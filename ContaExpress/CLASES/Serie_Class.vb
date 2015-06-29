Imports System.Data
Imports System.Data.SqlClient
Public Class serie_class

    Function Serie(id_Producto As String, DescripcionSerie_Actual As String)

        Dim CodSerie As String = ""

        Try
            'pregunta si descripcion producto tiene hashtag prefijos

            If DescripcionSerie_Actual.Contains("#") Then
                'Creamos un DataReader y este lo pasamos a un DataTable
                Dim bdConn As New BDConexión.BDConexion
                Dim dtSerie As New DataTable("PRODUCTO_SERIE")
                Dim dr As SqlDataReader
                Dim connString As New SqlConnection(bdConn.CadenaConexion)
                Dim sql As String = Nothing
                sql = " SELECT Id, Serie_desde, Serie_hasta, Serie_actual, Prefijo, Estado" & _
                      " FROM dbo.PRODUCTO_SERIE" & _
                      " WHERE (Id_producto = " & id_Producto & ") AND (Estado <> 2)"
                Dim SQLCmd As New SqlCommand(sql, connString)
                connString.Open()
                dr = SQLCmd.ExecuteReader(CommandBehavior.Default)
                dtSerie.Load(dr)
                connString.Close()

                'SI TIENE serie ingresa
                For Each row In dtSerie.Rows

                    Dim Serie_Desde As Integer = row("Serie_desde")
                    Dim Serie_Hasta As Integer = row("Serie_hasta")
                    Dim Serie_Actual As Integer = row("Serie_actual")
                    Dim Serie_Prefijo As String = row("Prefijo")
                    Dim Id As Integer = row("Id")

                    'BORRA TODO LO QUE VIENE DESPUES DEL HASHTAG
                    Dim HashIndex As Integer = DescripcionSerie_Actual.IndexOf("#")
                    If (HashIndex > 0) Then
                        DescripcionSerie_Actual = DescripcionSerie_Actual.Substring(0, HashIndex)
                    End If

                    'LE SUMAMOS MAS 1 A LA SERIE ACTUAL
                    If Serie_Actual <> Serie_Hasta Then
                        Serie_Actual = Serie_Actual + 1 'concatenamos el prefijo

                        CodSerie = Serie_Prefijo & Serie_Actual

                        Dim SqlString As String = "Update Producto_Serie set Serie_Actual='" & Serie_Actual & "' Where Id=" & Id
                        SQLCmd = New SqlCommand(SqlString, connString)
                        connString.Open()
                        SQLCmd.ExecuteNonQuery()
                        connString.Close()
                        Exit For

                    ElseIf Serie_Actual = Serie_Hasta Then
                        'Estado PASA A SER INACTIVO
                        'codigo de update para anular la serie en cuestion
                        Dim SqlString As String = "Update Producto_Serie Set Estado = 2 Where Id=" & Id
                        SQLCmd = New SqlCommand(SqlString, connString)
                        connString.Open()
                        SQLCmd.ExecuteNonQuery()
                        connString.Close()
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            '  connString.Close()
        End Try

        Return CodSerie
    End Function

End Class
