Imports System.Data
Imports System.Data.SqlClient

Public Class Compras_Model

    Dim SQLCmd As SqlCommand
    Dim bd As New BDConexión.BDConexion
    Dim SQLConn As New SqlConnection(bd.connString)
    Dim SQLRdr As SqlDataReader

    Dim dt As New DataTable
    Public Property dataTable As DataTable
        Get
            Return dt
        End Get
        Set(value As DataTable)
            dt = value
        End Set
    End Property

    Sub load_Compras()
        Try
            SQLConn.Open()
            SQLCmd = New SqlCommand(" SELECT COMPRAS.CODCOMPRA, COMPRAS.NUMRESPONSABLE, COMPRAS.RES_CODEMPRESA, COMPRAS.CODMONEDA, " & _
                            " COMPRAS.CODUSUARIO, COMPRAS.CODEMPRESA, COMPRAS.CODSUCURSAL, COMPRAS.CODCOMPROBANTE, COMPRAS.CODPROVEEDOR, " & _
                            " COMPRAS.NUMCOMPRA AS NUMFACTURA, RTRIM(SUBSTRING(COMPRAS.NUMCOMPRA, LEN(COMPRAS.NUMCOMPRA) - 4, 5)) AS NUMCOMPRA, " & _
                            " COMPRAS.FECHACOMPRA, COMPRAS.TOTALEXENTA, COMPRAS.TOTALGRAVADA, CAST(ROUND(dbo.COMPRAS.TOTALIVA, 0) AS numeric(18, 0)) AS TOTALIVA, " & _
                            " CAST(ROUND(COMPRAS.TOTALCOMPRA / COMPRAS.COTIZACION1, 0) AS numeric(18, 0)) AS TOTALCOMPRA, COMPRAS.TOTALDESCUENTO, " & _
                            " COMPRAS.COTIZACION1, COMPRAS.COTIZACION2, COMPRAS.FECGRA, COMPRAS.ESTADO, COMPRAS.CODTIPOGASTODET, COMPRAS.MODALIDADPAGO, " & _
                            " COMPRAS.CODCENTRO, COMPRAS.BASEIMPONIBLE, CAST(ROUND(COMPRAS.TOTALIVA5 / COMPRAS.COTIZACION1, 0) AS numeric(18, 0)) AS TOTALIVA5," & _
                            " COMPRAS.IVAINCLUIDO, ISNULL(RTRIM(PROVEEDOR.NOMBRE), '') + ' ' + ISNULL(LTRIM(PROVEEDOR.APELLIDO), '') AS PROVEEDOR, " & _
                            " COMPRAS.COMPRASIMPLE, COMPRAS.METODO, COMPRAS.CODEVENTO, COMPRAS.CONCEPTO, COMPRAS.CODDEPOSITO, COMPRAS.MOTIVOANULADO, " & _
                            " PROVEEDOR.MASCARA, COMPRAS.TOTALGRAVADO10, COMPRAS.TOTALGRAVADO5, CAST(ROUND(COMPRAS.TOTALIVA10 / COMPRAS.COTIZACION1, 0) " & _
                            " AS numeric(18, 0)) AS TOTALIVA10, PROVEEDOR.NUMPROVEEDOR, COMPRAS.TIMBRADOPROV, COMPRAS.ORDCOMPRA, PROVEEDOR.DIASVENCIMIENTO, " & _
                            " PROVEEDOR.FECHAVTOTIMBRADO, COMPRAS.CODORDCOMPRA" & _
                            " FROM COMPRAS INNER JOIN" & _
                            " PROVEEDOR ON COMPRAS.CODPROVEEDOR = PROVEEDOR.CODPROVEEDOR" & _
                            " ORDER BY COMPRAS.FECHACOMPRA", SQLConn)
            '##abhi> removed bc i want to bring everything
            ''''" WHERE (ISNULL(RTRIM(PROVEEDOR.NOMBRE), '') + ' ' + ISNULL(LTRIM(PROVEEDOR.APELLIDO), '') LIKE @PROVEEDOR) AND " & _
            ''''" (COMPRAS.FECHACOMPRA >= CONVERT(datetime, @FECHA1, 103)) AND (COMPRAS.FECHACOMPRA <= CONVERT(datetime, @FECHA2, 103))" & _

            'Execute
            SQLRdr = SQLCmd.ExecuteReader
            dt.Load(SQLRdr)
            SQLRdr.Close()
            SQLConn.Close()
        Catch
            SQLConn.Close()
        End Try
    End Sub

    Sub update_Compra()
        'Dim Concatenar As String = FechaFactTextBox.Text & " " + Now.ToString("HH:mm:ss")
        'VCodCompra = ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value
        'Dim TipoIVA As Integer = IvaIncluidoComboBox.SelectedValue
        'Dim EstadoCompra As Integer = w.FuncionConsultaDecimal("ESTADO", "COMPRAS", "CODCOMPRA", CDec(tbxCodCompras.Text))
        Try
            SQLConn.Open()
            SQLCmd = New SqlCommand(" UPDATE COMPRAS set TOTALIVA = @TotalIVA," & _
                                    " TOTALIVA5 = @TotalIVA5, TOTALIVA10 = @TotalIVA10, " & _
                                    " TOTALGRAVADA = @TotalGravada, MODALIDADPAGO = @FormaPago ," & _
                                    " TOTALEXENTA = @TotalExenta, CODDEPOSITO = @CodDeposito ," & _
                                    " TOTALCOMPRA = @TotalCompra, CODSUCURSAL =  @CodSucursal ," & _
                                    " ESTADO = @EstadoCompra, CODUSUARIO = @CodUsuario ," & _
                                    " FECHACOMPRA = CONVERT(DATETIME, @FechaCompra, 103)," & _
                                    " CODCOMPROBANTE = @CodComprobante, CODPROVEEDOR = @CodProveedor," & _
                                    " NUMCOMPRA = @NroFacturaCompra, TOTALDESCUENTO = @TotalDescuento , " & _
                                    " CODMONEDA = @CodMoneda, COTIZACION1 = @Cotizacion, " & _
                                    " IVAINCLUIDO = @CodIVAIncluido, TOTALGRAVADO10 = @TotalGrav10 , TOTALGRAVADO5 = @TotalGrav5," & _
                                    " COMPRASIMPLE=0 ,CODEVENTO= @CodEvento, METODO= @Metodo, TIMBRADOPROV = @TimbradoProveedor " & _
                                    " WHERE CODCOMPRA = @CodCompra", SQLConn)
            '##abhi> parameters
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalIVA", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalIVA5", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalIVA10", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalGravada", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@FormaPago", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalExenta", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodDeposito", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalCompra", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodSucursal", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@EstadoCompra", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodUsuario", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@FechaCompra", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodComprobante", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodProveedor", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@NroFacturaCompra", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalDescuento", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodMoneda", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@Cotizacion", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodIVAIncluido", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalGrav10", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TotalGrav5", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodEvento", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@Metodo", ""))
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@TimbradoProveedor", ""))
            '#abhi> where parameters
            SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@CodCompra", ""))
            'Execute
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        Catch
            SQLConn.Close()
        End Try

    End Sub

    Sub modificar_NroFactura(id_compra As Integer)

    End Sub

    Function list_IVACalculoTipo()
        '##abhi> iva incluido o no.
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("name")
        dt.Rows.Add(1, "Incluido")
        dt.Rows.Add(0, "No Incluido")
        dt.Rows.Add(2, "Importacion")
        Return dt
    End Function

    Function list_TipoPago()
        '##abhi> modalidad de pago
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("name")
        dt.Rows.Add(0, "Contado")
        dt.Rows.Add(1, "Crédito")
        Return dt
    End Function


End Class
