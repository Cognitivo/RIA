Imports System.Data.SqlClient
Imports System.IO
Imports Osuna.Utiles.Conectividad

Public Class ContaPlantillas

#Region "Fields"
    Private myTrans As SqlTransaction
    Private cmd As SqlCommand
    Private ser As BDConexión.BDConexion
    Private sqlc As SqlConnection
    Dim sql As String
    Dim sel, ins, upd, del, pri, anu As Integer
    Dim dr As SqlDataReader
    Dim IsNuevo As Integer
    Dim f As New Funciones.Funciones
    Dim ReglaFinanciera, ReglaMercaderias, AsientoCosto, AsientoGenerar, AsientoAplicar, DevolMerc, DevolDinero As Integer
    Dim permiso As Double
    Dim AccNuevo, AccEditar As Integer
#End Region

#Region "Constructors"
    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub
#End Region

#Region "Methods"

    Private Sub ContaPlantillas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If pbxNuevo.Enabled = True Then
                pbxNuevo_Click(Nothing, Nothing)
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

    Private Sub ContaPlantillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 195)
        Try
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        IsNuevo = 0

        Me.REGLACONTABLETableAdapter.Fill(Me.DsPlantillasConta.REGLACONTABLE)
        Me.MODULOTableAdapter.Fill(Me.DsPlantillasConta.MODULO)
        Me.PLANTILLATableAdapter.Fill(Me.DsPlantillasConta.PLANTILLA)

        dgvPlantilla.Sort(dgvPlantilla.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        DesHabilitar()
        RecorreDetalle()
        cbxTipoRegla.Text = ""
            AccNuevo = 0 : AccEditar = 0
        Catch ex As Exception

        End Try
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
        "VALUES ( " & CODIGO & ", " & EmpCodigo & "," & "'PLANTILLA CONTABLE', '" & tbxCodPlantilla.Text & "', " & "'" & Accion & " EN TABLA DE PLANTILLA CONTABLE' , " & _
        "CONVERT(DATETIME,  getdate()), " & "'" & UsuDescripcion & "'," & Insertar & "," & Modificar & ", " & Eliminar & " )"

        cmd.CommandText = consulta
        cmd.ExecuteNonQuery()

        myTrans.Commit()

    End Sub

    Private Sub Habilitar()
        'Cosas que Deshabilitar antes de Habilitar
        pbxNuevo.Image = My.Resources.NewOff
        pbxNuevo.Cursor = Cursors.Arrow
        pbxNuevo.Enabled = False
        pbxEditar.Image = My.Resources.EditOff
        pbxEditar.Cursor = Cursors.Arrow
        pbxEditar.Enabled = False
        pbxEliminar.Image = My.Resources.DeleteOff
        pbxEliminar.Cursor = Cursors.Arrow
        pbxEliminar.Enabled = False
        dgvPlantilla.Enabled = False
        BuscarTextBox.Enabled = False

        dgvPlantillaDetalle.Enabled = True
        'Cosas que Habilitar
        pbxGuardar.Image = My.Resources.Save
        pbxGuardar.Cursor = Cursors.Hand
        pbxGuardar.Enabled = True
        pbxCancelar.Image = My.Resources.SaveCancel
        pbxCancelar.Cursor = Cursors.Hand

        pbxCancelar.Enabled = True
        tbxDescripcion.Enabled = True
        cbxModulo.Enabled = True
        cbxContado.Enabled = True
        cbxCredito.Enabled = True
        cbxSimplificado.Enabled = True
        cbxAvanzado.Enabled = True
        cbxNoAplicableF.Enabled = True
        cbxNoAplicableM.Enabled = True
        tbxNroCuenta.Enabled = True
        cbxDebeHaber.Enabled = True
        cbxTipoRegla.Enabled = True
        btnAgregar.Enabled = True
        btnEliminar.Enabled = True
        rbNoDevDinero.Enabled = True
        rbNoDevMerc.Enabled = True
        rbSiDevDinero.Enabled = True
        rbSiDevMerc.Enabled = True
        chbAsientoCosto.Enabled = True
        chkAplicarAnti.Enabled = True
        chkGenerarAnti.Enabled = True
        chxConSaldo.Enabled = True
    End Sub

    Private Sub DesHabilitar()
        'Cosas que Habilitar antes de Deshabilitar
        pbxNuevo.Image = My.Resources.New_
        pbxNuevo.Cursor = Cursors.Hand
        pbxNuevo.Enabled = True
        pbxEditar.Image = My.Resources.Edit
        pbxEditar.Cursor = Cursors.Hand
        pbxEditar.Enabled = True
        pbxEliminar.Image = My.Resources.Delete
        pbxEliminar.Cursor = Cursors.Hand
        pbxEliminar.Enabled = True
        dgvPlantilla.Enabled = True
        BuscarTextBox.Enabled = True

        dgvPlantillaDetalle.Enabled = False
        'Cosas que DesHabilitar
        pbxGuardar.Image = My.Resources.SaveOff
        pbxGuardar.Cursor = Cursors.Arrow
        pbxGuardar.Enabled = False
        pbxCancelar.Image = My.Resources.SaveCancelOff
        pbxCancelar.Cursor = Cursors.Arrow

        pbxCancelar.Enabled = False
        tbxDescripcion.Enabled = False
        cbxModulo.Enabled = False
        cbxContado.Enabled = False
        cbxCredito.Enabled = False
        cbxSimplificado.Enabled = False
        cbxAvanzado.Enabled = False
        cbxNoAplicableF.Enabled = False
        cbxNoAplicableM.Enabled = False
        tbxNroCuenta.Enabled = False
        cbxDebeHaber.Enabled = False
        cbxTipoRegla.Enabled = False
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        rbNoDevDinero.Enabled = False
        rbNoDevMerc.Enabled = False
        rbSiDevDinero.Enabled = False
        rbSiDevMerc.Enabled = False
        chbAsientoCosto.Enabled = False
        chkAplicarAnti.Enabled = False
        chkGenerarAnti.Enabled = False
        chxConSaldo.Enabled = False
    End Sub

    Private Sub pbxNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxNuevo.Click
        Dim conexion As System.Data.SqlClient.SqlConnection

        IsNuevo = 1
        pnlCreditoSaldo.Visible = False : pnlDevDinero.Visible = False : pnlDevMerc.SendToBack()

        Me.PLANTILLABindingSource1.AddNew()

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

        cbxContado.Checked = False
        cbxCredito.Checked = False
        cbxSimplificado.Checked = False
        cbxAvanzado.Checked = False
        AccNuevo = 1 : AccEditar = 0
        Me.PLANTILLADETALLETableAdapter.Fill(DsPlantillasConta.PLANTILLADETALLE, 0)

        Habilitar()
        tbxDescripcion.Focus()
    End Sub

    Private Sub InsertarPlantillaNueva(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim consulta As System.String
        Dim Ultimo As Integer

        Ultimo = f.Maximo("PlantillaID", "PLANTILLA")
        tbxCodPlantilla.Text = Ultimo + 1

        consulta = "INSERT INTO PLANTILLA (PlantillaID) VALUES (" & CDec(tbxCodPlantilla.Text) & ")"

        Consultas.ConsultaComando(myTrans, consulta)
    End Sub

    Private Sub RecorreDetalle()
        Dim IDPlanilla As Integer

        If (dgvPlantilla.RowCount <> 0) Then
            If IsDBNull(dgvPlantilla.CurrentRow.Cells("PlantillaID").Value) Then
                IDPlanilla = 0
            Else
                IDPlanilla = dgvPlantilla.CurrentRow.Cells("PlantillaID").Value
            End If
            Me.PLANTILLADETALLETableAdapter.Fill(DsPlantillasConta.PLANTILLADETALLE, IDPlanilla)
        Else
            Me.PLANTILLADETALLETableAdapter.Fill(DsPlantillasConta.PLANTILLADETALLE, 0)
        End If
    End Sub

    Private Sub dgvPlantilla_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPlantilla.SelectionChanged
        If IsNuevo = 0 Then

            If dgvPlantilla.RowCount <> 0 Then

                If dgvPlantilla.CurrentRow.Cells("ReglaMonetaria").Value = 1 Then
                    cbxContado.Checked = True
                ElseIf dgvPlantilla.CurrentRow.Cells("ReglaMonetaria").Value = 2 Then
                    cbxCredito.Checked = True
                    chxConSaldo.Checked = False
                ElseIf dgvPlantilla.CurrentRow.Cells("ReglaMonetaria").Value = 4 Then
                    cbxCredito.Checked = True
                    chxConSaldo.Checked = True
                ElseIf dgvPlantilla.CurrentRow.Cells("ReglaMonetaria").Value = 3 Then
                    cbxNoAplicableF.Checked = True
                End If
                If dgvPlantilla.CurrentRow.Cells("ReglaMercaderia").Value = 1 Then
                    cbxSimplificado.Checked = True
                ElseIf dgvPlantilla.CurrentRow.Cells("ReglaMercaderia").Value = 2 Then
                    cbxAvanzado.Checked = True
                ElseIf dgvPlantilla.CurrentRow.Cells("ReglaMercaderia").Value = 3 Then
                    cbxNoAplicableM.Checked = True
                End If

                If IsDBNull(dgvPlantilla.CurrentRow.Cells("AsientoCostoDataGridViewCheckBoxColumn").Value) Then
                    chbAsientoCosto.Checked = False
                    chkAplicarAnti.Enabled = False
                    chkGenerarAnti.Enabled = False
                Else
                    If dgvPlantilla.CurrentRow.Cells("AsientoCostoDataGridViewCheckBoxColumn").Value = True Then
                        chbAsientoCosto.Checked = True
                        chkAplicarAnti.Enabled = True
                        chkGenerarAnti.Enabled = True
                    Else
                        chbAsientoCosto.Checked = False
                        chkAplicarAnti.Enabled = False
                        chkGenerarAnti.Enabled = False
                    End If
                End If
                If IsDBNull(dgvPlantilla.CurrentRow.Cells("DevDinero").Value) Then
                    rbSiDevDinero.Checked = False
                    rbNoDevDinero.Checked = False
                Else
                    If dgvPlantilla.CurrentRow.Cells("DevDinero").Value = True Then
                        rbSiDevDinero.Checked = True
                        rbNoDevDinero.Checked = False
                    Else
                        rbSiDevDinero.Checked = False
                        rbNoDevDinero.Checked = True
                    End If
                End If

                If IsDBNull(dgvPlantilla.CurrentRow.Cells("DevMerc").Value) Then
                    rbSiDevMerc.Checked = False
                    rbNoDevMerc.Checked = False
                Else
                    If dgvPlantilla.CurrentRow.Cells("DevMerc").Value = True Then
                        rbSiDevMerc.Checked = True
                        rbNoDevMerc.Checked = False
                    Else
                        rbSiDevMerc.Checked = False
                        rbNoDevMerc.Checked = True
                    End If
                End If

                If IsDBNull(dgvPlantilla.CurrentRow.Cells("AsientoCostoDataGridViewCheckBoxColumn").Value) Then
                    chbAsientoCosto.Checked = False
                ElseIf dgvPlantilla.CurrentRow.Cells("AsientoCostoDataGridViewCheckBoxColumn").Value = True Then
                    chbAsientoCosto.Checked = True
                Else
                    chbAsientoCosto.Checked = False
                End If

                If IsDBNull(dgvPlantilla.CurrentRow.Cells("AplicarAnti").Value) Then
                    chkAplicarAnti.Checked = False
                ElseIf dgvPlantilla.CurrentRow.Cells("AplicarAnti").Value = True Then
                    chkAplicarAnti.Checked = True
                Else
                    chkAplicarAnti.Checked = False
                End If

                If IsDBNull(dgvPlantilla.CurrentRow.Cells("GenerarAnti").Value) Then
                    chkGenerarAnti.Checked = False
                ElseIf dgvPlantilla.CurrentRow.Cells("GenerarAnti").Value = True Then
                    chkGenerarAnti.Checked = True
                Else
                    chkGenerarAnti.Checked = False
                End If

                RecorreDetalle()
            End If
        End If
    End Sub

    Private Sub tbxDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxDescripcion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxModulo.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxContado.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxCredito.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxCredito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxSimplificado.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxModulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxModulo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxContado.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxAvanzado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxAvanzado.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxNroCuenta.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxSimplificado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxSimplificado.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxAvanzado.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxVerTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxVerTodos.CheckedChanged
        If cbxVerTodos.Checked = True Then
            Me.PlancuentasTableAdapter.FillByTodos(Me.DsPlantillasConta.plancuentas)
        Else
            Dim TipoReglas As Integer
            If cbxTipoRegla.SelectedValue = 10 Or cbxTipoRegla.SelectedValue = 0 Then
                TipoReglas = 5
            Else
                TipoReglas = cbxTipoRegla.SelectedValue
            End If

            Me.PlancuentasTableAdapter.Fill(Me.DsPlantillasConta.plancuentas, TipoReglas)
        End If
    End Sub

    Private Sub tbxNroCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroCuenta.KeyPress, tbxCodCuenta.KeyPress, tbxCodPlantilla.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxDebeHaber.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 42 Then
            Dim TipoReglas As Integer
            If cbxTipoRegla.SelectedValue = 10 Or cbxTipoRegla.SelectedValue = 0 Then
                TipoReglas = 5
            Else
                TipoReglas = cbxTipoRegla.SelectedValue
            End If

            Me.PlancuentasTableAdapter.Fill(Me.DsPlantillasConta.plancuentas, TipoReglas)

            UltraPopupControlContainer1.Show()
            tbxBuscarCuenta.Text = ""
            tbxBuscarCuenta.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub cbxTipoRegla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoRegla.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxNroCuenta.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub dgbPlanCuentas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbPlanCuentas.CellDoubleClick
        If dgbPlanCuentas.RowCount <> 0 Then
            tbxCodCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("CODPLANCUENTA").Value
            tbxNroCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("NUMPLANCUENTA").Value
            tbxCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("DESPLANCUENTA").Value
            cbxDebeHaber.Focus()
            UltraPopupControlContainer1.Close()
        End If
    End Sub

    Private Sub cbxDebeHaber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxDebeHaber.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregar.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxBuscarCuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxBuscarCuenta.GotFocus
        If tbxBuscarCuenta.Text = "Buscar..." Then
            tbxBuscarCuenta.Text = ""
        End If
    End Sub

    Private Sub tbxBuscarCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxBuscarCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgbPlanCuentas.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxBuscarCuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxBuscarCuenta.LostFocus
        If tbxBuscarCuenta.Text = "" Then
            tbxBuscarCuenta.Text = "Buscar..."
        End If
    End Sub

    Private Sub tbxBuscarCuenta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxBuscarCuenta.TextChanged
        If tbxBuscarCuenta.Text <> "Buscar..." Then
            Me.PlancuentasBindingSource.Filter = "DESPLANCUENTA LIKE '%" & tbxBuscarCuenta.Text & "%' OR NUMPLANCUENTA LIKE '%" & tbxBuscarCuenta.Text & "%' "
        End If
    End Sub

    Private Sub dgbPlanCuentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgbPlanCuentas.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If dgbPlanCuentas.RowCount <> 0 Then
                Dim Pos As Integer = dgbPlanCuentas.CurrentRow.Index

                tbxCodCuenta.Text = dgbPlanCuentas.Rows(Pos - 1).Cells("CODPLANCUENTA").Value
                tbxNroCuenta.Text = dgbPlanCuentas.Rows(Pos - 1).Cells("NUMPLANCUENTA").Value
                tbxCuenta.Text = dgbPlanCuentas.Rows(Pos - 1).Cells("DESPLANCUENTA").Value
                cbxDebeHaber.Focus()
                UltraPopupControlContainer1.Close()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub pbxCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCancelar.Click
        '**************************************************************************************************************************************************
        Dim VarIsNull As String

        VarIsNull = f.FuncionConsultaString("ModuloID", "PLANTILLA", "PlantillaID", tbxCodPlantilla.Text)

        If VarIsNull = "" Or VarIsNull = Nothing Then
            Dim consulta As System.String
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            conexion = ser.Abrir()

            Try
                consulta = ""
                consulta = consulta + "DELETE FROM PLANTILLA WHERE PlantillaID=" & tbxCodPlantilla.Text & " "

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
            Catch ex As SqlException

            End Try

        End If

        '**************************************************************************************************************************************************

        Try
            Me.PlancuentasBindingSource.CancelEdit()
            Me.PlancuentasBindingSource.RemoveFilter()

            IsNuevo = 0

            cbxContado.Checked = False : cbxCredito.Checked = False : cbxSimplificado.Checked = False : cbxAvanzado.Checked = False
            tbxCuenta.Text = "" : tbxNroCuenta.Text = "" : cbxDebeHaber.Text = "" : tbxDescripcion.Text = "" : cbxModulo.Text = ""
            cbxTipoRegla.Text = ""

            Me.PLANTILLATableAdapter.Fill(Me.DsPlantillasConta.PLANTILLA)
            RecorreDetalle()
            DesHabilitar()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim Ultimo As Integer

        '1 - Controlamos que se hallan cargado todos los datos necesarios.
        If cbxModulo.SelectedValue = 8 Then
            If cbxTipoRegla.SelectedValue <> 1 And cbxTipoRegla.SelectedValue <> 3 And cbxTipoRegla.SelectedValue <> 8 Then
                If tbxNroCuenta.Text = "" Or tbxCuenta.Text = "" Then
                    MessageBox.Show("Introduzca un Plan de Cuentas", "POSEXPRESS")
                    tbxNroCuenta.Focus()
                    Exit Sub
                End If
            End If
        Else
            If cbxTipoRegla.SelectedValue <> 1 And cbxTipoRegla.SelectedValue <> 3 And cbxTipoRegla.SelectedValue <> 11 And cbxTipoRegla.SelectedValue <> 8 Then
                If tbxNroCuenta.Text = "" Or tbxCuenta.Text = "" Then
                    MessageBox.Show("Introduzca un Plan de Cuentas", "POSEXPRESS")
                    tbxNroCuenta.Focus()
                    Exit Sub
                End If
            End If
        End If

        If cbxDebeHaber.Text = "" Then
            MessageBox.Show("Indique si es Debe/Haber", "POSEXPRESS")
            cbxDebeHaber.Focus()
            Exit Sub
        End If

        If cbxTipoRegla.Text = "" Then
            MessageBox.Show("Indique el Tipo de Regla", "POSEXPRESS")
            cbxTipoRegla.Focus()
            Exit Sub
        End If

        '2 - Validamos que no se repita el Plan de Cuentas
        Dim count As Integer = dgvPlantillaDetalle.RowCount
        For i = 1 To count
            Try
                If IsDBNull(dgvPlantillaDetalle.Rows(i - 1).Cells("CuentaID").Value) Then
                Else
                    If tbxNroCuenta.Text = dgvPlantillaDetalle.Rows(i - 1).Cells("CuentaID").Value Then
                        MessageBox.Show("Ya se ingresó la cuenta!!", "POSEXPRESS")
                        tbxNroCuenta.Focus()
                        Exit Sub
                    End If
                End If
            Catch ex As Exception

            End Try
        Next

        Dim CantReg As Integer = dgvPlantillaDetalle.RowCount
        If CantReg = 0 Then
            Ultimo = f.Maximo("PlantillaDetID", "PLANTILLADETALLE")
            Ultimo = Ultimo + 1
        Else
            Ultimo = dgvPlantillaDetalle.Rows(CantReg - 1).Cells("PlantillaDetIDGrillaDet").Value + 1
        End If

        '3 - Insertamos en la grilla
        Me.PLANTILLADETALLEBindingSource.AddNew()
        CantReg = dgvPlantillaDetalle.RowCount

        ''If tbxCuenta.Text = "Este Dato se cargara en el momento de realizar el asiento" Then
        ''    tbxCodCuenta.Text = 0
        ''End If

        dgvPlantillaDetalle.Rows(CantReg - 1).Cells("PlantillaDetIDGrillaDet").Value = Ultimo
        dgvPlantillaDetalle.Rows(CantReg - 1).Cells("PlantillaIDGrillaDet").Value = tbxCodPlantilla.Text
        dgvPlantillaDetalle.Rows(CantReg - 1).Cells("CuentaID").Value = tbxCodCuenta.Text
        dgvPlantillaDetalle.Rows(CantReg - 1).Cells("NUMPLANCUENTAGrillaDet").Value = tbxNroCuenta.Text
        dgvPlantillaDetalle.Rows(CantReg - 1).Cells("DESPLANCUENTAGrillaDet").Value = tbxCuenta.Text
        dgvPlantillaDetalle.Rows(CantReg - 1).Cells("DescriTipoRegla").Value = cbxTipoRegla.Text
        dgvPlantillaDetalle.Rows(CantReg - 1).Cells("TipoRegla").Value = cbxTipoRegla.SelectedValue

        If cbxDebeHaber.Text = "Debe" Then
            dgvPlantillaDetalle.Rows(CantReg - 1).Cells("Debe").Value = "SI"
            dgvPlantillaDetalle.Rows(CantReg - 1).Cells("Haber").Value = "NO"

        ElseIf cbxDebeHaber.Text = "Haber" Then
            dgvPlantillaDetalle.Rows(CantReg - 1).Cells("Haber").Value = "SI"
            dgvPlantillaDetalle.Rows(CantReg - 1).Cells("Debe").Value = "NO"

        End If

        tbxNroCuenta.Enabled = True
        tbxCuenta.Text = "" : tbxNroCuenta.Text = "" : cbxDebeHaber.Text = "" : cbxTipoRegla.Text = ""
        cbxTipoRegla.Focus()
    End Sub

    Private Sub pbxEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEditar.Click
        Habilitar()
        tbxDescripcion.Focus()
        AccNuevo = 0 : AccEditar = 1
        tbxCodPlantilla.Text = dgvPlantilla.CurrentRow.Cells("PlantillaID").Value
    End Sub

    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxGuardar.Click
        Dim Existe, Ultimo, PlantillaDetID As Integer

        'Verificamos
        If tbxDescripcion.Text = "" Then
            MessageBox.Show("Ingrese una Descripción para la Plantilla", "POSEXPRESS")
            tbxDescripcion.Focus()
            Exit Sub
        End If

        If cbxModulo.Text = "" Then
            MessageBox.Show("Indique un Modulo para la Plantilla", "POSEXPRESS")
            cbxModulo.Focus()
            Exit Sub
        End If

        If cbxModulo.Text = "" Then
            MessageBox.Show("Indique un Modulo para la Plantilla", "POSEXPRESS")
            cbxModulo.Focus()
            Exit Sub
        End If

        If dgvPlantillaDetalle.RowCount = 0 Then
            MessageBox.Show("No se puede insertar una Planilla sin Detalle", "POSEXPRESS")
            cbxTipoRegla.Focus()
            Exit Sub
        End If

        If cbxContado.Checked = True Then
            ReglaFinanciera = 1
        ElseIf cbxCredito.Checked = True Then
            If cbxModulo.SelectedValue = 11 Then 'DEVOLUCIONES
                If chxConSaldo.Checked = True Then
                    ReglaFinanciera = 4
                Else
                    ReglaFinanciera = 2
                End If
            Else
                ReglaFinanciera = 2
            End If
        ElseIf cbxNoAplicableF.Checked = True Then
            ReglaFinanciera = 3
        Else
            MessageBox.Show("Seleccion una Regla Financiera", "POSEXPRESS")
            Exit Sub
        End If

        If cbxSimplificado.Checked = True Then
            ReglaMercaderias = 1
        ElseIf cbxAvanzado.Checked = True Then
            ReglaMercaderias = 2
        ElseIf cbxNoAplicableM.Checked = True Then
            ReglaMercaderias = 3
        Else
            MessageBox.Show("Seleccion una Regla para Mercaderia", "POSEXPRESS")
            Exit Sub
        End If

        If chbAsientoCosto.Checked = True Then
            AsientoCosto = 1
        Else
            AsientoCosto = 0
        End If
        '################################## by Saul
        If chkAplicarAnti.Checked = True Then
            AsientoAplicar = 1
        Else
            AsientoAplicar = 0
        End If

        If chkGenerarAnti.Checked = True Then
            AsientoGenerar = 1
        Else
            AsientoGenerar = 0
        End If
        '#################################
        If rbNoDevDinero.Checked = True Then
            DevolDinero = 0
        ElseIf rbSiDevDinero.Checked = True Then
            DevolDinero = 1
        Else
            If cbxModulo.SelectedValue = 11 Then
                MessageBox.Show("Seleccion una Regla para Devolucion de Dinero", "POSEXPRESS")
                Exit Sub
            Else
                DevolDinero = 0
            End If
        End If

        If rbNoDevMerc.Checked = True Then
            DevolMerc = 0
        ElseIf rbSiDevMerc.Checked = True Then
            DevolMerc = 1
        Else
            If cbxModulo.SelectedValue = 11 Then
                MessageBox.Show("Seleccion una Regla para Devolucion de Mercaderia", "POSEXPRESS")
                Exit Sub
            Else
                DevolMerc = 0
            End If
        End If

        'Guardamos en la base de datos
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            ActualizarCabecera()
            myTrans.Commit()

            Ultimo = f.Maximo("PlantillaDetID", "PLANTILLADETALLE")

            For k = 0 To dgvPlantillaDetalle.RowCount - 1
                PlantillaDetID = dgvPlantillaDetalle.Rows(k).Cells("PlantillaDetIDGrillaDet").Value
                Existe = f.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaID = " & tbxCodPlantilla.Text & " AND PlantillaDetID ", PlantillaDetID)

                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                cmd.Connection = sqlc
                cmd.Transaction = myTrans

                If Existe = 0 Then ' Nuevo
                    Try
                        Ultimo = Ultimo + 1
                        InsertarDetalle(k, Ultimo)
                        myTrans.Commit()
                    Catch ex As Exception
                    End Try

                Else    'Editar
                    Try
                        ActualizarDetalle(k)
                        myTrans.Commit()
                    Catch ex As Exception
                    End Try
                End If
            Next

            MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

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
            MessageBox.Show("Ocurrio un error al intentar insertar ", "POSEXPRESS")
            Me.pbxCancelar.PerformLayout()

        Finally
            sqlc.Close()

        End Try

        Me.PLANTILLATableAdapter.Fill(Me.DsPlantillasConta.PLANTILLA)
        RecorreDetalle()
        DesHabilitar()
        IsNuevo = 0
    End Sub

    Private Sub ActualizarCabecera()
        sql = ""
        sql = "UPDATE PLANTILLA SET " & _
              "Descripcion ='" & tbxDescripcion.Text & "', " & _
              "UsuarioID = " & UsuCodigo & " , " & _
              "ModuloID = " & cbxModulo.SelectedValue & ", " & _
              "ReglaMercaderia = " & ReglaMercaderias & ", " & _
              "ReglaMonetaria = " & ReglaFinanciera & " ,   " & _
              "AsientoCosto = " & AsientoCosto & ", " & _
              "DevMerc = " & DevolMerc & " ,   " & _
              "DevDinero = " & DevolDinero & " ,   " & _
              "GenerarAnti = " & AsientoGenerar & " ,   " & _
              "AplicarAnti = " & AsientoAplicar & "    " & _
              "WHERE PlantillaID = " & tbxCodPlantilla.Text

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertarDetalle(ByVal I As Integer, ByVal Ultimo As Integer)
        Dim PlantillaID, CuentaID, TipoRegla As Integer
        Dim Debe, Haber, DescriTipoRegla As String

        Debe = "" : Haber = "" : DescriTipoRegla = ""

        If IsDBNull(dgvPlantillaDetalle.Rows(I).Cells("PlantillaIDGrillaDet").Value) Then
        Else
            PlantillaID = dgvPlantillaDetalle.Rows(I).Cells("PlantillaIDGrillaDet").Value
        End If

        If IsDBNull(dgvPlantillaDetalle.Rows(I).Cells("CuentaID").Value) Then
        Else
            CuentaID = dgvPlantillaDetalle.Rows(I).Cells("CuentaID").Value
        End If

        If IsDBNull(dgvPlantillaDetalle.Rows(I).Cells("TipoRegla").Value) Then
        Else
            TipoRegla = dgvPlantillaDetalle.Rows(I).Cells("TipoRegla").Value
        End If

        If IsDBNull(dgvPlantillaDetalle.Rows(I).Cells("Debe").Value) Then
        Else
            Debe = dgvPlantillaDetalle.Rows(I).Cells("Debe").Value
        End If

        If IsDBNull(dgvPlantillaDetalle.Rows(I).Cells("Haber").Value) Then
        Else
            Haber = dgvPlantillaDetalle.Rows(I).Cells("Haber").Value
        End If

        sql = ""
        sql = "INSERT PLANTILLADETALLE (PlantillaDetID,PlantillaID,CuentaID,TipoRegla,Debe,Haber) " & _
              "VALUES (" & Ultimo & "," & PlantillaID & "," & CuentaID & "," & TipoRegla & ",'" & Debe & "','" & Haber & "')"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizarDetalle(ByVal i As Integer)
        Dim PlantillaDetID, CuentaID, TipoRegla As Integer
        Dim Debe, Haber, DescriTipoRegla As String

        Debe = "" : Haber = "" : DescriTipoRegla = ""

        If IsDBNull(dgvPlantillaDetalle.Rows(i).Cells("PlantillaDetIDGrillaDet").Value) Then
        Else
            PlantillaDetID = dgvPlantillaDetalle.Rows(i).Cells("PlantillaDetIDGrillaDet").Value
        End If

        If IsDBNull(dgvPlantillaDetalle.Rows(i).Cells("CuentaID").Value) Then
        Else
            CuentaID = dgvPlantillaDetalle.Rows(i).Cells("CuentaID").Value
        End If

        If IsDBNull(dgvPlantillaDetalle.Rows(i).Cells("TipoRegla").Value) Then
        Else
            TipoRegla = dgvPlantillaDetalle.Rows(i).Cells("TipoRegla").Value
        End If

        If IsDBNull(dgvPlantillaDetalle.Rows(i).Cells("Debe").Value) Then
        Else
            Debe = dgvPlantillaDetalle.Rows(i).Cells("Debe").Value
        End If

        If IsDBNull(dgvPlantillaDetalle.Rows(i).Cells("Haber").Value) Then
        Else
            Haber = dgvPlantillaDetalle.Rows(i).Cells("Haber").Value
        End If

        sql = ""
        sql = "UPDATE PLANTILLADETALLE SET CuentaID = " & CuentaID & ", TipoRegla = " & TipoRegla & ", Debe = '" & Debe & "', Haber = '" & Haber & "'   " & _
              "WHERE PlantillaDetID = " & PlantillaDetID

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub cbxTipoRegla_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxTipoRegla.LostFocus
        If cbxModulo.SelectedValue <> 8 And cbxModulo.SelectedValue <> 11 Then 'En ventas por el momento dejaremos que si elija la cuenta especifica xq no se maneja por centro de costo
            If cbxTipoRegla.SelectedValue = 1 Or cbxTipoRegla.SelectedValue = 3 Or cbxTipoRegla.SelectedValue = 11 Or cbxTipoRegla.SelectedValue = 8 Then
                tbxNroCuenta.Enabled = False
                Me.tbxCodCuenta.Text = 0
                cbxDebeHaber.Focus()
                tbxCuenta.Text = "Este Dato se cargara en el momento de realizar el asiento"
            Else
                tbxNroCuenta.Enabled = True
                tbxCuenta.Text = ""
            End If
        Else
            If cbxTipoRegla.SelectedValue = 1 Or cbxTipoRegla.SelectedValue = 3 Or cbxTipoRegla.SelectedValue = 8 Then
                tbxNroCuenta.Enabled = False
                Me.tbxCodCuenta.Text = 0
                cbxDebeHaber.Focus()
                tbxCuenta.Text = "Este Dato se cargara en el momento de realizar el asiento"
            Else
                tbxNroCuenta.Enabled = True
                tbxCuenta.Text = ""
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim Existe, PlantillaDetID, PlantillaID As Integer

        PlantillaDetID = dgvPlantillaDetalle.CurrentRow.Cells("PlantillaDetIDGrillaDet").Value
        PlantillaID = dgvPlantillaDetalle.CurrentRow.Cells("PlantillaIDGrillaDet").Value

        'Preguntamos si existe en la base de datos
        Existe = f.FuncionConsultaDecimal("PlantillaDetID", "PLANTILLADETALLE", "PlantillaDetID = " & PlantillaDetID & " AND PlantillaID", PlantillaID)

        If Existe <> 0 Then
            Try
                ser.Abrir(sqlc)
                cmd.Connection = sqlc
                sql = ""
                sql = "DELETE PLANTILLADETALLE WHERE PlantillaDetID = " & PlantillaDetID & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                sqlc.Close()

            Catch ex As SqlException
                MessageBox.Show("Ocurrió un error al tratar de Eliminar ", "POSEXPRESS")
                Exit Sub
            End Try

            ' RecorreDetalle()
        End If

        dgvPlantillaDetalle.Rows.Remove(Me.dgvPlantillaDetalle.CurrentRow)

    End Sub

    Private Sub pbxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEliminar.Click
        Dim Existe As Integer

        If dgvPlantilla.RowCount <> 0 Then
            If MessageBox.Show("¿Esta seguro que quiere eliminar la Plantilla?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            Existe = f.FuncionConsultaDecimal("PlantillaID", "PLANTILLA", "PlantillaID", dgvPlantilla.CurrentRow.Cells("PlantillaID").Value)

            If Existe <> 0 Then
                Try
                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc

                    'Eliminamos Detalle y encabezado
                    sql = ""
                    sql = "DELETE PLANTILLADETALLE WHERE PlantillaID = " & dgvPlantilla.CurrentRow.Cells("PlantillaID").Value & "  "
                    sql = sql + "DELETE PLANTILLA WHERE PlantillaID = " & dgvPlantilla.CurrentRow.Cells("PlantillaID").Value & ""

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    sqlc.Close()

                Catch ex As SqlException
                    MessageBox.Show("Ocurrió un error al tratar de Eliminar ", "POSEXPRESS")
                    Exit Sub
                End Try
            End If

            Me.PLANTILLATableAdapter.Fill(Me.DsPlantillasConta.PLANTILLA)
            RecorreDetalle()

            'INSERTAMOS EN AUDITORIA 
            InsertaAuditoria(0, 0, 1)
            '#########################
        End If
    End Sub

    Private Sub pbxAgregarCiudad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarCiudad.Click
        PlanCuentaV2.ShowDialog()
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
            Me.PLANTILLABindingSource1.Filter = "Descripcion LIKE '%" & BuscarTextBox.Text & "%' OR MODULO LIKE '%" & BuscarTextBox.Text & "%' "
        End If
    End Sub


    Private Sub cbxModulo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbxModulo.SelectedValueChanged
        If cbxModulo.SelectedValue = 11 Then 'DEVOLUCIONES
            pnlDevMerc.Visible = True
            pnlReglaMercNormal.Visible = False
            cbxSimplificado.Checked = True
        Else
            pnlDevMerc.Visible = False
            pnlReglaMercNormal.Visible = True
        End If
    End Sub

    Private Sub cbxCredito_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxCredito.CheckedChanged
        If cbxModulo.SelectedValue = 11 Then 'DEVOLUCIONES
            If cbxCredito.Checked = True Then
                pnlCreditoSaldo.Visible = True
            ElseIf cbxCredito.Checked = False Then
                pnlCreditoSaldo.Visible = False
            End If
        End If
    End Sub
#End Region
    Private Sub rbSiDevMerc_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbSiDevMerc.CheckedChanged
        If cbxModulo.SelectedValue = 11 Then 'DEVOLUCIONES
            If rbSiDevMerc.Checked = True Then
                pnlDevDinero.Visible = True
            ElseIf rbSiDevMerc.Checked = False Then
                pnlDevDinero.Visible = False
            End If
        End If
    End Sub
End Class