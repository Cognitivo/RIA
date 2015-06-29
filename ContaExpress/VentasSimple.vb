Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.Shared
Imports EnviaInformes
Imports Osuna.Utiles.Conectividad
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Imports System.Threading

Public Class VentasSimple

#Region "Fields"
    Private sqlc As New SqlConnection
    Private myTrans As System.Data.SqlClient.SqlTransaction
    Dim anu As Integer
    Private cmd As New SqlCommand
    'DETPC
    Dim Cantlinea, imprimirfact, imprimeticket As Integer
    Dim Clientes As Integer
    Dim CodClienteGlobal As Integer
    Dim CodCliente, CodVenta As Integer
    Dim CodRangoActual, panelactivo, cambioNroFact As String
    Dim PanelRangoVisible As String
    Dim TipoImpresion, Imprimir, buscador As Integer
    Dim IdMovimiento, CabPagoMax As Integer
    Public primeritem As Boolean
    Dim cantImpreTick As Integer = 0
    Dim CantidadDeVenta As String
    Dim PrecioDeVenta As Integer
    Dim FechaValidez As String
    Dim MultiplicarCant As Boolean
    Dim CantListaPrecio As Double
    Dim thPrecio, thCantidad, thCodProducto, thCantAux, thDescripcionProducto, thCodiProducViejo, thDescripProductoModif As String

    'PARA GUARDAR VENTA
    Dim CodTipocomprobante, CodClienteV, NumVenta, Cotizacion1, Estado, TimbradoFactura As String

    'Variable para Carga del Cliente y reserva del CODCLIENTE. Mirar funcion: "IniciarVentas()"
    Dim f As New Funciones.Funciones

    '#####################################################################################
    'Variable para el vendedor############################################################
    Dim CodVendedor As String
    Dim del As Integer
    Private direccion As String

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim ds As New DataSet
    Dim Existe As Integer

    'Variables de Transaccion
    Dim filename As String

    'Para filtrar Cobro
    Dim Filtro As String
    Dim MaxIdApertura As Integer

    'IMPRESORA
    Dim impresora As String
    Dim IndicePC, IndiceTipoComprobante, LineaVenta As Integer
    Dim ins As Integer

    Dim pri As Integer
    Dim permiso As Double
    'BANDERAS DE ESTADO DE LOS TABS
    Dim Requisitos As Integer
    Private row As DataRow
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Private sistema As New Funciones.Sistema
    Dim sql As String

    Dim TotalVenta As String 'Para imprimir en el ticket
    Dim upd As Integer
    Dim VarCliente As Integer
    Dim VarMaquina As Integer
    Dim VarTablaCaja As Integer
    Dim VarTablaCheque As Integer
    Dim VarTablaCliente As Integer
    Dim VarTablaCompra As Integer
    Dim VarTablaDeposito As Integer
    'Dim VarTablaPcFecha As Integer

    'BANDERAS PARA VERIFICAR SI LAS TABLAS ESTAN CARGADAS
    Dim VarTablaPoducto As Integer
    Dim VarTablaRangoComprobante As Integer
    Dim VarTablaStock As Integer
    Dim VarTablaTipoComprobante As Integer
    Dim VatTablaTarjeta As Integer
    Dim Venta As Integer
    Dim NroVentaGlobal As Double

    'Variables de Funcion
    Dim w As New Funciones.Funciones

    'Para controlar cuando un producto sea pesable
    Dim ProdPE As Integer = 0

    Private ThreadPrint As Thread
    Dim EstaImprimiendo As Integer = 0
    Dim VCodTipoClientePrioridad As String
    Dim VIvaGlobal As Double
    Dim CodComprobante As Integer = 0
    Dim Config1, Config2, Config3, Config4, Config5, Config6, Config7, Config8, Config9, Config10, Config11 As String
    Dim ParaPrecio, ParaListaPrecio, ParaEliminar, ParaUltimoPanel, ParaListaPrecio2 As Integer
    Dim VenderMasPermiso, ModificarPresioVenta, VerOtrosPrecios, PuedeEliminarDetalle, AnularFactura, ReimprimirMismoNro, ReimprimirOtroNro, CambiarVendedor As Integer 'Permisos de Usuarios
    Dim ValorFiscal As Integer
    Dim vProdPromocion, vProdCosto, cambiofact As Integer
    Dim AccNuevo, AccEditar As Integer
    Dim ErrorFuncion As Integer = 0

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

    Public Function InfFactura() As DataSet
        Dim ds As New DsInformes
        ds.Clear()
        Dim diez, cinco, exento, totalcinco, totaldiez, totalexento, total, TotalItems5, TotalItems10, TotalItemsExento As Decimal
        Dim IvaDescrip As String

        diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0 : TotalItems5 = 0
        TotalItems10 = 0 : TotalItemsExento = 0

        Try
            Dim CantImpresion As Integer
            Dim k As Integer = 1
            Dim c As Integer = DetalleVentaTGridView.RowCount()

            CantImpresion = f.FuncionConsultaDecimal("CANTIDADIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", CodComprobante)

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
                        row.Item("Campo1") = DetalleVentaTGridView.Rows(i - 1).Cells("ProductoDGVT").Value
                    End If

                    If i > c Then
                        row.Item("Campo13") = ""
                    Else
                        row.Item("Campo13") = DetalleVentaTGridView.Rows(i - 1).Cells("CodigoBarraDGVT").Value
                    End If

                    row.Item("Campo6") = RUCClienteTextBox.Text
                    row.Item("Campo4") = RTrim(NombreClienteTextBox.Text)
                    row.Item("Campo7") = VendendorComboBox.Text
                    row.Item("Campo8") = DireccionClienteTextBox.Text
                    row.Item("Fecha1") = Today
                    row.Item("Campo9") = NroFacturaLabel.Text
                    row.Item("Campo10") = TelefonoClienteTextBox.Text
                    '#####################################################################################

                    '########### campos numericos ##########################################################
                    If i > c Then
                    Else
                        row.Item("NUMERO1") = DetalleVentaTGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                    End If

                    If i > c Then
                    Else
                        row.Item("NUMERO2") = DetalleVentaTGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                    End If

                    Dim IVA As Decimal

                    If i > c Then
                    Else
                        IvaDescrip = DetalleVentaTGridView.Rows(i - 1).Cells("IVA").Value
                        IvaDescrip = Trim(Replace(IvaDescrip, "%", ""))
                        IVA = CDec(IvaDescrip)

                        row.Item("NUMERO5") = DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value
                        row.Item("NUMERO3") = DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value
                        row.Item("NUMERO4") = DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value

                        If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value) Then
                        Else
                            totalcinco = totalcinco + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value / 21)
                            TotalItems5 = TotalItems5 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value)
                        End If

                        If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value) Then
                        Else
                            totaldiez = totaldiez + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value / 11)
                            TotalItems10 = TotalItems10 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value)
                        End If

                        If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value) Then
                        Else
                            TotalItemsExento = TotalItemsExento + DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value
                        End If

                    End If

                    '#####################################################################################

                    row.Item("NUMERO6") = totalcinco
                    row.Item("NUMERO7") = totaldiez
                    row.Item("NUMERO8") = totaldiez + totalcinco
                    total = CDec(lblVentaTotal.Text)
                    row.Item("NUMERO9") = total

                    row.Item("NUMERO11") = TotalItems5
                    row.Item("NUMERO12") = TotalItems10
                    row.Item("NUMERO10") = TotalItemsExento

                    row.Item("Campo2") = Funciones.Cadenas.NumeroaLetras(total)

                    row.Item("Campo25") = "CONTADO"
                    row.Item("Campo21") = "X"
                    row.Item("Campo22") = ""

                    ds.Tables("Detalle").Rows.Add(row)

                Next

                diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0
                TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0
            Next
        Catch ex As Exception

        End Try

        Return ds
    End Function

    Public Function RecortaCaracteres(ByVal caracter As String, Optional ByVal longitud As Integer = 32) As String
        Select Case Len(caracter)
            Case Is > longitud
                caracter = caracter.Substring(0, 32)
            Case Is < longitud
                Dim longitudEspacio As Integer
                longitudEspacio = ((longitud - Len(caracter)) / 2) + Len(caracter)
                caracter = caracter.PadLeft(longitudEspacio)
        End Select

        Return caracter
    End Function

    Public Function RecortaCaracteresProductos(ByVal caracter As String, Optional ByVal longitud As Integer = 32) As String
        Select Case Len(caracter)
            Case Is > longitud
                caracter = caracter.Substring(0, 32)
            Case Is < longitud
                caracter = caracter
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

    Public Function VerificarApertura(ByVal numCaja As Long, _
        ByVal codEmpresa As Long, ByVal fechaApertura As String) As String
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand

        sql = ""
        sql = "SELECT NUMEROCAJA FROM CAJA WHERE NUMCAJA=" & numCaja & " AND ESTATUS= 1 "
        Try
            'Verifica si la caja ya ha sido
            'cerrada en esta fecha
            sqlc = New SqlConnection
            sqlc = ser.Abrir()

            cmd.Connection = sqlc
            cmd.CommandText = sql

            dr = cmd.ExecuteReader

            If dr.HasRows Then
                Return fechaApertura
            Else
                Return "0"
            End If
        Catch ex As Exception


            Return False
        Finally
            dr.Close()
            sqlc.Close()
        End Try
    End Function

    Private Sub ActualizaCliente()
        Dim NroCliente As String
        Dim Maximo As Integer
        Try
            Maximo = f.Maximo("NUMCLIENTE", "CLIENTES")
            Maximo = Maximo + 1
        Catch ex As Exception
            Maximo = CInt(CodClienteTextBox.Text)
        End Try
        
        NroCliente = Maximo
        sql = ""
        sql = "update CLIENTES set " & _
        "NOMBRE = '" & NombreClienteTextBox.Text & "',  AUTORIZADO=1," & _
        "NOMBREFANTASIA = '" & NombreClienteTextBox.Text & "', " & _
        "RUC = '" & RUCClienteTextBox.Text & "'," & _
        "DIRECCION = '" & DireccionClienteTextBox.Text & "'," & _
        "TELEFONO = '" & TelefonoClienteTextBox.Text & "', " & _
        "TIPORELACION = 1, " & _
        "CODTIPOCLIENTE=" & RadComboBoxTipoCliente.SelectedValue & " , NUMCLIENTE = '" & NroCliente & "'  " & _
        "WHERE CODCLIENTE = " & CodClienteTextBox.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AgregarDetChequeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarDetChequeButton.Click
        Dim f As New Funciones.Funciones
        Dim codtipocobro As Integer
        Try
            codtipocobro = f.FuncionConsulta("CODFORCOBRO", "TIPOFORMACOBRO", _
                                             "DESFORCOBRO='cheque' OR DESFORCOBRO='Cheque' or DESFORCOBRO", "CHEQUE")
        Catch ex As Exception

        End Try
        'Validamos
        If String.IsNullOrEmpty(txtMontoCheque.Text) Then
            MessageBox.Show("Ingrese el Monto para el Cobro en Cheque", "POSSEXPRESS")
            txtMontoCheque.Focus()
            Exit Sub
        ElseIf CDec(txtMontoCheque.Text) = 0 Then
            MessageBox.Show("Ingrese el Monto mayor a cero", "POSSEXPRESS")
            txtMontoCheque.Focus()
            Exit Sub
        End If

        If MonedaChequeComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Elija la Moneda para el Cobro con Cheque", "POSSEXPRESS")
            MonedaChequeComboBox.Focus()
            Exit Sub
        End If

        If BancoChequeComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Elija el Banco para el Cobro con Cheque", "POSSEXPRESS")
            BancoChequeComboBox.Focus()
            Exit Sub
        End If

        If NroChequeTextBox.Text = "" Then
            MessageBox.Show("Ingrese el Nro Cheque para el Cobro", "POSSEXPRESS")
            NroChequeTextBox.Focus()
            Exit Sub
        End If

        If FechaCobroChequeTextBox.Text = "" Then
            MessageBox.Show("Ingrese la Fecha para el Cobro", "POSSEXPRESS")
            FechaCobroChequeTextBox.Focus()
            Exit Sub
        End If
        'Choefiente Cambio
        Dim Coheficiente As String = w.FuncionConsultaString2("FACTORCOBRO", "COTIZACION", "CODMONEDA", MonedaChequeComboBox.SelectedValue & " ORDER BY FECGRA DESC")
        If Coheficiente = Nothing Then
            MessageBox.Show("El coheficiente para " & MonedaChequeComboBox.Text & " es íncorrecto o inexistente", "POSSEXPRESS")
            MonedaChequeComboBox.Focus()
            Exit Sub
        End If

        VENTASFORMACOBROBindingSource.AddNew()
        Dim c As Integer = CobroEfectivoTGridView.RowCount

        If c > 0 Then
            'Pasamos los datos a la Grilla
            'Tradicional
            CobroEfectivoTGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value = MonedaChequeComboBox.SelectedValue
            CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value = CDec(txtMontoCheque.Text)
            CobroEfectivoTGridView.Rows(c - 1).Cells("DESTIPOCOBRODataGridViewTextBoxColumn").Value = "Cheque"
            CobroEfectivoTGridView.Rows(c - 1).Cells("FECHACOBRODataGridViewTextBoxColumn").Value = FechaCobroChequeTextBox.Text
            CobroEfectivoTGridView.Rows(c - 1).Cells("COTIZACION1DataGridViewTextBoxColumn").Value = Coheficiente
            CobroEfectivoTGridView.Rows(c - 1).Cells("CHTATRCODBANCODataGridViewTextBoxColumn").Value = BancoChequeComboBox.SelectedValue
            CobroEfectivoTGridView.Rows(c - 1).Cells("CHNROCHEQUEDataGridViewTextBoxColumn").Value = NroChequeTextBox.Text
            CobroEfectivoTGridView.Rows(c - 1).Cells("CODTIPOCOBRODataGridViewTextBoxColumn").Value = codtipocobro
            CobroEfectivoTGridView.Rows(c - 1).Cells("Moneda").Value = MonedaChequeComboBox.Text

        End If

        RecorreEfectivo()
        LimpiarControlesCobro()

        If txtMontoCheque.Text = "" Then
            btnCobrar.Focus()
        End If
    End Sub

    Private Sub AgregarDetDebitoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarDetDebitoButton.Click
        Dim f As New Funciones.Funciones
        Dim codtipocobro As Integer
        Try
            codtipocobro = f.FuncionConsulta("CODFORCOBRO", "TIPOFORMACOBRO", _
                                             "DESFORCOBRO='TARJETA' OR DESFORCOBRO='Tarjeta' or DESFORCOBRO", "tarjeta")
        Catch ex As Exception

        End Try
        'Validamos
        If String.IsNullOrEmpty(MontoDebitoMaskedEdit.Text) Then
            MessageBox.Show("Ingrese el Monto para el Cobro en Debito", "POSSEXPRESS")
            MontoDebitoMaskedEdit.Focus()
            Exit Sub
        ElseIf CDec(MontoDebitoMaskedEdit.Text) = 0 Then
            MessageBox.Show("Ingrese el Monto mayor a cero", "POSSEXPRESS")
            MontoDebitoMaskedEdit.Focus()
            Exit Sub
        End If

        'Choefiente Cambio
        Dim Coheficiente As String = w.FuncionConsultaString2("FACTORCOBRO", "COTIZACION", "CODMONEDA", MonedaEfectivoComboBox.SelectedValue & " ORDER BY FECGRA DESC")
        If Coheficiente = Nothing Then
            MessageBox.Show("El coheficiente para " & MonedaEfectivoComboBox.Text & " es íncorrecto o inexistente", "POSSEXPRESS")
            MonedaEfectivoComboBox.Focus()
            Exit Sub
        End If

        VENTASFORMACOBROBindingSource.AddNew()
        Dim c As Integer = CobroEfectivoTGridView.RowCount

        If c > 0 Then
            'Pasamos los datos a la Grilla
            'Tradicional
            CobroEfectivoTGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value = CODMONEDAPRINCIPAL
            CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value = CDec(MontoDebitoMaskedEdit.Text)
            CobroEfectivoTGridView.Rows(c - 1).Cells("DESTIPOCOBRODataGridViewTextBoxColumn").Value = "Tarjeta de Débito"
            CobroEfectivoTGridView.Rows(c - 1).Cells("FECHACOBRODataGridViewTextBoxColumn").Value = Today
            CobroEfectivoTGridView.Rows(c - 1).Cells("COTIZACION1DataGridViewTextBoxColumn").Value = 1
            CobroEfectivoTGridView.Rows(c - 1).Cells("CODTIPOCOBRODataGridViewTextBoxColumn").Value = codtipocobro
            CobroEfectivoTGridView.Rows(c - 1).Cells("Banco").Value = BancoDebitoComboBox.Text
            CobroEfectivoTGridView.Rows(c - 1).Cells("Moneda").Value = MonedaEfectivoComboBox.Text
            CobroEfectivoTGridView.Rows(c - 1).Cells("COTIZACION1DataGridViewTextBoxColumn").Value = Coheficiente

            If BancoDebitoComboBox.SelectedValue = Nothing Then
            Else
                CobroEfectivoTGridView.Rows(c - 1).Cells("CHTATRCODBANCODataGridViewTextBoxColumn").Value = BancoDebitoComboBox.SelectedValue
            End If
        End If

        RecorreEfectivo()
        LimpiarControlesCobro()

        If MontoDebitoMaskedEdit.Text = "" Then
            btnCobrar.Focus()
        End If
    End Sub

    Private Sub AgregarDetTarjetaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarDetTarjetaButton.Click
        Dim f As New Funciones.Funciones
        Dim codtipocobro As Integer
        Try
            codtipocobro = f.FuncionConsulta("CODFORCOBRO", "TIPOFORMACOBRO", _
                                             "DESFORCOBRO='TARJETA' OR DESFORCOBRO='Tarjeta' or DESFORCOBRO", "tarjeta")
        Catch ex As Exception

        End Try
        'Validamos
        If String.IsNullOrEmpty(MontoTarjetaMaskedEdit.Text) Then
            MessageBox.Show("Ingrese el Monto para el Cobro en Tarjeta", "POSSEXPRESS")
            MontoTarjetaMaskedEdit.Focus()
            Exit Sub
        ElseIf CDec(MontoTarjetaMaskedEdit.Text) = 0 Then
            MessageBox.Show("Ingrese el Monto mayor a cero", "POSSEXPRESS")
            MontoTarjetaMaskedEdit.Focus()
            Exit Sub
        End If

        If TipoTarjetaComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Elija el Tipo de Tarjeta para el Cobro", "POSSEXPRESS")
            TipoTarjetaComboBox.Focus()
            Exit Sub
        End If

        Dim Coheficiente As String = w.FuncionConsultaString2("FACTORCOBRO", "COTIZACION", "CODMONEDA", MonedaEfectivoComboBox.SelectedValue & " ORDER BY FECGRA DESC")
        If Coheficiente = Nothing Then
            MessageBox.Show("El coheficiente para " & MonedaEfectivoComboBox.Text & " es íncorrecto o inexistente", "POSSEXPRESS")
            MonedaEfectivoComboBox.Focus()
            Exit Sub
        End If

        VENTASFORMACOBROBindingSource.AddNew()
        Dim c As Integer = CobroEfectivoTGridView.RowCount

        If c > 0 Then
            'Pasamos los datos a la Grilla
            'Tradicional
            CobroEfectivoTGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value = CODMONEDAPRINCIPAL
            CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value = CDec(MontoTarjetaMaskedEdit.Text)
            CobroEfectivoTGridView.Rows(c - 1).Cells("DESTIPOCOBRODataGridViewTextBoxColumn").Value = "Tarjeta de Crédito"
            CobroEfectivoTGridView.Rows(c - 1).Cells("FECHACOBRODataGridViewTextBoxColumn").Value = Today
            CobroEfectivoTGridView.Rows(c - 1).Cells("COTIZACION1DataGridViewTextBoxColumn").Value = 1
            CobroEfectivoTGridView.Rows(c - 1).Cells("TACODTIPOTARJETADataGridViewTextBoxColumn").Value = TipoTarjetaComboBox.SelectedValue
            CobroEfectivoTGridView.Rows(c - 1).Cells("CODTIPOCOBRODataGridViewTextBoxColumn").Value = codtipocobro
            CobroEfectivoTGridView.Rows(c - 1).Cells("COTIZACION1DataGridViewTextBoxColumn").Value = Coheficiente
            CobroEfectivoTGridView.Rows(c - 1).Cells("Moneda").Value = MonedaEfectivoComboBox.Text
            CobroEfectivoTGridView.Rows(c - 1).Cells("TipoTarjeta").Value = TipoTarjetaComboBox.Text

        End If
        RecorreEfectivo()
        LimpiarControlesCobro()

        If MontoTarjetaMaskedEdit.Text = "" Then
            btnCobrar.Focus()
        End If
    End Sub

    Private Sub AgregarDetVentaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarDetVentaButton.Click
        CantidadDeVenta = ""

        If CodComboTextBox.Text = "" Then
            If CodCodigoTextBox.Text = "" Or CodProductoTextBox.Text = "" And tbxCantidadVent.Text = 1 Then
                Me.CobrarButton.Focus()
                Exit Sub
            Else
                If String.IsNullOrEmpty(tbxCantidadVent.Text) Then
                    MessageBox.Show("Ingrese una cantidad correcta", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tbxCodigoProd.Focus()
                    Exit Sub
                ElseIf CDec(tbxCantidadVent.Text) = 0 Then
                    MessageBox.Show("Ingrese una cantidad mayor a cero", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tbxCodigoProd.Focus()
                    Exit Sub
                End If
                If String.IsNullOrEmpty(PrecioVentaMaskedEdit.Text) Or PrecioVentaMaskedEdit.Text = "" Then
                    MessageBox.Show("Ingrese un precio correcto", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tbxCodigoProd.Focus()
                    Exit Sub
                End If
            End If

            'La cantidad no puede ser mayor al de stock actual
            Dim CantidadEnStock As Decimal

            If lblEnStock.Text <> "Servicio" Then
                If lblEnStock.Text = "" Then
                    CantidadEnStock = 0
                Else
                    CantidadEnStock = lblEnStock.Text
                End If

                If ProdPE = 1 Then
                    CantidadDeVenta = Replace(tbxCantidadVent.Text, ".", ",")
                Else
                    CantidadDeVenta = tbxCantidadVent.Text
                End If

                If VenderMasPermiso = 0 Then
                    If CantidadEnStock < CDec(CantidadDeVenta) Then
                        MessageBox.Show("La Cantidad ingresada es mayor al Stock Actual", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        tbxCodigoProd.Focus()
                        Exit Sub
                    End If
                End If
            Else
                CantidadDeVenta = Replace(tbxCantidadVent.Text, ".", ",")
            End If

        End If
        If String.IsNullOrEmpty(PrecioVentaMaskedEdit.Text) Or PrecioVentaMaskedEdit.Text = "" Then
            MessageBox.Show("Ingrese un Precio de Venta", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxCodigoProd.Focus()
            Exit Sub
        End If

        '####################################################################

        If AgregarDetVentaButton.Text = "Modificar" Then
            PrecioDeVenta = PrecioVentaMaskedEdit.Text
            Dim preciobruto As Decimal = PrecioDeVenta * CantidadDeVenta

           
            thCodProducto = DetalleVentaTGridView.Rows(LineaVenta).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
            thPrecio = DetalleVentaTGridView.Rows(LineaVenta).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
            thCantidad = DetalleVentaTGridView.Rows(LineaVenta).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
            thDescripcionProducto = DetalleVentaTGridView.Rows(LineaVenta).Cells("ProductoDGVT").Value

            DetalleVentaTGridView.Rows(LineaVenta).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value = CDec(CodProductoTextBox.Text)
            DetalleVentaTGridView.Rows(LineaVenta).Cells("CODCODIGODataGridViewTextBoxColumn").Value = CodCodigoTextBox.Text
            DetalleVentaTGridView.Rows(LineaVenta).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value = PrecioDeVenta
            DetalleVentaTGridView.Rows(LineaVenta).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value = preciobruto
            DetalleVentaTGridView.Rows(LineaVenta).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value = CantidadDeVenta 'CDec(Me.tbxCantidadVent.Text)
            DetalleVentaTGridView.Rows(LineaVenta).Cells("ProductoDGVT").Value = lblDescripcionProducto.Text
            DetalleVentaTGridView.Rows(LineaVenta).Cells("CodigoBarraDGVT").Value = tbxCodigoProd.Text

            Dim SubTotal As Integer = (PrecioDeVenta * CantidadDeVenta)
            DetalleVentaTGridView.Rows(LineaVenta).Cells("SubTotalDGVT").Value = SubTotal
            DetalleVentaTGridView.Rows(LineaVenta).Cells("CODSUCURSALDataGridViewTextBoxColumn").Value = SucCodigo

            DetalleVentaTGridView.Rows(LineaVenta).Cells("CODSUCURSALDataGridViewTextBoxColumn").Value = SucCodigo

            ' Dim CostoFIFO As String = w.FuncionConsultaString("PRECIO", "CODIGOS", "CODCODIGO =" & CodCodigoTextBox.Text & " AND CODPRODUCTO", CodProductoTextBox.Text)
            DetalleVentaTGridView.Rows(LineaVenta).Cells("COSTOPROMEDIO").Value = vProdCosto * CantidadDeVenta
            DetalleVentaTGridView.Rows(LineaVenta).Cells("PRODPROMOCION").Value = vProdPromocion

            thDescripProductoModif = lblDescripcionProducto.Text
            thCodiProducViejo = CodProductoTextBox.Text
            primeritem = False
            'aqui volver a comentar
            'Try
            '    ThreadPrint = New Thread(New ThreadStart(AddressOf ModificarDetalles))
            '    ThreadPrint.Start()
            'Catch ex As Exception
            'End Try
            'aqui volver a comentar
           
            'AQUI LA IMPRESION DE TICKET "MODIFICAR"

            If lblEnStock.Text <> "Servicio" Then
                DetalleVentaTGridView.Rows(LineaVenta).Cells("Servicio").Value = 0
            Else
                DetalleVentaTGridView.Rows(LineaVenta).Cells("Servicio").Value = 1
            End If

            If tbxCoheficiente.Text = "1,100" Or tbxCoheficiente.Text = "1,10" Then
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IVA").Value = "10%"
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEGRABADODIEZ").Value = SubTotal
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEGRABADOCINCO").Value = 0
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEEXENTO").Value = 0
                DetalleVentaTGridView.Rows(LineaVenta).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = PrecioDeVenta - (PrecioDeVenta / 11)
            ElseIf tbxCoheficiente.Text = "1,050" Or tbxCoheficiente.Text = "1,05" Then
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IVA").Value = "5%"
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEGRABADOCINCO").Value = SubTotal
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEEXENTO").Value = 0
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEGRABADODIEZ").Value = 0
                DetalleVentaTGridView.Rows(LineaVenta).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = PrecioDeVenta - (PrecioDeVenta / 21)
            ElseIf tbxCoheficiente.Text = "1,000" Or tbxCoheficiente.Text = "1,00" Then
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IVA").Value = "0%"
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEEXENTO").Value = SubTotal
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEGRABADOCINCO").Value = 0
                DetalleVentaTGridView.Rows(LineaVenta).Cells("IMPORTEGRABADODIEZ").Value = 0
                DetalleVentaTGridView.Rows(LineaVenta).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = PrecioDeVenta
            End If

            EliminarDetVentaButton.Text = "Eliminar"
            AgregarDetVentaButton.Text = "Agregar"
        Else
            'VENTASBindingSource.AddNew()
            VENTASDETALLEBindingSource.AddNew()

            'Se verifica el tipo de impresion
            Dim c As Integer = DetalleVentaTGridView.RowCount
            Dim w As New Funciones.Funciones

            If TipoImpresion = 1 Then 'Formato Impresora
                'Para saber si imprime y la cantidad de lineas del detalle
                If c > Cantlinea Then
                    MessageBox.Show("No puede Facturar más de " & Cantlinea.ToString & " Lineas!", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    VENTASDETALLEBindingSource.CancelEdit()
                    Exit Sub
                End If
            End If

            PrecioDeVenta = PrecioVentaMaskedEdit.Text
            Dim preciobruto As Decimal = PrecioDeVenta * CantidadDeVenta

            DetalleVentaTGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value = CDec(CodProductoTextBox.Text)
            DetalleVentaTGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value = CodCodigoTextBox.Text
            DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value = PrecioDeVenta
            DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value = preciobruto
            DetalleVentaTGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value = CantidadDeVenta 'CDec(Me.tbxCantidadVent.Text)
            DetalleVentaTGridView.Rows(c - 1).Cells("ProductoDGVT").Value = lblDescripcionProducto.Text
            DetalleVentaTGridView.Rows(c - 1).Cells("CodigoBarraDGVT").Value = tbxCodigoProd.Text
            Dim SubTotal As Integer = (PrecioDeVenta * CantidadDeVenta)
            DetalleVentaTGridView.Rows(c - 1).Cells("SubTotalDGVT").Value = SubTotal
            DetalleVentaTGridView.Rows(c - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn").Value = SucCodigo

            'Dim CostoFIFO As String = w.FuncionConsultaString("PRECIO", "CODIGOS", "CODCODIGO =" & CodCodigoTextBox.Text & " AND CODPRODUCTO", CodProductoTextBox.Text)
            DetalleVentaTGridView.Rows(c - 1).Cells("COSTOPROMEDIO").Value = vProdCosto * CantidadDeVenta
            DetalleVentaTGridView.Rows(c - 1).Cells("PRODPROMOCION").Value = vProdPromocion

            thDescripcionProducto = lblDescripcionProducto.Text
            'aqui volver a comentar
            'Try
            '    ThreadPrint = New Thread(New ThreadStart(AddressOf CargarDetalles))
            '    ThreadPrint.Start()
            'Catch ex As Exception
            'End Trysta
            'aqui volver a comentar
            If lblEnStock.Text <> "Servicio" Then
                DetalleVentaTGridView.Rows(c - 1).Cells("Servicio").Value = 0
            Else
                DetalleVentaTGridView.Rows(c - 1).Cells("Servicio").Value = 1
            End If

            If tbxCoheficiente.Text = "1,100" Or tbxCoheficiente.Text = "1,10" Then
                DetalleVentaTGridView.Rows(c - 1).Cells("IVA").Value = "10%"
                DetalleVentaTGridView.Rows(c - 1).Cells("IMPORTEGRABADODIEZ").Value = SubTotal
                DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = PrecioDeVenta - (PrecioDeVenta / 11)
            ElseIf tbxCoheficiente.Text = "1,050" Or tbxCoheficiente.Text = "1,05" Then
                DetalleVentaTGridView.Rows(c - 1).Cells("IVA").Value = "5%"
                DetalleVentaTGridView.Rows(c - 1).Cells("IMPORTEGRABADOCINCO").Value = SubTotal
                DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = PrecioDeVenta - (PrecioDeVenta / 21)
            ElseIf tbxCoheficiente.Text = "1,000" Or tbxCoheficiente.Text = "1,00" Then
                DetalleVentaTGridView.Rows(c - 1).Cells("IVA").Value = "0%"
                DetalleVentaTGridView.Rows(c - 1).Cells("IMPORTEEXENTO").Value = SubTotal
                DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value = PrecioDeVenta
            End If
        End If

        CalcularTotalesVenta()

        tbxCantidadVent.Text = "" : tbxCodigoProd.Text = "" : PrecioVentaMaskedEdit.Text = "" : lblDescripcionProducto.Text = "" : CostoUltimo.Text = ""
        CodProductoTextBox.Text = "" : CodCodigoTextBox.Text = "" : ErrorCodigoLabel.Visible = False : lblEnStock.Text = "" : VIvaGlobal = 0
        CODIGOSBindingSource.RemoveFilter()

        'Verificamos que tipo de permiso tiene el usuraio
        PrecioVentaMaskedEdit.Appearance.BackColor = Color.WhiteSmoke
        If ModificarPresioVenta = 0 Then
            PrecioVentaMaskedEdit.Enabled = False
        Else
            PrecioVentaMaskedEdit.Enabled = True
        End If

        If Config2 = "Mostrar Siempre" Then
            CodCodigoTextBox.Text = "" : CodComboTextBox.Text = "" : ErrorCodigoLabel.Visible = False

            ProductosGroupBox.Visible = True
            ProductosGroupBox.BringToFront()
            BuscarProductoTextBox.Focus()

            CheckBox1.Checked = False
            BuscarProductoTextBox.Text = ""
            BuscarProductoTextBox.Focus()

            If VenderMasPermiso = 0 Then
                CODIGOSBindingSource.Filter = "STOCKACTUAL > 0"
            End If

            If VerOtrosPrecios = 0 Then
                CheckBox1.Enabled = False
            Else
                CheckBox1.Enabled = True
            End If
        Else
            tbxCodigoProd.Focus()
        End If
    End Sub

    Public Sub CargarDetalles()
        cantImpreTick = cantImpreTick + 1
        If TipoImpresion = 0 Then   'Formato Ticket
            If Imprimir = 1 Then 'Se imprime
                If cantImpreTick > 1 Then
                    primeritem = False
                    CargarDetalle(impresora, CantidadDeVenta, PrecioDeVenta, thDescripcionProducto, primeritem)
                Else
                    primeritem = True
                    CargarDetalle(impresora, CantidadDeVenta, PrecioDeVenta, thDescripcionProducto, primeritem)
                End If
            End If
        End If
    End Sub
    'todo el sub comentar
    'Public Sub ModificarDetalles()
    '    If TipoImpresion = 0 Then   'Formato Ticket
    '        If Imprimir = 1 Then 'Se imprime
    '            If thCodiProducViejo = thCodProducto Then
    '                If PrecioDeVenta = thPrecio Then
    '                    If Not CantidadDeVenta = thCantidad Then
    '                        thCantAux = thCantidad - CantidadDeVenta
    '                        If thCantAux > 0 Then
    '                            EliminarDetalle(impresora, thCantAux, thPrecio, thDescripcionProducto)
    '                        Else
    '                            thCantAux = thCantAux * (-1)
    '                            CargarDetalle(impresora, thCantAux, thPrecio, thDescripcionProducto, primeritem)
    '                        End If
    '                    End If
    '                Else
    '                    thCantAux = CantidadDeVenta
    '                    EliminarDetalle(impresora, thCantidad, thPrecio, thDescripcionProducto)
    '                    CargarDetalle(impresora, thCantAux, PrecioDeVenta, thDescripcionProducto, primeritem)
    '                End If
    '            Else
    '                EliminarDetalle(impresora, thCantidad, thPrecio, thDescripcionProducto)
    '                CargarDetalle(impresora, CantidadDeVenta, PrecioDeVenta, thDescripProductoModif, primeritem)
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub AgregarPagoEfectivoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarPagoEfectivoButton.Click
        Dim f As New Funciones.Funciones
        Dim codtipocobro As Integer

        Try
            codtipocobro = f.FuncionConsulta("CODFORCOBRO", "TIPOFORMACOBRO", _
                                             "DESFORCOBRO='EFECTIVO' OR DESFORCOBRO='Efectivo' or DESFORCOBRO", "efectivo")
        Catch ex As Exception

        End Try

        'Validamos
        If String.IsNullOrEmpty(MontoEfectivoMaskedEdit.Text) Then
            MessageBox.Show("Ingrese el Monto para el Cobro en Efectivo", "POSSEXPRESS")
            MontoEfectivoMaskedEdit.Focus()
            Exit Sub
        ElseIf CDec(MontoEfectivoMaskedEdit.Text) = 0 Then
            MessageBox.Show("Ingrese el Monto mayor a cero", "POSSEXPRESS")
            MontoEfectivoMaskedEdit.Focus()
            Exit Sub
        End If

        If MonedaEfectivoComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Elija la Moneda para el Cobro en Efectivo", "POSSEXPRESS")
            MonedaEfectivoComboBox.Focus()
            Exit Sub
        End If

        'Choefiente Cambio
        Dim Coheficiente As String = w.FuncionConsultaString2("FACTORCOBRO", "COTIZACION", "CODMONEDA", MonedaEfectivoComboBox.SelectedValue & " ORDER BY FECGRA DESC")
        If Coheficiente = Nothing Then
            MessageBox.Show("El coheficiente para " & MonedaEfectivoComboBox.Text & " es íncorrecto o inexistente", "POSSEXPRESS")
            MonedaEfectivoComboBox.Focus()
            Exit Sub
        End If
        VENTASFORMACOBROBindingSource.AddNew()
        Dim c As Integer = CobroEfectivoTGridView.RowCount

        If c > 0 Then
            'Pasamos los datos a la Grilla
            'Tradicional
            CobroEfectivoTGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value = MonedaEfectivoComboBox.SelectedValue
            CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value = CDec(MontoEfectivoMaskedEdit.Text)
            CobroEfectivoTGridView.Rows(c - 1).Cells("DESTIPOCOBRODataGridViewTextBoxColumn").Value = "Efectivo"
            CobroEfectivoTGridView.Rows(c - 1).Cells("FECHACOBRODataGridViewTextBoxColumn").Value = Today
            CobroEfectivoTGridView.Rows(c - 1).Cells("COTIZACION1DataGridViewTextBoxColumn").Value = Coheficiente
            CobroEfectivoTGridView.Rows(c - 1).Cells("CODTIPOCOBRODataGridViewTextBoxColumn").Value = codtipocobro
            CobroEfectivoTGridView.Rows(c - 1).Cells("Moneda").Value = MonedaEfectivoComboBox.Text

        End If
        RecorreEfectivo()
        LimpiarControlesCobro()

        If MontoEfectivoMaskedEdit.Text = "" Then
            btnCobrar.Focus()
        End If
    End Sub

    Private Sub ClienteGridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            'Funcion que Verifica los permisos y inicia ventas, lo separe porque el codigo es muy largo...mire abajo)

            IniciarVentas()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub IniciarVentas()
        If cbxRangoId.SelectedValue = Nothing Then
            MessageBox.Show("Elija un Rango de Comprobante. En caso que no haya opciones, sera necesario crear un nuevo rango antes de iniciar.", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

            CodComprobante = w.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", cbxRangoId.SelectedValue)

            'Para saber si imprime y la cantidad de lineas del detalle
            Cantlinea = w.FuncionConsulta("NROLINEASDETALLE", "TIPOCOMPROBANTE", "CODCOMPROBANTE", CodComprobante)


            Dim F As New Funciones.Funciones
            impresora = F.FuncionConsultaString("IMPRESORA", "DETPC", "RANDOID=" & cbxRangoId.SelectedValue & "AND ACTIVO", 1)
        End If

        Dim fechafacturar As String
        fechafacturar = Today.ToShortDateString

        If impresora = "" And Imprimir = 1 Then
            MessageBox.Show("Esta maquina no tiene impresora asignada", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If RadComboBoxTipoCliente.SelectedValue = Nothing Then
            MessageBox.Show("Este Cliente no pertenece a una Lista de Precio, asigne antes de continuar", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If VarTablaRangoComprobante = 0 Or VarCliente = 0 Then
            MessageBox.Show("Asegurece de que el Comprobante y el Cliente son Válidos", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            FacturacionPanel.BringToFront()
            panelactivo = "FacturacionPanel"

            primeritem = True : cantImpreTick = 0 : btnCobrar.Enabled = False

            VENTASBindingSource.AddNew()

            'limpiamos
            tbxCantidadVent.Text = "" : tbxCodigoProd.Text = "" : PrecioVentaMaskedEdit.Text = "" : lblDescripcionProducto.Text = "" : lblVentaTotal.Text = ""

            If Config1 = "No" Then
                CobrarButton.Text = "Imprimir Factura"
            Else
                CobrarButton.Text = "Cobrar"
            End If

            tbxCodigoProd.Focus()

            'Labels Cliente, Venta y Cobro
            ClienteLabel.ForeColor = Color.Black
            VentaLabel.ForeColor = Color.WhiteSmoke
            COBROLabel.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BancoChequeComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BancoChequeComboBox.KeyPress, MonedaChequeComboBox.KeyPress, FechaCobroChequeTextBox.KeyPress, NroChequeTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
    End Sub

    Private Sub BancoDebitoComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BancoDebitoComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
    End Sub

    Private Sub btnGuardarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCliente.Click
        'Validamos
        If NombreClienteTextBox.Text = "" Then
            MessageBox.Show("Nombre del Cliente no puede quedar vacio", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NombreClienteTextBox.Focus()
            Exit Sub
        End If
        If RadComboBoxTipoCliente.SelectedValue = Nothing Then
            MessageBox.Show("Seleccione una Lista de Precio", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RadComboBoxTipoCliente.Focus()
            Exit Sub
        End If

        If CodClienteTextBox.Text = "" Then
            DeshabilitaCliente()
            Exit Sub
        End If

        If AccEditar = 1 Then
            'ACTUALIZA
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "ActualizaCliente")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaCliente()

                myTrans.Commit()

                Dim Indice As Integer = CLIENTESBindingSource.Position
                CLIENTESTableAdapter.Fill(DsFacturacionSimple.CLIENTES)
                CLIENTESBindingSource.Position = Indice

            Catch ex As Exception
                Try
                    myTrans.Rollback("ActualizaCliente")
                Catch

                End Try
                MessageBox.Show("Ocurrio un error al intentar actualizar el Cliente" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Finally
                sqlc.Close()

            End Try
        Else
            'INSERTA
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "InsertaCliente")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaCliente()
                myTrans.Commit()

                CLIENTESTableAdapter.Fill(DsFacturacionSimple.CLIENTES)
                CLIENTESBindingSource.MoveLast()

            Catch ex As Exception
                Try
                    myTrans.Rollback("InsertaCliente")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error al insertar el Cliente", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Finally
                sqlc.Close()
            End Try

        End If
        DeshabilitaCliente()
        lblMsgNuevoCliente.Visible = False
        BuscarClientesTextBox.Focus()
        btnIniciarVenta.Enabled = True
    End Sub

    Private Sub btnNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClienteNuevo.Click
        AccNuevo = 1 : AccEditar = 0
        CLIENTESBindingSource.AddNew()

        HabilitaCliente()
        NombreClienteTextBox.Focus()
        btnIniciarVenta.Enabled = False
    End Sub

    Private Sub BuscarClientesTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarClientesTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If dgvClientes.RowCount > 0 Then
                dgvClientes.Focus()
            Else
                btnClienteNuevo.PerformClick()
                NombreClienteTextBox.Focus()
                NombreClienteTextBox.Text = BuscarClientesTextBox.Text
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub BuscarClientesTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarClientesTextBox.TextChanged
        CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & BuscarClientesTextBox.Text & "%' OR RUC LIKE '%" & BuscarClientesTextBox.Text & "%' "

        If dgvClientes.RowCount = 0 Then
            lblMsgNuevoCliente.Visible = True
        Else
            lblMsgNuevoCliente.Visible = False
        End If

    End Sub

    Private Sub BuscarProductoTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.GotFocus
        If BuscarProductoTextBox.Text = "Buscar..." Then
            BuscarProductoTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarProductoTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles BuscarProductoTextBox.KeyDown
        If e.KeyCode = Keys.Escape Then
            ProductosGroupBox.Visible = False
            tbxCodigoProd.Focus()
            CheckBox1.BackColor = Color.Transparent

            If VerOtrosPrecios = 0 Then
                CheckBox1.Enabled = False
            Else
                CheckBox1.Enabled = True
            End If

        ElseIf e.KeyCode = Keys.F2 Then
            ParaListaPrecio = 1 : ParaPrecio = 0 : ParaEliminar = 0 : ParaUltimoPanel = 0
            ProductosGroupBox.Visible = False
            pnlCambiarPrecio.Visible = True
            pnlCambiarPrecio.BringToFront()

            txtCodigoSupervisor.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            ProductosGridView.Focus()
        End If

    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProductosGridView.Focus()
        End If
    End Sub

    Private Sub BuscarProductoTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.LostFocus
        If BuscarProductoTextBox.Text = "" Then
            BuscarProductoTextBox.Text = "Buscar..."
        End If
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        'If TabBuscador.SelectedTab.Name = "Producto" Then
        If BuscarProductoTextBox.Text <> "Buscar..." Then
            If ProductosGridView.Visible = True Then
                If VenderMasPermiso = 0 Then 'no puede vender y llegar a negativo
                    CODIGOSBindingSource.Filter = "STOCKACTUAL >0 AND (DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%')"
                ElseIf VenderMasPermiso = 1 Then
                    CODIGOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
                End If
            Else
                ListaprecioBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%'"
            End If
        End If


    End Sub

    Private Sub CalculaNroFactura(ByVal UltimoRango As Integer, ByVal ControlHasta As Integer, ByVal IdPCRango As Integer)
        Dim NumSucursal, NumMaquina, NroRango, sql As String
        Dim NroDigitos As Integer

        NroDigitos = f.FuncionConsultaDecimal("NRODIGITOS", "DETPC", "ACTIVO = 1 AND RANDOID", cbxRangoId.SelectedValue)
        NroRango = ""
        NumSucursal = SucCodigo
        NumMaquina = NumMaquinaGlobal
        If cambioNroFact = 0 Then
            'Verificamos en la base de datos si el rango ya fue usado , en caso contrario le asignamos otro
            ' If UltimoRango <> 0 Then
            NroRango = UltimoRango + 1
            'End If

            If SucCodigo = 0 Then
                NumSucursal = "XXX"
            ElseIf Len(NumSucursal) = 1 Then
                NumSucursal = "00" & CStr(NumSucursal)
            ElseIf Len(NumSucursal) = 2 Then
                NumSucursal = "0" & CStr(NumSucursal)
            ElseIf Len(NumSucursal) = 3 Then
                NumSucursal = CStr(NumSucursal)
            End If

            If NumMaquina = "0" Then
                NumMaquina = "XXX"
            ElseIf Len(NumMaquina) = 1 Then
                NumMaquina = "00" & CStr(NumMaquina)
            ElseIf Len(NumMaquina) = 2 Then
                NumMaquina = "0" & CStr(NumMaquina)
            ElseIf Len(IpMaquina) = 3 Then
                NumMaquina = CStr(NumMaquina)
            End If

            For i = 1 To NroDigitos
                If Len(NroRango) = NroDigitos Then
                    Exit For
                Else
                    NroRango = "0" & NroRango
                End If
            Next

            NumVenta = NumSucursal & "." & NumMaquina & "." & NroRango
        Else
            'Numventa Ya tomo su valor
            NroRango = tbxUltimosNros.Text
        End If
        NroFacturaLabel.Text = NumVenta

        Dim transaction As SqlTransaction = Nothing
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            If NroRango = ControlHasta Then
                sql = "UPDATE DETPC SET ULTIMO = " & NroRango & ", ACTIVO = 0 WHERE RANDOID = " & IdPCRango
            Else
                sql = "UPDATE DETPC SET ULTIMO = " & NroRango & "  WHERE RANDOID = " & IdPCRango
            End If

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()

            sqlc.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstiraNroFactura(ByVal UltimoRango As Integer)
        Dim NumSucursal, NumMaquina, NroRango As String
        Dim NroDigitos As Integer

        NroDigitos = f.FuncionConsultaDecimal("NRODIGITOS", "DETPC", "ACTIVO = 1 AND RANDOID", cbxRangoId.SelectedValue)
        NroRango = ""
        NumSucursal = SucCodigo
        NumMaquina = NumMaquinaGlobal

        'Verificamos en la base de datos si el rango ya fue usado , en caso contrario le asignamos otro
        ' If UltimoRango <> 0 Then
        NroRango = UltimoRango + 1
        'End If

        If SucCodigo = 0 Then
            NumSucursal = "XXX"
        ElseIf Len(NumSucursal) = 1 Then
            NumSucursal = "00" & CStr(NumSucursal)
        ElseIf Len(NumSucursal) = 2 Then
            NumSucursal = "0" & CStr(NumSucursal)
        ElseIf Len(NumSucursal) = 3 Then
            NumSucursal = CStr(NumSucursal)
        End If

        If NumMaquina = "0" Then
            NumMaquina = "XXX"
        ElseIf Len(NumMaquina) = 1 Then
            NumMaquina = "00" & CStr(NumMaquina)
        ElseIf Len(NumMaquina) = 2 Then
            NumMaquina = "0" & CStr(NumMaquina)
        ElseIf Len(IpMaquina) = 3 Then
            NumMaquina = CStr(NumMaquina)
        End If

        For i = 1 To NroDigitos
            If Len(NroRango) = NroDigitos Then
                Exit For
            Else
                NroRango = "0" & NroRango
            End If
        Next

        lblPrimerosNros.Text = NumSucursal & "." & NumMaquina & "."
        tbxUltimosNros.Text = NroRango
    End Sub

    Private Sub CancelarClienteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarCliente.Click

        Dim CodClienteGlobal As Integer
        Dim NomCliente As String = ""

        Dim UltimoCliente As Integer
        UltimoCliente = f.Maximo("CODCLIENTE", "CLIENTES")
        CodClienteGlobal = UltimoCliente
        If CodClienteTextBox.Text <> "" Then

            'NomCliente = w.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", CodClienteGlobal)
        End If
        If NombreClienteTextBox.Text = "" Then

            Dim consulta As System.String
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            conexion = ser.Abrir()

            Try
                consulta = ""
                consulta = consulta + "DELETE FROM CLIENTES  WHERE  CODCLIENTE=" & CodClienteGlobal

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
            Catch ex As SqlException

            End Try
        End If
        CLIENTESBindingSource.CancelEdit()
        DeshabilitaCliente()
        btnIniciarVenta.Enabled = True
        BuscarClientesTextBox.Focus()
    End Sub

    Private Sub CancelarVentaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarVentaButton.Click
        VENTASBindingSource.CancelEdit()
        EstadoInicial()

        lblVentaTotal.Text = "" : lblNombreCliente.Text = "" : BuscarClientesTextBox.Text = ""

        BuscarClientesTextBox.Focus()
    End Sub

    Public Sub CancelarVentas()
        If TipoImpresion = 0 Then   'Formato Ticket
            If Imprimir = 1 Then 'Se imprime
                CancelarVenta(impresora)
            End If
        End If
    End Sub

    Private Sub tbxCantidadVent_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCantidadVent.GotFocus
        Try

            If CodProductoTextBox.Text <> "" Then
                Me.PRECIOTableAdapter.Fill(Me.DsFacturacionSimple.PRECIO, CodProductoTextBox.Text)
            End If
            If gbxListaPrecio.Visible = False Then
                If Config5 = "Mostrar Siempre" Then
                    If CodProductoTextBox.Text <> "" Then
                        gbxListaPrecio.Visible = True
                        gbxListaPrecio.BringToFront()

                        tbxBuscaLista.Text = ""
                        tbxBuscaLista.Focus()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tbxCantidadVent_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbxCantidadVent.KeyDown
        If e.KeyCode = Keys.F2 Then
            pnlCambiarPrecio.Visible = True
            pnlCambiarPrecio.BringToFront()
            ParaPrecio = 1 : ParaListaPrecio = 0 : ParaEliminar = 0 : ParaUltimoPanel = 0
            txtCodigoSupervisor.Focus()
        End If
    End Sub

    Private Sub CantidadVentaMaskedEdit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxCantidadVent.LostFocus
        If panelactivo = "FacturacionPanel" Then
            If tbxCantidadVent.Text = "" Then
                tbxCantidadVent.Text = 1
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CheckBox1.Checked = False Then
                Try
                    Me.CODIGOSTableAdapter.Fill(Me.DsFacturacionSimple.CODIGOS, SucCodigo, RadComboBoxTipoCliente.SelectedValue)
                Catch ex As Exception

                End Try
            Else
                Try
                    Me.CODIGOSTableAdapter.FillByTodos(Me.DsFacturacionSimple.CODIGOS, SucCodigo)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChequePanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChequePanel.Click, ChequePictureBox.Click
        Cheque()
        RecorreEfectivo()
        BancoChequeComboBox.Focus()
    End Sub

    Private Sub ChequePanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles EfectivoPanel.MouseLeave, DebitoPanel.MouseLeave, TarjetaPanel.MouseLeave, ChequePanel.MouseLeave, EfectivoPictureBox.MouseLeave, DebitoPictureBox.MouseLeave, TarjetaPictureBox.MouseLeave, ChequePictureBox.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CobrarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobrarButton.Click
        If DetalleVentaTGridView.RowCount = 0 Then
            MessageBox.Show("No se puede Cobrar: No hay Items para Facturar", "POSSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxCodigoProd.Focus()
        Else
            If CobrarButton.Text = "Imprimir Factura" And Config6 = "Si" Then
                Try
                    Dim UltimoRango As Integer
                    UltimoRango = f.FuncionConsultaString("ULTIMO", "DETPC", "RANDOID", cbxRangoId.SelectedValue)
                    'Obtenermos el Sgte. Nro. FActura
                    EstiraNroFactura(UltimoRango)
                    pnlCambioNroFact.BringToFront()
                    pnlCambioNroFact.Visible = True
                    cambiofact = 1
                    tbxUltimosNros.Focus()
                    tbxUltimosNros.SelectionStart = tbxUltimosNros.Text.Length
                    cambiofact = 0
                Catch ex As Exception
                    MessageBox.Show("Problema con el Rango Activo: " + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    pnlCambioNroFact.Visible = False
                End Try
            Else
                CobrarButtonClick2()
            End If
        End If
    End Sub

    Private Sub CobrarButtonClick2()
        If CobrarButton.Text = "Cobrar" Or CobrarButton.Text = "Imprimir Factura" Then

            DebeLabel.Text = lblVentaTotal.Text
            PagoLabel.Text = "0"

            If Config1 = "No" Then 'Para Saltar el panel de Cobros - Integrar Cobro : No
                ProcesarVenta()

                GraciasPanel.BringToFront()
                panelactivo = "GraciasPanel"
                VueltoLabel.Text = "0"
                RadButton1.Focus()

                If Config9 = "Si" Then  'Si se desea integrar contablidad en el modulo de ventas simples
                    '-------------------------------------------- CONTABILIDAD ------------------------------------------------------------------------------------
                    'Obtenemos los valores que se utilizaron el modulo de contabilidad - by Yolanda Zelaya 
                    Dim ConceptoAsiento, IVA5, IVA10, IVAEXE, TOTALIVA, ClienteProveedor, cadena As String
                    Dim Coti As Double

                    IVA5 = TotalCinco.Text
                    IVA10 = TotalDiez.Text
                    IVAEXE = TotalExentaMaskedEdit.Text
                    TOTALIVA = tbxGrav10.Text

                    ClienteProveedor = CodClienteTextBox.Text

                    cadena = CInt(MonedaEfectivoComboBox.SelectedValue) & " ORDER BY FECHAMOVIMIENTO DESC"

                    Cotizacion1 = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", cadena)
                    Cotizacion1 = Cotizacion1.Replace(".", "")
                    Coti = Cotizacion1


                    ConceptoAsiento = "Factura de Venta Contado / " & NombreClienteTextBox.Text
                    ReglaContable(IVAEXE, IVA5, IVA10, TOTALIVA, "VENTAS", CDec(CodVentaTextBox.Text), "CODVENTA", ConceptoAsiento, 1, 1, _
                                  CODMONEDAPRINCIPAL, Coti, NumVenta, Today, CDec(lblVentaTotal.Text), "8", TimbradoFactura, ClienteProveedor, SucCodigo)
                    '------------------------------------------------------------------------------------------------------------------------------------------------
                End If

            Else ' Integrar Cobro : Si
                CobroPanel.BringToFront()
                panelactivo = "CobroPanel"

                ClienteLabel.ForeColor = Color.Black
                VentaLabel.ForeColor = Color.Black
                COBROLabel.ForeColor = Color.WhiteSmoke
                TotalVenta = FaltaLabel.Text

                MontoEfectivoMaskedEdit.Focus()
            End If
        End If

    End Sub

    Private Sub CobrarPanel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub CobrarPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub tbxCodigoProd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCodigoProd.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 42 Then
            CodCodigoTextBox.Text = "" : CodComboTextBox.Text = ""
            ErrorCodigoLabel.Visible = False : ProductosGroupBox.Visible = True
            ProductosGroupBox.BringToFront()

            ProductosGridView.Enabled = True
            ProductosGridView.Visible = True
            ProductosGridView.BringToFront()

            dgv_precios2.Visible = False
            dgv_precios2.Enabled = False
            dgv_precios2.SendToBack()

            CheckBox1.Checked = False
            BuscarProductoTextBox.Text = ""
            buscador = 1
            BuscarProductoTextBox.Focus()
            buscador = 0
            BuscarProductoTextBox.Enabled = True : BuscarProductoTextBox.ReadOnly = False

            If VenderMasPermiso = 0 Then
                CODIGOSBindingSource.Filter = "STOCKACTUAL > 0"
            End If

            If VerOtrosPrecios = 0 Then
                CheckBox1.Enabled = False
            Else
                CheckBox1.Enabled = True
            End If

            e.Handled = True

        ElseIf KeyAscii = 43 Then
            Try
                Me.ListaprecioTableAdapter.Fill(Me.Consultaprecio_ventasimple.Listaprecio)
                CodCodigoTextBox.Text = "" : CodComboTextBox.Text = ""
                ErrorCodigoLabel.Visible = False : ProductosGroupBox.Visible = True
                ProductosGroupBox.BringToFront()

                CheckBox1.Checked = True
                BuscarProductoTextBox.Text = ""
                buscador = 1
                BuscarProductoTextBox.Focus()
                buscador = 0
                BuscarProductoTextBox.Enabled = True : BuscarProductoTextBox.ReadOnly = False

                ProductosGridView.Visible = False
                ProductosGridView.Enabled = False
                ProductosGridView.SendToBack()

                dgv_precios2.Visible = True
                dgv_precios2.Enabled = True
                dgv_precios2.BringToFront()
            Catch ex As Exception
                MessageBox.Show("Por favor presione * si quiere ver la lista de productos", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If

        If KeyAscii = 13 Then
            tbxCantidadVent.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCodigoProdTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxCodigoProd.LostFocus
        Dim VCodProducto, VCodCodigo, VDesProducto, VCantStock, VPrecioVenta As String
        Dim codigodebarra As String = "" 'Esta variable la utilizo porque desde el lector me trae 13 digitos y en la base de datos tengo 12 y a veces 11
        Dim vServicio, vPesable As Integer
        If buscador = 0 And cambiofact = 0 Then
            ErrorCodigoLabel.Visible = False
            If panelactivo = "FacturacionPanel" Then
                'Try
                If tbxCodigoProd.Text <> "" Then
                    CODIGOSBindingSource.RemoveFilter()
                    vPesable = w.FuncionConsultaDecimal("CODCODIGO", "CODIGOS", "CODIGO", tbxCodigoProd.Text)

                    If vPesable = 0 Then 'Si es cero todavia puede ser un producto pesable
                        If tbxCodigoProd.TextLength > 7 Then
                            codigodebarra = tbxCodigoProd.Text.Remove(7, tbxCodigoProd.TextLength - 7)
                            vPesable = w.FuncionConsultaDecimal("CODCODIGO", "CODIGOS", "CODIGO", codigodebarra)
                        End If
                    Else
                        codigodebarra = tbxCodigoProd.Text
                    End If

                    If vPesable = 0 Then 'Si es cero no existe el producto
                        ErrorCodigoLabel.Visible = True
                        tbxCodigoProd.Focus()
                        Exit Sub
                    End If

                    CODIGOSBindingSource.Filter = "CODIGO = '" & codigodebarra & "'"

                    If ProductosGridView.RowCount <> 0 Then
10:                     vServicio = ProductosGridView.Rows(0).Cells("SERVICIODGVT").Value
                        'Si es Servicio VServicio = 1 (al contrario es 0)
                        If vServicio = 0 Then
                            VCantStock = ProductosGridView.Rows(0).Cells("STOCKACTUALDataGridViewTextBoxColumn").Value
                            lblEnStock.Text = VCantStock
                        Else
                            VCantStock = 0
                            lblEnStock.Text = "Servicio"
                        End If


                        If (vServicio = 1) Or (VCantStock > 0) Then
20:                         VCodCodigo = ProductosGridView.Rows(0).Cells("CODCODIGO").Value
                            VCodProducto = ProductosGridView.Rows(0).Cells("CODPRODUCTO").Value
                            'Para traer la cantidad con codigo de balanza
                            'If (tbxCodigoProd.Text.IndexOf("200") = 0 And tbxCodigoProd.Text.Length = 13) Or (tbxCodigoProd.Text.IndexOf("240") = 0 And tbxCodigoProd.Text.Length = 13) Then
                            vPesable = w.FuncionConsultaDecimal("PESABLE", "CODIGOS", "CODCODIGO", VCodCodigo)
                            If vPesable = 1 Then
                                Dim CantidadExtraida As String = tbxCodigoProd.Text.Remove(0, 7)
                                Dim Entero As String = CantidadExtraida.Remove(2, 4)
                                Dim Fraccion As String = CantidadExtraida.Remove(0, 2)
                                tbxCantidadVent.Text = Entero + "," + Fraccion
                                tbxCantidadVent.Text = tbxCantidadVent.Text.Remove(6, 1)
                                ProdPE = 1
                            End If

                            VDesProducto = ProductosGridView.Rows(0).Cells("PRODUCTODataGridViewTextBoxColumn").Value
                            VPrecioVenta = ProductosGridView.Rows(0).Cells("PRECIOVENTA").Value
                            Me.tbxCoheficiente.Text = FormatNumber(ProductosGridView.Rows(0).Cells("COHEFICIENTE").Value, 2)

                            If IsDBNull(ProductosGridView.Rows(0).Cells("PROMOCION").Value) Then
                                vProdPromocion = 0
                            Else
                                If ProductosGridView.Rows(0).Cells("PROMOCION").Value = True Then
                                    vProdPromocion = 1
                                Else
                                    vProdPromocion = 0
                                End If
                            End If

                            If IsDBNull(ProductosGridView.Rows(0).Cells("PRODCOSTO").Value) Then
                                vProdCosto = 1
                            Else
                                vProdCosto = ProductosGridView.Rows(0).Cells("PRODCOSTO").Value
                            End If

                            CodProductoTextBox.Text = VCodProducto
                            CodCodigoTextBox.Text = VCodCodigo
                            lblDescripcionProducto.Text = VDesProducto
                            PrecioVentaMaskedEdit.Text = VPrecioVenta
                            ErrorCodigoLabel.Visible = False

                        Else
                            If VenderMasPermiso = 0 Then
                                MessageBox.Show("Stock Insuficiente para realizar la Venta", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                CodProductoTextBox.Text = ""
                                CodCodigoTextBox.Text = ""
                                lblDescripcionProducto.Text = ""
                                PrecioVentaMaskedEdit.Text = ""
                                tbxCantidadVent.Focus()
                                Exit Sub
                            Else
                                GoTo 20
                            End If
                        End If
                    Else
                        If RadComboBoxTipoCliente.SelectedValue <> VCodTipoClientePrioridad Then
                            Me.CODIGOSTableAdapter.FillByTodos(Me.DsFacturacionSimple.CODIGOS, SucCodigo)
                            CODIGOSBindingSource.Filter = "CODIGO = '" & codigodebarra & "' AND CODTIPOCLIENTE = " & VCodTipoClientePrioridad & ""
                        End If
                        If ProductosGridView.RowCount <> 0 Then
                            GoTo 10
                        Else
                            ErrorCodigoLabel.Visible = True
                            CodProductoTextBox.Text = ""
                            CodCodigoTextBox.Text = ""
                            lblDescripcionProducto.Text = ""
                            PrecioVentaMaskedEdit.Text = ""
                            tbxCantidadVent.Focus()
                            Exit Sub
                        End If
                    End If
                Else
                    ErrorCodigoLabel.Visible = True
                End If

                'tbxCantidadVent.Focus()
            End If
        End If
    End Sub

    Private Sub CodigoProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxCodigoProd.TextChanged
        Limpiarcodigos()
    End Sub

    Private Sub DebitoPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DebitoPanel.Click, DebitoPictureBox.Click
        Debito()
        RecorreEfectivo()
        cbxMonedaTrCredito.Focus()
    End Sub

    Private Sub DeshabilitaCliente()
        btnClienteNuevo.Enabled = True
        btnGuardarCliente.Enabled = False
        btnModificarCliente.Visible = True
        btnCancelarCliente.Visible = False

        dgvClientes.Enabled = True
        BuscarClientesTextBox.Enabled = True

        'Habilitar el Formulario
        NombreClienteTextBox.Enabled = False
        RUCClienteTextBox.Enabled = False
        DireccionClienteTextBox.Enabled = False
        TelefonoClienteTextBox.Enabled = False
        RadComboBoxTipoCliente.Enabled = False
    End Sub

    Private Sub EfectivoPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EfectivoPanel.Click, EfectivoPictureBox.Click
        Efectivo()
        RecorreEfectivo()
        MonedaEfectivoComboBox.Focus()
    End Sub

    Private Sub EfectivoPanel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles EfectivoPanel.MouseEnter, DebitoPanel.MouseEnter, TarjetaPanel.MouseEnter, ChequePanel.MouseEnter, EfectivoPictureBox.MouseEnter, DebitoPictureBox.MouseEnter, TarjetaPictureBox.MouseEnter, ChequePictureBox.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub EliminarDetChequeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarDetChequeButton.Click, EliminarDetTarjetaButton.Click, EliminarPagoEfectivoButton.Click, EliminarDetDebitoButton.Click
        Try
            CobroEfectivoTGridView.Rows.Remove(Me.CobroEfectivoTGridView.CurrentRow)
        Catch ex As Exception

        End Try
        RecorreEfectivo()
    End Sub

    Private Sub EliminarDetVentaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarDetVentaButton.Click
        If EliminarDetVentaButton.Text = "Eliminar" Then
            If DetalleVentaTGridView.RowCount > 0 Then

                permiso = PermisoAplicado(UsuCodigo, 225)
                If permiso = 0 Then
                    pnlCambiarPrecio.Visible = True
                    pnlCambiarPrecio.BringToFront()
                    ParaPrecio = 0 : ParaListaPrecio = 0 : ParaEliminar = 1 : ParaUltimoPanel = 0
                    txtCodigoSupervisor.Focus()
                Else
                    Try
                        Dim Precio, Cantidad, DescripcionProducto As String

                        Precio = DetalleVentaTGridView.CurrentRow.Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                        Cantidad = DetalleVentaTGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                        DescripcionProducto = DetalleVentaTGridView.CurrentRow.Cells("ProductoDGVT").Value

                        'If TipoImpresion = 0 Then   'Formato Ticket
                        '    If Imprimir = 1 Then 'Se imprime
                        '        EliminarDetalle(impresora, Cantidad, Precio, DescripcionProducto)
                        '    End If
                        'End If

                        DetalleVentaTGridView.Rows.Remove(Me.DetalleVentaTGridView.CurrentRow)

                        CalcularTotalesVenta()
                        tbxCodigoProd.Focus()
                    Catch ex As Exception
                    End Try
                End If
            End If

            If PuedeEliminarDetalle = 0 Then
                EliminarDetVentaButton.Enabled = False
            Else
                EliminarDetVentaButton.Enabled = True
            End If

        Else
            tbxCantidadVent.Text = "" : tbxCodigoProd.Text = "" : PrecioVentaMaskedEdit.Text = "" : lblDescripcionProducto.Text = ""
            EliminarDetVentaButton.Text = "Eliminar" : AgregarDetVentaButton.Text = "Agregar"
            tbxCodigoProd.Focus()
        End If
    End Sub

    Private Sub CalcularTotalesVenta()
        Dim Iva10, Iva5, Excento As Double
        Iva5 = 0 : Iva10 = 0 : Excento = 0
        'Recorremos Detalle para sumar las columnas de Grabado 10, 5, 0
        For i = 0 To DetalleVentaTGridView.RowCount - 1
            If IsDBNull(DetalleVentaTGridView.Rows(i).Cells("IMPORTEGRABADOCINCO").Value) Then
            Else
                Iva5 = Iva5 + DetalleVentaTGridView.Rows(i).Cells("IMPORTEGRABADOCINCO").Value
            End If
            If IsDBNull(DetalleVentaTGridView.Rows(i).Cells("IMPORTEGRABADODIEZ").Value) Then
            Else
                Iva10 = Iva10 + DetalleVentaTGridView.Rows(i).Cells("IMPORTEGRABADODIEZ").Value
            End If
            If IsDBNull(DetalleVentaTGridView.Rows(i).Cells("IMPORTEEXENTO").Value) Then
            Else
                Excento = Excento + DetalleVentaTGridView.Rows(i).Cells("IMPORTEEXENTO").Value
            End If
        Next

        lblVentaTotal.Text = Iva5 + Iva10 + Excento
        lblVentaTotal.Text = FormatNumber(lblVentaTotal.Text, 0)
        TotalExentaMaskedEdit.Text = FormatNumber(Excento, 1)
        tbxGrav5.Text = FormatNumber(Iva5, 1)
        tbxGrav10.Text = FormatNumber(Iva10, 1)

        Iva5 = 0 : Iva10 = 0 : Excento = 0
    End Sub

    Private Sub EstadoInicial()
        'Aqui ponemos el formulario en estado para una nueva Venta
        CLIENTESBindingSource.CancelEdit()
        VENTASBindingSource.CancelEdit()
        VENTASFORMACOBROBindingSource.CancelEdit()

        lblVentaTotal.Text = "" : TotalExentaMaskedEdit.Text = "" : tbxGrav5.Text = "" : tbxGrav10.Text = ""
        lblVentaTotal.Text = ""
        lblNombreCliente.Text = ""
        BuscarClientesTextBox.Text = ""
        vProdPromocion = 0 : vProdCosto = 0
        FechaLabel.Text = Today.ToLongDateString

        'paneles
        ClientesPanel.BringToFront()
        panelactivo = "ClientesPanel"

        'Labels Cliente, Venta y Cobro
        ClienteLabel.ForeColor = Color.WhiteSmoke
        VentaLabel.ForeColor = Color.Black
        COBROLabel.ForeColor = Color.Black

        ErrorCodigoLabel.Visible = False
    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1, CONFIG2, CONFIG3, CONFIG4, CONFIG5, CONFIG6,CONFIG7,CONFIG8,CONFIG9,CONFIG10, CONFIG11 FROM MODULO WHERE MODULO_ID = 30"
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
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FacturacionSimpleCompleto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        permiso = PermisoAplicado(UsuCodigo, 25)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Abrir esta Ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            primeritem = True
            ClientesPanel.BringToFront()
            BuscarClientesTextBox.Focus()

            ObtenerConfig()

            NroVentaGlobal = 0

            Me.VENDEDORTableAdapter.Fill(Me.DsFacturacionSimple.VENDEDOR)
            Me.TIPOCLIENTETableAdapter.Fill(Me.DsFacturacionSimple.TIPOCLIENTE)
            Me.BANCOTableAdapter.Fill(Me.DsFacturacionSimple.BANCO)
            Me.TIPOTARJETATableAdapter.Fill(Me.DsFacturacionSimple.TIPOTARJETA)
            Me.MONEDATableAdapter.Fill(Me.DsFacturacionSimple.MONEDA)
            Me.CLIENTESTableAdapter.Fill(Me.DsFacturacionSimple.CLIENTES)



            VCodTipoClientePrioridad = w.FuncionConsulta("CODTIPOCLIENTE", "TIPOCLIENTE", "PRIORIDAD", 1)

            Me.PCTableAdapter.Fill(Me.DsFacturacionSimple.PC, SucCodigo, CodigoMaquina)
            Me.DETPCTableAdapter.Fill(Me.DsFacturacionSimple.DETPC)
            Dim dt As DataTable = DETPCTableAdapter.GetData()

            lblEnStock.Text = ""
            SucursalLabel.Text = SucDescripcion
            FechaLabel.Text = Today.ToLongDateString
            panelactivo = "ClientesPanel"

            If Config1 = "No" Then
                CobrarButton.Text = "Imprimir Factura"
                lblImprCobrar.Text = "F12 - Para Imprimir"
            End If

            If Config7 = "Sin Decimales" Then
                DetalleVentaTGridView.Columns("CANTIDADVENTADataGridViewTextBoxColumn").DefaultCellStyle.Format = "N0"
            Else
                DetalleVentaTGridView.Columns("CANTIDADVENTADataGridViewTextBoxColumn").DefaultCellStyle.Format = "N3"
            End If

            MaxIdApertura = w.MaximoconWhere("id_apertura", "aperturas", "id_caja", NumCaja)
            If MaxIdApertura > 0 Then
                Dim ExisteCierre As Integer = w.MaximoconWhere("id_apertura", "cierres", "id_apertura", MaxIdApertura)
                If ExisteCierre > 0 Then
                    MessageBox.Show("Caja Actual Cerrada, Favor de apertura a una Caja o Cambie de Caja.", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Close()
                    Exit Sub
                End If
            Else
                If Config1 = "Si" Then
                    MessageBox.Show("Caja Actual Cerrada, Favor de apertura a una Caja o Cambie de Caja.", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Close()
                    Exit Sub
                End If
            End If

            'Tab Clientes
            DeshabilitaCliente()
            FechaCobroChequeTextBox.Text = Today

            'Verificamos si el usuario tambien es un vendedor para mostrar dicho nombre primero
            Dim CodigoVendedor As Integer
            Dim x As New Funciones.Funciones

            CodigoVendedor = x.FuncionConsulta("CODVENDEDOR", "VENDEDOR", "CODUSUARIO", UsuCodigo)
            If (CodigoVendedor <> 0) Or (CodigoVendedor <> Nothing) Then
                VENDEDORBindingSource.Position = VENDEDORBindingSource.Find("CODVENDEDOR", CodigoVendedor)
            End If

            Me.Text = "Ventas Simple | Sistema COGENT | Usuario:  " + UsuNombre + "  | Caja Nro: " + NumCaja.ToString

            'Permisos
            VenderMasPermiso = PermisoAplicado(UsuCodigo, 201)
            ModificarPresioVenta = PermisoAplicado(UsuCodigo, 223)
            VerOtrosPrecios = PermisoAplicado(UsuCodigo, 224)
            PuedeEliminarDetalle = PermisoAplicado(UsuCodigo, 225)
            ReimprimirOtroNro = PermisoAplicado(UsuCodigo, 193)
            AnularFactura = PermisoAplicado(UsuCodigo, 30)
            ReimprimirMismoNro = PermisoAplicado(UsuCodigo, 192)
            CambiarVendedor = PermisoAplicado(UsuCodigo, 260)
            If CambiarVendedor = 0 Then
                VendendorComboBox.Enabled = False
            End If

            ClienteLabel.ForeColor = Color.WhiteSmoke
            VentaLabel.ForeColor = Color.Black
            COBROLabel.ForeColor = Color.Black

            ParaPrecio = 0 : ParaListaPrecio = 0 : ParaEliminar = 0 : ParaUltimoPanel = 0

            If Config8 = "Precio por Cantidad" Then
                PRECIOXCANT.Visible = True
                PRECIOVENTA.Visible = False
                ProductosGridView.ScrollBars = ScrollBars.Both
            Else
                PRECIOVENTA.Visible = True
                PRECIOXCANT.Visible = False
                ProductosGridView.ScrollBars = ScrollBars.Vertical
            End If
        End If
    End Sub

    Public Sub FuncImprimir(ByVal FechaValidez As String)
        Try
            EstaImprimiendo = 1
            'se verifica el tipo de impresion para el tipo de comprobante actuamente seleccionado y de acuerdo a eso realizamos la impresion correspondiente
            'en caso de que este marcado la opcion de imprimir en la ventana "Rango de Comprobantes" 
            ValorFiscal = w.FuncionConsulta("VALORFISCAL", "TIPOCOMPROBANTE INNER JOIN DETPC ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "ACTIVO=1 AND RANDOID", cbxRangoId.SelectedValue)
            If TipoImpresion = 0 Then   'Formato Ticket
                If Imprimir = 1 Then 'Se imprime
                    If ValorFiscal = 0 Then 'Ticket¡
                        ImprimirTicket(FechaValidez)
                    ElseIf ValorFiscal = 1 Then 'Factura
                        ImprimirFactura(FechaValidez)
                    End If
                End If

            ElseIf TipoImpresion = 1 Then 'Formato Impresora
                If Imprimir = 1 Then 'Se imprime
                    ImprimirReporte()
                End If

            End If

            PanelRangoVisible = 0
            EstaImprimiendo = 0

        Catch ex As Exception
            MessageBox.Show("Error al Imprimir : " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EstaImprimiendo = 0
        End Try

    End Sub

    Private Sub InsertarFacturaCobrar()
        Try
            sql = ""
            sql = "INSERT INTO FACTURACOBRAR (CODNUMEROCUOTA,CODVENTA,FECHAVCTO,SALDOCUOTA,IMPORTECUOTA,FECGRA,PAGADO,TIPOFACTURA,IDCLIENTE) " & _
            "VALUES ( 1 ," & _
            "" & CDec(CodVentaTextBox.Text) & ",GETDATE(),0," & CDec(lblVentaTotal.Text) & " ,GETDATE(),1,'CONTADO', " & CodClienteTextBox.Text & ") "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error Insertar Forma Cobro" & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HabilitaCliente()

        btnClienteNuevo.Enabled = False
        btnGuardarCliente.Enabled = True
        btnModificarCliente.Visible = False
        btnCancelarCliente.Visible = True

        dgvClientes.Enabled = False
        BuscarClientesTextBox.Enabled = False

        'Habilitar el Formulario
        NombreClienteTextBox.Enabled = True
        RUCClienteTextBox.Enabled = True
        DireccionClienteTextBox.Enabled = True
        TelefonoClienteTextBox.Enabled = True
        RadComboBoxTipoCliente.Enabled = True
    End Sub

    Private Sub ImprimirAutofactura()
        Dim f As New Funciones.Funciones
        'Crear el objeto informe
        Dim informe = New Reportes.FacturaVenta1()

        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        informe.SetDataSource(InfFactura())
        informe.PrintOptions.PaperSource = PaperSource.Upper  'bandeja
        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de Impresora Invalida: " + ex.Message, "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        informe.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub ImprimirReporte()
        Dim f As New Funciones.Funciones
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.Factura

        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes

        If Config4 = "Papel Continuo" Then
            informe.PrintOptions.PaperSize = GetPapersizeID(impresora, "FacturaCogent")
        Else
            informe.PrintOptions.PaperSource = PaperSource.Upper 'bandeja
        End If

        informe.SetDataSource(InfFactura())

        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de Impresora Invalida: " + ex.Message, "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        informe.PrintToPrinter(1, False, 0, 0)
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

    Private Sub ImprimirFactura(ByVal FechaValidez As String)
        Dim ticket As New BarControlsCompleto.Ticket
        Dim TotalItems5, TotalItems10, Subtotallinea, TotalItemsExento As Decimal
        Dim Total5, Total10 As Integer
        TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0 : Total5 = 0 : Total10 = 0
        '#########################################################################################################################

        Dim Codigo, DescripcionProducto, Cantidad, Precio, Cliente, SubTotal As String
        Dim Empresa, RucEmpresa, Sucursal, DirSuc, CiudadSuc, TelSuc, NomContribuyente As String

        Codigo = "" : DescripcionProducto = "" : Cantidad = "" : Precio = "" : Subtotallinea = 0 : SubTotal = ""
        Empresa = "" : RucEmpresa = "" : Sucursal = "" : DirSuc = "" : CiudadSuc = "" : TelSuc = "" : Cliente = "" : NomContribuyente = ""

        '###################Traer Datos de Sucursal,Empresa y Cliente##############################################################################
        Try
            RucEmpresa = w.FuncionConsultaString2("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)
            NomContribuyente = w.FuncionConsultaString2("NOMCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)

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

        Catch ex As Exception
            cmd.Connection.Close()
        Finally

        End Try

        Cliente = RTrim(NombreClienteTextBox.Text)

        '################Cuerpo del Ticket ########################
        Try
            Empresa = UCase(RecortaCaracteres(EmpNomFantasia))
            NomContribuyente = "De " + NomContribuyente
            NomContribuyente = RecortaCaracteres(NomContribuyente)
            Sucursal = RecortaCaracteres(SucDescripcion)
            DirSuc = DirSuc + "-" + CiudadSuc
            RucEmpresa = RecortaCaracteres("RUC:" + RucEmpresa)
            TelSuc = RecortaCaracteres("TEL:" + TelSuc)
        Catch ex As Exception

        End Try

        ticket.AddHeaderLine(Empresa)
        ticket.AddHeaderLine(NomContribuyente)
        ticket.AddHeaderLine(Sucursal)
        ticket.AddHeaderLine(DirSuc)
        ticket.AddHeaderLine(RucEmpresa)
        ticket.AddHeaderLine(TelSuc)

        Dim CajeroDesc As String

        CajeroDesc = UsuNombre
        CajeroDesc = RecortaCaracteres2(CajeroDesc)
        ticket.AddSubHeaderLine("FECHA/HORA:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
        ticket.AddSubHeaderLine("CAJA Nº:" + NumCaja.ToString + "  " + "CAJERO:" + CajeroDesc)

        For i = 1 To DetalleVentaTGridView.RowCount()
            DescripcionProducto = DetalleVentaTGridView.Rows(i - 1).Cells("ProductoDGVT").Value
            '   DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)

            Codigo = DetalleVentaTGridView.Rows(i - 1).Cells("CodigoBarraDGVT").Value
            If Codigo.Count <= 5 Then
            Else
                Codigo = Codigo.Remove(0, Codigo.Count - 5)
            End If

            Cantidad = DetalleVentaTGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
            Precio = DetalleVentaTGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
            SubTotal = CDec(DetalleVentaTGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) * CDec(DetalleVentaTGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value)

            Dim IVA As Decimal
            Dim IvaDescrip As String = ""

            If i > DetalleVentaTGridView.RowCount() Then
            Else
                IvaDescrip = DetalleVentaTGridView.Rows(i - 1).Cells("IVA").Value
                IvaDescrip = Trim(Replace(IvaDescrip, "%", ""))
                IVA = CDec(IvaDescrip)

                If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value) Then
                Else
                    Total5 = Total5 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value / 21)
                    TotalItems5 = TotalItems5 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value)
                    Subtotallinea = Subtotallinea + CDec(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value)
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value) Then
                Else
                    Total10 = Total10 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value / 11)
                    TotalItems10 = TotalItems10 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value)
                    Subtotallinea = Subtotallinea + CDec(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value)
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value) Then
                Else
                    TotalItemsExento = TotalItemsExento + DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value
                    Subtotallinea = Subtotallinea + CDec(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value)
                End If
            End If

            Precio = Replace(Precio, ".", "")
            Precio = FormatNumber(Precio, 0)

            SubTotal = Replace(SubTotal, ".", "")
            SubTotal = FormatNumber(SubTotal, 0)

            ' Subtotallinea = Replace(Subtotallinea, ".", "")
            'Dim SubTotString As String = FormatNumber(Subtotallinea, 0)

            'ticket.AddItem(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(4), "", Precio.PadLeft(6) & " " & SubTotString.PadLeft(6))
            DescripcionProducto = RecortaCaracteresProductos(DescripcionProducto)
            ticket.AddItem(DescripcionProducto.PadLeft(8), "", "")
            ticket.AddItem(Cantidad.PadLeft(12), "", Precio.PadLeft(4) & " " & SubTotal.PadLeft(6))
        Next

        ticket.AddTotal("       TOTAL VENTA :", FormatNumber(lblVentaTotal.Text, 0))
        ticket.AddTotal("       RECIBIDO Gs.:", FormatNumber(PagoLabel.Text, 0))
        ticket.AddTotal("       VUELTO   Gs.:", FormatNumber(VueltoLabel.Text, 0))
        ticket.AddTotal("", "")

        Total10 = Replace(Total10, ".", ",")
        Total5 = Replace(Total5, ".", ",")
        TotalItemsExento = Replace(TotalItemsExento, ".", ",")

        ticket.AddTotal("TOTAL GRAVADA 10% Gs.:", TotalItems10.ToString)
        ticket.AddTotal("TOTAL GRAVADA 5%  Gs.:", TotalItems5.ToString)
        ticket.AddTotal("TOTAL EXENTAS     GS.:", TotalItemsExento)
        ticket.AddTotal("LIQUIDACION DEL IVA", "")
        ticket.AddTotal("IVA 10% Gs.:", Total10)
        ticket.AddTotal("IVA 5%  Gs.:", Total5)
        ticket.AddTotal("===============================", "=")

        ticket.AddFooterLine("FAC. CONTADO" + " Nº" + NroFacturaLabel.Text)
        ticket.AddFooterLine("TIMBRADO:" + TimbradoFactura)
        ticket.AddFooterLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        ticket.AddFooterLine("I.V.A Incluido")
        ticket.AddFooterLine("================================")

        ticket.AddFooterLine("CANTIDAD DE ARTICULOS:" + DetalleVentaTGridView.RowCount.ToString)
        ticket.AddFooterLine("RUC CLIENTE:" + RUCClienteTextBox.Text)
        ticket.AddFooterLine("CLIENTE:" + Cliente)
        ticket.AddFooterLine("")

        ticket.AddFooterLine("*****GRACIAS POR SU COMPRA******")

        Try
            ticket.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Problema al Imprimir Ticket Fiscal : " & ex.Message, "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ImprimirAutoFactura(ByVal FechaValidez As String)
        'ds.Clear()
        Dim ticket As New BarControls.Ticket
        Dim TotalItems5, TotalItems10, Subtotallinea, TotalItemsExento As Decimal
        Dim Total5, Total10 As Integer
        TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0 : Total5 = 0 : Total10 = 0
        '#########################################################################################################################

        Dim Codigo, DescripcionProducto, Cantidad, Precio, Cliente As String
        Dim Empresa, RucEmpresa, Sucursal, DirSuc, CiudadSuc, TelSuc As String

        Codigo = "" : DescripcionProducto = "" : Cantidad = "" : Precio = "" : Subtotallinea = 0
        Empresa = "" : RucEmpresa = "" : Sucursal = "" : DirSuc = "" : CiudadSuc = "" : TelSuc = ""
        Cliente = ""

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
            Cliente = RTrim(NombreClienteTextBox.Text)

        Catch ex As Exception

        End Try
        '################Cuerpo del Ticket ########################

        '##########################################################
        'recorta caracteres para centrar

        Try
            Empresa = UCase(RecortaCaracteres(EmpNomFantasia))
            Sucursal = RecortaCaracteres(SucDescripcion)
            DirSuc = DirSuc + "-" + CiudadSuc 'RecortaCaracteres3(DirSuc + "-" + CiudadSuc)
            RucEmpresa = RecortaCaracteres("RUC:" + RucEmpresa)
            TelSuc = RecortaCaracteres("TEL:" + TelSuc)
        Catch ex As Exception

        End Try

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

        ticket.AddHeaderLine("AUTOFACTURA" + " Nº" + NroFacturaLabel.Text)
        ticket.AddHeaderLine("TIMBRADO:" + TimbradoFactura)
        ticket.AddHeaderLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        ticket.AddHeaderLine("I.V.A Incluido")
        '##########################################################
        ticket.AddSubHeaderLine("FECHA/HORA:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
        ticket.AddSubHeaderLine("CAJA Nº:" + NumCaja.ToString + "  " + "CAJERO:" + CajeroDesc)
        '##########################################################

        Dim c As Integer = DetalleVentaTGridView.RowCount()
        For i = 1 To c
            'Ceramos el SubTotalLinea para no sumar
            Subtotallinea = 0

            DescripcionProducto = DetalleVentaTGridView.Rows(i - 1).Cells("ProductoDGVT").Value
            If DescripcionProducto.Count <= 8 Then
            Else
                DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)
            End If

            Codigo = DetalleVentaTGridView.Rows(i - 1).Cells("CodigoBarraDGVT").Value
            If Codigo.Count <= 5 Then
            Else
                Codigo = Codigo.Remove(0, Codigo.Count - 5)
            End If

            Cantidad = DetalleVentaTGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
            Precio = DetalleVentaTGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value

            Dim IVA As Decimal
            Dim IvaDescrip As String = ""
            If i > c Then

            Else
                IvaDescrip = DetalleVentaTGridView.Rows(i - 1).Cells("IVA").Value
                IvaDescrip = Trim(Replace(IvaDescrip, "%", ""))
                IVA = CDec(IvaDescrip)

                If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value) Then
                Else
                    Total5 = Total5 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value / 21)
                    TotalItems5 = TotalItems5 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value)
                    Subtotallinea = Subtotallinea + CDec(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADOCINCO").Value)
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value) Then
                Else
                    Total10 = Total10 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value / 11)
                    TotalItems10 = TotalItems10 + (DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value)
                    Subtotallinea = Subtotallinea + CDec(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEGRABADODIEZ").Value)
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value) Then
                Else
                    TotalItemsExento = TotalItemsExento + DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value
                    Subtotallinea = Subtotallinea + CDec(DetalleVentaTGridView.Rows(i - 1).Cells("IMPORTEEXENTO").Value)
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
        ticket.AddTotal(" TOTAL AUTOFACTURA :", FormatNumber(lblVentaTotal.Text, 0))
        ticket.AddTotal("       RECIBIDO Gs.:", FormatNumber(PagoLabel.Text, 0))
        ticket.AddTotal("       VUELTO   Gs.:", FormatNumber(VueltoLabel.Text, 0))
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

        ticket.AddFooterLine("RUC CLIENTE:" + RUCClienteTextBox.Text)
        ticket.AddFooterLine("CLIENTE:" + Cliente)
        ticket.AddFooterLine("")
        ticket.AddFooterLine("================================")
        ticket.AddFooterLine("")
        ticket.AddFooterLine("*****GRACIAS POR SU COMPRA******")

        Try
            ticket.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Problema al Imprimir Autofactura: ", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ImprimirTicket(ByVal FechaValidez As String)
        Dim ticket As New BarControlsCompleto.Ticket

        '#########################################################################################################################
        Dim Codigo, DescripcionProducto, Cantidad, Precio, Subtotallinea, Cliente, NomContribuyente As String
        Dim Empresa, RucEmpresa, Sucursal, DirSuc, CiudadSuc, TelSuc As String

        Codigo = "" : DescripcionProducto = "" : Cantidad = "" : Precio = "" : Subtotallinea = ""
        Empresa = "" : RucEmpresa = "" : Sucursal = "" : DirSuc = "" : CiudadSuc = "" : TelSuc = "" : Cliente = "" : NomContribuyente = ""

        '###################Traer Datos de Sucursal,Empresa y Cliente##############################################################################
        Try
            RucEmpresa = w.FuncionConsultaString2("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)
            NomContribuyente = w.FuncionConsultaString2("NOMCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)

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

            Cliente = RTrim(NombreClienteTextBox.Text)
        Catch ex As Exception

        End Try
        '################Cuerpo del Ticket ########################
        Dim CajeroDesc As String = ""

        Try
            CajeroDesc = UsuNombre
            CajeroDesc = RecortaCaracteres2(CajeroDesc)

            Empresa = UCase(RecortaCaracteres(EmpNomFantasia))
            NomContribuyente = "De " + NomContribuyente
            NomContribuyente = RecortaCaracteres(NomContribuyente)
            Sucursal = RecortaCaracteres(SucDescripcion)
            DirSuc = DirSuc + "-" + CiudadSuc
            RucEmpresa = RecortaCaracteres("RUC:" + RucEmpresa)
            TelSuc = RecortaCaracteres("TEL:" + TelSuc)
        Catch ex As Exception

        End Try

        ticket.AddHeaderLine(Empresa)
        ticket.AddHeaderLine(Sucursal)
        ticket.AddHeaderLine(DirSuc)
        ticket.AddHeaderLine(RucEmpresa)
        ticket.AddHeaderLine(TelSuc)

        ticket.AddSubHeaderLine("FECHA/HORA:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
        ticket.AddSubHeaderLine("CAJA Nº:" + NumeroCaja + "  " + "CAJERO:" + CajeroDesc)


        Dim c As Integer = DetalleVentaTGridView.RowCount()
        For i = 1 To c
            DescripcionProducto = DetalleVentaTGridView.Rows(i - 1).Cells("ProductoDGVT").Value
            '   DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)

            Codigo = DetalleVentaTGridView.Rows(i - 1).Cells("CodigoBarraDGVT").Value
            If Codigo.Count <= 5 Then
            Else
                Codigo = Codigo.Remove(0, Codigo.Count - 5)
            End If

            Cantidad = DetalleVentaTGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
            Precio = DetalleVentaTGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value

            Dim IVA As Decimal
            Dim IvaDescrip As String = ""

            If i > c Then
            Else
                IvaDescrip = DetalleVentaTGridView.Rows(i - 1).Cells("IVA").Value
                IvaDescrip = Trim(Replace(IvaDescrip, "%", ""))
                IVA = CDec(IvaDescrip)
                Subtotallinea = CDec(DetalleVentaTGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) * CDec(DetalleVentaTGridView.Rows(i - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value)
            End If

            Precio = Replace(Precio, ".", "")
            Precio = FormatNumber(Precio, 0)
            Subtotallinea = Replace(Subtotallinea, ".", "")
            Subtotallinea = FormatNumber(Subtotallinea, 0)

            'ticket.AddItem(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(4), "", Precio.PadLeft(6) & " " & Subtotallinea.PadLeft(6))
            DescripcionProducto = RecortaCaracteresProductos(DescripcionProducto)
            ticket.AddItem(DescripcionProducto.PadLeft(8), "", "")
            ticket.AddItem(Cantidad.PadLeft(10), "", Precio.PadLeft(6) & " " & Subtotallinea.PadLeft(6))
        Next

        ticket.AddTotal("       TOTAL VENTA :", FormatNumber(lblVentaTotal.Text, 0))
        ticket.AddTotal("       RECIBIDO Gs.:", FormatNumber(PagoLabel.Text, 0))
        ticket.AddTotal("       VUELTO   Gs.:", FormatNumber(VueltoLabel.Text, 0))
        ticket.AddTotal("", "")

        ticket.AddFooterLine("TICKET Nº" + NroFacturaLabel.Text)
        ticket.AddFooterLine("TIMBRADO:" + TimbradoFactura)
        ticket.AddFooterLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        ticket.AddFooterLine("================================")

        ticket.AddFooterLine("CANTIDAD DE ARTICULOS:" + c.ToString)
        ticket.AddFooterLine("RUC CLIENTE:" + RUCClienteTextBox.Text)
        ticket.AddFooterLine("CLIENTE:" + Cliente)
        ticket.AddFooterLine("")
        ticket.AddFooterLine("****Ticket sin Validez Fiscal***")
        ticket.AddFooterLine("*****GRACIAS POR SU COMPRA******")

        Try
            ticket.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub InsertaCliente()
        Dim Maximo As Long

        Maximo = f.Maximo("NUMCLIENTE", "CLIENTES")
        Maximo = Maximo + 1



        sql = ""
        sql = "INSERT INTO CLIENTES (CODUSUARIO, CODEMPRESA, NUMCLIENTE,NOMBRE, RUC, DIRECCION, TELEFONO,FECGRA,CODTIPOCLIENTE,AUTORIZADO,TIPORELACION) " & _
        "Values (" & UsuCodigo & "," & EmpCodigo & ", " & Maximo & ",'" & NombreClienteTextBox.Text & "','" & RUCClienteTextBox.Text & "', " & _
        "'" & DireccionClienteTextBox.Text & "', '" & TelefonoClienteTextBox.Text & "', CONVERT(DATETIME, '" & Today & "', 103)," & RadComboBoxTipoCliente.SelectedValue & ",1,1)"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaClienteAuditoria()
        Dim w As New Funciones.Funciones
        Dim CodAutitoria As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) values (" & CodAutitoria & ", " & EmpCodigo & ", 'CLIENTES', '" & CodAutitoria & "', 'INSERCION EN LA TABLA CLIENTES', CONVERT(DATETIME, '" & Today & "', 103), '" & UsuDescripcion & "', '" & UsuNivel & "', 1, 0, 0)"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaDetalleVenta()
        Try
            Dim CodVenta, CodSucursal, PrecioVentaNeto, PrecioVentaBruto, PrecioVentaLista, CantidadVenta, Iva, CodProductoVenta, _
            CodCodigoVenta, SumaIva, importe10, IvaVenta, CostoFifo, importe5, importeexento As String
            Dim Promocion As Integer = 0
            IvaVenta = 0 : SumaIva = 0
            Dim c As Integer = DetalleVentaTGridView.RowCount

            For c = 1 To c
                CodVenta = CodVentaTextBox.Text

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) Then
                    CodProductoVenta = "NULL"
                Else
                    CodProductoVenta = DetalleVentaTGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                    'DetalleVentaTGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                    CodCodigoVenta = "NULL"
                Else
                    CodCodigoVenta = DetalleVentaTGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                    CantidadVenta = "NULL"
                Else
                    CantidadVenta = DetalleVentaTGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                    CantidadVenta = Funciones.Cadenas.QuitarCad(CantidadVenta, ".")
                    CantidadVenta = Replace(CantidadVenta, ",", ".")
                End If
                Try
                    If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value) Then
                        PrecioVentaBruto = "0"
                    Else
                        PrecioVentaBruto = DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTABRUTODataGridViewTextBoxColumn").Value
                    End If
                Catch ex As Exception
                    PrecioVentaBruto = "0"
                End Try

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value) Then
                    PrecioVentaNeto = "NULL"
                Else
                    PrecioVentaNeto = DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTANETODataGridViewTextBoxColumn").Value
                End If

                Try
                    If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("COSTOPROMEDIO").Value) Then
                        CostoFifo = "1"
                    Else
                        CostoFifo = DetalleVentaTGridView.Rows(c - 1).Cells("COSTOPROMEDIO").Value
                    End If
                Catch ex As Exception
                    CostoFifo = "1"
                End Try

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("PRODPROMOCION").Value) Then
                Else
                    If DetalleVentaTGridView.Rows(c - 1).Cells("PRODPROMOCION").Value = True Then
                        Promocion = 1
                    Else
                        Promocion = 0
                    End If
                End If

                'SACAMOS EL IVA, PRECIOBRUTO - PRECIONETO
                Try
                    IvaVenta = CDec(PrecioVentaBruto) - CDec(PrecioVentaNeto)
                    SumaIva = CDec(SumaIva) + CDec(IvaVenta)

                Catch ex As Exception
                    IvaVenta = 0
                End Try

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value) Then
                    PrecioVentaLista = "NULL"
                Else
                    PrecioVentaLista = DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                    PrecioVentaLista = Funciones.Cadenas.QuitarCad(PrecioVentaLista, ".")
                    PrecioVentaLista = Replace(PrecioVentaLista, ",", ".")
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("IVA").Value) Then
                    Iva = "NULL"
                Else
                    Iva = DetalleVentaTGridView.Rows(c - 1).Cells("IVA").Value
                    Iva = Replace(Iva, "%", "")
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn").Value) Then
                    CodSucursal = "NULL"
                Else
                    CodSucursal = DetalleVentaTGridView.Rows(c - 1).Cells("CODSUCURSALDataGridViewTextBoxColumn").Value
                End If

                IvaVenta = CDec(PrecioVentaBruto - PrecioVentaNeto)
                importeexento = "0"
                importe5 = "0"
                importe10 = "0"

                If Iva = "10" Then
                    importe10 = CDec(PrecioVentaBruto)
                    importe5 = "0"
                    importeexento = "0"
                ElseIf Iva = "5" Then
                    importe5 = CDec(PrecioVentaBruto)
                    importe10 = "0"
                    importeexento = "0"
                ElseIf Iva = "0" Then
                    importeexento = CDec(PrecioVentaBruto)
                    importe5 = "0"
                    importe10 = "0"
                End If

                'replaces#################################################
                CostoFifo = Funciones.Cadenas.QuitarCad(CostoFifo, ".")
                CostoFifo = Replace(CostoFifo, ",", ".")
                PrecioVentaNeto = Funciones.Cadenas.QuitarCad(PrecioVentaNeto, ".")
                PrecioVentaNeto = Replace(PrecioVentaNeto, ",", ".")
                PrecioVentaBruto = Funciones.Cadenas.QuitarCad(PrecioVentaBruto, ".")
                PrecioVentaBruto = Replace(PrecioVentaBruto, ",", ".")
                importeexento = Funciones.Cadenas.QuitarCad(importeexento, ".")
                importeexento = Replace(importeexento, ",", ".")
                importe5 = Funciones.Cadenas.QuitarCad(importe5, ".")
                importe5 = Replace(importe5, ",", ".")
                importe10 = Funciones.Cadenas.QuitarCad(importe10, ".")
                importe10 = Replace(importe10, ",", ".")

                sql = ""
                sql = "INSERT INTO VENTASDETALLE (CODPRODUCTO, CODCODIGO, CODVENTA, CANTIDADVENTA, PRECIOVENTABRUTO, PRECIOVENTANETO, PRECIOVENTALISTA, " & _
                      "IVA, CODSUCURSAL,IMPORTEGRABADODIEZ,IMPORTEGRABADOCINCO,IMPORTEEXENTO,COSTOPROMEDIO,PRODPROMOCION, CODMONEDA) VALUES " & _
                      "(" & CodProductoVenta & ", " & CodCodigoVenta & "," & CodVenta & "," & CantidadVenta & "," & _
                      "" & PrecioVentaBruto & "," & PrecioVentaNeto & ", " & PrecioVentaLista & "," & Iva & "," & CodSucursal & ", " & _
                      "" & importe10 & "," & importe5 & "," & importeexento & "," & CostoFifo & ", " & Promocion & ",1) "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            MessageBox.Show("Error al Insertar la Venta Detalle: " & ex.Message & "  " & sql, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertaFormaCobro()
        Try
            Dim CodMoneda, CodTipoCobro, DestipoCobro, Cotizacion1, Importe, FechaCobro, CH_NroCheque, CH_TA_TR_CodBanco, TA_CodTipoTarjeta As String

            Dim c As Integer = CobroEfectivoTGridView.RowCount
            For c = 1 To c
                'CodCobro = CobroEfectivoTGridView.Rows(c - 1).Cells("CODCOBRODataGridViewTextBoxColumn").Value
                ' CodVenta = CobroEfectivoTGridView.Rows(c - 1).Cells("CODVENTADataGridViewTextBoxColumn1").Value

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("CODTIPOCOBRODataGridViewTextBoxColumn").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("CODTIPOCOBRODataGridViewTextBoxColumn").Value Is Nothing Then
                    CodTipoCobro = "NULL"
                Else
                    CodTipoCobro = CobroEfectivoTGridView.Rows(c - 1).Cells("CODTIPOCOBRODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value Is Nothing Then
                    CodMoneda = "NULL"
                Else
                    CodMoneda = CobroEfectivoTGridView.Rows(c - 1).Cells("CODMONEDADataGridViewTextBoxColumn1").Value
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("Cotizacion1DataGridViewTextBoxColumn").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("Cotizacion1DataGridViewTextBoxColumn").Value Is Nothing Then
                    Cotizacion1 = "0.00"
                Else
                    Cotizacion1 = CobroEfectivoTGridView.Rows(c - 1).Cells("Cotizacion1DataGridViewTextBoxColumn").Value
                    Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")

                    Cotizacion1 = Replace(Cotizacion1, ",", ".")
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value Is Nothing Then
                    Importe = "0.00"
                Else
                    Importe = CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value
                    Dim coti As Integer
                    coti = CobroEfectivoTGridView.Rows(c - 1).Cells("Cotizacion1DataGridViewTextBoxColumn").Value
                    Importe = Importe * coti

                    Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
                    Importe = Replace(Importe, ",", ".")
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("DESTIPOCOBRODataGridViewTextBoxColumn").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("DESTIPOCOBRODataGridViewTextBoxColumn").Value Is Nothing Then
                    DestipoCobro = ""
                Else
                    DestipoCobro = CobroEfectivoTGridView.Rows(c - 1).Cells("DESTIPOCOBRODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("FECHACOBRODataGridViewTextBoxColumn").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("FECHACOBRODataGridViewTextBoxColumn").Value Is Nothing Then
                    FechaCobro = ""
                Else
                    FechaCobro = CobroEfectivoTGridView.Rows(c - 1).Cells("FECHACOBRODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("CHNROCHEQUEDataGridViewTextBoxColumn").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("CHNROCHEQUEDataGridViewTextBoxColumn").Value Is Nothing Then
                    CH_NroCheque = "NULL"
                Else
                    CH_NroCheque = CobroEfectivoTGridView.Rows(c - 1).Cells("CHNROCHEQUEDataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("CHTATRCODBANCODataGridViewTextBoxColumn").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("CHTATRCODBANCODataGridViewTextBoxColumn").Value Is Nothing Then
                    CH_TA_TR_CodBanco = "NULL"
                Else
                    CH_TA_TR_CodBanco = CobroEfectivoTGridView.Rows(c - 1).Cells("CHTATRCODBANCODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("TACODTIPOTARJETADataGridViewTextBoxColumn").Value) Or CobroEfectivoTGridView.Rows(c - 1).Cells("TACODTIPOTARJETADataGridViewTextBoxColumn").Value Is Nothing Then
                    TA_CodTipoTarjeta = "NULL"
                Else
                    TA_CodTipoTarjeta = CobroEfectivoTGridView.Rows(c - 1).Cells("TACODTIPOTARJETADataGridViewTextBoxColumn").Value
                End If

                sql = ""
                'sql = "DECLARE @CODCOBRO AS INT SELECT @CODCOBRO= ISNULL(MAX(CODCOBRO),0) + 1 FROM VENTASFORMACOBRO " & _
                sql = " INSERT INTO VENTASFORMACOBRO (CODVENTA, CODTIPOCOBRO,CODMONEDA, COTIZACION1, IMPORTE, DESTIPOCOBRO, FECHACOBRO, " & _
                 "id_apertura,vuelto, NROCUOTA, TIPOCOBRO ,CABCOBRO, AUTORIZADO,CH_TA_TR_CODBANCO,TA_CODTIPOTARJETA,CH_NROCHEQUE,FECHAREGISTROCOB,CODCLIENTECAB,NRORECIBO, CODUSUARIO)  " & _
                 "VALUES (" & CodVentaTextBox.Text & ", " & CodTipoCobro & ",   " & CodMoneda & ", " & Cotizacion1 & ", " & Importe & ", '" & DestipoCobro & "', getdate()," & _
                  MaxIdApertura & ",0, 1, 1 , " & CabPagoMax & ", " & UsuCodigo & "," & CH_TA_TR_CodBanco & "," & TA_CodTipoTarjeta & "," & CH_NroCheque & ", GETDATE()," & dgvClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value & ", ''," & UsuCodigo & ")"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            MessageBox.Show("Error Insertar Forma Cobro" & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertaVuelto()
        Try
            Dim vuelto As String
            vuelto = CDec(DebeLabel.Text) - CDec(PagoLabel.Text)
            vuelto = Funciones.Cadenas.QuitarCad(vuelto, ".")
            vuelto = Replace(vuelto, ",", ".")

            'Insertamos en la Tabla VentasFormaCobro
            sql = "DECLARE @CODCOBRO AS INT SELECT @CODCOBRO= ISNULL(MAX(CODCOBRO),0) + 1 FROM VENTASFORMACOBRO " & _
                  "INSERT into VENTASFORMACOBRO (CODVENTA, CODTIPOCOBRO, CODMONEDA, COTIZACION1, IMPORTE, DESTIPOCOBRO, FECHACOBRO, " & _
                  "id_apertura,vuelto, NROCUOTA,TIPOCOBRO , CABCOBRO, AUTORIZADO, FECHAREGISTROCOB, CODCLIENTECAB,NRORECIBO, CODUSUARIO) " & _
                  "VALUES (" & CodVentaTextBox.Text & ", 1 , 1 , 1.00, " & vuelto & " , 'Efectivo', getdate()," & MaxIdApertura & " , 1 , 1 , 1 , " & _
                  CabPagoMax & ", " & UsuCodigo & ", GETDATE()," & dgvClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value & ", ''," & UsuCodigo & ")"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error Insertar Vuelto: " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertaMovimientoProducto(ByRef TipoOperacion As Integer)
        Try
            Dim CantidadFactura, CodCodigoFactura, CodProductoFactura As String

            Dim DescMovomiento, TipoMovimiento As String
            DescMovomiento = "" : TipoMovimiento = ""

            If TipoOperacion = 1 Then
                DescMovomiento = "SALIDA POR VENTA"
                TipoMovimiento = "SALIDA"
            ElseIf TipoOperacion = 2 Then
                DescMovomiento = "ENTRADA POR ANULACION DE VENTA"
                TipoMovimiento = "ENTRADA"
            End If

            Dim c As Integer = DetalleVentaTGridView.RowCount
            For c = 1 To c
                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                    CantidadFactura = "NULL"
                Else
                    CantidadFactura = DetalleVentaTGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                    CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                    CantidadFactura = Replace(CantidadFactura, ",", ".")
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) Then
                    CodProductoFactura = "NULL"
                Else
                    CodProductoFactura = DetalleVentaTGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                    CodCodigoFactura = "NULL"
                Else
                    CodCodigoFactura = DetalleVentaTGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                End If

                sql = ""
                sql = "INSERT INTO MOVIMIENTOPRODUCTO (CODPRODUCTO,CODCODIGO,CONCEPTO, TIPOMOVIMIENTO,CANTIDAD,FECHAMTO," & _
                "NUMCOMPROVANTE,CODSUCURSAL) VALUES (" & CodProductoFactura & "," & CodCodigoFactura & ",'" & DescMovomiento & "', '" & TipoMovimiento & "' ," & _
                CantidadFactura & ", GETDATE() ,'" & NroFacturaLabel.Text & "'," & SucCodigo & ")"
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MessageBox.Show("Error al Insertar el Movimiento: " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertaVenta(ByVal Excento As Decimal, ByVal TotalGrav As Decimal, ByVal Grav10 As Decimal, ByVal Grav5 As Decimal, _
                             ByVal nIVA5 As Decimal, ByVal nIVA10 As Decimal, ByVal TotIva As Decimal)
        Try
            Dim Direc As String
            Dim Cliente As String = NombreClienteTextBox.Text

            If DireccionClienteTextBox.Text = "" Then
                Direc = "NULL"
            Else
                Direc = "'" & DireccionClienteTextBox.Text & "'"
            End If

            If VendendorComboBox.SelectedValue = Nothing Then
                CodVendedor = "NULL"
            Else
                CodVendedor = VendendorComboBox.SelectedValue
            End If

            Dim vnIva10 As String = FormatNumber(CDec(nIVA10), 2)
            vnIva10 = Funciones.Cadenas.QuitarCad(vnIva10, ".")
            Dim vnIva5 As String = FormatNumber(CDec(nIVA5), 2)
            vnIva5 = Funciones.Cadenas.QuitarCad(vnIva5, ".")
            Dim vnTIva As String = FormatNumber(CDec(TotIva), 2)
            vnTIva = Funciones.Cadenas.QuitarCad(vnTIva, ".")

            sql = ""
            sql = "INSERT VENTAS (CODMONEDA, CODCOMPROBANTE, CODCLIENTE, CODSUCURSAL , CODDEPOSITO, NUMVENTA,FECHAVENTA,TOTALEXENTA,TOTALGRAVADA,TOTALIVA,FECGRA,ESTADO,TIPOVENTA," & _
                  "NOMBRECLIENTE,RUCCLIENTE,DIRECCION,TOTAL5,TOTAL10,CODVENDEDOR,TOTALGRAVADO10,COTIZACION1,TOTALGRAVADO5,TOTALVENTA,NUMVENTATIMBRADO ,METODO,CODRANGO, CODUSUARIO,MODALIDADPAGO)   " & _
                  "VALUES(" & CODMONEDAPRINCIPAL & " ," & CodComprobante & ", " & CodClienteTextBox.Text & "," & SucCodigo & "," & SucCodigo & ", '" & NumVenta & "'," & _
                  "GETDATE()," & Replace(Excento, ",", ".") & ", " & Replace(TotalGrav, ",", ".") & "," & Replace(vnTIva, ",", ".") & ", GETDATE(), 1 , 0 , '" & Replace(Cliente, "'", "''") & "','" & RUCClienteTextBox.Text & "' ,'" & Replace(Direc, "'", "''") & "'," & _
                  Replace(vnIva5, ",", ".") & "," & Replace(vnIva10, ",", ".") & " , " & CodVendedor & ", " & Replace(Grav10, ",", ".") & ", 1," & Replace(Grav5, ",", ".") & ", " & Replace(TotalGrav, ",", ".") & " , " & TimbradoFactura & ", 'Simplificado', " & cbxRangoId.SelectedValue & "," & UsuCodigo & ",0)  " & _
                  "SELECT CODVENTA FROM VENTAS WHERE CODVENTA = SCOPE_IDENTITY();"

            cmd.CommandText = sql
            CodVenta = cmd.ExecuteScalar()
            CodVentaTextBox.Text = CodVenta

        Catch ex As Exception
            MessageBox.Show("Error al Insertar la Venta: " & ex.Message & " (T-SQL)  " & sql, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Limpiarcodigos()
        CodProductoTextBox.Text = "" : CodCodigoTextBox.Text = "" : lblEnStock.Text = ""
    End Sub

    Private Sub LimpiarControlesCobro()
        'Cheque
        NroChequeTextBox.Text = ""
        txtMontoCheque.Text = ""
        FechaCobroChequeTextBox.Text = Today
        'Efectivo
        MontoEfectivoMaskedEdit.Text = ""
        'Debito
        MontoDebitoMaskedEdit.Text = ""
        'txtnrotarjetadebito.Text = ""
        'Tarjeta
        MontoTarjetaMaskedEdit.Text = ""
        'txtnrotarjeta.Text = ""
    End Sub

    Private Sub ModificarClienteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarCliente.Click
        AccNuevo = 0 : AccEditar = 1
        HabilitaCliente()
        btnIniciarVenta.Enabled = False
    End Sub

    Private Sub MonedaEfectivoComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MonedaEfectivoComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
    End Sub

    Private Sub MontoChequeMaskedEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoCheque.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            FechaCobroChequeTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub MontoDebitoMaskedEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MontoDebitoMaskedEdit.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            AgregarDetDebitoButton.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub MontoEfectivoMaskedEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MontoEfectivoMaskedEdit.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            AgregarPagoEfectivoButton.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub MontoTarjetaMaskedEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MontoTarjetaMaskedEdit.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            AgregarDetTarjetaButton.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub NombreClienteTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NombreClienteTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            RUCClienteTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub PrecioVentaMaskedEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioVentaMaskedEdit.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            AgregarDetVentaButton.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub ProductosGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductosGridView.DoubleClick
        Dim f As New Funciones.Funciones
        Dim vServicio As Integer
        Try
            If ProductosGridView.RowCount = 0 Then
                BuscarProductoTextBox.Text = ""
                CodCodigoTextBox.Text = ""
                tbxCodigoProd.Focus()
                'UltraPopupControlContainer1.Close()
                ProductosGroupBox.Visible = False

            Else
                If IsDBNull(ProductosGridView.CurrentRow) Then
                    BuscarProductoTextBox.Text = ""
                    tbxCodigoProd.Focus()
                    'UltraPopupControlContainer1.Close()
                    ProductosGroupBox.Visible = False
                Else

                    If IsDBNull(ProductosGridView.CurrentRow.Cells("CODIGO").Value) And IsDBNull(ProductosGridView.CurrentRow.Cells("CODPRODUCTO").Value) And _
                    IsDBNull(ProductosGridView.CurrentRow.Cells("CODCODIGO").Value) And IsDBNull(ProductosGridView.CurrentRow.Cells("PRODUCTO").Value) And _
                    IsDBNull(ProductosGridView.CurrentRow.Cells("PRECIOVENTA").Value) Then

                        MessageBox.Show("El Producto Seleccionado no contiene todos los datos necesarios para la venta", "POSEXPRESS")

                    Else
                        'eligiocbo = 0
                        tbxCodigoProd.Text = ProductosGridView.CurrentRow.Cells("CODIGO").Value
                        CodProductoTextBox.Text = ProductosGridView.CurrentRow.Cells("CODPRODUCTO").Value
                        CodCodigoTextBox.Text = ProductosGridView.CurrentRow.Cells("CODCODIGO").Value

                        If IsDBNull(ProductosGridView.CurrentRow.Cells("DESCODIGO1DataGridViewTextBoxColumn").Value) Then
                            lblDescripcionProducto.Text = ProductosGridView.CurrentRow.Cells("PRODUCTO").Value
                        Else
                            lblDescripcionProducto.Text = ProductosGridView.CurrentRow.Cells("PRODUCTO").Value + " " + ProductosGridView.CurrentRow.Cells("DESCODIGO1DataGridViewTextBoxColumn").Value
                        End If
                        PrecioVentaMaskedEdit.Text = ProductosGridView.CurrentRow.Cells("PRECIOVENTA").Value
                        Me.tbxCoheficiente.Text = FormatNumber(ProductosGridView.CurrentRow.Cells("COHEFICIENTE").Value, 2)

                        'Si es Servicio VServicio = 1 (al contrario es 0)
                        vServicio = ProductosGridView.CurrentRow.Cells("SERVICIODGVT").Value
                        If vServicio = 0 Then
                            lblEnStock.Text = ProductosGridView.CurrentRow.Cells("STOCKACTUALDataGridViewTextBoxColumn").Value
                        Else
                            lblEnStock.Text = "Servicio"
                        End If

                        If IsDBNull(ProductosGridView.CurrentRow.Cells("PROMOCION").Value) Then
                            vProdPromocion = 0
                        Else
                            If ProductosGridView.CurrentRow.Cells("PROMOCION").Value = True Then
                                vProdPromocion = 1
                            Else
                                vProdPromocion = 0
                            End If
                        End If

                        If IsDBNull(ProductosGridView.CurrentRow.Cells("PRODCOSTO").Value) Then
                            vProdCosto = 1
                        Else
                            vProdCosto = ProductosGridView.CurrentRow.Cells("PRODCOSTO").Value
                        End If
                    End If

                    BuscarProductoTextBox.Text = ""
                    tbxCantidadVent.Focus()
                    ProductosGroupBox.Visible = False

                    CheckBox1.BackColor = Color.Transparent
                    If VerOtrosPrecios = 0 Then
                        CheckBox1.Enabled = False
                    Else
                        CheckBox1.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProductosGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ProductosGridView.KeyDown
        Dim f As New Funciones.Funciones
        Dim vServicio As Integer

        Try

            If e.KeyCode = Keys.Enter Then

                If ProductosGridView.RowCount = 0 Then
                    BuscarProductoTextBox.Text = ""
                    CodCodigoTextBox.Text = ""
                    tbxCodigoProd.Focus()
                    'UltraPopupControlContainer1.Close()
                    ProductosGroupBox.Visible = False
                Else

                    If IsDBNull(ProductosGridView.CurrentRow) Then
                        BuscarProductoTextBox.Text = ""
                        tbxCodigoProd.Focus()
                        'UltraPopupControlContainer1.Close()
                        ProductosGroupBox.Visible = False
                    Else
                        Dim i As Integer = ProductosGridView.CurrentRow.Index
                        'Dim cantReg As Integer = ProductosGridView.RowCount - 1

                        'If (i <> 0) And (i <> cantReg) Then
                        '    i = i - 1
                        'End If

                        If IsDBNull(ProductosGridView.Rows(i).Cells("CODIGO").Value) And IsDBNull(ProductosGridView.Rows(i).Cells("CODPRODUCTO").Value) And _
                    IsDBNull(ProductosGridView.Rows(i).Cells("CODCODIGO").Value) And IsDBNull(ProductosGridView.Rows(i).Cells("PRODUCTO").Value) And _
                    IsDBNull(ProductosGridView.Rows(i).Cells("PRECIOVENTA").Value) Then

                            MessageBox.Show("El Producto Seleccionado no contiene todos los datos necesarios para la venta", "POSEXPRESS")

                        Else
                            'eligiocbo = 0
                            tbxCodigoProd.Text = ProductosGridView.Rows(i).Cells("CODIGO").Value
                            CodProductoTextBox.Text = ProductosGridView.Rows(i).Cells("CODPRODUCTO").Value
                            CodCodigoTextBox.Text = ProductosGridView.Rows(i).Cells("CODCODIGO").Value

                            If IsDBNull(ProductosGridView.Rows(i).Cells("DESCODIGO1DataGridViewTextBoxColumn").Value) Then
                                lblDescripcionProducto.Text = ProductosGridView.Rows(i).Cells("PRODUCTO").Value
                            Else
                                lblDescripcionProducto.Text = ProductosGridView.Rows(i).Cells("PRODUCTO").Value + " " + ProductosGridView.Rows(i).Cells("DESCODIGO1DataGridViewTextBoxColumn").Value
                            End If
                            PrecioVentaMaskedEdit.Text = ProductosGridView.Rows(i).Cells("PRECIOVENTA").Value
                            Me.tbxCoheficiente.Text = FormatNumber(ProductosGridView.Rows(i).Cells("COHEFICIENTE").Value, 2)

                            'Si es Servicio VServicio = 1 (al contrario es 0)
                            vServicio = ProductosGridView.Rows(i).Cells("SERVICIODGVT").Value
                            If vServicio = 0 Then
                                lblEnStock.Text = ProductosGridView.Rows(i).Cells("STOCKACTUALDataGridViewTextBoxColumn").Value
                            Else
                                lblEnStock.Text = "Servicio"
                            End If

                            If IsDBNull(ProductosGridView.Rows(i).Cells("PROMOCION").Value) Then
                                vProdPromocion = 0
                            Else
                                If ProductosGridView.Rows(i).Cells("PROMOCION").Value = True Then
                                    vProdPromocion = 1
                                Else
                                    vProdPromocion = 0
                                End If
                            End If

                            If IsDBNull(ProductosGridView.Rows(i).Cells("PRODCOSTO").Value) Then
                                vProdCosto = 1
                            Else
                                vProdCosto = ProductosGridView.Rows(i).Cells("PRODCOSTO").Value
                            End If
                        End If

                        BuscarProductoTextBox.Text = ""
                        tbxCantidadVent.Focus()
                        'UltraPopupControlContainer1.Close()
                        ProductosGroupBox.Visible = False

                        CheckBox1.BackColor = Color.Transparent
                        If VerOtrosPrecios = 0 Then
                            CheckBox1.Enabled = False
                        Else
                            CheckBox1.Enabled = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RecorreEfectivo()
        Try
            Dim Monto, Moneda, Banco, TipoTarjeta, TotalVentaE, FactorVentaE, Subtotal, NroCheque As String
            TotalVentaE = "0" : Monto = "0" : FactorVentaE = "0" : Moneda = "" : Banco = "" : TipoTarjeta = "" : NroCheque = ""

            Dim c As Integer = CobroEfectivoTGridView.RowCount
            For c = 1 To c
                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value) Then
                    Monto = ""
                Else
                    Monto = FormatNumber(CobroEfectivoTGridView.Rows(c - 1).Cells("IMPORTEDataGridViewTextBoxColumn").Value, 2)
                End If

                If IsDBNull(CobroEfectivoTGridView.Rows(c - 1).Cells("COTIZACION1DataGridViewTextBoxColumn").Value) Then
                    FactorVentaE = ""
                Else
                    FactorVentaE = FormatNumber(CobroEfectivoTGridView.Rows(c - 1).Cells("COTIZACION1DataGridViewTextBoxColumn").Value, 2)
                End If

                Subtotal = Monto * FactorVentaE
                TotalVentaE = CDec(TotalVentaE) + Subtotal
            Next

            'Total Venta
            PagoLabel.Text = FormatNumber(TotalVentaE, 2)

            'Manejo del vuelto y demas yerbas
            Dim Debe, Pago, Vuelto, Falta As String

            If PagoLabel.Text = "" Then
                Pago = "0"
            Else
                Pago = PagoLabel.Text
            End If

            If DebeLabel.Text = "" Then
                Debe = "0"
            Else
                Debe = DebeLabel.Text
            End If

            If CDec(Pago) >= CDec(Debe) Then
                'Se cancelo la deuda
                Vuelto = CDec(Pago) - CDec(Debe)

                'Se verifica si el tipo de moneda es guaranies entonces se debe hacer el rendondeo
                If MonedaEfectivoComboBox.SelectedValue = 1 Then
                    VueltoLabel.Text = FormatNumber(Vuelto, 0)
                Else
                    VueltoLabel.Text = FormatNumber(Vuelto, 2)
                End If

            Else
                Falta = CDec(Debe) - CDec(Pago)

                'Se verifica si el tipo de moneda es guaranies entonces se debe hacer el rendondeo
                If MonedaEfectivoComboBox.SelectedValue = 1 Then
                    FaltaLabel.Text = FormatNumber(Falta, 0)
                Else
                    FaltaLabel.Text = FormatNumber(Falta, 2)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Problema Recorriendo Efecto: " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TarjetaPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TarjetaPanel.Click, TarjetaPictureBox.Click
        Tarjeta()
        RecorreEfectivo()
        cbxMonedaDebito.Focus()
    End Sub

    Private Sub TipoTarjetaComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TipoTarjetaComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
    End Sub

    Private Sub VolverVentaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VolverVentaButton.Click
        FacturacionPanel.BringToFront()
        panelactivo = "FacturacionPanel"
        ClienteLabel.ForeColor = Color.Black
        VentaLabel.ForeColor = Color.WhiteSmoke
        COBROLabel.ForeColor = Color.Black
        ErrorCodigoLabel.Visible = False
    End Sub

#End Region 'Methods

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim pag As String
        pag = "http://www.cogentpotential.com/soporte/"
        Shell("Explorer " & pag)
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub tbxCantidadVent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCantidadVent.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If PrecioVentaMaskedEdit.Enabled = True Then
                PrecioVentaMaskedEdit.Focus()
            Else
                AgregarDetVentaButton.Focus()
            End If
            If MultiplicarCant = True Then
                tbxCantidadVent.Text = CDec(tbxCantidadVent.Text) * CantListaPrecio
            End If
            KeyAscii = 0
        End If
        If KeyAscii = 42 Then
            If VerOtrosPrecios = 0 Then
                ParaListaPrecio2 = 1 : ParaListaPrecio = 0 : ParaPrecio = 0 : ParaEliminar = 0 : ParaUltimoPanel = 0
                ProductosGroupBox.Visible = False
                pnlCambiarPrecio.Visible = True
                pnlCambiarPrecio.BringToFront()

                txtCodigoSupervisor.Focus()
            Else
                If CodProductoTextBox.Text <> "" Then
                    Me.PRECIOTableAdapter.Fill(Me.DsFacturacionSimple.PRECIO, CodProductoTextBox.Text)
                    gbxListaPrecio.Visible = True
                    gbxListaPrecio.BringToFront()

                    tbxBuscaLista.Text = ""
                    tbxBuscaLista.Focus()

                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        primeritem = True
        cantImpreTick = 0
        EstaImprimiendo = 0
        Try
            NroVentaGlobal = 0
            Me.CLIENTESTableAdapter.Fill(Me.DsFacturacionSimple.CLIENTES)
            Me.DETPCTableAdapter.Fill(Me.DsFacturacionSimple.DETPC)
            Me.MONEDATableAdapter.Fill(Me.DsFacturacionSimple.MONEDA)
        Catch ex As Exception

        End Try

        'ESTADO DE LOS TABS
        Requisitos = 0 : Clientes = 0 : Venta = 0
        lblVentaTotal.Text = "" : lblNombreCliente.Text = "" : BuscarClientesTextBox.Text = ""

        ClienteLabel.ForeColor = Color.WhiteSmoke
        VentaLabel.ForeColor = Color.Black
        COBROLabel.ForeColor = Color.Black

        'Tab Clientes
        DeshabilitaCliente()
        ClientesPanel.BringToFront()
        panelactivo = "ClientesPanel"
        FechaCobroChequeTextBox.Text = Today
        BuscarClientesTextBox.Focus()
    End Sub

    Private Sub ProcesarVenta()
        Dim Grav10, Grav5, Exento, TotIva, TotalGrav As Decimal
        Dim FechaValidez As String = ""
        Dim nIVA10, nIVA5 As Decimal
        Dim UltimoRango, IdPCRango, ControlHasta As Integer

        cmd.CommandText = "SELECT Ultimo,RandoID, Rango2, Timbrado, FECHAVALIDEZ FROM Detpc WHERE RANDOID=" & cbxRangoId.SelectedValue & ""
        cmd.Connection = New SqlConnection(ser.CadenaConexion)
        cmd.Connection.Open()
        Dim RangoDataReader As SqlDataReader = cmd.ExecuteReader()

        Try
            Do While RangoDataReader.Read()
                UltimoRango = RangoDataReader("Ultimo")
                IdPCRango = RangoDataReader("Randoid")
                ControlHasta = RangoDataReader("Rango2")
                TimbradoFactura = RangoDataReader("Timbrado")
                FechaValidez = RangoDataReader("FECHAVALIDEZ")
            Loop
            cmd.Connection.Close()

        Catch ex As Exception
            cmd.Connection.Close()
            MessageBox.Show("Problema con el Rango Activo: " + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pnlCambioRangos.Visible = True
            Me.DETPCTableAdapter.Fill(DsFacturacionSimple.DETPC)
            CodRangoActual = Me.cbxRangoId.SelectedValue
            PanelRangoVisible = 1
            Exit Sub
        End Try

        'RESERVANDO el Nro de Factura a Utilizar
        CalculaNroFactura(UltimoRango, ControlHasta, IdPCRango)

        If PanelRangoVisible = 1 Then
            cbxRangoId.SelectedValue = cbxRangoId.SelectedValue
        End If

        '### IVA 5%
        If tbxGrav5.Text = "" Or tbxGrav5.Text = "0" Then
            Grav5 = 0
            nIVA5 = 0
        Else
            Grav5 = CDec(tbxGrav5.Text)
            nIVA5 = Grav5 / 21
        End If
        '### IVA 10%
        If tbxGrav10.Text = "" Or tbxGrav10.Text = "0" Then
            Grav10 = 0
            nIVA10 = 0
        Else
            Grav10 = CDec(tbxGrav10.Text)
            nIVA10 = Grav10 / 11
        End If
        '### EXCENTA
        If TotalExentaMaskedEdit.Text = "" Or TotalExentaMaskedEdit.Text = "0" Then
            Exento = 0
        Else
            Exento = CDec(TotalExentaMaskedEdit.Text)
        End If
        TotIva = nIVA10 + nIVA5
        TotalGrav = Grav5 + Grav10 + Exento
        IndiceTipoComprobante = DETPCBindingSource.Position

        Dim transaction As SqlTransaction = Nothing

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            InsertaVenta(Exento, TotalGrav, Grav10, Grav5, nIVA5, nIVA10, TotIva) 'ok
            InsertaDetalleVenta() 'ok
            InsertaMovProducto(1)

            Try
                sql = ""
                sql = "INSERT INTO FACTURACOBRAR (CODNUMEROCUOTA,CODVENTA,FECHAVCTO,SALDOCUOTA,IMPORTECUOTA,FECGRA,PAGADO,TIPOFACTURA,IDCLIENTE) " & _
                "VALUES ( 1 ," & _
                "" & CDec(CodVentaTextBox.Text) & ",GETDATE()," & CDec(lblVentaTotal.Text) & "," & CDec(lblVentaTotal.Text) & " ,GETDATE(),0,'CONTADO', " & CodClienteTextBox.Text & ") "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error Insertar Forma Cobro" & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            myTrans.Commit()

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            End Try
            MessageBox.Show("Error al Vender la Factura: " & ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Cancelamos todo :(
        Finally
            sqlc.Close()
        End Try

        ''esto descomentar para impresion completa
        FuncImprimir(FechaValidez)

        'Impresion paso a paso
        'Try
        '    ThreadPrint = New Thread(New ThreadStart(AddressOf FinalizarVentas))
        '    ThreadPrint.Start()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub btncobrarClick2()
        Dim UltimoRango, IdPCRango, ControlHasta As Integer
        Dim Grav10, Grav5, Excento, TotIva, TotalGrav As Decimal
        FechaValidez = ""
        Dim nIVA10, nIVA5 As Decimal

        cmd.CommandText = "SELECT Ultimo,RandoID, Rango2, Timbrado, FECHAVALIDEZ FROM Detpc WHERE RANDOID=" & cbxRangoId.SelectedValue & ""
        cmd.Connection = New SqlConnection(ser.CadenaConexion)
        cmd.Connection.Open()
        Dim RangoDataReader As SqlDataReader = cmd.ExecuteReader()

        Try
            Do While RangoDataReader.Read()
                UltimoRango = RangoDataReader("Ultimo")
                IdPCRango = RangoDataReader("Randoid")
                ControlHasta = RangoDataReader("Rango2")
                TimbradoFactura = RangoDataReader("Timbrado")
                FechaValidez = RangoDataReader("FECHAVALIDEZ")
            Loop
            cmd.Connection.Close()

        Catch ex As Exception
            cmd.Connection.Close()
            MessageBox.Show("Problema con el Rango Activo: " + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pnlCambioRangos.Visible = True
            Me.DETPCTableAdapter.Fill(DsFacturacionSimple.DETPC)
            CodRangoActual = Me.cbxRangoId.SelectedValue
            PanelRangoVisible = 1
            Exit Sub
        End Try

        'RESERVANDO el Nro de Factura a Utilizar
        CalculaNroFactura(UltimoRango, ControlHasta, IdPCRango)

        If PanelRangoVisible = 1 Then
            cbxRangoId.SelectedValue = cbxRangoId.SelectedValue
        End If

        '### IVA 5%
        If tbxGrav5.Text = "" Or tbxGrav5.Text = "0" Then
            Grav5 = 0
            nIVA5 = 0
        Else
            Grav5 = CDec(tbxGrav5.Text)
            nIVA5 = Grav5 / 21
        End If
        '### IVA 10%
        If tbxGrav10.Text = "" Or tbxGrav10.Text = "0" Then
            Grav10 = 0
            nIVA10 = 0
        Else
            Grav10 = CDec(tbxGrav10.Text)
            nIVA10 = Grav10 / 11
        End If
        '### EXCENTA
        If TotalExentaMaskedEdit.Text = "" Or TotalExentaMaskedEdit.Text = "0" Then
            Excento = 0
        Else
            Excento = CDec(TotalExentaMaskedEdit.Text)
        End If
        TotIva = nIVA10 + nIVA5
        TotalGrav = Grav5 + Grav10 + Excento
        IndiceTipoComprobante = DETPCBindingSource.Position

        CabPagoMax = f.Maximo("CABCOBRO", "VENTASFORMACOBRO")
        CabPagoMax = CabPagoMax + 1

        Dim transaction As SqlTransaction = Nothing

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            InsertaVenta(Excento, TotalGrav, Grav10, Grav5, nIVA5, nIVA10, TotIva) 'ok
            InsertaDetalleVenta() 'ok
            InsertaMovProducto(1)
            InsertaFormaCobro() 'ok?

            'Insertamos el Vuelto
            If CDec(PagoLabel.Text) > CDec(DebeLabel.Text) Then
                InsertaVuelto()
            End If

            'Al ser VENTAS SIMPLES debemos poder registrar el cobro de forma automatica.
            InsertarFacturaCobrar()
            myTrans.Commit()

            RecorreEfectivo()

            ''esto descomentar para impresion completa
            FuncImprimir(FechaValidez)

            'Impresion paso a paso
            'Try
            '    ThreadPrint = New Thread(New ThreadStart(AddressOf FinalizarVentas))
            '    ThreadPrint.Start()
            'Catch ex As Exception
            'End Try

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            End Try
            MessageBox.Show("Error al Vender la Factura: " & ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Cancelamos todo :(
        Finally
            sqlc.Close()
        End Try

        GraciasPanel.BringToFront()
        panelactivo = "GraciasPanel"
        RadButton1.Focus()

        If Config9 = "Si" Then  'Si se desea integrar contablidad en el modulo de ventas simples
            '-------------------------------------------- CONTABILIDAD ------------------------------------------------------------------------------------
            'Obtenemos los valores que se utilizaron el modulo de contabilidad - by Yolanda Zelaya 
            Dim ConceptoAsiento, IVA5, IVA10, IVAEXE, TOTALIVA, ClienteProveedor, cadena As String
            Dim Coti As Double

            If tbxGrav5.Text <> "0,0" Then
                IVA5 = CDec(tbxGrav5.Text) / 21
            Else
                IVA5 = 0
            End If

            If tbxGrav10.Text <> "0,0" Then
                IVA10 = CDec(tbxGrav10.Text) / 11
            Else
                IVA10 = 0
            End If

            IVAEXE = TotalExentaMaskedEdit.Text
            TOTALIVA = CDec(tbxGrav10.Text) + CDec(tbxGrav5.Text)
            ClienteProveedor = CodClienteTextBox.Text

            cadena = CInt(MonedaEfectivoComboBox.SelectedValue) & " ORDER BY FECHAMOVIMIENTO DESC"

            Cotizacion1 = f.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", cadena)
            Cotizacion1 = Cotizacion1.Replace(".", "")
            Coti = Cotizacion1

            ConceptoAsiento = "Factura de Venta Contado / " & NombreClienteTextBox.Text
            ReglaContable(IVAEXE, IVA5, IVA10, TOTALIVA, "VENTAS", CDec(CodVentaTextBox.Text), "CODVENTA", ConceptoAsiento, 1, 1, _
                          CODMONEDAPRINCIPAL, Coti, NumVenta, Today, CDec(lblVentaTotal.Text), "8", TimbradoFactura, ClienteProveedor, SucCodigo)

            CobroContabilidad(CabPagoMax, ClienteProveedor, SucCodigo)
            '------------------------------------------------------------------------------------------------------------------------------------------------
        End If
        If Config10 = "Si" And CobrarButton.Text = "Cobrar" Then ' comanda
            'TipoImpresion = 0 : Imprimir = 1
            TicketComanda()
        End If
    End Sub

    Public Sub FinalizarVentas()
        Dim c As Integer = DetalleVentaTGridView.RowCount()
        Dim nIVA5, nIVA10 As Decimal

        If tbxGrav5.Text = "" Or tbxGrav5.Text = "0" Then
            nIVA5 = 0
        Else
            nIVA5 = CDec(tbxGrav5.Text) / 21
        End If

        If tbxGrav10.Text = "" Or tbxGrav10.Text = "0" Then
            nIVA10 = 0
        Else
            nIVA10 = CDec(tbxGrav10.Text) / 11
        End If

        '##################################  IMPRIMIR    #################################
        If TipoImpresion = 0 Then   'Formato Ticket
            If Imprimir = 1 Then 'Se imprime
                If ValorFiscal = 0 Then 'Ticket¡
                    FinalizarVenTicket(impresora, NombreClienteTextBox.Text, NroFacturaLabel.Text, TimbradoFactura, lblVentaTotal.Text, PagoLabel.Text, VueltoLabel.Text, RUCClienteTextBox.Text, c, FechaValidez)
                ElseIf ValorFiscal = 1 Then 'Factura
                    FinalizarVenta(impresora, NombreClienteTextBox.Text, NroFacturaLabel.Text, TimbradoFactura, lblVentaTotal.Text, PagoLabel.Text, VueltoLabel.Text, RUCClienteTextBox.Text, c, FechaValidez, nIVA5, nIVA10, tbxGrav10.Text, tbxGrav5.Text, TotalExentaMaskedEdit.Text)
                End If
            End If
        ElseIf TipoImpresion = 1 Then 'Formato Impresora
            If Imprimir = 1 Then 'Se imprime
                ImprimirReporte()
            End If
        End If
        '##############################################################################
    End Sub

    Private Sub btnCobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCobrar.Click
        If Config6 = "Si" Then
            Try
                Dim UltimoRango As Integer
                UltimoRango = f.FuncionConsultaString("ULTIMO", "DETPC", "RANDOID", cbxRangoId.SelectedValue)
                'Obtenermos el Sgte. Nro. FActura
                EstiraNroFactura(UltimoRango)
                pnlCambioNroFact.BringToFront()
                pnlCambioNroFact.Visible = True
                cambiofact = 1
                tbxUltimosNros.Focus()
                tbxUltimosNros.SelectionStart = tbxUltimosNros.Text.Length
                cambiofact = 0
            Catch ex As Exception
                MessageBox.Show("Problema con el Rango Activo: " + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                pnlCambioNroFact.Visible = False
            End Try
        Else
            btncobrarClick2()
        End If
        'If Config10 = "Si" And CobrarButton.Text = "Cobrar" Then ' comanda
        '    TicketComanda()
        'End If
    End Sub

    Private Sub InsertaMovProducto(ByRef TipoOperacion As Integer)
        Dim CantidadFactura, CodCodigoFactura, Precio, Costeable As String
        Dim c As Integer = DetalleVentaTGridView.RowCount
        Dim IsServicio As Integer

        For c = 1 To c
            IsServicio = DetalleVentaTGridView.Rows(c - 1).Cells("Servicio").Value
            If IsServicio <> 1 Then
                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                    CantidadFactura = "NULL"
                    Costeable = 0
                Else
                    CantidadFactura = DetalleVentaTGridView.Rows(c - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                    CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                    CantidadFactura = Replace(CantidadFactura, ",", ".")

                    Costeable = 0
                    If TipoOperacion = 1 Then
                        CantidadFactura = "-" + CantidadFactura
                    End If
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                    CodCodigoFactura = "NULL"
                Else
                    CodCodigoFactura = DetalleVentaTGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value) Then
                    Precio = "NULL"
                Else
                    Precio = DetalleVentaTGridView.Rows(c - 1).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                    Precio = Funciones.Cadenas.QuitarCad(Precio, ".")
                    Precio = Replace(Precio, ",", ".")
                End If

                sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,STOCK) " & _
                           "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & SucCodigo & ",GETDATE(),8," & CodVentaTextBox.Text & _
                           "," & CantidadFactura & "," & Precio & ",'Venta Nro " & NroFacturaLabel.Text & "'," & Costeable & ",1)"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub PagoLabel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagoLabel.TextChanged
        If CDec(PagoLabel.Text) >= CDec(DebeLabel.Text) Then
            btnCobrar.Enabled = True
        Else
            btnCobrar.Enabled = False
        End If

    End Sub

    Private Sub RUCClienteTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RUCClienteTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If InStr(1, "0123456789-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

        If KeyAscii = 13 Then
            RadComboBoxTipoCliente.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub RadComboBoxTipoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadComboBoxTipoCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            DireccionClienteTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub DireccionClienteTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DireccionClienteTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TelefonoClienteTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub TelefonoClienteTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TelefonoClienteTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnGuardarCliente.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub btnReImprimirNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnReImprimirNuevo.Click
        If ReimprimirOtroNro = 0 Then
            ParaListaPrecio = 0 : ParaPrecio = 0 : ParaEliminar = 0 : ParaUltimoPanel = 1
            pnlCambiarPrecio.Visible = True
            pnlCambiarPrecio.BringToFront()
            txtCodigoSupervisor.Focus()
        Else
            ReImprimirNuevo()
        End If
    End Sub

    Private Sub ReImprimirNuevo()
        Dim UltimoRango, IdPCRango, ControlHasta As Integer
        Dim NroFacturaActual As String
        Dim FechaValidez As String = ""

        If EstaImprimiendo = 1 Then
            MessageBox.Show("Exite una Impresion en Ejecucion, Aguarde y Vuelva a Impimir", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Guardamos en una Variable en Nro de Factura Actual , Antes de ser cambiado por uno Nuevo
        NroFacturaActual = NroFacturaLabel.Text

        'Obtenemos el nuevo  Nro de Factura a ser utilizado
        cmd.CommandText = "SELECT Ultimo, RANDOID, Rango2, Timbrado, FECHAVALIDEZ FROM Detpc WHERE CODCOMPROBANTE=" & CodComprobante & " AND IP=" & CodigoMaquina & " AND ACTIVO = 1 AND CODSUCURSAL= " & SucCodigo & ""
        cmd.Connection = New SqlConnection(ser.CadenaConexion)
        cmd.Connection.Open()
        Dim RangoDataReader As SqlDataReader = cmd.ExecuteReader()

        Try
            Do While RangoDataReader.Read()
                UltimoRango = RangoDataReader("Ultimo")
                IdPCRango = RangoDataReader("Randoid")
                ControlHasta = RangoDataReader("Rango2")
                TimbradoFactura = RangoDataReader("Timbrado")
                FechaValidez = RangoDataReader("FECHAVALIDEZ")
            Loop

            cmd.Connection.Close()

            'Cambiamos el numero de factura
            CalculaNroFactura(UltimoRango, ControlHasta, IdPCRango)

            'Alcualizamos en la BD el nuevo nro de facura
            Dim transaction As SqlTransaction = Nothing

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            sql = ""
            sql = "UPDATE VENTAS SET NUMVENTA = '" & NumVenta & "' WHERE CODVENTA=" & CDec(CodVentaTextBox.Text) & ""

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            '##################################  IMPRIMIR    #################################
            If TipoImpresion = 0 Then   'Formato Ticket
                If Imprimir = 1 Then 'Se imprime
                    If ValorFiscal = 0 Then 'Ticket¡
                        ImprimirTicket(FechaValidez)
                    ElseIf ValorFiscal = 1 Then 'Factura
                        ImprimirFactura(FechaValidez)
                    End If
                End If

            ElseIf TipoImpresion = 1 Then 'Formato Impresora
                If Imprimir = 1 Then 'Se imprime
                    ImprimirReporte()
                End If
            End If
            '##############################################################################

            'Despues de Actualizar el nro de Factura Insertamos un Nuevo registro de Venta Anulado con el nro de Factura que se dejo de usar
            Dim UltimaVenta As Integer = w.Maximo("CODVENTA", "VENTAS")
            UltimaVenta = UltimaVenta + 1

            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            sql = ""
            sql = "INSERT INTO VENTAS (CODVENTA,NUMVENTA,FECHAVENTA,ESTADO,MODALIDADPAGO,CODSUCURSAL) " & _
                  "VALUES (" & UltimaVenta & ",'" & NroFacturaActual & "', GETDATE(), 2,0," & SucCodigo & ")"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            GraciasPanel.BringToFront()
            panelactivo = "GraciasPanel"
        Catch ex As Exception
            MessageBox.Show("No se pudo Generar Nuevo Nro de Factura: " + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub btnReImprimirMismo_Click(sender As System.Object, e As System.EventArgs) Handles btnReImprimirMismo.Click
        If ReimprimirMismoNro = 0 Then
            ParaListaPrecio = 0 : ParaPrecio = 0 : ParaEliminar = 0 : ParaUltimoPanel = 2
            pnlCambiarPrecio.Visible = True
            pnlCambiarPrecio.BringToFront()
            txtCodigoSupervisor.Focus()
        Else
            pdReImprimirMismoNro()
        End If
    End Sub

    Private Sub pdReImprimirMismoNro()
        Dim FechaValidez As String = ""

        If EstaImprimiendo = 1 Then
            MessageBox.Show("Exite una Impresion en Ejecucion, Aguarde y Vuelva a Impimir", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cmd.CommandText = "SELECT FECHAVALIDEZ FROM Detpc WHERE CODCOMPROBANTE=" & CodComprobante & " AND IP=" & CodigoMaquina & " AND ACTIVO = 1 AND CODSUCURSAL= " & SucCodigo & ""
        cmd.Connection = New SqlConnection(ser.CadenaConexion)
        cmd.Connection.Open()
        Dim RangoDataReader As SqlDataReader = cmd.ExecuteReader()

        Try
            Do While RangoDataReader.Read()
                FechaValidez = RangoDataReader("FECHAVALIDEZ")
            Loop
        Catch ex As Exception

        End Try

        cmd.Connection.Close()
        '##################################  IMPRIMIR    #################################
        If TipoImpresion = 0 Then   'Formato Ticket
            If Imprimir = 1 Then 'Se imprime
                If ValorFiscal = 0 Then 'Ticket¡
                    ImprimirTicket(FechaValidez)
                ElseIf ValorFiscal = 1 Then 'Factura
                    ImprimirFactura(FechaValidez)
                End If
            End If

        ElseIf TipoImpresion = 1 Then 'Formato Impresora
            If Imprimir = 1 Then 'Se imprime
                ImprimirReporte()
            End If
        End If
        '##############################################################################
        If Config10 = "Si" Then ' comanda
            'TipoImpresion = 0 : Imprimir = 1
            TicketComanda()
        End If
    End Sub

    Private Sub btnAnularFactura_Click(sender As System.Object, e As System.EventArgs) Handles btnAnularFactura.Click
        If ReimprimirMismoNro = 0 Then
            ParaListaPrecio = 0 : ParaPrecio = 0 : ParaEliminar = 0 : ParaUltimoPanel = 3
            pnlCambiarPrecio.Visible = True
            pnlCambiarPrecio.BringToFront()
            txtCodigoSupervisor.Focus()
        Else
            pdAnularFactura()
        End If
    End Sub

    Private Sub pdAnularFactura()
        'Alcualizamos en la BD el nuevo nro de facura
        Dim transaction As SqlTransaction = Nothing

        If MessageBox.Show("¿Esta seguro de anular la factura?", "POS EXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            sql = ""
            sql = "UPDATE VENTAS SET ESTADO = 2  WHERE CODVENTA=" & CDec(CodVentaTextBox.Text) & "   " & _
                  "DELETE FROM FACTURACOBRAR WHERE  CODVENTA =" & CDec(CodVentaTextBox.Text) & "   " & _
                  "DELETE FROM MOVIMIENTOCUENTACLIENTE WHERE  CODVENTA =" & CDec(CodVentaTextBox.Text) & "  "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            InsertaMovProducto(2)

            myTrans.Commit()

            MessageBox.Show("Factura Anulada, Recuerde Anular Tambien la Factura Impresa", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RadButton1_Click(Nothing, Nothing)
        Catch ex As Exception
            Try
                MessageBox.Show("Error al Anular la Venta ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                myTrans.Rollback("Actualizar")
            Catch
            End Try
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub DetalleVentaTGridView_DoubleClick(sender As Object, e As System.EventArgs) Handles DetalleVentaTGridView.DoubleClick
        Try
            If IsDBNull(DetalleVentaTGridView.CurrentRow) Then
                Exit Sub
            Else
                LineaVenta = DetalleVentaTGridView.CurrentRow.Index

                tbxCodigoProd.Text = DetalleVentaTGridView.CurrentRow.Cells("CodigoBarraDGVT").Value
                tbxCantidadVent.Text = CDec(DetalleVentaTGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value)
                PrecioVentaMaskedEdit.Text = CDec(DetalleVentaTGridView.CurrentRow.Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value)
                lblDescripcionProducto.Text = DetalleVentaTGridView.CurrentRow.Cells("ProductoDGVT").Value

                AgregarDetVentaButton.Text = "Modificar"
                EliminarDetVentaButton.Text = "Cancelar"

                'EFECTO TOLERANCIA ZERO
                PrecioVentaMaskedEdit.Focus()
                tbxCantidadVent.Focus()
                tbxCodigoProd.Focus()
                tbxCantidadVent.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub InicializarVentas()
        Dim fechafacturar As String
        fechafacturar = Today.ToShortDateString
        primeritem = True
        cantImpreTick = 0
        ' Button1_Click(Nothing, Nothing)

        'ProductosGroupBox.Show = False
        ProductosGroupBox.SendToBack()




        Try
            Me.CODIGOSTableAdapter.Fill(Me.DsFacturacionSimple.CODIGOS, SucCodigo, CDec(RadComboBoxTipoCliente.SelectedValue))
        Catch ex As Exception
        End Try

        CodCliente = CLIENTESBindingSource.Current("CODCLIENTE")
        CodComprobante = w.FuncionConsultaDecimal("CODCOMPROBANTE", "DETPC", "RANDOID", cbxRangoId.SelectedValue)

        CodComprobante = w.FuncionConsulta("CODCOMPROBANTE", "DETPC", "RANDOID", cbxRangoId.SelectedValue)

        'Para saber si imprime y la cantidad de lineas del detalle
        Cantlinea = w.FuncionConsulta("NROLINEASDETALLE", "TIPOCOMPROBANTE", "CODCOMPROBANTE", CodComprobante)

        'Se verifica que tipo de formato de impresion tiene dicho comprabante
        TipoImpresion = w.FuncionConsulta("FORMAIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", CodComprobante)

        'Una ves que sabemos el tipo de impresion debemos verificar si esta marcada la opcion de imprimir
        Imprimir = w.FuncionConsulta("IMPRIMIR", "DETPC", "IP=" & CodigoMaquina & " AND CODCOMPROBANTE=" & CodComprobante & " " & _
                                     "and ACTIVO =1 AND CODSUCURSAL", SucCodigo)

        impresora = w.FuncionConsultaString("IMPRESORA", "DETPC", "RANDOID=" & cbxRangoId.SelectedValue & "AND ACTIVO", 1)

        If impresora = "" And Imprimir = 1 Then
            MessageBox.Show("Esta maquina No tiene Impresora asignada", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ErrorFuncion = 1
            Exit Sub
        End If

        If RadComboBoxTipoCliente.SelectedValue = Nothing Then
            MessageBox.Show("Este Cliente no pertenece a una Lista de Precio, asigne antes de continuar", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ErrorFuncion = 1
            Exit Sub
        End If

        FacturacionPanel.BringToFront()
        panelactivo = "FacturacionPanel"
        tbxCodigoProd.Focus()

        primeritem = True : cantImpreTick = 0 : btnCobrar.Enabled = False

        VENTASBindingSource.AddNew()

        'limpiamos
        tbxCantidadVent.Text = "" : tbxCodigoProd.Text = "" : PrecioVentaMaskedEdit.Text = "" : lblDescripcionProducto.Text = "" : lblVentaTotal.Text = ""

        If Config1 = "No" Then
            CobrarButton.Text = "Imprimir Factura"
        Else
            CobrarButton.Text = "Cobrar"
        End If

        tbxCodigoProd.Focus()

        'Labels Cliente, Venta y Cobro
        ClienteLabel.ForeColor = Color.Black
        VentaLabel.ForeColor = Color.WhiteSmoke
        COBROLabel.ForeColor = Color.Black
    End Sub

    Private Sub VentasSimple_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If panelactivo = "FacturacionPanel" Then
            If e.KeyCode = Keys.F12 Then
                If ProductosGroupBox.Visible = True Then
                    ProductosGroupBox.Visible = False
                End If
                CobrarButton_Click(Nothing, Nothing)
            ElseIf e.KeyCode = Keys.Escape Then
                If ProductosGroupBox.Visible = True Then
                    ProductosGroupBox.Visible = False
                    tbxCodigoProd.Focus()
                End If
                If gbxListaPrecio.Visible = True Then
                    gbxListaPrecio.Visible = False
                    tbxCantidadVent.Focus()
                End If
                If EliminarDetVentaButton.Text = "Cancelar" Then
                    EliminarDetVentaButton_Click(Nothing, Nothing)
                End If
            ElseIf e.KeyCode = Keys.F8 Then
                If DetalleVentaTGridView.RowCount <> 0 Then
                    DetalleVentaTGridView_DoubleClick(Nothing, Nothing)
                End If
            ElseIf e.KeyCode = Keys.F1 Then
                If ProductosGroupBox.Visible = True Then
                    BuscarProductoTextBox.Focus()
                Else
                    tbxCodigoProd.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub dgvClientes_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientes.CellDoubleClick
        EstaImprimiendo = 0
        pnlCambioRangos.BringToFront()
        cbxRangoId.Focus()
    End Sub

    Private Sub btnIniciarVenta_Click(sender As System.Object, e As System.EventArgs) Handles btnIniciarVenta.Click
        EstaImprimiendo = 0
        pnlCambioRangos.BringToFront()
        cbxRangoId.Focus()
        ClientesPanel.Enabled = False
        panelactivo = "FacturacionPanel"
    End Sub

    Private Sub cbxRangoId_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxRangoId.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlCambioRangos.SendToBack()
            ClientesPanel.Enabled = True
            BuscarClientesTextBox.Focus()
        End If
    End Sub

    Private Sub cbxRangoId_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxRangoId.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        AccNuevo = 0 : AccEditar = 0 : ErrorFuncion = 0

        If KeyAscii = 13 Then
            InicializarVentas()

            If ErrorFuncion = 0 Then
                FacturacionPanel.BringToFront()
                panelactivo = "FacturacionPanel"
                ClientesPanel.Enabled = True

                If ModificarPresioVenta = 0 Then
                    PrecioVentaMaskedEdit.Enabled = False
                Else
                    PrecioVentaMaskedEdit.Enabled = True
                End If

                If PuedeEliminarDetalle = 0 Then
                    EliminarDetVentaButton.Enabled = False
                Else
                    EliminarDetVentaButton.Enabled = True
                End If

                If Config2 = "Mostrar Siempre" Then
                    CodCodigoTextBox.Text = "" : CodComboTextBox.Text = "" : ErrorCodigoLabel.Visible = False

                    ProductosGroupBox.Visible = True
                    ProductosGroupBox.BringToFront()
                    BuscarProductoTextBox.Focus()

                    CheckBox1.Checked = False
                    BuscarProductoTextBox.Text = ""
                    BuscarProductoTextBox.Focus()

                    If VenderMasPermiso = 0 Then
                        CODIGOSBindingSource.Filter = "STOCKACTUAL > 0"
                    End If

                    If VerOtrosPrecios = 0 Then
                        CheckBox1.Enabled = False
                    Else
                        CheckBox1.Enabled = True
                    End If
                End If
                'aqui volver a comentar
                'Try
                '    'Se verifica que tipo de formato de impresion tiene dicho comprabante
                '    TipoImpresion = w.FuncionConsulta("FORMAIMPRESION", "TIPOCOMPROBANTE INNER JOIN DETPC ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "ACTIVO=1 AND RANDOID", cbxRangoId.SelectedValue)
                '    'Una ves que sabemos el tipo de impresion debemos verificar si esta marcada la opcion de imprimir
                '    Imprimir = w.FuncionConsulta("IMPRIMIR", "DETPC", "RANDOID", cbxRangoId.SelectedValue)
                '    ValorFiscal = w.FuncionConsulta("VALORFISCAL", "TIPOCOMPROBANTE INNER JOIN DETPC ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "ACTIVO=1 AND RANDOID", cbxRangoId.SelectedValue)

                '    ThreadPrint = New Thread(New ThreadStart(AddressOf ImprimirCabecera))
                '    ThreadPrint.Start()
                'Catch ex As Exception
                'End Try
                'aqui volver a comentar
            End If
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Public Sub ImprimirCabecera()
        If TipoImpresion = 0 Then   'Formato Ticket
            If Imprimir = 1 Then 'Se imprime
                IniciarImpresion(impresora)
            End If
        End If
    End Sub

    Private Sub dgvClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            pnlCambioRangos.BringToFront()
            cbxRangoId.Focus()
            ClientesPanel.Enabled = False
            e.Handled = True
        End If

    End Sub

    Private Sub dgvClientes_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgvClientes.KeyPress

        'Dim KeyAscii As Short = Asc(e.KeyChar)
        'If KeyAscii = 13 Then

        '    If dgvClientes.RowCount = 1 Then
        '        'hacer nada ya que es el unico de la lista
        '    Else
        '        Dim ClientRowNro As Integer = dgvClientes.CurrentRow.Index
        '        ClientRowNro = ClientRowNro - 1
        '        dgvClientes.CurrentCell = dgvClientes(0, ClientRowNro)
        '    End If

        '    pnlCambioRangos.BringToFront()
        '    cbxRangoId.Focus()
        '    ClientesPanel.Enabled = False
        'End If
        'If KeyAscii = 0 Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub txtCodigoSupervisor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoSupervisor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 27 Then 'Escape
            btnCerrarPanelSupervisor_Click(Nothing, Nothing)
        ElseIf KeyAscii = 13 Then
            If txtCodigoSupervisor.Text <> "" Then
                Dim ExisteCodigo As Integer
                'Verificamos si el codigo de Supervisor existe
                ExisteCodigo = w.FuncionConsultaDecimal("CODUSUARIO", "USUARIO", "CODSUPERVISOR", txtCodigoSupervisor.Text)

                If ExisteCodigo <> 0 Then
                    If ParaPrecio = 1 Then
                        PrecioVentaMaskedEdit.Enabled = True
                        PrecioVentaMaskedEdit.Focus()
                        PrecioVentaMaskedEdit.Appearance.BackColor = Color.Pink

                    ElseIf ParaListaPrecio = 1 Then
                        CheckBox1.Enabled = True
                        CheckBox1.BackColor = Color.Pink
                        ProductosGroupBox.Visible = True

                    ElseIf ParaListaPrecio2 = 1 Then
                        If Trim(CodProductoTextBox.Text) <> "" Then
                            Me.PRECIOTableAdapter.Fill(Me.DsFacturacionSimple.PRECIO, CodProductoTextBox.Text)
                            gbxListaPrecio.Visible = True
                            gbxListaPrecio.BringToFront()

                            tbxBuscaLista.Text = ""
                            tbxBuscaLista.Focus()
                        End If

                    ElseIf ParaEliminar = 1 Then
                        EliminarDetVentaButton.Enabled = True

                    ElseIf ParaUltimoPanel = 1 Then
                        ReImprimirNuevo()

                    ElseIf ParaUltimoPanel = 2 Then
                        pdReImprimirMismoNro()

                    ElseIf ParaUltimoPanel = 3 Then
                        pdAnularFactura()

                    End If

                    pnlCambiarPrecio.Visible = False
                Else
                    MessageBox.Show("Código Incorrecto, Intente Otra Vez", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCodigoSupervisor.Focus()
                    Exit Sub
                End If

                txtCodigoSupervisor.Text = ""
            Else
                pnlCambiarPrecio.SendToBack()
                pnlCambiarPrecio.Visible = False
            End If
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ProductosGroupBox.Visible = False
        tbxCodigoProd.Focus()
        CheckBox1.BackColor = Color.Transparent
        If VerOtrosPrecios = 0 Then
            CheckBox1.Enabled = False
        Else
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub btnCerrarPanelFactura_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarPanelFactura.Click
        pnlCambioRangos.SendToBack()
        ClientesPanel.Enabled = True
        BuscarClientesTextBox.Focus()
    End Sub

    Private Sub cbxMonedaTrCredito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMonedaTrCredito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            BancoDebitoComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxMonedaDebito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMonedaDebito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TipoTarjetaComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub Efectivo()
        CobroTabStrip.SelectedTab = EfectivoTabItem

        EfectivoPanel.BackColor = Color.LightGray
        TarjetaPanel.BackColor = Color.WhiteSmoke
        ChequePanel.BackColor = Color.WhiteSmoke
        DebitoPanel.BackColor = Color.WhiteSmoke

        Filtro = "Efectivo"
    End Sub

    Private Sub Debito()
        CobroTabStrip.SelectedTab = DebitoTabItem

        EfectivoPanel.BackColor = Color.WhiteSmoke
        TarjetaPanel.BackColor = Color.WhiteSmoke
        ChequePanel.BackColor = Color.WhiteSmoke
        DebitoPanel.BackColor = Color.LightGray

        Filtro = "Tarjeta de Débito"
    End Sub

    Private Sub Tarjeta()
        CobroTabStrip.SelectedTab = TarjetaTabItem

        EfectivoPanel.BackColor = Color.WhiteSmoke
        TarjetaPanel.BackColor = Color.LightGray
        ChequePanel.BackColor = Color.WhiteSmoke
        DebitoPanel.BackColor = Color.WhiteSmoke

        Filtro = "Tarjeta de Crédito"
    End Sub

    Private Sub Cheque()
        CobroTabStrip.SelectedTab = ChequeTabItem

        EfectivoPanel.BackColor = Color.WhiteSmoke
        TarjetaPanel.BackColor = Color.WhiteSmoke
        ChequePanel.BackColor = Color.LightGray
        DebitoPanel.BackColor = Color.WhiteSmoke

        Filtro = "Cheque"
    End Sub

    Private Sub DetalleVentaTGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DetalleVentaTGridView.KeyDown
        If e.KeyCode = Keys.Delete Then
            EliminarDetVentaButton_Click(Nothing, Nothing)
            'pnlCambiarPrecio.Visible = True
            'pnlCambiarPrecio.BringToFront()
            'ParaPrecio = 0 : ParaListaPrecio = 0 : ParaEliminar = 1 : ParaUltimoPanel = 0
            'txtCodigoSupervisor.Focus()
        End If
    End Sub

    Private Sub btnCerrarPanelSupervisor_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarPanelSupervisor.Click
        pnlCambiarPrecio.Visible = False
        If ParaListaPrecio2 = 1 Then
            tbxCantidadVent.Text = 1
            tbxCantidadVent.Focus()
        End If
    End Sub

    Private Sub dgwListaPrecio_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwListaPrecio.CellDoubleClick
        If dgwListaPrecio.RowCount <> 0 Then

            PrecioVentaMaskedEdit.Text = dgwListaPrecio.CurrentRow.Cells("PRECIOVENTADataGridViewTextBoxColumn").Value
            If IsDBNull(dgwListaPrecio.CurrentRow.Cells("CANTIDADDataGridViewTextBoxColumn").Value) Then
                tbxCantidadVent.Text = 1
            Else
                tbxCantidadVent.Text = dgwListaPrecio.CurrentRow.Cells("CANTIDADDataGridViewTextBoxColumn").Value
                CantListaPrecio = dgwListaPrecio.CurrentRow.Cells("CANTIDADDataGridViewTextBoxColumn").Value
                If tbxCantidadVent.Text = 0 Then
                    tbxCantidadVent.Text = 1
                End If
            End If
            If IsDBNull(dgwListaPrecio.CurrentRow.Cells("CANTMULT").Value) Then
                MultiplicarCant = False
            Else
                If dgwListaPrecio.CurrentRow.Cells("CANTMULT").Value = True Then
                    MultiplicarCant = True
                    tbxCantidadVent.Text = 1
                Else
                    MultiplicarCant = False
                End If
            End If
            tbxCantidadVent.Focus()
            gbxListaPrecio.Visible = False
        End If
    End Sub

    Private Sub dgwListaPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgwListaPrecio.KeyDown
        Dim index As Integer
        If e.KeyCode = Keys.Enter Then
            If dgwListaPrecio.RowCount <> 0 Then
                index = Me.PRECIOBindingSource.Position

                PrecioVentaMaskedEdit.Text = dgwListaPrecio.Rows(index).Cells("PRECIOVENTADataGridViewTextBoxColumn").Value
                If IsDBNull(dgwListaPrecio.Rows(index).Cells("CANTIDADDataGridViewTextBoxColumn").Value) Then
                    tbxCantidadVent.Text = 0
                Else
                    tbxCantidadVent.Text = dgwListaPrecio.CurrentRow.Cells("CANTIDADDataGridViewTextBoxColumn").Value
                End If

                gbxListaPrecio.Visible = False
                tbxCantidadVent.Focus()
            End If
        End If
    End Sub

    Private Sub NroFacturaLabel_Click(sender As System.Object, e As System.EventArgs) Handles NroFacturaLabel.Click
        permiso = PermisoAplicado(UsuCodigo, 214) 'Modificar Nro. Factura ya Aprobada
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else
            Dim nvoNumero As String = InputBox("Ingrese el nuevo Nro. de Factura: ", " Modificar Nro. Factura", Me.NroFacturaLabel.Text)
            If nvoNumero <> Me.NroFacturaLabel.Text And nvoNumero <> "" Then
                'modificamos nro. de factura sin validaciones, por el momento
                Try
                    Dim consulta As System.String
                    Dim conexion As System.Data.SqlClient.SqlConnection

                    conexion = ser.Abrir()
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    consulta = "UPDATE VENTAS SET NUMVENTA='" & nvoNumero & "' WHERE CODVENTA=" & CDec(CodVentaTextBox.Text) & ""
                    Consultas.ConsultaComando(myTrans, consulta)

                    myTrans.Commit()

                    NroFacturaLabel.Text = nvoNumero
                Catch ex As Exception
                    MsgBox(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub tbxBuscaLista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbxBuscaLista.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgwListaPrecio_CellDoubleClick(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            tbxCantidadVent.Focus()
            gbxListaPrecio.Visible = False
        ElseIf e.KeyCode = Keys.Tab Then
            dgwListaPrecio.Focus()
        End If
    End Sub

    Private Sub tbxBuscaLista_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxBuscaLista.TextChanged
        If Trim(tbxBuscaLista.Text) <> "" Then
            Dim strbusc, strlista, strorden As String
            strbusc = StrConv(tbxBuscaLista.Text, VbStrConv.Uppercase)
            For i = 0 To dgwListaPrecio.RowCount - 1
                If Not System.Text.RegularExpressions.Regex.IsMatch(tbxBuscaLista.Text, "^\d*$") Then ' Si introduce letras
                    strlista = StrConv(dgwListaPrecio.Rows(i).Cells("DESTIPOCLIENTEDataGridViewTextBoxColumn").Value, VbStrConv.Uppercase)
                    If strlista.Contains(strbusc) Then
                        dgwListaPrecio.CurrentCell = dgwListaPrecio(0, i)
                        Exit For
                    End If
                Else
                    strorden = StrConv(dgwListaPrecio.Rows(i).Cells("ORDEN").Value, VbStrConv.Uppercase)
                    If strorden.Contains(strbusc) Then
                        dgwListaPrecio.CurrentCell = dgwListaPrecio(0, i)
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub btnOKCambioFact_Click(sender As System.Object, e As System.EventArgs) Handles btnOKCambioFact.Click
        If Trim(tbxUltimosNros.Text) <> "" Then
            NumVenta = lblPrimerosNros.Text + Trim(tbxUltimosNros.Text)
            cambioNroFact = 1
            If panelactivo = "FacturacionPanel" Then
                CobrarButtonClick2()
            ElseIf panelactivo = "CobroPanel" Then
                btncobrarClick2()
            End If
            cambioNroFact = 0
            pnlCambioNroFact.Visible = False
        End If
    End Sub

    Private Sub tbxUltimosNros_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbxUltimosNros.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlCambioNroFact.SendToBack()
            pnlCambioNroFact.Visible = False
        End If
    End Sub

    Private Sub tbxUltimosNros_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxUltimosNros.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnOKCambioFact_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tbxUltimosNros_TextChanged(sender As Object, e As System.EventArgs) Handles tbxUltimosNros.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(tbxUltimosNros.Text, "^\d*$") Then 'Que introduzca solo numeros
            tbxUltimosNros.Text = tbxUltimosNros.Text.Remove(tbxUltimosNros.Text.Length - 1)
            tbxUltimosNros.SelectionStart = tbxUltimosNros.Text.Length
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Try
            Me.CODIGOSTableAdapter.Fill(Me.DsFacturacionSimple.CODIGOS, SucCodigo, CDec(RadComboBoxTipoCliente.SelectedValue))

            If VenderMasPermiso = 0 Then
                CODIGOSBindingSource.Filter = "STOCKACTUAL > 0"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnConsultarPrecios_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultarPrecios.Click
        CodCodigoTextBox.Text = "" : CodComboTextBox.Text = ""
        ErrorCodigoLabel.Visible = False : ProductosGroupBox.Visible = True
        ProductosGroupBox.BringToFront()

        BuscarProductoTextBox.Text = ""
        buscador = 1
        BuscarProductoTextBox.Focus()
        buscador = 0
        BuscarProductoTextBox.Enabled = True : BuscarProductoTextBox.ReadOnly = False

        If VenderMasPermiso = 0 Then
            CODIGOSBindingSource.Filter = "STOCKACTUAL > 0"
        End If

        If VerOtrosPrecios = 0 Then
            CheckBox1.Enabled = False
            CheckBox1.Checked = False
        Else
            CheckBox1.Enabled = True
            CheckBox1.Checked = True
        End If
    End Sub

    Public Sub TicketComanda() 'SAUL
        Dim ticket As New TicketComanda.Ticket
        Dim CodVentaC, CantVentaC As Integer
        Dim DesProductoC, NombreC As String

        CodVentaC = 0 : CantVentaC = 0 : DesProductoC = "" : NombreC = ""

        ticket.AddHeaderLine(RecortaCaracteres("*******"))
        ticket.AddHeaderLine("           C O P I A")
        ticket.AddHeaderLine("")
        ticket.AddHeaderLine("         C O M A N D A")
        ticket.AddHeaderLine("")

        Dim CajeroDesc As String

        CajeroDesc = UsuNombre
        CajeroDesc = RecortaCaracteres2(CajeroDesc)

        '##########################################################
        'ticket.AddSubHeaderLine("FECHA/HORA:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
        'ticket.AddSubHeaderLine("CAJA Nº:" + NumCaja.ToString + "  " + "CAJERO:" + CajeroDesc)
        '##########################################################

        Dim c As Integer = DetalleVentaTGridView.RowCount()
        For i = 1 To c
            'Ceramos el SubTotalLinea para no sumar
            'Subtotallinea = 0

            DesProductoC = DetalleVentaTGridView.Rows(i - 1).Cells("ProductoDGVT").Value
            'If DesProductoC.Count <= 8 Then
            'Else
            '    DesProductoC = DesProductoC.Remove(8, DesProductoC.Count - 8)
            'End If

            CantVentaC = CInt(DetalleVentaTGridView.Rows(i - 1).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value)

            '#####################################################################################

            ticket.AddItem(CantVentaC, DesProductoC)
        Next
        '##########################################################

        '##########################################################

        ticket.AddFooterLine("===============================")
        ticket.AddFooterLine("")
        ticket.AddFooterLine("**NO VALIDO COMO COMPROBANTE**")

        Try
            ticket.PrinterExists(impresora)
            'ticket.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Problema al Imprimir Ticket Comanda : " & ex.Message, "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ProductosGridView_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosGridView.CellContentClick

    End Sub

    Private Sub ProductosGroupBox_Click(sender As System.Object, e As System.EventArgs) Handles ProductosGroupBox.Click

    End Sub

    Private Sub RUCClienteTextBox_TextChanged(sender As Object, e As EventArgs) Handles RUCClienteTextBox.TextChanged

    End Sub
End Class


