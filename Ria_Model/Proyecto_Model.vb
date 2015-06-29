Imports System.Data.SqlClient

Public Class Proyecto_Model

    Dim dt As New DataTable
    Public Property dataTable As DataTable
        Get
            Return dt
        End Get
        Set(value As DataTable)
            dt = value
        End Set
    End Property


    Sub list_ProyectoActivos()
        Dim SQLCmd As SqlCommand
        Dim bd As New BDConexión.BDConexion
        Dim SQLConn As New SqlConnection(bd.connString)
        Dim SQLRdr As SqlDataReader

        Try
            SQLConn.Open()
            SQLCmd = New SqlCommand("SELECT * FROM EVENTO WHERE ESTADO = 1", SQLConn)
            SQLRdr = SQLCmd.ExecuteReader
            dt.Load(SQLRdr)
            SQLRdr.Close()
            SQLConn.Close()
        Catch
            'SQLRdr.Close()
            SQLConn.Close()
        End Try
    End Sub

End Class
