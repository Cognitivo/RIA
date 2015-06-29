Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class ABMUnidadMedida

    #Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand

    '################################################
    'Variable para actualizar e insertar el Movimiento
    '################################################
    Dim CodMedida, CodUsuario, CodEmpresa As Integer
    Dim del As Integer

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim FecGra As Date
    Dim filename As String
    Dim ins As Integer
    Private myTrans As SqlTransaction
    Dim NumMedida, DesMedida, Simbolo As String
    Dim pri As Integer
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String

    '###############################################
    'Variables de conexion usadas en la transaccion
    '###############################################
    Private sqlc As SqlConnection
    Dim upd As Integer
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

    'PERMITE UTILIZAR LAS TECLAS DE FUNCION PARA REALIZAR LOS PROCEDIMIENTOS
    Private Sub ABMUnidadMedida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode()
            Case Keys.F2
            Case Keys.F3
            Case Keys.F4
            Case Keys.F5
                NUEVO()
            Case Keys.F6
                MODIFICAR()
            Case Keys.F7
                GUARDAR()
            Case Keys.F8
                ELIMINAR()
            Case Keys.F9
                Close()
            Case Keys.F10
            Case Keys.F12
            Case Keys.Escape
                CANCELAR()
        End Select
    End Sub

    Private Sub ABMUnidadMedida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 74)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If
        Try
            Me.UNIDADMEDIDATableAdapter.Fill(Me.DsSettingFO.UNIDADMEDIDA)
        Catch ex As Exception

        End Try

        DeshabilitaControles()
        AsignarValores()
        
    End Sub

    Private Sub ActualizaUnidadMedida()
        sql = ""
        sql = "UPDATE [UNIDADMEDIDA] " & _
        "SET [CODUSUARIO] =  " & CodUsuario & _
        ",[CODEMPRESA] =  " & CodEmpresa & _
        ",[DESMEDIDA] =  '" & DesMedida & _
        "',[SIMBOLO] =  '" & Simbolo & _
        "',[FECGRA] =  " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & _
        " WHERE [CODMEDIDA] =  " & CodMedida & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AsignarValores()
        If IsDBNull(UsuCodigo) Or UsuCodigo = 0 Then
            CodUsuario = 1
            'CodVendedor = 1
            CodCobrador = 1
            'UsuGra = 1
        Else
            CodUsuario = UsuCodigo
            'CodVendedor = UsuCodigo
            CodCobrador = UsuCodigo
            'UsuGra = UsuCodigo
        End If

        If IsDBNull(EmpCodigo) Or EmpCodigo = 0 Then
            CodEmpresa = 1
        Else
            CodEmpresa = EmpCodigo
        End If

        If IsDBNull(SucCodigo) Or SucCodigo = 0 Then
            'CodSucursal = 1
        Else
            'CodSucursal = EmpCodigo
        End If
    End Sub

    'Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
    '    CANCELAR()
    'End Sub
    Private Sub CANCELAR()
        'Me.pbxAbierto.Visible = False
        'Me.pbxCerrado.Visible = True
        UNIDADMEDIDABindingSource.CancelEdit()
        Me.UNIDADMEDIDATableAdapter.Fill(Me.DsSettingFO.UNIDADMEDIDA)
        DeshabilitaControles()
    End Sub

    Private Sub DeshabilitaControles()
        txtDesMedida.Enabled = False
        txtSimbolo.Enabled = False

        Panel1.BringToFront()
        Panel2.SendToBack()

        grdBuscador.Enabled = True
        txtBuscar.Enabled = True

        'Botonera
        pbxNuevaFicha.Image = My.Resources.New_
        pbxNuevaFicha.Enabled = True
        pbxNuevaFicha.Cursor = Cursors.Hand
        pbxEliminarFicha.Image = My.Resources.Delete
        pbxEliminarFicha.Enabled = True
        pbxEliminarFicha.Cursor = Cursors.Hand
        pbxModificarFicha.Image = My.Resources.Edit
        pbxModificarFicha.Enabled = True
        pbxModificarFicha.Cursor = Cursors.Hand

        pbxCancelar.Enabled = False
        pbxCancelar.Image = My.Resources.SaveCancelOff
        pbxCancelar.Cursor = Cursors.Arrow
        pbxGuardar.Enabled = False
        pbxGuardar.Image = My.Resources.SaveOff
        pbxGuardar.Cursor = Cursors.Arrow
    End Sub

    Private Sub EliminaEmpresa()
        sql = ""
        sql = " DELETE FROM UNIDADMEDIDA " & _
        " WHERE CODMEDIDA = '" & Me.txtCodMedida.Text & "'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    'Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
    '    ELIMINAR()
    'End Sub
    Private Sub ELIMINAR()
       
        If MessageBox.Show("¿Esta seguro que quiere eliminar la Unidad de Medida?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = funcion.FuncionConsulta("CODMEDIDA", "UNIDADMEDIDA", "CODMEDIDA", Me.txtCodMedida.Text)
        If existe <> 0 Then
            Dim transaction As SqlTransaction = Nothing
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                EliminaEmpresa()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "UNIDADMEDIDA", CStr(CodMedida), "ELIMINACIÓN EN LA TABLA UNIDAD DE MEDIDA", _
                Today, UsuDescripcion, "NULL", 0, 0, 1)

                myTrans.Commit()

                MessageBox.Show("Unidad de Medida eliminada correctamente", "POSEXPRESS")
                DeshabilitaControles()
                UNIDADMEDIDATableAdapter.Fill(DsSettingFO.UNIDADMEDIDA)

            Catch ex As Exception
                Try
                    myTrans.Rollback("")
                Catch
                End Try
                MessageBox.Show("Ocurrio un error el eliminar la Unidad de Medida" + ex.Message, "POSEXPRESS")
            Finally
                sqlc.Close()
            End Try

            DeshabilitaControles()
        End If
    End Sub

    'Private Sub btnGruardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
    '    GUARDAR()
    'End Sub
    Private Sub GUARDAR()
        'Me.pbxAbierto.Visible = False
        'Me.pbxCerrado.Visible = True

        '###########################################
        'Se validan los campos que no admiten nulos
        '###########################################
        CodMedida = CInt(txtCodMedida.Text)
        NumMedida = CStr(txtCodMedida.Text)

        If txtDesMedida.Text = "" Then
            MessageBox.Show("Descripción de la Unidad de Medida es obligatorio, por favor introduzca ese dato", "POSEXPRESS")
            txtDesMedida.Focus()
            Exit Sub
        Else
            DesMedida = txtDesMedida.Text
        End If

        Simbolo = txtSimbolo.Text

        'Si quiere guardar con algun detalle incompleto
        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = funcion.FuncionConsulta("CODMEDIDA", "UNIDADMEDIDA", "CODMEDIDA", Me.txtCodMedida.Text)

        Dim transaction As SqlTransaction = Nothing

        If existe > 0 Then
            '#####################################################
            'ACTUALIZAR: si existe el codigo de cliente actualiza
            '#####################################################
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaUnidadMedida()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "UNIDADMEDIDA", CStr(CodMedida), "MODIFICACION EN LA TABLA UNIDAD DE MEDIDA", _
                Today, UsuDescripcion, "NULL", 0, 1, 0)

                myTrans.Commit()
                MessageBox.Show("El proceso de grabación ha finalizado correctamente", _
                                                       "POSEXPRESS")
                DeshabilitaControles()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try

                MessageBox.Show("Ocurrio un error al intentar actualizar la Unidad de Medida", _
                                                      "POSEXPRESS")
            Finally
                sqlc.Close()

            End Try
        Else
            '########################################
            'INSERTAR: si el codigo es nuevo inserta
            '########################################
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaUnidadMedida()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "UNIDADMEDIDA", CStr(CodMedida), "INSERCIÓN EN LA TABLA UNIDAD DE MEDIDA", _
                Today, UsuDescripcion, "NULL", 1, 0, 0)

                myTrans.Commit()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", _
                                                       "POSSExpress")
            Catch ex As Exception
                myTrans.Rollback("Insertar")

                MessageBox.Show("Ocurrió un error al insertar la Unidad de Medida", _
                                                       "POSSExpress")
            Finally
                sqlc.Close()
            End Try

        End If
        Try
            Me.UNIDADMEDIDATableAdapter.Fill(Me.DsSettingFO.UNIDADMEDIDA)
        Catch ex As Exception

        End Try

        DeshabilitaControles()
    End Sub

    Private Sub HabilitaControles()
        txtDesMedida.Enabled = True
        txtSimbolo.Enabled = True

        Panel1.SendToBack()
        Panel2.BringToFront()

        grdBuscador.Enabled = False
        txtBuscar.Enabled = False

        'Botonera
        pbxNuevaFicha.Image = My.Resources.NewOff
        pbxNuevaFicha.Enabled = False
        pbxNuevaFicha.Cursor = Cursors.Arrow
        pbxEliminarFicha.Enabled = False
        pbxEliminarFicha.Image = My.Resources.DeleteOff
        pbxEliminarFicha.Cursor = Cursors.Arrow
        pbxModificarFicha.Enabled = False
        pbxModificarFicha.Image = My.Resources.EditOff
        pbxModificarFicha.Cursor = Cursors.Arrow

        pbxCancelar.Enabled = True
        pbxCancelar.Image = My.Resources.SaveCancel
        pbxCancelar.Cursor = Cursors.Hand
        pbxGuardar.Enabled = True
        pbxGuardar.Image = My.Resources.Save
        pbxGuardar.Cursor = Cursors.Hand
    End Sub

    Private Sub InsertaUnidadMedida()
        sql = ""
        sql = "INSERT INTO [UNIDADMEDIDA] " & _
        "([CODMEDIDA] " & _
        ",[CODUSUARIO] " & _
        ",[CODEMPRESA] " & _
        ",[NUMMEDIDA] " & _
        ",[DESMEDIDA] " & _
        ",[SIMBOLO] " & _
        ",[FECGRA]) " & _
        " VALUES(" & _
        CodMedida & _
        ", " & CodUsuario & _
        ", " & CodEmpresa & _
        ", '" & NumMedida & _
        "', '" & DesMedida & _
        "', '" & Simbolo & _
        "', " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub LimpiarControles()
    End Sub

    'Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
    '    MODIFICAR()
    'End Sub
    Private Sub MODIFICAR()
        'Me.pbxCerrado.Visible = False
        'Me.pbxAbierto.Visible = True
        HabilitaControles()
    End Sub

    'Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
    '    NUEVO()
    'End Sub
    Private Sub NUEVO()
        Dim funcion As New Funciones.Funciones
        'Me.pbxCerrado.Visible = False
        'Me.pbxAbierto.Visible = True

        HabilitaControles()
        LimpiarControles()
        UNIDADMEDIDABindingSource.AddNew()
        'Me.txtCodigoComenta.Text = funcion.Maximo("CODCOMENTA", "COMENTAPRODUCTOS") + 1
        txtDesMedida.Focus()
    End Sub

    Private Sub pbxCancelarGris_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxCancelarGris_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCancelar.Click
        CANCELAR()

    End Sub

    Private Sub pbxEliminarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEliminarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 76)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para ELIMINAR", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ELIMINAR()
      
    End Sub
    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxGuardar.Click
        GUARDAR()
    End Sub

    Private Sub pbxModificarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxModificarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 78)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar en esta ventana", "Pos Express")
            Exit Sub
        End If
        MODIFICAR()
        pbxModificarFicha.Image = My.Resources.EditActive
    End Sub

    Private Sub pbxNuevaFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxNuevaFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 75)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        NUEVO()
        pbxNuevaFicha.Image = My.Resources.NewActive
    End Sub

    Private Sub txtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus

        txtBuscar.BackColor = Color.LightSteelBlue

    End Sub

    Private Sub txtBuscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.LostFocus
        txtBuscar.BackColor = Color.Gray
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "Buscar..." Then
        Else
            Dim Filtro As New FilterExpression()
            Filtro.Predicates.Add(FilterExpression.BinaryOperation.[OR], GridKnownFunction.Contains, GridFilterCellElement.ParameterName)
            Filtro.Parameters.Add(GridFilterCellElement.ParameterName, txtBuscar.Text)
            Me.grdBuscador.Columns("DESMEDIDA").Filter = Filtro
        End If
    End Sub

    Private Sub txtDesMedida_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDesMedida.GotFocus
        txtDesMedida.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtSimbolo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSimbolo.GotFocus
        txtSimbolo.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtSimbolo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSimbolo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        'Si es una tecla válida
        If KeyAscii = 13 Then
            'Enter
            GUARDAR()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSimbolo_LostFocus(sender As Object, e As System.EventArgs) Handles txtSimbolo.LostFocus
        txtSimbolo.BackColor = Color.Gainsboro
    End Sub

    Private Sub txtSimbolo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSimbolo.TextChanged
    End Sub

    #End Region 'Methods

    #Region "Other"

    '#######################################################################################################################

    #End Region 'Other

    Private Sub txtDesMedida_LostFocus(sender As Object, e As System.EventArgs) Handles txtDesMedida.LostFocus
        txtDesMedida.BackColor = Color.Gainsboro
    End Sub
End Class