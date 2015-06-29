Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports EnviaInformes
Imports Osuna.Utiles.Conectividad

Public Class CobroV2
#Region "Fields"
    Private ser As BDConexión.BDConexion
    Private ser2 As BDConexión.BDConexion
    Private sistema As New Funciones.Sistema
    Private cmd As SqlCommand
    Private direccion As String
    Private sqlc As SqlConnection
    Private sqlc2 As SqlConnection
    Private myTrans As SqlTransaction

    Dim indexcobro As Integer
    Dim dr As SqlDataReader
    Dim ds As New DataSet
    Dim existe As Integer
    Dim f As New Funciones.Funciones
    Dim impresora, sql As String
    Dim VCabCobro As Double
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim btnuevo, btmodificar, btmodificarCab, btmodificarDet, SaldoNC, indexNC As Integer
    Public Config1, Config2, Config3, Config4, Config5, Config6 As String
    Dim LineaCobro, ModifNC, ModifSF, yaPregunte As Integer
    Public panelactivo As String
    Dim saldoF As Boolean
    Dim ExisteAnt As String = ""
    '##############################################################
    Dim TotalCobro, TotalFalta, TotalDebe, TotalACobrar As Decimal
    Dim NumRecibo, NumSucursal, NumMaquina, NroRango, NroRango2 As String
    Dim VarGlobNroCuota, VarGlobNroVenta, VarGlobDeudaCobar, VarGlobSaldoFavor, BanExiste As Integer
    Dim ControlFiltro1, ControlFiltro2, ControlFiltro3, bt_nuevo, CabPagoMax, ErrorGuardar As Integer
    Dim SaldoFacTotal, Permiso, Saldo As Decimal
    Public VentasCobro, CodigoVenta, ContNewFilasEdit As Integer
    Dim errorFiltroFecha As Integer = 0
    Dim errorFiltroRango As Integer = 0
    Dim mensajeerror, IDRangoRecibos As String
    Dim dtmoneda As DataTable
    Dim dr2 As DataRow
    Dim cantdecimales, vgSaldoA, vgApliqueAnticipo As Integer

#End Region 'Fields

#Region "Constructors"

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        ser2 = New BDConexión.BDConexion
        cmd = New SqlCommand

        ds = New DataSet("INFORME")
        Try
            direccion = sistema.AppPath(False)
            direccion = direccion & "\" & "DsInformes.xsd"
        Catch ex As Exception

        End Try

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
        sqlc2 = New SqlConnection
        sqlc2.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

#End Region 'Constructors

#Region "Methods"

    Private Sub CobroV2_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        VentasCobro = 0
    End Sub

    Private Sub CobroV2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                ModificarCabPictureBox_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F7 Then 'Confirmar Pago
            If ConfirmarPictureBox.Enabled = True Then
                ConfirmarPictureBox_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F8 Then  'Cancelar
            If CancelarPictureBox.Enabled = True Then
                CancelarPictureBox_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyCode = Keys.F9 Then  'Ver Detalles
            If btnDetalles.Enabled = True Then
                btnDetalles_Click(Nothing, Nothing)
                dgvFacturasaCobar.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If pnlFacturasaCobrar.Visible = True Then
                btnDetalles_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub CobroV2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Permiso = PermisoAplicado(UsuCodigo, 36)
        If Permiso = 0 Then
            MessageBox.Show("Usted No tiene Permisos para Abrir esta Ventana", "Accesso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        saldoF = False
        ObtenerConfig()
        'SOLO CUANDO HAY UN SOLO COMPROBANTE RECIBO
        IDRangoRecibos = f.FuncionConsultaString("DETPC.RANDOID", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "ACTIVO = 1 AND COBROS", 1)

        CmbAño.SelectedText = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1
        InicializaFechaFiltro()

        ControlFiltro1 = 1 : ControlFiltro2 = 0 : ControlFiltro3 = 0 : VarGlobDeudaCobar = 0
        Me.CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)
        Me.COBROCABECERATableAdapter.Fill(Me.DsCobros3.COBROCABECERA, FechaFiltro1, FechaFiltro2)
        Me.MONEDATableAdapter1.Fill(Me.DsCobros2.MONEDA)
        Me.TIPOFORMACOBROTableAdapter1.Fill(Me.DsCobros2.TIPOFORMACOBRO)
        Me.CAJATableAdapter.Fill(Me.DsCobros2.CAJA)
        Me.USUARIOTableAdapter.Fill(Me.DsCobros2.USUARIO)
        Me.BANCOTableAdapter.Fill(Me.DsCobros3.BANCO)
        Me.FACTURASPENDIENTESTableAdapter.Fill(Me.DsCobros2.FACTURASPENDIENTES)
        dtmoneda = MONEDATableAdapter1.GetData()

        pnlNotaCredito.Visible = False : pnlRetencion.Visible = False : pnlBlanco.Visible = True : pnlBancario.Visible = False
        pnlBlanco.BringToFront()

        pnlFacturasaCobrar.Visible = False : tbxConcepto.Visible = False : lblConcepto.Visible = False : lblConceptoAyuda.Visible = False
        pnlFacturasaCobrar.SendToBack()
        DeshabilitarControles()
        ModificarDetPictureBox.Enabled = True
        tsEditar.Enabled = True

        If Config3 = "Panel Facturas Pendientes" Then
            PanelTodosPendientes.BringToFront()
            panelactivo = "Pendientes"
            NuevoPictureBox.Visible = False : EliminarPictureBox.Visible = False : ModificarDetPictureBox.Visible = False : CancelarPictureBox.Visible = False
            tbxNumCliPend.Text = "" : cmbCliPend.SelectedIndex = -1 : LblNomFantasiaPend.Text = ""
            tbxNumCliPend.Focus()
            MenuCobros.Enabled = False
        ElseIf Config3 = "Panel de Cobro" Then
            panelactivo = "SplitCobros"
            PagosActivo_Click(Nothing, Nothing)
            MenuCobros.Enabled = True
        End If

        If Config4 = "N° de Cliente" Then
            rbCliente.Checked = True
            rbFactura_CheckedChanged(Nothing, Nothing)
        ElseIf Config4 = "N° de Factura" Then
            rbFactura.Checked = True
            rbFactura_CheckedChanged(Nothing, Nothing)
            tbxNroFacturaPend.Focus()
        End If

        'Verificamos si la grilla de Cobros esta vacia que no permita editar
        If dgvCobros.RowCount = 0 Then
            ModificarDetPictureBox.Image = My.Resources.EditOff
            ModificarDetPictureBox.Enabled = False
            tsEditar.Enabled = False
        Else
            ModificarDetPictureBox.Image = My.Resources.Edit
            ModificarDetPictureBox.Enabled = True
            tsEditar.Enabled = True
        End If
        lblDGVCant.Text = "Cant. de Items:" & dgvCobros.RowCount
    End Sub

    Private Sub LimpiarGrilla()
        If dgvFormaCobro.Rows.Count > 0 Then
            For i = 0 To dgvFormaCobro.Rows.Count
                dgvFormaCobro.Rows.Clear()
            Next
        End If
    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged
        Try
            If panelactivo = "SplitCobros" Then
                If BuscarTextBox.Text = "" And BuscarTextBox.Text <> "Buscar..." Then
                    Me.CobroCabeceraBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR RECIBOCONSERIE LIKE '%" & BuscarTextBox.Text & "%'"
                Else

                    If Not System.Text.RegularExpressions.Regex.IsMatch(BuscarTextBox.Text, "^\d*$") Then ' Si introduce letras
                        Me.CobroCabeceraBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR RECIBOCONSERIE LIKE '%" & BuscarTextBox.Text & "%'"
                    Else
                        Me.CobroCabeceraBindingSource.Filter = "NUMCLIENTE =" & BuscarTextBox.Text
                        If dgvCobros.RowCount = 0 Then
                            Me.CobroCabeceraBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR RECIBOCONSERIE LIKE '%" & BuscarTextBox.Text & "%'"
                        End If
                    End If
                End If
            Else
                If BuscarTextBox.Text = "" And BuscarTextBox.Text <> "Buscar..." Then
                    Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%'"
                Else

                    If Not System.Text.RegularExpressions.Regex.IsMatch(BuscarTextBox.Text, "^\d*$") Then ' Si introduce letras
                        Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%'"
                    Else
                        Me.CLIENTESBindingSource.Filter = "NUMCLIENTE1 =" & BuscarTextBox.Text
                        If GridViewTodosClientes.RowCount = 0 Then
                            Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%'"
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
        lblDGVCant.Text = "Cant. de Items:" & dgvCobros.RowCount
    End Sub

    Private Sub BuscarTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.GotFocus
        BuscarTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub BuscarTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.LostFocus
        BuscarTextBox.BackColor = Color.DimGray
    End Sub

    Private Sub LimpiaFormulario()
        'dtpFechaCobroDet.Text = Today.ToShortDateString : dtpRegFechaCobro.Text = Today

        'lbxTipoCobro.SelectedItem = "Efectivo"
        'pnlBlanco.BringToFront()
        'pnlBlanco.Visible = True
        'pnlBancario.Visible = False
        'tbxConcepto.Visible = False
        'lblConcepto.Visible = False
        'lblConceptoAyuda.Visible = False

        lblMontoSelecionado.Text = "0 Gs"
        ControlFiltro1 = 1 : ControlFiltro2 = 0 : ControlFiltro3 = 0 : VarGlobDeudaCobar = 0
        lblCuotas.Text = "" : lblNroFacturas.Text = ""

        tbxMonto.Text = ""
        TotalCobro = 0
        TotalDebe = 0
        TotalFalta = 0
    End Sub

    Private Sub DeshabilitarControles()
        NuevoPictureBox.Enabled = True
        tsNuevaVenta.Enabled = True
        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Cursor = Cursors.Hand

        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Cursor = Cursors.Hand

        ConfirmarPictureBox.Enabled = False
        tsGuardar.Enabled = False
        ConfirmarPictureBox.Image = My.Resources.ApproveOff
        ConfirmarPictureBox.Cursor = Cursors.Arrow
        CancelarPictureBox.Enabled = False
        tsCancelar.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow

        pnlDatosdelCobro.Enabled = False
        btnMostrarOBS.Enabled = True
        pnlDetalleCobro.Enabled = False
        dgvFacturasaCobar.Enabled = False
        dgvFormaCobro.Enabled = False

        GridViewTodosClientes.Enabled = True
        BuscarTextBox.Enabled = True

        lblAyuda.Visible = False
        lblMontoC.Visible = False
        lblPagado.Visible = False
        lblSaldoFavor.Visible = False
        lblSaldoF.Visible = False
        pnlBlanco.Visible = False
        btnAgregarPago.Enabled = False
        btnEliminarPago.Enabled = False
        lblTitulo.Text = "Cobros"
        vgApliqueAnticipo = 0

        tbxNumCliente.Enabled = False
        CmbCliente.Enabled = False
        BtnAsterisco.Enabled = False
        lblDetalles.Text = "Ver Detalles"
        lblDGVCant.Text = "Cant. de Items:" & dgvCobros.RowCount

        btGuardarOBS.Enabled = True
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

        pnlDatosdelCobro.Enabled = True
        pnlDetalleCobro.Enabled = True
        dgvFacturasaCobar.Enabled = True
        dgvFormaCobro.Enabled = True

        GridViewTodosClientes.Enabled = False
        BuscarTextBox.Enabled = False

        btGuardarOBS.Enabled = False

        lblAyuda.Visible = True
        If btmodificar <> 1 Then
            lblMontoC.Visible = True
            lblPagado.Visible = True
            lblSaldoFavor.Visible = True
            lblSaldoF.Visible = True
        End If

        btnAgregarPago.Enabled = True
        btnEliminarPago.Enabled = True
        lblTitulo.Text = "Carga de Cobros"

        tbxNumCliente.Enabled = True
        CmbCliente.Enabled = True
        BtnAsterisco.Enabled = True
        'pnlFacturasaCobrar.BringToFront()
        'lblDetalles.Text = "Esconder"
    End Sub

    Private Sub CalcularSaldo()
        'by Yolanda Zelaya
        Dim x As Integer = Me.dgvFacturasaCobar.RowCount
        SaldoFacTotal = 0
        For i = 1 To x
            SaldoFacTotal = SaldoFacTotal + CDec(dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value)
        Next

        lblMontoSelecionado.Text = FormatNumber(SaldoFacTotal, 2)

    End Sub

    Private Sub ObtenerSaldoVencido()
        'by Yolanda Zelaya
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

    Private Sub btnDetalles_Click(sender As System.Object, e As System.EventArgs) Handles btnDetalles.Click
        'Abrir y Esconder el detalle de las cuentas a Cobrar

        If pnlFacturasaCobrar.Visible = False Then
            pnlFacturasaCobrar.Visible = True
            pnlFacturasaCobrar.BringToFront()
            lblDetalles.Text = "Esconder"
            lblDetalles.ForeColor = Color.Tomato
            btnDetalles.Image = My.Resources.DisplayActive
            lblACobrar2.Visible = False
            lblMontoSelec2.Visible = False

            lblAnticipoTexto2.Visible = False
            txtAnticipo2.Visible = False
        Else
            lbxTipoCobro.SelectedValue = 1
            pnlFacturasaCobrar.Visible = False
            pnlFacturasaCobrar.SendToBack()
            lblDetalles.Text = "Ver Detalles"
            lblDetalles.ForeColor = Color.White
            btnDetalles.Image = My.Resources.Display
            If lblMontoSelecionado.Text <> "0" Then
                lblACobrar2.Visible = True
                lblMontoSelec2.Text = lblMontoSelecionado.Text
                lblMontoSelec2.Visible = True

                If lblAnticipoS.Text <> "0" Then
                    lblAnticipoTexto2.Visible = True
                    txtAnticipo2.Visible = True
                    txtAnticipo2.Text = lblAnticipoS.Text
                End If
            End If
            dtpRegFechaCobro.Focus()
        End If
    End Sub

    Public Sub LimpiarDetalle()
        tbxMonto.Text = "" : tbxNroRef.Text = ""
        dtpFechaCobroDet.Text = dtpRegFechaCobro.Text : tbxConcepto.Text = "" : tbxNroRetencion.Text = "" : tbxNotadeCredito.Text = ""
    End Sub

    Private Sub GridViewCliente_SelectionChanged(sender As Object, e As System.EventArgs) Handles GridViewTodosClientes.SelectionChanged
        Try
            Dim par As String

            If panelactivo = "SplitCobros" Then
                FACTURAACOBRARTableAdapter1.Fill(DsCobros2.FACTURAACOBRAR, CmbCliente.SelectedValue)
                SALDOVENCIDOTableAdapter1.Fill(DsCobros2.SALDOVENCIDO, Today, CmbCliente.SelectedValue)
                CalcularSaldo()
                ObtenerSaldoVencido()

            ElseIf panelactivo = "Pagos" Then
                If IsDBNull(GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value) Then
                    par = 0
                Else
                    par = GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value
                End If

                Fecha1Filtro.Text = "  /  /    " : Fecha2Filtro.Text = "  /  /    "
                Me.FiltroCobroSaldoTableAdapter1.Fill(DsCobros2.FiltroCobroSaldo, par)

            ElseIf panelactivo = "Historial" Then
                cbxTipoCobro.Text = ""
                If IsDBNull(GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value) Then
                    par = 0
                Else
                    par = GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value
                End If
                Me.HISTORIALPAGOSTableAdapter1.Fill(DsCobros2.HISTORIALPAGOS, par, "%")
            End If

            lblClienteCtaCte.Text = GridViewTodosClientes.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value
            lblClienteHistorial.Text = GridViewTodosClientes.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CmbCliente.KeyPress
        Try
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If KeyAscii = 13 Then
                If lblDetalles.Text = "Esconder" Then
                    dgvFacturasaCobar.Focus()
                Else
                    dtpRegFechaCobro.Focus()
                    KeyAscii = 0
                End If
            End If
            If KeyAscii = 42 Then
                Me.CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)
                UltraPopupControlContainer1.PopupControl = GroupBoxCliente
                UltraPopupControlContainer1.Show()
                TxtBuscaCliente.Text = ""
                TxtBuscaCliente.Focus()
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FiltroPagosActivo_Click(sender As System.Object, e As System.EventArgs) Handles FiltroPagosActivo.Click
        Permiso = PermisoAplicado(UsuCodigo, 39)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene Permisos para Visualizar esta Ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If panelactivo = "SplitCobros" Then
            If dgvCobros.RowCount <> 0 Then
                indexcobro = dgvCobros.CurrentRow.Index
            End If

            NuevoPictureBox.Visible = False
            EliminarPictureBox.Visible = False
            ModificarDetPictureBox.Visible = False
            CancelarPictureBox.Visible = False
            ConfirmarPictureBox.Visible = False
        ElseIf panelactivo = "Pendientes" Then
            PictureBox2.Visible = True
            BuscarTextBox.Visible = True
        End If

        MenuCobros.Enabled = False
        panelactivo = "Pagos"
        ControlFiltro1 = 0 : ControlFiltro2 = 1 : ControlFiltro3 = 0

        DeshabilitarControles()
        LimpiaFormulario()
        pnlCobroSaldo.BringToFront()
        chbxEsconderSaldoCero.Checked = True

        PagosActivo.Image = My.Resources.Payment
        PagosActivo.Cursor = Cursors.Hand
        FiltroPagosActivo.Image = My.Resources.UserActive
        FiltroPagosActivo.Cursor = Cursors.Arrow
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        TipoCobroPictureBox.Cursor = Cursors.Hand
        PendientesPago.Image = My.Resources.Create
        PendientesPago.Cursor = Cursors.Hand

        splitNavegador.BringToFront()
        Dim par1 As String

        If IsDBNull(GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value) Then
            par1 = 0
        Else
            par1 = GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value
        End If

        Me.FiltroCobroSaldoTableAdapter1.Fill(DsCobros2.FiltroCobroSaldo, par1)

        lblClienteCtaCte.Text = GridViewTodosClientes.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value
        BuscarTextBox.Focus()
    End Sub

    Private Sub Fecha1Filtro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fecha1Filtro.LostFocus
        If Fecha1Filtro.Text = "" Then
            Fecha1Filtro.Text = "  /  /    "
        End If
    End Sub

    Private Sub Fecha1Filtro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fecha1Filtro.GotFocus
        If Fecha1Filtro.Text = "  /  /    " Then
            Fecha1Filtro.Text = ""
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

    Private Sub btnLimpiarCtaCte_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarCtaCte.Click
        Fecha1Filtro.Text = "  /  /    " : Fecha2Filtro.Text = "  /  /    " : chbxEsconderSaldoCero.Checked = True
        Me.FiltroCobroSaldoTableAdapter1.Fill(DsCobros2.FiltroCobroSaldo, GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value)
    End Sub

    Private Sub btnLimpiarCuentas_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarCuentas.Click
        FechaHasta3.Text = "  /  /    " : FechaDesde3.Text = "  /  /    " : cbxTipoCobro.Text = ""
        Me.HISTORIALPAGOSTableAdapter1.Fill(DsCobros2.HISTORIALPAGOS, GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value, "%")
    End Sub

    Private Sub TipoCobroPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles TipoCobroPictureBox.Click
        Permiso = PermisoAplicado(UsuCodigo, 40)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permisos para Visualizar los Datos en Ventana", "PosExpress")
            Exit Sub
        End If

        If panelactivo = "SplitCobros" Then
            If dgvCobros.RowCount <> 0 Then
                indexcobro = dgvCobros.CurrentRow.Index
            End If

            NuevoPictureBox.Visible = False
            EliminarPictureBox.Visible = False
            ModificarDetPictureBox.Visible = False
            CancelarPictureBox.Visible = False
            ConfirmarPictureBox.Visible = False
        ElseIf panelactivo = "Pendientes" Then
            PictureBox2.Visible = True
            BuscarTextBox.Visible = True
        End If

        MenuCobros.Enabled = False
        panelactivo = "Historial"
        ControlFiltro1 = 0 : ControlFiltro2 = 0 : ControlFiltro3 = 1 : cbxTipoCobro.Text = ""

        LimpiaFormulario()
        DeshabilitarControles()
        pnlFiltradoTipoCobro.BringToFront()

        PagosActivo.Image = My.Resources.Payment
        PagosActivo.Cursor = Cursors.Hand
        FiltroPagosActivo.Image = My.Resources.User
        FiltroPagosActivo.Cursor = Cursors.Hand
        TipoCobroPictureBox.Image = My.Resources.CuentaActive
        TipoCobroPictureBox.Cursor = Cursors.Arrow
        PendientesPago.Image = My.Resources.Create
        PendientesPago.Cursor = Cursors.Hand

        splitNavegador.BringToFront()
        Dim par As String
        If IsDBNull(GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value) Then
            par = 0
        Else
            par = GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value
        End If
        Me.HISTORIALPAGOSTableAdapter1.Fill(DsCobros2.HISTORIALPAGOS, par, "%")
        dgvCobros.Enabled = False
        BtnFiltro.Enabled = False

        lblClienteHistorial.Text = GridViewTodosClientes.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value
        BuscarTextBox.Focus()
    End Sub

    Public Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click

        Dim MaxIdApertura, ExisteCierre As Integer
        Dim dt As DataTable = CAJATableAdapter.GetData
        Dim dr As DataRow
        Dim countcajas As Integer = 0
        Dim cajasabiertas As String = ""

        'vgSaldoA = 0
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
            MessageBox.Show("No existen Cajas Abiertas para Realizar Cobros", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            CAJABindingSource.Filter = cajasabiertas
        End If

        btnuevo = 1 : btmodificar = 0
        PanelCobroCuotas.BringToFront()
        PagosActivo.Image = My.Resources.PaymentActive
        FiltroPagosActivo.Image = My.Resources.User
        TipoCobroPictureBox.Image = My.Resources.Cuenta

        pnlFacturasaCobrar.Visible = False
        lblDetalles.Text = "Ver Detalles"
        btnDetalles.Image = My.Resources.DisplayActive

        CLIENTESBindingSource.RemoveFilter()
        CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)

        HabilitarControles()
        Me.CobroCabeceraBindingSource.AddNew()
        Me.COBRODETALLETableAdapter.Fill(Me.DsCobros3.COBRODETALLE, 0)

        tbxMonto.Text = "" : lblMontoSelecionado.Text = 0 : lblSaldoFavor.Text = 0 : lblMontoTotalVencido.Text = "" : lblCuotas.Text = "" : lblNroFacturas.Text = "" : lblMontoSelecionado.Text = ""

        NuevoCobro()

        If Config2 = "Manual" Or Config2 = "Manual sin Importar usuario" Then
            Dim CodCobroMax As Integer
            Dim MaxNroRecibo As String

            cmbGenerarRecibo.Text = "Manual"
            'Obtiene el ultimo nro cargado
            Try
                If Config2 = "Manual por Usuario" Then
                    CodCobroMax = f.FuncionConsultaString("MAX(CODCOBRO)", "VENTASFORMACOBRO", "NRORECIBO IS NOT NULL AND AUTORIZADO", UsuCodigo)
                ElseIf Config2 = "Manual sin Importar usuario" Then
                    CodCobroMax = f.MaximoIsNotNull("CODCOBRO", "VENTASFORMACOBRO", "NRORECIBO")
                End If

                MaxNroRecibo = f.FuncionConsultaString("NRORECIBO", "VENTASFORMACOBRO", "CODCOBRO", CodCobroMax)

                If Trim(MaxNroRecibo) <> "" Then
                    Dim max As Integer = CInt(MaxNroRecibo)
                    MaxNroRecibo = max + 1
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

        If Config5 = "Seleccionada segun DashBoard" Then
            Try
                cmbCaja.SelectedValue = Dashboard.CmbCaja.SelectedValue
            Catch ex As Exception
            End Try
        End If

        pnlBlanco.BringToFront()
        pnlBlanco.Visible = True : pnlBancario.Visible = False : tbxConcepto.Visible = False : lblConcepto.Visible = False : lblConceptoAyuda.Visible = False
        dgvCobros.Enabled = False : BtnFiltro.Enabled = False : BuscarTextBox.Enabled = False : FiltroPagosActivo.Enabled = False : TipoCobroPictureBox.Enabled = False : PendientesPago.Enabled = False

        If saldoF = False Then
            btnDetalles_Click(Nothing, Nothing)
        End If

        umeTotalRec.Text = "0" : tbxNumCliente.Text = "" : CmbCliente.SelectedIndex = -1
        vgApliqueAnticipo = 0
    End Sub
    Private Sub ModificarCabPictureBox_Click(sender As System.Object, e As System.EventArgs)
        btmodificarCab = 1
        btmodificar = 1
        PagosActivo.Image = My.Resources.PaymentActive
        FiltroPagosActivo.Image = My.Resources.User
        TipoCobroPictureBox.Image = My.Resources.Cuenta

        ConfirmarPictureBox.Visible = True
        HabilitarControles()
        dgvFormaCobro.Enabled = True
        pnlDetalleCobro.Enabled = False
    End Sub

    Public Sub NuevoCobro()
        Try
            Permiso = PermisoAplicado(UsuCodigo, 37)
            If Permiso = 0 Then
                MessageBox.Show("Usted no tiene Permisos para cargar un COBRO", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            VarGlobDeudaCobar = 0 : Saldo = 0 : lblPagado.Text = "0" : ErrorGuardar = 0

            dgvFormaCobro.Enabled = True
            pnlDetalleCobro.Enabled = True

            LimpiaFormulario()

            ModificarDetPictureBox.Enabled = False
            tsEditar.Enabled = False
            ConfirmarPictureBox.Visible = True

            cbxPagador.SelectedValue = UsuCodigo
            cbxMoneda.SelectedIndex = 0
            If cbxMoneda.SelectedValue <> Nothing Then
                tbxCotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(cbxMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
                Dim SimboloEfectivo As String = f.FuncionConsultaString("SIMBOLO", "MONEDA", "CODMONEDA", cbxMoneda.SelectedValue)

                Me.COTIZACIONTableAdapter.Fill(DsCobros2.COTIZACION, cbxMoneda.SelectedValue)

                If SimboloEfectivo = "0" Then
                    lblSimbolo.Text = "Gs"
                Else
                    lblSimbolo.Text = SimboloEfectivo
                End If
            End If

            'Fecha del nuevo Cobro segun configuración
            If Config1 = "Mostrar Fecha Actual" Then
                dtpFechaCobroDet.Text = Today.ToShortDateString
                dtpRegFechaCobro.Text = Today.ToShortDateString

            ElseIf Config1 = "Mostrar Fecha Atrazada 1 Día" Then
                Dim day As Integer = DateTime.Now.AddDays(-1).Day
                Dim mes As Integer = Today.Month
                Dim anho As Integer = Today.Year

                Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                dtpFechaCobroDet.Text = Fecha
                dtpRegFechaCobro.Text = Fecha

            ElseIf Config1 = "Mostrar Fecha Adelantada 1 Día" Then
                Dim day As Integer = DateTime.Now.AddDays(+1).Day
                Dim mes As Integer = Today.Month
                Dim anho As Integer = Today.Year

                Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                dtpFechaCobroDet.Text = Fecha
                dtpRegFechaCobro.Text = Fecha

            ElseIf Config1 = "Mostrar Fecha de Ultima Seleccion por Usuario" Then 'fecha del ultimo recibo procesado por el usuario
                Try
                    Dim MaxCobro As Integer = f.FuncionConsulta("MAX(CODCOBRO)", "VENTASFORMACOBRO", "FECHAREGISTROCOB IS NOT NULL AND AUTORIZADO", UsuCodigo)
                    dtpRegFechaCobro.Text = f.FuncionConsultaString("FECHAREGISTROCOB", "VENTASFORMACOBRO", "CODCOBRO", MaxCobro)
                    dtpFechaCobroDet.Text = dtpRegFechaCobro.Text
                Catch ex As Exception
                    dtpRegFechaCobro.Text = Today.ToShortDateString
                    dtpFechaCobroDet.Text = Today.ToShortDateString
                End Try

            ElseIf Config1 = "Mostrar Fecha de Ultima Seleccion" Then 'fecha del ultimo recibo sin importar el usuario
                Try
                    Dim MaxCobro As Integer = f.MaximoIsNotNull("CODCOBRO", "VENTASFORMACOBRO", "FECHAREGISTROCOB")
                    dtpRegFechaCobro.Text = f.FuncionConsultaString("FECHAREGISTROCOB", "VENTASFORMACOBRO", "CODCOBRO", MaxCobro)
                    dtpFechaCobroDet.Text = dtpRegFechaCobro.Text
                Catch ex As Exception
                    dtpRegFechaCobro.Text = Today.ToShortDateString
                    dtpFechaCobroDet.Text = Today.ToShortDateString
                End Try
            End If

            FACTURAACOBRARTableAdapter1.Fill(DsCobros2.FACTURAACOBRAR, 0)
            SALDOVENCIDOTableAdapter1.Fill(DsCobros2.SALDOVENCIDO, Today, GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value)

            CalcularSaldo()
            ObtenerSaldoVencido()
            tbxNumCliente.Focus()
            NuevoPictureBox.Image = My.Resources.NewActive

        Catch ex As Exception

        End Try
    End Sub

    Public Sub dgvFacturasaCobar_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFacturasaCobar.CellContentClick
        Dim MontoACobrar As Double
        Dim CuotasACobrar, NroFacturas As String

        MontoACobrar = 0 : CuotasACobrar = "" : NroFacturas = ""

        'Recorremos la grilla para ir sumando los valores seleccionados
        For i = 0 To dgvFacturasaCobar.RowCount - 1
            Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgvFacturasaCobar.Rows(i).Cells("Cobrar")

            'Confirma los datos a la datasouce.
            Me.dgvFacturasaCobar.CommitEdit(DataGridViewDataErrorContexts.Commit)

            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
            Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)

            If checked = True Then
                MontoACobrar = MontoACobrar + dgvFacturasaCobar.Rows(i).Cells("SALDOCUOTA").Value

                CuotasACobrar = CuotasACobrar + Str(dgvFacturasaCobar.Rows(i).Cells("NUMEROCUOTA").Value)
                If (CuotasACobrar.Length = 1) Or (CuotasACobrar.Length = 2) Then
                    CuotasACobrar = dgvFacturasaCobar.Rows(i).Cells("NUMEROCUOTA").Value
                    NroFacturas = dgvFacturasaCobar.Rows(i).Cells("NUMVENTA").Value
                Else
                    CuotasACobrar = "Varios"
                    NroFacturas = "Ver Detalle"
                End If
            End If
        Next

        If lblPagado.Text = "" Then
            lblPagado.Text = "0"
        End If

        MontoACobrar = MontoACobrar + CDec(lblPagado.Text)
        cbxMoneda.SelectedValue = dgvFacturasaCobar.CurrentRow.Cells("CODMONEDA").Value
        lblMonedaFact.Text = dgvFacturasaCobar.CurrentRow.Cells("CODMONEDA").Value

        lblMontoSelecionado.Text = FormatNumber(MontoACobrar, 2)
        lblCuotas.Text = CuotasACobrar
        lblNroFacturas.Text = NroFacturas

        Dim Chequeado As Boolean = VerificarCkequet()
        If Chequeado = False Then
            CalcularSaldo()
        End If
    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1, CONFIG2, CONFIG3, CONFIG4, CONFIG5, CONFIG6 FROM MODULO WHERE MODULO_ID = 10"
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
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Public Function VerificarCkequet() As Boolean
        Dim rows As Integer = dgvFacturasaCobar.RowCount
        Dim ExisteCkequet As Boolean

        ExisteCkequet = False
        For x = 1 To rows
            If dgvFacturasaCobar.Rows(x - 1).Cells("Cobrar").Value = True Then
                ExisteCkequet = True
                Exit For
            End If
        Next
        Return ExisteCkequet
    End Function

    Private Sub lbxTipoCobro_GotFocus(sender As Object, e As System.EventArgs) Handles lbxTipoCobro.GotFocus
        lbxTipoCobro.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub lbxTipoCobro_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lbxTipoCobro.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxMonto.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub lbxTipoCobro_LostFocus(sender As Object, e As System.EventArgs) Handles lbxTipoCobro.LostFocus
        lbxTipoCobro.BackColor = Color.White
    End Sub

    Private Sub lbxTipoCobro_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbxTipoCobro.SelectedIndexChanged
        If lbxTipoCobro.SelectedValue = 1 Then 'lbxTipoCobro.Text = "Efectivo"
            pnlBlanco.BringToFront()
            pnlBlanco.Visible = True
            pnlBancario.Visible = False
            tbxConcepto.Visible = False
            lblConcepto.Visible = False
            lblConceptoAyuda.Visible = False
            pnlSaldoFavor.Visible = False
            btnAgregarPago.Visible = True
        ElseIf lbxTipoCobro.SelectedValue = 3 Then 'lbxTipoCobro.Text = "Cheque"
            pnlBlanco.BringToFront()
            pnlBlanco.Visible = True
            pnlBancario.BringToFront()
            pnlBancario.Visible = True
            pnlSaldoFavor.Visible = False
        ElseIf lbxTipoCobro.SelectedValue = 5 Then  'lbxTipoCobro.Text = "Nota de Credito" Or lbxTipoCobro.Text = "Nota de Crédito"
            pnlNotaCredito.Visible = True
            pnlNotaCredito.BringToFront()
            btnAgregarPago.Visible = True
        ElseIf lbxTipoCobro.SelectedValue = 2 Then 'lbxTipoCobro.Text = "Tarjeta"
            pnlBlanco.BringToFront()
            pnlBlanco.Visible = True
            pnlBancario.Visible = False
            tbxConcepto.Visible = False
            lblConcepto.Visible = False
            pnlSaldoFavor.Visible = False
            lblConceptoAyuda.Visible = False
            btnAgregarPago.Visible = True
        ElseIf lbxTipoCobro.SelectedValue = 4 Then 'lbxTipoCobro.Text = "Transferencia"
            pnlBlanco.BringToFront()
            pnlBlanco.Visible = True
            pnlBancario.BringToFront()
            pnlBancario.Visible = True
            pnlSaldoFavor.Visible = False
            btnAgregarPago.Visible = True
        ElseIf lbxTipoCobro.SelectedValue = 6 Then 'lbxTipoCobro.Text = "Retención Iva"
            pnlRetencion.BringToFront()
            pnlRetencion.Visible = True
            pnlSaldoFavor.Visible = False
            btnAgregarPago.Visible = True
        ElseIf lbxTipoCobro.SelectedValue = 7 Then 'lbxTipoCobro.Text = "Ajuste de Pago"
            pnlBlanco.BringToFront()
            pnlBlanco.Visible = True
            pnlBancario.Visible = False
            tbxConcepto.Visible = True
            lblConcepto.Visible = True
            lblConceptoAyuda.Visible = True
            pnlSaldoFavor.Visible = False
            btnAgregarPago.Visible = True
        ElseIf lbxTipoCobro.SelectedValue = 8 Then 'lbxTipoCobro.Text = "Aplique Saldo a Favor"
            'pnlBlanco.BringToFront()
            pnlSaldoFavor.BringToFront()
            pnlSaldoFavor.Visible = True
            pnlBancario.Visible = False
            pnlBlanco.Visible = False
            pnlNotaCredito.Visible = False
            pnlRetencion.Visible = False
            btnAgregarPago.Visible = False
            vgApliqueAnticipo = 1
            'tbxBuscSaldoFavor.Visible = True
            'lblConcepto.Visible = True
            'lblConceptoAyuda.Visible = True
        End If
    End Sub

    Private Sub FechaReciboFecha_LostFocus(sender As Object, e As System.EventArgs) Handles dtpRegFechaCobro.LostFocus
        dtpRegFechaCobro.BackColor = Color.White
        dtpFechaCobroDet.Text = dtpRegFechaCobro.Text
    End Sub

    Private Sub FechaReciboFecha_GotFocus(sender As Object, e As System.EventArgs) Handles dtpRegFechaCobro.GotFocus
        dtpRegFechaCobro.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub FechaReciboFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpRegFechaCobro.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbGenerarRecibo.Focus()
            KeyAscii = 0
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
    Private Sub NroReciboTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NroReciboTextBox.LostFocus
        lblProximoNro.Text = "Nro. Recibo: " + NroReciboTextBox.Text + " " + tbxNroSerie.Text
    End Sub

    Private Sub NroReciboTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NroReciboTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxMoneda.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub NroReciboTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles NroReciboTextBox.GotFocus
        NroReciboTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub cbxPagador_LostFocus(sender As Object, e As System.EventArgs) Handles cbxPagador.LostFocus
        cbxPagador.BackColor = Color.White
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
        Try
            Dim SimboloEfectivo As String
            If cbxMoneda.SelectedValue <> Nothing Then
                tbxCotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(cbxMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")

                'SimboloEfectivo = f.FuncionConsultaString("SIMBOLO", "MONEDA", "CODMONEDA", cbxMoneda.SelectedValue)
                SimboloEfectivo = ""
                Me.COTIZACIONTableAdapter.Fill(DsCobros2.COTIZACION, cbxMoneda.SelectedValue)

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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbxCotizacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxCotizacion.CheckedChanged
        If chbxCotizacion.Checked = True Then
            tbxCotizacion.Enabled = True
            tbxCotizacion.Text = ""
            tbxCotizacion.Focus()

        Else
            tbxCotizacion.Text = ""
            Me.COTIZACIONTableAdapter.Fill(DsCobros2.COTIZACION, cbxMoneda.SelectedValue)
            If cbxMoneda.SelectedValue <> Nothing Then
                tbxCotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(cbxMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
            End If
            tbxCotizacion.Enabled = False
        End If
    End Sub

    Private Sub tbxCotizacion_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCotizacion.GotFocus
        tbxCotizacion.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxCotizacion_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCotizacion.LostFocus
        tbxCotizacion.BackColor = Color.White
    End Sub

    Private Sub tbxMonto_GotFocus(sender As Object, e As System.EventArgs) Handles tbxMonto.GotFocus
        tbxMonto.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxMonto.KeyPress
        'Verificamos que tipo de Cobro selecciono y de acuerdo a eso ponemos el foco
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Me.lbxTipoCobro.SelectedValue = 1 Then 'Me.lbxTipoCobro.Text = "Efectivo" 
                cmbCaja.Focus()
            ElseIf Me.lbxTipoCobro.SelectedValue = 3 Then 'Me.lbxTipoCobro.Text = "Cheque"
                cmbCaja.Focus()
            ElseIf Me.lbxTipoCobro.SelectedValue = 5 Then 'Me.lbxTipoCobro.Text = "Nota de Credito"
                tbxNotadeCredito.Focus()
            ElseIf Me.lbxTipoCobro.SelectedValue = 2 Then 'Me.lbxTipoCobro.Text = "Tarjeta"
                cmbCaja.Focus()
            ElseIf Me.lbxTipoCobro.SelectedValue = 4 Then 'Me.lbxTipoCobro.Text = "Transferencia"
                cmbCaja.Focus()
            ElseIf Me.lbxTipoCobro.SelectedValue = 6 Then 'Me.lbxTipoCobro.Text = "Retencion"
                tbxNroRetencion.Focus()
            ElseIf Me.lbxTipoCobro.SelectedValue = 7 Then 'Me.lbxTipoCobro.Text = "Ajuste de Pago"
                cmbCaja.Focus()
            ElseIf Me.lbxTipoCobro.SelectedValue = 8 Then 'Me.lbxTipoCobro.Text = "Aplique de Saldo a Favor"
                cmbCaja.Focus()
            End If
        End If
        KeyAscii = 0
    End Sub

    Private Sub tbxMonto_LostFocus(sender As Object, e As System.EventArgs) Handles tbxMonto.LostFocus
        tbxMonto.BackColor = Color.White

        If (lbxTipoCobro.SelectedValue = 5) And (tbxMonto.Text <> "") And tbxNotadeCredito.Text <> "" Then
            'si es una nota de credito debemos verificar que no cargue un monto mayor al saldo de dicha nota de credito
            SaldoNC = CInt(dgvNotaCredito.Rows(dgvNotaCredito.CurrentRow.Index).Cells("SALDODataGridViewTextBoxColumn").Value)
            If CDec(tbxMonto.Text) > SaldoNC Then
                MessageBox.Show("El Importe no Puede ser Mayor al Saldo de la Nota de Crédito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxMonto.Focus()
            End If
        End If
    End Sub

    Private Sub tbxNroRef_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNroRef.GotFocus
        tbxNroRef.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxNroRef_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroRef.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaCobroDet.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxNroRef_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroRef.LostFocus
        tbxNroRef.BackColor = Color.White
    End Sub

    Private Sub Fecha1_GotFocus(sender As Object, e As System.EventArgs) Handles dtpFechaCobroDet.GotFocus
        dtpFechaCobroDet.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub Fecha1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaCobroDet.KeyPress
        'Verificamos que tipo de Pago selecciono y de acuerdo a eso ponemos el foco
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbBanco.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub Fecha1_LostFocus(sender As Object, e As System.EventArgs) Handles dtpFechaCobroDet.LostFocus
        dtpFechaCobroDet.BackColor = Color.White
    End Sub

    Private Sub tbxConcepto_GotFocus(sender As Object, e As System.EventArgs)
        tbxConcepto.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxConcepto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPago.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxConcepto_LostFocus(sender As Object, e As System.EventArgs)
        tbxConcepto.BackColor = Color.White
    End Sub

    Private Sub tbxNotadeCredito_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNotadeCredito.GotFocus
        tbxNotadeCredito.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxNotadeCredito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNotadeCredito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPago.Focus()
            KeyAscii = 0
        End If

        If KeyAscii = 42 Then
            If ModifNC = 0 Then
                NCREDITOTableAdapter.Fill(DsCobros2.NCREDITO, CmbCliente.SelectedValue)
            End If
            gbxNotaCredito.HeaderText = "Buscador de Nota de Crédito de " + CmbCliente.Text
            cbxNotaCredito.Checked = False
            UltraPopupControlContainer2.PopupControl = gbxNotaCredito
            UltraPopupControlContainer2.Show()
            e.Handled = True
        End If

    End Sub

    Private Sub tbxNotadeCredito_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNotadeCredito.LostFocus
        tbxNotadeCredito.BackColor = Color.White
    End Sub

    Private Sub tbxNroRetencion_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNroRetencion.GotFocus
        tbxNroRetencion.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxNroRetencion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroRetencion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPago.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxNroRetencion_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroRetencion.LostFocus
        tbxNroRetencion.BackColor = Color.White
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        DeshabilitarControles()

        If saldoF = True Then
            pnlEstado.BackColor = Color.Tan
            TIPOFORMACOBROBindingSource.RemoveFilter()
        End If

        Me.CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)
        FechaFiltro()
        Me.COBROCABECERATableAdapter.Fill(Me.DsCobros3.COBROCABECERA, FechaFiltro1, FechaFiltro2)
        If dgvCobros.RowCount <> 0 Then
            FACTURAACOBRARTableAdapter1.Fill(DsCobros2.FACTURAACOBRAR, CmbCliente.SelectedValue)
            SALDOVENCIDOTableAdapter1.Fill(DsCobros2.SALDOVENCIDO, Today, CmbCliente.SelectedValue)
            ObtenerSaldoVencido() : CalcularSaldo()
        End If

        VarGlobDeudaCobar = 0
        lblCuotas.Text = "" : lblNroFacturas.Text = "" : lblPagado.Text = "" : lblSaldoFavor.Text = "" : Me.lblSaldoF.Text = "Falta Cobrar:"

        pnlFacturasaCobrar.Visible = False
        lblDetalles.Text = "Ver Detalles"
        btnDetalles.Image = My.Resources.Display

        btnAgregarPago.BringToFront()
        btnEliminarPago.BringToFront()

        ModificarDetPictureBox.Image = My.Resources.Edit
        ModificarDetPictureBox.Enabled = True

        tsEditar.Enabled = True
        btnuevo = 0 : btmodificar = 0

        dgvCobros.Enabled = True : BtnFiltro.Enabled = True : BuscarTextBox.Enabled = True : FiltroPagosActivo.Enabled = True
        TipoCobroPictureBox.Enabled = True : PendientesPago.Enabled = True : cmbGenerarRecibo.Text = ""
        ModifNC = 0 : ModifSF = 0
        saldoF = False : lblACobrar2.Visible = False : lblMontoSelec2.Visible = False : lbxTipoCobro.SelectedValue = 1
        lblProximoNro.Text = "Ver Próximo Nro. de Recibo"
    End Sub

    Private Sub btnAgregarPago_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarPago.Click
        Try
            Dim Chequeado As Boolean
            Dim CodPago, TipoFormaPago As Integer
            Dim Monto As Double

            'Choefiente Cambio
            Dim Coheficiente As String = f.FuncionConsultaString2("FACTORVENTA", "COTIZACION", "CODMONEDA", cbxMoneda.SelectedValue & " ORDER BY FECGRA DESC")
            If Coheficiente = Nothing Then
                MessageBox.Show("El coheficiente para " & cbxMoneda.Text & " es íncorrecto o no existe", "POSSEXPRESS")
                cbxMoneda.Focus()
                Exit Sub
            End If

            'Verificamos que se completen todos los campos necesarios
            If tbxMonto.Text = "" Then
                MessageBox.Show("Ingrese el Monto a Pagar", "PosExpress")
                tbxMonto.Focus()
                Exit Sub
            End If

            If CDec(tbxMonto.Text) > CDec(lblMontoSelecionado.Text) And saldoF = False Then
                MsgBox("El Monto de Cobro es superior al Monto Seleccionado a Cobrar", MsgBoxStyle.Information, "PosExpress")

                'tbxMonto.Appearance.BackColor = Color.Pink
                'Exit Sub    Se le deja Seguir Igual
            End If

            If lbxTipoCobro.SelectedValue = 1 Then 'lbxTipoCobro.Text = "Efectivo" 
                If cmbCaja.Text = "" Then
                    MessageBox.Show("Ingrese la Cuenta", "PosExpress")
                    cmbCaja.Focus()
                    Exit Sub
                End If
            ElseIf lbxTipoCobro.SelectedValue = 3 Then 'lbxTipoCobro.Text = "Cheque" 
                If cmbCaja.Text = "" Then
                    MessageBox.Show("Ingrese la Cuenta", "PosExpress")
                    cmbCaja.Focus()
                    Exit Sub
                End If
                If tbxNroRef.Text = "" Then
                    MessageBox.Show("Ingrese el Nro de Ref.", "PosExpress")
                    tbxNroRef.Focus()
                    Exit Sub
                End If
            ElseIf lbxTipoCobro.SelectedValue = 5 Then 'lbxTipoCobro.Text = "Nota de Credito"
                If tbxNotadeCredito.Text = "" Then
                    MessageBox.Show("Ingrese el Nro de la Nota de Credito", "PosExpress")
                    tbxNotadeCredito.Focus()
                    Exit Sub
                End If
                If tbxMonto.Text > SaldoNC Then
                    MessageBox.Show("El Monto Supera el Saldo de la Nota de Credito. Ingrese un Monto no superior al Saldo de la Nota de Crédito", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tbxMonto.Focus()
                    lblPagosEstado.Text = "Ingrese un Monto no superior al Saldo de la Nota de Crédito"
                    Exit Sub
                End If
            ElseIf lbxTipoCobro.SelectedValue = 2 Then 'lbxTipoCobro.Text = "Tarjeta"
                If cmbCaja.Text = "" Then
                    MessageBox.Show("Ingrese la Cuenta", "PosExpress")
                    cmbCaja.Focus()
                    Exit Sub
                End If
            ElseIf lbxTipoCobro.SelectedValue = 4 Then 'lbxTipoCobro.Text = "Transferencia"
                If cmbCaja.Text = "" Then
                    MessageBox.Show("Ingrese la Cuenta", "PosExpress")
                    cmbCaja.Focus()
                    Exit Sub
                End If
                If tbxNroRef.Text = "" Then
                    MessageBox.Show("Ingrese el Nro de Ref.", "PosExpress")
                    tbxNroRef.Focus()
                    Exit Sub
                End If
            ElseIf lbxTipoCobro.SelectedValue = 6 Then 'lbxTipoCobro.Text = "Retención Iva"
                If tbxNroRetencion.Text = "" Then
                    MessageBox.Show("Ingrese el Nro de la Retencion", "PosExpress")
                    tbxNroRetencion.Focus()
                    Exit Sub
                End If
            ElseIf lbxTipoCobro.SelectedValue = 7 Then 'lbxTipoCobro.Text = "Ajuste de Pago"
                If cmbCaja.Text = "" Then
                    MessageBox.Show("Ingrese la Cuenta", "PosExpress")
                    cmbCaja.Focus()
                    Exit Sub
                End If
                If tbxConcepto.Text = "" Then
                    MessageBox.Show("Ingrese el Concepto", "PosExpress")
                    tbxConcepto.Focus()
                    Exit Sub
                End If
            ElseIf lbxTipoCobro.SelectedValue = 8 Then 'lbxTipoCobro.Text = "Aplique Saldo a Favor"
                If cmbCaja.Text = "" Then
                    MessageBox.Show("Ingrese la Cuenta", "PosExpress")
                    cmbCaja.Focus()
                    Exit Sub
                End If
            End If

            'Verificamos si se chequeo o no algun campo de la grilla
            Chequeado = VerificarCkequet()
            Dim MonedaDestino As Integer = 0
            If CDec(lblMonedaFact.Text) = 0 Then
                MonedaDestino = cbxMoneda.SelectedValue
            Else
                MonedaDestino = CDec(lblMonedaFact.Text)
            End If

            Dim rows As Integer = dgvFacturasaCobar.RowCount
            Dim MontoPagado As Decimal = MonedaCotizacion.ConvertMoney(CDec(tbxMonto.Text), cbxMoneda.SelectedValue, CDec(tbxCotizacion.Text), MonedaDestino)
            Dim ImporteGrilla As Decimal
            Dim MaxIdApertura As Integer

            If Chequeado = True Then
                For i = 1 To rows
                    If dgvFacturasaCobar.Rows(i - 1).Cells("Cobrar").Value = True Then
                        Monto = dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value

                        If Monto <> 0 Then
                            If MontoPagado > 0 Then
                                If MontoPagado >= Monto Then
                                    dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                    ImporteGrilla = Monto
                                Else
                                    dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                    ImporteGrilla = MontoPagado
                                End If

                                'Actualizar Saldo de la NC
                                If i = 1 And lbxTipoCobro.SelectedValue = 5 Then ' Solo hace falta 1 vez
                                    If MontoPagado = SaldoNC Then
                                        dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value = "0"
                                    Else
                                        dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value = dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value - MontoPagado
                                    End If
                                End If

                                MontoPagado = Monto - MontoPagado
                                MontoPagado = MontoPagado * (-1)

                                If dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                    TipoFormaPago = 1
                                Else
                                    TipoFormaPago = 2
                                End If

                                'Insertamos en la grilla
                                'dgvFormaCobro.Rows.Add()
                                CobroDetalleBindingSource.AddNew()

                                Dim c As Integer = dgvFormaCobro.RowCount
                                If btmodificar = 1 Then
                                    If ContNewFilasEdit = 0 Then
                                        CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                        CodPago = CodPago + 1
                                        ContNewFilasEdit = ContNewFilasEdit + 1
                                    Else
                                        CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                        ContNewFilasEdit = ContNewFilasEdit + 1
                                    End If
                                Else
                                    If c = 1 Then
                                        CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                        CodPago = CodPago + 1
                                    ElseIf c > 1 Then
                                        CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                    End If
                                End If

                                Dim sinfechadet As Boolean = False
                                If dtpFechaCobroDet.Text = "" Then
                                    sinfechadet = True
                                    dtpFechaCobroDet.Value = dtpRegFechaCobro.Text
                                End If

                                Dim conctFecha As String
                                Dim conctHora As String = Now.ToString("HH:mm:ss")
                                If sinfechadet = True Then
                                    conctFecha = dtpFechaCobroDet.Value
                                Else
                                    conctFecha = dtpFechaCobroDet.Text
                                End If

                                If lbxTipoCobro.SelectedValue = 5 Then
                                    MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", lbxTipoCobro.SelectedValue)
                                    lbxTipoCobro.Text = cmbCaja.Text
                                Else
                                    MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", cmbCaja.SelectedValue)
                                End If

                                Dim conctFechaHora As String = conctFecha & " " + conctHora
                                dgvFormaCobro.Rows(c - 1).Cells("NUMVENTA1").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMVENTA").Value
                                dgvFormaCobro.Rows(c - 1).Cells("CODVENTADET").Value = dgvFacturasaCobar.Rows(i - 1).Cells("CODVENTA").Value
                                dgvFormaCobro.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                dgvFormaCobro.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoCobro.Text
                                dgvFormaCobro.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                dgvFormaCobro.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoCobro.SelectedValue
                                dgvFormaCobro.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                dgvFormaCobro.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                                dgvFormaCobro.Rows(c - 1).Cells("CUENTA").Value = cmbCaja.Text
                                dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value = MaxIdApertura
                                dgvFormaCobro.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                                dgvFormaCobro.Rows(c - 1).Cells("NUMDEVOLUCION").Value = tbxNotadeCredito.Text
                                dgvFormaCobro.Rows(c - 1).Cells("CODNRODEV").Value = txtCodDevolucion.Text
                                dgvFormaCobro.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                                dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                dgvFormaCobro.Rows(c - 1).Cells("CODMONEDA2").Value = MonedaDestino
                                dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"

                                If cmbBanco.Text = "" Then
                                    'dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = ""
                                Else
                                    dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = cmbBanco.SelectedValue
                                End If

                                lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                            End If
                        End If
                    End If
                Next
            Else ' Chequeado = False
                'Aqui si es que no se va a hacer con un button
                If saldoF = True Then
                    'Insertamos en la grilla
                    CobroDetalleBindingSource.AddNew()
                    Dim c As Integer = dgvFormaCobro.RowCount

                    ImporteGrilla = CDec(tbxMonto.Text)
                    Dim sinfechadet As Boolean = False
                    If dtpFechaCobroDet.Text = "" Then
                        sinfechadet = True
                        dtpFechaCobroDet.Value = dtpRegFechaCobro.Text
                    End If

                    Dim conctFecha As String
                    Dim conctHora As String = Now.ToString("HH:mm:ss")
                    If sinfechadet = True Then
                        conctFecha = dtpFechaCobroDet.Value
                    Else
                        conctFecha = dtpFechaCobroDet.Text
                    End If
                    Dim conctFechaHora As String = conctFecha & " " + conctHora

                    If lbxTipoCobro.SelectedValue = 5 Then
                        Dim idCaja As String = dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value
                        MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", idCaja)
                        dgvFormaCobro.Rows(1).Cells("CODCUENTA").Value = MaxIdApertura
                    Else
                        MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", cmbCaja.SelectedValue)
                    End If

                    dgvFormaCobro.Rows(c - 1).Cells("NUMVENTA1").Value = "SALDO A FAVOR"
                    dgvFormaCobro.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                    dgvFormaCobro.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoCobro.Text
                    dgvFormaCobro.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                    dgvFormaCobro.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoCobro.SelectedValue
                    dgvFormaCobro.Rows(c - 1).Cells("NROCUOTA").Value = 0
                    dgvFormaCobro.Rows(c - 1).Cells("CUENTA").Value = cmbCaja.Text
                    dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value = MaxIdApertura
                    dgvFormaCobro.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                    dgvFormaCobro.Rows(c - 1).Cells("NUMDEVOLUCION").Value = tbxNotadeCredito.Text
                    dgvFormaCobro.Rows(c - 1).Cells("CODNRODEV").Value = txtCodDevolucion.Text
                    dgvFormaCobro.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                    dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                    dgvFormaCobro.Rows(c - 1).Cells("CODMONEDA2").Value = MonedaDestino
                    dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"

                    If Not cmbBanco.Text = "" Then
                        dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = cmbBanco.SelectedValue
                    End If

                    lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla

                Else
                    For i = 1 To rows
                        Monto = dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value
                        If Monto <> 0 Then
                            If MontoPagado > 0 Then
                                If MontoPagado >= Monto Then
                                    dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                    ImporteGrilla = Monto
                                Else
                                    dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                    ImporteGrilla = MontoPagado
                                End If

                                'Actualizar Saldo de la NC
                                If i = 1 And lbxTipoCobro.SelectedValue = 5 Then ' Solo hace falta 1 vez
                                    If MontoPagado = SaldoNC Then
                                        dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value = "0"
                                    Else
                                        dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value = dgvNotaCredito.Rows(indexNC).Cells("SALDODataGridViewTextBoxColumn").Value - MontoPagado
                                    End If
                                End If

                                MontoPagado = Monto - MontoPagado
                                MontoPagado = MontoPagado * (-1)

                                If dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                    TipoFormaPago = 1
                                Else
                                    TipoFormaPago = 2
                                End If

                                'Insertamos en la grilla
                                'dgvFormaCobro.Rows.Add()
                                CobroDetalleBindingSource.AddNew()
                                Dim c As Integer = dgvFormaCobro.RowCount
                                If btmodificar = 1 Then
                                    If ContNewFilasEdit = 0 Then
                                        CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                        CodPago = CodPago + 1
                                        ContNewFilasEdit = ContNewFilasEdit + 1
                                    Else
                                        CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                        ContNewFilasEdit = ContNewFilasEdit + 1
                                    End If
                                Else
                                    If c = 1 Then
                                        CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                        CodPago = CodPago + 1
                                    ElseIf c > 1 Then
                                        CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                    End If
                                End If

                                Dim sinfechadet As Boolean = False
                                If dtpFechaCobroDet.Text = "" Then
                                    sinfechadet = True
                                    dtpFechaCobroDet.Value = dtpRegFechaCobro.Text
                                End If

                                Dim conctFecha As String
                                Dim conctHora As String = Now.ToString("HH:mm:ss")
                                If sinfechadet = True Then
                                    conctFecha = dtpFechaCobroDet.Value
                                Else
                                    conctFecha = dtpFechaCobroDet.Text
                                End If
                                Dim conctFechaHora As String = conctFecha & " " + conctHora

                                If lbxTipoCobro.SelectedValue = 5 Then
                                    Dim idCaja As String = dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value
                                    MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", idCaja)
                                    dgvFormaCobro.Rows(1).Cells("CODCUENTA").Value = MaxIdApertura
                                Else
                                    MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", cmbCaja.SelectedValue)
                                End If

                                dgvFormaCobro.Rows(c - 1).Cells("NUMVENTA1").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMVENTA").Value
                                dgvFormaCobro.Rows(c - 1).Cells("CODVENTADET").Value = dgvFacturasaCobar.Rows(i - 1).Cells("CODVENTA").Value
                                dgvFormaCobro.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                dgvFormaCobro.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoCobro.Text
                                dgvFormaCobro.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                dgvFormaCobro.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoCobro.SelectedValue
                                dgvFormaCobro.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                dgvFormaCobro.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                                dgvFormaCobro.Rows(c - 1).Cells("CUENTA").Value = cmbCaja.Text
                                dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value = MaxIdApertura
                                dgvFormaCobro.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                                dgvFormaCobro.Rows(c - 1).Cells("NUMDEVOLUCION").Value = tbxNotadeCredito.Text
                                dgvFormaCobro.Rows(c - 1).Cells("CODNRODEV").Value = txtCodDevolucion.Text
                                dgvFormaCobro.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                                dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                dgvFormaCobro.Rows(c - 1).Cells("CODMONEDA2").Value = MonedaDestino
                                dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"

                                If cmbBanco.Text = "" Then
                                    'dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = ""
                                Else
                                    dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = cmbBanco.SelectedValue
                                End If

                                lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                            End If
                        End If
                    Next
                End If
            End If
            If lbxTipoCobro.SelectedValue = 5 Then
                Me.lblSaldoF.Text = "Saldo Nota Crédito:"
            End If

            If MontoPagado < 0 Then
                Me.lblSaldoF.Text = "Falta Cobrar:"
            End If

            '  VarGlobSaldoFavor = MontoPagado

            Dim TotalOtrosDoc, TotalRecibo, TotalPagado As Double
            Try
                For i = 0 To dgvFormaCobro.RowCount - 1
                    If dgvFormaCobro.Rows(i).Cells("CODTIPOPAGO").Value = 5 Or dgvFormaCobro.Rows(i).Cells("CODTIPOPAGO").Value = 8 Or dgvFormaCobro.Rows(i).Cells("CODTIPOPAGO").Value = 7 Then
                        TotalOtrosDoc = TotalOtrosDoc + dgvFormaCobro.Rows(i).Cells("IMPORTE").Value
                    Else
                        TotalRecibo = TotalRecibo + dgvFormaCobro.Rows(i).Cells("IMPORTE").Value
                    End If
                    TotalPagado = TotalPagado + dgvFormaCobro.Rows(i).Cells("IMPORTE").Value
                Next
                LblTotalDoc.Text = FormatNumber(TotalOtrosDoc, 2)
                umeTotalRec.Text = FormatNumber(TotalRecibo, 2)

            Catch ex As Exception

            End Try

            Dim Saldo As Double
            Saldo = CDec(lblMontoSelecionado.Text) - TotalPagado
            lblSaldoFavor.Text = FormatNumber(Saldo, 2)
            lblPagado.Text = FormatNumber(TotalPagado, 2)

            If CDec(lblMonedaFact.Text) <> 0 Then
                cbxMoneda.SelectedValue = CDec(lblMonedaFact.Text)
            End If

            LimpiarDetalle()
            tbxMonto.Text = lblSaldoFavor.Text
            lbxTipoCobro.SelectedValue = 1

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEliminarPago_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarPago.Click

        Dim Totaladescontar As Double
        If dgvFormaCobro.RowCount = 0 Then
            Exit Sub
        End If

        If btmodificar = 1 And dgvFormaCobro.CurrentRow.Cells("EstadoGrilla").Value = "I" Then
            ContNewFilasEdit = ContNewFilasEdit - 1
        End If

        'Antes de eliminar debemos restaurar la grilla de Facturas a Pagar
        Dim EncontreFactura As Integer = 0
        Dim TIENENC As Integer = 0
        Dim EncontreNC As Integer = 0
        If dgvFormaCobro.CurrentRow.Cells("NUMVENTA1").Value <> "SALDO A FAVOR" Then
            For i = 0 To dgvFacturasaCobar.RowCount - 1
                If dgvFacturasaCobar.Rows(i).Cells("CODVENTA").Value = dgvFormaCobro.CurrentRow.Cells("CODVENTADET").Value Then
                    dgvFacturasaCobar.Rows(i).Cells("SALDOCUOTA").Value = dgvFacturasaCobar.Rows(i).Cells("SALDOCUOTA").Value + dgvFormaCobro.CurrentRow.Cells("IMPORTE").Value
                    Totaladescontar = Totaladescontar + dgvFormaCobro.CurrentRow.Cells("IMPORTE").Value
                    EncontreFactura = 1
                End If
            Next
        Else
            GoTo borro
        End If

        Dim STRCODDEVOLUCION As String = ""
        If Not IsDBNull(dgvFormaCobro.CurrentRow.Cells("NUMDEVOLUCION").Value) Then
            If Not Trim(dgvFormaCobro.CurrentRow.Cells("NUMDEVOLUCION").Value) = "" Then
                TIENENC = 1 'Tiene asociada una NC
                STRCODDEVOLUCION = f.FuncionConsultaString("CODDEVOLUCION", "DEVOLUCION", "NUMDEVOLUCION", dgvFormaCobro.CurrentRow.Cells("NUMDEVOLUCION").Value)
                For i = 0 To dgvNotaCredito.RowCount - 1
                    If STRCODDEVOLUCION = dgvNotaCredito.Rows(i).Cells("CODDEVOLUCION").Value Then
                        Dim suma As Integer = dgvNotaCredito.Rows(i).Cells("SALDODataGridViewTextBoxColumn").Value + dgvFormaCobro.CurrentRow.Cells("IMPORTE").Value ' Este control por si haya eliminado 2 veces, o aumenta el saldo mas que el importe
                        If suma > dgvNotaCredito.Rows(i).Cells("IMPORTEDataGridViewTextBoxColumn2").Value Then
                            dgvNotaCredito.Rows(i).Cells("SALDODataGridViewTextBoxColumn").Value = dgvNotaCredito.Rows(i).Cells("IMPORTEDataGridViewTextBoxColumn2").Value
                        Else
                            dgvNotaCredito.Rows(i).Cells("SALDODataGridViewTextBoxColumn").Value = suma
                        End If
                        EncontreNC = 1
                        ModifNC = 1
                    End If
                Next
            End If
        End If

        If btnuevo = 1 Then
            If dgvFormaCobro.CurrentRow.Cells("CODTIPOPAGO").Value <> 5 And dgvFormaCobro.CurrentRow.Cells("CODTIPOPAGO").Value <> 8 And dgvFormaCobro.CurrentRow.Cells("CODTIPOPAGO").Value <> 7 Then
                umeTotalRec.Text = CDec(umeTotalRec.Text) - Totaladescontar
            End If
            dgvFormaCobro.Rows.Remove(Me.dgvFormaCobro.CurrentRow)
            GoTo actualizarglobales
        ElseIf btmodificar = 1 And dgvFormaCobro.CurrentRow.Cells("EstadoGrilla").Value = "I" Then ' Si EstadoGrilla tiene ese valor es porque fue una fila nueva despues de darle Editar
            dgvFormaCobro.Rows.Remove(Me.dgvFormaCobro.CurrentRow)
            GoTo actualizarglobales
        End If

        If EncontreFactura = 0 Then
            FACTURAACOBRARBindingSource.AddNew()
            dgvFacturasaCobar.Rows(dgvFacturasaCobar.RowCount - 1).Cells("CODVENTA").Value = dgvFormaCobro.CurrentRow.Cells("CODVENTADET").Value
            dgvFacturasaCobar.Rows(dgvFacturasaCobar.RowCount - 1).Cells("NUMEROCUOTA").Value = dgvFormaCobro.CurrentRow.Cells("NROCUOTA").Value
            dgvFacturasaCobar.Rows(dgvFacturasaCobar.RowCount - 1).Cells("NUMVENTA").Value = dgvFormaCobro.CurrentRow.Cells("NUMVENTA1").Value
            dgvFacturasaCobar.Rows(dgvFacturasaCobar.RowCount - 1).Cells("SALDOCUOTA").Value = dgvFormaCobro.CurrentRow.Cells("IMPORTE").Value

            ser.Abrir(sqlc)
            Dim daFact As New SqlDataAdapter("Select IMPORTECUOTA,FECHAVCTO,TIPOFACTURA FROM FACTURACOBRAR WHERE CODVENTA = " & dgvFormaCobro.CurrentRow.Cells("CODVENTADET").Value & "", sqlc)
            Dim dtFact As New DataTable
            Dim drFact As DataRow

            daFact.Fill(dtFact)

            If dtFact.Rows.Count <> 0 Then
                drFact = dtFact.Rows.Item(0)
                dgvFacturasaCobar.Rows(dgvFacturasaCobar.RowCount - 1).Cells("TIPOFACTURA").Value = drFact("TIPOFACTURA")
                dgvFacturasaCobar.Rows(dgvFacturasaCobar.RowCount - 1).Cells("FECHAVCTO").Value = drFact("FECHAVCTO")
                dgvFacturasaCobar.Rows(dgvFacturasaCobar.RowCount - 1).Cells("IMPORTECUOTA").Value = drFact("IMPORTECUOTA")
            End If
            Totaladescontar = Totaladescontar + dgvFormaCobro.CurrentRow.Cells("IMPORTE").Value
        End If

        If TIENENC = 1 And EncontreNC = 0 Then
            ModifNC = 1
            NCREDITOTableAdapter.Fill(DsCobros2.NCREDITO, CmbCliente.SelectedValue)

            Dim dt As DataTable = NCREDITOTableAdapter.GetData(CmbCliente.SelectedValue)
            NCREDITOBindingSource.AllowNew = True
            NCREDITOBindingSource.AddNew()

            dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value = dgvFormaCobro.CurrentRow.Cells("NUMDEVOLUCION").Value
            dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("SALDODataGridViewTextBoxColumn").Value = dgvFormaCobro.CurrentRow.Cells("IMPORTE").Value
            dgvNotaCredito.Rows(dgvNotaCredito.RowCount - 1).Cells("DataGridViewTextBoxColumn43").Value = dgvFormaCobro.CurrentRow.Cells("NUMVENTA1").Value

            Dim daNC As New SqlDataAdapter("Select TOTALDEVOLUCION,FECHADEVOLUCION FROM DEVOLUCION WHERE CODDEVOLUCION = " & STRCODDEVOLUCION & "", sqlc)
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
borro:
        dgvFormaCobro.CurrentRow.Cells("EstadoGrilla").Value = "D"
        Me.dgvFormaCobro.CurrentRow.Cells("DESTIPOPAGO").Value = "A Eliminar"

        For i = 0 To dgvFormaCobro.ColumnCount - 1
            dgvFormaCobro.Item(i, dgvFormaCobro.CurrentRow.Index).Style.BackColor = Color.Pink
        Next

actualizarglobales:
        If lblPagado.Text <> "" Then
            lblPagado.Text = CDec(lblPagado.Text) - Totaladescontar
            lblPagado.Text = FormatNumber(CDec(lblPagado.Text), 2)
            If btnuevo <> 1 Then
                If dgvFormaCobro.CurrentRow.Cells("CODTIPOPAGO").Value <> 5 And dgvFormaCobro.CurrentRow.Cells("CODTIPOPAGO").Value <> 8 And dgvFormaCobro.CurrentRow.Cells("CODTIPOPAGO").Value <> 7 Then
                    umeTotalRec.Text = CDec(umeTotalRec.Text) - Totaladescontar
                End If
            End If
        End If

        Dim FaltaPagar As Double
        If lblSaldoFavor.Text <> "" And lblSaldoFavor.Text <> "lblSaldo" Then
            FaltaPagar = Math.Abs(CDec(lblSaldoFavor.Text))
            lblSaldoFavor.Text = FaltaPagar + Totaladescontar
            lblSaldoFavor.Text = FormatNumber(CDec(lblSaldoFavor.Text), 2)
            tbxMonto.Text = lblSaldoFavor.Text
            tbxMonto.Focus()
        End If
    End Sub

    Public Sub btnFiltrarCuentas_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrarCuentas.Click
        Dim Par1, Par2 As String
        Dim dtFecha As DateTime = DateTime.Now
        Dim dtfechadesde As DateTime = DateTime.Now
        Dim FechaDesde As String = ""
        Dim FechaHasta As String = ""

        If (cbxTipoCobro.Text <> "") Then
            Par1 = cbxTipoCobro.Text
        Else
            Par1 = "%"
        End If

        If IsDBNull(GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value) Then
            Par2 = 0
        Else
            Par2 = GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value
        End If

        Try
            Dim desde, hasta As String

            If (FechaDesde3.Text <> "  /  /    ") Then
                desde = FechaDesde3.Text
                FechaDesde = desde & " 00:00:00"
            End If

            If (FechaHasta3.Text <> "  /  /    ") Then
                hasta = FechaHasta3.Text
                FechaHasta = hasta & " 23:59:00"
            End If

            If (FechaDesde3.Text = "  /  /    ") And (FechaHasta3.Text = "  /  /    ") Then
                Me.HISTORIALPAGOSTableAdapter1.Fill(DsCobros2.HISTORIALPAGOS, Par2, Par1)
            Else
                If (FechaDesde3.Text <> "  /  /    ") And (FechaHasta3.Text <> "  /  /    ") Then
                    Me.HISTORIALPAGOSTableAdapter1.FillByFecha(DsCobros2.HISTORIALPAGOS, Par2, Par1, FechaDesde, FechaHasta)
                End If
                If (FechaDesde3.Text <> "  /  /    ") And (FechaHasta3.Text = "  /  /    ") Then
                    dtFecha = DateTime.Now
                    Dim Fecha

                    Fecha = dtFecha.ToString("dd/MM/yyyy")
                    FechaHasta = Fecha & " 23:59:00"
                    FechaHasta3.Text = Fecha

                    Me.HISTORIALPAGOSTableAdapter1.FillByFecha(DsCobros2.HISTORIALPAGOS, Par2, Par1, FechaDesde, FechaHasta)
                End If
                If (FechaDesde3.Text = "  /  /    ") And (FechaHasta3.Text <> "  /  /    ") Then
                    Me.HISTORIALPAGOSTableAdapter1.FillByFecha2(DsCobros2.HISTORIALPAGOS, Par2, Par1, FechaHasta)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub ConfirmarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ConfirmarPictureBox.Click
        If btnuevo = 1 Then ' Le agregue la condicion de boton nuevo porque con modificar, si entro a eliminar una fila, no se carga nada en lblpagado. Sara
            If CDec(lblPagado.Text) = 0 Then
                MessageBox.Show("No hay nada que cobrar!", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If dgvFormaCobro.Rows.Count = 0 Then
            MessageBox.Show("No se pagó nada aún!", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Trim(NroReciboTextBox.Text) = "" Then
            MessageBox.Show("Especifique un Nro. Recibo", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NroReciboTextBox.Focus()
            Exit Sub
        End If

        If dtpRegFechaCobro.Text = "" Or dtpRegFechaCobro.Text = "  /  /    " Then
            MessageBox.Show("Inserte la fecha del cobro", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtpRegFechaCobro.Focus()
            Exit Sub
        End If

        'verifica si ya existe el nro de recibo
        Dim Existe As String
        Dim reciboConSerie As String = ""
        Try
verificarnrorecibo:
            If NroReciboTextBox.Text <> "" Then
                reciboConSerie = Trim(NroReciboTextBox.Text) + " " + Trim(tbxNroSerie.Text)
                Existe = f.FuncionConsultaString("CABCOBRO", "VENTASFORMACOBRO", "VENTASFORMACOBRO.NRORECIBO + ' ' + ISNULL(VENTASFORMACOBRO.RECIBONROSERIE, '')", reciboConSerie)
                If Not Existe Is Nothing Then
                    If btmodificar = 1 Then
                        If Existe <> dgvCobros.CurrentRow.Cells("CABCOBRO").Value Then
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
            ModificarDet()
        End If

        'Si hubo un error al momento de guardar no debe continuar haciendo Contabilidad
        If ErrorGuardar = 0 Then
            Try
                Dim Imprimir As Integer = f.FuncionConsultaDecimal("dbo.DETPC.IMPRIMIR", " dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE", "dbo.DETPC.ACTIVO = 1 AND dbo.TIPOCOMPROBANTE.COBROS", 1)
                If Imprimir = 1 And btnuevo = 1 And saldoF = False Then
                    ImprimirReporte()
                End If
            Catch ex As Exception
            End Try
            
            If vgSaldoA = 1 Or vgApliqueAnticipo = 1 Then ' EN CASO DE QUE DE CLIC EN EL MENU "CARGAR SALDO A FAVOR" O APLICAR ANTICIPO A FACUTRA
                Dim Detalle As String = "Anticipo de Cliente / " + CmbCliente.Text
                AnticipoContabilidad(CabPagoMax, CmbCliente.SelectedValue, Detalle, vgApliqueAnticipo, SucCodigo)
                vgSaldoA = 0 : vgApliqueAnticipo = 0
            Else
                'Obtenemos los valores que se utilizaron el modulo de contabilidad - by Yolanda Zelaya 
                CobroContabilidad(CabPagoMax, CmbCliente.SelectedValue, SucCodigo)
            End If
        End If

        FechaFiltro()
        Me.CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)
        COBROCABECERATableAdapter.Fill(Me.DsCobros3.COBROCABECERA, FechaFiltro1, FechaFiltro2)
        If dgvCobros.RowCount > 0 Then
            FACTURAACOBRARTableAdapter1.Fill(DsCobros2.FACTURAACOBRAR, CmbCliente.SelectedValue)
            SALDOVENCIDOTableAdapter1.Fill(DsCobros2.SALDOVENCIDO, Today, CmbCliente.SelectedValue)
        End If

        LimpiaFormulario()
        lblMontoSelecionado.Text = "0 Gs"
        DeshabilitarControles()

        lblCuotas.Text = "" : lblNroFacturas.Text = "" : lblPagado.Text = "" : lblSaldoFavor.Text = ""

        pnlFacturasaCobrar.Visible = False
        lblDetalles.Text = "Ver Detalles"
        btnDetalles.Image = My.Resources.DisplayActive

        btnAgregarPago.BringToFront()
        btnEliminarPago.BringToFront()
        ModificarDetPictureBox.Image = My.Resources.Edit
        ModificarDetPictureBox.Enabled = True
        tsEditar.Enabled = True
        lbxTipoCobro.SelectedValue = 1
        lbxTipoCobro_SelectedIndexChanged(Nothing, Nothing) 'Forzamos porque si ya estaba en Efectivo no hace y trae mal

        If saldoF = True Then
            pnlEstado.BackColor = Color.Tan
            TIPOFORMACOBROBindingSource.RemoveFilter()
        End If

        ErrorGuardar = 0 : dgvCobros.Enabled = True : BtnFiltro.Enabled = True : BuscarTextBox.Enabled = True : FiltroPagosActivo.Enabled = True
        TipoCobroPictureBox.Enabled = True : PendientesPago.Enabled = True : cmbGenerarRecibo.Text = ""
        btnuevo = 0 : btmodificar = 0 : ModifNC = 0 : ModifSF = 0 : saldoF = False : lblACobrar2.Visible = False : lblMontoSelec2.Visible = False
        lblProximoNro.Text = "Ver Próximo Nro. de Recibo"
        vgSaldoA = 0
    End Sub

    Private Sub ImprimirReporte()
        Dim informe = New ReportesPersonalizados.Recibo
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes

        'Obtenemos el Nombre de la impresora
        impresora = ObtenerImpresora()

        informe.PrintOptions.PaperSize = GetPapersizeID(impresora, "ReciboCogent")
        informe.SetDataSource(InfFactura())
        informe.SetParameterValue("ImporteLetra", Funciones.Cadenas.NumeroaLetras(umeTotalRec.Text))

        Try
            informe.PrintOptions.PrinterName = impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "RIA")
        End Try

        informe.PrintToPrinter(1, False, 0, 0)
        informe.Close() : informe.Dispose()
    End Sub

    Public Function InfFactura() As DataSet
        Dim ds As New DsInformes
        Dim row As DataRow
        Dim CodCobro As String

        ds.Clear()

        Try
            If IsDBNull(dgvCobros.CurrentRow.Cells("CABCOBRO").Value) Then
                CodCobro = CabPagoMax
            Else
                CodCobro = dgvCobros.CurrentRow.Cells("CABCOBRO").Value
            End If

            Dim dadatoscli As New SqlDataAdapter("SELECT dbo.VENTASFORMACOBRO.CODVENTA, dbo.VENTASFORMACOBRO.COTIZACION1, dbo.VENTASFORMACOBRO.IMPORTE, dbo.VENTASFORMACOBRO.FECHACOBRO, dbo.VENTASFORMACOBRO.DESTIPOCOBRO,  " & _
                                                "dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.CODCLIENTECAB, dbo.MONEDA.DESMONEDA, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.RUC,  " & _
                                                "dbo.MONEDA.SIMBOLO, dbo.VENTASFORMACOBRO.CH_TA_TR_CODBANCO, dbo.BANCO.DESBANCO, dbo.VENTASFORMACOBRO.CH_NROCHEQUE  FROM dbo.VENTASFORMACOBRO INNER JOIN " & _
                                                "dbo.MONEDA ON dbo.VENTASFORMACOBRO.CODMONEDA = dbo.MONEDA.CODMONEDA INNER JOIN dbo.CLIENTES ON dbo.VENTASFORMACOBRO.CODCLIENTECAB = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                                                "dbo.BANCO ON dbo.VENTASFORMACOBRO.CH_TA_TR_CODBANCO = dbo.BANCO.CODBANCO WHERE dbo.VENTASFORMACOBRO.CABCOBRO = " & CodCobro, ser.CadenaConexion)
            Dim dtdatoscli As New DataTable
            dadatoscli.Fill(dtdatoscli)
            Dim drdatoscli As DataRow
            drdatoscli = dtdatoscli.Rows(0)

            row = ds.Tables("Detalle").NewRow()

            row.Item("Fecha1") = drdatoscli("FECHACOBRO")
            row.Item("Campo1") = drdatoscli("NRORECIBO")
            row.Item("Numero2") = drdatoscli("COTIZACION1")
            row.Item("Numero1") = umeTotalRec.Text
            row.Item("Campo2") = drdatoscli("SIMBOLO")
            row.Item("Campo3") = drdatoscli("NOMBRE")
            row.Item("Campo4") = drdatoscli("RUC")
            row.Item("Campo5") = drdatoscli("DESTIPOCOBRO")
            row.Item("Campo6") = drdatoscli("CH_NROCHEQUE")
            row.Item("Campo7") = drdatoscli("DESBANCO")

            ds.Tables("Detalle").Rows.Add(row)

        Catch ex As Exception
            'MessageBox.Show("Ocurrio un error al intentar Imprimir el registro" + ex.Message, "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ds.Dispose()
        Return ds
    End Function

    Function ObtenerImpresora() As String
        Dim impName As String = ""
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT dbo.DETPC.IMPRESORA FROM dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                     "WHERE (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.COBROS = 1)"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    impName = odrConfig("IMPRESORA")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try

        Return impName
    End Function

    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        Dim s As String = ""
        doctoprint.PrinterSettings.PrinterName = PrinterName '(ex."EpsonSQ-1170ESC/P2")
        For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function

    Private Sub Grabar()
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        CabPagoMax = 0
        Try
            If cmbGenerarRecibo.Text = "Automático" Then
                ActualizaRango()
            End If

            InsertaFormaPago()
            InsertaenTablasCaja()

            If saldoF = False Then
                'En Caso que sea una nota de credito debemos guardar el monto en Saldo de Ncredito
                InsertarNotaCredito()
            End If

            myTrans.Commit()

            'Por Saldo a Favor
            If saldoF = True Then
                ActualizaFacturaCobrar()
            End If

            LimpiaFormulario()
            MessageBox.Show("Cobro efectuado correctamente! ", "POSEXPRESS")
            ErrorGuardar = 0

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            Finally
            End Try
            MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS")
            ErrorGuardar = 1

        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub ActualizaFacturaCobrar()
        Dim CodCliente, CodTipoCobro As String
        Dim ImporteGS, ImporteUSS As String
        CodCliente = CmbCliente.SelectedValue

        For i = 0 To dgvFormaCobro.RowCount - 1
            CodTipoCobro = dgvFormaCobro.Rows(i).Cells("CODTIPOPAGO").Value

            ImporteGS = System.Math.Abs(dgvFormaCobro.Rows(i).Cells("IMPORTE").Value)
            ImporteGS = MonedaCotizacion.ConvertMoney(ImporteGS, cbxMoneda.SelectedValue, CDec(tbxCotizacion.Text), CODMONEDAPRINCIPAL)
            ImporteGS = Funciones.Cadenas.QuitarCad(ImporteGS, ".")
            ImporteGS = Replace(ImporteGS, ",", ".")

            ImporteUSS = System.Math.Abs(dgvFormaCobro.Rows(i).Cells("IMPORTE").Value)
            ImporteUSS = Funciones.Cadenas.QuitarCad(ImporteUSS, ".")
            ImporteUSS = Replace(ImporteUSS, ",", ".")
            ImporteUSS = "-" & ImporteUSS

            'Importe = dgvFormaCobro.Rows(i).Cells("IMPORTE").Value
            'Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
            'Importe = Replace(Importe, ",", ".")

            sql = ""
            sql = "DECLARE @CODCOBRO INT,@IDFORMACOBRAR INT " & _
                         " SELECT @CODCOBRO=MAX(CODCOBRO) FROM VENTASFORMACOBRO WHERE CODVENTA IS NULL AND NROCUOTA = 0 AND CODCLIENTECAB=" & CodCliente & " AND IMPORTE= " & ImporteGS & " AND CODTIPOCOBRO=" & CodTipoCobro & " " & vbCrLf & _
                         " SELECT @IDFORMACOBRAR=MAX(IDFORMACOBRAR) FROM FACTURACOBRAR WHERE CODVENTA IS NULL AND CODNUMEROCUOTA = 0 AND IDCLIENTE=" & CodCliente & " AND IMPORTECUOTA= " & ImporteUSS & " AND PAGADO=" & CodTipoCobro & " " & _
                     "UPDATE FACTURACOBRAR SET TIPOFACTURA = @CODCOBRO WHERE IDFORMACOBRAR=@IDFORMACOBRAR "
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub ModificarDet()
        ser.Abrir(sqlc)
        ser2.Abrir(sqlc2)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        CabPagoMax = 0
        Try

            'MODIFICA LO QUE HAY QUE MODIFICAR
            ModificarVentasFormaCobro()

            If ErrorGuardar = 0 Then
                If cmbGenerarRecibo.Text = "Automático" Then
                    ActualizaRango()
                End If

                myTrans.Commit()
                ErrorGuardar = 0
            End If

            LimpiaFormulario()
            'MessageBox.Show("Cobro actualizado correctamente! ", "POSEXPRESS")

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

    Private Sub editarTablaMovimientos()

        Dim c As Integer = dgvFormaCobro.RowCount

        For i = 1 To c
            If dgvFormaCobro.Rows(i - 1).Cells("ESTADOGRILLA").Value = "D" Then

            End If
        Next
    End Sub

    Private Sub ModificarVentasFormaCobro()

        Dim CodPago, CodVenta, CodTipoPago, CodMoneda, Cotizacion1, Importe, DesTipoPago, NroCuota, NroRecibo, NroRef, NroNotaCredito, NroRetencion, FechaPago, FechaRegCobro, CodBanco As String
        Dim MaxIdApertura, CabPago, CodTipoFormaPago, CodAutorizado As Integer
        NroRecibo = NroReciboTextBox.Text
        Dim c As Integer = dgvFormaCobro.RowCount

        For i = 1 To c ' Siempre habrá igual o mayor cant. de las originales porque no se eliminan las filas 
            CodPago = dgvFormaCobro.Rows(i - 1).Cells("CODPAGO").Value

            If dgvFormaCobro.Rows(i - 1).Cells("NUMVENTA1").Value = "SALDO A FAVOR" Then
                Dim objCommandSF As New SqlCommand
                Try
                    objCommandSF.CommandText = "SELECT IDCLIENTE FROM FACTURACOBRAR WHERE TIPOFACTURA ='" & CodPago & "'"
                    objCommandSF.Connection = sqlc
                    objCommandSF.Transaction = myTrans
                    Dim odrConfigSF As SqlDataReader = objCommandSF.ExecuteReader()

                    If odrConfigSF.HasRows Then
                    Else
                        MessageBox.Show("El Saldo a Favor A Eliminar ya se encuentra Aplicado. Favor Elimine Primero la Aplicación del Saldo, luego el presente Recibo", "POSEXPRESS")
                        ErrorGuardar = 1
                        Exit Sub
                    End If

                    odrConfigSF.Close()
                    objCommandSF.Dispose()
                Catch ex As Exception
                End Try
            End If

            If dgvFormaCobro.Rows(i - 1).Cells("NUMVENTA1").Value <> "SALDO A FAVOR" Then
                CodVenta = dgvFormaCobro.Rows(i - 1).Cells("CODVENTADET").Value
            Else
                CodVenta = ""
            End If
            DesTipoPago = dgvFormaCobro.Rows(i - 1).Cells("DESTIPOPAGO").Value
            CodTipoPago = dgvFormaCobro.Rows(i - 1).Cells("CODTIPOPAGO").Value
            NroCuota = dgvFormaCobro.Rows(i - 1).Cells("NROCUOTA").Value
            NroNotaCredito = dgvFormaCobro.Rows(i - 1).Cells("NUMDEVOLUCION").Value.ToString
            NroRetencion = dgvFormaCobro.Rows(i - 1).Cells("NUMRETENCION").Value.ToString
            NroRef = dgvFormaCobro.Rows(i - 1).Cells("NROREF").Value.ToString
            CodMoneda = cbxMoneda.SelectedValue

            CodTipoFormaPago = dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value
            CodAutorizado = cbxPagador.SelectedValue

            If dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value Is Nothing Or dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value.ToString = "" Then
                CodBanco = 0
            Else
                CodBanco = dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value.ToString
            End If

            Dim conctHora As String = Now.ToString("HH:mm:ss")
            Dim conctFecha As String = dtpRegFechaCobro.Text
            Dim conctFechaHora As String = conctFecha & " " + conctHora
            FechaRegCobro = conctFechaHora

            Dim fechapago2 As Date = dgvFormaCobro.Rows(i - 1).Cells("FECHAPAGO").Value
            FechaPago = fechapago2.ToString("dd/MM/yyy")
            FechaPago = FechaPago & " " & Now.ToString("HH:mm:ss")

            Cotizacion1 = tbxCotizacion.Text
            Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
            Cotizacion1 = Replace(Cotizacion1, ",", ".")

            Importe = System.Math.Abs(dgvFormaCobro.Rows(i - 1).Cells("IMPORTE").Value)
            Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
            Importe = Replace(Importe, ",", ".")

            Dim Caja As String = dgvFormaCobro.Rows(i - 1).Cells("CUENTA").Value
            Dim idcaja As Integer = f.FuncionConsulta("NUMCAJA", "CAJA", "NUMEROCAJA", Caja)
            MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", idcaja)

            sql = ""
            If dgvFormaCobro.Rows(i - 1).Cells("EstadoGrilla").Value = "" Then
                Dim fechastr As String = CDate(dgvCobros.CurrentRow.Cells("FECHAREGISTROCOB").Value).ToString("dd/MM/yyy")
                If fechastr <> dtpRegFechaCobro.Text Then
                    sql = "UPDATE movimientos SET fecha_mto= CONVERT (DATETIME,'" & FechaRegCobro & "',103) WHERE id_cobro = " & CodPago & ""
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    sql = ""

                    sql = "UPDATE CLIENTESCUENTACORRIENTE SET FECHACLIENTEMOV= CONVERT (DATETIME,'" & FechaRegCobro & "',103) WHERE CODCOBRO = " & CodPago & ""
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    sql = ""
                End If

                sql = "UPDATE VENTASFORMACOBRO SET CODMONEDA= " & CodMoneda & ", COTIZACION1= " & Cotizacion1 & ", " & _
                     "CODUSUARIO= " & UsuCodigo & ", NRORECIBO= '" & NroRecibo & "', AUTORIZADO = " & CodAutorizado & ", OBSERVACIONES = '" & tbxObservaciones.Text & "' ,FECHACOBRO= CONVERT(DATETIME,'" & FechaRegCobro & "',103), FECHAREGISTROCOB= CONVERT(DATETIME,'" & FechaRegCobro & "',103), RECIBONROSERIE = '" & tbxNroSerie.Text & "'  WHERE CODCOBRO=" & CodPago & " "
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

            ElseIf dgvFormaCobro.Rows(i - 1).Cells("EstadoGrilla").Value = "I" Then

                CabPago = dgvCobros.CurrentRow.Cells("CABCOBRO").Value

                sql = "INSERT INTO VENTASFORMACOBRO (CODVENTA, CODTIPOCOBRO, CODMONEDA, COTIZACION1, IMPORTE, DESTIPOCOBRO, FECHACOBRO, " & _
               "CH_NROCHEQUE,CODUSUARIO,NROCUOTA, NRORECIBO,  NUMDEVOLUCION, NUMRETENCION,id_apertura,CABCOBRO,TIPOCOBRO,AUTORIZADO,OBSERVACIONES,FECHAREGISTROCOB,CH_TA_TR_CODBANCO,RECIBONROSERIE, CODCLIENTECAB) " & _
               "VALUES (" & CodVenta & ", " & CodTipoPago & ", " & CodMoneda & ", " & Cotizacion1 & ", " & _
               Importe & ", '" & DesTipoPago & "', CONVERT (DATETIME,'" & FechaPago & "',103), '" & NroRef & "', " & UsuCodigo & _
               ", " & NroCuota & ",'" & NroRecibo & "', '" & NroNotaCredito & "', '" & NroRetencion & "'," & idcaja & ", " & CabPago & ", " & CodTipoFormaPago & "," & CodAutorizado & ", '" & tbxObservaciones.Text & "', CONVERT (DATETIME,'" & FechaRegCobro & "',103), " & CodBanco & ", '" & tbxNroSerie.Text & "', " & CmbCliente.SelectedValue & ")"
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                sql = ""

                ''descontar del Saldo FacturaCobrar
                sql = "DECLARE @PAGADO INT,@CODIGO NUMERIC(18,0), @SALDO AS NUMERIC(18,5) " & _
                  "SELECT @SALDO=SALDOCUOTA FROM FACTURACOBRAR  WHERE CODVENTA = " & CodVenta & " AND CODNUMEROCUOTA =  " & NroCuota & " " & vbCrLf & _
                  "IF @SALDO<=" & Importe & " " & _
                  "begin  SET @PAGADO =1 End " & _
                  "ELSE begin SET @PAGADO =0 End " & _
                  "UPDATE FACTURACOBRAR SET SALDOCUOTA = SALDOCUOTA- " & Importe & ",PAGADO=@PAGADO " & _
                  "WHERE CODVENTA = " & CodVenta & " AND CODNUMEROCUOTA = " & NroCuota & " "
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                ''descontar saldo de Nota de Credito
                If NroNotaCredito <> "" Or NroNotaCredito <> Nothing Then
                    Dim CodNotaCredito As String = ""
                    Dim objCommand As New SqlCommand
                    Try
                        objCommand.CommandText = "SELECT CODDEVOLUCION FROM DEVOLUCION WHERE NUMDEVOLUCION = '" & NroNotaCredito & "'"
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
                      "SELECT @SALDO=SALDO FROM DEVOLUCION " & _
                      "WHERE CODDEVOLUCION = " & CodNotaCredito & " " & vbCrLf & _
                      "IF @SALDO<=" & Importe & " " & _
                      "begin " & _
                      "SET @PAGADO =1 " & _
                      "End " & _
                      "else " & _
                      "begin " & _
                      "SET @PAGADO =0 " & _
                      "End " & _
                      "UPDATE DEVOLUCION SET SALDO = (SALDO - " & Importe & "),COBRADO=@PAGADO " & _
                      "WHERE CODDEVOLUCION = " & CodNotaCredito & " "

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If


            ElseIf dgvFormaCobro.Rows(i - 1).Cells("EstadoGrilla").Value = "D" Then

                ''eliminar el movimiento de Movimientos
                sql = "DELETE movimientos WHERE id_cobro = " & CodPago & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                sql = ""
                sql = " DELETE CLIENTESCUENTACORRIENTE WHERE CODCOBRO= " & CodPago & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                sql = ""

                sql = ""
                sql = " DELETE VENTASFORMACOBRO WHERE CODCOBRO= " & CodPago & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                sql = ""

                If dgvFormaCobro.Rows(i - 1).Cells("NUMVENTA1").Value = "SALDO A FAVOR" Then
                    sql = " DELETE FACTURACOBRAR WHERE TIPOFACTURA='" & CodPago & "'"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                Else
                    sql = "UPDATE FACTURACOBRAR SET PAGADO=0, SALDOCUOTA = SALDOCUOTA + " & Importe & " " & _
                    "WHERE CODVENTA = " & CodVenta & " AND CODNUMEROCUOTA = " & NroCuota & " "
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    sql = ""

                    ''incrementar saldo de Nota de Credito
                    If NroNotaCredito <> "" Or NroNotaCredito <> Nothing Then
                        ''incrementar Saldo FacturaCobrar
                        Dim CodNotaCredito As String = ""
                        Dim objCommand As New SqlCommand
                        Try
                            objCommand.CommandText = "SELECT CODDEVOLUCION FROM DEVOLUCION WHERE NUMDEVOLUCION = '" & NroNotaCredito & "'"
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
                        sql = " UPDATE DEVOLUCION SET COBRADO = 0, SALDO = (SALDO + " & Importe & ") WHERE CODDEVOLUCION = " & CodNotaCredito

                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub ActualizaRango()
        Try
            sql = ""

            sql = "UPDATE DETPC SET ULTIMO = " & NroReciboTextBox.Text & " where RANDOID=" & IDRangoRecibos & ""

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub InsertaFormaPago()
        Dim CodVenta, CodTipoPago, CodMoneda, Cotizacion1, Importe, DesTipoPago, NroCuota, NroRecibo, NroRef, NroNotaCredito, NroRetencion, FechaPago, FechaRegCobro, CodBanco As String
        Dim MaxIdApertura, CabPago, CodTipoFormaPago, CodAutorizado As Integer
        Dim c As Integer = dgvFormaCobro.RowCount

        CodVenta = ""
        NroRecibo = NroReciboTextBox.Text
        CabPago = f.Maximo("CABCOBRO", "VENTASFORMACOBRO")
        CabPago = CabPago + 1
        CabPagoMax = CabPago

        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim Concat As String = dtpRegFechaCobro.Text
        Dim Concatenar As String = Concat & " " + hora
        FechaRegCobro = Concatenar

        For i = 1 To c
            If saldoF = False Then
                CodVenta = dgvFormaCobro.Rows(i - 1).Cells("CODVENTADET").Value
            End If
            DesTipoPago = dgvFormaCobro.Rows(i - 1).Cells("DESTIPOPAGO").Value
            CodTipoPago = dgvFormaCobro.Rows(i - 1).Cells("CODTIPOPAGO").Value
            NroCuota = dgvFormaCobro.Rows(i - 1).Cells("NROCUOTA").Value
            NroNotaCredito = dgvFormaCobro.Rows(i - 1).Cells("NUMDEVOLUCION").Value
            NroRetencion = dgvFormaCobro.Rows(i - 1).Cells("NUMRETENCION").Value
            NroRef = dgvFormaCobro.Rows(i - 1).Cells("NROREF").Value
            CodMoneda = dgvFormaCobro.Rows(i - 1).Cells("CODMONEDA2").Value


            CodTipoFormaPago = dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value
            CodAutorizado = cbxPagador.SelectedValue
            CodBanco = dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value.ToString

            Dim fechapago2 As Date = dgvFormaCobro.Rows(i - 1).Cells("FECHAPAGO").Value
            FechaPago = fechapago2.ToString("dd/MM/yyy")
            FechaPago = FechaPago & " " & Now.ToString("HH:mm:ss")

            Cotizacion1 = tbxCotizacion.Text
            Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
            Cotizacion1 = Replace(Cotizacion1, ",", ".")

            Importe = System.Math.Abs(dgvFormaCobro.Rows(i - 1).Cells("IMPORTE").Value)
            Importe = MonedaCotizacion.ConvertMoney(Importe, CDec(CodMoneda), CDec(tbxCotizacion.Text), CODMONEDAPRINCIPAL)
            Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
            Importe = Replace(Importe, ",", ".")

            MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", cmbCaja.SelectedValue)

            Dim aux As Integer
            If Not dgvFormaCobro.Rows(i - 1).Cells("SFCODCOBRO").Value Is DBNull.Value Then
                aux = dgvFormaCobro.Rows(i - 1).Cells("SFCODCOBRO").Value
            End If


            sql = ""
            If saldoF = False Then 'CARGA DE SALDO A FAVOR NO
                If CodBanco = "" Or CodBanco Is Nothing Then
                    sql = "INSERT INTO VENTASFORMACOBRO (CODVENTA, CODTIPOCOBRO, CODMONEDA, COTIZACION1, IMPORTE, DESTIPOCOBRO, FECHACOBRO, " & _
                      "CH_NROCHEQUE, NROCUOTA, NRORECIBO,  NUMDEVOLUCION, NUMRETENCION,id_apertura,CABCOBRO,TIPOCOBRO,AUTORIZADO,OBSERVACIONES,FECHAREGISTROCOB,RECIBONROSERIE,CODCLIENTECAB, CODUSUARIO, NROANTICIPO) " & _
                      "VALUES (" & CodVenta & ", " & CodTipoPago & ", " & CodMoneda & ", " & Cotizacion1 & ", " & Importe & ", '" & DesTipoPago & "', CONVERT(DATETIME,'" & FechaPago & "',103), '" & NroRef & "'" & _
                      ", " & NroCuota & ",'" & NroRecibo & "', '" & NroNotaCredito & "', '" & NroRetencion & "'," & MaxIdApertura & ", " & CabPagoMax & ", " & CodTipoFormaPago & "," & CodAutorizado & ", '" & tbxObservaciones.Text & "', CONVERT (DATETIME,'" & FechaRegCobro & "',103), '" & tbxNroSerie.Text & "'," & CmbCliente.SelectedValue & "," & UsuCodigo & ", " & aux & ")"
                Else
                    sql = "INSERT INTO VENTASFORMACOBRO (CODVENTA, CODTIPOCOBRO, CODMONEDA, COTIZACION1, IMPORTE, DESTIPOCOBRO, FECHACOBRO, " & _
                          "CH_NROCHEQUE, NROCUOTA, NRORECIBO,  NUMDEVOLUCION, NUMRETENCION,id_apertura,CABCOBRO,TIPOCOBRO,AUTORIZADO,OBSERVACIONES,FECHAREGISTROCOB,CH_TA_TR_CODBANCO,RECIBONROSERIE,CODCLIENTECAB,CODUSUARIO,  NROANTICIPO) " & _
                          "VALUES (" & CodVenta & ", " & CodTipoPago & ", " & CodMoneda & ", " & Cotizacion1 & ", " & Importe & ", '" & DesTipoPago & "', CONVERT(DATETIME,'" & FechaPago & "',103), '" & NroRef & "'" & _
                          ", " & NroCuota & ",'" & NroRecibo & "', '" & NroNotaCredito & "', '" & NroRetencion & "'," & MaxIdApertura & ", " & CabPagoMax & ", " & CodTipoFormaPago & "," & CodAutorizado & ", '" & tbxObservaciones.Text & "', CONVERT (DATETIME,'" & FechaRegCobro & "',103), " & CodBanco & ", '" & If(tbxNroSerie.Text Is Nothing, 0, tbxNroSerie.Text) & "'," & CmbCliente.SelectedValue & "," & UsuCodigo & ", " & aux & ")"
                End If
            Else 'CARGA DE SALDO A FAVOR SI
                If CodBanco = "" Or CodBanco Is Nothing Then
                    sql = "INSERT INTO VENTASFORMACOBRO (CODTIPOCOBRO, CODMONEDA, COTIZACION1, IMPORTE, DESTIPOCOBRO, FECHACOBRO, " & _
                      "CH_NROCHEQUE, NROCUOTA, NRORECIBO,  NUMDEVOLUCION, NUMRETENCION,id_apertura,CABCOBRO,TIPOCOBRO,AUTORIZADO,OBSERVACIONES,FECHAREGISTROCOB,RECIBONROSERIE,CODCLIENTECAB,CODUSUARIO, NROANTICIPO ) " & _
                      "VALUES (" & CodTipoPago & ", " & CodMoneda & ", " & Cotizacion1 & ", " & Importe & ", '" & DesTipoPago & "', CONVERT(DATETIME,'" & FechaPago & "',103), '" & NroRef & "'" & _
                      ", " & NroCuota & ",'" & NroRecibo & "', '" & NroNotaCredito & "', '" & NroRetencion & "'," & MaxIdApertura & ", " & CabPagoMax & ", " & CodTipoFormaPago & "," & CodAutorizado & ", '" & tbxObservaciones.Text & "', CONVERT (DATETIME,'" & FechaRegCobro & "',103), '" & tbxNroSerie.Text & "'," & CmbCliente.SelectedValue & "," & UsuCodigo & " , " & aux & ")"
                Else
                    sql = "INSERT INTO VENTASFORMACOBRO (CODTIPOCOBRO, CODMONEDA, COTIZACION1, IMPORTE, DESTIPOCOBRO, FECHACOBRO, " & _
                          "CH_NROCHEQUE, NROCUOTA, NRORECIBO,  NUMDEVOLUCION, NUMRETENCION,id_apertura,CABCOBRO,TIPOCOBRO,AUTORIZADO,OBSERVACIONES,FECHAREGISTROCOB,CH_TA_TR_CODBANCO,RECIBONROSERIE,CODCLIENTECAB,CODUSUARIO, NROANTICIPO) " & _
                          "VALUES (" & CodTipoPago & ", " & CodMoneda & ", " & Cotizacion1 & ", " & Importe & ", '" & DesTipoPago & "', CONVERT(DATETIME,'" & FechaPago & "',103), '" & NroRef & "'" & _
                          ", " & NroCuota & ",'" & NroRecibo & "', '" & NroNotaCredito & "', '" & NroRetencion & "'," & MaxIdApertura & ", " & CabPagoMax & ", " & CodTipoFormaPago & "," & CodAutorizado & ", '" & tbxObservaciones.Text & "', CONVERT (DATETIME,'" & FechaRegCobro & "',103), " & CodBanco & ", '" & tbxNroSerie.Text & "'," & CmbCliente.SelectedValue & "," & UsuCodigo & ", " & aux & ")"
                End If
            End If
            If CodTipoPago = 8 Then
                sql = sql + " UPDATE FACTURACOBRAR SET CODNUMEROCUOTA = 1 WHERE IDFORMACOBRAR= " & dgvFormaCobro.Rows(i - 1).Cells("SFCODCOBRO").Value
            End If

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub InsertaenTablasCaja()
        Dim CodVenta, CodCobro, NumVenta, Cotz, NroCuota, NroRecibo As String
        Dim c As Integer = dgvFormaCobro.RowCount
        Dim Importe As String


        NroCuota = "" : CodVenta = ""
        NroRecibo = NroReciboTextBox.Text


        For i = 1 To c
            If saldoF = False Then
                CodCobro = dgvFormaCobro.Rows(i - 1).Cells("CODPAGO").Value
                CodVenta = dgvFormaCobro.Rows(i - 1).Cells("CODVENTADET").Value
                NumVenta = dgvFormaCobro.Rows(i - 1).Cells("NUMVENTA1").Value
                NroCuota = dgvFormaCobro.Rows(i - 1).Cells("NROCUOTA").Value
            End If

            Dim CodtipoCobro As String = dgvFormaCobro.Rows(i - 1).Cells("CODTIPOPAGO").Value

            Importe = dgvFormaCobro.Rows(i - 1).Cells("IMPORTE").Value
            Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
            Importe = Replace(Importe, ",", ".")

            Cotz = tbxCotizacion.Text
            Cotz = Funciones.Cadenas.QuitarCad(Cotz, ".")
            Cotz = Replace(Cotz, ",", ".")


            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = CDate(dtpRegFechaCobro.Value).ToShortDateString
            Dim Concatenar As String = Concat & " " + hora

            If saldoF = True Then
                sql = ""

                Importe = "-" & Importe
                'En PAGADO INSERTAMOS CodTipoPago Como un Control MAS
                sql = "INSERT INTO FACTURACOBRAR (CODNUMEROCUOTA,CODUSUARIO,FECGRA,SALDOCUOTA,IMPORTECUOTA,PAGADO,IDCLIENTE,COTIZACION ) " & _
                "VALUES (0," & UsuCodigo & ",CONVERT(Datetime,'" & Concatenar & "',103) ," & Importe & "," & Importe & "," & CodtipoCobro & "," & CmbCliente.SelectedValue & "," & Cotz & ") "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Else

                sql = ""
                sql = "DECLARE @PAGADO INT,@CODIGO NUMERIC(18,0), @SALDO AS NUMERIC(18,5) " & _
                      "SELECT @SALDO=SALDOCUOTA FROM FACTURACOBRAR  WHERE CODVENTA = " & CodVenta & " AND CODNUMEROCUOTA =  " & NroCuota & " " & vbCrLf & _
                      "IF @SALDO<=" & Importe & " " & _
                        "begin  SET @PAGADO =1 End " & _
                      "ELSE begin SET @PAGADO =0 End " & _
                      "UPDATE FACTURACOBRAR SET SALDOCUOTA = SALDOCUOTA- " & Importe & ",PAGADO=@PAGADO " & _
                      "WHERE CODVENTA = " & CodVenta & " AND CODNUMEROCUOTA = " & NroCuota & " "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
        Next
        If saldoF = False Then
            VarGlobNroVenta = CodVenta
        End If

    End Sub

    Private Sub InsertarNotaCredito()
        Dim Importe, NroNotaCredito, CodNotaCredito As String
        Dim c As Integer = dgvFormaCobro.RowCount

        For i = 1 To c
            NroNotaCredito = dgvFormaCobro.Rows(i - 1).Cells("NUMDEVOLUCION").Value
            CodNotaCredito = dgvFormaCobro.Rows(i - 1).Cells("CODNRODEV").Value

            Importe = System.Math.Abs(dgvFormaCobro.Rows(i - 1).Cells("IMPORTE").Value)
            Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
            Importe = Replace(Importe, ",", ".")

            If NroNotaCredito <> "" Or NroNotaCredito <> Nothing Then
                sql = ""
                sql = " DECLARE @PAGADO INT,@CODIGO NUMERIC(18,0), @SALDO AS NUMERIC(18,5) " & _
                  "SELECT @SALDO=SALDO FROM DEVOLUCION " & _
                  "WHERE CODDEVOLUCION = " & CodNotaCredito & " " & vbCrLf & _
                  "IF @SALDO<=" & Importe & " " & _
                  "begin " & _
                  "SET @PAGADO =1 " & _
                  "End " & _
                  "else " & _
                  "begin " & _
                  "SET @PAGADO =0 " & _
                  "End " & _
                  "UPDATE DEVOLUCION SET SALDO = (SALDO - " & Importe & "),COBRADO=@PAGADO " & _
                  "WHERE CODDEVOLUCION = " & CodNotaCredito & " "
                ''sql = "UPDATE NCREDITO SET SALDO = (SALDO - " & Importe & ") WHERE CODDEVOLUCION = " & CodNotaCredito & _
                'sql = " UPDATE DEVOLUCION SET COBRADO = 1, SALDO = (SALDO - " & Importe & ") WHERE CODDEVOLUCION = " & CodNotaCredito

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub RegistrarSaldo()
        Dim SaldoFavor As String = VarGlobSaldoFavor
        SaldoFavor = Replace(SaldoFavor, ",", ".")
        SaldoFavor = "-" + SaldoFavor

        sql = ""
        sql = "INSERT FACTURACOBRAR (CODVENTA,CODNUMEROCUOTA,SALDOCUOTA,IMPORTECUOTA,CODEMPRESA,CODUSUARIO,PAGADO, DESTIPOCOBRO,CODTIPOCOBRO,TIPOFACTURA,FECGRA)" & _
              "VALUES (" & VarGlobNroVenta & ", 0, " & SaldoFavor & "," & SaldoFavor & "," & EmpCodigo & "," & UsuCodigo & ",0,'EFECTIVO',1, 'SALDO A FAVOR',GETDATE())"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ModifSaldoAFavor()

        sql = ""
        sql = "DELETE FACTURACOBRAR WHERE CODVENTA=" & VarGlobNroVenta & " AND CODNUMEROCUOTA= 0 AND TIPOFACTURA='SALDO A FAVOR'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub PagosActivo_Click(sender As System.Object, e As System.EventArgs) Handles PagosActivo.Click
        ControlFiltro1 = 1 : ControlFiltro2 = 0 : ControlFiltro3 = 0
        MenuCobros.Enabled = True
        panelactivo = "SplitCobros"

        If btnuevo = 0 Then
            FechaFiltro()

            Me.COBROCABECERATableAdapter.Fill(Me.DsCobros3.COBROCABECERA, FechaFiltro1, FechaFiltro2)
            CobroCabeceraBindingSource.Position = indexcobro

            If dgvCobros.RowCount <> 0 Then
                FACTURAACOBRARTableAdapter1.Fill(DsCobros2.FACTURAACOBRAR, CmbCliente.SelectedValue)
                SALDOVENCIDOTableAdapter1.Fill(DsCobros2.SALDOVENCIDO, Today, CmbCliente.SelectedValue)

                CalcularSaldo()
                ObtenerSaldoVencido()
            End If

            PanelCobroCuotas.BringToFront()
            DeshabilitarControles()

            pnlNotaCredito.Visible = False : pnlRetencion.Visible = False : pnlBlanco.Visible = True
            pnlBlanco.BringToFront()
            pnlBancario.Visible = False

            pnlFacturasaCobrar.Visible = False : tbxConcepto.Visible = False : lblConcepto.Visible = False : lblConceptoAyuda.Visible = False
            pnlFacturasaCobrar.SendToBack()
        End If

        splitCobros.BringToFront()

        dgvCobros.Enabled = True : BtnFiltro.Enabled = True : BuscarTextBox.Enabled = True

        PagosActivo.Image = My.Resources.PaymentActive
        PagosActivo.Cursor = Cursors.Arrow
        FiltroPagosActivo.Image = My.Resources.User
        FiltroPagosActivo.Cursor = Cursors.Hand
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        TipoCobroPictureBox.Cursor = Cursors.Hand
        PendientesPago.Image = My.Resources.Create
        PendientesPago.Cursor = Cursors.Hand

        PictureBox2.Visible = True : BuscarTextBox.Visible = True : NuevoPictureBox.Visible = True : EliminarPictureBox.Visible = True : ModificarDetPictureBox.Visible = True
        CancelarPictureBox.Visible = True : ConfirmarPictureBox.Visible = True
    End Sub

    Public Sub ChequearGrilla()
        If VentasCobro = 1 Then
            For i = 0 To dgvFacturasaCobar.RowCount - 1
                If dgvFacturasaCobar.Rows(i).Cells("CODVENTA").Value = CodigoVenta Then
                    dgvFacturasaCobar.Enabled = True
                    dgvFacturasaCobar.Rows(i).Cells("Cobrar").Value = True
                End If
            Next
        End If
    End Sub

    Private Sub btnFiltrarCtaCte_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrarCtaCte.Click
        Dim par1 As String

        If IsDBNull(GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value) Then
            par1 = 0
        Else
            par1 = GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value
        End If

        If chbxEsconderSaldoCero.Checked = True Then
            If (Fecha1Filtro.Text = "  /  /    ") And (Fecha2Filtro.Text = "  /  /    ") Then
                Me.FiltroCobroSaldoTableAdapter1.Fill(Me.DsCobros2.FiltroCobroSaldo, par1)
            Else
                If (Fecha1Filtro.Text <> "  /  /    ") And (Fecha2Filtro.Text <> "  /  /    ") Then
                    Me.FiltroCobroSaldoTableAdapter1.FillByFecha(Me.DsCobros2.FiltroCobroSaldo, par1, Fecha1Filtro.Text, Fecha2Filtro.Text)
                End If
                If (Fecha1Filtro.Text <> "  /  /    ") And (Fecha2Filtro.Text = "  /  /    ") Then
                    Dim dtFecha As DateTime = DateTime.Now
                    Dim Fecha

                    Fecha = dtFecha.ToString("dd/MM/yyyy")
                    Fecha2Filtro.Text = Fecha

                    Me.FiltroCobroSaldoTableAdapter1.FillByFecha(Me.DsCobros2.FiltroCobroSaldo, par1, Fecha1Filtro.Text, Fecha2Filtro.Text)

                End If
                If (Fecha1Filtro.Text = "  /  /    ") And (Fecha2Filtro.Text <> "  /  /    ") Then
                    Me.FiltroCobroSaldoTableAdapter1.FillBySinCerosUnaFecha(Me.DsCobros2.FiltroCobroSaldo, par1, Fecha2Filtro.Text)
                End If
            End If

        ElseIf chbxEsconderSaldoCero.Checked = False Then
            If (Fecha1Filtro.Text = "  /  /    ") And (Fecha2Filtro.Text = "  /  /    ") Then
                Me.FiltroCobroSaldoTableAdapter1.FillBy(Me.DsCobros2.FiltroCobroSaldo, par1)
            Else
                If (Fecha1Filtro.Text <> "  /  /    ") And (Fecha2Filtro.Text <> "  /  /    ") Then
                    Me.FiltroCobroSaldoTableAdapter1.FillByConCeroFecha(Me.DsCobros2.FiltroCobroSaldo, par1, Fecha1Filtro.Text, Fecha2Filtro.Text)
                End If
                If (Fecha1Filtro.Text <> "  /  /    ") And (Fecha2Filtro.Text = "  /  /    ") Then
                    Dim dtFecha As DateTime = DateTime.Now
                    Dim Fecha

                    Fecha = dtFecha.ToString("dd/MM/yyyy")
                    Fecha2Filtro.Text = Fecha

                    Me.FiltroCobroSaldoTableAdapter1.FillByConCeroFecha(Me.DsCobros2.FiltroCobroSaldo, par1, Fecha1Filtro.Text, Fecha2Filtro.Text)
                End If
                If (Fecha1Filtro.Text = "  /  /    ") And (Fecha2Filtro.Text <> "  /  /    ") Then
                    Me.FiltroCobroSaldoTableAdapter1.FillByConCerosUnaFecha(Me.DsCobros2.FiltroCobroSaldo, par1, Fecha2Filtro.Text)
                End If
            End If
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
                tbxMonto.Text = dgvNotaCredito.CurrentRow.Cells("SALDODataGridViewTextBoxColumn").Value
                tbxNotadeCredito.Text = dgvNotaCredito.CurrentRow.Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value
                txtCodDevolucion.Text = dgvNotaCredito.CurrentRow.Cells("CODDEVOLUCION").Value
                tbxMonto.Focus()
                UltraPopupControlContainer2.Close()
            End If
        End If
    End Sub
    'Private Sub dgvSaldoF_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSaldoF.CellDoubleClick
    '    If dgvSaldoF.RowCount = 0 Then
    '        UltraPopupControlContainer2.Close()
    '    Else
    '        'Antes de Agregar la Nota de Credito debemos verificar que no se halla cargado aun --- Yolanda Zelaya
    '        If SaldoCEROSF(dgvSaldoF.CurrentRow.Index) = True Then
    '            MessageBox.Show("Ya se encuentra agregado la totalidad del Saldo a Favor", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        Else
    '            tbxMonto.Text = dgvSaldoF.CurrentRow.Cells("SALDODataGridViewTextBoxColumn").Value
    '            tbxMonto.Focus()
    '            UltraPopupControlContainer2.Close()
    '        End If
    '    End If
    'End Sub
#End Region

    Private Sub cbxVerRelaciones_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxVerRelaciones.CheckedChanged
        If cbxVerRelaciones.Checked = True Then
            If IsDBNull(GridViewTodosClientes.CurrentRow.Cells("TIPORELACION").Value) Then
            Else
                If GridViewTodosClientes.CurrentRow.Cells("TIPORELACION").Value = 1 Then
                    FACTURAACOBRARTableAdapter1.FillByRelacion(DsCobros2.FACTURAACOBRAR, GridViewTodosClientes.CurrentRow.Cells("NUMCLIENTEDataGridViewTextBoxColumn").Value)
                Else
                    FACTURAACOBRARTableAdapter1.FillByRelacion(DsCobros2.FACTURAACOBRAR, GridViewTodosClientes.CurrentRow.Cells("RELACION").Value)
                End If
            End If
        ElseIf cbxVerRelaciones.Checked = False Then
            FACTURAACOBRARTableAdapter1.Fill(DsCobros2.FACTURAACOBRAR, GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value)
        End If
    End Sub

    Private Sub cbxCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCaja.KeyPress
        'Verificamos que tipo de Pago selecciono y de acuerdo a eso ponemos el foco
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Me.lbxTipoCobro.SelectedValue = 7 Then
                tbxConcepto.Focus()
            ElseIf Me.lbxTipoCobro.SelectedValue = 1 Or Me.lbxTipoCobro.SelectedValue = 2 Then
                btnAgregarPago.Focus()
            Else
                tbxNroRef.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub btnAgregarPago_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles btnAgregarPago.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPago.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub dgvCobros_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvCobros.SelectionChanged
        Try
            If btnuevo = 0 Then
                If dgvCobros.RowCount > 0 Then
                    If IsDBNull(dgvCobros.CurrentRow.Cells("CABCOBRO").Value) Then
                        VCabCobro = 0
                    Else
                        VCabCobro = dgvCobros.CurrentRow.Cells("CABCOBRO").Value
                    End If

                    Me.COBRODETALLETableAdapter.Fill(Me.DsCobros3.COBRODETALLE, VCabCobro)
                    Dim TotalImporte As Double
                    TotalImporte = 0
                    Dim FactRel As String = ""
                    Dim varias As Boolean = False
                    Dim contfact As Integer = 0
                    Dim i As Integer = 0
                    'For i = 0 To dgvFormaCobro.RowCount - 1
                    Try
                        For Each row As DataGridViewRow In dgvFormaCobro.Rows
                            Dim codTipoCobro As Integer = row.Cells("CODTIPOPAGO").Value
                            If codTipoCobro <> 5 And codTipoCobro <> 8 And codTipoCobro <> 7 Then
                                TotalImporte = TotalImporte + row.Cells("IMPORTE").Value
                            End If
                            If i = 0 Then
                                FactRel = row.Cells("NUMVENTA1").Value
                                i += 1
                            Else
                                If row.Cells("NUMVENTA1").Value <> FactRel Then
                                    varias = True
                                    contfact = contfact + 1
                                End If
                            End If
                        Next
                    Catch
                    End Try

                    If varias = True Then
                        lblNroFacturas.Text = contfact
                    Else
                        lblNroFacturas.Text = FactRel
                    End If
                    umeTotalRec.Text = TotalImporte
                    lblCuotas.Text = dgvFormaCobro.RowCount
                Else
                    Me.COBRODETALLETableAdapter.Fill(Me.DsCobros3.COBRODETALLE, 0)
                    Dim cant As Integer = dgvFormaCobro.RowCount
                    tbxMonto.Text = "" : lblMontoSelecionado.Text = "" : lblMontoTotalVencido.Text = "" : lblCuotas.Text = "" : lblNroFacturas.Text = ""
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub InicializaFechaFiltro()
        Dim nromes, nroaño As Integer
        nromes = Today.Month
        nroaño = Today.Year

        FechaFiltro1 = New DateTime(nroaño, nromes, 1)
        FechaFiltro2 = New DateTime(nroaño, nromes, DateTime.DaysInMonth(nroaño, nromes))
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
            FechaFiltro1 = fechacompleta1
            FechaFiltro2 = fechacompleta2
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Me.COBROCABECERATableAdapter.Fill(Me.DsCobros3.COBROCABECERA, FechaFiltro1, FechaFiltro2)

        'Verificamos si la grilla de Cobros esta vacia que no permita editar
        If dgvCobros.RowCount = 0 Then
            ModificarDetPictureBox.Image = My.Resources.EditOff
            ModificarDetPictureBox.Enabled = False
            tsEditar.Enabled = False
        Else
            ModificarDetPictureBox.Image = My.Resources.Edit
            ModificarDetPictureBox.Enabled = True
            tsEditar.Enabled = True
        End If
        lblDGVCant.Text = "Cant. de Items:" & dgvCobros.RowCount
    End Sub

    Private Sub BtnAsterisco_Click(sender As System.Object, e As System.EventArgs) Handles btnAsterisco.Click
        Me.CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)
        Dim dt As DataTable = Me.CLIENTESTableAdapter1.GetData
        UltraPopupControlContainer1.PopupControl = GroupBoxCliente
        UltraPopupControlContainer1.Show()
        TxtBuscaCliente.Text = ""
        TxtBuscaCliente.Focus()
    End Sub

    Private Sub GridViewClientes_DoubleClick(sender As Object, e As System.EventArgs) Handles GridViewClientes.DoubleClick
        If GridViewClientes.RowCount = 0 Then
            CmbCliente.Focus()
            UltraPopupControlContainer1.Close()
        Else
            If IsDBNull(GridViewClientes.CurrentRow) Then
                CmbCliente.Focus()
                UltraPopupControlContainer1.Close()
            Else
                'LIMPIAMOS DEL ANTERIOR
                If IsDBNull(GridViewClientes.CurrentRow.Cells("CODCLIENTE").Value) Then
                Else
                    CmbCliente.SelectedValue = CDec(GridViewClientes.CurrentRow.Cells("CODCLIENTE").Value)

                    lblNombreFantasia.Visible = True : lblRuc.Visible = True

                    If Not IsDBNull(GridViewClientes.CurrentRow.Cells("NOMBREFANTASIA").Value) Then
                        lblNombreFantasia.Text = GridViewClientes.CurrentRow.Cells("NOMBREFANTASIA").Value
                    Else
                        lblNombreFantasia.Text = ""
                    End If

                    If Not IsDBNull(GridViewClientes.CurrentRow.Cells("RUC").Value) Then
                        lblRuc.Text = GridViewClientes.CurrentRow.Cells("RUC").Value
                    Else
                        lblRuc.Text = ""
                    End If

                    If Not IsDBNull(GridViewClientes.CurrentRow.Cells("NUMCLIENTE1").Value) Then
                        tbxNumCliente.Text = GridViewClientes.CurrentRow.Cells("NUMCLIENTE1").Value
                    Else
                        tbxNumCliente.Text = ""
                    End If
                End If

                Me.dtpRegFechaCobro.Focus()
                UltraPopupControlContainer1.Close()
            End If
        End If
    End Sub

    Private Sub GridViewClientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridViewClientes.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If GridViewClientes.RowCount = 0 Then
                CmbCliente.Focus()
                UltraPopupControlContainer1.Close()
            Else
                If IsDBNull(GridViewClientes.CurrentRow) Then
                    CmbCliente.Focus()
                    UltraPopupControlContainer1.Close()
                Else
                    'LIMPIAMOS DEL ANTERIOR
                    If IsDBNull(GridViewClientes.CurrentRow.Cells("CODCLIENTE").Value) Then
                    Else
                        CmbCliente.SelectedValue = CDec(GridViewClientes.CurrentRow.Cells("CODCLIENTE").Value)

                        lblNombreFantasia.Visible = True : lblRuc.Visible = True

                        If Not IsDBNull(GridViewClientes.CurrentRow.Cells("NOMBREFANTASIA").Value) Then
                            lblNombreFantasia.Text = GridViewClientes.CurrentRow.Cells("NOMBREFANTASIA").Value
                        Else
                            lblNombreFantasia.Text = ""
                        End If

                        If Not IsDBNull(GridViewClientes.CurrentRow.Cells("RUC").Value) Then
                            lblRuc.Text = GridViewClientes.CurrentRow.Cells("RUC").Value
                        Else
                            lblRuc.Text = ""
                        End If

                        If Not IsDBNull(GridViewClientes.CurrentRow.Cells("NUMCLIENTE1").Value) Then
                            tbxNumCliente.Text = GridViewClientes.CurrentRow.Cells("NUMCLIENTE1").Value
                        Else
                            lblNombreFantasia.Text = ""
                            lblRuc.Text = ""
                        End If
                    End If

                    Me.dtpRegFechaCobro.Focus()
                    UltraPopupControlContainer1.Close()
                End If
            End If
        End If
    End Sub

    Private Sub tbxNumCliente_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNumCliente.LostFocus
        Dim codcli As Double
        codcli = f.FuncionConsulta("CODCLIENTE", "CLIENTES", "NUMCLIENTE", tbxNumCliente.Text)
        Try
            CmbCliente.SelectedValue = CDec(codcli)
        Catch ex As Exception
        End Try

        lblNombreFantasia.Visible = True
        lblNombreFantasia.Text = f.FuncionConsultaString("NOMBREFANTASIA", "CLIENTES", "CODCLIENTE", codcli)

        lblRuc.Visible = True
        lblRuc.Text = f.FuncionConsultaString("RUC", "CLIENTES", "CODCLIENTE", codcli)
    End Sub

    Private Sub TbxNumCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxNumCliente.TextChanged
        tbxNumCliente.Text = Funciones.Cadenas.SoloAlfaNumerico(tbxNumCliente.Text)
    End Sub

    Private Sub CmbCliente_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CmbCliente.SelectedIndexChanged
        If CmbCliente.SelectedValue = Nothing Then
            tbxNumCliente.Text = ""
            lblNombreFantasia.Text = ""
            lblRuc.Text = ""
        Else
            tbxNumCliente.Text = f.FuncionConsultaString("numcliente", "clientes", "codcliente", CmbCliente.SelectedValue)
            If tbxNumCliente.Text = Nothing Then
                tbxNumCliente.Text = ""
            End If
            lblNombreFantasia.Visible = True
            lblNombreFantasia.Text = f.FuncionConsultaString("NOMBREFANTASIA", "CLIENTES", "CODCLIENTE", CmbCliente.SelectedValue)

            lblRuc.Visible = True
            lblRuc.Text = f.FuncionConsultaString("RUC", "CLIENTES", "CODCLIENTE", CmbCliente.SelectedValue)

            FACTURAACOBRARTableAdapter1.Fill(DsCobros2.FACTURAACOBRAR, CmbCliente.SelectedValue)
            SALDOVENCIDOTableAdapter1.Fill(DsCobros2.SALDOVENCIDO, Today, CmbCliente.SelectedValue)
            CalcularSaldo()
            ObtenerSaldoVencido()

            'Verificamos si el cliente tiene un saldo a Favor (Anticipo de Dinero)
            Dim AnticipoCliente As Double = 0
            AnticipoCliente = f.FuncionConsultaDecimal("SUM(SALDOCUOTA) * - 1", "FACTURACOBRAR", "CODNUMEROCUOTA = 0 AND IDCLIENTE", CmbCliente.SelectedValue)

            If AnticipoCliente <> 0 Then
                lblAnticipo.Visible = True : lblAnticipoS.Visible = True
                lblAnticipoS.Text = FormatNumber(AnticipoCliente, 0)
            Else
                lblAnticipo.Visible = False : lblAnticipoS.Visible = False
                lblAnticipoS.Text = 0
            End If
        End If
    End Sub
    Private Sub TxtBuscaCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscaCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            GridViewClientes.Focus()
        End If
    End Sub
    Private Sub TxtBuscaCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscaCliente.TextChanged
        If TxtBuscaCliente.Text = "" Then
            Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & TxtBuscaCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & TxtBuscaCliente.Text & "%'"
        Else
            If TxtBuscaCliente.Text <> "Buscar..." Then
                If Not System.Text.RegularExpressions.Regex.IsMatch(TxtBuscaCliente.Text, "^\d*$") Then ' Si introduce letras
                    Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & TxtBuscaCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & TxtBuscaCliente.Text & "%'"
                Else
                    Me.CLIENTESBindingSource.Filter = "NUMCLIENTE1 =" & TxtBuscaCliente.Text
                    If GridViewClientes.RowCount = 0 Then
                        Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & TxtBuscaCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & TxtBuscaCliente.Text & "%'"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub tbxNumCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNumCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbCliente.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 42 Then
            BtnAsterisco_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmbGenerarRecibo_TextChanged(sender As Object, e As System.EventArgs) Handles cmbGenerarRecibo.TextChanged
        If btnuevo = 1 Or btmodificar = 1 Then
            If cmbGenerarRecibo.Text = "Automático" Then
                'Recuperamos el Ultimo Numero de Recibo para Cobros
                'POR AHORA COMO EN LA VENTANA COBROS NO SE SELECCIONA UN TIPO ESPECIFICO DE COMPROBANTE DE COBRO (SI HUBIERA + DE UNO), SE CONSIDERA QUE SOLO EXISTE UNO Y PREGUNTA  "WHERE COBRO=1"
                NroRango = f.FuncionConsultaString("DETPC.ULTIMO", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND ACTIVO = 1 AND COBROS", 1)

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

    Private Sub ModificarDetPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarDetPictureBox.Click
        ContNewFilasEdit = 0
        btmodificarDet = 1
        btmodificar = 1
        PagosActivo.Image = My.Resources.PaymentActive
        FiltroPagosActivo.Image = My.Resources.User
        TipoCobroPictureBox.Image = My.Resources.Cuenta
        ModificarDetPictureBox.Image = My.Resources.EditActive

        HabilitarControles()
        dgvFormaCobro.Enabled = True
        pnlDetalleCobro.Enabled = True
        pnlDatosdelCobro.Enabled = True
        CmbCliente.Enabled = False
        tbxNumCliente.Enabled = False

        lblPagado.Text = tbxMonto.Text
        dgvCobros.Enabled = False
        BtnFiltro.Enabled = False
        BuscarTextBox.Enabled = False
        FiltroPagosActivo.Enabled = False
        TipoCobroPictureBox.Enabled = False
        PendientesPago.Enabled = False
        tbxMonto.Text = ""
        lblProximoNro.Text = "Nro. Recibo: " + NroReciboTextBox.Text + " " + tbxNroSerie.Text
    End Sub

    Private Sub btnCerrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarOBS.Click
        pnlObservacion.Visible = False
    End Sub

    Private Sub tbxObservaciones_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbxObservaciones.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlObservacion.Visible = False
        End If
    End Sub

    Private Sub btnMostrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrarOBS.Click
        pnlObservacion.Visible = True
        pnlObservacion.BringToFront()
    End Sub

    Private Sub cmbBanco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBanco.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarPago.Focus()
            KeyAscii = 0
        End If
    End Sub

    Public Sub tbxNumCliPend_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNumCliPend.LostFocus
        Dim codcli As Double
        codcli = f.FuncionConsulta("CODCLIENTE", "CLIENTES", "NUMCLIENTE", tbxNumCliPend.Text)
        Try
            cmbCliPend.SelectedValue = CDec(codcli)
            LblNomFantasiaPend.Visible = True
            LblNomFantasiaPend.Text = f.FuncionConsultaString("NOMBREFANTASIA", "CLIENTES", "CODCLIENTE", codcli)
        Catch ex As Exception
        End Try


    End Sub

    Public Sub tbxNroFacturaPend_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroFacturaPend.LostFocus
        FACTURASPENDIENTESTableAdapter.Fill(DsCobros2.FACTURASPENDIENTES)
        FacturasPendientesBindingSource.Filter = " NUMVENTA LIKE '%" & tbxNroFacturaPend.Text & "%'"
        Dim codcli As String = ""
        If dgvPendientes.RowCount > 0 Then
            If tbxNroFacturaPend.Text = "" Then
                CmbCliente.Text = ""
                cmbCliPend.SelectedIndex = -1
                LblNomFantasiaPend.Text = ""
            Else
                If dgvPendientes.RowCount = 1 Then
                    codcli = dgvPendientes.CurrentRow.Cells("CODCLIENTEP").Value
                    Try
                        cmbCliPend.SelectedValue = CDec(codcli)
                        LblNomFantasiaPend.Visible = True
                        LblNomFantasiaPend.Text = f.FuncionConsultaString("NOMBREFANTASIA", "CLIENTES", "CODCLIENTE", codcli)
                    Catch ex As Exception
                    End Try
                Else
                    CmbCliente.Text = ""
                    cmbCliPend.SelectedIndex = -1
                    LblNomFantasiaPend.Text = ""
                End If
            End If
        Else
            CmbCliente.Text = ""
            cmbCliPend.SelectedIndex = -1
            LblNomFantasiaPend.Text = ""
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
                FacturasPendientesBindingSource.RemoveFilter()
                btnFiltrarFechasP_Click(Nothing, Nothing)
                dgvPendientes.Select()
                'tbxFechaPend1.Focus()
                KeyAscii = 0
            End If
            If KeyAscii = 42 Then
                Me.CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)
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
            LblNomFantasiaPend.Text = ""
        Else
            tbxNumCliPend.Text = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliPend.SelectedValue)
            If tbxNumCliPend.Text = Nothing Then
                tbxNumCliPend.Text = ""
            End If
            LblNomFantasiaPend.Visible = True
            LblNomFantasiaPend.Text = f.FuncionConsultaString("NOMBREFANTASIA", "CLIENTES", "CODCLIENTE", cmbCliPend.SelectedValue)
        End If
    End Sub

    Private Sub PendientesPago_Click(sender As System.Object, e As System.EventArgs) Handles PendientesPago.Click
        MenuCobros.Enabled = False
        If panelactivo = "SplitCobros" Then
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
        LblNomFantasiaPend.Text = ""
        Me.FACTURASPENDIENTESTableAdapter.Fill(DsCobros2.FACTURASPENDIENTES)
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
                Me.FACTURASPENDIENTESTableAdapter.FillByFecha(DsCobros2.FACTURASPENDIENTES, vtoDesde, vtoHasta)
            Else
                Me.FACTURASPENDIENTESTableAdapter.FillByClienteYFecha(DsCobros2.FACTURASPENDIENTES, cmbCliPend.SelectedValue, vtoDesde, vtoHasta)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAsteriscoPend_Click(sender As System.Object, e As System.EventArgs) Handles btnAsteriscoPend.Click
        Me.CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)
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
                If dgvPendientes.SelectedRows.Item(i).Cells("CODCLIENTEP").Value = dgvPendientes.SelectedRows.Item(0).Cells("CODCLIENTEP").Value Then 'Si seleccina filas de mas de 1 cliente, solo considera el primer cliente
                    seleccionados(i) = dgvPendientes.SelectedRows.Item(i).Cells("CODVENTAP").Value
                    seleccionados2(i) = dgvPendientes.SelectedRows.Item(i).Cells("CODNUMEROCUOTAP").Value
                    vectorcount = vectorcount + 1
                    ReDim Preserve seleccionados(vectorcount)
                    ReDim Preserve seleccionados2(vectorcount)
                End If
            Next

            panelactivo = "SplitCobros"
            NuevoPictureBox_Click(Nothing, Nothing)

            CmbCliente.SelectedValue = dgvPendientes.CurrentRow.Cells("CODCLIENTEP").Value

            For i = 0 To dgvFacturasaCobar.Rows.Count - 1
                Dim i2 As Integer
                For i2 = 0 To vectorcount - 1
                    If dgvFacturasaCobar.Rows(i).Cells("CODVENTA").Value = seleccionados(i2) And dgvFacturasaCobar.Rows(i).Cells("NUMEROCUOTA").Value = seleccionados2(i2) Then
                        dgvFacturasaCobar.Rows(i).Cells("Cobrar").Value = True
                    End If
                Next
            Next

            dgvFacturasaCobar_CellContentClick(Nothing, Nothing)
            btnDetalles_Click(Nothing, Nothing)
            splitCobros.BringToFront()
            tbxMonto.Focus()

            cbxMoneda.Text = dgvPendientes.CurrentRow.Cells("DataGridViewTextBoxColumn49").Value

            PagosActivo.Image = My.Resources.PaymentActive
            PagosActivo.Cursor = Cursors.Arrow
            FiltroPagosActivo.Image = My.Resources.User
            FiltroPagosActivo.Cursor = Cursors.Hand
            TipoCobroPictureBox.Image = My.Resources.Cuenta
            TipoCobroPictureBox.Cursor = Cursors.Hand
            PendientesPago.Image = My.Resources.Create
            PendientesPago.Cursor = Cursors.Hand

            dgvCobros.Enabled = True : BtnFiltro.Enabled = True : BuscarTextBox.Enabled = True
            BuscarTextBox.Visible = True : NuevoPictureBox.Visible = True : PictureBox2.Visible = True : EliminarPictureBox.Visible = True
            ModificarDetPictureBox.Visible = True : CancelarPictureBox.Visible = True : ConfirmarPictureBox.Visible = True
            CmbCliente.SelectedValue = dgvPendientes.CurrentRow.Cells("CODCLIENTEP").Value

        End If
    End Sub

    Private Sub txtBuscaClientePend_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscaClientePend.TextChanged
        If txtBuscaClientePend.Text = "" Then
            Me.ClientesPendBindingSource.Filter = "NOMBRE LIKE '%" & txtBuscaClientePend.Text & "%' OR NOMBREFANTASIA LIKE '%" & txtBuscaClientePend.Text & "%'"
        Else
            If txtBuscaClientePend.Text <> "Buscar..." Then
                If Not System.Text.RegularExpressions.Regex.IsMatch(txtBuscaClientePend.Text, "^\d*$") Then ' Si introduce letras
                    Me.ClientesPendBindingSource.Filter = "NOMBRE LIKE '%" & txtBuscaClientePend.Text & "%' OR NOMBREFANTASIA LIKE '%" & txtBuscaClientePend.Text & "%'"
                Else
                    Me.ClientesPendBindingSource.Filter = "NUMCLIENTE1 =" & txtBuscaClientePend.Text
                    If GridViewClientesPend.RowCount = 0 Then
                        Me.ClientesPendBindingSource.Filter = "NOMBRE LIKE '%" & txtBuscaClientePend.Text & "%' OR NOMBREFANTASIA LIKE '%" & txtBuscaClientePend.Text & "%'"
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
                    If IsDBNull(GridViewClientesPend.CurrentRow.Cells("CODCLIENTE").Value) Then
                    Else
                        cmbCliPend.SelectedValue = CDec(GridViewClientesPend.CurrentRow.Cells("CODCLIENTE").Value)

                        LblNomFantasiaPend.Visible = True
                        LblNomFantasiaPend.Text = GridViewClientesPend.CurrentRow.Cells("NOMBREFANTASIA").Value.ToString
                        tbxNumCliPend.Text = GridViewClientesPend.CurrentRow.Cells("NUMCLIENTE1").Value
                    End If

                    Me.cmbCliPend.Focus()
                    UltraPopupControlContainer1.Close()

                End If
            End If
        End If
    End Sub

    Private Sub cbxNotaCredito_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxNotaCredito.CheckedChanged
        If cbxNotaCredito.Checked = True Then
            If IsDBNull(GridViewTodosClientes.CurrentRow.Cells("TIPORELACION").Value) Then
            Else
                If GridViewTodosClientes.CurrentRow.Cells("TIPORELACION").Value = 1 Then
                    NCREDITOTableAdapter.FillBy(DsCobros2.NCREDITO, GridViewTodosClientes.CurrentRow.Cells("NUMCLIENTEDataGridViewTextBoxColumn").Value)
                Else
                    NCREDITOTableAdapter.FillBy(DsCobros2.NCREDITO, GridViewTodosClientes.CurrentRow.Cells("RELACION").Value)
                End If
            End If
        ElseIf cbxNotaCredito.Checked = False Then
            NCREDITOTableAdapter.Fill(DsCobros2.NCREDITO, GridViewTodosClientes.CurrentRow.Cells("CODCLIENTE").Value)
        End If
    End Sub

    Private Sub tbxNroSerie_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroSerie.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxMoneda.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub btnAgregarNC_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarNC.Click
        Try
            Dim Chequeado, ChequeadoNC As Boolean
            Dim CodPago, TipoFormaPago, CodMonedaNC As Integer
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
                        CodMonedaNC = dgvNotaCredito.Rows(j).Cells("CODMONEDANC").Value

                        'Verificamos si se chequeo o no algun campo de la grilla de las Facturas Pendientes de Cobro
                        Chequeado = VerificarCkequet()

                        If Chequeado = True Then
                            For i = 1 To dgvFacturasaCobar.RowCount
                                If dgvFacturasaCobar.Rows(i - 1).Cells("Cobrar").Value = True Then
                                    Monto = dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value

                                    If Monto <> 0 Then
                                        If MontoPagado > 0 Then
                                            If MontoPagado >= Monto Then
                                                dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                                ImporteGrilla = Monto
                                            Else
                                                dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                                ImporteGrilla = MontoPagado
                                            End If
                                            MontoPagado = Monto - MontoPagado
                                            MontoPagado = MontoPagado * (-1)

                                            If dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                                TipoFormaPago = 1
                                            Else
                                                TipoFormaPago = 2
                                            End If

                                            CobroDetalleBindingSource.AddNew()

                                            Dim c As Integer = dgvFormaCobro.RowCount

                                            If btmodificar = 1 Then
                                                If ContNewFilasEdit = 0 Then
                                                    CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                                    CodPago = CodPago + 1
                                                    ContNewFilasEdit = ContNewFilasEdit + 1
                                                Else
                                                    CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                                    ContNewFilasEdit = ContNewFilasEdit + 1
                                                End If
                                            Else
                                                If c = 1 Then
                                                    CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                                    CodPago = CodPago + 1
                                                ElseIf c > 1 Then
                                                    CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                                End If
                                            End If

                                            Dim sinfechadet As Boolean = False
                                            If dtpFechaCobroDet.Text = "" Then
                                                sinfechadet = True
                                                dtpFechaCobroDet.Value = dtpRegFechaCobro.Text
                                            End If

                                            Dim conctFecha As String
                                            Dim conctHora As String = Now.ToString("HH:mm:ss")
                                            If sinfechadet = True Then
                                                conctFecha = dtpFechaCobroDet.Value
                                            Else
                                                conctFecha = dtpFechaCobroDet.Text
                                            End If
                                            Dim MaxIdApertura As Integer
                                            'Dim idCaja As String = dgvFormaCobro.Rows(i - 1).Cells("CODCUENTA").Value
                                            '   MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", cmbCaja.SelectedValue)
                                            'Dim MaxIdApertura As Integer = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", idCaja)
                                            If lbxTipoCobro.SelectedValue = 5 Then
                                                'Dim idCaja As String = dgvFormaCobro.Rows(c - 1).Cells("DESTIPOPAGO").Value
                                                MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", lbxTipoCobro.SelectedValue)
                                                lbxTipoCobro.Text = cmbCaja.Text
                                                'dgvFormaCobro.Rows(1).Cells("CODCUENTA").Value = MaxIdApertura
                                            Else
                                                MaxIdApertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja", cmbCaja.SelectedValue)
                                            End If


                                            Dim conctFechaHora As String = conctFecha & " " + conctHora

                                            dgvFormaCobro.Rows(c - 1).Cells("NUMVENTA1").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMVENTA").Value
                                            dgvFormaCobro.Rows(c - 1).Cells("CODVENTADET").Value = dgvFacturasaCobar.Rows(i - 1).Cells("CODVENTA").Value
                                            dgvFormaCobro.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                            dgvFormaCobro.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoCobro.Text
                                            dgvFormaCobro.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                            dgvFormaCobro.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoCobro.SelectedValue
                                            dgvFormaCobro.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                            dgvFormaCobro.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                                            dgvFormaCobro.Rows(c - 1).Cells("CUENTA").Value = cmbCaja.Text
                                            dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value = MaxIdApertura
                                            'dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value = cmbCaja.SelectedValue
                                            dgvFormaCobro.Rows(c - 1).Cells("NUMDEVOLUCION").Value = NroDevolucion
                                            dgvFormaCobro.Rows(c - 1).Cells("CODNRODEV").Value = CodDevolucion
                                            dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                            dgvFormaCobro.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                                            dgvFormaCobro.Rows(c - 1).Cells("CODMONEDA2").Value = CodMonedaNC
                                            dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"
                                            dgvFormaCobro.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text

                                            If cmbBanco.Text = "" Then
                                                'dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = ""
                                            Else
                                                dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = cmbBanco.SelectedValue
                                            End If

                                            lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                                            lblPagado.Text = FormatNumber(lblPagado.Text, 0)
                                        End If
                                    End If
                                End If
                            Next

                        Else
                            For i = 1 To dgvFacturasaCobar.RowCount
                                Monto = dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value

                                If Monto <> 0 Then
                                    If MontoPagado > 0 Then
                                        If MontoPagado >= Monto Then
                                            dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                            ImporteGrilla = Monto
                                        Else
                                            dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                            ImporteGrilla = MontoPagado
                                        End If
                                        MontoPagado = Monto - MontoPagado
                                        MontoPagado = MontoPagado * (-1)

                                        If dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                            TipoFormaPago = 1
                                        Else
                                            TipoFormaPago = 2
                                        End If

                                        'Insertamos en la grilla
                                        'dgvFormaCobro.Rows.Add()
                                        CobroDetalleBindingSource.AddNew()
                                        Dim c As Integer = dgvFormaCobro.RowCount

                                        If btmodificar = 1 Then
                                            If ContNewFilasEdit = 0 Then
                                                CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                                CodPago = CodPago + 1
                                                ContNewFilasEdit = ContNewFilasEdit + 1
                                            Else
                                                CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                                ContNewFilasEdit = ContNewFilasEdit + 1
                                            End If
                                        Else
                                            If c = 1 Then
                                                CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                                CodPago = CodPago + 1
                                            ElseIf c > 1 Then
                                                CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                            End If
                                        End If

                                        Dim sinfechadet As Boolean = False
                                        If dtpFechaCobroDet.Text = "" Then
                                            sinfechadet = True
                                            dtpFechaCobroDet.Value = dtpRegFechaCobro.Text
                                        End If

                                        Dim conctFecha As String
                                        Dim conctHora As String = Now.ToString("HH:mm:ss")
                                        If sinfechadet = True Then
                                            conctFecha = dtpFechaCobroDet.Value
                                        Else
                                            conctFecha = dtpFechaCobroDet.Text
                                        End If
                                        Dim conctFechaHora As String = conctFecha & " " + conctHora

                                        dgvFormaCobro.Rows(c - 1).Cells("NUMVENTA1").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMVENTA").Value
                                        dgvFormaCobro.Rows(c - 1).Cells("CODVENTADET").Value = dgvFacturasaCobar.Rows(i - 1).Cells("CODVENTA").Value
                                        dgvFormaCobro.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                        dgvFormaCobro.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoCobro.Text
                                        dgvFormaCobro.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                        dgvFormaCobro.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoCobro.SelectedValue
                                        dgvFormaCobro.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                        dgvFormaCobro.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                                        dgvFormaCobro.Rows(c - 1).Cells("CUENTA").Value = cmbCaja.Text
                                        dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value = cmbCaja.SelectedValue
                                        dgvFormaCobro.Rows(c - 1).Cells("NUMRETENCION").Value = tbxNroRetencion.Text
                                        dgvFormaCobro.Rows(c - 1).Cells("NUMDEVOLUCION").Value = NroDevolucion
                                        dgvFormaCobro.Rows(c - 1).Cells("CODNRODEV").Value = CodDevolucion
                                        dgvFormaCobro.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                                        dgvFormaCobro.Rows(c - 1).Cells("CODMONEDA2").Value = CodMonedaNC
                                        dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                        If btmodificar = 1 Then
                                            dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "IU"
                                            dgvFormaCobro.Rows(c - 1).Cells("CABCOBRO").Value = dgvCobros.CurrentRow.Cells("CABCOBRO").Value
                                        Else
                                            dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"
                                        End If


                                        If cmbBanco.Text = "" Then
                                            'dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = ""
                                        Else
                                            dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = cmbBanco.SelectedValue
                                        End If

                                        lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                                        lblPagado.Text = FormatNumber(lblPagado.Text, 0)
                                    End If
                                End If
                            Next
                        End If
                    Else
                        MessageBox.Show("La Nota de Credito Nro :" & dgvNotaCredito.Rows(j).Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value & " ya fue utilizada anteriormente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Next

            lblSaldoFavor.Text = CDec(lblMontoSelecionado.Text) - CDec(lblPagado.Text)
            lblSaldoFavor.Text = FormatNumber(lblSaldoFavor.Text, 0)
            lblSaldoF.Text = "Falta Cobrar :"
            tbxMonto.Text = lblSaldoFavor.Text

            UltraPopupControlContainer2.Close()
            ' tbxMonto.Focus()
            lbxTipoCobro.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Private Function SaldoCERO(ByVal indice As Integer) As Boolean
        If dgvNotaCredito.Rows(indice).Cells("SALDODataGridViewTextBoxColumn").Value = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function SaldoCEROSF(ByVal indice As Integer) As Boolean
        If dgvSaldoF.Rows(indice).Cells("SALDOSALDOFAVOR").Value = 0 Then
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

    Private Function VerificarCheckedSF() As Boolean
        Dim rows As Integer = dgvSaldoF.RowCount
        Dim ExisteCheckedSF As Boolean

        ExisteCheckedSF = False
        For x = 1 To rows
            If dgvSaldoF.Rows(x - 1).Cells("USARSALDO").Value = True Then
                ExisteCheckedSF = True
                Exit For
            End If
        Next
        Return ExisteCheckedSF
    End Function

    Private Sub BuscarProductoTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        If Me.BuscarProductoTextBox.Text <> "" Then
            Me.NCREDITOBindingSource.Filter = "NUMDEVOLUCION LIKE '%" & BuscarProductoTextBox.Text & "%'"
        Else
            Me.NCREDITOBindingSource.RemoveFilter()
        End If
    End Sub

    Private Sub tbxNroSerie_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroSerie.LostFocus
        lblProximoNro.Text = "Nro. Recibo: " + NroReciboTextBox.Text + " " + tbxNroSerie.Text
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Me.FACTURASPENDIENTESTableAdapter.Fill(Me.DsCobros2.FACTURASPENDIENTES)

        btnFiltrarFechasP_Click(Nothing, Nothing)

        If tbxNumCliPend.Text = "" Then
            tbxNumCliPend.Focus()
        Else
            dgvPendientes.Select()
        End If
    End Sub
    Private Sub tsNuevaVenta_Click(sender As System.Object, e As System.EventArgs)
        NuevoPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsEditar_Click(sender As System.Object, e As System.EventArgs)
        ModificarDetPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsGuardar_Click(sender As System.Object, e As System.EventArgs)
        ConfirmarPictureBox_Click(Nothing, Nothing)
    End Sub

    'Private Sub tsEliminar_Click(sender As System.Object, e As System.EventArgs)
    '    EliminarPictureBox_Click(Nothing, Nothing)
    'End Sub

    Private Sub tsCancelar_Click(sender As System.Object, e As System.EventArgs) Handles tsCancelar.Click
        CancelarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAyudaOnline_Click(sender As System.Object, e As System.EventArgs) Handles tsAyudaOnline.Click
        Dim soporte As String = "http://www.cogentpotential.com/soporte/cobros"
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
        ABMConfigPosExpress.abrirdesde("Cobros")
    End Sub

    Private Sub lblProximoNro_Click(sender As System.Object, e As System.EventArgs) Handles lblProximoNro.Click
        Dim CodCobroMax As Integer
        Dim MaxNroRecibo As Integer = 0

        If Config2 = "Manual por Usuario" Or Config2 = "Manual sin Importar usuario" Then
            cmbGenerarRecibo.Text = "Manual"
            'Obtiene el ultimo nro cargado
            Try
                If Config2 = "Manual por Usuario" Then
                    CodCobroMax = f.FuncionConsultaString("MAX(CODCOBRO)", "VENTASFORMACOBRO", "NRORECIBO IS NOT NULL AND AUTORIZADO", UsuCodigo)
                ElseIf Config2 = "Manual sin Importar usuario" Then
                    CodCobroMax = f.MaximoIsNotNull("CODCOBRO", "VENTASFORMACOBRO", "NRORECIBO")
                End If

                MaxNroRecibo = f.FuncionConsultaString("NRORECIBO", "VENTASFORMACOBRO", "CODCOBRO", CodCobroMax)

                If Trim(MaxNroRecibo) <> "" Then
                    Dim max As Integer = CInt(MaxNroRecibo)
                    MaxNroRecibo = max + 1
                    NroReciboTextBox.Text = MaxNroRecibo
                End If
            Catch ex As Exception
                NroReciboTextBox.Text = ""
            End Try
        Else
            cmbGenerarRecibo.Text = "Automático"
            If cmbGenerarRecibo.Text = "Automático" Then
                NroRango = f.FuncionConsultaString("DETPC.ULTIMO", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND ACTIVO = 1 AND COBROS", 1)

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

        lblProximoNro.Text = "Nro. Recibo: " + NroReciboTextBox.Text
    End Sub

    Private Sub tsQuemarProxNro_Click(sender As System.Object, e As System.EventArgs) Handles tsQuemarProxNro.Click
        permiso = PermisoAplicado(UsuCodigo, 212) 'Crear una Factura en Blanco
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else
            Dim RangoID As Integer
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                'Verificar si el Comprobante está Activo
                RangoID = f.FuncionConsulta("ACTIVO", "DETPC", "RANDOID", IDRangoRecibos)

                If RangoID = 0 Or String.IsNullOrEmpty(RangoID) = True Then
                    MessageBox.Show("No hay comprobantes activos para esta máquina o No tiene asignado un Nro. de Comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'BtnImprimir.Image = My.Resources.Approve
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                Dim CodCobroMax As Integer
                Dim MaxNroRecibo As Integer = 0

                ''Obtenemos el ultimo codigo que tuvo un nro de recibo distinto de vacio
                'CabPago = f.MaximoconWhereDistinto("CABCOBRO", "VENTASFORMACOBRO", "NRORECIBO", "''")

                ''se debe obtener el ultimo nro insertado
                'CabPagoMax = f.Maximo("CABCOBRO", "VENTASFORMACOBRO")
                'CabPagoMax = CabPagoMax + 1

                ''Obtiene el ultimo nro de recibo cargado
                'MaxNroRecibo = f.FuncionConsultaString("NRORECIBO", "VENTASFORMACOBRO", "CABCOBRO", CabPago)
                'MaxNroRecibo = MaxNroRecibo + 1

                If Config2 = "Manual por Usuario" Or Config2 = "Manual sin Importar usuario" Then
                    cmbGenerarRecibo.Text = "Manual"
                    'Obtiene el ultimo nro cargado
                    Try
                        If Config2 = "Manual por Usuario" Then
                            CodCobroMax = f.FuncionConsultaString("MAX(CODCOBRO)", "VENTASFORMACOBRO", "NRORECIBO IS NOT NULL AND AUTORIZADO", UsuCodigo)
                        ElseIf Config2 = "Manual sin Importar usuario" Then
                            CodCobroMax = f.MaximoIsNotNull("CODCOBRO", "VENTASFORMACOBRO", "NRORECIBO")
                        End If

                        MaxNroRecibo = f.FuncionConsultaString("NRORECIBO", "VENTASFORMACOBRO", "CODCOBRO", CodCobroMax)

                        If Trim(MaxNroRecibo) <> "" Then
                            Dim max As Integer = CInt(MaxNroRecibo)
                            MaxNroRecibo = max + 1
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    cmbGenerarRecibo.Text = "Automático"
                    If cmbGenerarRecibo.Text = "Automático" Then
                        MaxNroRecibo = f.FuncionConsultaString("DETPC.ULTIMO", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND ACTIVO = 1 AND COBROS", 1)

                        If MaxNroRecibo = 0 Or String.IsNullOrEmpty(MaxNroRecibo) = True Then
                            MessageBox.Show("Comprobante no tiene mas Rango, cierre esta ventana y cargue lo en (Dashboard >> Configuración >> 'Rangos de Comprobantes') o bien, cargue el Nro. Recibo Manualmente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        Else
                            MaxNroRecibo = MaxNroRecibo + 1
                        End If
                    Else
                    End If
                End If

                'sql = "INSERT INTO VENTASFORMACOBRO (NRORECIBO, CABCOBRO, FECHAREGISTROCOB,CODUSUARIO,CODTIPOCOBRO) " & _
                '  "VALUES ('" & MaxNroRecibo & "', " & CabPagoMax & ", GetDate()," & UsuCodigo & ",1)    "

                'Inserta SI O SI CON FECHA DE HOY
                sql = "INSERT INTO VENTASFORMACOBRO (NRORECIBO, FECHAREGISTROCOB) " & _
                  "VALUES ('" & MaxNroRecibo & "', GetDate())    "

                sql = sql + " UPDATE DETPC SET ULTIMO =" & MaxNroRecibo & " WHERE RANDOID =" & IDRangoRecibos
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans.Commit()

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
            COBROCABECERATableAdapter.Fill(DsCobros3.COBROCABECERA, FechaFiltro1, FechaFiltro2)
            Me.Cursor = Cursors.Arrow
            dgvFormaCobro.Refresh()
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

        COBROCABECERATableAdapter.Fill(DsCobros3.COBROCABECERA, fechaDesdeEspecial, fechaHastaEspecial)


        If Trim(tsFiltroNroCliente.Text) <> "" Then
            CobroCabeceraBindingSource.Filter = "NUMCLIENTE = " & Trim(tsFiltroNroCliente.Text)
        Else
            If Trim(tsFiltroNomCliente.Text) <> "" Then
                CobroCabeceraBindingSource.Filter = "NOMBRE like '%" & Trim(tsFiltroNomCliente.Text) & "%'"
            End If
        End If
        lblDGVCant.Text = "Cant. de Items:" & dgvCobros.RowCount
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
            rlblCliFac.Text = "Nro. Cliente"
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
        LblNomFantasiaPend.Text = ""
    End Sub

    Private Sub rbFactura_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbFactura.CheckedChanged
        If rbFactura.Checked = True Then
            rlblCliFac.Text = "Nro. Factura"
            tbxNroFacturaPend.Text = ""
            tbxNroFacturaPend.BringToFront()
            cmbCliPend.Enabled = False
            tbxNroFacturaPend.Focus()
        Else
            rlblCliFac.Text = "Nro. Cliente"
            tbxNumCliPend.Text = ""
            tbxNumCliPend.BringToFront()
            cmbCliPend.Enabled = True
            tbxNumCliPend.Focus()
        End If
        cmbCliPend.Text = ""
        cmbCliPend.SelectedIndex = -1
        LblNomFantasiaPend.Text = ""
    End Sub

    Private Sub dgvPendientes_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvPendientes.DoubleClick
        btnCobrar_Click(Nothing, Nothing)
    End Sub

    Private Sub tsSaldoAFavor_Click(sender As System.Object, e As System.EventArgs) Handles tsSaldoAFavor.Click
        saldoF = True
        vgSaldoA = 1
        NuevoPictureBox_Click(Nothing, Nothing)
        pnlEstado.BackColor = Color.MediumSeaGreen
        lblTitulo.Text = "Carga de Saldo a Favor"
        TIPOFORMACOBROBindingSource.Filter = "CAJA = 1"
        lblSaldoF.Visible = False : lblSaldoFavor.Visible = False
    End Sub

    Private Sub btnAsteriscoNC_Click(sender As System.Object, e As System.EventArgs) Handles btnAsteriscoNC.Click
        If ModifNC = 0 Then
            NCREDITOTableAdapter.Fill(DsCobros2.NCREDITO, CmbCliente.SelectedValue)
        End If
        gbxNotaCredito.HeaderText = "Buscador de Nota de Crédito de " + CmbCliente.Text
        cbxNotaCredito.Checked = False
        UltraPopupControlContainer2.PopupControl = gbxNotaCredito
        UltraPopupControlContainer2.Show()
    End Sub

    Private Sub btnAsteriscoSF_Click(sender As System.Object, e As System.EventArgs) Handles btnAsteriscoSF.Click
        If ModifSF = 0 Then
            FACTURACOBRARSALDOFAVORTableAdapter.Fill(DsCobros2.FACTURACOBRARSALDOFAVOR, CmbCliente.SelectedValue)
            If dgvSaldoF.RowCount = 0 Then
                MessageBox.Show("No existen Saldos a Favor del Cliente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                UltraPopupControlContainer1.PopupControl = pnlSaldo
                UltraPopupControlContainer1.Show()
            End If
        End If
    End Sub

    Private Sub btAgregarSaldoF_Click(sender As System.Object, e As System.EventArgs) Handles btAgregarSaldoF.Click
        Try
            Dim Chequeado, ChequeadoSF As Boolean
            Dim CodPago, TipoFormaPago As Integer
            Dim MontoPagado, ImporteGrilla, Monto As Decimal

            Dim Coheficiente As String = f.FuncionConsultaString2("FACTORVENTA", "COTIZACION", "CODMONEDA", cbxMoneda.SelectedValue & " ORDER BY FECGRA DESC")

            ChequeadoSF = VerificarCheckedSF()
            If ChequeadoSF = False Then
                MessageBox.Show("Debe Seleccionar al menos un Saldo", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UltraPopupControlContainer1.Close()
                Exit Sub
            End If

            For j = 0 To dgvSaldoF.RowCount - 1
                If dgvSaldoF.Rows(j).Cells("USARSALDO").Value = True Then
                    'Antes de insertar debemos verificar que no se halla usado aun o no exita todavia en la grilla
                    If SaldoCEROSF(j) = True Then
                        MessageBox.Show("El Saldo a Favor ya se utilizó en su totalidad", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    Dim moneda As Decimal
                    moneda = cbxMoneda.SelectedValue()


                    If dgvSaldoF.Rows(j).Cells("SALDOSALDOFAVOR").Value <> 0 Then
                        MontoPagado = dgvSaldoF.Rows(j).Cells("SALDOSALDOFAVOR").Value * -1
                        dgvSaldoF.Rows(j).Cells("SALDOSALDOFAVOR").Value = 0
                        ModifSF = 1

                        'Verificamos si se chequeo o no algun campo de la grilla de las Facturas Pendientes de Cobro
                        Chequeado = VerificarCkequet()

                        If Chequeado = True Then
                            For i = 1 To dgvFacturasaCobar.RowCount
                                If dgvFacturasaCobar.Rows(i - 1).Cells("Cobrar").Value = True Then
                                    Monto = dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value

                                    If Monto <> 0 Then
                                        If MontoPagado > 0 Then
                                            If MontoPagado >= Monto Then
                                                dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                                ImporteGrilla = Monto
                                            Else
                                                dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                                ImporteGrilla = MontoPagado
                                            End If
                                            MontoPagado = Monto - MontoPagado
                                            MontoPagado = MontoPagado * (-1)

                                            If dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                                TipoFormaPago = 1
                                            Else
                                                TipoFormaPago = 2
                                            End If

                                            CobroDetalleBindingSource.AddNew()

                                            Dim c As Integer = dgvFormaCobro.RowCount

                                            If btmodificar = 1 Then
                                                If ContNewFilasEdit = 0 Then
                                                    CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                                    CodPago = CodPago + 1
                                                    ContNewFilasEdit = ContNewFilasEdit + 1
                                                Else
                                                    CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                                    ContNewFilasEdit = ContNewFilasEdit + 1
                                                End If
                                            Else
                                                If c = 1 Then
                                                    CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                                    CodPago = CodPago + 1
                                                ElseIf c > 1 Then
                                                    CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                                End If
                                            End If

                                            Dim sinfechadet As Boolean = False
                                            If dtpFechaCobroDet.Text = "" Then
                                                sinfechadet = True
                                                dtpFechaCobroDet.Value = dtpRegFechaCobro.Text
                                            End If

                                            Dim conctFecha As String
                                            Dim conctHora As String = Now.ToString("HH:mm:ss")
                                            If sinfechadet = True Then
                                                conctFecha = dtpFechaCobroDet.Value
                                            Else
                                                conctFecha = dtpFechaCobroDet.Text
                                            End If

                                            Dim conctFechaHora As String = conctFecha & " " + conctHora
                                            Try
                                                dgvFormaCobro.Rows(c - 1).Cells("NUMVENTA1").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMVENTA").Value
                                                dgvFormaCobro.Rows(c - 1).Cells("CODVENTADET").Value = dgvFacturasaCobar.Rows(i - 1).Cells("CODVENTA").Value
                                                dgvFormaCobro.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                                dgvFormaCobro.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoCobro.Text
                                                dgvFormaCobro.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                                dgvFormaCobro.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoCobro.SelectedValue()
                                                dgvFormaCobro.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                                dgvFormaCobro.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                                                dgvFormaCobro.Rows(c - 1).Cells("CUENTA").Value = ""
                                                dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value = 0
                                                dgvFormaCobro.Rows(c - 1).Cells("NUMDEVOLUCION").Value = ""
                                                dgvFormaCobro.Rows(c - 1).Cells("CODNRODEV").Value = ""
                                                dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                                dgvFormaCobro.Rows(c - 1).Cells("NUMRETENCION").Value = ""
                                                dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"
                                                dgvFormaCobro.Rows(c - 1).Cells("CODMONEDA2").Value = moneda
                                                dgvFormaCobro.Rows(c - 1).Cells("NROREF").Value = tbxNroRef.Text
                                                dgvFormaCobro.Rows(c - 1).Cells("SFCODCOBRO").Value = dgvSaldoF.Rows(j).Cells("IDFORMACOBRARSF").Value
                                            Catch ex As Exception
                                            End Try

                                            If cmbBanco.Text = "" Then
                                                'dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = ""
                                            Else
                                                dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = cmbBanco.SelectedValue
                                            End If

                                            lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                                            lblPagado.Text = FormatNumber(lblPagado.Text, 0)
                                        End If
                                    End If
                                End If
                            Next

                        Else
                            For i = 1 To dgvFacturasaCobar.RowCount
                                Monto = dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value

                                If Monto <> 0 Then
                                    If MontoPagado > 0 Then
                                        If MontoPagado >= Monto Then
                                            dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = "0"
                                            ImporteGrilla = Monto
                                        Else
                                            dgvFacturasaCobar.Rows(i - 1).Cells("SALDOCUOTA").Value = Monto - MontoPagado
                                            ImporteGrilla = MontoPagado
                                        End If
                                        MontoPagado = Monto - MontoPagado
                                        MontoPagado = MontoPagado * (-1)

                                        If dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "CONTADO" Or dgvFacturasaCobar.Rows(i - 1).Cells("TIPOFACTURA").Value = "Contado" Then
                                            TipoFormaPago = 1
                                        Else
                                            TipoFormaPago = 2
                                        End If

                                        'Insertamos en la grilla
                                        'dgvFormaCobro.Rows.Add()
                                        CobroDetalleBindingSource.AddNew()
                                        Dim c As Integer = dgvFormaCobro.RowCount

                                        If btmodificar = 1 Then
                                            If ContNewFilasEdit = 0 Then
                                                CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                                CodPago = CodPago + 1
                                                ContNewFilasEdit = ContNewFilasEdit + 1
                                            Else
                                                CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                                ContNewFilasEdit = ContNewFilasEdit + 1
                                            End If
                                        Else
                                            If c = 1 Then
                                                CodPago = f.Maximo("CODCOBRO", "VENTASFORMACOBRO")
                                                CodPago = CodPago + 1
                                            ElseIf c > 1 Then
                                                CodPago = dgvFormaCobro.Rows(c - 2).Cells("CODPAGO").Value + 1
                                            End If
                                        End If

                                        Dim sinfechadet As Boolean = False
                                        If dtpFechaCobroDet.Text = "" Then
                                            sinfechadet = True
                                            dtpFechaCobroDet.Value = dtpRegFechaCobro.Text
                                        End If

                                        Dim conctFecha As String
                                        Dim conctHora As String = Now.ToString("HH:mm:ss")
                                        If sinfechadet = True Then
                                            conctFecha = dtpFechaCobroDet.Value
                                        Else
                                            conctFecha = dtpFechaCobroDet.Text
                                        End If
                                        Dim conctFechaHora As String = conctFecha & " " + conctHora

                                        dgvFormaCobro.Rows(c - 1).Cells("NUMVENTA1").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMVENTA").Value
                                        dgvFormaCobro.Rows(c - 1).Cells("CODVENTADET").Value = dgvFacturasaCobar.Rows(i - 1).Cells("CODVENTA").Value
                                        dgvFormaCobro.Rows(c - 1).Cells("IMPORTE").Value = ImporteGrilla
                                        dgvFormaCobro.Rows(c - 1).Cells("DESTIPOPAGO").Value = lbxTipoCobro.Text
                                        dgvFormaCobro.Rows(c - 1).Cells("FECHAPAGO").Value = conctFechaHora
                                        dgvFormaCobro.Rows(c - 1).Cells("CODTIPOPAGO").Value = lbxTipoCobro.SelectedValue
                                        dgvFormaCobro.Rows(c - 1).Cells("CODPAGO").Value = CodPago
                                        dgvFormaCobro.Rows(c - 1).Cells("NROCUOTA").Value = dgvFacturasaCobar.Rows(i - 1).Cells("NUMEROCUOTA").Value
                                        dgvFormaCobro.Rows(c - 1).Cells("CUENTA").Value = cmbCaja.Text
                                        dgvFormaCobro.Rows(c - 1).Cells("CODCUENTA").Value = cmbCaja.SelectedValue
                                        dgvFormaCobro.Rows(c - 1).Cells("NUMDEVOLUCION").Value = ""
                                        dgvFormaCobro.Rows(c - 1).Cells("CODNRODEV").Value = ""
                                        dgvFormaCobro.Rows(c - 1).Cells("FORMAPAGO").Value = TipoFormaPago
                                        dgvFormaCobro.Rows(c - 1).Cells("NUMRETENCION").Value = ""
                                        dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"
                                        dgvFormaCobro.Rows(i - 1).Cells("CODMONEDA2").Value = moneda
                                        dgvFormaCobro.Rows(c - 1).Cells("NROREF").Value = ""
                                        If btmodificar = 1 Then
                                            dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "IU"
                                            dgvFormaCobro.Rows(c - 1).Cells("CABCOBRO").Value = dgvCobros.CurrentRow.Cells("CABCOBRO").Value
                                        Else
                                            dgvFormaCobro.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"
                                        End If
                                        dgvFormaCobro.Rows(c - 1).Cells("SFCODCOBRO").Value = dgvSaldoF.Rows(j).Cells("IDFORMACOBRARSF").Value

                                        If cmbBanco.Text = "" Then
                                            'dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = ""
                                        Else
                                            dgvFormaCobro.Rows(c - 1).Cells("CODBANCO").Value = cmbBanco.SelectedValue
                                        End If

                                        lblPagado.Text = CDec(lblPagado.Text) + ImporteGrilla
                                        lblPagado.Text = FormatNumber(lblPagado.Text, 0)
                                    End If
                                End If
                            Next
                        End If
                    Else
                        MessageBox.Show("La Nota de Credito Nro :" & dgvSaldoF.Rows(j).Cells("NUMDEVOLUCIONDataGridViewTextBoxColumn1").Value & " ya fue utilizada anteriormente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Next

            lblSaldoFavor.Text = CDec(lblMontoSelecionado.Text) - CDec(lblPagado.Text)
            lblSaldoFavor.Text = FormatNumber(lblSaldoFavor.Text, 2)
            lblSaldoF.Text = "Falta Cobrar :"

            UltraPopupControlContainer2.Close()
            If lbxTipoCobro.SelectedValue <> 5 And lbxTipoCobro.SelectedValue <> 8 And lbxTipoCobro.SelectedValue <> 7 Then
                umeTotalRec.Text = CDec(umeTotalRec.Text) + ImporteGrilla
            End If

            LimpiarDetalle()
            tbxMonto.Text = lblSaldoFavor.Text
            tbxMonto.Focus()
            lbxTipoCobro.SelectedValue = 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvFacturasaCobar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvFacturasaCobar.KeyDown
        If e.KeyCode = Keys.Space Then 'Ir a Montos
            If dgvFacturasaCobar.CurrentRow.Cells("Cobrar").Value = False Then
                dgvFacturasaCobar.CurrentRow.Cells("Cobrar").Value = True
                dgvFacturasaCobar_CellContentClick(Nothing, Nothing)
            Else
                dgvFacturasaCobar.CurrentRow.Cells("Cobrar").Value = False
                dgvFacturasaCobar_CellContentClick(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub tbxBuscSaldoFavor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxBuscSaldoFavor.KeyPress
        Try
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If KeyAscii = 42 Then
                If ModifSF = 0 Then
                    FACTURACOBRARSALDOFAVORTableAdapter.Fill(DsCobros2.FACTURACOBRARSALDOFAVOR, CmbCliente.SelectedValue)
                    If dgvSaldoF.RowCount = 0 Then
                        MessageBox.Show("No existen Saldos a Favor del Cliente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        UltraPopupControlContainer1.PopupControl = pnlSaldo
                        UltraPopupControlContainer1.Show()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btGuardarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btGuardarOBS.Click
        'Actualizamos la OBS del Cobro Seleccionado
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            Dim nroRecibo As Integer = dgvCobros.CurrentRow.Cells("DataGridViewTextBoxColumn44").Value

            sql = "UPDATE VENTASFORMACOBRO SET OBSERVACIONES  = '" & Me.tbxObservaciones.Text & "'  WHERE NRORECIBO = " & nroRecibo

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()

            MessageBox.Show("Observacion Guardada Exitosamente!! ", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlObservacion.Visible = False

        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch
            End Try
            MsgBox("No se pudo Guardar la OBS..", MsgBoxStyle.Exclamation)
            Throw
        End Try
    End Sub


    Private Sub EliminarPictureBox_Click(sender As Object, e As EventArgs) Handles EliminarPictureBox.Click  'Marilin y Will.i.am Crearon esto :)
        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction

        Dim nrorecibo As String = dgvCobros.CurrentRow.Cells("DataGridViewTextBoxColumn44").Value
        Dim codcobro, nrocuota, codventa As Integer
        Dim importecuota As Double


        If MessageBox.Show("¿Está seguro que desea eliminar el Cobro?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = MsgBoxResult.No Then
            Exit Sub
        End If

        conexion = ser.Abrir()
        Try
            consulta = ""
            For i = 1 To dgvFormaCobro.RowCount
                codcobro = dgvFormaCobro.Rows(i - 1).Cells("CODPAGO").Value
                nrocuota = dgvFormaCobro.Rows(i - 1).Cells("NROCUOTA").Value
                importecuota = dgvFormaCobro.Rows(i - 1).Cells("IMPORTE").Value
                If IsDBNull(dgvFormaCobro.Rows(i - 1).Cells("CODVENTADET").Value) Then
                    codventa = 0
                Else
                    codventa = dgvFormaCobro.Rows(i - 1).Cells("CODVENTADET").Value
                End If

                Dim aux As String
                If dgvFormaCobro.Rows(i - 1).Cells("SFCODCOBRO").Value Is Nothing Or IsDBNull(dgvFormaCobro.Rows(i - 1).Cells("SFCODCOBRO").Value) Then
                    aux = 0
                Else
                    aux = dgvFormaCobro.Rows(i - 1).Cells("SFCODCOBRO").Value
                End If

                If f.FuncionConsultaString("CLIENTEMOVID", "CLIENTESCUENTACORRIENTE", "CODCOBRO", codcobro) <> 0 Then
                    consulta = consulta + "DELETE FROM CLIENTESCUENTACORRIENTE WHERE CODCOBRO = " & CDec(codcobro) & "  "
                End If
                If f.FuncionConsultaString("id_movimiento", "movimientos", "id_cobro", codcobro) <> 0 Then
                    consulta = consulta + "DELETE FROM movimientos WHERE id_cobro = " & CDec(codcobro) & "  "
                End If
                If f.FuncionConsultaString("CODCOBRO", "VENTASFORMACOBRO", "CODCOBRO", codcobro) <> 0 Then
                    consulta = consulta + "DELETE FROM VENTASFORMACOBRO WHERE CODCOBRO= " & CDec(codcobro) & "  "
                End If
                If f.FuncionConsultaString("CODNUMEROCUOTA", "FACTURACOBRAR", "CODVENTA", codventa) <> 0 Then
                    consulta = consulta + "UPDATE FACTURACOBRAR SET SALDOCUOTA = SALDOCUOTA + replace('" & CDec(importecuota) & "', ',', '.'), PAGADO = 0 WHERE CODVENTA = " & CDec(codventa) & " AND CODNUMEROCUOTA = " & CDec(nrocuota) & "  "
                End If
                If dgvFormaCobro.Rows(i - 1).Cells("DESTIPOPAGO").Value = "Nota de Credito" Then
                    consulta = consulta + "UPDATE DEVOLUCIONES SET COBRADO = 0 WHERE NUMDEVOLUCION = " & dgvFormaCobro.Rows(i - 1).Cells("NUMDEVOLUCION").Value & ""
                ElseIf dgvFormaCobro.Rows(i - 1).Cells("DESTIPOPAGO").Value = "Aplique Saldo a Favor" Then
                    consulta = consulta + "UPDATE FACTURACOBRAR SET CODNUMEROCUOTA = 0 WHERE IDFORMACOBRAR = " & aux & ""
                End If
            Next
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            Try
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
            Catch ex As SqlException
                Try
                    myTrans.Rollback("Eliminar")
                Catch

                End Try
                Throw ex
            Finally
                myTrans.Dispose()
            End Try
        Catch
            MessageBox.Show("Ocurrió un error al eliminar el cobro", "POSEXPRESS")
            conexion.Close()
        Finally
            MessageBox.Show("Cobro eliminado correctamente! ", "POSEXPRESS")
            conexion.Close()
        End Try

        '#######################################################################################################
        '#######################################################################################################
        FechaFiltro()
        Me.CLIENTESTableAdapter1.Fill(Me.DsCobros2.CLIENTES)
        COBROCABECERATableAdapter.Fill(Me.DsCobros3.COBROCABECERA, FechaFiltro1, FechaFiltro2)
        If dgvCobros.RowCount > 0 Then
            FACTURAACOBRARTableAdapter1.Fill(DsCobros2.FACTURAACOBRAR, CmbCliente.SelectedValue)
            SALDOVENCIDOTableAdapter1.Fill(DsCobros2.SALDOVENCIDO, Today, CmbCliente.SelectedValue)
        End If

        LimpiaFormulario()
        lblMontoSelecionado.Text = "0 Gs"
        DeshabilitarControles()

        lblCuotas.Text = "" : lblNroFacturas.Text = "" : lblPagado.Text = "" : lblSaldoFavor.Text = ""

        pnlFacturasaCobrar.Visible = False
        lblDetalles.Text = "Ver Detalles"
        btnDetalles.Image = My.Resources.DisplayActive

        btnAgregarPago.BringToFront()
        btnEliminarPago.BringToFront()
        ModificarDetPictureBox.Image = My.Resources.Edit
        ModificarDetPictureBox.Enabled = True
        tsEditar.Enabled = True
        lbxTipoCobro.SelectedValue = 1
        lbxTipoCobro_SelectedIndexChanged(Nothing, Nothing) 'Forzamos porque si ya estaba en Efectivo no hace y trae mal

        If saldoF = True Then
            pnlEstado.BackColor = Color.Tan
            TIPOFORMACOBROBindingSource.RemoveFilter()
        End If

        ErrorGuardar = 0 : dgvCobros.Enabled = True : BtnFiltro.Enabled = True : BuscarTextBox.Enabled = True : FiltroPagosActivo.Enabled = True
        TipoCobroPictureBox.Enabled = True : PendientesPago.Enabled = True : cmbGenerarRecibo.Text = ""
        btnuevo = 0 : btmodificar = 0 : ModifNC = 0 : ModifSF = 0 : saldoF = False : lblACobrar2.Visible = False : lblMontoSelec2.Visible = False
        lblProximoNro.Text = "Ver Próximo Nro. de Recibo"
        vgSaldoA = 0

    End Sub

  
    Private Sub ReImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReImprimirToolStripMenuItem.Click
        Try
            Dim Imprimir As Integer = f.FuncionConsultaDecimal("dbo.DETPC.IMPRIMIR", " dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE", "dbo.DETPC.ACTIVO = 1 AND dbo.TIPOCOMPROBANTE.COBROS", 1)
            If btnuevo = 0 Then
                btnuevo = 1
            End If
            If Imprimir = 1 And btnuevo = 1 And saldoF = False Then
                ImprimirReporte()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class






