Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Public Class ABMOrdenarAsientoPeriodo

    Private Sub btnOrdenarPeriodo_Click(sender As Object, e As EventArgs) Handles btnOrdenarPeriodo.Click
        Me.Cursor = Cursors.AppStarting
        Dim periodo As Integer = CmbPeriodo.SelectedValue
        Try
            Me.OrdenarAsientoPeriodoTableAdapter.Fill(DsOrdenarAsientoPeriodo.OrdenarAsientoPeriodo, periodo)
            MessageBox.Show("Proceso Finalizado con Exito", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Se Produjo un Error al momento de Ordenar", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ABMOrdenarAsientoPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsPeriodosFiscales.periodofiscal' Puede moverla o quitarla según sea necesario.
        Me.PeriodofiscalTableAdapter.Fill(Me.DsPeriodosFiscales.periodofiscal)

    End Sub
End Class