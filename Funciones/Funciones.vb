Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad
Imports System.Data.SqlClient

Public Class Funciones

#Region "Fields"

    Dim a, b, c As String
    Dim ds As DataSet
    'Dim dt As New DataTable("dtResultado")
    Dim ser As New BDConexión.BDConexion

#End Region 'Fields

#Region "Methods"

    Public Function BaseDatos() As DataSet
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim ds As System.Data.DataSet

        consulta = "select ""DBID"" AS CODIGO,""name"" as NOMBRE from master.dbo.sysdatabases where ""sid"" <> 0x01"

        conexion = ser.Abrir()

        Try
            ds = Consultas.ConsultaDs(conexion, consulta)
        Finally
            conexion.Close()
        End Try

        Return ds
    End Function

    Public Function CantidadRegistro(ByVal campo_a_traer As String, ByVal nombre_tabla As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        conexion = ser.Abrir

        consulta = "SELECT COUNT(" & campo_a_traer & ") AS total FROM " & nombre_tabla & "  "

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Ciudad() As DataSet
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim ds As System.Data.DataSet = Nothing
        'Dim style As Microsoft.VisualBasic.MsgBoxStyle
        conexion = ser.Abrir()

        Try
            consulta = "SELECT CODCIUDAD AS CODIGO, RTRIM(DESCIUDAD) AS NOMBRE FROM CIUDAD ORDER BY DESCIUDAD ASC"
            ds = Consultas.ConsultaDs(conexion, consulta)
        Catch ex As Exception
            Dim ex2 As Exception = New Exception("No se pudo realizar la Conexión." & vbCrLf & "Verifique el Servidor.", ex)
            MessageBox.Show(ex2.Message)
        Finally
            conexion.Close()
        End Try

        Return ds
    End Function

    '###########################################################################################################
    'Esta función es utilizada para obtener la cantidad de registros de una tabla, teniendo en cuenta un filtro,
    'el campo que se devuelve es del tipo LONG  by Fabio Ojeda
    '###########################################################################################################
    Public Function ConBetween(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal valor_campo As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & campo_a_traer & " AS total FROM " & nombre_tabla & " where " & campo_a_comparar & " between " & valor_campo & " "

        conexion = ser.Abrir

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ConsultaPrecio(ByVal Codigo1 As Integer, ByVal Codigo2 As Integer, ByVal Codigo3 As Integer, ByVal Codigo4 As Integer, ByVal Tabla As String, ByVal PrimerIngresa As String, ByVal SegundoIngresa As String, ByVal TercerIngresa As String, ByVal Cuartoingresa As String) As Integer
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & PrimerIngresa & "  as Existe  From  " & Tabla & " where (" & PrimerIngresa & "  = " & Codigo1 & ") and (" & SegundoIngresa & "= " & Codigo2 & ") and (" & TercerIngresa & " = " & Codigo3 & ") and (" & Cuartoingresa & " = " & Codigo4 & " )"

        conexion = ser.Abrir

        Try
            Return Consultas.ConsultaEscalar(Of Integer)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    '###########################################################################################################
    'Esta función es utilizada para obtener la cantidad de registros de una tabla, teniendo en cuenta un filtro,
    'el campo que se devuelve es del tipo LONG  by Fabio Ojeda
    '###########################################################################################################
    Public Function CountconWhere(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal valor_campo As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = ""
        If campo_a_comparar = "" Or valor_campo = "" Then
            consulta = "SELECT COUNT(" & campo_a_traer & ") AS total FROM " & nombre_tabla
        Else
            consulta = "SELECT COUNT(" & campo_a_traer & ") AS total FROM " & nombre_tabla & " where " & campo_a_comparar & "= " & valor_campo & " "
        End If

        conexion = ser.Abrir

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function CtaCaracteresPassw(ByVal nombre_campo As String, ByVal nombre_tabla As String, ByVal codigo_empresa As String, ByVal codusuario As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & nombre_campo & " AS maximo FROM " & nombre_tabla & " where codempresa = " & codigo_empresa & " and codusuario=" & codusuario & "  "

        conexion = ser.Abrir

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Descripcion_Tabla(ByVal nombre_campo As String, ByVal nombre_tabla As String, ByVal campo_buscado As String, ByVal variable_ingresada As String, ByVal codigo_empresa As Long) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT RTRIM(" & nombre_campo & ") AS DESCRIPCION FROM " & nombre_tabla & " WHERE " & campo_buscado & " = '" & variable_ingresada & "' AND CODEMPRESA = " & codigo_empresa & " "

        conexion = ser.Abrir

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Empresa() As DataSet
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim ds As System.Data.DataSet = Nothing

        consulta = "SELECT CODEMPRESA AS CODIGO, RTRIM(NOMFANTASIA) AS NOMBRE FROM EMPRESA ORDER BY NOMFANTASIA"

        conexion = ser.Abrir()

        Try
            ds = Consultas.ConsultaDs(conexion, consulta)
        Catch ex As Exception
            MsgBox("No se pudo realizar la Conexión." & vbCrLf & "Verifique el Servidor.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly + MsgBoxStyle.SystemModal, _
            "Acceso")
        Finally
            conexion.Close()
        End Try

        Return ds
    End Function

    Public Function Entrar_OpciondeMenu(ByVal CodUsuario As Long, ByVal CodModulo As String, ByVal CodEmpresa As Long, ByVal NumSistema As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim result As System.Int32

        consulta = "SELECT CASE WHEN (MU.[SELECT]) = 0 " _
                 & "AND (MU.[INSERT]) = 0 " _
                 & "AND (MU.[UPDATE]) = 0 " _
                 & "AND (MU.[DELETE]) = 0 " _
                 & "AND (MU.[PRINT]) = 0 " _
                 & "AND (MU.VENCIDAS) = 0 " _
                 & "AND (MU.LIMITECREDITO) = 0 " _
                 & "AND (MU.[DESC]) = 0 " _
                 & "AND (MU.ANULAR) = 0 THEN 0 " _
                 & "ELSE isnull(mu.codmodulo, 0) END AS modulo " _
                 & "FROM modulousuario mu, modulos m, sistemas s " _
                 & "WHERE mu.codusuario = " & ValoresSql.Int64(CodUsuario) & " " _
                 & "AND mu.codmodulo = m.codmodulo " _
                 & "AND s.NUMSISTEMAS = " & ValoresSql.VarChar(NumSistema) & " " _
                 & "AND m.CODSISTEMAS = s.codsistemas " _
                 & "AND mu.codempresa = " & ValoresSql.Int64(CodEmpresa) & " " _
                 & "AND m.desmodulo = " & ValoresSql.VarChar(CodModulo)

        conexion = ser.Abrir()

        Try
            result = Consultas.ConsultaEscalar(Of Integer)(conexion, consulta)
            Return result
        Catch
            Return 0
        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
    End Function

    Public Function FormateaFecha(ByVal FechaSinFormato As String) As String
        Dim ano As String
        Dim mes As String
        Dim dia As String
        ano = FechaSinFormato.Substring(6, 4)
        mes = FechaSinFormato.Substring(3, 2)
        dia = FechaSinFormato.Substring(0, 2)
        Dim FechaConFormato As String
        FechaConFormato = ano + mes + dia
        Return FechaConFormato
    End Function

    Public Function FuncionCalculaManoObra(ByVal campo_a_traer As String, ByVal variable_ingresada1 As String, ByVal variable_ingresada2 As String) As Decimal
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT SUM(" & campo_a_traer & ") AS total " _
            & "FROM PRODUCTOOPERACIONDETALLE " _
            & "where CODPRODUCTO = " & variable_ingresada1 & " " _
            & "AND CODCODIGO = " & variable_ingresada2 & " "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Decimal)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function FuncionCodigoStringNumeric(ByVal campo_a_traer As String, ByVal nombre_tabla As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT MAX(CONVERT(NUMERIC(18)," & campo_a_traer & ")) AS maximo FROM " & nombre_tabla & "  "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function FuncionConsulta(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal variable_ingresada As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & campo_a_traer & " AS maximo FROM " & nombre_tabla & " where " & campo_a_comparar & " = '" & variable_ingresada & "' "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function FuncionExisteDuplicados(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal variable_ingresada As String) As Decimal
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT COUNT(" & campo_a_traer & ") AS REPETICION FROM " & nombre_tabla & " WHERE " & campo_a_comparar & " = '" & variable_ingresada & "' "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Decimal)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function FuncionConsulta2(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal campo_a_comparar2 As String, ByVal variable_ingresada As String, ByVal variable_ingresada2 As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & campo_a_traer & " AS maximo FROM " & nombre_tabla & " where " & campo_a_comparar & " = '" & variable_ingresada & "' and " & campo_a_comparar2 & " = '" & variable_ingresada2 & "' "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    '########################################################################################################
    'Esta función es utilizada para obtener un campo específico y devolverlo en una variable de tipo DECIMAL,
    'esto quiere decir que el dato devuelto es un número .
    '########################################################################################################
    Public Function FuncionConsultaDecimal(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal variable_ingresada As String) As Decimal
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & campo_a_traer & " AS maximo FROM " & nombre_tabla & " where " & campo_a_comparar & " = '" & variable_ingresada & "' "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Decimal)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    '######################################################################################################
    'Esta Función es utilizada para obtener un campo específico y devolverlo en una variable de tipo STRING
    'esto quiere decir que el dato devuelto es un carácter. Trae de dos Tablas by Fabio Ojeda
    '######################################################################################################
    Public Function FuncionConsultaDosTablas(ByVal CAMPO As String, ByVal TABLA_1 As String, ByVal TABLA_2 As String, ByVal CODIGO_INNER As String, ByVal CAMPO_COMPARA As String, ByVal VARIABLE_COMPARACION As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & CAMPO & " AS maximo " _
                 & "FROM " & TABLA_1 & " " _
                 & "INNER JOIN " & TABLA_2 & " " _
                 & "ON " & TABLA_1 & "." & CODIGO_INNER & " = " & TABLA_2 & "." & CODIGO_INNER & " " _
                 & "WHERE " & TABLA_2 & "." & CAMPO_COMPARA & " = '" & VARIABLE_COMPARACION & "'"

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    '######################################################################################################
    'Esta Función es utilizada para obtener un campo específico y devolverlo en una variable de tipo STRING
    'esto quiere decir que el dato devuelto es un carácter. Trae de dos Tablas by Fabio Ojeda RIGHT OUTER JOIN
    '######################################################################################################
    Public Function FuncionConsultaDosTablasRight(ByVal CAMPO As String, ByVal TABLA_1 As String, ByVal TABLA_2 As String, ByVal CODIGO_INNER As String, ByVal CAMPO_COMPARA As String, ByVal VARIABLE_COMPARACION As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & CAMPO & " AS maximo FROM " & TABLA_1 & " RIGHT OUTER JOIN " & TABLA_2 & _
        " ON " & TABLA_1 & "." & CODIGO_INNER & " = " & TABLA_2 & "." & CODIGO_INNER & _
        " WHERE " & TABLA_2 & "." & CAMPO_COMPARA & " = '" & VARIABLE_COMPARACION & "'"

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function FuncionConsultaString(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal variable_ingresada As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        If variable_ingresada = "" Then
            variable_ingresada = 0
        End If

        consulta = "SELECT " & campo_a_traer & " AS maximo FROM " & nombre_tabla & " where " & campo_a_comparar & " = '" & variable_ingresada & "' "
        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function FuncionConsultaStringMAX(ByVal campo_a_traer As String, ByVal nombre_tabla As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & campo_a_traer & " AS maximo FROM " & nombre_tabla

        conexion = ser.Abrir()

        Try

            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function


    Public Function FuncionSUM(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal variable_ingresada As String) As Double
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT SUM(" & campo_a_traer & ") FROM " & nombre_tabla & " WHERE " & campo_a_comparar & " = " & campo_a_traer

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Decimal)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    
    'Public Function FuncionConsultaStringDos(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal variable_ingresada As String) As String
    '    Dim ConsultaDos As New SqlCommand
    '    Dim conexion As System.Data.Common.DbConnection
    '    Dim CompanyData As MySqlDataReader

    '    conexion = ser.Abrir()
    '    ConsultaDos = "SELECT " & CampoUno & ", " & CampoDos & " FROM " & nombre_tabla & " where " & campo_a_comparar & " = '" & variable_ingresada & "' "




    '    Try
    '        ' Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
    '    Finally
    '        conexion.Close()
    '    End Try
    'End Function


    Public Function FuncionTop1(ByVal campo_a_traer As String, ByVal nombre_tabla As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT TOP (1)" & campo_a_traer & " AS maximo FROM " & nombre_tabla

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function FuncionTop1WHERE(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As Integer) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "select top(1)" & campo_a_traer & " as maximo from " & nombre_tabla & " where CODMONEDA=" & campo_a_comparar

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function
    Public Function FuncionTop1WHEREString(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "select top(1)" & campo_a_traer & " as maximo from " & nombre_tabla & " where TIPOSUCURSAL=" & campo_a_comparar

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function HAB(ByVal campo_a_traer As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "OPEN SYMMETRIC KEY CogentTableKey " & _
                   "DECRYPTION BY CERTIFICATE EncryptCogentCert " & _
                   "SELECT CONVERT(VARCHAR(50),DECRYPTBYKEY(HAB))  AS DecryptSecondCol  " & _
                   "FROM SUCURSAL WHERE CODSUCURSAL = " & campo_a_traer

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function


    Public Function FuncionDECRYPTBYKEY(ByVal campo_a_traer As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "OPEN SYMMETRIC KEY CogentTableKey " & _
                   "DECRYPTION BY CERTIFICATE EncryptCogentCert " & _
                   "SELECT CONVERT(VARCHAR(50),DECRYPTBYKEY(UPD))  AS DecryptSecondCol , UPD " & _
                   "FROM LINK WHERE LINKID = " & campo_a_traer

        conexion = ser.Abrir()

        Try

            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function FuncionConsultaString2(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal variable_ingresada As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & campo_a_traer & " AS maximo FROM " & nombre_tabla & " where " & campo_a_comparar & " = " & variable_ingresada & " "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    '######################################################################################################
    'Esta Función es utilizada para obtener un campo específico y devolverlo en una variable de tipo STRING
    'esto quiere decir que el dato devuelto es un carácter. Se utiliza la funcion Like by Fabio Ojeda
    '######################################################################################################
    Public Function FuncionLikeConsultaString(ByVal CAMPO As String, ByVal TABLA As String, ByVal CAMPO_COMPARA1 As String, _
        ByVal CAMPO_COMPARA2 As String, ByVal CAMPO_COMPARA3 As String, _
        ByVal VARIABLE_COMPARACION As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & CAMPO & " AS maximo FROM " & TABLA & "" & " where " & CAMPO_COMPARA1 & " LIKE '" & VARIABLE_COMPARACION & _
        "' OR " & CAMPO_COMPARA2 & " LIKE '" & VARIABLE_COMPARACION & _
        "' OR " & CAMPO_COMPARA3 & " lIKE '" & VARIABLE_COMPARACION & "'"

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    '#################################################################################################################
    'INSERTAR DATOS EN LA TABLA AUDITORIA MOVIMIENTOS: PARA GUARDAR LOS DATOS EN LA TABLA DE AUDITORIA  by Fabio Ojeda
    '#################################################################################################################
    Public Function InsertarAuditoriaMovimiento(ByVal Codigo As Integer, ByVal Empresa As Integer, ByVal Movimiento As String, ByVal Sucursal As String, _
        ByVal Comprobante As String, ByVal Numero As String, ByVal Moneda As String, ByVal Cotizacion1 As String, ByVal Cotizacion2 As String, _
        ByVal FechaMovimiento As String, ByVal FechaProceso As String, ByVal Observacion As String, ByVal Importe As String, ByVal Detalle As String, _
        ByVal Fecha As Date, ByVal Usuario As String, ByVal Nivel As String, ByVal Insertar As Integer, ByVal Modificar As Integer, _
        ByVal Eliminar As Integer) As Integer
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "INSERT INTO [AUDITORIAMOVIMIENTOS] ([CODIGO],[EMPRESA],[MOVIMIENTO],[SUCURSAL],[COMPROBANTE],[NUMERO],[MONEDA],[COTIZACION1],[COTIZACION2], " & _
            "[FECHAMOVIMIENTO],[FECHAPROCESO],[OBSERVACION],[IMPORTE],[DETALLE],[FECHA],[USUARIO],[NIVEL],[INSERTAR],[MODIFICAR],[ELIMINAR]) " & _
            "VALUES (" & Codigo & ", " & Empresa & ", '" & Movimiento & "', '" & Sucursal & "', '" & Comprobante & "', '" & Numero & "', '" & Moneda & "', '" & Cotizacion1 & "', '" & Cotizacion2 & "', '" & _
            FechaMovimiento & "', '" & FechaProceso & "', '" & Observacion & "', " & Importe & ", '" & _
            Detalle & "', " & "convert(datetime, '" & Fecha & " 0:00:00', 103)" & ", '" & Usuario & "', '" & Nivel & "', " & Insertar & ", " & Modificar & ", " & Eliminar & ")"

        conexion = ser.Abrir()

        Try
            Consultas.ConsultaComando(conexion, consulta)
            Return 1
        Catch ex As Exception

            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    '#################################################################################################################
    'INSERTAR DATOS EN LA TABLA AUDITORIA TABLAS: PARA GUARDAR LOS DATOS EN LA TABLA DE AUDITORIA  by Fabio Ojeda
    '#################################################################################################################
    Public Function InsertarAuditoriaTablas(ByVal Codigo As Integer, ByVal Empresa As Integer, ByVal Tabla As String, ByVal NumCodigo As String, _
        ByVal Descripcion As String, ByVal Fecha As Date, ByVal Usuario As String, ByVal Nivel As String, ByVal Insertar As Integer, _
        ByVal Modificar As Integer, ByVal Eliminar As Integer) As Integer
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "INSERT INTO [AUDITORIATABLAS]([CODIGO],[EMPRESA],[TABLA],[NUMCODIGO],[DESCRIPCION],[FECHA],[USUARIO],[NIVEL],[INSERTAR], " & _
           "[MODIFICAR],[ELIMINAR]) " & _
        "VALUES (" & Codigo & ", " & Empresa & ", '" & Tabla & "', '" & NumCodigo & "', '" & Descripcion & "', " & "convert(datetime, getdate(), 103)" & ", '" & _
        Usuario & "', '" & Nivel & "', " & Insertar & ", " & Modificar & ", " & Eliminar & ")"

        conexion = ser.Abrir()

        Try
            Consultas.ConsultaComando(conexion, consulta)
            Return 1
        Catch ex As Exception

            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    '#############################################################################################################
    'INSERTAR DATOS EN LA TABLA MOVIMIENTOS: PARA GUARDAR LOS DATOS EN LA TABLA DE MOVIMIENTOS  by Fabio Ojeda
    '#############################################################################################################
    Public Function InsertarMovimientoProducto(ByVal codmto As Integer, ByVal CodProducto As Integer, ByVal CodCodigo As Integer, _
        ByVal Concepto As String, ByVal TipoMovimiento As String, ByVal Cantidad As Integer, _
        ByVal FechaMto As Date, ByVal CodUsuario As Integer, ByVal CodEmpresa As Integer, _
        ByVal NumComprobante As String) As Integer
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "INSERT INTO [MOVIMIENTOPRODUCTO]([CODIGOMOVIEMIENTO],[CODPRODUCTO],[CODCODIGO],[CONCEPTO],[TIPOMOVIMIENTO],[CANTIDAD],[FECHAMTO] " & _
           ",[CODUSUARIO],[CODEMPRESA],[NUMCOMPROVANTE]) " & _
            "VALUES (" & codmto & " ," & CodProducto & ", " & CodCodigo & ", '" & Concepto & "', '" & TipoMovimiento & "', " & Cantidad & ", " & _
            "convert(datetime, '" & FechaMto & " 0:00:00', 103)" & ", " & CodUsuario & ", " & CodEmpresa & ", '" & NumComprobante & "')"

        conexion = ser.Abrir()

        Try
            Consultas.ConsultaComando(conexion, consulta)
            Return 1
        Catch ex As Exception

            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Maximo(ByVal campo_a_traer As String, ByVal nombre_tabla As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT MAX(" & campo_a_traer & ") AS maximo FROM " & nombre_tabla & ""

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch ex As Exception
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Maximo_con_Where(ByVal campo_a_traer As String, ByVal nombre_tabla As String, where As string) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT MAX(" & campo_a_traer & ") AS maximo FROM " & nombre_tabla & " WHERE " & where

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch ex As Exception
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function
    '###########################################################################################################
    'Esta función es utilizada para obtener un campo maximo especifico y devolverlo en una variable de tipo LONG,
    'esto quiere decir que el dato devuelto es un número, y se los datos se filtran con un Where By Cesar
    '###########################################################################################################
    Public Function MaximoconWhere(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal valor_campo As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT MAX(" & campo_a_traer & ") AS maximo FROM " & nombre_tabla & " where " & campo_a_comparar & " = " & valor_campo & " "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch ex As Exception
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function MaximoconWhereDistinto(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal valor_campo As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT MAX(" & campo_a_traer & ") AS maximo FROM " & nombre_tabla & " where " & campo_a_comparar & " <> " & valor_campo & " "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch ex As Exception
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function MaximoIsNotNull(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT MAX(" & campo_a_traer & ") AS maximo FROM " & nombre_tabla & " where " & campo_a_comparar & " IS NOT NULL"

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch ex As Exception
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Minimo(ByVal campo_a_traer As String, ByVal nombre_tabla As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT MIN(" & campo_a_traer & ") AS minimo FROM " & nombre_tabla & "  "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch ex As Exception
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Monillo(ByVal PrimerCodigo As Integer, ByVal SegundoCodigo As Integer, ByVal Tabla As String, ByVal PrimerCompara As String, ByVal SegundoCompara As String) As Integer
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & PrimerCompara & "  as Existe  From  " & Tabla & " where (" & PrimerCompara & "  = " & PrimerCodigo & ") and (" & SegundoCompara & "= " & SegundoCodigo & ")"

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Integer)(conexion, consulta)
        Catch ex As Exception
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Monillo2(ByVal CampoaTraer As String, ByVal PrimerCodigo As Integer, ByVal SegundoCodigo As Integer, ByVal Tabla As String, ByVal PrimerCompara As String, ByVal SegundoCompara As String) As String
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT " & CampoaTraer & "  as Existe  From  " & Tabla & " where (" & PrimerCompara & "  = " & PrimerCodigo & ") and (" & SegundoCompara & "= " & SegundoCodigo & ")"

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of String)(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function otorgapermisos(ByVal Descripcion_De_Modulo As String, ByVal Num_De_Sistemas As String, _
        ByVal Codigo_De_Usuario As Long, ByVal codigoempresa As Long) As DbDataReader
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT M.CODMODULO, S.CODSISTEMAS, MU.CODUSUARIO, (MU.[SELECT])AS S, (MU.[INSERT])AS I , (MU.[UPDATE])AS U, (MU.[DELETE]) AS D, (MU.[PRINT])AS P, " & _
                     "(MU.VENCIDAS)AS V, (MU.LIMITECREDITO)AS L, (MU.[DESC])AS D,(MU.ANULAR)AS A FROM MODULOS M, SISTEMAS S, MODULOUSUARIO MU " & _
                      "WHERE S.NUMSISTEMAS = '" & Num_De_Sistemas & "' AND " & _
                      "MU.CODUSUARIO = " & Codigo_De_Usuario & " " & _
                      "AND M.DESMODULO = '" & Descripcion_De_Modulo & "' AND M.CODMODULO = MU.CODMODULO " & _
                      "AND M.CODSISTEMAS = S.CODSISTEMAS "

        conexion = ser.Abrir()

        Return Consultas.ConsultaReader(conexion, consulta)
    End Function

    Public Function Sucursal(ByVal empresa As Long) As DataSet
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "select rtrim(numsucursal) + ' ' + rtrim(dessucursal) as Nombre, codsucursal as Codigo from sucursal where codempresa = '" & empresa & "' ORDER BY DESSUCURSAL"

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaDs(conexion, consulta)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function usuario(ByVal nombre_usuario As String, ByVal password As String, ByVal codigoempresa As Long) As DbDataReader
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT CODUSUARIO AS codigo" _
            & ", CODEMPRESA AS empresa" _
            & ", rtrim(DESUSUARIO) AS usuario" _
            & ", rtrim(PASSUSUARIO) as password" _
            & ", NIVELCUENTA AS NIVEL" _
            & ", NOMBRE" _
            & ", APELLIDO" _
            & ", SEXO" _
            & ",CAJERO " _
            & ",IMAGEN " _
            & ",ESTADO " _
            & "FROM USUARIO " _
            & "WHERE DESUSUARIO = '" & nombre_usuario & "' " _
            & "AND PASSUSUARIO = '" & password & "' "

        conexion = ser.Abrir()

        Return Consultas.ConsultaReader(conexion, consulta)
    End Function

    Public Function ValidarModulo(ByVal numsistemas As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim valor As System.String

        consulta = "OPEN SYMMETRIC KEY GestionTableKey DECRYPTION BY CERTIFICATE EncryptGestionCert " & _
                   "SELECT Convert(VARCHAR(50), DECRYPTBYKEY(ACEPTAENCRYPTADO)) AS ACEPTA FROM SISTEMAS WHERE NUMSISTEMAS='" & numsistemas & "' "

        conexion = ser.Abrir()

        Try
            valor = Consultas.ConsultaEscalar(Of String)(conexion, consulta)

            If valor = "4121982" Then
                Return 0
            ElseIf valor = "1312182" Then
                Return 1
            ElseIf valor = "1405811" Then
                Return 2
            End If

        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function Validar_Tabla(ByVal nombre_campo As String, ByVal nombre_tabla As String, ByVal campo_buscado As String, ByVal variable_ingresada As String, ByVal codigo_empresa As String) As Long
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection

        consulta = "SELECT MAX(" & nombre_campo & ") AS maximo FROM " & nombre_tabla & " where " & campo_buscado & " = '" & variable_ingresada & "' and codempresa = " & codigo_empresa & " "

        conexion = ser.Abrir()

        Try
            Return Consultas.ConsultaEscalar(Of Long)(conexion, consulta)
        Catch
            Return 0
        Finally
            conexion.Close()
        End Try
    End Function

    'Tiene la misma funcionalidad de Validar_Tabla y devuelve un valor boolean en caso de
    'que exista una clave string igual a la variable_ingresada
    Public Function Validar_Tabla_cod_string(ByVal nombre_campo As String, ByVal nombre_tabla As String, ByVal campo_buscado As String, ByVal variable_ingresada As String, ByVal codigo_empresa As String) As Boolean
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim count As System.Int32

        consulta = "SELECT count(*) " _
                 & "FROM " & nombre_tabla & " " _
                 & "WHERE " & campo_buscado & " = " & ValoresSql.VarChar(variable_ingresada) & " " _
                 & "AND codempresa = " & codigo_empresa

        conexion = ser.Abrir()

        Try
            count = Consultas.ConsultaEscalar(Of Integer)(conexion, consulta)
            Return count > 0
        Catch
            Return False
        Finally
            conexion.Close()
        End Try
    End Function



#End Region 'Methods

    'Function FuncionConsultaString(p1 As String, p2 As String, p3 As String) As String
    '    Throw New NotImplementedException
    'End Function

End Class