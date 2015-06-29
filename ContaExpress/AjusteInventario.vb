Imports System.Data.SqlClient
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class AjusteInventario
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Dim sql, tipomovimientoproducto As String

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim sel As Integer
    Dim ins As Integer
    Dim upd As Integer
    Dim del As Integer
    Dim pri As Integer
    Dim anu As Integer
    Dim CodigoDeposito As String
    Dim permiso As Double
    Dim elijioproducto As Boolean
    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub
    Private Sub SUCURSALBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.SUCURSALBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DsInventario)
    End Sub

    Private Sub AjusteInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 138)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        lbxPanel.Text = "Ajuste de Inventario"
        buscarAjuste.BringToFront()
        txtCodigoAjuste.Focus()
        Me.SUCURSALTableAdapter.Fill(Me.DsInventario.SUCURSAL)
        Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock' "

        elijioproducto = True

        Try
            Me.MOVPRODUCTOSTableAdapter.FillBySuc(DsInventario1.MOVPRODUCTOS, CodigoDeposito)
            CodigoDeposito = dgvDeposito.CurrentRow.Cells("CODSUCURSALDataGridViewTextBoxColumn3").Value
            Me.TransferenciaMovimientoTableAdapter.Fill(DsInventario1.TransferenciaMovimiento, CodigoDeposito)
        Catch ex As Exception

        End Try
        PanelProducto.BringToFront()
        dtpFechaAjuste.Text = Today()

        DataGridView3.Sort(FECHAMTO3, System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub PictureBoxProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxProducto.Click
        lbxPanel.Visible = True : buscarAjuste.Visible = True : BuscarTextBox.Visible = True : PictureBox2.Visible = True

        buscarAjuste.BringToFront()
        elijioproducto = True
        lbxPanel.Text = "Ajuste de Inventario"

        PictureBoxProducto.Image = My.Resources.StockActive
        PictureBoxProducto.Cursor = Cursors.Arrow
        PictureBoxTransferencia.Image = My.Resources.Transfer
        PictureBoxTransferencia.Cursor = Cursors.Hand
        PictureBox3.Image = My.Resources.Create
        PictureBox3.Cursor = Cursors.Hand
        MOVPRODUCTOBindingSource.RemoveFilter()
        PanelProducto.BringToFront()
        Me.MOVPRODUCTOSTableAdapter.FillBySuc(Me.DsInventario.MOVPRODUCTOS, CodigoDeposito)
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If TextBoxCodCodigo.Text = "" Or TextBoxCodProducto.Text = "" Then
            MessageBox.Show("Seleccione un Producto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxProducto.Focus()
            tbxProducto.BackColor = Color.Pink
            Exit Sub
        End If
        If tbxConceptoAjuste.Text = "" Then
            MessageBox.Show("Ingrese un Concepto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxConceptoAjuste.Focus()
            tbxConceptoAjuste.BackColor = Color.Pink
            Exit Sub
        End If
        If ComboBoxProductos.Text = "" Or IsDBNull(ComboBoxProductos.SelectedValue) Then
            MessageBox.Show("Selecione un Tipo de Ajuste", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ComboBoxProductos.Focus()
            ComboBoxProductos.BackColor = Color.Pink
            Exit Sub
        End If

        If String.IsNullOrEmpty(CantidadProdTxt.Text) Then
            MessageBox.Show("Ingrese alguna Cantidad", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CantidadProdTxt.Focus()
            CantidadProdTxt.BackColor = Color.Pink
            Exit Sub
        ElseIf CDec(CantidadProdTxt.Text) = 0 Then
            MessageBox.Show("Cantidad del Ajuste no puede ser Cero (0)", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CantidadProdTxt.Focus()
            CantidadProdTxt.BackColor = Color.Pink
            Exit Sub
        End If

        Dim f As New Funciones.Funciones
        Dim existe As Integer
        Try
            existe = f.FuncionConsulta("CODDEPOSITO", "STOCKDEPOSITO", "CODCODIGO=" & CDec(TextBoxCodCodigo.Text) & " AND CODDEPOSITO", dgvDeposito.CurrentRow.Cells("CODSUCURSALDataGridViewTextBoxColumn3").Value.ToString)
        Catch ex As Exception

        End Try
        If existe = 0 Then

            MessageBox.Show("Producto no tiene Stock para Deposito: " & dgvDeposito.CurrentRow.Cells("DESSUCURSALDataGridViewTextBoxColumn3").Value, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Exit Sub
        End If

        InsertarProducto()

    End Sub

    Private Sub InsertarProducto()
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            'cargastock()
            insertamovimientoproducto()
            myTrans.Commit()
            limpiarcampos()

            Me.MOVPRODUCTOSTableAdapter.FillBySuc(Me.DsInventario.MOVPRODUCTOS, CodigoDeposito)
            Me.MOVPRODUCTOBindingSource.MoveFirst()
        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
                MessageBox.Show("Error al Ajustar Stock: " + ex.Message, "PosExpress")
            End Try
        End Try

        sqlc.Close()

    End Sub

    Private Sub TransferenciaProducto(ByVal existe As Integer)
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            insertamovimientoproductotransferencia()
            myTrans.Commit()
            limpiarcampos()

            CodigoDeposito = dgvDeposito.CurrentRow.Cells("CODSUCURSALDataGridViewTextBoxColumn3").Value
            Me.TransferenciaMovimientoTableAdapter.Fill(Me.DsInventario.TransferenciaMovimiento, CodigoDeposito)

            CodModID.Text = "" : TxtConceptoTransf.Text = "" : txtCodigo.Text = "" : TxtProductoTransf.Text = ""
            CodModID.Focus()

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
                CodModID.Text = ""
                CodModID.Focus()
            Catch
            End Try
            MessageBox.Show("Error al Transferir Producto: " + ex.Message, "POSEXPRESS")
            '
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub insertamovimientoproducto()
        Dim w As New Funciones.Funciones
        Dim Concepto As String = "Ajuste. " + tbxConceptoAjuste.Text
        Dim ComboCantidad As Integer

        Dim cantidad, cantidadAux As String
        cantidadAux = ""
        If ComboBoxProductos.Text = "En Menos" Then
            cantidadAux = CDec(CantidadProdTxt.Text) * -1
        Else
            cantidadAux = CDec(CantidadProdTxt.Text)
        End If

        cantidad = Funciones.Cadenas.QuitarCad(cantidadAux, ".")
        cantidad = Replace(cantidad, ",", ".")

        sql = ""
        sql = " INSERT INTO MOVPRODUCTO (CODCODIGO,CONCEPTO,CANTIDAD,FECHAMOVIMIENTO,CODUSUARIO, CODDEPOSITO,MODULO,STOCK,COSTEABLE)" & _
              " VALUES (" & CDec(TextBoxCodCodigo.Text) & ",'" & Concepto & "',  " & cantidad & ", CONVERT(DATETIME,'" & dtpFechaAjuste.Text & "',103) ," & _
              "" & UsuCodigo & "," & dgvDeposito.CurrentRow.Cells("CODSUCURSALDataGridViewTextBoxColumn3").Value & ",13,1,0) "


        'ESTO SOLO ES EN CASO DE QUE SEA UN COMBO
        Dim IsCombo As Integer = w.FuncionConsulta("dbo.PRODUCTOS.PRODUCTO", " dbo.CODIGOS INNER JOIN  dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO", "dbo.CODIGOS.CODCODIGO", CDec(TextBoxCodCodigo.Text))
        If IsCombo = 4 Then
            Dim objCommand As New SqlCommand
            Try
                objCommand.CommandText = "SELECT dbo.COMBOS.CODPRODUCTO, dbo.COMBOS.SUBCODCODIGO, dbo.COMBOS.CANTIDAD, dbo.CODIGOS.CODCODIGO, dbo.COMBOS.CODSUCURSAL  " & _
                                         "FROM dbo.PRODUCTOS INNER JOIN dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO INNER JOIN  " & _
                                         "dbo.COMBOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.COMBOS.CODPRODUCTO   " & _
                                         "WHERE (dbo.CODIGOS.CODCODIGO =" & CDec(TextBoxCodCodigo.Text) & ")"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        If ComboBoxProductos.Text = "En Menos" Then
                            ComboCantidad = CInt(odrConfig("CANTIDAD")) * CInt(CantidadProdTxt.Text)
                        Else
                            ComboCantidad = (CInt(odrConfig("CANTIDAD")) * CInt(CantidadProdTxt.Text)) * -1
                        End If

                        sql = sql + " INSERT INTO MOVPRODUCTO (CODCODIGO,CONCEPTO,CANTIDAD,FECHAMOVIMIENTO,CODUSUARIO, CODDEPOSITO,MODULO,STOCK,COSTEABLE)" & _
                              " VALUES (" & odrConfig("SUBCODCODIGO") & ",'" & Concepto & "',  " & ComboCantidad & ", CONVERT(DATETIME,'" & dtpFechaAjuste.Text & "',103) ," & _
                              UsuCodigo & "," & odrConfig("CODSUCURSAL") & ",13,1,0) "
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try
        End If

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub insertamovimientoproductotransferencia()
        Dim w As New Funciones.Funciones
        Dim cantidad As String
        Dim Concepto As String = "Transf. " + TxtConceptoTransf.Text

        cantidad = Funciones.Cadenas.QuitarCad(TxtCantidadTransferido.Text, ".")
        cantidad = Replace(cantidad, ",", ".")

        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim Concat As String = dtpFecha.Text
        Dim Concatenar As String = Concat & " " + hora

        '--------------- INSERTA EL MOVIMIENTO EN LA TRANSFERENCIA DE ORIGEN ---------------

        sql = ""
        sql = " INSERT INTO MOVPRODUCTO " & _
        "(CODCODIGO,CONCEPTO,CANTIDAD,FECHAMOVIMIENTO,CODUSUARIO, CODDEPOSITO,MODULO,STOCK,COSTEABLE,NROMOVIMIENTO,TIPOPRODUCCION,MODULOTRANSID)" & _
        " VALUES (" & CDec(TxtCodCodigoTransf.Text) & ",'" & Concepto & "',  -" & cantidad & ", convert(datetime,'" & Concatenar & "',103) ," & _
        "" & UsuCodigo & "," & CmbSucursalOrigen.SelectedValue & ",13,1,0," & CDec(CodModID.Text) & "," & CmbSucursalDestino.SelectedValue & "," & CDec(CodModID.Text) & ") "

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()


        '--------------- INSERTA EL MOVIMIENTO EN LA TRANSFERENCIA DESTINO ---------------
        sql = ""
        sql = " INSERT INTO MOVPRODUCTO " & _
        "(CODCODIGO,CONCEPTO,CANTIDAD,FECHAMOVIMIENTO,CODUSUARIO, CODDEPOSITO,MODULO,STOCK,COSTEABLE,NROMOVIMIENTO,TIPOPRODUCCION,MODULOTRANSID)" & _
        " VALUES (" & CDec(TxtCodCodigoTransf.Text) & ",'" & Concepto & "'," & _
        "" & cantidad & ", convert(datetime,'" & Concatenar & "',103) ," & _
        "" & UsuCodigo & "," & CmbSucursalDestino.SelectedValue & ",13,1,0," & CDec(CodModID.Text) & "," & CmbSucursalOrigen.SelectedValue & "," & CDec(CodModID.Text) & ") "

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub limpiarcampos()
        txtCodigoAjuste.Text = ""
        tbxProducto.Text = ""
        TxtProductoTransf.Text = ""
        TextBoxCodCodigo.Text = ""
        TxtCodCodigoTransf.Text = ""
        TextBoxCodProducto.Text = ""
        TxtCodProductoTransf.Text = ""
        CantidadProdTxt.Text = ""
        TxtCantidadTransferido.Text = ""
        txtCodigo.Text = ""
    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            RadGridView1.Focus()
        End If
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        Try
            Me.CODIGOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tbxProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            TextBoxCodProducto.Text = ""
            TextBoxCodCodigo.Text = ""
            BuscarProductoTextBox.Text = ""
            Try
                Me.CODIGOSTableAdapter.Fill(Me.DsInventario.CODIGOS, "%", "%", "%")

            Catch ex As Exception

            End Try
            UltraPopupControlContainer1.PopupControl = ProductosGroupBox
            UltraPopupControlContainer1.Show()
            'BuscarProductoTextBox.Text = ""
            BuscarProductoTextBox.Focus()
            e.Handled = True
        End If

        If KeyAscii = 13 Then
            ComboBoxProductos.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CantidadProdTxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadProdTxt.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)


        If KeyAscii = 13 Then
            BtnGuardar.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub RadGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles RadGridView1.CellDoubleClick
        Dim codmedida As Integer
        Dim f As New Funciones.Funciones
        Try
            If RadGridView1.RowCount = 0 Then
                BuscarProductoTextBox.Text = ""
                TextBoxCodCodigo.Text = ""
                tbxProducto.Focus()
                UltraPopupControlContainer1.Close()

            Else

                If IsDBNull(RadGridView1.CurrentRow) Then
                    BuscarProductoTextBox.Text = ""
                    tbxProducto.Focus()
                    UltraPopupControlContainer1.Close()

                Else
                    If elijioproducto = True Then
                        If IsDBNull(RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value) Then
                        Else
                            TextBoxCodProducto.Text = RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value
                        End If

                        If IsDBNull(RadGridView1.CurrentRow.Cells("CODCODIGO").Value) Then
                        Else
                            TextBoxCodCodigo.Text = RadGridView1.CurrentRow.Cells("CODCODIGO").Value
                        End If

                        If IsDBNull(RadGridView1.CurrentRow.Cells("PRODUCTO").Value) Then
                        Else
                            tbxProducto.Text = RadGridView1.CurrentRow.Cells("PRODUCTO").Value
                        End If
                        If IsDBNull(RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value) Then
                        Else
                            codmedida = f.FuncionConsulta("CODMEDIDA", "PRODUCTOS", "CODPRODUCTO", RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value)
                            'LabelMedida.Text = f.FuncionConsultaString("DESMEDIDA", "UNIDADMEDIDA", "CODMEDIDA", codmedida)
                        End If
                        If IsDBNull(RadGridView1.CurrentRow.Cells("CODIGO").Value) Then
                        Else
                            txtCodigoAjuste.Text = RadGridView1.CurrentRow.Cells("CODIGO").Value
                        End If

                        BuscarProductoTextBox.Text = ""
                        ComboBoxProductos.Focus()
                    Else
                        If IsDBNull(RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value) Then
                        Else
                            TxtCodProductoTransf.Text = RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value
                        End If

                        If IsDBNull(RadGridView1.CurrentRow.Cells("CODCODIGO").Value) Then
                        Else
                            TxtCodCodigoTransf.Text = RadGridView1.CurrentRow.Cells("CODCODIGO").Value
                        End If

                        If IsDBNull(RadGridView1.CurrentRow.Cells("PRODUCTO").Value) Then
                        Else
                            TxtProductoTransf.Text = RadGridView1.CurrentRow.Cells("PRODUCTO").Value
                        End If
                        If IsDBNull(RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value) Then
                        Else
                            codmedida = f.FuncionConsulta("CODMEDIDA", "PRODUCTOS", "CODPRODUCTO", RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value)
                            'LblUnidadMedTransf.Text = f.FuncionConsultaString("DESMEDIDA", "UNIDADMEDIDA", "CODMEDIDA", codmedida)
                        End If
                        If IsDBNull(RadGridView1.CurrentRow.Cells("CODIGO").Value) Then
                        Else
                            txtCodigo.Text = RadGridView1.CurrentRow.Cells("CODIGO").Value
                        End If

                        BuscarProductoTextBox.Text = ""
                        TxtConceptoTransf.Focus()
                    End If

                    UltraPopupControlContainer1.Close()

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadGridView1.KeyPress
        Dim codmedida As Integer
        Dim f As New Funciones.Funciones
        Try
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If KeyAscii = 13 Then
                If RadGridView1.RowCount = 0 Then
                    BuscarProductoTextBox.Text = ""
                    TextBoxCodCodigo.Text = ""
                    tbxProducto.Focus()
                    UltraPopupControlContainer1.Close()

                Else

                    If IsDBNull(RadGridView1.CurrentRow) Then
                        BuscarProductoTextBox.Text = ""
                        tbxProducto.Focus()
                        UltraPopupControlContainer1.Close()

                    Else

                        If elijioproducto = True Then
                            If IsDBNull(RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value) Then
                            Else
                                TextBoxCodProducto.Text = RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value
                            End If

                            If IsDBNull(RadGridView1.CurrentRow.Cells("CODCODIGO").Value) Then
                            Else
                                TextBoxCodCodigo.Text = RadGridView1.CurrentRow.Cells("CODCODIGO").Value
                            End If

                            If IsDBNull(RadGridView1.CurrentRow.Cells("PRODUCTO").Value) Then
                            Else
                                tbxProducto.Text = RadGridView1.CurrentRow.Cells("PRODUCTO").Value
                            End If
                            If IsDBNull(RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value) Then
                            Else
                                codmedida = f.FuncionConsulta("CODMEDIDA", "PRODUCTOS", "CODPRODUCTO", RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value)
                                'LabelMedida.Text = f.FuncionConsultaString("DESMEDIDA", "UNIDADMEDIDA", "CODMEDIDA", codmedida)
                            End If
                            If IsDBNull(RadGridView1.CurrentRow.Cells("CODIGO").Value) Then
                            Else
                                txtCodigoAjuste.Text = RadGridView1.CurrentRow.Cells("CODIGO").Value
                            End If

                            BuscarProductoTextBox.Text = ""
                            ComboBoxProductos.Focus()
                        Else
                            If IsDBNull(RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value) Then
                            Else
                                TxtCodProductoTransf.Text = RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value
                            End If

                            If IsDBNull(RadGridView1.CurrentRow.Cells("CODCODIGO").Value) Then
                            Else
                                TxtCodCodigoTransf.Text = RadGridView1.CurrentRow.Cells("CODCODIGO").Value
                            End If

                            If IsDBNull(RadGridView1.CurrentRow.Cells("PRODUCTO").Value) Then
                            Else
                                TxtProductoTransf.Text = RadGridView1.CurrentRow.Cells("PRODUCTO").Value
                            End If
                            If IsDBNull(RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value) Then
                            Else
                                codmedida = f.FuncionConsulta("CODMEDIDA", "PRODUCTOS", "CODPRODUCTO", RadGridView1.CurrentRow.Cells("CODPRODUCTO").Value)
                            End If
                            If IsDBNull(RadGridView1.CurrentRow.Cells("CODIGO").Value) Then
                            Else
                                txtCodigo.Text = RadGridView1.CurrentRow.Cells("CODIGO").Value
                            End If

                            BuscarProductoTextBox.Text = ""
                            TxtConceptoTransf.Focus()
                        End If
                        UltraPopupControlContainer1.Close()

                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBoxProductos_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBoxProductos.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            dtpFechaAjuste.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxConceptoAjuste_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxConceptoAjuste.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            CantidadProdTxt.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProducto.Click
        TextBoxCodProducto.Text = ""
        TextBoxCodCodigo.Text = ""
        BuscarProductoTextBox.Text = ""
        Try
            Me.CODIGOSTableAdapter.Fill(Me.DsInventario.CODIGOS, "%", "%", "%")

        Catch ex As Exception

        End Try
        UltraPopupControlContainer1.PopupControl = ProductosGroupBox
        UltraPopupControlContainer1.Show()
        BuscarProductoTextBox.Focus()
    End Sub


    Private Sub PictureBoxTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxTransferencia.Click
        lbxPanel.Visible = True : buscarAjuste.Visible = True : BuscarTextBox.Visible = True : PictureBox2.Visible = True

        BuscarTextBox.BringToFront()
        Me.SUCURSALOrigenBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock' "
        Me.SUCURSALDestinoBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock' "

        CodigoDeposito = dgvDeposito.CurrentRow.Cells("CODSUCURSALDataGridViewTextBoxColumn3").Value
        Me.TransferenciaMovimientoTableAdapter.Fill(Me.DsInventario.TransferenciaMovimiento, CodigoDeposito)

        elijioproducto = False
        lbxPanel.Text = "Transferencias"

        PictureBoxProducto.Image = My.Resources.Stock
        PictureBoxProducto.Cursor = Cursors.Hand
        PictureBoxTransferencia.Image = My.Resources.TransferActive
        PictureBoxTransferencia.Cursor = Cursors.Arrow
        PictureBox3.Image = My.Resources.Create
        PictureBox3.Cursor = Cursors.Hand

        PanelTransferencia.BringToFront()
        CmbSucursalOrigen.Focus()
    End Sub

    Private Sub TxtProductoTransf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProductoTransf.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            TextBoxCodProducto.Text = ""
            TextBoxCodCodigo.Text = ""
            BuscarProductoTextBox.Text = ""
            Try
                Me.CODIGOSTableAdapter.Fill(Me.DsInventario.CODIGOS, "%", "%", "%")

            Catch ex As Exception

            End Try
            UltraPopupControlContainer1.PopupControl = ProductosGroupBox
            UltraPopupControlContainer1.Show()

            BuscarProductoTextBox.Focus()
            e.Handled = True
        End If

        If KeyAscii = 13 Then
            TxtConceptoTransf.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtConceptoTransf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConceptoTransf.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            TxtCantidadTransferido.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCantidadTransferido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidadTransferido.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            BtnGuardarTransf.Select()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbSucursalOrigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbSucursalOrigen.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            CmbSucursalDestino.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbSucursalDestino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbSucursalDestino.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            dtpFecha.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnGuardarTransf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarTransf.Click
        If TxtCodCodigoTransf.Text = "" Or TxtCodProductoTransf.Text = "" Then
            MessageBox.Show("Seleccione un producto", "POSEXPRESS")
            TxtProductoTransf.Focus()
            Exit Sub
        End If
        If TxtConceptoTransf.Text = "" Then
            MessageBox.Show("Es necesario que ingrese el concepto", "POSEXPRESS")
            TxtConceptoTransf.Focus()
            Exit Sub
        End If
        If CmbSucursalOrigen.Text = "" Or IsDBNull(CmbSucursalOrigen.SelectedValue) Then
            MessageBox.Show("Es necesario que selecciona la sucursal de origen", "POSEXPRESS")
            CmbSucursalOrigen.Focus()
            Exit Sub
        End If
        If CmbSucursalDestino.Text = "" Or IsDBNull(CmbSucursalDestino.SelectedValue) Then
            MessageBox.Show("Es necesario que selecciona la sucursal destino", "POSEXPRESS")
            CmbSucursalDestino.Focus()
            Exit Sub
        End If
        If CmbSucursalDestino.Text = CmbSucursalOrigen.Text Then
            MessageBox.Show("Es necesario elegir Depósitos distintos para las transferencias", "POSEXPRESS")
            CmbSucursalOrigen.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtCantidadTransferido.Text) Then
            MessageBox.Show("Ingrese la cantidad", "POSEXPRESS")
            TxtCantidadTransferido.Focus()
            Exit Sub
        ElseIf CDec(TxtCantidadTransferido.Text) = 0 Then
            MessageBox.Show("Ingrese la cantidad mayor a cero", "POSEXPRESS")
            TxtCantidadTransferido.Focus()
            Exit Sub
        End If

        Dim f As New Funciones.Funciones
        Dim existe, existe1 As Integer
        Dim stockactual As Decimal
        Try
            existe = f.FuncionConsulta("CODDEPOSITO", "STOCKDEPOSITO", "CODCODIGO=" & CDec(TxtCodCodigoTransf.Text) & " AND CODDEPOSITO", CmbSucursalOrigen.SelectedValue.ToString)
        Catch ex As Exception

        End Try

        Try
            existe1 = f.FuncionConsulta("CODDEPOSITO", "STOCKDEPOSITO", "CODCODIGO=" & CDec(TxtCodCodigoTransf.Text) & " AND CODDEPOSITO", CmbSucursalDestino.SelectedValue.ToString)
        Catch ex As Exception

        End Try

        If existe = 0 Then
            MessageBox.Show("El producto no tiene stock en la sucursal :" & CmbSucursalOrigen.Text & " para hacer un movimiento", "POSEXPRESS")
            Exit Sub
        Else
            Try
                stockactual = f.FuncionConsulta("STOCKACTUAL", "STOCKDEPOSITO", "CODCODIGO=" & CDec(TxtCodCodigoTransf.Text) & " AND CODDEPOSITO", CmbSucursalOrigen.SelectedValue.ToString)
            Catch ex As Exception

            End Try
            If CDec(TxtCantidadTransferido.Text) > stockactual Then
                MessageBox.Show("No tiene stock suficiente para la transferencia", "POSEXPRESS")
                TxtCantidadTransferido.Focus()
                Exit Sub
            End If
        End If

        'Sino tiene un codigo de Movimiento el sistema le genera uno automaticamente
        If CodModID.Text = "" Then
            Dim CodMovMax As Integer
            CodMovMax = f.Maximo("NROMOVIMIENTO", "MOVPRODUCTO")
            CodMovMax = CodMovMax + 1
            CodModID.Text = CodMovMax
        End If

        TransferenciaProducto(existe1)

    End Sub

    Private Sub tbxBuscador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarTextBox.KeyPress
        Try
            Me.TransferenciaMovimientoBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarTextBox.Text & "%' OR CONCEPTO LIKE '%" & BuscarTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarTextBox.Text & "%' OR IDMOVIMIENTOSTRING LIKE '%" & BuscarTextBox.Text & "%'"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbxTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTodos.CheckedChanged
        If cbxTodos.Checked = True Then
            Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock' OR TIPOSUCURSAL = 'Solo Factura'"
        Else
            Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock' "
        End If
    End Sub

    Private Sub dgvDeposito_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvDeposito.SelectionChanged
        If dgvDeposito.RowCount > 0 Then
            CodigoDeposito = dgvDeposito.CurrentRow.Cells("CODSUCURSALDataGridViewTextBoxColumn3").Value
            RadLabel7.Text = dgvDeposito.CurrentRow.Cells("DESSUCURSALDataGridViewTextBoxColumn3").Value

            If lbxPanel.Text = "Ajuste de Inventario" Then
                Me.MOVPRODUCTOSTableAdapter.FillBySuc(Me.DsInventario.MOVPRODUCTOS, CodigoDeposito)
            ElseIf lbxPanel.Text = "Transferencias" Then
                Me.TransferenciaMovimientoTableAdapter.Fill(Me.DsInventario.TransferenciaMovimiento, CodigoDeposito)
            Else 'Movimientos
                btnFiltro_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            CodModID.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CodModID_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CodModID.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtCodigo.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub buscarAjuste_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles buscarAjuste.KeyPress
        Try
            Me.MOVPRODUCTOBindingSource.Filter = "PRODUCTO LIKE '%" & buscarAjuste.Text & "%' OR CONCEPTO LIKE '%" & buscarAjuste.Text & "%' OR CODIGO LIKE '%" & buscarAjuste.Text & "%'"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            TextBoxCodProducto.Text = ""
            TextBoxCodCodigo.Text = ""
            BuscarProductoTextBox.Text = ""
            Try
                Me.CODIGOSTableAdapter.Fill(Me.DsInventario.CODIGOS, "%", "%", "%")

            Catch ex As Exception

            End Try
            UltraPopupControlContainer1.PopupControl = ProductosGroupBox
            UltraPopupControlContainer1.Show()

            BuscarProductoTextBox.Focus()
            e.Handled = True
        End If

        If KeyAscii = 13 Then
            TxtProductoTransf.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigo_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigo.LostFocus
        If txtCodigo.Text <> "" Then
            Dim objCommand As New SqlCommand

            objCommand.CommandText = "SELECT dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODPRODUCTO, dbo.PRODUCTOS.DESPRODUCTO    " & _
                                     "FROM dbo.PRODUCTOS INNER JOIN dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO    " & _
                                     "WHERE dbo.CODIGOS.CODIGO = '" & txtCodigo.Text & "'"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrProducto As SqlDataReader = objCommand.ExecuteReader()

            If odrProducto.HasRows Then
                Do While odrProducto.Read()
                    TxtCodCodigoTransf.Text = odrProducto("CODCODIGO")
                    TxtCodProductoTransf.Text = odrProducto("CODPRODUCTO")
                    TxtProductoTransf.Text = odrProducto("DESPRODUCTO")
                Loop
            End If

            odrProducto.Close()
            objCommand.Dispose()

            TxtProductoTransf.Focus()
        End If
    End Sub

    Private Sub txtCodigoAjuste_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoAjuste.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            TextBoxCodProducto.Text = ""
            TextBoxCodCodigo.Text = ""
            BuscarProductoTextBox.Text = ""
            Try
                Me.CODIGOSTableAdapter.Fill(Me.DsInventario.CODIGOS, "%", "%", "%")

            Catch ex As Exception

            End Try
            UltraPopupControlContainer1.PopupControl = ProductosGroupBox
            UltraPopupControlContainer1.Show()
            'BuscarProductoTextBox.Text = ""
            BuscarProductoTextBox.Focus()
            e.Handled = True
        End If

        If KeyAscii = 13 Then
            tbxProducto.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigoAjuste_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigoAjuste.LostFocus
        If txtCodigoAjuste.Text <> "" Then
            Dim objCommand As New SqlCommand

            objCommand.CommandText = "SELECT dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODPRODUCTO, dbo.PRODUCTOS.DESPRODUCTO    " & _
                                     "FROM dbo.PRODUCTOS INNER JOIN dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO    " & _
                                     "WHERE dbo.CODIGOS.CODIGO = '" & txtCodigoAjuste.Text & "'"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrProducto As SqlDataReader = objCommand.ExecuteReader()

            If odrProducto.HasRows Then
                Do While odrProducto.Read()
                    TextBoxCodCodigo.Text = odrProducto("CODCODIGO")
                    TextBoxCodProducto.Text = odrProducto("CODPRODUCTO")
                    tbxProducto.Text = odrProducto("DESPRODUCTO")
                Loop
            End If

            odrProducto.Close()
            objCommand.Dispose()

            tbxProducto.Focus()
        End If
    End Sub

    Private Sub CodModID_Validated(sender As Object, e As System.EventArgs) Handles CodModID.Validated
        CodModID.Text = Funciones.Cadenas.SoloNumeros(CodModID.Text)
    End Sub

    Private Sub DataGridView3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown, dgvTransferencias.KeyDown
        If e.KeyCode = Keys.F6 Then
            Dim sql As String

            permiso = PermisoAplicado(UsuCodigo, 222)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                Exit Sub
            End If

            sql = ""
            'Eliminamos un Ajuste o Tranferencia, para eso verificamos que panel esta seleccionado
            If lbxPanel.Text = "Ajuste de Inventario" Then

                'If DataGridView3.CurrentRow.Cells("NUMCOMPROVANTE").Value <> "" Then 'Antes de Eliminar un Ajuste Verificamos que este no relacionado a ninguna Factura
                If IsDBNull(DataGridView3.CurrentRow.Cells("NROMOVIMIENTO3").Value) Then   'Es un Ajuste
                    If MessageBox.Show("¿Esta seguro que quiere eliminar este Ajuste?", "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                        Exit Sub
                    End If

                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans

                    Try
                        
                        sql = sql + "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO = " & DataGridView3.CurrentRow.Cells("CODMOVIMIENTO3").Value

                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                        myTrans.Commit()

                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Insertar")
                        Catch
                            MessageBox.Show("Error al Eliminar el Ajuste de Stock: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Try

                    sqlc.Close()

                    Me.MOVPRODUCTOSTableAdapter.FillBySuc(Me.DsInventario.MOVPRODUCTOS, CodigoDeposito)
                    Me.MOVPRODUCTOBindingSource.MoveFirst()

                Else 'Es una Tranferencia
                    GoTo 10
                End If
                

            ElseIf lbxPanel.Text = "Transferencias" Then
10:             If MessageBox.Show("Al Eliminar esta Tranferencia se Eliminara la ENTRADA/SALIDA del Deposito Relacionado ¿Esta seguro que quiere Continuar?", "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                    Exit Sub
                End If

                'Obtenemos los Valores de DepositoOrigen, DepositoDestino
                Dim objCommand As New SqlCommand
                Dim NroMovimiento As Integer
                Dim CodigoProducto As String
                'Dim cantidad As String

                NroMovimiento = dgvTransferencias.CurrentRow.Cells("NROMOVIMIENTOTR").Value
                CodigoProducto = dgvTransferencias.CurrentRow.Cells("CODIGOTR").Value

                Try
                    objCommand.CommandText = "SELECT dbo.MOVPRODUCTO.CODMOVIMIENTO, dbo.MOVPRODUCTO.CANTIDAD " & _
                                             "FROM dbo.MOVPRODUCTO INNER JOIN dbo.CODIGOS ON dbo.MOVPRODUCTO.CODCODIGO = dbo.CODIGOS.CODCODIGO   " & _
                                             "WHERE (dbo.MOVPRODUCTO.NROMOVIMIENTO = " & NroMovimiento & ") AND (dbo.CODIGOS.CODIGO = '" & CodigoProducto & "')"

                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    Dim odrMov As SqlDataReader = objCommand.ExecuteReader()

                    If odrMov.HasRows Then
                        Do While odrMov.Read()
                           
                            ser.Abrir(sqlc)
                            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

                            cmd.Connection = sqlc
                            cmd.Transaction = myTrans

                            Try
                               
                                sql = sql + " DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO = " & odrMov("CODMOVIMIENTO")

                                cmd.CommandText = sql
                                cmd.ExecuteNonQuery()
                                myTrans.Commit()

                            Catch ex As Exception
                                Try
                                    myTrans.Rollback("Insertar")
                                Catch
                                    MessageBox.Show("Error al Eliminar el Ajuste de Stock: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                            End Try
                        Loop
                    End If

                    odrMov.Close()
                    objCommand.Dispose()

                    CodigoDeposito = dgvDeposito.CurrentRow.Cells("CODSUCURSALDataGridViewTextBoxColumn3").Value
                    Me.TransferenciaMovimientoTableAdapter.Fill(Me.DsInventario.TransferenciaMovimiento, CodigoDeposito)

                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub dtpFechaAjuste_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaAjuste.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxConceptoAjuste.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        PictureBoxProducto.Image = My.Resources.Stock
        PictureBoxProducto.Cursor = Cursors.Hand
        PictureBoxTransferencia.Image = My.Resources.Transfer
        PictureBoxTransferencia.Cursor = Cursors.Hand

        PictureBox3.Image = My.Resources.CreateActive
        PictureBox3.Cursor = Cursors.Arrow

        pnlFiltros.BringToFront()
        Fecha1.Value = DateAdd(DateInterval.Month, -1, Today)
        Fecha2.Value = DateAdd(DateInterval.Day, 1, Today)

        btnFiltro_Click(Nothing, Nothing)

        lbxPanel.Text = "Movimientos de Productos"
        buscarAjuste.Visible = False : BuscarTextBox.Visible = False : PictureBox2.Visible = False
    End Sub

    Private Sub btnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltro.Click
        Dim Tipo1, Tipo2, Tipo3 As String

        Tipo1 = "%" : Tipo2 = "%" : Tipo3 = "%"

        Dim FechaDesde, FechaHasta As String
        Dim desde As String = Fecha1.Value.ToString("dd/MM/yyy")
        Dim hasta As String = Fecha2.Value.ToString("dd/MM/yyy")

        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:00"

        Try
            Me.MOVPRODUCTOSTableAdapter.FillByFechaSuc(Me.DsInventario.MOVPRODUCTOS, FechaDesde, FechaHasta, CodigoDeposito)
        Catch ex As Exception
        End Try

        If chkAjustes.Checked = True Then
            Tipo1 = "Ajuste."
        End If
        If chkTransacciones.Checked = True Then
            Tipo2 = "Transf."
        End If
        If chkMovimientos.Checked = True Then
            Tipo3 = " "
        End If

        If Tipo1 = "%" Then Tipo1 = Tipo2
        If Tipo2 = "%" Then Tipo2 = Tipo1

        If Tipo3 = "%" Then
            MOVPRODUCTOBindingSource.Filter = "CONCEPTO LIKE '%" & Tipo1 & "%' OR CONCEPTO LIKE '%" & Tipo2 & "%'"
        Else
            If Tipo1 = "%" And Tipo2 = "%" Then
                MOVPRODUCTOBindingSource.Filter = "CONCEPTO NOT LIKE 'Ajuste.%' AND CONCEPTO NOT LIKE 'Transf.%'"
            Else
                MOVPRODUCTOBindingSource.Filter = "CONCEPTO NOT LIKE 'Ajuste.%' AND CONCEPTO NOT LIKE 'Transf.%' OR CONCEPTO LIKE '%" & Tipo1 & "%' OR CONCEPTO LIKE '%" & Tipo2 & "%'"
            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        Try
            Me.MOVPRODUCTOBindingSource.Filter = "PRODUCTO LIKE '%" & TextBox2.Text & "%' OR CONCEPTO LIKE '%" & TextBox2.Text & "%' OR CODIGO LIKE '%" & TextBox2.Text & "%'"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tbxProducto_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxProducto.TextChanged

    End Sub
End Class