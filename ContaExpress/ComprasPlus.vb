Imports System
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Imports System.Data.Common
Imports System.Windows.Forms
Imports EnviaInformes
Imports BDConexión
Imports CrystalDecisions.Shared

Public Class CompraPlus

#Region "Fields"

    Dim Anho, TimbradoFactura As String
    Dim GlobalAutofactura As Integer
    Dim anu As Integer
    Private row As DataRow
    Dim dr2 As DataRow
    Dim NumAutoFactura As String
    Dim TipoImpresion, CantLinea, Imprimir As Integer
    Dim NroRango As Integer
    Dim RangoID As Decimal
    Dim impresora As String
    Private cmd As SqlCommand
    Dim CodProductoDetalle, CodIvaDetalle As Integer
    Dim CompraDetalleMonto, CompraDetalleCantidad, TipoIvaDetalle, TotalGravada10F, TotalGravada5F, TotalIva10F As String
    Dim del As Integer
    Dim NroFactura, CodigoABorrar As String
    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim EntradoGuardar As Boolean
    Dim EntradoModificar As Boolean
    Dim EntradoNuevo As Boolean
    Dim Existe As Integer
    Dim FechaFiltro1, FechaFiltro2 As String
    Dim FechaValida As Integer
    Dim IsServicio, PermisoIVA As Integer
    '***Variables de conexion usadas en la transaccion**********************
    'Dim filename As String
    Dim IndiceDetalleCompra As Integer
    Dim ins As Integer
    Dim IvaIncluido As Integer
    Dim LineaCompra As Integer
    Dim VCodCompra As Integer
    Dim vgDescuento As Integer
    Dim matricial As Integer
    Dim i As Integer

    'Dim monedadecimales As Integer
    '#################### Para el filtro de fechas ##############################
    Dim Mes As String
    Dim MonedaFactura, ProvFactura, CotizacioF1, CotizacionF2, TotalExentaF, TotalCompraF, TotalGravadaF, TotalIvaF, TotalIva5F, CodComprobanteF, EstadoCompra, TipoFactura, Evento, Metodo As String
    Private myTrans As SqlTransaction

    '#####################################################################
    Dim proveedorexterior As Integer

    'Para las Cuotas###########################################################
    Dim Frecuencia As Integer
    Dim cantidadcuotas As Integer

    '******************Formateo de Grilla ********************************************
    Dim Resultado As String
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Private sqlc As SqlConnection
    Dim ToolTip1 As New ToolTip()

    '*****************variables para guardar factura ******************
    Dim TotalFac As String
    Dim upd As Integer
    Dim w As New Funciones.Funciones
    Dim Nuevop As Boolean 'para saber si apreto nuevo
    Dim NroCompraGlobal As Double
    Dim EnlazadoProductos As Integer
    Dim btNuevo, btModificar, btaprobar, btcfcuota As Integer
    Dim permiso As Double
    Dim coheficiente As Double
    'Dim key As Integer
    Dim compra As Integer
    Dim timbradoActual As String
    Dim mascaraActual As String
    Dim proveedorActual As String
    Dim numeroProvActual As String
    Dim nombreProvActual As String
    Dim rucActualProv As String
    Dim VCodCentroCosto As Integer
    Dim VCodMoneda, DiasVto, PCantCuotas As Integer
    Dim VtoTimbrado As Date
    Dim KeyProv As Integer
    Dim f As New Funciones.Funciones
    Dim CodProductoCTextBox As Integer
    Dim CodCodigoCTextBox As Integer
    Dim CantDetalle As Integer
    Dim Config1, Config2, Config3, Config4, Config5, Config6, Config7, Config8, Config9, Config10, Config11, Config12 As String
    Dim nuevacuota As Integer = 0
    Dim errorFiltroFecha, errorfiltrorango As Integer
    Dim IsKeyPress As Integer = 0
    Dim dtIva As DataTable
    'Dim dtMoneda As DataTable
    Dim DuplicarContenido As Integer = 0
#End Region 'Fields

#Region "Constructors"

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

#End Region 'Constructors

#Region "Methods"

    Private Sub ActualizaCompra()
        Try
            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = FechaFactTextBox.Text
            Dim Concatenar As String = Concat & " " + hora
            Dim varBaseImponible As Integer = 0
            VCodCompra = ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

            If IvaIncluidoComboBox.Text = "No incluido" Then
                IvaIncluidoTextBox.Text = "0"
            ElseIf IvaIncluidoComboBox.Text = "Incluido" Then
                IvaIncluidoTextBox.Text = "1"
            ElseIf IvaIncluidoComboBox.Text = "Importacion" Then
                IvaIncluidoTextBox.Text = "2"
            End If

            If BaseImponible.Text = "" Or BaseImponible.Text = Nothing Then
                BaseImponible.Text = 0
            Else
                varBaseImponible = CDec(BaseImponible.Text)
                varBaseImponible = Funciones.Cadenas.QuitarCad(varBaseImponible, ".")
                varBaseImponible = Replace(varBaseImponible, ",", ".")
            End If

            Dim EstadoCompra As Integer = w.FuncionConsultaDecimal("ESTADO", "COMPRAS", "CODCOMPRA", CDec(tbxCodCompras.Text))

            sql = ""
            sql = sql + " UPDATE COMPRAS set TOTALIVA = " & TotalIvaF & "," & _
                    "TOTALIVA5 = " & TotalIva5F & ", " & _
                    "TOTALIVA10 = " & TotalIva10F & ", " & _
                    "TOTALGRAVADA = " & TotalGravadaF & ", MODALIDADPAGO = " & ModalidadPagoFacturaTextBox.Text & " ," & _
                    "TOTALEXENTA = " & TotalExentaF & ", CODDEPOSITO = " & CmbDeposito.SelectedValue & " ," & _
                    "TOTALCOMPRA = " & TotalFac & ", CODSUCURSAL =  " & SucCodigo & " ," & _
                    "ESTADO = " & EstadoCompra & ", CODUSUARIO = " & UsuCodigo & " ," & _
                    "FECHACOMPRA = CONVERT(DATETIME, '" & Concatenar & "', 103)," & _
                    "CODCOMPROBANTE = " & CodComprobanteF & ", " & _
                    "CODPROVEEDOR = " & ProvFactura & "," & _
                    "NUMCOMPRA = '" & NroFactura & "', " & _
                    "TOTALDESCUENTO = '" & vgDescuento & " ' , TIMBRADOPROV = '" & txtTimbrado.Text & " ' , " & _
                    "CODMONEDA = " & MonedaFactura & ", COTIZACION1 = " & CotizacioF1 & ", " & _
                    "IVAINCLUIDO = " & IvaIncluidoTextBox.Text & ", TOTALGRAVADO10 = " & TotalGravada10F & ",TOTALGRAVADO5 = " & TotalGravada5F & _
                    ", COMPRASIMPLE=0,CODEVENTO=" & Evento & ",METODO='" & Me.cbxMetodo.Text & "', BASEIMPONIBLE = " & varBaseImponible & " " & _
                    "WHERE CODCOMPRA = " & VCodCompra & ""

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            compra = VCodCompra

        Catch ex As Exception
            MessageBox.Show("Problema al Actualizar la Compra: " + ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ActualizaDetalleCompra()
        Dim Existe, CodCentroFactura, CodFactura, LineaNro, DesProductoFactura, CostoFactura, _
        MontoFactura, CantidadFactura, CodCodigoFactura, CodProductoFactura, _
        IvaFactura, Iva5, Iva10, Exento, ImporteGravado5, ImporteGravado10, TipoIvaDet As String

        Dim c As Integer = DetalleCompraGridView.RowCount

        'PRIMERO VERIFICAMOS SI SE ELIMINARON FILAS EXISTENTES ANTERIORMENTE EN LA BD Y LAS ELIMINAMOS DE LA BD
        If CodigoABorrar <> "" Then
            CodigoABorrar = Mid(CodigoABorrar, 1, CodigoABorrar.Length - 1)
            sql = ""
            sql = "delete COMPRASDETALLE where ComprasDetalleID in(" & CodigoABorrar & ")"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        End If
        Dim i As Integer
        For i = 1 To c
            LineaNro = DetalleCompraGridView.Rows(i - 1).Cells("LINEANROCOMPRA").Value
            If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("CODCOMPRA2").Value) Then
                CodFactura = "NULL"
            Else
                CodFactura = DetalleCompraGridView.Rows(i - 1).Cells("CODCOMPRA2").Value
            End If

            If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("DESPRODUCTO").Value) Then
                DesProductoFactura = ""
            Else
                DesProductoFactura = DetalleCompraGridView.Rows(i - 1).Cells("DESPRODUCTO").Value
            End If

            If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("COSTOUNITARIO").Value) Then
                CostoFactura = "NULL"
            Else
                CostoFactura = DetalleCompraGridView.Rows(i - 1).Cells("COSTOUNITARIO").Value
                CostoFactura = Funciones.Cadenas.QuitarCad(CostoFactura, ".")
                CostoFactura = Replace(CostoFactura, ",", ".")
            End If

            Try
                If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO5").Value) Then
                    Iva5 = "0"
                Else
                    Iva5 = DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO5").Value
                    If Iva5 = Nothing Then
                        Iva5 = "0"
                    End If
                    Iva5 = Funciones.Cadenas.QuitarCad(Iva5, ".")
                    Iva5 = Replace(Iva5, ",", ".")
                End If
            Catch ex As Exception
                Iva5 = "0"
            End Try

            Try
                If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO10").Value) Then
                    Iva10 = "0"
                Else
                    Iva10 = DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO10").Value
                    Iva10 = Funciones.Cadenas.QuitarCad(Iva10, ".")
                    Iva10 = Replace(Iva10, ",", ".")
                End If
            Catch ex As Exception
                Iva10 = "0"
            End Try

            Try
                If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("SUBTOTAL").Value) Then
                    MontoFactura = "0"
                Else
                    MontoFactura = DetalleCompraGridView.Rows(i - 1).Cells("SUBTOTAL").Value
                    MontoFactura = Funciones.Cadenas.QuitarCad(MontoFactura, ".")
                    MontoFactura = Replace(MontoFactura, ",", ".")
                End If
            Catch ex As Exception
                MontoFactura = "0"
            End Try

            If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("CANTIDADCOMPRA").Value) Then
                CantidadFactura = "NULL"
            Else
                CantidadFactura = DetalleCompraGridView.Rows(i - 1).Cells("CANTIDADCOMPRA").Value
                CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                CantidadFactura = Replace(CantidadFactura, ",", ".")
            End If

            If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("CODPRODUCTO").Value) Then
                CodProductoFactura = "NULL"
            Else
                CodProductoFactura = DetalleCompraGridView.Rows(i - 1).Cells("CODPRODUCTO").Value
            End If

            If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("CODCODIGO").Value) Then
                CodCodigoFactura = "NULL"
            Else
                CodCodigoFactura = DetalleCompraGridView.Rows(i - 1).Cells("CODCODIGO").Value
            End If

            If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("CODCENTRO").Value) Then
                CodCentroFactura = "NULL"
            Else
                CodCentroFactura = DetalleCompraGridView.Rows(i - 1).Cells("CODCENTRO").Value
            End If

            If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("IVA").Value) Then
                TipoIvaDet = "NULL"
            Else
                TipoIvaDet = DetalleCompraGridView.Rows(i - 1).Cells("IVA").Value
                TipoIvaDet = Funciones.Cadenas.QuitarCad(TipoIvaDet, ".")
                TipoIvaDet = Replace(TipoIvaDet, ",", ".")
            End If

            If Iva10 <> "0" Then
                IvaFactura = Iva10
                ImporteGravado10 = MontoFactura
            Else
                IvaFactura = "0"
                ImporteGravado10 = "0"
            End If

            If Iva5 <> "0" Then
                IvaFactura = Iva5
                ImporteGravado5 = MontoFactura
            Else
                IvaFactura = "0"
                ImporteGravado5 = "0"
            End If

            If Iva10 = "0" And Iva5 = "0" Then
                Exento = MontoFactura
            Else
                Exento = "0"
            End If

            '############################################################################
            'preguntamos si existe el detalle para saber si actualizar o insertar
            'Existe = DetalleCompraGridView.Rows(i - 1).Cells("EstadoFila").Value
            Existe = w.FuncionConsulta("ComprasDetalleID", "COMPRASDETALLE", "CODCOMPRA = " & compra & " AND ComprasDetalleID ", DetalleCompraGridView.Rows(i - 1).Cells("ComprasDetalleID").Value)

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = FechaFactTextBox.Text
            Dim Concatenar As String = Concat & " " + hora

            If Existe <> 0 Then
                sql = ""
                sql = "UPDATE COMPRASDETALLE set " & _
                "IMPORTEEXENTO = " & Exento & "," & _
                "IMPORTEGRAVADO10 = " & ImporteGravado10 & "," & _
                "IMPORTEGRAVADO5 = " & ImporteGravado5 & ", " & _
                "CODPRODUCTO = " & CodProductoFactura & ", " & _
                "CODCODIGO = " & CodCodigoFactura & ", " & _
                "CANTIDADCOMPRA = " & CantidadFactura & ", " & _
                "COSTOUNITARIO = " & CostoFactura & ", " & _
                "IVA = " & TipoIvaDet & ", CODCENTRO = " & CodCentroFactura & "," & _
                "DESPRODUCTO = '" & Replace(DesProductoFactura, "'", "''") & "'  WHERE CODCOMPRA = " & compra & " AND LINEANROCOMPRA = " & LineaNro & "  "
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

            Else
                sql = ""

                'If CodCodigoCompraTextBox.Enabled = True Then
                sql = "INSERT INTO COMPRASDETALLE (IMPORTEEXENTO, IMPORTEGRAVADO10, IMPORTEGRAVADO5, FECGRA, CODCOMPRA, " & _
               "LINEANROCOMPRA, CODPRODUCTO, CODCODIGO, CANTIDADCOMPRA, COSTOUNITARIO, IVA, CODCENTRO, DESPRODUCTO, CODSUCURSAL, TIPOIVA) VALUES " & _
               "(" & Exento & ", " & ImporteGravado10 & "," & ImporteGravado5 & ",  CONVERT(DATETIME, '" & Concatenar & "', 103), " & _
               "" & compra & ", " & LineaNro & ", " & CodProductoFactura & ", " & CodCodigoFactura & ", " & CantidadFactura & ", " & CostoFactura & "," & _
               "" & TipoIvaDet & ", " & CodCentroFactura & ", '" & Replace(DesProductoFactura, "'", "''") & "'," & SucCodigo & ", '" & TipoIvaDet & "' )  "

                If CodProductoFactura <> "NULL" Then
                    sql = sql + "UPDATE PRODUCTOS SET ULTIMOCOSTO=" & CostoFactura & " WHERE CODPRODUCTO=" & CodProductoFactura & " "
                End If


                'Else
                '    sql = "INSERT INTO COMPRASDETALLE " & _
                '  "(IMPORTEEXENTO, IMPORTEGRAVADO10," & _
                '  "IMPORTEGRAVADO5, FECGRA, CODCOMPRA, " & _
                '  "LINEANROCOMPRA, " & _
                '  "CANTIDADCOMPRA, COSTOUNITARIO, IVA, " & _
                '  "CODCENTRO, DESPRODUCTO, CODSUCURSAL," & _
                '  "TIPOIVA) VALUES " & _
                '  "(" & Exento & ", " & ImporteGravado10 & "," & _
                '  "" & ImporteGravado5 & ",  CONVERT(DATETIME, '" & Concatenar & "', 103), " & _
                '  "" & compra & ", " & LineaNro & ", " & CantidadFactura & ", " & CostoFactura & "," & _
                '  "" & TipoIvaDet & ", " & CodCentroFactura & ", '" & Replace(DesProductoFactura, "'", "''") & "'," & _
                '  "" & SucCodigo & ", '" & TipoIvaDet & "' )  "

                'End If

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub InsertarDetalleCompra()
        Try
            Dim CodCentroFactura, CodFactura, LineaNro, DesProductoFactura, CostoFactura, _
            MontoFactura, CantidadFactura, CodCodigoFactura, CodProductoFactura, _
            IvaFactura, Iva5, Iva10, Exento, ImporteGravado5, ImporteGravado10, TipoIvaDet As String
            Dim i As Integer

            For i = 0 To CantDetalle - 1
                LineaNro = DetalleCompraGridView.Rows(i).Cells("LINEANROCOMPRA").Value
                If IsDBNull(DetalleCompraGridView.Rows(i).Cells("CODCOMPRA2").Value) Then
                    CodFactura = "Null"
                Else
                    CodFactura = DetalleCompraGridView.Rows(i).Cells("CODCOMPRA2").Value
                End If

                If IsDBNull(DetalleCompraGridView.Rows(i).Cells("DESPRODUCTO").Value) Then
                    DesProductoFactura = ""
                Else
                    DesProductoFactura = DetalleCompraGridView.Rows(i).Cells("DESPRODUCTO").Value
                End If

                If IsDBNull(DetalleCompraGridView.Rows(i).Cells("COSTOUNITARIO").Value) Then
                    CostoFactura = "Null"
                Else
                    CostoFactura = DetalleCompraGridView.Rows(i).Cells("COSTOUNITARIO").Value * CDec(tbxCompraCotizacion.Text)
                    CostoFactura = Funciones.Cadenas.QuitarCad(CostoFactura, ".")
                    CostoFactura = Replace(CostoFactura, ",", ".")
                End If

                Try
                    If IsDBNull(DetalleCompraGridView.Rows(i).Cells("IMPORTEGRAVADO5").Value) Then
                        Iva5 = "0"
                    Else
                        Iva5 = DetalleCompraGridView.Rows(i).Cells("IMPORTEGRAVADO5").Value * CDec(tbxCompraCotizacion.Text)
                        If Iva5 = Nothing Then
                            Iva5 = "0"
                        End If
                        Iva5 = Funciones.Cadenas.QuitarCad(Iva5, ".")

                        Iva5 = Replace(Iva5, ",", ".")
                    End If
                Catch ex As Exception
                    Iva5 = "0"
                End Try

                Try
                    If IsDBNull(DetalleCompraGridView.Rows(i).Cells("IMPORTEGRAVADO10").Value) Then
                        Iva10 = "0"
                    Else
                        Iva10 = DetalleCompraGridView.Rows(i).Cells("IMPORTEGRAVADO10").Value * CDec(tbxCompraCotizacion.Text)
                        Iva10 = Funciones.Cadenas.QuitarCad(Iva10, ".")
                        Iva10 = Replace(Iva10, ",", ".")
                    End If
                Catch ex As Exception
                    Iva10 = "0"
                End Try

                Try
                    If IsDBNull(DetalleCompraGridView.Rows(i).Cells("SUBTOTAL").Value) Then
                        MontoFactura = "0"
                    Else
                        MontoFactura = DetalleCompraGridView.Rows(i).Cells("SUBTOTAL").Value * CDec(tbxCompraCotizacion.Text)
                        MontoFactura = Funciones.Cadenas.QuitarCad(MontoFactura, ".")
                        MontoFactura = Replace(MontoFactura, ",", ".")
                    End If
                Catch ex As Exception
                    MontoFactura = "0"
                End Try

                If IsDBNull(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value) Then
                    CantidadFactura = "Null"
                Else
                    CantidadFactura = DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value
                    CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                    CantidadFactura = Replace(CantidadFactura, ",", ".")
                End If

                If IsDBNull(DetalleCompraGridView.Rows(i).Cells("CODPRODUCTO").Value) Then
                    CodProductoFactura = "Null"
                Else
                    CodProductoFactura = DetalleCompraGridView.Rows(i).Cells("CODPRODUCTO").Value
                End If

                If IsDBNull(DetalleCompraGridView.Rows(i).Cells("CODCODIGO").Value) Then
                    CodCodigoFactura = "null"
                Else
                    CodCodigoFactura = DetalleCompraGridView.Rows(i).Cells("CODCODIGO").Value
                End If

                If IsDBNull(DetalleCompraGridView.Rows(i).Cells("CODCENTRO").Value) Then
                    CodCentroFactura = "Null"
                Else
                    CodCentroFactura = DetalleCompraGridView.Rows(i).Cells("CODCENTRO").Value
                End If

                If IsDBNull(DetalleCompraGridView.Rows(i).Cells("IVA").Value) Then
                    TipoIvaDet = "Null"
                Else
                    TipoIvaDet = DetalleCompraGridView.Rows(i).Cells("IVA").Value
                    TipoIvaDet = Funciones.Cadenas.QuitarCad(TipoIvaDet, ".")
                    TipoIvaDet = Replace(TipoIvaDet, ",", ".")
                End If

                If Iva10 <> "0" Then
                    IvaFactura = Iva10
                    ImporteGravado10 = MontoFactura
                Else
                    IvaFactura = "0"
                    ImporteGravado10 = "0"
                End If

                If Iva5 <> "0" Then
                    IvaFactura = Iva5
                    ImporteGravado5 = MontoFactura
                Else
                    IvaFactura = "0"
                    ImporteGravado5 = "0"
                End If

                If Iva10 = "0" And Iva5 = "0" Then
                    Exento = MontoFactura
                Else
                    Exento = "0"
                End If

                'GLOBALESSSSSSSSSSS
                If UsuCodigo = Nothing Then
                    UsuCodigo = 1
                End If
                If EmpCodigo = Nothing Then
                    EmpCodigo = 1
                End If
                If SucCodigo = Nothing Then
                    SucCodigo = 1
                End If
                Dim hora As String = Now.ToString("HH:mm:ss")
                Dim Concat As String = FechaFactTextBox.Text
                Dim Concatenar As String = Concat & " " + hora
                sql = ""
                sql = "insert into COMPRASDETALLE " & _
                "(IMPORTEEXENTO, IMPORTEGRAVADO10," & _
                "IMPORTEGRAVADO5, FECGRA, CODCOMPRA, " & _
                "LINEANROCOMPRA, CODPRODUCTO, CODCODIGO, " & _
                "CANTIDADCOMPRA, COSTOUNITARIO, IVA, " & _
                "CODCENTRO, DESPRODUCTO, CODSUCURSAL," & _
                "TIPOIVA) VALUES " & _
                "(" & Exento & ", " & ImporteGravado10 & "," & _
                "" & ImporteGravado5 & ",  CONVERT(DATETIME, '" & Concatenar & "', 103), " & _
                "" & compra & ", " & LineaNro & ", " & CodProductoFactura & ", " & _
                "" & CodCodigoFactura & ", " & CantidadFactura & ", " & CostoFactura & "," & _
                "" & TipoIvaDet & ", " & CodCentroFactura & ", '" & Replace(DesProductoFactura, "'", "''") & "'," & _
                "" & SucCodigo & ", '" & TipoIvaDet & "' )  "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

            Next
        Catch ex As Exception
            MessageBox.Show("Problema al guardar el Detalle de la Compra:" + ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub ActualizaFacturaPagarContado()
        Dim Existe As Integer
        Dim total, saldo, Pagado As String

        If String.IsNullOrEmpty(TotalTextBox1.Text) Then
            total = 0
        Else
            total = CDec(TotalTextBox1.Text)
            total = Funciones.Cadenas.QuitarCad(total, ".")
            total = Replace(total, ",", ".")
        End If

        Existe = w.FuncionConsulta("NUMEROCUOTA", "FACTURAPAGAR", "NUMEROCUOTA = 1 AND CODCOMPRA", CodCompraTextBox.Text)

        If Config3 = "No Generar Saldo" Then
            saldo = "0"
            Pagado = "1"
        Else
            saldo = total
            Pagado = "0"
        End If

        If Existe = 0 Then
            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concatenar As String = Today & " " + hora
            sql = " INSERT INTO FACTURAPAGAR (NUMEROCUOTA,CODUSUARIO, CODEMPRESA,CODCOMPRA,FECHAVCTO, SALDOCUOTA,IMPORTECUOTA,FECGRA,PAGADO,DESTIPOPAGO,TIPOFACTURA, COTIZACION) " & _
            "VALUES ( 1," & UsuCodigo & "," & EmpCodigo & " , " & CDec(CodCompraTextBox.Text) & ",CONVERT(DATETIME, '" & Concatenar & "', 103) " & _
            "," & saldo & " ," & total & ",GETDATE()," & Pagado & ",'Efectivo','CONTADO', " & CInt(tbxCompraCotizacion.Text) & " ) "
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Else
            sql = " UPDATE FACTURAPAGAR SET IMPORTECUOTA= " & total & ",SALDOCUOTA= " & saldo & ",PAGADO=" & Pagado & ", COTIZACION = " & CInt(tbxCompraCotizacion.Text) & " " & _
            " WHERE NUMEROCUOTA=1 AND CODCOMPRA= " & CDec(CodCompraTextBox.Text) & " "
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub AgregarDetOrdenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            If TipoIvaComboBox.Text = "" Then
                MessageBox.Show("Antes de agregar el Detalle debe Seleccionar el Iva del Producto/Servicio", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TipoIvaComboBox.Focus()
                Exit Sub
            End If
            If ProvFactComboBox.Text = "" Then
                MessageBox.Show("Antes de agregar el Detalle debe Seleccionar el Proveedor", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ProvFactComboBox.Focus()
                Exit Sub
            End If
            '############validamos##############
            If IvaIncluidoComboBox.Text = "" Then
                MessageBox.Show("Elija si la Factura es Iva Incluido o No", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                IvaIncluidoComboBox.Focus()
                Exit Sub
            End If

            If CodCompraTextBox.Text = "" Then
                MessageBox.Show("Seleccione la Factura o cree una nueva", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DesProdComTextBox.Text = "" Then
                MessageBox.Show("Ingrese una Descripción para el Detalle", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DesProdComTextBox.Focus()
                Exit Sub
            End If

            'valida el valor en cantidad
            If String.IsNullOrEmpty(CantidadComTextBox1.Text) Then
                MessageBox.Show("Ingrese la Cantidad para el nuevo detalle", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CantidadComTextBox1.Focus()
                Exit Sub
            Else
                If CDec(CantidadComTextBox1.Text) = 0 Then
                    MessageBox.Show("Ingrese una cantidad mayor a cero", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CantidadComTextBox1.Focus()
                    Exit Sub
                End If
            End If
            'valida el valor en costo
            If String.IsNullOrEmpty(CostoComTextBox1.Text) Then
                MessageBox.Show("Ingrese el precio para el nuevo detalle", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CostoComTextBox1.Focus()
                Exit Sub
            Else
                If CDec(CostoComTextBox1.Text) = 0 Then
                    MessageBox.Show("Ingrese un precio mayor a cero", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CostoComTextBox1.Focus()
                    Exit Sub
                End If
            End If

            If cbxComprasMoneda.Text = "" Then
                MessageBox.Show("Seleccione la Moneda y  Cotizacion", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxComprasMoneda.BackColor = Color.Pink
                cbxComprasMoneda.Focus()
                Exit Sub
            End If

            If tbxCompraCotizacion.Text = "" Or tbxCompraCotizacion.Text = "0" Then
                MessageBox.Show("La Cotización ingresada debe ser mayor a Cero", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                IngresarCotCheckBox.Checked = True
                tbxCompraCotizacion.BackColor = Color.Pink
                tbxCompraCotizacion.Focus()
                Exit Sub
            End If
            If GlobalAutofactura = 1 Then 'Or IvaIncluidoTextBox.Text = "2" 
                TipoIvaComboBox.Text = "0,00"
            End If

            If btnAgregar.Text = "Modificar" Then
                'primero eliminamos el detalle para luego volverlo a cargar
                If btNuevo = 1 Then
                    DetalleCompraGridView.Rows.Remove(Me.DetalleCompraGridView.CurrentRow)
                Else
                    If IsDBNull(DetalleCompraGridView.CurrentRow) Then
                        MessageBox.Show("Seleccione la Fila a Eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        If btModificar = 1 Then
                            If DetalleCompraGridView.CurrentRow.Cells("ComprasDetalleID").Value > 0 Then 'Quiere decir que es un detalle ya grabado en la BD
                                CodigoABorrar = DetalleCompraGridView.CurrentRow.Cells("ComprasDetalleID").Value.ToString + ","
                            End If
                        End If
                    End If

                    Try
                        DetalleCompraGridView.Rows.Remove(Me.DetalleCompraGridView.CurrentRow)
                    Catch ex As Exception
                        MessageBox.Show("Problema al Eliminar: " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End Try
                End If
            End If

            COMPRASDETALLEBindingSource.AddNew()
            Dim c As Integer = DetalleCompraGridView.RowCount

            If EnlazadoProductos = 1 Then
                'SE ESTA INGRESANDO UN PRODUCTO DE BD
                DetalleCompraGridView.Rows(c - 1).Cells("CODIGOPROD").Value = CodCodigoCompraTextBox.Text
                DetalleCompraGridView.Rows(c - 1).Cells("CODPRODUCTO").Value = CodProductoCTextBox
                DetalleCompraGridView.Rows(c - 1).Cells("CODCODIGO").Value = CodCodigoCTextBox
                DetalleCompraGridView.Rows(c - 1).Cells("IVA").Value = CDec(TipoIvaComboBox.Text)
                DetalleCompraGridView.Rows(c - 1).Cells("DESPRODUCTO").Value = DesProdComTextBox.Text
            Else
                'SE ESTA INGRESANDO UN PRODUCTO/SERVICIO QUE NO ESTA EN BD
                DetalleCompraGridView.Rows(c - 1).Cells("DESPRODUCTO").Value = DesProdComTextBox.Text
                DetalleCompraGridView.Rows(c - 1).Cells("IVA").Value = TipoIvaComboBox.Text
            End If

            DetalleCompraGridView.Rows(c - 1).Cells("DESCENTRO").Value = cbxCdC.Text
            DetalleCompraGridView.Rows(c - 1).Cells("CODCENTRO").Value = cbxCdC.SelectedValue
            DetalleCompraGridView.Rows(c - 1).Cells("CANTIDADCOMPRA").Value = CDec(CantidadComTextBox1.Text)
            DetalleCompraGridView.Rows(c - 1).Cells("TIPOIVA").Value = TipoIvaComboBox.Text
            DetalleCompraGridView.Rows(c - 1).Cells("EstadoFila").Value = 1
            DetalleCompraGridView.Rows(c - 1).Cells("Simbolo").Value = lblSimboloPrecio.Text

            If btnAgregar.Text = "Modificar" Then
                DetalleCompraGridView.Rows(c - 1).Cells("LINEANROCOMPRA").Value = IndiceDetalleCompra
            Else
                DetalleCompraGridView.Rows(c - 1).Cells("LINEANROCOMPRA").Value = c
            End If

            Dim cantidad As String = DetalleCompraGridView.Rows(c - 1).Cells("CANTIDADCOMPRA").Value
            Dim costo As Double = CDec(CostoComTextBox1.Text)
            Dim Iva As Double = 0

            If IvaIncluidoComboBox.Text = "No Incluido" Then
                costo = costo * coheficiente
            End If

            DetalleCompraGridView.Rows(c - 1).Cells("COSTOUNITARIO").Value = costo
            Dim subtotal As Double = (CDec(cantidad) * CDec(costo))

            If TipoIvaComboBox.Text = "5,00" Or TipoIvaComboBox.Text = "5" Then
                DetalleCompraGridView.Rows(c - 1).Cells("IMPORTEGRAVADO5").Value = subtotal
            ElseIf TipoIvaComboBox.Text = "10,00" Or TipoIvaComboBox.Text = "10" Then
                DetalleCompraGridView.Rows(c - 1).Cells("IMPORTEGRAVADO10").Value = subtotal
            ElseIf TipoIvaComboBox.Text = "0,00" Or TipoIvaComboBox.Text = "0" Then
                DetalleCompraGridView.Rows(c - 1).Cells("IMPORTEEXENTO").Value = subtotal
            End If
            DetalleCompraGridView.Rows(c - 1).Cells("SUBTOTAL").Value = subtotal

            RecalcularIVA() 'saul

            CodCodigoCompraTextBox.Text = "" : CantidadComTextBox1.Text = "" : CostoComTextBox1.Text = "" : DesProdComTextBox.Text = "" : TipoIvaComboBox.Text = ""
            CODIGOSBindingSource.RemoveFilter()
            CodCodigoCompraTextBox.Focus()

            'ordenamos la grilla - Por un error inexplicable o por algun tipo de poltergeist que tiene esta ventana si es el primer registro no ordena , por eso se hace esta verificacion
            If ComprasSimpleGridView1.Rows.Count <> 1 Then
                DetalleCompraGridView.Sort(DetalleCompraGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If

        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try

        btnEliminar.Text = "Eliminar" : btnAgregar.Text = "Agregar"
        lblMensajeInteractivo.Text = ""
    End Sub

    Private Sub BtnCancelaCuota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PanelCuota.Visible = False
    End Sub

    Private Sub BtnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        tsFiltroFechaE.Text = "" : tsFiltroRDesde.Text = "" : tsFiltroRHasta.Text = "" : tsFiltroNroProv.Text = "" : tsFiltroNomProv.Text = ""
        COMPRASBindingSource.RemoveFilter()

        If rbtvertodo.Checked = True Then
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If
        If rbtverOC.Checked = True Then
            rbtverOC_CheckedChanged(Nothing, Nothing)
        End If
        If rbtVerfacturas.Checked = True Then
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnPagosGenerarCuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagosGenerarCuotas.Click
        If GridViewCuotas.Rows.Count > 0 Then
            MessageBox.Show("Cancele las cuotas para volver a generar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(tbxCantidadPagos.Text) Then
            MessageBox.Show("Ingrese una cantidad de cuota correcta", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxCantidadPagos.Focus()
            Exit Sub
        ElseIf CDec(tbxCantidadPagos.Text) = 0 Then
            MessageBox.Show("Ingrese una cantidad mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxCantidadPagos.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(tbxPagoDias.Text) Then
            MessageBox.Show("Ingrese una cantidad de dias correcta", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxPagoDias.Focus()
            Exit Sub
        ElseIf CDec(tbxPagoDias.Text) = 0 Then
            MessageBox.Show("Ingrese una cantidad mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxPagoDias.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TotalTextBox1.Text) Then
            MessageBox.Show("No se ingresaron items detalles para calcular la cuota", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf CDec(TotalTextBox1.Text) = 0 Then
            MessageBox.Show("No se ingresaron items detalles para calcular la cuota", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        GeneraCuotas()
        btGuardarCuotas.Focus()
    End Sub

    Private Sub GeneraCuotas()
        Dim i As Integer
        Dim Impcuo As Decimal
        Dim Totalimporte As Decimal = 0

        cantidadcuotas = CInt(tbxCantidadPagos.Text)
        Frecuencia = tbxPagoDias.Text

        Impcuo = CDec(TotalTextBox1.Text)
        Impcuo = Math.Round(Impcuo / cantidadcuotas, 0)
        dttFechaPrimeraCuota.Text = dttFechaPrimeraCuota.Value.AddDays(Frecuencia)

        For i = 1 To cantidadcuotas
            FACTURAPAGARBindingSource.AddNew()
            Dim c As Integer = GridViewCuotas.RowCount
            If c > 0 Then
                'grilla tradicional
                Dim fecha As Date
                If i = 1 Then
                    fecha = dttFechaPrimeraCuota.Text
                Else
                    fecha = fecha.AddDays(Frecuencia)
                End If

                GridViewCuotas.Rows(c - 1).Cells("NUMEROCUOTADataGridViewTextBoxColumn").Value = i
                GridViewCuotas.Rows(c - 1).Cells("CODCOMPRADataGridViewTextBoxColumn1").Value = CDec(Me.CodCompraTextBox.Text)
                GridViewCuotas.Rows(c - 1).Cells("FECHAVCTODataGridViewTextBoxColumn").Value = fecha.ToShortDateString
                If i = cantidadcuotas Then
                    Impcuo = CDec(TotalTextBox1.Text)
                    Impcuo = Math.Round(Impcuo - Totalimporte, 2)
                End If
                GridViewCuotas.Rows(c - 1).Cells("IMPORTECUOTADataGridViewTextBoxColumn").Value = Impcuo
                GridViewCuotas.Rows(c - 1).Cells("SALDOCUOTADataGridViewTextBoxColumn").Value = Impcuo
                GridViewCuotas.Rows(c - 1).Cells("DESTIPOPAGODataGridViewTextBoxColumn").Value = "EFECTIVO"
                GridViewCuotas.Rows(c - 1).Cells("TIPOFACTURADataGridViewTextBoxColumn").Value = "CREDITO"

                Totalimporte = Totalimporte + Impcuo
            End If
        Next
    End Sub

    Private Sub LimpiaPagoCuota()
        tbxCantidadPagos.Text = ""
        tbxPagoDias.Text = ""
    End Sub

    Private Sub BtnGuardarCuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            'ActualizaCuotas()
            myTrans.Commit()
            FACTURAPAGARTableAdapter.Fill(DsPagos.FACTURAPAGAR)
            PanelCuota.Visible = False
        Catch ex As SqlException
            Dim NroError As Integer = ex.Number
            Dim Mensaje As String = ex.Message
            myTrans.Rollback("Actualizar")
            MessageBox.Show("Problema al guardar las cuotas" + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub BuscarCompraTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarCompraTextBox.GotFocus
        BuscarCompraTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarCompraTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarCompraTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ComprasSimpleGridView1.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub BuscarCompraTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarCompraTextBox.LostFocus
        BuscarCompraTextBox.BackColor = Color.Tan
    End Sub

    Private Sub BuscarCompraTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarCompraTextBox.TextChanged
        Try
            Me.COMPRASBindingSource.Filter = "PROVEEDOR LIKE '%" & BuscarCompraTextBox.Text & "%' OR NUMCOMPRA LIKE '%" & BuscarCompraTextBox.Text & "%'"
            lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
            PintarCeldas()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BusCodigoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BusCodigoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProdGridView1.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub BusCodigoTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BusCodigoTextBox.LostFocus
        'If BusCodigoTextBox.Text = "" Then
        '    BusCodigoTextBox.Text = "Buscar..."
        'End If
    End Sub

    Private Sub BusCodigoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BusCodigoTextBox.TextChanged
        '  If BusCodigoTextBox.Text <> "Buscar..." Then
        CODIGOSBindingSource.Filter = "CODIGO LIKE '%" & BusCodigoTextBox.Text & "%' OR DESPRODUCTO LIKE '%" & BusCodigoTextBox.Text & "%'"
        '  End If
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        COMPRASBindingSource.CancelEdit()
        COMPRASDETALLEBindingSource.CancelEdit()
        pnlDescuento.SendToBack()

        FechaFiltro()

        lblTextoOrd.Text = "Nº Ord Compra:"
        lblTextoOrd.Visible = False
        txtTimbrado.BackColor = SystemColors.GradientInactiveCaption

        btnAgregar.Text = "Agregar" : btnEliminar.Text = "Eliminar"
        RecorreDetalleCompra2()

        txtEstado_TextChanged(Nothing, Nothing)
        If ComprasSimpleGridView1.RowCount = 0 Then
            txtEstado.Text = "0"
        End If

        Me.PanelRedondeo.Visible = False : Me.tbxRedondeo.Text = ""
        ComprasSimpleGridView1.Enabled = True
        btNuevo = 0 : btModificar = 0 : CodigoABorrar = ""

        Limpiarcompra()

        If Config9 = "Ver Ordenes de Compra" Then
            rbtverOC.Checked = True
            rbtverOC_CheckedChanged(Nothing, Nothing)
        ElseIf Config9 = "Ver Facturas" Then
            rbtVerfacturas.Checked = True
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)
        Else
            rbtvertodo.Checked = True
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If

        ComprasSimpleGridView1_SelectionChanged(False, New System.EventArgs)
        Deshabilitamos()
    End Sub

    Private Sub CantidadComTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadComTextBox1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CostoComTextBox1.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub CCostoComComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxCdC.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If CodCodigoCompraTextBox.Enabled = False Then
                DesProdComTextBox.Focus()
            Else
                CodCodigoCompraTextBox.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub CCostoComComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCdC.SelectedIndexChanged
        If cbxCdC.SelectedValue <> 0 Then
            Dim w As New Funciones.Funciones

            EnlazadoProductos = w.FuncionConsulta("ENLAZADO", "CENTROCOSTO", "CODCENTRO", cbxCdC.SelectedValue)
            If EnlazadoProductos = 1 Then
                CodCodigoCompraTextBox.Enabled = True
                DesProdComTextBox.ReadOnly = True
                If PermisoIVA = 0 Then
                    TipoIvaComboBox.Enabled = False
                Else
                    TipoIvaComboBox.Enabled = True
                End If
            Else
                CodCodigoCompraTextBox.Enabled = False
                TipoIvaComboBox.Enabled = True
                CodCodigoCompraTextBox.Text = ""
                DesProdComTextBox.ReadOnly = False : DesProdComTextBox.Enabled = True
            End If
        End If
    End Sub

    Private Sub CmbTipoFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbTipoFactura.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbDeposito.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub CmbTipoFactura_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoFactura.SelectedValueChanged
        If CmbTipoFactura.Text = "Contado" Then
            ModalidadPagoFacturaTextBox.Text = "0"
        ElseIf CmbTipoFactura.Text = "Crédito" Then
            ModalidadPagoFacturaTextBox.Text = "1"
        End If
    End Sub

    Private Sub CodCodigoCompraTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles CodCodigoCompraTextBox.GotFocus
        lblMensajeInteractivo.Text = ""
        Try
            Me.CODIGOSTableAdapter.Fill(DsPagos.CODIGOS, "%")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CodCodigoCompraTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CodCodigoCompraTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            EnlazadoProductos = w.FuncionConsulta("ENLAZADO", "CENTROCOSTO", "CODCENTRO", cbxCdC.SelectedValue)
            CantidadComTextBox1.Focus()
            KeyAscii = 0
        ElseIf KeyAscii = 42 Then
            CodCodigoCompraTextBox.Text = ""
            If cbxCdC.SelectedValue = Nothing Then
                Exit Sub
            Else
                EnlazadoProductos = w.FuncionConsulta("ENLAZADO", "CENTROCOSTO", "CODCENTRO", cbxCdC.SelectedValue)
                If EnlazadoProductos = 1 Then
                    Me.CODIGOSBindingSource.RemoveFilter()
                    ProdGroupBox.BringToFront()
                    ProdGroupBox.Visible = True
                    BusCodigoTextBox.Text = ""
                    If PermisoIVA = 0 Then
                        TipoIvaComboBox.Enabled = False
                    Else
                        TipoIvaComboBox.Enabled = True
                    End If
                    BusCodigoTextBox.Focus()
                End If
            End If
        ElseIf KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub CodCodigoCompraTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodCodigoCompraTextBox.LostFocus
        Try
            If CodCodigoCompraTextBox.Text <> "" Then
                Me.CODIGOSBindingSource.Filter = "CODIGO = '" & CodCodigoCompraTextBox.Text & "'"

                ErrorCodigoLabel.Visible = False
                If EnlazadoProductos = 1 Then
                    If ProdGridView1.RowCount = 0 Then
                        BusCodigoTextBox.Text = ""
                        CodCodigoCompraTextBox.Text = ""
                        CodCodigoCompraTextBox.Focus()

                    Else
                        If IsDBNull(ProdGridView1.CurrentRow) Then
                            BusCodigoTextBox.Text = ""
                            CodCodigoCompraTextBox.Focus()
                        Else

                            Dim CostoProd As String
                            lblMensajeInteractivo.Text = ""

                            If Config5 = "Precio Última Compra" Then
                                If IsDBNull(ProdGridView1.CurrentRow.Cells("PRECIOULTCOMPRA").Value) Then
                                    CostoProd = 0
                                Else
                                    CostoProd = FormatNumber(ProdGridView1.CurrentRow.Cells("PRECIOULTCOMPRA").Value, 0)
                                End If

                                If CDec(CostoProd) > 0 Then
                                    lblMensajeInteractivo.ForeColor = Color.Black
                                    lblMensajeInteractivo.Text = "Costo Ulti. Compra: " + CostoProd

                                    If Config6 = "Si" Then
                                        CostoComTextBox1.Text = CostoProd
                                    End If
                                End If
                            Else
                                If IsDBNull(ProdGridView1.CurrentRow.Cells("COSTOFIFO").Value) Then
                                    CostoProd = 0
                                Else
                                    CostoProd = FormatNumber(ProdGridView1.CurrentRow.Cells("COSTOFIFO").Value, 0)
                                End If

                                If CDec(CostoProd) > 0 Then
                                    lblMensajeInteractivo.Text = "Costo Fifo: " + CostoProd
                                    lblMensajeInteractivo.ForeColor = Color.Black

                                    If Config6 = "Si" Then
                                        CostoComTextBox1.Text = CostoProd
                                    End If
                                End If
                            End If

                            lblPrecio2.Text = CostoProd

                            If IsDBNull(ProdGridView1.CurrentRow.Cells("CODCODIGO2").Value) Then
                            Else
                                CodCodigoCTextBox = ProdGridView1.CurrentRow.Cells("CODCODIGO2").Value
                            End If

                            If IsDBNull(ProdGridView1.CurrentRow.Cells("CODPRODUCTO2").Value) Then
                            Else
                                CodProductoCTextBox = ProdGridView1.CurrentRow.Cells("CODPRODUCTO2").Value
                            End If

                            If IsDBNull(ProdGridView1.CurrentRow.Cells("CODIGO2").Value) Then
                            Else
                                CodCodigoCompraTextBox.Text = ProdGridView1.CurrentRow.Cells("CODIGO2").Value
                            End If

                            If IsDBNull(ProdGridView1.CurrentRow.Cells("DESCRIPCION").Value) Then
                            Else
                                DesProdComTextBox.Text = ProdGridView1.CurrentRow.Cells("DESCRIPCION").Value
                            End If

                            If IsDBNull(ProdGridView1.CurrentRow.Cells("PORCENTAJEIVA").Value) Then
                            Else
                                If GlobalAutofactura = 1 Then 'Or IvaIncluidoTextBox.Text = "2"
                                    TipoIvaComboBox.Text = "0,00"
                                Else
                                    Dim PorcentajeIvaProducto As String = ProdGridView1.CurrentRow.Cells("PORCENTAJEIVA").Value
                                    TipoIvaComboBox.Text = PorcentajeIvaProducto
                                End If
                            End If

                        End If
                    End If
                End If
                BusCodigoTextBox.Text = ""
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CodMonedaComTextBox_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodMonedaComTextBox.TextChanged
        'Para traer la Cotizacion
        If CodMonedaComTextBox.Text = "" Then
            tbxCompraCotizacion.Text = 1
        Else
            Try
                Dim Cotizacion As String
                Cotizacion = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", CodMonedaComTextBox.Text + " ORDER BY FECHAMOVIMIENTO DESC")
                If Cotizacion <> Nothing Or Cotizacion <> "" Then
                    tbxCompraCotizacion.Text = FormatNumber(Cotizacion, 0)
                Else
                    tbxCompraCotizacion.Text = 1
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1, CONFIG2, CONFIG3, CONFIG4, CONFIG5, CONFIG6,CONFIG7, CONFIG8, CONFIG9, CONFIG10, CONFIG11, CONFIG12 FROM MODULO WHERE MODULO_ID = 3"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    Config1 = odrConfig("CONFIG1")
                    Config2 = odrConfig("CONFIG2")
                    Config3 = odrConfig("CONFIG3")
                    Config4 = odrConfig("CONFIG4")
                    Config5 = odrConfig("CONFIG5")
                    Config6 = odrConfig("CONFIG6")
                    Config7 = odrConfig("CONFIG7")
                    Config8 = odrConfig("CONFIG8")
                    Config9 = odrConfig("CONFIG9")
                    Config10 = odrConfig("CONFIG10")
                    Config11 = odrConfig("CONFIG11")
                    Config12 = odrConfig("CONFIG12")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CompraPlus_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            If cbxCdC.Enabled = True Then
                cbxCdC.Focus()
            End If
        End If

        If e.KeyCode = Keys.F5 Then
            If NuevoPictureBox.Enabled = True Then
                NuevoPictureBox_Click(Nothing, Nothing)
            End If

        End If

        If e.KeyCode = Keys.F6 Then
            '    If ModificarPictureBox.Enabled = True Then
            ModificarPictureBox_Click(Nothing, Nothing)
            'End If
        End If

        If e.KeyCode = Keys.F7 Then
            If GuardarPictureBox.Enabled = True Then
                GuardarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F8 Then
            If CancelarPictureBox.Enabled = True Then
                CancelarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F9 Then
            PanelConceptoCompras.Visible = True
            PanelConceptoCompras.BringToFront()

            TextBoxConcepto.Enabled = True
            TextBoxConcepto.Focus()
        End If

        If e.KeyCode = Keys.F10 Then
            If BtnImprimir.Enabled = True Then
                PictureBoxCuotas_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F11 Then
            If BtnImprimir.Enabled = True Then
                BtnImprimir_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F12 Then
            If PictureBoxMotivoAnulacion.Enabled = True Then
                PictureBoxMotivoAnulacion_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            gbxEventos.Visible = False
            RadGroupBoxProveedor.Visible = False
            PanelConceptoCompras.SendToBack()
            ProdGroupBox.SendToBack()
            ProdGroupBox.Visible = False
            pnlRedondeoIVA.Visible = False
        End If
    End Sub

    Private Sub ComprasPlus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 19)

        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        ObtenerConfig()

        NroCompraGlobal = 0 : KeyProv = 0 : btaprobar = 0 : IsKeyPress = 0
        dtIva = IVATableAdapter.GetData()

        Try
            Me.DEPOSITOTableAdapter.Fill(Me.DsPagos.DEPOSITO)
            Me.TIPOFORMACOBROTableAdapter.Fill(Me.DsPagos.TIPOFORMACOBRO)

            Me.EVENTOTableAdapter.Fill(Me.DsPagos.EVENTO)
            EVENTOBindingSource.RemoveFilter()

            Me.MONEDATableAdapter.Fill(Me.DsPagos.MONEDA)
            Me.IVATableAdapter.Fill(Me.DsPagos.IVA)
            Me.TIPOCOMPROBANTETableAdapter.Fill(Me.DsPagos.TIPOCOMPROBANTE)
            Me.CENTROCOSTOTableAdapter.Fill(Me.DsPagos.CENTROCOSTO)
            Me.PROVEEDORTableAdapter.Fill(Me.DsPagos.PROVEEDOR, "%", "%")
            Me.SUCURSALTableAdapter.Fill(Me.DsPagos.SUCURSAL)
        Catch ex As Exception
        End Try

        PermisoIVA = PermisoAplicado(UsuCodigo, 261)
        Nuevop = False

        If MONEDA1 = Nothing Then
            MONEDA1 = "Gs"
        End If
        If CODMONEDAPRINCIPAL = Nothing Then
            CODMONEDAPRINCIPAL = 1
        End If

        If ComprasSimpleGridView1.RowCount <= 0 Then
            Limpiarcompra()
        End If

        CmbAño.SelectedText = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1

        FechaFiltro()

        Deshabilitamos()
        txtEstado_TextChanged(Nothing, Nothing)

        BuscarCompraTextBox.Focus()
        PintarCeldas()
        EstadoCompra = 0

        If Config9 = "Ver Ordenes de Compra" Then
            rbtverOC.Checked = True
            rbtverOC_CheckedChanged(Nothing, Nothing)

        ElseIf Config9 = "Ver Facturas" Then
            rbtVerfacturas.Checked = True
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)

        Else
            rbtvertodo.Checked = True
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ComprasSimpleGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComprasSimpleGridView1.SelectionChanged
        Try
            Dim CodPago As Integer
            Dim CantDecimales As String
            VCodCompra = ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value
            txtEstado_TextChanged(Nothing, Nothing)

            Try
                If VCodCompra <> Nothing Then
                    CodPago = ComprasSimpleGridView1.CurrentRow.Cells("MODALIDADPAGODataGridViewTextBoxColumn").Value
                    ProvFactComboBox.Text = ComprasSimpleGridView1.CurrentRow.Cells("PROVEEDORDataGridViewTextBoxColumn").Value
                    mascaraActual = ComprasSimpleGridView1.CurrentRow.Cells("MASCARA").Value
                    VCodCompra = ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value
                    txtEstado_TextChanged(Nothing, Nothing)

                    If CodPago = 1 Then
                        CmbTipoFactura.Text = "Crédito"
                        If VCodCompra <> Nothing Then
                            CodPago = ComprasSimpleGridView1.CurrentRow.Cells("MODALIDADPAGODataGridViewTextBoxColumn").Value
                            ProvFactComboBox.Text = ComprasSimpleGridView1.CurrentRow.Cells("PROVEEDORDataGridViewTextBoxColumn").Value
                            mascaraActual = ComprasSimpleGridView1.CurrentRow.Cells("MASCARA").Value

                            If CodPago = 1 Then
                                CmbTipoFactura.Text = "Crédito"
                            Else
                                CmbTipoFactura.Text = "Contado"
                            End If
                        Else
                            CmbTipoFactura.Text = "Contado"
                        End If
                    End If
                    RecorreDetalleCompra2()
                End If

                If cbxComprasMoneda.SelectedValue <> Nothing Then
                    CantDecimales = f.FuncionConsultaDecimal("CANTIDADDECIMALES", "MONEDA", "CODMONEDA", cbxComprasMoneda.SelectedValue)
                    DetalleCompraGridView.Columns("COSTOUNITARIO").DefaultCellStyle.Format = "N" & CantDecimales
                    DetalleCompraGridView.Columns("SUBTOTAL").DefaultCellStyle.Format = "N" & CantDecimales
                End If
            Catch ex As Exception
            End Try

            TxtNumProv.Show()

            If cbxComprasMoneda.SelectedValue <> Nothing Then
                CantDecimales = f.FuncionConsultaDecimal("CANTIDADDECIMALES", "MONEDA", "CODMONEDA", cbxComprasMoneda.SelectedValue)
                DetalleCompraGridView.Columns("COSTOUNITARIO").DefaultCellStyle.Format = "N" & CantDecimales
                DetalleCompraGridView.Columns("SUBTOTAL").DefaultCellStyle.Format = "N" & CantDecimales
            End If

            'Verificamos si esta factura tiene una orden de compra 
            If IsDBNull(ComprasSimpleGridView1.CurrentRow.Cells("CodOrdCompra").Value) Then
                If IsDBNull(ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value) Then
                    lblTextoOrd.Visible = False
                ElseIf ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value = 1 Then
                    lblTextoOrd.Visible = True
                End If
                lblOrdenCompra.Visible = False
            Else
                lblOrdenCompra.Text = f.FuncionConsultaString("NUMCOMPRA", "COMPRAS", "CODCOMPRA", ComprasSimpleGridView1.CurrentRow.Cells("CodOrdCompra").Value)

                If lblOrdenCompra.Text <> "" Then
                    lblOrdenCompra.Visible = True : lblTextoOrd.Visible = True : lblTextoOrd.Visible = True
                End If
            End If

            'Si es una orden de compra vamos a mostrar el nro de factura que esta relacionada
            lblTextoFactura.Visible = True : lblNroFacturaRelOC.Visible = True : lblNroFacturaRelOC.Text = ""
            lblNroFacturaRelOC.Text = f.FuncionConsultaString("NUMCOMPRA", "COMPRAS", "CODORDCOMPRA", ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value)
            If lblNroFacturaRelOC.Text = "" Then
                lblTextoFactura.Visible = False : lblNroFacturaRelOC.Visible = False
            End If

            'esto tuve que hacer asi porque no encontre la forma de que la grilla me muetre con los decimales que esta en la bd sin hacer el redondeo, por mas
            'que le ponia con dos decimale igual me hacia 328.00 aunque mi nro era 328.51 - No es una buena forma de hacer pero por la falta de tiempo de presentar una solucion
            'en fecha tuve que hacerlo asi. Aquel que vea esto y encuentre una mejor solucion aplicar enseguida. Yoly
            Dim objCommand As New SqlCommand
            Dim v10, v5, vTI, vEx, vTTC As Decimal

            Try
                objCommand.CommandText = "SELECT TOTALIVA10, TOTALIVA5, TOTALIVA, TOTALEXENTA, TOTALCOMPRA FROM COMPRAS WHERE CODCOMPRA = " & ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value
                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        v10 = odrConfig("TOTALIVA10")
                        v5 = odrConfig("TOTALIVA5")
                        vTI = odrConfig("TOTALIVA")
                        vEx = odrConfig("TOTALEXENTA")
                        vTTC = odrConfig("TOTALCOMPRA")
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try

            v10 = v10 / CDec(tbxCompraCotizacion.Text) : Iva10TextBox1.Text = FormatNumber(v10, 2)
            v5 = v5 / CDec(tbxCompraCotizacion.Text) : Iva5TextBox1.Text = FormatNumber(v5, 2)
            vTI = vTI / CDec(tbxCompraCotizacion.Text) : umeTotalIva.Text = FormatNumber(vTI, 2)
            vEx = vEx / CDec(tbxCompraCotizacion.Text) : TotalExentaTextBox1.Text = FormatNumber(vEx, 2)
            vTTC = vTTC / CDec(tbxCompraCotizacion.Text) : TotalTextBox1.Text = FormatNumber(vTTC, 2)
        Catch ex As Exception

        End Try

        TxtNumProv.Show()
    End Sub

    Private Sub CostoComTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CostoComTextBox1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If TipoIvaComboBox.Enabled = False Then
                btnAgregar.Focus()
            Else
                TipoIvaComboBox.Focus() 'el focus en Iva causa problemas
                If CodCodigoCompraTextBox.Enabled = False Then
                    TipoIvaComboBox.Text = ""
                End If
                'AgregarDetCompraButton.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxCompraCotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCompraCotizacion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxCdC.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub DarFormatoMoneda(ByVal Cadena As String)
        Dim MontoIngresado As Double = CDec(Cadena)
        Dim Cantidad As Double
        Dim Entero As String = Int(Cadena)
        Dim Largo As Integer = Entero.Length
        Dim Decimales As Double
        Dim PosicionInicial As Integer
        Dim TieneDecimales As Integer = 0

        Resultado = Cadena

        If Largo > 3 Then
            'Separamos la parte entera de la decimal
            Entero = Int(MontoIngresado)
            Decimales = CDec(MontoIngresado) - Entero

            If Decimales > 0 Then
                TieneDecimales = 1
            End If

            'Sacamos la Cantidad de punto que debe llevar
            Cantidad = Largo / 3
            Cantidad = Int(Cantidad)

            'Empezamos a armar
            If TieneDecimales = 1 Then
                PosicionInicial = 3
            Else
                PosicionInicial = 3
            End If

            For Cantidad = 1 To Cantidad
                Resultado = Resultado.Insert(Largo - PosicionInicial, ".")
                PosicionInicial = PosicionInicial + 3
            Next

        End If
        Resultado = Resultado.ToString + " " + MONEDA1
    End Sub

    Private Sub Deshabilitamos()
        ComprasSimpleGridView1.Enabled = True
        ComprasSimpleGridView1.Focus()
        IngresarCotCheckBox.Enabled = False
        PanelCuota.Visible = False
        pnlCabecera.Enabled = False
        pnlDetalle.Enabled = True
        TableLayoutPanel8.Enabled = True

        'Detalle

        cbxCdC.Enabled = False
        CodCodigoCompraTextBox.Enabled = False
        CantidadComTextBox1.Enabled = False
        CostoComTextBox1.Enabled = False
        TipoIvaComboBox.Enabled = False
        DesProdComTextBox.Enabled = False
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        DetalleCompra1GridView.Enabled = True

        PanelConceptoCompras.Enabled = False
        tsCampoDeConcepto.Enabled = False
        PanelAnular.Enabled = False
        btnModTimbrado.Enabled = False

        'Botonsillos :)
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        BuscarCompraTextBox.Enabled = True
        BtnFiltro.Enabled = True
        CmbMes.Enabled = True
        CmbAño.Enabled = True
        rbtvertodo.Enabled = True
        rbtverOC.Enabled = True
        rbtVerfacturas.Enabled = True
        pbxBuscarProveedor.Enabled = False

        ComprasSimpleGridView1.Enabled = True
        tsAplicarDescuentoAlTota.Enabled = True
        BuscarCompraTextBox.Enabled = True
    End Sub

    Private Sub DesProdComTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DesProdComTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If CantidadComTextBox1.Enabled = True Then
                CantidadComTextBox1.Focus()
            Else
                TipoIvaComboBox.Focus()
            End If

        End If
    End Sub

    Private Sub DetalleCompra1GridView_CellDoubleClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles DetalleCompra1GridView.CellDoubleClick
        'Pasamos los datos a los Controles para su modificacion
        Try
            If IsDBNull(DetalleCompra1GridView.CurrentRow.Cells("CODCENTRO").Value) Then
            Else
                cbxCdC.SelectedValue = DetalleCompra1GridView.CurrentRow.Cells("CODCENTRO").Value
            End If

            If IsDBNull(DetalleCompra1GridView.CurrentRow.Cells("CANTIDADCOMPRA").Value) Then
            Else
                CantidadComTextBox1.Text = DetalleCompra1GridView.CurrentRow.Cells("CANTIDADCOMPRA").Value
            End If

            If IsDBNull(DetalleCompra1GridView.CurrentRow.Cells("COSTOUNITARIO").Value) Then
            Else
                CostoComTextBox1.Text = DetalleCompra1GridView.CurrentRow.Cells("COSTOUNITARIO").Value
            End If

            If IsDBNull(DetalleCompra1GridView.CurrentRow.Cells("CODCODIGO").Value) Then
                CodCodigoCTextBox = Nothing
            Else
                CodCodigoCTextBox = DetalleCompra1GridView.CurrentRow.Cells("CODCODIGO").Value
                CodCodigoCompraTextBox.Text = w.FuncionConsultaString("CODIGO", "CODIGOS", "CODCODIGO", DetalleCompra1GridView.CurrentRow.Cells("CODCODIGO").Value)
            End If

            If IsDBNull(DetalleCompra1GridView.CurrentRow.Cells("CODPRODUCTO").Value) Then
                CodProductoCTextBox = Nothing
            Else
                CodProductoCTextBox = DetalleCompra1GridView.CurrentRow.Cells("CODPRODUCTO").Value
            End If


            If IsDBNull(DetalleCompra1GridView.CurrentRow.Cells("IVA").Value) Then
                'PorcentajeIvaCompra.Text = ""
            Else
                'PorcentajeIvaCompra.Text = DetalleCompra1GridView.CurrentRow.Cells("IVA").Value
                TipoIvaComboBox.SelectedValue = DetalleCompra1GridView.CurrentRow.Cells("IVA").Value
            End If

            If IsDBNull(DetalleCompra1GridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value) Then
                DesProdComTextBox.Text = ""
            Else
                DesProdComTextBox.Text = DetalleCompra1GridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
            End If

            cbxCdC.Focus()

            IndiceDetalleCompra = DetalleCompraGridView.CurrentRow.Index

            btnAgregar.Text = "Modificar"
            btnEliminar.Text = "Cancelar"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ElimDetFacButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If DetalleCompraGridView.RowCount <> 0 Then
            If btnEliminar.Text = "Eliminar" Then
                If btNuevo = 1 Then
                    DetalleCompraGridView.Rows.Remove(Me.DetalleCompraGridView.CurrentRow)
                Else
                    If IsDBNull(DetalleCompraGridView.CurrentRow) Then
                        MessageBox.Show("Seleccione la Fila a Eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        If btModificar = 1 Then
                            If DetalleCompraGridView.CurrentRow.Cells("ComprasDetalleID").Value > 0 Then 'Quiere decir que es un detalle ya grabado en la BD
                                CodigoABorrar = DetalleCompraGridView.CurrentRow.Cells("ComprasDetalleID").Value.ToString + ","
                            End If
                        End If
                    End If

                    Try
                        DetalleCompraGridView.Rows.Remove(Me.DetalleCompraGridView.CurrentRow)
                    Catch ex As Exception
                        MessageBox.Show("Problema al Eliminar: " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End Try
                End If

                RecalcularIVA()
                cbxCdC.Select()
            End If
        End If

        Dim centro As String
        centro = w.FuncionTop1("DESCENTRO", "CENTROCOSTO")
        cbxCdC.Text = centro
        btnEliminar.Text = "Eliminar" : btnAgregar.Text = "Agregar"
    End Sub

    Private Sub ELIMINAR()
        If CodCompraTextBox.Text = "" Then
            Exit Sub
        End If

        If MessageBox.Show("Eliminar esta Orden de Compra?", "Cogent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            Dim ExistePago As Integer

            ExistePago = w.FuncionConsulta("NUMEROCUOTA", "FACTURAPAGAR", "PAGADO = 1 " & _
                                             "AND CODCOMPRA", CodCompraTextBox.Text)
            If ExistePago > 0 Then
                MessageBox.Show("Compra no se puede Eliminar, porque tiene un Pago Relacionado", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            EliminarDetalleCompra()
            EliminarCompra()
            myTrans.Commit()

            If rbtvertodo.Checked = True Then
                rbtvertodo_CheckedChanged(Nothing, Nothing)
            End If
            If rbtverOC.Checked = True Then
                rbtverOC_CheckedChanged(Nothing, Nothing)
            End If
            If rbtVerfacturas.Checked = True Then
                rbtVerfacturas_CheckedChanged(Nothing, Nothing)
            End If

            COMPRASBindingSource.MoveLast()
            lblComprasEstado.Text = "Compra Eliminada"
            RecorreDetalleCompra2()
            ''GUARDADO
            Deshabilitamos()
        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch

            End Try
            MessageBox.Show("Problema al Eliminar la Compra la misma esta relacionada a otros campos del sistema" & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblComprasEstado.Text = "Problema al Eliminar"
            RecorreDetalleCompra2()
        Finally
            sqlc.Close()

        End Try
    End Sub

    Private Sub EliminarCompra()
        Try

            sql = ""
            sql = " DELETE FROM COMPRAS " & _
            " WHERE CODCOMPRA= " & CDec(CodCompraTextBox.Text) & ""
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Problema al Eliminar la Compra la misma esta relacionada a otros campos del sistema ", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub EliminarDetalleCompra()
        Try

            sql = ""
            sql = " DELETE FROM COMPRASDETALLE " & _
            " WHERE CODCOMPRA= " & CDec(CodCompraTextBox.Text) & " "
            sql = sql + " DELETE FROM FACTURAPAGAR WHERE CODCOMPRA=" & CDec(CodCompraTextBox.Text) & ""
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Problema al Eliminar el Detalle de la Compra: " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click

        permiso = PermisoAplicado(UsuCodigo, 21)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para ELIMINAR", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            ELIMINAR()
            PintarCeldas()
        End If
        If ComprasSimpleGridView1.RowCount = 0 Then
            txtEstado.Text = "0"
        End If
    End Sub

    Private Sub FechaFactTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FechaFactTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            IvaIncluidoComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub FechaFiltro()
        Try

            Dim nromes, nroaño As Integer
            Dim fechacompleta1, fechacompleta2, mes As String
            nromes = CmbMes.SelectedIndex + 1
            nroaño = CInt(CmbAño.Text)

            If nromes = 10 Or nromes = 11 Or nromes = 12 Then
                mes = nromes.ToString
            Else
                mes = "0" + nromes.ToString

            End If

            fechacompleta1 = "01" + "/" + nromes.ToString + "/" + CmbAño.Text
            fechacompleta2 = ""
            If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
                fechacompleta2 = "31" + "/" + nromes.ToString + "/" + CmbAño.Text

            ElseIf nromes = 2 Or nromes = 4 Or nromes = 6 Or nromes = 7 Or nromes = 9 Or nromes = 11 Then
                If nromes = 2 Then
                    If (nroaño - 1992) Mod 4 = 0 Then
                        fechacompleta2 = "29" + "/" + mes.ToString + "/" + nroaño.ToString
                    Else
                        fechacompleta2 = "28" + "/" + mes.ToString + "/" + nroaño.ToString
                    End If
                Else
                    fechacompleta2 = "30" + "/" + mes.ToString + "/" + nroaño.ToString
                End If
            End If
            fechacompleta1 = fechacompleta1 + " 00:00:00.000"
            fechacompleta2 = fechacompleta2 + " 23:59:59.900"
            FechaFiltro1 = CDate(fechacompleta1)
            FechaFiltro2 = CDate(fechacompleta2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim MensajesError As String = ""
        Dim NroError As Integer = 0
        pnlDescuento.SendToBack()
        CantDetalle = DetalleCompraGridView.RowCount
        Try
            If Not (btModificar = 1 And EstadoCompra = 1) Then
                proveedorexterior = dgvProveedor.CurrentRow.Cells("MASCARA2").Value
            End If
        Catch ex As Exception
        End Try

        If CantDetalle = 0 Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Antes de Guardar, es necesario cargar algun Item " + Chr(13)
        End If

        If CodCompraTextBox.Text = "" Then
            Exit Sub
        End If

        'Bueno aca empezamos a guardar la bocha de datos que tenemos
        If Config7 = "No" Then
            If DuplicarContenido = 0 Then
                If proveedorexterior = 0 Then
                    If NroFacturaMaskedEditBox1.Text = "--" Or NroFacturaMaskedEditBox1.Text = "" Then
                        NroError = NroError + 1
                        MensajesError = CStr(NroError) & ") Nro. de Factura no puede quedar vacio " + Chr(13)
                    End If
                Else
                    If NroFactText.Text = "" Then
                        NroError = NroError + 1
                        MensajesError = CStr(NroError) & ") Nro. de Factura no puede quedar vacio " + Chr(13)
                    End If
                End If
            End If
        End If

        If proveedorexterior = 0 Then
            NroFactura = NroFacturaMaskedEditBox1.Text
        Else
            NroFactura = NroFactText.Text
        End If

        If CmbTipoFactura.Text = "" Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Seleccione el Tipo de Factura " + Chr(13)
        End If

        If cbxComprasMoneda.SelectedValue = Nothing Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Elija la Moneda para la Factura " + Chr(13)
        End If

        If ProvFactComboBox.SelectedValue = Nothing Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Es necesario que elija el Proveedor " + Chr(13)
        End If

        If Config8 = "No" Then
            If Trim(txtTimbrado.Text = "") Then
                NroError = NroError + 1
                MensajesError = CStr(NroError) & ") Es necesario ingresar el Timbrado del Proveedor " + Chr(13)
            End If
        End If

        If NroError <> 0 Then
            MessageBox.Show("Faltaron datos para completar el proceso de guardado. Favor revise estos items antes de seguir:  " + Chr(13) + MensajesError, "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        GuardarPictureBox.Image = My.Resources.SaveActive
        Me.Cursor = Cursors.AppStarting

        'Validar
        ValidaFactura()
        ProvFactura = ProvFactComboBox.SelectedValue

        '#######################################################################
        'Preguntamos si existe la Factura para saber si es una actualizacion o insercion

        If CmbTipoFactura.Text = "Contado" Then
            ModalidadPagoFacturaTextBox.Text = "0"
        ElseIf CmbTipoFactura.Text = "Crédito" Then
            ModalidadPagoFacturaTextBox.Text = "1"
        End If

        Dim transaction As SqlTransaction = Nothing

        If btModificar = 1 Then
            '###################################################################
            'ACTUALIZAR: si existe el codigo de la Compra actualiza
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaCompra()
                ActualizaDetalleCompra()

                myTrans.Commit()

                lblComprasEstado.Text = "Guardado!"

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                MessageBox.Show("Error al Guardar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblComprasEstado.Text = "Error al Guardar"
            Finally
                sqlc.Close()

                EntradoModificar = False
                EntradoNuevo = False
            End Try

        ElseIf btNuevo = 1 Then

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaCompra()
                InsertarDetalleCompra()

                myTrans.Commit()

                lblComprasEstado.Text = "Guardado!"

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Error al Guardar: " + ex.Message, "POSEXPRESS")
                lblComprasEstado.Text = "Error al Guardar"
            Finally
                sqlc.Close()
            End Try

        End If

        lblTextoOrd.Text = "Nº Ord Compra:"
        lblTextoOrd.Visible = False
        txtTimbrado.BackColor = SystemColors.GradientInactiveCaption

        Deshabilitamos()
        ComprasSimpleGridView1.Enabled = True

        'Mostramos los datos de acuerdo a la opcion seleccionada
        If rbtverOC.Checked = True Then
            rbtverOC_CheckedChanged(Nothing, Nothing)

        ElseIf rbtVerfacturas.Checked = True Then
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)

        ElseIf rbtvertodo.Checked = True Then
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If

        'Buscamos la posicion del registro guardado
        For k = 0 To ComprasSimpleGridView1.RowCount - 1
            If ComprasSimpleGridView1.Rows(k).Cells("CODCOMPRA").Value = compra Then
                COMPRASBindingSource.Position = k
            End If
        Next

        COMPRASDETALLEBindingSource.RemoveFilter()
        COMPRASDETALLETableAdapter.Fill(DsPagos.COMPRASDETALLE, compra)

        TextBoxConcepto.Text = "" : Me.PanelRedondeo.Visible = False : Me.tbxRedondeo.Text = ""
        btNuevo = 0 : btModificar = 0 : CodigoABorrar = "" : DuplicarContenido = 0
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Habilitamos()
        PanelCuota.Enabled = True
        pnlCabecera.Enabled = True
        pnlDetalle.Enabled = True

        ProvFactComboBox.Enabled = True : IvaIncluidoComboBox.Enabled = True : TipoCompComboBox.Enabled = True : CmbEvento.Enabled = True
        CmbTipoFactura.Enabled = True : CmbDeposito.Enabled = True : tbxCompraCotizacion.Enabled = False : IngresarCotCheckBox.Enabled = True
        pbxBuscarProveedor.Enabled = True : cbxComprasMoneda.Enabled = True : TxtNumProv.Enabled = True

        cbxCdC.Enabled = True
        CodCodigoCompraTextBox.Enabled = True
        CantidadComTextBox1.Enabled = True
        CostoComTextBox1.Enabled = True
        TipoIvaComboBox.Enabled = True
        btnAgregar.Enabled = True
        btnEliminar.Enabled = True

        PanelConceptoCompras.Enabled = True
        tsCampoDeConcepto.Enabled = True
        PanelAnular.Enabled = True
        IngresarCotCheckBox.Enabled = True
        ' Botones Habilitados '
        ComprasSimpleGridView1.Enabled = True
        BuscarCompraTextBox.Enabled = True
        BtnFiltro.Enabled = False
        CmbMes.Enabled = False
        CmbAño.Enabled = False
        rbtvertodo.Enabled = False
        rbtverOC.Enabled = False
        rbtVerfacturas.Enabled = False

        btnAgregar.Enabled = True
        btnEliminar.Enabled = True
        pbxBuscarProveedor.Enabled = True
        DetalleCompraGridView.Enabled = True

        btnModTimbrado.Enabled = True

        TxtNumProv.Focus()

        ComprasSimpleGridView1.Enabled = False
        tsAplicarDescuentoAlTota.Enabled = False
        BuscarCompraTextBox.Enabled = False
        DetalleCompra1GridView.Enabled = True
    End Sub


    Private Sub IngresarCotCheckBox_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs)
        If IngresarCotCheckBox.Checked = True Then
            tbxCompraCotizacion.Focus()
            tbxCompraCotizacion.Enabled = True
        Else
            tbxCompraCotizacion.Focus()
            tbxCompraCotizacion.Enabled = False
        End If
    End Sub

    Private Sub InicializaFechaFiltro()
        Dim nromes, nroaño As Integer
        Dim fechacompleta1, fechacompleta2, mes As String
        nromes = Today.Month
        nroaño = Today.Year

        If nromes = 10 Or nromes = 11 Or nromes = 12 Then
            mes = nromes.ToString
        Else
            mes = "0" + nromes.ToString

        End If

        fechacompleta1 = "01" + "/" + mes + "/" + nroaño.ToString
        fechacompleta2 = ""
        If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
            fechacompleta2 = "31" + "/" + mes + "/" + nroaño.ToString

        ElseIf nromes = 2 Or nromes = 4 Or nromes = 6 Or nromes = 7 Or nromes = 9 Or nromes = 11 Then
            If nromes = 2 Then
                If (nroaño - 1992) Mod 4 = 0 Then
                    fechacompleta2 = "29" + "/" + mes + "/" + nroaño.ToString
                Else
                    fechacompleta2 = "28" + "/" + mes + "/" + nroaño.ToString
                End If
            Else
                fechacompleta2 = "30" + "/" + mes + "/" + nroaño.ToString
            End If

        End If
        FechaFiltro1 = CDate(fechacompleta1)
        FechaFiltro2 = CDate(fechacompleta2)
    End Sub

    Private Sub InsertaCompra()
        Try
            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = FechaFactTextBox.Text
            Dim Concatenar As String = Concat & " " + hora
            Dim varBaseImponible As Integer = 0

            If IvaIncluidoComboBox.Text = "No incluido" Then
                IvaIncluidoTextBox.Text = "0"
            ElseIf IvaIncluidoComboBox.Text = "Incluido" Then
                IvaIncluidoTextBox.Text = "1"
            ElseIf IvaIncluidoComboBox.Text = "Importacion" Then
                IvaIncluidoTextBox.Text = "2"
            End If

            If BaseImponible.Text = "" Or BaseImponible.Text = Nothing Then
                BaseImponible.Text = 0
            Else
                varBaseImponible = CDec(BaseImponible.Text)
                varBaseImponible = Funciones.Cadenas.QuitarCad(varBaseImponible, ".")
                varBaseImponible = Replace(varBaseImponible, ",", ".")
            End If

            Dim EstadoCompra As Integer = w.FuncionConsultaDecimal("ESTADO", "COMPRAS", "CODCOMPRA", CDec(tbxCodCompras.Text))

            sql = ""
            sql = sql + " insert into COMPRAS(TOTALIVA,TOTALIVA5,TOTALIVA10,TOTALGRAVADA,MODALIDADPAGO,TOTALEXENTA," & _
             "CODDEPOSITO,TOTALCOMPRA,CODSUCURSAL,ESTADO,CODUSUARIO,FECHACOMPRA,CODCOMPROBANTE" & _
             ",CODPROVEEDOR,NUMCOMPRA,CODMONEDA,COTIZACION1,IVAINCLUIDO,COMPRASIMPLE,CODEVENTO,METODO, TOTALGRAVADO10,TOTALGRAVADO5, TIMBRADOPROV,ORDCOMPRA, BASEIMPONIBLE) " & _
             "VALUES(" & TotalIvaF & ", " & TotalIva5F & ", " & _
            "" & TotalIva10F & ", " & _
            "" & TotalGravadaF & ", " & ModalidadPagoFacturaTextBox.Text & " ," & _
            "" & TotalExentaF & ", " & CmbDeposito.SelectedValue & " ," & _
            "" & TotalFac & "," & SucCodigo & " ," & _
            "0 ," & UsuCodigo & "," & _
            "CONVERT(DATETIME, '" & Concatenar & "', 103)," & _
            "" & CodComprobanteF & ", " & _
            "" & ProvFactura & "," & _
            "'" & NroFactura & "', " & _
            "" & MonedaFactura & "," & CotizacioF1 & ", " & _
            "" & IvaIncluidoTextBox.Text & "," & _
            "0," & Evento & ",'" & Me.cbxMetodo.Text & "'," & TotalGravada10F & "," & TotalGravada5F & ",'" & txtTimbrado.Text & "',0, " & varBaseImponible & ")" & _
             "SELECT CODCOMPRA FROM COMPRAS WHERE CODCOMPRA = SCOPE_IDENTITY();"

            cmd.CommandText = sql
            compra = cmd.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("Error al Insertar la Compra: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub IvaIncluidoComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IvaIncluidoComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TipoCompComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub IvaIncluidoComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IvaIncluidoComboBox.SelectedIndexChanged
        If IvaIncluidoComboBox.Text = "No incluido" Then
            IvaIncluidoTextBox.Text = "0"
            'Habilita el campo de Sector
            CmbEvento.Visible = True
            pbxBuscarEvento.Visible = True
            Label7.Text = "Sector / Proyecto:"

        ElseIf IvaIncluidoComboBox.Text = "Incluido" Then
            IvaIncluidoTextBox.Text = "1"
            'Habilita el campo de Sector
            CmbEvento.Visible = True
            pbxBuscarEvento.Visible = True
            Label7.Text = "Sector / Proyecto:"
            BaseImponible.Visible = False

        ElseIf IvaIncluidoComboBox.Text = "Importacion" Then
            IvaIncluidoTextBox.Text = "2"
            'Habilita el campo de Base Imponible
            BaseImponible.Visible = True
            Label7.Text = "Base Imponible"

            'Deshabilita los campos de Sector.
            CmbEvento.Visible = False
            pbxBuscarEvento.Visible = False
        End If
    End Sub

    Private Sub IvaIncluidoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IvaIncluidoTextBox.TextChanged
        If IvaIncluidoTextBox.Text = "1" Then
            IvaIncluidoComboBox.Text = "Incluido"
        ElseIf IvaIncluidoTextBox.Text = "0" Then
            IvaIncluidoComboBox.Text = "No incluido"
        ElseIf IvaIncluidoTextBox.Text = "2" Then
            IvaIncluidoComboBox.Text = "Importacion"
        End If
    End Sub

    Private Sub Limpiarcompra()
        'LIMPIAMOS
        cbxCdC.Text = ""
        CodCodigoCompraTextBox.Text = ""
        CodCodigoCTextBox = Nothing
        CodProductoCTextBox = Nothing
        CantidadComTextBox1.Text = ""
        CostoComTextBox1.Text = ""
        DesProdComTextBox.Text = ""
        TipoIvaComboBox.Text = ""
        cbxCdC.Select()
    End Sub

    Private Sub ModalidadPagoFacturaTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModalidadPagoFacturaTextBox.TextChanged
        If ModalidadPagoFacturaTextBox.Text = "0" Then
            CmbTipoFactura.SelectedItem = "Contado"
            PictureBoxCuotas.Enabled = False
            tsPanelDeCreditos.Enabled = False
            PictureBoxCuotas.Image = My.Resources.CreditOff
            PictureBoxCuotas.Cursor = Cursors.Arrow

        ElseIf ModalidadPagoFacturaTextBox.Text = "1" Then
            CmbTipoFactura.SelectedItem = "Crédito"

            If VGComprasFacil = 1 Then
                PictureBoxCuotas.Enabled = False
                tsPanelDeCreditos.Enabled = False
                PictureBoxCuotas.Image = My.Resources.CreditOff
            Else
                PictureBoxCuotas.Enabled = True
                tsPanelDeCreditos.Enabled = True
                PictureBoxCuotas.Image = My.Resources.Credit
                PictureBoxCuotas.Cursor = Cursors.Hand
            End If
        Else
            CmbTipoFactura.SelectedItem = Nothing
            PictureBoxCuotas.Enabled = False
            tsPanelDeCreditos.Enabled = False
            PictureBoxCuotas.Image = My.Resources.CreditOff
            PictureBoxCuotas.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 22)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para MODIFICAR", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            EstadoCompra = w.FuncionConsultaDecimal("ESTADO", "COMPRAS", "CODCOMPRA", CDec(tbxCodCompras.Text))
            If (EstadoCompra = 1) Then
                permiso = PermisoAplicado(UsuCodigo, 258)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para modificar una Compra Aprobada", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If

            Me.TotalTextBox1.Enabled = True
            btNuevo = 0 : btModificar = 1

            If CodCompraTextBox.Text = "" Then
                MessageBox.Show("Elija una Compra para Modificar, o cargue uno Nuevo", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If (EstadoCompra <> 1) Then
                ProvFactComboBox.Enabled = True : IvaIncluidoComboBox.Enabled = True : TipoCompComboBox.Enabled = True : CmbEvento.Enabled = True
                CmbTipoFactura.Enabled = True : CmbDeposito.Enabled = True : tbxCompraCotizacion.Enabled = True : IngresarCotCheckBox.Enabled = True
                pbxBuscarProveedor.Enabled = True : cbxComprasMoneda.Enabled = True : pnlDetalle.Enabled = True
                PanelConceptoCompras.Visible = True
            End If

            Habilitamos()
            ModificarPictureBox.Image = My.Resources.EditActive
            EntradoGuardar = False : EntradoModificar = True : EntradoNuevo = True : IvaIncluidoComboBox.Enabled = False
            txtEstado.Text = "3"

            If (EstadoCompra = 1) Then
                ProvFactComboBox.Enabled = False : IvaIncluidoComboBox.Enabled = False : TipoCompComboBox.Enabled = False : CmbEvento.Enabled = False
                CmbTipoFactura.Enabled = False : CmbDeposito.Enabled = False : tbxCompraCotizacion.Enabled = False : IngresarCotCheckBox.Enabled = False
                pbxBuscarProveedor.Enabled = False : cbxComprasMoneda.Enabled = False : pnlDetalle.Enabled = True : PanelConceptoCompras.Visible = False

                cbxCdC.Enabled = False : CodCodigoCompraTextBox.Enabled = False : CantidadComTextBox1.Enabled = False : CostoComTextBox1.Enabled = False
                TipoIvaComboBox.Enabled = False : btnAgregar.Enabled = False : btnEliminar.Enabled = False
            End If
        End If
    End Sub

    Private Sub cbxComprasMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxComprasMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If IngresarCotCheckBox.Checked = True Then
                tbxCompraCotizacion.Focus()
            Else
                cbxCdC.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxComprasMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxComprasMoneda.SelectedIndexChanged
        If cbxComprasMoneda.SelectedValue <> Nothing Then
            CodMonedaComTextBox.Text = cbxComprasMoneda.SelectedValue
            Dim CantDecimales As String
            If cbxComprasMoneda.SelectedValue <> Nothing Then
                CantDecimales = f.FuncionConsultaDecimal("CANTIDADDECIMALES", "MONEDA", "CODMONEDA", cbxComprasMoneda.SelectedValue)
                DetalleCompraGridView.Columns("COSTOUNITARIO").DefaultCellStyle.Format = "N" & CantDecimales
                DetalleCompraGridView.Columns("SUBTOTAL").DefaultCellStyle.Format = "N" & CantDecimales
            End If
            If CodMonedaComTextBox.Text = "1" Then
                IngresarCotCheckBox.Enabled = False
            Else
                IngresarCotCheckBox.Enabled = True
            End If
        End If

    End Sub

    Private Sub NroFactText_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NroFactText.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            FechaFactTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub NroFacturaMaskedEditBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NroFacturaMaskedEditBox1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Config12 = "Si" Then
                'verificamos que el nro de factura tenga 15 digitos (001-001-0000000 = 15)
                Dim CantDigFactura As Integer = NroFacturaMaskedEditBox1.Text.Length
                If CantDigFactura <> 15 Then
                    MessageBox.Show("El nro de Factura debe contener 13 digitos (Ej: 001-001-1234567), favor verifique", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            FechaFactTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Public Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 20)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para CREAR una COMPRA", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            PanelAnular.SendToBack()
            PanelConceptoCompras.SendToBack()
            IvaIncluidoTextBox.Text = "1"
            'ComprasSimpleGridView1.Enabled = False
            EntradoNuevo = True : EntradoGuardar = False : EntradoModificar = True
            btNuevo = 1 : btModificar = 0 : Nuevop = True : LineaCompra = 0 : DuplicarContenido = 0
            TotalTextBox1.Text = "" : TotalExentaTextBox1.Text = "" : Iva5TextBox1.Text = "" : Iva10TextBox1.Text = "" : umeTotalIva.Text = "" : NroFacturaMaskedEditBox1.Text = ""
            ProvFactComboBox.SelectedIndex = -1 : ProvFactComboBox.Text = ""

            Limpiarcompra()

            FechaFiltro1 = "01/01/2013" : FechaFiltro2 = "01/01/3000"
            If btNuevo = 1 Then
                COMPRASTableAdapter.Fill(DsPagos.COMPRAS, "%", FechaFiltro1, FechaFiltro2)
            Else
                If rbtvertodo.Checked = True Then
                    rbtvertodo_CheckedChanged(Nothing, Nothing)
                End If
                If rbtverOC.Checked = True Then
                    rbtverOC_CheckedChanged(Nothing, Nothing)
                End If
                If rbtVerfacturas.Checked = True Then
                    rbtVerfacturas_CheckedChanged(Nothing, Nothing)
                End If
            End If

            COMPRASBindingSource.AddNew()
            NuevoPictureBox.Image = My.Resources.NewActive

            Habilitamos()
            IvaIncluidoComboBox.Enabled = True
            TxtNumProv.Focus()

            Dim deposito As String
            deposito = w.FuncionTop1WHEREString("DESSUCURSAL", "SUCURSAL", "'Solo Stock' or TIPOSUCURSAL='Factura y Stock'")
            CmbDeposito.Text = deposito

            lblNroOrdCompra.Visible = False : lblTextoOrd.Visible = False

            If TipoCompComboBox.Text = "" And TipoCompComboBox.Items.Count > 0 Then
                TipoCompComboBox.SelectedIndex = TipoCompComboBox.SelectedIndex + 1
            End If

            Dim centro As String
            centro = w.FuncionTop1("DESCENTRO", "CENTROCOSTO")
            CmbDeposito.Text = deposito : cbxCdC.Text = centro
            Nuevop = False : txtEstado.Text = "3" : cbxMetodo.Text = "Simplificado" : TipoIvaComboBox.Text = "10,00" : Me.TotalTextBox1.Enabled = True
            tbxCompraCotizacion.Text = w.FuncionTop1WHERE("FACTORVENTA", "COTIZACION", cbxComprasMoneda.SelectedValue)

            PanelConceptoCompras.SendToBack()
            PanelAnular.SendToBack()
        End If
    End Sub

    Private Sub panelfococontrol(ByVal control As Control, ByVal panelfoco As Panel)
        Dim ancho, largo As Integer
        Dim x, y As Integer
        With control
            panelfoco.Visible = True
            ancho = .Width + 2
            largo = .Height + 2
            x = .Location.X - 1
            y = .Location.Y - 1
        End With
        panelfoco.SetBounds(x, y, ancho, largo)
    End Sub

    Private Sub PbxProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbxProveedor.Click
        Proveedor.ShowDialog()
    End Sub

    Private Sub ProdGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProdGridView1.CellDoubleClick
        If ProdGridView1.RowCount = 0 Then
            BusCodigoTextBox.Text = ""
            CodCodigoCompraTextBox.Text = ""
            CodCodigoCompraTextBox.Focus()
            ProdGroupBox.Visible = False

        Else
            If IsDBNull(ProdGridView1.CurrentRow) Then
                BusCodigoTextBox.Text = ""
                CodCodigoCompraTextBox.Focus()
                ProdGroupBox.Visible = False
            Else
                Dim CostoProd As String
                lblMensajeInteractivo.Text = ""

                If Not Config5 = "Precio Última Compra" Then
                    If IsDBNull(ProdGridView1.CurrentRow.Cells("PRECIOULTCOMPRA").Value) Then
                        CostoProd = 0
                    Else
                        CostoProd = FormatNumber(ProdGridView1.CurrentRow.Cells("PRECIOULTCOMPRA").Value, 0)
                        CostoComTextBox1.Text = CostoProd
                    End If
                    If CDec(CostoProd) > 0 Then
                        lblMensajeInteractivo.ForeColor = Color.Red
                        lblMensajeInteractivo.Text = "Costo Ult. Compra: " + CostoProd
                    End If
                Else
                    If IsDBNull(ProdGridView1.CurrentRow.Cells("COSTOFIFO").Value) Then
                        CostoProd = 0
                    Else
                        CostoProd = FormatNumber(ProdGridView1.CurrentRow.Cells("COSTOFIFO").Value, 0)
                    End If
                    If CDec(CostoProd) > 0 Then
                        lblMensajeInteractivo.Text = "Costo Fifo: " + CostoProd
                        lblMensajeInteractivo.ForeColor = Color.Black
                    End If
                End If

                lblPrecio2.Text = CostoProd

                If IsDBNull(ProdGridView1.CurrentRow.Cells("CODCODIGO2").Value) Then
                Else
                    CodCodigoCTextBox = ProdGridView1.CurrentRow.Cells("CODCODIGO2").Value
                End If

                If IsDBNull(ProdGridView1.CurrentRow.Cells("CODPRODUCTO2").Value) Then
                Else
                    CodProductoCTextBox = ProdGridView1.CurrentRow.Cells("CODPRODUCTO2").Value
                End If

                If IsDBNull(ProdGridView1.CurrentRow.Cells("CODIGO2").Value) Then
                Else
                    CodCodigoCompraTextBox.Text = ProdGridView1.CurrentRow.Cells("CODIGO2").Value
                End If

                If IsDBNull(ProdGridView1.CurrentRow.Cells("DESCRIPCION").Value) Then
                Else
                    DesProdComTextBox.Text = ProdGridView1.CurrentRow.Cells("DESCRIPCION").Value
                End If

                If IsDBNull(ProdGridView1.CurrentRow.Cells("PORCENTAJEIVA").Value) Then
                Else
                    If GlobalAutofactura = 1 Then 'Or IvaIncluidoTextBox.Text = "2" 
                        TipoIvaComboBox.Text = "0,00"
                    Else
                        Dim PorcentajeIvaProducto As String = ProdGridView1.CurrentRow.Cells("PORCENTAJEIVA").Value
                        TipoIvaComboBox.SelectedText = PorcentajeIvaProducto
                    End If
                End If

                BusCodigoTextBox.Text = ""
                CodCodigoCompraTextBox.Focus()
                ProdGroupBox.Visible = False
            End If
            CantidadComTextBox1.Focus()
        End If
    End Sub

    Private Sub ProvFactComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ProvFactComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Dim proveedorexterior As Integer = f.FuncionConsultaDecimal("MASCARA", "PROVEEDOR", "CODPROVEEDOR", ProvFactComboBox.SelectedValue)
            If proveedorexterior = 1 Then
                NroFactText.Focus()
            Else
                NroFacturaMaskedEditBox1.Focus()
            End If
        End If

        If KeyAscii = 43 Then
            Proveedor.ShowDialog()
        End If

        If KeyAscii = 42 Then
            IsKeyPress = 1
            Me.PROVEEDORBindingSource1.RemoveFilter()
            RadGroupBoxProveedor.Visible = True
            RadGroupBoxProveedor.BringToFront()
            TxtBuscaProveedor.Text = ""
            TxtBuscaProveedor.Focus()
            e.Handled = True
        End If
        KeyProv = 1
    End Sub

    Private Sub ProvFactComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles ProvFactComboBox.LostFocus
        If IsKeyPress = 0 Then
            Try
                Me.PROVEEDORBindingSource1.Filter = "CODPROVEEDOR= " & ProvFactComboBox.SelectedValue & ""

                If IsDBNull(dgvProveedor.CurrentRow.Cells("CODCENTROPROV").Value) Then
                Else
                    VCodCentroCosto = dgvProveedor.CurrentRow.Cells("CODCENTROPROV").Value
                    cbxCdC.SelectedValue = VCodCentroCosto
                End If

                If IsDBNull(dgvProveedor.CurrentRow.Cells("CODMONEDA").Value) Then
                    cbxComprasMoneda.SelectedValue = 1
                Else
                    VCodMoneda = dgvProveedor.CurrentRow.Cells("CODMONEDA").Value
                    cbxComprasMoneda.SelectedValue = VCodMoneda
                End If

                If IsDBNull(dgvProveedor.CurrentRow.Cells("DIASVENCIMIENTO").Value) Then
                    DiasVto = 1
                Else
                    DiasVto = dgvProveedor.CurrentRow.Cells("DIASVENCIMIENTO").Value
                End If

                If IsDBNull(dgvProveedor.CurrentRow.Cells("CANTCUOTAS").Value) Then
                    PCantCuotas = 1
                Else
                    PCantCuotas = dgvProveedor.CurrentRow.Cells("CANTCUOTAS").Value
                End If

                If Config10 = "No" Then
                    Me.txtTimbrado.Text = ""
                Else
                    If IsDBNull(dgvProveedor.CurrentRow.Cells("TIMBRADOFACTURA2").Value) Then
                    Else
                        timbradoActual = dgvProveedor.CurrentRow.Cells("TIMBRADOFACTURA2").Value
                        Me.txtTimbrado.Text = dgvProveedor.CurrentRow.Cells("TIMBRADOFACTURA2").Value
                    End If
                End If

                Try
                    If IsDBNull(dgvProveedor.CurrentRow.Cells("FORMAPAGO").Value) Then
                    Else
                        If dgvProveedor.CurrentRow.Cells("FORMAPAGO").Value = 0 Then
                            Me.CmbTipoFactura.Text = "Contado"
                        Else
                            Me.CmbTipoFactura.Text = "Crédito"
                        End If
                    End If
                Catch ex As Exception

                End Try

                If IsDBNull(dgvProveedor.CurrentRow.Cells("FECHAVTOTIMBRADO").Value) Then
                    lblTextoOrd.Text = "Nº Ord Compra:"
                    lblTextoOrd.Visible = False
                    txtTimbrado.BackColor = SystemColors.GradientInactiveCaption
                Else
                    VtoTimbrado = dgvProveedor.CurrentRow.Cells("FECHAVTOTIMBRADO").Value
                    If Today > VtoTimbrado Then
                        lblTextoOrd.Text = "Timbrado Vencido"
                        lblTextoOrd.Visible = True
                        txtTimbrado.BackColor = Color.Pink
                    Else
                        lblTextoOrd.Text = "Nº Ord Compra:"
                        lblTextoOrd.Visible = False
                        txtTimbrado.BackColor = SystemColors.GradientInactiveCaption
                    End If
                End If

                proveedorexterior = dgvProveedor.CurrentRow.Cells("MASCARA2").Value

                If proveedorexterior = 0 Then
                    NroFactText.Visible = False
                    NroFacturaMaskedEditBox1.Visible = True
                    IvaIncluidoComboBox.Text = "Incluido"
                    IvaIncluidoTextBox.Text = "1"
                    NroFacturaMaskedEditBox1.Focus()

                ElseIf proveedorexterior > 0 Then
                    NroFactText.Visible = True
                    NroFacturaMaskedEditBox1.Visible = False
                    IvaIncluidoComboBox.Text = "Importacion"
                    IvaIncluidoTextBox.Text = "2"
                    NroFactText.Focus()
                End If

                If ComprasSimpleGridView1.RowCount = 1 Then
                    COMPRASDETALLEBindingSource.Filter = "CODCOMPRA=" & compra & ""
                End If

                If Not ProvFactComboBox.SelectedValue = Nothing Then
                    TxtNumProv.Text = f.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", ProvFactComboBox.SelectedValue)
                End If

            Catch ex As Exception
            End Try
        Else
            Try
                PROVEEDORBindingSource.RemoveFilter()
                'Obtenemos el Timbrado del Proveedor
                txtTimbrado.Text = w.FuncionConsultaString("TIMBRADOFACTURA", "PROVEEDOR", "CODPROVEEDOR", ProvFactComboBox.SelectedValue)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub RecorreDetalleCompra2()
        COMPRASDETALLETableAdapter.Fill(DsPagos.COMPRASDETALLE, VCodCompra)
    End Sub

    Private Sub TimbTextBox_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        Try
            If KeyAscii = 13 Then
                FechaFactTextBox.Focus()
                KeyAscii = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TipoIvaComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TipoIvaComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregar.Focus()
            KeyAscii = 0
            'e.Handled = 0
        End If
    End Sub

    Private Sub TxtBuscaProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscaProveedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgvProveedor.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub TxtBuscaProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscaProveedor.TextChanged
        PROVEEDORBindingSource1.Filter = "NOMBRE LIKE '%" & TxtBuscaProveedor.Text & "%'  OR RUC_CIN LIKE '%" & TxtBuscaProveedor.Text & "%'"
    End Sub

    Private Sub ValidaFactura()
        If EstadoTextBox.Text = "" Then
            EstadoCompra = "NULL"
        Else
            EstadoCompra = EstadoTextBox.Text
        End If
        If ModalidadPagoFacturaTextBox.Text = "" Then
            If CmbTipoFactura.Text = "Contado" Then
                TipoFactura = "0"
            ElseIf CmbTipoFactura.Text = "Crédito" Then
                TipoFactura = "1"
            Else
                TipoFactura = "NULL"
            End If

        Else
            TipoFactura = ModalidadPagoFacturaTextBox.Text
        End If

        If cbxComprasMoneda.SelectedValue = Nothing Then
            MonedaFactura = "NULL"
        Else
            MonedaFactura = cbxComprasMoneda.SelectedValue
        End If

        If TipoCompComboBox.SelectedValue = Nothing Then
            CodComprobanteF = "NULL"
        Else
            CodComprobanteF = TipoCompComboBox.SelectedValue
        End If
        If CmbEvento.SelectedValue = Nothing Then
            Evento = "NULL"
        Else
            Evento = CmbEvento.SelectedValue
        End If

        If tbxCompraCotizacion.Text = "" Then
            CotizacioF1 = "NULL"
        Else
            CotizacioF1 = CDec(tbxCompraCotizacion.Text)
            CotizacioF1 = Funciones.Cadenas.QuitarCad(CotizacioF1, ".")
            CotizacioF1 = Replace(CotizacioF1, ",", ".")
        End If

        'Obetenemos los valore Gavados.
        Dim Grav5, Grav10 As Double
        Grav5 = 0 : Grav10 = 0
        Dim i As Integer
        For i = 0 To DetalleCompraGridView.RowCount - 1
            If IsDBNull(DetalleCompraGridView.Rows(i).Cells("IMPORTEGRAVADO5").Value) Then
            Else
                Grav5 = Grav5 + (DetalleCompraGridView.Rows(i).Cells("IMPORTEGRAVADO5").Value * CotizacioF1)
            End If
            If IsDBNull(DetalleCompraGridView.Rows(i).Cells("IMPORTEGRAVADO10").Value) Then
            Else
                Grav10 = Grav10 + (DetalleCompraGridView.Rows(i).Cells("IMPORTEGRAVADO10").Value * CotizacioF1)
            End If
        Next

        'Decimales
        If Grav10 <> 0 Then
            TotalGravada10F = Math.Round(Grav10 - (Grav10 / 11), 0)
        Else
            TotalGravada10F = 0
        End If
        If Grav5 <> 0 Then
            TotalGravada5F = Math.Round(Grav5 - (Grav5 / 21), 0)
        Else
            TotalGravada5F = 0
        End If

        TotalExentaF = CDec(TotalExentaTextBox1.Text) * CDec(tbxCompraCotizacion.Text)
        TotalExentaF = Funciones.Cadenas.QuitarCad(TotalExentaF, ".")

        TotalFac = CDec(TotalTextBox1.Text) * CDec(tbxCompraCotizacion.Text)
        TotalFac = Funciones.Cadenas.QuitarCad(TotalFac, ".")

        TotalIva5F = CDec(Iva5TextBox1.Text) * CDec(tbxCompraCotizacion.Text)
        TotalIva5F = FormatNumber(TotalIva5F, 2)
        TotalIva5F = Funciones.Cadenas.QuitarCad(TotalIva5F, ".")

        TotalIva10F = CDec(Iva10TextBox1.Text) * CDec(tbxCompraCotizacion.Text)
        TotalIva10F = FormatNumber(TotalIva10F, 2)
        TotalIva10F = Funciones.Cadenas.QuitarCad(TotalIva10F, ".")

        TotalIvaF = CDec(TotalIva10F) + CDec(TotalIva5F)
        TotalIvaF = FormatNumber(TotalIvaF, 2)
        TotalIvaF = Funciones.Cadenas.QuitarCad(TotalIvaF, ".")

        TotalExentaF = Replace(TotalExentaF, ",", ".")
        TotalGravada10F = Replace(TotalGravada10F, ",", ".")
        TotalGravada5F = Replace(TotalGravada5F, ",", ".")

        TotalFac = Replace(TotalFac, ",", ".")
        TotalIvaF = Replace(TotalIvaF, ",", ".")
        TotalIva5F = Replace(TotalIva5F, ",", ".")
        TotalIva10F = Replace(TotalIva10F, ",", ".")

        If TotalExentaF = Nothing Then
            TotalExentaF = "NULL"
        End If

        If TotalGravadaF = Nothing Then
            TotalGravadaF = "NULL"
        End If

        If TotalFac = Nothing Then
            TotalFac = "NULL"
        End If

        If TotalIvaF = Nothing Then
            TotalIvaF = "NULL"
        End If

        If TotalIva5F = Nothing Then
            TotalIva5F = "NULL"
        End If
        If TotalGravada10F = Nothing Then
            TotalGravada10F = "NULL"
        End If
        If TotalGravada5F = Nothing Then
            TotalGravada5F = "NULL"
        End If
    End Sub

    Private Sub CmbDeposito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbDeposito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxComprasMoneda.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub CmbEvento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbTipoFactura.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxMetodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMetodo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxCdC.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub txtEstado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstado.TextChanged
        Try
            If txtEstado.Text = "0" Then
                Try
                    If IsDBNull(ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value) Then
                        LblEstado.Text = "Pendiente"
                        lblNroOrdCompra.Visible = False
                        lblTextoOrd.Visible = False
                        LblEstado.ForeColor = Color.Black
                    ElseIf ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value = 1 Then
                        LblEstado.Text = "Orden de Compra"
                        lblNroOrdCompra.Visible = True
                        lblTextoOrd.Visible = True
                        LblEstado.ForeColor = Color.DarkOrange
                    Else
                        LblEstado.Text = "Pendiente"
                        lblNroOrdCompra.Visible = False
                        lblTextoOrd.Visible = False
                        LblEstado.ForeColor = Color.Black
                    End If
                Catch ex As Exception
                    LblEstado.Text = "Pendiente"
                    lblNroOrdCompra.Visible = False
                    lblTextoOrd.Visible = False
                    LblEstado.ForeColor = Color.Black
                End Try

                BtnImprimir.Enabled = True
                tsAprobar.Enabled = True
                BtnImprimir.Image = My.Resources.Approve
                BtnImprimir.Cursor = Cursors.Hand
                PictureBoxMotivoAnulacion.Enabled = False
                tsAnular.Enabled = False
                PictureBoxMotivoAnulacion.Image = My.Resources.AnullOff
                PictureBoxMotivoAnulacion.Cursor = Cursors.Arrow

                NuevoPictureBox.Enabled = True
                tsNuevaCompra.Enabled = True
                NuevoPictureBox.Image = My.Resources.New_
                NuevoPictureBox.Cursor = Cursors.Hand
                EliminarPictureBox.Enabled = True
                tsEliminar.Enabled = True
                EliminarPictureBox.Image = My.Resources.Delete
                EliminarPictureBox.Cursor = Cursors.Hand
                ModificarPictureBox.Enabled = True
                tsEditar.Enabled = True
                ModificarPictureBox.Image = My.Resources.Edit
                ModificarPictureBox.Cursor = Cursors.Hand
                CancelarPictureBox.Enabled = False
                tsCancelar.Enabled = False
                CancelarPictureBox.Image = My.Resources.SaveCancelOff
                CancelarPictureBox.Cursor = Cursors.Arrow
                GuardarPictureBox.Enabled = False
                tsGuardar.Enabled = False
                GuardarPictureBox.Image = My.Resources.SaveOff
                GuardarPictureBox.Cursor = Cursors.Arrow
                PanelConceptoCompras.SendToBack()
                PanelAnular.SendToBack()

                btnModificarNroFactura.Enabled = False
                PictureBoxCuotas.Enabled = False
                tsPanelDeCreditos.Enabled = False
                PictureBoxCuotas.Image = My.Resources.CreditOff
                PictureBoxCuotas.Cursor = Cursors.Arrow

                tsEmitirOrdDeCompra.Enabled = True
                tsImprimirOrdDeCompra.Enabled = False
                tsAprobarOrdCompr.Enabled = False
                tsAnularOrdCompra.Enabled = False
                tsReImprimirOrdDeCompraMATR.Enabled = False

                Try
                    'Si es una orden de compra debemos habilitar la opcion de Anular
                    If Not IsDBNull(ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value) Then
                        If ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value = 1 Then
                            tsAnularOrdCompra.Enabled = True
                            PictureBoxMotivoAnulacion.Enabled = True
                            PictureBoxMotivoAnulacion.Image = My.Resources.Anull
                            PictureBoxMotivoAnulacion.Cursor = Cursors.Hand
                            BtnAnular.Enabled = True

                            tsImprimirOrdDeCompra.Enabled = True
                            tsReImprimirOrdDeCompraMATR.Enabled = True
                            tsAprobarOrdCompr.Enabled = True
                        End If
                    End If
                Catch ex As Exception
                End Try

            ElseIf txtEstado.Text = "1" Then
                LblEstado.Text = "Aprobada"
                LblEstado.ForeColor = Color.YellowGreen

                BtnImprimir.Enabled = False
                tsAprobar.Enabled = False
                BtnImprimir.Image = My.Resources.ApproveOff
                BtnImprimir.Cursor = Cursors.Arrow

                PictureBoxMotivoAnulacion.Enabled = True
                tsAnular.Enabled = True
                PictureBoxMotivoAnulacion.Image = My.Resources.Anull
                PictureBoxMotivoAnulacion.Cursor = Cursors.Hand

                btnModificarNroFactura.Enabled = True
                btnModificarNroFactura.BringToFront()

                'PanelConceptoCompras.BringToFront()
                'PanelConceptoCompras.Enabled = True

                tsCampoDeConcepto.Enabled = True
                BtnProbar.Enabled = False
                BtnCerrarAprobar.Enabled = True
                TextBoxConcepto.Enabled = False

                NuevoPictureBox.Enabled = True
                tsNuevaCompra.Enabled = True
                NuevoPictureBox.Image = My.Resources.New_
                NuevoPictureBox.Cursor = Cursors.Hand
                EliminarPictureBox.Enabled = False
                tsEliminar.Enabled = False
                EliminarPictureBox.Image = My.Resources.DeleteOff
                EliminarPictureBox.Cursor = Cursors.Arrow
                ModificarPictureBox.Enabled = False
                tsEditar.Enabled = True 'Habilitamos solo por Menú y por permiso
                ModificarPictureBox.Image = My.Resources.EditOff
                ModificarPictureBox.Cursor = Cursors.Arrow
                CancelarPictureBox.Enabled = False
                tsCancelar.Enabled = False
                CancelarPictureBox.Image = My.Resources.SaveCancelOff
                CancelarPictureBox.Cursor = Cursors.Arrow
                GuardarPictureBox.Enabled = False
                tsGuardar.Enabled = False
                GuardarPictureBox.Image = My.Resources.SaveOff
                GuardarPictureBox.Cursor = Cursors.Arrow

                PictureBoxCuotas.Enabled = True
                tsPanelDeCreditos.Enabled = True
                PictureBoxCuotas.Image = My.Resources.Credit
                PictureBoxCuotas.Cursor = Cursors.Hand

                tsEmitirOrdDeCompra.Enabled = False
                tsImprimirOrdDeCompra.Enabled = False
                tsAprobarOrdCompr.Enabled = False
                tsAnularOrdCompra.Enabled = False
                tsReImprimirOrdDeCompraMATR.Enabled = False
                lblNroOrdCompra.Visible = False
                lblTextoOrd.Visible = False

            ElseIf txtEstado.Text = "2" Then
                LblEstado.Text = "Anulada"
                LblEstado.ForeColor = Color.Maroon
                BtnImprimir.Enabled = False
                tsAprobar.Enabled = False
                BtnImprimir.Image = My.Resources.ApproveOff

                PictureBoxMotivoAnulacion.Enabled = False
                tsAnular.Enabled = False
                PictureBoxMotivoAnulacion.Image = My.Resources.AnullOff
                PictureBoxCuotas.Enabled = False
                tsPanelDeCreditos.Enabled = False
                PictureBoxCuotas.Image = My.Resources.CreditOff

                NuevoPictureBox.Enabled = True
                tsNuevaCompra.Enabled = True
                NuevoPictureBox.Image = My.Resources.New_
                NuevoPictureBox.Cursor = Cursors.Hand
                EliminarPictureBox.Enabled = False
                tsEliminar.Enabled = False
                EliminarPictureBox.Image = My.Resources.DeleteOff
                ModificarPictureBox.Enabled = False
                tsEditar.Enabled = False
                ModificarPictureBox.Image = My.Resources.EditOff
                CancelarPictureBox.Enabled = False
                tsCancelar.Enabled = False
                CancelarPictureBox.Image = My.Resources.SaveCancelOff
                CancelarPictureBox.Cursor = Cursors.Arrow
                GuardarPictureBox.Enabled = False
                tsGuardar.Enabled = False
                GuardarPictureBox.Image = My.Resources.SaveOff
                GuardarPictureBox.Cursor = Cursors.Arrow

                PanelAnular.BringToFront()
                PanelAnular.Enabled = True
                BtnCerrarAnular.Enabled = True
                BtnAnular.Enabled = False
                TextBoxAnulacionConcepto.Enabled = False

                btnModificarNroFactura.Enabled = False

                tsEmitirOrdDeCompra.Enabled = False
                tsImprimirOrdDeCompra.Enabled = False
                tsReImprimirOrdDeCompraMATR.Enabled = False
                tsAprobarOrdCompr.Enabled = False
                tsAnularOrdCompra.Enabled = False
                lblNroOrdCompra.Visible = False
                lblTextoOrd.Visible = False

            ElseIf txtEstado.Text = "3" Then
                LblEstado.Text = "Para Editar"
                LblEstado.ForeColor = Color.Black

                BtnImprimir.Enabled = False
                tsAprobar.Enabled = False
                BtnImprimir.Image = My.Resources.ApproveOff
                BtnImprimir.Cursor = Cursors.Arrow
                PictureBoxMotivoAnulacion.Enabled = False
                tsAnular.Enabled = False
                PictureBoxMotivoAnulacion.Image = My.Resources.AnullOff
                PictureBoxMotivoAnulacion.Cursor = Cursors.Arrow

                pnlCabecera.BringToFront()

                NuevoPictureBox.Image = My.Resources.NewOff
                NuevoPictureBox.Cursor = Cursors.Hand
                NuevoPictureBox.Enabled = False
                tsNuevaCompra.Enabled = False
                EliminarPictureBox.Enabled = False
                tsEliminar.Enabled = False
                EliminarPictureBox.Image = My.Resources.DeleteOff
                EliminarPictureBox.Cursor = Cursors.Arrow
                ModificarPictureBox.Enabled = False
                tsEditar.Enabled = False
                ModificarPictureBox.Image = My.Resources.EditOff
                ModificarPictureBox.Cursor = Cursors.Arrow

                CancelarPictureBox.Visible = True
                CancelarPictureBox.Enabled = True
                tsCancelar.Enabled = True
                CancelarPictureBox.Image = My.Resources.SaveCancel
                CancelarPictureBox.Cursor = Cursors.Hand
                GuardarPictureBox.Enabled = True
                tsGuardar.Enabled = True
                GuardarPictureBox.Image = My.Resources.Save
                GuardarPictureBox.Cursor = Cursors.Hand

                btnModificarNroFactura.Enabled = False
                PictureBoxCuotas.Enabled = False
                tsPanelDeCreditos.Enabled = False
                PictureBoxCuotas.Image = My.Resources.CreditOff
                PictureBoxCuotas.Cursor = Cursors.Arrow

                tsEmitirOrdDeCompra.Enabled = False
                tsImprimirOrdDeCompra.Enabled = False
                tsAprobarOrdCompr.Enabled = False
                tsAnularOrdCompra.Enabled = False
                tsReImprimirOrdDeCompraMATR.Enabled = False
                lblNroOrdCompra.Visible = False
                lblTextoOrd.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GuardarPictureBox_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.MouseHover
        Me.ToolTip1.SetToolTip(Me.GuardarPictureBox, "Guardar Factura")
    End Sub

    Private Sub PictureBoxCuotas_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxCuotas.MouseHover, pbxProductos.MouseHover
        Me.ToolTip1.SetToolTip(Me.PictureBoxCuotas, "Factura Crédito")
    End Sub

    Private Sub BtnImprimir_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimir.MouseHover
        Me.ToolTip1.SetToolTip(Me.BtnImprimir, "Aprobar Factura")
    End Sub

    Private Sub PictureBoxMotivoAnulacion_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxMotivoAnulacion.MouseHover
        Me.ToolTip1.SetToolTip(Me.PictureBoxMotivoAnulacion, "Cancelar Factura")
    End Sub

    Private Sub ModificarPictureBox_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.MouseHover
        Me.ToolTip1.SetToolTip(Me.ModificarPictureBox, "Editar Factura")
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        permiso = PermisoAplicado(UsuCodigo, 23)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para Aprobar Compras", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            ' Controlamos si el nro de factura se repite con el mismo proveedor
            Dim existenrofactura As String

            If Not NroFacturaMaskedEditBox1.Visible = True Then
                existenrofactura = w.FuncionConsultaString("NUMCOMPRA", "COMPRAS", "ESTADO=1 AND NUMCOMPRA = '" & NroFactText.Text & "' AND TIMBRADOPROV = '" & txtTimbrado.Text & "' AND CODPROVEEDOR", ProvFactComboBox.SelectedValue)
                If existenrofactura <> "" Then
                    If MessageBox.Show("Ya existe una Compra Aprobada de este Proveedor con el mismo Nro. de Factura y dentro del Timbrado. Desea Guardar de todos modos?", "Cogent SIG", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = MsgBoxResult.No Then
                        NroFactText.Focus()
                        Exit Sub
                    End If
                End If
            Else
                existenrofactura = w.FuncionConsultaString("NUMCOMPRA", "COMPRAS", "ESTADO=1 AND NUMCOMPRA = '" & NroFacturaMaskedEditBox1.Text & "' AND TIMBRADOPROV = '" & txtTimbrado.Text & "' AND CODPROVEEDOR", ProvFactComboBox.SelectedValue)
                If existenrofactura <> "" Then
                    If MessageBox.Show("Ya existe una Compra Aprobada de este Proveedor con el mismo Nro. de Factura y dentro del Timbrado. Desea Guardar de todos modos?", "Cogent SIG", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = MsgBoxResult.No Then
                        NroFacturaMaskedEditBox1.Focus()
                        Exit Sub
                    End If
                End If
            End If

            'Verificamos que el tipo de comprobante no quede vacio antes de aprobar
            If TipoCompComboBox.Text = "" Then
                MessageBox.Show("Ingrese el Tipo de Comprobantes", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TipoCompComboBox.Focus()
                Exit Sub
            End If
            PanelConceptoCompras.BringToFront()
            PanelConceptoCompras.Enabled = True : tsCampoDeConcepto.Enabled = True : BtnProbar.Enabled = True : TextBoxConcepto.Enabled = True
            TextBoxConcepto.Text = ""
            TextBoxConcepto.Focus()

            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub BtnProbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProbar.Click
        btaprobar = 1
        'Al Aprobar una factura de compra debemos realizar las siguientes acciones
        BtnImprimir.Image = My.Resources.ApproveActive
        Me.Cursor = Cursors.AppStarting
        Dim transaction As SqlTransaction = Nothing
        Dim CodOrdCompra As Integer = 0
        Dim ExsiteCodOrdCompra As Integer = 0

        If Not IsDBNull(ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value) Then
            If ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value = 1 Then
                'si es una orden de compras verificamos que no se halla aprobado antes (evitamos que una misma orden de compras se apruebe varias veces)
                ExsiteCodOrdCompra = f.FuncionConsultaDecimal("CODORDCOMPRA", "COMPRAS", "CODORDCOMPRA", ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value)

                If ExsiteCodOrdCompra = 0 Then
                    CodOrdCompra = ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value
                    tsDuplicarFactura_Click(Nothing, Nothing) 'Duplicamos el contenido
                Else
                    MessageBox.Show("Esta Orden de Compras ya fue Aprobada", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Cursor = Cursors.Arrow
                    ComprasSimpleGridView1.Enabled = True
                    PanelConceptoCompras.SendToBack()
                    BtnImprimir.Image = My.Resources.Approve
                    Exit Sub
                End If
            End If
        End If

        Dim c As Integer = DetalleCompraGridView.RowCount
        Dim CODCODIGO, CODPRODUCTO, CANDPROD, precio As String
        sql = ""

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        For j = 1 To c
            'Veririficamos
            If IsDBNull(DetalleCompraGridView.Rows(j - 1).Cells("CODPRODUCTO").Value) Then
            Else
                'Obtenemos el codigo del StockDeposito
                If IsDBNull(DetalleCompraGridView.Rows(j - 1).Cells("CODCODIGO").Value) Then
                    CODCODIGO = "null"
                Else
                    If DetalleCompraGridView.Rows(j - 1).Cells("CODCODIGO").Value = 0 Then
                        CODCODIGO = "null"
                    Else
                        CODCODIGO = DetalleCompraGridView.Rows(j - 1).Cells("CODCODIGO").Value
                    End If
                End If
                CODPRODUCTO = DetalleCompraGridView.Rows(j - 1).Cells("CODPRODUCTO").Value

                CANDPROD = DetalleCompraGridView.Rows(j - 1).Cells("CANTIDADCOMPRA").Value
                CANDPROD = Replace(CANDPROD, ",", ".")

                Dim hora As String = Now.ToString("HH:mm:ss")
                Dim Concat As DateTime = FechaFactTextBox.Text
                Dim Concatenar As Date = Concat & " " + hora
                Dim fecha As String
                fecha = Concatenar.ToString("dd/MM/yyy HH:mm:ss")

                'se debe insertar el movimiento de productos con un valor sin iva
                Dim Iva, PrecioCosto As Double
                PrecioCosto = DetalleCompraGridView.Rows(j - 1).Cells("COSTOUNITARIO").Value
                PrecioCosto = PrecioCosto * CInt(tbxCompraCotizacion.Text)

                If DetalleCompraGridView.Rows(j - 1).Cells("TIPOIVA").Value = "5.00" Then
                    Iva = Math.Round(PrecioCosto / 21, 0)
                ElseIf DetalleCompraGridView.Rows(j - 1).Cells("TIPOIVA").Value = "10.00" Then
                    Iva = Math.Round(PrecioCosto / 11, 0)
                ElseIf DetalleCompraGridView.Rows(j - 1).Cells("TIPOIVA").Value = "0.00" Then
                    Iva = 0
                End If

                precio = PrecioCosto - Iva
                precio = Replace(precio, ",", ".")

                If CODCODIGO <> "null" Then
                    'Insertamos Movimiento del Stock
                    sql = sql + " INSERT INTO MOVPRODUCTO " & _
                    "(CODCODIGO,CONCEPTO,CANTIDAD,FECHAMOVIMIENTO,CODUSUARIO, CODDEPOSITO,MODULO,STOCK,COSTEABLE,VALOR,MODULOTRANSID)" & _
                    " VALUES (" & CODCODIGO & ",'Compra Nro. " & NroFacturaMaskedEditBox1.Text & "', " & CANDPROD & ", convert(datetime,'" & fecha & "',103) ," & _
                    "" & UsuCodigo & "," & CmbDeposito.SelectedValue & ",3,1,1," & precio & "," & CDec(CodCompraTextBox.Text) & " ) "
                End If
            End If
        Next

        Try
            If sql <> "" Then
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If

            If ModalidadPagoFacturaTextBox.Text = "0" Then
                ActualizaFacturaPagarContado()
            End If

            '3 - Cambiamos de Estado la Factura de Compras
            If TextBoxConcepto.Text = "" Then
                TextBoxConcepto.Text = "Compra de " + ProvFactComboBox.Text
            End If

            '====Actualizando la compra para aprobado===
            Dim concepto As String = Replace(TextBoxConcepto.Text, "'", "''")
            Dim CadenaSQL As String = ""

            If CodOrdCompra = 0 Then 'Verificamos si esta factura vino de una Orden de Compra
                CadenaSQL = "CONCEPTO = '" & concepto & "'"
            Else
                CadenaSQL = "CONCEPTO = '" & concepto & "', CODORDCOMPRA = " & CodOrdCompra
            End If

            ActualizaEstadoCompra(1, CadenaSQL)

            myTrans.Commit()
            Existe = 0
        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch

            End Try
            BtnImprimir.Image = My.Resources.Approve
            Me.Cursor = Cursors.Arrow
            MessageBox.Show("Error al Aprobar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblComprasEstado.Text = "Error al Aprobar"
            btaprobar = 0
            Exit Sub
        Finally
            sqlc.Close()
        End Try

        '---------------------------------------------- PARA IMPRIMIR EN CASO DE AUTOFACTURAS ---------------------------
        Dim Autofactura As Integer
        Autofactura = w.FuncionConsultaString("convert(int,autofactura)", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
        If Autofactura = 1 Then
            RangoID = w.FuncionConsultaDecimal("RANDOID", "DETPC", "ACTIVO=1 AND CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
            '---------------------------- OBTENEMOS NRO DE COMPROBANTE ----------------------------
            'Antes de generar un nro de factura debemos verificar que no se haya cargado de forma manual dicho nro.
            CalculaNroAutoFactura() 'Se calcula el Nro de Autofactura a Generar de forma automatica

            '---------------------------- IMPRIMIMOS ----------------------------
            Try
                CantLinea = w.FuncionConsulta("NROLINEASDETALLE", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
                'Se verifica que tipo de formato de impresion tiene dicho comprabante
                TipoImpresion = w.FuncionConsulta("FORMAIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
                'Una ves que sabemos el tipo de impresion debemos verificar si esta marcada la opcion de imprimir
                Imprimir = w.FuncionConsulta("IMPRIMIR", "DETPC", "RANDOID", RangoID)
                impresora = f.FuncionConsultaString("IMPRESORA", "DETPC", "RandoId", RangoID)
                'se verifica el tipo de impresion para el tipo de comprobante actuamente seleccionado y de acuerdo a eso realizamos la impresion correspondiente
                'en caso de que este marcado la opcion de imprimir en la ventana "Rango de Comprobantes" 
                If TipoImpresion = 0 Then   'Formato Ticket
                    If Imprimir = 1 Then 'Se imprime
                        ImprimirAutoFacturaTicket()
                    End If
                ElseIf TipoImpresion = 1 Then 'Formato Impresora
                    If Imprimir = 1 Then 'Se imprime
                        ImprimirReporte()
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show("Error al Imprimir,  Mensaje : " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            '---------------------------- QUEMAMOS ----------------------------
            'Una ves impreso el documento y no haber error de impresion guardamos en la base de datos el nro de autofactura
            Try
                'Solo debemos actualizar el rango si es que no se introdujo la numeracion de forma manual
                ActualizaRango()

            Catch ex As Exception
                MessageBox.Show("Error al General el Nro de AutoFactura", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
        End If

        'Insertamos en la Tabla Comentarios
        If CmbEvento.Text <> "" Then
            InsertarProyecto("Factura de Compra Nro " & NroFacturaMaskedEditBox1.Text, CmbEvento.SelectedValue())
        End If

        '------------------------------------------------------------------- CONTABILIDAD --------------------------------------------------------
        'Obtenemos los valores que se utilizaron el modulo de contabilidad - by Yolanda Zelaya 
        Dim ConceptoAsiento, Timbrado, ClienteProveedor, NumCompra As String
        Dim objCommand As New SqlCommand
        Dim vContaIVA10, vContaIVA5, vContaExcenta, vContaTotalFactura, vContaTotalIva, RgMerc, RgMonet As Integer
        vContaIVA10 = 0 : vContaIVA5 = 0 : vContaExcenta = 0

        NumCompra = ""
        Try
            objCommand.CommandText = "SELECT CAST(ROUND(TOTALIVA, 0) AS INT) AS TOTALIVA, CAST(ROUND(TOTALCOMPRA, 0) AS INT) AS TOTALCOMPRA, CAST(ROUND(TOTALIVA5, 0) AS INT) AS TOTALIVA5, " & _
                                     " CAST(ROUND(TOTALIVA10, 0) AS INT) AS TOTALIVA10, TOTALEXENTA  FROM dbo.COMPRAS WHERE  CODCOMPRA = " & ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    vContaIVA10 = odrConfig("TOTALIVA10")
                    vContaIVA5 = odrConfig("TOTALIVA5")
                    vContaExcenta = odrConfig("TOTALEXENTA")
                    vContaTotalFactura = odrConfig("TOTALCOMPRA")
                    vContaTotalIva = odrConfig("TOTALIVA")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try

        ClienteProveedor = ProvFactComboBox.SelectedValue
        If CmbTipoFactura.Text = "Contado" Then
            RgMonet = 1
        ElseIf CmbTipoFactura.Text = "Crédito" Then
            RgMonet = 2
        End If
        If Trim(cbxMetodo.Text) = "Simplificado" Then
            RgMerc = 1
        End If

        If NroFacturaMaskedEditBox1.Text <> "" Then
            NumCompra = NroFacturaMaskedEditBox1.Text
        ElseIf NroFactText.Text <> "" Then
            NumCompra = NroFactText.Text
        End If

        Timbrado = w.FuncionConsultaString("TIMBRADOFACTURA", "PROVEEDOR", "CODPROVEEDOR", ClienteProveedor)
        Try
            ConceptoAsiento = TextBoxConcepto.Text
            'ConceptoAsiento = "Factura de Compra " & CmbTipoFactura.Text & " / " & ProvFactComboBox.Text
            ReglaContable(vContaExcenta, vContaIVA5, vContaIVA10, vContaTotalIva, "COMPRAS", CDec(tbxCodCompras.Text), "CODCOMPRA", ConceptoAsiento, RgMerc, RgMonet, _
                          cbxComprasMoneda.SelectedValue, tbxCompraCotizacion.Text, NumCompra, Me.FechaFactTextBox.Value, vContaTotalFactura, "3", Timbrado, ClienteProveedor, SucCodigo)
        Catch ex As Exception

        End Try

        Dim I As Integer = COMPRASBindingSource.Position
        rbtvertodo_CheckedChanged(Nothing, Nothing)
        COMPRASBindingSource.Position = I
        Deshabilitamos()
        Me.Cursor = Cursors.Arrow

        '-------------------------------------------------------------------------------------------------------------------------------------------
        'Verificamos si el pago fue al contado debemos abrir el panel de Pagos con todos los datos de la compra, si es credito abrir Panel de Cuotas
        Dim TotalCompra, CodigoDeCompra As Double
        Dim ProveedorDescrip As String

        TotalCompra = CDec(Me.TotalTextBox1.Text) * CDec(tbxCompraCotizacion.Text)
        CodigoDeCompra = Me.tbxCodCompras.Text
        ProveedorDescrip = ProvFactComboBox.Text

        If CmbTipoFactura.Text = "Crédito" Then
            PictureBoxCuotas_Click(Nothing, Nothing)
            dttFechaPrimeraCuota.Focus()
            If PCantCuotas = 0 Then
                PCantCuotas = 1
            End If
            tbxCantidadPagos.Text = PCantCuotas
            If DiasVto = 0 Then
                DiasVto = 1
            End If
            tbxPagoDias.Text = DiasVto

            If Config1 = "Simplificar Cuotas" Then
                btnPagosGenerarCuotas_Click(Nothing, Nothing)
                btGuardarCuotas.Focus()
            End If

        ElseIf CmbTipoFactura.Text = "Contado" And Config2 = "Mostrar automaticamente" Then
            PagosV2.Show()
            PagosV2.NuevoPictureBox_Click(Nothing, Nothing)
            PagosV2.CmbProveedor.SelectedValue = ProvFactComboBox.SelectedValue
            PagosV2.FACTURAPAGARTableAdapter.Fill(PagosV2.DsPagosFacutas.FACTURAPAGAR, PagosV2.CmbProveedor.SelectedValue)

            For I = 0 To PagosV2.dgvFacturasaPagar.Rows.Count - 1
                If PagosV2.dgvFacturasaPagar.Rows(I).Cells("CODCOMPRA1").Value = CodigoDeCompra Then
                    PagosV2.dgvFacturasaPagar.Rows(I).Cells("Pagar").Value = True
                    Exit For ' Ya encontro, entonces corta el Loop
                End If
            Next

            PagosV2.dgvFacturasaPagar_CellContentClick(Nothing, Nothing)
            PagosV2.SplitPagos.BringToFront()
            PagosV2.tbxMonto.Focus()
            PagosV2.panelactivo = "SplitPagos"

            PagosV2.PagosActivo.Image = My.Resources.PaymentActive
            PagosV2.PagosActivo.Cursor = Cursors.Arrow
            PagosV2.FiltroPagosActivo.Image = My.Resources.User
            PagosV2.FiltroPagosActivo.Cursor = Cursors.Hand
            PagosV2.TipoCobroPictureBox.Image = My.Resources.Cuenta
            PagosV2.TipoCobroPictureBox.Cursor = Cursors.Hand
            PagosV2.PendientesPago.Image = My.Resources.Create
            PagosV2.PendientesPago.Cursor = Cursors.Hand

            PagosV2.dgvPagos.Enabled = True : PagosV2.BtnFiltro.Enabled = True : PagosV2.BuscarTextBox.Enabled = True : PagosV2.PictureBox2.Visible = True
            PagosV2.BuscarTextBox.Visible = True : PagosV2.NuevoPictureBox.Visible = True : PagosV2.EliminarPictureBox.Visible = True
            PagosV2.CancelarPictureBox.Visible = True : PagosV2.ConfirmarPictureBox.Visible = True : PagosV2.ModificarDetPictureBox.Visible = True

            PagosV2.CodigoCompra = CodigoDeCompra
            PagosV2.tbxMonto.Text = TotalCompra
            PagosV2.lblMontoSelecionado.Text = TotalCompra
            PagosV2.pnlFacturasaPagar.Visible = False

            PagosV2.dtpFechaPago.Text = FechaFactTextBox.Text
            PagosV2.dtpFechaPago.Focus()

            If Config9 = "Ver Ordenes de Compra" Then
                rbtverOC.Checked = True
                rbtverOC_CheckedChanged(Nothing, Nothing)
            ElseIf Config9 = "Ver Facturas" Then
                rbtVerfacturas.Checked = True
                rbtVerfacturas_CheckedChanged(Nothing, Nothing)
            Else
                rbtvertodo.Checked = True
                rbtvertodo_CheckedChanged(Nothing, Nothing)
            End If
        End If

        btaprobar = 0
        btNuevo = 0 : btModificar = 0 : CodigoABorrar = ""
        ComprasSimpleGridView1.Enabled = True
        PanelConceptoCompras.SendToBack()
    End Sub

    Private Sub ActualizaRango()
        ser.Abrir(sqlc)
        cmd.Connection = sqlc

        Dim sql As String = ""
        Dim f As New Funciones.Funciones
        Dim Ultimo As Integer = f.MaximoconWhere("ULTIMO", "DETPC", "RANDOID", RangoID)
        Ultimo = Ultimo + 1

        sql = "UPDATE DETPC SET ULTIMO = " & Ultimo & " where RANDOID=" & RangoID & ""
        sql = sql + " UPDATE COMPRAS SET NUMCOMPRA='" & NumAutoFactura & "' WHERE CODCOMPRA=" & CDec(CodCompraTextBox.Text) & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub ImprimirReporte()
        Dim f As New Funciones.Funciones
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.AutoFactura

        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes

        If Config4 = "Papel Continuo" Then
            informe.PrintOptions.PaperSize = GetPapersizeID(impresora, "FacturaCogent")
        ElseIf Config4 = "Papel Normal" Then
            informe.PrintOptions.PaperSource = PaperSource.Upper 'bandeja
        End If

        informe.SetDataSource(InfAutoFactura())

        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress")
        End Try

        informe.PrintToPrinter(1, False, 0, 0)
    End Sub
    Public Function InfAutoFactura() As DataSet
        Dim ds As New DsInformes
        ds.Clear()
        Dim diez, cinco, exento, totalcinco, totaldiez, totalexento, total, TotalItems5, TotalItems10, TotalItemsExento As Decimal

        diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0 : TotalItems5 = 0
        TotalItems10 = 0 : TotalItemsExento = 0

        Try
            Dim CantImpresion As Integer
            Dim nrofactura As String
            nrofactura = NroFactText.Text
            Dim k As Integer = 1
            Dim c As Integer = DetalleCompraGridView.RowCount()

            Dim dadetpc As New SqlDataAdapter("Select TIMBRADO, IP, FECHAVALIDEZ FROM DETPC WHERE ACTIVO = 1 AND RANDOID=" & RangoID & "", ser.CadenaConexion)
            Dim dtdetpc As New DataTable
            dadetpc.Fill(dtdetpc)
            Dim drdetpc As DataRow
            drdetpc = dtdetpc.Rows(0)

            CantImpresion = f.FuncionConsultaDecimal("CANTIDADIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoCompComboBox.SelectedValue)

            Dim dadatoscli As New SqlDataAdapter("SELECT NOMBRE, DIRECCION, RUC_CIN FROM dbo.PROVEEDOR " & _
            "WHERE       CODPROVEEDOR =" & ProvFactComboBox.SelectedValue & "", ser.CadenaConexion)

            Dim dtdatoscli As New DataTable
            dadatoscli.Fill(dtdatoscli)
            Dim drdatoscli As DataRow
            drdatoscli = dtdatoscli.Rows(0)

            If CantImpresion = 0 Then
                CantImpresion = 1
            End If
            Dim i As Integer
            For k = 1 To CantImpresion
                For i = 1 To CantLinea
                    row = ds.Tables("Detalle").NewRow()
                    row.Item("Campo3") = k

                    '########### campos string ##########################################################
                    If i > c Then
                        row.Item("Campo1") = ""
                    Else
                        row.Item("Campo1") = DetalleCompraGridView.Rows(i - 1).Cells("DESPRODUCTO").Value
                    End If

                    If i > c Then
                        row.Item("Campo13") = ""
                    Else
                        row.Item("Campo13") = DetalleCompraGridView.Rows(i - 1).Cells("CODIGOPROD").Value
                    End If

                    If i = 1 Then
                        row.Item("Campo6") = drdatoscli("RUC_CIN")
                        row.Item("Campo4") = drdatoscli("NOMBRE")
                        row.Item("Campo8") = drdatoscli("DIRECCION")
                        row.Item("Fecha1") = FechaFactTextBox.Text

                        row.Item("Campo9") = drdetpc("TIMBRADO")
                        row.Item("Campo10") = f.FuncionConsultaString("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)
                        row.Item("Fecha2") = drdetpc("FECHAVALIDEZ")

                        row.Item("Campo11") = nrofactura
                    End If
                    '#####################################################################################

                    '########### campos numericos ##########################################################

                    If i > c Then
                        ' row.Item("NUMERO1") = Nothing
                    Else
                        row.Item("NUMERO1") = DetalleCompraGridView.Rows(i - 1).Cells("CANTIDADCOMPRA").Value
                    End If

                    If i > c Then
                        ' row.Item("NUMERO2") = Nothing
                    Else
                        row.Item("NUMERO2") = DetalleCompraGridView.Rows(i - 1).Cells("COSTOUNITARIO").Value
                    End If

                    'Dim IVA As Decimal
                    If i > c Then

                    Else
                        ' IVA = DetalleCompraGridView.Rows(i - 1).Cells("IVADataGridViewTextBoxColumn").Value
                        row.Item("NUMERO5") = DetalleCompraGridView.Rows(i - 1).Cells("SUBTOTAL").Value
                    End If

                    '#####################################################################################

                    'row.Item("NUMERO6") = totalcinco
                    'row.Item("NUMERO7") = totaldiez
                    'row.Item("NUMERO8") = totaldiez + totalcinco
                    row.Item("NUMERO9") = FormatNumber(TotalTextBox1.Text, 0)

                    'row.Item("NUMERO11") = TotalItems5
                    'row.Item("NUMERO12") = TotalItems10
                    'row.Item("NUMERO10") = TotalItemsExento
                    'row.Item("Campo14") = "OBSERVACIONES: " + drdatoscli("MOTIVODESCUENTO")
                    row.Item("Campo2") = Funciones.Cadenas.NumeroaLetras(FormatNumber(TotalTextBox1.Text, 0))

                    ds.Tables("Detalle").Rows.Add(row)
                Next

                diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0
                TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0
            Next

        Catch ex As Exception
            MessageBox.Show("Error")
        End Try

        Return ds
    End Function
    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        Dim s As String = ""
        doctoprint.PrinterSettings.PrinterName = PrinterName '(ex."EpsonSQ-1170ESC/P2")
        For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function
    Private Sub ImprimirAutoFacturaTicket()
        'ds.Clear()
        Dim ticket As New BarControls.Ticket
        Dim TotalItems5, TotalItems10, Subtotallinea, TotalItemsExento As Decimal
        Dim Total5, Total10 As Integer
        TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0 : Total5 = 0 : Total10 = 0
        '#########################################################################################################################

        Dim Codigo, DescripcionProducto, Cantidad, Precio, Proveedor As String
        Dim Empresa, RucEmpresa, Sucursal, DirSuc, CiudadSuc, TelSuc As String

        Codigo = "" : DescripcionProducto = "" : Cantidad = "" : Precio = "" : Subtotallinea = 0
        Empresa = "" : RucEmpresa = "" : Sucursal = "" : DirSuc = "" : CiudadSuc = "" : TelSuc = ""
        Proveedor = ""

        '###################Traer Datos de Sucursal,Empresa y Cliente##############################################################################
        Try
            RucEmpresa = w.FuncionConsultaString2("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)

            cmd.CommandText = "SELECT dbo.CIUDAD.DESCIUDAD, dbo.SUCURSAL.DIRECCION, dbo.SUCURSAL.TELEFONO FROM dbo.SUCURSAL LEFT OUTER JOIN  " & _
                              "dbo.CIUDAD ON dbo.SUCURSAL.CODCIUDAD = dbo.CIUDAD.CODCIUDAD  WHERE (dbo.SUCURSAL.CODSUCURSAL = " & SucCodigo & ")"

            cmd.Connection = New SqlConnection(ser.CadenaConexion)
            cmd.Connection.Open()
            Dim RangoDataReader As SqlDataReader = cmd.ExecuteReader()

            Do While RangoDataReader.Read()
                DirSuc = RangoDataReader("DIRECCION")
                TelSuc = RangoDataReader("TELEFONO")
                CiudadSuc = RangoDataReader("DESCIUDAD")
            Loop
            cmd.Connection.Close()
            Proveedor = RTrim(ProvFactComboBox.Text)

            ' TimbradoFactura = f.FuncionConsultaString("TIMBRADO", "DETPC", "RandoId", RangoID)
            Dim Fechavalidez As String = ""
            Dim dadetpc As New SqlDataAdapter("Select TIMBRADO,FECHAVALIDEZ FROM DETPC WHERE ACTIVO = 1 AND RANDOID=" & RangoID & "", ser.CadenaConexion)
            Dim dtdetpc As New DataTable
            dadetpc.Fill(dtdetpc)
            Dim drdetpc As DataRow
            drdetpc = dtdetpc.Rows(0)

            TimbradoFactura = drdetpc("TIMBRADO")
            Fechavalidez = drdetpc("FECHAVALIDEZ")

        Catch ex As Exception
            cmd.Connection.Close()
            MessageBox.Show("Problema con el Rango Activo: " + ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

        '################Cuerpo del Ticket ########################

        '##########################################################
        'recorta caracteres para centrar

        Empresa = RecortaCaracteres(EmpNomFantasia)
        Sucursal = RecortaCaracteres(SucDescripcion)
        DirSuc = RecortaCaracteres(DirSuc + "-" + CiudadSuc)
        RucEmpresa = RecortaCaracteres("RUC:" + RucEmpresa)
        TelSuc = RecortaCaracteres("TEL:" + TelSuc)

        ticket.AddHeaderLine(RecortaCaracteres("* * * * * *"))
        ticket.AddHeaderLine("")
        ticket.AddHeaderLine(Empresa)
        ticket.AddHeaderLine(Sucursal)
        ticket.AddHeaderLine(DirSuc)
        ticket.AddHeaderLine(RucEmpresa)
        ticket.AddHeaderLine(TelSuc)
        ticket.AddHeaderLine("================================")
        ' ticket.AddHeaderLine("BOLETA DE VENTA-I.V.A Incluido")
        '##########################################################
        Dim CajeroDesc As String

        CajeroDesc = UsuNombre
        CajeroDesc = RecortaCaracteres2(CajeroDesc)

        ticket.AddHeaderLine("AUTOFACTURA" + " Nº" + NroFacturaMaskedEditBox1.Text)
        ticket.AddHeaderLine("TIMBRADO:" + TimbradoFactura)
        'ticket.AddHeaderLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        ticket.AddHeaderLine("I.V.A Incluido")
        '##########################################################
        ticket.AddSubHeaderLine("FECHA/HORA:" + FechaFactTextBox.Text + " " + DateTime.Now.ToShortTimeString())
        ' ticket.AddSubHeaderLine("CAJA Nº:" + NumCaja.ToString + "  " + "CAJERO:" + CajeroDesc)
        '##########################################################
        Dim i As Integer
        Dim c As Integer = DetalleCompraGridView.RowCount()
        For i = 1 To c
            'Ceramos el SubTotalLinea para no sumar
            Subtotallinea = 0

            DescripcionProducto = DetalleCompraGridView.Rows(i - 1).Cells("DESPRODUCTO").Value
            If DescripcionProducto.Count <= 8 Then
            Else
                DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)
            End If

            Codigo = DetalleCompraGridView.Rows(i - 1).Cells("CODIGOPROD").Value
            If Codigo.Count <= 5 Then
            Else
                Codigo = Codigo.Remove(0, Codigo.Count - 5)
            End If

            Cantidad = DetalleCompraGridView.Rows(i - 1).Cells("CANTIDADCOMPRA").Value
            Precio = DetalleCompraGridView.Rows(i - 1).Cells("COSTOUNITARIO").Value

            Dim IVA As Decimal
            Dim IvaDescrip As String = ""
            If i > c Then

            Else
                IvaDescrip = DetalleCompraGridView.Rows(i - 1).Cells("IVA").Value
                IvaDescrip = Trim(Replace(IvaDescrip, "%", ""))
                IVA = CDec(IvaDescrip)

                If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO5").Value) Then
                Else
                    Total5 = Total5 + (DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO5").Value / 21)
                    TotalItems5 = TotalItems5 + (DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO5").Value)
                    Subtotallinea = Subtotallinea + CDec(DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO5").Value)
                End If

                If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO10").Value) Then
                Else
                    Total10 = Total10 + (DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO10").Value / 11)
                    TotalItems10 = TotalItems10 + (DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO10").Value)
                    Subtotallinea = Subtotallinea + CDec(DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEGRAVADO10").Value)
                End If

                If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value) Then
                Else
                    TotalItemsExento = TotalItemsExento + DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value
                    Subtotallinea = Subtotallinea + CDec(DetalleCompraGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value)
                End If

            End If

            '#####################################################################################

            Precio = Replace(Precio, ".", "")
            Precio = FormatNumber(Precio, 0)
            Subtotallinea = Replace(Subtotallinea, ".", "")
            Dim SubTotString As String = Subtotallinea

            ticket.AddItem(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(4), "", Precio.PadLeft(6) & " " & SubTotString.PadLeft(6))
        Next
        '##########################################################
        ticket.AddTotal(" TOTAL AUTOFACTURA :", FormatNumber(TotalTextBox1.Text, 0))
        ticket.AddTotal("", "")
        ticket.AddTotal("===============================", "=")

        Total10 = Replace(Total10, ".", ",")
        Total5 = Replace(Total5, ".", ",")
        TotalItemsExento = Replace(TotalItemsExento, ".", ",")

        ticket.AddTotal("TOTAL GRAVADA 10% Gs.:", TotalItems10.ToString)
        ticket.AddTotal("TOTAL GRAVADA 5%  Gs.:", TotalItems5.ToString)
        ticket.AddTotal("TOTAL EXENTAS     GS.:", TotalItemsExento)
        ticket.AddTotal("===============================", "=")
        ticket.AddTotal("LIQUIDACION DEL IVA", "")
        ticket.AddTotal("IVA 10% Gs.:", Total10)
        ticket.AddTotal("IVA 5%  Gs.:", Total5)
        ticket.AddTotal("===============================", "=")
        '##########################################################
        ticket.AddFooterLine("CANTIDAD DE ARTICULOS:" + c.ToString)

        ticket.AddFooterLine("RUC PROVEEDOR:" + rucActualProv)
        ticket.AddFooterLine("PROVEEDOR:" + Proveedor)
        ticket.AddFooterLine("")
        ticket.AddFooterLine("================================")

        Try
            ticket.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Problema al Imprimir Autofactura: ", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Public Function RecortaCaracteres(ByVal caracter As String, _
       Optional ByVal longitud As Integer = 32) As String
        Select Case Len(caracter)
            Case Is > longitud
                caracter = caracter.Substring(0, 35)
            Case Is < longitud
                Dim longitudEspacio As Integer
                longitudEspacio = ((longitud - Len(caracter)) / 2) + Len(caracter)
                caracter = caracter.PadLeft(longitudEspacio)
        End Select

        Return caracter
    End Function
    Public Function RecortaCaracteres2(ByVal caracter As String, _
      Optional ByVal longitud As Integer = 14) As String
        Select Case Len(caracter)
            Case Is > longitud
                caracter = caracter.Substring(0, 14)
            Case Is < longitud
                Dim longitudEspacio As Integer
                longitudEspacio = ((longitud - Len(caracter)) / 2) + Len(caracter)
                caracter = caracter.PadLeft(longitudEspacio)
        End Select

        Return caracter
    End Function

    Public Function RecortaCaracteres3(ByVal caracter As String, _
   Optional ByVal longitud As Integer = 39) As String
        Select Case Len(caracter)
            Case Is > longitud
                caracter = caracter.Substring(0, 42)
            Case Is < longitud
                Dim longitudEspacio As Integer
                longitudEspacio = ((longitud - Len(caracter)) / 2) + Len(caracter)
                caracter = caracter.PadLeft(longitudEspacio)
        End Select

        Return caracter
    End Function
    Private Sub CalculaNroAutoFactura()
        Dim conexion As System.Data.SqlClient.SqlConnection
        conexion = ser.Abrir()
        Try
            Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString As String
            Dim NroDigitos As Integer

            NumSucursal = SucCodigo
            NumMaquina = NumMaquinaGlobal
            NroDigitos = f.FuncionConsultaDecimal("NRODIGITOS", "DETPC", "ACTIVO = 1 AND RANDOID", RangoID)

            Dim dadetpc As New SqlDataAdapter("Select CODSUCURSAL, IP, ULTIMO, RANGO2 FROM DETPC WHERE (ULTIMO < RANGO2) AND ACTIVO = 1 AND RANDOID=" & RangoID & "", conexion)
            Dim dtdetpc As New DataTable
            dadetpc.Fill(dtdetpc)
            Dim drdetpc As DataRow
            drdetpc = dtdetpc.Rows(0)

            'Validamos que haya rango para ese TipoComprobante
            NroRango = drdetpc("ULTIMO")
            NroRango = NroRango + 1

            NroRango2 = drdetpc("RANGO2")

            If CDec(NroRango) > CDec(NroRango2) Then
                NumAutoFactura = ""
                'supero el ultimo
                Exit Sub
            End If

            Dim codsuc As Integer = drdetpc("CODSUCURSAL")
            NumSucTimbrado = w.FuncionConsultaString("SUCURSALTIMBRADO", "SUCURSAL", "CODSUCURSAL", codsuc)

            Dim IPMAQ As Integer = drdetpc("IP")
            NumMaquina = w.FuncionConsultaString("NUMMAQUINA", "PC", "IP", IPMAQ)

            NroRangoString = CStr(NroRango)
            Dim i As Integer
            For i = 1 To NroDigitos
                If Len(NroRangoString) = NroDigitos Then
                    Exit For
                Else
                    NroRangoString = "0" & NroRangoString
                End If
            Next

            NumAutoFactura = NumSucTimbrado & "-" & NumMaquina & "-" & NroRangoString
            NroFacturaMaskedEditBox1.Text = NumAutoFactura
            NroFactText.Text = NumAutoFactura

            If NumAutoFactura = "" Then
                MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub ActualizaEstadoCompra(ByVal Estado As Integer, ByVal Cadena As String)
        sql = " "

        If IvaIncluidoTextBox.Text = "2" And Estado = 1 Then
            sql = "INSERT INTO IMPORTACION (OBSERVACION, ESTADO, CODCOMPRA) VALUES ('" & CStr(TextBoxConcepto.Text) & "', " & Estado & ", " & CDec(tbxCodCompras.Text) & ") "
        ElseIf IvaIncluidoTextBox.Text = "2" And Estado = 2 Then
            sql = "UPDATE IMPORTACION SET ESTADO = 2 WHERE CODCOMPRA = " & CDec(tbxCodCompras.Text)
        End If

        sql = sql + "  UPDATE COMPRAS SET ESTADO = " & Estado & ",  " & Cadena & " WHERE CODCOMPRA = " & CDec(tbxCodCompras.Text) & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub BtnCerrarAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarAprobar.Click
        TableLayoutPanel9.BringToFront()
        btnModificarNroFactura.BringToFront()
        PanelConceptoCompras.SendToBack()
    End Sub

    Private Sub PictureBoxMotivoAnulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxMotivoAnulacion.Click
        PanelAnular.BringToFront()
        PanelAnular.Enabled = True
        tsMotivoAnulacion.Enabled = True
        BtnAnular.Enabled = True
        TextBoxAnulacionConcepto.Enabled = True
        TextBoxAnulacionConcepto.Focus()
    End Sub

    Private Sub BtnCerrarAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarAnular.Click
        TableLayoutPanel9.BringToFront()
    End Sub

    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        permiso = PermisoAplicado(UsuCodigo, 24)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para ANULAR", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            If TextBoxAnulacionConcepto.Text = "" Then
                MessageBox.Show("Ingrese el Motivo de Anulación", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBoxAnulacionConcepto.Focus()
                Exit Sub
            End If

            Me.Cursor = Cursors.AppStarting

            If Not IsDBNull(ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value) And ComprasSimpleGridView1.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 0 Then
                If ComprasSimpleGridView1.CurrentRow.Cells("ORDCOMPRA").Value = 1 And ComprasSimpleGridView1.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 0 Then
                    Dim transaction As SqlTransaction = Nothing

                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans

                    Try
                        '1 - Cambiamos de Estado la Factura de Compras
                        ActualizaEstadoCompra(2, "MOTIVOANULADO = '" & TextBoxAnulacionConcepto.Text & "'")
                        myTrans.Commit()

                    Catch ex As Exception
                        MessageBox.Show("Problema al Anular: " & ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Arrow
                    Finally
                        sqlc.Close()
                    End Try
                ElseIf txtEstado.Text = 1 Then
                    AnularFactura()
                End If
            ElseIf txtEstado.Text = 1 Then
                AnularFactura()
            End If
        End If

        Dim I As Integer = COMPRASBindingSource.Position

        If rbtvertodo.Checked = True Then
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If
        If rbtverOC.Checked = True Then
            rbtverOC_CheckedChanged(Nothing, Nothing)
        End If
        If rbtVerfacturas.Checked = True Then
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)
        End If

        COMPRASBindingSource.Position = I
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AnularFactura()
        Dim ExistePago As Integer

        'VALIDACIONES DE ANULACIONES, COMO SI SE PAGO Y SI CARGO UNA RAZON. 
        ExistePago = w.FuncionConsulta("CODCOMPRA", "FACTURAPAGAR", "PAGADO = 1 AND CODCOMPRA", CDec(tbxCodCompras.Text))

        If ExistePago <> 0 Then
            If MessageBox.Show("Esta compra tiene Pagos realizados , ¿Esta seguro que la desea Anular?", "Cogent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        'Anular la COMPRA
        Dim transaction As SqlTransaction = Nothing

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            '1 - Cambiamos de Estado la Factura de Compras
            ActualizaEstadoCompra(2, "MOTIVOANULADO = '" & TextBoxAnulacionConcepto.Text & "'")
            sql = "DELETE FROM FACTURAPAGAR WHERE CODCOMPRA =" & CDec(tbxCodCompras.Text) & "  "
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            CambiosRegistroCosteble()
            DescuentaStock()
            myTrans.Commit()

        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch

            End Try
            MessageBox.Show("Problema al Anular: " & ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
        Finally
            sqlc.Close()
        End Try


        '################################################################################################################
        'Anular Compra, Ceramos los asientos creados. By Yolanda Zelaya
        AnularAsientos(CDec(tbxCodCompras.Text), 3)
        '################################################################################################################
    End Sub
    Private Sub CambiosRegistroCosteble()
        Dim c As Integer = DetalleCompraGridView.RowCount
        Dim CODCODIGO, CODPRODUCTO, i As Integer

        For i = 1 To c
            EnlazadoProductos = w.FuncionConsulta("ENLAZADO", "CENTROCOSTO", "CODCENTRO", DetalleCompraGridView.Rows(i - 1).Cells("CODCENTRO").Value)
            If EnlazadoProductos = 1 Then
                'Veririficamos
                If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("CODPRODUCTO").Value) Then
                Else
                    CODCODIGO = CDec(DetalleCompraGridView.Rows(i - 1).Cells("CODCODIGO").Value)
                    CODPRODUCTO = DetalleCompraGridView.Rows(i - 1).Cells("CODPRODUCTO").Value

                    'Insertamos Movimiento del Stock
                    sql = ""
                    sql = "UPDATE MOVPRODUCTO SET COSTEABLE=0 WHERE CODCODIGO=" & CODCODIGO & " AND CODDEPOSITO=" & CmbDeposito.SelectedValue & " AND MODULOTRANSID=" & CDec(CodCompraTextBox.Text) & _
                          " AND MODULO=3 "

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
            End If
        Next
    End Sub
    Private Sub DescuentaStock()
        Dim c As Integer = DetalleCompraGridView.RowCount
        Dim CODCODIGO, CODPRODUCTO, i As Integer
        Dim precio As String
        Dim CANDPROD As Double

        For i = 1 To c
            EnlazadoProductos = w.FuncionConsulta("ENLAZADO", "CENTROCOSTO", "CODCENTRO", DetalleCompraGridView.Rows(i - 1).Cells("CODCENTRO").Value)
            If EnlazadoProductos = 1 Then
                'Veririficamos
                If IsDBNull(DetalleCompraGridView.Rows(i - 1).Cells("CODPRODUCTO").Value) Then
                Else
                    'Obtenemos el codigo del StockDeposito
                    CODCODIGO = CDec(DetalleCompraGridView.Rows(i - 1).Cells("CODCODIGO").Value)
                    CODPRODUCTO = DetalleCompraGridView.Rows(i - 1).Cells("CODPRODUCTO").Value

                    CANDPROD = CDec(DetalleCompraGridView.Rows(i - 1).Cells("CANTIDADCOMPRA").Value)
                    CANDPROD = Replace(CANDPROD, ",", ".")


                    precio = DetalleCompraGridView.Rows(i - 1).Cells("COSTOUNITARIO").Value
                    precio = Replace(precio, ",", ".")

                    Dim hora As String = Now.ToString("HH:mm:ss")
                    Dim Concat As String = FechaFactTextBox.Text
                    Dim Concatenar As String = Concat & " " + hora

                    'Insertamos Movimiento del Stock
                    sql = ""
                    sql = "INSERT INTO MOVPRODUCTO " & _
                      "(CODCODIGO,CONCEPTO,CANTIDAD,FECHAMOVIMIENTO,CODUSUARIO, CODDEPOSITO,MODULO,STOCK,COSTEABLE,VALOR,MODULOTRANSID)" & _
                      " VALUES (" & CODCODIGO & ",'Anulación Compra Nro. " & NroFacturaMaskedEditBox1.Text & "', -" & CANDPROD & ", CONVERT(DATETIME, '" & Concatenar & "',103)," & _
                      "" & UsuCodigo & "," & CmbDeposito.SelectedValue & ",3,1,1," & precio & "," & CDec(CodCompraTextBox.Text) & " ) "

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
            End If
        Next
    End Sub


#End Region 'Methods

    Private Sub TipoCompComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TipoCompComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbEvento.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub PictureBoxCuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCuotas.Click
        Me.FACTURAPAGARTableAdapter.Fill(Me.DsPagos.FACTURAPAGAR)
        PanelCuota.Visible = True
        PanelCuota.BringToFront()

        dttFechaPrimeraCuota.Focus()
        lblCambiarCredito.Visible = False

        If GridViewCuotas.RowCount > 0 Then 'Tiene cuotas generadas
            If txtEstado.Text = "0" Or txtEstado.Text = "1" Or txtEstado.Text = "3" Then
                Me.FACTURAPAGARTableAdapter.Fill(Me.DsPagos.FACTURAPAGAR)
                btnPagosGenerarCuotas.Enabled = False
                btnLimpiarCuotas.Enabled = False
                btGuardarCuotas.Enabled = False
                Me.dttFechaPrimeraCuota.Enabled = False
                tbxCantidadPagos.Enabled = False
                tbxPagoDias.Enabled = False

                If CmbTipoFactura.Text = "Contado" Then
                    Me.btnCambiarFecha.Visible = True
                    btnCambiarFecha.Enabled = True
                    btnCambiarFecha.Text = "Cambiar a Crédito"
                Else
                    Me.btnCambiarFecha.Visible = True
                    btnCambiarFecha.Enabled = True
                    btnCambiarFecha.Text = "Cambiar a Contado"
                End If

            ElseIf txtEstado.Text = "2" Then
                Me.btnCambiarFecha.Visible = False
            End If
        Else ' No tiene cuotas generadas
            If txtEstado.Text = "0" Or txtEstado.Text = "1" Then
                btnPagosGenerarCuotas.Enabled = True
                btnLimpiarCuotas.Enabled = True
                btGuardarCuotas.Enabled = True
                Me.dttFechaPrimeraCuota.Enabled = True
                tbxCantidadPagos.Enabled = True
                tbxPagoDias.Enabled = True

                Me.btnCambiarFecha.Visible = False
            End If
        End If

    End Sub

    Private Sub btCerrarPanelCuota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCerrarPanelCuota.Click
        PanelCuota.Visible = False
    End Sub

    Private Sub TxtCantCuotas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCantidadPagos.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxPagoDias.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub TxtPeriodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxPagoDias.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnPagosGenerarCuotas.Focus()
            KeyAscii = 0
        End If

    End Sub

    Private Sub btGuardarCuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardarCuotas.Click
        If GridViewCuotas.RowCount = 0 Then
            MessageBox.Show("Debe Generar las cuotas antes de guardarlas", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            Dim existe As Integer

            existe = w.FuncionConsulta("CODCOMPRA", "COMPRAS", "CODCOMPRA", tbxCodCompras.Text)

            If existe > 0 Then

                conexion = ser.Abrir()

                Try
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    Try
                        ActualizaPagos(myTrans) ' Inserta en la tabla facturacobrar(cuotas)

                        myTrans.Commit()
                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Actualizar")
                        Catch
                        End Try

                        Throw ex
                    End Try
                    lblComprasEstado.Text = "Cuotas Guardadas!"

                Catch ex As Exception

                    MessageBox.Show("Problema al Guardar Cuota: " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lblComprasEstado.Text = "Error al Guardar Cuota!"
                Finally
                    conexion.Close()
                End Try
            Else
                MessageBox.Show("Debe guardar la factura para guardar las cuotas", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            PanelCuota.Visible = False
            Me.FACTURAPAGARTableAdapter.Fill(DsPagos.FACTURAPAGAR)

            If Config9 = "Ver Ordenes de Compra" Then
                rbtverOC.Checked = True
                rbtverOC_CheckedChanged(Nothing, Nothing)
            ElseIf Config9 = "Ver Facturas" Then
                rbtVerfacturas.Checked = True
                rbtVerfacturas_CheckedChanged(Nothing, Nothing)
            Else
                rbtvertodo.Checked = True
                rbtvertodo_CheckedChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub ActualizaPagos(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection

        conexion = ser.Abrir()

        Dim c As Integer = GridViewCuotas.RowCount
        If c = 0 Then
            Exit Sub
        End If
        Dim w As New Funciones.Funciones
        Dim Existe, Codnrocuota, Codcompra, importe, fecha, saldocuota, destipocobro, tipofactura As String
        Dim i As Integer
        For i = 1 To c

            Codcompra = CDec(GridViewCuotas.Rows(i - 1).Cells("CODCOMPRADataGridViewTextBoxColumn1").Value)
            Codnrocuota = CDec(GridViewCuotas.Rows(i - 1).Cells("NUMEROCUOTADataGridViewTextBoxColumn").Value)
            destipocobro = GridViewCuotas.Rows(i - 1).Cells("DESTIPOPAGODataGridViewTextBoxColumn").Value

            importe = GridViewCuotas.Rows(i - 1).Cells("IMPORTECUOTADataGridViewTextBoxColumn").Value
            importe = Funciones.Cadenas.QuitarCad(importe, ".")
            importe = Replace(importe, ",", ".")

            saldocuota = GridViewCuotas.Rows(i - 1).Cells("SALDOCUOTADataGridViewTextBoxColumn").Value
            saldocuota = Funciones.Cadenas.QuitarCad(saldocuota, ".")
            saldocuota = Replace(saldocuota, ",", ".")

            fecha = CDate(GridViewCuotas.Rows(i - 1).Cells("FECHAVCTODataGridViewTextBoxColumn").Value).ToShortDateString
            tipofactura = GridViewCuotas.Rows(i - 1).Cells("TIPOFACTURADataGridViewTextBoxColumn").Value

            '############################################################################
            'preguntamos si existe el detalle para saber si actualizar o insertar

            Existe = w.FuncionConsultaString("NUMEROCUOTA", "FACTURAPAGAR", "NUMEROCUOTA = " & Codnrocuota & " " & _
                                             "AND CODCOMPRA", Codcompra.ToString)
            Dim hora As String = Now.ToString("HH:mm:ss")
            'Dim Concat As String = FechaFactTextBox.Value
            Dim Concatenar As String = fecha & " " + hora
            If Existe <> Nothing Then

                consulta = "UPDATE FACTURAPAGAR SET FECHAVCTO =CONVERT(DATETIME,'" & Concatenar & "',103)," & _
                "IMPORTECUOTA=" & importe & ",SALDOCUOTA=" & saldocuota & "," & _
                "DESTIPOPAGO='" & destipocobro & "', COTIZACION = " & CInt(tbxCompraCotizacion.Text) & " " & _
                "WHERE NUMEROCUOTA = " & Codnrocuota & " AND  CODCOMPRA = " & Codcompra & " "

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
                '################AUDITORIA########################
            Else

                consulta = "INSERT INTO FACTURAPAGAR (NUMEROCUOTA,CODUSUARIO,CODEMPRESA,CODCOMPRA,FECHAVCTO,SALDOCUOTA,IMPORTECUOTA,FECGRA,PAGADO,DESTIPOPAGO,TIPOFACTURA, COTIZACION) " & _
                "VALUES ( " & Codnrocuota & "," & UsuCodigo & "," & EmpCodigo & " , " & _
                "" & Codcompra & ",CONVERT(DATETIME,'" & Concatenar & "',103)," & saldocuota & "," & importe & " ,GETDATE(),0,'" & destipocobro & "','" & tipofactura & "', " & CInt(tbxCompraCotizacion.Text) & "  ) "

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
            End If
        Next
    End Sub

    Private Sub IngresarCotCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarCotCheckBox.CheckedChanged

        If IngresarCotCheckBox.Checked = True And txtEstado.Text = "3" Then
            tbxCompraCotizacion.Enabled = True
            tbxCompraCotizacion.Focus()
        Else
            tbxCompraCotizacion.Enabled = False
        End If
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Dim html As String = "http://www.cogentpotential.com/soporte/compras/comprasplus"
        Shell("Explorer " & html)
    End Sub

    Private Sub CmbTipoFactura_LostFocus(sender As Object, e As System.EventArgs) Handles CmbTipoFactura.LostFocus
        If CmbTipoFactura.Text = "" Then
            CmbTipoFactura.SelectedIndex = CmbTipoFactura.SelectedIndex + 1
        End If
    End Sub

    Private Sub CmbDeposito_LostFocus(sender As Object, e As System.EventArgs) Handles CmbDeposito.LostFocus
        If CmbDeposito.Text = "" Then
            CmbDeposito.SelectedIndex = CmbTipoFactura.SelectedIndex + 1
        End If
    End Sub

    Private Sub pbxImprimirOrden_Click(sender As System.Object, e As System.EventArgs) Handles pbxProductos.Click
        permiso = PermisoAplicado(UsuCodigo, 54)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Producto.Show()
            Producto.Opacity = 1
            Producto.BuscaProductoTextBox.Focus()
        End If
    End Sub

    Private Sub btnLimpiarCuotas_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarCuotas.Click
        Dim i As Integer
        For i = 1 To GridViewCuotas.Rows.Count
            GridViewCuotas.Rows.RemoveAt(GridViewCuotas.Rows.Count - 1)
        Next
    End Sub

    Private Sub dgvProveedor_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProveedor.CellDoubleClick
        If dgvProveedor.RowCount = 0 Then
            TxtBuscaProveedor.Text = ""
            Exit Sub
        Else
            If IsDBNull(dgvProveedor.CurrentRow.Cells("CODPROVEEDOR").Value) Then
            Else
                proveedorActual = dgvProveedor.CurrentRow.Cells("CODPROVEEDOR").Value
            End If
            If IsDBNull(dgvProveedor.CurrentRow.Cells("NUMPROVEEDOR").Value) Then
            Else
                numeroProvActual = dgvProveedor.CurrentRow.Cells("NUMPROVEEDOR").Value
            End If
            If IsDBNull(dgvProveedor.CurrentRow.Cells("NOMBRE").Value) Then
            Else
                nombreProvActual = dgvProveedor.CurrentRow.Cells("NOMBRE").Value
            End If
            If IsDBNull(dgvProveedor.CurrentRow.Cells("RUC_CIN").Value) Then
            Else
                rucActualProv = dgvProveedor.CurrentRow.Cells("RUC_CIN").Value
            End If
            If IsDBNull(dgvProveedor.CurrentRow.Cells("MASCARA2").Value) Then
            Else
                mascaraActual = dgvProveedor.CurrentRow.Cells("MASCARA2").Value
            End If

            If Config10 = "No" Then
                Me.txtTimbrado.Text = ""
            Else
                If IsDBNull(dgvProveedor.CurrentRow.Cells("TIMBRADOFACTURA2").Value) Then
                Else
                    timbradoActual = dgvProveedor.CurrentRow.Cells("TIMBRADOFACTURA2").Value
                    Me.txtTimbrado.Text = dgvProveedor.CurrentRow.Cells("TIMBRADOFACTURA2").Value
                End If
            End If

            ProvFactComboBox.Text = nombreProvActual
        End If
        RadGroupBoxProveedor.Visible = False
        IsKeyPress = 0
        ProvFactComboBox.Focus()
    End Sub


    Private Sub TotalTextBox1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If btNuevo <> 1 Then
            PanelRedondeo.Visible = True
            PanelRedondeo.BringToFront()
            tbxRedondeo.Focus()
        End If
    End Sub

    Private Sub tbxRedondeo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbxRedondeo.KeyDown
        If e.KeyCode = Keys.Escape Then
            PanelRedondeo.Visible = False
            PanelRedondeo.SendToBack()
            CancelarPictureBox_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tbxRedondeo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxRedondeo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim Desc, i, Diferencia, redondeo1 As Integer
        Dim Porc, SubtotDesc, ValSubt As Double
        Dim PrecioDescontado As Double
        Dim vIva5, vIva10, vExcenta, tviejo As Double
        Dim vImporteGrab5, vImporteGrab10, vImporteExcento, TipoIva As String
        Dim TIva5, TIva10, TExcento, TIva, TGrab10, TGrab5 As String

        If KeyAscii = 13 Then
            tviejo = TotalTextBox1.Text
            redondeo1 = tbxRedondeo.Text
            PanelRedondeo.Visible = False
            Me.tbxRedondeo.Text = ""
            GuardarPictureBox.Focus()
            KeyAscii = 0

            '********************************************************************* SAUL
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            '1RO DESCONTAMOS DEL MONTO TOTAL
            vIva5 = 0 : vIva10 = 0 : vExcenta = 0 : TIva = "" : TIva5 = "" : TIva10 = "" : TGrab10 = "" : TGrab5 = "" : vgDescuento = 0 : Diferencia = 0

            Desc = CDec(tviejo) - CDec(redondeo1) 'Guarda el descuento aplicado en Efectivo, se hace la conversion 
            Diferencia = CDec(tviejo) - CDec(redondeo1)

            For i = 0 To DetalleCompraGridView.RowCount - 1
                ValSubt = 0 : PrecioDescontado = 0 : vImporteGrab5 = "0" : vImporteGrab10 = "0" : vImporteExcento = "0"

                ValSubt = CDec(DetalleCompraGridView.Rows(i).Cells("SUBTOTAL").Value)
                Porc = CDec((ValSubt * 100) / CDec(tviejo))
                SubProc = CDec((Diferencia * Porc) / 100)
                Desc = Desc - SubProc
                SubtotDesc = ValSubt - SubProc 'Restamos del subtotal el descuento a aplicar
                PrecioDescontado = SubtotDesc / CDec(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value)
                '   PrecioDescontado = Math.Round(PrecioDescontado)

                'Guardamos en la base de datos el nuevo valor del subtotal con los nuevos datos del IVA - VENTASDETALLE
                Try
                    Dim subTotalString As String = Replace(PrecioDescontado, ",", ".")
                    Dim LineaNro As String = DetalleCompraGridView.Rows(i).Cells("LINEANROCOMPRA").Value
                    TipoIva = DetalleCompraGridView.Rows(i).Cells("TIPOIVA").Value

                    If TipoIva = "5.00" Then
                        vImporteGrab5 = PrecioDescontado * CDec(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value)
                        vImporteGrab10 = 0 : vImporteExcento = 0

                        vIva5 = vIva5 + CDec(vImporteGrab5)

                    ElseIf TipoIva = "10.00" Then
                        vImporteGrab10 = PrecioDescontado * CDec(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value)
                        vImporteGrab5 = 0 : vImporteExcento = 0

                        vIva10 = vIva10 + CDec(vImporteGrab10)

                    ElseIf TipoIva = "0.00" Then
                        vImporteExcento = PrecioDescontado * CDec(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value)
                        vImporteGrab5 = 0 : vImporteGrab10 = 0

                        vExcenta = vExcenta + CDec(vImporteExcento)
                    End If

                    sql = "UPDATE COMPRASDETALLE SET  COSTOUNITARIO = " & subTotalString & ", IMPORTEGRAVADO5 = " & Replace(vImporteGrab5, ",", ".") & ", IMPORTEGRAVADO10 = " & Replace(vImporteGrab10, ",", ".") & ", " & _
                          "IMPORTEEXENTO = " & Replace(vImporteExcento, ",", ".") & "  WHERE LINEANROCOMPRA = " & LineaNro & "  "

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            Next

            'Obtenemos los datos de las Grabadas
            TGrab10 = vIva10 : TGrab10 = Replace(TGrab10, ",", ".")
            TGrab5 = vIva5 : TGrab5 = Replace(TGrab5, ",", ".")

            'Obtenemos los nuevos datos para el iva
            For i = 0 To dtIva.Rows.Count - 1
                dr2 = dtIva.Rows(i)
                If dr2("PORCENTAJEIVA") = "5,00" Then
                    coheficiente = dr2("COHEFICIENTE")
                    vIva5 = vIva5 / 21 'CAMBIAR EL COHEFICIENTE
                ElseIf dr2("PORCENTAJEIVA") = "10,00" Then
                    coheficiente = dr2("COHEFICIENTE")
                    vIva10 = vIva10 / 11 'CAMBIAR EL COHEFICIENTE
                End If
            Next

            'Guardamos en Nuevo Valor de la Compra y el Descuento Aplicado.
            '  If btModificar = 1 Then
            Try
                Dim NuevoTotal As String = CDec(TotalTextBox1.Text) - CDec(Diferencia)
                NuevoTotal = Replace(NuevoTotal, ",", ".")

                TIva5 = vIva5 : TIva5 = Replace(TIva5, ",", ".")
                Iva5TextBox1.Text = TIva5
                TIva10 = vIva10 : TIva10 = Replace(TIva10, ",", ".")
                Iva10TextBox1.Text = TIva10
                TIva = vIva10 + vIva5 : TIva = Replace(TIva, ",", ".")
                umeTotalIva.Text = TIva
                TExcento = vExcenta : TExcento = Replace(TExcento, ",", ".")
                TotalExentaTextBox1.Text = TExcento
                Dim posi As String = ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

                sql = ""
                sql = "UPDATE COMPRAS SET TOTALCOMPRA = " & NuevoTotal & ", TOTALDESCUENTO = " & CDec(Desc) & " , TOTALIVA10 = " & TIva10 & ", " & _
                      "TOTALIVA5 = " & TIva5 & " , TOTALIVA = " & TIva & ", TOTALEXENTA = " & TExcento & " , TOTALGRAVADO10 = " & TGrab10 & " , TOTALGRAVADO5 = " & TGrab5 & _
                      "  WHERE CODCOMPRA = " & CDec(posi) & ""

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                TotalTextBox1.Text = NuevoTotal

                'si la compra ya esta aprobada debemos actualizar TOTALAPAGAR
                If ComprasSimpleGridView1.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = "1" Then
                    Dim objCommand As New SqlCommand
                    Try
                        objCommand.CommandText = "SELECT SALDOCUOTA, IMPORTECUOTA, PAGADO FROM dbo.FACTURAPAGAR " & _
                            "WHERE (PAGADO = 0) AND (SALDOCUOTA = IMPORTECUOTA) AND (CODCOMPRA = " & compra & ") "

                        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                        objCommand.Connection.Open()
                        Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                        If odrConfig.HasRows Then
                            Do While odrConfig.Read()
                                sql = "UPDATE FACTURAPAGAR SET SALDOCUOTA = " & NuevoTotal & ", IMPORTECUOTA = " & NuevoTotal & ", COTIZACION = " & CInt(tbxCompraCotizacion.Text) & "  WHERE CODCOMPRA = " & compra

                                cmd.CommandText = sql
                                cmd.ExecuteNonQuery()
                            Loop
                        End If

                        odrConfig.Close()
                        objCommand.Dispose()
                    Catch ex As Exception
                    End Try
                End If

            Catch ex As Exception
                If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                    MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Finally
                sqlc.Close()
            End Try

            pnlDescuento.SendToBack()
            btNuevo = 0 : btModificar = 0

            compra = Me.ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

            FechaFiltro()
            BtnFiltro_Click(Nothing, Nothing)

            'Buscamos la posicion del registro guardado
            For k = 0 To ComprasSimpleGridView1.RowCount - 1
                If ComprasSimpleGridView1.Rows(k).Cells("CODCOMPRA").Value = compra Then
                    COMPRASBindingSource.Position = k
                End If
            Next
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles pbxBuscarProveedor.Click
        PROVEEDORBindingSource1.RemoveFilter()
        RadGroupBoxProveedor.Visible = True
        RadGroupBoxProveedor.BringToFront()
        TxtBuscaProveedor.Text = ""
        TxtBuscaProveedor.Focus()
        KeyProv = 1
    End Sub

    Private Sub btnModificarNroFactura_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarNroFactura.Click
        permiso = PermisoAplicado(UsuCodigo, 221)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para Modificar el Nro de Factura", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        pnlCabecera.Enabled = True
        ProvFactComboBox.Enabled = False : PbxProveedor.Enabled = False : FechaFactTextBox.Enabled = False : IvaIncluidoComboBox.Enabled = False
        TipoCompComboBox.Enabled = False : CmbEvento.Enabled = False : CmbTipoFactura.Enabled = False : CmbDeposito.Enabled = False : IngresarCotCheckBox.Enabled = False
        cbxComprasMoneda.Enabled = False : cbxMetodo.Enabled = False

        NroFacturaMaskedEditBox1.Focus()

        btnModificarNroFactura.Visible = False
        btnGuardarNroFactura.Visible = True : btnGuardarNroFactura.Enabled = True
        btnCancelarFactura.Visible = True : btnCancelarFactura.Enabled = True
    End Sub

    Private Sub btnCancelarFactura_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarFactura.Click
        btnGuardarNroFactura.Visible = False : btnCancelarFactura.Visible = False : btnModificarNroFactura.Visible = True

        Deshabilitamos()
        If rbtvertodo.Checked = True Then
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If
        If rbtverOC.Checked = True Then
            rbtverOC_CheckedChanged(Nothing, Nothing)
        End If
        If rbtVerfacturas.Checked = True Then
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnGuardarNroFactura_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardarNroFactura.Click
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim consulta As System.String

        conexion = ser.Abrir()
        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        Try
            consulta = "UPDATE COMPRAS SET NUMCOMPRA='" & NroFacturaMaskedEditBox1.Text & "' WHERE CODCOMPRA=" & CDec(Me.tbxCodCompras.Text) & ""
            Consultas.ConsultaComando(myTrans, consulta)

            myTrans.Commit()
        Catch ex As Exception
            MessageBox.Show("No se puedo cambiar el Nro de Factura", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        btnGuardarNroFactura.Visible = False : btnCancelarFactura.Visible = False
        btnModificarNroFactura.Visible = True : pnlCabecera.Enabled = False

        If rbtvertodo.Checked = True Then
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If
        If rbtverOC.Checked = True Then
            rbtverOC_CheckedChanged(Nothing, Nothing)
        End If
        If rbtVerfacturas.Checked = True Then
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsNuevaVenta_Click(sender As System.Object, e As System.EventArgs) Handles tsNuevaCompra.Click
        NuevoPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsEditar.Click
        ModificarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsGuardar.Click
        GuardarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsEliminar_Click(sender As System.Object, e As System.EventArgs) Handles tsEliminar.Click
        EliminarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAprobar_Click(sender As System.Object, e As System.EventArgs) Handles tsAprobar.Click
        BtnImprimir_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsAnular.Click
        PictureBoxMotivoAnulacion_Click(Nothing, Nothing)
    End Sub

    Private Sub tsCancelar_Click(sender As System.Object, e As System.EventArgs) Handles tsCancelar.Click
        CancelarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAyudaOnline_Click(sender As System.Object, e As System.EventArgs) Handles tsAyudaOnline.Click
        Dim soporte As String = "http://www.cogentpotential.com/soporte/compras/comprasplus"
        Shell("Explorer " & soporte)
    End Sub

    Private Sub tsPanelDeCreditos_Click(sender As System.Object, e As System.EventArgs) Handles tsPanelDeCreditos.Click
        PictureBoxCuotas_Click(Nothing, Nothing)
    End Sub

    Private Sub tsCampoDeConcepto_Click_(sender As System.Object, e As System.EventArgs) Handles tsCampoDeConcepto.Click
        PanelConceptoCompras.Visible = True
        PanelConceptoCompras.BringToFront()
    End Sub

    Private Sub tsMotivoAnulacion_Click(sender As System.Object, e As System.EventArgs) Handles tsMotivoAnulacion.Click
        PanelAnular.Visible = True
        PanelAnular.BringToFront()
    End Sub

    Private Sub tsVentanaDeCobros_Click(sender As System.Object, e As System.EventArgs) Handles tsVentanaDePagos.Click
        If txtEstado.Text <> "Para Editar" Then
            PagosV2.BuscarTextBox.Text = ProvFactComboBox.Text
            PagosV2.Show()
        End If
    End Sub

    Private Sub tsPersonalizarVentas_Click(sender As System.Object, e As System.EventArgs) Handles tsPersonalizarCompras.Click
        ABMConfigPosExpress.Show()
        ABMConfigPosExpress.abrirdesde("Compras")
    End Sub

    Private Sub tsDuplicarFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsDuplicarFactura.Click
        permiso = PermisoAplicado(UsuCodigo, 232) ' Duplicar una Factura
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Cogent")
        Else
            Me.Cursor = Cursors.AppStarting

            Me.NroFacturaMaskedEditBox1.Text = ""
            'Si duplica..si o si con la fecha de Hoy
            FechaFactTextBox.Value = Today.ToShortDateString
            btNuevo = 1 : DuplicarContenido = 1

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Dim consulta As String = ""

            consulta = "INSERT INTO COMPRAS(TOTALIVA,TOTALIVA5,TOTALIVA10,TOTALGRAVADA,MODALIDADPAGO,TOTALEXENTA,CODDEPOSITO,TOTALCOMPRA,CODSUCURSAL,ESTADO,CODUSUARIO,FECHACOMPRA,CODCOMPROBANTE,CODPROVEEDOR,CODMONEDA,COTIZACION1,IVAINCLUIDO,COMPRASIMPLE,CODEVENTO,METODO, TOTALGRAVADO10,TOTALGRAVADO5,TIMBRADOPROV,ORDCOMPRA) " & _
                  "SELECT TOTALIVA,TOTALIVA5,TOTALIVA10,TOTALGRAVADA,MODALIDADPAGO,TOTALEXENTA,CODDEPOSITO,TOTALCOMPRA,CODSUCURSAL,0,CODUSUARIO,FECHACOMPRA,CODCOMPROBANTE,CODPROVEEDOR,CODMONEDA,COTIZACION1,IVAINCLUIDO,COMPRASIMPLE,CODEVENTO,METODO,TOTALGRAVADO10,TOTALGRAVADO5,TIMBRADOPROV,0" & _
                  "FROM COMPRAS WHERE CODCOMPRA = " & ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value & "  " & _
                  "SELECT CODCOMPRA FROM COMPRAS WHERE CODCOMPRA = SCOPE_IDENTITY();"

            cmd.CommandText = consulta
            compra = cmd.ExecuteScalar()

            consulta = ""
            consulta = "INSERT INTO COMPRASDETALLE (IMPORTEEXENTO, IMPORTEGRAVADO10, IMPORTEGRAVADO5, FECGRA, CODCOMPRA, LINEANROCOMPRA, CODPRODUCTO, CODCODIGO, CANTIDADCOMPRA, COSTOUNITARIO, IVA,CODCENTRO, DESPRODUCTO, CODSUCURSAL,TIPOIVA) " & _
                  "SELECT IMPORTEEXENTO, IMPORTEGRAVADO10, IMPORTEGRAVADO5, FECGRA," & compra & ", LINEANROCOMPRA, CODPRODUCTO, CODCODIGO, CANTIDADCOMPRA, COSTOUNITARIO, IVA,CODCENTRO, DESPRODUCTO, CODSUCURSAL,TIPOIVA " & _
                  "FROM COMPRASDETALLE WHERE CODCOMPRA = " & ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

            cmd.CommandText = consulta
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            DetalleCompraGridView.Refresh()
            rbtvertodo_CheckedChanged(Nothing, Nothing)

            'Buscamos la posicion del registro guardado
            For k = 0 To ComprasSimpleGridView1.RowCount - 1
                If ComprasSimpleGridView1.Rows(k).Cells("CODCOMPRA").Value = compra Then
                    COMPRASBindingSource.Position = k
                End If
            Next

            COMPRASDETALLETableAdapter.Fill(DsPagos.COMPRASDETALLE, compra)
            DetalleCompraGridView.Refresh()

            TextBoxConcepto.Text = "" : Me.PanelRedondeo.Visible = False : Me.tbxRedondeo.Text = ""
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub tsModificarNroFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsModificarNroFactura.Click
        permiso = PermisoAplicado(UsuCodigo, 233) 'Modificar Nro. Factura ya Aprobada
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Cogent")
        Else
            Dim nvoNumero As String = InputBox("Ingrese el nuevo Nro. de Factura: ", " Modificar Nro. Factura", Me.NroFacturaMaskedEditBox1.Text)
            If nvoNumero <> Me.NroFacturaMaskedEditBox1.Text And nvoNumero <> "" Then
                'modificamos nro. de factura sin validaciones, por el momento
                Try
                    Dim consulta As System.String
                    Dim conexion As System.Data.SqlClient.SqlConnection

                    conexion = ser.Abrir()
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    consulta = "UPDATE COMPRAS SET NUMCOMPRA='" & nvoNumero & "' WHERE CODCOMPRA=" & CDec(Me.tbxCodCompras.Text) & ""
                    Consultas.ConsultaComando(myTrans, consulta)

                    myTrans.Commit()

                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc

                    If rbtvertodo.Checked = True Then
                        rbtvertodo_CheckedChanged(Nothing, Nothing)
                    End If
                    If rbtverOC.Checked = True Then
                        rbtverOC_CheckedChanged(Nothing, Nothing)
                    End If
                    If rbtVerfacturas.Checked = True Then
                        rbtVerfacturas_CheckedChanged(Nothing, Nothing)
                    End If

                    Me.ComprasSimpleGridView1.Refresh()
                Catch ex As Exception
                    'MsgBox(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub tsAplicarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles tsAplicarFiltros.Click
        Dim fechaDesdeEspecial As String
        Dim fechaHastaEspecial As String
        CmbAño.Text = ""
        CmbMes.Text = "Filtros"
        If errorFiltroFecha = 0 And errorfiltrorango = 0 And Trim(tsFiltroFechaE.Text) <> "" And (Trim(tsFiltroRDesde.Text) <> "" Or Trim(tsFiltroRHasta.Text) <> "") Then
            MsgBox("Se introdujeron filtros en Fecha Específica y Rango de Fechas. El Sistema toma por defecto la Fecha Específica", MsgBoxStyle.Information, "Error en Filtro")
        ElseIf Trim(tsFiltroNroProv.Text) <> "" And Trim(tsFiltroNomProv.Text) <> "" Then
            MsgBox("Se introdujeron filtros en Nro. de Cliente y Nombre de Cliente. El Sistema toma por defecto el Nro. de Cliente", MsgBoxStyle.Information, "Error en Filtro")
        End If
        If Trim(tsFiltroFechaE.Text) <> "" Then
            If errorFiltroFecha = 0 Then
                fechaDesdeEspecial = tsFiltroFechaE.Text + " 00:00:00"
                fechaHastaEspecial = tsFiltroFechaE.Text + " 23:59:00"
            Else
                GoTo todasfechas
            End If
        Else
            If Trim(tsFiltroRDesde.Text) <> "" And Trim(tsFiltroRHasta.Text) <> "" And errorfiltrorango = 0 Then
                If errorfiltrorango = 0 Then
                    fechaDesdeEspecial = tsFiltroRDesde.Text + " 00:00:00"
                    fechaHastaEspecial = tsFiltroRHasta.Text + " 23:59:00"
                Else
                    GoTo todasfechas
                End If
            ElseIf Trim(tsFiltroRDesde.Text) <> "" Or Trim(tsFiltroRHasta.Text) <> "" Then
                MsgBox("Falta Especificar una Fecha del Rango", MsgBoxStyle.Information, "Error en Filtro")
                Exit Sub
            Else
todasfechas:
                fechaDesdeEspecial = "01/01/1900 00:00:00"
                fechaHastaEspecial = "31/12/2900 23:59:00"
            End If
        End If

        FechaFiltro1 = fechaDesdeEspecial
        FechaFiltro2 = fechaHastaEspecial

        If rbtvertodo.Checked = True Then
            FechaFiltro()
            COMPRASTableAdapter.Fill(DsPagos.COMPRAS, "%", fechaDesdeEspecial, fechaHastaEspecial)
            PintarCeldas()
            lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
        End If
        If rbtverOC.Checked = True Then
            FechaFiltro()
            COMPRASTableAdapter.FillBy1(DsPagos.COMPRAS, "%", fechaDesdeEspecial, fechaHastaEspecial, 1)
            PintarCeldas()
            lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
        End If
        If rbtVerfacturas.Checked = True Then
            FechaFiltro()
            COMPRASTableAdapter.FillBy1(DsPagos.COMPRAS, "%", fechaDesdeEspecial, fechaHastaEspecial, 0)
            PintarCeldas()
            lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
        End If

        If Trim(tsFiltroNroProv.Text) <> "" Then
            COMPRASBindingSource.Filter = "NUMPROVEEDOR = " & Trim(tsFiltroNroProv.Text)
        Else
            If Trim(tsFiltroNomProv.Text) <> "" Then
                COMPRASBindingSource.Filter = "PROVEEDOR like '%" & Trim(tsFiltroNomProv.Text) & "%'"
            End If
        End If
        lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
    End Sub

    Private Sub tsLimpiarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles tsLimpiarFiltros.Click
        tsFiltroFechaE.Text = "" : tsFiltroFechaE.BackColor = SystemColors.Window
        tsFiltroRDesde.Text = "" : tsFiltroRDesde.BackColor = SystemColors.Window
        tsFiltroRHasta.Text = "" : tsFiltroRHasta.BackColor = SystemColors.Window
        tsFiltroNroProv.Text = ""
        tsFiltroNomProv.Text = ""
        InicializaFechaFiltro()
        If CmbMes.Text = "Filtros" Then
            CmbMes.SelectedIndex = Today.Month - 1
        End If
        If CmbAño.Text = "" Then
            CmbAño.SelectedText = Today.Year.ToString
        End If

        BtnFiltro_Click(Nothing, Nothing)
    End Sub

    Private Sub tsFiltroNroCliente_TextChanged(sender As Object, e As System.EventArgs) Handles tsFiltroNroProv.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(tsFiltroNroProv.Text, "^\d*$") Then
            tsFiltroNroProv.Text = tsFiltroNroProv.Text.Remove(tsFiltroNroProv.Text.Length - 1)
            tsFiltroNroProv.SelectionStart = tsFiltroNroProv.Text.Length
        End If
    End Sub

    Private Sub tsFiltroFechaE_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroFechaE.LostFocus
        If Trim(tsFiltroFechaE.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroFechaE.Text)
                errorFiltroFecha = 0
                tsFiltroFechaE.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroFecha = 1
                MsgBox("El Sistema no tomará el Filtro Fecha Específica. Por Favor Ingrese una Fecha válida", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroFechaE.BackColor = Color.Pink
                'tsFiltroFechaE.Focus() no funciona
            End Try
        ElseIf errorFiltroFecha = 1 Then
            errorFiltroFecha = 0
            tsFiltroFechaE.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub tsFiltroRDesde_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroRDesde.LostFocus
        If Trim(tsFiltroRDesde.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroRDesde.Text)
                errorfiltrorango = 0
                tsFiltroRDesde.BackColor = SystemColors.Window
            Catch ex As Exception
                errorfiltrorango = 1
                MsgBox("El Sistema no tomará el Filtro Rango de Fechas. Por Favor Ingrese una Fecha válida en Fecha Desde", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroRDesde.BackColor = Color.Pink
            End Try
        ElseIf errorfiltrorango = 1 Then
            errorfiltrorango = 0
            tsFiltroRDesde.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub tsFiltroRHasta_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroRHasta.LostFocus
        If Trim(tsFiltroRHasta.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroRHasta.Text)
                errorfiltrorango = 0
                tsFiltroRHasta.BackColor = SystemColors.Window
            Catch ex As Exception
                errorfiltrorango = 1
                MsgBox("El Sistema no tomará el Filtro Rango de Fechas. Por Favor Ingrese una Fecha válida en Fecha Hasta", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroRHasta.BackColor = Color.Pink
            End Try
        ElseIf errorfiltrorango = 1 Then
            errorfiltrorango = 0
            tsFiltroRHasta.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub btnModTimbrado_Click(sender As System.Object, e As System.EventArgs) Handles btnModTimbrado.Click
        Me.txtTimbrado.ReadOnly = False
        Me.txtTimbrado.Focus()

        btnGuardarTimbrado.Visible = True : btnGuardarTimbrado.Enabled = True
        btnCancelarTimbrado.Visible = True : btnCancelarTimbrado.Enabled = True
        btnModTimbrado.Visible = False
    End Sub

    Private Sub btnCancelarTimbrado_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarTimbrado.Click
        Me.txtTimbrado.ReadOnly = True

        btnGuardarTimbrado.Visible = False : btnGuardarTimbrado.Enabled = False
        btnCancelarTimbrado.Visible = False : btnCancelarTimbrado.Enabled = False
        btnModTimbrado.Visible = True
    End Sub

    Private Sub btnGuardarTimbrado_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardarTimbrado.Click
        Dim transaction As SqlTransaction = Nothing
        Dim ProveedorNombre As String = ""

        If txtTimbrado.Text <> "" Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            ProveedorNombre = ProvFactComboBox.Text

            Try
                sql = ""
                sql = "UPDATE PROVEEDOR SET TIMBRADOFACTURA = '" & txtTimbrado.Text & "' WHERE CODPROVEEDOR = " & ProvFactComboBox.SelectedValue

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans.Commit()

            Catch ex As Exception
                myTrans.Rollback("Actualizar")
                MessageBox.Show("Error al Guardar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            sqlc.Close()

            Me.txtTimbrado.ReadOnly = True

            btnGuardarTimbrado.Visible = False : btnGuardarTimbrado.Enabled = False
            btnCancelarTimbrado.Visible = False : btnCancelarTimbrado.Enabled = False
            btnModTimbrado.Visible = True

            'Actualizamos el fill de proveedor
            Me.PROVEEDORTableAdapter.Fill(Me.DsPagos.PROVEEDOR, "%", "%")
            ProvFactComboBox.Text = ProveedorNombre

        Else
            MessageBox.Show("Ingrese un Nro de Timbrado", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTimbrado.Focus()
        End If

    End Sub

    Private Sub ProdGridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ProdGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Index As Integer = Me.CODIGOSBindingSource.Position

            Dim CostoProd As String
            lblMensajeInteractivo.Text = ""

            If Config5 = "Precio Última Compra" Then
                If IsDBNull(ProdGridView1.Rows(Index).Cells("PRECIOULTCOMPRA").Value) Then
                    CostoProd = 0
                Else
                    CostoProd = FormatNumber(ProdGridView1.Rows(Index).Cells("PRECIOULTCOMPRA").Value, 0)
                    CostoComTextBox1.Text = CostoProd
                End If
                If CDec(CostoProd) > 0 Then
                    lblMensajeInteractivo.ForeColor = Color.Black
                    lblMensajeInteractivo.Text = "Costo Ulti. Compra: " + CostoProd

                    If Config6 = "Si" Then
                        CostoComTextBox1.Text = CostoProd
                    End If
                End If
            Else
                If IsDBNull(ProdGridView1.Rows(Index).Cells("COSTOFIFO").Value) Then
                    CostoProd = 0
                Else
                    CostoProd = FormatNumber(ProdGridView1.Rows(Index).Cells("COSTOFIFO").Value, 0)
                End If
                If CDec(CostoProd) > 0 Then
                    lblMensajeInteractivo.Text = "Costo Fifo: " + CostoProd
                    lblMensajeInteractivo.ForeColor = Color.Black

                    If Config6 = "Si" Then
                        CostoComTextBox1.Text = CostoProd
                    End If
                End If
            End If
            lblPrecio2.Text = CostoProd

            If IsDBNull(ProdGridView1.Rows(Index).Cells("CODCODIGO2").Value) Then
            Else
                CodCodigoCTextBox = ProdGridView1.Rows(Index).Cells("CODCODIGO2").Value
            End If

            If IsDBNull(ProdGridView1.Rows(Index).Cells("CODPRODUCTO2").Value) Then
            Else
                CodProductoCTextBox = ProdGridView1.Rows(Index).Cells("CODPRODUCTO2").Value
            End If

            If IsDBNull(ProdGridView1.Rows(Index).Cells("CODIGO2").Value) Then
            Else
                CodCodigoCompraTextBox.Text = ProdGridView1.Rows(Index).Cells("CODIGO2").Value
            End If

            If IsDBNull(ProdGridView1.Rows(Index).Cells("DESCRIPCION").Value) Then
            Else
                DesProdComTextBox.Text = ProdGridView1.Rows(Index).Cells("DESCRIPCION").Value
            End If

            If IsDBNull(ProdGridView1.Rows(Index).Cells("PORCENTAJEIVA").Value) Then
            Else
                If GlobalAutofactura = 1 Then 'Or IvaIncluidoTextBox.Text = "2"
                    TipoIvaComboBox.Text = "0,00"
                Else
                    Dim PorcentajeIvaProducto As String = ProdGridView1.Rows(Index).Cells("PORCENTAJEIVA").Value
                    TipoIvaComboBox.SelectedText = PorcentajeIvaProducto
                End If
            End If
            BusCodigoTextBox.Text = ""
            CodCodigoCompraTextBox.Focus()
            ProdGroupBox.Visible = False

            CantidadComTextBox1.Focus()
        End If
    End Sub

    Private Sub btnMostrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrarOBS.Click
        PanelConceptoCompras.Visible = True
        PanelConceptoCompras.BringToFront()

        PanelConceptoCompras.Enabled = True

        If btNuevo = 1 Or btModificar = 1 Then
            BtnCerrarAprobar.Enabled = True
            TextBoxConcepto.Enabled = True
            BtnProbar.Enabled = True
        Else
            BtnCerrarAprobar.Enabled = True
            TextBoxConcepto.Enabled = False
            BtnProbar.Enabled = False
        End If
    End Sub

    Private Sub btnCambiarFecha_Click(sender As System.Object, e As System.EventArgs) Handles btnCambiarFecha.Click
        btcfcuota = 1
        lblCambiarCredito.Visible = True
        Me.dttFechaPrimeraCuota.Enabled = True
        dttFechaPrimeraCuota.Focus()
    End Sub

    Private Sub dttFechaPrimeraCuota_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dttFechaPrimeraCuota.KeyPress
        Dim conexion1 As System.Data.SqlClient.SqlConnection

        conexion1 = ser.Abrir()
        Dim asentvalor As String = ""
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If btcfcuota = 1 Then
                Dim myTrans As System.Data.SqlClient.SqlTransaction
                Dim conexion As System.Data.SqlClient.SqlConnection
                conexion = ser.Abrir()

                Try
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Try
                        ActualizaPago(myTrans) ' Inserta en la tabla facturapagar(cuotas)

                        If CmbTipoFactura.Text = "Contado" Then
                            btnCambiarFecha.Text = "Cambiar a Crédito"
                        Else
                            btnCambiarFecha.Text = "Cambiar a Contado"
                        End If

                        myTrans.Commit()

                        MessageBox.Show("Factura Actualizada Correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Actualizar")
                        Catch
                        End Try

                        Throw ex
                    End Try
                Catch
                End Try

                Me.FACTURAPAGARTableAdapter.Fill(Me.DsPagos.FACTURAPAGAR)
                GridViewCuotas.Refresh()

            Else
                tbxCantidadPagos.Focus()
            End If

            lblCambiarCredito.Visible = False
        End If

        '############################################################# By Saul
        Dim codcomreg As Integer = CInt(ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value)
        If CmbTipoFactura.Text = "Contado" Then
            asentvalor = "Factura de Compra Contado / " & w.FuncionConsultaString("NOMBRE", "PROVEEDOR", "NUMPROVEEDOR", ComprasSimpleGridView1.CurrentRow.Cells("DataGridViewTextBoxColumn1").Value)
        Else
            asentvalor = "Factura de Compra Credito / " & w.FuncionConsultaString("NOMBRE", "PROVEEDOR", "NUMPROVEEDOR", ComprasSimpleGridView1.CurrentRow.Cells("DataGridViewTextBoxColumn1").Value)
        End If

        ser.Abrir(sqlc)
        cmd.Connection = sqlc

        If CmbTipoFactura.Text = "Contado" Then
            sql = "UPDATE PARAASENTAR SET DETALLE= '" & asentvalor & "' WHERE REGISTROID=" & codcomreg & " "
        Else
            sql = "UPDATE PARAASENTAR SET DETALLE= '" & asentvalor & "' WHERE REGISTROID=" & codcomreg & " "
        End If

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

        myTrans = conexion1.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        Consultas.ConsultaComando(myTrans, sql)
        myTrans.Commit()
        '#############################################################

        Dim CodCompraTemp As Integer = tbxCodCompras.Text
        If rbtvertodo.Checked = True Then
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If
        If rbtverOC.Checked = True Then
            rbtverOC_CheckedChanged(Nothing, Nothing)
        End If
        If rbtVerfacturas.Checked = True Then
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)
        End If

        'Buscamos la posicion del registro guardado
        For k = 0 To ComprasSimpleGridView1.RowCount - 1
            If ComprasSimpleGridView1.Rows(k).Cells("CODCOMPRA").Value = CodCompraTemp Then
                COMPRASBindingSource.Position = k
            End If
        Next
    End Sub

    Private Sub ActualizaPago(ByVal myTrans As System.Data.Common.DbTransaction)

        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection

        conexion = ser.Abrir()

        Dim c As Integer = GridViewCuotas.RowCount
        If c = 0 Then
            Exit Sub
        End If
        Dim w As New Funciones.Funciones
        Dim Existe, Codnrocuota, Codcompra, importe, fecha, saldocuota, destipopago, tipofactura, ModalidadPago As String
        Dim asentvalor As String = ""

        If CmbTipoFactura.Text = "Contado" Then
            tipofactura = "CREDITO"
            ModalidadPago = 1
        Else
            tipofactura = "CONTADO"
            ModalidadPago = 0
        End If
        Dim i As Integer
        For i = 1 To c

            Codcompra = CDec(GridViewCuotas.Rows(i - 1).Cells("CODCOMPRADataGridViewTextBoxColumn1").Value)
            Codnrocuota = CDec(GridViewCuotas.Rows(i - 1).Cells("NUMEROCUOTADataGridViewTextBoxColumn").Value)
            destipopago = GridViewCuotas.Rows(i - 1).Cells("DESTIPOPAGODataGridViewTextBoxColumn").Value

            importe = GridViewCuotas.Rows(i - 1).Cells("IMPORTECUOTADataGridViewTextBoxColumn").Value
            importe = Funciones.Cadenas.QuitarCad(importe, ".")
            importe = Replace(importe, ",", ".")

            If CmbTipoFactura.Text = "Contado" Then ' Le reintegra como saldo el Importe
                saldocuota = GridViewCuotas.Rows(i - 1).Cells("IMPORTECUOTADataGridViewTextBoxColumn").Value
                saldocuota = Funciones.Cadenas.QuitarCad(saldocuota, ".")
                saldocuota = Replace(saldocuota, ",", ".")
            Else
                saldocuota = GridViewCuotas.Rows(i - 1).Cells("SALDOCUOTADataGridViewTextBoxColumn").Value
                saldocuota = Funciones.Cadenas.QuitarCad(saldocuota, ".")
                saldocuota = Replace(saldocuota, ",", ".")
            End If

            If btcfcuota = 0 Then
                fecha = CDate(GridViewCuotas.Rows(i - 1).Cells("FECHAVCTODataGridViewTextBoxColumn").Value).ToShortDateString
            Else
                fecha = CDate(dttFechaPrimeraCuota.Value).ToShortDateString
            End If

            '############################################################################
            'preguntamos si existe el detalle para saber si actualizar o insertar

            Existe = w.FuncionConsultaString("NUMEROCUOTA", "FACTURAPAGAR", "NUMEROCUOTA = " & Codnrocuota & " " & _
                                             "AND CODCOMPRA", Codcompra.ToString)
            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = fecha
            Dim Concatenar As String = Concat & " " + hora
            Dim asiento1 As String = ""

            If Existe <> Nothing Then
                consulta = "UPDATE FACTURAPAGAR SET FECHAVCTO =CONVERT(DATETIME,'" & Concatenar & "',103), IMPORTECUOTA=" & importe & ",SALDOCUOTA=" & saldocuota & ", TIPOFACTURA = '" & tipofactura & "'," & _
                "DESTIPOPAGO='" & destipopago & "', PAGADO = 0, COTIZACION = " & CInt(tbxCompraCotizacion.Text) & " WHERE NUMEROCUOTA = " & Codnrocuota & " AND  CODCOMPRA = " & Codcompra & " "
            Else
                consulta = "INSERT INTO FACTURAPAGAR (NUMEROCUOTA,CODUSUARIO,CODEMPRESA,CODCOMPRA,FECHAVCTO,SALDOCUOTA,IMPORTECUOTA,FECGRA,PAGADO,DESTIPOPAGO,TIPOFACTURA, COTIZACION) " & _
                "VALUES ( " & Codnrocuota & "," & UsuCodigo & "," & EmpCodigo & " , " & _
                "" & Codnrocuota & ",CONVERT(Datetime,'" & Concatenar & "',103) ," & saldocuota & "," & importe & ",CONVERT(Datetime,'" & Concatenar & "',103),0 ,'" & destipopago & "','" & tipofactura & "', " & CInt(tbxCompraCotizacion.Text) & " ) "
            End If

            'Actualizamos el tipo de la Compra a credito o Contado
            consulta = consulta + "    UPDATE COMPRAS SET MODALIDADPAGO=" & ModalidadPago & " WHERE CODCOMPRA=" & CDec(tbxCodCompras.Text)

            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            Consultas.ConsultaComando(myTrans, consulta)
            myTrans.Commit()
        Next
    End Sub

    Private Sub TipoCompComboBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles TipoCompComboBox.SelectedValueChanged
        Try
            GlobalAutofactura = w.FuncionConsultaString("convert(int,autofactura)", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
            If GlobalAutofactura = 1 And btNuevo = 1 Then
                MostrarNroAutoFactura()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MostrarNroAutoFactura()
        Dim conexion As System.Data.SqlClient.SqlConnection
        conexion = ser.Abrir()
        Try
            Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString, RANGOIDACTIVO, NumCompra As String
            Dim NroDigitos, i As Integer

            NumSucursal = SucCodigo
            RANGOIDACTIVO = w.FuncionConsultaString("RANDOID", "DETPC", "ACTIVO=1 AND CODCOMPROBANTE= " & TipoCompComboBox.SelectedValue & " AND IP", CodigoMaquina)

            Dim dadetpc As New SqlDataAdapter("Select CODSUCURSAL, IP, ULTIMO, RANGO2,NRODIGITOS FROM DETPC WHERE (ULTIMO < RANGO2) AND ACTIVO = 1 AND RANDOID=" & RANGOIDACTIVO & "", conexion)
            Dim dtdetpc As New DataTable
            dadetpc.Fill(dtdetpc)
            Dim drdetpc As DataRow
            drdetpc = dtdetpc.Rows(0)

            NroDigitos = drdetpc("NRODIGITOS")
            NroRango = drdetpc("ULTIMO")
            NroRango = NroRango + 1
            NroRango2 = drdetpc("RANGO2")

            If CDec(NroRango) > CDec(NroRango2) Then
                NumCompra = ""
                Exit Sub
            End If

            Dim codsuc As Integer = drdetpc("CODSUCURSAL")
            NumSucTimbrado = w.FuncionConsultaString("SUCURSALTIMBRADO", "SUCURSAL", "CODSUCURSAL", codsuc)

            Dim IPMAQ As Integer = drdetpc("IP")
            NumMaquina = w.FuncionConsultaString("NUMMAQUINA", "PC", "IP", IPMAQ)

            NroRangoString = CStr(NroRango)
            For i = 1 To NroDigitos
                If Len(NroRangoString) = NroDigitos Then
                    Exit For
                Else
                    NroRangoString = "0" & NroRangoString
                End If
            Next

            NumCompra = NumSucTimbrado & "-" & NumMaquina & "-" & NroRangoString
            NroFacturaMaskedEditBox1.Text = NumCompra
            NumCompra = ""

        Catch ex As Exception
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub TipoIvaComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TipoIvaComboBox.SelectedIndexChanged
        Dim i As Integer
        For i = 0 To dtIva.Rows.Count - 1
            dr2 = dtIva.Rows(i)
            If Trim(TipoIvaComboBox.Text) <> "" Then
                If TipoIvaComboBox.Text = dr2("PORCENTAJEIVA") Then
                    coheficiente = dr2("COHEFICIENTE")
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub TipoIvaComboBox2_TextChanged(sender As Object, e As System.EventArgs) Handles TipoIvaComboBox.TextChanged
        Try
            Dim i As Integer
            For i = 0 To dtIva.Rows.Count - 1
                dr2 = dtIva.Rows(i)
                If Trim(TipoIvaComboBox.Text) <> "" Then
                    If TipoIvaComboBox.Text = dr2("PORCENTAJEIVA") Then
                        coheficiente = dr2("COHEFICIENTE")
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Sub PintarCeldas()
        Dim i As Integer
        If ComprasSimpleGridView1.RowCount - 1 >= 1 Then
            For i = 0 To ComprasSimpleGridView1.RowCount - 1
                If ComprasSimpleGridView1.Rows(i).Cells("ESTADODataGridViewTextBoxColumn").Value = 1 Then
                    ComprasSimpleGridView1.Item(0, i).Style.ForeColor = Color.Green

                ElseIf ComprasSimpleGridView1.Rows(i).Cells("ESTADODataGridViewTextBoxColumn").Value = 2 Then
                    ComprasSimpleGridView1.Item(0, i).Style.ForeColor = Color.Maroon

                ElseIf ComprasSimpleGridView1.Rows(i).Cells("ESTADODataGridViewTextBoxColumn").Value = 0 Then
                    If IsDBNull(ComprasSimpleGridView1.Rows(i).Cells("ORDCOMPRA").Value) Then
                        ComprasSimpleGridView1.Item(0, i).Style.ForeColor = Color.Black
                    ElseIf ComprasSimpleGridView1.Rows(i).Cells("ORDCOMPRA").Value = 1 Then
                        ComprasSimpleGridView1.Item(0, i).Style.ForeColor = Color.DarkOrange
                    Else
                        ComprasSimpleGridView1.Item(0, i).Style.ForeColor = Color.Black
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub DetalleCompraGridView_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DetalleCompraGridView.DataError
        Dim s As String = e.Exception.Message
        Dim columna As Integer = e.ColumnIndex
    End Sub

    Private Sub tsEmitirOrdDeCompra_Click(sender As System.Object, e As System.EventArgs) Handles tsEmitirOrdDeCompra.Click
        Dim CodCompraTemp As Integer
        Me.Cursor = Cursors.AppStarting

        'Antes de Emitir el presupuesto verificamos que ya no se halla emitido anteriormente
        Dim ExisteEmitido As Integer = w.FuncionConsultaDecimal("ORDCOMPRA", "COMPRAS", "CODCOMPRA", VCodCompra)
        If ExisteEmitido = 0 Then
            Dim rango As String = ""

            'Obtenemos los datos Rango, Impresora e Imprimir
            Dim objCommand As New SqlCommand
            Try
                objCommand.CommandText = "SELECT dbo.DETPC.RANDOID, dbo.DETPC.IMPRESORA, dbo.DETPC.IMPRIMIR,dbo.TIPOCOMPROBANTE.FORMAIMPRESION " & _
                                          "FROM dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                          "WHERE (dbo.TIPOCOMPROBANTE.ORDCOMPRA = 1) AND (dbo.DETPC.ACTIVO = 1)"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        rango = odrConfig("RANDOID")
                        impresora = odrConfig("IMPRESORA")
                        Imprimir = odrConfig("IMPRIMIR")
                        TipoImpresion = odrConfig("FORMAIMPRESION")
                    Loop
                Else
                    MessageBox.Show("No Existe un Rango para la Ord de Compra. Configuracion -> Rango de Comprobante", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    odrConfig.Close()
                    objCommand.Dispose()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try

            'Obtenemos el Nro  y lo marcamos como Presupuesto
            CalculaNroOrdCompra(rango)

            'Ponemos como visible los campos de Ord de Compra
            lblTextoOrd.Visible = True
            lblNroOrdCompra.Visible = True

            'Verificamos si quiere imprimir 
            Try
                If impresora = "" And Imprimir = 1 Then
                    MessageBox.Show("Esta maquina No tiene Impresora asignada", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If TipoImpresion = 0 Then   'Formato Ticket
                    If Imprimir = 1 Then 'Se imprime
                        ' ImprimirReportePreVenta()
                    End If
                ElseIf TipoImpresion = 1 Then 'Formato Impresora
                    If Imprimir = 1 Then 'Se imprime
                        ImprimirReporteOrdCompra()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error al Imprimir : " & ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            'Insertamos en la Tabla Comentarios
            If CmbEvento.Text <> "" Then
                InsertarProyecto("Orden de Compra Nro " & lblNroOrdCompra.Text, CmbEvento.SelectedValue())
            End If

            CodCompraTemp = ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

            FechaFiltro()
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)

            'Buscamos la posicion del registro guardado
            For k = 0 To ComprasSimpleGridView1.RowCount - 1
                If ComprasSimpleGridView1.Rows(k).Cells("CODCOMPRA").Value = CodCompraTemp Then
                    COMPRASBindingSource.Position = k
                End If
            Next

            COMPRASDETALLEBindingSource.RemoveFilter()
            COMPRASDETALLETableAdapter.Fill(DsPagos.COMPRASDETALLE, compra)

            PintarCeldas()
            Deshabilitamos()


        End If

        Me.Cursor = Cursors.Arrow

        If Config9 = "Ver Ordenes de Compra" Then
            rbtverOC.Checked = True
            rbtverOC_CheckedChanged(Nothing, Nothing)
        ElseIf Config9 = "Ver Facturas" Then
            rbtVerfacturas.Checked = True
            rbtVerfacturas_CheckedChanged(Nothing, Nothing)
        Else
            rbtvertodo.Checked = True
            rbtvertodo_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub CalculaNroOrdCompra(RangoAQuemar As String)
        Dim NumOrdCompra As String
        Dim cmd2 As New SqlCommand
        Dim conexion As System.Data.SqlClient.SqlConnection
        conexion = ser.Abrir()
        Try
            Dim NroRango2, NroRangoString As String
            Dim NroDigitos As Integer

            Dim drdetpc As DataRow
            Dim dadetpc As New SqlDataAdapter("SELECT dbo.DETPC.TIMBRADO, dbo.DETPC.NRODIGITOS, dbo.SUCURSAL.SUCURSALTIMBRADO, dbo.PC.NUMMAQUINA,  dbo.DETPC.RANGO2, dbo.DETPC.ULTIMO FROM dbo.DETPC INNER JOIN dbo.SUCURSAL ON dbo.DETPC.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN dbo.PC ON dbo.DETPC.IP = dbo.PC.IP WHERE dbo.DETPC.RANDOID=" & RangoAQuemar & "", conexion)
            Dim dtdetpc As New DataTable
            dadetpc.Fill(dtdetpc)
            drdetpc = dtdetpc.Rows(0)

            'Validamos que haya rango para ese TipoComprobante
            NroRango = drdetpc("ULTIMO")
            NroRango = NroRango + 1

            NroRango2 = drdetpc("RANGO2")
            NroDigitos = drdetpc("NRODIGITOS")

            If CDec(NroRango) > CDec(NroRango2) Then
                NumOrdCompra = ""
                'supero el ultimo
                Exit Sub
            End If
            Dim i As Integer
            NroRangoString = CStr(NroRango)
            For i = 1 To NroDigitos
                If Len(NroRangoString) = NroDigitos Then
                    Exit For
                Else
                    NroRangoString = "0" & NroRangoString
                End If
            Next

            NumOrdCompra = NroRangoString
            lblNroOrdCompra.Text = NumOrdCompra

            If NumOrdCompra = "" Then
                MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                ser.Abrir(sqlc)
                cmd2.Connection = sqlc

                sql = ""
                sql = "UPDATE COMPRAS SET ORDCOMPRA=1, NUMCOMPRA = '" & NumOrdCompra & "' where CODCOMPRA= " & ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

                cmd2.CommandText = sql
                cmd2.ExecuteNonQuery()

                sql = ""
                sql = "UPDATE DETPC SET ULTIMO = " & NroRangoString & " where RANDOID=" & RangoAQuemar & ""

                cmd2.CommandText = sql
                cmd2.ExecuteNonQuery()

                '---------------------------- DESACTIVA RANGO ----------------------------
                'Verificamos si es el ultimo Nro del rango de comprobantes y ponemos como desabilitado dicho rango 'SE CONSULTA ULTIMO OTRA VEZ PORQUE SE ACABA DE QUEMAR UNO NUEVO
                If NroRango2 = NroRangoString Then
                    sql = ""
                    sql = "UPDATE DETPC SET ACTIVO=0 WHERE RANDOID =" & RangoAQuemar & ""

                    cmd2.CommandText = sql
                    cmd2.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al Emitir la Orden de Compra : " & ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblNroOrdCompra.Text = ""
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub tsImprimirOrdDeCompra_Click(sender As System.Object, e As System.EventArgs) Handles tsImprimirOrdDeCompra.Click
        matricial = 0
        ImprimirReporteOrdCompra()
    End Sub

    Private Sub ImprimirReporteOrdCompra()
        Dim frm = New VerInformes
        Me.RepOrdCompraTableAdapter.Fill(DsPagos.RepOrdCompra, ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value)
        Me.RepOrdCompraEmpresaTableAdapter.Fill(DsPagos.RepOrdCompraEmpresa)

        If matricial = 0 Then
            Dim rpt As New ReportesPersonalizados.OrdenCompra
            rpt.SetDataSource(DsPagos)
            frm.CrystalReportViewer1.ReportSource = rpt
        Else
            Dim rptmat As New ReportesPersonalizados.OrdenCompraMATR
            rptmat.SetDataSource(DsPagos)
            frm.CrystalReportViewer1.ReportSource = rptmat
        End If

        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub tsAprobarOrdCompr_Click(sender As System.Object, e As System.EventArgs) Handles tsAprobarOrdCompr.Click
        'Mostramos Panel de Aprobacion
        BtnProbar_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAnularOrdCompra_Click(sender As System.Object, e As System.EventArgs) Handles tsAnularOrdCompra.Click
        PictureBoxMotivoAnulacion_Click(Nothing, Nothing)
    End Sub

    Private Sub CantidadComTextBox1_LostFocus(sender As Object, e As System.EventArgs) Handles CantidadComTextBox1.LostFocus
        Try
            Dim Stock, StockNuevo, StockMax, StockMin As Double
            lblMensajeInteractivo.Text = ""

            EnlazadoProductos = w.FuncionConsulta("ENLAZADO", "CENTROCOSTO", "CODCENTRO", cbxCdC.SelectedValue)
            If EnlazadoProductos = 1 Then
                If IsDBNull(ProdGridView1.CurrentRow.Cells("Stock").Value) Then
                    Stock = 0
                Else
                    Stock = ProdGridView1.CurrentRow.Cells("Stock").Value
                End If

                If IsDBNull(ProdGridView1.CurrentRow.Cells("STOCKMAXIMO").Value) Then
                    StockMax = 0
                Else
                    StockMax = ProdGridView1.CurrentRow.Cells("STOCKMAXIMO").Value
                End If

                If IsDBNull(ProdGridView1.CurrentRow.Cells("STOCKMINIMO").Value) Then
                    StockMin = 0
                Else
                    StockMin = ProdGridView1.CurrentRow.Cells("STOCKMINIMO").Value
                End If

                If CantidadComTextBox1.Text <> "" Then
                    StockNuevo = Stock + CDec(CantidadComTextBox1.Text)
                    If StockNuevo > StockMax Then
                        lblMensajeInteractivo.Text = "Soprepasa el Stock Maximo"
                        lblMensajeInteractivo.ForeColor = Color.Red
                    ElseIf StockNuevo < StockMin Then
                        lblMensajeInteractivo.Text = "No alcanzas al Stock Minimo"
                        lblMensajeInteractivo.ForeColor = Color.OrangeRed
                    End If
                Else
                    lblMensajeInteractivo.Text = ""
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsReImprimirOrdDeCompraMATR_Click(sender As System.Object, e As System.EventArgs) Handles tsReImprimirOrdDeCompraMATR.Click
        matricial = 1
        ImprimirReporteOrdCompra()
    End Sub

    Private Sub TxtNumProv_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumProv.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProvFactComboBox.Focus()
            KeyAscii = 0
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNumProv_LostFocus(sender As Object, e As System.EventArgs) Handles TxtNumProv.LostFocus
        Dim CodProveedor As String
        If TxtNumProv.Text <> "" Then
            Try
                CodProveedor = f.FuncionConsultaString("CODPROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", TxtNumProv.Text)
                ProvFactComboBox.SelectedValue = CDec(CodProveedor)

                Dim VcodMod As Integer = f.FuncionConsultaDecimal("CODMONEDA", "PROVEEDOR", "CODPROVEEDOR", CDec(CodProveedor))
                If VcodMod = 0 Then
                    cbxComprasMoneda.SelectedValue = CODMONEDAPRINCIPAL
                Else
                    cbxComprasMoneda.SelectedValue = VcodMod
                End If

                Dim vFormaCobro As Double = f.FuncionConsultaDecimal("FORMAPAGO", "PROVEEDOR", "CODPROVEEDOR", CodProveedor)
                If vFormaCobro = 0 Then
                    Me.CmbTipoFactura.Text = "Contado"
                Else
                    Me.CmbTipoFactura.Text = "Crédito"
                End If

            Catch ex As Exception
            End Try
            IsKeyPress = 1
        End If
    End Sub

    Private Sub ProvFactComboBox_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ProvFactComboBox.SelectedIndexChanged
        If Not ProvFactComboBox.SelectedValue = Nothing Then
            TxtNumProv.Text = f.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", ProvFactComboBox.SelectedValue)

            Dim VcodMod As Integer = f.FuncionConsultaDecimal("CODMONEDA", "PROVEEDOR", "CODPROVEEDOR", ProvFactComboBox.SelectedValue)
            If VcodMod = 0 Then
                cbxComprasMoneda.SelectedValue = CODMONEDAPRINCIPAL
            Else
                cbxComprasMoneda.SelectedValue = VcodMod
            End If
        End If
    End Sub

    Private Sub tsAplicarDescuentoAlTota_Click(sender As System.Object, e As System.EventArgs) Handles tsAplicarDescuentoAlTota.Click
        ModificarPictureBox_Click(Nothing, Nothing)
        pnlDescuento.Visible = True
        pnlDescuento.BringToFront()
        tbxDescuento.Focus()
    End Sub

    Private Sub tsAplicarRedondeoAlMontoTotal_Click(sender As System.Object, e As System.EventArgs) Handles tsAplicarRedondeoAlMontoTotal.Click
        ModificarPictureBox_Click(Nothing, Nothing)
        PanelRedondeo.Visible = True
        PanelRedondeo.BringToFront()
        tbxRedondeo.Focus()
    End Sub

    Private Sub tbxDescuento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbxDescuento.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlDescuento.Visible = False
            pnlDescuento.SendToBack()
            CancelarPictureBox_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tbxDescuento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxDescuento.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim Desc, i As Integer
        Dim Porc, SubtotDesc, ValSubt As Double
        Dim SubProc, PrecioDescontado As Double
        Dim vIva5, vIva10, vExcenta As Double
        Dim vImporteGrab5, vImporteGrab10, vImporteExcento, TipoIva As String
        Dim TIva5, TIva10, TExcento, TIva, TGrab10, TGrab5 As String

        If KeyAscii = 42 Then
            If lblSimbolo.Text = "%" Then
                lblSimbolo.Text = "Gs"
            Else
                lblSimbolo.Text = "%"
            End If
        End If

        If KeyAscii = 13 Then
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            '1RO DESCONTAMOS DEL MONTO TOTAL
            vIva5 = 0 : vIva10 = 0 : vExcenta = 0 : TIva = "" : TIva5 = "" : TIva10 = "" : TGrab10 = "" : TGrab5 = "" : vgDescuento = 0
            'total = TotalTextBox1.Text

            If lblSimbolo.Text = "%" Then 'SI EL DESCUENTO SE APLICA A UN PORCENTAJE
                Desc = (CDec(TotalTextBox1.Text) * CDec(tbxDescuento.Text)) / 100 'Guarda el descuento aplicado en Efectivo, se hace la conversion 

            Else 'SI EL DESCUENTO SE APLICA EN EFECTIVO
                Desc = tbxDescuento.Text 'Guarda el descuento aplicado en Efectivo

            End If

            For i = 0 To DetalleCompraGridView.RowCount - 1
                Porc = 0 : ValSubt = 0 : PrecioDescontado = 0 : vImporteGrab5 = "0" : vImporteGrab10 = "0" : vImporteExcento = "0"

                ValSubt = CDec(DetalleCompraGridView.Rows(i).Cells("SUBTOTAL").Value)
                Porc = CDec((ValSubt * 100) / CDec(TotalTextBox1.Text)) 'Verifica el porcentaje sobre el total descuento
                SubProc = CDec((Desc * Porc) / 100) 'Obtenemos el monto a descontar
                SubtotDesc = ValSubt - SubProc 'Restatamos del subtotal el descuento a aplicar
                PrecioDescontado = SubtotDesc / CDec(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value)

                'Guardamos en la base de datos el nuevo valor del subtotal con los nuevos datos del IVA - VENTASDETALLE
                Try
                    Dim subTotalString As String = Replace(PrecioDescontado, ",", ".")
                    Dim LineaNro As String = DetalleCompraGridView.Rows(i).Cells("LINEANROCOMPRA").Value
                    TipoIva = DetalleCompraGridView.Rows(i).Cells("TIPOIVA").Value

                    If TipoIva = "5.00" Then
                        vImporteGrab5 = PrecioDescontado * CDec(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value)
                        vImporteGrab10 = 0 : vImporteExcento = 0

                        vIva5 = vIva5 + CDec(vImporteGrab5)

                    ElseIf TipoIva = "10.00" Then
                        vImporteGrab10 = PrecioDescontado * CDec(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value)
                        vImporteGrab5 = 0 : vImporteExcento = 0

                        vIva10 = vIva10 + CDec(vImporteGrab10)

                    ElseIf TipoIva = "0.00" Then
                        vImporteExcento = PrecioDescontado * CDec(DetalleCompraGridView.Rows(i).Cells("CANTIDADCOMPRA").Value)
                        vImporteGrab5 = 0 : vImporteGrab10 = 0

                        vExcenta = vExcenta + CDec(vImporteExcento)
                    End If

                    sql = "UPDATE COMPRASDETALLE SET  COSTOUNITARIO = " & subTotalString & ", IMPORTEGRAVADO5 = " & Replace(vImporteGrab5, ",", ".") & ", IMPORTEGRAVADO10 = " & Replace(vImporteGrab10, ",", ".") & ", " & _
                          "IMPORTEEXENTO = " & Replace(vImporteExcento, ",", ".") & "  WHERE LINEANROCOMPRA = " & LineaNro & "  "

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            Next

            'Obtenemos los datos de las Grabadas
            TGrab10 = vIva10 : TGrab10 = Replace(TGrab10, ",", ".")
            TGrab5 = vIva5 : TGrab5 = Replace(TGrab5, ",", ".")

            'Obtenemos los nuevos datos para el iva
            For i = 0 To dtIva.Rows.Count - 1
                dr2 = dtIva.Rows(i)
                If dr2("PORCENTAJEIVA") = "5,00" Then
                    coheficiente = dr2("COHEFICIENTE")
                    vIva5 = vIva5 / 21 'CAMBIAR EL COHEFICIENTE
                ElseIf dr2("PORCENTAJEIVA") = "10,00" Then
                    coheficiente = dr2("COHEFICIENTE")
                    vIva10 = vIva10 / 11 'CAMBIAR EL COHEFICIENTE
                End If
            Next

            'Guardamos en Nuevo Valor de la Compra y el Descuento Aplicado.
            Dim NuevoTotal As String = CDec(TotalTextBox1.Text) - CDec(Desc)
            Try
                NuevoTotal = Replace(NuevoTotal, ",", ".")

                TIva5 = vIva5 : TIva5 = Replace(TIva5, ",", ".")
                TIva10 = vIva10 : TIva10 = Replace(TIva10, ",", ".")
                TIva = vIva10 + vIva5 : TIva = Replace(TIva, ",", ".")
                TExcento = vExcenta : TExcento = Replace(TExcento, ",", ".")
                Dim posi As String = ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

                sql = ""
                sql = "UPDATE COMPRAS SET TOTALCOMPRA = " & NuevoTotal & ", TOTALDESCUENTO = " & CDec(Desc) & " , TOTALIVA10 = " & TIva10 & ", " & _
                      "TOTALIVA5 = " & TIva5 & " , TOTALIVA = " & TIva & ", TOTALEXENTA = " & TExcento & " , TOTALGRAVADO10 = " & TGrab10 & " , TOTALGRAVADO5 = " & TGrab5 & _
                      "  WHERE CODCOMPRA = " & CDec(posi) & ""

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                TotalTextBox1.Text = NuevoTotal
            Catch ex As Exception

            End Try

            sqlc.Close()
            pnlDescuento.SendToBack()
            compra = Me.ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

            FechaFiltro()
            BtnFiltro_Click(Nothing, Nothing)

            'Buscamos la posicion del registro guardado
            For k = 0 To ComprasSimpleGridView1.RowCount - 1
                If ComprasSimpleGridView1.Rows(k).Cells("CODCOMPRA").Value = compra Then
                    COMPRASBindingSource.Position = k
                End If
            Next
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub lblSimbolo_DoubleClick(sender As Object, e As System.EventArgs) Handles lblSimbolo.DoubleClick
        If lblSimbolo.Text = "Gs" Then
            lblSimbolo.Text = "%"
        Else
            lblSimbolo.Text = "Gs"
        End If
    End Sub

    Private Sub rbtvertodo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtvertodo.CheckedChanged
        FechaFiltro()
        COMPRASTableAdapter.Fill(DsPagos.COMPRAS, "%", FechaFiltro1, FechaFiltro2)
        PintarCeldas()
        lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
    End Sub

    Private Sub rbtverOC_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtverOC.CheckedChanged
        FechaFiltro()
        COMPRASTableAdapter.FillBy1(DsPagos.COMPRAS, "%", FechaFiltro1, FechaFiltro2, 1)
        PintarCeldas()
        lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
    End Sub

    Private Sub rbtVerfacturas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtVerfacturas.CheckedChanged
        FechaFiltro()
        COMPRASTableAdapter.FillBy1(DsPagos.COMPRAS, "%", FechaFiltro1, FechaFiltro2, 0)
        PintarCeldas()
        lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
    End Sub

    Private Sub DetalleCompraGridView_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DetalleCompraGridView.DoubleClick
        Try
            If IsDBNull(DetalleCompraGridView.CurrentRow) Then
                Exit Sub
            Else
                IndiceDetalleCompra = DetalleCompraGridView.CurrentRow.Cells("LINEANROCOMPRA").Value.ToString

                CodCodigoCompraTextBox.Text = DetalleCompraGridView.CurrentRow.Cells("CODIGOPROD").Value.ToString
                cbxCdC.Text = DetalleCompraGridView.CurrentRow.Cells("DESCENTRO").Value
                CantidadComTextBox1.Text = CDec(DetalleCompraGridView.CurrentRow.Cells("CANTIDADCOMPRA").Value)
                CostoComTextBox1.Text = CDec(DetalleCompraGridView.CurrentRow.Cells("COSTOUNITARIO").Value)
                TipoIvaComboBox.Text = DetalleCompraGridView.CurrentRow.Cells("IVA").Value
                DesProdComTextBox.Text = DetalleCompraGridView.CurrentRow.Cells("DESPRODUCTO").Value
            End If

        Catch ex As Exception

        End Try
        btnAgregar.Text = "Modificar" : btnEliminar.Text = "Cancelar"
        CodCodigoCompraTextBox.Enabled = True
        CodCodigoCompraTextBox.Focus()
    End Sub

    Private Sub dgvProveedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvProveedor.KeyDown
        If e.KeyCode = Keys.F2 Then
            CodCodigoCompraTextBox.Focus()
        End If
        Try
            ProvFactComboBox.Text = dgvProveedor.CurrentRow.Cells("NOMBRE").Value
            TxtNumProv.Text = dgvProveedor.CurrentRow.Cells("RUC_CIN").Value

            If Config10 = "" Then
                txtTimbrado.Text = ""
            Else
                txtTimbrado.Text = w.FuncionConsultaString("TIMBRADOFACTURA", "PROVEEDOR", "CODPROVEEDOR", ProvFactComboBox.SelectedValue)
            End If

            IsKeyPress = 0
            ProvFactComboBox.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgvProveedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            KeyAscii = 0
            RadGroupBoxProveedor.SendToBack()
            NroFacturaMaskedEditBox1.Focus()

        End If
        If KeyAscii = 42 Then
            UltraPopupControlContainer1.PopupControl = RadGroupBoxProveedor
            UltraPopupControlContainer1.Show()

            TxtBuscaProveedor.Text = "" : TxtBuscaProveedor.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub tsReImprimirAutoF_Click(sender As System.Object, e As System.EventArgs) Handles tsReImprimirAutoF.Click
        '---------------------------------------------- PARA IMPRIMIR EN CASO DE AUTOFACTURAS ---------------------------
        Dim Autofactura As Integer
        Autofactura = w.FuncionConsultaString("convert(int,autofactura)", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
        If Autofactura = 1 Then
            RangoID = w.FuncionConsultaDecimal("RANDOID", "DETPC", "ACTIVO=1 AND CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
            Try
                CantLinea = w.FuncionConsulta("NROLINEASDETALLE", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
                TipoImpresion = w.FuncionConsulta("FORMAIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoCompComboBox.SelectedValue)
                Imprimir = w.FuncionConsulta("IMPRIMIR", "DETPC", "RANDOID", RangoID)
                impresora = f.FuncionConsultaString("IMPRESORA", "DETPC", "RandoId", RangoID)

                'se verifica el tipo de impresion para el tipo de comprobante actuamente seleccionado y de acuerdo a eso realizamos la impresion correspondiente
                'en caso de que este marcado la opcion de imprimir en la ventana "Rango de Comprobantes" 
                If TipoImpresion = 0 Then   'Formato Ticket
                    If Imprimir = 1 Then 'Se imprime
                        ImprimirAutoFacturaTicket()
                    End If
                ElseIf TipoImpresion = 1 Then 'Formato Impresora
                    If Imprimir = 1 Then 'Se imprime
                        ImprimirReporte()
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show("Error al Imprimir,  Mensaje : " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
        End If
    End Sub

    Public Sub RecalcularIVA()
        Try
            Dim i As Integer
            Dim tiva5, tiva10, texenta, ttotal, tcant As Double
            Dim iva10, iva5, exenta As Double

            ttotal = 0 : tcant = 0 : iva10 = 0 : iva5 = 0 : exenta = 0

            For i = 0 To DetalleCompraGridView.RowCount - 1
                If DetalleCompraGridView.Rows(i).Cells("IVA").Value = "5,00" Then
                    tiva5 = 0
                    tiva5 = CDec(DetalleCompraGridView.Rows(i).Cells("Subtotal").Value)
                    tiva5 = tiva5 / 21
                    iva5 = iva5 + tiva5
                ElseIf DetalleCompraGridView.Rows(i).Cells("IVA").Value = "10,00" Then
                    tiva10 = 0
                    tiva10 = CDec(DetalleCompraGridView.Rows(i).Cells("Subtotal").Value)
                    tiva10 = tiva10 / 11
                    iva10 = iva10 + tiva10
                Else
                    texenta = 0
                    texenta = CDec(DetalleCompraGridView.Rows(i).Cells("Subtotal").Value)
                    texenta = texenta
                    exenta = exenta + texenta
                End If
                ttotal = ttotal + CDec(DetalleCompraGridView.Rows(i).Cells("Subtotal").Value)
            Next

            Iva10TextBox1.Text = FormatNumber(iva10, 2)
            Iva5TextBox1.Text = FormatNumber(iva5, 2)
            TotalExentaTextBox1.Text = FormatNumber(exenta, 2)
            umeTotalIva.Text = FormatNumber(iva10 + iva5, 2)
            TotalTextBox1.Text = FormatNumber(ttotal, 2)

        Catch ex As Exception
            If MessageBox.Show("Ocurrio un Error. Si desea ver el mensaje que produce, favor hacer click en si.", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Contacte se con COGENT. Mensaje de Error: " + ex.Message, "COGENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try
    End Sub

    Private Sub pbxBuscarEvento_Click(sender As Object, e As EventArgs) Handles pbxBuscarEvento.Click
        If gbxEventos.Visible = True Then
            gbxEventos.Visible = False
            gbxEventos.SendToBack()
        Else
            EVENTOBindingSource.RemoveFilter()
            gbxEventos.Visible = True
            gbxEventos.BringToFront()
            txtBuscarEvento.Text = ""
        End If
    End Sub

    Private Sub txtBuscarEvento_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarEvento.TextChanged
        EVENTOBindingSource.Filter = "DESCEVENTO LIKE '%" & txtBuscarEvento.Text & "%' OR NUMEVENTO LIKE '%" & txtBuscarEvento.Text & "%'"
    End Sub

    Private Sub dgwEventos_DoubleClick(sender As Object, e As EventArgs) Handles dgwEventos.DoubleClick
        If dgwEventos.Rows.Count <> 0 Then
            CmbEvento.SelectedValue = dgwEventos.CurrentRow.Cells("CODEVENTODataGridViewTextBoxColumn1").Value

            gbxEventos.Visible = False
            gbxEventos.SendToBack()
            CmbEvento.Select()
        End If
    End Sub

    Private Sub txtTimbrado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTimbrado.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CodCodigoCompraTextBox.Focus()
            KeyAscii = 0
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTimbrado_LostFocus(sender As Object, e As EventArgs) Handles txtTimbrado.LostFocus
        'verificamos que el timbrado tenga si o si 8 digitos.
        Dim CantDig As Integer = txtTimbrado.Text.Length
        If CantDig <> 8 And CantDig > 0 Then
            MessageBox.Show("El Timbrado debe tener 8 Digitos", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub RedondearIVASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedondearIVASToolStripMenuItem.Click
        permiso = PermisoAplicado(UsuCodigo, 283)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar los Valores de IVA", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If btNuevo = 0 And btModificar = 0 Then
            pnlRedondeoIVA.Visible = True
            pnlRedondeoIVA.BringToFront()

            txtNvIva10.Text = Iva10TextBox1.Text
            txtNvIva5.Text = Iva5TextBox1.Text
            txtNvExen.Text = TotalExentaTextBox1.Text

            txtNvIva10.Focus()
        End If
    End Sub

    Private Sub txtNvIva10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNvIva10.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtNvIva5.Focus()
            KeyAscii = 0
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNvIva5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNvIva5.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtNvExen.Focus()
            KeyAscii = 0
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNvExen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNvExen.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnModifIVA.Focus()
            KeyAscii = 0
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnModifIVA_Click(sender As Object, e As EventArgs) Handles btnModifIVA.Click
        Try
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            Dim vIva10 As String = Funciones.Cadenas.QuitarCad(txtNvIva10.Text.ToString, ".")
            vIva10 = Replace(vIva10, ",", ".")

            Dim vIva5 As String = Funciones.Cadenas.QuitarCad(txtNvIva5.Text.ToString, ".")
            vIva5 = Replace(vIva5, ",", ".")

            Dim vExen As String = Funciones.Cadenas.QuitarCad(txtNvExen.Text.ToString, ".")
            vExen = Replace(vExen, ",", ".")

            Dim vTiva As String = CDec(txtNvIva10.Text) + CDec(txtNvIva5.Text)
            vTiva = Replace(vTiva, ",", ".")

            sql = ""
            sql = "UPDATE COMPRAS SET TOTALIVA10 = " & vIva10 & ", TOTALIVA5 = " & vIva5 & " , TOTALIVA = " & vTiva & ", TOTALEXENTA = " & vExen & _
                  "  WHERE CODCOMPRA = " & CDec(ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value) & ""

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error al querer Modificar el IVA : " + ex.Message, "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlc.Close()
        End Try
        pnlRedondeoIVA.Visible = False

        compra = Me.ComprasSimpleGridView1.CurrentRow.Cells("CODCOMPRA").Value

        FechaFiltro()
        BtnFiltro_Click(Nothing, Nothing)

        'Buscamos la posicion del registro guardado
        For k = 0 To ComprasSimpleGridView1.RowCount - 1
            If ComprasSimpleGridView1.Rows(k).Cells("CODCOMPRA").Value = compra Then
                COMPRASBindingSource.Position = k
            End If
        Next
    End Sub

    Private Sub CostoComTextBox1_LostFocus(sender As Object, e As EventArgs) Handles CostoComTextBox1.LostFocus
        Try
            If Config11 = "Si" Then
                If CDec(lblPrecio2.Text) <> 0 Then
                    If CDec(CostoComTextBox1.Text) < CDec(lblPrecio2.Text) Then
                        MessageBox.Show("El Precio de Costo BAJO", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    If CDec(CostoComTextBox1.Text) > CDec(lblPrecio2.Text) Then
                        MessageBox.Show("El Precio de Costo SUBIO", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub TxtNumProv_TextChanged(sender As Object, e As EventArgs) Handles TxtNumProv.TextChanged

    End Sub

    Private Sub NroFacturaMaskedEditBox1_MaskChanged(sender As Object, e As Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs) Handles NroFacturaMaskedEditBox1.MaskChanged

    End Sub

    Private Sub tbxComment_Keypressed(sender As Object, e As KeyEventArgs) Handles TextBoxConcepto.KeyDown
        Dim KeyAscii As Short = Asc(e.KeyCode)
        If KeyAscii = 49 Then
            TextBoxConcepto.Text = DetalleCompraGridView.Rows(0).Cells(7).Value.ToString
            e.Handled = True
        End If
    End Sub
End Class

