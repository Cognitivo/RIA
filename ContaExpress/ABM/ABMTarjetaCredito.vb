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

Public Class ABMTarjetaCredito

    #Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand

    '################################################
    'Variable para actualizar e insertar el Movimiento
    '################################################
    Dim CodTarjeta, CodUsuario, CodEmpresa As Integer
    Dim del As Integer

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim FecGra As Date
    Dim filename As String
    Dim ins As Integer
    Private myTrans As SqlTransaction
    Dim NumTipoTarje, DesTarjeta As String
    Dim pri As Integer
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Dim permiso As Double
    '###############################################
    'Variables de conexion usadas en la transaccion
    '###############################################
    Private sqlc As SqlConnection
    Dim upd As Integer

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

    Private Sub ABMTarjetaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 95)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para Abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

        Me.TIPOTARJETATableAdapter.Fill(Me.DsSettingFO.TIPOTARJETA)


        DeshabilitaControles()
        AsignarValores()
        Windows.Forms.Application.DoEvents()
        
    End Sub

    Private Sub ActualizaTarjeta()
        '",[CODPLANCUENTA] = " & CodPlanCuenta & _
        sql = ""
        sql = "UPDATE [TIPOTARJETA] " & _
        "SET [CODTARJETA] =  " & CodTarjeta & _
        ",[CODUSUARIO] =  " & CodUsuario & _
        ",[CODEMPRESA] =  " & CodEmpresa & _
        ",[NUMTIPOTARJE] =  '" & NumTipoTarje & _
        "',[DESTARJETA] =  '" & DesTarjeta & _
        "',[FECGRA] =  " & "convert(datetime,GETDATE(), 103)" & _
        " WHERE [CODTARJETA] =  " & CodTarjeta & ""

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


    Private Sub DeshabilitaControles()

        pbxNuevaFicha.Image = My.Resources.New_
        pbxNuevaFicha.Cursor = Cursors.Hand
        pbxNuevaFicha.Enabled = True
        pbxEliminarFicha.Image = My.Resources.Delete
        pbxEliminarFicha.Cursor = Cursors.Hand
        pbxEliminarFicha.Enabled = True
        pbxModificarFicha.Image = My.Resources.Edit
        pbxEliminarFicha.Cursor = Cursors.Hand
        pbxEliminarFicha.Enabled = True

        pbxGuardar.Image = My.Resources.SaveOff
        pbxEliminarFicha.Cursor = Cursors.Arrow
        pbxEliminarFicha.Enabled = False
        pbxCancelar.Image = My.Resources.SaveCancelOff
        pbxEliminarFicha.Cursor = Cursors.Arrow
        pbxEliminarFicha.Enabled = False

        txtDesTarjeta.Enabled = False
        grdBuscador.Enabled = True
        txtBuscar.Enabled = True
    End Sub

    'Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
    '    ELIMINAR()
    'End Sub
    Private Sub ELIMINAR()
        'Me.pbxAbierto.Visible = False
        'Me.pbxCerrado.Visible = True

        If MessageBox.Show("¿Esta seguro que quiere eliminar la Tarjeta de Crédito?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = funcion.FuncionConsulta("CODTARJETA", "TIPOTARJETA", "CODTARJETA", Me.txtCodTarjeta.Text)
        If existe <> 0 Then
            Dim transaction As SqlTransaction = Nothing
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                EliminaTarjeta()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "TIPOTARJETA", CStr(CodTarjeta), "ELIMINACIÓN EN LA TABLA TIPO DE TARJETA", _
                Today, UsuDescripcion, "NULL", 0, 0, 1)

                myTrans.Commit()

                MessageBox.Show("Tarjeta de Crédito eliminada correctamente", "POSEXPRESS")
                DeshabilitaControles()
                TIPOTARJETATableAdapter.Fill(DsSettingFO.TIPOTARJETA)

            Catch ex As Exception
                Try
                    myTrans.Rollback("")
                Catch
                End Try
                MessageBox.Show("Ocurrio un error el eliminar la Tarjeta de Crédito" + ex.Message, "POSEXPRESS")
            Finally
                sqlc.Close()
            End Try

            DeshabilitaControles()
        End If
    End Sub

    Private Sub EliminaTarjeta()
        sql = ""
        sql = " DELETE FROM TIPOTARJETA " & _
        " WHERE CODTARJETA = '" & Me.txtCodTarjeta.Text & "'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub HabilitaControles()
     
        pbxNuevaFicha.Image = My.Resources.NewOff
        pbxNuevaFicha.Cursor = Cursors.Arrow
        pbxNuevaFicha.Enabled = False
        pbxEliminarFicha.Image = My.Resources.DeleteOff
        pbxEliminarFicha.Cursor = Cursors.Arrow
        pbxEliminarFicha.Enabled = False
        pbxModificarFicha.Image = My.Resources.EditOff
        pbxEliminarFicha.Cursor = Cursors.Arrow
        pbxEliminarFicha.Enabled = False

        pbxGuardar.Image = My.Resources.Save
        pbxEliminarFicha.Cursor = Cursors.Hand
        pbxEliminarFicha.Enabled = True
        pbxCancelar.Image = My.Resources.SaveCancel
        pbxEliminarFicha.Cursor = Cursors.Hand
        pbxEliminarFicha.Enabled = True

        txtDesTarjeta.Enabled = True
        grdBuscador.Enabled = False
        txtBuscar.Enabled = False

    End Sub

    Private Sub InsertaTarjeta()
        '",[CODPLANCUENTA] " & _
        sql = ""
        sql = "INSERT INTO [TIPOTARJETA] " & _
        "([CODTARJETA] " & _
        ",[CODUSUARIO] " & _
        ",[CODEMPRESA] " & _
        ",[NUMTIPOTARJE] " & _
        ",[DESTARJETA] " & _
        ",[FECGRA]) " & _
        " VALUES(" & _
        CodTarjeta & _
        ", " & CodUsuario & _
        ", " & CodEmpresa & _
        ", '" & NumTipoTarje & _
        "', '" & DesTarjeta & _
        "', " & "convert(datetime, GETDATE(), 103)" & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    'Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
    '    NUEVO()
    'End Sub
    Private Sub NUEVO()
        Dim funcion As New Funciones.Funciones
        HabilitaControles()
        TIPOTARJETABindingSource.AddNew()
        txtDesTarjeta.Focus()
    End Sub

    Private Sub pbxEliminarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEliminarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 97)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para ELIMINAR", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ELIMINAR()
    End Sub


    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxGuardar.Click
        '###########################################
        'Se validan los campos que no admiten nulos
        '###########################################
        CodTarjeta = CInt(txtCodTarjeta.Text)
        NumTipoTarje = CStr(txtCodTarjeta.Text)

        If txtDesTarjeta.Text = "" Then
            MessageBox.Show("Descripción de Tarjeta de Crédito es obligatorio, por favor introduzca ese dato", "POSEXPRESS")
            txtDesTarjeta.Focus()
            Exit Sub
        Else
            DesTarjeta = txtDesTarjeta.Text
        End If

        FecGra = Today

        'Si quiere guardar con algun detalle incompleto
        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = funcion.FuncionConsulta("CODTARJETA", "TIPOTARJETA", "CODTARJETA", Me.txtCodTarjeta.Text)

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
                ActualizaTarjeta()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "TIPOTARJETA", CStr(CodTarjeta), "MODIFICACIÓN EN LA TABLA TIPO TARJETA", _
                Today, UsuDescripcion, "NULL", 0, 1, 0)

                myTrans.Commit()
                DeshabilitaControles()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try

                MessageBox.Show("Error al Guardar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                InsertaTarjeta()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "TIPOTARJETA", CStr(CodTarjeta), "INSERCIÓN EN LA TABLA TIPO DE TARJETA", _
                Today, UsuDescripcion, "NULL", 1, 0, 0)

                myTrans.Commit()

            Catch ex As Exception
                myTrans.Rollback("Insertar")

                MessageBox.Show("Error al Guardar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                sqlc.Close()
            End Try

        End If

        Try
            Me.TIPOTARJETATableAdapter.Fill(Me.DsSettingFO.TIPOTARJETA)
        Catch ex As Exception
        End Try

        DeshabilitaControles()
    End Sub

    Private Sub pbxModificarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxModificarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 98)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para MODIFICAR", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        HabilitaControles()
        pbxModificarFicha.Image = My.Resources.EditActive
    End Sub

    Private Sub pbxNuevaFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxNuevaFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 96)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear una Tarjeta", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        NUEVO()

        pbxNuevaFicha.Image = My.Resources.NewActive
    End Sub

    Private Sub txtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        txtBuscar.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtBuscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.LostFocus
        txtBuscar.BackColor = Color.Gainsboro
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "Buscar..." Then
        Else
            Dim Filtro As New FilterExpression()
            Filtro.Predicates.Add(FilterExpression.BinaryOperation.[OR], GridKnownFunction.Contains, GridFilterCellElement.ParameterName)
            Filtro.Parameters.Add(GridFilterCellElement.ParameterName, txtBuscar.Text)
            Me.grdBuscador.Columns("DESTARJETA").Filter = Filtro
        End If
    End Sub

    Private Sub txtDesTarjeta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDesTarjeta.GotFocus
        txtDesTarjeta.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtDesTarjeta_LostFocus(sender As Object, e As System.EventArgs) Handles txtDesTarjeta.LostFocus
        txtDesTarjeta.BackColor = Color.Gainsboro
    End Sub

    #End Region 'Methods

    Private Sub pbxCancelar_Click(sender As System.Object, e As System.EventArgs) Handles pbxCancelar.Click
        TIPOTARJETABindingSource.CancelEdit()
        Me.TIPOTARJETATableAdapter.Fill(Me.DsSettingFO.TIPOTARJETA)
        DeshabilitaControles()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class