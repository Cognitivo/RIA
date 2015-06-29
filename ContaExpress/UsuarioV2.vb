Imports System.Data.SqlClient
Imports System.IO
Imports Osuna.Utiles.Conectividad

Public Class UsuarioV2
    Private sqlc As New SqlConnection
    Private myTrans As SqlTransaction
    Private ser As New BDConexión.BDConexion
    Private cmd As New SqlCommand
    Private sql As String
    Dim expiro As Integer
    Dim Nuevo As Integer
    Dim ins As Integer
    Dim IsNew, IsEdit As Integer
    Dim f As New Funciones.Funciones
    Dim CodUsuarioGlobal As Integer
    Dim CodEmpresaGlobal As Integer
    Dim permiso As Double
    Dim modificarPermisos As Integer
    Dim path As String = (Microsoft.VisualBasic.Left(Application.StartupPath, Len(Application.StartupPath) - 9))
    Dim ImageId As Integer


    Public Sub New()
        Me.InitializeComponent()
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub
    '*********LOAD***********
    Private Sub UsuarioV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 49)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        Dim Habilitado As Integer = 1

        Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)
        Me.USUARIOTableAdapter.Fill(Me.DsUsuario.USUARIO, "%")

        '--------------------------------------------------------------------------
        ModificarPictureBox_Click(sender, e)
        CancelarPictureBox_Click(sender, e)
        '---------------------------------------------------------------------------

        pnlUsuario.BringToFront()
        Deshabilitar()
        cbxPermisos.Checked = False
        IsNew = 0
        IsEdit = 0
    End Sub
    '**************HABILITAR CONTROLES******************

    Private Sub Habilitar()

        tbxUsuarios.BringToFront()

        pnlAccesos.Enabled = True
        pnlUsuario.Enabled = True

        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Cursor = Cursors.Hand
        GuardarPictureBox.Image = My.Resources.Save
        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Cursor = Cursors.Hand
        CancelarPictureBox.Image = My.Resources.SaveCancel

        dgvUsuarios.Enabled = False
        btnNuevo.Enabled = False
        btnNuevo.Cursor = Cursors.Arrow
        btnNuevo.Image = My.Resources.NewOff
        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Cursor = Cursors.Arrow
        EliminarPictureBox.Image = My.Resources.DeleteOff
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Cursor = Cursors.Arrow
        ModificarPictureBox.Image = My.Resources.EditOff

        tbxBuscar.Enabled = False
        tbxUsuarios.Visible = True

    End Sub
    '*******************DESHABILITAR CONTROLES***************

    Private Sub Deshabilitar()
       
        pnlAccesos.Enabled = False
        pnlUsuario.Enabled = False

        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Image = My.Resources.SaveOff
        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Cursor = Cursors.Arrow
        CancelarPictureBox.Image = My.Resources.AnullOff

        dgvUsuarios.Enabled = True
        btnNuevo.Enabled = True
        btnNuevo.Cursor = Cursors.Hand
        btnNuevo.Image = My.Resources.New_
        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Cursor = Cursors.Hand
        EliminarPictureBox.Image = My.Resources.Delete
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Cursor = Cursors.Hand
        ModificarPictureBox.Image = My.Resources.Edit
        tbxBuscar.Enabled = True

        tbxUsuarios.Visible = False
        dgvUsuarios.Focus()
    End Sub
    '******************BOTON NUEVO*******************************

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Nuevo = 1
        cbxPermisos.Enabled = True
        permiso = PermisoAplicado(UsuCodigo, 50)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permisos para Crear Nuevos Usuarios", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Habilitar()
            pnlUsuario.BringToFront()
            IsNew = 1
            IsEdit = 0
            Dim conexion As System.Data.SqlClient.SqlConnection
            conexion = ser.Abrir()
            Try
                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                'Insertamos un codigo de usuario en la base de datos tabla Usuario
                InsertaUsuario(myTrans)
                myTrans.Commit()
            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                Throw
            End Try

            USUARIOBindingSource.AddNew()
          
            Try
                Dim Habilitado As Integer
                Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)
                Dim CantReg As Integer = dgvPermisoUsuario.RowCount
                Dim UltimoUsuario As Integer

                'Mantenemos el mayor numero mayor de la base de datos como nuestro codigo de usuario
                UltimoUsuario = f.Maximo("CODUSUARIO", "USUARIO")
                CodUsuarioGlobal = UltimoUsuario
                txtUsuario.Text = CodUsuarioGlobal
                'Verificamos si el permiso esta habilitado para nuestro usuario
                For i = 0 To CantReg - 1
                    Habilitado = f.FuncionConsultaString("Permiso", "PERMISOSAPLICADOS", "Usuario_id = " & CodUsuarioGlobal & " AND Permiso_Id", dgvPermisoUsuario.Rows(i).Cells("Permisoid").Value)
                    dgvPermisoUsuario.Rows(i).Cells("Ver").Value = Habilitado
                Next

            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        Nuevo = 2
        cbxPermisos.Enabled = True
        permiso = PermisoAplicado(UsuCodigo, 51)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para modificar los datos de los Usuarios", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            IsNew = 0
            IsEdit = 1
            Habilitar()

            tbxUsuarios.Focus()

            Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)

            Dim CantReg As Integer = dgvPermisoUsuario.RowCount
            If pnlAccesos.Visible = True Then
                If Nuevo = 2 Then
                    For i = 0 To CantReg - 1
                        Dim Habilitado As Integer
                        Habilitado = f.FuncionConsultaString("Permiso", "PERMISOSAPLICADOS", "Usuario_id = " & CodUsuarioGlobal & " AND Permiso_Id", dgvPermisoUsuario.Rows(i).Cells("Permisoid").Value)
                        dgvPermisoUsuario.Rows(i).Cells("Ver").Value = Habilitado

                    Next
                End If
            End If




            End If
    End Sub
    '******************VALIDACION DE CONTRASEÑAS***********************

    Private Function validacontrasenhas(ByVal texto As TextBox) As Integer
        Dim w As New Funciones.Funciones
        Dim tipocontraseña As String
        Dim i As Integer
        tipocontraseña = w.FuncionConsultaString("TIPOCONTRASENHA", "CONFIGURACIONPASSW", "CODCONFIGURACION", 1)
        If Funciones.Cadenas.ContainsNumeric(texto.Text) And Funciones.Cadenas.ContainsAlpha(texto.Text) Then
            i = 3
        ElseIf IsNumeric(texto.Text) Then
            i = 1
        Else
            i = 2
        End If
        If tipocontraseña = "Números y Letras" Then
            If i = 1 Or i = 2 Then
                MessageBox.Show("Incluya  Números y Letras", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return 1
                Exit Function
            End If
        End If
        If tipocontraseña = "Solo Números" Then
            If i = 2 Or i = 3 Then
                MessageBox.Show("Solo se permiten Números", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return 1
                Exit Function
            End If
        End If
        If tipocontraseña = "Solo Letras" Then
            If i = 1 Or i = 3 Then
                MessageBox.Show("Solo se permiten Letras", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return 1
                Exit Function
            End If
        End If
        Return 0
    End Function

    Private Sub PeriodoPassword()
        Dim f As New Funciones.Funciones
        Dim fecha As String
        Dim fechaexpira As String
        Dim UltimoUsuario As Integer
        'Obtenemos el numero mayor registrado en la base de datos y le sumamos 1 para nuestro actual codigo
        UltimoUsuario = f.Maximo("CODUSUARIO", "USUARIO")
        fecha = f.FuncionConsultaString("FECHAPASSW", "USUARIO", "CODUSUARIO=" & UltimoUsuario & " AND CODEMPRESA", 1)

        fechaexpira = f.FuncionConsultaString("PERIODO", "CONFIGURACIONPASSW", "CODCONFIGURACION", 1)


            If fechaexpira = "12 meses" Then
                Dim fechadirerencia As Long
                fechadirerencia = DateDiff(DateInterval.Month, CDate(fecha), Today)
                If fechadirerencia >= 12 Then
                    'LabelExpiro.Visible = True
                    expiro = 1
                    Exit Sub
                End If
            End If
            If fechaexpira = "3 meses" Then
                Dim fechadirerencia As Long
                fechadirerencia = DateDiff(DateInterval.Month, CDate(fecha), Today)
                If fechadirerencia >= 3 Then
                    'LabelExpiro.Visible = True
                    expiro = 1
                    Exit Sub
                End If
            End If
            If fechaexpira = "1 mes" Then
                Dim fechadirerencia As Long
                fechadirerencia = DateDiff(DateInterval.Month, CDate(fecha), Today)
                If fechadirerencia >= 1 Then
                    'LabelExpiro.Visible = True
                    expiro = 1
                    Exit Sub
                End If
            End If
            If fechaexpira = "1 dia" Then
                Dim fechadirerencia As Long
                fechadirerencia = DateDiff(DateInterval.Day, CDate(fecha), Today)
                If fechadirerencia >= 1 Then
                    'LabelExpiro.Visible = True
                    expiro = 1
                    Exit Sub
                End If
            End If
            If fechaexpira = "15 dias" Then
                Dim fechadirerencia As Long
                fechadirerencia = DateDiff(DateInterval.Day, CDate(fecha), Today)
                If fechadirerencia >= 15 Then
                    expiro = 1
                    Exit Sub
                End If
            End If
            expiro = 0
    End Sub
    '**********************ACTUALIZAR USUARIO*******************

    Private Sub ActualizaUsuario()
        Dim Supervisor, Estado As Integer
        Dim CodSupervisor As String

        If cbxSupervisor.Checked = True Then
            Supervisor = 1
        Else
            Supervisor = 0
        End If

        If txtCodigoSupervisor.Text = "" Then
            CodSupervisor = "0"
        Else
            CodSupervisor = txtCodigoSupervisor.Text
        End If

        If cmbEstado.Text = "Activo" Then
            Estado = 1
        Else
            Estado = 0
        End If

        'Dim ImageIdOrig = Nothing
        'If IsDBNull(dgvUsuarios.CurrentRow.Cells("FONDO").Value) Then
        'Else
        '    ImageIdOrig = dgvUsuarios.CurrentRow.Cells("FONDO").Value
        'End If
        'If ImageId = Nothing Or ImageId = ImageIdOrig Then
        '    ImageId = dgvUsuarios.CurrentRow.Cells("FONDO").Value
        'End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        'Obtenemos el numero mayor registrado en la base de datos y le sumamos 1 para nuestro actual codigo
        If Nuevo = 1 Then
            Dim UltimoUsuario As Integer
            UltimoUsuario = f.Maximo("CODUSUARIO", "USUARIO")
            txtUsuario.Text = UltimoUsuario
        Else
            txtUsuario.Text = dgvUsuarios.CurrentRow.Cells("CODUSUARIO").Value
        End If
        cmd.Connection = sqlc
        cmd.Transaction = myTrans


        sql = ""
        sql = "UPDATE USUARIO SET " & _
        "DESUSUARIO='" & tbxNomUsuario.Text & "', NOMBRE = '" & tbxUsuarios.Text & "', CEDULA='" & tbxCIUsuario.Text & "', PASSUSUARIO ='" & tbxContraseña.Text & "', EMAIL='" & tbxEmail.Text & "', " & _
        "FECHAPASSW=" & Today & ", SUPERVISOR = " & Supervisor & ", IMAGEN = " & ImageId & ", CODSUPERVISOR = " & CodSupervisor & ", ESTADO = " & Estado & "  WHERE CODUSUARIO = " & txtUsuario.Text

        If chbxVendedor.Checked = True And chbxVendedor.Visible = True Then
            Dim Maximo As Integer = f.Maximo("Convert(int,NUMVENDEDOR)", "VENDEDOR")
            Maximo = Maximo + 1
            sql = sql + " INSERT INTO VENDEDOR (CODUSUARIO,NUMVENDEDOR,DESVENDEDOR,CEDULA,EMAIL,ESTADO) VALUES(" & txtUsuario.Text & ",'" & Maximo & "', '" & tbxUsuarios.Text & "','" & tbxCIUsuario.Text & "','" & tbxEmail.Text & "'," & Estado & ")"
        End If

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        myTrans.Commit()

    End Sub

    '****************INSERTAR USUARIO**************************

    Private Sub InsertaUsuario(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim consulta As System.String
        Dim UltimoUsuario As Integer
        'Obtenemos el numero mayor registrado en la base de datos y le sumamos 1 para nuestro actual codigo
        UltimoUsuario = f.Maximo("CODUSUARIO", "USUARIO")
        CodUsuarioGlobal = UltimoUsuario + 1
        txtUsuario.Text = CodUsuarioGlobal
        consulta = "INSERT INTO USUARIO (CODUSUARIO,CODEMPRESA) VALUES (" & CodUsuarioGlobal & ",1)"
        tbxUsuarios.Focus()
        Consultas.ConsultaComando(myTrans, consulta)
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim i, c As Integer
        Dim f As New Funciones.Funciones
        Dim w As New Funciones.Funciones

        '**************VALIDACIONES***************

        If tbxUsuarios.Text = "" Then
            MessageBox.Show("Ingrese el nombre del usuario", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxUsuarios.Focus()
        End If

        If tbxNomUsuario.Text = "" Then
            MessageBox.Show("Ingrese el Usuario", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            tbxNomUsuario.Focus()
            Exit Sub
        End If
        If tbxContraseña.Text = "" Then
            MessageBox.Show("Ingrese un password", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxContraseña.Focus()
            Exit Sub
        End If
        Try
            c = f.CtaCaracteresPassw("CANTIDADCARACTERES", "CONFIGURACIONPASSW", EmpCodigo, UsuCodigo)
            i = tbxContraseña.Text.Length
        Catch ex As Exception

        End Try
        If i < c Then
            MessageBox.Show("Debe introducir por lo menos " + c.ToString + " caracteres para el password", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxContraseña.Focus()
            Exit Sub
        End If
        If tbxRepContraseña.Text = "" Then
            MessageBox.Show("Ingrese de nuevo el password", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxRepContraseña.Focus()
            Exit Sub
        End If

        If tbxRepContraseña.Text <> tbxContraseña.Text Then

            MessageBox.Show("La confirmación de la contraseña no coincide con la contraseña, ingrese de nuevo", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxRepContraseña.Focus()
            Exit Sub
        End If

        If validacontrasenhas(tbxContraseña) = 1 Then
            tbxContraseña.Focus()
            Exit Sub
        End If
        If validacontrasenhas(tbxRepContraseña) = 1 Then
            tbxRepContraseña.Focus()
            Exit Sub
        End If

        'Dim transaction As SqlTransaction = Nothing

        If expiro = 1 Then
            If tbxContraseña.Text = w.FuncionConsultaString("PASSUSUARIO", "USUARIO", "CODUSUARIO=" & CodUsuarioGlobal & " AND CODEMPRESA", 1) Then
                MessageBox.Show("No ha modificado su contraseña, favor modifiquela!!,porque ya expiró!!")
                tbxContraseña.Focus()
                Exit Sub
            Else

            End If
        End If

        '****************INICIAR ACTUALIZACION******************
        ActualizaUsuario()


        '*****************GUARDAR RECORRE DE PERMISOS**************************


        Dim Habilitado As Integer
     
        'Recorremos la grilla para ir sumando los valores seleccionados
        If (Nuevo = 2 Or Nuevo = 1) And modificarPermisos = 1 Then

            For i = 0 To dgvPermisoUsuario.RowCount - 1
                Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgvPermisoUsuario.Rows(i).Cells("Ver")

                'Confirma los datos a la datasouce.
                Me.dgvPermisoUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit)

                'Dimensionamos una variable de tipo Boolean para hacer la verificacion
                Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)

                Dim idPermiso As Integer = dgvPermisoUsuario.Rows(i).Cells("Permisoid").Value
                Dim exitePermiso As Integer = f.FuncionConsultaString("Permiso", "PERMISOSAPLICADOS", "Usuario_Id=" & txtUsuario.Text & " AND Permiso_Id ", idPermiso)
                'Dim usuario As Integer=f.Funci")

                If checked = True Then
                    Habilitado = 1
                    If exitePermiso <> 0 Then
                        '*************EN CASO QUE TUVO EL PERMISO, LO SACARON, Y LO VOLVIERON A AGREGAR******************
                        ser.Abrir(sqlc)

                        Try
                            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                        Catch ex As Exception
                        End Try

                        cmd.Connection = sqlc
                        cmd.Transaction = myTrans
                        sql = ""
                        sql = "UPDATE PERMISOSAPLICADOS  SET Permiso= '" & Habilitado & "' WHERE  Usuario_id=" & txtUsuario.Text & " and Permiso_Id=" & idPermiso & ""
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                        myTrans.Commit()
                        sqlc.Close()

                    Else
                        '*************EN CASO QUE NUNCA TUVO EL PERMISO, Y AHORA LO TIENE******************
                        Try
                            Habilitado = 1
                            ser.Abrir(sqlc)
                            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

                            cmd.Connection = sqlc
                            cmd.Transaction = myTrans
                            sql = ""
                            sql = "INSERT INTO PERMISOSAPLICADOS (Permiso_Id,Usuario_id,Permiso)values(" & idPermiso & "," & txtUsuario.Text & "," & Habilitado & ")"
                            cmd.CommandText = sql
                            cmd.ExecuteNonQuery()
                            myTrans.Commit()
                            sqlc.Close()
                        Catch ex As Exception

                        End Try

                    End If

                Else

                    '*************EN CASO QUE TUVO PERMISO Y LUEGO LO SACARON******************
                    If exitePermiso <> 0 Then
                        ser.Abrir(sqlc)
                        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                        cmd.Connection = sqlc
                        cmd.Transaction = myTrans
                        sql = ""
                        sql = "DELETE FROM PERMISOSAPLICADOS  WHERE  Usuario_id=" & txtUsuario.Text & " AND Permiso_Id=" & idPermiso
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                        myTrans.Commit()
                        sqlc.Close()
                    End If
                End If


            Next
            modificarPermisos = 0
        End If
        MsgBox("Operacion realizada con exito")
        
        tbxBuscar.Focus()
        'Dim codusuTemp As Integer
        'codusuTemp = txtUsuario.Text
        Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)
        Me.USUARIOTableAdapter.Fill(Me.DsUsuario.USUARIO, "%")

        If Nuevo = 0 Then
            PeriodoPassword()
        End If


        Deshabilitar()
        cbxPermisos.Enabled = False
        tbxBuscar.Focus()
        Nuevo = 0

        '--------------------------------------------------------------------------

        ModificarPictureBox_Click(sender, e)
        CancelarPictureBox_Click(sender, e)

        '---------------------------------------------------------------------------


    End Sub
    '*************ELIMINAR USUARIO*********************

   

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        Try

            permiso = PermisoAplicado(UsuCodigo, 52)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para eliminar Usuarios", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else

                If MessageBox.Show("¿Esta seguro que quiere eliminar el Usuario?", "POS EXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                    Exit Sub

                End If
                CodUsuarioGlobal = dgvUsuarios.CurrentRow.Cells("CODUSUARIO").Value
                If CodUsuarioGlobal = 0 Or CodUsuarioGlobal = Nothing Then
                    MessageBox.Show("Seleccione un Cliente para Eliminar", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Deshabilitar()
                    Exit Sub
                End If
                Dim transaction As SqlTransaction = Nothing
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                cmd.Connection = sqlc
                cmd.Transaction = myTrans
                CodUsuarioGlobal = dgvUsuarios.CurrentRow.Cells("CODUSUARIO").Value
                sql = ""
                sql = " DELETE FROM USUARIO " & _
                      " WHERE CODUSUARIO= " & CDec(CodUsuarioGlobal)
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans.Commit()
                For i = 0 To dgvPermisoUsuario.Rows.Count - 1
                    Dim idPermiso As Integer = dgvPermisoUsuario.Rows(i).Cells("Permisoid").Value
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "DELETE FROM PERMISOSAPLICADOS  WHERE  Usuario_id=" & txtUsuario.Text & " AND Permiso_Id=" & idPermiso
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                Next
                Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)
                Me.USUARIOTableAdapter.Fill(Me.DsUsuario.USUARIO, "%")

                Deshabilitar()
            End If
            cbxPermisos.Checked = False

        Catch ex As Exception
            MessageBox.Show("Error al Eliminar: " & ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        If Nuevo = 1 Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            CodUsuarioGlobal = f.Maximo("CODUSUARIO", "USUARIO")

            sql = ""
            sql = " DELETE FROM USUARIO " & _
                  " WHERE CODUSUARIO= " & CDec(CodUsuarioGlobal)
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
        End If
        Try

            USUARIOBindingSource.CancelEdit()
            Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)

            Me.USUARIOTableAdapter.Fill(Me.DsUsuario.USUARIO, "%")

            Deshabilitar()
            tbxBuscar.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvUsuarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUsuarios.SelectionChanged
        modificarPermisos = 0
        pnlUsuario.BringToFront()

        pbxDatosUsuario.Cursor = Cursors.Arrow
        pbxDatosUsuario.Image = My.Resources.UserActive
        pbxAccesso.Cursor = Cursors.Hand
        pbxAccesso.Image = My.Resources.Access

        If dgvUsuarios.RowCount <> 0 Then
            If IsDBNull(dgvUsuarios.CurrentRow.Cells("SUPERVISOR").Value) Then
                cbxSupervisor.Checked = False
                pnlSupervisor.Visible = False
            Else
                If dgvUsuarios.CurrentRow.Cells("SUPERVISOR").Value = 0 Then
                    cbxSupervisor.Checked = False
                    pnlSupervisor.Visible = False
                Else
                    cbxSupervisor.Checked = True
                    pnlSupervisor.Visible = True
                End If
            End If
            chbxVendedor.Checked = False
            Dim existeVendedor As Integer = f.FuncionConsultaString("CODVENDEDOR", "VENDEDOR", "CODUSUARIO", txtUsuario.Text)
            If existeVendedor = 0 Then 'NO EXISTE
                chbxVendedor.Visible = True
            Else
                chbxVendedor.Visible = False
            End If
            If Not IsDBNull(dgvUsuarios.CurrentRow.Cells("ESTADO").Value) Then
                If dgvUsuarios.CurrentRow.Cells("ESTADO").Value = False Then
                    cmbEstado.SelectedIndex = 0
                Else
                    cmbEstado.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    'PROPIEDADES PARA tbxUsuarios
    Private Sub tbxUsuarios_GotFocus(sender As Object, e As System.EventArgs) Handles tbxUsuarios.GotFocus
        tbxUsuarios.BackColor = Color.LightSteelBlue
    End Sub
    Private Sub tbxUsuarios_tbxNomUsuario(sender As Object, e As System.EventArgs) Handles tbxUsuarios.LostFocus
        tbxUsuarios.BackColor = Color.Gainsboro
    End Sub
    Private Sub tbxUsuarios_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxUsuarios.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxCIUsuario.Focus()
            KeyAscii = 0
        End If
    End Sub

    'PROPIEDADES PARA tbxCIUsuario
    Private Sub tbxCIUsuario_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCIUsuario.GotFocus
        tbxCIUsuario.BackColor = Color.LightSteelBlue
    End Sub
    Private Sub tbxCIUsuario_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCIUsuario.LostFocus
        tbxCIUsuario.BackColor = Color.Gainsboro
    End Sub
    Private Sub tbxCIUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCIUsuario.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxNomUsuario.Focus()
            KeyAscii = 0
        End If
    End Sub

    'PROPIEDADES PARA tbxNomUsuario
    Private Sub tbxNomUsuario_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNomUsuario.GotFocus
        tbxNomUsuario.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxNomUsuario_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNomUsuario.LostFocus
        tbxNomUsuario.BackColor = Color.Gainsboro
        Dim s As String = tbxNomUsuario.Text
        tbxNomUsuario.Text = s.ToLower ' Converts String To Lower Cas
    End Sub

    Private Sub tbxNomUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNomUsuario.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxContraseña.Focus()
            KeyAscii = 0

        End If
    End Sub

    'PROPIEDADES PARA CONTRASENHA
    Private Sub tbxContraseña_GotFocus(sender As Object, e As System.EventArgs) Handles tbxContraseña.GotFocus
        tbxContraseña.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxContraseña_LostFocus(sender As Object, e As System.EventArgs) Handles tbxContraseña.LostFocus
        tbxContraseña.BackColor = Color.Gainsboro
    End Sub

    Private Sub tbxContraseña_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxContraseña.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxRepContraseña.Focus()
            KeyAscii = 0
        End If
    End Sub

    'PROPIEDADES PARA REPETIR CONTRASENHA
    Private Sub tbxRepContraseña_GotFocus(sender As Object, e As System.EventArgs) Handles tbxRepContraseña.GotFocus
        tbxRepContraseña.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxRepContraseña_LostFocus(sender As Object, e As System.EventArgs) Handles tbxRepContraseña.LostFocus
        tbxRepContraseña.BackColor = Color.Gainsboro
    End Sub

    Private Sub tbxRepContraseña_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxRepContraseña.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxEmail.Focus()
            KeyAscii = 0
        End If
    End Sub

    'PROPIEDADES PARA REPETIR tbxEmail
    Private Sub tbxEmail_GotFocus(sender As Object, e As System.EventArgs) Handles tbxEmail.GotFocus
        tbxEmail.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxEmail_LostFocus(sender As Object, e As System.EventArgs) Handles tbxEmail.LostFocus
        tbxEmail.BackColor = Color.Gainsboro
    End Sub

    Private Sub tbxBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxBuscar.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgvUsuarios.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxBuscar.TextChanged
        If tbxBuscar.Text <> "Buscar..." Then
            Me.USUARIOTableAdapter.Fill(Me.DsUsuario.USUARIO, "%" + tbxBuscar.Text + "%")
        End If
    End Sub

    Private Sub tbxBuscarPermiso_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxBuscarPermiso.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgvPermisoUsuario.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxBuscarPermiso_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxBuscarPermiso.TextChanged
        Try

            Dim consulta As String
            If tbxBuscarPermiso.Text <> Nothing Then

                CodUsuarioGlobal = dgvUsuarios.CurrentRow.Cells("CODUSUARIO").Value
                pnlAccesos.BringToFront()

                Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)
                Me.PermisoUsuarioBindingSource.Filter = "MODULO LIKE ('%" + tbxBuscarPermiso.Text + "%')"
                For I = 0 To dgvPermisoUsuario.RowCount
                    consulta = f.FuncionConsultaDecimal("Permiso", "PERMISOSAPLICADOS", "Usuario_id=" & CodUsuarioGlobal & " AND Permiso_Id", dgvPermisoUsuario.Rows(I).Cells("Permisoid").Value)
                    If consulta <> 0 Then

                        dgvPermisoUsuario.Rows(I).Cells("Ver").Value = 1

                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbPermisos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxPermisos.CheckedChanged, cbxPermisos.CheckedChanged
        Dim c As Integer = dgvPermisoUsuario.RowCount
        If c = 0 Then
            Exit Sub
        Else
            For i = 0 To c - 1
                If cbxPermisos.Checked = True Then
                    dgvPermisoUsuario.Rows(i).Cells("Ver").Value = 1
                ElseIf cbxPermisos.Checked = False Then
                    dgvPermisoUsuario.Rows(i).Cells("Ver").Value = 0

                End If
            Next

        End If
    End Sub

    Private Sub pbxAccesso_Click(sender As System.Object, e As System.EventArgs) Handles pbxAccesso.Click
        Dim Habilitado As Integer
        '--------------------------------------------------------------------------
        Dim CantReg As Integer = dgvPermisoUsuario.RowCount

        If Nuevo = 2 Then
            For i = 0 To CantReg - 1
                Dim Hab As Integer
                Hab = f.FuncionConsultaString("Permiso", "PERMISOSAPLICADOS", "Usuario_id = " & CodUsuarioGlobal & " AND Permiso_Id", dgvPermisoUsuario.Rows(i).Cells("Permisoid").Value)
                dgvPermisoUsuario.Rows(i).Cells("Ver").Value = Hab

            Next
        End If
        '---------------------------------------------------------------------------
        Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)

        modificarPermisos = 1
        cbxPermisos.Enabled = True
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar los Permisos.", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            cbxPermisos.Enabled = True
            permiso = PermisoAplicado(UsuCodigo, 51)
            'If Nuevo = 1 Then
            For i = 0 To CantReg - 1
                Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgvPermisoUsuario.Rows(i).Cells("Ver")

                'Confirma los datos a la datasouce.
                Me.dgvPermisoUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit)

                'Dimensionamos una variable de tipo Boolean para hacer la verificacion
                Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)
                If checked = True Then
                    Habilitado = 1
                ElseIf checked = False Then
                    Habilitado = 0
                End If
                dgvPermisoUsuario.Rows(i).Cells("Ver").Value = Habilitado
            Next
            'Else
            'cbxPermisos.Checked = False
            If Nuevo = 1 And tbxUsuarios.Text = "" Then
                MessageBox.Show("Este Usuario es nuevo,debe especificar su NOMBRE antes de aplicar los permisos.", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxUsuarios.Focus()
                tbxUsuarios.BackColor = Color.LightSteelBlue
                Exit Sub
            End If
            If Nuevo = 1 And tbxNomUsuario.Text = "" And tbxContraseña.Text = "" And tbxRepContraseña.Text = "" Then
                MessageBox.Show("Este Usuario es nuevo,debe especificar el USUARIO antes de aplicar los permisos.", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxNomUsuario.Focus()
                tbxNomUsuario.BackColor = Color.LightSteelBlue
                Exit Sub
            End If
            If Nuevo = 1 And tbxContraseña.Text = "" And tbxRepContraseña.Text = "" Then
                MessageBox.Show("Este Usuario es nuevo,debe especificar su CONTRASEÑA antes de aplicar los permisos.", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxContraseña.Focus()
                tbxContraseña.BackColor = Color.LightSteelBlue
                Exit Sub
            End If
            If Nuevo = 1 And tbxRepContraseña.Text = "" Then
                MessageBox.Show("Este Usuario es nuevo,debe REPETIR SU CONTRASEÑA antes de aplicar los permisos.", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tbxRepContraseña.Focus()
                tbxRepContraseña.BackColor = Color.LightSteelBlue
                Exit Sub
            End If
            Me.Cursor = Cursors.AppStarting
            'Me.PermisoUsuarioTableAdapter.Fill(Me.DsUsuario.PermisoUsuario)
            CodUsuarioGlobal = txtUsuario.Text
            'Dim Habilitado As Integer
            'Dim CantReg As Integer = dgvPermisoUsuario.RowCount
            If Nuevo = 2 Then
                For i = 0 To CantReg - 1

                    Habilitado = f.FuncionConsultaString("Permiso", "PERMISOSAPLICADOS", "Usuario_id = " & CodUsuarioGlobal & " AND Permiso_Id", dgvPermisoUsuario.Rows(i).Cells("Permisoid").Value)
                    dgvPermisoUsuario.Rows(i).Cells("Ver").Value = Habilitado

                Next
            End If
        End If
        pbxDatosUsuario.Cursor = Cursors.Hand
        pbxDatosUsuario.Image = My.Resources.User
        pbxAccesso.Cursor = Cursors.Arrow
        pbxAccesso.Image = My.Resources.AccessActive
        pnlAccesos.BringToFront()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub pbxDatosUsuario_Click(sender As System.Object, e As System.EventArgs) Handles pbxDatosUsuario.Click

        pbxDatosUsuario.Cursor = Cursors.Arrow
        pbxDatosUsuario.Image = My.Resources.UserActive
        pbxAccesso.Cursor = Cursors.Hand
        pbxAccesso.Image = My.Resources.Access
        'If Nuevo = 1 Then
        Dim Habilitado As Integer
        Dim CantReg As Integer = dgvPermisoUsuario.RowCount
        For i = 0 To CantReg - 1
            Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgvPermisoUsuario.Rows(i).Cells("Ver")

            'Confirma los datos a la datasouce.
            Me.dgvPermisoUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit)

            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
            Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)
            If checked = True Then
                Habilitado = 1
            ElseIf checked = False Then
                Habilitado = 0
            End If
            dgvPermisoUsuario.Rows(i).Cells("Ver").Value = Habilitado
        Next
        'End If
        pnlUsuario.BringToFront()
    End Sub


    Private Sub dgvPermisoUsuario_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPermisoUsuario.CellContentClick

    End Sub

    Private Sub dgvPermisoUsuario_Click(sender As Object, e As System.EventArgs) Handles dgvPermisoUsuario.Click
        'If Nuevo = 1 Then
        Dim Habilitado As Integer
        Dim CantReg As Integer = dgvPermisoUsuario.RowCount
        For i = 0 To CantReg - 1
            Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgvPermisoUsuario.Rows(i).Cells("Ver")

            'Confirma los datos a la datasouce.
            Me.dgvPermisoUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit)

            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
            Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)
            If checked = True Then
                Habilitado = 1
            ElseIf checked = False Then
                Habilitado = 0
            End If
            dgvPermisoUsuario.Rows(i).Cells("Ver").Value = Habilitado
        Next
        'End If
    End Sub

    Private Sub btnGenerarCodigo_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarCodigo.Click
        Try
            'Generacion del Codigo de Barra Formato EAN13 
            Dim Aleatorio, Maximo, Minimo, CodigoExistente, CodigoPeseable, result, CodPais As String
            Dim w As New Funciones.Funciones
            Dim tamanho, first, check, digit, i, r As Integer

            CodigoPeseable = ""
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

            txtCodigoSupervisor.Text = Aleatorio
        Catch ex As Exception
            MessageBox.Show("Error al Generará el Código Aleatorio", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cbxSupervisor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxSupervisor.CheckedChanged
        If cbxSupervisor.Checked = True Then
            pnlSupervisor.Enabled = True
            pnlSupervisor.Visible = True
        Else
            pnlSupervisor.Enabled = False
            pnlSupervisor.Visible = False
        End If
    End Sub

    Private Sub btnImprimirCodigo_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirCodigo.Click
        Dim informe = New Reportes.CodSupervisor
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim tamanho As Integer
        Dim codigo As String

        Dim dtCodigodeBarra As New DataTable
        dtCodigodeBarra.Columns.Add("Codigo")

        codigo = txtCodigoSupervisor.Text
        tamanho = codigo.Length

        If (tamanho < 12) Then
        Else
            Dim dr As DataRow = dtCodigodeBarra.NewRow
            Dim CodigoFormateado As String

            CodigoFormateado = EAN13(codigo)
            dr("Codigo") = CodigoFormateado
            dtCodigodeBarra.Rows.Add(dr)
            dtCodigodeBarra.AcceptChanges()

            informe.SetDataSource(informes.InfCodigoBarraSupervisor(dtCodigodeBarra))
            frm.CrystalReportViewer1.ReportSource = informe
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Public Function EAN13(ByVal value As String) As String
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

            result = (result + CType(ChrW((65 + (digit + (tableAB(first, (i - 1)) * 10)))), Char))
            i = (i + 1)
        Loop

        result = (result + "*")

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

    Private Sub btnSubirFondo_Click(sender As System.Object, e As System.EventArgs) Handles btnSubirFondo.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            pnlVistaPrevia.Visible = True
            pbxVistaPrevia.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
            'MessageBox.Show("Favor Cargue algun Nombre para esta Imagen", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxNombreImagen.Focus()
        End If
    End Sub

    Private Sub btnGuardarFondo_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardarFondo.Click
        If tbxNombreImagen.Text = "" Then
            MessageBox.Show("Favor Cargue algun Nombre para esta Imagen!", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxNombreImagen.Focus()
        Else
            ser.Abrir(sqlc)

            Dim sql As String = "INSERT INTO USUARIOFONDO VALUES(@IMAGEN,@DESCRIPCION)"
            Dim cmd As New SqlCommand(sql, sqlc)
            cmd.Parameters.AddWithValue("@DESCRIPCION", tbxNombreImagen.Text)
            Dim ms As New MemoryStream()
            pbxVistaPrevia.BackgroundImage.Save(ms, pbxVistaPrevia.BackgroundImage.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@IMAGEN", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Imagen Guardada exitosamente", "Guardar", MessageBoxButtons.OK)
            Me.USUARIOFONDOTableAdapter.Fill(Me.DsUsuario.USUARIOFONDO)
            pnlVistaPrevia.Visible = False
            Try

            Catch ex As Exception
                MessageBox.Show("Occurio un Error al Guardar la Imagen: " & ex.Message, "Problema al Cargar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub pbxPersonalizacion_Click(sender As System.Object, e As System.EventArgs) Handles pbxPersonalizacion.Click
        pnlPersonalizacion.BringToFront()
        pbxDatosUsuario.Image = My.Resources.User
        pbxAccesso.Image = My.Resources.Access
        Me.USUARIOFONDOTableAdapter.Fill(Me.DsUsuario.USUARIOFONDO)
    End Sub

    Private Sub dgvPersonalizacion_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvPersonalizacion.MouseDoubleClick
        lblNombreImagen.Text = dgvPersonalizacion.CurrentRow.Cells("DESCRIPCION").Value
        ImageId = dgvPersonalizacion.CurrentRow.Cells("CODIMAGEN").Value
    End Sub

    Private Sub btnVistaPrevia_Click(sender As System.Object, e As System.EventArgs) Handles btnVistaPrevia.Click

        ser.Abrir(sqlc)
        Dim cmd As New SqlCommand("SELECT IMAGEN FROM USUARIOFONDO WHERE CODIMAGEN='" & ImageId & "'", sqlc)
        Dim imageData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
        If Not imageData Is Nothing Then
            Using ms As New MemoryStream(imageData, 0, imageData.Length)
                ms.Write(imageData, 0, imageData.Length)
                Dashboard.Background.BackgroundImage = Image.FromStream(ms, True)
                ms.Dispose()
            End Using
        End If

        If rbtEstirarImagen.Checked = True Then
            Dashboard.Background.BackgroundImageLayout = ImageLayout.Stretch
        Else
            Dashboard.Background.BackgroundImageLayout = ImageLayout.Tile
        End If
    End Sub

    Private Sub dgvPersonalizacion_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPersonalizacion.CellContentClick

    End Sub

    Private Sub dgvUsuarios_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick

    End Sub
End Class