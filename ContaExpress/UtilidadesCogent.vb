Public Class UtilidadesCogent

    Private Sub PbxModificarCuotas_Click(sender As System.Object, e As System.EventArgs) Handles PbxModificarCuotas.Click
        ComprasModificarCuotas.Show()
    End Sub

    Private Sub pbxRetencion_Click(sender As System.Object, e As System.EventArgs) Handles pbxRetencion.Click
        ComprasRetencion.Show()
    End Sub

    Private Sub pbxCostoFifo_Click(sender As System.Object, e As System.EventArgs) Handles pbxCostoFifo.Click
        ABMCalculoFifo.Show()
    End Sub

    Private Sub UtilidadesCogent_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If TraerPanelUtilidades = "Compras" Then
            pnlCompras.BringToFront()
        ElseIf TraerPanelUtilidades = "Stock" Then
            pnlStock.BringToFront()
        ElseIf TraerPanelUtilidades = "Contabilidad" Then
            pnlContabilidad.BringToFront()
        ElseIf TraerPanelUtilidades = "Ventas" Then
            pnlVentas.BringToFront()
        End If
    End Sub

    Private Sub pbxAjusteAutomStock_Click(sender As System.Object, e As System.EventArgs) Handles pbxAjusteAutomStock.Click
        AjusteHistoricoStock.Show()
    End Sub

    Private Sub btnCostoVenta_Click(sender As System.Object, e As System.EventArgs) Handles btnCostoVenta.Click
        CostodeVenta.Show()
        Me.Cursor = Cursors.Arrow
        CostodeVenta.Opacity = 1
    End Sub

    Private Sub btnReasentar_Click(sender As System.Object, e As System.EventArgs) Handles btnReasentar.Click
        frmReAsentar.Show()
        Me.Cursor = Cursors.Arrow
        frmReAsentar.Opacity = 1
    End Sub

    Private Sub pbxHistoricoStock_Click(sender As System.Object, e As System.EventArgs) Handles pbxHistoricoStock.Click
        GenerarHistoricoStock.Show()
    End Sub

    Private Sub btnSerie_Click(sender As Object, e As EventArgs) Handles btnSerie.Click
        Producto_Serie.Show()
    End Sub

    Private Sub pbxModCuotasVentas_Click(sender As Object, e As EventArgs) Handles pbxModCuotasVentas.Click
        VentasModificarCuotas.Show()
        Me.Cursor = Cursors.Arrow
        VentasModificarCuotas.Opacity = 1
    End Sub

    Private Sub btnCodigos_Click(sender As Object, e As EventArgs) Handles btnCodigos.Click
        UpdateBarCode.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CalculoHistóricoPorProducto.Show()
    End Sub

    Private Sub btnOrdenarAsientoPorPeriodo_Click(sender As Object, e As EventArgs) Handles btnOrdenarAsientoPorPeriodo.Click
        ABMOrdenarAsientoPeriodo.Show()
        Me.Cursor = Cursors.Arrow
        ABMOrdenarAsientoPeriodo.Opacity = 1
    End Sub

    Private Sub btnOrdenarAsientosPorMes_Click(sender As Object, e As EventArgs) Handles btnOrdenarAsientosPorMes.Click
        ABMOrdenarAsientoPorMes.Show()
        Me.Cursor = Cursors.Arrow
        ABMOrdenarAsientoPorMes.Opacity = 1
    End Sub
End Class