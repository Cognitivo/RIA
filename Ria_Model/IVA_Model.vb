Imports System.Data.SqlClient

Public Class IVA_Model

    Dim dt As New DataTable
    Public Property dataTable As DataTable
        Get
            Return dt
        End Get
        Set(value As DataTable)
            dt = value
        End Set
    End Property


    Sub list_IVA()
        Dim SQLCmd As SqlCommand
        Dim bd As New BDConexión.BDConexion
        Dim SQLConn As New SqlConnection(bd.connString)
        Dim SQLRdr As SqlDataReader
        Try
            SQLConn.Open()
            SQLCmd = New SqlCommand("SELECT CODIVA, DESIVA, PORCENTAJEIVA, COHEFICIENTE FROM dbo.IVA", SQLConn)
            SQLRdr = SQLCmd.ExecuteReader
            dt.Load(SQLRdr)
            SQLRdr.Close()
            SQLConn.Close()
        Catch
            SQLConn.Close()
        End Try
    End Sub

    Function CalcularIVA(origValue As Decimal, IVAfactor As Decimal)
        Dim answerIVA As Decimal = CDec(origValue)
        Return answerIVA
    End Function

End Class
