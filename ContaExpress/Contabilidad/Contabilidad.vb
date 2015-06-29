'###########################################################################################################
' Modulo de contablidad - by : Yolanda Zelaya
'###########################################################################################################
Imports System.Data.SqlClient
'Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad

Module Contabilidad

#Region "Fields"
    'Varibles Locales
    Private w As New Funciones.Funciones
    Private UsarPlantilla As Integer
    Private IsExisteRegla, IsExisteReglaFK, PeriodoFiscalActivo, CodCuenta As Integer
    Private ReglaGenerica, ReglaEspecifica As Integer

    Private SeGuardo, ImporteD, ImporteH, DebeHaber, DescripCuenta As String
    Private Monto As Double

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

    'Estirando los Variables para Usar
    Public Sub ReglaContable(ByVal CONT_MontoExcenta As String, ByVal CONT_MontoIva5 As String, ByVal CONT_MontoIva10 As String, _
                             ByVal CONT_MontoTotalIva As String, ByVal CONT_TablaConsulta As String, ByVal CONT_CodTrans As Double, _
                             ByVal CONT_CampWhere As String, ByVal CONT_ConceptoAsiento As String, ByVal CONT_RgMerc As Integer, _
                             ByVal CONT_RgMonet As Integer, ByVal CONT_Moneda As Double, ByVal CONT_Cotizacion As Double, ByVal CONT_NroTrans As String, _
                             ByVal CONT_Fecha As String, ByVal CONT_TotalMontoTrans As Double, ByVal CONT_ModuloID As Integer, ByVal CONT_Timbrado As String, _
                             ByVal CONT_PersonaID As Integer, ByVal CONT_Sucursal As Integer, Optional CONT_Tratamiento As Integer = 0)

        SeGuardo = 0 'Varible para saber si se acento correctamente
        Dim codventadev As Integer

        '1ro - Debemos saber que plantilla usar
        If CONT_ModuloID = 11 Then
            UsarPlantilla = w.FuncionConsultaDecimal("MAX(PlantillaID)", "PLANTILLA", "ModuloID = " & CONT_ModuloID & " AND ReglaMercaderia", CONT_RgMerc) 'SOLO SABER SI TIENE PLANTILLA EN EL MODULO, DESPUES HACEMOS PREGUNTAS MAS ESPECIFICAS
        Else
            UsarPlantilla = w.FuncionConsultaDecimal("PlantillaID", "PLANTILLA", "ModuloID = " & CONT_ModuloID & " AND ReglaMercaderia =" & CONT_RgMerc & " AND ReglaMonetaria", CONT_RgMonet)
        End If

        '2do - Una ves que sabes que plantilla usaremos se debe obtener todas las reglas o cuentas que dicha plantilla usa
        If UsarPlantilla <> 0 Then
            If CONT_ModuloID <> 11 Then
                conexion = ser.Abrir()

                'Obtenemos el Periodo Fiscal
                PeriodoFiscalActivo = w.FuncionConsultaDecimal("CODPERIODOFISCAL", "periodofiscal", "ESTADO", 1)

                ' - - - - - Vemos que tipo de reglas contiene la platilla seleccionada y en base a eso se arma el asiento contable
                IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 5)
                If (IsExisteRegla <> 0) Then 'IVA 5%
                    Monto = CONT_MontoIva5
                    GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                End If

                IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 10)
                If (IsExisteRegla <> 0) Then 'IVA 10%
                    Monto = CONT_MontoIva10
                    GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                End If

                IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 9)
                If (IsExisteRegla <> 0) Then 'Excenta
                    Monto = CONT_MontoExcenta
                    GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                End If

                'MOVIEMIENTO DE CAJA GENERICO/ESPECIFICO
                IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
                IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", NumCaja)
                Monto = CONT_TotalMontoTrans

                If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico
                    GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 1, CONT_RgMonet, CONT_Sucursal)

                Else 'Movimiento de Caja Generico
                    IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
                    If (IsExisteRegla <> 0) Then
                        GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                    End If
                End If
            End If

            'Verificamos de que modulo
            If (CONT_ModuloID = 8) Then 'Ventas
                IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 6)

                If (IsExisteRegla <> 0) Then
                    objCommand.CommandText = "SELECT MAX((round(dbo.VENTAS.TOTAL10,0)*11/1.1) " & _
                                              "+ (round(dbo.VENTAS.TOTAL5,0)*21/1.05) + round(dbo.VENTAS.TOTALEXENTA,0)) AS total,  " & _
                                              "dbo.VENTAS.CODVENTA, dbo.plancuentas.REGLA, dbo.plancuentas.REGLAFK, dbo.plancuentas.CODPLANCUENTA " & _
                                              "FROM dbo.plancuentas INNER JOIN dbo.PRODUCTOS ON dbo.plancuentas.REGLAFK = dbo.PRODUCTOS.PRODUCTO INNER JOIN  " & _
                                              "dbo.VENTASDETALLE ON dbo.PRODUCTOS.CODPRODUCTO = dbo.VENTASDETALLE.CODPRODUCTO INNER JOIN " & _
                                              "dbo.VENTAS ON dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA " & _
                                              "GROUP BY dbo.plancuentas.REGLAFK, dbo.VENTAS.CODVENTA, dbo.plancuentas.REGLA, dbo.plancuentas.CODPLANCUENTA " & _
                                              "HAVING(dbo.VENTAS.CODVENTA =" & CONT_CodTrans & ") And (dbo.plancuentas.REGLA = 6) And (dbo.plancuentas.REGLAFK <> 3)"

                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()
                    ' Dim codplancuenta As Integer

                    If odrPlanilla.HasRows Then
                        Do While odrPlanilla.Read()
                            '   codplancuenta = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 6)

                            Monto = Math.Round(odrPlanilla("TOTAL"), 0)
                            IsExisteReglaFK = odrPlanilla("CODPLANCUENTA")
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 1, CONT_RgMonet, CONT_Sucursal)
                        Loop
                    End If

                    odrPlanilla.Close()
                    objCommand.Dispose()
                End If

                ReglaEspecifica = 1 'Cliente Especifico
                ReglaGenerica = 2 'Cliente Generico

            ElseIf (CONT_ModuloID = 3) Then 'Compras
                IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 11)

                If (IsExisteRegla <> 0) Then
                    objCommand.CommandText = "SELECT dbo.CENTROCOSTO.DESCENTRO, SUM((dbo.COMPRASDETALLE.IMPORTEGRAVADO10 - dbo.COMPRASDETALLE.IMPORTEGRAVADO10 / 11) " & _
                                             "+ (dbo.COMPRASDETALLE.IMPORTEGRAVADO5 - dbo.COMPRASDETALLE.IMPORTEGRAVADO5 / 21) + dbo.COMPRASDETALLE.IMPORTEEXENTO) AS total, " & _
                                             "dbo.COMPRASDETALLE.CODCOMPRA, dbo.CENTROCOSTO.CODCENTRO, dbo.plancuentas.REGLA, dbo.plancuentas.REGLAFK,dbo.plancuentas.CODPLANCUENTA " & _
                                             "FROM dbo.COMPRASDETALLE INNER JOIN dbo.CENTROCOSTO ON dbo.COMPRASDETALLE.CODCENTRO = dbo.CENTROCOSTO.CODCENTRO INNER JOIN " & _
                                             "dbo.plancuentas ON dbo.CENTROCOSTO.CODCENTRO = dbo.plancuentas.REGLAFK " & _
                                             "GROUP BY dbo.CENTROCOSTO.DESCENTRO, dbo.COMPRASDETALLE.CODCOMPRA, dbo.CENTROCOSTO.CODCENTRO, dbo.plancuentas.REGLA, " & _
                                             "dbo.plancuentas.CODPLANCUENTA , dbo.plancuentas.REGLAFK HAVING (dbo.COMPRASDETALLE.CODCOMPRA  =" & CONT_CodTrans & ") AND (dbo.plancuentas.REGLA = 11)"

                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()
                    Dim codplancuenta As Integer

                    If odrPlanilla.HasRows Then
                        Do While odrPlanilla.Read()
                            '**********************
                            codplancuenta = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 6)
                            '**********************
                            Monto = Math.Round(odrPlanilla("TOTAL"), 0)
                            IsExisteReglaFK = odrPlanilla("CODPLANCUENTA")
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 1, CONT_RgMonet, CONT_Sucursal)
                        Loop
                    End If

                    odrPlanilla.Close()
                    objCommand.Dispose()
                End If

                ReglaEspecifica = 3 'Proveedor Especifico
                ReglaGenerica = 4 'Proveedor Generico

            ElseIf (CONT_ModuloID = 11) Then 'Nota de Crédito (Venta)
                Dim regmonet, regdevmerc, regdevdinero As Integer

                'PREGUNTAMOS DIRECTAMENTE PORQUE AQUI SE ENCUENTRAN LAS VARIANTES
                objCommand.CommandText = "SELECT CODDEVOLUCION, NUMDEVOLUCION, FECHADEVOLUCION, TOTALDEVOLUCION, SUM(TOTALSINIVA) AS TOTALSINIVA, DESCARTAR, DEVTRATAMIENTO, CODVENTA, SALDOVENTA, TIPOVENTA " & _
                                         "FROM ((SELECT DEVOLUCIONDETALLE.CODDEVOLUCION, DEVOLUCIONDETALLE.CODCODIGO, DEVOLUCION.NUMDEVOLUCION, (DEVOLUCION.TOTALDEVOLUCION * DEVOLUCION.COTIZACION1) AS TOTALDEVOLUCION, CONVERT(varchar(10),DEVOLUCION.FECHADEVOLUCION,103) AS FECHADEVOLUCION, " & _
                                         "CASE WHEN iva = 10 THEN ROUND((((DEVOLUCIONDETALLE.CANTIDADDEVUELTA * DEVOLUCIONDETALLE.PRECIONETO)) " & _
                                         "- ((DEVOLUCIONDETALLE.CANTIDADDEVUELTA * DEVOLUCIONDETALLE.PRECIONETO) / 11)) * DEVOLUCION.COTIZACION1, 0) " & _
                                         "WHEN iva = 5 THEN ROUND((((DEVOLUCIONDETALLE.CANTIDADDEVUELTA * DEVOLUCIONDETALLE.PRECIONETO)) " & _
                                         "- ((DEVOLUCIONDETALLE.CANTIDADDEVUELTA * DEVOLUCIONDETALLE.PRECIONETO) / 21) * DEVOLUCION.COTIZACION1), 0) " & _
                                         "ELSE ROUND((((DEVOLUCIONDETALLE.CANTIDADDEVUELTA * DEVOLUCIONDETALLE.PRECIONETO)) * DEVOLUCION.COTIZACION1), 0) END AS TOTALSINIVA, DEVOLUCIONDETALLE.DESCARTAR,DEVOLUCION.DEVTRATAMIENTO,DEVOLUCION.CODVENTA,V.TIPOVENTA,(SELECT SUM(SALDOCUOTA * FACTURACOBRAR.COTIZACION) AS Expr1 FROM dbo.FACTURACOBRAR WHERE (CODVENTA = V.CODVENTA)) AS SALDOVENTA " & _
                                         "FROM dbo.DEVOLUCION INNER JOIN " & _
                                         "DEVOLUCIONDETALLE ON DEVOLUCION.CODDEVOLUCION = DEVOLUCIONDETALLE.CODDEVOLUCION LEFT OUTER JOIN VENTAS AS V ON DEVOLUCION.CODVENTA = V.CODVENTA)) AS SUBCONSULTA " & _
                                         "GROUP BY CODDEVOLUCION,NUMDEVOLUCION, TOTALDEVOLUCION, FECHADEVOLUCION, DESCARTAR, DEVTRATAMIENTO, CODVENTA, TIPOVENTA, SALDOVENTA " & _
                                         "HAVING (CODDEVOLUCION =" & CONT_CodTrans & ")"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()

                If odrPlanilla.HasRows Then
                    Do While odrPlanilla.Read()
                        codventadev = odrPlanilla("CODVENTA")
                        If odrPlanilla("DESCARTAR") = 0 Then 'SIN DEVOLUCION DE MERCADERIA
                            regdevmerc = 0
                            If odrPlanilla("CODVENTA") = 0 Then 'NO TIENE FACTURA ASOCIADA

                                regmonet = 1
                                regdevdinero = 0

                            Else
                                If odrPlanilla("TIPOVENTA") = 0 Then 'FACT. ASOCIADA CONTADO
                                    regdevdinero = 0
                                    regmonet = 1
                                Else 'FACT. ASOCIADA CREDITO
                                    If odrPlanilla("SALDOVENTA") = 0 Then 'No Tiene saldo
                                        regdevdinero = 0
                                        regmonet = 2
                                    Else 'Tiene Saldo
                                        'CUENTA DESCUENTOS OTORGADOS A CLIENTES
                                        regmonet = 4
                                        regdevdinero = 0
                                    End If
                                End If
                            End If
                        Else 'CON DEVOLUCION DE MERCADERIA
                            regdevmerc = 1
                            If odrPlanilla("CODVENTA") = 0 Then 'NO TIENE FACTURA ASOCIADA
                                
                                regmonet = 1
                                regdevdinero = 0

                            Else
                                If odrPlanilla("TIPOVENTA") = 0 Then 'FACT. ASOCIADA CONTADO
                                    If odrPlanilla("DEVTRATAMIENTO") = 0 Then 'NO DEVOLVER PLATA
                                        regmonet = 1
                                        regdevdinero = 0
                                    Else 'DEVOLVER PLATA
                                        regmonet = 1
                                        regdevdinero = 1
                                    End If
                                Else 'FACT. ASOCIADA CREDITO
                                    If odrPlanilla("SALDOVENTA") = 0 Then 'No Tiene saldo
                                        If odrPlanilla("DEVTRATAMIENTO") = 0 Then 'NO DEVOLVER PLATA
                                            regmonet = 2
                                            regdevdinero = 0
                                        Else 'DEVOLVER PLATA
                                            regmonet = 2
                                            regdevdinero = 1
                                        End If
                                    Else 'Tiene Saldo - descuento a clientes
                                        regmonet = 4
                                        regdevdinero = 0
                                    End If
                                End If
                            End If
                        End If
                        CONT_RgMonet = regmonet

                        conexion = ser.Abrir()

                        'Obtenemos el Periodo Fiscal
                        PeriodoFiscalActivo = w.FuncionConsultaDecimal("CODPERIODOFISCAL", "periodofiscal", "ESTADO", 1)

                        ' - - - - - Vemos que tipo de reglas contiene la platilla seleccionada y en base a eso se arma el asiento contable
                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 5)
                        If (IsExisteRegla <> 0) Then 'IVA 5%
                            Monto = CONT_MontoIva5
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                        End If

                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 10)
                        If (IsExisteRegla <> 0) Then 'IVA 10%
                            Monto = CONT_MontoIva10
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                        End If

                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 9)
                        If (IsExisteRegla <> 0) Then 'Excenta
                            Monto = CONT_MontoExcenta
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                        End If

                        'MOVIEMIENTO DE CAJA GENERICO/ESPECIFICO
                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 8)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", NumCaja)
                        Monto = CONT_TotalMontoTrans

                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)

                        Else 'Movimiento de Caja Generico
                            IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 7)
                            If (IsExisteRegla <> 0) Then
                                GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                            End If
                        End If

                        'Venta de Productos o Servicios
                        If regdevmerc = 0 Then
                            Monto = Math.Round(odrPlanilla("TOTALDEVOLUCION"), 0)
                        Else
                            Monto = Math.Round(odrPlanilla("TOTALSINIVA"), 0)
                        End If

                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 6)
                        IsExisteReglaFK = 0
                        GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)

                        ReglaEspecifica = 1 'Cliente Especifico
                        ReglaGenerica = 2 'Cliente Generico

                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", ReglaEspecifica)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA =" & ReglaEspecifica & "AND REGLAFK", CONT_PersonaID)

                        'CLIENTE/PROVEEDOR ESPECIFICO/GENERICO
                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'CLIENTE/PROVEEDOR ESPECIFICO
                            Monto = CONT_TotalMontoTrans
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 1, CONT_RgMonet, CONT_Sucursal)

                        Else 'CLIENTE/PROVEEDOR GENERICO
                            IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", ReglaGenerica)
                            If (IsExisteRegla <> 0) Then
                                Monto = CONT_TotalMontoTrans
                                GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                            End If
                        End If
                    Loop
                End If


            ElseIf (CONT_ModuloID = 29) Then
                Dim regmonet, regdevmerc, regdevdinero As Integer
                objCommand.CommandText = "SELECT CODDEVOLUCION,NUMDEVOLUCION,FECHADEVOLUCION,TOTALDEVOLUCION,'TOTALSINIVA'=SUM(TOTALSINIVA), DESCARTAR, CODCOMPRA, SALDOCOMPRA, MODALIDADPAGO FROM " & _
                    "((SELECT DEVOLUCIONCOMPRADETALLE.CODDEVOLUCION, DEVOLUCIONCOMPRADETALLE.CODCODIGO, DEVOLUCIONCOMPRA.NUMDEVOLUCION, DEVOLUCIONCOMPRA.TOTALDEVOLUCION, 'FECHADEVOLUCION'=CONVERT(varchar(10),DEVOLUCIONCOMPRA.FECHADEVOLUCION,103), 'TOTALSINIVA'=CASE " & _
                    "WHEN iva = 10 THEN ROUND(((DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA * DEVOLUCIONCOMPRADETALLE.PRECIONETO)) - ((DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA * DEVOLUCIONCOMPRADETALLE.PRECIONETO) / 11), 0) WHEN iva = 5 " & _
                    "THEN ROUND(((DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA * DEVOLUCIONCOMPRADETALLE.PRECIONETO)) - ((DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA * DEVOLUCIONCOMPRADETALLE.PRECIONETO) / 21), 0) " & _
                    "ELSE ROUND(((DEVOLUCIONCOMPRADETALLE.CANTIDADDEVUELTA * DEVOLUCIONCOMPRADETALLE.PRECIONETO)), 0) " & _
                    "END, DEVOLUCIONCOMPRADETALLE.DESCARTAR,DEVOLUCIONCOMPRA.CODCOMPRA,C.MODALIDADPAGO,'SALDOCOMPRA'=(SELECT SUM(SALDOCUOTA) AS Expr1 FROM dbo.FACTURAPAGAR WHERE (CODCOMPRA = C.CODCOMPRA)) FROM dbo.DEVOLUCIONCOMPRA " & _
                    "INNER JOIN DEVOLUCIONCOMPRADETALLE ON DEVOLUCIONCOMPRA.CODDEVOLUCION = DEVOLUCIONCOMPRADETALLE.CODDEVOLUCION LEFT OUTER JOIN COMPRAS AS C ON DEVOLUCIONCOMPRA.CODCOMPRA = C.CODCOMPRA)) AS SUBCONSULTA  " & _
                    "GROUP BY CODDEVOLUCION,NUMDEVOLUCION, TOTALDEVOLUCION, FECHADEVOLUCION, DESCARTAR, CODCOMPRA, MODALIDADPAGO, SALDOCOMPRA " & _
                    "Having (CODDEVOLUCION =" & CONT_CodTrans & ")"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()

                If odrPlanilla.HasRows Then
                    Do While odrPlanilla.Read()
                        codventadev = odrPlanilla("CODCOMPRA")
                        If odrPlanilla("DESCARTAR") = 0 Then 'SIN DEVOLUCION DE MERCADERIA
                            regdevmerc = 0
                            If odrPlanilla("CODCOMPRA") = 0 Then 'NO TIENE FACTURA ASOCIADA
                                'ver
                            Else
                                If odrPlanilla("MODALIDADPAGO") = 0 Then 'FACT. ASOCIADA CONTADO
                                    regdevdinero = 0
                                    regmonet = 1
                                Else 'FACT. ASOCIADA CREDITO
                                    If odrPlanilla("CODCOMPRA") = 0 Then 'No Tiene saldo
                                        regdevdinero = 0
                                        regmonet = 2
                                    Else 'Tiene Saldo
                                        'CUENTA DESCUENTOS OTORGADOS A CLIENTEs
                                        regmonet = 4
                                        regdevdinero = 0
                                    End If
                                End If
                            End If
                        Else 'CON DEVOLUCION DE MERCADERIA
                            regdevmerc = 1
                            regdevdinero = 0
                            If odrPlanilla("CODCOMPRA") = 0 Then 'NO TIENE FACTURA ASOCIADA
                                regmonet = 1
                            Else
                                If odrPlanilla("MODALIDADPAGO") = 0 Then 'FACT. ASOCIADA CONTADO
                                    regmonet = 1
                                Else 'FACT. ASOCIADA CREDITO
                                    If odrPlanilla("SALDOCOMPRA") = 0 Then 'No Tiene saldo
                                        regmonet = 2
                                    Else 'Tiene Saldo - descuento a clientes
                                        regmonet = 4
                                    End If
                                End If
                            End If
                        End If
                        CONT_RgMonet = regmonet

                        conexion = ser.Abrir()

                        'Obtenemos el Periodo Fiscal
                        PeriodoFiscalActivo = w.FuncionConsultaDecimal("CODPERIODOFISCAL", "periodofiscal", "ESTADO", 1)

                        ' - - - - - Vemos que tipo de reglas contiene la platilla seleccionada y en base a eso se arma el asiento contable
                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 5)
                        If (IsExisteRegla <> 0) Then 'IVA 5%
                            Monto = CONT_MontoIva5
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                        End If

                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 10)
                        If (IsExisteRegla <> 0) Then 'IVA 10%
                            Monto = CONT_MontoIva10
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                        End If

                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 9)
                        If (IsExisteRegla <> 0) Then 'Excenta
                            Monto = CONT_MontoExcenta
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                        End If

                        'MOVIEMIENTO DE CAJA GENERICO/ESPECIFICO
                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 8)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", NumCaja)
                        Monto = CONT_TotalMontoTrans

                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)

                        Else 'Movimiento de Caja Generico
                            IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 7)
                            If (IsExisteRegla <> 0) Then
                                GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                            End If
                        End If

                        'Venta de Productos o Servicios
                        If regdevmerc = 0 Then
                            Monto = Math.Round(odrPlanilla("TOTALDEVOLUCION"), 0)
                        Else
                            Monto = Math.Round(odrPlanilla("TOTALSINIVA"), 0)
                        End If

                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", 11)
                        IsExisteReglaFK = 0
                        GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)

                        ReglaEspecifica = 1 'Cliente Especifico
                        ReglaGenerica = 2 'Cliente Generico

                        IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", ReglaEspecifica)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA =" & ReglaEspecifica & "AND REGLAFK", CONT_PersonaID)

                        'CLIENTE/PROVEEDOR ESPECIFICO/GENERICO
                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'CLIENTE/PROVEEDOR ESPECIFICO
                            Monto = CONT_TotalMontoTrans
                            GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 1, CONT_RgMonet, CONT_Sucursal)

                        Else 'CLIENTE/PROVEEDOR GENERICO
                            IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = " & CONT_ModuloID & " AND PLANTILLA.ReglaMercaderia = " & CONT_RgMerc & " AND PLANTILLA.DevMerc = " & regdevmerc & " AND PLANTILLA.DevDinero= " & regdevdinero & " AND PLANTILLA.ReglaMonetaria = " & regmonet & " AND PLANTILLADETALLE.TipoRegla", ReglaGenerica)
                            If (IsExisteRegla <> 0) Then
                                Monto = CONT_TotalMontoTrans
                                GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                            End If
                        End If
                    Loop
                End If
            End If

            If (CONT_ModuloID <> 11) Then 'Nota de Crédito
                IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", ReglaEspecifica)
                IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA =" & ReglaEspecifica & "AND REGLAFK", CONT_PersonaID)

                If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'CLIENTE/PROVEEDOR ESPECIFICO
                    Monto = CONT_TotalMontoTrans
                    GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 1, CONT_RgMonet, CONT_Sucursal)

                Else 'CLIENTE/PROVEEDOR GENERICO
                    IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", ReglaGenerica)
                    If (IsExisteRegla <> 0) Then
                        Monto = CONT_TotalMontoTrans
                        GuardarRegla(CONT_ModuloID, CONT_CodTrans, CONT_Moneda, CONT_Fecha, CONT_Cotizacion, CONT_ConceptoAsiento, CONT_Timbrado, CONT_NroTrans, 0, CONT_RgMonet, CONT_Sucursal)
                    End If
                End If
            End If
        End If


        '4to - Cambiamos el estado en el campo ASENTADO
        '       0 --- > Sino se guardo en la tabla PARAASENTAR
        '       1 --- > Si se guardo en la tabla PARAASENTAR
        '       2 --- > Cuando ya se contabilizo, es decir se guardo en la tabla ASIENTOS

        conexion = ser.Abrir()

        'Devolución Venta

        If CONT_ModuloID = 11 Then ' actualizamos tambien a Asentado=1 la cobranza
            consulta = "UPDATE " & CONT_TablaConsulta & " SET ASENTADO ='" & SeGuardo & "' WHERE " & CONT_CampWhere & " = " & CONT_CodTrans & " UPDATE VENTASFORMACOBRO SET ASENTADO='" & SeGuardo & "' WHERE CODTIPOCOBRO=5 AND CODVENTA=" & codventadev & " AND NUMDEVOLUCION='" & CONT_NroTrans & "'"
        Else
            consulta = "UPDATE " & CONT_TablaConsulta & " SET ASENTADO ='" & SeGuardo & "' WHERE " & CONT_CampWhere & " = " & CONT_CodTrans & ""
        End If
        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")


        Consultas.ConsultaComando(myTrans, consulta)
        myTrans.Commit()



        conexion = ser.Abrir()

        ' Devolución Compra

        If CONT_ModuloID = 29 Then ' actualizamos tambien a Asentado=1 la cobranza
            consulta = "UPDATE " & CONT_TablaConsulta & " SET ASENTADO ='" & SeGuardo & "' WHERE " & CONT_CampWhere & " = " & CONT_CodTrans & " UPDATE COMPRASFORMAPAGO SET ASENTADO='" & SeGuardo & "' WHERE CODTIPOPAGO=5 AND CODCOMPRA=" & codventadev & " AND NUMDEVOLUCION='" & CONT_NroTrans & "'"
        End If
        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")


        Consultas.ConsultaComando(myTrans, consulta)
        myTrans.Commit()


    End Sub

    Public Sub AnularAsientos(ByVal RegistroID As Integer, ByVal IdModulo As Integer)
        'Antes de cerar el debe y el haber debemos verificar si la factura se  en la tabla Asientos o ParaAsentar

        Dim Existe As Integer = w.FuncionConsultaDecimal("AsientoID", "PARAASENTAR", "RegistroID = " & RegistroID & " AND ModuloID", IdModulo)

        conexion = ser.Abrir()

        If Existe <> 0 Then 'Se encuentra en la tabla PARASENTAR

            consulta = "UPDATE PARAASENTAR SET IMPORTED = 0, IMPORTEH = 0 , DETALLE = 'FACTURA ANULADA'  " & _
                        "WHERE RegistroID = " & RegistroID & " AND ModuloID =  " & IdModulo & ""

            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            Consultas.ConsultaComando(myTrans, consulta)
            myTrans.Commit()

        Else

            consulta = "UPDATE ASIENTOS SET IMPORTED = 0, IMPORTEH = 0 , DETALLE = 'FACTURA ANULADA'  " & _
                        "WHERE RegistroID = " & RegistroID & " AND ModuloID =  " & IdModulo & ""

            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            Consultas.ConsultaComando(myTrans, consulta)
            myTrans.Commit()


        End If
    End Sub

    Public Sub PagosContabilidad(ByVal CabPagos As Integer, ByVal CodProveedor As Integer, ByVal vpCodSucursal As Integer)
        Try
            Dim ConceptoPAgo, NroFactura, Timbrado As String
            SeGuardo = 0
            'Obtenemos el Periodo Fiscal
            PeriodoFiscalActivo = w.FuncionConsultaDecimal("CODPERIODOFISCAL", "periodofiscal", "ESTADO", 1)

            '-----PAGOS CONTADO ------
            UsarPlantilla = w.FuncionConsultaDecimal("PlantillaID", "PLANTILLA", "ModuloID = 4 AND ReglaMercaderia = 3  AND ReglaMonetaria", 1)

            If UsarPlantilla <> 0 Then  'Si existe una Plantilla de Pagos al Contado
                conexion = ser.Abrir()

                objCommand.CommandText = "SELECT dbo.COMPRASFORMAPAGO.CODCOMPRA, dbo.COMPRASFORMAPAGO.CODTIPOPAGO, SUM(dbo.COMPRASFORMAPAGO.IMPORTE) AS Importe, CONVERT(varchar(10), FECHAREGISTROPAG, 103) AS FECHAREGISTROPAG, dbo.COMPRASFORMAPAGO.FECHAPAGO, " & _
                                         "dbo.COMPRASFORMAPAGO.CABPAGO, dbo.aperturas.id_caja, dbo.COMPRASFORMAPAGO.CODMONEDA, dbo.COMPRASFORMAPAGO.COTIZACION1, dbo.COMPRASFORMAPAGO.NRORECIBO " & _
                                         "FROM  dbo.COMPRASFORMAPAGO INNER JOIN dbo.aperturas ON dbo.COMPRASFORMAPAGO.id_apertura = dbo.aperturas.id_apertura " & _
                                         "GROUP BY dbo.COMPRASFORMAPAGO.CODCOMPRA, dbo.COMPRASFORMAPAGO.TIPOPAGO, CONVERT(varchar(10), FECHAREGISTROPAG, 103),dbo.COMPRASFORMAPAGO.CABPAGO, dbo.aperturas.id_caja, " & _
                                         "dbo.COMPRASFORMAPAGO.CODMONEDA, dbo.COMPRASFORMAPAGO.COTIZACION1, dbo.COMPRASFORMAPAGO.NRORECIBO,dbo.COMPRASFORMAPAGO.CODTIPOPAGO, dbo.COMPRASFORMAPAGO.FECHAPAGO " & _
                                         "HAVING (dbo.COMPRASFORMAPAGO.TIPOPAGO = 0) AND (dbo.COMPRASFORMAPAGO.CABPAGO = " & CabPagos & ")"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()

                If odrPlanilla.HasRows Then
                    Do While odrPlanilla.Read()
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", odrPlanilla("id_caja"))

                        ConceptoPAgo = "Factura de Compra Contado / " & w.FuncionConsultaString("NOMBRE", "PROVEEDOR", "CODPROVEEDOR", CodProveedor)
                        NroFactura = w.FuncionConsultaString("NUMCOMPRA", "COMPRAS", "CODCOMPRA", odrPlanilla("CODCOMPRA"))
                        Timbrado = w.FuncionConsultaString("TIMBRADOFACTURA", "PROVEEDOR", "CODPROVEEDOR", CodProveedor)

                        Monto = Math.Round(odrPlanilla("Importe"), 0)

                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) And (odrPlanilla("CODTIPOPAGO") <> 6) Then 'Movimiento de Caja Especifico
                            GuardarRegla(3, odrPlanilla("CODCOMPRA"), odrPlanilla("CODMONEDA"), odrPlanilla("FECHAREGISTROPAG"), odrPlanilla("COTIZACION1"), ConceptoPAgo, Timbrado, odrPlanilla("NRORECIBO"), 1, 1, vpCodSucursal)

                        Else 'Movimiento de Caja Generico
                            IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
                            If (IsExisteRegla <> 0) And (odrPlanilla("CODTIPOPAGO") <> 6) Then
                                GuardarRegla(3, odrPlanilla("CODCOMPRA"), odrPlanilla("CODMONEDA"), odrPlanilla("FECHAREGISTROPAG"), odrPlanilla("COTIZACION1"), ConceptoPAgo, Timbrado, NroFactura, 0, 1, vpCodSucursal)
                            End If
                        End If

                        'Para Retenciones 
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 14)
                        If (IsExisteRegla <> 0) And (odrPlanilla("CODTIPOPAGO") = 6) Then
                            Monto = Math.Round(odrPlanilla("Importe"), 0)
                            GuardarRegla(3, odrPlanilla("CODCOMPRA"), odrPlanilla("CODMONEDA"), odrPlanilla("FECHAREGISTROPAG"), odrPlanilla("COTIZACION1"), ConceptoPAgo, Timbrado, NroFactura, 0, 1, vpCodSucursal)
                        End If
                    Loop

                    consulta = "UPDATE COMPRASFORMAPAGO SET ASENTADO ='" & SeGuardo & "' WHERE CABPAGO =" & CabPagos & ""
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()
                End If

                odrPlanilla.Close()
                objCommand.Dispose()
            End If

            '-----PAGOS CREDITO ------
            UsarPlantilla = w.FuncionConsultaDecimal("PlantillaID", "PLANTILLA", "ModuloID = 4 AND ReglaMercaderia = 3  AND ReglaMonetaria", 2)

            If UsarPlantilla <> 0 Then  'Si existe una Plantilla de Pagos a Credito
                conexion = ser.Abrir()

                objCommand.CommandText = "SELECT dbo.COMPRASFORMAPAGO.id_apertura, dbo.COMPRASFORMAPAGO.CODTIPOPAGO, SUM(dbo.COMPRASFORMAPAGO.IMPORTE) AS IMPORTE, CONVERT(varchar(10), FECHAREGISTROPAG, 103) AS FECHAREGISTROPAG, dbo.COMPRASFORMAPAGO.FECHAPAGO," & _
                                         " (SELECT SUM(IMPORTE) AS Expr1 FROM dbo.COMPRASFORMAPAGO AS CFP WHERE (CABPAGO = " & CabPagos & ")) AS TOTALRECIBO ,  " & _
                                         "dbo.COMPRASFORMAPAGO.CABPAGO, dbo.aperturas.id_caja, dbo.COMPRASFORMAPAGO.CODMONEDA, dbo.COMPRASFORMAPAGO.COTIZACION1, dbo.COMPRASFORMAPAGO.NRORECIBO " & _
                                         "FROM dbo.COMPRASFORMAPAGO INNER JOIN dbo.aperturas ON dbo.COMPRASFORMAPAGO.id_apertura = dbo.aperturas.id_apertura " & _
                                         "GROUP BY dbo.COMPRASFORMAPAGO.id_apertura, dbo.COMPRASFORMAPAGO.TIPOPAGO, dbo.COMPRASFORMAPAGO.CABPAGO, CONVERT(varchar(10), FECHAREGISTROPAG, 103),dbo.aperturas.id_caja,dbo.COMPRASFORMAPAGO.FECHAPAGO, " & _
                                         "dbo.COMPRASFORMAPAGO.CODMONEDA, dbo.COMPRASFORMAPAGO.COTIZACION1, dbo.COMPRASFORMAPAGO.NRORECIBO,dbo.COMPRASFORMAPAGO.CODTIPOPAGO " & _
                                         "HAVING (dbo.COMPRASFORMAPAGO.TIPOPAGO = 1) AND (dbo.COMPRASFORMAPAGO.CABPAGO = " & CabPagos & ")"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()

                If odrPlanilla.HasRows Then
                    Do While odrPlanilla.Read()
                        'MOVIMIENTO DE CAJA ESPECIFIO / GENERICO
                        ReglaEspecifica = 8 'Mov. de Caja Especifico
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA =" & ReglaEspecifica & "AND REGLAFK", odrPlanilla("id_caja"))

                        Monto = odrPlanilla("Importe")
                        ConceptoPAgo = "Pago de Factura Crédito / " & w.FuncionConsultaString("NOMBRE", "PROVEEDOR", "CODPROVEEDOR", CodProveedor)

                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) And (odrPlanilla("CODTIPOPAGO") <> 6) Then 'Movimiento de Caja Especifico   
                            GuardarRegla(4, CabPagos, odrPlanilla("CODMONEDA"), odrPlanilla("FECHAREGISTROPAG"), odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 1, 1, vpCodSucursal)

                        Else 'Movimiento de Caja Generico
                            IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
                            If (IsExisteRegla <> 0) And (odrPlanilla("CODTIPOPAGO") <> 6) Then
                                GuardarRegla(4, CabPagos, odrPlanilla("CODMONEDA"), odrPlanilla("FECHAREGISTROPAG"), odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 0, 1, vpCodSucursal)
                            End If
                        End If

                        'PROVEEDOR ESPECIFICO/GENERICO
                        ReglaEspecifica = 3 'Proveedor Especifico
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 3)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA =" & ReglaEspecifica & "AND REGLAFK", CodProveedor)

                        Monto = odrPlanilla("TOTALRECIBO")
                        ConceptoPAgo = "Pago de Factura Crédito / " & w.FuncionConsultaString("NOMBRE", "PROVEEDOR", "CODPROVEEDOR", CodProveedor)

                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) And (odrPlanilla("CODTIPOPAGO") <> 6) Then 'PROVEEDOR ESPECIFICO
                            GuardarRegla(4, CabPagos, odrPlanilla("CODMONEDA"), odrPlanilla("FECHAREGISTROPAG"), odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 1, 1, vpCodSucursal)

                        Else 'PROVEEDOR GENERICO
                            IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 4)
                            If (IsExisteRegla <> 0) And (odrPlanilla("CODTIPOPAGO") <> 6) Then
                                GuardarRegla(4, CabPagos, odrPlanilla("CODMONEDA"), odrPlanilla("FECHAREGISTROPAG"), odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 0, 1, vpCodSucursal)
                            End If
                        End If

                        'Para Retenciones 
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 14)
                        If (IsExisteRegla <> 0) And (odrPlanilla("CODTIPOPAGO") = 6) Then
                            Monto = Math.Round(odrPlanilla("Importe"), 0)
                            GuardarRegla(4, CabPagos, odrPlanilla("CODMONEDA"), odrPlanilla("FECHAREGISTROPAG"), odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 0, 1, vpCodSucursal)
                        End If
                    Loop

                    consulta = "UPDATE COMPRASFORMAPAGO SET ASENTADO ='" & SeGuardo & "' WHERE CABPAGO =" & CabPagos & ""
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()
                End If

                odrPlanilla.Close()
                objCommand.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show("Problema al Aplicar Regla Contable" & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub CobroContabilidad(ByVal CabCobro As Integer, ByVal CodCliente As Integer, ByVal vpCodSucursal As Integer)
        Dim ConceptoPAgo, NroFactura, Timbrado As String
        Dim Fecha As String
        SeGuardo = 0
        'Obtenemos el Periodo Fiscal
        PeriodoFiscalActivo = w.FuncionConsultaDecimal("CODPERIODOFISCAL", "periodofiscal", "ESTADO", 1)
        Fecha = Format(Today, "dd/MM/yyyy")

        '-----COBRO CONTADO ------
        UsarPlantilla = w.FuncionConsultaDecimal("PlantillaID", "PLANTILLA", "ModuloID = 10 AND ReglaMercaderia = 3  AND ReglaMonetaria", 1)

        If UsarPlantilla <> 0 Then  'Si existe una Plantilla de Cobro al Contado
            conexion = ser.Abrir()

            objCommand.CommandText = "SELECT dbo.VENTASFORMACOBRO.CODVENTA, dbo.VENTASFORMACOBRO.CODTIPOCOBRO, CONVERT(varchar(10),dbo.VENTASFORMACOBRO.FECHAREGISTROCOB,103) AS FECHAREGISTROCOB, dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.COTIZACION1,  " & _
                                     "SUM(dbo.VENTASFORMACOBRO.IMPORTE) AS IMPORTE, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO,  " & _
                                     "dbo.VENTASFORMACOBRO.TIPOCOBRO, dbo.aperturas.id_caja  FROM dbo.VENTASFORMACOBRO INNER JOIN  dbo.aperturas  " & _
                                     "ON dbo.VENTASFORMACOBRO.id_apertura = dbo.aperturas.id_apertura GROUP BY dbo.VENTASFORMACOBRO.CODVENTA, CONVERT(varchar(10),dbo.VENTASFORMACOBRO.FECHAREGISTROCOB,103),  " & _
                                     "dbo.VENTASFORMACOBRO.CODTIPOCOBRO, dbo.VENTASFORMACOBRO.CODMONEDA,  dbo.VENTASFORMACOBRO.NRORECIBO,  " & _
                                     "dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.TIPOCOBRO, dbo.aperturas.id_caja, dbo.VENTASFORMACOBRO.COTIZACION1  " & _
                                     "HAVING(dbo.VENTASFORMACOBRO.TIPOCOBRO = 1) And (dbo.VENTASFORMACOBRO.CABCOBRO = " & CabCobro & ")"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()

            If odrPlanilla.HasRows Then
                Do While odrPlanilla.Read()
                    Fecha = odrPlanilla("FECHAREGISTROCOB")
                    IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
                    IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA =8 AND REGLAFK", odrPlanilla("id_caja"))

                    NroFactura = w.FuncionConsultaString("NUMVENTA", "VENTAS", "CODVENTA", odrPlanilla("CODVENTA"))
                    ConceptoPAgo = "Factura de Venta Contado / " & w.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", CodCliente)
                    Timbrado = w.FuncionConsultaString("NUMVENTATIMBRADO", "VENTAS", "CODVENTA", odrPlanilla("CODVENTA"))
                    Monto = odrPlanilla("Importe")

                    If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico
                        GuardarRegla(8, odrPlanilla("CODVENTA"), odrPlanilla("CODMONEDA"), Fecha, odrPlanilla("COTIZACION1"), ConceptoPAgo, Timbrado, NroFactura, 1, 1, vpCodSucursal)

                    Else 'Movimiento de Caja Generico
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
                        If (IsExisteRegla <> 0) Then
                            GuardarRegla(8, odrPlanilla("CODVENTA"), odrPlanilla("CODMONEDA"), Fecha, odrPlanilla("COTIZACION1"), ConceptoPAgo, Timbrado, NroFactura, 0, 1, vpCodSucursal)
                        End If
                    End If
                    consulta = "UPDATE VENTASFORMACOBRO SET ASENTADO ='" & SeGuardo & "' WHERE CABCOBRO =" & CabCobro & ""
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()
                Loop
            End If

            odrPlanilla.Close()
            objCommand.Dispose()
        End If

        '-----COBRO CREDITO ------
        UsarPlantilla = w.FuncionConsultaDecimal("PlantillaID", "PLANTILLA", "ModuloID = 10 AND ReglaMercaderia = 3  AND ReglaMonetaria", 2)

        If UsarPlantilla <> 0 Then  'Si existe una Plantilla de Cobro a Credito
            conexion = ser.Abrir()

            objCommand.CommandText = "SELECT dbo.VENTASFORMACOBRO.CODVENTA,CONVERT(varchar(10),dbo.VENTASFORMACOBRO.FECHAREGISTROCOB,103) AS FECHAREGISTROCOB, dbo.VENTASFORMACOBRO.CODTIPOCOBRO, dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.COTIZACION1,  " & _
                                    "SUM(dbo.VENTASFORMACOBRO.IMPORTE) AS IMPORTE, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO,  " & _
                                    "dbo.VENTASFORMACOBRO.TIPOCOBRO, dbo.aperturas.id_caja  FROM dbo.VENTASFORMACOBRO INNER JOIN  dbo.aperturas  " & _
                                    "ON dbo.VENTASFORMACOBRO.id_apertura = dbo.aperturas.id_apertura GROUP BY dbo.VENTASFORMACOBRO.CODVENTA,CONVERT(varchar(10),dbo.VENTASFORMACOBRO.FECHAREGISTROCOB,103),  " & _
                                    "dbo.VENTASFORMACOBRO.CODTIPOCOBRO, dbo.VENTASFORMACOBRO.CODMONEDA,  dbo.VENTASFORMACOBRO.NRORECIBO,  " & _
                                    "dbo.VENTASFORMACOBRO.CABCOBRO, dbo.VENTASFORMACOBRO.TIPOCOBRO, dbo.aperturas.id_caja, dbo.VENTASFORMACOBRO.COTIZACION1  " & _
                                    "HAVING(dbo.VENTASFORMACOBRO.TIPOCOBRO = 2) And (dbo.VENTASFORMACOBRO.CABCOBRO = " & CabCobro & ")"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrPlanilla As SqlDataReader = objCommand.ExecuteReader()

            If odrPlanilla.HasRows Then
                Do While odrPlanilla.Read()
                    'MOVIMIENTO DE CAJA ESPECIFIO / GENERICO
                    IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
                    IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", odrPlanilla("id_caja"))

                    Fecha = odrPlanilla("FECHAREGISTROCOB")
                    Monto = odrPlanilla("Importe")
                    ConceptoPAgo = "Pago Credito / " & w.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", CodCliente)

                    If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico   
                        GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), Fecha, odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 1, 1, vpCodSucursal)

                    Else 'Movimiento de Caja Generico
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
                        If (IsExisteRegla <> 0) Then
                            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), Fecha, odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 0, 1, vpCodSucursal)
                        End If
                    End If

                    'CLIENTE ESPECIFICO/GENERICO
                    IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 1)
                    IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA =" & ReglaEspecifica & "AND REGLAFK", CodCliente)

                    Monto = odrPlanilla("Importe")
                    ConceptoPAgo = "Pago Credito / " & w.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", CodCliente)

                    If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'CLIENTE ESPECIFICO
                        GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), Fecha, odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 1, 1, vpCodSucursal)

                    Else 'CLIENTE GENERICO
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 2)
                        If (IsExisteRegla <> 0) Then
                            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), Fecha, odrPlanilla("COTIZACION1"), ConceptoPAgo, "", odrPlanilla("NRORECIBO"), 0, 1, vpCodSucursal)
                        End If
                    End If
                    consulta = "UPDATE VENTASFORMACOBRO SET ASENTADO ='" & SeGuardo & "' WHERE CABCOBRO =" & CabCobro & ""
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()
                Loop
            End If

            odrPlanilla.Close()
            objCommand.Dispose()
        End If
    End Sub

    Public Sub GuardarRegla(ByVal CONT_ModuloID As Integer, ByVal CONT_CodTrans As Integer, ByVal CONT_Moneda As Double, ByVal CONT_Fecha As String, _
                            ByVal CONT_Cotizacion As Double, ByVal CONT_ConceptoAsiento As String, ByVal CONT_Timbrado As String, ByVal CONT_NroTrans As String, _
                            ByVal IsEspecifico As Integer, ByVal CONT_RgMonet As Integer, ByVal CONT_CodSucursal As Integer)
        If Monto <> 0 Or QuemandoNro = 1 Then
            DebeHaber = w.FuncionConsultaString("Debe", "PLANTILLADETALLE", "PlantillaDetID", IsExisteRegla)

            If DebeHaber = "SI" Then  'Debe
                ImporteD = Monto
                ImporteH = 0
                ImporteD = Replace(ImporteD, ",", ".")
            ElseIf DebeHaber = "NO" Then 'Haber
                ImporteH = Monto
                ImporteD = 0
                ImporteH = Replace(ImporteH, ",", ".")
            End If

            If IsEspecifico = 0 Then
                CodCuenta = w.FuncionConsultaDecimal("CuentaID", "PLANTILLADETALLE", "PlantillaDetID", IsExisteRegla)
            Else
                CodCuenta = IsExisteReglaFK
            End If

            DescripCuenta = w.FuncionConsultaString("DESPLANCUENTA", "plancuentas", "CODPLANCUENTA", CodCuenta)

            Try
                Dim fecha As DateTime
                fecha = CONT_Fecha
                Dim fechacadena As String
                fechacadena = ""
                fechacadena = fecha.ToString("dd/MM/yyyy")

                consulta = "INSERT INTO PARAASENTAR (ModuloID,RegistroID,CODMONEDA,FECHAASIENTO,COTIZACION, TIPOPAGO," & _
                           "CODPERIODOFISCAL,CODPLANCUENTA,DESCRIPCION,IMPORTED,IMPORTEH,NUMCOMPROBANTE,DETALLE,TIMBRADO,CODSUCURSAL) " & _
                            "VALUES   " & _
                            "(" & CONT_ModuloID & "," & CONT_CodTrans & ", " & CONT_Moneda & ",CONVERT(DATETIME,'" & fechacadena & "',103) ," & _
                              CONT_Cotizacion & "," & CONT_RgMonet & "," & PeriodoFiscalActivo & ", " & CodCuenta & ", '" & DescripCuenta & "', " & _
                              ImporteD & ", " & ImporteH & ", '" & CONT_NroTrans & "' , '" & CONT_ConceptoAsiento & "','" & CONT_Timbrado & "'," & CONT_CodSucursal & ")"

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()

                SeGuardo = 1
            Catch e As Exception
                SeGuardo = 0
                MessageBox.Show(e.Message)
            End Try
        End If
    End Sub

    Public Sub AnticipoContabilidad(ByVal CabCobro As Integer, ByVal CodCliente As Integer, ByVal Detalle As String, ByVal TipoAnt As Integer, ByVal vpCodSucursal As Integer)
        Dim fechacobro, NroRecibo As String
        Dim MontoTotal As Double
        Dim Moneda, Cotizacion As String
        Dim Tipomovimiento As Integer = 0
        Dim odrPlanilla As SqlDataReader

        'OBTENERMOS EL PERIODO FISCAL ACTIVO
        PeriodoFiscalActivo = w.FuncionConsulta("CODPERIODOFISCAL", "PERIODOFISCAL", "ESTADO", 1)
        MontoTotal = 0 : fechacobro = "" : NroRecibo = "" : Moneda = "" : Cotizacion = ""

        If TipoAnt = 0 Then
            '-----GENERAR ANTICIPOS DE CLIENTES ------
            UsarPlantilla = w.FuncionConsulta("PlantillaID", "PLANTILLA", "ModuloID = " & 10 & " AND ReglaMercaderia = " & 3 & " AND ReglaMonetaria = " & 3 & " AND GenerarAnti = 1 AND AplicarAnti", 0)
            GoTo GenerarAnticipo
        Else
            '-----APLICAR ANTICIPOS DE CLIENTES ------
            UsarPlantilla = w.FuncionConsulta("PlantillaID", "PLANTILLA", "ModuloID = " & 10 & " AND ReglaMercaderia = " & 3 & " AND ReglaMonetaria = " & 3 & " AND GenerarAnti = 0 AND AplicarAnti", 1)
            GoTo AplicarAnticipo
        End If

GenerarAnticipo:
        If UsarPlantilla <> 0 Then  'Si existe una Plantilla de Cobro al Contado
            conexion = ser.Abrir()

            objCommand.CommandText = "SELECT  CONVERT(varchar(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103) AS FECHAREGISTROCOB, dbo.VENTASFORMACOBRO.CODTIPOCOBRO, " & _
                                     "dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.COTIZACION1, SUM(dbo.VENTASFORMACOBRO.IMPORTE) AS IMPORTE,  " & _
                                     "dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.aperturas.id_caja  " & _
                                     "FROM dbo.VENTASFORMACOBRO LEFT OUTER JOIN dbo.aperturas ON dbo.VENTASFORMACOBRO.id_apertura = dbo.aperturas.id_apertura  " & _
                                     "WHERE(dbo.VENTASFORMACOBRO.CABCOBRO = " & CabCobro & ") " & _
                                     "GROUP BY CONVERT(varchar(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103), dbo.VENTASFORMACOBRO.CODTIPOCOBRO, " & _
                                     "dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.aperturas.id_caja, " & _
                                     "dbo.VENTASFORMACOBRO.COTIZACION1 "

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            odrPlanilla = objCommand.ExecuteReader()

            If odrPlanilla.HasRows Then
                Do While odrPlanilla.Read()
                    fechacobro = odrPlanilla("FECHAREGISTROCOB")
                    NroRecibo = odrPlanilla("NRORECIBO")
                    Monto = odrPlanilla("Importe")

                    ''MOVIMIENTO DE CAJA ESPECIFIO / GENERICO
                    IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
                    IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", odrPlanilla("id_caja"))

                    If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico
                        'Dim Detalle As String = " / " + CmbCliente.Text
                        GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)

                    Else 'Movimiento de Caja Generico
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
                        If (IsExisteRegla <> 0) Then
                            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 0, 1, vpCodSucursal)
                        End If
                    End If

                    'Anticipo de Cliente
                    IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 12)
                    IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 12 AND REGLAFK", 1)
                    If (IsExisteRegla <> 0) Then
                        GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)
                    End If
                Loop
            End If
            odrPlanilla.Close()
            objCommand.Dispose()
            GoTo FinAnticipo
        End If


AplicarAnticipo:
        If UsarPlantilla <> 0 Then  'Si existe una Plantilla de Cobro al Contado
            conexion = ser.Abrir()

            objCommand.CommandText = "SELECT  CONVERT(varchar(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103) AS FECHAREGISTROCOB, dbo.VENTASFORMACOBRO.CODTIPOCOBRO, " & _
                                     "dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.COTIZACION1, SUM(dbo.VENTASFORMACOBRO.IMPORTE) AS IMPORTE,  " & _
                                     "dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.aperturas.id_caja  " & _
                                     "FROM dbo.VENTASFORMACOBRO LEFT OUTER JOIN dbo.aperturas ON dbo.VENTASFORMACOBRO.id_apertura = dbo.aperturas.id_apertura  " & _
                                     "WHERE(dbo.VENTASFORMACOBRO.CABCOBRO = " & CabCobro & ") " & _
                                     "GROUP BY CONVERT(varchar(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103), dbo.VENTASFORMACOBRO.CODTIPOCOBRO, " & _
                                     "dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.aperturas.id_caja, " & _
                                     "dbo.VENTASFORMACOBRO.COTIZACION1 "

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            odrPlanilla = objCommand.ExecuteReader()

            If odrPlanilla.HasRows Then
                Do While odrPlanilla.Read()
                    fechacobro = odrPlanilla("FECHAREGISTROCOB")
                    NroRecibo = odrPlanilla("NRORECIBO")
                    Monto = odrPlanilla("Importe")
                    MontoTotal = MontoTotal + Monto

                    Tipomovimiento = odrPlanilla("CODTIPOCOBRO")

                    If Tipomovimiento = 1 Then
                        ''MOVIMIENTO DE CAJA ESPECIFIO / GENERICO
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", odrPlanilla("id_caja"))

                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico
                            'Dim Detalle As String = " / " + CmbCliente.Text
                            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)

                        Else 'Movimiento de Caja Generico
                            IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
                            If (IsExisteRegla <> 0) Then
                                GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 0, 1, vpCodSucursal)
                            End If
                        End If
                    End If

                    If Tipomovimiento = 8 Then
                        'Anticipo de Cliente
                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 12)
                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 12 AND REGLAFK", 1)
                        If (IsExisteRegla <> 0) Then
                            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)
                        End If
                    End If

                    Moneda = odrPlanilla("CODMONEDA") : Cotizacion = odrPlanilla("COTIZACION1")
                Loop

                'CLIENTE ESPECIFICO/GENERICO
                IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = 10 AND PLANTILLA.ReglaMercaderia =  3 AND PLANTILLA.ReglaMonetaria = 3  AND PLANTILLADETALLE.TipoRegla = 1 AND dbo.PLANTILLA.PlantillaID ", UsarPlantilla)
                IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 1 AND REGLAFK", CodCliente)

                If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'CLIENTE ESPECIFICO
                    Monto = MontoTotal
                    GuardarRegla(10, CabCobro, Moneda, fechacobro, Cotizacion, Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)

                Else 'CLIENTE GENERICO
                    IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = 10 AND PLANTILLA.ReglaMercaderia =  3 AND PLANTILLA.ReglaMonetaria = 3  AND PLANTILLADETALLE.TipoRegla = 2 AND dbo.PLANTILLA.PlantillaID", UsarPlantilla)
                    If (IsExisteRegla <> 0) Then
                        Monto = MontoTotal
                        GuardarRegla(10, CabCobro, Moneda, fechacobro, Cotizacion, Detalle, 0, NroRecibo, 0, 1, vpCodSucursal)
                    End If
                End If
            End If
            odrPlanilla.Close()
            objCommand.Dispose()
        End If

FinAnticipo:

        consulta = ""
        consulta = "UPDATE VENTASFORMACOBRO SET ASENTADO ='" & SeGuardo & "' WHERE CABCOBRO =" & CabCobro & ""
        Try
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
       

        Consultas.ConsultaComando(myTrans, consulta)
        myTrans.Commit()

        Catch
        End Try

    End Sub

    'ANTICIPO DE PROVEEDORES**************************************************
    Public Sub AnticipoProveedores(ByVal CabCobro As Integer, ByVal CodCliente As Integer, ByVal Detalle As String, ByVal TipoAnt As Integer, ByVal vpCodSucursal As Integer)
        Dim fechacobro, NroRecibo As String
        Dim MontoTotal As Double
        Dim Moneda, Cotizacion As String
        Dim Tipomovimiento As Integer = 0
        'Dim odrPlanilla As SqlDataReader

        'OBTENERMOS EL PERIODO FISCAL ACTIVO
        PeriodoFiscalActivo = w.FuncionConsulta("CODPERIODOFISCAL", "PERIODOFISCAL", "ESTADO", 1)
        MontoTotal = 0 : fechacobro = "" : NroRecibo = "" : Moneda = "" : Cotizacion = ""

        If TipoAnt = 0 Then
            '-----GENERAR ANTICIPOS DE CLIENTES ------
            UsarPlantilla = w.FuncionConsulta("PlantillaID", "PLANTILLA", "ModuloID = " & 4 & " AND ReglaMercaderia = " & 3 & " AND ReglaMonetaria = " & 3 & " AND GenerarAnti = 1 AND AplicarAnti", 0)
            GoTo GenerarAnticipo
        Else
            '-----APLICAR ANTICIPOS DE CLIENTES ------
            UsarPlantilla = w.FuncionConsulta("PlantillaID", "PLANTILLA", "ModuloID = " & 4 & " AND ReglaMercaderia = " & 3 & " AND ReglaMonetaria = " & 3 & " AND GenerarAnti = 0 AND AplicarAnti", 1)
            'GoTo AplicarAnticipo
        End If

GenerarAnticipo:
        If UsarPlantilla <> 0 Then  'Si existe una Plantilla de Pago al Contado
            'conexion = ser.Abrir()

            'objCommand.CommandText = "SELECT  CONVERT(varchar(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103) AS FECHAREGISTROCOB, dbo.VENTASFORMACOBRO.CODTIPOCOBRO, " & _
            '                         "dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.COTIZACION1, SUM(dbo.VENTASFORMACOBRO.IMPORTE) AS IMPORTE,  " & _
            '                         "dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.aperturas.id_caja  " & _
            '                         "FROM dbo.VENTASFORMACOBRO LEFT OUTER JOIN dbo.aperturas ON dbo.VENTASFORMACOBRO.id_apertura = dbo.aperturas.id_apertura  " & _
            '                         "WHERE(dbo.VENTASFORMACOBRO.CABCOBRO = " & CabCobro & ") " & _
            '                         "GROUP BY CONVERT(varchar(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103), dbo.VENTASFORMACOBRO.CODTIPOCOBRO, " & _
            '                         "dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.aperturas.id_caja, " & _
            '                         "dbo.VENTASFORMACOBRO.COTIZACION1 "

            'objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            'objCommand.Connection.Open()
            'odrPlanilla = objCommand.ExecuteReader()

            'If odrPlanilla.HasRows Then
            '    Do While odrPlanilla.Read()
            '        fechacobro = odrPlanilla("FECHAREGISTROCOB")
            '        NroRecibo = odrPlanilla("NRORECIBO")
            '        Monto = odrPlanilla("Importe")

            '        ''MOVIMIENTO DE CAJA ESPECIFIO / GENERICO
            '        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
            '        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", odrPlanilla("id_caja"))

            '        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico
            '            'Dim Detalle As String = " / " + CmbCliente.Text
            '            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)

            '        Else 'Movimiento de Caja Generico
            '            IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
            '            If (IsExisteRegla <> 0) Then
            '                GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 0, 1, vpCodSucursal)
            '            End If
            '        End If

            '        'Anticipo de Cliente
            '        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 12)
            '        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 12 AND REGLAFK", 1)
            '        If (IsExisteRegla <> 0) Then
            '            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)
            '        End If
            '    Loop
            'End If
            'odrPlanilla.Close()
            'objCommand.Dispose()
            'GoTo FinAnticipo
        End If


        'AplicarAnticipo:
        '        If UsarPlantilla <> 0 Then  'Si existe una Plantilla de Cobro al Contado
        '            conexion = ser.Abrir()

        '            objCommand.CommandText = "SELECT  CONVERT(varchar(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103) AS FECHAREGISTROCOB, dbo.VENTASFORMACOBRO.CODTIPOCOBRO, " & _
        '                                     "dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.COTIZACION1, SUM(dbo.VENTASFORMACOBRO.IMPORTE) AS IMPORTE,  " & _
        '                                     "dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.aperturas.id_caja  " & _
        '                                     "FROM dbo.VENTASFORMACOBRO LEFT OUTER JOIN dbo.aperturas ON dbo.VENTASFORMACOBRO.id_apertura = dbo.aperturas.id_apertura  " & _
        '                                     "WHERE(dbo.VENTASFORMACOBRO.CABCOBRO = " & CabCobro & ") " & _
        '                                     "GROUP BY CONVERT(varchar(10), dbo.VENTASFORMACOBRO.FECHAREGISTROCOB, 103), dbo.VENTASFORMACOBRO.CODTIPOCOBRO, " & _
        '                                     "dbo.VENTASFORMACOBRO.CODMONEDA, dbo.VENTASFORMACOBRO.NRORECIBO, dbo.VENTASFORMACOBRO.CABCOBRO, dbo.aperturas.id_caja, " & _
        '                                     "dbo.VENTASFORMACOBRO.COTIZACION1 "

        '            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        '            objCommand.Connection.Open()
        '            odrPlanilla = objCommand.ExecuteReader()

        '            If odrPlanilla.HasRows Then
        '                Do While odrPlanilla.Read()
        '                    fechacobro = odrPlanilla("FECHAREGISTROCOB")
        '                    NroRecibo = odrPlanilla("NRORECIBO")
        '                    Monto = odrPlanilla("Importe")
        '                    MontoTotal = MontoTotal + Monto

        '                    Tipomovimiento = odrPlanilla("CODTIPOCOBRO")

        '                    If Tipomovimiento = 1 Then
        '                        ''MOVIMIENTO DE CAJA ESPECIFIO / GENERICO
        '                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 8)
        '                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 8 AND REGLAFK", odrPlanilla("id_caja"))

        '                        If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'Movimiento de Caja Especifico
        '                            'Dim Detalle As String = " / " + CmbCliente.Text
        '                            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)

        '                        Else 'Movimiento de Caja Generico
        '                            IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 7)
        '                            If (IsExisteRegla <> 0) Then
        '                                GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 0, 1, vpCodSucursal)
        '                            End If
        '                        End If
        '                    End If

        '                    If Tipomovimiento = 8 Then
        '                        'Anticipo de Cliente
        '                        IsExisteRegla = w.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & UsarPlantilla & " AND TipoRegla", 12)
        '                        IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 12 AND REGLAFK", 1)
        '                        If (IsExisteRegla <> 0) Then
        '                            GuardarRegla(10, CabCobro, odrPlanilla("CODMONEDA"), fechacobro, odrPlanilla("COTIZACION1"), Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)
        '                        End If
        '                    End If

        '                    Moneda = odrPlanilla("CODMONEDA") : Cotizacion = odrPlanilla("COTIZACION1")
        '                Loop

        '                'CLIENTE ESPECIFICO/GENERICO
        '                IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = 10 AND PLANTILLA.ReglaMercaderia =  3 AND PLANTILLA.ReglaMonetaria = 3  AND PLANTILLADETALLE.TipoRegla = 1 AND dbo.PLANTILLA.PlantillaID ", UsarPlantilla)
        '                IsExisteReglaFK = w.FuncionConsultaDecimal("CODPLANCUENTA", "plancuentas", "REGLA = 1 AND REGLAFK", CodCliente)

        '                If (IsExisteRegla <> 0) And (IsExisteReglaFK <> 0) Then 'CLIENTE ESPECIFICO
        '                    Monto = MontoTotal
        '                    GuardarRegla(10, CabCobro, Moneda, fechacobro, Cotizacion, Detalle, 0, NroRecibo, 1, 1, vpCodSucursal)

        '                Else 'CLIENTE GENERICO
        '                    IsExisteRegla = w.FuncionConsultaDecimal("PLANTILLADETALLE.PlantillaDetID", "PLANTILLADETALLE INNER JOIN PLANTILLA ON PLANTILLADETALLE.PlantillaID = PLANTILLA.PlantillaID", "PLANTILLA.ModuloID = 10 AND PLANTILLA.ReglaMercaderia =  3 AND PLANTILLA.ReglaMonetaria = 3  AND PLANTILLADETALLE.TipoRegla = 2 AND dbo.PLANTILLA.PlantillaID", UsarPlantilla)
        '                    If (IsExisteRegla <> 0) Then
        '                        Monto = MontoTotal
        '                        GuardarRegla(10, CabCobro, Moneda, fechacobro, Cotizacion, Detalle, 0, NroRecibo, 0, 1, vpCodSucursal)
        '                    End If
        '                End If
        '            End If
        '            odrPlanilla.Close()
        '            objCommand.Dispose()
        '        End If

        'FinAnticipo:
        '        Try
        '            consulta = ""
        '            consulta = "UPDATE VENTASFORMACOBRO SET ASENTADO ='" & SeGuardo & "' WHERE CABCOBRO =" & CabCobro & ""
        '        Catch ex As Exception
        '        End Try

        '        Try
        '            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        '            Consultas.ConsultaComando(myTrans, consulta)
        '            myTrans.Commit()
        '        Catch ex As Exception
        '        End Try
    End Sub
    '*******************************************************************************************
#End Region
End Module
