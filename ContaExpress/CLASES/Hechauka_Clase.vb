Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class Hechauka_Clase
    Dim SQLCmd As New SqlCommand
    Dim ser As New BDConexión.BDConexion
    Dim f As New Funciones.Funciones
    Dim sw As StreamWriter


    Dim connString As String = My.Settings.GESTIONConnectionString2.ToString()
    Dim myConn As SqlConnection
    Dim myCmd As SqlCommand
    Dim myReader As SqlDataReader
    Dim mySQLReader As SqlDataReader
    Dim dt As New DataTable

    Enum TipoDocumento
        nada_porningun
        Factura
        Nota_de_Debito
        Nota_de_Credito
        Despacho
        AutoFactura
        nada_alla
        PasajeAereo
        Factura_Exterior
        Planilla_Sueldo
        Comprobante_Ingreso
        Retencion_Absorbido
        nada_aqui
        PAsajeAereoElectronico
    End Enum

    Enum TipoCompraVenta
        nada_por
        Contado
        Credito
    End Enum

    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    tbxUbicacion.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    '    dtpDesde.CustomFormat = "MM"
    '    dtpHasta.CustomFormat = "MM"
    'End Sub


    Public Sub Hechauka_Comrpas(listarAnuladas As Boolean,
                                cbxComprobante As String,
                                cbxDesde As String,
                                cbxHasta As String,
                                cbxMes As String,
                                cbxAño As String,
                        Localizacion As String,
                        _file As String,
                        TipoReporte As Integer,
                        ByRef chbxAsentado As RadioButton)
        Dim RecordCounter As Integer = 1
        Dim TotalCompra As Decimal = 0
        Dim TotalDevolucion As Integer = 0
        Dim line As String

        'Cabecera
        Const _TipoRegistroCabecera As Integer = 1
        Dim _Periodo As String = cbxAño & cbxMes
        Dim dtpFechaDesde As String = cbxDesde & "/" & cbxMes & "/" & cbxAño
        Dim dtpFechaHasta As String = cbxHasta & "/" & cbxMes & "/" & cbxAño
        'Dim _TipoReporte As Integer = IIf(rbtRectificativa.Checked, 2, 1)
        Dim _TipoReporte = TipoReporte
        Dim _CodigoObligacion As Integer = 911
        Dim _CodigoFormulario As Integer = 211
        Dim _RUC As String
        Dim _DV As Integer
        Dim _NombreAgente As String
        Dim _RUC_Representante As String = "0"
        Dim _DV_Representante As Integer = 0
        Dim _NombreRepresentante As String = String.Empty
        Dim _CantidadRegistros As Integer
        Dim _MontoTotal_sinIVA As Decimal
        Dim Exportador As String = "NO"
        Dim Version As Integer = 2

        'Detalle Compra
        Const _TipoRegistroDetalle As Integer = 2
        Dim _Proveedor_RUC As String : Dim _Proveedor_DV As Integer
        Dim _Proveedor_Nombre As String
        Dim _Proveedor_Timbrado As Integer
        Dim _TipoDocumento As Integer = TipoDocumento.Factura
        Dim _NumeroDocumento As String : Dim _FechaDocumento As Date
        Dim _IVA10 As Integer : Dim _Total_SinIVA10 As Integer
        Dim _IVA5 As Integer : Dim _Total_SinIVA5 As Integer
        Dim _GRAVADO5 As Integer
        Dim _Total_Excenta As Integer
        Dim _TipoOperacion As Integer : Dim _TipoCompra As Integer
        Dim _CantidadCuotas As Integer
        Dim PosGuion As Integer
        'Dim _file As String = tbxUbicacion.Text & "\HechaukaCompras[" & _Periodo & "].txt"
        Dim objWriter As New System.IO.StreamWriter(_file)
        'Dejar primera fila vacia para lluego llenar.
        objWriter.WriteLine("")


        Try
            Dim sql As String = "SELECT dbo.COMPRAS.CODCOMPRA, dbo.COMPRAS.NUMCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.PROVEEDOR.RUC_CIN, dbo.PROVEEDOR.NOMBRE,dbo.COMPRAS.MODALIDADPAGO, " & _
                                "dbo.COMPRAS.TIMBRADOPROV, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, (dbo.COMPRAS.TOTALIVA10 *11) - dbo.COMPRAS.TOTALIVA10  AS Iva10, " & _
                                " (dbo.COMPRAS.TOTALIVA5 * 21) -dbo.COMPRAS.TOTALIVA5 AS Iva5, dbo.COMPRAS.TOTALIVA5, dbo.COMPRAS.TOTALIVA10, dbo.COMPRAS.TOTALEXENTA, dbo.COMPRAS.ESTADO,  " & _
                                "dbo.TIPOCOMPROBANTE.IDCOMPROBANTE, MAX(dbo.FACTURAPAGAR.NUMEROCUOTA) AS CUOTAS FROM dbo.COMPRAS INNER JOIN " & _
                                "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR INNER JOIN " & _
                                "dbo.TIPOCOMPROBANTE ON dbo.COMPRAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN  " & _
                                "dbo.FACTURAPAGAR ON dbo.COMPRAS.CODCOMPRA = dbo.FACTURAPAGAR.CODCOMPRA LEFT OUTER JOIN  " & _
                                "dbo.COMPRASDETALLE ON dbo.COMPRAS.CODCOMPRA = dbo.COMPRASDETALLE.CODCOMPRA " & _
                                "GROUP BY dbo.COMPRAS.NUMCOMPRA, dbo.PROVEEDOR.RUC_CIN, dbo.PROVEEDOR.NOMBRE, dbo.COMPRAS.TIMBRADOPROV, dbo.COMPRAS.MODALIDADPAGO,  " & _
                                "dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, dbo.COMPRAS.TOTALGRAVADO5, dbo.COMPRAS.TOTALIVA5, dbo.COMPRAS.TOTALGRAVADO10, " & _
                                "dbo.COMPRAS.TOTALIVA10, dbo.COMPRAS.TOTALEXENTA, dbo.COMPRAS.CODCOMPRA, dbo.COMPRAS.FECHACOMPRA, dbo.COMPRAS.ESTADO, " & _
                                "dbo.COMPRAS.ASENTADO, dbo.TIPOCOMPROBANTE.IDCOMPROBANTE " & _
                                "HAVING (dbo.COMPRAS.FECHACOMPRA >= CONVERT(DATETIME, '" & dtpFechaDesde & " 00:00:00', 103)) AND (dbo.COMPRAS.FECHACOMPRA <= CONVERT(DATETIME, '" & dtpFechaHasta & " 23:59:59', 103)) "
            DataAccessLayer(sql)
        Catch ex As Exception
            MsgBox("Error al Abrir Conexion con la Base de Datos. Verifique Conexion. EX= " + ex.Message)
            Exit Sub
        End Try

        For Each row In dt.Rows
            _Proveedor_RUC = row("RUC_CIN")
            PosGuion = InStr(_Proveedor_RUC, "-")
            _Proveedor_RUC = _Proveedor_RUC.Substring(0, PosGuion - 1)
            'hacer codigo de limpieza
            _Proveedor_DV = DVcalculo(_Proveedor_RUC)
            _Proveedor_Nombre = row("NOMBRE")
            _Proveedor_Timbrado = row("TIMBRADOPROV")
            _TipoDocumento = TipoDocumentoCalc(row("DESCOMPROBANTE"))
            If _Proveedor_RUC = "99999901" Then
                _TipoDocumento = 4
            End If

            _NumeroDocumento = row("NUMCOMPRA")
            'limpieza de sql para traer solo fecha no la hora
            _FechaDocumento = row("FECHACOMPRA")
            _FechaDocumento = _FechaDocumento.Date
            _IVA10 = Math.Round(row("TOTALIVA10"), 0)
            _Total_SinIVA10 = (_IVA10 * 11) - _IVA10
            _IVA5 = Math.Round(row("TOTALIVA5"), 0)
            _GRAVADO5 = Math.Round(row("IVA5"), 0)
            _Total_SinIVA5 = (_Total_SinIVA5 * 11) - _Total_SinIVA5
            _Total_Excenta = Math.Round(row("TOTALEXENTA"), 0)
            _TipoOperacion = 0 'NOSE QUE HACER
            _TipoCompra = TipoCompraVentaCalc(row("MODALIDADPAGO"))
            _CantidadCuotas = IIf(_TipoCompra = TipoCompraVenta.Contado, 0, row("CUOTAS"))

            'Para Cabecera
            TotalCompra = TotalCompra + _Total_SinIVA10 + _Total_SinIVA5 + _Total_Excenta + _GRAVADO5

            line = _TipoRegistroDetalle & vbTab & _Proveedor_RUC & vbTab & _Proveedor_DV & _
                vbTab & _Proveedor_Nombre & vbTab & _Proveedor_Timbrado & vbTab & _TipoDocumento & vbTab & _NumeroDocumento & _
                vbTab & _FechaDocumento & vbTab & _Total_SinIVA10 & vbTab & _IVA10 & vbTab & _GRAVADO5 & vbTab & _IVA5 & _
                vbTab & _Total_Excenta & vbTab & _TipoOperacion & vbTab & _TipoCompra & vbTab & _CantidadCuotas

            objWriter.WriteLine(line)
            _CantidadRegistros += 1
        Next

        'Detalle Devolucion Venta SIN CONSOLIDAR
        Try
            Dim SqlWhere As String = " AND (dbo.DEVOLUCION.ASENTADO <> 0)"
            If chbxAsentado.Checked Then
                SqlWhere.Replace("<> 0", "= 2")
            End If
            If listarAnuladas Then
                'incluye 1 & 2. ignora 0
                SqlWhere = SqlWhere & " AND (dbo.DEVOLUCION.ESTADO <> 0)"
            Else
                SqlWhere = SqlWhere & " AND (dbo.DEVOLUCION.ESTADO = 1)"
            End If
            'If cmbComprobante.Text <> "%" Then
            '    SqlWhere1 = SqlWhere1 + " AND TIPOCOMPROBANTE.IDCOMPROBANTE IN (" & cmbComprobante.Text & ")"
            'End If
            dt.Clear()
            Dim sql As String = " SELECT dbo.CLIENTES.RUC, dbo.CLIENTES.NOMBRE, TIPOCOMPROBANTE_1.DESCOMPROBANTE, dbo.DEVOLUCION.NUMDEVOLUCION, dbo.DEVOLUCION.FECHADEVOLUCION, dbo.DEVOLUCION.TOTALEXENTA," & _
                                " dbo.DEVOLUCION.TOTALGRAVADA, dbo.DEVOLUCION.TOTALIVA, dbo.DEVOLUCION.TOTALDESCUENTO, dbo.DEVOLUCION.TOTALDEVOLUCION, dbo.DEVOLUCION.COBRADO, dbo.DEVOLUCION.ESTADO," & _
                                " dbo.DEVOLUCION.TOTALIVA5, dbo.DEVOLUCION.TOTALIVA10, SUBSTRING(dbo.DEVOLUCION.NUMDEVOLUCION, 5, 3) AS NUMMAQUINA" & _
                                " FROM dbo.DEVOLUCION INNER JOIN" & _
                                " dbo.CLIENTES ON dbo.DEVOLUCION.CODCLIENTE = dbo.CLIENTES.CODCLIENTE INNER JOIN" & _
                                " dbo.TIPOCOMPROBANTE AS TIPOCOMPROBANTE_1 ON dbo.DEVOLUCION.CODCOMPROBANTE = TIPOCOMPROBANTE_1.CODCOMPROBANTE" & _
                                " WHERE (dbo.DEVOLUCION.FECHADEVOLUCION >= CONVERT(DATETIME,'" & dtpFechaDesde & "',103)) AND (dbo.DEVOLUCION.FECHADEVOLUCION <= CONVERT(DATETIME,'" & dtpFechaHasta & "',103))" & SqlWhere
            DataAccessLayer(sql)
        Catch ex As Exception
            MsgBox("Error al Abrir Conexion con la Base de Datos. Verifique Conexion. EX= " + ex.Message)
            Exit Sub
        End Try

        For Each row In dt.Rows
            _Proveedor_RUC = row("RUC")
            PosGuion = InStr(_Proveedor_RUC, "-")
            _Proveedor_RUC = _Proveedor_RUC.Substring(0, PosGuion - 1)
            'hacer codigo de limpieza
            _Proveedor_DV = DVcalculo(_Proveedor_RUC)
            _Proveedor_Nombre = row("NOMBRE")
            '_Proveedor_Timbrado = 0 'buscar
            _TipoDocumento = TipoDocumentoCalc(row("DESCOMPROBANTE"))
            _NumeroDocumento = row("NUMDEVOLUCION")
            _NumeroDocumento = _NumeroDocumento.Replace(".", "-")
            'limpieza de sql para traer solo fecha no la hora
            _FechaDocumento = row("FECHADEVOLUCION")
            _FechaDocumento = _FechaDocumento.Date
            _IVA10 = Math.Round(row("TOTALIVA10"), 0)
            _Total_SinIVA10 = (_IVA10 * 11) - _IVA10
            _IVA5 = Math.Round(row("TOTALIVA5"), 0)
            _Total_SinIVA5 = (_Total_SinIVA5 * 11) - _Total_SinIVA5
            _Total_Excenta = Math.Round(row("TOTALEXENTA"), 0)
            _TipoOperacion = 0 'NOSE QUE HACER
            _TipoCompra = TipoCompraVenta.Contado
            _CantidadCuotas = 0

            Dim vnTimbrado As String = f.FuncionConsultaString("dbo.DETPC.TIMBRADO", "dbo.PC INNER JOIN dbo.DETPC ON dbo.PC.IP = dbo.DETPC.IP INNER JOIN " & _
                                       "dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE", "dbo.DETPC.ACTIVO = 1 AND dbo.TIPOCOMPROBANTE.NCREDITO = 1 AND dbo.PC.NUMMAQUINA", row("NUMMAQUINA"))

            'Para Cabecera
            TotalDevolucion = TotalDevolucion + _Total_SinIVA10 + _Total_SinIVA5 + _Total_Excenta

            line = _TipoRegistroDetalle & vbTab & _Proveedor_RUC & vbTab & _Proveedor_DV & _
                    vbTab & _Proveedor_Nombre & vbTab & vnTimbrado & vbTab & _TipoDocumento & vbTab & _NumeroDocumento & _
                    vbTab & _FechaDocumento & vbTab & _Total_SinIVA10 & vbTab & _IVA10 & vbTab & _Total_SinIVA5 & vbTab & _IVA5 & _
                    vbTab & _Total_Excenta & vbTab & _TipoOperacion & vbTab & _TipoCompra & vbTab & _CantidadCuotas
            _CantidadRegistros += 1
            objWriter.WriteLine(line)
        Next

        Try
            Dim sql As String = " SELECT RUCCONTRIBUYENTE, NOMCONTRIBUYENTE,RUCREPRESENTANTE, NOMREPRESENTANTE " & _
                                " FROM EMPRESA"
            DataAccessLayer(sql)
        Catch ex As Exception
            MsgBox("Error al Abrir Conexion con la Base de Datos. Verifique Conexion.")
            Exit Sub
        End Try

        For Each row In dt.Rows
            _RUC = row("RUCCONTRIBUYENTE")
            PosGuion = InStr(_RUC, "-")
            If PosGuion <> 0 Then
                _RUC = _RUC.Substring(0, PosGuion - 1)
            End If
            _DV = DVcalculo(_RUC)
            _NombreAgente = row("NOMCONTRIBUYENTE")
            _RUC_Representante = row("RUCREPRESENTANTE")
            PosGuion = InStr(row("RUCREPRESENTANTE"), "-")
            If PosGuion <> 0 Then
                _RUC_Representante = _RUC_Representante.Substring(0, PosGuion - 1)
            End If
            _DV_Representante = DVcalculo(_RUC_Representante)
            _NombreRepresentante = row("NOMREPRESENTANTE")
            _MontoTotal_sinIVA = TotalCompra + TotalDevolucion
            objWriter.Close()
            Dim lines As String() = System.IO.File.ReadAllLines(_file)

            Dim cadena As String = _TipoRegistroCabecera & vbTab & _Periodo & vbTab & _TipoReporte & _
                vbTab & _CodigoObligacion & vbTab & _CodigoFormulario & vbTab & _RUC & vbTab & _DV & _
                vbTab & _NombreAgente & vbTab & _RUC_Representante & vbTab & _DV_Representante & vbTab & _NombreRepresentante & vbTab & _CantidadRegistros & _
                vbTab & _MontoTotal_sinIVA & vbTab & Exportador & vbTab & Version
            lines(0) = cadena
            System.IO.File.WriteAllLines(_file, lines)

            MessageBox.Show("Archivo Generado Correctamente", "Cognitivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Next
        objWriter.Close()
        objWriter.Dispose()
    End Sub

    Private Sub DataAccessLayer(sql As String)

        Dim sqlconn As New SqlConnection(My.Settings.GESTIONConnectionString2.ToString())
        Dim sqlcmd As New SqlCommand
        Dim sqldr As SqlDataReader
        'Dim dt As New DataTable
        If dt IsNot Nothing Then
            dt.Clear()
            dt.Dispose()
        End If

        sqlconn.Open()
        sqlcmd = New SqlCommand(sql, sqlconn)
        Try
            sqldr = sqlcmd.ExecuteReader
            dt.Load(sqldr)
            sqldr.Close()
        Catch ex As Exception
            Throw ex
        Finally
            sqlconn.Close()
        End Try
        'SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
        'SQLCmd.Connection.Open()
        'odrDetalle = SQLCmd.ExecuteReader()
        'Dim connstring As String = "Data Source=COGNITIVO-HP\HPDESARROLLO;Initial Catalog=Cultural;User ID=sa;Password=Cognitivo360"
        'myConn = New SqlConnection(connstring)
        'dt.Clear()
        'SQLCmd = New SqlCommand(sql, ser.CadenaConexion)
        'SQLCmd.Connection.Open()
        'odrDetalle = SQLCmd.ExecuteReader
        'dt.Load(odrDetalle)
        'odrDetalle.Close()
        'SQLCmd.Dispose()
        'SQLCmd.Connection.Close()
        'Dim connstring As String = "Data Source=COGNITIVO-HP\HPDESARROLLO;Initial Catalog=Cultural;User ID=sa;Password=Cognitivo360"
        'myConn = New SqlConnection(connstring)
        'dt.Clear()
        'myConn.Open()
        'myCmd = New SqlCommand(sql, myConn)
        'mySQLReader = myCmd.ExecuteReader
        'dt.Load(mySQLReader)
        'mySQLReader.Close()
        'myCmd.Dispose()
        'myConn.Close()
    End Sub

    Private Function TipoDocumentoCalc(_doc As String)
        If _doc.Contains("Factura") Then
            Return TipoDocumento.Factura
        ElseIf _doc.Contains("Debito") Then
            Return TipoDocumento.Nota_de_Debito
        ElseIf _doc.Contains("Credito") Then
            Return TipoDocumento.Nota_de_Credito
        ElseIf _doc.Contains("Auto") Then
            Return TipoDocumento.AutoFactura
        Else
            Return TipoDocumento.Factura
        End If
    End Function

    Private Function TipoCompraVentaCalc(_TipoCompra As String)
        If _TipoCompra = 0 Then
            Return TipoCompraVenta.Contado
        Else
            Return TipoCompraVenta.Credito
        End If
    End Function

    Function DVcalculo(ByVal numero As String, Optional basemax As Integer = 11) As String
        Dim codigo As Long
        Dim numero_al As String = ""

        Dim i
        For i = 1 To Len(numero)
            Dim c
            c = Mid$(numero, i, 1)
            codigo = Asc(UCase(c))
            If Not (codigo >= 48 And codigo <= 57) Then
                numero_al = numero_al & codigo
            Else
                numero_al = numero_al & c
            End If
        Next

        Dim k : Dim total
        k = 2
        total = 0

        For i = Len(numero_al) To 1 Step -1
            If (k > basemax) Then k = 2
            Dim numero_aux
            numero_aux = Val(Mid(numero_al, i, 1))
            total = total + (numero_aux * k)
            k = k + 1
        Next

        Dim resto : Dim digito
        resto = total Mod 11
        If (resto > 1) Then
            digito = 11 - resto
        Else
            digito = 0
        End If
        Return digito
    End Function

    Sub Hechauka_Ventas(listarAnuladas As Boolean, cbxComprobante As String, cbxMes As String, cbxDesde As String,
                        Localizacion As String, cbxHasta As String, cbxAño As String, ruta As String, TipoReporte As Integer)

        Dim sqlwhere As String = ""
        Dim TotVenta As Decimal = 0
        Dim cantreg As Integer = 0
        Dim cantfile As Integer = 0
        Dim recordet As Integer = 0
        Dim modalidadpago As Integer = 0
        Dim Cuotas As Integer = 0
        Dim nroTimbrado As Integer = 0

        Dim Contribuyente As String = ""
        Dim Representante As String = ""
        Dim RucContribuyente As String = ""
        Dim DVContribuyente As String = ""
        Dim RucRepresentante As String = ""
        Dim DVRepresentante As String = ""
        Dim txtCadena As String
        Dim offset As Integer = 0
        'Dim sinnombre As Integer = 0
        Dim numberfile As Integer = 0
        Dim NroDocumento As String = ""
        Dim RucCliente As String
        Dim rutaExtra As String = Localizacion & "\" & cbxMes & cbxAño & "- VentaHechauka (" & numberfile & ").txt"

        Try
            'consulta sql para saber cantidad de registros
            If listarAnuladas = True Then
                sqlwhere = " AND (dbo.VENTAS.ESTADO <> 0) "
            Else
                sqlwhere = " AND (dbo.VENTAS.ESTADO = 1) "
            End If

            If cbxComprobante <> "%" Then
                sqlwhere = sqlwhere + " AND dbo.TIPOCOMPROBANTE.IDCOMPROBANTE IN (" & cbxComprobante & ")"
            End If

            Dim fechaDesde As String = cbxDesde + "/" + cbxMes + "/" + cbxAño + " 00:00:00"
            Dim fechaHasta As String = cbxHasta + "/" + cbxMes + "/" + cbxAño + " 23:59:59"

            SQLCmd.CommandText = "SELECT COUNT(dbo.VENTAS.NUMVENTA) AS CantReg " & _
                                 " FROM dbo.VENTAS INNER JOIN " & _
                                 " dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE INNER JOIN " & _
                                 " dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                 " WHERE (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & fechaDesde & "', 103)) AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME, '" & fechaHasta & "', 103)) AND (dbo.CLIENTES.CODCLIENTE <> 1) " & _
                                 " " & sqlwhere

            SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
            SQLCmd.Connection.Open()
            odrDetalle = SQLCmd.ExecuteReader()

            If odrDetalle.HasRows Then
                Do While odrDetalle.Read()
                    If listarAnuladas = True Then
                        cantreg = odrDetalle("CantReg") + 1
                    Else
                        cantreg = odrDetalle("CantReg")
                    End If
                Loop
            End If

            SQLCmd.CommandText = ""
            SQLCmd.CommandText = " SELECT SUM(dbo.VENTAS.TOTALVENTA) AS TOTALVENTA " & _
                                 " FROM dbo.VENTAS INNER JOIN " & _
                                 " dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE INNER JOIN " & _
                                 " dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                 " WHERE (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & fechaDesde & "', 103)) AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME, '" & fechaHasta & "', 103)) AND " & _
                                 " (dbo.VENTAS.ESTADO = 1)"

            odrDetalle.Close()
            SQLCmd.Dispose()
            SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
            SQLCmd.Connection.Open()
            odrDetalle = SQLCmd.ExecuteReader()

            If odrDetalle.HasRows Then
                Do While odrDetalle.Read()
                    TotVenta = FormatNumber(odrDetalle("TOTALVENTA"), 0)
                    TotVenta = Funciones.Cadenas.QuitarCad(TotVenta, ".")
                Loop
            End If

            odrDetalle.Close()
            SQLCmd.Dispose()
            'FIN CONTADOR

            Dim cada15mil As Integer
            If cantreg > 14000 Then
                cada15mil = cantreg / 14000
            Else
                cada15mil = 1
            End If

            'INICIO ENCABEZADO
            SQLCmd.CommandText = " SELECT DATEPART(yyyy, dbo.periodofiscal.FECHAINICIO) AS Anho, DATEPART(month, GETDATE()) AS Mes, dbo.EMPRESA.RUCCONTRIBUYENTE, " & _
                                 " dbo.EMPRESA.NOMCONTRIBUYENTE, dbo.EMPRESA.NOMREPRESENTANTE, dbo.EMPRESA.RUCREPRESENTANTE " & _
                                 " FROM dbo.periodofiscal CROSS JOIN dbo.EMPRESA " & _
                                 " WHERE (dbo.periodofiscal.ESTADO = 1) "

            SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
            SQLCmd.Connection.Open()
            Dim odrEncabezado As SqlDataReader = SQLCmd.ExecuteReader()

            If odrEncabezado.HasRows Then
                Do While odrEncabezado.Read()
                    Contribuyente = odrEncabezado("NOMCONTRIBUYENTE")
                    Representante = odrEncabezado("NOMREPRESENTANTE")

                    If odrEncabezado("RUCCONTRIBUYENTE") <> "" Then
                        PosGuion = InStr(odrEncabezado("RUCCONTRIBUYENTE"), "-")
                        RucContribuyente = odrEncabezado("RUCCONTRIBUYENTE")
                        If PosGuion <> 0 Then
                            RucContribuyente = Trim(RucContribuyente.Substring(0, PosGuion - 1))
                        End If
                        DVContribuyente = DVcalculo(RucContribuyente, 11)
                    Else
                        RucContribuyente = ""
                        DVContribuyente = ""
                    End If

                    If odrEncabezado("RUCREPRESENTANTE") <> "" Then
                        PosGuion = InStr(odrEncabezado("RUCREPRESENTANTE"), "-")
                        RucRepresentante = odrEncabezado("RUCREPRESENTANTE")
                        If PosGuion <> 0 Then
                            RucRepresentante = RucRepresentante.Substring(0, PosGuion - 1)
                        End If
                        DVRepresentante = DVcalculo(RucRepresentante, 11)
                    Else
                        RucRepresentante = ""
                        DVRepresentante = ""
                    End If
                Loop
            End If

            odrEncabezado.Close()
            SQLCmd.Dispose()
            'FIN ENCABEZADO

            'INICIO DETALLE

            rutaExtra = Localizacion & "\" & cbxMes & cbxAño & "- VentaHechauka.txt"

            If File.Exists(rutaExtra) = True Then
                If MessageBox.Show("Archivo " & cbxMes & cbxAño & "- VentaHechauka (" & numberfile & ").txt, ya existe, desea sobreescribirlo", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    Try
                        File.Delete(rutaExtra)
                    Catch ex As Exception

                    Finally
                        sw = File.CreateText(rutaExtra)
                    End Try

                Else
                    'si usuario no quiere sobreescribir, no se hace nada...
                    Exit Sub
                End If
            Else
                sw = File.CreateText(rutaExtra)
            End If

            txtCadena = "1" & vbTab & cbxAño + cbxMes & vbTab & TipoReporte & vbTab & "921" & vbTab & "221" & vbTab & RucContribuyente & vbTab & DVContribuyente & vbTab & _
                Contribuyente & vbTab & RucRepresentante & vbTab & DVRepresentante & vbTab & Representante & vbTab & cantreg & vbTab & TotVenta & vbTab & "2"

            sw.WriteLine(txtCadena)


            For recordet = 1 To cada15mil
                Dim VentasDetalle As New DataTable
                'If sinnombre = 0 Then
                '    SQLCmd.CommandText = ""
                '    SQLCmd.CommandText = "SELECT dbo.VENTAS.CODVENTA,dbo.VENTAS.NUMVENTA, dbo.VENTAS.FECHAVENTA, dbo.CLIENTES.RUC, " & _
                '                        " dbo.CLIENTES.NOMBRE, dbo.CLIENTES.TIMBRADOFACTURA, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, " & _
                '                        " MAX(dbo.FACTURACOBRAR.CODNUMEROCUOTA ) AS CUOTAS, DBO.VENTAS.MODALIDADPAGO," & _
                '                        " (dbo.VENTAS.TOTALGRAVADO10 - dbo.VENTAS.TOTAL10) AS TOTALGRAVADO10, " & _
                '                        " (dbo.VENTAS.TOTALGRAVADO5 - dbo.VENTAS.TOTAL5 ) AS TOTALGRAVADO5, " & _
                '                        " dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTAL10, (select timbrado from detpc where ventas.CODRANGO = DETPC.RANDOID) as TIMBRADO," & _
                '                        " dbo.VENTAS.TOTALVENTA, dbo.VENTAS.TOTALEXENTA, dbo.VENTAS.ESTADO, dbo.VENTAS.COTIZACION1" & _
                '                        " FROM dbo.VENTAS" & _
                '                        " INNER JOIN dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE " & _
                '                        " INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE" & _
                '                        " INNER JOIN  dbo.FACTURACOBRAR ON dbo.VENTAS.CODVENTA = dbo.FACTURACOBRAR.CODVENTA " & _
                '                        " INNER JOIN dbo.DETPC ON dbo.VENTAS.CODRANGO = dbo.DETPC.RANDOID" & _
                '                        " GROUP BY dbo.VENTAS.NUMVENTA, dbo.VENTAS.FECHAVENTA, dbo.VENTAS.CODVENTA, " & _
                '                        " dbo.CLIENTES.RUC, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.TIMBRADOFACTURA, dbo.VENTAS.ESTADO, " & _
                '                        " dbo.VENTAS.ASENTADO, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, dbo.VENTAS.TOTALGRAVADO5, DBO.VENTAS.MODALIDADPAGO," & _
                '                        " dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTALGRAVADO10, dbo.VENTAS.TOTAL10, dbo.VENTAS.TOTALVENTA,   dbo.VENTAS.CODRANGO," & _
                '                        " dbo.VENTAS.TOTALEXENTA, dbo.TIPOCOMPROBANTE.IDCOMPROBANTE, dbo.VENTAS.COTIZACION1  " & _
                '                        " HAVING(dbo.VENTAS.FECHAVENTA >= Convert(DateTime, '" & fechaDesde & "', 103))" & _
                '                        " AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME,'" & fechaHasta & "' ,103))   " & _
                '                        " AND (dbo.VENTAS.ESTADO = 1)  AND (dbo.CLIENTES.RUC <> '44444401-7') " & _
                '                        " ORDER BY dbo.VENTAS.NUMVENTA ASC OFFSET 0 ROWS FETCH NEXT 14999 ROWS ONLY;  "

                '    SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
                '    SQLCmd.Connection.Open()

                '    VentasDetalle.Load(SQLCmd.ExecuteReader)
                '    SQLCmd.Dispose()
                '    SQLCmd.Connection.Close()



                'Else
                SQLCmd.CommandText = ""
                SQLCmd.CommandText = "SELECT  dbo.VENTAS.CODVENTA, dbo.VENTAS.NUMVENTA, dbo.VENTAS.FECHAVENTA, dbo.CLIENTES.RUC, dbo.CLIENTES.NOMBRE, " & _
                                    " dbo.CLIENTES.TIMBRADOFACTURA, dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, " & _
                                    " MAX(dbo.FACTURACOBRAR.CODNUMEROCUOTA ) AS CUOTAS, DBO.VENTAS.MODALIDADPAGO," & _
                                     "(dbo.VENTAS.TOTALGRAVADO10 - dbo.VENTAS.TOTAL10) AS TOTALGRAVADO10, (dbo.VENTAS.TOTALGRAVADO5 - dbo.VENTAS.TOTAL5 ) AS TOTALGRAVADO5," & _
                                     " dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTAL10, dbo.VENTAS.TOTALVENTA, dbo.VENTAS.TOTALEXENTA, dbo.VENTAS.ESTADO, " & _
                                     "dbo.VENTAS.COTIZACION1, (select timbrado from detpc where ventas.CODRANGO = DETPC.RANDOID) as TIMBRADO " & _
                                     "FROM dbo.VENTAS " & _
                                     " INNER JOIN dbo.CLIENTES ON dbo.VENTAS.CODCLIENTE = dbo.CLIENTES.CODCLIENTE " & _
                                     " INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.VENTAS.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                     " LEFT OUTER JOIN  dbo.FACTURACOBRAR ON dbo.VENTAS.CODVENTA = dbo.FACTURACOBRAR.CODVENTA " & _
                                    " LEFT OUTER JOIN dbo.DETPC ON dbo.VENTAS.CODRANGO = dbo.DETPC.RANDOID " & _
                                     "GROUP BY dbo.VENTAS.NUMVENTA, dbo.VENTAS.CODVENTA, dbo.VENTAS.FECHAVENTA, dbo.CLIENTES.RUC, DBO.VENTAS.MODALIDADPAGO, dbo.CLIENTES.NOMBRE, dbo.CLIENTES.TIMBRADOFACTURA, dbo.VENTAS.ESTADO, dbo.VENTAS.ASENTADO, " & _
                                     "dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, dbo.VENTAS.TOTALGRAVADO5, dbo.VENTAS.TOTAL5, dbo.VENTAS.TOTALGRAVADO10, dbo.VENTAS.TOTAL10, dbo.VENTAS.TOTALVENTA,  " & _
                                     "dbo.VENTAS.TOTALEXENTA, dbo.TIPOCOMPROBANTE.IDCOMPROBANTE, dbo.VENTAS.COTIZACION1, dbo.VENTAS.CODRANGO " & _
                                     " HAVING (dbo.VENTAS.FECHAVENTA >= CONVERT(DATETIME, '" & fechaDesde & "', 103)) AND (dbo.VENTAS.FECHAVENTA <= CONVERT(DATETIME, '" & fechaHasta & "',103)) " & _
                                     " " & sqlwhere & " AND (dbo.CLIENTES.RUC <> '44444401-7') ORDER BY dbo.VENTAS.NUMVENTA ASC OFFSET 0 ROWS FETCH NEXT 14999 ROWS ONLY; "

                SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
                SQLCmd.Connection.Open()

                VentasDetalle.Load(SQLCmd.ExecuteReader)
                SQLCmd.Dispose()
                SQLCmd.Connection.Close()

                'End If

                For i As Integer = 0 To VentasDetalle.Rows.Count - 1
                    Dim codventa As String = VentasDetalle.Rows(i).Item("CODVENTA")
                    Dim NUMVENTA As String
                    Dim RUC As String = VentasDetalle.Rows(i).Item("RUC").ToString()
                    Dim DESCOMPROBANTE As String = VentasDetalle.Rows(i).Item("DESCOMPROBANTE").ToString()
                    Dim Estado As Integer = VentasDetalle.Rows(i).Item("Estado")
                    'If sinnombre = 0 Then
                    '    NUMVENTA = f.FuncionConsultaString("NUMVENTA", "VENTAS", "CODVENTA", codventa)
                    '    NUMVENTA = NUMVENTA.Replace(".", "-")
                    'Else
                    NUMVENTA = VentasDetalle.Rows(i).Item("NUMVENTA").Replace(".", "-")
                    'End If
                    Dim FECHAVENTA As String = VentasDetalle.Rows(i).Item("FECHAVENTA").ToString()
                    Dim TOTAL5 As Decimal = VentasDetalle.Rows(i).Item("TOTAL5")
                    Dim TOTAL10 As Decimal = VentasDetalle.Rows(i).Item("TOTAL10")
                    Dim Iva10 As Decimal = VentasDetalle.Rows(i).Item("TOTALGRAVADO10")
                    Dim Iva5 As Decimal = VentasDetalle.Rows(i).Item("TOTALGRAVADO5")
                    Dim TOTALVENTA As Decimal = VentasDetalle.Rows(i).Item("TOTALVENTA")
                    Dim TOTALEXENTA As Decimal = VentasDetalle.Rows(i).Item("TOTALEXENTA")
                    Dim ClienteNombre As String
                    'If sinnombre = 0 Then
                    '    ClienteNombre = "IMPORTES CONSOLIDADOS"
                    'Else
                    ClienteNombre = VentasDetalle.Rows(i).Item("NOMBRE").ToString()
                    'End If

                    If VentasDetalle.Rows(i).Item("MODALIDADPAGO") = 0 Then
                        modalidadpago = 1
                    Else
                        modalidadpago = 2

                    End If

                    If modalidadpago = 1 And VentasDetalle.Rows(i).Item("Cuotas") = 1 Then
                        Cuotas = 0
                    ElseIf VentasDetalle.Rows(i).Item("Cuotas") >= 1 Then
                        Cuotas = VentasDetalle.Rows(i).Item("Cuotas")
                    End If

                    timbrado = VentasDetalle.Rows(i).Item("TIMBRADO")

                    If RUC <> "" Then
                        PosGuion = InStr(RUC, "-")
                        RucCliente = RUC
                        If PosGuion <> 0 Then
                            RucCliente = RucCliente.Substring(0, PosGuion - 1)

                        End If
                        DVCliente = DVcalculo(RucCliente, 11)
                    Else
                        RucCliente = ""
                        DVCliente = ""
                    End If

                    NroDocumento = RucCliente

                    Dim TipoFactura As Integer = 1
                    'Select Case "DESCOMPROBANTE"
                    Select Case DESCOMPROBANTE
                        Case "Factura" : TipoFactura = 1
                        Case "Nota de Débito" : TipoFactura = 2
                        Case "Nota de Crédito" : TipoFactura = 3
                        Case "Ticket"
                            'Si es ticket debemos verificar que sea con valor o sin valor fiscal
                            Dim ValorFical As Integer = 0
                            ValorFical = f.FuncionConsultaDecimal("VALORFISCAL", "TIPOCOMPROBANTE", "DESCOMPROBANTE", "Ticket")
                            If ValorFical = 1 Then
                                TipoFactura = 1
                            Else
                                TipoFactura = 6
                            End If
                    End Select

                    Dim fecha2 As DateTime
                    fecha2 = FECHAVENTA
                    Dim ventaFecha As DateTime = fecha2.ToString("dd/MM/yyy")

                    If (Estado = 2) And (listarAnuladas = True) Then
                        TOTAL5 = 0 : TOTAL10 = 0 : Iva10 = 0 : Iva5 = 0 : TOTALVENTA = 0 : TOTALEXENTA = 0
                        'RucCliente = 0 : DVCliente = 0

                        ClienteNombre = "FACTURA ANULADA"

                        txtCadena = "2" & vbTab & RucCliente & vbTab & DVCliente & vbTab & ClienteNombre & vbTab & TipoFactura & vbTab & NUMVENTA & vbTab & _
                            ventaFecha & vbTab & Iva10 & vbTab & TOTAL10 & vbTab & Iva5 & vbTab & TOTAL5 & vbTab & TOTALEXENTA & vbTab & TOTALVENTA & vbTab & _
                            modalidadpago & vbTab & Cuotas & vbTab & timbrado

                        sw.WriteLine(txtCadena)
                        txtCadena = ""
                        'sinnombre = 1

                    ElseIf (Estado = 1) Then

                        TOTAL5 = FormatNumber(TOTAL5, 0)
                        TOTAL5 = Funciones.Cadenas.QuitarCad(TOTAL5, ".")
                        TOTAL10 = FormatNumber(TOTAL10, 0)
                        TOTAL10 = Funciones.Cadenas.QuitarCad(TOTAL10, ".")
                        Iva10 = FormatNumber(Iva10, 0)
                        Iva10 = Funciones.Cadenas.QuitarCad(Iva10, ".")
                        Iva5 = FormatNumber(Iva5, 0)
                        Iva5 = Funciones.Cadenas.QuitarCad(Iva5, ".")
                        TOTALVENTA = FormatNumber(TOTALVENTA, 0)
                        TOTALVENTA = Funciones.Cadenas.QuitarCad(TOTALVENTA, ".")
                        TOTALEXENTA = FormatNumber(TOTALEXENTA, 0)
                        TOTALEXENTA = Funciones.Cadenas.QuitarCad(TOTALEXENTA, ".")

                        txtCadena = "2" & vbTab & RucCliente & vbTab & DVCliente & vbTab & ClienteNombre & vbTab & TipoFactura & vbTab & NUMVENTA & vbTab & _
                            ventaFecha & vbTab & Iva10 & vbTab & TOTAL10 & vbTab & Iva5 & vbTab & TOTAL5 & vbTab & TOTALEXENTA & vbTab & TOTALVENTA & vbTab & _
                            modalidadpago & vbTab & Cuotas & vbTab & timbrado

                        sw.WriteLine(txtCadena)
                        txtCadena = ""
                    End If

                Next
                'sinnombre = 1
                txtCadena = ""
            Next 'DETALLE

            sw.Close()
            sw.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'sw.Close()
            'sw.Dispose()
        End Try
    End Sub

    Sub Hechauka_notadecredito(listarAnuladas As Boolean, cbxComprobante As String, cbxMes As String, cbxDesde As String,
                        Localizacion As String, cbxHasta As String, cbxAño As String, ruta As String, TipoReporte As Integer)

        Dim sqlwhere As String = ""
        Dim TotVenta As Decimal = 0
        Dim cantreg As Integer = 0
        Dim cantfile As Integer = 0
        Dim recordet As Integer = 0
        Dim contribuyente As String = ""
        Dim Representante As String = ""
        Dim RucContribuyente As String = ""
        Dim rucrepresentante As String = ""
        Dim dvrepresentante As String = ""
        Dim dvcontribuyente As String = ""
        Dim sinnombre As Integer = 0
        Dim numberfile As Integer = 0
        Dim NroDocumento As String = ""
        Dim RucCliente As String
        Dim timbrado As String
        Dim rutaExtra As String = Localizacion & "\" & cbxMes & cbxAño & "- NotadeCreditoHechauka.txt"

        'NOTAS DE CREDITO
        Try
            sqlwhere = ""
            Dim TotalDevolucion As Decimal = 0

            If listarAnuladas = True Then
                sqlwhere = " AND (dbo.DEVOLUCIONCOMPRA.ESTADO <> 0)"
            Else
                sqlwhere = " AND (dbo.DEVOLUCIONCOMPRA.ESTADO = 1)"
            End If

            If cbxComprobante <> "%" Then
                sqlwhere = sqlwhere + " AND TIPOCOMPROBANTE.IDCOMPROBANTE IN (" & cbxComprobante & ")"
            End If

            Dim Fechadesde As String = cbxDesde + "/" + cbxMes + "/" + cbxAño + " 00:00:00.000"
            Dim fechahasta As String = cbxHasta + "/" + cbxMes + "/" + cbxAño + " 23:59:59.999"

            'CANTIDAD Y MONTO PARA CABECERA

            Dim NCCabCant As New DataTable

            SQLCmd.CommandText = "SELECT COUNT(dbo.DEVOLUCIONCOMPRA.CODCOMPRA) AS CODCOMPRA FROM DEVOLUCIONCOMPRA " & _
                                 " WHERE (dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION >= CONVERT(DATETIME, '" & Fechadesde & "', 103)) " & _
                                 " AND (dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION <= CONVERT(DATETIME, '" & fechahasta & "', 103)) " & _
                                 " " & sqlwhere

            SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
            SQLCmd.Connection.Open()

            NCCabCant.Load(SQLCmd.ExecuteReader)
            SQLCmd.Dispose()
            SQLCmd.Connection.Close()

            For i As Integer = 0 To NCCabCant.Rows.Count - 1
                cantreg = cantreg + NCCabCant.Rows(i).Item("CODCOMPRA")
            Next

            Dim NCCabTotal As New DataTable

            SQLCmd.CommandText = ""
            SQLCmd.CommandText = "SELECT SUM(dbo.DEVOLUCIONCOMPRA.TOTALDEVOLUCION) AS TOTAL FROM DEVOLUCIONCOMPRA " & _
                                 " WHERE (dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION >= CONVERT(DATETIME, '" & Fechadesde & "', 103)) " & _
                                 " AND (dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION <= CONVERT(DATETIME, '" & fechahasta & "', 103)) " & _
                                 " " & sqlwhere

            SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
            SQLCmd.Connection.Open()

            NCCabTotal.Load(SQLCmd.ExecuteReader)
            SQLCmd.Dispose()
            SQLCmd.Connection.Close()

            For i As Integer = 0 To NCCabTotal.Rows.Count - 1

                If IsDBNull(NCCabTotal.Rows(i).Item("TOTAL")) Then
                    MessageBox.Show("No existen registros para Notas de Credito en este periodo", "R.I.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    TotVenta = FormatNumber(NCCabTotal.Rows(i).Item("TOTAL"), 0)
                    TotVenta = Funciones.Cadenas.QuitarCad(TotVenta, ".")
                End If

            Next

            SQLCmd.Dispose()
            'FIN CANTIDAD Y MONTO PARA CABECERA

            'INICIO CABECERA

            Dim NCCabecera As New DataTable

            SQLCmd.CommandText = " SELECT DATEPART(yyyy, dbo.periodofiscal.FECHAINICIO) AS Anho, DATEPART(month, GETDATE()) AS Mes, dbo.EMPRESA.RUCCONTRIBUYENTE, " & _
                                 " dbo.EMPRESA.NOMCONTRIBUYENTE, dbo.EMPRESA.NOMREPRESENTANTE, dbo.EMPRESA.RUCREPRESENTANTE " & _
                                 " FROM dbo.periodofiscal CROSS JOIN dbo.EMPRESA " & _
                                 " WHERE (dbo.periodofiscal.ESTADO = 1) "

            SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
            SQLCmd.Connection.Open()

            NCCabecera.Load(SQLCmd.ExecuteReader)
            SQLCmd.Dispose()
            SQLCmd.Connection.Close()

            For i As Integer = 0 To NCCabecera.Rows.Count - 1

                contribuyente = NCCabecera.Rows(i).Item("NOMCONTRIBUYENTE").ToString
                Representante = NCCabecera.Rows(i).Item("NOMREPRESENTANTE").ToString

                If NCCabecera.Rows(i).Item("RUCCONTRIBUYENTE").ToString <> "" Then
                    PosGuion = InStr(NCCabecera.Rows(i).Item("RUCCONTRIBUYENTE").ToString, "-")
                    RucContribuyente = NCCabecera.Rows(i).Item("RUCCONTRIBUYENTE").ToString
                    If PosGuion <> 0 Then
                        RucContribuyente = Trim(RucContribuyente.Substring(0, PosGuion - 1))
                    End If
                    dvcontribuyente = DVcalculo(RucContribuyente, 11)
                Else
                    RucContribuyente = ""
                    dvcontribuyente = ""
                End If

                If NCCabecera.Rows(i).Item("RUCREPRESENTANTE").ToString <> "" Then
                    PosGuion = InStr(NCCabecera.Rows(i).Item("RUCREPRESENTANTE").ToString, "-")
                    rucrepresentante = NCCabecera.Rows(i).Item("RUCREPRESENTANTE").ToString
                    If PosGuion <> 0 Then
                        rucrepresentante = rucrepresentante.Substring(0, PosGuion - 1)
                    End If
                    dvrepresentante = DVcalculo(rucrepresentante, 11)
                Else
                    rucrepresentante = ""
                    dvrepresentante = ""
                End If
            Next

            'FIN CABECERA

            rutaExtra = Localizacion & "\" & cbxMes & cbxAño & "- NotadeCreditoHechaukaCompra.txt"

            If File.Exists(rutaExtra) = True Then
                If MessageBox.Show("Archivo " & cbxMes & cbxAño & "- NotadeCreditoHechaukaCompra (" & numberfile & ").txt, ya existe, desea sobreescribirlo", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    Try
                        File.Delete(rutaExtra)
                    Catch ex As Exception

                    Finally
                        sw = File.CreateText(rutaExtra)
                    End Try

                Else
                    'si usuario no quiere sobreescribir, no se hace nada...
                    Exit Sub
                End If
            Else
                sw = File.CreateText(rutaExtra)
            End If

            txtCadena = "1" & vbTab & cbxAño + cbxMes & vbTab & TipoReporte & vbTab & "921" & vbTab & "221" & vbTab & RucContribuyente & vbTab & dvcontribuyente & vbTab & _
                contribuyente & vbTab & rucrepresentante & vbTab & dvrepresentante & vbTab & Representante & vbTab & cantreg & vbTab & TotVenta

            sw.WriteLine(txtCadena)

            'INICIO DETALLE
            Dim NCDetalle As New DataTable

            SQLCmd.CommandText = ""
            SQLCmd.CommandText = "SELECT dbo.DEVOLUCIONCOMPRA.CODDEVOLUCION, dbo.DEVOLUCIONCOMPRA.NUMDEVOLUCION, dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION, " & _
                                 "dbo.DEVOLUCIONCOMPRA.TOTALEXENTA, dbo.DEVOLUCIONCOMPRA.TOTALIVA, dbo.DEVOLUCIONCOMPRA.CODPROVEEDOR, dbo.DEVOLUCIONCOMPRA.ESTADO, dbo.DEVOLUCIONCOMPRA.TOTALIVA5, " & _
                                 "dbo.DEVOLUCIONCOMPRA.TOTALIVA10, dbo.PROVEEDOR.NUMPROVEEDOR, dbo.PROVEEDOR.NOMBRE, dbo.TIPOCOMPROBANTE.CODCOMPROBANTE, dbo.TIPOCOMPROBANTE.IDCOMPROBANTE, " & _
                                 "dbo.TIPOCOMPROBANTE.DESCOMPROBANTE, dbo.PROVEEDOR.RUC_CIN AS RUC, dbo.DEVOLUCIONCOMPRA.TOTALIVA10 * 11 - dbo.DEVOLUCIONCOMPRA.TOTALIVA10 AS TOTALGRAVADO10, " & _
                                 "dbo.DEVOLUCIONCOMPRA.TOTALIVA5 * 21 - dbo.DEVOLUCIONCOMPRA.TOTALIVA5 AS TOTALGRAVADO5, dbo.DEVOLUCIONCOMPRA.TOTALDEVOLUCION, dbo.DEVOLUCIONCOMPRA.timbradoprov " & _
                                 "FROM  dbo.DEVOLUCIONCOMPRA INNER JOIN  dbo.PROVEEDOR ON dbo.DEVOLUCIONCOMPRA.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR INNER JOIN " & _
                                 "dbo.TIPOCOMPROBANTE ON dbo.DEVOLUCIONCOMPRA.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                 "WHERE (dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION >= CONVERT(DATETIME,'" & Fechadesde & "', 103)) AND (dbo.DEVOLUCIONCOMPRA.FECHADEVOLUCION <= CONVERT(DATETIME, '" & fechahasta & "', 103)) and DEVOLUCIONCOMPRA.Estado=1 " & _
                                 sqlwhere

            SQLCmd.Connection = New SqlConnection(ser.CadenaConexion)
            SQLCmd.Connection.Open()

            NCDetalle.Load(SQLCmd.ExecuteReader)
            SQLCmd.Dispose()
            SQLCmd.Connection.Close()

            For i As Integer = 0 To NCDetalle.Rows.Count - 1

                If NCDetalle.Rows(i).Item("RUC").ToString <> "" Then
                    PosGuion = InStr(NCDetalle.Rows(i).Item("RUC"), "-")
                    RucCliente = NCDetalle.Rows(i).Item("RUC").ToString

                    If PosGuion <> 0 Then
                        RucCliente = RucCliente.Substring(0, PosGuion - 1)
                    End If
                    DVCliente = DVcalculo(RucCliente, 11)
                Else
                    RucCliente = ""
                    DVCliente = ""
                End If

                Try
                    TipoFactura = NCDetalle.Rows(i).Item("IDCOMPROBANTE")
                Catch ex As Exception
                    TipoFactura = 3
                End Try

                EstadoVenta = NCDetalle.Rows(i).Item("ESTADO")
                Dim fecha2 As DateTime
                fecha2 = NCDetalle.Rows(i).Item("FECHADEVOLUCION").ToString
                Dim fecha As DateTime = fecha2.ToString("dd/MM/yyy")

                NroDocumento = NCDetalle.Rows(i).Item("NUMDEVOLUCION").ToString
                NroDocumento = NroDocumento.Replace(".", "-")

                TotalDevolucion = Math.Round(NCDetalle.Rows(i).Item("TOTALDEVOLUCION"), 0)

                If NCDetalle.Rows(i).Item("timbradoprov").ToString Is DBNull.Value Then
                    timbrado = 0
                Else
                    timbrado = NCDetalle.Rows(i).Item("timbradoprov").ToString
                End If

                If (EstadoVenta = 2) And (listarAnuladas = True) Then
                    Total5 = 0 : Total10 = 0 : Iva10 = 0 : Iva5 = 0 : TotalExenta = 0
                    RucCliente = 0 : DVCliente = 0

                    ClienteNombre = "NOTA DE CREDITO COMPRA ANULADA"

                    Cadena = "2" & vbTab & RucCliente & vbTab & DVCliente & vbTab & ClienteNombre & vbTab & 3 & vbTab & NroDocumento & vbTab & _
                         fecha & vbTab & Iva10 & vbTab & Total10 & vbTab & Iva5 & vbTab & Total5 & vbTab & TotalExenta & vbTab & TotalDevolucion & vbTab & _
                         "1" & vbTab & "0" & vbTab & timbrado
                    sw.WriteLine(Cadena)

                ElseIf (EstadoVenta = 1) Then
                    Try
                        Total5 = Math.Round(NCDetalle.Rows(i).Item("TOTALIVA5"), 0)
                    Catch ex As Exception
                        Total5 = 0
                    End Try
                    Try
                        Total10 = Math.Round(NCDetalle.Rows(i).Item("TOTALIVA10"), 0)
                    Catch ex As Exception
                        Total10 = 0
                    End Try
                    Try
                        Iva10 = Math.Round(NCDetalle.Rows(i).Item("TOTALGRAVADO10"), 0)
                    Catch ex As Exception
                        Iva10 = 0
                    End Try
                    Try
                        Iva5 = Math.Round(NCDetalle.Rows(i).Item("TOTALGRAVADO5"), 0)
                    Catch ex As Exception
                        Iva5 = 0
                    End Try

                    TotalExenta = Math.Round(NCDetalle.Rows(i).Item("TOTALEXENTA"), 0)
                    ClienteNombre = NCDetalle.Rows(i).Item("NOMBRE").ToString



                    Cadena = "2" & vbTab & RucCliente & vbTab & DVCliente & vbTab & ClienteNombre & vbTab & 3 & vbTab & NroDocumento & vbTab & _
                         fecha & vbTab & Iva10 & vbTab & Total10 & vbTab & Iva5 & vbTab & Total5 & vbTab & TotalExenta & vbTab & TotalDevolucion & vbTab & _
                         "1" & vbTab & "0" & vbTab & timbrado
                    sw.WriteLine(Cadena)
                End If
            Next

            sw.Close()
            sw.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'sw.Close()
            'sw.Dispose()
        End Try

    End Sub
End Class
