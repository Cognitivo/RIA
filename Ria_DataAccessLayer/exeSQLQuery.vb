Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Public Class exeSQLQuery

    Dim SQLConn As System.Data.Common.DbConnection
    Dim ser As New BDConexión.BDConexion
    Dim SQLCmd As New SqlCommand
    Dim SQLRdr As SqlDataReader

    Public Sub SQLQuery_Execute(ByVal strSQL As String)
        Try
            SQLConn = ser.Abrir
            SQLCmd = New SqlCommand(strSQL, SQLConn)
            'Execute
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        Catch
            SQLConn.Close()
        End Try
    End Sub

    Public Function SQLQuery_ReturnScalar(ByVal strSQL As String)
        Dim eSQL As String = Nothing
        Try
            SQLConn.Open()
            SQLCmd = New SqlCommand(strSQL, SQLConn)
            'Execute & Return Scalar
            eSQL = SQLCmd.ExecuteScalar
            SQLConn.Close()
        Catch
            SQLConn.Close()
        End Try
        Return eSQL
    End Function

 
End Class
