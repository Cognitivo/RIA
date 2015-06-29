Imports System.IO
Imports System.Net
Imports System.Net.Mime
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Module FileSepsa
    Dim TotalMontoIva5, TotalMontoIva10, TotalMontoExcento, TotIva5, TotIva10 As Integer
    Dim Body, PreviewFileName, PreviewFileHTML, HTMLProductos, HTMLFooter As String
    Dim MontoIva, PrecioUnit, PrecioTotal, SubTotal, TotalIva, Monto, MontoTotal As Integer
    Dim CodGNU, RucEmpresa, RucCliente, TipoIva, PorcIVA, DiasPagoCliente As String
    Dim CodigoProd, CantidadVenta, PrecioProd, Producto As String
    Dim IdentificationMSG, IdentificationTRA As String
    Private ser As BDConexión.BDConexion
    Private sqlc As New SqlConnection
    Dim f As New Funciones.Funciones
    Dim ItemProd As Integer
    Dim OrdCompra As Integer

    Sub New()
        ser = New BDConexión.BDConexion()
    End Sub

    Public Sub FileSepsaCreator(ByVal sPath As String, ByVal CodGNUCliente As String, ByVal CreationDateAndTime As String, ByVal DeliveryDate As String, ByVal CodVenta As Integer, ByVal DateVenta As Date, ByVal Identification As String)
        ItemProd = 0 : MontoIva = 0 : PrecioUnit = 0 : PrecioTotal = 0 : SubTotal = 0 : TotalIva = 0 : Monto = 0
        TotalMontoIva5 = 0 : TotalMontoIva10 = 0 : TotalMontoExcento = 0 : TotIva5 = 0 : TotIva10 = 0 : MontoTotal = 0

        'Obtenemos los datos de la Empresa
        CodGNU = f.FuncionTop1("CODGNU", "EMPRESA")
        RucEmpresa = f.FuncionTop1("RUCCONTRIBUYENTE", "EMPRESA")

        'Obtenemos los datos del Cliente
        RucCliente = f.FuncionConsultaString("RUC", "CLIENTES", "SEPSA", CodGNUCliente)
        DiasPagoCliente = f.FuncionConsultaString("DIASVENCIMIENTO", "CLIENTES", "SEPSA", CodGNUCliente)

        'Obtenemos la fecha actual para luego convertirla en formato SEPSA
        IdentificationMSG = "MSG-1-" & DateVenta.Year & DateVenta.Month & DateVenta.Day
        IdentificationTRA = "TRA-1-" & DateVenta.Year & DateVenta.Month & DateVenta.Day

        Identification = Identification & "-" & DateVenta.Year & DateVenta.Month & DateVenta.Day

        'Obtenemos el Nro de Oreden de Compra de la factura a Exportar
        OrdCompra = f.FuncionConsultaDecimal("CODORDCOMPRA", "VENTAS", "CODVENTA", CodVenta)

        Body = "<ns5:StandardBusinessDocument xmlns:ns2=""http://www.w3.org/2000/09/xmldsig#"" xmlns:ns4=""urn:ean.ucc:pay:2"" xmlns:ns3=""urn:ean.ucc:2"" xmlns:ns5=""http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader""> " & _
                "<ns5:StandardBusinessDocumentHeader>" & _
                "<ns5:HeaderVersion>1.0</ns5:HeaderVersion>" & _
                "<ns5:Sender>" & _
                "<ns5:Identifier Authority=""EAN.UCC"">" & CodGNU & "</ns5:Identifier>" & _
                "<ns5:ContactInformation>" & _
                "<ns5:Contact/>" & _
                "<ns5:EmailAddress/>" & _
                "<ns5:FaxNumber/>" & _
                "<ns5:TelephoneNumber/>" & _
                "<ns5:ContactTypeIdentifier>Seller</ns5:ContactTypeIdentifier>" & _
                "</ns5:ContactInformation>" & _
                "</ns5:Sender>" & _
                "<ns5:Receiver>" & _
                "<ns5:Identifier Authority=""EAN.UCC"">" & CodGNUCliente & "</ns5:Identifier>" & _
                "<ns5:ContactInformation>" & _
                "<ns5:Contact/>" & _
                "<ns5:EmailAddress/>" & _
                "<ns5:FaxNumber/>" & _
                "<ns5:TelephoneNumber/>" & _
                "<ns5:ContactTypeIdentifier>Buyer</ns5:ContactTypeIdentifier>" & _
                "</ns5:ContactInformation>" & _
                "</ns5:Receiver>" & _
                "<ns5:DocumentIdentification>" & _
                "<ns5:Standard>EAN.UCC</ns5:Standard>" & _
                "<ns5:TypeVersion>2.4</ns5:TypeVersion>" & _
                "<ns5:InstanceIdentifier></ns5:InstanceIdentifier>" & _
                "<ns5:Type>INVOICE</ns5:Type>" & _
                "<ns5:MultipleType>false</ns5:MultipleType>" & _
                "<ns5:CreationDateAndTime>" & CreationDateAndTime & "</ns5:CreationDateAndTime>" & _
                "</ns5:DocumentIdentification>" & _
                "</ns5:StandardBusinessDocumentHeader>" & _
                "<message>" & _
                "<entityIdentification>" & _
                "<uniqueCreatorIdentification>" & IdentificationMSG & "</uniqueCreatorIdentification>" & _
                "<contentOwner>" & _
                "<gln>" & CodGNU & "</gln>" & _
                "</contentOwner>" & _
                "</entityIdentification>" & _
                "<transaction>" & _
                "<entityIdentification>" & _
                "<uniqueCreatorIdentification>" & IdentificationTRA & "</uniqueCreatorIdentification>" & _
                "<contentOwner>" & _
                "<gln>" & CodGNU & "</gln>" & _
                "</contentOwner>" & _
                "</entityIdentification>" & _
                "<command>" & _
                "<documentCommand>" & _
                "<documentCommandHeader type=""ADD"">" & _
                "<entityIdentification>" & _
                "<uniqueCreatorIdentification>" & IdentificationTRA & "</uniqueCreatorIdentification>" & _
                "<contentOwner>" & _
                "<gln>" & CodGNU & "</gln>" & _
                "</contentOwner>" & _
                "</entityIdentification>" & _
                "</documentCommandHeader>" & _
                "<documentCommandOperand>" & _
                "<invoice documentStatus=""ORIGINAL"" creationDateTime=""" & CreationDateAndTime & """>" & _
                "<invoiceIdentification>" & _
                "<uniqueCreatorIdentification>" & Identification & "</uniqueCreatorIdentification>" & _
                "<contentOwner>" & _
                "<gln>" & CodGNU & "</gln>" & _
                "<additionalPartyIdentification>" & _
                "<additionalPartyIdentificationValue>" & RucEmpresa & "</additionalPartyIdentificationValue>" & _
                "<additionalPartyIdentificationType>DUNS</additionalPartyIdentificationType>" & _
                "</additionalPartyIdentification>" & _
                "</contentOwner>" & _
                "</invoiceIdentification>" & _
                "<invoiceCurrency>" & _
                "<currencyISOCode>PYG</currencyISOCode>" & _
                "</invoiceCurrency>" & _
                "<buyer>" & _
                "<partyIdentification>" & _
                "<gln>" & CodGNUCliente & "</gln>" & _
                "<additionalPartyIdentification>" & _
                "<additionalPartyIdentificationValue>" & RucCliente & "</additionalPartyIdentificationValue>" & _
                "<additionalPartyIdentificationType>DUNS</additionalPartyIdentificationType>" & _
                "</additionalPartyIdentification>" & _
                "</partyIdentification>" & _
                "</buyer>" & _
                "<seller>" & _
                "<partyIdentification>" & _
                "<gln>" & CodGNU & "</gln>" & _
                "<additionalPartyIdentification>" & _
                "<additionalPartyIdentificationValue>" & RucEmpresa & "</additionalPartyIdentificationValue>" & _
                "<additionalPartyIdentificationType>DUNS</additionalPartyIdentificationType>" & _
                "</additionalPartyIdentification>" & _
                "</partyIdentification>" & _
                "</seller>"

        'Obtenemos la lista de productos que corresponde a la venta a Exportar a SEPSA
        Dim objCommand As New SqlCommand

        Try
            ser.Abrir(sqlc)
            objCommand.CommandText = "SELECT dbo.VENTASDETALLE.CODMONEDA, dbo.VENTASDETALLE.IVA, dbo.VENTASDETALLE.CANTIDADVENTA, dbo.CODIGOS.CODIGO, " & _
                                     "dbo.VENTASDETALLE.PRECIOVENTALISTA, dbo.PRODUCTOS.DESPRODUCTO " & _
                                     "FROM dbo.VENTASDETALLE INNER JOIN dbo.CODIGOS ON dbo.VENTASDETALLE.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN " & _
                                     "dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO " & _
                                     "WHERE (dbo.VENTASDETALLE.CODVENTA = " & CodVenta & ")"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                HTMLProductos = ""
                Do While odrConfig.Read()
                    CodigoProd = odrConfig("CODIGO")
                    CantidadVenta = odrConfig("CANTIDADVENTA")
                    PrecioProd = odrConfig("PRECIOVENTALISTA")
                    TipoIva = odrConfig("IVA")
                    Producto = odrConfig("DESPRODUCTO")

                    ItemProd = ItemProd + 1

                    If TipoIva = 10 Then 'Iva 10
                        MontoIva = PrecioProd / 11
                        PorcIVA = "10.0000"

                        TotIva10 = TotIva10 + MontoIva
                        Monto = PrecioProd - MontoIva
                        TotalMontoIva10 = TotalMontoIva10 + Monto

                    ElseIf PorcIVA = 5 Then 'Iva 5
                        MontoIva = PrecioProd / 21
                        PorcIVA = "5.0000"

                        TotIva5 = TotIva5 + MontoIva
                        Monto = PrecioProd - MontoIva
                        TotalMontoIva10 = TotalMontoIva10 + Monto

                    ElseIf PorcIVA = 0 Then 'Excento
                        MontoIva = 0
                        PorcIVA = "0.0000"

                        Monto = PrecioProd - MontoIva
                        TotalMontoExcento = TotalMontoExcento + Monto
                    End If

                    PrecioUnit = PrecioProd - MontoIva 'Precio Unitario sin IVA
                    PrecioTotal = PrecioUnit * CantidadVenta
                    SubTotal = SubTotal + PrecioTotal
                    TotalIva = TotalIva + MontoIva

                    HTMLProductos = HTMLProductos + "<invoiceLineItem number=""" & ItemProd & """>" & _
                                   "<tradeItemIdentification>" & _
                                   "<gtin>" & CodigoProd & "</gtin>" & _
                                   "</tradeItemIdentification>" & _
                                   "<invoicedQuantity>" & _
                                   "<value>" & Replace(CantidadVenta, ",", ".") & "</value>" & _
                                   "<unitOfMeasure>" & _
                                   "<measurementUnitCodeValue>PCS</measurementUnitCodeValue>" & _
                                   "</unitOfMeasure>" & _
                                   "</invoicedQuantity>" & _
                                   "<transferOfOwnershipDate>" & DeliveryDate & "</transferOfOwnershipDate>" & _
                                   "<itemDescription>" & _
                                   "<language>" & _
                                   "<languageISOCode>SP</languageISOCode>" & _
                                   "</language>" & _
                                   "<text>" & Producto & "</text>" & _
                                   "</itemDescription>" & _
                                   "<itemPriceBaseQuantity>" & _
                                   "<value>" & Replace(PrecioUnit, ",", ".") & "</value>" & _
                                   "<unitOfMeasure>" & _
                                   "<measurementUnitCodeValue>PCS</measurementUnitCodeValue>" & _
                                   "</unitOfMeasure>" & _
                                   "</itemPriceBaseQuantity>" & _
                                   "<orderIdentification>" & _
                                   "<documentReference>" & _
                                   "<uniqueCreatorIdentification>" & OrdCompra & "</uniqueCreatorIdentification>" & _
                                   "</documentReference>" & _
                                   "</orderIdentification>" & _
                                   "<invoiceLineTaxInformation>" & _
                                   "<dutyTaxFeeType>VALUE_ADDED_TAX</dutyTaxFeeType>" & _
                                   "<taxableAmount>" & Replace(PrecioTotal, ",", ".") & "</taxableAmount>" & _
                                   "<taxAmount>" & Replace(MontoIva, ",", ".") & "</taxAmount>" & _
                                   "<extension>" & _
                                   "<rate xsi:type=""xs:string"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">" & PorcIVA & "</rate>" & _
                                   "<VATCategory xsi:type=""xs:string"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">STANDARD_RATE</VATCategory>" & _
                                   "</extension>" & _
                                   "</invoiceLineTaxInformation>" & _
                                   "</invoiceLineItem>"
                Loop

                MontoTotal = SubTotal + TotalIva

                HTMLProductos = HTMLProductos & "<invoiceTotals>" & _
                                "<totalInvoiceAmount>" & Replace(SubTotal, ",", "0") & "</totalInvoiceAmount>" & _
                                "<totalTaxAmount>" & Replace(TotalIva, ",", ".") & "</totalTaxAmount>" & _
                                "<taxSubTotal>" & _
                                "<dutyTaxFeeType>VALUE_ADDED_TAX</dutyTaxFeeType>" & _
                                "<taxableAmount>" & Replace(TotalMontoIva5, ",", ".") & "</taxableAmount>" & _
                                "<taxAmount>" & Replace(TotIva5, ",", ".") & "</taxAmount>" & _
                                "<extension>" & _
                                "<rate xsi:type=""xs:string"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">5.0000</rate>" & _
                                "<VATCategory xsi:type=""xs:string"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">STANDARD_RATE</VATCategory>" & _
                                "</extension>" & _
                                "</taxSubTotal>" & _
                                "<taxSubTotal>" & _
                                "<dutyTaxFeeType>VALUE_ADDED_TAX</dutyTaxFeeType>" & _
                                "<taxableAmount>" & Replace(TotalMontoIva10, ",", ".") & "</taxableAmount>" & _
                                "<taxAmount>" & Replace(TotIva10, ",", ".") & "</taxAmount>" & _
                                "<extension>" & _
                                "<rate xsi:type=""xs:string"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">10.0000</rate>" & _
                                "<VATCategory xsi:type=""xs:string"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">STANDARD_RATE</VATCategory>" & _
                                "</extension>" & _
                                "</taxSubTotal>" & _
                                "<taxSubTotal>" & _
                                "<dutyTaxFeeType>VALUE_ADDED_TAX</dutyTaxFeeType>" & _
                                "<taxableAmount>" & Replace(TotalMontoExcento, ",", ".") & "</taxableAmount>" & _
                                "<taxAmount>0.0</taxAmount>" & _
                                "<extension>" & _
                                "<rate xsi:type=""xs:string"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">0.0000</rate>" & _
                                "<VATCategory xsi:type=""xs:string"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">STANDARD_RATE</VATCategory>" & _
                                "</extension>" & _
                                "</taxSubTotal>" & _
                                "<totalInvoiceAmountPayable>" & Replace(MontoTotal, ",", ".") & "</totalInvoiceAmountPayable>" & _
                                "</invoiceTotals>" & _
                                "<paymentTerms paymentTermsEvent=""RECEIPT_OF_GOODS"" paymentTermsType=""BASIC_NET"">" & _
                                "<netPayment>" & _
                                "<paymentTimePeriod>" & _
                                "<timePeriodDue timePeriod=""DAYS"">" & _
                                "<value>" & DiasPagoCliente & "</value>" & _
                                "</timePeriodDue>" & _
                                "</paymentTimePeriod>" & _
                                "</netPayment>" & _
                                "</paymentTerms>"
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try

        HTMLFooter = "</invoice>" & _
                     "</documentCommandOperand>" & _
                     "</documentCommand>" & _
                     "</command>" & _
                     "</transaction>" & _
                     "</message>" & _
                     "</ns5:StandardBusinessDocument>"

        'Concatemos Body, Productos y Footer
        Body = Body + HTMLProductos + HTMLFooter

        PreviewFileName = sPath

        If Body <> "" Then
            PreviewFileHTML = "<?xml version=""1.0"" encoding=""ISO-8859-1"" standalone=""yes""?>" + Body
        End If

        Try
            My.Computer.FileSystem.WriteAllText(PreviewFileName, PreviewFileHTML, False)
        Catch ex As Exception
        End Try
    End Sub
End Module
