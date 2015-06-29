Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad
Imports System.Drawing.SystemIcons

Public Class FiltroReporteAuditoria
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
    Dim banverifcheck As Boolean = True
    Dim permiso As Double
    Dim FechaDesde As String
    Dim FechaHasta As String
    Dim ListaReportes(15, 3) As String
    'Dim f As New Funciones.Funciones
    Dim dtSucursal, dtComprobante As DataTable
    Dim FormatF1, FormatF2, FormatF3, FormatF4, FormatF5, Formateado, CodigoGral As String

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

    Private Sub FiltroReporteAuditoria_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dr As DataRow

        dtSucursal = Me.ASUCURSALTableAdapter.GetData()
        If dtSucursal.Rows.Count > 0 Then
            For i = 0 To dtSucursal.Rows.Count - 1
                dr = dtSucursal.Rows.Item(i)
                cmbSucursal.Items.Add(dr("DESSUCURSAL"))
            Next
        End If

        dtComprobante = Me.AtipocomprobanteTableAdapter.GetData()
        If dtComprobante.Rows.Count > 0 Then
            cmbComprobante.Clear()
            For i = 0 To dtComprobante.Rows.Count - 1
                dr = dtComprobante.Rows.Item(i)
                cmbComprobante.Items.Add(dr("DESCOMPROBANTE"))
            Next
        End If

        cmbTipo.Items.Add("Contado")
        cmbTipo.Items.Add("Crédito")
        cmbTipo.Items.Add("Bonificación")
        cmbTipo.Items.Add("Cambio")
        cmbTipo.Items.Add("Otros")

        cmbSucursal.AccessibleName = "False"
        cmbTipo.AccessibleName = "False"
        cmbComprobante.AccessibleName = "False"

        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)

        cargarListaReportes()
        PintarCeldas()

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
        ListaReportes = {{"TITULO", "INFORMES DE VENTAS", "Informe,Ventas"},
                         {"rptVentasAprobadas", "Facturas de Ventas Aprobadas", "Informe,Ventas"},
                         {"rptVentasAnuladas", "Facturas de Ventas Anuladas", "Informe,Ventas"},
                         {"rptVentasPendientes", "Facturas de Ventas Pendientes", "Informe,Ventas"},
                         {"TITULO", "INFORMES DE PRESUPUESTOS", "Informe,presupuestos"},
                         {"rptVentasPresupuestosEmitidos", "Presupuestos Emitidos", "Informe,presupuestos"},
                         {"rptVentasPresupuestosAnulados", "Presupuestos Anulados", "Informe,presupuestos"}}

        For i = 0 To 6
            dgvListaReportes.Rows.Add()
            dgvListaReportes.Item(1, i).Value = ListaReportes(i, 0)
            dgvListaReportes.Item(0, i).Value = ListaReportes(i, 1)
            dgvListaReportes.Item(2, i).Value = ListaReportes(i, 2)
        Next
        dgvListaReportes.AllowUserToAddRows = False
    End Sub

    Private Sub InvisivilizarTodo()
        pnlfechas.Location = PosInvisible
        pnlSinFiltro.Location = PosInvisible
        pnlComprobante.Location = PosInvisible
        pnlSucursal.Location = PosInvisible
        pnlTipo.Location = PosInvisible
    End Sub

    Private Sub FiltroReporteAuditoria_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim rpt As New Reportes.ReporteBlanco
        rpt.SetParameterValue("pmtReporteName", "Reportes de Auditoria")
        CrystalReportViewer.ReportSource = rpt
    End Sub

    Private Sub dgvListaReportes_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvListaReportes.SelectionChanged
        'Dim rpt As Reportes.ReporteBlanco
        'CrystalReportViewer.ReportSource = rpt

        If pnlFiltros.Visible = False Then
            pnlFiltros.Visible = True
        End If

        InvisivilizarTodo()

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasAprobadas" Then
            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2
            pnlTipo.Location = Pos3
            pnlfechas.Location = Pos4

            cmbSucursal.Text = "%" : cmbComprobante.Text = "%" : cmbTipo.Text = "%"
            lblReporte.Text = "Facturas de Ventas Aprobadas"
            lblReporteDescrip.Text = ""
            btnGenerar.Visible = True

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasAnuladas" Then
            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2
            pnlTipo.Location = Pos3
            pnlfechas.Location = Pos4

            cmbSucursal.Text = "%" : cmbComprobante.Text = "%" : cmbTipo.Text = "%"
            lblReporte.Text = "Facturas de Ventas Anuladas"
            lblReporteDescrip.Text = ""
            btnGenerar.Visible = True

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPendientes" Then
            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2
            pnlTipo.Location = Pos3
            pnlfechas.Location = Pos4

            cmbSucursal.Text = "%" : cmbComprobante.Text = "%" : cmbTipo.Text = "%"
            lblReporte.Text = "Facturas de Ventas Pendientes"
            lblReporteDescrip.Text = ""
            btnGenerar.Visible = True

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPresupuestosEmitidos" Then
            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2
            pnlTipo.Location = Pos3
            pnlfechas.Location = Pos4

            cmbSucursal.Text = "%" : cmbComprobante.Text = "%" : cmbTipo.Text = "%"
            lblReporte.Text = "Presupuestos Emitidos"
            lblReporteDescrip.Text = ""
            btnGenerar.Visible = True

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPresupuestosAnulados" Then
            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2
            pnlTipo.Location = Pos3
            pnlfechas.Location = Pos4

            cmbSucursal.Text = "%" : cmbComprobante.Text = "%" : cmbTipo.Text = "%"
            lblReporte.Text = "Presupuestos Anulados"
            lblReporteDescrip.Text = ""
            btnGenerar.Visible = True

        Else
            pnlSinFiltro.Location = Pos1
            lblReporte.Text = ""
            lblReporteDescrip.Text = ""
            btnGenerar.Visible = False
        End If
    End Sub

    Private Sub verificarvacioscombo(ByVal control As System.Windows.Forms.ComboBox)
        If Trim(control.Text) = "" Then
            control.Text = "%"
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        Me.Cursor = Cursors.AppStarting

        Dim desde As String = dtpFechaDesde.Value
        Dim hasta As String = dtpFechaHasta.Value
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:00"

        verificarvacioscombo(cmbComprobante)
        verificarvacioscombo(cmbSucursal)
        verificarvacioscombo(cmbTipo)

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasAprobadas" Then
            rptVentasAprobadas()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasAnuladas" Then
            rptVentasAnuladas()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPendientes" Then
            rptVentasPendientes()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPresupuestosEmitidos" Then
            rptVentasPresupuestosEmitidos()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPresupuestosAnulados" Then
            rptVentasPresupuestosAnulados()
        End If

        Me.Cursor = Cursors.Default
        pnlFiltros.Visible = False
    End Sub

    Private Sub rptVentasAprobadas()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.aVentasAprobadas
        Dim desde As String = dtpFechaDesde.Value
        Dim hasta As String = dtpFechaHasta.Value
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:00"


        AVentasAprobadasTableAdapter.selectcommand.CommandText = "SELECT VENTAS.CODVENTA, VENTAS.FECHAVENTA, TIPOCOMPROBANTE.DESCOMPROBANTE, SUCURSAL.DESSUCURSAL, VENTAS.NUMVENTA, USUARIO.NOMBRE, " & _
                                                                 "VENTAS.MODALIDADPAGO, CLIENTES.NOMBRE AS CLIENTE , VENTAS.MOTIVOANULADO FROM VENTAS INNER JOIN DETPC ON VENTAS.CODRANGO = DETPC.RANDOID INNER JOIN  " & _
                                                                 "TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN SUCURSAL ON VENTAS.CODSUCURSAL = SUCURSAL.CODSUCURSAL INNER JOIN  " & _
                                                                 "USUARIO ON VENTAS.CODUSUARIO = USUARIO.CODUSUARIO INNER JOIN CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE  "

        FormatF1 = calcularcmbTipoFactura(cmbTipo)
        FormatF2 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
        FormatF3 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")

        Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", "%", "", FormatF3, "VENTAS.CODSUCURSAL", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn")

        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103)) ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        Else
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME,'" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103)) ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        End If

        AVentasAprobadasTableAdapter.Fill(DsReportesAuditoria.AVentasAprobadas)

        rpt.SetDataSource([DsReportesAuditoria])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub rptVentasAnuladas()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.aVentasAnuladas

        AVentasAprobadasTableAdapter.selectcommand.CommandText = "SELECT VENTAS.CODVENTA, VENTAS.FECHAVENTA, TIPOCOMPROBANTE.DESCOMPROBANTE, SUCURSAL.DESSUCURSAL, VENTAS.NUMVENTA, USUARIO.NOMBRE, " & _
                                                                 "VENTAS.MODALIDADPAGO, CLIENTES.NOMBRE AS CLIENTE, VENTAS.MOTIVOANULADO FROM VENTAS INNER JOIN DETPC ON VENTAS.CODRANGO = DETPC.RANDOID INNER JOIN  " & _
                                                                 "TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN SUCURSAL ON VENTAS.CODSUCURSAL = SUCURSAL.CODSUCURSAL INNER JOIN  " & _
                                                                 "USUARIO ON VENTAS.CODUSUARIO = USUARIO.CODUSUARIO INNER JOIN CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE  "

        FormatF1 = calcularcmbTipoFactura(cmbTipo)
        FormatF2 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
        FormatF3 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")

        Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", "%", "", FormatF3, "VENTAS.CODSUCURSAL", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn")

        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 2) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103))  ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        Else
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 2)  AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME,'" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103)) ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        End If

        AVentasAprobadasTableAdapter.Fill(DsReportesAuditoria.AVentasAprobadas)

        rpt.SetDataSource([DsReportesAuditoria])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub rptVentasPendientes()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.aVentasPendientes

        AVentasAprobadasTableAdapter.selectcommand.CommandText = "SELECT VENTAS.CODVENTA, VENTAS.FECHAVENTA, TIPOCOMPROBANTE.DESCOMPROBANTE, SUCURSAL.DESSUCURSAL, VENTAS.NUMVENTA, USUARIO.NOMBRE, " & _
                                                                 "VENTAS.MODALIDADPAGO, CLIENTES.NOMBRE AS CLIENTE, VENTAS.MOTIVOANULADO FROM VENTAS INNER JOIN DETPC ON VENTAS.CODRANGO = DETPC.RANDOID INNER JOIN  " & _
                                                                 "TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN SUCURSAL ON VENTAS.CODSUCURSAL = SUCURSAL.CODSUCURSAL INNER JOIN  " & _
                                                                 "USUARIO ON VENTAS.CODUSUARIO = USUARIO.CODUSUARIO INNER JOIN CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE  "

        FormatF1 = calcularcmbTipoFactura(cmbTipo)
        FormatF2 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
        FormatF3 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")

        Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", "%", "", FormatF3, "VENTAS.CODSUCURSAL", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn")

        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103))  ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        Else
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME,'" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103)) ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        End If

        AVentasAprobadasTableAdapter.Fill(DsReportesAuditoria.AVentasAprobadas)

        rpt.SetDataSource([DsReportesAuditoria])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub rptVentasPresupuestosEmitidos()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.aVentasPresupuestosEmitidos

        AVentasAprobadasTableAdapter.selectcommand.CommandText = "SELECT VENTAS.CODVENTA, VENTAS.FECHAVENTA, TIPOCOMPROBANTE.DESCOMPROBANTE, SUCURSAL.DESSUCURSAL, VENTAS.NUMVENTA, USUARIO.NOMBRE, " & _
                                                                 "VENTAS.MODALIDADPAGO, CLIENTES.NOMBRE AS CLIENTE , VENTAS.MOTIVOANULADO FROM VENTAS INNER JOIN DETPC ON VENTAS.CODRANGO = DETPC.RANDOID INNER JOIN  " & _
                                                                 "TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN SUCURSAL ON VENTAS.CODSUCURSAL = SUCURSAL.CODSUCURSAL INNER JOIN  " & _
                                                                 "USUARIO ON VENTAS.CODUSUARIO = USUARIO.CODUSUARIO INNER JOIN CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE  "

        FormatF1 = calcularcmbTipoFactura(cmbTipo)
        FormatF2 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
        FormatF3 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")

        Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", "%", "", FormatF3, "VENTAS.CODSUCURSAL", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn")

        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 0) AND (dbo.VENTAS.CODPRESUPUESTO = 1) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103)) ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        Else
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 0) AND (dbo.VENTAS.CODPRESUPUESTO = 1) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME,'" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103)) ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        End If

        AVentasAprobadasTableAdapter.Fill(DsReportesAuditoria.AVentasAprobadas)

        rpt.SetDataSource([DsReportesAuditoria])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub rptVentasPresupuestosAnulados()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.aVentasPresupuestosAnuladas

        AVentasAprobadasTableAdapter.selectcommand.CommandText = "SELECT VENTAS.CODVENTA, VENTAS.FECHAVENTA, TIPOCOMPROBANTE.DESCOMPROBANTE, SUCURSAL.DESSUCURSAL, VENTAS.NUMVENTA, USUARIO.NOMBRE, " & _
                                                                 "VENTAS.MODALIDADPAGO, CLIENTES.NOMBRE AS CLIENTE , VENTAS.MOTIVOANULADO FROM VENTAS INNER JOIN DETPC ON VENTAS.CODRANGO = DETPC.RANDOID INNER JOIN  " & _
                                                                 "TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN SUCURSAL ON VENTAS.CODSUCURSAL = SUCURSAL.CODSUCURSAL INNER JOIN  " & _
                                                                 "USUARIO ON VENTAS.CODUSUARIO = USUARIO.CODUSUARIO INNER JOIN CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE  "

        FormatF1 = calcularcmbTipoFactura(cmbTipo)
        FormatF2 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
        FormatF3 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")

        Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", "%", "", FormatF3, "VENTAS.CODSUCURSAL", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn")

        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 2) AND (dbo.VENTAS.CODPRESUPUESTO = 1) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103)) ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        Else
            Me.AVentasAprobadasTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 2) AND (dbo.VENTAS.CODPRESUPUESTO = 1) AND (VENTAS.FECHAVENTA >= CONVERT(DATETIME,'" & FechaDesde & "',103)) AND (VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & FechaHasta & "',103)) ORDER BY SUCURSAL.DESSUCURSAL, TIPOCOMPROBANTE.DESCOMPROBANTE, VENTAS.MODALIDADPAGO, VENTAS.FECHAVENTA"
        End If

        AVentasAprobadasTableAdapter.Fill(DsReportesAuditoria.AVentasAprobadas)

        rpt.SetDataSource([DsReportesAuditoria])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Function obtenerwhere(ByVal Filtro1 As String, ByVal nombrecampof1 As String, ByVal Filtro2 As String, ByVal nombrecampof2 As String, ByVal Filtro3 As String, ByVal nombrecampof3 As String, ByVal Filtro4 As String, ByVal nombrecampof4 As String, ByVal tipo1 As String, ByVal tipo2 As String, ByVal tipo3 As String, ByVal tipo4 As String, Optional ByVal filtro5 As String = "%", Optional ByVal nombrecampof5 As String = "", Optional ByVal tipo5 As String = "", Optional ByVal filtro6 As String = "%", Optional ByVal nombrecampof6 As String = "", Optional ByVal tipo6 As String = "", Optional ByVal filtro7 As String = "%", Optional ByVal nombrecampof7 As String = "", Optional ByVal tipo7 As String = "")
        Dim CtrlFiltro1 As String = ""
        Dim SiFiltro1 As Boolean = False
        Dim CtrlFiltro2 As String = ""
        Dim SiFiltro2 As Boolean = False
        Dim CtrlFiltro3 As String = ""
        Dim SiFiltro3 As Boolean = False
        Dim CtrlFiltro4 As String = ""
        Dim SiFiltro4 As Boolean = False
        Dim CtrlFiltro5 As String = ""
        Dim SiFiltro5 As Boolean = False
        Dim CtrlFiltro6 As String = ""
        Dim SiFiltro6 As Boolean = False
        Dim CtrlFiltro7 As String = ""
        Dim consultawhere As String

        If Filtro1 = "%" Or Filtro1 = "" Then
            SiFiltro1 = False
        Else
            If tipo1 = "Cadena Text" Then
                CtrlFiltro1 = nombrecampof1 + " = '" & Filtro1 & "'"
            ElseIf tipo1 = "Numero Text" Then
                CtrlFiltro1 = nombrecampof1 + " = " & Filtro1
            ElseIf tipo1 = "CodigoIn" Then
                CtrlFiltro1 = nombrecampof1 + " IN (" & Filtro1 & ")"
            ElseIf tipo1 = "CodigoIn NULL" Then
                CtrlFiltro1 = "(" & nombrecampof1 + " IN (" & Filtro1 & ") OR " & nombrecampof1 & " IS NULL)"
            ElseIf tipo1 = "Especial" Then
                CtrlFiltro1 = Filtro1
            End If
            SiFiltro1 = True
        End If

        If Filtro2 = "%" Or Filtro2 = "" Then
            SiFiltro2 = False
        Else
            SiFiltro2 = True
            If SiFiltro1 = False Then
                If tipo2 = "Cadena Text" Then
                    CtrlFiltro2 = nombrecampof2 + " = '" & Filtro2 & "'"
                ElseIf tipo2 = "Numero Text" Then
                    CtrlFiltro2 = nombrecampof2 + " = " & Filtro2
                ElseIf tipo2 = "CodigoIn" Then
                    CtrlFiltro2 = nombrecampof2 + " IN (" & Filtro2 & ")"
                ElseIf tipo2 = "CodigoIn NULL" Then
                    CtrlFiltro2 = "(" & nombrecampof2 + " IN (" & Filtro2 & ") OR " & nombrecampof2 & " IS NULL)"
                ElseIf tipo2 = "Especial" Then
                    CtrlFiltro2 = Filtro2
                End If
            Else
                If tipo2 = "Cadena Text" Then
                    CtrlFiltro2 = " AND " + nombrecampof2 + " = '" & Filtro2 & "'"
                ElseIf tipo2 = "Numero Text" Then
                    CtrlFiltro2 = " AND " + nombrecampof2 + " = " & Filtro2
                ElseIf tipo2 = "CodigoIn" Then
                    CtrlFiltro2 = " AND " & nombrecampof2 + " IN (" & Filtro2 & ")"
                ElseIf tipo2 = "CodigoIn NULL" Then
                    CtrlFiltro2 = " AND (" + nombrecampof2 + " IN (" & Filtro2 & ") OR " & nombrecampof2 & " IS NULL)"
                ElseIf tipo2 = "Especial" Then
                    CtrlFiltro2 = " AND " + Filtro2
                End If
            End If
        End If

        If Filtro3 = "%" Or Filtro3 = "" Then
            SiFiltro3 = False
        Else
            SiFiltro3 = True
            If SiFiltro1 = True Or SiFiltro2 = True Then
                If tipo3 = "Cadena Text" Then
                    CtrlFiltro3 = " AND " + nombrecampof3 + " = '" & Filtro3 & "'"
                ElseIf tipo3 = "Numero Text" Then
                    CtrlFiltro3 = " AND " + nombrecampof3 + " = " & Filtro3
                ElseIf tipo3 = "CodigoIn" Then
                    CtrlFiltro3 = " AND " + nombrecampof3 + " IN (" & Filtro3 & ")"
                ElseIf tipo3 = "CodigoIn NULL" Then
                    CtrlFiltro3 = " AND (" + nombrecampof3 + " IN (" & Filtro3 & ") OR " & nombrecampof3 & " IS NULL)"
                ElseIf tipo3 = "Especial" Then
                    CtrlFiltro3 = " AND " + Filtro3
                End If
            Else
                If tipo3 = "Cadena Text" Then
                    CtrlFiltro3 = nombrecampof3 + " = '" & Filtro3 & "'"
                ElseIf tipo3 = "Numero Text" Then
                    CtrlFiltro3 = nombrecampof3 + " = " & Filtro3
                ElseIf tipo3 = "CodigoIn" Then
                    CtrlFiltro3 = nombrecampof3 + " IN (" & Filtro3 & ")"
                ElseIf tipo3 = "CodigoIn NULL" Then
                    CtrlFiltro3 = "(" & nombrecampof3 + " IN (" & Filtro3 & ") OR " & nombrecampof3 & " IS NULL)"
                ElseIf tipo3 = "Especial" Then
                    CtrlFiltro3 = Filtro3
                End If
            End If
        End If


        If Filtro4 = "%" Or Filtro4 = "" Then
            SiFiltro4 = False
        Else
            SiFiltro4 = True
            If SiFiltro1 = True Or SiFiltro2 = True Or SiFiltro3 = True Then
                If tipo4 = "Cadena Text" Then
                    CtrlFiltro4 = " AND " + nombrecampof4 + " = '" & Filtro4 & "'"
                ElseIf tipo4 = "Numero Text" Then
                    CtrlFiltro4 = " AND " + nombrecampof4 + " = " & Filtro4
                ElseIf tipo4 = "CodigoIn" Then
                    CtrlFiltro4 = " AND " + nombrecampof4 + " IN (" & Filtro4 & ")"
                ElseIf tipo4 = "CodigoIn NULL" Then
                    CtrlFiltro4 = " AND (" + nombrecampof4 + " IN (" & Filtro4 & ") OR " & nombrecampof4 & " IS NULL)"
                ElseIf tipo4 = "Especial" Then
                    CtrlFiltro4 = " AND " + Filtro4
                End If
            Else
                If tipo4 = "Cadena Text" Then
                    CtrlFiltro4 = nombrecampof4 + " = '" & Filtro4 & "'"
                ElseIf tipo4 = "Numero Text" Then
                    CtrlFiltro4 = nombrecampof4 + " = " & Filtro4 & ""
                ElseIf tipo4 = "CodigoIn" Then
                    CtrlFiltro4 = nombrecampof4 + " IN (" & Filtro4 & ")"
                ElseIf tipo4 = "CodigoIn NULL" Then
                    CtrlFiltro4 = "(" & nombrecampof4 + " IN (" & Filtro4 & ") OR " & nombrecampof4 & " IS NULL)"
                ElseIf tipo4 = "Especial" Then
                    CtrlFiltro4 = Filtro4
                End If
            End If
        End If

        If filtro5 = "%" Or filtro5 = "" Then
            SiFiltro5 = False
        Else
            SiFiltro5 = True
            If SiFiltro1 = True Or SiFiltro2 = True Or SiFiltro3 = True Or SiFiltro4 = True Then
                If tipo5 = "Cadena Text" Then
                    CtrlFiltro5 = " AND " + nombrecampof5 + " = '" & filtro5 & "'"
                ElseIf tipo5 = "Numero Text" Then
                    CtrlFiltro5 = " AND " + nombrecampof5 + " = " & filtro5
                ElseIf tipo5 = "CodigoIn" Then
                    CtrlFiltro5 = " AND " + nombrecampof5 + " IN (" & filtro5 & ")"
                ElseIf tipo5 = "CodigoIn NULL" Then
                    CtrlFiltro5 = " AND (" + nombrecampof5 + " IN (" & filtro5 & ") OR " & nombrecampof5 & " IS NULL)"
                ElseIf tipo5 = "Especial" Then
                    CtrlFiltro5 = " AND " + filtro5
                End If
            Else
                If tipo5 = "Cadena Text" Then
                    CtrlFiltro5 = nombrecampof5 + " = '" & filtro5 & "'"
                ElseIf tipo5 = "Numero Text" Then
                    CtrlFiltro5 = nombrecampof5 + " = " & filtro5 & ""
                ElseIf tipo5 = "CodigoIn" Then
                    CtrlFiltro5 = nombrecampof5 + " IN (" & filtro5 & ")"
                ElseIf tipo5 = "CodigoIn NULL" Then
                    CtrlFiltro5 = "(" & nombrecampof5 + " IN (" & filtro5 & ") OR " & nombrecampof5 & " IS NULL)"
                ElseIf tipo5 = "Especial" Then
                    CtrlFiltro5 = filtro5
                End If
            End If
        End If

        If filtro6 = "%" Or filtro6 = "" Then
            SiFiltro6 = False
        Else
            SiFiltro6 = True
            If SiFiltro1 = True Or SiFiltro2 = True Or SiFiltro3 = True Or SiFiltro4 = True Or SiFiltro5 = True Then
                If tipo6 = "Cadena Text" Then
                    CtrlFiltro6 = " AND " + nombrecampof6 + " = '" & filtro6 & "'"
                ElseIf tipo6 = "Numero Text" Then
                    CtrlFiltro6 = " AND " + nombrecampof6 + " = " & filtro6
                ElseIf tipo6 = "CodigoIn" Then
                    CtrlFiltro6 = " AND " + nombrecampof6 + " IN (" & filtro6 & ")"
                ElseIf tipo6 = "CodigoIn NULL" Then
                    CtrlFiltro6 = " AND (" + nombrecampof6 + " IN (" & filtro6 & ") OR " & nombrecampof6 & " IS NULL)"
                ElseIf tipo6 = "Especial" Then
                    CtrlFiltro6 = " AND " + filtro6
                End If
            Else
                If tipo6 = "Cadena Text" Then
                    CtrlFiltro6 = nombrecampof6 + " = '" & filtro6 & "'"
                ElseIf tipo6 = "Numero Text" Then
                    CtrlFiltro6 = nombrecampof6 + " = " & filtro6 & ""
                ElseIf tipo6 = "CodigoIn" Then
                    CtrlFiltro6 = nombrecampof6 + " IN (" & filtro6 & ")"
                ElseIf tipo6 = "CodigoIn NULL" Then
                    CtrlFiltro6 = "(" & nombrecampof6 + " IN (" & filtro6 & ") OR " & nombrecampof6 & " IS NULL)"
                ElseIf tipo6 = "Especial" Then
                    CtrlFiltro6 = filtro6
                End If
            End If
        End If

        If filtro7 = "%" Or filtro7 = "" Then
            'nada
        Else
            'SiFiltro7 = True
            If SiFiltro1 = True Or SiFiltro2 = True Or SiFiltro3 = True Or SiFiltro4 = True Or SiFiltro5 = True Or SiFiltro6 = True Then
                If tipo7 = "Cadena Text" Then
                    CtrlFiltro7 = " AND " + nombrecampof7 + " = '" & filtro7 & "'"
                ElseIf tipo7 = "Numero Text" Then
                    CtrlFiltro7 = " AND " + nombrecampof7 + " = " & filtro7
                ElseIf tipo7 = "CodigoIn" Then
                    CtrlFiltro7 = " AND " + nombrecampof7 + " IN (" & filtro7 & ")"
                ElseIf tipo7 = "CodigoIn NULL" Then
                    CtrlFiltro7 = " AND (" + nombrecampof7 + " IN (" & filtro7 & ") OR " & nombrecampof7 & " IS NULL)"
                ElseIf tipo7 = "Especial" Then
                    CtrlFiltro7 = " AND " + filtro7
                End If
            Else
                If tipo7 = "Cadena Text" Then
                    CtrlFiltro7 = nombrecampof7 + " = '" & filtro7 & "'"
                ElseIf tipo7 = "Numero Text" Then
                    CtrlFiltro7 = nombrecampof7 + " = " & filtro7 & ""
                ElseIf tipo7 = "CodigoIn" Then
                    CtrlFiltro7 = nombrecampof7 + " IN (" & filtro7 & ")"
                ElseIf tipo7 = "CodigoIn NULL" Then
                    CtrlFiltro7 = "(" & nombrecampof7 + " IN (" & filtro7 & ") OR " & nombrecampof7 & " IS NULL)"
                ElseIf tipo7 = "Especial" Then
                    CtrlFiltro7 = filtro7
                End If
            End If
        End If

        consultawhere = CtrlFiltro1 + CtrlFiltro2 + CtrlFiltro3 + CtrlFiltro4 + CtrlFiltro5 + CtrlFiltro6 + CtrlFiltro7

        Return consultawhere
    End Function

    Private Function calcularcmbTipoFactura(combo As PresentationControls.CheckBoxComboBox) As String
        CodigoGral = ""
        If combo.Text = "%" Then
            CodigoGral = "%"
        Else
            For i = 0 To combo.Items.Count - 1
                If combo.CheckBoxItems(i).Checked = True Then
                    If combo.CheckBoxItems(i).Text = "Contado" Then
                        CodigoGral = CodigoGral + "0,"
                    ElseIf combo.CheckBoxItems(i).Text = "Crédito" Then
                        CodigoGral = CodigoGral + "1,"
                    ElseIf combo.CheckBoxItems(i).Text = "Bonificación" Then
                        CodigoGral = CodigoGral + "2,"
                    ElseIf combo.CheckBoxItems(i).Text = "Cambio" Then
                        CodigoGral = CodigoGral + "3,"
                    ElseIf combo.CheckBoxItems(i).Text = "Otros" Then
                        CodigoGral = CodigoGral + "4,"
                    End If
                End If
            Next
            If CodigoGral <> "" Then
                CodigoGral = Mid(CodigoGral, 1, CodigoGral.Length - 1)
            End If
        End If
        Return CodigoGral
    End Function

    Private Function FormatearFiltroCheckCombo(combo As PresentationControls.CheckBoxComboBox, ByVal Dtable As DataTable, CampoCodigo As String, ReturnPorc As String) As String
        Formateado = ""
        If combo.Text = "%" And ReturnPorc = "SI" Then
            Formateado = "%"
        Else
            Formateado = calcularCodigos(Dtable, combo, CampoCodigo)
        End If
        Return Formateado
    End Function

    Private Function calcularCodigos(ByVal Dtable As DataTable, combo As PresentationControls.CheckBoxComboBox, CampoCodigo As String) As String
        CodigoGral = ""
        Dim dr As DataRow
        For i = 0 To combo.Items.Count - 1
            If combo.CheckBoxItems(i).Checked = True Then
                dr = Dtable.Rows(i) ' Los ItemsIndex Coinciden
                CodigoGral = CodigoGral + dr("" & CampoCodigo & "").ToString + ","
            End If
        Next
        If CodigoGral <> "" Then
            CodigoGral = Mid(CodigoGral, 1, CodigoGral.Length - 1)
        End If
        Return CodigoGral
    End Function

    Private Sub marcardesmarcartodos(combo As PresentationControls.CheckBoxComboBox, dt As DataTable)
        banverifcheck = False
        If dt.Rows.Count > 0 Then
            If combo.AccessibleName <> "True" Then
                For i = 0 To combo.CheckBoxItems.Count - 1
                    combo.CheckBoxItems(i).Checked = True
                Next
                combo.AccessibleName = "True"
            Else
                For i = 0 To combo.CheckBoxItems.Count - 1
                    combo.CheckBoxItems(i).Checked = False
                Next
                combo.AccessibleName = "False"
            End If
        End If
        banverifcheck = True
    End Sub

    Private Sub marcardesmarcartodossindt(combo As PresentationControls.CheckBoxComboBox)
        banverifcheck = False
        If combo.AccessibleName <> "True" Then
            For i = 0 To combo.CheckBoxItems.Count - 1
                combo.CheckBoxItems(i).Checked = True
            Next
            combo.AccessibleName = "True"
        Else
            For i = 0 To combo.CheckBoxItems.Count - 1
                combo.CheckBoxItems(i).Checked = False
            Next
            combo.AccessibleName = "False"
        End If
        banverifcheck = True
    End Sub

    Private Sub cmbSucursal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbSucursal.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbSucursal.Text = "%"
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
        ElseIf e.KeyCode = Keys.Back And cmbSucursal.Text.Length = 1 And cmbSucursal.AccessibleName <> "False" Then
            marcardesmarcartodos(cmbSucursal, dtSucursal)
        End If
    End Sub

    Private Sub cmbTipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbTipo.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"
        ElseIf e.KeyCode = Keys.Back And cmbTipo.Text.Length = 1 And cmbTipo.AccessibleName <> "False" Then
            marcardesmarcartodossindt(cmbTipo)
        End If
    End Sub

    Private Sub cmbComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbComprobante.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbComprobante.Text = "%"
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
        ElseIf e.KeyCode = Keys.Back And cmbComprobante.Text.Length = 1 And cmbComprobante.AccessibleName <> "False" Then
            marcardesmarcartodos(cmbComprobante, dtComprobante)
        End If
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

    Private Sub BuscarTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.GotFocus
        BuscarTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.LostFocus
        BuscarTextBox.BackColor = Color.Tan
    End Sub
End Class