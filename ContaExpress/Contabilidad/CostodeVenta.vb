Public Class CostodeVenta
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim f As New Funciones.Funciones
    Dim permiso As Double

    Private Sub CostodeVenta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 257)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            cmbAnho.SelectedText = Today.Year.ToString
            cmbMes.SelectedIndex = Today.Month - 1
            FechaFiltro()

            Try
                VENTASTableAdapter.Fill(DsCosteo.VENTAS, FechaFiltro1, FechaFiltro2)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FechaFiltro()
        Try
            Dim nromes, nroaño As Integer
            Dim fechacompleta1, fechacompleta2, mes As String
            nromes = cmbMes.SelectedIndex + 1
            nroaño = CInt(cmbAnho.Text)

            If nromes = 10 Or nromes = 11 Or nromes = 12 Then
                mes = nromes.ToString
            Else
                mes = "0" + nromes.ToString

            End If

            fechacompleta1 = "01" + "/" + nromes.ToString + "/" + cmbAnho.Text
            fechacompleta2 = ""
            If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
                fechacompleta2 = "31" + "/" + nromes.ToString + "/" + cmbAnho.Text

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

            FechaFiltro1 = CDate(fechacompleta1)
            FechaFiltro2 = CDate(fechacompleta2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvVentasCosto_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvVentasCosto.SelectionChanged
        If dgvVentasCosto.RowCount <> 0 Then
            Dim TotalVenta As Integer = CDec(lblTotalVenta.Text)
            lblTotalVenta.Text = FormatNumber(TotalVenta, 0)

            Try
                VENTASDETALLECOSTOTableAdapter.Fill(DsCosteo.VENTASDETALLECOSTO, dgvVentasCosto.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)
            Catch ex As Exception
            End Try
        Else
            VENTASDETALLECOSTOTableAdapter.Fill(DsCosteo.VENTASDETALLECOSTO, 0)
        End If
    End Sub
    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        FechaFiltro()
        VENTASTableAdapter.Fill(DsCosteo.VENTAS, FechaFiltro1, FechaFiltro2)
    End Sub
    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        VENTASBindingSource.Filter = "NUMVENTA LIKE '%" & BuscarTextBox.Text & "%' OR NOMBRECLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR RUCCLIENTE  LIKE '%" & BuscarTextBox.Text & "%'"
    End Sub
End Class