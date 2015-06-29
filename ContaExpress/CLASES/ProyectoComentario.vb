Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Module ProyectoComentario
    Private ser As BDConexión.BDConexion = New BDConexión.BDConexion
    Private cmd As SqlCommand = New SqlCommand
    Private sqlc As SqlConnection = New SqlConnection

    Public Sub InsertarProyecto(ByVal Comentario As String, ByVal CodEvento As Integer)
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
        Dim sql As String = ""

        ser.Abrir(sqlc)
        cmd.Connection = sqlc

        Try
            sql = "INSERT INTO COMENTARIOS(COMENTARIO,FECHA,CODUSUARIO,CODEVENTO)  " & _
                   "VALUES('" & Comentario & "',GETDATE()," & UsuCodigo & "," & CodEvento & ")"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try

        sqlc.Close()
    End Sub
End Module
