Imports System.Data.SqlClient
Imports System.IO
Imports Osuna.Utiles.Conectividad
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class Producto
    Dim ClickCabecera As Boolean
#Region "Fields"
    Dim dtEquipo As DataTable
    Dim banverifcheck As Boolean = True

    '#####################Codigo aleatorio###################################################################################
    Dim Aleatorio, Maximo, Minimo, CodigoExistente, CodigoPeseable As String
    'Dim anu As Integer
    Dim Bloqueado As Integer
    Dim CambiarEstado As Integer
    Private cmd As SqlCommand
    Dim permisonuevo As Integer
    Dim permisoeditarDatos As Integer
    Dim permisoeditarPrecio As Integer
    '########################################################################################################################
    Dim costomin As Boolean
    Dim LineaCodigo As Integer
    Dim Config1, Config2 As String

    '#################### Para los permisos de usuarios #####################################################################
    Dim dr As SqlDataReader
    Dim Editable As Integer
    Dim Existe As Integer

    '########################################################################################################################
    Dim f As New Funciones.Funciones
  
    '#####################Materia Prima######################################################################################
    Dim modificadetalle As Integer
    Private myTrans As SqlTransaction

    Dim Precio, StockMin, StockMax, CodProveedor, _
    CodCategoriaGlobal, CodMarcaGlobal, CodLineaGlobal, CodSucursal, CodMedidaGlobal, CodTipoIva, multiplemedida, Ubicacion As String

    Private ser As BDConexión.BDConexion
    Dim Servicios, ProductoProducido, Producto As Boolean
    Dim sql1, ubicacionarchivo As String
    Private sqlc As SqlConnection
    Dim Balanza As Integer
    Dim Bteditar, Btnuevo As Integer
    Dim permiso As Double
    Dim HayError, errorcodigo As Integer
    Dim vgPromocion As Boolean
    Dim VCodProducto As Integer
    Private objCommand As New SqlCommand
    Dim ProductoActivo As Integer
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
    Public Function EAN13(ByVal value As String) As String
        'If Regex.IsMatch(value, "^\\d{12}$") Then
        'Dim Unknown(,) As Integer
        Dim tableAB(,) As Integer = New Integer(,) {{0, 0, 0, 0, 0, 0}, {0, 0, 1, 0, 1, 1}, _
                                                    {0, 0, 1, 1, 0, 1}, {0, 0, 1, 1, 1, 0}, _
                                                    {0, 1, 0, 0, 1, 1}, {0, 1, 1, 0, 0, 1}, _
                                                    {0, 1, 1, 1, 0, 0}, {0, 1, 0, 1, 0, 1}, _
                                                    {0, 1, 0, 1, 1, 0}, {0, 1, 1, 0, 1, 0}}
        Dim result As String = value.Substring(0, 1)
        Dim first As Integer = Convert.ToInt32(result)
        Dim check As Integer = first
        Dim digit As Integer = 0
        Dim i As Integer = 1
        Dim r As Integer
        Do While (i <= 6)
            digit = Convert.ToInt32(value.Substring(i, 1))
            If i Mod 2 = 0 Then
                r = 1
            Else
                r = 3
            End If
            check = (check + (digit * (r)))
            'check = (check + (digit * ((i Mod 2) = 0)))
            result = (result + CType(ChrW((65 + (digit + (tableAB(first, (i - 1)) * 10)))), Char))
            i = (i + 1)
        Loop

        result = (result + "*")
        'Dim j As Integer = 7
        i = 7
        Do While (i < 12)
            digit = Convert.ToInt32(value.Substring(i, 1))
            If i Mod 2 = 0 Then
                r = 1
            Else
                r = 3
            End If
            check = (check + (digit * (r)))
            result = (result + CType(ChrW((97 + digit)), Char))
            i = (i + 1)
        Loop
        digit = ((10 - (check Mod 10)) Mod 10)
        result = (result + CType(ChrW((97 + digit)), Char))
        result = (result + "+")
        Return result
    End Function

    Private Sub ActualizaCodigos()
        Dim Desc1, Codigo, Estado, vencimiento, pesable As String
        Dim dgvCodCodigo As Integer
        Dim dgvCodRowCount = CodigosTradicionalGridView.RowCount
        Dim w As New Funciones.Funciones

        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim Concat As String = Today
        Dim Concatenar As String = Concat & " " + hora

        For i = 0 To dgvCodRowCount - 1
            If IsDBNull(CodigosTradicionalGridView.Rows(i).Cells("DESCODIGO1DataGridViewTextBoxColumn").Value) Then
                Desc1 = ""
            Else
                Desc1 = CodigosTradicionalGridView.Rows(i).Cells("DESCODIGO1DataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(CodigosTradicionalGridView.Rows(i).Cells("CODIGODataGridViewTextBoxColumn").Value) Then
                Codigo = ""
            Else
                Codigo = CodigosTradicionalGridView.Rows(i).Cells("CODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(CodigosTradicionalGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                dgvCodCodigo = 0
            Else
                dgvCodCodigo = CodigosTradicionalGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If

            If CmbVencimiento.Text = "Si" Then
                vencimiento = 1
            Else
                vencimiento = 0
            End If

            If CmbPesable.Text = "Si" Then
                pesable = 1
            Else
                pesable = 0
            End If

            If ChckBalanza.Checked = True Then
                Balanza = 1
            Else
                Balanza = 0
            End If

            Estado = Me.CodigosTradicionalGridView.Rows(i).Cells("EstadoCodigo").Value

            Try
                If Estado = 1 Then
                    sql1 = "insert into CODIGOS (DESCODIGO1, CODIGO, CODPRODUCTO, FECGRA,VENCIMIENTO,PESABLE,BALANZA)" & _
                            " VALUES ( '" & Replace(Desc1, "'", "''") & "', '" & Replace(Codigo, "'", "''") & "', " & _
                            "" & VCodProducto & ", CONVERT(DATETIME,'" & Concatenar & "',103)," & vencimiento & "," & pesable & "," & Balanza & ") "
                    cmd.CommandText = sql1
                    cmd.ExecuteNonQuery()
                ElseIf Estado = 2 Then
                    sql1 = "UPDATE CODIGOS SET DESCODIGO1 = '" & Replace(Desc1, "'", "''") & "', CODIGO = '" & Replace(Codigo, "'", "''") & "', CODPRODUCTO= " & VCodProducto & ", FECGRA =  CONVERT(DATETIME,'" & Concatenar & "',103)" & _
                        ", VENCIMIENTO = " & vencimiento & ", PESABLE = " & pesable & ", BALANZA = " & Balanza & " WHERE CODCODIGO= " & dgvCodCodigo & ""
                    cmd.CommandText = sql1
                    cmd.ExecuteNonQuery()
                ElseIf Estado = 3 Then
                    sql1 = "DELETE CODIGOS WHERE CODCODIGO= " & dgvCodCodigo & ""
                    cmd.CommandText = sql1
                    cmd.ExecuteNonQuery()
                End If

            Catch ex As Exception
                errorcodigo = 1
                Exit Sub
            End Try
        Next
    End Sub

    Private Sub ActualizaPrecios()
        ' Dim Codigo As String
        Dim dgvCodPrecio, Estado, CodTipoCliente, CodSucursal, CODMONEDA, Cantidad As Integer
        Dim dgvCodRowCount = PreciosGridView.RowCount
        Dim w As New Funciones.Funciones

        For i = 0 To dgvCodRowCount - 1
            If IsDBNull(PreciosGridView.Rows(i).Cells("CODPRECIO1").Value) Then
                dgvCodPrecio = 0
            Else
                dgvCodPrecio = PreciosGridView.Rows(i).Cells("CODPRECIO1").Value
            End If

            Precio = CDec(PreciosGridView.Rows(i).Cells("PRECIOVENTA1").Value)
            CodTipoCliente = PreciosGridView.Rows(i).Cells("CODTIPOCLIENTE1").Value
            CodSucursal = SucCodigo
            CODMONEDA = PreciosGridView.Rows(i).Cells("CODMONEDA1").Value

            If IsDBNull(PreciosGridView.Rows(i).Cells("CANTIDAD").Value) Then
                Cantidad = 0
            Else
                Cantidad = PreciosGridView.Rows(i).Cells("CANTIDAD").Value
            End If

            Precio = Funciones.Cadenas.QuitarCad(Precio, ".")
            Precio = Replace(Precio, ",", ".")

            Estado = Me.PreciosGridView.Rows(i).Cells("EstadoPrecio").Value
            sql1 = ""

            If Estado = 1 Then
                sql1 = "INSERT INTO PRECIO (CODTIPOCLIENTE, CODSUCURSAL, CODPRODUCTO, CODMONEDA, PRECIOVENTA, FECGRA, CANTIDAD) " & _
                        "VALUES ( " & CodTipoCliente & ", " & CodSucursal & ", " & VCodProducto & ", " & CODMONEDA & ", " & Precio & ", GETDATE(), " & Cantidad & ") "

                cmd.CommandText = sql1
                cmd.ExecuteNonQuery()

            ElseIf Estado = 2 Then
                sql1 = "UPDATE PRECIO SET CODTIPOCLIENTE = " & CodTipoCliente & " , CODPRODUCTO = " & VCodProducto & ", PRECIOVENTA = " & Precio & ", FECGRA = GETDATE(), CANTIDAD = " & Cantidad & "  WHERE CODPRECIO = " & dgvCodPrecio


                cmd.CommandText = sql1
                cmd.ExecuteNonQuery()

            ElseIf Estado = 3 Then
                sql1 = "DELETE PRECIO WHERE CODPRECIO = " & dgvCodPrecio

                cmd.CommandText = sql1
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub InsertarCodigos()
        Dim Desc1, Codigo, vencimiento, pesable As String
        Dim IndiceCodigo = CodigosTradicionalGridView.RowCount
        Dim w As New Funciones.Funciones

        If IndiceCodigo > 0 Then
            For IndiceCodigo = 1 To IndiceCodigo
                If IsDBNull(CodigosTradicionalGridView.Rows(IndiceCodigo - 1).Cells("DESCODIGO1DataGridViewTextBoxColumn").Value) Then
                    Desc1 = ""
                Else
                    Desc1 = CodigosTradicionalGridView.Rows(IndiceCodigo - 1).Cells("DESCODIGO1DataGridViewTextBoxColumn").Value
                End If
                If IsDBNull(CodigosTradicionalGridView.Rows(IndiceCodigo - 1).Cells("CODIGODataGridViewTextBoxColumn").Value) Then
                    Codigo = ""
                    'ERROR: NO PUEDE QUEDAR CODIGO VACIO
                    MessageBox.Show("Asegurese de Ingresar todos los códigos en el Detalle de Códigos", "POSEXPRESS")
                    Exit Sub
                Else
                    Codigo = CodigosTradicionalGridView.Rows(IndiceCodigo - 1).Cells("CODIGODataGridViewTextBoxColumn").Value
                End If

                If CmbVencimiento.Text = "Si" Then
                    vencimiento = 1
                Else
                    vencimiento = 0
                End If

                If CmbPesable.Text = "Si" Then
                    pesable = 1
                Else
                    pesable = 0
                End If

                If ChckBalanza.Checked = True Then
                    Balanza = 1
                Else
                    Balanza = 0
                End If

                Dim Estado As Integer = Me.CodigosTradicionalGridView.Rows(IndiceCodigo - 1).Cells("EstadoCodigo").Value

                If Estado = 1 Or Estado = 2 Then
                    sql1 = "insert into CODIGOS (DESCODIGO1, CODIGO, CODPRODUCTO, FECGRA,VENCIMIENTO,PESABLE,BALANZA)" & _
                        " VALUES ( '" & Replace(Desc1, "'", "''") & "', '" & Replace(Codigo, "'", "''") & "', " & _
                        "" & VCodProducto & ", " & Today & "," & vencimiento & "," & pesable & "," & Balanza & ") "
                    cmd.CommandText = sql1
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If
    End Sub

    Private Sub InsertarPrecios()
        Dim c As Integer = PreciosGridView.RowCount
        'Dim w As New Funciones.Funciones
        Dim CodTipoCliente, Precio, CodMoneda, Cantidad As String

        If SucCodigo = Nothing Then
            SucCodigo = 1
        End If

        For c = 1 To c
            Precio = CDec(PreciosGridView.Rows(c - 1).Cells("PRECIOVENTA1").Value)
            CodTipoCliente = PreciosGridView.Rows(c - 1).Cells("CODTIPOCLIENTE1").Value
            CodSucursal = SucCodigo
            CodMoneda = PreciosGridView.Rows(c - 1).Cells("CODMONEDA1").Value

            If IsDBNull(PreciosGridView.Rows(c - 1).Cells("CANTIDAD").Value) Then
                Cantidad = 0
            Else
                Cantidad = PreciosGridView.Rows(c - 1).Cells("CANTIDAD").Value
            End If

            Precio = Funciones.Cadenas.QuitarCad(Precio, ".")
            Precio = Replace(Precio, ",", ".")

            sql1 = ""
            sql1 = "INSERT INTO PRECIO (CODTIPOCLIENTE, CODSUCURSAL, CODPRODUCTO, CODMONEDA, PRECIOVENTA, FECGRA, CANTIDAD) " & _
            "VALUES ( " & CodTipoCliente & ", " & CodSucursal & ", " & VCodProducto & ", " & CodMoneda & ", " & Precio & ", GETDATE(), " & Cantidad & ") "
            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub ActualizaProducto()
        Dim StockMinimo, StockMaximo As Double
        Dim v_producto As Integer

        If TipoProductoComboBox.Text = "Producto" Then
            v_producto = 1
        ElseIf TipoProductoComboBox.Text = "Servicio" Then
            v_producto = 0
        ElseIf TipoProductoComboBox.Text = "Producto Producido" Then
            v_producto = 2
        ElseIf TipoProductoComboBox.Text = "Materia Prima" Then
            v_producto = 3
        ElseIf TipoProductoComboBox.Text = "Combo" Then
            v_producto = 4
        ElseIf TipoProductoComboBox.Text = "Descuento" Then
            v_producto = 5
        End If

        If StockMinimoTextBox.Text = "" Then
            StockMinimo = 0
        Else
            StockMinimo = CDec(StockMinimoTextBox.Text)
        End If

        If StockMaximoTextBox.Text = "" Then
            StockMaximo = 0
        Else
            StockMaximo = CDec(StockMaximoTextBox.Text)
        End If

        Dim Promocion As Integer = 0

        If vgPromocion = False Then
            Promocion = 0
        ElseIf vgPromocion = True Then
            Promocion = 1
        End If

        If ubicacionarchivo <> "" Then
            actualizaimagen(VCodProducto)
        End If

        sql1 = ""
        sql1 = "update PRODUCTOS set " & _
        "CODFAMILIA =" & CodCategoriaGlobal & "," & _
        "CODLINEA = " & CodMarcaGlobal & ", " & _
        "CODRUBRO = " & CodLineaGlobal & "," & _
        "DESPRODUCTO = '" & Replace(DesProductoTextBox.Text, "'", "''") & _
        "' , ESTADO = " & ProductoActivo & " , CODIVA = " & CodTipoIva & "," & _
        "CODMEDIDA=" & CodMedidaGlobal & ",  " & _
        "STOCKMINIMO=" & Replace(StockMinimo, ",", ".") & ", " & _
        "STOCKMAXIMO=" & Replace(StockMaximo, ",", ".") & ", " & _
        "SERVICIO=" & v_producto & " , PROMOCION = " & Promocion & "," & _
        "CODPROVEEDOR =" & CodProveedor & ",  " & _
        "ESPECIFICACIONES ='" & tbxEspecificaciones.Text & "' , " & _
        "PRODUCTO=" & v_producto & ", " & _
        "IDMARCA ='" & cbxMarca.SelectedValue & "'," & _
        "IDEQUIPO ='" & cbxEquipo.SelectedValue & "'," & _
        "UBICACION ='" & Ubicacion & "'" & _
        "where CODPRODUCTO = " & VCodProducto & ""

        For Each Row As DataRow In DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE.Select(Nothing, Nothing, DataViewRowState.Added)
            Row("IDPRODUCTO") = VCodProducto
        Next

        PRODUCTO_EQUIPO_REL_SIMPLETableAdapter.Update(DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE)



        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub actualizaimagen2(ByVal codproducto As Integer)
        Dim sql As String = "UPDATE PRODUCTOS Set IMAGENPRODUCTO=@IMAGEN WHERE CODPRODUCTO=" & codproducto & ""
        Dim cmd As New SqlCommand(sql, sqlc)
        cmd.Transaction = myTrans
        Dim ms As New MemoryStream()
        pbxImagen.Image.Save(ms, pbxImagen.Image.RawFormat)
        Dim data As Byte() = ms.GetBuffer()
        Dim p As New SqlParameter("@IMAGEN", SqlDbType.Image)
        p.Value = data
        cmd.Parameters.Add(p)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub actualizaimagen(ByVal codproducto As Integer)
        Try
            Dim sql As String

            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(ubicacionarchivo, IO.FileMode.Open, IO.FileAccess.Read)

            Dim Data() As Byte = New [Byte](fs.Length) {}
            fs.Read(Data, 0, fs.Length)

            Dim NewImage As Byte()
            NewImage = GetResizedImage(Data, 640, 480)

            sql = "UPDATE PRODUCTOS Set IMAGENPRODUCTO=@img WHERE CODPRODUCTO=" & codproducto & ""
            Dim cmd As New SqlCommand(sql)

            cmd.Connection = ser.Abrir
            cmd.Parameters.AddWithValue("@img", NewImage)
            cmd.ExecuteNonQuery()

            fs.Close()
            MsgBox("The Picture has been saved")
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetResizedImage(ByVal Data As Byte(), ByVal NewWidth As Integer, ByVal NewHeight As Integer) As Byte()
        Try
            Dim ms As New IO.MemoryStream(Data)
            Dim bmp As New Bitmap(New Bitmap(ms), NewWidth, NewHeight)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(bmp, 0, 0, NewWidth, NewHeight)
            Dim NewImageStream As New IO.MemoryStream
            bmp.Save(NewImageStream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Return NewImageStream.ToArray
        Catch
            Throw
        End Try
    End Function

    Public Function ImageResize(ByVal strImageSrcPath As String _
                          , ByVal strImageDesPath As String _
                          , Optional ByVal intWidth As Integer = 0 _
                          , Optional ByVal intHeight As Integer = 0) As String

        If System.IO.File.Exists(strImageSrcPath) = False Then
            Return "0"
            Exit Function
        End If

        Dim objImage As System.Drawing.Image = System.Drawing.Image.FromFile(strImageSrcPath)

        If intWidth > objImage.Width Then intWidth = objImage.Width
        If intHeight > objImage.Height Then intHeight = objImage.Height
        If intWidth = 0 And intHeight = 0 Then
            intWidth = objImage.Width
            intHeight = objImage.Height
        ElseIf intHeight = 0 And intWidth <> 0 Then
            intHeight = Fix(objImage.Height * intWidth / objImage.Width)
        ElseIf intWidth = 0 And intHeight <> 0 Then
            intWidth = Fix(objImage.Width * intHeight / objImage.Height)
        End If

        Dim imgOutput As New Bitmap(objImage, intWidth, intHeight)
        Dim imgFormat = objImage.RawFormat

        objImage.Dispose()
        objImage = Nothing

        If strImageSrcPath = strImageDesPath Then System.IO.File.Delete(strImageSrcPath)
        ' send the resized image to the viewer
        imgOutput.Save(strImageDesPath, imgFormat)
        imgOutput.Dispose()

        Return strImageDesPath

    End Function
    Private Sub ActualizaProductoAuditoria()
        Dim w As New Funciones.Funciones
        Dim CodAutitoria As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql1 = ""
        sql1 = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) values (" & CodAutitoria & ", " & EmpCodigo & ", 'PRODUCTOS', '" & CodAutitoria & "', 'ACTUALIZACION EN LA TABLA PRODUCTOS', CONVERT(DATETIME, '" & Today & "', 103), '" & UsuDescripcion & "', '" & UsuNivel & "', 0, 1, 0)"
        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AgregarPrecioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarPrecioButton.Click
        'Dim w As New Funciones.Funciones

        'LISTA DE PRECIO
        If TipoClieComboBox.Text = "" Then
            MessageBox.Show("Elija el Tipo de Cliente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TipoClieComboBox.Focus()
            Exit Sub
        End If
        'MONEDA
        If CbxMoneda.Text = "" Then
            MessageBox.Show("Elija una moneda", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbxMoneda.Focus()
            Exit Sub
        End If
        'PRECIO
        'valida el valor en costo
        If String.IsNullOrEmpty(PrecioTxtMoneda.Text) Then
            MessageBox.Show("Ingrese el precio para el nuevo detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PrecioTxtMoneda.Focus()
            Exit Sub
        Else
            If CDec(PrecioTxtMoneda.Text) = 0 Then
                MessageBox.Show("Ingrese un precio mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PrecioTxtMoneda.Focus()
                Exit Sub
            End If
        End If
        'CANTIDAD
        If Trim(tbxCant.Text) = "" Then
            MessageBox.Show("Ingrese la Cantidad de Producto de la Lista de Precio", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxCant.Focus()
            Exit Sub
        End If
        '###########################VALIDAMOS QUE NO SE REPITAN LOS PRECIOS#########################
        'LISTA DE PRECIOS
        Dim BanderitaTipoCliente As Integer
        BanderitaTipoCliente = 0

        Dim CodTipocliente As Integer = TipoClieComboBox.SelectedValue

        Dim x As Integer = PreciosGridView.RowCount
        For x = 1 To x
            If IsDBNull(PreciosGridView.Rows(x - 1).Cells("CODTIPOCLIENTE1").Value) Then
            Else
                If CodTipocliente = PreciosGridView.Rows(x - 1).Cells("CODTIPOCLIENTE1").Value Then
                    BanderitaTipoCliente = 1
                End If
            End If

            If BanderitaTipoCliente = 1 Then
                MessageBox.Show("El Precio ya se encuentra para este Producto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TipoClieComboBox.Focus()
                Exit Sub
            End If
        Next
        '###############################################################################################

        'AGREGAMOS A LA GRILLA
        If SucCodigo = Nothing Then
            SucCodigo = 1
        End If
        If UsuCodigo = Nothing Then
            UsuCodigo = 1
        End If
        If EmpCodigo = Nothing Then
            EmpCodigo = 1
        End If


        PRECIOBindingSource.AddNew()
        Dim c As Integer = PreciosGridView.RowCount

        Dim Porcentaje As Integer = f.FuncionConsultaDecimal("PORCENTAJE", "TIPOCLIENTE", "CODTIPOCLIENTE", TipoClieComboBox.SelectedValue)
        Dim VarAux As String = PrecioTxtMoneda.Text
        Dim Resultado As Decimal

        If Porcentaje <> 0 Then
            Resultado = (VarAux + ((Porcentaje * VarAux) / 100))
        Else
            Resultado = PrecioTxtMoneda.Text
        End If

        If c > 0 Then
            PreciosGridView.Rows(c - 1).Cells("CODTIPOCLIENTE1").Value = TipoClieComboBox.SelectedValue
            '  PreciosGridView.Rows(c - 1).Cells("CODSUCURSAL1").Value = 
            PreciosGridView.Rows(c - 1).Cells("PRECIOVENTA1").Value = Resultado
            PreciosGridView.Rows(c - 1).Cells("CODMONEDA1").Value = CbxMoneda.SelectedValue
            PreciosGridView.Rows(c - 1).Cells("CODPRODUCTO1").Value = VCodProducto
            PreciosGridView.Rows(c - 1).Cells("DESMONEDA1").Value = CbxMoneda.Text
            PreciosGridView.Rows(c - 1).Cells("EstadoPrecio").Value = 1
            PreciosGridView.Rows(c - 1).Cells("DESTIPOCLIENTE1").Value = TipoClieComboBox.Text
            PreciosGridView.Rows(c - 1).Cells("CANTIDAD").Value = tbxCant.Text
        End If

        TipoClieComboBox.Text = "" : CbxMoneda.Text = "" : PrecioTxtMoneda.Text = "" : tbxCant.Text = "1"
        TipoClieComboBox.Focus()
    End Sub
    Private Sub tbxCant_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxCant.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(tbxCant.Text, "^\d*$") Then
            tbxCant.Text = tbxCant.Text.Remove(tbxCant.Text.Length - 1)
            tbxCant.SelectionStart = tbxCant.Text.Length
        End If
    End Sub
    Private Sub BuscaProductoTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscaProductoTextBox.GotFocus
        'Me.PRODUCTOSTableAdapter.Fill(Me.DsProductos.PRODUCTOS, "%")
        BuscaProductoTextBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub BuscaProductoTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscaProductoTextBox.LostFocus
        BuscaProductoTextBox.BackColor = Color.Tan
    End Sub

    Private Sub BuscaProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscaProductoTextBox.TextChanged
        'If BuscaProductoTextBox.Text = "" Or BuscaProductoTextBox.Text = Nothing Then
        '    PRODUCTOSTableAdapter.Fill(Me.DsProductos.PRODUCTOS, "%")
        '    Exit Sub
        'End If

        'PRODUCTOSTableAdapter.FillBy(Me.DsProductos.PRODUCTOS, "%")
        'PRODUCTOSBindingSource.Filter = "DESPRODUCTO  LIKE '%" & BuscaProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscaProductoTextBox.Text & "%' OR DESMARCA LIKE '%" & BuscaProductoTextBox.Text & "%' OR DESEQUIPO LIKE '%" & BuscaProductoTextBox.Text & "%' OR DESCODIGO1 LIKE '%" & BuscaProductoTextBox.Text & "%'"
        'If ProductosGridView.Rows.Count = 0 Then
        '    PRODUCTOSTableAdapter.Fill(Me.DsProductos.PRODUCTOS, "%")
        '    PRODUCTOSBindingSource.Filter = "DESPRODUCTO  LIKE '%" & BuscaProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscaProductoTextBox.Text & "%'"

        'End If

        Dim filtro As String = "DESPRODUCTO  LIKE '%" & BuscaProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscaProductoTextBox.Text & "%' OR DESMARCA LIKE '%" & BuscaProductoTextBox.Text & "%' OR DESEQUIPO LIKE '%" & BuscaProductoTextBox.Text & "%' OR DESCODIGO1 LIKE '%" & BuscaProductoTextBox.Text & "%'"

        DsProductos.PRODUCTOS.DefaultView.RowFilter = filtro

        PRODUCTOSBindingSource.DataSource = DsProductos.PRODUCTOS.DefaultView

        If ProductosGridView.RowCount = 0 Then
            PictureBoxEliminar.Enabled = False
            PictureBoxEliminar.Image = My.Resources.DeleteOff
            PictureBoxEliminar.Cursor = Cursors.Arrow
            PictureBoxModifica.Enabled = False
            PictureBoxModifica.Image = My.Resources.EditOff
            PictureBoxModifica.Cursor = Cursors.Arrow
        Else
            PictureBoxEliminar.Enabled = True
            PictureBoxEliminar.Image = My.Resources.Delete
            PictureBoxEliminar.Cursor = Cursors.Hand
            PictureBoxModifica.Enabled = True
            PictureBoxModifica.Image = My.Resources.Edit
            PictureBoxModifica.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub Cancelar()
        PRODUCTOSBindingSource.CancelEdit()
        Dim Indice As Integer = PRODUCTOSBindingSource.Position
        PRODUCTOSTableAdapter.Fill(DsProductos.PRODUCTOS, "%")
        PRODUCTOSBindingSource.Position = Indice
        DeshabilitaControles()
    End Sub

    Private Sub CategoriaComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles CategoriaComboBox.GotFocus
        CategoriaComboBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub UbicacionTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles UbicacionTextBox.GotFocus
        UbicacionTextBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub CategoriaComboBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CategoriaComboBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            MarcaComboBox.Focus()
        End If
    End Sub

    Private Sub CategoriaComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CategoriaComboBox.KeyPress
        If Bloqueado = 1 Then
            Exit Sub
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 45 Then
            If CategoriaComboBox.SelectedValue = Nothing Then
                Exit Sub
            End If
            If MsgBox("Va a borrar una categoria, esta seguro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.No Then
                ' DemandadoBindingSource.CancelEdit()
            Else
                Try

                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "EliminaCategoria")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans



                    myTrans.Commit()
                    FAMILIATableAdapter.Fill(DsProductos.FAMILIA)
                Catch ex As SqlException
                    Try
                        myTrans.Rollback("EliminaCategoria")
                    Catch
                    End Try

                    Dim NroError As Integer = ex.Number
                    Dim Mensaje As String = ex.Message
                    If NroError = 547 Then
                        MessageBox.Show("La Categoría que desea eliminar tiene relacion con otra tabla del Sistema", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Problema al Eliminar los Datos: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Finally
                    sqlc.Close()
                End Try

            End If
            If KeyAscii = 13 Then
                e.Handled = True
                MarcaComboBox.Focus()
            End If
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CategoriaComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles CategoriaComboBox.LostFocus
        CategoriaComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub DeshabilitaControles()

        PictureBoxNuevo.Enabled = True
        PictureBoxNuevo.Image = My.Resources.New_
        PictureBoxNuevo.Cursor = Cursors.Hand
        PictureBoxEliminar.Enabled = True
        PictureBoxEliminar.Image = My.Resources.Delete
        PictureBoxEliminar.Cursor = Cursors.Hand
        PictureBoxModifica.Enabled = True
        PictureBoxModifica.Image = My.Resources.Edit
        PictureBoxModifica.Cursor = Cursors.Hand

        PictureBoxGuardar.Enabled = False
        PictureBoxGuardar.Image = My.Resources.SaveOff
        PictureBoxGuardar.Cursor = Cursors.Arrow
        PictureBoxCancelar.Enabled = False
        PictureBoxCancelar.Image = My.Resources.SaveCancelOff
        PictureBoxCancelar.Cursor = Cursors.Arrow

        BuscaProductoTextBox.Enabled = True

        'Tab1
        DesProductoTextBox.Enabled = False
        'PanelPrincipal.Enabled = False
        PanelDetalles.Enabled = False
        pnlCodigoBarra.Enabled = False
        TipoClieComboBox.Enabled = False
        'MONEDA
        CbxMoneda.Enabled = False
        PrecioTxtMoneda.Enabled = False
        tbxCant.Enabled = False
        AgregarPrecioButton.Enabled = False
        ElimPrecioButton.Enabled = False
        txtxcaja.Enabled = False
        PreciosGridView.Enabled = True
        CategoriaComboBox.Enabled = False
        LineaComboBox.Enabled = False
        MarcaComboBox.Enabled = False

        CmbPesable.DisplayMember = "No"
        pbxImagen.Enabled = False
        pbxSinImagen.Enabled = False

        PictureBoxActivo.Enabled = False

        ProductosGridView.Enabled = True
        ProductosGridView.Focus()
        'Botonera
        Editable = 0
        Bloqueado = 1

    End Sub

    Private Sub DesProductoTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles DesProductoTextBox.GotFocus
        DesProductoTextBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub DesProductoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DesProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            CategoriaComboBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub EimPrecioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElimPrecioButton.Click
        Dim CRDGV As Integer = Me.PreciosGridView.CurrentRow.Index
        Try
            PreciosGridView.CurrentRow.Cells("EstadoPrecio").Value = 3
            Me.PreciosGridView.Item(4, CRDGV).Style.BackColor = Color.Pink
            Me.PreciosGridView.Item(5, CRDGV).Style.BackColor = Color.Pink
            Me.PreciosGridView.Item(6, CRDGV).Style.BackColor = Color.Pink
            Me.PreciosGridView.Item(7, CRDGV).Style.BackColor = Color.Pink
            Me.PreciosGridView.Item(9, CRDGV).Style.BackColor = Color.Pink
            Me.PreciosGridView.CurrentRow.Cells("DESTIPOCLIENTE1").Value = "Precio para Eliminar"
            Me.PreciosGridView.CurrentRow.Cells("CODTIPOCLIENTE1").Value = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EliminaCabeceraProducto()
        sql1 = ""
        sql1 = " DELETE FROM PRODUCTOS " & _
        " WHERE CODPRODUCTO= '" & VCodProducto & "'"
        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
    End Sub


    Private Sub EliminaCodigos()
        sql1 = ""
        sql1 = " DELETE FROM CODIGOS" & _
        " WHERE CODPRODUCTO= " & VCodProducto & ""
        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminaPrecios()
        sql1 = ""
        sql1 = " DELETE FROM PRECIO " & _
        " WHERE CODPRODUCTO= '" & VCodProducto & "'"
        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminaProductoAuditoria()
        Dim w As New Funciones.Funciones
        Dim CodAutitoria As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql1 = ""
        sql1 = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) values (" & CodAutitoria & ", " & EmpCodigo & ", 'PRODUCTOS', '" & CodAutitoria & "', 'ELIMINACION EN LA TABLA PRODUCTOS', CONVERT(DATETIME, '" & Today & "', 103), '" & UsuDescripcion & "', '" & UsuNivel & "', 0, 0, 1)"
        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
    End Sub


    Private Sub EliminarCodigoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarCodigoButton.Click
        Dim w As New Funciones.Funciones
        Dim c As Integer = CodigosTradicionalGridView.RowCount

        If CodigosTradicionalGridView.RowCount = 0 Then
            Exit Sub
        End If

        Dim CRDGV As Integer = Me.CodigosTradicionalGridView.CurrentRow.Index
        Me.CodigosTradicionalGridView.CurrentRow.Cells("EstadoCodigo").Value = 3 'Eliminar/Delete
        Me.CodigosTradicionalGridView.Item(2, CRDGV).Style.BackColor = Color.Pink
        Me.CodigosTradicionalGridView.Item(1, CRDGV).Style.BackColor = Color.Pink
        Me.CodigosTradicionalGridView.CurrentRow.Cells("DESCODIGO1DataGridViewTextBoxColumn").Value = "Este Codigo sera Eliminado"

        '  CodigosTradicionalGridView.Rows(CRDGV).Visible = False
    End Sub

    Private Sub EliminarProducto()
        If MessageBox.Show("¿Esta seguro que quiere eliminar el Producto?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        CambiarEstado = 0
        '###########VALIDAMOS QUE NO TENGA STOCK############################
        Dim ExisteStock As Integer
        Dim w As New Funciones.Funciones

        ExisteStock = w.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO = " & VCodProducto & " AND STOCKACTUAL > ", 1)

        If ExisteStock > 0 Then
            MessageBox.Show("El Producto tiene existencia en Stock y no puede eliminarse", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim transaction As SqlTransaction = Nothing
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            EliminaCodigos()
            EliminaPrecios()
            EstadoProducto()

            '########AUDITORIA########################
            EliminaProductoAuditoria()
            '########################################

            myTrans.Commit()
            PRODUCTOSTableAdapter.Fill(DsProductos.PRODUCTOS, "%")

        Catch ex As SqlException
            Try
                myTrans.Rollback("Eliminar")
            Catch
            End Try

            Dim NroError As Integer = ex.Number
            Dim Mensaje As String = ex.Message

            If NroError = 547 Then
                CambiarEstado = 1
                MessageBox.Show("El Producto que desea eliminar tiene relacion otra tabla del Sistema, elimine primero la otra relación", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Ocurrió un error al tratar de Eliminar el Producto" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Finally
            sqlc.Close()
        End Try
        DeshabilitaControles()
    End Sub

    Private Sub EstadoProducto()
        Try
            sql1 = ""
            sql1 = "DELETE PRODUCTOS WHERE CODPRODUCTO = " & VCodProducto & ""
            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub GeneraCodigodeBarra()
        Try
            'Generacion del Codigo de Barra Formato EAN13 
            Dim CodPais As String
            Dim w As New Funciones.Funciones
            Dim tamanho As Integer
            Dim result As String
            Dim first As Integer
            Dim check As Integer
            Dim digit As Integer
            Dim i As Integer
            Dim r As Integer

            CodPais = "569"  'Colocamos el codigo del pais correspondiente a Iceland , considreando que este pais no vende a Paraguay

            Aleatorio = "000000001"   'Debemos generar 9 digitos de forma aleatoria, estos digitos corresponden a el codigo del producto y fabricante
            Minimo = "1"
            Maximo = "999999999"
            CodigoExistente = 1 'Para que siempre entre al ciclo la primera ves

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
                CodigoExistente = w.FuncionConsultaString("CODIGO", "CODIGOS", "CODIGO", Aleatorio)

            Loop

            CodigoBarraTextBox.Text = Aleatorio
        Catch ex As Exception
            MessageBox.Show("Error al Generará el Código Aleatorio", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub GenerarCodButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarCodButton.Click
        If ChckBalanza.Checked = False Then
            GeneraCodigodeBarra()
        End If
        DesCodigoTextBox.Focus()
    End Sub

    Private Sub GenerarCodigoPesable()
        Dim CodCodigoActual As Integer
        Dim CodigoExistente As Integer = 1
        Dim d As Integer
        Dim w As New Funciones.Funciones


        Dim Desc1, vencimiento, pesable As String
        Dim IndiceCodigo = CodigosTradicionalGridView.RowCount

        Desc1 = "" : vencimiento = "" : pesable = ""

        If CmbPesable.Text = "Si" Then
            CodigoPeseable = "20"
        Else
            CodigoPeseable = "24"
        End If

        If ChckBalanza.Checked = True Then
            Balanza = 1
            If Me.CmbVencimiento.Text = "Si" Then
                vencimiento = "1"
            Else
                vencimiento = "0"
            End If

            If Me.CmbPesable.Text = "Si" Then
                pesable = "1"
            Else
                pesable = "0"
            End If
        End If

        d = CodigosTradicionalGridView.Rows.Count
        CodCodigoActual = f.Maximo("CODCODIGO", "CODIGOS")
        CodCodigoActual = CodCodigoActual + 1

        If d = 0 Then
            If CodCodigoActual.ToString.Count = 1 Then
                CodigoPeseable = CodigoPeseable + "0000" + CodCodigoActual.ToString
            ElseIf CodCodigoActual.ToString.Count = 2 Then
                CodigoPeseable = CodigoPeseable + "000" + CodCodigoActual.ToString
            ElseIf CodCodigoActual.ToString.Count = 3 Then
                CodigoPeseable = CodigoPeseable + "00" + CodCodigoActual.ToString
            ElseIf CodCodigoActual.ToString.Count = 4 Then
                CodigoPeseable = CodigoPeseable + "0" + CodCodigoActual.ToString
            ElseIf CodCodigoActual.ToString.Count = 5 Then
                CodigoPeseable = CodigoPeseable + CodCodigoActual.ToString
            End If
        Else

            Dim retorna1, retorna2 As Integer

            Do
                CodCodigoActual = CodCodigoActual + 1
                retorna2 = 0
                retorna1 = 0
                For i = 0 To d - 1
                    If CodCodigoActual = CInt(CodigosTradicionalGridView.Rows(i).Cells("CODIGODataGridViewTextBoxColumn").Value.ToString.Substring(3)) Then
                        retorna1 = 1
                    Else
                        retorna2 = 1
                    End If

                Next
            Loop Until retorna2 = 1 And retorna1 = 0

            If CodCodigoActual.ToString.Count = 1 Then
                CodigoPeseable = CodigoPeseable + "0000" + CodCodigoActual.ToString
            ElseIf CodCodigoActual.ToString.Count = 2 Then
                CodigoPeseable = CodigoPeseable + "000" + CodCodigoActual.ToString
            ElseIf CodCodigoActual.ToString.Count = 3 Then
                CodigoPeseable = CodigoPeseable + "00" + CodCodigoActual.ToString
            ElseIf CodCodigoActual.ToString.Count = 4 Then
                CodigoPeseable = CodigoPeseable + "0" + CodCodigoActual.ToString
            ElseIf CodCodigoActual.ToString.Count = 5 Then
                CodigoPeseable = CodigoPeseable + CodCodigoActual.ToString
            End If
        End If

        'Verificamos si el codigo de barra ya existe en la base de datos
        CodigoExistente = w.FuncionConsultaString("CODIGO", "CODIGOS", "CODIGO", CodigoPeseable)
        If CodigoExistente = 0 Then
            sql1 = "insert into CODIGOS (DESCODIGO1, CODIGO, CODPRODUCTO, FECGRA,VENCIMIENTO,PESABLE,BALANZA)" & _
                      " VALUES ('" & Replace(Desc1, "'", "''") & "', '" & Replace(CodigoPeseable, "'", "''") & "', " & _
                      "" & VCodProducto & ", " & Today & "," & vencimiento & "," & pesable & "," & Balanza & ") "
            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
        End If
        CodigoBarraTextBox.Text = CodigoPeseable


    End Sub

    Private Sub GUARDARPRODUCTO()

        barProductos.Value = 20
        'Recorre
        If CategoriaComboBox.SelectedValue = Nothing Then
            CodCategoriaGlobal = "NULL"
        Else
            CodCategoriaGlobal = CategoriaComboBox.SelectedValue
        End If
        If MarcaComboBox.SelectedValue = Nothing Then
            CodMarcaGlobal = "NULL"
        Else
            CodMarcaGlobal = MarcaComboBox.SelectedValue
        End If
        If LineaComboBox.SelectedValue = Nothing Then
            CodLineaGlobal = "NULL"
        Else
            CodLineaGlobal = LineaComboBox.SelectedValue
        End If
        If MedidaComboBox.SelectedValue = Nothing Then
            CodMedidaGlobal = "NULL"
        Else
            CodMedidaGlobal = MedidaComboBox.SelectedValue
        End If
        If TipoIVAComboBox.SelectedValue = Nothing Then
            CodTipoIva = "NULL"
        Else
            CodTipoIva = TipoIVAComboBox.SelectedValue
        End If

        If StockMaximoTextBox.Text = "" Then
            StockMax = "0"
        Else
            StockMax = Funciones.Cadenas.QuitarCad(StockMaximoTextBox.Text, ".")
            StockMax = Replace(StockMax, ",", ".")
        End If
        If StockMinimoTextBox.Text = "" Then
            StockMin = "0"
        Else
            StockMin = Funciones.Cadenas.QuitarCad(StockMinimoTextBox.Text, ".")
            StockMin = Replace(StockMin, ",", ".")
        End If


        If cbxProveedor.Text = "" Then
            CodProveedor = "NULL"
        Else
            CodProveedor = cbxProveedor.SelectedValue
        End If

        If UbicacionTextBox.Text = "" Then
            Ubicacion = ""
        Else
            Ubicacion = UbicacionTextBox.Text
        End If

        barProductos.Value = 50

        'si quiere guardar con algun detalle incompleto
        Dim w As New Funciones.Funciones
        Dim transaction As SqlTransaction = Nothing

        '######################################################################

        If Bteditar = 1 Then
            '###################################################################
            'ACTUALIZAR: si existe el codigo de cliente actualiza
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaProducto()
                'If TipoProductoComboBox.Text = "Producto" Or TipoProductoComboBox.Text = "Producto Producido" Or TipoProductoComboBox.Text = "Materia Prima" Then
                errorcodigo = 0
                ActualizaCodigos()
                ' End If
                If errorcodigo = 0 Then
                    ActualizaPrecios()
                    '####AUDITORIA##############
                    ActualizaProductoAuditoria()
                    '##########################

                    myTrans.Commit()

                    barProductos.Value = 100
                End If
                If errorcodigo = 1 Then
                    MessageBox.Show("No puede eliminar el Codigo del Producto, intente Modificar", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                myTrans.Rollback("Actualizar")
                MessageBox.Show("Ocurrio un error al intentar actualizar el Producto" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                sqlc.Close()

            End Try
            'DeshabilitaControles()
        Else
            '############################################################################
            'INSERTAR: si el codigo es nuevo inserta
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaProducto()

                If ChckBalanza.Checked = True Then
                    GenerarCodigoPesable()
                Else
                    InsertarCodigos()
                End If

                InsertarPrecios()

                '####AUDITORIA##############
                InsertaProductoAuditoria()
                '##########################

                myTrans.Commit()

                barProductos.Value = 100
            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error al insertar el Producto", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                sqlc.Close()
            End Try

        End If

    End Sub

    Private Sub HabilitaControles()
        PictureBoxNuevo.Enabled = False
        PictureBoxNuevo.Image = My.Resources.NewOff
        PictureBoxNuevo.Cursor = Cursors.Arrow
        PictureBoxEliminar.Enabled = False
        PictureBoxEliminar.Image = My.Resources.DeleteOff
        PictureBoxEliminar.Cursor = Cursors.Arrow
        PictureBoxModifica.Enabled = False
        PictureBoxModifica.Image = My.Resources.EditOff
        PictureBoxModifica.Cursor = Cursors.Arrow

        PictureBoxGuardar.Enabled = True
        PictureBoxGuardar.Image = My.Resources.Save
        PictureBoxGuardar.Cursor = Cursors.Hand
        PictureBoxCancelar.Enabled = True
        PictureBoxCancelar.Image = My.Resources.SaveCancel
        PictureBoxCancelar.Cursor = Cursors.Hand

        ProductosGridView.Enabled = False
        BuscaProductoTextBox.Enabled = False
        DesProductoTextBox.Enabled = True
        'PanelPrincipal.Enabled = True
        PanelDetalles.Enabled = True
        PanelCabecera.Enabled = True
        pnlCodigoBarra.Enabled = True
        Label13.Enabled = True

        TipoClieComboBox.Enabled = True
        'MONEDA
        CbxMoneda.Enabled = True
        PrecioTxtMoneda.Enabled = True
        tbxCant.Enabled = True
        AgregarPrecioButton.Enabled = True
        ElimPrecioButton.Enabled = True
        pbxAgregarListaPrecio.Enabled = True
        PreciosGridView.Enabled = True

        'Categoria
        CategoriaComboBox.Enabled = True
        LineaComboBox.Enabled = True
        MarcaComboBox.Enabled = True

        If ChckBalanza.Checked = True Then
            ChckBalanza.Enabled = False
            CmbVencimiento.Enabled = False
            CmbPesable.Enabled = False
            pnlCodigoBarra.Enabled = False
        End If

        If TipoProductoComboBox.Text = "Servicio" Then
            StockMinimoTextBox.Enabled = False
            StockMaximoTextBox.Enabled = False
            'pnlCodigoBarra.Enabled = False
        End If

        PictureBoxActivo.Enabled = True
        pbxImagen.Enabled = True
        pbxSinImagen.Enabled = True

        Editable = 1
        Bloqueado = 0

        DesProductoTextBox.Enabled = True
        'PanelPrincipal.Enabled = True
        PanelDetalles.Enabled = True
        pnlCodigoBarra.Enabled = True
        TipoClieComboBox.Enabled = True
        PrecioTxtMoneda.Enabled = True
        tbxCant.Enabled = True
        AgregarPrecioButton.Enabled = True
        ElimPrecioButton.Enabled = True
        'txtxcaja.Enabled = True
        PreciosGridView.Enabled = True

    End Sub


    Private Sub InsertacodigoParaServicios()
        sql1 = ""
        'sql1 = "insert into CODIGOS (CODIGO,CODPRODUCTO, FECGRA,DESCODIGO1)" & _
        '" VALUES ( '" & CodigoBarraTextBox.Text & "'," & _
        '"" & VCodProducto & ", " & Today & ", '') "

        sql1 = "insert into CODIGOS (DESCODIGO1, CODIGO, CODPRODUCTO, FECGRA)" & _
                " VALUES ( '', '" & CodigoBarraTextBox.Text & "', " & VCodProducto & ", " & Today & ") "

        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaProducto()
        Dim Promocion As Integer = 0
        Dim v_producto As Integer

        If TipoProductoComboBox.Text = "Producto" Then
            v_producto = 1
        ElseIf TipoProductoComboBox.Text = "Servicio" Then
            v_producto = 0
        ElseIf TipoProductoComboBox.Text = "Producto Producido" Then
            v_producto = 2
        ElseIf TipoProductoComboBox.Text = "Materia Prima" Then
            v_producto = 3
        ElseIf TipoProductoComboBox.Text = "Combo" Then
            v_producto = 4
        ElseIf TipoProductoComboBox.Text = "Descuento" Then
            v_producto = 5
        End If

        If vgPromocion = False Then
            Promocion = 0
        ElseIf vgPromocion = True Then
            Promocion = 1
        End If

        If TipoProductoComboBox.Text = "Servicio" Then
            sql1 = ""
            sql1 = "insert into PRODUCTOS(DESPRODUCTO," & _
            "CODIVA,CODUSUARIO,SERVICIO,PRODUCTO,PRODUCTOPRODUCIDO,ESTADO," & _
            "CODFAMILIA,CODLINEA, CODRUBRO,CODPROVEEDOR, PROMOCION, ESPECIFICACIONES,CODMEDIDA,IDMARCA,IDEQUIPO, UBICACION) VALUES " & _
            "('" & Replace(DesProductoTextBox.Text, "'", "''") & "'," & _
            "" & CodTipoIva & "," & UsuCodigo & ",1," & v_producto & ",0," & ProductoActivo & "," & _
            "" & CodCategoriaGlobal & ", " & CodMarcaGlobal & "," & CodLineaGlobal & "," & CodProveedor & "," & Promocion & ",'" & tbxEspecificaciones.Text & "'," & CodMedidaGlobal & ",'" & cbxMarca.SelectedValue & "','" & cbxEquipo.SelectedValue & "','" & Ubicacion & "') " & _
            "SELECT CODPRODUCTO FROM PRODUCTOS WHERE CODPRODUCTO = SCOPE_IDENTITY();"

            cmd.CommandText = sql1
            VCodProducto = cmd.ExecuteScalar()
            If ubicacionarchivo <> "" Then
                actualizaimagen2(VCodProducto)
            End If
        Else
            Dim TipoProd As Integer
            Dim vencimiento, pesable As String

            TipoProd = 0 : vencimiento = "" : pesable = ""

            If ChckBalanza.Checked = True Then
                If Me.CmbVencimiento.Text = "Si" Then
                    vencimiento = "1"
                Else
                    vencimiento = "0"
                End If

                If Me.CmbPesable.Text = "Si" Then
                    pesable = "1"
                Else
                    pesable = "0"
                End If
            End If

            sql1 = ""
            sql1 = "insert into PRODUCTOS " & _
            "( CODFAMILIA,CODLINEA, CODRUBRO, " & _
            "DESPRODUCTO, CODUSUARIO, FECGRA, STOCKMAXIMO, STOCKMINIMO," & _
            "CODIVA, ESTADO,CODMEDIDA,IDMARCA,IDEQUIPO," & _
            "SERVICIO,CODPROVEEDOR,PROMOCION, ESPECIFICACIONES,PRODUCTO,UBICACION)" & _
            "values (" & CodCategoriaGlobal & ", " & CodMarcaGlobal & ", " & _
            "" & CodLineaGlobal & ", '" & Replace(DesProductoTextBox.Text, "'", "''") & "'," & _
            "" & UsuCodigo & ", " & _
            "CONVERT(DATETIME, '" & Today & "', 103), " & _
            "" & StockMax & ", " & StockMin & ", " & _
            "" & TipoIVAComboBox.SelectedValue & ", 0," & _
            "" & CodMedidaGlobal & ",'" & cbxMarca.SelectedValue & "','" & cbxEquipo.SelectedValue & "', 0 ," & CodProveedor & "," & Promocion & ",'" & tbxEspecificaciones.Text & "','" & v_producto & "','" & Ubicacion & "') " & _
            "SELECT CODPRODUCTO FROM PRODUCTOS WHERE CODPRODUCTO = SCOPE_IDENTITY();"

            cmd.CommandText = sql1
            VCodProducto = cmd.ExecuteScalar()
            If ubicacionarchivo <> "" Then
                actualizaimagen2(VCodProducto)
            End If

            For Each Row As DataRow In DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE.Select(Nothing, Nothing, DataViewRowState.Added)
                Row("IDPRODUCTO") = VCodProducto
            Next

            PRODUCTO_EQUIPO_REL_SIMPLETableAdapter.Update(DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE)

        End If
    End Sub

    Private Sub InsertaProductoAuditoria()
        Dim w As New Funciones.Funciones
        Dim CodAutitoria As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql1 = ""
        sql1 = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) values (" & CodAutitoria & ", " & EmpCodigo & ", 'PRODUCTOS', '" & CodAutitoria & "', 'INSERCION EN LA TABLA PRODUCTOS', CONVERT(DATETIME, '" & Today & "', 103), '" & UsuDescripcion & "', '" & UsuNivel & "', 1, 0, 0)"
        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub LineaComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles LineaComboBox.GotFocus
        LineaComboBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub LineaComboBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LineaComboBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            cbxMarca.Focus()

            'TipoProductoComboBox.Focus()
        End If
    End Sub


    Private Sub LineaComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LineaComboBox.KeyPress
        If Bloqueado = 1 Then
            Exit Sub
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            cbxMarca.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If KeyAscii = 45 Then
            If LineaComboBox.SelectedValue = Nothing Then
                Exit Sub
            End If
            If MsgBox("Va a borrar una Linea, esta seguro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.No Then
                ' DemandadoBindingSource.CancelEdit()
            Else
                Try

                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "EliminaLinea")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans

                    myTrans.Commit()
                    RUBROTableAdapter.Fill(DsProductos.RUBRO)
                Catch ex As SqlException
                    Try
                        myTrans.Rollback("EliminaLinea")
                    Catch
                    End Try

                    Dim NroError As Integer = ex.Number
                    Dim Mensaje As String = ex.Message
                    If NroError = 547 Then
                        MessageBox.Show("La Linea que desea eliminar tiene relacion con otra tabla del Sistema", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Ocurrio un error el eliminar los Datos: " + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Finally
                    sqlc.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub cbxMarca_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxMarca.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            UbicacionTextBox.Focus()
        End If
    End Sub

    Private Sub UbicacionTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UbicacionTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            TipoProductoComboBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    'Private Sub cbxEquipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxEquipo.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        e.Handled = True
    '        TipoProductoComboBox.Focus()

    '        'TipoProductoComboBox.Focus()
    '    End If
    'End Sub

    Private Sub MarcaComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles MarcaComboBox.GotFocus
        MarcaComboBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub MarcaComboBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MarcaComboBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            LineaComboBox.Focus()
        End If
    End Sub

    Private Sub MarcaComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MarcaComboBox.KeyPress
        If Bloqueado = 1 Then
            Exit Sub
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            LineaComboBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If KeyAscii = 45 Then
            If MarcaComboBox.SelectedValue = Nothing Then
                Exit Sub
            End If
            If MsgBox("Va a borrar una Marca, esta seguro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.No Then
                ' DemandadoBindingSource.CancelEdit()
            Else
                Try
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "EliminaMarca")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans

                    myTrans.Commit()
                    LINEATableAdapter.Fill(DsProductos.LINEA)
                Catch ex As SqlException
                    Try
                        myTrans.Rollback("EliminaMarca")
                    Catch
                    End Try

                    Dim NroError As Integer = ex.Number
                    Dim Mensaje As String = ex.Message
                    If NroError = 547 Then
                        MessageBox.Show("La Marca que desea eliminar tiene relacion con otra tabla del Sistema", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Ocurrio un error el eliminar los Datos" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Finally
                    sqlc.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub MarcaComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles MarcaComboBox.LostFocus
        MarcaComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub UbicacionTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles UbicacionTextBox.LostFocus
        UbicacionTextBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub NumericCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericCode.TextChanged
        Try
            BarcodeString.Text = EAN13(NumericCode.Text.PadRight(12, "0"))
            'CodBarraLabel.Text = BarcodeString.Text
        Catch ex As Exception

        End Try
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

    Private Sub PictureBoxCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCodigo.Click
        permiso = PermisoAplicado(UsuCodigo, 58)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir la Ventana de Codigo de Barra", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            CodigodeBarra.Show()
        End If
    End Sub

    Private Sub PictureBoxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxEliminar.Click
        permiso = PermisoAplicado(UsuCodigo, 56)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Eliminar este Producto", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            VCodProducto = ProductosGridView.CurrentRow.Cells("CODPRODUCTO2").Value
            If VCodProducto = Nothing Then
                MessageBox.Show("Elija un Producto para Eliminar", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            EliminarProducto()
        End If
    End Sub

    Private Sub VerificarGuardar()
        If TipoProductoComboBox.Text = "Producto" Then
            'Un codigo por lo menos debe tener
            'Codigos
            Dim CountBueno As Integer = 0
            Dim CountMalo As Integer = 0

            If ChckBalanza.Checked = False Then
                For i = 0 To CodigosTradicionalGridView.RowCount - 1
                    If CodigosTradicionalGridView.Rows(i).Cells("EstadoCodigo").Value = 3 Then
                        CountMalo = 1 'f.FuncionConsultaDecimal("CODCODIGO", "STOCKDEPOSITO", "CODCODIGO", CodigosTradicionalGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value)
                        'If CountMalo <> 0 Then
                        '    Exit For
                        'End If
                    Else
                        CountBueno = 1
                    End If
                Next

                If CountBueno = 0 Then
                    MessageBox.Show("Ingrese por lo menos un Código para este Producto", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    HayError = 1
                    Exit Sub
                ElseIf CountMalo <> 0 And CountBueno = 0 Then
                    MessageBox.Show("El Codigo No Puede ser Eliminado porque tiene Relacion", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    HayError = 1
                    Exit Sub
                End If
            End If
            If ChckBalanza.Checked = False Then
                Dim c As Integer = CodigosTradicionalGridView.RowCount
                If c < 1 Then
                    MessageBox.Show("Ingrese por lo menos un Código de Barra para el Producto", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    HayError = 1
                    CodigoBarraTextBox.Focus()
                    CodigoBarraTextBox.BackColor = Color.Pink
                    Exit Sub
                End If
            End If
        End If

        'Precios
        HayError = 0
        For i = 0 To PreciosGridView.RowCount - 1
            If PreciosGridView.Rows(i).Cells("EstadoPrecio").Value = 3 Then
                HayError = 1
                Exit For
            End If
        Next
        If HayError = 1 And PreciosGridView.RowCount = 1 Then
            MessageBox.Show("Ingrese por lo menos un Precio para este Producto", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HayError = 1
            Exit Sub
        End If
        HayError = 0

        '****** VERIFICACIONES
        If DesProductoTextBox.Text = "" Then
            MessageBox.Show("Ingrese la descripción para el Producto", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HayError = 1
            DesProductoTextBox.Focus()
            DesProductoTextBox.BackColor = Color.Pink
            PanelPrincipal.Visible = True
            Exit Sub
        End If

        If DesProductoTextBox.Text.Length > 80 Then
            MessageBox.Show("La descripción del Producto no puede superar los 80 caracteres", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HayError = 1
            PanelPrincipal.Visible = True
            DesProductoTextBox.Focus()
            DesProductoTextBox.BackColor = Color.Pink
            Exit Sub
        End If

        If TipoProductoComboBox.Text = "Servicio" Then
            Dim existe As Integer
            existe = f.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO", VCodProducto)
            If existe > 0 Then
                MessageBox.Show("El producto no puede ser modificado a servicio porque tiene stock", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                HayError = 1
                TipoProductoComboBox.Focus()
                TipoProductoComboBox.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        '##### Para cuando usemos sevicios###########

        If ChckBalanza.Checked = True Then

            If CmbPesable.Text = "Si" Then
                If CategoriaComboBox.SelectedValue = Nothing And MarcaComboBox.SelectedValue = Nothing Then
                    MessageBox.Show("Seleccione las categorias correspondientes para este producto", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    HayError = 1
                    CategoriaComboBox.BackColor = Color.Pink
                    Exit Sub
                End If
            End If
            If CmbPesable.Text = "" Then
                MessageBox.Show("Establezca si es pesable o no", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                HayError = 1
                CmbPesable.Focus()
                CmbPesable.BackColor = Color.Pink
                Exit Sub
            End If
        Else
            CmbVencimiento.Text = ""
            CmbPesable.Text = ""
        End If
        If TipoProductoComboBox.Text = "Producto" Then
            If MedidaComboBox.Text = "" Then
                MessageBox.Show("Ingrese la unidad de medida del producto", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                HayError = 1
                MedidaComboBox.Focus()
                MedidaComboBox.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        'Iva tiene q elegir
        If TipoIVAComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Seleccione el Tipo de IVA para el Producto", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HayError = 1
            TipoIVAComboBox.Focus()
            TipoIVAComboBox.BackColor = Color.Pink
            Exit Sub
        Else
            CodTipoIva = TipoIVAComboBox.SelectedValue
        End If

        'UN PRECIO POR LO MENOS DEBEMOS TENER
        Dim x As Integer = PreciosGridView.RowCount
        If x < 1 Then
            MessageBox.Show("Ingrese por lo menos un Precio ", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HayError = 1
            PrecioTxtMoneda.Focus()
            PrecioTxtMoneda.BackColor = Color.Pink
            Exit Sub
        End If

        '##############################################

        '#######################################################################
        'si quiere modificar estando el codigo del producto vacio
        If VCodProducto = Nothing Then
            MessageBox.Show("Selecione un Producto antes de Guardar", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HayError = 1
            DeshabilitaControles()
            BuscaProductoTextBox.Enabled = True
            Exit Sub
        End If
    End Sub

    Private Sub PictureBoxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxGuardar.Click
        HayError = 0

        Me.Cursor = Cursors.AppStarting
        VerificarGuardar()

        If HayError = 0 Then

            GUARDARPRODUCTO()

            Dim codprodTemp As String
            codprodTemp = VCodProducto

            Try
                PRODUCTOSTableAdapter.Fill(DsProductos.PRODUCTOS, "%")
                'Buscamos la posicion del registro guardado
                For i = 0 To ProductosGridView.RowCount - 1
                    If ProductosGridView.Rows(i).Cells("CODPRODUCTO2").Value = codprodTemp Then
                        PRODUCTOSBindingSource.Position = i
                        Exit For
                    End If
                Next

                Me.CODIGOSTableAdapter.FillBy(DsProductos.CODIGOS, VCodProducto)
                Me.PRECIOTableAdapter.Fill(Me.DsProductos.PRECIO, VCodProducto)
                'MONEDA
                'Me.MONEDATableAdapter.Fill(Me.DsProductos.MONEDA, VCodProducto)

            Catch ex As Exception

            End Try

            lblAyudaEditarCod.Visible = False
            Bteditar = 0 : Btnuevo = 0
            CodigoBarraTextBox.Text = "" : DesCodigoTextBox.Text = "" : TipoClieComboBox.Text = "" : CbxMoneda.Text = "" : PrecioTxtMoneda.Text = "" : tbxCant.Text = "1"
            DeshabilitaControles()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBoxModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxModifica.Click

        If permisoeditarDatos = 0 And permisoeditarPrecio = 0 Then
            MessageBox.Show("Usted No tiene Permisos para Modificar", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            If ProductosGridView.CurrentRow.Cells("CODPRODUCTO2").Value <> Nothing Then
                Bteditar = 1
                HabilitaControles() ' habilita tambien guardar, cancelar, etc
                If permisoeditarDatos = 0 Then
                    If permisoeditarPrecio = 1 Then
                        PanelCabecera.Enabled = False
                        PanelDetalles.Enabled = False
                        pnlCodigoBarra.Enabled = False
                        Label13.Enabled = False
                        'PanelPrincipal.Enabled = True
                        TipoClieComboBox.Enabled = True
                        PrecioTxtMoneda.Enabled = True
                        tbxCant.Enabled = True
                        AgregarPrecioButton.Enabled = True
                        ElimPrecioButton.Enabled = True
                        pbxAgregarListaPrecio.Enabled = True
                        PreciosGridView.Enabled = True
                    End If
                Else
                    If permisoeditarPrecio = 0 Then
                        TipoClieComboBox.Enabled = False
                        PrecioTxtMoneda.Enabled = False
                        tbxCant.Enabled = False
                        AgregarPrecioButton.Enabled = False
                        ElimPrecioButton.Enabled = False
                        pbxAgregarListaPrecio.Enabled = False
                        PreciosGridView.Enabled = False
                    End If
                End If
                lblAyudaEditarCod.Visible = True
                PictureBoxModifica.Image = My.Resources.EditActive
            Else
                MessageBox.Show("Elija un Producto para Modificar", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub PictureBoxNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxNuevo.Click
        If permisonuevo = 0 Then
            MessageBox.Show("Usted no tiene Permiso para crear un Nuevo Producto", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            VCodProducto = 0
            Bteditar = 0 : Btnuevo = 1
            PictureBoxNuevo.Image = My.Resources.NewActive
            pnlCostoProducto.Visible = False
            lblAyudaEditarCod.Visible = True

            PRODUCTOSBindingSource.AddNew()
            TipoProductoComboBox.Text = "Producto"
            ChckBalanza.Enabled = True : pnlCodigoBarra.Enabled = True : StockMinimoTextBox.Enabled = True
            StockMaximoTextBox.Enabled = True : ChckBalanza.Checked = False : CmbVencimiento.Enabled = False
            CmbPesable.Enabled = False

            LimpiarGrillaCodigo()
            LimpiarGrillaPrecio()
            HabilitaControles()
            DesProductoTextBox.Focus()

            ProductoActivo = 0 'Activo es 0
            PictureBoxActivo.Image = My.Resources.AbiertoActive
            lblActivo.ForeColor = Color.OrangeRed
            lblActivo.Text = "Activo"
            TipoIVAComboBox.SelectedValue = 1
            MedidaComboBox.SelectedValue = 1
        End If
    End Sub

    Private Sub verificarchecks(ByVal control As PresentationControls.CheckBoxComboBox, dt As DataTable)
        If banverifcheck = True Then
            Dim contcheck As Integer = 0
            For i = 0 To dt.Rows.Count - 1
                If control.CheckBoxItems(i).Checked = True Then
                    contcheck = contcheck + 1
                End If
            Next
            If contcheck = dt.Rows.Count Then
                control.AccessibleName = "True"
            ElseIf contcheck = 0 Then
                control.AccessibleName = "False"
            Else
                control.AccessibleName = "Parcial"
            End If
        End If
    End Sub

    Private Sub LimpiarGrillaCodigo()
        Try
            If CodigosTradicionalGridView.RowCount >= 1 Then
                For i As Integer = 0 To CodigosTradicionalGridView.RowCount - 1
                    CodigosTradicionalGridView.Rows.Remove(CodigosTradicionalGridView.CurrentRow)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LimpiarGrillaPrecio()
        Try
            If PreciosGridView.RowCount >= 1 Then
                For i As Integer = 0 To PreciosGridView.RowCount - 1
                    PreciosGridView.Rows.Remove(PreciosGridView.CurrentRow)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductosGridView_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ProductosGridView.ColumnHeaderMouseClick
        If e.RowIndex < 0 Then
            ClickCabecera = True
        End If
    End Sub


    Private Sub ProductosGridView_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ProductosGridView.RowHeaderMouseClick
        If e.RowIndex >= 0 Then
            ClickCabecera = True
        End If
    End Sub

    Private Sub ProductosGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductosGridView.SelectionChanged

        Dim Pesable, Vencimiento, Balanza, IsProducto As Integer
        Dim ultmovOcompra As String = ""
        PreciosGridView.Enabled = True
        If ProductosGridView.RowCount > 0 Then
            VCodProducto = ProductosGridView.CurrentRow.Cells("CODPRODUCTO2").Value

            Me.PRODUCTO_EQUIPO_RELTableAdapter.Fill(Me.DsEquipoRel.PRODUCTO_EQUIPO_REL, VCodProducto)

            Me.PRODUCTO_EQUIPO_REL_SIMPLETableAdapter.Fill(Me.DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE, VCodProducto)


            Try
                If Config1 = "Precio Última Compra (Con Iva)" Then
                    ultmovOcompra = f.FuncionConsulta("MAX(COMPRASDETALLE.COSTOUNITARIO)", "COMPRASDETALLE INNER JOIN COMPRAS ON COMPRASDETALLE.CODCOMPRA = COMPRAS.CODCOMPRA", "COMPRAS.ESTADO=1 AND COMPRAS.FECHACOMPRA = (SELECT MAX(COMPRAS_1.FECHACOMPRA) AS Expr1 FROM COMPRASDETALLE AS COMPRASDET_1 INNER JOIN COMPRAS AS COMPRAS_1 ON COMPRASDET_1.CODCOMPRA = COMPRAS_1.CODCOMPRA GROUP BY COMPRASDET_1.CODCODIGO, COMPRAS_1.ESTADO HAVING COMPRAS_1.ESTADO=1 AND (COMPRASDET_1.CODCODIGO = " & ProductosGridView.CurrentRow.Cells("CODCODIGO").Value & ")) AND COMPRASDETALLE.CODCODIGO ", ProductosGridView.CurrentRow.Cells("CODCODIGO").Value)
                    lblUltimoCosto.Text = FormatNumber(ultmovOcompra, 0)
                Else
                    Dim SqlWhere As String = "dbo.MOVPRODUCTO WHERE (CANTIDAD > 0) AND (COSTEABLE = 1) AND CODCODIGO = " & ProductosGridView.CurrentRow.Cells("CODCODIGO").Value.ToString & " ORDER BY FECHAMOVIMIENTO DESC"
                    ultmovOcompra = f.FuncionTop1("VALOR", SqlWhere)
                    lblUltimoCosto.Text = FormatNumber(ultmovOcompra, 0)
                End If

            Catch ex As Exception
                lblUltimoCosto.Text = ""
            End Try

            lblCosto.Text = FormatNumber(f.FuncionConsultaDecimal("PRECIO", "CODIGOS", "CODCODIGO", ProductosGridView.CurrentRow.Cells("CODCODIGO").Value), 0)
            txtPorcGanancia.Text = "" : lblPrecioVenta.Text = ""

            Try
                If IsDBNull(ProductosGridView.CurrentRow.Cells("CODCODIGO").Value) Then
                Else
                    objCommand.CommandText = "SELECT PESABLE, VENCIMIENTO, BALANZA FROM dbo.CODIGOS WHERE CODCODIGO =" & ProductosGridView.CurrentRow.Cells("CODCODIGO").Value & ""

                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    Dim odrCodigos As SqlDataReader = objCommand.ExecuteReader()

                    If odrCodigos.HasRows Then
                        Do While odrCodigos.Read()
                            If IsDBNull(odrCodigos("PESABLE")) Then
                                Pesable = 0
                            Else
                                Pesable = odrCodigos("PESABLE")
                            End If

                            If IsDBNull(odrCodigos("VENCIMIENTO")) Then
                                Vencimiento = 0
                            Else
                                Vencimiento = odrCodigos("VENCIMIENTO")
                            End If

                            If IsDBNull(odrCodigos("BALANZA")) Then
                                Balanza = 0
                            Else
                                Balanza = odrCodigos("BALANZA")
                            End If
                        Loop
                    End If

                    odrCodigos.Close()
                    objCommand.Dispose()

                    If Pesable = 1 Then
                        CmbPesable.Text = "Si"
                    Else
                        CmbPesable.Text = "No"
                    End If

                    If Vencimiento = 1 Then
                        CmbVencimiento.Text = "Si"
                    Else
                        CmbVencimiento.Text = "No"
                    End If

                    If Balanza = 1 Then
                        ChckBalanza.Checked = True
                    Else
                        ChckBalanza.Checked = False
                    End If

                    Me.CODIGOSTableAdapter.FillBy(DsProductos.CODIGOS, VCodProducto)

                    'De la grilla no trae correctamente por eso tuve que hacer la funcion para traer el servicio----Cyn
                    IsProducto = f.FuncionConsulta("PRODUCTO", "PRODUCTOS", "CODPRODUCTO", ProductosGridView.CurrentRow.Cells("CODPRODUCTO2").Value)

                    If IsProducto = 1 Then
                        TipoProductoComboBox.Text = "Producto"
                    ElseIf IsProducto = 0 Then
                        TipoProductoComboBox.Text = "Servicio"
                    ElseIf IsProducto = 2 Then
                        TipoProductoComboBox.Text = "Producto Producido"
                    ElseIf IsProducto = 3 Then
                        TipoProductoComboBox.Text = "Materia Prima"
                    ElseIf IsProducto = 4 Then
                        TipoProductoComboBox.Text = "Combo"
                    ElseIf IsProducto = 5 Then
                        TipoProductoComboBox.Text = "Descuento"
                    End If
                End If
            Catch ex As Exception

            End Try

            If IsDBNull(ProductosGridView.CurrentRow.Cells("IMAGENPRODUCTO").Value) Then
                pbxSinImagen.BringToFront()
                pbxImagen.SendToBack()
            Else
                pbxImagen.BringToFront()
                pbxSinImagen.SendToBack()
            End If

            'Para Obtener la lista de precios de los articulos
            Me.PRECIOTableAdapter.Fill(Me.DsProductos.PRECIO, VCodProducto)

            Try
                If IsDBNull(ProductosGridView.CurrentRow.Cells("PROMOCION").Value) Then
                    pbxEnPromocion.Image = My.Resources.star___copia
                ElseIf ProductosGridView.CurrentRow.Cells("PROMOCION").Value = True Then
                    pbxEnPromocion.Image = My.Resources.star
                ElseIf ProductosGridView.CurrentRow.Cells("PROMOCION").Value = False Then
                    pbxEnPromocion.Image = My.Resources.star___copia
                End If
            Catch ex As Exception
            End Try

            If IsDBNull(ProductosGridView.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value) Then
                PictureBoxActivo.Image = My.Resources.AbiertoOff
                ProductoActivo = 1 'Inactivo
                lblActivo.ForeColor = Color.Black
                lblActivo.Text = "Inactivo"
            Else
                If ProductosGridView.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 1 Then
                    PictureBoxActivo.Image = My.Resources.AbiertoOff
                    ProductoActivo = 1
                    lblActivo.ForeColor = Color.Black
                    lblActivo.Text = "Inactivo"
                Else
                    PictureBoxActivo.Image = My.Resources.AbiertoActive
                    ProductoActivo = 0
                    lblActivo.ForeColor = Color.OrangeRed
                    lblActivo.Text = "Activo"
                End If
            End If
        End If
        'Try
        '    cbxMarca.Text = PRODUCTOMARCABindingSource.Current("DESMARCA").ToString
        '    cbxEquipo.Text = PRODUCTOEQUIPOBindingSource.Current("DESEQUIPO").ToString
        'Catch
        '    cbxMarca.Text = ""
        '    cbxEquipo.Text = ""
        'End Try
    End Sub

    Private Sub Producto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If PictureBoxNuevo.Enabled = True Then
                PictureBoxNuevo_Click(Nothing, Nothing)
            End If

        End If

        If e.KeyCode = Keys.F6 Then
            If PictureBoxModifica.Enabled = True Then
                PictureBoxModifica_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F7 Then
            If PictureBoxGuardar.Enabled = True Then
                PictureBoxGuardar_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F8 Then
            If PictureBoxCancelar.Enabled = True Then
                PictureBoxCancelar_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F10 Then
            PictureBoxStockInicial_Click(Nothing, Nothing)
        End If

        If e.KeyCode = Keys.F11 Then
            PictureBoxCodigo_Click(Nothing, Nothing)
        End If

        If e.KeyCode = Keys.Escape Then
            pnlCostoProducto.Visible = False
        End If

        If e.KeyCode = Keys.F12 Then
            'Verificamos si tiene permiso para ver el panel de costos
            permiso = PermisoAplicado(UsuCodigo, 262)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para ver los costos del Producto", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If pnlCostoProducto.Visible = False Then
                    pnlCostoProducto.Visible = True
                    pnlCostoProducto.BringToFront()
                    lblPrecioVenta.Text = "" : txtPorcGanancia.Text = "" : cmbTipoCosto.Text = "FIFO"
                    txtPorcGanancia.Focus()
                Else
                    pnlCostoProducto.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub Producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsEquipoRel.PRODUCTO_EQUIPO_REL' Puede moverla o quitarla según sea necesario.

        Me.PRODUCTOEQUIPOTableAdapter.Fill(Me.DsProductos.PRODUCTOEQUIPO)
        Me.PRODUCTOMARCATableAdapter.Fill(Me.DsProductos.PRODUCTOMARCA)

        Me.MONEDATableAdapter.Fill(Me.DsProductos.MONEDA)
        permiso = PermisoAplicado(UsuCodigo, 54)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        Bteditar = 0
        obtenerconfig()
        lblAyudaEditarCod.Visible = False

        Me.FAMILIATableAdapter.Fill(Me.DsProductos.FAMILIA)
        Me.UNIDADMEDIDATableAdapter.Fill(Me.DsProductos.UNIDADMEDIDA)
        Me.IVATableAdapter.Fill(Me.DsProductos.IVA)
        Me.TIPOCLIENTETableAdapter.Fill(Me.DsProductos.TIPOCLIENTE)
        Me.LINEATableAdapter.Fill(Me.DsProductos.LINEA)
        Me.RUBROTableAdapter.Fill(Me.DsProductos.RUBRO)
        Try
            Me.PROVEEDORTableAdapter.Fill(Me.DsProductos.PROVEEDOR)
        Catch ex As Exception
        End Try

        Try
            Me.PRODUCTOSTableAdapter.Fill(Me.DsProductos.PRODUCTOS, "%")
        Catch ex As Exception
            MessageBox.Show("Faltan columnas en la tabla", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        UbicacionTextBox.Text = ""
        MarcaComboBox.Text = "" : LineaComboBox.Text = "" : CategoriaComboBox.Text = "" : vgPromocion = False

        If Config1 = "Precio Última Compra (Con Iva)" Then
            lblSinIva.Text = "(con Iva)"
            lblTituloUltMov.Text = "Precio Última Compra:"
            cmbTipoCosto.Items.Clear()
            cmbTipoCosto.Items.Add("FIFO")
            cmbTipoCosto.Items.Add("Última Compra")
        Else
            lblSinIva.Text = "(sin Iva)"
            lblTituloUltMov.Text = "Costo Últ. Movimiento:"
            cmbTipoCosto.Items.Clear()
            cmbTipoCosto.Items.Add("FIFO")
            cmbTipoCosto.Items.Add("Últ. Movimiento")
        End If

        If Config2 = "No" Then
            Me.ProductosGridView.Columns("DESCODIGO1DataGridViewTextBoxColumn1").Visible = False
        Else
            Try
                Me.ProductosGridView.Columns("DESCODIGO1DataGridViewTextBoxColumn1").Visible = True
            Catch
            End Try

        End If

        Editable = 0
        DeshabilitaControles()
        modificadetalle = 0
        permisonuevo = PermisoAplicado(UsuCodigo, 55)
        permisoeditarDatos = PermisoAplicado(UsuCodigo, 57)
        permisoeditarPrecio = PermisoAplicado(UsuCodigo, 226)
        BuscaProductoTextBox.Focus()

        PreciosGridView.Enabled = True
        PanelPrincipal.Enabled = True


    End Sub
    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1, CONFIG2 FROM MODULO WHERE MODULO_ID = 12"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    Config1 = odrConfig("CONFIG1")
                    Config2 = odrConfig("CONFIG2")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub StockMinimoTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles StockMinimoTextBox.GotFocus
        StockMinimoTextBox.Appearance.BackColor = Color.DodgerBlue
    End Sub

    Private Sub StockMinimoTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles StockMinimoTextBox.KeyPress
        StockMaximoTextBox.Focus()
    End Sub
#End Region

    Private Sub LineaComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles LineaComboBox.LostFocus
        LineaComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub TxtVencimiento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtVencimiento.TextChanged
        If TxtVencimiento.Text = "" Then
            CmbVencimiento.Text = ""
        ElseIf TxtVencimiento.Text = "0" Then
            CmbVencimiento.Text = "No"
        ElseIf TxtVencimiento.Text = "1" Then
            CmbVencimiento.Text = "Si"
        End If
    End Sub

    Private Sub TxtPesable_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPesable.TextChanged
        If TxtPesable.Text = "" Then
            CmbPesable.Text = ""
        ElseIf TxtPesable.Text = "0" Then
            CmbPesable.Text = "No"
        ElseIf TxtPesable.Text = "1" Then
            CmbPesable.Text = "Si"
        End If
    End Sub

    Private Sub CmbVencimiento_GotFocus(sender As Object, e As System.EventArgs) Handles CmbVencimiento.GotFocus
        CmbVencimiento.BackColor = Color.DodgerBlue
    End Sub

    Private Sub CmbVencimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbVencimiento.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            CmbPesable.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbVencimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbVencimiento.SelectedIndexChanged
        If CmbVencimiento.Text = "Si" Then
            TxtVencimiento.Text = "1"
        ElseIf CmbVencimiento.Text = "No" Then
            TxtVencimiento.Text = "0"
        End If
    End Sub

    Private Sub CmbPesable_GotFocus(sender As Object, e As System.EventArgs) Handles CmbPesable.GotFocus
        CmbPesable.BackColor = Color.DodgerBlue
    End Sub

    Private Sub CmbPesable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPesable.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            CodigoBarraTextBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbPesable_LostFocus(sender As Object, e As System.EventArgs) Handles CmbPesable.LostFocus
        CmbPesable.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub CmbPesable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPesable.SelectedIndexChanged
        If CmbPesable.Text = "Si" Then
            TxtPesable.Text = "1"
        ElseIf CmbPesable.Text = "No" Then
            TxtPesable.Text = "0"
        End If
    End Sub

    Private Sub PictureBoxCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancelar.Click
        PRODUCTOSBindingSource.CancelEdit()
        Dim codprodTemp As String
        codprodTemp = ProductosGridView.CurrentRow.Cells("CODPRODUCTO2").Value

        Try
            PRODUCTOSTableAdapter.Fill(DsProductos.PRODUCTOS, "%")
            'Buscamos la posicion del registro guardado
            For i = 0 To ProductosGridView.RowCount - 1
                If ProductosGridView.Rows(i).Cells("CODPRODUCTO2").Value = codprodTemp Then
                    PRODUCTOSBindingSource.Position = i
                    Exit For
                End If
            Next

            Me.CODIGOSTableAdapter.FillBy(DsProductos.CODIGOS, VCodProducto)
            Me.PRECIOTableAdapter.Fill(Me.DsProductos.PRECIO, VCodProducto)
        Catch ex As Exception

        End Try
        lblAyudaEditarCod.Visible = False
        Bteditar = 0 : Btnuevo = 0
        DeshabilitaControles()
        CancelarCodigoButton_Click(Nothing, Nothing)
    End Sub

    Private Sub TipoProductoComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles TipoProductoComboBox.GotFocus
        TipoProductoComboBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub TipoProductoComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TipoProductoComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            TipoIVAComboBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TipoProductoComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles TipoProductoComboBox.LostFocus
        TipoProductoComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub TipoProductoComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoProductoComboBox.SelectedIndexChanged
        If TipoProductoComboBox.Text = "Servicio" Then
            'ChckBalanza.Enabled = False
            'CmbVencimiento.Enabled = False
            'CmbPesable.Enabled = False
            'pnlCodigoBarra.Enabled = False

            ChckBalanza.Enabled = True
            pnlCodigoBarra.Enabled = True
            StockMinimoTextBox.Enabled = True
            StockMaximoTextBox.Enabled = True

            StockMinimoTextBox.Enabled = False
            StockMaximoTextBox.Enabled = False

        ElseIf TipoProductoComboBox.Text = "Producto" Then
            ChckBalanza.Enabled = True
            pnlCodigoBarra.Enabled = True
            StockMinimoTextBox.Enabled = True
            StockMaximoTextBox.Enabled = True

        ElseIf TipoProductoComboBox.Text = "Materia Prima" Then
            ChckBalanza.Enabled = True
            pnlCodigoBarra.Enabled = True
            StockMinimoTextBox.Enabled = True
            StockMaximoTextBox.Enabled = True

        ElseIf TipoProductoComboBox.Text = "Producto Producido" Then
            ChckBalanza.Enabled = True
            pnlCodigoBarra.Enabled = True
            StockMinimoTextBox.Enabled = True
            StockMaximoTextBox.Enabled = True

        End If
    End Sub

    Private Sub AgregarCodigoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarCodigoButton.Click
        Dim SQLFrom As String
        'Existe = f.FuncionConsulta("CODCODIGO", "CODIGOS", "CODIGO", Trim(CodigoBarraTextBox.Text))

        SQLFrom = " CODIGOS INNER JOIN PRODUCTOS ON CODIGOS.CODPRODUCTO = PRODUCTOS.CODPRODUCTO"
        Existe = f.FuncionConsulta("CODCODIGO", SQLFrom, "PRODUCTOS.ESTADO <> 1 AND CODIGO", Trim(CodigoBarraTextBox.Text))

        If Existe <> 0 Then
            MessageBox.Show("Codigo repetido introduzca otro ", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CodigoBarraTextBox.Focus()
            Exit Sub
        End If

        If CodigoBarraTextBox.Text = "" Or CodigoBarraTextBox.Text.Length >= 15 Then
            MessageBox.Show("El Código no puede quedar Vacio o Mayor a 15 dígitos", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CodigoBarraTextBox.Focus()
            Exit Sub
        End If

        'controla que el codigo del producto no se repita dentro de la grilla
        Try

            ' CODIGOPRODUCTOBindingSource.AddNew()
            CODIGOSBindingSource.AddNew()

            Dim c As Integer = CodigosTradicionalGridView.RowCount
            'Pasamos a la Grilla Tradicional
            CodigosTradicionalGridView.Rows(c - 1).Cells("CODIGODataGridViewTextBoxColumn").Value = CodigoBarraTextBox.Text
            CodigosTradicionalGridView.Rows(c - 1).Cells("DESCODIGO1DataGridViewTextBoxColumn").Value = DesCodigoTextBox.Text
            CodigosTradicionalGridView.Rows(c - 1).Cells("EstadoCodigo").Value = 1 'Nuevo/Insertar

            'LIMPIAMOS
            CodigoBarraTextBox.Text = ""
            DesCodigoTextBox.Text = ""
        Catch ex As Exception
            MessageBox.Show("Problema al Insertar Nuevo Codigo: " + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        CodigoBarraTextBox.Text = ""
        DesCodigoTextBox.Text = ""
    End Sub


    Private Sub ChckBalanza_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBalanza.CheckedChanged
        If Editable = 1 Then
            If ChckBalanza.Checked = True Then
                CmbVencimiento.Enabled = True
                CmbPesable.Enabled = True
                'CkckGenerarBalanzaSiNo.Enabled = True
                pnlCodigoBarra.Enabled = False
            Else
                CmbVencimiento.Text = ""
                CmbPesable.Text = ""
                CmbVencimiento.Enabled = False
                CmbPesable.Enabled = False
                pnlCodigoBarra.Enabled = True
                'CkckGenerarBalanzaSiNo.Enabled = False
            End If
        End If
    End Sub

    Private Sub CancelarCodigoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarCodigoButton.Click
        CodigoBarraTextBox.Text = ""
        DesCodigoTextBox.Text = ""

        AgregarCodigoButton.BringToFront()
        EliminarCodigoButton.BringToFront()
    End Sub

    Private Sub ModificarCodigoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarCodigoButton.Click
        If (CodigoBarraTextBox.Text <> "") Then
            CodigosTradicionalGridView.Rows(LineaCodigo).Cells("CODIGODataGridViewTextBoxColumn").Value = CodigoBarraTextBox.Text
            CodigosTradicionalGridView.Rows(LineaCodigo).Cells("DESCODIGO1DataGridViewTextBoxColumn").Value = DesCodigoTextBox.Text
            CodigosTradicionalGridView.Rows(LineaCodigo).Cells("EstadoCodigo").Value = 2 'Editar/Update

            AgregarCodigoButton.BringToFront()
            EliminarCodigoButton.BringToFront()
            CodigoBarraTextBox.Text = "" : DesCodigoTextBox.Text = ""
        End If
    End Sub

    Private Sub pbxAgregarCategoriaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarCategoriaProducto.Click
        ABMCategorias.ShowDialog()
        Me.RUBROTableAdapter.Fill(Me.DsProductos.RUBRO)
        Me.LINEATableAdapter.Fill(Me.DsProductos.LINEA)
        Me.FAMILIATableAdapter.Fill(Me.DsProductos.FAMILIA)
    End Sub

    Private Sub pbxAgregarMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarMarca.Click
        cbxMarca.SelectedItem = Nothing
        ABMProductoMarca.ShowDialog()
        Me.PRODUCTOMARCATableAdapter.Fill(DsProductos.PRODUCTOMARCA)
    End Sub

    Private Sub pbxAgregarEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarEquipo.Click
        cbxEquipo.SelectedItem = Nothing
        ABMProductoEquipo.ShowDialog()
        Me.PRODUCTOEQUIPOTableAdapter.Fill(DsProductos.PRODUCTOEQUIPO)
    End Sub

    Private Sub pbxAgregarMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarMedida.Click
        ABMUnidadMedida.ShowDialog()
        Me.UNIDADMEDIDATableAdapter.Fill(DsProductos.UNIDADMEDIDA)
    End Sub

    Private Sub pbxAgregarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarListaPrecio.Click
        ABMTipoCliente.ShowDialog()
        Me.TIPOCLIENTETableAdapter.Fill(DsProductos.TIPOCLIENTE)
    End Sub

    Private Sub TipoIVAComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles TipoIVAComboBox.GotFocus
        TipoIVAComboBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub TipoIVAComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TipoIVAComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            MedidaComboBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub MedidaComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles MedidaComboBox.GotFocus
        MedidaComboBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub MedidaComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MedidaComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            cbxProveedor.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub StockMaximoTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles StockMaximoTextBox.GotFocus
        StockMaximoTextBox.Appearance.BackColor = Color.DodgerBlue
    End Sub


    Private Sub StockMaximoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles StockMaximoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            tbxEspecificaciones.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ChckBalanza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ChckBalanza.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If ChckBalanza.Checked = True Then
            If KeyAscii = 13 Then
                e.Handled = True
                CmbVencimiento.Focus()
            End If
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        Else
            If KeyAscii = 13 Then
                e.Handled = True
                CodigoBarraTextBox.Focus()
            End If
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub tbxEspecificaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxEspecificaciones.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'If KeyAscii = 13 Then
        '    e.Handled = True
        '    CodigoBarraTextBox.Focus()
        'End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbxEspecificaciones_GotFocus(sender As Object, e As System.EventArgs) Handles tbxEspecificaciones.GotFocus
        tbxEspecificaciones.BackColor = Color.DodgerBlue
    End Sub

    Private Sub tbxEspecificaciones_LostFocus(sender As Object, e As System.EventArgs) Handles tbxEspecificaciones.LostFocus
        tbxEspecificaciones.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub CodigoBarraTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles CodigoBarraTextBox.GotFocus
        CodigoBarraTextBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub CodigoBarraTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CodigoBarraTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            DesCodigoTextBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub DesCodigoTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles DesCodigoTextBox.GotFocus
        DesCodigoTextBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub DesCodigoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DesCodigoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            AgregarCodigoButton.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub DesProductoTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles DesProductoTextBox.LostFocus
        DesProductoTextBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub TipoIVAComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles TipoIVAComboBox.LostFocus
        TipoIVAComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub MedidaComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles MedidaComboBox.LostFocus
        MedidaComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub StockMinimoTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles StockMinimoTextBox.LostFocus
        StockMinimoTextBox.Appearance.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub StockMaximoTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles StockMaximoTextBox.LostFocus
        StockMaximoTextBox.Appearance.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub CodigoBarraTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles CodigoBarraTextBox.LostFocus
        CodigoBarraTextBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub DesCodigoTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles DesCodigoTextBox.LostFocus
        DesCodigoTextBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub TipoClieComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles TipoClieComboBox.GotFocus
        TipoClieComboBox.BackColor = Color.DodgerBlue
    End Sub

    Private Sub TipoClieComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TipoClieComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            PrecioTxtMoneda.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TipoClieComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles TipoClieComboBox.LostFocus
        TipoClieComboBox.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub PrecioTxtMoneda_GotFocus(sender As Object, e As System.EventArgs) Handles PrecioTxtMoneda.GotFocus
        PrecioTxtMoneda.BackColor = Color.DodgerBlue
    End Sub

    Private Sub PrecioTxtMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioTxtMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            tbxCant.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub PrecioTxtMoneda_LostFocus(sender As Object, e As System.EventArgs) Handles PrecioTxtMoneda.LostFocus
        PrecioTxtMoneda.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub tbxCant_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCant.GotFocus
        tbxCant.BackColor = Color.DodgerBlue
        lblAyudaCant.Visible = True
        If Trim(tbxCant.Text) = "" Then
            tbxCant.Text = 1
        End If
    End Sub

    Private Sub tbxCant_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCant.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            AgregarPrecioButton.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCant_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCant.LostFocus
        tbxCant.BackColor = SystemColors.ControlLightLight
        lblAyudaCant.Visible = False
    End Sub
    Private Sub CodigosTradicionalGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CodigosTradicionalGridView.CellDoubleClick

        If IsDBNull(CodigosTradicionalGridView.CurrentRow) Then
            Exit Sub
        Else
            LineaCodigo = CodigosTradicionalGridView.CurrentRow.Index
            If IsDBNull(CodigosTradicionalGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value) Then
                CodigoBarraTextBox.Text = ""
            Else
                CodigoBarraTextBox.Text = CodigosTradicionalGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(CodigosTradicionalGridView.CurrentRow.Cells("DESCODIGO1DataGridViewTextBoxColumn").Value) Then
                DesCodigoTextBox.Text = ""
            Else
                DesCodigoTextBox.Text = CodigosTradicionalGridView.CurrentRow.Cells("DESCODIGO1DataGridViewTextBoxColumn").Value
            End If
        End If

        CodigoBarraTextBox.Focus()
        ModificarCodigoButton.BringToFront()
        CancelarCodigoButton.BringToFront()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Dim html As String = "http://www.cogentpotential.com/soporte/stock/productos"
        Shell("Explorer " & html)
    End Sub

    Private Sub PictureBoxStockInicial_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxStockInicial.Click
        StockInicial.Show()
    End Sub

    Private Sub cbxProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxProveedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            StockMinimoTextBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub PictureBoxNuevo_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxNuevo.MouseDown
        If PictureBoxNuevo.Enabled = True Then
            PictureBoxNuevo.Image = My.Resources.NewMouseDown
        End If
    End Sub

    Private Sub PictureBoxEliminar_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxEliminar.MouseDown
        If PictureBoxEliminar.Enabled = True Then
            PictureBoxEliminar.Image = My.Resources.DeleteMouseDown
        End If
    End Sub

    Private Sub PictureBoxModifica_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxModifica.MouseDown
        If PictureBoxModifica.Enabled = True Then
            PictureBoxModifica.Image = My.Resources.EditMouseDown
        End If
    End Sub

    Private Sub PictureBoxGuardar_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxGuardar.MouseDown
        If PictureBoxGuardar.Enabled = True Then
            PictureBoxGuardar.Image = My.Resources.SaveMouseDown

        End If
    End Sub

    Private Sub PictureBoxCancelar_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxCancelar.MouseDown
        If PictureBoxCancelar.Enabled = True Then
            PictureBoxCancelar.Image = My.Resources.SaveCancel
        End If
    End Sub

    Private Sub PictureBoxStockInicial_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxStockInicial.MouseDown
        If PictureBoxStockInicial.Enabled = True Then
            PictureBoxStockInicial.Image = My.Resources.StockMouseDown
        End If
    End Sub

    Private Sub PictureBoxCodigo_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxCodigo.MouseDown
        If PictureBoxCodigo.Enabled = True Then
            PictureBoxCodigo.Image = My.Resources.BarcodeMouseDown
        End If
    End Sub

    Private Sub PreciosGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PreciosGridView.CellDoubleClick
        If PreciosGridView.RowCount <> 0 Then
            If IsDBNull(PreciosGridView.CurrentRow.Cells("EstadoPrecio").Value) Or (PreciosGridView.CurrentRow.Cells("EstadoPrecio").Value = Nothing) Then
                If PreciosGridView.CurrentRow.Cells("EstadoPrecio").Value = 1 Then
                Else
                    PreciosGridView.CurrentRow.Cells("EstadoPrecio").Value = 2
                End If
            End If
        End If
    End Sub

    Private Sub pbxEnPromocion_Click(sender As System.Object, e As System.EventArgs) Handles pbxEnPromocion.Click
        Dim ProductID As Integer = ProductosGridView.CurrentRow.Cells("CODPRODUCTO2").Value

        ser.Abrir(sqlc)
        cmd.Connection = sqlc

        If vgPromocion = True And ProductID <> Nothing Then
            pbxEnPromocion.Image = My.Resources.star___copia
            vgPromocion = False
            sql1 = ""
            sql1 = "UPDATE PRODUCTOS SET PROMOCION = 0 WHERE CODPRODUCTO = " & ProductID & ""
        Else
            pbxEnPromocion.Image = My.Resources.star
            vgPromocion = True
            sql1 = ""
            sql1 = "UPDATE PRODUCTOS SET PROMOCION = 1 WHERE CODPRODUCTO = " & ProductID & ""
        End If

        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()
        sqlc.Close()
    End Sub

    Private Sub txtPorcGanancia_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcGanancia.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            txtPorcGanancia_LostFocus(Nothing, Nothing)
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPorcGanancia_LostFocus(sender As Object, e As System.EventArgs) Handles txtPorcGanancia.LostFocus
        If txtPorcGanancia.Text <> "" Then
            Dim PrecioVenta, Porc, vCosto As Decimal

            If cmbTipoCosto.Text = "" Then
                MessageBox.Show("Selecciones un Tipo de Costo", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbTipoCosto.Focus()
                Exit Sub
            End If

            Try
                If cmbTipoCosto.Text = "FIFO" Then
                    vCosto = CDec(lblCosto.Text)
                Else
                    vCosto = CDec(lblUltimoCosto.Text)
                End If

                Porc = CDec(txtPorcGanancia.Text) / 100
                PrecioVenta = vCosto + (vCosto * Porc)
                lblPrecioVenta.Text = FormatNumber(PrecioVenta, 0)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub pbxImagen_DoubleClick(sender As Object, e As System.EventArgs) Handles pbxImagen.DoubleClick
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ''CREAR IMAGEN DESDE EL FICHERO
            'Dim myImage = Image.FromFile(OpenFileDialog1.FileName)

            'Dim myBitmap = New Bitmap(myImage)

            ''LIMPIAR OBJETO IMAGE ORIGINAL
            'myImage.Dispose()
            'myImage = Nothing

            ''ASIGNAR AL PICTUREBOX
            'Me.pbxImagen.Image = myBitmap
            pbxImagen.Image = Image.FromFile(OpenFileDialog1.FileName)
            ubicacionarchivo = OpenFileDialog1.FileName
        Else
            ubicacionarchivo = ""
            pbxSinImagen.BringToFront()
        End If
    End Sub
    Private Sub pbxSinImagen_DoubleClick(sender As Object, e As System.EventArgs) Handles pbxSinImagen.DoubleClick
        pbxSinImagen.SendToBack()
        pbxImagen.BringToFront()
        pbxImagen_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub tbxEspecificaciones_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxEspecificaciones.TextChanged
        Dim num, cont As Integer
        num = Len(tbxEspecificaciones.Text)
        cont = 300 - num
        lblCantCaracteres.Text = "Cant Caractares : " & cont

        If Bteditar = 1 Or Btnuevo = 1 Then
            If cont <= -1 Then
                MessageBox.Show("Solo puede insertar 300 caracteres, borre el caracter sobrante para poder GUARDAR", "Especificaciones", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                PictureBoxGuardar.Image = My.Resources.SaveOff
                PictureBoxGuardar.Enabled = False
            Else
                PictureBoxGuardar.Image = My.Resources.Save
                PictureBoxGuardar.Enabled = True
            End If
        End If


    End Sub

    Private Sub PictureBoxActivo_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxActivo.Click
        permiso = PermisoAplicado(UsuCodigo, 268)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Activar/Desactivar un Producto", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If ProductoActivo = 1 Then
            ProductoActivo = 0
            PictureBoxActivo.Image = My.Resources.AbiertoActive
            lblActivo.ForeColor = Color.OrangeRed
            lblActivo.Text = "Activo"
        ElseIf ProductoActivo = 0 Then
            ProductoActivo = 1
            PictureBoxActivo.Image = My.Resources.AbiertoOff
            lblActivo.ForeColor = Color.Black
            lblActivo.Text = "Inactivo"
        End If
    End Sub

    Private Sub cmbTipoCosto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoCosto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            txtPorcGanancia.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Function errocodigo() As Integer
        Throw New NotImplementedException
    End Function
    Private Sub PreciosGridView_SelectionChanged(sender As Object, e As System.EventArgs) Handles PreciosGridView.SelectionChanged
        Try

            txtxcaja.Text = 0
            For i = 0 To PreciosGridView.RowCount - 1
                If IsDBNull(PreciosGridView.CurrentRow.Cells("PRECIOVENTA1").Value) = True Then
                    txtxcaja.Text = 0
                Else
                    txtxcaja.Text = PreciosGridView.CurrentRow.Cells("PRECIOVENTA1").Value * PreciosGridView.CurrentRow.Cells("CANTIDAD").Value
                End If
            Next
        Catch ex As Exception
        End Try
        lblCalculo.Text = txtxcaja.Text
    End Sub


    Private Sub PreciosGridView_Click(sender As Object, e As System.EventArgs) Handles PreciosGridView.Click
        txtxcaja.Visible = True
    End Sub

    Private Sub PreciosGridView_LostFocus(sender As Object, e As System.EventArgs) Handles PreciosGridView.LostFocus
        txtxcaja.Visible = False
    End Sub

    Private Sub AddEquipo_Click(sender As Object, e As EventArgs) Handles AddEquipo.Click
        If cbxEquipo.SelectedItem Is Nothing Then 'VERIFICAMOS SI SE AGREGA ALGO.
            MessageBox.Show("Eliga un equipo primero", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '#########################################################################################################
        'VALIDAMOS QUE NO SE REPITAN LOS EQUIPOS.
        Dim Bandera As Integer
        Bandera = 0

        Dim EquipoDuplicado As String = cbxEquipo.Text

        Dim x As Integer = EquipoDataGridView.RowCount
        For x = 1 To x
            If IsDBNull(EquipoDataGridView.Rows(x - 1).Cells("DESEQUIPODataGridViewTextBoxColumn").Value) Then
            Else
                If EquipoDuplicado = EquipoDataGridView.Rows(x - 1).Cells("DESEQUIPODataGridViewTextBoxColumn").Value Then
                    Bandera = 1
                End If
            End If

            If Bandera = 1 Then
                MessageBox.Show("Este equipo ya se encuentra en este producto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TipoClieComboBox.Focus()
                Exit Sub
            End If
        Next
        '#########################################################################################################
        Dim id_equipo As Integer = cbxEquipo.SelectedValue
        Dim equipo As String = cbxEquipo.Text
        Dim id As Integer = DsEquipoRel.PRODUCTO_EQUIPO_REL.Rows.Count + 1

        Dim RowNew As DataRow = DsEquipoRel.PRODUCTO_EQUIPO_REL.NewRow
        RowNew("ID") = id
        RowNew("IDEQUIPO") = id_equipo
        RowNew("DESEQUIPO") = equipo
        DsEquipoRel.PRODUCTO_EQUIPO_REL.Rows.Add(RowNew)

        PRODUCTOEQUIPORELBindingSource.DataSource = DsEquipoRel.PRODUCTO_EQUIPO_REL.DefaultView

        Dim RowNew2 As DataRow = DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE.NewRow
        RowNew2("IDEQUIPO") = id_equipo
        DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE.Rows.Add(RowNew2)


    End Sub

    Private Sub DelEquipo_Click(sender As Object, e As EventArgs) Handles DelEquipo.Click
        If EquipoDataGridView.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Dim id As Integer = 0
        For Each Row As DataGridViewRow In EquipoDataGridView.SelectedRows
            id = Row.Cells("ID").Value.ToString
        Next

        For Each Row As DataRow In DsEquipoRel.PRODUCTO_EQUIPO_REL.Select("id=" & id)
            DsEquipoRel.PRODUCTO_EQUIPO_REL.Rows.Remove(Row)
        Next

        If DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE.Rows.Count > 0 Then
            For Each Row As DataRow In DsEquipoRel.PRODUCTO_EQUIPO_REL_SIMPLE.Select("id=" & id)
                Row.Delete()
            Next
        End If

        PRODUCTOEQUIPORELBindingSource.DataSource = DsEquipoRel.PRODUCTO_EQUIPO_REL.DefaultView


    End Sub
End Class