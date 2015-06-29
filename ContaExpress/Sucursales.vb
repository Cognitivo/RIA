Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Public Class Sucursales

    #Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand
    Dim CodEncargado, Codciudad As String
    Dim del As Integer

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim ins As Integer
    Private Modificar As Integer 'Para saber si presiono en el boton nmodificar
    Private myTrans As SqlTransaction
    Dim pri As Integer
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Private sql As String
    Private sqlc As SqlConnection
    Private sucursal As Integer 'Para saber quien tiene foco inserta,elimina o actualiza
    Dim f As New Funciones.Funciones
    Dim upd As Integer
    Dim permiso As Double
    #End Region 'Fields

    #Region "Constructors"

    '#######################################################################################################################
    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    #End Region 'Constructors

    #Region "Methods"

    Private Sub ActualizaPC()
        Dim CodCaja As Integer = 0
        If cmbCaja.Text <> "" Then
            CodCaja = cmbCaja.SelectedValue
        End If

        sql = ""
        sql = "UPDATE PC SET CODUSUARIO = " & UsuCodigo & ", NOMBRE = '" & TxtNombreMaquina.Text & "', DESCRIPCION = '" & TxtDescripcionMaquina.Text & "', TIPOPC= '" & RadComboBoxTipoMaquina.Text & _
            "', NUMMAQUINA= '" & TxtNumMaquina.Text & "' , CODCAJA =" & CodCaja & " WHERE CodEmpresa = " & EmpCodigo & " and CODSUCURSAL = " & CODSUCURSALTextBox.Text & " AND IP =" & PCRadGridView.CurrentRow.Cells("IP").Value
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizaSucursal()
        Dim C As Integer
        If FACTURARCheckBox.Checked = True Then
            C = 1
        Else
            C = 0
        End If

        sql = ""
        sql = "UPDATE SUCURSAL SET DESSUCURSAL = '" & TxtDescripcionSucursal.Text & "' " & _
             ",DIRECCION='" & TxtDireccionSucursal.Text & "',TELEFONO='" & TxtTelefonoSucursal.Text & "' ," & _
            "CODUSUARIO = " & UsuCodigo & ",SUCURSALTIMBRADO='" & TxtTimbradoSucursal.Text & "',CODCIUDAD=" & Codciudad & "," & _
            "EMAIL='" & TxtEmailSucursal.Text & "',FACTURAR=" & C & "," & _
            " TIPOSUCURSAL='" & RadComboBoxTipoSucursal.Text & "' WHERE  CODSUCURSAL = " & CODSUCURSALTextBox.Text & " "

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub DeshabilitarSucursales()
        'Habilita campos para cargar Sucursal
        PictureBoxNuevoR.Enabled = False
        PictureBoxNuevoR.Image = My.Resources.NewOff
        PictureBoxNuevoR.Cursor = Cursors.Arrow
        PictureBoxEliminarR.Enabled = False
        PictureBoxEliminarR.Image = My.Resources.DeleteOff
        PictureBoxEliminarR.Cursor = Cursors.Arrow
        PictureBoxModificaR.Enabled = False
        PictureBoxModificaR.Image = My.Resources.EditOff
        PictureBoxModificaR.Cursor = Cursors.Arrow

        PictureBoxCancelarR.Enabled = True
        PictureBoxCancelarR.Image = My.Resources.SaveCancel
        PictureBoxCancelarR.Cursor = Cursors.Hand
        PictureBoxGuardarR.Enabled = True
        PictureBoxGuardarR.Image = My.Resources.Save
        PictureBoxGuardarR.Cursor = Cursors.Hand

        'quita  read only los textos
        TxtDescripcionSucursal.Enabled = True
        RadComboBoxTipoSucursal.Enabled = True
        TxtDireccionSucursal.Enabled = True
        TxtTimbradoSucursal.Enabled = True
        TxtEmailSucursal.Enabled = True
        TxtTelefonoSucursal.Enabled = True
        RadComboBoxCiudadSucursal.Enabled = True
        SUCURSALRadGridView.Enabled = False
        PCRadGridView.Enabled = False
        pnlSucursal.BackColor = Color.Gainsboro
    End Sub

    Private Sub DeshabilitarMaquinas()
        'Habilita Los Campos necesario para cargar Maquina
        PictureBoxNuevoR.Enabled = False
        PictureBoxNuevoR.Image = My.Resources.NewOff
        PictureBoxNuevoR.Cursor = Cursors.Arrow
        PictureBoxEliminarR.Enabled = False
        PictureBoxEliminarR.Image = My.Resources.DeleteOff
        PictureBoxEliminarR.Cursor = Cursors.Arrow
        PictureBoxModificaR.Enabled = False
        PictureBoxModificaR.Image = My.Resources.EditOff
        PictureBoxModificaR.Cursor = Cursors.Arrow

        PictureBoxCancelarR.Enabled = True
        PictureBoxCancelarR.Image = My.Resources.SaveCancel
        PictureBoxCancelarR.Cursor = Cursors.Hand
        PictureBoxGuardarR.Enabled = True
        PictureBoxGuardarR.Image = My.Resources.Save
        PictureBoxGuardarR.Cursor = Cursors.Hand

        'quita  read only los textos
        TxtDescripcionMaquina.Enabled = True
        TxtNumMaquina.Enabled = True
        RadComboBoxTipoMaquina.Enabled = True
        TxtNombreMaquina.Enabled = True
        cmbCaja.Enabled = True

        SUCURSALRadGridView.Enabled = False
        PCRadGridView.Enabled = False
        pnlMaquina.BackColor = Color.Gainsboro
    End Sub

    Private Sub eliminapc(ByVal codpc As Decimal)
        Dim transaction As SqlTransaction = Nothing
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            sql = "DELETE FROM PC WHERE IP= " & codpc & ""
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

            Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "PC", codigoaudi.ToString, "ELIMINACIÓN DE PC", _
                                                  Today(), UsuDescripcion, UsuNivel, 0, 0, 1)

            '#############################################################################################################

        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch
            End Try
            MessageBox.Show("Ocurrio un error al intentar eliminar el registro: " + ex.Message, "POSEXPRESS")
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub eliminasucursal(ByVal codsucursal As Decimal)
        Dim transaction As SqlTransaction = Nothing
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            sql = "DELETE FROM SUCURSAL WHERE CODSUCURSAL= " & codsucursal & ""
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

            Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "SUCURSAL", codigoaudi.ToString, "ELIMINACIÓN DE SUCURSAL", _
                                                 Today(), UsuDescripcion, UsuNivel, 0, 0, 1)

            '#############################################################################################################

        Catch ex As SqlException
            Try
                myTrans.Rollback("Eliminar")
            Catch
            End Try
            Dim NroError As Integer = ex.Number
            Dim Mensaje As String = ex.Message
            If NroError = 547 Then

                MessageBox.Show("La sucursal tiene relación con otra tabla del Sistema,borre primero la relación y luego intente de nuevo", "POSEXPRESS")
            Else
                MessageBox.Show("Ocurrio un error el eliminar Sucursal" + ex.Message, "POSEXPRESS")
            End If
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub GuardarPc()
        Dim w As New Funciones.Funciones
        If TxtNumMaquina.Text = "" Then
            MessageBox.Show("Ingrese el Número de Pc necesario para la numeración de facturas", "POSEXPRESS")
            TxtNumMaquina.Focus()
            Exit Sub
        End If

        '#######################################################################
        'Preguntamos si existe para saber si es una actualizacion o insercion

        Dim existe As Integer
        existe = w.FuncionConsulta("IP", "PC", "IP", IPTextBox.Text)

        Dim transaction As SqlTransaction = Nothing

        If existe > 0 Then
            '###################################################################
            'ACTUALIZAR: si existe el codigo actualiza
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaPC()
                myTrans.Commit()

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

                '############################################# - AUDITORIA TABLAS - ##########################################
                Dim c As New Funciones.Funciones
                Dim codigoaudi As Integer = c.Maximo("CODIGO", "auditoriatablas")
                If codigoaudi = 0 Then
                    codigoaudi = 1
                Else
                    codigoaudi = codigoaudi + 1
                End If

                Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "PC", codigoaudi.ToString, "MODIFICACION DE PC", _
                                                     Today(), UsuDescripcion, UsuNivel, 0, 1, 0)

                '###############################################################################################################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "POSEXPRESS")

            Finally
                sqlc.Close()

            End Try

        Else
            '############################################################################
            'INSERTAR: si el codigo es nuevo inserta
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaPC()
                myTrans.Commit()

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

                '############################################# - AUDITORIA TABLAS - ##########################################
                Dim c As New Funciones.Funciones
                Dim codigoaudi As Integer = c.Maximo("CODIGO", "auditoriatablas")
                If codigoaudi = 0 Then
                    codigoaudi = 1
                Else
                    codigoaudi = codigoaudi + 1
                End If

                Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "PC", codigoaudi.ToString, "INSERCIÓN DE PC", _
                                                     Today(), UsuDescripcion, UsuNivel, 1, 0, 0)

                '###############################################################################################################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error al insertar el registro ", "POSEXPRESS")
                ' MsgBox("Ocurrió un error al insertar el Cliente" + ex.Message, MsgBoxStyle.Exclamation)
            Finally
                sqlc.Close()
            End Try

        End If
        Dim i As Integer = PCBindingSource.Position()
        Me.PCTableAdapter.Fill(Me.DsSettings.PC, "%", "%", "%")
        'HABILITAMOS
        habilitacontroles()
        recorremaquinaservidorcliente()
    End Sub

    Private Sub GuardarSucursal()
        Dim w As New Funciones.Funciones

        If FACTURARCheckBox.Checked = True Then
            If TxtTimbradoSucursal.Text = "" Then
                MessageBox.Show("Ingrese el Número de Sucursal, es necesario para la numeración de facturas", "POSEXPRESS")
                TxtTimbradoSucursal.Focus()
                Exit Sub
            End If
        End If

        If RadComboBoxCiudadSucursal.SelectedValue = Nothing Then
            Codciudad = "NULL"
        Else
            Codciudad = RadComboBoxCiudadSucursal.SelectedValue
        End If
        Dim existe As Integer
        existe = w.FuncionConsulta("CODSUCURSAL", "SUCURSAL", "CODSUCURSAL", CODSUCURSALTextBox.Text)

        Dim transaction As SqlTransaction = Nothing

        If existe > 0 Then
            '###################################################################
            'ACTUALIZAR: si existe el codigo actualiza
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaSucursal()
                myTrans.Commit()

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

                '############################################# - AUDITORIA TABLAS - ##########################################
                Dim c As New Funciones.Funciones
                Dim codigoaudi As Integer = c.Maximo("CODIGO", "auditoriatablas")
                If codigoaudi = 0 Then
                    codigoaudi = 1
                Else
                    codigoaudi = codigoaudi + 1
                End If

                Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "SUCURSAL", codigoaudi.ToString, "MODIFICACION DE SUCURSAL", _
                                                     Today(), UsuDescripcion, UsuNivel, 0, 1, 0)

                '###############################################################################################################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "POSEXPRESS")

            Finally
                sqlc.Close()

            End Try

        Else
            '############################################################################
            'INSERTAR: si el codigo es nuevo inserta
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaSucursal()

                'AUDITORIA
                'InsertaAuditoriaTablas
                myTrans.Commit()
                'RecorreInventario()

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

                '############################################# - AUDITORIA TABLAS - ##########################################
                Dim c As New Funciones.Funciones
                Dim codigoaudi As Integer = c.Maximo("CODIGO", "auditoriatablas")
                If codigoaudi = 0 Then
                    codigoaudi = 1
                Else
                    codigoaudi = codigoaudi + 1
                End If

                Me.AUDITORIATABLASTableAdapter.Insert(codigoaudi, EmpCodigo, "SUCURSAL", codigoaudi.ToString, "INSERCIÓN EN SUCURSAL", _
                                                     Today(), UsuDescripcion, UsuNivel, 1, 0, 0)

                '###############################################################################################################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error al insertar el registro ", "POSEXPRESS")
                ' MsgBox("Ocurrió un error al insertar el Cliente" + ex.Message, MsgBoxStyle.Exclamation)
            Finally
                sqlc.Close()
            End Try

        End If
        Dim i As Integer = SUCURSALBindingSource.Position()
        Me.SUCURSALTableAdapter.Fill(Me.DsSettings.SUCURSAL)

        'HABILITAMOS
        HabilitaControles()
        recorrelocaldeposito()
    End Sub

    Private Sub HabilitaControles()
        PictureBoxNuevoR.Enabled = True
        PictureBoxNuevoR.Image = My.Resources.New_
        PictureBoxNuevoR.Cursor = Cursors.Hand
        PictureBoxEliminarR.Enabled = True
        PictureBoxEliminarR.Image = My.Resources.Delete
        PictureBoxEliminarR.Cursor = Cursors.Hand
        PictureBoxModificaR.Enabled = True
        PictureBoxModificaR.Image = My.Resources.Edit
        PictureBoxModificaR.Cursor = Cursors.Hand

        PictureBoxCancelarR.Enabled = False
        PictureBoxCancelarR.Image = My.Resources.SaveCancelOff
        PictureBoxCancelarR.Cursor = Cursors.Arrow
        PictureBoxGuardarR.Enabled = False
        PictureBoxGuardarR.Image = My.Resources.SaveOff
        PictureBoxGuardarR.Cursor = Cursors.Arrow

        'quita  read only los textos
        TxtDescripcionSucursal.Enabled = False
        RadComboBoxTipoSucursal.Enabled = False
        TxtDireccionSucursal.Enabled = False
        TxtTimbradoSucursal.Enabled = False
        TxtEmailSucursal.Enabled = False
        TxtTelefonoSucursal.Enabled = False
        TxtDescripcionMaquina.Enabled = False
        TxtNumMaquina.Enabled = False
        RadComboBoxTipoMaquina.Enabled = False
        TxtNombreMaquina.Enabled = False
        RadComboBoxCiudadSucursal.Enabled = False

        SUCURSALRadGridView.Enabled = True
        PCRadGridView.Enabled = True
        pnlMaquina.BackColor = Color.DarkGray
        pnlSucursal.BackColor = Color.DarkGray
        Modificar = 2
        cmbCaja.Enabled = False
    End Sub

    Private Sub InsertaPC()
        Dim CodCaja As Integer = 0
        If cmbCaja.Text <> "" Then
            CodCaja = cmbCaja.SelectedValue
        End If

        sql = ""
        sql = "insert into PC (IP,CODUSUARIO,CODEMPRESA,CODSUCURSAL,NOMBRE,DESCRIPCION,FECGRA,TIPOPC,NUMMAQUINA,CODCAJA) values  " & _
            "(" & IPTextBox.Text & "," & UsuCodigo & "," & EmpCodigo & "," & SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value & "," & _
            "'" & TxtNombreMaquina.Text & "','" & TxtDescripcionMaquina.Text & "',GETDATE ()," & _
            "'" & RadComboBoxTipoMaquina.Text & "','" & TxtNumMaquina.Text & "'," & CodCaja & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaSucursal()
        Dim C As Integer
        If FACTURARCheckBox.Checked = True Then
            C = 1
        Else
            C = 0
        End If
        sql = ""
        sql = "insert into SUCURSAL (CODSUCURSAL,CODUSUARIO,CODEMPRESA,EMPRESACODEMPRESA,NUMSUCURSAL,DESSUCURSAL,DIRECCION," & _
        " TELEFONO,FECGRA,SUCURSALTIMBRADO,CODCIUDAD,EMAIL,FACTURAR,TIPOSUCURSAL) values  " & _
        "(" & CODSUCURSALTextBox.Text & "," & UsuCodigo & "," & EmpCodigo & "," & EmpCodigo & "," & CODSUCURSALTextBox.Text & ",  " & _
        "'" & TxtDescripcionSucursal.Text & "','" & TxtDireccionSucursal.Text & "','" & TxtTelefonoSucursal.Text & "', GETDATE(), " & _
        "'" & TxtTimbradoSucursal.Text & "'," & Codciudad & "," & _
        "'" & TxtEmailSucursal.Text & "'," & C & ",'" & RadComboBoxTipoSucursal.Text & "' )"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Nuevo()

        If sucursal = 1 Then
            SUCURSALBindingSource.AddNew()
            DeshabilitarSucursales()
            TxtDescripcionSucursal.Focus()

        ElseIf sucursal = 0 Then
            PCBindingSource.AddNew()
            DeshabilitarMaquinas()
            TxtNombreMaquina.Focus()

        End If
    End Sub

    Private Sub PCRadGridView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PCRadGridView.Click
        sucursal = 0
    End Sub

    Private Sub PictureBoxCancelarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCancelarR.Click
        If sucursal = 1 Then
            SUCURSALBindingSource.CancelEdit()
        ElseIf sucursal = 0 Then
            PCBindingSource.CancelEdit()
        End If
        habilitacontroles()

    End Sub

    Private Sub PictureBoxEliminarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxEliminarR.Click
        permiso = PermisoAplicado(UsuCodigo, 114)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If
        If sucursal = 1 Then
            If MessageBox.Show("Esta seguro que desea eliminar el registro", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                Exit Sub
            Else
                eliminasucursal(SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value)
                Me.SUCURSALTableAdapter.Fill(DsSettings.SUCURSAL)
            End If
            habilitacontroles()
            recorrelocaldeposito()
        ElseIf sucursal = 0 Then

            If MessageBox.Show("Esta seguro que desea eliminar el registro", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                Exit Sub
            Else
                eliminapc(PCRadGridView.CurrentRow.Cells("IP").Value)
                Me.PCTableAdapter.Fill(Me.DsSettings.PC, "%", "%", "%")
            End If
            habilitacontroles()
            recorremaquinaservidorcliente()

        End If
        Modificar = 2

    End Sub

    Private Sub PictureBoxGuardarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxGuardarR.Click
        If sucursal = 1 Then
            GuardarSucursal()
        ElseIf sucursal = 0 Then
            GuardarPc()
        End If
    End Sub

    Private Sub PictureBoxImprimirR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pri = 0 Then
            MessageBox.Show("No tiene permiso para imprimir", "POSEXPRESS")
            Exit Sub
        End If
    End Sub

    Private Sub PictureBoxModificaR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxModificaR.Click
        permiso = PermisoAplicado(UsuCodigo, 115)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar en esta ventana", "Pos Express")
            Exit Sub
        End If
        If sucursal = 1 Then
            DeshabilitarSucursales()
        ElseIf sucursal = 0 Then
            Dim CantPc As Integer = f.CantidadRegistro("IP", "PC")
            If CantPc <> 0 Then
                DeshabilitarMaquinas()
            Else
                Exit Sub
            End If
        End If
        Modificar = 1

    End Sub

    Private Sub PictureBoxNuevoR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxNuevoR.Click
        permiso = PermisoAplicado(UsuCodigo, 117)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        Nuevo()
        Modificar = 0
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As String = TxtTelefonoSucursal.Text
    End Sub

    Private Sub recorrelocaldeposito()
        Dim w As New Funciones.Funciones

        Dim c As Integer = SUCURSALRadGridView.RowCount

        For c = 1 To c
            'Sucursal
            If IsDBNull(SUCURSALRadGridView.Rows(c - 1).Cells("TIPOSUCURSAL").Value) Then
            Else
                If SUCURSALRadGridView.Rows(c - 1).Cells("TIPOSUCURSAL").Value = "Solo Factura" Then
                    SUCURSALRadGridView.Rows(c - 1).Cells("LOCALDEPOSITO").Value = "(F)"
                ElseIf SUCURSALRadGridView.Rows(c - 1).Cells("TIPOSUCURSAL").Value = "Solo Stock" Then
                    SUCURSALRadGridView.Rows(c - 1).Cells("LOCALDEPOSITO").Value = "(S)"
                ElseIf SUCURSALRadGridView.Rows(c - 1).Cells("TIPOSUCURSAL").Value = "Factura y Stock" Then
                    SUCURSALRadGridView.Rows(c - 1).Cells("LOCALDEPOSITO").Value = "(FS)"
                End If
            End If
        Next

        If SUCURSALRadGridView.RowCount <> 0 Then
            RadComboBoxTipoSucursal.Text = f.FuncionConsultaString("TIPOSUCURSAL", "SUCURSAL", "CODSUCURSAL", SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value)
            CAJATableAdapter.Fill(DsSettings.CAJA, SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value)
            PCBindingSource.Filter = "CODSUCURSAL = " & SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value
        End If
    End Sub

    Private Sub recorremaquinaservidorcliente()
        Dim w As New Funciones.Funciones
        Dim c As Integer = PCRadGridView.RowCount
        For c = 1 To c
            'Pc
            If IsDBNull(PCRadGridView.Rows(c - 1).Cells("TIPOPC").Value) Then
            Else
                If PCRadGridView.Rows(c - 1).Cells("TIPOPC").Value = "CLIENTE" Then
                    PCRadGridView.Rows(c - 1).Cells("CLIENTESERVIDOR").Value = "(C)"
                ElseIf PCRadGridView.Rows(c - 1).Cells("TIPOPC").Value = "SERVIDOR" Then
                    PCRadGridView.Rows(c - 1).Cells("CLIENTESERVIDOR").Value = "(S)"
                End If
            End If
        Next
    End Sub

    Private Sub Sucursales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 113)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If

        Me.AUDITORIATABLASTableAdapter.Fill(Me.DsSettings.AUDITORIATABLAS, "%", "%", "%", "%")
        Me.CIUDADTableAdapter.Fill(Me.DsSettings.CIUDAD)
        Me.SUCURSALTableAdapter.Fill(Me.DsSettings.SUCURSAL)

        recorrelocaldeposito()
        Me.PCTableAdapter.Fill(DsSettings.PC, "%", "%", "%")
        recorremaquinaservidorcliente()
        sucursal = 1
        Modificar = 2
        HabilitaControles()

        'Para mostrar el tipo
        If SUCURSALRadGridView.RowCount <> 0 Then
            RadComboBoxTipoSucursal.Text = f.FuncionConsultaString("TIPOSUCURSAL", "SUCURSAL", "CODSUCURSAL", SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value)
        End If
    End Sub

    Private Sub TxtDescripcionSucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FACTURARCheckBox.KeyPress, RadComboBoxCiudadSucursal.KeyPress, TxtTelefonoSucursal.KeyPress, RadComboBoxTipoMaquina.KeyPress, RadComboBoxTipoSucursal.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
    End Sub

    Private Sub TxtNumMaquina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtNumMaquina.Text = Funciones.Cadenas.SoloNumeros(TxtNumMaquina.Text)
    End Sub

    Private Sub TxtNumMaquina_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If TxtNumMaquina.Text.Count = 1 Then
            TxtNumMaquina.Text = "0" + "0" + TxtNumMaquina.Text
        ElseIf TxtNumMaquina.Text.Count = 2 Then
            TxtNumMaquina.Text = "0" + TxtNumMaquina.Text
        End If
        Dim w As New Funciones.Funciones
        Dim existe As Integer
        existe = w.FuncionConsulta("IP", "PC", "CODEMPRESA=" & EmpCodigo & " and NUMMAQUINA='" & TxtNumMaquina.Text & "' AND  CODSUCURSAL", SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value)
        If Modificar = 0 Then
            If existe > 0 Then
                MessageBox.Show("El numero de maquina  ya fue asignado para la sucursal : " + SUCURSALRadGridView.CurrentRow.Cells("DESSUCURSAL").Value, "POSEXPRESS")
                TxtNumMaquina.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TxtTimbradoSucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtTimbradoSucursal.Text = Funciones.Cadenas.SoloNumeros(TxtTimbradoSucursal.Text)
    End Sub

    Private Sub TxtTimbradoSucursal_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If TxtTimbradoSucursal.Text.Count = 1 Then
            TxtTimbradoSucursal.Text = "0" + "0" + TxtTimbradoSucursal.Text
        ElseIf TxtTimbradoSucursal.Text.Count = 2 Then
            TxtTimbradoSucursal.Text = "0" + TxtTimbradoSucursal.Text
        End If
        Dim w As New Funciones.Funciones
        Dim existe As Integer
        existe = w.FuncionConsulta("CODSUCURSAL", "SUCURSAL", "CODEMPRESA=" & EmpCodigo & "  AND SUCURSALTIMBRADO", TxtTimbradoSucursal.Text)
        If Modificar = 0 Then
            If existe > 0 Then
                MessageBox.Show("El numero de sucursal ya fue asignado para la empresa : " + EmpDescripcion, "POSEXPRESS")
                TxtTimbradoSucursal.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TxtDescripcionMaquina_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcionMaquina.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
    End Sub

    Private Sub SUCURSALRadGridView_Click(sender As System.Object, e As System.EventArgs) Handles SUCURSALRadGridView.Click
        sucursal = 1
        'Para mostrar el tipo

        If SUCURSALRadGridView.RowCount <> 0 Then
            RadComboBoxTipoSucursal.Text = f.FuncionConsultaString("TIPOSUCURSAL", "SUCURSAL", "CODSUCURSAL", SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value)
            CAJATableAdapter.Fill(DsSettings.CAJA, SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value)
            PCBindingSource.Filter = "CODSUCURSAL = " & SUCURSALRadGridView.CurrentRow.Cells("CODSUCURSAL").Value
        End If
    End Sub
#End Region  'Methods
End Class