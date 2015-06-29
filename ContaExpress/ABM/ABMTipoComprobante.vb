Imports System.Data.SqlClient

Public Class ABMTipoComprobante
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Private b As Byte
    Dim dr As SqlDataReader
    Dim sel As Integer
    Dim ins As Integer
    Dim upd As Integer
    Dim del As Integer
    Dim pri As Integer
    Dim anu As Integer
    Dim permiso As Double
    Private actualizaroinsertar As Byte

    Private Sub Habilitar()
        'Botones
        PictureBoxNuevoR.Enabled = False
        PictureBoxNuevoR.Image = My.Resources.NewOff
        PictureBoxNuevoR.Cursor = Cursors.Arrow
        PictureBoxEliminarR.Enabled = False
        PictureBoxEliminarR.Image = My.Resources.DeleteOff
        PictureBoxEliminarR.Cursor = Cursors.Arrow
        PictureBoxModificaR.Enabled = False
        PictureBoxModificaR.Image = My.Resources.EditOff
        PictureBoxModificaR.Cursor = Cursors.Arrow

        PictureBoxGuardarR.Enabled = True
        PictureBoxGuardarR.Image = My.Resources.Save
        PictureBoxGuardarR.Cursor = Cursors.Hand
        PictureBoxCancelarR.Enabled = True
        PictureBoxCancelarR.Image = My.Resources.SaveCancel
        PictureBoxCancelarR.Cursor = Cursors.Hand

        'Texto
        tbxCodigo.Enabled = True
        tbxComprobante.Enabled = True
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        txtIdComprobante.Enabled = True

        dgvTipoComprobante.Enabled = False
        cbxNoRegCobros.Enabled = True
    End Sub

    Private Sub DesHabilitar()
        'Botones
        PictureBoxNuevoR.Enabled = True
        PictureBoxNuevoR.Image = My.Resources.New_
        PictureBoxNuevoR.Cursor = Cursors.Hand
        PictureBoxEliminarR.Enabled = True
        PictureBoxEliminarR.Image = My.Resources.Delete
        PictureBoxEliminarR.Cursor = Cursors.Hand
        PictureBoxModificaR.Enabled = True
        PictureBoxModificaR.Image = My.Resources.Edit
        PictureBoxModificaR.Cursor = Cursors.Hand

        PictureBoxGuardarR.Enabled = False
        PictureBoxGuardarR.Image = My.Resources.SaveOff
        PictureBoxGuardarR.Cursor = Cursors.Arrow
        PictureBoxCancelarR.Enabled = False
        PictureBoxCancelarR.Image = My.Resources.SaveCancelOff
        PictureBoxCancelarR.Cursor = Cursors.Arrow

        'Texto
        tbxCodigo.Enabled = False
        tbxComprobante.Enabled = False
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        txtIdComprobante.Enabled = False

        dgvTipoComprobante.Enabled = True
        cbxNoRegCobros.Enabled = False
    End Sub

    Private Sub TipoComprobante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 104)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If
        TIPOCOMPROBANTETableAdapter.Fill(DsSettings.TIPOCOMPROBANTE, "%")

        DesHabilitar()
        dgvTipoComprobante.Focus()
    End Sub

    Private Sub dgvTipoComprobante_SelectionChanged() Handles dgvTipoComprobante.SelectionChanged
        VaciarComboBox()
        If b = 1 Then
            Exit Sub
        Else
            If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("CODCOMPROBANTE").Value) Then
            Else
                'verificamos para que tipo de comprobante esta checkeado
                If dgvTipoComprobante.CurrentRow.Cells("COMPRAS").Value = 1 Then
                    cbxCompras.Checked = True
                End If

                If dgvTipoComprobante.CurrentRow.Cells("VENTAS").Value = 1 Then
                    cbxVentas.Checked = True
                End If

                If dgvTipoComprobante.CurrentRow.Cells("PRODUCCION").Value = 1 Then
                    cbxProduccion.Checked = True
                End If

                If dgvTipoComprobante.CurrentRow.Cells("COBROS").Value = 1 Then
                    cbxCobros.Checked = True
                End If

                If dgvTipoComprobante.CurrentRow.Cells("PAGOS").Value = 1 Then
                    cbxPagos.Checked = True
                End If

                If dgvTipoComprobante.CurrentRow.Cells("NOTACREDITO").Value = 1 Then
                    cbxNotaDeCredito.Checked = True
                End If

                If dgvTipoComprobante.CurrentRow.Cells("NOTADEBITO").Value = 1 Then
                    cbxNotaDeDebito.Checked = True
                End If

                If dgvTipoComprobante.CurrentRow.Cells("RETENCION").Value = 1 Then

                    cbxRetencion.Checked = True
                End If

                If dgvTipoComprobante.CurrentRow.Cells("AUTOFACTURA").Value = True Then
                    chbxAutoFactura.Checked = True
                End If

                If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("PAGARE").Value) Then
                    cbxPagares.Checked = False
                ElseIf dgvTipoComprobante.CurrentRow.Cells("PAGARE").Value = 1 Then
                    cbxPagares.Checked = True
                End If

                If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("NREMISION").Value) Then
                    cbxNotaDeRemision.Checked = False
                ElseIf dgvTipoComprobante.CurrentRow.Cells("NREMISION").Value = 1 Then
                    cbxNotaDeRemision.Checked = True
                End If

                If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("PRESUPUESTO").Value) Then
                    cbxPresupuesto.Checked = False
                ElseIf dgvTipoComprobante.CurrentRow.Cells("PRESUPUESTO").Value = 1 Then
                    cbxPresupuesto.Checked = True
                End If

                If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("ORDCOMPRA").Value) Then
                    cbxOrdCompra.Checked = False
                ElseIf dgvTipoComprobante.CurrentRow.Cells("ORDCOMPRA").Value = 1 Then
                    cbxOrdCompra.Checked = True
                End If

                If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("NDEBITOCOMPRA").Value) Then
                    cbxNotaDeDebitoCompra.Checked = False
                ElseIf dgvTipoComprobante.CurrentRow.Cells("NDEBITOCOMPRA").Value = 1 Then
                    cbxNotaDeDebitoCompra.Checked = True
                End If

                If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("PROYECTO").Value) Then
                    cbxProyectos.Checked = False
                ElseIf dgvTipoComprobante.CurrentRow.Cells("PROYECTO").Value = 1 Then
                    cbxProyectos.Checked = True
                End If

                Select Case dgvTipoComprobante.CurrentRow.Cells("FORMAIMPRESION").Value
                    Case Is = 0
                        rbtnTicket.Checked = True
                    Case Is = 1
                        rbtnImpresoraMatricial.Checked = True
                End Select

                If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("VALORFISCAL").Value) Then
                    cbxConValorLegal.Checked = False
                    cbxSinValorLegal.Checked = False
                Else
                    If dgvTipoComprobante.CurrentRow.Cells("VALORFISCAL").Value = 1 Then
                        cbxConValorLegal.Checked = True
                    ElseIf dgvTipoComprobante.CurrentRow.Cells("VALORFISCAL").Value = 0 Then
                        cbxSinValorLegal.Checked = True
                    End If
                End If

                If IsDBNull(dgvTipoComprobante.CurrentRow.Cells("NOREGCOBRO").Value) Then
                    cbxNoRegCobros.Checked = False
                Else
                    If dgvTipoComprobante.CurrentRow.Cells("NOREGCOBRO").Value = 1 Then
                        cbxNoRegCobros.Checked = True
                    ElseIf dgvTipoComprobante.CurrentRow.Cells("NOREGCOBRO").Value = 0 Then
                        cbxNoRegCobros.Checked = False
                    End If
                End If

            End If
        End If

        'Verificamos que check esta macado
        If rbtnTicket.Checked = True Then
            gbxTicket.Enabled = True
            gbxImpresora.Enabled = False
        Else
            gbxTicket.Enabled = False
            gbxImpresora.Enabled = True
        End If
    End Sub

    Private Sub PictureBoxNuevoR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxNuevoR.Click
        permiso = PermisoAplicado(UsuCodigo, 105)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        actualizaroinsertar = 0

        rbtnTicket.Checked = True
        rbtnImpresoraMatricial.Checked = False
        tbxCodigo.Text = "" : tbxComprobante.Text = "" : tbxCantLineas.Text = "" : tbxCodigo.Text = "" : tbxCantImpresion.Text = "" : txtIdComprobante.Text = ""

        VaciarComboBox()
        Habilitar()

        tbxCodigo.Focus()
    End Sub

    Private Sub PictureBoxEliminarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxEliminarR.Click
        permiso = PermisoAplicado(UsuCodigo, 106)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If
        If tbxCodigo.Text = "" Then
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere eliminar el Tipo de Comprobante?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            EliminarTipoComprobante()
            myTrans.Commit()
            MessageBox.Show("Tipo de comprobante eliminado con éxito", "POSEXPRESS")

        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch
            End Try
            MessageBox.Show("Ocurrió un error en la Operación" & ex.Message, "POSEXPRESS")
            'Cancelamos todo :(
        Finally
            sqlc.Close()
        End Try

        PictureBoxCancelarR_Click(Nothing, Nothing)
    End Sub

    Private Sub EliminarTipoComprobante()
        sql = ""
        sql = "delete from TIPOCOMPROBANTE WHERE NUMTIPOCOMPRO = '" & tbxCodigo.Text & "'"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizarTipoComprobante()
        Dim CantLineas, CantImpresion, ValorFiscal As Integer
        Dim NoRegCobro As Integer

        If cbxNoRegCobros.Checked = True Then
            NoRegCobro = 1
        Else
            NoRegCobro = 0
        End If

        If tbxCantLineas.Text <> "" Then
            CantLineas = CDec(tbxCantLineas.Text)
        Else
            CantLineas = 0
        End If

        If tbxCantImpresion.Text <> "" Then
            CantImpresion = CDec(tbxCantImpresion.Text)
        Else
            CantImpresion = 0
        End If

        If rbtnTicket.Checked = True Then
            If cbxConValorLegal.Checked = True Then
                ValorFiscal = 1
            Else
                ValorFiscal = 0
            End If
        Else
            ValorFiscal = 1
        End If

        sql = ""
        sql = "update TIPOCOMPROBANTE set NUMTIPOCOMPRO = '" & tbxCodigo.Text & "',DESCOMPROBANTE = '" & tbxComprobante.Text _
        & "', COMPRAS = " & RetornaTrueoFalse(cbxCompras.Checked) _
        & " ,VENTAS = " & RetornaTrueoFalse(cbxVentas.Checked) _
        & " ,COBROS = " & RetornaTrueoFalse(cbxCobros.Checked) _
        & " ,PAGOS = " & RetornaTrueoFalse(cbxPagos.Checked) _
        & " ,NCREDITO = " & RetornaTrueoFalse(cbxNotaDeCredito.Checked) _
        & " ,NDEBITO = " & RetornaTrueoFalse(cbxNotaDeDebito.Checked) _
        & " ,RETENCION = " & RetornaTrueoFalse(cbxRetencion.Checked) _
        & " ,PRODUCCION = " & RetornaTrueoFalse(cbxProduccion.Checked) _
        & " , VALORFISCAL = " & ValorFiscal _
        & " , NROLINEASDETALLE = " & CantLineas _
        & " ,FORMAIMPRESION = " & RetornaTipoImpresion() _
        & " ,CANTIDADIMPRESION = " & CantImpresion _
        & " ,AUTOFACTURA = " & RetornaTrueoFalse(chbxAutoFactura.Checked) _
        & ", PRESUPUESTO = " & RetornaTrueoFalse(cbxPresupuesto.Checked) _
        & ", ORDCOMPRA = " & RetornaTrueoFalse(cbxOrdCompra.Checked) _
        & ", NDEBITOCOMPRA = " & RetornaTrueoFalse(cbxNotaDeDebitoCompra.Checked) _
        & ", PAGARE = " & RetornaTrueoFalse(cbxPagares.Checked) _
        & ", NREMISION = " & RetornaTrueoFalse(cbxNotaDeRemision.Checked) _
        & ", PROYECTO = " & RetornaTrueoFalse(cbxProyectos.Checked) _
        & ", NOREGCOBRO = " & NoRegCobro & " , IDCOMPROBANTE =  '" & txtIdComprobante.Text & "'" _
        & "  WHERE CODCOMPROBANTE=" & dgvTipoComprobante.CurrentRow.Cells("CODCOMPROBANTE").Value

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Function RetornaTrueoFalse(ByRef val As Boolean) As String
        If val = True Then
            RetornaTrueoFalse = "1"
        Else
            RetornaTrueoFalse = "0"
        End If
    End Function

    Private Function RetornaTipoImpresion() As String
        RetornaTipoImpresion = "0"
        'If rbtnImpresoraAChorro.Checked = True Then
        '    RetornaTipoImpresion = "2"
        'End If
        If rbtnImpresoraMatricial.Checked = True Then
            RetornaTipoImpresion = "1"
        End If
    End Function

    Private Sub InsertarTipoComprobante()
        Dim CantLineas, CantImpresion, ValorFiscal As Integer
        Dim NoRegCobro As Integer

        If cbxNoRegCobros.Checked = True Then
            NoRegCobro = 1
        Else
            NoRegCobro = 0
        End If

        If tbxCantLineas.Text <> "" Then
            CantLineas = CDec(tbxCantLineas.Text)
        Else
            CantLineas = 0
        End If

        If tbxCantImpresion.Text <> "" Then
            CantImpresion = CDec(tbxCantImpresion.Text)
        Else
            CantImpresion = 1
        End If

        If rbtnTicket.Checked = True Then
            ValorFiscal = RetornaTrueoFalse(cbxConValorLegal.Checked)
        Else
            ValorFiscal = 1
        End If

        Dim f As New Funciones.Funciones
        Dim ultimo As Integer
        ultimo = f.Maximo("CODCOMPROBANTE", "TIPOCOMPROBANTE")
        Dim codcomp As Integer = ultimo + 1

        Dim cadenainsercion As String = codcomp & "," _
        & UsuCodigo.ToString & "," & EmpCodigo.ToString & ",'" & tbxCodigo.Text & "','" & tbxComprobante.Text & "'," _
        & RetornaTrueoFalse(cbxCompras.Checked) & "," & RetornaTrueoFalse(cbxVentas.Checked) & "," _
        & RetornaTrueoFalse(cbxCobros.Checked) & "," & RetornaTrueoFalse(cbxPagos.Checked) & "," _
        & RetornaTrueoFalse(cbxNotaDeCredito.Checked) & "," & RetornaTrueoFalse(cbxNotaDeDebito.Checked) & "," _
        & RetornaTrueoFalse(cbxRetencion.Checked) & "," & RetornaTrueoFalse(cbxProduccion.Checked) & ",GETDATE()," & RetornaTipoImpresion() & "," _
        & CantLineas & "," & ValorFiscal & "," & CantImpresion & "," & NoRegCobro & "," & RetornaTrueoFalse(chbxAutoFactura.Checked) & "," & _
        RetornaTrueoFalse(cbxPresupuesto.Checked) & "," & RetornaTrueoFalse(cbxOrdCompra.Checked) & "," & RetornaTrueoFalse(cbxNotaDeDebitoCompra.Checked) & "," & _
        RetornaTrueoFalse(cbxPagares.Checked) & "," & RetornaTrueoFalse(cbxNotaDeRemision.Checked) & "," & RetornaTrueoFalse(cbxProyectos.Checked)

        sql = ""
        sql = "INSERT INTO TIPOCOMPROBANTE (CODCOMPROBANTE,CODUSUARIO,CODEMPRESA,NUMTIPOCOMPRO,DESCOMPROBANTE,COMPRAS,VENTAS,COBROS,PAGOS,NCREDITO," & _
              "NDEBITO,RETENCION,PRODUCCION,FECGRA,FORMAIMPRESION,NROLINEASDETALLE,VALORFISCAL,CANTIDADIMPRESION,NOREGCOBRO,AUTOFACTURA,PRESUPUESTO,ORDCOMPRA,NDEBITOCOMPRA,   " & _
              "PAGARE, NREMISION, PROYECTO, IDCOMPROBANTE)  VALUES (" & cadenainsercion & ",'" & txtIdComprobante.Text & "')"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub VaciarComboBox()
        cbxCobros.Checked = False
        cbxCompras.Checked = False
        cbxPagos.Checked = False
        cbxNotaDeCredito.Checked = False
        cbxNotaDeDebito.Checked = False
        cbxRetencion.Checked = False
        cbxProduccion.Checked = False
        cbxVentas.Checked = False
        chbxAutoFactura.Checked = False
        cbxPresupuesto.Checked = False
        cbxNotaDeDebitoCompra.Checked = False
    End Sub

    Private Sub PictureBoxGuardarR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxGuardarR.Click

        'Verificamos que si esta selecionado TICKET marque al menos una opcion y que si esta seleccionado IMPRESORA cargue la cantidad de lineas
        If rbtnTicket.Checked = True Then
            If cbxConValorLegal.Checked = False And cbxSinValorLegal.Checked = False Then
                MessageBox.Show("Seleccione un Tipo de Ticket.", "POSEXPRESS")
                Exit Sub
            End If
        End If

        If rbtnImpresoraMatricial.Checked = True Then
            If tbxCantLineas.Text = "" Then
                MessageBox.Show("Ingrese la canidad de lineas.", "POSEXPRESS")
                tbxCantLineas.Focus()
                Exit Sub
            End If
            If tbxCantImpresion.Text = "" Then
                MessageBox.Show("Ingrese la cantidad de impresion por hoja.", "POSEXPRESS")
                tbxCantImpresion.Focus()
                Exit Sub
            End If
        End If

        If tbxCodigo.Text = "" Or tbxComprobante.Text = "" Then
            MessageBox.Show("Complete todos los campos necesarios.", "POSEXPRESS")
            tbxCodigo.Focus()
            Exit Sub
        End If
        If actualizaroinsertar = 0 Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertarTipoComprobante()
                myTrans.Commit()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Error al GUARDAR: " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Cancelamos todo :(
            Finally
                sqlc.Close()
            End Try
        End If
        If actualizaroinsertar = 1 Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizarTipoComprobante()
                myTrans.Commit()


            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Error al GUARDAR: " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Cancelamos todo :(
            Finally
                sqlc.Close()
            End Try
        End If
        DesHabilitar()
        b = 1
        TIPOCOMPROBANTETableAdapter.Fill(DsSettings.TIPOCOMPROBANTE, "%")
        b = 0
        dgvTipoComprobante_SelectionChanged()
    End Sub

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2

    End Sub

    Private Sub PictureBoxCancelarR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxCancelarR.Click
        DesHabilitar()
        b = 1
        TIPOCOMPROBANTETableAdapter.Fill(DsSettings.TIPOCOMPROBANTE, "%")
        b = 0
        dgvTipoComprobante_SelectionChanged()
    End Sub

    Private Sub PictureBoxModificaR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxModificaR.Click
        permiso = PermisoAplicado(UsuCodigo, 107)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express")
            Exit Sub
        End If

        Habilitar()

        actualizaroinsertar = 1
        'Verificamos que check esta macado
        If rbtnTicket.Checked = True Then
            gbxTicket.Enabled = True
            gbxImpresora.Enabled = False
        Else
            gbxTicket.Enabled = False
            gbxImpresora.Enabled = True
        End If

    End Sub

    Private Sub rbtnTicket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnTicket.CheckedChanged
        'Verificamos que check esta macado
        If rbtnTicket.Checked = True Then
            gbxTicket.Enabled = True
            gbxImpresora.Enabled = False
            tbxCantLineas.Text = ""
            tbxCantImpresion.Text = ""
        End If
    End Sub

    Private Sub rbtnImpresoraMatricial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnImpresoraMatricial.CheckedChanged
        'Verificamos que check esta macado
        If rbtnImpresoraMatricial.Checked = True Then
            gbxTicket.Enabled = False
            gbxImpresora.Enabled = True
        End If
    End Sub

    Private Sub tbxCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCodigo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxComprobante.Focus()
        End If
    End Sub

    Private Sub tbxComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxComprobante.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtIdComprobante.Focus()
        End If
    End Sub

    Private Sub dgvTipoComprobante_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipoComprobante.CellContentClick

    End Sub
End Class