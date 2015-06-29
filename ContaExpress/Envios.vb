Imports EnviaInformes
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class Envios
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Private conexion As System.Data.SqlClient.SqlConnection
    Private objCommand As New SqlCommand
    Dim sql As String
    Dim AccNuevo, AccEditar, vgCodEnvio As Integer
    Dim Config1, Config2, Config3, Config4, Config5, Config6, Config7, Config8, Config9, Config10, Config11, ConfigDecVS As String
    Dim f As New Funciones.Funciones
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim CodVentaTemp As String

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub DeshabilitaControles()
        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Cursor = Cursors.Hand

        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Cursor = Cursors.Hand

        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Cursor = Cursors.Hand

        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow

        BuscarTextBox.Enabled = True
        dgvFacturasSaldoEnvio.Enabled = True
        dgvEnviosXFactura.Enabled = True

        dtpFechaVto.Enabled = False : txtNroEnvio.Enabled = False : cmbDeposito.Enabled = False
        rbnFaltanEnviar.Enabled = True : rbnEnviados.Enabled = True
    End Sub

    Private Sub HabilitaControles()
        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Cursor = Cursors.Arrow

        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Image = My.Resources.DeleteOff
        EliminarPictureBox.Cursor = Cursors.Arrow

        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        GuardarPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand

        BuscarTextBox.Enabled = False
        dgvFacturasSaldoEnvio.Enabled = False
        dgvEnviosXFactura.Enabled = False

        dtpFechaVto.Enabled = True : txtNroEnvio.Enabled = True : cmbDeposito.Enabled = True
        rbnFaltanEnviar.Enabled = False : rbnEnviados.Enabled = False : tbxRemNroFactura.Enabled = True
    End Sub

    Private Sub DescotarSaldoVenta()
        sql = ""

        For i = 0 To dgvEnvioDetalle.RowCount - 1
            'Descontamos el saldo a enviar de la tabla Ventas Detalle
            sql = sql + " UPDATE VENTASDETALLE SET SALDOENVIO = SALDOENVIO - " & FormatNumber(dgvEnvioDetalle.Rows(i).Cells("Enviado").Value, 0) & " WHERE CODCODIGO = " & _
                  dgvEnvioDetalle.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn1").Value & " AND CODVENTA =" & dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value
        Next

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizarStockProductoEnvio(ByVal NrodeVenta As String, ByVal Operacion As Integer)
        Dim w As New Funciones.Funciones
        Dim CantidadFactura, CodCodigoFactura, Precio, Costeable As String
        Dim c As Integer = dgvEnvioDetalle.RowCount
        Dim IsProducto As Integer

        sql = ""

        If Operacion = 0 Then
            'descuenta al stock
            For c = 1 To c
                'SE DEBE VERIFICAR QUE NO SEA UN SERVICIO
                IsProducto = w.FuncionConsulta("SERVICIO", "PRODUCTOS", "CODPRODUCTO", dgvEnvioDetalle.Rows(c - 1).Cells("CODIGODataGridViewTextBoxColumn").Value)

                If IsProducto <> 1 Then
                    If IsDBNull(dgvEnvioDetalle.Rows(c - 1).Cells("Enviado").Value) Then
                        CantidadFactura = "NULL"
                    Else
                        CantidadFactura = dgvEnvioDetalle.Rows(c - 1).Cells("Enviado").Value
                        CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                        CantidadFactura = Replace(CantidadFactura, ",", ".")

                    End If

                    Costeable = 0
                    If IsDBNull(dgvEnvioDetalle.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                        CodCodigoFactura = "NULL"
                    Else
                        CodCodigoFactura = dgvEnvioDetalle.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                    End If

                    Precio = w.FuncionConsultaString2("PRECIOVENTALISTA", "VENTASDETALLE", "CODCODIGO = " & dgvEnvioDetalle.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn1").Value & " AND CODVENTA", dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)
                    Precio = Funciones.Cadenas.QuitarCad(Precio, ".")
                    Precio = Replace(Precio, ",", ".")

                    Dim hora, Concat, Concatenar As String

                    hora = Now.ToString("HH:mm:ss")
                    Concat = w.FuncionConsultaString2("FECHAVENTA", "VENTAS", "CODVENTA", dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)
                    Concat = Concat.Substring(0, 10)
                    Concatenar = Concat & " " + hora

                    sql = sql + " INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,STOCK) " & _
                               "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & cmbDeposito.SelectedValue & ",CONVERT(Datetime,'" & Concatenar & "',103),8," & dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & _
                               ", -" & CantidadFactura & "," & Precio & ",'Remisión Nro " & txtNroEnvio.Text & "'," & Costeable & ",1)     "
                End If
            Next

            'CAMBIAR A APROBADO
            sql = sql + " UPDATE ENVIOS SET ESTADO = 1 WHERE CODENVIO = " & CInt(dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value)

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        ElseIf Operacion = 1 Then
            'Agrega a stock
            For c = 1 To c
                'SE DEBE VERIFICAR QUE NO SEA UN SERVICIO
                IsProducto = w.FuncionConsulta("SERVICIO", "PRODUCTOS", "CODPRODUCTO", dgvEnvioDetalle.Rows(c - 1).Cells("CODIGODataGridViewTextBoxColumn").Value)

                If IsProducto <> 1 Then
                    If IsDBNull(dgvEnvioDetalle.Rows(c - 1).Cells("Enviado").Value) Then
                        CantidadFactura = "NULL"
                    Else
                        CantidadFactura = dgvEnvioDetalle.Rows(c - 1).Cells("Enviado").Value
                        CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                        CantidadFactura = Replace(CantidadFactura, ",", ".")
                    End If

                    Costeable = 0
                    If IsDBNull(dgvEnvioDetalle.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                        CodCodigoFactura = "NULL"
                    Else
                        CodCodigoFactura = dgvEnvioDetalle.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                    End If

                    Precio = w.FuncionConsultaString2("PRECIOVENTALISTA", "VENTASDETALLE", "CODCODIGO = " & dgvEnvioDetalle.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn1").Value & " AND CODVENTA", dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)
                    Precio = Funciones.Cadenas.QuitarCad(Precio, ".")
                    Precio = Replace(Precio, ",", ".")

                    Dim hora, Concat, Concatenar As String

                    hora = Now.ToString("HH:mm:ss")
                    Concat = w.FuncionConsultaString2("FECHAVENTA", "VENTAS", "CODVENTA", dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)
                    Concat = Concat.Substring(0, 10)
                    Concatenar = Concat & " " + hora

                    sql = sql + " INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,STOCK) " & _
                               "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & cmbDeposito.SelectedValue & ",CONVERT(Datetime,'" & Concatenar & "',103),8," & dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & _
                               "," & CantidadFactura & "," & Precio & ",'Remisión Nro " & txtNroEnvio.Text & "'," & Costeable & ",1)     "
                End If
            Next

            'CAMBIAR A ANULADO
            sql = sql + " UPDATE ENVIOS SET ESTADO = 2 WHERE CODENVIO = " & CInt(dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value)

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub GuardarEnvio()
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            EnvioCabecera() 'Tabla Envios
            VentasxEnvio()  'Tabla EnviosxVentas
            EnvioDetalle()  'Tabla EnviosDetalle

            myTrans.Commit()

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            myTrans.Rollback("Actualizar")
        End Try
    End Sub

    Private Sub ModificarEnvio()
        Dim MaxCodEnvioDetalle As Integer = f.Maximo("CODENVIODET", "ENVIOSDETALLE")
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            For i = 0 To dgvEnvioDetalle.Rows.Count - 1
                If dgvEnvioDetalle.Rows(i).Cells("ENVIAR").Value > 0 Then
                    MaxCodEnvioDetalle = MaxCodEnvioDetalle + 1

                    sql = sql + "INSERT INTO ENVIOSDETALLE (CODENVIODET,CODENVIO,CODCODIGO,CANTIDAD) " & _
                          "VALUES(" & MaxCodEnvioDetalle & "," & dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value & "," & dgvEnvioDetalle.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn1").Value & "," & CInt(dgvEnvioDetalle.Rows(i).Cells("ENVIAR").Value) & ")"
                End If
            Next

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            myTrans.Rollback("Actualizar")
        End Try
    End Sub

    Private Sub VentasxEnvio()
        sql = ""
        sql = "INSERT INTO VENTASXENVIO (CODENVIO,CODVENTA)  " & _
              "VALUES(" & vgCodEnvio & "," & dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EnvioCabecera()
        sql = ""
        sql = "INSERT INTO ENVIOS (CODCLIENTE,FECHAENVIO,CODDEPOSITO,ESTADO)  " & _
              "VALUES(" & dgvFacturasSaldoEnvio.CurrentRow.Cells("CODCLIENTE").Value & ", CONVERT (DATETIME,'" & dtpFechaVto.Text & "',103), " & _
              cmbDeposito.SelectedValue & ",0) " & _
              "SELECT CODENVIO FROM ENVIOS WHERE CODENVIO = SCOPE_IDENTITY();"

        cmd.CommandText = sql
        vgCodEnvio = cmd.ExecuteScalar
    End Sub

    Private Sub EnvioDetalle()
        Dim MaxCodEnvioDetalle As Integer = f.Maximo("CODENVIODET", "ENVIOSDETALLE")
        sql = ""

        For i = 0 To dgvEnvioDetalle.RowCount - 1
            'Solo guardaremos aquellos que Stock a enviar sea Mayor a Cero (0)
            If dgvEnvioDetalle.Rows(i).Cells("ENVIAR").Value > 0 Then
                MaxCodEnvioDetalle = MaxCodEnvioDetalle + 1

                sql = "INSERT INTO ENVIOSDETALLE (CODENVIODET,CODENVIO,CODCODIGO,CANTIDAD) " & _
                      "VALUES(" & MaxCodEnvioDetalle & "," & vgCodEnvio & "," & dgvEnvioDetalle.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn1").Value & "," & dgvEnvioDetalle.Rows(i).Cells("ENVIAR").Value & ")"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub AprobarEnvio()
        Try
            sql = ""
            sql = "UPDATE ENVIOS SET ESTADO = 1 , NROENVIO  =  '" & txtNroEnvio.Text & "'  WHERE CODENVIO = " & dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AnularEnvio()
        Try
            sql = ""
            sql = "UPDATE ENVIOS SET ESTADO = 2 WHERE CODENVIO = " & dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Eliminar()

        If MessageBox.Show("¿Esta seguro que quiere eliminar el Envío?", "Cogent SIG", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try

            EliminarEnvioDetalle()
            EliminarVentasXEnvio()
            EliminarEnvio()

            myTrans.Commit()

            Try
                Me.ENVIOSTableAdapter.Fill(Me.DsEnvios.ENVIOS)
                ENVIOSTableAdapter.FillBy(DsEnvios.ENVIOS, dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)
            Catch ex As Exception
            End Try

            EnviosBindingSource.MoveLast()

            MessageBox.Show("Envío eliminada correctamente", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch

            End Try
            MessageBox.Show(" La Envío está siendo utilizado por el Sistema y no se puede Eliminar ", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlc.Close()
        End Try

    End Sub

    Private Sub EliminarEnvio()
        Try
            sql = ""
            sql = "DELETE FROM ENVIOS WHERE CODENVIO=" & dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EliminarEnvioDetalle()
        Try
            sql = ""
            sql = "DELETE FROM ENVIOSDETALLE WHERE CODENVIO=" & dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EliminarVentasXEnvio()
        Try
            sql = ""
            sql = "DELETE FROM VENTASXENVIO WHERE CODENVIO=" & dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoEnvio()
        Try
            If dgvEnviosXFactura.CurrentRow.Cells("ESTADO").Value = 0 Then
                LblEstado.Text = "Pendiente"
                LblEstado.ForeColor = Color.Black

                ConfirmarPictureBox.Image = My.Resources.Approve
                ConfirmarPictureBox.Enabled = True
                ConfirmarPictureBox.Cursor = Cursors.Hand

                EliminarPictureBox.Enabled = True
                EliminarPictureBox.Image = My.Resources.Delete
                EliminarPictureBox.Cursor = Cursors.Hand

                ModificarPictureBox.Enabled = True
                ModificarPictureBox.Image = My.Resources.Edit
                ModificarPictureBox.Cursor = Cursors.Hand

                GuardarPictureBox.Enabled = False
                GuardarPictureBox.Image = My.Resources.SaveOff
                GuardarPictureBox.Cursor = Cursors.Hand

                ConfirmarPictureBox.Enabled = True
                ConfirmarPictureBox.Image = My.Resources.Approve
                ConfirmarPictureBox.Cursor = Cursors.Hand


                PictureBoxMotivoAnulacion.Enabled = False
                PictureBoxMotivoAnulacion.Image = My.Resources.AnullOff
                PictureBoxMotivoAnulacion.Cursor = Cursors.Arrow

            ElseIf dgvEnviosXFactura.CurrentRow.Cells("ESTADO").Value = 1 Then
                LblEstado.Text = "Aprobada"
                LblEstado.ForeColor = Color.YellowGreen

                ConfirmarPictureBox.Image = My.Resources.ApproveOff
                ConfirmarPictureBox.Enabled = False
                ConfirmarPictureBox.Cursor = Cursors.Arrow

                EliminarPictureBox.Enabled = False
                EliminarPictureBox.Image = My.Resources.DeleteOff
                EliminarPictureBox.Cursor = Cursors.Arrow


                ModificarPictureBox.Enabled = False
                ModificarPictureBox.Image = My.Resources.EditOff
                ModificarPictureBox.Cursor = Cursors.Arrow

                GuardarPictureBox.Enabled = False
                GuardarPictureBox.Image = My.Resources.SaveOff
                GuardarPictureBox.Cursor = Cursors.Arrow


                PictureBoxMotivoAnulacion.Enabled = True
                PictureBoxMotivoAnulacion.Image = My.Resources.Anull
                PictureBoxMotivoAnulacion.Cursor = Cursors.Hand

            ElseIf dgvEnviosXFactura.CurrentRow.Cells("ESTADO").Value = 2 Then
                LblEstado.Text = "Anulada"
                LblEstado.ForeColor = Color.Maroon

                ConfirmarPictureBox.Image = My.Resources.ApproveOff
                ConfirmarPictureBox.Enabled = False
                ConfirmarPictureBox.Cursor = Cursors.Arrow

                EliminarPictureBox.Enabled = False
                EliminarPictureBox.Image = My.Resources.DeleteOff
                EliminarPictureBox.Cursor = Cursors.Arrow


                ModificarPictureBox.Enabled = False
                ModificarPictureBox.Image = My.Resources.EditOff
                ModificarPictureBox.Cursor = Cursors.Arrow

                GuardarPictureBox.Enabled = False
                GuardarPictureBox.Image = My.Resources.SaveOff
                GuardarPictureBox.Cursor = Cursors.Arrow


                PictureBoxMotivoAnulacion.Enabled = False
                PictureBoxMotivoAnulacion.Image = My.Resources.AnullOff
                PictureBoxMotivoAnulacion.Cursor = Cursors.Hand
            End If
        Catch ex As Exception
            ConfirmarPictureBox.Image = My.Resources.ApproveOff
            ConfirmarPictureBox.Enabled = False
            ConfirmarPictureBox.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub Automatico()

        If dgvEnvioDetalle.Rows.Count > 0 Then
            Exit Sub
        End If
        'Si presiona Automatico debe trae en la grilla todos los productos del Presupuesto o Factura que aun no se hallan enviado
        Dim objCommand As New SqlCommand
        Dim CodEnvio As Integer = f.Maximo("CODENVIO", "ENVIOS") + 1
        Dim CantReg As Integer = 0
        Dim vStockActual, vSaldoEnvio As Integer

        Try
            objCommand.CommandText = "SELECT dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO + ' ' + dbo.CODIGOS.DESCODIGO1 AS DESPRODUCTO, dbo.VENTASDETALLE.CODCODIGO, " & _
                                      "dbo.VENTASDETALLE.CODVENTA, dbo.VENTASDETALLE.SALDOENVIO, dbo.STOCKDEPOSITO.STOCKACTUAL, dbo.STOCKDEPOSITO.CODDEPOSITO,  " & _
                                      "SUBSTRING(dbo.VENTAS.NUMVENTA, LEN(dbo.VENTAS.NUMVENTA) - 5, 6) AS NUMVENTA1 " & _
                                      "FROM dbo.VENTAS INNER JOIN dbo.VENTASDETALLE ON dbo.VENTAS.CODVENTA = dbo.VENTASDETALLE.CODVENTA LEFT OUTER JOIN  " & _
                                      "dbo.CODIGOS INNER JOIN dbo.STOCKDEPOSITO ON dbo.CODIGOS.CODCODIGO = dbo.STOCKDEPOSITO.CODCODIGO RIGHT OUTER JOIN " & _
                                      "dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO ON dbo.VENTASDETALLE.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO " & _
                                      "WHERE (dbo.VENTASDETALLE.CODVENTA = " & dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & ") AND " & _
                                      "(dbo.PRODUCTOS.PRODUCTO = 1) AND (dbo.VENTASDETALLE.SALDOENVIO > 0) AND  dbo.STOCKDEPOSITO.CODDEPOSITO = " & cmbDeposito.SelectedValue

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    EnviosDetalleBindingSource.AddNew()
                    CantReg = dgvEnvioDetalle.RowCount

                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("CODENVIODataGridViewTextBoxColumn1").Value = CodEnvio
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("CODENVIODETDataGridViewTextBoxColumn").Value = CantReg
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = odrConfig("CODCODIGO")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("CODIGODataGridViewTextBoxColumn").Value = odrConfig("CODIGO")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("PRODUCTODataGridViewTextBoxColumn1").Value = odrConfig("DESPRODUCTO")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("NUMVENTADataGridViewTextBoxColumn1").Value = odrConfig("NUMVENTA1")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("SALDO").Value = odrConfig("SALDOENVIO")
                    vSaldoEnvio = odrConfig("SALDOENVIO")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("STOCK").Value = odrConfig("STOCKACTUAL")
                    vStockActual = odrConfig("STOCKACTUAL") '- f.FuncionConsultaString2("CANTIDAD", "ENVIOSDETALLE", "CODCODIGO", odrConfig("CODCODIGO"))

                    If vStockActual < 0 Then
                        dgvEnvioDetalle.Item(4, CantReg - 1).Style.ForeColor = Color.Maroon
                    Else
                        dgvEnvioDetalle.Item(4, CantReg - 1).Style.ForeColor = Color.Black
                    End If

                    If vSaldoEnvio > vStockActual Then
                        If vStockActual > 0 Then
                            dgvEnvioDetalle.Rows(CantReg - 1).Cells("ENVIAR").Value = vStockActual
                        Else
                            dgvEnvioDetalle.Rows(CantReg - 1).Cells("ENVIAR").Value = 0
                        End If
                    Else
                        dgvEnvioDetalle.Rows(CantReg - 1).Cells("ENVIAR").Value = vSaldoEnvio
                    End If
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
            objCommand.Dispose()
        End Try
    End Sub

    Private Sub AutomaticoEditar()
        'Si presiona Automatico debe trae en la grilla todos los productos del Presupuesto o Factura que aun no se hallan enviado
        Dim objCommand As New SqlCommand
        Dim CantReg As Integer = 0
        Dim vStockActual As Integer

        Try
            objCommand.CommandText = "SELECT dbo.VENTASDETALLE.CODVENTA, dbo.VENTASDETALLE.CODCODIGO, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.VENTASDETALLE.SALDOENVIO, " & _
                                     "SUBSTRING(dbo.VENTAS.NUMVENTA, LEN(dbo.VENTAS.NUMVENTA) - 5, 6) AS NUMVENTA1, dbo.STOCKDEPOSITO.STOCKACTUAL  FROM dbo.VENTASDETALLE INNER JOIN dbo.CODIGOS ON dbo.VENTASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN " & _
                                     "dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO INNER JOIN dbo.VENTAS ON dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA INNER JOIN  " & _
                                     "dbo.STOCKDEPOSITO ON dbo.CODIGOS.CODCODIGO = dbo.STOCKDEPOSITO.CODCODIGO " & _
                                     "WHERE (dbo.VENTASDETALLE.CODVENTA = " & dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & ") AND (dbo.PRODUCTOS.PRODUCTO = 0) " & _
                                     "AND (dbo.VENTASDETALLE.CODCODIGO NOT IN  (SELECT CODCODIGO FROM dbo.ENVIOSDETALLE WHERE CODENVIO = " & dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value & "))"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    EnviosDetalleBindingSource.AddNew()
                    CantReg = dgvEnvioDetalle.RowCount

                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("CODENVIODataGridViewTextBoxColumn1").Value = dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("CODENVIODETDataGridViewTextBoxColumn").Value = CantReg
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = odrConfig("CODCODIGO")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("CODIGODataGridViewTextBoxColumn").Value = odrConfig("CODIGO")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("PRODUCTODataGridViewTextBoxColumn1").Value = odrConfig("DESPRODUCTO")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("NUMVENTADataGridViewTextBoxColumn1").Value = odrConfig("NUMVENTA1").ToString
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("SALDO").Value = odrConfig("SALDOENVIO")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("ENVIAR").Value = odrConfig("CANTIDADVENTA")
                    dgvEnvioDetalle.Rows(CantReg - 1).Cells("STOCK").Value = odrConfig("STOCKACTUAL")
                    vStockActual = odrConfig("STOCKACTUAL")

                    If vStockActual < 0 Then
                        dgvEnvioDetalle.Item(4, CantReg - 1).Style.ForeColor = Color.Maroon
                    Else
                        dgvEnvioDetalle.Item(4, CantReg - 1).Style.ForeColor = Color.Black
                    End If

                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
            objCommand.Dispose()
        End Try
    End Sub

    Private Sub Envios_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlChofer.Visible = False
        End If
    End Sub

    Private Sub Envios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DeshabilitaControles()
        Try
            Me.ENVIOSDETALLETableAdapter.Fill(Me.DsEnvios.ENVIOSDETALLE)
            Me.ENVIOSTableAdapter.Fill(Me.DsEnvios.ENVIOS)
            Me.FACTURASCONSALDOENVIOTableAdapter.Fill(Me.DsEnvios.FACTURASCONSALDOENVIO)
            Me.DEPOSITOTableAdapter.Fill(Me.DsEnvios.DEPOSITO)

            LblEstado.Text = " "
            Me.ENVIOSTableAdapter.FillBy(Me.DsEnvios.ENVIOS, 0)
            ENVIOSDETALLETableAdapter.FillBy(DsEnvios.ENVIOSDETALLE, 0)
        Catch ex As Exception
        End Try

        NroRemision()

        'Ocultamos los Campos
        SALDO.Visible = False : STOCK.Visible = False : ENVIAR.Visible = False : Enviado.Visible = True
        Try
            dgvFacturasSaldoEnvio.Sort(dgvFacturasSaldoEnvio.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvEnvioDetalle_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvEnvioDetalle.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvEnvioDetalle.CurrentCell.ColumnIndex
        If columna = 6 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ",") And (txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvEnvioDetalle_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEnvioDetalle.CellEndEdit

        'verificamos que el stock a enviar no supere el stock actual
        If dgvEnvioDetalle.CurrentRow.Cells("STOCK").Value < dgvEnvioDetalle.CurrentRow.Cells("ENVIAR").Value Then
            MessageBox.Show("El Stock a Enviar no Puede ser Mayor al Stock Actual", "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvEnvioDetalle.CurrentRow.Cells("ENVIAR").Value = 0
            Exit Sub
        End If

        'verificamos que el stock a enviar no supere el stock Saldo
        If dgvEnvioDetalle.CurrentRow.Cells("SALDO").Value < dgvEnvioDetalle.CurrentRow.Cells("ENVIAR").Value Then
            MessageBox.Show("El Stock a Enviar no Puede ser Mayor al Saldo de Envío", "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvEnvioDetalle.CurrentRow.Cells("ENVIAR").Value = 0
        End If

    End Sub

    Private Sub dgvFacturasSaldoEnvio_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvFacturasSaldoEnvio.SelectionChanged
        Try
            Me.ENVIOSTableAdapter.FillBy(Me.DsEnvios.ENVIOS, dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)
            EstadoEnvio()
            CodVentaTemp = dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        AccNuevo = 1 : AccEditar = 0
        SALDO.Visible = True : STOCK.Visible = True : ENVIAR.Visible = True : Enviado.Visible = False

        HabilitaControles()
        EnviosBindingSource.AddNew()

        dtpFechaVto.Value = Today.ToShortDateString

        Try
            cmbDeposito.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Automatico()
        dtpFechaVto.Focus()
    End Sub

    Private Sub dtpFechaVto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaVto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtNroEnvio.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroEnvio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroEnvio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbDeposito.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Try
            DeshabilitaControles()
            EnviosDetalleBindingSource.CancelEdit()
            EnviosBindingSource.CancelEdit()
            BuscarTextBox.Focus()

            'Ocultamos los Campos
            SALDO.Visible = False : STOCK.Visible = False : ENVIAR.Visible = False : Enviado.Visible = True

            Me.ENVIOSDETALLETableAdapter.Fill(Me.DsEnvios.ENVIOSDETALLE)
            Me.ENVIOSTableAdapter.Fill(Me.DsEnvios.ENVIOS)
            Me.FACTURASCONSALDOENVIOTableAdapter.Fill(Me.DsEnvios.FACTURASCONSALDOENVIO)
        Catch ex As Exception
        End Try
        Try
            'ordenamos la grilla
            dgvFacturasSaldoEnvio.Sort(dgvFacturasSaldoEnvio.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        FacturasSaldoEnvioBindingSource.Filter = "NUMVENTA LIKE '%" & BuscarTextBox.Text & "%' OR NOMBRECLIENTE LIKE '%" & BuscarTextBox.Text & "%'"
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        If dgvEnvioDetalle.Rows.Count = 0 Then
            Exit Sub
        End If

        'Verificamos que tenga numero de envio, deposito y algun detalle
        If cmbDeposito.Text = "" Then
            MessageBox.Show("Seleccion al menos un Deposito", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbDeposito.BackColor = Color.Pink
        End If

        If AccNuevo = 1 Then
            GuardarEnvio()
        ElseIf AccEditar = 1 Then
            ModificarEnvio()
        End If

        Dim EnvioTemp As Integer = dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value

        Try
            Me.ENVIOSDETALLETableAdapter.Fill(Me.DsEnvios.ENVIOSDETALLE)
            Me.ENVIOSTableAdapter.Fill(Me.DsEnvios.ENVIOS)
            Me.FACTURASCONSALDOENVIOTableAdapter.Fill(Me.DsEnvios.FACTURASCONSALDOENVIO)
        Catch ex As Exception
        End Try

        For i = 0 To dgvFacturasSaldoEnvio.RowCount - 1
            If dgvFacturasSaldoEnvio.Rows(i).Cells("CODVENTADataGridViewTextBoxColumn").Value = EnvioTemp Then
                FacturasSaldoEnvioBindingSource.Position = i
                Exit For
            End If
        Next

        'Ocultamos los Campos
        SALDO.Visible = False : STOCK.Visible = False : ENVIAR.Visible = False : Enviado.Visible = True

        Try
            'ordenamos la grilla
            dgvFacturasSaldoEnvio.Sort(dgvFacturasSaldoEnvio.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
        End Try

        For i = 0 To dgvFacturasSaldoEnvio.RowCount - 1
            If dgvFacturasSaldoEnvio.Rows(i).Cells("CODVENTADataGridViewTextBoxColumn").Value = CodVentaTemp Then
                EnviosDetalleBindingSource.Position = i
                Exit For
            End If
        Next

        DeshabilitaControles()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEnviosXFactura_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvEnviosXFactura.SelectionChanged
        Try
            ENVIOSDETALLETableAdapter.FillBy(DsEnvios.ENVIOSDETALLE, dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value)
            EstadoEnvio()
        Catch ex As Exception
            LblEstado.Text = " "
            ENVIOSDETALLETableAdapter.FillBy(DsEnvios.ENVIOSDETALLE, 0)
        End Try
    End Sub

    Public Sub ConfirmarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ConfirmarPictureBox.Click
        pnlNroFactura.BringToFront()
        pnlNroFactura.Visible = True
        pnlNroFactura.Enabled = True
        tbxRemNroFactura.Text = ""
        tbxRemNroFactura.Focus()

    End Sub
    Public Sub btnContinuar_Click() Handles btnContinuar.Click
        If tbxRemNroFactura.Text Is Nothing Then
            tbxRemNroFactura.Text = ""
        End If
        pnlNroFactura.Visible = False
        MostrarPanelChofer()
    End Sub
    Private Sub MostrarPanelChofer()
        pnlChofer.BringToFront()
        pnlChofer.Visible = True
        btnEnviar.Enabled = True

        txtRucChofer.Text = "" : txtVehiculo.Text = "" : txtNroChapa.Text = "" : txtConductor.Text = "" : txtDireccion.Text = ""
        txtRucChofer.Focus()
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 217)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para modificar un envío", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            SALDO.Visible = True : STOCK.Visible = True : ENVIAR.Visible = True : Enviado.Visible = False
            HabilitaControles()

            AccEditar = 1 : AccNuevo = 0
            AutomaticoEditar()

            dgvEnviosXFactura.Enabled = True
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 218)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para eliminar una devolución", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Eliminar()
        End If
    End Sub

    Private Sub PictureBoxMotivoAnulacion_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxMotivoAnulacion.Click
        If MessageBox.Show("¿Esta seguro que quiere Anular el Envío?", "Cogent SIG", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            AnularEnvio()
            ActualizarStockProductoEnvio(CStr(dgvFacturasSaldoEnvio.CurrentRow.Cells("NUMVENTADataGridViewTextBoxColumn").Value), 1)

            myTrans.Commit()

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            myTrans.Rollback("Actualizar")
        End Try

        Try
            Me.ENVIOSDETALLETableAdapter.Fill(Me.DsEnvios.ENVIOSDETALLE)
            Me.ENVIOSTableAdapter.Fill(Me.DsEnvios.ENVIOS)
            Me.FACTURASCONSALDOENVIOTableAdapter.Fill(Me.DsEnvios.FACTURASCONSALDOENVIO)
        Catch ex As Exception
        End Try

        DeshabilitaControles()
        'Ocultamos los Campos
        SALDO.Visible = False : STOCK.Visible = False : ENVIAR.Visible = False : Enviado.Visible = True
    End Sub

    Public Function InfFactura() As DataSet
        Dim ds As New DsInformes
        Dim row As DataRow

        ds.Clear()

        Try
            Dim TipoVenta As String = ""
            Dim CodVenta As String = dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value
            Dim k As Integer = 1
            Dim i As Integer = 0
            Dim c As Integer = dgvEnvioDetalle.RowCount()

            Dim cantlinea = f.FuncionConsultaString2("NROLINEASDETALLE", "TIPOCOMPROBANTE", "NREMISION", 1)
            Dim CantImpresion As Integer = f.FuncionConsultaDecimal("CANTIDADIMPRESION", "TIPOCOMPROBANTE", "NREMISION", 1)

            Dim dadatoscli As New SqlDataAdapter("SELECT dbo.ENVIOS.FECHAENVIO, dbo.ENVIOS.NROENVIO, dbo.CHOFERENVIO.NOMBRE, dbo.CHOFERENVIO.RUC, dbo.CHOFERENVIO.VEHICULO, dbo.CHOFERENVIO.CHAPA, dbo.CHOFERENVIO.DIRECCION, dbo.ENVIOSDETALLE.CANTIDAD, " & _
                                                 "dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.VENTASXENVIO.CODVENTA, dbo.CLIENTES.NOMBRE AS CLIENTE, dbo.CLIENTES.RUC AS RUCCLIENTE, dbo.CLIENTES.DIRECCION AS DIRECCIONCLIENTE, dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTAS.COTIZACION1 " & _
                                                 "FROM dbo.ENVIOS INNER JOIN dbo.ENVIOSDETALLE ON dbo.ENVIOS.CODENVIO = dbo.ENVIOSDETALLE.CODENVIO INNER JOIN dbo.CODIGOS ON dbo.ENVIOSDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                                                 "dbo.VENTASXENVIO ON dbo.ENVIOS.CODENVIO = dbo.VENTASXENVIO.CODENVIO INNER JOIN dbo.CLIENTES ON dbo.ENVIOS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE INNER JOIN dbo.VENTASDETALLE ON dbo.VENTASXENVIO.CODVENTA = dbo.VENTASDETALLE.CODVENTA INNER JOIN dbo.VENTAS ON " & _
                                                 "dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA LEFT OUTER JOIN dbo.CHOFERENVIO ON dbo.ENVIOS.CODENVIO = dbo.CHOFERENVIO.ENVIOID WHERE dbo.VENTASXENVIO.CODVENTA = " & CodVenta, ser.CadenaConexion)

            Dim dtdatoscli As New DataTable
            dadatoscli.Fill(dtdatoscli)
            Dim drdatoscli As DataRow
            drdatoscli = dtdatoscli.Rows(0)

            If CantImpresion = 0 Then
                CantImpresion = 1
            End If

            For k = 1 To CantImpresion
                For i = 1 To cantlinea
                    row = ds.Tables("Detalle").NewRow()

                    If i = 1 Then
                        row.Item("Campo4") = drdatoscli("CLIENTE")
                        row.Item("Campo5") = drdatoscli("RUCCLIENTE")
                        row.Item("Campo8") = drdatoscli("DIRECCIONCLIENTE")
                        row.Item("Campo17") = drdatoscli("NROENVIO")
                        row.Item("Campo18") = tbxRemNroFactura.Text
                        row.Item("Fecha1") = dgvEnviosXFactura.CurrentRow.Cells("FECHAENVIODataGridViewTextBoxColumn").Value

                        row.Item("Campo9") = drdatoscli("VEHICULO")
                        row.Item("Campo2") = drdatoscli("CHAPA")
                        row.Item("Campo10") = drdatoscli("NOMBRE")
                        row.Item("Campo3") = drdatoscli("RUC")
                        row.Item("Campo1") = drdatoscli("DIRECCION")

                        If f.FuncionConsultaString2("TIPOVENTA", "VENTAS", "CODVENTA", dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value) = 1 Then
                            TipoVenta = "Contado"
                        Else
                            TipoVenta = "Credito"
                        End If
                        row.Item("Campo14") = "** Fin de la Impresión ** Nro Factura: " + dgvFacturasSaldoEnvio.CurrentRow.Cells("NUMVENTADataGridViewTextBoxColumn").Value + " Tipo de Venta " + TipoVenta
                    End If

                    If i > c Then
                    Else
                        row.Item("Numero1") = dgvEnvioDetalle.Rows(i - 1).Cells("Enviado").Value
                    End If

                    If i > c Then
                        row.Item("Campo15") = ""
                    Else
                        row.Item("Campo15") = dgvEnvioDetalle.Rows(i - 1).Cells("CODIGODataGridViewTextBoxColumn").Value
                    End If

                    If i > c Then
                        row.Item("Campo16") = ""
                    Else
                        row.Item("Campo16") = dgvEnvioDetalle.Rows(i - 1).Cells("PRODUCTODataGridViewTextBoxColumn1").Value
                    End If

                    If i > c Then
                    Else
                        row.Item("Numero2") = drdatoscli("PRECIOVENTALISTA") / drdatoscli("COTIZACION1")
                    End If



                    ds.Tables("Detalle").Rows.Add(row)
                Next
            Next

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar Imprimir el registro" + ex.Message, "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ds.Dispose()
        Return ds
    End Function

    Private Sub txtRucChofer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRucChofer.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtVehiculo.Focus()
            KeyAscii = 0
        ElseIf KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtVehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVehiculo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtNroChapa.Focus()
            KeyAscii = 0
        ElseIf KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroChapa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroChapa.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtConductor.Focus()
            KeyAscii = 0
        ElseIf KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtConductor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConductor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtDireccion.Focus()
            KeyAscii = 0
        ElseIf KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            btnEnviar.Focus()
            KeyAscii = 0
        ElseIf KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnCerrarAnular_Click(sender As Object, e As EventArgs) Handles BtnCerrarAnular.Click
        pnlChofer.SendToBack()
        pnlChofer.Visible = False
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            CalculaNroRemision()
            ActualizarStockProductoEnvio(CStr(dgvFacturasSaldoEnvio.CurrentRow.Cells("NUMVENTADataGridViewTextBoxColumn").Value), 0)

            'verificamos sino ingreso datos en la parte de chofer que no se guarde nada
            If txtRucChofer.Text <> "" And txtConductor.Text <> "" And txtVehiculo.Text <> "" And txtNroChapa.Text <> "" Then
                GuardarChofer()
            End If

            AprobarEnvio()
            ActualizarVentasDetalle()

            cmd.ExecuteNonQuery()
            myTrans.Commit()

            ImprimirReporte()

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            sqlc.Close()
        End Try

        Try
            Me.ENVIOSDETALLETableAdapter.Fill(Me.DsEnvios.ENVIOSDETALLE)
            Me.ENVIOSTableAdapter.Fill(Me.DsEnvios.ENVIOS)
            Me.FACTURASCONSALDOENVIOTableAdapter.Fill(Me.DsEnvios.FACTURASCONSALDOENVIO)
        Catch ex As Exception

        End Try

        pnlChofer.SendToBack()
        pnlChofer.Visible = False

        DeshabilitaControles()
        NroRemision()
    End Sub

    Private Sub ActualizarVentasDetalle()
        Try
            sql = ""
            sql = "UPDATE VENTASDETALLE SET SALDOENVIO = 0 WHERE CODVENTA = " & dgvFacturasSaldoEnvio.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalculaNroRemision()
        Dim sql As String = ""

        Try
            Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString, NumRemision As String
            Dim NroDigitos, RangoID As Integer

            NumSucursal = SucCodigo
            NumMaquina = NumMaquinaGlobal

            sql = "SELECT dbo.DETPC.TIMBRADO, dbo.DETPC.NRODIGITOS, dbo.SUCURSAL.SUCURSALTIMBRADO, dbo.PC.NUMMAQUINA, dbo.DETPC.RANGO2, dbo.DETPC.ULTIMO, dbo.DETPC.ACTIVO, " & _
                  "dbo.TIPOCOMPROBANTE.NREMISION,dbo.DETPC.RANDOID   FROM dbo.DETPC INNER JOIN  dbo.SUCURSAL ON dbo.DETPC.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN " & _
                  "dbo.PC ON dbo.DETPC.IP = dbo.PC.IP INNER JOIN  dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                  "WHERE (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.NREMISION = 1)"

            Dim drdetpc As DataRow
            Dim dadetpc As New SqlDataAdapter(sql, ser.CadenaConexion)
            Dim dtdetpc As New DataTable
            dadetpc.Fill(dtdetpc)
            drdetpc = dtdetpc.Rows(0)

            'Validamos que haya rango para ese TipoComprobante
            NroRango = drdetpc("ULTIMO")
            NroRango = NroRango + 1

            NroRango2 = drdetpc("RANGO2")
            NroDigitos = drdetpc("NRODIGITOS")

            RangoID = drdetpc("RANDOID")

            If CDec(NroRango) > CDec(NroRango2) Then
                NumRemision = ""
                Exit Sub
            End If

            NumSucTimbrado = drdetpc("SUCURSALTIMBRADO")
            NumMaquina = drdetpc("NUMMAQUINA")

            NroRangoString = CStr(NroRango)
            For i = 1 To NroDigitos
                If Len(NroRangoString) = NroDigitos Then
                    Exit For
                Else
                    NroRangoString = "0" & NroRangoString
                End If
            Next

            NumRemision = NumSucTimbrado & "-" & NumMaquina & "-" & NroRangoString
            txtNroEnvio.Text = NumRemision

            If NumRemision = "" Then
                MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Quemamos el Nro 
            sql = " UPDATE DETPC SET ULTIMO =" & NroRango & " WHERE RANDOID =" & RangoID & ""

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NroRemision()
        Dim sql As String = ""

        Try
            Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString, NumRemision As String
            Dim NroDigitos, RangoID As Integer

            NumSucursal = SucCodigo
            NumMaquina = NumMaquinaGlobal

            sql = "SELECT dbo.DETPC.TIMBRADO, dbo.DETPC.NRODIGITOS, dbo.SUCURSAL.SUCURSALTIMBRADO, dbo.PC.NUMMAQUINA, dbo.DETPC.RANGO2, dbo.DETPC.ULTIMO, dbo.DETPC.ACTIVO, " & _
                  "dbo.TIPOCOMPROBANTE.NREMISION,dbo.DETPC.RANDOID   FROM dbo.DETPC INNER JOIN  dbo.SUCURSAL ON dbo.DETPC.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN " & _
                  "dbo.PC ON dbo.DETPC.IP = dbo.PC.IP INNER JOIN  dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                  "WHERE (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.NREMISION = 1)"

            Dim drdetpc As DataRow
            Dim dadetpc As New SqlDataAdapter(sql, ser.CadenaConexion)
            Dim dtdetpc As New DataTable
            dadetpc.Fill(dtdetpc)
            drdetpc = dtdetpc.Rows(0)

            'Validamos que haya rango para ese TipoComprobante
            NroRango = drdetpc("ULTIMO")
            NroRango = NroRango + 1

            NroRango2 = drdetpc("RANGO2")
            NroDigitos = drdetpc("NRODIGITOS")

            RangoID = drdetpc("RANDOID")

            If CDec(NroRango) > CDec(NroRango2) Then
                NumRemision = ""
                Exit Sub
            End If

            NumSucTimbrado = drdetpc("SUCURSALTIMBRADO")
            NumMaquina = drdetpc("NUMMAQUINA")

            NroRangoString = CStr(NroRango)
            For i = 1 To NroDigitos
                If Len(NroRangoString) = NroDigitos Then
                    Exit For
                Else
                    NroRangoString = "0" & NroRangoString
                End If
            Next

            NumRemision = NumSucTimbrado & "-" & NumMaquina & "-" & NroRangoString
            lblProximoNro.Text = "Próximo Nro : " & NumRemision
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GuardarChofer()
        sql = ""
        Try
            sql = "INSERT INTO CHOFERENVIO (ENVIOID, NOMBRE, RUC, VEHICULO, CHAPA, DIRECCION) " & _
                  "VALUES (" & dgvEnviosXFactura.CurrentRow.Cells("CODENVIODataGridViewTextBoxColumn").Value & ", " & _
                  "'" & txtConductor.Text & "', '" & txtRucChofer.Text & "', '" & txtVehiculo.Text & "', '" & txtNroChapa.Text & "', '" & txtDireccion.Text & "' )"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ImprimirReporte()

        'Ocultamos los Campos
        SALDO.Visible = False : STOCK.Visible = False : ENVIAR.Visible = False : Enviado.Visible = True
    End Sub

    Private Sub ImprimirReporte()
        Dim informe = New ReportesPersonalizados.Envios
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes

        'Obtenemos el Nombre de la impresora
        impresora = ObtenerImpresora()

        informe.PrintOptions.PaperSize = GetPapersizeID(impresora, "EnviosCogent")
        informe.SetDataSource(InfFactura())

        Try
            informe.PrintOptions.PrinterName = impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "RIA")
        End Try

        informe.PrintToPrinter(1, False, 0, 0)
        informe.Close() : informe.Dispose()
    End Sub

    Function ObtenerImpresora() As String
        Dim impName As String = ""
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT dbo.DETPC.IMPRESORA FROM dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                     "WHERE (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.NREMISION = 1)"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    impName = odrConfig("IMPRESORA")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try

        Return impName
    End Function

    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        Dim s As String = ""
        doctoprint.PrinterSettings.PrinterName = PrinterName '(ex."EpsonSQ-1170ESC/P2")
        For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function

    Private Sub pbxDatosChofer_Click(sender As Object, e As EventArgs) Handles pbxDatosChofer.Click
        pnlChofer.BringToFront()
        pnlChofer.Visible = True
        btnEnviar.Enabled = False
    End Sub

    Private Sub pbxReimprimir_Click(sender As Object, e As EventArgs) Handles pbxReimprimir.Click
        Try
            ImprimirReporte()
        Catch ex As Exception
            MessageBox.Show("Error al Imprimir", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub rbnFaltanEnviar_CheckedChanged(sender As Object, e As EventArgs) Handles rbnFaltanEnviar.CheckedChanged
        Try
            Me.FACTURASCONSALDOENVIOTableAdapter.Fill(Me.DsEnvios.FACTURASCONSALDOENVIO)

            If dgvFacturasSaldoEnvio.RowCount = 0 Then
                ENVIOSTableAdapter.FillBy(DsEnvios.ENVIOS, 0)
                ENVIOSDETALLETableAdapter.FillBy(DsEnvios.ENVIOSDETALLE, 0)
            End If

            dgvFacturasSaldoEnvio.Sort(dgvFacturasSaldoEnvio.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub rbnEnviados_CheckedChanged(sender As Object, e As EventArgs) Handles rbnEnviados.CheckedChanged
        Try
            Me.FACTURASCONSALDOENVIOTableAdapter.FillBy(Me.DsEnvios.FACTURASCONSALDOENVIO)
            dgvFacturasSaldoEnvio.Sort(dgvFacturasSaldoEnvio.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
        End Try
    End Sub

End Class