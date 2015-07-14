Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports EnviaInformes
Imports Osuna.Utiles.Conectividad
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Imports Osuna.Utiles.Configuracion
Imports System.Reflection.BindingFlags
Imports System
Imports System.Xml

Public Class VentasPlus
    Implements IDisposable

#Region "Fields"
    Private row As DataRow

    Dim dtRemisiones As New DataTable

    Dim NroRango As Integer
    Dim ImprControl As Integer
    Dim TipoImpresion As Integer
    Dim apretoteclaabajoencombo, PROMO As Boolean
    Dim anho, RUC As String
    Dim Cantlinea, imprimirfact, imprimeticket, imprimeautofact, hastanro, ultimo, Imprimir, NroManual, ValorFiscal, CodRangoGral As Integer
    Dim Clientes As Integer
    Dim CodCliente, CodVenta As Integer
    Dim var As Integer
    Dim PermisoFact, VenderMasQueStock As Integer
    Dim Descuento, TotalCalc As Double
    Dim permiso As Double
    Dim EstadoExiste, btAprobado, btAnulado, btcfcuota, btcambiotipoventa, FIFOCOSTO As Integer
    Dim btduplicar As Integer = 0
    Dim btquemarblanco As Integer = 0
    Dim nuevocodventa As String = ""
    Dim tieneerror As Boolean = False
    Dim mensajeerror, fechavalidez As String
    Dim banchangecmbventa As Integer = 0
    Dim btcancelando As Integer
    Dim errorFiltroFecha As Integer = 0
    Dim errorFiltroRango As Integer = 0
    Dim AccionPermiso, diasvtocli, cantcuotascli, periodocobro As String
    Dim tipocomp2, cantdecimales As Integer
    Dim dtmoneda As DataTable

    '#############################################################
    'Variable para guardar el ingreso en cajaingreso#######################################
    Dim codingreso As String

    '######################################################################
    'Variable para saber el tipo de cliente; puede ser vip,pete,capiata, exclusivo,caigue
    Dim codtipocliente As Integer

    'PARA GUARDAR CABECERA VENTA
    Dim CodMonedaV, MotivoDescV, CodClienteV, CodComprobanteV, CodSucV, CodDepV, FechaV, _
        NumVentaV, Cotizacion1V, TipoVtaV, NombreV, RucV, ModalidadV, DirecV, _
        CodVendedorV, TotalIva10V, TotalIva5V, CodZonaV, CodEventoV, MetodoV, NumTimbradoV, _
        CodRangoV, EstadoV, TotalExentaV, TotalGravadaV, TotalVentaV, TotalGravado10V, TotalGravado5V, TotalIvaV As String

    Dim Departamento, Ciudad, Zona, Observaciones As String

    '#####################################################################################
    'Variable para el vendedor############################################################
    Dim CodVendedor As String
    Dim del As Integer
    Private direccion As String

    '#################### Para los permisos de usuarios ####################################################################
    Dim Existe As Integer
    Dim f As New Funciones.Funciones
    Dim cadena As New Funciones.Cadenas
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim PrecioVentaG As String

    'Para las Cuotas###########################################################
    Dim Frecuencia As Integer
    Dim cantidadcuotas As Integer

    '#############################################################
    'IMPRESORA
    Dim impresora As String
    Dim LineaVenta As Integer
    Dim Total10, Total5 As String
    Dim ins As Integer

    '#################### Para el filtro de fechas ##############################
    Dim Mes As String
    Dim pri As Integer

    'BANDERAS DE ESTADO DE LOS TABS
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Private sistema As New Funciones.Sistema

    Dim TimbradoFactura As String
    Private WithEvents Trabajador As New System.ComponentModel.BackgroundWorker 'Variable para optimizar la carga del formulario
    Dim upd As Integer
    '  Dim Venta As Integer

    'Variables de Funcion
    Dim w As New Funciones.Funciones
    Dim btNuevo, btModificar, GrillaModif As Integer
    Dim VCodVenta As Integer
    Dim servicio As Integer
    Dim Config1, Config2, Config3, Config4, Config5, Config6, Config7, Config8, Config9, Config10, Config11, Config12, Config13, ConfigDecVS As String
    Dim ModificarFactura, PanelCliente, OKSupervisor As Integer
    Dim PosicionDato As Integer 'esto se usa a la hora de editar/modificar los datos en la grilla
    Dim LocalizacionFile As String
    Dim OrdCompraSEPSA As String

    Private WithEvents docToTicket As New Printing.PrintDocument
#End Region 'Fields

#Region "Constructors"

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion()

    End Sub

#End Region 'Constructors

#Region "Methods"

    Dim cantidadstockcbo As Decimal 'para validar la cantidad en combo
    Dim eligiocbo As Integer = 0 ' para saber si eligio un combo
    'Para controlar cuando un producto sea pesable
    Dim ProdPE As Integer = 0
    Dim NumVentaContabilidad As String = ""
    Private sqlc As New SqlConnection
    Private myTrans As SqlTransaction
    Private cmd As New SqlCommand
    Dim NoRegistrarCobro As Integer = 0
    Dim consultaInsert As String
    Private sql As String
    Dim MensajesError As String = ""
    Dim NroError As Integer = 0

    Public Overloads Sub Dispose() 'Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Function InfPresupuesto() As DataSet
        Dim ds As New DsInformes
        ds.Clear()
        Dim diez, cinco, exento, totalcinco, totaldiez, totalexento, total, TotalItems5, TotalItems10, TotalItemsExento As Decimal

        diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0 : TotalItems5 = 0
        TotalItems10 = 0 : TotalItemsExento = 0

        Try
            Dim CantImpresion As Integer
            Dim nrofactura As String
            nrofactura = NroFacturaLabel.Text
            Dim k As Integer = 1
            Dim c As Integer = DetalleVentaGridView.RowCount()

            Dim rango As String = w.FuncionConsultaString2("DETPC.RANDOID", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "TIPOCOMPROBANTE.PRESUPUESTO", 1)
            Dim tipocomp2 As Integer = f.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", rango)
            CantImpresion = f.FuncionConsultaDecimal("CANTIDADIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", tipocomp2)
            Cantlinea = w.FuncionConsulta("dbo.TIPOCOMPROBANTE.NROLINEASDETALLE", "dbo.TIPOCOMPROBANTE INNER JOIN dbo.DETPC ON dbo.TIPOCOMPROBANTE.CODCOMPROBANTE = dbo.DETPC.CODCOMPROBANTE", "dbo.DETPC.RANDOID", rango)

            Dim dadatoscli As New SqlDataAdapter("SELECT dbo.CLIENTES.DIRECCION, dbo.CLIENTES.TELEFONO, dbo.ZONA.DESZONA, dbo.CLIENTES.CUSTOMFIELD, dbo.VENTAS.FECHAVENTA, dbo.CLIENTES.NOMBREFANTASIA, dbo.CLIENTES.NOMBRE, dbo.VENTAS.MOTIVODESCUENTO, dbo.FACTURACOBRAR.FECHAVCTO, SUBSTRING(dbo.VENTAS.NUMVENTA, " & _
                         "LEN(dbo.VENTAS.NUMVENTA) - 5, 6) AS NUMVENTA1 " & _
            "FROM            dbo.CLIENTES LEFT OUTER JOIN " & _
                         "dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA INNER JOIN " & _
                         "dbo.VENTAS ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.FACTURACOBRAR ON dbo.VENTAS.CODVENTA = dbo.FACTURACOBRAR.CODVENTA " & _
            "WHERE        dbo.VENTAS.CODVENTA =" & VCodVenta & "", ser.CadenaConexion)

            Dim dtdatoscli As New DataTable
            dadatoscli.Fill(dtdatoscli)
            Dim drdatoscli As DataRow
            drdatoscli = dtdatoscli.Rows(0)

            Dim dadatosEmpresa As New SqlDataAdapter("SELECT RUCCONTRIBUYENTE, DIRECCION, TELEFONO, DESEMPRESA, LOCALIDAD " & _
            "FROM dbo.EMPRESA " & _
            "WHERE CODEMPRESA =" & EmpCodigo & "", ser.CadenaConexion)

            Dim dtdatosEmpresa As New DataTable
            dadatosEmpresa.Fill(dtdatosEmpresa)
            Dim drdatosEmpresa As DataRow
            drdatosEmpresa = dtdatosEmpresa.Rows(0)

            If CantImpresion = 0 Then
                CantImpresion = 1
            End If

            For k = 1 To CantImpresion
                For i = 1 To Cantlinea
                    row = ds.Tables("Detalle").NewRow()
                    row.Item("Campo3") = k

                    '########### campos string ##########################################################
                    If i > c Then
                        row.Item("Campo1") = ""
                    Else
                        row.Item("Campo1") = DetalleVentaGridView.Rows(i - 1).Cells("ProductoGrilla").Value
                    End If

                    If i > c Then
                        row.Item("Campo13") = ""
                    Else
                        row.Item("Campo13") = DetalleVentaGridView.Rows(i - 1).Cells("CodigoGrilla").Value
                    End If

                    If i = 1 Then
                        row.Item("Campo6") = RUCClienteTextBox.Text
                        row.Item("Campo4") = drdatoscli("NOMBRE")
                        row.Item("Campo7") = VendendorComboBox.Text
                        row.Item("Campo8") = drdatoscli("DIRECCION")
                        row.Item("Fecha1") = dtpFechaHora.Text
                        row.Item("Campo9") = NroFacturaLabel.Text


                        row.Item("Campo17") = drdatosEmpresa("DESEMPRESA")
                        row.Item("Campo18") = drdatosEmpresa("DIRECCION")
                        row.Item("Campo19") = drdatosEmpresa("LOCALIDAD")
                        row.Item("Campo20") = drdatosEmpresa("TELEFONO")
                        row.Item("Campo21") = drdatosEmpresa("RUCCONTRIBUYENTE")

                    End If
                    '#####################################################################################

                    '########### campos numericos ##########################################################

                    If i > c Then
                        ' row.Item("NUMERO1") = Nothing
                    Else
                        row.Item("NUMERO1") = DetalleVentaGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                    End If

                    If i > c Then
                        ' row.Item("NUMERO2") = Nothing
                    Else
                        row.Item("NUMERO2") = DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                    End If

                    Dim IVA As Decimal
                    If i > c Then

                    Else
                        IVA = DetalleVentaGridView.Rows(i - 1).Cells("IVADataGridViewTextBoxColumn").Value

                        If IVA = 10 Then
                            row.Item("NUMERO5") = DetalleVentaGridView.Rows(i - 1).Cells("SUBTOTAL").Value
                            diez = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("SUBTOTAL").Value / 11, 2)
                            totaldiez = totaldiez + diez
                            total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                            TotalItems10 = TotalItems10 + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                        ElseIf IVA = 0 Then
                            row.Item("NUMERO3") = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                            exento = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                            totalexento = totalexento + exento
                            total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                            TotalItemsExento = TotalItemsExento + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                        ElseIf IVA = 5 Then
                            row.Item("NUMERO4") = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                            cinco = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value / 21, 2)
                            totalcinco = totalcinco + cinco
                            total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                            TotalItems5 = TotalItems5 + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                        End If
                    End If

                    '#####################################################################################

                    row.Item("NUMERO6") = totalcinco
                    row.Item("NUMERO7") = totaldiez
                    row.Item("NUMERO8") = totaldiez + totalcinco
                    row.Item("NUMERO9") = total

                    row.Item("NUMERO11") = TotalItems5
                    row.Item("NUMERO12") = TotalItems10
                    row.Item("NUMERO10") = TotalItemsExento
                    'row.Item("Campo14") = "OBSERVACIONES: " + drdatoscli("MOTIVODESCUENTO")
                    row.Item("Campo2") = Funciones.Cadenas.NumeroaLetras(total)

                    ds.Tables("Detalle").Rows.Add(row)
                Next

                diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0
                TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0
            Next

        Catch ex As Exception
            MessageBox.Show("Error al Generar el Presupuesto", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ds
    End Function

    Public Function InfPresupuestoPreVenta() As DataSet
        Dim ds As New DsInformes
        Dim row As DataRow
        ds.Clear()

        Try
            Dim nrofactura As String = NroFacturaLabel.Text
            Dim dadatosEmpresa As New SqlDataAdapter("SELECT RUCCONTRIBUYENTE, DIRECCION, TELEFONO, DESEMPRESA, LOCALIDAD " & _
                                                     "FROM dbo.EMPRESA WHERE CODEMPRESA =" & EmpCodigo & "", ser.CadenaConexion)

            Dim dtdatosEmpresa As New DataTable
            dadatosEmpresa.Fill(dtdatosEmpresa)
            Dim drdatosEmpresa As DataRow
            drdatosEmpresa = dtdatosEmpresa.Rows(0)

            row = ds.Tables("Detalle").NewRow()

            row.Item("Campo1") = drdatosEmpresa("DESEMPRESA")
            row.Item("Campo2") = drdatosEmpresa("DIRECCION")
            row.Item("Campo3") = drdatosEmpresa("TELEFONO")

            row.Item("Campo4") = "Nro Pre-Venta: " & Me.NroFacturaLabel.Text
            row.Item("Campo5") = "Cliente Nro: " & Me.TxtNumCliente.Text
            row.Item("Campo6") = "Cliente: " & Me.CmbCliente.Text
            row.Item("Campo7") = "Fecha/Hora:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()

            row.Item("Campo8") = "*** Documento de Uso Interno ***"

            ds.Tables("Detalle").Rows.Add(row)

        Catch ex As Exception
            MessageBox.Show("Error")
        End Try

        Return ds
    End Function

    Public Function InfFactura() As DataSet
        Dim ds As New DsInformes
        ds.Clear()
        Dim diez, cinco, exento, totalcinco, totaldiez, totalexento, total, TotalItems5, TotalItems10, TotalItemsExento, TotalDescuento As Decimal

        diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0 : TotalItems5 = 0 : TotalDescuento = 0
        TotalItems10 = 0 : TotalItemsExento = 0

        Try
            Dim CantImpresion As Integer
            Dim nrofactura As String = NroFacturaLabel.Text
            Dim k As Integer = 1
            Dim c As Integer = DetalleVentaGridView.RowCount()

            Dim tipocomp2 As Integer = f.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)
            CantImpresion = f.FuncionConsultaDecimal("CANTIDADIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", tipocomp2)
            Dim CanDigitosFact As Integer = f.FuncionConsultaDecimal("NRODIGITOS", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)

            Dim dadatoscli As New SqlDataAdapter("SELECT dbo.CLIENTES.DIRECCION, dbo.CLIENTES.TELEFONO, dbo.ZONA.DESZONA, dbo.CLIENTES.CUSTOMFIELD, DATEDIFF(d, dbo.VENTAS.FECHAVENTA, dbo.FACTURACOBRAR.FECHAVCTO) AS DIAS,  " & _
                                                 "dbo.VENTAS.FECHAVENTA, dbo.CLIENTES.NOMBREFANTASIA, dbo.VENTAS.NOMBRECLIENTE AS NOMBRE, dbo.VENTAS.MOTIVODESCUENTO, dbo.FACTURACOBRAR.FECHAVCTO,  " & _
                                                 "SUBSTRING(dbo.VENTAS.NUMVENTA, 9, LEN(dbo.VENTAS.NUMVENTA) - 8) AS NUMVENTA1, dbo.CIUDAD.DESCIUDAD, dbo.CLIENTES.CODCLIENTE, dbo.MONEDA.SIMBOLO, dbo.VENTAS.COTIZACION1  " & _
                                                 "FROM dbo.CLIENTES LEFT OUTER JOIN dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA INNER JOIN dbo.VENTAS ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE LEFT OUTER JOIN " & _
                                                 "dbo.MONEDA ON dbo.VENTAS.CODMONEDA = dbo.MONEDA.CODMONEDA LEFT OUTER JOIN dbo.CIUDAD ON dbo.CLIENTES.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN  " & _
                                                 "dbo.FACTURACOBRAR ON dbo.VENTAS.CODVENTA = dbo.FACTURACOBRAR.CODVENTA  WHERE dbo.VENTAS.CODVENTA =" & VCodVenta & "", ser.CadenaConexion)

            Dim dtdatoscli As New DataTable
            dadatoscli.Fill(dtdatoscli)
            Dim drdatoscli As DataRow
            drdatoscli = dtdatoscli.Rows(0)

            If CantImpresion = 0 Then
                CantImpresion = 1
            End If

            For k = 1 To CantImpresion
                For i = 1 To Cantlinea
                    row = ds.Tables("Detalle").NewRow()
                    row.Item("Campo3") = k

                    '########### campos string ##########################################################
                    If i > c Then
                        row.Item("Campo1") = ""
                    Else
                        row.Item("Campo1") = DetalleVentaGridView.Rows(i - 1).Cells("ProductoGrilla").Value
                    End If

                    If i > c Then
                        row.Item("Campo13") = ""
                    Else
                        row.Item("Campo13") = DetalleVentaGridView.Rows(i - 1).Cells("CodigoGrilla").Value
                    End If

                    If i = 1 Then
                        row.Item("Campo6") = RUCClienteTextBox.Text
                        row.Item("Campo4") = drdatoscli("NOMBRE")
                        row.Item("Campo7") = VendendorComboBox.Text
                        row.Item("Campo8") = drdatoscli("DIRECCION")
                        row.Item("Fecha1") = dtpFechaHora.Text
                        row.Item("Campo9") = nrofactura.Substring(8, CanDigitosFact) 'drdatoscli("NUMVENTA1")
                        row.Item("Campo5") = drdatoscli("NOMBREFANTASIA")
                        row.Item("Campo23") = tbxFactNroRemision.Text
                        row.Item("Campo24") = txtObservacion.Text

                        'Nuevo para Dicopar
                        row.Item("Fecha2") = dtpFechaHora.Text
                        row.Item("Fecha3") = dtpFechaHora.Text

                        If TxtNumCliente.Text <> "" Then
                            row.Item("Numero13") = TxtNumCliente.Text
                        End If

                        row.Item("Campo10") = drdatoscli("DESZONA")
                        row.Item("Campo11") = drdatoscli("TELEFONO")
                        row.Item("Campo12") = w.FuncionConsultaString("NUMVENDEDOR", "VENDEDOR", "CODVENDEDOR", VendendorComboBox.SelectedValue) 'Para Dilip
                        row.Item("Campo15") = drdatoscli("CUSTOMFIELD") 'NRO PROVEEDOR - Guazu
                    End If
                    '#####################################################################################

                    '########### campos numericos ##########################################################

                    If i > c Then
                        ' row.Item("NUMERO1") = Nothing
                    Else
                        row.Item("NUMERO1") = DetalleVentaGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value

                    End If

                    If i > c Then
                        ' row.Item("NUMERO2") = Nothing
                    Else
                        row.Item("NUMERO2") = DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                    End If

                    Dim IVA As Decimal
                    If i > c Then

                    Else
                        IVA = DetalleVentaGridView.Rows(i - 1).Cells("IVADataGridViewTextBoxColumn").Value

                        If Not IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("DESCDataGridViewTextBoxColumn").Value) Then
                            TotalDescuento = TotalDescuento + DetalleVentaGridView.Rows(i - 1).Cells("DESCDataGridViewTextBoxColumn").Value * DetalleVentaGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                        End If

                        If IVA = 10 Then
                            row.Item("NUMERO5") = DetalleVentaGridView.Rows(i - 1).Cells("SUBTOTAL").Value
                            diez = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("SUBTOTAL").Value / 11, 2)
                            totaldiez = totaldiez + diez
                            total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                            TotalItems10 = TotalItems10 + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                        ElseIf IVA = 0 Then
                            row.Item("NUMERO3") = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                            exento = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                            totalexento = totalexento + exento
                            total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                            TotalItemsExento = TotalItemsExento + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                        ElseIf IVA = 5 Then
                            row.Item("NUMERO4") = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                            cinco = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value / 21, 2)
                            totalcinco = totalcinco + cinco
                            total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                            TotalItems5 = TotalItems5 + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                        End If
                    End If

                    '#####################################################################################

                    row.Item("NUMERO6") = totalcinco
                    row.Item("NUMERO7") = totaldiez
                    row.Item("NUMERO8") = totaldiez + totalcinco
                    row.Item("NUMERO9") = total

                    row.Item("NUMERO11") = TotalItems5
                    row.Item("NUMERO12") = TotalItems10
                    row.Item("NUMERO10") = TotalItemsExento

                    If TotalDescuento > 0 Then
                        Dim Desc As String
                        Desc = FormatNumber(TotalDescuento, 0, TriState.True, TriState.False, TriState.True)
                        row.Item("Campo26") = "TOTAL DESCUENTO: " & Desc & " Gs."
                    End If

                    'Guazu - MIENTRAS, PARA NO TOCAR LA FACTURA
                    row.Item("Campo14") = "" + drdatoscli("MOTIVODESCUENTO")

                    'Dicopar
                    row.Item("Campo17") = drdatoscli("MOTIVODESCUENTO")
                    row.Item("Campo2") = Funciones.Cadenas.NumeroaLetras(total)
                    row.Item("Campo20") = drdatoscli("DESCIUDAD") 'Para Dilip


                    If CmbTipoVenta.Text = "Crédito" Then
                        row.Item("Campo21") = ""
                        row.Item("Campo22") = "X"
                        row.Item("Campo16") = "C/ " & TxtPeriodo.Text 'PARA OTROS 
                        row.Item("Campo25") = "CREDITO"
                        row.Item("Campo26") = GridViewCuotas.RowCount

                    Else ' Contado u Otros (Por bonificacion,etc)
                        row.Item("Campo21") = "X"
                        row.Item("Campo22") = ""
                        row.Item("Campo16") = ""
                        row.Item("Campo25") = "CONTADO"
                    End If

                    row.Item("Campo27") = drdatoscli("SIMBOLO") 'Para Cultural
                    row.Item("NUMERO14") = drdatoscli("COTIZACION1") 'Para Cultural



                    ds.Tables("Detalle").Rows.Add(row)
                Next

                diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0
                TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0
            Next

        Catch ex As Exception
            MessageBox.Show("Error, un campo no se cargó correctamente para poder imprimir")
        End Try

        ds.Dispose()
        Return ds
    End Function

    Private Sub GuardaDetalleVenta()
        Dim CodSucursal, CodMonedaVenta, LineaNro, PrecioVentaNeto, CostoFifo, PrecioVentaBruto, PrecioVentaLista, CantidadVenta, Iva, CodProductoVenta, CodCodigoVenta, Desc, _
        SumaIva, codenviodetalle, importe10, importe5, importeexento, IvaVenta, LineaNroDetalle As String
        Dim PromoDet As Integer
        Dim codSerie As String = ""
        Dim c As Integer = DetalleVentaGridView.RowCount

        importeexento = "" : SumaIva = "0" : importe5 = "" : importe10 = "" : consultaInsert = "" : IvaVenta = 0 : LineaNroDetalle = ""

        For i = 1 To c
            LineaNro = DetalleVentaGridView.Rows(i - 1).Cells("VentaDetalleID").Value

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("Serie").Value) Then
                codSerie = 0
            Else
                codSerie = DetalleVentaGridView.Rows(i - 1).Cells("Serie").Value
            End If

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                CodProductoVenta = "NULL"
            Else
                CodProductoVenta = DetalleVentaGridView.Rows(i - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("LINEANUMERODataGridViewTextBoxColumn").Value) Then
                LineaNroDetalle = "0"
            Else
                LineaNroDetalle = DetalleVentaGridView.Rows(i - 1).Cells("LINEANUMERODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                CodCodigoVenta = "NULL"
            Else
                CodCodigoVenta = DetalleVentaGridView.Rows(i - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value) Then
                CodMonedaVenta = "NULL"
            Else
                CodMonedaVenta = DetalleVentaGridView.Rows(i - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                CantidadVenta = "NULL"
            Else
                CantidadVenta = DetalleVentaGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                CantidadVenta = Funciones.Cadenas.QuitarCad(CantidadVenta, ".")

                CantidadVenta = Replace(CantidadVenta, ",", ".")
            End If

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("DESCDataGridViewTextBoxColumn").Value) Then
                Desc = "NULL"
            Else
                Desc = DetalleVentaGridView.Rows(i - 1).Cells("DESCDataGridViewTextBoxColumn").Value
                Desc = Replace(Desc, ",", ".")
            End If

            Try
                If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value) Then
                    PrecioVentaBruto = "0"
                Else
                    PrecioVentaBruto = DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value
                    PrecioVentaBruto = CDec(PrecioVentaBruto) * CDec(Cot1FactTextBox.Text)
                End If
            Catch ex As Exception
                PrecioVentaBruto = "0"
            End Try

            Try
                If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("COSTOPROMEDIO").Value) Then
                    CostoFifo = "1"
                Else
                    CostoFifo = DetalleVentaGridView.Rows(i - 1).Cells("COSTOPROMEDIO").Value
                End If

            Catch ex As Exception
                CostoFifo = "1"
            End Try
            Try
                If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("PRODPROMOCION").Value) Then
                    PromoDet = 0
                Else
                    If DetalleVentaGridView.Rows(i - 1).Cells("PRODPROMOCION").Value = True Then
                        PromoDet = 1
                    Else
                        PromoDet = 0
                    End If
                End If
            Catch ex As Exception
                PromoDet = 0
            End Try

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value) Then
                PrecioVentaNeto = "NULL"
            Else
                PrecioVentaNeto = DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value
                PrecioVentaNeto = (CDec(PrecioVentaNeto) * CDec(Cot1FactTextBox.Text))
            End If

            'SACAMOS EL IVA, PRECIOBRUTO - PRECIONETO
            Try
                IvaVenta = CDec(PrecioVentaBruto) - CDec(PrecioVentaNeto)
                SumaIva = (CDec(SumaIva) + CDec(IvaVenta))
            Catch ex As Exception
                IvaVenta = 0
            End Try

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value) Then
                PrecioVentaLista = "NULL"
            Else
                PrecioVentaLista = DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                PrecioVentaLista = PrecioVentaLista * Cot1FactTextBox.Text
                PrecioVentaLista = Funciones.Cadenas.QuitarCad(PrecioVentaLista, ".")
                PrecioVentaLista = Replace(PrecioVentaLista, ",", ".")
            End If

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("IVADataGridViewTextBoxColumn").Value) Then
                Iva = "NULL"
            Else
                Iva = Math.Round(CDec(DetalleVentaGridView.Rows(i - 1).Cells("IVADataGridViewTextBoxColumn").Value))
                Iva = Funciones.Cadenas.QuitarCad(Iva, ".")
                Iva = Replace(Iva, ",", ".")
            End If

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value) Then
                CodSucursal = "NULL"
            Else
                CodSucursal = DetalleVentaGridView.Rows(i - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value
            End If

            codenviodetalle = "NULL"

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value) Then
                importe10 = 0
            Else
                importe10 = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value, cantdecimales)
            End If
            importe10 = importe10 * Cot1FactTextBox.Text

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value) Then
                importe5 = 0
            Else
                importe5 = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value, cantdecimales)
            End If
            importe5 = importe5 * Cot1FactTextBox.Text

            If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value) Then
                importeexento = 0
            Else
                importeexento = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value, cantdecimales)
            End If
            importeexento = importeexento * Cot1FactTextBox.Text

            'replaces#################################################

            PrecioVentaNeto = Funciones.Cadenas.QuitarCad(PrecioVentaNeto, ".")
            PrecioVentaNeto = Replace(PrecioVentaNeto, ",", ".")

            CostoFifo = Funciones.Cadenas.QuitarCad(CostoFifo, ".")
            CostoFifo = Replace(CostoFifo, ",", ".")

            PrecioVentaBruto = Funciones.Cadenas.QuitarCad(PrecioVentaBruto, ".")
            PrecioVentaBruto = Replace(PrecioVentaBruto, ",", ".")

            importeexento = Funciones.Cadenas.QuitarCad(importeexento, ".")
            importeexento = Replace(importeexento, ",", ".")

            importe5 = Funciones.Cadenas.QuitarCad(importe5, ".")
            importe5 = Replace(importe5, ",", ".")

            importe10 = Funciones.Cadenas.QuitarCad(importe10, ".")
            importe10 = Replace(importe10, ",", ".")

            '############################################################################
            'preguntamos si existe el detalle para saber si actualizar o insertar

            Existe = w.FuncionConsulta("VentaDetalleID", "VENTASDETALLE", "CODVENTA = " & VCodVenta & " AND VentaDetalleID ", LineaNro)

            If Existe <> 0 Then
                consultaInsert = consultaInsert + " update VENTASDETALLE set " & _
                "CANTIDADVENTA = " & CantidadVenta & ", " & _
                "PRECIOVENTABRUTO = " & PrecioVentaBruto & ", " & _
                "PRECIOVENTANETO = " & PrecioVentaNeto & " , " & _
                "PRECIOVENTALISTA = " & PrecioVentaLista & "," & _
                "IVA = " & Iva & ", " & _
                "[DESC] = " & Desc & ", LINEANUMERO = " & LineaNroDetalle & ", " & _
                "CODSUCURSAL = " & CodSucursal & ",IMPORTEGRABADODIEZ=" & importe10 & ",IMPORTEGRABADOCINCO=" & importe5 & ",IMPORTEEXENTO=" & importeexento & ",COSTOPROMEDIO=" & CostoFifo & ", PRODPROMOCION= " & PromoDet & " " & _
                "WHERE VentaDetalleID = " & LineaNro & ""

                '################AUDITORIA########################
            Else
                consultaInsert = consultaInsert + " insert into VENTASDETALLE " & _
                "(CODPRODUCTO, CODCODIGO, CODVENTA," & _
                "CODMONEDA, CANTIDADVENTA, PRECIOVENTABRUTO," & _
                "PRECIOVENTANETO, PRECIOVENTALISTA, IVA, [DESC], " & _
                "CODSUCURSAL,IMPORTEGRABADODIEZ,IMPORTEGRABADOCINCO,IMPORTEEXENTO,COSTOPROMEDIO,PRODPROMOCION, LINEANUMERO, SERIE) VALUES " & _
                "(" & CodProductoVenta & ", " & _
                " " & CodCodigoVenta & "," & _
                "" & Me.VCodVenta & ",  " & _
                "" & CodMonedaVenta & ", " & _
                "" & CantidadVenta & ", " & _
                "" & PrecioVentaBruto & "," & _
                "" & PrecioVentaNeto & ", " & _
                "" & PrecioVentaLista & "," & _
                "" & Iva & "," & _
                "" & Desc & "," & _
                "" & CodSucursal & ", " & _
                "" & importe10 & "," & importe5 & "," & importeexento & "," & CostoFifo & ", " & PromoDet & ", " & LineaNroDetalle & ", '" & codSerie & "') "
            End If
        Next

        cmd.CommandText = consultaInsert
        'cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizaVenta()
        Dim consulta As String
        Dim codpresupuesto, codzona, metodo, codevento, modalidad As String
        Dim Cliente As String = CmbCliente.Text
        Dim OBS As String

        If txtObservacion.Text = "" Then
            OBS = " "
        Else
            OBS = txtObservacion.Text
        End If

        If VendendorComboBox.SelectedValue = Nothing Then
            CodVendedor = "NULL"
        Else
            CodVendedor = VendendorComboBox.SelectedValue
        End If
        If Cot1FactTextBox.Text = "" Or Cot1FactTextBox.Text = "0,00" Then
            Cotizacion1V = "1"
        Else
            Cotizacion1V = CDec(Cot1FactTextBox.Text)
            Cotizacion1V = Funciones.Cadenas.QuitarCad(Cotizacion1V, ".")
            Cotizacion1V = Replace(Cotizacion1V, ",", ".")
        End If

        If CmbEvento.SelectedValue = Nothing Then
            codevento = "NULL"
        Else
            codevento = CmbEvento.SelectedValue
        End If

        codzona = f.FuncionConsulta("codzona", "clientes", "CAST(codcliente AS VARCHAR)", TxtCodigoCliente.Text)
        If codzona = 0 Then
            codzona = "null"
        End If
        If CmbMetodo.Text = Nothing Then
            metodo = "NULL"
        Else
            metodo = CmbMetodo.Text
        End If

        codpresupuesto = "NULL"

        If chbxBonif.Checked = True Then
            modalidad = "2"
        ElseIf chbxCambio.Checked = True Then
            modalidad = "3"
        ElseIf chbxOtros.Checked = True Then
            modalidad = "4"
        Else
            If CmbTipoVenta.Text = "Contado" Then
                modalidad = "0"
            Else
                modalidad = "1"
            End If
        End If

        Try
            Dim tipocomp2 As Integer = f.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)
            Dim codsuc As Integer = f.FuncionConsulta("CODSUCURSAL", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = dtpFechaHora.Text
            Dim Concatenar As String = Concat & " " + hora

            consulta = "UPDATE VENTAS SET CODMONEDA=" & CmbMoneda.SelectedValue & ", MOTIVODESCUENTO ='" & OBS & "'," & _
                  "CODEMPRESA=" & EmpCodigo & ", CODUSUARIO = " & UsuCodigo & _
                  ",CODCOMPROBANTE=" & tipocomp2 & ", " & _
                  "CODCLIENTE=" & CmbCliente.SelectedValue & ", " & _
                  "CODSUCURSAL=" & codsuc & "," & _
                  "CODDEPOSITO=" & CmbSucursal.SelectedValue & "," & _
                  "FECHAVENTA= CONVERT(Datetime,'" & Concatenar & "',103)," & _
                  "TOTALEXENTA=" & TotalExentaV & ", " & _
                  "TOTALGRAVADA=" & TotalGravadaV & ",TOTALIVA=" & TotalIvaV & ",  " & _
                  "COTIZACION1=" & Cotizacion1V & ",TIPOVENTA=" & TxTTipoVenta.Text & ", NOMBRECLIENTE='" & Replace(Cliente, "'", "''") & "'," & _
                  "RUCCLIENTE='" & RUCClienteTextBox.Text & "', MODALIDADPAGO=" & modalidad & ", " & _
                  "DIRECCION='" & Replace(txtLocalizacion.Text, "'", "''") & "'," & _
                  "CODVENDEDOR=" & CodVendedor & ",CODPRESUPUESTO=" & codpresupuesto & "," & _
                  "TOTAL10=" & Total10 & ",TOTAL5=" & Total5 & ",  " & _
                  "CODZONA=" & codzona & ",CODEVENTO=" & codevento & ",METODO='" & metodo & "',  " & _
                  "TOTALGRAVADO5=" & TotalGravado5V & ",TOTALGRAVADO10=" & TotalGravado10V & ",TOTALVENTA=" & TotalVentaV & ",NUMVENTATIMBRADO=" & TimbradoFactura & ",CODRANGO=" & TipoComprobanteComboBox.SelectedValue & " " & _
                  "WHERE CODVENTA=" & CDec(VCodVenta) & ""

            cmd.CommandText = consulta
            cmd.ExecuteNonQuery()

        Catch ex As Exception
        End Try
    End Sub


    Private Sub AgregarDetVentaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarDetVentaButton.Click
        Dim YaEstoy As Integer
        Dim PrecioVenta As Double
        Dim servicio As Integer
        Dim stockdesdelector As String

        If CodProductoTextBox.Text <> "" Then
            servicio = w.FuncionConsultaDecimal("SERVICIO", "PRODUCTOS", "CODPRODUCTO", CodProductoTextBox.Text)
        End If

        'Validamos
        Dim ErrorMsg As String = ""
        If TipoComprobanteComboBox.SelectedValue = Nothing Then
            TipoComprobanteComboBox.BackColor = Color.Pink
            ErrorMsg = "1"
        End If
        If CmbSucursal.SelectedValue = Nothing OrElse String.IsNullOrEmpty(CmbSucursal.SelectedValue) Then
            CmbSucursal.BackColor = Color.Pink
            ErrorMsg = "1"
        End If
        If CodCodigoTextBox.Text = "" Or CodProductoTextBox.Text = "" Then
            tbxCodigoProducto.BackColor = Color.Pink
            ErrorMsg = "1"
        End If
        If String.IsNullOrEmpty(CantidadVentaMaskedEdit.Text) Then
            CantidadVentaMaskedEdit.BackColor = Color.Pink
            ErrorMsg = "1"
        ElseIf CDec(CantidadVentaMaskedEdit.Text) = 0 Then
            CantidadVentaMaskedEdit.BackColor = Color.Pink
            ErrorMsg = "1"
        End If
        If String.IsNullOrEmpty(tbxPrecioVenta.Text) Then
            tbxPrecioVenta.BackColor = Color.Pink
            ErrorMsg = "1"
        End If

        If DesProductoTextBox.Text = "" Then
            tbxCodigoProducto.BackColor = Color.Pink
            ErrorMsg = "1"
        End If

        If ErrorMsg <> "" Then
            MessageBox.Show("Verifique los Campos marcados en Rosa!" & vbCrLf & "Sera que te falto cargar algo?", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ErrorMsg = ""
            Exit Sub
        End If

        'Si tiene la configuración, alertamos si hubo cambio de precio venta

        If Config11 = "Si" Then
            If CDec(PrecioVentaG) <> CDec(tbxPrecioVenta.Text) Then
                If MessageBox.Show("Se cambió el Precio de Venta del Producto, ¿Desea Agregarlo de todos modos?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.No Then
                    tbxPrecioVenta.Focus()
                    Exit Sub
                End If
            End If
        End If


        '################################################################################################################
        '# Antes de agregar el producto en la grilla debemos verificar que si es una Factura Credito no tengo un credito
        '# mayor a su limite permitido. By Yolanda Zelaya
        '################################################################################################################
        If CmbTipoVenta.Text = "Crédito" Then
            ' 1 - Verificamos el limite de credito del cliente
            Dim LimiteCredito As Double
            permiso = PermisoAplicado(UsuCodigo, 34)
            If permiso = 0 Then
                'Verificar que este Cliente no sobrepase su limite de Credito
                LimiteCredito = w.FuncionConsultaDecimal("LIMCREDITO", "CLIENTES", "NUMCLIENTE", TxtNumCliente.Text)
                LimiteCredito = Replace(LimiteCredito, ",", ".")

                If LimiteCredito <> "0,00" Then
                    ' 2 - Verificamos el monto total del credito que tiene acumulado para verificar que no sobrepase su limite establecido
                    Dim TotalVentas, TotalCobros, Total As Double
                    Dim SQLConsulta As String

                    'Verificamos si tiene descuento
                    If TxtDescuento.Text <> "" Then
                        'si tiene descuento tenemos que ver si es con Porcentaje o un Monto
                        PrecioVenta = CDec(tbxPrecioVenta.Text)
                        If lblSimboloDesc.Text = "%" Then
                            TotalCalc = FormatNumber((PrecioVenta * CDec(TxtDescuento.Text)) / 100, cantdecimales)
                            PrecioVenta = FormatNumber(PrecioVenta - TotalCalc, cantdecimales)
                            PrecioVenta = FormatNumber(PrecioVenta * CDec(Cot1FactTextBox.Text), cantdecimales)
                        Else
                            TotalCalc = CDec(TxtDescuento.Text)
                            PrecioVenta = PrecioVenta - TotalCalc
                            PrecioVenta = FormatNumber(PrecioVenta * CDec(Cot1FactTextBox.Text), cantdecimales)
                        End If
                    Else
                        PrecioVenta = FormatNumber(CDec(tbxPrecioVenta.Text) * CDec(Cot1FactTextBox.Text), cantdecimales)
                        TotalCalc = 0
                    End If

                    SQLConsulta = "CODCLIENTE = " & CmbCliente.SelectedValue & " AND TIPOMOVIMIENTO "
                    TotalVentas = w.FuncionConsultaDecimal("SUM(IMPORTE)", "MOVIMIENTOCUENTACLIENTE", SQLConsulta, "Venta")

                    SQLConsulta = "CODCLIENTE = " & CmbCliente.SelectedValue & " AND TIPOMOVIMIENTO "
                    TotalCobros = w.FuncionConsultaDecimal("SUM(IMPORTE)", "MOVIMIENTOCUENTACLIENTE", SQLConsulta, "Cobro")

                    If TotalVentaTextBox.Text <> "0,00" And TotalVentaTextBox.Text <> "" Then
                        TotalVentas = TotalVentas + PrecioVenta + CDec(TotalVentaTextBox.Text)
                    Else
                        TotalVentas = TotalVentas + PrecioVenta
                    End If

                    Total = TotalVentas - TotalCobros
                    Total = FormatNumber(Total, cantdecimales)

                    If Total > LimiteCredito Then
                        MessageBox.Show("Cliente sobrepaso su Limite de Credito. Hable con un Gerente o Administrador de su Empresa", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
        End If

        'La cantidad no puede ser mayor al de stock actual
        If servicio = 1 Then
        Else
            If TxtCantidadEnStock.Text = "" Then
                stockdesdelector = f.FuncionConsultaString("STOCKACTUAL", "STOCKDEPOSITO", "CODCODIGO=" & CodCodigoTextBox.Text & " AND CODDEPOSITO", CmbSucursal.SelectedValue)

                If stockdesdelector = Nothing Then
                    'Aqui ver despues...porque así esta permitiendo guardar un producto que no existe en el deposito (por Guazu)
                    TxtCantidadEnStock.Text = 0
                Else
                    TxtCantidadEnStock.Text = stockdesdelector
                End If

            End If

            If CDec(CantidadVentaMaskedEdit.Text) > CDec(TxtCantidadEnStock.Text) Then
                If ProdPE = 1 Then
                    Dim TGramo As Double

                    TGramo = CantidadVentaMaskedEdit.Text / 1000
                    If TGramo > CDec(TxtCantidadEnStock.Text) Then
                        If VenderMasQueStock = 0 Then
                            MessageBox.Show("No se puede insertar porque sobrepasó el stock actual", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            CantidadVentaMaskedEdit.Focus()
                            ProdPE = 0
                            Exit Sub
                        End If
                    End If
                Else
                    If VenderMasQueStock = 0 Then
                        MessageBox.Show("No se puede insertar porque sobrepasó el stock actual", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        CantidadVentaMaskedEdit.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If CDec(CantidadVentaMaskedEdit.Text) > CDec(TxtCantidadEnStock.Text) Then
                If VenderMasQueStock = 0 Then
                    MessageBox.Show("No se puede insertar porque sobrepasó el stock actual", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CantidadVentaMaskedEdit.Focus()
                    Exit Sub
                End If
            End If
        End If


        '####################################################################
        '--------DEPENDIENDO DEL TIPO DE IMPRESION SE OBTIENE LA CANTIDAD DE LINEA

        'Se verifica que tipo de formato de impresion tiene dicho comprabante
        TipoImpresion = w.FuncionConsulta("dbo.TIPOCOMPROBANTE.FORMAIMPRESION", "dbo.TIPOCOMPROBANTE INNER JOIN dbo.DETPC ON dbo.TIPOCOMPROBANTE.CODCOMPROBANTE = dbo.DETPC.CODCOMPROBANTE", "dbo.DETPC.RANDOID", TipoComprobanteComboBox.SelectedValue)

        If TipoImpresion = 1 Then 'Formato Impresora
            'Sistema Verifica las cantidad de lineas para el comprobante selecto. 
            Cantlinea = w.FuncionConsulta("dbo.TIPOCOMPROBANTE.NROLINEASDETALLE", "dbo.TIPOCOMPROBANTE INNER JOIN dbo.DETPC ON dbo.TIPOCOMPROBANTE.CODCOMPROBANTE = dbo.DETPC.CODCOMPROBANTE", "dbo.DETPC.RANDOID", TipoComprobanteComboBox.SelectedValue)
            If Cantlinea = 0 Then
                If MessageBox.Show("Este Comprobante no tiene su Cantidad de Lineas especificado. Desea Especificarlo?", "POSSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ABMRangoComprobante.Show()
                    Exit Sub
                Else
                    Exit Sub
                End If
            End If

            If DetalleVentaGridView.RowCount = Cantlinea Then
                MessageBox.Show("Solo se permiten hasta " + Cantlinea.ToString + " lineas para este Tipo de Comprobante", "POSSEXPRESS")
                Exit Sub
            End If
        End If

        '####################################################################

        Dim CantDeStockAct As Double
        If tbxCodigoProducto.Text.IndexOf("200") = 0 Or tbxCodigoProducto.Text.IndexOf("240") = 0 Then
            CantDeStockAct = Replace(CantidadVentaMaskedEdit.Text, ".", ",")
        Else
            CantDeStockAct = CantidadVentaMaskedEdit.Text
        End If

        If AgregarDetVentaButton.Text = "Modificar" Then

        Else
            '###########################VALIDAMOS QUE NO SE REPITAN LOS ARTICULOS#########################

            ' Dim CodigoProducto As Integer = CodCodigoComComboBox.SelectedValue
            If eligiocbo = 1 Then 'para validar que no se repitan los combos
                Dim y As Integer = DetalleVentaGridView.RowCount
                YaEstoy = 0
                For i = 1 To y

                    If IsDBNull(DetalleVentaGridView.Rows(i - 1).Cells("CodigoGrilla").Value) Then
                    Else
                        If CodComboTextBox.Text = DetalleVentaGridView.Rows(i - 1).Cells("CodigoGrilla").Value Then
                            If MessageBox.Show("El Producto ya se encuentra en el detalle, ¿Desea Agregarlo?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.No Then
                                CodCodigoTextBox.Text = ""
                                CodProductoTextBox.Text = ""
                                tbxCodigoProducto.Focus()
                                Exit Sub
                            End If
                            YaEstoy = 1
                        End If
                    End If


                Next
            End If
            ' si eligio producto
            YaEstoy = 0
            Dim x As Integer = DetalleVentaGridView.RowCount
            For x = 1 To x
                ' Items repetidos 

                If IsDBNull(DetalleVentaGridView.Rows(x - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                Else
                    If CodCodigoTextBox.Text = DetalleVentaGridView.Rows(x - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value Then
                        If YaEstoy = 0 Then
                            If MessageBox.Show("El Producto ya se encuentra en el detalle, ¿Desea Agregarlo?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.No Then
                                CodCodigoTextBox.Text = ""
                                CodProductoTextBox.Text = ""
                                tbxCodigoProducto.Focus()
                                Exit Sub
                            End If
                            YaEstoy = 1
                        End If
                        'MessageBox.Show("El Producto ya se encuentra en el detalle", "RIA")
                        'Exit Sub
                    End If

                End If

                'Valida que no meta sucursales diferentes

                If IsDBNull(DetalleVentaGridView.Rows(x - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value) Then
                Else
                    If CmbSucursal.SelectedValue <> DetalleVentaGridView.Rows(x - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value Then
                        MessageBox.Show("No es permitido Insertar Productos de otros Depositos", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                End If

            Next


            VENTASDETALLEBindingSource.AddNew()


            Dim Precio, Cantidad, Subtotal, PrecioNeto As String
            Dim Iva, Iva1, CodIvaProducto, PorcIva, TotalIva, TotalGravada, TotalExenta, total10, total5 As String
            Dim CoheficienteIva As Decimal

            total10 = "0" : total5 = "0" : Subtotal = "0" : CoheficienteIva = "0" : PorcIva = "0" : TotalExenta = "0"
            TotalGravada = "0" : PrecioNeto = "0" : Subtotal = "" : TotalVentaV = "0" : TotalGravado10V = "0" : TotalGravado5V = "0"
            Iva = "0" : TotalIva = "0" : eligiocbo = 0

            Dim c As Integer = DetalleVentaGridView.RowCount
            Dim w As New Funciones.Funciones

            DetalleVentaGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value = CodProductoTextBox.Text
            DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = CodCodigoTextBox.Text
            DetalleVentaGridView.Rows(c - 1).Cells("CODIGOGrilla").Value = tbxCodigoProducto.Text

            'Verificamos si tiene descuento
            If TxtDescuento.Text <> "" Then
                'si tiene descuento tenemos que ver si es con Porcentaje o un Monto
                PrecioVenta = CDec(tbxPrecioVenta.Text)
                If lblSimboloDesc.Text = "%" Then
                    TotalCalc = FormatNumber((PrecioVenta * CDec(TxtDescuento.Text)) / 100, cantdecimales)
                    PrecioVenta = FormatNumber(PrecioVenta - TotalCalc, cantdecimales)
                Else
                    TotalCalc = CDec(TxtDescuento.Text)
                    PrecioVenta = PrecioVenta - TotalCalc
                End If
            Else
                If tbxPorcSuma.Text = "" Then
                    PrecioVenta = FormatNumber(CDec(tbxPrecioVenta.Text), cantdecimales)
                    TotalCalc = 0
                Else
                    PrecioVenta = ((FormatNumber(CDec(tbxPrecioVenta.Text), cantdecimales) * FormatNumber(CDec(tbxPorcSuma.Text), cantdecimales)) / 100) + FormatNumber(CDec(tbxPrecioVenta.Text), cantdecimales)
                End If
                
            End If

            'VERIFICAMOS SI ES UN TIPO DE PRODUCTO DESCUENTO - METODO REEEE IMPROVISADO. 
            Dim isDesc As Decimal = f.FuncionConsultaDecimal("SERVICIO", "PRODUCTOS", "CODPRODUCTO", CodProductoTextBox.Text)
            If isDesc = 5 Then
                DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value = PrecioVenta

                If lblDescuentoSimbolo.Text = "%" Then
                    PrecioVenta = (CDec(TotalVentaTextBox.Text) * PrecioVenta) / 100
                End If
                PrecioVenta = PrecioVenta * -1
            End If

            DetalleVentaGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value = CmbMoneda.SelectedValue
            '***
            DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value = PrecioVenta
            '***
            DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value = CantDeStockAct
            DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value = CDec(DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value * DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value)
            DetalleVentaGridView.Rows(c - 1).Cells("DESCDataGridViewTextBoxColumn").Value = TotalCalc
            DetalleVentaGridView.Rows(c - 1).Cells("ProductoGrilla").Value = Me.DesProductoTextBox.Text
            DetalleVentaGridView.Rows(c - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value = CmbSucursal.SelectedValue
            DetalleVentaGridView.Rows(c - 1).Cells("SIMBOLO").Value = lblSimboloMoneda.Text
            DetalleVentaGridView.Rows(c - 1).Cells("LINEANUMERODataGridViewTextBoxColumn").Value = c


            'Dim serie As New serie_class
            'DetalleVentaGridView.Rows(c - 1).Cells("SERIE").Value = serie.Serie(CodProductoTextBox.Text, DesProductoTextBox.Text)

            DetalleVentaGridView.Rows(c - 1).Cells("SERIE").Value = tbxNroSerie.Text
            ' Precio = FormatNumber(DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value, cantdecimales)
            Cantidad = DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value

            'PARA LOS PRODUCTOS PESABLES 
            If (Me.tbxCodigoProducto.Text.IndexOf("200") = 0 Or Me.tbxCodigoProducto.Text.IndexOf("240") = 0 Or ProdPE = 1) Then
                Cantidad = Replace(Cantidad, ".", ",")
                DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value = Cantidad
            End If

            DetalleVentaGridView.Rows(c - 1).Cells("COSTOPROMEDIO").Value = CDec(FIFOCOSTO)
            DetalleVentaGridView.Rows(c - 1).Cells("PRODPROMOCION").Value = PROMO

            Subtotal = DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value
            DetalleVentaGridView.Rows(c - 1).Cells("Subtotal").Value = Subtotal

            CodIvaProducto = cbxTipoIva.SelectedValue
            CoheficienteIva = w.FuncionConsultaDecimal("COHEFICIENTE", "IVA", "CODIVA", CodIvaProducto)
            PorcIva = w.FuncionConsultaString("PORCENTAJEIVA", "IVA", "CODIVA", CodIvaProducto)

            If CoheficienteIva = 1 Then
                Iva1 = "0"
                Iva = FormatNumber(Iva1, 2)
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = Subtotal
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = 0
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = 0
            ElseIf CoheficienteIva = 1.1 Then
                Iva1 = CDbl(Subtotal) / 11
                Iva = Iva1
                Iva = Funciones.Cadenas.QuitarCad(Iva, ".")
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = Subtotal
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = 0
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = 0

            ElseIf CoheficienteIva = 1.05 Then
                Iva1 = CDec(Subtotal) / 21
                Iva = FormatNumber(Iva1, 10)
                Iva = Funciones.Cadenas.QuitarCad(Iva, ".")
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = Subtotal
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = 0
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = 0
            End If

            DetalleVentaGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = CDec(PorcIva)

            'Tipo de iva
            'PRECIO NETO
            If Subtotal <> "0" And CoheficienteIva <> 1 Then
                PrecioNeto = CDbl(Subtotal) - CDbl(Iva)
                DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = PrecioNeto
            ElseIf CoheficienteIva = 1 Then
                DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = CDec(Subtotal)
            End If

            Dim sumaimpgrav10, sumaimpgrav5, sumaimpexe As Double
            sumaimpgrav10 = 0 : sumaimpgrav5 = 0 : sumaimpexe = 0 : Subtotal = 0
            'SAUL}


            For Each columna As DataGridViewRow In DetalleVentaGridView.Rows
                If IsDBNull(columna.Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value) Then
                    columna.Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = "0"
                End If
                If IsDBNull(columna.Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value) Then
                    columna.Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = "0"
                End If
                If IsDBNull(columna.Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value) Then
                    columna.Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = "0"
                End If
                If IsDBNull(columna.Cells("SubTotal").Value) Then
                    columna.Cells("SubTotal").Value = "0"
                End If
                sumaimpgrav10 = sumaimpgrav10 + CDec(columna.Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value)
                sumaimpgrav5 = sumaimpgrav5 + CDec(columna.Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value)
                sumaimpexe = sumaimpexe + CDec(columna.Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value)
                Subtotal = Subtotal + CDec(columna.Cells("SubTotal").Value)
            Next

            TotalGravado10V = sumaimpgrav10
            TotalGravado5V = sumaimpgrav5
            TotalGravada = sumaimpgrav10 + sumaimpgrav5
            TotalVentaV = sumaimpgrav10 + sumaimpgrav5 + sumaimpexe
            total10 = CDbl(sumaimpgrav10 / 11)
            total5 = CDbl(sumaimpgrav5 / 21)
            TotalExenta = sumaimpexe
            TotalIva = CDbl(total10) + CDbl(total5)
            If servicio = 1 And TotalVentaV = 0 Then
                TotalVentaV = Subtotal
                TotalExenta = Subtotal
            End If

            If CmbMoneda.SelectedValue = 1 Or CmbMoneda.SelectedValue = Nothing Then
                TotalVentaTextBox.Text = FormatNumber(TotalVentaV, 0)
            Else
                TotalVentaTextBox.Text = FormatNumber(TotalVentaV, cantdecimales)
            End If

            '*********************************************************************************

            TotalIvaVentaMaskedEdit.Text = TotalIva
            TotalGravadaMaskedEdit.Text = TotalGravada
            TotalExentaMaskedEdit.Text = TotalExenta
            totaliva10mascara.Text = total10
            Iva10TextBox1.Text = FormatNumber(total10, cantdecimales)
            totaliva5mascara.Text = total5
            Iva5TextBox1.Text = FormatNumber(total5, cantdecimales)
            '*********************************************************************************


            CantidadVentaMaskedEdit.Text = "" : tbxCodigoProducto.Text = "" : tbxPrecioVenta.Text = "" : DesProductoTextBox.Text = ""
            CodProductoTextBox.Text = "" : CodCodigoTextBox.Text = "" : TxtCantidadEnStock.Text = "" : TxtDescuento.Text = "" : tbxNroSerie.Text = ""
            ErrorCodigoLabel.Visible = False : lblDescuentoSimbolo.Visible = False : tbxPorcSuma.Text = "" : tbxPorcSuma.SendToBack() : tbxPorcSuma.Visible = False
            TxtDescuento.Appearance.BackColor = SystemColors.ControlLightLight : TxtDescuento.Enabled = True
            tbxCodigoProducto.Focus()

        End If
    End Sub

    Private Sub AgregarDetVentaButton_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AgregarDetVentaButton.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Left Then
            tbxPrecioVenta.Focus()
        End If
    End Sub

    Private Sub AnularunaFactura()
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction
        Dim consulta As System.String

        conexion = ser.Abrir()

        Try
            consulta = "UPDATE VENTAS SET ESTADO=2,MOTIVOANULADO='" & TxtMotivodeAnulacion.Text & "' WHERE  CODVENTA =" & CDec(VCodVenta) & "  "
            consulta = consulta + "DELETE FROM FACTURACOBRAR WHERE  CODVENTA =" & CDec(VCodVenta) & "  "
            consulta = consulta + "DELETE FROM MOVIMIENTOCUENTACLIENTE WHERE  CODVENTA =" & CDec(VCodVenta) & "  "

            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            Consultas.ConsultaComando(myTrans, consulta)

            Try
                If CmbMetodo.Text = "Simplificado" Then
                    InsertaMovProducto(myTrans, Me.NroFacturaLabel.Text)
                    Consultas.ConsultaComando(myTrans, consulta)
                End If

                myTrans.Commit()

                '################################################################################################################
                'Anular Venta, Ceramos los asientos creados. By Yolanda Zelaya
                AnularAsientos(CDec(VCodVenta), 8)
                '################################################################################################################

                'Preguntamos si quiere eliminar el Cobro (Esto es solo cuando es contado)
                If Config8 = "Habilitar Eliminar Cobro" Then
                    If CmbTipoVenta.Text = "Contado" Then
                        Dim ImporteEliminado As Double
                        Dim CodCobro As Double = f.FuncionConsultaDecimal("CODCOBRO", "VENTASFORMACOBRO", "CODVENTA", VCodVenta)

                        If MessageBox.Show("¿Desea Eliminar Tambien el Cobro?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                            GoTo Salir
                        End If

                        ImporteEliminado = CDec(TotalVentaTextBox.Text)

                        ser.Abrir(sqlc)
                        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualiza")

                        cmd.Connection = sqlc
                        cmd.Transaction = myTrans

                        Try
                            'Actualizamos en la Tabla FacturaCobrar :)
                            ActualizaCobroEliminado(ImporteEliminado, VCodVenta, "0")

                            'Eliminamos el detalle de pago de la Tabla COMPRASFORMAPAGO y MOVIMIENTOS :(
                            EliminarCobroMovimiento(CodCobro)
                            EliminarCobroEliminado(CodCobro)

                            myTrans.Commit()
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try

                Throw ex
            End Try
Salir:
            Dim I As Integer = VENTASBindingSource.Position
            FechaFiltro()

            If Config1 = "Con todas las Sucursales" Then
                Me.VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
            Else
                VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
            End If

            VENTASBindingSource.Position = I
            PanelMotivoAnulacion.Visible = False

        Catch ex As Exception
            MessageBox.Show("Error al Anular: " + ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub ActualizaCobroEliminado(ByRef ImporteActualizar As Double, ByRef CodVenta As Integer, ByRef ParPagado As Integer)
        sql = ""
        sql = "UPDATE FACTURACOBRAR SET SALDOCUOTA = SALDOCUOTA + " & CDec(ImporteActualizar) & ", PAGADO = " & ParPagado & ", COTIZACION = " & CInt(Cot1FactTextBox.Text) & "  " & _
              "WHERE CODVENTA = " & CodVenta

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarCobroMovimiento(ByRef CodCobroEL As Integer)
        sql = ""
        sql = "DELETE movimientos WHERE id_cobro = " & CodCobroEL

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarCobroEliminado(ByRef CodCobroEL As Integer)
        sql = ""
        sql = "DELETE VENTASFORMACOBRO WHERE CODCOBRO = " & CodCobroEL

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Aprobar()
        Dim CodVentaTemp As Integer
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction
        conexion = ser.Abrir()
        Try
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            Try

                If CmbTipoVenta.Text = "Contado" Then
                    InsertaFacturaCobrar(myTrans)
                End If

                If CmbMetodo.Text = "Simplificado" Then
                    InsertaMovProducto(myTrans, NumVentaV)
                ElseIf CmbMetodo.Text = "Avanzado" Then
                    ActualizaSaldoProducto(myTrans)
                End If

                myTrans.Commit()
            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                Throw ex
            End Try

            CodVentaTemp = VCodVenta

            FechaFiltro()
            If Config1 = "Con todas las Sucursales" Then
                VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
            Else
                VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
            End If
            Me.FACTURACOBRARTableAdapter.Fill(DsFacturacionCompleja.FACTURACOBRAR)

            'Buscamos la posicion del registro guardado
            For i = 0 To GridViewFacturacion.RowCount - 1
                If GridViewFacturacion.Rows(i).Cells("CODVENTADataGridViewTextBoxColumn").Value = CodVentaTemp Then
                    VENTASBindingSource.Position = i
                    Exit For
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error al procesar la factura para imprimir, no se puede aprobar la factura ", "RIA")
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub ActualizaSaldoProducto(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim consulta As System.String
        Dim CantidadFactura, CodCodigoFactura As String
        Dim c As Integer = DetalleVentaGridView.RowCount
        Dim IsProducto As Integer

        For c = 1 To c
            'SE DEBE VERIFICAR QUE NO SEA UN SERVICIO
            IsProducto = w.FuncionConsulta("SERVICIO", "PRODUCTOS", "CODPRODUCTO", DetalleVentaGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value)

            If IsProducto <> 1 And IsProducto <> 5 Then
                If IsDBNull(DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                    CantidadFactura = "NULL"
                Else
                    CantidadFactura = DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                    CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                    CantidadFactura = Replace(CantidadFactura, ",", ".")

                    If IsDBNull(DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                        CodCodigoFactura = "NULL"
                    Else
                        CodCodigoFactura = DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                    End If

                    consulta = "UPDATE VENTASDETALLE SET SALDOENVIO  = " & CantidadFactura & " WHERE CODVENTA = " & CodVenta & " AND CODCODIGO = " & CodCodigoFactura

                    Consultas.ConsultaComando(myTrans, consulta)
                End If
            End If
        Next
    End Sub

    Private Sub InsertaMovProducto(ByVal myTrans As System.Data.Common.DbTransaction, ByVal NrodeVenta As String)
        Dim consulta As System.String
        Dim CantidadFactura, CodCodigoFactura, Precio, Costeable As String
        Dim c As Integer = DetalleVentaGridView.RowCount
        Dim IsProducto As Integer

        For c = 1 To c
            'SE DEBE VERIFICAR QUE NO SEA UN SERVICIO
            IsProducto = w.FuncionConsulta("SERVICIO", "PRODUCTOS", "CODPRODUCTO", DetalleVentaGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value)

            If IsProducto <> 1 Then
                If IsDBNull(DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                    CantidadFactura = "NULL"
                Else
                    CantidadFactura = DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                    CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                    CantidadFactura = Replace(CantidadFactura, ",", ".")

                    If btAprobado = 1 Then
                        CantidadFactura = "-" + CantidadFactura
                    ElseIf btAnulado = 1 Then
                        CantidadFactura = CantidadFactura
                    End If
                End If

                Costeable = 0
                If IsDBNull(DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                    CodCodigoFactura = "NULL"
                Else
                    CodCodigoFactura = DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                End If

                If IsDBNull(DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value) Then
                    Precio = "NULL"
                Else
                    Precio = DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                    Precio = Precio * CDec(Cot1FactTextBox.Text)
                    Precio = Funciones.Cadenas.QuitarCad(Precio, ".")
                    Precio = Replace(Precio, ",", ".")
                End If

                Dim hora, Concat, Concatenar As String

                hora = Now.ToString("HH:mm:ss")
                Concat = dtpFechaHora.Text
                Concatenar = Concat & " " + hora

                consulta = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,STOCK) " & _
                           "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & CmbSucursal.SelectedValue & ",CONVERT(Datetime,'" & Concatenar & "',103),8," & GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & _
                           "," & CantidadFactura & "," & Precio & ",'Venta Nro " & NrodeVenta & "'," & Costeable & ",1)"


                Consultas.ConsultaComando(myTrans, consulta)
            End If
        Next
    End Sub

    Private Sub BtnAceptarCuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarCuotas.Click
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction
        Dim existe As Integer
        Dim Aprovperm As Double = PermisoAplicado(UsuCodigo, 201)


        If Not IsDBNull(GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value) Then
            If GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value = 1 And Aprovperm = 1 Then
                If TxtEstado.Text = 0 Then
                    'Duplicamos el contenido seleccionado y nos posicionamos sobre el mismo
                    tsDuplicarFactura_Click(Nothing, Nothing)
                End If
            End If
        End If
        existe = f.FuncionConsulta("CODVENTA", "VENTAS", "CODVENTA", VCodVenta)

        If existe > 0 Then
            conexion = ser.Abrir()
            Try
                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                Try
                    InsertaFacturaCobrar(myTrans) ' Inserta en la tabla facturacobrar(cuotas)
                    myTrans.Commit()
                Catch ex As Exception
                    Try
                        myTrans.Rollback("Actualizar")
                    Catch
                    End Try

                    Throw ex
                End Try

                If TxtEstado.Text = 0 Then  'en caso que no se cargo las cuotas y se deba volver a cargar no debemos hacer todo el proceso de Aprobar nuevamente si ya esta aprobado
                    AprobarCheck()
                End If

                Dim GRPos As Integer = VENTASBindingSource.Position
                FechaFiltro()
                If Config1 = "Con todas las Sucursales" Then
                    VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
                Else
                    VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
                End If
                VENTASBindingSource.Position = GRPos

                DeshabilitaControles()

            Catch ex As Exception

                MessageBox.Show("Error al cargar Cuotas: " + ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Cancelamos todo :(
            Finally
                conexion.Close()
            End Try
            PanelCuota.Visible = False
        Else
            MessageBox.Show("Debe guardar la factura para guardar las cuotas", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PanelCuota.Visible = False
        End If

        Me.Cursor = Cursors.Arrow

        FACTURACOBRARTableAdapter.Fill(DsFacturacionCompleja.FACTURACOBRAR)
        GridViewCuotas.Refresh()
        lblProximoNro_Click(Nothing, Nothing)
        PintarCeldas()
    End Sub

    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        If OKSupervisor = 0 Then
            permiso = PermisoAplicado(UsuCodigo, 30)
            If permiso = 0 Then
                AccionPermiso = "Anular"
                pnlCodSupervisor.Visible = True
                pnlCodSupervisor.BringToFront()
                txtCodigoSupervisor.Focus()
            Else
                GoTo OKSupervisor
            End If
        Else

OKSupervisor:
            If TxtMotivodeAnulacion.Text = "" Then
                MessageBox.Show("Ingrese el motivo de anulación", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMotivodeAnulacion.Focus()
                Exit Sub
            End If

            'Anular Presupuesto
            If Not IsDBNull(GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value) And (GridViewFacturacion.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 0) Then
                If (GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value = 1) And (GridViewFacturacion.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 0) Then
                    Dim conexion As System.Data.SqlClient.SqlConnection
                    Dim myTrans As System.Data.SqlClient.SqlTransaction
                    Dim consulta As System.String

                    conexion = ser.Abrir()

                    Try
                        consulta = "UPDATE VENTAS SET ESTADO=2,MOTIVOANULADO='" & TxtMotivodeAnulacion.Text & "' WHERE  CODVENTA =" & CDec(VCodVenta) & "  "
                        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                        Consultas.ConsultaComando(myTrans, consulta)
                        myTrans.Commit()
                    Catch ex As Exception
                    End Try

                    Dim I As Integer = VENTASBindingSource.Position
                    FechaFiltro()

                    If Config1 = "Con todas las Sucursales" Then
                        Me.VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
                    Else
                        VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
                    End If

                    VENTASBindingSource.Position = I
                    PanelMotivoAnulacion.Visible = False
                ElseIf TxtEstado.Text = 1 Then
                    AnularunaFactura() 'Anular Venta
                End If
            ElseIf TxtEstado.Text = 1 Then
                AnularunaFactura() 'Anular Venta
            End If

            Me.Cursor = Cursors.AppStarting
            OKSupervisor = 0
        End If

        PintarCeldas()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BtnAsterisco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsterisco.Click
        PanelCliente = 1
        UltraPopupControlContainer1.PopupControl = GroupBoxCliente
        UltraPopupControlContainer1.Show()

        TxtBuscaCliente.Text = ""
        TxtBuscaCliente.Focus()
    End Sub

    Private Sub BtnCancelaCuota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelaCuota.Click
        PanelCuota.Visible = False
        btcfcuota = 0
    End Sub

    Private Sub BtnCancelarCuota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarCuota.Click
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim existe As Integer

        Try
            existe = f.FuncionConsulta("CODVENTA", "FACTURACOBRAR", "CODVENTA", VCodVenta)
            If existe > 0 Then
                Try
                    consulta = "DELETE FACTURACOBRAR WHERE CODVENTA = " & VCodVenta & " "
                    conexion = ser.Abrir()
                    Consultas.ConsultaComando(conexion, consulta)

                    conexion.Close()
                    FACTURACOBRARTableAdapter.Fill(DsFacturacionCompleja.FACTURACOBRAR)
                Catch ex As Exception
                    MessageBox.Show("Error al Cancelar: " & ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            Else
                'FACTURACOBRARBindingSource.Clear()
                'FACTURACOBRARTableAdapter.Fill(DsFacturacionCompleja.FACTURACOBRAR)
                For i = 1 To GridViewCuotas.Rows.Count
                    GridViewCuotas.Rows.RemoveAt(GridViewCuotas.Rows.Count - 1)
                Next
            End If

            btnGenerarPagares.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCerrarMotivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarMotivo.Click
        PanelMotivoAnulacion.Visible = False
        'BtnAnular.Enabled = False
    End Sub

    Private Sub BtnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        VENTASBindingSource.RemoveFilter()
        tsFiltroFechaE.Text = "" : tsFiltroRDesde.Text = "" : tsFiltroRHasta.Text = "" : tsFiltroNroCliente.Text = ""

        If Config1 = "Con todas las Sucursales" Then
            VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
        Else
            VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
        End If

        lblDGVCant.Text = "Cant. de Items:" & GridViewFacturacion.RowCount
        tipocomp2 = f.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)
        lblProximoNro_Click(Nothing, Nothing)

        PintarCeldas()
    End Sub

    Private Sub BtnGeneraCuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGeneraCuotas.Click
        If GridViewCuotas.Rows.Count > 0 Then
            MessageBox.Show("Cancele las cuotas para volver a generar", "RIA")
            Exit Sub
        End If
        If String.IsNullOrEmpty(TxtCantCuotas.Text) Then
            MessageBox.Show("Ingrese una cantidad de cuota correcta", "RIA")
            TxtCantCuotas.Focus()
            Exit Sub
        ElseIf CDec(TxtCantCuotas.Text) = 0 Then
            MessageBox.Show("Ingrese una cantidad mayor a cero", "RIA")
            TxtCantCuotas.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(TxtPeriodo.Text) Then
            MessageBox.Show("Ingrese una cantidad de dias correcta", "RIA")
            TxtPeriodo.Focus()
            Exit Sub
        ElseIf CDec(TxtPeriodo.Text) = 0 Then
            MessageBox.Show("Ingrese una cantidad mayor a cero", "RIA")
            TxtPeriodo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(TotalVentaTextBox.Text) Then
            MessageBox.Show("No se ingresaron items detalles para calcular la cuota", "RIA")
            Exit Sub
        ElseIf CDec(TotalVentaTextBox.Text) = 0 Then
            MessageBox.Show("No se ingresaron items detalles para calcular la cuota", "RIA")
            Exit Sub
        End If
        GeneraCuotas()
        BtnGuardarCuotas.Focus()
        btnGenerarPagares.Enabled = True
    End Sub
    Dim SucNro As Integer = 0
    Public Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

        Dim Aprovperm As Double = PermisoAplicado(UsuCodigo, 201)
        permiso = PermisoAplicado(UsuCodigo, 29)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para aprobar una venta", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Dim IsProducto As Integer
            Dim SinStock As Double
            Dim CodProductoVenta, CodCodigo, CantidadVenta, CantidadDeposito, TextStock As String
            Dim ExsitePresupuesto As Integer = 0
            Dim CodPresupuesto As Integer = 0
            Me.Cursor = Cursors.AppStarting

            '---------------------------- VERIFICACIONES ----------------------------
            '-------- SI LOS PRODUCTOS EXISTENTES EN LA GRILLA DE VENTAS DETALLES TIENEN STOCK PARA PODER HACER LA APROBACION DE LA FACTURA
            '-------- CASO CONTRARIO NO DEBEMOS DEJAR APROBAR
            Dim c As Integer = DetalleVentaGridView.RowCount

            pbarEstadoVentas.Value = 40
            SinStock = 0 : TextStock = ""

            For c = 1 To c
                CodProductoVenta = DetalleVentaGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
                CantidadVenta = DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                CodCodigo = DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value

                'SE DEBE VERIFICAR QUE NO SEA UN SERVICIO
                IsProducto = w.FuncionConsulta("SERVICIO", "PRODUCTOS", "CODPRODUCTO", CodProductoVenta)

                If IsProducto <> 1 Then
                    CantidadDeposito = w.FuncionConsultaString("STOCKACTUAL", "STOCKDEPOSITO", "CODDEPOSITO = " & CmbSucursal.SelectedValue & " AND CODCODIGO", CodCodigo)
                    If CDec(CantidadVenta) > CDec(CantidadDeposito) Then
                        SinStock = 1
                        TextStock = TextStock + "- " & DetalleVentaGridView.Rows(c - 1).Cells("ProductoGrilla").Value + " Cantidad Venta : " + FormatNumber(CantidadVenta, 0) + " Cantidad Stock:" + FormatNumber(CantidadDeposito, 0) & vbCrLf
                    End If
                End If
            Next

            If SinStock = 1 Then
                If (VenderMasQueStock = 0) Or (Config10 = "Mostrar Panel de Productos Sin Stock") Then
                    pnlSinStock.Visible = True
                    pnlSinStock.BringToFront()
                    tbxMsgSinStock.Text = TextStock
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

            If CmbTipoVenta.Text = "Contado" Then
                If Not IsDBNull(GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value) Then
                    If GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value = 1 And Aprovperm = 1 Then
                        tsDuplicarFactura_Click(Nothing, Nothing) 'Duplicamos el contenido seleccionado y nos posicionamos sobre el mismo
                    End If
                End If
            End If

            If TipoComprobanteComboBox.SelectedValue = Nothing Then
                MessageBox.Show("Seleccione un Tipo de Comprobante", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If


        '---------------------------- VERIFICACIONES DE COMPROBANTES ----------------------------




        Dim drdetpc As DataRow
        Dim dadetpc As New SqlDataAdapter("SELECT dbo.TIPOCOMPROBANTE.CODCOMPROBANTE, dbo.TIPOCOMPROBANTE.NROLINEASDETALLE, dbo.TIPOCOMPROBANTE.FORMAIMPRESION, dbo.DETPC.IMPRIMIR, " & _
        "dbo.TIPOCOMPROBANTE.NOREGCOBRO, dbo.DETPC.FECHAVALIDEZ, dbo.DETPC.RANGO2, dbo.DETPC.ULTIMO, dbo.TIPOCOMPROBANTE.VALORFISCAL, " & _
        "dbo.DETPC.IMPRESORA, dbo.DETPC.TIMBRADO, dbo.SUCURSAL.SUCURSALTIMBRADO " & _
        "FROM dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN " & _
        "dbo.SUCURSAL ON dbo.DETPC.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL  WHERE dbo.DETPC.RANDOID = " & TipoComprobanteComboBox.SelectedValue & "", ser.CadenaConexion)

        Dim dtdetpc As New DataTable
        dadetpc.Fill(dtdetpc)
        drdetpc = dtdetpc.Rows(0)

        CodRangoGral = TipoComprobanteComboBox.SelectedValue
        SucNro = drdetpc("SUCURSALTIMBRADO")
        TimbradoFactura = drdetpc("TIMBRADO")
        hastanro = drdetpc("RANGO2")
        ultimo = drdetpc("ULTIMO")
        fechavalidez = drdetpc("FECHAVALIDEZ")
        Cantlinea = drdetpc("NROLINEASDETALLE")
        TipoImpresion = drdetpc("FORMAIMPRESION")
        Imprimir = drdetpc("IMPRIMIR")
        ValorFiscal = drdetpc("VALORFISCAL")
        impresora = drdetpc("IMPRESORA")
        Try
            NoRegistrarCobro = drdetpc("NOREGCOBRO")
        Catch ex As Exception

        End Try


        If TipoComprobanteComboBox.SelectedValue = Nothing Or CmbSucursal.SelectedValue = Nothing Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") No ha seleccionado el tipo de comprobante o sucursal " + Chr(13)
        End If

        If fechavalidez = Nothing Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Este comprobante no posee fecha de validez, porfavor modifique en Rangos de Comprobantes " + Chr(13)
        End If

        If Today > CDate(fechavalidez) Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") El comprobante ya ha superado su fecha de validez en fecha: " & fechavalidez & " " + Chr(13)
        End If

        If hastanro = ultimo Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") El rango de comprobante ya alcanzó su último nro, actualize con nuevos rangos " + Chr(13)
        End If

        If DetalleVentaGridView.RowCount = 0 Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") No puede aprobar ni imprimir una factura sin detalles " + Chr(13)
        End If

        If (SucNro = 0) Or (SucNro = Nothing) Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") La Sucursal no Posee un Nro de Sucursal, Ingrese en Configuraciones -> Locales y Depositos -> Nro Suc " + Chr(13)
        End If

        If TimbradoFactura = 0 Or String.IsNullOrEmpty(TimbradoFactura) = True Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Comprobante no tiene mas Rango, cierre esta ventana y cargue lo en (Dashboard >> Configuración >> 'Rangos de Comprobantes') " + Chr(13)
        End If

        If NroError <> 0 Then
            MessageBox.Show("Faltaron datos para completar el proceso de guardado. Favor revise estos items antes de seguir:  " + Chr(13) + MensajesError, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Metodo()


    End Sub

    Private Sub Continuar()
        If CmbTipoVenta.Text = "Contado" Then

            AprobarCheck()
            pbarEstadoVentas.Value = 0
            DeshabilitaControles()
            lblProximoNro_Click(Nothing, Nothing)

        ElseIf CmbTipoVenta.Text = "Crédito" Then
            Me.FACTURACOBRARTableAdapter.Fill(DsFacturacionCompleja.FACTURACOBRAR)
            btnCambiarTipoVenta.Visible = False
            PanelCuota.Visible = True
            PanelCuota.BringToFront()

            BtnGeneraCuotas.Enabled = True
            BtnCancelarCuota.Enabled = True
            BtnGuardarCuotas.Enabled = True
            TxtCantCuotas.Enabled = True
            TxtPeriodo.Enabled = True

            'TxtCantCuotas.Text = 1
            TxtCantCuotas.Text = cantcuotascli
            If cantcuotascli = "" Or cantcuotascli = 0 Or cantcuotascli Is Nothing Then
                TxtCantCuotas.Text = 1
            End If

            If diasvtocli = "" Or diasvtocli = 0 Or diasvtocli Is Nothing Then
                TxtPeriodo.Text = ""
            Else
                TxtPeriodo.Text = diasvtocli
            End If

            Dim fecha As Date
            fecha = dtpFechaHora.Text
            fecha = fecha.ToString("dd/MM/yyy")
            Dim varFecha As String
            varFecha = DateAdd(DateInterval.Day, CDec(diasvtocli), fecha)
            dttFechaPrimeraCuota.Text = varFecha
            TxtCantCuotas.Focus()
            pbarEstadoVentas.Value = 0

            If Config3 = "Simplificar Cuotas" Then
                BtnGeneraCuotas_Click(Nothing, Nothing)
                BtnGuardarCuotas.Focus()
            End If
        End If


        'Insertamos en la Tabla Comentarios
        If CmbEvento.Text <> "" Then
            InsertarProyecto("Factura de Venta Nro " & NroFacturaLabel.Text, CmbEvento.SelectedValue())
        End If

        PintarCeldas()
        Me.Cursor = Cursors.Arrow

        BtnImprimir.Image = My.Resources.ApproveActive
    End Sub
    Private Sub Metodo()
        If CmbMetodo.Text = "Avanzado" Then
            pnlNroRemision.Enabled = True
            pnlNroRemision.Visible = True
            btnContinuarRemision.Enabled = True
            tbxFactNroRemision.Text = ""
            pnlNroRemision.BringToFront()
            tbxFactNroRemision.Focus()
        Else
            tbxFactNroRemision.Text = ""
            Continuar()
        End If
    End Sub

    Private Sub AprobarCheck()
        Dim IsPresupuesto As Integer = 0
        pbarEstadoVentas.Value = 20
        btAprobado = 1 : btAnulado = 0

        If Not IsDBNull(GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value) Then
            If GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value = 1 Then
                IsPresupuesto = 1
            End If
        End If

        '---------------------------- OBTENEMOS NRO DE COMPROBANTE ----------------------------
        'Antes de generar un nro de factura debemos verificar que no se halla cargado de forma manual dicho nro.
        NumVentaV = ""
        If (NroFacturaLabel.Text <> "") And (NroFacturaLabel.Text <> "Pend. de Aprob.") Then
            NumVentaV = NroFacturaLabel.Text
            NroManual = 1
        End If
        If NumVentaV = "" Or NumVentaV = Nothing Or IsPresupuesto = 1 Then
            CalculaNroFactura("NO") 'Se calcula el Nro de factura a Generar de forma automatica
            NroManual = 0
        End If
        NumVentaContabilidad = NumVentaV

        '---------------------------- IMPRIMIMOS ----------------------------
        Try
            pbarEstadoVentas.Value = 60
            If TipoImpresion = 0 Then   'Formato Ticket
                If Imprimir = 1 Then 'Se imprime
                    If ValorFiscal = 0 Then 'Ticket
                        ImprimirTicket()
                    ElseIf ValorFiscal = 1 Then 'Factura
                        ImprimirFactura()
                    End If
                End If
            ElseIf TipoImpresion = 1 Then 'Formato Impresora
                If Imprimir = 1 Then 'Se imprime
                    ImprimirReporte()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al imprimir, no existe la impresora ", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

        '---------------------------- QUEMAMOS ----------------------------
        'Una ves impreso el documento y no haber error de impresion guardamos en la base de datos el nro de factura
        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction

        conexion = ser.Abrir()

        Try
            consulta = "UPDATE VENTAS SET ESTADO = 1, CODPRESUPUESTO = 0, NUMVENTA ='" & NumVentaV & "' WHERE  CODVENTA =" & Me.VCodVenta & ""

            If NroManual = 0 Then
                ultimo = ultimo + 1
                consulta = consulta + " UPDATE DETPC SET ULTIMO = " & ultimo & " where RANDOID=" & CodRangoGral & ""
            End If

            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            Consultas.ConsultaComando(myTrans, consulta)
            myTrans.Commit()
        Catch ex As Exception
            MessageBox.Show("Algo no funcionó al General el Nro de Factura", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

        '---------------------------- APROBAMOS Y DESCUENTA STOCK ----------------------------
        Try
            pbarEstadoVentas.Value = 80
            Aprobar() 'Aprueba,Inserta en cuentacliente y descuenta stock si es simplificado
        Catch ex As Exception
        End Try

        '------------------------------------------------------------------- CONTABILIDAD --------------------------------------------------------
        Try
            'Obtenemos los valores que se utilizaron el modulo de contabilidad - by Yolanda Zelaya 
            Dim ConceptoAsiento, Timbrado, IVA5, IVA10, IVAEXE, TOTALIVA, ClienteProveedor, TOTALVENTACONT As String
            Dim RgMerc, RgMonet As Integer

            pbarEstadoVentas.Value = 100
            If (CmbMoneda.SelectedValue <> 1) Then
                IVA5 = Math.Round((CDbl(Iva5TextBox1.Text) * CDbl(Cot1FactTextBox.Text)), cantdecimales)
                IVA10 = Math.Round((CDbl(Iva10TextBox1.Text) * CDbl(Cot1FactTextBox.Text)), cantdecimales)
                IVAEXE = Math.Round((CDbl(TotalExentaMaskedEdit.Text) * CDbl(Cot1FactTextBox.Text)), cantdecimales)
                TOTALIVA = Math.Round((CDbl(Iva5TextBox1.Text) * CDbl(Cot1FactTextBox.Text)), cantdecimales) + Math.Round((CDbl(Iva10TextBox1.Text) * CDbl(Cot1FactTextBox.Text)), cantdecimales)
                TOTALVENTACONT = Math.Round((CDbl(TotalVentaTextBox.Text) * CDbl(Cot1FactTextBox.Text)), cantdecimales)
                ClienteProveedor = CmbCliente.SelectedValue
            Else
                IVA5 = Iva5TextBox1.Text
                IVA10 = Iva10TextBox1.Text
                IVAEXE = TotalExentaMaskedEdit.Text
                TOTALIVA = IVA5 + IVA10
                TOTALVENTACONT = TotalVentaTextBox.Text
                ClienteProveedor = CmbCliente.SelectedValue
            End If

            If CmbTipoVenta.Text = "Contado" Then
                RgMonet = 1
            ElseIf CmbTipoVenta.Text = "Crédito" Then
                RgMonet = 2
            End If
            If CmbMetodo.Text = "Simplificado" Then
                RgMerc = 1
            ElseIf CmbMetodo.Text = "Avanzado" Then
                RgMerc = 2
            End If

            Timbrado = f.FuncionConsulta("TIMBRADO", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)
            If Cot1FactTextBox.Text = "" Or Cot1FactTextBox.Text = "0,00" Then
                Cotizacion1V = "1"
            Else
                Cotizacion1V = Cot1FactTextBox.Text
            End If

            ConceptoAsiento = "Factura de Venta " & CmbTipoVenta.Text & " / " & CmbCliente.Text
            ReglaContable(IVAEXE, IVA5, IVA10, TOTALIVA, "VENTAS", CDec(VCodVenta), "CODVENTA", ConceptoAsiento, RgMerc, RgMonet, _
                          CmbMoneda.SelectedValue, Cotizacion1V, NumVentaContabilidad, dtpFechaHora.Text, TOTALVENTACONT, "8", Timbrado, ClienteProveedor, SucCodigo)

        Catch ex As Exception

        End Try

        '---------------------------- DESACTIVA RANGO ----------------------------
        'Verificamos si es el ultimo Nro del rango de comprobantes y ponemos como desabilitado dicho rango 'SE CONSULTA ULTIMO OTRA VEZ PORQUE SE ACABA DE QUEMAR UNO NUEVO

        If hastanro = ultimo Then
            conexion = ser.Abrir()
            Try
                consulta = "UPDATE DETPC SET ACTIVO=0 WHERE RANDOID =" & CodRangoGral & ""
                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
            Catch ex As Exception
            End Try
        End If


        '-------------------------------------------------------------------------------------------------------------------------------------------
        'Verificamos si la venta fue al contado, entonces debemos abrir el panel de Cobros con todos los datos de la Venta
        'Abrimos cobros
        If CmbTipoVenta.Text = "Contado" And Config6 = "Mostrar automaticamente" Then
            CobroV2.Show()
            CobroV2.NuevoPictureBox_Click(Nothing, Nothing)
            CobroV2.CmbCliente.SelectedValue = CmbCliente.SelectedValue
            CobroV2.FACTURAACOBRARTableAdapter1.Fill(CobroV2.DsCobros2.FACTURAACOBRAR, CobroV2.CmbCliente.SelectedValue)

            For i = 0 To CobroV2.dgvFacturasaCobar.Rows.Count - 1
                If CobroV2.dgvFacturasaCobar.Rows(i).Cells("CODVENTA").Value = CInt(Me.VCodVenta) Then
                    CobroV2.dgvFacturasaCobar.Rows(i).Cells("Cobrar").Value = True
                    i = CobroV2.dgvFacturasaCobar.Rows.Count - 1 ' Ya encontro, entonces corta el Loop
                End If
            Next

            CobroV2.dgvFacturasaCobar_CellContentClick(Nothing, Nothing)
            CobroV2.splitCobros.BringToFront()
            CobroV2.tbxMonto.Focus()
            CobroV2.panelactivo = "SplitCobros"

            CobroV2.PagosActivo.Image = My.Resources.PaymentActive
            CobroV2.PagosActivo.Cursor = Cursors.Arrow
            CobroV2.FiltroPagosActivo.Image = My.Resources.User
            CobroV2.FiltroPagosActivo.Cursor = Cursors.Hand
            CobroV2.TipoCobroPictureBox.Image = My.Resources.Cuenta
            CobroV2.TipoCobroPictureBox.Cursor = Cursors.Hand
            CobroV2.PendientesPago.Image = My.Resources.Create
            CobroV2.PendientesPago.Cursor = Cursors.Hand

            CobroV2.dgvCobros.Enabled = True : CobroV2.BtnFiltro.Enabled = True : CobroV2.BuscarTextBox.Enabled = True
            CobroV2.PictureBox2.Visible = True : CobroV2.BuscarTextBox.Visible = True : CobroV2.NuevoPictureBox.Visible = True
            CobroV2.EliminarPictureBox.Visible = True : CobroV2.ModificarDetPictureBox.Visible = True : CobroV2.CancelarPictureBox.Visible = True
            CobroV2.ConfirmarPictureBox.Visible = True

            CobroV2.CodigoVenta = CInt(Me.VCodVenta)

            CobroV2.tbxMonto.Text = CDec(Me.TotalVentaTextBox.Text) '* CDec(Cot1FactTextBox.Text)
            CobroV2.lblMontoSelecionado.Text = CDec(Me.TotalVentaTextBox.Text) '* CDec(Cot1FactTextBox.Text)
            CobroV2.pnlFacturasaCobrar.Visible = False

            CobroV2.dtpRegFechaCobro.Text = dtpFechaHora.Text
            CobroV2.dtpRegFechaCobro.Focus()

            CobroV2.lblACobrar2.Visible = True
            CobroV2.lblMontoSelec2.Text = FormatNumber(CobroV2.lblMontoSelecionado.Text, 0)
            CobroV2.lblMontoSelec2.Visible = True
        End If
    End Sub

    Private Sub Totallizadordeticket()
        Dim numero As System.Decimal
        Dim mascara As System.String
        mascara = "######0.0###"

        If Decimal.TryParse(TotalExentaMaskedEdit.Text, numero) Then
            TotalExentaV = numero.ToString(mascara)
            TotalExentaV = Replace(TotalExentaV, ",", ".")
        Else
            TotalExentaV = "0"
        End If

        If Decimal.TryParse(TotalGravadaMaskedEdit.Text, numero) Then
            TotalGravadaV = numero.ToString(mascara)
            TotalGravadaV = Replace(TotalGravadaV, ",", ".")
        Else
            TotalGravadaV = "0"
        End If

        If Decimal.TryParse(TotalIvaVentaMaskedEdit.Text, numero) Then
            TotalIvaV = numero.ToString(mascara)
            TotalIvaV = Replace(TotalIvaV, ",", ".")
        Else
            TotalIvaV = "0"
        End If

        If Decimal.TryParse(Iva10TextBox1.Text, numero) Then
            Total10 = numero.ToString(mascara)

            Total10 = Replace(Total10, ",", ".")
        Else
            Total10 = "0"
        End If


        If Decimal.TryParse(Iva5TextBox1.Text, numero) Then
            Total5 = numero.ToString(mascara)
            Total5 = Replace(Total5, ",", ".")
        Else
            Total5 = "0"
        End If

    End Sub

    Private Sub ImprimirFactura()
        'ds.Clear()
        Dim ticket As New BarControlsCompleto.Ticket
        Dim diez, cinco, exento, totalcinco, totaldiez, totalexento, total, TotalItems5, TotalItems10, TotalItemsExento As Decimal

        diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0 : TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0

        '#########################################################################################################################
        Dim Codigo, DescripcionProducto, Cantidad, Precio, Subtotallinea, IvaTicket, Cliente, DVCliente As String
        Dim Empresa, RucEmpresa, Sucursal, DirSuc, CiudadSuc, TelSuc, FechaValidez As String

        Codigo = "" : DescripcionProducto = "" : Cantidad = "" : Precio = "" : Subtotallinea = "" : IvaTicket = "" : DVCliente = ""
        Empresa = "" : RucEmpresa = "" : Sucursal = "" : DirSuc = "" : CiudadSuc = "" : TelSuc = "" : TimbradoFactura = "" : FechaValidez = ""

        Dim CodCiudad As Integer
        '###################Traer Datos de Sucursal,Empresa y Cliente##############################################################################
        Try
            RucEmpresa = w.FuncionConsultaString2("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)
            DirSuc = w.FuncionConsultaString2("DIRECCION", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            TelSuc = w.FuncionConsultaString2("TELEFONO", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            CodCiudad = w.FuncionConsulta("CODCIUDAD", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            CiudadSuc = w.FuncionConsultaString2("DESCIUDAD", "CIUDAD", "CODCIUDAD", CodCiudad)

            TimbradoFactura = f.FuncionConsulta("TIMBRADO", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)
            FechaValidez = f.FuncionConsultaString2("FECHAVALIDEZ", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)

            Cliente = CmbCliente.Text

            Try
                DVCliente = w.FuncionConsultaString2("DV", "CLIENTES", "CODCLIENTE", CmbCliente.SelectedValue)
                If DVCliente = Nothing Then
                    DVCliente = ""
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
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
        ticket.AddHeaderLine("FAC. " & CmbTipoVenta.Text.ToUpper & " Nº" + NroFacturaLabel.Text)
        ticket.AddHeaderLine("TIMBRADO:" + TimbradoFactura)
        ticket.AddHeaderLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        ticket.AddHeaderLine("I.V.A Incluido")

        '##########################################################
        ticket.AddSubHeaderLine("FECHA/HORA:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
        ticket.AddSubHeaderLine("CAJA Nº:" + NumeroCaja + "  " + "CAJERO:" + UsuNombre)
        '##########################################################

        Dim c As Integer = DetalleVentaGridView.RowCount()
        For i = 1 To c
            DescripcionProducto = DetalleVentaGridView.Rows(i - 1).Cells("ProductoGrilla").Value
            If DescripcionProducto.Count <= 8 Then
            Else
                DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)
            End If

            Codigo = DetalleVentaGridView.Rows(i - 1).Cells("CodigoGrilla").Value
            If Codigo.Count <= 5 Then
            Else
                Codigo = Codigo.Remove(0, Codigo.Count - 5)
            End If

            Cantidad = DetalleVentaGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
            Precio = DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value

            Dim IVA As Decimal
            If i > c Then

            Else
                IVA = DetalleVentaGridView.Rows(i - 1).Cells("IVADataGridViewTextBoxColumn").Value

                If IVA = 10 Then
                    Subtotallinea = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    diez = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value - DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value / 1.1, 2)

                    totaldiez = totaldiez + diez
                    total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    TotalItems10 = TotalItems10 + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    TotalItems10 = Math.Round(TotalItems10, 0)
                    IvaTicket = "10"
                ElseIf IVA = 0 Then
                    Subtotallinea = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    exento = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    totalexento = totalexento + exento
                    total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                    TotalItemsExento = TotalItemsExento + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    TotalItemsExento = Math.Round(TotalItemsExento, 0)
                    IvaTicket = "0"
                ElseIf IVA = 5 Then
                    Subtotallinea = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    cinco = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value - DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value / 1.1

                    totalcinco = totalcinco + cinco
                    total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    TotalItems5 = TotalItems5 + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    TotalItems5 = Math.Round(TotalItems5, 0)
                    IvaTicket = "5"
                End If
            End If

            Precio = Replace(Precio, ".", "")
            Precio = FormatNumber(Precio, 0)
            Subtotallinea = Replace(Subtotallinea, ".", "")
            Subtotallinea = FormatNumber(Subtotallinea, 0)
            ticket.AddItem(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(4), "", Precio.PadLeft(6) & " " & Subtotallinea.PadLeft(6))
        Next

        Totallizadordeticket()
        '##########################################################
        ticket.AddTotal("       TOTAL VENTA :", FormatNumber(TotalVentaV, 0))
        ticket.AddTotal("       RECIBIDO Gs.:", "0")
        ticket.AddTotal("       VUELTO   Gs.:", "0")
        ticket.AddTotal("", "")
        ticket.AddTotal("===============================", "=")

        Total10 = Replace(Total10, ".", ",")
        Total5 = Replace(Total5, ".", ",")
        TotalExentaV = Replace(TotalExentaV, ".", ",")

        ticket.AddTotal("TOTAL GRAVADA 10% Gs.:", TotalItems10.ToString)
        ticket.AddTotal("TOTAL GRAVADA 5%  Gs.:", TotalItems5.ToString)
        ticket.AddTotal("TOTAL EXENTAS     GS.:", TotalExentaV.ToString)
        ticket.AddTotal("===============================", "=")
        ticket.AddTotal("LIQUIDACION DEL IVA", "")
        ticket.AddTotal("IVA 10% Gs.:", Total10)
        ticket.AddTotal("IVA 5%  Gs.:", Total5)
        ticket.AddTotal("===============================", "=")
        '##########################################################
        ticket.AddFooterLine("CANTIDAD DE ARTICULOS:" + c.ToString)
        If DVCliente = "0" Or DVCliente = "" Then
            DVCliente = ""
        Else
            DVCliente = "-" + DVCliente
        End If
        ticket.AddFooterLine("RUC CLIENTE:" + RUCClienteTextBox.Text + DVCliente)
        ticket.AddFooterLine("CLIENTE:" + CmbCliente.Text)
        ticket.AddFooterLine("")
        ticket.AddFooterLine("================================")
        ticket.AddFooterLine("")
        ticket.AddFooterLine("*****GRACIAS POR SU COMPRA******")

        Try
            ticket.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "RIA")
        End Try
    End Sub

    Private Sub ImprimirTicket()
        'ds.Clear()
        Dim ticket As New BarControlsCompleto.Ticket
        Dim diez, cinco, exento, totalcinco, totaldiez, totalexento, total, TotalItems5, TotalItems10, TotalItemsExento As Decimal

        diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0
        TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0
        '#########################################################################################################################
        Dim Codigo, DescripcionProducto, Cantidad, Precio, Subtotallinea, IvaTicket, Cliente, DVCliente As String
        Dim Empresa, RucEmpresa, Sucursal, DirSuc, CiudadSuc, TelSuc, FechaValidez As String
        Codigo = "" : DescripcionProducto = "" : Cantidad = "" : Precio = "" : Subtotallinea = "" : IvaTicket = "" : DVCliente = ""
        Empresa = "" : RucEmpresa = "" : Sucursal = "" : DirSuc = "" : CiudadSuc = "" : TelSuc = "" : TimbradoFactura = "" : FechaValidez = ""

        Dim CodCiudad As Integer
        '###################Traer Datos de Sucursal,Empresa y Cliente##############################################################################
        Try
            RucEmpresa = w.FuncionConsultaString2("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)
            DirSuc = w.FuncionConsultaString2("DIRECCION", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            TelSuc = w.FuncionConsultaString2("TELEFONO", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            CodCiudad = w.FuncionConsulta("CODCIUDAD", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            CiudadSuc = w.FuncionConsultaString2("DESCIUDAD", "CIUDAD", "CODCIUDAD", CodCiudad)

            TimbradoFactura = f.FuncionConsulta("TIMBRADO", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)
            FechaValidez = f.FuncionConsultaString("FECHAVALIDEZ", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)
            Cliente = CmbCliente.Text

            Try
                DVCliente = w.FuncionConsultaString2("DV", "CLIENTES", "CODCLIENTE", CmbCliente.SelectedValue)
                If DVCliente = Nothing Then
                    DVCliente = ""
                End If
            Catch ex As Exception
            End Try

        Catch ex As Exception
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

        ticket.AddHeaderLine("TICKET Nº" + NroFacturaLabel.Text)
        ticket.AddHeaderLine("TIMBRADO:" + TimbradoFactura)
        ticket.AddHeaderLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        '##########################################################
        ticket.AddSubHeaderLine("FECHA/HORA:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
        ticket.AddSubHeaderLine("CAJA Nº:" + NumeroCaja + "  " + "CAJERO:" + UsuNombre)
        '##########################################################

        Dim c As Integer = DetalleVentaGridView.RowCount()
        For i = 1 To c
            DescripcionProducto = DetalleVentaGridView.Rows(i - 1).Cells("ProductoGrilla").Value
            If DescripcionProducto.Count <= 8 Then
            Else
                DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)
            End If

            Codigo = DetalleVentaGridView.Rows(i - 1).Cells("CodigoGrilla").Value
            If Codigo.Count <= 5 Then
            Else
                Codigo = Codigo.Remove(0, Codigo.Count - 5)
            End If

            Cantidad = DetalleVentaGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
            Precio = DetalleVentaGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value

            Dim IVA As Decimal
            If i > c Then

            Else
                IVA = DetalleVentaGridView.Rows(i - 1).Cells("IVADataGridViewTextBoxColumn").Value

                If IVA = 10 Then
                    Subtotallinea = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    diez = FormatNumber(DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value - DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value / 1.1, 2)

                    totaldiez = totaldiez + diez
                    total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                    TotalItems10 = TotalItems10 + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                    IvaTicket = "10"
                ElseIf IVA = 0 Then
                    Subtotallinea = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    exento = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    totalexento = totalexento + exento
                    total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value

                    TotalItemsExento = TotalItemsExento + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    IvaTicket = "0"
                ElseIf IVA = 5 Then
                    Subtotallinea = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    cinco = DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value - DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value / 1.1

                    totalcinco = totalcinco + cinco
                    total = total + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    TotalItems5 = TotalItems5 + DetalleVentaGridView.Rows(i - 1).Cells("Subtotal").Value
                    IvaTicket = "5"
                End If
            End If

            Precio = Replace(Precio, ".", "")
            Precio = FormatNumber(Precio, 0)
            Subtotallinea = Replace(Subtotallinea, ".", "")
            Subtotallinea = FormatNumber(Subtotallinea, 0)
            ticket.AddItem(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(4), "", Precio.PadLeft(6) & " " & Subtotallinea.PadLeft(6))
        Next
        Totallizadordeticket()
        '##########################################################
        ticket.AddTotal("       TOTAL VENTA :", FormatNumber(TotalVentaV, 0))
        ticket.AddTotal("       RECIBIDO Gs.:", "0")
        ticket.AddTotal("       VUELTO   Gs.:", "0")
        ticket.AddTotal("", "")
        ticket.AddTotal("===============================", "=")

        ticket.AddFooterLine("CANTIDAD DE ARTICULOS:" + c.ToString)
        If DVCliente = "0" Or DVCliente = "" Then
            DVCliente = ""
        Else
            DVCliente = "-" + DVCliente
        End If
        ticket.AddFooterLine("RUC CLIENTE:" + RUCClienteTextBox.Text + DVCliente)
        ticket.AddFooterLine("CLIENTE:" + CmbCliente.Text)
        ticket.AddFooterLine("")
        ticket.AddFooterLine("================================")
        ticket.AddFooterLine("****Ticket sin validez fiscal***")
        ticket.AddFooterLine("*****GRACIAS POR SU COMPRA******")

        Try
            ticket.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "RIA")
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


    Private Sub BuscarProductoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProductosGridView.Focus()
        End If
    End Sub


    Private Sub BuscarProductoTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.GotFocus
        If BuscarProductoTextBox.Text = "Buscar..." Then
            BuscarProductoTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarProductoTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.LostFocus
        If BuscarProductoTextBox.Text = "" Then
            BuscarProductoTextBox.Text = "Buscar..."
        End If
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        If BuscarProductoTextBox.Text <> "Buscar..." Then
            Me.CODIGOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
        End If
    End Sub

    Private Sub BuscarTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.GotFocus
        BuscarTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.LostFocus
        BuscarTextBox.BackColor = Color.Tan
    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged
        Try
            Me.VENTASBindingSource.Filter = "NOMBRECLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR NUMVENTA LIKE '%" & BuscarTextBox.Text & "%'"
            lblDGVCant.Text = "Cant. de Items:" & GridViewFacturacion.RowCount

            PintarCeldas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalculaNroFactura(RangoAQuemar As String)
        Dim conexion As System.Data.SqlClient.SqlConnection
        conexion = ser.Abrir()
        Try
            Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString As String
            Dim NroDigitos As Integer

            NumSucursal = SucCodigo
            NumMaquina = NumMaquinaGlobal

            Dim drdetpc As DataRow
            If RangoAQuemar = "NO" Then
                Dim dadetpc As New SqlDataAdapter("SELECT dbo.DETPC.TIMBRADO, dbo.DETPC.NRODIGITOS, dbo.SUCURSAL.SUCURSALTIMBRADO, dbo.PC.NUMMAQUINA, dbo.DETPC.RANGO2, dbo.DETPC.ULTIMO FROM dbo.DETPC INNER JOIN dbo.SUCURSAL ON dbo.DETPC.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN dbo.PC ON dbo.DETPC.IP = dbo.PC.IP WHERE dbo.DETPC.RANDOID=" & TipoComprobanteComboBox.SelectedValue & "", conexion)
                Dim dtdetpc As New DataTable
                dadetpc.Fill(dtdetpc)
                drdetpc = dtdetpc.Rows(0)
            Else
                Dim dadetpc As New SqlDataAdapter("SELECT dbo.DETPC.TIMBRADO, dbo.DETPC.NRODIGITOS, dbo.SUCURSAL.SUCURSALTIMBRADO, dbo.PC.NUMMAQUINA,  dbo.DETPC.RANGO2, dbo.DETPC.ULTIMO FROM dbo.DETPC INNER JOIN dbo.SUCURSAL ON dbo.DETPC.CODSUCURSAL = dbo.SUCURSAL.CODSUCURSAL INNER JOIN dbo.PC ON dbo.DETPC.IP = dbo.PC.IP WHERE dbo.DETPC.RANDOID=" & RangoAQuemar & "", conexion)
                Dim dtdetpc As New DataTable
                dadetpc.Fill(dtdetpc)
                drdetpc = dtdetpc.Rows(0)
            End If

            'Validamos que haya rango para ese TipoComprobante
            NroRango = drdetpc("ULTIMO")
            NroRango = NroRango + 1

            NroRango2 = drdetpc("RANGO2")

            NroDigitos = drdetpc("NRODIGITOS")

            If CDec(NroRango) > CDec(NroRango2) Then
                NumVentaV = ""
                'supero el ultimo
                Exit Sub
            End If

            NumSucTimbrado = drdetpc("SUCURSALTIMBRADO")
            NumMaquina = drdetpc("NUMMAQUINA")

            NroRangoString = CStr(NroRango)
            For i = 1 To NroDigitos
                If Len(NroRangoString) = NroDigitos Then
                    Exit For
                Else
                    NroRangoString = "0" & NroRangoString
                End If
            Next

            NumVentaV = NumSucTimbrado & "." & NumMaquina & "." & NroRangoString
            NroFacturaLabel.Text = NumVentaV

            If NumVentaV = "" Then
                MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        btNuevo = 0 : btModificar = 0 : btcancelando = 1
        lblCredito.Visible = False : lblLimiteCredito.Visible = False : lblLimiteCredito.Text = "0"

        CmbCliente.BackColor = SystemColors.ControlLightLight
        CmbSucursal.BackColor = SystemColors.ControlLightLight
        TipoComprobanteComboBox.BackColor = SystemColors.ControlLightLight
        CmbTipoVenta.BackColor = SystemColors.ControlLightLight
        CmbMoneda.BackColor = SystemColors.ControlLightLight
        CmbSucursal.BackColor = SystemColors.ControlLightLight

        If NroFactText.Visible = True Then
            NroFactText.Visible = False
            NroFacturaLabel.Visible = True

            BtnGuardarP3.Visible = False
            BtnCancelarP3.Visible = False
            BtnNuevoP3.Visible = True
            BtnNuevoP3.Enabled = False
            Me.tsCargarNroFactura.Enabled = False
        End If

        CLIENTESBindingSource.RemoveFilter()
        VENTASBindingSource.CancelEdit()
        VENTASDETALLEBindingSource.CancelEdit()
        btcancelando = 0

        CancelarDetVentaButton_Click(Nothing, Nothing)

        FechaFiltro()
        If Config1 = "Con todas las Sucursales" Then
            VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
        Else
            VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
        End If

        RecorreDetalleVenta()
        DeshabilitaControles()

        'VERIFICAMOS QUE SI NO HAYA VENTAS EN LA GRILLA, QUE EL ESTADO SEA PENDIENTE
        If GridViewFacturacion.RowCount = 0 Then
            TxtEstado.Text = "0"
        End If

        PintarCeldas()
    End Sub

    Private Sub CantidadVentaMaskedEdit_GotFocus(sender As Object, e As System.EventArgs) Handles CantidadVentaMaskedEdit.GotFocus
        CantidadVentaMaskedEdit.BackColor = SystemColors.Highlight
    End Sub

    Private Sub CantidadVentaMaskedEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadVentaMaskedEdit.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxPrecioVenta.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbCliente_GotFocus(sender As Object, e As System.EventArgs) Handles CmbCliente.GotFocus
        CmbCliente.BackColor = SystemColors.Highlight
        PanelCliente = 0
    End Sub

    Private Sub CmbCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CmbCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbSucursal.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 42 Then
            PanelCliente = 1
            UltraPopupControlContainer1.PopupControl = GroupBoxCliente
            UltraPopupControlContainer1.Show()

            TxtBuscaCliente.Text = "" : TxtBuscaCliente.Focus()
            e.Handled = True
        End If
    End Sub


    Private Sub CmbCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCliente.LostFocus
        Dim objCommand As New SqlCommand
        RUC = ""


        CmbCliente.BackColor = SystemColors.ControlLightLight

        If PanelCliente = 0 Then
            If CmbCliente.Text <> "" Then

                objCommand.CommandText = "SELECT dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.TIPOVENTA, dbo.CLIENTES.CODVENDEDOR, dbo.CLIENTES.NOMBREFANTASIA, dbo.CLIENTES.CODCLIENTE, " & _
                                        "dbo.CLIENTES.CODTIPOCLIENTE, dbo.PAIS.DESPAIS, dbo.CLIENTES.DIRECCION, dbo.ZONA.DESZONA, dbo.CIUDAD.DESCIUDAD, dbo.CLIENTES.RUC  FROM dbo.CLIENTES LEFT OUTER JOIN " & _
                                        "dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN dbo.CIUDAD ON dbo.CLIENTES.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                                        "dbo.PAIS ON dbo.CLIENTES.CODPAIS = dbo.PAIS.CODPAIS WHERE AUTORIZADO = 1 AND CODCLIENTE = " & CmbCliente.SelectedValue

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        'Tipo Cliente (Lista de Precio)
                        Try
                            codtipocliente = odrConfig("CODTIPOCLIENTE")
                        Catch
                        End Try

                        'Vendedor

                        If VendendorComboBox.SelectedValue Is Nothing Then
                            If IsDBNull(odrConfig("CODVENDEDOR")) Then
                                Try
                                    VendendorComboBox.SelectedValue = f.FuncionConsultaString("CODVENDEDOR", "VENDEDOR", "CODUSUARIO", UsuCodigo)
                                Catch ex As Exception
                                End Try
                            Else
                                VendendorComboBox.SelectedValue = odrConfig("CODVENDEDOR")
                            End If
                        End If



                        'Tipo de Venta Contado
                        Try
                            If odrConfig("TIPOVENTA") = 1 Then
                                CmbTipoVenta.Text = "Crédito"
                                TxTTipoVenta.Text = "1"
                            ElseIf odrConfig("TIPOVENTA") = 0 Then
                                CmbTipoVenta.Text = "Contado"
                                TxTTipoVenta.Text = "0"
                            End If
                        Catch
                        End Try

                        'Nombre de Fantasia y NumCliente
                        Try
                            TxtNumCliente.Text = odrConfig("NUMCLIENTE")
                            lblNombreFantasia.Visible = True : lblNombreFantasia.Text = odrConfig("NOMBREFANTASIA")
                            lblRucCliente.Visible = True : lblRucCliente.Text = odrConfig("RUC")
                            RUC = odrConfig("RUC")
                        Catch ex As Exception
                            lblRucCliente.Visible = True : lblRucCliente.Text = odrConfig("RUC")
                            RUC = odrConfig("RUC")
                        End Try

                        'Preguntamos si Desea Ver la LOCALIZACION o DIRECCION del Cliente

                        If Config4 = "Mostrar Localizacion del Cliente" Then
                            txtLocalizacion.Text = odrConfig("DESPAIS") + " / " + odrConfig("DESCIUDAD") + " / " + odrConfig("DESZONA")

                        ElseIf Config4 = "Mostrar Dirección del Cliente" Then
                            txtLocalizacion.Text = odrConfig("DIRECCION").ToString
                        End If

                    Loop

                Else

                    Dim ClienteDes As String = f.FuncionConsultaString("NOMBRE", "CLIENTES", "NUMCLIENTE", TxtNumCliente.Text)
                    If ClienteDes <> Nothing Then
                        MessageBox.Show("El Cliente : " & ClienteDes & "  se encuentra DESACTIVADO", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtNumCliente.Text = "" : TxtNumCliente.Focus() : CmbCliente.Text = ""
                        Exit Sub
                    End If
                End If

                odrConfig.Close()
                objCommand.Dispose()

            End If


            'Mostramos el limite de credito del cliente
            Dim LimiteCredito As Double = w.FuncionConsultaDecimal("LIMCREDITO", "CLIENTES", "NUMCLIENTE", TxtNumCliente.Text)
            If LimiteCredito <> "0,00" Then
                ' 2 - Verificamos el monto total del credito que tiene acumulado para verificar que no sobrepase su limite establecido
                Dim Saldo As Decimal = 0
                Saldo = w.FuncionConsultaDecimal("SUM(DEBE) - SUM(HABER)", "CLIENTESCUENTACORRIENTE", "CODVENTA IS NOT NULL AND CODCLIENTE", CmbCliente.SelectedValue)

                If Saldo = 0 Then 'Si tiene saldo cero debemos mostrar el total del limite del credito
                    Saldo = LimiteCredito
                Else
                    Saldo = LimiteCredito - Saldo
                End If

                lblCredito.Visible = True : lblLimiteCredito.Visible = True
                lblLimiteCredito.Text = FormatNumber(Saldo, 0)
            Else
                lblCredito.Visible = False : lblLimiteCredito.Visible = False
                lblLimiteCredito.Text = "0"
            End If

            'Verificamos si el cliente tiene un saldo a Favor (Anticipo de Dinero)
            Dim AnticipoCliente As Double = 0
            AnticipoCliente = w.FuncionConsultaDecimal("SUM(SALDOCUOTA) * - 1", "FACTURACOBRAR", "CODNUMEROCUOTA = 0 AND IDCLIENTE", CmbCliente.SelectedValue)

            If AnticipoCliente <> 0 Then
                lblAnticipo.Visible = True : lblAnticipoS.Visible = True
                lblAnticipoS.Text = FormatNumber(AnticipoCliente, 0)
            Else
                lblAnticipo.Visible = False : lblAnticipoS.Visible = False
            End If

        End If
    End Sub

    Private Sub CmbCriterioBusc_DropDownClosed(ByVal sender As Object, ByVal args As Telerik.WinControls.UI.RadPopupClosedEventArgs)
        apretoteclaabajoencombo = False
    End Sub

    Private Sub CmbEvento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEvento.GotFocus
        CmbEvento.BackColor = SystemColors.Highlight
    End Sub

    Private Sub CmbEvento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CmbEvento.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub CmbEvento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbEvento.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            apretoteclaabajoencombo = False
            CmbMetodo.Select()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbMetodo_GotFocus(sender As Object, e As System.EventArgs) Handles CmbMetodo.GotFocus
        CmbMetodo.BackColor = SystemColors.Highlight
    End Sub

    Private Sub CmbMetodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbMetodo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            apretoteclaabajoencombo = False
            tbxCodigoProducto.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbMoneda_GotFocus(sender As Object, e As System.EventArgs) Handles CmbMoneda.GotFocus
        CmbMoneda.BackColor = SystemColors.Highlight
    End Sub

    Private Sub CmbMoneda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CmbMoneda.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub CmbMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If IngresarCotCheckBox.Checked = True Then
                Cot1FactTextBox.Focus()
            Else
                CmbEvento.Focus()
            End If

        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbMoneda_LostFocus(sender As Object, e As System.EventArgs) Handles CmbMoneda.LostFocus
        CmbMoneda.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub CmbMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMoneda.SelectedIndexChanged
        If btNuevo = 1 Or btModificar = 1 Then
            TxtCodMoneda.Text = CmbMoneda.SelectedValue
            Dim SimboloEfectivo As String
            Dim drmoneda As DataRow
            If CmbMoneda.SelectedValue <> Nothing Then
                For i = 0 To dtmoneda.Rows.Count - 1
                    drmoneda = dtmoneda.Rows(i)
                    If CmbMoneda.SelectedValue = drmoneda("CODMONEDA") Then
                        cantdecimales = drmoneda("CANTIDADDECIMALES")
                        Cotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(CmbMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
                        DetalleVentaGridView.Columns("PRECIOVENTALISTADataGridViewTextBoxColumn").DefaultCellStyle.Format = "N" & cantdecimales
                        DetalleVentaGridView.Columns("SubTotal").DefaultCellStyle.Format = "N" & cantdecimales

                        Try
                            Cot1FactTextBox.Text = FormatNumber(CDec(Cotizacion.Text), 0)
                        Catch ex As Exception
                            Cot1FactTextBox.Text = 1
                        End Try

                        SimboloEfectivo = drmoneda("SIMBOLO")
                        Me.COTIZACIONTableAdapter.Fill(Me.DsFacturacionCompleja.COTIZACION, CmbMoneda.SelectedValue)
                        If SimboloEfectivo = "0" Then
                            SimCot1Label.Text = "Gs"
                        Else
                            SimCot1Label.Text = SimboloEfectivo
                        End If
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub CmbSucursal_GotFocus(sender As Object, e As System.EventArgs) Handles CmbSucursal.GotFocus
        CmbSucursal.BackColor = SystemColors.Highlight
    End Sub

    Private Sub CmbSucursal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CmbSucursal.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub CmbSucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbSucursal.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then

            TipoComprobanteComboBox.Select()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbTipoVenta_Click(sender As Object, e As System.EventArgs) Handles CmbTipoVenta.Click
        var = 1
    End Sub

    Private Sub CmbTipoVenta_GotFocus(sender As Object, e As System.EventArgs) Handles CmbTipoVenta.GotFocus
        CmbTipoVenta.BackColor = SystemColors.Highlight
    End Sub

    Private Sub CmbTipoVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbTipoVenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            apretoteclaabajoencombo = False
            dtpFechaHora.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbTipoVenta_LostFocus(sender As Object, e As System.EventArgs) Handles CmbTipoVenta.LostFocus
        CmbTipoVenta.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxCodigoProducto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxCodigoProducto.GotFocus
        tbxCodigoProducto.BackColor = SystemColors.Highlight

        If VenderMasQueStock = 0 Then
            Me.CODIGOSTableAdapter.Fill(Me.DsFacturacionCompleja.CODIGOS, CDec(CmbSucursal.SelectedValue), codtipocliente)
        Else
            Me.CODIGOSTableAdapter.FillSinStock(Me.DsFacturacionCompleja.CODIGOS, CDec(CmbSucursal.SelectedValue), codtipocliente)
        End If

    End Sub

    Private Sub TxtNumCliente_GotFocus(sender As Object, e As System.EventArgs) Handles TxtNumCliente.GotFocus
        TxtNumCliente.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxCodigoProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles tbxCodigoProducto.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Left Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub tbxCodigoProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCodigoProducto.KeyPress

        Dim KeyAscii As Short = Asc(e.KeyChar)
        ErrorCodigoLabel.Visible = False
        If KeyAscii = 42 Then
            CodCodigoTextBox.Text = ""
            CodComboTextBox.Text = ""

            UltraPopupControlContainer1.PopupControl = ProductosGroupBox
            UltraPopupControlContainer1.Show()

            CheckBox1.Checked = False
            BuscarProductoTextBox.Text = ""
            BuscarProductoTextBox.Focus()
            e.Handled = True
        End If

        If KeyAscii = 13 Then
            CantidadVentaMaskedEdit.Focus()
            Dim fx_Valor As Double = 0
            If IngresarCotCheckBox.Checked = True Then
                fx_Valor = Cotizacion.Text
            Else
                fx_Valor = Cot1FactTextBox.Text
            End If
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Cot1FactTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Then
            CmbMoneda.Select()
        End If
    End Sub

    Private Sub Cot1FactTextBox_KeyDown1(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Cot1FactTextBox.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub Cot1FactTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cot1FactTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxCodigoProducto.Select()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Cot2FactTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cot2FactTextBox.KeyDown
        If e.KeyCode = Keys.Up Then
            CmbMoneda.Select()
        End If
    End Sub

    Private Sub Cot2FactTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cot2FactTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbMetodo.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub DeshabilitaControles()
        pnlVentasCabecera.Enabled = False
        pnlVentasDetalle.Enabled = False

        GridViewFacturacion.Enabled = True
        BtnFiltro.Enabled = True
        CmbMes.Enabled = True
        CmbAño.Enabled = True
        BuscarTextBox.Enabled = True
        btnMostrarOBS.Enabled = True
        BtnNuevoP3.Enabled = False
        Me.tsCargarNroFactura.Enabled = True
        lblDGVCant.Text = "Cant. de Items:" & GridViewFacturacion.RowCount
    End Sub

    Private Sub Eliminar()
        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction

        Existe = w.FuncionConsulta("CODVENTA", "VENTAS", "CODVENTA", VCodVenta)

        If TxtEstado.Text = "1" Or TxtEstado.Text = "2" Then
            MessageBox.Show("Ventas ""Aprobadas"" o ""Anuladas"" No se pueden Eliminar", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Si es un presupuesto no debemos poder eliminar
        If Not IsDBNull(GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value) Then
            If GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value = 1 Then
                MessageBox.Show("Un Presupuesto ya Emitido no se puede Eliminar", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If MessageBox.Show("¿Esta seguro que quiere Eliminar la Venta?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Existe <> 0 Then
            conexion = ser.Abrir()

            Try
                consulta = ""

                If f.FuncionConsultaString("CODVENTA", "VENTASDETALLE", "CODVENTA", VCodVenta) <> 0 Then
                    consulta = consulta + "DELETE FROM VENTASDETALLE WHERE CODVENTA=" & CDec(VCodVenta) & "  "
                End If
                If f.FuncionConsultaString("CODVENTA", "FACTURACOBRAR", "CODVENTA", VCodVenta) <> 0 Then
                    consulta = consulta + "DELETE FROM FACTURACOBRAR WHERE CODVENTA=" & CDec(VCodVenta) & "  "
                End If
                If f.FuncionConsultaString("CODVENTA", "FACTURACOBRAR", "CODVENTA", VCodVenta) <> 0 Then
                    consulta = consulta + "DELETE FROM FACTURACOBRAR WHERE CODVENTA=" & CDec(VCodVenta) & "  "
                End If
                consulta = consulta + "DELETE FROM VENTAS WHERE CODVENTA=" & CDec(VCodVenta) & " "

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

                Try
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()
                Catch ex As SqlException
                    Try
                        myTrans.Rollback("Eliminar")
                    Catch

                    End Try
                    Throw ex
                Finally
                    myTrans.Dispose()
                End Try

                FechaFiltro()
                If Config1 = "Con todas las Sucursales" Then
                    VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
                Else
                    VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
                End If

                MessageBox.Show("Registro Eliminado Correctamente", "RIA", MessageBoxButtons.OK, MessageBoxIcon.None)
                DeshabilitaControles()

            Catch ex As SqlException

                Dim NroError As Integer = ex.Number
                Dim Mensaje As String = ex.Message

                If NroError = 547 Then
                    MessageBox.Show("La factura tiene relacion  otra tabla del Sistema, elimine primero la otra relación", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al Eliminar esta Venta", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Finally
                conexion.Close()

            End Try
        Else

        End If
        DeshabilitaControles()
    End Sub

    Private Sub EliminarDetVentaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarDetVentaButton.Click
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim c As Integer
        Dim W As New Funciones.Funciones
        c = DetalleVentaGridView.Rows.Count()
        If c = 0 Then
            Exit Sub
        End If

        Dim f As New Funciones.Funciones
        Dim existe As Integer

        If EliminarDetVentaButton.Text = "Cancelar" Then
            AgregarDetVentaButton.Text = "Agregar"
            EliminarDetVentaButton.Text = "Eliminar"
            VENTASDETALLEBindingSource.CancelEdit()
            CantidadVentaMaskedEdit.Text = ""
            tbxCodigoProducto.Text = ""
            tbxPrecioVenta.Text = ""
            DesProductoTextBox.Text = ""

            tbxCodigoProducto.Focus()
            Exit Sub
        End If

        If EliminarDetVentaButton.Text = "Eliminar" Then
            Try

                existe = W.FuncionConsulta("VentaDetalleID", "VENTASDETALLE", "VentaDetalleID", DetalleVentaGridView.CurrentRow.Cells("VentaDetalleID").Value.ToString)
            Catch ex As Exception

            End Try
            If existe > 0 Then
                Try

                    consulta = "DELETE FROM VENTASDETALLE WHERE VentaDetalleID=" & DetalleVentaGridView.CurrentRow.Cells("VentaDetalleID").Value & " "
                    Dim condicion As String
                    If IsDBNull(DetalleVentaGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                        condicion = "CODCOMBO=" & DetalleVentaGridView.CurrentRow.Cells("CODCOMBODataGridViewTextBoxColumn2").Value & " "
                    Else
                        condicion = "CODCODIGO =" & DetalleVentaGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn1").Value & " AND CODPRODUCTO=" & DetalleVentaGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value & ""
                    End If

                    conexion = ser.Abrir()

                    Try
                        Consultas.ConsultaComando(conexion, consulta)
                        DetalleVentaGridView.Rows.Remove(Me.DetalleVentaGridView.CurrentRow)
                    Finally
                        conexion.Close()
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Error al eliminar el detalle", "RIA")
                    Exit Sub
                End Try
            Else
                DetalleVentaGridView.Rows.Remove(Me.DetalleVentaGridView.CurrentRow)



            End If

            Dim sumaimpgrav10, sumaimpgrav5, sumaimpexe, SubTotal As Double
            sumaimpgrav10 = 0 : sumaimpgrav5 = 0 : sumaimpexe = 0 : SubTotal = 0

            Dim i As Integer
            For i = 0 To DetalleVentaGridView.RowCount - 1
                sumaimpgrav10 = sumaimpgrav10 + DetalleVentaGridView.Rows(i).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value
                sumaimpgrav5 = sumaimpgrav5 + DetalleVentaGridView.Rows(i).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value
                sumaimpexe = sumaimpexe + DetalleVentaGridView.Rows(i).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value
                SubTotal = SubTotal + DetalleVentaGridView.Rows(i).Cells("SubTotal").Value
            Next

            TotalGravado10V = sumaimpgrav10
            TotalGravado5V = sumaimpgrav5
            TotalGravadaV = sumaimpgrav10 + sumaimpgrav5
            TotalVentaV = sumaimpgrav10 + sumaimpgrav5 + sumaimpexe
            Total10 = CDec(sumaimpgrav10 / 11)
            Total5 = CDec(sumaimpgrav5 / 21)
            TotalExentaV = sumaimpexe
            TotalIvaV = CDec(Total10) + CDec(Total5)

            If CmbMoneda.SelectedValue = 1 Or CmbMoneda.SelectedValue = Nothing Then
                TotalVentaTextBox.Text = FormatNumber(TotalVentaV, 0)
            Else
                TotalVentaTextBox.Text = FormatNumber(TotalVentaV, cantdecimales)
            End If

            TotalIvaVentaMaskedEdit.Text = FormatNumber(TotalIvaV, cantdecimales)
            TotalGravadaMaskedEdit.Text = FormatNumber(TotalGravadaV, cantdecimales)
            TotalExentaMaskedEdit.Text = FormatNumber(TotalExentaV, cantdecimales)
            Iva10TextBox1.Text = FormatNumber(Total10, cantdecimales)
            Iva5TextBox1.Text = FormatNumber(Total5, cantdecimales)

        End If
    End Sub

    Private Sub EliminarDetVentaButton_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EliminarDetVentaButton.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Left Then
            AgregarDetVentaButton.Focus()
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 27)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para eliminar una venta", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Eliminar()
        End If
        'VERIFICAMOS QUE SI NO HAYA VENTAS EN LA GRILLA, QUE EL ESTADO SEA PENDIENTE
        If GridViewFacturacion.RowCount = 0 Then
            TxtEstado.Text = "0"
        End If
        lblDGVCant.Text = "Cant. de Items:" & GridViewFacturacion.RowCount
        PintarCeldas()
    End Sub

    Private Sub Facturacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub Facturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btNuevo = 0 : btModificar = 0 : btAprobado = 0 : btAnulado = 0 : GrillaModif = 0 : btcfcuota = 0 : PanelCliente = 0 : ControlarStock = 1 'Si controla el stock
        pnlNroRemision.Visible = False

        permiso = PermisoAplicado(UsuCodigo, 25)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para Abrir esta Ventana", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            ObtenerConfig()

            lblSimboloDesc.Visible = True

            Me.IVATableAdapter.Fill(Me.DsFacturacionCompleja.IVA)
            Me.CLIENTESTableAdapter.Fill(DsFacturacionCompleja.CLIENTES)
            Me.SUCURSALTableAdapter.Fill(DsFacturacionCompleja.SUCURSAL)

            Me.EVENTOTableAdapter.Fill(DsFacturacionCompleja.EVENTO)
            EVENTOBindingSource.RemoveFilter()

            Me.MONEDATableAdapter.Fill(DsFacturacionCompleja.MONEDA)
            Me.VENDEDORTableAdapter.Fill(DsFacturacionCompleja.VENDEDOR)

            dtmoneda = Me.MONEDATableAdapter.GetData()


            CmbAño.SelectedText = Today.Year.ToString
            CmbMes.SelectedIndex = Today.Month - 1

            FechaFiltro()


            If Config1 = "Con todas las Sucursales" Then
                TIPOCOMPROBANTETableAdapter.Fill(DsFacturacionCompleja.TIPOCOMPROBANTE)
                VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
                Me.Text = "Ventas Plus | Facturando desde cualquier Sucursal"
            Else
                TIPOCOMPROBANTETableAdapter.FillByCodSuc(DsFacturacionCompleja.TIPOCOMPROBANTE, SucCodigo)
                VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
                Dim Descripmaquina As String
                Descripmaquina = f.FuncionConsultaString("DESCRIPCION", "PC", "IP", CodigoMaquina)
                Me.Text = "Ventas Plus | Facturando desde: " & Descripmaquina & ""
            End If
            RecorreDetalleVenta()

            VenderMasQueStock = PermisoAplicado(UsuCodigo, 201)
            ModificarFactura = PermisoAplicado(UsuCodigo, 41)

            Try
                If GridViewFacturacion.RowCount = 0 Then
                    tipocomp2 = f.FuncionConsultaString("TIPOCOMPROBANTE.CODCOMPROBANTE", "TIPOCOMPROBANTE INNER JOIN DETPC ON TIPOCOMPROBANTE.CODCOMPROBANTE=DETPC.CODCOMPROBANTE", "DETPC.CODSUCURSAL=" & SucCodigo & " AND TIPOCOMPROBANTE.CODEMPRESA=" & EmpCodigo & " AND TIPOCOMPROBANTE.VENTAS=1 AND DETPC.ACTIVO = 1 AND  DETPC.IP", CodigoMaquina)
                Else
                    tipocomp2 = f.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)
                End If
                impresora = f.FuncionConsultaString("IMPRESORA", "DETPC", "CODSUCURSAL=" & SucCodigo & " AND CODEMPRESA=" & EmpCodigo & " AND ACTIVO = 1 AND CODCOMPROBANTE= " & tipocomp2 & "AND IP", CodigoMaquina)
            Catch ex As Exception
            End Try

            If impresora = Nothing Then
                MessageBox.Show("Esta maquina no tiene impresora asignada", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If Config13 = "No" Then
                SERIE.Visible = False
            Else
                SERIE.Visible = True
            End If

            lblDGVCant.Text = "Cant. de Items:" & GridViewFacturacion.RowCount

            ImprControl = 0
            DeshabilitaControles()
            lblProximoNro_Click(Nothing, Nothing)

            PintarCeldas()
        End If
    End Sub

    Public Sub PintarCeldas()
        If GridViewFacturacion.RowCount - 1 > 1 Then
            For i = 0 To GridViewFacturacion.RowCount - 1
                If GridViewFacturacion.Rows(i).Cells("ESTADODataGridViewTextBoxColumn").Value = 1 Then
                    GridViewFacturacion.Item(0, i).Style.ForeColor = Color.Green

                ElseIf GridViewFacturacion.Rows(i).Cells("ESTADODataGridViewTextBoxColumn").Value = 2 Then
                    GridViewFacturacion.Item(0, i).Style.ForeColor = Color.Maroon

                ElseIf GridViewFacturacion.Rows(i).Cells("ESTADODataGridViewTextBoxColumn").Value = 0 Then
                    If IsDBNull(GridViewFacturacion.Rows(i).Cells("CODPRESUPUESTO").Value) Then
                        GridViewFacturacion.Item(0, i).Style.ForeColor = Color.Black
                    ElseIf GridViewFacturacion.Rows(i).Cells("CODPRESUPUESTO").Value = 1 Then
                        GridViewFacturacion.Item(0, i).Style.ForeColor = Color.DarkOrange
                    Else
                        GridViewFacturacion.Item(0, i).Style.ForeColor = Color.Black
                    End If
                End If
            Next
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

    Private Sub dtpFechaHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaHora.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub FechaPreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaHora.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            VendendorComboBox.Select()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub GeneraCuotas()
        Dim i As Integer
        Dim Impcuo As Decimal
        Dim Totalimporte As Decimal = 0

        cantidadcuotas = CInt(TxtCantCuotas.Text)
        Frecuencia = TxtPeriodo.Text
        Impcuo = CDec(TotalVentaTextBox.Text) '* CDec(Cot1FactTextBox.Text)
        Impcuo = Math.Round(Impcuo / cantidadcuotas, 0)

        For i = 1 To cantidadcuotas
            FACTURACOBRARBindingSource.AddNew()
            Dim c As Integer = GridViewCuotas.RowCount
            If c > 0 Then
                'grilla tradicional
                Dim fecha As Date
                If i = 1 Then
                    fecha = dttFechaPrimeraCuota.Text
                Else
                    fecha = fecha.AddDays(Frecuencia)
                End If

                GridViewCuotas.Rows(c - 1).Cells("CODNUMEROCUOTADataGridViewTextBoxColumn").Value = i
                GridViewCuotas.Rows(c - 1).Cells("CODVENTADataGridViewTextBoxColumn2").Value = CDec(VCodVenta)
                GridViewCuotas.Rows(c - 1).Cells("FECHAVCTODataGridViewTextBoxColumn").Value = fecha.ToShortDateString
                If i = cantidadcuotas Then
                    Impcuo = CDec(TotalVentaTextBox.Text) '* CDec(Cot1FactTextBox.Text)
                    Impcuo = Math.Round(Impcuo - Totalimporte, 2)
                End If
                GridViewCuotas.Rows(c - 1).Cells("IMPORTECUOTADataGridViewTextBoxColumn").Value = Impcuo
                GridViewCuotas.Rows(c - 1).Cells("SALDOCUOTADataGridViewTextBoxColumn").Value = Impcuo
                If CmbTipoVenta.Text = "Contado" Then
                    GridViewCuotas.Rows(c - 1).Cells("TIPOFACTURADataGridViewTextBoxColumn").Value = "CONTADO"
                ElseIf CmbTipoVenta.Text = "Crédito" Then
                    GridViewCuotas.Rows(c - 1).Cells("TIPOFACTURADataGridViewTextBoxColumn").Value = "CREDITO"
                End If
                Totalimporte = Totalimporte + Impcuo
            End If
        Next
    End Sub

    Private Sub dgwClientes_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwClientes.CellDoubleClick
        If dgwClientes.RowCount <> 0 Then
            TxtNumCliente.Text = dgwClientes.CurrentRow.Cells("NUMCLIENTEDataGridViewTextBoxColumn").Value
            CmbCliente.Text = dgwClientes.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value

            PanelCliente = 0
            UltraPopupControlContainer1.Close()
            CmbCliente.Focus()
        End If
    End Sub

    Private Sub GridViewFacturacion_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles GridViewFacturacion.CellFormatting
        'Try
        '    If Me.GridViewFacturacion.Columns(e.ColumnIndex).Name = "ESTADODataGridViewTextBoxColumn" Then
        '        If e.Value IsNot Nothing Then
        '            If e.Value = 1 Then
        '                e.CellStyle.ForeColor = Color.Green
        '            ElseIf e.Value = 2 Then
        '                e.CellStyle.ForeColor = Color.Maroon
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub GridViewFacturacion_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewFacturacion.SelectionChanged

        If btNuevo = 0 Then
            pbarEstadoVentas.Value = 0 : btcfcuota = 0
            Dim objCommand As New SqlCommand
            Dim v10, v5, vTI, vEx, vTTC, VIvaGrab10, VIvaGrab5, vCotizacion As Decimal

            Try
                VCodVenta = GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value
                RecorreDetalleVenta()

                '-----Sara
                Dim drmoneda As DataRow
                For i = 0 To dtmoneda.Rows.Count
                    drmoneda = dtmoneda.Rows(i)
                    If CmbMoneda.SelectedValue = drmoneda("CODMONEDA") Then
                        cantdecimales = drmoneda("CANTIDADDECIMALES")
                        Exit For
                    End If
                Next

                DetalleVentaGridView.Columns("PRECIOVENTALISTADataGridViewTextBoxColumn").DefaultCellStyle.Format = "N" & cantdecimales
                DetalleVentaGridView.Columns("SubTotal").DefaultCellStyle.Format = "N" & cantdecimales

                Try
                    objCommand.CommandText = "SELECT TOTALIVA, TOTALEXENTA, TOTALGRAVADA, TOTAL5, TOTAL10, TOTALVENTA,COTIZACION1, TOTALGRAVADO5,TOTALGRAVADO10 FROM dbo.VENTAS WHERE CODVENTA = " & VCodVenta
                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                    If odrConfig.HasRows Then
                        Do While odrConfig.Read()
                            v10 = odrConfig("TOTAL10")
                            v5 = odrConfig("TOTAL5")
                            vTI = odrConfig("TOTALIVA")
                            vEx = odrConfig("TOTALEXENTA")
                            vTTC = odrConfig("TOTALVENTA")
                            VIvaGrab10 = odrConfig("TOTALGRAVADO10")
                            VIvaGrab5 = odrConfig("TOTALGRAVADO5")
                            vCotizacion = odrConfig("COTIZACION1")
                        Loop
                    End If

                    odrConfig.Close()
                    objCommand.Dispose()
                Catch ex As Exception
                End Try

                v10 = v10 / vCotizacion : Iva10TextBox1.Text = FormatNumber(v10, 2)
                v5 = v5 / vCotizacion : Iva5TextBox1.Text = FormatNumber(v5, 2)
                vTI = vTI / vCotizacion : TotalIvaVentaMaskedEdit.Text = FormatNumber(vTI, 2)
                vEx = vEx / vCotizacion : TotalExentaMaskedEdit.Text = FormatNumber(vEx, 2)
                vTTC = vTTC / vCotizacion : TotalVentaTextBox.Text = FormatNumber(vTTC, 2)
                TotalVentaV = TotalVentaTextBox.Text
                VIvaGrab10 = VIvaGrab10 / vCotizacion : TotalGravado10V = FormatNumber(VIvaGrab10, 2)
                VIvaGrab5 = VIvaGrab5 / vCotizacion : TotalGravado5V = FormatNumber(VIvaGrab5, 2)
                TotalGravadaMaskedEdit.Text = VIvaGrab10 + VIvaGrab5

                lblRucCliente.Text = GridViewFacturacion.CurrentRow.Cells("RUCCLIENTEDataGridViewTextBoxColumn").Value


                'TotalVentaTextBox.Text = FormatNumber(FormatNumber((f.FuncionConsultaString("TOTALVENTA", "VENTAS", "CODVENTA", CInt(GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value))), cantdecimales, , , TriState.UseDefault) / CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)), cantdecimales)
                ' TotalVentaV = FormatNumber(TotalVentaTextBox.Text, cantdecimales, , , TriState.UseDefault)
                ' TotalIvaVentaMaskedEdit.Text = FormatNumber(FormatNumber(GridViewFacturacion.CurrentRow.Cells("TOTALIVADataGridViewTextBoxColumn").Value, cantdecimales, , , TriState.UseDefault) / CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)), cantdecimales)
                '  TotalGravado10V = FormatNumber(FormatNumber(GridViewFacturacion.CurrentRow.Cells("TOTALGRAVADO10").Value, cantdecimales, , , TriState.UseDefault) / CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)), cantdecimales)
                'TotalGravado5V = FormatNumber(FormatNumber(GridViewFacturacion.CurrentRow.Cells("TOTALGRAVADO5").Value, cantdecimales, , , TriState.UseDefault) / CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)), cantdecimales)
                ' TotalGravadaMaskedEdit.Text = FormatNumber(FormatNumber(TotalGravadaMaskedEdit.Text, cantdecimales, , , TriState.UseDefault) / CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)), cantdecimales)
                ' TotalExentaMaskedEdit.Text = FormatNumber(FormatNumber(TotalExentaMaskedEdit.Text, cantdecimales, , , TriState.UseDefault) / CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)), cantdecimales)
                ' Iva10TextBox1.Text = FormatNumber(FormatNumber(GridViewFacturacion.CurrentRow.Cells("TOTAL10DataGridViewTextBoxColumn").Value, cantdecimales, , , TriState.UseDefault) / CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)), cantdecimales)
                'Iva5TextBox1.Text = FormatNumber(FormatNumber(GridViewFacturacion.CurrentRow.Cells("TOTAL5DataGridViewTextBoxColumn").Value, cantdecimales, , , TriState.UseDefault) / CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)), cantdecimales)

                '---------

                If GridViewFacturacion.CurrentRow.Cells("MODALIDADPAGO").Value = 2 Then
                    chbxBonif.Checked = True
                    chbxCambio.Checked = False
                    chbxOtros.Checked = False
                ElseIf GridViewFacturacion.CurrentRow.Cells("MODALIDADPAGO").Value = 3 Then
                    chbxBonif.Checked = False
                    chbxCambio.Checked = True
                    chbxOtros.Checked = False
                ElseIf GridViewFacturacion.CurrentRow.Cells("MODALIDADPAGO").Value = 4 Then
                    chbxBonif.Checked = False
                    chbxCambio.Checked = False
                    chbxOtros.Checked = True
                Else
                    chbxBonif.Checked = False
                    chbxCambio.Checked = False
                    chbxOtros.Checked = False
                End If

                If GridViewFacturacion.CurrentRow.Cells("TIPOVENTADataGridViewTextBoxColumn").Value = 1 Then
                    CmbTipoVenta.Text = "Crédito"
                    TxTTipoVenta.Text = "1"
                ElseIf GridViewFacturacion.CurrentRow.Cells("TIPOVENTADataGridViewTextBoxColumn").Value = 0 Then
                    CmbTipoVenta.Text = "Contado"
                    TxTTipoVenta.Text = "0"
                End If

            Catch ex As Exception
            End Try

            '  Dim objCommand As New SqlCommand
            'Dim CodTipoCliente As Integer

            CmbCliente.BackColor = SystemColors.ControlLightLight

            'ABHI: SIGUIENTE CODIGO FUERA O ACHICAR. ES MUY LARGO CON MUCHO INNER JOINS QUE LENTECEN EL CODIGO DURANTE EL SELECTION INDEX CHANGE.
            If CmbCliente.Text <> "" Then
                Try
                    objCommand.CommandText = "SELECT dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.RUC, dbo.CLIENTES.NOMBREFANTASIA, dbo.CLIENTES.DIASVENCIMIENTO, dbo.CLIENTES.CANTCUOTAS, dbo.PAIS.DESPAIS, dbo.CLIENTES.DIRECCION, dbo.ZONA.DESZONA, " & _
                                             "dbo.CIUDAD.DESCIUDAD FROM dbo.CLIENTES LEFT OUTER JOIN " & _
                                             "dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN dbo.CIUDAD ON dbo.CLIENTES.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                                             "dbo.PAIS ON dbo.CLIENTES.CODPAIS = dbo.PAIS.CODPAIS WHERE dbo.CLIENTES.CODCLIENTE = " & CmbCliente.SelectedValue

                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                    If odrConfig.HasRows Then
                        Do While odrConfig.Read()

                            'Nombre de Fantasia y NumCliente
                            Try
                                'Preguntamos si Desea Ver la LOCALIZACION o DIRECCION del Cliente
                                If Config4 = "Mostrar Localizacion del Cliente" Then
                                    txtLocalizacion.Text = odrConfig("DESPAIS") + " / " + odrConfig("DESCIUDAD") + " / " + odrConfig("DESZONA")

                                ElseIf Config4 = "Mostrar Dirección del Cliente" Then
                                    txtLocalizacion.Text = odrConfig("DIRECCION")
                                End If

                                TxtNumCliente.Text = odrConfig("NUMCLIENTE")
                                lblNombreFantasia.Visible = True
                                lblNombreFantasia.Text = odrConfig("NOMBREFANTASIA")
                                lblRucCliente.Visible = True : lblRucCliente.Text = odrConfig("RUC")
                                diasvtocli = odrConfig("DIASVENCIMIENTO")
                                cantcuotascli = odrConfig("CANTCUOTAS")
                            Catch ex As Exception
                            End Try
                        Loop
                    End If

                    odrConfig.Close()
                    objCommand.Dispose()
                Catch ex As Exception
                End Try
            End If

            TxtEstado_TextChanged(Nothing, Nothing)

            Try
                If Config1 = "Con todas las Sucursales" Then
                    lblProximoNro_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
            End Try

            Try
                'ordenamos la grilla
                DetalleVentaGridView.Sort(DetalleVentaGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Catch ex As Exception
            End Try
        End If

        If (NroFacturaLabel.Text = "") Or (NroFacturaLabel.Text = "Pend. de Aprob.") Then
            NroFacturaLabel.Text = "Pend. de Aprob."
            NroFacturaLabel.ForeColor = Color.DimGray
        Else
            NroFacturaLabel.ForeColor = Color.OrangeRed
        End If
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim CodVentaTemp As Integer
        Dim MensajesError As String = ""
        Dim NroError As Integer = 0
        Me.Cursor = Cursors.AppStarting

        habilitaControles()

        If btNuevo = 1 And NroFacturaLabel.Text <> "" Then
            Dim ExisteNroFactura As String = f.FuncionConsultaString("NUMVENTA", "VENTAS", "NUMVENTA = ", NroFacturaLabel.Text) 'Quitamos el numtimbrado ya que forzaria a hacer una consulta y esta opcion no se usa mucho
            If ExisteNroFactura <> Nothing Then
                NroError = NroError + 1
                MensajesError = CStr(NroError) & ") El Nro de Factura ya se encuentra en la Base de Datos " + Chr(13)
            End If
        End If

        If CmbCliente.SelectedValue = Nothing OrElse String.IsNullOrEmpty(CmbCliente.SelectedValue) Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Elija un Cliente " + Chr(13)
            CmbCliente.BackColor = Color.Pink
        Else
            CodClienteV = CmbCliente.SelectedValue
        End If

        If CmbSucursal.SelectedValue = Nothing OrElse String.IsNullOrEmpty(CmbSucursal.SelectedValue) Then
            NroError = NroError + 1
            MensajesError = MensajesError + CStr(NroError) + ") Elija un Deposito  " + Chr(13)
            CmbSucursal.BackColor = Color.Pink
        Else
            CodDepV = CmbSucursal.SelectedValue
        End If

        If TipoComprobanteComboBox.SelectedValue = Nothing OrElse String.IsNullOrEmpty(TipoComprobanteComboBox.SelectedValue) Then
            NroError = NroError + 1
            MensajesError = MensajesError + CStr(NroError) + ") Indique el Tipo de Comprobante " + Chr(13)
            TipoComprobanteComboBox.BackColor = Color.Pink
        Else
            CodRangoV = TipoComprobanteComboBox.SelectedValue
        End If

        If CmbTipoVenta.Text = Nothing OrElse String.IsNullOrEmpty(CmbTipoVenta.Text) Then
            NroError = NroError + 1
            MensajesError = MensajesError + CStr(NroError) + ") Indique el Tipo de Venta  " + Chr(13)
            CmbTipoVenta.BackColor = Color.Pink
        Else
            If CmbTipoVenta.Text = "Contado" Then
                TipoVtaV = "0"
            Else
                TipoVtaV = "1"
            End If
        End If

        If CmbMoneda.SelectedValue = Nothing OrElse String.IsNullOrEmpty(CmbMoneda.SelectedValue) Then
            NroError = NroError + 1
            MensajesError = MensajesError + CStr(NroError) + ") Indique la Moneda  " + Chr(13)
            CmbMoneda.BackColor = Color.Pink
        Else
            CodMonedaV = CmbMoneda.SelectedValue
        End If

        If DetalleVentaGridView.RowCount > 0 Then
            If CmbSucursal.SelectedValue <> DetalleVentaGridView.Rows(0).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value Then
                NroError = NroError + 1
                MensajesError = MensajesError + CStr(NroError) + ") Se ingresaron Productos de diferentes Depositos. No se permite vender productos de Multiples Depositos!  " + Chr(13)
                CmbSucursal.BackColor = Color.Pink
            End If
        End If

        If NroError <> 0 Then
            MessageBox.Show("Faltaron datos para completar el proceso de guardado. Favor revise estos items antes de seguir:  " + Chr(13) + MensajesError, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim EstadoDev As Integer = 0
        If btModificar = 1 Then
            EstadoDev = w.FuncionConsultaDecimal("ESTADO", "VENTAS", "CODVENTA", CDec(VCodVenta))
        End If

        GuardarPictureBox.Image = My.Resources.SaveActive

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            GuardaCabeceraVenta()
            GuardaDetalleVenta()

            If (EstadoDev = 1) And btModificar = 1 Then
                'VER SI IMPLEMENTAR O NO
                'Dim ModalidadAntigua As String
                'If Not IsDBNull(GridViewFacturacion.CurrentRow.Cells("MODALIDADPAGO").Value) Then
                '    ModalidadAntigua = GridViewFacturacion.CurrentRow.Cells("MODALIDADPAGO").Value
                '    If (ModalidadAntigua = 0 Or ModalidadAntigua = 4) And ModalidadV <> 0 And ModalidadV <> 4 Then
                '        InsertaFacturaCobrar(Nothing)
                '    End If
                'End If

                'Insertamos en la Tabla MovimientosVendedores
                If VendendorComboBox.Text <> "" Then
                    consultaInsert = consultaInsert + " UPDATE MOVIMIENTOVENDEDOR SET CODVENDEDOR = " & VendendorComboBox.SelectedValue & " where IDMOVIMIENTO =" & GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & " OR CODVENTAREL= " & GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & ""
                    consultaInsert = consultaInsert + " UPDATE DEVOLUCION SET CODVENDEDOR = " & VendendorComboBox.SelectedValue & " where CODVENTA =" & GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value
                    Consultas.ConsultaComando(myTrans, consultaInsert)
                End If
            End If

            cmd.ExecuteNonQuery()
            myTrans.Commit()

            'lblEstadoVentasPlus.Text = "Guardado!"
            If pbarEstadoVentas.Value < 81 Then
                pbarEstadoVentas.Value += 20
            End If

        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch
            End Try
            MessageBox.Show("Problema al Grabar: " & ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            sqlc.Close()
        End Try

        ''Actualizar TotalIVA Si es igual a Cero
        'Dim MaxVenta As Integer = f.Maximo("CODVENTA", "VENTAS")
        'Dim TotalIVAMAX As Decimal = f.FuncionConsulta("TOTALIVA", "VENTAS", "CODVENTA", MaxVenta)

        'Try
        '    If TotalIVAMAX = 0 Then
        '        cmd.Connection.Open()
        '        Dim SP As String
        '        SP = "Exec SPActualizarVenta " & MaxVenta
        '        cmd.CommandText = SP
        '        cmd.Connection = sqlc
        '        cmd.ExecuteNonQuery()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Problema al Grabar: " & ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End Try

        'GUARDAR()
        TxtDescuento.Enabled = False

        'Despues activamos  la posiblidad de modificar dicho nro de factura
        If PermisoFact = 0 Then
            BtnNuevoP3.Enabled = False
            Me.tsCargarNroFactura.Enabled = False
        Else
            If NroFacturaLabel.Text <> "" Then
                BtnNuevoP3.Visible = True : BtnCancelarP3.Visible = False : BtnGuardarP3.Visible = False
            Else
                BtnNuevoP3.Visible = False : BtnCancelarP3.Visible = False : BtnGuardarP3.Visible = False : Me.tsCargarNroFactura.Enabled = False
            End If
        End If

        CodVentaTemp = VCodVenta

        btNuevo = 0 : btModificar = 0 : pbarEstadoVentas.Value = 0
        lblCredito.Visible = False : lblLimiteCredito.Visible = False : lblLimiteCredito.Text = "0"

        TxtEstado.Text = "0"
        CLIENTESBindingSource.RemoveFilter()

        FechaFiltro()
        If Config1 = "Con todas las Sucursales" Then
            VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
        Else
            VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
        End If
        pbarEstadoVentas.Value = 100

        'TIPOCOMPROBANTEBindingSource.RemoveFilter()
        'Buscamos la posicion del registro guardado
        For i = 0 To GridViewFacturacion.RowCount - 1
            If GridViewFacturacion.Rows(i).Cells("CODVENTADataGridViewTextBoxColumn").Value = CodVentaTemp Then
                VENTASBindingSource.Position = i
                Exit For
            End If
        Next

        Try
            'ordenamos la grilla
            DetalleVentaGridView.Sort(DetalleVentaGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
        End Try


        PintarCeldas()
        DeshabilitaControles()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardaCabeceraVenta()
        Dim numero As System.Decimal
        Iva10TextBox1.Text = totaliva10mascara.Text
        Iva5TextBox1.Text = totaliva5mascara.Text

        consultaInsert = ""
        If Decimal.TryParse(TotalExentaMaskedEdit.Text, numero) Then
            TotalExentaV = Math.Round((CDbl(TotalExentaMaskedEdit.Text) * CDbl(Cot1FactTextBox.Text)), cantdecimales)
            TotalExentaV = Replace(TotalExentaV, ",", ".")
        Else
            TotalExentaV = "0"
        End If

        If Decimal.TryParse(TotalGravadaMaskedEdit.Text, numero) Then
            TotalGravadaV = Math.Round((CDec(TotalGravadaMaskedEdit.Text) * CDec(Cot1FactTextBox.Text)), cantdecimales)
            TotalGravadaV = Replace(TotalGravadaV, ",", ".")
        Else
            TotalGravadaV = "0"
        End If

        If Decimal.TryParse(Iva10TextBox1.Text, numero) Then
            TotalIvaV = Iva10TextBox1.Text
            TotalIvaV = TotalIvaV * Cot1FactTextBox.Text
            TotalIvaV = Replace(TotalIvaV, ",", ".")
        Else
            TotalIvaV = "0"
        End If

        If Decimal.TryParse(Iva10TextBox1.Text, numero) Then
            TotalIva10V = Iva10TextBox1.Text * Cot1FactTextBox.Text
            TotalIva10V = Replace(TotalIva10V, ",", ".")
        Else
            TotalIva10V = "0"
        End If

        If Decimal.TryParse(Iva5TextBox1.Text, numero) Then
            TotalIva5V = Iva5TextBox1.Text * Cot1FactTextBox.Text
            TotalIva5V = Replace(TotalIva5V, ",", ".")
        Else
            TotalIva5V = "0"
        End If

        If String.IsNullOrEmpty(TotalVentaV) Then
            TotalVentaV = "0"
        Else
            TotalVentaV = Funciones.Cadenas.QuitarCad(TotalVentaV, ".")
            TotalVentaV = Math.Round((CDec(TotalVentaV) * CDec(Cot1FactTextBox.Text)), cantdecimales)
            TotalVentaV = Replace(TotalVentaV, ",", ".")
        End If
        If String.IsNullOrEmpty(TotalGravado10V) Then
            TotalGravado10V = "0"
        Else
            TotalGravado10V = TotalGravado10V * Cot1FactTextBox.Text
            TotalGravado10V = Replace(TotalGravado10V, ",", ".")
        End If
        If String.IsNullOrEmpty(TotalGravado5V) Then
            TotalGravado5V = "0"
        Else
            TotalGravado5V = TotalGravado5V * Cot1FactTextBox.Text
            TotalGravado5V = Replace(TotalGravado5V, ",", ".")
        End If

        If txtObservacion.Text = "" Then
            MotivoDescV = " "
        Else
            MotivoDescV = txtObservacion.Text
        End If

        If VendendorComboBox.SelectedValue = Nothing Then
            CodVendedorV = "NULL"
        Else
            CodVendedorV = VendendorComboBox.SelectedValue
        End If
        If Cot1FactTextBox.Text = "" Or Cot1FactTextBox.Text = "0,00" Then
            Cotizacion1V = "1"
        Else
            Cotizacion1V = CDec(Cot1FactTextBox.Text)
            Cotizacion1V = Funciones.Cadenas.QuitarCad(Cotizacion1V, ".")
            Cotizacion1V = Replace(Cotizacion1V, ",", ".")
        End If

        If CmbEvento.SelectedValue = Nothing Then
            CodEventoV = "NULL"
        Else
            CodEventoV = CmbEvento.SelectedValue
        End If

        CodZonaV = f.FuncionConsulta("codzona", "clientes", "CAST(codcliente AS VARCHAR)", CodClienteV)
        If CodZonaV = 0 Then
            CodZonaV = "NULL"
        End If

        If CmbMetodo.Text = Nothing Then
            MetodoV = "NULL"
        Else
            MetodoV = CmbMetodo.Text
        End If

        If chbxBonif.Checked = True Then
            ModalidadV = "2"
        ElseIf chbxCambio.Checked = True Then
            ModalidadV = "3"
        ElseIf chbxOtros.Checked = True Then
            ModalidadV = "4"
        Else
            If CmbTipoVenta.Text = "Contado" Then
                ModalidadV = "0"
            Else
                ModalidadV = "1"
            End If
        End If

        Dim drdetpc As DataRow
        Dim dadetpc As New SqlDataAdapter("SELECT CODCOMPROBANTE,CODSUCURSAL,TIMBRADO FROM DETPC WHERE RANDOID=" & CodRangoV & "", ser.CadenaConexion)
        Dim dtdetpc As New DataTable
        dadetpc.Fill(dtdetpc)
        drdetpc = dtdetpc.Rows(0)

        CodComprobanteV = drdetpc("CODCOMPROBANTE")
        CodSucV = drdetpc("CODSUCURSAL")
        NumTimbradoV = drdetpc("TIMBRADO")

        drdetpc.Delete()
        dtdetpc.Clear()
        Dim daDatosCli As New SqlDataAdapter("SELECT RUC,DIRECCION FROM CLIENTES WHERE CODCLIENTE=" & CodClienteV & "", ser.CadenaConexion)
        daDatosCli.Fill(dtdetpc)
        drdetpc = dtdetpc.Rows(0)

        '*******************SE MODIFICO PARA MEJOR CONTROL DEL IVA, PARA QUE GUARDE EL IVA CORRECTO QUE APARECE EN EL FORM - SAUL
        RucV = lblRucCliente.Text 'drdetpc("RUC")
        '*************************************************************

        ' inicio Arturo
        If drdetpc("DIRECCION") Is DBNull.Value Then
            DirecV = Nothing
        Else
            DirecV = drdetpc("DIRECCION")
        End If
        ' fin Arturo "Dios es Amor"
        NombreV = CmbCliente.Text
        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim Concat As String = dtpFechaHora.Text
        FechaV = Concat & " " + hora 'FECHAVENTA= CONVERT(Datetime,'" & FechaV & "',103),

        If btModificar = 1 Then
            consultaInsert = " UPDATE VENTAS SET CODMONEDA=" & CodMonedaV & ", MOTIVODESCUENTO ='" & MotivoDescV & "'," & _
                       "CODEMPRESA=" & EmpCodigo & ", CODUSUARIO = " & UsuCodigo & _
                       ",CODCOMPROBANTE=" & CodComprobanteV & ", " & _
                       "CODCLIENTE=" & CodClienteV & ", " & _
                       "CODSUCURSAL=" & CodSucV & "," & _
                       "CODDEPOSITO=" & CodDepV & "," & _
                       "FECHAVENTA= CONVERT(Datetime,'" & FechaV & "',103)," & _
                       "TOTALEXENTA=" & TotalExentaV & ", " & _
                       "TOTALGRAVADA=" & TotalGravadaV & ",TOTALIVA=" & TotalIvaV & ",  " & _
                       "COTIZACION1=" & Cotizacion1V & ",TIPOVENTA=" & TipoVtaV & ", NOMBRECLIENTE='" & Replace(NombreV, "'", "''") & "'," & _
                       "RUCCLIENTE='" & RucV & "', MODALIDADPAGO=" & ModalidadV & ", " & _
                       "DIRECCION='" & Replace(DirecV, "'", "''") & "'," & _
                       "CODVENDEDOR=" & CodVendedorV & ", " & _
                       "TOTAL10=" & TotalIva10V & ",TOTAL5=" & TotalIva5V & ",  " & _
                       "CODZONA=" & CodZonaV & ",CODEVENTO=" & CodEventoV & ",METODO='" & MetodoV & "',  " & _
                       "TOTALGRAVADO5=" & TotalGravado5V & ",TOTALGRAVADO10=" & TotalGravado10V & ",TOTALVENTA=" & TotalVentaV & ",NUMVENTATIMBRADO=" & NumTimbradoV & ",CODRANGO=" & CodRangoV & " " & _
                       "WHERE CODVENTA=" & VCodVenta & ""
            cmd.CommandText = consultaInsert
            cmd.ExecuteNonQuery()
        Else
            consultaInsert = " INSERT VENTAS (CODMONEDA, MOTIVODESCUENTO,CODEMPRESA,CODUSUARIO,CODCOMPROBANTE,CODCLIENTE,CODSUCURSAL,CODDEPOSITO,FECHAVENTA,TOTALEXENTA,TOTALGRAVADA, " & _
                        "TOTALIVA,COTIZACION1,TIPOVENTA,NOMBRECLIENTE,RUCCLIENTE,MODALIDADPAGO,DIRECCION,CODVENDEDOR,TOTAL10,TOTAL5,CODZONA,CODEVENTO,METODO,TOTALGRAVADO5, " & _
                        "TOTALGRAVADO10,TOTALVENTA,NUMVENTATIMBRADO,CODRANGO,ESTADO,CODORDCOMPRA,CODPRESUPUESTO)  " & _
                        "VALUES(" & CodMonedaV & " , '" & MotivoDescV & "'," & EmpCodigo & ", " & UsuCodigo & "," & CodComprobanteV & ", " & CodClienteV & ", " & _
                        CodSucV & "," & CodDepV & "," & " CONVERT(Datetime,'" & FechaV & "',103)," & TotalExentaV & ", " & TotalGravadaV & "," & TotalIvaV & "," & Cotizacion1V & _
                        "," & TipoVtaV & ",'" & Replace(NombreV, "'", "''") & "','" & RucV & "'," & ModalidadV & ",'" & Replace(DirecV, "'", "''") & "'," & _
                        CodVendedorV & "," & TotalIva10V & "," & TotalIva5V & "," & CodZonaV & "," & CodEventoV & ",'" & MetodoV & "'," & TotalGravado5V & "," & TotalGravado10V & "," & _
                        TotalVentaV & "," & NumTimbradoV & "," & CodRangoV & ",0," & OrdCompraSEPSA & ",0) " & _
                         "SELECT CODVENTA FROM VENTAS WHERE CODVENTA = SCOPE_IDENTITY();"
            cmd.CommandText = consultaInsert
            CodVenta = cmd.ExecuteScalar() 'Este comando necesita si o si el CommandText para poder ejecutarse
            VCodVenta = CodVenta
        End If
    End Sub

    Private Sub habilitaControles()
        pnlVentasCabecera.Enabled = True
        pnlVentasDetalle.Enabled = True

        If Config12 = "DesHabilitar" Then
            cbxTipoIva.Enabled = False
        End If

        GridViewFacturacion.Enabled = False
        BuscarTextBox.Enabled = False
        BtnFiltro.Enabled = False
        CmbMes.Enabled = False
        CmbAño.Enabled = False
        TxtDescuento.Enabled = True
        btnMostrarOBS.Enabled = True

        BtnNuevoP3.Enabled = False
        BtnNuevoP3.Visible = False
        Me.tsCargarNroFactura.Enabled = False

        lblDGVCant.Text = ""
        lblAnticipo.Visible = False
        lblAnticipoS.Visible = False
    End Sub

    Private Sub IngresarCotCheckBox_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles IngresarCotCheckBox.ToggleStateChanged
        If IngresarCotCheckBox.Checked = True Then
            Cot1FactTextBox.ReadOnly = False
            Cotizacion.BringToFront()
            Try
                Cotizacion.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", TxtCodMoneda.Text + " ORDER BY FECHAMOVIMIENTO DESC")
            Catch ex As Exception

            End Try
        Else
            Cot1FactTextBox.ReadOnly = True
            Cot1FactTextBox.BringToFront()
            Cot1FactTextBox.Focus()
        End If
    End Sub

    Private Sub InicializaFechaFiltro()
        Dim nromes, nroaño As Integer
        nromes = Today.Month
        nroaño = Today.Year

        FechaFiltro1 = New DateTime(nroaño, nromes, 1)
        FechaFiltro2 = New DateTime(nroaño, nromes, DateTime.DaysInMonth(nroaño, nromes))
    End Sub

    'Private Sub InsertaFacturaCobrarContado(ByVal myTrans As System.Data.Common.DbTransaction)
    '    Dim consulta As System.String
    '    Dim codventa, importe, saldo As String
    '    Dim Pagado As Integer

    '    codventa = VCodVenta

    '    importe = CDec(TotalVentaTextBox.Text) * CDec(Cot1FactTextBox.Text)
    '    importe = Funciones.Cadenas.QuitarCad(importe, ".")
    '    importe = Replace(importe, ",", ".")

    '    If NoRegistrarCobro = 0 Then
    '        saldo = importe
    '        Pagado = 0
    '        If Config7 = "No Generar Saldo" Then
    '            saldo = "0"
    '            Pagado = 1
    '        End If
    '    Else
    '        saldo = "0"
    '        Pagado = 1
    '    End If

    '    consulta = "INSERT INTO FACTURACOBRAR (CODNUMEROCUOTA,CODUSUARIO," & _
    '    "CODVENTA,FECHAVCTO,SALDOCUOTA,IMPORTECUOTA,FECGRA," & _
    '    "PAGADO,TIPOFACTURA,IDCLIENTE) " & _
    '    "VALUES ( 1," & UsuCodigo & ", " & _
    '    "" & codventa & ", " & ValoresSql.Date(Today) & ", " & saldo & ", " & _
    '    "" & importe & " ,GETDATE()," & Pagado & ",'CONTADO', " & CmbCliente.SelectedValue & " ) "

    '    Consultas.ConsultaComando(myTrans, consulta)

    'End Sub

    Private Sub InsertaFacturaCobrar(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim Existe, Codnrocuota, Codventa, importe, fecha, saldocuota, tipofactura As String
        Dim Pagado As Integer
        conexion = ser.Abrir()

        Dim c As Integer = 0
        If CmbTipoVenta.Text = "Contado" And btcambiotipoventa = 0 Then 'btcambiotipoventa=1 quiere decir que la llamada al procedimiento viene de cambiar de un tipo de venta a otro
            c = 1 'una sola insercion
        Else 'Es credito o viene de un cambio de tipo de venta
            c = GridViewCuotas.RowCount 'una insercion por cada cuota
            If c = 0 Then
                Exit Sub 'TODO
            End If
        End If

        consulta = ""
        For i = 1 To c
            If CmbTipoVenta.Text = "Contado" And btcambiotipoventa = 0 Then
                Codventa = VCodVenta
                Codnrocuota = 1

                importe = CDec(TotalVentaTextBox.Text) ' * CDec(Cot1FactTextBox.Text)
                importe = Funciones.Cadenas.QuitarCad(importe, ".")
                importe = Math.Round(CDec(importe), cantdecimales)
                importe = Replace(importe, ",", ".")

                Dim hora As String = Now.ToString("HH:mm:ss")
                Dim Concat As String = dtpFechaHora.Text
                fecha = Concat & " " + hora

                If NoRegistrarCobro = 0 Then
                    saldocuota = importe
                    Pagado = 0
                    If Config7 = "No Generar Saldo" And chbxBonif.Checked = False And chbxCambio.Checked = False Then ' agregamos la salvedad para Cambios y Bonificaciones: Guazu!!
                        saldocuota = "0"
                        Pagado = 1
                    End If
                Else
                    saldocuota = "0"
                    Pagado = 1
                End If
                tipofactura = "CONTADO"
            Else ' Es credito o viene de un cambio de tipo de venta, entonces se lee de la grilla
                Codventa = CDec(GridViewCuotas.Rows(i - 1).Cells("CODVENTADataGridViewTextBoxColumn2").Value)
                Codnrocuota = CDec(GridViewCuotas.Rows(i - 1).Cells("CODNUMEROCUOTADataGridViewTextBoxColumn").Value)

                importe = GridViewCuotas.Rows(i - 1).Cells("IMPORTECUOTADataGridViewTextBoxColumn").Value
                importe = Funciones.Cadenas.QuitarCad(importe, ".")
                importe = Math.Round(CDec(importe), cantdecimales)
                importe = Replace(importe, ",", ".")

                If btcfcuota = 0 Then
                    fecha = CDate(GridViewCuotas.Rows(i - 1).Cells("FECHAVCTODataGridViewTextBoxColumn").Value).ToShortDateString
                Else
                    fecha = CDate(dttFechaPrimeraCuota.Value).ToShortDateString
                End If
                Dim hora As String = Now.ToString("HH:mm:ss")
                Dim Concat As String = fecha
                fecha = Concat & " " + hora

                If btcambiotipoventa = 0 Then
                    If CmbTipoVenta.Text = "Contado" Then
                        tipofactura = "CONTADO"
                        If NoRegistrarCobro = 0 Then
                            saldocuota = importe
                            Pagado = 0
                            If Config7 = "No Generar Saldo" And chbxBonif.Checked = False And chbxCambio.Checked = False Then ' agregamos la salvedad para Cambios y Bonificaciones: Guazu!!
                                saldocuota = "0"
                                Pagado = 1
                            End If
                        Else
                            saldocuota = "0"
                            Pagado = 1
                        End If
                    Else
                        Pagado = 0
                        saldocuota = importe
                        tipofactura = "CREDITO"
                    End If
                ElseIf btnCambiarTipoVenta.Text = "Cambiar a Crédito" Then
                    Pagado = 0
                    saldocuota = importe
                    tipofactura = "CREDITO"
                    If chbxBonif.Checked = False And chbxCambio.Checked = False And chbxOtros.Checked = False Then
                        consulta = consulta + " UPDATE VENTAS SET TIPOVENTA= 1, MODALIDADPAGO=1 WHERE CODVENTA=" & Codventa
                    Else
                        consulta = consulta + " UPDATE VENTAS SET TIPOVENTA= 1 WHERE CODVENTA=" & Codventa
                    End If
                Else ' Cambiar a Contado
                    'Actualizamos el tipo de la venta a Contado
                    tipofactura = "CONTADO"
                    If NoRegistrarCobro = 0 Then
                        saldocuota = importe
                        Pagado = 0
                        If Config7 = "No Generar Saldo" And chbxBonif.Checked = False And chbxCambio.Checked = False Then ' agregamos la salvedad para Cambios y Bonificaciones: Guazu!!
                            saldocuota = "0"
                            Pagado = 1
                        End If
                    Else
                        saldocuota = "0"
                        Pagado = 1
                    End If
                    If chbxBonif.Checked = False And chbxCambio.Checked = False And chbxOtros.Checked = False Then
                        consulta = consulta + " UPDATE VENTAS SET TIPOVENTA= 0, MODALIDADPAGO=0 WHERE CODVENTA=" & Codventa
                    Else
                        consulta = consulta + " UPDATE VENTAS SET TIPOVENTA= 0 WHERE CODVENTA=" & Codventa
                    End If
                End If
            End If

            'preguntamos si existe el detalle para saber si actualizar o insertar
            Existe = f.FuncionConsultaString("CODNUMEROCUOTA", "FACTURACOBRAR", "CODNUMEROCUOTA = " & Codnrocuota & " " & _
                                             "AND CODVENTA", Codventa)

            If Existe <> Nothing Then
                consulta = consulta + " UPDATE FACTURACOBRAR SET FECHAVCTO =CONVERT(DATETIME,'" & fecha & "',103), IMPORTECUOTA=" & importe & ",SALDOCUOTA=" & saldocuota & ", TIPOFACTURA = '" & tipofactura & "'," & _
              "PAGADO = " & Pagado & ", COTIZACION = " & CInt(Cot1FactTextBox.Text) & "   WHERE CODNUMEROCUOTA = " & Codnrocuota & " AND  CODVENTA = " & Codventa & " "
            Else
                consulta = consulta + " INSERT INTO FACTURACOBRAR (CODNUMEROCUOTA,CODUSUARIO,CODVENTA,FECHAVCTO,SALDOCUOTA,IMPORTECUOTA,FECGRA,PAGADO,TIPOFACTURA,IDCLIENTE, COTIZACION) " & _
                "VALUES ( " & Codnrocuota & "," & UsuCodigo & ", " & _
                "" & Codventa & ",CONVERT(Datetime,'" & fecha & "',103) ," & saldocuota & "," & importe & ",CONVERT(Datetime,'" & fecha & "',103)," & Pagado & ",'" & tipofactura & "'," & CmbCliente.SelectedValue & ", " & CInt(Cot1FactTextBox.Text) & ") "
            End If
        Next

        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        Consultas.ConsultaComando(myTrans, consulta)
        myTrans.Commit()
    End Sub

    Private Sub EliminarCobroMovimiento(ByRef CodCobroEL As Integer, ByVal myTrans As System.Data.Common.DbTransaction)
        Dim consulta As System.String

        consulta = ""
        consulta = "DELETE movimientos WHERE id_movimiento = " & CodCobroEL

        Consultas.ConsultaComando(myTrans, consulta)
    End Sub

    Private Sub LimpiaPagoCuota()
        TxtCantCuotas.Text = ""
        TxtPeriodo.Text = ""
    End Sub

    Private Sub Limpiarcodigos()
        CodProductoTextBox.Text = ""
        CodCodigoTextBox.Text = ""
    End Sub

    Private Sub Modificar()
        If TxtEstado.Text = "1" Or TxtEstado.Text = "2" Then
            MessageBox.Show("La  factura ya no se puede modificar", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            VENTASBindingSource.CancelEdit()
            VENTASDETALLEBindingSource.CancelEdit()
            Exit Sub
        End If
        habilitaControles()
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 28)
        If permiso = 0 Then
            MessageBox.Show("Usted No tienePpermiso para Modificar esta Venta", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Dim EstadoDev As Integer = w.FuncionConsultaDecimal("ESTADO", "VENTAS", "CODVENTA", CDec(VCodVenta))
            If (EstadoDev = 1) Then
                permiso = PermisoAplicado(UsuCodigo, 255)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para modificar una Venta Aprobada", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If

            TIPOCOMPROBANTEBindingSource.Filter = "ACTIVO = 1"
            habilitaControles()

            btNuevo = 0 : btModificar = 1 : TxtEstado.Text = "3"
            CmbSucursal.Enabled = False

            If (EstadoDev = 1) Then
                CmbCliente.Enabled = False : txtLocalizacion.Enabled = False : CmbTipoVenta.Enabled = False : CmbMoneda.Enabled = False
                CmbEvento.Enabled = False : CmbMetodo.Enabled = False : TipoComprobanteComboBox.Enabled = False : TxtNumCliente.Enabled = False
                BtnAsterisco.Enabled = False : CmbCliente.Enabled = False
                pnlVentasDetalle.Enabled = False

                dtpFechaHora.Enabled = True
                VendendorComboBox.Enabled = True
            End If

            For i = 0 To DetalleVentaGridView.RowCount - 1
                DetalleVentaGridView.Rows(i).Cells("LINEANUMERODataGridViewTextBoxColumn").Value = i + 1
            Next

            ModificarPictureBox.Image = My.Resources.EditActive
            Me.Cursor = Cursors.Arrow

            CmbCliente.Focus()
        End If
    End Sub

    Private Sub Nuevo()
        Dim conexion As System.Data.SqlClient.SqlConnection

        FechaFiltro1 = "01/01/2000"
        FechaFiltro2 = "01/01/2050"

        conexion = ser.Abrir()

        If btduplicar = 0 Then 'Si no está duplicando
            VENTASBindingSource.AddNew()
        End If

    End Sub

    Public Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        Try
            permiso = PermisoAplicado(UsuCodigo, 26)
            If permiso = 0 Then
                MessageBox.Show("Usted No tiene Permiso para Crear una Venta", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                pbarEstadoVentas.Value = 0
                pnlSinStock.Visible = False
                btNuevo = 1
                btModificar = 0
                GrillaModif = 0

                Me.Cursor = Cursors.AppStarting
                NuevoPictureBox.Image = My.Resources.NewActive

                If btduplicar = 0 Then 'Si no está duplicando
                    VENTASBindingSource.AddNew()
                End If

                tbxCodigoProducto.Text = "" : CantidadVentaMaskedEdit.Text = "" : tbxPrecioVenta.Text = "" : TxtEstado.Text = "3" : TxtDescuento.Text = "" : CmbEvento.Text = "" : txtLocalizacion.Text = ""
                DesProductoTextBox.Text = "" : CmbTipoVenta.Text = "Contado" : Me.TxtDescuento.Enabled = True : TxTTipoVenta.Text = "0" : CmbMetodo.Text = "Simplificado"
                CmbMoneda.SelectedValue = CDec(CODMONEDAPRINCIPAL) : CmbEvento.SelectedIndex = -1 : NroFacturaLabel.Text = "" : lblRucCliente.Text = ""
                TIPOCOMPROBANTEBindingSource.Filter = "ACTIVO = 1"

                Dim MaxVenta As Integer 'AHHORA TAMBIEN POR USUARIO
                If Config5 = "Mostrar Ultimo Seleccionado" Then
                    If Config1 = "Con todas las Sucursales" Then
                        MaxVenta = f.FuncionConsulta("MAX(CODVENTA)", "VENTAS", "CODRANGO IS NOT NULL AND CODUSUARIO", UsuCodigo)
                    Else
                        MaxVenta = f.FuncionConsulta("MAX(CODVENTA)", "VENTAS", "CODRANGO IS NOT NULL AND CODSUCURSAL=" & SucCodigo & " AND CODUSUARIO", UsuCodigo)
                    End If
                    Try
                        TipoComprobanteComboBox.SelectedValue = f.FuncionConsultaDecimal("CODRANGO", "VENTAS", "CODVENTA", MaxVenta)
                    Catch ex As Exception

                    End Try
                End If

                Try
                    If Not Config1 = "Con todas las Sucursales" Then
                        CmbSucursal.SelectedValue = f.FuncionConsulta("CODSUCURSAL", "SUCURSAL", "(TIPOSUCURSAL='Factura y Stock' OR TIPOSUCURSAL='Solo Stock') AND CODSUCURSAL", SucCodigo)
                    End If
                Catch ex As Exception

                End Try

                If Config2 = "Mostrar Fecha Actual" Then
                    dtpFechaHora.Value = Today.ToShortDateString

                ElseIf Config2 = "Mostrar Fecha Atrazada 1 Día" Then
                    Dim day As Integer = DateTime.Now.AddDays(-1).Day
                    Dim mes As Integer = Today.Month
                    Dim anho As Integer = Today.Year

                    Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                    dtpFechaHora.Value = Fecha

                ElseIf Config2 = "Mostrar Fecha Adelantada 1 Día" Then
                    Dim day As Integer = DateTime.Now.AddDays(+1).Day
                    Dim mes As Integer = Today.Month
                    Dim anho As Integer = Today.Year

                    Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                    dtpFechaHora.Value = Fecha

                ElseIf Config2 = "Mostrar Fecha de Ultima Seleccion" Then  'se verifica si quiere ultima seleccion por usuario o generla
                    If Config1 = "Con todas las Sucursales" Then
                        MaxVenta = f.MaximoIsNotNull("CODVENTA", "VENTAS", "CODRANGO")
                    Else
                        MaxVenta = f.FuncionConsulta("MAX(CODVENTA)", "VENTAS", "CODRANGO IS NOT NULL AND CODSUCURSAL", SucCodigo)
                    End If

                    dtpFechaHora.Text = f.FuncionConsultaString("FECHAVENTA", "VENTAS", "CODVENTA", MaxVenta)

                ElseIf Config2 = "Mostrar Fecha de Ultima Seleccion por Usuario" Then  'se verifica si quiere ultima seleccion por usuario o generla
                    dtpFechaHora.Text = f.FuncionConsultaString("FECHAVENTA", "VENTAS", "CODVENTA", MaxVenta)
                End If

                CmbMoneda.SelectedValue = CODMONEDAPRINCIPAL
                If CmbMoneda.SelectedValue <> Nothing Then
                    Cotizacion.Text = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(CmbMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
                    Me.COTIZACIONTableAdapter.Fill(DsFacturacionCompleja.COTIZACION, CmbMoneda.SelectedValue)
                End If

                Me.Cursor = Cursors.Arrow

                habilitaControles()
                CmbCliente.Enabled = True : txtLocalizacion.Enabled = True : CmbTipoVenta.Enabled = True : CmbMoneda.Enabled = True
                CmbEvento.Enabled = True : CmbMetodo.Enabled = True : TipoComprobanteComboBox.Enabled = True : TxtNumCliente.Enabled = True
                BtnAsterisco.Enabled = True : CmbCliente.Enabled = True : pnlVentasDetalle.Enabled = True : dtpFechaHora.Enabled = True
                VendendorComboBox.Enabled = True : CmbSucursal.Enabled = True


                If TipoComprobanteComboBox.Text = "" And TipoComprobanteComboBox.Items.Count > 0 Then
                    TipoComprobanteComboBox.SelectedIndex = TipoComprobanteComboBox.SelectedIndex + 1
                End If

                If CmbSucursal.Text = "" And CmbSucursal.Items.Count > 0 Then
                    CmbSucursal.SelectedIndex = CmbSucursal.SelectedIndex + 1
                End If


                TxTTipoVenta_TextChanged(Nothing, Nothing)
            End If

            NuevoPictureBox.Image = My.Resources.NewActive
            CmbCliente.SelectedIndex = -1 : TxtNumCliente.Focus() : TxtNumCliente.Text = "" : Iva10TextBox1.Text = "0" : Iva5TextBox1.Text = "0" : TotalGravadaMaskedEdit.Text = "0" : lblNombreFantasia.Text = ""
            chbxBonif.Checked = False : chbxCambio.Checked = False : chbxOtros.Checked = False : lblRucCliente.Text = ""
            OrdCompraSEPSA = 0

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub PictureBoxMotivoAnulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxMotivoAnulacion.Click
        If MessageBox.Show("¿Esta seguro de Anular el Registro?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        If VCodVenta = Nothing Then
            MessageBox.Show("Elija una Factura para Anular", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim IsPresupuesto As Integer = 0
        If Not IsDBNull(GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value) Then
            If GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value = 1 Then
                IsPresupuesto = 1
            End If
        End If

        If TxtEstado.Text = "1" Or IsPresupuesto = 1 Then
            PictureBoxMotivoAnulacion.Image = My.Resources.AnullActive
            btAprobado = 0
            btAnulado = 1
            PanelMotivoAnulacion.Visible = True
            PanelMotivoAnulacion.BringToFront()
            TxtMotivodeAnulacion.Text = ""
            TxtMotivodeAnulacion.Enabled = True
            TxtMotivodeAnulacion.Focus()

            BtnAnular.Visible = True
        Else
            MessageBox.Show("Solo se puede Anular Ventas Aprobadas", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Private Sub PictureBoxCuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCuotas.Click
        Me.FACTURACOBRARTableAdapter.Fill(DsFacturacionCompleja.FACTURACOBRAR)

        PanelCuota.Visible = True
        PanelCuota.BringToFront()

        lblCambiarCredito.Visible = False
        If GridViewCuotas.RowCount > 0 Then 'Tiene cuotas generadas
            If TxtEstado.Text = "0" Or TxtEstado.Text = "1" Or TxtEstado.Text = "3" Then
                Me.btnCambiarTipoVenta.Visible = True
                FACTURACOBRARTableAdapter.Fill(DsFacturacionCompleja.FACTURACOBRAR)
                BtnGeneraCuotas.Enabled = False
                BtnCancelarCuota.Enabled = False
                BtnGuardarCuotas.Enabled = False
                Me.dttFechaPrimeraCuota.Enabled = False
                TxtCantCuotas.Enabled = False
                TxtPeriodo.Enabled = False

                If CmbTipoVenta.Text = "Contado" Then
                    btnCambiarTipoVenta.Text = "Cambiar a Crédito"
                Else
                    btnCambiarTipoVenta.Text = "Cambiar a Contado"
                End If

            ElseIf TxtEstado.Text = "2" Then
                Me.btnCambiarTipoVenta.Visible = False
            End If
            btnGenerarPagares.Enabled = True
        Else ' No tiene cuotas generadas
            If TxtEstado.Text = "0" Or TxtEstado.Text = "1" Then
                BtnGeneraCuotas.Enabled = True
                BtnCancelarCuota.Enabled = True
                BtnGuardarCuotas.Enabled = True
                Me.dttFechaPrimeraCuota.Enabled = True
                TxtCantCuotas.Enabled = True
                TxtPeriodo.Enabled = True

                Me.btnCambiarTipoVenta.Visible = False
            End If
            btnGenerarPagares.Enabled = False
        End If
    End Sub

    Private Sub tbxPrecioVenta_GotFocus(sender As Object, e As System.EventArgs) Handles tbxPrecioVenta.GotFocus
        tbxPrecioVenta.BackColor = SystemColors.Highlight

        'Verificamos si el producto es de tipo Descuento para permitir realizar el descuento en porcentaje
        Dim TipoProd As Integer = f.FuncionConsultaDecimal("SERVICIO", "PRODUCTOS", "CODPRODUCTO", CodProductoTextBox.Text)
        If TipoProd = 5 Then
            lblDescuentoSimbolo.Visible = True
            lblDescuentoSimbolo.Text = lblSimboloMoneda.Text
        End If
    End Sub

    Private Sub tbxPrecioVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbxPrecioVenta.KeyDown
        If e.KeyCode = Keys.Up Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub tbxPrecioVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxPrecioVenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            If Config12 = "DesHabilitar" Then
                TxtDescuento.Focus()
            Else
                Me.cbxTipoIva.Focus()
            End If
        End If

        If KeyAscii = 42 Then
            'Verificamos si el producto es de tipo Descuento para permitir realizar el descuento en porcentaje
            Dim TipoProd As Integer = f.FuncionConsultaDecimal("SERVICIO", "PRODUCTOS", "CODPRODUCTO", CodProductoTextBox.Text)
            If TipoProd = 5 Then
                If lblDescuentoSimbolo.Text = "%" Then
                    lblDescuentoSimbolo.Text = lblSimboloMoneda.Text
                Else
                    lblDescuentoSimbolo.Text = "%"
                End If
                lblDescuentoSimbolo.Visible = True
            End If
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub RecorreBuscadorProductos()
        Dim c As Integer = ProductosGridView.RowCount

        Try
            For c = 1 To c
                Dim f As New Funciones.Funciones

                ProductosGridView.Rows(c - 1).Cells("PrecioVentaGrilla").Value = FormatNumber(ProductosGridView.Rows(c - 1).Cells("PRECIOVENTA").Value, 2)

                If IsDBNull(ProductosGridView.Rows(c - 1).Cells("STOCKACTUAL").Value) Then
                    ProductosGridView.Rows(c - 1).Cells("StockActualGrilla").Value = 0
                Else
                    ProductosGridView.Rows(c - 1).Cells("StockActualGrilla").Value = FormatNumber(ProductosGridView.Rows(c - 1).Cells("STOCKACTUAL").Value, 3)
                End If
                ProductosGridView.Rows(c - 1).Cells("TIPOCLIENTE").Value = f.FuncionConsultaString("DESTIPOCLIENTE", "TIPOCLIENTE", "CODTIPOCLIENTE", _
                                                                           ProductosGridView.Rows(c - 1).Cells("CODTIPOCLIENTE").Value)

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RecorreDetalleVenta()
        Try
            VENTASDETALLETableAdapter.FillByCodVta(Me.DsFacturacionCompleja.VENTASDETALLE, CInt(VCodVenta))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TipoComprobanteComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles TipoComprobanteComboBox.GotFocus
        TipoComprobanteComboBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub TipoComprobanteComboBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TipoComprobanteComboBox.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub TipoComprobanteComboBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TipoComprobanteComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            apretoteclaabajoencombo = False
            CmbTipoVenta.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtBuscaCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscaCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgwClientes.Focus()
        End If
    End Sub

    Private Sub TxtBuscaCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscaCliente.TextChanged
        If TxtBuscaCliente.Text <> "Buscar..." Then
            Me.CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & TxtBuscaCliente.Text & "%' OR NUMCLIENTE1 LIKE '%" & TxtBuscaCliente.Text & "%' OR RUC LIKE '%" & TxtBuscaCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & TxtBuscaCliente.Text & "%'"
        End If
    End Sub

    Private Sub TxtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoCliente.TextChanged
        TxtNumCliente.Text = f.FuncionConsultaString("numcliente", "clientes", "codcliente", TxtCodigoCliente.Text)
        If TxtNumCliente.Text = Nothing Then
            TxtNumCliente.Text = ""
        End If
    End Sub

    Private Sub TxtCodMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodMoneda.TextChanged
        If TxtCodMoneda.Text <> "" Then
            If TxtCodMoneda.Text = CODMONEDAPRINCIPAL Then
                Cot1FactTextBox.Text = 1
            Else
                Try
                    Cot1FactTextBox.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", TxtCodMoneda.Text + " ORDER BY FECHAMOVIMIENTO DESC")

                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub TxtEstado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEstado.TextChanged
        If btcancelando = 0 Then
            Try
                tsReImprimir.Enabled = False
                tsMotivoAnulacion.Enabled = False
                tsModificarNroFactura.Enabled = False

                If TxtEstado.Text = "0" Then
                    NuevoPictureBox.Image = My.Resources.New_
                    NuevoPictureBox.Enabled = True
                    tsNuevaVenta.Enabled = True

                    If IsDBNull(GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value) Then
                        LblEstado.Text = "Pendiente"
                        LblEstado.ForeColor = Color.Black
                    ElseIf GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value = 1 Then
                        LblEstado.Text = "Presupuesto"
                        LblEstado.ForeColor = Color.DarkOrange
                    Else
                        LblEstado.Text = "Pendiente"
                        LblEstado.ForeColor = Color.Black
                    End If

                    BtnImprimir.Enabled = True
                    tsAprobar.Enabled = True
                    BtnImprimir.Image = My.Resources.Approve
                    BtnImprimir.Cursor = Cursors.Hand
                    PictureBoxMotivoAnulacion.Enabled = False
                    tsAnular.Enabled = False
                    PictureBoxMotivoAnulacion.Image = My.Resources.AnullOff
                    PictureBoxMotivoAnulacion.Cursor = Cursors.Arrow

                    GuardarPictureBox.Enabled = False
                    tsGuardar.Enabled = False
                    GuardarPictureBox.Image = My.Resources.SaveOff
                    GuardarPictureBox.Cursor = Cursors.Arrow

                    CancelarPictureBox.Enabled = False
                    tsCancelar.Enabled = False
                    CancelarPictureBox.Image = My.Resources.SaveCancelOff
                    CancelarPictureBox.Cursor = Cursors.Arrow
                    ''
                    PanelMotivoAnulacion.Visible = False
                    BtnAnular.Enabled = True

                    EliminarPictureBox.Enabled = True
                    tsEliminar.Enabled = True
                    EliminarPictureBox.Image = My.Resources.Delete
                    EliminarPictureBox.Cursor = Cursors.Hand
                    ModificarPictureBox.Enabled = True
                    tsEditar.Enabled = True
                    ModificarPictureBox.Image = My.Resources.Edit
                    ModificarPictureBox.Cursor = Cursors.Hand

                    PictureBoxCuotas.Enabled = False
                    tsPanelDeCreditos.Enabled = False
                    PictureBoxCuotas.Image = My.Resources.CreditOff
                    BtnAnular.Enabled = False
                    TxtMotivodeAnulacion.Enabled = False

                    BtnNuevoP3.Enabled = False
                    Me.tsCargarNroFactura.Enabled = True

                    tsEmitirPresupuesto.Enabled = True
                    tsImprimirPresupuesto.Enabled = False
                    tsAprobarPresupuesto.Enabled = False
                    tsReImprimirPreVenta.Enabled = False
                    tsAnularPresupuesto.Enabled = False

                    'Si es un presupuesto debemos habilitar las opciones de Presupuesto
                    If Not IsDBNull(GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value) Then
                        If GridViewFacturacion.CurrentRow.Cells("CODPRESUPUESTO").Value = 1 Then
                            tsAnularPresupuesto.Enabled = True
                            PictureBoxMotivoAnulacion.Enabled = True
                            PictureBoxMotivoAnulacion.Image = My.Resources.Anull
                            PictureBoxMotivoAnulacion.Cursor = Cursors.Hand
                            BtnAnular.Enabled = True

                            tsImprimirPresupuesto.Enabled = True
                            tsAprobarPresupuesto.Enabled = True
                            tsReImprimirPreVenta.Enabled = True
                        End If
                    End If

                ElseIf TxtEstado.Text = "1" Then
                    NuevoPictureBox.Image = My.Resources.New_
                    NuevoPictureBox.Enabled = True
                    tsNuevaVenta.Enabled = True

                    LblEstado.Text = "Aprobada"
                    LblEstado.ForeColor = Color.Green

                    BtnImprimir.Enabled = False
                    tsAprobar.Enabled = True
                    BtnImprimir.Image = My.Resources.ApproveOff
                    BtnImprimir.Cursor = Cursors.Arrow

                    PictureBoxMotivoAnulacion.Enabled = True
                    tsAnular.Enabled = True
                    PictureBoxMotivoAnulacion.Image = My.Resources.Anull
                    PictureBoxMotivoAnulacion.Cursor = Cursors.Hand

                    PanelMotivoAnulacion.Visible = False
                    BtnAnular.Enabled = True

                    EliminarPictureBox.Enabled = False
                    tsEliminar.Enabled = False
                    EliminarPictureBox.Image = My.Resources.DeleteOff
                    EliminarPictureBox.Cursor = Cursors.Arrow

                    ModificarPictureBox.Enabled = False
                    tsEditar.Enabled = True
                    ModificarPictureBox.Image = My.Resources.EditOff
                    tsMotivoAnulacion.Enabled = True

                    CancelarPictureBox.Enabled = False
                    tsCancelar.Enabled = False
                    CancelarPictureBox.Image = My.Resources.SaveCancelOff
                    CancelarPictureBox.Cursor = Cursors.Arrow

                    GuardarPictureBox.Enabled = False
                    tsGuardar.Enabled = False
                    GuardarPictureBox.Image = My.Resources.SaveOff
                    GuardarPictureBox.Cursor = Cursors.Arrow
                    BtnNuevoP3.Enabled = False

                    If TxTTipoVenta.Text <> "0" And TxTTipoVenta.Text <> "1" Then
                        PictureBoxCuotas.Enabled = False
                        tsPanelDeCreditos.Enabled = False
                        PictureBoxCuotas.Image = My.Resources.CreditOff
                        TxtMotivodeAnulacion.Enabled = False
                    Else
                        PictureBoxCuotas.Enabled = True
                        tsPanelDeCreditos.Enabled = True
                        PictureBoxCuotas.Image = My.Resources.Credit
                        PictureBoxCuotas.Cursor = Cursors.Hand
                    End If

                    tsReImprimir.Enabled = True
                    tsModificarNroFactura.Enabled = True
                    tsImprimirPresupuesto.Enabled = False
                    tsEmitirPresupuesto.Enabled = False
                    tsAprobarPresupuesto.Enabled = False
                    tsReImprimirPreVenta.Enabled = False
                    tsAnularPresupuesto.Enabled = False
                    Me.tsCargarNroFactura.Enabled = False

                ElseIf TxtEstado.Text = "2" Then
                    NuevoPictureBox.Image = My.Resources.New_
                    NuevoPictureBox.Enabled = True
                    tsNuevaVenta.Enabled = True

                    LblEstado.Text = "Anulada"
                    LblEstado.ForeColor = Color.Red
                    BtnImprimir.Enabled = False
                    tsAprobar.Enabled = False
                    BtnImprimir.Image = My.Resources.ApproveOff

                    'BtnAnularFact.Visible = False
                    PictureBoxMotivoAnulacion.Enabled = False
                    tsAnular.Enabled = False
                    PictureBoxMotivoAnulacion.Image = My.Resources.AnullOff
                    PanelMotivoAnulacion.Visible = True
                    PanelMotivoAnulacion.BringToFront()

                    PictureBoxCuotas.Enabled = False
                    tsPanelDeCreditos.Enabled = False
                    PictureBoxCuotas.Image = My.Resources.CreditOff
                    BtnAnular.Enabled = False
                    TxtMotivodeAnulacion.Enabled = False

                    GuardarPictureBox.Enabled = False
                    tsGuardar.Enabled = False
                    GuardarPictureBox.Image = My.Resources.SaveOff
                    GuardarPictureBox.Cursor = Cursors.Arrow

                    BtnNuevoP3.Enabled = False
                    Me.tsCargarNroFactura.Enabled = False

                    EliminarPictureBox.Enabled = False
                    tsEliminar.Enabled = False
                    EliminarPictureBox.Image = My.Resources.DeleteOff

                    ModificarPictureBox.Enabled = False
                    tsEditar.Enabled = False
                    ModificarPictureBox.Image = My.Resources.EditOff
                    tsMotivoAnulacion.Enabled = True

                    CancelarPictureBox.Enabled = False
                    tsCancelar.Enabled = False
                    CancelarPictureBox.Image = My.Resources.SaveCancelOff
                    CancelarPictureBox.Cursor = Cursors.Arrow

                    tsImprimirPresupuesto.Enabled = False
                    tsEmitirPresupuesto.Enabled = False
                    tsAprobarPresupuesto.Enabled = False
                    tsReImprimirPreVenta.Enabled = False

                ElseIf TxtEstado.Text = "3" Then
                    NuevoPictureBox.Image = My.Resources.NewOff
                    NuevoPictureBox.Enabled = False
                    tsNuevaVenta.Enabled = False

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
                    PanelMotivoAnulacion.Visible = False
                    BtnAnular.Enabled = True

                    EliminarPictureBox.Enabled = False
                    tsEliminar.Enabled = False
                    EliminarPictureBox.Image = My.Resources.DeleteOff
                    EliminarPictureBox.Cursor = Cursors.Arrow

                    ModificarPictureBox.Enabled = False
                    tsEditar.Enabled = False
                    ModificarPictureBox.Image = My.Resources.EditOff
                    ModificarPictureBox.Cursor = Cursors.Arrow
                    Me.tsCargarNroFactura.Enabled = False
                    CancelarPictureBox.Visible = True
                    CancelarPictureBox.Enabled = True
                    CancelarPictureBox.Image = My.Resources.SaveCancel
                    CancelarPictureBox.Cursor = Cursors.Hand

                    GuardarPictureBox.Enabled = True
                    tsGuardar.Enabled = True
                    GuardarPictureBox.Image = My.Resources.Save
                    GuardarPictureBox.Cursor = Cursors.Hand

                    PictureBoxCuotas.Enabled = True
                    tsPanelDeCreditos.Enabled = True
                    PictureBoxCuotas.Image = My.Resources.Credit
                    PictureBoxCuotas.Cursor = Cursors.Hand

                    tsImprimirPresupuesto.Enabled = False
                    tsEmitirPresupuesto.Enabled = False
                    tsAprobarPresupuesto.Enabled = False
                    tsReImprimirPreVenta.Enabled = False
                    tsAnularPresupuesto.Enabled = False
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TxtNumCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNumCliente.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub TxtNumCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbCliente.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 42 Then
            BtnAsterisco_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtNumCliente_LostFocus(sender As Object, e As System.EventArgs) Handles TxtNumCliente.LostFocus
        Dim objCommand As New SqlCommand

        TxtNumCliente.BackColor = SystemColors.ControlLightLight
        If TxtNumCliente.Text <> "" Then
            Try
                objCommand.CommandText = "SELECT dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.TIPOVENTA, dbo.CLIENTES.CODCLIENTE, dbo.CLIENTES.CODVENDEDOR, dbo.CLIENTES.NOMBREFANTASIA, " & _
                                            "dbo.CLIENTES.CODTIPOCLIENTE, dbo.PAIS.DESPAIS, dbo.CLIENTES.DIRECCION, dbo.ZONA.DESZONA, dbo.CIUDAD.DESCIUDAD, dbo.CLIENTES.RUC FROM dbo.CLIENTES LEFT OUTER JOIN " & _
                                            "dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN dbo.CIUDAD ON dbo.CLIENTES.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
                                            "dbo.PAIS ON dbo.CLIENTES.CODPAIS = dbo.PAIS.CODPAIS WHERE AUTORIZADO=1 AND NUMCLIENTE = " & TxtNumCliente.Text
                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        Try
                            'Tipo Cliente (Lista de Precio)
                            Try
                                CmbCliente.SelectedValue = odrConfig("CODCLIENTE")
                                codtipocliente = odrConfig("CODTIPOCLIENTE")
                            Catch ex As Exception
                            End Try

                            'Vendedor
                            Try
                                VendendorComboBox.SelectedValue = odrConfig("CODVENDEDOR")
                            Catch ex As Exception
                            End Try

                            'Tipo de Venta Contado
                            Try
                                If odrConfig("TIPOVENTA") = 1 Then
                                    CmbTipoVenta.Text = "Crédito"
                                    TxTTipoVenta.Text = "1"
                                ElseIf odrConfig("TIPOVENTA") = 0 Then
                                    CmbTipoVenta.Text = "Contado"
                                    TxTTipoVenta.Text = "0"
                                    'ElseIf odrConfig("TIPOVENTA") = 2 Then
                                    '    CmbTipoVenta.Text = "Bonificación"
                                    '    TxTTipoVenta.Text = "2"
                                    'ElseIf odrConfig("TIPOVENTA") = 3 Then
                                    '    CmbTipoVenta.Text = "Cambio"
                                    '    TxTTipoVenta.Text = "3"
                                    'ElseIf odrConfig("TIPOVENTA") = 4 Then
                                    '    CmbTipoVenta.Text = "Otros"
                                    '    TxTTipoVenta.Text = "4"
                                End If
                            Catch ex As Exception
                            End Try

                            'Nombre de Fantasia y NumCliente
                            Try
                                TxtNumCliente.Text = odrConfig("NUMCLIENTE")
                                lblNombreFantasia.Visible = True : lblNombreFantasia.Text = odrConfig("NOMBREFANTASIA")
                                lblRucCliente.Visible = True : lblRucCliente.Text = odrConfig("RUC")
                            Catch ex As Exception
                                lblRucCliente.Visible = True : lblRucCliente.Text = odrConfig("RUC")
                            End Try

                            'Preguntamos si Desea Ver la LOCALIZACION o DIRECCION del Cliente
                            Try
                                If Config4 = "Mostrar Localizacion del Cliente" Then
                                    txtLocalizacion.Text = odrConfig("DESPAIS") + " / " + odrConfig("DESCIUDAD") + " / " + odrConfig("DESZONA")

                                ElseIf Config4 = "Mostrar Dirección del Cliente" Then
                                    txtLocalizacion.Text = odrConfig("DIRECCION")
                                End If
                            Catch ex As Exception
                            End Try
                        Catch ex As Exception
                        End Try
                    Loop
                Else
                    Dim ClienteDes As String = f.FuncionConsultaString("NOMBRE", "CLIENTES", "NUMCLIENTE", TxtNumCliente.Text)
                    If ClienteDes <> Nothing Then
                        MessageBox.Show("El Cliente : " & ClienteDes & "  se encuentra DESACTIVADO", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtNumCliente.Text = "" : TxtNumCliente.Focus() : CmbCliente.Text = ""
                        Exit Sub
                    End If
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try
        End If

        '-------------------------------------------------------------------
        'If TxtNumCliente.Text <> "" Then
        '    Try
        '        objCommand.CommandText = "SELECT dbo.CLIENTES.NUMCLIENTE, dbo.CLIENTES.TIPOVENTA, dbo.CLIENTES.CODCLIENTE, dbo.CLIENTES.CODVENDEDOR, dbo.CLIENTES.NOMBREFANTASIA, " & _
        '                                    "dbo.CLIENTES.CODTIPOCLIENTE, dbo.PAIS.DESPAIS, dbo.CLIENTES.DIRECCION, dbo.ZONA.DESZONA, dbo.CIUDAD.DESCIUDAD, dbo.CLIENTES.RUC FROM dbo.CLIENTES LEFT OUTER JOIN " & _
        '                                    "dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN dbo.CIUDAD ON dbo.CLIENTES.CODCIUDAD = dbo.CIUDAD.CODCIUDAD LEFT OUTER JOIN " & _
        '                                    "dbo.PAIS ON dbo.CLIENTES.CODPAIS = dbo.PAIS.CODPAIS WHERE AUTORIZADO=1 AND NUMCLIENTE = " & TxtNumCliente.Text
        '        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        '        objCommand.Connection.Open()
        '        Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

    End Sub

    Private Sub TxtNumCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumCliente.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(TxtNumCliente.Text, "^\d*$") Then
            TxtNumCliente.Text = TxtNumCliente.Text.Remove(TxtNumCliente.Text.Length - 1)
            TxtNumCliente.SelectionStart = TxtNumCliente.Text.Length
        End If
    End Sub

    Private Sub TxTTipoVenta_Click(sender As Object, e As System.EventArgs) Handles TxTTipoVenta.Click
        var = 1
    End Sub

    Private Sub TxTTipoVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxTTipoVenta.TextChanged
        '  If banchangecmbventa = 0 Then
        If btNuevo = 1 Or btModificar = 1 Then
            PictureBoxCuotas.Enabled = False

            If TxTTipoVenta.Text = "0" Or TxTTipoVenta.Text = "" Then
                CmbTipoVenta.Text = "Contado"
                PictureBoxCuotas.Image = My.Resources.CreditOff

            ElseIf TxTTipoVenta.Text = "1" Then
                CmbTipoVenta.Text = "Crédito"
                PictureBoxCuotas.Image = My.Resources.Credit

                'ElseIf TxTTipoVenta.Text = "2" Then
                '    CmbTipoVenta.Text = "Bonificación"
                '    PictureBoxCuotas.Image = My.Resources.CreditOff

                'ElseIf TxTTipoVenta.Text = "3" Then
                '    CmbTipoVenta.Text = "Cambio"
                '    PictureBoxCuotas.Image = My.Resources.CreditOff

                'ElseIf TxTTipoVenta.Text = "4" Then
                '    CmbTipoVenta.Text = "Otros"
                '    PictureBoxCuotas.Image = My.Resources.CreditOff

                'Else
                '    CmbTipoVenta.Text = ""
            End If
        End If
    End Sub

    Private Sub VendendorComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles VendendorComboBox.GotFocus
        VendendorComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub VendendorComboBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles VendendorComboBox.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub


    Private Sub VendendorComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles VendendorComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            apretoteclaabajoencombo = False
            CmbMoneda.Select()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

#End Region

    'Methods
    Function obtenerwhere(ByVal cmbfiltro1 As System.Windows.Forms.ToolStripTextBox, ByVal nombrecampof1 As String, ByVal cmbfiltro2 As System.Windows.Forms.ToolStripTextBox, ByVal nombrecampof2 As String, ByVal cmbfiltro3 As System.Windows.Forms.ToolStripTextBox, ByVal nombrecampof3 As String, ByVal tipo1 As String, ByVal tipo2 As String, ByVal tipo3 As String)

        Dim Filtro1 As String = ""
        Dim SiFiltro1 As Boolean = False
        Dim Filtro2 As String = ""
        Dim SiFiltro2 As Boolean = False
        Dim Filtro3 As String = ""
        Dim consultawhere As String

        If cmbfiltro1.Text = "%" Or cmbfiltro1.Text = "" Then
            SiFiltro1 = False
        Else
            If tipo1 = "Cadena Text" Then
                Filtro1 = nombrecampof1 + "'" & cmbfiltro1.Text & "'"
            ElseIf tipo1 = "Numero Text" Then
                Filtro1 = nombrecampof1 & cmbfiltro1.Text
            End If
            SiFiltro1 = True
        End If

        If cmbfiltro2.Text = "%" Or cmbfiltro2.Text = "" Then
            SiFiltro2 = False
        Else
            SiFiltro2 = True
            If SiFiltro1 = False Then
                If tipo2 = "Cadena Text" Then
                    Filtro2 = nombrecampof2 + "'" & cmbfiltro2.Text & "'"
                ElseIf tipo2 = "Numero Text" Then
                    Filtro2 = nombrecampof2 & cmbfiltro2.Text
                End If
            Else
                If tipo2 = "Cadena Text" Then
                    Filtro2 = " AND " + nombrecampof2 + "'" & cmbfiltro2.Text & "'"
                ElseIf tipo2 = "Numero Text" Then
                    Filtro2 = " AND " + nombrecampof2 & cmbfiltro2.Text
                End If
            End If
        End If

        If Not cmbfiltro3.Text = "%" Or cmbfiltro3.Text = "" Then
            If SiFiltro1 = True Or SiFiltro2 = True Then
                If tipo3 = "Cadena Text" Then
                    Filtro3 = " AND " + nombrecampof3 + "'" & cmbfiltro3.Text & "'"
                ElseIf tipo3 = "Numero Text" Then
                    Filtro3 = " AND " + nombrecampof3 & cmbfiltro3.Text
                End If
            Else
                If tipo3 = "Cadena Text" Then
                    Filtro3 = nombrecampof3 + "'" & cmbfiltro3.Text & "'"
                ElseIf tipo3 = "Numero Text" Then
                    Filtro3 = nombrecampof3 & cmbfiltro3.Text
                End If
            End If
        End If

        consultawhere = Filtro1 + Filtro2 + Filtro3

        Return consultawhere
    End Function

    Private Sub TxtCantCuotas_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantCuotas.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TxtPeriodo.Focus()
        End If
    End Sub

    Private Sub TxtCantCuotas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantCuotas.TextChanged
        TxtCantCuotas.Text = Funciones.Cadenas.SoloNumeros(TxtCantCuotas.Text)
    End Sub

    Private Sub TxtPeriodo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPeriodo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            BtnGeneraCuotas.Focus()
        End If
    End Sub

    Private Sub TxtPeriodo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPeriodo.TextChanged
        TxtPeriodo.Text = Funciones.Cadenas.SoloNumeros(TxtPeriodo.Text)
    End Sub

    Private Sub BtnNuevoP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevoP3.Click
        ' permiso = PermisoAplicado(UsuCodigo, 41)
        If ModificarFactura = 0 Then
            BtnNuevoP3.SendToBack()
        Else
            NroFactText.Visible = True
            If NroFacturaLabel.Text <> "" Then
                NroFactText.Text = NroFacturaLabel.Text
            Else
                NroFactText.Text = ""
            End If
            NroFactText.Focus()
            NroFacturaLabel.Visible = False
            BtnGuardarP3.Visible = True
            BtnCancelarP3.Visible = True
            BtnNuevoP3.Visible = False
            Me.tsCargarNroFactura.Enabled = False
        End If
    End Sub

    Private Sub BtnCancelarP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarP3.Click
        NroFactText.Visible = False
        NroFacturaLabel.Visible = True
        BtnGuardarP3.Visible = False
        BtnCancelarP3.Visible = False
        BtnNuevoP3.Visible = True
        tsCargarNroFactura.Enabled = True
    End Sub

    Private Sub BtnGuardarP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarP3.Click
        Dim f As New Funciones.Funciones
        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction
        Dim ExisteNroFactura, SucRango, SubCadena As String

        'se verifica que el nro de factura no este vacio
        If NroFactText.Text <> "--" Then
            'TxtEstado.Text = "3"
            Try
                'Si se cargo de forma manual verificamos q el rango de factura que ingreso exista en algun rango de comprobantes
                SubCadena = Mid(NroFactText.Text, 1, 3)
                ExisteNroFactura = w.FuncionConsultaString("CODSUCURSAL", "SUCURSAL", "SUCURSALTIMBRADO", SubCadena)
                SucRango = ExisteNroFactura

                If ExisteNroFactura = "" Or ExisteNroFactura = Nothing Then
                    MessageBox.Show("No existe ningún Rango de Comprobante Activo con esta Numeración", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' NroFactText.Text = NroFacturaLabel.Text
                    NroFacturaLabel.Visible = False
                    NroFactText.Visible = True
                    NroFactText.Focus()

                    BtnGuardarP3.Visible = True
                    BtnCancelarP3.Visible = True
                    BtnNuevoP3.Visible = False
                    Me.tsCargarNroFactura.Enabled = False
                    Exit Sub

                Else
                    SubCadena = Mid(NroFactText.Text, 5, 3)
                    ExisteNroFactura = w.FuncionConsultaString("NUMMAQUINA", "PC", "CODSUCURSAL = " & SucRango & " AND NUMMAQUINA", SubCadena)

                    If ExisteNroFactura = "" Or ExisteNroFactura = Nothing Then
                        MessageBox.Show("No existe ningún Rango de Comprobante Activo con esta numeración", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '  NroFactText.Text = NroFacturaLabel.Text
                        NroFacturaLabel.Visible = False
                        NroFactText.Visible = True
                        NroFactText.Focus()

                        BtnGuardarP3.Visible = True
                        BtnCancelarP3.Visible = True
                        BtnNuevoP3.Visible = False
                        Me.tsCargarNroFactura.Enabled = False
                        Exit Sub
                    End If
                End If

                'Verificamos que el nro de factura nose repita dentro del mismo timbrado
                TimbradoFactura = f.FuncionConsulta("TIMBRADO", "DETPC", " ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)
                ExisteNroFactura = w.FuncionConsultaString("NUMVENTA", "VENTAS", "ESTADO = 1 AND NUMVENTA = '" & NroFactText.Text & "' AND NUMVENTATIMBRADO", TimbradoFactura)

                If ExisteNroFactura <> "" Then
                    MessageBox.Show("El Nro de Factura ya Existe para el Rango con Timbrado: " & TimbradoFactura, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    NroFacturaLabel.Visible = False
                    NroFactText.Visible = True
                    NroFactText.Focus()

                    BtnGuardarP3.Visible = True
                    BtnCancelarP3.Visible = True
                    BtnNuevoP3.Visible = False
                    Me.tsCargarNroFactura.Enabled = False
                    Exit Sub
                End If

                conexion = ser.Abrir()
                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                consulta = "UPDATE VENTAS SET NUMVENTA='" & NroFactText.Text & "' WHERE CODVENTA=" & CDec(Me.VCodVenta) & ""
                Consultas.ConsultaComando(myTrans, consulta)

                myTrans.Commit()
            Catch ex As Exception
                Try
                    conexion = ser.Abrir()
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    myTrans.Rollback("Insertar")
                Catch
                End Try

                Throw
            End Try

            NroFacturaLabel.ForeColor = Color.OrangeRed
            NroFacturaLabel.Text = NroFactText.Text
            NroFactText.Visible = False
            NroFacturaLabel.Visible = True
            BtnGuardarP3.Visible = False
            BtnCancelarP3.Visible = False
            BtnNuevoP3.Visible = True

            BtnFiltro_Click(Nothing, Nothing)
        Else
            MessageBox.Show("Debe ingresar un Nro de Factura", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NroFactText.Focus()
        End If
    End Sub

    Private Sub TxtDescuento_GotFocus(sender As Object, e As System.EventArgs) Handles TxtDescuento.GotFocus
        TxtDescuento.BackColor = SystemColors.Highlight

        If lblSimboloDesc.Text = "%" Then
            rlblTituloDesc.Text = "Descuento en %"
        Else
            lblSimboloDesc.Text = "%"
            rlblTituloDesc.Text = "Descuento en " & CmbMoneda.Text
        End If
    End Sub

    Private Sub TxtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescuento.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If GrillaModif = 1 Then
                btnModificarDetVenta.Focus()
            Else
                AgregarDetVentaButton.Focus()
            End If

        End If

        If KeyAscii = 42 Then
            If lblSimboloDesc.Text = "%" Then
                lblSimboloDesc.Text = lblSimboloMoneda.Text
                rlblTituloDesc.Text = "Descuento en " & CmbMoneda.Text
                TxtDescuento.Appearance.BackColor = Color.Pink
            Else
                lblSimboloDesc.Text = "%"
                rlblTituloDesc.Text = "Descuento en %"
                TxtDescuento.Appearance.BackColor = SystemColors.ControlLightLight
            End If
        End If

        If KeyAscii = 65 Or KeyAscii = 97 Then
            tbxPorcSuma.Enabled = True
            tbxPorcSuma.Visible = True
            tbxPorcSuma.BringToFront()
            tbxPorcSuma.Focus()

            TxtDescuento.Enabled = False
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxPorcSuma_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxPorcSuma.KeyPress

        Dim KeyAscii As Short = Asc(e.KeyChar)

        If InStr(1, "0123456789," & Chr(15), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

        If KeyAscii = 13 Then
            AgregarDetVentaButton.Focus()
            KeyAscii = 0
        End If


    End Sub
    Private Sub ProductosGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductosGridView.DoubleClick
        Dim f As New Funciones.Funciones
        'CodEnvioDetalle.Text = ""
        ErrorCodigoLabel.Visible = False
        PrecioVentaG = 0
        Try
            If ProductosGridView.RowCount = 0 Then
                BuscarProductoTextBox.Text = ""
                CodCodigoTextBox.Text = ""
                tbxCodigoProducto.Focus()
                UltraPopupControlContainer1.Close()
            Else
                If IsDBNull(ProductosGridView.CurrentRow) Then
                    BuscarProductoTextBox.Text = ""
                    tbxCodigoProducto.Focus()
                    UltraPopupControlContainer1.Close()
                Else

                    If IsDBNull(ProductosGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value) And IsDBNull(ProductosGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) And _
                       IsDBNull(ProductosGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value) And IsDBNull(ProductosGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value) And _
                       IsDBNull(ProductosGridView.CurrentRow.Cells("PRECIOVENTADataGridViewTextBoxColumn").Value) Then

                        MessageBox.Show("El Producto Seleccionado no contiene todos los datos necesarios para la venta", "RIA")

                    Else
                        tbxCodigoProducto.Text = ProductosGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
                        CodProductoTextBox.Text = ProductosGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                        CodCodigoTextBox.Text = ProductosGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value

                        If IsDBNull(ProductosGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value) Then
                        Else
                            DesProductoTextBox.Text = ProductosGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
                        End If

                        Dim fx_Valor As Double = 0
                        If IngresarCotCheckBox.Checked = True Then
                            fx_Valor = Cotizacion.Text
                        Else
                            fx_Valor = Cot1FactTextBox.Text
                        End If

                        Dim precio As Double = MonedaCotizacion.ConvertMoney(CDec(ProductosGridView.CurrentRow.Cells("PRECIOVENTADataGridViewTextBoxColumn").Value), CDec(ProductosGridView.CurrentRow.Cells("CODMONEDA").Value), fx_Valor, CmbMoneda.SelectedValue)
                        tbxPrecioVenta.Text = precio
                        PrecioVentaG = tbxPrecioVenta.Text

                        If IsDBNull(ProductosGridView.CurrentRow.Cells("STOCKACTUALDataGridViewTextBoxColumn").Value) Then
                            TxtCantidadEnStock.Text = "0"
                        Else
                            TxtCantidadEnStock.Text = ProductosGridView.CurrentRow.Cells("STOCKACTUALDataGridViewTextBoxColumn").Value
                        End If
                        If IsDBNull(ProductosGridView.CurrentRow.Cells("COSTOFIFO").Value) Then
                            FIFOCOSTO = 1
                        Else
                            FIFOCOSTO = ProductosGridView.CurrentRow.Cells("COSTOFIFO").Value '/ CInt(Cot1FactTextBox.Text) 'CInt(f.FuncionConsultaString("COTIZACION1", "VENTAS", "CODVENTA", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)) 'saul
                        End If
                        If IsDBNull(ProductosGridView.CurrentRow.Cells("PROMOCION").Value) Then
                            PROMO = False
                        Else
                            PROMO = ProductosGridView.CurrentRow.Cells("PROMOCION").Value
                        End If
                        If Not IsDBNull(ProductosGridView.CurrentRow.Cells("CODIVA").Value) Then
                            cbxTipoIva.SelectedValue = ProductosGridView.CurrentRow.Cells("CODIVA").Value
                        End If
                    End If

                    Dim serie As New serie_class
                    tbxNroSerie.Text = serie.Serie(ProductosGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value, ProductosGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value)

                    lblSimboloMoneda.Text = w.FuncionConsultaString2("SIMBOLO", "MONEDA", "CODMONEDA", CmbMoneda.SelectedValue)
                    BuscarProductoTextBox.Text = ""

                    'si el producto tiene # y esta habilitado para trabajar con nro de serie ahi mostramos el panel para nro de serie
                    Dim DescripcionSerie_Actual As String = DesProductoTextBox.Text
                    If DescripcionSerie_Actual.Contains("#") And Config13 = "Si" Then
                        pnlNroSerie.Visible = True
                        pnlNroSerie.BringToFront()
                        tbxNroSerie.Focus()
                    Else
                        CantidadVentaMaskedEdit.Focus()
                    End If

                    UltraPopupControlContainer1.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarSinStock.Click
        pnlSinStock.Visible = False
    End Sub

    Private Sub NuevoPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NuevoPictureBox.MouseDown
        If NuevoPictureBox.Enabled = True Then
            NuevoPictureBox.Image = My.Resources.NewMouseDown
        End If
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.NuevoPictureBox, "Nueva Factura")
    End Sub

    Private Sub BtnImprimir_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles BtnImprimir.MouseDown
        If BtnImprimir.Enabled = True Then
            BtnImprimir.Image = My.Resources.ApproveMouseDown
        End If
    End Sub

    Private Sub BtnImprimir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimir.MouseEnter
        Me.ToolTip1.SetToolTip(Me.BtnImprimir, "Aprobar Factura")
    End Sub

    Private Sub EliminarPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles EliminarPictureBox.MouseDown
        If EliminarPictureBox.Enabled = True Then
            EliminarPictureBox.Image = My.Resources.DeleteMouseDown
        End If
    End Sub

    Private Sub EliminarPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.EliminarPictureBox, "Eliminar Factura")
    End Sub

    Private Sub ModificarPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ModificarPictureBox.MouseDown
        If ModificarPictureBox.Enabled = True Then
            ModificarPictureBox.Image = My.Resources.EditMouseDown
        End If
    End Sub

    Private Sub ModificarPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.ModificarPictureBox, "Editar Factura")
    End Sub

    Private Sub GuardarPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GuardarPictureBox.MouseDown
        If GuardarPictureBox.Enabled = True Then
            GuardarPictureBox.Image = My.Resources.SaveMouseDown
        End If
    End Sub

    Private Sub GuardarPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.GuardarPictureBox, "Guardar Factura")
    End Sub

    Private Sub CancelarPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.CancelarPictureBox, "Cancelar Factura")
    End Sub

    Private Sub PictureBoxCuotas_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxCuotas.MouseDown
        If PictureBoxCuotas.Enabled = True Then
            PictureBoxCuotas.Image = My.Resources.CreditMouseDown
        End If
    End Sub

    Private Sub PictureBoxCuotas_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxCuotas.MouseEnter
        Me.ToolTip1.SetToolTip(Me.PictureBoxCuotas, "Factura a Credito")
    End Sub

    Private Sub PictureBoxMotivoAnulacion_DoubleClick(sender As Object, e As System.EventArgs) Handles PictureBoxMotivoAnulacion.DoubleClick
        PictureBoxMotivoAnulacion.Enabled = False
    End Sub

    Private Sub PictureBoxMotivoAnulacion_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxMotivoAnulacion.MouseDown
        If PictureBoxMotivoAnulacion.Enabled = True Then
            PictureBoxMotivoAnulacion.Image = My.Resources.AnullMouseDown
        End If
    End Sub

    Private Sub PictureBoxMotivoAnulacion_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxMotivoAnulacion.MouseEnter
        Me.ToolTip1.SetToolTip(Me.PictureBoxMotivoAnulacion, "Anular Factura")
    End Sub

    Private Sub DetalleVentaGridView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DetalleVentaGridView.CellDoubleClick
        If TxtEstado.Text = "0" Or TxtEstado.Text = "" Or TxtEstado.Text = "3" Then
            GrillaModif = 1
            Try
                If IsDBNull(DetalleVentaGridView.CurrentRow) Then
                    Exit Sub
                Else
                    LineaVenta = DetalleVentaGridView.CurrentRow.Index
                    DetalleVentaGridView.BeginEdit(True)

                    If IsDBNull(DetalleVentaGridView.CurrentRow.Cells("CodigoGrilla").Value) Then
                        tbxCodigoProducto.Text = ""
                    Else
                        tbxCodigoProducto.Text = DetalleVentaGridView.CurrentRow.Cells("CodigoGrilla").Value
                    End If

                    If IsDBNull(DetalleVentaGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                        tbxCodigoProducto.Text = ""
                        CodCodigoTextBox.Text = ""
                    Else
                        CodProductoTextBox.Text = DetalleVentaGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
                        CodCodigoTextBox.Text = DetalleVentaGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                        CodComboTextBox.Text = ""
                    End If

                    If IsDBNull(DetalleVentaGridView.CurrentRow.Cells("CODCOMBODataGridViewTextBoxColumn2").Value) Then
                        CodComboTextBox.Text = ""
                    Else
                        CodComboTextBox.Text = DetalleVentaGridView.CurrentRow.Cells("CODCOMBODataGridViewTextBoxColumn2").Value
                        tbxCodigoProducto.Text = DetalleVentaGridView.CurrentRow.Cells("CODCOMBODataGridViewTextBoxColumn2").Value
                        CodCodigoTextBox.Text = ""
                    End If

                    cbxTipoIva.Text = DetalleVentaGridView.CurrentRow.Cells("IVADataGridViewTextBoxColumn").Value
                    CantidadVentaMaskedEdit.Text = CDec(DetalleVentaGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value)
                    tbxPrecioVenta.Text = CDec(DetalleVentaGridView.CurrentRow.Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value)

                    DesProductoTextBox.Text = DetalleVentaGridView.CurrentRow.Cells("ProductoGrilla").Value

                    tbxNroSerie.Text = DetalleVentaGridView.CurrentRow.Cells("serie").Value
                    Dim DescripcionSerie_Actual As String = DesProductoTextBox.Text
                    If DescripcionSerie_Actual.Contains("#") And Config13 = "Si" Then
                        pnlNroSerie.Visible = True
                        pnlNroSerie.BringToFront()
                        tbxNroSerie.Focus()
                    End If

                    'obtenemos la posicion
                    PosicionDato = DetalleVentaGridView.CurrentRow.Cells("LINEANUMERODataGridViewTextBoxColumn").Value
                End If
            Catch ex As Exception

            End Try
            AgregarDetVentaButton.Visible = False : EliminarDetVentaButton.Visible = False
            btnModificarDetVenta.Visible = True : CancelarDetVentaButton.Visible = True
            DetalleVentaGridView.Enabled = False
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub ModificarDetVentaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarDetVenta.Click
        Dim PrecioVenta As Double
        Dim stockdesdelector As String
        EliminarDetVentaButton_Click(Nothing, Nothing)
        If CodProductoTextBox.Text <> "" Then
            servicio = f.FuncionConsultaDecimal("SERVICIO", "PRODUCTOS", "CODPRODUCTO", CodProductoTextBox.Text)
        End If

        '################################################################################################################
        '# Antes de agregar el producto en la grilla debemos verificar que si es una Factura Credito no tengo un credito
        '# mayor a su limite permitido. By Yolanda Zelaya
        '################################################################################################################
        If CmbTipoVenta.Text = "Crédito" Then
            ' 1 - Verificamos el limite de credito del cliente
            Dim LimiteCredito As Double
            permiso = PermisoAplicado(UsuCodigo, 34)
            If permiso = 0 Then
                'Verificar que este Cliente no sobrepase su limite de Credito
                LimiteCredito = f.FuncionConsultaDecimal("LIMCREDITO", "CLIENTES", "NUMCLIENTE", TxtNumCliente.Text)
                LimiteCredito = Replace(LimiteCredito, ",", ".")

                If LimiteCredito <> "0,00" Then
                    ' 2 - Verificamos el monto total del credito que tiene acumulado para verificar que no sobrepase su limite establecido
                    Dim TotalVentas, TotalCobros, Total As Double
                    Dim SQLConsulta As String

                    'Verificamos si tiene descuento
                    If TxtDescuento.Text <> "" Then
                        'si tiene descuento tenemos que ver si es con Porcentaje o un Monto
                        PrecioVenta = CDec(tbxPrecioVenta.Text)
                        If lblSimboloDesc.Text = "%" Then
                            TotalCalc = FormatNumber((PrecioVenta * CDec(TxtDescuento.Text)) / 100, 2)
                            PrecioVenta = FormatNumber(PrecioVenta - TotalCalc, 2)
                        Else
                            TotalCalc = CDec(TxtDescuento.Text)
                            PrecioVenta = PrecioVenta - TotalCalc
                        End If
                    Else
                        PrecioVenta = FormatNumber(CDec(tbxPrecioVenta.Text), 2)
                        TotalCalc = 0
                    End If

                    SQLConsulta = "CODCLIENTE = " & CmbCliente.SelectedValue & " AND TIPOMOVIMIENTO "
                    TotalVentas = f.FuncionConsultaDecimal("SUM(IMPORTE)", "MOVIMIENTOCUENTACLIENTE", SQLConsulta, "Venta")

                    SQLConsulta = "CODCLIENTE = " & CmbCliente.SelectedValue & " AND TIPOMOVIMIENTO "
                    TotalCobros = f.FuncionConsultaDecimal("SUM(IMPORTE)", "MOVIMIENTOCUENTACLIENTE", SQLConsulta, "Cobro")

                    If TotalVentaTextBox.Text <> "0,00" And TotalVentaTextBox.Text <> "" Then
                        TotalVentas = TotalVentas + PrecioVenta + CDec(TotalVentaTextBox.Text)
                    Else
                        TotalVentas = TotalVentas + PrecioVenta
                    End If

                    Total = TotalVentas - TotalCobros
                    Total = FormatNumber(Total, 0)

                    If Total > LimiteCredito Then
                        MessageBox.Show("Cliente sobrepaso su Limite de Credito. Hable con un Gerente o Administrador de su Empresa", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
        End If

        'La cantidad no puede ser mayor al de stock actual
        If servicio = 1 Then
        Else
            If TxtCantidadEnStock.Text = "" Then
                stockdesdelector = f.FuncionConsultaString("STOCKACTUAL", "STOCKDEPOSITO", "CODCODIGO=" & CodCodigoTextBox.Text & " AND CODDEPOSITO", CmbSucursal.SelectedValue)
                If stockdesdelector = Nothing Then
                    'Aqui ver despues...porque así esta permitiendo guardar un producto que no existe en el deposito (por Guazu)
                    TxtCantidadEnStock.Text = 0
                Else
                    TxtCantidadEnStock.Text = stockdesdelector
                End If
            End If

            If CDec(CantidadVentaMaskedEdit.Text) > CDec(TxtCantidadEnStock.Text) Then
                If ProdPE = 1 Then
                    Dim TGramo As Double

                    TGramo = CantidadVentaMaskedEdit.Text / 1000
                    If TGramo > CDec(TxtCantidadEnStock.Text) Then
                        If VenderMasQueStock = 0 Then
                            MessageBox.Show("No se puede insertar porque sobrepasó el stock actual", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            CantidadVentaMaskedEdit.Focus()
                            ProdPE = 0
                            Exit Sub
                        End If
                    End If
                Else
                    If VenderMasQueStock = 0 Then
                        MessageBox.Show("No se puede insertar porque sobrepasó el stock actual", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        CantidadVentaMaskedEdit.Focus()
                        Exit Sub
                    End If
                End If
            End If
        End If

        If TxtCantidadEnStock.Text <> "" Then
            If CDec(CantidadVentaMaskedEdit.Text) > CDec(TxtCantidadEnStock.Text) Then
                If VenderMasQueStock = 0 Then
                    MessageBox.Show("No se puede insertar porque sobrepasó el stock actual", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CantidadVentaMaskedEdit.Focus()
                    Exit Sub
                End If
            End If
        End If

        Dim CantDeStockAct As Double
        If tbxCodigoProducto.Text.IndexOf("200") = 0 Or tbxCodigoProducto.Text.IndexOf("240") = 0 Then
            CantDeStockAct = Replace(CantidadVentaMaskedEdit.Text, ".", ",")
        Else
            CantDeStockAct = CantidadVentaMaskedEdit.Text
        End If

        Dim Precio, Cantidad, Subtotal, PrecioNeto As String
        Dim Iva, Iva1, CodIvaProducto, PorcIva, TotalIva, TotalGravada, TotalExenta, total10, total5 As String
        Dim CoheficienteIva As Decimal


        total10 = "0" : total5 = "0" : Subtotal = "0" : CoheficienteIva = "0" : PorcIva = "0" : TotalExenta = "0"
        TotalGravada = "0" : PrecioNeto = "0" : Subtotal = "" : TotalVentaV = "0" : TotalGravado10V = "0" : TotalGravado5V = "0"
        Iva = "0" : TotalIva = "0" : eligiocbo = 0

        Try
            VENTASDETALLEBindingSource.AddNew()

        Catch ex As Exception
        End Try

        Dim c As Integer = DetalleVentaGridView.RowCount
        Dim w As New Funciones.Funciones

        Try
            DetalleVentaGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value = CodProductoTextBox.Text
            DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = CodCodigoTextBox.Text
            DetalleVentaGridView.Rows(c - 1).Cells("CODIGOGrilla").Value = tbxCodigoProducto.Text

            'Verificamos si tiene descuento
            If TxtDescuento.Text <> "" Then
                'si tiene descuento tenemos que ver si es con Porcentaje o un Monto
                PrecioVenta = CDec(tbxPrecioVenta.Text)
                If lblSimboloDesc.Text = "%" Then
                    TotalCalc = FormatNumber((PrecioVenta * CDec(TxtDescuento.Text)) / 100, cantdecimales)
                    PrecioVenta = FormatNumber(PrecioVenta - TotalCalc, cantdecimales)
                Else
                    TotalCalc = CDec(TxtDescuento.Text)
                    PrecioVenta = PrecioVenta - TotalCalc
                End If
            Else
                PrecioVenta = FormatNumber(CDec(tbxPrecioVenta.Text), cantdecimales)
                TotalCalc = 0
            End If

            'VERIFICAMOS SI ES UN TIPO DE PRODUCTO DESCUENTO - METODO REEEE IMPROVISADO. 
            Dim isDesc As Decimal = f.FuncionConsultaDecimal("SERVICIO", "PRODUCTOS", "CODPRODUCTO", CodProductoTextBox.Text)
            If isDesc = 5 Then
                DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value = PrecioVenta
                PrecioVenta = PrecioVenta * -1
            End If

            DetalleVentaGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value = CmbMoneda.SelectedValue
            DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value = PrecioVenta
            DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value = CantDeStockAct
            DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value = CDec(DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value * DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value)
            DetalleVentaGridView.Rows(c - 1).Cells("DESCDataGridViewTextBoxColumn").Value = TotalCalc
            DetalleVentaGridView.Rows(c - 1).Cells("ProductoGrilla").Value = Me.DesProductoTextBox.Text
            DetalleVentaGridView.Rows(c - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value = CmbSucursal.SelectedValue
            DetalleVentaGridView.Rows(c - 1).Cells("LINEANUMERODataGridViewTextBoxColumn").Value = PosicionDato
            DetalleVentaGridView.Rows(c - 1).Cells("SIMBOLO").Value = lblSimboloMoneda.Text

            Precio = FormatNumber(DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value, 0)
            Cantidad = DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value

            'PARA LOS PRODUCTOS PESABLES 
            If (Me.tbxCodigoProducto.Text.IndexOf("200") = 0 Or Me.tbxCodigoProducto.Text.IndexOf("240") = 0 Or ProdPE = 1) Then
                Cantidad = Replace(Cantidad, ".", ",")
                DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value = Cantidad
            End If

            DetalleVentaGridView.Rows(c - 1).Cells("COSTOPROMEDIO").Value = CDec(FIFOCOSTO)
            DetalleVentaGridView.Rows(c - 1).Cells("PRODPROMOCION").Value = PROMO

            Subtotal = DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value
            DetalleVentaGridView.Rows(c - 1).Cells("Subtotal").Value = Subtotal

            CodIvaProducto = cbxTipoIva.SelectedValue 'w.FuncionConsultaString("CODIVA", "PRODUCTOS", "CODPRODUCTO", DetalleVentaGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value)
            CoheficienteIva = w.FuncionConsultaDecimal("COHEFICIENTE", "IVA", "CODIVA", CodIvaProducto)
            PorcIva = w.FuncionConsultaString("PORCENTAJEIVA", "IVA", "CODIVA", CodIvaProducto)

            If CoheficienteIva = 1 Then
                Iva1 = "0"
                Iva = FormatNumber(Iva1, 2)
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = Subtotal
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = 0
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = 0
            ElseIf CoheficienteIva = 1.1 Then
                Iva1 = CDec(Subtotal) / 11
                Iva = FormatNumber(Iva1, 2)
                Iva = Funciones.Cadenas.QuitarCad(Iva, ".")
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = Subtotal
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = 0
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = 0

            ElseIf CoheficienteIva = 1.05 Then
                Iva1 = CDec(Subtotal) / 21
                Iva = FormatNumber(Iva1, 2)
                Iva = Funciones.Cadenas.QuitarCad(Iva, ".")
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = Subtotal
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = 0
                DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = 0
            End If

            DetalleVentaGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = CDec(PorcIva)
            DetalleVentaGridView.Rows(c - 1).Cells("SERIE").Value = tbxNroSerie.Text

            'Tipo de iva
            'PRECIO NETO
            If Subtotal <> "0" And CoheficienteIva <> 1 Then
                PrecioNeto = CDec(Subtotal) - CDec(Iva)
                DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = PrecioNeto
            ElseIf CoheficienteIva = 1 Then
                DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = CDec(Subtotal)
            End If

            Dim sumaimpgrav10, sumaimpgrav5, sumaimpexe As Double
            sumaimpgrav10 = 0 : sumaimpgrav5 = 0 : sumaimpexe = 0 : Subtotal = 0
            Dim i As Integer
            For i = 0 To DetalleVentaGridView.RowCount - 1

                sumaimpgrav10 = sumaimpgrav10 + DetalleVentaGridView.Rows(i).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value
                sumaimpgrav5 = sumaimpgrav5 + DetalleVentaGridView.Rows(i).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value
                sumaimpexe = sumaimpexe + DetalleVentaGridView.Rows(i).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value
                Subtotal = Subtotal + DetalleVentaGridView.Rows(i).Cells("SubTotal").Value

            Next
            TotalGravado10V = sumaimpgrav10
            TotalGravado5V = sumaimpgrav5
            TotalGravada = sumaimpgrav10 + sumaimpgrav5
            TotalVentaV = sumaimpgrav10 + sumaimpgrav5 + sumaimpexe
            total10 = CDec(sumaimpgrav10 / 11)
            total5 = CDec(sumaimpgrav5 / 21)
            TotalExenta = sumaimpexe
            TotalIva = CDec(total10) + CDec(total5)

            If CmbMoneda.SelectedValue = 1 Or CmbMoneda.SelectedValue = Nothing Then
                TotalVentaTextBox.Text = FormatNumber(TotalVentaV, 0)
            Else
                TotalVentaTextBox.Text = FormatNumber(TotalVentaV, cantdecimales)
            End If

            TotalIvaVentaMaskedEdit.Text = FormatNumber(TotalIva, cantdecimales)
            TotalGravadaMaskedEdit.Text = FormatNumber(TotalGravada, cantdecimales)
            TotalExentaMaskedEdit.Text = FormatNumber(TotalExenta, cantdecimales)
            Iva10TextBox1.Text = FormatNumber(total10, cantdecimales)
            Iva5TextBox1.Text = FormatNumber(total5, cantdecimales)

            CantidadVentaMaskedEdit.Text = "" : tbxCodigoProducto.Text = "" : tbxPrecioVenta.Text = "" : DesProductoTextBox.Text = ""
            CodProductoTextBox.Text = "" : CodCodigoTextBox.Text = "" : TxtCantidadEnStock.Text = "" : TxtDescuento.Text = ""

            ErrorCodigoLabel.Visible = False
            TxtDescuento.Appearance.BackColor = SystemColors.ControlLightLight
            tbxCodigoProducto.Focus()

            'ordenamos la grilla
            DetalleVentaGridView.Sort(DetalleVentaGridView.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            CantidadVentaMaskedEdit.Text = "" : tbxCodigoProducto.Text = "" : tbxPrecioVenta.Text = "" : DesProductoTextBox.Text = ""
            TxtCantidadEnStock.Text = "" : TxtDescuento.Text = ""
            tbxCodigoProducto.Focus()

            AgregarDetVentaButton.Visible = True : btnModificarDetVenta.Visible = False : CancelarDetVentaButton.Visible = False : EliminarDetVentaButton.Visible = True
            GrillaModif = 0
            DetalleVentaGridView.Enabled = True
        Catch ex As Exception
            DetalleVentaGridView.Enabled = True
        End Try
    End Sub

    Private Sub CancelarDetVentaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarDetVentaButton.Click
        CantidadVentaMaskedEdit.Text = "" : tbxCodigoProducto.Text = "" : tbxPrecioVenta.Text = "" : DesProductoTextBox.Text = ""
        TxtCantidadEnStock.Text = "" : TxtDescuento.Text = ""
        pnlNroSerie.Visible = False : tbxNroSerie.Text = ""
        tbxCodigoProducto.Focus()
        DetalleVentaGridView.Enabled = True
        AgregarDetVentaButton.Visible = True : btnModificarDetVenta.Visible = False : CancelarDetVentaButton.Visible = False : EliminarDetVentaButton.Visible = True
        GrillaModif = 0
    End Sub

    Private Sub ImprimirReporte()
        Dim f As New Funciones.Funciones
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.Factura

        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes

        If Config9 = "Papel Continuo" Then
            informe.PrintOptions.PaperSize = GetPapersizeID(impresora, "FacturaCogent")
        ElseIf Config9 = "Papel Normal" Then
            informe.PrintOptions.PaperSource = PaperSource.Upper 'bandeja
        End If

        informe.SetDataSource(InfFactura())

        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "RIA")
        End Try

        informe.PrintToPrinter(1, False, 0, 0)

        'Para ver si con esto se limpia un poco el cache del Crystall. Nose si funciona hay que verificar. Si es posible en Guazu. Sarita =(
        informe.Close() : informe.Dispose()
    End Sub

    Private Sub ImprimirReportePresupuesto()
        Dim rpt As New ReportesPersonalizados.Presupuesto
        Me.RepPresupuestoTableAdapter1.Fill(DsFacturacionCompleja.RepPresupuesto, GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)
        Me.RepPresupuestoEmpresaTableAdapter1.Fill(DsFacturacionCompleja.RepPresupuestoEmpresa)

        rpt.SetDataSource(DsFacturacionCompleja)

        Dim frm = New VerInformes

        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

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


    Private Sub tbxCodigoProducto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxCodigoProducto.LostFocus
        If tbxCodigoProducto.Text <> "" Then


            ErrorCodigoLabel.Visible = False
            tbxCodigoProducto.BackColor = SystemColors.ControlLightLight

            If (CodComboTextBox.Text = "") Or (CodCodigoTextBox.Text = "" And CodProductoTextBox.Text = "") Then
                'Verificamos si el Codigo ingresado es correcto
                Dim VCodProducto, VCodCodigo, VDesProducto, VDetalleProducto1, VCantStock, VEstado, VCodTipoClientePrioridad As String
                Dim codigodebarra As String 'Esta variable la utilizo porque desde el lector me trae 13 digitos y en la base de datos tengo 12 y a veces 11
                Dim longitud, existe, ProdServicio, VCodMoneda As Integer

                VCodProducto = "" : VCodCodigo = "" : VDesProducto = "" : VDetalleProducto1 = "" : VCantStock = "" : VEstado = "" : PrecioVentaG = 0 : VCodTipoClientePrioridad = ""

                'antes de hacer cualquier verificacion se debe ver si el codigo introducido le corresponde algun producto
                existe = w.FuncionConsulta("CODPRODUCTO", "CODIGOS", "CODIGO", tbxCodigoProducto.Text)

                If (existe <> 0) Or (tbxCodigoProducto.Text.IndexOf("200") = 0) Or (tbxCodigoProducto.Text.IndexOf("240") = 0) Then

                    VCodProducto = existe
                    VCodCodigo = w.FuncionConsulta("CODCODIGO", "CODIGOS", "CODIGO", tbxCodigoProducto.Text)

                    If VCodProducto = 0 Then
                        longitud = tbxCodigoProducto.TextLength
                        If longitud = 0 Then
                            Exit Sub
                        End If

                        codigodebarra = tbxCodigoProducto.Text.Remove(longitud - 1, 1)
                        If longitud = 1 Then
                            VCodProducto = w.FuncionConsulta("CODPRODUCTO", "CODIGOS", "CODIGO", codigodebarra)
                            VCodCodigo = w.FuncionConsulta("CODCODIGO", "CODIGOS", "CODIGO", codigodebarra)

                            If VCodProducto = 0 Then
                                ErrorCodigoLabel.Visible = True
                                Exit Sub
                            End If
                        Else

                            VCodProducto = w.FuncionConsulta("CODPRODUCTO", "CODIGOS", "CODIGO", codigodebarra)
                            VCodCodigo = w.FuncionConsulta("CODCODIGO", "CODIGOS", "CODIGO", codigodebarra)

                            If VCodProducto = 0 Then ' Primera instancia si con 12 digitos no encuentra 
                                longitud = codigodebarra.Length
                                codigodebarra = codigodebarra.Remove(longitud - 1, 1)
                                VCodProducto = w.FuncionConsulta("CODPRODUCTO", "CODIGOS", "CODIGO", codigodebarra)
                                VCodCodigo = w.FuncionConsulta("CODCODIGO", "CODIGOS", "CODIGO", codigodebarra)
                                If VCodProducto = 0 Then 'Segunda instancia si con 11 no encuentra 
                                    longitud = codigodebarra.Length
                                    codigodebarra = codigodebarra.Remove(7, longitud - 7)
                                    VCodProducto = w.FuncionConsulta("CODPRODUCTO", "CODIGOS", "CODIGO", codigodebarra)
                                    VCodCodigo = w.FuncionConsulta("CODCODIGO", "CODIGOS", "CODIGO", codigodebarra)
                                    If VCodProducto = 0 Then  'Tercera instancia si con 7 digitos  generado por la balanza no encuentra
                                        ErrorCodigoLabel.Visible = True
                                        Exit Sub
                                    Else
                                        'Para traer la cantidad con codigo de balanza
                                        If (tbxCodigoProducto.Text.IndexOf("200") = 0 And tbxCodigoProducto.Text.Length = 13) _
                                        Or (tbxCodigoProducto.Text.IndexOf("240") = 0 And tbxCodigoProducto.Text.Length = 13) Then
                                            Dim CantidadExtraida As String = tbxCodigoProducto.Text.Remove(0, 7)
                                            Dim Entero As String = CantidadExtraida.Remove(2, 4)
                                            Dim Fraccion As String = CantidadExtraida.Remove(0, 2)

                                            CantidadVentaMaskedEdit.Text = Entero + "," + Fraccion
                                            CantidadVentaMaskedEdit.Text = CantidadVentaMaskedEdit.Text.Remove(6, 1)

                                            ProdPE = 1
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        codigodebarra = tbxCodigoProducto.Text
                    End If

                    Dim objCommand As New SqlCommand
                    Try
                        objCommand.CommandText = "SELECT dbo.PRODUCTOS.CODPRODUCTO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CODIGOS.DESCODIGO1, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.ESTADO, dbo.STOCKDEPOSITO.STOCKACTUAL, " & _
                                                 "dbo.PRODUCTOS.SERVICIO, dbo.PRECIO.CODMONEDA  FROM dbo.PRODUCTOS INNER JOIN dbo.PRECIO ON dbo.PRODUCTOS.CODPRODUCTO = dbo.PRECIO.CODPRODUCTO LEFT OUTER JOIN  " & _
                                                 "dbo.CODIGOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO LEFT OUTER JOIN dbo.STOCKDEPOSITO ON dbo.STOCKDEPOSITO.CODCODIGO = dbo.CODIGOS.CODCODIGO " & _
                                                  "WHERE(dbo.CODIGOS.CODCODIGO =" & VCodCodigo & ")"

                        objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                        objCommand.Connection.Open()
                        Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                        If odrConfig.HasRows Then
                            Do While odrConfig.Read()
                                Try
                                    VDetalleProducto1 = odrConfig("DESCODIGO1")
                                Catch ex As Exception
                                End Try

                                VEstado = odrConfig("ESTADO")
                                VDesProducto = odrConfig("DESPRODUCTO")
                                ProdServicio = odrConfig("SERVICIO")
                                servicio = ProdServicio
                                VCodMoneda = odrConfig("CODMONEDA")
                            Loop
                        End If

                        odrConfig.Close()
                        objCommand.Dispose()
                    Catch ex As Exception
                    End Try

                    VCodTipoClientePrioridad = w.FuncionConsulta("CODTIPOCLIENTE", "TIPOCLIENTE", "PRIORIDAD", 1)

                    Dim fx_Valor As Double = 0
                    If IngresarCotCheckBox.Checked = True Then
                        fx_Valor = Cotizacion.Text
                    Else
                        fx_Valor = Cot1FactTextBox.Text
                    End If

                    Dim precio As Double = CDec(w.FuncionConsultaDecimal("PRECIOVENTA", "PRECIO", "CODPRODUCTO=" & VCodProducto & " AND CODTIPOCLIENTE", codtipocliente))

                    precio = MonedaCotizacion.ConvertMoney(precio, VCodMoneda, fx_Valor, CmbMoneda.SelectedValue)
                    tbxPrecioVenta.Text = Math.Round(precio, 2)

                    If precio = 0 Then
                        PrecioVentaG = w.FuncionConsultaString("PRECIO", "CODIGOS", "CODIGO", tbxCodigoProducto.Text)
                        tbxPrecioVenta.Text = PrecioVentaG
                        '" AND CODTIPOCLIENTE", VCodTipoClientePrioridad)
                    Else
                        PrecioVentaG = precio
                        tbxPrecioVenta.Text = PrecioVentaG
                    End If
                    Dim IVA As Integer = w.FuncionConsultaDecimal("CODIVA", "PRODUCTOS", "CODPRODUCTO", VCodProducto)
                    If IVA = 1 Then
                        cbxTipoIva.SelectedValue = IVA
                    ElseIf IVA = 2 Then
                        cbxTipoIva.SelectedValue = IVA
                    Else
                        cbxTipoIva.SelectedValue = IVA
                    End If
                    VCantStock = w.FuncionConsulta("STOCKACTUAL", "STOCKDEPOSITO", "CODDEPOSITO = " & CmbSucursal.SelectedValue & " AND CODCODIGO", VCodCodigo)
                    FIFOCOSTO = w.FuncionConsulta("PRECIO", "CODIGOS", "CODCODIGO", VCodCodigo)
                    PROMO = w.FuncionConsultaString("PROMOCION", "PRODUCTOS", "CODPRODUCTO", VCodProducto)

                    If ProdServicio = 0 Then
                        If VCodProducto = "0" Then
                            VCodProducto = "" : VCodCodigo = "" : VDesProducto = ""
                        Else
                            VDesProducto = VDesProducto + " " + VDetalleProducto1
                        End If

                        If VCantStock > 0 And VEstado = 0 Then
                            CodProductoTextBox.Text = VCodProducto
                            CodCodigoTextBox.Text = VCodCodigo
                            DesProductoTextBox.Text = VDesProducto
                            ErrorCodigoLabel.Visible = False

                        ElseIf VCantStock <= 0 Then
                            If VenderMasQueStock = 0 Then
                                MessageBox.Show("No tiene el stock suficiente para realizar la Venta", "RIA")
                                CodProductoTextBox.Text = "" : CodCodigoTextBox.Text = "" : DesProductoTextBox.Text = "" : tbxPrecioVenta.Text = ""
                                Exit Sub
                            Else
                                CodProductoTextBox.Text = VCodProducto
                                CodCodigoTextBox.Text = VCodCodigo
                                DesProductoTextBox.Text = VDesProducto
                                ErrorCodigoLabel.Visible = False
                            End If

                        Else
                            CodProductoTextBox.Text = "" : CodCodigoTextBox.Text = "" : DesProductoTextBox.Text = "" : tbxPrecioVenta.Text = ""
                            ErrorCodigoLabel.Visible = True
                        End If
                    End If

                    DesProductoTextBox.Text = VDesProducto
                    CodProductoTextBox.Text = VCodProducto
                    CodCodigoTextBox.Text = VCodCodigo

                Else
                    If tbxCodigoProducto.Text <> "" Then
                        ErrorCodigoLabel.Visible = True
                        CodProductoTextBox.Text = "" : CodCodigoTextBox.Text = "" : DesProductoTextBox.Text = "" : tbxPrecioVenta.Text = ""
                    End If
                End If

                CantidadVentaMaskedEdit.Focus()
            End If
        End If

    End Sub

    Private Sub CantidadVentaMaskedEdit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CantidadVentaMaskedEdit.LostFocus
        Dim servicio As Integer
        Dim stockdesdelector As String
        CantidadVentaMaskedEdit.BackColor = SystemColors.ControlLightLight
        lblErrorCantidad.Visible = False


        If (CantidadVentaMaskedEdit.Text <> "") Then
            If CodProductoTextBox.Text <> "" Then
                servicio = w.FuncionConsultaDecimal("SERVICIO", "PRODUCTOS", "CODPRODUCTO", CodProductoTextBox.Text)
            End If

            'La cantidad no puede ser mayor al de stock actual
            If servicio = 1 Then
            Else
                stockdesdelector = f.FuncionConsultaString("STOCKACTUAL", "STOCKDEPOSITO", "CODCODIGO=" & CodCodigoTextBox.Text & " AND CODDEPOSITO", CmbSucursal.SelectedValue)
                TxtCantidadEnStock.Text = stockdesdelector
                If CDec(CantidadVentaMaskedEdit.Text) > CDec(TxtCantidadEnStock.Text) Then
                    If ProdPE = 1 Then
                        If CDec(CantidadVentaMaskedEdit.Text) > CDec(TxtCantidadEnStock.Text) Then
                            lblErrorCantidad.Visible = True
                            ProdPE = 0
                            Exit Sub
                        End If
                    Else
                        lblErrorCantidad.Visible = True
                        Exit Sub
                    End If
                End If
            End If
        ElseIf CantidadVentaMaskedEdit.Text = "" Then
            CantidadVentaMaskedEdit.Text = 1

        End If


    End Sub

    Private Sub tbxPrecioVenta_LostFocus(sender As Object, e As System.EventArgs) Handles tbxPrecioVenta.LostFocus
        tbxPrecioVenta.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub TxtDescuento_LostFocus(sender As Object, e As System.EventArgs) Handles TxtDescuento.LostFocus
        TxtDescuento.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub CmbSucursal_LostFocus(sender As Object, e As System.EventArgs) Handles CmbSucursal.LostFocus
        CmbSucursal.BackColor = SystemColors.ControlLightLight

        If CmbSucursal.Text = "" Then
            CmbSucursal.SelectedIndex = CmbSucursal.SelectedIndex + 1
        End If

    End Sub

    Private Sub TipoComprobanteComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles TipoComprobanteComboBox.LostFocus
        TipoComprobanteComboBox.BackColor = SystemColors.ControlLightLight
        If TipoComprobanteComboBox.Text = "" And TipoComprobanteComboBox.Items.Count > 0 Then
            TipoComprobanteComboBox.SelectedIndex = TipoComprobanteComboBox.SelectedIndex + 1
        End If
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Dim soporte As String = "http://www.cogentpotential.com/soporte/ventas/ventasplus"
        Shell("Explorer " & soporte)
    End Sub

    Private Sub dtpFechaHora_LostFocus(sender As Object, e As System.EventArgs) Handles dtpFechaHora.LostFocus
        dtpFechaHora.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub CmbEvento_LostFocus(sender As Object, e As System.EventArgs)
        CmbEvento.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub VendendorComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles VendendorComboBox.LostFocus
        VendendorComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub CmbMetodo_LostFocus(sender As Object, e As System.EventArgs) Handles CmbMetodo.LostFocus
        CmbMetodo.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub btnClientes_Click(sender As System.Object, e As System.EventArgs) Handles btnClientes.Click
        ClientesV2.Show()
    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

            objCommand.CommandText = "SELECT CONFIG1, CONFIG2, CONFIG3, CONFIG4, CONFIG5, CONFIG6,CONFIG7, CONFIG8,CONFIG9, CONFIG10, CONFIG11, CONFIG12,CONFIG13 FROM MODULO WHERE MODULO_ID = 8"
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
                    Config13 = odrConfig("CONFIG13")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        
    End Sub

    Private Sub CmbCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CmbCliente.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
        lblRucCliente.Text = RUC
    End Sub

    Private Sub CmbTipoVenta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CmbTipoVenta.KeyDown
        If e.KeyCode = Keys.F2 Then
            tbxCodigoProducto.Focus()
        End If
        lblRucCliente.Text = RUC
    End Sub

    Private Sub btnMostrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrarOBS.Click
        pnlObservacion.Visible = True
        pnlObservacion.BringToFront()
        txtObservacion.Enabled = True
        txtObservacion.Focus()
        ' btnMostrarOBS.Image = My.Resources.DisplayActive
    End Sub

    Private Sub txtObservacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlObservacion.Visible = False
        End If
    End Sub

    Private Sub btnCerrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarOBS.Click
        pnlObservacion.Visible = False
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCambiarTipoVenta_Click(sender As System.Object, e As System.EventArgs) Handles btnCambiarTipoVenta.Click
        btcfcuota = 1
        lblCambiarCredito.Visible = True
        Me.dttFechaPrimeraCuota.Enabled = True
        dttFechaPrimeraCuota.Focus()
    End Sub

    Private Sub dttFechaPrimeraCuota_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dttFechaPrimeraCuota.KeyPress
        Dim asentvalor As String
        Dim forpago As Integer = 0
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim conexion1 As System.Data.SqlClient.SqlConnection
        conexion1 = ser.Abrir()
        If KeyAscii = 13 Then
            If btcfcuota = 1 Then
                Dim myTrans As System.Data.SqlClient.SqlTransaction
                Dim conexion As System.Data.SqlClient.SqlConnection
                conexion = ser.Abrir()
                btcambiotipoventa = 1
                Try
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Try
                        InsertaFacturaCobrar(myTrans) ' Inserta en la tabla facturacobrar(cuotas)

                        myTrans.Commit()

                        MessageBox.Show("Factura Actualizada Correctamente", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        If CmbTipoVenta.Text = "Contado" Then
                            btnCambiarTipoVenta.Text = "Cambiar a Crédito"
                            forpago = 2
                        Else
                            btnCambiarTipoVenta.Text = "Cambiar a Contado"
                            forpago = 1
                        End If
                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Actualizar")
                        Catch
                        End Try

                        Throw ex
                    End Try
                Catch
                End Try

                FACTURACOBRARTableAdapter.Fill(DsFacturacionCompleja.FACTURACOBRAR)
                GridViewCuotas.Refresh()

                Dim CodVentaTemp As Integer = VCodVenta

                FechaFiltro()
                If Config1 = "Con todas las Sucursales" Then
                    VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
                Else
                    VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
                End If

                'Buscamos la posicion del registro guardado
                For i = 0 To GridViewFacturacion.RowCount - 1
                    If GridViewFacturacion.Rows(i).Cells("CODVENTADataGridViewTextBoxColumn").Value = CodVentaTemp Then
                        VENTASBindingSource.Position = i
                        Exit For
                    End If
                Next
                btcambiotipoventa = 0
            Else
                TxtCantCuotas.Focus()
            End If
            lblCambiarCredito.Visible = False

            '############################################################# By Saul
            Try
                Dim codcomreg As Integer = CInt(GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)

                If CmbTipoVenta.Text = "Contado" Then
                    asentvalor = "Factura de Venta Contado / " & w.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", GridViewFacturacion.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value)

                Else
                    asentvalor = "Factura de Venta Credito / " & w.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", GridViewFacturacion.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value)
                End If
                ser.Abrir(sqlc)
                cmd.Connection = sqlc

                If CmbTipoVenta.Text = "Contado" Then
                    sql = "UPDATE PARAASENTAR SET DETALLE= '" & asentvalor & "' ,TIPOPAGO=" & forpago & " WHERE REGISTROID=" & codcomreg & " "
                Else
                    sql = "UPDATE PARAASENTAR SET DETALLE= '" & asentvalor & "' ,TIPOPAGO=" & forpago & " WHERE REGISTROID=" & codcomreg & " "
                End If
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans = conexion1.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                Consultas.ConsultaComando(myTrans, sql)
                myTrans.Commit()

            Catch ex As Exception
            End Try
            '#############################################################
        End If

    End Sub

    Private Sub tsNuevaVenta_Click(sender As System.Object, e As System.EventArgs) Handles tsNuevaVenta.Click
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
        Dim soporte As String = "http://www.cogentpotential.com/soporte/ventas/ventasplus"
        Shell("Explorer " & soporte)
    End Sub

    Private Sub tsPanelDeCreditos_Click(sender As System.Object, e As System.EventArgs) Handles tsPanelDeCreditos.Click
        PictureBoxCuotas_Click(Nothing, Nothing)
    End Sub

    Private Sub tsCampoDeObservacion_Click_(sender As System.Object, e As System.EventArgs) Handles tsCampoDeObservacion.Click
        pnlObservacion.Visible = True
        pnlObservacion.BringToFront()
    End Sub

    Private Sub tsMotivoAnulacion_Click(sender As System.Object, e As System.EventArgs) Handles tsMotivoAnulacion.Click
        PanelMotivoAnulacion.Visible = True
        PanelMotivoAnulacion.BringToFront()
    End Sub

    Private Sub tsVentanaDeCobros_Click(sender As System.Object, e As System.EventArgs) Handles tsVentanaDeCobros.Click
        If TxtEstado.Text <> "Para Editar" Then
            CobroV2.tbxNumCliPend.Text = TxtNumCliente.Text
            CobroV2.tbxNumCliPend_LostFocus(Nothing, Nothing)
            CobroV2.Show()
        End If
    End Sub

    Private Sub tsPersonalizarVentas_Click(sender As System.Object, e As System.EventArgs) Handles tsPersonalizarVentas.Click
        ABMConfigPosExpress.Show()
        ABMConfigPosExpress.abrirdesde("Ventas")
    End Sub

    Private Sub tsDuplicarFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsDuplicarFactura.Click
        Me.Cursor = Cursors.AppStarting

        permiso = PermisoAplicado(UsuCodigo, 213) ' Duplicar una Factura
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else
            Me.NroFacturaLabel.Text = ""

            Dim MaxVenta As Integer
            If Config5 = "Mostrar Ultimo Seleccionado" Then
                If Config1 = "Con todas las Sucursales" Then
                    MaxVenta = f.MaximoIsNotNull("CODVENTA", "VENTAS", "CODRANGO")
                Else
                    MaxVenta = f.MaximoIsNotNull("CODVENTA", "VENTAS", "CODSUCURSAL=" & SucCodigo & " AND CODRANGO")
                End If
                TipoComprobanteComboBox.SelectedValue = f.FuncionConsultaDecimal("CODRANGO", "VENTAS", "CODVENTA", MaxVenta)
            End If

            'Obtenemos la fecha
            If Config2 = "Mostrar Fecha Actual" Then
                dtpFechaHora.Value = Today.ToShortDateString

            ElseIf Config2 = "Mostrar Fecha Atrazada 1 Día" Then
                Dim day As Integer = DateTime.Now.AddDays(-1).Day
                Dim mes As Integer = Today.Month
                Dim anho As Integer = Today.Year

                Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                dtpFechaHora.Value = Fecha

            ElseIf Config2 = "Mostrar Fecha Adelantada 1 Día" Then
                Dim day As Integer = DateTime.Now.AddDays(+1).Day
                Dim mes As Integer = Today.Month
                Dim anho As Integer = Today.Year

                Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                dtpFechaHora.Value = Fecha

            ElseIf Config2 = "Mostrar Fecha de Ultima Seleccion" Then
                'Buscamos la Ultima Fecha utilizada
                If MaxVenta <> 0 Then
                    dtpFechaHora.Value = w.FuncionConsultaString("FECHAVENTA", "VENTAS", "CODVENTA", MaxVenta)
                Else 'si da error, con la fecha de hoy
                    dtpFechaHora.Value = Today.ToShortDateString
                End If
            End If

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Dim consulta As String = ""
            consulta = "INSERT INTO VENTAS(CODMONEDA, TOTALVENTA, CODRANGO, MOTIVODESCUENTO, CODEMPRESA, CODUSUARIO, CODCOMPROBANTE, CODCLIENTE,CODSUCURSAL, CODDEPOSITO, FECHAVENTA,TOTALEXENTA, TOTALGRAVADA, COTIZACION1,TIPOVENTA, NOMBRECLIENTE,RUCCLIENTE, MODALIDADPAGO,DIRECCION,CODVENDEDOR,TOTAL10,TOTAL5,CODZONA,CODEVENTO,METODO,TOTALGRAVADO5,TOTALGRAVADO10, NUMVENTATIMBRADO, TOTALIVA, ESTADO, CODPRESUPUESTO) " & _
                "SELECT CODMONEDA, TOTALVENTA, " & TipoComprobanteComboBox.SelectedValue & ", MOTIVODESCUENTO, CODEMPRESA, CODUSUARIO, CODCOMPROBANTE, CODCLIENTE,CODSUCURSAL, CODDEPOSITO, CONVERT(DATETIME,'" & dtpFechaHora.Text & "',103),TOTALEXENTA, TOTALGRAVADA, COTIZACION1,TIPOVENTA, NOMBRECLIENTE,RUCCLIENTE, MODALIDADPAGO,DIRECCION,CODVENDEDOR,TOTAL10,TOTAL5,CODZONA,CODEVENTO,METODO,TOTALGRAVADO5,TOTALGRAVADO10, NUMVENTATIMBRADO, TOTALIVA,0,0 " & _
                "FROM VENTAS WHERE CODVENTA= " & GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value & " " & _
                "SELECT CODVENTA FROM VENTAS WHERE CODVENTA = SCOPE_IDENTITY();"

            cmd.CommandText = consulta
            CodVenta = cmd.ExecuteScalar()
            VCodVenta = CodVenta

            consulta = ""
            consulta = "INSERT INTO VENTASDETALLE(CODPRODUCTO, CODCODIGO, CODVENTA,CODMONEDA, CANTIDADVENTA, PRECIOVENTABRUTO, PRECIOVENTANETO, PRECIOVENTALISTA, IVA, [DESC], CODSUCURSAL,IMPORTEGRABADODIEZ,IMPORTEGRABADOCINCO,IMPORTEEXENTO,COSTOPROMEDIO,PRODPROMOCION,LINEANUMERO ) " & _
                "SELECT CODPRODUCTO, CODCODIGO, " & CodVenta & ",CODMONEDA, CANTIDADVENTA, PRECIOVENTABRUTO, PRECIOVENTANETO, PRECIOVENTALISTA, IVA, [DESC], CODSUCURSAL,IMPORTEGRABADODIEZ,IMPORTEGRABADOCINCO,IMPORTEEXENTO,COSTOPROMEDIO,PRODPROMOCION,LINEANUMERO  " & _
                "FROM VENTASDETALLE WHERE CODVENTA= " & GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value

            cmd.CommandText = consulta
            cmd.ExecuteNonQuery()

            myTrans.Commit()

            FechaFiltro()
            If Config1 = "Con todas las Sucursales" Then
                VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
            Else
                VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
            End If

            'Buscamos la posicion del registro guardado
            For i = 0 To GridViewFacturacion.RowCount - 1
                If GridViewFacturacion.Rows(i).Cells("CODVENTADataGridViewTextBoxColumn").Value = CodVenta Then
                    VENTASBindingSource.Position = i
                    Exit For
                End If
            Next

            PintarCeldas()
            DeshabilitaControles()
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub txtCodigoSupervisor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoSupervisor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If txtCodigoSupervisor.Text <> "" Then
                Dim ExisteCodigo As Integer
                'Verificamos si el codigo de Supervisor existe
                ExisteCodigo = w.FuncionConsultaDecimal("CODUSUARIO", "USUARIO", "CODSUPERVISOR", txtCodigoSupervisor.Text)

                If ExisteCodigo <> 0 Then
                    pnlCodSupervisor.Visible = False
                    pnlCodSupervisor.SendToBack()
                    OKSupervisor = 1
                    If AccionPermiso = "Anular" Then
                        BtnAnular_Click(Nothing, Nothing)
                    ElseIf AccionPermiso = "ReImprimir" Then
                        tsReImprimir_Click(Nothing, Nothing)
                    End If
                Else
                    MessageBox.Show("Código Incorrecto, Intente Otra Vez", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCodigoSupervisor.Focus()
                    OKSupervisor = 0
                    Exit Sub
                End If
                txtCodigoSupervisor.Text = ""
            Else
                OKSupervisor = 0
                pnlCodSupervisor.SendToBack()
                pnlCodSupervisor.Visible = False
            End If

        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tsReImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsReImprimir.Click
        Observaciones = txtObservacion.Text
        If OKSupervisor = 0 Then
            permiso = PermisoAplicado(UsuCodigo, 192)
            If permiso = 0 Then
                AccionPermiso = "ReImprimir"
                pnlCodSupervisor.Visible = True
                pnlCodSupervisor.BringToFront()
                txtCodigoSupervisor.Focus()
                'MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
            Else
                GoTo SupervisorOK
            End If
        Else
SupervisorOK:
            Try
                OKSupervisor = 0
                Dim ValorFiscal As Integer
                Dim tipocomp As Integer = f.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)

                Cantlinea = w.FuncionConsulta("NROLINEASDETALLE", "TIPOCOMPROBANTE", "CODCOMPROBANTE", tipocomp)
                TipoImpresion = w.FuncionConsulta("FORMAIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", tipocomp)
                impresora = w.FuncionConsultaString("IMPRESORA", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)

                If impresora = "" Then
                    MessageBox.Show("Esta maquina No tiene Impresora asignada", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                ValorFiscal = w.FuncionConsulta("VALORFISCAL", "TIPOCOMPROBANTE", "CODCOMPROBANTE", tipocomp)

                'se verifica el tipo de impresion para el tipo de comprobante actuamente seleccionado y de acuerdo a eso realizamos la impresion correspondiente
                'en caso de que este marcado la opcion de imprimir en la ventana "Rango de Comprobantes" 
                If TipoImpresion = 0 Then   'Formato Ticket
                    If ValorFiscal = 0 Then 'Ticket
                        ImprimirTicket()

                    ElseIf ValorFiscal = 1 Then 'Factura
                        ImprimirFactura()
                    End If
                ElseIf TipoImpresion = 1 Then 'Formato Impresora
                    ImprimirReporte()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al Imprimir : " & ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub tsCargarNroFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsCargarNroFactura.Click
        ' permiso = PermisoAplicado(UsuCodigo, 41) ' Cargar Nro. de Factura Manual
        If ModificarFactura = 0 Then
            BtnNuevoP3.SendToBack()
        Else
            NroFactText.Visible = True
            If NroFacturaLabel.Text <> "" Then
                NroFactText.Text = NroFacturaLabel.Text
            Else
                NroFactText.Text = ""
            End If
            NroFactText.Focus()
            NroFacturaLabel.Visible = False
            BtnGuardarP3.Visible = True
            BtnCancelarP3.Visible = True
            BtnNuevoP3.Visible = False
            Me.tsCargarNroFactura.Enabled = False
            'Aqui al dar Guardar (BtnGuardarP3) se Actualiza Auditoria
        End If
    End Sub

    Private Sub tsModificarNroFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsModificarNroFactura.Click
        permiso = PermisoAplicado(UsuCodigo, 214) 'Modificar Nro. Factura ya Aprobada
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else
            Dim nvoNumero As String = InputBox("Ingrese el nuevo Nro. de Factura: ", " Modificar Nro. Factura", Me.NroFacturaLabel.Text)
            If nvoNumero <> Me.NroFacturaLabel.Text And nvoNumero <> "" Then
                Try
                    Dim consulta As System.String
                    Dim conexion As System.Data.SqlClient.SqlConnection

                    'Verificamos que el nro de factura nose repita dentro del mismo timbrado
                    TimbradoFactura = f.FuncionConsulta("TIMBRADO", "DETPC", " ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)
                    Dim ExisteNrofactura As String
                    ExisteNrofactura = w.FuncionConsultaString("NUMVENTA", "VENTAS", "ESTADO = 1 AND NUMVENTA = '" & nvoNumero & "' AND NUMVENTATIMBRADO", TimbradoFactura)

                    If ExisteNrofactura <> 0 Then
                        If MessageBox.Show("Ya existe una Factura Aprobada con el mismo Nro. dentro del Timbrado, ¿Desea Duplicarlo de todos modos?", "RIA", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = MsgBoxResult.Yes Then
                            conexion = ser.Abrir()
                            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                            consulta = "UPDATE VENTAS SET NUMVENTA='" & nvoNumero & "' WHERE CODVENTA=" & CDec(Me.VCodVenta) & ""
                            Consultas.ConsultaComando(myTrans, consulta)

                            myTrans.Commit()


                            FechaFiltro()
                            If Config1 = "Con todas las Sucursales" Then
                                VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
                            Else
                                VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
                            End If

                            Me.GridViewFacturacion.Refresh()
                        End If
                    Else
                        conexion = ser.Abrir()
                        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                        consulta = "UPDATE VENTAS SET NUMVENTA='" & nvoNumero & "' WHERE CODVENTA=" & CDec(Me.VCodVenta) & ""
                        Consultas.ConsultaComando(myTrans, consulta)

                        myTrans.Commit()


                        FechaFiltro()
                        If Config1 = "Con todas las Sucursales" Then
                            VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
                        Else
                            VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
                        End If

                        Me.GridViewFacturacion.Refresh()
                    End If

                Catch ex As Exception
                    MsgBox(ex)
                End Try
            End If
            PintarCeldas()
        End If
    End Sub

    Private Sub lblProximoNro_Click(sender As System.Object, e As System.EventArgs) Handles lblProximoNro.Click
        Dim conexion As System.Data.SqlClient.SqlConnection
        conexion = ser.Abrir()
        Try
            Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString, RANGOIDACTIVO As String
            Dim NroDigitos As Integer

            NumSucursal = SucCodigo
            'NumMaquina = NumMaquinaGlobal

            If Config1 = "Con todas las Sucursales" Then
                RANGOIDACTIVO = w.FuncionConsultaString("RANDOID", "DETPC", "ACTIVO=1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)
            Else
                RANGOIDACTIVO = w.FuncionConsultaString("RANDOID", "DETPC", "ACTIVO=1 AND CODCOMPROBANTE= " & tipocomp2 & " AND IP", CodigoMaquina)
            End If


            Dim dadetpc As New SqlDataAdapter("Select CODSUCURSAL, IP, ULTIMO, RANGO2,NRODIGITOS FROM DETPC WHERE (ULTIMO < RANGO2) AND ACTIVO = 1 AND RANDOID=" & RANGOIDACTIVO & "", conexion)
            Dim dtdetpc As New DataTable
            dadetpc.Fill(dtdetpc)
            Dim drdetpc As DataRow
            drdetpc = dtdetpc.Rows(0)

            NroDigitos = drdetpc("NRODIGITOS")
            'Validamos que haya rango para ese TipoComprobante
            NroRango = drdetpc("ULTIMO")
            NroRango = NroRango + 1
            NroRango2 = drdetpc("RANGO2")

            If CDec(NroRango) > CDec(NroRango2) Then
                NumVentaV = ""
                'supero el ultimo
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

            NumVentaV = NumSucTimbrado & "." & NumMaquina & "." & NroRangoString

            lblProximoNro.Text = "Próximo Nro de Factura: " + NumVentaV
            'MessageBox.Show("Próximo Nro de Factura para comprobante '" + TipoComprobanteComboBox.Text + "': " + NumVenta, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NumVentaV = ""

        Catch ex As Exception
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub tsQuemarProxNro_Click(sender As System.Object, e As System.EventArgs) Handles tsQuemarProxNro.Click
        permiso = PermisoAplicado(UsuCodigo, 212) 'Crear una Factura en Blanco
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else

            Dim consulta As System.String
            Dim UltimaVenta, UltimaVentaFecha As Integer
            Dim RangoID As Integer
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            Me.Cursor = Cursors.AppStarting
            conexion = ser.Abrir()
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            Try
                Dim codsuc As Integer
                'Verificar si el Comprobante está Activo
                ' RangoID = f.FuncionConsulta("ACTIVO", "DETPC","RANDOID", TipoComprobanteComboBox.SelectedValue)
                If Config1 = "Con todas las Sucursales" Then 'Porque puede haber varios rangos activos en dif. sucursales
                    tipocomp2 = f.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", TipoComprobanteComboBox.SelectedValue)
                    codsuc = w.FuncionConsultaString("CODSUCURSAL", "DETPC", "ACTIVO=1 AND CODCOMPROBANTE= " & tipocomp2 & " AND IP", CodigoMaquina)
                    RangoID = TipoComprobanteComboBox.SelectedValue
                    UltimaVenta = f.MaximoIsNotNull("CODVENTA", "VENTAS", "CODRANGO")
                Else
                    codsuc = SucCodigo
                    RangoID = w.FuncionConsultaString("RANDOID", "DETPC", "ACTIVO=1 AND CODCOMPROBANTE= " & tipocomp2 & " AND IP", CodigoMaquina)
                    UltimaVenta = f.MaximoIsNotNull("CODVENTA", "VENTAS", "CODSUCURSAL=" & SucCodigo & " AND CODRANGO")
                End If

                If RangoID = 0 Or String.IsNullOrEmpty(RangoID) = True Then
                    MessageBox.Show("No hay comprobantes activos para esta máquina o No tiene asignado un nro. de comprobante", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TipoComprobanteComboBox.Focus()
                    'BtnImprimir.Image = My.Resources.Approve
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

                CalculaNroFactura(RangoID) 'Se calcula el Nro de factura a Generar de forma automatica

                'se debe obtener el ultimo nro insertado
                UltimaVenta = f.Maximo("CODVENTA", "VENTAS")
                UltimaVentaFecha = f.MaximoIsNotNull("CODVENTA", "VENTAS", "FECHAVENTA")
                VCodVenta = UltimaVenta + 1

                'Obtenemos la fecha
                If Config2 = "Mostrar Fecha Actual" Then
                    dtpFechaHora.Value = Today.ToShortDateString

                ElseIf Config2 = "Mostrar Fecha Atrazada 1 Día" Then
                    Dim day As Integer = DateTime.Now.AddDays(-1).Day
                    Dim mes As Integer = Today.Month
                    Dim anho As Integer = Today.Year

                    Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                    dtpFechaHora.Value = Fecha

                ElseIf Config2 = "Mostrar Fecha Adelantada 1 Día" Then
                    Dim day As Integer = DateTime.Now.AddDays(+1).Day
                    Dim mes As Integer = Today.Month
                    Dim anho As Integer = Today.Year

                    Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                    dtpFechaHora.Value = Fecha

                ElseIf Config2 = "Mostrar Fecha de Ultima Seleccion" Then
                    'Buscamos la Ultima Fecha utilizada
                    If UltimaVenta <> 0 Then
                        dtpFechaHora.Value = w.FuncionConsultaString("FECHAVENTA", "VENTAS", "CODVENTA", UltimaVentaFecha)
                    End If
                End If

                'Nrango acaba de calcular en CalculaNroFactura()
                consulta = "INSERT INTO VENTAS (CODCOMPROBANTE,NUMVENTA,FECHAVENTA,ESTADO,CODSUCURSAL,CODRANGO,CODUSUARIO) VALUES (" & tipocomp2 & ", '" & NumVentaV & "', CONVERT(DATETIME,'" & dtpFechaHora.Text & "',103) , 2, " & codsuc & ", " & RangoID & "," & UsuCodigo & ")"


                consulta = consulta + " UPDATE DETPC SET ULTIMO =" & NroRango & " WHERE RANDOID =" & RangoID & ""
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()

                '------------------------------------------------------------------- CONTABILIDAD --------------------------------------------------------
                'Obtenemos los valores que se utilizaron el modulo de contabilidad - by Yolanda Zelaya 
                Dim ConceptoAsiento, Timbrado, IVA5, IVA10, IVAEXE, TOTALIVA, ClienteProveedor, TOTALVENTACONT As String
                Dim RgMerc, RgMonet As Integer

                IVA5 = 0 : IVA10 = 0 : IVAEXE = 0 : TOTALIVA = 0 : TOTALVENTACONT = 0 : ClienteProveedor = 0
                RgMonet = 1

                If CmbMetodo.Text = "Simplificado" Then
                    RgMerc = 1
                End If

                Timbrado = 0

                Cotizacion1V = "1"

                QuemandoNro = 1
                ConceptoAsiento = "FACTURA ANULADA"
                ReglaContable(IVAEXE, IVA5, IVA10, TOTALIVA, "VENTAS", CDec(VCodVenta), "CODVENTA", ConceptoAsiento, RgMerc, RgMonet, _
                              CmbMoneda.SelectedValue, Cotizacion1V, NumVentaV, dtpFechaHora.Text, TOTALVENTACONT, "8", Timbrado, ClienteProveedor, SucCodigo)
                QuemandoNro = 0
                '-------------------------------------------------------------------------------------------------------------------------------------------

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MsgBox(mensajeerror)
                Throw
            End Try

            '---------------------------- DESACTIVA RANGO ----------------------------
            'Verificamos si es el ultimo Nro del rango de comprobantes y ponemos como desabilitado dicho rango

            Dim hastanro, ultimo, IDRango As Integer

            ultimo = w.FuncionConsulta("ULTIMO", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)

            hastanro = w.FuncionConsulta("RANGO2", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)


            If hastanro = ultimo Then
                'conexion = ser.Abrir()

                Try
                    IDRango = TipoComprobanteComboBox.SelectedValue

                    consulta = "UPDATE DETPC SET ACTIVO=0 WHERE RANDOID =" & IDRango & ""
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()
                Catch ex As Exception

                End Try
            End If

            conexion.Close()

            FechaFiltro()
            If Config1 = "Con todas las Sucursales" Then
                VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
            Else
                VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
            End If
            Me.Cursor = Cursors.Arrow
        End If
        lblProximoNro_Click(Nothing, Nothing)
        PintarCeldas()
    End Sub

    Private Sub btnBuscProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscProductos.Click
        CodCodigoTextBox.Text = "" : CodComboTextBox.Text = ""

        UltraPopupControlContainer1.PopupControl = ProductosGroupBox
        UltraPopupControlContainer1.Show()

        CheckBox1.Checked = True
        BuscarProductoTextBox.Text = ""
        BuscarProductoTextBox.Focus()
    End Sub

    Private Sub btnMostrarOBS_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles btnMostrarOBS.MouseDown
        If btnMostrarOBS.Enabled = True Then
            btnMostrarOBS.Image = My.Resources.DisplayMouseDown
        End If
    End Sub

    Private Sub NuevoPictureBox_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NuevoPictureBox.MouseUp
        If NuevoPictureBox.Enabled = True Then
            NuevoPictureBox.Image = My.Resources.New_
        End If
    End Sub

    Private Sub EliminarPictureBox_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles EliminarPictureBox.MouseUp
        If EliminarPictureBox.Enabled = True Then
            EliminarPictureBox.Image = My.Resources.Delete
        End If
    End Sub

    Private Sub ModificarPictureBox_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ModificarPictureBox.MouseUp
        If ModificarPictureBox.Enabled = True Then
            ModificarPictureBox.Image = My.Resources.Edit
        End If
    End Sub

    Private Sub GuardarPictureBox_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GuardarPictureBox.MouseUp
        If GuardarPictureBox.Enabled = True Then
            GuardarPictureBox.Image = My.Resources.Save
        End If
    End Sub

    Private Sub CancelarPictureBox_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CancelarPictureBox.MouseUp
        If CancelarPictureBox.Enabled = True Then
            CancelarPictureBox.Image = My.Resources.SaveCancel
        End If
    End Sub

    Private Sub BtnImprimir_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles BtnImprimir.MouseUp
        If BtnImprimir.Enabled = True Then
            BtnImprimir.Image = My.Resources.Approve
        End If
    End Sub

    Private Sub PictureBoxMotivoAnulacion_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxMotivoAnulacion.MouseUp
        If PictureBoxMotivoAnulacion.Enabled = True Then
            PictureBoxMotivoAnulacion.Image = My.Resources.Anull
        End If
    End Sub

    Private Sub btnMostrarOBS_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If btnMostrarOBS.Enabled = True Then
            btnMostrarOBS.Image = My.Resources.Display
        End If
    End Sub

    Private Sub tsAplicarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles tsAplicarFiltros.Click
        Dim fechaDesdeEspecial As String
        Dim fechaHastaEspecial As String
        CmbAño.Text = ""
        CmbMes.Text = "Filtros"
        If errorFiltroFecha = 0 And errorFiltroRango = 0 And Trim(tsFiltroFechaE.Text) <> "" And (Trim(tsFiltroRDesde.Text) <> "" Or Trim(tsFiltroRHasta.Text) <> "") Then
            MsgBox("Se introdujeron filtros en Fecha Específica y Rango de Fechas. El Sistema toma por defecto la Fecha Específica", MsgBoxStyle.Information, "Error en Filtro")
        ElseIf Trim(tsFiltroNroCliente.Text) <> "" And Trim(tsFiltroNomCliente.Text) <> "" Then
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
            If Trim(tsFiltroRDesde.Text) <> "" And Trim(tsFiltroRHasta.Text) <> "" And errorFiltroRango = 0 Then
                If errorFiltroRango = 0 Then
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

        If Config1 = "Con todas las Sucursales" Then
            VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, fechaDesdeEspecial, fechaHastaEspecial)
        Else
            VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, fechaDesdeEspecial, fechaHastaEspecial, SucCodigo)
        End If

        If Trim(tsFiltroNroCliente.Text) <> "" Then
            VENTASBindingSource.Filter = "NUMCLIENTE = " & Trim(tsFiltroNroCliente.Text)
        Else
            If Trim(tsFiltroNomCliente.Text) <> "" Then
                VENTASBindingSource.Filter = "NOMBRECLIENTE like '%" & Trim(tsFiltroNomCliente.Text) & "%'"
            End If
        End If
        lblDGVCant.Text = "Cant. de Items:" & GridViewFacturacion.RowCount
    End Sub

    Private Sub tsLimpiarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles tsLimpiarFiltros.Click
        tsFiltroFechaE.Text = "" : tsFiltroFechaE.BackColor = SystemColors.Window
        tsFiltroRDesde.Text = "" : tsFiltroRDesde.BackColor = SystemColors.Window
        tsFiltroRHasta.Text = "" : tsFiltroRHasta.BackColor = SystemColors.Window
        tsFiltroNroCliente.Text = ""
        tsFiltroNomCliente.Text = ""
        InicializaFechaFiltro()
        If CmbMes.Text = "Filtros" Then
            CmbMes.SelectedIndex = Today.Month - 1
        End If
        If CmbAño.Text = "" Then
            CmbAño.SelectedText = Today.Year.ToString
        End If
        BtnFiltro_Click(Nothing, Nothing)
    End Sub

    Private Sub tsFiltroNroCliente_TextChanged(sender As Object, e As System.EventArgs) Handles tsFiltroNroCliente.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(tsFiltroNroCliente.Text, "^\d*$") Then
            tsFiltroNroCliente.Text = tsFiltroNroCliente.Text.Remove(tsFiltroNroCliente.Text.Length - 1)
            tsFiltroNroCliente.SelectionStart = tsFiltroNroCliente.Text.Length
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
                errorFiltroRango = 0
                tsFiltroRDesde.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroRango = 1
                MsgBox("El Sistema no tomará el Filtro Rango de Fechas. Por Favor Ingrese una Fecha válida en Fecha Desde", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroRDesde.BackColor = Color.Pink
            End Try
        ElseIf errorFiltroRango = 1 Then
            errorFiltroRango = 0
            tsFiltroRDesde.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub tsFiltroRHasta_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroRHasta.LostFocus
        If Trim(tsFiltroRHasta.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroRHasta.Text)
                errorFiltroRango = 0
                tsFiltroRHasta.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroRango = 1
                MsgBox("El Sistema no tomará el Filtro Rango de Fechas. Por Favor Ingrese una Fecha válida en Fecha Hasta", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroRHasta.BackColor = Color.Pink
            End Try
        ElseIf errorFiltroRango = 1 Then
            errorFiltroRango = 0
            tsFiltroRHasta.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub dgwClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgwClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgwClientes.RowCount <> 0 Then
                'Dim index As Integer = CLIENTESBindingSource.Position
                Dim index As Integer = dgwClientes.CurrentRow.Index

                TxtNumCliente.Text = dgwClientes.Rows(index).Cells("NUMCLIENTEDataGridViewTextBoxColumn").Value
                CmbCliente.SelectedValue = dgwClientes.Rows(index).Cells("CODCLIENTEDataGridViewTextBoxColumn1").Value
                'CmbCliente.Text = dgwClientes.Rows(index).Cells("NOMBREDataGridViewTextBoxColumn").Value

                PanelCliente = 1

                UltraPopupControlContainer1.Close()

                'CmbCliente.Focus()
                CmbCliente.Refresh()

                TxtNumCliente.Focus()


            End If
        End If
    End Sub

    Private Sub CmbTipoVenta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbTipoVenta.SelectedIndexChanged
        banchangecmbventa = 1
        If CmbTipoVenta.Text = "Contado" Then
            TxTTipoVenta.Text = "0"
            TxtDescuento.Enabled = True

        ElseIf CmbTipoVenta.Text = "Crédito" Then
            permiso = PermisoAplicado(UsuCodigo, 31)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para Vender a Credito", "Pos Express")
                TxTTipoVenta.Text = "0"
                dtpFechaHora.Focus()
            Else
                TxTTipoVenta.Text = "1"
                TxtDescuento.Enabled = True
            End If

            'ElseIf CmbTipoVenta.Text = "Bonificación" Then
            '    TxTTipoVenta.Text = "2"
            '    TxtDescuento.Enabled = False

            'ElseIf CmbTipoVenta.Text = "Cambio" Then
            '    TxTTipoVenta.Text = "3"
            '    TxtDescuento.Enabled = False

            'ElseIf CmbTipoVenta.Text = "Otros" Then
            '    TxTTipoVenta.Text = "4"
            '    TxtDescuento.Enabled = False

        End If

        banchangecmbventa = 0
    End Sub

    Private Sub btnCerrarPanelSupervisor_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarPanelSupervisor.Click
        pnlCodSupervisor.Visible = False
        pnlCodSupervisor.SendToBack()
    End Sub

    Private Sub ProductosGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ProductosGridView.KeyDown
        Dim f As New Funciones.Funciones
        Dim i As Integer
        PrecioVentaG = 0
        i = ProductosGridView.CurrentRow.Index
        Try
            If e.KeyCode = Keys.Enter Then
                If ProductosGridView.RowCount = 0 Then
                    BuscarProductoTextBox.Text = ""
                    CodCodigoTextBox.Text = ""
                    tbxCodigoProducto.Focus()
                    UltraPopupControlContainer1.Close()
                Else

                    If IsDBNull(ProductosGridView.CurrentRow) Then
                        BuscarProductoTextBox.Text = ""
                        tbxCodigoProducto.Focus()
                        UltraPopupControlContainer1.Close()
                    Else
                        If IsDBNull(ProductosGridView.Rows(i).Cells("CODIGODataGridViewTextBoxColumn").Value) And IsDBNull(ProductosGridView.Rows(i).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) And _
                        IsDBNull(ProductosGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) And IsDBNull(ProductosGridView.Rows(i).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value) And _
                        IsDBNull(ProductosGridView.Rows(i).Cells("PRECIOVENTADataGridViewTextBoxColumn").Value) Then
                            MessageBox.Show("El Producto Seleccionado no contiene todos los datos necesarios para la venta", "RIA")
                        Else
                            tbxCodigoProducto.Text = ProductosGridView.Rows(i).Cells("CODIGODataGridViewTextBoxColumn").Value
                            CodProductoTextBox.Text = ProductosGridView.Rows(i).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                            CodCodigoTextBox.Text = ProductosGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value

                            If IsDBNull(ProductosGridView.Rows(i).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value) Then
                            Else
                                DesProductoTextBox.Text = ProductosGridView.Rows(i).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
                            End If

                            Dim fx_Valor As Double = 0
                            If IngresarCotCheckBox.Checked = True Then
                                fx_Valor = Cotizacion.Text
                            Else
                                fx_Valor = Cot1FactTextBox.Text
                            End If

                            Dim precio As Double = MonedaCotizacion.ConvertMoney(CDec(ProductosGridView.Rows(i).Cells("PRECIOVENTADataGridViewTextBoxColumn").Value), CDec(ProductosGridView.CurrentRow.Cells("CODMONEDA").Value), fx_Valor, CmbMoneda.SelectedValue)
                            tbxPrecioVenta.Text = Math.Round(precio, 2)
                            PrecioVentaG = tbxPrecioVenta.Text

                            If IsDBNull(ProductosGridView.Rows(i).Cells("STOCKACTUALDataGridViewTextBoxColumn").Value) Then
                                TxtCantidadEnStock.Text = "0"
                            Else
                                TxtCantidadEnStock.Text = ProductosGridView.Rows(i).Cells("STOCKACTUALDataGridViewTextBoxColumn").Value
                            End If
                            If IsDBNull(ProductosGridView.CurrentRow.Cells("COSTOFIFO").Value) Then
                                FIFOCOSTO = 1
                            Else
                                FIFOCOSTO = ProductosGridView.CurrentRow.Cells("COSTOFIFO").Value
                            End If
                            If IsDBNull(ProductosGridView.CurrentRow.Cells("PROMOCION").Value) Then
                                PROMO = False
                            Else
                                PROMO = ProductosGridView.CurrentRow.Cells("PROMOCION").Value
                            End If
                            If Not IsDBNull(ProductosGridView.CurrentRow.Cells("CODIVA").Value) Then
                                cbxTipoIva.SelectedValue = ProductosGridView.CurrentRow.Cells("CODIVA").Value
                            End If
                        End If

                        lblSimboloMoneda.Text = w.FuncionConsultaString2("SIMBOLO", "MONEDA", "CODMONEDA", CmbMoneda.SelectedValue)
                        BuscarProductoTextBox.Text = ""

                        Dim serie As New serie_class
                        tbxNroSerie.Text = serie.Serie(ProductosGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value, ProductosGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value)

                        lblSimboloMoneda.Text = w.FuncionConsultaString2("SIMBOLO", "MONEDA", "CODMONEDA", CmbMoneda.SelectedValue)
                        BuscarProductoTextBox.Text = ""

                        'si el producto tiene # y esta habilitado para trabajar con nro de serie ahi mostramos el panel para nro de serie
                        Dim DescripcionSerie_Actual As String = DesProductoTextBox.Text
                        If DescripcionSerie_Actual.Contains("#") And Config13 = "Si" Then
                            pnlNroSerie.Visible = True
                            pnlNroSerie.BringToFront()
                            tbxNroSerie.Focus()
                        Else
                            CantidadVentaMaskedEdit.Focus()
                        End If

                        UltraPopupControlContainer1.Close()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CheckBox1.Checked = False Then
                Try
                    If VenderMasQueStock = 0 Then
                        Me.CODIGOSTableAdapter.Fill(Me.DsFacturacionCompleja.CODIGOS, SucCodigo, codtipocliente)
                    Else
                        Me.CODIGOSTableAdapter.FillSinStock(Me.DsFacturacionCompleja.CODIGOS, CDec(CmbSucursal.SelectedValue), codtipocliente)
                    End If
                Catch ex As Exception

                End Try
            Else
                Try
                    If VenderMasQueStock = 0 Then
                        Me.CODIGOSTableAdapter.FillBy(Me.DsFacturacionCompleja.CODIGOS, SucCodigo)
                    Else
                        Me.CODIGOSTableAdapter.FillBySinStockSoloSuc(Me.DsFacturacionCompleja.CODIGOS, SucCodigo)
                    End If
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsImportarSepsa_Click(sender As System.Object, e As System.EventArgs) Handles tsImportarSepsa.Click
        permiso = PermisoAplicado(UsuCodigo, 263)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Crear/Importar una Venta", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            'Una vez que obtenemos la direccion y el nombre del archivo debemos empezar a leer y cargar los datos del XML
            NuevoPictureBox_Click(Nothing, Nothing)

            OpenFileDialog1.Title = "Por favor Seleccione un Archivo"
            OpenFileDialog1.InitialDirectory = "C:"
            OpenFileDialog1.ShowDialog()

            'Abrimos y leemos el archivo
            Dim XmlDocument As New System.Xml.XmlDocument
            Dim CreationDate As Date
            Dim Codigo, Producto, TipoIva, PrecioUnit, Cantidad, GlnCliente, ProductosNoEncontrados, NroOrdenSepsaCab As String
            Dim CodCodigo, CodProducto, Costo, c, PorcIVA, MontoIva, CantItem, ExisteProducto, NumClienteCab As Integer
            Dim SubTotal, Iva5, Iva10, Excento, TotalIva, TotalGravada, Gravada5, Gravada10, TotalExenta, total10, total5, TotalFactura As Double

            Producto = "" : TipoIva = "" : Codigo = "" : SubTotal = 0 : Iva5 = 0 : Iva10 = 0 : Excento = 0 : TotalIva = 0 : TotalGravada = 0 : ProductosNoEncontrados = ""
            TotalExenta = 0 : total10 = 0 : total5 = 0 : TotalFactura = 0 : Gravada5 = 0 : Gravada10 = 0 : GlnCliente = "" : PorcIVA = 0 : MontoIva = 0 : CantItem = 0 : TotalGravado10V = "0" : TotalGravado5V = "0" : TotalVentaV = "0" ' AGREGUE : TotalGravado10V = "0" : TotalGravado5V = "0" : TotalVentaV = "0" que son variables globales para insertar en la cabecera

            XmlDocument.Load(LocalizacionFile)
            Dim Node As System.Xml.XmlNode

            'Obtenemos la Fecha de la Venta
            Try
                For Each Node In XmlDocument.Item("ns5:StandardBusinessDocument").Item("ns5:StandardBusinessDocumentHeader").Item("ns5:DocumentIdentification")
                    Try
                        If Node.Name = "ns5:InstanceIdentifier" Then
                            OrdCompraSEPSA = Node.InnerText
                            Exit For
                        End If
                    Catch ex As Exception
                    End Try
                Next Node
            Catch ex As Exception
                MessageBox.Show("Formato de Archivo Incorrecto, Por favor verifique el Archivo", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End Try

            'Obtenemos los Datos del Cliente y Fecha de Entrega
            Try
                For Each Node In XmlDocument.Item("ns5:StandardBusinessDocument").Item("message").Item("transaction").Item("command").Item("documentCommand").Item("documentCommandOperand").Item("order").Item("orderPartyInformation")
                    Try
                        If Node.Name = "buyer" Then
                            GlnCliente = Node.Item("gln").InnerText
                            TxtNumCliente.Text = f.FuncionConsultaString("NUMCLIENTE", "CLIENTES", "SEPSA", GlnCliente)
                            NumClienteCab = TxtNumCliente.Text
                            TxtNumCliente_LostFocus(Nothing, Nothing)
                            CmbCliente_LostFocus(Nothing, Nothing)
                            TipoComprobanteComboBox.Focus()
                            Exit For
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Cliente inexistente. Favor verificar el Código Sepsa del Cliente", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        CancelarPictureBox_Click(Nothing, Nothing)
                        Exit Sub
                        'lblNombreFantasia.Text = "Cliente Inexistente"
                    End Try
                Next Node
                For Each Node In XmlDocument.Item("ns5:StandardBusinessDocument").Item("message").Item("transaction").Item("command").Item("documentCommand").Item("documentCommandOperand").Item("order").Item("orderLogisticalInformation").Item("orderLogisticalDateGroup").Item("requestedDeliveryDate")
                    If Node.Name = "date" Then
                        CreationDate = Node.InnerText
                        dtpFechaHora.Text = CreationDate.ToString("dd/MM/yyy")
                        Exit For
                    End If
                Next Node
            Catch ex As Exception
                MessageBox.Show("Formato de Archivo Incorrecto, Por favor verifique el Archivo", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End Try

            Dim cantfacturas As Integer = 1
            Dim CantlineaFact As Integer = w.FuncionConsulta("dbo.TIPOCOMPROBANTE.NROLINEASDETALLE", "dbo.TIPOCOMPROBANTE INNER JOIN dbo.DETPC ON dbo.TIPOCOMPROBANTE.CODCOMPROBANTE = dbo.DETPC.CODCOMPROBANTE", "dbo.DETPC.RANDOID", TipoComprobanteComboBox.SelectedValue)
            c = 0

            'Obtenemos los Datos del detalle (Productos)
            For Each Node In XmlDocument.Item("ns5:StandardBusinessDocument").Item("message").Item("transaction").Item("command").Item("documentCommand").Item("documentCommandOperand").Item("order")
                Try
                    If Node.Name = "orderLineItem" Then
                        CantItem = CantItem + 1
                        Cantidad = Node.Item("requestedQuantity").InnerText : Cantidad = Replace(Cantidad, ".", ",") : Cantidad = FormatNumber(Cantidad, 0)
                        Codigo = Node.Item("tradeItemIdentification").Item("gtin").InnerText
                        PrecioUnit = Node.Item("netPrice").Item("amount").Item("monetaryAmount").InnerText : PrecioUnit = Replace(PrecioUnit, ".", ",")

                        PorcIVA = Node.Item("allowanceCharge").Item("monetaryAmountOrPercentage").Item("percentage").InnerText
                        If PorcIVA = 100 Then 'Iva 10
                            MontoIva = PrecioUnit * 0.1
                        ElseIf PorcIVA = 50 Then 'Iva 5
                            MontoIva = PrecioUnit * 0.05
                        End If
                        PrecioUnit = PrecioUnit + MontoIva

                        'Debemos obtener los datos necesarios del producto para insertarlo en la grilla
                        Dim objCommand As New SqlCommand
                        Try
                            objCommand.CommandText = "SELECt dbo.PRODUCTOS.CODPRODUCTO, dbo.PRODUCTOS.DESPRODUCTO, dbo.PRODUCTOS.PROMOCION, dbo.CODIGOS.CODCODIGO, " & _
                                                     "dbo.CODIGOS.PRECIO, dbo.IVA.DESIVA   FROM dbo.PRODUCTOS INNER JOIN dbo.CODIGOS ON " & _
                                                     "dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO INNER JOIN dbo.IVA ON dbo.PRODUCTOS.CODIVA = dbo.IVA.CODIVA " & _
                                                     "WHERE dbo.CODIGOS.CODIGO = '" & Codigo & "'"

                            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                            objCommand.Connection.Open()
                            Dim odrProductos As SqlDataReader = objCommand.ExecuteReader()

                            If odrProductos.HasRows Then
                                Do While odrProductos.Read()
                                    CodCodigo = odrProductos("CODCODIGO")
                                    CodProducto = odrProductos("CODPRODUCTO")
                                    Producto = odrProductos("DESPRODUCTO")
                                    TipoIva = odrProductos("DESIVA")
                                    Costo = odrProductos("PRECIO")
                                    ExisteProducto = 1
                                Loop
                            Else
                                ProductosNoEncontrados = vbCrLf & "Item Nro : " & CantItem & "  Codigo : " & Codigo & ProductosNoEncontrados
                                ExisteProducto = 0
                            End If

                            odrProductos.Close()
                            objCommand.Dispose()
                        Catch ex As Exception
                        End Try

                        If c + 1 <= CantlineaFact Then
                            'Insertamos en la Grilla los productos
                            If ExisteProducto = 1 Then
                                Try
                                    VENTASDETALLEBindingSource.AddNew()
                                    c = DetalleVentaGridView.RowCount

                                    DetalleVentaGridView.Rows(c - 1).Cells("COSTOPROMEDIO").Value = CDec(Costo) ' AGREGUE 
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value = CodProducto
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = CodCodigo
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODIGOGrilla").Value = Codigo
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value = CmbMoneda.SelectedValue
                                    DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value = PrecioUnit
                                    DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value = Cantidad
                                    DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value = CDec(PrecioUnit) * CDec(Cantidad)
                                    DetalleVentaGridView.Rows(c - 1).Cells("DESCDataGridViewTextBoxColumn").Value = 0
                                    DetalleVentaGridView.Rows(c - 1).Cells("ProductoGrilla").Value = Producto
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value = CmbSucursal.SelectedValue
                                    DetalleVentaGridView.Rows(c - 1).Cells("SIMBOLO").Value = lblSimboloMoneda.Text
                                    DetalleVentaGridView.Rows(c - 1).Cells("LINEANUMERODataGridViewTextBoxColumn").Value = c
                                    DetalleVentaGridView.Rows(c - 1).Cells("Subtotal").Value = CDec(PrecioUnit) * CDec(Cantidad)

                                    SubTotal = FormatNumber(CDec(PrecioUnit) * CDec(Cantidad), 0)
                                    TotalFactura = TotalFactura + SubTotal

                                    If TipoIva = "5%" Then
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = SubTotal
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = "5"

                                        Iva5 = CDec(SubTotal) / 21 : Iva5 = Math.Round(Iva5, 0)
                                        Gravada5 = CDec(SubTotal) 'AQUI MODIFICO PORQUE EN LA CARGA NORMAL EN GRAVADA NO SE RESTA EL IVA (SARA)
                                        Gravada5 = Math.Round(Gravada5)
                                        TotalGravado5V = TotalGravado5V + Gravada5 ' AGREGUE
                                        total5 = total5 + Iva5
                                        TotalGravada = TotalGravada + Gravada5
                                        DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = SubTotal - Iva5 ' AGREGUE 

                                    ElseIf TipoIva = "10%" Then
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = SubTotal
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = "10"

                                        Iva10 = CDec(SubTotal) / 11 : Iva10 = Math.Round(Iva10, 0)
                                        Gravada10 = CDec(SubTotal) 'AQUI MODIFICO PORQUE EN LA CARGA NORMAL EN GRAVADA NO SE RESTA EL IVA (SARA)
                                        Gravada10 = Math.Round(Gravada10, 0)
                                        TotalGravado10V = TotalGravado10V + Gravada10
                                        total10 = total10 + Iva10
                                        TotalGravada = TotalGravada + Gravada10
                                        DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = SubTotal - Iva10 ' AGREGUE 

                                    Else
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = SubTotal
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = "0"
                                        DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = SubTotal 'AGREGUE
                                        Excento = SubTotal
                                        TotalExenta = TotalExenta + Excento
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                        Else 'La cantidad de lineas del pedido excedio a la cant. de lineas imprimibles en la factura
                            'Actualizamos los Totalizadores
                            If CmbMoneda.SelectedValue = 1 Or CmbMoneda.SelectedValue = Nothing Then
                                TotalVentaTextBox.Text = FormatNumber(TotalFactura, 0)
                                TotalVentaV = FormatNumber(TotalFactura, 0)
                            Else
                                TotalVentaTextBox.Text = FormatNumber(TotalFactura, cantdecimales)
                                TotalVentaV = FormatNumber(TotalFactura, cantdecimales)
                            End If

                            TotalIva = total10 + total5

                            TotalIvaVentaMaskedEdit.Text = FormatNumber(TotalIva, cantdecimales)
                            TotalGravadaMaskedEdit.Text = FormatNumber(TotalGravada, cantdecimales)
                            TotalExentaMaskedEdit.Text = FormatNumber(TotalExenta, cantdecimales)
                            Iva10TextBox1.Text = FormatNumber(total10, cantdecimales)
                            Iva5TextBox1.Text = FormatNumber(total5, cantdecimales)

                            CmbTipoVenta.Text = "Crédito"
                            NroOrdenSepsaCab = OrdCompraSEPSA
                            'Guardamos la factura actual
                            GuardarPictureBox_Click(Nothing, Nothing)

                            '---------------------------NUEVA FACTURA -----------------------------

                            'Ceramos los totalizadores
                            SubTotal = 0 : Iva5 = 0 : Iva10 = 0 : Excento = 0 : TotalIva = 0 : TotalGravada = 0
                            TotalExenta = 0 : total10 = 0 : total5 = 0 : TotalFactura = 0 : Gravada5 = 0 : Gravada10 = 0 : PorcIVA = 0 : TotalGravado10V = "0" : TotalGravado5V = "0" : TotalVentaV = "0"

                            'Damos la orden de una Nueva Factura
                            NuevoPictureBox_Click(Nothing, Nothing)

                            OrdCompraSEPSA = NroOrdenSepsaCab
                            dtpFechaHora.Text = CreationDate.ToString("dd/MM/yyy")
                            TxtNumCliente.Text = NumClienteCab

                            TxtNumCliente_LostFocus(Nothing, Nothing)
                            CmbCliente_LostFocus(Nothing, Nothing)
                            TipoComprobanteComboBox.Focus()

                            'para el 1ero excedido
                            If ExisteProducto = 1 Then
                                Try
                                    'Aumentamos el contador de facturas
                                    cantfacturas = cantfacturas + 1
                                    VENTASDETALLEBindingSource.AddNew()
                                    c = DetalleVentaGridView.RowCount

                                    DetalleVentaGridView.Rows(c - 1).Cells("COSTOPROMEDIO").Value = CDec(Costo)  ' AGREGUE 
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value = CodProducto
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = CodCodigo
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODIGOGrilla").Value = Codigo
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value = CmbMoneda.SelectedValue
                                    DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value = PrecioUnit
                                    DetalleVentaGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value = Cantidad
                                    DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value = CDec(PrecioUnit) * CDec(Cantidad)
                                    DetalleVentaGridView.Rows(c - 1).Cells("DESCDataGridViewTextBoxColumn").Value = 0
                                    DetalleVentaGridView.Rows(c - 1).Cells("ProductoGrilla").Value = Producto
                                    DetalleVentaGridView.Rows(c - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn1").Value = CmbSucursal.SelectedValue
                                    DetalleVentaGridView.Rows(c - 1).Cells("SIMBOLO").Value = lblSimboloMoneda.Text
                                    DetalleVentaGridView.Rows(c - 1).Cells("LINEANUMERODataGridViewTextBoxColumn").Value = c
                                    DetalleVentaGridView.Rows(c - 1).Cells("Subtotal").Value = CDec(PrecioUnit) * CDec(Cantidad)

                                    SubTotal = FormatNumber(CDec(PrecioUnit) * CDec(Cantidad), 0)
                                    TotalFactura = TotalFactura + SubTotal

                                    If TipoIva = "5%" Then
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = SubTotal
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = "5"

                                        Iva5 = CDec(SubTotal) / 21 : Iva5 = Math.Round(Iva5, 0)
                                        Gravada5 = CDec(SubTotal) 'AQUI MODIFICO PORQUE EN LA CARGA NORMAL EN GRAVADA NO SE RESTA EL IVA (SARA)
                                        Gravada5 = Math.Round(Gravada5)
                                        TotalGravado5V = TotalGravado5V + Gravada5 ' AGREGUE
                                        total5 = total5 + Iva5
                                        TotalGravada = TotalGravada + Gravada5
                                        DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = SubTotal - Iva5 ' AGREGUE 

                                    ElseIf TipoIva = "10%" Then
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = SubTotal
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = "10"

                                        Iva10 = CDec(SubTotal) / 11 : Iva10 = Math.Round(Iva10, 0)
                                        Gravada10 = CDec(SubTotal) 'AQUI MODIFICO PORQUE EN LA CARGA NORMAL EN GRAVADA NO SE RESTA EL IVA (SARA)
                                        Gravada10 = Math.Round(Gravada10, 0)
                                        TotalGravado10V = TotalGravado10V + Gravada10
                                        total10 = total10 + Iva10
                                        TotalGravada = TotalGravada + Gravada10
                                        DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = SubTotal - Iva10 ' AGREGUE 

                                    Else
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEEXENTODataGridViewTextBoxColumn").Value = SubTotal
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZDataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCODataGridViewTextBoxColumn").Value = 0
                                        DetalleVentaGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = "0"
                                        DetalleVentaGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = SubTotal 'AGREGUE
                                        Excento = SubTotal
                                        TotalExenta = TotalExenta + Excento
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                        End If

                    End If
                Catch ex As Exception
                End Try
            Next Node

            If CmbMoneda.SelectedValue = 1 Or CmbMoneda.SelectedValue = Nothing Then
                TotalVentaTextBox.Text = FormatNumber(TotalFactura, 0)
                TotalVentaV = FormatNumber(TotalFactura, 0)
            Else
                TotalVentaTextBox.Text = FormatNumber(TotalFactura, cantdecimales)
                TotalVentaV = FormatNumber(TotalFactura, cantdecimales)
            End If

            TotalIva = total10 + total5

            TotalIvaVentaMaskedEdit.Text = FormatNumber(TotalIva, cantdecimales)
            TotalGravadaMaskedEdit.Text = FormatNumber(TotalGravada, cantdecimales)
            TotalExentaMaskedEdit.Text = FormatNumber(TotalExenta, cantdecimales)
            Iva10TextBox1.Text = FormatNumber(total10, cantdecimales)
            Iva5TextBox1.Text = FormatNumber(total5, cantdecimales)


            'Las Facturas Importadas de SEPSA siempre son CREDITO
            CmbTipoVenta.Text = "Crédito"
            GuardarPictureBox_Click(Nothing, Nothing)

            If ProductosNoEncontrados <> "" Then
                MessageBox.Show("Cantidad de Facturas Generadas: " & cantfacturas & "" & Chr(13) & "Productos no Encontrados : " + ProductosNoEncontrados, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim strm As System.IO.Stream

        strm = OpenFileDialog1.OpenFile()
        LocalizacionFile = OpenFileDialog1.FileName.ToString()
    End Sub

    Private Sub tsExportarSepsa_Click(sender As System.Object, e As System.EventArgs) Handles tsExportarSepsa.Click
        Dim LocalizacionFile, GlnCliente, CreationDateAndTime, CreationTimer, DeliveryDate, Timbrado, NroFactura As String
        Dim CreationDate As Date
        Dim CreationYear, CreationMonth, CreationDay, Segundos As String

        permiso = PermisoAplicado(UsuCodigo, 264)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Exportar el Archivo SEPSA", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            'Antes de empezar la exportacion debemos verificar que la factura esta Aprobada
            If TxtEstado.Text = "1" Then
                Try
                    ' Configuración del FolderBrowserDialog
                    With (FolderBrowserDialog1)
                        .RootFolder = Environment.SpecialFolder.DesktopDirectory
                        Dim ret As DialogResult = .ShowDialog ' abre el diálogo
                        LocalizacionFile = .SelectedPath
                    End With
                Catch oe As Exception
                    Exit Sub
                End Try

                'Verificamos que tengo una ruta para guardar el archivo
                If LocalizacionFile = "" Then
                    MessageBox.Show("Ingrese la Dirección donde se Guardará el Archivo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                'Obtenemos el Codigo SEPSA del Cliente
                GlnCliente = f.FuncionConsultaString("SEPSA", "CLIENTES", "NUMCLIENTE", TxtNumCliente.Text)

                'Obtemos y convertimos la fecha
                CreationDate = Me.dtpFechaHora.Text
                CreationYear = CreationDate.ToString("yyyy")
                CreationMonth = CreationDate.ToString("MM")
                CreationDay = CreationDate.ToString("dd")
                CreationDateAndTime = CreationYear & "-" & CreationMonth & "-" & CreationDay & "T"
                Segundos = Now.Second
                If CDec(Segundos) < 10 Then
                    Segundos = "0" & Segundos
                End If
                CreationTimer = Now.Hour & ":" & Now.Minute & ":" & Segundos
                CreationDateAndTime = CreationDateAndTime & CreationTimer

                DeliveryDate = CreationDate.ToString("yyyy-MM-dd")

                'Obtenemos el timbrado
                Timbrado = f.FuncionConsulta("TIMBRADO", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)

                'Obtenemos el nro de Factura y lo convertimos en formato SEPSA
                NroFactura = Replace(NroFacturaLabel.Text, ".", "")
                NroFactura = Timbrado & "-" & NroFactura

                LocalizacionFile = LocalizacionFile & "\" & NroFactura & ".xml"
                FileSepsaCreator(LocalizacionFile, GlnCliente, CreationDateAndTime, DeliveryDate, Me.VCodVenta, Me.dtpFechaHora.Text, NroFactura)

                MessageBox.Show("Archivo Generado con Exito!!", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("La Factura debe estar Aprobada para poder Exportar los datos", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TipoComprobanteComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TipoComprobanteComboBox.SelectedIndexChanged
        Try
            If Config1 = "Con todas las Sucursales" Then 'facturar Segun Dashboard
                lblProximoNro_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbxBonif_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbxBonif.CheckedChanged
        If chbxBonif.Checked = True Then
            chbxCambio.Checked = False
            chbxOtros.Checked = False
        End If
    End Sub

    Private Sub chbxCambio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbxCambio.CheckedChanged
        If chbxCambio.Checked = True Then
            chbxBonif.Checked = False
            chbxOtros.Checked = False
        End If
    End Sub

    Private Sub chbxOtros_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbxOtros.CheckedChanged
        If chbxOtros.Checked = True Then
            chbxCambio.Checked = False
            chbxBonif.Checked = False
        End If
    End Sub

    Private Sub tsEmitirPresupuesto_Click(sender As System.Object, e As System.EventArgs) Handles tsEmitirPresupuesto.Click
        Me.Cursor = Cursors.AppStarting

        'Antes de Emitir el presupuesto verificamos que ya no se halla emitido anteriormente
        Dim ExisteEmitido As Integer = w.FuncionConsultaDecimal("CODPRESUPUESTO", "VENTAS", "CODVENTA", VCodVenta)
        If ExisteEmitido = 0 Then
            Dim CodVentaTemp As Integer
            Dim rango As String = ""

            'Obtenemos los datos Rango, Impresora e Imprimir
            Dim objCommand As New SqlCommand

            Try
                objCommand.CommandText = "SELECT dbo.DETPC.RANDOID, dbo.DETPC.IMPRESORA, dbo.DETPC.IMPRIMIR,dbo.TIPOCOMPROBANTE.FORMAIMPRESION " & _
                                          "FROM dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                                          "WHERE (dbo.TIPOCOMPROBANTE.PRESUPUESTO = 1) AND (dbo.DETPC.ACTIVO = 1)"

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
                    MessageBox.Show("No Existe un Rango para el Presupuesto. Configuracion -> Rango de Comprobante", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            CalculaNroPresupuesto(rango)

            Try 'Actualizamos el Saldo para Envio
                If CmbMetodo.Text = "Avanzado" Then
                    Dim conexion As System.Data.SqlClient.SqlConnection
                    Dim myTrans As System.Data.SqlClient.SqlTransaction
                    conexion = ser.Abrir()
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

                    CodVenta = VCodVenta
                    ActualizaSaldoProducto(myTrans)

                    myTrans.Commit()
                End If
            Catch ex As Exception

            End Try

            'Verificamos si quiere imprimir 
            Try
                If impresora = "" And Imprimir = 1 Then
                    MessageBox.Show("Esta maquina No tiene Impresora asignada", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If TipoImpresion = 0 Then   'Formato Ticket
                    If Imprimir = 1 Then 'Se imprime
                        ImprimirReportePreVenta()
                    End If
                ElseIf TipoImpresion = 1 Then 'Formato Impresora
                    If Imprimir = 1 Then 'Se imprime
                        ImprimirReportePresupuesto()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error al Imprimir : " & ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            'Insertamos en la Tabla Comentarios
            If CmbEvento.Text <> "" Then
                InsertarProyecto("Presupuesto Nro " & NroFacturaLabel.Text, CmbEvento.SelectedValue())
            End If

            CodVentaTemp = VCodVenta
            FechaFiltro()

            If Config1 = "Con todas las Sucursales" Then
                VENTASTableAdapter.Fill(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2)
            Else
                VENTASTableAdapter.FillBySuc(DsFacturacionCompleja.VENTAS, FechaFiltro1, FechaFiltro2, SucCodigo)
            End If

            'Buscamos la posicion del registro guardado
            For i = 0 To GridViewFacturacion.RowCount - 1
                If GridViewFacturacion.Rows(i).Cells("CODVENTADataGridViewTextBoxColumn").Value = CodVentaTemp Then
                    VENTASBindingSource.Position = i
                    Exit For
                End If
            Next

            PintarCeldas()
            DeshabilitaControles()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CalculaNroPresupuesto(RangoAQuemar As String)
        Dim NumPresupuesto As String
        Dim cmd2 As New SqlCommand
        Dim conexion As System.Data.SqlClient.SqlConnection
        conexion = ser.Abrir()
        Try
            Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString As String
            Dim NroDigitos As Integer

            NumSucursal = SucCodigo
            NumMaquina = NumMaquinaGlobal
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
                NumPresupuesto = ""
                'supero el ultimo
                Exit Sub
            End If

            NumSucTimbrado = drdetpc("SUCURSALTIMBRADO")
            NumMaquina = drdetpc("NUMMAQUINA")

            NroRangoString = CStr(NroRango)
            For i = 1 To NroDigitos
                If Len(NroRangoString) = NroDigitos Then
                    Exit For
                Else
                    NroRangoString = "0" & NroRangoString
                End If
            Next

            NumPresupuesto = NumSucTimbrado & "." & NumMaquina & "." & NroRangoString
            NroFacturaLabel.Text = NumPresupuesto

            If NumPresupuesto = "" Then
                MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                ser.Abrir(sqlc)
                cmd2.Connection = sqlc

                sql = ""
                sql = "UPDATE VENTAS SET CODPRESUPUESTO=1, NUMVENTA = '" & NumPresupuesto & "' where CODVENTA= " & GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value

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
            MessageBox.Show("Error al Emitir el Presupuesto : " & ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NumPresupuesto = ""
            NroFacturaLabel.Text = ""
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub tsImprimirPresupuesto_Click(sender As System.Object, e As System.EventArgs) Handles tsImprimirPresupuesto.Click
        ImprimirReportePresupuesto()
    End Sub

    Private Sub ImprimirReportePreVenta()
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.TicketPreVenta

        informe.PrintOptions.PaperSource = PaperSource.Upper 'bandeja
        informe.SetDataSource(InfPresupuestoPreVenta())

        Try
            informe.PrintOptions.PrinterName = impresora  'impresora

        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "RIA")
        End Try

        informe.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub tsReImprimirPreVenta_Click(sender As System.Object, e As System.EventArgs) Handles tsReImprimirPreVenta.Click
        Dim informe = New ReportesPersonalizados.TicketPreVenta
        informe.SetDataSource(InfPresupuestoPreVenta())
        Dim result As DialogResult = PrintDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            informe.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
            informe.PrintToPrinter(1, False, 0, 0)
        End If
    End Sub

    Private Sub tsAprobarPresupuesto_Click(sender As System.Object, e As System.EventArgs) Handles tsAprobarPresupuesto.Click
        BtnImprimir_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAnularPresupuesto_Click(sender As System.Object, e As System.EventArgs) Handles tsAnularPresupuesto.Click
        PictureBoxMotivoAnulacion_Click(Nothing, Nothing)
    End Sub

    Private Sub Cotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Cotizacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbEvento.Focus()
            Cot1FactTextBox.Text = Cotizacion.Text
        End If
    End Sub

    Private Sub btnGenerarPagares_Click(sender As Object, e As EventArgs) Handles btnGenerarPagares.Click
        permiso = PermisoAplicado(UsuCodigo, 282)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para Generar Pagares", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If GridViewCuotas.Rows.Count <> 0 Then
            Dim consulta As String = ""
            Dim DateVence, NroPagare As String
            Dim Fecha As Date
            Dim ExistePagare As Integer = 0
            Dim UltimoNro, CantDigitos, IdComprobante As Integer

            Dim fx_Valor As Double = 0
            If IngresarCotCheckBox.Checked = True Then
                fx_Valor = Cotizacion.Text
            Else
                fx_Valor = Cot1FactTextBox.Text
            End If

            'Verificamos si existe un rango para el Pagare
            Dim dtPagare As New DataTable("TIPOCOMPROBANTE")
            Dim bdConn As New BDConexión.BDConexion
            Dim connString As New SqlConnection(bdConn.CadenaConexion)
            sql = "SELECT dbo.DETPC.ULTIMO, dbo.DETPC.NRODIGITOS,dbo.DETPC.RANDOID FROM dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                  "WHERE (dbo.TIPOCOMPROBANTE.PAGARE = 1) AND (dbo.DETPC.ACTIVO = 1)"
            Dim SQLCmd As New SqlCommand(sql, connString)
            connString.Open()
            dr = SQLCmd.ExecuteReader(CommandBehavior.Default)
            dtPagare.Load(dr)
            connString.Close()

            If dtPagare.Rows.Count <> 0 Then
                For Each rows In dtPagare.Rows
                    UltimoNro = rows("ULTIMO")
                    CantDigitos = rows("NRODIGITOS")
                    IdComprobante = rows("RANDOID")
                Next

                'Antes de Insertar el Pagare debemos verificar que ya no se halla generado anteriormente
                ExistePagare = w.FuncionConsultaDecimal("Codpagare", "VENTAS_PAGARE", "CodVenta", GridViewFacturacion.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn").Value)

                If ExistePagare = 0 Then
                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc

                    For i = 0 To GridViewCuotas.Rows.Count - 1
                        Fecha = GridViewCuotas.Rows(i).Cells("FECHAVCTODataGridViewTextBoxColumn").Value
                        DateVence = FormatDateTime(Fecha, DateFormat.ShortDate)

                        UltimoNro = UltimoNro + 1
                        NroPagare = CStr(UltimoNro)
                        For h = 1 To CantDigitos
                            If Len(NroPagare) = CantDigitos Then
                                Exit For
                            Else
                                NroPagare = "0" & NroPagare
                            End If
                        Next

                        Dim ImportePagare As String = GridViewCuotas.Rows(i).Cells("IMPORTECUOTADataGridViewTextBoxColumn").Value
                        ImportePagare = Funciones.Cadenas.QuitarCad(ImportePagare, ".")
                        ImportePagare = Replace(ImportePagare, ",", ".")


                        consulta = consulta + "  INSERT INTO VENTAS_PAGARE (CodCliente,CodVenta,CodMoneda,Cotizacion,FechaCreacion,FechaVencimiento,Valor,Codestado,NroCuota,NroPagare)  " & _
                                        "VALUES(" & CmbCliente.SelectedValue & "," & GridViewCuotas.Rows(i).Cells("CODVENTADataGridViewTextBoxColumn2").Value & "," & CmbMoneda.SelectedValue & "," & _
                                        fx_Valor & ", CONVERT(DATETIME, '" & dtpFechaHora.Text & "',103), CONVERT(DATETIME, '" & DateVence & "',103), " & _
                                        ImportePagare & ", 1," & GridViewCuotas.Rows(i).Cells("CODNUMEROCUOTADataGridViewTextBoxColumn").Value & ",'" & NroPagare & "')       "
                    Next

                    consulta = consulta + "    UPDATE DETPC SET ULTIMO = " & UltimoNro & " where RANDOID =" & IdComprobante & " "
                    cmd.CommandText = consulta

                    Try
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Los Pagares se Generaron con Exito !!", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try

                    sqlc.Close()
                Else
                    MessageBox.Show("Ya se genero Pagares en esta Factura", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Verifique si Existe un rango para el Pagare antes de continuar", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Primero debe Generar las Cuotas para emitir los Pagares", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub cbxTipoIva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxTipoIva.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            If TxtDescuento.Enabled = True Then
                Me.TxtDescuento.Focus()
            Else
                If GrillaModif = 1 Then
                    btnModificarDetVenta.Focus()
                Else
                    AgregarDetVentaButton.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub pbxBuscarEnvento_Click(sender As Object, e As EventArgs) Handles pbxBuscarEnvento.Click
        upcEventos.Show()
        txtBuscarEvento.Text = ""
    End Sub

    Private Sub dgwEventos_DoubleClick(sender As Object, e As EventArgs) Handles dgwEventos.DoubleClick
        If dgwEventos.Rows.Count <> 0 Then
            CmbEvento.SelectedValue = dgwEventos.CurrentRow.Cells("CODEVENTODataGridViewTextBoxColumn1").Value

            upcEventos.Close()
            CmbEvento.Select()
        End If
    End Sub

    Private Sub txtBuscarEvento_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarEvento.TextChanged
        EVENTOBindingSource.Filter = "DESCEVENTO LIKE '%" & txtBuscarEvento.Text & "%' OR NUMEVENTO LIKE '%" & txtBuscarEvento.Text & "%'"
    End Sub

    Private Sub tbxNroSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbxNroSerie.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            pnlNroSerie.Visible = False
            CantidadVentaMaskedEdit.Focus()
        End If
    End Sub

    Private Sub PanelDeNroDeSerieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PanelDeNroDeSerieToolStripMenuItem.Click
        If Config13 = "Si" Then
            pnlNroSerie.Visible = True
            pnlNroSerie.BringToFront()
            tbxNroSerie.Focus()
        End If
    End Sub

    Public Sub btnContinuarRemision_Click() Handles btnContinuarRemision.Click
        If tbxFactNroRemision.Text Is Nothing Then
            tbxFactNroRemision.Text = ""
        End If
        pnlNroRemision.Visible = False
        Continuar()
    End Sub



    Private Sub lblLimiteCredito_Click(sender As Object, e As EventArgs) Handles lblLimiteCredito.Click

    End Sub


End Class

