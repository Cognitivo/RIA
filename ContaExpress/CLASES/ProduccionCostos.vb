'###########################################################################################################
' Modulo de Costos de Produccion - by : Yolanda Zelaya
'###########################################################################################################
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad

Module ProduccionCostos

#Region "Fields"
    'Varibles Locales
    Private w As New Funciones.Funciones
    Private objCommand As New SqlCommand
    Private ser As BDConexión.BDConexion
    Private consulta As System.String
    Private conexion As System.Data.SqlClient.SqlConnection
    Private myTrans As System.Data.SqlClient.SqlTransaction
#End Region

#Region "Methods"
    Sub New()
        ser = New BDConexión.BDConexion()
    End Sub

    Public Sub ProduccionCosteo(ByVal IDPRODCAB As Integer)
        Dim CostoUnitario, CostoTotal As Double
        Dim CadenaSql As String = ""

        CostoTotal = 0

        'Obtenemos la Produccion Detalle Operacion corespondiente a la Produccion Cabecera
        conexion = ser.Abrir()

        objCommand.CommandText = "SELECT dbo.PRODUCCIONDETOPERACION.IDPRODCAB, dbo.PRODUCCIONDETOPERACION.IDRELACION, dbo.PRODUCCIONDETOPERACION.DESCRIPTIPORELACION, " & _
                                 "dbo.PRODUCCIONDETOPERACION.CANTIDAD, dbo.PRODUCCIONDETOPERACION.UNIDADMEDIDA, dbo.PRODUCTOS.DESPRODUCTO, dbo.CODIGOS.PRECIO, " & _
                                 "dbo.PRODUCCIONDETOPERACION.COSTO, dbo.CODIGOS.CODPRODUCTO, dbo.CODIGOS.CODCODIGO, dbo.PRODUCCIONCAB.CODUSUARIO, dbo.PRODUCCIONCAB.CODSUCURSAL  " & _
                                 "FROM dbo.PRODUCCIONDETOPERACION INNER JOIN dbo.CODIGOS ON dbo.PRODUCCIONDETOPERACION.IDRELACION = dbo.CODIGOS.CODCODIGO INNER JOIN " & _
                                 "dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO INNER JOIN dbo.PRODUCCIONCAB ON dbo.PRODUCCIONDETOPERACION.IDPRODCAB = dbo.PRODUCCIONCAB.IDPRODCAB " & _
                                 "WHERE (dbo.PRODUCCIONDETOPERACION.IDPRODCAB = " & IDPRODCAB & ") "

        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        objCommand.Connection.Open()
        Dim odrProduccion As SqlDataReader = objCommand.ExecuteReader()

        If odrProduccion.HasRows Then
            Do While odrProduccion.Read()
                '1ro Obtenemos el Costo Unitario (Costo * Consumo)
                CostoUnitario = odrProduccion("PRECIO") * odrProduccion("CANTIDAD")

                '2do el Costo Total
                CostoTotal = CostoTotal + CostoUnitario

                '3ro Guardamos el Costo Unitario en la Tabla PRODUCCIONDETOPERACION y Descontamos el Stock de la Materia Prima
                Try
                    CadenaSql = "UPDATE PRODUCCIONDETOPERACION SET COSTO = " & CostoUnitario & " WHERE IDPRODCAB=" & IDPRODCAB & " AND IDRELACION=" & odrProduccion("IDRELACION") & "    "
                    CadenaSql = CadenaSql + "UPDATE STOCKDEPOSITO SET STOCKACTUAL = STOCKACTUAL -" & odrProduccion("CANTIDAD") & "   " & _
                                "WHERE CODDEPOSITO=" & odrProduccion("CODSUCURSAL") & " AND CODCODIGO = " & odrProduccion("CODCODIGO")

                    consulta = CadenaSql

                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                Catch ex As Exception
                    MessageBox.Show("Problema al Guardar el costo " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            Loop
        End If

        odrProduccion.Close()
        objCommand.Dispose()

        'PRODUCCIONDETPRODUCTO 

        objCommand.CommandText = "SELECT dbo.PRODUCCIONDETPRODUCTO.CODCODIGO, dbo.PRODUCCIONDETPRODUCTO.CANTIDAD, dbo.PRODUCCIONDETPRODUCTO.IDPRODCAB,dbo.PRODUCCIONCAB.FECHAINICIO,  " & _
                                 "dbo.PRODUCCIONDETPRODUCTO.DESCRIPRODUCTO, dbo.CODIGOS.CODPRODUCTO, dbo.PRODUCCIONCAB.CODUSUARIO, dbo.PRODUCCIONCAB.CODSUCURSAL   " & _
                                 "FROM  dbo.PRODUCCIONDETPRODUCTO INNER JOIN dbo.CODIGOS ON dbo.PRODUCCIONDETPRODUCTO.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN " & _
                                 "dbo.PRODUCCIONCAB ON dbo.PRODUCCIONDETPRODUCTO.IDPRODCAB = dbo.PRODUCCIONCAB.IDPRODCAB   " & _
                                 "WHERE (dbo.PRODUCCIONDETPRODUCTO.IDPRODCAB = " & IDPRODCAB & ") "

        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        objCommand.Connection.Open()

        odrProduccion = objCommand.ExecuteReader()

        If odrProduccion.HasRows Then
            Do While odrProduccion.Read()
                Dim CostoTotalString As String

                '4to Obtenemos el Costo Total por Producto
                CostoTotal = FormatNumber(CostoTotal / odrProduccion("CANTIDAD"), 2)
                CostoTotalString = Funciones.Cadenas.QuitarCad(CostoTotal, ".")
                CostoTotalString = Replace(CostoTotalString, ",", ".")

                '5to Insertamos en la Tabla [MOVIMIENTOPRODUCTO]
                Try
                    consulta = "INSERT INTO MOVIMIENTOPRODUCTO (CODPRODUCTO,CODCODIGO,CONCEPTO,TIPOMOVIMIENTO,CANTIDAD,FECHAMTO,CODUSUARIO,NUMCOMPROVANTE,CODSUCURSAL,IMPORTE) " & _
                               "VALUES(" & odrProduccion("CODPRODUCTO") & "," & odrProduccion("CODCODIGO") & ",'ENTRADA POR PRODUCCION', 'ENTRADA', " & _
                               odrProduccion("CANTIDAD") & ",CONVERT(DATETIME, GETDATE(), 103)," & odrProduccion("CODUSUARIO") & "," & IDPRODCAB & "," & _
                               odrProduccion("CODSUCURSAL") & "," & CostoTotalString & ")"

                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                Catch ex As Exception
                    MessageBox.Show("Problema Insertar en Movimientos de Productos " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try

                '6to Aumentos el Stock de la Produccion
                Try
                    'Verificamos si el Producto Existe. 
                    Dim ExisteProducto As Integer
                    ExisteProducto = w.FuncionConsultaDecimal("CODCODIGO", "STOCKDEPOSITO", "CODCODIGO", odrProduccion("CODCODIGO"))

                    If ExisteProducto = 0 Then
                        consulta = "INSERT INTO STOCKDEPOSITO (CODDEPOSITO,CODPRODUCTO,STOCKACTUAL,FECGRA,CODCODIGO)  " & _
                                   "VALUES (" & odrProduccion("CODSUCURSAL") & "," & odrProduccion("CODPRODUCTO") & "," & odrProduccion("CANTIDAD") & ",CONVERT(DATETIME, GETDATE(), 103)," & _
                                    odrProduccion("CODCODIGO") & ")"
                    Else
                        consulta = "UPDATE STOCKDEPOSITO SET STOCKACTUAL = STOCKACTUAL +" & odrProduccion("CANTIDAD") & "   " & _
                                "WHERE CODDEPOSITO=" & odrProduccion("CODSUCURSAL") & " AND CODCODIGO = " & odrProduccion("CODCODIGO")
                    End If

                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                Catch ex As Exception
                    MessageBox.Show("Problema al Aumentaer el Stock " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            Loop
        End If
        odrProduccion.Close()
        objCommand.Dispose()
    End Sub

    Public Sub AnularProduccion(ByVal IDPRODCAB As Integer)
        conexion = ser.Abrir()

        'Aumentamos el Stock de la Materia Prima
        objCommand.CommandText = "SELECT dbo.PRODUCCIONDETOPERACION.IDPRODCAB, dbo.PRODUCCIONDETOPERACION.IDRELACION, dbo.PRODUCCIONDETOPERACION.DESCRIPTIPORELACION, " & _
                                 "dbo.PRODUCCIONDETOPERACION.CANTIDAD, dbo.PRODUCCIONDETOPERACION.UNIDADMEDIDA, dbo.PRODUCTOS.DESPRODUCTO, dbo.CODIGOS.PRECIO, " & _
                                 "dbo.PRODUCCIONDETOPERACION.COSTO, dbo.CODIGOS.CODPRODUCTO, dbo.CODIGOS.CODCODIGO, dbo.PRODUCCIONCAB.CODUSUARIO, dbo.PRODUCCIONCAB.CODSUCURSAL  " & _
                                 "FROM dbo.PRODUCCIONDETOPERACION INNER JOIN dbo.CODIGOS ON dbo.PRODUCCIONDETOPERACION.IDRELACION = dbo.CODIGOS.CODCODIGO INNER JOIN " & _
                                 "dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO INNER JOIN dbo.PRODUCCIONCAB ON dbo.PRODUCCIONDETOPERACION.IDPRODCAB = dbo.PRODUCCIONCAB.IDPRODCAB " & _
                                 "WHERE (dbo.PRODUCCIONDETOPERACION.IDPRODCAB = " & IDPRODCAB & ") "

        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        objCommand.Connection.Open()
        Dim odrProduccion As SqlDataReader = objCommand.ExecuteReader()

        If odrProduccion.HasRows Then
            Do While odrProduccion.Read()
                Try
                    consulta = "UPDATE STOCKDEPOSITO SET STOCKACTUAL = STOCKACTUAL +" & odrProduccion("CANTIDAD") & "   " & _
                                "WHERE CODDEPOSITO=" & odrProduccion("CODSUCURSAL") & " AND CODCODIGO = " & odrProduccion("CODCODIGO")

                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                Catch ex As Exception
                    MessageBox.Show("Problema Aumentar Stock de Materia Prima " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            Loop
        End If

        odrProduccion.Close()
        objCommand.Dispose()

        'Descontamos el Stock del Producto
        objCommand.CommandText = "SELECT dbo.PRODUCCIONDETPRODUCTO.CODCODIGO, dbo.PRODUCCIONDETPRODUCTO.CANTIDAD, dbo.PRODUCCIONDETPRODUCTO.IDPRODCAB,dbo.PRODUCCIONCAB.FECHAINICIO,  " & _
                                 "dbo.PRODUCCIONDETPRODUCTO.DESCRIPRODUCTO, dbo.CODIGOS.CODPRODUCTO, dbo.PRODUCCIONCAB.CODUSUARIO, dbo.PRODUCCIONCAB.CODSUCURSAL   " & _
                                 "FROM  dbo.PRODUCCIONDETPRODUCTO INNER JOIN dbo.CODIGOS ON dbo.PRODUCCIONDETPRODUCTO.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN " & _
                                 "dbo.PRODUCCIONCAB ON dbo.PRODUCCIONDETPRODUCTO.IDPRODCAB = dbo.PRODUCCIONCAB.IDPRODCAB   " & _
                                 "WHERE (dbo.PRODUCCIONDETPRODUCTO.IDPRODCAB = " & IDPRODCAB & ") "

        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        objCommand.Connection.Open()

        odrProduccion = objCommand.ExecuteReader()

        If odrProduccion.HasRows Then
            Do While odrProduccion.Read()
                Try
                    consulta = "UPDATE STOCKDEPOSITO SET STOCKACTUAL = STOCKACTUAL -" & odrProduccion("CANTIDAD") & "   " & _
                                "WHERE CODDEPOSITO=" & odrProduccion("CODSUCURSAL") & " AND CODCODIGO = " & odrProduccion("CODCODIGO")


                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                Catch ex As Exception
                    MessageBox.Show("Problema al Descontar el Stock " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            Loop
        End If

        odrProduccion.Close()
        objCommand.Dispose()
    End Sub
#End Region
End Module
