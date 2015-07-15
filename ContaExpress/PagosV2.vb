Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Osuna.Utiles.Conectividad
Imports CrystalDecisions.Shared
Imports EnviaInformes

Public Class PagosV2
#Region "Fields"

    Private cmd As SqlCommand

    'Variable para LA TABLA FACTURA AFECTADA#######################################
    Dim CodAfectada As Integer

    'Variable para guardar el ingreso en cajaingreso#######################################
    Dim codingreso As String
    Private direccion As String
    Dim dr As SqlDataReader
    Dim ds As New DataSet
    Dim existe As Integer
    Dim f As New Funciones.Funciones
    Dim FechaRecibo As String
    Public ComprasPago, CodigoCompra As Integer

    '#############################################################
    'IMPRESORA
    Dim impresora As String

    '##############################################################
    Private myTrans As SqlTransaction
    Dim NumRecibo, NumSucursal, NumMaquina, NroRango As String
    Private row As DataRow
    Private ser As BDConexión.BDConexion
    Private sistema As New Funciones.Sistema
    Dim sql As String
    Private sqlc As SqlConnection
    Dim dtmoneda As DataTable
    Dim dr2 As DataRow
    Dim cantdecimales As Integer

    '#############################################################
    Dim TipoPago As String
    Dim TotalCobro, TotalFalta, TotalDebe, TotalACobrar, AuxMontoIgresado As Decimal
    Dim VarGlobNroCuota, VarGlobNroCompra, BanExiste, VarGlobDeudaCobar, VarGlobSaldoFavor As Integer
    Dim ControlFiltro1, ControlFiltro2, ControlFiltro3, bt_nuevo, CabPagoMax, ErrorGuardar As Integer
    Dim SaldoFacTotal, Permiso, Saldo As Decimal
    Dim FechaFiltroDesde, FechaFiltroHasta As Date
    Dim btnuevo, btmodificar, ModifNC, yaPregunte, SaldoNC, indexNC As Integer
    Public Config1, Config2, Config3, Config4, Config5, Config6, Config7, Config8 As String
    Dim VCabPago As Double
    Public panelactivo, txtCodDevolucion As String
    Dim indexPago, ContNewFilasEdit As Integer
    Dim mensajeerror, IDRangoRecibos As String
    Dim errorFiltroFecha As Integer = 0
    Dim errorFiltroRango As Integer = 0
    Dim ExisteAnt As String = ""
    Dim PorcRetencion, PorcRetencionRenta As Double
    Dim NroRetencion, RangoIDRetencion, ImprimeRenta As String
    Dim IsRetencion As Integer = 0
    Dim IsRetencionRenta As Integer = 0
    Dim PanelProv As Integer = 0
    Dim ValorRetener As Integer = 0

#End Region 'Fields

#Region "Constructors"

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        ds = New DataSet("INFORME")
        Try
            direccion = sistema.AppPath(False)
            direccion = direccion & "\" & "DsInformes.xsd"
        Catch ex As Exception

        End Try

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

#End Region 'Constructors

#Region "Methods"

    Private Sub AUDITORIAAMODIFICACOBRO()
        Dim CODIGO As Integer = f.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS" & _
        "(CODIGO, EMPRESA, TABLA, NUMCODIGO," & _
        "DESCRIPCION, FECHA, USUARIO, NIVEL," & _
        "INSERTAR, MODIFICAR, ELIMINAR) VALUES" & _
        "( " & CODIGO & ", " & EmpCodigo & ",  " & _
        "'COMPRASFORMAPAGO', '" & CODIGO & "', " & _
        "'ACUALIZACION EN TABLA COMPRASFORMAPAGO' ," & _
        "CONVERT(DATETIME, getdate(), 103 )," & _
        "'" & UsuDescripcion & "', Null , 0,  1 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAINSERTACOBRO()
        Dim CODIGO As Integer = f.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS" & _
        "(CODIGO, EMPRESA, TABLA, NUMCODIGO," & _
        "DESCRIPCION, FECHA, USUARIO, NIVEL," & _
        "INSERTAR, MODIFICAR, ELIMINAR) VALUES" & _
        "( " & CODIGO & ", " & EmpCodigo & ",  " & _
        "'COMPRASFORMAPAGO', '" & CODIGO & "', " & _
        "'INSERCIÓN EN TABLA COMPRASFORMAPAGO' ," & _
        "CONVERT(DATETIME, getdate(), 103 )," & _
        "'" & UsuDescripcion & "', Null , 1,  0 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        DeshabilitarControles()
        LimpiarDetalle()

        Me.PROVEEDORFILLPAGOTableAdapter.Fill(Me.DsPagosFacutas.PROVEEDORFILLPAGO)
        FechaFiltro()
        Me.CABECERAPAGOSTableAdapter.Fill(Me.DsPagosFacutas.CABECERAPAGOS, FechaFiltroDesde, FechaFiltroHasta)
        FACTURAPAGARTableAdapter.Fill(DsPagosFacutas.FACTURAPAGAR, GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value)
        FACTURASVENCIDASTableAdapter.Fill(DsPagosFacutas.FACTURASVENCIDAS, Today, GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value)

        VarGlobDeudaCobar = 0 : btnuevo = 0 : btmodificar = 0
        lblCuotas.Text = "" : lblNroFacturas.Text = "" : lblPagado.Text = "" : lblSaldoFavor.Text = ""
        ObtenerSaldoVencido() : CalcularSaldo()

        pnlFacturasaPagar.Visible = False
        lblDetalles.Text = "Ver Detalles"
        btnDetalles.Image = My.Resources.Display
        ModificarDetPictureBox.Image = My.Resources.Edit
        ModificarDetPictureBox.Enabled = True
        tsEditar.Enabled = True
        PendientesPago.Enabled = True

        dgvPagos.Enabled = True
        BtnFiltro.Enabled = True
        BuscarTextBox.Enabled = True
        FiltroPagosActivo.Enabled = True
        TipoCobroPictureBox.Enabled = True
        cmbGenerarRecibo.Text = ""

        btnAgregarPagos.BringToFront()
        btnEliminarPagos.BringToFront()
        ModifNC = 0
        lbxTipoPago.SelectedValue = 1
    End Sub

    'by Yolanda Zelaya
    Private Sub ObtenerSaldoVencido()
        Dim rows As Integer = dgvFacturasVencidas.Rows.Count
        Dim SaldoVencido As Double = 0

        If rows = 0 Then
            lblMontoTotalVencido.Text = "0 Gs"
        Else
            For x = 1 To rows
                SaldoVencido = SaldoVencido + dgvFacturasVencidas.Rows(x - 1).Cells("SaldoVencido").Value()
            Next
            lblMontoTotalVencido.Text = FormatNumber(SaldoVencido, 2)
        End If
    End Sub

    'by Yolanda Zelaya
    Private Sub CalcularSaldo()
        Dim x As Integer = dgvFacturasaPagar.RowCount
        SaldoFacTotal = 0
        For i = 1 To x
            SaldoFacTotal = SaldoFacTotal + CDec(dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value)
        Next
        lblMontoSelecionado.Text = FormatNumber(SaldoFacTotal, 2)
    End Sub

    Private Sub PagosV2_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ComprasPago = 0
    End Sub

    Private Sub NroReciboTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NroReciboTextBox.LostFocus
        lblProximoNro.Text = "Nro. Recibo: " + NroReciboTextBox.Text + " " + tbxNroSerie.Text
    End Sub

    Private Sub tbxNroSerie_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroSerie.LostFocus
        lblProximoNro.Text = "Nro. Recibo: " + NroReciboTextBox.Text + " " + tbxNroSerie.Text
    End Sub

    Private Sub PagosV2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then 'Ir a Montos
            If tbxMonto.Enabled = True Then
                tbxMonto.Focus()
            End If
        ElseIf e.KeyCode = Keys.F3 Then 'Cobrar / Panel de Pendientes
            If panelactivo = "Pendientes" Then
                btnCobrar_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F4 Then 'Cobrar / Panel de Pendientes
            If panelactivo = "Pendientes" Then
                btnRefresh_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F5 Then 'Nuevo
            If NuevoPictureBox.Enabled = True Then
                NuevoPictureBox_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F6 Then 'Modificar Pago
            If ModificarDetPictureBox.Enabled = True Then
                ModificarDetPictureBox_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F7 Then 'Confirmar Pago
            If ConfirmarPictureBox.Enabled = True Then
                ConfirmarPictureBox_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F8 Then  'Cancelar
            If CancelarPictureBox.Enabled = True Then
                CancelarPictureBox_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If pnlFacturasaPagar.Visible = True Then
                btnDetalles_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub PagosV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Permiso = PermisoAplicado(UsuCodigo, 11)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permisos para Abrir esta ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        ObtenerConfig()

        CmbAño.SelectedText = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1

        btnuevo = 0 : btmodificar = 0
        ControlFiltro1 = 1 : ControlFiltro2 = 0 : ControlFiltro3 = 0 : bt_nuevo = 0 : VarGlobDeudaCobar = 0
        lblCuotas.Text = "" : lblNroFacturas.Text = "" : lblPagado.Text = "" : lblSaldoFavor.Text = ""

        Me.USUARIOTableAdapter.Fill(Me.DsPagosFacutas.USUARIO)
        Me.TIPOFORMACOBROTableAdapter1.Fill(Me.DsPagosFacutas.TIPOFORMACOBRO)
        Me.COMPRASFORMAPAGOTableAdapter.Fill(Me.DsPagosFacutas.COMPRASFORMAPAGO)
        Me.CAJATableAdapter.Fill(Me.DsPagosFacutas.CAJA)
        Me.MONEDATableAdapter1.Fill(Me.DsPagosFacutas.MONEDA)
        Me.PROVEEDORFILLPAGOTableAdapter.Fill(Me.DsPagosFacutas.PROVEEDORFILLPAGO)
        Me.PROVEEDORTableAdapter.Fill(Me.DsPagosFacutas.PROVEEDOR, "%", "%", "%", "%")
        Me.FACTURASPAGARPENDIENTESTableAdapter.Fill(Me.DsPagosFacutas.FACTURASPAGARPENDIENTES)
        dtmoneda = MONEDATableAdapter1.GetData()

        'InicializaFechaFiltro()
        If cbxMoneda.SelectedValue <> Nothing Then
            tbxCotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(cbxMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
            Dim SimboloEfectivo As String = f.FuncionConsultaString("SIMBOLO", "MONEDA", "CODMONEDA", cbxMoneda.SelectedValue)
            Me.COTIZACIONTableAdapter.Fill(DsPagosFacutas.COTIZACION, cbxMoneda.SelectedValue)
            If SimboloEfectivo = "0" Then
                lblSimbolo.Text = "Gs"
            Else
                lblSimbolo.Text = SimboloEfectivo
            End If
        End If

        'SOLO CUANDO HAY UN SOLO COMPROBANTE RECIBO
        IDRangoRecibos = f.FuncionConsultaString("DETPC.RANDOID", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "ACTIVO = 1 AND PAGOS", 1)

        If Config3 = "Panel Facturas Pendientes" Then
            PanelTodosPendientes.BringToFront()
            panelactivo = "Pendientes"
            PendientesPago_Click(Nothing, Nothing)
            NuevoPictureBox.Visible = False : EliminarPictureBox.Visible = False : ModificarDetPictureBox.Visible = False : CancelarPictureBox.Visible = False
            tbxNumCliPend.Text = "" : cmbCliPend.SelectedIndex = -1 : ConfirmarPictureBox.Visible = False
            tbxNumCliPend.Focus()

            MenuCobros.Enabled = False
        ElseIf Config3 = "Panel de Pagos" Then
            MenuCobros.Enabled = True
            panelactivo = "SplitPagos"
            PagosActivo_Click(Nothing, Nothing)
        End If

        If Config4 = "N° de Proveedor" Then
            rbCliente.Checked = True
            rbFactura_CheckedChanged(Nothing, Nothing)
        ElseIf Config4 = "N° de Factura" Then
            rbFactura.Checked = True
            rbFactura_CheckedChanged(Nothing, Nothing)
            tbxNroFacturaPend.Focus()
        End If

        pnlBlanco.BringToFront()
        lbxTipoPago.SelectedItem = "Efectivo"
        tbxConcepto.Visible = False : lblConcepto.Visible = False : lblConceptoAyuda.Visible = False : pnlFacturasaPagar.Visible = False

        PorcRetencion = f.FuncionConsultaDecimal("PORRETENCIO", "EMPRESA", "CODEMPRESA", EmpCodigo)
        PorcRetencionRenta = f.FuncionConsultaDecimal("PORCRETRENTA", "EMPRESA", "CODEMPRESA", EmpCodigo)

        LimpiaFormulario()
        DeshabilitarControles()

        lblDGVCant.Text = "Cant. de Items:" & dgvPagos.RowCount
    End Sub

    Private Sub InicializaFechaFiltro()
        Dim nromes, nroaño As Integer
        nromes = Today.Month
        nroaño = Today.Year

        FechaFiltroDesde = New DateTime(nroaño, nromes, 1)
        FechaFiltroHasta = New DateTime(nroaño, nromes, DateTime.DaysInMonth(nroaño, nromes))
    End Sub

    Private Sub DeshabilitarControles()
        NuevoPictureBox.Enabled = True
        tsNuevaVenta.Enabled = True
        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Cursor = Cursors.Hand

        ConfirmarPictureBox.Enabled = False
        tsGuardar.Enabled = False
        ConfirmarPictureBox.Image = My.Resources.ApproveOff
        ConfirmarPictureBox.Cursor = Cursors.Arrow
        CancelarPictureBox.Enabled = False
        tsCancelar.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow

        pnlDatosdelPago.Enabled = False
        pnlDetallePago.Enabled = False
        dgvFacturasaPagar.Enabled = False

        GridViewProveedor.Enabled = True
        BuscarTextBox.Enabled = True

        tbxRucProveedor.Enabled = False
        CmbProveedor.Enabled = False
        tbxNroProv.Enabled = False


        lblDetalles.Text = "Esconder"
        lblDGVCant.Text = "Cant. de Items:" & dgvPagos.RowCount
    End Sub

    Private Sub Grabar()
        If cmbGenerarRecibo.Text = "Automático" Then
            ActualizaRango()
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        CabPagoMax = 0
        Try
            InsertaFormaCobro()
            InsertaenTablasCaja1()

            'En Caso que sea una nota de credito debemos guardar el monto en Saldo de Ncredito
            InsertarNotaCredito()

            myTrans.Commit()

            LimpiaFormulario()
            MessageBox.Show("Pago efectuado correctamente! ", "POSEXPRESS")
            ErrorGuardar = 0

            Try
                AUDITORIAINSERTACOBRO()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            End Try
            MessageBox.Show("Ocurrió un error al Insertar el Pago", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            lblPagosEstado.Text = "Error al Pagar"
            ErrorGuardar = 1
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub InsertarNotaCredito()
        Dim Importe, NroNotaCredito, CodNotaCredito As String
        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

        For i = 1 To c
            NroNotaCredito = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMDEVOLUCION").Value

            If NroNotaCredito <> "" Or NroNotaCredito <> Nothing Then
                CodNotaCredito = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODNRODEV").Value

                Importe = System.Math.Abs(CobroFormaPagoDataGridView.Rows(i - 1).Cells("IMPORTE").Value)
                Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
                Importe = Replace(Importe, ",", ".")

                sql = ""
                sql = " DECLARE @PAGADO INT,@CODIGO NUMERIC(18,0), @SALDO AS NUMERIC(18,5) " & _
                    "SELECT @SALDO=SALDO FROM DEVOLUCIONCOMPRA " & _
                    "WHERE CODDEVOLUCION = " & CodNotaCredito & " " & vbCrLf & _
                    "IF @SALDO<=" & Importe & " " & _
                    "begin " & _
                    "SET @PAGADO =1 " & _
                    "End " & _
                    "else " & _
                    "begin " & _
                    "SET @PAGADO =0 " & _
                    "End " & _
                    "UPDATE DEVOLUCIONCOMPRA SET SALDO = (SALDO - " & Importe & "),COBRADO=@PAGADO " & _
                    "WHERE CODDEVOLUCION = " & CodNotaCredito & " "
                ''sql = "UPDATE NCREDITO SET SALDO = (SALDO - " & Importe & ") WHERE CODDEVOLUCION = " & CodNotaCredito & _
                'sql = " UPDATE DEVOLUCIONCOMPRA SET COBRADO = 1, SALDO = (SALDO - " & Importe & ") WHERE CODDEVOLUCION = " & CodNotaCredito

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub ActualizaRango()
        Try
            sql = ""

            Dim RangoId As String = f.FuncionConsultaString("DETPC.RANDOID", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "ACTIVO = 1 AND PAGOS", 1)
            sql = "UPDATE DETPC SET ULTIMO = " & NroReciboTextBox.Text & " where RANDOID=" & RangoId & ""

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            '---------------------------- DESACTIVA RANGO ----------------------------
            'Verificamos si es el ultimo Nro del rango de comprobantes y ponemos como desabilitado dicho rango
            Dim Rango2 As String = f.FuncionConsultaString("RANGO2", "DETPC", "ACTIVO = 1 AND RANDOID", RangoId)

            If Rango2 = NroReciboTextBox.Text Then

                sql = ""
                sql = "UPDATE DETPC SET ACTIVO=0 WHERE RANDOID =" & RangoId & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub HabilitarControles()
        NuevoPictureBox.Enabled = False
        tsNuevaVenta.Enabled = False
        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Cursor = Cursors.Arrow
        ConfirmarPictureBox.Enabled = True
        tsGuardar.Enabled = True
        ConfirmarPictureBox.Image = My.Resources.Approve
        ConfirmarPictureBox.Cursor = Cursors.Hand
        CancelarPictureBox.Enabled = True
        tsCancelar.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand

        pnlDatosdelPago.Enabled = True
        pnlDetallePago.Enabled = True
        dgvFacturasaPagar.Enabled = True

        GridViewProveedor.Enabled = False
        BuscarTextBox.Enabled = False

        tbxRucProveedor.Enabled = True
        CmbProveedor.Enabled = True
        tbxNroProv.Enabled = True
        btnAsterisco.Enabled = True


        lblDetalles.Text = "Ver Detalles"
    End Sub

    Private Sub InsertaenTablasCaja1()
        Dim CodPago, CodCompra, Importe, NroCuota, NroRecibo, NumCompra As String
        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

        NroCuota = "" : CodCompra = ""
        NroRecibo = NroReciboTextBox.Text

        For i = 1 To c
            CodPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODPAGO").Value
            CodCompra = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODCOMPRA").Value
            NumCompra = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMCOMPRA").Value
            NroCuota = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NROCUOTA").Value

            Importe = CobroFormaPagoDataGridView.Rows(i - 1).Cells("IMPORTE").Value
            Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
            Importe = Replace(Importe, ",", ".")

            sql = ""
            sql = " DECLARE @PAGADO INT,@CODIGO NUMERIC(18,0), @SALDO AS NUMERIC(18,5) " & _
                       "SELECT @SALDO=SALDOCUOTA FROM FACTURAPAGAR " & _
                       "WHERE CODCOMPRA = " & CodCompra & " AND NUMEROCUOTA =  " & NroCuota & " " & vbCrLf & _
                       "IF @SALDO<=" & Importe & " " & _
                       "begin " & _
                       "SET @PAGADO =1 " & _
                       "End " & _
                       "else " & _
                       "begin " & _
                       "SET @PAGADO =0 " & _
                       "End " & _
                       "UPDATE FACTURAPAGAR SET SALDOCUOTA = SALDOCUOTA- " & Importe & ",PAGADO=@PAGADO " & _
                       "WHERE CODCOMPRA = " & CodCompra & " AND NUMEROCUOTA = " & NroCuota & " "
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        Next

        VarGlobNroCompra = CodCompra
    End Sub

    Private Sub RegsitrarSaldo()
        Dim SaldoFavor As String = VarGlobSaldoFavor
        SaldoFavor = Replace(SaldoFavor, ",", ".")
        SaldoFavor = SaldoFavor

        sql = ""
        sql = "INSERT FACTURAPAGAR (CODCOMPRA,NUMEROCUOTA,SALDOCUOTA,IMPORTECUOTA,CODEMPRESA,CODUSUARIO,PAGADO, DESTIPOPAGO,TIPOFACTURA,FECGRA)" & _
              "VALUES (" & VarGlobNroCompra & ", 0, " & SaldoFavor & "," & SaldoFavor & "," & EmpCodigo & "," & UsuCodigo & ",0,'EFECTIVO', 'SALDO A FAVOR',GETDATE())"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaVuelto()
        Dim Cotizacion1 As String
        Dim CodVenta As String
        Cotizacion1 = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", CODMONEDAPRINCIPAL.ToString + " ORDER BY FECHAMOVIMIENTO DESC")
        Cotizacion1 = Cotizacion1.Replace(".", "")
        Cotizacion1 = Cotizacion1.Replace(",", ".")

        Dim vuelto As String = CDec(VarGlobDeudaCobar) - CDec(TotalDebe)
        vuelto = Funciones.Cadenas.QuitarCad(vuelto, ".")
        vuelto = Replace(vuelto, ",", ".")


        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

        CodVenta = CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODVENTA").Value

        Dim MaxIdApertura As Integer
        MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", NumCaja)

        sql = ""
        sql = "DECLARE @CODCOBRO AS INT " & _
        "SELECT @CODCOBRO=ISNULL(MAX(CODCOBRO),0)+ 1 FROM COMPRASFORMAPAGO " & _
        "insert into COMPRASFORMAPAGO" & _
        "(CODCOBRO, CODVENTA, CODTIPOCOBRO," & _
        "CODMONEDA, COTIZACION1, COTIZACION2," & _
        "IMPORTE, DESTIPOCOBRO, FECHACOBRO, " & _
        "CODUSUARIO, CODEMPRESA," & _
        "id_apertura,vuelto) " & _
        "VALUES (@CODCOBRO, " & CDec(CodVenta) & ", " & _
        "1,   " & CODMONEDAPRINCIPAL & ", " & _
        "" & Cotizacion1 & ",  0, " & _
        "" & vuelto & ", 'Efectivo', " & _
        "CONVERT(DATETIME, '" & Today.ToShortDateString & "', 103)," & _
        " " & UsuCodigo & ", " & EmpCodigo & "," & MaxIdApertura & ",1) "
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaFormaCobro()
        Dim CodPago, CodCompra, CodTipoPago, CodMoneda, Cotizacion1, Importe, DesTipoPago, NroCuota, NroRecibo, NroRef, NroNotaCredito, NroRetencion, FechaPago, FechaRegPago As String
        Dim MaxIdApertura, CabPago, CodTipoFormaPago, CodAutorizado As Integer
        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

        NroRecibo = NroReciboTextBox.Text
        CabPago = f.Maximo("CABPAGO", "COMPRASFORMAPAGO")
        CabPago = CabPago + 1
        CabPagoMax = CabPago

        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim Concat As String = dtpFechaPago.Text
        Dim Concatenar As String = Concat & " " + hora
        FechaRegPago = Concatenar

        For i = 1 To c
            'CodPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODPAGO").Value
            CodCompra = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODCOMPRA").Value
            DesTipoPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("DESTIPOPAGO").Value
            CodTipoPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODTIPOPAGO").Value
            NroCuota = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NROCUOTA").Value
            NroNotaCredito = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMDEVOLUCION").Value
            NroRetencion = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMRETENCION").Value
            NroRef = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NROREF").Value
            CodMoneda = cbxMoneda.SelectedValue
            CodTipoFormaPago = CobroFormaPagoDataGridView.Rows(c - 1).Cells("FORMAPAGO").Value
            CodAutorizado = cbxPagador.SelectedValue

            Dim fechapago2 As Date = CobroFormaPagoDataGridView.Rows(i - 1).Cells("FECHAPAGO").Value
            FechaPago = fechapago2.ToString("dd/MM/yyy")
            FechaPago = FechaPago & " " & Now.ToString("HH:mm:ss")

            Cotizacion1 = tbxCotizacion.Text
            Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
            Cotizacion1 = Replace(Cotizacion1, ",", ".")

            Importe = System.Math.Abs(CobroFormaPagoDataGridView.Rows(i - 1).Cells("IMPORTE").Value)
            Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
            Importe = Replace(Importe, ",", ".")

            MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODCUENTA").Value)

            If NroCuota <> 0 Then
                sql = ""
                sql = "INSERT INTO COMPRASFORMAPAGO (CODPAGO, CODCOMPRA, CODTIPOPAGO, CODMONEDA, COTIZACION1,OBSERVACIONES, IMPORTE, DESTIPOPAGO, FECHAPAGO, FECHAREGISTROPAG," & _
                      "CH_NROCHEQUE,  CODUSUARIO, CODEMPRESA,NROCUOTA, NRORECIBO,  NUMDEVOLUCION, NUMRETENCION,id_apertura,CABPAGO,TIPOPAGO,AUTORIZADO,RECIBONROSERIE) " & _
                      "VALUES ((Select max(CODPAGO+1) From COMPRASFORMAPAGO)" & ", " & CodCompra & ", " & CodTipoPago & ", " & CodMoneda & ", " & Cotizacion1 & ", '" & tbxObservaciones.Text & "'," & _
                      Importe & ", '" & DesTipoPago & "', CONVERT (DATETIME,'" & FechaPago & "',103), CONVERT (DATETIME,'" & FechaRegPago & "',103), '" & NroRef & "', " & UsuCodigo & ", " & EmpCodigo & _
                      ", " & NroCuota & ",'" & NroRecibo & "', '" & NroNotaCredito & "', '" & NroRetencion & "'," & MaxIdApertura & ", " & CabPago & ", " & CodTipoFormaPago & "," & CodAutorizado & ",'" & tbxNroSerie.Text & "')"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub
    Private Sub ModificaRetencion()
        Dim CodProveedor, CodCompra, CodTipoPago, ImporteRetenido, CodAutorizado As Integer
        Dim FechaPago, Compras, FacturasNro As String
        Dim Tiporet As Integer
        Dim ImporteRetAEliminar As Double
        Dim c As Integer = CobroFormaPagoDataGridView.RowCount
        Dim contmodificados As Integer = 0

        CodProveedor = CmbProveedor.SelectedValue : Compras = "" : ImporteRetenido = 0 : FacturasNro = "" : FechaPago = ""
        For i = 1 To c
            If Not (CobroFormaPagoDataGridView.Rows(i - 1).Cells("EstadoGrilla").Value Is Nothing) Then
                contmodificados = contmodificados + 1
            End If
            CodTipoPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODTIPOPAGO").Value
            If CobroFormaPagoDataGridView.Rows(i - 1).Cells("EstadoGrilla").Value = "D" Then
                If CodTipoPago = 6 Or CodTipoPago = 10 Then
                    NroRetencion = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMRETENCION").Value
                    ImporteRetAEliminar = ImporteRetAEliminar + CobroFormaPagoDataGridView.Rows(i - 1).Cells("IMPORTE").Value
                End If
            Else
                If CodTipoPago = 6 Or CodTipoPago = 10 Then
                    If CodTipoPago = 6 Then
                        Tiporet = 1 'RET IVA
                    Else
                        Tiporet = 0 'RET RENTA
                    End If
                    CodCompra = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODCOMPRA").Value

                    If Compras.Length = 0 Then
                        Compras = CodCompra.ToString
                    Else
                        Compras = Compras & "," & CodCompra.ToString
                    End If

                    ImporteRetenido = ImporteRetenido + CobroFormaPagoDataGridView.Rows(i - 1).Cells("IMPORTE").Value
                    NroRetencion = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMRETENCION").Value
                    CodAutorizado = cbxPagador.SelectedValue

                    Dim fechapago2 As Date = CobroFormaPagoDataGridView.Rows(i - 1).Cells("FECHAPAGO").Value
                    FechaPago = fechapago2.ToString("dd/MM/yyy")
                    FechaPago = FechaPago & " " & Now.ToString("HH:mm:ss")
                End If
            End If
        Next

        If contmodificados > 0 Then
            Dim codretencion As Integer = f.FuncionConsultaString("CODRETENCION", "RETENCIONCOMPRA", "ESTADO=1 AND NUMRETENCION", NroRetencion)
            Dim montoretencion As Double = f.FuncionConsultaString("TOTALRETENCION", "RETENCIONCOMPRA", "CODRETENCION", codretencion)
            If montoretencion = FormatNumber(ImporteRetAEliminar, 0) Then
                Try
                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc

                    sql = ""
                    sql = "UPDATE RETENCIONCOMPRA SET ESTADO=2 WHERE CODRETENCION=" & codretencion

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Al Eliminar todos los items de la Retención, el Nro. Retención ha sido Anulado.", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error al tratar de Anular la Retencion", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    sqlc.Close()
                    Exit Sub
                End Try
                sqlc.Close()
            Else
                Dim objCommand As New SqlCommand
                Dim MontoSinIVA, IvaIncluido, ImporteTotalFactura As Decimal
                MontoSinIVA = 0 : IvaIncluido = 0 : ImporteTotalFactura = 0

                Try
                    objCommand.CommandText = "SELECT  dbo.FACTURAPAGAR.CODCOMPRA, C2.TOTALCOMPRA - ISNULL   " & _
                                             "((SELECT SUM(IMPORTE) AS Expr1  " & _
                                             "FROM dbo.COMPRASFORMAPAGO AS CFPAUX  " & _
                                             "WHERE (CODCOMPRA = C2.CODCOMPRA) AND (CODTIPOPAGO = 5)), 0) AS SALDO, C2.TOTALIVA - ISNULL  " & _
                                             "((SELECT SUM(TOTALIVA) AS Expr1  " & _
                                             "FROM dbo.DEVOLUCIONCOMPRA  " & _
                                             "WHERE (NUMDEVOLUCION IN  (SELECT NUMDEVOLUCION AS Expr1  " & _
                                             "FROM dbo.COMPRASFORMAPAGO AS CFP2   WHERE (CODCOMPRA = C2.CODCOMPRA) AND (CODTIPOPAGO = 5)))), 0) AS TOTALIVA, C2.NUMCOMPRA  " & _
                                             "FROM dbo.FACTURAPAGAR INNER JOIN dbo.COMPRAS AS C2 ON dbo.FACTURAPAGAR.CODCOMPRA = C2.CODCOMPRA   " & _
                                             "GROUP BY C2.CODCOMPRA, dbo.FACTURAPAGAR.CODCOMPRA, C2.TOTALCOMPRA, C2.TOTALIVA, dbo.FACTURAPAGAR.PAGADO, C2.CODPROVEEDOR ,C2.NUMCOMPRA  " & _
                                             "HAVING (dbo.FACTURAPAGAR.CODCOMPRA IN (" & Compras & "))"
                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                    If odrConfig.HasRows Then
                        Do While odrConfig.Read()
                            ImporteTotalFactura = ImporteTotalFactura + odrConfig("SALDO")
                            MontoSinIVA = MontoSinIVA + (odrConfig("SALDO") - odrConfig("TOTALIVA"))
                            IvaIncluido = IvaIncluido + odrConfig("TOTALIVA")

                            If FacturasNro.Length = 0 Then
                                FacturasNro = odrConfig("NUMCOMPRA").ToString
                            Else
                                FacturasNro = FacturasNro & "/" & odrConfig("NUMCOMPRA").ToString
                            End If
                        Loop
                    End If

                    odrConfig.Close()
                    objCommand.Dispose()

                Catch ex As Exception
                    MessageBox.Show("Error al Tratar de Procesar los Datos de la Retención", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    objCommand.Dispose()
                    Exit Sub
                End Try

                Try
                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc

                    sql = ""
                    sql = "UPDATE RETENCIONCOMPRA SET CODPROVEEDOR=" & CodProveedor & ",FECHARETENCION=CONVERT(DATETIME,'" & FechaPago & "',103),DESCRIPCIONRET ='" & FacturasNro & "',IMPORTERETTOTAL=" & CInt(ImporteTotalFactura) & ",IMPORTERETSINIVA=" & CInt(MontoSinIVA) & ",IMPORTERETIVA=" & CInt(IvaIncluido) & ",TOTALRETENCION=" & CInt(ImporteRetenido) & ",CODUSUARIO=" & CodAutorizado & " WHERE CODRETENCION=" & codretencion

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error al Tratar de Modificar la Retencion", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    sqlc.Close()
                    Exit Sub
                End Try
                sqlc.Close()
            End If
        End If
    End Sub
    Private Sub InsertarRetencion()
        Dim CodProveedor, CodCompra, CodPago, ImporteRetenido, CodAutorizado As Integer
        Dim FechaPago, Compras, FacturasNro As String
        Dim TipoRet As Integer
        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

        CodProveedor = CmbProveedor.SelectedValue : Compras = "" : ImporteRetenido = 0 : FacturasNro = "" : FechaPago = ""
        For i = 1 To c
            If CobroFormaPagoDataGridView.Rows(i - 1).Cells("EstadoGrilla").Value <> "D" Then
                CodPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODTIPOPAGO").Value

                If CodPago = 6 Or CodPago = 10 Then
                    If CodPago = 6 Then
                        TipoRet = 1 'RET IVA
                    Else
                        TipoRet = 0 'RET RENTA
                    End If
                    CodCompra = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODCOMPRA").Value

                    If Compras.Length = 0 Then
                        Compras = CodCompra.ToString
                    Else
                        Compras = Compras & "," & CodCompra.ToString
                    End If

                    ImporteRetenido = ImporteRetenido + CobroFormaPagoDataGridView.Rows(i - 1).Cells("IMPORTE").Value
                    NroRetencion = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMRETENCION").Value
                    CodAutorizado = cbxPagador.SelectedValue

                    Dim fechapago2 As Date = CobroFormaPagoDataGridView.Rows(i - 1).Cells("FECHAPAGO").Value
                    FechaPago = fechapago2.ToString("dd/MM/yyy")
                    FechaPago = FechaPago & " " & Now.ToString("HH:mm:ss")
                End If
            End If
        Next

        Dim objCommand As New SqlCommand
        Dim MontoSinIVA, IvaIncluido, ImporteTotalFactura As Decimal
        MontoSinIVA = 0 : IvaIncluido = 0 : ImporteTotalFactura = 0

        Try
            objCommand.CommandText = "SELECT  dbo.FACTURAPAGAR.CODCOMPRA, C2.TOTALCOMPRA - ISNULL   " & _
                                     "((SELECT SUM(IMPORTE) AS Expr1  " & _
                                     "FROM dbo.COMPRASFORMAPAGO AS CFPAUX  " & _
                                     "WHERE (CODCOMPRA = C2.CODCOMPRA) AND (CODTIPOPAGO = 5)), 0) AS SALDO, C2.TOTALIVA - ISNULL  " & _
                                     "((SELECT SUM(TOTALIVA) AS Expr1  " & _
                                     "FROM dbo.DEVOLUCIONCOMPRA  " & _
                                     "WHERE (NUMDEVOLUCION IN  (SELECT NUMDEVOLUCION AS Expr1  " & _
                                     "FROM dbo.COMPRASFORMAPAGO AS CFP2   WHERE (CODCOMPRA = C2.CODCOMPRA) AND (CODTIPOPAGO = 5)))), 0) AS TOTALIVA, C2.NUMCOMPRA  " & _
                                     "FROM dbo.FACTURAPAGAR INNER JOIN dbo.COMPRAS AS C2 ON dbo.FACTURAPAGAR.CODCOMPRA = C2.CODCOMPRA   " & _
                                     "GROUP BY C2.CODCOMPRA, dbo.FACTURAPAGAR.CODCOMPRA, C2.TOTALCOMPRA, C2.TOTALIVA, dbo.FACTURAPAGAR.PAGADO, C2.CODPROVEEDOR ,C2.NUMCOMPRA  " & _
                                     "HAVING (dbo.FACTURAPAGAR.CODCOMPRA IN (" & Compras & "))"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    ImporteTotalFactura = ImporteTotalFactura + odrConfig("SALDO")
                    MontoSinIVA = MontoSinIVA + (odrConfig("SALDO") - odrConfig("TOTALIVA"))
                    IvaIncluido = IvaIncluido + odrConfig("TOTALIVA")

                    If FacturasNro.Length = 0 Then
                        FacturasNro = odrConfig("NUMCOMPRA").ToString
                    Else
                        FacturasNro = FacturasNro & "/" & odrConfig("NUMCOMPRA").ToString
                    End If
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()

        Catch ex As Exception
            MessageBox.Show("Error al Tratar de Procesar los Datos", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            objCommand.Dispose()
            Exit Sub
        End Try

        Try
            'Antes de Insertar obtenemos el CodRango
            Dim RangoID As Integer
            Dim vFrom, vWhere As String

            vFrom = "dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE"
            vWhere = "(dbo.DETPC.ULTIMO < dbo.DETPC.RANGO2) AND (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.RETENCION = 1) And DETPC.IP "

            RangoID = f.FuncionConsultaDecimal("dbo.DETPC.RANDOID", vFrom, vWhere, CodigoMaquina)


            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            sql = ""
            sql = "INSERT INTO RETENCIONCOMPRA (CODPROVEEDOR,NUMRETENCION,FECHARETENCION,DESCRIPCIONRET,IMPORTERETTOTAL,IMPORTERETSINIVA,IMPORTERETIVA,TOTALRETENCION,TIPORETENCION,CODUSUARIO,CODRANGO,ESTADO) " & _
                  "VALUES(" & CodProveedor & ",'" & NroRetencion & "', CONVERT(DATETIME,'" & FechaPago & "',103),'" & FacturasNro & "'," & CInt(ImporteTotalFactura) & "," & CInt(MontoSinIVA) & "," & CInt(IvaIncluido) & "," & CInt(ImporteRetenido) & "," & TipoRet & "," & CodAutorizado & "," & RangoID & ",1)"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error al Tratar de Guardar la Retencion", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sqlc.Close()
            Exit Sub
        End Try

        sqlc.Close()
    End Sub

    Private Sub EliminarRetencion()
        Dim CodPago As Integer
        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

        For i = 1 To c
            CodPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODTIPOPAGO").Value

            If CodPago = 6 Then
                NroRetencion = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMRETENCION").Value
            End If
        Next
        Try
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            sql = ""
            sql = "DELETE RETENCIONCOMPRA WHERE NUMRETENCION = '" & NroRetencion & "'"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error al Tratar de Eliminar la retencion", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sqlc.Close()
            Exit Sub
        End Try

        sqlc.Close()
    End Sub

    Private Sub LimpiaFormulario()
        dtpFechaPago.Text = "" : NroReciboTextBox.Text = ""
        dtpFechaPago.Text = Today.ToShortDateString

        'Limpiamos los totales
        TotalCobro = 0 : TotalDebe = 0 : TotalFalta = 0

        lblMontoSelecionado.Text = "0 Gs"
    End Sub

    Private Sub cbxMoneda_GotFocus(sender As Object, e As System.EventArgs) Handles cbxMoneda.GotFocus
        cbxMoneda.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub cbxMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If chbxCotizacion.Checked = True Then
                tbxCotizacion.Focus()
            Else
                cbxPagador.Focus()
            End If

            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxMoneda_LostFocus(sender As Object, e As System.EventArgs) Handles cbxMoneda.LostFocus
        cbxMoneda.BackColor = Color.White
    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxMoneda.SelectedIndexChanged
        Dim SimboloEfectivo As String
        If cbxMoneda.SelectedValue <> Nothing Then
            tbxCotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(cbxMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")

            'SimboloEfectivo = f.FuncionConsultaString("SIMBOLO", "MONEDA", "CODMONEDA", cbxMoneda.SelectedValue)
            SimboloEfectivo = ""
            Me.COTIZACIONTableAdapter.Fill(DsPagosFacutas.COTIZACION, cbxMoneda.SelectedValue)

            For i = 0 To dtmoneda.Rows.Count - 1
                dr2 = dtmoneda.Rows(i)
                If dr2("CODMONEDA") = cbxMoneda.SelectedValue Then
                    SimboloEfectivo = dr2("SIMBOLO")
                    cantdecimales = dr2("CANTIDADDECIMALES")
                End If
            Next

            If cantdecimales = 1 Then
                tbxMonto.InputMask = "nnn,nnn,nnn,nnn.n"
            ElseIf cantdecimales = 2 Then
                tbxMonto.InputMask = "nnn,nnn,nnn,nnn.nn"
            ElseIf cantdecimales = 3 Then
                tbxMonto.InputMask = "nnn,nnn,nnn,nnn.nnn"
            ElseIf cantdecimales = 0 Then
                tbxMonto.InputMask = "nnn,nnn,nnn,nnn"
            Else
                tbxMonto.InputMask = "nnn,nnn,nnn,nnn.nn"
            End If

            If SimboloEfectivo = "0" Then
                lblSimbolo.Text = "Gs"
            Else
                lblSimbolo.Text = SimboloEfectivo
            End If
        End If

    End Sub

    Private Sub tbxNotaCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNotadeCredito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPagos.Focus()
            KeyAscii = 0
        End If

        If KeyAscii = 42 Then
            If ModifNC = 0 Then
                NdebitoTableAdapter.Fill(DsPagosFacutas.NDEBITO, CmbProveedor.SelectedValue)
            End If
            gbxNotaCredito.HeaderText = "Buscador de Nota de Crédito de " + CmbProveedor.Text
            UltraPopupControlContainer2.PopupControl = gbxNotaCredito
            UltraPopupControlContainer2.Show()
            e.Handled = True
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub dgvNotaCredito_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaCredito.CellDoubleClick
        If dgvNotaCredito.RowCount = 0 Then
            UltraPopupControlContainer2.Close()
        Else
            'Antes de Agregar la Nota de Credito debemos verificar que no se halla cargado aun --- Yolanda Zelaya
            If SaldoCERO(dgvNotaCredito.CurrentRow.Index) = True Then
                MessageBox.Show("El saldo de la Nota de Credito Nro :" & dgvNotaCredito.CurrentRow.Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value & " se encuentra agotado", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                indexNC = dgvNotaCredito.CurrentRow.Index
                SaldoNC = dgvNotaCredito.CurrentRow.Cells("SALDODataGridViewTextBoxColumn").Value
                tbxMonto.Text = dgvNotaCredito.CurrentRow.Cells("SALDODataGridViewTextBoxColumn").Value
                tbxNotadeCredito.Text = dgvNotaCredito.CurrentRow.Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value
                txtCodDevolucion = dgvNotaCredito.CurrentRow.Cells("CODDEVOLUCION").Value
                tbxMonto.Focus()
                UltraPopupControlContainer2.Close()
            End If
        End If
    End Sub

    Public Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        Dim MaxIdApertura, ExisteCierre As Integer
        Dim dt As DataTable = CAJATableAdapter.GetData
        Dim dr As DataRow
        Dim countcajas As Integer = 0
        Dim cajasabiertas As String = ""

        PanelCobroCuotas.BringToFront()
        PagosActivo.Image = My.Resources.PaymentActive
        FiltroPagosActivo.Image = My.Resources.User
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        PendientesPago.Image = My.Resources.Create

        pnlFacturasaPagar.Visible = False
        lblDetalles.Text = "Ver Detalles" : lblInfoRef.Visible = False
        btnDetalles.Image = My.Resources.DisplayActive

        btnuevo = 1 : btmodificar = 0

        PROVEEDORFILLPAGOBindingSource.RemoveFilter()
        PROVEEDORFILLPAGOTableAdapter.Fill(DsPagosFacutas.PROVEEDORFILLPAGO)

        Me.CABECERAPAGOSBindingSource.AddNew()
        Me.DETALLEPAGOTableAdapter.Fill(DsPagosFacutas.DETALLEPAGO, 0)

        NuevoPago()

        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows.Item(i)
            MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", dr("NumCaja"))
            If MaxIdApertura > 0 Then
                ExisteCierre = f.MaximoconWhere("id_apertura", "cierres", "id_apertura", MaxIdApertura)
                If ExisteCierre > 0 Then 'La Cuenta está cerrada
                Else
                    countcajas = countcajas + 1
                    If countcajas = 1 Then 'La primera caja
                        cajasabiertas = " NUMCAJA= " & dr("NumCaja")
                    Else
                        cajasabiertas = cajasabiertas + " OR NUMCAJA=" & dr("NumCaja")
                    End If
                End If
            End If
        Next
        If countcajas = 0 Then ' No hay ninguna caja abierta
            MessageBox.Show("No existen Cajas Abiertas para Realizar Pagos", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            CAJABindingSource.Filter = cajasabiertas
        End If

        tbxMonto.Text = "" : lblMontoSelecionado.Text = 0 : lblMontoTotalVencido.Text = "" : lblCuotas.Text = "" : lblNroFacturas.Text = "" : lblMontoSelecionado.Text = ""
        HabilitarControles()

        If Config2 = "Manual por Usuario" Or Config2 = "Manual sin Importar usuario" Then
            Dim CodPagoMax As Integer
            Dim MaxNroRecibo As Integer = 0

            cmbGenerarRecibo.Text = "Manual"

            Try
                If Config2 = "Manual por Usuario" Then
                    CodPagoMax = f.FuncionConsultaString("MAX(CODPAGO)", "COMPRASFORMAPAGO", "NRORECIBO IS NOT NULL AND AUTORIZADO", UsuCodigo)
                ElseIf Config2 = "Manual sin Importar usuario" Then
                    CodPagoMax = f.MaximoIsNotNull("CODPAGO", "COMPRASFORMAPAGO", "NRORECIBO")
                End If

                If Config7 = "Si" Then
                    'Obtiene el ultimo nro cargado
                    MaxNroRecibo = f.FuncionConsultaString("NRORECIBO", "COMPRASFORMAPAGO", "CODPAGO", CodPagoMax)
                    MaxNroRecibo = MaxNroRecibo + 1

                    NroReciboTextBox.Text = MaxNroRecibo
                End If
            Catch ex As Exception
                NroReciboTextBox.Text = ""
            End Try
        Else
            cmbGenerarRecibo.Text = "Automático"
            cmbGenerarRecibo_TextChanged(Nothing, Nothing)
        End If

        lblProximoNro.Text = "Nro. Recibo: " + NroReciboTextBox.Text

        If Config6 = "Seleccionada segun DashBoard" Then
            Try
                cbxCuenta.SelectedValue = Dashboard.CmbCaja.SelectedValue
            Catch ex As Exception
            End Try
        End If

        pnlBlanco.BringToFront()
        pnlBlanco.Visible = True : pnlBancario.Visible = False : tbxConcepto.Visible = False : lblConcepto.Visible = False : lblConceptoAyuda.Visible = False
        dgvPagos.Enabled = False : BtnFiltro.Enabled = False : BuscarTextBox.Enabled = False : FiltroPagosActivo.Enabled = False : TipoCobroPictureBox.Enabled = False : PendientesPago.Enabled = False

        btnDetalles_Click(Nothing, Nothing)

        lblPagado.Text = "0" : lblSaldoFavor.Text = "0" : tbxRucProveedor.Text = "" : CmbProveedor.SelectedIndex = -1 : umeTotalRec.Text = "0"
        IsRetencion = 0 : IsRetencionRenta = 0


        If Config8 = "RUC" Then
            tbxRucProveedor.BringToFront()
            tbxRucProveedor.Focus()
        Else
            tbxNroProv.BringToFront()
            tbxNroProv.Focus()
        End If
    End Sub

    Public Sub NuevoPago()
        Try
            Permiso = PermisoAplicado(UsuCodigo, 12)
            If Permiso = 0 Then
                MessageBox.Show("Usted no tiene Permisos para cargar un PAGO", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            bt_nuevo = 1 : VarGlobDeudaCobar = 0 : Saldo = 0 : lblPagado.Text = "0" : BanExiste = 0 : ErrorGuardar = 0

            HabilitarControles()
            LimpiaFormulario()

            NuevoPictureBox.Image = My.Resources.NewActive
            ConfirmarPictureBox.Visible = True
            CancelarPictureBox.BringToFront()
            dtpFechaPago.Text = Today

            cmbGenerarRecibo.SelectedIndex = 0
            cbxPagador.SelectedValue = UsuCodigo
            cbxMoneda.SelectedIndex = 0

            If cbxMoneda.SelectedValue <> Nothing Then
                tbxCotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(cbxMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
                Dim SimboloEfectivo As String = f.FuncionConsultaString("SIMBOLO", "MONEDA", "CODMONEDA", cbxMoneda.SelectedValue)

                Me.COTIZACIONTableAdapter.Fill(DsPagosFacutas.COTIZACION, cbxMoneda.SelectedValue)

                If SimboloEfectivo = "0" Then
                    lblSimbolo.Text = "Gs"
                Else
                    lblSimbolo.Text = SimboloEfectivo
                End If
            End If

            FACTURAPAGARTableAdapter.Fill(DsPagosFacutas.FACTURAPAGAR, 0)
            FACTURASVENCIDASTableAdapter.Fill(DsPagosFacutas.FACTURASVENCIDAS, Today, 0)
            Me.RETENCIONCOMPRATableAdapter.Fill(Me.DsPagosFacutas.RETENCIONCOMPRA, 0)

            'Fecha del nuevo Cobro segun configuración
            If Config1 = "Mostrar Fecha Actual" Then
                dtpFechaPagoDet.Text = Today.ToShortDateString
                dtpFechaPago.Text = Today.ToShortDateString

            ElseIf Config1 = "Mostrar Fecha Atrazada 1 Día" Then
                Dim day As Integer = DateTime.Now.AddDays(-1).Day
                Dim mes As Integer = Today.Month
                Dim anho As Integer = Today.Year

                Dim Fecha As String = day.ToString & "/" & mes.ToString + "/" & anho.ToString
                dtpFechaPagoDet.Text = Fecha
                dtpFechaPago.Text = Fecha

            ElseIf Config1 = "Mostrar Fecha Adelantada 1 Día" Then
                Dim day As Integer = DateTime.Now.AddDays(+1).Day
                Dim mes As Integer = Today.Month
                Dim anho As Integer = Today.Year

                Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                dtpFechaPagoDet.Text = Fecha
                dtpFechaPago.Text = Fecha

            ElseIf Config1 = "Mostrar Fecha de Ultima Seleccion por Usuario" Then
                Try
                    Dim MaxCobro As Integer = f.FuncionConsulta("MAX(CODPAGO)", "COMPRASFORMAPAGO", "FECHAREGISTROPAG IS NOT NULL AND AUTORIZADO", UsuCodigo)
                    dtpFechaPago.Text = f.FuncionConsultaString("FECHAREGISTROPAG", "COMPRASFORMAPAGO", "CODPAGO", MaxCobro)
                    dtpFechaPagoDet.Text = dtpFechaPago.Text
                Catch ex As Exception
                    dtpFechaPagoDet.Text = Today.ToShortDateString
                    dtpFechaPago.Text = Today.ToShortDateString
                End Try

            ElseIf Config1 = "Mostrar Fecha de Ultima Seleccion" Then
                Try
                    Dim MaxCobro As Integer = f.MaximoIsNotNull("CODPAGO", "COMPRASFORMAPAGO", "FECHAREGISTROPAG")
                    dtpFechaPago.Text = f.FuncionConsultaString("FECHAREGISTROPAG", "COMPRASFORMAPAGO", "CODPAGO", MaxCobro)
                    dtpFechaPagoDet.Text = dtpFechaPago.Text
                Catch ex As Exception
                    dtpFechaPagoDet.Text = Today.ToShortDateString
                    dtpFechaPago.Text = Today.ToShortDateString
                End Try
            End If

            CalcularSaldo()
            ObtenerSaldoVencido()
            LimpiarDetalle()

            CobroFormaPagoDataGridView.Enabled = True
            pnlDetallePago.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub RecorreDetalleCobro(ByVal monto As Decimal, ByVal sumaresta As Boolean)
        If sumaresta = True Then
            lblMontoSelecionado.Text = FormatNumber(CDec(lblMontoSelecionado.Text) + monto, 2) + " Gs"
        Else
            lblMontoSelecionado.Text = FormatNumber(CDec(lblMontoSelecionado.Text) - monto, 2) + " Gs"
        End If
    End Sub

    Private Sub RecorreFacturasACobrar()
        Dim c As System.Int32
        Dim acumulador, totalmarcado As Decimal
        c = dgvFacturasaPagar.RowCount
        TotalACobrar = 0
        acumulador = 0
        totalmarcado = 0

        CalcularSaldo()
        TotalDebe = Me.lblMontoSelecionado.Text
        For i = 1 To c
            If dgvFacturasaPagar.Rows(i - 1).Cells("PagarGrilla").Value = True Then
                totalmarcado = totalmarcado + 1

                TotalACobrar = CDec(dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTADataGridViewText").Value)
                acumulador = acumulador + TotalACobrar
                lblMontoSelecionado.Text = FormatNumber(acumulador, 2).ToString + " Gs"
                'FaltaLabel.Text = FormatNumber(acumulador, 2).ToString + " Gs"
            End If
        Next
    End Sub

    Private Sub Fecha1Filtro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fecha1Filtro.LostFocus
        If Fecha1Filtro.Text = "" Then
            Fecha1Filtro.Text = "  /  /    "
        End If
    End Sub

    Private Sub Fecha2Filtro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fecha2Filtro.GotFocus
        If Fecha2Filtro.Text = "  /  /    " Then
            Fecha2Filtro.Text = ""
        End If
    End Sub

    Private Sub Fecha2Filtro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fecha2Filtro.LostFocus
        If Fecha2Filtro.Text = "" Then
            Fecha2Filtro.Text = "  /  /    "
        End If
    End Sub

    Private Sub btnLimpiarCtaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarCtaCte.Click
        Fecha1Filtro.Text = "  /  /    " : Fecha2Filtro.Text = "  /  /    " : chbxEsconderSaldoCero.Checked = True
        Me.FiltroPagoSaldoTableAdapter.Fill(DsPagosFacutas.FiltroPagoSaldo, GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value)
    End Sub

    Private Sub ConfirmarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfirmarPictureBox.Click
        If Trim(lblPagado.Text) <> "" Then
            If CDec(lblPagado.Text) = 0 Then
                MessageBox.Show("No hay nada para Pagar! Ingrese algun tipo de Pago", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblPagosEstado.Text = "Ingrese un Pago"
                Exit Sub
            End If
        End If

        If CobroFormaPagoDataGridView.Rows.Count = 0 Then
            MessageBox.Show("No se pagó nada aún!", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblPagosEstado.Text = "Ingrese un Pago"
            Exit Sub
        End If

        If Trim(NroReciboTextBox.Text) = "" Then
            MessageBox.Show("Especifique un Nro. Recibo", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NroReciboTextBox.Focus()
            Exit Sub
        End If

        If dtpFechaPago.Text = "" Or dtpFechaPago.Text = "  /  /    " Then
            MessageBox.Show("Inserte la Fecha del Pago", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblPagosEstado.Text = "Ingrese una Fecha"
            dtpFechaPago.Focus()
            dtpFechaPago.BackColor = Color.Pink
            Exit Sub
        End If

        'si es retencion de IVA debemos quemar el ultimo nro
        If IsRetencion = 1 Or IsRetencionRenta = 1 Then
            If IsRetencion = 1 Then
                Me.RETENCIONCOMPRATableAdapter.Fill(Me.DsPagosFacutas.RETENCIONCOMPRA, 0)
                lblPorcRetencion.Text = PorcRetencion.ToString + " %"
                lblMontoRentencion.Text = "0"
            ElseIf IsRetencionRenta = 1 Then
                Me.RETENCIONRENTATableAdapter.Fill(Me.DsPagosFacutas.RETENCIONRENTA, 0)
                lblPorcRetRenta.Text = PorcRetencionRenta.ToString + " %"
                lblMontoRetRenta.Text = "0"
            End If

            'quemamos el ultimo nro
            If btnuevo = 1 Then
                '---------------------------- QUEMAMOS ----------------------------
                Dim consulta As System.String
                Dim conexion As System.Data.SqlClient.SqlConnection
                Dim myTrans As System.Data.SqlClient.SqlTransaction

                conexion = ser.Abrir()
                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                Try
                    consulta = "UPDATE DETPC SET ULTIMO = " & NroRetencion & " where RANDOID=" & RangoIDRetencion & ""

                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()
                Catch ex As Exception
                    MessageBox.Show("Error al General el Nro. de Retencion", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End If


        'verifica si ya existe el nro de recibo
        Dim Existe As String
        Dim reciboConSerie As String = ""

        Try
verificarnrorecibo:
            If NroReciboTextBox.Text <> "" Then
                reciboConSerie = Trim(NroReciboTextBox.Text) + " " + Trim(tbxNroSerie.Text)
                Existe = f.FuncionConsultaString("CABPAGO", "COMPRASFORMAPAGO", "COMPRASFORMAPAGO.NRORECIBO + ' ' + ISNULL(COMPRASFORMAPAGO.RECIBONROSERIE, '')", reciboConSerie)
                If Not Existe Is Nothing Then
                    If btmodificar = 1 Then
                        If Existe <> dgvPagos.CurrentRow.Cells("CABPAGO").Value Then
                            If MessageBox.Show("El Nro de Recibo ya Existe, ¿Desea Duplicarlo?", "POS EXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = MsgBoxResult.No Then
                                Dim nvonumero As String
                                If Trim(tbxNroSerie.Text) = "" Then
                                    nvonumero = InputBox("Ingrese el nuevo Nro. de Recibo: (Si desea agregar Nro. de Serie, ingrese un Guión '-' seguido de la Serie)", " Modificar Nro. Recibo", Trim(NroReciboTextBox.Text))
                                Else
                                    nvonumero = InputBox("Ingrese el nuevo Nro. de Recibo: (Especifique el Nro. de Serie despues del guión)", " Modificar Nro. Recibo", Trim(NroReciboTextBox.Text) + "-" + Trim(tbxNroSerie.Text))
                                    If nvonumero = "" Then ' Dio click en Cancelar
                                        Exit Sub
                                    End If
                                End If

                                Dim TestPos As Integer
                                TestPos = InStr(1, nvonumero, "-", CompareMethod.Text)
                                If TestPos = 0 Then 'El texto no tiene guion
                                    NroReciboTextBox.Text = nvonumero
                                    GoTo verificarnrorecibo
                                Else
                                    Dim recibo As String = Trim(Mid(nvonumero, 1, TestPos - 1))
                                    Dim serie As String = Trim(Mid(nvonumero, TestPos + 1, nvonumero.Length))
                                    NroReciboTextBox.Text = recibo
                                    tbxNroSerie.Text = serie
                                    GoTo verificarnrorecibo
                                End If
                            End If
                        End If
                    Else
                        If MessageBox.Show("El Nro de Recibo ya Existe, ¿Desea Duplicarlo?", "POS EXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                            Dim nvoNumero As String = InputBox("Ingrese el nuevo Nro. de Recibo: (Especifique el Nro. de Serie despues del guión)", " Modificar Nro. Recibo", Trim(NroReciboTextBox.Text) + "-" + Trim(tbxNroSerie.Text))
                            Dim TestPos As Integer
                            TestPos = InStr(1, nvoNumero, "-", CompareMethod.Text)
                            If TestPos = 0 Then 'El texto no tiene guion
                                NroReciboTextBox.Text = nvoNumero
                                GoTo verificarnrorecibo
                            Else
                                Dim recibo As String = Trim(Mid(nvoNumero, 1, TestPos - 1))
                                Dim serie As String = Trim(Mid(nvoNumero, TestPos + 1, nvoNumero.Length))
                                NroReciboTextBox.Text = recibo
                                tbxNroSerie.Text = serie
                                GoTo verificarnrorecibo
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

        If btnuevo = 1 Then '
            Grabar()
        ElseIf btmodificar = 1 Then
            Modificar()
        End If

        If ErrorGuardar = 0 Then
            If IsRetencion = 1 Or IsRetencionRenta = 1 Then 'Si es una retencion debemos insertar en la Tabla Retenciones
                If btnuevo = 1 Then
                    InsertarRetencion()
                ElseIf btmodificar = 1 Then
                    ModificaRetencion()
                End If
            End If

            'Si hubo un error al momento de guardar no debe continuar haciendo Contabilidad
            '------------------------------------------------------------------- CONTABILIDAD --------------------------------------------------------
            'Obtenemos los valores que se utilizaron el modulo de contabilidad - by Yolanda Zelaya 
            PagosContabilidad(CabPagoMax, CmbProveedor.SelectedValue, SucCodigo)
            '-------------------------------------------------------------------------------------------------------------------------------------------
        End If

        FechaFiltro()
        Me.PROVEEDORFILLPAGOTableAdapter.Fill(Me.DsPagosFacutas.PROVEEDORFILLPAGO)
        Me.CABECERAPAGOSTableAdapter.Fill(Me.DsPagosFacutas.CABECERAPAGOS, FechaFiltroDesde, FechaFiltroHasta)

        If dgvPagos.RowCount > 0 Then
            FACTURAPAGARTableAdapter.Fill(DsPagosFacutas.FACTURAPAGAR, dgvPagos.CurrentRow.Cells("CODPROVEEDORCAB").Value)
            FACTURASVENCIDASTableAdapter.Fill(DsPagosFacutas.FACTURASVENCIDAS, Today, dgvPagos.CurrentRow.Cells("CODPROVEEDORCAB").Value)
        End If

        LimpiaFormulario()
        lblMontoSelecionado.Text = "0 Gs"
        DeshabilitarControles()

        pnlFacturasaPagar.Visible = False
        lblDetalles.Text = "Ver Detalles"
        btnDetalles.Image = My.Resources.Display
        ModificarDetPictureBox.Image = My.Resources.Edit
        ModificarDetPictureBox.Enabled = True
        tsEditar.Enabled = True

        btnAgregarPagos.BringToFront()
        btnEliminarPagos.BringToFront()

        dgvPagos.Enabled = True : BtnFiltro.Enabled = True : BuscarTextBox.Enabled = True : FiltroPagosActivo.Enabled = True : TipoCobroPictureBox.Enabled = True : cmbGenerarRecibo.Text = ""
        lblCuotas.Text = "" : lblNroFacturas.Text = "" : lblPagado.Text = "" : lblSaldoFavor.Text = "" : btnuevo = 0 : btmodificar = 0 : ModifNC = 0

        BtnFiltro_Click(Nothing, Nothing)

        PendientesPago.Enabled = True
        lbxTipoPago.SelectedValue = 1
    End Sub

    Private Sub Modificar()
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        CabPagoMax = 0
        Try
            ModificarComprasFormaPago()

            If cmbGenerarRecibo.Text = "Automático" Then
                ActualizaRango()
            End If

            Try
                'AUDITORIAMODIFICAPAGO()
            Catch ex As Exception
            End Try

            myTrans.Commit()
            LimpiaFormulario()
            'MessageBox.Show("Cobro actualizado correctamente! ", "POSEXPRESS")
            ErrorGuardar = 0
        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            End Try
            MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS")
            ErrorGuardar = 1

        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub ModificarComprasFormaPago()
        Dim CodPago, CodCompra, CodTipoPago, CodMoneda, Cotizacion1, Importe, DesTipoPago, NroCuota, NroRecibo, NroRef, NroNotaCredito, NroRetencion, FechaPago, FechaRegCobro As String
        Dim MaxIdApertura, CabPago, CodTipoFormaPago, CodAutorizado As Integer
        NroRecibo = NroReciboTextBox.Text
        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

        Dim conctHora As String = Now.ToString("HH:mm:ss")
        Dim conctFecha As String = dtpFechaPago.Text
        Dim conctFechaHora As String = conctFecha & " " + conctHora
        FechaRegCobro = conctFechaHora

        For i = 1 To c ' Siempre habrá igual o mayor cant. de las originales porque no se eliminan las filas 
            CodPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODPAGO").Value
            CodTipoPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODTIPOPAGO").Value

            If CodTipoPago = 6 Then
                IsRetencion = 1
            ElseIf CodTipoPago = 10 Then
                IsRetencionRenta = 1
            End If

            CodCompra = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODCOMPRA").Value
            DesTipoPago = CobroFormaPagoDataGridView.Rows(i - 1).Cells("DESTIPOPAGO").Value
            NroCuota = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NROCUOTA").Value
            NroNotaCredito = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMDEVOLUCION").Value.ToString
            NroRetencion = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NUMRETENCION").Value.ToString
            NroRef = CobroFormaPagoDataGridView.Rows(i - 1).Cells("NROREF").Value.ToString
            CodTipoFormaPago = CobroFormaPagoDataGridView.Rows(c - 1).Cells("FORMAPAGO").Value
            CodAutorizado = cbxPagador.SelectedValue
            CodMoneda = cbxMoneda.SelectedValue

            Dim fechapago2 As Date = CobroFormaPagoDataGridView.Rows(i - 1).Cells("FECHAPAGO").Value
            FechaPago = fechapago2.ToString("dd/MM/yyy")
            FechaPago = FechaPago & " " & Now.ToString("HH:mm:ss")

            Cotizacion1 = tbxCotizacion.Text
            Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
            Cotizacion1 = Replace(Cotizacion1, ",", ".")

            Importe = System.Math.Abs(CobroFormaPagoDataGridView.Rows(i - 1).Cells("IMPORTE").Value)
            Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
            Importe = Replace(Importe, ",", ".")

            MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", cbxCuenta.SelectedValue)

            sql = ""
            If CobroFormaPagoDataGridView.Rows(i - 1).Cells("EstadoGrilla").Value = "" Then
                Dim fechastr As String = FormatDateTime(dgvPagos.CurrentRow.Cells("FECHAREGISTROPAGDataGridViewTextBoxColumn").Value, DateFormat.ShortDate)
                If fechastr <> dtpFechaPago.Text Then
                    sql = "UPDATE movimientos SET fecha_mto= CONVERT (DATETIME,'" & FechaRegCobro & "',103) WHERE id_pago = " & CodPago & ""
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    sql = ""
                End If

                sql = "UPDATE COMPRASFORMAPAGO SET CODTIPOPAGO = " & CodTipoPago & ", CODMONEDA= " & CodMoneda & ", COTIZACION1= " & Cotizacion1 & ", IMPORTE = " & Importe & ",  DESTIPOPAGO = '" & DesTipoPago & "', FECHAPAGO = CONVERT(DATETIME,'" & FechaPago & "',103), CH_NROCHEQUE = '" & NroRef & "' " & _
                      ", CODUSUARIO= " & UsuCodigo & ", NRORECIBO= '" & NroRecibo & "', NROCUOTA= " & NroCuota & ", NUMDEVOLUCION = '" & NroNotaCredito & "', NUMRETENCION ='" & NroRetencion & "', id_apertura = " & MaxIdApertura & ", TIPOPAGO = " & CodTipoFormaPago & ", AUTORIZADO = " & CodAutorizado & ", OBSERVACIONES = '" & tbxObservaciones.Text & "' , " & _
                      " FECHAREGISTROPAG= CONVERT(DATETIME,'" & FechaRegCobro & "',103),RECIBONROSERIE = '" & tbxNroSerie.Text & "' WHERE CODPAGO=" & CodPago & " "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

            ElseIf CobroFormaPagoDataGridView.Rows(i - 1).Cells("EstadoGrilla").Value = "I" Then
                CabPago = dgvPagos.CurrentRow.Cells("CABPAGO").Value
                sql = "INSERT INTO COMPRASFORMAPAGO (CODPAGO, CODCOMPRA, CODTIPOPAGO, CODMONEDA, COTIZACION1,OBSERVACIONES, IMPORTE, DESTIPOPAGO, FECHAPAGO, FECHAREGISTROPAG," & _
                      "CH_NROCHEQUE,  CODUSUARIO, CODEMPRESA,NROCUOTA, NRORECIBO,  NUMDEVOLUCION, NUMRETENCION,id_apertura,CABPAGO,TIPOPAGO,AUTORIZADO,RECIBONROSERIE) " & _
                      "VALUES (" & CodPago & ", " & CodCompra & ", " & CodTipoPago & ", " & CodMoneda & ", " & Cotizacion1 & ", '" & tbxObservaciones.Text & "'," & _
                      Importe & ", '" & DesTipoPago & "', CONVERT (DATETIME,'" & FechaPago & "',103), CONVERT (DATETIME,'" & FechaRegCobro & "',103), '" & NroRef & "', " & UsuCodigo & ", " & EmpCodigo & _
                      ", " & NroCuota & ",'" & NroRecibo & "', '" & NroNotaCredito & "', '" & NroRetencion & "'," & MaxIdApertura & ", " & CabPago & ", " & CodTipoFormaPago & "," & CodAutorizado & ",'" & tbxNroSerie.Text & "')"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                'descontar del Saldo FacturaPagar
                sql = ""
                sql = " DECLARE @PAGADO INT,@CODIGO NUMERIC(18,0), @SALDO AS NUMERIC(18,5) " & _
                      "SELECT @SALDO=SALDOCUOTA FROM FACTURAPAGAR " & _
                      "WHERE CODCOMPRA = " & CodCompra & " AND NUMEROCUOTA =  " & NroCuota & " " & vbCrLf & _
                      "IF @SALDO<=" & Importe & " " & _
                      "begin " & _
                      "SET @PAGADO =1 " & _
                      "End " & _
                      "else " & _
                      "begin " & _
                      "SET @PAGADO =0 " & _
                      "End " & _
                      "UPDATE FACTURAPAGAR SET SALDOCUOTA = SALDOCUOTA- " & Importe & ",PAGADO=@PAGADO " & _
                      "WHERE CODCOMPRA = " & CodCompra & " AND NUMEROCUOTA = " & NroCuota & " "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                ''descontar saldo de Nota de Credito
                If NroNotaCredito <> "" Or NroNotaCredito <> Nothing Then
                    Dim CodNotaCredito As String = ""
                    Dim objCommand As New SqlCommand
                    Try
                        objCommand.CommandText = "SELECT CODDEVOLUCION FROM DEVOLUCIONCOMPRA WHERE NUMDEVOLUCION = '" & NroNotaCredito & "'"
                        objCommand.Connection = sqlc
                        objCommand.Transaction = myTrans
                        Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                        If odrConfig.HasRows Then
                            Do While odrConfig.Read()
                                CodNotaCredito = odrConfig("CODDEVOLUCION")
                            Loop
                        End If

                        odrConfig.Close()
                        objCommand.Dispose()
                    Catch ex As Exception
                    End Try

                    sql = ""
                    sql = " DECLARE @PAGADO INT,@CODIGO NUMERIC(18,0), @SALDO AS NUMERIC(18,5) " & _
                        "SELECT @SALDO=SALDO FROM DEVOLUCIONCOMPRA " & _
                        "WHERE CODDEVOLUCION = " & CodNotaCredito & " " & vbCrLf & _
                        "IF @SALDO<=" & Importe & " " & _
                        "begin " & _
                        "SET @PAGADO =1 " & _
                        "End " & _
                        "else " & _
                        "begin " & _
                        "SET @PAGADO =0 " & _
                        "End " & _
                        "UPDATE DEVOLUCIONCOMPRA SET SALDO = (SALDO - " & Importe & "),COBRADO=@PAGADO " & _
                        "WHERE CODDEVOLUCION = " & CodNotaCredito & " "
                    ''sql = "UPDATE NCREDITO SET SALDO = (SALDO - " & Importe & ") WHERE CODDEVOLUCION = " & CodNotaCredito & _
                    'sql = " UPDATE DEVOLUCIONCOMPRA SET COBRADO = 1, SALDO = (SALDO - " & Importe & ") WHERE CODDEVOLUCION = " & CodNotaCredito

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If

            ElseIf CobroFormaPagoDataGridView.Rows(i - 1).Cells("EstadoGrilla").Value = "D" Then
                'eliminar el movimiento de Movimientos
                sql = "DELETE movimientos WHERE id_pago = " & CodPago & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                sql = ""
                sql = " DELETE COMPRASFORMAPAGO WHERE CODPAGO= " & CodPago & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                sql = ""

                'incrementar Saldo FacturaCobrar
                sql = "UPDATE FACTURAPAGAR SET PAGADO=0, SALDOCUOTA = SALDOCUOTA + " & Importe & " " & _
                     "WHERE CODCOMPRA = " & CodCompra & " AND NUMEROCUOTA = " & NroCuota & " "
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                sql = ""



                ''incrementar saldo de Nota de Credito
                If NroNotaCredito <> "" Or NroNotaCredito <> Nothing Then
                    Dim CodNotaCredito As String = ""
                    Dim objCommand As New SqlCommand
                    Try
                        objCommand.CommandText = "SELECT CODDEVOLUCION FROM DEVOLUCIONCOMPRA WHERE NUMDEVOLUCION = '" & NroNotaCredito & "'"
                        objCommand.Connection = sqlc
                        objCommand.Transaction = myTrans
                        Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                        If odrConfig.HasRows Then
                            Do While odrConfig.Read()
                                CodNotaCredito = odrConfig("CODDEVOLUCION")
                            Loop
                        End If

                        odrConfig.Close()
                        objCommand.Dispose()
                    Catch ex As Exception
                    End Try

                    sql = ""
                    sql = " UPDATE DEVOLUCIONCOMPRA SET COBRADO = 0, SALDO = (SALDO + " & Importe & ") WHERE CODDEVOLUCION = " & CodNotaCredito

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If

            End If
        Next
    End Sub

    Public Sub btnFiltrarCuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarCuentas.Click
        Dim Par1, Par2 As String
        Dim FechaDesde As String
        Dim FechaHasta As String

        If (cbxTipoCobro.Text <> "") Then
            Par1 = cbxTipoCobro.Text
        Else
            Par1 = "%"
        End If

        If IsDBNull(GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value) Then
            Par2 = 0
        Else
            Par2 = GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value
        End If

        Try
            Dim desde As String = FechaDesde3.Text
            Dim hasta As String = FechaHasta3.Text
            FechaDesde = desde & " 00:00:00"
            FechaHasta = hasta & " 23:59:00"

            If (FechaDesde = "  /  /    ") And (FechaHasta = "  /  /    ") Then
                Me.HISTORIALCAJATableAdapter.Fill(DsPagosFacutas.HISTORIALCAJA, Par1, Par2)

            Else

                If (FechaDesde <> "  /  /    ") And (FechaHasta <> "  /  /    ") Then
                    Me.HISTORIALCAJATableAdapter.FillByFecha(DsPagosFacutas.HISTORIALCAJA, Par1, FechaDesde, FechaHasta, Par2)

                End If

                If (FechaDesde <> "  /  /    ") And (FechaHasta = "  /  /    ") Then
                    Dim dtFecha As DateTime = DateTime.Now
                    Dim Fecha

                    Fecha = dtFecha.ToString("dd/MM/yyyy")
                    FechaHasta = Fecha & " 23:59:00"
                    FechaHasta3.Text = Fecha

                    Me.HISTORIALCAJATableAdapter.FillByFecha(DsPagosFacutas.HISTORIALCAJA, Par1, FechaDesde, FechaHasta, Par2)
                End If

                If (FechaDesde = "  /  /    ") And (FechaHasta <> "  /  /    ") Then
                    Me.HISTORIALCAJATableAdapter.FillByFecha2(DsPagosFacutas.HISTORIALCAJA, Par1, Par2, FechaHasta)

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try



    End Sub

    Private Sub FechaDesde3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FechaDesde3.GotFocus
        If FechaDesde3.Text = "  /  /    " Then
            FechaDesde3.Text = ""
        End If
    End Sub

    Private Sub FechaDesde3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FechaDesde3.LostFocus
        If FechaDesde3.Text = "" Then
            FechaDesde3.Text = "  /  /    "
        End If
    End Sub

    Private Sub FechaHasta3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FechaHasta3.GotFocus
        If FechaHasta3.Text = "  /  /    " Then
            FechaHasta3.Text = ""
        End If
    End Sub

    Private Sub FechaHasta3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FechaHasta3.LostFocus
        If FechaHasta3.Text = "" Then
            FechaHasta3.Text = "  /  /    "
        End If
    End Sub

    Private Sub btnLimpiarCuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarCuentas.Click
        FechaHasta3.Text = "  /  /    " : FechaDesde3.Text = "  /  /    " : cbxTipoCobro.Text = ""
        Me.HISTORIALCAJATableAdapter.Fill(DsPagosFacutas.HISTORIALCAJA, "%", GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value)
    End Sub

    'By Yolanda Zelaya
    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        Dim ImporteEliminado As Double

        'Antes de eliminar debemos verificar que dicho registro no sea un saldo a favor
        If IsDBNull(DataGridView3.CurrentRow.Cells("VueltoDataGridHC").Value) Then
            If MessageBox.Show("¿Esta seguro que quiere eliminar el Registro?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If

            ImporteEliminado = DataGridView3.CurrentRow.Cells("IMPORTEDataGridHC").Value

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualiza")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                'Actualizamos en la Tabla FacturaCobrar :)
                ActualizaCobroEliminado(ImporteEliminado, DataGridView3.CurrentRow.Cells("CODVENTADataGridHC").Value, DataGridView3.CurrentRow.Cells("NROCUOTADataGridHC").Value, "0")

                'Eliminamos el detalle de pago de la Tabla COMPRASFORMAPAGO y MOVIMIENTOS :(
                EliminarCobroMovimiento(DataGridView3.CurrentRow.Cells("CODCOBRODataGridHC").Value)
                EliminarCobroEliminado(DataGridView3.CurrentRow.Cells("CODCOBRODataGridHC").Value)

                myTrans.Commit()

            Catch ex As Exception

            End Try

        Else
            If MessageBox.Show("El registro a eliminar es un SALDO A FAVOR ¿Esta seguro que quiere eliminar el Registro?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualiza")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                'Me.ELIMINARCOBROTableAdapter1.FillByNegativo(Me.DsPagosFacutas.ELIMINARCOBRO, DataGridView3.CurrentRow.Cells("CLIENTEDataGridHC").Value)

                'Actualizamos en la Tabla FacturaCobrar :)
                ActualizaCobroEliminado("0.000", ELIMINARCOBRODataGridView.Rows(0).Cells("CODVENTADataEliminar").Value, ELIMINARCOBRODataGridView.Rows(0).Cells("CODNUMEROCUOTADataEliminar").Value, "1")

                'Eliminamos el detalle de pago de la Tabla COMPRASFORMAPAGO y MOVIMIENTOS :(
                EliminarCobroMovimiento(DataGridView3.CurrentRow.Cells("CODCOBRODataGridHC").Value)
                EliminarCobroEliminado(DataGridView3.CurrentRow.Cells("CODCOBRODataGridHC").Value)

                myTrans.Commit()

            Catch ex As Exception

            End Try
        End If

        'Me.HISTORIALPAGOSTableAdapter1.Fill(DsPagosFacutas.HISTORIALPAGOS, "%", "%")
        lblPagosEstado.Text = "Pago Eliminado"
        lblDGVCant.Text = "Cant. de Items:" & dgvPagos.RowCount
    End Sub

    Private Sub EliminarCobroMovimiento(ByRef CodCobroEL As Integer)
        sql = ""
        sql = "DELETE movimientos WHERE id_cobro = " & CodCobroEL

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarCobroEliminado(ByRef CodCobroEL As Integer)
        sql = ""
        sql = "DELETE COMPRASFORMAPAGO WHERE CODCOBRO = " & CodCobroEL

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizaCobroEliminado(ByRef ImporteActualizar As Double, ByRef CodVenta As Integer, ByRef NroCuota As Integer, ByRef ParPagado As Integer)
        sql = ""
        sql = "UPDATE FACTURACOBRAR SET SALDOCUOTA = SALDOCUOTA + " & CDec(ImporteActualizar) & ", PAGADO = " & ParPagado & "  " & _
              "WHERE CODVENTA = " & CodVenta & " AND CODNUMEROCUOTA = " & NroCuota

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub NroReciboTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles NroReciboTextBox.GotFocus
        NroReciboTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub TipoCobroPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoCobroPictureBox.Click
        Permiso = PermisoAplicado(UsuCodigo, 15)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permisos para Visualizar los Datos en Ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        MenuCobros.Enabled = False
        If panelactivo = "SplitPagos" Then
            Try
                If dgvPagos.RowCount <> 0 Then
                    indexPago = dgvPagos.CurrentRow.Index
                End If
            Catch ex As Exception
            End Try

            NuevoPictureBox.Visible = False
            EliminarPictureBox.Visible = False
            ModificarDetPictureBox.Visible = False
            CancelarPictureBox.Visible = False
            ConfirmarPictureBox.Visible = False

        ElseIf panelactivo = "Pendientes" Then
            PictureBox2.Visible = True
            BuscarTextBox.Visible = True
        End If

        panelactivo = "Historial"
        ControlFiltro1 = 0 : ControlFiltro2 = 0 : ControlFiltro3 = 1

        LimpiaFormulario()
        TipoCobros()

        PagosActivo.Image = My.Resources.Payment
        FiltroPagosActivo.Image = My.Resources.User
        TipoCobroPictureBox.Image = My.Resources.CuentaActive
        PendientesPago.Image = My.Resources.Create
        PendientesPago.Cursor = Cursors.Hand

        SplitNavegarProveedor.BringToFront()

        Dim par1 As String

        If IsDBNull(GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value) Then
            par1 = 0
        Else
            par1 = GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value
        End If

        Me.HISTORIALCAJATableAdapter.Fill(DsPagosFacutas.HISTORIALCAJA, "%", par1)

        cbxTipoCobro.Text = ""
        BuscarTextBox.Focus()
    End Sub

    Private Sub FiltroPagosActivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltroPagosActivo.Click
        Permiso = PermisoAplicado(UsuCodigo, 14)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permisos para Visualizar los Datos esta Ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        MenuCobros.Enabled = False
        If panelactivo = "SplitPagos" Then
            Try
                If dgvPagos.RowCount <> 0 Then
                    indexPago = dgvPagos.CurrentRow.Index
                End If
            Catch ex As Exception
            End Try

            NuevoPictureBox.Visible = False
            EliminarPictureBox.Visible = False
            ModificarDetPictureBox.Visible = False
            CancelarPictureBox.Visible = False
            ConfirmarPictureBox.Visible = False

        ElseIf panelactivo = "Pendientes" Then
            PictureBox2.Visible = True
            BuscarTextBox.Visible = True
        End If
        panelactivo = "Pagos"
        ControlFiltro1 = 0 : ControlFiltro2 = 1 : ControlFiltro3 = 0

        FiltroPagos()
        LimpiaFormulario()
        PanelCobroSaldo.BringToFront()
        chbxEsconderSaldoCero.Checked = True

        PagosActivo.Image = My.Resources.Payment
        FiltroPagosActivo.Image = My.Resources.UserActive
        TipoCobroPictureBox.Image = My.Resources.Cuenta

        PagosActivo.Image = My.Resources.Payment
        PagosActivo.Cursor = Cursors.Hand
        FiltroPagosActivo.Image = My.Resources.UserActive
        FiltroPagosActivo.Cursor = Cursors.Arrow
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        TipoCobroPictureBox.Cursor = Cursors.Hand
        PendientesPago.Image = My.Resources.Create
        PendientesPago.Cursor = Cursors.Hand

        SplitNavegarProveedor.BringToFront()

        Dim par1 As String

        If IsDBNull(GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value) Then
            par1 = 0
        Else
            par1 = GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value
        End If

        Me.FiltroPagoSaldoTableAdapter.Fill(DsPagosFacutas.FiltroPagoSaldo, par1)
        BuscarTextBox.Focus()
    End Sub

    Public Sub PagosActivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosActivo.Click
        panelactivo = "SplitPagos"
        ControlFiltro1 = 1 : ControlFiltro2 = 0 : ControlFiltro3 = 0
        MenuCobros.Enabled = True
        FechaFiltro()
        Me.CABECERAPAGOSTableAdapter.Fill(Me.DsPagosFacutas.CABECERAPAGOS, FechaFiltroDesde, FechaFiltroHasta)

        Try
            If dgvPagos.RowCount <> 0 Then
                CABECERAPAGOSBindingSource.Position = indexPago
            End If
        Catch ex As Exception
        End Try

        'Al Llamar Funcion de Pagos, el sistema tambien automaticamente Deshabilita los Botones Principales
        Pagos()

        FACTURAPAGARTableAdapter.Fill(DsPagosFacutas.FACTURAPAGAR, GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value)
        FACTURASVENCIDASTableAdapter.Fill(DsPagosFacutas.FACTURASVENCIDAS, Today, GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value)

        CalcularSaldo()
        ObtenerSaldoVencido()
        PanelCobroCuotas.BringToFront()

        PagosActivo.Image = My.Resources.PaymentActive
        FiltroPagosActivo.Image = My.Resources.User
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        PendientesPago.Image = My.Resources.Create
        PendientesPago.Cursor = Cursors.Hand

        SplitPagos.BringToFront()

        dgvPagos.Enabled = True
        BtnFiltro.Enabled = True
        BuscarTextBox.Enabled = True

        PagosActivo.Image = My.Resources.PaymentActive
        PagosActivo.Cursor = Cursors.Arrow
        FiltroPagosActivo.Image = My.Resources.User
        FiltroPagosActivo.Cursor = Cursors.Hand
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        TipoCobroPictureBox.Cursor = Cursors.Hand

        PictureBox2.Visible = True : BuscarTextBox.Visible = True : NuevoPictureBox.Visible = True : EliminarPictureBox.Visible = True
        ModificarDetPictureBox.Visible = True : CancelarPictureBox.Visible = True : ConfirmarPictureBox.Visible = True
    End Sub


    Private Sub Pagos()
        DeshabilitarControles()

        PagosActivo.Image = My.Resources.Payment
        PagosActivo.Cursor = Cursors.Arrow

        FiltroPagosActivo.Image = My.Resources.CteContacto
        FiltroPagosActivo.Cursor = Cursors.Hand

        TipoCobroPictureBox.Image = My.Resources.Cuenta
        TipoCobroPictureBox.Cursor = Cursors.Hand
    End Sub

    Private Sub FiltroPagos()
        DeshabilitarControles()
        PagosActivo.Image = My.Resources.Payment
        PagosActivo.Cursor = Cursors.Hand

        FiltroPagosActivo.Image = My.Resources.CteContactoOff
        FiltroPagosActivo.Cursor = Cursors.Arrow

        TipoCobroPictureBox.Image = My.Resources.Cuenta
        TipoCobroPictureBox.Cursor = Cursors.Hand
    End Sub

    Private Sub TipoCobros()
        DeshabilitarControles()
        PagosActivo.Image = My.Resources.Payment
        PagosActivo.Cursor = Cursors.Hand

        FiltroPagosActivo.Image = My.Resources.CteContacto
        FiltroPagosActivo.Cursor = Cursors.Hand

        TipoCobroPictureBox.Image = My.Resources.CuentaOff
        TipoCobroPictureBox.Cursor = Cursors.Arrow
        PanelFiltradoTipoCobro.BringToFront()

    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged
        Try
            If panelactivo = "SplitPagos" Then
                Me.CABECERAPAGOSBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR RUC_CIN LIKE '%" & BuscarTextBox.Text & "%' OR RECIBOCONSERIE LIKE '%" & BuscarTextBox.Text & "%'"
            Else
                PROVEEDORBindingSource.Filter = "NOMBRE like '%" & BuscarTextBox.Text & "%' OR RUC_CIN LIKE '%" & BuscarTextBox.Text & "%'"
            End If

        Catch ex As Exception

        End Try
        lblDGVCant.Text = "Cant. de Items:" & dgvPagos.RowCount
    End Sub

    Private Sub BuscarTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.GotFocus
        BuscarTextBox.BackColor = Color.LightSteelBlue
        lblPagosEstado.Text = "Buscar un Proveedor"
    End Sub

    Private Sub BuscarTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.LostFocus
        BuscarTextBox.BackColor = Color.DimGray
        lblPagosEstado.Text = ""
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.NuevoPictureBox, "Nuevo Pago")
    End Sub

    Private Sub ConfirmarPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConfirmarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.ConfirmarPictureBox, "Confirmar Pago")
    End Sub

    Private Sub CancelarPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.CancelarPictureBox, "Cancelar Pago")
    End Sub

    Private Sub PagosActivo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagosActivo.MouseEnter
        Me.ToolTip1.SetToolTip(Me.PagosActivo, "Realizar Pago")
    End Sub

    Private Sub FiltroPagosActivo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroPagosActivo.MouseEnter
        Me.ToolTip1.SetToolTip(Me.PagosActivo, "Cuenta Cliente")
    End Sub

    Private Sub TipoCobroPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TipoCobroPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.TipoCobroPictureBox, "Ingresos Pagos")
    End Sub
    Private Sub TxtBuscaProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscaProveedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgwProveedores.Focus()
        End If
    End Sub
    Private Sub GridViewProveedor_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewProveedor.SelectionChanged
        Try
            Dim par As String
            If panelactivo = "SplitPagos" Then
                FACTURAPAGARTableAdapter.Fill(DsPagosFacutas.FACTURAPAGAR, GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value)
                FACTURASVENCIDASTableAdapter.Fill(DsPagosFacutas.FACTURASVENCIDAS, Today, GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value)

                CalcularSaldo()
                ObtenerSaldoVencido()

            ElseIf panelactivo = "Pagos" Then
                If IsDBNull(GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value) Then
                    par = 0
                Else
                    par = GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value
                End If

                Fecha1Filtro.Text = "  /  /    " : Fecha2Filtro.Text = "  /  /    "

                Me.FiltroPagoSaldoTableAdapter.Fill(DsPagosFacutas.FiltroPagoSaldo, par)

            ElseIf panelactivo = "Historial" Then

                If IsDBNull(GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value) Then
                    par = 0
                Else
                    par = GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value
                End If

                Me.HISTORIALCAJATableAdapter.Fill(DsPagosFacutas.HISTORIALCAJA, "%", par)
                cbxTipoCobro.Text = ""

            End If

            lblCtaCteProveedor.Text = GridViewProveedor.CurrentRow.Cells("PROVEEDORDataGridViewTextBoxColumn").Value
            lblProveedorHistorial.Text = GridViewProveedor.CurrentRow.Cells("PROVEEDORDataGridViewTextBoxColumn").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbxTipoPago_GotFocus(sender As Object, e As System.EventArgs) Handles lbxTipoPago.GotFocus
        lbxTipoPago.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub lbxTipoPago_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lbxTipoPago.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxMonto.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub lbxTipoPago_LostFocus(sender As Object, e As System.EventArgs) Handles lbxTipoPago.LostFocus
        lbxTipoPago.BackColor = Color.White
    End Sub

    Private Sub lbxTipoPago_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbxTipoPago.SelectedIndexChanged
        Dim monto As String = tbxMonto.Text
        LimpiarDetalle()
        tbxMonto.Text = monto
        If lbxTipoPago.Text = "Efectivo" Then
            pnlBlanco.BringToFront()
            tbxConcepto.Visible = False
            lblConcepto.Visible = False
            lblConceptoAyuda.Visible = False
            ImprimirCheque.Visible = False
        ElseIf lbxTipoPago.Text = "Cheque" Then
            pnlBlanco.BringToFront()
            pnlBlanco.Visible = True
            pnlBancario.BringToFront()
            pnlBancario.Visible = True
            ImprimirCheque.Visible = True
        ElseIf lbxTipoPago.Text = "Nota de Credito" Then
            pnlNotaCredito.BringToFront()
            ImprimirCheque.Visible = False
        ElseIf lbxTipoPago.Text = "Tarjeta" Then
            pnlBlanco.BringToFront()
            tbxConcepto.Visible = False
            lblConcepto.Visible = False
            lblConceptoAyuda.Visible = False
            ImprimirCheque.Visible = False
        ElseIf lbxTipoPago.Text = "Transferencia" Then
            pnlBlanco.BringToFront()
            pnlBancario.BringToFront()
            ImprimirCheque.Visible = False
        ElseIf lbxTipoPago.Text = "Retencion" Then
            ImprimirCheque.Visible = False
            If MessageBox.Show("Desea que el sistema genere la retención sobre el " & PorcRetencion.ToString & " % preestablecido? ", "POSSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                RETENCIONCOMPRATableAdapter.Fill(Me.DsPagosFacutas.RETENCIONCOMPRA, CmbProveedor.SelectedValue)
                lblPorcRetencion.Text = PorcRetencion.ToString + " %"
                lblMontoRentencion.Text = "0"
                If btmodificar = 1 Then
                    dgwRetencion.Enabled = False
                    tbxNroRetencion.Text = " "
                    For x = 0 To CobroFormaPagoDataGridView.RowCount - 1
                        If CobroFormaPagoDataGridView.Rows(x).Cells("DESTIPOPAGO").Value = "Retención Iva" Or CobroFormaPagoDataGridView.Rows(x).Cells("DESTIPOPAGO").Value = "Retencion" Then
                            tbxNroRetencion.Text = CobroFormaPagoDataGridView.Rows(x).Cells("NUMRETENCION").Value
                            Exit For
                        End If
                    Next
                Else
                    dgwRetencion.Enabled = True
                    GenerarNroRetencion()
                End If

                pnlRetencion.Visible = True
                pnlRetencion.BringToFront()

                lblSaldoFavor.BringToFront()
                lblPagado.BringToFront()
                Label20.BringToFront()
                Label21.BringToFront()
            Else
                RETENCIONCOMPRATableAdapter.Fill(Me.DsPagosFacutas.RETENCIONCOMPRA, CmbProveedor.SelectedValue)
                GenerarNroRetencion()
                dgwRetencion.Enabled = True

                btnAceptarValorRetencion.BringToFront()
                btnAceptarValorRetencion.Enabled = True
                btnAceptarValorRetencion.Visible = True

                pnlRetencion.Visible = True
                pnlRetencion.BringToFront()

                lblSaldoFavor.BringToFront()
                lblPagado.BringToFront()
                Label20.BringToFront()
                Label21.BringToFront()

                lblMontoRentencion.Visible = False

                tbxValorRetener.Visible = True
                tbxValorRetener.BringToFront()
                tbxValorRetener.Enabled = True

            End If

        ElseIf lbxTipoPago.Text = "Retencion Renta" Then
            RETENCIONRENTATableAdapter.Fill(Me.DsPagosFacutas.RETENCIONRENTA, CmbProveedor.SelectedValue)
            Dim DT As DataTable = RETENCIONRENTATableAdapter.GetData(CmbProveedor.SelectedValue)
            lblPorcRetRenta.Text = PorcRetencionRenta.ToString + " %"
            lblMontoRetRenta.Text = "0"

            If btmodificar = 1 Then
                dgwRetencionRenta.Enabled = False
                lblNroRetRenta.Text = " "
                For x = 0 To CobroFormaPagoDataGridView.RowCount - 1
                    If CobroFormaPagoDataGridView.Rows(x).Cells("DESTIPOPAGO").Value = "Retención Renta" Or CobroFormaPagoDataGridView.Rows(x).Cells("DESTIPOPAGO").Value = "Retencion Renta" Then
                        lblNroRetRenta.Text = CobroFormaPagoDataGridView.Rows(x).Cells("NUMRETENCION").Value
                        Exit For
                    End If
                Next
            Else
                dgwRetencionRenta.Enabled = True
                GenerarNroRetencion()
            End If

            pnlRetencionRenta.Visible = True
            pnlRetencionRenta.BringToFront()

            lblSaldoFavor.BringToFront()
            lblPagado.BringToFront()
            Label20.BringToFront()
            Label21.BringToFront()

        ElseIf lbxTipoPago.Text = "Ajuste de Pago" Then
            pnlBlanco.BringToFront()
            tbxConcepto.Visible = True
            lblConcepto.Visible = True
            lblConceptoAyuda.Visible = True
        End If
    End Sub

    Private Sub btnDetalles_Click(sender As System.Object, e As System.EventArgs) Handles btnDetalles.Click
        'Abrir y Esconder el detalle de las cuentas a Cobrar

        If pnlFacturasaPagar.Visible = False Then
            pnlFacturasaPagar.Visible = True
            pnlFacturasaPagar.BringToFront()
            lblDetalles.Text = "Esconder"
            lblDetalles.ForeColor = Color.Tomato
            btnDetalles.Image = My.Resources.DisplayActive
            lblACobrar2.Visible = False
            lblMontoSelec2.Visible = False
        Else
            lbxTipoPago.SelectedValue = 1
            pnlFacturasaPagar.Visible = False
            pnlFacturasaPagar.SendToBack()
            lblDetalles.Text = "Ver Detalles"
            lblDetalles.ForeColor = Color.White
            btnDetalles.Image = My.Resources.Display

            If lblMontoSelecionado.Text <> "0" Then
                lblACobrar2.Visible = True
                lblMontoSelec2.Text = lblMontoSelecionado.Text
                lblMontoSelec2.Visible = True
            End If

            dtpFechaPago.Focus()
        End If
    End Sub

    Public Sub dgvFacturasaPagar_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFacturasaPagar.CellContentClick
        Dim MontoAPagar As Double
        Dim CuotasAPagar, NroFacturas As String

        MontoAPagar = 0 : CuotasAPagar = "" : NroFacturas = ""

        'Recorremos la grilla para ir sumando los valores seleccionados
        For i = 0 To dgvFacturasaPagar.RowCount - 1
            Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgvFacturasaPagar.Rows(i).Cells("Pagar")

            'Confirma los datos a la datasouce.
            Me.dgvFacturasaPagar.CommitEdit(DataGridViewDataErrorContexts.Commit)

            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
            Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)

            If checked = True Then
                MontoAPagar = MontoAPagar + dgvFacturasaPagar.Rows(i).Cells("SALDOCUOTA").Value

                CuotasAPagar = CuotasAPagar + Str(dgvFacturasaPagar.Rows(i).Cells("NUMEROCUOTA").Value)
                If (CuotasAPagar.Length = 1) Or (CuotasAPagar.Length = 2) Then
                    CuotasAPagar = dgvFacturasaPagar.Rows(i).Cells("NUMEROCUOTA").Value
                    Try
                        NroFacturas = dgvFacturasaPagar.Rows(i).Cells("NUMFACTURA").Value
                    Catch ex As Exception
                    End Try
                Else
                    CuotasAPagar = "Varios"
                    NroFacturas = "Ver Detalle"
                End If
            End If
        Next

        lblMontoSelecionado.Text = FormatNumber(MontoAPagar, 2)
        lblCuotas.Text = CuotasAPagar
        lblNroFacturas.Text = NroFacturas

        Dim Chequeado As Boolean = VerificarCkequet()
        If Chequeado = False Then
            CalcularSaldo()
        End If

    End Sub

    Private Sub dtpFechaPago_GotFocus(sender As Object, e As System.EventArgs) Handles dtpFechaPago.GotFocus
        dtpFechaPago.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub cbxPagador_GotFocus(sender As Object, e As System.EventArgs) Handles cbxPagador.GotFocus
        cbxPagador.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub cbxPagador_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxPagador.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxMonto.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub btnAgregarPagos_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarPagos.Click
        Dim Chequeado As Boolean
        Dim CodPago, TipoFormaPago, IdApertura As Integer
        Dim Monto As Double

        lblInfoRef.Visible = False

        'Choefiente Cambio
        Dim Coheficiente As String = f.FuncionConsultaString2("FACTORVENTA", "COTIZACION", "CODMONEDA", cbxMoneda.SelectedValue & " ORDER BY FECGRA DESC")
        If Coheficiente = Nothing Then
            MessageBox.Show("El coheficiente para " & cbxMoneda.Text & " es íncorrecto o inexistente", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxMoneda.Focus()
            cbxMoneda.BackColor = Color.Pink
            Exit Sub
        End If

        'Verificamos que se completen todos los campos necesarios
        If tbxMonto.Text = "" Then
            MessageBox.Show("Ingrese el Monto a Pagar", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxMonto.Focus()
            tbxMonto.BackColor = Color.Pink
            lblPagosEstado.Text = "Ingrese el Monto a Pagar"
            Exit Sub
        End If

        If CDec(tbxMonto.Text) > CDec(lblMontoSelecionado.Text) Then
            MsgBox("El Monto de Cobro es superior al Monto Seleccionado a Pagar. Se ajustará el monto a Pagar", MsgBoxStyle.Information, "PosExpress")
            'tbxMonto.Appearance.BackColor = Color.Pink
            'Exit Sub    Se le deja Seguir Igual
        End If

        If lbxTipoPago.Text = "Efectivo" Then
            If cbxCuenta.Text = "" Then
                MessageBox.Show("Ingrese la Cuenta", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxCuenta.Focus()
                cbxCuenta.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese la Cuenta"
                Exit Sub
            End If
        ElseIf lbxTipoPago.Text = "Cheque" Then
            If cbxCuenta.Text = "" Then
                MessageBox.Show("Ingrese la Cuenta", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxCuenta.Focus()
                cbxCuenta.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese la Cuenta"

                Exit Sub
            End If
            If tbxNroRef.Text = "" Then
                MessageBox.Show("Ingrese el Nro de Ref.", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxNroRef.Focus()
                tbxNroRef.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese el Nro de Ref."
                Exit Sub
            End If
        ElseIf lbxTipoPago.Text = "Nota de Credito" Then
            If tbxNotadeCredito.Text = "" Then
                MessageBox.Show("Ingrese el Nro de la Nota de Credito", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxNotadeCredito.Focus()
                tbxNotadeCredito.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese el Nro de la Nota de Credito"
                Exit Sub
            End If
            If tbxMonto.Text > SaldoNC Then
                MessageBox.Show("El Monto Supera el Saldo de la Nota de Credito. Ingrese un Monto no superior al Saldo de la Nota de Crédito", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxMonto.Focus()
                lblPagosEstado.Text = "Ingrese un Monto no superior al Saldo de la Nota de Crédito"
                Exit Sub
            End If
        ElseIf lbxTipoPago.Text = "Tarjeta" Then
            If cbxCuenta.Text = "" Then
                MessageBox.Show("Ingrese la Cuenta", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxCuenta.Focus()
                cbxCuenta.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese la Cuenta"
                Exit Sub
            End If
        ElseIf lbxTipoPago.Text = "Transferencia" Then
            If cbxCuenta.Text = "" Then
                MessageBox.Show("Ingrese la Cuenta", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxCuenta.Focus()
                cbxCuenta.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese la Cuenta"
                Exit Sub
            End If
            If tbxNroRef.Text = "" Then
                MessageBox.Show("Ingrese el Nro de Ref.", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxNroRef.Focus()
                tbxNroRef.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese el Nro de Ref."
                Exit Sub
            End If
        ElseIf lbxTipoPago.Text = "Retencion" Or lbxTipoPago.Text = "Retención Iva" Then

            If tbxValorRetener.Text = "" Then
                ValorRetener = lblMontoRentencion.Text
            Else
                ValorRetener = tbxValorRetener.Text
            End If

            If tbxNroRetencion.Text = "" Then
                MessageBox.Show("Ingrese el Nro de la Retencion", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxNroRetencion.Focus()
                tbxNroRetencion.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese el Nro de la Retencion"
                Exit Sub
            Else
                IsRetencion = 1 : IsRetencionRenta = 0
            End If
        ElseIf lbxTipoPago.Text = "Retencion Renta" Or lbxTipoPago.Text = "Retención Renta" Then
            If lblNroRetRenta.Text = "" Then
                MessageBox.Show("Debe generar el Nro. de la Retención de Renta", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxNroRetencion.Focus()
                tbxNroRetencion.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese el Nro. de la Retención de Renta"
                Exit Sub
            Else
                IsRetencion = 0 : IsRetencionRenta = 1
            End If
        ElseIf lbxTipoPago.Text = "Ajuste de Pago" Then
            If cbxCuenta.Text = "" Then
                MessageBox.Show("Ingrese la Cuenta", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxCuenta.Focus()
                cbxCuenta.BackColor = Color.Pink
                lblPagosEstado.Text = "Ajuste de Pago"
                Exit Sub
            End If
            If tbxConcepto.Text = "" Then
                MessageBox.Show("Ingrese el Concepto", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxConcepto.Focus()
                tbxConcepto.BackColor = Color.Pink
                lblPagosEstado.Text = "Ingrese el Concepto"
                Exit Sub
            End If
        End If

        'If lbxTipoPago.Text <> "Retencion" And lbxTipoPago.Text <> "Retención Iva" Then
        IdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", cbxCuenta.SelectedValue)
        'End If

        If IdApertura = 0 Then
            MessageBox.Show("No ha realizado ninguna Apertura para esta Cuenta/Caja", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim MontoPagado As Decimal
        Dim ImporteGrilla As Decimal
        Dim i2 As Integer
        If lbxTipoPago.Text = "Retención Iva" Or lbxTipoPago.Text = "Retencion" Then
            Chequeado = VerifCheckRetIva()
            Dim rows As Integer = dgwRetencion.RowCount
            If rows > 0 Then
                MontoPagado = CDec(ValorRetener) * CDec(Coheficiente)
                If Chequeado = True Then
                    For i = 1 To rows
                        If MontoPagado > 0 Then
                            If dgwRetencion.Rows(i - 1).Cells("Retener").Value = True Then
                                i2 = buscaIndiceFactura(dgwRetencion.Rows(i - 1).Cells("CODCOMPRARET").Value)
                                Monto = ValorRetener
                                ' CDec(dgwRetencion.Rows(i - 1).Cells("TOTALIVA").Value) * (PorcRetencion / 100)
                                If MontoPagado >= Monto Then
                                    dgvFacturasaPagar.Rows(i2).Cells("SALDOCUOTA").Value = dgvFacturasaPagar.Rows(i2).Cells("SALDOCUOTA").Value - Monto
                                    ImporteGrilla = Monto
                                    MontoPagado = MontoPagado - Monto
                                Else
                                    dgvFacturasaPagar.Rows(i2).Cells("SALDOCUOTA").Value = dgvFacturasaPagar.Rows(i2).Cells("SALDOCUOTA").Value - MontoPagado
                                    ImporteGrilla = MontoPagado
                                    MontoPagado = 0
                                End If
                                If dgvFacturasaPagar.Rows(i2).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaPagar.Rows(i2).Cells("TIPOFACTURA").Value = "Contado" Then
                                    TipoFormaPago = 0
                                Else
                                    TipoFormaPago = 1
                                End If
                                'Insertamos en la grilla
                                DETALLEPAGOBindingSource.AddNew()
                                Dim c As Integer = CobroFormaPagoDataGridView.RowCount

                                If btmodificar = 1 Then
                                    If ContNewFilasEdit = 0 Then
                                        CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                        CodPago = CodPago + 1
                                        ContNewFilasEdit = ContNewFilasEdit + 1
                                    Else
                                        CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                        ContNewFilasEdit = ContNewFilasEdit + 1
                                    End If
                                Else
                                    If c = 1 Then
                                        CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                        CodPago = CodPago + 1
                                    ElseIf c > 1 Then
                                        CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                    End If
                                End If

                                Dim sinfechadet As Boolean = False
                                If dtpFechaPagoDet.Text = "" Then
                                    sinfechadet = True
                                    dtpFechaPagoDet.Value = dtpFechaPago.Text
                                End If

                                Dim conctFecha As String
                                Dim conctHora As String = Now.ToString("HH:mm:ss")
                                If sinfechadet = True Then
                                    conctFecha = dtpFechaPagoDet.Value
                                Else
                                    conctFecha = dtpFechaPagoDet.Text
                                End If
                                Dim conctFechaHora As String = conctFecha & " " + conctHora

                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMCOMPRA").Value = dgvFacturasaPagar.Rows(i2).Cells("NUMFACTURA").Value
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCOMPRA").Value = dgvFacturasaPagar.Rows(i2).Cells("CODCOMPRA1").Value
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoPago.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoPago.SelectedValue
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaPagar.Rows(i2).Cells("NUMEROCUOTA").Value
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CUENTA").Value = cbxCuenta.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCUENTA").Value = cbxCuenta.SelectedValue
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMDEVOLUCION").Value = tbxNotadeCredito.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODNRODEV").Value = txtCodDevolucion
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = "I"

                                lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                            End If
                        Else
                            Exit For
                        End If
                    Next
                Else
                    MessageBox.Show("Debe Seleccionar las Facturas para aplicar la Retención", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                MessageBox.Show("No hay Facturas para aplicar la Retención", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf lbxTipoPago.Text = "Retención Renta" Or lbxTipoPago.Text = "Retencion Renta" Then
            Chequeado = VerifCheckRetRenta()
            Dim rows As Integer = dgwRetencionRenta.RowCount
            If rows > 0 Then
                MontoPagado = CDec(lblMontoRetRenta.Text) * CDec(Coheficiente)
                If Chequeado = True Then
                    For i = 1 To rows
                        If MontoPagado > 0 Then
                            If dgwRetencionRenta.Rows(i - 1).Cells("RetenerRenta").Value = True Then
                                i2 = buscaIndiceFactura(dgwRetencionRenta.Rows(i - 1).Cells("CODCOMPRARENTA2").Value)
                                Monto = CDec(dgwRetencionRenta.Rows(i - 1).Cells("SALDORENTA2").Value) * (PorcRetencionRenta / 100)
                                If MontoPagado >= Monto Then
                                    dgvFacturasaPagar.Rows(i2).Cells("SALDOCUOTA").Value = dgvFacturasaPagar.Rows(i2).Cells("SALDOCUOTA").Value - Monto
                                    ImporteGrilla = Monto
                                    MontoPagado = MontoPagado - Monto
                                Else
                                    dgvFacturasaPagar.Rows(i2).Cells("SALDOCUOTA").Value = dgvFacturasaPagar.Rows(i2).Cells("SALDOCUOTA").Value - MontoPagado
                                    ImporteGrilla = MontoPagado
                                    MontoPagado = 0
                                End If
                                If dgvFacturasaPagar.Rows(i2).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaPagar.Rows(i2).Cells("TIPOFACTURA").Value = "Contado" Then
                                    TipoFormaPago = 0
                                Else
                                    TipoFormaPago = 1
                                End If
                                'Insertamos en la grilla
                                DETALLEPAGOBindingSource.AddNew()
                                Dim c As Integer = CobroFormaPagoDataGridView.RowCount

                                If btmodificar = 1 Then
                                    If ContNewFilasEdit = 0 Then
                                        CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                        CodPago = CodPago + 1
                                        ContNewFilasEdit = ContNewFilasEdit + 1
                                    Else
                                        CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                        ContNewFilasEdit = ContNewFilasEdit + 1
                                    End If
                                Else
                                    If c = 1 Then
                                        CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                        CodPago = CodPago + 1
                                    ElseIf c > 1 Then
                                        CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                    End If
                                End If

                                Dim sinfechadet As Boolean = False
                                If dtpFechaPagoDet.Text = "" Then
                                    sinfechadet = True
                                    dtpFechaPagoDet.Value = dtpFechaPago.Text
                                End If

                                Dim conctFecha As String
                                Dim conctHora As String = Now.ToString("HH:mm:ss")
                                If sinfechadet = True Then
                                    conctFecha = dtpFechaPagoDet.Value
                                Else
                                    conctFecha = dtpFechaPagoDet.Text
                                End If
                                Dim conctFechaHora As String = conctFecha & " " + conctHora

                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMCOMPRA").Value = dgvFacturasaPagar.Rows(i2).Cells("NUMFACTURA").Value
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCOMPRA").Value = dgvFacturasaPagar.Rows(i2).Cells("CODCOMPRA1").Value
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoPago.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoPago.SelectedValue
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaPagar.Rows(i2).Cells("NUMEROCUOTA").Value
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CUENTA").Value = cbxCuenta.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCUENTA").Value = cbxCuenta.SelectedValue
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMRETENCION").Value = lblNroRetRenta.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMDEVOLUCION").Value = tbxNotadeCredito.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODNRODEV").Value = txtCodDevolucion
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                CobroFormaPagoDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = "I"

                                lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                            End If
                        Else
                            Exit For
                        End If
                    Next
                Else
                    MessageBox.Show("Debe Seleccionar las Facturas para aplicar la Retención de Renta", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                MessageBox.Show("No existen AutoFacturas para aplicar la Retención de Renta", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            'Verificamos si se chequeo o no algun campo de la grilla
            Chequeado = VerificarCkequet()
            Dim rows As Integer = dgvFacturasaPagar.RowCount
            MontoPagado = CDec(tbxMonto.Text) * CDec(Coheficiente)
            If Chequeado = True Then
                For i = 1 To rows
                    If dgvFacturasaPagar.Rows(i - 1).Cells("Pagar").Value = True Then
                        Monto = dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value

                        If MontoPagado > 0 Then
                            If MontoPagado >= Monto Then
                                dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                ImporteGrilla = tbxMonto.Text
                            Else
                                dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                ImporteGrilla = MontoPagado
                            End If
                            'Actualizar Saldo de la NC
                            If i = 1 And lbxTipoPago.Text = "Nota de Credito" Then ' Solo hace falta 1 vez
                                If MontoPagado = SaldoNC Then
                                    dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value = "0"
                                Else
                                    dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value = dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value - MontoPagado
                                End If
                            End If

                            MontoPagado = Monto - MontoPagado
                            MontoPagado = MontoPagado * (-1)

                            If dgvFacturasaPagar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaPagar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                TipoFormaPago = 0
                            Else
                                TipoFormaPago = 1
                            End If

                            'Insertamos en la grilla
                            DETALLEPAGOBindingSource.AddNew()
                            Dim c As Integer = CobroFormaPagoDataGridView.RowCount

                            If btmodificar = 1 Then
                                If ContNewFilasEdit = 0 Then
                                    CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                    CodPago = CodPago + 1
                                    ContNewFilasEdit = ContNewFilasEdit + 1
                                Else
                                    CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                    ContNewFilasEdit = ContNewFilasEdit + 1
                                End If
                            Else
                                If c = 1 Then
                                    CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                    CodPago = CodPago + 1
                                ElseIf c > 1 Then
                                    CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                End If
                            End If

                            Dim sinfechadet As Boolean = False
                            If dtpFechaPagoDet.Text = "" Then
                                sinfechadet = True
                                dtpFechaPagoDet.Value = dtpFechaPago.Text
                            End If

                            Dim conctFecha As String
                            Dim conctHora As String = Now.ToString("HH:mm:ss")
                            If sinfechadet = True Then
                                conctFecha = dtpFechaPagoDet.Value
                            Else
                                conctFecha = dtpFechaPagoDet.Text
                            End If
                            Dim conctFechaHora As String = conctFecha & " " + conctHora

                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMCOMPRA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("NUMFACTURA").Value
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCOMPRA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("CODCOMPRA1").Value
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoPago.Text
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoPago.SelectedValue
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("CUENTA").Value = cbxCuenta.Text
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCUENTA").Value = cbxCuenta.SelectedValue
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMDEVOLUCION").Value = tbxNotadeCredito.Text
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODNRODEV").Value = txtCodDevolucion
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                            CobroFormaPagoDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = "I"

                            lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                        End If
                    End If
                Next
            Else
                For i = 1 To rows
                    Monto = dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value

                    If MontoPagado > 0 Then
                        If MontoPagado >= Monto Then
                            dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                            ImporteGrilla = Monto
                        Else
                            dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                            ImporteGrilla = MontoPagado
                        End If
                        'Actualizar Saldo de la NC
                        If i = 1 And lbxTipoPago.Text = "Nota de Credito" Then ' Solo hace falta 1 vez
                            If MontoPagado = SaldoNC Then
                                dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value = "0"
                            Else
                                dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value = dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value - MontoPagado
                            End If
                        End If

                        MontoPagado = Monto - MontoPagado
                        MontoPagado = MontoPagado * (-1)

                        If dgvFacturasaPagar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaPagar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                            TipoFormaPago = 0
                        Else
                            TipoFormaPago = 1
                        End If

                        'Insertamos en la grilla
                        DETALLEPAGOBindingSource.AddNew()
                        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

                        If btmodificar = 1 Then
                            If ContNewFilasEdit = 0 Then
                                CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                CodPago = CodPago + 1
                                ContNewFilasEdit = ContNewFilasEdit + 1
                            Else
                                CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                ContNewFilasEdit = ContNewFilasEdit + 1
                            End If
                        Else
                            If c = 1 Then
                                CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                CodPago = CodPago + 1
                            ElseIf c > 1 Then
                                CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                            End If
                        End If

                        Dim sinfechadet As Boolean = False
                        If dtpFechaPagoDet.Text = "" Then
                            sinfechadet = True
                            dtpFechaPagoDet.Value = dtpFechaPago.Text
                        End If

                        Dim conctFecha As String
                        Dim conctHora As String = Now.ToString("HH:mm:ss")
                        If sinfechadet = True Then
                            conctFecha = dtpFechaPagoDet.Value
                        Else
                            conctFecha = dtpFechaPagoDet.Text
                        End If
                        Dim conctFechaHora As String = conctFecha & " " + conctHora

                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMCOMPRA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("NUMFACTURA").Value
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCOMPRA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("CODCOMPRA1").Value
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoPago.Text
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoPago.SelectedValue
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CUENTA").Value = cbxCuenta.Text
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCUENTA").Value = cbxCuenta.SelectedValue
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMDEVOLUCION").Value = tbxNotadeCredito.Text
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODNRODEV").Value = txtCodDevolucion
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = "I"

                        lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                    Else
                        Exit For
                    End If
                Next
            End If
        End If

        'VarGlobSaldoFavor = MontoPagado
        Dim Saldo As Double
        Saldo = CDec(lblMontoSelecionado.Text) - CDec(lblPagado.Text)
        lblSaldoFavor.Text = FormatNumber(Saldo, 2)
        lblPagado.Text = FormatNumber(CDec(lblPagado.Text), 2)

        If MontoPagado < 0 Then
            Label21.Text = "Falta Pagar:"
        End If

        Dim TotalOtrosDoc, TotalRecibo, TotalPagado As Double
        Try
            For i = 0 To CobroFormaPagoDataGridView.RowCount - 1
                If CobroFormaPagoDataGridView.Rows(i).Cells("CODTIPOPAGO").Value = 5 Or CobroFormaPagoDataGridView.Rows(i).Cells("CODTIPOPAGO").Value = 8 Or CobroFormaPagoDataGridView.Rows(i).Cells("CODTIPOPAGO").Value = 7 Then
                    TotalOtrosDoc = TotalOtrosDoc + CobroFormaPagoDataGridView.Rows(i).Cells("IMPORTE").Value
                Else
                    TotalRecibo = TotalRecibo + CobroFormaPagoDataGridView.Rows(i).Cells("IMPORTE").Value
                End If
                TotalPagado = TotalPagado + CobroFormaPagoDataGridView.Rows(i).Cells("IMPORTE").Value
            Next
            LblTotalDoc.Text = FormatNumber(TotalOtrosDoc, 2)
            umeTotalRec.Text = FormatNumber(TotalRecibo, 2)
        Catch ex As Exception
        End Try


        'If lbxTipoPago.SelectedValue <> 5 And lbxTipoPago.SelectedValue <> 8 And lbxTipoPago.SelectedValue <> 7 Then
        '    umeTotalRec.Text = CDec(umeTotalRec.Text) + CDec(lblPagado.Text)
        'End If

        LimpiarDetalle()

        If lbxTipoPago.Text <> "Retencion" And lbxTipoPago.Text <> "Retencion Renta" Then
            lbxTipoPago.SelectedValue = 1
        End If

    End Sub

    Public Function buscaIndiceFactura(codcompra As String) As Integer
        Dim rows As Integer = dgvFacturasaPagar.RowCount
        Dim indice As Integer
        For x = 0 To rows - 1
            If dgvFacturasaPagar.Rows(x).Cells("CODCOMPRA1").Value = codcompra And dgvFacturasaPagar.Rows(x).Cells("SALDOCUOTA").Value > 0 Then
                indice = x
                Exit For
            End If
        Next
        Return indice
    End Function

    Public Function buscaIndiceFactura2(codcompra As String) As Integer
        Dim rows As Integer = dgwRetencion.RowCount
        Dim indice As Integer
        For x = 0 To rows - 1
            If dgwRetencion.Rows(x).Cells("CODCOMPRARET").Value = codcompra Then
                indice = x
                Exit For
            End If
        Next
        Return indice
    End Function
    Public Function buscaIndiceFactura3(codcompra As String) As Integer
        Dim rows As Integer = dgwRetencionRenta.RowCount
        Dim indice As Integer
        For x = 0 To rows - 1
            If dgwRetencionRenta.Rows(x).Cells("CODCOMPRARENTA2").Value = codcompra Then
                indice = x
                Exit For
            End If
        Next
        Return indice
    End Function

    Public Function VerifCheckRetIva() As Boolean
        Dim rows As Integer = dgwRetencion.RowCount
        Dim ExisteCkequet As Boolean

        ExisteCkequet = False
        For x = 1 To rows
            If dgwRetencion.Rows(x - 1).Cells("Retener").Value = True Then
                ExisteCkequet = True
                Exit For
            End If
        Next
        Return ExisteCkequet
    End Function
    Public Function VerifCheckRetRenta() As Boolean
        Dim rows As Integer = dgwRetencionRenta.RowCount
        Dim ExisteCkequet As Boolean

        ExisteCkequet = False
        For x = 1 To rows
            If dgwRetencionRenta.Rows(x - 1).Cells("RetenerRenta").Value = True Then
                ExisteCkequet = True
                Exit For
            End If
        Next
        Return ExisteCkequet
    End Function

    Public Function VerificarCkequet() As Boolean
        Dim rows As Integer = dgvFacturasaPagar.RowCount
        Dim ExisteCkequet As Boolean

        ExisteCkequet = False
        For x = 1 To rows
            If dgvFacturasaPagar.Rows(x - 1).Cells("Pagar").Value = True Then
                ExisteCkequet = True
                Exit For
            End If
        Next
        Return ExisteCkequet
    End Function

    Public Sub LimpiarDetalle()
        tbxMonto.Text = "" : tbxNroRef.Text = ""
        dtpFechaPagoDet.Text = dtpFechaPago.Text
        tbxConcepto.Text = "" : tbxNotadeCredito.Text = ""

        If lbxTipoPago.Text = "Retencion" Or lbxTipoPago.Text = "Retención de IVA" Then
            pnlRetencion.Visible = True
            pnlRetencionRenta.Visible = False
        ElseIf lbxTipoPago.Text = "Retencion Renta" Or lbxTipoPago.Text = "Retención Renta" Then
            pnlRetencionRenta.Visible = True
            pnlRetencion.Visible = False
        Else
            pnlRetencion.Visible = False
            pnlRetencionRenta.Visible = False
            tbxNroRetencion.Text = ""
            lblNroRetRenta.Text = ""
        End If
    End Sub

    Private Sub btnFiltrarCtaCte_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrarCtaCte.Click
        Dim par1 As String

        If IsDBNull(GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value) Then
            par1 = 0
        Else
            par1 = GridViewProveedor.CurrentRow.Cells("CODPROVEEDOR").Value
        End If

        If chbxEsconderSaldoCero.Checked = True Then
            If (Fecha1Filtro.Text = "  /  /    ") And (Fecha2Filtro.Text = "  /  /    ") Then
                Me.FiltroPagoSaldoTableAdapter.Fill(DsPagosFacutas.FiltroPagoSaldo, par1)
            Else
                If (Fecha1Filtro.Text <> "  /  /    ") And (Fecha2Filtro.Text <> "  /  /    ") Then
                    Dim dtFecha As DateTime = DateTime.Now
                    Dim Fecha

                    Fecha = dtFecha.ToString("dd/MM/yyyy")
                    Fecha2Filtro.Text = Fecha

                    Me.FiltroPagoSaldoTableAdapter.FillByFechaSinSaldo(Me.DsPagosFacutas.FiltroPagoSaldo, par1, Fecha1Filtro.Text, Fecha2Filtro.Text)
                End If
                If (Fecha1Filtro.Text <> "  /  /    ") And (Fecha2Filtro.Text = "  /  /    ") Then
                    Dim dtFecha As DateTime = DateTime.Now
                    Dim Fecha

                    Fecha = dtFecha.ToString("dd/MM/yyyy")
                    Fecha2Filtro.Text = Fecha

                    Me.FiltroPagoSaldoTableAdapter.FillByFechaSinSaldo(Me.DsPagosFacutas.FiltroPagoSaldo, par1, Fecha1Filtro.Text, Fecha2Filtro.Text)
                End If
                If (Fecha1Filtro.Text = "  /  /    ") And (Fecha2Filtro.Text <> "  /  /    ") Then
                    Me.FiltroPagoSaldoTableAdapter.FillByFecha1SinSaldo(Me.DsPagosFacutas.FiltroPagoSaldo, par1, Fecha2Filtro.Text)
                End If
            End If

        ElseIf chbxEsconderSaldoCero.Checked = False Then
            If (Fecha1Filtro.Text = "  /  /    ") And (Fecha2Filtro.Text = "  /  /    ") Then
                Me.FiltroPagoSaldoTableAdapter.FillBy(DsPagosFacutas.FiltroPagoSaldo, par1)
            Else
                If (Fecha1Filtro.Text <> "  /  /    ") And (Fecha2Filtro.Text <> "  /  /    ") Then
                    Me.FiltroPagoSaldoTableAdapter.FillByFechaConSaldo(Me.DsPagosFacutas.FiltroPagoSaldo, par1, Fecha1Filtro.Text, Fecha2Filtro.Text)
                End If
                If (Fecha1Filtro.Text <> "  /  /    ") And (Fecha2Filtro.Text = "  /  /    ") Then
                    Dim dtFecha As DateTime = DateTime.Now
                    Dim Fecha

                    Fecha = dtFecha.ToString("dd/MM/yyyy")
                    Fecha2Filtro.Text = Fecha

                    Me.FiltroPagoSaldoTableAdapter.FillByFechaConSaldo(Me.DsPagosFacutas.FiltroPagoSaldo, par1, Fecha1Filtro.Text, Fecha2Filtro.Text)
                End If
                If (Fecha1Filtro.Text = "  /  /    ") And (Fecha2Filtro.Text <> "  /  /    ") Then
                    Me.FiltroPagoSaldoTableAdapter.FillByFecha1ConSaldo(Me.DsPagosFacutas.FiltroPagoSaldo, par1, Fecha2Filtro.Text)
                End If
            End If
        End If
    End Sub

    Public Sub ChequearGrilla()
        If ComprasPago = 1 Then
            For i = 0 To dgvFacturasaPagar.RowCount - 1
                If dgvFacturasaPagar.Rows(i).Cells("CODCOMPRA1").Value = CodigoCompra Then
                    dgvFacturasaPagar.Enabled = True
                    dgvFacturasaPagar.Rows(i).Cells("Pagar").Value = True
                End If
            Next
        End If
    End Sub

    Private Sub btnEliminarPagos_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarPagos.Click

        Dim Totaladescontar As Double
        If CobroFormaPagoDataGridView.RowCount = 0 Then
            Exit Sub
        End If

        If btmodificar = 1 And CobroFormaPagoDataGridView.CurrentRow.Cells("EstadoGrilla").Value = "I" Then
            ContNewFilasEdit = ContNewFilasEdit - 1
        End If

        'Antes de eliminar debemos restaurar la grilla de Facturas a Pagar
        Dim EncontreFactura As Integer = 0
        Dim TIENENC As Integer = 0
        Dim EncontreNC As Integer = 0

        For i = 0 To dgvFacturasaPagar.RowCount - 1
            If dgvFacturasaPagar.Rows(i).Cells("CODCOMPRA1").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("CODCOMPRA").Value And dgvFacturasaPagar.Rows(i).Cells("NUMEROCUOTA").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("NROCUOTA").Value Then
                dgvFacturasaPagar.Rows(i).Cells("SALDOCUOTA").Value = dgvFacturasaPagar.Rows(i).Cells("SALDOCUOTA").Value + CobroFormaPagoDataGridView.CurrentRow.Cells("IMPORTE").Value
                Totaladescontar = Totaladescontar + CobroFormaPagoDataGridView.CurrentRow.Cells("IMPORTE").Value
                EncontreFactura = 1
                Exit For
            End If
        Next

        Dim STRCODDEVOLUCION As String = ""
        If Not IsDBNull(CobroFormaPagoDataGridView.CurrentRow.Cells("NUMDEVOLUCION").Value) Then
            If Not Trim(CobroFormaPagoDataGridView.CurrentRow.Cells("NUMDEVOLUCION").Value) = "" Then
                TIENENC = 1 'Tiene asociada una NC
                STRCODDEVOLUCION = f.FuncionConsultaString("CODDEVOLUCION", "DEVOLUCIONCOMPRA", "NUMDEVOLUCION", CobroFormaPagoDataGridView.CurrentRow.Cells("NUMDEVOLUCION").Value)
                For i = 0 To dgvNotaCredito.RowCount - 1
                    If STRCODDEVOLUCION = dgvNotaCredito.Rows(i).Cells("CODDEVOLUCION").Value Then
                        Dim suma As Integer = dgvNotaCredito.Rows(i).Cells("SALDODataGridViewTextBoxColumn").Value + CobroFormaPagoDataGridView.CurrentRow.Cells("IMPORTE").Value ' Este control por si haya eliminado 2 veces, o aumenta el saldo mas que el importe
                        If suma > dgvNotaCredito.Rows(i).Cells("IMPORTEDataGridViewTextBoxColumn2").Value Then
                            dgvNotaCredito.Rows(i).Cells("SALDODataGridViewTextBoxColumn").Value = dgvNotaCredito.Rows(i).Cells("IMPORTEDataGridViewTextBoxColumn2").Value
                        Else
                            dgvNotaCredito.Rows(i).Cells("SALDODataGridViewTextBoxColumn").Value = suma
                        End If
                        EncontreNC = 1
                        ModifNC = 1
                        Exit For
                    End If
                Next
            End If
        End If

        Dim vCodTipoPago As Integer = CobroFormaPagoDataGridView.CurrentRow.Cells("CODTIPOPAGO").Value

        If btnuevo = 1 Then
            CobroFormaPagoDataGridView.Rows.Remove(Me.CobroFormaPagoDataGridView.CurrentRow)
            GoTo actualizarglobales
        ElseIf btmodificar = 1 And CobroFormaPagoDataGridView.CurrentRow.Cells("EstadoGrilla").Value = "I" Then ' Si EstadoGrilla tiene ese valor es porque fue una fila nueva despues de darle Edita
            CobroFormaPagoDataGridView.Rows.Remove(Me.CobroFormaPagoDataGridView.CurrentRow)
            GoTo actualizarglobales
            'ElseIf btmodificar = 1 And vCodTipoPago = 6 Then
            '    MessageBox.Show("No se puede Eliminar una Retencion ya Aprobada, Ingrese en el Administrador de Retenciones y Anule la Retencion", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
        End If

        If EncontreFactura = 0 Then
            FACTURAPAGARBindingSource.AddNew()
            Dim c As Integer = dgvFacturasaPagar.RowCount

            dgvFacturasaPagar.Rows(c - 1).Cells("CODCOMPRA1").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("CODCOMPRA").Value
            dgvFacturasaPagar.Rows(c - 1).Cells("NUMFACTURA").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("NUMCOMPRA").Value
            dgvFacturasaPagar.Rows(c - 1).Cells("NUMEROCUOTA").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("NROCUOTA").Value
            dgvFacturasaPagar.Rows(c - 1).Cells("SALDOCUOTA").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("IMPORTE").Value

            ser.Abrir(sqlc)
            Dim daFact As New SqlDataAdapter("Select IMPORTECUOTA,FECHAVCTO,TIPOFACTURA FROM FACTURAPAGAR WHERE CODCOMPRA = " & CobroFormaPagoDataGridView.CurrentRow.Cells("CODCOMPRA").Value & "", sqlc)
            Dim dtFact As New DataTable
            Dim drFact As DataRow

            daFact.Fill(dtFact)

            If dtFact.Rows.Count <> 0 Then
                drFact = dtFact.Rows.Item(0)
                dgvFacturasaPagar.Rows(c - 1).Cells("TIPOFACTURA").Value = drFact("TIPOFACTURA")
                dgvFacturasaPagar.Rows(c - 1).Cells("FECHAVCTO").Value = drFact("FECHAVCTO")
                dgvFacturasaPagar.Rows(c - 1).Cells("DataGridViewTextBoxColumn27").Value = drFact("IMPORTECUOTA")
            End If

            Totaladescontar = Totaladescontar + CobroFormaPagoDataGridView.CurrentRow.Cells("IMPORTE").Value
        End If

        If TIENENC = 1 And EncontreNC = 0 Then
            ModifNC = 1
            NdebitoTableAdapter.Fill(DsPagosFacutas.NDEBITO, CmbProveedor.SelectedValue)

            Dim dt As DataTable = NdebitoTableAdapter.GetData(CmbProveedor.SelectedValue)
            NDEBITOBindingSource.AllowNew = True
            NDEBITOBindingSource.AddNew()

            dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("NUMDEVOLUCION").Value
            dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("SALDODataGridViewTextBoxColumn").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("IMPORTE").Value
            dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("NUMCOMPRADataGridViewTextBoxColumn").Value = CobroFormaPagoDataGridView.CurrentRow.Cells("NUMCOMPRA").Value

            Dim daNC As New SqlDataAdapter("Select TOTALDEVOLUCION,FECHADEVOLUCION FROM DEVOLUCIONCOMPRA WHERE CODDEVOLUCION = " & STRCODDEVOLUCION & "", sqlc)
            Dim dtNC As New DataTable
            Dim drNC As DataRow

            daNC.Fill(dtNC)

            If dtNC.Rows.Count <> 0 Then
                drNC = dtNC.Rows.Item(0)
                dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("FECHADataGridViewTextBoxColumn").Value = drNC("FECHADEVOLUCION")
                dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("IMPORTEDataGridViewTextBoxColumn2").Value = drNC("TOTALDEVOLUCION")
                dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("CODDEVOLUCION").Value = STRCODDEVOLUCION
            End If
        End If

        CobroFormaPagoDataGridView.CurrentRow.Cells("EstadoGrilla").Value = "D"
        CobroFormaPagoDataGridView.CurrentRow.Cells("DESTIPOPAGO").Value = "A Eliminar"

        For i = 0 To CobroFormaPagoDataGridView.ColumnCount - 1
            CobroFormaPagoDataGridView.Item(i, CobroFormaPagoDataGridView.CurrentRow.Index).Style.BackColor = Color.Pink
        Next

actualizarglobales:
        If lblPagado.Text <> "" Then
            lblPagado.Text = CDec(lblPagado.Text) - Totaladescontar
            lblPagado.Text = FormatNumber(CDec(lblPagado.Text), 2)
        End If

        Dim FaltaPagar As Double
        If lblSaldoFavor.Text <> "" And lblSaldoFavor.Text <> "lblSaldo" Then
            FaltaPagar = Math.Abs(CDec(lblSaldoFavor.Text))
            lblSaldoFavor.Text = FaltaPagar + Totaladescontar
            lblSaldoFavor.Text = FormatNumber(CDec(lblSaldoFavor.Text), 2)
        End If
    End Sub

    Private Function SaldoCERO(ByVal indice As Integer) As Boolean
        If dgvNotaCredito.Rows(indice).Cells("SALDODataGridViewTextBoxColumn").Value = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function VerificarCkequetNC() As Boolean
        Dim rows As Integer = dgvNotaCredito.RowCount
        Dim ExisteCkequet As Boolean

        ExisteCkequet = False
        For x = 1 To rows
            If dgvNotaCredito.Rows(x - 1).Cells("Usar").Value = True Then
                ExisteCkequet = True
                Exit For
            End If
        Next
        Return ExisteCkequet
    End Function

    Private Sub btnAgregarNC_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarNC.Click
        Try
            Dim Chequeado, ChequeadoNC As Boolean
            Dim CodPago, TipoFormaPago As Integer
            Dim MontoPagado, ImporteGrilla, Monto As Decimal
            Dim CodDevolucion, NroDevolucion As String

            Dim Coheficiente As String = f.FuncionConsultaString2("FACTORVENTA", "COTIZACION", "CODMONEDA", cbxMoneda.SelectedValue & " ORDER BY FECGRA DESC")

            ChequeadoNC = VerificarCkequetNC()
            If ChequeadoNC = False Then
                MessageBox.Show("Debe Seleccionar al menos una Devolucion", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UltraPopupControlContainer2.Close()
                Exit Sub
            End If

            For j = 0 To dgvNotaCredito.RowCount - 1
                If dgvNotaCredito.Rows(j).Cells("Usar").Value = True Then
                    'Antes de insertar la devolucion debemos verificar que no se halla usado aun o no exita todavia en la grilla
                    If SaldoCERO(j) = True Then
                        MessageBox.Show("El saldo de la Nota de Credito Nro :" & dgvNotaCredito.Rows(j).Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value & " se encuentra agotado", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If dgvNotaCredito.Rows(j).Cells("SALDODataGridViewTextBoxColumn").Value <> 0 Then
                        MontoPagado = dgvNotaCredito.Rows(j).Cells("SALDODataGridViewTextBoxColumn").Value * CDec(Coheficiente)
                        dgvNotaCredito.Rows(j).Cells("SALDODataGridViewTextBoxColumn").Value = 0
                        ModifNC = 1
                        CodDevolucion = dgvNotaCredito.Rows(j).Cells("CODDEVOLUCION").Value
                        NroDevolucion = dgvNotaCredito.Rows(j).Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value

                        'Verificamos si se chequeo o no algun campo de la grilla de las Facturas Pendientes de Cobro
                        Chequeado = VerificarCkequet()
                        Dim rows As Integer = dgvFacturasaPagar.RowCount

                        If Chequeado = True Then
                            For i = 1 To dgvFacturasaPagar.RowCount
                                If dgvFacturasaPagar.Rows(i - 1).Cells("Pagar").Value = True Then
                                    Monto = dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value


                                    If MontoPagado <> 0 Then
                                        If MontoPagado >= Monto Then
                                            dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                            ImporteGrilla = Monto
                                        Else
                                            dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                            ImporteGrilla = MontoPagado
                                        End If
                                        MontoPagado = Monto - MontoPagado
                                        MontoPagado = MontoPagado * (-1)

                                        If dgvFacturasaPagar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaPagar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                            TipoFormaPago = 0
                                        Else
                                            TipoFormaPago = 1
                                        End If

                                        DETALLEPAGOBindingSource.AddNew()
                                        Dim c As Integer = CobroFormaPagoDataGridView.RowCount

                                        If btmodificar = 1 Then
                                            If ContNewFilasEdit = 0 Then
                                                CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                                CodPago = CodPago + 1
                                                ContNewFilasEdit = ContNewFilasEdit + 1
                                            Else
                                                CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                                ContNewFilasEdit = ContNewFilasEdit + 1
                                            End If
                                        Else
                                            If c = 1 Then
                                                CodPago = f.Maximo("CODPAGO", "VENTASFORMACOBRO")
                                                CodPago = CodPago + 1
                                            ElseIf c > 1 Then
                                                CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                            End If
                                        End If

                                        Dim sinfechadet As Boolean = False
                                        If dtpFechaPagoDet.Text = "" Then
                                            sinfechadet = True
                                            dtpFechaPagoDet.Value = dtpFechaPago.Text
                                        End If

                                        Dim conctFecha As String
                                        Dim conctHora As String = Now.ToString("HH:mm:ss")
                                        If sinfechadet = True Then
                                            conctFecha = dtpFechaPagoDet.Value
                                        Else
                                            conctFecha = dtpFechaPagoDet.Text
                                        End If
                                        Dim conctFechaHora As String = conctFecha & " " + conctHora

                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMCOMPRA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("NUMFACTURA").Value
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCOMPRA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("CODCOMPRA1").Value
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoPago.Text
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoPago.SelectedValue
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CUENTA").Value = cbxCuenta.Text
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCUENTA").Value = cbxCuenta.SelectedValue
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMDEVOLUCION").Value = NroDevolucion
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODNRODEV").Value = CodDevolucion
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                        CobroFormaPagoDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = "I"

                                        lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                                        lblPagado.Text = FormatNumber(lblPagado.Text, 0)
                                    End If
                                End If
                            Next

                        Else
                            For i = 1 To rows
                                Monto = dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value

                                If MontoPagado > 0 Then
                                    If MontoPagado >= Monto Then
                                        dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                        ImporteGrilla = Monto
                                    Else
                                        dgvFacturasaPagar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                        ImporteGrilla = MontoPagado
                                    End If
                                    MontoPagado = Monto - MontoPagado
                                    MontoPagado = MontoPagado * (-1)

                                    If dgvFacturasaPagar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaPagar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                        TipoFormaPago = 0
                                    Else
                                        TipoFormaPago = 1
                                    End If

                                    'Insertamos en la grilla
                                    DETALLEPAGOBindingSource.AddNew()
                                    Dim c As Integer = CobroFormaPagoDataGridView.RowCount

                                    If btmodificar = 1 Then
                                        If ContNewFilasEdit = 0 Then
                                            CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                            CodPago = CodPago + 1
                                            ContNewFilasEdit = ContNewFilasEdit + 1
                                        Else
                                            CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                            ContNewFilasEdit = ContNewFilasEdit + 1
                                        End If
                                    Else
                                        If c = 1 Then
                                            CodPago = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                                            CodPago = CodPago + 1
                                        ElseIf c > 1 Then
                                            CodPago = CobroFormaPagoDataGridView.Rows(c - 2).Cells("CODPAGO").Value + 1
                                        End If
                                    End If

                                    Dim sinfechadet As Boolean = False
                                    If dtpFechaPagoDet.Text = "" Then
                                        sinfechadet = True
                                        dtpFechaPagoDet.Value = dtpFechaPago.Text
                                    End If

                                    Dim conctFecha As String
                                    Dim conctHora As String = Now.ToString("HH:mm:ss")
                                    If sinfechadet = True Then
                                        conctFecha = dtpFechaPagoDet.Value
                                    Else
                                        conctFecha = dtpFechaPagoDet.Text
                                    End If
                                    Dim conctFechaHora As String = conctFecha & " " + conctHora

                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMCOMPRA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("NUMFACTURA").Value
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCOMPRA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("CODCOMPRA1").Value
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoPago.Text
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoPago.SelectedValue
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaPagar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("CUENTA").Value = cbxCuenta.Text
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODCUENTA").Value = cbxCuenta.SelectedValue
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("NUMDEVOLUCION").Value = NroDevolucion
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("CODNRODEV").Value = CodDevolucion
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                    CobroFormaPagoDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = "I"

                                    lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                                End If
                            Next
                        End If
                    Else
                        MessageBox.Show("El saldo de la Nota de Credito Nro :" & dgvNotaCredito.Rows(j).Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value & " se encuentra agotado", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Next

            lblSaldoFavor.Text = CDec(lblMontoSelecionado.Text) - CDec(lblPagado.Text)
            lblSaldoFavor.Text = FormatNumber(lblSaldoFavor.Text, 0)

            UltraPopupControlContainer2.Close()
            tbxMonto.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFechaPago_LostFocus(sender As Object, e As System.EventArgs) Handles dtpFechaPago.LostFocus
        dtpFechaPago.BackColor = Color.White
        dtpFechaPagoDet.Text = dtpFechaPago.Text
    End Sub

    Private Sub cbxPagador_LostFocus(sender As Object, e As System.EventArgs) Handles cbxPagador.LostFocus
        cbxPagador.BackColor = Color.White
    End Sub

    Private Sub tbxCotizacion_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCotizacion.GotFocus
        tbxCotizacion.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxCotizacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCotizacion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxPagador.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxCotizacion_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCotizacion.LostFocus
        tbxCotizacion.BackColor = Color.White
    End Sub

    Private Sub tbxMonto_GotFocus(sender As Object, e As System.EventArgs) Handles tbxMonto.GotFocus
        tbxMonto.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxMonto.KeyPress
        'Verificamos que tipo de Pago selecciono y de acuerdo a eso ponemos el foco
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Me.lbxTipoPago.Text = "Efectivo" Then
                cbxCuenta.Focus()
            ElseIf Me.lbxTipoPago.Text = "Cheque" Then
                cbxCuenta.Focus()
            ElseIf Me.lbxTipoPago.Text = "Nota de Credito" Then
                tbxNotadeCredito.Focus()
            ElseIf Me.lbxTipoPago.Text = "Tarjeta" Then
                cbxCuenta.Focus()
            ElseIf Me.lbxTipoPago.Text = "Transferencia" Then
                cbxCuenta.Focus()
            ElseIf Me.lbxTipoPago.Text = "Retencion" Then
                tbxNroRetencion.Focus()
            ElseIf Me.lbxTipoPago.Text = "Retencion Renta" Then
                lblNroRetRenta.Focus()
            ElseIf Me.lbxTipoPago.Text = "Ajuste de Pago" Then
                cbxCuenta.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxMonto_LostFocus(sender As Object, e As System.EventArgs) Handles tbxMonto.LostFocus
        tbxMonto.BackColor = Color.White
    End Sub

    Private Sub Fecha1_GotFocus(sender As Object, e As System.EventArgs) Handles dtpFechaPagoDet.GotFocus
        dtpFechaPagoDet.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub Fecha1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaPagoDet.KeyPress
        'Verificamos que tipo de Pago selecciono y de acuerdo a eso ponemos el foco
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPagos.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub Fecha1_LostFocus(sender As Object, e As System.EventArgs) Handles dtpFechaPagoDet.LostFocus
        dtpFechaPagoDet.BackColor = Color.White
    End Sub

    Private Sub tbxNroRef_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNroRef.GotFocus
        tbxNroRef.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxNroRef_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroRef.KeyPress
        'Verificamos que tipo de Pago selecciono y de acuerdo a eso ponemos el foco
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaPagoDet.Focus()
            KeyAscii = 0

        End If
    End Sub

    Private Sub tbxNroRef_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroRef.LostFocus
        Dim ExisteRef As Integer
        Dim w As New Funciones.Funciones

        If tbxNroRef.Text <> "" Then
            ExisteRef = w.FuncionConsultaString("CODPAGO", "COMPRASFORMAPAGO", "CH_NROCHEQUE", tbxNroRef.Text)

            If ExisteRef > 0 Then
                lblInfoRef.Visible = True
            Else
                lblInfoRef.Visible = False
            End If
        Else
            lblInfoRef.Visible = False
        End If
    End Sub

    Private Sub tbxConcepto_GotFocus(sender As Object, e As System.EventArgs) Handles tbxConcepto.GotFocus
        tbxConcepto.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxConcepto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxConcepto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPagos.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxConcepto_LostFocus(sender As Object, e As System.EventArgs) Handles tbxConcepto.LostFocus
        tbxConcepto.BackColor = Color.White
    End Sub

    Private Sub tbxNotadeCredito_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNotadeCredito.GotFocus
        tbxNotadeCredito.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxNotadeCredito_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNotadeCredito.LostFocus
        tbxNotadeCredito.BackColor = Color.White
    End Sub

    Private Sub tbxNroRetencion_GotFocus(sender As Object, e As System.EventArgs)
        tbxNroRetencion.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxNroRetencion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        'Verificamos que tipo de Pago selecciono y de acuerdo a eso ponemos el foco
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPagos.Focus()
            KeyAscii = 0
        End If

    End Sub

    Private Sub tbxNroRetencion_LostFocus(sender As Object, e As System.EventArgs)
        tbxNroRetencion.BackColor = Color.White
    End Sub

#End Region

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Dim site As String = "http://www.cogentpotential.com/soporte/compras/pagos"
        Shell("Explorer " & site)
    End Sub

    Private Sub cbxCuenta_GotFocus(sender As Object, e As System.EventArgs) Handles cbxCuenta.GotFocus
        cbxCuenta.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub cbxCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxCuenta.KeyPress
        'Verificamos que tipo de Pago selecciono y de acuerdo a eso ponemos el foco
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Me.lbxTipoPago.Text = "Ajuste de Pago" Then
                tbxConcepto.Focus()
            ElseIf Me.lbxTipoPago.Text = "Efectivo" Or Me.lbxTipoPago.Text = "Tarjeta" Then
                btnAgregarPagos.Focus()
            Else
                tbxNroRef.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxCuenta_LostFocus(sender As Object, e As System.EventArgs) Handles cbxCuenta.LostFocus
        cbxCuenta.BackColor = Color.White
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Me.CABECERAPAGOSTableAdapter.Fill(Me.DsPagosFacutas.CABECERAPAGOS, FechaFiltroDesde, FechaFiltroHasta)

        'Verificamos si la grilla de Cobros esta vacia que no permita editar
        If dgvPagos.RowCount = 0 Then
            ModificarDetPictureBox.Image = My.Resources.EditOff
            ModificarDetPictureBox.Enabled = False
            tsEditar.Enabled = False
        Else
            ModificarDetPictureBox.Image = My.Resources.Edit
            ModificarDetPictureBox.Enabled = True
            tsEditar.Enabled = True
        End If
        lblDGVCant.Text = "Cant. de Items:" & dgvPagos.RowCount
    End Sub

    Private Sub FechaFiltro()
        Try

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
            FechaFiltroDesde = fechacompleta1
            FechaFiltroHasta = fechacompleta2
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPagos_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvPagos.SelectionChanged
        btnAsterisco.Enabled = False

        Try
            If dgvPagos.RowCount > 0 Then
                If dgvPagos.CurrentRow.Cells("CABPAGO").Value Is DBNull.Value Then
                Else
                    VCabPago = dgvPagos.CurrentRow.Cells("CABPAGO").Value
                    Me.DETALLEPAGOTableAdapter.Fill(Me.DsPagosFacutas.DETALLEPAGO, VCabPago)
                End If




                Dim TotalImporte As Double = 0
                Dim FactRel As String = ""
                Dim varias As Boolean = False
                Dim contfact As Integer = 0
                Dim i As Integer


                For i = 0 To CobroFormaPagoDataGridView.RowCount - 1
                    If CobroFormaPagoDataGridView.Rows(i).Cells("DESTIPOPAGO").Value <> "Nota de Credito" Then
                        TotalImporte = TotalImporte + CobroFormaPagoDataGridView.Rows(i).Cells("IMPORTE").Value
                    End If
                    If i = 0 Then
                        FactRel = CobroFormaPagoDataGridView.Rows(i).Cells("NUMCOMPRA").Value
                    Else
                        If CobroFormaPagoDataGridView.Rows(i).Cells("NUMCOMPRA").Value <> FactRel Then
                            varias = True
                            contfact = contfact + 1
                        End If
                    End If
                Next

                If varias = True Then
                    lblNroFacturas.Text = contfact
                Else
                    lblNroFacturas.Text = FactRel
                End If

                umeTotalRec.Text = TotalImporte
                lblCuotas.Text = CobroFormaPagoDataGridView.RowCount

            Else
                Me.DETALLEPAGOTableAdapter.Fill(Me.DsPagosFacutas.DETALLEPAGO, 0)
                tbxMonto.Text = "" : lblMontoSelecionado.Text = "" : lblMontoTotalVencido.Text = "" : lblCuotas.Text = "" : lblNroFacturas.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        If Config8 = "RUC" Then
            tbxRucProveedor.BringToFront()
        Else
            tbxNroProv.BringToFront()
        End If
    End Sub

    Private Sub btnMostrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrarOBS.Click
        pnlObservacion.Visible = True : pnlObservacion.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        pnlObservacion.Visible = False
    End Sub

    Private Sub tbxRucProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxRucProveedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbProveedor.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxRucProveedor_LostFocus(sender As Object, e As System.EventArgs) Handles tbxRucProveedor.LostFocus
        Dim CodProveedor As Double
        tbxNroProv.Enabled = False
        tbxNroProv.Visible = False
        If Config8 = "RUC" Then
            If tbxRucProveedor.Text <> "" Then
                CodProveedor = f.FuncionConsulta("CODPROVEEDOR", "PROVEEDOR", "RUC_CIN", tbxRucProveedor.Text)
                Try
                    CmbProveedor.SelectedValue = CDec(CodProveedor)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub CmbProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CmbProveedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If lblDetalles.Text = "Esconder" Then
                dgvFacturasaPagar.Focus()
            Else
                dtpFechaPago.Focus()
                KeyAscii = 0
            End If
        End If
        If KeyAscii = 42 Then
            Me.PROVEEDORFILLPAGOTableAdapter.Fill(Me.DsPagosFacutas.PROVEEDORFILLPAGO)
            UltraPopupControlContainer1.PopupControl = GroupBoxProveedor
            UltraPopupControlContainer1.Show()

            TxtBuscaProveedor.Text = ""
            TxtBuscaProveedor.Focus()
            e.Handled = True
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtpFechaPago_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaPago.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbGenerarRecibo.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbGenerarRecibo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbGenerarRecibo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cmbGenerarRecibo.Text = "Automático" Then
                cbxMoneda.Focus()
            Else
                NroReciboTextBox.Focus()
            End If

            KeyAscii = 0
        End If
    End Sub

    Private Sub NroReciboTextBox_KeyPress1(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles NroReciboTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxNroSerie.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxNroSerie_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroSerie.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxMoneda.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cbxMoneda.SelectedIndexChanged
        Dim SimboloEfectivo As String
        If cbxMoneda.SelectedValue <> Nothing Then
            tbxCotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(cbxMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")

            SimboloEfectivo = f.FuncionConsultaString("SIMBOLO", "MONEDA", "CODMONEDA", cbxMoneda.SelectedValue)
            Me.COTIZACIONTableAdapter.Fill(DsPagosFacutas.COTIZACION, cbxMoneda.SelectedValue)
            If SimboloEfectivo = "0" Then
                lblSimbolo.Text = "Gs"
            Else
                lblSimbolo.Text = SimboloEfectivo
            End If
        End If
    End Sub

    Private Sub chbxCotizacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbxCotizacion.CheckedChanged
        If chbxCotizacion.Checked = True Then
            tbxCotizacion.Enabled = True
            tbxCotizacion.Text = ""
            tbxCotizacion.Focus()

        Else
            tbxCotizacion.Text = ""
            Me.COTIZACIONTableAdapter.Fill(DsPagosFacutas.COTIZACION, cbxMoneda.SelectedValue)
            If cbxMoneda.SelectedValue <> Nothing Then
                tbxCotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(cbxMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
            End If
            tbxCotizacion.Enabled = False
        End If
    End Sub

    Private Sub cmbGenerarRecibo_TextChanged(sender As Object, e As System.EventArgs) Handles cmbGenerarRecibo.TextChanged
        If btnuevo = 1 Or btmodificar = 1 Then
            If cmbGenerarRecibo.Text = "Automático" Then
                'Recuperamos el Ultimo Numero de Recibo para Cobros
                'POR AHORA COMO EN LA VENTANA COBROS NO SE SELECCIONA UN TIPO ESPECIFICO DE COMPROBANTE DE COBRO (SI HUBIERA + DE UNO), SE CONSIDERA QUE SOLO EXISTE UNO Y PREGUNTA  "WHERE COBRO=1"
                NroRango = f.FuncionConsultaString("DETPC.ULTIMO", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND ACTIVO = 1 AND PAGOS", 1)

                If NroRango = 0 Or String.IsNullOrEmpty(NroRango) = True Then
                    MessageBox.Show("Comprobante no tiene mas Rango, cierre esta ventana y cargue lo en (Dashboard >> Configuración >> 'Rangos de Comprobantes') o bien, cargue el Nro. Recibo Manualmente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    NroRango = NroRango + 1
                    NroReciboTextBox.Text = NroRango
                End If
                Me.NroReciboTextBox.Enabled = False
            Else
                Me.NroReciboTextBox.Enabled = True
            End If
        End If
    End Sub

    Private Sub GenerarNroRetencion()
        Dim sql As String
        Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString, NumRetencion As String
        Dim NroDigitos As Integer

        If btnuevo = 1 Or btmodificar = 1 Then
            NroRetencion = f.FuncionConsultaString("DETPC.ULTIMO", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND (ACTIVO = 1) AND (RETENCION = 1) AND dbo.DETPC.IP", CodigoMaquina)

            If NroRetencion = 0 Or String.IsNullOrEmpty(NroRetencion) = True Then
                MessageBox.Show("Comprobante no tiene mas Rango, cierre esta ventana y cargue lo en (Dashboard >> Configuración >> 'Rangos de Comprobantes') o bien, cargue el Nro. Recibo Manualmente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                Dim conexion As System.Data.SqlClient.SqlConnection
                conexion = ser.Abrir()

                Try
                    NumSucursal = SucCodigo
                    NumMaquina = NumMaquinaGlobal
                    NroDigitos = f.FuncionConsultaDecimal("DETPC.NRODIGITOS", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND ACTIVO = 1 AND RETENCION", 1)

                    Dim CodigoMaq As Integer
                    If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
                        CodigoMaq = CodigoMaquina
                    Else
                        CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
                    End If

                    sql = "SELECT dbo.DETPC.RANDOID, dbo.DETPC.CODSUCURSAL, dbo.DETPC.IP, dbo.DETPC.ULTIMO, dbo.DETPC.RANGO2, dbo.TIPOCOMPROBANTE.RETENCION FROM dbo.DETPC INNER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE WHERE (dbo.DETPC.ULTIMO < dbo.DETPC.RANGO2) AND (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.RETENCION = 1) " & _
                         "AND DETPC.IP = " & CodigoMaq

                    Dim dadetpc As New SqlDataAdapter(sql, conexion)
                    Dim dtdetpc As New DataTable
                    dadetpc.Fill(dtdetpc)
                    Dim drdetpc As DataRow
                    drdetpc = dtdetpc.Rows(0)

                    'Validamos que haya rango para ese TipoComprobante
                    NroRetencion = drdetpc("ULTIMO")
                    NroRetencion = NroRetencion + 1

                    RangoIDRetencion = drdetpc("RANDOID")
                    NroRango2 = drdetpc("RANGO2")

                    If CDec(NroRango) > CDec(NroRango2) Then
                        NumRetencion = ""
                        Exit Sub
                    End If

                    Dim codsuc As Integer = drdetpc("CODSUCURSAL")
                    NumSucTimbrado = f.FuncionConsultaString("SUCURSALTIMBRADO", "SUCURSAL", "CODSUCURSAL", codsuc)

                    Dim IPMAQ As Integer = drdetpc("IP")
                    NumMaquina = f.FuncionConsultaString("NUMMAQUINA", "PC", "IP", IPMAQ)

                    NroRangoString = CStr(NroRetencion)
                    For i = 1 To NroDigitos
                        If Len(NroRangoString) = NroDigitos Then
                            Exit For
                        Else
                            NroRangoString = "0" & NroRangoString
                        End If
                    Next

                    NumRetencion = NumSucTimbrado & "." & NumMaquina & "." & NroRangoString

                    If lbxTipoPago.SelectedValue = 6 Then 'IVA
                        Me.tbxNroRetencion.Text = NumRetencion
                    Else
                        Me.lblNroRetRenta.Text = NumRetencion
                    End If


                    If NumRetencion = "" Then
                        MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Catch ex As Exception
                Finally
                    conexion.Close()
                End Try
            End If
        End If
    End Sub
    'Private Sub GenerarNroRetencionRenta()
    '    Dim sql As String
    '    Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString, NumRetencionRenta As String
    '    Dim NroDigitos As Integer

    '    If btnuevo = 1 Or btmodificar = 1 Then
    '        NroRetencionRenta = f.FuncionConsultaString("DETPC.ULTIMO", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND (ACTIVO = 1) AND (RETENCIONRENTA = 1) AND dbo.DETPC.IP", CodigoMaquina)

    '        If NroRetencionRenta = 0 Or String.IsNullOrEmpty(NroRetencionRenta) = True Then
    '            MessageBox.Show("Comprobante no tiene mas Rango, cierre esta ventana y cargue lo en (Dashboard >> Configuración >> 'Rangos de Comprobantes') o bien, cargue el Nro. Recibo Manualmente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        Else
    '            Dim conexion As System.Data.SqlClient.SqlConnection
    '            conexion = ser.Abrir()

    '            Try
    '                NumSucursal = SucCodigo
    '                NumMaquina = NumMaquinaGlobal
    '                'NroDigitos = f.FuncionConsultaDecimal("DETPC.NRODIGITOS", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND ACTIVO = 1 AND RETENCIONRENTA", 1)

    '                Dim CodigoMaq As Integer
    '                If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
    '                    CodigoMaq = CodigoMaquina
    '                Else
    '                    CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
    '                End If

    '                sql = "SELECT dbo.DETPC.NRODIGITOS, dbo.DETPC.RANDOID, dbo.DETPC.CODSUCURSAL, dbo.DETPC.IP, dbo.DETPC.ULTIMO, dbo.DETPC.RANGO2, dbo.TIPOCOMPROBANTE.RETENCION FROM dbo.DETPC INNER JOIN " & _
    '                     "dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE WHERE (dbo.DETPC.ULTIMO < dbo.DETPC.RANGO2) AND (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.RETENCIONRENTA = 1) " & _
    '                     "AND DETPC.IP = " & CodigoMaq

    '                Dim dadetpc As New SqlDataAdapter(sql, conexion)
    '                Dim dtdetpc As New DataTable
    '                dadetpc.Fill(dtdetpc)
    '                Dim drdetpc As DataRow
    '                drdetpc = dtdetpc.Rows(0)

    '                NroDigitos = drdetpc("NRODIGITOS")
    '                'Validamos que haya rango para ese TipoComprobante
    '                NroRetencionRenta = drdetpc("ULTIMO")
    '                NroRetencionRenta = NroRetencionRenta + 1

    '                RangoIDRetencionRenta = drdetpc("RANDOID")
    '                NroRango2 = drdetpc("RANGO2")

    '                If CDec(NroRango) > CDec(NroRango2) Then
    '                    NumRetencionRenta = ""
    '                    Exit Sub
    '                End If

    '                Dim codsuc As Integer = drdetpc("CODSUCURSAL")
    '                NumSucTimbrado = f.FuncionConsultaString("SUCURSALTIMBRADO", "SUCURSAL", "CODSUCURSAL", codsuc)

    '                Dim IPMAQ As Integer = drdetpc("IP")
    '                NumMaquina = f.FuncionConsultaString("NUMMAQUINA", "PC", "IP", IPMAQ)

    '                NroRangoString = CStr(NroRetencionRenta)
    '                For i = 1 To NroDigitos
    '                    If Len(NroRangoString) = NroDigitos Then
    '                        Exit For
    '                    Else
    '                        NroRangoString = "0" & NroRangoString
    '                    End If
    '                Next

    '                NumRetencionRenta = NumSucTimbrado & "." & NumMaquina & "." & NroRangoString
    '                Me.lblNroRetRenta.Text = NumRetencionRenta

    '                If NumRetencionRenta = "" Then
    '                    MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Exit Sub
    '                End If
    '            Catch ex As Exception
    '            Finally
    '                conexion.Close()
    '            End Try
    '        End If
    '    End If
    'End Sub

    Private Sub btnAsterisco_Click(sender As System.Object, e As System.EventArgs) Handles btnAsterisco.Click
        Me.PROVEEDORFILLPAGOTableAdapter.Fill(Me.DsPagosFacutas.PROVEEDORFILLPAGO)
        UltraPopupControlContainer1.PopupControl = GroupBoxProveedor
        UltraPopupControlContainer1.Show()

        TxtBuscaProveedor.Text = ""
        TxtBuscaProveedor.Focus()
    End Sub

    Private Sub dgwProveedores_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwProveedores.CellDoubleClick
        'LIMPIAMOS DEL ANTERIOR
        If IsDBNull(dgwProveedores.CurrentRow.Cells("CODPROVEEDORDataGridViewTextBoxColumn").Value) Then
        Else
            CmbProveedor.SelectedValue = CDec(dgwProveedores.CurrentRow.Cells("CODPROVEEDORDataGridViewTextBoxColumn").Value)
            tbxRucProveedor.Text = dgwProveedores.CurrentRow.Cells("RUCCINDataGridViewTextBoxColumn2").Value
        End If

        Me.dtpFechaPago.Focus()
        UltraPopupControlContainer1.Close()
    End Sub



    Private Sub TxtBuscaProveedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscaProveedor.TextChanged
        Me.PROVEEDORFILLPAGOBindingSource.Filter = "RUC_CIN LIKE '%" & TxtBuscaProveedor.Text & "%' OR NOMBRE LIKE '%" & TxtBuscaProveedor.Text & "%'"

    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1, CONFIG2, CONFIG3, CONFIG4, CONFIG5, CONFIG6, CONFIG7, CONFIG8 FROM MODULO WHERE MODULO_ID = 4"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    Config1 = odrConfig("CONFIG1")
                    Config2 = odrConfig("CONFIG2")
                    Config3 = odrConfig("CONFIG3")
                    Config4 = odrConfig("CONFIG4")
                    Config5 = odrConfig("CONFIG5")
                    Config6 = odrConfig("CONFIG6")
                    Config7 = odrConfig("CONFIG7")
                    Config8 = odrConfig("CONFIG8")

                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ModificarDetPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarDetPictureBox.Click
        ContNewFilasEdit = 0
        btmodificar = 1

        PagosActivo.Image = My.Resources.PaymentActive
        FiltroPagosActivo.Image = My.Resources.User
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        ModificarDetPictureBox.Image = My.Resources.EditActive
        PendientesPago.Image = My.Resources.Create

        HabilitarControles()

        CobroFormaPagoDataGridView.Enabled = True
        pnlDetallePago.Enabled = True
        pnlDatosdelPago.Enabled = True
        CmbProveedor.Enabled = False
        tbxRucProveedor.Enabled = False
        btnAsterisco.Enabled = False
        tbxNroProv.Enabled = False

        lblPagado.Text = tbxMonto.Text

        dgvPagos.Enabled = False
        BtnFiltro.Enabled = False
        BuscarTextBox.Enabled = False
        FiltroPagosActivo.Enabled = False
        TipoCobroPictureBox.Enabled = False
        PendientesPago.Enabled = False

        tbxMonto.Text = ""
    End Sub
    Public Sub tbxNumCliPend_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNumCliPend.LostFocus
        Dim codcli As Double
        codcli = f.FuncionConsulta("CODPROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", tbxNumCliPend.Text)
        Try
            cmbCliPend.SelectedValue = CDec(codcli)
        Catch ex As Exception
        End Try


    End Sub

    Public Sub tbxNroFacturaPend_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroFacturaPend.LostFocus
        FACTURASPAGARPENDIENTESTableAdapter.Fill(DsPagosFacutas.FACTURASPAGARPENDIENTES)
        FacturasPagarPendientesBindingSource.Filter = " NUMCOMPRA LIKE '%" & tbxNroFacturaPend.Text & "%'"
        Dim codcli As String = ""
        If dgvPendientes.RowCount > 0 Then
            If tbxNroFacturaPend.Text = "" Then
                CmbProveedor.Text = ""
                cmbCliPend.SelectedIndex = -1
            Else
                If dgvPendientes.RowCount = 1 Then
                    codcli = dgvPendientes.CurrentRow.Cells("CODPROVEEDORP").Value
                    Try
                        cmbCliPend.SelectedValue = CDec(codcli)
                    Catch ex As Exception
                    End Try
                Else
                    CmbProveedor.Text = ""
                    cmbCliPend.SelectedIndex = -1
                End If
            End If
        Else
            CmbProveedor.Text = ""
            cmbCliPend.SelectedIndex = -1
        End If
    End Sub
    Private Sub tbxNroFacturaPend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroFacturaPend.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgvPendientes.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxNumCliPend_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxNumCliPend.TextChanged
        tbxNumCliPend.Text = Funciones.Cadenas.SoloAlfaNumerico(tbxNumCliPend.Text)
    End Sub

    Private Sub tbxNumCliPend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNumCliPend.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbCliPend.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbCliPend_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCliPend.KeyPress
        Try
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If KeyAscii = 13 Then
                FacturasPagarPendientesBindingSource.RemoveFilter()
                btnFiltrarFechasP_Click(Nothing, Nothing)
                dgvPendientes.Select()
                'tbxFechaPend1.Focus()
                KeyAscii = 0
            End If
            If KeyAscii = 42 Then
                Me.PROVEEDORFILLPAGOTableAdapter.Fill(Me.DsPagosFacutas.PROVEEDORFILLPAGO)
                UltraPopupControlContainer1.PopupControl = GroupBoxClientesPendientes
                UltraPopupControlContainer1.Show()
                txtBuscaClientePend.Text = ""
                txtBuscaClientePend.Focus()
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCliPend_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliPend.SelectedIndexChanged
        If cmbCliPend.SelectedValue = Nothing Then
            tbxNumCliPend.Text = ""
        Else
            tbxNumCliPend.Text = f.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", cmbCliPend.SelectedValue)
            If tbxNumCliPend.Text = Nothing Then
                tbxNumCliPend.Text = ""
            End If
        End If
    End Sub

    Private Sub PendientesPago_Click(sender As System.Object, e As System.EventArgs) Handles PendientesPago.Click
        MenuCobros.Enabled = False
        If panelactivo = "SplitPagos" Then
            BuscarTextBox.Visible = False
            NuevoPictureBox.Visible = False
            EliminarPictureBox.Visible = False
            ModificarDetPictureBox.Visible = False
            CancelarPictureBox.Visible = False
            ConfirmarPictureBox.Visible = False
        End If
        PictureBox2.Visible = False
        BuscarTextBox.Visible = False

        panelactivo = "Pendientes"

        PanelTodosPendientes.BringToFront()

        PagosActivo.Image = My.Resources.Payment
        PagosActivo.Cursor = Cursors.Arrow
        FiltroPagosActivo.Image = My.Resources.User
        FiltroPagosActivo.Cursor = Cursors.Hand
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        TipoCobroPictureBox.Cursor = Cursors.Hand
        PendientesPago.Image = My.Resources.CreateActive
        PendientesPago.Cursor = Cursors.Hand
    End Sub

    Private Sub tbxFechaPend1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxFechaPend1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            tbxFechaPend2.Focus()
        End If
    End Sub

    Private Sub tbxFechaPend1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxFechaPend1.LostFocus
        If tbxFechaPend1.Text = "" Then
            tbxFechaPend1.Text = "  /  /    "
        End If
    End Sub

    Private Sub tbxFechaPend1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxFechaPend1.GotFocus
        If tbxFechaPend1.Text = "  /  /    " Then
            tbxFechaPend1.Text = ""
        End If
    End Sub

    Private Sub tbxFechaPend2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxFechaPend2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            btnFiltrarFechasP.Focus()
        End If
    End Sub
    Private Sub tbxFechaPend2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxFechaPend2.LostFocus
        If tbxFechaPend2.Text = "" Then
            tbxFechaPend2.Text = "  /  /    "
        End If
    End Sub

    Private Sub tbxFechaPend2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxFechaPend2.GotFocus
        If tbxFechaPend2.Text = "  /  /    " Then
            tbxFechaPend2.Text = ""
        End If
    End Sub

    Private Sub btnLimpiarFechasP_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFechasP.Click
        tbxFechaPend1.Text = "  /  /    " : tbxFechaPend2.Text = "  /  /    "
        tbxNumCliPend.Text = ""
        cmbCliPend.Text = ""
        Me.FACTURASPAGARPENDIENTESTableAdapter.Fill(DsPagosFacutas.FACTURASPAGARPENDIENTES)
    End Sub
    Private Sub btnFiltrarFechasP_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrarFechasP.Click
        Try
            Dim vtoDesde, vtoHasta As String

            If (tbxFechaPend1.Text = "  /  /    ") And (tbxFechaPend2.Text = "  /  /    ") Then
                vtoDesde = "01/01/1900 00:00:00.000"
                vtoHasta = "31/12/2999 23:59:59.900"
            Else
                vtoDesde = Trim(tbxFechaPend1.Text) + " 00:00:00.000"
                vtoHasta = Trim(tbxFechaPend2.Text) + " 23:59:59.900"
            End If

            If cmbCliPend.Text = "" Then
                Me.FACTURASPAGARPENDIENTESTableAdapter.FillByFecha(DsPagosFacutas.FACTURASPAGARPENDIENTES, vtoDesde, vtoHasta)
            Else
                Me.FACTURASPAGARPENDIENTESTableAdapter.FillByProvFecha(DsPagosFacutas.FACTURASPAGARPENDIENTES, vtoDesde, vtoHasta, cmbCliPend.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAsteriscoPend_Click(sender As System.Object, e As System.EventArgs) Handles btnAsteriscoPend.Click
        Me.PROVEEDORFILLPAGOTableAdapter.Fill(DsPagosFacutas.PROVEEDORFILLPAGO)
        UltraPopupControlContainer1.PopupControl = GroupBoxClientesPendientes
        UltraPopupControlContainer1.Show()
        txtBuscaClientePend.Text = ""
        txtBuscaClientePend.Focus()
    End Sub

    Private Sub btnCobrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCobrar.Click
        Dim i As Integer
        Dim seleccionados(0) As Integer
        Dim seleccionados2(0) As Integer
        Dim vectorcount As Integer = 0

        If dgvPendientes.RowCount <> 0 Then
            For i = 0 To dgvPendientes.SelectedRows.Count - 1
                If dgvPendientes.SelectedRows.Item(i).Cells("CODPROVEEDORP").Value = dgvPendientes.SelectedRows.Item(0).Cells("CODPROVEEDORP").Value Then 'Si seleccina filas de mas de 1 cliente, solo considera el primer cliente
                    seleccionados(i) = dgvPendientes.SelectedRows.Item(i).Cells("CODCOMPRAP").Value
                    seleccionados2(i) = dgvPendientes.SelectedRows.Item(i).Cells("NUMEROCUOTAP").Value
                    vectorcount = vectorcount + 1
                    ReDim Preserve seleccionados(vectorcount)
                    ReDim Preserve seleccionados2(vectorcount)
                End If
            Next

            panelactivo = "splitPagos"
            NuevoPictureBox_Click(Nothing, Nothing)

            CmbProveedor.SelectedValue = dgvPendientes.SelectedRows.Item(0).Cells("CODPROVEEDORP").Value
            For i = 0 To dgvFacturasaPagar.Rows.Count - 1
                Dim i2 As Integer
                For i2 = 0 To vectorcount - 1
                    If dgvFacturasaPagar.Rows(i).Cells("CODCOMPRA1").Value = seleccionados(i2) And dgvFacturasaPagar.Rows(i).Cells("NUMEROCUOTA").Value = seleccionados2(i2) Then
                        dgvFacturasaPagar.Rows(i).Cells("Pagar").Value = True
                    End If
                Next
            Next

            dgvFacturasaPagar_CellContentClick(Nothing, Nothing)
            btnDetalles_Click(Nothing, Nothing)
            SplitPagos.BringToFront()
            tbxMonto.Focus()

            cbxMoneda.SelectedValue = f.FuncionConsultaDecimal("CODMONEDA", "COMPRAS", "CODCOMPRA", dgvPendientes.CurrentRow.Cells("CODCOMPRAP").Value)

            PagosActivo.Image = My.Resources.PaymentActive
            PagosActivo.Cursor = Cursors.Arrow
            FiltroPagosActivo.Image = My.Resources.User
            FiltroPagosActivo.Cursor = Cursors.Hand
            TipoCobroPictureBox.Image = My.Resources.Cuenta
            TipoCobroPictureBox.Cursor = Cursors.Hand
            PendientesPago.Image = My.Resources.Create
            PendientesPago.Cursor = Cursors.Hand

            dgvPagos.Enabled = True : BtnFiltro.Enabled = True : BuscarTextBox.Enabled = True
            BuscarTextBox.Visible = True : NuevoPictureBox.Visible = True : PictureBox2.Visible = True : EliminarPictureBox.Visible = True
            ModificarDetPictureBox.Visible = True : CancelarPictureBox.Visible = True : ConfirmarPictureBox.Visible = True
        End If
    End Sub
    Private Sub txtBuscaClientePend_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscaClientePend.TextChanged
        If txtBuscaClientePend.Text = "" Then
            Me.ProveedorPendientesBindingSource.Filter = "NOMBRE LIKE '%" & txtBuscaClientePend.Text & "%' OR RUC_CIN LIKE '%" & txtBuscaClientePend.Text & "%'"
        Else
            If txtBuscaClientePend.Text <> "Buscar..." Then
                If Not System.Text.RegularExpressions.Regex.IsMatch(txtBuscaClientePend.Text, "^\d*$") Then ' Si introduce letras
                    Me.ProveedorPendientesBindingSource.Filter = "NOMBRE LIKE '%" & txtBuscaClientePend.Text & "%' OR RUC_CIN LIKE '%" & txtBuscaClientePend.Text & "%'"
                Else
                    Me.ProveedorPendientesBindingSource.Filter = "NUMPROVEEDOR =" & txtBuscaClientePend.Text
                    If GridViewClientesPend.RowCount = 0 Then
                        Me.ProveedorPendientesBindingSource.Filter = "NOMBRE LIKE '%" & txtBuscaClientePend.Text & "%' OR RUC_CIN LIKE '%" & txtBuscaClientePend.Text & "%'"
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtBuscaClientePend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscaClientePend.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            GridViewClientesPend.Focus()
        End If
    End Sub
    Private Sub GridViewClientesPend_DoubleClick(sender As Object, e As System.EventArgs) Handles GridViewClientesPend.DoubleClick
        UltraPopupControlContainer1.Close()
        Me.cmbCliPend.Focus()
    End Sub

    Private Sub GridViewClientesPend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridViewClientesPend.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If GridViewClientesPend.RowCount = 0 Then
                cmbCliPend.Focus()
                UltraPopupControlContainer1.Close()
            Else

                If IsDBNull(GridViewClientesPend.CurrentRow) Then
                    cmbCliPend.Focus()
                    UltraPopupControlContainer1.Close()

                Else
                    'LIMPIAMOS DEL ANTERIOR
                    If IsDBNull(GridViewClientesPend.CurrentRow.Cells("CODPROVEEDORB").Value) Then
                    Else
                        cmbCliPend.SelectedValue = CDec(GridViewClientesPend.CurrentRow.Cells("CODPROVEEDORB").Value)
                        tbxNumCliPend.Text = GridViewClientesPend.CurrentRow.Cells("NUMPROVEEDOR").Value
                    End If

                    Me.cmbCliPend.Focus()
                    UltraPopupControlContainer1.Close()

                End If
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Me.FACTURASPAGARPENDIENTESTableAdapter.Fill(Me.DsPagosFacutas.FACTURASPAGARPENDIENTES)

        btnFiltrarFechasP_Click(Nothing, Nothing)

        If tbxNumCliPend.Text = "" Then
            tbxNumCliPend.Focus()
        Else
            dgvPendientes.Select()
        End If
    End Sub

    Private Sub tsNuevaVenta_Click(sender As System.Object, e As System.EventArgs) Handles tsNuevaVenta.Click
        NuevoPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsEditar.Click
        ModificarDetPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsGuardar.Click
        ConfirmarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsEliminar_Click(sender As System.Object, e As System.EventArgs) Handles tsEliminar.Click
        EliminarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsCancelar_Click(sender As System.Object, e As System.EventArgs) Handles tsCancelar.Click
        CancelarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAyudaOnline_Click(sender As System.Object, e As System.EventArgs) Handles tsAyudaOnline.Click
        Dim soporte As String = "http://www.cogentpotential.com/soporte/pagos"
        Shell("Explorer " & soporte)
    End Sub

    Private Sub tsPanelDeCreditos_Click(sender As System.Object, e As System.EventArgs) Handles tsPanelDeCreditos.Click
        btnDetalles_Click(Nothing, Nothing)
    End Sub

    Private Sub tsCampoDeObservacion_Click_(sender As System.Object, e As System.EventArgs) Handles tsCampoDeObservacion.Click
        pnlObservacion.Visible = True
        pnlObservacion.BringToFront()
    End Sub

    Private Sub tsPersonalizarVentas_Click(sender As System.Object, e As System.EventArgs) Handles tsPersonalizarVentas.Click
        ABMConfigPosExpress.Show()
        ABMConfigPosExpress.abrirdesde("Pagos")
    End Sub

    Private Sub lblProximoNro_Click(sender As System.Object, e As System.EventArgs) Handles lblProximoNro.Click
        Dim CodCobroMax As Integer
        Dim MaxNroRecibo As Integer = 0

        'Obtiene el ultimo nro cargado
        CodCobroMax = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
        MaxNroRecibo = f.FuncionConsultaString("NRORECIBO", "COMPRASFORMAPAGO", "CODPAGO", CodCobroMax)
        MaxNroRecibo = MaxNroRecibo + 1

        MessageBox.Show("Próximo Nro de Recibo: " & MaxNroRecibo & "", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsQuemarProxNro_Click(sender As System.Object, e As System.EventArgs) Handles tsQuemarProxNro.Click
        Permiso = PermisoAplicado(UsuCodigo, 212) 'Crear una Factura en Blanco
        If Permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else

            Dim RangoID As Integer
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                'Verificar si el Comprobante está Activo
                RangoID = f.FuncionConsulta("ACTIVO", "DETPC", _
                                            "RANDOID", _
                                           IDRangoRecibos)

                If RangoID = 0 Or String.IsNullOrEmpty(RangoID) = True Then
                    MessageBox.Show("No hay comprobantes activos para esta máquina o No tiene asignado un Nro. de Comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'BtnImprimir.Image = My.Resources.Approve
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                Dim CabPago As Integer
                Dim MaxNroRecibo As Integer = 0
                Dim CodCobro As String

                'se debe obtener el ultimo nro insertado
                CabPago = f.Maximo("CABPAGO", "COMPRASFORMAPAGO")
                CabPago = CabPago + 1
                CabPagoMax = CabPago


                CodCobro = f.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                'Obtiene el ultimo nro cargado
                MaxNroRecibo = f.FuncionConsultaString("NRORECIBO", "COMPRASFORMAPAGO", "CODPAGO", CodCobro)
                MaxNroRecibo = MaxNroRecibo + 1

                CodCobro = CodCobro + 1

                'Inserta SI O SI CON FECHA DE HOY
                sql = "INSERT INTO COMPRASFORMAPAGO (CODPAGO, NRORECIBO, CABPAGO, FECHAREGISTROPAG) " & _
                  "VALUES (" & CodCobro & ",'" & MaxNroRecibo & "', " & CabPagoMax & ", GetDate())"

                sql = sql + " UPDATE DETPC SET ULTIMO =" & MaxNroRecibo & " WHERE RANDOID =" & IDRangoRecibos
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans.Commit()
                Try
                    AUDITORIAINSERTACOBRO()
                Catch ex As Exception
                End Try

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MsgBox(mensajeerror)
                Throw
            End Try


            '---------------------------- DESACTIVA RANGO ----------------------------
            'Verificamos si es el ultimo Nro del rango de comprobantes y ponemos como desabilitado dicho rango

            Dim hastanro, ultimo As Integer

            ultimo = f.FuncionConsulta("ULTIMO", "DETPC", "ACTIVO = 1 AND RANDOID", IDRangoRecibos)

            hastanro = f.FuncionConsulta("RANGO2", "DETPC", "ACTIVO = 1 AND RANDOID", IDRangoRecibos)


            If hastanro = ultimo Then
                'conexion = ser.Abrir()

                Try

                    sql = "UPDATE DETPC SET ACTIVO=0 WHERE RANDOID =" & IDRangoRecibos & ""
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    myTrans.Commit()
                Catch ex As Exception

                End Try
            End If
            sqlc.Close()
            FechaFiltro()
            CABECERAPAGOSTableAdapter.Fill(DsPagosFacutas.CABECERAPAGOS, FechaFiltroDesde, FechaFiltroHasta)
            Me.Cursor = Cursors.Arrow
        End If
    End Sub
    Private Sub tsAplicarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles tsAplicarFiltros.Click
        Dim fechaDesdeEspecial As String
        Dim fechaHastaEspecial As String
        CmbAño.Text = ""
        CmbMes.Text = "Filtros"
        If errorFiltroFecha = 0 And errorFiltroRango = 0 And Trim(tsFiltroFechaE.Text) <> "" And (Trim(tsFiltroRDesde.Text) <> "" Or Trim(tsFiltroRHasta.Text) <> "") Then
            MsgBox("Se introdujeron filtros en Fecha Específica y Rango de Fechas. El Sistema toma por defecto la Fecha Específica", MsgBoxStyle.Information, "Error en Filtro")
        ElseIf Trim(tsFiltroNroCliente.Text) <> "" And Trim(tsFiltroNomCliente.Text) <> "" Then
            MsgBox("Se introdujeron filtros en Nro. de Cliente y Nombre de Cliente. El Sistema toma por defecto el Nro. de Cliente", MsgBoxStyle.Information, "Error en Filtro")
        End If
        If Trim(tsFiltroFechaE.Text) <> "" Then
            If errorFiltroFecha = 0 Then
                fechaDesdeEspecial = tsFiltroFechaE.Text + " 00:00:00"
                fechaHastaEspecial = tsFiltroFechaE.Text + " 23:59:00"
            Else
                GoTo todasfechas
            End If
        Else
            If Trim(tsFiltroRDesde.Text) <> "" And Trim(tsFiltroRHasta.Text) <> "" And errorFiltroRango = 0 Then
                If errorFiltroRango = 0 Then
                    fechaDesdeEspecial = tsFiltroRDesde.Text + " 00:00:00"
                    fechaHastaEspecial = tsFiltroRHasta.Text + " 23:59:00"
                Else
                    GoTo todasfechas
                End If
            ElseIf Trim(tsFiltroRDesde.Text) <> "" Or Trim(tsFiltroRHasta.Text) <> "" Then
                MsgBox("Falta Especificar una Fecha del Rango", MsgBoxStyle.Information, "Error en Filtro")
                Exit Sub
            Else
todasfechas:
                fechaDesdeEspecial = "01/01/1900 00:00:00"
                fechaHastaEspecial = "31/12/2900 23:59:00"
            End If
        End If

        CABECERAPAGOSTableAdapter.Fill(DsPagosFacutas.CABECERAPAGOS, fechaDesdeEspecial, fechaHastaEspecial)


        If Trim(tsFiltroNroCliente.Text) <> "" Then
            CABECERAPAGOSBindingSource.Filter = "NUMPROVEEDOR = " & Trim(tsFiltroNroCliente.Text)
        Else
            If Trim(tsFiltroNomCliente.Text) <> "" Then
                CABECERAPAGOSBindingSource.Filter = "NOMBRE like '%" & Trim(tsFiltroNomCliente.Text) & "%'"
            End If
        End If
        lblDGVCant.Text = "Cant. de Items:" & dgvPagos.RowCount
    End Sub

    Private Sub tsLimpiarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles tsLimpiarFiltros.Click
        tsFiltroFechaE.Text = "" : tsFiltroFechaE.BackColor = SystemColors.Window
        tsFiltroRDesde.Text = "" : tsFiltroRDesde.BackColor = SystemColors.Window
        tsFiltroRHasta.Text = "" : tsFiltroRHasta.BackColor = SystemColors.Window
        tsFiltroNroCliente.Text = ""
        tsFiltroNomCliente.Text = ""
        InicializaFechaFiltro()
        If CmbMes.Text = "Filtros" Then
            CmbMes.SelectedIndex = Today.Month - 1
        End If
        If CmbAño.Text = "" Then
            CmbAño.SelectedText = Today.Year.ToString
        End If
        BtnFiltro_Click(Nothing, Nothing)
    End Sub

    Private Sub tsFiltroNroCliente_TextChanged(sender As Object, e As System.EventArgs) Handles tsFiltroNroCliente.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(tsFiltroNroCliente.Text, "^\d*$") Then
            tsFiltroNroCliente.Text = tsFiltroNroCliente.Text.Remove(tsFiltroNroCliente.Text.Length - 1)
            tsFiltroNroCliente.SelectionStart = tsFiltroNroCliente.Text.Length
        End If
    End Sub

    Private Sub tsFiltroFechaE_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroFechaE.LostFocus
        If Trim(tsFiltroFechaE.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroFechaE.Text)
                errorFiltroFecha = 0
                tsFiltroFechaE.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroFecha = 1
                MsgBox("El Sistema no tomará el Filtro Fecha Específica. Por Favor Ingrese una Fecha válida", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroFechaE.BackColor = Color.Pink
                'tsFiltroFechaE.Focus() no funciona
            End Try
        ElseIf errorFiltroFecha = 1 Then
            errorFiltroFecha = 0
            tsFiltroFechaE.BackColor = SystemColors.Window
        End If
    End Sub
    Private Sub tsFiltroRDesde_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroRDesde.LostFocus
        If Trim(tsFiltroRDesde.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroRDesde.Text)
                errorFiltroRango = 0
                tsFiltroRDesde.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroRango = 1
                MsgBox("El Sistema no tomará el Filtro Rango de Fechas. Por Favor Ingrese una Fecha válida en Fecha Desde", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroRDesde.BackColor = Color.Pink
            End Try
        ElseIf errorFiltroRango = 1 Then
            errorFiltroRango = 0
            tsFiltroRDesde.BackColor = SystemColors.Window
        End If
    End Sub
    Private Sub tsFiltroRHasta_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroRHasta.LostFocus
        If Trim(tsFiltroRHasta.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroRHasta.Text)
                errorFiltroRango = 0
                tsFiltroRHasta.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroRango = 1
                MsgBox("El Sistema no tomará el Filtro Rango de Fechas. Por Favor Ingrese una Fecha válida en Fecha Hasta", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroRHasta.BackColor = Color.Pink
            End Try
        ElseIf errorFiltroRango = 1 Then
            errorFiltroRango = 0
            tsFiltroRHasta.BackColor = SystemColors.Window
        End If
    End Sub


    Private Sub rbCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbCliente.CheckedChanged
        If rbCliente.Checked = True Then
            rlblCliFac.Text = "Nro. Proveedor"
            tbxNumCliPend.Text = ""
            tbxNumCliPend.BringToFront()
            cmbCliPend.Enabled = True
            tbxNumCliPend.Focus()
        Else
            rlblCliFac.Text = "Nro. Factura"
            tbxNroFacturaPend.Text = ""
            tbxNroFacturaPend.BringToFront()
            cmbCliPend.Enabled = False
            tbxNroFacturaPend.Focus()
        End If
        cmbCliPend.Text = ""
        cmbCliPend.SelectedIndex = -1
    End Sub
    Private Sub rbFactura_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbFactura.CheckedChanged
        If rbFactura.Checked = True Then
            rlblCliFac.Text = "Nro. Factura"
            tbxNroFacturaPend.Text = ""
            tbxNroFacturaPend.BringToFront()
            cmbCliPend.Enabled = False
            tbxNroFacturaPend.Focus()
        Else
            rlblCliFac.Text = "Nro. Proveedor"
            tbxNumCliPend.Text = ""
            tbxNumCliPend.BringToFront()
            cmbCliPend.Enabled = True
            tbxNumCliPend.Focus()
        End If
        cmbCliPend.Text = ""
        cmbCliPend.SelectedIndex = -1
    End Sub

    Private Sub dgvPendientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendientes.CellContentClick

    End Sub

    Public Sub dgwRetencion_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwRetencion.CellContentClick
        Dim CalcIva As Double
        Dim MontoRetenido As Double = 0
        Dim TotalRetenido As Double = 0
        Dim NroFacturas As String = ""
        Dim TotalIvaX As Double = 0

        CalcIva = PorcRetencion / 100

        'Recorremos la grilla para ir sumando los valores seleccionados
        For i = 0 To dgwRetencion.RowCount - 1
            Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgwRetencion.Rows(i).Cells("Retener")

            'Confirma los datos a la datasouce.
            Me.dgwRetencion.CommitEdit(DataGridViewDataErrorContexts.Commit)

            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
            Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)

            If checked = True Then
                MontoRetenido = dgwRetencion.Rows(i).Cells("TOTALIVA").Value * CalcIva
                TotalRetenido = TotalRetenido + MontoRetenido
                NroFacturas = NroFacturas & "," & dgwRetencion.Rows(i).Cells("NUMCOMPRADataGridViewTextBoxColumn1").Value
                TotalIvaX = TotalIvaX + dgwRetencion.Rows(i).Cells("TOTALIVA").Value
            End If
        Next

        lblMontoRentencion.Text = Math.Round(TotalRetenido, 0)
        tbxMonto.Text = lblMontoRentencion.Text
    End Sub
    Private Sub dgwRetencionRenta_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwRetencionRenta.CellContentClick
        Dim CalcRet As Double
        Dim MontoRetenido As Double = 0
        Dim TotalRetenido As Double = 0
        Dim NroFacturas As String = ""

        CalcRet = PorcRetencionRenta / 100

        'Recorremos la grilla para ir sumando los valores seleccionados
        For i = 0 To dgwRetencionRenta.RowCount - 1
            Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgwRetencionRenta.Rows(i).Cells("RetenerRenta")

            'Confirma los datos a la datasouce.
            Me.dgwRetencionRenta.CommitEdit(DataGridViewDataErrorContexts.Commit)

            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
            Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)

            If checked = True Then
                MontoRetenido = (dgwRetencionRenta.Rows(i).Cells("SALDORENTA2").Value) * CalcRet
                TotalRetenido = TotalRetenido + MontoRetenido
                NroFacturas = NroFacturas & "," & dgwRetencionRenta.Rows(i).Cells("NUMCOMPRARENTA2").Value
            End If
        Next

        lblMontoRetRenta.Text = FormatNumber(TotalRetenido, 2)
        tbxMonto.Text = lblMontoRetRenta.Text
    End Sub
    Private Sub CmbProveedor_LostFocus(sender As Object, e As System.EventArgs) Handles CmbProveedor.LostFocus
        Dim pos As Integer = dgwProveedores.CurrentRow.Index
        'If PanelProv = 0 Then
        If CmbProveedor.SelectedValue = Nothing Then
            tbxRucProveedor.Text = ""
            tbxNroProv.Text = ""
        Else

            If Config8 = "RUC" Then
                tbxRucProveedor.Text = f.FuncionConsultaString("RUC_CIN", "PROVEEDOR", "CODPROVEEDOR", CmbProveedor.SelectedValue)
            End If
            If Config8 = "Número de Proveedor" Then
                tbxNroProv.Text = f.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", CmbProveedor.SelectedValue)
            End If
            If tbxRucProveedor.Text = Nothing Then
                tbxRucProveedor.Text = ""
            End If

            FACTURAPAGARTableAdapter.Fill(DsPagosFacutas.FACTURAPAGAR, CmbProveedor.SelectedValue)
            FACTURASVENCIDASTableAdapter.Fill(DsPagosFacutas.FACTURASVENCIDAS, Today, CmbProveedor.SelectedValue)

            CalcularSaldo()
            ObtenerSaldoVencido()
            'End If
        End If
    End Sub

    Private Sub CmbProveedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbProveedor.SelectedIndexChanged

        ' If PanelProv = 0 Then
        If CmbProveedor.SelectedValue = Nothing Then
            tbxRucProveedor.Text = ""
            tbxRucProveedor.Text = ""
        Else

            If Config8 = "RUC" Then
                tbxNroProv.Enabled = False
                tbxNroProv.Visible = False
                tbxRucProveedor.Text = f.FuncionConsultaString("RUC_CIN", "PROVEEDOR", "CODPROVEEDOR", CmbProveedor.SelectedValue)
            End If
            If Config8 = "Número de Proveedor" Then
                tbxRucProveedor.Enabled = False
                tbxRucProveedor.Visible = False
                tbxNroProv.Text = f.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", CmbProveedor.SelectedValue)
            End If
            If tbxRucProveedor.Text = Nothing Then
                tbxRucProveedor.Text = ""
            End If
            If tbxNroProv.Text = Nothing Then
                tbxNroProv.Text = ""
            End If

            FACTURAPAGARTableAdapter.Fill(DsPagosFacutas.FACTURAPAGAR, CmbProveedor.SelectedValue)
            FACTURASVENCIDASTableAdapter.Fill(DsPagosFacutas.FACTURASVENCIDAS, Today, CmbProveedor.SelectedValue)

            CalcularSaldo()
            ObtenerSaldoVencido()
        End If
        'End If
    End Sub

    Private Sub dgvPendientes_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvPendientes.DoubleClick
        btnCobrar_Click(Nothing, Nothing)
    End Sub

    Private Sub ImprimirRetPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirRetPictureBox.Click
        '---------------------------- IMPRIMIMOS ----------------------------
        Try
            'lblEstadoVentasPlus.Text = "Imprimiendo"
            Dim TipoImpresion, Imprimir As Integer
            Dim SQL As String = ""

            Dim CodigoMaq As Integer
            If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
                CodigoMaquina = f.FuncionConsultaString("DETPC.IP", "DETPC INNER JOIN PC ON DETPC.IP = PC.IP", "PC.NOMBRE='" & nommaquina & "' AND DETPC.CODSUCURSAL", SucCodigo)
                CodigoMaq = CodigoMaquina
            Else
                CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
            End If

            SQL = "SELECT DETPC.IMPRIMIR,DETPC.IP,DETPC.IMPRESORA,TIPOCOMPROBANTE.FORMAIMPRESION FROM DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                  "WHERE ACTIVO = 1 AND RETENCION = 1 AND DETPC.IP = " & CodigoMaq

            Dim dadatoscomp As New SqlDataAdapter(SQL, ser.CadenaConexion)
            Dim dtdatoscomp As New DataTable
            dadatoscomp.Fill(dtdatoscomp)
            Dim drdatoscomp As DataRow

            drdatoscomp = dtdatoscomp.Rows(0)
            TipoImpresion = drdatoscomp("FORMAIMPRESION")
            Imprimir = drdatoscomp("IMPRIMIR")
            CodigoMaquina = drdatoscomp("IP")
            impresora = drdatoscomp("IMPRESORA")
            'se verifica el tipo de impresion para el tipo de comprobante actuamente seleccionado y de acuerdo a eso realizamos la impresion correspondiente
            'en caso de que este marcado la opcion de imprimir en la ventana "Rango de Comprobantes" 

            If TipoImpresion = 0 Then   'Formato Ticket
                If Imprimir = 1 Then 'Se imprime
                    If ImprimeRenta = 1 Then
                        ' imprimirRetRentaTicket()  Hacer tambien Formato Ticket
                    Else
                        ' imprimirRetTicket()  Hacer tambien Formato Ticket
                    End If
                End If
            ElseIf TipoImpresion = 1 Then 'Formato Impresora
                If Imprimir = 1 Then 'Se imprime
                    If ImprimeRenta = 1 Then
                        ImprimirReporteRetencionRenta()
                    Else
                        ImprimirReporteRetencion()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al imprimir, no existe la impresora ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
    End Sub

    Private Sub ImprimirRetRentaPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirRetRentaPictureBox.Click
        ImprimeRenta = 1
        ImprimirRetPictureBox_Click(Nothing, Nothing)
        ImprimeRenta = 0
    End Sub

    Private Sub ImprimirReporteRetencion()
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.RetencionIVA
        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        informe.SetDataSource(InfRetencion())

        informe.PrintOptions.PaperSource = PaperSource.Upper  'bandeja
        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress")
        End Try


        informe.PrintToPrinter(1, False, 0, 0)

    End Sub
    Private Sub ImprimirReporteRetencionRenta()
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.RetencionRENTA
        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        informe.SetDataSource(InfRetencionRenta())

        informe.PrintOptions.PaperSource = PaperSource.Upper  'bandeja
        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress")
        End Try


        informe.PrintToPrinter(1, False, 0, 0)

    End Sub

    Public Function InfRetencion() As DataSet
        Dim objCommand As New SqlCommand
        Dim rows As Integer = CobroFormaPagoDataGridView.RowCount
        Dim MontoSinIVA, IvaIncluido, ImporteRetenido As Decimal
        Dim NroFacturas, TipoFact, FactAnt, CodCompra, NroRet As String
        Dim NroDigitos As Double

        MontoSinIVA = 0 : IvaIncluido = 0 : ImporteRetenido = 0 : CodCompra = "" : NroFacturas = "" : FactAnt = "" : NroRet = ""

        For x = 0 To rows - 1
            If CobroFormaPagoDataGridView.Rows(x).Cells("DESTIPOPAGO").Value = "Retención Iva" Or CobroFormaPagoDataGridView.Rows(x).Cells("DESTIPOPAGO").Value = "Retencion" Then
                If btmodificar = 1 Then 'CobroFormaPagoDataGridView.Rows(x).Cells("FORMAPAGO").Value no esta enlazado y al momento de editar para reimprimir siempre traia Nothing, hay problemas con el dataset por eso no se enlazo
                    Dim formapago As Integer = f.FuncionConsulta("MODALIDADPAGO", "COMPRAS", "CODCOMPRA", CobroFormaPagoDataGridView.Rows(x).Cells("CODCOMPRA").Value)
                    If formapago = 0 Then
                        TipoFact = "CONT "
                    Else
                        TipoFact = "CRED "
                    End If
                Else
                    TipoFact = ""
                    If CobroFormaPagoDataGridView.Rows(x).Cells("FORMAPAGO").Value = 0 Then
                        TipoFact = "CONT "
                    Else
                        TipoFact = "CRED "
                    End If
                End If
                If CobroFormaPagoDataGridView.Rows(x).Cells("NUMCOMPRA").Value <> FactAnt Then 'Por el tema de las cuotas, puede aparecer 2 veces la misma factura
                    NroFacturas = NroFacturas + TipoFact + CobroFormaPagoDataGridView.Rows(x).Cells("NUMCOMPRA").Value + "/"
                    FactAnt = CobroFormaPagoDataGridView.Rows(x).Cells("NUMCOMPRA").Value
                End If
                ImporteRetenido = ImporteRetenido + CobroFormaPagoDataGridView.Rows(x).Cells("IMPORTE").Value

                If x = 0 Then
                    CodCompra = CobroFormaPagoDataGridView.Rows(x).Cells("CODCOMPRA").Value
                Else
                    CodCompra = CodCompra & "," & CobroFormaPagoDataGridView.Rows(x).Cells("CODCOMPRA").Value
                End If
                NroRet = CobroFormaPagoDataGridView.Rows(x).Cells("NUMRETENCION").Value
            End If

        Next

        Try
            objCommand.CommandText = "SELECT  dbo.FACTURAPAGAR.CODCOMPRA, C2.TOTALCOMPRA - ISNULL   " & _
                                     "((SELECT SUM(IMPORTE) AS Expr1  " & _
                                     "FROM dbo.COMPRASFORMAPAGO AS CFPAUX  " & _
                                     "WHERE (CODCOMPRA = C2.CODCOMPRA) AND (CODTIPOPAGO = 5)), 0) AS SALDO, C2.TOTALIVA - ISNULL  " & _
                                     "((SELECT SUM(TOTALIVA) AS Expr1  " & _
                                     "FROM dbo.DEVOLUCIONCOMPRA  " & _
                                     "WHERE (NUMDEVOLUCION IN  (SELECT NUMDEVOLUCION AS Expr1  " & _
                                     "FROM dbo.COMPRASFORMAPAGO AS CFP2   WHERE (CODCOMPRA = C2.CODCOMPRA) AND (CODTIPOPAGO = 5)))), 0) AS TOTALIVA  " & _
                                     "FROM dbo.FACTURAPAGAR INNER JOIN dbo.COMPRAS AS C2 ON dbo.FACTURAPAGAR.CODCOMPRA = C2.CODCOMPRA   " & _
                                     "GROUP BY C2.CODCOMPRA, dbo.FACTURAPAGAR.CODCOMPRA, C2.TOTALCOMPRA, C2.TOTALIVA, dbo.FACTURAPAGAR.PAGADO, C2.CODPROVEEDOR   " & _
                                     "HAVING (C2.CODPROVEEDOR = " & CmbProveedor.SelectedValue & ") AND (dbo.FACTURAPAGAR.CODCOMPRA IN (" & CodCompra & "))"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    MontoSinIVA = MontoSinIVA + (odrConfig("SALDO") - odrConfig("TOTALIVA"))
                    IvaIncluido = IvaIncluido + odrConfig("TOTALIVA")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try

        If NroFacturas <> "" Then
            NroFacturas = Mid(NroFacturas, 1, NroFacturas.Length - 1)
        End If

        Dim direccion As String = f.FuncionConsultaString("DIRECCION", "PROVEEDOR", "CODPROVEEDOR", CmbProveedor.SelectedValue)
        Dim ds As New DsInformes
        ds.Clear()
        Dim row As DataRow

        row = ds.Tables("Detalle").NewRow()
        row.Item("Fecha1") = dtpFechaPago.Text
        row.Item("Campo2") = CmbProveedor.Text
        row.Item("Campo3") = tbxRucProveedor.Text
        row.Item("Campo4") = direccion
        row.Item("Campo5") = NroFacturas
        row.Item("Numero1") = MontoSinIVA
        row.Item("Numero2") = IvaIncluido
        row.Item("Numero3") = MontoSinIVA + IvaIncluido
        row.Item("Numero4") = ImporteRetenido
        row.Item("Campo6") = PorcRetencion.ToString + " %"
        row.Item("Campo7") = Funciones.Cadenas.NumeroaLetras(FormatNumber(ImporteRetenido, 0))

        If Config5 = "Si" Then
            Dim CodigoMaq As Integer
            If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
                CodigoMaq = CodigoMaquina
            Else
                CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
            End If

            Try
                objCommand.CommandText = "SELECT dbo.DETPC.TIMBRADO, dbo.DETPC.FECHAVALIDEZ, dbo.DETPC.NRODIGITOS, dbo.EMPRESA.RUCCONTRIBUYENTE, dbo.DETPC.ULTIMO " & _
                                         "FROM   dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN  " & _
                                         "dbo.EMPRESA ON dbo.DETPC.CODEMPRESA = dbo.EMPRESA.CODEMPRESA " & _
                                         "WHERE (dbo.DETPC.ACTIVO = 1) AND (dbo.DETPC.IP = " & CodigoMaq & ") AND (dbo.TIPOCOMPROBANTE.RETENCION = '1')"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        row.Item("Campo8") = odrConfig("TIMBRADO")
                        row.Item("Campo9") = odrConfig("RUCCONTRIBUYENTE")
                        row.Item("Fecha2") = odrConfig("FECHAVALIDEZ")
                        NroRetencion = odrConfig("ULTIMO")
                        NroDigitos = odrConfig("NRODIGITOS")
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try

            row.Item("Campo16") = "Timbrado :"
            row.Item("Campo17") = "Fecha Validez :"
            row.Item("Campo18") = "R.U.C :"

            If btmodificar = 1 Then
                row.Item("Campo10") = NroRet.Substring(8)
            Else
                NroRetencion = NroRetencion + 1
                Dim NroRangoString As String = NroRetencion

                For i = 1 To NroDigitos
                    If Len(NroRangoString) = NroDigitos Then
                        Exit For
                    Else
                        NroRangoString = "0" & NroRangoString
                    End If
                Next
                row.Item("Campo10") = NroRangoString
            End If
        End If
        ds.Tables("Detalle").Rows.Add(row)

        Return ds
    End Function
    Public Function InfRetencionRenta() As DataSet
        Dim objCommand As New SqlCommand
        Dim rows As Integer = CobroFormaPagoDataGridView.RowCount
        Dim MontoSinIVA, IvaIncluido, ImporteRetenido As Decimal
        Dim NroFacturas, TipoFact, FactAnt, CodCompra, NroRet As String
        Dim NroDigitos As Double

        MontoSinIVA = 0 : IvaIncluido = 0 : ImporteRetenido = 0 : CodCompra = "" : NroFacturas = "" : FactAnt = "" : NroRet = ""

        For x = 0 To rows - 1
            If CobroFormaPagoDataGridView.Rows(x).Cells("DESTIPOPAGO").Value = "Retención Renta" Or CobroFormaPagoDataGridView.Rows(x).Cells("DESTIPOPAGO").Value = "Retencion Renta" Then
                TipoFact = ""
                If btmodificar = 1 Then 'CobroFormaPagoDataGridView.Rows(x).Cells("FORMAPAGO").Value no esta enlazado y al momento de editar para reimprimir siempre traia Nothing, hay problemas con el dataset por eso no se enlazo
                    Dim formapago As Integer = f.FuncionConsulta("MODALIDADPAGO", "COMPRAS", "CODCOMPRA", CobroFormaPagoDataGridView.Rows(x).Cells("CODCOMPRA").Value)
                    If formapago = 0 Then
                        TipoFact = "CONT "
                    Else
                        TipoFact = "CRED "
                    End If
                Else
                    If CobroFormaPagoDataGridView.Rows(x).Cells("FORMAPAGO").Value = 0 Then
                        TipoFact = "CONT "
                    Else
                        TipoFact = "CRED "
                    End If
                End If
                If CobroFormaPagoDataGridView.Rows(x).Cells("NUMCOMPRA").Value <> FactAnt Then 'Por el tema de las cuotas, puede aparecer 2 veces la misma factura
                    NroFacturas = NroFacturas + TipoFact + CobroFormaPagoDataGridView.Rows(x).Cells("NUMCOMPRA").Value + "/"
                    FactAnt = CobroFormaPagoDataGridView.Rows(x).Cells("NUMCOMPRA").Value
                End If
                ImporteRetenido = ImporteRetenido + CobroFormaPagoDataGridView.Rows(x).Cells("IMPORTE").Value

                If x = 0 Then
                    CodCompra = CobroFormaPagoDataGridView.Rows(x).Cells("CODCOMPRA").Value
                Else
                    CodCompra = CodCompra & "," & CobroFormaPagoDataGridView.Rows(x).Cells("CODCOMPRA").Value
                End If
                NroRet = CobroFormaPagoDataGridView.Rows(x).Cells("NUMRETENCION").Value
            End If

        Next

        Try
            objCommand.CommandText = "SELECT  dbo.FACTURAPAGAR.CODCOMPRA, C2.TOTALCOMPRA - ISNULL   " & _
                                     "((SELECT SUM(IMPORTE) AS Expr1  " & _
                                     "FROM dbo.COMPRASFORMAPAGO AS CFPAUX  " & _
                                     "WHERE (CODCOMPRA = C2.CODCOMPRA) AND (CODTIPOPAGO = 5)), 0) AS SALDO, C2.TOTALIVA - ISNULL  " & _
                                     "((SELECT SUM(TOTALIVA) AS Expr1  " & _
                                     "FROM dbo.DEVOLUCIONCOMPRA  " & _
                                     "WHERE (NUMDEVOLUCION IN  (SELECT NUMDEVOLUCION AS Expr1  " & _
                                     "FROM dbo.COMPRASFORMAPAGO AS CFP2   WHERE (CODCOMPRA = C2.CODCOMPRA) AND (CODTIPOPAGO = 5)))), 0) AS TOTALIVA  " & _
                                     "FROM dbo.FACTURAPAGAR INNER JOIN dbo.COMPRAS AS C2 ON dbo.FACTURAPAGAR.CODCOMPRA = C2.CODCOMPRA   " & _
                                     "GROUP BY C2.CODCOMPRA, dbo.FACTURAPAGAR.CODCOMPRA, C2.TOTALCOMPRA, C2.TOTALIVA, dbo.FACTURAPAGAR.PAGADO, C2.CODPROVEEDOR   " & _
                                     "HAVING (C2.CODPROVEEDOR = " & CmbProveedor.SelectedValue & ") AND (dbo.FACTURAPAGAR.CODCOMPRA IN (" & CodCompra & "))"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    MontoSinIVA = MontoSinIVA + (odrConfig("SALDO") - odrConfig("TOTALIVA"))
                    IvaIncluido = IvaIncluido + odrConfig("TOTALIVA")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try

        If NroFacturas <> "" Then
            NroFacturas = Mid(NroFacturas, 1, NroFacturas.Length - 1)
            NroFacturas = "AUTOFACTURA " + NroFacturas
        End If

        Dim direccion As String = f.FuncionConsultaString("DIRECCION", "PROVEEDOR", "CODPROVEEDOR", CmbProveedor.SelectedValue)
        Dim ds As New DsInformes
        ds.Clear()
        Dim row As DataRow

        row = ds.Tables("Detalle").NewRow()
        row.Item("Fecha1") = dtpFechaPago.Text
        row.Item("Campo2") = CmbProveedor.Text
        row.Item("Campo3") = tbxRucProveedor.Text
        row.Item("Campo4") = direccion
        row.Item("Campo5") = NroFacturas
        row.Item("Numero3") = MontoSinIVA + IvaIncluido
        row.Item("Numero4") = ImporteRetenido
        row.Item("Campo6") = PorcRetencionRenta.ToString + " %"
        row.Item("Campo7") = Funciones.Cadenas.NumeroaLetras(FormatNumber(ImporteRetenido, 0))

        If Config5 = "Si" Then

            Dim CodigoMaq As Integer
            If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
                CodigoMaq = CodigoMaquina
            Else
                CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
            End If

            Try
                objCommand.CommandText = "SELECT dbo.DETPC.TIMBRADO, dbo.DETPC.FECHAVALIDEZ, dbo.DETPC.NRODIGITOS, dbo.EMPRESA.RUCCONTRIBUYENTE, dbo.DETPC.ULTIMO " & _
                                         "FROM   dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN  " & _
                                         "dbo.EMPRESA ON dbo.DETPC.CODEMPRESA = dbo.EMPRESA.CODEMPRESA " & _
                                         "WHERE (dbo.DETPC.ACTIVO = 1) AND (dbo.DETPC.IP = " & CodigoMaq & ") AND (dbo.TIPOCOMPROBANTE.RETENCION = '1')"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        row.Item("Campo8") = odrConfig("TIMBRADO")
                        row.Item("Campo9") = odrConfig("RUCCONTRIBUYENTE")
                        row.Item("Fecha2") = odrConfig("FECHAVALIDEZ")
                        NroRetencion = odrConfig("ULTIMO")
                        NroDigitos = odrConfig("NRODIGITOS")
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try

            row.Item("Campo16") = "Timbrado :"
            row.Item("Campo17") = "Fecha Validez :"
            row.Item("Campo18") = "R.U.C :"
            If btmodificar = 1 Then
                row.Item("Campo10") = NroRet.Substring(8)
            Else
                NroRetencion = NroRetencion + 1
                Dim NroRangoString As String = NroRetencion

                For i = 1 To NroDigitos
                    If Len(NroRangoString) = NroDigitos Then
                        Exit For
                    Else
                        NroRangoString = "0" & NroRangoString
                    End If
                Next
                row.Item("Campo10") = NroRangoString
            End If
        End If
        ds.Tables("Detalle").Rows.Add(row)

        Return ds
    End Function

    Private Sub dgvFacturasaPagar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvFacturasaPagar.KeyDown
        If e.KeyCode = Keys.Space Then 'Ir a Montos
            If dgvFacturasaPagar.CurrentRow.Cells("Pagar").Value = False Then
                dgvFacturasaPagar.CurrentRow.Cells("Pagar").Value = True
                dgvFacturasaPagar_CellContentClick(Nothing, Nothing)
            Else
                dgvFacturasaPagar.CurrentRow.Cells("Pagar").Value = False
                dgvFacturasaPagar_CellContentClick(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub AdministrarRetencionesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AdministrarRetencionesToolStripMenuItem.Click
        ComprasRetencion.Show()
    End Sub



    Private Sub tbxNroProv_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroProv.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbProveedor.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxNroProv_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroProv.LostFocus
        Dim CodProveedor As Double
        tbxRucProveedor.Enabled = False
        tbxRucProveedor.Visible = False
        If Config8 = "Número de Proveedor" Then
            If tbxNroProv.Text <> "" Then
                CodProveedor = f.FuncionConsulta("CODPROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", tbxNroProv.Text)

                Try
                    CmbProveedor.SelectedValue = CDec(CodProveedor)
                Catch ex As Exception
                End Try
            End If

        End If

    End Sub

    Private Sub dgwProveedores_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgwProveedores.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Dim pos As Integer = dgwProveedores.CurrentRow.Index - 1
            PanelProv = 1

            If dgwProveedores.RowCount <> 0 Then
                If pos < 0 Then
                    pos = 0
                End If
                CmbProveedor.SelectedValue = CDec(dgwProveedores.Rows(pos).Cells("CODPROVEEDORDataGridViewTextBoxColumn").Value)
                ' tbxRucProveedor.Text = dgwProveedores.Rows(pos).Cells("RUCCINDataGridViewTextBoxColumn2").Value
                Me.tbxRucProveedor.Focus()
                UltraPopupControlContainer1.Close()
                Me.Refresh()

            End If
        End If
    End Sub

    Public Sub btnAceptarValorRetencion_Click(sender As Object, e As EventArgs) Handles btnAceptarValorRetencion.Click
        Dim TotalIvaX As Integer = 0
        For i = 0 To dgwRetencion.RowCount - 1
            Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgwRetencion.Rows(i).Cells("Retener")
            'Confirma los datos a la datasouce.
            Me.dgwRetencion.CommitEdit(DataGridViewDataErrorContexts.Commit)

            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
            Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)

            If checked = True Then
                TotalIvaX = TotalIvaX + dgwRetencion.Rows(i).Cells("TOTALIVA").Value
            End If
        Next

        Dim PorcRetencion As Int64 = 0
        If tbxValorRetener.Text = "" Then
            MessageBox.Show("Por favor ingrese el valor que desea retener", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            tbxValorRetener.Focus()
        Else
            PorcRetencion = (tbxValorRetener.Text * 100) / TotalIvaX
        End If
        lblPorcRetencion.Text = Math.Round(PorcRetencion, 0)
        lblPorcRetencion.Text = PorcRetencion.ToString + " %"
    End Sub

    Private Sub ImprimirCheque_Click(sender As Object, e As EventArgs) Handles ImprimirCheque.Click
        Dim ImprimirCheques As New ImprimirCheque()
        Dim c As Integer = CobroFormaPagoDataGridView.RowCount
        Dim IMPORTE As Decimal = 0
        Dim Concepto As String = ""
        Dim Proveedor As String = CmbProveedor.Text
        Dim fechapago2 As Date
        For i = 1 To c
            IMPORTE = IMPORTE + System.Math.Abs(CobroFormaPagoDataGridView.Rows(i - 1).Cells("IMPORTE").Value)
            CODTIPOPAGO = CobroFormaPagoDataGridView.Rows(i - 1).Cells("CODTIPOPAGO").Value
            fechapago2 = CobroFormaPagoDataGridView.Rows(i - 1).Cells("FECHAPAGO").Value
        Next
        IMPORTE = Funciones.Cadenas.QuitarCad(CDec(IMPORTE), ".")
        IMPORTE = Replace(IMPORTE, ",", ".")
        ImprimirCheques.Imprimir_Cheque(dtpFechaPago.Text, fechapago2, IMPORTE, Concepto, Proveedor)
    End Sub
End Class