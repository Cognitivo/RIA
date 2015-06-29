Imports System.Data
Imports System.Data.SqlClient

Public Class Sucursal_Model

    Dim dt As New DataTable
    Public Property dataTable As DataTable
        Get
            Return dt
        End Get
        Set(value As DataTable)
            dt = value
        End Set
    End Property

    Sub load_Deposito()
        Dim SQLCmd As SqlCommand
        Dim bd As New BDConexión.BDConexion
        Dim SQLConn As New SqlConnection(bd.connString)
        Dim SQLRdr As SqlDataReader
        Try
            SQLConn.Open()
            SQLCmd = New SqlCommand(" SELECT CODSUCURSAL, DESSUCURSAL," & _
                                    " FROM SUCURSAL" & _
                                    " WHERE (TIPOSUCURSAL = 'Factura y Stock') OR" & _
                                    " (TIPOSUCURSAL = 'Solo Stock')", SQLConn)
            SQLRdr = SQLCmd.ExecuteReader
            dt.Load(SQLRdr)
            SQLRdr.Close()
            SQLConn.Close()
        Catch
            SQLConn.Close()
        End Try
    End Sub

    Sub load_Sucursal()
        Dim SQLCmd As SqlCommand
        Dim bd As New BDConexión.BDConexion
        Dim SQLConn As New SqlConnection(bd.connString)
        Dim SQLRdr As SqlDataReader
        Try
            SQLConn.Open()
            SQLCmd = New SqlCommand(" SELECT CODSUCURSAL, DESSUCURSAL, NUMSUCURSAL," & _
                                    " SUCURSALTIMBRADO" & _
                                    " FROM SUCURSAL" & _
                                    " WHERE (TIPOSUCURSAL = 'Factura y Stock') OR" & _
                                    " (TIPOSUCURSAL = 'Solo Factura')", SQLConn)
            SQLRdr = SQLCmd.ExecuteReader
            dt.Load(SQLRdr)
            SQLRdr.Close()
            SQLConn.Close()
        Catch
            SQLConn.Close()
        End Try
    End Sub
End Class
