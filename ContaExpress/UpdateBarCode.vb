Imports System.Data.SqlClient

Public Class UpdateBarCode
    Dim conn As New SqlConnection("")

    Dim dtCodigos As New DataTable

    Private Sub btnExtraera_Click(sender As Object, e As EventArgs) Handles btnExtraer.Click
        Try
            Dim SQLcommand As New SqlCommand("SELECT CODCODIGO, CODPRODUCTO, CODIGO  FROM CODIGOS", conn)
            conn.Open()
            Dim drProv As SqlDataReader = SQLcommand.ExecuteReader()
            dtCodigos.Load(drProv)
            conn.Close()
            dgvProductView.DataSource = dtCodigos
        Catch ex As SqlException
            MessageBox.Show("Favor cargar Connection String")
        End Try

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        For Each r In dtCodigos.Rows
            Dim cod As String = r("CODIGO")
            Dim ean As Integer
            If ean = Nothing Then
                ' Dim codigoBarra As String
                r("CODIGO") = GeneraCodigodeBarra()
            End If
        Next
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim sql As String = String.Empty
        For Each r In dtCodigos.Rows
            Dim cod As String = r("CODIGO")
            Dim codcodigo As Integer = r("CODCODIGO")
            ' Dim codigoBarra As String
            sql = UpdateCodigodeBarra(cod, codcodigo) + sql
        Next
        Dim SQLcommand As New SqlCommand(sql, conn)
        conn.Open()
        SQLcommand.ExecuteScalar()
        conn.Close()
        MessageBox.Show("Proceso finalizado")
    End Sub

    Public Function GeneraCodigodeBarra()
        'Generacion del Codigo de Barra Formato EAN13 
        Dim CodPais As String
        Dim tamanho As Integer
        Dim result As String
        Dim first As Integer
        Dim check As Integer
        Dim digit As Integer
        Dim i As Integer
        Dim r As Integer

        CodPais = "569"  'Colocamos el codigo del pais correspondiente a Iceland , considreando que este pais no vende a Paraguay

        Dim Aleatorio = "000000001"   'Debemos generar 9 digitos de forma aleatoria, estos digitos corresponden a el codigo del producto y fabricante
        Dim Minimo = "1"
        Dim Maximo = "999999999"
        Dim CodigoExistente = 1 'Para que siempre entre al ciclo la primera ves

        Randomize() ' inicializar la semilla

        Do While CodigoExistente <> Nothing
            Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)

            'Se debe verificar que el codigo generado contenga 9 digitos.
            tamanho = Aleatorio.Length

            While (tamanho < 9)
                Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)
                tamanho = Aleatorio.Length
            End While

            'Se debe calcular el Digito de Comprobacion.
            Aleatorio = CodPais + Aleatorio
            result = Aleatorio.Substring(0, 1)
            first = Convert.ToInt32(result)
            check = first
            digit = 0
            i = 11

            Do While (i >= 1)
                digit = Convert.ToInt32(Aleatorio.Substring(i, 1))
                If i Mod 2 = 0 Then
                    r = 1
                Else
                    r = 3
                End If
                check = (check + (digit * (r)))
                i = (i - 1)
            Loop
            digit = ((10 - (check Mod 10)) Mod 10)

            'Concatenamos todo
            Aleatorio = Aleatorio + System.Convert.ToString(digit)

            'Verificamos si el codigo de barra ya existe en la base de datos
            Dim SQLcommand As New SqlCommand("SELECT CODIGO FROM CODIGOS WHERE CODIGO='" & Aleatorio & "'", conn)
            conn.Open()
            CodigoExistente = SQLcommand.ExecuteScalar()
            conn.Close()
        Loop
        Return Aleatorio
    End Function

    Private Function UpdateCodigodeBarra(cod As String, codcodigo As Integer)
        Return "UPDATE CODIGOS SET CODIGO = '" & cod & "' WHERE CODCODIGO = " & codcodigo
    End Function

    Private Sub rtbConn_TextChanged(sender As Object, e As EventArgs) Handles rtbConn.TextChanged
        If rtbConn.Text <> "" Then
            conn.ConnectionString = rtbConn.Text
        End If
    End Sub

End Class