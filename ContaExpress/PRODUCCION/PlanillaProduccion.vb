Imports System
Imports System.Data
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class PlanillaProduccion

    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction
    Dim f As New Funciones.Funciones

    Dim UltimoRegistro, UltimoRegistroEmpleado As Integer
    Dim costoUnitario, PrecioCostoTotal As Double
    Dim vAccion As String = ""
    Dim FechaFiltro1, FechaFiltro2 As Date

    Public Sub New()
        Me.InitializeComponent()

        ser = New BDConexión.BDConexion
        cmd = New SqlCommand
        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub PlanillaProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tipoSucursal1 As String = "Solo Stock"
        Dim tipoSucursal2 As String = "Factura y Stock"
        Me.PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.Fill(Me.PlanilladeProduccionFinal.PLANILLAPRODUCCION_EMPLEADO_REL)

        Me.PLANILLADEDEPRODUCCIONDETALLETableAdapter.Fill(Me.PlanilladeProduccionFinal.PLANILLADEDEPRODUCCIONDETALLE)

        Me.COMBOSTableAdapter.Fill(Me.PlanilladeProduccionFinal.COMBOS)

        Me.EMPLEADOSTableAdapter.Fill(Me.PlanilladeProduccionFinal.EMPLEADOS)

        Me.DataTable1TableAdapter.Fill(Me.PlanilladeProduccionFinal.DataTable1)

        Me.ORDENPRODUCCIONTableAdapter.Fill(Me.PlanilladeProduccionFinal.ORDENPRODUCCION)

        Me.PLANILLADEPRODUCCIONTableAdapter.Fill(Me.PlanilladeProduccionFinal.PLANILLADEPRODUCCION)

        Me.SUCURSALTableAdapter.Fill(Me.PlanilladeProduccionFinal.SUCURSAL, tipoSucursal1, tipoSucursal2)

        Me.TIPOPRODUCCIONTableAdapter.Fill(Me.PlanilladeProduccionFinal.TIPOPRODUCCION)

        DesHabilitar()
        vAccion = "I"
    End Sub

#Region "Procesos"
    Sub dgvPlanillaProduccion_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPlanillaProduccion.SelectionChanged
        PrecioCostoTotal = 0
        lblPrecioCostoTotal.Text = 0
        If vAccion = "U" Then
            CalcularCostoTotal()
        ElseIf vAccion <> "D" Then
            tbxCantBruto.Text = dgvPlanillaProduccion.CurrentRow.Cells("CANTBRUTODataGridViewTextBoxColumn").Value
            tbxCantAveriado.Text = dgvPlanillaProduccion.CurrentRow.Cells("CANTAVERIADODataGridViewTextBoxColumn").Value
            tbxCantNeto.Text = dgvPlanillaProduccion.CurrentRow.Cells("CANTNETODataGridViewTextBoxColumn").Value
            PLANILLADEDEPRODUCCIONDETALLETableAdapter.FillBy(PlanilladeProduccionFinal.PLANILLADEDEPRODUCCIONDETALLE, CInt(dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value))
            PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.FillBy(PlanilladeProduccionFinal.PLANILLAPRODUCCION_EMPLEADO_REL, CInt(dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value))
            lblPrecioCostoTotal.Text = dgvPlanillaProduccion.CurrentRow.Cells("DataGridViewTextBoxColumn4").Value
            'CalcularCostoTotal()
        End If
        vAccion = "I"
    End Sub

    Sub CalcularCostoTotal()
        Try
            If dgvPlanillaDetalle.RowCount <> 0 Then
                PrecioCostoTotal = 0
                For i = 0 To dgvPlanillaDetalle.Rows.Count - 1
                    If dgvPlanillaDetalle.Rows(i).Cells("EventoGrilla").Value <> "D" Then
                        PrecioCostoTotal = PrecioCostoTotal + (dgvPlanillaDetalle.Rows(i).Cells("DataGridViewTextBoxColumn5").Value)
                    End If
                Next

                lblPrecioCostoTotal.Text = CInt(PrecioCostoTotal).ToString
            End If
            If dgvEmployee.RowCount <> 0 Then
                For i = 0 To dgvEmployee.Rows.Count - 1
                    If dgvEmployee.Rows(i).Cells("DataGridViewTextBoxColumn3").Value <> "D" Then
                        PrecioCostoTotal = PrecioCostoTotal + dgvEmployee.Rows(i).Cells("Costo").Value
                    End If
                Next

                lblPrecioCostoTotal.Text = CInt(PrecioCostoTotal).ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DesHabilitar()
        NuevoPictureBox.Enabled = False
        'pnlDetalle.Enabled = False

        dgvPlanillaProduccion.Enabled = True
        BuscarTextBox.Enabled = True

        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Cursor = Cursors.Hand
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Cursor = Cursors.Hand
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow


        cbxTipoProd.Text = ""
        cbxSucursal.Text = ""
        cbxOrdenProduccion.Text = ""
        cbxProductoRealizar.Text = ""
        cbxProductoIngrediente.Text = ""
        tbxCantidadIngrediente.Text = ""
        tbxCostoIngrediente.Text = ""
        tbxCostAdm.Text = ""
        tbxCantBruto.Text = ""
        tbxCantAveriado.Text = ""
        tbxCantNeto.Text = ""

    End Sub

    Private Sub Habilitar()
        pnlCabecera.Enabled = True
        'pnlDetalle.Enabled = True

        dgvPlanillaProduccion.Enabled = False
        BuscarTextBox.Enabled = False

        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Cursor = Cursors.Arrow
        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Image = My.Resources.DeleteOff
        EliminarPictureBox.Cursor = Cursors.Arrow
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand
        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        GuardarPictureBox.Cursor = Cursors.Hand
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If tbxCantidadIngrediente.Text = "" Then
                MessageBox.Show("Ingrese la Cantidad a producir", "COGENT SIG", MessageBoxButtons.OK)
                tbxCantidadIngrediente.Focus()
                Exit Sub
            End If
            PLANILLADEDEPRODUCCIONDETALLEBindingSource.AddNew()
            Dim c As Integer = dgvPlanillaDetalle.RowCount
            dgvPlanillaDetalle.Rows(c - 1).Cells("IDPLANILLAPRODUCCIONDataGridViewTextBoxColumn").Value = dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value
            dgvPlanillaDetalle.Rows(c - 1).Cells("CODIGODataGridViewTextBoxColumn").Value = COMBOSBindingSource.Current("CODIGO")
            dgvPlanillaDetalle.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = COMBOSBindingSource.Current("CODCODIGO")
            dgvPlanillaDetalle.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value = cbxProductoIngrediente.SelectedValue
            dgvPlanillaDetalle.Rows(c - 1).Cells("CANTIDAPRODREALDataGridViewTextBoxColumn").Value = CInt(tbxCantidadIngrediente.Text * tbxCantBruto.Text).ToString
            dgvPlanillaDetalle.Rows(c - 1).Cells("CANTIDADPRODUCIDADataGridViewTextBoxColumn").Value = CInt(tbxCantidadIngrediente.Text).ToString
            dgvPlanillaDetalle.Rows(c - 1).Cells("DataGridViewTextBoxColumn5").Value = CInt((tbxCostoIngrediente.Text * tbxCantidadIngrediente.Text) * tbxCantBruto.Text).ToString
            dgvPlanillaDetalle.Rows(c - 1).Cells("ID_ORDENTRABAJO").Value = cbxOrdenProduccion.SelectedValue
            dgvPlanillaDetalle.Rows(c - 1).Cells("CODSUCURSAL").Value = COMBOSBindingSource.Current("CODSUCURSAL")
            'dgvPlanillaDetalle.Rows(c - 1).Cells("CODSUCURSAL").Value = COMBOSBindingSource.Current("CODSUCURSAL")
            'dgwOPDetalle.Rows(c - 1).Cells("TIPOPRODUCTO").Value = cbxOrdenProduccion.SelectedValue
            dgvPlanillaDetalle.Rows(c - 1).Cells("EventoGrilla").Value = "I"

            CalcularCostoTotal()
            'tbxCantidadIngrediente.Text = "" : cbxProductoIngrediente.SelectedItem = Nothing : cbxCodigoIngrediente.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnEliminarProducto_Click(sender As Object, e As EventArgs) Handles btnEliminarProducto.Click
        Try
            dgvPlanillaDetalle.CurrentRow.Cells("EventoGrilla").Value = "D"
            For C = 0 To dgvPlanillaDetalle.ColumnCount - 1
                dgvPlanillaDetalle.Item(C, dgvPlanillaDetalle.CurrentRow.Index).Style.BackColor = Color.Pink
            Next
            CalcularCostoTotal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "ABM"
    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        Habilitar()
        dtpFecha.Value = Now()
        dtpFecha.Focus()
        vAccion = "I"
        'tbxCantBruto.Clear()
        'tbxCantAveriado.Clear()
        'tbxCantNeto.Clear()
        Try
            PrecioCostoTotal = 0
            lblPrecioCostoTotal.Text = 0
            PLANILLADEPRODUCCIONBindingSource.RemoveFilter()
            PLANILLADEPRODUCCIONBindingSource.AddNew()
            For i = 0 To dgvPlanillaProduccion.Rows.Count - 1
                If UltimoRegistro = dgvPlanillaProduccion.Rows(i).Cells("IDDataGridViewTextBoxColumn").Value Then
                    PLANILLADEPRODUCCIONBindingSource.Position = i + 1
                End If
            Next
            PLANILLADEDEPRODUCCIONDETALLETableAdapter.FillBy(PlanilladeProduccionFinal.PLANILLADEDEPRODUCCIONDETALLE, CInt(dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value))
            PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.FillBy(PlanilladeProduccionFinal.PLANILLAPRODUCCION_EMPLEADO_REL, CInt(dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value))
            Me.COMBOSTableAdapter.Fill(Me.PlanilladeProduccionFinal.COMBOS)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub GuardarPictureBox_Click(sender As Object, e As EventArgs) Handles GuardarPictureBox.Click
        Try
            'Dim movcantidad As Double
            Dim rowDetail As Integer

            UltimoRegistro = f.Maximo("ID", "PLANILLADEPRODUCCION")
            UltimoRegistro = UltimoRegistro + 1
            Dim Sql As String = ""
            If vAccion = "I" Then
                ser.Abrir(sqlc)
                cmd.Connection = sqlc

                Sql = "INSERT PLANILLADEPRODUCCION (ID_ORDENPRODUCCION,FECHA,OBS,CODCODIGO,CODSUCURSAL,CANTBRUTO,CANTAVERIADO,CANTNETO,TIPOPRODUCCION, COSTO) " & _
                                    "VALUES('" & cbxOrdenProduccion.SelectedValue & "', CONVERT (DATETIME, '" & dtpFecha.Text & "',103), '" & txtOBS.Text & "','" & _
                                    cbxProductoRealizar.SelectedValue & "','" & cbxSucursal.SelectedValue & "','" & tbxCantBruto.Text & "','" & tbxCantAveriado.Text & "','" & _
                                    tbxCantNeto.Text & "','" & cbxTipoProd.SelectedValue & "','" & lblPrecioCostoTotal.Text & "') " & _
                                    "SELECT ID FROM PLANILLADEPRODUCCION WHERE ID = SCOPE_IDENTITY();"

                cmd.CommandText = Sql
                UltimoRegistro = cmd.ExecuteScalar

                Sql = "INSERT INTO MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,CANTIDAD,VALOR,STOCK) " & _
                       "VALUES(" & UsuCodigo & ",'" & cbxProductoRealizar.SelectedValue & "','" & cbxSucursal.SelectedValue & "',CONVERT(Datetime,'" & dtpFecha.Text & "',103)" & _
                       ",'" & tbxCantNeto.Text & "','" & CInt(lblPrecioCostoTotal.Text / tbxCantBruto.Text).ToString & "',1)"
                cmd.CommandText = Sql
                cmd.ExecuteScalar()

                'Actualizar Detalle
                For rowDetail = 0 To dgvPlanillaDetalle.Rows.Count - 1
                    If dgvPlanillaDetalle.Rows(rowDetail).Cells("EventoGrilla").Value = "I" Then

                        PLANILLADEDEPRODUCCIONDETALLETableAdapter.InsertQuery(UltimoRegistro, dgvPlanillaDetalle.Rows(rowDetail).Cells("CODCODIGODataGridViewTextBoxColumn1").Value, dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDADPRODUCIDADataGridViewTextBoxColumn").Value, dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDAPRODREALDataGridViewTextBoxColumn").Value, CInt(dgvPlanillaDetalle.Rows(rowDetail).Cells("DataGridViewTextBoxColumn5").Value).ToString, cbxOrdenProduccion.SelectedValue)
                        Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,CANTIDAD,VALOR,STOCK) " & _
                              "VALUES('" & UsuCodigo & "','" & dgvPlanillaDetalle.Rows(rowDetail).Cells("CODCODIGODataGridViewTextBoxColumn1").Value & "','" & dgvPlanillaDetalle.Rows(rowDetail).Cells("CODSUCURSAL").Value & "',CONVERT(Datetime,'" & dtpFecha.Text & "',103)" & _
                              ",'-" & (dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDAPRODREALDataGridViewTextBoxColumn").Value * tbxCantBruto.Text) & "','" & CInt((dgvPlanillaDetalle.Rows(rowDetail).Cells("DataGridViewTextBoxColumn5").Value / dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDADPRODUCIDADataGridViewTextBoxColumn").Value) / tbxCantBruto.Text).ToString & "', 1)"
                        cmd.CommandText = Sql
                        cmd.ExecuteScalar()

                    ElseIf dgvPlanillaDetalle.Rows(rowDetail).Cells("EventoGrilla").Value = "D" Then

                        'PLANILLADEDEPRODUCCIONDETALLETableAdapter.DeleteQuery(dgvPlanillaDetalle.Rows(rowDetail).Cells("IDDataGridViewTextBoxColumn1").Value)
                        'Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,CANTIDAD,VALOR,STOCK) " & _
                        '     "VALUES('" & UsuCodigo & "','" & dgvPlanillaDetalle.Rows(rowDetail).Cells("CODCODIGODataGridViewTextBoxColumn1").Value & "','" & dgvPlanillaDetalle.Rows(rowDetail).Cells("CODSUCURSAL").Value & "',CONVERT(Datetime,'" & dtpFecha.Text & "',103)" & _
                        '     ",'" & (dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDAPRODREALDataGridViewTextBoxColumn").Value * tbxCantBruto.Text) & "','" & dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDADPRODUCIDADataGridViewTextBoxColumn").Value & "'1)"
                        'cmd.CommandText = Sql
                        'cmd.ExecuteScalar()
                    End If
                Next

                For rowEmployee = 0 To dgvEmployee.Rows.Count - 1
                    If dgvEmployee.Rows(rowEmployee).Cells("DataGridViewTextBoxColumn3").Value = "I" Then
                        'UltimoRegistroEmpleado = f.Maximo("ID", "PLANILLAPRODUCCION_EMPLEADO_REL")
                        'UltimoRegistroEmpleado = UltimoRegistroEmpleado + 1
                        'Sql = "INSERT PLANILLAPRODUCCION_EMPLEADO_REL (ID_PLANILLAPRODUCCION,ID_EMPLEADO,PAGO) " & _
                        '    "VALUES(" & UltimoRegistro & "," & dgvEmployee.Rows(rowEmployee).Cells("ID_EMPLEADO").Value & "," & dgvEmployee.Rows(rowEmployee).Cells("Costo").Value & ")" & _
                        '    " SELECT ID FROM PLANILLAPRODUCCION_EMPLEADO_REL WHERE ID =" & UltimoRegistroEmpleado & ""
                        'cmd.CommandText = Sql
                        'cmd.ExecuteScalar()
                        PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.InsertQuery(UltimoRegistro, dgvEmployee.Rows(rowEmployee).Cells("ID_EMPLEADO").Value, dgvEmployee.Rows(rowEmployee).Cells("Costo").Value)

                    End If
                Next
            Else

                UltimoRegistro = dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value
                'PLANILLADEPRODUCCIONTableAdapter.UpdateQuery(cbxOrdenProduccion.SelectedValue, cbxProductoRealizar.SelectedValue, cbxSucursal.SelectedValue, tbxCantBruto.Text, tbxCantAveriado.Text, tbxCantNeto.Text, dtpFecha.Value, txtOBS.Text, UltimoRegistro)

                'Actualizar Detalle
                For rowdetail = 0 To dgvPlanillaDetalle.Rows.Count - 1
                    If dgvPlanillaDetalle.Rows(rowDetail).Cells("EventoGrilla").Value = "I" Then

                        PLANILLADEDEPRODUCCIONDETALLETableAdapter.InsertQuery(UltimoRegistro, dgvPlanillaDetalle.Rows(rowDetail).Cells("CODCODIGODataGridViewTextBoxColumn1").Value, dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDAPRODREALDataGridViewTextBoxColumn").Value, dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDADPRODUCIDADataGridViewTextBoxColumn").Value, dgvPlanillaDetalle.Rows(rowDetail).Cells("PRECIODataGridViewTextBoxColumn").Value, cbxOrdenProduccion.SelectedValue)
                        Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,CANTIDAD,STOCK) " & _
                             "VALUES(" & UsuCodigo & "," & dgvPlanillaDetalle.Rows(rowDetail).Cells("CODCODIGODataGridViewTextBoxColumn1").Value & "," & dgvPlanillaDetalle.Rows(rowDetail).Cells("CODSUCURSAL").Value & ",CONVERT(Datetime,'" & dtpFecha.Text & "',103)" & _
                             ",-" & (dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDAPRODREALDataGridViewTextBoxColumn").Value * tbxCantBruto.Text) & ",1)"
                        cmd.CommandText = Sql
                        cmd.ExecuteScalar()

                    ElseIf dgvPlanillaDetalle.Rows(rowDetail).Cells("EventoGrilla").Value = "D" Then

                        PLANILLADEDEPRODUCCIONDETALLETableAdapter.DeleteQuery(dgvPlanillaDetalle.Rows(rowDetail).Cells("IDDataGridViewTextBoxColumn1").Value)
                        Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,CANTIDAD,STOCK) " & _
                             "VALUES(" & UsuCodigo & "," & dgvPlanillaDetalle.Rows(rowDetail).Cells("CODCODIGODataGridViewTextBoxColumn1").Value & "," & dgvPlanillaDetalle.Rows(rowDetail).Cells("CODSUCURSAL").Value & ",CONVERT(Datetime,'" & dtpFecha.Text & "',103)" & _
                             "," & (dgvPlanillaDetalle.Rows(rowDetail).Cells("CANTIDAPRODREALDataGridViewTextBoxColumn").Value * tbxCantBruto.Text) & ",1)"
                        cmd.CommandText = Sql
                        cmd.ExecuteScalar()
                    End If
                Next

                For rowEmployee = 0 To dgvEmployee.Rows.Count - 1
                    If dgvEmployee.Rows(rowEmployee).Cells("DataGridViewTextBoxColumn3").Value = "I" Then
                        'UltimoRegistroEmpleado = f.Maximo("ID", "PLANILLAPRODUCCION_EMPLEADO_REL")
                        'UltimoRegistroEmpleado = UltimoRegistroEmpleado + 1
                        'Sql = "INSERT PLANILLAPRODUCCION_EMPLEADO_REL (ID_PLANILLAPRODUCCION,ID_EMPLEADO,PAGO) " & _
                        '  "VALUES(" & UltimoRegistro & "," & dgvEmployee.Rows(rowEmployee).Cells("ID_EMPLEADO").Value & "," & dgvEmployee.Rows(rowEmployee).Cells("Costo").Value & ")" & _
                        '                            " SELECT ID FROM PLANILLAPRODUCCION_EMPLEADO_REL WHERE ID =" & UltimoRegistroEmpleado & ""

                        'cmd.CommandText = Sql
                        'cmd.ExecuteScalar()
                        PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.InsertQuery(UltimoRegistro, dgvEmployee.Rows(rowEmployee).Cells("ID_EMPLEADO").Value, dgvEmployee.Rows(rowEmployee).Cells("Costo").Value)
                    ElseIf dgvEmployee.Rows(rowEmployee).Cells("DataGridViewTextBoxColumn2").Value = "D" Then
                        PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.DeleteQuery(dgvEmployee.Rows(rowEmployee).Cells("ID").Value)
                    End If
                Next
            End If

            vAccion = "U"

            Me.PLANILLADEPRODUCCIONTableAdapter.Fill(PlanilladeProduccionFinal.PLANILLADEPRODUCCION)
            For i = 0 To dgvPlanillaProduccion.Rows.Count - 1
                If UltimoRegistro = dgvPlanillaProduccion.Rows(i).Cells("IDDataGridViewTextBoxColumn").Value Then
                    PLANILLADEPRODUCCIONBindingSource.Position = i
                End If
            Next
            Me.PLANILLADEDEPRODUCCIONDETALLETableAdapter.FillBy(PlanilladeProduccionFinal.PLANILLADEDEPRODUCCIONDETALLE, CInt(dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value))
            Me.PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.FillBy(PlanilladeProduccionFinal.PLANILLAPRODUCCION_EMPLEADO_REL, CInt(dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value))


            DesHabilitar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarPictureBox_Click(sender As Object, e As EventArgs) Handles EliminarPictureBox.Click
        If MessageBox.Show("¿Esta seguro que quiere Eliminar?", "COGENT SIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            vAccion = "D"
            ser.Abrir(sqlc)
            cmd.Connection = sqlc
            Dim Sql As String = ""
            btnAnulado = 1
            btAprobado = 0
            Dim RegistroActual As Integer = dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value

            'DescontarStock antes de eliminar 
            If dgvPlanillaDetalle.RowCount <> 0 Then
                For rowdetail = 0 To dgvPlanillaDetalle.Rows.Count - 1
                    Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,FECHAMOVIMIENTO,CANTIDAD,VALOR,STOCK) " & _
                          "VALUES(" & UsuCodigo & "," & dgvPlanillaDetalle.Rows(rowdetail).Cells("CODCODIGODataGridViewTextBoxColumn1").Value & ",CONVERT(Datetime,'" & dtpFecha.Text & "',103)" & _
                          "," & (dgvPlanillaDetalle.Rows(rowdetail).Cells("CANTIDAPRODREALDataGridViewTextBoxColumn").Value * tbxCantBruto.Text) & ",'" & CInt((dgvPlanillaDetalle.Rows(rowdetail).Cells("DataGridViewTextBoxColumn5").Value / dgvPlanillaDetalle.Rows(rowdetail).Cells("CANTIDADPRODUCIDADataGridViewTextBoxColumn").Value) / tbxCantBruto.Text).ToString & "',1)"
                    cmd.CommandText = Sql
                    cmd.ExecuteScalar()
                Next
                PLANILLADEDEPRODUCCIONDETALLETableAdapter.DeleteQueryTODO(RegistroActual)
            End If

            'Eliminar empleado
            If dgvEmployee.RowCount <> 0 Then
                PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.DeleteQueryTODO(RegistroActual)
            End If

            'DescontarStock antes de eliminar 
            Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,FECHAMOVIMIENTO,CANTIDAD,VALOR,STOCK) " & _
                "VALUES(" & UsuCodigo & ",'" & dgvPlanillaProduccion.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value & "',CONVERT(Datetime,'" & dtpFecha.Text & "',103)" & _
                ",'-" & tbxCantNeto.Text & "','" & CInt(lblPrecioCostoTotal.Text / tbxCantBruto.Text).ToString & "', 1)"
            cmd.CommandText = Sql
            cmd.ExecuteScalar()
            PLANILLADEPRODUCCIONTableAdapter.DeleteQuery(RegistroActual)

            Me.PLANILLADEDEPRODUCCIONDETALLETableAdapter.Fill(PlanilladeProduccionFinal.PLANILLADEDEPRODUCCIONDETALLE)
            Me.PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.Fill(PlanilladeProduccionFinal.PLANILLAPRODUCCION_EMPLEADO_REL)
            Me.PLANILLADEPRODUCCIONTableAdapter.Fill(PlanilladeProduccionFinal.PLANILLADEPRODUCCION)

        Catch ex As Exception
            MessageBox.Show("Error al Eliminar :" & ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Try
            PLANILLADEPRODUCCIONBindingSource.CancelEdit()
            PLANILLADEDEPRODUCCIONDETALLEBindingSource.CancelEdit()
            PLANILLAPRODUCCIONEMPLEADORELBindingSource.CancelEdit()
            DesHabilitar()
            Me.PLANILLADEPRODUCCIONTableAdapter.Fill(PlanilladeProduccionFinal.PLANILLADEPRODUCCION)
            Me.PLANILLAPRODUCCION_EMPLEADO_RELTableAdapter.FillBy(PlanilladeProduccionFinal.PLANILLAPRODUCCION_EMPLEADO_REL, CInt(dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value))
            Me.PLANILLADEDEPRODUCCIONDETALLETableAdapter.FillBy(PlanilladeProduccionFinal.PLANILLADEDEPRODUCCIONDETALLE, CInt(dgvPlanillaProduccion.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value))

            'tbxCantidadIngrediente.Text = "" : cbxProductoIngrediente.SelectedValue = Nothing
            'cbxOrdenProduccion.SelectedValue = Nothing : cbxProductoRealizar.SelectedValue = Nothing : cbxSucursal.SelectedValue = Nothing
            'tbxCantBruto.Text = "" : tbxCantAveriado.Text = "" : tbxCantNeto.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "KeyPress"
    Sub tbxCantAveriado_textChanged(sender As Object, e As EventArgs) Handles tbxCantAveriado.TextChanged
        CalcularNeto()
    End Sub

    Sub CalcularNeto()
        Try
            tbxCantNeto.Text = CInt(tbxCantBruto.Text - tbxCantAveriado.Text).ToString
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub cbxOrdenProduccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxOrdenProduccion.SelectionChangeCommitted
        'tbxIdOrdenProduccion.Text = cbxOrdenProduccion.SelectedValue
        'COMBOSBindingSource.Filter = "ID_ORDENPRODUCCION ='" & cbxOrdenProduccion.SelectedValue & "'"
        DataTable1BindingSource.Filter = "ID_ORDEN_PRODUCCION ='" & cbxOrdenProduccion.SelectedValue & "'"
        cbxProductoRealizar.Focus()
    End Sub

    Private Sub cbxProductoRealizar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProductoRealizar.SelectedIndexChanged
        If cbxProductoRealizar.Text = "" Then
            Exit Sub
        Else
            COMBOSBindingSource.Filter = "CODPRODUCTO ='" & cbxProductoRealizar.SelectedValue & "'"
        End If

        If cbxProductoIngrediente.Text = "" Then
            COMBOSBindingSource.Filter = Nothing
        End If
        tbxCantBruto.Focus()
    End Sub

    Private Sub cbxProductoReceta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProductoIngrediente.SelectedIndexChanged
        Try
            tbxCantidadIngrediente.Text = COMBOSBindingSource.Current("CANTIDAD")
            tbxCostoIngrediente.Text = COMBOSBindingSource.Current("PRECIO")
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Mano se Obra"

    Private Sub pbxAgregarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarEmpleado.Click
        cbxListaEmpleados.SelectedItem = Nothing
        Empleados.ShowDialog()
        Me.EMPLEADOSTableAdapter.Fill(PlanilladeProduccionFinal.EMPLEADOS)
    End Sub

    Sub tbxMinutos_TextChanged(sender As Object, e As EventArgs) Handles tbxMinutos.TextChanged
        Try
            tbxMontoCorrespondiente.Text = CInt((((EMPLEADOSBindingSource.Current("SALARIO") / 30) / 8) / 60) * tbxMinutos.Text).ToString
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btnAgregarEmpleado_Click(sender As Object, e As EventArgs) Handles btnAgregarEmpleado.Click
        Try
            If tbxMinutos.Text = "" Then
                MessageBox.Show("Ingrese los minutos a emplear", "COGENT SIG", MessageBoxButtons.OK)
                tbxCantidadIngrediente.Focus()
                Exit Sub
            End If
            PLANILLAPRODUCCIONEMPLEADORELBindingSource.AddNew()
            Dim c As Integer = dgvEmployee.RowCount
            dgvEmployee.Rows(c - 1).Cells("ID").Value = c
            dgvEmployee.Rows(c - 1).Cells("ID_EMPLEADO").Value = EMPLEADOSBindingSource.Current("IDEMPLEADO")
            dgvEmployee.Rows(c - 1).Cells("Codigo").Value = EMPLEADOSBindingSource.Current("CODEMPLEADO")
            dgvEmployee.Rows(c - 1).Cells("Nombre").Value = EMPLEADOSBindingSource.Current("NOMBRE")
            dgvEmployee.Rows(c - 1).Cells("Costo").Value = tbxMontoCorrespondiente.Text
            dgvEmployee.Rows(c - 1).Cells("DataGridViewTextBoxColumn3").Value = "I"
            PLANILLAPRODUCCIONEMPLEADORELBindingSource.EndEdit()
            CalcularCostoTotal()
            'tbxCantidadIngrediente.Text = "" : cbxProductoIngrediente.SelectedItem = Nothing : cbxCodigoIngrediente.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnEliminarEmpleado_Click(sender As Object, e As EventArgs) Handles btnEliminarEmpleado.Click
        Try
            dgvEmployee.CurrentRow.Cells("DataGridViewTextBoxColumn3").Value = "D"
            For C = 0 To dgvEmployee.ColumnCount - 1
                dgvEmployee.Item(C, dgvEmployee.CurrentRow.Index).Style.BackColor = Color.Pink
            Next
            CalcularCostoTotal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "FILTRO"
    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Me.PLANILLADEPRODUCCIONBindingSource.Filter = " FECHA >= '" & FechaFiltro1 & "' AND FECHA <= '" & FechaFiltro2 & "' AND TIPOPRODUCCION = '" & cbxFiltroTipoProd.SelectedValue & "'"
        'Me.PLANILLADEDEPRODUCCIONDETALLETableAdapter.Fillby(PlanilladeProduccionFinal.PLANILLADEDEPRODUCCIONDETALLE, )
        'SumarTotales()
    End Sub

    Sub FechaFiltro()
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
    End Sub
#End Region
   
    Private Sub pbxAgregarTipoProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarTipoProd.Click
        cbxTipoProd.SelectedItem = Nothing
        TipoProduccion.ShowDialog()
        Me.TIPOPRODUCCIONTableAdapter.Fill(PlanilladeProduccionFinal.TIPOPRODUCCION)
    End Sub

    Private Sub btnSumCostAdm_Click(sender As Object, e As EventArgs) Handles btnSumCostAdm.Click
        lblPrecioCostoTotal.Text = CInt(CDec(lblPrecioCostoTotal.Text).ToString + CDec(tbxCostAdm.Text)).ToString
    End Sub

    'Private Sub tbxCostAdm_TextChanged(sender As Object, e As EventArgs) Handles lblPrecioCostoTotal.TextChanged, tbxCostAdm.LostFocus
    '    If tbxCostAdm.Text <> "" Then
    '        lblPrecioCostoTotal.Text = CInt(lblPrecioCostoTotal.Text + tbxCostAdm.Text).ToString
    '    End If
    'End Sub
End Class