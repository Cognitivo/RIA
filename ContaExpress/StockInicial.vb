Imports System.Data.SqlClient
Imports System.Globalization

Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class StockInicial

    #Region "Fields"

    Private cmd As SqlCommand

    'Variable para guardar Stock
    Dim Concepto As String
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Private sqlc As SqlConnection
    Dim permiso As Double

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

    Private Sub BuscadorGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscadorGridView.DoubleClick
        If IsDBNull(BuscadorGridView.CurrentRow) Then
        Else
            Dim w As New Funciones.Funciones
            CodigoProdTextBox.Text = BuscadorGridView.CurrentRow.Cells("CODPRODUCTO").Value
            CodCodigoRadTextBox.Text = BuscadorGridView.CurrentRow.Cells("CODCODIGO").Value
            RadTextBoxDesproducto.Text = BuscadorGridView.CurrentRow.Cells("DESPRODUCTO").Value
            Me.TbxCodigoProducto.Text = w.FuncionConsultaString("CODIGO", "CODIGOS", "CODCODIGO", CodCodigoRadTextBox.Text)
            UltraPopupControlContainer1.Close()
            TxtPrecio.Focus()
        End If
    End Sub

    Private Sub BuscadorGridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscadorGridView.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim w As New Funciones.Funciones

        If KeyAscii = 13 Then 'Enter
            If IsDBNull(BuscadorGridView.CurrentRow) Then
            Else
                CodigoProdTextBox.Text = BuscadorGridView.CurrentRow.Cells("CODPRODUCTO").Value
                CodCodigoRadTextBox.Text = BuscadorGridView.CurrentRow.Cells("CODCODIGO").Value
                RadTextBoxDesproducto.Text = BuscadorGridView.CurrentRow.Cells("DESPRODUCTO").Value
                Me.TbxCodigoProducto.Text = w.FuncionConsultaString("CODIGO", "CODIGOS", "CODCODIGO", CodCodigoRadTextBox.Text)

                UltraPopupControlContainer1.Close()
                TxtPrecio.Focus()
            End If
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BuscadorTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscadorTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            BuscadorGridView.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BuscadorTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscadorTextBox.TextChanged
        If BuscadorTextBox.Text <> "Buscar..." Then
            CODIGOSBindingSource.Filter = "CODIGO LIKE '%" & BuscadorTextBox.Text & "%' OR DESPRODUCTO LIKE '%" & BuscadorTextBox.Text & "%' OR DESCODIGO1 LIKE '%" & BuscadorTextBox.Text & "%'"
        End If
    End Sub

    Private Sub Form_KeyPress(ByVal KeyAscii As Integer)
        If KeyAscii = 13 Then
            SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
    End Sub

    Private Sub limpiarcampos()
        RadTextBoxDesproducto.Text = "" : TxtPrecio.Text = "" : CantidadInvTextBox.Text = "" : TbxCodigoProducto.Text = ""
    End Sub

    Private Sub RadButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButtonEliminar.Click
        If MessageBox.Show("Esta seguro que desea eliminar el registro", "Inventario", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            RadTextBoxDesproducto.Focus()
            Exit Sub
        Else
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO = " & dgwStockInicial.CurrentRow.Cells("CODMOVIMIENTO").Value

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans.Commit()

                limpiarcampos()

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un al Eliminar el Stock Inicial", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlc.Close()
            End Try

            Me.STOCKINICIALTableAdapter1.Fill(Me.DsProductos.STOCKINICIAL)
            TbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub RadButtonInserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButtonInserta.Click
        Dim f As New Funciones.Funciones
        Dim ProdStockActual As Double
        If RadTextBoxDesproducto.Text = "" Then
            MessageBox.Show("No se cargo ningún producto aun, cargue uno para poder cargar stock", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TbxCodigoProducto.Focus()
            Exit Sub
        End If

        'VALIDAMOS QUE INGRESE EL PRODUCTO CORRECTAMENTE
        If CodCodigoRadTextBox.Text = "" Or CodigoProdTextBox.Text = "" Then
            MessageBox.Show("Seleccione el Producto para Cargar su Stock", "POSEXPRESS")
            TbxCodigoProducto.Focus()
            Exit Sub

        End If

        If RadComboBoxSucursal.SelectedValue = Nothing Then
            MessageBox.Show("Seleccione la Sucursal para Cargar el Stock", "POSEXPRESS")
            RadComboBoxSucursal.Focus()
            Exit Sub
        End If

        ProdStockActual = f.FuncionConsultaString2("STOCKACTUAL", "STOCKDEPOSITO", "CODCODIGO = " & CDec(CodCodigoRadTextBox.Text) & " AND CODDEPOSITO", RadComboBoxSucursal.SelectedValue)

        If ProdStockActual <> 0 Then
            MessageBox.Show("El producto ya tiene stock en esta sucursal", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TbxCodigoProducto.Focus()
            Exit Sub
        End If

        If RadTextBoxDesproducto.Text = "" Then
            MessageBox.Show("Ingrese el producto ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TbxCodigoProducto.Focus()
            Exit Sub
        End If

        If CantidadInvTextBox.Text = Nothing Then
            MessageBox.Show("Ingrese la cantidad ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CantidadInvTextBox.Focus()
            Exit Sub
        End If

        If RadComboBoxSucursal.Text = "" Then
            MessageBox.Show("Ingrese la sucursal para cargar el stock", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            RadComboBoxSucursal.Focus()
            Exit Sub
        End If

        If TxtPrecio.Text = "" Then
            MessageBox.Show("Ingrese el Costo/Precio ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtPrecio.Focus()
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            Dim w As New Funciones.Funciones
            Dim cantidad, precio As String

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Fecha As String = dtpFecha.Text
            Dim FechaHora As String = Fecha & " " + hora

            cantidad = Funciones.Cadenas.QuitarCad(CantidadInvTextBox.Text, ".")
            cantidad = Replace(cantidad, ",", ".")

            precio = Funciones.Cadenas.QuitarCad(TxtPrecio.Text, ".")
            precio = Replace(precio, ",", ".")

            sql = ""
            sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,STOCK) " & _
                 "VALUES(" & UsuCodigo & "," & CDec(CodCodigoRadTextBox.Text) & "," & RadComboBoxSucursal.SelectedValue & ", CONVERT(DATETIME,'" & FechaHora & "',103),13," & _
                 cantidad & "," & precio & ",'Stock Inicial',1,1)"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()

            limpiarcampos()

            MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            End Try
            MessageBox.Show("Ocurrió un error al insertar el Stock inicial", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlc.Close()
        End Try

        Me.STOCKINICIALTableAdapter1.Fill(Me.DsProductos.STOCKINICIAL)
        TbxCodigoProducto.Focus()
    End Sub

    Private Sub RadTextBoxBuscar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles RadTextBoxBuscar.KeyDown

    End Sub

    Private Sub RadTextBoxBuscar_RightToLeftChanged(sender As Object, e As System.EventArgs) Handles RadTextBoxBuscar.RightToLeftChanged

    End Sub

    Private Sub RadTextBoxBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadTextBoxBuscar.TextChanged
        If RadTextBoxBuscar.Text <> "Buscar..." Then
            STOCKINICIALBindingSource.Filter = "CODIGO LIKE '%" & RadTextBoxBuscar.Text & "%' OR DESPRODUCTO LIKE '%" & RadTextBoxBuscar.Text & "%' OR DESSUCURSAL LIKE '%" & RadTextBoxBuscar.Text & "%'"
        End If
    End Sub

    Private Sub RadTextBoxDesproducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If CodigoProdTextBox.Text = "" Then
                TxtPrecio.Focus()
                Exit Sub
            End If
        End If

        If KeyAscii = 42 Then
            CodigoProdTextBox.Text = "" : CodCodigoRadTextBox.Text = ""
            UltraPopupControlContainer1.Show()
            BuscadorTextBox.Text = ""
            BuscadorTextBox.Focus()
            
            e.Handled = True
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub StockInicial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 60)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If

        Me.SUCURSALTableAdapter.Fill(Me.DsInventario.SUCURSAL)
        Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' or TIPOSUCURSAL='Factura y Stock'"
        CODIGOSTableAdapter.Fill(DsInventario.CODIGOS, "%", "%", "%")

        Me.STOCKINICIALTableAdapter1.Fill(Me.DsProductos.STOCKINICIAL)

        TbxCodigoProducto.Focus()
    End Sub

    Private Sub TxtPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrecio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            RadComboBoxSucursal.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub RadComboBoxSucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadComboBoxSucursal.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CantidadInvTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub CantidadInvTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadInvTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFecha.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            RadButtonInserta.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub RadTextBoxBuscar_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadTextBoxBuscar.GotFocus
        If RadTextBoxBuscar.Text = "Buscar..." Then
            RadTextBoxBuscar.Text = ""
        End If
    End Sub

    Private Sub RadTextBoxBuscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadTextBoxBuscar.LostFocus
        If RadTextBoxBuscar.Text = "" Then
            RadTextBoxBuscar.Text = "Buscar..."
        End If
    End Sub

    Private Sub TbxCodigoProducto_GotFocus(sender As Object, e As System.EventArgs) Handles TbxCodigoProducto.GotFocus
        TbxCodigoProducto.BackColor = Color.LightSteelBlue
    End Sub

    'Private Sub TbxCodigoProducto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TbxCodigoProducto.KeyDown

    'End Sub

    Private Sub TbxCodigoProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TbxCodigoProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 42 Then
            CODIGOSTableAdapter.Fill(DsInventario.CODIGOS, "%", "%", "%")

            CodigoProdTextBox.Text = "" : CodCodigoRadTextBox.Text = ""
            UltraPopupControlContainer1.Show()
            BuscadorTextBox.Text = "" : BuscadorTextBox.Focus()

            e.Handled = True
        End If

        If KeyAscii = 13 Then
            TxtPrecio.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TbxCodigoProducto_LostFocus(sender As Object, e As System.EventArgs) Handles TbxCodigoProducto.LostFocus
        Try
            Dim w As New Funciones.Funciones
            TbxCodigoProducto.BackColor = Color.White

            If TbxCodigoProducto.Text <> "" Then
                Me.CODIGOSBindingSource.Filter = "CODIGO = '" & TbxCodigoProducto.Text & "'"
                CodCodigoRadTextBox.Text = BuscadorGridView.CurrentRow.Cells("CODCODIGO").Value
                CodigoProdTextBox.Text = BuscadorGridView.CurrentRow.Cells("CODPRODUCTO").Value
                RadTextBoxDesproducto.Text = BuscadorGridView.CurrentRow.Cells("Producto").Value
                Me.CODIGOSBindingSource.Filter = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub TbxCodigoProducto_TextChanged(sender As System.Object, e As System.EventArgs) Handles TbxCodigoProducto.TextChanged

    End Sub

    Private Sub BtnAsterisco_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsterisco.Click
        CODIGOSTableAdapter.Fill(DsInventario.CODIGOS, "%", "%", "%")

        CodigoProdTextBox.Text = "" : CodCodigoRadTextBox.Text = ""
        UltraPopupControlContainer1.Show()
        BuscadorTextBox.Text = "" : BuscadorTextBox.Focus()
    End Sub

    Private Sub dgwStockInicial_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwStockInicial.CellContentClick

    End Sub

    Private Sub dgwStockInicial_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwStockInicial.CellContentDoubleClick


    End Sub

    Private Sub dgwStockInicial_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwStockInicial.CellDoubleClick
        Dim Costo As String
        Costo = InputBox("Ingrese el Nuevo Costo del producto:", "Actualizar Costos", Me.dgwStockInicial.SelectedCells(4).Value)
        If Costo = "" Then
        Else
            Costo = Replace(Costo, ",", ".")
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                sql = ""
                sql = "UPDATE MOVPRODUCTO SET VALOR = '" & Costo & "' WHERE CODMOVIMIENTO= " & Me.dgwStockInicial.SelectedCells(7).Value
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                myTrans.Commit()
                MessageBox.Show("El proceso de Actualización a finalizado correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error al Actualizar el Stock Inicial", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                sqlc.Close()
                StockInicial_Load(Nothing, Nothing)
            End Try
        End If
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Dim html As String = "http://www.cogentpotential.com/soporte/stock/productos"
        Shell("Explorer " & html)
    End Sub
End Class
