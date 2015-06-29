Imports System.Data
Imports System.Data.SqlClient

Module MonedaCotizacion

    Dim bdConn As New BDConexión.BDConexion
    Dim dtMoneda As New DataTable("MONEDA")
    Dim dr As SqlDataReader

    Public Function ConvertMoney(ByVal ValorOriginal As Double, ByVal id_MonedaOrigen As Integer, ByVal CotizacionTrans As Double, ByVal id_MonedaDestino As Integer)

        Dim respuesta As Double = Nothing
        Dim sql As String = Nothing

        If id_MonedaOrigen <> id_MonedaDestino Then
            'Creamos un DayaReader y este lo pasamos a un DataTable
            Dim connString As New SqlConnection(bdConn.CadenaConexion)
            sql = "SELECT CODMONEDA, PRIORIDAD, MULTIPLICADOR, (SELECT TOP (1) PERCENT FACTORVENTA  FROM dbo.COTIZACION WHERE CODMONEDA = dbo.MONEDA.CODMONEDA " & _
                  "ORDER BY FECHAMOVIMIENTO DESC) AS COTIZACION  FROM dbo.MONEDA Where PRIORIDAD is not null ORDER BY CODMONEDA"
            Dim SQLCmd As New SqlCommand(sql, connString)
            connString.Open()
            dr = SQLCmd.ExecuteReader(CommandBehavior.Default)
            dtMoneda.Load(dr)
            connString.Close()

            Dim fx_OriginalxPrioridad As Decimal = Nothing
            Dim mult_Originen_Prioridad As String = Nothing
            Dim fx_Prioridad_Destino As Decimal = Nothing
            Dim mult_Prioridad_Destino As String = Nothing

            Dim id_MonedaPrioriad As Integer

            Dim i As Integer = dtMoneda.Rows.Count

            For Each row In dtMoneda.Rows
                'obtener codigo de prioridad
                If row("PRIORIDAD") = 1 Then
                    id_MonedaPrioriad = row("CODMONEDA") 'para que duerma tranquilo
                End If
                If row("CODMONEDA") = id_MonedaOrigen Then
                    fx_OriginalxPrioridad = row("COTIZACION")      'cotizacion contra prioridad
                    If Not IsDBNull(row("MULTIPLICADOR")) Then
                        mult_Originen_Prioridad = row("MULTIPLICADOR") 'multiplicador
                    End If
                End If
                If row("CODMONEDA") = id_MonedaDestino Then
                    fx_Prioridad_Destino = row("COTIZACION")      'cotizacion contra prioridad
                    If Not IsDBNull(row("MULTIPLICADOR")) Then
                        mult_Prioridad_Destino = row("MULTIPLICADOR") 'multiplicador
                    End If
                End If
            Next

            'preguntar, es MonedaOrigen Prioridad o monedadestino prioridad?
            If id_MonedaPrioriad = id_MonedaOrigen Or id_MonedaPrioriad = id_MonedaDestino Then
                'caso si... hacer multiplicacion directa
                If id_MonedaPrioriad = id_MonedaOrigen Then
                    respuesta = Convertir(ValorOriginal, fx_Prioridad_Destino, mult_Prioridad_Destino)

                ElseIf id_MonedaPrioriad = id_MonedaDestino Then
                    'se hace el inverso
                    mult_Originen_Prioridad = ConvertirInverso(mult_Originen_Prioridad)
                    respuesta = Convertir(ValorOriginal, CotizacionTrans, mult_Originen_Prioridad)
                End If
            Else
                'caso no... hacer multiplicacion por tercero. primero. tomar origen, y convertir a prioridad. despues... tomar prioridad y convertir a destino.
                mult_Originen_Prioridad = ConvertirInverso(mult_Originen_Prioridad)
                Dim Valor_a_Prioridad = Convertir(ValorOriginal, fx_OriginalxPrioridad, mult_Originen_Prioridad)
                respuesta = Convertir(Valor_a_Prioridad, CotizacionTrans, mult_Prioridad_Destino)
            End If
        Else
            respuesta = ValorOriginal
        End If

        Return respuesta
    End Function

    Private Function Convertir(Valor_Original As Decimal, fx_Valor As Decimal, fx_Multiplicador As String)
        Dim respuesta As Double = Nothing

        If fx_Multiplicador = "/" Then
            respuesta = Valor_Original / fx_Valor
        ElseIf fx_Multiplicador = "*" Then
            respuesta = Valor_Original * fx_Valor
        End If

        Return respuesta
    End Function

    Private Function ConvertirInverso(SignoMultiplicador As String)
        Dim respuesta As String = Nothing

        If SignoMultiplicador = "/" Then
            respuesta = "*"
        ElseIf SignoMultiplicador = "*" Then
            respuesta = "/"
        End If

        Return respuesta
    End Function
End Module
