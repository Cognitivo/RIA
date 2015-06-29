Public Class ImpEtiquetas
    Dim FechaFiltro1, FechaFiltro2 As Date

    Private Sub ImpEtiquetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbAño.SelectedText = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1

        FechaFiltro()
        Me.ORDENPRODUCCIONTableAdapter.Fill(DsOrdProduccion.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2)
        Me.OPDETALLETableAdapter.Fill(DsOrdProduccion.OPDETALLE)
    End Sub

    Sub FechaFiltro()
        Dim nromes, nroaño As Integer
        Dim fechacompleta1, fechacompleta2, mes As String

        nromes = CmbMes.SelectedIndex + 1
        nroaño = CInt(CmbAño.Text)

        If nromes = 10 Or nromes = 11 Or nromes = 12 Then
            mes = nromes.ToString
        Else
            mes = "0" + nromes.ToString
        End If

        fechacompleta1 = "01" + "/" + nromes.ToString + "/" + CmbAño.Text
        fechacompleta2 = ""
        If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
            fechacompleta2 = "31" + "/" + nromes.ToString + "/" + CmbAño.Text

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
    End Sub

    Private Sub BtnFiltro_Click(sender As Object, e As EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Me.ORDENPRODUCCIONTableAdapter.Fill(DsOrdProduccion.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2)
        Me.OPDETALLETableAdapter.Fill(DsOrdProduccion.OPDETALLE)
    End Sub

    Private Sub dgwOrdenProduccion_SelectionChanged(sender As Object, e As EventArgs) Handles dgwOrdenProduccion.SelectionChanged
        Dim Total As Integer = 0
        If OPDETALLEDataGridView.Rows.Count <> 0 Then
            For i = 0 To OPDETALLEDataGridView.Rows.Count - 1
                Total = Total + CDec(OPDETALLEDataGridView.Rows(i).Cells("DataGridViewTextBoxColumn5").Value)
            Next
        End If
        tbxTotal.Text = FormatNumber(Total, 2)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If rbnProductosTerminados.Checked = True Then
            ImpProducto()
        End If
    End Sub

    Private Sub ImpProducto()
        Dim vEanCode As New EanCode
        Dim informe = New Reportes.EtiquetasProductos
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim x, cant As Integer
        Dim tamanho As Integer
        Dim codigo As String

        Dim dtCodigodeBarra As New DataTable
        dtCodigodeBarra.Columns.Add("Codigo")
        dtCodigodeBarra.Columns.Add("Fecha")
        dtCodigodeBarra.Columns.Add("Cliente")
        dtCodigodeBarra.Columns.Add("Litografia")
        dtCodigodeBarra.Columns.Add("Medida")
        dtCodigodeBarra.Columns.Add("Cantidad")

        For i = 0 To OPDETALLEDataGridView.Rows.Count - 1
            Dim CodigoFormateado As String
            Dim IsChecked As Integer = OPDETALLEDataGridView.Rows(i).Cells("Marcar").Value

            If (IsChecked = -1) Or (IsChecked = 1) Then
                codigo = dgwOrdenProduccion.CurrentRow.Cells("CODIGOLOTEDataGridViewTextBoxColumn").Value
                tamanho = codigo.Length

                If (tamanho < 12) Then
                Else
                    cant = CDec(tbxCantEtiquetas.Text)
                    For x = 0 To cant - 1
                        Dim dr As DataRow = dtCodigodeBarra.NewRow
                        dr("Fecha") = dgwOrdenProduccion.CurrentRow.Cells("FECHADataGridViewTextBoxColumn").Value
                        dr("Cliente") = OPDETALLEDataGridView.Rows(i).Cells("NOMBRE").Value
                        dr("Cantidad") = OPDETALLEDataGridView.Rows(i).Cells("Cantidad_Lote").Value
                        dr("Litografia") = OPDETALLEDataGridView.Rows(i).Cells("DESLINEA").Value
                        dr("Medida") = OPDETALLEDataGridView.Rows(i).Cells("DESFAMILIA").Value

                        CodigoFormateado = vEanCode.EAN13(codigo)
                        dr("Codigo") = CodigoFormateado

                        dtCodigodeBarra.Rows.Add(dr)
                        dtCodigodeBarra.AcceptChanges()
                    Next
                End If
            End If
        Next

        informe.SetDataSource(informes.InfEtiquetasProdcutos(dtCodigodeBarra))
        frm.CrystalReportViewer1.ReportSource = informe
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub cbxMarcarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMarcarTodos.CheckedChanged
        If cbxMarcarTodos.Checked = True Then
            If OPDETALLEDataGridView.Rows.Count <> 0 Then
                For i = 0 To OPDETALLEDataGridView.Rows.Count - 1
                    OPDETALLEDataGridView.Rows(i).Cells("Marcar").Value = 1
                Next
            End If
        ElseIf cbxMarcarTodos.Checked = False Then
            If OPDETALLEDataGridView.Rows.Count <> 0 Then
                For i = 0 To OPDETALLEDataGridView.Rows.Count - 1
                    OPDETALLEDataGridView.Rows(i).Cells("Marcar").Value = 0
                Next
            End If
        End If
    End Sub
End Class