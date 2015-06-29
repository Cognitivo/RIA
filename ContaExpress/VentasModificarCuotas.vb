Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class VentasModificarCuotas
    Dim TotalSaldo, TotalCobrar, Diferencia As Double
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
        permiso = PermisoAplicado(UsuCodigo, 284)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        Me.CLIENTESTableAdapter.Fill(Me.DsAppModVentas.CLIENTES)
        Me.VENTASTableAdapter.Fill(Me.DsAppModVentas.VENTAS, Nothing)
        CamposDeshabilitados()
    End Sub

    Private Sub recorrerdgvProveedor()
        TotalCobrar = 0
        If dgvFacturasCuotas.RowCount <> 0 Then
            For rowDetail = 0 To dgvFacturasCuotas.Rows.Count - 1
                dgvFacturasCuotas.Rows(rowDetail).Cells("AJUSTE").Value = dgvFacturasCuotas.Rows(rowDetail).Cells("IMPORTECUOTA").Value
                dgvFacturasCuotas.Rows(rowDetail).Cells("NVONROCUOTA").Value = dgvFacturasCuotas.Rows(rowDetail).Cells("CODNUMEROCUOTA").Value
                TotalCobrar = TotalCobrar + dgvFacturasCuotas.Rows(rowDetail).Cells("SALDOCUOTA").Value
            Next
            tbxTotalCobrar.Text = FormatNumber(CDec(TotalCobrar), 2)
        End If
    End Sub

    Private Sub recorrerdgvFacturasCuotas()
        TotalSaldo = 0
        Diferencia = 0
        Dim TotalSaldoFact As Double = 0
        If dgvFacturasCuotas.RowCount <> 0 Then
            For rowDetail = 0 To dgvFacturasCuotas.Rows.Count - 1
                If dgvFacturasCuotas.Rows(rowDetail).Cells("EstadoFila").Value <> "D" Then
                    dgvFacturasCuotas.Rows(rowDetail).Cells("AJUSTE").Value = dgvFacturasCuotas.Rows(rowDetail).Cells("SALDOCUOTA").Value
                    dgvFacturasCuotas.Rows(rowDetail).Cells("NVONROCUOTA").Value = dgvFacturasCuotas.Rows(rowDetail).Cells("CODNUMEROCUOTA").Value
                    TotalSaldo = TotalSaldo + dgvFacturasCuotas.Rows(rowDetail).Cells("AJUSTE").Value
                    'End If
                End If
            Next
            Diferencia = TotalCobrar - TotalSaldo

            For Each Row As DataRow In DsAppModVentas.FACTURACOBRAR.Select("CODVENTA=" & dgvFacturasCuotas.CurrentRow.Cells("CODVENTA").Value)
                If dgvFacturasCuotas.CurrentRow.Cells("EstadoFila").Value Is Nothing Then
                    TotalSaldoFact = TotalSaldoFact + Row("SALDOCUOTA")
                End If
            Next
            lblValorActual.Text = TotalSaldoFact

            tbxTotalCobrar.Text = FormatNumber(CDec(TotalCobrar), 2)
            tbxSumaSaldos.Text = FormatNumber(CDec(TotalSaldo), 2)
            lblTotalDiferencia.Text = FormatNumber(CDec(Diferencia), 2)

            If Diferencia >= 1 Then
                btAplicarCambios.Enabled = False
            Else
                btAplicarCambios.Enabled = True
            End If
        End If
    End Sub

    Private Sub BorraDetalle()
        Dim C As Integer

        For i = 0 To dgvFacturasCuotas.RowCount - 1
            If dgvFacturasCuotas.Rows(i).Cells("EstadoFila").Value = "D" Then

                TotalSaldo = TotalSaldo - dgvFacturasCuotas.Rows(i).Cells("AJUSTE").Value
                Diferencia = TotalCobrar - TotalSaldo

                tbxSumaSaldos.Text = FormatNumber(CDec(TotalSaldo), 2)
                lblTotalDiferencia.Text = FormatNumber(CDec(Diferencia), 2)


                For C = 0 To dgvFacturasCuotas.ColumnCount - 1
                    dgvFacturasCuotas.Item(C, dgvFacturasCuotas.CurrentRow.Index).Style.BackColor = Color.Pink
                Next
            End If
        Next
    End Sub

    Public Sub dgvCuotas_selectionChanged() Handles dgvFacturasCuotas.SelectionChanged

        If dgvFacturasCuotas.RowCount = 0 Then
            Exit Sub
        Else
            
            lblValorFactura.Text = dgvFacturasCuotas.CurrentRow.Cells("NUMVENTA").Value
            VENTASTableAdapter.Fill(Me.DsAppModVentas.VENTAS, dgvProveedor.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value)
            recorrerdgvFacturasCuotas()
        End If
    End Sub

    Sub CamposDeshabilitados()
        lblNuevoMonto.Enabled = True
        lblNuevoMonto.Visible = True
        tbxNuevoMonto.Enabled = True
        tbxNuevoMonto.Visible = True
        lblFechaVencimiento.Enabled = True
        lblFechaVencimiento.Visible = True
        dtpFechaVto.Enabled = True
        dtpFechaVto.Visible = True
        lblListaFactura.Enabled = True
        lblListaFactura.Visible = True
        cbxListadoFactura.Visible = True

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
                    'dgvFacturas_SelectionChanged(Nothing, Nothing)
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
            dgvFacturas_SelectionChanged(Nothing, Nothing)
        Else
            MessageBox.Show("La Suma de los Montos Ajustados No coincide con el Total Importe. Favor verifique de nuevo los Ajustes", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub actualizarcuotas(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String
        conexion = ser.Abrir()

        For i = 0 To dgvFacturasCuotas.Rows.Count - 1
            Dim ajuste As String
            ajuste = dgvFacturasCuotas.Rows(i).Cells("AJUSTE").Value
           
            ajuste = Funciones.Cadenas.QuitarCad(ajuste, ".")
            ajuste = Replace(ajuste, ",", ".")

            Dim tipofactura As String = ""

            Dim Fecha, FechaHoraNvo As String

            sql = ""

            If dgvFacturasCuotas.Rows(i).Cells("EstadoFila").Value = "D" Then
                sql = " DELETE FACTURACOBRAR WHERE IDFORMACOBRAR = " & dgvFacturasCuotas.Rows(i).Cells("IDFORMACOBRAR").Value

            ElseIf dgvFacturasCuotas.Rows(i).Cells("EstadoFila").Value = "I" Then

                Fecha = Format(dgvFacturasCuotas.Rows(i).Cells("FECHAVCTO").Value, "dd/MM/yyy")
                FechaHoraNvo = Fecha & " " '+ hora
                sql = " INSERT INTO FACTURACOBRAR (CODNUMEROCUOTA,CODUSUARIO,CODVENTA,FECHAVCTO,SALDOCUOTA,IMPORTECUOTA,FECGRA,PAGADO,TIPOFACTURA)  " & _
                        "VALUES ('" & dgvFacturasCuotas.Rows(i).Cells("NVONROCUOTA").Value & "','" & UsuCodigo & "','" & dgvFacturasCuotas.Rows(i).Cells("CODVENTA").Value & "', CONVERT(DATETIME,'" & FechaHoraNvo & "',103)," & ajuste & "," & ajuste & ", getdate(),0,'" & tipofactura & "')"

            Else

                Fecha = Format(dgvFacturasCuotas.Rows(i).Cells("FECHAVCTO").Value, "dd/MM/yyy")
                FechaHoraNvo = Fecha & " " '+ hora
                sql = " UPDATE FACTURACOBRAR SET FECHAVCTO = CONVERT(DATETIME,'" & FechaHoraNvo & "',103), IMPORTECUOTA = " & ajuste & ", SALDOCUOTA = " & ajuste & ", CODNUMEROCUOTA = " & dgvFacturasCuotas.Rows(i).Cells("NVONROCUOTA").Value & " WHERE IDFORMACOBRAR = " & dgvFacturasCuotas.Rows(i).Cells("IDFORMACOBRAR").Value
            End If

            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            Consultas.ConsultaComando(myTrans, sql)
            myTrans.Commit()
        Next
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click


        If lblTotalDiferencia.Text < tbxNuevoMonto.Text Then
            MessageBox.Show("Monto Superior al Saldo de la factura")
            Exit Sub
        Else
            If cbxListadoFactura.Text <> dgvFacturasCuotas.CurrentRow.Cells("NUMVENTA").Value Then
                MessageBox.Show("Las factura a la cual desea agregar la cuota es distinta a la que está seleccionada, por favor seleccione la correcta")
                Exit Sub
            Else
                FACTURACOBRARBindingSource.AddNew()
                Dim c As Integer = dgvFacturasCuotas.RowCount
                Dim nrocuota As Integer = 0

                For rowDetail = 0 To dgvFacturasCuotas.RowCount - 1
                    If IsDBNull(dgvFacturasCuotas.Rows(rowDetail).Cells("EstadoFila").Value) Then
                        nrocuota = nrocuota + 1
                    ElseIf dgvFacturasCuotas.Rows(rowDetail).Cells("EstadoFila").Value <> "D" Then
                        nrocuota = nrocuota + 1
                    End If
                Next

                dgvFacturasCuotas.Rows(c - 1).Cells("IDFORMACOBRAR").Value = c
                dgvFacturasCuotas.Rows(c - 1).Cells("CODNUMEROCUOTA").Value = nrocuota
                dgvFacturasCuotas.Rows(c - 1).Cells("FECHAVCTO").Value = dtpFechaVto.Value
                dgvFacturasCuotas.Rows(c - 1).Cells("IMPORTECUOTA").Value = CDec(tbxNuevoMonto.Text)
                dgvFacturasCuotas.Rows(c - 1).Cells("SALDOCUOTA").Value = CDec(tbxNuevoMonto.Text)
                dgvFacturasCuotas.Rows(c - 1).Cells("AJUSTE").Value = CDec(tbxNuevoMonto.Text)
                dgvFacturasCuotas.Rows(c - 1).Cells("EstadoFila").Value = "I"
                dgvFacturasCuotas.Rows(c - 1).Cells("NUMVENTA").Value = cbxListadoFactura.Text
                dgvFacturasCuotas.Rows(c - 1).Cells("CODVENTA").Value = cbxListadoFactura.SelectedValue

                tbxNuevoMonto.Text = "" : cbxListadoFactura.SelectedItem = Nothing : dtpFechaVto.Focus()

                recorrerdgvFacturasCuotas()

            End If
        End If

        'nueva cuota
        'FACTURACOBRARBindingSource.AddNew()
        'Dim c As Integer = dgvFacturasCuotas.RowCount
        'Dim nrocuota As Integer = 0

        'For rowDetail = 0 To dgvFacturasCuotas.RowCount - 1
        '    If IsDBNull(dgvFacturasCuotas.Rows(rowDetail).Cells("EstadoFila").Value) Then
        '        nrocuota = nrocuota + 1
        '    ElseIf dgvFacturasCuotas.Rows(rowDetail).Cells("EstadoFila").Value <> "D" Then
        '        nrocuota = nrocuota + 1
        '    End If
        'Next

        'dgvFacturasCuotas.Rows(c - 1).Cells("IDFORMACOBRAR").Value = c
        'dgvFacturasCuotas.Rows(c - 1).Cells("CODNUMEROCUOTA").Value = nrocuota
        'dgvFacturasCuotas.Rows(c - 1).Cells("FECHAVCTO").Value = dtpFechaVto.Value
        'dgvFacturasCuotas.Rows(c - 1).Cells("IMPORTECUOTA").Value = CDec(tbxNuevoMonto.Text)
        'dgvFacturasCuotas.Rows(c - 1).Cells("SALDOCUOTA").Value = CDec(tbxNuevoMonto.Text)
        'dgvFacturasCuotas.Rows(c - 1).Cells("AJUSTE").Value = CDec(tbxNuevoMonto.Text)
        'dgvFacturasCuotas.Rows(c - 1).Cells("EstadoFila").Value = "I"
        'dgvFacturasCuotas.Rows(c - 1).Cells("NUMVENTA").Value = cbxListadoFactura.Text
        'dgvFacturasCuotas.Rows(c - 1).Cells("CODVENTA").Value = cbxListadoFactura.SelectedValue

        'tbxNuevoMonto.Text = "" : cbxListadoFactura.SelectedItem = Nothing : dtpFechaVto.Focus()

        'recorrerdgvFacturasCuotas()
    End Sub



    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click

        dgvFacturasCuotas.CurrentRow.Cells("EstadoFila").Value = "D"
        BorraDetalle()
        recorrerdgvFacturasCuotas()

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        dgvFacturas_SelectionChanged(Nothing, Nothing)
        lblTotalDiferencia.Text = 0
    End Sub


    Private Sub dtpFechaVto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaVto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
        End If
    End Sub

    Private Sub tbxMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnNuevo.Focus()
        End If
    End Sub

    Private Sub BuscarCompraTextBox_TextChanged(sender As Object, e As EventArgs) Handles BuscarCompraTextBox.TextChanged
        CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & BuscarCompraTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarCompraTextBox.Text & "%'"
    End Sub

    Private Sub dgvProveedor_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProveedor.SelectionChanged
        If dgvProveedor.RowCount <> 0 Then
            lblTotalDiferencia.Text = 0 : tbxTotalCobrar.Text = 0 : tbxSumaSaldos.Text = 0
            lblProvName.Text = dgvProveedor.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value & " - " & dgvProveedor.CurrentRow.Cells("NOMBREFANTASIADataGridViewTextBoxColumn").Value
            Me.FACTURACOBRARTableAdapter.Fill(Me.DsAppModVentas.FACTURACOBRAR, dgvProveedor.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value)
            VENTASBindingSource.Filter = "CODCLIENTE =" & dgvProveedor.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value
            recorrerdgvProveedor()
            recorrerdgvFacturasCuotas()
        End If
    End Sub

#Region "Desechados Comentados"

    Private Sub dgvFacturas_SelectionChanged(sender As Object, e As EventArgs)
        If dgvFacturasCuotas.RowCount <> 0 Then
            FACTURACOBRARBindingSource.RemoveFilter()
            FACTURACOBRARTableAdapter.Fill(Me.DsAppModVentas.FACTURACOBRAR, Me.dgvProveedor.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value)
            recorrerdgvFacturasCuotas()
        Else
            Me.FACTURACOBRARBindingSource.Filter = "CODNUMEROCUOTA = 0"
        End If
    End Sub

    Private Function recorreMontosModif() As Integer
        Dim TotalMontosModif As Double
        For i = 0 To dgvFacturasCuotas.Rows.Count - 1
            If dgvFacturasCuotas.Rows(i).Cells("EstadoFila").Value <> "D" Then
                TotalMontosModif = TotalMontosModif + dgvFacturasCuotas.Rows(i).Cells("AJUSTE").Value
            End If
        Next
        TotalMontosModif = Math.Round(TotalMontosModif, 2)
        TotalSaldo = Math.Round(TotalSaldo, 2)

        If TotalMontosModif = TotalSaldo Then
            Return 1
        Else
            Return 0
        End If
    End Function
#End Region

End Class