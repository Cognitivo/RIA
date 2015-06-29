Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class ABMRangoComprobante
    Private cmd As SqlCommand
    Private ser As BDConexión.BDConexion
    Private sql As String
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction

    Dim permiso As Double
    Dim w As New Funciones.Funciones
    Dim btnNuevo, btnEditar As Integer
    Dim Imprimir, Activo As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub ABMRangoComprobante_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        'CargarImpresora()
    End Sub

    Private Sub ABMRangoComprobante_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 79)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        btnNuevo = 0 : btnEditar = 0

        Try
            Me.TIPOCOMPROBANTETableAdapter.Fill(Me.DsSettings.TIPOCOMPROBANTE, "%")
            Me.SUCURSALTableAdapter.Fill(Me.DsSettings.SUCURSAL)
        Catch ex As Exception
        End Try
        Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Factura'  OR TIPOSUCURSAL = 'Factura y Stock'"

        If dgwSucursal.RowCount <> 0 Then
            Me.PCTableAdapter.FillBy(Me.DsSettings.PC, dgwSucursal.CurrentRow.Cells("CODSUCURSAL").Value)
            If dgwPc.RowCount <> 0 Then
                Me.RANGOPCTableAdapter.Fill(DsSettings.RANGOPC, dgwPc.CurrentRow.Cells("IP").Value)
            End If
        End If

        EstadoRango()
        Deshabilita()
    End Sub

    Private Sub EstadoRango()
        'Estado
        If Me.txtEstado.Text <> "" Then
            If Me.txtEstado.Text = 0 Then
                LblEstado.Text = "Desactivado"
                LblEstado.ForeColor = Color.Red
                cbxEstado.Text = "Desactivado"
            ElseIf Me.txtEstado.Text = 1 Then
                LblEstado.Text = "Activo"
                LblEstado.ForeColor = Color.Green
                cbxEstado.Text = "Activo"
            ElseIf Me.txtEstado.Text = 2 Then
                LblEstado.Text = "Pendiente"
                LblEstado.ForeColor = Color.Black
                cbxEstado.Text = "Pendiente"
            End If
        End If
        
        'Imprimir
        If Me.txtImprimir.Text <> "" Then
            If Me.txtImprimir.Text = 1 Then
                ChckImprimir.Checked = True
            ElseIf Me.txtImprimir.Text = 0 Then
                ChckImprimir.Checked = False
            End If
        End If
    End Sub

    Private Sub CargarImpresora()
        Dim prtdoc As New PrintDocument
        Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName
        Dim strPrinter As [String]
        Try
            For Each strPrinter In PrinterSettings.InstalledPrinters
                cbxImpresora.Items.Add(strPrinter)
            Next strPrinter
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Habilita()
        pnlDetPc.Enabled = True

        'Botonera
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

    Private Sub Deshabilita()
        pnlDetPc.Enabled = False

        'Botonera
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
    End Sub

    Private Sub dgwSucursal_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwSucursal.SelectionChanged
        If dgwSucursal.RowCount <> 0 Then
            Me.PCTableAdapter.FillBy(Me.DsSettings.PC, dgwSucursal.CurrentRow.Cells("CODSUCURSAL").Value)
        End If
    End Sub

    Private Sub dgwPc_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwPc.SelectionChanged
        If dgwPc.RowCount <> 0 Then
            Me.RANGOPCTableAdapter.Fill(DsSettings.RANGOPC, dgwPc.CurrentRow.Cells("IP").Value)
        End If
    End Sub

    Private Sub txtDesde_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesde.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtHasta.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDesde_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDesde.TextChanged
        Funciones.Cadenas.SoloNumeros(txtDesde.Text)
    End Sub

    Private Sub txtHasta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHasta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxImpresora.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtHasta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHasta.TextChanged
        Funciones.Cadenas.SoloNumeros(txtHasta.Text)
    End Sub

    Private Sub txtActual_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtActual.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtNroDigitos.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtActual_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtActual.TextChanged
        Funciones.Cadenas.SoloNumeros(txtActual.Text)
    End Sub

    Private Sub txtNroDigitos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDigitos.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxEstado.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroDigitos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNroDigitos.TextChanged
        Funciones.Cadenas.SoloNumeros(txtNroDigitos.Text)
    End Sub

    Private Sub cbxTipoComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoComprobante.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtTimbrado.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTimbrado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbrado.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtDesde.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxImpresora_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxImpresora.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaValidez.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtpFechaValidez_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaValidez.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtActual.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 82)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para crear en esta ventana", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        btnNuevo = 0 : btnEditar = 1
        cbxImpresora.Items.Clear()
        CargarImpresora()

        'verificamos que el rango no este desactivado
        If Me.dgwPc.CurrentRow.Cells("IP").Value <> 0 Then
            If dgwDetPc.RowCount <> 0 Then
                Habilita()
                cbxTipoComprobante.Focus()
            Else
                MessageBox.Show("No existe rango de comprobantes para esta máquina")
            End If
        Else
            Deshabilita()
        End If
    End Sub

    Private Sub dgwDetPc_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwDetPc.SelectionChanged
        If dgwDetPc.RowCount <> 0 Then
            EstadoRango()
        End If
    End Sub

    Private Sub txtActual_Validated(sender As Object, e As System.EventArgs) Handles txtActual.Validated
        Dim actual, desde, hasta As Integer
        Try
            If txtDesde.Text = "" Then
                desde = 0
            Else
                desde = CInt(txtDesde.Text)
            End If
            If txtHasta.Text = "" Then
                hasta = 0
            Else
                hasta = CInt(txtHasta.Text)
            End If
            If txtActual.Text = "" Then
                actual = 0
            Else
                actual = CInt(txtActual.Text)
            End If

            If desde > actual Then
                MessageBox.Show("No puede ser menor que el desde ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtActual.Focus()
            End If
            If hasta < actual Then
                MessageBox.Show("No puede ser mayor al hasta ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtActual.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHasta_Validated(sender As Object, e As System.EventArgs) Handles txtHasta.Validated
        Try
            Dim hasta, desde As Integer
            If txtDesde.Text = "" Then
                desde = 0
            Else
                desde = CInt(txtDesde.Text)
            End If
            If txtHasta.Text = "" Then
                hasta = 0
            Else
                hasta = CInt(txtHasta.Text)
            End If
            If desde > hasta Then
                MessageBox.Show("No puede ser menor que el desde ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtHasta.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim transaction As SqlTransaction = Nothing

        permiso = PermisoAplicado(UsuCodigo, 80)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para guardar en esta ventana", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If cbxTipoComprobante.Text = "" Then
            MessageBox.Show("Ingrese el Comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbxTipoComprobante.Focus()
            Exit Sub
        End If
        If txtDesde.Text = "" Then
            MessageBox.Show("Ingrese desde que nro comiennza el Comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDesde.Focus()
            Exit Sub
        End If
        If txtHasta.Text = "" Then
            MessageBox.Show("Ingrese hasta que nro abarca el Comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHasta.Focus()
            Exit Sub
        End If
        If txtActual.Text = "" Then
            MessageBox.Show("Ingrese el Nro actual de Comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtActual.Focus()
            Exit Sub
        End If

        If txtNroDigitos.Text = "" Then
            MessageBox.Show("Ingrese el nro de Dígitos del Comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNroDigitos.Focus()
            Exit Sub
        End If

        If ChckImprimir.Checked = True Then
            Imprimir = 1
        Else
            Imprimir = 0
        End If

        If cbxEstado.Text = "Desactivado" Then
            Activo = 0
        ElseIf cbxEstado.Text = "Activo" Then
            Activo = 1
        ElseIf cbxEstado.Text = "Pendiente" Then
            Activo = 2
        End If

        Dim ExisteOtroActivo As Integer
        'se verifica que no se inserte 2 comprobantes iguales con estado activo
        ExisteOtroActivo = w.FuncionConsulta("RANDOID", "DETPC", "IP= " & dgwPc.CurrentRow.Cells("IP").Value & " AND CODSUCURSAL=" & dgwSucursal.CurrentRow.Cells("CODSUCURSAL").Value & _
                                             " AND CODCOMPROBANTE= " & cbxTipoComprobante.SelectedValue & " AND ACTIVO", 1)

        If (ExisteOtroActivo <> 0) And (Activo = 1) And (ExisteOtroActivo <> dgwDetPc.CurrentRow.Cells("RANDOIDDataGridViewTextBoxColumn").Value) Then
            MessageBox.Show("Ya existe un comprobante activo en la sucursal,el mismo se creará como pendiente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Activo = 2
        End If

        'Preguntamos si existe para saber si es una actualizacion o insercion
        If btnEditar = 1 Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizarRango()
                myTrans.Commit()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '############################################# - AUDITORIA TABLAS - ##########################################
                Dim c As New Funciones.Funciones
                Dim codigoaudi As Integer = c.Maximo("CODIGO", "auditoriatablas")
                If codigoaudi = 0 Then
                    codigoaudi = 1
                Else
                    codigoaudi = codigoaudi + 1
                End If

                Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "DETPC", codigoaudi.ToString, "MODIFICACION EN DETPC(RANGOS DE COMPROBANTES)", Today(), UsuDescripcion, UsuNivel, 0, 1, 0)
                '###############################################################################################################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Finally
                sqlc.Close()

            End Try

        ElseIf btnNuevo = 1 Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                InsertaRango()
                myTrans.Commit()

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '############################################# - AUDITORIA TABLAS - ##########################################
                Dim c As New Funciones.Funciones
                Dim codigoaudi As Integer = c.Maximo("CODIGO", "auditoriatablas")
                If codigoaudi = 0 Then
                    codigoaudi = 1
                Else
                    codigoaudi = codigoaudi + 1
                End If

                Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "DETPC", codigoaudi.ToString, "INSERCIÓN EN DETPC(RANGOS DE COMPROBANTES)", Today(), UsuDescripcion, UsuNivel, 1, 0, 0)
                '###############################################################################################################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error al insertar el registro ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                sqlc.Close()
            End Try
        End If

        Dim i As Integer = RANGOPCBindingSource.Position()
        Me.RANGOPCTableAdapter.Fill(DsSettings.RANGOPC, dgwPc.CurrentRow.Cells("IP").Value)
        RANGOPCBindingSource.Position = i

        Deshabilita()
        EstadoRango()
    End Sub

    Private Sub InsertaRango()
        Dim timbrado, fecha As String

        If txtTimbrado.Text = "" Then
            timbrado = "NULL"
        Else
            timbrado = txtTimbrado.Text
        End If

        If dtpFechaValidez.Text = "" Or dtpFechaValidez.Text = Nothing Then
            fecha = Today.ToShortDateString
        Else
            fecha = dtpFechaValidez.Text
        End If

        sql = ""
        sql = "INSERT INTO DETPC (IP,CODEMPRESA,CODSUCURSAL,CODCOMPROBANTE,RANGO1,RANGO2,ULTIMO,IMPRESORA,TIMBRADO,FECHAVALIDEZ, NRODIGITOS,IMPRIMIR,ACTIVO)   " & _
              "VALUES (" & dgwPc.CurrentRow.Cells("IP").Value & ", " & EmpCodigo & ", " & dgwSucursal.CurrentRow.Cells("CODSUCURSAL").Value & ", " & _
              cbxTipoComprobante.SelectedValue & "," & txtDesde.Text & " , " & txtHasta.Text & ", " & txtActual.Text & " , '" & cbxImpresora.Text & "'," & timbrado & ", " & _
              "CONVERT(DATETIME,'" & fecha & "',103), " & txtNroDigitos.Text & "," & Imprimir & "," & Activo & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizarRango()
        Dim timbrado, fecha As String

        If txtTimbrado.Text = "" Then
            timbrado = "NULL"
        Else
            timbrado = txtTimbrado.Text
        End If

        If dtpFechaValidez.Text = "" Or dtpFechaValidez.Text = Nothing Then
            fecha = Today.ToShortDateString
        Else
            fecha = dtpFechaValidez.Text
        End If

        sql = ""
        sql = "UPDATE DETPC  SET RANGO1= " & txtDesde.Text & " , RANGO2= " & txtHasta.Text & ", ULTIMO=" & txtActual.Text & " , CODCOMPROBANTE=" & cbxTipoComprobante.SelectedValue & _
              ",ACTIVO=" & Activo & " , IMPRESORA='" & cbxImpresora.Text & "',TIMBRADO=" & timbrado & " , FECHAVALIDEZ=CONVERT(DATETIME,'" & fecha & "',103), " & _
              "NRODIGITOS = " & txtNroDigitos.Text & " , IMPRIMIR=" & Imprimir & "    WHERE  RANDOID=" & dgwDetPc.CurrentRow.Cells("RANDOIDDataGridViewTextBoxColumn").Value & " "

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub txtDesde_Validated(sender As Object, e As System.EventArgs) Handles txtDesde.Validated
        Dim hasta, desde As Integer
        Try
            If txtDesde.Text = "" Then
                desde = 0
            Else
                desde = CInt(txtDesde.Text)
            End If
            If txtHasta.Text = "" Then
                Exit Sub
            Else
                hasta = CInt(txtHasta.Text)
            End If
            If desde > hasta Then
                MessageBox.Show("No puede ser mayor que el hasta ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDesde.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 83)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para crear en esta ventana", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If dgwPc.RowCount = 0 Then
            MessageBox.Show("No se ha grabado ninguna maquina todavia, grabe un maquina e intente de nuevo", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        btnNuevo = 1 : btnEditar = 0
        Habilita()
        RANGOPCBindingSource.AddNew()

        cbxImpresora.Items.Clear()
        CargarImpresora()

        cbxTipoComprobante.Focus()
        txtNroDigitos.Text = 7 : lblNumeracion.Text = ""
        LabelSucursal.Text = dgwSucursal.CurrentRow.Cells("DESSUCURSAL").Value
        LabelMaquina.Text = dgwPc.CurrentRow.Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value
        ChckImprimir.Checked = False
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        RANGOPCBindingSource.CancelEdit()
        Deshabilita()
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 81)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para eliminar registros en esta ventana", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("Esta seguro que desea eliminar el registro", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        Else
            EliminarRango()
         
        End If

        Me.RANGOPCTableAdapter.Fill(DsSettings.RANGOPC, dgwPc.CurrentRow.Cells("IP").Value)

        Deshabilita()
        EstadoRango()        
    End Sub

    Private Sub EliminarRango()
        Dim transaction As SqlTransaction = Nothing

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            sql = "DELETE FROM DETPC WHERE  RANDOID=" & dgwDetPc.CurrentRow.Cells("RANDOIDDataGridViewTextBoxColumn").Value & "  "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            MessageBox.Show("Se han eliminado correctamente los datos: ", "POSEXPRESS")

            '############################################# - AUDITORIA TABLAS - ##########################################
            Dim c As New Funciones.Funciones
            Dim codigoaudi As Integer = c.Maximo("CODIGO", "auditoriatablas")
            If codigoaudi = 0 Then
                codigoaudi = 1
            Else
                codigoaudi = codigoaudi + 1
            End If

            Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "PC", codigoaudi.ToString, "ELIMINACIÓN DE DETPC(RANGO DE COMPROBANTES)", Today(), UsuDescripcion, UsuNivel, 0, 0, 1)
            '#############################################################################################################

        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch
            End Try
            MessageBox.Show("No se puede Eliminar este Rango, Porque tiene relacion con otra tabla ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub dgwPc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwPc.CellContentClick

    End Sub
End Class