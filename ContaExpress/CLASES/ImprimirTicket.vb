Imports Osuna.Utiles.Conectividad
Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.Shared
Imports EnviaInformes
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Imports System.Threading


Module ImprimirTicket

    Private cmd As New SqlCommand
    Private sqlc As New SqlConnection
    Private myTrans As System.Data.SqlClient.SqlTransaction
    Private ser As BDConexión.BDConexion
    Dim w As New Funciones.Funciones
    Dim tckCabecera As New BarControls.Ticket
    Dim tckNuevoDetalle As New BarControls.Ticket
    Dim tckCancelarVenta As New BarControls.Ticket
    Dim ticket2 As New BarControls.Ticket
    Dim ticket3 As New BarControls.Ticket
    Dim Codigo, DescripcionProducto, Cantidad, Precio, Subtotallinea, Cliente As String
    Dim Empresa, RucEmpresa, Sucursal, DirSuc, CiudadSuc, TelSuc As String


    Sub New()
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Public Sub IniciarImpresion(ByVal impresora As String)
        Codigo = "" : DescripcionProducto = "" : Cantidad = "" : Precio = "" : Subtotallinea = ""
        Empresa = "" : RucEmpresa = "" : Sucursal = "" : DirSuc = "" : CiudadSuc = "" : TelSuc = ""

        '###################Traer Datos de Sucursal,Empresa y Cliente##############################################################################
        Try
            RucEmpresa = w.FuncionConsultaString2("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)

            cmd.CommandText = "SELECT dbo.CIUDAD.DESCIUDAD, dbo.SUCURSAL.DIRECCION, dbo.SUCURSAL.TELEFONO FROM dbo.SUCURSAL LEFT OUTER JOIN  " & _
                              "dbo.CIUDAD ON dbo.SUCURSAL.CODCIUDAD = dbo.CIUDAD.CODCIUDAD  WHERE (dbo.SUCURSAL.CODSUCURSAL = " & SucCodigo & ")"

            cmd.Connection = New SqlConnection(sqlc.ConnectionString)
            cmd.Connection.Open()
            Dim RangoDataReader As SqlDataReader = cmd.ExecuteReader()

            Do While RangoDataReader.Read()
                DirSuc = RangoDataReader("DIRECCION")
                TelSuc = RangoDataReader("TELEFONO")
                CiudadSuc = RangoDataReader("DESCIUDAD")
            Loop
            cmd.Connection.Close()
        Catch ex As Exception

        End Try
        '################Cuerpo del Ticket ########################
        'recorta caracteres para centrar
        Dim CajeroDesc As String = ""

        Try
            CajeroDesc = UsuNombre
            CajeroDesc = RecortaCaracteres2(CajeroDesc)

            Empresa = UCase(RecortaCaracteres(EmpNomFantasia))
            DirSuc = DirSuc + "-" + CiudadSuc 'RecortaCaracteres3(DirSuc + "-" + CiudadSuc)
            RucEmpresa = RecortaCaracteres("RUC:" + RucEmpresa)
            TelSuc = RecortaCaracteres("TEL:" + TelSuc)
        Catch ex As Exception

        End Try

        tckCabecera.AddHeaderLine(RecortaCaracteres("* * * * * *"))
        tckCabecera.AddHeaderLine(Empresa)
        tckCabecera.AddHeaderLine(DirSuc)
        tckCabecera.AddHeaderLine(RucEmpresa)
        tckCabecera.AddHeaderLine(TelSuc)


        tckCabecera.AddSubHeaderLine("FECHA/HORA:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
        tckCabecera.AddSubHeaderLine("CAJA Nº:" + NumeroCaja + "  " + "CAJERO:" + CajeroDesc)

        Try
            tckCabecera.PrintTicket(impresora)
        Catch ex As Exception
            If MessageBox.Show("Nombre de impresora invalida. Desea ver el error?", "POSExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Try
    End Sub

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

    Public Sub CargarDetalle(ByVal impresora As String, ByVal Cantidad As String, ByVal Precio As String, ByVal DescripcionProducto As String, ByVal primeritem As Boolean)
        If DescripcionProducto.Count <= 8 Then
        Else
            DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)
        End If

        Subtotallinea = Cantidad * Precio

        Precio = Replace(Precio, ".", "")
        Precio = FormatNumber(Precio, 0)
        Subtotallinea = Replace(Subtotallinea, ".", "")
        Subtotallinea = FormatNumber(Subtotallinea, 0)

        If primeritem = True Then
            tckNuevoDetalle.AddItem(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(4), "", Precio.PadLeft(6) & " " & Subtotallinea.PadLeft(6))
        Else
            tckNuevoDetalle.AddItem1(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(4), "", Precio.PadLeft(6) & " " & Subtotallinea.PadLeft(6))
        End If
        Try
            tckNuevoDetalle.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    
    Public Sub EliminarDetalle(ByVal impresora As String, ByVal Cantidad As String, ByVal Precio As String, ByVal DescripcionProducto As String)
        If DescripcionProducto.Count <= 8 Then
        Else
            DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)
        End If

        Subtotallinea = Cantidad * Precio

        Precio = Replace(Precio, ".", "") : Precio = FormatNumber(Precio, 0) : Precio = "-" & Precio
        Subtotallinea = Replace(Subtotallinea, ".", "") : Subtotallinea = FormatNumber(Subtotallinea, 0) : Subtotallinea = "-" & Subtotallinea
        Cantidad = "-" & Cantidad

        ticket2.AddItem1(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(4), "", Precio.PadLeft(6) & " " & Subtotallinea.PadLeft(6))

        Try
            ticket2.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub FinalizarVenta(ByVal impresora As String, NombreClienteTextBox As String, NroFacturaLabel As String, TimbradoFactura As String, lblVentaTotal As String, PagoLabel As String, VueltoLabel As String, RUCClienteTextBox As String, ByVal CantidadLineas As String, ByVal FechaValidez As String, ByVal nIVA5 As Integer, ByVal nIVA10 As Integer, ByVal Grav10 As Integer, ByVal Grav5 As Integer, ByVal Excento As Integer)
        'ds.Clear()
        Dim TotalItems10, TotalItems5, TotalItemsExento As Decimal
        Dim Total10, Total5 As Integer

        TotalItemsExento = Excento
        TotalItems10 = Grav10 - nIVA10 : TotalItems10 = FormatNumber(TotalItems10, 0)
        TotalItems5 = Grav5 - nIVA5 : TotalItems5 = FormatNumber(TotalItems5, 0)

        Total10 = nIVA10 : Total10 = FormatNumber(Total10, 0)
        Total5 = nIVA5 : Total5 = FormatNumber(Total5, 0)

        Cliente = ""
        Cliente = RTrim(NombreClienteTextBox)

        '##########################################################
        'recorta caracteres para centr
        '##########################################################
        ticket3.AddTotal("       TOTAL VENTA :", FormatNumber(lblVentaTotal, 0))
        ticket3.AddTotal("       RECIBIDO Gs.:", FormatNumber(PagoLabel, 0))
        ticket3.AddTotal("       VUELTO   Gs.:", FormatNumber(VueltoLabel, 0))
        ticket3.AddTotal("", "")
        ticket3.AddTotal("===============================", "=")
        Total10 = Replace(Total10, ".", ",")
        Total5 = Replace(Total5, ".", ",")
        TotalItemsExento = Replace(TotalItemsExento, ".", ",")
        ticket3.AddTotal("TOTAL GRAVADA 10% Gs.:", TotalItems10.ToString)
        ticket3.AddTotal("TOTAL GRAVADA 5%  Gs.:", TotalItems5.ToString)
        ticket3.AddTotal("TOTAL EXENTAS     GS.:", TotalItemsExento)
        ticket3.AddTotal("===============================", "=")
        ticket3.AddTotal("LIQUIDACION DEL IVA", "")
        ticket3.AddTotal("IVA 10% Gs.:", Total10)
        ticket3.AddTotal("IVA 5%  Gs.:", Total5)
        ticket3.AddTotal("===============================", "=")
        '##########################################################
        ticket3.AddFooterLine("FAC. CONTADO" + " Nº" + NroFacturaLabel)
        ticket3.AddFooterLine("TIMBRADO:" + TimbradoFactura)
        ticket3.AddFooterLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        ticket3.AddFooterLine("================================")
        ticket3.AddFooterLine("CANTIDAD DE ARTICULOS:" + CantidadLineas.ToString)
        ticket3.AddFooterLine("RUC CLIENTE:" + RUCClienteTextBox)
        ticket3.AddFooterLine("CLIENTE:" + Cliente)
        ticket3.AddFooterLine("")
        ticket3.AddFooterLine("================================")
        ticket3.AddFooterLine("")
        ticket3.AddFooterLine("*****GRACIAS POR SU COMPRA******")

        Try
            ticket3.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Problema al Imprimir Ticket Fiscal : ", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub FinalizarVenTicket(ByVal impresora As String, NombreClienteTextBox As String, NroFacturaLabel As String, TimbradoFactura As String, lblVentaTotal As String, PagoLabel As String, VueltoLabel As String, RUCClienteTextBox As String, ByVal CantidadLineas As String, ByVal FechaValidez As String)
        Cliente = ""
        Cliente = RTrim(NombreClienteTextBox)

        ticket3.AddTotal("       TOTAL VENTA :", FormatNumber(lblVentaTotal, 0))
        ticket3.AddTotal("       RECIBIDO Gs.:", FormatNumber(PagoLabel, 0))
        ticket3.AddTotal("       VUELTO   Gs.:", FormatNumber(VueltoLabel, 0))
        ticket3.AddTotal("", "")
        ticket3.AddTotal("===============================", "=")
        '##########################################################
        ticket3.AddFooterLine("TICKET Nº" + NroFacturaLabel)
        ticket3.AddFooterLine("TIMBRADO:" + TimbradoFactura)
        ticket3.AddFooterLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        ticket3.AddFooterLine("================================")
        ticket3.AddFooterLine("CANTIDAD DE ARTICULOS:" + CantidadLineas.ToString)
        ticket3.AddFooterLine("RUC CLIENTE:" + RUCClienteTextBox)
        ticket3.AddFooterLine("CLIENTE:" + Cliente)
        ticket3.AddFooterLine("")
        ticket3.AddFooterLine("================================")
        ticket3.AddFooterLine("****Ticket sin Validez Fiscal***")
        ticket3.AddFooterLine("*****GRACIAS POR SU COMPRA******")

        Try
            ticket3.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Problema al Imprimir Ticket Fiscal : ", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub CancelarVenta(ByVal impresora As String)
        tckCancelarVenta.AddFooterLine1("================================")
        tckCancelarVenta.AddFooterLine1("********Venta Cancelada*********")
        Try
            tckCancelarVenta.PrintTicket(impresora)
        Catch ex As Exception
            MessageBox.Show("Problema al Imprimir Ticket Fiscal : ", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Module
