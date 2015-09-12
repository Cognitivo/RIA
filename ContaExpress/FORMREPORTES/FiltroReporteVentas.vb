Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad
Imports System.Drawing.SystemIcons

Public Class FiltroReporteVentas
    Dim sql As String
    Dim sql1 As String
    Private ser As BDConexión.BDConexion
    Dim Pos1 As System.Drawing.Point = New Point(3, 56)
    Dim Pos2 As System.Drawing.Point = New Point(3, 104)
    Dim Pos3 As System.Drawing.Point = New Point(3, 152)
    Dim Pos4 As System.Drawing.Point = New Point(3, 200)
    Dim Pos5 As System.Drawing.Point = New Point(3, 248)
    Dim Pos6 As System.Drawing.Point = New Point(3, 296)
    Dim Pos7 As System.Drawing.Point = New Point(3, 344)
    Dim Pos8 As System.Drawing.Point = New Point(3, 392)
    Dim Pos9 As System.Drawing.Point = New Point(3, 440)
    Dim PosSinFiltro As System.Drawing.Point = New Point(3, 31)
    Dim PosInvisible As System.Drawing.Point = New Point(3000, 33)
    Dim permiso As Double
    Dim FechaDesde As String
    Dim FechaHasta As String
    Dim BanCargaProductos, BanComprVent, BanCompNC As Boolean
    Dim ListaReportes(81, 3) As String
    Dim Config4, NumCliente As String
    Dim f As New Funciones.Funciones
    Dim CodigoGral, FormatF1, FormatF2, FormatF3, FormatF4, FormatF5, FormatF6, Formateado As String
    Dim dtVendedores, dtCategoriaClientes, dtZonas, dtTipo, dtListaPrecio, dtComprobante, dtSucursal, dtNumFactura As DataTable
    Dim banverifcheck As Boolean = True

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        CrystalReportViewer.ShowPageNavigateButtons = True
        CrystalReportViewer.DisplayStatusBar = True
        CrystalReportViewer.DisplayToolbar = True

        If chbxCodCliente.Checked = True And (pnlCliente.Location = Pos1 Or pnlCliente.Location = Pos2 Or pnlCliente.Location = Pos3 Or pnlCliente.Location = Pos4 Or pnlCliente.Location = Pos5 Or pnlCliente.Location = Pos6 Or pnlCliente.Location = Pos7) Then
            If tbxcodCliente.Text = "" Then
                MessageBox.Show("Debe Ingresar un Filtro para Clientes", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                tbxcodCliente.Focus()
                Exit Sub
            End If
        ElseIf chbxCodProducto.Checked = True Then

        End If
        ' validamos los combo/checkcombo
        verificarvacioscombo(cbxCategoria)
        verificarvacioscombo(cbxLinea)
        verificarvacioscombo(cbxRubro)
        verificarvacioscombo(cmbCiudad)
        verificarvacioscombo(cmbCaja)
        verificarvacioscombo(cmbCategCliente)
        verificarvacioscombo(cmbCliente)
        verificarvacioscombo(cmbCiudad)
        verificarvacioscombo(cmbComprobante)
        verificarvacioscombo(cmbListaPrecio)
        verificarvacioscombo(cmbMoneda)
        verificarvacioscombo(cmbPais)
        verificarvacioscombo(cmbProducto)
        verificarvacioscombo(cmbSucursal)
        verificarvacioscombo(cmbTipo)
        verificarvacioscombo(cmbVendedor)
        verificarvacioscombo(cmbZona)

        Dim desde As String = dtpFechaDesde.Value
        Dim hasta As String = dtpFechaHasta.Value
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:59"

        Me.Cursor = Cursors.AppStarting
        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiarioCajaResIva" Then
            ReporteResumenCajaIva()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSPromNeto" Then
            permiso = PermisoAplicado(UsuCodigo, 169)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteCoGSPromedioNeto()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaBreakeven" Then
            permiso = PermisoAplicado(UsuCodigo, 89)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteBreakeven()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSCompraVenta" Then
            permiso = PermisoAplicado(UsuCodigo, 190)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteCompraVenta()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSListaPrecio" Then
            permiso = PermisoAplicado(UsuCodigo, 1)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteCoGSlistaPrecio()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSUtilidadPorVenta" Then
            permiso = PermisoAplicado(UsuCodigo, 187)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteUtilidadVenta()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProyeccionCobros" Then
            proyeccioncobros()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIngresoVsEgresoPorDía" Then
            permiso = PermisoAplicado(UsuCodigo, 170)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteIngresoEgreso()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaProd" Then
            permiso = PermisoAplicado(UsuCodigo, 156)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteVentasProductoDetallado()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasTipoCobro" Then
            permiso = PermisoAplicado(UsuCodigo, 163)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteVentasTipoPago()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasVendedorPorCliente" Then
            permiso = PermisoAplicado(UsuCodigo, 157)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteVentasPorVendedorPorCliente()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaCliente" Then
            permiso = PermisoAplicado(UsuCodigo, 167)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteListaClienteNombreCliente()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesAporVendedorporZona" Then
            permiso = PermisoAplicado(UsuCodigo, 167)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteListaClienteAVendedorporZona()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesAporZona" Then
            permiso = PermisoAplicado(UsuCodigo, 167)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteListaClienteAZona()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesAporVendedor" Then
            permiso = PermisoAplicado(UsuCodigo, 167)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteListaClienteAVendedor()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesAporCategoria" Then
            permiso = PermisoAplicado(UsuCodigo, 167)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteListaClienteACategoria()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProdVendidosTop20" Then
            permiso = PermisoAplicado(UsuCodigo, 158)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteProductoMasVendido()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasCobrar" Then
            permiso = PermisoAplicado(UsuCodigo, 162)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteFacturaAcobrar()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptPendienteProducto" Then
            permiso = PermisoAplicado(UsuCodigo, 150)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReportePendienteProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptPendienteCliente" Then
            permiso = PermisoAplicado(UsuCodigo, 151)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReportePedidoPendientePorCliente()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiarioCajaDet" Then
            permiso = PermisoAplicado(UsuCodigo, 161)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteDiarioCaja()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEnvioZonaProducto" Then
            permiso = PermisoAplicado(UsuCodigo, 168)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteEnvioPorZonaProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEnvioPorClienteProducto" Then

            permiso = PermisoAplicado(UsuCodigo, 168)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteEnvioPorClienteProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEnvioPorCliente" Then
            permiso = PermisoAplicado(UsuCodigo, 168)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteEnvioPorCliente()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCatVendidasTop20" Then
            permiso = PermisoAplicado(UsuCodigo, 159)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ReporteCategoriasMasVendidas()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaProdTop20" Then
            permiso = PermisoAplicado(UsuCodigo, 155)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            VentaProductoTop20Mes()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasCatTop20" Then
            permiso = PermisoAplicado(UsuCodigo, 154)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            VentaCategoriaTop20Mes()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaSucursal" Then
            permiso = PermisoAplicado(UsuCodigo, 152)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            VentasPorSucursal()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaVsCostoPorProducto" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            VentasVsCostoPorProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaVsCostoPorCategoria" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            VentasVsCostoPorCategoria()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaListaPrecio" Then
            permiso = PermisoAplicado(UsuCodigo, 153)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            VentasTipoCliente()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaListaPrecioComp" Then
             VentasListaPreciaComparativo()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesporListadeprecio" Then
            ReporteListaClienteporListaprec()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSProm" Then
                permiso = PermisoAplicado(UsuCodigo, 164)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                ReporteCOGSPromedio()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSUltPrecio" Then
                permiso = PermisoAplicado(UsuCodigo, 165)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                ReporteCOGSPromedioUltimo()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSUltPrecioNeto" Then
                permiso = PermisoAplicado(UsuCodigo, 179)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                ReporteCOGSPromedioUltimoNeto()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasCantidadVentasYoY" Then
                permiso = PermisoAplicado(UsuCodigo, 182)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                VentasCantVentasYoY()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaResumen" Then
                permiso = PermisoAplicado(UsuCodigo, 183)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                VentasResumen()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaDetallado" Then
                permiso = PermisoAplicado(UsuCodigo, 184)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                VentasDetallado()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorZona" Then
                permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                VentasPorZona()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorZonaPromedio" Then
                permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                rptVentasPorZonaPromedio()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorZonaSimple" Then
                rptVentasPorZonaSimple()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasDetalladasAgrupPorZona" Then
                VentasAgrupPorZonaDetalle()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptUtilidadCliente" Then
                permiso = PermisoAplicado(UsuCodigo, 185)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                UtilidadCliente()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptGs.Comprado" Then
                permiso = PermisoAplicado(UsuCodigo, 186)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                VentasGsComprado()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCantidadVendida" Then
                permiso = PermisoAplicado(UsuCodigo, 181)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                VentasCantidadComprada()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiarioCajaRes" Then
                permiso = PermisoAplicado(UsuCodigo, 180)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                VentasResumenCaja()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMenosVendidos" Then
                permiso = PermisoAplicado(UsuCodigo, 180)
                 rptMenosVendidos()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiasVentas" Then
                permiso = PermisoAplicado(UsuCodigo, 180)
                rptDiasVentas()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "frmDiasUltimaCompra" Then
                permiso = PermisoAplicado(UsuCodigo, 180)
                frmDiasUltimaCompra()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturas" Then
                permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                ComprobantesVentas()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasAgrupCli" Then
                permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                ComprobantesVentasAgrupCli()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorCliente" Then
                permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            rptVentasPorCliente()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasTipoPago" Then '********************************SAUL
            'permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            'If permiso = 0 Then
            '    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If
            rptVentasTipoPago()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIncidenciaNCVTA" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            rptIncidenciaNCVTA()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIVAVentasDetallado" Then
                IVAVentasComprobantesDetallado()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIVANCreditoDetallado" Then
                IVAVentasNCreditoDetallado()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIVANCreditoDesStockDetallado" Then
                IVAVentasNCreditoDesStockDetallado()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasResumido" Then
                ComprobantesVentasResumido()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNCPeriodoPorProducto" Then
                permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                rptNCPeriodoPorProducto()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNCPeriodoPorProductoAgrupCli" Then
                permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            rptNCPeriodoPorProductoAgrupCli()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNClistadetallado" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            rptNClistadetallado()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasEstado" Then
            rptFacturasEstado()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorVendedorDetalle" Then
            VentasPorVendedorDetalle()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptComisionVendedorRes" Then
            ComisionVendedorRes()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptComisionVendedorDet" Then
            ComisionVendedorDet()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLiquidacionVendedor" Then
            LiquidaciondeVendedores()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptComisionVendedorTipoFactura" Then
            rptComisionVendedorTipoFactura()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptventaporcentajeventa" Then
            Ventaporcentajeventa()
            ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasPorProductoResumido" Then
                permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            ComprobantesVentasPorProductoResumido()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaVentasLey" Then

            rptLibroIvaVentasLey()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaNotasCreditoVentasLey" Then

            rptLibroIvaNotasCreditoVentasLey()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasPorProductoPorCliente" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ComprobantesVentasPorClientePorProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptComprVentasPorVendedorProductoResumido" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ComprVentasPorVendedorProductoResumido()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasPorProductoPorFecha" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            ComprobantesVentasPorProductoPorFecha()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNotasCreditoResumido" Then
            ComprobantesNotasCreditoResumido()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNCEstado" Then
            rptNCEstado()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNotasCreditoPorProducto" Then
            ComprobantesNotasCreditoPorProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRecibosClientes" Then
            RecibosClientes()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRecibosClientesDet" Then
            rptRecibosClientesDet()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRecibosXFactura" Then
            FacturasXRecibo() 'Saul
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasXRecibo" Then
            RecibosXFactura() 'Saul
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasACobrar" Then
            FacturasACobrar()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptPendienteCobro" Then
            PendientesCobro()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNCPendienteCobro" Then
            NotasdeCreditoPendientes()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptlistadorecibos" Then
            listadorecibos()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEstadoCuenta" Then
            EstadoCuentaCliente()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovimientoCliente" Then
            rptMovimientoCliente()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptClientesAtrasados" Then
            ClientesAtrasados()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptAnalisisSaldo" Then
            AnalisisdeSaldos()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRankingClientes" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            RankingClientes()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovRemision" Then
            rptMovRemision()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRankingProductos" Then
            permiso = PermisoAplicado(UsuCodigo, 269) 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD 'PERMISO PARA VER REPORTES CON DETALLE DE COSTOS, UTILIDAD
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en este Reporte ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            RankingProductos()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasCliXProd" Then
            VentasCliXProd()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasProdXCli" Then
            VentasProdXCli()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorProductoComparativo" Then
            VentasPorProductoComparativo()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorClienteComparativo" Then
            VentasPorClienteComparativo()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaPresupuesto" Then
            VentasListaPresupuesto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaPresupuestoSC" Then
            VentasListaPresupuestoSC()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptutilidadventa" Then ' saul
            UtilidadVenta()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasDetalladaXCliente" Then ' saul
            VentasDetalladaXCliente()

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptSaldoCliente" Then
            SaldoClientes()
        End If
            pnlFiltros.Visible = False
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub SaldoClientes()
        Dim rpt As New Reportes.ComposicionSaldoClientes
        Dim compSaldoTA As DsRVClientesTableAdapters.CompSaldoClienteTableAdapter = New DsRVClientesTableAdapters.CompSaldoClienteTableAdapter()
        compSaldoTA.Fill(DsRVClientes.CompSaldoCliente)

        rpt.SetDataSource([CompSaldoClientes])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))

        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub ComisionVendedorRes()
        Try
            If rbPorCobr.Checked = True Then
                Dim rpt As New Reportes.VentasComisionVendedorCobr

                Dim fechadesde2, fechahasta2 As String
                fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
                fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

                FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "NO")

                If cmbVendedor.Text = "%" Then
                    If rbPorCobr.Checked = True Then
                        Me.ComisionVendedorTableAdapter.Fill(DsRVComisiones.ComisionVendedorCobranza, fechadesde2, fechahasta2)
                    Else
                        Me.ComisionVendedorFacturacionTableAdapter.Fill(DsRVComisiones.ComisionVendedorFacturacion, fechadesde2, fechahasta2)
                    End If
                Else
                    If rbPorCobr.Checked = True Then
                        Me.ComisionVendedorTableAdapter.FillBy1Vend(DsRVComisiones.ComisionVendedorCobranza, fechadesde2, fechahasta2, FormatF1)
                    Else
                        Me.ComisionVendedorFacturacionTableAdapter.FillBy1Vend(DsRVComisiones.ComisionVendedorFacturacion, fechadesde2, fechahasta2, FormatF1)
                    End If
                End If

                rpt.SetDataSource([DsRVComisiones])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
                If rbIVANO.Checked = True Then
                    rpt.SetParameterValue("pmtConIVA", "NO")
                Else
                    rpt.SetParameterValue("pmtConIVA", "SI")
                End If
                If rbPorCobr.Checked = True Then
                    rpt.SetParameterValue("pmtTipoCalculo", "- Cobranza")
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            Else 'Por Facturacion
                Dim fechadesde2, fechahasta2 As String
                fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
                fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
                FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
                
                Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", "%", "SUCURSAL.CODSUCURSAL", "%", "SUCURSAL.CODSUCURSAL", "%", "SUCURSAL.CODSUCURSAL", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn")
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.FacturacionPorVendedorTableAdapter.Fill(DsFacturacionPorVendedor.FacturacionPorVendedor, fechadesde2, fechahasta2)
                Else
                    Me.FacturacionPorVendedorTableAdapter.FillBy(DsFacturacionPorVendedor.FacturacionPorVendedor, fechadesde2, fechahasta2, FormatF1)
                End If
                
                Dim rpt As New Reportes.VentasComisionVendedorFact

                rpt.SetDataSource([DsFacturacionPorVendedor])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
                If rbIVANO.Checked = True Then
                    rpt.SetParameterValue("pmtConIVA", "NO")
                Else
                    rpt.SetParameterValue("pmtConIVA", "SI")
                End If
                If rbPorCobr.Checked = True Then
                    rpt.SetParameterValue("pmtTipoCalculo", "- Cobranza")
                Else
                    rpt.SetParameterValue("pmtTipoCalculo", "- Facturación")
                End If
                
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptComisionVendedorTipoFactura()
        Try
            Dim rpt As New Reportes.VentasComisionVendedorCobrTipoVenta

            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "NO")

            If cmbVendedor.Text = "%" Then
                If rbPorCobr.Checked = True Then
                    Me.ComisionVendedorCobranzaTipoVentaTableAdapter.Fill(DsRVComisiones.ComisionVendedorCobranzaTipoVenta, fechadesde2, fechahasta2)
                Else
                End If
            Else
                If rbPorCobr.Checked = True Then
                    Me.ComisionVendedorCobranzaTipoVentaTableAdapter.FillBy(DsRVComisiones.ComisionVendedorCobranzaTipoVenta, fechadesde2, fechahasta2, FormatF1)
                Else
                End If
            End If

            rpt.SetDataSource([DsRVComisiones])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptMovimientoCliente()
        Try
            Dim rpt As New Reportes.VentasMovimientoClientes

            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

            If cmbCliente.Text = "%" Then
                RvHistoricoClienteTableAdapter1.FillBy(DsRVClientes.RVHistoricoCliente, fechadesde2, fechahasta2)
            Else
                RvHistoricoClienteTableAdapter1.Fill(DsRVClientes.RVHistoricoCliente, cmbCliente.SelectedValue, fechadesde2, fechahasta2)
            End If

            rpt.SetDataSource([DsRVClientes])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VentasNCCobradasVend()
        Dim rpt As New Reportes.VentasNotasCreditoCobradas
        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

        FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "NO")

        Me.ComisionNotasCreditoTableAdapter.FillNC(DsRVComisiones.ComisionNotasCredito, FormatF1, fechadesde2, fechahasta2)
        rpt.SetDataSource([DsRVComisiones])
        CrystalReportViewer.ReportSource = rpt
        CrystalReportViewer.Refresh()
    End Sub



    Private Sub ComisionVendedorDet()

        Dim rpt As New Reportes.VentasComisionVendedorCobrDet
        Dim frm = New VerInformes

        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

        FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "NO")

        If cmbVendedor.Text = "%" Then
            Me.ComisionVendedorCobrDetTableAdapter.Fill(DsRVComisiones.ComisionVendedorCobrDet, fechadesde2, fechahasta2)
            Me.ComisionNotasCreditoTableAdapter.FillNCTodos(DsRVComisiones.ComisionNotasCredito, fechadesde2, fechahasta2)
            Else
            Me.ComisionVendedorCobrDetTableAdapter.FillBy1Vend(DsRVComisiones.ComisionVendedorCobrDet, fechadesde2, fechahasta2, FormatF1)
            Me.ComisionNotasCreditoTableAdapter.FillNC(DsRVComisiones.ComisionNotasCredito, fechadesde2, fechahasta2, FormatF1)
        End If

        rpt.SetDataSource([DsRVComisiones])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
        If rbIVANO.Checked = True Then
            rpt.SetParameterValue("pmtConIVA", "NO")
        Else
            rpt.SetParameterValue("pmtConIVA", "SI")
        End If

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If


    End Sub
    Private Sub Ventaporcentajeventa()

        Dim rpt As New Reportes.VentasPorcentajedeVentas
        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        Me.PorcentajedeventaTableAdapter.Fill(DsReporteVentas.PorcentajedeVenta, fechadesde2, fechahasta2)

        rpt.SetDataSource([DsReporteVentas])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Private Sub VentasProdXCli()

        Dim rpt As New Reportes.VentasdeProductosXCliente
        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

        '-----------------
        'If cmbCliente.Text = "%" Then
        '    RvHistoricoClienteTableAdapter1.FillBy(DsRVClientes.RVHistoricoCliente, fechadesde2, fechahasta2)
        'Else
        '    RvHistoricoClienteTableAdapter1.Fill(DsRVClientes.RVHistoricoCliente, cmbCliente.SelectedValue, fechadesde2, fechahasta2)
        'End If
        '-----------------Will.i.am


        'If chbxCodCliente.Checked = True Then
        '    Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", "%", "", FormatF4, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn")
        '    Dim TestPos As Integer
        '
        '    TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
        '    If TestPos = 0 Then 'El texto no tiene guion
        '        If Trim(sqlwhere) = "" Then ' se eligieron todos %
        '            Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
        '        Else
        '            Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
        '        End If
        '    Else
        '        Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
        '        Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
        '        If Trim(sqlwhere) = "" Then ' se eligieron todos %
        '            Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
        '        Else
        '            Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
        '        End If
        '    End If
        'Else


        If chbxCodProducto.Checked = True And chbxCodCliente.Checked = True Then
            Dim TestPos As Integer

            TestPos = InStr(1, tbxcodProd.Text, "-", CompareMethod.Text)
            'TestPos2 = InStr(1, cmbCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then ' And TestPos2 = 0 Then 'El texto del Producto(TestPos) y el Cliente(TestPos2) no tienen guion
                Me.RvVentasCompletoTableAdapter.FillByListaProd(Me.DsRVEstadisticas.RVVentasCompleto, FechaDesde, FechaHasta, tbxcodProd.Text)
            Else
                Dim codInicio As String = "'" + Trim(Mid(tbxcodProd.Text, 1, TestPos - 1)) + "'"
                Dim codFin As String = "'" + Trim(Mid(tbxcodProd.Text, TestPos + 1, tbxcodProd.Text.Length)) + "'"
                Me.RvVentasCompletoTableAdapter.FillByPRODDH(Me.DsRVEstadisticas.RVVentasCompleto, FechaDesde, FechaHasta, codInicio, codFin)
            End If
        ElseIf cmbProducto.Text = "%" Then
            Me.RvVentasCompletoTableAdapter.Fill(DsRVEstadisticas.RVVentasCompleto, fechadesde2, fechahasta2)
        Else
            Me.RvVentasCompletoTableAdapter.FillByUnProd(DsRVEstadisticas.RVVentasCompleto, fechadesde2, fechahasta2, cmbProducto.SelectedValue)
        End If

        rpt.SetDataSource([DsRVEstadisticas])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If


    End Sub
    Private Sub VentasPorClienteComparativo()
        Try
            Dim rpt As New Reportes.VentasPorClienteComparativoMesAnho
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If cmbCategCliente.Text = "%" Then
                        Me.RvVentasPorClienteComparativoMesAnhoTableAdapter.FillByListaCliente(DsRVEstadisticas.RVVentasPorClienteComparativoMesAnho, fechadesde2, fechahasta2, tbxcodCliente.Text)
                    Else
                        FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
                        Me.RvVentasPorClienteComparativoMesAnhoTableAdapter.FillByListaClienteCateg(DsRVEstadisticas.RVVentasPorClienteComparativoMesAnho, fechadesde2, fechahasta2, FormatF1, tbxcodCliente.Text)
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If cmbCategCliente.Text = "%" Then
                        Me.RvVentasPorClienteComparativoMesAnhoTableAdapter.FillByNumClienteDH(DsRVEstadisticas.RVVentasPorClienteComparativoMesAnho, fechadesde2, fechahasta2, codInicio, codFin)
                    Else
                        FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
                        Me.RvVentasPorClienteComparativoMesAnhoTableAdapter.FillByNumClienteDHCateg(DsRVEstadisticas.RVVentasPorClienteComparativoMesAnho, fechadesde2, fechahasta2, FormatF1, codInicio, codFin)
                    End If
                End If
            ElseIf cmbCliente.Text = "%" Then
                If cmbCategCliente.Text = "%" Then
                    Me.RvVentasPorClienteComparativoMesAnhoTableAdapter.Fill(DsRVEstadisticas.RVVentasPorClienteComparativoMesAnho, fechadesde2, fechahasta2)
                Else
                    FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
                    Me.RvVentasPorClienteComparativoMesAnhoTableAdapter.FillBySCateg(DsRVEstadisticas.RVVentasPorClienteComparativoMesAnho, fechadesde2, fechahasta2, FormatF1)
                End If
            Else
                Me.RvVentasPorClienteComparativoMesAnhoTableAdapter.FillByUnCliente(DsRVEstadisticas.RVVentasPorClienteComparativoMesAnho, fechadesde2, fechahasta2, cmbCliente.SelectedValue)
            End If
            rpt.SetDataSource([DsRVEstadisticas])

            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub VentasPorProductoComparativo()
        Try
            Dim rpt As New Reportes.VentasPorProductoComparativoMesAnho
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            If chbxCodProducto.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodProd.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    Me.RvVentasPorProductoComparativoMesAnhoTableAdapter.FillByListaProd(DsRVEstadisticas.RVVentasPorProductoComparativoMesAnho, fechadesde2, fechahasta2, tbxcodProd.Text)
                Else
                    Dim codInicio As String = "'" + Trim(Mid(tbxcodProd.Text, 1, TestPos - 1)) + "'"
                    Dim codFin As String = "'" + Trim(Mid(tbxcodProd.Text, TestPos + 1, tbxcodProd.Text.Length)) + "'"
                    Me.RvVentasPorProductoComparativoMesAnhoTableAdapter.FillByProdDH(DsRVEstadisticas.RVVentasPorProductoComparativoMesAnho, fechadesde2, fechahasta2, codInicio, codFin)
                End If
            ElseIf cmbProducto.Text = "%" Then
                Me.RvVentasPorProductoComparativoMesAnhoTableAdapter.Fill(DsRVEstadisticas.RVVentasPorProductoComparativoMesAnho, fechadesde2, fechahasta2)
            Else
                Me.RvVentasPorProductoComparativoMesAnhoTableAdapter.FillByUnProducto(DsRVEstadisticas.RVVentasPorProductoComparativoMesAnho, fechadesde2, fechahasta2, cmbProducto.SelectedValue)
            End If
            rpt.SetDataSource([DsRVEstadisticas])

            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub VentasCliXProd()
        Try
            Dim rpt As New Reportes.VentasClienteXProducto
            'Dim rpt As New Reportes.VentasEstadisticaMatriz
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If cmbCategCliente.Text = "%" Then
                        Me.RvVentasCompletoTableAdapter.FillByNumCliente(Me.DsRVEstadisticas.RVVentasCompleto, FechaDesde, FechaHasta, tbxcodCliente.Text)
                    Else
                        FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
                        Me.RvVentasCompletoTableAdapter.FillByNumClienteCateg(Me.DsRVEstadisticas.RVVentasCompleto, FechaDesde, FechaHasta, FormatF1, tbxcodCliente.Text)
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If cmbCategCliente.Text = "%" Then
                        Me.RvVentasCompletoTableAdapter.FillByNumClienteDH(Me.DsRVEstadisticas.RVVentasCompleto, FechaDesde, FechaHasta, codInicio, codFin)
                    Else
                        FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
                        Me.RvVentasCompletoTableAdapter.FillByNumClienteDHCateg(Me.DsRVEstadisticas.RVVentasCompleto, FechaDesde, FechaHasta, FormatF1, codInicio, codFin)
                    End If
                End If
            ElseIf cmbCliente.Text = "%" Then
                If cmbCategCliente.Text = "%" Then
                    Me.RvVentasCompletoTableAdapter.FillBy(DsRVEstadisticas.RVVentasCompleto, fechadesde2, fechahasta2)
                Else
                    FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
                    Me.RvVentasCompletoTableAdapter.FillBySCateg(DsRVEstadisticas.RVVentasCompleto, fechadesde2, fechahasta2, FormatF1)
                End If
            Else
                Me.RvVentasCompletoTableAdapter.FillByUnCliente(DsRVEstadisticas.RVVentasCompleto, fechadesde2, fechahasta2, cmbCliente.SelectedValue)
            End If
            rpt.SetDataSource([DsRVEstadisticas])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub RankingProductos()
        Dim rpt As New Reportes.VentasRankingProductos
        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

        Me.RvRankingProductosTableAdapter.Fill(DsRVEstadisticas.RVRankingProductos, fechadesde2, fechahasta2)

        rpt.SetDataSource([DsRVEstadisticas])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()

        End If
    End Sub
    Private Sub RankingClientes()
        Dim rpt As New Reportes.VentasRankingClientes
        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

        Me.RvRankingClientesTableAdapter.Fill(DsRVEstadisticas.RVRankingClientes, fechadesde2, fechahasta2)

        rpt.SetDataSource([DsRVEstadisticas])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()

        End If
    End Sub
    Private Sub rptMovRemision()
        Dim rpt As New Reportes.MovimientoRemision
        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

        Me.MovimientoRemisionesTableAdapter.Fill(DsContaBalanceGeneral173.MovimientoRemisiones, fechadesde2, fechahasta2)

        rpt.SetDataSource([DsContaBalanceGeneral173])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFechaHasta.Value.ToString("dd/MM/yyyy"))
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()

        End If
    End Sub
    Private Sub EstadoCuentaCliente()
        Dim rpt As New Reportes.VentasEstadoCuentaCliente
        Dim rptmat As New Reportes.VentasEstadoCuentaClienteMATR
        'Dim ds As New DataSet
        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:59"

        If chbxCodCliente.Checked = False Then
            If cmbCliente.Text = "%" Then
                Me.RvMovimientosClienteTableAdapter.FillTodos(DsRVFacturacion.RVMovimientosCliente, fechadesde2, fechahasta2)
            Else
                Me.RvMovimientosClienteTableAdapter.Fill(DsRVFacturacion.RVMovimientosCliente, CDec(cmbCliente.SelectedValue), fechadesde2, fechahasta2)

            End If
        Else
            Dim TestPos As Integer
            TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                Me.RvMovimientosClienteTableAdapter.FillByPlan(DsRVFacturacion.RVMovimientosCliente, tbxcodCliente.Text, fechadesde2, fechahasta2)
            Else
                Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                Me.RvMovimientosClienteTableAdapter.FillByRango(DsRVFacturacion.RVMovimientosCliente, codInicio, codFin, fechadesde2, fechahasta2)
            End If
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVFacturacion])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
        Else
            rpt.SetDataSource([DsRVFacturacion])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            ds = New DataSet
        End If
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()

        End If
    End Sub

    Private Sub PendientesCobro()


        Dim rpt As New Reportes.VentasFacturasPendienteCobro
        Dim dt As New DataTable
        Dim rptmat As New Reportes.VentasFacturasPendienteCobroMATR
        Dim fechadesde2, fechahasta2 As String
        Dim numcliente As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
        FormatF2 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
        If chbxCodCliente.Checked = True Then
            Dim TestPos As Integer
            TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                Me.RvchdiF_NCREDTableAdapter.FillByPlan(DsRVCobros.RVCHDIF_NCRED, fechadesde2, fechahasta2, tbxcodCliente.Text)
                dt = Me.RvchdiF_NCREDTableAdapter.GetDataByPlan(fechadesde2, fechahasta2, tbxcodCliente.Text)
                Me.RvPendienteCobroDifTableAdapter.FillByPlan(Me.DsRVCobros.RVPendienteCobroDif, fechadesde2, fechahasta2, FormatF1, FormatF2, tbxcodCliente.Text)
            Else
                Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                Me.RvchdiF_NCREDTableAdapter.FillByRangoCli(DsRVCobros.RVCHDIF_NCRED, codInicio, codFin, fechadesde2, fechahasta2)
                dt = Me.RvchdiF_NCREDTableAdapter.GetDataByRangoCli(codInicio, codFin, fechadesde2, fechahasta2)
                Me.RvPendienteCobroDifTableAdapter.FillByRangoCli(Me.DsRVCobros.RVPendienteCobroDif, codInicio, codFin, fechadesde2, fechahasta2, FormatF1, FormatF2)
            End If
        ElseIf cmbCliente.Text = "%" Then
            Me.RvchdiF_NCREDTableAdapter.Fill(DsRVCobros.RVCHDIF_NCRED, fechadesde2, fechahasta2)
            dt = Me.RvchdiF_NCREDTableAdapter.GetData(fechadesde2, fechahasta2)
            Me.RvPendienteCobroDifTableAdapter.Fill(Me.DsRVCobros.RVPendienteCobroDif, fechadesde2, fechahasta2, FormatF1, FormatF2)
        Else
            Me.RvchdiF_NCREDTableAdapter.FillByCliente(DsRVCobros.RVCHDIF_NCRED, fechadesde2, fechahasta2, cmbCliente.SelectedValue)
            dt = Me.RvchdiF_NCREDTableAdapter.GetDataByCliente(fechadesde2, fechahasta2, cmbCliente.SelectedValue)
            Me.RvPendienteCobroDifTableAdapter.FillByCliente(Me.DsRVCobros.RVPendienteCobroDif, cmbCliente.SelectedValue, fechadesde2, fechahasta2, FormatF1, FormatF2)
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVCobros])
            If chbxCodCliente.Checked = True Then
                rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rptmat.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If
            If dt.Rows.Count = 0 Then
                rptmat.SetParameterValue("pmtChequesDif", "No hay Cheques Diferidos para mostrar")
            Else
                rptmat.SetParameterValue("pmtChequesDif", "Cheques Diferidos")
            End If
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
        Else
            rpt.SetDataSource([DsRVCobros])
            If chbxCodCliente.Checked = True Then
                rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rpt.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rpt.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If
            If dt.Rows.Count = 0 Then
                rpt.SetParameterValue("pmtChequesDif", "No hay Cheques Diferidos para mostrar")
            Else
                rpt.SetParameterValue("pmtChequesDif", "Cheques Diferidos")
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
        End If
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub FacturasACobrar()
        Dim rpt As New Reportes.VentasFacturaACobrar
        Dim dt As New DataTable
        Dim rptmat As New Reportes.VentasFacturaACobrarMATR
        Dim fechadesde2, fechahasta2 As String
        Dim numcliente As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
        FormatF2 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
        If chbxCodCliente.Checked = True Then
            Dim TestPos As Integer
            TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                Me.RvFacturasACobrarTableAdapter.FillByPlanNCli(Me.DsRVCobros.RVFACTURASACOBRAR, fechadesde2, fechahasta2, FormatF1, FormatF2, tbxcodCliente.Text)
            Else
                Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                Me.RvFacturasACobrarTableAdapter.FillByRangoCli(Me.DsRVCobros.RVFACTURASACOBRAR, codInicio, codFin, fechadesde2, fechahasta2, FormatF1, FormatF2)
            End If
        ElseIf cmbCliente.Text = "%" Then
            Me.RvFacturasACobrarTableAdapter.Fill(Me.DsRVCobros.RVFACTURASACOBRAR, fechadesde2, fechahasta2, FormatF1, FormatF2)
        Else
            Me.RvFacturasACobrarTableAdapter.FillByCliente(Me.DsRVCobros.RVFACTURASACOBRAR, cmbCliente.SelectedValue, fechadesde2, fechahasta2, FormatF1, FormatF2)
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVCobros])
            rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            If chbxCodCliente.Checked = True Then
                rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rptmat.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        Else
            rpt.SetDataSource([DsRVCobros])
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            If chbxCodCliente.Checked = True Then
                rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rpt.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rpt.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If

            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        End If
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub ClientesAtrasados()
        Dim rpt As New Reportes.VentasClientesAtrasados
        Dim dt As New DataTable
        Dim rptmat As New Reportes.VentasClientesAtrasadosMATR
        Dim fechadesde2, fechahasta2 As String
        Dim numcliente As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
        FormatF2 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")

        If chbxCodCliente.Checked = True Then
            Dim TestPos As Integer
            TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                Me.RvClientesAtrasadosTableAdapter.FillByPlan(Me.DsRVCobros.RVCLIENTESATRASADOS, fechadesde2, fechahasta2, tbxcodCliente.Text, FormatF1, FormatF2)
            Else
                Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                Me.RvClientesAtrasadosTableAdapter.FillByRangoCli(Me.DsRVCobros.RVCLIENTESATRASADOS, codInicio, codFin, fechadesde2, fechahasta2, FormatF1, FormatF2)
            End If
        ElseIf cmbCliente.Text = "%" Then
            Me.RvClientesAtrasadosTableAdapter.Fill(Me.DsRVCobros.RVCLIENTESATRASADOS, fechadesde2, fechahasta2, FormatF1, FormatF2)
        Else
            Me.RvClientesAtrasadosTableAdapter.FillByCliente(Me.DsRVCobros.RVCLIENTESATRASADOS, cmbCliente.SelectedValue, fechadesde2, fechahasta2, FormatF1, FormatF2)
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVCobros])
            rptmat.SetParameterValue("pmtRangoFecha", "Al " + dtpFechaHasta.Text + " de vencimiento hasta el " + dtpFechaDesde.Text)
            If chbxCodCliente.Checked = True Then
                rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rptmat.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If

            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
        Else
            rpt.SetDataSource([DsRVCobros])
            rpt.SetParameterValue("pmtRangoFecha", "Al " + dtpFechaHasta.Text + " de vencimiento hasta el " + dtpFechaDesde.Text)
            If chbxCodCliente.Checked = True Then
                rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rpt.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rpt.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
        End If
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()

        End If
    End Sub
    Private Sub AnalisisdeSaldos()
        Dim rpt As New Reportes.VentasAnalisisdeSaldos
        Dim dt As New DataTable
        Dim rptmat As New Reportes.VentasAnalisisdeSaldos
        Dim fechadesde2, fechahasta2 As String
        Dim numcliente As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
        FormatF2 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
        If chbxCodCliente.Checked = True Then
            Dim TestPos As Integer
            TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                Me.RVAnalisisDeSaldoTableAdapter.FillByListaCli(Me.DsRVCobros.RVANALISISDESALDO, fechadesde2, tbxcodCliente.Text, FormatF1, FormatF2)
            Else
                Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                Me.RVAnalisisDeSaldoTableAdapter.FillByRangoCli(Me.DsRVCobros.RVANALISISDESALDO, codInicio, codFin, fechadesde2, FormatF1, FormatF2)
            End If
        ElseIf cmbCliente.Text = "%" Then
            Me.RVAnalisisDeSaldoTableAdapter.Fill(Me.DsRVCobros.RVANALISISDESALDO, fechadesde2, FormatF1, FormatF2)
        Else
            Me.RVAnalisisDeSaldoTableAdapter.FillByCliente(Me.DsRVCobros.RVANALISISDESALDO, cmbCliente.SelectedValue, fechadesde2, FormatF1, FormatF2)
        End If
        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVCobros])
            rptmat.SetParameterValue("pmtRangoFecha", "Hasta el " + dtpFechaDesde.Text)
            If chbxCodCliente.Checked = True Then
                rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rptmat.SetParameterValue("pmtCliente", numcliente)
            End If
            If cmbListaPrecio.Text = "%" Then
                rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If

            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        Else
            rpt.SetDataSource([DsRVCobros])
            rpt.SetParameterValue("pmtRangoFecha", "Hasta el " + dtpFechaDesde.Text)
            If chbxCodCliente.Checked = True Then
                rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rpt.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rpt.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        End If
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()

        End If
    End Sub
    Private Sub NotasdeCreditoPendientes()
        Dim rpt As New Reportes.VentasNCPendienteCobro
        Dim dt As New DataTable
        Dim rptmat As New Reportes.VentasNCPendienteCobroMATR
        Dim fechadesde2, fechahasta2 As String
        Dim numcliente As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
        FormatF2 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
        If chbxCodCliente.Checked = True Then
            Dim TestPos As Integer
            TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                Me.RvNotasCreditoPendienteTableAdapter.FillByPlan(Me.DsRVCobros.RVNotasCreditoPendiente, fechadesde2, fechahasta2, FormatF1, FormatF2, tbxcodCliente.Text)
            Else
                Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                Me.RvNotasCreditoPendienteTableAdapter.FillByRangoCli(Me.DsRVCobros.RVNotasCreditoPendiente, codInicio, codFin, fechadesde2, fechahasta2, FormatF1, FormatF2)
            End If
        ElseIf cmbCliente.Text = "%" Then
            Me.RvNotasCreditoPendienteTableAdapter.Fill(Me.DsRVCobros.RVNotasCreditoPendiente, fechadesde2, fechahasta2, FormatF1, FormatF2)
        Else
            Me.RvNotasCreditoPendienteTableAdapter.FillByCliente(Me.DsRVCobros.RVNotasCreditoPendiente, cmbCliente.SelectedValue, fechadesde2, fechahasta2, FormatF1, FormatF2)
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVCobros])
            If chbxCodCliente.Checked = True Then
                rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rptmat.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If
            
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
        Else
            rpt.SetDataSource([DsRVCobros])
            If chbxCodCliente.Checked = True Then
                rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
            ElseIf cmbCliente.Text = "%" Then
                rpt.SetParameterValue("pmtCliente", "(Todos)")
            Else
                Dim w As New Funciones.Funciones
                numcliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                rpt.SetParameterValue("pmtCliente", numcliente)
            End If

            If cmbListaPrecio.Text = "%" Then
                rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
            Else
                rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
            End If
            
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
        End If
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()

        End If
    End Sub
    Private Sub FacturasXRecibo()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject

        Dim rpt As New Reportes.VentasFacturasXRecibo
        Dim rptmat As New Reportes.VentasFacturasXReciboMATR

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText = "SELECT VFCORIG.CODVENTA, VFCORIG.IMPORTE, UPPER (VFCORIG.DESTIPOCOBRO) AS DESTIPOCOBRO, VFCORIG.FECHACOBRO, VFCORIG.NRORECIBO, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.NUMVENTA," & _
                                                                         " (SELECT SUM (IMPORTE) AS Expr1 " & _
                                                                         " FROM dbo.VENTASFORMACOBRO" & _
                                                                         " WHERE  CODTIPOCOBRO <> 8 AND NRORECIBO = VFCORIG.NRORECIBO " & _
                                                                         " GROUP BY NRORECIBO) AS TOTALRECIBO, VFCORIG.CODCOBRO, dbo.VENTAS.FECHAVENTA, " & _
                                                                         " CASE VENTAS.TIPOVENTA WHEN 0 THEN 'CONTADO' WHEN 1 THEN 'CREDITO' WHEN 2 THEN 'BONIF' WHEN 3 THEN 'CAMBIO' ELSE 'OTROS' END AS TIPOVENTA, dbo.CLIENTES.NUMCLIENTE, " & _
                                                                         " dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.CLIENTES.CODCLIENTE " & _
                                                                         " FROM dbo.VENTAS INNER JOIN " & _
                                                                         " dbo.VENTASFORMACOBRO AS VFCORIG ON dbo.VENTAS.CODVENTA = VFCORIG.CODVENTA INNER JOIN " & _
                                                                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE"
            FormatF1 = calcularcmbTipoFactura(cmbTipo)
            FormatF2 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            If chbxCodCliente.Checked = True Then
                Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", "%", "", FormatF4, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn")
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 1) AND (VFCORIG.FECHACOBRO >= '" & fechadesde2 & "') AND (VFCORIG.FECHACOBRO <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    Else
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 1) AND (VFCORIG.FECHACOBRO >= '" & fechadesde2 & "') AND (VFCORIG.FECHACOBRO <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 1) AND (VFCORIG.FECHACOBRO >= '" & fechadesde2 & "') AND (VFCORIG.FECHACOBRO <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    Else
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 1) AND (VFCORIG.FECHACOBRO >= '" & fechadesde2 & "') AND (VFCORIG.FECHACOBRO <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    End If
                End If
            Else
                FormatF3 = FormatearFiltroCombo(cmbCliente, "SV")
                Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", FormatF3, "CLIENTES.CODCLIENTE", FormatF4, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn NULL")
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VFCORIG.FECHACOBRO >= '" & fechadesde2 & "') AND (VFCORIG.FECHACOBRO <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                Else
                    Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VFCORIG.FECHACOBRO >= '" & fechadesde2 & "') AND (VFCORIG.FECHACOBRO <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                End If
            End If
            Me.RvFacturasXReciboTableAdapter.Fill(DsRVCobros.RVFacturasXRecibo)

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVCobros])
                txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    txt.Width = 0 ' No mostramos NUMCLIENTE2
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0 ' No mostramos NUMCLIENTE2
                Else
                    rptmat.SetParameterValue("pmtCliente", "") ' Se va a mostrar NUMCLIENTE2
                End If

                If cmbTipo.Text = "%" Then
                    If cmbComprobante.Text = "%" Then
                        rptmat.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtTipo", cmbComprobante.Text + " - (Todos)")
                    End If
                Else
                    If cmbComprobante.Text = "%" Then
                        rptmat.SetParameterValue("pmtTipo", "(Todos) - " + cmbTipo.Text)
                    Else
                        rptmat.SetParameterValue("pmtTipo", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If

                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)

            Else
                rpt.SetDataSource([DsRVCobros])
                txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    txt.Width = 0 ' No mostramos NUMCLIENTE2
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0 ' No mostramos NUMCLIENTE2
                Else
                    rpt.SetParameterValue("pmtCliente", "") ' Se va a mostrar NUMCLIENTE2
                End If

                If cmbTipo.Text = "%" Then
                    If cmbComprobante.Text = "%" Then
                        rpt.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtTipo", cmbComprobante.Text + " - (Todos)")
                    End If
                Else
                    If cmbComprobante.Text = "%" Then
                        rpt.SetParameterValue("pmtTipo", "(Todos) - " + cmbTipo.Text)
                    Else
                        rpt.SetParameterValue("pmtTipo", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If

                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)

            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RecibosXFactura()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject

        Dim rpt As New Reportes.VentasRecibosXFactura
        Dim rptmat As New Reportes.VentasRecibosXFacturaMATR
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText = "SELECT VFCORIG.CODVENTA, VFCORIG.IMPORTE,CASE WHEN CODTIPOCOBRO = 5 AND (NRORECIBO IS NULL OR NRORECIBO = 0) THEN 'NOTA DE CREDITO' ELSE 'RECIBO' END AS DESTIPOCOBRO, VFCORIG.FECHACOBRO, CASE WHEN CODTIPOCOBRO = 5 AND (NRORECIBO IS NULL OR NRORECIBO = 0) THEN VFCORIG.NUMDEVOLUCION ELSE VFCORIG.NRORECIBO END AS NRORECIBO, " & _
                                                                         "VENTAS.TOTALVENTA, VENTAS.NUMVENTA, " & _
                                                                         "(SELECT        SUM(IMPORTE) AS Expr1 FROM VENTASFORMACOBRO " & _
                                                                         "WHERE NRORECIBO = VFCORIG.NRORECIBO GROUP BY NRORECIBO) AS TOTALRECIBO, VFCORIG.CODCOBRO, VENTAS.FECHAVENTA, " & _
                                                                         "CASE VENTAS.MODALIDADPAGO WHEN 0 THEN 'CONTADO' WHEN 1 THEN 'CREDITO' WHEN 2 THEN 'BONIF' WHEN 3 THEN 'CAMBIO' ELSE 'OTROS' END AS TIPOVENTA, " & _
                                                                         "CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, CLIENTES.NOMBREFANTASIA, CLIENTES.CODCLIENTE " & _
                                                                         "FROM VENTAS INNER JOIN " & _
                                                                         "VENTASFORMACOBRO AS VFCORIG ON VENTAS.CODVENTA = VFCORIG.CODVENTA INNER JOIN " & _
                                                                         "CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE "
            FormatF1 = calcularcmbTipoFactura(cmbTipo)
            FormatF2 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")

            If chbxCodCliente.Checked = True Then
                Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", "%", "", FormatF4, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn")
                Dim TestPos As Integer

                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    Else
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    Else
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    End If
                End If
            Else
                FormatF3 = FormatearFiltroCombo(cmbCliente, "SV")
                Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "VENTAS.CODCOMPROBANTE", FormatF3, "CLIENTES.CODCLIENTE", FormatF4, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", "CodigoIn", "Numero Text", "CodigoIn NULL")
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    If cmbCliente.Text = "%" Then
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    Else
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.CODCLIENTE= " & cmbCliente.SelectedValue & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    End If
                Else
                    If cmbCliente.Text = "%" Then
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    Else
                        Me.RvFacturasXReciboTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.CODCLIENTE= " & cmbCliente.SelectedValue & ") AND " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY FECHAVENTA"
                    End If
                End If
            End If

            Me.RvFacturasXReciboTableAdapter.Fill(DsRVCobros.RVFacturasXRecibo)

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVCobros])

                txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    txt.Width = 0 ' No mostramos NUMCLIENTE2
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0 ' No mostramos NUMCLIENTE2
                Else
                    rptmat.SetParameterValue("pmtCliente", "") ' Se va a mostrar NUMCLIENTE2
                End If

                If cmbTipo.Text = "%" Then
                    rptmat.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtTipo", cmbTipo.Text)
                End If
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If

                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVCobros])

                txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    txt.Width = 0 ' No mostramos NUMCLIENTE2
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0 ' No mostramos NUMCLIENTE2
                Else
                    rpt.SetParameterValue("pmtCliente", "") ' Se va a mostrar NUMCLIENTE2
                End If

                If cmbTipo.Text = "%" Then
                    rpt.SetParameterValue("pmtTipo", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtTipo", cmbTipo.Text)
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If

                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)

            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm As New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub listadorecibos()
        Dim rpt As New Reportes.VentasListadodeRecibos
        Dim fechadesde2, fechahasta2 As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

        Me.ListadereciboTableAdapter.Fill(DsReporteVentas.Listaderecibo, fechadesde2, fechahasta2)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Private Sub RecibosClientes()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            'Volvemos al SelectCommand original del Table Adapter (sin las condiciones de esta instancia)"
            Me.RvCobrosClientesTableAdapter.selectcommand.CommandText = "SELECT dbo.MONEDA.SIMBOLO, SUM(dbo.VENTASFORMACOBRO.IMPORTE / dbo.VENTASFORMACOBRO.COTIZACION1) AS IMPORTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, " & _
                        "dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.RECIBONROSERIE AS SERIE, dbo.CLIENTES.NOMBREFANTASIA, CONVERT(CHAR(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103) AS FECHAREGISTROCOB   " & _
                        "FROM dbo.VENTASFORMACOBRO INNER JOIN dbo.MONEDA ON dbo.VENTASFORMACOBRO.CODMONEDA = dbo.MONEDA.CODMONEDA INNER JOIN " & _
                        "dbo.CLIENTES ON dbo.VENTASFORMACOBRO.CODCLIENTECAB = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN  " & _
                        "dbo.VENTAS ON dbo.VENTASFORMACOBRO.CODVENTA = dbo.VENTAS.CODVENTA LEFT OUTER JOIN  " & _
                        "dbo.CATEGORIACLIENTE ON dbo.CLIENTES.CODCATEGORIACLIENTE = dbo.CATEGORIACLIENTE.CODCATEGORIACLIENTE  " & _
                        "WHERE (dbo.VENTASFORMACOBRO.CODTIPOCOBRO <> 8) AND  (dbo.VENTASFORMACOBRO.DESTIPOCOBRO <> 'Nota de Credito') AND (dbo.VENTASFORMACOBRO.DESTIPOCOBRO <> 'Nota de Crédito') "

            FormatF1 = calcularcmbTipoFactura(cmbTipo)
            FormatF2 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "CLIENTES.CODTIPOCLIENTE", FormatF3, "CATEGORIACLIENTE.CODCATEGORIACLIENTE", "%", "", "CodigoIn", "CodigoIn", "CodigoIn NULL", "Numero Text")

            Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText = "SELECT  VENTASFORMACOBRO.FECHAREGISTROCOB, VENTASFORMACOBRO.CODCOBRO, VENTASFORMACOBRO.DESTIPOCOBRO, MONEDA.SIMBOLO, " & _
                      "(VENTASFORMACOBRO.IMPORTE / dbo.VENTASFORMACOBRO.COTIZACION1) AS IMPORTE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, CLIENTES.CODCLIENTE, VENTASFORMACOBRO.NRORECIBO " & _
            "FROM      VENTASFORMACOBRO INNER JOIN " & _
                       "MONEDA ON VENTASFORMACOBRO.CODMONEDA = MONEDA.CODMONEDA INNER JOIN " & _
                       "VENTAS ON VENTASFORMACOBRO.CODVENTA = VENTAS.CODVENTA INNER JOIN " & _
                       "CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE  LEFT OUTER JOIN " & _
                       "CATEGORIACLIENTE ON CLIENTES.CODCATEGORIACLIENTE = CATEGORIACLIENTE.CODCATEGORIACLIENTE " & _
            "WHERE  ((VENTASFORMACOBRO.DESTIPOCOBRO = 'Nota de Credito') OR (VENTASFORMACOBRO.DESTIPOCOBRO = 'Nota de Crédito')) AND VENTASFORMACOBRO.NRORECIBO <> '' AND VENTASFORMACOBRO.NRORECIBO <> '0' "


            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvCobrosClientesTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "')  GROUP BY dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.VENTASFORMACOBRO.RECIBONROSERIE, dbo.CLIENTES.NOMBREFANTASIA, CONVERT(CHAR(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103)"
                        Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                    Else
                        Me.RvCobrosClientesTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') GROUP BY dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.VENTASFORMACOBRO.RECIBONROSERIE, dbo.CLIENTES.NOMBREFANTASIA, CONVERT(CHAR(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103)"
                        Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                        End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvCobrosClientesTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') GROUP BY dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.VENTASFORMACOBRO.RECIBONROSERIE, dbo.CLIENTES.NOMBREFANTASIA, CONVERT(CHAR(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103)"
                        Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                    Else
                        Me.RvCobrosClientesTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') GROUP BY dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.VENTASFORMACOBRO.RECIBONROSERIE, dbo.CLIENTES.NOMBREFANTASIA, CONVERT(CHAR(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103)"
                        Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                        End If
                    End If
                Me.RvCobrosClientesTableAdapter.Fill(DsRVCobros.RVCobrosClientes)
                Me.RvCobrosClientesNCTableAdapter.Fill(DsRVCobros.RVCobrosClientesNC)
                GoTo variosclientes
            ElseIf cmbCliente.Text = "%" Then
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvCobrosClientesTableAdapter.selectcommand.CommandText += " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') GROUP BY dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.VENTASFORMACOBRO.RECIBONROSERIE, dbo.CLIENTES.NOMBREFANTASIA, CONVERT(CHAR(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103)"
                    Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText += " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "')  ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                Else
                    Me.RvCobrosClientesTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') GROUP BY dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.VENTASFORMACOBRO.RECIBONROSERIE, dbo.CLIENTES.NOMBREFANTASIA, CONVERT(CHAR(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103)"
                    Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "')  ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                    End If

                Me.RvCobrosClientesTableAdapter.Fill(DsRVCobros.RVCobrosClientes)
                Me.RvCobrosClientesNCTableAdapter.Fill(DsRVCobros.RVCobrosClientesNC)
                Dim rpt As New Reportes.VentasReciboClientes
                Dim rptmat As New Reportes.VentasReciboClientesMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVCobros])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                    txt.Width = 0 ' No mostramos NUMCLIENTE2

                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtTipo", cmbTipo.Text)
                        End If
                    If cmbListaPrecio.Text = "%" Then
                        rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
                        End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                        End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVCobros])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                    txt.Width = 0 ' No mostramos NUMCLIENTE2

                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtTipo", cmbTipo.Text)
                        End If
                    If cmbListaPrecio.Text = "%" Then
                        rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
                        End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                        End If

                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                    End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                        End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                        End If
                    CrystalReportViewer.Refresh()
                    End If
            Else ' Un Solo Cliente
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvCobrosClientesTableAdapter.selectcommand.CommandText += " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') AND CLIENTES.CODCLIENTE = " & cmbCliente.SelectedValue & " GROUP BY dbo.VENTASFORMACOBRO.CABCOBRO, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.RECIBONROSERIE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTASFORMACOBRO.FECHAREGISTROCOB ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                    Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText += " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') AND CLIENTES.CODCLIENTE = " & cmbCliente.SelectedValue & " ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                Else
                    Me.RvCobrosClientesTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') AND CLIENTES.CODCLIENTE = " & cmbCliente.SelectedValue & " GROUP BY dbo.VENTASFORMACOBRO.CABCOBRO, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.RECIBONROSERIE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTASFORMACOBRO.FECHAREGISTROCOB ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                    Me.RvCobrosClientesNCTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') AND CLIENTES.CODCLIENTE = " & cmbCliente.SelectedValue & " ORDER BY VENTASFORMACOBRO.FECHAREGISTROCOB,CLIENTES.NOMBRE"
                    End If

                Me.RvCobrosClientesTableAdapter.Fill(DsRVCobros.RVCobrosClientes)
                Me.RvCobrosClientesNCTableAdapter.Fill(DsRVCobros.RVCobrosClientesNC)
variosclientes:
                Dim rpt As New Reportes.VentasReciboClientes
                Dim rptmat As New Reportes.VentasReciboClientesMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVCobros])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                        txt.Width = 0 ' No mostramos NUMCLIENTE2

                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    Else
                        rptmat.SetParameterValue("pmtCliente", "") ' Se va a mostrar NUMCLIENTE2
                        End If

                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtTipo", cmbTipo.Text)
                        End If
                    If cmbListaPrecio.Text = "%" Then
                        rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
                        End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                        End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVCobros])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                        txt.Width = 0 ' No mostramos NUMCLIENTE2

                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    Else
                        rpt.SetParameterValue("pmtCliente", "") ' Se va a mostrar NUMCLIENTE2
                        End If

                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtTipo", cmbTipo.Text)
                        End If
                    If cmbListaPrecio.Text = "%" Then
                        rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
                        End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                        End If

                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                    End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                        End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                        End If
                    CrystalReportViewer.Refresh()
                    End If
                End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptRecibosClientesDet()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            'Volvemos al SelectCommand original del Table Adapter (sin las condiciones de esta instancia)"
            Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText = "SELECT MONEDA.SIMBOLO, SUM(VENTASFORMACOBRO.IMPORTE / VENTASFORMACOBRO.COTIZACION1) AS IMPORTE, CLIENTES.NUMCLIENTE, CLIENTES.CODCLIENTE, " & _
                         "VENTASFORMACOBRO.NRORECIBO + ' ' + ISNULL(VENTASFORMACOBRO.RECIBONROSERIE, '') AS RECIBOSERIE, CLIENTES.NOMBREFANTASIA, " & _
                         "VENTASFORMACOBRO.FECHAREGISTROCOB, VENTAS.NOMBRECLIENTE AS NOMBRE, VENTASFORMACOBRO.OBSERVACIONES, " & _
                         "VENTASFORMACOBRO.CH_NROCHEQUE, VENTASFORMACOBRO.DESTIPOCOBRO, CAJA.NUMEROCAJA, BANCO.DESBANCO, VENTAS.NUMVENTA, " & _
                         "CASE MODALIDADPAGO WHEN 0 THEN 'CONTADO' WHEN 1 THEN 'CREDITO' WHEN 2 THEN 'BONIFICACIÓN' WHEN 3 THEN 'CAMBIO' ELSE 'OTROS' END AS TIPO, " & _
                         "VENTASFORMACOBRO.CABCOBRO, (VENTAS.TOTALVENTA / VENTAS.COTIZACION1) AS TOTALVENTA, VENTAS.FECHAVENTA, VENTASFORMACOBRO.FECHACOBRO, VENTASFORMACOBRO.NUMDEVOLUCION, " & _
                         "VENTASFORMACOBRO.NUMRETENCION, (SELECT (SUM(IMPORTE) / MAX(VENTASFORMACOBRO.COTIZACION1)) AS Expr1 FROM dbo.VENTASFORMACOBRO AS VF WHERE (CODTIPOCOBRO <> 8) AND (dbo.VENTASFORMACOBRO.NRORECIBO = NRORECIBO) " & _
                         "GROUP BY NRORECIBO) AS TOTALRECIBO " & _
                         "FROM dbo.CLIENTES INNER JOIN " & _
                         "dbo.VENTAS ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE RIGHT OUTER JOIN  " & _
                         "dbo.VENTASFORMACOBRO LEFT OUTER JOIN " & _
                         "dbo.MONEDA ON dbo.VENTASFORMACOBRO.CODMONEDA = dbo.MONEDA.CODMONEDA ON " & _
                         "dbo.VENTAS.CODVENTA = dbo.VENTASFORMACOBRO.CODVENTA LEFT OUTER JOIN " & _
                         "dbo.BANCO ON dbo.VENTASFORMACOBRO.CH_TA_TR_CODBANCO = dbo.BANCO.CODBANCO LEFT OUTER JOIN " & _
                         "dbo.aperturas ON dbo.VENTASFORMACOBRO.id_apertura = dbo.aperturas.id_apertura LEFT OUTER JOIN  " & _
                         "dbo.CAJA ON dbo.aperturas.id_caja = dbo.CAJA.NUMCAJA " & _
             "GROUP BY MONEDA.SIMBOLO, CLIENTES.NUMCLIENTE, CLIENTES.CODCLIENTE, VENTASFORMACOBRO.NRORECIBO, VENTASFORMACOBRO.RECIBONROSERIE, " & _
                         "CLIENTES.NOMBREFANTASIA, VENTASFORMACOBRO.FECHAREGISTROCOB, VENTAS.NOMBRECLIENTE, VENTASFORMACOBRO.OBSERVACIONES, " & _
                         "VENTASFORMACOBRO.CH_NROCHEQUE, VENTASFORMACOBRO.DESTIPOCOBRO, CAJA.NUMEROCAJA, BANCO.DESBANCO, VENTAS.NUMVENTA, " & _
                         "VENTASFORMACOBRO.CABCOBRO, VENTAS.MODALIDADPAGO, VENTAS.TOTALVENTA, VENTAS.FECHAVENTA, VENTASFORMACOBRO.FECHACOBRO, " & _
                         "VENTASFORMACOBRO.CODTIPOCOBRO, VENTASFORMACOBRO.NUMDEVOLUCION, VENTASFORMACOBRO.NUMRETENCION, VENTAS.COTIZACION1  " & _
             "HAVING     (VENTASFORMACOBRO.CODTIPOCOBRO <> 5) "

            FormatF1 = calcularcmbTipoFactura(cmbTipo)
            FormatF2 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.MODALIDADPAGO", FormatF2, "CLIENTES.CODTIPOCLIENTE", FormatF3, "CLIENTES.CODCATEGORIACLIENTE", "%", "", "CodigoIn", "CodigoIn", "CodigoIn NULL", "Numero Text")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText += " AND dbo.CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")  AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, dbo.CLIENTES.NOMBREFANTASIA"
                    Else
                        Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, dbo.CLIENTES.NOMBREFANTASIA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, dbo.CLIENTES.NOMBREFANTASIA"
                    Else
                        Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, dbo.CLIENTES.NOMBREFANTASIA"
                    End If
                End If
                Me.RvCobrosClientesTableAdapter.Fill(DsRVCobros.RVCobrosClientes)
                GoTo variosclientes
            ElseIf cmbCliente.Text = "%" Then
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText += " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, dbo.CLIENTES.NOMBREFANTASIA"
                Else
                    Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') ORDER BY dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, dbo.CLIENTES.NOMBREFANTASIA"
                End If

                Me.RvRecibosClienteDetTableAdapter.Fill(DsRVCobros.RVRecibosClienteDet)

                Dim rpt As New Reportes.VentasReciboClientesDetallado
                Dim rptmat As New Reportes.VentasReciboClientesDetalladoMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVCobros])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                    txt.Width = 0 ' No mostramos NUMCLIENTE2

                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtTipo", cmbTipo.Text)
                    End If
                    If cmbListaPrecio.Text = "%" Then
                        rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVCobros])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                    txt.Width = 0 ' No mostramos NUMCLIENTE2

                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtTipo", cmbTipo.Text)
                    End If
                    If cmbListaPrecio.Text = "%" Then
                        rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            Else ' Un Solo Cliente
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText += " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') AND CLIENTES.CODCLIENTE = " & cmbCliente.SelectedValue & " ORDER BY dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, dbo.CLIENTES.NOMBREFANTASIA"
                Else
                    Me.RvRecibosClienteDetTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTASFORMACOBRO.FECHAREGISTROCOB >= '" & fechadesde2 & "') AND (VENTASFORMACOBRO.FECHAREGISTROCOB <= '" & fechahasta2 & "') AND CLIENTES.CODCLIENTE = " & cmbCliente.SelectedValue & " ORDER BY dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, dbo.CLIENTES.NOMBREFANTASIA"
                End If

                Me.RvRecibosClienteDetTableAdapter.Fill(DsRVCobros.RVRecibosClienteDet)
variosclientes:
                Dim rpt As New Reportes.VentasReciboClientesDetallado
                Dim rptmat As New Reportes.VentasReciboClientesDetalladoMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVCobros])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                        txt.Width = 0 ' No mostramos NUMCLIENTE2

                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    Else
                        rptmat.SetParameterValue("pmtCliente", "") ' Se va a mostrar NUMCLIENTE2
                    End If

                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtTipo", cmbTipo.Text)
                    End If
                    If cmbListaPrecio.Text = "%" Then
                        rptmat.SetParameterValue("pmtListaPrecio", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVCobros])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")
                        txt.Width = 0 ' No mostramos NUMCLIENTE2

                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    Else
                        rpt.SetParameterValue("pmtCliente", "") ' Se va a mostrar NUMCLIENTE2
                    End If

                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtTipo", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtTipo", cmbTipo.Text)
                    End If
                    If cmbListaPrecio.Text = "%" Then
                        rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub IVAVentasComprobantesDetallado()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RVIVADetalladoTableAdapter.selectcommand.CommandText = "SELECT VENTAS.FECHAVENTA AS FECHA, CASE dbo.VENTAS.MODALIDADPAGO WHEN 0 THEN 'VTA_CONT' WHEN 1 THEN 'VTA_CRED' WHEN 2 THEN 'BONIF.' WHEN 3 THEN 'CAMBIO' WHEN 4 THEN 'OTROS' END " & _
                         "AS TIPO,  SUBSTRING(dbo.VENTAS.NUMVENTA, 8, LEN(dbo.VENTAS.NUMVENTA) - 7) AS NUMVENTA, CLIENTES.NUMCLIENTE, VENTAS.NOMBRECLIENTE, " & _
                         "MONEDA.SIMBOLO, CASE IVA WHEN 10 THEN SUM(dbo.VENTASDETALLE.IMPORTEGRABADODIEZ) - SUM(dbo.VENTASDETALLE.IMPORTEGRABADODIEZ) " & _
                         "/ 11 WHEN 5 THEN SUM(dbo.VENTASDETALLE.IMPORTEGRABADOCINCO) - SUM(dbo.VENTASDETALLE.IMPORTEGRABADOCINCO) / 21 END AS NETO, " & _
                         "TIPOCLIENTE.NUMTIPOCLIENTE, CLIENTES.NOMBREFANTASIA, VENTASDETALLE.IVA, VENTAS.CODCLIENTE, SUM(VENTASDETALLE.IMPORTEGRABADODIEZ) " & _
                         "/ 11 AS IVA10, SUM(VENTASDETALLE.IMPORTEGRABADOCINCO) / 21 AS IVA5, VENTAS.CODVENTA, SUM(VENTASDETALLE.IMPORTEGRABADODIEZ) " & _
                         "AS TOTALGRAB10, SUM(VENTASDETALLE.IMPORTEGRABADOCINCO) AS TOTALGRAV5 " & _
            "FROM            VENTAS LEFT OUTER JOIN " & _
                         "VENDEDOR ON VENTAS.CODVENDEDOR = VENDEDOR.CODVENDEDOR INNER JOIN " & _
                         "SUCURSAL ON VENTAS.CODSUCURSAL = SUCURSAL.CODSUCURSAL INNER JOIN " & _
                         "CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE INNER JOIN " & _
                         "VENTASDETALLE ON VENTAS.CODVENTA = VENTASDETALLE.CODVENTA LEFT OUTER JOIN " & _
                         "MONEDA ON VENTASDETALLE.CODMONEDA = MONEDA.CODMONEDA AND VENTAS.CODMONEDA = MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                         "TIPOCOMPROBANTE ON VENTAS.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE LEFT OUTER JOIN " & _
                         "TIPOCLIENTE ON CLIENTES.CODTIPOCLIENTE = TIPOCLIENTE.CODTIPOCLIENTE " & _
            "WHERE      (dbo.VENTASDETALLE.IVA <> 0) "

            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String
            If chbxCodCliente.Checked = True Then
                FormatF1 = "%"
                sqlwhere = obtenerwhere(FormatF1, "", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "Cadena Text", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn NULL")
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RVIVADetalladoTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.VENTAS.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTAS.MODALIDADPAGO, dbo.VENTASDETALLE.IVA, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.CODVENTA ORDER BY NUMVENTA"
                    Else
                        Me.RVIVADetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.VENTAS.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTAS.MODALIDADPAGO, dbo.VENTASDETALLE.IVA, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.CODVENTA ORDER BY NUMVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RVIVADetalladoTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.VENTAS.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTAS.MODALIDADPAGO, dbo.VENTASDETALLE.IVA, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.CODVENTA ORDER BY NUMVENTA"
                    Else
                        Me.RVIVADetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.VENTAS.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTAS.MODALIDADPAGO, dbo.VENTASDETALLE.IVA, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.CODVENTA ORDER BY NUMVENTA"
                    End If
                End If
                Me.RVIVADetalladoTableAdapter.Fill(DsRVComprobantes.RVIVADETALLADO)
                '  Dim dt As DataTable = RVIVADetalladoTableAdapter.GetData()
                GoTo Parametros
            Else
                FormatF1 = FormatearFiltroCombo(cmbCliente, "SV")
                sqlwhere = obtenerwhere(FormatF1, "CLIENTES.CODCLIENTE", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "Numero Text", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn NULL")
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RVIVADetalladoTableAdapter.selectcommand.CommandText += " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.VENTAS.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTAS.MODALIDADPAGO, dbo.VENTASDETALLE.IVA, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.CODVENTA ORDER BY FECHA, NUMVENTA"
                Else
                    Me.RVIVADetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.VENTAS.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTAS.MODALIDADPAGO, dbo.VENTASDETALLE.IVA, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.CODVENTA ORDER BY FECHA, NUMVENTA"
                End If
                Me.RVIVADetalladoTableAdapter.Fill(DsRVComprobantes.RVIVADETALLADO)
                ' Dim dt As DataTable = RVIVADetalladoTableAdapter.GetData()
Parametros:
                Dim rpt As New Reportes.VentasIVAComprobantesDetallado
                Dim rptmat As New Reportes.VentasIVAComprobantesDetalladoMATR

                If chbxMatricial.Checked = True Then
                    txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                        txt.Width = 0
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rptmat.SetParameterValue("pmtCliente", "")
                    End If

                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "" + cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                        txt.Width = 0
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rpt.SetParameterValue("pmtCliente", "")
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", " " + cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If

                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub IVAVentasNCreditoDesStockDetallado()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvivancventasTableAdapter.selectcommand.CommandText = "SELECT DEV.FECHADEVOLUCION AS FECHA, SUBSTRING(DEV.NUMDEVOLUCION, LEN(DEV.NUMDEVOLUCION) - 6, 7) AS NUMDEVOLUCION,  " & _
                         "dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.MONEDA.SIMBOLO,  " & _
                         "CASE DEV.TIPODEVOLUCION WHEN 'Devolución' THEN 'NC_DEVOL' WHEN 'Bonificación' THEN 'NC_BONIF' WHEN 'Por Cambio' THEN 'NC_CAMBIO' END AS TIPO,  " & _
                         "CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) " & _
                         "- SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA)  " & _
                         "/ 11 WHEN 5 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) " & _
                         "- SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) / 21 END AS NETO, dbo.TIPOCLIENTE.NUMTIPOCLIENTE,  " & _
                         "dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, " & _
                         "CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) / 11 END AS IVA10,  " & _
                         "CASE IVA WHEN 5 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) / 21 END AS IVA5,  " & _
                         "DEV.CODDEVOLUCION, CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA)  " & _
                         "END AS TOTALGRAB10, CASE IVA WHEN 5 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA)  " & _
                         "END AS TOTALGRAV5  " & _
            "FROM            dbo.DEVOLUCION AS DEV LEFT OUTER JOIN " & _
                         "dbo.VENDEDOR ON DEV.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR INNER JOIN  " & _
                         "dbo.SUCURSAL ON DEV.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN  " & _
                         "dbo.CLIENTES ON DEV.CODCLIENTE = dbo.CLIENTES.CODCLIENTE INNER JOIN   " & _
                         "dbo.DEVOLUCIONDETALLE ON DEV.CODDEVOLUCION = dbo.DEVOLUCIONDETALLE.CODDEVOLUCION LEFT OUTER JOIN   " & _
                         "dbo.VENTAS ON DEV.CODVENTA = dbo.VENTAS.CODVENTA LEFT OUTER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON DEV.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE LEFT OUTER JOIN   " & _
                         "dbo.MONEDA ON dbo.VENTAS.CODMONEDA = dbo.MONEDA.CODMONEDA AND DEV.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN   " & _
                         "dbo.TIPOCLIENTE ON dbo.CLIENTES.CODTIPOCLIENTE = dbo.TIPOCLIENTE.CODTIPOCLIENTE   " & _
            "WHERE      (DEV.ESTADO = 1) AND (dbo.DEVOLUCIONDETALLE.DESCARTAR = 1) AND (dbo.DEVOLUCIONDETALLE.IVA <> 0) "

            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbConTexto(cmbTipo, "DEV.TIPODEVOLUCION", "SI")
            Dim sqlwhere As String
            If chbxCodCliente.Checked = True Then
                FormatF1 = "%"
                sqlwhere = obtenerwhere(FormatF1, "", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "Cadena Text", "CodigoIn", "CodigoIn", "Especial")
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                    Else
                        Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                    Else
                        Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                    End If
                End If
                Me.RvivancventasTableAdapter.Fill(DsRVNotasCredito.RVIVANCVENTAS)
                GoTo Parametros
            Else
                FormatF1 = FormatearFiltroCombo(cmbCliente, "SV")
                sqlwhere = obtenerwhere(FormatF1, "CLIENTES.CODCLIENTE", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "Numero Text", "CodigoIn", "CodigoIn", "Especial")
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                Else
                    Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                End If
                Me.RvivancventasTableAdapter.Fill(DsRVNotasCredito.RVIVANCVENTAS)
Parametros:
                Dim rpt As New Reportes.VentasIVANCreditoDetallado
                Dim rptmat As New Reportes.VentasIVANCreditoDetalladoMATR

                If chbxMatricial.Checked = True Then
                    txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rptmat.SetDataSource([DsRVNotasCredito])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                        txt.Width = 0
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rptmat.SetParameterValue("pmtCliente", "")
                    End If

                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "Con Ingreso a Stock")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "Con Ingreso a Stock / " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "Con Ingreso a Stock")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "Con Ingreso a Stock / " + cmbTipo.Text)
                        End If
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rpt.SetDataSource([DsRVNotasCredito])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                        txt.Width = 0
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rpt.SetParameterValue("pmtCliente", "")
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "Con Ingreso a Stock")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "Con Ingreso a Stock" + " / " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "Con Ingreso a Stock")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "Con Ingreso a Stock" + " / " + cmbTipo.Text)
                        End If
                    End If

                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub IVAVentasNCreditoDetallado()
        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvivancventasTableAdapter.selectcommand.CommandText = "SELECT DEV.FECHADEVOLUCION AS FECHA, SUBSTRING(DEV.NUMDEVOLUCION, LEN(DEV.NUMDEVOLUCION) - 7, 9) AS NUMDEVOLUCION,  " & _
                         "dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.MONEDA.SIMBOLO,  " & _
                         "CASE DEV.TIPODEVOLUCION WHEN 'Devolución' THEN 'NC_DEVOL' WHEN 'Bonificación' THEN 'NC_BONIF' WHEN 'Por Cambio' THEN 'NC_CAMBIO' END AS TIPO,  " & _
                         "CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) " & _
                         "- SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA)  " & _
                         "/ 11 WHEN 5 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) " & _
                         "- SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) / 21 END AS NETO, dbo.TIPOCLIENTE.NUMTIPOCLIENTE,  " & _
                         "dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, " & _
                         "CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) / 11 END AS IVA10,  " & _
                         "CASE IVA WHEN 5 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) / 21 END AS IVA5,  " & _
                         "DEV.CODDEVOLUCION, CASE IVA WHEN 10 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA)  " & _
                         "END AS TOTALGRAB10, CASE IVA WHEN 5 THEN SUM(dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA)  " & _
                         "END AS TOTALGRAV5  " & _
            "FROM            dbo.DEVOLUCION AS DEV LEFT OUTER JOIN " & _
                         "dbo.VENDEDOR ON DEV.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR INNER JOIN  " & _
                         "dbo.SUCURSAL ON DEV.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN  " & _
                         "dbo.CLIENTES ON DEV.CODCLIENTE = dbo.CLIENTES.CODCLIENTE INNER JOIN   " & _
                         "dbo.DEVOLUCIONDETALLE ON DEV.CODDEVOLUCION = dbo.DEVOLUCIONDETALLE.CODDEVOLUCION LEFT OUTER JOIN   " & _
                         "dbo.VENTAS ON DEV.CODVENTA = dbo.VENTAS.CODVENTA LEFT OUTER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON DEV.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE LEFT OUTER JOIN   " & _
                         "dbo.MONEDA ON dbo.VENTAS.CODMONEDA = dbo.MONEDA.CODMONEDA AND DEV.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN   " & _
                         "dbo.TIPOCLIENTE ON dbo.CLIENTES.CODTIPOCLIENTE = dbo.TIPOCLIENTE.CODTIPOCLIENTE   " & _
            "WHERE       (DEV.ESTADO = 1) AND (dbo.DEVOLUCIONDETALLE.DESCARTAR = 0) AND (dbo.DEVOLUCIONDETALLE.IVA <> 0) "

            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbConTexto(cmbTipo, "DEV.TIPODEVOLUCION", "SI")
            Dim sqlwhere As String
            If chbxCodCliente.Checked = True Then
                FormatF1 = "%"
                sqlwhere = obtenerwhere(FormatF1, "", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "Cadena Text", "CodigoIn", "CodigoIn", "Especial")
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                    Else
                        Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                    Else
                        Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                    End If
                End If
                Me.RvivancventasTableAdapter.Fill(DsRVNotasCredito.RVIVANCVENTAS)
                GoTo Parametros
            Else
                FormatF1 = FormatearFiltroCombo(cmbCliente, "SV")
                sqlwhere = obtenerwhere(FormatF1, "CLIENTES.CODCLIENTE", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "Numero Text", "CodigoIn", "CodigoIn", "Especial")
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                Else
                    Me.RvivancventasTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (DEV.ESTADO = 1) AND (DEV.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEV.FECHADEVOLUCION <= '" & fechahasta2 & "') GROUP BY DEV.FECHADEVOLUCION, DEV.NUMDEVOLUCION, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, DEV.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCIONDETALLE.IVA, DEV.CODCLIENTE, DEV.CODDEVOLUCION, DEV.TIPODEVOLUCION ORDER BY FECHA, NUMDEVOLUCION"
                End If
                Me.RvivancventasTableAdapter.Fill(DsRVNotasCredito.RVIVANCVENTAS)
Parametros:
                Dim rpt As New Reportes.VentasIVANCreditoDetallado
                Dim rptmat As New Reportes.VentasIVANCreditoDetalladoMATR

                If chbxMatricial.Checked = True Then
                    txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rptmat.SetDataSource([DsRVNotasCredito])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                        txt.Width = 0
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rptmat.SetParameterValue("pmtCliente", "")
                    End If

                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "Sin Ingreso a Stock")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "Sin Ingreso a Stock" + "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "Sin Ingreso a Stock")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "Sin Ingreso a Stock" + " / " + cmbTipo.Text)
                        End If
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                    rpt.SetDataSource([DsRVNotasCredito])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                        txt.Width = 0
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rpt.SetParameterValue("pmtCliente", "")
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "Sin Ingreso a Stock")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "Sin Ingreso a Stock " + "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "Sin Ingreso a Stock")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "Sin Ingreso a Stock " + "/ " + cmbTipo.Text)
                        End If
                    End If

                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub VentasPorVendedorDetalle()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText = "SELECT dbo.VENTAS.FECHAVENTA AS FECHA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA AS NOMBRECLIENTE, " & _
            "dbo.VENTAS.COTIZACION1, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.MONEDA.SIMBOLO, dbo.VENTAS.TOTALIVA, dbo.VENTAS.TOTALVENTA, CLIENTES.NOMBREFANTASIA, VENDEDOR.CODVENDEDOR, VENDEDOR.DESVENDEDOR, dbo.VENTAS.MODALIDADPAGO " & _
            "FROM         dbo.VENTAS LEFT OUTER JOIN " & _
                         "dbo.VENDEDOR ON dbo.VENTAS.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                         "dbo.SUCURSAL ON dbo.VENTAS.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.MONEDA ON dbo.VENTAS.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                         "dbo.TIPOCLIENTE ON dbo.CLIENTES.CODTIPOCLIENTE = dbo.TIPOCLIENTE.CODTIPOCLIENTE LEFT OUTER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE "

            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")

            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY dbo.VENDEDOR.DESVENDEDOR, FECHA"
            Else
                Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY dbo.VENDEDOR.DESVENDEDOR, FECHA"
            End If
            Me.RvComprobantesResumidoTableAdapter.Fill(DsRVFacturacion.RVComprobantesResumido)

            Dim rpt As New Reportes.VentasPorVendedorDetalle
            Dim rptmat As New Reportes.VentasPorVendedorDetalleMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVFacturacion])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "Ventas Por Vendedor " + cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "Ventas Por Vendedor " + cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                If rbIVASI.Checked = True Then
                    rptmat.SetParameterValue("pmtIVA", "Si")
                Else
                    rptmat.SetParameterValue("pmtIVA", "No")
                End If
               
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVFacturacion])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "Ventas Por Vendedor " + cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", "Ventas Por Vendedor " + cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                If rbIVASI.Checked = True Then
                    rptmat.SetParameterValue("pmtIVA", "Si")
                Else
                    rptmat.SetParameterValue("pmtIVA", "No")
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComprobantesVentasResumido()

        Try
            Dim fechadesde2, fechahasta2, anulados As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText = "SELECT dbo.VENTAS.FECHAVENTA AS FECHA, SUBSTRING(dbo.VENTAS.NUMVENTA, 9, LEN(dbo.VENTAS.NUMVENTA) - 8) AS NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENTAS.NOMBRECLIENTE, " & _
            "isnull(dbo.VENTAS.COTIZACION1,1) as COTIZACION1, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.MONEDA.SIMBOLO,dbo.VENTAS.TOTAL10+dbo.VENTAS.TOTAL5 as TOTALIVA,dbo.VENTAS.TOTAL10,dbo.VENTAS.TOTAL5,dbo.VENTAS.TOTALGRAVADO5, dbo.VENTAS.TOTALVENTA, CLIENTES.NOMBREFANTASIA, VENDEDOR.CODVENDEDOR, VENDEDOR.DESVENDEDOR, dbo.VENTAS.TIPOVENTA, dbo.VENTAS.MOTIVOANULADO, dbo.VENTAS.CODPRESUPUESTO " & _
            "FROM         dbo.VENTAS LEFT OUTER JOIN " & _
                         "dbo.VENDEDOR ON dbo.VENTAS.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                         "dbo.SUCURSAL ON dbo.VENTAS.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.MONEDA ON dbo.VENTAS.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                         "dbo.TIPOCLIENTE ON dbo.CLIENTES.CODTIPOCLIENTE = dbo.TIPOCLIENTE.CODTIPOCLIENTE LEFT OUTER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE "

            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")

            Dim sqlwhere As String = obtenerwhere(FormatF1, "dbo.VENDEDOR.CODVENDEDOR", FormatF2, "dbo.SUCURSAL.CODSUCURSAL", FormatF3, "dbo.TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "dbo.VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "dbo.CLIENTES.CODCATEGORIACLIENTE", "CodigoIn NULL")
            If rbtConanuladas.Checked = True Then
                anulados = "dbo.VENTAS.ESTADO <> 0"
            Else
                anulados = "dbo.VENTAS.MOTIVOANULADO IS NULL"
            End If
            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)

                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (" & anulados & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (dbo.CLIENTES.NUMCLIENTE <> 0) AND (NOT(dbo.VENTAS.NUMVENTA IS NULL)) AND ((dbo.VENTAS.CODPRESUPUESTO IS NULL) OR (dbo.VENTAS.CODPRESUPUESTO = 0)) ORDER BY NUMVENTA"
                    Else
                        Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (" + sqlwhere + ") AND ('" & anulados & "') AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (dbo.CLIENTES.NUMCLIENTE <> 0)) AND (dbo.VENTAS.CODPRESUPUESTO IS NULL) OR (dbo.VENTAS.CODPRESUPUESTO = 0) ORDER BY NUMVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (" & anulados & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND (CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & ") AND (dbo.CLIENTES.NUMCLIENTE <> 0) AND (NOT(dbo.VENTAS.NUMVENTA IS NULL)) AND ((dbo.VENTAS.CODPRESUPUESTO IS NULL) OR (dbo.VENTAS.CODPRESUPUESTO = 0)) ORDER BY NUMVENTA"
                    Else
                        Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (" + sqlwhere + ") AND (" & anulados & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND (CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & ") AND (dbo.CLIENTES.NUMCLIENTE <> 0) AND (NOT(dbo.VENTAS.NUMVENTA IS NULL)) AND ((dbo.VENTAS.CODPRESUPUESTO IS NULL) OR (dbo.VENTAS.CODPRESUPUESTO = 0)) ORDER BY NUMVENTA"
                    End If
                End If
                Me.RvComprobantesResumidoTableAdapter.Fill(DsRVFacturacion.RVComprobantesResumido)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (" & anulados & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND (dbo.CLIENTES.NUMCLIENTE <> 0) AND (NOT(dbo.VENTAS.NUMVENTA IS NULL)) AND ((dbo.VENTAS.CODPRESUPUESTO IS NULL) OR (dbo.VENTAS.CODPRESUPUESTO = 0)) ORDER BY NUMVENTA"
                Else
                    Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (" + sqlwhere + ") AND (" & anulados & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND ((dbo.CLIENTES.NUMCLIENTE <> 0 or dbo.CLIENTES.NUMCLIENTE IS NULL)) AND (NOT(dbo.VENTAS.NUMVENTA IS NULL)) AND ((dbo.VENTAS.CODPRESUPUESTO IS NULL) OR (dbo.VENTAS.CODPRESUPUESTO = 0)) ORDER BY NUMVENTA"
                End If
                Me.RvComprobantesResumidoTableAdapter.Fill(DsRVFacturacion.RVComprobantesResumido)
            End If
            Dim rpt As New Reportes.VentasComprobantesResumido
            Dim rptmat As New Reportes.VentasComprobantesResumidoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVFacturacion])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                If rbIVASI.Checked = True Then
                    rptmat.SetParameterValue("pmtIVA", "Si")
                Else
                    rptmat.SetParameterValue("pmtIVA", "No")
                End If
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVFacturacion])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                If rbIVASI.Checked = True Then
                    rpt.SetParameterValue("pmtIVA", "Si")
                Else
                    rpt.SetParameterValue("pmtIVA", "No")
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptFacturasEstado()

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText = "SELECT dbo.VENTAS.FECHAVENTA AS FECHA, SUBSTRING(dbo.VENTAS.NUMVENTA, 8, LEN(dbo.VENTAS.NUMVENTA) - 7) AS NUMVENTA, dbo.CLIENTES.NUMCLIENTE, CASE VENTAS.ESTADO WHEN 1 THEN dbo.VENTAS.NOMBRECLIENTE WHEN 2 THEN 'FACTURA ANULADA DE CLIENTES' END AS NOMBRECLIENTE, " & _
            "dbo.VENTAS.COTIZACION1, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.MONEDA.SIMBOLO, CASE VENTAS.ESTADO WHEN 1 THEN dbo.VENTAS.TOTALIVA WHEN 2 THEN 0 END AS TOTALIVA, CASE VENTAS.ESTADO WHEN 1 THEN dbo.VENTAS.TOTALVENTA WHEN 2 THEN 0 END AS TOTALVENTA, CLIENTES.NOMBREFANTASIA, VENDEDOR.CODVENDEDOR, VENDEDOR.DESVENDEDOR " & _
            "FROM         dbo.VENTAS LEFT OUTER JOIN " & _
                         "dbo.VENDEDOR ON dbo.VENTAS.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                         "dbo.SUCURSAL ON dbo.VENTAS.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.MONEDA ON dbo.VENTAS.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                         "dbo.TIPOCLIENTE ON dbo.CLIENTES.CODTIPOCLIENTE = dbo.TIPOCLIENTE.CODTIPOCLIENTE LEFT OUTER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE "
            FormatF1 = calcularcmbEstado(cmbEstado)
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.ESTADO", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn NULL")
            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") ORDER BY NUMVENTA"
                    Else
                        Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")  ORDER BY NUMVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  ORDER BY NUMVENTA"
                    Else
                        Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " ORDER BY NUMVENTA"
                    End If
                End If
                Me.RvComprobantesResumidoTableAdapter.Fill(DsRVFacturacion.RVComprobantesResumido)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY NUMVENTA"
                Else
                    Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY NUMVENTA"
                End If
                Me.RvComprobantesResumidoTableAdapter.Fill(DsRVFacturacion.RVComprobantesResumido)
            End If
            Dim rpt As New Reportes.VentasComprobantesResumido
            Dim rptmat As New Reportes.VentasComprobantesResumidoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVFacturacion])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                If rbIVASI.Checked = True Then
                    rptmat.SetParameterValue("pmtIVA", "Si")
                Else
                    rptmat.SetParameterValue("pmtIVA", "No")
                End If
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVFacturacion])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                If rbIVASI.Checked = True Then
                    rpt.SetParameterValue("pmtIVA", "Si")
                Else
                    rpt.SetParameterValue("pmtIVA", "No")
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub VentasAgrupPorZonaDetalle()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText = "SELECT dbo.VENTAS.FECHAVENTA AS FECHA, SUBSTRING(dbo.VENTAS.NUMVENTA, 8, LEN(dbo.VENTAS.NUMVENTA) - 7) AS NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENTAS.NOMBRECLIENTE, " & _
            "dbo.VENTAS.COTIZACION1, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.MONEDA.SIMBOLO, dbo.VENTAS.TOTALIVA, dbo.VENTAS.TOTALVENTA, CLIENTES.NOMBREFANTASIA, VENDEDOR.CODVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.CODZONA, ZONA.DESZONA, ZONA.NUMZONA, SUM(dbo.VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD " & _
            "FROM         dbo.VENTAS INNER JOIN " & _
                         "dbo.VENTASDETALLE ON dbo.VENTAS.CODVENTA = dbo.VENTASDETALLE.CODVENTA LEFT OUTER JOIN " & _
                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.VENDEDOR ON dbo.VENTAS.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                         "dbo.SUCURSAL ON dbo.VENTAS.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                         "dbo.MONEDA ON dbo.VENTAS.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                         "dbo.TIPOCLIENTE ON dbo.CLIENTES.CODTIPOCLIENTE = dbo.TIPOCLIENTE.CODTIPOCLIENTE LEFT OUTER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE LEFT OUTER JOIN ZONA ON ZONA.CODZONA = CLIENTES.CODZONA LEFT OUTER JOIN " & _
                         "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                         "PAIS ON PAIS.CODPAIS = CIUDAD.CODPAIS"
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = cmbZona.Text
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "ZONA.DESZONA", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "Cadena Text", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", cmbPais.Text, "PAIS.DESPAIS", "Cadena Text", cmbCiudad.Text, "CIUDAD.DESCIUDAD", "Cadena Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.VENTAS.TOTALIVA, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENDEDOR.CODVENDEDOR, dbo.VENDEDOR.DESVENDEDOR, dbo.CLIENTES.CODZONA, dbo.ZONA.DESZONA, dbo.ZONA.NUMZONA ORDER BY FECHA, NOMBREFANTASIA"
            Else
                Me.RvComprobantesResumidoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CLIENTES.NUMCLIENTE, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.VENTAS.TOTALIVA, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.COTIZACION1, dbo.MONEDA.SIMBOLO, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENDEDOR.CODVENDEDOR, dbo.VENDEDOR.DESVENDEDOR, dbo.CLIENTES.CODZONA, dbo.ZONA.DESZONA, dbo.ZONA.NUMZONA ORDER BY FECHA, NOMBREFANTASIA"
            End If
            Me.RvComprobantesResumidoTableAdapter.Fill(DsRVFacturacion.RVComprobantesResumido)

            Dim rpt As New Reportes.VentasVentasAgrupZonaDetalle
            Dim rptmat As New Reportes.VentasVentasAgrupZonaDetalleMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVFacturacion])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbTipo.Text = "%" Then
                    rptmat.SetParameterValue("pmtComprobante", "")
                Else
                    rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If

                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVFacturacion])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbTipo.Text = "%" Then
                    rpt.SetParameterValue("pmtComprobante", "")
                Else
                    rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If

                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptNCPeriodoPorProducto()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText = "SELECT SUM(CANTIDAD) AS CANTIDAD, SUM(TOTAL) AS TOTAL, CODIGO, PRODUCTO, SUM(COSTO) AS COSTO, SUM(TOTALSINIVA) " & _
                         "AS TOTALSINIVA, CODFAMILIA, DESFAMILIA, CODCLIENTE, NOMBRE, NUMCLIENTE, NOMBREFANTASIA, ESTADO, SUM(DESCARTAR) AS DESCARTAR " & _
            "FROM            (SELECT dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA AS CANTIDAD, " & _
                                                    "dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA AS TOTAL, dbo.CODIGOS.CODIGO, " & _
                                                    "LTRIM(dbo.DEVOLUCIONDETALLE.DESCRIPCION) AS PRODUCTO, CASE WHEN CODIGO IS NULL " & _
                                                    "THEN dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA ELSE dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA " & _
                                                    " * dbo.CODIGOS.PRECIO END AS COSTO, " & _
                                                    "CASE IVA WHEN 10 THEN (dbo.DEVOLUCIONDETALLE.PRECIONETO-dbo.DEVOLUCIONDETALLE.PRECIONETO/11) " & _
                                                    "* dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA WHEN 5 THEN (dbo.DEVOLUCIONDETALLE.PRECIONETO-dbo.DEVOLUCIONDETALLE.PRECIONETO/21) " & _
                                                    "* dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA ELSE dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA " & _
                                                    " END AS TOTALSINIVA, dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.DEVOLUCION.CODCLIENTE, dbo.CLIENTES.NOMBRE, " & _
                                                    " dbo.CLIENTES.NUMCLIENTE,dbo.CLIENTES.CODCATEGORIACLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCION.ESTADO, dbo.DEVOLUCION.CODVENDEDOR, DEVOLUCION.TIPODEVOLUCION, DEVOLUCION.CODSUCURSAL,RUBRO.DESRUBRO, LINEA.DESLINEA, ISNULL(dbo.DEVOLUCIONDETALLE.DESCARTAR,0) AS DESCARTAR " & _
                            "FROM            dbo.DEVOLUCIONDETALLE LEFT OUTER JOIN " & _
                                                    "dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.DEVOLUCIONDETALLE.CODPRODUCTO LEFT OUTER JOIN " & _
                                                    "dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO INNER JOIN " & _
                                                    "dbo.DEVOLUCION ON dbo.DEVOLUCIONDETALLE.CODDEVOLUCION = dbo.DEVOLUCION.CODDEVOLUCION LEFT OUTER JOIN " & _
                                                    "dbo.VENDEDOR ON dbo.DEVOLUCION.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR INNER JOIN " & _
                                                    "dbo.CLIENTES ON dbo.CLIENTES.CODCLIENTE = dbo.DEVOLUCION.CODCLIENTE LEFT OUTER JOIN " & _
                                                    "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                                                    "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                                                    "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA " & _
                                                    "WHERE (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "')) AS SUBCONSULTA " & _
            "GROUP BY CODIGO, PRODUCTO, CODFAMILIA, DESFAMILIA, CODCLIENTE, NOMBRE, NUMCLIENTE, CODCATEGORIACLIENTE, NOMBREFANTASIA, ESTADO,CODVENDEDOR, TIPODEVOLUCION, CODSUCURSAL,DESRUBRO, DESLINEA, DESCARTAR " & _
            "HAVING        (ESTADO = 1)"

            If cmbIngresoStock.Text <> "%" Then
                If cmbIngresoStock.Text = "Con Ingreso a Stock" Then
                    Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND DESCARTAR>0 "
                ElseIf cmbIngresoStock.Text = "Sin Ingreso a Stock" Then
                    Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND DESCARTAR=0 "
                End If
            End If

            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = cmbTipo.Text 'calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "CODVENDEDOR", FormatF2, "CODSUCURSAL", "%", "CODCOMPROBANTE", FormatF4, "TIPODEVOLUCION", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CODCATEGORIACLIENTE", "CodigoIn", cbxCategoria.Text, "DESFAMILIA", "Cadena Text", cbxLinea.Text, "DESLINEA", "Cadena Text", cbxRubro.Text, "DESRUBRO", "Cadena Text")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND NUMCLIENTE IN (" & tbxcodCliente.Text & ") ORDER BY PRODUCTO"
                    Else
                        Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND NUMCLIENTE IN (" & tbxcodCliente.Text & ") ORDER BY PRODUCTO"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " ORDER BY PRODUCTO"
                    Else
                        Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " ORDER BY PRODUCTO"
                    End If
                End If
                Me.RvncPorProductoResumTableAdapter.Fill(DsRVNotasCredito.RVNCPorProductoResum)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = " CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " ORDER BY PRODUCTO"
                Else
                    Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " ORDER BY PRODUCTO"
                End If
                Me.RvncPorProductoResumTableAdapter.Fill(DsRVNotasCredito.RVNCPorProductoResum)
            End If

            If rbSinAgrup.Checked = True Then
                Dim rpt As New Reportes.VentasNCPorProductoResumido
                Dim rptmat As New Reportes.VentasNCPorProductoResumido

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVNotasCredito])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVNotasCredito])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.VentasNCPorProductoResumidoAFam
                Dim rptmat As New Reportes.VentasNCPorProductoResumidoAFam

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVNotasCredito])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVNotasCredito])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptNCPeriodoPorProductoAgrupCli()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText = "SELECT CANTIDAD, TOTAL, CODIGO, PRODUCTO, COSTO, TOTALSINIVA, CODFAMILIA, DESFAMILIA, CODCLIENTE, NOMBRE, NUMCLIENTE, " & _
            "NOMBREFANTASIA, Estado, NUMDEVOLUCION, FECHADEVOLUCION, DESCARTAR " & _
                        "FROM            (SELECT dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA AS CANTIDAD, " & _
                                                    "dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA AS TOTAL, dbo.CODIGOS.CODIGO, " & _
                                                    "LTRIM(dbo.DEVOLUCIONDETALLE.DESCRIPCION) AS PRODUCTO, CASE WHEN CODIGO IS NULL " & _
                                                    "THEN dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA ELSE dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA " & _
                                                    " * dbo.CODIGOS.PRECIO END AS COSTO, " & _
                                                    "CASE IVA WHEN 10 THEN ((dbo.DEVOLUCIONDETALLE.PRECIONETO-dbo.DEVOLUCIONDETALLE.PRECIONETO/11) * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) " & _
                                                    " WHEN 5 THEN ((dbo.DEVOLUCIONDETALLE.PRECIONETO-dbo.DEVOLUCIONDETALLE.PRECIONETO/21) * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) " & _
                                                    " ELSE dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA " & _
                                                    " END AS TOTALSINIVA, dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.DEVOLUCION.CODCLIENTE, dbo.CLIENTES.NOMBRE, " & _
                                                    " dbo.CLIENTES.NUMCLIENTE,dbo.CLIENTES.CODCATEGORIACLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCION.ESTADO, dbo.DEVOLUCION.CODVENDEDOR, DEVOLUCION.TIPODEVOLUCION, DEVOLUCION.CODSUCURSAL,RUBRO.DESRUBRO, LINEA.DESLINEA, dbo.DEVOLUCION.NUMDEVOLUCION, dbo.DEVOLUCION.FECHADEVOLUCION, ISNULL(dbo.DEVOLUCIONDETALLE.DESCARTAR,0) AS DESCARTAR " & _
                            "FROM            dbo.DEVOLUCIONDETALLE LEFT OUTER JOIN " & _
                                                    "dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.DEVOLUCIONDETALLE.CODPRODUCTO LEFT OUTER JOIN " & _
                                                    "dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO INNER JOIN " & _
                                                    "dbo.DEVOLUCION ON dbo.DEVOLUCIONDETALLE.CODDEVOLUCION = dbo.DEVOLUCION.CODDEVOLUCION LEFT OUTER JOIN " & _
                                                    "dbo.VENDEDOR ON dbo.DEVOLUCION.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR INNER JOIN " & _
                                                    "dbo.CLIENTES ON dbo.CLIENTES.CODCLIENTE = dbo.DEVOLUCION.CODCLIENTE LEFT OUTER JOIN " & _
                                                    "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                                                    "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                                                    "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA " & _
                                                    "WHERE (DEVOLUCION.ESTADO=1) AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') "

            If cmbIngresoStock.Text <> "%" Then
                If cmbIngresoStock.Text = "Con Ingreso a Stock" Then
                    Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND DESCARTAR>0 "
                ElseIf cmbIngresoStock.Text = "Sin Ingreso a Stock" Then
                    Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND DESCARTAR=0 "
                End If
            End If

            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = cmbTipo.Text 'calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "CODVENDEDOR", FormatF2, "CODSUCURSAL", "%", "CODCOMPROBANTE", FormatF4, "TIPODEVOLUCION", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CODCATEGORIACLIENTE", "CodigoIn", cbxCategoria.Text, "DESFAMILIA", "Cadena Text", cbxLinea.Text, "DESLINEA", "Cadena Text", cbxRubro.Text, "DESRUBRO", "Cadena Text")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND NUMCLIENTE IN (" & tbxcodCliente.Text & ")) AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                    Else
                        Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND NUMCLIENTE IN (" & tbxcodCliente.Text & ")) AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & ") AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                    Else
                        Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & ") AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                    End If
                End If
                Me.RvncPorProductoResumTableAdapter.Fill(DsRVNotasCredito.RVNCPorProductoResum)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = " CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += ") AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                Else
                    Me.RvncPorProductoResumTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + ") AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                End If
                Me.RvncPorProductoResumTableAdapter.Fill(DsRVNotasCredito.RVNCPorProductoResum)
            End If

            If rbSinAgrup.Checked = True Then
                Dim rpt As New Reportes.VentasNCPorProductoPorCliente
                Dim rptmat As New Reportes.VentasNCPorProductoPorCliente

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVNotasCredito])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVNotasCredito])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If

            Else
                Dim rpt As New Reportes.VentasNCPorProductoPorClienteAFam
                Dim rptmat As New Reportes.VentasNCPorProductoPorClienteAFam

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVNotasCredito])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVNotasCredito])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptNClistadetallado()

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

           
            Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText = "SELECT CANTIDAD, TOTAL, CODIGO, PRODUCTO, COSTO, TOTALDEVOLUCION, DESFAMILIA, CODCLIENTE, NOMBRE, NUMCLIENTE, NOMBREFANTASIA, ESTADO, NUMDEVOLUCION, " & _
                                            " FECHADEVOLUCION, DESCARTAR, DESZONA " & _
                                            " FROM (SELECT dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA AS CANTIDAD, dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA AS TOTAL, dbo.CODIGOS.CODIGO,  " & _
                                            " LTRIM(dbo.DEVOLUCIONDETALLE.DESCRIPCION) AS PRODUCTO, CASE WHEN CODIGO IS NULL THEN dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA ELSE dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA * dbo.CODIGOS.PRECIO END AS COSTO, " & _
                                            " dbo.FAMILIA.DESFAMILIA, dbo.DEVOLUCION.CODCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCION.ESTADO, " & _
                                            " dbo.DEVOLUCION.NUMDEVOLUCION, dbo.DEVOLUCION.FECHADEVOLUCION, dbo.DEVOLUCIONDETALLE.DESCARTAR, dbo.DEVOLUCION.TOTALDEVOLUCION, dbo.ZONA.DESZONA " & _
                                            " FROM dbo.DEVOLUCIONDETALLE LEFT OUTER JOIN dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.DEVOLUCIONDETALLE.CODPRODUCTO LEFT OUTER JOIN  " & _
                                            " dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO INNER JOIN dbo.DEVOLUCION ON dbo.DEVOLUCIONDETALLE.CODDEVOLUCION = dbo.DEVOLUCION.CODDEVOLUCION INNER JOIN " & _
                                            " dbo.CLIENTES ON dbo.CLIENTES.CODCLIENTE = dbo.DEVOLUCION.CODCLIENTE INNER JOIN dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN " & _
                                            " dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA) AS SUBCONSULTA" & _
                                            " WHERE (ESTADO=1) AND (FECHADEVOLUCION >= '" & fechadesde2 & "') AND (FECHADEVOLUCION <= '" & fechahasta2 & "') "

            If cmbIngresoStock.Text <> "%" Then
                If cmbIngresoStock.Text = "Con Ingreso a Stock" Then
                    Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText += " AND DESCARTAR>0 "
                ElseIf cmbIngresoStock.Text = "Sin Ingreso a Stock" Then
                    Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText += " AND DESCARTAR=0 "
                End If
            End If

            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "CODVENDEDOR", FormatF2, "CODSUCURSAL", "%", "CODCOMPROBANTE", FormatF4, "TIPODEVOLUCION", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CODCATEGORIACLIENTE", "CodigoIn", cbxCategoria.Text, "DESFAMILIA", "Cadena Text", cbxLinea.Text, "DESLINEA", "Cadena Text", cbxRubro.Text, "DESRUBRO", "Cadena Text")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText += " AND NUMCLIENTE IN (" & tbxcodCliente.Text & ")) AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                    Else
                        Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND NUMCLIENTE IN (" & tbxcodCliente.Text & ")) AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText += " AND NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & ") AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                    Else
                        Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & ") AS SUBCONSULTA  ORDER BY NUMDEVOLUCION"
                    End If
                End If
                Me.NotaCreditoDetalladoTableAdapter.Fill(DsReporteVentas.NotaCreditoDetallado)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = " CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText += " ORDER BY NUMDEVOLUCION"
                Else
                    Me.NotaCreditoDetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " ORDER BY NUMDEVOLUCION"
                End If
                Me.NotaCreditoDetalladoTableAdapter.Fill(DsReporteVentas.NotaCreditoDetallado)
            End If
            If rbSinAgrup.Checked = True Then
                Dim rpt As New Reportes.VentasNCListaDetallado
                Dim rptmat As New Reportes.VentasNCListaDetallado
                'Me.NotaCreditoDetalladoTableAdapter.Fill(DsReporteVentas.NotaCreditoDetallado)
                'rpt.SetDataSource([DsReporteVentas])

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsReporteVentas])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsReporteVentas])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If

                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.VentasNCListaDetalladoAFam
                Dim rptmat As New Reportes.VentasNCListaDetalladoAFam
                Me.NotaCreditoDetalladoTableAdapter.Fill(DsReporteVentas.NotaCreditoDetallado)
                rpt.SetDataSource([DsReporteVentas])

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsReporteVentas])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsReporteVentas])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComprobantesVentasPorProductoResumido()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantesPorProductoResumTableAdapter.selectcommand.CommandText = "SELECT        SUM(dbo.VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, dbo.CODIGOS.CODIGO, " & _
                         "LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')) " & _
                         "AS PRODUCTO, SUM(dbo.VENTASDETALLE.CANTIDADVENTA) * (CODIGOS.PRECIO) AS COSTO,(SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) - SUM(ROUND((dbo.VENTASDETALLE.IMPORTEGRABADODIEZ / 11),0)) - SUM(ROUND((dbo.VENTASDETALLE.IMPORTEGRABADOCINCO/ 21),0))) AS TOTALSINIVA, dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA " & _
            "FROM            dbo.VENTASDETALLE INNER JOIN " & _
                         "dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                         "dbo.CODIGOS ON VENTASDETALLE.CODCODIGO = CODIGOS.CODCODIGO INNER JOIN " & _
                         "dbo.VENTAS ON dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA INNER JOIN " & _
                         "dbo.CLIENTES ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                         "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                         "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA "
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", cbxCategoria.Text, "FAMILIA.DESFAMILIA", "Cadena Text", cbxLinea.Text, "LINEA.DESLINEA", "Cadena Text", cbxRubro.Text, "RUBRO.DESRUBRO", "Cadena Text")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesPorProductoResumTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO ORDER BY PRODUCTO"
                    Else
                        Me.RvComprobantesPorProductoResumTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO ORDER BY PRODUCTO"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesPorProductoResumTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO ORDER BY PRODUCTO"
                    Else
                        Me.RvComprobantesPorProductoResumTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO ORDER BY PRODUCTO"
                    End If
                End If
                Me.RvComprobantesPorProductoResumTableAdapter.Fill(DsRVComprobantes.RVComprobantesPorProductoResum)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvComprobantesPorProductoResumTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')   GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO ORDER BY PRODUCTO"
                Else
                    Me.RvComprobantesPorProductoResumTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')   GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO ORDER BY PRODUCTO"
                End If
                Me.RvComprobantesPorProductoResumTableAdapter.Fill(DsRVComprobantes.RVComprobantesPorProductoResum)
            End If

            If rbSinAgrup.Checked = True Then
                Dim rpt As New Reportes.VentasComprobantesPorProductoResumido
                Dim rptmat As New Reportes.VentasComprobantesPorProductoResumidoMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.VentasComprobantesPorProductoResumidoAFam
                Dim rptmat As New Reportes.VentasComprobantesPorProductoResumidoAFamMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptLibroIvaVentasLey()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.ContaLibroIvaVentasley
        Dim rptmat As New Reportes.ContaLibroIvaVentasleyMATR
        Dim FechaInicio, FechaFin As String

        FechaInicio = dtpFechaDesde.Text & " 12:00:00 a.m."
        FechaFin = dtpFechaHasta.Text & " 11:59:00 p.m."

        If cmbSucursal.Text = "%" Then
            Me.LibroVentasLeyTableAdapter.Fill(Me.DsReporteVentas.LibroVentasLey, FechaInicio, FechaFin)
        Else
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            Me.LibroVentasLeyTableAdapter.FillBy(Me.DsReporteVentas.LibroVentasLey, FechaInicio, FechaFin, FormatF2)
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsReporteVentas])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

            If cmbSucursal.Text = "%" Then
                rptmat.SetParameterValue("pmtSucursal", "Consolidado")
            Else
                rptmat.SetParameterValue("pmtSucursal", cmbSucursal.Text)
            End If

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsReporteVentas])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

            If cmbSucursal.Text = "%" Then
                rpt.SetParameterValue("pmtSucursal", "Consolidado")
            Else
                rpt.SetParameterValue("pmtSucursal", cmbSucursal.Text)
            End If

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

    Private Sub rptLibroIvaNotasCreditoVentasLey()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.VentasLibroIvaNC
        Dim rptmat As New Reportes.VentasLibroIvaNCMATR
        Dim FechaInicio, FechaFin As String

        FechaInicio = dtpFechaDesde.Text & " 12:00:00 a.m."
        FechaFin = dtpFechaHasta.Text & " 11:59:00 p.m."

        If cmbSucursal.Text = "%" Then
            Me.RvnclibroivaTableAdapter.Fill(Me.DsRVNotasCredito.RVNCLIBROIVA, FechaInicio, FechaFin)
        Else
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            Me.RvnclibroivaTableAdapter.FillBy(Me.DsRVNotasCredito.RVNCLIBROIVA, FechaInicio, FechaFin, FormatF2)
        End If

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsReporteVentas])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

            If cmbSucursal.Text = "%" Then
                rptmat.SetParameterValue("pmtSucursal", "Consolidado")
            Else
                rptmat.SetParameterValue("pmtSucursal", cmbSucursal.Text)
            End If

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rptmat
                CrystalReportViewer.Refresh()
            End If
        Else
            rpt.SetDataSource([DsRVNotasCredito])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)

            If cmbSucursal.Text = "%" Then
                rpt.SetParameterValue("pmtSucursal", "Consolidado")
            Else
                rpt.SetParameterValue("pmtSucursal", cmbSucursal.Text)
            End If

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

    Private Sub ComprobantesVentasPorClientePorProducto()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantePorProductoPorClienteTableAdapter.selectcommand.CommandText = "SELECT        SUM(dbo.VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, dbo.CODIGOS.CODIGO, " & _
                         "LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')) " & _
                         "AS PRODUCTO, SUM(dbo.VENTASDETALLE.CANTIDADVENTA) * (CODIGOS.PRECIO) AS COSTO,(SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) - SUM(ROUND((dbo.VENTASDETALLE.IMPORTEGRABADODIEZ / 11),0)) - SUM(ROUND((dbo.VENTASDETALLE.IMPORTEGRABADOCINCO/ 21),0))) AS TOTALSINIVA, dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA " & _
            "FROM            dbo.VENTASDETALLE INNER JOIN " & _
                         "dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                         "dbo.CODIGOS ON VENTASDETALLE.CODCODIGO = CODIGOS.CODCODIGO INNER JOIN " & _
                         "dbo.VENTAS ON dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA INNER JOIN " & _
                         "dbo.CLIENTES ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                         "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                         "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA "
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", cbxCategoria.Text, "FAMILIA.DESFAMILIA", "Cadena Text", cbxLinea.Text, "LINEA.DESLINEA", "Cadena Text", cbxRubro.Text, "RUBRO.DESRUBRO", "Cadena Text")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantePorProductoPorClienteTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA ORDER BY PRODUCTO"
                    Else
                        Me.RvComprobantePorProductoPorClienteTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA ORDER BY PRODUCTO"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantePorProductoPorClienteTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA ORDER BY PRODUCTO"
                    Else
                        Me.RvComprobantePorProductoPorClienteTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA ORDER BY PRODUCTO"
                    End If
                End If
                Me.RvComprobantePorProductoPorClienteTableAdapter.Fill(DsRVComprobantes.RVComprobantePorProductoPorCliente)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvComprobantePorProductoPorClienteTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')   GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA ORDER BY PRODUCTO"
                Else
                    Me.RvComprobantePorProductoPorClienteTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')   GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, dbo.VENTAS.CODCLIENTE, dbo.VENTAS.NOMBRECLIENTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA ORDER BY PRODUCTO"
                End If
                Me.RvComprobantePorProductoPorClienteTableAdapter.Fill(DsRVComprobantes.RVComprobantePorProductoPorCliente)
            End If

            If rbSinAgrup.Checked = True Then
                Dim rpt As New Reportes.VentasComprobantesPorProductoPorCliente
                Dim rptmat As New Reportes.VentasComprobantesPorProductoPorClienteMATR
                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.VentasComprobantesPorProductoPorClienteAFam
                Dim rptmat As New Reportes.VentasComprobantesPorProductoPorClienteAFamMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComprVentasPorVendedorProductoResumido()

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprPorVendPorProductoTableAdapter.selectcommand.CommandText = "SELECT        SUM(dbo.VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, dbo.CODIGOS.CODIGO, " & _
                         "LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')) " & _
                         "AS PRODUCTO, SUM(dbo.VENTASDETALLE.CANTIDADVENTA) * (CODIGOS.PRECIO) AS COSTO,(SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) - SUM(dbo.VENTASDETALLE.IMPORTEGRABADODIEZ) / 11) - SUM(dbo.VENTASDETALLE.IMPORTEGRABADOCINCO) / 21 AS TOTALSINIVA, dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR " & _
            "FROM            dbo.VENTASDETALLE INNER JOIN " & _
                         "dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                         "dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO INNER JOIN " & _
                         "dbo.VENTAS ON dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA INNER JOIN " & _
                         "dbo.CLIENTES ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE INNER JOIN VENDEDOR ON VENTAS.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                         "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                         "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                         "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA "
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", cbxCategoria.Text, "FAMILIA.DESFAMILIA", "Cadena Text", cbxLinea.Text, "LINEA.DESLINEA", "Cadena Text", cbxRubro.Text, "RUBRO.DESRUBRO", "Cadena Text")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprPorVendPorProductoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR ORDER BY PRODUCTO"
                    Else
                        Me.RvComprPorVendPorProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR ORDER BY PRODUCTO"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprPorVendPorProductoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR ORDER BY PRODUCTO"
                    Else
                        Me.RvComprPorVendPorProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR ORDER BY PRODUCTO"
                    End If
                End If
                Me.RvComprPorVendPorProductoTableAdapter.Fill(DsRVComprobantes.RVComprPorVendPorProducto)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvComprPorVendPorProductoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')   GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR ORDER BY PRODUCTO"
                Else
                    Me.RvComprPorVendPorProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')   GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), dbo.CODIGOS.PRECIO, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR ORDER BY PRODUCTO"
                End If
                Me.RvComprPorVendPorProductoTableAdapter.Fill(DsRVComprobantes.RVComprPorVendPorProducto)
            End If
            If rbSinAgrup.Checked = True Then
                Dim rpt As New Reportes.VentasComprPorVendedorProductoResumido
                Dim rptmat As New Reportes.VentasComprPorVendedorProductoResumidoMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.VentasComprPorVendedorProductoResumidoAFam
                Dim rptmat As New Reportes.VentasComprPorVendedorProductoResumidoAFamMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If

                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComprobantesVentasPorProductoPorFecha()

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantesPorProductoPorFechaTableAdapter.selectcommand.CommandText = "SELECT        SUM(dbo.VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, dbo.CODIGOS.CODIGO, " & _
                         "LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')) " & _
                         "AS PRODUCTO,CONVERT(DATE, VENTAS.FECHAVENTA, 103) AS FECHA, SUM(dbo.VENTASDETALLE.CANTIDADVENTA) * (CODIGOS.PRECIO) AS COSTO,(SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) - SUM(ROUND((dbo.VENTASDETALLE.IMPORTEGRABADODIEZ / 11),0)) - SUM(ROUND((dbo.VENTASDETALLE.IMPORTEGRABADOCINCO/ 21),0))) AS TOTALSINIVA, dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA " & _
            "FROM            dbo.VENTASDETALLE INNER JOIN " & _
                         "dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                         "dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO INNER JOIN " & _
                         "dbo.VENTAS ON dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA INNER JOIN " & _
                         "dbo.CLIENTES ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                         "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                         "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA "

            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", cbxCategoria.Text, "FAMILIA.DESFAMILIA", "Cadena Text", cbxLinea.Text, "LINEA.DESLINEA", "Cadena Text", cbxRubro.Text, "RUBRO.DESRUBRO", "Cadena Text")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesPorProductoPorFechaTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), CONVERT(DATE, VENTAS.FECHAVENTA, 103), dbo.CODIGOS.PRECIO ORDER BY FECHA,PRODUCTO"
                    Else
                        Me.RvComprobantesPorProductoPorFechaTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), CONVERT(DATE, VENTAS.FECHAVENTA, 103), dbo.CODIGOS.PRECIO ORDER BY FECHA,PRODUCTO"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesPorProductoPorFechaTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), CONVERT(DATE, VENTAS.FECHAVENTA, 103), dbo.CODIGOS.PRECIO ORDER BY FECHA,PRODUCTO"
                    Else
                        Me.RvComprobantesPorProductoPorFechaTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), CONVERT(DATE, VENTAS.FECHAVENTA, 103), dbo.CODIGOS.PRECIO ORDER BY FECHA,PRODUCTO"
                    End If
                End If
                Me.RvComprobantesPorProductoPorFechaTableAdapter.Fill(DsRVComprobantes.RVComprobantesPorProductoPorFecha)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvComprobantesPorProductoPorFechaTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')   GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), CONVERT(DATE, VENTAS.FECHAVENTA, 103), dbo.CODIGOS.PRECIO ORDER BY FECHA,PRODUCTO"
                Else
                    Me.RvComprobantesPorProductoPorFechaTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')   GROUP BY dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, dbo.CODIGOS.CODIGO, LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), CONVERT(DATE, VENTAS.FECHAVENTA, 103), dbo.CODIGOS.PRECIO ORDER BY FECHA,PRODUCTO"
                End If
                Me.RvComprobantesPorProductoPorFechaTableAdapter.Fill(DsRVComprobantes.RVComprobantesPorProductoPorFecha)
            End If

            If rbSinAgrup.Checked = True Then
                Dim rpt As New Reportes.VentasComprobantesPorProductoPorFecha
                Dim rptmat As New Reportes.VentasComprobantesPorProductoPorFechaMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If rbIVANO.Checked = True Then
                        rptmat.SetParameterValue("pmtIVA", "NO")
                    Else
                        rptmat.SetParameterValue("pmtIVA", "SI")
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If rbIVANO.Checked = True Then
                        rpt.SetParameterValue("pmtIVA", "NO")
                    Else
                        rpt.SetParameterValue("pmtIVA", "SI")
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.VentasComprobantesPorProductoPorFechaAFam
                Dim rptmat As New Reportes.VentasComprobantesPorProductoPorFechaAFamMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVComprobantes])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rptmat.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtNumCliente", "(Todos)")
                        rptmat.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rptmat.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If rbIVANO.Checked = True Then
                        rptmat.SetParameterValue("pmtIVA", "NO")
                    Else
                        rptmat.SetParameterValue("pmtIVA", "SI")
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If

                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVComprobantes])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtNumCliente", tbxcodCliente.Text)
                        rpt.SetParameterValue("pmtCliente", "")
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtNumCliente", "(Todos)")
                        rpt.SetParameterValue("pmtCliente", "")
                    Else
                        NumCliente = f.FuncionConsultaString("numcliente", "clientes", "codcliente", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", cmbCliente.Text)
                        rpt.SetParameterValue("pmtNumCliente", NumCliente)
                    End If
                    If rbIVANO.Checked = True Then
                        rpt.SetParameterValue("pmtIVA", "NO")
                    Else
                        rpt.SetParameterValue("pmtIVA", "SI")
                    End If
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto")
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " Por Producto " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComprobantesVentas()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantesTableAdapter.selectcommand.CommandText = "SELECT dbo.VENTASDETALLE.CANTIDADVENTA AS CANTIDAD, dbo.VENTASDETALLE.PRECIOVENTABRUTO AS TOTALCONIVA, dbo.VENTASDETALLE.IMPORTEGRABADODIEZ / 11 AS IVA10,  " & _
                         "dbo.VENTASDETALLE.IMPORTEGRABADOCINCO / 21 AS IVA5, dbo.VENTASDETALLE.CANTIDADVENTA * dbo.VENTASDETALLE.COSTOPROMEDIO AS COSTO, dbo.VENTAS.FECHAVENTA, dbo.VENTAS.CODCLIENTE,  " & _
                         "dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA   " & _
                         "FROM  dbo.VENTAS INNER JOIN   " & _
                         "dbo.VENTASDETALLE ON dbo.VENTAS.CODVENTA = dbo.VENTASDETALLE.CODVENTA LEFT OUTER JOIN  " & _
                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN   " & _
                         "dbo.CODIGOS ON dbo.VENTASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO AND dbo.VENTASDETALLE.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO   "

            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")

            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")  ORDER BY FECHAVENTA"
                    Else
                        Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")   ORDER BY FECHAVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "   ORDER BY FECHAVENTA"
                    Else
                        Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  ORDER BY FECHAVENTA"
                    End If
                End If
                Me.RvComprobantesTableAdapter.Fill(DsRVFacturacion.RVComprobantes)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')  ORDER BY FECHAVENTA"
                Else
                    Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')  ORDER BY FECHAVENTA"
                End If
                Me.RvComprobantesTableAdapter.Fill(DsRVFacturacion.RVComprobantes)

            End If

            If rbtDia.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasDia
                Dim rptmat As New Reportes.VentasComprVentasDiaMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnAño.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasAño
                Dim rptmat As New Reportes.VentasComprVentasAñoMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnHora.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasHora
                Dim rptmat As New Reportes.VentasComprVentasHoraMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnQuincena.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasQuincena
                Dim rptmat As New Reportes.VentasComprVentasQuincenaMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnMes.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasMes
                Dim rptmat As New Reportes.VentasComprVentasMesMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnSemana.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasSemana
                Dim rptmat As New Reportes.VentasComprVentasSemanaMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnSemestre.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasSemestre
                Dim rptmat As New Reportes.VentasComprVentasSemestreMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComprobantesVentasAgrupCli()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvComprobantesTableAdapter.selectcommand.CommandText = "SELECT  dbo.VENTASDETALLE.CANTIDADVENTA AS CANTIDAD, dbo.VENTASDETALLE.PRECIOVENTABRUTO AS TOTALCONIVA, " & _
                         "dbo.VENTASDETALLE.IMPORTEGRABADODIEZ / 11 AS IVA10, dbo.VENTASDETALLE.IMPORTEGRABADOCINCO / 21 AS IVA5, " & _
                         "dbo.VENTASDETALLE.CANTIDADVENTA * dbo.CODIGOS.PRECIO AS COSTO, dbo.VENTAS.FECHAVENTA, dbo.VENTAS.CODCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA " & _
            "FROM            dbo.VENTAS INNER JOIN " & _
                         "dbo.VENTASDETALLE ON dbo.VENTAS.CODVENTA = dbo.VENTASDETALLE.CODVENTA LEFT OUTER JOIN " & _
                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.CODIGOS ON dbo.VENTASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO AND " & _
                         "dbo.VENTASDETALLE.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO "
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")  ORDER BY FECHAVENTAVENTA"
                    Else
                        Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")   ORDER BY FECHAVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "   ORDER BY FECHAVENTA"
                    Else
                        Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  ORDER BY FECHAVENTA"
                    End If
                End If
                Me.RvComprobantesTableAdapter.Fill(DsRVFacturacion.RVComprobantes)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')  ORDER BY FECHAVENTA"
                Else
                    Me.RvComprobantesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')  ORDER BY FECHAVENTA"
                End If
                Me.RvComprobantesTableAdapter.Fill(DsRVFacturacion.RVComprobantes)

            End If

            If rbtDia.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasAgrupCliDia
                Dim rptmat As New Reportes.VentasComprVentasAgrupCliDiaMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnAño.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasAgrupCliAño
                Dim rptmat As New Reportes.VentasComprVentasAgrupCliAñoMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnHora.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasAgrupCliHora
                Dim rptmat As New Reportes.VentasComprVentasAgrupCliHoraMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnQuincena.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasAgrupCliQuincena
                Dim rptmat As New Reportes.VentasComprVentasAgrupCliQuincenaMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnMes.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasAgrupCliMes
                Dim rptmat As New Reportes.VentasComprVentasAgrupCliMesMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnSemana.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasAgrupCliSemana
                Dim rptmat As New Reportes.VentasComprVentasAgrupCliSemanaMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnSemestre.Checked = True Then
                Dim rpt As New Reportes.VentasComprVentasAgrupCliSemestre
                Dim rptmat As New Reportes.VentasComprVentasAgrupCliSemestreMATR

                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If chbxCodCliente.Checked = True Then
                        rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rptmat.SetParameterValue("pmtCliente", numcliente)
                    End If
                    If cmbVendedor.Text = "%" Then
                        rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", "")
                        Else
                            rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    If chbxCodCliente.Checked = True Then
                        rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                    ElseIf cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                    Else
                        Dim w As New Funciones.Funciones
                        Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                        rpt.SetParameterValue("pmtCliente", numcliente)
                    End If
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    If cmbVendedor.Text = "%" Then
                        rpt.SetParameterValue("pmtVendedor", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                    End If
                    If cmbSucursal.Text = "%" Then
                        rpt.SetParameterValue("pmtDeposito", "(Todos)")
                    Else
                        rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                    End If

                    If cmbComprobante.Text = "%" Then
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", "")
                        Else
                            rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                        End If
                    Else
                        If cmbTipo.Text = "%" Then
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                        Else
                            rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                        End If
                    End If
                    If cmbCategCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCategCli", "(Todas)")
                    Else
                        rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                    End If
                    rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                    rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptVentasPorCliente()

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvventasporclientesTableAdapter.selectcommand.CommandText = "SELECT  dbo.VENTASDETALLE.CANTIDADVENTA AS CANTIDAD, dbo.VENTASDETALLE.PRECIOVENTABRUTO AS TOTALGS, " & _
                         "dbo.VENTASDETALLE.CANTIDADVENTA * dbo.CODIGOS.PRECIO AS COSTO, dbo.CLIENTES.CODCLIENTE, dbo.CLIENTES.NUMCLIENTE, " & _
                         "dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NOMBREFANTASIA, CASE iva WHEN 10 THEN dbo.VENTASDETALLE.PRECIOVENTABRUTO / 11 ELSE 0 END AS IVA10, " & _
                         "CASE IVA WHEN 5 THEN dbo.VENTASDETALLE.PRECIOVENTABRUTO / 21 ELSE 0 END AS IVA5 " & _
            "FROM            dbo.VENTAS INNER JOIN " & _
                         "dbo.VENTASDETALLE ON dbo.VENTAS.CODVENTA = dbo.VENTASDETALLE.CODVENTA LEFT OUTER JOIN " & _
                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.CODIGOS ON dbo.VENTASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO AND " & _
                         "dbo.VENTASDETALLE.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO "
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")

            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvventasporclientesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") ORDER BY dbo.CLIENTES.NOMBREFANTASIA"
                    Else
                        Me.RvventasporclientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")   ORDER BY dbo.CLIENTES.NOMBREFANTASIA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvventasporclientesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "   ORDER BY dbo.CLIENTES.NOMBREFANTASIA"
                    Else
                        Me.RvventasporclientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  ORDER BY dbo.CLIENTES.NOMBREFANTASIA"
                    End If
                End If
                Me.RvventasporclientesTableAdapter.Fill(DsRVFacturacion.RVVENTASPORCLIENTES)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvventasporclientesTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')  ORDER BY dbo.CLIENTES.NOMBREFANTASIA"
                Else
                    Me.RvventasporclientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "')  ORDER BY dbo.CLIENTES.NOMBREFANTASIA"
                End If
                Me.RvventasporclientesTableAdapter.Fill(DsRVFacturacion.RVVENTASPORCLIENTES)
            End If

            Dim rpt As New Reportes.VentasVentasPorCliente
            Dim rptmat As New Reportes.VentasVentasPorClienteMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVFacturacion])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVFacturacion])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptIncidenciaNCVTA()

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvincidenciancsobrevtaTableAdapter.selectcommand.CommandText = "SELECT FECHA, CANTVTA, CANTNC, TOTCIVAVTA, TOTCIVANC, COSTOVTA, COSTONC, IVA10VTA, IVA10NC, IVA5VTA, IVA5NC, CODCLIENTE, NUMCLIENTE, NOMBRE, NOMBREFANTASIA " & _
                                                    "FROM (SELECT TOP (100) PERCENT VENTAS.FECHAVENTA AS FECHA, VENTASDETALLE.CANTIDADVENTA AS CANTVTA, 0 AS CANTNC, " & _
                                                    "VENTASDETALLE.PRECIOVENTABRUTO AS TOTCIVAVTA, 0 AS TOTCIVANC, VENTASDETALLE.CANTIDADVENTA * CODIGOS.PRECIO AS COSTOVTA, " & _
                                                    "0 AS COSTONC, CASE iva WHEN 10 THEN dbo.VENTASDETALLE.PRECIOVENTABRUTO / 11 ELSE 0 END AS IVA10VTA, 0 AS IVA10NC, " & _
                                                    "CASE IVA WHEN 5 THEN dbo.VENTASDETALLE.PRECIOVENTABRUTO / 21 ELSE 0 END AS IVA5VTA, 0 AS IVA5NC, CLIENTES.CODCLIENTE, " & _
                                                    "CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, CLIENTES.NOMBREFANTASIA, CLIENTES.CODCATEGORIACLIENTE, VENTAS.CODVENDEDOR, VENTAS.CODSUCURSAL, 0 AS NC, 'VTA' AS TIPOMOV " & _
                                                    "FROM VENTAS INNER JOIN " & _
                                                    "VENTASDETALLE ON VENTAS.CODVENTA = VENTASDETALLE.CODVENTA LEFT OUTER JOIN " & _
                                                    "CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                                                    "CODIGOS ON VENTASDETALLE.CODCODIGO = CODIGOS.CODCODIGO AND " & _
                                                    "VENTASDETALLE.CODPRODUCTO = CODIGOS.CODPRODUCTO " & _
                                                    "WHERE(VENTAS.ESTADO = 1) " & _
                                                    "UNION ALL " & _
                                                    "SELECT TOP (100) PERCENT FECHA, 0 AS CANTVTA, - CANTIDAD AS CANTNC, 0 AS TOTCIVAVTA, - TOTAL AS TOTCIVANC, 0 AS COSTOVTA, " & _
                                                    "- COSTO AS COSTONC, 0 AS IVA10VTA, IVA10 AS IVA10NC, 0 AS IVA5VTA, IVA5 AS Expr1, CODCLIENTE, NUMCLIENTE, NOMBRE, NOMBREFANTASIA, CODCATEGORIACLIENTE, CODVENDEDOR, CODSUCURSAL, NC, TIPOMOV " & _
                                                    "FROM (SELECT TOP (100) PERCENT DEVOLUCION.FECHADEVOLUCION AS FECHA, DEVOLUCIONDETALLE.CANTIDADDEVUELTA AS CANTIDAD, " & _
                                                    "DEVOLUCIONDETALLE.PRECIONETO * DEVOLUCIONDETALLE.CANTIDADDEVUELTA AS TOTAL, CODIGOS_1.CODIGO, " & _
                                                    "LTRIM(DEVOLUCIONDETALLE.DESCRIPCION) AS PRODUCTO, CASE WHEN CODIGO IS NULL AND IVA=10 " & _
                                                    "THEN (dbo.DEVOLUCIONDETALLE.PRECIONETO-dbo.DEVOLUCIONDETALLE.PRECIONETO/11) * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA WHEN CODIGO IS NULL AND IVA=5 THEN (dbo.DEVOLUCIONDETALLE.PRECIONETO-dbo.DEVOLUCIONDETALLE.PRECIONETO/21) * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA WHEN CODIGO IS NULL AND IVA=0 THEN dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA ELSE dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA " & _
                                                    " * CODIGOS_1.PRECIO END AS COSTO, " & _
                                                    "CASE IVA WHEN 10 THEN ((dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) / 11) " & _
                                                    "ELSE 0 END AS IVA10, " & _
                                                    "CASE IVA WHEN 5 THEN ((dbo.DEVOLUCIONDETALLE.PRECIONETO * dbo.DEVOLUCIONDETALLE.CANTIDADDEVUELTA) / 21) " & _
                                                    "ELSE 0 END AS IVA5, FAMILIA.CODFAMILIA, FAMILIA.DESFAMILIA, DEVOLUCION.CODCLIENTE, CLIENTES_1.NOMBRE, " & _
                                                    "CLIENTES_1.NUMCLIENTE, CLIENTES_1.NOMBREFANTASIA, DEVOLUCION.ESTADO, CLIENTES_1.CODCATEGORIACLIENTE, DEVOLUCION.CODVENDEDOR, DEVOLUCION.CODSUCURSAL, 1 AS NC, 'NC' AS TIPOMOV  " & _
                                                    "FROM DEVOLUCIONDETALLE LEFT OUTER JOIN " & _
                                                    "PRODUCTOS ON PRODUCTOS.CODPRODUCTO = DEVOLUCIONDETALLE.CODPRODUCTO LEFT OUTER JOIN " & _
                                                    "CODIGOS AS CODIGOS_1 ON PRODUCTOS.CODPRODUCTO = CODIGOS_1.CODPRODUCTO INNER JOIN " & _
                                                    "DEVOLUCION ON DEVOLUCIONDETALLE.CODDEVOLUCION = DEVOLUCION.CODDEVOLUCION INNER JOIN " & _
                                                    "CLIENTES AS CLIENTES_1 ON CLIENTES_1.CODCLIENTE = DEVOLUCION.CODCLIENTE LEFT OUTER JOIN " & _
                                                    "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA " & _
                                                    "WHERE (DEVOLUCION.ESTADO = 1)) AS SUBCONSULTA) AS UNIONTABLAS "
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")


            Dim sqlwhere As String = obtenerwhere(FormatF1, "CODVENDEDOR", FormatF2, "CODSUCURSAL", FormatF3, "CODCATEGORIACLIENTE", "%", "", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn")

                    If chbxCodCliente.Checked = True Then
                        Dim TestPos As Integer
                        TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                        If TestPos = 0 Then 'El texto no tiene guion
                            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvincidenciancsobrevtaTableAdapter.selectcommand.CommandText += " WHERE (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') AND NUMCLIENTE IN (" & tbxcodCliente.Text & ") ORDER BY NOMBRE"
                    Else
                        Me.RvincidenciancsobrevtaTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') AND NUMCLIENTE IN (" & tbxcodCliente.Text & ")   ORDER BY NOMBRE"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvincidenciancsobrevtaTableAdapter.selectcommand.CommandText += " WHERE (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') AND NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "   ORDER BY NOMBRE"
                    Else
                        Me.RvincidenciancsobrevtaTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') AND NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & "  ORDER BY NOMBRE"
                    End If
                End If
                Me.RvincidenciancsobrevtaTableAdapter.Fill(DsRVEstadisticas.RVINCIDENCIANCSOBREVTA)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvincidenciancsobrevtaTableAdapter.selectcommand.CommandText += " WHERE (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "')  ORDER BY NOMBRE"
                Else
                    Me.RvincidenciancsobrevtaTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (FECHA >= '" & fechadesde2 & "') AND (FECHA <= '" & fechahasta2 & "') ORDER BY NOMBRE"
                End If
                Me.RvincidenciancsobrevtaTableAdapter.Fill(DsRVEstadisticas.RVINCIDENCIANCSOBREVTA)
                    End If

            Dim rpt As New Reportes.VentasIncidenciaNCsobreVTA
            Dim rptmat As New Reportes.VentasIncidenciaNCsobreVTAMATR

                    If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                        If cmbVendedor.Text = "%" Then
                            rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                        Else
                            rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                        End If
                        If cmbSucursal.Text = "%" Then
                            rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                        Else
                            rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                        End If

                        If cmbCategCliente.Text = "%" Then
                            rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                        Else
                            rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                        End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
                    Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                        If cmbVendedor.Text = "%" Then
                            rpt.SetParameterValue("pmtVendedor", "(Todos)")
                        Else
                            rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                        End If
                        If cmbSucursal.Text = "%" Then
                            rpt.SetParameterValue("pmtDeposito", "(Todos)")
                        Else
                            rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                        End If

                        If cmbCategCliente.Text = "%" Then
                            rpt.SetParameterValue("pmtCategCli", "(Todas)")
                        Else
                            rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                        End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
                    End If
                    If chbxNuevaVent.Checked = True Then
                        Dim frm = New VerInformes
                        If chbxMatricial.Checked = True Then
                            frm.CrystalReportViewer1.ReportSource = rptmat
                        Else
                            frm.CrystalReportViewer1.ReportSource = rpt
                        End If
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        If chbxMatricial.Checked = True Then
                            CrystalReportViewer.ReportSource = rptmat
                        Else
                            CrystalReportViewer.ReportSource = rpt
                        End If
                        CrystalReportViewer.Refresh()
                    End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComprobantesNotasCreditoResumido()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            'Volvemos al SelectCommand original del Table Adapter (sin las condiciones de esta instancia)"
            If Config4 = "Nombre del Cliente" Then
                Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText = "SELECT TOP (100) PERCENT dbo.DEVOLUCION.FECHADEVOLUCION, dbo.DEVOLUCION.NUMDEVOLUCION, dbo.DEVOLUCION.TIPODEVOLUCION, dbo.CLIENTES.CODCLIENTE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, " & _
                                                                            "dbo.DEVOLUCION.COTIZACION1, dbo.VENDEDOR.DESVENDEDOR, dbo.VENDEDOR.NUMVENDEDOR, dbo.VENDEDOR.CODVENDEDOR, dbo.DEVOLUCION.CODMONEDA, dbo.MONEDA.SIMBOLO, " & _
                                                                            "dbo.DEVOLUCION.TOTALIVA, dbo.DEVOLUCION.TOTALDEVOLUCION, dbo.CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCION.ESTADO, dbo.DEVOLUCION.MOTIVOANULADO, dbo.DEVOLUCION.CODSUCURSAL, dbo.DEVOLUCION.CODCOMPROBANTE " & _
                                                                            "FROM dbo.MONEDA RIGHT OUTER JOIN " & _
                                                                            "dbo.TIPOCOMPROBANTE RIGHT OUTER JOIN " & _
                                                                            "dbo.ZONA RIGHT OUTER JOIN " & _
                                                                            "dbo.DEVOLUCION LEFT OUTER JOIN " & _
                                                                            "dbo.CLIENTES ON dbo.DEVOLUCION.CODCLIENTE = dbo.CLIENTES.CODCLIENTE ON dbo.ZONA.CODZONA = dbo.CLIENTES.CODZONA LEFT OUTER JOIN " & _
                                                                            "dbo.CIUDAD ON dbo.ZONA.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                                                                            "dbo.PAIS ON dbo.CIUDAD.CODPAIS = dbo.PAIS.CODPAIS ON dbo.TIPOCOMPROBANTE.CODCOMPROBANTE = dbo.DEVOLUCION.CODCOMPROBANTE LEFT OUTER JOIN " & _
                                                                            "dbo.SUCURSAL ON dbo.SUCURSAL.CODSUCURSAL = dbo.DEVOLUCION.CODSUCURSAL LEFT OUTER JOIN " & _
                                                                            "dbo.VENDEDOR ON dbo.DEVOLUCION.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR ON dbo.MONEDA.CODMONEDA = dbo.DEVOLUCION.CODMONEDA"
            Else
                Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText = "SELECT DEVOLUCION.FECHADEVOLUCION, SUBSTRING(DEVOLUCION.NUMDEVOLUCION, LEN(DEVOLUCION.NUMDEVOLUCION) - 5, 6) AS NUMDEVOLUCION, dbo.DEVOLUCION.TIPODEVOLUCION, CLIENTES.CODCLIENTE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, " & _
                                                                            "DEVOLUCION.COTIZACION1, VENDEDOR.DESVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.CODVENDEDOR, DEVOLUCION.CODMONEDA, " & _
                                                                            "MONEDA.SIMBOLO, DEVOLUCION.TOTALIVA, DEVOLUCION.TOTALDEVOLUCION,CLIENTES.NOMBREFANTASIA, dbo.DEVOLUCION.ESTADO, dbo.DEVOLUCION.MOTIVOANULADO " & _
                                                                            "FROM DEVOLUCION INNER JOIN " & _
                                                                            "CLIENTES ON DEVOLUCION.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                                                                            "TIPOCOMPROBANTE ON DEVOLUCION.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE LEFT OUTER JOIN " & _
                                                                            "SUCURSAL ON SUCURSAL.CODSUCURSAL = DEVOLUCION.CODSUCURSAL LEFT OUTER JOIN " & _
                                                                            "VENDEDOR ON DEVOLUCION.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                                                                            "MONEDA ON DEVOLUCION.CODMONEDA = MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                                                                            "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                                                                            "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                                                                            "PAIS ON CIUDAD.CODPAIS = PAIS.CODPAIS"
            End If
            
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbConTexto(cmbTipo, "DEVOLUCION.TIPODEVOLUCION", "SI")
            If cmbTipo.Text = "Devolución y Cambio de Productos" Then
                FormatF4 = "DEVOLUCION.TIPODEVOLUCION like '%Devoluci%'"
            ElseIf cmbTipo.Text = "Bonificación de Productos" Then
                FormatF4 = "DEVOLUCION.TIPODEVOLUCION like '%Bonificac%'"
            ElseIf cmbTipo.Text = "Por Bandeo/Promoción" Then
                FormatF4 = "DEVOLUCION.TIPODEVOLUCION like '%Promoci%'"
            End If

            ' '"%" 
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            If rbtConanuladas.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", FormatF2, "SUCURSAL.CODSUCURSAL", "%", "", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "CodigoIn", "CodigoIn", "CodigoIn", "Cadena Text", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIN")
                    Dim TestPos As Integer

                    TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)

                    If TestPos = 0 Then
                        If Trim(sqlwhere) = "" Then ' se eligieron todos %

                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO <> 0) AND (CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")) AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        Else
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO <> 0) AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        End If
                    Else
                        Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                        Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                        If Trim(sqlwhere) = "" Then
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO <> 0) AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        Else
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO <> 0) AND " + sqlwhere + "AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') AND (VENDEDOR.CODVENDEDOR = " & FormatF1 & ") ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        End If
                    End If
                Else
                    FormatF7 = FormatearFiltroCombo(cmbCliente, "SV")
                    Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "Cadena Text", "CodigoIn", "CodigoIn", "Especial", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIN")

                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        If cmbCliente.Text = "%" Then
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO <> 0) AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        Else
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO <> 0) AND  (CLIENTES.CODCLIENTE= " & cmbCliente.SelectedValue & ") AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') AND (VENDEDOR.CODVENDEDOR = " & FormatF1 & ") ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        End If
                    Else
                        If cmbCliente.Text = "%" Then
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO <> 0) AND " + sqlwhere + " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "')  ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        Else
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO <> 0) AND (CLIENTES.CODCLIENTE= " & cmbCliente.SelectedValue & ") AND " + sqlwhere + " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "')    ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        End If
                    End If
                End If
            ElseIf rbtsinanuladas.Checked = True Then 'SIN NOTAS DE CREDITO ANULADAS - SAUL - 
                If chbxCodCliente.Checked = True Then
                    Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", FormatF2, "SUCURSAL.CODSUCURSAL", "%", "", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "CodigoIn", "CodigoIn", "CodigoIn", "Especial", FormatF5, "Especial", "CodigoIN")
                    Dim TestPos As Integer

                    TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)

                    If TestPos = 0 Then
                        If Trim(sqlwhere) = "" Then ' se eligieron todos %

                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO = 1) AND (CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ")) AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        Else
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO = 1) AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') AND (VENDEDOR.CODVENDEDOR = " & FormatF1 & ") ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        End If
                    Else
                        Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                        Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                        If Trim(sqlwhere) = "" Then
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO = 1) AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') AND (VENDEDOR.CODVENDEDOR = " & FormatF1 & ") ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        Else
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO = 1) AND " + sqlwhere + "AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') AND (VENDEDOR.CODVENDEDOR = " & FormatF1 & ") ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        End If
                    End If
                Else
                    'FormatF4 = FormatearFiltroCombo(cmbCliente, "SV")
                    Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "DEVOLUCION.TIPODEVOLUCION", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", "Especial", "Especial", "CodigoIN")
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        If cmbCliente.Text = "%" Then
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO = 1) AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        Else
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO = 1) AND  (CLIENTES.CODCLIENTE= " & cmbCliente.SelectedValue & ") AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') AND (VENDEDOR.CODVENDEDOR = " & FormatF1 & ") ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        End If
                    Else
                        If cmbCliente.Text = "%" Then
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO = 1) AND " + sqlwhere + " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "')  ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        Else
                            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE (dbo.DEVOLUCION.ESTADO = 1) AND (CLIENTES.CODCLIENTE= " & cmbCliente.SelectedValue & ") AND " + sqlwhere + " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "')  AND (VENDEDOR.CODVENDEDOR = " & FormatF1 & ")  ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
                        End If
                    End If
                End If
            End If

            Me.RvNotasDeCreditoTableAdapter.Fill(DsRVNotasCredito.RVNotasDeCredito)

            Dim rpt As New Reportes.VentasComprNotasCreditoResumido
            Dim rptmat As New Reportes.VentasComprNotasCreditoResumidoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVNotasCredito])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "/ " + " " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If

                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVNotasCredito])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "/ " + " " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rptNCEstado()

        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
            'Volvemos al SelectCommand original del Table Adapter (sin las condiciones de esta instancia)"
            Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText = "SELECT DEVOLUCION.FECHADEVOLUCION, SUBSTRING(DEVOLUCION.NUMDEVOLUCION, LEN(DEVOLUCION.NUMDEVOLUCION) - 5, 6) AS NUMDEVOLUCION, CLIENTES.CODCLIENTE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, " & _
                        "DEVOLUCION.COTIZACION1, VENDEDOR.DESVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.CODVENDEDOR, DEVOLUCION.CODMONEDA, " & _
                        "MONEDA.SIMBOLO, DEVOLUCION.TOTALIVA, DEVOLUCION.TOTALDEVOLUCION,CLIENTES.NOMBREFANTASIA " & _
            "FROM        DEVOLUCION INNER JOIN " & _
                         "CLIENTES ON DEVOLUCION.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "TIPOCOMPROBANTE ON DEVOLUCION.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE LEFT OUTER JOIN " & _
                         "SUCURSAL ON SUCURSAL.CODSUCURSAL = DEVOLUCION.CODSUCURSAL LEFT OUTER JOIN " & _
                         "VENDEDOR ON DEVOLUCION.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                         "MONEDA ON DEVOLUCION.CODMONEDA = MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                         "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                         "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                         "PAIS ON CIUDAD.CODPAIS = PAIS.CODPAIS "
            FormatF1 = calcularcmbEstado(cmbEstado)
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbConTexto(cmbTipo, "DEVOLUCION.TIPODEVOLUCION", "SI")

            Dim sqlwhere As String = ""
            If cmbRelacionado.Text = "%" Then
                sqlwhere = obtenerwhere(FormatF1, "DEVOLUCION.ESTADO", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "CodigoIn", "CodigoIn", "CodigoIn", "Especial")
            ElseIf cmbRelacionado.Text = "Sin Relacionar" Then
                sqlwhere = obtenerwhere(FormatF1, "DEVOLUCION.ESTADO", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "CodigoIn", "CodigoIn", "CodigoIn", "Especial", "DEVOLUCION.COBRADO=0 AND DEVOLUCION.CODVENTA=0", "", "Especial")
            ElseIf cmbRelacionado.Text = "Relacionado por Devolucion" Then
                sqlwhere = obtenerwhere(FormatF1, "DEVOLUCION.ESTADO", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "CodigoIn", "CodigoIn", "CodigoIn", "Especial", "DEVOLUCION.COBRADO=1 AND DEVOLUCION.CODVENTA<>0", "", "Especial")
            Else ' Relacionado por Cobro
                sqlwhere = obtenerwhere(FormatF1, "DEVOLUCION.ESTADO", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "CodigoIn", "CodigoIn", "CodigoIn", "Especial", "DEVOLUCION.COBRADO=1 AND DEVOLUCION.CODVENTA=0", "", "Especial")
            End If


            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += "WHERE (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
            Else
                Me.RvNotasDeCreditoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (DEVOLUCION.FECHADEVOLUCION >= '" & fechadesde2 & "') AND (DEVOLUCION.FECHADEVOLUCION <= '" & fechahasta2 & "') ORDER BY DEVOLUCION.FECHADEVOLUCION, CLIENTES.NOMBRE"
            End If
            Me.RvNotasDeCreditoTableAdapter.Fill(DsRVNotasCredito.RVNotasDeCredito)

            Dim rpt As New Reportes.VentasComprNotasCreditoResumido
            Dim rptmat As New Reportes.VentasComprNotasCreditoResumidoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVNotasCredito])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "/ " + " " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If

                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVNotasCredito])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "/ " + " " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComprobantesNotasCreditoPorProducto()

        Dim txt1 As CrystalDecisions.CrystalReports.Engine.FieldObject
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("dd/MM/yyy") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("dd/MM/yyy") & " 23:59:00"
            'Volvemos al SelectCommand original del Table Adapter (sin las condiciones de esta instancia)"
            Me.RvNotasDeCreditoPorProdTableAdapter.selectcommand.CommandText = "SELECT CONVERT(DATE, DEVOLUCION.FECHADEVOLUCION, 103) AS FECHA, CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) " & _
                         "+ ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) AS PRODUCTO, " & _
                         "SUM(DEVOLUCIONDETALLE.CANTIDADDEVUELTA) AS CANTIDAD, SUM(DEVOLUCIONDETALLE.CANTIDADDEVUELTA * DEVOLUCIONDETALLE.PRECIONETO) " & _
                         "AS TOTALDET " & _
                         "FROM DEVOLUCION LEFT OUTER JOIN " & _
                         "CLIENTES ON DEVOLUCION.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "SUCURSAL ON SUCURSAL.CODSUCURSAL = DEVOLUCION.CODSUCURSAL LEFT OUTER JOIN " & _
                         "VENDEDOR ON DEVOLUCION.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                         "PRODUCTOS LEFT OUTER JOIN " & _
                         "DEVOLUCIONDETALLE ON PRODUCTOS.CODPRODUCTO = DEVOLUCIONDETALLE.CODPRODUCTO LEFT OUTER JOIN " & _
                         "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO ON  " & _
                         "DEVOLUCION.CODDEVOLUCION = DEVOLUCIONDETALLE.CODDEVOLUCION LEFT OUTER JOIN " & _
                         "TIPOCOMPROBANTE ON DEVOLUCION.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE WHERE (DEVOLUCION.ESTADO=1)"
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbConTexto(cmbTipo, "DEVOLUCION.TIPODEVOLUCION", "SI")
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "", "CodigoIn", "CodigoIn", "CodigoIn", "Especial", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn")
            Dim rpt As New Reportes.VentasComprNotasCreditoPorProducto
            Dim rptmat As New Reportes.VentasComprNotasCreditoPorProductoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVNotasCredito])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                txt1 = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                txt1.Width = 0 ' No mostramos
                rptmat.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "Notas de Crédito")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "Notas de Crédito" + " " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVNotasCredito])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                txt1 = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE3")
                txt1.Width = 0 ' No mostramos
                rpt.SetParameterValue("pmtCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If
                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "Notas de Crédito")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "Notas de Crédito" + " " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub frmDiasUltimaCompra()

        Dim rpt As New Reportes.VentaDiasCompra
        FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        Me.DiasUltimaCompraTableAdapter.Fill(DsReporteVentas.DiasUltimaCompra, FormatF1)
        Me.CantidadUltimaCompraTableAdapter.Fill(DsReporteVentas.CantidadUltimaCompra, FormatF1)
        Me.StockUltimaCompraTableAdapter.Fill(DsReporteVentas.StockUltimaCompra, FormatF1)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub rptDiasVentas()
        If rbAgrupFamillia.Checked = True Then
            Dim rpt As New Reportes.VentaDiasDesdeUltimaVentaConAgrup
            Me.DiasDesdeUltimaVentaTableAdapter.Fill(DsReporteVentas.DiasDesdeUltimaVenta)
            Me.AjusteTableAdapter.Fill(DsReporteVentas.Ajuste)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else
            Dim rpt As New Reportes.VentaDiasDesdeUltimaVenta
            Me.DiasDesdeUltimaVentaTableAdapter.Fill(DsReporteVentas.DiasDesdeUltimaVenta)
            Me.AjusteTableAdapter.Fill(DsReporteVentas.Ajuste)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub
    Sub rptMenosVendidos()

        Dim rpt As New Reportes.VentaProdMenosVendidos
        FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        Me.PRODUCTOSMENOSVENDIDOSTableAdapter.Fill(DsReporteVentas.PRODUCTOSMENOSVENDIDOS, FechaDesde, FechaHasta, FormatF1)
        Me.AjusteTableAdapter.Fill(DsReporteVentas.Ajuste)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub VentasResumenCaja()
        Try

            Dim rpt As New Reportes.VentasResumenCaja
            FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
            Me.VENTASFORMACOBROTableAdapter.Fill(DsReporteVentas.VENTASFORMACOBRO, FormatF1, FechaDesde, FechaHasta, cmbCaja.Text, cmbMoneda.Text)
            Me.TotalMovimientosVentaTableAdapter.Fill(DsReporteVentas.TotalMovimientosVenta, FechaDesde, FechaHasta, cmbMoneda.Text)
            Me.TotalMovimientosCompraTableAdapter.Fill(DsReporteVentas.TotalMovimientosCompra, FechaDesde, FechaHasta, cmbMoneda.Text)
            Me.AperturaCierreTableAdapter.Fill(DsReporteVentas.AperturaCierre)
            Me.AjusteEntradaTableAdapter.Fill(DsReporteVentas.AjusteEntrada)
            Me.AjusteSalidaTableAdapter.Fill(DsReporteVentas.AjusteSalida)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub ReporteResumenCajaIva()
        Try
            Dim desde As String = dtpFechaDesde.Value
            Dim hasta As String = dtpFechaHasta.Value
            FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")

            Dim rpt As New Reportes.VentasResumenCajaIva
            Me.RvCajaIvaTableAdapter.Fill(DsRVCaja.RVCajaIva, cmbMoneda.Text, desde, hasta, cmbCaja.Text, FormatF1)
            rpt.SetDataSource([DsRVCaja])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub VentasGsComprado()

        Dim rpt As New Reportes.VentasPromedioGsComprado
        Me.PromedioGs_CompradoTableAdapter.Fill(DsReporteVentas._PromedioGs_Comprado, FechaDesde, FechaHasta, cmbCliente.Text)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub VentasCantidadComprada()

        Dim rpt As New Reportes.VentasPromedioCantidadComprada
        Me.PromedioCantidadCompradaTableAdapter.Fill(DsReporteVentas.PromedioCantidadComprada, cmbCliente.Text, FechaDesde, FechaHasta)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Sub UtilidadCliente()

        Dim rpt As New Reportes.VentasUtilidadCliente
        Me.UtilidadClienteCompraTableAdapter.Fill(DsReporteVentas.UtilidadClienteCompra)
        Me.UtilidadClienteVentasTableAdapter.Fill(DsReporteVentas.UtilidadClienteVentas, FechaDesde, FechaHasta, cmbCliente.Text)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub VentasDetallado()
        Dim fechadesde2, fechahasta2 As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        Try
            Me.VentasDetalladoTableAdapter.selectcommand.CommandText = "SELECT VENTAS.FECHAVENTA, CLIENTES.NOMBRE, VENTAS.NUMVENTA, VENTASDETALLE.CANTIDADVENTA, VENTASDETALLE.PRECIOVENTALISTA * VENTASDETALLE.CANTIDADVENTA AS TOTAL, PRODUCTOS.DESPRODUCTO, VENTASDETALLE.PRECIOVENTALISTA, CLIENTES.NOMBREFANTASIA, CLIENTES.DIRECCION, CLIENTES.RUC, VENTAS.MODALIDADPAGO AS TIPOVENTA, VENDEDOR.DESVENDEDOR, VENTAS.MOTIVOANULADO, VENTAS.TOTAL5, VENTAS.TOTAL10, VENTAS.TOTALVENTA, VENTAS.TOTALIVA, CODIGOS.CODIGO, CLIENTES.TELEFONO, ZONA.DESZONA, " & _
                  "VENTASDETALLE.PRECIOVENTABRUTO, VENTAS.ESTADO, VENTAS.MOTIVODESCUENTO " & _
                  "FROM VENTAS INNER JOIN " & _
                  "VENTASDETALLE ON VENTAS.CODVENTA = VENTASDETALLE.CODVENTA LEFT OUTER JOIN " & _
                  "CODIGOS ON VENTASDETALLE.CODCODIGO = CODIGOS.CODCODIGO AND VENTASDETALLE.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                  "ZONA ON VENTAS.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                  "CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                  "PRODUCTOS ON CODIGOS.CODPRODUCTO = PRODUCTOS.CODPRODUCTO AND VENTASDETALLE.CODPRODUCTO = PRODUCTOS.CODPRODUCTO LEFT OUTER JOIN " & _
                  "VENDEDOR ON VENTAS.CODVENDEDOR = VENDEDOR.CODVENDEDOR " & _
                  "WHERE (VENTAS.ESTADO <> 0)" 'Tambien debe traer los anulados
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.VentasDetalladoTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    Else
                        Me.VentasDetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.VentasDetalladoTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    Else
                        Me.VentasDetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    End If
                End If
                Me.VentasDetalladoTableAdapter.Fill(DsReporteVentas.VentasDetallado)
            ElseIf cmbCliente.Text = "%" Then
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.VentasDetalladoTableAdapter.selectcommand.CommandText += " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                Else
                    Me.VentasDetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                End If
            Else ' Un Cliente
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.VentasDetalladoTableAdapter.selectcommand.CommandText += " AND CLIENTES.CODCLIENTE =" & cmbCliente.SelectedValue & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                Else
                    Me.VentasDetalladoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.CODCLIENTE =" & cmbCliente.SelectedValue & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                End If
            End If

            Me.VentasDetalladoTableAdapter.Fill(DsReporteVentas.VentasDetallado)


            Dim rpt As New Reportes.VentasDetallado
            Dim rptmat As New Reportes.VentasDetalladoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsReporteVentas])
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", "")
                    Else
                        rptmat.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rptmat.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRango", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsReporteVentas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbComprobante.Text = "%" Then
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", "")
                    Else
                        rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                    End If
                Else
                    If cmbTipo.Text = "%" Then
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                    Else
                        rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                    End If
                End If
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRango", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasPorZona()
        Dim fechadesde2, fechahasta2 As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        Try
            FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")
            FormatF2 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "NO")

            If cmbZona.Text = "%" Then
                Me.RvVentasPorZONATableAdapter.Fill(DsRVComprobantes.RVVentasPorZONA, fechadesde2, fechahasta2, FormatF1, FormatF2)
            Else
                Me.RvVentasPorZONATableAdapter.FillByZona(DsRVComprobantes.RVVentasPorZONA, cmbZona.Text, fechadesde2, fechahasta2, FormatF1, FormatF2)
            End If

            Dim rpt As New Reportes.VentasPorZonaPeriodo
            Dim rptmat As New Reportes.VentasPorZonaPeriodoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVComprobantes])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)

            Else
                rpt.SetDataSource([DsRVComprobantes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub rptVentasPorZonaPromedio()
        Dim fechadesde2, fechahasta2 As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        Try
            FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")

            If cmbZona.Text = "%" Then
                Me.RVVentasPorZonaPromedioTableAdapter.Fill(DsRVComprobantes.RVVENTASPORZONAPROMEDIO, fechadesde2, fechahasta2, FormatF1)
            Else
                Me.RVVentasPorZonaPromedioTableAdapter.FillByZona(DsRVComprobantes.RVVENTASPORZONAPROMEDIO, cmbZona.Text, fechadesde2, fechahasta2, FormatF1)
            End If

            If rbtnSemana.Checked = True Then
                Dim rpt As New Reportes.VentasPorZonaPromedioSemanal
                rpt.SetDataSource([DsRVComprobantes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnQuincena.Checked = True Then
                Dim rpt As New Reportes.VentasPorZonaPromedioQuincenal
                rpt.SetDataSource([DsRVComprobantes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnMes.Checked = True Then
                Dim rpt As New Reportes.VentasPorZonaPromedioMensual
                rpt.SetDataSource([DsRVComprobantes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnSemestre.Checked = True Then
                Dim rpt As New Reportes.VentasPorZonaPromedioSemestral
                rpt.SetDataSource([DsRVComprobantes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            ElseIf rbtnAño.Checked = True Then
                Dim rpt As New Reportes.VentasPorZonaPromedioAnual
                rpt.SetDataSource([DsRVComprobantes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub rptVentasPorZonaSimple()
        Dim fechadesde2, fechahasta2 As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        Try
            FormatF1 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "NO")

            If cmbZona.Text = "%" Then
                Me.RVVentasPorZonatipoTableAdapter.Fill(DsRVComprobantes.RVVENTASPORZONATIPO, fechadesde2, fechahasta2, FormatF1)
            Else
                Me.RVVentasPorZonatipoTableAdapter.FillByZona(DsRVComprobantes.RVVENTASPORZONATIPO, cmbZona.Text, fechadesde2, fechahasta2, FormatF1)
            End If

            Dim rpt As New Reportes.VentasPorZonaTipo
            Dim rptmat As New Reportes.VentasPorZonaTipoMATR

            If rbIVASI.Checked = False And rbIVANO.Checked = False Then
                rbIVASI.Checked = True
                rptmat.SetParameterValue("pmtIVA", "Si")
            End If
            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVComprobantes])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rptmat.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)
                If rbIVASI.Checked = True Then
                    rptmat.SetParameterValue("pmtIVA", "Si")
                Else
                    rptmat.SetParameterValue("pmtIVA", "No")
                End If
            Else
                rpt.SetDataSource([DsRVComprobantes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text.ToString)
                rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text.ToString)
                If rbIVASI.Checked = True Then
                    rpt.SetParameterValue("pmtIVA", "Si")
                Else
                    rpt.SetParameterValue("pmtIVA", "No")
                End If
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasResumen()

        Dim rpt As New Reportes.VentasResumen
        Me.RvVentasResumenTableAdapter.Fill(DsRVFacturacion.RVVentasResumen, FechaDesde, FechaHasta)
        rpt.SetDataSource([DsRVFacturacion])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub
    Sub ReporteCompraVenta()

        Dim rpt As New Reportes.VentasCompraVenta
        Me.GastosPorProductoTableAdapter.Fill(DsReporteVentas.GastosPorProducto)
        Me.IngresosPorProductoTableAdapter.Fill(DsReporteVentas.IngresosPorProducto, FechaDesde, FechaHasta)
        Me.CostoFijoSumaTableAdapter.Fill(DsReporteVentas.CostoFijoSuma, FechaDesde, FechaHasta)
        Me.CostoFijoCantidadVentaTableAdapter.Fill(DsReporteVentas.CostoFijoCantidadVenta, FechaDesde, FechaHasta)
        Me.STOCKDEPOSITOTableAdapter.Fill(DsReporteVentas.STOCKDEPOSITO, FechaDesde, FechaHasta)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub ReporteBreakeven()

        Dim rpt As New Reportes.VentasBreakeven


        Me.GastosPorProductoTableAdapter.Fill(DsReporteVentas.GastosPorProducto)
        Me.IngresosPorProductoTableAdapter.Fill(DsReporteVentas.IngresosPorProducto, FechaDesde, FechaHasta)
        Me.CostoFijoSumaTableAdapter.Fill(DsReporteVentas.CostoFijoSuma, FechaDesde, FechaHasta)
        Me.CostoFijoCantidadVentaTableAdapter.Fill(DsReporteVentas.CostoFijoCantidadVenta, FechaDesde, FechaHasta)
        Me.VENTASDETALLETableAdapter.Fill(DsReporteVentas.VENTASDETALLE)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub ReporteCoGSlistaPrecio()

        Dim rpt As New Reportes.VentasListaPrecio
        Me.PRODUCTOSLISTAPRECIOTableAdapter.Fill(DsReporteVentas.PRODUCTOSLISTAPRECIO)
        Me.CostoFijoSumaTableAdapter.Fill(DsReporteVentas.CostoFijoSuma, FechaDesde, FechaHasta)
        Me.CostoFijoCantidadVentaTableAdapter.Fill(DsReporteVentas.CostoFijoCantidadVenta, FechaDesde, FechaHasta)
        Me.VentasListaPrecioTableAdapter.Fill(DsReporteVentas.VentasListaPrecio)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Sub ReporteUtilidadVenta()

        Dim rpt As New Reportes.VentasUtilidadPorVentaPromedioNeto

        Me.GastosPorProductoTableAdapter.Fill(DsReporteVentas.GastosPorProducto)
        Me.IngresosPorProductoTableAdapter.Fill(DsReporteVentas.IngresosPorProducto, FechaDesde, FechaHasta)
        Me.CostoFijoSumaTableAdapter.Fill(DsReporteVentas.CostoFijoSuma, FechaDesde, FechaHasta)
        Me.CostoFijoCantidadVentaTableAdapter.Fill(DsReporteVentas.CostoFijoCantidadVenta, FechaDesde, FechaHasta)
        Me.CostoFijoDesglosadoTableAdapter.Fill(DsReporteVentas.CostoFijoDesglosado, FechaDesde, FechaHasta)
        Me.CantidadVentaTableAdapter.Fill(DsReporteVentas.CantidadVenta, FechaDesde, FechaHasta)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub ReporteCOGSPromedioUltimoNeto()

        Dim rpt As New Reportes.VentasCoGSUltimoNeto

        Me.GastosUltimaCompraTableAdapter.Fill(DsReporteVentas.GastosUltimaCompra)
        Me.IngresosPorProductoTableAdapter.Fill(DsReporteVentas.IngresosPorProducto, FechaDesde, FechaHasta)
        Me.CostoFijoCantidadVentaTableAdapter.Fill(DsReporteVentas.CostoFijoCantidadVenta, FechaDesde, FechaHasta)
        Me.CostoFijoSumaTableAdapter.Fill(DsReporteVentas.CostoFijoSuma, FechaDesde, FechaHasta)
        Me.CostoFijoDesglosadoTableAdapter.Fill(DsReporteVentas.CostoFijoDesglosado, FechaDesde, FechaHasta)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub ReporteCoGSPromedioNeto()

        Dim rpt As New Reportes.VentasCoGSPromedioNeto
        Me.GastosPorProductoTableAdapter.Fill(DsReporteVentas.GastosPorProducto)
        Me.IngresosPorProductoTableAdapter.Fill(DsReporteVentas.IngresosPorProducto, FechaDesde, FechaHasta)
        Me.CostoFijoSumaTableAdapter.Fill(DsReporteVentas.CostoFijoSuma, FechaDesde, FechaHasta)
        Me.CostoFijoCantidadVentaTableAdapter.Fill(DsReporteVentas.CostoFijoCantidadVenta, FechaDesde, FechaHasta)
        Me.CostoFijoDesglosadoTableAdapter.Fill(DsReporteVentas.CostoFijoDesglosado, FechaDesde, FechaHasta)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub ReporteIngresoEgreso()

        If rbtDia.Checked = True Then

            Dim rpt As New Reportes.VentaIngresoEgreso
            Me.VentaMovimientoTableAdapter.Fill(Me.DsReporteVentas.VentaMovimiento, FechaDesde, FechaHasta)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnHora.Checked = True Then

            Dim rpt As New Reportes.VentaIngresoEgresoHora
            Me.VentaMovimientoTableAdapter.Fill(Me.DsReporteVentas.VentaMovimiento, FechaDesde, FechaHasta)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnSemana.Checked = True Then

            Dim rpt As New Reportes.VentaIngresoEgresoSemana
            Me.VentaMovimientoTableAdapter.Fill(Me.DsReporteVentas.VentaMovimiento, FechaDesde, FechaHasta)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnQuincena.Checked = True Then

            Dim rpt As New Reportes.VentaIngresoEgresoPorQuincena
            Me.VentaMovimientoTableAdapter.Fill(Me.DsReporteVentas.VentaMovimiento, FechaDesde, FechaHasta)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnMes.Checked = True Then

            Dim rpt As New Reportes.VentaIngresoEgresoPorMesAnhoRT
            Me.VentaMovimientoTableAdapter.Fill(Me.DsReporteVentas.VentaMovimiento, FechaDesde, FechaHasta)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnSemestre.Checked = True Then

            Dim rpt As New Reportes.VentaIngresoEgresoPorSemestre
            Me.VentaMovimientoTableAdapter.Fill(Me.DsReporteVentas.VentaMovimiento, FechaDesde, FechaHasta)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnAño.Checked = True Then

            Dim rpt As New Reportes.VentaIngresoEgresoPorAño
            Me.VentaMovimientoTableAdapter.Fill(Me.DsReporteVentas.VentaMovimiento, FechaDesde, FechaHasta)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Sub VentasCantVentasYoY()
        Dim Primero As Integer = 0
        Dim Primero1 As Integer = 0
        FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        If chbxCodProducto.Checked = False Then
            Dim rpt As New Reportes.VentasProductoStockYoY
            Me.VentasProductoDetallladoTableAdapter.FillByProdSuc(Me.DsReporteVentas.VentasProductoDetalllado, cmbProducto.Text, FechaDesde, FechaHasta, FormatF1)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else
            Dim rpt As New Reportes.VentasProductoStockYoY
            Me.VentasProductoDetallladoTableAdapter.FillByPlanSuc(Me.DsReporteVentas.VentasProductoDetalllado, tbxcodProd.Text, FechaDesde, FechaHasta, FormatF1)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Sub ReporteCOGSPromedioUltimo()

        Dim rpt As New Reportes.VentasCoGSUltimo


        Me.GastosUltimaCompraTableAdapter.Fill(DsReporteVentas.GastosUltimaCompra)
        Me.IngresosPorProductoTableAdapter.Fill(DsReporteVentas.IngresosPorProducto, FechaDesde, FechaHasta)


        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub
    Sub ReporteCOGSPromedio()

        Dim rpt As New Reportes.VentasCoGSPromedio


        Me.GastosPorProductoTableAdapter.Fill(DsReporteVentas.GastosPorProducto)
        Me.IngresosPorProductoTableAdapter.Fill(DsReporteVentas.IngresosPorProducto, FechaDesde, FechaHasta)


        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub

    Sub ReporteDiarioCaja()
        Try
            FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
            Dim rpt As New Reportes.VentaDiarioCaja

            RvDiarioCajaTableAdapter.Fill(DsRVCaja.RVDiarioCaja, FechaDesde, FechaHasta, cmbCaja.Text, cmbMoneda.Text, FormatF1)
            RvTotalTableAdapter.Fill(DsRVCaja.RVTotal, FechaDesde, FechaHasta, cmbCaja.Text, cmbMoneda.Text)
            RvAperturaCierreTableAdapter.Fill(DsRVCaja.RVAperturaCierre)
            rpt.SetDataSource([DsRVCaja])

            'POR ERROR EN NUMERACION DE VENTA EN SAN JUSTO
            Try
                Dim RUCEMPRESA = f.FuncionConsultaString("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)
                If RUCEMPRESA = "459534-3" Then 'QUE SOLO HAGA EN SAN JUSTO
                   
                    If cmbCaja.Text = "1" And ((dtpFechaDesde.Text = "10/08/2013" Or dtpFechaHasta.Text = "10/08/2013") Or (dtpFechaDesde.Text = "11/10/2013" Or dtpFechaHasta.Text = "11/10/2013") Or (dtpFechaDesde.Text = "19/10/2013" Or dtpFechaHasta.Text = "19/10/2013") Or (dtpFechaDesde.Text = "20/10/2013" Or dtpFechaHasta.Text = "20/10/2013") Or (dtpFechaDesde.Text = "22/10/2013" Or dtpFechaHasta.Text = "22/10/2013") Or (dtpFechaDesde.Text = "28/10/2013" Or dtpFechaHasta.Text = "28/10/2013")) Then
                        rpt.SetParameterValue("pmtObservacion", "OBSERVACIÓN: En esta fecha hubo casos de error del Sistema en la asignación de la Numeración de Venta")
                    ElseIf cmbCaja.Text = "2" And ((dtpFechaDesde.Text = "23/07/2013" Or dtpFechaHasta.Text = "23/07/2013") Or (dtpFechaDesde.Text = "10/08/2013" Or dtpFechaHasta.Text = "10/08/2013") Or (dtpFechaDesde.Text = "19/10/2013" Or dtpFechaHasta.Text = "19/10/2013") Or (dtpFechaDesde.Text = "20/10/2013" Or dtpFechaHasta.Text = "20/10/2013") Or (dtpFechaDesde.Text = "21/10/2013" Or dtpFechaHasta.Text = "21/10/2013") Or (dtpFechaDesde.Text = "22/10/2013" Or dtpFechaHasta.Text = "22/10/2013") Or (dtpFechaDesde.Text = "29/10/2013" Or dtpFechaHasta.Text = "29/10/2013")) Then
                        rpt.SetParameterValue("pmtObservacion", "OBSERVACIÓN: En esta fecha hubo casos de error del Sistema en la asignación de la Numeración de Venta")
                    ElseIf cmbCaja.Text = "3" And ((dtpFechaDesde.Text = "30/07/2013" Or dtpFechaHasta.Text = "30/07/2013") Or (dtpFechaDesde.Text = "20/09/2013" Or dtpFechaHasta.Text = "20/09/2013") Or (dtpFechaDesde.Text = "19/10/2013" Or dtpFechaHasta.Text = "19/10/2013") Or (dtpFechaDesde.Text = "20/10/2013" Or dtpFechaHasta.Text = "20/10/2013") Or (dtpFechaDesde.Text = "26/10/2013" Or dtpFechaHasta.Text = "26/10/2013")) Then
                        rpt.SetParameterValue("pmtObservacion", "OBSERVACIÓN: En esta fecha hubo casos de error del Sistema en la asignación de la Numeración de Venta")
                    ElseIf cmbCaja.Text = "4" And ((((dtpFechaDesde.Value.Day >= "6" And dtpFechaDesde.Value.Day <= "15") And dtpFechaDesde.Value.Month = "10" And dtpFechaDesde.Value.Year = "2013") Or ((dtpFechaHasta.Value.Day >= "6" And dtpFechaHasta.Value.Day <= "15") And dtpFechaHasta.Value.Month = "10" And dtpFechaHasta.Value.Year = "2013") Or (dtpFechaDesde.Text = "19/10/2013" Or dtpFechaHasta.Text = "19/10/2013") Or (dtpFechaDesde.Text = "20/10/2013" Or dtpFechaHasta.Text = "20/10/2013") Or (dtpFechaDesde.Text = "22/10/2013" Or dtpFechaHasta.Text = "22/10/2013") Or (dtpFechaDesde.Text = "24/10/2013" Or dtpFechaHasta.Text = "24/10/2013"))) Then
                        rpt.SetParameterValue("pmtObservacion", "OBSERVACIÓN: En esta fecha hubo casos de error del Sistema en la asignación de la Numeración de Venta")
                    Else
                        rpt.SetParameterValue("pmtObservacion", "")
                    End If
                Else
                    rpt.SetParameterValue("pmtObservacion", "")
                End If
            Catch ex As Exception

            End Try
            
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub ReportePedidoPendientePorCliente()

        If cmbZona.Text = "%" Then
            Dim rpt As New Reportes.VentasPedidosPendientesPorClientes
            Dim rptmat As New Reportes.VentasPedidosPendientesPorClientesMATR
            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    Me.RvPendientePorClienteTableAdapter.FillByPlan(Me.DsRVFacturacion.RVPendientePorCliente, FechaDesde, FechaHasta, tbxcodCliente.Text)
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    Me.RvPendientePorClienteTableAdapter.FillByRangoCli(Me.DsRVFacturacion.RVPendientePorCliente, codInicio, codFin, FechaDesde, FechaHasta)
                End If
            Else
                Me.RvPendientePorClienteTableAdapter.Fill(Me.DsRVFacturacion.RVPendientePorCliente, cmbCliente.Text, FechaDesde, FechaHasta)
            End If

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVFacturacion])
                rptmat.SetParameterValue("FDesde", FechaDesde.ToString)
                rptmat.SetParameterValue("FHasta", FechaHasta.ToString)
            Else
                rpt.SetDataSource([DsRVFacturacion])
                rpt.SetParameterValue("FDesde", FechaDesde.ToString)
                rpt.SetParameterValue("FHasta", FechaHasta.ToString)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Else
            If chbxCodCliente.Checked = True Then
                Dim rpt As New Reportes.VentasPedidosPendientesPorZona
                Dim rptmat As New Reportes.VentasPedidosPendientesPorZonaMATR
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    Me.RvPendientePorZonaClienteTableAdapter.FillByPlan(Me.DsRVFacturacion.RVPendientePorZonaCliente, cmbZona.Text, FechaDesde, FechaHasta, tbxcodCliente.Text)
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    Me.RvPendientePorZonaClienteTableAdapter.FillByRangoCli(Me.DsRVFacturacion.RVPendientePorZonaCliente, cmbZona.Text, codInicio, codFin, FechaDesde, FechaHasta)
                End If
                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("FDesde", FechaDesde.ToString)
                    rptmat.SetParameterValue("FHasta", FechaHasta.ToString)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    rpt.SetParameterValue("FDesde", FechaDesde.ToString)
                    rpt.SetParameterValue("FHasta", FechaHasta.ToString)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            ElseIf cmbCliente.Text = "%" Then
                Dim rpt As New Reportes.VentasPedidosPendientesPorZona
                Dim rptmat As New Reportes.VentasPedidosPendientesPorZonaMATR

                Me.RvPendientePorZonaClienteTableAdapter.FillByZona(Me.DsRVFacturacion.RVPendientePorZonaCliente, cmbZona.Text, FechaDesde, FechaHasta)
                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("FDesde", FechaDesde.ToString)
                    rptmat.SetParameterValue("FHasta", FechaHasta.ToString)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    rpt.SetParameterValue("FDesde", FechaDesde.ToString)
                    rpt.SetParameterValue("FHasta", FechaHasta.ToString)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.VentasPedidosPendientesPorZona
                Dim rptmat As New Reportes.VentasPedidosPendientesPorZonaMATR
                Me.RvPendientePorZonaClienteTableAdapter.FillByZonaCliente(Me.DsRVFacturacion.RVPendientePorZonaCliente, cmbZona.Text, cmbCliente.SelectedValue, FechaDesde, FechaHasta)
                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRVFacturacion])
                    rptmat.SetParameterValue("FDesde", FechaDesde.ToString)
                    rptmat.SetParameterValue("FHasta", FechaHasta.ToString)
                Else
                    rpt.SetDataSource([DsRVFacturacion])
                    rpt.SetParameterValue("FDesde", FechaDesde.ToString)
                    rpt.SetParameterValue("FHasta", FechaHasta.ToString)
                End If
                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    If chbxMatricial.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    If chbxMatricial.Checked = True Then
                        CrystalReportViewer.ReportSource = rptmat
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                    CrystalReportViewer.Refresh()
                End If
            End If
        End If

    End Sub
    Sub ReportePendienteProducto()

        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

        cmbMoneda.Text = "%"
        FormatF1 = FormatearFiltroCombo(cmbPais, "T")
        FormatF2 = FormatearFiltroCombo(cmbCiudad, "T")
        FormatF3 = FormatearFiltroCombo(cmbZona, "T")
        FormatF4 = FormatearFiltroCombo(cmbMoneda, "T")
        Dim sqlwhere As String = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "Z.DESZONA", FormatF4, "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

        If chbxCodCliente.Checked = True Then
            Dim rpt As New Reportes.VentasPedidosPendientesPorClienteProducto
            'Volvemos al SelectCommand original del Table Adapter (borrando las condiciones de la instancia anterior)"
            Me.RvPendientePorClienteProductoTableAdapter.selectcommand.CommandText = "SELECT SUM(VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, CODIGOS.CODIGO, " & _
                         "LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) AS PRODUCTO, " & _
                         "CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE " & _
            "FROM            VENTASDETALLE INNER JOIN " & _
                         "PRODUCTOS ON PRODUCTOS.CODPRODUCTO = VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                         "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO INNER JOIN " & _
                         "VENTAS ON VENTASDETALLE.CODVENTA = VENTAS.CODVENTA INNER JOIN " & _
                         "CLIENTES ON CLIENTES.CODCLIENTE = VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                         "ZONA AS Z ON Z.CODZONA = CLIENTES.CODZONA LEFT OUTER JOIN " & _
                         "CIUDAD ON CIUDAD.CODCIUDAD = Z.CODCIUDAD LEFT OUTER JOIN " & _
                         "PAIS ON CIUDAD.CODPAIS = PAIS.CODPAIS"
            Dim TestPos As Integer
            TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvPendientePorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE ORDER BY PRODUCTO"
                Else
                    Me.RvPendientePorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE ORDER BY PRODUCTO"
                End If
            Else
                Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvPendientePorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE ORDER BY PRODUCTO"
                Else
                    Me.RvPendientePorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE ORDER BY PRODUCTO"
                End If
            End If
            Me.RvPendientePorClienteProductoTableAdapter.Fill(Me.DsRVFacturacion.RVPendientePorClienteProducto)
            rpt.SetDataSource([DsRVFacturacion])
            rpt.SetParameterValue("FDesde", FechaDesde.ToString)
            rpt.SetParameterValue("FHasta", FechaHasta.ToString)
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf cmbCliente.Text = "%" Then ' MOSTRAMOS EL REPORTE POR ZONA
            Dim rpt As New Reportes.VentasPedidosPendientesPorZonaProducto
            'Volvemos al SelectCommand original del Table Adapter (borrando las condiciones de la instancia anterior)"
            Me.RvPendientePorZonaProductoTableAdapter.selectcommand.CommandText = "SELECT SUM(VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, Z.DESZONA, CODIGOS.CODIGO, " & _
                             "LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) AS PRODUCTO " & _
            "FROM            VENTASDETALLE INNER JOIN " & _
                             "PRODUCTOS ON PRODUCTOS.CODPRODUCTO = VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                             "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO INNER JOIN " & _
                             "VENTAS ON VENTASDETALLE.CODVENTA = VENTAS.CODVENTA INNER JOIN " & _
                             "CLIENTES ON CLIENTES.CODCLIENTE = VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                             "ZONA AS Z ON Z.CODZONA = CLIENTES.CODZONA LEFT OUTER JOIN " & _
                             "CIUDAD ON CIUDAD.CODCIUDAD = Z.CODCIUDAD LEFT OUTER JOIN " & _
                             "PAIS ON CIUDAD.CODPAIS = PAIS.CODPAIS"

            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RvPendientePorZonaProductoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY Z.DESZONA, CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) ORDER BY PRODUCTO"
            Else
                Me.RvPendientePorZonaProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY Z.DESZONA, CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) ORDER BY PRODUCTO"
            End If
            Me.RvPendientePorZonaProductoTableAdapter.Fill(Me.DsRVFacturacion.RVPendientePorZonaProducto)
            rpt.SetDataSource([DsRVFacturacion])
            rpt.SetParameterValue("FDesde", FechaDesde.ToString)
            rpt.SetParameterValue("FHasta", FechaHasta.ToString)
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else ' MOSTRAMOS EL REPORTE POR CLIENTE
            Dim rpt As New Reportes.VentasPedidosPendientesPorClienteProducto
            'Volvemos al SelectCommand original del Table Adapter (borrando las condiciones de la instancia anterior)"
            Me.RvPendientePorClienteProductoTableAdapter.selectcommand.CommandText = "SELECT SUM(VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, CODIGOS.CODIGO, " & _
                         "LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) AS PRODUCTO, " & _
                         "CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE " & _
            "FROM            VENTASDETALLE INNER JOIN " & _
                         "PRODUCTOS ON PRODUCTOS.CODPRODUCTO = VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                         "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO INNER JOIN " & _
                         "VENTAS ON VENTASDETALLE.CODVENTA = VENTAS.CODVENTA INNER JOIN " & _
                         "CLIENTES ON CLIENTES.CODCLIENTE = VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                         "ZONA AS Z ON Z.CODZONA = CLIENTES.CODZONA LEFT OUTER JOIN " & _
                         "CIUDAD ON CIUDAD.CODCIUDAD = Z.CODCIUDAD LEFT OUTER JOIN " & _
                         "PAIS ON CIUDAD.CODPAIS = PAIS.CODPAIS"
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RvPendientePorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE CLIENTES.CODCLIENTE= " & cmbCliente.SelectedValue & " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE ORDER BY PRODUCTO"
            Else
                Me.RvPendientePorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND CLIENTES.CODCLIENTE= " & cmbCliente.SelectedValue & " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE ORDER BY PRODUCTO"
            End If
            Me.RvPendientePorClienteProductoTableAdapter.Fill(Me.DsRVFacturacion.RVPendientePorClienteProducto)
            rpt.SetDataSource([DsRVFacturacion])
            rpt.SetParameterValue("FDesde", FechaDesde.ToString)
            rpt.SetParameterValue("FHasta", FechaHasta.ToString)
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub
    Sub ReporteEnvioPorClienteProducto()
        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

        Dim txt As CrystalDecisions.CrystalReports.Engine.FieldObject
        Me.RvEnviosPorClienteProductoTableAdapter.selectcommand.CommandText = "SELECT        SUM(dbo.VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(dbo.VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, dbo.CODIGOS.CODIGO, " & _
                         " LTRIM(dbo.PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, ''))  " & _
                         " AS PRODUCTO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTAS.NUMVENTA " & _
                         "FROM            dbo.VENTASDETALLE INNER JOIN " & _
                         " dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                         " dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO INNER JOIN " & _
                         " dbo.VENTAS ON dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA INNER JOIN " & _
                         " dbo.CLIENTES ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                         " dbo.ZONA AS Z ON Z.CODZONA = dbo.CLIENTES.CODZONA LEFT OUTER JOIN " & _
                         " dbo.CIUDAD ON dbo.CIUDAD.CODCIUDAD = Z.CODCIUDAD LEFT OUTER JOIN " & _
                         " dbo.PAIS ON dbo.CIUDAD.CODPAIS = dbo.PAIS.CODPAIS "

        If Not (cmbCliente.Text = "" Or cmbCliente.Text = "%") Then
            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
        End If
        cmbMoneda.Text = "%"
        FormatF1 = FormatearFiltroCombo(cmbPais, "T")
        FormatF2 = FormatearFiltroCombo(cmbCiudad, "T")
        FormatF3 = FormatearFiltroCombo(cmbZona, "T")
        FormatF4 = FormatearFiltroCombo(cmbMoneda, "T")
        Dim sqlwhere As String = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "Z.DESZONA", FormatF4, "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

        If chbxCodCliente.Checked = True Then
            Dim TestPos As Integer
            TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvEnviosPorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA, dbo.VENTAS.NUMVENTA ORDER BY PRODUCTO"
                Else
                    Me.RvEnviosPorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA, dbo.VENTAS.NUMVENTA ORDER BY PRODUCTO"
                End If
            Else
                Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvEnviosPorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA, dbo.VENTAS.NUMVENTA ORDER BY PRODUCTO"
                Else
                    Me.RvEnviosPorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA, dbo.VENTAS.NUMVENTA ORDER BY PRODUCTO"
                End If
            End If
            Me.RvEnviosPorClienteProductoTableAdapter.Fill(Me.DsRVEnvios.RVEnviosPorClienteProducto)
        Else
            FormatF4 = FormatearFiltroCombo(cmbCliente, "SV")
            sqlwhere = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "Z.DESZONA", FormatF4, "CLIENTES.CODCLIENTE", "Cadena Text", "Cadena Text", "Cadena Text", "Numero Text")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                Me.RvEnviosPorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA, dbo.VENTAS.NUMVENTA ORDER BY PRODUCTO"
            Else
                Me.RvEnviosPorClienteProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')), CLIENTES.NOMBRE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA, dbo.VENTAS.NUMVENTA ORDER BY PRODUCTO"
            End If
            Me.RvEnviosPorClienteProductoTableAdapter.Fill(Me.DsRVEnvios.RVEnviosPorClienteProducto)
        End If

        If rbtSinNumFac.Checked = True Then
            Dim rpt As New Reportes.VentasEnviosPorClienteProducto
            Dim rptmat As New Reportes.VentasEnviosPorClienteProductoMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVEnvios])
                rptmat.SetParameterValue("FDesde", FechaDesde.ToString)
                rptmat.SetParameterValue("FHasta", FechaHasta.ToString)
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")

                If cmbZona.Text = "%" Then
                    rptmat.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rptmat.SetParameterValue("pmtZona", cmbZona.Text)
                End If
                If cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0
                Else
                    rptmat.SetParameterValue("pmtCliente", "")
                End If
                rptmat.SetParameterValue("pmtObs1", "Una vez firmada su recepción, las mercaderías recibidas son de ABSOLUTA RESPONSABILIDAD del chofer.")
                rptmat.SetParameterValue("pmtObs2", "NO SE ACEPTAN RECLAMOS POSTERIORES.")
            Else
                rpt.SetDataSource([DsRVEnvios])
                rpt.SetParameterValue("FDesde", FechaDesde.ToString)
                rpt.SetParameterValue("FHasta", FechaHasta.ToString)
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")

                If cmbZona.Text = "%" Then
                    rpt.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rpt.SetParameterValue("pmtZona", cmbZona.Text)
                End If
                If cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                    txt.Width = 0
                Else
                    rpt.SetParameterValue("pmtCliente", "")
                End If
                rpt.SetParameterValue("pmtObs1", "Una vez firmada su recepción, las mercaderías recibidas son de ABSOLUTA RESPONSABILIDAD del chofer.")
                rpt.SetParameterValue("pmtObs2", "NO SE ACEPTAN RECLAMOS POSTERIORES.")
            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Else  'Con Nro de Factura
            Dim rpt As New Reportes.VentasEnviosPorClienteProductoAFAC
            Dim rptmat As New Reportes.VentasEnviosPorClienteProductoMATRaFAC
            Dim rptSinDetalle As New Reportes.VentasEnviosPorClienteProductoAFACSinDetalle
            Dim rptSinDetallemat As New Reportes.VentasEnviosPorClienteProductoAFACSinDetalleMATR

            If chbxMatricial.Checked = True Then
                If rbtSinDetalleProducto.Checked = True Then
                    rptSinDetallemat.SetDataSource([DsRVEnvios])
                    rptSinDetallemat.SetParameterValue("FDesde", FechaDesde.ToString)
                    rptSinDetallemat.SetParameterValue("FHasta", FechaHasta.ToString)
                    rptSinDetallemat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    txt = rptSinDetallemat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")

                    If cmbZona.Text = "%" Then
                        rptSinDetallemat.SetParameterValue("pmtZona", "(Todas las Zonas)")
                    Else
                        rptSinDetallemat.SetParameterValue("pmtZona", cmbZona.Text)
                    End If
                    If cmbCliente.Text = "%" Then
                        rptSinDetallemat.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rptSinDetallemat.SetParameterValue("pmtCliente", "")
                    End If
                    rptSinDetallemat.SetParameterValue("pmtObs1", "Una vez firmada su recepción, las mercaderías recibidas son de ABSOLUTA RESPONSABILIDAD del chofer.")
                    rptSinDetallemat.SetParameterValue("pmtObs2", "NO SE ACEPTAN RECLAMOS POSTERIORES.")
                Else
                    rptmat.SetDataSource([DsRVEnvios])
                    rptmat.SetParameterValue("FDesde", FechaDesde.ToString)
                    rptmat.SetParameterValue("FHasta", FechaHasta.ToString)
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    txt = rptmat.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")

                    If cmbZona.Text = "%" Then
                        rptmat.SetParameterValue("pmtZona", "(Todas las Zonas)")
                    Else
                        rptmat.SetParameterValue("pmtZona", cmbZona.Text)
                    End If
                    If cmbCliente.Text = "%" Then
                        rptmat.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rptmat.SetParameterValue("pmtCliente", "")
                    End If
                    rptmat.SetParameterValue("pmtObs1", "Una vez firmada su recepción, las mercaderías recibidas son de ABSOLUTA RESPONSABILIDAD del chofer.")
                    rptmat.SetParameterValue("pmtObs2", "NO SE ACEPTAN RECLAMOS POSTERIORES.")
                End If
               
            Else
                If rbtSinDetalleProducto.Checked = True Then
                    rptSinDetalle.SetDataSource([DsRVEnvios])
                    rptSinDetalle.SetParameterValue("FDesde", FechaDesde.ToString)
                    rptSinDetalle.SetParameterValue("FHasta", FechaHasta.ToString)
                    rptSinDetalle.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    txt = rptSinDetalle.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")

                    If cmbZona.Text = "%" Then
                        rptSinDetalle.SetParameterValue("pmtZona", "(Todas las Zonas)")
                    Else
                        rptSinDetalle.SetParameterValue("pmtZona", cmbZona.Text)
                    End If
                    If cmbCliente.Text = "%" Then
                        rptSinDetalle.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rptSinDetalle.SetParameterValue("pmtCliente", "")
                    End If
                    rptSinDetalle.SetParameterValue("pmtObs1", "Una vez firmada su recepción, las mercaderías recibidas son de ABSOLUTA RESPONSABILIDAD del chofer.")
                    rptSinDetalle.SetParameterValue("pmtObs2", "NO SE ACEPTAN RECLAMOS POSTERIORES.")

                Else
                    rpt.SetDataSource([DsRVEnvios])
                    rpt.SetParameterValue("FDesde", FechaDesde.ToString)
                    rpt.SetParameterValue("FHasta", FechaHasta.ToString)
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    txt = rpt.ReportDefinition.ReportObjects.Item("NUMCLIENTE2")

                    If cmbZona.Text = "%" Then
                        rpt.SetParameterValue("pmtZona", "(Todas las Zonas)")
                    Else
                        rpt.SetParameterValue("pmtZona", cmbZona.Text)
                    End If
                    If cmbCliente.Text = "%" Then
                        rpt.SetParameterValue("pmtCliente", "(Todos)")
                        txt.Width = 0
                    Else
                        rpt.SetParameterValue("pmtCliente", "")
                    End If
                    rpt.SetParameterValue("pmtObs1", "Una vez firmada su recepción, las mercaderías recibidas son de ABSOLUTA RESPONSABILIDAD del chofer.")
                    rpt.SetParameterValue("pmtObs2", "NO SE ACEPTAN RECLAMOS POSTERIORES.")
                End If
            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    If rbtSinDetalleProducto.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptSinDetallemat
                    Else
                        frm.CrystalReportViewer1.ReportSource = rptmat
                    End If
                Else
                    If rbtSinDetalleProducto.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptSinDetalle
                    Else
                        frm.CrystalReportViewer1.ReportSource = rpt
                    End If
                End If

                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    If rbtSinDetalleProducto.Checked = True Then
                        CrystalReportViewer.ReportSource = rptSinDetallemat
                    Else
                        CrystalReportViewer.ReportSource = rptmat
                    End If
                Else
                    If rbtSinDetalleProducto.Checked = True Then
                        CrystalReportViewer.ReportSource = rptSinDetalle
                    Else
                        CrystalReportViewer.ReportSource = rpt
                    End If
                End If

                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub
    Sub ReporteEnvioPorCliente()

        Dim rpt As New Reportes.VentasEnviosPorCliente
        Dim rptmat As New Reportes.VentasEnviosPorClienteMATR

        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

        'Volvemos al SelectCommand original del Table Adapter (borrando las condiciones de la instancia anterior)"
        Me.RvEnviosPorClienteTableAdapter.selectcommand.CommandText = "SELECT SUM(VD.CANTIDADVENTA) AS CANTIDAD, SUM(VD.PRECIOVENTABRUTO) AS TOTAL, V.NOMBRECLIENTE, Z.DESZONA, V.ESTADO, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA  " & _
        "FROM VENTAS AS V INNER JOIN VENTASDETALLE AS VD ON V.CODVENTA = VD.CODVENTA INNER JOIN CLIENTES ON CLIENTES.CODCLIENTE = V.CODCLIENTE LEFT OUTER JOIN ZONA AS Z ON Z.CODZONA = CLIENTES.CODZONA LEFT OUTER JOIN " & _
        "CIUDAD ON CIUDAD.CODCIUDAD = Z.CODCIUDAD LEFT OUTER JOIN PAIS ON CIUDAD.CODPAIS = PAIS.CODPAIS"

        cmbMoneda.Text = "%"
        FormatF1 = FormatearFiltroCombo(cmbPais, "T")
        FormatF2 = FormatearFiltroCombo(cmbCiudad, "T")
        FormatF3 = FormatearFiltroCombo(cmbZona, "T")
        FormatF4 = FormatearFiltroCombo(cmbMoneda, "T")

        Dim sqlwhere As String = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "Z.DESZONA", FormatF4, "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.RvEnviosPorClienteTableAdapter.selectcommand.CommandText += " WHERE (V.ESTADO = 1) AND (V.FECHAVENTA >= '" & fechadesde2 & "') AND (V.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY V.NOMBRECLIENTE, Z.DESZONA, V.ESTADO, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA ORDER BY V.NOMBRECLIENTE"
        Else
            Me.RvEnviosPorClienteTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (V.ESTADO = 1) AND (V.FECHAVENTA >= '" & fechadesde2 & "') AND (V.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY V.NOMBRECLIENTE, Z.DESZONA, V.ESTADO, CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA ORDER BY V.NOMBRECLIENTE"
        End If

        Me.RvEnviosPorClienteTableAdapter.Fill(Me.DsRVEnvios.RVEnviosPorCliente)

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVEnvios])
            rptmat.SetParameterValue("FDesde", FechaDesde.ToString)
            rptmat.SetParameterValue("FHasta", FechaHasta.ToString)
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtCliente", "Todos")
            If cmbZona.Text = "%" Then
                rptmat.SetParameterValue("pmtZona", "Todas las zonas")
            Else
                rptmat.SetParameterValue("pmtZona", cmbZona.Text)
            End If
        Else
            rpt.SetDataSource([DsRVEnvios])
            rpt.SetParameterValue("FDesde", FechaDesde.ToString)
            rpt.SetParameterValue("FHasta", FechaHasta.ToString)
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtCliente", "Todos")
            If cmbZona.Text = "%" Then
                rpt.SetParameterValue("pmtZona", "Todas las zonas")
            Else
                rpt.SetParameterValue("pmtZona", cmbZona.Text)
            End If
        End If

        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()
        End If

    End Sub
    Sub ReporteEnvioPorZonaProducto()

        Dim rpt As New Reportes.VentasEnviosPorZonaProducto
        Dim rptmat As New Reportes.VentasEnviosPorZonaProductoMATR

        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

        'Volvemos al SelectCommand original del Table Adapter (borrando las condiciones de la instancia anterior)"
        Me.RvEnviosPorZonaProductoTableAdapter.selectcommand.CommandText = "SELECT SUM(VENTASDETALLE.CANTIDADVENTA) AS CANTIDAD, SUM(VENTASDETALLE.PRECIOVENTABRUTO) AS TOTAL, Z.DESZONA, CODIGOS.CODIGO, " & _
                         "LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) AS PRODUCTO " & _
        "FROM            VENTASDETALLE INNER JOIN " & _
                         "PRODUCTOS ON PRODUCTOS.CODPRODUCTO = VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                         "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO INNER JOIN " & _
                         "VENTAS ON VENTASDETALLE.CODVENTA = VENTAS.CODVENTA INNER JOIN " & _
                         "CLIENTES ON CLIENTES.CODCLIENTE = VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                         "ZONA AS Z ON Z.CODZONA = CLIENTES.CODZONA LEFT OUTER JOIN " & _
                         "CIUDAD ON CIUDAD.CODCIUDAD = Z.CODCIUDAD LEFT OUTER JOIN " & _
                         "PAIS ON CIUDAD.CODPAIS = PAIS.CODPAIS"
        cmbMoneda.Text = "%"
        FormatF1 = FormatearFiltroCombo(cmbPais, "T")
        FormatF2 = FormatearFiltroCombo(cmbCiudad, "T")
        FormatF3 = FormatearFiltroCombo(cmbZona, "T")
        FormatF4 = FormatearFiltroCombo(cmbMoneda, "T")
        Dim sqlwhere As String = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "Z.DESZONA", FormatF4, "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.RvEnviosPorZonaProductoTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY Z.DESZONA, CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) ORDER BY PRODUCTO"
        Else
            Me.RvEnviosPorZonaProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') GROUP BY Z.DESZONA, CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) ORDER BY PRODUCTO"
        End If
        Me.RvEnviosPorZonaProductoTableAdapter.Fill(Me.DsRVEnvios.RVEnviosPorZonaProducto)
        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVEnvios])
            rptmat.SetParameterValue("FDesde", FechaDesde.ToString)
            rptmat.SetParameterValue("FHasta", FechaHasta.ToString)
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rptmat.SetParameterValue("pmtCliente", "Todos")
            If cmbZona.Text = "%" Then
                rptmat.SetParameterValue("pmtZona", "Todas las zonas")
            Else
                rptmat.SetParameterValue("pmtZona", cmbZona.Text)
            End If
            rptmat.SetParameterValue("pmtObs1", "Una vez firmada su recepción, las mercaderías recibidas son de ABSOLUTA RESPONSABILIDAD del chofer.")
            rptmat.SetParameterValue("pmtObs2", "NO SE ACEPTAN RECLAMOS POSTERIORES.")
        Else
            rpt.SetDataSource([DsRVEnvios])
            rpt.SetParameterValue("FDesde", FechaDesde.ToString)
            rpt.SetParameterValue("FHasta", FechaHasta.ToString)
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtCliente", "Todos")
            If cmbZona.Text = "%" Then
                rpt.SetParameterValue("pmtZona", "Todas las zonas")
            Else
                rpt.SetParameterValue("pmtZona", cmbZona.Text)
            End If
            rpt.SetParameterValue("pmtObs1", "Una vez firmada su recepción, las mercaderías recibidas son de ABSOLUTA RESPONSABILIDAD del chofer.")
            rpt.SetParameterValue("pmtObs2", "NO SE ACEPTAN RECLAMOS POSTERIORES.")
        End If
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub ReporteFacturaAcobrar()

        Dim Primero As Integer = 0
        Dim Primero1 As Integer = 0

        Dim rpt As New Reportes.VentasFacturaACobrar
        Me.FacturaACobrarTableAdapter.Fill(Me.DsReporteVentas.FacturaACobrar, cmbZona.Text, cmbCliente.Text, cmbCiudad.Text)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub

    Sub ReporteProductoMasVendido()
        Dim Primero As Integer = 0
        Dim Primero1 As Integer = 0
        If rbAgrupFamillia.Checked = True Then
            Dim rpt As New Reportes.VentasProductosMasVendidosConAgrup
            FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
            Me.VentasProductosMasVendidosTableAdapter.Fill(Me.DsReporteVentas.VentasProductosMasVendidos, FechaHasta, FechaDesde, FormatF1)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else
            Dim rpt As New Reportes.VentasProductosMasVendidos
            FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
            Me.VentasProductosMasVendidosTableAdapter.Fill(Me.DsReporteVentas.VentasProductosMasVendidos, FechaHasta, FechaDesde, FormatF1)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub
    Sub ReporteCategoriasMasVendidas()

        Dim rpt As New Reportes.VentasCategoriasMasVendidas
        Me.CategoriasMasVendidasTableAdapter.Fill(Me.DsReporteVentas.CategoriasMasVendidas, FechaDesde, FechaHasta)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Function obtenerwhere(ByVal Filtro1 As String, ByVal nombrecampof1 As String, ByVal Filtro2 As String, ByVal nombrecampof2 As String, ByVal Filtro3 As String, ByVal nombrecampof3 As String, ByVal Filtro4 As String, ByVal nombrecampof4 As String, ByVal tipo1 As String, ByVal tipo2 As String, ByVal tipo3 As String, ByVal tipo4 As String, Optional ByVal filtro5 As String = "%", Optional ByVal nombrecampof5 As String = "", Optional ByVal tipo5 As String = "", Optional ByVal filtro6 As String = "%", Optional ByVal nombrecampof6 As String = "", Optional ByVal tipo6 As String = "", Optional ByVal filtro7 As String = "%", Optional ByVal nombrecampof7 As String = "", Optional ByVal tipo7 As String = "", Optional ByVal Filtro8 As String = "%", Optional ByVal nombrecampof8 As String = "", Optional ByVal tipo8 As String = "")

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
        Dim SiFiltro7 As Boolean = False
        Dim CtrlFiltro8 As String = ""
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
            SiFiltro7 = False
        Else
            SiFiltro7 = True
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

        If Filtro8 = "%" Or Filtro8 = "" Then
            'nada
        Else
            'SiFiltro8 = True
            If SiFiltro1 = True Or SiFiltro2 = True Or SiFiltro3 = True Or SiFiltro4 = True Or SiFiltro5 = True Or SiFiltro6 = True Or SiFiltro7 = True Then
                If tipo8 = "Cadena Text" Then
                    CtrlFiltro8 = " AND " + nombrecampof8 + " = '" & Filtro8 & "'"
                ElseIf tipo8 = "Numero Text" Then
                    CtrlFiltro8 = " AND " + nombrecampof8 + " = " & Filtro8
                ElseIf tipo8 = "CodigoIn" Then
                    CtrlFiltro8 = " AND " + nombrecampof8 + " IN (" & Filtro8 & ")"
                ElseIf tipo8 = "CodigoIn NULL" Then
                    CtrlFiltro8 = " AND (" + nombrecampof8 + " IN (" & Filtro8 & ") OR " & nombrecampof8 & " IS NULL)"
                ElseIf tipo8 = "Especial" Then
                    CtrlFiltro8 = " AND " + Filtro8
                End If
            Else
                If tipo8 = "Cadena Text" Then
                    CtrlFiltro8 = nombrecampof8 + " = '" & Filtro8 & "'"
                ElseIf tipo8 = "Numero Text" Then
                    CtrlFiltro8 = nombrecampof8 + " = " & Filtro8 & ""
                ElseIf tipo8 = "CodigoIn" Then
                    CtrlFiltro8 = nombrecampof8 + " IN (" & Filtro8 & ")"
                ElseIf tipo8 = "CodigoIn NULL" Then
                    CtrlFiltro8 = "(" & nombrecampof8 + " IN (" & Filtro8 & ") OR " & nombrecampof8 & " IS NULL)"
                ElseIf tipo8 = "Especial" Then
                    CtrlFiltro8 = Filtro8
                End If
            End If
        End If

        consultawhere = CtrlFiltro1 + CtrlFiltro2 + CtrlFiltro3 + CtrlFiltro4 + CtrlFiltro5 + CtrlFiltro6 + CtrlFiltro7 + CtrlFiltro8

        Return consultawhere
    End Function
    Sub ReporteListaClienteNombreCliente()
        Try

            If Config4 = "Nombre del Cliente" Then
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
                "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC, dbo.CLIENTES.NOMBREFANTASIA " & _
                "FROM            CLIENTES LEFT OUTER JOIN " & _
                       "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                       "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                       "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                       "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS order by CLIENTES.NOMBRE "
            Else
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA AS NOMBRE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
                "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC, dbo.CLIENTES.NOMBREFANTASIA " & _
                "FROM            CLIENTES LEFT OUTER JOIN " & _
                      "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                      "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                      "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                      "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS order by CLIENTES.NUMCLIENTE "
            End If

            Me.RvListaClientesTableAdapter.Fill(DsRVClientes.RVListaClientes)

            Dim rpt As New Reportes.VentasListaCliente
            Dim rptmat As New Reportes.VentasListaClienteMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVClientes])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtNroCliente", "(Todos)")

            Else
                rpt.SetDataSource([DsRVClientes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                rpt.SetParameterValue("pmtNroCliente", "(Todos)")

            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub ReporteVentasPorVendedorPorCliente()

        Dim fechadesde2, fechahasta2 As String
        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

        'Volvemos al SelectCommand original del Table Adapter (borrando las condiciones de la instancia anterior)"
        Me.RvVentasPorVendedorTableAdapter.selectcommand.CommandText = "SELECT VENDEDOR.DESVENDEDOR, VENTAS.TOTALVENTA AS Total, VENTAS.NOMBRECLIENTE, VENTAS.CODCLIENTE, CLIENTES.RUC, VENTAS.FECHAVENTA, " & _
                        "CLIENTES.NUMCLIENTE, VENTAS.TOTALIVA, CLIENTES.NOMBREFANTASIA " & _
        "FROM            VENTAS INNER JOIN " & _
                         "VENDEDOR ON VENTAS.CODVENDEDOR = VENDEDOR.CODVENDEDOR INNER JOIN " & _
                         "CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE "
        FormatF4 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")

        Dim sqlwhere As String = obtenerwhere("%", "", "%", "", "%", "", FormatF4, "VENDEDOR.CODVENDEDOR", "Cadena Text", "Cadena Text", "Cadena Text", "CodigoIn")
        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.RvVentasPorVendedorTableAdapter.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.NOMBRECLIENTE"
        Else
            Me.RvVentasPorVendedorTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.NOMBRECLIENTE"
        End If
        Me.RvVentasPorVendedorTableAdapter.Fill(Me.DsRVFacturacion.RVVentasPorVendedor)

        Dim rpt As New Reportes.VentasVendedorPorCliente
        Dim rptmat As New Reportes.VentasVendedorPorClienteMATR

        If chbxMatricial.Checked = True Then
            rptmat.SetDataSource([DsRVFacturacion])
            rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)

            If cmbVendedor.Text = "%" Then
                rptmat.SetParameterValue("pmtVendedor", "(Todos)")
            Else
                rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
            End If
            If rbIVASI.Checked = True Then
                rptmat.SetParameterValue("pmtIVA", "Si")
            ElseIf rbIVANO.Checked = True Then
                rptmat.SetParameterValue("pmtIVA", "No")
            End If
            rptmat.SetParameterValue("pmtRango", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
        Else
            rpt.SetDataSource([DsRVFacturacion])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            If cmbVendedor.Text = "%" Then
                rpt.SetParameterValue("pmtVendedor", "(Todos)")
            Else
                rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
            End If
            rpt.SetParameterValue("pmtRango", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            If rbIVASI.Checked = True Then
                rpt.SetParameterValue("pmtIVA", "Si")
            ElseIf rbIVANO.Checked = True Then
                rpt.SetParameterValue("pmtIVA", "No")
            End If
        End If

        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            If chbxMatricial.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                frm.CrystalReportViewer1.ReportSource = rpt
            End If
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            If chbxMatricial.Checked = True Then
                CrystalReportViewer.ReportSource = rptmat
            Else
                CrystalReportViewer.ReportSource = rpt
            End If
            CrystalReportViewer.Refresh()
        End If


    End Sub
    Sub ReporteListaClienteAVendedorporZona()

        Try
            If Config4 = "Nombre del Cliente" Then
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
                "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC " & _
                "FROM            CLIENTES LEFT OUTER JOIN " & _
                       "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                       "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                       "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                       "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS"
            Else
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA AS NOMBRE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
               "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC " & _
               "FROM            CLIENTES LEFT OUTER JOIN " & _
                      "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                      "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                      "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                      "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS"
            End If

            FormatF1 = FormatearFiltroCombo(cmbPais, "T")
            FormatF2 = FormatearFiltroCombo(cmbCiudad, "T")
            FormatF3 = FormatearFiltroCombo(cmbZona, "T")
            FormatF4 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")

            Dim sqlwhere As String = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "ZONA.DESZONA", FormatF4, "VENDEDOR.CODVENDEDOR", "Cadena Text", "Cadena Text", "Cadena Text", "CodigoIn")

            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                If Config4 = "Nombre del Cliente" Then
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " ORDER BY CLIENTES.NOMBRE, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                Else
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " ORDER BY CLIENTES.NOMBREFANTASIA, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                End If

            Else
                If Config4 = "Nombre del Cliente" Then
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY CLIENTES.NOMBRE, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                Else
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY CLIENTES.NOMBREFANTASIA, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                End If
            End If
            Me.RvListaClientesTableAdapter.Fill(DsRVClientes.RVListaClientes)

            Dim rpt As New Reportes.VentasListaClienteAgrupVendZona
            Dim rptmat As New Reportes.VentasListaClienteAgrupVendZonaMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVClientes])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtOrdenadoPor", "Nombre Cliente")
                rptmat.SetParameterValue("pmtNroCliente", "(Todos)")

                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbZona.Text = "%" Then
                    rptmat.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rptmat.SetParameterValue("pmtZona", cmbZona.Text)
                End If
            Else
                rpt.SetDataSource([DsRVClientes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtOrdenadoPor", "Nombre Cliente")
                rpt.SetParameterValue("pmtNroCliente", "(Todos)")

                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbZona.Text = "%" Then
                    rpt.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rpt.SetParameterValue("pmtZona", cmbZona.Text)
                End If
            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub ReporteListaClienteAZona()

        Try
            If Config4 = "Nombre del Cliente" Then
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE + ' / ' + CLIENTES.NOMBREFANTASIA AS NOMBRECLIENTE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
                "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC " & _
                "FROM            CLIENTES LEFT OUTER JOIN " & _
                       "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                       "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                       "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                       "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS"
            Else
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE + ' / ' + CLIENTES.NOMBREFANTASIA AS NOMBRECLIENTE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
               "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC " & _
               "FROM            CLIENTES LEFT OUTER JOIN " & _
                      "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                      "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                      "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                      "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS"
            End If

            FormatF1 = FormatearFiltroCombo(cmbPais, "T")
            FormatF2 = FormatearFiltroCombo(cmbCiudad, "T")
            FormatF3 = FormatearFiltroCombo(cmbZona, "T")
            FormatF4 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")

            Dim sqlwhere As String = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "ZONA.DESZONA", FormatF4, "VENDEDOR.CODVENDEDOR", "Cadena Text", "Cadena Text", "Cadena Text", "CodigoIn")

            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                If Config4 = "Nombre del Cliente" Then
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " ORDER BY CLIENTES.NOMBRE, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                Else
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " ORDER BY CLIENTES.NOMBREFANTASIA, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                End If

            Else
                If Config4 = "Nombre del Cliente" Then
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY CLIENTES.NOMBRE, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                Else
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY CLIENTES.NOMBREFANTASIA, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                End If
            End If
            Me.RvListaClientesTableAdapter.Fill(DsRVClientes.RVListaClientes)

            Dim rpt As New Reportes.VentasListaClientePorZona
            Dim rptmat As New Reportes.VentasListaClientePorZonaMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVClientes])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtOrdenadoPor", "Nombre Cliente")
                rptmat.SetParameterValue("pmtNroCliente", "(Todos)")

                If cmbCiudad.Text = "%" Then
                    rptmat.SetParameterValue("pmtCiudad", "(Todas las Ciudades)")
                Else
                    rptmat.SetParameterValue("pmtCiudad", cmbCiudad.Text)
                End If
                If cmbZona.Text = "%" Then
                    rptmat.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rptmat.SetParameterValue("pmtZona", cmbZona.Text)
                End If
            Else
                rpt.SetDataSource([DsRVClientes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtOrdenadoPor", "Nombre Cliente")
                rpt.SetParameterValue("pmtNroCliente", "(Todos)")

                If cmbCiudad.Text = "%" Then
                    rpt.SetParameterValue("pmtCiudad", "(Todas las Ciudades)")
                Else
                    rpt.SetParameterValue("pmtCiudad", cmbCiudad.Text)
                End If
                If cmbZona.Text = "%" Then
                    rpt.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rpt.SetParameterValue("pmtZona", cmbZona.Text)
                End If
            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub ReporteListaClienteAVendedor()

        Try
            If Config4 = "Nombre del Cliente" Then
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
                "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC " & _
                "FROM            CLIENTES LEFT OUTER JOIN " & _
                       "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                       "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                       "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                       "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS"
            Else
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA AS NOMBRE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
                "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC " & _
                "FROM            CLIENTES LEFT OUTER JOIN " & _
                       "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                       "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                       "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                       "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS"
            End If

            FormatF1 = FormatearFiltroCombo(cmbPais, "T")
            FormatF2 = FormatearFiltroCombo(cmbCiudad, "T")
            FormatF3 = FormatearFiltroCombo(cmbZona, "T")
            FormatF4 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")

            Dim sqlwhere As String = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "ZONA.DESZONA", FormatF4, "VENDEDOR.CODVENDEDOR", "Cadena Text", "Cadena Text", "Cadena Text", "CodigoIn")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                If Config4 = "Nombre del Cliente" Then
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " ORDER BY CLIENTES.NOMBRE, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                Else
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " ORDER BY CLIENTES.NOMBREFANTASIA, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                End If
            Else
                If Config4 = "Nombre del Cliente" Then
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY CLIENTES.NOMBRE, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                Else
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY CLIENTES.NOMBREFANTASIA, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                End If
            End If
            Me.RvListaClientesTableAdapter.Fill(DsRVClientes.RVListaClientes)

            Dim rpt As New Reportes.VentasListaClientePorVendedor
            Dim rptmat As New Reportes.VentasListaClientePorVendedorMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVClientes])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtOrdenadoPor", "Nombre Cliente")
                rptmat.SetParameterValue("pmtNroCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If

                If cmbCiudad.Text = "%" Then
                    rptmat.SetParameterValue("pmtCiudad", "(Todas las Ciudades)")
                Else
                    rptmat.SetParameterValue("pmtCiudad", cmbCiudad.Text)
                End If
                If cmbZona.Text = "%" Then
                    rptmat.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rptmat.SetParameterValue("pmtZona", cmbZona.Text)
                End If
            Else
                rpt.SetDataSource([DsRVClientes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtOrdenadoPor", "Nombre Cliente")
                rpt.SetParameterValue("pmtNroCliente", "(Todos)")
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If

                If cmbCiudad.Text = "%" Then
                    rpt.SetParameterValue("pmtCiudad", "(Todas las Ciudades)")
                Else
                    rpt.SetParameterValue("pmtCiudad", cmbCiudad.Text)
                End If
                If cmbZona.Text = "%" Then
                    rpt.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rpt.SetParameterValue("pmtZona", cmbZona.Text)
                End If
            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub ReporteListaClienteACategoria()
        Try
            If Config4 = "Nombre del Cliente" Then
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
             "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC, CATEGORIACLIENTE.DESCATEGORIACLIENTE, CATEGORIACLIENTE.CODCATEGORIACLIENTE " & _
             "FROM            CLIENTES LEFT OUTER JOIN " & _
                       "CATEGORIACLIENTE ON CLIENTES.CODCATEGORIACLIENTE = CATEGORIACLIENTE.CODCATEGORIACLIENTE LEFT OUTER JOIN " & _
                       "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                       "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                       "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                       "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS"
            Else
                Me.RvListaClientesTableAdapter.selectcommand.CommandText = "SELECT CLIENTES.NUMCLIENTE, CLIENTES.NOMBREFANTASIA AS NOMBRE, CLIENTES.DIRECCION, CLIENTES.TELEFONO, PAIS.DESPAIS, CIUDAD.DESCIUDAD, " & _
             "ZONA.DESZONA, CLIENTES.CODCLIENTE, VENDEDOR.CODVENDEDOR, VENDEDOR.NUMVENDEDOR, VENDEDOR.DESVENDEDOR, CLIENTES.RUC, CATEGORIACLIENTE.DESCATEGORIACLIENTE, CATEGORIACLIENTE.CODCATEGORIACLIENTE " & _
             "FROM            CLIENTES LEFT OUTER JOIN " & _
                       "CATEGORIACLIENTE ON CLIENTES.CODCATEGORIACLIENTE = CATEGORIACLIENTE.CODCATEGORIACLIENTE LEFT OUTER JOIN " & _
                       "VENDEDOR ON CLIENTES.CODVENDEDOR = VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                       "PAIS ON CLIENTES.CODDEPARTAMENTO = PAIS.CODPAIS LEFT OUTER JOIN " & _
                       "ZONA ON CLIENTES.CODZONA = ZONA.CODZONA LEFT OUTER JOIN " & _
                       "CIUDAD ON ZONA.CODCIUDAD = CIUDAD.CODCIUDAD AND CLIENTES.CODCIUDAD = CIUDAD.CODCIUDAD AND PAIS.CODPAIS = CIUDAD.CODPAIS"
            End If

            FormatF1 = FormatearFiltroCombo(cmbPais, "T")
            FormatF2 = FormatearFiltroCombo(cmbCiudad, "T")
            FormatF3 = FormatearFiltroCombo(cmbZona, "T")
            FormatF4 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")

            Dim sqlwhere As String = obtenerwhere(FormatF1, "PAIS.DESPAIS", FormatF2, "CIUDAD.DESCIUDAD", FormatF3, "ZONA.DESZONA", FormatF4, "CLIENTES.CODCATEGORIACLIENTE", "Cadena Text", "Cadena Text", "Cadena Text", "CodigoIn")
            If Trim(sqlwhere) = "" Then ' se eligieron todos %
                If Config4 = "Nombre del Cliente" Then
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " ORDER BY CLIENTES.NOMBRE, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                Else
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " ORDER BY CLIENTES.NOMBREFANTASIA, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                End If
            Else
                If Config4 = "Nombre del Cliente" Then
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY CLIENTES.NOMBRE, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                Else
                    Me.RvListaClientesTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY CLIENTES.NOMBREFANTASIA, ZONA.DESZONA, VENDEDOR.DESVENDEDOR"
                End If
            End If
            Me.RvListaClientesTableAdapter.Fill(DsRVClientes.RVListaClientes)
            
            Dim rpt As New Reportes.VentasListaClientePorCategoria
            Dim rptmat As New Reportes.VentasListaClientePorCategoriaMATR

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVClientes])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtOrdenadoPor", "Nombre Cliente")
                rptmat.SetParameterValue("pmtNroCliente", "(Todos)")
                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategoria", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtCategoria", cmbCategCliente.Text)
                End If

                If cmbCiudad.Text = "%" Then
                    rptmat.SetParameterValue("pmtCiudad", "(Todas las Ciudades)")
                Else
                    rptmat.SetParameterValue("pmtCiudad", cmbCiudad.Text)
                End If
                If cmbZona.Text = "%" Then
                    rptmat.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rptmat.SetParameterValue("pmtZona", cmbZona.Text)
                End If
            Else
                rpt.SetDataSource([DsRVClientes])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtOrdenadoPor", "Nombre Cliente")
                rpt.SetParameterValue("pmtNroCliente", "(Todos)")
                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategoria", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtCategoria", cmbCategCliente.Text)
                End If

                If cmbCiudad.Text = "%" Then
                    rpt.SetParameterValue("pmtCiudad", "(Todas las Ciudades)")
                Else
                    rpt.SetParameterValue("pmtCiudad", cmbCiudad.Text)
                End If
                If cmbZona.Text = "%" Then
                    rpt.SetParameterValue("pmtZona", "(Todas las Zonas)")
                Else
                    rpt.SetParameterValue("pmtZona", cmbZona.Text)
                End If
            End If

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub ReporteVentasTipoPago()
        sql = ""
        sql1 = ""
        Dim Primero As Integer = 0
        Dim Primero1 As Integer = 0


        Dim rpt As New Reportes.VentasPorTipoPago
        Me.VentasPorTipoPagoTableAdapter.Fill(Me.DsReporteVentas.VentasPorTipoPago, FechaDesde, FechaHasta, cmbCliente.Text)
        rpt.SetDataSource([DsReporteVentas])

        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub

    Private Sub proyeccioncobros()  'Will.i.am
        Dim rpt As New Reportes.ProyeccionCobros

        If cmbCliente.Text = "%" Then
            Me.ProyeccionCobrosTableAdapter.FillBy(DsProyeccionCobros.ProyeccionCobros)
            Me.EMPRESATableAdapter.Fill(DsProyeccionCobros.EMPRESA)
        Else
            Me.ProyeccionCobrosTableAdapter.Fill(DsProyeccionCobros.ProyeccionCobros, cmbCliente.SelectedValue)
            Me.EMPRESATableAdapter.Fill(DsProyeccionCobros.EMPRESA)
        End If

        rpt.SetDataSource([DsProyeccionCobros])

        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Sub ReporteVentasProductoDetallado()

        Dim Primero As Integer = 0
        Dim Primero1 As Integer = 0
        FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        If chbxCodProducto.Checked = False Then

            Dim rpt As New Reportes.VentasPorProducto
            If cmbSucursal.Text = "%" Then
                If cbxCategoria.Text = "%" And cbxLinea.Text = "%" And cbxRubro.Text = "%" Then
                    Me.VentasProductoDetallladoTableAdapter.FillByProd(Me.DsReporteVentas.VentasProductoDetalllado, Trim(cmbProducto.Text), FechaDesde, FechaHasta)
                Else
                    Me.VentasProductoDetallladoTableAdapter.FillByFamProd(Me.DsReporteVentas.VentasProductoDetalllado, Trim(cmbProducto.Text), FechaDesde, FechaHasta, cbxLinea.Text, cbxRubro.Text, cbxCategoria.Text)
                End If
            Else
                If cbxCategoria.Text = "%" And cbxLinea.Text = "%" And cbxRubro.Text = "%" Then
                    Me.VentasProductoDetallladoTableAdapter.FillByProdSuc(Me.DsReporteVentas.VentasProductoDetalllado, Trim(cmbProducto.Text), FechaDesde, FechaHasta, FormatF1)
                Else
                    Me.VentasProductoDetallladoTableAdapter.FillByFamProdSuc(Me.DsReporteVentas.VentasProductoDetalllado, Trim(cmbProducto.Text), FechaDesde, FechaHasta, FormatF1, cbxLinea.Text, cbxRubro.Text, cbxCategoria.Text)
                End If
            End If

            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else

            Dim rpt As New Reportes.VentasPorProducto
            If cmbSucursal.Text = "%" Then
                If cbxCategoria.Text = "%" And cbxLinea.Text = "%" And cbxRubro.Text = "%" Then
                    Me.VentasProductoDetallladoTableAdapter.FillByPlan(Me.DsReporteVentas.VentasProductoDetalllado, FechaDesde, FechaHasta, tbxcodProd.Text)
                Else
                    Me.VentasProductoDetallladoTableAdapter.FillByFamPlan(Me.DsReporteVentas.VentasProductoDetalllado, FechaDesde, FechaHasta, cbxLinea.Text, cbxRubro.Text, cbxCategoria.Text, tbxcodProd.Text)
                End If
            Else
                If cbxCategoria.Text = "%" And cbxLinea.Text = "%" And cbxRubro.Text = "%" Then
                    Me.VentasProductoDetallladoTableAdapter.FillByPlanSuc(Me.DsReporteVentas.VentasProductoDetalllado, FechaDesde, FechaHasta, FormatF1, tbxcodProd.Text)
                Else
                    Me.VentasProductoDetallladoTableAdapter.FillByFamPlanSuc(Me.DsReporteVentas.VentasProductoDetalllado, FechaDesde, FechaHasta, FormatF1, cbxLinea.Text, cbxRubro.Text, cbxCategoria.Text, tbxcodProd.Text)
                End If
            End If
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub FiltroReporteVentas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If ProductosGroupBox.Visible = True Then
                ProductosGroupBox.Visible = False
                ProductosGroupBox.SendToBack()
                cmbProducto.Focus()
            ElseIf GroupBoxCliente.Visible = True Then
                GroupBoxCliente.Visible = False
                GroupBoxCliente.SendToBack()
                cmbCliente.Focus()
            End If
        End If
    End Sub

    Private Sub ReporteVentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsProyeccionCobros.EMPRESA' Puede moverla o quitarla según sea necesario.
        Me.EMPRESATableAdapter.Fill(Me.DsProyeccionCobros.EMPRESA)

        Me.RUBROTableAdapter.Fill(Me.DsReporteVentas.RUBRO)
        Me.LINEATableAdapter.Fill(Me.DsReporteVentas.LINEA)

        rbtDia.Checked = True
        BanCargaProductos = False
        BanComprVent = False
        BanCompNC = False

        ser = New BDConexión.BDConexion
        ObtenerConfig()

        Me.CAJATableAdapter.Fill(Me.DsReporteVentas.CAJA)
        Me.MONEDATableAdapter.Fill(Me.DsReporteVentas.MONEDA)
        Me.PAISTableAdapter.Fill(Me.DsReporteVentas.PAIS)
        Me.ZONATableAdapter.Fill(Me.DsReporteVentas.ZONA)
        Me.CIUDADTableAdapter.Fill(Me.DsReporteVentas.CIUDAD)
        Me.FAMILIATableAdapter.Fill(Me.DsReporteVentas.FAMILIA)
        Me.CLIENTESTableAdapter.FillBy(Me.DsReporteVentas.CLIENTES)

        Dim dr As DataRow
        dtVendedores = Me.VENDEDORTableAdapter.GetData
        If dtVendedores.Rows.Count > 0 Then
            For i = 0 To dtVendedores.Rows.Count - 1
                dr = dtVendedores.Rows.Item(i)
                cmbVendedor.Items.Add(dr("DESVENDEDOR"))
            Next
        End If

        dtCategoriaClientes = Me.RventascategoriaclienteTableAdapter.GetData()
        If dtCategoriaClientes.Rows.Count > 0 Then
            For i = 0 To dtCategoriaClientes.Rows.Count - 1
                dr = dtCategoriaClientes.Rows.Item(i)
                cmbCategCliente.Items.Add(dr("DESCATEGORIACLIENTE"))
            Next
        End If

        dtZonas = Me.ZONATableAdapter.GetData()
        If dtZonas.Rows.Count > 0 Then
            For i = 0 To dtZonas.Rows.Count - 1
                dr = dtZonas.Rows.Item(i)
                cmbZona1.Items.Add(dr("DESZONA"))
            Next
        End If

        dtListaPrecio = Me.TIPOCLIENTETableAdapter.GetData()
        If dtListaPrecio.Rows.Count > 0 Then
            For i = 0 To dtListaPrecio.Rows.Count - 1
                dr = dtListaPrecio.Rows.Item(i)
                cmbListaPrecio.Items.Add(dr("DESTIPOCLIENTE"))
            Next
        End If

        dtSucursal = Me.SUCURSALTableAdapter.GetData()
        If dtSucursal.Rows.Count > 0 Then
            For i = 0 To dtSucursal.Rows.Count - 1
                dr = dtSucursal.Rows.Item(i)
                cmbSucursal.Items.Add(dr("DESSUCURSAL"))
            Next
        End If

        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)

        cmbVendedor.AccessibleName = "False"
        cmbZona1.AccessibleName = "False"
        cmbTipo.AccessibleName = "False"
        cmbComprobante.AccessibleName = "False"
        cmbSucursal.AccessibleName = "False"
        cmbListaPrecio.AccessibleName = "False"
        cmbCategCliente.AccessibleName = "False"

        pnlFiltros.Visible = False
        cargarListaReportes()
        PintarCeldas()
        Dim rpt As New Reportes.ReporteBlanco
        rpt.SetParameterValue("pmtReporteName", "Reportes Ventas")
        CrystalReportViewer.ReportSource = rpt

        BuscarTextBox.Focus()


    End Sub

    Private Sub cargarListaReportes()
        ListaReportes = {{"Titulo", "Cajas y Cobros", "Cajas y Cobros,Arqueo,Caja,Detallado,Resumen,IVA,Recibos,Facturas,Comprobantes Pendientes"},
                         {"rptDiarioCajaDet", "Diario de Caja Detallado", "Cajas y Cobros Arqueo"},
                         {"rptDiarioCajaRes", "Resumen de Caja", "Cajas y Cobros Arqueo"},
                         {"rptDiarioCajaResIva", "Resumen de Caja Con IVA Ventas", "Cajas y Cobros Arqueo"},
                         {"rptFacturasXRecibo", "Facturas por Recibo", "Cajas y Cobros"},
                         {"rptFacturasACobrar", "Facturas a Cobrar", "Cajas y Cobros"},
                         {"rptSaldoCliente", "Composición de Saldo de Clientes", "Cajas y Cobros"},
                         {"rptRecibosClientes", "Recibo de Clientes", "Cajas y Cobros"},
                         {"rptRecibosClientesDet", "Recibo de Clientes Detallado", "Cajas y Cobros"},
                         {"rptRecibosXFactura", "Recibos por Factura", "Cajas y Cobros"},
                         {"rptPendienteCobro", "Comprobantes Pendientes", "Cajas y Cobros"},
                         {"rptPendienteCobroDet", "Comprobantes Pendientes Detallado", "Cajas y Cobros"},
                         {"rptlistadorecibos", "Listado de Recibos", "Cajas y Cobros"},
                         {"rptProyeccionCobros", "Proyeccion de Cobros", "Cajas y Cobros"},
                    {"Titulo", "Clientes", "Lista,Cuenta,Corriente,Agrupados,Zona,Vendedor"},
                         {"rptClientesAtrasados", "Clientes Atrasados", "cuenta,Corriente, Clientes"},
                         {"rptAnalisisSaldo", "Análisis de Saldos", "cuenta,Corriente, Clientes"},
                         {"rptEstadoCuenta", "Estado de Cuenta Cliente / Mov. Historico", "historico, cuenta,Corriente, Clientes"},
                         {"rptListaCliente", "Lista de Clientes", "Clientes"},
                         {"rptListaClientesAporZona", "Lista de Clientes Agrup. por Zona", " Clientes"},
                         {"rptListaClientesAporVendedor", "Lista de Clientes Agrup. por Vendedor", "Clientes"},
                         {"rptListaClientesAporVendedorporZona", "Lista de Clientes Agrup. por Vendedor y Zona", "Clientes"},
                         {"rptListaClientesAporCategoria", "Lista de Clientes Agrupados por Categoría", "Clientes"},
                         {"rptListaClientesporListadeprecio", "Lista de Clientes por Lista de precios", "Clientes"},
                    {"Titulo", "Presupuestos", "Presupuesto"},
                         {"rptListaPresupuesto", "Lista de Presupuesto a Clientes", "Presupuesto"},
                         {"rptListaPresupuestoSC", "Lista de Presupuesto Detallado", "Presupuesto"},
                    {"Titulo", "Envíos", "Envios Pedidos Pendientes por Producto por Cliente Por Zona - Producto"},
                         {"rptMovRemision", "Movimiento por Remisiones", "Movimientos"},
                         {"rptEnvioPorCliente", "Envio Por Cliente Resumido", ""},
                         {"rptEnvioPorClienteProducto", "Envio Por Cliente Detallado", ""},
                         {"rptEnvioZonaProducto", "Envio Por Zona - Producto", ""},
                         {"rptPendienteProducto", "Pedidos Pendientes por Producto", "Envio"},
                         {"rptPendienteCliente", "Pedidos Pendientes por Cliente", "Envio"},
                    {"Titulo", "Estadísticas", "Estadisticas Dias desde Ultima Venta Dias Ultima Compra Categorias Productos Menos Vendidos Productos mas Vendidos Ranking de (Top 20) Comparativo Categoria Sucursal"},
                         {"rptDiasVentas", "Dias desde Ultima Venta", "Estadistica Estadísticas"},
                         {"frmDiasUltimaCompra", "Dias Ultima Compra", "Estadistica Estadísticas"},
                         {"rptFacturas", "Facturas Por Periodo (Margen de Ganancia)", "Información de Ventas Informacion de Ventas"},
                         {"rptFacturasAgrupCli", "Facturas Agrupadas por Cliente", "Información de Ventas Informacion de Ventas"},
                         {"rptFacturasPorProductoPorCliente", "Facturas Por Periodo por Cliente por Producto", "Información de Ventas Informacion de Ventas"},
                         {"rptFacturasPorProductoResumido", "Facturas Por Periodo Agrup. por Producto", "Información de Ventas Informacion de Ventas"},
                         {"rptFacturasPorProductoPorFecha", "Facturas Por Periodo Agrup. por Fecha", "Información de Ventas Informacion de Ventas"},
                         {"rptIncidenciaNCVTA", "Incidencia de Notas de Crédito sobre Ventas", "Estadísticas Estadisticas"},
                         {"rptProdVendidosTop20", "Productos más Vendidos (Top 20)", "Estadísticas Estadistica Productos mas Vendidos"},
                         {"rptRankingClientes", "Ranking de Clientes", "Estadistica Estadísticas"},
                         {"rptRankingProductos", "Ranking de Productos", "Estadistica Estadísticas"},
                         {"rptVentasCliXProd", "Ventas a Clientes Por Producto", "Estadistica Estadísticas"},
                         {"rptVentasCatTop20", "Ventas por Categoria (Top 20)", "Estadistica Estadísticas"},
                         {"rptVentasTipoPago", "Ventas por Tipo de Pago", "Tipo Ventas Pago"},
                         {"rptVentasPorCliente", "Ventas Por Cliente", "Información de Ventas Informacion de Ventas"},
                         {"rptVentaProdTop20", "Ventas de Productos (Top 20)", "Estadistica Estadísticas"},
                         {"rptVentasProdXCli", "Ventas de Productos Por Cliente", "Estadistica Estadísticas"},
                         {"rptVentaProd", "Ventas Por Producto", "Estadistica Estadísticas"},
                         {"rptVentaSucursal", "Ventas por Sucursal", "Estadistica Estadísticas"},
                         {"rptComprVentasPorVendedorProductoResumido", "Ventas por Vendedor - Producto", "Vendedores"},
                         {"rptVentasPorZona", "Ventas Por Zona Por Periodo", "Estadísticas Estadistica"},
                         {"rptVentasPorZonaPromedio", "Ventas Por Zona - Promedio", "Estadísticas Estadistica"},
                         {"rptVentaVsCostoPorProducto", "Ventas Vs. Costo por Producto", "Estadistica Estadísticas"},
                         {"rptVentaVsCostoPorCategoria", "Ventas Vs. Costo por Categoría", "Estadistica Estadísticas"},
                         {"rptutilidadventa", "Utilidad de Venta Detallada", "Estadistica Estadísticas"},
                         {"rptventaporcentajeventa", "Porcentaje de Venta", "Estadistica Estadísticas"},
                         {"rptVentasDetalladaXCliente", "Ventas Detallada por Cliente", "Ventas Detalladas de Clientes"},
                    {"Titulo", "Información de Ventas", " Zona de Resumido por Producto Facturas Informacion Detallado"},
                         {"rptFacturasResumido", "Facturas Lista", "Información de Ventas Informacion de Ventas"},
                         {"rptVentaDetallado", "Ventas Detalladas", "Información de Ventas Informacion de Ventas"},
                         {"rptVentasDetalladasAgrupPorZona", "Ventas Por Zona Detallado", "Información de Ventas Informacion de Ventas"},
                         {"rptVentasPorZonaSimple", "Ventas Por Zona", "Información de Ventas Informacion de Ventas"},
                    {"Titulo", "IVA", "IVA Ventas Notas de Crédito Detallado Notas de Credito Devoluciones "},
                         {"rptIVAVentasDetallado", "IVA Ventas Detallado", "IVA"},
                         {"rptLibroIvaVentasLey", "Libro Iva Ventas - Ley 125 / 91", "IVA Notas de Credito Detallado Devoluciones"},
                         {"rptLibroIvaNotasCreditoVentasLey", "Libro Iva Notas de Credito Ventas - Ley 125 / 91", "IVA Notas de Credito Detallado Devoluciones"},
                         {"rptIVANCreditoDetallado", "IVA Notas de Crédito Detallado Sin Ingreso a Stock", "IVA Notas de Credito Detallado Devoluciones"},
                         {"rptIVANCreditoDesStockDetallado", "IVA Notas de Crédito Detallado Con Ingreso a Stock", "IVA Notas de Credito Detallado Devoluciones"},
                    {"Titulo", "Notas de Crédito", "Nota de credito Por Producto Resumido Devoluciones"},
                         {"rptNCPendienteCobro", "Notas de Crédito Pendientes", "Nota de credito, Nota de crédito, Devoluciones"},
                         {"rptNotasCreditoResumido", "Notas de Crédito Lista", "Nota de credito, Nota de crédito, Devoluciones"},
                         {"rptNClistadetallado", "Notas de Crédito Lista Detallado", "Nota de credito, Nota de crédito, Devoluciones"},
                         {"rptNCPeriodoPorProducto", "Notas de Crédito Por Periodo por Producto", "Nota de credito, Nota de crédito, Devoluciones"},
                         {"rptNCPeriodoPorProductoAgrupCli", "Notas de Crédito Por Periodo por Cliente por Producto", "Nota de credito, Nota de crédito, Devoluciones"},
                    {"Titulo", "Vendedores", "Vendedores Detallado por Clientes Ventas por Vendedor Comision Comisión Resumido"},
                         {"rptVentasVendedorPorCliente", "Ventas por Vendedor por Cliente", "Vendedores"},
                         {"rptVentasPorVendedorDetalle", "Ventas por Vendedor Detallado", "Vendedores"},
                         {"rptComisionVendedorRes", "Comisión de Vendedores", "Vendedores"},
                         {"rptComisionVendedorDet", "Comisión de Vendedores Detallado", "Vendedores"},
                         {"rptComisionVendedorTipoFactura", "Comisión de Vendedores x Tipo de Venta", "Vendedores"},
                    {"Titulo", "Tablas Consulta", "Precios Listas Consultas"},
                         {"rptVentaListaPrecio", "Lista de Precios", "Consultas Tablas Tablas Consulta"},
                         {"rptVentaListaPrecioComp", "Comparativo de Listas de Precios", "Consultas Tablas Tablas Consulta"}}


        '{"rptLiquidacionVendedor", "Liquidación de Vendedores", "Vendedores"},
        '{"rptVentasPorClienteComparativo", "Ventas por Cliente Comparativo", "Estadistica Estadísticas"},
        '{"rptVentasPorProductoComparativo", "Ventas de Productos Comparativo", "Estadistica Estadísticas"},
        '{"rptNotasCreditoCobradas", "Notas de Crédito a Descontar", "Nota de credito, Nota de crédito, Devoluciones"},

        For i = 0 To 86
            dgvListaReportes.Rows.Add()
            dgvListaReportes.Item(1, i).Value = ListaReportes(i, 0)
            dgvListaReportes.Item(0, i).Value = ListaReportes(i, 1)
            dgvListaReportes.Item(2, i).Value = ListaReportes(i, 2)
        Next
        dgvListaReportes.AllowUserToAddRows = False
    End Sub
    Public Sub PintarCeldas()
        If dgvListaReportes.RowCount > 0 Then
            For i = 0 To dgvListaReportes.RowCount - 1
                If dgvListaReportes.Rows(i).Cells("REFERENCIA").Value = "Titulo" Then
                    dgvListaReportes.Item(0, i).Style.BackColor = Color.PaleGoldenrod
                End If
            Next
        End If
    End Sub
    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG4 FROM MODULO WHERE MODULO_ID = 7"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    Config4 = odrConfig("CONFIG4")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GridViewClientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridViewClientes.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Me.CLIENTESBindingSource.Position = Me.CLIENTESBindingSource.Position - 1
            If Not IsDBNull(GridViewClientes.CurrentRow.Cells("NOMBREFANTASIADataGridViewTextBoxColumn").Value) Then
                NumCliente = GridViewClientes.CurrentRow.Cells("NOMBREFANTASIADataGridViewTextBoxColumn").Value
            End If
            cmbCliente.Focus()
            UltraPopupControlContainer1.Close()
        End If
        If KeyAscii = 27 Then
            cmbCliente.Text = "%"
            cmbCliente.Focus()

            If ProductosGroupBox.Visible = True Then
                ProductosGroupBox.Visible = False
                ProductosGroupBox.SendToBack()
                cmbProducto.Focus()
            ElseIf GroupBoxCliente.Visible = True Then
                GroupBoxCliente.Visible = False
                GroupBoxCliente.SendToBack()
                cmbCliente.Focus()
            End If
        End If
    End Sub

    Private Sub TxtBuscaCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscaCliente.TextChanged
        If TxtBuscaCliente.Text <> "Buscar..." Then
            If TxtBuscaCliente.Text = "" Then
                Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & TxtBuscaCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & TxtBuscaCliente.Text & "%'"
            ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(TxtBuscaCliente.Text, "^\d*$") Then ' Si introduce letras
                Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & TxtBuscaCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & TxtBuscaCliente.Text & "%'"
            Else
                Me.CLIENTESBindingSource.Filter = "NUMCLIENTE1 =" & TxtBuscaCliente.Text
                If GridViewClientes.RowCount = 0 Then
                    Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & TxtBuscaCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & TxtBuscaCliente.Text & "%'"
                End If
            End If
        End If
    End Sub
    Private Sub TxtBuscaCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscaCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            GridViewClientes.Focus()
        End If

        If KeyAscii = 27 Then
            cmbCliente.Text = "%"
            cmbCliente.Focus()


            If ProductosGroupBox.Visible = True Then
                ProductosGroupBox.Visible = False
                ProductosGroupBox.SendToBack()
                cmbProducto.Focus()
            ElseIf GroupBoxCliente.Visible = True Then
                GroupBoxCliente.Visible = False
                GroupBoxCliente.SendToBack()
                cmbCliente.Focus()
            End If
        End If
    End Sub
    Private Sub cmbCiudad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbCiudad.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbCiudad.Text = "%"
            cmbZona.Select()
        End If
    End Sub

    Private Sub cmbPais_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbPais.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbPais.Text = "%"
            cmbCiudad.Select()
        End If
    End Sub

    Private Sub chbxCodigosProductos_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If chbxCodProducto.Checked = True Then
            tbxcodProd.Visible = True
            lblAyudaCodProd.Visible = True
        Else
            tbxcodProd.Visible = False
            lblAyudaCodProd.Visible = False
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

    Sub VentaProductoTop20Mes()
        Dim ser As New BDConexión.BDConexion
        Dim objCommand As New SqlCommand
        Dim conexion As System.Data.SqlClient.SqlConnection
        conexion = ser.Abrir()
        objCommand.CommandText = "SELECT DISTINCT TOP (20) P.DESPRODUCTO, SUM(VD.CANTIDADVENTA) AS TOTAL, C.CODIGO, C.CODCODIGO" & _
                                    " FROM VENTASDETALLE AS VD INNER JOIN PRODUCTOS AS P INNER JOIN" & _
                                    " CODIGOS AS C ON P.CODPRODUCTO = C.CODPRODUCTO ON VD.CODCODIGO = C.CODCODIGO INNER JOIN" & _
                                    " VENTAS AS V ON VD.CODVENTA = V.CODVENTA" & _
                                    " WHERE (V.FECHAVENTA <= CONVERT(datetime, '" & FechaHasta & "', 103)) AND (V.FECHAVENTA >= CONVERT(datetime, '" & FechaDesde & "', 103))" & _
                                    " GROUP BY P.DESPRODUCTO, C.CODIGO, C.CODCODIGO" & _
                                    " ORDER BY TOTAL DESC"

        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        objCommand.Connection.Open()
        Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()

        Dim Primero As Integer

        If odrPlanilla.HasRows Then
            Do While odrPlanilla.Read()
                If Primero = 0 Then
                    sql = odrPlanilla("CODCODIGO").ToString
                Else
                    sql = sql + "," + odrPlanilla("CODCODIGO").ToString
                End If
                Primero = 1
            Loop
        End If
        odrPlanilla.Close()
        objCommand.Dispose()
        If rbtDia.Checked = True Then

            Dim rpt As New Reportes.VentasProductoTop20Diario
            Me.VentaProductoFechaTableAdapter.Fill(DsReporteVentas.VentaProductoFecha, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnMes.Checked = True Then

            Dim rpt As New Reportes.VentasProductoTop20Mes
            Me.VentaProductoFechaTableAdapter.Fill(DsReporteVentas.VentaProductoFecha, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If

        ElseIf rbtnQuincena.Checked = True Then

            Dim rpt As New Reportes.VentasProductoTop20Quincena
            Me.VentaProductoFechaTableAdapter.Fill(DsReporteVentas.VentaProductoFecha, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If

        ElseIf rbtnSemana.Checked = True Then

            Dim rpt As New Reportes.VentasProductoTop20Semana
            Me.VentaProductoFechaTableAdapter.Fill(DsReporteVentas.VentaProductoFecha, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If

        ElseIf rbtnSemestre.Checked = True Then

            Dim rpt As New Reportes.VentasProductoTop20Semestre
            Me.VentaProductoFechaTableAdapter.Fill(DsReporteVentas.VentaProductoFecha, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If

        ElseIf rbtnAño.Checked = True Then

            Dim rpt As New Reportes.VentasProductoTop20Anho
            Me.VentaProductoFechaTableAdapter.Fill(DsReporteVentas.VentaProductoFecha, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub
    Sub VentaCategoriaTop20Mes()
        Dim ser As New BDConexión.BDConexion
        Dim objCommand As New SqlCommand
        Dim conexion As System.Data.SqlClient.SqlConnection
        conexion = ser.Abrir()
        objCommand.CommandText = " SELECT TOP (20) FAMILIA.CODFAMILIA, FAMILIA.DESFAMILIA, PRODUCTOS.DESPRODUCTO, SUM(VENTASDETALLE.CANTIDADVENTA) AS Total, VENTAS.FECHAVENTA " & _
                                 " FROM VENTASDETALLE INNER JOIN " & _
                                 " VENTAS ON VENTASDETALLE.CODVENTA = VENTAS.CODVENTA INNER JOIN " & _
                                 " FAMILIA INNER JOIN " & _
                                 " PRODUCTOS ON FAMILIA.CODFAMILIA = PRODUCTOS.CODFAMILIA ON VENTASDETALLE.CODPRODUCTO = PRODUCTOS.CODPRODUCTO " & _
                                 " WHERE (VENTAS.FECHAVENTA >= CONVERT(datetime, '" & FechaDesde & "', 103)) AND (VENTAS.FECHAVENTA <= CONVERT(datetime, '" & FechaHasta & "', 103)) " & _
                                 " GROUP BY FAMILIA.CODFAMILIA, FAMILIA.DESFAMILIA, PRODUCTOS.DESPRODUCTO, VENTAS.FECHAVENTA " & _
                                 " ORDER BY total DESC"

        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        objCommand.Connection.Open()
        Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()

        Dim Primero As Integer

        If odrPlanilla.HasRows Then
            Do While odrPlanilla.Read()
                If Primero = 0 Then
                    sql = odrPlanilla("CODFAMILIA").ToString
                Else
                    sql = sql + "," + odrPlanilla("CODFAMILIA").ToString
                End If
                If sql = Nothing Then
                    sql = 0
                End If
                Primero = 1
            Loop
        Else
            sql = 0
        End If
        odrPlanilla.Close()
        objCommand.Dispose()
        If rbtnMes.Checked = True Then

            Dim rpt As New Reportes.VentasCategoriasTop20Mes
            Me.CategoriasPorMesTableAdapter.Fill(DsReporteVentas.CategoriasPorMes, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtDia.Checked = True Then

            Dim rpt As New Reportes.VentasCategoriasTop20Dia
            Me.CategoriasPorMesTableAdapter.Fill(DsReporteVentas.CategoriasPorMes, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnHora.Checked = True Then

            Dim rpt As New Reportes.VentasCategoriasTop20Hora
            Me.CategoriasPorMesTableAdapter.Fill(DsReporteVentas.CategoriasPorMes, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnQuincena.Checked = True Then

            Dim rpt As New Reportes.VentasCategoriasTop20Quincena
            Me.CategoriasPorMesTableAdapter.Fill(DsReporteVentas.CategoriasPorMes, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnSemana.Checked = True Then

            Dim rpt As New Reportes.VentasCategoriasTop20Semana
            Me.CategoriasPorMesTableAdapter.Fill(DsReporteVentas.CategoriasPorMes, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnSemestre.Checked = True Then

            Dim rpt As New Reportes.VentasCategoriasTop20Semestre
            Me.CategoriasPorMesTableAdapter.Fill(DsReporteVentas.CategoriasPorMes, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnAño.Checked = True Then

            Dim rpt As New Reportes.VentasCategoriasTop20Anho
            Me.CategoriasPorMesTableAdapter.Fill(DsReporteVentas.CategoriasPorMes, FechaDesde, FechaHasta, sql)
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub
    Sub VentasVsCostoPorCategoria()
        Dim fechadesde2, fechahasta2 As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        Try
            'se cambio VENTASDETALLE.PRECIOVENTANETO AS PRECIOVENTABRUTO PARA EL CORRECTO CALCULO DE UTILIDAD (TOTAL SIN IVA - COSTO(SIN IVA))
            Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText = "SELECT        CODIGOS.CODCODIGO, CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, ''))  " & _
                 "+ ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) AS PRODUCTO, CLIENTES.CODCLIENTE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, " & _
                 "VENTASDETALLE.CANTIDADVENTA, VENTASDETALLE.PRECIOVENTANETO AS PRECIOVENTABRUTO, ISNULL(VENTASDETALLE.COSTOPROMEDIO, 0) AS COSTOFIFO, " & _
                 "CASE WHEN VENTASDETALLE.COSTOPROMEDIO IS NOT NULL OR VENTASDETALLE.COSTOPROMEDIO <> 0 THEN VENTASDETALLE.PRECIOVENTANETO - VENTASDETALLE.COSTOPROMEDIO ELSE 0 END AS TOTALUTILIDAD,  " & _
                 "VENTAS.FECHAVENTA, CATEGORIACLIENTE.DESCATEGORIACLIENTE, FAMILIA.DESFAMILIA, LINEA.DESLINEA, RUBRO.DESRUBRO, " & _
                 "VENTASDETALLE.PRECIOVENTANETO, VENTASDETALLE.PRECIOVENTALISTA, VENTASDETALLE.PRODPROMOCION, " & _
                 "ISNULL(ISNULL(dbo.VENTASDETALLE.COSTOPROMEDIO, 0) * dbo.VENTASDETALLE.CANTIDADVENTA, 0) AS PRECIOCOSTOBRUTO " & _
            "FROM        VENTAS INNER JOIN " & _
                  "VENTASDETALLE ON VENTAS.CODVENTA = VENTASDETALLE.CODVENTA LEFT OUTER JOIN " & _
                  "CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                  "PRODUCTOS ON VENTASDETALLE.CODPRODUCTO = PRODUCTOS.CODPRODUCTO LEFT OUTER JOIN " & _
                  "CODIGOS ON VENTASDETALLE.CODCODIGO = CODIGOS.CODCODIGO LEFT OUTER JOIN " & _
                  "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                  "LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA LEFT OUTER JOIN " & _
                  "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                  "CATEGORIACLIENTE ON CLIENTES.CODCATEGORIACLIENTE = CATEGORIACLIENTE.CODCATEGORIACLIENTE " & _
            "WHERE       (VENTAS.ESTADO = 1)"
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn")


            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    Else
                        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    Else
                        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    End If
                End If
                Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.Fill(DsRVEstadisticas.RVVentasPrecioVentaVsCostoPorProducto)
            ElseIf cmbCliente.Text = "%" Then
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                Else
                    Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                End If
            Else ' Un Cliente
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND CLIENTES.CODCLIENTE =" & cmbCliente.SelectedValue & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                Else
                    Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.CODCLIENTE =" & cmbCliente.SelectedValue & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                End If
            End If

            Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.Fill(DsRVEstadisticas.RVVentasPrecioVentaVsCostoPorProducto)

            If rbtnHora.Checked = True Then
                VentasVsCostoPorCategoriaHora()
            ElseIf rbtDia.Checked = True Then
                VentasVsCostoPorCategoriaDia()
            ElseIf rbtnSemana.Checked = True Then
                VentasVsCostoPorCategoriaSemana()
            ElseIf rbtnQuincena.Checked = True Then
                VentasVsCostoPorCategoriaQuincena()
            ElseIf rbtnMes.Checked = True Then
                VentasVsCostoPorCategoriaMes()
            ElseIf rbtnSemestre.Checked = True Then
                VentasVsCostoPorCategoriaSemestre()
            ElseIf rbtnAño.Checked = True Then
                VentasVsCostoPorCategoriaAño()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorCategoriaHora()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoCategoriaHora
            Dim rptmat As New Reportes.VentaVentaVsCostoCategoriaHora
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorCategoriaDia()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoCategoriaDia
            Dim rptmat As New Reportes.VentaVentaVsCostoCategoriaDia
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorCategoriaSemana()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoCategoriaSemana
            Dim rptmat As New Reportes.VentaVentaVsCostoCategoriaSemana
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorCategoriaQuincena()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoCategoriaQuincena
            Dim rptmat As New Reportes.VentaVentaVsCostoCategoriaQuincena
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorCategoriaMes()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoCategoriaMes
            Dim rptmat As New Reportes.VentaVentaVsCostoCategoriaMes
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorCategoriaSemestre()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoCategoriaSemestre
            Dim rptmat As New Reportes.VentaVentaVsCostoCategoriaSemestre
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorCategoriaAño()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoCategoriaAño
            Dim rptmat As New Reportes.VentaVentaVsCostoCategoriaAño
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProducto()
        Dim fechadesde2, fechahasta2 As String

        fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"
        Try
            'se cambio VENTASDETALLE.PRECIOVENTANETO AS PRECIOVENTABRUTO PARA EL CORRECTO CALCULO DE UTILIDAD (TOTAL SIN IVA - COSTO(SIN IVA))
            Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText = "SELECT        CODIGOS.CODCODIGO, CODIGOS.CODIGO, LTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO1, ''))  " & _
                 "+ ' ' + LTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) AS PRODUCTO, CLIENTES.CODCLIENTE, CLIENTES.NUMCLIENTE, CLIENTES.NOMBRE, " & _
                 "VENTASDETALLE.CANTIDADVENTA, VENTASDETALLE.PRECIOVENTANETO AS PRECIOVENTABRUTO, ISNULL(VENTASDETALLE.COSTOPROMEDIO, 0) AS COSTOFIFO, " & _
                 "CASE WHEN VENTASDETALLE.COSTOPROMEDIO IS NOT NULL OR VENTASDETALLE.COSTOPROMEDIO <> 0 THEN VENTASDETALLE.PRECIOVENTANETO - VENTASDETALLE.COSTOPROMEDIO ELSE 0 END AS TOTALUTILIDAD,  " & _
                 "VENTAS.FECHAVENTA, CATEGORIACLIENTE.DESCATEGORIACLIENTE, FAMILIA.DESFAMILIA, LINEA.DESLINEA, RUBRO.DESRUBRO, " & _
                 "VENTASDETALLE.PRECIOVENTANETO, VENTASDETALLE.PRECIOVENTANETO as PRECIOVENTASINIVA,VENTASDETALLE.PRECIOVENTALISTA as PRECIOVENTALISTA,  VENTASDETALLE.PRODPROMOCION, " & _
                 "ISNULL(ISNULL(dbo.VENTASDETALLE.COSTOPROMEDIO, 0) * dbo.VENTASDETALLE.CANTIDADVENTA, 0) AS PRECIOCOSTOBRUTO " & _
            "FROM        VENTAS INNER JOIN " & _
                  "VENTASDETALLE ON VENTAS.CODVENTA = VENTASDETALLE.CODVENTA LEFT OUTER JOIN " & _
                  "CLIENTES ON VENTAS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                  "PRODUCTOS ON VENTASDETALLE.CODPRODUCTO = PRODUCTOS.CODPRODUCTO LEFT OUTER JOIN " & _
                  "CODIGOS ON VENTASDETALLE.CODCODIGO = CODIGOS.CODCODIGO LEFT OUTER JOIN " & _
                  "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                  "LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA LEFT OUTER JOIN " & _
                  "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                  "CATEGORIACLIENTE ON CLIENTES.CODCATEGORIACLIENTE = CATEGORIACLIENTE.CODCATEGORIACLIENTE " & _
            "WHERE       (VENTAS.ESTADO = 1)"
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENTAS.CODVENDEDOR", FormatF2, "VENTAS.CODSUCURSAL", FormatF3, "VENTAS.CODCOMPROBANTE", FormatF4, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn")

            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    Else
                        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    Else
                        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " AND " & codFin & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                    End If
                End If
                Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.Fill(DsRVEstadisticas.RVVentasPrecioVentaVsCostoPorProducto)
            ElseIf cmbCliente.Text = "%" Then
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                Else
                    Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND (VENTAS.ESTADO = 1) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                End If
            Else ' Un Cliente
                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND CLIENTES.CODCLIENTE =" & cmbCliente.SelectedValue & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                Else
                    Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.selectcommand.CommandText += " AND " + sqlwhere + " AND CLIENTES.CODCLIENTE =" & cmbCliente.SelectedValue & " AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') ORDER BY VENTAS.FECHAVENTA, VENTAS.NUMVENTA"
                End If
            End If

            Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.Fill(DsRVEstadisticas.RVVentasPrecioVentaVsCostoPorProducto)


            If rbtnHora.Checked = True And rbtConGrafico.Checked Then
                VentasVsCostoPorProductoHora()
            ElseIf rbtnHora.Checked = True And rbtSinGrafico.Checked = True Then
                VentasVsCostoPorProductoHoraSinGrafico()
            ElseIf rbtDia.Checked = True And rbtConGrafico.Checked = True Then
                VentasVsCostoPorProductoDia()
            ElseIf rbtDia.Checked = True And rbtSinGrafico.Checked = True Then
                VentasVsCostoPorProductoDiaSinGrafico()
            ElseIf rbtnSemana.Checked = True And rbtConGrafico.Checked = True Then
                VentasVsCostoPorProductoSemana()
            ElseIf rbtnSemana.Checked = True And rbtSinGrafico.Checked = True Then
                VentasVsCostoPorProductoSemanaSinGrafico()
            ElseIf rbtnQuincena.Checked = True And rbtConGrafico.Checked = True Then
                VentasVsCostoPorProductoQuincena()
            ElseIf rbtnQuincena.Checked = True And rbtSinGrafico.Checked = True Then
                VentasVsCostoPorProductoQuincenaSinGrafico()
            ElseIf rbtnMes.Checked = True And rbtConGrafico.Checked = True Then
                VentasVsCostoPorProductoMes()
            ElseIf rbtnMes.Checked = True And rbtSinGrafico.Checked = True Then
                VentasVsCostoPorProductoMesSinGrafico()
            ElseIf rbtnSemestre.Checked = True And rbtConGrafico.Checked = True Then
                VentasVsCostoPorProductoSemestre()
            ElseIf rbtnSemestre.Checked = True And rbtSinGrafico.Checked = True Then
                VentasVsCostoPorProductoSemestreSinGrafico()
            ElseIf rbtnAño.Checked = True And rbtConGrafico.Checked = True Then
                VentasVsCostoPorProductoAño()
            ElseIf rbtnAño.Checked = True And rbtSinGrafico.Checked = True Then
                VentaVsCostoProductoAñoSinGrafico()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub VentasVsCostoPorProductoHora()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoHora
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoHora
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoHoraSinGrafico()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoHoraSinGrafico
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoHoraSinGrafico
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub VentasVsCostoPorProductoDia()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoDia
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoDia
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoDiaSinGrafico()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoDiaSinGrafico
            'Dim rpt As New Reportes.VentasVsCostosProducto_DiaSG
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoDiaSinGrafico
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoSemana()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoSemana
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoSemana
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoSemanaSinGrafico()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoSemanaSinGrafico
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoSemanaSinGrafico
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoQuincena()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoQuincena
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoQuincena
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoQuincenaSinGrafico()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoQuincenaSinGrafico
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoQuincenaSinGrafico
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoMes()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoMes
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoMes
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoMesSinGrafico()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoMesSinGrafico
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoMesSinGrafico
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoSemestre()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoSemestre
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoSemestre
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoSemestreSinGrafico()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoSemestreSinGrafico
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoSemestreSinGrafico
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasVsCostoPorProductoAño()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoAño
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoAño
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentaVsCostoProductoAñoSinGrafico()
        Try
            Dim rpt As New Reportes.VentaVentaVsCostoProductoAñoSinGrafico
            Dim rptmat As New Reportes.VentaVentaVsCostoProductoAñoSinGrafico
            If chbxMatricial.Checked = True Then
                If chbxCodCliente.Checked = True Then
                    rptmat.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rptmat.SetParameterValue("pmtCliente", numcliente)
                End If
                rptmat.SetDataSource([DsRVEstadisticas])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If cmbVendedor.Text = "%" Then
                    rptmat.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rptmat.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rptmat.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rptmat.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rptmat.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rptmat.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            Else
                rpt.SetDataSource([DsRVEstadisticas])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                If chbxCodCliente.Checked = True Then
                    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
                ElseIf cmbCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCliente", "(Todos)")
                Else
                    Dim w As New Funciones.Funciones
                    Dim numcliente As String = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
                    rpt.SetParameterValue("pmtCliente", numcliente)
                End If
                If cmbVendedor.Text = "%" Then
                    rpt.SetParameterValue("pmtVendedor", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
                End If
                If cmbSucursal.Text = "%" Then
                    rpt.SetParameterValue("pmtDeposito", "(Todos)")
                Else
                    rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
                End If

                If cmbCategCliente.Text = "%" Then
                    rpt.SetParameterValue("pmtCategCli", "(Todas)")
                Else
                    rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
                End If
                rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
            End If
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                    CrystalReportViewer.ReportSource = rptmat
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub VentasPorSucursal()
        FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        Me.VentasPorSucursalTableAdapter.Fill(DsReporteVentas.VentasPorSucursal, FechaDesde, FechaHasta, FormatF1)
        If rbtnHora.Checked = True Then

            Dim rpt As New Reportes.VentasPorSucursalHora
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtDia.Checked = True Then

            Dim rpt As New Reportes.VentasPorSucursalDiario
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnSemana.Checked = True Then

            Dim rpt As New Reportes.VentasPorSucursalSemana
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnQuincena.Checked = True Then

            Dim rpt As New Reportes.VentasPorSucursalQuincena
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnSemestre.Checked = True Then

            Dim rpt As New Reportes.VentasPorSucursalSemestre
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        ElseIf rbtnAño.Checked = True Then

            Dim rpt As New Reportes.VentasPorSucursalAnho
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else

            Dim rpt As New Reportes.VentasPorSucursal
            rpt.SetDataSource([DsReporteVentas])

            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Sub VentasTipoCliente()
        If rbAgrupFamillia.Checked = True Then
            Dim rpt As New Reportes.VentaListaPrecioDiaConAgrup
            FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
            Me.VentasPorTipoClienteTableAdapter.Fill(DsReporteVentas.VentasPorTipoCliente, cbxCategoria.Text, FormatF1)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else
            Dim rpt As New Reportes.VentaListaPrecioDia
            FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
            Me.VentasPorTipoClienteTableAdapter.Fill(DsReporteVentas.VentasPorTipoCliente, cbxCategoria.Text, FormatF1)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub
    Sub ReporteListaClienteporListaprec()
        Dim rpt As New Reportes.VentasListaClienteporListaPrecio
        FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
        Me.ListaClientesporlistaPrecioTableAdapter.Fill(DsReporteVentas.ListaClientesporlistaPrecio, FormatF1)
        rpt.SetDataSource([DsReporteVentas])
        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub VentasListaPreciaComparativo()
        If rbAgrupFamillia.Checked = True Then
            Dim rpt As New Reportes.VentasListaPrecioComparativoConAgrup
            Dim DESFAMILIA As String = cbxCategoria.Text
            Me.VentasListaPrecioTableAdapter.Fill(DsReporteVentas.VentasListaPrecio)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else
            Dim rpt As New Reportes.VentasListaPrecioComparativo
            Dim DESFAMILIA As String = cbxCategoria.Text
            Me.VentasListaPrecioTableAdapter.Fill(DsReporteVentas.VentasListaPrecio)
            rpt.SetDataSource([DsReporteVentas])
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If
    End Sub

    Private Sub tbxCodigosProductos_GotFocus(sender As Object, e As System.EventArgs)
        lblAyudaCodProd.Visible = True
    End Sub
    Private Sub tbxCodigosProductos_LostFocus(sender As Object, e As System.EventArgs)
        If tbxcodProd.Text = "" Then
            lblAyudaCodProd.Visible = False
        End If
    End Sub

    Private Sub InvisivilizarTodo()
        pnlCategCliente.Location = PosInvisible
        pnlCategorias.Location = PosInvisible
        pnlfechas.Location = PosInvisible
        pnlLocalidad.Location = PosInvisible
        pnlVisualizar.Location = PosInvisible
        pnlVisualizardatos.Location = PosInvisible
        pnlIntervalo.Location = PosInvisible
        pnlCuenta.Location = PosInvisible
        pnlCliente.Location = PosInvisible
        pnlComprobante.Location = PosInvisible
        pnlListaPrecio.Location = PosInvisible
        pnlMoneda.Location = PosInvisible
        pnlProducto.Location = PosInvisible
        pnlSucursal.Location = PosInvisible
        pnlTipo.Location = PosInvisible
        pnlVendedor.Location = PosInvisible
        pnlSinFiltro.Location = PosInvisible
        pnlIVA.Location = PosInvisible
        pnlEstado.Location = PosInvisible
        pnlRelacionado.Location = PosInvisible
        pnlOtrasOpciones.Location = PosInvisible
        pnlIntervalo.Location = PosInvisible
        pnlIngresoStock.Location = PosInvisible
        pnlAnulados.Location = PosInvisible
        pnlNumFactura.Location = PosInvisible
        pnlTipoCobro.Location = PosInvisible
    End Sub
    Private Sub Visibilizarintervalos()
        rbtDia.Visible = True
        rbtnAño.Visible = True
        rbtnHora.Visible = True
        rbtnMes.Visible = True
        rbtnQuincena.Visible = True
        rbtnSemana.Visible = True
        rbtnSemestre.Visible = True
        rbtSinGrafico.Visible = True
        rbtSinGrafico.Checked = True
        rbtConGrafico.Visible = True
        rbtConNroFac.Visible = True
        rbtSinNumFac.Visible = True
    End Sub
    Private Sub FiltrarNadaProducto()
        cbxCategoria.Text = "%"
        cbxRubro.Text = "%"
        cbxLinea.Text = "%"
        cmbProducto.Text = "%"
    End Sub
    Private Sub FiltrarNadaLocalidad()
        cmbPais.Text = "%"
        cmbCiudad.Text = "%"
        cmbZona.Text = "%"
        cmbCliente.Text = "%"
    End Sub

    Private Sub cargarproductos()
        BanCargaProductos = True
        Me.RVProductosTableAdapter.Fill(Me.DsRVFacturacion.RVProductos)
    End Sub
    Private Sub cargarCompVentas()
        BanComprVent = True
        BanCompNC = False
        If Not dtComprobante Is Nothing Then
            dtComprobante.Clear()
        End If
        dtComprobante = Me.RVTipoComprobanteTableAdapter.GetDataByVentas()
        If dtComprobante.Rows.Count > 0 Then
            Dim dr As DataRow
            cmbComprobante.Clear()
            For i = 0 To dtComprobante.Rows.Count - 1
                dr = dtComprobante.Rows.Item(i)
                cmbComprobante.Items.Add(dr("DESCOMPROBANTE"))
            Next
        End If
    End Sub
    Private Sub cargarCompNC()
        BanCompNC = True
        BanComprVent = False
        If Not dtComprobante Is Nothing Then
            dtComprobante.Clear()
        End If
        dtComprobante = Me.RVTipoComprobanteTableAdapter.GetDataByNC()
        If dtComprobante.Rows.Count > 0 Then
            Dim dr As DataRow
            cmbComprobante.Clear()
            For i = 0 To dtComprobante.Rows.Count - 1
                dr = dtComprobante.Rows.Item(i)
                cmbComprobante.Items.Add(dr("DESCOMPROBANTE"))
            Next
        End If
    End Sub

    Private Sub dgvListaReportes_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvListaReportes.SelectionChanged
        CLIENTESBindingSource.RemoveFilter()
        ProductosBindingSource.RemoveFilter()
        chbxCodCliente.Checked = False
        chbxCodProducto.Checked = False
        tbxcodCliente.SendToBack()
        tbxcodProd.SendToBack()
        tbxcodCliente.Text = ""
        tbxcodProd.Text = ""
        rbIVASI.Location = New Point(12, 36)
        rbIVANO.Location = New Point(117, 36)
        rbIVASI.Visible = True
        lblFechaD.Text = "Fecha Desde"
        lblFechaH.Text = "Fecha Hasta"
        dtpFechaDesde.Visible = True
        dtpFechaHasta.Visible = True
        cbxLinea.Enabled = True
        cbxRubro.Enabled = True
        pnlDetalleEnvio.Visible = False
        pbxRangoCli.Visible = True : chbxCodCliente.Visible = True
        Visibilizarintervalos()

        Dim rpt As Reportes.ReporteBlanco
        CrystalReportViewer.ReportSource = rpt

        If pnlFiltros.Visible = False Then
            pnlFiltros.Visible = True
        End If

        chbxNuevaVent.Visible = True
        pnlFactCobr.Visible = False

        Try
            lblReporte.Text = dgvListaReportes.CurrentRow.Cells("TITULO").Value
        Catch ex As Exception
            lblReporte.Text = "Elija un Reporte"
        End Try

        InvisivilizarTodo()
        btnGenerar.Visible = True

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "Titulo" Then
            chbxNuevaVent.Visible = False
            chbxMatricial.Visible = False
            btnGenerar.Visible = False

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptPendienteProducto" Then
            chbxMatricial.Visible = False

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            cmbCliente.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlCliente.Location = Pos2
            pnlfechas.Location = Pos3

            lblReporteDescrip.Text = "Permite visualizar los Productos de Ventas Pendientes (Presupuestadas) de una Zona o Cliente específico. Elija la Zona o Cliente que quiera ver. Este reporte requiere del Modulo Comercio Plus."
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptPendienteCliente" Then
            chbxMatricial.Visible = True

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            cmbCliente.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlCliente.Location = Pos2
            pnlfechas.Location = Pos3

            lblReporteDescrip.Text = "Permite visualizar las Ventas Pendientes (Presupuestadas) por Cliente o por Zona. Elija el Cliente y/o Zona que quiera ver (o inserte %). Este reporte requiere del Modulo Comercio Plus."
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaSucursal" Then
            chbxMatricial.Visible = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            pnlIntervalo.Location = New Point(Pos3.X + 7, Pos3.Y)

            lblReporteDescrip.Text = "Visualize las ventas hechas por Sucursal. Le permitira ver las Cantidades de item y el Valor del mismo. Elija el Sucursal, los Rangos de Fecha, y tambien el Intervalo de Fecha que quiera ver."
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaVsCostoPorCategoria" Then
            chbxMatricial.Visible = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            pnlComprobante.Location = Pos3

            pnlCategCliente.Location = Pos4
            pnlCliente.Location = Pos5
            pnlfechas.Location = Pos6
            pnlIntervalo.Location = Pos7

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptutilidadventa" Then '**********SAUL
            chbxMatricial.Visible = False
            cmbCliente.Text = "%"
            txtNumVenta.Text = "%"

            pnlCliente.Location = Pos1
            pnlfechas.Location = Pos3
            pnlNumFactura.Location = Pos2

            ' lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProyeccionCobros" Then
            cmbCliente.Text = "%"
            pnlCliente.Location = Pos2

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaVsCostoPorProducto" Then
            chbxMatricial.Visible = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            pnlComprobante.Location = Pos3

            pnlCategCliente.Location = Pos4
            pnlCliente.Location = Pos5
            pnlfechas.Location = Pos6
            pnlIntervalo.Location = Pos7
            pnlVisualizar.Location = New Point(Pos8.X, Pos8.Y + 30)

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaListaPrecio" Then
            chbxMatricial.Visible = False

            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If

            cmbListaPrecio.Text = "%"
            cbxCategoria.Text = "%"
            cbxLinea.Text = "%"
            cbxRubro.Text = "%"
            pnlListaPrecio.Location = Pos1
            pnlCategorias.Location = Pos2
            pnlOtrasOpciones.Location = Pos3

            cbxLinea.Enabled = False
            cbxRubro.Enabled = False
            rbAgrupFamillia.Checked = True

            lblReporteDescrip.Text = "Muestra la Lista de Precio de los Productos Agrupado por Familia"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesporListadeprecio" Then
            chbxMatricial.Visible = False
            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"

            pnlListaPrecio.Location = Pos1

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaListaPrecioComp" Then
            chbxMatricial.Visible = False
            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            pnlListaPrecio.Location = Pos1
            pnlCategorias.Location = Pos2
            pnlfechas.Location = Pos3
            pnlOtrasOpciones.Location = Pos4

            cbxLinea.Enabled = False
            cbxRubro.Enabled = False
            rbAgrupFamillia.Checked = True
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasCatTop20" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1
            pnlIntervalo.Location = Pos2 'New Point(Pos2.X + 7, Pos2.Y)


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaProdTop20" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1
            pnlIntervalo.Location = Pos2 'New Point(Pos2.X + 7, Pos2.Y)
            rbtnHora.Enabled = False

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSListaPrecio" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaResumen" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMenosVendidos" Then
            chbxMatricial.Visible = False

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaProd" Then
            chbxMatricial.Visible = False

            If BanCargaProductos = False Then
                cargarproductos()
            End If

            marcartodascategorias()
            cmbProducto.Text = "%"
            cmbSucursal.Text = "%"
            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            pnlSucursal.Location = Pos3
            pnlfechas.Location = Pos4


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasVendedorPorCliente" Then
            chbxMatricial.Visible = True

            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            rbIVANO.Checked = True
            pnlVendedor.Location = Pos1
            pnlfechas.Location = Pos2
            pnlIVA.Location = Pos3   'New Point(Pos3.X + 7, Pos3.Y)


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiarioCajaDet" Or dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiarioCajaResum" Then
            chbxMatricial.Visible = False

            cmbMoneda.Text = "%"
            cmbCaja.Text = "%"
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            pnlMoneda.Location = Pos1
            pnlCuenta.Location = Pos2
            pnlSucursal.Location = Pos3
            pnlfechas.Location = Pos4


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaDetallado" Then
            chbxMatricial.Visible = True

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCategCliente.Location = Pos5
            pnlCliente.Location = Pos6
            pnlfechas.Location = Pos7
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorZona" Then
            chbxMatricial.Visible = True

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"

            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"

            pnlLocalidad.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlCategCliente.Location = Pos3
            pnlfechas.Location = Pos4

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorZonaPromedio" Then
            chbxMatricial.Visible = False

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"

            rbtnHora.Visible = False
            rbtDia.Visible = False

            rbtnSemana.Checked = True
            pnlLocalidad.Location = Pos1
            pnlCategCliente.Location = Pos2
            pnlfechas.Location = Pos3
            pnlIntervalo.Location = Pos4

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorZonaSimple" Then
            chbxMatricial.Visible = True

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            rbIVASI.Checked = True

            pnlLocalidad.Location = Pos1
            pnlCategCliente.Location = Pos2
            pnlfechas.Location = Pos3
            pnlIVA.Location = Pos4

            lblReporteDescrip.Text = "Muestra las Ventas de tipo Contado, Crédito o Cambios, Agrupados por Zona"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasDetalladasAgrupPorZona" Then
            chbxMatricial.Visible = True

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            pnlLocalidad.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCategCliente.Location = Pos5
            pnlfechas.Location = Pos6

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiarioCajaResIva" Then
            chbxMatricial.Visible = False

            cmbMoneda.Text = "%"
            cmbCaja.Text = "%"
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            pnlMoneda.Location = Pos1
            pnlCuenta.Location = Pos2
            pnlSucursal.Location = Pos3
            pnlfechas.Location = Pos4


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiarioCajaRes" Or dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiarioCajaRes" Then
            chbxMatricial.Visible = False


            cmbMoneda.Text = "%"
            cmbCaja.Text = "%"
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlMoneda.Location = Pos1
            pnlCuenta.Location = Pos2
            pnlSucursal.Location = Pos3
            pnlfechas.Location = Pos4


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasCobrar" Then
            chbxMatricial.Visible = False


            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            cmbCliente.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlCliente.Location = Pos2


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasTipoCobro" Then
            chbxMatricial.Visible = False

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            cmbCliente.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlCliente.Location = Pos2
            pnlfechas.Location = Pos3


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaCliente" Then
            chbxMatricial.Visible = False
            pnlSinFiltro.Visible = True
            pnlSinFiltro.Location = Pos1

            'cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            'If cmbVendedor.AccessibleName <> "True" Then
            '    marcardesmarcartodos(cmbVendedor, dtVendedores)
            'End If
            'cmbVendedor.Text = "%"

            'pnlLocalidad.Location = Pos1
            'pnlVendedor.Location = Pos2

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesAporZona" Then
            chbxMatricial.Visible = True

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlVendedor.Location = Pos2


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesAporVendedorporZona" Then
            chbxMatricial.Visible = True

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlVendedor.Location = Pos2


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesAporVendedor" Then
            chbxMatricial.Visible = True

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlVendedor.Location = Pos2


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaClientesAporCategoria" Then
            chbxMatricial.Visible = True

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlCategCliente.Location = Pos2


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEnvioZonaProducto" Then
            chbxMatricial.Visible = True

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlfechas.Location = Pos2


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEnvioPorCliente" Then
            chbxMatricial.Visible = True

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEnvioPorClienteProducto" Then
            chbxMatricial.Visible = True

            cmbPais.Text = "%" : cmbCiudad.Text = "%" : cmbZona.Text = "%"
            cmbCliente.Text = "%"
            pnlLocalidad.Location = Pos1
            pnlCliente.Location = Pos2
            pnlfechas.Location = Pos3
            pnlVisualizardatos.Location = Pos4

            rbtConNroFac_Click(Nothing, Nothing)

            lblReporteDescrip.Text = "Permite visualizar los Productos a Enviar por rango de Fechas por Zona O bien, si desea verlo por un Cliente específico. Elija el Cliente o Zona que quiera ver (o inserte %). Este reporte requiere del Modulo Comercio Plus."
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProdVendidosTop20" Then
            chbxMatricial.Visible = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            pnlOtrasOpciones.Location = Pos3
            rbAgrupFamillia.Checked = True
            lblReporteDescrip.Text = ""

            lblReporteDescrip.Text = "Permite visualizar los Productos más vendidos en un rango de Fechas"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCatVendidasTop20" Then
            chbxMatricial.Visible = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2


            lblReporteDescrip.Text = "Permite visualizar las Categorias de Productos más vendidas en un rango de Fechas"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSProm" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSUltPrecio" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSUltPrecioNeto" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasCantidadVentasYoY" Then
            chbxMatricial.Visible = False


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            cmbProducto.Text = "%"

            pnlSucursal.Location = Pos1
            If BanCargaProductos = False Then
                cargarproductos()
            End If

            pnlProducto.Location = Pos2
            pnlfechas.Location = Pos3

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIngresoVsEgresoPorDía" Then
            chbxMatricial.Visible = False


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            pnlIntervalo.Location = Pos3 'New Point(Pos3.X + 7, Pos3.Y)


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIngresoVsEgresoPorQuincena" Then
            chbxMatricial.Visible = False


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            pnlIntervalo.Location = Pos3 'New Point(Pos3.X + 7, Pos3.Y)

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIngresoVsEgresoPorMes" Then
            chbxMatricial.Visible = False


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            pnlIntervalo.Location = Pos3 'New Point(Pos3.X + 7, Pos3.Y)


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIngresoVsEgresoPorSemestre" Then
            chbxMatricial.Visible = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            pnlIntervalo.Location = Pos3 'New Point(Pos3.X + 7, Pos3.Y)
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIngresoVsEgresoPorAño" Then
            chbxMatricial.Visible = False


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            pnlIntervalo.Location = Pos3 'New Point(Pos3.X + 7, Pos3.Y)
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentaCOGSPromNeto" Then
            chbxMatricial.Visible = False


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturas" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            cmbCliente.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCategCliente.Location = Pos5
            pnlCliente.Location = Pos6
            pnlfechas.Location = Pos7
            pnlIntervalo.Location = Pos8
            rbtDia.Checked = True

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasAgrupCli" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            cmbCliente.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCategCliente.Location = Pos5
            pnlCliente.Location = Pos6
            pnlfechas.Location = Pos7
            pnlIntervalo.Location = Pos8
            rbtDia.Checked = True

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorCliente" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            cmbCliente.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCategCliente.Location = Pos5
            pnlCliente.Location = Pos6
            pnlfechas.Location = Pos7

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasTipoPago" Then

            cmbCliente.Text = "%"
            'If BanComprVent = False Then
            '    cargarCompVentas()
            'End If

            lblTipoComp.Text = "Tipo Factura"
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipoCobro.Text = "%"
            pnlTipoCobro.Location = Pos1
            'pnlTipo.Location = Pos1
            pnlCliente.Location = Pos2
            pnlfechas.Location = Pos3

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIncidenciaNCVTA" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            cmbCliente.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            pnlCategCliente.Location = Pos3
            pnlCliente.Location = Pos4
            pnlfechas.Location = Pos5

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorVendedorDetalle" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            cmbCliente.Text = "%"
            rbIVASI.Checked = True

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCategCliente.Location = Pos5
            pnlfechas.Location = Pos6

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptComisionVendedorRes" Then
            chbxMatricial.Visible = False

            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            pnlVendedor.Location = Pos1

            rbPorFact.Visible = True
            rbPorCobr.Checked = True
            pnlFactCobr.Visible = True
            rbIVANO.Checked = True
            rbIVANO.Location = New Point(12, 36)
            rbIVASI.Visible = False
            pnlfechas.Location = Pos2
            pnlIVA.Location = Pos3 ' Point(Pos3.X + 7, Pos3.Y)

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptComisionVendedorDet" Then
            chbxMatricial.Visible = False


            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            pnlVendedor.Location = Pos1

            pnlfechas.Location = Pos2
            pnlIVA.Location = Pos3 'New Point(Pos3.X + 7, Pos3.Y)

            rbPorFact.Visible = False
            rbPorCobr.Checked = True
            pnlFactCobr.Visible = True

            rbIVANO.Checked = True
            rbIVANO.Location = New Point(12, 36)
            rbIVASI.Visible = False '

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLiquidacionVendedor" Then ' Saul
            chbxNuevaVent.Visible = True

            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            pnlVendedor.Location = Pos1

            pnlfechas.Location = Pos2

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptComisionVendedorTipoFactura" Then
            chbxMatricial.Visible = False


            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            pnlVendedor.Location = Pos1

            pnlfechas.Location = Pos2
            pnlIVA.Location = Pos3 'New Point(Pos3.X + 7, Pos3.Y)

            rbPorFact.Visible = False
            rbPorCobr.Checked = True
            pnlFactCobr.Visible = True

            rbIVANO.Checked = True
            rbIVANO.Location = New Point(12, 36)
            rbIVASI.Visible = False

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptventaporcentajeventa" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos2

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasResumido" Then
            chbxMatricial.Visible = True

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCategCliente.Location = Pos5
            pnlCliente.Location = Pos6
            pnlfechas.Location = Pos7
            pnlIVA.Location = Pos8
            pnlAnulados.Location = New Point(Pos9.X, Pos9.Y + 20)


            lblReporteDescrip.Text = "Muestra un Resumen de todas las Facturas Emitidas en un periodo de Tiempo"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNCPeriodoPorProductoAgrupCli" Then
            chbxMatricial.Visible = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            lblTipoComp.Text = "Tipo NCrédito"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Devolución y Cambio de Productos")
            cmbTipo.Items.Add("Bonificación de Productos")
            cmbTipo.Items.Add("Descuento")
            cmbTipo.Items.Add("Por Flete")
            cmbTipo.Items.Add("Por Bandeo/Promoción")
            cmbTipo.Items.Add("Por Diferencia de Precio")
            cmbTipo.Items.Add("Por Faltante de Mercaderia")
            cmbTipo.Items.Add("Degustación")
            cmbTipo.Items.Add("Acuerdo Comercial")
            cmbTipo.Items.Add("Muestras Varias")

            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            cmbIngresoStock.Text = "%"
            pnlIngresoStock.Location = Pos4

            marcartodascategorias()
            pnlCategorias.Location = Pos5
            pnlCategCliente.Location = Pos6
            pnlCliente.Location = Pos7
            pnlfechas.Location = Pos8
            pnlOtrasOpciones.Location = Pos9
            rbAgrupFamillia.Checked = True

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNCPeriodoPorProducto" Then
            chbxMatricial.Visible = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            lblTipoComp.Text = "Tipo NCrédito"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Devolución y Cambio de Productos")
            cmbTipo.Items.Add("Bonificación de Productos")
            cmbTipo.Items.Add("Descuento")
            cmbTipo.Items.Add("Por Flete")
            cmbTipo.Items.Add("Por Bandeo/Promoción")
            cmbTipo.Items.Add("Por Diferencia de Precio")
            cmbTipo.Items.Add("Por Faltante de Mercaderia")
            cmbTipo.Items.Add("Degustación")
            cmbTipo.Items.Add("Acuerdo Comercial")
            cmbTipo.Items.Add("Muestras Varias")

            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            cmbIngresoStock.Text = "%"
            pnlIngresoStock.Location = Pos4
            marcartodascategorias()
            pnlCategorias.Location = Pos5
            pnlCategCliente.Location = Pos6
            pnlCliente.Location = Pos7
            pnlfechas.Location = Pos8
            pnlOtrasOpciones.Location = Pos9
            rbAgrupFamillia.Checked = True

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNClistadetallado" Then
            chbxMatricial.Visible = False


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2

            lblTipoComp.Text = "Tipo NCrédito"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Devolución y Cambio de Productos")
            cmbTipo.Items.Add("Bonificación de Productos")
            cmbTipo.Items.Add("Descuento")
            cmbTipo.Items.Add("Por Flete")
            cmbTipo.Items.Add("Por Bandeo/Promoción")
            cmbTipo.Items.Add("Por Diferencia de Precio")
            cmbTipo.Items.Add("Por Faltante de Mercaderia")
            cmbTipo.Items.Add("Degustación")
            cmbTipo.Items.Add("Acuerdo Comercial")
            cmbTipo.Items.Add("Muestras Varias")

            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            cmbIngresoStock.Text = "%"
            pnlIngresoStock.Location = Pos4

            marcartodascategorias()
            pnlCategorias.Location = Pos5
            pnlCategCliente.Location = Pos6
            pnlCliente.Location = Pos7
            pnlfechas.Location = Pos8
            pnlOtrasOpciones.Location = Pos9
            rbAgrupFamillia.Checked = True

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNotasCreditoCobradas" Then

            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If

            cmbVendedor.Text = "%"
            pnlVendedor.Location = Pos1

            pnlfechas.Location = Pos2

            lblReporteDescrip.Text = "Ver Notas de Créditos Aplicadas a Cobros"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasEstado" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1

            pnlComprobante.Location = Pos2

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"


            pnlEstado.Location = Pos4
            cmbEstado.Items.Clear()
            cmbEstado.Items.Add("Anulado")
            cmbEstado.Items.Add("Aprobado")
            cmbEstado.Items.Add("Pendiente")
            If cmbEstado.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbEstado)
            End If
            cmbEstado.Text = "%"

            pnlCliente.Location = Pos5
            pnlfechas.Location = Pos6

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIVAVentasDetallado" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            cmbCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            pnlCategCliente.Location = Pos4
            pnlCliente.Location = Pos5
            pnlfechas.Location = Pos6

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIVANCreditoDetallado" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            cmbCliente.Text = "%"
            If BanCompNC = False Then
                cargarCompNC()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2

            lblTipoComp.Text = "Tipo NCrédito"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Devolución y Cambio de Productos")
            cmbTipo.Items.Add("Bonificación de Productos")
            cmbTipo.Items.Add("Descuento")
            cmbTipo.Items.Add("Por Flete")
            cmbTipo.Items.Add("Por Bandeo/Promoción")
            cmbTipo.Items.Add("Por Diferencia de Precio")
            cmbTipo.Items.Add("Por Faltante de Mercaderia")
            cmbTipo.Items.Add("Degustación")
            cmbTipo.Items.Add("Acuerdo Comercial")
            cmbTipo.Items.Add("Muestras Varias")

            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCliente.Location = Pos4
            pnlfechas.Location = Pos5

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptIVANCreditoDesStockDetallado" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            cmbCliente.Text = "%"
            If BanCompNC = False Then
                cargarCompNC()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2

            lblTipoComp.Text = "Tipo NCrédito"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Devolución y Cambio de Productos")
            cmbTipo.Items.Add("Bonificación de Productos")
            cmbTipo.Items.Add("Descuento")
            cmbTipo.Items.Add("Por Flete")
            cmbTipo.Items.Add("Por Bandeo/Promoción")
            cmbTipo.Items.Add("Por Diferencia de Precio")
            cmbTipo.Items.Add("Por Faltante de Mercaderia")
            cmbTipo.Items.Add("Degustación")
            cmbTipo.Items.Add("Acuerdo Comercial")
            cmbTipo.Items.Add("Muestras Varias")

            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCliente.Location = Pos4
            pnlfechas.Location = Pos5

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaVentasLey" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            cmbSucursal.Text = "%"

            lblReporte.Text = "Libro Iva de Ventas"
            lblReporteDescrip.Text = " Permite visualizar los totales que se han registrado en una determinada venta,ya sean Gravadas,Exentas,Total Iva y Total de la Venta."
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptLibroIvaNotasCreditoVentasLey" Then
            InvisivilizarTodo()

            chbxMatricial.Visible = True
            chbxNuevaVent.Visible = True

            pnlSucursal.Location = Pos1
            pnlfechas.Location = Pos2
            cmbSucursal.Text = "%"

            lblReporte.Text = "Libro Iva Notas de Credito de Ventas"
            lblReporteDescrip.Text = " Permite visualizar los totales que se han registrado en una determinada Nota de Credito,ya sean Gravadas,Exentas,Total Iva y Total de la NC."
            btnGenerar.Text = "Generar Datos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasPorProductoResumido" Then
            chbxMatricial.Visible = True


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            cmbCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"
            marcartodascategorias()

            pnlCategorias.Location = Pos5
            pnlCategCliente.Location = Pos6
            pnlCliente.Location = Pos7
            pnlOtrasOpciones.Location = Pos9  'New Point(Pos9.X + 7, Pos9.Y)
            pnlfechas.Location = Pos8

            rbSinAgrup.Checked = True
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasPorProductoPorCliente" Then
            chbxMatricial.Visible = True

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            cmbCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"
            marcartodascategorias()

            pnlCategorias.Location = Pos5
            pnlCategCliente.Location = Pos6
            pnlCliente.Location = Pos7
            pnlOtrasOpciones.Location = Pos9 'New Point(Pos9.X + 7, Pos9.Y)

            pnlfechas.Location = Pos8

            rbSinAgrup.Checked = True
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptComprVentasPorVendedorProductoResumido" Then
            chbxMatricial.Visible = True

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            cmbCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"
            marcartodascategorias()

            pnlCategorias.Location = Pos5
            pnlCategCliente.Location = Pos6
            pnlCliente.Location = Pos7
            pnlOtrasOpciones.Location = Pos9 'New Point(Pos9.X + 7, Pos9.Y)
            pnlfechas.Location = Pos8

            rbSinAgrup.Checked = True
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasPorProductoPorFecha" Then
            chbxMatricial.Visible = True

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            cmbCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"
            marcartodascategorias()

            pnlCategorias.Location = Pos5
            pnlCategCliente.Location = Pos6
            pnlCliente.Location = Pos7
            pnlOtrasOpciones.Location = Pos9 'New Point(Pos9.X + 7, Pos9.Y)
            pnlfechas.Location = Pos8

            rbSinAgrup.Checked = True
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNotasCreditoResumido" Then
            chbxMatricial.Visible = True

            If BanCompNC = False Then
                cargarCompNC()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3
            pnlAnulados.Location = Pos8

            lblTipoComp.Text = "Tipo NCrédito"
            pnlTipo.Location = Pos4
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Devolución y Cambio de Productos")
            cmbTipo.Items.Add("Bonificación de Productos")
            cmbTipo.Items.Add("Descuento")
            cmbTipo.Items.Add("Por Flete")
            cmbTipo.Items.Add("Por Bandeo/Promoción")
            cmbTipo.Items.Add("Por Diferencia de Precio")
            cmbTipo.Items.Add("Por Faltante de Mercaderia")
            cmbTipo.Items.Add("Degustación")
            cmbTipo.Items.Add("Acuerdo Comercial")
            cmbTipo.Items.Add("Muestras Varias")

            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCategCliente.Location = Pos5
            pnlCliente.Location = Pos6
            pnlfechas.Location = Pos7

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNCEstado" Then
            chbxMatricial.Visible = True


            If BanCompNC = False Then
                cargarCompNC()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlComprobante.Location = Pos2

            lblTipoComp.Text = "Tipo NCrédito"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Devolución y Cambio de Productos")
            cmbTipo.Items.Add("Bonificación de Productos")
            cmbTipo.Items.Add("Descuento")
            cmbTipo.Items.Add("Por Flete")
            cmbTipo.Items.Add("Por Bandeo/Promoción")
            cmbTipo.Items.Add("Por Diferencia de Precio")
            cmbTipo.Items.Add("Por Faltante de Mercaderia")
            cmbTipo.Items.Add("Degustación")
            cmbTipo.Items.Add("Acuerdo Comercial")
            cmbTipo.Items.Add("Muestras Varias")

            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlEstado.Location = Pos4
            cmbEstado.Items.Clear()
            cmbEstado.Items.Add("Aprobado")
            cmbEstado.Items.Add("Pendiente")
            cmbEstado.Items.Add("Anulado")
            If cmbEstado.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbEstado)
            End If
            cmbEstado.Text = "%"

            pnlRelacionado.Location = Pos5
            cmbRelacionado.Items.Clear()
            cmbRelacionado.Items.Add("Sin Relacionar")
            cmbRelacionado.Items.Add("Relacionado desde Devolución")
            cmbRelacionado.Items.Add("Relacionado desde Cobros")
            If cmbRelacionado.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbRelacionado)
            End If
            cmbRelacionado.Text = "%"

            pnlfechas.Location = Pos6
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNotasCreditoPorProducto" Then
            chbxMatricial.Visible = True


            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If BanCompNC = False Then
                cargarCompNC()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"

            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlComprobante.Location = Pos3

            lblTipoComp.Text = "Tipo NCrédito"
            pnlTipo.Location = Pos4

            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Devolución y Cambio de Productos")
            cmbTipo.Items.Add("Bonificación de Productos")
            cmbTipo.Items.Add("Descuento")
            cmbTipo.Items.Add("Por Flete")
            cmbTipo.Items.Add("Por Bandeo/Promoción")
            cmbTipo.Items.Add("Por Diferencia de Precio")
            cmbTipo.Items.Add("Por Faltante de Mercaderia")
            cmbTipo.Items.Add("Degustación")
            cmbTipo.Items.Add("Acuerdo Comercial")
            cmbTipo.Items.Add("Muestras Varias")

            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            pnlCategCliente.Location = Pos5
            pnlfechas.Location = Pos6

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRecibosClientes" Then
            chbxMatricial.Visible = True


            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            cmbCliente.Text = "%"

            pnlCategCliente.Location = Pos1
            pnlListaPrecio.Location = Pos2

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCliente.Location = Pos4
            pnlfechas.Location = Pos5

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRecibosClientesDet" Then
            chbxMatricial.Visible = True


            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            cmbCliente.Text = "%"

            pnlCategCliente.Location = Pos1
            pnlListaPrecio.Location = Pos2

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos3
            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCliente.Location = Pos4
            pnlfechas.Location = Pos5

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRecibosXFactura" Then
            chbxMatricial.Visible = True

            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            cmbCliente.Text = "%"

            pnlListaPrecio.Location = Pos1
            pnlComprobante.Location = Pos2

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos3

            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCliente.Location = Pos4
            pnlfechas.Location = Pos5


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasXRecibo" Then
            chbxMatricial.Visible = True

            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            cmbCliente.Text = "%"

            pnlListaPrecio.Location = Pos1
            pnlComprobante.Location = Pos2

            lblTipoComp.Text = "Tipo Factura"
            pnlTipo.Location = Pos3

            cmbTipo.Items.Clear()
            cmbTipo.Items.Add("Contado")
            cmbTipo.Items.Add("Crédito")
            cmbTipo.Items.Add("Bonificación")
            cmbTipo.Items.Add("Cambio")
            cmbTipo.Items.Add("Otros")
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"

            pnlCliente.Location = Pos4
            pnlfechas.Location = Pos5

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptFacturasACobrar" Then
            chbxMatricial.Visible = True

            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"

            pnlCategCliente.Location = Pos1
            pnlListaPrecio.Location = Pos2

            pnlCliente.Location = Pos3
            pnlfechas.Location = Pos4

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptSaldoCliente" Then
            pnlSinFiltro.Location = Pos1

            lblReporteDescrip.Text = "Composición de Saldo de CLientes"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptPendienteCobro" Then
            chbxMatricial.Visible = True

            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            cmbCliente.Text = "%"

            Dim año As Integer = Today.Year - 4
            dtpFechaDesde.Text = "01/01/" & año

            pnlCategCliente.Location = Pos1
            pnlListaPrecio.Location = Pos2

            pnlCliente.Location = Pos3
            pnlfechas.Location = Pos4

            lblReporteDescrip.Text = ""

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptPendienteCobroDet" Then

            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            cmbCliente.Text = "%"

            Dim año As Integer = Today.Year - 4
            dtpFechaDesde.Text = "01/01/" & año

            pnlCliente.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporteDescrip.Text = ""

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptNCPendienteCobro" Then
            chbxMatricial.Visible = True

            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"

            Dim año As Integer = Today.Year - 4
            dtpFechaDesde.Text = "01/01/" & año

            pnlCategCliente.Location = Pos1
            pnlListaPrecio.Location = Pos2

            pnlCliente.Location = Pos3
            pnlfechas.Location = Pos4

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptlistadorecibos" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos2

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptClientesAtrasados" Then
            chbxMatricial.Visible = True


            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"

            pnlCategCliente.Location = Pos1
            pnlListaPrecio.Location = Pos2

            

            pnlCliente.Location = Pos3
            pnlfechas.Location = Pos4
            lblFechaD.Text = "Vcto. al:"
            Dim año As Integer = Today.Year - 4
            dtpFechaDesde.Text = "01/01/" & año
            lblFechaH.Text = "Consulta al:"
            dtpFechaHasta.Value = Today

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptAnalisisSaldo" Then
            chbxMatricial.Visible = False

            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"

            pnlCategCliente.Location = Pos1
            pnlListaPrecio.Location = Pos2

            pnlCliente.Location = Pos3
            pnlfechas.Location = Pos4
            dtpFechaDesde.Value = Today
            lblFechaD.Text = "Hasta el:"
            lblFechaH.Visible = False
            dtpFechaHasta.Visible = False

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEstadoCuenta" Then
            chbxMatricial.Visible = True


            cmbCliente.SelectedItem = 1
            pnlCliente.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporteDescrip.Text = "Permite visualizar el Estado de Cuenta de un Cliente. Seleccione un Cliente de la lista"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovimientoCliente" Then
            chbxMatricial.Visible = False
            pbxRangoCli.Visible = False : chbxCodCliente.Visible = False

            cmbCliente.SelectedItem = 1
            pnlCliente.Location = Pos1
            pnlfechas.Location = Pos2

            lblReporteDescrip.Text = "Permite visualizar todos los Movimientos de un Cliente. Seleccione un Cliente de la lista"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRankingClientes" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1

            lblReporteDescrip.Text = "Permite visualizar el Ranking de Clientes por Monto de Venta, Cantidad de Venta, Porcentaje de Utilidad"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovRemision" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1

            lblReporteDescrip.Text = "Permite visualizar el Ranking de Clientes por Monto de Venta, Cantidad de Venta, Porcentaje de Utilidad"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptRankingProductos" Then
            chbxMatricial.Visible = False

            pnlfechas.Location = Pos1

            lblReporteDescrip.Text = "Permite visualizar el Ranking de Productos por Monto de Venta, Cantidad de Venta, Porcentaje de Utilidad"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasProdXCli" Then
            chbxMatricial.Visible = False


            If BanCargaProductos = False Then
                cargarproductos()
            End If
            cmbCliente.Text = "%"
            cmbProducto.Text = "%"
            pnlProducto.Location = Pos1
            pnlfechas.Location = Pos2
            'pnlCliente.Location = Pos3    Will.i.am

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasCliXProd" Then
            chbxMatricial.Visible = False

            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"
            pnlCategCliente.Location = Pos1
            pnlCliente.Location = Pos2
            pnlfechas.Location = Pos3

            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorProductoComparativo" Then
            chbxMatricial.Visible = False

            If BanCargaProductos = False Then
                cargarproductos()
            End If
            cmbProducto.Text = "%"
            pnlProducto.Location = Pos1
            pnlfechas.Location = Pos2


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasPorClienteComparativo" Then
            chbxMatricial.Visible = False


            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
            cmbCliente.Text = "%"
            pnlCategCliente.Location = Pos1
            pnlCliente.Location = Pos2
            pnlfechas.Location = Pos3
            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptDiasVentas" Then
            InvisivilizarTodo()
            pnlOtrasOpciones.Location = Pos1
            rbAgrupFamillia.Checked = True
            lblReporteDescrip.Text = ""
            'PRESUPUESTO BY SAUL####################################==========================
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaPresupuesto" Then

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlCliente.Location = Pos3
            pnlfechas.Location = Pos4


            lblReporteDescrip.Text = ""

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaPresupuestoSC" Then

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlCliente.Location = Pos3
            pnlfechas.Location = Pos4


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptutilidadventas" Then '*************************SAUL

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
            If BanComprVent = False Then
                cargarCompVentas()
            End If
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"

            rbIVASI.Checked = True
            cmbCliente.Text = "%"

            pnlSucursal.Location = Pos1
            pnlVendedor.Location = Pos2
            pnlCliente.Location = Pos3
            pnlfechas.Location = Pos4


            lblReporteDescrip.Text = ""
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptVentasDetalladaXCliente" Then '*************************SAUL

            cmbCliente.Text = "%"

            pnlCliente.Location = Pos1
            pnlfechas.Location = Pos2


            lblReporteDescrip.Text = ""
        Else
            InvisivilizarTodo()

            pnlSinFiltro.Location = PosSinFiltro
            lblReporteDescrip.Text = ""
        End If
    End Sub
    Private Sub marcartodascategorias()
        cbxCategoria.Text = "%"
        cbxLinea.Text = "%"
        cbxRubro.Text = "%"
    End Sub
    Private Sub cmbZona_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbZona.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbZona.Text = "%"
        End If
    End Sub

    Private Sub cmbComprobante_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbComprobante.CheckBoxCheckedChanged
        verificarchecks(cmbComprobante, dtComprobante)
    End Sub
    Private Sub cmbComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbComprobante.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbComprobante.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbComprobante, dtComprobante)
            End If
            cmbComprobante.Text = "%"
        End If
    End Sub

    Private Sub cmbTipo_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbTipo.CheckBoxCheckedChanged
        verificarcheckssindt(cmbTipo)
    End Sub
    Private Sub cmbTipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbTipo.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbTipo.AccessibleName <> "True" Then
                marcardesmarcartodossindt(cmbTipo)
            End If
            cmbTipo.Text = "%"
        End If
    End Sub

    Private Sub cmbCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbCliente.Text = "%"
        End If
    End Sub

    Private Sub cmbProducto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbProducto.Text = "%"
        End If
    End Sub

    Private Sub cmbSucursal_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbSucursal.CheckBoxCheckedChanged
        verificarchecks(cmbSucursal, dtSucursal)
    End Sub

    Private Sub cmbSucursal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbSucursal.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbSucursal.Text = "%"
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
        End If
    End Sub

    Private Sub cmbVendedor_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbVendedor.CheckBoxCheckedChanged
        verificarchecks(cmbVendedor, dtVendedores)
    End Sub

    Private Sub cmbVendedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbVendedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbVendedor.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbVendedor, dtVendedores)
            End If
            cmbVendedor.Text = "%"
        End If
    End Sub

    Private Sub cmbCaja_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbCaja.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbCaja.Text = "%"
        End If
    End Sub

    Private Sub cmbMoneda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbMoneda.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbMoneda.Text = "%"
        End If
    End Sub

    Private Sub cmbCategCliente_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbCategCliente.CheckBoxCheckedChanged
        verificarchecks(cmbCategCliente, dtCategoriaClientes)
    End Sub

    Private Sub cmbCategCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbCategCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbCategCliente.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
            End If
            cmbCategCliente.Text = "%"
        End If
        
    End Sub

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

    Private Sub cmbListaPrecio_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbListaPrecio.CheckBoxCheckedChanged
        verificarchecks(cmbListaPrecio, dtListaPrecio)
    End Sub
    Private Sub cmbListaPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbListaPrecio.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
        End If
    End Sub
    Private Sub cmbPais_TextChanged(sender As Object, e As System.EventArgs) Handles cmbPais.TextChanged
        Dim Codpais As String = cmbPais.Text
        Me.CIUDADBindingSource.Filter = "DESPAIS like '" & Codpais & "'"
    End Sub
    Private Sub cmbCiudad_TextChanged(sender As Object, e As System.EventArgs) Handles cmbCiudad.TextChanged
        Dim CODCIUDAD As String = cmbCiudad.Text
        Dim Codpais As String = cmbPais.Text
        Me.ZONABindingSource.Filter = "DESCIUDAD like '" & CODCIUDAD & "'"
    End Sub

    Private Sub cbxLinea_TextChanged(sender As Object, e As System.EventArgs) Handles cbxLinea.TextChanged
        Dim DESRUBRO As String = cbxRubro.Text
        Dim DESLINEA As String = cbxLinea.Text
        Dim DESFAMILIA As String = cbxCategoria.Text
        If DESLINEA <> "%" And DESLINEA <> "" Then
            If DESFAMILIA <> "%" And DESFAMILIA <> "" Then
                Me.ProductosBindingSource.Filter = "(DESFAMILIA like '" & DESFAMILIA & "') AND (DESLINEA like '" & DESLINEA & "')"
            Else
                Me.ProductosBindingSource.Filter = "DESLINEA like '" & DESLINEA & "'"
            End If
            Me.RUBROBindingSource.Filter = "DESLINEA like '" & DESLINEA & "'"
        Else
            If DESFAMILIA <> "%" And DESFAMILIA <> "" Then
                Me.ProductosBindingSource.Filter = "DESFAMILIA like '" & DESFAMILIA & "'"
            Else
                If (DESRUBRO = "%" Or DESRUBRO = "") Then
                    Me.ProductosBindingSource.RemoveFilter()
                End If
            End If
        End If
    End Sub

    Private Sub cbxCategoria_TextChanged(sender As Object, e As System.EventArgs) Handles cbxCategoria.TextChanged
        Dim DESRUBRO As String = cbxRubro.Text
        Dim DESLINEA As String = cbxLinea.Text
        Dim DESFAMILIA As String = cbxCategoria.Text
        Me.LINEABindingSource.Filter = "DESFAMILIA like '" & DESFAMILIA & "'"
        If DESFAMILIA <> "%" And DESFAMILIA <> "" Then
            Me.ProductosBindingSource.Filter = "DESFAMILIA like '" & DESFAMILIA & "'"
        Else
            If (DESLINEA = "%" Or DESLINEA = "") And (DESRUBRO = "%" Or DESRUBRO = "") Then
                Me.ProductosBindingSource.RemoveFilter()
            End If
        End If
    End Sub

    Private Sub cbxRubro_TextChanged(sender As Object, e As System.EventArgs) Handles cbxRubro.TextChanged
        Dim DESRUBRO As String = cbxRubro.Text
        Dim DESLINEA As String = cbxLinea.Text
        Dim DESFAMILIA As String = cbxCategoria.Text
        If DESLINEA <> "%" And DESLINEA <> "" Then
            Me.CODIGOSBindingSource.Filter = "DESLINEA like '" & DESLINEA & "'"
            If DESFAMILIA <> "%" And DESFAMILIA <> "" Then
                If DESRUBRO <> "%" And DESRUBRO <> "" Then
                    Me.ProductosBindingSource.Filter = "(DESFAMILIA like '" & DESFAMILIA & "' ) AND (DESLINEA like '" & DESLINEA & "') AND (DESRUBRO like '" & DESRUBRO & "')"
                Else
                    Me.ProductosBindingSource.Filter = "(DESFAMILIA like '" & DESFAMILIA & "' ) AND (DESLINEA like '" & DESLINEA & "') "
                End If
            Else
                If DESRUBRO <> "%" And DESRUBRO <> "" Then
                    Me.ProductosBindingSource.Filter = "(DESLINEA like '" & DESLINEA & "') AND (DESRUBRO like '" & DESRUBRO & "')"
                Else
                    Me.ProductosBindingSource.Filter = "DESLINEA like '" & DESLINEA & "' "
                End If
            End If
        Else
            If DESFAMILIA <> "%" And DESFAMILIA <> "" Then
                If DESRUBRO <> "%" And DESRUBRO <> "" Then
                    Me.ProductosBindingSource.Filter = "(DESFAMILIA like '" & DESFAMILIA & "' ) AND (DESRUBRO like '" & DESRUBRO & "')"
                Else
                    Me.ProductosBindingSource.Filter = "DESFAMILIA like '" & DESFAMILIA & "' "
                End If
            Else
                If DESRUBRO <> "%" And DESRUBRO <> "" Then
                    Me.ProductosBindingSource.Filter = "DESRUBRO like '" & DESRUBRO & "'"
                Else
                    Me.ProductosBindingSource.RemoveFilter()
                End If
            End If
        End If

    End Sub

    Private Sub cmbCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            dtpFechaDesde.Focus()
        ElseIf KeyAscii = 42 Then
            BtnAsteriscoCliente_Click(Nothing, Nothing)
            Me.CLIENTESTableAdapter.Fill(Me.DsReporteVentas.CLIENTES)
            e.Handled = True
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BuscarTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.GotFocus
        BuscarTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.LostFocus
        BuscarTextBox.BackColor = Color.Tan
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        Dim dgvcount As Integer = -1
        Dim strtitulo, strclave, strbusq As String
        Try
            If BuscarTextBox.Text = "" Or BuscarTextBox.Text = "Buscar..." Then
                dgvListaReportes.Rows.Clear()
                cargarListaReportes()
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
                dgvListaReportes_SelectionChanged(Nothing, Nothing)
            End If
            PintarCeldas()
        Catch ex As Exception

        End Try
        BuscarTextBox.Focus()
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

    Private Sub BtnAsteriscoCliente_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsteriscoCliente.Click
        UltraPopupControlContainer1.PopupControl = GroupBoxCliente
        UltraPopupControlContainer1.Show()
        If cmbCliente.Text = "%" Then
            TxtBuscaCliente.Text = ""
        Else
            TxtBuscaCliente.Text = cmbCliente.Text
        End If
        If chbxCodCliente.Checked = True Then
            chbxCodCliente.Checked = False
        End If
        TxtBuscaCliente.Focus()
        TxtBuscaCliente.SelectionStart = TxtBuscaCliente.TextLength
    End Sub

    Private Sub BtnAsteriscoProducto_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsteriscoProducto.Click

        If cmbProducto.Text = "%" Then
            BuscarProductoTextBox.Text = ""
        Else
            BuscarProductoTextBox.Text = cmbProducto.Text
        End If
        If chbxCodProducto.Checked = True Then
            chbxCodProducto.Checked = False
        End If
        UltraPopupControlContainer1.PopupControl = ProductosGroupBox
        UltraPopupControlContainer1.Show()

        BuscarProductoTextBox.Focus()
        BuscarProductoTextBox.SelectionStart = BuscarProductoTextBox.TextLength
    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProductosGridView.Focus()
        End If
        If KeyAscii = 27 Then
            cmbProducto.Text = "%"
            cmbProducto.Focus()

            If ProductosGroupBox.Visible = True Then
                ProductosGroupBox.Visible = False
                ProductosGroupBox.SendToBack()
                cmbProducto.Focus()
            ElseIf ProductosGroupBox.Visible = True Then
                ProductosGroupBox.Visible = False
                ProductosGroupBox.SendToBack()
                cmbProducto.Focus()
            End If
        End If
    End Sub
    Private Sub BuscarProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        Try
            If BuscarProductoTextBox.Text <> "Buscar..." Then
                Me.ProductosBindingSource.Filter = "DESCRIPCION LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProductosGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosGridView.CellDoubleClick
        BuscarProductoTextBox.Text = ""
        cmbProducto.Focus()
        UltraPopupControlContainer1.Close()
    End Sub
    Private Sub ProductosGridView_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ProductosGridView.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Me.ProductosBindingSource.Position = Me.ProductosBindingSource.Position - 1
            cmbProducto.Focus()
            UltraPopupControlContainer1.Close()
        End If
        If KeyAscii = 27 Then
            cmbProducto.Text = "%"
            cmbProducto.Focus()

            If ProductosGroupBox.Visible = True Then
                ProductosGroupBox.Visible = False
                ProductosGroupBox.SendToBack()
                cmbProducto.Focus()
            ElseIf GroupBoxCliente.Visible = True Then
                GroupBoxCliente.Visible = False
                GroupBoxCliente.SendToBack()
                cmbCliente.Focus()
            End If
        End If
    End Sub

    Private Sub chbxCodProducto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbxCodProducto.CheckedChanged
        If chbxCodProducto.Checked = True Then
            tbxcodProd.BringToFront()
            tbxcodProd.Focus()
        Else
            tbxcodProd.SendToBack()
            tbxcodProd.Text = ""
        End If
    End Sub

    Private Sub chbxCodCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbxCodCliente.CheckedChanged
        If chbxCodCliente.Checked = True Then
            tbxcodCliente.BringToFront()
            tbxcodCliente.Focus()
        Else
            tbxcodCliente.SendToBack()
            tbxcodCliente.Text = ""
        End If
    End Sub

    Private Sub GridViewClientes_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridViewClientes.CellDoubleClick
        UltraPopupControlContainer1.Close()
        cmbCliente.Focus()
    End Sub

    Private Sub cmbProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            BtnAsteriscoProducto_Click(Nothing, Nothing)
            e.Handled = True
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Function calcularcmbEstado(combo As PresentationControls.CheckBoxComboBox) As String
        CodigoGral = ""
        If combo.Text = "%" Then
            CodigoGral = "%"
        Else
            For i = 0 To combo.Items.Count - 1
                If combo.CheckBoxItems(i).Checked = True Then
                    If combo.CheckBoxItems(i).Text = "Pendiente" Then
                        CodigoGral = CodigoGral + "0,"
                    ElseIf combo.CheckBoxItems(i).Text = "Aprobado" Then
                        CodigoGral = CodigoGral + "1,"
                    ElseIf combo.CheckBoxItems(i).Text = "Anulado" Then
                        CodigoGral = CodigoGral + "2,"
                    End If
                End If
            Next
            If CodigoGral <> "" Then
                CodigoGral = Mid(CodigoGral, 1, CodigoGral.Length - 1)
            End If
        End If
        Return CodigoGral
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
    Private Function calcularcmbConTexto(combo As PresentationControls.CheckBoxComboBox, Campo As String, ReturnPorcentaje As String) As String
        CodigoGral = ""
        Dim contchk As Integer = 0
        If combo.Text = "%" And ReturnPorcentaje = "SI" Then
            CodigoGral = "%"
        Else
            For i = 0 To combo.Items.Count - 1
                If combo.CheckBoxItems(i).Checked = True Then
                    contchk = contchk + 1
                    If contchk = 1 Then
                        CodigoGral = "(" + Campo + " = '" + combo.CheckBoxItems(i).Text + "'"
                    Else
                        CodigoGral = CodigoGral + " OR " + Campo + " = '" + combo.CheckBoxItems(i).Text + "'"
                    End If
                End If
            Next
            If CodigoGral <> "" Then
                CodigoGral = CodigoGral + ")"
            End If
        End If
        Return CodigoGral
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
    Private Function FormatearFiltroCombo(combo As System.Windows.Forms.ComboBox, tipo As String) As String
        Formateado = ""
        If combo.Text = "%" Then
            Formateado = "%"
        Else
            If tipo = "T" Then
                Formateado = combo.Text
            ElseIf tipo = "SV" Then
                Formateado = combo.SelectedValue
            End If
        End If
        Return Formateado
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
    Private Sub cmbVendedor_Click(sender As Object, e As System.EventArgs) Handles cmbVendedor.Click
        cmbVendedor.Focus()
    End Sub

    Private Sub cmbZona1_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbZona1.CheckBoxCheckedChanged
        verificarchecks(cmbZona1, dtZonas)
    End Sub
    Private Sub cmbZona_Click(sender As Object, e As System.EventArgs) Handles cmbZona1.Click
        cmbZona1.Focus()
    End Sub
    Private Sub cmbCategCliente_Click(sender As Object, e As System.EventArgs) Handles cmbCategCliente.Click
        cmbCategCliente.Focus()
    End Sub
    Private Sub cmbComprobante_Click(sender As Object, e As System.EventArgs) Handles cmbComprobante.Click
        cmbComprobante.Focus()
    End Sub
    Private Sub cmbTipo_Click(sender As Object, e As System.EventArgs) Handles cmbTipo.Click
        cmbTipo.Focus()
    End Sub
    Private Sub cmbListaPrecio_Click(sender As Object, e As System.EventArgs) Handles cmbListaPrecio.Click
        cmbListaPrecio.Focus()
    End Sub
    Private Sub cmbSucursal1_Click(sender As Object, e As System.EventArgs) Handles cmbSucursal.Click
        cmbSucursal.Focus()
    End Sub

    Private Sub cmbZona1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbZona1.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbZona1.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbZona1, dtZonas)
            End If
            cmbZona1.Text = "%"
        End If
    End Sub
    Private Sub cmbZona1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbZona1.KeyUp
        If cmbZona1.Text = "" And cmbZona1.AccessibleName <> "False" Then
            cmbZona1.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodos(cmbZona1, dtZonas)
        End If
    End Sub
    Private Sub verificarvacioscombo(ByVal control As System.Windows.Forms.ComboBox)
        If Trim(control.Text) = "" Then
            control.Text = "%"
        End If
    End Sub
    Private Sub verificarchecks(ByVal control As PresentationControls.CheckBoxComboBox, dt As DataTable)
        If banverifcheck = True Then
            Dim contcheck As Integer = 0
            For i = 0 To dt.Rows.Count - 1
                If control.CheckBoxItems(i).Checked = True Then
                    contcheck = contcheck + 1
                End If
            Next
            If contcheck = dt.Rows.Count Then
                control.AccessibleName = "True"
            ElseIf contcheck = 0 Then
                control.AccessibleName = "False"
            Else
                control.AccessibleName = "Parcial"
            End If
        End If
    End Sub

    Private Sub verificarcheckssindt(ByVal control As PresentationControls.CheckBoxComboBox)
        If banverifcheck = True Then
            Dim contcheck As Integer = 0
            For i = 0 To control.CheckBoxItems.Count - 1
                If control.CheckBoxItems(i).Checked = True Then
                    contcheck = contcheck + 1
                End If
            Next
            If contcheck = control.CheckBoxItems.Count Then
                control.AccessibleName = "True"
            ElseIf contcheck = 0 Then
                control.AccessibleName = "False"
            Else
                control.AccessibleName = "Parcial"
            End If
        End If
    End Sub

    Private Sub cmbComprobante_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbComprobante.KeyUp
        If cmbComprobante.Text = "" And cmbComprobante.AccessibleName <> "False" Then
            cmbComprobante.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodos(cmbComprobante, dtComprobante)
        End If
    End Sub

    Private Sub cmbListaPrecio_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbListaPrecio.KeyUp
        If cmbListaPrecio.Text = "" And cmbListaPrecio.AccessibleName <> "False" Then
            cmbListaPrecio.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
        End If
    End Sub

    Private Sub cmbCategCliente_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbCategCliente.KeyUp
        If cmbCategCliente.Text = "" And cmbCategCliente.AccessibleName <> "False" Then
            cmbCategCliente.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodos(cmbCategCliente, dtCategoriaClientes)
        End If
    End Sub

    Private Sub cmbVendedor_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbVendedor.KeyUp
        If cmbVendedor.Text = "" And cmbVendedor.AccessibleName <> "False" Then
            cmbVendedor.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodos(cmbVendedor, dtVendedores)
        End If
    End Sub

    Private Sub cmbSucursal_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbSucursal.KeyUp
        If cmbSucursal.Text = "" And cmbSucursal.AccessibleName <> "False" Then
            cmbSucursal.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodos(cmbSucursal, dtSucursal)
        End If
    End Sub

    Private Sub cmbTipo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbTipo.KeyUp
        If cmbTipo.Text = "" And cmbTipo.AccessibleName <> "False" Then
            cmbTipo.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodossindt(cmbTipo)
        End If
    End Sub

    Private Sub pbxRangoProd_Click(sender As System.Object, e As System.EventArgs) Handles pbxRangoProd.Click
        If chbxCodProducto.Checked = True Then
            chbxCodProducto.Checked = False
        Else
            chbxCodProducto.Checked = True
        End If
    End Sub

    Private Sub pbxRangoCli_Click(sender As System.Object, e As System.EventArgs) Handles pbxRangoCli.Click
        If chbxCodCliente.Checked = True Then
            chbxCodCliente.Checked = False
        Else
            chbxCodCliente.Checked = True
        End If
    End Sub

    Private Sub cmbIngresoStock_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbIngresoStock.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbIngresoStock.Text = "%"
            cmbIngresoStock.Select()
        End If
    End Sub

    Private Sub rbtConNroFac_Click(sender As Object, e As System.EventArgs) Handles rbtConNroFac.Click
        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptEnvioPorClienteProducto" Then
            If rbtConNroFac.Checked = True Then
                pnlDetalleEnvio.Visible = True
            Else
                pnlDetalleEnvio.Visible = False
            End If
        End If
    End Sub
    Public Sub VentasListaPresupuesto() 'SAUL


        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvListaPresupuestoTableAdapter1.selectcommand.CommandText = "SELECT dbo.VENTAS.FECHAVENTA AS FECHA, SUBSTRING(dbo.VENTAS.NUMVENTA, 9, LEN(dbo.VENTAS.NUMVENTA) - 8) AS NUMVENTA, dbo.CLIENTES.NUMCLIENTE, " & _
            "dbo.VENTAS.COTIZACION1, dbo.VENDEDOR.NUMVENDEDOR, dbo.TIPOCLIENTE.NUMTIPOCLIENTE, dbo.MONEDA.SIMBOLO, dbo.VENTAS.TOTALIVA, dbo.VENTAS.TOTALVENTA, dbo.CLIENTES.NOMBRE, CLIENTES.NOMBREFANTASIA, VENDEDOR.CODVENDEDOR, VENDEDOR.DESVENDEDOR, dbo.VENTAS.TIPOVENTA, dbo.VENTAS.MOTIVOANULADO, dbo.VENTAS.CODPRESUPUESTO " & _
            "FROM         dbo.VENTAS LEFT OUTER JOIN " & _
                         "dbo.VENDEDOR ON dbo.VENTAS.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR LEFT OUTER JOIN " & _
                         "dbo.SUCURSAL ON dbo.VENTAS.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                         "dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.MONEDA ON dbo.VENTAS.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN " & _
                         "dbo.TIPOCLIENTE ON dbo.CLIENTES.CODTIPOCLIENTE = dbo.TIPOCLIENTE.CODTIPOCLIENTE LEFT OUTER JOIN " & _
                         "dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE "
            FormatF1 = FormatearFiltroCheckCombo(cmbVendedor, dtVendedores, "CODVENDEDOR", "SI")
            FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "SI")
            FormatF3 = FormatearFiltroCheckCombo(cmbComprobante, dtComprobante, "CODCOMPROBANTE", "SI")
            FormatF4 = calcularcmbTipoFactura(cmbTipo)
            FormatF5 = FormatearFiltroCheckCombo(cmbCategCliente, dtCategoriaClientes, "CODCATEGORIACLIENTE", "SI")
            Dim sqlwhere As String = obtenerwhere(FormatF1, "VENDEDOR.CODVENDEDOR", FormatF2, "SUCURSAL.CODSUCURSAL", FormatF3, "TIPOCOMPROBANTE.CODCOMPROBANTE", FormatF4, "VENTAS.MODALIDADPAGO", "CodigoIn", "CodigoIn", "CodigoIn", "CodigoIn", FormatF5, "CLIENTES.CODCATEGORIACLIENTE", "CodigoIn NULL")
            If chbxCodCliente.Checked = True Then
                Dim TestPos As Integer
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvListaPresupuestoTableAdapter1.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (dbo.VENTAS.CODPRESUPUESTO = 1) ORDER BY NUMVENTA"
                    Else
                        Me.RvListaPresupuestoTableAdapter1.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE IN (" & tbxcodCliente.Text & ") AND (dbo.VENTAS.CODPRESUPUESTO = 1)  ORDER BY NUMVENTA"
                    End If
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    If Trim(sqlwhere) = "" Then ' se eligieron todos %
                        Me.RvListaPresupuestoTableAdapter1.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " AND (dbo.VENTAS.CODPRESUPUESTO = 1)  ORDER BY NUMVENTA"
                    Else
                        Me.RvListaPresupuestoTableAdapter1.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND CLIENTES.NUMCLIENTE BETWEEN " & codInicio & " and " & codFin & " AND (dbo.VENTAS.CODPRESUPUESTO = 1) ORDER BY NUMVENTA"
                    End If
                End If
                Me.RvListaPresupuestoTableAdapter1.Fill(DsRVFacturacion.RVListaPresupuesto)
            Else
                If cmbCliente.Text <> "%" Then
                    If sqlwhere = "" Then
                        sqlwhere = "CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    Else
                        sqlwhere = sqlwhere + " AND CLIENTES.CODCLIENTE=" & cmbCliente.SelectedValue
                    End If
                End If

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RvListaPresupuestoTableAdapter1.selectcommand.CommandText += " WHERE (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND (dbo.VENTAS.CODPRESUPUESTO = 1) ORDER BY NUMVENTA"
                Else
                    Me.RvListaPresupuestoTableAdapter1.selectcommand.CommandText += " WHERE " + sqlwhere + " AND (VENTAS.ESTADO = 0) AND (VENTAS.FECHAVENTA >= '" & fechadesde2 & "') AND (VENTAS.FECHAVENTA <= '" & fechahasta2 & "') AND (dbo.VENTAS.CODPRESUPUESTO = 1) ORDER BY NUMVENTA"
                End If
                Me.RvListaPresupuestoTableAdapter1.Fill(DsRVFacturacion.RVListaPresupuesto)
            End If
            Dim rpt As New Reportes.VentasListaPresupuesto
            
            rpt.SetDataSource([DsRVFacturacion])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            rpt.SetParameterValue("pmtCliente", "(Todos)")
            If cmbVendedor.Text = "%" Then
                rpt.SetParameterValue("pmtVendedor", "(Todos)")
            Else
                rpt.SetParameterValue("pmtVendedor", cmbVendedor.Text)
            End If
            If cmbSucursal.Text = "%" Then
                rpt.SetParameterValue("pmtDeposito", "(Todos)")
            Else
                rpt.SetParameterValue("pmtDeposito", cmbSucursal.Text)
            End If

            If cmbComprobante.Text = "%" Then
                If cmbTipo.Text = "%" Then
                    rpt.SetParameterValue("pmtComprobante", "")
                Else
                    rpt.SetParameterValue("pmtComprobante", "/ " + cmbTipo.Text)
                End If
            Else
                If cmbTipo.Text = "%" Then
                    rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text)
                Else
                    rpt.SetParameterValue("pmtComprobante", cmbComprobante.Text + " " + cmbTipo.Text)
                End If
            End If
            If cmbCategCliente.Text = "%" Then
                rpt.SetParameterValue("pmtCategCli", "(Todas)")
            Else
                rpt.SetParameterValue("pmtCategCli", cmbCategCliente.Text)
            End If
            If rbIVASI.Checked = True Then
                rpt.SetParameterValue("pmtIVA", "Si")
            Else
                rpt.SetParameterValue("pmtIVA", "No")
            End If
            rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub UtilidadVenta()
        Try
            Dim fechadesde2, fechahasta2, NumFactura As String
            NumFactura = txtNumVenta.Text
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            Me.RvUtilidadVentasTableAdapter.selectcommand.CommandText = "SELECT dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.VENTAS.NUMVENTA, dbo.VENTAS.FECHAVENTA, dbo.CLIENTES.NOMBRE, dbo.CODIGOS.PRECIO, dbo.VENTASDETALLE.PRECIOVENTANETO, " & _
                                                                "dbo.VENTASDETALLE.PRECIOVENTANETO - dbo.CODIGOS.PRECIO AS DIFERENCIA, CASE dbo.CODIGOS.PRECIO WHEN 0 THEN 1 ELSE ((dbo.VENTASDETALLE.PRECIOVENTANETO / ISNULL(dbo.CODIGOS.PRECIO, 1)) - 1) * 100 END AS UTILIDAD, dbo.VENTASDETALLE.CANTIDADVENTA, " & _
                                                                "dbo.CLIENTES.RUC, dbo.VENTAS.TIPOVENTA, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTAL10, dbo.VENTAS.TOTALIVA, dbo.VENDEDOR.DESVENDEDOR, dbo.VENTAS.MOTIVODESCUENTO,dbo.VENTASDETALLE.PRECIOVENTANETO  " & _
                                                                "FROM dbo.CLIENTES INNER JOIN dbo.VENTAS ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE INNER JOIN dbo.VENTASDETALLE ON dbo.VENTAS.CODVENTA = dbo.VENTASDETALLE.CODVENTA INNER JOIN " & _
                                                                "dbo.CODIGOS INNER JOIN dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO ON dbo.VENTASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO LEFT OUTER JOIN " & _
                                                                "dbo.VENDEDOR ON dbo.VENTAS.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR  "

            If cmbCliente.Text = "%" And txtNumVenta.Text = "%" Then
                Me.RvUtilidadVentasTableAdapter.selectcommand.CommandText += " WHERE (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & fechadesde2 & "', 121)) AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & fechahasta2 & "', 121)) AND (dbo.VENTAS.ESTADO = 1) AND (dbo.VENTAS.CODPRESUPUESTO = 0) GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CLIENTES.NOMBRE, dbo.VENTASDETALLE.PRECIOVENTANETO, dbo.CODIGOS.PRECIO, dbo.VENTASDETALLE.PRECIOVENTANETO / dbo.VENTASDETALLE.CANTIDADVENTA, dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.CLIENTES.RUC, dbo.VENTAS.TIPOVENTA, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTAL10, dbo.VENTAS.TOTALIVA, dbo.VENDEDOR.DESVENDEDOR, dbo.VENTAS.MOTIVODESCUENTO,dbo.VENTASDETALLE.PRECIOVENTANETO"
            ElseIf cmbCliente.Text <> "%" And txtNumVenta.Text = "%" Then
                Me.RvUtilidadVentasTableAdapter.selectcommand.CommandText += " WHERE (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & fechadesde2 & "', 121)) AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & fechahasta2 & "', 121)) AND (dbo.VENTAS.ESTADO = 1) AND (dbo.VENTAS.CODPRESUPUESTO = 0) AND (dbo.VENTAS.CODCLIENTE = " & CInt(cmbCliente.SelectedValue) & ") GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CLIENTES.NOMBRE, dbo.VENTASDETALLE.PRECIOVENTANETO, dbo.CODIGOS.PRECIO, dbo.VENTASDETALLE.PRECIOVENTANETO / dbo.VENTASDETALLE.CANTIDADVENTA, dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.CANTIDADVENTA,dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.CLIENTES.RUC, dbo.VENTAS.TIPOVENTA, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTAL10, dbo.VENTAS.TOTALIVA, dbo.VENDEDOR.DESVENDEDOR, dbo.VENTAS.MOTIVODESCUENTO,dbo.VENTASDETALLE.PRECIOVENTANETO"
            ElseIf cmbCliente.Text = "%" And txtNumVenta.Text <> "%" Then
                Me.RvUtilidadVentasTableAdapter.selectcommand.CommandText += " WHERE (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & fechadesde2 & "', 121)) AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & fechahasta2 & "', 121)) AND (dbo.VENTAS.ESTADO = 1) AND (dbo.VENTAS.CODPRESUPUESTO = 0) AND (dbo.VENTAS.NUMVENTA LIKE '%" & NumFactura & "%') GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CLIENTES.NOMBRE, dbo.VENTASDETALLE.PRECIOVENTANETO, dbo.CODIGOS.PRECIO, dbo.VENTASDETALLE.PRECIOVENTANETO / dbo.VENTASDETALLE.CANTIDADVENTA, dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.CANTIDADVENTA,dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.CLIENTES.RUC, dbo.VENTAS.TIPOVENTA, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTAL10, dbo.VENTAS.TOTALIVA, dbo.VENDEDOR.DESVENDEDOR, dbo.VENTAS.MOTIVODESCUENTO,dbo.VENTASDETALLE.PRECIOVENTANETO"
            Else
                Me.RvUtilidadVentasTableAdapter.selectcommand.CommandText += " WHERE (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & fechadesde2 & "', 121)) AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & fechahasta2 & "', 121)) AND (dbo.VENTAS.ESTADO = 1) AND (dbo.VENTAS.CODPRESUPUESTO = 0) AND (dbo.VENTAS.NUMVENTA LIKE '%" & NumFactura & "%') AND (dbo.VENTAS.CODCLIENTE = " & CInt(cmbCliente.SelectedValue) & ") GROUP BY dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CLIENTES.NOMBRE, dbo.VENTASDETALLE.PRECIOVENTANETO, dbo.CODIGOS.PRECIO, dbo.VENTASDETALLE.PRECIOVENTANETO / dbo.VENTASDETALLE.CANTIDADVENTA, dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.CANTIDADVENTA,dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.CLIENTES.RUC, dbo.VENTAS.TIPOVENTA, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTAL10, dbo.VENTAS.TOTALIVA, dbo.VENDEDOR.DESVENDEDOR, dbo.VENTAS.MOTIVODESCUENTO,dbo.VENTASDETALLE.PRECIOVENTANETO"
            End If

            Me.RvUtilidadVentasTableAdapter.Fill(DsRVEstadisticas.RVUtilidadVentas) : Dim rpt As New Reportes.rptUtilidadVenta

            rpt.SetDataSource([DsRVEstadisticas]) : rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia) : rpt.SetParameterValue("fechadesde", dtpFechaDesde.Text) : rpt.SetParameterValue("fechahasta", dtpFechaHasta.Text)
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt : frm.WindowState = FormWindowState.Maximized : frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt : CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNumVenta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumVenta.KeyDown
        If e.KeyCode = Keys.F12 Then
            txtNumVenta.Text = "%"
        End If
    End Sub

    Private Sub txtNumVenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumVenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaDesde.Focus()
        End If
    End Sub
    Public Sub VentasDetalladaXCliente()
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            '*************************************************************
            Dim TestPos As Integer
            If chbxCodCliente.Checked = True Then
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    Me.VentasDetXClienteTableAdapter.FillByUC(DsRVEstadisticas.VentasDetXCliente, fechadesde2, fechahasta2, tbxcodCliente.Text)
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    Me.VentasDetXClienteTableAdapter.FillByC(DsRVEstadisticas.VentasDetXCliente, codInicio, codFin, fechadesde2, fechahasta2)
                End If
            ElseIf cmbCliente.Text = "%" Then
                Me.VentasDetXClienteTableAdapter.Fill(DsRVEstadisticas.VentasDetXCliente, fechadesde2, fechahasta2)
            Else
                Me.VentasDetXClienteTableAdapter.FillByUC(DsRVEstadisticas.VentasDetXCliente, fechadesde2, fechahasta2, cmbCliente.SelectedValue)
            End If
            '*************************************************************

            Dim rpt As New Reportes.VentasDetalladaXCliente

            rpt.SetDataSource([DsRVEstadisticas]) : rpt.SetParameterValue("pmtFechadesde", dtpFechaDesde.Value.ToString("dd/MM/yyy")) : rpt.SetParameterValue("pmtFechaHasta", dtpFechaHasta.Value.ToString("dd/MM/yyy"))
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                frm.CrystalReportViewer1.ReportSource = rpt : frm.WindowState = FormWindowState.Maximized : frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt : CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Sub VentasListaPresupuestoSC() 'SAUL
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            If cmbSucursal.Text = "%" And cmbVendedor.Text = "%" And cmbCliente.Text = "%" Then
                Me.RvPresupuestoDetalladoTableAdapter.Fill(DsRVFacturacion.RVPresupuestoDetallado, fechadesde2, fechahasta2) 'sin filtro
            ElseIf cmbSucursal.Text = "%" And cmbVendedor.Text = "%" Then
                Me.RvPresupuestoDetalladoTableAdapter.FillByCliente(DsRVFacturacion.RVPresupuestoDetallado, fechadesde2, fechahasta2, cmbCliente.SelectedValue) ' por cliente
            ElseIf cmbSucursal.Text = "%" Then ' por vendedor y cliente
                Me.RvPresupuestoDetalladoTableAdapter.FillByVenCli(DsRVFacturacion.RVPresupuestoDetallado, fechadesde2, fechahasta2, cmbVendedor.SelectedValue, cmbCliente.SelectedValue)
            ElseIf cmbSucursal.Text = "%" And cmbCliente.Text = "%" Then ' por vendedor
                Me.RvPresupuestoDetalladoTableAdapter.FillByVen(DsRVFacturacion.RVPresupuestoDetallado, fechadesde2, fechahasta2, cmbVendedor.SelectedValue)
            ElseIf cmbVendedor.Text = "%" And cmbCliente.Text = "%" Then 'por sucursal
                Me.RvPresupuestoDetalladoTableAdapter.FillBySuc(DsRVFacturacion.RVPresupuestoDetallado, fechadesde2, fechahasta2, cmbSucursal.SelectedValue)
            ElseIf cmbCliente.Text = "%" Then ' sucursal - vendedor
                Me.RvPresupuestoDetalladoTableAdapter.FillBySucVen(DsRVFacturacion.RVPresupuestoDetallado, fechadesde2, fechahasta2, cmbSucursal.SelectedValue, cmbVendedor.SelectedValue)
            ElseIf cmbVendedor.Text = "%" Then ' sucursal - cliente
                Me.RvPresupuestoDetalladoTableAdapter.FillBySucCli(DsRVFacturacion.RVPresupuestoDetallado, fechadesde2, fechahasta2, cmbSucursal.SelectedValue, cmbCliente.SelectedValue)
            End If

            Dim rpt As New Reportes.VentasListaPresupuestoDetallado

            rpt.SetDataSource([DsRVFacturacion])
            rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
            
            rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub rptVentasTipoPago() 'SAUL
        Try
            Dim fechadesde2, fechahasta2 As String
            fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
            fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

            If cmbTipoCobro.Text = "%" And cmbCliente.Text = "%" Then
                Me.VentasTipoPagoTableAdapter.Fill(DsRVFacturacion.VentasTipoPago, fechadesde2, fechahasta2) 'sin filtro
            ElseIf cmbTipoCobro.Text = "%" Then
                TestPos = InStr(1, tbxcodCliente.Text, "-", CompareMethod.Text)
                If TestPos = 0 Then 'El texto no tiene guion
                    Me.VentasTipoPagoTableAdapter.FillByClie(DsRVFacturacion.VentasTipoPago, fechadesde2, fechahasta2, cmbCliente.SelectedValue) ' por cliente
                Else
                    Dim codInicio As String = Trim(Mid(tbxcodCliente.Text, 1, TestPos - 1))
                    Dim codFin As String = Trim(Mid(tbxcodCliente.Text, TestPos + 1, tbxcodCliente.Text.Length))
                    Me.VentasTipoPagoTableAdapter.FillByRangoC(DsRVFacturacion.VentasTipoPago, fechadesde2, fechahasta2, codInicio, codFin)
                End If
            ElseIf cmbCliente.Text = "%" Then ' por cobro
                Me.VentasTipoPagoTableAdapter.FillByCobro(DsRVFacturacion.VentasTipoPago, fechadesde2, fechahasta2, cmbTipoCobro.SelectedValue)
            ElseIf cmbCliente.Text <> "%" And cmbTipoCobro.Text <> "%" Then ' por cliente y tipo cobro
                Me.VentasTipoPagoTableAdapter.FillByCobCli(DsRVFacturacion.VentasTipoPago, fechadesde2, fechahasta2, cmbTipoCobro.SelectedValue, cmbCliente.SelectedValue)
            End If

            Dim rpt As New Reportes.VentasTipoPago

            rpt.SetDataSource([DsRVFacturacion])

            rpt.SetParameterValue("pmtFDesde", dtpFechaDesde.Text)
            rpt.SetParameterValue("pmtFHasta", dtpFechaHasta.Text)
            If chbxNuevaVent.Checked = True Then
                Dim frm = New VerInformes
                If chbxMatricial.Checked = True Then
                Else
                    frm.CrystalReportViewer1.ReportSource = rpt
                End If
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                If chbxMatricial.Checked = True Then
                Else
                    CrystalReportViewer.ReportSource = rpt
                End If
                CrystalReportViewer.Refresh()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTipoCobro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoCobro.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbTipoCobro.Text = "%"
        End If
    End Sub

    Public Sub LiquidaciondeVendedores() 'saul
        'Try
        '    Dim fechadesde2, fechahasta2 As String
        '    fechadesde2 = dtpFechaDesde.Value.ToString("yyy/MM/dd") & " 00:00:00"
        '    fechahasta2 = dtpFechaHasta.Value.ToString("yyy/MM/dd") & " 23:59:00"

        '    If cmbVendedor.Text = "%" Then
        '        Me.LiquidacionvendTableAdapter.FillByfecha(DsComisiones1.LIQUIDACIONVEND, fechadesde2, fechahasta2)
        '        Me.VentascaidasTableAdapter.FillByfecha(DsComisiones1.VENTASCAIDAS, fechadesde2, fechahasta2)
        '    Else
        '        Me.LiquidacionvendTableAdapter.Fill(DsComisiones1.LIQUIDACIONVEND, fechadesde2, fechahasta2, CInt(cmbVendedor.SelectedValue))
        '        Me.VentascaidasTableAdapter.Fill(DsComisiones1.VENTASCAIDAS, fechadesde2, fechahasta2, CInt(cmbVendedor.SelectedValue))
        '    End If

        '    Dim rpt As New Reportes.LiquidacionSemanalVendedores

        '    rpt.SetDataSource([DsComisiones1])

        '    rpt.SetParameterValue("ptmfechadesde", dtpFechaDesde.Text) : rpt.SetParameterValue("ptmfechahasta", dtpFechaHasta.Text) : rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        '    If chbxNuevaVent.Checked = True Then
        '        Dim frm = New VerInformes : frm.CrystalReportViewer1.ReportSource = rpt : frm.WindowState = FormWindowState.Maximized : frm.Show()
        '    Else
        '        CrystalReportViewer.ReportSource = rpt : CrystalReportViewer.Refresh()
        '    End If
        'Catch ex As Exception
        '    If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
        '        MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'End Try
    End Sub
    Public Sub SaldoCliente() 'DICOPAR

        Dim rpt As New Reportes.VentasSaldoCliente()
        Dim dt As New DataTable

        Me.RvFacturasACobrarTableAdapter.FillBySinfiltro(Me.DsRVCobros.RVFACTURASACOBRAR)

        'rpt.SetDataSource([DsRVCobros])
        'rpt.SetParameterValue("pmtRangoFecha", dtpFechaDesde.Text + " - " + dtpFechaHasta.Text)
        'If chbxCodCliente.Checked = True Then
        '    rpt.SetParameterValue("pmtCliente", tbxcodCliente.Text)
        'ElseIf cmbCliente.Text = "%" Then
        '    rpt.SetParameterValue("pmtCliente", "(Todos)")
        'Else
        '    Dim w As New Funciones.Funciones
        '    NumCliente = w.FuncionConsulta("NUMCLIENTE", "CLIENTES", "CODCLIENTE", cmbCliente.SelectedValue)
        '    rpt.SetParameterValue("pmtCliente", NumCliente)
        'End If

        'If cmbListaPrecio.Text = "%" Then
        '    rpt.SetParameterValue("pmtListaPrecio", "(Todas)")
        'Else
        '    rpt.SetParameterValue("pmtListaPrecio", cmbListaPrecio.Text)
        'End If

        'rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        'If chbxMatricial.Checked = True Then
        '    CrystalReportViewer.ReportSource = rptmat
        'Else
        '    CrystalReportViewer.ReportSource = rpt
        'End If
        'CrystalReportViewer.Refresh()
        'End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class

