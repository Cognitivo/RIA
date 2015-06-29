Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class ComprasModificarCuotas
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim TotalSaldo, TotalAjustes As Double
    Dim permiso As Double
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Private conexion As System.Data.SqlClient.SqlConnection
    Private objCommand As New SqlCommand
    Dim sql As String

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2

    End Sub

    Private Sub ComprasModificarCuotas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 267)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If
        FechaFiltro()
        Me.ProveedorTableAdapter.Fill(Me.DsAppCompras.PROVEEDOR)

        'Asignamos Fechas
        dtpFechaDesde.Text = FechaFiltro1
        dtpFechaHasta.Text = FechaFiltro2

        btnFiltrarCuentas_Click(Nothing, Nothing)
    End Sub

    Private Sub dgvProveedor_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvProveedor.SelectionChanged
        If dgvProveedor.RowCount <> 0 Then
            lblTotalDiferencia.Text = 0 : lblTotalImporte.Text = 0 : lblTotalAjustes.Text = 0
            lblProvName.Text = dgvProveedor.CurrentRow.Cells("NOMBRE").Value
            Me.ComprasTableAdapter.Fill(Me.DsAppCompras.COMPRAS, dgvProveedor.CurrentRow.Cells("CODPROVEEDOR").Value, FechaFiltro1, FechaFiltro2)
        End If
    End Sub

    Private Sub lblVerModulo_Click(sender As System.Object, e As System.EventArgs) Handles lblVerModulo.Click
        If IsDBNull(dgvFacturas.CurrentRow.Cells("CODCOMPRA").Value) Then
        Else
            CompraPlus.COMPRASBindingSource.Filter = "CODCOMPRA = " & dgvFacturas.CurrentRow.Cells("CODCOMPRA").Value
            CompraPlus.Show()
        End If
    End Sub

    Private Sub FechaFiltro()
        Try
            Dim nromes, nroaño As Integer
            Dim fechacompleta1, fechacompleta2, mes As String

            'Obtenemos el Mes y Año actual
            nromes = Today.Month
            nroaño = Today.Year.ToString

            If nromes = 10 Or nromes = 11 Or nromes = 12 Then
                mes = nromes.ToString
            Else
                mes = "0" + nromes.ToString
            End If

            fechacompleta1 = "01" + "/" + nromes.ToString + "/" + nroaño.ToString
            fechacompleta2 = ""

            If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
                fechacompleta2 = "31" + "/" + nromes.ToString + "/" + nroaño.ToString

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

            FechaFiltro1 = CDate(fechacompleta1)
            FechaFiltro2 = CDate(fechacompleta2)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvFacturas_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvFacturas.SelectionChanged
        If dgvFacturas.RowCount <> 0 Then
            CuotasBindingSource.RemoveFilter()
            Me.FacturapagarTableAdapter.Fill(Me.DsAppCompras.FACTURAPAGAR, Me.dgvFacturas.CurrentRow.Cells("CODCOMPRA").Value, FechaFiltro1, FechaFiltro2)
            recorredetalle()
        Else
            Me.CuotasBindingSource.Filter = "numerocuota = 0"
        End If
    End Sub

    Private Sub recorredetalle()
        TotalSaldo = 0
        For i = 0 To dgvCuotas.Rows.Count - 1
            dgvCuotas.Rows(i).Cells("AJUSTE").Value = dgvCuotas.Rows(i).Cells("IMPORTECUOTA").Value
            dgvCuotas.Rows(i).Cells("NVONROCUOTA").Value = dgvCuotas.Rows(i).Cells("NUMEROCUOTA").Value
            TotalSaldo = TotalSaldo + dgvCuotas.Rows(i).Cells("IMPORTECUOTA").Value
        Next
        lblTotalImporte.Text = TotalSaldo
        lblTotalImporte.Text = FormatNumber(CDec(lblTotalImporte.Text), 2)
        lblTotalAjustes.Text = TotalSaldo
        lblTotalAjustes.Text = FormatNumber(CDec(lblTotalAjustes.Text), 2)
    End Sub

    Private Sub calculatotales()
        TotalAjustes = 0
        For i = 0 To dgvCuotas.Rows.Count - 1
            If dgvCuotas.Rows(i).Cells("EstadoFila").Value <> "D" Then
                TotalAjustes = TotalAjustes + dgvCuotas.Rows(i).Cells("AJUSTE").Value
            End If
        Next
        lblTotalAjustes.Text = TotalAjustes
        lblTotalAjustes.Text = FormatNumber(CDec(lblTotalAjustes.Text), 2)

        'Calculamos la diferencia
        Dim Diferencia As Double = CDec(lblTotalImporte.Text) - CDec(lblTotalAjustes.Text)
        lblTotalDiferencia.Text = FormatNumber(CDec(Diferencia), 2)

        If Diferencia = 0 Then
            btAplicarCambios.Enabled = True
        Else
            btAplicarCambios.Enabled = False
        End If
    End Sub

    Private Sub BorraDetalle()
        Dim C As Integer = 0

        Dim NroCuota As Integer = 0
        For i = 0 To dgvCuotas.RowCount - 1
            If dgvCuotas.Rows(i).Cells("EstadoFila").Value = "D" Then
                lblTotalAjustes.Text = CDec(lblTotalAjustes.Text) - dgvCuotas.Rows(i).Cells("AJUSTE").Value
                lblTotalAjustes.Text = FormatNumber(CDec(lblTotalAjustes.Text), 2)
                dgvCuotas.Rows(i).Cells("NVONROCUOTA").Value = "A Eliminar"
                dgvCuotas.Rows(i).Cells("IMPORTECUOTA").Value = dgvCuotas.Rows(i).Cells("IMPORTECUOTA").Value
                dgvCuotas.Rows(i).Cells("AJUSTE").Value = dgvCuotas.Rows(i).Cells("AJUSTE").Value
                For C = 0 To dgvCuotas.ColumnCount - 1
                    dgvCuotas.Item(C, dgvCuotas.CurrentRow.Index).Style.BackColor = Color.Pink
                Next
            Else
                NroCuota = NroCuota + 1
                dgvCuotas.Rows(i).Cells("NVONROCUOTA").Value = NroCuota
            End If
        Next
    End Sub

    Private Function recorreMontosModif() As Integer
        Dim TotalMontosModif As Double
        For i = 0 To dgvCuotas.Rows.Count - 1
            If dgvCuotas.Rows(i).Cells("EstadoFila").Value <> "D" Then
                TotalMontosModif = TotalMontosModif + dgvCuotas.Rows(i).Cells("AJUSTE").Value
            End If
        Next
        If TotalMontosModif = TotalSaldo Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Private Sub btnFiltrarCuentas_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrarCuentas.Click
        FechaFiltro1 = dtpFechaDesde.Text & " 00:00:00"
        FechaFiltro2 = dtpFechaHasta.Text & " 23:59:59"
        Me.ComprasTableAdapter.Fill(Me.DsAppCompras.COMPRAS, dgvProveedor.CurrentRow.Cells("CODPROVEEDOR").Value, FechaFiltro1, FechaFiltro2)
    End Sub

    Private Sub btAplicarCambios_Click(sender As System.Object, e As System.EventArgs) Handles btAplicarCambios.Click
        Dim ok As Integer = recorreMontosModif()
        If ok = 1 Then
            Try
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                Try
                    actualizarcuotas(myTrans)
                    myTrans.Commit()

                    MessageBox.Show("Operación Finalizada con éxito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvFacturas_SelectionChanged(Nothing, Nothing)
                Catch ex As Exception
                    Try
                        myTrans.Rollback("Actualizar")
                    Catch
                    End Try

                    Throw ex
                End Try

            Catch ex As Exception
                MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("La Suma de los Montos Ajustados No coincide con el Total Importe. Favor verifique de nuevo los Ajustes", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub actualizarcuotas(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String
        conexion = ser.Abrir()

        For i = 0 To dgvCuotas.Rows.Count - 1
            Dim ajuste As String
            ajuste = dgvCuotas.Rows(i).Cells("AJUSTE").Value
            ajuste = Funciones.Cadenas.QuitarCad(ajuste, ".")
            ajuste = Replace(ajuste, ",", ".")

            Dim tipofactura As String = ""
            If dgvFacturas.CurrentRow.Cells("MODALIDADPAGO").Value = 0 Then
                tipofactura = "CONTADO"
            Else
                tipofactura = "CREDITO"
            End If

            Dim hora, Fecha, FechaHoraNvo As String

            sql = ""

            If dgvCuotas.Rows(i).Cells("EstadoFila").Value = "D" Then
                sql = " DELETE FACTURAPAGAR WHERE NUMEROCUOTA= " & dgvCuotas.Rows(i).Cells("NUMEROCUOTA").Value & " AND CODCOMPRA= " & dgvCuotas.Rows(i).Cells("CODCOMPRACUOTA").Value
            ElseIf dgvCuotas.Rows(i).Cells("EstadoFila").Value = "I" Then
                hora = Now.ToString("HH:mm:ss")
                Fecha = Format(dgvCuotas.Rows(i).Cells("FECHAVCTO").Value, "dd/MM/yyy")
                FechaHoraNvo = Fecha & " " + hora
                sql = " INSERT INTO FACTURAPAGAR (NUMEROCUOTA,CODUSUARIO,CODEMPRESA,CODCOMPRA,FECHAVCTO,SALDOCUOTA,IMPORTECUOTA,FECGRA,PAGADO,TIPOFACTURA) " & _
                        "VALUES (" & dgvCuotas.Rows(i).Cells("NVONROCUOTA").Value & "," & UsuCodigo & "," & EmpCodigo & "," & dgvCuotas.Rows(i).Cells("CODCOMPRACUOTA").Value & ", CONVERT(DATETIME,'" & FechaHoraNvo & "',103)," & ajuste & "," & ajuste & ", getdate(),0,'" & tipofactura & "')"
            Else
                hora = Now.ToString("HH:mm:ss")
                Fecha = Format(dgvCuotas.Rows(i).Cells("FECHAVCTO").Value, "dd/MM/yyy")
                FechaHoraNvo = Fecha & " " + hora
                sql = " UPDATE FACTURAPAGAR SET FECHAVCTO=CONVERT(DATETIME,'" & FechaHoraNvo & "',103), IMPORTECUOTA=" & ajuste & ", SALDOCUOTA=" & ajuste & ", NUMEROCUOTA= " & dgvCuotas.Rows(i).Cells("NVONROCUOTA").Value & " WHERE NUMEROCUOTA= " & dgvCuotas.Rows(i).Cells("NUMEROCUOTA").Value & " AND CODCOMPRA= " & dgvCuotas.Rows(i).Cells("CODCOMPRACUOTA").Value
            End If

            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            Consultas.ConsultaComando(myTrans, sql)
            myTrans.Commit()
        Next
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        If tbxMonto.Text = "" Then
            MessageBox.Show("Ingrese un Monto para la Cuota", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxMonto.Focus()
            Exit Sub
        End If

        CuotasBindingSource.AddNew()
        Dim c As Integer = dgvCuotas.RowCount
        Dim nrocuota As Integer = 0

        For i = 0 To dgvCuotas.RowCount - 1
            If IsDBNull(dgvCuotas.Rows(i).Cells("EstadoFila").Value) Then
                nrocuota = nrocuota + 1
            ElseIf dgvCuotas.Rows(i).Cells("EstadoFila").Value <> "D" Then
                nrocuota = nrocuota + 1
            End If
        Next

        dgvCuotas.Rows(c - 1).Cells("NVONROCUOTA").Value = nrocuota
        dgvCuotas.Rows(c - 1).Cells("NUMEROCUOTA").Value = nrocuota
        dgvCuotas.Rows(c - 1).Cells("CODCOMPRACUOTA").Value = dgvFacturas.CurrentRow.Cells("CODCOMPRA").Value
        dgvCuotas.Rows(c - 1).Cells("FECHAVCTO").Value = dtpFechaVto.Value
        dgvCuotas.Rows(c - 1).Cells("IMPORTECUOTA").Value = CDec(tbxMonto.Text)
        dgvCuotas.Rows(c - 1).Cells("SALDOCUOTA").Value = CDec(tbxMonto.Text)
        dgvCuotas.Rows(c - 1).Cells("AJUSTE").Value = CDec(tbxMonto.Text)
        dgvCuotas.Rows(c - 1).Cells("PAGADO").Value = 0
        dgvCuotas.Rows(c - 1).Cells("EstadoFila").Value = "I"

        lblTotalAjustes.Text = CDec(lblTotalAjustes.Text) + CDec(tbxMonto.Text)
        lblTotalAjustes.Text = FormatNumber(CDec(lblTotalAjustes.Text), 2)
        tbxMonto.Text = "" : dtpFechaVto.Focus()
        calculatotales()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        dgvCuotas.CurrentRow.Cells("EstadoFila").Value = "D"
        BorraDetalle()
        calculatotales()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        dgvFacturas_SelectionChanged(Nothing, Nothing)
        tbxMonto.Text = ""
        lblTotalDiferencia.Text = 0
    End Sub

    Private Sub dgvCuotas_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuotas.CellEndEdit
        If dgvCuotas.CurrentCellAddress.X = 8 Then
            calculatotales()
        End If
    End Sub

    Private Sub dtpFechaVto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaVto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxMonto.Focus()
        End If
    End Sub

    Private Sub tbxMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxMonto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnNuevo.Focus()
        End If
    End Sub

    Private Sub BuscarCompraTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarCompraTextBox.TextChanged
        Try
            Me.ProveedorBindingSource.Filter = "NOMBRE LIKE '%" & BuscarCompraTextBox.Text & "%' OR RUC_CIN LIKE '%" & BuscarCompraTextBox.Text & "%'"
        Catch ex As Exception
        End Try
    End Sub
End Class