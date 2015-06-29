Imports BDConexión
Imports System.Data.SqlClient

Public Class ReporteFlujoCaja
    Private Sub FiltrarPorFechas_Click(sender As System.Object, e As System.EventArgs) Handles FiltrarPorFechas.Click
        Dim Reporte As New Reportes.InformeFlujoCaja
        Dim rpt As New Reportes.InformeFlujoCaja

        Me.FlujodeCajaTableAdapter.Fill(Me.DsFlujoCaja.FlujodeCaja, dtpFechaDesde.Value, dtpFechaHasta.Value)
        rpt.SetDataSource([DsFlujoCaja])

        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub ReporteFlujoCaja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)
    End Sub
End Class