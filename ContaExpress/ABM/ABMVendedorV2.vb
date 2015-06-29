Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Public Class ABMVendedorV2

    Private ser As BDConexión.BDConexion
    Private sql As String
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction
    Private cmd As SqlCommand
    Dim Permiso As Integer
    Dim Maximo As Integer
    Dim f As New Funciones.Funciones
    Dim panelactivo As String
    Dim btnuevo, btmodif As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub ABMVendedorV2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Permiso = PermisoAplicado(UsuCodigo, 85)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If

        Me.USUARIOTableAdapter.Fill(Me.DsCentroDeCosto.USUARIO)
        Me.VENDEDORTableAdapter.Fill(Me.DsCentroDeCosto.VENDEDOR)
        Me.ZONATableAdapter.Fill(Me.DsCentroDeCosto.ZONA)

        panelactivo = "SplitVendedor"
        SplitVendedor.BringToFront()
        pnlEditBusc.Visible = True
        pbxTransferCli.Image = My.Resources.AjusteCaja
        pbxDatos.Image = My.Resources.UserActive

        DesHabilitar()
        btnuevo = 0 : btmodif = 0

    End Sub
    Private Sub Habilitar()
        PanelDatos.Enabled = True

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
    Private Sub DesHabilitar()
        PanelDatos.Enabled = False

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
    Private Sub tbxNroVend_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroVend.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxUsuario.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNombre.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxNroVend.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxUsuario.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxCelular.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 42 Then
            UltraPopupControlContainer1.PopupControl = gbxUsuario
            UltraPopupControlContainer1.Show()

            TxtBuscaUsuario.Focus()
            e.Handled = True
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbxEmail_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxEmail.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxCedula.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCelular_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCelular.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxEmail.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCedula_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCedula.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbEstado.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub cmbEstado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbEstado.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxComBase.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbxNombre_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNombre.GotFocus
        tbxNombre.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxNroVend_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNroVend.GotFocus
        tbxNroVend.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxUsuario_GotFocus(sender As Object, e As System.EventArgs) Handles tbxUsuario.GotFocus
        tbxUsuario.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxEmail_GotFocus(sender As Object, e As System.EventArgs) Handles tbxEmail.GotFocus
        tbxEmail.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxCedula_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCedula.GotFocus
        tbxCedula.BackColor = SystemColors.Highlight
    End Sub
    Private Sub cmbEstado_GotFocus(sender As Object, e As System.EventArgs) Handles cmbEstado.GotFocus
        cmbEstado.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxComBase_GotFocus(sender As Object, e As System.EventArgs) Handles tbxComBase.GotFocus
        tbxComBase.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxNombre_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNombre.LostFocus
        tbxNombre.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxNroVend_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroVend.LostFocus
        tbxNroVend.BackColor = SystemColors.ControlLightLight
        'Verificamos que el nro de VENDEDOR no se repita.' GenerarNroVENDEDOR()
        Dim Existe, CodVENDEDOR As Integer

        Try
            If tbxNroVend.Text = "" Then
                Maximo = f.Maximo("CAST(NUMVENDEDOR AS INT)", "VENDEDOR")
                Maximo = Maximo + 1

                tbxNroVend.Text = Maximo

            ElseIf tbxNroVend.Text <> "" Then
                Existe = f.FuncionConsultaString("NUMVENDEDOR", "VENDEDOR", "NUMVENDEDOR", tbxNroVend.Text)
                CodVENDEDOR = f.FuncionConsultaString("CODVENDEDOR", "VENDEDOR", "NUMVENDEDOR", tbxNroVend.Text)

                If (Existe = tbxNroVend.Text) And (CodVENDEDOR <> dgvVendedor.CurrentRow.Cells("CODVENDEDOR").Value) Then
                    MessageBox.Show("El Nro. de Vendedor ingresado ya existe en la Base de Datos. Elija otro Nro.!", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tbxNroVend.Focus()
                    tbxNroVend.BackColor = Color.Pink
                    Exit Sub
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tbxUsuario_LostFocus(sender As Object, e As System.EventArgs) Handles tbxUsuario.LostFocus
        tbxUsuario.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub tbxEmail_LostFocus(sender As Object, e As System.EventArgs) Handles tbxEmail.LostFocus
        tbxEmail.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub tbxCedula_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCedula.LostFocus
        tbxCedula.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub cmbEstado_LostFocus(sender As Object, e As System.EventArgs) Handles cmbEstado.LostFocus
        cmbEstado.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub tbxComBase_LostFocus(sender As Object, e As System.EventArgs) Handles tbxComBase.LostFocus
        tbxComBase.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        DesHabilitar()
        VENDEDORBindingSource.CancelEdit()
        lblNombre.SendToBack()
        dgvVendedor.Enabled = True
        lblNombre.BringToFront()
        btmodif = 0 : btnuevo = 0
    End Sub
    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click

        'Verificamos
        Dim MensajesError As String = ""
        Dim NroError, Estado As Integer
        Dim Comision As String
        Dim numero As System.Decimal
        Dim mascara As System.String
        mascara = "######000.00###"

        If tbxNombre.Text = "" Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Debe especificar el Nombre del Vendedor " + Chr(13)
            tbxNombre.BackColor = Color.Pink
        End If

        If tbxNroVend.Text = "" Then
            Maximo = f.Maximo("Convert(int,NUMVENDEDOR)", "VENDEDOR")
            Maximo = Maximo + 1

            tbxNroVend.Text = Maximo
        End If

        If tbxComBase.Text = "" Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Debe especificar la Comision Base del Vendedor " + Chr(13)
            tbxComBase.BackColor = Color.Pink
        End If

        If NroError <> 0 Then
            MessageBox.Show("Faltaron datos para completar el proceso de guardado. Favor revise estos items antes de seguir:  " + Chr(13) + MensajesError, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Decimal.TryParse(tbxComBase.Text, numero) Then
            Comision = numero.ToString(mascara)
            Comision = Replace(Comision, ",", ".")
        Else
            Comision = "0"
        End If

        If cmbEstado.Text = "Activo" Then
            Estado = 1
        Else
            Estado = 0
        End If

        'Guardamos
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            If btnuevo = 1 Then
                sql = ""
                If Trim(tbxUsuario.Text) = "" Then
                    sql = "INSERT INTO VENDEDOR(NUMVENDEDOR,DESVENDEDOR,CELULAR,CEDULA,EMAIL,COMISIONPOR,ESTADO) VALUES('" & tbxNroVend.Text & "','" & tbxNombre.Text & "','" & tbxCelular.Text & "','" & tbxCedula.Text & "','" & tbxEmail.Text & "'," & Comision & "," & Estado & ")"
                Else
                    sql = "INSERT INTO VENDEDOR (CODUSUARIO,NUMVENDEDOR,DESVENDEDOR,CELULAR,CEDULA,EMAIL,COMISIONPOR,ESTADO) VALUES(" & tbxUsuario.SelectedValue & ",'" & tbxNroVend.Text & "','" & tbxNombre.Text & "','" & tbxCelular.Text & "','" & tbxCedula.Text & "','" & tbxEmail.Text & "'," & Comision & "," & Estado & ")"
                End If

            ElseIf btmodif = 1 Then
                sql = ""
                If Trim(tbxUsuario.Text) = "" Then
                    sql = "UPDATE VENDEDOR SET NUMVENDEDOR  = '" & tbxNroVend.Text & "' ,DESVENDEDOR = '" & tbxNombre.Text & "' ,CELULAR = '" & tbxCelular.Text & "' ,CEDULA = '" & tbxCedula.Text & "' ,EMAIL = '" & tbxEmail.Text & "' ,COMISIONPOR = " & Comision & " ,ESTADO = " & Estado & " WHERE  CODVENDEDOR = " & dgvVendedor.CurrentRow.Cells("CODVENDEDOR").Value
                Else
                    sql = "UPDATE VENDEDOR SET CODUSUARIO = " & tbxUsuario.SelectedValue & " ,NUMVENDEDOR  = '" & tbxNroVend.Text & "' ,DESVENDEDOR = '" & tbxNombre.Text & "' ,CELULAR = '" & tbxCelular.Text & "' ,CEDULA = '" & tbxCedula.Text & "' ,EMAIL = '" & tbxEmail.Text & "' ,COMISIONPOR = " & Comision & " ,ESTADO = " & Estado & " WHERE  CODVENDEDOR = " & dgvVendedor.CurrentRow.Cells("CODVENDEDOR").Value
                End If
            End If

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            MessageBox.Show("Registro almacenado Existosamente", "POSEXPRESS")
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "POSEXPRESS")
            myTrans.Dispose()
        End Try

        Dim J As Integer
        J = VENDEDORBindingSource.Position
        Me.VENDEDORTableAdapter.Fill(Me.DsCentroDeCosto.VENDEDOR)
        VENDEDORBindingSource.Position = J
        lblNombre.BringToFront()
        DesHabilitar()
        btnuevo = 0
        btmodif = 0
        dgvVendedor.Enabled = True
        lblNombre.BringToFront()
    End Sub
    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        If BuscarTextBox.Text <> "" Then
            VENDEDORBindingSource.Filter = "DESVENDEDOR LIKE '%" & BuscarTextBox.Text & "%'"
        Else
            VENDEDORBindingSource.RemoveFilter()
        End If
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        Permiso = PermisoAplicado(UsuCodigo, 88)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            Habilitar()
            dgvVendedor.Enabled = False
            btnuevo = 0 : btmodif = 1
            lblNombre.SendToBack()
            tbxNombre.Focus()
        End If
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        Permiso = PermisoAplicado(UsuCodigo, 86)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Agregar un Vendedor", "Pos Express")
            Exit Sub
        End If
        btnuevo = 1 : btmodif = 0
        VENDEDORBindingSource.AddNew()
        dgvVendedor.Enabled = False
        Habilitar()
        lblNombre.SendToBack()
        tbxNombre.Focus()
        tbxComBase.Text = 0
    End Sub

    Private Sub BtnAsterisco_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsterisco.Click
        UltraPopupControlContainer1.PopupControl = gbxUsuario
        UltraPopupControlContainer1.Show()

        TxtBuscaUsuario.Text = ""
        TxtBuscaUsuario.Focus()
    End Sub
    Private Sub TxtBuscaUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscaUsuario.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgvUsuarios.Focus()
        End If
    End Sub
    Private Sub TxtBuscaUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscaUsuario.TextChanged
        If TxtBuscaUsuario.Text <> "Buscar..." Then
            Me.USUARIOBindingSource.Filter = "NOMBRE LIKE '%" & TxtBuscaUsuario.Text & "%'"
        End If
    End Sub
    Private Sub dgvUsuarios_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvUsuarios.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvUsuarios.RowCount <> 0 Then
                Dim index As Integer = USUARIOBindingSource.Position

                tbxUsuario.Text = dgvUsuarios.Rows(index).Cells("NOMBREUSUARIO").Value
                If Trim(tbxNombre.Text) = "" Then
                    tbxNombre.Text = dgvUsuarios.Rows(index).Cells("NOMBREUSUARIO").Value
                End If

                UltraPopupControlContainer1.Close()
                tbxUsuario.Focus()
            End If
        End If
    End Sub
    Private Sub dgvUsuarios_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellDoubleClick
        If dgvUsuarios.RowCount <> 0 Then
            tbxUsuario.Text = dgvUsuarios.CurrentRow.Cells("NOMBREUSUARIO").Value
            If Trim(tbxNombre.Text) = "" Then
                tbxNombre.Text = dgvUsuarios.CurrentRow.Cells("NOMBREUSUARIO").Value
            End If
            UltraPopupControlContainer1.Close()
            tbxUsuario.Focus()
        End If
    End Sub

    Private Sub dgvVendedor_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvVendedor.SelectionChanged
        If dgvVendedor.RowCount > 0 Then
            If Not IsDBNull(dgvVendedor.CurrentRow.Cells("ESTADO").Value) Then
                If dgvVendedor.CurrentRow.Cells("ESTADO").Value = False Then
                    cmbEstado.SelectedIndex = 0
                Else
                    cmbEstado.SelectedIndex = 1
                End If
            End If

        End If
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        Permiso = PermisoAplicado(UsuCodigo, 87)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere Eliminar este Vendedor?", "POS EXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        ser.Abrir(sqlc)
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            sql = " DELETE FROM VENDEDOR " & _
            " WHERE CODVENDEDOR= " & dgvVendedor.CurrentRow.Cells("CODVENDEDOR").Value & ""
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            DesHabilitar()
            VENDEDORTableAdapter.Fill(DsCentroDeCosto.VENDEDOR)
        Catch ex As Exception
            MessageBox.Show("El Vendedor ya tiene movimientos en el sistema y no se puede Eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myTrans.Dispose()
            sqlc.Close()
        End Try

        sqlc.Close()
    End Sub

    Private Sub rbPorVendedor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbPorVendedor.CheckedChanged
        If rbPorVendedor.Checked = True Then
            pnlPorVendedor.Enabled = True
            pnlPorVendedor.Visible = True
        Else
            pnlPorVendedor.Enabled = False
            pnlPorVendedor.Visible = False
        End If
    End Sub

    Private Sub rbPorZona_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbPorZona.CheckedChanged
        If rbPorZona.Checked = True Then
            pnlPorZona.Enabled = True
            pnlPorZona.Visible = True
        Else
            pnlPorZona.Enabled = False
            pnlPorZona.Visible = False
        End If
    End Sub

    Private Sub btnTransferir_Click(sender As System.Object, e As System.EventArgs) Handles btnTransferir.Click
        ser.Abrir(sqlc)
        cmd.Connection = sqlc

        Try
            If rbPorVendedor.Checked = True Then
                sql = ""
                sql = "UPDATE CLIENTES SET CODVENDEDOR= " & cmbVendedorA.SelectedValue & "" & _
                " WHERE CODVENDEDOR= " & cmbVendedorDe.SelectedValue & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                MessageBox.Show("Se ha Transferido existosamente los Clientes del Vendedor " & cmbVendedorDe.Text & " al Vendedor " & cmbVendedorA.Text & "", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf rbPorZona.Checked = True Then

                sql = ""
                sql = "UPDATE CLIENTES SET CODVENDEDOR= " & cmbVendedorAZona.SelectedValue & "" & _
                " WHERE CODZONA= " & cmbZona.SelectedValue & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                MessageBox.Show("Se ha Transferido existosamente los Clientes de la Zona " & cmbZona.Text & " al Vendedor " & cmbVendedorAZona.Text & "", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error en la operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        sqlc.Close()

    End Sub

    Private Sub pbxTransferCli_Click(sender As System.Object, e As System.EventArgs) Handles pbxTransferCli.Click
        If panelactivo = "SplitVendedor" Then
            Permiso = PermisoAplicado(UsuCodigo, 87)
            If Permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para Transferir Clientes", "Pos Express")
                Exit Sub
            End If
            panelactivo = "TransferClientes"
            pnlTransfer.BringToFront()
            pnlEditBusc.Visible = False
            pbxTransferCli.Image = My.Resources.AjusteCajaActive
            pbxDatos.Image = My.Resources.User
            rbPorVendedor.Checked = True
            rbPorZona_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub pbxDatos_Click(sender As System.Object, e As System.EventArgs) Handles pbxDatos.Click
        If panelactivo = "TransferClientes" Then
            panelactivo = "SplitVendedor"
            SplitVendedor.BringToFront()
            pnlEditBusc.Visible = True
            pbxDatos.Image = My.Resources.UserActive
            pbxTransferCli.Image = My.Resources.AjusteCaja
        End If
    End Sub

    Private Sub pbxDatos_MouseEnter(sender As Object, e As System.EventArgs) Handles pbxDatos.MouseEnter
        Me.ToolTip1.SetToolTip(Me.pbxDatos, "Datos Vendedores")
    End Sub

    Private Sub pbxTransferCli_MouseEnter(sender As Object, e As System.EventArgs) Handles pbxTransferCli.MouseEnter
        Me.ToolTip1.SetToolTip(Me.pbxTransferCli, "Transferencia de Clientes")
    End Sub

    Private Sub tbxNroVend_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxNroVend.TextChanged

    End Sub
End Class