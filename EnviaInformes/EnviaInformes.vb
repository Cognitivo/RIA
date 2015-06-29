Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class EnviaInformes
    Dim sql2 As String
    Dim sql As String
    Dim ser As New BDConexión.BDConexion
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand 'Para cuando se esta usando cmd en un private sub,función etc y se quiere volver a usar, entonces se usa sqlc1
    Private sqlc As SqlConnection
    Private sqlc1 As SqlConnection 'Para cuando se esta usando sqlc en un private sub,función etc y se quiere volver a usar, entonces se usa sqlc1

    Dim dr As SqlDataReader
    Dim dr1 As SqlDataReader 'Para cuando se esta usando dr1 en un private sub,función etc y se quiere volver a usar, entonces se usa sqlc1

    Private row As DataRow

    Private direccion As String
    Private sistema As New Funciones.Sistema
    Private f As New Funciones.Funciones


    Public Sub New()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand
        sqlc = New SqlConnection

        cmd1 = New SqlCommand
        sqlc1 = New SqlConnection

    End Sub
    Public Function InfInventario(ByVal CONDICIONES As String, ByVal DesSucursal As String, ByVal CodSucursal As Integer, ByVal UsuNombre As String, ByVal TipoInventario As String) As DataSet
        Dim ds As New DsInformes


        sql = ""
        ' SQL = "SELECT CODPRODUCTO, STOCKACTUAL, CODCODIGO  FROM ABOGADO"

        sql = "SELECT STOCKDEPOSITO.CODSTOCKDEPOSTIPO, STOCKDEPOSITO.CODDEPOSITO, STOCKDEPOSITO.CODPRODUCTO, STOCKDEPOSITO.CODUSUARIO, " & _
                    " STOCKDEPOSITO.CODEMPRESA, STOCKDEPOSITO.STOCKACTUAL, STOCKDEPOSITO.STOCKMIN, STOCKDEPOSITO.STOCKMAX, " & _
                    " STOCKDEPOSITO.FECGRA, STOCKDEPOSITO.CODCIUDAD, STOCKDEPOSITO.CODCODIGO, CODIGOS.DESCODIGO1, CODIGOS.DESCODIGO2, " & _
                    " PRODUCTOS.DESPRODUCTO, LTRIM(RTRIM(CODIGOS.DESCODIGO1 + ' ' + CODIGOS.DESCODIGO2)) AS PRODUCTO, RUBRO.DESRUBRO, " & _
                    " LINEA.DESLINEA, CODIGOS.CODIGO " & _
                    " FROM STOCKDEPOSITO INNER JOIN " & _
                    " CODIGOS ON STOCKDEPOSITO.CODCODIGO = CODIGOS.CODCODIGO AND STOCKDEPOSITO.CODPRODUCTO = CODIGOS.CODPRODUCTO INNER JOIN" & _
                    " PRODUCTOS ON CODIGOS.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN" & _
                    " LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA INNER JOIN" & _
                    " RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO AND LINEA.CODLINEA = RUBRO.CODLINEA"


        sql = sql + " " + CONDICIONES

        Try
            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("DESLINEA")
                Dim d As String = dr("DESLINEA")
                row.Item("Campo2") = dr("DESRUBRO")
                row.Item("Campo3") = dr("CODIGO")
                row.Item("Campo4") = dr("DESPRODUCTO")
                row.Item("Campo5") = dr("PRODUCTO")
                row.Item("Numero1") = dr("STOCKACTUAL")
                ds.Tables("Detalle").Rows.Add(row)
            Loop
            ''###################
            ''#    CABECERA     #
            ''###################
            Dim DesUsu As String = UsuNombre
            row = ds.Tables("Cabecera").NewRow()

            ''row.Item("Campo1") = empDescripcion
            row.Item("Campo1") = DesSucursal
            row.Item("Campo3") = CodSucursal
            row.Item("Campo2") = DesUsu
            row.Item("Campo4") = TipoInventario

            ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try

        Return ds

    End Function

    Public Function InfProductoCodigoBarra(ByVal CONDICIONES As String, ByVal DesSucursal As String, ByVal UsuNombre As String, ByVal Usuario As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT     C.CODCODIGO,MAX(L.DESLINEA)AS DESLINEA,MAX(R.DESRUBRO) AS DESRUBRO," & _
                "C.CODPRODUCTO, C.DESCODIGO1, C.DESCODIGO2, " & _
                "C.CODUSUARIO, C.CODEMPRESA,  " & _
                "C.FECGRA, C.CODIGO, P.DESPRODUCTO, " & _
                "RTRIM(LTRIM(P.DESPRODUCTO + ' ' + C.DESCODIGO1 + ' ' + C.DESCODIGO2)) AS PRODUCTO " & _
                "FROM         CODIGOS C  " & _
                "INNER JOIN PRODUCTOS P ON C.CODPRODUCTO = P.CODPRODUCTO " & _
                "INNER JOIN LINEA L ON P.CODLINEA=L.CODLINEA " & _
                "INNER JOIN RUBRO R ON L.CODLINEA=R.CODLINEA " & _
                "GROUP BY   C.CODCODIGO,C.CODPRODUCTO, " & _
                "C.DESCODIGO1, C.DESCODIGO2, " & _
                "C.CODUSUARIO, C.CODEMPRESA, " & _
                "C.FECGRA, C.CODIGO, P.DESPRODUCTO " & _
                " HAVING C.CODIGO LIKE '" & CONDICIONES & "' OR P.DESPRODUCTO LIKE '" & CONDICIONES & "' "


        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("DESLINEA")
                row.Item("Campo2") = dr("DESRUBRO")
                row.Item("Campo3") = dr("CODIGO")
                ' row.Item("Campo4") = dr("DESPRODUCTO")
                row.Item("Campo4") = dr("PRODUCTO")
                ds.Tables("Detalle").Rows.Add(row)
            Loop
            ''###################
            ''#    CABECERA     #
            ''###################
            Dim DesUsu As String = UsuNombre
            row = ds.Tables("Cabecera").NewRow()

            ''row.Item("Campo1") = empDescripcion
            row.Item("Campo1") = DesSucursal

            row.Item("Campo2") = DesUsu

            ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try

        Return ds

    End Function
    Public Function InfCodigoBarra(ByVal NombreProducto As String, ByVal Precio As String, ByVal Codigo As String) As DataSet
        Dim ds As New DsInformes
        Try
            row = ds.Tables("Detalle").NewRow()
            row.Item("Campo1") = NombreProducto
            row.Item("Campo2") = Precio
            row.Item("Campo3") = Codigo
            row.Item("Campo4") = NombreProducto
            row.Item("Campo5") = Precio
            row.Item("Campo6") = Codigo
            row.Item("Campo7") = NombreProducto
            row.Item("Campo8") = Precio
            row.Item("Campo9") = Codigo

            ds.Tables("Detalle").Rows.Add(row)


        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfCodigoBarraMultiple(ByVal DtCodigodebarra As DataTable) As DataSet
        Dim ds As New DsInformes
        Try


            For i = 0 To DtCodigodebarra.Rows.Count - 1
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = DtCodigodebarra.Rows(i)("NombreProducto")
                row.Item("Numero1") = DtCodigodebarra.Rows(i)("Precio")
                row.Item("Campo3") = DtCodigodebarra.Rows(i)("Codigo")
                row.Item("Campo4") = DtCodigodebarra.Rows(i)("NombreProducto")
                row.Item("Numero1") = DtCodigodebarra.Rows(i)("Precio")
                row.Item("Campo6") = DtCodigodebarra.Rows(i)("Codigo")
                row.Item("Campo7") = DtCodigodebarra.Rows(i)("NombreProducto")
                row.Item("Numero1") = DtCodigodebarra.Rows(i)("Precio")
                row.Item("Campo9") = DtCodigodebarra.Rows(i)("Codigo")
                ds.Tables("Detalle").Rows.Add(row)
            Next
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfCodigoBarraMultiple2(ByVal DtCodigodebarra As DataTable) As DataSet
        Dim ds As New DsInformes
        Try


            For i = 0 To DtCodigodebarra.Rows.Count - 1
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = DtCodigodebarra.Rows(i)("NombreProducto")
                row.Item("Campo4") = DtCodigodebarra.Rows(i)("NombreProducto")
                row.Item("Campo7") = DtCodigodebarra.Rows(i)("NombreProducto")
                row.Item("Campo3") = DtCodigodebarra.Rows(i)("Codigo")
                row.Item("Campo6") = DtCodigodebarra.Rows(i)("Codigo")
                row.Item("Campo9") = DtCodigodebarra.Rows(i)("Codigo")
                row.Item("Campo2") = DtCodigodebarra.Rows(i)("Empresa")
                row.Item("Campo10") = DtCodigodebarra.Rows(i)("Empresa")
                row.Item("Campo11") = DtCodigodebarra.Rows(i)("Empresa")
                row.Item("Campo5") = DtCodigodebarra.Rows(i)("Ruc")
                row.Item("Campo8") = DtCodigodebarra.Rows(i)("Ruc")
                row.Item("Campo12") = DtCodigodebarra.Rows(i)("Ruc")
                ds.Tables("Detalle").Rows.Add(row)
            Next
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfCodigoBarraMultiple1(ByVal DtCodigodebarra As DataTable) As DataSet
        Dim ds As New DsInformes
        Try


            For i = 0 To DtCodigodebarra.Rows.Count - 1
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = DtCodigodebarra.Rows(i)("NombreProducto")
                row.Item("Numero1") = DtCodigodebarra.Rows(i)("Precio")
                row.Item("Campo3") = DtCodigodebarra.Rows(i)("Codigo")
                ds.Tables("Detalle").Rows.Add(row)
            Next
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfEtiquetasProdcutos(ByVal DtCodigodebarra As DataTable) As DataSet
        Dim ds As New DsInformes
        Try

            For i = 0 To DtCodigodebarra.Rows.Count - 1
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = DtCodigodebarra.Rows(i)("Cliente")
                row.Item("Campo2") = DtCodigodebarra.Rows(i)("Litografia")
                row.Item("Campo3") = DtCodigodebarra.Rows(i)("Codigo")
                row.Item("Campo4") = DtCodigodebarra.Rows(i)("Medida")
                row.Item("Fecha1") = DtCodigodebarra.Rows(i)("Fecha")
                row.Item("Numero1") = DtCodigodebarra.Rows(i)("Cantidad")
                ds.Tables("Detalle").Rows.Add(row)
            Next
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfCodigoBarraSupervisor(ByVal DtCodigodebarra As DataTable) As DataSet
        Dim ds As New DsInformes
        Try
            For i = 0 To DtCodigodebarra.Rows.Count - 1
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo3") = DtCodigodebarra.Rows(i)("Codigo")
                ds.Tables("Detalle").Rows.Add(row)
            Next
        Catch ex As Exception
        Finally
        End Try

        Return ds
    End Function

    Public Function InfTipoClientesVentas(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes
        Dim hoy As DateTime = DateTime.Now
        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "Select DISTINCT c.NOMBRE AS NOMBRE, c.NUMCLIENTE, TC.DESTIPOCLIENTE AS TIPOCLIENTE, c.RUC, c.TELEFONO, dbo.PAIS.DESPAIS, " & _
                  "dbo.CIUDAD.DESCIUDAD, dbo.ZONA.DESZONA FROM dbo.CLIENTES AS c LEFT OUTER JOIN dbo.CIUDAD ON c.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                  "dbo.PAIS ON dbo.CIUDAD.CODPAIS = dbo.PAIS.CODPAIS AND c.CODPAIS = dbo.PAIS.CODPAIS LEFT OUTER JOIN dbo.ZONA ON c.CODZONA = dbo.ZONA.CODZONA AND dbo.CIUDAD.CODCIUDAD = dbo.ZONA.CODCIUDAD LEFT OUTER JOIN " & _
                  "dbo.TIPOCLIENTE AS TC ON c.CODTIPOCLIENTE = TC.CODTIPOCLIENTE  " & _
                  "" & condiciones & " " & _
                  "GROUP BY TC.DESTIPOCLIENTE, c.NOMBRE, c.APELLIDO, c.NUMCLIENTE, c.RUC, c.TELEFONO, dbo.PAIS.DESPAIS, dbo.CIUDAD.DESCIUDAD, dbo.ZONA.DESZONA"

        End If
        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("RUC")
                row.Item("Campo2") = dr("TIPOCLIENTE")
                row.Item("Campo3") = EmpDescripcion
                row.Item("Campo4") = dr("NOMBRE")
                row.Item("Campo5") = dr("TELEFONO")
                row.Item("Campo6") = dr("DESPAIS") + " / " + dr("DESCIUDAD") + " / " + dr("DESZONA")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function


    Public Function InfChequesRecibidos(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes
        Dim hoy As DateTime = DateTime.Now
        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "SELECT     VENTAS.NUMVENTA, VENTAS.FECHAVENTA, VENTAS.NOMBRECLIENTE, VENTAS.RUCCLIENTE, " & _
                "VENTASFORMACOBRO.DESTIPOCOBRO, VENTASFORMACOBRO.IMPORTE, VENTASFORMACOBRO.CH_NROCHEQUE, " & _
                "BANCO.DESBANCO FROM VENTAS LEFT OUTER JOIN VENTASFORMACOBRO " & _
                "ON VENTAS.CODVENTA = VENTASFORMACOBRO.CODVENTA LEFT OUTER JOIN BANCO ON " & _
                "VENTASFORMACOBRO.CH_TA_TR_CODBANCO = BANCO.CODBANCO WHERE (VENTASFORMACOBRO.DESTIPOCOBRO = 'CHEQUE') " & _
                "AND VENTAS.FECHAVENTA >= convert(datetime,'" & FechaDesde & "',103) " & _
                "AND VENTAS.FECHAVENTA <= convert(datetime,'" & FechaHasta & "',103)" & _
                "" & condiciones & " " & _
                "GROUP BY  VENTAS.NOMBRECLIENTE, VENTAS.NUMVENTA, VENTAS.FECHAVENTA, VENTAS.RUCCLIENTE, " & _
                "VENTASFORMACOBRO.DESTIPOCOBRO, VENTASFORMACOBRO.IMPORTE, VENTASFORMACOBRO.CH_NROCHEQUE, " & _
                "BANCO.DESBANCO ORDER BY BANCO.DESBANCO, VENTAS.NOMBRECLIENTE"
        End If


        Try
            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("DESBANCO")
                row.Item("Campo3") = dr("NUMVENTA")
                row.Item("Campo4") = dr("NOMBRECLIENTE")
                row.Item("Numero1") = dr("CH_NROCHEQUE")
                row.Item("Numero2") = dr("IMPORTE")
                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function



    Public Function InfTipoPago(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes
        Dim hoy As DateTime = DateTime.Now
        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "SELECT   VENTAS.CODCLIENTE,  VENTAS.NUMVENTA, VENTAS.FECHAVENTA, VENTAS.NOMBRECLIENTE, VENTAS.RUCCLIENTE, " & _
            "VENTASFORMACOBRO.DESTIPOCOBRO, VENTASFORMACOBRO.IMPORTE, VENTASFORMACOBRO.CH_NROCHEQUE, " & _
            "BANCO.DESBANCO FROM VENTAS INNER JOIN VENTASFORMACOBRO " & _
            "ON VENTAS.CODVENTA = VENTASFORMACOBRO.CODVENTA LEFT OUTER JOIN BANCO ON " & _
            "VENTASFORMACOBRO.CH_TA_TR_CODBANCO = BANCO.CODBANCO " & _
            "WHERE VENTAS.FECHAVENTA >= convert(datetime, '" & FechaDesde & "',103) " & _
            "AND VENTAS.FECHAVENTA <= convert(datetime, '" & FechaHasta & "',103) " & _
            "" & condiciones & " " & _
            "GROUP BY  VENTAS.CODCLIENTE,VENTAS.NOMBRECLIENTE, VENTAS.NUMVENTA, VENTAS.FECHAVENTA, VENTAS.RUCCLIENTE, " & _
            "VENTASFORMACOBRO.DESTIPOCOBRO, VENTASFORMACOBRO.IMPORTE, VENTASFORMACOBRO.CH_NROCHEQUE,  " & _
            "BANCO.DESBANCO ORDER BY VENTASFORMACOBRO.DESTIPOCOBRO, BANCO.DESBANCO, VENTAS.NOMBRECLIENTE "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("DESTIPOCOBRO")
                row.Item("Campo3") = dr("NUMVENTA")
                row.Item("Campo4") = dr("NOMBRECLIENTE")
                row.Item("Campo5") = dr("RUCCLIENTE")
                row.Item("Numero2") = dr("IMPORTE")
                row.Item("Fecha3") = dr("FECHAVENTA")
                ds.Tables("Detalle").Rows.Add(row)
            Loop


        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function



    Public Function InfCdCCompras(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "SELECT (CASE CD.TIPOIVA WHEN '10.00' THEN CD.IMPORTEGRAVADO10   " & _
                " WHEN '5.00' THEN CD.IMPORTEGRAVADO5  ELSE CD.IMPORTEEXENTO  END ) AS IMPORTE, " & _
                "CD.CANTIDADCOMPRA CANTIDAD,CE.DESCENTRO, CD.DESPRODUCTO AS PRODUCTO,C.NUMCOMPRA " & _
                "FROM COMPRASDETALLE CD, COMPRAS C, CENTROCOSTO CE  " & _
                "WHERE(C.CODCOMPRA = CD.CODCOMPRA) AND CD.CODCENTRO = CE.CODCENTRO  " & _
                "AND C.FECHACOMPRA >= convert(datetime, '" & FechaDesde & "',103) AND C.FECHACOMPRA  <= " & _
                "convert(datetime,'" & FechaHasta & "',103) " + condiciones + ") " & _
                " GROUP BY CD.IMPORTEGRAVADO10,CD.IMPORTEGRAVADO5,CD.IMPORTEEXENTO,CD.TIPOIVA, " & _
                "CD.CANTIDADCOMPRA, CE.DESCENTRO,  CD.DESPRODUCTO, C.NUMCOMPRA " & _
                "ORDER BY CE.DESCENTRO, C.NUMCOMPRA "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                Dim n As Integer
                Dim d As Decimal
                Dim s As String
                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("DESCENTRO")
                s = dr("DESCENTRO")
                row.Item("Numero1") = dr("CANTIDAD")
                n = dr("CANTIDAD")
                row.Item("Campo3") = dr("PRODUCTO")
                s = dr("PRODUCTO")
                row.Item("Campo4") = dr("NUMCOMPRA")
                s = dr("NUMCOMPRA")
                row.Item("Numero2") = dr("IMPORTE")
                d = dr("IMPORTE")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfLibroDiario(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal Sucursal As Integer) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "select fechaasiento, plancuentas.numplancuenta, numasiento, descripcion, asientos.codsucursal, numcomprobante, detalle, " & _
            "imported, sucursal.dessucursal, sucursal.numsucursal, importeh from asientos,plancuentas,sucursal where " & _
            "fechaasiento >= convert(datetime,'" & FechaDesde & "',103) and fechaasiento <= convert(datetime,'" & FechaHasta & "',103) " & _
            "and asientos.codsucursal= '" & Sucursal & "'and plancuentas.codplancuenta=asientos.codplancuenta and sucursal.codsucursal='" & Sucursal & "'"
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo7") = dr("dessucursal")
                row.Item("fecha1") = FechaDesde
                row.Item("fecha2") = FechaHasta
                row.Item("fecha3") = dr("fechaasiento")
                row.Item("Campo3") = dr("numplancuenta")
                row.Item("Campo2") = dr("numasiento")
                row.Item("campo4") = dr("descripcion")
                row.Item("Numero3") = dr("numsucursal")
                row.Item("Campo5") = dr("numcomprobante")
                row.Item("campo6") = dr("detalle")
                row.Item("Numero2") = dr("imported")
                row.Item("Numero4") = dr("importeh")
                ds.Tables("Detalle").Rows.Add(row)
            Loop
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfLibroMayor(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal Sucursal As Integer, ByRef CuentaDescr As String) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "DECLARE " & _
                "@dessucursal AS VARCHAR(200), " & _
                "@numplancuenta AS VARCHAR(300), " & _
                "@desplancuenta AS VARCHAR(300),  " & _
                "@numasiento AS NUMERIC(18,2), " & _
                "@fechaasiento AS DATETIME, " & _
                "@detalle AS VARCHAR(300),  " & _
                "@desmoneda AS VARCHAR(300), " & _
                "@imported AS NUMERIC(18,2), " & _
                "@importeh AS NUMERIC(18,2), " & _
                "@SALDO AS NUMERIC(18,2), " & _
                "@numplancuenta2 AS VARCHAR(300) " & _
                "DECLARE @VariableTabla " & _
                "as TABLE(dessucursal VARCHAR(200),numplancuenta VARCHAR(300),desplancuenta VARCHAR(300), " & _
                "numasiento NUMERIC(18,2),fechaasiento DATETIME,detalle VARCHAR(300),desmoneda VARCHAR(300), " & _
                "imported NUMERIC(18,2),importeh NUMERIC(18,2),saldo NUMERIC(18,2)) " & _
                "declare  cur_extracto cursor for " & _
                "SELECT dessucursal,numplancuenta, " & _
                "desplancuenta,numasiento,fechaasiento,detalle,desmoneda,imported,importeh " & _
                "FROM asientos, plancuentas, sucursal, moneda  where plancuentas.codplancuenta=asientos.codplancuenta and " & _
                "sucursal.codsucursal=asientos.codsucursal and moneda.codmoneda=asientos.codmoneda " & _
                "and fechaasiento >= CONVERT(DATETIME,'" & FechaDesde & "',103) " & _
                "AND fechaasiento <= CONVERT(DATETIME,'" & FechaHasta & "',103)AND desplancuenta LIKE '" & CuentaDescr & "'  order by numplancuenta ASC " & _
                "set @numplancuenta2=0 " & _
                "SET @SALDO=0 " & _
                "open cur_extracto " & _
                "fetch next from  cur_extracto " & _
                "into @dessucursal,@numplancuenta,@desplancuenta,@numasiento,@fechaasiento,@detalle,@desmoneda,@imported,@importeh " & _
                "WHILE @@FETCH_STATUS = 0 " & _
                "Begin " & _
                "Set @SALDO =@SALDO +@imported - @importeh " & _
                "IF @numplancuenta!=@numplancuenta2 " & _
                "begin " & _
                "set @numplancuenta2=@numplancuenta " & _
                "set @saldo=@imported - @importeh " & _
                "End " & _
                "INSERT INTO @VariableTabla(dessucursal,numplancuenta,desplancuenta, " & _
                "numasiento,fechaasiento,detalle,desmoneda,imported,importeh,saldo) " & _
                "VALUES(@dessucursal,@numplancuenta,@desplancuenta, " & _
                "@numasiento,@fechaasiento,@detalle,@desmoneda,@imported,@importeh,@saldo) " & _
                "fetch next from  cur_extracto " & _
                "into   @dessucursal,@numplancuenta,@desplancuenta, " & _
                "@numasiento,@fechaasiento,@detalle,@desmoneda,@imported,@importeh " & _
                "End " & _
                "Close cur_extracto " & _
                "deallocate cur_extracto " & _
                "Select * from @VariableTabla "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo7") = dr("dessucursal")
                row.Item("fecha1") = FechaDesde
                row.Item("fecha2") = FechaHasta
                row.Item("fecha3") = dr("fechaasiento")
                row.Item("numero1") = dr("numplancuenta")
                row.Item("Campo4") = dr("detalle")
                row.Item("campo2") = dr("desplancuenta")
                row.Item("Numero3") = dr("numasiento")
                row.Item("Numero2") = dr("imported")
                row.Item("Numero4") = dr("importeh")
                row.Item("Numero5") = dr("saldo")
                ds.Tables("Detalle").Rows.Add(row)
            Loop
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfLibroCompras(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal mescompras As String, ByVal añocompras As String) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "select CONVERT(CHAR(2),MAX(fechaasiento), 101) as fecha, numcompra, nombre+' '+apellido as proveedor, ruc_cin, totalexenta," & _
            "totalgravado5,TOTALIVA5,TOTALGRAVADO10,TOTALIVA10 FROM asientos INNER JOIN " & _
            "asientoscompras ON asientos.CODASIENTO = asientoscompras.CODASIENTO INNER JOIN " & _
            "COMPRAS ON asientoscompras.CODCOMPRA = COMPRAS.CODCOMPRA INNER JOIN " & _
            "PROVEEDOR ON COMPRAS.CODPROVEEDOR = PROVEEDOR.CODPROVEEDOR where fechaasiento>=convert(datetime,'" & FechaDesde & "',103) " & _
            "and fechaasiento<=convert(datetime,'" & FechaHasta & "',103)" & _
            "group by NUMCOMPRA,nombre,APELLIDO, RUC_CIN,totalexenta, " & _
            "totalgravado5, TOTALIVA5, TOTALGRAVADO10, TOTALIVA10 "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("numero2") = dr("fecha")
                row.Item("campo2") = dr("numcompra")
                row.Item("campo1") = dr("proveedor")
                row.Item("campo5") = dr("ruc_cin")
                row.Item("numero1") = dr("totalexenta")
                row.Item("numero3") = dr("totalgravado5")
                row.Item("numero6") = dr("totaliva5")
                row.Item("Numero7") = dr("totalgravado10")
                row.Item("Numero8") = dr("totaliva10")
                row.Item("campo6") = mescompras
                row.Item("campo4") = añocompras
                ds.Tables("Detalle").Rows.Add(row)
            Loop
            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo7") = dr("dessucursal")
            'row.Item("fecha1") = FechaDesde
            'row.Item("fecha2") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfLibroVentas(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal mesventas As String, ByVal añoventas As String) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "select CONVERT(CHAR(2),MAX(fechaasiento), 101) as fecha, numventa, nombre+' '+apellido as cliente, ruc, totalexenta, " & _
            "totalgravado5,TOTAL5,TOTALGRAVADO10,TOTAL10 FROM asientos INNER JOIN " & _
            "asientosventas ON asientos.CODASIENTO = asientosventas.CODASIENTO INNER JOIN " & _
            "ventas ON asientosventas.CODventa = ventas.CODventa INNER JOIN " & _
            "clientes ON ventas.CODcliente = clientes.CODcliente where fechaasiento>=convert(datetime,'" & FechaDesde & "',103) " & _
            "and fechaasiento<=convert(datetime,'" & FechaHasta & "',103)" & _
            "group by NUMventa,nombre,APELLIDO, RUC,totalexenta, " & _
            "totalgravado5, TOTAL5, TOTALGRAVADO10, TOTAL10 "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("numero1") = dr("fecha")
                row.Item("campo1") = dr("numventa")
                row.Item("campo3") = dr("cliente")
                row.Item("campo4") = dr("ruc")
                row.Item("numero3") = dr("totalexenta")
                row.Item("numero5") = dr("totalgravado5")
                row.Item("numero6") = dr("total5")
                row.Item("Numero7") = dr("totalgravado10")
                row.Item("Numero8") = dr("total10")
                row.Item("campo5") = mesventas
                row.Item("campo6") = añoventas
                ds.Tables("Detalle").Rows.Add(row)
            Loop
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfProveedorCompras(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "SELECT (CASE CD.TIPOIVA WHEN '10.00' THEN CD.IMPORTEGRAVADO10  " & _
            "WHEN '5.00' THEN CD.IMPORTEGRAVADO5  ELSE CD.IMPORTEEXENTO  END ) AS IMPORTE " & _
            ",CD.CANTIDADCOMPRA CANTIDAD,RTRIM(P.NOMBRE) AS NOMBREPROVEEDOR,  " & _
            "CD.DESPRODUCTO AS PRODUCTO,C.NUMCOMPRA FROM COMPRASDETALLE CD, COMPRAS C, PROVEEDOR P  " & _
           " WHERE(C.CODCOMPRA = CD.CODCOMPRA) And C.CODPROVEEDOR = P.CODPROVEEDOR " & _
            "AND C.FECHACOMPRA>=CONVERT(DATETIME,'" & FechaDesde & "',103) AND C.FECHACOMPRA  <= " & _
            "CONVERT(DATETIME,'" & FechaHasta & "',103) " + condiciones + " " & _
            "GROUP BY CD.IMPORTEGRAVADO10,CD.IMPORTEGRAVADO5,CD.IMPORTEEXENTO,CD.TIPOIVA," & _
            "CD.CANTIDADCOMPRA, CD.DESPRODUCTO,C.NUMCOMPRA,P.NOMBRE, P.APELLIDO " & _
            " ORDER BY P.APELLIDO, C.NUMCOMPRA"
        End If
        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                Dim n As Integer
                Dim d As Decimal
                Dim s As String
                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("NOMBREPROVEEDOR")
                row.Item("Numero1") = dr("CANTIDAD")
                n = dr("CANTIDAD")
                row.Item("Campo3") = dr("PRODUCTO")
                s = dr("PRODUCTO")
                row.Item("Campo4") = dr("NUMCOMPRA")
                s = dr("NUMCOMPRA")
                row.Item("Numero2") = dr("IMPORTE")
                d = dr("IMPORTE")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfVentasporProductosDetallado(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes
        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""

            sql = "SELECT     dbo.CODIGOS.CODPRODUCTO, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.VENTASDETALLE.PRECIOVENTABRUTO, " & _
                      "dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NUMVENTA, dbo.FAMILIA.DESFAMILIA, dbo.PRODUCTOS.CODFAMILIA, dbo.CODIGOS.CODIGO,  " & _
            "dbo.PRODUCTOS.DESPRODUCTO + ' ' + dbo.CODIGOS.DESCODIGO1 AS DESCRIPCION " & _
                     "FROM         dbo.FAMILIA RIGHT OUTER JOIN  " & _
                      "dbo.PRODUCTOS ON dbo.FAMILIA.CODFAMILIA = dbo.PRODUCTOS.CODFAMILIA RIGHT OUTER JOIN  " & _
                      "dbo.VENTASDETALLE INNER JOIN  " & _
                      "dbo.VENTAS ON dbo.VENTASDETALLE.CODVENTA = dbo.VENTAS.CODVENTA LEFT OUTER JOIN  " & _
                      "dbo.CODIGOS ON dbo.VENTASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO AND dbo.VENTASDETALLE.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO ON  " & _
            "dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO  " & _
                  "WHERE VENTAS.FECHAVENTA >= convert(datetime, '" & FechaDesde & "',103) AND VENTAS.FECHAVENTA  <= convert(datetime,'" & FechaHasta & "',103) " & _
                   " " & condiciones & " " & _
                  "GROUP BY dbo.FAMILIA.DESFAMILIA, dbo.VENTAS.FECHAVENTA, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.VENTASDETALLE.PRECIOVENTALISTA, " & _
                      "dbo.VENTASDETALLE.PRECIOVENTABRUTO, dbo.VENTAS.NUMVENTA, dbo.CODIGOS.CODPRODUCTO, dbo.PRODUCTOS.CODFAMILIA, dbo.CODIGOS.CODIGO, " & _
            "dbo.PRODUCTOS.DESPRODUCTO + ' ' + dbo.CODIGOS.DESCODIGO1, dbo.PRODUCTOS.CODPRODUCTO"
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("DESCRIPCION")
                row.Item("Campo3") = dr("CODIGO")
                row.Item("Campo4") = dr("CANTIDADVENTA")
                row.Item("Campo5") = dr("NUMVENTA")
                row.Item("Campo6") = dr("DESFAMILIA")
                row.Item("Numero2") = dr("PRECIOVENTALISTA")
                row.Item("Numero1") = dr("PRECIOVENTABRUTO")
                row.Item("Fecha3") = dr("FECHAVENTA")
                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfProveedorCheques(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes
        ds.Clear()
        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "SELECT     COMPRASFORMAPAGO.IMPORTE, COMPRASFORMAPAGO.DESTIPOPAGO, COMPRASFORMAPAGO.FECHAPAGO, PROVEEDOR.NOMBRE, COMPRASFORMAPAGO.CH_NROCHEQUE" & _
            " FROM COMPRASFORMAPAGO INNER JOIN " & _
            " COMPRAS ON COMPRASFORMAPAGO.CODCOMPRA = COMPRAS.CODCOMPRA INNER JOIN " & _
            " PROVEEDOR ON COMPRAS.CODPROVEEDOR = PROVEEDOR.CODPROVEEDOR " & _
            " WHERE DESTIPOPAGO = 'CHEQUE' " & _
            " AND FECHAPAGO >= convert(datetime, '" & FechaDesde & "',103) AND FECHAPAGO  <= " & _
            " convert(datetime,'" & FechaHasta & "',103) " + condiciones + " ORDER BY APELLIDO,FECHAPAGO "

        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("NOMBRE")
                row.Item("Numero1") = dr("IMPORTE")

                row.Item("Campo3") = dr("CH_NROCHEQUE")

                row.Item("Campo4") = dr("FECHAPAGO")

                ' row.Item("Numero2") = dr("TOTALPRODUCTO")


                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function


    Public Function InfProductosMasVendidos(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String, ByVal c As Integer) As DataSet
        Dim ds As New DsInformes
        If condiciones <> "" Then
            'If c = 0 Then
            If FechaDesde <> Nothing And FechaHasta <> Nothing Then
                sql = ""

                sql = "SELECT     TOP (100) PERCENT P.DESPRODUCTO, C.DESCODIGO1, C.DESCODIGO2, SUM(VD.CANTIDADVENTA) AS TOTAL, P.CODFAMILIA, F.DESFAMILIA, " & _
                      "ISNULL(RTRIM(P.DESPRODUCTO), '') + ' ' + ISNULL(LTRIM(C.DESCODIGO1), '') + ' ' + ISNULL(LTRIM(C.DESCODIGO2), '') AS DESCRIPCION," & _
                      "SUM(VD.PRECIOVENTALISTA) AS VALOR " & _
                      " FROM dbo.FAMILIA AS F INNER JOIN " & _
                      "dbo.VENTASDETALLE AS VD INNER JOIN " & _
                      "dbo.PRODUCTOS AS P INNER JOIN " & _
                      "dbo.CODIGOS AS C ON P.CODPRODUCTO = C.CODPRODUCTO ON VD.CODCODIGO = C.CODCODIGO INNER JOIN " & _
                      "dbo.VENTAS AS V ON VD.CODVENTA = V.CODVENTA ON F.CODFAMILIA = P.CODFAMILIA " & _
                      "AND V.FECHAVENTA >= convert(datetime, '" & FechaDesde & "',103) AND V.FECHAVENTA <= " & _
                      "convert(datetime,'" & FechaHasta & "',103) " & _
                      "GROUP BY P.DESPRODUCTO, VD.CODPRODUCTO, VD.CODCODIGO, C.DESCODIGO1, C.DESCODIGO2, RTRIM(P.DESPRODUCTO) + ' ' + LTRIM(C.DESCODIGO1),P.CODFAMILIA,F.DESFAMILIA " & _
                      "ORDER BY TOTAL DESC"

            End If

        End If



        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo3") = dr("DESFAMILIA")
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("DESCRIPCION")
                row.Item("Numero1") = dr("TOTAL")
                row.Item("Numero2") = dr("VALOR")
                ds.Tables("Detalle").Rows.Add(row)

            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfProductosMasVendidos4(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String, ByVal c As Integer) As DataSet
        Dim ds As New DsInformes
        If condiciones <> "" Then
            'If c = 0 Then
            If FechaDesde <> Nothing And FechaHasta <> Nothing Then
                sql = ""
                sql = "SELECT P.DESPRODUCTO, C.DESCODIGO1, C.DESCODIGO2, SUM (VD.CANTIDADVENTA) AS TOTAL,  P.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,  " & _
                "ISNULL(RTRIM(P.DESPRODUCTO),'') + ' ' + ISNULL(LTRIM(C.DESCODIGO1),'')+ ' '+ISNULL(LTRIM(C.DESCODIGO2),'') AS DESCRIPCION,  SUM (VD.PRECIOVENTALISTA) AS VALOR " & _
                "FROM dbo.VENTASDETALLE AS VD INNER JOIN dbo.CODIGOS AS C ON VD.CODCODIGO = C.CODCODIGO INNER JOIN dbo.PRODUCTOS AS P ON C.CODPRODUCTO = P.CODPRODUCTO INNER JOIN " & _
                "dbo.VENTAS AS V ON VD.CODVENTA = V.CODVENTA INNER JOIN dbo.FAMILIA ON P.CODFAMILIA = dbo.FAMILIA.CODFAMILIA  " & _
                "WHERE(C.CODCODIGO = VD.CODCODIGO) " & _
                "AND P.CODPRODUCTO=C.CODPRODUCTO " & _
                "AND V.CODVENTA = VD.CODVENTA " & _
                "AND V.FECHAVENTA >= convert(datetime, '" & FechaDesde & "',103) AND V.FECHAVENTA <= " & _
                "convert(datetime,'" & FechaHasta & "',103) " & _
                " " & condiciones & ") " & _
                " GROUP BY P.DESPRODUCTO,VD.CODPRODUCTO, VD.CODCODIGO, C.DESCODIGO1, C.DESCODIGO2, RTRIM(P.DESPRODUCTO) + ' ' + LTRIM(C.DESCODIGO1)+ ' '+LTRIM(C.DESCODIGO2), " & _
                "P.CODFAMILIA, dbo.FAMILIA.DESFAMILIA ORDER BY SUM(VD.CANTIDADVENTA) DESC"


            End If

        End If



        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo3") = dr("DESFAMILIA")
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("DESCRIPCION")
                row.Item("Numero1") = dr("TOTAL")
                row.Item("Numero2") = dr("VALOR")
                ds.Tables("Detalle").Rows.Add(row)

            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function


    Public Function InfProductosMasVendidos2(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String, ByVal c As Integer) As DataSet
        Dim ds As New DsInformes
        'If condiciones <> "" Then
        'If c = 0 Then
        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""

            sql = "SELECT     TOP (100) PERCENT P.DESPRODUCTO, C.DESCODIGO1, C.DESCODIGO2, SUM(VD.CANTIDADVENTA) AS TOTAL, P.CODFAMILIA,F.DESFAMILIA, ISNULL(RTRIM(P.DESPRODUCTO), '') " & _
                      "+ ' ' + ISNULL(LTRIM(C.DESCODIGO1), '') + ' ' + ISNULL(LTRIM(C.DESCODIGO2), '') AS DESCRIPCION, SUM(VD.PRECIOVENTALISTA) AS VALOR " & _
" FROM         dbo.VENTASDETALLE AS VD INNER JOIN " & _
                      " dbo.CODIGOS AS C ON VD.CODCODIGO = C.CODCODIGO INNER JOIN " & _
                      " dbo.PRODUCTOS AS P ON C.CODPRODUCTO = P.CODPRODUCTO INNER JOIN " & _
                      " dbo.VENTAS AS V ON VD.CODVENTA = V.CODVENTA LEFT OUTER JOIN " & _
                      " dbo.FAMILIA as F ON P.CODFAMILIA = F.CODFAMILIA " & _
                      "AND V.FECHAVENTA >= convert(datetime, '" & FechaDesde & "',103) AND V.FECHAVENTA <= " & _
                      "convert(datetime,'" & FechaHasta & "',103) " & _
                     " GROUP BY P.DESPRODUCTO, VD.CODPRODUCTO, VD.CODCODIGO, C.DESCODIGO1, C.DESCODIGO2, RTRIM(P.DESPRODUCTO) + ' ' + LTRIM(C.DESCODIGO1)" & _
                     " + ' ' + LTRIM(C.DESCODIGO2), P.CODFAMILIA, F.DESFAMILIA " & _
                     "ORDER BY TOTAL DESC"

        End If





        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo3") = dr("DESFAMILIA")
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("DESCRIPCION")
                row.Item("Numero1") = dr("TOTAL")
                row.Item("Numero2") = dr("VALOR")
                ds.Tables("Detalle").Rows.Add(row)

            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfProductosMasVendidos3(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String, ByVal c As Integer) As DataSet
        Dim ds As New DsInformes
        'If condiciones <> "" Then
        'If c = 0 Then
        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""

            sql = "SELECT P.DESPRODUCTO, C.DESCODIGO1, C.DESCODIGO2, " & _
"SUM (VD.CANTIDADVENTA) AS TOTAL,  P.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,  " & _
"ISNULL(RTRIM(P.DESPRODUCTO),'') + ' ' + ISNULL(LTRIM(C.DESCODIGO1),'')+ ' '+ " & _
"ISNULL(LTRIM(C.DESCODIGO2),'') AS DESCRIPCION,  SUM (VD.PRECIOVENTALISTA) AS VALOR " & _
"FROM dbo.VENTASDETALLE AS VD INNER JOIN dbo.CODIGOS AS C ON VD.CODCODIGO = C.CODCODIGO " & _
" INNER JOIN dbo.PRODUCTOS AS P ON C.CODPRODUCTO = P.CODPRODUCTO INNER JOIN dbo.VENTAS AS V " & _
"ON VD.CODVENTA = V.CODVENTA INNER JOIN dbo.FAMILIA ON P.CODFAMILIA = dbo.FAMILIA.CODFAMILIA " & _
 " GROUP BY P.DESPRODUCTO,VD.CODPRODUCTO, VD.CODCODIGO, C.DESCODIGO1, C.DESCODIGO2, RTRIM(P.DESPRODUCTO) + ' ' + " & _
 "LTRIM(C.DESCODIGO1)+ ' '+LTRIM(C.DESCODIGO2), P.CODFAMILIA, dbo.FAMILIA.DESFAMILIA " & _
" ORDER BY SUM(VD.CANTIDADVENTA) DESC "

        End If





        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo3") = dr("DESFAMILIA")
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("DESCRIPCION")
                row.Item("Numero1") = dr("TOTAL")
                row.Item("Numero2") = dr("VALOR")
                ds.Tables("Detalle").Rows.Add(row)

            Loop

            ''###################
            ''#    CABECERA     #
            ''###################


        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfGsPorClientesVentas(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "SELECT DISTINCT M.DESMONEDA, V.NOMBRECLIENTE, P.DESPRODUCTO, C.DESCODIGO1, " & _
            "SUM (VD.CANTIDADVENTA) SUMAPRODUCTO,ISNULL(RTRIM(P.DESPRODUCTO),'') + ' ' + ISNULL(LTRIM(C.DESCODIGO1),'') + ' '+ISNULL(LTRIM(C.DESCODIGO2),'')  PRODUCTO " & _
            "FROM VENTASDETALLE VD,CODIGOS C, PRODUCTOS P, VENTAS V, MONEDA M, VENTASFORMACOBRO VF " & _
            "WHERE(C.CODCODIGO = VD.CODCODIGO) " & _
            "AND P.CODPRODUCTO=C.CODPRODUCTO AND V.CODVENTA = VD.CODVENTA " & _
            "AND VF.CODMONEDA=M.CODMONEDA AND V.CODVENTA=VF.CODVENTA " & _
            "AND M.DESMONEDA='Guaranies' " & _
            "AND V.FECHAVENTA >= convert(datetime, '" & FechaDesde & "',103) AND V.FECHAVENTA <= " & _
            "convert(datetime,'" & FechaHasta & "',103) " & _
            "" & condiciones & "" & _
            "GROUP BY V.NOMBRECLIENTE, P.DESPRODUCTO,VD.CODPRODUCTO, VD.CODCODIGO, C.DESCODIGO1, M.DESMONEDA, " & _
            "ISNULL(RTRIM(P.DESPRODUCTO),'') + ' ' + ISNULL(LTRIM(C.DESCODIGO1),'') + ' '+ISNULL(LTRIM(C.DESCODIGO2),'') " & _
            "ORDER BY M.DESMONEDA, V.NOMBRECLIENTE,ISNULL(RTRIM(P.DESPRODUCTO),'') + ' ' + ISNULL(LTRIM(C.DESCODIGO1),'') + ' '+ISNULL(LTRIM(C.DESCODIGO2),'')"


        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("NOMBRECLIENTE")
                row.Item("Campo3") = dr("PRODUCTO")
                row.Item("Numero1") = dr("SUMAPRODUCTO")
                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function





    Public Function Infstockdebajominimo(ByVal empDescripcion As String, ByVal codsucursal As Integer, ByVal dessucursal As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT		RTRIM(PRODUCTOS.DESPRODUCTO)AS PRODUCTO, " & _
              "FAMILIA.DESFAMILIA AS CATEGORIA, LINEA.DESLINEA AS LINEA ,RUBRO.DESRUBRO AS MARCA ," & _
              "ISNULL(PRODUCTOS.STOCKMINIMO,0) AS STOCKMINIMO,ISNULL(PRODUCTOS.STOCKMAXIMO,0)AS STOCKMAXIMO," & _
              "CODIGOS.CODCODIGO,CODIGOS.CODPRODUCTO," & _
              "ISNULL(STOCKDEPOSITO.STOCKACTUAL,0)AS STOCKACTUAL,UNIDADMEDIDA.DESMEDIDA AS MEDIDA FROM PRODUCTOS LEFT OUTER JOIN " & _
              "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
              "LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA  " & _
              "AND FAMILIA.CODFAMILIA = LINEA.CODFAMILIA LEFT OUTER JOIN " & _
              "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO  " & _
              "AND LINEA.CODLINEA = RUBRO.CODLINEA LEFT OUTER JOIN " & _
              "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
              "STOCKDEPOSITO ON CODIGOS.CODCODIGO = STOCKDEPOSITO.CODCODIGO " & _
              "AND CODIGOS.CODPRODUCTO = STOCKDEPOSITO.CODPRODUCTO " & _
              "LEFT OUTER JOIN UNIDADMEDIDA ON UNIDADMEDIDA.CODMEDIDA = PRODUCTOS.CODMEDIDA " & _
              "WHERE PRODUCTOS.ESTADO = 0 And SERVICIO = 0 " & _
              "AND PRODUCTOS.STOCKMINIMO > STOCKDEPOSITO.STOCKACTUAL "
        If codsucursal <> 0 Then
            sql = sql + "And STOCKDEPOSITO.CODDEPOSITO = " & codsucursal & ""
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("PRODUCTO")
                row.Item("Campo2") = dr("CATEGORIA")
                row.Item("Campo3") = dr("LINEA")
                row.Item("Campo4") = dr("MARCA")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo6") = dessucursal
                row.Item("Campo7") = dr("MEDIDA")
                row.Item("Numero1") = dr("STOCKMINIMO")
                ' row.Item("Numero3") = dr("STOCKMAXIMO")
                row.Item("Numero2") = dr("STOCKACTUAL")
                ds.Tables("Detalle").Rows.Add(row)
            Loop

        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try
        'InfOrganizarProductos
        Return ds

    End Function

    Public Function InfOrganizarProductos(ByVal empDescripcion As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT		RTRIM(PRODUCTOS.DESPRODUCTO)AS PRODUCTO,  " & _
              "isnull(FAMILIA.DESFAMILIA, 'Sin Familia') AS CATEGORIA, isnull(LINEA.DESLINEA, 'Sin Linea') AS LINEA ,isnull(RUBRO.DESRUBRO, 'Sin Marca') AS MARCA , " & _
              "UNIDADMEDIDA.DESMEDIDA AS MEDIDA FROM PRODUCTOS LEFT OUTER JOIN  " & _
              "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
              "LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA   " & _
              "AND FAMILIA.CODFAMILIA = LINEA.CODFAMILIA LEFT OUTER JOIN  " & _
              "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO   " & _
              "AND LINEA.CODLINEA = RUBRO.CODLINEA LEFT OUTER JOIN  " & _
              "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
              "STOCKDEPOSITO ON CODIGOS.CODCODIGO = STOCKDEPOSITO.CODCODIGO  " & _
              "AND CODIGOS.CODPRODUCTO = STOCKDEPOSITO.CODPRODUCTO  " & _
              "LEFT OUTER JOIN UNIDADMEDIDA ON UNIDADMEDIDA.CODMEDIDA = PRODUCTOS.CODMEDIDA " & _
              "WHERE(PRODUCTOS.ESTADO = 0 And SERVICIO = 0)" & _
              "GROUP BY FAMILIA.DESFAMILIA ,LINEA.DESLINEA,RUBRO.DESRUBRO," & _
              "PRODUCTOS.DESPRODUCTO,CODIGOS.DESCODIGO1,CODIGOS.DESCODIGO2," & _
              "UNIDADMEDIDA.DESMEDIDA"


        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("PRODUCTO")
                row.Item("Campo2") = dr("CATEGORIA")
                row.Item("Campo3") = dr("LINEA")
                row.Item("Campo4") = dr("MARCA")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo7") = dr("MEDIDA")
                ds.Tables("Detalle").Rows.Add(row)
            Loop

        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try

        Return ds

    End Function
    Public Function InfArticulosProducidos(ByVal empDescripcion As String, ByVal codsucursal As Integer, ByVal dessucursal As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT     PLANILLAPRODUCCIONDETALLE.CANTPLANPRODUCCION AS CANTIDAD, " & _
                "RTRIM(PRODUCTOS.DESPRODUCTO)+' '+LTRIM(CODIGOS.DESCODIGO1)+' '+LTRIM(CODIGOS.DESCODIGO2) AS PRODUCTO,  " & _
                "FAMILIA.DESFAMILIA AS CATEGORIA, LINEA.DESLINEA AS LINEA ,RUBRO.DESRUBRO AS MARCA, UNIDADMEDIDA.DESMEDIDA as MEDIDA," & _
                "ORDENPRODUCCIONCABECERA.NUMORDENPRODUCCION, PLANILLAPRODUCCIONCABECERA.NUMPLANILLAPRODUCCION " & _
                "FROM   PLANILLAPRODUCCIONDETALLE INNER JOIN " & _
                "CODIGOS ON PLANILLAPRODUCCIONDETALLE.CODCODIGO = CODIGOS.CODCODIGO AND  " & _
                "PLANILLAPRODUCCIONDETALLE.CODPRODUCTO = CODIGOS.CODPRODUCTO INNER JOIN " & _
                "PRODUCTOS ON CODIGOS.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                "UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA INNER JOIN " & _
                "ORDENPRODUCCIONCABECERA ON " & _
                "PLANILLAPRODUCCIONDETALLE.CODORDENPRODUCCION = ORDENPRODUCCIONCABECERA.CODORDENPRODUCCION INNER JOIN " & _
                "PLANILLAPRODUCCIONCABECERA ON  " & _
                "PLANILLAPRODUCCIONDETALLE.CODPLANILLAPRODUCCION = PLANILLAPRODUCCIONCABECERA.CODPLANILLAPRODUCCION INNER JOIN " & _
                "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA INNER JOIN " & _
                "LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA AND FAMILIA.CODFAMILIA = LINEA.CODFAMILIA INNER JOIN " & _
                "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO AND LINEA.CODLINEA = RUBRO.CODLINEA "
        If codsucursal <> 0 Then
            sql = sql + "WHERE PLANILLAPRODUCCIONCABECERA.CODSUCURSAL= " & codsucursal & " "
            If fechadesde = "" Or fechadesde = "  /  /    " And fechahasta = "" Or fechahasta = "  /  /    " Then
            ElseIf fechadesde <> "" Or fechadesde <> "  /  /    " And fechahasta <> "" Or fechahasta <> "  /  /    " Then
                sql = sql + "AND CONVERT(NVARCHAR(30),FECPLANILLA,103)>='" & fechadesde & "' AND CONVERT(NVARCHAR(30),FECPLANILLA,103) <= '" & fechahasta & "' "
            ElseIf fechadesde <> "" Or fechadesde <> "  /  /    " And fechahasta = "" Or fechahasta = "  /  /    " Then
                sql = sql + "AND CONVERT(NVARCHAR(30),FECPLANILLA,103)>='" & fechadesde & "'"
            ElseIf fechadesde = "" Or fechadesde = "  /  /    " And fechahasta <> "" Or fechahasta <> "  /  /    " Then
                sql = sql + "AND CONVERT(NVARCHAR(30),FECPLANILLA,103) <= '" & fechahasta & "'"
            End If
        Else

            If fechadesde = "" Or fechadesde = "  /  /    " And fechahasta = "" Or fechahasta = "  /  /    " Then
            ElseIf fechadesde <> "" Or fechadesde <> "  /  /    " And fechahasta <> "" Or fechahasta <> "  /  /    " Then

                sql = sql + "WHERE CONVERT(NVARCHAR(30),FECPLANILLA,103)>='" & fechadesde & "' AND CONVERT(NVARCHAR(30),FECPLANILLA,103) <= '" & fechahasta & "' "
            ElseIf fechadesde <> "" Or fechadesde <> "  /  /    " And fechahasta = "" Or fechahasta = "  /  /    " Then
                sql = sql + "WHERE CONVERT(NVARCHAR(30),FECPLANILLA,103)>='" & fechadesde & "'"
            ElseIf fechadesde = "" Or fechadesde = "  /  /    " And fechahasta <> "" Or fechahasta <> "  /  /    " Then
                sql = sql + "WHERE CONVERT(NVARCHAR(30),FECPLANILLA,103) <= '" & fechahasta & "'"
            End If
        End If




        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("PRODUCTO")
                row.Item("Campo2") = dr("CATEGORIA")
                row.Item("Campo3") = dr("LINEA")
                row.Item("Campo4") = dr("MARCA")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo6") = dessucursal
                row.Item("Campo7") = dr("MEDIDA")
                row.Item("Campo8") = dr("NUMORDENPRODUCCION")
                row.Item("Campo9") = dr("NUMPLANILLAPRODUCCION")
                row.Item("Numero1") = dr("CANTIDAD")
                row.Item("Campo10") = fechadesde
                row.Item("Campo11") = fechahasta
                ds.Tables("Detalle").Rows.Add(row)
            Loop

        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try
        'InfOrganizarProductos
        Return ds

    End Function

    Public Function InfstockProducto(ByVal empDescripcion As String, ByVal codsucursal As Integer, ByVal dessucursal As String, ByVal codfamilia As Integer, ByVal codgrupo As Integer, ByVal codsubgrupo As Integer) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT     STOCKDEPOSITO.STOCKACTUAL, SUCURSAL.DESSUCURSAL, RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1) " & _
                     " AS PRODUCTO, CODIGOS.CODIGO, RUBRO.DESRUBRO, LINEA.DESLINEA, UNIDADMEDIDA.DESMEDIDA, " & _
                     " FAMILIA.DESFAMILIA" & _
                     " FROM         STOCKDEPOSITO INNER JOIN " & _
                     " SUCURSAL ON STOCKDEPOSITO.CODDEPOSITO = SUCURSAL.CODSUCURSAL INNER JOIN " & _
                     " PRODUCTOS ON STOCKDEPOSITO.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                     " CODIGOS ON STOCKDEPOSITO.CODCODIGO = CODIGOS.CODCODIGO AND STOCKDEPOSITO.CODPRODUCTO = CODIGOS.CODPRODUCTO AND " & _
                     " PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                     " FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                     " LINEA ON FAMILIA.CODFAMILIA = LINEA.CODFAMILIA AND PRODUCTOS.CODLINEA = LINEA.CODLINEA LEFT OUTER JOIN " & _
                     " UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA FULL OUTER JOIN " & _
                     " RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO AND LINEA.CODLINEA = RUBRO.CODLINEA " & _
                     " WHERE     (PRODUCTOS.ESTADO = 0)"

        If codsucursal <> 0 Then
            sql = sql + "AND STOCKDEPOSITO.CODDEPOSITO = " & codsucursal & " "
        End If

        If codfamilia <> 0 Then
            sql = sql + "AND PRODUCTOS.CODFAMILIA = " & codfamilia & " "
        End If

        If codgrupo <> 0 Then
            sql = sql + "AND LINEA.CODLINEA = " & codgrupo & " "
        End If

        If codsubgrupo <> 0 Then
            sql = sql + "AND RUBRO.CODRUBRO = " & codsubgrupo & " "
        End If


        sql = sql + "GROUP BY SUCURSAL.DESSUCURSAL,FAMILIA.DESFAMILIA, LINEA.DESLINEA,RUBRO.DESRUBRO,CODIGOS.CODPRODUCTO,STOCKDEPOSITO.STOCKACTUAL," & _
            "PRODUCTOS.DESPRODUCTO, CODIGOS.CODIGO, CODIGOS.DESCODIGO1, CODIGOS.DESCODIGO2, UNIDADMEDIDA.DESMEDIDA"

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("PRODUCTO")
                row.Item("Campo2") = dr("DESFAMILIA")
                row.Item("Campo3") = dr("DESLINEA")
                row.Item("Campo4") = dr("DESRUBRO")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo6") = dr("DESSUCURSAL")
                row.Item("Campo7") = dr("DESMEDIDA")
                row.Item("Campo8") = dr("CODIGO")
                row.Item("Numero1") = dr("STOCKACTUAL")
                ds.Tables("Detalle").Rows.Add(row)
            Loop
            
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try
        'InfOrganizarProductos
        Return ds

    End Function

    Public Function InfMtoProducto(ByVal empDescripcion As String, ByVal codsucursal As Integer, ByVal dessucursal As String, ByVal desfamilia As String, _
                                   ByVal desgrupo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        Dim ds As New DsInformes
        Dim ControlWHERE As String
        Dim RangoFecha As String

        ControlWHERE = 0
        sql = ""
        sql = "DECLARE " & _
             "  @CODIGO AS VARCHAR(50)," & _
             "  @PRODUCTO AS VARCHAR(300)," & _
             "  @CANTIDAD NUMERIC(18,2)," & _
             "  @TIPOMOVIMIENTO AS VARCHAR(50)," & _
             "  @CONCEPTO AS VARCHAR(50)," & _
             "  @CODPRODUCTO AS INT," & _
             "  @CODCODIGO AS INT," & _
             "  @CODSUCURSAL AS INT, " & _
             "  @DESFAMILIA VARCHAR(50), " & _
             "  @DESGRUPO VARCHAR(50),   " & _
             "  @FECHAMTO DATETIME   " & _
            "DECLARE @VariableTabla  AS" & _
            "   TABLE(" & _
            "       CODIGO VARCHAR(50)," & _
            "       PRODUCTO VARCHAR(300)," & _
            "       STOCKINICIAL  DECIMAL(18,2), " & _
            "       COMPRA  DECIMAL(18,2)," & _
            "       DEVOLUCIONCLIENTE DECIMAL(18,2)," & _
            "       TRANSFERENCIAENTRADA  DECIMAL(18,2)," & _
            "       AJUSTEENTRADA  DECIMAL(18,2), " & _
            "       VENTA DECIMAL (18,2)," & _
            "       ENVIO DECIMAL(18,2)," & _
            "       TRANSFERENCIASALIDA DECIMAL(18,2)," & _
            "       AJUSTESALIDA DECIMAL(18,2)," & _
            "       DEVOLUCIONELIMINADO DECIMAL(18,2), " & _
            "       CODSUCURSAL INT , " & _
            "       FAMILIA VARCHAR(50), " & _
            "       GRUPO VARCHAR(50) , " & _
            "       FECHAMTO DATETIME " & _
            "        )  " & _
            "declare  cur_movimiento cursor for " & _
            "   SELECT CD.CODIGO, RTRIM(ISNULL(P.DESPRODUCTO,''))+' '+LTRIM(ISNULL(CD.DESCODIGO1,''))+' '+LTRIM(ISNULL(CD.DESCODIGO2,''))AS PRODUCTO," & _
            "          M.CANTIDAD,M.TIPOMOVIMIENTO,M.CONCEPTO,M.CODPRODUCTO,M.CODCODIGO,M.CODSUCURSAL, FAMILIA.DESFAMILIA, LINEA.DESLINEA, M.FECHAMTO" & _
            "   FROM MOVIMIENTOPRODUCTO M INNER JOIN  CODIGOS CD ON M.CODCODIGO=CD.CODCODIGO AND M.CODPRODUCTO=CD.CODPRODUCTO INNER JOIN PRODUCTOS P " & _
            "        ON  CD.CODPRODUCTO=P.CODPRODUCTO INNER JOIN FAMILIA ON P.CODFAMILIA = FAMILIA.CODFAMILIA  INNER JOIN LINEA ON P.CODLINEA = LINEA.CODLINEA   " & _
            "WHERE CONVERT(DATETIME,  CAST(M.FECHAMTO AS VARCHAR(11)),103) >=CONVERT(DATETIME, '" & FechaIni & "',103) AND CONVERT(DATETIME,  CAST(M.FECHAMTO AS VARCHAR(11)),103) <=CONVERT(DATETIME, '" & FechaFin & "',103)   " & _
            "open cur_movimiento  " & _
            "fetch next from  cur_movimiento  " & _
            "into @CODIGO,@PRODUCTO,@CANTIDAD,@TIPOMOVIMIENTO,@CONCEPTO,@CODPRODUCTO,@CODCODIGO,@CODSUCURSAL, @DESFAMILIA, @DESGRUPO, @FECHAMTO " & _
            "WHILE @@FETCH_STATUS = 0   " & _
            "BEGIN " & _
            "IF @TIPOMOVIMIENTO='ENTRADA' " & _
            "Begin " & _
            "IF @CONCEPTO='Stock Inicial' " & _
            "	Begin " & _
            "		INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO, FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,@CANTIDAD,0,0,0,0,0,0,0,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO, @FECHAMTO) " & _
            "	end 	 " & _
            "	IF @CONCEPTO='ENTRADA POR COMPRA' " & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,@CANTIDAD,0,0,0,0,0,0,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO) " & _
            "	end " & _
            "	IF @CONCEPTO='Transferencia' or @CONCEPTO='TRANSFERENCIA'" & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,0,0,@CANTIDAD,0,0,0,0,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO)" & _
            "	end " & _
            "	IF @CONCEPTO='AJUSTE'  OR @CONCEPTO='Ajuste' " & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,0,0,0,@CANTIDAD,0,0,0,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO, @FECHAMTO) " & _
            "	end " & _
            "	IF @CONCEPTO='ENTRADA POR DEVOLUCIÓN' " & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,0,@CANTIDAD,0,0,0,0,0,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO) " & _
            "	end " & _
            "End " & _
            "IF @TIPOMOVIMIENTO='SALIDA' " & _
            "Begin " & _
           "	IF @CONCEPTO='Transferencia' or @CONCEPTO='TRANSFERENCIA'" & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,0,@CANTIDAD,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO)" & _
            "	end " & _
            "	IF @CONCEPTO='AJUSTE'  OR @CONCEPTO='Ajuste' " & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,0,0,@CANTIDAD,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO) " & _
            "	end " & _
            "	IF @CONCEPTO='SALIDA POR VENTA' OR @CONCEPTO ='SALIDA POR VENTA (Combo)' " & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,0,0,0,0,@CANTIDAD,0,0,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO) " & _
            "	end " & _
            "	IF @CONCEPTO='ENVIO DE MERCADERIA'  OR @CONCEPTO='ENVIO DE MERCADERIA(Combo)'" & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,@CANTIDAD,0,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO) " & _
            "	end " & _
            "   IF @CONCEPTO='SALIDA POR ELIMINACIÓN EN DEVOLUCIÓN' or @CONCEPTO='SALIDA POR ELIMINAR DET COMPRA'  " & _
            "	Begin " & _
            "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA," & _
            "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES " & _
            "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,0,0,0,@CANTIDAD,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO) " & _
            " 	end " & _
            " End " & _
            "IF @TIPOMOVIMIENTO='ENTRADA/SALIDA'  " & _
           "Begin   " & _
           "		IF @CANTIDAD<0 " & _
           "					BEGIN  " & _
           "					DECLARE @CANTIDADVALORABSOLUTO AS NUMERIC(18,2) " & _
           "					SET @CANTIDADVALORABSOLUTO=@CANTIDAD*-1 " & _
           "					INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA, " & _
           "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO, FECHAMTO) VALUES   " & _
           "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,0,0,0,@CANTIDADVALORABSOLUTO,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO)   " & _
           "		END " & _
           "		IF @CANTIDAD>0 " & _
           "					BEGIN  " & _
           "					INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
           "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL, FAMILIA, GRUPO , FECHAMTO) VALUES    " & _
           "        (@CODIGO,@PRODUCTO,@CANTIDAD,0,0,0,0,0,0,0,0,0,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO , @FECHAMTO) " & _
           "		END " & _
           "End  " & _
            "fetch next from  cur_movimiento  into @CODIGO,@PRODUCTO,@CANTIDAD,@TIPOMOVIMIENTO,@CONCEPTO,@CODPRODUCTO,@CODCODIGO,@CODSUCURSAL, @DESFAMILIA,@DESGRUPO,@FECHAMTO " & _
            "End " & _
            "close cur_movimiento  " & _
            "deallocate cur_movimiento " & _
            "Select CODIGO ,PRODUCTO,SUM(STOCKINICIAL) AS STOCKINICIAL,SUM(COMPRA) AS COMPRA, " & _
            "SUM(DEVOLUCIONCLIENTE) AS DEVOLUCIONCLIENTE,SUM(TRANSFERENCIAENTRADA) AS TRANSFERENCIAENTRADA," & _
            "SUM(AJUSTEENTRADA)AS AJUSTEENTRADA,SUM(VENTA) AS VENTA," & _
            "SUM(ENVIO)AS ENVIO,SUM(TRANSFERENCIASALIDA) AS TRANSFERENCIASALIDA," & _
            "SUM(AJUSTESALIDA)AS AJUSTESALIDA,SUM(DEVOLUCIONELIMINADO)AS DEVOLUCIONELIMINADO," & _
            "CODSUCURSAL AS CODSUCURSAL, FAMILIA , GRUPO  from @VariableTabla "

        If codsucursal <> 0 Then
            sql = sql + "WHERE CODSUCURSAL = " & codsucursal & "   "
            ControlWHERE = 1
        End If

        If desfamilia <> "" Then
            If ControlWHERE = 1 Then
                sql = sql + "AND FAMILIA = '" & desfamilia & "'   "
            Else
                sql = sql + "WHERE FAMILIA = '" & desfamilia & "'   "
                ControlWHERE = 1
            End If
        End If

        If desgrupo <> "" Then
            If ControlWHERE = 1 Then
                sql = sql + " AND GRUPO = '" & desgrupo & "'  "
            Else
                sql = sql + " WHERE GRUPO = '" & desgrupo & "'  "
            End If
        End If

        sql = sql + "GROUP BY  CODIGO ,PRODUCTO,CODSUCURSAL , FAMILIA, GRUPO   " & _
                    "ORDER BY PRODUCTO "
        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader

            RangoFecha = "De " + FechaIni + "    Hasta  " + FechaFin

            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo8") = dr("CODIGO")
                row.Item("Campo1") = dr("PRODUCTO")
                row.Item("Campo2") = dr("FAMILIA")
                row.Item("Campo3") = dr("GRUPO")
                row.Item("Numero1") = dr("STOCKINICIAL")
                row.Item("Numero2") = dr("COMPRA")
                row.Item("Numero3") = dr("DEVOLUCIONCLIENTE")
                row.Item("Numero4") = dr("TRANSFERENCIAENTRADA")
                row.Item("Numero5") = dr("AJUSTEENTRADA")
                row.Item("Numero6") = dr("VENTA")
                row.Item("Numero7") = dr("ENVIO")
                row.Item("Numero8") = dr("TRANSFERENCIASALIDA")
                row.Item("Numero9") = dr("AJUSTESALIDA")
                row.Item("Numero10") = dr("DEVOLUCIONELIMINADO")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo6") = dessucursal
                row.Item("Campo4") = RangoFecha

                ds.Tables("Detalle").Rows.Add(row)
            Loop
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try
        'InfOrganizarProductos
        Return ds

    End Function
    Public Function InfMtoProductoDetallado(ByVal empDescripcion As String, ByVal codsucursal As Integer, _
                                            ByVal codproducto As Integer, ByVal codcodigo As Integer, _
                                            ByVal dessucursal As String, ByVal fecha1 As String, ByVal fecha2 As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "DECLARE " & _
        "@CODIGO AS VARCHAR(50),@PRODUCTO AS VARCHAR(300),@CANTIDAD NUMERIC(18,2),@TIPOMOVIMIENTO AS VARCHAR(50), " & _
        "@CONCEPTO AS VARCHAR(50),@CODPRODUCTO AS INT,@CODCODIGO AS INT,@CODSUCURSAL AS INT ,@FECHA DATETIME,  " & _
        "@DESFAMILIA AS VARCHAR(100),@DESLINEA AS VARCHAR(100),@DESRUBRO AS VARCHAR(100),  " & _
        "@SALDO AS NUMERIC(18,2)  " & _
        "DECLARE @VariableTabla    " & _
        "as TABLE(CODIGO VARCHAR(50),PRODUCTO VARCHAR(300),STOCKINICIAL  DECIMAL(18,2),    " & _
        "COMPRA  DECIMAL(18,2),DEVOLUCIONCLIENTE DECIMAL(18,2),TRANSFERENCIAENTRADA  DECIMAL(18,2),AJUSTEENTRADA  DECIMAL(18,2),   " & _
        "VENTA DECIMAL (18,2),ENVIO DECIMAL(18,2),TRANSFERENCIASALIDA DECIMAL(18,2),AJUSTESALIDA DECIMAL(18,2),DEVOLUCIONELIMINADO DECIMAL(18,2) " & _
        ",CODSUCURSAL INT,FECHA DATETIME,DESFAMILIA VARCHAR(100),DESLINEA VARCHAR(100),DESRUBRO VARCHAR(100),SALDO NUMERIC(18,2))  " & _
        "declare  cur_movimiento cursor for  " & _
        "SELECT CD.CODIGO,    " & _
        "RTRIM(ISNULL(P.DESPRODUCTO,''))+' '+LTRIM(ISNULL(CD.DESCODIGO1,''))+' '+LTRIM(ISNULL(CD.DESCODIGO2,''))AS PRODUCTO, " & _
        "M.CANTIDAD,M.TIPOMOVIMIENTO,M.CONCEPTO,M.CODPRODUCTO,M.CODCODIGO,M.CODSUCURSAL,M.FECHAMTO,  " & _
        "F.DESFAMILIA,L.DESLINEA,R.DESRUBRO  " & _
        "FROM MOVIMIENTOPRODUCTO M INNER JOIN  CODIGOS CD ON M.CODCODIGO=CD.CODCODIGO AND M.CODPRODUCTO=CD.CODPRODUCTO   " & _
        "INNER JOIN PRODUCTOS P   " & _
        "ON  CD.CODPRODUCTO=P.CODPRODUCTO   " & _
        "LEFT OUTER JOIN FAMILIA F   " & _
        "ON F.CODFAMILIA=P.CODFAMILIA  " & _
        "LEFT OUTER JOIN LINEA L  " & _
        "ON L.CODLINEA=P.CODLINEA  " & _
        "LEFT OUTER JOIN RUBRO R   " & _
        "ON R.CODRUBRO=P.CODRUBRO  " & _
        "WHERE CD.CODCODIGO= " & codcodigo & "  AND CD.CODPRODUCTO= " & codproducto & "  AND M.CODSUCURSAL= " & codsucursal & " " & _
        "AND CONVERT(DATETIME,  CAST(M.FECHAMTO AS VARCHAR(11)),103) >=CONVERT(DATETIME, '" & fecha1 & "',103) AND CONVERT(DATETIME,  CAST(M.FECHAMTO AS VARCHAR(11)),103) <=CONVERT(DATETIME, '" & fecha2 & "',103)   " & _
        "SET @SALDO=0    " & _
        "open cur_movimiento    " & _
        "fetch next from  cur_movimiento   " & _
        "into @CODIGO,@PRODUCTO,@CANTIDAD,@TIPOMOVIMIENTO,@CONCEPTO,@CODPRODUCTO,@CODCODIGO,@CODSUCURSAL ,@FECHA ,   " & _
        "@DESFAMILIA,@DESLINEA,@DESRUBRO   " & _
        "WHILE @@FETCH_STATUS = 0     " & _
        "BEGIN   " & _
        "IF @TIPOMOVIMIENTO='ENTRADA'   " & _
        "Begin   " & _
        "SET @SALDO=@SALDO+@CANTIDAD   " & _
        "   IF @CONCEPTO='Stock Inicial'   " & _
        "	Begin    " & _
        "		INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,   " & _
        "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES  " & _
        "        (@CODIGO,@PRODUCTO,@CANTIDAD,0,0,0,0,0,0,0,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)  " & _
        "   end 	 " & _
        "   IF @CONCEPTO='ENTRADA POR COMPRA'  " & _
        "	Begin   " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES   " & _
        "        (@CODIGO,@PRODUCTO,0,@CANTIDAD,0,0,0,0,0,0,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)  " & _
        "	end   " & _
        "	IF @CONCEPTO='Transferencia' or @CONCEPTO='TRANSFERENCIA'  " & _
        "	Begin   " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES   " & _
        "        (@CODIGO,@PRODUCTO,0,0,0,@CANTIDAD,0,0,0,0,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)  " & _
        "	end  " & _
        "	IF @CONCEPTO='AJUSTE'  OR @CONCEPTO='Ajuste'  " & _
        "	Begin   " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES  " & _
        "        (@CODIGO,@PRODUCTO,0,0,0,0,@CANTIDAD,0,0,0,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)    " & _
        "	end  " & _
        "	IF @CONCEPTO='ENTRADA POR DEVOLUCIÓN'  " & _
        "	Begin  " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES   " & _
        "        (@CODIGO,@PRODUCTO,0,0,@CANTIDAD,0,0,0,0,0,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)   " & _
        "	end  " & _
        "End   " & _
        "IF @TIPOMOVIMIENTO='SALIDA'   " & _
        "Begin   " & _
        "SET @SALDO=@SALDO-@CANTIDAD  " & _
         "	IF @CONCEPTO='Transferencia' or @CONCEPTO='TRANSFERENCIA'  " & _
        "	Begin   " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES  " & _
        "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,0,@CANTIDAD,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)  " & _
        "	end  " & _
        "	IF @CONCEPTO='AJUSTE'  OR @CONCEPTO='Ajuste'   " & _
        "	Begin   " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES  " & _
        "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,0,0,@CANTIDAD,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)   " & _
        "	end   " & _
        "	IF @CONCEPTO='SALIDA POR VENTA'   OR @CONCEPTO ='SALIDA POR VENTA (Combo)' " & _
        "	Begin  " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES  " & _
        "        (@CODIGO,@PRODUCTO,0,0,0,0,0,@CANTIDAD,0,0,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)   " & _
        "	end  " & _
        "	IF @CONCEPTO='ENVIO DE MERCADERIA'  OR @CONCEPTO='ENVIO DE MERCADERIA(Combo)'" & _
        "	Begin  " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "       VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES " & _
        "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,@CANTIDAD,0,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)  " & _
        "	end   " & _
        "   IF @CONCEPTO='SALIDA POR ELIMINACIÓN EN DEVOLUCIÓN'  or @CONCEPTO='SALIDA POR ELIMINAR DET COMPRA'  " & _
        "	Begin   " & _
        "	INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,   " & _
        "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES   " & _
        "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,0,0,0,@CANTIDAD,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO) " & _
        "	end   " & _
        "End   " & _
        "IF @TIPOMOVIMIENTO='ENTRADA/SALIDA'  " & _
        "Begin   " & _
        "		IF @CANTIDAD<0 " & _
        "					BEGIN  " & _
        "					DECLARE @CANTIDADVALORABSOLUTO AS NUMERIC(18,2) " & _
        "					SET @CANTIDADVALORABSOLUTO=@CANTIDAD*-1 " & _
        "					SET @SALDO=@SALDO-@CANTIDADVALORABSOLUTO  " & _
        "					INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA, " & _
        "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES   " & _
        "        (@CODIGO,@PRODUCTO,0,0,0,0,0,0,0,0,0,@CANTIDADVALORABSOLUTO,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO)   " & _
        "		END " & _
        "		IF @CANTIDAD>0 " & _
        "					BEGIN  " & _
        "					 SET @SALDO=@SALDO+@CANTIDAD  " & _
        "					INSERT @VariableTabla (CODIGO ,PRODUCTO,STOCKINICIAL,COMPRA,DEVOLUCIONCLIENTE,TRANSFERENCIAENTRADA,AJUSTEENTRADA,  " & _
        "        VENTA,ENVIO,TRANSFERENCIASALIDA,AJUSTESALIDA,DEVOLUCIONELIMINADO,CODSUCURSAL,FECHA,DESFAMILIA,DESLINEA,DESRUBRO,SALDO) VALUES    " & _
        "        (@CODIGO,@PRODUCTO,@CANTIDAD,0,0,0,0,0,0,0,0,0,@CODSUCURSAL,@FECHA,@DESFAMILIA,@DESLINEA,@DESRUBRO,@SALDO) " & _
        "		END " & _
        "End  " & _
        "fetch next from  cur_movimiento  into  @CODIGO,@PRODUCTO,@CANTIDAD,@TIPOMOVIMIENTO,@CONCEPTO,@CODPRODUCTO,@CODCODIGO,@CODSUCURSAL ,@FECHA , " & _
        "@DESFAMILIA,@DESLINEA,@DESRUBRO    " & _
        "End   " & _
        "close cur_movimiento     " & _
        "deallocate cur_movimiento    " & _
        "Select CODIGO ,PRODUCTO,STOCKINICIAL ,COMPRA ,    " & _
        "DEVOLUCIONCLIENTE ,TRANSFERENCIAENTRADA,  " & _
        "AJUSTEENTRADA ,VENTA ," & _
        "ENVIO ,TRANSFERENCIASALIDA ,  " & _
        "AJUSTESALIDA ,DEVOLUCIONELIMINADO ,  " & _
        "CODSUCURSAL ,FECHA ,  " & _
        "DESFAMILIA,DESLINEA,DESRUBRO,SALDO  " & _
        "from @VariableTabla " & _
        "ORDER BY FECHA "


        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo8") = dr("CODIGO")
                row.Item("Campo1") = dr("PRODUCTO")
                row.Item("Numero1") = dr("STOCKINICIAL")
                row.Item("Numero2") = dr("COMPRA")
                row.Item("Numero3") = dr("DEVOLUCIONCLIENTE")
                row.Item("Numero4") = dr("TRANSFERENCIAENTRADA")
                row.Item("Numero5") = dr("AJUSTEENTRADA")
                row.Item("Numero6") = dr("VENTA")
                row.Item("Numero7") = dr("ENVIO")
                row.Item("Numero8") = dr("TRANSFERENCIASALIDA")
                row.Item("Numero9") = dr("AJUSTESALIDA")
                row.Item("Numero10") = dr("DEVOLUCIONELIMINADO")
                row.Item("Numero11") = dr("SALDO")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo6") = dessucursal
                row.Item("Campo2") = dr("DESFAMILIA")
                row.Item("Campo4") = dr("DESLINEA")
                row.Item("Campo9") = dr("DESRUBRO")
                row.Item("Fecha1") = dr("FECHA")
                row.Item("Fecha2") = fecha1
                row.Item("Fecha3") = fecha2



                ds.Tables("Detalle").Rows.Add(row)
            Loop
    
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try
        'InfOrganizarProductos
        Return ds

    End Function
    Public Function InfstockMateriaPrima(ByVal empDescripcion As String, ByVal codsucursal As Integer, ByVal dessucursal As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT	RTRIM(MATERIAPRIMA.DESCRIPCION) AS MATERIAPRIMA,   " & _
            "CATEGORIAMATERIAPRIMA.DESCATEGORIA AS CATEGORIA,  " & _
            "ISNULL(STOCKMATERIAPRIMA.STOCKACTUAL,0) AS STOCKACTUAL, " & _
            "UNIDADMEDIDA.DESMEDIDA AS MEDIDA , " & _
            "SUCURSAL.DESSUCURSAL FROM MATERIAPRIMA " & _
            "LEFT OUTER JOIN CATEGORIAMATERIAPRIMA ON MATERIAPRIMA.CODCATEGORIAMATERIAPRIMA = CATEGORIAMATERIAPRIMA.CODCATEGORIA " & _
            "LEFT OUTER JOIN STOCKMATERIAPRIMA ON MATERIAPRIMA.CODMATERIAPRIMA  = STOCKMATERIAPRIMA.CODMATERIAPRIMA  " & _
            "LEFT OUTER JOIN SUCURSAL ON SUCURSAL.CODSUCURSAL=STOCKMATERIAPRIMA.CODDEPOSITO  " & _
            "LEFT OUTER JOIN UNIDADMEDIDA ON UNIDADMEDIDA.CODMEDIDA = MATERIAPRIMA.CODMEDIDA   "
        If codsucursal <> 0 Then
            sql = sql + "WHERE STOCKMATERIAPRIMA.CODDEPOSITO = " & codsucursal & " "
        End If

        sql = sql + "GROUP BY SUCURSAL.DESSUCURSAL,CATEGORIAMATERIAPRIMA.DESCATEGORIA," & _
                    "MATERIAPRIMA.DESCRIPCION, UNIDADMEDIDA.DESMEDIDA, STOCKMATERIAPRIMA.STOCKACTUAL"

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("MATERIAPRIMA")
                row.Item("Campo2") = dr("CATEGORIA")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo6") = dr("DESSUCURSAL")
                row.Item("Campo7") = dr("MEDIDA")
                row.Item("Numero1") = dr("STOCKACTUAL")
                ds.Tables("Detalle").Rows.Add(row)
            Loop
          
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try
        'InfOrganizarProductos
        Return ds

    End Function
    Public Function InfstockKitCombo(ByVal empDescripcion As String, ByVal codsucursal As Integer, ByVal dessucursal As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT COMBO.DESCOMBO,MIN((ISNULL(STOCKDEPOSITO.STOCKACTUAL,0)/COMBODETALLE.CANTIDAD)) AS STOCK," & _
              "SUCURSAL.DESSUCURSAL " & _
              "FROM COMBO INNER JOIN COMBODETALLE ON COMBO.CODCOMBO=COMBODETALLE.CODCOMBO " & _
              "INNER JOIN CODIGOS ON COMBODETALLE.CODCODIGO=CODIGOS.CODCODIGO AND COMBODETALLE.CODPRODUCTO=CODIGOS.CODPRODUCTO " & _
              "INNER JOIN STOCKDEPOSITO ON CODIGOS.CODCODIGO=STOCKDEPOSITO.CODCODIGO AND CODIGOS.CODPRODUCTO=STOCKDEPOSITO.CODPRODUCTO " & _
              "INNER JOIN SUCURSAL ON STOCKDEPOSITO.CODDEPOSITO=SUCURSAL.CODSUCURSAL "
        If codsucursal <> 0 Then
            sql = sql + "WHERE STOCKDEPOSITO.CODDEPOSITO = " & codsucursal & " "
        End If

        sql = sql + "GROUP BY SUCURSAL.DESSUCURSAL,COMBO.DESCOMBO"

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("DESCOMBO")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo6") = dr("DESSUCURSAL")
                row.Item("Numero1") = dr("STOCK")
                ds.Tables("Detalle").Rows.Add(row)
            Loop
          
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try
        'InfOrganizarProductos
        Return ds

    End Function
    Public Function InfProductoporProveedor(ByVal empDescripcion As String, ByVal codproveedor As Integer, ByVal desproveedor As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT		RTRIM(PRODUCTOS.DESPRODUCTO)+' '+LTRIM(CODIGOS.DESCODIGO1)+' '+LTRIM(CODIGOS.DESCODIGO2) AS PRODUCTO,  " & _
            "FAMILIA.DESFAMILIA AS CATEGORIA, LINEA.DESLINEA AS LINEA ,RUBRO.DESRUBRO AS MARCA , " & _
            "RTRIM(PROVEEDOR.NOMBRE)+' ' +LTRIM(PROVEEDOR.APELLIDO) AS PROVEEDOR," & _
            "UNIDADMEDIDA.DESMEDIDA AS MEDIDA FROM PRODUCTOS LEFT OUTER JOIN  " & _
            "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN  " & _
            "LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA   " & _
            "AND FAMILIA.CODFAMILIA = LINEA.CODFAMILIA LEFT OUTER JOIN  " & _
            "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO   " & _
            "AND LINEA.CODLINEA = RUBRO.CODLINEA LEFT OUTER JOIN  " & _
            "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
            "PROVEEDOR ON PRODUCTOS.CODPROVEEDOR=PROVEEDOR.CODPROVEEDOR " & _
            "LEFT OUTER JOIN UNIDADMEDIDA ON UNIDADMEDIDA.CODMEDIDA = PRODUCTOS.CODMEDIDA  " & _
            "WHERE(PRODUCTOS.ESTADO = 0 And SERVICIO = 0)"

        If codproveedor <> 0 Then
            sql = sql + "AND PROVEEDOR.CODPROVEEDOR = " & codproveedor & " "
        End If

        sql = sql + "GROUP BY PROVEEDOR.NOMBRE,PROVEEDOR.APELLIDO,PRODUCTOS.DESPRODUCTO,CODIGOS.DESCODIGO1,CODIGOS.DESCODIGO2," & _
            "FAMILIA.DESFAMILIA,LINEA.DESLINEA,RUBRO.DESRUBRO,UNIDADMEDIDA.DESMEDIDA"
        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()
                row.Item("Campo1") = dr("PRODUCTO")
                row.Item("Campo2") = dr("CATEGORIA")
                row.Item("Campo3") = dr("LINEA")
                row.Item("Campo4") = dr("MARCA")
                row.Item("Campo5") = empDescripcion
                row.Item("Campo6") = dr("PROVEEDOR")
                row.Item("Campo7") = dr("MEDIDA")
                ds.Tables("Detalle").Rows.Add(row)
            Loop
          
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try
        'InfOrganizarProductos
        Return ds

    End Function
    Public Function infDiarioCaja(ByVal desdeCaja As String, ByVal hastaCaja As String, _
   ByVal desdeFecha As String, ByVal hastaFecha As String, _
   ByVal desdeHora As String, ByVal hastaHora As String, ByVal hora As Boolean, _
   ByVal codMoneda As Long, ByVal moneda As String, ByVal cotizacion As String, _
   ByVal canDecimales As Integer, ByVal tipo As Integer, _
   ByVal condicionesIngreso As String, ByVal condicionesEgreso As String, ByVal EmpCodigo As Integer, ByVal EmpDescripcion As String) As DataSet
        Dim fechaInicio As String
        fechaInicio = ""

        Dim ds As New DsInformes

        sql = ""
        sql = " SELECT MAX(1) AS MOVIMIENTO, MAX(1) AS ORDEN, " & _
        " MAX(CONVERT(VARCHAR(10), CI.FECINGRESO, 103)) AS FECHA, " & _
        " MAX(CONVERT(DATETIME,CI.FECINGRESO,103)) AS FECHAORDEN, " & _
        " MAX(CONVERT(DATETIME,CI.FECGRA,103)) AS HORAORDEN, " & _
        " MAX(C.NUMCAJA) AS NUMCAJA, MAX(RTRIM(C.NUMEROCAJA) + ' - ' + RTRIM(CB.DESUSUARIO)) AS CAJA, " & _
        " MAX(RTRIM(TF.NUMFORCOBRO)) AS NUMFORCOBRO, MAX(RTRIM(TF.DESFORCOBRO)) AS DESFORCOBRO, " & _
        " MAX(RTRIM(TE.NUMTIPOEGRESO)) AS TIPO , MAX(RTRIM(TE.DESTIPOEGRESO)) AS CONCEPTO, " & _
        " MAX(CI.CODMONEDA) AS CODMONEDA, MAX(RTRIM(M.DESMONEDA)) AS DESMONEDA, " & _
        " SUM(CI.IMPORTE) AS IMPORTE, SUM(CI.IMPORTE * CI.COTIZACION1) AS IMPORTEINFORME, MAX(TE.PRIORIDAD) AS PRIORIDAD " & _
        " FROM CAJAINGRESOS CI INNER JOIN CAJA C ON CI.NUMCAJA = C.NUMCAJA " & _
        " INNER JOIN TIPOEGRESO TE ON CI.CODTIPOEGRESO = TE.CODTIPOEGRESO " & _
        " INNER JOIN MONEDA M ON CI.CODMONEDA = M.CODMONEDA " & _
        " INNER JOIN USUARIO CB ON CI.CODUSUARIO = CB.CODUSUARIO " & _
        " INNER JOIN TIPOFORMACOBRO TF ON TF.CODFORCOBRO = CI.CODFORCOBRO " & _
        " WHERE CI.TIPOINGRESO = 1 " & _
        " AND CI.CODEMPRESA = " & EmpCodigo & " " & condicionesIngreso & " " & _
        " GROUP BY CI.FECINGRESO, CI.NUMCAJA, CI.CODMONEDA, CI.CODFORCOBRO, CI.CODTIPOEGRESO " & _
        " UNION ALL " & _
        " /*EGRESOS*/ " & _
        " SELECT MAX(2) AS MOVIMIENTO, MAX(4) AS ORDEN, " & _
        " MAX(CONVERT(VARCHAR(10), CE.FECHAMOVIMIENTO, 103)) AS FECHA, " & _
        " MAX(CONVERT(DATETIME,CE.FECHAMOVIMIENTO,103)) AS FECHAORDEN, " & _
        " MAX(CONVERT(DATETIME,CE.FECGRA,103)) AS HORAORDEN, " & _
        " MAX(C.NUMCAJA) AS NUMCAJA, MAX(RTRIM(C.NUMEROCAJA) + ' - ' + RTRIM(CB.DESUSUARIO)) AS CAJA, " & _
        " MAX(RTRIM(TF.NUMFORCOBRO)) AS NUMFORCOBRO, MAX(RTRIM(TF.DESFORCOBRO)) AS DESFORCOBRO, " & _
        " MAX(RTRIM(TE.NUMTIPOEGRESO)) AS TIPO, MAX(RTRIM(TE.DESTIPOEGRESO)) AS CONCEPTO, " & _
        " MAX(CE.CODMONEDA) AS CODMONEDA, MAX(RTRIM(M.DESMONEDA)) AS DESMONEDA, " & _
        " SUM(CE.IMPORTE) AS IMPORTE, SUM(CE.IMPORTE * CE.COTIZACION1) AS IMPORTEINFORME, MAX(TE.PRIORIDAD) AS PRIORIDAD " & _
        " FROM CAJAEGRESOS CE INNER JOIN CAJA C ON CE.NUMCAJA = C.NUMCAJA " & _
        " INNER JOIN TIPOEGRESO TE ON CE.CODTIPOEGRESO = TE.CODTIPOEGRESO " & _
        " INNER JOIN MONEDA M ON CE.CODMONEDA = M.CODMONEDA " & _
        " INNER JOIN USUARIO CB ON CE.CODUSUARIO = CB.CODUSUARIO " & _
        " INNER JOIN TIPOFORMACOBRO TF ON TF.CODFORCOBRO = CE.CODFORCOBRO " & _
        " WHERE CE.CODEMPRESA = " & EmpCodigo & " " & condicionesEgreso & " " & _
        " GROUP BY CE.FECHAMOVIMIENTO, CE.NUMCAJA, CE.CODMONEDA, CE.CODFORCOBRO, CE.CODTIPOEGRESO " & _
        " UNION ALL " & _
        " /*FACTURAS COBRADAS*/ " & _
        " SELECT MAX(3) AS MOVIMIENTO, MAX(2) AS ORDEN, " & _
        " MAX(CONVERT(VARCHAR(10), CI.FECINGRESO, 103)) AS FECHA, " & _
        " MAX(CONVERT(DATETIME,CI.FECINGRESO,103)) AS FECHAORDEN, " & _
        " MAX(CONVERT(DATETIME,CI.FECGRA,103)) AS HORAORDEN, " & _
        " MAX(C.NUMCAJA) AS NUMCAJA, MAX(RTRIM(C.NUMEROCAJA) + ' - ' + RTRIM(CB.DESUSUARIO)) AS CAJA, " & _
        " MAX(RTRIM(TF.NUMFORCOBRO)) AS NUMFORCOBRO, MAX(RTRIM(TF.DESFORCOBRO)) AS DESFORCOBRO, " & _
        " '' AS TIPO, MAX(RTRIM(TF.DESFORCOBRO) + ' por facturas cobradas ') AS CONCEPTO, " & _
        " MAX(CF.CODMONEDA) AS CODMONEDA, MAX(RTRIM(M.DESMONEDA)) AS DESMONEDA, " & _
        " SUM(CF.IMPORTE) AS IMPORTE, SUM(CF.IMPORTE * CF.COTIZACION1) AS IMPORTEINFORME, 0 AS PRIORIDAD " & _
        " FROM CAJAINGRESOS CI INNER JOIN CAJA C ON CI.NUMCAJA = C.NUMCAJA " & _
        " INNER JOIN CAJAFORMACOBRO CF ON CI.CODINGRESO = CF.CODINGRESO " & _
        " INNER JOIN TIPOFORMACOBRO TF ON CF.CODFORCOBRO = TF.CODFORCOBRO " & _
        " INNER JOIN MONEDA M ON CF.CODMONEDA = M.CODMONEDA " & _
        " INNER JOIN USUARIO CB ON CI.CODUSUARIO = CB.CODUSUARIO " & _
        " WHERE CI.TIPOINGRESO = 0 " & _
        " AND CI.CODEMPRESA = " & EmpCodigo & " " & condicionesIngreso & " " & _
        " GROUP BY CI.FECINGRESO, CI.NUMCAJA, CF.CODMONEDA, CF.CODFORCOBRO " & _
        " UNION ALL " & _
        " /*VUELTO*/ " & _
        " SELECT MAX(4) AS MOVIMIENTO, MAX(3) AS ORDEN, " & _
        " MAX(CONVERT(VARCHAR(10), CI.FECINGRESO, 103)) AS FECHA, " & _
        " MAX(CONVERT(DATETIME,CI.FECINGRESO,103)) AS FECHAORDEN, " & _
        " MAX(CONVERT(DATETIME,CI.FECGRA,103)) AS HORAORDEN, " & _
        " MAX(C.NUMCAJA) AS NUMCAJA, MAX(RTRIM(C.NUMEROCAJA) + ' - ' + RTRIM(CB.DESUSUARIO)) AS CAJA, " & _
        " 'EFE' AS NUMFORCOBRO, 'Efectivo' AS DESFORCOBRO, " & _
        " '' AS TIPO, 'Vuelto' AS CONCEPTO, " & _
        " MAX(CI.CODMONEDA) AS CODMONEDA, MAX(RTRIM(M.DESMONEDA)) AS DESMONEDA, " & _
        " SUM(CI.VUELTO) * -1 AS IMPORTE, " & _
        " SUM(CI.VUELTO * CI.COTIZACION1) * -1 AS IMPORTEINFORME, 0 AS PRIORIDAD " & _
        " FROM CAJAINGRESOS CI INNER JOIN CAJA C ON CI.NUMCAJA = C.NUMCAJA " & _
        " INNER JOIN MONEDA M ON CI.CODMONEDA = M.CODMONEDA " & _
       " INNER JOIN USUARIO CB ON CI.CODUSUARIO = CB.CODUSUARIO " & _
        " WHERE CI.TIPOINGRESO = 0 " & _
        " AND CI.CODEMPRESA = " & EmpCodigo & " " & condicionesIngreso & " " & _
        " GROUP BY CI.FECINGRESO, CI.NUMCAJA, CI.CODMONEDA " & _
        " ORDER BY FECHAORDEN, CAJA, DESMONEDA, NUMFORCOBRO, ORDEN, MOVIMIENTO, TIPO "

        Try


            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql

            dr = cmd.ExecuteReader

            Do While dr.Read
                ''''''''''''''''''''''''
                ''''SALDO REAL
                ''''''''''''''''''''''''

                If fechaInicio <> dr("FECHA") Then
                    fechaInicio = dr("FECHA")

                    If tipo = 1 Then
                        sql = ""
                        sql = "SELECT CS.SALDOCIERRE AS IMPORTE, " & _
                        "(CS.SALDOCIERRE * CS.COTIZACION1) AS IMPORTEINFORME, " & _
                        "CS.CODMONEDA AS CODMONEDA, RTRIM(M.DESMONEDA) AS DESMONEDA, " & _
                        "RTRIM(TF.NUMFORCOBRO) AS NUMFORCOBRO, RTRIM(TF.DESFORCOBRO) AS DESFORCOBRO " & _
                        "FROM CAJACIERRE CCI INNER JOIN CAJASALDO CS ON CCI.NUMCIERRE = CS.NUMCIERRE " & _
                        "INNER JOIN MONEDA M ON CS.CODMONEDA = M.CODMONEDA " & _
                        "INNER JOIN TIPOFORMACOBRO TF ON TF.CODFORCOBRO = CS.CODFORCOBRO " & _
                        "WHERE CCI.NUMCAJA = " & dr("NUMCAJA") & " " & _
                        "AND CCI.CODEMPRESA = " & EmpCodigo & " " & _
                        "AND CCI.FECCIERRE = CONVERT(DATETIME,'" & dr("FECHA") & "',103)"

                        ser.Abrir(sqlc1)
                        cmd1.Connection = sqlc1
                        cmd1.CommandText = sql
                        dr1 = cmd1.ExecuteReader

                        Do While dr1.Read
                            row = ds.Tables("Detalle").NewRow()

                            row.Item("Campo1") = dr("FECHA")
                            row.Item("Campo2") = dr("CAJA")
                            row.Item("Campo4") = dr1("DESMONEDA")
                            row.Item("Campo5") = dr1("DESFORCOBRO")
                            row.Item("Campo3") = "SALDO REAL"
                            'cabecera##############################
                            'row.Item("Campo1") = EmpDescripcion
                            'row.Item("Campo7") = desdeFecha
                            'row.Item("Campo8") = hastaFecha
                            'row.Item("Campo9") = desdeCaja
                            'row.Item("Campo10") = moneda
                            'row.Item("Numero4") = cotizacion
                            '##########################################
                            row.Item("Numero1") = dr1("IMPORTE")

                            If codMoneda = dr1("CODMONEDA") Then
                                row.Item("Numero2") = dr1("IMPORTE")
                            Else
                                row.Item("Numero2") = Math.Round(dr1("IMPORTEINFORME") / cotizacion, canDecimales)
                            End If

                            row.Item("Numero5") = 0

                            ds.Tables("Detalle").Rows.Add(row)
                        Loop

                        sqlc1.Close()
                        dr1.Close()
                    End If
                End If
                ''''''''''''''''''''''''
                'SALDO REAL
                ''''''''''''''''''''''''

                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = dr("FECHA")
                row.Item("Campo2") = dr("CAJA")
                row.Item("Campo4") = dr("DESMONEDA")
                row.Item("Campo5") = dr("DESFORCOBRO")
                row.Item("Campo3") = dr("CONCEPTO")
                'cabecera##############################
                'row.Item("Campo1") = EmpDescripcion
                'row.Item("Campo7") = desdeFecha
                'row.Item("Campo8") = hastaFecha
                'row.Item("Campo9") = desdeCaja
                'row.Item("Campo10") = moneda
                'row.Item("Numero4") = cotizacion
                '##########################################
                If Not dr("MOVIMIENTO") = 2 Then
                    row.Item("Numero1") = dr("IMPORTE")

                    If codMoneda = dr("CODMONEDA") Then
                        row.Item("Numero2") = dr("IMPORTE")
                    Else
                        row.Item("Numero2") = Math.Round(dr("IMPORTEINFORME") / cotizacion, canDecimales)
                    End If

                    row.Item("Numero3") = 0
                    row.Item("Numero4") = 0
                Else
                    row.Item("Numero1") = 0
                    row.Item("Numero2") = 0

                    row.Item("Numero3") = dr("IMPORTE")

                    If codMoneda = dr("CODMONEDA") Then
                        row.Item("Numero4") = dr("IMPORTE")
                    Else
                        row.Item("Numero4") = Math.Round(dr("IMPORTEINFORME") / cotizacion, canDecimales)
                    End If
                End If

                row.Item("Numero5") = dr("PRIORIDAD")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            '###################
            '#    CABECERA     #
            '###################
            row = ds.Tables("Cabecera").NewRow()

            row.Item("Campo1") = EmpDescripcion
            row.Item("Campo2") = desdeFecha
            row.Item("Campo3") = hastaFecha
            row.Item("Campo4") = desdeCaja
            row.Item("Campo5") = hastaCaja

            If hora = True Then
                row.Item("Campo7") = desdeHora
                row.Item("Campo8") = hastaHora
            End If

            row.Item("Campo6") = moneda
            row.Item("Numero2") = cotizacion

            ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally
            sqlc.Close()
            sqlc1.Close()
        End Try

        Return ds
    End Function

    Public Function infRendicionCaja(ByVal NumeroCaja As String, ByVal FechaDesde As String, ByVal FechaHasta As String, ByVal moneda As String, _
                                     ByVal DescSucursal As String, ByVal EmpDescripcion As String, ByVal cotizacion As String) As DataSet

        Dim ds As New DsInformes

        sql = ""
        'sql = "SELECT dbo.CAJA.NUMCAJA, dbo.USUARIO.DESUSUARIO, dbo.movimientos.fecha_mto, dbo.movimientos.monto, dbo.movimientos.entradasalida, dbo.VENTAS.NUMVENTA, " & _
        '      "dbo.COMPRAS.NUMCOMPRA, dbo.COMPRASFORMAPAGO.NROCUOTA AS CuotaPago, dbo.VENTASFORMACOBRO.NROCUOTA AS CuotaCobro, dbo.MONEDA.DESMONEDA, dbo.EMPRESA.NOMFANTASIA, dbo.SUCURSAL.DESSUCURSAL, dbo.movimientos.id_apertura, SUM(dbo.aperturas_det.monto) " & _
        '      "AS SumAperturas " & _
        '      "FROM dbo.SUCURSAL INNER JOIN dbo.CAJA INNER JOIN dbo.aperturas ON dbo.CAJA.NUMCAJA = dbo.aperturas.id_caja INNER JOIN dbo.movimientos ON dbo.aperturas.id_apertura = dbo.movimientos.id_apertura INNER JOIN " & _
        '      "dbo.USUARIO ON dbo.movimientos.id_usuario = dbo.USUARIO.CODUSUARIO AND dbo.movimientos.id_empresa = dbo.USUARIO.CODEMPRESA INNER JOIN dbo.MONEDA ON dbo.movimientos.id_moneda = dbo.MONEDA.CODMONEDA INNER JOIN " & _
        '      "dbo.EMPRESA ON dbo.USUARIO.CODEMPRESA = dbo.EMPRESA.CODEMPRESA ON dbo.SUCURSAL.CODSUCURSAL = dbo.movimientos.codsucursal INNER JOIN dbo.aperturas_det ON dbo.aperturas.id_apertura = dbo.aperturas_det.id_apertura AND dbo.MONEDA.CODMONEDA = dbo.aperturas_det.id_moneda LEFT OUTER JOIN " & _
        '      "dbo.VENTASFORMACOBRO ON dbo.movimientos.id_cobro = dbo.VENTASFORMACOBRO.CODCOBRO AND dbo.movimientos.id_venta = dbo.VENTASFORMACOBRO.CODVENTA LEFT OUTER JOIN " & _
        '      "dbo.COMPRAS ON dbo.movimientos.id_compra = dbo.COMPRAS.CODCOMPRA LEFT OUTER JOIN dbo.VENTAS ON dbo.movimientos.id_venta = dbo.VENTAS.CODVENTA LEFT OUTER JOIN dbo.COMPRASFORMAPAGO ON dbo.movimientos.id_compra = dbo.COMPRASFORMAPAGO.CODCOMPRA AND " & _
        '      "dbo.movimientos.id_pago = dbo.COMPRASFORMAPAGO.CODPAGO " & _
        '      "GROUP BY dbo.CAJA.NUMCAJA, dbo.USUARIO.DESUSUARIO, dbo.movimientos.fecha_mto, dbo.movimientos.monto, dbo.movimientos.entradasalida, dbo.VENTAS.NUMVENTA, " & _
        '      "dbo.COMPRAS.NUMCOMPRA, dbo.COMPRASFORMAPAGO.NROCUOTA, dbo.VENTASFORMACOBRO.NROCUOTA, dbo.MONEDA.DESMONEDA, dbo.EMPRESA.NOMFANTASIA, dbo.SUCURSAL.DESSUCURSAL, dbo.movimientos.id_apertura " & _
        '      "HAVING(dbo.movimientos.fecha_mto >= CONVERT(DATETIME, '" & FechaDesde & "', 103)) AND (dbo.movimientos.fecha_mto <= CONVERT(DATETIME, '" & FechaHasta & "', 103))" & _
        '      "AND (dbo.MONEDA.DESMONEDA = '" & moneda & "' ) AND (dbo.CAJA.NUMCAJA =" & NumeroCaja & ") AND (dbo.SUCURSAL.DESSUCURSAL = '" & DescSucursal & "')"

        sql = "SELECT TOP (100) PERCENT dbo.CAJA.NUMCAJA, dbo.USUARIO.DESUSUARIO, dbo.movimientos.fecha_mto, dbo.movimientos.monto, dbo.movimientos.entradasalida,   " & _
              "dbo.VENTAS.NUMVENTA, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRASFORMAPAGO.NROCUOTA AS CuotaPago, dbo.VENTASFORMACOBRO.NROCUOTA AS CuotaCobro, dbo.MONEDA.DESMONEDA, dbo.EMPRESA.NOMFANTASIA, dbo.SUCURSAL.DESSUCURSAL,  " & _
              "dbo.movimientos.id_apertura, dbo.movimientos.concepto, dbo.movimientos.cotizacion1, dbo.movimientos.monto / dbo.movimientos.cotizacion1 AS MontoReal  " & _
              "FROM dbo.SUCURSAL INNER JOIN dbo.CAJA INNER JOIN dbo.aperturas ON dbo.CAJA.NUMCAJA = dbo.aperturas.id_caja INNER JOIN dbo.movimientos ON dbo.aperturas.id_apertura = dbo.movimientos.id_apertura INNER JOIN  " & _
              "dbo.USUARIO ON dbo.movimientos.id_usuario = dbo.USUARIO.CODUSUARIO AND dbo.movimientos.id_empresa = dbo.USUARIO.CODEMPRESA INNER JOIN dbo.MONEDA ON dbo.movimientos.id_moneda = dbo.MONEDA.CODMONEDA INNER JOIN  " & _
              "dbo.EMPRESA ON dbo.USUARIO.CODEMPRESA = dbo.EMPRESA.CODEMPRESA ON dbo.SUCURSAL.CODSUCURSAL = dbo.movimientos.codsucursal INNER JOIN dbo.aperturas_det ON dbo.aperturas.id_apertura = dbo.aperturas_det.id_apertura AND dbo.MONEDA.CODMONEDA = dbo.aperturas_det.id_moneda LEFT OUTER JOIN  " & _
              "dbo.VENTASFORMACOBRO ON dbo.movimientos.id_cobro = dbo.VENTASFORMACOBRO.CODCOBRO AND dbo.movimientos.id_venta = dbo.VENTASFORMACOBRO.CODVENTA LEFT OUTER JOIN dbo.COMPRAS ON dbo.movimientos.id_compra = dbo.COMPRAS.CODCOMPRA LEFT OUTER JOIN  " & _
              "dbo.VENTAS ON dbo.movimientos.id_venta = dbo.VENTAS.CODVENTA LEFT OUTER JOIN dbo.COMPRASFORMAPAGO ON dbo.movimientos.id_compra = dbo.COMPRASFORMAPAGO.CODCOMPRA AND dbo.movimientos.id_pago = dbo.COMPRASFORMAPAGO.CODPAGO  " & _
              "GROUP BY dbo.movimientos.fecha_mto, dbo.movimientos.entradasalida, dbo.VENTAS.NUMVENTA, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRASFORMAPAGO.NROCUOTA, dbo.VENTASFORMACOBRO.NROCUOTA, dbo.MONEDA.DESMONEDA, dbo.EMPRESA.NOMFANTASIA, dbo.SUCURSAL.DESSUCURSAL, dbo.movimientos.id_apertura,  " & _
              "dbo.movimientos.concepto, dbo.CAJA.NUMCAJA, dbo.USUARIO.DESUSUARIO, dbo.movimientos.monto, dbo.movimientos.cotizacion1  " & _
              "HAVING(dbo.movimientos.fecha_mto >= CONVERT(DATETIME, '" & FechaDesde & "', 103)) AND (dbo.movimientos.fecha_mto <= CONVERT(DATETIME, '" & FechaHasta & "', 103))" & _
              "AND (dbo.MONEDA.DESMONEDA = '" & moneda & "' ) AND (dbo.CAJA.NUMCAJA =" & NumeroCaja & ") AND (dbo.SUCURSAL.DESSUCURSAL = '" & DescSucursal & "')   " & _
              "ORDER BY dbo.movimientos.fecha_mto, dbo.movimientos.concepto "

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql

            dr = cmd.ExecuteReader
            Dim TotalSaldo As Double
            TotalSaldo = 0

            '################################################
            'Obtenemos los datos de la apertura de dicha caja
            '################################################
            Do While dr.Read
                ''antes de insertar los datos en el reporte debemos verificar que "CuotaCobro" y "CuotaPago" no sean nulos
                'If IsDBNull(dr("CuotaCobro")) And IsDBNull(dr("CuotaPago")) Then

                'Else
                row = ds.Tables("Detalle").NewRow()

                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Fecha3") = dr("fecha_mto")

                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo3") = dr("DESUSUARIO")
                row.Item("Campo4") = dr("id_apertura")

                If IsDBNull(dr("NUMCOMPRA")) And IsDBNull(dr("NUMVENTA")) Then
                    row.Item("Campo2") = dr("concepto")

                ElseIf IsDBNull(dr("NUMCOMPRA")) Then
                    row.Item("Campo2") = dr("concepto") + " / Venta Nro. " + dr("NUMVENTA")

                ElseIf IsDBNull(dr("NUMVENTA")) Then
                    row.Item("Campo2") = dr("concepto") + " / Compra Nro. " + dr("NUMCOMPRA")

                End If


                'If IsDBNull(dr("CuotaCobro")) Then
                '    row.Item("Campo2") = "Compra Nro. " + dr("NUMCOMPRA")

                'ElseIf IsDBNull(dr("NUMCOMPRA")) Then
                '    row.Item("Campo2") = "Venta Nro. " + dr("NUMVENTA")
                'End If

                If dr("entradasalida") = "Entrada" Then
                    row.Item("Numero1") = dr("MontoReal")
                    TotalSaldo = TotalSaldo + CDec(dr("MontoReal"))
                Else
                    row.Item("Numero2") = dr("MontoReal")
                    TotalSaldo = TotalSaldo - CDec(dr("MontoReal"))
                End If

                row.Item("Numero3") = TotalSaldo

                ds.Tables("Detalle").Rows.Add(row)
                'End If
            Loop

            '###################
            '#    CABECERA     #
            '###################
            row = ds.Tables("Cabecera").NewRow()

            row.Item("Campo4") = NumeroCaja
            row.Item("Campo5") = DescSucursal
            row.Item("Campo6") = moneda
            row.Item("Numero1") = TotalSaldo
            row.Item("Numero2") = cotizacion

            ds.Tables("Cabecera").Rows.Add(row)

        Catch ex As Exception

        Finally
            sqlc.Close()

        End Try

        Return ds
    End Function

    Public Function InfFacturaCobrar(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String, _
                                     ByVal Departamento As String, ByVal Ciudad As String, ByVal Zona As String, ByVal cliente As String) As DataSet
        Dim ds As New DsInformes


        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "SELECT V.NUMVENTA , V.CODVENTA,FC.CODNUMEROCUOTA, FC.CODNUMEROCUOTA ,FC.FECHAVCTO,FC.SALDOCUOTA AS SALDO,FC.IMPORTECUOTA AS IMPORTE " & _
                  "     ,( CASE FC.PAGADO WHEN 1 THEN 'Si' WHEN 0 THEN 'No' ELSE 'Sin Dato' END ) AS PAGADO,FC.DESTIPOCOBRO, " & _
                  "     RTRIM(C.NOMBRE) AS CLIENTE, PAIS.DESPAIS AS DEPARTAMENTO, CIUDAD.DESCIUDAD AS CIUDAD, ZONA.DESZONA AS ZONA, C.DIRECCION   " & _
                  "FROM FACTURACOBRAR FC INNER JOIN " & _
                  "     VENTAS V ON V.CODVENTA =FC.CODVENTA INNER JOIN " & _
                  "     CLIENTES C ON V.CODCLIENTE=C.CODCLIENTE  LEFT OUTER JOIN " & _
                  "     CIUDAD ON C.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                  "     PAIS ON C.CODDEPARTAMENTO  = dbo.PAIS.CODPAIS LEFT OUTER JOIN " & _
                  "     ZONA ON C.CODZONA = dbo.ZONA.CODZONA  " & _
                  "WHERE C.NOMBRE LIKE '" & cliente & "' AND V.ESTADO = 1 AND FC.PAGADO = 0 AND FC.FECHAVCTO  >= convert(datetime, '" & FechaDesde & "',103)  " & _
                  "      AND FC.FECHAVCTO <= convert(datetime,'" & FechaHasta & "',103)AND (PAIS.DESPAIS LIKE '" & Departamento & "') AND (CIUDAD.DESCIUDAD LIKE '" & Ciudad & "') " & _
                  "AND (ZONA.DESZONA LIKE '" & Zona & "')AND " & _
                  "" & condiciones & "" & _
                  "GROUP BY PAIS.DESPAIS, ZONA.DESZONA, CIUDAD.DESCIUDAD , C.NOMBRE ,C.APELLIDO ,V.CODVENTA ,V.NUMVENTA ,FC.CODNUMEROCUOTA ," & _
                  "         FC.FECHAVCTO, FC.SALDOCUOTA, FC.IMPORTECUOTA, FC.PAGADO, FC.DESTIPOCOBRO,  C.DIRECCION " & _
                  "ORDER BY C.NOMBRE ,C.APELLIDO, FC.CODNUMEROCUOTA  "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Fecha3") = dr("FECHAVCTO")
                row.Item("Campo3") = dr("DIRECCION")
                ' row.Item("Campo6") = dr("DESTIPOCOBRO")
                row.Item("Campo5") = dr("NUMVENTA")
                row.Item("Campo2") = dr("CLIENTE")
                row.Item("Campo7") = dr("DEPARTAMENTO")
                row.Item("Campo8") = dr("CIUDAD")
                row.Item("Campo9") = dr("ZONA")
                row.Item("Campo6") = dr("DESTIPOCOBRO")
                row.Item("Numero1") = dr("CODNUMEROCUOTA")
                row.Item("Numero2") = dr("IMPORTE")
                row.Item("Numero3") = dr("SALDO")

                ds.Tables("Detalle").Rows.Add(row)

            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function


    Public Function InfFacturaCobrar3(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String, _
                                     ByVal Departamento As String, ByVal Ciudad As String, ByVal Zona As String, ByVal cliente As String) As DataSet
        Dim ds As New DsInformes


        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "SELECT V.NUMVENTA , V.CODVENTA,FC.CODNUMEROCUOTA, FC.CODNUMEROCUOTA ,FC.FECHAVCTO,FC.SALDOCUOTA AS SALDO,FC.IMPORTECUOTA AS IMPORTE " & _
                  "     ,( CASE FC.PAGADO WHEN 1 THEN 'Si' WHEN 0 THEN 'No' ELSE 'Sin Dato' END ) AS PAGADO,FC.DESTIPOCOBRO, " & _
                  "     RTRIM(C.NOMBRE) AS CLIENTE, PAIS.DESPAIS AS DEPARTAMENTO, CIUDAD.DESCIUDAD AS CIUDAD, ZONA.DESZONA AS ZONA, C.DIRECCION   " & _
                  "FROM FACTURACOBRAR FC INNER JOIN " & _
                  "     VENTAS V ON V.CODVENTA =FC.CODVENTA INNER JOIN " & _
                  "     CLIENTES C ON V.CODCLIENTE=C.CODCLIENTE  LEFT OUTER JOIN " & _
                  "     CIUDAD ON C.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                  "     PAIS ON C.CODDEPARTAMENTO  = dbo.PAIS.CODPAIS LEFT OUTER JOIN " & _
                  "     ZONA ON C.CODZONA = dbo.ZONA.CODZONA  " & _
                  "WHERE C.NOMBRE LIKE '" & cliente & "' AND V.ESTADO = 1 AND FC.PAGADO = 0 AND FC.FECHAVCTO  >= convert(datetime, '" & FechaDesde & "',103)  " & _
                  "      AND FC.FECHAVCTO <= convert(datetime,'" & FechaHasta & "',103)" & _
                  "" & condiciones & "" & _
                  "GROUP BY PAIS.DESPAIS, ZONA.DESZONA, CIUDAD.DESCIUDAD , C.NOMBRE ,C.APELLIDO ,V.CODVENTA ,V.NUMVENTA ,FC.CODNUMEROCUOTA ," & _
                  "         FC.FECHAVCTO, FC.SALDOCUOTA, FC.IMPORTECUOTA, FC.PAGADO, FC.DESTIPOCOBRO,  C.DIRECCION " & _
                  "ORDER BY C.NOMBRE ,C.APELLIDO, FC.CODNUMEROCUOTA  "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Fecha3") = dr("FECHAVCTO")
                row.Item("Campo3") = dr("DIRECCION")
                ' row.Item("Campo6") = dr("DESTIPOCOBRO")
                row.Item("Campo5") = dr("NUMVENTA")
                row.Item("Campo2") = dr("CLIENTE")
                row.Item("Campo7") = dr("DEPARTAMENTO")
                row.Item("Campo8") = dr("CIUDAD")
                row.Item("Campo9") = dr("ZONA")
                row.Item("Campo6") = dr("DESTIPOCOBRO")
                row.Item("Numero1") = dr("CODNUMEROCUOTA")
                row.Item("Numero2") = dr("IMPORTE")
                row.Item("Numero3") = dr("SALDO")

                ds.Tables("Detalle").Rows.Add(row)

            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfFacturaCobrar2(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String, _
                                    ByVal Departamento As String, ByVal Ciudad As String, ByVal Zona As String, ByVal CLIENTE As String) As DataSet
        Dim ds As New DsInformes


        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql2 = ""
            sql2 = "SELECT V.NUMVENTA , V.CODVENTA,FC.CODNUMEROCUOTA, FC.CODNUMEROCUOTA ,FC.FECHAVCTO,FC.SALDOCUOTA AS SALDO,FC.IMPORTECUOTA AS IMPORTE " & _
                  "     ,( CASE FC.PAGADO WHEN 1 THEN 'Si' WHEN 0 THEN 'No' ELSE 'Sin Dato' END ) AS PAGADO,FC.DESTIPOCOBRO, " & _
                  "     RTRIM(C.NOMBRE) AS CLIENTE, PAIS.DESPAIS AS DEPARTAMENTO, CIUDAD.DESCIUDAD AS CIUDAD, ZONA.DESZONA AS ZONA, C.DIRECCION   " & _
                  "FROM FACTURACOBRAR FC INNER JOIN " & _
                  "     VENTAS V ON V.CODVENTA =FC.CODVENTA INNER JOIN " & _
                  "     CLIENTES C ON V.CODCLIENTE=C.CODCLIENTE  LEFT OUTER JOIN " & _
                  "     CIUDAD ON C.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                  "     PAIS ON C.CODDEPARTAMENTO  = dbo.PAIS.CODPAIS LEFT OUTER JOIN " & _
                  "     ZONA ON C.CODZONA = dbo.ZONA.CODZONA  " & _
                  "WHERE " & CLIENTE & " AND FC.PAGADO = 0 AND FC.FECHAVCTO  >= convert(datetime, '" & FechaDesde & "',103)AND FC.FECHAVCTO <= convert(datetime,'" & FechaHasta & "',103)" & _
                  "GROUP BY PAIS.DESPAIS, ZONA.DESZONA, CIUDAD.DESCIUDAD , C.NOMBRE ,C.APELLIDO ,V.CODVENTA ,V.NUMVENTA ,FC.CODNUMEROCUOTA ," & _
                  "         FC.FECHAVCTO, FC.SALDOCUOTA, FC.IMPORTECUOTA, FC.PAGADO, FC.DESTIPOCOBRO,  C.DIRECCION " & _
                  "ORDER BY C.NOMBRE ,C.APELLIDO, FC.CODNUMEROCUOTA  "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql2
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Fecha3") = dr("FECHAVCTO")
                row.Item("Campo3") = dr("DIRECCION")
                ' row.Item("Campo6") = dr("DESTIPOCOBRO")
                row.Item("Campo5") = dr("NUMVENTA")
                row.Item("Campo2") = dr("CLIENTE")
                row.Item("Campo7") = dr("DEPARTAMENTO")
                row.Item("Campo8") = dr("CIUDAD")
                row.Item("Campo9") = dr("ZONA")
                row.Item("Campo6") = dr("DESTIPOCOBRO")
                row.Item("Numero1") = dr("CODNUMEROCUOTA")
                row.Item("Numero2") = dr("IMPORTE")
                row.Item("Numero3") = dr("SALDO")

                ds.Tables("Detalle").Rows.Add(row)

            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function



    Public Function InfListadoCliente(ByVal EmpDescripcion As String, ByVal condiciones As String, ByVal Departamento As String, ByVal Ciudad As String, _
                                      ByVal Zona As String, ByVal Cliente As String, ByVal DatoFill As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT     TOP (100) PERCENT dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.DIRECCION, dbo.CLIENTES.CODDEPARTAMENTO, " & _
                      "dbo.CLIENTES.CODCIUDAD, dbo.CLIENTES.CODZONA, dbo.CLIENTES.NOMBRE AS Expr1, dbo.CLIENTES.TELEFONO, dbo.CLIENTES.CODCLIENTE, " & _
                      "dbo.PAIS.DESPAIS, dbo.CIUDAD.DESCIUDAD, dbo.ZONA.DESZONA " & _
                      "FROM         dbo.CLIENTES LEFT OUTER JOIN " & _
                      "dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN " & _
                      "dbo.CIUDAD ON dbo.ZONA.CODCIUDAD = dbo.CIUDAD.CODCIUDAD AND dbo.CLIENTES.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                      "dbo.PAIS ON dbo.CIUDAD.CODPAIS = dbo.PAIS.CODPAIS AND dbo.CLIENTES.CODDEPARTAMENTO = dbo.PAIS.CODPAIS " & _
                      "WHERE " & Cliente & " " & _
                      "GROUP BY dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.TELEFONO, dbo.CLIENTES.DIRECCION, dbo.CLIENTES.CODDEPARTAMENTO, " & _
                     " dbo.CLIENTES.CODCIUDAD, dbo.CLIENTES.CODZONA, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.CODCLIENTE, dbo.PAIS.DESPAIS, dbo.CIUDAD.DESCIUDAD, " & _
                     "dbo.ZONA.DESZONA "





        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql

            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo2") = dr("DESPAIS")
                row.Item("Campo3") = dr("NUMCLIENTE")
                row.Item("Campo4") = dr("NOMBRE")
                row.Item("Campo5") = dr("DESCIUDAD")
                row.Item("Campo6") = dr("DESZONA")
                row.Item("Campo7") = dr("TELEFONO")
                row.Item("Campo8") = DatoFill
                row.Item("Campo9") = dr("DIRECCION")

                row.Item("Campo1") = EmpDescripcion

                ds.Tables("Detalle").Rows.Add(row)

            Loop

        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfListadoCliente3(ByVal EmpDescripcion As String, ByVal condiciones As String, ByVal Departamento As String, ByVal Ciudad As String, _
                                     ByVal Zona As String, ByVal Cliente As String, ByVal DatoFill As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.APELLIDO, dbo.CLIENTES.DIRECCION, dbo.CLIENTES.CODDEPARTAMENTO, " & _
              "dbo.CLIENTES.CODCIUDAD, dbo.CLIENTES.CODZONA, dbo.PAIS.DESPAIS, dbo.CLIENTES.NOMBRE + '  ' + dbo.CLIENTES.APELLIDO AS CLIENTE, " & _
              "dbo.CIUDAD.DESCIUDAD, dbo.ZONA.DESZONA,dbo.CLIENTES.TELEFONO " & _
              "FROM dbo.CLIENTES LEFT OUTER JOIN dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN " & _
              "dbo.CIUDAD ON dbo.ZONA.CODCIUDAD = dbo.CIUDAD.CODCIUDAD AND dbo.CLIENTES.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
              "dbo.PAIS ON dbo.CIUDAD.CODPAIS = dbo.PAIS.CODPAIS AND dbo.CLIENTES.CODDEPARTAMENTO = dbo.PAIS.CODPAIS " & _
              "WHERE dbo.CLIENTES.NOMBRE LIKE '" & Cliente & "' AND (dbo.PAIS.DESPAIS LIKE '" & Departamento & "') AND (CIUDAD.DESCIUDAD LIKE '" & Ciudad & "') AND (ZONA.DESZONA LIKE '" & Zona & "')AND  " & _
              "" & condiciones & "" & _
              "GROUP BY dbo.PAIS.DESPAIS, dbo.CIUDAD.DESCIUDAD, dbo.ZONA.DESZONA, dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.APELLIDO,dbo.CLIENTES.TELEFONO,  " & _
              "dbo.CLIENTES.DIRECCION, dbo.CLIENTES.CODDEPARTAMENTO, dbo.CLIENTES.CODCIUDAD, dbo.CLIENTES.CODZONA,dbo.CLIENTES.NOMBRE + '  ' + dbo.CLIENTES.APELLIDO " & _
              "ORDER BY dbo.PAIS.DESPAIS, dbo.CIUDAD.DESCIUDAD, dbo.ZONA.DESZONA"


        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql

            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo2") = dr("DESPAIS")
                row.Item("Campo3") = dr("NUMCLIENTE")
                row.Item("Campo4") = dr("NOMBRE")
                row.Item("Campo5") = dr("DESCIUDAD")
                row.Item("Campo6") = dr("DESZONA")
                row.Item("Campo7") = dr("TELEFONO")
                row.Item("Campo8") = DatoFill
                row.Item("Campo9") = dr("DIRECCION")

                row.Item("Campo1") = EmpDescripcion

                ds.Tables("Detalle").Rows.Add(row)

            Loop

        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfListadoCliente2(ByVal EmpDescripcion As String, ByVal condiciones As String, ByVal Departamento As String, ByVal Ciudad As String, _
                                      ByVal Zona As String, ByVal Cliente As String, ByVal DatoFill As String) As DataSet
        Dim ds As New DsInformes

        sql = ""



        sql = "SELECT dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.NOMBRE,dbo.CLIENTES.DIRECCION, dbo.CLIENTES.CODDEPARTAMENTO," & _
"dbo.CLIENTES.CODCIUDAD, dbo.CLIENTES.CODZONA,dbo.PAIS.DESPAIS, dbo.CIUDAD.DESCIUDAD, dbo.ZONA.DESZONA, dbo.CLIENTES.TELEFONO " & _
"FROM dbo.CLIENTES LEFT OUTER JOIN dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN dbo.CIUDAD " & _
"ON dbo.ZONA.CODCIUDAD = dbo.CIUDAD.CODCIUDAD AND dbo.CLIENTES.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN dbo.PAIS " & _
"ON dbo.CIUDAD.CODPAIS = dbo.PAIS.CODPAIS AND dbo.CLIENTES.CODDEPARTAMENTO = dbo.PAIS.CODPAIS" & _
" WHERE dbo.CLIENTES.NOMBRE LIKE '" & Cliente & "'"

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo2") = dr("DESPAIS")
                row.Item("Campo3") = dr("NUMCLIENTE")
                row.Item("Campo4") = dr("NOMBRE")
                row.Item("Campo5") = dr("DESCIUDAD")
                row.Item("Campo6") = dr("DESZONA")
                row.Item("Campo7") = dr("TELEFONO")
                row.Item("Campo8") = DatoFill
                row.Item("Campo9") = dr("DIRECCION")

                row.Item("Campo1") = EmpDescripcion

                ds.Tables("Detalle").Rows.Add(row)

            Loop

        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function

    Public Function InfPedidoPendienteCliente(ByVal FechaVto As Date, ByVal EmpDescripcion As String, ByVal Condiciones As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT  SUM(FC.IMPORTECUOTA) AS TOTAL, C.TELEFONO, C.NUMCLIENTE, C.NOMBRE, SUM(VD.CANTIDADVENTA) AS CANTIDAD ,V.NUMVENTA  " & _
                " FROM FACTURACOBRAR FC JOIN VENTAS V ON V.CODVENTA =FC.CODVENTA INNER JOIN CLIENTES C ON " & _
                " V.CODCLIENTE = C.CODCLIENTE INNER JOIN VENTASDETALLE VD ON" & _
                " VD.CODVENTA = FC.CODVENTA" & _
                "  WHERE FC.PAGADO = 0 " & _
                "" & Condiciones & "" & _
                " GROUP BY C.NUMCLIENTE, C.NOMBRE, C.TELEFONO,V.NUMVENTA " & _
                "order by C.NOMBRE"

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaVto

                row.Item("Campo2") = dr("NUMCLIENTE")
                row.Item("Campo3") = dr("NOMBRE")
                row.Item("Campo4") = dr("NUMVENTA")
                row.Item("Campo5") = dr("TELEFONO")

                row.Item("Numero2") = dr("TOTAL")
                row.Item("Numero3") = dr("CANTIDAD")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables(Cabecera).NewRow()
            'row.Item(Campo1) = EmpDescripcion
            'row.Item(Campo2) = FechaDesde
            'row.Item(Campo3) = FechaHasta

            'ds.Tables(Cabecera).Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds
    End Function

    Public Function InfVentasPorVendedor(ByVal EmpDescripcion As String, ByVal DesVendedor As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date, _
                                         ByVal DesDept As String, ByRef DesCiudad As String, ByVal DesZona As String, ByVal DatoFill As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT dbo.VENDEDOR.DESVENDEDOR, dbo.VENTAS.NUMVENTA, dbo.VENTAS.FECHAVENTA, dbo.VENTAS.TOTALVENTA, dbo.PAIS.DESPAIS, dbo.CIUDAD.DESCIUDAD, " & _
              "dbo.ZONA.DESZONA, dbo.VENTAS.NOMBRECLIENTE FROM dbo.VENTAS INNER JOIN dbo.VENDEDOR ON dbo.VENTAS.CODVENDEDOR = dbo.VENDEDOR.CODVENDEDOR INNER JOIN " & _
              "dbo.ZONA ON dbo.VENTAS.CODZONA = dbo.ZONA.CODZONA INNER JOIN dbo.CIUDAD ON dbo.ZONA.CODCIUDAD = dbo.CIUDAD.CODCIUDAD INNER JOIN " & _
              "dbo.PAIS ON dbo.CIUDAD.CODPAIS = dbo.PAIS.CODPAIS " & _
              "WHERE dbo.VENDEDOR.DESVENDEDOR LIKE '" & DesVendedor & "' AND (VENTAS.FECHAVENTA >= CONVERT(datetime, '" & FechaDesde & "', 103)) AND (VENTAS.FECHAVENTA <= CONVERT(datetime, '" & FechaHasta & "', 103)) " & _
              "AND dbo.PAIS.DESPAIS LIKE '" & DesDept & "' AND dbo.CIUDAD.DESCIUDAD LIKE '" & DesCiudad & "' AND dbo.ZONA.DESZONA LIKE '" & DesZona & "' " & _
              "GROUP BY dbo.PAIS.DESPAIS, dbo.CIUDAD.DESCIUDAD, dbo.ZONA.DESZONA,dbo.VENTAS.NOMBRECLIENTE, dbo.VENDEDOR.DESVENDEDOR, " & _
              "dbo.VENTAS.NUMVENTA, dbo.VENTAS.FECHAVENTA, dbo.VENTAS.TOTALVENTA"


        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo2") = dr("DESVENDEDOR")
                row.Item("Campo3") = dr("DESZONA")
                row.Item("Campo4") = dr("NUMVENTA")
                row.Item("Campo5") = dr("DESCIUDAD")
                row.Item("Campo6") = dr("DESPAIS")
                row.Item("Campo7") = dr("NOMBRECLIENTE")
                row.Item("Campo8") = DatoFill

                row.Item("Numero2") = dr("TOTALVENTA")
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Fecha3") = dr("FECHAVENTA")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()


            ''row.Item("Campo3") = CodSucursal
            ''row.Item("Campo2") = DesUsu
            ''row.Item("Campo4") = TipoInventario

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally
            sqlc.Close()
        End Try

        Return ds

    End Function

    Public Function InfPendientePorClienteArticulo(ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "select SUM(VD.CANTIDADVENTA) * -1 CANTIDAD , SUM(VD.PRECIOVENTABRUTO) *-1 TOTAL, COD.CODIGO, I.DESIVA, C.NUMCLIENTE, RTRIM(C.NOMBRE)+' '+LTRIM(C.APELLIDO) AS CLIENTE, " & _
              " ISNULL(P.DESPRODUCTO, '') + ' ' +  ISNULL(COD.DESCODIGO1, '') + ' ' + ISNULL(COD.DESCODIGO2, '') AS PRODUCTO " & _
              " FROM VENTASDETALLE VD INNER JOIN PRODUCTOS P ON  " & _
              " P.CODPRODUCTO = VD.CODPRODUCTO INNER JOIN CODIGOS COD ON " & _
              " COD.CODCODIGO = VD.CODCODIGO INNER JOIN FACTURACOBRAR FC ON " & _
              " VD.CODVENTA = FC.CODVENTA INNER JOIN VENTAS V ON " & _
              " V.CODVENTA = VD.CODVENTA INNER JOIN IVA I ON " & _
              " I.CODIVA = P.CODIVA INNER JOIN CLIENTES C ON " & _
              " C.CODCLIENTE = V.CODCLIENTE " & _
              " WHERE(FC.PAGADO = 0 And (FC.FECHAVCTO > Convert(DateTime, GETDATE(), 103))) " & _
               "" & condiciones & "" & _
              " GROUP BY P.DESPRODUCTO, COD.CODIGO, COD.DESCODIGO1, COD.DESCODIGO2, I.DESIVA,C.APELLIDO, C.NOMBRE,  C.NUMCLIENTE " & _
              " ORDER BY P.DESPRODUCTO "

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = Today
                '  row.Item("Fecha2") = FechaHasta
                row.Item("Campo2") = dr("NUMCLIENTE")
                row.Item("Campo3") = dr("CLIENTE")
                row.Item("Campo4") = dr("CODIGO")
                row.Item("Campo5") = dr("PRODUCTO")
                row.Item("Campo6") = dr("DESIVA")
                row.Item("Numero2") = dr("CANTIDAD")
                row.Item("Numero3") = dr("TOTAL")


                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables(Cabecera).NewRow()
            'row.Item(Campo1) = EmpDescripcion
            'row.Item(Campo2) = FechaDesde
            'row.Item(Campo3) = FechaHasta

            'ds.Tables(Cabecera).Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds
    End Function

    Public Function InflistadePrecios(ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT C.CODIGO , " & _
        "ISNULL(RTRIM(P.DESPRODUCTO),'') + ' ' + ISNULL(LTRIM(C.DESCODIGO1),'') " & _
        "+ ' ' + ISNULL(LTRIM(C.DESCODIGO2),'') AS PRODUCTOS, " & _
        "PRE.PRECIOVENTA AS PRECIO,TC.DESTIPOCLIENTE as TIPOCLIENTE " & _
        "FROM PRODUCTOS P INNER JOIN  " & _
        "CODIGOS C " & _
        "ON P.CODPRODUCTO =C.CODPRODUCTO INNER JOIN  " & _
        "PRECIO PRE " & _
        "ON PRE.CODPRODUCTO=P.CODPRODUCTO INNER JOIN " & _
        "TIPOCLIENTE TC " & _
        "ON PRE.CODTIPOCLIENTE =TC.CODTIPOCLIENTE  " & _
        "ORDER BY P.DESPRODUCTO ,C.DESCODIGO1 ,C.DESCODIGO2  "

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = Today.ToShortDateString
                row.Item("Campo2") = dr("CODIGO")
                row.Item("Campo3") = dr("PRODUCTOS")
                row.Item("Campo4") = dr("TIPOCLIENTE")
                row.Item("Numero1") = dr("PRECIO")


                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables(Cabecera).NewRow()
            'row.Item(Campo1) = EmpDescripcion
            'row.Item(Campo2) = FechaDesde
            'row.Item(Campo3) = FechaHasta

            'ds.Tables(Cabecera).Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds
    End Function
    Public Function InfPendientesPorZonaArticulo(ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "select SUM(VD.CANTIDADVENTA) AS CANTIDAD , SUM(VD.PRECIOVENTABRUTO) AS TOTAL, COD.CODIGO, I.DESIVA, Z.DESZONA, Z.NUMZONA, ISNULL(P.DESPRODUCTO, '') + ' ' + " & _
           " ISNULL(COD.DESCODIGO1, '') + ' ' + ISNULL(COD.DESCODIGO2, '') AS PRODUCTO,V.NOMBRECLIENTE " & _
              " FROM VENTASDETALLE VD INNER JOIN PRODUCTOS P ON " & _
              " P.CODPRODUCTO = VD.CODPRODUCTO INNER JOIN CODIGOS COD ON " & _
              " COD.CODCODIGO = VD.CODCODIGO INNER JOIN FACTURACOBRAR FC ON " & _
              " VD.CODVENTA = FC.CODVENTA INNER JOIN VENTAS V ON " & _
              " V.CODVENTA = VD.CODVENTA INNER JOIN IVA I ON" & _
              " I.CODIVA = P.CODIVA LEFT OUTER JOIN ZONA Z ON" & _
              " Z.CODZONA = V.CODZONA" & _
              " WHERE(FC.PAGADO = 0) " & _
              "" & condiciones & "" & _
              " GROUP BY Z.NUMZONA, Z.DESZONA ,V.NOMBRECLIENTE,P.DESPRODUCTO, COD.CODIGO, COD.DESCODIGO1, COD.DESCODIGO2, I.DESIVA  "

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Fecha1") = Today
                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo3") = dr("NOMBRECLIENTE")
                row.Item("Campo4") = dr("CODIGO")
                row.Item("Campo5") = dr("PRODUCTO")
                row.Item("Campo6") = dr("DESIVA")
                row.Item("Campo7") = dr("DESZONA")

                row.Item("Numero2") = dr("CANTIDAD")
                row.Item("Numero3") = dr("TOTAL")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables(Cabecera).NewRow()
            'row.Item(Campo1) = EmpDescripcion
            'row.Item(Campo2) = FechaDesde
            'row.Item(Campo3) = FechaHasta

            'ds.Tables(Cabecera).Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds
    End Function

    Public Function InfEnviosPorZonaArticulo(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal condiciones As String) As DataSet
        Dim ds As New DsInformes

        sql = ""
        sql = "SELECT     TOP (100) PERCENT dbo.VENTAS.FECHAVENTA, dbo.VENTAS.NOMBRECLIENTE, dbo.VENTAS.CODZONA, dbo.ZONA.DESZONA, dbo.VENTASDETALLE.CODCODIGO, " & _
              "dbo.VENTASDETALLE.CANTIDADVENTA, dbo.PRODUCTOS.DESPRODUCTO " & _
              "FROM dbo.CLIENTES INNER JOIN " & _
              "dbo.VENTAS ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE INNER JOIN " & _
              "dbo.VENTASDETALLE ON dbo.VENTAS.CODVENTA = dbo.VENTASDETALLE.CODVENTA INNER JOIN " & _
              "dbo.ZONA ON dbo.VENTAS.CODZONA = dbo.ZONA.CODZONA INNER JOIN " & _
              "dbo.PRODUCTOS ON dbo.VENTASDETALLE.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO " & _
              "WHERE dbo.VENTAS.FECHAVENTA >= convert(datetime,  '" & FechaDesde & "' ,103)  " & _
              "AND dbo.VENTAS.FECHAVENTA <= convert(datetime, '" & FechaHasta & "' ,103) " & _
              "" & condiciones & "" & _
              "GROUP BY dbo.VENTAS.CODZONA, dbo.ZONA.DESZONA, dbo.VENTAS.NOMBRECLIENTE, dbo.VENTAS.CODVENDEDOR, dbo.VENTAS.FECHAVENTA, " & _
              "dbo.VENTASDETALLE.CODCODIGO, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.PRODUCTOS.DESPRODUCTO " & _
              "ORDER BY dbo.VENTAS.CODZONA, dbo.ZONA.DESZONA, dbo.VENTAS.NOMBRECLIENTE"

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader

            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta

                row.Item("Campo3") = dr("DESZONA")
                row.Item("Campo4") = dr("CODCODIGO")
                row.Item("Campo5") = dr("DESPRODUCTO")
                row.Item("Numero2") = dr("CANTIDADVENTA")
                row.Item("Campo6") = dr("NOMBRECLIENTE")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables(Cabecera).NewRow()
            'row.Item(Campo1) = EmpDescripcion
            'row.Item(Campo2) = FechaDesde
            'row.Item(Campo3) = FechaHasta

            'ds.Tables(Cabecera).Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds
    End Function
    Public Function InfFacturaPagar(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal EmpDescripcion As String, ByVal codproveedor As Integer, ByVal proveedor As String) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            'sql = "  SELECT C.NUMCOMPRA,F.IMPORTECUOTA AS IMPORTE,F.DESTIPOPAGO,F.FECHAVCTO AS FECHAPAGO,F.PAGADO " & _
            ' "FROM FACTURAPAGAR F INNER JOIN COMPRAS C ON C.CODCOMPRA =F.CODCOMPRA " & _
            '"WHERE F.FECHAVCTO >= convert(datetime,  '" & FechaDesde & "' ,103)  " & _
            ' "AND F.FECHAVCTO <= convert(datetime, '" & FechaHasta & "' ,103) AND C.CODPROVEEDOR = " & codproveedor & " AND F.PAGADO=0"

            sql = " SELECT C.NUMCOMPRA, C.FECHACOMPRA, F.FECHAVCTO AS FECHAPAGO, C.COTIZACION1, PROVEEDOR.NOMBRE AS Proveedor, C.CONCEPTO, " & _
                  " (CASE C.CODMONEDA WHEN 1 THEN F.IMPORTECUOTA WHEN 0 THEN 0 END ) AS Importe_Guaranies, (CASE C.CODMONEDA WHEN 1 THEN 0 WHEN 0 THEN F.IMPORTECUOTA END ) AS Importe_Dolares " & _
                  "  FROM   dbo.FACTURAPAGAR AS F INNER JOIN dbo.COMPRAS AS C ON C.CODCOMPRA = F.CODCOMPRA LEFT OUTER JOIN " & _
                  "  dbo.MONEDA ON C.CODMONEDA = dbo.MONEDA.CODMONEDA FULL OUTER JOIN dbo.PROVEEDOR ON C.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR  " & _
                  "  WHERE  (F.FECHAVCTO >= CONVERT(datetime, '" & FechaDesde & "', 103)) AND (F.FECHAVCTO <= CONVERT(datetime, '" & FechaHasta & "', 103)) AND (F.PAGADO = 0)"

            If proveedor <> 0 Then
                sql = sql + "AND C.CODPROVEEDOR = " & codproveedor
            End If

            sql = sql + "  ORDER BY Proveedor  "
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo1") = EmpDescripcion
                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta

                row.Item("Campo2") = dr("NUMCOMPRA")
                row.Item("Campo3") = dr("Proveedor")
                row.Item("Campo4") = dr("CONCEPTO")
                row.Item("Fecha3") = dr("FECHAPAGO")
                row.Item("Fecha4") = dr("FECHACOMPRA")
                row.Item("Numero2") = dr("Importe_Guaranies")
                row.Item("Numero3") = dr("Importe_Dolares")
                row.Item("Numero4") = dr("COTIZACION1")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables(Cabecera).NewRow()
            'row.Item(Campo1) = EmpDescripcion
            'row.Item(Campo2) = FechaDesde
            'row.Item(Campo3) = FechaHasta

            'ds.Tables(Cabecera).Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfLifo(ByVal EmpDescripcion As String, ByVal condiciones As String, ByVal codsucursal As Decimal, ByVal sucursal As String) As DataSet
        Dim ds As New DsInformes


        sql = ""
        sql = "DECLARE " & _
                "@NUMCOMPRA varchar(200), " & _
                "@FECHACOMPRA DATE,@CODPRODUCTO numeric(18,0), " & _
                "@CODCODIGO numeric(18,0),@COSTOUNITARIO numeric(18,2), " & _
                "@CANTIDADCOMPRA numeric(18,2) ,@LINEANROCOMPRA  numeric(18,0), " & _
                "@CODPRODUCTO1 numeric(18,0),@CODCODIGO1 NUMERIC (18,0),@STOCKACTUAL NUMERIC(18,2), " & _
                "@STOCKVIRTUAL NUMERIC(18,2),@VALOR NUMERIC(18,2) , @VALORTOTAL NUMERIC(18,2), " & _
                "@PRODUCTO VARCHAR(200) " & _
                "DECLARE @VariableTabla AS TABLE  " & _
                "(CODCODIGO NUMERIC(18,0),CODPRODUCTO NUMERIC(18,0),VALOR NUMERIC(18,2),PRODUCTO VARCHAR(200),STOCKACTUAL NUMERIC(18,2)) " & _
                "DECLARE CUR_STOCK CURSOR FOR  " & _
                "SELECT ST.CODCODIGO,ST.CODPRODUCTO,ST.STOCKACTUAL,ISNULL(RTRIM(P.DESPRODUCTO),'') + ' ' + " & _
                "ISNULL(LTRIM(C.DESCODIGO1),'') +' '+ ISNULL(LTRIM(C.DESCODIGO2),'') PRODUCTO " & _
                "FROM STOCKDEPOSITO ST INNER JOIN CODIGOS C  " & _
                "ON ST.CODCODIGO=C.CODCODIGO AND ST.CODPRODUCTO=C.CODPRODUCTO " & _
                "INNER JOIN PRODUCTOS  P " & _
                "ON C.CODPRODUCTO=P.CODPRODUCTO " & _
                "WHERE ISNULL(ST.CODCODIGO,0)<>0 " & condiciones & " AND ST.CODDEPOSITO=" & codsucursal & " order by ST.codproducto,ST.codcodigo " & _
                "OPEN CUR_STOCK " & _
                "fetch next from  CUR_STOCK INTO @CODCODIGO1,@CODPRODUCTO1,@STOCKACTUAL,@PRODUCTO " & _
                "WHILE @@FETCH_STATUS = 0    " & _
                "BEGIN " & _
                "SET @VALORTOTAL=0 " & _
                "SET @STOCKVIRTUAL =@STOCKACTUAL  " & _
                "declare  cur_detallecompra cursor for  " & _
                "SELECT  C.NUMCOMPRA,C.FECHACOMPRA,CD.CODPRODUCTO,CD.CODCODIGO, " & _
                "CD.COSTOUNITARIO,CD.CANTIDADCOMPRA,CD.LINEANROCOMPRA   FROM COMPRAS C INNER JOIN  " & _
                "COMPRASDETALLE CD ON C.CODCOMPRA =CD.CODCOMPRA WHERE CD.CODCODIGO =@CODCODIGO1 AND CD.CODPRODUCTO =@CODPRODUCTO1 " & _
                "ORDER BY CD.LINEANROCOMPRA DESC " & _
                "open  cur_detallecompra  " & _
                "fetch next from  cur_detallecompra  into @NUMCOMPRA,@FECHACOMPRA,@CODPRODUCTO,@CODCODIGO,@COSTOUNITARIO,@CANTIDADCOMPRA,@LINEANROCOMPRA " & _
                "WHILE @@FETCH_STATUS = 0   " & _
                "BEGIN " & _
                "IF @STOCKVIRTUAL<>0 " & _
                "BEGIN " & _
                "IF @STOCKVIRTUAL  >  @CANTIDADCOMPRA " & _
                "BEGIN " & _
                "SET @STOCKVIRTUAL =@STOCKVIRTUAL-@CANTIDADCOMPRA " & _
                "SET @VALOR= @COSTOUNITARIO * @CANTIDADCOMPRA  " & _
                "END  " & _
                "ELSE " & _
                "BEGIN " & _
                "IF @STOCKVIRTUAL  <=  @CANTIDADCOMPRA " & _
                "BEGIN " & _
                "SET @VALOR= @COSTOUNITARIO * @STOCKVIRTUAL " & _
                "SET @STOCKVIRTUAL =0 " & _
                "END  " & _
                "END  " & _
                "SET @VALORTOTAL =@VALORTOTAL + @VALOR  " & _
                "END  " & _
                "fetch next from  cur_detallecompra  into @NUMCOMPRA,@FECHACOMPRA,@CODPRODUCTO,@CODCODIGO,@COSTOUNITARIO,@CANTIDADCOMPRA,@LINEANROCOMPRA " & _
                "END " & _
                "close cur_detallecompra  " & _
                "deallocate cur_detallecompra  " & _
                "INSERT INTO @VariableTabla VALUES (@CODCODIGO1,@CODPRODUCTO1,@VALORTOTAL,@PRODUCTO,@STOCKACTUAL) " & _
                "fetch next from  CUR_STOCK INTO @CODCODIGO1,@CODPRODUCTO1,@STOCKACTUAL,@PRODUCTO " & _
                "END " & _
                "close CUR_STOCK " & _
                "deallocate CUR_STOCK " & _
                "Select * from @VariableTabla "




        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo5") = EmpDescripcion
                row.Item("Campo6") = sucursal
                row.Item("Campo1") = dr("PRODUCTO")
                row.Item("Numero1") = dr("VALOR")
                row.Item("Numero2") = dr("STOCKACTUAL")



                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables(Cabecera).NewRow()
            'row.Item(Campo1) = EmpDescripcion
            'row.Item(Campo2) = FechaDesde
            'row.Item(Campo3) = FechaHasta

            'ds.Tables(Cabecera).Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfFifo(ByVal EmpDescripcion As String, ByVal todos As Boolean, ByVal codsucursal As String, ByVal dessucursal As String, ByVal codproducto As String) As DataSet
        Dim ds As New DsInformes


        sql = ""
        ''If todos = True Then

        ''sql = "DECLARE @CODCODIGO AS NUMERIC(18,2)," & _


        '' Else
        sql = "DECLARE @CODCODIGO AS NUMERIC(18,2), " & _
              "@CODPRODUCTO AS NUMERIC(18,2), " & _
              "@COSTOUNITARIO AS MONEY,  " & _
              "@CANTIDADCOMPRA AS NUMERIC(18,2)," & _
              "@STOCKACTUAL AS NUMERIC(18,2),  " & _
              "@PRODUCTO AS VARCHAR (200) ," & _
              "@FECHACOMPRA AS DATETIME," & _
              "@STOCKVALORIZADO MONEY," & _
              "@STOCKSOBRANTE NUMERIC(18,2)," & _
              "@CANTIDADREGISTROS INT " & _
              "DECLARE @VariableTabla as TABLE  " & _
              "(CodProducto int,  " & _
              "CodCodigo int,  " & _
              "Producto varchar(200),  " & _
              "StockFisico numeric(18,2),    " & _
              "StockValorizado numeric(18,2))  " & _
              "SET @STOCKVALORIZADO=0  " & _
              "SET @CANTIDADREGISTROS =0  " & _
              "declare  cur_detalle_compra cursor for    " & _
              "SELECT CD.CODPRODUCTO,CD.CODCODIGO,CD.COSTOUNITARIO,CD.CANTIDADCOMPRA,S.STOCKACTUAL,CO.FECHACOMPRA,  " & _
              "RTRIM(ISNUll(P.DESPRODUCTO,'')) + ' ' +LTRIM(ISNULL(C.DESCODIGO1,'')) + ' ' +LTRIM(ISNULL(C.DESCODIGO2,'')) AS PRODUCTO  " & _
              "FROM COMPRASDETALLE  CD INNER JOIN COMPRAS CO  " & _
              "ON CD.CODCOMPRA=CO.CODCOMPRA  " & _
              "INNER JOIN CODIGOS C   " & _
              "ON C.CODCODIGO=CD.CODCODIGO AND C.CODPRODUCTO=CD.CODPRODUCTO  " & _
              "INNER JOIN  PRODUCTOS P   " & _
              "ON C.CODPRODUCTO=P.CODPRODUCTO  " & _
              "INNER JOIN STOCKDEPOSITO S  " & _
              "ON S.CODCODIGO=CD.CODCODIGO AND S.CODPRODUCTO=CD.CODPRODUCTO  " & _
              "WHERE S.CODDEPOSITO=" & codsucursal & " AND CD.CODPRODUCTO=" & codproducto & "" & _
              "ORDER BY CO.FECHACOMPRA DESC   " & _
              "open  cur_detalle_compra   " & _
              "fetch next from  cur_detalle_compra      " & _
              "into @CODPRODUCTO,@CODCODIGO,@COSTOUNITARIO,  " & _
              "@CANTIDADCOMPRA,@STOCKACTUAL,@FECHACOMPRA ,@PRODUCTO  " & _
              "SET @STOCKSOBRANTE= @STOCKACTUAL  " & _
              "WHILE @@FETCH_STATUS = 0 AND @STOCKSOBRANTE<>-999  " & _
              "BEGIN   " & _
              "IF @CANTIDADCOMPRA<=@STOCKSOBRANTE  " & _
              "BEGIN   " & _
              "						SET @STOCKVALORIZADO=@STOCKVALORIZADO+(@CANTIDADCOMPRA *@COSTOUNITARIO )  " & _
              "						SET @CANTIDADREGISTROS  =@CANTIDADREGISTROS +1  " & _
              "						SET @STOCKSOBRANTE =@STOCKSOBRANTE - @CANTIDADCOMPRA  " & _
              "						IF 	@STOCKSOBRANTE=0     OR  @CANTIDADREGISTROS =@@CURSOR_ROWS   " & _
              "						BEGIN  " & _
              "							INSERT INTO @VariableTabla VALUES(@CODPRODUCTO ,@CODCODIGO,@PRODUCTO,@STOCKACTUAL ,@STOCKVALORIZADO )  " & _
              "							SET @STOCKSOBRANTE=-999      " & _
              "						END   " & _
              "END   " & _
              "ELSE  " & _
              "BEGIN  " & _
              "							SET @STOCKVALORIZADO=@STOCKVALORIZADO+(@STOCKSOBRANTE *@COSTOUNITARIO )  " & _
              "							SET @CANTIDADREGISTROS =@CANTIDADREGISTROS +1  " & _
              "							INSERT INTO @VariableTabla VALUES(@CODPRODUCTO ,@CODCODIGO,@PRODUCTO,@STOCKACTUAL ,@STOCKVALORIZADO )  " & _
              "       					SET @STOCKSOBRANTE=-999      " & _
              "END			  " & _
              "fetch next from  cur_detalle_compra     " & _
              "into @CODPRODUCTO,@CODCODIGO,@COSTOUNITARIO,  " & _
              "@CANTIDADCOMPRA,@STOCKACTUAL,@FECHACOMPRA ,@PRODUCTO	  " & _
              "END   " & _
              "close cur_detalle_compra   " & _
              "deallocate cur_detalle_compra    " & _
              "Select * from   @VariableTabla "
        ''End If


        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Campo5") = EmpDescripcion
                row.Item("Campo6") = dessucursal
                row.Item("Campo1") = dr("Producto")
                row.Item("Numero1") = dr("StockValorizado")
                row.Item("Numero3") = dr("StockFisico")




                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables(Cabecera).NewRow()
            'row.Item(Campo1) = EmpDescripcion
            'row.Item(Campo2) = FechaDesde
            'row.Item(Campo3) = FechaHasta

            'ds.Tables(Cabecera).Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfCtaCliente(ByVal FechaDesde As String, ByVal FechaHasta As String, ByVal EmpDescripcion As String, ByVal codcliente As Decimal) As DataSet
        Dim ds As New DsInformes
        Dim cadena As String

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "DECLARE " & _
                    "@NUMFACTURA AS VARCHAR(200),@CLIENTE AS VARCHAR(300),@CONCEPTO AS VARCHAR(300)," & _
                    "@IMPORTE AS NUMERIC(18,2),@FECHA AS DATETIME, @TIPO AS VARCHAR(50), " & _
                    "@SALDO AS NUMERIC(18,2), @NRO_CH_TAR AS VARCHAR(50),@FORMACOBRO AS VARCHAR(100) " & _
                    "DECLARE @VariableTabla " & _
                    "as TABLE(CLIENTE VARCHAR(300),FECHA DATETIME,CONCEPTO VARCHAR(300),NUMFACTURA varchar(200),FORMACOBRO VARCHAR(100), " & _
                    "NRO_CH_TAR VARCHAR(50), IMPORTE  numeric(18,2),TIPO VARCHAR(50),SALDO NUMERIC(18,2)) " & _
                    "declare  cur_extracto cursor for " & _
                    "SELECT  M.FECHA,M.CONCEPTO,M.NUMFACTURA,ISNULL(M.FORMACOBRO,'-----------------------') AS FORMACOBRO," & _
                    "ISNULL(M.NRO_CH_TAR,'-----------------------') AS NROCHTAR,M.IMPORTE,M.TIPOMOVIMIENTO, " & _
                    "ISNULL(RTRIM(C.NOMBRE),'')+' '+ISNULL(LTRIM(C.APELLIDO),'') AS CLIENTE " & _
                    "from MOVIMIENTOCUENTACLIENTE  M INNER JOIN CLIENTES C " & _
                    "ON M.CODCLIENTE=C.CODCLIENTE " & _
                    "WHERE  M.CODCLIENTE = " & codcliente & "   " & _
                    "ORDER BY M.FECHA " & _
                    "SET @SALDO=0 " & _
                    "open cur_extracto " & _
                    "fetch next from  cur_extracto  " & _
                    "into @FECHA,@CONCEPTO,@NUMFACTURA,@FORMACOBRO,@NRO_CH_TAR,@IMPORTE,@TIPO,@CLIENTE " & _
                    "WHILE @@FETCH_STATUS = 0   " & _
                    "BEGIN " & _
                    "IF @TIPO='Venta' " & _
                    " Begin " & _
                    "Set @SALDO=@SALDO + @IMPORTE " & _
                    "INSERT INTO @VariableTabla(CLIENTE ,FECHA ,CONCEPTO ,NUMFACTURA ,FORMACOBRO,NRO_CH_TAR , IMPORTE  ,TIPO ,SALDO ) " & _
                    "VALUES(@CLIENTE,@FECHA,@CONCEPTO,@NUMFACTURA,@FORMACOBRO,@NRO_CH_TAR,@IMPORTE,@TIPO,@SALDO) " & _
                    "End " & _
                    "IF @TIPO='Cobro'" & _
                    "Begin " & _
                    "Set @SALDO =@SALDO - @IMPORTE " & _
                    "INSERT INTO @VariableTabla(CLIENTE ,FECHA ,CONCEPTO ,NUMFACTURA ,FORMACOBRO,NRO_CH_TAR , IMPORTE  ,TIPO ,SALDO ) " & _
                    "VALUES(@CLIENTE,@FECHA,@CONCEPTO,@NUMFACTURA,@FORMACOBRO,@NRO_CH_TAR,@IMPORTE,@TIPO,@SALDO) " & _
                    "End " & _
                    "fetch next from  cur_extracto  into @FECHA,@CONCEPTO,@NUMFACTURA,@FORMACOBRO,@NRO_CH_TAR,@IMPORTE,@TIPO,@CLIENTE " & _
                    "End " & _
                    "close cur_extracto " & _
                    "deallocate cur_extracto " & _
                    "Select * from @VariableTabla " & _
                    " where  CONVERT(DATETIME,CAST(FECHA AS VARCHAR(11)),103) >= CONVERT(DATETIME,'" & FechaDesde & "',103)" & _
                    "AND CONVERT(DATETIME,CAST(FECHA AS VARCHAR(11)),103) <= CONVERT(DATETIME,'" & FechaHasta & "',103)"
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo2") = dr("CLIENTE")
                row.Item("Campo3") = dr("NUMFACTURA")

                cadena = dr("CONCEPTO")
                row.Item("Campo4") = cadena.Remove(21)

                row.Item("Fecha3") = dr("FECHA")

                If dr("TIPO") = "Venta" Then
                    row.Item("Numero2") = dr("IMPORTE")

                ElseIf dr("TIPO") = "Cobro" Then
                    row.Item("Numero4") = dr("IMPORTE")
                End If

                row.Item("Numero3") = dr("SALDO")

                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
    Public Function InfCtaProveedor(ByVal FechaDesde As String, ByVal FechaHasta As String, ByVal EmpDescripcion As String, ByVal codproveedor As Decimal, ByVal proveedor As String) As DataSet
        Dim ds As New DsInformes

        If FechaDesde <> Nothing And FechaHasta <> Nothing Then
            sql = ""
            sql = "DECLARE " & _
                "@CODPROVEEDOR INT ," & _
                "@NUMFACTURA AS VARCHAR(200), " & _
                "@CONCEPTO AS VARCHAR(300), " & _
                "@IMPORTE AS NUMERIC(18,2)," & _
                "@FECHA AS DATETIME," & _
                "@HABER AS MONEY ," & _
                "@DEBE AS MONEY ,  " & _
                "@SALDO AS NUMERIC(18,2) " & _
                "DECLARE @VariableTabla  " & _
                "as TABLE(CODPROVEEDOR INT,FECHA DATETIME,CONCEPTO VARCHAR(300),DEBE MONEY ,HABER MONEY ,SALDO MONEY)   " & _
                "declare  cur_extracto cursor for  " & _
                "SELECT C.CODPROVEEDOR,C.FECHACOMPRA AS FECHA," & _
                "'Compra según factura Nº/'+ C.NUMCOMPRA AS CONCEPTO," & _
                "SUM(C.TOTALCOMPRA ) AS DEBE,0 AS HABER " & _
                "FROM COMPRAS C INNER JOIN " & _
                "FACTURAPAGAR FP " & _
                "ON C.CODCOMPRA =FP.CODCOMPRA " & _
                "GROUP BY C.CODPROVEEDOR,C.FECHACOMPRA,C.NUMCOMPRA " & _
                "UNION ALL " & _
                "SELECT C.CODPROVEEDOR,CF.FECHAPAGO AS FECHA, " & _
                "'Pago según factura Nº '+C.NUMCOMPRA+'/'+CAST(CF.NROCUOTA AS VARCHAR(10))+'  en ' +CF.DESTIPOPAGO   AS CONCEPTO " & _
                ",0 AS DEBE,IMPORTE AS HABER " & _
                "FROM COMPRASFORMAPAGO CF " & _
                "INNER JOIN COMPRAS C " & _
                "ON C.CODCOMPRA =CF.CODCOMPRA " & _
                "WHERE CF.DESTIPOPAGO<>'Vuelto' " & _
                "ORDER BY FECHA " & _
                "SET @SALDO=0  " & _
                "open cur_extracto " & _
                "fetch next from  cur_extracto   " & _
                "into @CODPROVEEDOR,@FECHA,@CONCEPTO,@DEBE,@HABER  " & _
                "WHILE @@FETCH_STATUS = 0   " & _
                "BEGIN " & _
                "IF @HABER=0  " & _
                "Begin " & _
                "Set @SALDO=@SALDO + @DEBE  " & _
                "INSERT INTO @VariableTabla(CODPROVEEDOR,FECHA ,CONCEPTO ,DEBE ,HABER ,SALDO )  " & _
                "VALUES(@CODPROVEEDOR,@FECHA,@CONCEPTO,@DEBE ,@HABER,@SALDO)  " & _
                "End " & _
                "IF @DEBE=0   " & _
                "Begin " & _
                "Set @SALDO =@SALDO - @HABER " & _
                "INSERT INTO @VariableTabla(CODPROVEEDOR,FECHA ,CONCEPTO ,DEBE ,HABER ,SALDO )  " & _
                "VALUES(@CODPROVEEDOR,@FECHA,@CONCEPTO,@DEBE ,@HABER,@SALDO)   " & _
                "End " & _
                "fetch next from  cur_extracto " & _
                "into   @CODPROVEEDOR,@FECHA,@CONCEPTO,@DEBE,@HABER " & _
                "End " & _
                "Close cur_extracto " & _
                "deallocate cur_extracto " & _
                "Select * from @VariableTabla  " & _
                "where  fecha >= CONVERT(DATETIME,'" & FechaDesde & "',103) " & _
                "AND fecha <= CONVERT(DATETIME,'" & FechaHasta & "',103) " & _
                "AND CODPROVEEDOR=" & codproveedor & ""
        End If

        Try

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            cmd.CommandText = sql
            dr = cmd.ExecuteReader
            Do While dr.Read
                row = ds.Tables("Detalle").NewRow()

                row.Item("Fecha1") = FechaDesde
                row.Item("Fecha2") = FechaHasta
                row.Item("Campo1") = EmpDescripcion
                row.Item("Campo2") = proveedor
                row.Item("Campo4") = dr("CONCEPTO")
                row.Item("Fecha3") = dr("FECHA")
                row.Item("Numero1") = dr("DEBE")
                row.Item("Numero2") = dr("HABER")
                row.Item("Numero3") = dr("SALDO")



                ds.Tables("Detalle").Rows.Add(row)
            Loop

            ''###################
            ''#    CABECERA     #
            ''###################

            'row = ds.Tables("Cabecera").NewRow()
            'row.Item("Campo1") = EmpDescripcion
            'row.Item("Campo2") = FechaDesde
            'row.Item("Campo3") = FechaHasta

            'ds.Tables("Cabecera").Rows.Add(row)
        Catch ex As Exception

        Finally

        End Try

        Return ds

    End Function
End Class


