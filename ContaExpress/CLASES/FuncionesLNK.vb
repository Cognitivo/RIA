''###########################################################################################################
''Modulo de Funciones varias para usar con el servidor externo de Link - by Yolanda Zelaya
''###########################################################################################################

'Imports MySql.Data
'Imports MySql.Data.MySqlClient

'Module FuncionesLNK


#Region "Fields"
    'Public LNKConn As MySqlConnection
#End Region 'Fields

'#Region "Fields"
'    Public LNKConn As MySqlConnection
'#End Region 'Fields




'Public Sub LNKDB()
'    LNKConn = New MySqlConnection
'    LNKConn.ConnectionString = "Server=cogentpotential.com; user id=posexpress; password=t8UTh4kEstuh; database=Link; default command timeout=60;"
'End Sub

'#Region "Methods"
'    Public Sub LNKDB()
'        LNKConn = New MySqlConnection
'        LNKConn.ConnectionString = "Server=cogentpotential.com; user id=posexpress; password=t8UTh4kEstuh; database=Link; default command timeout=60;"
'    End Sub



'Public Function VerificarLNK(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal valor_campo As String) As Long
'    Dim myCommand As New MySqlCommand
'    Dim consulta As String

'    Public Function VerificarLNK(ByVal campo_a_traer As String, ByVal nombre_tabla As String, ByVal campo_a_comparar As String, ByVal valor_campo As String) As Long
'        Dim myCommand As New MySqlCommand
'        Dim consulta As String

'    If LinkOn = 1 Then
'        LNKDB()
'        Try
'            LNKConn.Open()
'        Catch ex As Exception
'        End Try

'        If LinkOn = 1 Then
'            LNKDB()
'            Try
'                LNKConn.Open()
'            Catch ex As Exception
'            End Try

'        consulta = "SELECT " & campo_a_traer & "  FROM " & nombre_tabla & " WHERE " & campo_a_comparar & " = " & valor_campo & " "

'            consulta = "SELECT " & campo_a_traer & "  FROM " & nombre_tabla & " WHERE " & campo_a_comparar & " = " & valor_campo & " "

'        myCommand.Connection = LNKConn
'        myCommand.CommandText = consulta

'            myCommand.Connection = LNKConn
'            myCommand.CommandText = consulta

'        Try
'            Return myCommand.ExecuteScalar
'        Catch
'            Return 0
'        Finally
'            LNKConn.Close()
'            LNKConn.Dispose()
'        End Try

'            Try
'                Return myCommand.ExecuteScalar
'            Catch
'                Return 0
'            Finally
'                LNKConn.Close()
'                LNKConn.Dispose()
'            End Try

'    End If
'End Function

'        End If
'    End Function



'Public Function PromoActivo(ByVal campo_a_comparar1 As String, ByVal campo_a_comparar2 As String) As Long
'    Dim myCommand As New MySqlCommand
'    Dim consulta As String

'    Public Function PromoActivo(ByVal campo_a_comparar1 As String, ByVal campo_a_comparar2 As String) As Long
'        Dim myCommand As New MySqlCommand
'        Dim consulta As String



'    If LinkOn = 1 Then
'        LNKDB()
'        LNKConn.Open()

'        If LinkOn = 1 Then
'            LNKDB()
'            LNKConn.Open()



'        consulta = "SELECT IF(CURDATE() <= TrailEndDat , 1, 0) As PruebaActiva " & _
'                  "FROM CompanyBranchModule WHERE companybranchid = " & campo_a_comparar1 & " AND moduleid = " & campo_a_comparar2 & "; "

'            consulta = "SELECT IF(CURDATE() <= TrailEndDat , 1, 0) As PruebaActiva " & _
'                      "FROM CompanyBranchModule WHERE companybranchid = " & campo_a_comparar1 & " AND moduleid = " & campo_a_comparar2 & "; "



'        myCommand.Connection = LNKConn
'        myCommand.CommandText = consulta

'            myCommand.Connection = LNKConn
'            myCommand.CommandText = consulta



'        Try
'            Return myCommand.ExecuteScalar
'        Catch
'            Return 0
'        End Try

'            Try
'                Return myCommand.ExecuteScalar
'            Catch
'                Return 0
'            End Try



'        LNKConn.Close()
'        LNKConn.Dispose()
'    End If
'End Function

'            LNKConn.Close()
'            LNKConn.Dispose()
'        End If
'    End Function



'Public Function GenerarFechaPromo() As Date
'    Dim myCommand As New MySqlCommand
'    Dim consulta As String

'    Public Function GenerarFechaPromo() As Date
'        Dim myCommand As New MySqlCommand
'        Dim consulta As String

'    If LinkOn = 1 Then
'        LNKDB()
'        LNKConn.Open()

'        If LinkOn = 1 Then
'            LNKDB()
'            LNKConn.Open()

'        consulta = "SELECT DATE_ADD(now(), INTERVAL 15 DAY);"

'            consulta = "SELECT DATE_ADD(now(), INTERVAL 15 DAY);"



'        myCommand.Connection = LNKConn
'        myCommand.CommandText = consulta

'            myCommand.Connection = LNKConn


'        Try
'            Return myCommand.ExecuteScalar
'        Catch
'            Return Today
'        End Try

'            Try
'                Return myCommand.ExecuteScalar
'            Catch
'                Return Today
'            End Try

'        LNKConn.Close()
'        LNKConn.Dispose()
'    End If
'End Function

'            LNKConn.Close()
'            LNKConn.Dispose()
'        End If
'    End Function



'Public Function Maximo(ByVal campo_a_traer As String, ByVal nombre_tabla As String) As Long
'    Dim myCommand As New MySqlCommand
'    Dim consulta As String

'    Public Function Maximo(ByVal campo_a_traer As String, ByVal nombre_tabla As String) As Long
'        Dim myCommand As New MySqlCommand
'        Dim consulta As String



'    If LinkOn = 1 Then
'        LNKDB()
'        LNKConn.Open()

'        If LinkOn = 1 Then
'            LNKDB()
'            LNKConn.Open()

'        consulta = "SELECT MAX(" & campo_a_traer & ") As Maximo FROM " & nombre_tabla & "; "

'        myCommand.Connection = LNKConn
'        myCommand.CommandText = consulta


'        Try
'            Return myCommand.ExecuteScalar
'        Catch
'            Return 0
'        End Try

'        LNKConn.Close()
'        LNKConn.Dispose()
'    End If
'End Function


'#End Region 'Fields
'End Module
