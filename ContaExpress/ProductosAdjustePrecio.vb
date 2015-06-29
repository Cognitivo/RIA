Imports System.Data.SqlClient

Public Class ProductosAdjustePrecio
    Private sql As String
    Private sqlc As New SqlConnection
    Private myTrans As SqlTransaction
    Private cmd As New SqlCommand
    Private ser As New BDConexión.BDConexion

    Private Sub ProductosAdjustePrecio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.RUBROTableAdapter.Fill(Me.DsProductos.RUBRO)
        Me.LINEATableAdapter.Fill(Me.DsProductos.LINEA)
        Me.FAMILIATableAdapter.Fill(Me.DsProductos.FAMILIA)

        Try
            Me.TIPOCLIENTETableAdapter.Fill(Me.DsProductos.TIPOCLIENTE)
            Me.PRODUCTOAjustePrecioTableAdapter.Fill(Me.DsProductos.PRODUCTOAjustePrecio, "%")
            lblPorcentajeCambio.Text = "%"
            Dim CodTipoCliente As String = dgvListaPrecio.CurrentRow.Cells("DESTIPOCLIENTE").Value
            Me.PRODUCTOAjustePrecioTableAdapter.Fill(Me.DsProductos.PRODUCTOAjustePrecio, CodTipoCliente)
            For i = 0 To dgvPrecios.RowCount - 1
                dgvPrecios.Rows(i).Cells("PRECIOVENTA").Value = 0

            Next
            cbxMarcar.Checked = False
          
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgvListaPrecio_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvListaPrecio.SelectionChanged
        Dim CodTipoCliente As String = dgvListaPrecio.CurrentRow.Cells("DESTIPOCLIENTE").Value
        Me.PRODUCTOAjustePrecioTableAdapter.Fill(Me.DsProductos.PRODUCTOAjustePrecio, CodTipoCliente)

        For i = 0 To dgvPrecios.RowCount - 1
            dgvPrecios.Rows(i).Cells("PRECIOVENTA").Value = 0

        Next
    End Sub

    Private Sub btnPreVisualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnPreVisualizar.Click
        Try

       
        Dim Ajuste As Double
            Ajuste = CDec(tbxAjuste.Text)
            For i = 0 To dgvPrecios.RowCount - 1
                If dgvPrecios.Rows(i).Cells("Marcar").Value = 1 Or dgvPrecios.Rows(i).Cells("Marcar").Value = True Then
                    Dim Precio As Double = dgvPrecios.Rows(i).Cells("PrecioReal").Value
                    Precio = Precio * Ajuste
                    dgvPrecios.Rows(i).Cells("PRECIOVENTA").Value = Precio
                    If Precio < dgvPrecios.Rows(i).Cells("PrecioReal").Value Then

                        dgvPrecios.Item(3, i).Style.ForeColor = Color.Red

                    Else

                        dgvPrecios.Item(3, i).Style.ForeColor = Color.Green
                    End If
                End If
            Next
            btnAplicar.Enabled = True
        Catch ex As Exception
            If tbxAjuste.Text = " ," Or tbxAjuste.Text = "," Then
                MessageBox.Show("Especifíque el porcentaje de ajuste", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxAjuste.Focus()
                Exit Sub
            End If
        End Try
    End Sub

    Private Sub btnAplicar_Click(sender As System.Object, e As System.EventArgs) Handles btnAplicar.Click

        If MessageBox.Show("Los precios de Todos los productos se cambiarán, ¿Está seguro que desea realizar esos cambios?", "POS EXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        Else

            Dim QtyCambio As Integer = 0

            Me.Cursor = Cursors.AppStarting
            pgbAplicarCambios.Maximum = dgvPrecios.RowCount

            'PnlEspere.BringToFront()
            Dim f As New Funciones.Funciones
            Dim CodTipoCliente As Integer = dgvListaPrecio.CurrentRow.Cells("CODTIPOCLIENTE").Value
            Dim Precio As Double
            Dim codigo As String
            QtyCambio = 0

            Application.DoEvents()
            lblEstado.Text = "Procesando cambios"

            For i = 0 To dgvPrecios.RowCount - 1
                If dgvPrecios.Rows(i).Cells("Marcar").Value = 1 Or dgvPrecios.Rows(i).Cells("Marcar").Value = True Then
                    Try
                        Precio = Int(dgvPrecios.Rows(i).Cells("PRECIOVENTA").Value)
                        codigo = dgvPrecios.Rows(i).Cells("CODIGO").Value
                        ser.Abrir(sqlc)
                        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                        cmd.Connection = sqlc
                        cmd.Transaction = myTrans
                        sql = ""
                        sql = "UPDATE PRECIO SET PRECIOVENTA = '" & Precio & "' from PRECIO  join CODIGOS  on( codigos.codproducto=PRECIO.codproducto ) WHERE precio.CODTIPOCLIENTE = " & CodTipoCliente & " AND codigos.CODIGO = '" & codigo & "'"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                        myTrans.Commit()
                        sqlc.Close()
                    Catch ex As Exception

                    End Try
                    dgvPrecios.Rows(i).Cells("PRECIOVENTA").Value = Precio
                    dgvPrecios.Rows(i).Cells("PrecioReal").Value = dgvPrecios.Rows(i).Cells("PRECIOVENTA").Value
                    dgvPrecios.Rows(i).Cells("PRECIOVENTA").Value = 0

                    QtyCambio += 1
                    Application.DoEvents()
                    pgbAplicarCambios.Value = QtyCambio
                End If

            Next


            btnAplicar.Enabled = False
            Me.Cursor = Cursors.Arrow
            lblEstado.Text = "Proceso Terminado"
            'PnlEspere.SendToBack()
        End If

    End Sub
  

    Private Sub tbxAjuste_TextChanged(sender As Object, e As System.EventArgs) Handles tbxAjuste.TextChanged
        Try
            If tbxAjuste.Text = "," Then
                Exit Sub
            Else
                Dim PocentajeCambio As Double
                If tbxAjuste.Text <> " ," Then
                    PocentajeCambio = CDec(tbxAjuste.Text)
                    PocentajeCambio = (PocentajeCambio - 1) * 100
                    lblPorcentajeCambio.Text = PocentajeCambio.ToString + "%"
                End If
                End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPrecios_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrecios.CellContentClick

    End Sub

    Private Sub cbxMarcar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxMarcar.CheckedChanged
        Dim c As Integer = dgvPrecios.RowCount
        If c = 0 Then
            Exit Sub
        Else
            For i = 0 To c - 1
                If cbxMarcar.Checked = True Then
                    dgvPrecios.Rows(i).Cells("Marcar").Value = 1
                ElseIf cbxMarcar.Checked = False Then
                    dgvPrecios.Rows(i).Cells("Marcar").Value = 0

                End If
            Next

        End If
    End Sub
End Class