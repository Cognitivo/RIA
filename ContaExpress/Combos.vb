Imports System.Data.SqlClient
Imports System.IO
Imports Osuna.Utiles.Conectividad

Public Class Combos
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private objCommand As New SqlCommand

    Dim Aleatorio, Maximo, Minimo, CodigoExistente As String
    Dim sql As String
    Dim is_New As Integer = 0

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub btnGenerarCodigo_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarCodigo.Click
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

            CodPais = "569"  'Colocamos el codigo del pais correspondiente a Ireland , considreando que este pais no vende a Paraguay

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

            txtCodigo.Text = Aleatorio
        Catch ex As Exception
            MessageBox.Show("Error al Generará el Código Aleatorio", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Combos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsCombos.LISTAPRODUCTOS' table. You can move, or remove it, as needed.
        Me.LISTAPRODUCTOSTableAdapter.Fill(Me.DsCombos.LISTAPRODUCTOS)
        Me.DEPOSITOTableAdapter.Fill(Me.DsCombos.DEPOSITO)
        Me.LISTADEPRECIOTableAdapter.Fill(Me.DsCombos.LISTADEPRECIO)
        Me.LISTACOMBOSTableAdapter.Fill(Me.DsCombos.LISTACOMBOS)
        Me.UNIDADMEDIDATableAdapter.Fill(Me.DsCombos.UNIDADMEDIDA)
        Me.IVATableAdapter.Fill(Me.DsCombos.IVA)


        Deshabilitar()
        BuscaProductoTextBox.Focus()
    End Sub

    Private Sub Deshabilitar()
        tbxProducto.Enabled = False
        txtCodigo.Enabled = False
        cbxTipoIva.Enabled = False
        btnGenerarCodigo.Enabled = False
        pnlProducto.Enabled = False
        pnlListaPrecio.Enabled = False
        cbxMedida.Enabled = False

        BuscaProductoTextBox.Enabled = True
        dgwProductosCombos.Enabled = True

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
    End Sub

    Private Sub Habilitar()
        tbxProducto.Enabled = True
        txtCodigo.Enabled = True
        cbxTipoIva.Enabled = True
        btnGenerarCodigo.Enabled = True
        pnlProducto.Enabled = True
        pnlListaPrecio.Enabled = True
        cbxMedida.Enabled = True

        BuscaProductoTextBox.Enabled = False
        dgwProductosCombos.Enabled = False

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
    End Sub

    Private Sub PictureBoxNuevo_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxNuevo.Click
        is_New = 1

        Habilitar()
        LISTACOMBOSBindingSource.AddNew()
        LimpiarGrillaCodigo()
        tbxProducto.Focus()
    End Sub

    Private Sub LimpiarGrillaCodigo()
        Try
            If dgwListaProductos.RowCount >= 1 Then
                For i As Integer = 0 To dgwListaProductos.RowCount - 1
                    dgwListaProductos.Rows.Remove(dgwListaProductos.CurrentRow)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tbxProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 42 Then
            upcProductoCombo.Show()

            tbxBuscarProdcutoCombo.Text = ""
            tbxBuscarProdcutoCombo.Focus()
            e.Handled = True
        End If

        If KeyAscii = 13 Then
            e.Handled = True
            txtCodigo.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            cbxTipoIva.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxTipoIva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoIva.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            cbxMedida.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCantidad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            cbxDepositoCombo.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCodigoProductos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCodigoProductos.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 42 Then
            upcProductos.Show()

            BuscarProductoTextBox.Text = ""
            BuscarProductoTextBox.Focus()
            e.Handled = True
        End If

        If KeyAscii = 13 Then
            e.Handled = True
            tbxCantidad.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnAsterisco_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsterisco.Click
        upcProductos.Show()

        BuscarProductoTextBox.Text = ""
        BuscarProductoTextBox.Focus()
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        Try
            LISTAPRODUCTOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAgregarProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarProducto.Click
        'Insertamos en la grilla de Productos
       
        Try
            If tbxCodigoProductos.Text = "" Then
                MessageBox.Show("Seleccione un Producto", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxCodigoProductos.Focus()
                Exit Sub
            End If

            If tbxCantidad.Text = "" Then
                MessageBox.Show("Ingrese la Cantidad", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxCantidad.Focus()
                Exit Sub
            End If

            If cbxDepositoCombo.Text = "" Then
                MessageBox.Show("Seleccione un Desposito", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxDepositoCombo.Focus()
                Exit Sub
            End If

            'Dim cantidad As String
            'cantidad = tbxCantidad.Text.Replace(",", ".")
            COMBOSDETBindingSource.AddNew()

            Dim c As Integer = dgwListaProductos.RowCount
            dgwListaProductos.Rows(c - 1).Cells("SUBCODCODIGODataGridViewTextBoxColumn").Value = tbxCodProductoInsert.Text
            dgwListaProductos.Rows(c - 1).Cells("CODIGODataGridViewTextBoxColumn2").Value = tbxCodigoProductos.Text
            dgwListaProductos.Rows(c - 1).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value = tbxNombreProductos.Text
            dgwListaProductos.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value = CDec(tbxCantidad.Text).ToString
            dgwListaProductos.Rows(c - 1).Cells("DESSUCURSAL").Value = cbxDepositoCombo.Text
            dgwListaProductos.Rows(c - 1).Cells("CODSUCURSAL").Value = cbxDepositoCombo.SelectedValue
            dgwListaProductos.Rows(c - 1).Cells("EstadoGrilla").Value = "I" 'Insert

            'LIMPIAMOS
            tbxCodigoProductos.Text = "" : tbxNombreProductos.Text = "" : tbxCantidad.Text = "" : tbxCodigoProductos.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProductosGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosGridView.CellDoubleClick
        Try
            'Obtenermos los valores
            tbxCodProductoInsert.Text = ProductosGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn2").Value
            tbxCodigoProductos.Text = ProductosGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn3").Value
            tbxNombreProductos.Text = ProductosGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn3").Value

            upcProductos.Close()
            tbxCantidad.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBoxGuardar_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxGuardar.Click
        Dim VCodProducto As Integer

        'Verificamos que halla cargado los datos correspondientes
        If tbxProducto.Text = "" Then
            MessageBox.Show("Ingrese el Producto", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxProducto.Focus()
            Exit Sub
        End If

        If txtCodigo.Text = "" Then
            MessageBox.Show("Ingrese el Codigo del Producto", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCodigo.Focus()
            Exit Sub
        End If

        If cbxTipoIva.Text = "" Then
            MessageBox.Show("Seleccione el Tipo de IVA", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxTipoIva.Focus()
            Exit Sub
        End If

        If dgwListaProductos.Rows.Count = 0 Then
            MessageBox.Show("Ingrese la lista de Productos para el Combo", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxCodigoProductos.Focus()
            Exit Sub
        End If
        If dgwListaPrecio.Rows.Count = 0 Then
            MessageBox.Show("Ingrese la lista de Precios para el Combo", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgwListaPrecio.Focus()
            Exit Sub
        End If
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        If is_New = 1 Then
            Try
                'Producto Combo
                If lblCodProducto.Text <> "" Then
                    sql = "UPDATE PRODUCTOS SET DESPRODUCTO = '" & tbxProducto.Text & "', CODIVA = " & cbxTipoIva.SelectedValue & ", CODMEDIDA = " & cbxMedida.SelectedValue & _
                       ", IS_COMBO = 1, PRODUCTO = 4, SERVICIO = 0  WHERE CODPRODUCTO = " & lblCodProducto.Text

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    'Codigo del Producto Combo
                    sql = ""
                    sql = "UPDATE CODIGOS SET CODIGO =  '" & txtCodigo.Text & "' WHERE CODPRODUCTO = " & lblCodProducto.Text & " "

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    'Productos Detalle - Productos del Combos
                    sql = ""
                    For i = 0 To dgwListaProductos.Rows.Count - 1
                        sql = sql + "INSERT INTO COMBOS (CODPRODUCTO,SUBCODCODIGO,CANTIDAD,CODSUCURSAL) " & _
                            "VALUES('" & lblCodProducto.Text & "','" & dgwListaProductos.Rows(i).Cells("SUBCODCODIGODataGridViewTextBoxColumn").Value & "', CONVERT(DECIMAL(18,4), REPLACE( '" & dgwListaProductos.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value & "',',','.'))" & _
                            ", '" & dgwListaProductos.Rows(i).Cells("CODSUCURSAL").Value & "')  "
                    Next

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()


                Else
                    sql = "INSERT INTO PRODUCTOS (DESPRODUCTO, CODUSUARIO, FECGRA, CODIVA, ESTADO , CODMEDIDA , SERVICIO , PRODUCTO,IS_COMBO,PROMOCION) " & _
                      "VALUES ('" & tbxProducto.Text & "', " & UsuCodigo & ", CONVERT(DATETIME, '" & Today & "', 103), " & cbxTipoIva.SelectedValue & "," & _
                      "0," & cbxMedida.SelectedValue & ",0,4,1,0)   " & _
                      "SELECT CODPRODUCTO FROM PRODUCTOS WHERE CODPRODUCTO = SCOPE_IDENTITY();"

                    cmd.CommandText = sql
                    VCodProducto = cmd.ExecuteScalar()

                    'Codigo del Producto Combo
                    sql = ""
                    sql = "INSERT INTO CODIGOS (CODIGO, CODPRODUCTO, FECGRA,VENCIMIENTO,PESABLE,BALANZA)  " & _
                          " VALUES ('" & txtCodigo.Text & "', " & VCodProducto & ", " & Today & ", 0, 0,0) "

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    'Productos Detalle - Productos del Combos
                    sql = ""
                    For i = 0 To dgwListaProductos.Rows.Count - 1
                        sql = sql + "INSERT INTO COMBOS (CODPRODUCTO,SUBCODCODIGO,CANTIDAD,CODSUCURSAL) " & _
                            "VALUES(" & VCodProducto & "," & dgwListaProductos.Rows(i).Cells("SUBCODCODIGODataGridViewTextBoxColumn").Value & "," & dgwListaProductos.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value & " , " & _
                            dgwListaProductos.Rows(i).Cells("CODSUCURSAL").Value & ")  "
                    Next

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    'Lista de Precio
                    sql = ""
                    For i = 0 To dgwListaPrecio.Rows.Count - 1
                        sql = sql + "INSERT INTO PRECIO (CODTIPOCLIENTE,CODSUCURSAL,CODPRODUCTO,CODMONEDA,PRECIOVENTA,FECGRA,CANTIDAD) " & _
                              "VALUES('" & dgwListaPrecio.Rows(i).Cells("CODTIPOCLIENTEDataGridViewTextBoxColumn").Value & "','" & SucCodigo & "','" & VCodProducto & "', 1 ,'" & dgwListaPrecio.Rows(i).Cells("PRECIOVENTADataGridViewTextBoxColumn").Value & _
                              "', CONVERT(DATETIME, '" & Today & "', 103), 1)    "
                    Next

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
                
                myTrans.Commit()

            Catch ex As Exception
                MessageBox.Show("Error al Guardar : " & ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                sqlc.Close()
            End Try

        Else
            Try
                'Producto Combo
                sql = "UPDATE PRODUCTOS SET DESPRODUCTO = '" & tbxProducto.Text & "', CODIVA = " & cbxTipoIva.SelectedValue & ", CODMEDIDA = " & cbxMedida.SelectedValue & _
                       "WHERE CODPRODUCTO = " & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
  
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                'Codigo del Producto Combo
                sql = ""
                sql = "UPDATE CODIGOS SET CODIGO = '" & txtCodigo.Text & "' WHERE CODPRODUCTO = " & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                'Productos Detalle - Productos del Combos
                sql = ""
                For i = 0 To dgwListaProductos.Rows.Count - 1
                    If dgwListaProductos.Rows(i).Cells("EstadoGrilla").Value = "I" Then  'Insertar
                        sql = sql + "INSERT INTO COMBOS (CODPRODUCTO,SUBCODCODIGO,CANTIDAD,CODSUCURSAL) VALUES(" & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value & "," & _
                              dgwListaProductos.Rows(i).Cells("SUBCODCODIGODataGridViewTextBoxColumn").Value & "," & dgwListaProductos.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value & ",  " & _
                              dgwListaProductos.Rows(i).Cells("CODSUCURSAL").Value & ")  "

                    ElseIf dgwListaProductos.Rows(i).Cells("EstadoGrilla").Value = "D" Then 'Eliminar
                        sql = sql + "DELETE FROM COMBOS WHERE SUBCODCODIGO = " & dgwListaProductos.Rows(i).Cells("SUBCODCODIGODataGridViewTextBoxColumn").Value & " AND " & _
                            "CODPRODUCTO = " & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                    End If
                Next

                If sql <> "" Then
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If

                'Lista de Precio
                sql = ""
                For i = 0 To dgwListaPrecio.Rows.Count - 1
                    If dgwListaPrecio.Rows(i).Cells("EstadoGrillaPrecio").Value = "I" Then 'Insertar
                        sql = sql + "INSERT INTO PRECIO (CODTIPOCLIENTE,CODSUCURSAL,CODPRODUCTO,CODMONEDA,PRECIOVENTA,FECGRA,CANTIDAD) " & _
                              "VALUES(" & dgwListaPrecio.Rows(i).Cells("CODTIPOCLIENTEDataGridViewTextBoxColumn").Value & "," & SucCodigo & "," & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value & _
                              ", 1 ," & dgwListaPrecio.Rows(i).Cells("PRECIOVENTADataGridViewTextBoxColumn").Value & ", CONVERT(DATETIME, '" & Today & "', 103), 1)    "

                    ElseIf dgwListaPrecio.Rows(i).Cells("EstadoGrillaPrecio").Value = "D" Then 'Eliminar
                        sql = sql + "DELETE FROM PRECIO WHERE CODTIPOCLIENTE = " & dgwListaPrecio.Rows(i).Cells("CODTIPOCLIENTEDataGridViewTextBoxColumn").Value & " AND " & _
                            "CODPRODUCTO = " & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                    End If
                Next

                If sql <> "" Then
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If

                myTrans.Commit()

            Catch ex As Exception
                MessageBox.Show("Error al Guardar : " & ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                sqlc.Close()
            End Try

        End If

        Deshabilitar()
        Me.LISTACOMBOSTableAdapter.Fill(Me.DsCombos.LISTACOMBOS)
        COMBOSDETTableAdapter.Fill(DsCombos.COMBOSDET, CInt(dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value))

        is_New = 0 : lblCodProducto.Text = ""
        BuscaProductoTextBox.Focus()
    End Sub

    Private Sub cbxMedida_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMedida.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            tbxCodigoProductos.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgwProductosCombos_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwProductosCombos.SelectionChanged
        Try
            If dgwProductosCombos.Rows.Count <> 0 Then
                COMBOSDETTableAdapter.Fill(DsCombos.COMBOSDET, CInt(dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value))
                PRECIOSDETTableAdapter.Fill(DsCombos.PRECIOSDET, CInt(dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBoxCancelar_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxCancelar.Click
        Try
            LISTACOMBOSBindingSource.CancelEdit()
            Me.LISTACOMBOSTableAdapter.Fill(Me.DsCombos.LISTACOMBOS)
        Catch ex As Exception
        End Try

        Deshabilitar()
        is_New = 0 : lblCodProducto.Text = ""
        BuscaProductoTextBox.Focus()
    End Sub

    Private Sub BuscaProductoTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscaProductoTextBox.TextChanged
        Try
            LISTACOMBOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscaProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscaProductoTextBox.Text & "%' "
        Catch ex As Exception
        End Try
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

    Private Sub PrecioTxtMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioTxtMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            btnAgregarPrecio.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAgregarPrecio_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarPrecio.Click
        'Insertamos en la grilla de Precios
        Try
            If TipoClieComboBox.Text = "" Then
                MessageBox.Show("Seleccione una Lista de Precio", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TipoClieComboBox.Focus()
                Exit Sub
            End If

            If PrecioTxtMoneda.Text = "" Then
                MessageBox.Show("Ingrese el Precio", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PrecioTxtMoneda.Focus()
                Exit Sub
            End If

            PRECIOSDETBindingSource.AddNew()

            Dim c As Integer = dgwListaPrecio.RowCount
            dgwListaPrecio.Rows(c - 1).Cells("DESTIPOCLIENTEDataGridViewTextBoxColumn").Value = TipoClieComboBox.Text
            dgwListaPrecio.Rows(c - 1).Cells("CODTIPOCLIENTEDataGridViewTextBoxColumn").Value = TipoClieComboBox.SelectedValue
            dgwListaPrecio.Rows(c - 1).Cells("PRECIOVENTADataGridViewTextBoxColumn").Value = PrecioTxtMoneda.Text
            dgwListaPrecio.Rows(c - 1).Cells("CODPRODUCTO").Value = CInt(dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value)
            dgwListaPrecio.Rows(c - 1).Cells("EstadoGrillaPrecio").Value = "I" 'Insert

            'LIMPIAMOS
            TipoClieComboBox.Text = "" : PrecioTxtMoneda.Text = "" : TipoClieComboBox.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBoxModifica_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxModifica.Click
        Habilitar()
        tbxProducto.Focus()
    End Sub

    Private Sub btnEliminarProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarProducto.Click
        Try
            If dgwListaProductos.Rows.Count <> 0 Then
                dgwListaProductos.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value = "Para Eliminar"
                dgwListaProductos.CurrentRow.Cells("EstadoGrilla").Value = "D" 'Para Eliminar
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEliminarPrecio_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarPrecio.Click
        Try
            If dgwListaPrecio.Rows.Count <> 0 Then
                dgwListaPrecio.CurrentRow.Cells("DESTIPOCLIENTEDataGridViewTextBoxColumn").Value = "Para Eliminar"
                dgwListaPrecio.CurrentRow.Cells("EstadoGrillaPrecio").Value = "D" 'Para Eliminar
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBoxEliminar_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxEliminar.Click
        If MessageBox.Show("¿Esta seguro que quiere eliminar el Producto?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        '###########VALIDAMOS QUE NO TENGA STOCK############################
        Dim ExisteStock As Integer
        Dim w As New Funciones.Funciones

        ExisteStock = w.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO = " & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value & " AND STOCKACTUAL > ", 1)
        If ExisteStock > 0 Then
            MessageBox.Show("El Producto tiene existencia en Stock y no puede eliminarse", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            EliminaCodigos()
            EliminaPrecios()
            EliminaComboDetalle()
            EliminaProducto()

            myTrans.Commit()

        Catch ex As SqlException
            Try
                myTrans.Rollback("Eliminar")
            Catch
            End Try

            Dim NroError As Integer = ex.Number
            Dim Mensaje As String = ex.Message

            If NroError = 547 Then
                CambiarEstado = 1
                MessageBox.Show("El Producto que desea eliminar tiene relacion otra tabla del Sistema, elimine primero la otra relación", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Ocurrió un error al tratar de Eliminar el Producto" + ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Finally
            sqlc.Close()
        End Try

        Deshabilitar()
        Me.LISTACOMBOSTableAdapter.Fill(Me.DsCombos.LISTACOMBOS)
        COMBOSDETTableAdapter.Fill(DsCombos.COMBOSDET, CInt(dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value))
        BuscaProductoTextBox.Focus()
    End Sub

    Private Sub EliminaCodigos()
        Sql = ""
        sql = " DELETE FROM CODIGOS  WHERE CODPRODUCTO= " & CInt(dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminaPrecios()
        sql = ""
        sql = " DELETE FROM PRECIO  WHERE CODPRODUCTO= '" & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value & "'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminaComboDetalle()
        sql = ""
        sql = " DELETE FROM COMBOS WHERE CODPRODUCTO= " & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminaProducto()
        Try
            sql = ""
            sql = "DELETE PRODUCTOS WHERE CODPRODUCTO = " & dgwProductosCombos.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value & ""

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbxDepositoCombo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxDepositoCombo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            e.Handled = True
            btnAgregarProducto.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxBuscarProdcutoCombo_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxBuscarProdcutoCombo.TextChanged
        LISTAPRODUCTOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & tbxBuscarProdcutoCombo.Text & "%' OR CODIGO LIKE '%" & tbxBuscarProdcutoCombo.Text & "%'"
    End Sub

    Private Sub pbxBuscarCombos_Click(sender As System.Object, e As System.EventArgs) Handles pbxBuscarCombos.Click
        upcProductoCombo.Show()

        tbxBuscarProdcutoCombo.Text = ""
        tbxBuscarProdcutoCombo.Focus()
    End Sub

    Private Sub dgwProdcutoCombo_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwProdcutoCombo.CellDoubleClick
        If dgwProdcutoCombo.Rows.Count <> 0 Then
            lblCodProducto.Text = dgwProdcutoCombo.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
            tbxProducto.Text = dgwProdcutoCombo.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value
            txtCodigo.Text = dgwProdcutoCombo.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn1").Value
            cbxTipoIva.SelectedValue = dgwProdcutoCombo.CurrentRow.Cells("CODIVA").Value
            cbxMedida.SelectedValue = dgwProdcutoCombo.CurrentRow.Cells("CODMEDIDA").Value

            'debemos cargar la lista de precios 
            Dim objCommand As New SqlCommand

            Try
                objCommand.CommandText = "SELECT dbo.PRECIO.CODTIPOCLIENTE, dbo.PRECIO.CODPRODUCTO, dbo.PRECIO.PRECIOVENTA, dbo.TIPOCLIENTE.DESTIPOCLIENTE " & _
                                         "FROM dbo.PRECIO INNER JOIN dbo.TIPOCLIENTE ON dbo.PRECIO.CODTIPOCLIENTE = dbo.TIPOCLIENTE.CODTIPOCLIENTE " & _
                                         "WHERE dbo.PRECIO.CODPRODUCTO = " & lblCodProducto.Text

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()

                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()
                Dim c As Integer

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        PRECIOSDETBindingSource.AddNew()

                        c = dgwListaPrecio.RowCount
                        dgwListaPrecio.Rows(c - 1).Cells("DESTIPOCLIENTEDataGridViewTextBoxColumn").Value = odrConfig("DESTIPOCLIENTE")
                        dgwListaPrecio.Rows(c - 1).Cells("CODTIPOCLIENTEDataGridViewTextBoxColumn").Value = odrConfig("CODTIPOCLIENTE")
                        dgwListaPrecio.Rows(c - 1).Cells("PRECIOVENTADataGridViewTextBoxColumn").Value = odrConfig("PRECIOVENTA")
                        dgwListaPrecio.Rows(c - 1).Cells("CODPRODUCTO").Value = CInt(lblCodProducto.Text)
                        dgwListaPrecio.Rows(c - 1).Cells("EstadoGrillaPrecio").Value = "S"
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try
            upcProductoCombo.Close()
        End If
    End Sub

End Class