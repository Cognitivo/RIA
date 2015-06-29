Imports System.Data.SqlClient

Public Class Proveedor_Model

    Dim dt As New DataTable
    Public Property dataTable As DataTable
        Get
            Return dt
        End Get
        Set(value As DataTable)
            dt = value
        End Set
    End Property

    Sub list_Proveedor()
        Dim SQLCmd As SqlCommand
        Dim bd As New BDConexión.BDConexion
        Dim SQLConn As New SqlConnection(bd.connString)
        Dim SQLRdr As SqlDataReader

        Try
            SQLConn.Open()
            SQLCmd = New SqlCommand("SELECT CODPROVEEDOR, NOMBRE,NUMPROVEEDOR, RUC_CIN, TIMBRADOFACTURA, FECHAVTOTIMBRADO, CODCENTRO, CODMONEDA, ESTADO" & _
            " FROM dbo.PROVEEDOR WHERE (ESTADO = 1)", SQLConn)
            SQLRdr = SQLCmd.ExecuteReader
            dt.Load(SQLRdr)
            SQLRdr.Close()
            SQLConn.Close()
        Catch
            SQLConn.Close()
        End Try
    End Sub
End Class
