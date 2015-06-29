Imports System.Data.SqlClient
Imports System.IO
Imports Osuna.Utiles.Conectividad
Imports System.DateTime
Imports System.Globalization

Public Class Asientos
#Region "Fields"
    Dim f As New Funciones.Funciones
    Dim FechaFiltro1, FechaFiltro2 As Date

    '------ Coneccion para BD -----------
    Private myTrans As SqlTransaction
    Private cmd As SqlCommand
    Private ser As BDConexión.BDConexion
    Private sqlc As SqlConnection
    Dim sql As String
    Dim permiso As Double
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
    Private Sub tbxBuscador_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxBuscador.TextChanged
        Try
            Dim CodPeriodoFiscal As Integer = cbxPeriodoFiscal.SelectedValue
            If tbxBuscador.Text <> "" Then
                If Not System.Text.RegularExpressions.Regex.IsMatch(tbxBuscador.Text, "^\d*$") Then ' Si introduce letras
                    Me.AsientosBindingSource.Filter = "DESCRIPCION LIKE '%" & tbxBuscador.Text & "%' OR DETALLE LIKE '%" & tbxBuscador.Text & "%'"
                Else
                    Me.AsientosBindingSource.Filter = "NUMASIENTO = " & tbxBuscador.Text
                    If dgvAsiento.RowCount = 0 Then
                        Me.AsientosBindingSource.Filter = "DESCRIPCION LIKE '%" & tbxBuscador.Text & "%' OR DETALLE LIKE '%" & tbxBuscador.Text & "%'"
                    End If
                End If
            Else
                Me.AsientosBindingSource.Filter = "DESCRIPCION LIKE '%" & tbxBuscador.Text & "%' OR DETALLE LIKE '%" & tbxBuscador.Text & "%'"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Asientos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If NuevoPictureBox.Enabled = True Then
                NuevoPictureBox_Click(Nothing, Nothing)
            End If

        End If

        If e.KeyCode = Keys.F6 Then
            If ModificarPictureBox.Enabled = True Then
                ModificarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F7 Then
            If GuardarPictureBox.Enabled = True Then
                GuardarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F8 Then
            If CancelarPictureBox.Enabled = True Then
                CancelarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F9 Then
            'Navegar entre los paneles
            If pnlBuscarAsiento.Enabled = False Then
                pbxBuscar_Click(Nothing, Nothing)
            Else
                pbxAsientos_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Public Sub Asientos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 197)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        Me.PeriodofiscalTableAdapter.Fill(Me.DsPeriodoFiscal.periodofiscal, "%")
        cbxPeriodoFiscal.Text = f.FuncionConsultaString("DESEJERCICIO", "periodofiscal", "ESTADO", 1)

        cmbAnho.SelectedText = Today.Year.ToString
        cmbMes.SelectedIndex = Today.Month - 1
        FechaFiltro()
        Dim auxperiodofiscal As Integer = CInt(cbxPeriodoFiscal.SelectedValue)

        Me.AsientosTableAdapter.FillBy(Me.DsPlantillasConta.Asientos, auxperiodofiscal, FechaFiltro1, FechaFiltro2)

        pnlDetalleAsiento.Enabled = False
        pnlBuscarAsiento.Enabled = False
        pnlDetalleAsiento.BringToFront()

        DesHabilitar()
        RecorreGrilla()
        ArrastrarTotales()



        dtpFechaDesde.CustomFormat = "dd/MM/yyyy"

        Dim Fecha As Date = dtpFechaDesde.Text
        Fecha = CDate(CalculaFechaAnterior(Fecha))
        'Dim fechaconvert As DateTime = DateTime.ParseExact(Fecha, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture)
        dtpFechaDesde.Text = Fecha
        dtpFechaHasta.Text = Today.ToShortDateString
    End Sub

    Private Sub FechaFiltro()
        Try
            Dim nromes, nroaño As Integer
            Dim fechacompleta1, fechacompleta2, mes As String
            nromes = cmbMes.SelectedIndex + 1
            nroaño = CInt(cmbAnho.Text)

            If nromes = 10 Or nromes = 11 Or nromes = 12 Then
                mes = nromes.ToString
            Else
                mes = "0" + nromes.ToString

            End If

            fechacompleta1 = "01" + "/" + nromes.ToString + "/" + cmbAnho.Text
            fechacompleta2 = ""
            If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
                fechacompleta2 = "31" + "/" + nromes.ToString + "/" + cmbAnho.Text

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

            FechaFiltro1 = CDate(fechacompleta1)
            FechaFiltro2 = CDate(fechacompleta2)
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
        "VALUES ( " & CODIGO & ", " & EmpCodigo & "," & "'ASIENTOS', '" & tbxAsientoID.Text & "', " & "'" & Accion & " EN TABLA DE ASIENTOS' , " & _
        "CONVERT(DATETIME,  getdate()), " & "'" & UsuDescripcion & "'," & Insertar & "," & Modificar & ", " & Eliminar & " )"

        cmd.CommandText = consulta
        cmd.ExecuteNonQuery()

        myTrans.Commit()

    End Sub

    Private Sub ObtenerDiff()
        Dim objCommand As New SqlCommand
        Dim Diferencia As Integer

        Try
            objCommand.CommandText = "SELECT NUMASIENTO, SUM(IMPORTED) - SUM(IMPORTEH) AS Diferencia FROM(dbo.ASIENTOS) " & _
                                     "WHERE (CODPERIODOFISCAL = " & cbxPeriodoFiscal.SelectedValue & ") GROUP BY NUMASIENTO ORDER BY NUMASIENTO"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    Diferencia = odrConfig("Diferencia")

                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Function CalculaFechaAnterior(ByVal fecha As Date) As String
        'Dim mes As String
        'mes = (Today.Month - 1).ToString
        'If mes = "0" Then
        '    mes = "12"
        'End If
        'If mes.Length = 1 Then
        '    mes = "0" + mes
        'End If
        'fecha = Today.Day.ToString + "/" + mes + "/" + Today.Year.ToString
        'Return fecha

        Return fecha.AddMonths(-1)

    End Function

    Public Sub RecorreGrilla()
        Dim TotalDebe, TotalHaber As Double

        TotalDebe = 0 : TotalHaber = 0
        For i = 0 To dgvAsiento.RowCount - 1
            TotalDebe = TotalDebe + dgvAsiento.Rows(i).Cells("IMPORTED").Value
            TotalHaber = TotalHaber + dgvAsiento.Rows(i).Cells("IMPORTEH").Value
        Next

        Me.tbxTotakDebe.Text = TotalDebe
        Me.tbxTotalHaber.Text = TotalHaber
    End Sub

    Private Sub Habilitar()
        pnlDetalleAsiento.Enabled = True

        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Image = My.Resources.NewOff
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

        dgvAsiento.Enabled = False
    End Sub

    Private Sub DesHabilitar()
        pnlDetalleAsiento.Enabled = False

        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Cursor = Cursors.Hand
        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Cursor = Cursors.Hand
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        dgvAsiento.Enabled = True
    End Sub

    Private Sub pbxBuscar_Click(sender As System.Object, e As System.EventArgs) Handles pbxBuscar.Click
        pnlBuscarAsiento.BringToFront()
        pnlBuscarAsiento.Enabled = True

        pbxBuscar.Image = My.Resources.SearchBigOff
        pbxBuscar.Cursor = Cursors.Arrow
        pbxAsientos.Image = My.Resources.PaymentBig
        pbxAsientos.Cursor = Cursors.Hand

    End Sub

    Private Sub pbxAsientos_Click(sender As System.Object, e As System.EventArgs) Handles pbxAsientos.Click
        pnlDetalleAsiento.BringToFront()
        pnlBuscarAsiento.Enabled = False

        pbxBuscar.Image = My.Resources.SearchBig
        pbxBuscar.Cursor = Cursors.Hand
        pbxAsientos.Image = My.Resources.PaymentBigOff
        pbxAsientos.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        Dim AsientoId As Integer

        pbxAsientos_Click(Nothing, Nothing)
        pbxBuscar.Enabled = False
        Habilitar()

        AsientoId = f.Maximo("AsientoID", "ASIENTOS")
        Me.tbxAsientoID.Text = AsientoId + 1
        tbxNroCuenta.Focus()
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        LimpiarCampos()
        DesHabilitar()
        RecorreGrilla()
        pbxBuscar.Enabled = True
        Me.AsientosBindingSource.RemoveFilter()
        Me.AsientosTableAdapter.Fill(Me.DsPlantillasConta.Asientos, cbxPeriodoFiscal.SelectedValue)
    End Sub

    Public Sub LimpiarCampos()
        tbxNroCuenta.Text = ""
        tbxNombreCuenta.Text = ""
        tbxComentarios.Text = ""
        tbxDebe.Text = ""
        tbxHaber.Text = ""
        txtAsientoNroManual.Text = ""
    End Sub

    Private Sub tbxBuscarCuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxBuscarCuenta.GotFocus
        If tbxBuscarCuenta.Text = "Buscar..." Then
            tbxBuscarCuenta.Text = ""
        End If
    End Sub

    Private Sub tbxBuscarCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxBuscarCuenta.KeyPress
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

    Private Sub tbxNroCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxNombreCuenta.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 42 Then
            Me.PlancuentasTableAdapter.FillByTodos(Me.DsPlantillasConta.plancuentas)
            UltraPopupControlContainer1.Show()
            tbxBuscarCuenta.Text = ""
            tbxBuscarCuenta.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub tbxNombreCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNombreCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxComentarios.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 42 Then
            Me.PlancuentasTableAdapter.FillByTodos(Me.DsPlantillasConta.plancuentas)
            UltraPopupControlContainer1.Show()
            tbxBuscarCuenta.Text = ""
            tbxBuscarCuenta.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub tbxComentarios_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxComentarios.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxDebe.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxDebe_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxDebe.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxHaber.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub dgbPlanCuentas_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgbPlanCuentas.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If dgbPlanCuentas.RowCount <> 0 Then
                Dim Pos As Integer = dgbPlanCuentas.CurrentRow.Index

                tbxCodCuenta.Text = dgbPlanCuentas.Rows(Pos - 1).Cells("CODPLANCUENTA1").Value
                tbxNroCuenta.Text = dgbPlanCuentas.Rows(Pos - 1).Cells("NUMPLANCUENTA").Value
                tbxNombreCuenta.Text = dgbPlanCuentas.Rows(Pos - 1).Cells("DESPLANCUENTA").Value
                tbxComentarios.Focus()
                UltraPopupControlContainer1.Close()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub dgbPlanCuentas_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbPlanCuentas.CellDoubleClick
        If dgbPlanCuentas.RowCount <> 0 Then
            tbxCodCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("CODPLANCUENTA1").Value
            tbxNroCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("NUMPLANCUENTA").Value
            tbxNombreCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("DESPLANCUENTA").Value
            tbxComentarios.Focus()
            UltraPopupControlContainer1.Close()
        End If
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim Existe, NroAsiento, CodPeriodoActual As Integer
        Dim Debe, Haber As String

        'Verificamos que esten Cargados todos los datos
        If tbxNroCuenta.Text = "" Then
            MessageBox.Show("Ingrese el Nro de la Cuenta", "Pos Express")
            tbxNroCuenta.Focus()
            Exit Sub
        End If

        If tbxNombreCuenta.Text = "" Then
            MessageBox.Show("Ingrese la Cuenta", "Pos Express")
            tbxNombreCuenta.Focus()
            Exit Sub
        End If

        If (tbxDebe.Text = "") And (tbxHaber.Text = "") Then
            MessageBox.Show("Ingrese El Debe/Haber", "Pos Express")
            tbxDebe.Focus()
            Exit Sub
        End If

        If (tbxDebe.Text = "") Then
            Debe = 0
        Else
            Debe = CDec(tbxDebe.Text)
            Debe = Replace(Debe, ",", ".")
        End If

        If (tbxHaber.Text = "") Then
            Haber = 0
        Else
            Haber = CDec(tbxHaber.Text)
            Haber = Replace(Haber, ",", ".")
        End If

        'Verificamos si Existe o no la Cuenta para saber si Actualizamos o Insertamos
        Existe = f.FuncionConsultaDecimal("AsientoID", "ASIENTOS", "AsientoID", Me.tbxAsientoID.Text)

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Dim Fecha As Date
        Dim fechaFormateada As String

        Fecha = dttFecha.Text
        fechaFormateada = Fecha.ToString("dd/MM/yyyy")

        CodPeriodoActual = f.FuncionConsultaDecimal("CODPERIODOFISCAL", "periodofiscal", "ESTADO", 1)
        CODSUCURSAL = 1

        If Existe = 0 Then 'Insert           
            Try
                If rdbCargarManual.Checked = True Then
                    'opcion 3
                    NroAsiento = txtAsientoNroManual.Text
                Else

                    NroAsiento = f.Maximo_con_Where("NUMASIENTO", "ASIENTOS", " CODPERIODOFISCAL =" & CodPeriodoActual)

                    If rdbNuevoNro.Checked = True Then
                        NroAsiento = NroAsiento + 1
                    End If


                End If

                sql = ""
                sql = "INSERT ASIENTOS (ModuloID,RegistroID,CODMONEDA,NUMASIENTO,FECHAASIENTO,COTIZACION,CODPERIODOFISCAL,CODPLANCUENTA,DESCRIPCION,IMPORTED,IMPORTEH,DETALLE, CODSUCURSAL) " & _
                      "VALUES (26," & Me.tbxAsientoID.Text & ",1," & NroAsiento & ",CONVERT(DATETIME,'" & fechaFormateada & "',103), 1.00," & CodPeriodoActual & "," & Me.tbxCodCuenta.Text & ",'" & Me.tbxNombreCuenta.Text & "'," & _
                      Debe & "," & Haber & ",'" & Me.tbxComentarios.Text & "', " & CODSUCURSAL & ")"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans.Commit()

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

                'INSERTAMOS EN AUDITORIA 
                InsertaAuditoria(1, 0, 0)
                '#########################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Ocurrio un error al intentar insertar ", "POSEXPRESS")
            Finally
                sqlc.Close()
            End Try

        Else 'Update
            Try
                sql = ""
                sql = "UPDATE ASIENTOS SET CODPLANCUENTA = " & Me.tbxCodCuenta.Text & " , FECHAASIENTO = CONVERT(DATETIME,'" & fechaFormateada & "',103), DESCRIPCION = '" & Me.tbxNombreCuenta.Text & "' , DETALLE = '" & Me.tbxComentarios.Text & "'," & _
                     "IMPORTED = " & Debe & " , IMPORTEH =" & Haber & "   WHERE AsientoID = " & tbxAsientoID.Text

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans.Commit()

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

                'INSERTAMOS EN AUDITORIA 
                InsertaAuditoria(0, 1, 0)
                '#########################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Ocurrio un error al intentar insertar ", "POSEXPRESS")
            Finally
                sqlc.Close()
            End Try

        End If

        Dim CodTemp As Integer = tbxAsientoID.Text

        Me.AsientosBindingSource.RemoveFilter()
        Dim i As Integer = cbxPeriodoFiscal.SelectedValue
        Me.AsientosTableAdapter.Fill(Me.DsPlantillasConta.Asientos, i)

        'Buscamos la posicion del registro guardado
        For i = 0 To dgvAsiento.RowCount - 1
            If dgvAsiento.Rows(i).Cells("AsientoID").Value = CodTemp Then
                AsientosBindingSource.Position = i
            End If
        Next

        RecorreGrilla()

        pbxBuscar.Enabled = True
        LimpiarCampos() : DesHabilitar()
    End Sub

    Private Sub tbxDebe_LostFocus(sender As Object, e As System.EventArgs) Handles tbxDebe.LostFocus
        If tbxDebe.Text = "" Then
            tbxDebe.Text = "0"
        End If
    End Sub

    Private Sub tbxHaber_LostFocus(sender As Object, e As System.EventArgs) Handles tbxHaber.LostFocus
        If tbxHaber.Text = "" Then
            tbxHaber.Text = "0"
        End If
    End Sub

    Private Sub dgvAsiento_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsiento.CellDoubleClick
        'Habilitamos el Modo de Edicion
        If dgvAsiento.RowCount <> 0 Then
            pbxAsientos_Click(Nothing, Nothing)
            pbxBuscar.Enabled = False
            Habilitar()

            'Obtenemos los datos de la grilla
            tbxAsientoID.Text = dgvAsiento.CurrentRow.Cells("AsientoID").Value
            tbxCodCuenta.Text = dgvAsiento.CurrentRow.Cells("CODPLANCUENTA").Value
            tbxNroCuenta.Text = f.FuncionConsultaString("NUMPLANCUENTA", "plancuentas", "CODPLANCUENTA", tbxCodCuenta.Text)
            tbxNombreCuenta.Text = dgvAsiento.CurrentRow.Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value
            tbxComentarios.Text = dgvAsiento.CurrentRow.Cells("DETALLE").Value
            tbxDebe.Text = dgvAsiento.CurrentRow.Cells("IMPORTED").Value
            tbxHaber.Text = dgvAsiento.CurrentRow.Cells("IMPORTEH").Value
            dttFecha.Text = dgvAsiento.CurrentRow.Cells("FECHAASIENTO").Value

            dttFecha.Focus()
        End If
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        'Habilitamos el Modo de Edicion
        If dgvAsiento.RowCount <> 0 Then
            pbxAsientos_Click(Nothing, Nothing)
            pbxBuscar.Enabled = False
            Habilitar()

            'Obtenemos los datos de la grilla
            tbxAsientoID.Text = dgvAsiento.CurrentRow.Cells("AsientoID").Value
            tbxCodCuenta.Text = dgvAsiento.CurrentRow.Cells("CODPLANCUENTA").Value
            tbxNroCuenta.Text = f.FuncionConsultaString("NUMPLANCUENTA", "plancuentas", "CODPLANCUENTA", tbxCodCuenta.Text)
            tbxNombreCuenta.Text = dgvAsiento.CurrentRow.Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value
            tbxComentarios.Text = dgvAsiento.CurrentRow.Cells("DETALLE").Value
            tbxDebe.Text = dgvAsiento.CurrentRow.Cells("IMPORTED").Value
            tbxHaber.Text = dgvAsiento.CurrentRow.Cells("IMPORTEH").Value
            dttFecha.Text = dgvAsiento.CurrentRow.Cells("FECHAASIENTO").Value

            dttFecha.Focus()
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        If dgvAsiento.RowCount <> 0 Then

            Dim Existe As Integer
            If MessageBox.Show("¿Esta seguro que quiere eliminar el Asiento?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Preguntamos si existe en la base de datos
            Existe = f.FuncionConsultaDecimal("AsientoID", "ASIENTOS", "AsientoID", dgvAsiento.CurrentRow.Cells("AsientoID").Value)

            If Existe <> 0 Then
                Try
                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc
                    sql = ""
                    sql = "DELETE ASIENTOS WHERE AsientoID = " & dgvAsiento.CurrentRow.Cells("AsientoID").Value & ""
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    sqlc.Close()

                Catch ex As SqlException
                    MessageBox.Show("Ocurrió un error al tratar de Eliminar ", "POSEXPRESS")
                    Exit Sub
                End Try

                'INSERTAMOS EN AUDITORIA 
                InsertaAuditoria(0, 0, 1)
                '#########################

                'Try
                '    Me.AsientosTableAdapter.Fill(Me.DsPlantillasConta.Asientos, cmbMes.SelectedValue)
                'Catch ex As Exception
                'End Try

                Button1_Click(Nothing, Nothing)
                'RecorreGrilla()
            End If
        End If
    End Sub

    Private Sub btnFiltrarCuentas_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrarCuentas.Click
        Dim CuentaDescrip As String

        If tbxBuscador.Text <> "" Then
            CuentaDescrip = "'%" + tbxBuscador.Text + "%'"
        Else
            CuentaDescrip = "%"
        End If

        Me.AsientosTableAdapter.FillBy(Me.DsPlantillasConta.Asientos, cbxPeriodoFiscal.SelectedValue, Me.dtpFechaDesde.Text, Me.dtpFechaHasta.Text)

        RecorreGrilla()
    End Sub

    Private Sub btnLimpiarCuentas_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarCuentas.Click
        dtpFechaDesde.Text = CalculaFechaAnterior(dtpFechaDesde.Text)
        dtpFechaHasta.Text = Today.ToShortDateString
        cbxPeriodoFiscal.Text = f.FuncionConsultaString("DESEJERCICIO", "periodofiscal", "ESTADO", 1)
        tbxBuscador.Text = ""

        Me.AsientosTableAdapter.Fill(Me.DsPlantillasConta.Asientos, cbxPeriodoFiscal.SelectedValue)
        RecorreGrilla()
    End Sub

    Private Sub dttFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dttFecha.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxNroCuenta.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FechaFiltro()

        Me.AsientosTableAdapter.FillBy(Me.DsPlantillasConta.Asientos, cbxPeriodoFiscal.SelectedValue, FechaFiltro1, FechaFiltro2)

        RecorreGrilla()
        ArrastrarTotales()
    End Sub
#End Region

    Private Sub ArrastrarTotales()
        'Se calcula el total de todos los meses

        If cmbMes.Text <> "Enero" Then
            Dim objCommand As New SqlCommand
            Dim Fecha1, Fecha2 As String

            Fecha1 = "01/01/" + cmbAnho.Text + " 00:00:00"
            Fecha2 = FechaFiltro2 + " 23:59:59"

            Try
                objCommand.CommandText = "SELECT TOP (100) PERCENT SUM(IMPORTED) AS DEBE, SUM(IMPORTEH) AS HABER FROM dbo.ASIENTOS " & _
                                         "WHERE (CODPERIODOFISCAL = " & cbxPeriodoFiscal.SelectedValue & ") AND (FECHAASIENTO >= CONVERT(DATETIME, '" & Fecha1 & "', 103)) AND " & _
                                         "(FECHAASIENTO <= CONVERT(DATETIME,'" & Fecha2 & "', 103))"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        txtTotalGenDebe.Text = FormatNumber(odrConfig("DEBE"), 0)
                        txtTotalGenHaber.Text = FormatNumber(odrConfig("HABER"), 0)
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try
        Else
            txtTotalGenDebe.Text = FormatNumber(tbxTotakDebe.Text, 0)
            txtTotalGenHaber.Text = FormatNumber(tbxTotalHaber.Text, 0)
        End If
    End Sub

    Private Sub rdbCargarManual_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbCargarManual.CheckedChanged
        If rdbCargarManual.Checked = True Then
            txtAsientoNroManual.Enabled = True
        Else
            txtAsientoNroManual.Enabled = False
        End If
    End Sub

    Private Sub rdbUltimoNro_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbUltimoNro.CheckedChanged
        txtAsientoNroManual.Enabled = False
    End Sub

    Private Sub rdbNuevoNro_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbNuevoNro.CheckedChanged
        txtAsientoNroManual.Enabled = False
    End Sub

End Class
