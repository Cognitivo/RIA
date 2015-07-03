Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad
Imports System.Drawing.SystemIcons

'Para Escribir en un archivo 
Imports System
Imports System.IO
Imports System.IO.StreamWriter
Imports Funciones.Funciones

Public Class FiltroReporteContabilidad
    Dim sql As String
    Dim sql1 As String
    Dim Pos1 As System.Drawing.Point = New Point(3, 56)
    Dim Pos2 As System.Drawing.Point = New Point(3, 104)
    Dim Pos3 As System.Drawing.Point = New Point(3, 152)
    Dim Pos4 As System.Drawing.Point = New Point(3, 200)
    Dim Pos5 As System.Drawing.Point = New Point(3, 248)
    Dim Pos6 As System.Drawing.Point = New Point(3, 296)
    Dim Pos7 As System.Drawing.Point = New Point(3, 344)
    Dim PosSinFiltro As System.Drawing.Point = New Point(4, 31)
    Dim PosInvisible As System.Drawing.Point = New Point(700, 33)
    Dim permiso As Double
    Dim FechaDesde As String
    Dim FechaHasta As String
    Dim ListaReportes(47, 3) As String
    Dim dtComprobante As DataTable
    Dim CodigoGral, FormatF1, Formateado As String
    Dim f As New Funciones.Funciones
    Dim banverifcheck, banComprVent, banCompNC As Boolean

    'Variables para la Conexion con la BD
    Private objCommand As New SqlCommand
    Private ser As BDConexión.BDConexion
    Private consulta As System.String
    Private conexion As System.Data.SqlClient.SqlConnection
    Private myTrans As System.Data.SqlClient.SqlTransaction

    Sub New()
        InitializeComponent()
        ser = New BDConexión.BDConexion()
    End Sub

    Private Sub ReporteVentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CAJATableAdapter.Fill(Me.DsCaja.CAJA)
        Me.PlancuentasTableAdapter.Fill(Me.DsInfContabilidad.plancuentas)
        Me.SUCURSALTableAdapter.Fill(Me.DsInfContabilidad.SUCURSAL)
        Me.PeriodofiscalTableAdapter.Fill(Me.DsInfContabilidad.periodofiscal)

        banComprVent = False
        banCompNC = False

        pnlFiltros.Visible = False
        cargarListaReportes()
        PintarCeldas()

        cmbMes.Text = Now.Month
        cmbAño.Text = Now.Year
        cmbDesde.Text = "1"
        cmbHasta.Text = "30"
        Dim _id As Integer = f.FuncionConsulta("CODPERIODOFISCAL", "periodofiscal", "ESTADO", "1")
        cmbPeriodoFiscal.SelectedValue = _id

        Select Case cmbMes.Text
            Case "1" : cmbMes.Text = "Enero"
            Case "2" : cmbMes.Text = "Febrero"
            Case "3" : cmbMes.Text = "Marzo"
            Case "4" : cmbMes.Text = "Abril"
            Case "5" : cmbMes.Text = "Mayo"
            Case "6" : cmbMes.Text = "Junio"
            Case "7" : cmbMes.Text = "Julio"
            Case "8" : cmbMes.Text = "Agosto"
            Case "9" : cmbMes.Text = "Septiembre"
            Case "10" : cmbMes.Text = "Octubre"
            Case "11" : cmbMes.Text = "Noviembre"
            Case "12" : cmbMes.Text = "Diciembre"
        End Select

        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)
    End Sub

    Public Sub PintarCeldas()
        If dgvListaReportes.RowCount - 1 > 1 Then
            For i = 0 To dgvListaReportes.RowCount - 1
                If dgvListaReportes.Rows(i).Cells("REFERENCIA").Value = "TITULO" Then
                    dgvListaReportes.Item(0, i).Style.BackColor = Color.PaleGoldenrod
                Else
                    dgvListaReportes.Item(0, i).Style.BackColor = Color.White
                End If
            Next
        End If
    End Sub

    Private Sub cargarListaReportes()
        ListaReportes = {{"TITULO", "LIBROS", "Libros,Diario,Mayor,IVA"},
                            {"rptLibroDiario", "Libro Diario", "Libros,Diario,Mayor,IVA"},
                            {"rptLibroDiarioResumido", "Libro Diario Resumido", "Libros,Diario,Mayor,IVA"},
                            {"rptLibroMayor", "Libro Mayor", "Libros,Diario,Mayor,IVA"},
                            {"rptLibroIvaVentas", "Libro Iva Ventas - Ley 125 / 91", "Libros,Diario,Mayor,IVA"},
                            {"rptLibroIvaCompras", "Libro Iva Compras - Ley 125 / 91", "Libros,Diario,Mayor,IVA"},
                            {"rptLibroIvaTicket", "Libro Iva Ticket - Ley 14 / 92", "Libros,Ticket,Ley,IVA"},
                            {"TITULO", "BALANCES", "Balances,General,Resultados,Suma, Saldo"},
                            {"rptBalanceGeneral", "Balance General", "Balances,General,Resultados,Suma, Saldo"},
                            {"rptBalanceGeneral173", "Balance General Según RES. 49", "Balances,General,Resultados,Suma, Saldo"},
                            {"rptBalanceGeneralImpositivo", "Balance General Impositivo", "Balance,Impositivo"},
                            {"rptBalanceGeneralImpositivoResumido", "Balance General Impositivo Resumido", "Balance,Impositivo Resumido"},
                            {"rptCuadroResultado49", "Cuadro Resultado Según RES. 49", "Balances,General,Resultados,Suma, Saldo"},
                            {"rptCuadroResultado", "Cuadro Resultado", "Balances,General,Resultados,Suma, Saldo"},
                            {"rptBalanceSumaySaldo", "Balance Suma y Saldo", "Balances,General,Resultados,Suma, Saldo"},
                            {"TITULO", "EXPORTAR DATOS", "Exportar,Libro,Excel,IVA,Retenciones"},
                            {"rptHechaukaVenta", "Libro Venta (Hechauka)", "Exportar,Libro,Excel,IVA"},
                            {"rptHechaukaCompra", "Libro Compra (Hechauka)", "Exportar,Libro,Excel,IVA"},
                            {"rptHechaukaRetenciones", "Retenciones en la Fuente (Hechauka)", "Exportar,Libro,Excel,IVA,Retenciones"},
                            {"rptLibroVenta", "Libro Venta (Excel)", "Exportar,Libro,Excel,IVA"},
                            {"rptLibroCompra", "Libro Compra (Excel)", "Exportar,Libro,Excel,IVA"},
                            {"TITULO", "LISTADO", "Listado,Plan de Cuentas,Plan,Cuenta"},
                            {"rptListadoPlan", "Plan de Cuentas", "Listado,Plan de Cuentas,Plan,Cuenta"},
                            {"TITULO", "RETENCIONES", "Detalle,Detalle de Retenciones,Retenciones, Iva, Renta"},
                            {"rptDetalleRetenciones", "Detalle de Retenciones IVA", "Retenciones,IVA"},
                            {"rptRetencionesRenta", "Retenciones Renta", "Retenciones,Renta"}}

        For i = 0 To 25
            dgvListaReportes.Rows.Add()
            dgvListaReportes.Item(1, i).Value = ListaReportes(i, 0)
            dgvListaReportes.Item(0, i).Value = ListaReportes(i, 1)
            dgvListaReportes.Item(2, i).Value = ListaReportes(i, 2)
        Next
        dgvListaReportes.AllowUserToAddRows = False
    End Sub

    Private Sub InvisivilizarTodo()
        pnlFacturasAnuladas.Location = PosInvisible
        pnlFechaPeriodo.Location = PosInvisible
        pnlfechas.Location = PosInvisible
        pnlLocalizacion.Location = PosInvisible
        pnlPeriodoFiscal.Location = PosInvisible
        pnlSinFiltro.Location = PosInvisible
        pnlTipoReporte.Location = PosInvisible
        pnlRegistrosAsentados.Location = PosInvisible
        pnlSucursal.Location = PosInvisible
        Panel2.Location = PosInvisible
        pnlComprobante.Location = PosInvisible
        pnlCaja.Location = PosInvisible

        chbxMatricial.Visible = False
        chbxNuevaVent.Visible = False
    End Sub

    Private Sub dgvListaReportes_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvListaReportes.SelectionChanged
        InvisivilizarTodo()
        btnGenerar.Visible = True
        dtpFechaDesde.Enabled = True

        Dim rpt As Reportes.ReporteBlanco
        CrystalReportViewer.ReportSource = rpt
        If pnlFiltros.Visible = False Then
            pnlFiltros.Visible = True
        End If

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptHechaukaVenta" Then
            chbxMatricial.Visible = False
            chbxNuevaVent.Visible = False

            pnlPeriodoFiscal.Location = Pos1
            pnlTipoReporte.Location = Pos2
            pnlRegistrosAsentados.Location = Pos3
            pnlFacturasAnuladas.Location = Pos4
            pnlComprobante.Location = Pos5
            pnlFechaPeriodo.Location = Pos6
            pnlLocalizacion.Location = Pos7

            cmbComprobante.Text = "%"

            lblReporte.Text = "Libro Venta (Hechauka)"
            lblReporteDescrip.Text = "Exporta los Registros Asentados del Libro de Venta en un archivo formato .TXT"
            btnGenerar.Text = "Exportar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptHechaukaCompra" Then
            chbxMatricial.Visible = False
            chbxNuevaVent.Visible = False

            pnlPeriodoFiscal.Location = Pos1
            pnlTipoReporte.Location = Pos2
            pnlRegistrosAsentados.Location = Pos3
            pnlFacturasAnuladas.Location = Pos4
            pnlComprobante.Location = Pos5
            pnlFechaPeriodo.Location = Pos6
            pnlLocalizacion.Location = Pos7

            cmbComprobante.Text = "%"

            lblReporte.Text = "Libro Compra (Hechauka)"
            lblReporteDescrip.Text = "Exporta los Registros Asentados del Libro de Compra en un archivo formato .TXT"
            btnGenerar.Text = "Exportar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptHechaukaRetenciones" Then
            chbxMatricial.Visible = False
            chbxNuevaVent.Visible = False

            pnlPeriodoFiscal.Location = Pos1
            pnlTipoReporte.Location = Pos2
            pnlRegistrosAsentados.Location = Pos3
            pnlComprobante.Location = Pos4
            pnlFechaPeriodo.Location = Pos5
            pnlLocalizacion.Location = Pos6

            cmbComprobante.Text = "%"

            lblReporte.Text = "Retenciones en la Fuente (Hechauka)"
            lblReporteDescrip.Text = "Exporta los Registros Asentados de Retenciones en un archivo formato .TXT"
            btnGenerar.Text = "Exportar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroVenta" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = False
            chbxNuevaVent.Visible = False

            pnlSucursal.Location = Pos1
            pnlRegistrosAsentados.Location = Pos2
            pnlfechas.Location = Pos3
            pnlLocalizacion.Location = Pos4

            lblReporte.Text = "Libro Venta (Excel)"
            lblReporteDescrip.Text = "Exporta los Registros Asentados del Libro de Venta en un archivo formato Excel"
            btnGenerar.Text = "Exportar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroCompra" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = False
            chbxNuevaVent.Visible = False

            pnlSucursal.Location = Pos1
            pnlRegistrosAsentados.Location = Pos2
            pnlfechas.Location = Pos3
            pnlLocalizacion.Location = Pos4

            lblReporte.Text = "Libro Compra (Excel)"
            lblReporteDescrip.Text = "Exporta los Registros Asentados del Libro de Compra en un archivo formato Excel"
            btnGenerar.Text = "Exportar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListadoPlan" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlSinFiltro.Location = Pos1

            lblReporte.Text = "Listado de Plan de Cuentas"
            lblReporteDescrip.Text = " Permite visualizar el listado de Plan de Cuentas con algunas de sus determinadas características."
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceGeneral" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporte.Text = "Balance General"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Balance General "
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceGeneral173" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporte.Text = "Balance General"
            lblReporteDescrip.Text = " Permite la emisión y/o impresión del Balance General según formato establecido por la Resolución 173"
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceGeneralImpositivo" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporte.Text = "Balance General Impositivo"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Balance General Impositivo "
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceGeneralImpositivoResumido" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporte.Text = "Balance General Impositivo Resumido"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Balance General Impositivo Resumido "
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceSumaySaldo" Then
            InvisivilizarTodo()

            Try
                'Obtenemos la fecha de inicio del Periodo fiscal seleccionado
                Dim FechaPeriodo As String = f.FuncionConsultaString("FECHAINICIO", "periodofiscal", "CODPERIODOFISCAL", cmbPeriodoFiscal.SelectedValue)
                dtpFechaDesde.Text = FechaPeriodo
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporte.Text = "Balances de Sumas y Saldos"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Balances de Sumas y Saldos "
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCuadroResultado49" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporte.Text = "Cuadro de Resultado"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Cuadro de Resultados Segun la Resolucion 49 "
            btnGenerar.Text = "Generar Datos"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCuadroResultado" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporte.Text = "Cuadro de Resultado"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Cuadro de Resultados"
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaVentas" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2

            cmbSucursal.Text = "%"

            lblReporte.Text = "Libro Iva de Ventas"
            lblReporteDescrip.Text = " Permite visualizar los totales que se han registrado en una determinada venta,ya sean Gravadas,Exentas,Total Iva y Total de la Venta."
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaCompras" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2

            cmbSucursal.Text = "%"

            lblReporte.Text = "Libro Iva de Compras"
            lblReporteDescrip.Text = " Permite visualizar los totales que se han registrado en una determinada Compra,ya sean Gravadas,Exentas,Total Iva y Total de la Compra."
            btnGenerar.Text = "Generar Datos"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaTicket" Then 'Saul
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlCaja.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporte.Text = "Libro Iva Ticket"
            lblReporteDescrip.Text = " Permite visualizar los detalles de los Ticket emitidos según Ley 14/92"
            btnGenerar.Text = "Generar Datos"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroDiario" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlSucursal.Location = Pos2
            pnlfechas.Location = Pos3

            cmbSucursal.Text = "%"

            lblReporte.Text = "Libro Diario"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Libro Diario de Cuentas. "
            btnGenerar.Text = "Generar Datos"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroDiarioResumido" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlSucursal.Location = Pos2
            pnlfechas.Location = Pos3

            cmbSucursal.Text = "%"

            lblReporte.Text = "Libro Diario Resumido"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Libro Diario de Cuentas de forma Resumida"
            btnGenerar.Text = "Generar Datos"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroMayor" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlPeriodoFiscal.Location = Pos1
            pnlfechas.Location = Pos2
            Panel2.Location = Pos3

            lblReporte.Text = "Libro Mayor"
            lblReporteDescrip.Text = " Permite la emisión o impresión del Libro Mayor de Cuentas. "
            btnGenerar.Text = "Generar Datos"
            '******************************************************** SAUL
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDetalleRetenciones" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlCaja.Location = Pos1
            pnlSucursal.Location = Pos2
            pnlfechas.Location = Pos3

            cbxCaja.Text = "%"
            cmbSucursal.Text = "%"

            lblReporte.Text = "Detalle de Retenciones IVA"
            lblReporteDescrip.Text = " Permite la visualización de las Rentenciones del IVA. "
            btnGenerar.Text = "Generar Datos"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRetencionesRenta" Then
            InvisivilizarTodo()

            chbxNuevaVent.Visible = True

            pnlfechas.Location = Pos1

            lblReporte.Text = "Detalle de Retenciones Renta"
            lblReporteDescrip.Text = " Permite la visualización de las Rentenciones Renta. "
            btnGenerar.Text = "Generar Datos"
            '*****************************************************
        Else
            pnlSinFiltro.Location = Pos1
            lblReporte.Text = ""
            lblReporteDescrip.Text = ""
            btnGenerar.Visible = False
        End If
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        Dim dgvcount As Integer = -1
        Dim strtitulo, strclave, strbusq As String
        Try
            If BuscarTextBox.Text = "" Or BuscarTextBox.Text = "Buscar..." Then
                dgvListaReportes.Rows.Clear()
                cargarListaReportes()
                dgvListaReportes.Sort(dgvListaReportes.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                dgvListaReportes_SelectionChanged(Nothing, Nothing)
            Else
                strbusq = StrConv(BuscarTextBox.Text, VbStrConv.Uppercase)
                dgvListaReportes.Rows.Clear()
                For i = 0 To ListaReportes.Length / 3 - 1
                    strtitulo = StrConv(ListaReportes(i, 1), VbStrConv.Uppercase)
                    strclave = StrConv(ListaReportes(i, 2), VbStrConv.Uppercase)
                    If strtitulo.Contains(strbusq) Or strclave.Contains(strbusq) Then
                        dgvcount = dgvcount + 1
                        dgvListaReportes.Rows.Add()
                        dgvListaReportes.Item(1, dgvcount).Value = ListaReportes(i, 0)
                        dgvListaReportes.Item(0, dgvcount).Value = ListaReportes(i, 1)
                        dgvListaReportes.Item(2, dgvcount).Value = ListaReportes(i, 2)
                    End If
                Next
                dgvListaReportes.Sort(dgvListaReportes.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                dgvListaReportes_SelectionChanged(Nothing, Nothing)
            End If

            PintarCeldas()
        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Desea ver el mensaje de error?", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try
        BuscarTextBox.Focus()
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        CrystalReportViewer.ShowPageNavigateButtons = True
        CrystalReportViewer.DisplayStatusBar = True
        CrystalReportViewer.DisplayToolbar = True

        Me.Cursor = Cursors.AppStarting

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptHechaukaVenta" Then
            rptHechaukaVenta()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptHechaukaRetenciones" Then
            rptHechaukaRetenciones()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptHechaukaCompra" Then
            rptHechaukaCompra()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroVenta" Then
            rptLibroVentaExcel()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroCompra" Then
            rptLibroCompraExcel()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListadoPlan" Then
            rptListadoPlan()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceGeneral" Then
            rptBalanceGeneral()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceGeneral173" Then
            rptBalanceGeneral173()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceGeneralImpositivo" Then
            rptBalanceGeneralImpositivo()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceGeneralImpositivoResumido" Then
            rptBalanceGeneralImpositivoResumido()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceSumaySaldo" Then
            rptBalanceSumaySaldo()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCuadroResultado" Then
            rptCuadroResultado()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCuadroResultado49" Then
            rptCuadroResultado49()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaVentas" Then
            rptLibroIvaVentas()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaCompras" Then
            rptLibroIvaCompras()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaTicket" Then
            rptLibroIvaTicket()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroMayor" Then
            rptLibroMayor()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroDiario" Then
            rptLibroDiario()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroDiarioResumido" Then
            rptLibroDiarioResumido()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDetalleRetenciones" Then 'Saul
            DetalleRetenciones()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRetencionesRenta" Then 'Saul
            RetencionesRenta()
        End If

        pnlFiltros.Visible = False
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rptLibroDiario()
        Dim frm = New VerInformes
        Dim rpt
        Dim rptmat

        If cmbSucursal.Text = "%" Then ' Sin Agrupar por sucursal
            Me.LibrioDiarioTableAdapter.FillBy(Me.DsInfContabilidad.LibrioDiario, dtpFechaDesde.Value, dtpFechaHasta.Value, Me.cmbPeriodoFiscal.SelectedValue)
            rpt = New Reportes.ContaLibroDiarioSINAGRUP
            rptmat = New Reportes.ContaLibroDiarioMATRSINAGRUP

        Else
            Me.LibrioDiarioTableAdapter.Fill(Me.DsInfContabilidad.LibrioDiario, dtpFechaDesde.Value, dtpFechaHasta.Value, Me.cmbPeriodoFiscal.SelectedValue, cmbSucursal.SelectedValue)
            rpt = New Reportes.ContaLibroDiario
            rptmat = New Reportes.ContaLibroDiarioMATR
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsInfContabilidad])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub rptLibroDiarioResumido()
        Dim frm = New VerInformes

        Dim rpt
        Dim rptmat

        If cmbSucursal.Text = "%" Then ' Sin Agrupar por sucursal
            Me.LibrioDiarioTableAdapter.FillBy(Me.DsInfContabilidad.LibrioDiario, dtpFechaDesde.Value, dtpFechaHasta.Value, Me.cmbPeriodoFiscal.SelectedValue)
            rpt = New Reportes.ContaLibroDiarioResumido
            rptmat = New Reportes.ContaLibroDiarioResumidoMATR

        Else
            Me.LibrioDiarioTableAdapter.Fill(Me.DsInfContabilidad.LibrioDiario, dtpFechaDesde.Value, dtpFechaHasta.Value, Me.cmbPeriodoFiscal.SelectedValue, cmbSucursal.SelectedValue)
            rpt = New Reportes.ContaLibroDiarioResumidoAGRUP
            rptmat = New Reportes.ContaLibroDiarioResumidoMATRAGRUP
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsInfContabilidad])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If

    End Sub

    Private Sub rptLibroMayor()

        Dim dsBalance As New DSContaBalanceGeneral()
        Dim LibroMayor As New DSContaBalanceGeneralTableAdapters.LibroMayorTableAdapter()

        '        SELECT        periodofiscal.DESEJERCICIO, ASIENTOS.IMPORTED, ASIENTOS.IMPORTEH, ASIENTOS.DETALLE, ASIENTOS.NUMCOMPROBANTE, ASIENTOS.FECHAASIENTO, ASIENTOS.NUMASIENTO, 
        '                         plancuentas.DESPLANCUENTA, plancuentas.NUMPLANCUENTA, periodofiscal.CODPERIODOFISCAL
        'FROM            ASIENTOS INNER JOIN
        '                         plancuentas ON ASIENTOS.CODPLANCUENTA = plancuentas.CODPLANCUENTA INNER JOIN
        '                         periodofiscal ON ASIENTOS.CODPERIODOFISCAL = periodofiscal.CODPERIODOFISCAL
        'WHERE        (ASIENTOS.FECHAASIENTO > CONVERT(DATETIME, @FECHADESDE, 102)) AND (ASIENTOS.FECHAASIENTO < CONVERT(DATETIME, @FECHAHASTA, 102)) AND 
        '                         (periodofiscal.CODPERIODOFISCAL = @CODPERIODO)
        'ORDER BY plancuentas.NUMPLANCUENTA, ASIENTOS.FECHAASIENTO

        Dim PlanCuentaList As String = ","

        For r As Integer = 0 To dgvCuenta.Rows.Count - 1
            If Convert.ToBoolean(dgvCuenta.Rows(r).Cells(2).Value) = True Then
                PlanCuentaList = PlanCuentaList & dgvCuenta.Rows(r).Cells(3).Value & ","
            End If
        Next
        LibroMayor.Fill(dsBalance.LibroMayor, dtpFechaDesde.Value, dtpFechaHasta.Value, Me.cmbPeriodoFiscal.SelectedValue, PlanCuentaList)

        'Dim cuenta, SaldoEsperado As String
        'Dim Primero As Integer = 0
        'Dim Saldo, SaldoAnt, AcumDebe, AcumHaber As Long
        'Dim dtSaldoAnterior As New DataTable
        'Dim dtHistoricoMayor As New DataTable
        'Dim ds As New EnviaInformes.DsInformes
        'Dim drHistoricoMayor As DataRow
        'Dim drSaldoAnt As DataRow
        'Dim drInf As DataRow
        'Dim FechaPeriodo As String = ""

        'SaldoEsperado = "" : cuenta = ""

        'For i = 1 To dgvCuenta.Rows.Count
        '    If (dgvCuenta.Rows(i - 1).Cells("Ver").Value) <> 0 Then
        '        If (dgvCuenta.Rows(i - 1).Cells("CODPLANCUENTA1").Value) <> 0 Then
        '            cuenta = dgvCuenta.Rows(i - 1).Cells("CODPLANCUENTA1").Value.ToString
        '            Try
        '                dtHistoricoMayor.Clear()
        '                HISTORICOLIBROMAYOTableAdapter.Fill(DsInfContabilidad.HISTORICOLIBROMAYO, dtpFechaDesde.Text, dtpFechaHasta.Text, cmbPeriodoFiscal.SelectedValue, cuenta)
        '                dtHistoricoMayor = HISTORICOLIBROMAYOTableAdapter.GetData(dtpFechaDesde.Text, dtpFechaHasta.Text, cmbPeriodoFiscal.SelectedValue, cuenta)

        '                'SI LA FECHA DESDE ES IGUAL AL 01/01/XXXX, DEBEMOS HACER UN FILL ESPECIAL
        '                Dim FechaDesde As Date = dtpFechaDesde.Text
        '                Dim FechaHasta As Date = dtpFechaDesde.Text
        '                Dim Day As String = FechaDesde.ToString("dd")
        '                Dim vMothn As String = FechaDesde.ToString("MM")

        '                If Day = "01" And vMothn = "01" Then
        '                    SaldoAnteriorTableAdapter.FillBy(DsInfContabilidad.SaldoAnterior, cuenta, CInt(cmbPeriodoFiscal.SelectedValue))
        '                    dtSaldoAnterior = SaldoAnteriorTableAdapter.GetDataBy(cuenta, CInt(cmbPeriodoFiscal.SelectedValue))
        '                Else
        '                    Try 'Obtenemos la fecha de inicio del Periodo fiscal seleccionado
        '                        FechaPeriodo = f.FuncionConsultaString("FECHAINICIO", "periodofiscal", "CODPERIODOFISCAL", cmbPeriodoFiscal.SelectedValue)
        '                    Catch ex As Exception
        '                    End Try

        '                    dtSaldoAnterior.Clear()
        '                    SaldoAnteriorTableAdapter.FillBy1(DsInfContabilidad.SaldoAnterior, cuenta, FechaHasta, cmbPeriodoFiscal.SelectedValue)
        '                    dtSaldoAnterior = SaldoAnteriorTableAdapter.GetDataBy1(cuenta, FechaHasta, cmbPeriodoFiscal.SelectedValue)
        '                End If

        '                'Obtenemos el Saldo Anterior
        '                If dtSaldoAnterior.Rows.Count = 0 Then
        '                    SaldoAnt = 0
        '                    Dim se As String = f.FuncionConsultaString("SALDOESPERADO", "PLANCUENTAS", "CODPLANCUENTA", cuenta)
        '                    SaldoEsperado = se
        '                    AcumDebe = 0
        '                    AcumHaber = 0
        '                Else
        '                    drSaldoAnt = dtSaldoAnterior.Rows.Item(0)

        '                    SaldoEsperado = CStr(drSaldoAnt("SALDOESPERADO"))
        '                    If CStr(drSaldoAnt("SALDOESPERADO")) = 2 Then
        '                        SaldoAnt = drSaldoAnt("TOTALHABER") - drSaldoAnt("TOTALDEBE")
        '                    Else
        '                        SaldoAnt = drSaldoAnt("TOTALDEBE") - drSaldoAnt("TOTALHABER")
        '                    End If
        '                    AcumDebe = drSaldoAnt("TOTALDEBE")
        '                    AcumHaber = drSaldoAnt("TOTALHABER")
        '                End If

        '                Saldo = SaldoAnt
        '                'Ahora debemos hacer el calculo de los saldos
        '                Dim c As Integer
        '                If dtHistoricoMayor.Rows.Count <> 0 Then
        '                    For c = 0 To dtHistoricoMayor.Rows.Count - 1
        '                        drHistoricoMayor = dtHistoricoMayor.Rows.Item(c)
        '                        drInf = ds.Tables("Detalle").NewRow()

        '                        If SaldoEsperado = 2 Then
        '                            Saldo = Saldo - drHistoricoMayor("IMPORTED") + drHistoricoMayor("IMPORTEH")
        '                        Else
        '                            Saldo = Saldo + drHistoricoMayor("IMPORTED") - drHistoricoMayor("IMPORTEH")
        '                        End If

        '                        If SaldoEsperado = Nothing Then
        '                            SaldoEsperado = 0
        '                        End If

        '                        drInf.Item("Numero1") = Saldo
        '                        drInf.Item("Numero2") = SaldoAnt
        '                        drInf.Item("Numero3") = drHistoricoMayor("IMPORTED")
        '                        drInf.Item("Numero4") = drHistoricoMayor("IMPORTEH")
        '                        drInf.Item("Numero5") = AcumDebe
        '                        drInf.Item("Numero6") = AcumHaber
        '                        drInf.Item("Campo1") = drHistoricoMayor("NUMPLANCUENTA")
        '                        drInf.Item("Campo2") = drHistoricoMayor("DESCRIPCION")
        '                        drInf.Item("Campo3") = drHistoricoMayor("NUMASIENTO")
        '                        drInf.Item("Campo4") = drHistoricoMayor("DETALLE")
        '                        drInf.Item("Campo5") = drHistoricoMayor("CODPLANCUENTA")
        '                        drInf.Item("Fecha1") = drHistoricoMayor("FECHAASIENTO")

        '                        ds.Tables("Detalle").Rows.Add(drInf)
        '                    Next
        '                Else
        '                    drInf = ds.Tables("Detalle").NewRow()
        '                    drInf.Item("Numero2") = SaldoAnt
        '                    ds.Tables("Detalle").Rows.Add(drInf)
        '                End If
        '            Catch ex As Exception
        '            End Try

        '        End If
        '    End If
        'Next

        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaLibroMayor_Simple
        rpt.SetDataSource(dsBalance)
        'Dim rptmat As New Reportes.ContaLibroMayorMATR

        'If SaldoEsperado = Nothing Then
        '    SaldoEsperado = 0
        'End If

        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()

        'Try
        '    rpt.SetDataSource([ds])
        '    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        '    rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)
        '    rpt.SetParameterValue("pmtSaldoEsp", SaldoEsperado)

        '    If chbxMatricial.Checked = True Then
        '        rptmat.SetDataSource([ds])
        '        rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        '        rptmat.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)
        '        rptmat.SetParameterValue("pmtSaldoEsp", SaldoEsperado)

        '        If chbxNuevaVent.Checked = True Then
        '            frm.CrystalReportViewer1.ReportSource = rptmat
        '            frm.WindowState = FormWindowState.Maximized
        '            frm.Show()
        '        Else
        '            CrystalReportViewer.ReportSource = rptmat
        '            CrystalReportViewer.Refresh()
        '        End If
        '    Else
        '        rpt.SetDataSource([ds])
        '        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        '        rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)
        '        rpt.SetParameterValue("pmtSaldoEsp", SaldoEsperado)

        '        If chbxNuevaVent.Checked = True Then
        '            frm.CrystalReportViewer1.ReportSource = rpt
        '            frm.WindowState = FormWindowState.Maximized
        '            frm.Show()
        '        Else
        '            CrystalReportViewer.ReportSource = rpt
        '            CrystalReportViewer.Refresh()
        '        End If
        '    End If
        'Catch ex As Exception
        '    If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
        '        MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'End Try
    End Sub

    Private Sub rptLibroIvaCompras()
        Dim frm = New VerInformes
        Dim rpt
        Dim rptmat
        Dim FechaInicio, FechaFin As String

        FechaInicio = dtpFechaDesde.Text & " 00:00:00"
        FechaFin = dtpFechaHasta.Text & " 23:59:59"

        If cmbSucursal.Text = "%" Then
            Me.LibroIvaComprasTableAdapter.FillBy(Me.DsInfContabilidad.LibroIvaCompras, FechaInicio, FechaFin)
            rpt = New Reportes.ContaLibroIvaCompras
            rptmat = New Reportes.ContaLibroIvaComprasMATR
        Else
            Me.LibroIvaComprasTableAdapter.Fill(Me.DsInfContabilidad.LibroIvaCompras, FechaInicio, FechaFin, cmbSucursal.SelectedValue)
            rpt = New Reportes.ContaLibroIvaComprasAGRUP
            rptmat = New Reportes.ContaLibroIvaComprasMATRAGRUP
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsInfContabilidad])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub rptLibroIvaTicket()
        Try
            Dim frm = New VerInformes
            Dim rpt As New Reportes.VentaContLibroIvaTicket
            Dim FechaInicio, FechaFin As String

            FechaInicio = dtpFechaDesde.Text & " 12:00:00 a.m."
            FechaFin = dtpFechaHasta.Text & " 11:59:00 p.m."

            Me.LibroIvaTicketTableAdapter.Fill(Me.DsInfContabilidad.LibroIvaTicket, FechaInicio, cbxCaja.Text, FechaFin)

            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            '**************************************************
            rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            rpt.SetParameterValue("ptmCaja", cbxCaja.Text)
            '**************************************************
            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try

    End Sub

    Private Sub rptLibroIvaVentas()
        Dim frm = New VerInformes
        Dim FechaInicio, FechaFin As String
        Dim rpt
        Dim rptmat

        FechaInicio = dtpFechaDesde.Text & " 12:00:00 a.m."
        FechaFin = dtpFechaHasta.Text & " 11:59:00 p.m."

        If cmbSucursal.Text = "%" Then
            Me.LibroIvaVentasTableAdapter.FillBy(Me.DsInfContabilidad.LibroIvaVentas, FechaInicio, FechaFin)
            rpt = New Reportes.ContaLibroIvaVentasSINAGRUP
            rptmat = New Reportes.ContaLibroIvaVentasMATR
        Else
            Me.LibroIvaVentasTableAdapter.Fill(Me.DsInfContabilidad.LibroIvaVentas, FechaInicio, FechaFin, cmbSucursal.SelectedValue)
            rpt = New Reportes.ContaLibroIvaVentas
            rptmat = New Reportes.ContaLibroIvaVentasMATRAGRUP
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsInfContabilidad])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub rptCuadroResultado49()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaEstadosDeResultados49
        Dim año As String
        año = Year(dtpFechaDesde.Text)
        Me.EstadosDeResultados49TableAdapter.Fill(Me.DsContaBalanceGeneral173.EstadosDeResultados49, CInt(Me.cmbPeriodoFiscal.SelectedValue), dtpFechaDesde.Text, dtpFechaHasta.Text, año)
        Me.SaldoEstadosDeResultados49TableAdapter.Fill(Me.DsContaBalanceGeneral173.SaldoEstadosDeResultados49, dtpFechaDesde.Text, dtpFechaHasta.Text, CInt(Me.cmbPeriodoFiscal.SelectedValue), año)

        rpt.SetDataSource([DsContaBalanceGeneral173])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)
        rpt.SetParameterValue("pmtPeriodoElegido", año)
        rpt.SetParameterValue("pmtPeriodoAnterior", año - 1)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub




    Private Sub rptCuadroResultado()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaCuadroResultados
        Dim rptmat As New Reportes.ContaCuadroResultadosMATR

        Me.CuadroResultadosTableAdapter.Fill(Me.DsInfContabilidad.CuadroResultados, Me.cmbPeriodoFiscal.SelectedValue, dtpFechaDesde.Value, dtpFechaHasta.Value)


        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsInfContabilidad])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub rptBalanceSumaySaldo()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaBalanceSumaSaldo
        Dim rptmat As New Reportes.ContaBalanceSumaSaldoMATR

        Me.BALANCESUMAYSALDOTableAdapter.Fill(Me.DsInfContabilidad.BALANCESUMAYSALDO, cmbPeriodoFiscal.SelectedValue, dtpFechaDesde.Value, dtpFechaHasta.Value)

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsInfContabilidad])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub rptHechaukaCompra()
        Dim ruta, ArchivoMes As String
        Dim Periodo, anho, mes, Cadena As String
        Dim TipoFactura, TipoReporte As String

        Periodo = "" : anho = "" : mes = "" : Cadena = "" : TipoFactura = ""

        'Verificamos que tengo una ruta para guardar el archivo
        If tbxLocalizacion.Text = "" Then
            MessageBox.Show("Ingrese la Dirección donde se Guardará el Archivo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxLocalizacion.Focus()
            Exit Sub
        End If

        Try
            Select Case cmbMes.Text
                Case "Enero" : mes = "01"
                Case "Febrero" : mes = "02"
                Case "Marzo" : mes = "03"
                Case "Abril" : mes = "04"
                Case "Mayo" : mes = "05"
                Case "Junio" : mes = "06"
                Case "Julio" : mes = "07"
                Case "Agosto" : mes = "08"
                Case "Septiembre" : mes = "09"
                Case "Octubre" : mes = "10"
                Case "Noviembre" : mes = "11"
                Case "Diciembre" : mes = "12"
            End Select

            anho = cmbAño.Text : Periodo = anho + mes
            ArchivoMes = CalcularMes(mes)
            Cadena = "\" & ArchivoMes & anho & "CompraHechauka.txt"

            If rbtnOriginal.Checked = True Then
                TipoReporte = 1
            ElseIf rbtnRectificativa.Checked = True Then
                TipoReporte = 2
            Else
                TipoReporte = 1
            End If

            ruta = tbxLocalizacion.Text & Cadena

            If File.Exists(ruta) = True Then
                If MessageBox.Show("Archivo '" & ArchivoMes & anho & " - CompraHechauka.txt' ya existe, desea sobreescribirlo?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    File.Delete(ruta)
                Else
                    'si usuario no quiere sobreescribir, no se hace nada...
                    Exit Sub
                End If
            End If

            Try
                Dim Hechauka As New Hechauka_Clase
                Hechauka.Hechauka_Comrpas(
                    rbnAnuladasSI.Checked,
                    cmbComprobante.Text,
                    cmbDesde.Text,
                cmbHasta.Text, mes, cmbAño.Text, tbxLocalizacion.Text, ruta,
                    TipoReporte,
                    rbtAsentadosSI)

                'Hechauka.Hechauka_Comrpas(rbnAnuladasSI.Checked, cmbComprobante.Text, mes, cmbDesde.Text, tbxLocalizacion.Text, cmbHasta.Text, cmbAño.Text, ruta, TipoReporte)
                'Hechauka.Hechauka_notadecredito(rbnAnuladasSI.Checked, cmbComprobante.Text, mes, cmbDesde.Text, tbxLocalizacion.Text, cmbHasta.Text, cmbAño.Text, ruta, TipoReporte)


                MessageBox.Show("Archivo Generado con Exito", "RIA.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MessageBox.Show("Error al Tratar de Escribir en el Archivo " & ex.Message, "RIA.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)

            MessageBox.Show("Error al Tratar de Escribir en el Archivo" & ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub


    Private Sub rptBalanceGeneral()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaBalanceGeneral
        Dim rptmat As New Reportes.ContaBalanceGeneralMATR
        Dim fechaini As String
        Dim fechafin As String
        fechaini = dtpFechaDesde.Text + " 00:00:00"
        fechafin = dtpFechaHasta.Text + " 23:59:59"
        Try
            'Me.CalculoResultadoTableAdapter.Fill(Me.DsCalculoResultado.CalculoResultado, fechaini, fechafin, CInt(Me.cmbPeriodoFiscal.SelectedValue))
        Catch
        End Try
        Me.BalanceGeneralTableAdapter.Fill(Me.DsInfContabilidad.BalanceGeneral, CInt(Me.cmbPeriodoFiscal.SelectedValue), fechaini, fechafin)

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsInfContabilidad])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub rptBalanceGeneral173()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaBalanceGeneral173
        Dim año As String
        año = Year(dtpFechaDesde.Text)
        Me.BalanceGeneral173TableAdapter.Fill(Me.DsContaBalanceGeneral173.BalanceGeneral173, CInt(Me.cmbPeriodoFiscal.SelectedValue), dtpFechaDesde.Text, dtpFechaHasta.Text, año)
        Me.SaldoBalanceGeneral173TableAdapter.Fill(Me.DsContaBalanceGeneral173.SaldoBalanceGeneral173, dtpFechaDesde.Text, dtpFechaHasta.Text, CInt(Me.cmbPeriodoFiscal.SelectedValue), año)

        rpt.SetDataSource([DsContaBalanceGeneral173])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)
        rpt.SetParameterValue("pmtPeriodoElegido", año)
        rpt.SetParameterValue("pmtPeriodoAnterior", año - 1)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Private Sub rptBalanceGeneralImpositivo()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaBalanceGeneralImpositivo
        'Dim rptmat As New Reportes.ContaBalanceGeneralMATR
        Dim fechaini As String
        Dim fechafin As String
        fechaini = dtpFechaDesde.Text + " 00:00:00"
        fechafin = dtpFechaHasta.Text + " 23:59:59"

        Dim dt As DataTable
        Dim Ria_DataAccessLayer As New Ria_DataAccessLayer.exeDataTable

        Dim NroPeriodo As Integer = cmbPeriodoFiscal.SelectedValue

        Dim Array As New ArrayList
        Array.Add(NroPeriodo)
        Array.Add(fechaini)
        Array.Add(fechafin)

        Dim connstring As String = My.Settings.GESTIONConnectionString2.ToString()

        dt = Ria_DataAccessLayer.loadDataTable("Exec BalanceGeneralImpositivo " & NroPeriodo & ",'" & fechaini & "','" & fechafin & "'", connstring)
        'Try
        '    Me.CalculoResultadoTableAdapter.Fill(Me.DsCalculoResultado.CalculoResultado, fechaini, fechafin, CInt(Me.cmbPeriodoFiscal.SelectedValue))
        'Catch
        'End Try
        'Me.BalanceGeneralTableAdapter.Fill(Me.DsInfContabilidad.BalanceGeneral, CInt(Me.cmbPeriodoFiscal.SelectedValue), fechaini, fechafin)

        rpt.SetDataSource([dt])
        'rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        'rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub rptBalanceGeneralImpositivoResumido()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaBalanceGeneralImpositivoResumido
        'Dim rptmat As New Reportes.ContaBalanceGeneralMATR
        Dim fechaini As String
        Dim fechafin As String
        fechaini = dtpFechaDesde.Text + " 00:00:00"
        fechafin = dtpFechaHasta.Text + " 23:59:59"

        Dim dt As DataTable
        Dim Ria_DataAccessLayer As New Ria_DataAccessLayer.exeDataTable

        Dim NroPeriodo As Integer = cmbPeriodoFiscal.SelectedValue

        Dim Array As New ArrayList
        Array.Add(NroPeriodo)
        Array.Add(fechaini)
        Array.Add(fechafin)

        Dim connstring As String = My.Settings.GESTIONConnectionString2.ToString()

        dt = Ria_DataAccessLayer.loadDataTable("Exec BalanceGeneralImpositivo2 " & NroPeriodo & ",'" & fechaini & "','" & fechafin & "'", connstring)
        'Try
        '    Me.CalculoResultadoTableAdapter.Fill(Me.DsCalculoResultado.CalculoResultado, fechaini, fechafin, CInt(Me.cmbPeriodoFiscal.SelectedValue))
        'Catch
        'End Try
        'Me.BalanceGeneralTableAdapter.Fill(Me.DsInfContabilidad.BalanceGeneral, CInt(Me.cmbPeriodoFiscal.SelectedValue), fechaini, fechafin)

        rpt.SetDataSource([dt])
        'rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        'rpt.SetParameterValue("pmtRangoFecha", "De : " + dtpFechaDesde.Text.ToString + "  Hasta : " + dtpFechaHasta.Text.ToString)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub rptListadoPlan()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaListadoPlanCuentas
        Dim rptmat As New Reportes.ContaListadoPlanCuentasMATR

        Me.PlanCuentasRepTableAdapter.Fill(Me.DsInfContabilidad.PlanCuentasRep)

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsInfContabilidad])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsInfContabilidad])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub rptLibroVentaExcel()
        Dim odrEncabezado As SqlDataReader
        Dim oExcel As Object
        Dim oBook As Object = Nothing
        Dim oSheet As Object
        Dim doc, nom, ruc, grav10, grav5, iva10, iva5, exentas, total, retenc, ArchivoMes, Cadena, ArchivoAnho, ruta As String
        Dim dia As DateTime
        Dim FechaDia As String
        Dim FechaMes As String
        Dim FechaAño As String
        Dim hora As String

        dia = dtpFechaDesde.Value

        FechaMes = dia.ToString("MM")
        hora = Format(Now, "hh:mm:ss")

        If FechaMes = "01" Then
            FechaMes = "ENERO"
        ElseIf FechaMes = "02" Then
            FechaMes = "FEBRERO"
        ElseIf FechaMes = "02" Then
            FechaMes = "FEBRERO"
        ElseIf FechaMes = "03" Then
            FechaMes = "MARZO"
        ElseIf FechaMes = "04" Then
            FechaMes = "ABRIL"
        ElseIf FechaMes = "05" Then
            FechaMes = "MAYO"
        ElseIf FechaMes = "06" Then
            FechaMes = "JUNIO"
        ElseIf FechaMes = "07" Then
            FechaMes = "JULIO"
        ElseIf FechaMes = "08" Then
            FechaMes = "AGOSTO"
        ElseIf FechaMes = "09" Then
            FechaMes = "SEPTIEMBRE"
        ElseIf FechaMes = "10" Then
            FechaMes = "OCTUBRE"
        ElseIf FechaMes = "11" Then
            FechaMes = "NOVIEMBRE"
        ElseIf FechaMes = "12" Then
            FechaMes = "DICIEMBRE"
        End If

        FechaAño = dia.ToString("yyy")

        'Iniciar un nuevo libro en Excel
        oExcel = CreateObject("Excel.Application")
        ArchivoMes = Month(Now) : ArchivoAnho = Year(Now)
        ArchivoMes = CalcularMes(ArchivoMes)
        Cadena = "\" & ArchivoMes & ArchivoAnho & "LibroVenta.xls"
        ruta = tbxLocalizacion.Text & Cadena

        If File.Exists(ruta) = False Then
            oBook = oExcel.Workbooks.Add
            'Agregar datos a las celdas de la primera hoja en el libro nuevo
            oSheet = oBook.Worksheets(1)
            ' Agregamos Los datos que queremos agregar,estas filas son para identificar las columnas
            oSheet.Range("A2").Value = EmpNomFantasia
            oSheet.Range("E3").Value = "LIBRO DE VENTAS LEY 125/91"
            oSheet.Range("C6").Value = "CLIENTE"
            oSheet.Range("E6").Value = "VALORES DE VENTA"

            If cmbSucursal.Text = "%" Then
                cmbSucursal.Text = "Consolidada"
            End If

            oSheet.Range("A4").Value = "SUCURSAL:" & cmbSucursal.Text
            oSheet.Range("A5").Value = "CENTRO:"
            oSheet.Range("H5").Value = "MES DE:" & FechaMes
            oSheet.Range("J5").Value = "AÑO:" & FechaAño

            oSheet.Range("A7").Value = "DIA"
            oSheet.Range("B7").Value = "DOCUMEN.NUMERO"
            oSheet.Range("C7").Value = "R. SOCIAL/APELL./NOMB"
            oSheet.Range("D7").Value = "R.U.C"
            oSheet.Range("E7").Value = "GRAV. 10%"
            oSheet.Range("F7").Value = "GRAV.5%"
            oSheet.Range("G7").Value = "IVA 10%"
            oSheet.Range("H7").Value = "IVA 5%"
            oSheet.Range("I7").Value = "EXENTAS"
            oSheet.Range("J7").Value = "TOTAL"
            oSheet.Range("K7").Value = "RETENC."

            Dim sqlWhere As String = ""
            Dim Fecha1, Fecha2 As String
            Dim col As Integer = 8
            Dim TotalGrav10 As Decimal = 0
            Dim TotalGrav5 As Decimal = 0
            Dim Total10 As Decimal = 0
            Dim Total5 As Decimal = 0
            Dim TotalGeneral As Decimal = 0
            Dim Totalexentas As Decimal = 0
            Dim a As String
            Dim b As String
            Dim c As String
            Dim d As String
            Dim e As String
            Dim f As String
            Dim g As String
            Dim h As String
            Dim i As String
            Dim j As String
            Dim k As String
            Dim EstadoVenta As String

            Fecha1 = dtpFechaDesde.Value + " 00:00:00"
            Fecha2 = dtpFechaHasta.Value + " 23:59:59"

            'PARA LOS CLIENTES SIN NOMBRE SE HACE EL CONSOLIDADO
            objCommand.CommandText = "SELECT MAX(dbo.VENTAS.CODVENTA) AS CODVENTA, MAX(dbo.VENTAS.FECHAVENTA) AS FECHAVENTA, dbo.CLIENTES.RUC, 'IMPORTES CONSOLIDADOS' AS Expr1, dbo.CLIENTES.TIMBRADOFACTURA, " & _
                                     "dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, (CASE SUM(dbo.VENTAS.TOTALGRAVADO5) - SUM(dbo.VENTAS.TOTAL5) WHEN 0 THEN 0 ELSE SUM(dbo.VENTAS.TOTALGRAVADO5) - SUM(dbo.VENTAS.TOTAL5)  " & _
                                     "END) AS TOTALGRAVADO5, (CASE SUM(dbo.VENTAS.TOTALGRAVADO10) - SUM(dbo.VENTAS.TOTAL10) WHEN 0 THEN 0 ELSE SUM(dbo.VENTAS.TOTALGRAVADO10) - SUM(dbo.VENTAS.TOTAL10) END)  " & _
                                     "AS TOTALGRAVADO10, SUM(dbo.VENTAS.TOTAL10) AS TOTAL10, SUM(dbo.VENTAS.TOTAL5) AS TOTAL5, SUM(dbo.VENTAS.TOTALVENTA) AS TOTALVENTA, SUM(dbo.VENTAS.TOTALEXENTA) AS TOTALEXENTA,  " & _
                                     "dbo.VENTAS.ESTADO, dbo.VENTAS.COTIZACION1, MAX(dbo.VENTAS.NUMVENTA) AS NUMVENTA " & _
                                     "FROM dbo.VENTAS INNER JOIN dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE INNER JOIN " & _
                                     "dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                     " WHERE (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & Fecha1 & "', 103)) AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME, '" & Fecha2 & "',103)) " & _
                                     " GROUP BY dbo.CLIENTES.RUC, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.TIMBRADOFACTURA, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, dbo.VENTAS.ESTADO, dbo.VENTAS.COTIZACION1 " & _
                                     " HAVING (dbo.CLIENTES.RUC = '44444401-7') AND (dbo.VENTAS.ESTADO <> 0) "

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            odrEncabezado = objCommand.ExecuteReader()

            If odrEncabezado.HasRows Then
                Do While odrEncabezado.Read()
                    dia = odrEncabezado("FECHAVENTA")
                    FechaDia = dia.ToString("dd")
                    FechaMes = dia.ToString("MM")
                    FechaAño = dia.ToString("yyy")

                    EstadoVenta = odrEncabezado("ESTADO")
                    doc = odrEncabezado("NUMVENTA")

                    If EstadoVenta = 2 Then
                        nom = "FACTURA ANULADA"
                        ruc = 0 : grav10 = 0 : grav5 = 0 : iva10 = 0 : iva5 = 0 : exentas = 0 : total = 0
                    Else
                        ruc = odrEncabezado("RUC")
                        grav10 = odrEncabezado("TOTALGRAVADO10")
                        grav5 = odrEncabezado("TOTALGRAVADO5")
                        iva10 = odrEncabezado("TOTAL10")
                        iva5 = odrEncabezado("TOTAL5")
                        exentas = odrEncabezado("TOTALEXENTA")
                        total = odrEncabezado("TOTALVENTA")
                    End If

                    retenc = "0"
                    a = "A" + col.ToString + ""
                    b = "B" + col.ToString + ""
                    c = "C" + col.ToString + ""
                    d = "D" + col.ToString + ""
                    e = "E" + col.ToString + ""
                    f = "F" + col.ToString + ""
                    g = "G" + col.ToString + ""
                    h = "H" + col.ToString + ""
                    i = "I" + col.ToString + ""
                    j = "J" + col.ToString + ""
                    k = "K" + col.ToString + ""

                    oSheet.Range(a).Value = FechaDia
                    oSheet.Range(b).Value = doc
                    oSheet.Range(c).Value = "IMPORTES CONSOLIDADOS"
                    oSheet.Range(d).Value = ruc
                    oSheet.Range(e).Value = FormatNumber(grav10, 2)
                    oSheet.Range(f).Value = FormatNumber(grav5, 2)
                    oSheet.Range(g).Value = FormatNumber(iva10, 2)
                    oSheet.Range(h).Value = FormatNumber(iva5, 2)
                    oSheet.Range(i).Value = FormatNumber(exentas, 2)
                    oSheet.Range(j).Value = FormatNumber(total, 2)
                    oSheet.Range(k).Value = retenc

                    col = col + 1
                    TotalGrav10 = TotalGrav10 + grav10
                    TotalGrav5 = TotalGrav5 + grav5
                    Total10 = Total10 + iva10
                    Total5 = Total5 + iva5
                    Totalexentas = Totalexentas + exentas
                    TotalGeneral = TotalGeneral + total
                Loop
            End If
            odrEncabezado.Close()


            If rbtAsentadosSI.Checked = True Then
                sqlWhere = "AND (dbo.VENTAS.ASENTADO = 2) ORDER BY dbo.VENTAS.FECHAVENTA "
            Else
                sqlWhere = "ORDER BY dbo.VENTAS.FECHAVENTA "
            End If

            'Desde aqui empezaremos a exportar la lista
            objCommand.CommandText = " SELECT dbo.VENTAS.NUMVENTA,dbo.CLIENTES.RUC, dbo.CLIENTES.NOMBRE, round((dbo.VENTAS.TOTALGRAVADO10 - dbo.VENTAS.TOTAL10),0) AS TOTALGRAVADO10, " & _
                                    "round((dbo.VENTAS.TOTALGRAVADO5 - dbo.VENTAS.TOTAL5),0)  AS TOTALGRAVADO5, round(dbo.VENTAS.TOTAL10,0) AS TOTAL10 , round(dbo.VENTAS.TOTAL5,0) AS TOTAL5, round(dbo.VENTAS.TOTALEXENTA,0) AS TOTALEXENTA, " & _
                                    " round(dbo.VENTAS.TOTALVENTA,0) AS TOTALVENTA, dbo.VENTAS.FECHAVENTA, dbo.SUCURSAL.DESSUCURSAL, " & _
                                    " dbo.EMPRESA.NOMFANTASIA,dbo.VENTAS.ASENTADO,dbo.VENTAS.ESTADO  FROM dbo.VENTAS INNER JOIN " & _
                                    " dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE INNER JOIN  dbo.SUCURSAL ON dbo.VENTAS.CODDEPOSITO = dbo.SUCURSAL.CODSUCURSAL LEFT OUTER JOIN" & _
                                    " dbo.EMPRESA ON dbo.SUCURSAL.CODEMPRESA = dbo.EMPRESA.CODEMPRESA" & _
                                    " WHERE (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & Fecha1 & "',103)) AND (dbo.VENTAS.FECHAVENTA <=CONVERT(DATETIME,'" & Fecha2 & "',103))" & _
                                    "AND (dbo.VENTAS.ESTADO <> 0) AND (dbo.CLIENTES.RUC <> '44444401-7')  " & sqlWhere

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            odrEncabezado = objCommand.ExecuteReader()

            If odrEncabezado.HasRows Then
                Try
                    Do While odrEncabezado.Read()
                        dia = odrEncabezado("FECHAVENTA")
                        FechaDia = dia.ToString("dd")
                        FechaMes = dia.ToString("MM")
                        FechaAño = dia.ToString("yyy")

                        'Dim i As Integer ' for para empezar a recorrer la lista
                        'empezaremos en el libro de excel a partir de la celda 11
                        EstadoVenta = odrEncabezado("ESTADO")
                        doc = odrEncabezado("NUMVENTA")

                        If EstadoVenta = 2 Then
                            nom = "FACTURA ANULADA"
                            ruc = 0 : grav10 = 0 : grav5 = 0 : iva10 = 0 : iva5 = 0 : exentas = 0 : total = 0
                        Else
                            nom = odrEncabezado("NOMBRE")
                            ruc = odrEncabezado("RUC")
                            grav10 = odrEncabezado("TOTALGRAVADO10")
                            grav5 = odrEncabezado("TOTALGRAVADO5")
                            iva10 = odrEncabezado("TOTAL10")
                            iva5 = odrEncabezado("TOTAL5")
                            exentas = odrEncabezado("TOTALEXENTA")
                            total = odrEncabezado("TOTALVENTA")
                        End If

                        retenc = "0"
                        a = "A" + col.ToString + ""
                        b = "B" + col.ToString + ""
                        c = "C" + col.ToString + ""
                        d = "D" + col.ToString + ""
                        e = "E" + col.ToString + ""
                        f = "F" + col.ToString + ""
                        g = "G" + col.ToString + ""
                        h = "H" + col.ToString + ""
                        i = "I" + col.ToString + ""
                        j = "J" + col.ToString + ""
                        k = "K" + col.ToString + ""

                        oSheet.Range(a).Value = FechaDia
                        oSheet.Range(b).Value = doc
                        oSheet.Range(c).Value = nom
                        oSheet.Range(d).Value = ruc
                        oSheet.Range(e).Value = FormatNumber(grav10, 2)
                        oSheet.Range(f).Value = FormatNumber(grav5, 2)
                        oSheet.Range(g).Value = FormatNumber(iva10, 2)
                        oSheet.Range(h).Value = FormatNumber(iva5, 2)
                        oSheet.Range(i).Value = FormatNumber(exentas, 2)
                        oSheet.Range(j).Value = FormatNumber(total, 2)
                        oSheet.Range(k).Value = retenc

                        col = col + 1
                        TotalGrav10 = TotalGrav10 + grav10
                        TotalGrav5 = TotalGrav5 + grav5
                        Total10 = Total10 + iva10
                        Total5 = Total5 + iva5
                        Totalexentas = Totalexentas + exentas
                        TotalGeneral = TotalGeneral + total
                    Loop

                    a = "A" + col.ToString + ""
                    e = "E" + col.ToString + ""
                    f = "F" + col.ToString + ""
                    g = "G" + col.ToString + ""
                    h = "H" + col.ToString + ""
                    i = "I" + col.ToString + ""
                    j = "J" + col.ToString + ""
                    k = "K" + col.ToString + ""
                    oSheet.Range(a).Value = "TOTAL..."
                    oSheet.Range(e).Value = FormatNumber(TotalGrav10, 2)
                    oSheet.Range(f).Value = FormatNumber(TotalGrav5, 2)
                    oSheet.Range(g).Value = FormatNumber(Total10, 2)
                    oSheet.Range(h).Value = FormatNumber(Total5, 2)
                    oSheet.Range(i).Value = FormatNumber(Totalexentas, 2)
                    oSheet.Range(j).Value = FormatNumber(TotalGeneral, 2)
                    oSheet.Range(k).Value = "0"

                Catch ex As Exception
                    MessageBox.Show("Errorr:" + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            ' hacemos visible el documento
            oExcel.Visible = True
            oExcel.UserControl = True
            odrEncabezado.Close()

        Else
            MessageBox.Show("El Archivo ya existe", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Try
            ArchivoMes = Month(Now) : ArchivoAnho = Year(Now)
            ArchivoMes = CalcularMes(ArchivoMes)
            Cadena = "\" & ArchivoMes & ArchivoAnho & "LibroVenta.xls"

            oBook.SaveAs(tbxLocalizacion.Text & Cadena)
        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try
    End Sub

    Private Sub rptLibroCompraExcel()
        Dim oExcel As Object
        Dim oBook As Object = Nothing
        Dim oSheet As Object
        Dim doc, nom, ruc, grav10, grav5, iva10, iva5, exentas, total, Import, tipoco, Cadena, ruta As String
        Dim dia As DateTime
        Dim FechaDia As String
        Dim FechaMes As String
        Dim FechaAño As String
        Dim fechadesde, fechahasta As String
        Dim hora As String

        Import = "" : tipoco = ""

        dia = dtpFechaDesde.Value & " 23:59:59"
        fechadesde = dtpFechaDesde.Value & " 00:00:00"
        fechahasta = dtpFechaHasta.Value & " 23:59:59"

        FechaMes = dia.ToString("MM")
        hora = Format(Now, "hh:mm:ss")

        If FechaMes = "01" Then
            FechaMes = "ENERO"
        ElseIf FechaMes = "02" Then
            FechaMes = "FEBRERO"
        ElseIf FechaMes = "02" Then
            FechaMes = "FEBRERO"
        ElseIf FechaMes = "03" Then
            FechaMes = "MARZO"
        ElseIf FechaMes = "04" Then
            FechaMes = "ABRIL"
        ElseIf FechaMes = "05" Then
            FechaMes = "MAYO"
        ElseIf FechaMes = "06" Then
            FechaMes = "JUNIO"
        ElseIf FechaMes = "07" Then
            FechaMes = "JULIO"
        ElseIf FechaMes = "08" Then
            FechaMes = "AGOSTO"
        ElseIf FechaMes = "09" Then
            FechaMes = "SEPTIEMBRE"
        ElseIf FechaMes = "10" Then
            FechaMes = "OCTUBRE"
        ElseIf FechaMes = "11" Then
            FechaMes = "NOVIEMBRE"
        ElseIf FechaMes = "12" Then
            FechaMes = "DICIEMBRE"
        End If

        FechaAño = dia.ToString("yyy")

        'Iniciar un nuevo libro en Excel
        oExcel = CreateObject("Excel.Application")
        Cadena = "\" & FechaMes & FechaAño & "LibroCompra.xls"
        ruta = tbxLocalizacion.Text & Cadena

        If File.Exists(ruta) = False Then
            oBook = oExcel.Workbooks.Add
            'Agregar datos a las celdas de la primera hoja en el libro nuevo
            oSheet = oBook.Worksheets(1)
            ' Agregamos Los datos que queremos agregar,estas filas son para identificar las columnas
            oSheet.Range("A2").Value = EmpNomFantasia
            oSheet.Range("E3").Value = "LIBRO DE COMPRAS LEY 125/91"
            oSheet.Range("C6").Value = "PROVEEDOR DE BIENES Y SERVIC."
            oSheet.Range("E6").Value = "VALORES DE COMPRAS/SERVICIOS"

            If cmbSucursal.Text = "%" Then
                cmbSucursal.Text = "Consolidada"
            End If

            oSheet.Range("A4").Value = "SUCURSAL:" & cmbSucursal.Text
            oSheet.Range("A5").Value = "CENTRO:"
            oSheet.Range("H5").Value = "MES DE:" & FechaMes
            oSheet.Range("J5").Value = "AÑO:" & FechaAño
            oSheet.Range("L5").Value = "HORA:" & hora
            oSheet.Range("A7").Value = "DIA"
            oSheet.Range("B7").Value = "DOCUMEN.NUMERO"
            oSheet.Range("C7").Value = "R. SOCIAL/APELL./NOMB"
            oSheet.Range("D7").Value = "R.U.C"
            oSheet.Range("E7").Value = "GRAV. 10%"
            oSheet.Range("F7").Value = "GRAV.5%"
            oSheet.Range("G7").Value = "IVA 10%"
            oSheet.Range("H7").Value = "IVA 5%"
            oSheet.Range("I7").Value = "EXENTAS"
            oSheet.Range("J7").Value = "TOTAL"
            oSheet.Range("K7").Value = "IMPORT.BASE IMPONIBLE."
            oSheet.Range("L7").Value = "TI CO"

            Dim sqlWhere As String = ""
            If rbtAsentadosSI.Checked = True Then
                sqlWhere = "AND (dbo.COMPRAS.ASENTADO = 2) ORDER BY dbo.COMPRAS.FECHACOMPRA "
            Else
                sqlWhere = "ORDER BY dbo.COMPRAS.FECHACOMPRA "
            End If

            'Desde aqui empezaremos a exportar la lista
            objCommand.CommandText = "SELECT dbo.COMPRAS.FECHACOMPRA, dbo.COMPRAS.NUMCOMPRA, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.RUC_CIN, " & _
                                     "round(dbo.COMPRAS.TOTALIVA10 * 11 - dbo.COMPRAS.TOTALIVA10,0) AS IMPORTEGRAVADO10, " & _
                                     "round(dbo.COMPRAS.TOTALIVA10,0) AS TOTALIVA10, round(dbo.COMPRAS.TOTALIVA5 * 21 - dbo.COMPRAS.TOTALIVA5,0) AS IMPORTEGRAVADO5, round(dbo.COMPRAS.TOTALIVA5,0) AS TOTALIVA5, round(dbo.COMPRAS.TOTALEXENTA,0) AS TOTALEXENTA, " & _
                                     "round(dbo.COMPRAS.TOTALCOMPRA,0) AS TOTALCOMPRA, isnull(dbo.COMPRAS.BASEIMPONIBLE,0) AS BASEIMPONIBLE, dbo.SUCURSAL.DESSUCURSAL, dbo.EMPRESA.NOMFANTASIA,  " & _
                                     "dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, dbo.COMPRAS.ESTADO " & _
                                     "FROM dbo.EMPRESA INNER JOIN dbo.SUCURSAL ON dbo.EMPRESA.CODEMPRESA = dbo.SUCURSAL.EMPRESACODEMPRESA RIGHT OUTER JOIN " & _
                                     "dbo.COMPRAS ON dbo.SUCURSAL.CODSUCURSAL = dbo.COMPRAS.CODSUCURSAL LEFT OUTER JOIN " & _
                                     "dbo.TIPOCOMPROBANTE ON dbo.COMPRAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE LEFT OUTER JOIN " & _
                                     "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR " & _
                                     "WHERE (dbo.COMPRAS.FECHACOMPRA >= CONVERT(DATETIME, '" & fechadesde & "', 103)) AND (dbo.COMPRAS.FECHACOMPRA <= CONVERT(DATETIME, '" & fechahasta & "', 103)) " & _
                                     "AND (dbo.COMPRAS.ESTADO <> 0)  AND (dbo.COMPRAS.CODCOMPROBANTE <> 2) " & sqlWhere

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrEncabezado As SqlDataReader = objCommand.ExecuteReader()

            If odrEncabezado.HasRows Then
                Try
                    Dim col As Integer = 8
                    Dim TotalGrav10 As Decimal = 0
                    Dim TotalGrav5 As Decimal = 0
                    Dim Total10 As Decimal = 0
                    Dim Total5 As Decimal = 0
                    Dim TotalGeneral As Decimal = 0
                    Dim Totalexentas As Decimal = 0
                    Dim a As String
                    Dim b As String
                    Dim c As String
                    Dim d As String
                    Dim e As String
                    Dim f As String
                    Dim g As String
                    Dim h As String
                    Dim i As String
                    Dim j As String
                    Dim k As String
                    Dim l As String
                    Dim EstadoCompra As String

                    Do While odrEncabezado.Read()
                        dia = odrEncabezado("FECHACOMPRA")
                        FechaDia = dia.ToString("dd")

                        'empezaremos en el libro de excel a partir de la celda 11
                        EstadoCompra = odrEncabezado("ESTADO")
                        doc = odrEncabezado("NUMCOMPRA")

                        If EstadoCompra = 2 Then
                            nom = "FACTURA ANULADA"
                            ruc = 0 : grav10 = 0 : grav5 = 0 : iva10 = 0 : iva5 = 0 : exentas = 0 : total = 0
                        Else
                            nom = odrEncabezado("NOMBRE")
                            ruc = odrEncabezado("RUC_CIN")
                            grav10 = odrEncabezado("IMPORTEGRAVADO10")
                            grav5 = odrEncabezado("IMPORTEGRAVADO5")
                            iva10 = odrEncabezado("TOTALIVA10")
                            iva5 = odrEncabezado("TOTALIVA5")
                            exentas = odrEncabezado("TOTALEXENTA")
                            total = odrEncabezado("TOTALCOMPRA")
                            Try
                                Import = odrEncabezado("BASEIMPONIBLE")
                            Catch ex As Exception
                            End Try

                            tipoco = odrEncabezado("DESCOMPROBANTE")
                        End If

                        a = "A" + col.ToString + ""
                        b = "B" + col.ToString + ""
                        c = "C" + col.ToString + ""
                        d = "D" + col.ToString + ""
                        e = "E" + col.ToString + ""
                        f = "F" + col.ToString + ""
                        g = "G" + col.ToString + ""
                        h = "H" + col.ToString + ""
                        i = "I" + col.ToString + ""
                        j = "J" + col.ToString + ""
                        k = "K" + col.ToString + ""
                        l = "L" + col.ToString + ""

                        oSheet.Range(a).Value = FechaDia
                        oSheet.Range(b).Value = doc
                        oSheet.Range(c).Value = nom
                        oSheet.Range(d).Value = ruc
                        oSheet.Range(e).Value = FormatNumber(grav10, 2)
                        oSheet.Range(f).Value = FormatNumber(grav5, 2)
                        oSheet.Range(g).Value = FormatNumber(iva10, 2)
                        oSheet.Range(h).Value = FormatNumber(iva5, 2)
                        oSheet.Range(i).Value = FormatNumber(exentas, 2)
                        oSheet.Range(j).Value = FormatNumber(total, 2)
                        oSheet.Range(k).Value = FormatNumber(Import, 2)
                        oSheet.Range(l).Value = tipoco

                        col = col + 1
                        TotalGrav10 = TotalGrav10 + grav10
                        TotalGrav5 = TotalGrav5 + grav5
                        Total10 = Total10 + iva10
                        Total5 = Total5 + iva5
                        Totalexentas = Totalexentas + exentas
                        TotalGeneral = TotalGeneral + total
                    Loop

                    a = "A" + col.ToString + ""
                    e = "E" + col.ToString + ""
                    f = "F" + col.ToString + ""
                    g = "G" + col.ToString + ""
                    h = "H" + col.ToString + ""
                    i = "I" + col.ToString + ""
                    j = "J" + col.ToString + ""
                    k = "K" + col.ToString + ""

                    oSheet.Range(a).Value = "TOTAL..."
                    oSheet.Range(e).Value = FormatNumber(TotalGrav10, 2)
                    oSheet.Range(f).Value = FormatNumber(TotalGrav5, 2)
                    oSheet.Range(g).Value = FormatNumber(Total10, 2)
                    oSheet.Range(h).Value = FormatNumber(Total5, 2)
                    oSheet.Range(i).Value = FormatNumber(Totalexentas, 2)
                    oSheet.Range(j).Value = FormatNumber(TotalGeneral, 2)
                    oSheet.Range(k).Value = FormatNumber(Import, 2)

                Catch ex As Exception
                    MessageBox.Show("Error:" + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            ' hacemos visible el documento
            oExcel.Visible = True
            oExcel.UserControl = True
            odrEncabezado.Close()

        Else
            MessageBox.Show("El Archivo ya existe", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Guardaremos el documento 
        Try
            Cadena = "\" & FechaMes & FechaAño & "LibroCompra.xls"
            oBook.SaveAs(tbxLocalizacion.Text & Cadena)
        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try
    End Sub

    Private Sub rptHechaukaVenta()
        Dim ruta, ArchivoMes As String
        Dim Periodo, anho, mes, Cadena As String
        Dim TipoFactura, TipoReporte As String

        Periodo = "" : anho = "" : mes = "" : Cadena = "" : TipoFactura = ""

        'Verificamos que tengo una ruta para guardar el archivo
        If tbxLocalizacion.Text = "" Then
            MessageBox.Show("Ingrese la Dirección donde se Guardará el Archivo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxLocalizacion.Focus()
            Exit Sub
        End If

        Try
            Select Case cmbMes.Text
                Case "Enero" : mes = "01"
                Case "Febrero" : mes = "02"
                Case "Marzo" : mes = "03"
                Case "Abril" : mes = "04"
                Case "Mayo" : mes = "05"
                Case "Junio" : mes = "06"
                Case "Julio" : mes = "07"
                Case "Agosto" : mes = "08"
                Case "Septiembre" : mes = "09"
                Case "Octubre" : mes = "10"
                Case "Noviembre" : mes = "11"
                Case "Diciembre" : mes = "12"
            End Select

            anho = cmbAño.Text : Periodo = anho + mes
            ArchivoMes = CalcularMes(mes)
            Cadena = "\" & ArchivoMes & anho & "VentaHechauka.txt"

            If rbtnOriginal.Checked = True Then
                TipoReporte = 1
            ElseIf rbtnRectificativa.Checked = True Then
                TipoReporte = 2
            Else
                TipoReporte = 1
            End If

            ruta = tbxLocalizacion.Text & Cadena

            If File.Exists(ruta) = True Then
                If MessageBox.Show("Archivo '" & ArchivoMes & anho & " - VentaHechauka.txt' ya existe, desea sobreescribirlo?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    File.Delete(ruta)
                Else
                    'si usuario no quiere sobreescribir, no se hace nada...
                    Exit Sub
                End If
            End If

            Try
                Dim Hechauka As New Hechauka_Clase
                Hechauka.Hechauka_Ventas(rbnAnuladasSI.Checked, cmbComprobante.Text, mes, cmbDesde.Text, tbxLocalizacion.Text, cmbHasta.Text, cmbAño.Text, ruta, TipoReporte)
                Hechauka.Hechauka_notadecredito(rbnAnuladasSI.Checked, cmbComprobante.Text, mes, cmbDesde.Text, tbxLocalizacion.Text, cmbHasta.Text, cmbAño.Text, ruta, TipoReporte)

                'Hechauka.Hechauka_Ventas(rbtAsentadosSI.Checked, cmbComprobante.Text, mes, cmbDesde.Text, tbxLocalizacion.Text, cmbHasta.Text, cmbAño.Text, ruta, TipoReporte)
                'Hechauka.Hechauka_notadecredito(rbtAsentadosSI.Checked, cmbComprobante.Text, mes, cmbDesde.Text, tbxLocalizacion.Text, cmbHasta.Text, cmbAño.Text, ruta, TipoReporte)

                MessageBox.Show("Archivo Generado con Exito", "R.I.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MessageBox.Show("Error al Tratar de Escribir en el Archivo " & ex.Message, "R.I.A.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)

            MessageBox.Show("Error al Tratar de Escribir en el Archivo" & ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub rptHechaukaRetenciones()
        Dim ruta, ArchivoMes As String
        Dim sw As StreamWriter
        'Variables a utilizar en el encabezado del archivo
        Dim Periodo, RucContribuyente, RucRepresentante, DVContribuyente, DVRepresentante, Contribuyente, Representante, anho, mes, Cadena, fecha3 As String
        Dim RucCliente, DVCliente, TipoFactura, TipoReporte, NroDocumento, ProveedorNombre, Tipo, ImporteRenta As String
        Dim PosGuion As Integer

        Periodo = "" : RucContribuyente = "" : RucRepresentante = "" : DVContribuyente = "" : DVRepresentante = "" : Contribuyente = "" : Representante = ""
        anho = "" : mes = "" : Cadena = "" : RucCliente = "" : DVCliente = "" : TipoFactura = "" : NroDocumento = "" : ImporteRenta = ""

        'Verificamos que tengo una ruta para guardar el archivo
        If tbxLocalizacion.Text = "" Then
            MessageBox.Show("Ingrese la Dirección donde se Guardará el Archivo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxLocalizacion.Focus()
            Exit Sub
        End If

        Try
            Select Case cmbMes.Text
                Case "Enero" : mes = "01"
                Case "Febrero" : mes = "02"
                Case "Marzo" : mes = "03"
                Case "Abril" : mes = "04"
                Case "Mayo" : mes = "05"
                Case "Junio" : mes = "06"
                Case "Julio" : mes = "07"
                Case "Agosto" : mes = "08"
                Case "Septiembre" : mes = "09"
                Case "Octubre" : mes = "10"
                Case "Noviembre" : mes = "11"
                Case "Diciembre" : mes = "12"
            End Select

            anho = cmbAño.Text : Periodo = anho + mes
            anho = cmbAño.Text : Periodo = anho + mes
            ArchivoMes = CalcularMes(mes)
            Cadena = "\" & ArchivoMes & anho & "RetencionHechauka.txt"

            If rbtnOriginal.Checked = True Then
                TipoReporte = 1
            ElseIf rbtnRectificativa.Checked = True Then
                TipoReporte = 2
            Else
                TipoReporte = 1
            End If

            ruta = tbxLocalizacion.Text & Cadena
            If File.Exists(ruta) = False Then
                'Creamos la consulta SQL para luego empezar a escribir en el archivo
                '***** PARA EL ENCABEZADO *****
                objCommand.CommandText = "SELECT DATEPART(yyyy, dbo.periodofiscal.FECHAINICIO) AS Anho, DATEPART(month, GETDATE()) AS Mes, dbo.EMPRESA.RUCCONTRIBUYENTE, " & _
                                        "dbo.EMPRESA.NOMCONTRIBUYENTE, dbo.EMPRESA.NOMREPRESENTANTE, dbo.EMPRESA.RUCREPRESENTANTE " & _
                                        "FROM dbo.periodofiscal CROSS JOIN dbo.EMPRESA " & _
                                        "WHERE (dbo.periodofiscal.ESTADO = 1)"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrEncabezado As SqlDataReader = objCommand.ExecuteReader()

                If odrEncabezado.HasRows Then
                    Do While odrEncabezado.Read()
                        Contribuyente = odrEncabezado("NOMCONTRIBUYENTE")
                        Representante = odrEncabezado("NOMREPRESENTANTE")

                        If odrEncabezado("RUCCONTRIBUYENTE") <> "" Then
                            PosGuion = InStr(odrEncabezado("RUCCONTRIBUYENTE"), "-")
                            RucContribuyente = odrEncabezado("RUCCONTRIBUYENTE")
                            If PosGuion <> 0 Then
                                RucContribuyente = Trim(RucContribuyente.Substring(0, PosGuion - 1))
                            End If
                            DVContribuyente = calcular(RucContribuyente, 11)
                        Else
                            RucContribuyente = ""
                            DVContribuyente = ""
                        End If

                        If odrEncabezado("RUCREPRESENTANTE") <> "" Then
                            PosGuion = InStr(odrEncabezado("RUCREPRESENTANTE"), "-")
                            RucRepresentante = odrEncabezado("RUCREPRESENTANTE")
                            If PosGuion <> 0 Then
                                RucRepresentante = RucRepresentante.Substring(0, PosGuion - 1)
                            End If
                            DVRepresentante = calcular(RucRepresentante, 11)
                        Else
                            RucRepresentante = ""
                            DVRepresentante = ""
                        End If
                    Loop
                End If

                odrEncabezado.Close()
                objCommand.Dispose()

                '***** PARA EL DETALLE *****
                Dim odrDetalle As SqlDataReader
                Dim TotalRetencionIVA, TotalRetencionRenta, CantReg, MontoImponibleIVA, fecha, fechaCompra, NumComprobCompra, MontoImponibleRenta As String
                TotalRetencionIVA = "" : TotalRetencionRenta = "" : CantReg = "" : MontoImponibleIVA = "" : MontoImponibleRenta = ""
                Dim SqlWhere As String = ""
                'Si solo quiere los registros acentados o todos
                If rbtAsentadosSI.Checked = True Then
                    SqlWhere = "AND  (dbo.VENTAS.ASENTADO = 2)" ' AQUI VER DE QUE CAMPO LEER
                End If

                If cmbComprobante.Text <> "%" Then
                    'FormatF1 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "IDCOMPROBANTE", "NO")
                    SqlWhere = SqlWhere + " AND dbo.TIPOCOMPROBANTE.IDCOMPROBANTE IN (" & cmbComprobante.Text & ")"
                End If

                fecha = cmbDesde.Text + "/" + mes + "/" + cmbAño.Text + " 00:00:00"
                fecha3 = cmbHasta.Text + "/" + mes + "/" + cmbAño.Text + " 23:59:59"

                objCommand.CommandText = " SELECT COUNT(NUMRETENCION) AS CantReg, SUM(IMPORTERET) AS TOTALRET FROM (SELECT MAX(dbo.COMPRAS.FECHACOMPRA) AS FECHACOMPRA, dbo.COMPRAS.NUMCOMPRA, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.RUC_CIN, " & _
                                         "dbo.COMPRAS.TOTALIVA5, dbo.COMPRAS.TOTALIVA10, dbo.COMPRAS.TOTALCOMPRA, dbo.SUCURSAL.DESSUCURSAL, " & _
                                         "dbo.EMPRESA.NOMFANTASIA, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, dbo.COMPRAS.ESTADO, dbo.COMPRASFORMAPAGO.CODTIPOPAGO, dbo.COMPRASFORMAPAGO.NUMRETENCION, " & _
                                         " dbo.COMPRASFORMAPAGO.IMPORTE AS IMPORTERET, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG AS FECHARET " & _
                                         "FROM dbo.COMPRAS INNER JOIN " & _
                                         "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR INNER JOIN " & _
                                         "dbo.SUCURSAL ON dbo.COMPRAS.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN " & _
                                         "dbo.EMPRESA ON dbo.SUCURSAL.EMPRESACODEMPRESA = dbo.EMPRESA.CODEMPRESA INNER JOIN " & _
                                         "dbo.TIPOCOMPROBANTE ON dbo.COMPRAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN " & _
                                         "dbo.COMPRASDETALLE ON dbo.COMPRASDETALLE.CODCOMPRA = dbo.COMPRAS.CODCOMPRA INNER JOIN " & _
                                         "dbo.COMPRASFORMAPAGO ON dbo.COMPRAS.CODCOMPRA = dbo.COMPRASFORMAPAGO.CODCOMPRA " & _
                                         "GROUP BY dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.RUC_CIN, dbo.COMPRAS.BASEIMPONIBLE, dbo.SUCURSAL.DESSUCURSAL, dbo.EMPRESA.NOMFANTASIA, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, " & _
                                         "dbo.COMPRAS.ESTADO, dbo.COMPRAS.ASENTADO, dbo.COMPRASFORMAPAGO.CODTIPOPAGO, dbo.COMPRASFORMAPAGO.NUMRETENCION, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, dbo.COMPRAS.NUMCOMPRA, " & _
                                         "dbo.COMPRAS.TOTALIVA10, dbo.COMPRAS.TOTALIVA5, dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRASFORMAPAGO.IMPORTE " & _
                                         "HAVING ((dbo.COMPRASFORMAPAGO.CODTIPOPAGO = 6) OR (dbo.COMPRASFORMAPAGO.CODTIPOPAGO = 10)) AND " & _
                                         "(dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG >= CONVERT(DATETIME, '" & fecha & "', 103)) AND (dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG <= CONVERT(DATETIME, '" & fecha3 & "', 103)) " & _
                                         "AND (dbo.COMPRAS.ESTADO = 1)" & SqlWhere & ") AS SUBCONSULTA"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                odrDetalle = objCommand.ExecuteReader()

                If odrDetalle.HasRows Then
                    Do While odrDetalle.Read()
                        TotalRetencionIVA = FormatNumber(odrDetalle("TOTALRET"), 0)
                        TotalRetencionIVA = Funciones.Cadenas.QuitarCad(TotalRetencionIVA, ".")
                        CantReg = odrDetalle("CantReg")
                    Loop
                End If

                odrDetalle.Close()
                objCommand.Dispose()

                If CInt(CantReg) < 15000 Then
                    sw = File.CreateText(ruta)

                    Cadena = "1" & vbTab & Periodo & vbTab & TipoReporte & vbTab & "931" & vbTab & "231" & vbTab & RucContribuyente & vbTab & DVContribuyente & vbTab & _
                             Contribuyente & vbTab & RucRepresentante & vbTab & DVRepresentante & vbTab & Representante & vbTab & CantReg & vbTab & TotalRetencionIVA & vbTab
                    sw.WriteLine(Cadena)

                    objCommand.CommandText = "SELECT MAX(dbo.COMPRAS.FECHACOMPRA) AS FECHACOMPRA, dbo.COMPRAS.NUMCOMPRA, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.RUC_CIN, dbo.COMPRAS.TOTALIVA AS TOTALIVA, " & _
                                             "dbo.COMPRAS.TOTALCOMPRA AS TOTALCOMPRAS, dbo.COMPRAS.BASEIMPONIBLE, dbo.SUCURSAL.DESSUCURSAL, dbo.EMPRESA.NOMFANTASIA, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, " & _
                                             "dbo.COMPRAS.ESTADO, dbo.COMPRASFORMAPAGO.CODTIPOPAGO, dbo.COMPRASFORMAPAGO.NUMRETENCION, dbo.COMPRASFORMAPAGO.IMPORTE AS IMPORTERET, " & _
                                             "dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG AS FECHARET " & _
                                             "FROM dbo.COMPRAS INNER JOIN " & _
                                             "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR INNER JOIN " & _
                                             "dbo.SUCURSAL ON dbo.COMPRAS.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN " & _
                                             "dbo.EMPRESA ON dbo.SUCURSAL.EMPRESACODEMPRESA = dbo.EMPRESA.CODEMPRESA INNER JOIN " & _
                                             "dbo.TIPOCOMPROBANTE ON dbo.COMPRAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN " & _
                                             "dbo.COMPRASDETALLE ON dbo.COMPRASDETALLE.CODCOMPRA = dbo.COMPRAS.CODCOMPRA INNER JOIN " & _
                                             "dbo.COMPRASFORMAPAGO ON dbo.COMPRAS.CODCOMPRA = dbo.COMPRASFORMAPAGO.CODCOMPRA " & _
                                             "GROUP BY dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.RUC_CIN, dbo.COMPRAS.BASEIMPONIBLE, dbo.SUCURSAL.DESSUCURSAL, dbo.EMPRESA.NOMFANTASIA, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, " & _
                                             "dbo.COMPRAS.ESTADO, dbo.COMPRAS.ASENTADO, dbo.COMPRASFORMAPAGO.CODTIPOPAGO, dbo.COMPRASFORMAPAGO.NUMRETENCION, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, " & _
                                             "dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.TOTALIVA, dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRASFORMAPAGO.IMPORTE " & _
                                             "HAVING (dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG >= CONVERT(DATETIME, '" & fecha & "', 103)) AND (dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG <= CONVERT(DATETIME, '" & fecha3 & "', 103)) " & _
                                             "AND (dbo.COMPRAS.ESTADO = 1) AND ((dbo.COMPRASFORMAPAGO.CODTIPOPAGO = 6) OR (dbo.COMPRASFORMAPAGO.CODTIPOPAGO = 10)) " & SqlWhere

                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    odrDetalle = objCommand.ExecuteReader()

                    If odrDetalle.HasRows Then
                        Do While odrDetalle.Read()
                            If odrDetalle("RUC_CIN") <> "" Then
                                PosGuion = InStr(odrDetalle("RUC_CIN"), "-")
                                RucCliente = odrDetalle("RUC_CIN")

                                If PosGuion <> 0 Then
                                    RucCliente = RucCliente.Substring(0, PosGuion - 1)
                                End If
                                DVCliente = calcular(RucCliente, 11)
                            Else
                                RucCliente = ""
                                DVCliente = ""
                            End If

                            TipoFactura = 1 'Valor por defecto para Retencion 

                            NroDocumento = odrDetalle("NUMRETENCION") : NroDocumento = NroDocumento.Replace(".", "-")
                            NumComprobCompra = odrDetalle("NUMCOMPRA") : NroDocumento = NroDocumento.Replace(".", "-")

                            Dim fecha2 As DateTime
                            fecha2 = odrDetalle("FECHARET")
                            fecha = fecha2.ToString("dd/MM/yyy")

                            Dim fecha4 As DateTime
                            fecha4 = odrDetalle("FECHACOMPRA")
                            fechaCompra = fecha4.ToString("dd/MM/yyy")

                            Tipo = odrDetalle("CODTIPOPAGO")
                            If Tipo = 6 Then 'RETENCIONIVA
                                MontoImponibleIVA = FormatNumber(odrDetalle("TOTALIVA"), 0) : MontoImponibleIVA = Funciones.Cadenas.QuitarCad(MontoImponibleIVA, ".")
                                TotalRetencionIVA = FormatNumber(odrDetalle("IMPORTERET"), 0) : TotalRetencionIVA = Funciones.Cadenas.QuitarCad(TotalRetencionIVA, ".")
                                MontoImponibleRenta = 0
                                TotalRetencionRenta = 0
                            Else
                                MontoImponibleIVA = 0
                                TotalRetencionIVA = 0
                                MontoImponibleRenta = FormatNumber(odrDetalle("TOTALCOMPRAS"), 0) : MontoImponibleRenta = Funciones.Cadenas.QuitarCad(MontoImponibleRenta, ".")
                                TotalRetencionRenta = FormatNumber(odrDetalle("IMPORTERET"), 0) : TotalRetencionRenta = Funciones.Cadenas.QuitarCad(TotalRetencionRenta, ".")
                            End If

                            ProveedorNombre = odrDetalle("NOMBRE")

                            Cadena = "2" & vbTab & RucCliente & vbTab & DVCliente & vbTab & ProveedorNombre & vbTab & TipoFactura & vbTab & fechaCompra & vbTab & _
                                NumComprobCompra & vbTab & NroDocumento & vbTab & fecha & vbTab & MontoImponibleRenta & vbTab & MontoImponibleIVA & vbTab & TotalRetencionIVA & vbTab & TotalRetencionRenta

                            sw.WriteLine(Cadena)
                        Loop
                    End If

                    sw.Flush()
                    sw.Close()

                    MessageBox.Show("Archivo Generado con Exito!!", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("La Cantidad de Registros supera los 15.000", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                MessageBox.Show("El Archivo ya existe", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("Error al Tratar de Escribir en el Archivo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Function calcular(ByVal numero As String, ByVal basemax As Integer) As String
        Dim codigo As Long
        Dim numero_al As String = ""

        Dim i
        For i = 1 To Len(numero)
            Dim c
            c = Mid$(numero, i, 1)
            codigo = Asc(UCase(c))
            If Not (codigo >= 48 And codigo <= 57) Then
                numero_al = numero_al & codigo
            Else
                numero_al = numero_al & c
            End If
        Next

        Dim k : Dim total
        k = 2
        total = 0

        For i = Len(numero_al) To 1 Step -1
            If (k > basemax) Then k = 2
            Dim numero_aux
            numero_aux = Val(Mid(numero_al, i, 1))
            total = total + (numero_aux * k)
            k = k + 1
        Next


        Dim resto : Dim digito
        resto = total Mod 11
        If (resto > 1) Then
            digito = 11 - resto
        Else
            digito = 0
        End If
        calcular = digito
    End Function

    Function CalcularMes(ByVal mes As String) As String
        Dim MesLetra As String
        MesLetra = ""
        Select Case mes
            Case "01" : MesLetra = "ENE"
            Case "02" : MesLetra = "FEB"
            Case "03" : MesLetra = "MAR"
            Case "04" : MesLetra = "ABR"
            Case "05" : MesLetra = "MAY"
            Case "06" : MesLetra = "JUN"
            Case "07" : MesLetra = "JUL"
            Case "08" : MesLetra = "AGO"
            Case "09" : MesLetra = "SEP"
            Case "10" : MesLetra = "OCT"
            Case "11" : MesLetra = "NOV"
            Case "12" : MesLetra = "DIC"
        End Select

        Return MesLetra
    End Function

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            ' Configuración del FolderBrowserDialog
            With (FolderBrowserDialog1)
                .RootFolder = Environment.SpecialFolder.DesktopDirectory
                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                tbxLocalizacion.Text = .SelectedPath

            End With
        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try
    End Sub

    Private Sub btnFiltros_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltros.Click
        If pnlFiltros.Visible = True Then
            pnlFiltros.Visible = False
        Else
            pnlFiltros.Visible = True
        End If
    End Sub

    Private Sub pbxCerrarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles pbxCerrarFiltros.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub cmbComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbComprobante.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbComprobante.Text = "%"
        End If
    End Sub

    Private Sub cmbCaja_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPeriodoFiscal.SelectedIndexChanged
        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptBalanceSumaySaldo" Then
            'Obtenemos la fecha de inicio del Periodo fiscal seleccionado
            Dim FechaPeriodo As String = f.FuncionConsultaString("FECHAINICIO", "periodofiscal", "CODPERIODOFISCAL", cmbPeriodoFiscal.SelectedValue)
            dtpFechaDesde.Text = FechaPeriodo
        End If
    End Sub

    Private Sub chbxTodos_Click(sender As Object, e As System.EventArgs) Handles chbxTodos.Click
        Dim c As Integer = dgvCuenta.RowCount
        If c = 0 Then
            Exit Sub
        Else
            For i = 0 To c - 1
                If chbxTodos.Checked = True Then
                    dgvCuenta.Rows(i).Cells("Ver").Value = 1
                ElseIf chbxTodos.Checked = False Then
                    dgvCuenta.Rows(i).Cells("Ver").Value = 0
                End If
            Next
        End If
    End Sub

    Private Sub tbxBuscarPermiso_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxBuscarPermiso.TextChanged
        If dgvCuenta.RowCount <> 0 Then
            PlancuentasBindingSource.Filter = "NUMPLANCUENTA LIKE '%" & tbxBuscarPermiso.Text & "%' OR DESPLANCUENTA LIKE '%" & tbxBuscarPermiso.Text & "%'"
        Else
            PlancuentasBindingSource.RemoveFilter()
        End If
    End Sub

    Private Sub FiltroReporteContabilidad_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim rpt As New Reportes.ReporteBlanco
        rpt.SetParameterValue("pmtReporteName", "Reportes de Contabilidad")
        CrystalReportViewer.ReportSource = rpt
    End Sub

    Private Sub cmbSucursal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbSucursal.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbSucursal.Text = "%"
        End If
    End Sub
    Public Sub DetalleRetenciones() 'Saul
        Try

            Dim frm = New VerInformes
            Dim rpt As New Reportes.ContRetencionesIVA
            Dim fechadesde2, fechahasta2 As String

            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            If cbxCaja.Text = "%" And cmbSucursal.Text = "%" Then ' todos
                Me.RetencionesIVATableAdapter.Fill(Me.DsInfContabilidad.RetencionesIVA, fechadesde2, fechahasta2)
            ElseIf cbxCaja.Text <> "%" And cmbSucursal.Text = "%" Then ' sucursal 
                Me.RetencionesIVATableAdapter.FillByCaja(Me.DsInfContabilidad.RetencionesIVA, fechadesde2, fechahasta2, cbxCaja.SelectedValue)
            ElseIf cbxCaja.Text = "%" And cmbSucursal.Text <> "%" Then ' caja
                Me.RetencionesIVATableAdapter.FillBySuc(Me.DsInfContabilidad.RetencionesIVA, fechadesde2, fechahasta2, cmbSucursal.SelectedValue)
            ElseIf cbxCaja.Text <> "%" And cmbSucursal.Text <> "%" Then ' caja - sucursal
                Me.RetencionesIVATableAdapter.FillBySucCaja(Me.DsInfContabilidad.RetencionesIVA, fechadesde2, fechahasta2, cbxCaja.SelectedValue, cmbSucursal.SelectedValue)
            End If

            rpt.SetDataSource([DsInfContabilidad]) : rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia) : rpt.SetParameterValue("fechadesde", fechadesde2) : rpt.SetParameterValue("fechahasta", fechahasta2)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt : frm.WindowState = FormWindowState.Maximized : frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt : CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try
    End Sub
    Public Sub RetencionesRenta() 'Saul
        Try

            Dim frm = New VerInformes
            Dim rpt As New Reportes.ContRetencionesRenta
            Dim fechadesde2, fechahasta2 As String

            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RetencionesRentaTableAdapter.Fill(Me.DsInfContabilidad.RetencionesRenta, fechadesde2, fechahasta2)

            rpt.SetDataSource([DsInfContabilidad]) : rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia) : rpt.SetParameterValue("fechadesde", fechadesde2) : rpt.SetParameterValue("fechahasta", fechahasta2)

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt : frm.WindowState = FormWindowState.Maximized : frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt : CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try
    End Sub

    Private Sub dgvListaReportes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListaReportes.CellContentClick

    End Sub
End Class