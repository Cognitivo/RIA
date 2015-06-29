Public Class CalculoHistóricoPorProducto

    Private Sub CalculoHistóricoPorProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsInfVentas.SUCURSAL' Puede moverla o quitarla según sea necesario.
        Me.SUCURSALTableAdapter.FillBy(Me.DsInfVentas.SUCURSAL)

        Me.PRODUCTOSTableAdapter.Fill(Me.DsProductos.PRODUCTOS, "%")
        lblFecha.Text = Date.Now


    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Dim mes, anho, deposito As Integer
        Dim codigo, fecha As String
        codigo = cbxProducto.SelectedValue
        deposito = cbxDeposito.SelectedValue

        Select Case cbxMes.Text
            Case "Enero"
                mes = 1
            Case  "Febrero"
                mes = 2
            Case "Marzo"
                mes = 3
            Case "Abril"
                mes = 4
            Case "Mayo"
                mes = 5
            Case "Junio"
                mes = 6
            Case "Julio"
                mes = 7
            Case "Agosto"
                mes = 8
            Case "Septiembre"
                mes = 9
            Case "Octubre"
                mes = 10
            Case "Noviembre"
                mes = 11
            Case "Diciembre"
                mes = 12
        End Select

        anho = cbxAnho.Text

        fecha = lblFecha.Text

        Me.CalculoAjusteHistoricoTableAdapter.Fill(DsCalculoAjusteHistórico.CalculoAjusteHistorico, codigo, deposito, mes, anho, fecha)
    End Sub
End Class