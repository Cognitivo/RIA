Public Class Importacion_uctrl

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    'Private Sub btnAprobar_Click(sender As System.Object, e As System.EventArgs)
    '    Dim combinar, I, compras, tporcent, tsubtotal, ttotal, tcant, AMovimiento, isChecked As Integer
    '    Dim tcantidad, tcostos As Double
    '    Dim objCommand As New SqlCommand
    '    Dim moduloID As Integer

    '    ser.Abrir(sqlc)
    '    Try
    '        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
    '    Catch ex As Exception
    '        myTrans.Rollback("Actualizar")
    '    End Try


    '    cmd.Connection = sqlc
    '    cmd.Transaction = myTrans

    '    combinar = 0
    '    If cbxprorrateo.Text = "" Then
    '        MessageBox.Show("Ingrese el tipo de Prorrateo", "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        cbxprorrateo.Focus()
    '        Exit Sub
    '    End If
    '    Try
    '        For I = 0 To dgvImportacion.RowCount - 1
    '            isChecked = dgvImportacion.Rows(I).Cells("Combinar").Value
    '            If isChecked = 1 Or isChecked = -1 Then
    '                combinar = 1
    '                compras = dgvImportacion.CurrentRow.Cells("CODCOMPRADataGridViewTextBoxColumn").Value
    '                'Exit Sub
    '            End If
    '        Next
    '        If combinar = 0 Then
    '            MessageBox.Show("Seleccione la compra", "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            pnlImportacion.BringToFront()
    '            'dgvImportacion.CurrentRow.Cells("").Value
    '            Exit Sub
    '        End If

    '        Dim totalCompras As Double
    '        Dim iva10, iva5, exenta, gravado10, gravado5, totaliva10, totaliva5, totalgravada10, totalgravada5, totalcompra, totaliva, totalexenta, cotizacion As Double
    '        Dim coddetalle As Integer = 0

    '        If cbxprorrateo.Text = "Costo" And combinar = 1 Then

    '            iva10 = 0 : iva5 = 0 : exenta = 0 : gravado10 = 0 : gravado5 = 0 : totaliva10 = 0 : totaliva5 = 0 : totalgravada10 = 0 : totalgravada5 = 0 : totalcompra = 0 : totaliva = 0 : totalexenta = 0 : cotizacion = 0

    '            objCommand.CommandText = " SELECT dbo.COMPRASDETALLE.CODCOMPRA, dbo.COMPRASDETALLE.CANTIDADCOMPRA, dbo.COMPRASDETALLE.TIPOIVA, dbo.COMPRASDETALLE.COSTOUNITARIO, dbo.COMPRASDETALLE.DESPRODUCTO, dbo.COMPRASDETALLE.CODCODIGO, " & _
    '                                     " dbo.PRODUCTOS.PRODUCTO, dbo.PRODUCTOS.SERVICIO, dbo.COMPRASDETALLE.CANTIDADCOMPRA * dbo.COMPRASDETALLE.COSTOUNITARIO AS SUBTOTAL, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.COTIZACION1 FROM dbo.COMPRASDETALLE INNER JOIN " & _
    '                                     " dbo.CODIGOS ON dbo.COMPRASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO INNER JOIN dbo.COMPRAS ON dbo.COMPRASDETALLE.CODCOMPRA = dbo.COMPRAS.CODCOMPRA " & _
    '                                     " WHERE (dbo.COMPRASDETALLE.CODCOMPRA = " & compras & ")"
    '            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
    '            objCommand.Connection.Open()
    '            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

    '            If odrConfig.HasRows Then
    '                sql = ""

    '                Do While odrConfig.Read()
    '                    moduloID = f.MaximoconWhere("MODULOTRANSID", "MOVPRODUCTO", "MODULO", 3)
    '                    AMovimiento = f.FuncionConsultaString("CODMOVIMIENTO", "MOVPRODUCTO", "MODULOTRANSID = " & compras & " AND MODULO = 3 AND CODCODIGO ", CDbl(odrConfig("CODCODIGO")))
    '                    tcostos = (odrConfig("SUBTOTAL") * odrConfig("COTIZACION1")) / CDbl(dgvImportacion.CurrentRow.Cells("TOTALCOMPRADataGridViewTextBoxColumn1").Value)
    '                    tporcent = tcostos * 100
    '                    tsubtotal = TotalTextBox1.Text * tporcent
    '                    ttotal = tsubtotal / 100
    '                    ttotal = (ttotal + (CDbl(odrConfig("SUBTOTAL"))) / CInt(odrConfig("CANTIDADCOMPRA")))

    '                    totalCompras = totalCompras + ttotal

    '                    Dim tipoiva As String = odrConfig("TIPOIVA").ToString
    '                    If tipoiva = "10,00" Then
    '                        iva10 = ttotal / 11
    '                        gravado10 = ttotal - iva10
    '                    ElseIf tipoiva = "5,00" Then
    '                        iva5 = ttotal / 21
    '                        gravado5 = ttotal - iva5
    '                    Else 'If odrConfig("TIPOIVA").ToString = "0,00" Then
    '                        exenta = ttotal
    '                    End If

    '                    totaliva10 = totaliva10 + iva10
    '                    totaliva5 = totaliva5 + iva5
    '                    totalexenta = totalexenta + exenta
    '                    totalgravada10 = totalgravada10 + gravado10
    '                    totalgravada5 = totalgravada5 + gravado5
    '                    totalcompra = totalcompra + ttotal
    '                    cotizacion = odrConfig("COTIZACION1")

    '                    'MODIFICA EL VALOR EN MOVPRODUCTO
    '                    sql = sql + " INSERT INTO MOVPRODUCTO (CODUSUARIO, CODCODIGO, CODDEPOSITO, FECHAMOVIMIENTO, MODULO, CANTIDAD, MODULOTRANSID, " & _
    '                                " VALOR, STOCK, CONCEPTO, COSTEABLE) VALUES (" & UsuCodigo & ", " & CInt(odrConfig("CODCODIGO")) & ", " & _
    '                                " " & CInt(CmbDeposito.SelectedValue) & ", CONVERT(DATETIME, '" & FechaFactTextBox.Text & "', 103), 3, " & _
    '                                " " & CInt(odrConfig("CANTIDADCOMPRA")) & ", " & CInt(moduloID + 1) & ", " & _
    '                                " " & CInt(ttotal / odrConfig("CANTIDADCOMPRA")) + CInt(odrConfig("COSTOUNITARIO")) & ", 1," & _
    '                                " 'Prorrateo por Costo Nro. Compra " & odrConfig("NUMCOMPRA") & "', 1)"

    '                    'INSERTA EN LA NUEVA BASE MOVPRODUCTODETALLE
    '                    sql = sql + " INSERT INTO MOVPRODUCTODETALLE (CODMOVIMIENTO, CODPRODUCTO, COSTO, COSTOIMPORT) " & _
    '                                " VALUES (" & AMovimiento & ", " & odrConfig("CODCODIGO") & ", " & CInt(odrConfig("COSTOUNITARIO")) & ", " & _
    '                                " " & CInt(ttotal / odrConfig("CANTIDADCOMPRA")) + CInt(odrConfig("COSTOUNITARIO")) & ")"

    '                Loop

    '                cmd.CommandText = sql
    '                cmd.ExecuteNonQuery()
    '            End If
    '            odrConfig.Close()
    '            objCommand.Dispose()

    '        ElseIf cbxprorrateo.Text = "Cantidad" And combinar = 1 Then

    '            iva10 = 0 : iva5 = 0 : exenta = 0 : gravado10 = 0 : gravado5 = 0 : totaliva10 = 0 : totaliva5 = 0 : totalgravada10 = 0 : totalgravada5 = 0 : totalcompra = 0

    '            objCommand.CommandText = ""
    '            objCommand.CommandText = "SELECT dbo.COMPRASDETALLE.CODCOMPRA, dbo.COMPRASDETALLE.CANTIDADCOMPRA, dbo.COMPRASDETALLE.COSTOUNITARIO, dbo.COMPRASDETALLE.DESPRODUCTO, dbo.COMPRASDETALLE.CODCODIGO, " & _
    '                                 "dbo.PRODUCTOS.PRODUCTO, dbo.PRODUCTOS.SERVICIO, dbo.COMPRASDETALLE.CANTIDADCOMPRA * dbo.COMPRASDETALLE.COSTOUNITARIO AS SUBTOTAL, dbo.COMPRAS.NUMCOMPRA FROM dbo.COMPRASDETALLE INNER JOIN " & _
    '                                 "dbo.CODIGOS ON dbo.COMPRASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO INNER JOIN dbo.COMPRAS ON dbo.COMPRASDETALLE.CODCOMPRA = dbo.COMPRAS.CODCOMPRA " & _
    '                                 " WHERE (dbo.PRODUCTOS.PRODUCTO = 0) AND (dbo.PRODUCTOS.SERVICIO = 0) AND (dbo.COMPRASDETALLE.CODCOMPRA = " & compras & ")"
    '            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
    '            objCommand.Connection.Open()
    '            Dim odrConfig1 As SqlDataReader = objCommand.ExecuteReader()
    '            tcant = 0

    '            If odrConfig1.HasRows Then
    '                Do While odrConfig1.Read()
    '                    tcant = tcant + odrConfig1("CANTIDADCOMPRA")
    '                Loop
    '            End If

    '            objCommand.CommandText = " SELECT dbo.COMPRASDETALLE.CODCOMPRA, dbo.COMPRASDETALLE.CANTIDADCOMPRA, dbo.COMPRASDETALLE.TIPOIVA, dbo.COMPRASDETALLE.COSTOUNITARIO, dbo.COMPRASDETALLE.DESPRODUCTO, dbo.COMPRASDETALLE.CODCODIGO, " & _
    '                                     " dbo.PRODUCTOS.PRODUCTO, dbo.PRODUCTOS.SERVICIO, dbo.COMPRASDETALLE.CANTIDADCOMPRA * dbo.COMPRASDETALLE.COSTOUNITARIO AS SUBTOTAL, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.COTIZACION1 FROM dbo.COMPRASDETALLE INNER JOIN " & _
    '                                     " dbo.CODIGOS ON dbo.COMPRASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO INNER JOIN dbo.COMPRAS ON dbo.COMPRASDETALLE.CODCOMPRA = dbo.COMPRAS.CODCOMPRA " & _
    '                                     " WHERE (dbo.COMPRASDETALLE.CODCOMPRA = " & compras & ")"
    '            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
    '            objCommand.Connection.Open()
    '            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

    '            If odrConfig.HasRows Then
    '                sql = ""
    '                Do While odrConfig.Read()
    '                    moduloID = f.MaximoconWhere("MODULOTRANSID", "MOVPRODUCTO", "MODULO", 3)
    '                    AMovimiento = f.FuncionConsultaString("CODMOVIMIENTO", "MOVPRODUCTO", "MODULOTRANSID = " & compras & " AND MODULO = 3 AND CODCODIGO ", CDbl(odrConfig("CODCODIGO")))
    '                    tcantidad = odrConfig("CANTIDADCOMPRA") / CDbl(tcant)
    '                    tporcent = tcantidad * 100
    '                    tsubtotal = TotalTextBox1.Text * tporcent
    '                    ttotal = tsubtotal / 100
    '                    ttotal = (ttotal + CDbl(odrConfig("SUBTOTAL"))) / CInt(odrConfig("CANTIDADCOMPRA"))

    '                    totalCompras = totalCompras + ttotal

    '                    Dim tipoiva As String = odrConfig("TIPOIVA").ToString
    '                    If tipoiva = "10,00" Then
    '                        iva10 = ttotal / 11
    '                        gravado10 = ttotal - iva10
    '                    ElseIf tipoiva = "5,00" Then
    '                        iva5 = ttotal / 21
    '                        gravado5 = ttotal - iva5
    '                    Else 'If odrConfig("TIPOIVA").ToString = "0,00" Then
    '                        exenta = ttotal
    '                    End If

    '                    totaliva10 = totaliva10 + iva10
    '                    totaliva5 = totaliva5 + iva5
    '                    totalexenta = totalexenta + exenta
    '                    totalgravada10 = totalgravada10 + gravado10
    '                    totalgravada5 = totalgravada5 + gravado5
    '                    totalcompra = totalcompra + ttotal
    '                    cotizacion = odrConfig("COTIZACION1")

    '                    'MODIFICA EL VALOR EN MOVPRODUCTO
    '                    sql = sql + " INSERT INTO MOVPRODUCTO (CODUSUARIO, CODCODIGO, CODDEPOSITO, FECHAMOVIMIENTO, MODULO, CANTIDAD, MODULOTRANSID, " & _
    '                                " VALOR, STOCK, CONCEPTO, COSTEABLE) VALUES (" & UsuCodigo & ", " & CInt(odrConfig("CODCODIGO")) & ", " & _
    '                                " " & CInt(CmbDeposito.SelectedValue) & ", CONVERT(DATETIME, '" & FechaFactTextBox.Text & "', 103), 3, " & _
    '                                " " & CInt(odrConfig("CANTIDADCOMPRA")) & ", " & CInt(moduloID + 1) & ", " & _
    '                                " " & CInt(ttotal / odrConfig("CANTIDADCOMPRA")) + CInt(odrConfig("COSTOUNITARIO")) & ", 1," & _
    '                                " 'Prorrateo por Costo Nro. Compra " & odrConfig("NUMCOMPRA") & "', 1)"

    '                    'INSERTA EN LA NUEVA BASE MOVPRODUCTODETALLE
    '                    sql = sql + " INSERT INTO MOVPRODUCTODETALLE (CODMOVIMIENTO, CODPRODUCTO, COSTO, COSTOIMPORT) " & _
    '                                " VALUES (" & AMovimiento & ", " & odrConfig("CODCODIGO") & ", " & CInt(odrConfig("COSTOUNITARIO")) & ", " & _
    '                                " " & CInt(ttotal + CInt(odrConfig("COSTOUNITARIO"))) & ")"
    '                Loop

    '                cmd.CommandText = sql
    '                cmd.ExecuteNonQuery()

    '            End If
    '            odrConfig.Close()
    '            odrConfig1.Close()
    '            objCommand.Dispose()
    '        End If
    '        sql = ""
    '        sql = " UPDATE IMPORTACION SET ESTADO = 2 WHERE CODCOMPRA = " & compras & " UPDATE COMPRAS SET IMPORTACIONRELACION = " & compras & " WHERE CODCOMPRA = " & ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

    '        cmd.CommandText = sql
    '        cmd.ExecuteNonQuery()
    '        myTrans.Commit()

    '        MessageBox.Show("Prorrateo Exitoso", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    Catch ex As Exception
    '        myTrans.Rollback("Actualizar")
    '        If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
    '            MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    End Try
    'End Sub
End Class
