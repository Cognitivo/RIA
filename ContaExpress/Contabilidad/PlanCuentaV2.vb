'Descripcion de la Regla Contable Aplicada
' Cliente Especifico    ---> 1
' Cliente Generico      ---> 2
' Proveedor Especifico  ---> 3
' Proveedor Generico    ---> 4
' I.V.A 5%              ---> 5
' Venta de Mercaderia   ---> 6   (1 - Producto / 0 - Servicio)
' Movi de Caja Generico ---> 7
' Movimiento de Caja    ---> 8
' I.V.A 10%             ---> 10
' Exento                ---> 9
'Compra de Mercaderia   ---> 11  (Centro de Costo)


Imports System.Data.SqlClient
Imports System.IO
Imports Osuna.Utiles.Conectividad

Public Class PlanCuentaV2

#Region "Fields"
    Private myTrans As SqlTransaction
    Private cmd As SqlCommand
    Private ser As BDConexión.BDConexion
    Private sqlc As SqlConnection
    Dim permiso As Double
    Dim sql As String
    Dim ReglaAplicada, DetalleRegla As Integer
    Dim f As New Funciones.Funciones
    Dim AccNuevo, AccEditar As Integer
#End Region

#Region "BD Conexion"
    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub
#End Region

#Region "Methods"

    Private Sub PlanCuentaV2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If pbxNuevo.Enabled = True Then
                NuevoPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F6 Then
            If pbxEditar.Enabled = True Then
                pbxEditar_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F7 Then
            If pbxGuardar.Enabled = True Then
                pbxGuardar_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F8 Then
            If pbxCancelar.Enabled = True Then
                pbxCancelar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub PlanCuentaV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 200)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        Me.CAJATableAdapter.Fill(Me.DsPlantillasConta.CAJA)
        Me.CENTROCOSTOTableAdapter.Fill(Me.DsPlantillasConta.CENTROCOSTO)
        Try
            Me.PROVEEDORTableAdapter.Fill(Me.DsPlantillasConta.PROVEEDOR)
        Catch

        End Try

        Me.CLIENTESTableAdapter.Fill(Me.DsPlantillasConta.CLIENTES)
        Me.PlancuentasTableAdapter.FillByTodos(Me.DsPlantillasConta.plancuentas)


        DesHabilitar()
        AccNuevo = 0 : AccEditar = 0
    End Sub

    Public Sub PintarCeldas()
        If dgvCuentas.RowCount - 1 > 1 Then
            For i = 0 To dgvCuentas.RowCount - 1
                If dgvCuentas.Rows(i).Cells("ASENTABLE").Value = "No" Then
                    dgvCuentas.Item(0, i).Style.BackColor = Color.PaleGoldenrod
                    dgvCuentas.Item(1, i).Style.BackColor = Color.PaleGoldenrod
                Else
                    dgvCuentas.Item(0, i).Style.BackColor = Color.White
                    dgvCuentas.Item(1, i).Style.BackColor = Color.White
                End If
            Next
        End If
    End Sub

    Public Sub Habilitar()
        pbxNuevo.Image = My.Resources.NewOff
        pbxNuevo.Cursor = Cursors.Arrow
        pbxNuevo.Enabled = False
        pbxEditar.Image = My.Resources.EditOff
        pbxEditar.Cursor = Cursors.Arrow
        pbxEditar.Enabled = False
        pbxEliminar.Image = My.Resources.DeleteOff
        pbxEliminar.Cursor = Cursors.Arrow
        pbxEliminar.Enabled = False

        pbxGuardar.Image = My.Resources.Save
        pbxGuardar.Cursor = Cursors.Hand
        pbxGuardar.Enabled = True
        pbxCancelar.Image = My.Resources.SaveCancel
        pbxCancelar.Cursor = Cursors.Hand
        pbxCancelar.Enabled = True

        tbxDescripcionCuenta.Enabled = True
        tbxNroCuenta.Enabled = True
        pnlContable.Enabled = True
        pnlIntegracion.Enabled = True

        dgvCuentas.Enabled = False
        BuscarTextBox.Enabled = False
    End Sub

    Public Sub DesHabilitar()
        pbxNuevo.Image = My.Resources.New_
        pbxNuevo.Cursor = Cursors.Hand
        pbxNuevo.Enabled = True
        pbxEditar.Image = My.Resources.Edit
        pbxEditar.Cursor = Cursors.Hand
        pbxEditar.Enabled = True
        pbxEliminar.Image = My.Resources.Delete
        pbxEliminar.Cursor = Cursors.Hand
        pbxEliminar.Enabled = True

        pbxGuardar.Image = My.Resources.SaveOff
        pbxGuardar.Cursor = Cursors.Arrow
        pbxGuardar.Enabled = False
        pbxCancelar.Image = My.Resources.SaveCancelOff
        pbxCancelar.Cursor = Cursors.Arrow
        pbxCancelar.Enabled = False

        tbxDescripcionCuenta.Enabled = False
        tbxNroCuenta.Enabled = False
        pnlContable.Enabled = False
        pnlIntegracion.Enabled = False

        dgvCuentas.Enabled = True
        BuscarTextBox.Enabled = True
    End Sub

    Private Sub dgvCuentas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCuentas.SelectionChanged
        If dgvCuentas.RowCount <> 0 Then
            Dim TipoVenta As Integer = 0

            cbxCliente.Text = "" : cbxProveedor.Text = "" : cbxIVA.Text = "" : cbxProducto.Text = "" : cbxMonetario.Text = "" : cbxAnticipo.Text = ""

            If IsDBNull(dgvCuentas.CurrentRow.Cells("ReglaGrilla").Value) Then
                ReglaAplicada = 0
                lblErrorRegla.Visible = True

            Else
                ReglaAplicada = dgvCuentas.CurrentRow.Cells("ReglaGrilla").Value
                lblErrorRegla.Visible = False

                'Tilda la Regla correspondiente

                Select Case ReglaAplicada
                    Case 1
                        rbtnCliente1.Checked = True
                        cbxCliente.Text = f.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", dgvCuentas.CurrentRow.Cells("REGLAFK").Value)
                    Case 2
                        rbtnClienteGen2.Checked = True

                    Case 3
                        rbtnProveedor3.Checked = True
                        cbxProveedor.Text = f.FuncionConsultaString("NOMBRE", "PROVEEDOR", "CODPROVEEDOR", dgvCuentas.CurrentRow.Cells("REGLAFK").Value)

                    Case 4
                        rbtnProveedorGen4.Checked = True

                    Case 5
                        rbtnIVA5.Checked = True
                        If dgvCuentas.CurrentRow.Cells("REGLAFK").Value = 5 Then
                            cbxIVA.Text = "I.V.A 5%"
                        ElseIf dgvCuentas.CurrentRow.Cells("REGLAFK").Value = 10 Then
                            cbxIVA.Text = "I.V.A 10%"
                        ElseIf dgvCuentas.CurrentRow.Cells("REGLAFK").Value = 0 Then
                            cbxIVA.Text = "Exento"
                        End If

                    Case 6
                        rbtnVenta11.Checked = True
                        cbxMovVentas.BringToFront()
                        TipoVenta = dgvCuentas.CurrentRow.Cells("REGLAFK").Value

                        If TipoVenta = 1 Then
                            cbxMovVentas.Text = "Producto"
                        ElseIf TipoVenta = 0 Then
                            cbxMovVentas.Text = "Servicio"
                        ElseIf cbxMovVentas.Text = "Costo de Venta" Then
                            DetalleRegla = 3
                        Else
                            cbxMovVentas.Text = ""
                        End If

                    Case 7
                        rbtnMovimientoGen8.Checked = True

                    Case 8
                        rbtnMonetario7.Checked = True
                        cbxMonetario.Text = f.FuncionConsultaString("NUMEROCAJA", "CAJA", "NUMCAJA", dgvCuentas.CurrentRow.Cells("REGLAFK").Value)

                    Case 11
                        rbtnProducto6.Checked = True
                        cbxProducto.Text = f.FuncionConsultaString("DESCENTRO", "CENTROCOSTO", "CODCENTRO", dgvCuentas.CurrentRow.Cells("REGLAFK").Value)

                    Case 12
                        rbtAnticipo.Checked = True
                        cbxAnticipo.Text = "Cliente"

                    Case 13
                        rbtAnticipo.Checked = True
                        cbxAnticipo.Text = "Proveedor"

                    Case 14
                        rbtRetencion.Checked = True
                        cbxRetencion.Text = "Compra"

                    Case 15
                        rbtRetencion.Checked = True
                        cbxRetencion.Text = "Venta"
                End Select

            End If
            ' Tipo Cuenta
            If IsDBNull(dgvCuentas.CurrentRow.Cells("TIPOCUENTA").Value) Then
                cbxTipoCuenta.Text = ""
            ElseIf (dgvCuentas.CurrentRow.Cells("TIPOCUENTA").Value) = 1 Then
                cbxTipoCuenta.Text = "Activo"
            ElseIf (dgvCuentas.CurrentRow.Cells("TIPOCUENTA").Value) = 2 Then
                cbxTipoCuenta.Text = "Pasivo"
            ElseIf (dgvCuentas.CurrentRow.Cells("TIPOCUENTA").Value) = 3 Then
                cbxTipoCuenta.Text = "Patrimonio Neto"
            ElseIf (dgvCuentas.CurrentRow.Cells("TIPOCUENTA").Value) = 4 Then
                cbxTipoCuenta.Text = "Ingreso"
            ElseIf (dgvCuentas.CurrentRow.Cells("TIPOCUENTA").Value) = 5 Then
                cbxTipoCuenta.Text = "Egreso"
            ElseIf (dgvCuentas.CurrentRow.Cells("TIPOCUENTA").Value) = 6 Then
                cbxTipoCuenta.Text = "Regularizadora del Activo"
            End If


            'Saldo Esperado
            If IsDBNull(dgvCuentas.CurrentRow.Cells("SALDOESPERADO").Value) Then
                cbxSaldoEsperado.Text = ""
            Else
                If dgvCuentas.CurrentRow.Cells("SALDOESPERADO").Value = 1 Then
                    cbxSaldoEsperado.Text = "Deudor"
                ElseIf dgvCuentas.CurrentRow.Cells("SALDOESPERADO").Value = 2 Then
                    cbxSaldoEsperado.Text = "Acreedor"
                End If
            End If

            'Resultado
            If IsDBNull(dgvCuentas.CurrentRow.Cells("RESULTADO").Value) Then
                cbxResultado.Text = ""
            Else
                If dgvCuentas.CurrentRow.Cells("RESULTADO").Value = 1 Then
                    cbxResultado.Text = "Ganancia del Ejercicio"
                ElseIf dgvCuentas.CurrentRow.Cells("RESULTADO").Value = 2 Then
                    cbxResultado.Text = "Pérdida del Ejercicio"
                End If
            End If

        End If

        dgvCuentas.Refresh()
    End Sub

    Private Sub BuscarTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.GotFocus
        If BuscarTextBox.Text = "Buscar..." Then
            BuscarTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.LostFocus
        If BuscarTextBox.Text = "" Then
            BuscarTextBox.Text = "Buscar..."

        End If
    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged
        If BuscarTextBox.Text <> "Buscar..." Then
            Me.PlancuentasBindingSource.Filter = "DESPLANCUENTA LIKE '%" & BuscarTextBox.Text & "%'"
        End If
    End Sub

    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxNuevo.Click

        Dim conexion As System.Data.SqlClient.SqlConnection

        lblErrorRegla.Visible = False
        Me.PlancuentasBindingSource.AddNew()

        conexion = ser.Abrir()

        Try
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            InsertarPlantillaNueva(myTrans)
            myTrans.Commit()

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            End Try
        End Try

        Habilitar()
        cbxCliente.Text = "" : cbxProveedor.Text = "" : cbxIVA.Text = "" : cbxProducto.Text = "" : cbxMonetario.Text = ""
        AccNuevo = 1 : AccEditar = 0
        lblErrorRegla.Visible = False
        tbxDescripcionCuenta.Focus()
    End Sub

    Private Sub InsertaAuditoria(ByVal Insertar As Integer, ByVal Modificar As Integer, ByVal Eliminar As Integer)
        Dim consulta, Accion As String
        Dim CODIGO As Integer = f.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        Accion = ""

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        If Insertar = 1 Then
            Accion = "INSERTO"
        ElseIf Modificar = 1 Then
            Accion = "MODIFICO"
        ElseIf Eliminar = 1 Then
            Accion = "ELIMINO"
        End If

        consulta = "INSERT INTO AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO,DESCRIPCION, FECHA, USUARIO,  INSERTAR, MODIFICAR, ELIMINAR)" & _
        "VALUES ( " & CODIGO & ", " & EmpCodigo & "," & "'PLAN DE CUENTAS', '" & tbxCodPlanCuenta.Text & "', " & "'" & Accion & " EN TABLA DE PLAN DE CUENTAS' , " & _
        "CONVERT(DATETIME,  getdate()), " & "'" & UsuDescripcion & "'," & Insertar & "," & Modificar & ", " & Eliminar & " )"

        cmd.CommandText = consulta
        cmd.ExecuteNonQuery()

        myTrans.Commit()

    End Sub

    Private Sub InsertarPlantillaNueva(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim consulta As System.String
        Dim Ultimo As Integer

        Ultimo = f.Maximo("CODPLANCUENTA", "plancuentas")
        tbxCodPlanCuenta.Text = Ultimo + 1

        consulta = "INSERT INTO plancuentas (CODPLANCUENTA) VALUES (" & CDec(tbxCodPlanCuenta.Text) & ")"

        Consultas.ConsultaComando(myTrans, consulta)
    End Sub

    Private Sub pbxCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCancelar.Click
        Dim VarIsNull As String

        VarIsNull = f.FuncionConsultaString("DESPLANCUENTA", "plancuentas", "CODPLANCUENTA", tbxCodPlanCuenta.Text)

        If VarIsNull = "" Or VarIsNull = Nothing Then
            Dim consulta As System.String
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            conexion = ser.Abrir()

            Try
                consulta = ""
                consulta = consulta + "DELETE FROM plancuentas WHERE CODPLANCUENTA=" & tbxCodPlanCuenta.Text & " "

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
            Catch ex As SqlException

            End Try
        End If

        Try
            PlancuentasBindingSource.CancelEdit()
            Me.PlancuentasTableAdapter.FillByTodos(Me.DsPlantillasConta.plancuentas)
            DesHabilitar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pbxEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEditar.Click
        lblErrorRegla.Visible = False
        Habilitar()
        tbxDescripcionCuenta.Focus()
        AccNuevo = 0 : AccEditar = 1
    End Sub

    Private Sub rbtnCliente1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCliente1.CheckedChanged
        If rbtnCliente1.Checked = True Then
            cbxCliente.Enabled = True
        Else
            cbxCliente.Enabled = False
        End If
    End Sub

    Private Sub rbtnClienteGen2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnClienteGen2.CheckedChanged
        If rbtnClienteGen2.Checked = True Then
            cbxCliente.Enabled = False
        End If
    End Sub

    Private Sub rbtnProveedor3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProveedor3.CheckedChanged
        If rbtnProveedor3.Checked = True Then
            cbxProveedor.Enabled = True
        Else
            cbxProveedor.Enabled = False
        End If
    End Sub

    Private Sub rbtnProveedorGen4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProveedorGen4.CheckedChanged
        If rbtnProveedorGen4.Checked = True Then
            cbxProveedor.Enabled = False
        End If
    End Sub

    Private Sub rbtnIVA5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnIVA5.CheckedChanged
        If rbtnIVA5.Checked = True Then
            Me.cbxIVA.Enabled = True
        Else
            Me.cbxIVA.Enabled = False
        End If
    End Sub

    Private Sub rbtnProducto6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProducto6.CheckedChanged
        If rbtnProducto6.Checked = True Then
            cbxProducto.Enabled = True
            cbxProducto.BringToFront()
        Else
            cbxProducto.Enabled = False
            cbxProducto.SendToBack()
        End If
    End Sub

    Private Sub rbtnMonetario7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnMonetario7.CheckedChanged
        If rbtnMonetario7.Checked = True Then
            cbxMonetario.Enabled = True
        Else
            cbxMonetario.Enabled = False
        End If
    End Sub

    Private Sub rbtnMovimientoGen8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnMovimientoGen8.CheckedChanged
        If rbtnMovimientoGen8.Checked = True Then
            cbxMonetario.Enabled = False
        End If
    End Sub

    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxGuardar.Click
        Dim TipoCuenta, SaldoEsperado, ProdServ As Integer

        'Verificamos 
        If tbxDescripcionCuenta.Text = "" Then
            MessageBox.Show("Ingrese una Descripción de la Cuenta", "POSEXPRESS")
            tbxDescripcionCuenta.Focus()
            Exit Sub
        End If

        If tbxNroCuenta.Text = "" Then
            MessageBox.Show("Ingrese un Nro de Cuenta", "POSEXPRESS")
            tbxNroCuenta.Focus()
            Exit Sub
        End If

        If tbxNivel.Text = "" Then
            MessageBox.Show("Ingrese un Nivel de Cuenta", "POSEXPRESS")
            tbxNivel.Focus()
            Exit Sub
        End If

        If cbxImputable.Text = "" Then
            MessageBox.Show("Indique si la Cuenta es Imputable", "POSEXPRESS")
            cbxImputable.Focus()
            Exit Sub
        End If

        If cbxTipoCuenta.Text = "" Then
            MessageBox.Show("Indique el Tipo de Cuenta", "POSEXPRESS")
            cbxImputable.Focus()
            Exit Sub
        End If

        'Obtenemos los datos de los RadioBotton 
        ReglaAplicada = 0 : DetalleRegla = 0 : ProdServ = 0

        If rbtnCliente1.Checked = True Then         'Cliente Especifico
            ReglaAplicada = 1
            DetalleRegla = cbxCliente.SelectedValue

        ElseIf rbtnClienteGen2.Checked = True Then  'Cliente Generico
            ReglaAplicada = 2

        ElseIf rbtnProveedor3.Checked = True Then   'Proveedor Especifico
            ReglaAplicada = 3
            DetalleRegla = cbxProveedor.SelectedValue

        ElseIf rbtnProveedorGen4.Checked = True Then 'Proveedor Generico
            ReglaAplicada = 4

        ElseIf rbtnIVA5.Checked = True Then          'Movimiento de Iva
            ReglaAplicada = 5

            If cbxIVA.Text = "I.V.A 5%" Then
                DetalleRegla = 5
            ElseIf cbxIVA.Text = "I.V.A 10%" Then
                DetalleRegla = 10
            ElseIf cbxIVA.Text = "Exento" Then
                DetalleRegla = 0
            End If

        ElseIf rbtnVenta11.Checked = True Then     'Ventas de Productos / Servicios
            ReglaAplicada = 6
 
            If cbxMovVentas.Text = "Producto" Then
                DetalleRegla = 1
            ElseIf cbxMovVentas.Text = "Servicio" Then
                DetalleRegla = 0
            ElseIf cbxMovVentas.Text = "Costo de Venta" Then
                DetalleRegla = 3
            End If

        ElseIf rbtnMovimientoGen8.Checked = True Then 'Moviemiento de Caja Generico
            ReglaAplicada = 7

        ElseIf rbtnMonetario7.Checked = True Then    'Movimiento de Caja
            ReglaAplicada = 8
            DetalleRegla = cbxMonetario.SelectedValue

        ElseIf rbtnProducto6.Checked = True Then 'Compras de Productos / Servicios
            ReglaAplicada = 11
            DetalleRegla = cbxProducto.SelectedValue

        ElseIf rbtAnticipo.Checked = True Then ' Anticipo de Clientes - Proveedores
            ReglaAplicada = 12
            If cbxAnticipo.Text = "Clientes" Then
                DetalleRegla = 1
            ElseIf cbxAnticipo.Text = "Proveedores" Then
                DetalleRegla = 2
            End If

        ElseIf rbtRetencion.Checked = True Then ' Retenciones de IVA
            If cbxRetencion.Text = "Ventas" Then
                ReglaAplicada = 15
                DetalleRegla = 15 'Por ser venta
            ElseIf cbxRetencion.Text = "Compras" Then
                ReglaAplicada = 14
                DetalleRegla = 14 'Por ser Compra
            End If
        End If

        If cbxTipoCuenta.Text = "Ingreso" Then
            TipoCuenta = 4
        ElseIf cbxTipoCuenta.Text = "Egreso" Then
            TipoCuenta = 5
        ElseIf cbxTipoCuenta.Text = "Pasivo" Then
            TipoCuenta = 2
        ElseIf cbxTipoCuenta.Text = "Activo" Then
            TipoCuenta = 1
        ElseIf cbxTipoCuenta.Text = "Patrimonio Neto" Then
            TipoCuenta = 3
        ElseIf cbxTipoCuenta.Text = "Regularizadora del Activo" Then
            TipoCuenta = 6
        End If

        Dim resultado As Integer
        If cbxResultado.Text = "Ganancia del Ejercicio" Then
            resultado = 1
        ElseIf cbxResultado.Text = "Pérdida del Ejercicio" Then
            resultado = 2
        End If

        If cbxSaldoEsperado.Text = "Deudor" Then
            SaldoEsperado = 1
        ElseIf cbxSaldoEsperado.Text = "Acreedor" Then
            SaldoEsperado = 2
        End If

        'Guardamos en la base de datos
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            sql = "UPDATE plancuentas SET " & _
                  "NUMPLANCUENTA ='" & tbxNroCuenta.Text & "', " & _
                  "DESPLANCUENTA ='" & tbxDescripcionCuenta.Text & "' , " & _
                  "NIVELCUENTA = " & tbxNivel.Text & " , " & _
                  "ASENTABLE = '" & cbxImputable.Text & "' , " & _
                  "TIPOCUENTA = " & TipoCuenta & " , " & _
                  "SALDOESPERADO = " & SaldoEsperado & " , " & _
                  "DESTIPOCUENTA = '" & cbxTipoCuenta.Text & "' , " & _
                  "RESULTADO = " & resultado & " , " & _
                  "FECGRA = GETDATE() , " & _
                  "REGLA = " & ReglaAplicada & ", REGLAFK = " & DetalleRegla & _
                  " WHERE CODPLANCUENTA = " & tbxCodPlanCuenta.Text

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()

            Dim I As Integer = PlancuentasBindingSource.Position
            Me.PlancuentasTableAdapter.FillByTodos(Me.DsPlantillasConta.plancuentas)
            PlancuentasBindingSource.Position = I
            MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

            DesHabilitar()
            lblErrorRegla.Visible = False

            'INSERTAMOS EN AUDITORIA 
            If AccNuevo = 1 Then
                InsertaAuditoria(1, 0, 0)
            ElseIf AccEditar = 1 Then
                InsertaAuditoria(0, 1, 0)
            End If
            '#########################

        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch

            End Try
            MessageBox.Show("Ocurrio un error ", "POSEXPRESS")
            Me.pbxCancelar.PerformLayout()

        Finally
            sqlc.Close()

        End Try

    End Sub

    Private Sub pbxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEliminar.Click
        If MessageBox.Show("¿Esta seguro que quiere eliminar la Cuenta?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If tbxCodPlanCuenta.Text = "" Then
            MessageBox.Show("Ocurrio un error, seleccione una Cuenta", "POSEXPRESS")
            DesHabilitar()
            Exit Sub
        End If

        Dim transaction As SqlTransaction = Nothing
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            EliminaCuenta()

            myTrans.Commit()
            Me.PlancuentasTableAdapter.FillByTodos(Me.DsPlantillasConta.plancuentas)
            MessageBox.Show("Cuenta eliminada correctamente", "POSEXPRESS")
            DesHabilitar()

            'INSERTAMOS EN AUDITORIA 
            InsertaAuditoria(0, 0, 1)
            '#########################
        Catch ex As SqlException
            Try
                myTrans.Rollback("")
            Catch

            End Try

            Dim NroError As Integer = ex.Number
            Dim Mensaje As String = ex.Message

            If NroError = 547 Then
                MessageBox.Show("La Cuenta que desea eliminar tiene relacion con alguna otra tabla del Sistema", "POSEXPRESS")
            Else
                MessageBox.Show("Ocurrio un error el eliminar la Cuenta" + ex.Message, "POSEXPRESS")
            End If

        Finally
            sqlc.Close()

        End Try
    End Sub

    Private Sub EliminaCuenta()
        sql = ""
        sql = " DELETE FROM plancuentas " & _
              " WHERE CODPLANCUENTA= " & CDec(tbxCodPlanCuenta.Text)
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

#End Region

    Private Sub tbxDescripcionCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxDescripcionCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxNroCuenta.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxNroCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxNivel.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxNivel_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNivel.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxImputable.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxImputable_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxImputable.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxTipoCuenta.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxTipoCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxSaldoEsperado.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub rbtnVenta11_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtnVenta11.CheckedChanged
        If rbtnVenta11.Checked = True Then
            cbxMovVentas.Enabled = True
            cbxMovVentas.BringToFront()
        Else
            cbxMovVentas.Enabled = False
            cbxMovVentas.SendToBack()
        End If
    End Sub

    Private Sub rbtAnticipo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtAnticipo.CheckedChanged
        If rbtAnticipo.Checked = True Then
            cbxAnticipo.Enabled = True
        Else
            cbxAnticipo.Enabled = False
        End If
    End Sub

    Private Sub rbtRetencion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtRetencion.CheckedChanged
        If rbtRetencion.Checked = True Then
            cbxRetencion.Enabled = True
        Else
            cbxRetencion.Enabled = False
        End If
    End Sub
End Class