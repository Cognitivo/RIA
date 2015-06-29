Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad
Imports System.Drawing.SystemIcons
Imports CrystalDecisions.Windows.Forms

Public Class FiltroReporteProduccion
    Dim sql As String
    Dim sql1 As String
    Dim Pos1 As System.Drawing.Point = New Point(3, 56)
    Dim Pos2 As System.Drawing.Point = New Point(3, 104)
    Dim Pos3 As System.Drawing.Point = New Point(3, 152)
    Dim Pos4 As System.Drawing.Point = New Point(3, 200)
    Dim Pos5 As System.Drawing.Point = New Point(3, 260)
    Dim Pos6 As System.Drawing.Point = New Point(3, 296)
    Dim Pos7 As System.Drawing.Point = New Point(3, 344)
    Dim PosSinFiltro As System.Drawing.Point = New Point(4, 31)
    Dim PosInvisible As System.Drawing.Point = New Point(3000, 33)
    Dim banverifcheck As Boolean = True
    Dim permiso As Double
    Dim FechaDesde, DesdeA As String
    Dim FechaHasta, HastaA As String
    Dim ListaReportes(15, 3) As String
    Dim f As New Funciones.Funciones
    Dim dtSucursal, dtComprobante As DataTable
    Dim FormatF1, FormatF2, FormatF3, FormatF4, FormatF5, Formateado, CodigoGral As String
    Dim Buscador As String

    'Variables para la Conexion con la BD
    Private objCommand As New SqlCommand
    Dim dr As SqlDataReader
    Private ser As BDConexión.BDConexion
    Private consulta As System.String
    Private conexion As System.Data.SqlClient.SqlConnection
    Private myTrans As System.Data.SqlClient.SqlTransaction

    Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        objCommand = New SqlCommand

        conexion = New SqlConnection
        conexion.ConnectionString = My.Settings.GESTIONConnectionString2
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

    Private Sub CargarListaReportes()
        ListaReportes = {{"TITULO", "INFORMES DE PRODUCCION", "Informe,Produccion"},
                         {"rptProduccionEntradaProducto", "Entrada de Prod. por Periodo por Producto", "Producción,Entrada/Producto"},
                         {"rptProduccionSalidaProducto", "Salida de Prod. por Periodo por Producto", "Producción,Salida/Producto"},
                         {"rptProduccionComparativo", "Comparativo de Prod. por Mes por Producto", "Comparativo,Producto"}}


        For i = 0 To 3
            dgvListaReportes.Rows.Add()
            dgvListaReportes.Item(1, i).Value = ListaReportes(i, 0)
            dgvListaReportes.Item(0, i).Value = ListaReportes(i, 1)
            dgvListaReportes.Item(2, i).Value = ListaReportes(i, 2)
        Next
        dgvListaReportes.AllowUserToAddRows = False
    End Sub

    Private Sub InvisivilizarTodo()
        pnlfechas.Location = PosInvisible
        pnlOtrasOpciones.Location = PosInvisible
        pnlProducto.Location = PosInvisible
        pnlCategorias.Location = PosInvisible
        pnlAgrupado.Location = PosInvisible
    End Sub

    Private Sub rptProduccionSalidaProducto()
        ' Dim rpt1 As New Reportes.ProdProduccionPeriodo
        Dim rpt2 As New Reportes.ProdProduccionPeriodoProducto
        Dim Titulo As String
        Dim CodFamilia As Integer
        Dim desde As String = dtpFechaDesde.Value.Date
        Dim hasta As String = dtpFechaHasta.Value.Date
        Dim CodCodigo As Integer
        Dim DesdeAño As String = dtpFechaDesde.Value.Year
        Dim HastaAño As String = dtpFechaHasta.Value.Year
        DesdeA = "01/01/" & DesdeAño
        hastaA = "31/12/" & HastaAño
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:00"
        Titulo = "Salidas de Producción Por Producto"

        CodCodigo = cmbProducto.SelectedValue
        CodFamilia = cbxCategoria.SelectedValue

        If rbtAPorD.Checked = True Then
            If cmbProducto.Text = "%" And cbxCategoria.Text = "%" Then
                Me.VProduccionTableAdapter.Fill(DsProducccionInforme.VProduccion, desde, hasta, 0)
            Else
                If cmbProducto.Text = "%" And cbxCategoria.Text <> "%" Then
                    Me.VProduccionTableAdapter.FillByFD(DsProducccionInforme.VProduccion, desde, hasta, 0, CodFamilia)
                End If
                If cmbProducto.Text <> "%" And cbxCategoria.Text = "%" Then
                    Me.VProduccionTableAdapter.FillByPD(DsProducccionInforme.VProduccion, desde, hasta, 0, CodCodigo)
                End If
                If cmbProducto.Text <> "%" And cbxCategoria.Text <> "%" Then
                    Me.VProduccionTableAdapter.FillByPFD(DsProducccionInforme.VProduccion, desde, hasta, 0, CodFamilia, CodCodigo)
                End If
            End If
        Else
            If rbtAPorM.Checked = True Then
                If cmbProducto.Text = "%" And cbxCategoria.Text = "%" Then
                    Me.VProduccionTableAdapter.FillByMes(DsProducccionInforme.VProduccion, desde, hasta, 0)
                Else
                    If cmbProducto.Text = "%" And cbxCategoria.Text <> "%" Then
                        Me.VProduccionTableAdapter.FillByFM(DsProducccionInforme.VProduccion, desde, hasta, 0, CodFamilia)
                    End If
                    If cmbProducto.Text <> "%" And cbxCategoria.Text = "%" Then
                        Me.VProduccionTableAdapter.FillByPM(DsProducccionInforme.VProduccion, desde, hasta, 0, CodCodigo)
                    End If
                    If cmbProducto.Text <> "%" And cbxCategoria.Text <> "%" Then
                        Me.VProduccionTableAdapter.FillByPFM(DsProducccionInforme.VProduccion, desde, hasta, 0, CodFamilia, CodCodigo)
                    End If
                End If
            End If
            If rbtAPorA.Checked = True Then
                If cmbProducto.Text = "%" And cbxCategoria.Text = "%" Then
                    Me.VProduccionTableAdapter.FillByAnho(DsProducccionInforme.VProduccion, DesdeA, HastaA, 0)
                Else
                    If cmbProducto.Text = "%" And cbxCategoria.Text <> "%" Then
                        Me.VProduccionTableAdapter.FillByFA(DsProducccionInforme.VProduccion, DesdeA, HastaA, 0, CodFamilia)
                    End If
                    If cmbProducto.Text <> "%" And cbxCategoria.Text = "%" Then
                        Me.VProduccionTableAdapter.FillByPFA(DsProducccionInforme.VProduccion, DesdeA, HastaA, 0, CodCodigo)
                    End If
                    If cmbProducto.Text <> "%" And cbxCategoria.Text <> "%" Then
                        Me.VProduccionTableAdapter.FillByPFA(DsProducccionInforme.VProduccion, DesdeA, HastaA, 0, CodCodigo)
                    End If
                End If
            End If
        End If
        rpt2.SetDataSource(DsProducccionInforme)
        rpt2.SetParameterValue("pmtFechaDesde", desde)
        rpt2.SetParameterValue("pmtFechaHasta", hasta)
        rpt2.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt2.SetParameterValue("pmtTipo", Titulo)

        If rbtAPorA.Checked = True Then
            rpt2.SetParameterValue("pmtPeriodo", 1)
        End If
        If rbtAPorD.Checked = True Then
            rpt2.SetParameterValue("pmtPeriodo", 2)
        End If
        If rbtAPorM.Checked = True Then
            rpt2.SetParameterValue("pmtPeriodo", 3)
        End If

        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt2
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt2
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub rptProduccionEntradaProducto()
        ' Dim rpt1 As New Reportes.ProdProduccionPeriodo
        Dim rpt2 As New Reportes.ProdProduccionPeriodoProducto
        Dim Titulo As String
        Dim CodFamilia As Integer
        Dim desde As String = dtpFechaDesde.Value.Date
        Dim hasta As String = dtpFechaHasta.Value.Date
        Dim CodCodigo As Double
        Dim DesdeAño As String = dtpFechaDesde.Value.Year
        Dim HastaAño As String = dtpFechaHasta.Value.Year
        DesdeA = "01/01/" & DesdeAño
        HastaA = "31/12/" & HastaAño
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:00"
        Titulo = "Entrada de Producción Por Producto" : Periodo = ""

        CodCodigo = CStr(cmbProducto.SelectedValue)
        CodFamilia = cbxCategoria.SelectedValue

        If rbtAPorD.Checked = True Then
            If cmbProducto.Text = "%" And cbxCategoria.Text = "%" Then
                Me.VProduccionTableAdapter.Fill(DsProducccionInforme.VProduccion, desde, hasta, 1)
            Else
                If cmbProducto.Text = "%" And cbxCategoria.Text <> "%" Then
                    Me.VProduccionTableAdapter.FillByFD(DsProducccionInforme.VProduccion, desde, hasta, 1, CodFamilia)
                End If
                If cmbProducto.Text <> "%" And cbxCategoria.Text = "%" Then
                    Me.VProduccionTableAdapter.FillByPD(DsProducccionInforme.VProduccion, desde, hasta, 1, CodCodigo)
                End If
                If cmbProducto.Text <> "%" And cbxCategoria.Text <> "%" Then
                    Me.VProduccionTableAdapter.FillByPFD(DsProducccionInforme.VProduccion, desde, hasta, 1, CodFamilia, CodCodigo)
                End If
            End If
        Else
            If rbtAPorM.Checked = True Then
                If cmbProducto.Text = "%" And cbxCategoria.Text = "%" Then
                    Me.VProduccionTableAdapter.FillByMes(DsProducccionInforme.VProduccion, desde, hasta, 1)
                Else
                    If cmbProducto.Text = "%" And cbxCategoria.Text <> "%" Then
                        Me.VProduccionTableAdapter.FillByFM(DsProducccionInforme.VProduccion, desde, hasta, 1, CodFamilia)
                    End If
                    If cmbProducto.Text <> "%" And cbxCategoria.Text = "%" Then
                        Me.VProduccionTableAdapter.FillByPM(DsProducccionInforme.VProduccion, desde, hasta, 1, CodCodigo)
                    End If
                    If cmbProducto.Text <> "%" And cbxCategoria.Text <> "%" Then
                        Me.VProduccionTableAdapter.FillByPFM(DsProducccionInforme.VProduccion, desde, hasta, 1, CodFamilia, CodCodigo)
                    End If
                End If
            End If
            If rbtAPorA.Checked = True Then
                If cmbProducto.Text = "%" And cbxCategoria.Text = "%" Then
                    Me.VProduccionTableAdapter.FillByAnho(DsProducccionInforme.VProduccion, DesdeA, HastaA, 1)
                Else
                    If cmbProducto.Text = "%" And cbxCategoria.Text <> "%" Then
                        Me.VProduccionTableAdapter.FillByFA(DsProducccionInforme.VProduccion, DesdeA, HastaA, 1, CodFamilia)
                    End If
                    If cmbProducto.Text <> "%" And cbxCategoria.Text = "%" Then
                        Me.VProduccionTableAdapter.FillByPFA(DsProducccionInforme.VProduccion, DesdeA, HastaA, 1, CodCodigo)
                    End If
                    If cmbProducto.Text <> "%" And cbxCategoria.Text <> "%" Then
                        Me.VProduccionTableAdapter.FillByPFA(DsProducccionInforme.VProduccion, DesdeA, HastaA, 1, CodCodigo)
                    End If
                End If
            End If
        End If
        rpt2.SetDataSource(DsProducccionInforme)
        rpt2.SetParameterValue("pmtFechaDesde", desde)
        rpt2.SetParameterValue("pmtFechaHasta", hasta)
        rpt2.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        rpt2.SetParameterValue("pmtTipo", Titulo)

        If rbtAPorA.Checked = True Then
            rpt2.SetParameterValue("pmtPeriodo", 1)
        End If
        If rbtAPorD.Checked = True Then
            rpt2.SetParameterValue("pmtPeriodo", 2)
        End If
        If rbtAPorM.Checked = True Then
            rpt2.SetParameterValue("pmtPeriodo", 3)
        End If

        If chbxNuevaVent.Checked = True Then
            Dim frm = New VerInformes
            frm.CrystalReportViewer1.ReportSource = rpt2
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt2
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Private Sub rptProduccionComparativo()
        Dim rpt1 As New Reportes.ProdProduccionPeriodoComparativo
        Dim rpt2 As New Reportes.ProdProduccionPeriodoComparativoFamilia
        Dim rpt3 As New Reportes.ProdProduccionPeriodoComparativoEntrada
        Dim rpt4 As New Reportes.ProdProduccionPeriodoComparativoFamiliaEntrada
        Dim Titulo As String
        Dim desde As String = dtpFechaDesde.Value
        Dim hasta As String = dtpFechaHasta.Value
        Dim CodFamilia As Integer
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:00"

        CodFamilia = cbxCategoria.SelectedValue

        If rbtSalida.Checked = True Then ' COMPARATIVO DE SALIDA
            If cbxCategoria.Text <> "%" Then
                Titulo = "COMPARATIVO DE PRODUCCION DE SALIDA POR MES/FAMILIA/PRODUCTO"
                Me.VProduccionComparativoTableAdapter1.FillBy(DsProducccionInforme.VProduccionComparativo, desde, hasta, CodFamilia)
                rpt2.SetDataSource(DsProducccionInforme)
                rpt2.SetParameterValue("pmtFechaDesde", desde)
                rpt2.SetParameterValue("pmtFechaHasta", hasta)
                rpt2.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt2.SetParameterValue("pmtTipo", Titulo)

                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt2
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt2
                    CrystalReportViewer.Refresh()
                End If
            Else
                Titulo = "COMPARATIVO DE PRODUCCION DE SALIDA POR MES/PRODUCTO"
                Me.VProduccionComparativoTableAdapter1.Fill(DsProducccionInforme.VProduccionComparativo, desde, hasta)

                rpt1.SetDataSource(DsProducccionInforme)
                rpt1.SetParameterValue("pmtFechaDesde", desde)
                rpt1.SetParameterValue("pmtFechaHasta", hasta)
                rpt1.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt1.SetParameterValue("pmtTipo", Titulo)

                If chbxNuevaVent.Checked = True Then
                    Dim frm = New VerInformes
                    frm.CrystalReportViewer1.ReportSource = rpt1
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt1
                    CrystalReportViewer.Refresh()
                End If
            End If
        Else
            If rbtEntrada.Checked = True Then 'COMPARATIVO DE ENTRADA
                If cbxCategoria.Text <> "%" Then
                    Titulo = "COMPARATIVO DE PRODUCCION DE ENTRADA POR MES/FAMILIA/PRODUCTO"
                    Me.VProduccionComparativoEntradaTableAdapter.FillBy(DsProducccionInforme.VProduccionComparativoEntrada, desde, hasta, CodFamilia)
                    rpt4.SetDataSource(DsProducccionInforme)
                    rpt4.SetParameterValue("pmtFechaDesde", desde)
                    rpt4.SetParameterValue("pmtFechaHasta", hasta)
                    rpt4.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    rpt4.SetParameterValue("pmtTipo", Titulo)

                    If chbxNuevaVent.Checked = True Then
                        Dim frm = New VerInformes
                        frm.CrystalReportViewer1.ReportSource = rpt4
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rpt4
                        CrystalReportViewer.Refresh()
                    End If
                Else
                    Titulo = "COMPARATIVO DE PRODUCCION DE ENTRADA POR MES/PRODUCTO"
                    Me.VProduccionComparativoEntradaTableAdapter.Fill(DsProducccionInforme.VProduccionComparativoEntrada, desde, hasta)

                    rpt3.SetDataSource(DsProducccionInforme)
                    rpt3.SetParameterValue("pmtFechaDesde", desde)
                    rpt3.SetParameterValue("pmtFechaHasta", hasta)
                    rpt3.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                    rpt3.SetParameterValue("pmtTipo", Titulo)

                    If chbxNuevaVent.Checked = True Then
                        Dim frm = New VerInformes
                        frm.CrystalReportViewer1.ReportSource = rpt3
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rpt3
                        CrystalReportViewer.Refresh()
                    End If
                End If
            End If
        End If
    End Sub
    'Private Sub rptOrdenProduccion()   XAVI
    '    Dim rpt As New Reportes.OrdenPlanillaProduccionReporte

    '    Me.ORDENPRODUCCIONCOSTOTOTALTableAdapter.Fill(DsProdInforme.ORDENPRODUCCIONCOSTOTOTAL, cbxOrdenProd.SelectedValue)
    '    Me.PLANILLAPRODUCCIONCOSTOTableAdapter.Fill(DsProdInforme.PLANILLAPRODUCCIONCOSTO, cbxOrdenProd.SelectedValue)
    '    Me.IMPMATERIAPRIMATableAdapter.Fill(DsOrdProduccion.IMPMATERIAPRIMA, cbxOrdenProd.SelectedValue)
    '    Me.IMPPRODUCTOTERMTableAdapter.Fill(DsOrdProduccion.IMPPRODUCTOTERM, cbxOrdenProd.SelectedValue)

    '    rpt.SetDataSource([DsProdInforme])
    '    rpt.SetDataSource([DsOrdProduccion])

    '        If chbxNuevaVent.Checked = True Then
    '            Dim frm = New VerInformes
    '        frm.CrystalReportViewer1.ReportSource = rpt
    '            frm.WindowState = FormWindowState.Maximized
    '            frm.Show()
    '        Else
    '        CrystalReportViewer.ReportSource = rpt
    '            CrystalReportViewer.Refresh()
    '        End If

    'End Sub

    Private Sub ObtenerDia()
        Try
            ser.Abrir(conexion)
            objCommand = New SqlCommand("SELECT DATEADD(DAY, DATEDIFF(day,0,getdate()), 0)as 'Desde',dateadd(ms,-3,DATEADD(day, DATEDIFF(day,0,getdate()  )+1, 0))'Hasta'", conexion)
            dr = objCommand.ExecuteReader
            dr.Read()
            dtpFechaDesde.Text = dr.Item("Desde").ToString
            dtpFechaHasta.Text = dr.Item("Hasta").ToString
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al Obtener la fecha : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerMes()
        Try
            ser.Abrir(conexion)
            objCommand = New SqlCommand("SELECT DATEADD(mm, DATEDIFF(mm,0,getdate()), 0)as 'Desde',dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,getdate()  )+1, 0))as 'Hasta'", conexion)
            dr = objCommand.ExecuteReader
            dr.Read()
            dtpFechaDesde.Text = dr.Item("Desde").ToString
            dtpFechaHasta.Text = dr.Item("Hasta").ToString
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al Obtener la fecha : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerAño()
        Try
            ser.Abrir(conexion)
            objCommand = New SqlCommand(" SELECT CONVERT (CHAR(20), CONVERT(CHAR(4), YEAR(GETDATE())) + '/01/01', 111) as Desde,CONVERT (CHAR(20), CONVERT(CHAR(4), YEAR(GETDATE())) + '/12/31', 111) as Hasta ", conexion)
            dr = objCommand.ExecuteReader
            dr.Read()
            dtpFechaDesde.Text = dr.Item("Desde").ToString
            dtpFechaHasta.Text = dr.Item("Hasta").ToString
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al Obtener la fecha : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxCategoria.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbxCategoria.Text = "%"
        End If
    End Sub

    Private Sub FiltroReporteProduccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsOrdProduccion.TIPOPRODUCCION' table. You can move, or remove it, as needed.
        'Me.TIPOPRODUCCIONTableAdapter1.Fill(Me.DsOrdProduccion.TIPOPRODUCCION)
        'TODO: This line of code loads data into the 'DsProducccionInforme.TIPOPRODUCCION' table. You can move, or remove it, as needed.
        Me.TIPOPRODUCCIONTableAdapter.Fill(Me.DsProducccionInforme.TIPOPRODUCCION)
        'TODO: This line of code loads data into the 'DsProducccionInforme.ORDENPRODUCCION' table. You can move, or remove it, as needed.
        Me.ORDENPRODUCCIONTableAdapter.Fill(Me.DsProducccionInforme.ORDENPRODUCCION)
        Me.FAMILIATableAdapter.Fill(Me.DsProducccionInforme.FAMILIA)
        Me.PRODUCTOSTableAdapter.Fill(Me.DsProducccionInforme.PRODUCTOS)
        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)
        pnlfechas.SendToBack()
        cmbProducto.Text = "%"
        cbxCategoria.Text = "%"
        cbxTipoProd.Text = "%"
        rbtAPorM.Checked = True
        CargarListaReportes()
        PintarCeldas()
    End Sub

    Private Sub FiltroReporteProduccion_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim rpt As New Reportes.ReporteBlanco
        rpt.SetParameterValue("pmtReporteName", "Reportes de Producción")
        CrystalReportViewer.ReportSource = rpt
    End Sub

    Private Sub dgvListaReportes_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvListaReportes.SelectionChanged
        PRODUCTOSBindingSource.RemoveFilter()
        Dim rpt As Reportes.ReporteBlanco
        CrystalReportViewer.ReportSource = rpt

        If pnlFiltros.Visible = False Then
            pnlFiltros.Visible = True
            pnlProducto.Location = Pos1
            pnlfechas.Location = Pos2
            pnlOtrasOpciones.Location = Pos3
            btnGenerar.Visible = True
            pnlSinFiltro.SendToBack()
        End If
        'If pnlSinFiltro.Visible = True Then
        '    pnlFiltros.Visible = True
        '    pnlFiltros.Show()
        '    pnlSinFiltro.Visible = False
        'End If
        btnGenerar.Visible = True
        PintarCeldas()
        InvisivilizarTodo()
        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "TITULO" Then
            InvisivilizarTodo()
            pnlSinFiltro.Visible = True
            pnlSinFiltro.BringToFront()
        End If

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProduccionSalidaProducto" Then
            pnlFiltros.Visible = True
            pnlFiltros.Show()
            pnlSinFiltro.Visible = False
            lblReporte.Text = "Salidas de Producción por Producto"
            lblReporteDescrip.Text = "Salidas de Producción por Producto - PRODUCCION"
            pnlProducto.Visible = True
            chbxCodProducto.Checked = False
            tbxcodProd.SendToBack()
            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2
            pnlfechas.Location = Pos3
            'pnlOtrasOpciones.Location = 
            pnlAgrupado.Location = Pos4
            btnGenerar.Visible = True
            pnlTipoProd.Visible = False
            pnlOrdenProd.Visible = False
            pnlCategorias.Visible = True
            pnlfechas.Visible = True
            pnlOtrasOpciones.Visible = True
            panelTipoProd.Visible = False

        End If

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProduccionEntradaProducto" Then
            pnlFiltros.Visible = True
            pnlFiltros.Show()
            pnlSinFiltro.Visible = False
            lblReporte.Text = "Entradas de Producción por Producto"
            lblReporteDescrip.Text = "Entradas de Producción por Producto - PRODUCCION"
            pnlProducto.Visible = True
            chbxCodProducto.Checked = False
            tbxcodProd.SendToBack()
            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2
            pnlfechas.Location = Pos3
            'pnlOtrasOpciones.Location = Pos4
            pnlAgrupado.Location = Pos4
            btnGenerar.Visible = True
            pnlTipoProd.Visible = False
            pnlOrdenProd.Visible = False
            pnlCategorias.Visible = True
            pnlfechas.Visible = True
            pnlOtrasOpciones.Visible = True
            panelTipoProd.Visible = False

        End If

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProduccionRendimientoProducto" Then
            pnlFiltros.Visible = True
            pnlFiltros.Show()
            pnlSinFiltro.Visible = False
            lblReporte.Text = "Rendimiento de Producción por Producto"
            lblReporteDescrip.Text = "Rendimiento de Producción por Producto - PRODUCCION"
            pnlProducto.Visible = True
            chbxCodProducto.Checked = False
            tbxcodProd.SendToBack()
            pnlProducto.Location = Pos1
            pnlfechas.Location = Pos2
            btnGenerar.Visible = True
            pnlTipoProd.Visible = False
            pnlOrdenProd.Visible = False
            pnlCategorias.Visible = True
            pnlfechas.Visible = True
            pnlOtrasOpciones.Visible = True
            panelTipoProd.Visible = False

        End If

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProduccionRendimientoPeriodo" Then
            pnlFiltros.Visible = True
            pnlFiltros.Show()
            pnlSinFiltro.Visible = False
            lblReporte.Text = "Rendimiento de Producción por Periodo"
            lblReporteDescrip.Text = "Rendimiento de Producción por Periodo - PRODUCCION"
            chbxCodProducto.Checked = False
            tbxcodProd.SendToBack()
            cmbProducto.BringToFront()
            pnlfechas.Location = Pos1
            btnGenerar.Visible = True
            pnlTipoProd.Visible = False
            pnlOrdenProd.Visible = False
            pnlCategorias.Visible = True
            pnlfechas.Visible = True
            pnlOtrasOpciones.Visible = True
            panelTipoProd.Visible = False

        End If
        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProduccionComparativo" Then
            pnlFiltros.Visible = True
            pnlFiltros.Show()
            pnlSinFiltro.Visible = False
            lblReporte.Text = "Comparativo de Producción por Mes/Producto"
            lblReporteDescrip.Text = "Comparativo de Producción por Mes/Producto - PRODUCCION"
            pnlCategorias.Location = Pos1
            pnlfechas.Location = Pos2
            pnlOtrasOpciones.Location = Pos3
            rbtEntrada.Checked = True
            btnGenerar.Visible = True
            pnlTipoProd.Visible = False
            pnlOrdenProd.Visible = False
            pnlCategorias.Visible = True
            pnlfechas.Visible = True
            pnlOtrasOpciones.Visible = True
            panelTipoProd.Visible = False

        End If
        'If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptOrdenProduccion" Then           XAVI
        '    pnlFiltros.Visible = True
        '    pnlFiltros.Show()
        '    panelTipoProd.Visible = True
        '    pnlTipoProd.Visible = True
        '    pnlOrdenProd.Visible = True
        '    pnlSinFiltro.Visible = False
        '    lblReporte.Text = "Ordenes de Producción"
        '    lblReporteDescrip.Text = "PRODUCCION"
        '    pnlCategorias.Visible = False
        '    pnlfechas.Visible = False
        '    pnlOtrasOpciones.Visible = False
        '    rbtEntrada.Checked = True
        '    btnGenerar.Visible = True
        'End If
    End Sub

    Private Sub verificarvacioscombo(ByVal control As System.Windows.Forms.ComboBox)
        If Trim(control.Text) = "" Then
            control.Text = "%"
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        CrystalReportViewer.ShowPageNavigateButtons = True
        CrystalReportViewer.DisplayStatusBar = True
        CrystalReportViewer.DisplayToolbar = True
        Me.Cursor = Cursors.AppStarting

        Dim desde As String = dtpFechaDesde.Value
        Dim hasta As String = dtpFechaHasta.Value
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:00"

        verificarvacioscombo(cmbProducto)

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProduccionSalidaProducto" Then
            rptProduccionSalidaProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProduccionEntradaProducto" Then
            rptProduccionEntradaProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptProduccionComparativo" Then
            rptProduccionComparativo()
            'ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptOrdenProduccion" Then
            '    rptOrdenProduccion()
        End If

        Me.Cursor = Cursors.Default
        pnlFiltros.Visible = False
    End Sub

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

    Private Sub cmbSucursal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.F12 Then
        '    cmbSucursal.Text = "%"
        '    If cmbSucursal.AccessibleName <> "True" Then
        '        marcardesmarcartodos(cmbSucursal, dtSucursal)
        '    End If
        '    cmbSucursal.Text = "%"
        'ElseIf e.KeyCode = Keys.Back And cmbSucursal.Text.Length = 1 And cmbSucursal.AccessibleName <> "False" Then
        '    marcardesmarcartodos(cmbSucursal, dtSucursal)
        'End If
    End Sub

    Private Sub cmbTipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.F12 Then
        '    If cmbTipo.AccessibleName <> "True" Then
        '        marcardesmarcartodossindt(cmbTipo)
        '    End If
        '    cmbTipo.Text = "%"
        'ElseIf e.KeyCode = Keys.Back And cmbTipo.Text.Length = 1 And cmbTipo.AccessibleName <> "False" Then
        '    marcardesmarcartodossindt(cmbTipo)
        'End If
    End Sub

    Private Sub cmbComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F12 Then
            cmbProducto.Text = "%"
            If cmbProducto.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbProducto, dtComprobante)
            End If
            cmbProducto.Text = "%"
        ElseIf e.KeyCode = Keys.Back And cmbProducto.Text.Length = 1 And cmbProducto.AccessibleName <> "False" Then
            marcardesmarcartodos(cmbProducto, dtComprobante)
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

    Private Sub BtnAsteriscoProducto_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsteriscoProducto.Click
        '................................................

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
        '................................................

    End Sub

    Private Sub ProductosGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosGridView.CellDoubleClick
        cmbProducto.Focus()
        UltraPopupControlContainer1.Close()
    End Sub

    Private Sub ProductosGridView_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ProductosGridView.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Me.PRODUCTOSBindingSource1.Position = Me.PRODUCTOSBindingSource.Position - 1
            cmbProducto.Focus()
            UltraPopupControlContainer1.Close()
        End If
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        If BuscarProductoTextBox.Text <> "Buscar..." Then
            Me.PRODUCTOSBindingSource1.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
        End If
    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProductosGridView.Focus()
        End If
        If KeyAscii = 27 Then
            cmbProducto.Text = ""
            cmbProducto.Focus()

            If ProductosGroupBox.Visible = True Then
                ProductosGroupBox.Visible = False
                ProductosGroupBox.SendToBack()
                cmbProducto.Focus()
            End If
        End If
    End Sub

    Private Sub FiltroReporteInventario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UltraPopupControlContainer1.IsDisplayed Then
                If Buscador = "Producto" Then 'Si mas adelante se agrega otro buscador, ya esta la variable para diferenciar cual esta abierto
                    BuscarProductoTextBox.Text = ""
                    cmbProducto.Focus()
                    UltraPopupControlContainer1.Close()
                End If
            End If
        End If
    End Sub

    Private Sub cmbProducto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbProducto.Text = "%"
        End If
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

    Private Sub pbxRangoProd_Click(sender As System.Object, e As System.EventArgs) Handles pbxRangoProd.Click
        If chbxCodProducto.Checked = True Then
            chbxCodProducto.Checked = False
        Else
            chbxCodProducto.Checked = True
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

    Private Sub cbxTipoProd_SelectionChanged(sender As Object, e As EventArgs) Handles cbxTipoProd.SelectionChangeCommitted
        ORDENPRODUCCIONBindingSource.Filter = "TIPOPRODUCCION ='" & cbxTipoProd.SelectedValue & "'"
    End Sub
End Class