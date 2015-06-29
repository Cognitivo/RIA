Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad

Public Class ReporteCompras
    Dim sql As String
    Dim sql1 As String
    Dim btnPos1 As System.Drawing.Point = New Point(306, 89)
    Dim btnPos2 As System.Drawing.Point = New Point(439, 89)
    Dim btnPos3 As System.Drawing.Point = New Point(572, 89)
    Dim btnPos4 As System.Drawing.Point = New Point(705, 89)
    Dim FechaDesde As String
    Dim FechaHasta As String

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        Dim desde As String = dtpFechaDesde.Value
        Dim hasta As String = dtpFechaHasta.Value
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:59"
        Me.Cursor = Cursors.AppStarting
        If treeReportesVentas.SelectedNode.Name = "frmCompraProducto" Then
            frmCompraProducto()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptCompraSucursal" Then
            rptCompraSucursal()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptGastosporCentroCosto" Then
            rptCompraCentroCosto()
            'PARA EL REPORTE DETALLADO POR CENTRO DE COSTOS
        ElseIf treeReportesVentas.SelectedNode.Name = "rptDetalleporCentroCosto" Then
            rptCompraCentroCostoDetalle()
            '-----------------------------------------------------------------------
        ElseIf treeReportesVentas.SelectedNode.Name = "rptPendienteProveedor" Then
            rptPendienteProveedor()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptListaProveedor" Then
            rptListaProveedor()
        ElseIf treeReportesVentas.SelectedNode.Name = "frmCompraPorCategorias" Then
            ' frmCompraPorCategorias()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptDiarioCajaDet" Then
            rptDiarioCajaDet()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptDiarioCajaResum" Then
            rptDiarioCajaResum()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptIVACompras" Then
            rptIVACompras()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptLibroCompraLEY" Then
            rptLIBROComprasLEY()
        ElseIf treeReportesVentas.SelectedNode.Name = "NotasCreditoLey" Then
            NotasCreditoLey()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptIVANCCompras" Then
            rptIVANCCompras()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasFifo" Then

        ElseIf treeReportesVentas.SelectedNode.Name = "rptGastosCdCTotalRTLineal" Then
            rptGastosCdCTotalRTLineal()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptGastosCdCTotalRTMensual" Then
            rptGastosCdCTotalRTMensual()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptFacturasCobrar" Then
            rptFacturasCobrar()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptCostosUltimaCompra" Then
            rptUltimaCompraDias()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasCostoPromedio" Then
            rptComprasCostoPromedio()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptCOGSDetallado" Then
            rptCOGSDetallado()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptCostoFifo" Then
            rptCostoFifo()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptCostoFijoListaPrecio" Then
            rptCostoFijoListaPrecio()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasVsListaPrecioSinCF" Then
            rptComprasVsListaPrecioSinCF()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasVs.ListaPrecioUltimaCompra" Then
            rptComprasVsListaPrecioUltimaCompra()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptCuentaCorrienteProveedor" Then
            rptCuentaCorrienteProveedor()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptCostoFijo" Then
            rptCostoFijo()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptConsultaCompras" Then
            rptConsultaCompras()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasLista" Then
            rptComprasLista()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptPendientesPago" Then
            rptPendientesPago()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptFacturasPagar" Then
            rptFacturasPagar()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptAnalisisSaldo" Then
            rptAnalisisSaldo()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptRecibosXFactura" Then
            rptRecibosXFactura()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptFacturasXRecibo" Then
            rptFacturasXRecibo()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptRecibosProveedor" Then
            rptRecibosProveedor()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptRecibosProveedorDet" Then
            rptRecibosProveedorDet()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptRetenciones" Then
            rptRetenciones()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptEstadoCuenta" Then
            rptEstadoCuentaProveedor()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasPorProveedor" Then
            rptComprasPrecioPorProductoPorProveedor()
        ElseIf treeReportesVentas.SelectedNode.Name = "rptListadoOC" Then
            rptListadoOC()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub rptIVACompras()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasIVAComprasDetallado
        Dim rptmat As New Reportes.ComprasIVAComprasDetalladoMATR

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            'Acortamos para incluir Where"
            Me.RCIVAComprasTableAdapter.selectcommand.CommandText = "SELECT TOP (100) PERCENT FECHA, TIPO, NUMCOMPRA, NUMPROVEEDOR, NOMBRE, SIMBOLO, CASE WHEN iva = 10 AND " & _
                         "cant10 = cantotal THEN totalcompra - totalcompra / 11 WHEN iva = 10 AND cant10 <> cantotal THEN SUM(IMPORTEGRAVADO10) - SUM(IMPORTEGRAVADO10) " & _
                         "/ 11 WHEN iva = 5 AND cant5 = cantotal THEN totalcompra / 21 - totalcompra WHEN iva = 5 AND cant5 <> cantotal THEN SUM(IMPORTEGRAVADO5) " & _
                         "- SUM(IMPORTEGRAVADO5) / 21 END AS NETO, CASE WHEN iva = 10 AND cant10 = cantotal THEN totalcompra / 11 ELSE SUM(IMPORTEGRAVADO10) " & _
                         "/ 11 END AS IVA10, CASE WHEN iva = 5 AND cant5 = cantotal THEN totalcompra / 21 ELSE SUM(IMPORTEGRAVADO5) / 21 END AS IVA5, IVA, " & _
                         "CODPROVEEDOR, CODCOMPRA, CASE WHEN iva = 10 AND cant10 = cantotal THEN totalcompra ELSE SUM(IMPORTEGRAVADO10) END AS TOTALGRAB10, " & _
                         "CASE WHEN iva = 5 AND cant5 = cantotal THEN totalcompra ELSE SUM(IMPORTEGRAVADO5) END AS TOTALGRAV5 " & _
            "FROM            (SELECT COMP.FECHACOMPRA AS FECHA, CASE COMP.MODALIDADPAGO WHEN 0 THEN 'COMP_CONT' WHEN 1 THEN 'COMP_CRED' END AS TIPO, " & _
            "SUBSTRING(COMP.NUMCOMPRA, LEN(COMP.NUMCOMPRA) - 5, 6) AS NUMCOMPRA, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.MONEDA.SIMBOLO, dbo.COMPRASDETALLE.IMPORTEGRAVADO10, " & _
            "dbo.COMPRASDETALLE.IMPORTEGRAVADO5, dbo.COMPRASDETALLE.IVA, COMP.CODPROVEEDOR, COMP.CODCOMPRA, COMP.TOTALCOMPRA, SUCURSAL.DESSUCURSAL, " & _
                                                        "(SELECT        COUNT(CODCOMPRA) AS Expr1 FROM            dbo.COMPRASDETALLE AS CD " & _
                                                        "  WHERE        (CODCOMPRA = COMP.CODCOMPRA) AND (IVA = 10)) AS CANT10, " & _
                                                        "(SELECT        COUNT(CODCOMPRA) AS Expr1 FROM            dbo.COMPRASDETALLE AS CD " & _
                                                        "  WHERE        (CODCOMPRA = COMP.CODCOMPRA) AND (IVA = 5)) AS CANT5, " & _
                                                        "(SELECT        COUNT(CODCOMPRA) AS Expr1 FROM            dbo.COMPRASDETALLE AS CD " & _
                                                        "  WHERE        (CODCOMPRA = COMP.CODCOMPRA) AND (IVA <> 0)) AS CANTOTAL " & _
                              "FROM            dbo.COMPRAS AS COMP LEFT OUTER JOIN " & _
                                                   "dbo.SUCURSAL ON COMP.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN " & _
                                                   "dbo.PROVEEDOR ON COMP.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR INNER JOIN " & _
                                                   "dbo.COMPRASDETALLE ON COMP.CODCOMPRA = dbo.COMPRASDETALLE.CODCOMPRA LEFT OUTER JOIN " & _
                                                   "dbo.MONEDA ON COMP.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                                                   "dbo.TIPOCOMPROBANTE ON COMP.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                              "WHERE        (COMP.ESTADO = 1)) AS SUBCONSULTA " & _
            "WHERE        (IVA <> 0) "

            Dim sqlwhere As String = obtenerwhere(cmbSucursal, "DESSUCURSAL", cmbtipo2, "TIPO", cbxCdC, "", cbxCdC, "", "Cadena Text", "Numero Text", "Cadena Text", "Cadena Text")
            If cmbProveedor.Text = "%" Then
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RCIVAComprasTableAdapter.selectcommand.CommandText += " AND (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') GROUP BY FECHA, NUMCOMPRA, NUMPROVEEDOR, TOTALCOMPRA, SIMBOLO, NOMBRE, TIPO, IVA, CODPROVEEDOR, CODCOMPRA, CANT10, CANT5, CANTOTAL, DESSUCURSAL ORDER BY FECHA, NUMCOMPRA"
                Else
                    Me.RCIVAComprasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') GROUP BY FECHA, NUMCOMPRA, NUMPROVEEDOR, TOTALCOMPRA, SIMBOLO, NOMBRE, TIPO, IVA, CODPROVEEDOR, CODCOMPRA, CANT10, CANT5, CANTOTAL, DESSUCURSAL ORDER BY FECHA, NUMCOMPRA"
                End If
                Me.RCIVAComprasTableAdapter.Fill(DSReporteCompras.RCIVACOMPRAS)

                If chbxMatricial.Checked = True Then
                    txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rptmat.SetDataSource([DSReporteCompras])
                    rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)

                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If
                    If cmbtipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "IVA Compras")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "IVA Compras / " + cmbtipo.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                    rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rpt.SetDataSource([DSReporteCompras])
                    rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)

                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If
                    If cmbtipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "IVA Compras")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "IVA Compras / " + cmbtipo.Text)
                    End If

                    rpt.SetParameterValue("pmtFDesde", FechaDesde)
                    rpt.SetParameterValue("pmtFHasta", FechaHasta)
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If

            Else ' Un Proveedor Especifico
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RCIVAComprasTableAdapter.selectcommand.CommandText += " (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') AND CODPROVEEDOR = " & cmbProveedor.SelectedValue & " GROUP BY FECHA, NUMCOMPRA, NUMPROVEEDOR, TOTALCOMPRA, SIMBOLO, NOMBRE, TIPO, IVA, CODPROVEEDOR, CODCOMPRA, CANT10, CANT5, CANTOTAL, DESSUCURSAL ORDER BY FECHA, NUMCOMPRA"
                Else
                    Me.RCIVAComprasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') AND CODPROVEEDOR = " & cmbProveedor.SelectedValue & " GROUP BY FECHA, NUMCOMPRA, NUMPROVEEDOR, TOTALCOMPRA, SIMBOLO, NOMBRE, TIPO, IVA, CODPROVEEDOR, CODCOMPRA, CANT10, CANT5, CANTOTAL, DESSUCURSAL ORDER BY FECHA, NUMCOMPRA"
                End If
                Me.RCIVAComprasTableAdapter.Fill(DSReporteCompras.RCIVACOMPRAS)

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DSReporteCompras])
                    rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
                    rptmat.SetParameterValue("pmtCliente", cmbProveedor.Text)
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If
                    If cmbtipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "IVA Compras")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "IVA Compras / " + cmbtipo.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                    rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    rpt.SetDataSource([DSReporteCompras])
                    rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)
                    rpt.SetParameterValue("pmtCliente", cmbProveedor.Text)
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If
                    If cmbtipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "IVA Compras")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "IVA Compras / " + cmbtipo.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", FechaDesde)
                    rpt.SetParameterValue("pmtFHasta", FechaHasta)
                    frm.CrystalReportViewer1.ReportSource = rpt

                End If
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptLIBROComprasLEY()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaLibroIvaComprasV2
        Dim rptmat As New Reportes.ContaLibroIvaComprasV2

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value & " 23:59:59"

            If cmbSucursal.Text = "%" Then
                Me.LibroivacomprA_RCTableAdapter.FillBy(DsRCCompras.LIBROIVACOMPRA_RC, fechadesde2, fechahasta2)
            Else
                Me.LibroivacomprA_RCTableAdapter.Fill(DsRCCompras.LIBROIVACOMPRA_RC, fechadesde2, fechahasta2, cmbSucursal.SelectedValue)
            End If

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCCompras])
                rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCCompras])
                rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NotasCreditoLey()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaLibroIvaNCCompras
        Dim rptmat As New Reportes.ContaLibroIvaNCCompras

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value & " 23:59:59"

            'Acortamos para incluir Where"
            Me.RcivancleyTableAdapter.selectcommand.CommandText = "SELECT dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION AS FECHA, DAY(dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION) AS FECHADEVOLUCION, " & _
                         "YEAR(dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION) AS AÑO, dbo.DEVOLUCIONCOMPRA.TIPODEVOLUCION AS TIPO, " & _
                         "dbo.DEVOLUCIONCOMPRA.NUMDEVOLUCION, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.MONEDA.SIMBOLO, 0 AS NETO, " & _
                         "dbo.PROVEEDOR.CODPROVEEDOR, dbo.DEVOLUCIONCOMPRA.TOTALIVA10 AS IVA10, dbo.DEVOLUCIONCOMPRA.TOTALIVA5 AS IVA5, " & _
                         "dbo.DEVOLUCIONCOMPRA.CODDEVOLUCION, dbo.DEVOLUCIONCOMPRA.TOTALIVA10 * 11 AS IMPORTEGRAVADO10, " & _
                         "dbo.DEVOLUCIONCOMPRA.TOTALIVA5 * 21 AS IMPORTEGRAVADO5, dbo.DEVOLUCIONCOMPRA.TOTALDEVOLUCION, dbo.DEVOLUCIONCOMPRA.TOTALEXENTA, dbo.PROVEEDOR.RUC_CIN " & _
            "FROM            dbo.DEVOLUCIONCOMPRA INNER JOIN " & _
                         "dbo.PROVEEDOR ON dbo.DEVOLUCIONCOMPRA.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR LEFT OUTER JOIN " & _
                         "dbo.MONEDA ON dbo.DEVOLUCIONCOMPRA.CODMONEDA = dbo.MONEDA.CODMONEDA INNER JOIN " & _
                         "dbo.SUCURSAL ON dbo.DEVOLUCIONCOMPRA.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL"

            Dim sqlwhere As String = obtenerwhere(cmbSucursal, "SUCURSAL.DESSUCURSAL", cmbtipo2, "DEVOLUCIONCOMPRA.TIPODEVOLUCION", cbxCdC, "", cbxCdC, "", "Cadena Text", "Numero Text", "Cadena Text", "Cadena Text")

            If cmbProveedor.Text = "%" Then
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RcivancleyTableAdapter.selectcommand.CommandText += " WHERE (DEVOLUCIONCOMPRA.ESTADO = 1) AND (DEVOLUCIONCOMPRA.FECHADEVOLUCION >= CONVERT(DATETIME,'" & fechadesde2 & "', 103)) AND (DEVOLUCIONCOMPRA.FECHADEVOLUCION <= CONVERT(DATETIME,'" & fechahasta2 & "', 103)) ORDER BY FECHA, NUMDEVOLUCION"
                Else
                    Me.RcivancleyTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (DEVOLUCIONCOMPRA.ESTADO = 1) AND (DEVOLUCIONCOMPRA.FECHADEVOLUCION >= CONVERT(DATETIME,'" & fechadesde2 & "', 103)) AND (DEVOLUCIONCOMPRA.FECHADEVOLUCION <= CONVERT(DATETIME,'" & fechahasta2 & "', 103)) ORDER BY FECHA, NUMDEVOLUCION"
                End If

                Me.RcivancleyTableAdapter.Fill(DSReporteCompras.RCIVANCLEY)

                If chbxMatricial.Checked = True Then

                    rptmat.SetDataSource([DSReporteCompras])
                    rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
                    rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    rpt.SetDataSource([DSReporteCompras])
                    rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)
                    rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

                    frm.CrystalReportViewer1.ReportSource = rpt
                End If

            Else ' Un Proveedor Especifico
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RcivaleyTableAdapter.selectcommand.CommandText += " WHERE (COMP.ESTADO = 1) AND (COMP.FECHACOMPRA >= CONVERT(DATETIME,'" & fechadesde2 & "', 103)) AND (COMP.FECHACOMPRA <= CONVERT(DATETIME,'" & fechahasta2 & "', 103))  AND CODPROVEEDOR= " & cmbProveedor.SelectedValue & " GROUP BY COMP.FECHACOMPRA, COMP.NUMCOMPRA, PROVEEDOR.NUMPROVEEDOR,PROVEEDOR.RUC_CIN, COMP.COTIZACION1, MONEDA.SIMBOLO, PROVEEDOR.NOMBRE, COMP.MODALIDADPAGO, COMP.CODPROVEEDOR, COMP.CODCOMPRA, COMP.TOTALCOMPRA ORDER BY FECHA, NUMCOMPRA"
                Else
                    Me.RcivaleyTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (COMP.ESTADO = 1) AND (COMP.FECHACOMPRA >= CONVERT(DATETIME,'" & fechadesde2 & "', 103)) AND (COMP.FECHACOMPRA <= CONVERT(DATETIME,'" & fechahasta2 & "', 103)) AND CODPROVEEDOR= " & cmbProveedor.SelectedValue & " GROUP BY COMP.FECHACOMPRA, COMP.NUMCOMPRA, PROVEEDOR.NUMPROVEEDOR,PROVEEDOR.RUC_CIN, COMP.COTIZACION1, MONEDA.SIMBOLO, PROVEEDOR.NOMBRE, COMP.MODALIDADPAGO, COMP.CODPROVEEDOR, COMP.CODCOMPRA, COMP.TOTALCOMPRA ORDER BY FECHA, NUMCOMPRA"
                End If
                Me.RcivaleyTableAdapter.Fill(DSReporteCompras.RCIVALEY)

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DSReporteCompras])
                    rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
                    rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

                  
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    rpt.SetDataSource([DSReporteCompras])
                    rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)
                    rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

                  
                    frm.CrystalReportViewer1.ReportSource = rpt

                End If
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptIVANCCompras()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasIVANCreditoDetallado
        Dim rptmat As New Reportes.ComprasIVANCreditoDetalladoMATR

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            'Acortamos para incluir Where"
            Me.RCIVANCREDITOComprasTableAdapter.selectcommand.CommandText = "SELECT  DEV.FECHADEVOLUCION AS FECHA, SUBSTRING(DEV.NUMDEVOLUCION, LEN(DEV.NUMDEVOLUCION) - 5, 6) AS NUMDEVOLUCION, " & _
                         "dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.MONEDA.SIMBOLO, " & _
                         "CASE COMPRAS.MODALIDADPAGO WHEN 2 THEN 'NC_BONIF' WHEN 3 THEN 'NC_CAMBIO' WHEN 4 THEN 'NC_OTROS' ELSE 'NC_COMPRAS' END AS TIPO, " & _
                         "CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONCOMPRADETALLE.PRECIONETO * dbo.DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA) " & _
                         "- SUM(dbo.DEVOLUCIONCOMPRADETALLE.PRECIONETO * dbo.DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA) " & _
                         "/ 11 WHEN 5 THEN SUM(dbo.DEVOLUCIONCOMPRADETALLE.PRECIONETO * dbo.DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA) " & _
                         "- SUM(dbo.DEVOLUCIONCOMPRADETALLE.PRECIONETO * dbo.DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA) / 21 END AS NETO, " & _
                         "dbo.DEVOLUCIONCOMPRADETALLE.IVA, DEV.CODPROVEEDOR, " & _
                         "CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONCOMPRADETALLE.PRECIONETO * dbo.DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA) / 11 END AS IVA10, " & _
                         "CASE IVA WHEN 5 THEN SUM(dbo.DEVOLUCIONCOMPRADETALLE.PRECIONETO * dbo.DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA) / 21 END AS IVA5, " & _
                         "DEV.CODDEVOLUCION, " & _
                         "CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONCOMPRADETALLE.PRECIONETO * dbo.DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA) " & _
                         "END AS TOTALGRAB10, CASE IVA WHEN 5 THEN SUM(dbo.DEVOLUCIONCOMPRADETALLE.PRECIONETO * dbo.DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA) " & _
                         "END AS TOTALGRAV5 " & _
            "FROM            dbo.DEVOLUCIONCOMPRA AS DEV LEFT OUTER JOIN " & _
                         "dbo.SUCURSAL ON DEV.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN " & _
                         "dbo.PROVEEDOR ON DEV.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR INNER JOIN " & _
                         "dbo.DEVOLUCIONCOMPRADETALLE ON DEV.CODDEVOLUCION = dbo.DEVOLUCIONCOMPRADETALLE.CODDEVOLUCION LEFT OUTER JOIN " & _
                         "dbo.COMPRAS ON DEV.CODCOMPRA = dbo.COMPRAS.CODCOMPRA LEFT OUTER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON DEV.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE LEFT OUTER JOIN " & _
                         "dbo.MONEDA ON dbo.COMPRAS.CODMONEDA = dbo.MONEDA.CODMONEDA AND DEV.CODMONEDA = dbo.MONEDA.CODMONEDA " & _
            "WHERE       (dbo.DEVOLUCIONCOMPRADETALLE.IVA <> 0) "


            Dim sqlwhere As String = obtenerwhere(cmbSucursal, "SUCURSAL.DESSUCURSAL", cmbtipo2, "COMPRAS.MODALIDADPAGO", cbxCdC, "", cbxCdC, "", "Cadena Text", "Numero Text", "Cadena Text", "Cadena Text")
            If cmbProveedor.Text = "%" Then
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RCIVANCREDITOComprasTableAdapter.selectcommand.CommandText += " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.PROVEEDOR.NUMPROVEEDOR, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NOMBRE, dbo.DEVOLUCIONCOMPRADETALLE.IVA, DEV.CODPROVEEDOR, DEV.CODDEVOLUCION, dbo.COMPRAS.MODALIDADPAGO ORDER BY FECHA, NUMDEVOLUCION"
                Else
                    Me.RCIVANCREDITOComprasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.PROVEEDOR.NUMPROVEEDOR, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NOMBRE, dbo.DEVOLUCIONCOMPRADETALLE.IVA, DEV.CODPROVEEDOR, DEV.CODDEVOLUCION, dbo.COMPRAS.MODALIDADPAGO ORDER BY FECHA, NUMDEVOLUCION"
                End If
                Me.RCIVANCREDITOComprasTableAdapter.Fill(DsRCNCredito.RCIVANCREDITOCOMPRAS)

                If chbxMatricial.Checked = True Then
                    txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rptmat.SetDataSource([DsRCNCredito])
                    rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)

                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If
                    If cmbtipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "IVA Compras - Notas de Crédito")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "IVA Compras - Notas de Crédito / " + cmbtipo.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                    rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rpt.SetDataSource([DsRCNCredito])
                    rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)

                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If
                    If cmbtipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "IVA Compras - Notas de Crédito")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "IVA Compras - Notas de Crédito / " + cmbtipo.Text)
                    End If

                    rpt.SetParameterValue("pmtFDesde", FechaDesde)
                    rpt.SetParameterValue("pmtFHasta", FechaHasta)
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If

            Else ' Un Proveedor Especifico
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RCIVANCREDITOComprasTableAdapter.selectcommand.CommandText += " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') AND PROVEEDOR.CODPROVEEDOR = " & cmbProveedor.SelectedValue & " GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.PROVEEDOR.NUMPROVEEDOR, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NOMBRE, dbo.DEVOLUCIONCOMPRADETALLE.IVA, DEV.CODPROVEEDOR, DEV.CODDEVOLUCION, dbo.COMPRAS.MODALIDADPAGO ORDER BY FECHA, NUMDEVOLUCION"
                Else
                    Me.RCIVANCREDITOComprasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') AND PROVEEDOR.CODPROVEEDOR = " & cmbProveedor.SelectedValue & " GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.PROVEEDOR.NUMPROVEEDOR, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NOMBRE, dbo.DEVOLUCIONCOMPRADETALLE.IVA, DEV.CODPROVEEDOR, DEV.CODDEVOLUCION, dbo.COMPRAS.MODALIDADPAGO ORDER BY FECHA, NUMDEVOLUCION"
                End If
                Me.RCIVANCREDITOComprasTableAdapter.Fill(DsRCNCredito.RCIVANCREDITOCOMPRAS)

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRCNCredito])
                    rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
                    rptmat.SetParameterValue("pmtCliente", cmbProveedor.Text)
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If
                    If cmbtipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "IVA Compras - Notas de Crédito")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "IVA Compras - Notas de Crédito / " + cmbtipo.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                    rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    rpt.SetDataSource([DsRCNCredito])
                    rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)
                    rpt.SetParameterValue("pmtCliente", cmbProveedor.Text)
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If
                    If cmbtipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "IVA Compras - Notas de Crédito")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "IVA Compras - Notas de Crédito / " + cmbtipo.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", FechaDesde)
                    rpt.SetParameterValue("pmtFHasta", FechaHasta)
                    frm.CrystalReportViewer1.ReportSource = rpt

                End If
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptEstadoCuentaProveedor()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasEstadoCuentaProveedor
        Dim rptmat As New Reportes.ComprasEstadoCuentaProveedorMATR

        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

        If cmbProveedor.Text = "%" Then
            Me.RcMovimientosProveedorTableAdapter.FillByTProv(DsRCPagos.RCMovimientosProveedor, fechadesde2, fechahasta2)
        Else
            Me.RcMovimientosProveedorTableAdapter.Fill(DsRCPagos.RCMovimientosProveedor, cmbProveedor.SelectedValue, fechadesde2, fechahasta2)
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRCPagos])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rptmat
        Else
            rpt.SetDataSource([DsRCPagos])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        End If
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub rptListadoOC()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasListadoOC
        Dim rptmat As New Reportes.ComprasListadoOCMATR

        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

        If cmbProveedor.Text = "%" Then
            Me.ListaOrdenCompraTableAdapter1.Fill(DSReporteCompras.ListaOrdenCompra, fechadesde2, fechahasta2)
        Else
            Me.ListaOrdenCompraTableAdapter1.FillBy(DSReporteCompras.ListaOrdenCompra, fechadesde2, fechahasta2, cmbProveedor.SelectedValue)
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource(DSReporteCompras)
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtFdesde", dtpFechaDesde.Text)
            rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rptmat
        Else
            rpt.SetDataSource(DSReporteCompras)
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtFdesde", dtpFechaDesde.Text)
            rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        End If
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub rptRecibosProveedor()
        Dim frm = New VerInformes
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            'Volvemos al SelectCommand original del Table Adapter (sin las condiciones de la instancia anterior)"
            Me.RcPagosProveedorTableAdapter.selectcommand.CommandText = "SELECT dbo.MONEDA.SIMBOLO, SUM(dbo.COMPRASFORMAPAGO.IMPORTE) AS IMPORTE, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, " & _
                        "dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, " & _
                        "dbo.COMPRASFORMAPAGO.RECIBONROSERIE AS SERIE " & _
            "FROM            dbo.COMPRASFORMAPAGO INNER JOIN " & _
                         "dbo.MONEDA ON dbo.COMPRASFORMAPAGO.CODMONEDA = dbo.MONEDA.CODMONEDA INNER JOIN " & _
                         "dbo.COMPRAS ON dbo.COMPRASFORMAPAGO.CODCOMPRA = dbo.COMPRAS.CODCOMPRA INNER JOIN " & _
                         "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR " & _
            "WHERE        (dbo.COMPRASFORMAPAGO.DESTIPOPAGO <> 'Nota de Credito') AND (dbo.COMPRASFORMAPAGO.DESTIPOPAGO <> 'Nota de Crédito') "

            cmbProducto.Text = "%"
            Dim sqlwhere As String = obtenerwhere(cmbtipo2, "COMPRAS.MODALIDADPAGO", cmbProveedor, "PROVEEDOR.CODPROVEEDOR", cmbProducto, "", cmbProducto, "", "Cadena Text", "Numero SValue", "Cadena Text", "Cadena Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RcPagosProveedorTableAdapter.selectcommand.CommandText += " AND (COMPRAS.ESTADO = 1) AND (COMPRASFORMAPAGO.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (COMPRASFORMAPAGO.FECHAREGISTROPAG <= '" & fechahasta2 & "') GROUP BY dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRASFORMAPAGO.RECIBONROSERIE ORDER BY FECHAREGISTROPAG ASC"
            Else
                Me.RcPagosProveedorTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (COMPRAS.ESTADO = 1) AND (COMPRASFORMAPAGO.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (COMPRASFORMAPAGO.FECHAREGISTROPAG <= '" & fechahasta2 & "') GROUP BY dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRASFORMAPAGO.RECIBONROSERIE ORDER BY FECHAREGISTROPAG ASC"
            End If

            Me.RcPagosProveedorTableAdapter.Fill(DsRCPagos.RCPagosProveedor)
            Dim rpt As New Reportes.ComprasReciboProveedores
            Dim rptmat As New Reportes.ComprasReciboProveedoresMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                txt = rptmat.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR2")
                If cmbProveedor.Text = "%" Then
                    txt.Width = 0 ' No mostramos NUMPROVEEDOR2
                    rptmat.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtProveedor", "")
                End If

                If cmbtipo.Text = "%" Then
                    rptmat.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtTipo", cmbtipo.Text)
                End If

                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                txt = rpt.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR2")

                If cmbProveedor.Text = "%" Then
                    txt.Width = 0 ' No mostramos NUMPROVEEDOR2
                    rpt.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtProveedor", "")
                End If

                If cmbtipo.Text = "%" Then
                    rpt.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtTipo", cmbtipo.Text)
                End If

                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptRecibosProveedorDet()
        Dim frm = New VerInformes
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            'Volvemos al SelectCommand original del Table Adapter (sin las condiciones de la instancia anterior)"
            Me.RCRecibosProveedorDetTableAdapter.selectcommand.CommandText = "SELECT TOP (100) PERCENT dbo.MONEDA.SIMBOLO, SUM(dbo.COMPRASFORMAPAGO.IMPORTE) AS IMPORTE, dbo.PROVEEDOR.NUMPROVEEDOR, " & _
                        "dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRASFORMAPAGO.NRORECIBO + ' ' + ISNULL(dbo.COMPRASFORMAPAGO.RECIBONROSERIE, '') AS RECIBOSERIE, " & _
                        "dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, dbo.PROVEEDOR.NOMBRE, dbo.COMPRASFORMAPAGO.OBSERVACIONES, " & _
                        "dbo.COMPRASFORMAPAGO.CH_NROCHEQUE, dbo.COMPRASFORMAPAGO.DESTIPOPAGO, dbo.CAJA.NUMEROCAJA, dbo.BANCO.DESBANCO, " & _
                        "dbo.COMPRAS.NUMCOMPRA, CASE MODALIDADPAGO WHEN 0 THEN 'CONTADO' ELSE 'CREDITO' END AS TIPO, " & _
                        "dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.COMPRASFORMAPAGO.FECHAPAGO, " & _
                        "dbo.COMPRASFORMAPAGO.NUMDEVOLUCION, dbo.COMPRASFORMAPAGO.NUMRETENCION " & _
            "FROM            dbo.COMPRASFORMAPAGO INNER JOIN " & _
                        "dbo.MONEDA ON dbo.COMPRASFORMAPAGO.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                        "dbo.COMPRAS ON dbo.COMPRASFORMAPAGO.CODCOMPRA = dbo.COMPRAS.CODCOMPRA INNER JOIN " & _
                        "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR LEFT OUTER JOIN " & _
                        "dbo.BANCO ON dbo.COMPRASFORMAPAGO.CH_TA_TR_CODBANCO = dbo.BANCO.CODBANCO LEFT OUTER JOIN " & _
                        "dbo.aperturas ON dbo.COMPRASFORMAPAGO.id_apertura = dbo.aperturas.id_apertura LEFT OUTER JOIN " & _
                        "dbo.CAJA ON dbo.aperturas.id_caja = dbo.CAJA.NUMCAJA " & _
            "GROUP BY dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRASFORMAPAGO.NRORECIBO, " & _
                        "dbo.COMPRASFORMAPAGO.RECIBONROSERIE, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, dbo.PROVEEDOR.NOMBRE, " & _
                        "dbo.COMPRASFORMAPAGO.OBSERVACIONES, dbo.COMPRASFORMAPAGO.CH_NROCHEQUE, dbo.COMPRASFORMAPAGO.DESTIPOPAGO, dbo.CAJA.NUMEROCAJA, " & _
                        "dbo.BANCO.DESBANCO, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRAS.MODALIDADPAGO, dbo.COMPRAS.TOTALCOMPRA, " & _
                        "dbo.COMPRAS.FECHACOMPRA, dbo.COMPRASFORMAPAGO.FECHAPAGO, dbo.COMPRASFORMAPAGO.CODTIPOPAGO, " & _
                        "dbo.COMPRASFORMAPAGO.NUMDEVOLUCION, dbo.COMPRASFORMAPAGO.NUMRETENCION " & _
            "HAVING        (dbo.COMPRASFORMAPAGO.CODTIPOPAGO <> 5) "

            cmbProducto.Text = "%"
            Dim sqlwhere As String = obtenerwhere(cmbtipo2, "COMPRAS.MODALIDADPAGO", cmbProveedor, "PROVEEDOR.CODPROVEEDOR", cmbProducto, "", cmbProducto, "", "Cadena Text", "Numero SValue", "Cadena Text", "Cadena Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RCRecibosProveedorDetTableAdapter.selectcommand.CommandText += " AND (COMPRASFORMAPAGO.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (COMPRASFORMAPAGO.FECHAREGISTROPAG <= '" & fechahasta2 & "') ORDER BY dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, NOMBRE"
            Else
                Me.RCRecibosProveedorDetTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (COMPRASFORMAPAGO.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (COMPRASFORMAPAGO.FECHAREGISTROPAG <= '" & fechahasta2 & "') ORDER BY dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, NOMBRE"
            End If

            Me.RCRecibosProveedorDetTableAdapter.Fill(DsRCPagos.RCRECIBOSPROVEEDORDET)
            Dim rpt As New Reportes.ComprasRecibosDetallado
            Dim rptmat As New Reportes.ComprasRecibosDetalladoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbProveedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtProveedor", cmbProveedor.Text)
                End If

                If cmbtipo.Text = "%" Then
                    rptmat.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtTipo", cmbtipo.Text)
                End If

                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbProveedor.Text = "%" Then
                    rpt.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtProveedor", cmbProveedor.Text)
                End If

                If cmbtipo.Text = "%" Then
                    rpt.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtTipo", cmbtipo.Text)
                End If

                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptRetenciones()
        Dim frm = New VerInformes

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            'Volvemos al SelectCommand original del Table Adapter (sin las condiciones de la instancia anterior)"
            Me.RcRetencionesTableAdapter.selectcommand.CommandText = "SELECT TOP (100) PERCENT dbo.MONEDA.SIMBOLO, { fn TRUNCATE (SUM(dbo.COMPRASFORMAPAGO.IMPORTE), 0) } AS IMPORTE, dbo.PROVEEDOR.NUMPROVEEDOR, " & _
                                                                     "dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, " & _
                                                                     "dbo.COMPRASFORMAPAGO.RECIBONROSERIE AS SERIE, dbo.COMPRASFORMAPAGO.NUMRETENCION, dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRAS.TOTALIVA, " & _
                                                                     "dbo.COMPRAS.TOTALEXENTA, dbo.PROVEEDOR.RUC_CIN, dbo.COMPRAS.NUMCOMPRA " & _
                                                                     "FROM dbo.COMPRASFORMAPAGO INNER JOIN " & _
                                                                     "dbo.MONEDA ON dbo.COMPRASFORMAPAGO.CODMONEDA = dbo.MONEDA.CODMONEDA INNER JOIN " & _
                                                                     "dbo.COMPRAS ON dbo.COMPRASFORMAPAGO.CODCOMPRA = dbo.COMPRAS.CODCOMPRA INNER JOIN " & _
                                                                     "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR"

            cmbProducto.Text = "%"
            Dim sqlwhere As String = obtenerwhere(cmbtipo2, "COMPRASFORMAPAGO.CODTIPOPAGO", cmbProveedor, "PROVEEDOR.CODPROVEEDOR", cmbProducto, "", cmbProducto, "", "Cadena Text", "Numero SValue", "Cadena Text", "Cadena Text")

            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RcRetencionesTableAdapter.selectcommand.CommandText += " WHERE (COMPRASFORMAPAGO.CODTIPOPAGO = 10 OR COMPRASFORMAPAGO.CODTIPOPAGO = 6) AND (COMPRAS.ESTADO = 1) AND (COMPRASFORMAPAGO.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (COMPRASFORMAPAGO.FECHAREGISTROPAG <= '" & fechahasta2 & "') GROUP BY dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR,  dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRASFORMAPAGO.RECIBONROSERIE, dbo.COMPRASFORMAPAGO.NUMRETENCION, dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRAS.TOTALIVA, dbo.COMPRAS.TOTALEXENTA, dbo.PROVEEDOR.RUC_CIN,dbo.COMPRAS.NUMCOMPRA ORDER BY NUMRETENCION ASC"
            Else
                If cmbtipo2.Text = "%" Then
                    Me.RcRetencionesTableAdapter.selectcommand.CommandText += " WHERE (COMPRASFORMAPAGO.CODTIPOPAGO = 10 OR COMPRASFORMAPAGO.CODTIPOPAGO = 6) AND " + sqlwhere + " AND (COMPRAS.ESTADO = 1) AND (COMPRASFORMAPAGO.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (COMPRASFORMAPAGO.FECHAREGISTROPAG <= '" & fechahasta2 & "') GROUP BY dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR,  dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRASFORMAPAGO.RECIBONROSERIE, dbo.COMPRASFORMAPAGO.NUMRETENCION, dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRAS.TOTALIVA, dbo.COMPRAS.TOTALEXENTA, dbo.PROVEEDOR.RUC_CIN, dbo.COMPRAS.NUMCOMPRA ORDER BY NUMRETENCION ASC"
                Else
                    Me.RcRetencionesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (COMPRAS.ESTADO = 1) AND (COMPRASFORMAPAGO.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (COMPRASFORMAPAGO.FECHAREGISTROPAG <= '" & fechahasta2 & "') GROUP BY dbo.MONEDA.SIMBOLO, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR,  dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.FECHAREGISTROPAG, dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRASFORMAPAGO.RECIBONROSERIE, dbo.COMPRASFORMAPAGO.NUMRETENCION, dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRAS.TOTALIVA, dbo.COMPRAS.TOTALEXENTA, dbo.PROVEEDOR.RUC_CIN, dbo.COMPRAS.NUMCOMPRA ORDER BY NUMRETENCION ASC"
                End If
            End If


            Me.RcRetencionesTableAdapter.Fill(DsRCPagos.RCRetenciones)
            Dim rpt As New Reportes.ComprasRetenciones
            Dim rptmat As New Reportes.ComprasRetenciones

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbProveedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtProveedor", cmbProveedor.Text)
                End If

                If cmbtipo.Text = "%" Then
                    rptmat.SetParameterValue("pmtComprobante", "")
                ElseIf cmbtipo.Text = "IVA" Then
                    rptmat.SetParameterValue("pmtComprobante", "de IVA")
                Else
                    rptmat.SetParameterValue("pmtComprobante", "de Renta")
                End If

                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbProveedor.Text = "%" Then
                    rpt.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtProveedor", cmbProveedor.Text)
                End If

                If cmbtipo.Text = "%" Then
                    rpt.SetParameterValue("pmtComprobante", "")
                ElseIf cmbtipo.Text = "IVA" Then
                    rpt.SetParameterValue("pmtComprobante", "de IVA")
                Else
                    rpt.SetParameterValue("pmtComprobante", "de Renta")
                End If

                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptFacturasXRecibo()
        Dim frm = New VerInformes
        'Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject
        'Dim txt2 As CrystalDecisions.CrystalReports.Engine.FieldObject
        'Dim txt3 As CrystalDecisions.CrystalReports.Engine.FieldObject
        Dim rpt As New Reportes.ComprasFacturasXRecibo
        Dim rptmat As New Reportes.ComprasFacturasXReciboMATR
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            Me.RcFacturasXReciboTableAdapter.selectcommand.CommandText = "SELECT CFPORIG.CODCOMPRA, CFPORIG.IMPORTE, CASE WHEN CODTIPOPAGO = 5 AND (NRORECIBO IS NULL OR NRORECIBO = 0) THEN 'NOTA DE CREDITO' ELSE 'RECIBO' END AS DESTIPOPAGO, CFPORIG.FECHAREGISTROPAG AS FECHAPAGO, CASE WHEN CODTIPOPAGO = 5 AND (NRORECIBO IS NULL OR NRORECIBO = 0) THEN CFPORIG.NUMDEVOLUCION ELSE CFPORIG.NRORECIBO END AS NRORECIBO, " & _
                        "dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRAS.NUMCOMPRA, (SELECT SUM(IMPORTE) AS Expr1 " & _
                        "FROM dbo.COMPRASFORMAPAGO WHERE (NRORECIBO = CFPORIG.NRORECIBO) " & _
                               "GROUP BY NRORECIBO) AS TOTALRECIBO, CFPORIG.CODPAGO, dbo.COMPRAS.FECHACOMPRA, " & _
                        "CASE WHEN COMPRAS.MODALIDADPAGO = 0 THEN 'CONTADO' WHEN COMPRAS.MODALIDADPAGO = 1 THEN 'CREDITO' END AS MODALIDADPAGO, " & _
                        "dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR " & _
            "FROM            dbo.COMPRAS INNER JOIN " & _
                         "dbo.COMPRASFORMAPAGO AS CFPORIG ON dbo.COMPRAS.CODCOMPRA = CFPORIG.CODCOMPRA INNER JOIN " & _
                         "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR"

            cmbProducto.Text = "%"
            Dim sqlwhere As String = obtenerwhere(cmbtipo2, "COMPRAS.MODALIDADPAGO", cmbProveedor, "PROVEEDOR.CODPROVEEDOR", cmbProducto, "", cmbProducto, "", "Cadena Text", "Numero SValue", "Cadena Text", "Cadena Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RcFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE (COMPRAS.ESTADO = 1) AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') ORDER BY FECHACOMPRA"
            Else
                Me.RcFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (COMPRAS.ESTADO = 1) AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') ORDER BY FECHACOMPRA"
            End If

            Me.RcFacturasXReciboTableAdapter.Fill(DsRCPagos.RCFacturasXRecibo)

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])

                'txt = rptmat.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR2")
                'txt2 = rptmat.ReportDefinition.ReportObjects.Item("NOMBRE1")
                'txt3 = rptmat.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR3")

                If cmbProveedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtProveedor", "(Todos)")
                    'txt.Width = 0 ' No mostramos NUMPROVEEDOR2
                    'txt2.Width = 0 ' No mostramos NOMBRE
                    'txt3.Width = 0 ' No mostramos NUMPROVEEDOR3
                Else
                    rptmat.SetParameterValue("pmtProveedor", "") ' Se va a mostrar NUMPROVEEDOR2
                End If

                If cmbtipo.Text = "%" Then
                    rptmat.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtTipo", cmbtipo.Text)
                End If


                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)

                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])

                'txt = rpt.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR2")
                'txt2 = rpt.ReportDefinition.ReportObjects.Item("NOMBRE1")
                'txt3 = rpt.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR3")

                If cmbProveedor.Text = "%" Then
                    rpt.SetParameterValue("pmtProveedor", "(Todos)")
                    'txt.Width = 0 ' No mostramos NUMPROVEEDOR2
                    'txt2.Width = 0 ' No mostramos NOMBRE
                    'txt3.Width = 0 ' No mostramos NUMPROVEEDOR3
                Else
                    rpt.SetParameterValue("pmtProveedor", "") ' Se va a mostrar NUMPROVEEDOR2
                End If

                If cmbtipo.Text = "%" Then
                    rpt.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtTipo", cmbtipo.Text)
                End If

                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)

                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptRecibosXFactura()
        Dim frm = New VerInformes
        'Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject
        'Dim txt2 As CrystalDecisions.CrystalReports.Engine.FieldObject
        'Dim txt3 As CrystalDecisions.CrystalReports.Engine.FieldObject
        Dim rpt As New Reportes.ComprasRecibosXFactura
        Dim rptmat As New Reportes.ComprasRecibosXFacturaMATR
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            Me.RcFacturasXReciboTableAdapter.selectcommand.CommandText = "SELECT CFPORIG.CODCOMPRA, CFPORIG.IMPORTE, CASE WHEN CODTIPOPAGO = 5 AND (NRORECIBO IS NULL OR NRORECIBO = 0) THEN 'NOTA DE CREDITO' ELSE 'RECIBO' END AS DESTIPOPAGO, CFPORIG.FECHAREGISTROPAG AS FECHAPAGO, CASE WHEN CODTIPOPAGO = 5 AND (NRORECIBO IS NULL OR NRORECIBO = 0) THEN CFPORIG.NUMDEVOLUCION ELSE CFPORIG.NRORECIBO END AS NRORECIBO, " & _
                        "dbo.COMPRAS.TOTALCOMPRA, dbo.COMPRAS.NUMCOMPRA, (SELECT SUM(IMPORTE) AS Expr1 " & _
                        "FROM dbo.COMPRASFORMAPAGO WHERE (NRORECIBO = CFPORIG.NRORECIBO) " & _
                               "GROUP BY NRORECIBO) AS TOTALRECIBO, CFPORIG.CODPAGO, dbo.COMPRAS.FECHACOMPRA, " & _
                        "CASE WHEN COMPRAS.MODALIDADPAGO = 0 THEN 'CONTADO' WHEN COMPRAS.MODALIDADPAGO = 1 THEN 'CREDITO' END AS MODALIDADPAGO, " & _
                        "dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR " & _
            "FROM            dbo.COMPRAS INNER JOIN " & _
                         "dbo.COMPRASFORMAPAGO AS CFPORIG ON dbo.COMPRAS.CODCOMPRA = CFPORIG.CODCOMPRA INNER JOIN " & _
                         "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR"

            cmbProducto.Text = "%"
            Dim sqlwhere As String = obtenerwhere(cmbtipo, "CFPORIG.DESTIPOPAGO", cmbProveedor, "PROVEEDOR.CODPROVEEDOR", cmbProducto, "", cmbProducto, "", "Cadena Text", "Numero SValue", "Cadena Text", "Cadena Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RcFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE (COMPRAS.ESTADO = 1) AND (CFPORIG.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (CFPORIG.FECHAREGISTROPAG <= '" & fechahasta2 & "') ORDER BY FECHACOMPRA"
            Else
                Me.RcFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (COMPRAS.ESTADO = 1) AND (CFPORIG.FECHAREGISTROPAG >= '" & fechadesde2 & "') AND (CFPORIG.FECHAREGISTROPAG <= '" & fechahasta2 & "') ORDER BY FECHACOMPRA"
            End If

            Me.RcFacturasXReciboTableAdapter.Fill(DsRCPagos.RCFacturasXRecibo)

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])

                'txt = rptmat.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR2")
                'txt2 = rptmat.ReportDefinition.ReportObjects.Item("NOMBRE1")
                'txt3 = rptmat.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR3")

                If cmbProveedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtProveedor", "(Todos)")
                    'txt.Width = 0 ' No mostramos NUMPROVEEDOR2
                    'txt2.Width = 0 ' No mostramos NOMBRE
                    'txt3.Width = 0 ' No mostramos NUMPROVEEDOR3
                Else
                    rptmat.SetParameterValue("pmtProveedor", "") ' Se va a mostrar NUMPROVEEDOR2
                End If

                If cmbtipo.Text = "%" Then
                    rptmat.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtTipo", cmbtipo.Text)
                End If


                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)

                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])

                'txt = rpt.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR2")
                'txt2 = rpt.ReportDefinition.ReportObjects.Item("NOMBRE1")
                'txt3 = rpt.ReportDefinition.ReportObjects.Item("NUMPROVEEDOR3")

                If cmbProveedor.Text = "%" Then
                    rpt.SetParameterValue("pmtProveedor", "(Todos)")
                    'txt.Width = 0 ' No mostramos NUMPROVEEDOR2
                    'txt2.Width = 0 ' No mostramos NOMBRE
                    'txt3.Width = 0 ' No mostramos NUMPROVEEDOR3
                Else
                    rpt.SetParameterValue("pmtProveedor", "") ' Se va a mostrar NUMPROVEEDOR2
                End If

                If cmbtipo.Text = "%" Then
                    rpt.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtTipo", cmbtipo.Text)
                End If

                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)

                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptFacturasPagar()
        Dim frm = New VerInformes

        Try
            Dim fechadesde2, fechahasta2 As String
            Dim numproveedor As String

            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            If cmbProveedor.Text = "%" Then
                Me.RCFacturasAPagarTableAdapter.Fill(Me.DsRCPagos.RCFACTURASAPAGAR, fechadesde2, fechahasta2)
            Else
                Me.RCFacturasAPagarTableAdapter.FillByProv(Me.DsRCPagos.RCFACTURASAPAGAR, fechadesde2, fechahasta2, cmbProveedor.SelectedValue)
            End If

            Dim rpt As New Reportes.ComprasFacturaAPagar
            Dim rptmat As New Reportes.ComprasFacturaAPagarMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])
                If cmbProveedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    numproveedor = w.FuncionConsulta("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", cmbProveedor.SelectedValue)
                    rptmat.SetParameterValue("pmtProveedor", numproveedor)
                End If
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])
                If cmbProveedor.Text = "%" Then
                    rpt.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    numproveedor = w.FuncionConsulta("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", cmbProveedor.SelectedValue)
                    rpt.SetParameterValue("pmtProveedor", numproveedor)
                End If

                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptAnalisisSaldo()
        Dim frm = New VerInformes

        Try
            Dim fechadesde2, fechahasta2 As String
            Dim numproveedor As String

            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            If cmbProveedor.Text = "%" Then
                Me.RcAnalisisdeSaldosTableAdapter.Fill(Me.DsRCPagos.RCAnalisisdeSaldos, fechadesde2)
            Else
                Me.RcAnalisisdeSaldosTableAdapter.FillByProv(Me.DsRCPagos.RCAnalisisdeSaldos, cmbProveedor.Text, fechadesde2)
            End If

            Dim rpt As New Reportes.ComprasAnalisisdeSaldos
            Dim rptmat As New Reportes.ComprasAnalisisdeSaldos

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])
                If cmbProveedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    numproveedor = w.FuncionConsulta("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", cmbProveedor.SelectedValue)
                    rptmat.SetParameterValue("pmtProveedor", numproveedor)
                End If
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtRangoFecha", "Hasta el " + dtpFechaDesde.Text)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])
                If cmbProveedor.Text = "%" Then
                    rpt.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    numproveedor = w.FuncionConsulta("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", cmbProveedor.SelectedValue)
                    rpt.SetParameterValue("pmtProveedor", numproveedor)
                End If

                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtRangoFecha", "Hasta el " + dtpFechaDesde.Text)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptPendientesPago()
        Dim frm = New VerInformes

        Try
            Dim dt As DataTable
            Dim fechadesde2, fechahasta2 As String
            Dim numproveedor As String

            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"
            Dim sicheques As Boolean = False
            If cmbProveedor.Text = "%" Then
                Me.RcchdifTableAdapter.Fill(DsRCPagos.RCCHDIF, fechadesde2, fechahasta2)
                Try
                    dt = RcchdifTableAdapter.GetData(fechadesde2, fechahasta2)
                    sicheques = True
                Catch ex As Exception
                    sicheques = False
                End Try
                Me.RcPendientePagoDifTableAdapter.FillOByNombre(Me.DsRCPagos.RCPendientePagoDif, fechadesde2, fechahasta2)
            Else
                Me.RcchdifTableAdapter.FillByProveedor(DsRCPagos.RCCHDIF, cmbProveedor.SelectedValue, fechadesde2, fechahasta2)
                Try
                    dt = RcchdifTableAdapter.GetDataByProveedor(cmbProveedor.SelectedValue, fechadesde2, fechahasta2)
                    sicheques = True
                Catch ex As Exception
                    sicheques = False
                End Try
                Me.RcPendientePagoDifTableAdapter.FillByProvOByNombre(Me.DsRCPagos.RCPendientePagoDif, cmbProveedor.SelectedValue, fechadesde2, fechahasta2)
            End If

            Dim rpt As New Reportes.ComprasFacturasPendientePago
            Dim rptmat As New Reportes.ComprasFacturasPendientePagoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])
                If cmbProveedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    numproveedor = w.FuncionConsulta("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", cmbProveedor.SelectedValue)
                    rptmat.SetParameterValue("pmtProveedor", numproveedor)
                End If
                If sicheques = False Then
                    rptmat.SetParameterValue("pmtChequesDif", "No hay Cheques Diferidos para mostrar")
                Else
                    rptmat.SetParameterValue("pmtChequesDif", "Cheques Diferidos")
                End If
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])
                If cmbProveedor.Text = "%" Then
                    rpt.SetParameterValue("pmtProveedor", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    numproveedor = w.FuncionConsulta("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", cmbProveedor.SelectedValue)
                    rpt.SetParameterValue("pmtProveedor", numproveedor)
                End If

                If sicheques = False Then
                    rpt.SetParameterValue("pmtChequesDif", "No hay Cheques Diferidos para mostrar")
                Else
                    rpt.SetParameterValue("pmtChequesDif", "Cheques Diferidos")
                End If
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptConsultaCompras()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasComprCompras
        Dim rptmat As New Reportes.ComprasComprComprasMATR

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            'Acortamos para incluir Where"
            Me.ComprasAprobadasTableAdapter.selectcommand.CommandText = "SELECT SUM(COMPRASDETALLE.CANTIDADCOMPRA) AS CANTIDAD, (SELECT SUM(TOTALCOMPRA) AS Expr1 FROM dbo.COMPRAS WHERE (CODCOMPRA IN (SELECT DISTINCT CODCOMPRA FROM dbo.COMPRAS AS COMPRAS_1 where CONVERT(DATE, COMPRAS_1.FECHACOMPRA, 103)=CONVERT(DATE, COMPRAS.FECHACOMPRA, 103)))) AS TOTALGS, " & _
                         "CONVERT(DATE, COMPRAS.FECHACOMPRA, 103) AS FECHA, SUM(COMPRASDETALLE.IMPORTEGRAVADO10) AS GRAV10, " & _
                         "SUM(COMPRASDETALLE.IMPORTEGRAVADO5) AS GRAV5 " & _
            "FROM            COMPRASDETALLE INNER JOIN " & _
                         "COMPRAS ON COMPRASDETALLE.CODCOMPRA = COMPRAS.CODCOMPRA INNER JOIN " & _
                         "SUCURSAL ON COMPRAS.CODDEPOSITO = SUCURSAL.CODSUCURSAL INNER JOIN " & _
                         "PROVEEDOR ON COMPRAS.CODPROVEEDOR = PROVEEDOR.CODPROVEEDOR "


            Dim sqlwhere As String = obtenerwhere(cmbSucursal, "SUCURSAL.DESSUCURSAL", cmbtipo2, "COMPRAS.MODALIDADPAGO", cbxCdC, "", cbxCdC, "", "Cadena Text", "Numero Text", "Cadena Text", "Cadena Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.ComprasAprobadasTableAdapter.selectcommand.CommandText += " WHERE (COMPRAS.ESTADO = 1) AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY CONVERT(DATE, COMPRAS.FECHACOMPRA, 103) ORDER BY FECHA"
            Else
                Me.ComprasAprobadasTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (COMPRAS.ESTADO = 1) AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY CONVERT(DATE, COMPRAS.FECHACOMPRA, 103) ORDER BY FECHA"
            End If
            Me.ComprasAprobadasTableAdapter.Fill(DSReporteCompras.ComprasAprobadas)

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DSReporteCompras])
                rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbtipo.Text = "%" Then
                    rptmat.SetParameterValue("pmtComprobante", "Compras por Periodo")
                Else
                    rptmat.SetParameterValue("pmtComprobante", "Compras por Periodo / " + cmbtipo.Text)
                End If

                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DSReporteCompras])
                rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)

                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbtipo.Text = "%" Then
                    rpt.SetParameterValue("pmtComprobante", "Compras por Periodo")
                Else
                    rpt.SetParameterValue("pmtComprobante", "Compras por Periodo / " + cmbtipo.Text)
                End If

                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptComprasPrecioPorProductoPorProveedor()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasPrecioPorProductoPorProveedor
        Dim rptmat As New Reportes.ComprasPrecioPorProductoPorProveedorMATR

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            'Acortamos para incluir Where"
            Me.RcProductosPorProveedorTableAdapter.selectcommand.CommandText = "SELECT        CODIGOS.CODCODIGO, CODIGOS.CODIGO, PROVEEDOR.NOMBRE, COMPRAS.NUMCOMPRA, SUM(COMPRASDETALLE.CANTIDADCOMPRA) AS CANTIDAD, " & _
                         "AVG(COMPRASDETALLE.COSTOUNITARIO) AS COSTO, CASE IVA WHEN 10 THEN AVG(COMPRASDETALLE.COSTOUNITARIO) " & _
                         "- AVG(COMPRASDETALLE.COSTOUNITARIO) / 11 WHEN 5 THEN AVG(COMPRASDETALLE.COSTOUNITARIO) - AVG(COMPRASDETALLE.COSTOUNITARIO) " & _
                         "/ 21 ELSE AVG(COMPRASDETALLE.COSTOUNITARIO) END AS COSTOSINIVA, CASE IVA WHEN 0 THEN 'Ex' ELSE '' END AS EXENTA, " & _
                         "COMPRAS.FECHACOMPRA, PRODUCTOS.DESPRODUCTO, PROVEEDOR.NUMPROVEEDOR " & _
            "FROM            COMPRASDETALLE INNER JOIN " & _
                         "COMPRAS ON COMPRASDETALLE.CODCOMPRA = COMPRAS.CODCOMPRA INNER JOIN " & _
                         "CODIGOS ON COMPRASDETALLE.CODCODIGO = CODIGOS.CODCODIGO INNER JOIN " & _
                         "PRODUCTOS ON CODIGOS.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                         "PROVEEDOR ON COMPRAS.CODPROVEEDOR = PROVEEDOR.CODPROVEEDOR LEFT OUTER JOIN " & _
                         "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                         "LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA LEFT OUTER JOIN " & _
                         "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO "
            cbxCdC.Text = "%"
            Dim sqlwhere As String = obtenerwhere(cbxCategoria, "FAMILIA.DESFAMILIA", cbxLinea, "LINEA.DESLINEA", cbxRubro, "RUBRO.DESRUBRO", cbxCdC, "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                If chbxCodigosProductos.Checked = True Then
                    Me.RcProductosPorProveedorTableAdapter.selectcommand.CommandText += " WHERE (COMPRAS.ESTADO = 1) and (CODIGOS.CODIGO IN (SELECT item FROM dbo.fnPartir('" & tbxCodigosProductos.Text & "', ',') AS fnPartir_1)) AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.PRODUCTOS.DESPRODUCTO, dbo.PROVEEDOR.NUMPROVEEDOR, COMPRASDETALLE.IVA ORDER BY FECHACOMPRA DESC"
                ElseIf cmbProducto.Text = "%" Then
                    Me.RcProductosPorProveedorTableAdapter.selectcommand.CommandText += " WHERE (COMPRAS.ESTADO = 1) AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.PRODUCTOS.DESPRODUCTO, dbo.PROVEEDOR.NUMPROVEEDOR, COMPRASDETALLE.IVA ORDER BY FECHACOMPRA DESC"
                Else
                    Me.RcProductosPorProveedorTableAdapter.selectcommand.CommandText += " WHERE (COMPRAS.ESTADO = 1) AND  dbo.PRODUCTOS.CODPRODUCTO=" & cmbProducto.SelectedValue & " AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.PRODUCTOS.DESPRODUCTO, dbo.PROVEEDOR.NUMPROVEEDOR, COMPRASDETALLE.IVA ORDER BY FECHACOMPRA DESC"
                End If
            Else

                If chbxCodigosProductos.Checked = True Then
                    Me.RcProductosPorProveedorTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (COMPRAS.ESTADO = 1) and (CODIGOS.CODIGO IN (SELECT item FROM dbo.fnPartir('" & tbxCodigosProductos.Text & "', ',') AS fnPartir_1)) AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.PRODUCTOS.DESPRODUCTO, dbo.PROVEEDOR.NUMPROVEEDOR, COMPRASDETALLE.IVA ORDER BY FECHACOMPRA DESC"
                ElseIf cmbProveedor.Text = "%" Then
                    Me.RcProductosPorProveedorTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (COMPRAS.ESTADO = 1) AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.PRODUCTOS.DESPRODUCTO, dbo.PROVEEDOR.NUMPROVEEDOR, COMPRASDETALLE.IVA ORDER BY FECHACOMPRA DESC"
                Else
                    Me.RcProductosPorProveedorTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (COMPRAS.ESTADO = 1) AND  dbo.PRODUCTOS.CODPRODUCTO=" & cmbProducto.SelectedValue & " AND (COMPRAS.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMPRAS.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.CODPROVEEDOR, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.PRODUCTOS.DESPRODUCTO, dbo.PROVEEDOR.NUMPROVEEDOR, COMPRASDETALLE.IVA ORDER BY FECHACOMPRA DESC"
                End If
            End If

            Me.RcProductosPorProveedorTableAdapter.Fill(DsRCCompras.RCProductosPorProveedor)

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource(DsRCCompras)
                rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)

                If cmbProducto.Text = "%" Then
                    rptmat.SetParameterValue("pmtProducto", "Todos")
                Else
                    rptmat.SetParameterValue("pmtProducto", cmbProducto.Text)
                End If

                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource(DsRCCompras)
                rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)

                If cmbProveedor.Text = "%" Then
                    rpt.SetParameterValue("pmtProducto", "Todos")
                Else
                    rpt.SetParameterValue("pmtProducto", cmbProveedor.Text)
                End If

                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptComprasLista()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasComprasDetallado
        Dim rptmat As New Reportes.ComprasComprasDetalladoMATR
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            'Acortamos para incluir Where"
            Me.RCOMPRASLISTATableAdapter.selectcommand.CommandText = "SELECT TOP (100) PERCENT COMP.FECHACOMPRA AS FECHA, CASE COMP.MODALIDADPAGO WHEN 0 THEN 'CONTADO' WHEN 1 THEN 'CREDITO' END AS TIPO, " & _
                         "SUBSTRING(COMP.NUMCOMPRA, LEN(COMP.NUMCOMPRA) - 5, 6) AS NUMCOMPRA, PROVEEDOR.NUMPROVEEDOR, PROVEEDOR.NOMBRE, MONEDA.SIMBOLO, " & _
                         "COMP.CODPROVEEDOR, CASE WHEN " & _
                         "(SELECT COUNT(CODCOMPRA) FROM dbo.COMPRASDETALLE AS CD " & _
            "WHERE        (CD.CODCOMPRA = COMP.CODCOMPRA) AND (IVA = 10)) = " & _
            "(SELECT COUNT(CODCOMPRA) FROM dbo.COMPRASDETALLE AS CD " & _
            "WHERE        (CD.CODCOMPRA = COMP.CODCOMPRA)) THEN TOTALCOMPRA / 11 ELSE SUM(dbo.COMPRASDETALLE.IMPORTEGRAVADO10) / 11 END AS IVA10, " & _
            "CASE WHEN (SELECT COUNT(CODCOMPRA) FROM dbo.COMPRASDETALLE AS CD " & _
            "WHERE        (CD.CODCOMPRA = COMP.CODCOMPRA) AND (IVA = 5)) = (SELECT COUNT(CODCOMPRA) FROM dbo.COMPRASDETALLE AS CD " & _
            "WHERE        (CD.CODCOMPRA = COMP.CODCOMPRA)) THEN TOTALCOMPRA / 21 ELSE SUM(dbo.COMPRASDETALLE.IMPORTEGRAVADO5) / 21 END AS IVA5, " & _
            "COMP.CODCOMPRA, CASE WHEN (SELECT COUNT(CODCOMPRA) FROM dbo.COMPRASDETALLE AS CD " & _
            "WHERE        (CD.CODCOMPRA = COMP.CODCOMPRA) AND (IVA = 10)) = (SELECT COUNT(CODCOMPRA) FROM dbo.COMPRASDETALLE AS CD " & _
            "WHERE        (CD.CODCOMPRA = COMP.CODCOMPRA)) THEN TOTALCOMPRA ELSE SUM(dbo.COMPRASDETALLE.IMPORTEGRAVADO10) END AS TOTALGRAB10, " & _
            "CASE WHEN (SELECT COUNT(CODCOMPRA) FROM  dbo.COMPRASDETALLE AS CD " & _
            "WHERE        (CD.CODCOMPRA = COMP.CODCOMPRA) AND (IVA = 5)) = (SELECT COUNT(CODCOMPRA) FROM dbo.COMPRASDETALLE AS CD " & _
            "WHERE        (CD.CODCOMPRA = COMP.CODCOMPRA)) THEN TOTALCOMPRA  ELSE SUM(dbo.COMPRASDETALLE.IMPORTEGRAVADO5) END AS TOTALGRAV5, COMP.TOTALCOMPRA " & _
            "FROM            COMPRAS AS COMP LEFT OUTER JOIN " & _
                         "SUCURSAL ON COMP.CODSUCURSAL = SUCURSAL.CODSUCURSAL INNER JOIN " & _
                         "PROVEEDOR ON COMP.CODPROVEEDOR = PROVEEDOR.CODPROVEEDOR INNER JOIN " & _
                         "COMPRASDETALLE ON COMP.CODCOMPRA = COMPRASDETALLE.CODCOMPRA LEFT OUTER JOIN " & _
                         "MONEDA ON COMP.CODMONEDA = MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                         "TIPOCOMPROBANTE ON COMP.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE"

            Dim sqlwhere As String = obtenerwhere(cmbSucursal, "SUCURSAL.DESSUCURSAL", cmbtipo2, "COMP.MODALIDADPAGO", cmbComprobante, "TIPOCOMPROBANTE.DESCOMPROBANTE", cbxCdC, "", "Cadena Text", "Numero Text", "Cadena Text", "Cadena Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RCOMPRASLISTATableAdapter.selectcommand.CommandText += " WHERE (COMP.ESTADO = 1) AND (COMP.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMP.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY COMP.FECHACOMPRA, COMP.NUMCOMPRA, PROVEEDOR.NUMPROVEEDOR, COMP.COTIZACION1, MONEDA.SIMBOLO, PROVEEDOR.NOMBRE, COMP.MODALIDADPAGO, COMP.CODPROVEEDOR, COMP.CODCOMPRA, COMP.TOTALCOMPRA ORDER BY FECHA, NUMCOMPRA"
            Else
                Me.RCOMPRASLISTATableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (COMP.ESTADO = 1) AND (COMP.FECHACOMPRA >= '" & fechadesde2 & "') AND (COMP.FECHACOMPRA <= '" & fechahasta2 & "') GROUP BY COMP.FECHACOMPRA, COMP.NUMCOMPRA, PROVEEDOR.NUMPROVEEDOR, COMP.COTIZACION1, MONEDA.SIMBOLO, PROVEEDOR.NOMBRE, COMP.MODALIDADPAGO, COMP.CODPROVEEDOR, COMP.CODCOMPRA, COMP.TOTALCOMPRA ORDER BY FECHA, NUMCOMPRA"
            End If
            Me.RCOMPRASLISTATableAdapter.Fill(DsRCPagos.RCCOMPRASLISTA)

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRCPagos])
                rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
                rptmat.SetParameterValue("pmtCliente", cmbProveedor.Text)
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbComprobante.Text = "%" Then
                    If cmbtipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "Compras Lista")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "Compras Lista / " + cmbtipo.Text)
                    End If
                Else
                    If cmbtipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "Compras Lista / " + cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "Compras Lista / " + cmbComprobante.Text + " " + cmbtipo.Text)
                    End If
                End If

                rptmat.SetParameterValue("pmtFDesde", FechaDesde)
                rptmat.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRCPagos])
                rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)
                rpt.SetParameterValue("pmtCliente", cmbProveedor.Text)
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos los Depósitos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbComprobante.Text = "%" Then
                    If cmbtipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "Compras Lista")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "Compras Lista / " + cmbtipo.Text)
                    End If
                Else
                    If cmbtipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "Compras Lista / " + cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", "Compras Lista / " + cmbComprobante.Text + " " + cmbtipo.Text)
                    End If
                End If

                rpt.SetParameterValue("pmtFDesde", FechaDesde)
                rpt.SetParameterValue("pmtFHasta", FechaHasta)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmCompraProducto()
        If rbConIva.Checked = True Then
            If chbxCodigosProductos.Checked = False Then
                If cbxCategoria.Text = "%" Then
                    Me.ComprasPorProductoTableAdapter.FillByProd(DSReporteCompras.ComprasPorProducto, cmbProducto.Text, FechaDesde, FechaHasta)
                Else
                    Me.ComprasPorProductoTableAdapter.FillByFam(DSReporteCompras.ComprasPorProducto, cbxCategoria.Text, FechaDesde, FechaHasta)
                End If
            Else
                Me.ComprasPorProductoTableAdapter.FillByPlan(DSReporteCompras.ComprasPorProducto, FechaDesde, FechaHasta, tbxCodigosProductos.Text)
            End If
        Else
            If chbxCodigosProductos.Checked = False Then
                If cbxCategoria.Text = "%" Then
                    Me.ComprasPorProductoTableAdapter.FillByProdSINIVA(DSReporteCompras.ComprasPorProducto, cmbProducto.Text, FechaDesde, FechaHasta)
                Else
                    Me.ComprasPorProductoTableAdapter.FillByFamSINIVA(DSReporteCompras.ComprasPorProducto, cbxCategoria.Text, FechaDesde, FechaHasta)
                End If
            Else
                Me.ComprasPorProductoTableAdapter.FillByPlanSINIVA(DSReporteCompras.ComprasPorProducto, FechaDesde, FechaHasta, tbxCodigosProductos.Text)
            End If
        End If
        

        Dim frm = New VerInformes
        If rbSinAgrup.Checked = True Then
            Dim rpt As New Reportes.CompraPorProducto
            rpt.SetDataSource([DSReporteCompras])
            If rbConIva.Checked = True Then
                rpt.SetParameterValue("pmtIva", "Si")
            Else
                rpt.SetParameterValue("pmtIva", "No")
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        Else
            Dim rpt As New Reportes.CompraPorProductoAFam
            rpt.SetDataSource([DSReporteCompras])
            If rbConIva.Checked = True Then
                rpt.SetParameterValue("pmtIva", "Si")
            Else
                rpt.SetParameterValue("pmtIva", "No")
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        End If
        frm.WindowState = FormWindowState.Maximized
        frm.Show()

    End Sub

    Private Sub rptPendienteProveedor()
        Try
            Dim frm = New VerInformes
            Dim rpt As New Reportes.CompraPendientePorProveedor

            Me.ComprasPendienteProveedorTableAdapter.Fill(DSReporteCompras.ComprasPendienteProveedor, cmbProveedor.Text, FechaDesde, FechaHasta)
            Me.COMPRASDETALLETableAdapter.Fill(DSReporteCompras.COMPRASDETALLE)
            rpt.SetDataSource([DSReporteCompras])
            'rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            'rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptCompraCentroCosto()
        If rbtndia.Checked = True Then
            Dim frm = New VerInformes
            Dim rpt As New Reportes.CompraGastosCentroCostoDia

            Me.ComprasPorSucursalTableAdapter.FillBy(DSReporteCompras.ComprasPorSucursal, FechaDesde, FechaHasta, cbxCdC.Text)
            rpt.SetDataSource([DSReporteCompras])
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        ElseIf rbtnsemana.Checked = True Then
            Dim frm = New VerInformes
            Dim rpt As New Reportes.CompraGastosCentroCostoSemanal

            Me.ComprasPorSucursalTableAdapter.FillBy(DSReporteCompras.ComprasPorSucursal, FechaDesde, FechaHasta, cbxCdC.Text)
            rpt.SetDataSource([DSReporteCompras])
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        ElseIf rbtnQuincena.Checked = True Then
            Dim frm = New VerInformes
            Dim rpt As New Reportes.CompraGastosCentroCostoQuincenal

            Me.ComprasPorSucursalTableAdapter.FillBy(DSReporteCompras.ComprasPorSucursal, FechaDesde, FechaHasta, cbxCdC.Text)
            rpt.SetDataSource([DSReporteCompras])
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        ElseIf rbtnMes.Checked = True Then
            Dim frm = New VerInformes
            Dim rpt As New Reportes.CompraGastosCentroCostoMensual

            Me.ComprasPorSucursalTableAdapter.FillBy(DSReporteCompras.ComprasPorSucursal, FechaDesde, FechaHasta, cbxCdC.Text)
            rpt.SetDataSource([DSReporteCompras])
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        ElseIf rbtnSemestre.Checked = True Then
            Dim frm = New VerInformes
            Dim rpt As New Reportes.CompraGastosCentroCostoSemestral

            Me.ComprasPorSucursalTableAdapter.FillBy(DSReporteCompras.ComprasPorSucursal, FechaDesde, FechaHasta, cbxCdC.Text)
            rpt.SetDataSource([DSReporteCompras])
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else : rbtnAño.Checked = True
            Dim frm = New VerInformes
            Dim rpt As New Reportes.CompraGastosCentroCostoAnual

            Me.ComprasPorSucursalTableAdapter.FillBy(DSReporteCompras.ComprasPorSucursal, FechaDesde, FechaHasta, cbxCdC.Text)
            rpt.SetDataSource([DSReporteCompras])
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()

        End If
    End Sub
    'PARA EL INFORME DETALLADO POR CENTRO DE COSTOS
    Private Sub rptCompraCentroCostoDetalle()

        Dim frm = New VerInformes
        Dim rpt As New Reportes.CentroCostoDetallado

        Me.CentroDetalladoTableAdapter.Fill(DsDetalleCentro.CentroDetallado, FechaDesde, FechaHasta, cmbSucursal.Text, cbxCdC.Text)
        rpt.SetDataSource(DsDetalleCentro)

        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub rptCompraSucursal()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.CompraPorSucursalDia

        Me.ComprasPorSucursalTableAdapter.Fill(DSReporteCompras.ComprasPorSucursal, FechaDesde, FechaHasta, cmbSucursal.Text, cbxCdC.Text)
        rpt.SetDataSource([DSReporteCompras])
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub rptListaProveedor()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.CompraListaProveedor
        Dim rptmat As New Reportes.CompraListaProveedorMATR

        Me.ListaProveedorTableAdapter.Fill(DSReporteCompras.ListaProveedor)
        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DSReporteCompras])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            frm.CrystalReportViewer1.ReportSource = rptmat
        Else
            rpt.SetDataSource([DSReporteCompras])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            frm.CrystalReportViewer1.ReportSource = rpt
        End If
        
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
    Private Sub rptDiarioCajaDet()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.CompraDiarioCaja

        Me.CompraDiarioCajaTableAdapter.Fill(DSReporteCompras.CompraDiarioCaja, FechaDesde, cmbCaja.Text, FechaHasta, cmbSucursal.Text, cmbMoneda.Text)
        Me.COMPRASDETALLETableAdapter.Fill(DSReporteCompras.COMPRASDETALLE)
        rpt.SetDataSource([DSReporteCompras])
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub rptDiarioCajaResum()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.CompraDiarioCajaResumen

        Me.DiarioCajaResumenTableAdapter.Fill(DSReporteCompras.DiarioCajaResumen, cmbSucursal.Text, cmbMoneda.Text, FechaDesde, FechaHasta)
        Me.COMPRASDETALLETableAdapter.Fill(DSReporteCompras.COMPRASDETALLE)
        rpt.SetDataSource([DSReporteCompras])
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub rptFacturasCobrar()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.CompraFacturaAPagar

        Me.FacturaAPagarTableAdapter.Fill(DSReporteCompras.FacturaAPagar, cmbProveedor.Text)
        Me.COMPRASDETALLETableAdapter.Fill(DSReporteCompras.COMPRASDETALLE)
        rpt.SetDataSource([DSReporteCompras])
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Sub rptCuentaCorrienteProveedor()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.CompraCuentaCorrienteProveedor
        Me.CuentaCorrienteProveedorTableAdapter.Fill(DSReporteCompras.CuentaCorrienteProveedor, FechaDesde, FechaHasta, cmbProveedor.Text)
        rpt.SetDataSource([DSReporteCompras])
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Sub rptComprasVsListaPrecioUltimaCompra()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasPreciosDeCompraUltimaCompra
        Me.GastosPorProductoTableAdapter.Fill(DSReporteCompras.GastosPorProducto, FechaDesde, cmbProducto.Text, FechaHasta)
        Me.ListaPrecioTableAdapter.Fill(DSReporteCompras.ListaPrecio)
        Me.COSTOFIJOTableAdapter.Fill(DSReporteCompras.COSTOFIJO, FechaDesde, FechaHasta)
        Me.CostoFijoCAntidadVentaTableAdapter.Fill(DSReporteCompras.CostoFijoCAntidadVenta, FechaDesde, FechaHasta)
        Me.UltimaCompraDiasTableAdapter.Fill(DSReporteCompras.UltimaCompraDias)
        rpt.SetDataSource([DSReporteCompras])
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Sub rptComprasVsListaPrecioSinCF()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasVsListaPrecioSinCF
        Me.GastosPorProductoTableAdapter.Fill(DSReporteCompras.GastosPorProducto, FechaDesde, cmbProducto.Text, FechaHasta)
        Me.CostoFijoCAntidadVentaTableAdapter.Fill(DSReporteCompras.CostoFijoCAntidadVenta, FechaDesde, FechaHasta)
        Me.ListaPrecioTableAdapter.Fill(DSReporteCompras.ListaPrecio)
        rpt.SetDataSource([DSReporteCompras])
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
    Sub rptCostoFijoListaPrecio()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasVsListaPrecio
        Me.GastosPorProductoTableAdapter.Fill(DSReporteCompras.GastosPorProducto, FechaDesde, cmbProducto.Text, FechaHasta)
        Me.COSTOFIJOTableAdapter.Fill(DSReporteCompras.COSTOFIJO, FechaDesde, FechaHasta)
        Me.CostoFijoCAntidadVentaTableAdapter.Fill(DSReporteCompras.CostoFijoCAntidadVenta, FechaDesde, FechaHasta)
        Me.ListaPrecioTableAdapter.Fill(DSReporteCompras.ListaPrecio)
        rpt.SetDataSource([DSReporteCompras])
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
    Sub rptCostoFijo()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasCostoFijo
        Me.GastosPorProductoTableAdapter.Fill(DSReporteCompras.GastosPorProducto, FechaDesde, cmbProducto.Text, FechaHasta)
        Me.COSTOFIJOTableAdapter.Fill(DSReporteCompras.COSTOFIJO, FechaDesde, FechaHasta)
        Me.CostoFijoCAntidadVentaTableAdapter.Fill(DSReporteCompras.CostoFijoCAntidadVenta, FechaDesde, FechaHasta)
        rpt.SetDataSource([DSReporteCompras])
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Sub rptCOGSDetallado()
        Dim frm = New VerInformes
        If rbConIva.Checked = True Then
            If chbxCodigosProductos.Checked = True Then
                Me.COGSDetalladoTableAdapter.FillByPlan(DSReporteCompras.COGSDetallado, FechaDesde, FechaHasta, tbxCodigosProductos.Text)
            ElseIf cbxCategoria.Text = "%" Then
                Me.COGSDetalladoTableAdapter.FillByFam(DSReporteCompras.COGSDetallado, FechaDesde, FechaHasta, cbxCategoria.Text)
            Else
                Me.COGSDetalladoTableAdapter.Fill(DSReporteCompras.COGSDetallado, FechaDesde, FechaHasta, cmbProducto.Text)
            End If
        Else
            If chbxCodigosProductos.Checked = True Then
                Me.COGSDetalladoTableAdapter.FillByPlanSINIVA(DSReporteCompras.COGSDetallado, FechaDesde, FechaHasta, tbxCodigosProductos.Text)
            ElseIf cbxCategoria.Text = "%" Then
                Me.COGSDetalladoTableAdapter.FillByFamSINIVA(DSReporteCompras.COGSDetallado, FechaDesde, FechaHasta, cbxCategoria.Text)
            Else
                Me.COGSDetalladoTableAdapter.FillSINIVA(DSReporteCompras.COGSDetallado, FechaDesde, FechaHasta, cmbProducto.Text)
            End If
        End If

        If rbAgrupFamillia.Checked = True Then
            Dim rpt As New Reportes.ComprasCostoPromedioDetalladoAFam
            rpt.SetDataSource([DSReporteCompras])
            If rbConIva.Checked = True Then
                rpt.SetParameterValue("pmtIva", "Si")
            Else
                rpt.SetParameterValue("pmtIva", "No")
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        Else
            Dim rpt As New Reportes.ComprasCostoPromedioDetallado
            rpt.SetDataSource([DSReporteCompras])
            If rbConIva.Checked = True Then
                rpt.SetParameterValue("pmtIva", "Si")
            Else
                rpt.SetParameterValue("pmtIva", "No")
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        End If
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Sub rptComprasCostoPromedio()
        Dim frm = New VerInformes
        If rbConIva.Checked = True Then
            If chbxCodigosProductos.Checked = True Then
                Me.ComprasCOGsPromedioTableAdapter.FillByPlan(DSReporteCompras.ComprasCOGsPromedio, FechaDesde, FechaHasta, tbxCodigosProductos.Text)
            ElseIf cbxCategoria.Text = "%" Then
                Me.ComprasCOGsPromedioTableAdapter.Fill(DSReporteCompras.ComprasCOGsPromedio, cmbProducto.Text, FechaDesde, FechaHasta)
            Else
                Me.ComprasCOGsPromedioTableAdapter.FillByFam(DSReporteCompras.ComprasCOGsPromedio, cbxCategoria.Text, FechaDesde, FechaHasta)
            End If
        Else
            If chbxCodigosProductos.Checked = True Then
                Me.ComprasCOGsPromedioTableAdapter.FillByPlanSINIVA(DSReporteCompras.ComprasCOGsPromedio, FechaDesde, FechaHasta, tbxCodigosProductos.Text)
            ElseIf cbxCategoria.Text = "%" Then
                Me.ComprasCOGsPromedioTableAdapter.FillSINIVA(DSReporteCompras.ComprasCOGsPromedio, cmbProducto.Text, FechaDesde, FechaHasta)
            Else
                Me.ComprasCOGsPromedioTableAdapter.FillByFamSINIVA(DSReporteCompras.ComprasCOGsPromedio, cbxCategoria.Text, FechaDesde, FechaHasta)
            End If
        End If

        If rbAgrupFamillia.Checked = True Then
            Dim rpt As New Reportes.ComprasCostoPromedioGeneralAFam
            rpt.SetDataSource([DSReporteCompras])
            
            If rbConIva.Checked = True Then
                rpt.SetParameterValue("pmtIva", "Si")
            Else
                rpt.SetParameterValue("pmtIva", "No")
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        Else
            Dim rpt As New Reportes.ComprasCostoPromedioGeneral
            rpt.SetDataSource([DSReporteCompras])
            If rbConIva.Checked = True Then
                rpt.SetParameterValue("pmtIva", "Si")
            Else
                rpt.SetParameterValue("pmtIva", "No")
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        End If

        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Sub rptUltimaCompraDias()
        Try
            Dim frm = New VerInformes

        If rbConIva.Checked = True Then
            If chbxCodigosProductos.Checked = True Then
                Me.GastosPorProductoTableAdapter.FillByPlan(DSReporteCompras.GastosPorProducto, FechaDesde, FechaHasta, tbxCodigosProductos.Text)
            ElseIf cbxCategoria.Text = "%" Then
                Me.GastosPorProductoTableAdapter.Fill(DSReporteCompras.GastosPorProducto, FechaDesde, cmbProducto.Text, FechaHasta)
            Else
                Me.GastosPorProductoTableAdapter.FillByFam(DSReporteCompras.GastosPorProducto, FechaDesde, FechaHasta, cbxCategoria.Text)
            End If
        Else
            If chbxCodigosProductos.Checked = True Then
                Me.GastosPorProductoTableAdapter.FillByPlanSINIVA(DSReporteCompras.GastosPorProducto, FechaDesde, FechaHasta, tbxCodigosProductos.Text)
            ElseIf cbxCategoria.Text = "%" Then
                Me.GastosPorProductoTableAdapter.FillSINIVA(DSReporteCompras.GastosPorProducto, FechaDesde, cmbProducto.Text, FechaHasta)
            Else
                Me.GastosPorProductoTableAdapter.FillByFamSINIVA(DSReporteCompras.GastosPorProducto, FechaDesde, FechaHasta, cbxCategoria.Text)
            End If
        End If

        Me.UltimaCompraDiasTableAdapter.Fill(DSReporteCompras.UltimaCompraDias)
        If rbAgrupFamillia.Checked = True Then
            Dim rpt As New Reportes.ComprasPreciosDeCompraUltimaCompraAFam
            rpt.SetDataSource([DSReporteCompras])
            If rbConIva.Checked = True Then
                rpt.SetParameterValue("pmtIVA", "Si")
            Else
                rpt.SetParameterValue("pmtIVA", "No")
            End If
            rpt.SetParameterValue("pmtRangoFecha", "Fecha Al " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        Else
            Dim rpt As New Reportes.ComprasPreciosDeCompraUltimaCompra
            rpt.SetDataSource([DSReporteCompras])
            If rbConIva.Checked = True Then
                rpt.SetParameterValue("pmtIVA", "Si")
            Else
                rpt.SetParameterValue("pmtIVA", "No")
            End If
            rpt.SetParameterValue("pmtRangoFecha", "Fecha Al " + dtpFechaHasta.Text)
            frm.CrystalReportViewer1.ReportSource = rpt
        End If

        frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub
    
       
    Private Sub rptCostoFifo()
        Dim frm = New VerInformes

        If chbxCodigosProductos.Checked = True Then
            Me.COMPRASDETALLETableAdapter.FillByPlan(DSReporteCompras.COMPRASDETALLE, tbxCodigosProductos.Text)
        ElseIf cbxCategoria.Text = "%" Then
            Me.COMPRASDETALLETableAdapter.FillBy1Prod(DSReporteCompras.COMPRASDETALLE, cmbProducto.Text)
        Else
            Me.COMPRASDETALLETableAdapter.FillByFam(DSReporteCompras.COMPRASDETALLE, cbxCategoria.Text)
        End If

        Me.TotalStockActualTableAdapter.Fill(DSReporteCompras.TotalStockActual)
        Me.COMPRASDETALLETableAdapter.Fill(DSReporteCompras.COMPRASDETALLE)

        If rbAgrupFamillia.Checked = True Then
            Dim rpt As New Reportes.ComprasCostoValorizadoFifo
            rpt.SetDataSource([DSReporteCompras])
            frm.CrystalReportViewer1.ReportSource = rpt
        Else
            Dim rpt As New Reportes.ComprasCostoValorizadoFifoAFam
            rpt.SetDataSource([DSReporteCompras])
            frm.CrystalReportViewer1.ReportSource = rpt
        End If

        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub rptGastosCdCTotalRTLineal()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasCdCLinealRT

        Dim FechaDesde As Date = dtpFechaDesde.Value
        Dim FechaHasta As Date = dtpFechaHasta.Value
        Me.CdC_LinealTableAdapter.Fill(DSReporteCompras.CdC_Lineal, FechaHasta, FechaDesde)

        rpt.SetDataSource([DSReporteCompras])
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub rptGastosCdCTotalRTMensual()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ComprasCdCLinealRTLimpio

        Dim FechaDesde As Date = dtpFechaDesde.Value
        Dim FechaHasta As Date = dtpFechaHasta.Value
        Me.CdC_LinealTableAdapter.Fill(DSReporteCompras.CdC_Lineal, FechaHasta, FechaDesde)
        rpt.SetDataSource([DSReporteCompras])
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub treeReportesVentas_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles treeReportesVentas.AfterSelect
        DeshabilitaTodo()
        cmbSucursal.Enabled = True
        pnlFechaPeriodo.Visible = False
        pnlOtrasOpciones.Visible = False
        lblIva.Visible = False
        pnlIva.Visible = False
        cbxCategoria.Text = "%"
        cbxCdC.Text = "%"
        cbxLinea.Text = "%"
        cbxRubro.Text = "%"
        cmbProducto.Text = "%"
        cmbProveedor.Text = "%"
        cmbSucursal.Text = "%"
        lblAgrupacion.Text = "Agrupar los datos por Intervalos"
        rbAgrupFamillia.Checked = True
        dtpFechaHasta.Visible = True
        dtpFechaDesde.Visible = True
        Label11.Visible = True
        Label7.Visible = True
        Label7.Text = "Desde"
        Label11.Text = "Hasta"

        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)

        If treeReportesVentas.SelectedNode.Name = "frmCompraProducto" Then
            chbxMatricial.Visible = False

            pnlIntervalo.Visible = True
            lblAgrupacion.Text = "Agrupar los datos"
            HabilitaFecha()
            HabilitaIntervalo()
            pnlOtrasOpciones.Visible = True
            lblIva.Visible = True
            pnlIva.Visible = True
            pnlIva.Location = New Point(250, 0)
            lblIva.Location = New Point(272, 0)
            rbConIva.Checked = True

            btnFiltroProd.Visible = True
            btnFiltroProd.Location = btnPos1
            pnlProductos.BringToFront()
            cmbProducto.Enabled = True

            lblReporte.Text = "Compras por Producto"
            lblReporteDescrip.Text = "Permite visualizar las compras por producto"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptPendienteProveedor" Then
            chbxMatricial.Visible = False
            btnFiltroProveedor.Visible = True
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()
            tbxcodProv.Visible = False
            pbxRangoProv.BringToFront()
            pbxRangoProv.Visible = True
            pbxRangoProv.Enabled = True
            btnFiltroProveedor.Visible = True
            cmbProveedor.Enabled = True
            HabilitaFecha()

            lblReporte.Text = "Pedientes por Proveedor"
            lblReporteDescrip.Text = "Permite visualizar las Compras Pendientes por Proveedor"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptCompraSucursal" Then
            chbxMatricial.Visible = False

            btnFiltroEmpresa.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            pnlEmpresa.BringToFront()
            cmbProveedor.Enabled = False
            cmbtipo.Enabled = False
            HabilitaFecha()
            lblReporte.Text = "Gastos Por Sucursal"
            lblReporteDescrip.Text = "Permite visualizar las  Compras/Gastos por Sucursal"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptGastosporCentroCosto" Then
            chbxMatricial.Visible = False

            chbxMatricial.Visible = False

            btnFiltroEmpresa.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            pnlEmpresa.BringToFront()
            cmbProveedor.Enabled = False
            cmbtipo.Enabled = False
            HabilitaFecha()
            HabilitaIntervalo()
            lblReporte.Text = "Gastos Por Centro de Costo"
            lblReporteDescrip.Text = "Permite visualizar las  Compras/Gastos por Centro de Costo"
            '----------------------------------------------------------------------
            'CENTRO DE COSTO DETALLADO
        ElseIf treeReportesVentas.SelectedNode.Name = "rptDetalleporCentroCosto" Then
            chbxMatricial.Visible = False

            chbxMatricial.Visible = False

            btnFiltroEmpresa.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            pnlEmpresa.BringToFront()
            cmbProveedor.Enabled = False
            cmbtipo.Enabled = False
            HabilitaFecha()
            'HabilitaIntervalo()
            lblReporte.Text = "Gastos Por Centro de Costo Detallado"
            lblReporteDescrip.Text = "Permite visualizar las  Compras/Gastos por Centro de Costo Detallado"
            '---------------------------------------------------------------------------------
        ElseIf treeReportesVentas.SelectedNode.Name = "rptListaProveedor" Then
            chbxMatricial.Visible = True

            pnlSinFiltro.BringToFront()
            lblReporte.Text = "Lista de Proveedores"
            lblReporteDescrip.Text = "Permite visualizar datos de todos los Proveedores"

        ElseIf treeReportesVentas.SelectedNode.Name = "frmCompraPorCategorias" Then
            chbxMatricial.Visible = False

            btnFiltroProd.Visible = True
            btnFiltroProd.Location = btnPos1
            pnlProductos.BringToFront()
            cmbProducto.Enabled = True
            lblReporte.Text = "Compras por Categoria"
            lblReporteDescrip.Text = "Permite visualizar las Compras por Categorias"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptDiarioCajaDet" Then
            chbxMatricial.Visible = False

            btnFiltroFinanciero.Visible = True
            btnFiltroFinanciero.Enabled = True
            btnFiltroFinanciero.Location = btnPos1
            pnlFinanciero.BringToFront()
            cmbCaja.Enabled = True
            cmbMoneda.Enabled = True
            cmbComprobante.Enabled = False
            HabilitaFecha()
            lblReporte.Text = "Diario de Caja"
            lblReporteDescrip.Text = ""

        ElseIf treeReportesVentas.SelectedNode.Name = "rptDiarioCajaResum" Then
            chbxMatricial.Visible = False

            btnFiltroFinanciero.Visible = True
            btnFiltroFinanciero.Enabled = True
            btnFiltroFinanciero.Location = btnPos1
            pnlFinanciero.BringToFront()
            pnlFecha.Enabled = True
            cmbCaja.Enabled = True
            cmbMoneda.Enabled = True
            cmbComprobante.Enabled = False
            'HabilitaIntervalo()
            lblReporte.Text = "Diario de Caja"
            lblReporteDescrip.Text = ""

            'ElseIf treeReportesVentas.SelectedNode.Name = "rptFacturasCobrar" Then  NO FUNCIONA
            '    chbxMatricial.Visible = False

            '    btnFiltroProveedor.Visible = True
            '    btnFiltroProveedor.Enabled = True
            '    btnFiltroProveedor.Location = btnPos1
            '    pnlProveedor.BringToFront()
            '    '  HabilitaFecha()
            '    'HabilitaIntervalo()
            '    lblReporte.Text = "Factura a Cobrar"
            '    lblReporteDescrip.Text = ""

        ElseIf treeReportesVentas.SelectedNode.Name = "rptCuentaCorrienteProveedor" Then
            chbxMatricial.Visible = False

            btnFiltroProveedor.Visible = True
            btnFiltroProveedor.Enabled = True
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()
            HabilitaFecha()
            lblReporte.Text = "Cuenta Corriente Proveedor"
            lblReporteDescrip.Text = "Con en este reporte se visualizan todos los movimientos (Compras / Pagos) que su empresa tiene con los Proveedores"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasVsListaPrecioUltimaCompra" Then
            chbxMatricial.Visible = False

            pnlSinFiltro.BringToFront()
            pnlFecha.Enabled = True
            'HabilitaIntervalo()
            lblReporte.Text = "Compra Vs. Lista Precio de Ultima Compra"
            lblReporteDescrip.Text = ""

        ElseIf treeReportesVentas.SelectedNode.Name = "rptGastosCdCTotalRTMensual" Then
            chbxMatricial.Visible = False

            pnlSinFiltro.BringToFront()
            HabilitaFecha()
            pnlIntervalo.Enabled = False
            lblReporte.Text = "Gastos Total Mensual"
            lblReporteDescrip.Text = "Te mostrara los gastos mensuales en Suma como tambien por Centro de Costo. Esto te ayuda ver relaciones entre los diferentes Centros De Costos y como las mismas afectan la suma de gastos incurrido en el mes."

        ElseIf treeReportesVentas.SelectedNode.Name = "rptGastosCdCTotalRTLineal" Then
            chbxMatricial.Visible = False

            pnlSinFiltro.BringToFront()
            HabilitaFecha()
            pnlIntervalo.Enabled = False
            lblReporte.Text = "Gastos Total Lineal"
            lblReporteDescrip.Text = "Te permite visualizar los gastos acumulados por un periodo de tiempo. Esto sirve cuando tienes proyectos, obras, o eventos especiales que acumulan gastos y es necesario analizar los gastos hechos durante un periodo de tiempo."

        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasFifo" Then
            chbxMatricial.Visible = False

            pnlSinFiltro.BringToFront()
            lblReporte.Text = "Resumir los Costos Fijos"
            lblReporteDescrip.Text = ""

        ElseIf treeReportesVentas.SelectedNode.Name = "rptCostoFifo" Then
            chbxMatricial.Visible = False

            pnlIntervalo.Visible = True
            lblAgrupacion.Text = "Agrupar los datos"
            HabilitaIntervalo()
            pnlOtrasOpciones.Visible = True
            btnFiltroProd.Visible = True
            btnFiltroProd.Location = btnPos1
            pnlProductos.BringToFront()
            cmbProducto.Enabled = True
            lblReporte.Text = "Costo de Productos Valorizado"
            lblReporteDescrip.Text = "Muestra el Costo de los Productos Valorizados utilizando el Metodo FIFO"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptCostosUltimaCompra" Then
            chbxMatricial.Visible = False

            pnlIntervalo.Visible = True
            lblAgrupacion.Text = "Agrupar los datos"
            HabilitaFecha()
            HabilitaIntervalo()
            pnlOtrasOpciones.Visible = True
            lblIva.Visible = True
            pnlIva.Visible = True
            pnlIva.Location = New Point(250, 0)
            lblIva.Location = New Point(272, 0)
            rbConIva.Checked = True

            btnFiltroProd.Visible = True
            btnFiltroProd.Location = btnPos1
            pnlProductos.BringToFront()
            cmbProducto.Enabled = True
            HabilitaFecha()
            lblReporte.Text = "Precios de Ultima Compra"
            lblReporteDescrip.Text = "Muestra los datos de la Última Compra dentro de un Rango. Incluye precios y totales con IVA"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasCostoPromedio" Then
            chbxMatricial.Visible = False

            btnFiltroProd.Visible = True
            btnFiltroProd.Location = btnPos1
            pnlProductos.BringToFront()
            cmbProducto.Enabled = True
            pnlIntervalo.Visible = True
            lblAgrupacion.Text = "Agrupar los datos"
            HabilitaFecha()
            HabilitaIntervalo()
            pnlOtrasOpciones.Visible = True
            lblIva.Visible = True
            pnlIva.Visible = True
            pnlIva.Location = New Point(250, 0)
            lblIva.Location = New Point(272, 0)
            rbConIva.Checked = True

            lblReporte.Text = "Costo Promedio  por Producto"
            lblReporteDescrip.Text = "CoGS significa 'Cost of Goods Sold.' Basicamente calcula un Costo Promedio y lo multiplica por la cantidad del mismo productos vendido en un periodo x."

        ElseIf treeReportesVentas.SelectedNode.Name = "rptCOGSDetallado" Then
            chbxMatricial.Visible = False

            pnlIntervalo.Visible = True
            lblAgrupacion.Text = "Agrupar los datos"
            HabilitaFecha()
            HabilitaIntervalo()
            pnlOtrasOpciones.Visible = True
            lblIva.Visible = True
            pnlIva.Visible = True
            pnlIva.Location = New Point(250, 0)
            lblIva.Location = New Point(272, 0)
            rbConIva.Checked = True

            btnFiltroProd.Visible = True
            btnFiltroProd.Location = btnPos1
            pnlProductos.BringToFront()
            cmbProducto.Enabled = True
            lblReporte.Text = "Costo Promedio Por Producto Detallado"
            lblReporteDescrip.Text = "CoGS significa 'Cost of Goods Sold.' Basicamente calcula un Costo Promedio y lo multiplica por la cantidad del mismo productos vendido en un periodo x."

        ElseIf treeReportesVentas.SelectedNode.Name = "rptCostoFijo" Then
            chbxMatricial.Visible = False

            pnlSinFiltro.BringToFront()
            HabilitaFecha()
            lblReporte.Text = "Precio Promedio Con Costo Fijo"
            lblReporteDescrip.Text = "Este reporte le ayudara ver los Precios de los productos/servicios que adquiere agregando los Costos Fijos (o Costos Administrativos) de su empresa. "

        ElseIf treeReportesVentas.SelectedNode.Name = "rptCostoFijoListaPrecio" Then
            chbxMatricial.Visible = False

            pnlSinFiltro.BringToFront()
            HabilitaFecha()
            lblReporte.Text = "Precio Promedio Vs. Lista de Precio"
            lblReporteDescrip.Text = "Este reporte le ayudara ver los precios de los productos/servicios que adquiere agregando los Costos Fijos (o Costos Administrativos) de su empresa. "

        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasVsListaPrecioSinCF" Then
            chbxMatricial.Visible = False

            pnlSinFiltro.BringToFront()
            HabilitaFecha()
            lblReporte.Text = "Precio Prom Vs Lista de Precio Sin Costo Fijo"
            lblReporteDescrip.Text = "Este reporte le ayudara ver los precios de los productos/servicios que adquiere de su empresa."

        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasVs.ListaPrecioUltimaCompra" Then
            chbxMatricial.Visible = False

            pnlSinFiltro.BringToFront()
            HabilitaFecha()
            lblReporte.Text = "Costo Prom Vs Lista Precio Ultima Compra"
            lblReporteDescrip.Text = "CoGS significa 'Cost of Goods Sold.' Basicamente calcula un Costo Promedio y lo multiplica por la cantidad del mismo productos vendido en un periodo x."
        ElseIf treeReportesVentas.SelectedNode.Name = "rptIVANCCompras" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroProveedor.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            btnFiltroProveedor.Location = btnPos2
            pnlEmpresa.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = True
            cmbtipo.Enabled = True
            LblTipo.Text = "Tipo Factura"
            cmbtipo.Items.Clear()
            cmbtipo.Items.Add("Contado")
            cmbtipo.Items.Add("Crédito")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "IVA Notas de Crédito Compras"
            lblReporteDescrip.Text = "Permite visualizar los IVA Detallados de Notas de Crédito Compras, filtrando por intervalo de fecha y tipo de Factura"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptIVACompras" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroProveedor.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            btnFiltroProveedor.Location = btnPos2
            pnlEmpresa.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = True
            cmbtipo.Enabled = True
            LblTipo.Text = "Tipo Factura"
            cmbtipo.Items.Clear()
            cmbtipo.Items.Add("Contado")
            cmbtipo.Items.Add("Crédito")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "IVA Compras"
            lblReporteDescrip.Text = "Permite visualizar los IVA Detallados de Compras Aprobadas, filtrando por intervalo de fecha y tipo de Factura"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptLibroCompraLEY" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            pnlEmpresa.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = True
            cmbtipo.Enabled = True

            HabilitaFecha()
            lblReporte.Text = "Libro Compras Ley 125/91"
            lblReporteDescrip.Text = "Permite visualizar los IVA Detallados de Compras Aprobadas, filtrando por intervalo de fecha y tipo de Factura"

        ElseIf treeReportesVentas.SelectedNode.Name = "NotasCreditoLey" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroProveedor.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            btnFiltroProveedor.Location = btnPos2
            pnlEmpresa.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = True
            cmbtipo.Enabled = True
            LblTipo.Text = "Tipo Devolución"
            cmbtipo.Items.Clear()
            cmbtipo.Items.Add("Devolucion")
            cmbtipo.Items.Add("Bonificación")
            cmbtipo.Items.Add("Por Cambio")
            cmbtipo.Text = "%"
            cmbtipo.Enabled = False

            HabilitaFecha()
            lblReporte.Text = "Nota de Crédito Formato LEY"
            lblReporteDescrip.Text = "Permite visualizar los IVA Detallados de Notas de Crédito Aprobadas, filtrando por intervalo de fecha y tipo de Factura"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptConsultaCompras" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            pnlEmpresa.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = True
            cmbtipo.Enabled = True
            cmbtipo.Items.Clear()
            LblTipo.Text = "Tipo Factura"
            cmbtipo.Items.Add("Contado")
            cmbtipo.Items.Add("Crédito")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "Compras Aprobadas"
            lblReporteDescrip.Text = "Permite visualizar el total de Compras Aprobadas, filtrando por intervalo de fecha y tipo de Factura"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasPorProveedor" Then
            chbxMatricial.Visible = True

            btnFiltroProd.Visible = True
            btnFiltroProd.Location = btnPos1
            pnlProductos.BringToFront()

            HabilitaFecha()
            lblReporte.Text = "Precio de Compra por Producto por Proveedor"
            lblReporteDescrip.Text = "Permite visualizar las compras de cada Producto por Proveedor mostrando la Cantidad y el Precio de la Compra"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptComprasLista" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroEmpresa.Location = btnPos1
            btnFiltroFinanciero.Visible = True
            btnFiltroFinanciero.Location = btnPos2
            pnlEmpresa.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False
            cmbCaja.Enabled = False
            cmbMoneda.Enabled = False

            cmbComprobante.Text = "%"
            cmbSucursal.Enabled = True
            cmbtipo.Enabled = True
            cmbtipo.Items.Clear()
            LblTipo.Text = "Tipo Factura"
            cmbtipo.Items.Add("Contado")
            cmbtipo.Items.Add("Crédito")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "Compras Lista"
            lblReporteDescrip.Text = "Permite visualizar la Lista de Compras Aprobadas, filtrando por intervalo de fecha y tipo de Factura"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptFacturasPagar" Then
            chbxMatricial.Visible = True

            btnFiltroProveedor.Visible = True
            pnlProveedor.BringToFront()
            btnFiltroProveedor.Location = btnPos1
            cmbProveedor.Enabled = True

            HabilitaFecha()
            lblReporte.Text = "Facturas a Pagar"
            lblReporteDescrip.Text = "Permite visualizar las Facturas pendientes de Pago Agrupados por días de Pago"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptAnalisisSaldo" Then
            chbxMatricial.Visible = False

            btnFiltroProveedor.Visible = True
            pnlProveedor.BringToFront()
            btnFiltroProveedor.Location = btnPos1
            cmbProveedor.Enabled = True
            dtpFechaDesde.Value = Today
            dtpFechaHasta.Visible = False

            Label11.Visible = False
            Label7.Text = "Hasta"
            HabilitaFecha()
            lblReporte.Text = "Analisis de Saldos"
            lblReporteDescrip.Text = "Permite visualisar los saldos de facturas pendientes agrupadas por dias de atraso"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptPendientesPago" Then
            chbxMatricial.Visible = True

            btnFiltroProveedor.Visible = True
            pnlProveedor.BringToFront()
            btnFiltroProveedor.Location = btnPos1
            cmbProveedor.Enabled = True

            HabilitaFecha()
            lblReporte.Text = "Comprobantes Pendientes de Pago"
            lblReporteDescrip.Text = "Permite visualizar las Facturas pendientes de Pago, Notas de Crédito pendientes a aplicar y como Información Adicinal los Cheques Diferidos Pendientes emitidos como Pago"

            Dim año As Integer = Today.Year - 4
            dtpFechaDesde.Text = "01/01/" & año

            'ElseIf treeReportesVentas.SelectedNode.Name = "rptNotasCredito" Then
            '    chbxMatricial.Visible = True

            '    btnFiltroEmpresa.Visible = True
            '    btnFiltroProveedor.Visible = True
            '    btnFiltroEmpresa.Location = btnPos1
            '    btnFiltroProveedor.Location = btnPos2
            '    pnlEmpresa.BringToFront()

            '    cbxCdC.Text = "%"
            '    cbxCdC.Enabled = False

            '    cmbSucursal.Enabled = True
            '    cmbtipo.Enabled = True
            '    cmbtipo.Items.Clear()
            '    LblTipo.Text = "Tipo Devolucion"
            '    cmbtipo.Items.Add("Devolucion")
            '    cmbtipo.Items.Add("Bonificación")
            '    cmbtipo.Items.Add("Por Cambio")
            '    cmbtipo.Text = "%"

            '    HabilitaFecha()
            '    lblReporte.Text = "Notas de Crédito"
            '    lblReporteDescrip.Text = "Permite visualizar las Notas de Crédito, filtrando por Sucursal, tipo de Nota de Crédito e intervalo de fecha"

        ElseIf treeReportesVentas.SelectedNode.Name = "rptRecibosXFactura" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroProveedor.Visible = True
            btnFiltroEmpresa.Location = btnPos2
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = False
            cmbtipo.Enabled = True
            cmbtipo.Items.Clear()
            LblTipo.Text = "Tipo Pago"
            cmbtipo.Items.Add("Efectivo")
            cmbtipo.Items.Add("Cheque")
            cmbtipo.Items.Add("Nota de Credito")
            cmbtipo.Items.Add("Retención Iva")
            cmbtipo.Items.Add("Tarjeta")
            cmbtipo.Items.Add("Transferencia")
            cmbtipo.Items.Add("Ajuste de Pago")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "Recibos Por Factura"
            lblReporteDescrip.Text = "Permite visualizar los datos de Recibos de Proveedores aplicadas a las Facturas de Compra, filtrando por Proveedor, tipo de Recibo e intervalo de fecha"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptFacturasXRecibo" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroProveedor.Visible = True
            btnFiltroEmpresa.Location = btnPos2
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = False
            cmbtipo.Enabled = True
            cmbtipo.Items.Clear()
            LblTipo.Text = "Tipo Factura"
            cmbtipo.Items.Add("Contado")
            cmbtipo.Items.Add("Crédito")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "Facturas Por Recibo"
            lblReporteDescrip.Text = "Permite visualizar las Facturas de Compra y los Recibos de Proveedores aplicados las mismas, filtrando por Proveedor, tipo de Factura e intervalo de fecha"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptRecibosProveedor" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroProveedor.Visible = True
            btnFiltroEmpresa.Location = btnPos2
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = False
            LblTipo.Text = "Tipo Factura"
            cmbtipo.Enabled = True
            cmbtipo.Items.Clear()
            cmbtipo.Items.Add("Contado")
            cmbtipo.Items.Add("Crédito")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "Recibos de Proveedores"
            lblReporteDescrip.Text = "Permite visualizar los datos de Recibos de Proveedores, filtrando por Proveedor, tipo de Recibo e intervalo de fecha"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptRecibosProveedorDet" Then
            chbxMatricial.Visible = True

            btnFiltroEmpresa.Visible = True
            btnFiltroProveedor.Visible = True
            btnFiltroEmpresa.Location = btnPos2
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = False
            LblTipo.Text = "Tipo Factura"
            cmbtipo.Enabled = True
            cmbtipo.Items.Clear()
            cmbtipo.Items.Add("Contado")
            cmbtipo.Items.Add("Crédito")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "Recibos de Proveedores Detallado"
            lblReporteDescrip.Text = "Permite visualizar los datos de Recibos de Proveedores, filtrando por Proveedor, tipo de Recibo e intervalo de fecha"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptRetenciones" Then
            chbxMatricial.Visible = False

            btnFiltroEmpresa.Visible = True
            btnFiltroProveedor.Visible = True
            btnFiltroEmpresa.Location = btnPos2
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()

            cbxCdC.Text = "%"
            cbxCdC.Enabled = False

            cmbSucursal.Enabled = False
            LblTipo.Text = "Tipo Retención"
            cmbtipo.Enabled = True
            cmbtipo.Items.Clear()
            cmbtipo.Items.Add("IVA")
            cmbtipo.Items.Add("RENTA")
            cmbtipo.Text = "%"

            HabilitaFecha()
            lblReporte.Text = "Lista de Retenciones"
            lblReporteDescrip.Text = "Permite visualizar la lista de Retenciones, filtrando por Proveedor, tipo de Retencion e intervalo de fecha"
        ElseIf treeReportesVentas.SelectedNode.Name = "rptEstadoCuenta" Then
            chbxMatricial.Visible = True

            btnFiltroProveedor.Visible = True
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()

            HabilitaFecha()
            lblReporte.Text = "Estado de Cuenta Proveedor"
            lblReporteDescrip.Text = "Permite visualizar los Movimientos hechos con Proveedores. Seleccione un Proveedor de la Lista "
        ElseIf treeReportesVentas.SelectedNode.Name = "rptListadoOC" Then
            chbxMatricial.Visible = True

            btnFiltroProveedor.Visible = True
            btnFiltroProveedor.Location = btnPos1
            pnlProveedor.BringToFront()

            HabilitaFecha()
            lblReporte.Text = "Listado de Ordenes de Compra"
            lblReporteDescrip.Text = "Permite visualizar ordenes de compras realizadas "

        End If
    End Sub

    Private Sub DeshabilitaTodo()
        btnFiltroProd.Visible = False
        btnFiltroProveedor.Visible = False
        btnFiltroFinanciero.Visible = False
        btnFiltroEmpresa.Visible = False
        pnlSinFiltro.BringToFront()
        pnlFecha.Enabled = False
        pnlFechaActivo.BackColor = Color.DimGray
        pnlIntervalo.Enabled = False
        pnlIntervaloActivo.BackColor = Color.DimGray
    End Sub

    Private Sub ReporteCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
'TODO: esta línea de código carga datos en la tabla 'DsProveedores.ListaProv' Puede moverla o quitarla según sea necesario.
Me.ListaProvTableAdapter.Fill(Me.DsProveedores.ListaProv)
        treeReportesVentas.ExpandAll()
        DeshabilitaTodo()

        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)
        rbtndia.Checked = True
        cmbMes.Text = Now.Month
        cmbAño.Text = Now.Year
        cmbDesde.Text = "1"
        cmbHasta.Text = "30"
        pnlFechaPeriodo.Visible = False

        Me.ListaPrecioTableAdapter.Fill(Me.DSReporteCompras.ListaPrecio)
        Me.CAJATableAdapter.Fill(Me.DSReporteCompras1.CAJA)
        Me.MONEDATableAdapter.Fill(Me.DSReporteCompras1.MONEDA)
        Me.PROVEEDORTableAdapter.Fill(Me.DSReporteCompras1.PROVEEDOR)
        Me.SUCURSALTableAdapter.Fill(Me.DSReporteCompras1.SUCURSAL)
        Me.CENTROCOSTOTableAdapter.Fill(Me.DSReporteCompras1.CENTROCOSTO)
        Me.PRODUCTOSTableAdapter.Fill(Me.DSReporteCompras1.PRODUCTOS)
        Me.RUBROTableAdapter.Fill(Me.DSReporteCompras1.RUBRO)
        Me.LINEATableAdapter.Fill(Me.DSReporteCompras1.LINEA)
        Me.FAMILIATableAdapter.Fill(Me.DSReporteCompras1.FAMILIA)
        Me.RCTIPOCOMPROBANTETableAdapter.Fill(Me.DsRCPagos.RCTIPOCOMPROBANTE)

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
    End Sub


    Private Sub btnFiltroProd_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltroProd.Click
        pnlProductos.BringToFront()
    End Sub

    Private Sub btnFiltroProveedor_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltroProveedor.Click
        pnlProveedor.BringToFront()
    End Sub

    Private Sub btnFiltroFinanciero_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltroFinanciero.Click
        pnlFinanciero.BringToFront()
    End Sub

    Private Sub btnFiltroEmpresa_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltroEmpresa.Click
        pnlEmpresa.BringToFront()
    End Sub

    Private Sub HabilitaIntervalo()
        pnlIntervalo.Enabled = True
        pnlIntervaloActivo.BackColor = Color.DarkGray
    End Sub

    Private Sub HabilitaFecha()
        pnlFecha.Enabled = True
        pnlFechaActivo.BackColor = Color.DarkGray
    End Sub


    Private Sub cmbProveedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbProveedor.Text = "%"
            dtpFechaDesde.Select()
        End If
    End Sub
    Private Sub cmbComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbComprobante.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbComprobante.Text = "%"
            dtpFechaDesde.Select()
        End If
    End Sub

    Private Sub cbxCdC_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxCdC.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbxCdC.Text = "%"
            cmbSucursal.Select()
        End If
    End Sub

    Private Sub cmbSucursal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbSucursal.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbSucursal.Text = "%"
            dtpFechaDesde.Select()
        End If
    End Sub

    Private Sub cbxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxCategoria.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbxCategoria.Text = "%"
        End If
        cbxLinea.Select()
    End Sub

    Private Sub cbxLinea_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxLinea.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbxLinea.Text = "%"
        End If
        cbxRubro.Select()
    End Sub

    Private Sub cbxRubro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxRubro.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbxRubro.Text = "%"
        End If
        cmbProducto.Select()
    End Sub

    Private Sub cmbProducto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbProducto.Text = "%"
            dtpFechaDesde.Select()
        End If
    End Sub

    Private Sub cbxCategoria_TextChanged(sender As Object, e As System.EventArgs) Handles cbxCategoria.TextChanged
        Dim codCategoria As String = cbxCategoria.Text
        Me.LINEABindingSource.Filter = "DESFAMILIA like '" & codCategoria & "'"
    End Sub

    Private Sub cbxLinea_TextChanged(sender As Object, e As System.EventArgs) Handles cbxLinea.TextChanged
        Dim CODLINEA As String = cbxLinea.Text
        Dim codCategoria As String = cbxCategoria.Text
        Me.RUBROBindingSource.Filter = "DESLINEA like '" & CODLINEA & "'"
        If cbxLinea.SelectedValue <> Nothing Then
            'Me.PRODUCTOSBindingSource.Filter = "CODLINEA = " & cbxLinea.SelectedValue
        End If
    End Sub

    Private Sub cbxRubro_TextChanged(sender As Object, e As System.EventArgs) Handles cbxRubro.TextChanged
        If cbxLinea.SelectedValue <> Nothing Then
            'Me.PRODUCTOSBindingSource.Filter = "CODLINEA = " & cbxLinea.SelectedValue
        End If
    End Sub

    Private Sub chbxCodigosProductos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbxCodigosProductos.CheckedChanged
        If chbxCodigosProductos.Checked = True Then
            tbxCodigosProductos.Visible = True
            lblAyudaCodProd.Visible = True
        Else
            tbxCodigosProductos.Visible = False
            lblAyudaCodProd.Visible = False
        End If
    End Sub

    Private Sub cmbtipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbtipo.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbtipo.Text = "%"
            dtpFechaDesde.Select()
        End If
    End Sub
    Private Sub cmbTipo_TextChanged(sender As System.Object, e As System.EventArgs) Handles cmbtipo.TextChanged
        If cmbtipo.Text = "Contado" Then
            cmbtipo2.Text = "0"
        ElseIf cmbtipo.Text = "Crédito" Then
            cmbtipo2.Text = "1"
        ElseIf cmbtipo.Text = "IVA" Then
            cmbtipo2.Text = "6"
        ElseIf cmbtipo.Text = "RENTA" Then
            cmbtipo2.Text = "10"
        Else
            cmbtipo2.Text = "%"
        End If
    End Sub
    Function obtenerwhere(ByVal cmbfiltro1 As System.Windows.Forms.ComboBox, ByVal nombrecampof1 As String, ByVal cmbfiltro2 As System.Windows.Forms.ComboBox, ByVal nombrecampof2 As String, ByVal cmbfiltro3 As System.Windows.Forms.ComboBox, ByVal nombrecampof3 As String, ByVal cmbfiltro4 As System.Windows.Forms.ComboBox, ByVal nombrecampof4 As String, ByVal tipo1 As String, ByVal tipo2 As String, ByVal tipo3 As String, ByVal tipo4 As String)

        Dim Filtro1 As String = ""
        Dim SiFiltro1 As Boolean = False
        Dim Filtro2 As String = ""
        Dim SiFiltro2 As Boolean = False
        Dim Filtro3 As String = ""
        Dim SiFiltro3 As Boolean = False
        Dim Filtro4 As String = ""
        Dim consultawhere As String

        If cmbfiltro1.Text = "%" Or cmbfiltro1.Text = "" Then
            SiFiltro1 = False
        Else
            If tipo1 = "Cadena Text" Then
                Filtro1 = nombrecampof1 + " = '" & cmbfiltro1.Text & "'"
            ElseIf tipo1 = "Numero Text" Then
                Filtro1 = nombrecampof1 + " = " & cmbfiltro1.Text
            ElseIf tipo1 = "Cadena SValue" Then
                Filtro1 = nombrecampof1 + " = '" & cmbfiltro1.SelectedValue & "'"
            ElseIf tipo1 = "Numero SValue" Then
                Filtro1 = nombrecampof1 + " = " & cmbfiltro1.SelectedValue
            End If
            SiFiltro1 = True
        End If

        If cmbfiltro2.Text = "%" Or cmbfiltro2.Text = "" Then
            SiFiltro2 = False
        Else
            SiFiltro2 = True
            If SiFiltro1 = False Then
                If tipo2 = "Cadena Text" Then
                    Filtro2 = nombrecampof2 + " = '" & cmbfiltro2.Text & "'"
                ElseIf tipo2 = "Numero Text" Then
                    Filtro2 = nombrecampof2 + " = " & cmbfiltro2.Text
                ElseIf tipo2 = "Cadena SValue" Then
                    Filtro2 = nombrecampof2 + " = '" & cmbfiltro2.SelectedValue & "'"
                ElseIf tipo2 = "Numero SValue" Then
                    Filtro2 = nombrecampof2 + " = " & cmbfiltro2.SelectedValue
                End If
            Else
                If tipo2 = "Cadena Text" Then
                    Filtro2 = " AND " + nombrecampof2 + " = '" & cmbfiltro2.Text & "'"
                ElseIf tipo2 = "Numero Text" Then
                    Filtro2 = " AND " + nombrecampof2 + " = " & cmbfiltro2.Text
                ElseIf tipo2 = "Cadena SValue" Then
                    Filtro2 = " AND " + nombrecampof2 + " = '" & cmbfiltro2.SelectedValue & "'"
                ElseIf tipo2 = "Numero SValue" Then
                    Filtro2 = " AND " + nombrecampof2 + " = " & cmbfiltro2.SelectedValue
                End If
            End If
        End If

        If cmbfiltro3.Text = "%" Or cmbfiltro3.Text = "" Then
            SiFiltro3 = False
        Else
            SiFiltro3 = True
            If SiFiltro1 = True Or SiFiltro2 = True Then
                If tipo3 = "Cadena Text" Then
                    Filtro3 = " AND " + nombrecampof3 + " = '" & cmbfiltro3.Text & "'"
                ElseIf tipo3 = "Numero Text" Then
                    Filtro3 = " AND " + nombrecampof3 + " = " & cmbfiltro3.Text
                ElseIf tipo3 = "Cadena SValue" Then
                    Filtro3 = " AND " + nombrecampof3 + " = '" & cmbfiltro3.SelectedValue & "'"
                ElseIf tipo3 = "Numero SValue" Then
                    Filtro3 = " AND " + nombrecampof3 + " = " & cmbfiltro3.SelectedValue
                End If
            Else
                If tipo3 = "Cadena Text" Then
                    Filtro3 = nombrecampof3 + " = '" & cmbfiltro3.Text & "'"
                ElseIf tipo3 = "Numero Text" Then
                    Filtro3 = nombrecampof3 + " = " & cmbfiltro3.Text
                ElseIf tipo3 = "Cadena SValue" Then
                    Filtro3 = nombrecampof3 + " = '" & cmbfiltro3.SelectedValue & "'"
                ElseIf tipo3 = "Numero SValue" Then
                    Filtro3 = nombrecampof3 + " = " & cmbfiltro3.SelectedValue
                End If
            End If
        End If


        If cmbfiltro4.Text = "%" Or cmbfiltro4.Text = "" Then
            'Nada
        Else
            If SiFiltro1 = True Or SiFiltro2 = True Or SiFiltro3 = True Then
                If tipo4 = "Cadena Text" Then
                    Filtro4 = " AND " + nombrecampof4 + " = '" & cmbfiltro4.Text & "'"
                ElseIf tipo4 = "Numero Text" Then
                    Filtro4 = " AND " + nombrecampof4 + " = " & cmbfiltro4.Text
                ElseIf tipo4 = "Cadena SValue" Then
                    Filtro4 = " AND " + nombrecampof4 + " = '" & cmbfiltro4.SelectedValue & "'"
                ElseIf tipo4 = "Numero SValue" Then
                    Filtro4 = " AND " + nombrecampof4 + " = " & cmbfiltro4.SelectedValue
                End If
            Else
                If tipo4 = "Cadena Text" Then
                    Filtro4 = nombrecampof4 + " = '" & cmbfiltro4.Text & "'"
                ElseIf tipo4 = "Numero Text" Then
                    Filtro4 = nombrecampof4 + " = " & cmbfiltro4.Text & ""
                ElseIf tipo4 = "Cadena SValue" Then
                    Filtro4 = nombrecampof4 + " = '" & cmbfiltro4.SelectedValue & "'"
                ElseIf tipo4 = "Numero SValue" Then
                    Filtro4 = nombrecampof4 + " = " & cmbfiltro4.SelectedValue & ""
                End If
            End If
        End If
        consultawhere = Filtro1 + Filtro2 + Filtro3 + Filtro4

        Return consultawhere
    End Function

    Private Sub pnlOtrasOpciones_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlOtrasOpciones.Paint

    End Sub

    Private Sub pbxRangoProv_Click(sender As Object, e As EventArgs) Handles pbxRangoProv.Click
        tbxcodProv.Visible = True
        tbxcodProv.BringToFront()
        tbxcodProv.Enabled = True
    End Sub

End Class