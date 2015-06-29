Imports System.Data
Imports System.Data.SqlClient
Public Class exeDataTable
    'Dim SqlBdConn As New BDConexión.BDConexion
    'Dim SQLConn As New SqlConnection
    'Dim SQLCmd As New SqlCommand
    'Dim SQLRdr As SqlDataReader

    Public Function loadDataTable(strSQL As String, connstring As String, Optional ByVal Array As ArrayList = Nothing) As DataTable
        Dim sqlconn As New SqlConnection(connstring)
        Dim sqlcmd As New SqlCommand
        Dim sqldr As SqlDataReader

        Dim dt As New DataTable

        If Not (Array) Is Nothing Then
            Dim obj As [Object]
            Dim i As Integer = 1
            For Each obj In Array
                Dim Name As String = "@" & i
                Dim SQLParameter As New SqlParameter
                SQLParameter.ParameterName = Name
                SQLParameter.Value = obj.ToString
                sqlcmd.Parameters.Add(SQLParameter)
                i = i + 1
            Next obj
        End If

        sqlconn.Open()
        sqlcmd = New SqlCommand(strSQL, sqlconn)
        sqlcmd.CommandTimeout = 100000
        Try
            sqldr = sqlcmd.ExecuteReader
            dt.Load(sqldr)
            sqldr.Close()
        Catch ex As Exception
            Throw ex
        Finally
            sqlconn.Close()
        End Try

        Return dt
    End Function
End Class

'Imports System.Data
'Imports System.Data.SqlClient
'Imports Osuna.Utiles.Conectividad


'Public Class exeDataTable

'    Dim SQLConn As System.Data.Common.DbConnection
'    Dim ser As New BDConexión.BDConexion
'    'Dim SQLCmd As New SqlCommand
'    Dim SQLRdr As SqlDataReader

'    Public Function loadDataTable(ByVal SQLCmd As SqlCommand) As DataTable
'        Dim dt As New DataTable

'        Try
'            SQLConn = ser.connString
'            dt = Consultas.ConsultaDt(SQLConn, strSQL)

'        Finally
'            SQLConn.Close()
'        End Try

'        Try
'            SQLConn.Open()
'            SQLCmd = New SqlCommand(strSQL, SQLConn)
'            SQLRdr = SQLCmd.ExecuteReader
'            dt.Load(SQLRdr)
'            SQLRdr.Close()
'            SQLConn.Close()
'        Catch
'            SQLRdr.Close()
'            SQLConn.Close()
'        End Try

'        'returns nothing if failed.
'        Return dt
'    End Function
'End Class
