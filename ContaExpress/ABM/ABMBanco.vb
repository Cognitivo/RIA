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

Public Class ABMBanco

#Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand

    'INSTRUMENTO
    Dim CodInstrumento As Integer

    '################################################
    'Variable para actualizar e insertar el Movimiento
    '################################################
    Dim CodUsuario, CodEmpresa, CodMoneda, CodBanco, CodTipoCuenta As String 'Corregido x cesar, no podes ser tannn peluchinnnn........

    '#######################################################################################################################
    Dim Ctrl, N, G, T, D As Boolean
    Dim del As Integer
    Dim DescripcionInstrumento, TipoInstrumento, Status, Usuario, Firma, Clave As String

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim FecGra As Date
    Dim FechaApertura As Date
    Dim filename As String
    Dim ins As Integer
    Dim LimiteCredito, Interes As String
    Private myTrans As SqlTransaction

    'BANCO
    Dim NumBanco, DesBanco, Sucursal, Direccion, Agente, Telefono, Email As String
    Dim NumCuenta, DescripcionCuenta As String
    Dim pri As Integer
    Dim sel As Integer
    Private ser As BDConexión.BDConexion

    'CUENTA
    Dim Sobregiro As Integer
    Dim sql As String

    '###############################################
    'Variables de conexion usadas en la transaccion
    '###############################################
    Private sqlc As SqlConnection
    Dim upd As Integer

    'VARIABLES PARA ABM
    Dim varBANCO As Integer = 0
    Dim varCUENTA As Integer
    Dim varINSTRUMENTO As Integer = 0
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

    Private Sub ABMBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 61)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express")
            Me.Close()
        End If

        Me.AUDITORIATABLASTableAdapter.Fill(Me.DsFacturacion.AUDITORIATABLAS)
        Try
            Me.MONEDASINFILTROTableAdapter.Fill(Me.DsFacturacion.MONEDASINFILTRO)
        Catch ex As Exception

        End Try
        Try
            Me.TIPOCUENTATableAdapter.Fill(Me.DsFacturacion.TIPOCUENTA)
        Catch ex As Exception

        End Try
        Try
            Me.VENTASFORMACOBROTableAdapter.Fill(Me.DsFacturacion.VENTASFORMACOBRO)
        Catch ex As Exception

        End Try
        Try
            Me.INSTRUMENTOTableAdapter.Fill(Me.DsFacturacion.INSTRUMENTO)
        Catch ex As Exception

        End Try

        Try
            Me.CUENTABANCARIATableAdapter.Fill(Me.DsFacturacion.CUENTABANCARIA)
        Catch ex As Exception

        End Try

        Try
            Me.BANCOTableAdapter.Fill(Me.DsFacturacion.BANCO)
        Catch ex As Exception

        End Try

        'tabLocalidades.SelectedTab = tabPais
        DeshabilitaControles()
        AsignarValores()

        Windows.Forms.Application.DoEvents()
        HabilitaPanel()
        lb_mensaje.Visible = True
    End Sub

    'PERMITE UTILIZAR LAS TECLAS DE FUNCION PARA REALIZAR LOS PROCEDIMIENTOS
    Private Sub ABMPais_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Select Case e.KeyCode()
        '    Case Keys.F2
        '    Case Keys.F3
        '    Case Keys.F4
        '    Case Keys.F5
        '        NUEVO()
        '    Case Keys.F6
        '        MODIFICAR()
        '    Case Keys.F7
        '        GUARDAR()
        '    Case Keys.F8
        '        ELIMINAR()
        '    Case Keys.F9
        '        Close()
        '    Case Keys.F10
        '    Case Keys.F12
        '    Case Keys.Escape
        '        CANCELAR()

        'End Select
        If e.KeyValue = 17 Then Ctrl = True
        If e.KeyValue = 78 Then N = True
        If e.KeyValue = 84 Then T = True
        If e.KeyValue = 71 Then G = True
        If Ctrl And N Then
            NUEVO()
            Ctrl = False
            N = False
        ElseIf Ctrl And T Then
            MODIFICAR()
            Ctrl = False
            T = False
        ElseIf Ctrl And G Then
            GUARDAR()
            Ctrl = False
            G = False
        ElseIf e.KeyCode = Keys.Delete Then
            ELIMINAR()
        ElseIf e.KeyCode = Keys.Escape Then
            CANCELAR()
        End If
    End Sub

    Private Sub ActualizaDatos()
        sql = ""
        If varBANCO = 1 Then
            sql = "UPDATE [BANCO] " & _
            "SET [CODUSUARIO] = " & CodUsuario & _
            ",[CODEMPRESA] = " & CodEmpresa & _
            ",[NUMBANCO] = '" & NumBanco & _
            "',[DESBANCO] = '" & DesBanco & _
            "',[SUCURSAL] = '" & Sucursal & _
            "',[DIRECCION] = '" & Direccion & _
            "',[AGENTE] = '" & Agente & _
            "',[TELEFONO] = '" & Telefono & _
            "',[EMAIL] = '" & Email & _
            "',[FECGRA] = " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & _
            " WHERE [CODBANCO] =  " & CodBanco & ""
        ElseIf varCUENTA = 1 Then
            sql = "UPDATE [CUENTABANCARIA] " & _
            "SET [CODTIPOCUENTA] = " & CodTipoCuenta & _
            ",[CODUSUARIO] = " & CodUsuario & _
            ",[CODEMPRESA] = " & CodEmpresa & _
            ",[CODMONEDA] = " & CodMoneda & _
            ",[CODBANCO] = " & CodBanco & _
            ",[DESCRIPCION] = '" & DescripcionCuenta & _
            "',[FECHAAPERTURA] = " & "convert(datetime, '" & FechaApertura & " 0:00:00', 103)" & _
            ",[LIMITECREDITO] = " & LimiteCredito & _
            ",[FECGRA] =  " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & _
            ",[SOBREGIRO] = " & Sobregiro & _
            ",[INTERES] = " & Interes & _
            " WHERE [NUMCUENTA] = '" & txtNumCuenta.Text & "' AND [CODBANCO] = " & CodBanco & ""
        ElseIf varINSTRUMENTO = 1 Then
            sql = "UPDATE [INSTRUMENTO] " & _
            "SET [CODUSUARIO] = " & CodUsuario & _
            ",[CODEMPRESA] = " & CodEmpresa & _
            ",[DESCRIPCION] = '" & DescripcionInstrumento & _
            "',[TIPOINTRUMENTO] = '" & TipoInstrumento & _
            "',[STATUS] = " & Status & _
            ",[USUARIO] = '" & Usuario & _
            "',[FIRMA] = '" & Firma & _
            "',[CLAVE] = '" & Clave & _
            "',[FECGRA] = " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & _
            " WHERE [CODINSTRUMENTO] = " & CodInstrumento & _
            " AND [NUMCUENTA] = '" & txtNumCuenta.Text & _
            "' AND [CODBANCO] = " & CodBanco & ""
        End If

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

    Private Sub btnEliminarBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarBanco.Click
        permiso = PermisoAplicado(UsuCodigo, 132)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If

        If txtCodBanco.Text = "" Then
            MessageBox.Show("No existen registros para eliminar", "POS EXPRESS")
            Exit Sub
        End If

        varBANCO = 1
        ELIMINAR()
        varBANCO = 0
        HabilitaPanel()
    End Sub

    Private Sub btnEliminarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCuenta.Click
        permiso = PermisoAplicado(UsuCodigo, 132)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If

        If grdCuenta.RowCount = 0 Or grdCuenta.CurrentRow.Cells("NUMCUENTA").Value = "" Then
            MessageBox.Show("No existen registros para eliminar", "POSEXPRESS")
            Exit Sub
        End If


        varCUENTA = 1
        ELIMINAR()
        varCUENTA = 0
        HabilitaPanel()
    End Sub

    Private Sub btnEliminarInstrumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarInstrumento.Click
        permiso = PermisoAplicado(UsuCodigo, 132)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If

        If txtCodInstrumento.Text = "" Then
            MessageBox.Show("No existen registros para eliminar", "POSEXPRESS")
            Exit Sub
        End If


        varINSTRUMENTO = 1
        ELIMINAR()
        varINSTRUMENTO = 0
        HabilitaPanel()
    End Sub

    Private Sub btnGuardarBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarBanco.Click
        permiso = PermisoAplicado(UsuCodigo, 133)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Guardar en esta ventana", "Pos Express")
            Exit Sub
        End If

        varBANCO = 1
        GUARDAR()
        varBANCO = 0
        HabilitaPanel()
    End Sub

    Private Sub btnGuardarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCuenta.Click
        permiso = PermisoAplicado(UsuCodigo, 133)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Guardar en esta ventana", "Pos Express")
            Exit Sub
        End If

        varCUENTA = 1
        GUARDAR()
        varCUENTA = 0
        HabilitaPanel()
    End Sub

    Private Sub btnGuardarInstrumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarInstrumento.Click
        permiso = PermisoAplicado(UsuCodigo, 133)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Guardar en esta ventana", "Pos Express")
            Exit Sub
        End If

        varINSTRUMENTO = 1
        GUARDAR()
        varINSTRUMENTO = 0
        HabilitaPanel()
    End Sub

    Private Sub btnInstrumentoVerClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInstrumentoVerClave.Click
        If btnInstrumentoVerClave.Text = "Ver" Then
            Me.txtInstrumentoClave.PasswordChar = ""
            btnInstrumentoVerClave.Text = "Ocultar"
        Else
            Me.txtInstrumentoClave.PasswordChar = "*"
            btnInstrumentoVerClave.Text = "Ver"
        End If
    End Sub

    Private Sub btnModificarBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarBanco.Click
        permiso = PermisoAplicado(UsuCodigo, 133)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar en esta ventana", "Pos Express")
            Exit Sub
        End If
        varBANCO = 1
        DeshabilitaPanel()
        MODIFICAR()
        varBANCO = 0
    End Sub

    Private Sub btnModificarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarCuenta.Click
        permiso = PermisoAplicado(UsuCodigo, 133)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar en esta ventana", "Pos Express")
            Exit Sub
        End If

        varCUENTA = 1
        DeshabilitaPanel()
        MODIFICAR()
        varCUENTA = 0
        txtNumCuenta.Enabled = False
    End Sub

    Private Sub btnModificarInstrumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarInstrumento.Click
        permiso = PermisoAplicado(UsuCodigo, 133)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar en esta ventana", "Pos Express")
            Exit Sub
        End If

        varINSTRUMENTO = 1
        DeshabilitaPanel()
        MODIFICAR()
        varINSTRUMENTO = 0
    End Sub

    Private Sub BtnNuevobanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoBanco.Click
        permiso = PermisoAplicado(UsuCodigo, 131)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        varBANCO = 1
        DeshabilitaPanel()
        NUEVO()
        varBANCO = 0
        lb_mensaje.Visible = True
    End Sub

    Private Sub btnNuevoCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCuenta.Click
        permiso = PermisoAplicado(UsuCodigo, 131)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        varCUENTA = 1
        DeshabilitaPanel()
        NUEVO()
        varCUENTA = 0
        txtNumCuenta.Enabled = True
    End Sub

    Private Sub btnNuevoInstrumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoInstrumento.Click
        permiso = PermisoAplicado(UsuCodigo, 131)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        varINSTRUMENTO = 1
        DeshabilitaControles()
        NUEVO()
        varINSTRUMENTO = 0
    End Sub

    Private Sub CANCELAR()
        Me.pbxAbierto.Visible = False
        Me.pbxCerrado.Visible = True

        BANCOBindingSource.CancelEdit()
        Me.BANCOTableAdapter.Fill(Me.DsFacturacion.BANCO)

        CUENTABANCARIABindingSource.CancelEdit()
        Me.CUENTABANCARIATableAdapter.Fill(Me.DsFacturacion.CUENTABANCARIA)

        INSTRUMENTOBindingSource.CancelEdit()
        'Me.INSTRUMENTOTableAdapter.Fill(Me.DsFacturacion.INSTRUMENTO)

        DeshabilitaControles()
    End Sub



    Private Sub cboCuentaMoneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCuentaMoneda.GotFocus
        lb_mensaje.Text = " Moneda: Seleccionar Tipo de Moneda "
        lb_mensaje.Visible = True
    End Sub

    Private Sub cboCuentaMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuentaMoneda.SelectedIndexChanged
    End Sub

    Private Sub cboInstrumentoStatus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInstrumentoStatus.GotFocus
        lb_mensaje.Text = " Status: Seleccionar el Status del Instrumento "
        lb_mensaje.Visible = True
    End Sub

    Private Sub cboInstrumentoStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInstrumentoStatus.SelectedIndexChanged
    End Sub

    Private Sub cboTipoCuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoCuenta.GotFocus
        lb_mensaje.Text = " Tipo Cuenta: Seleccionar Tipo de Cuenta "
        lb_mensaje.Visible = True
    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCuenta.SelectedIndexChanged
    End Sub

    Private Sub chkCuentaSobregiro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCuentaSobregiro.GotFocus
        lb_mensaje.Text = " Usted desea realizar un sobregiro"
    End Sub

    Private Sub chkCuentaSobregiro_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkCuentaSobregiro.ToggleStateChanged
    End Sub

    Private Sub DeshabilitaControles()
        'If varBANCO = 1 Then
        txtBanco.Enabled = False
        txtBancoSucursal.Enabled = False
        txtBancoDireccion.Enabled = False
        txtBancoAgente.Enabled = False
        txtBancoTelefono.Enabled = False
        txtBancoEmail.Enabled = False
        'ElseIf varCUENTA = 1 Then
        txtCuentaDescripcion.Enabled = False
        txtNumCuenta.Enabled = False
        cboTipoCuenta.Enabled = False
        cboCuentaMoneda.Enabled = False
        chkCuentaSobregiro.Enabled = False
        txtCuentaLimite.Enabled = False
        txtCuentaInteres.Enabled = False
        'ElseIf varINSTRUMENTO = 1 Then
        txtInstrumentoDescripcion.Enabled = False
        txtInstrumentoTipo.Enabled = False
        cboInstrumentoStatus.Enabled = False
        txtInstrumentoUsuario.Enabled = False
        txtInstrumentoFirma.Enabled = False
        txtInstrumentoClave.Enabled = False
        'End If

        'Habilita los botones de Guardar y Cancelar
        btnGuardarBanco.Enabled = False
        'pbxGuardar.Visible = True
        'pbxGuardarGris.Visible = False
        'BtnCancelar.Visible = True

        'Habilita los botones de Guardar y Cancelar
        btnGuardarCuenta.Enabled = False
        'pbxGuardar.Visible = True
        'pbxGuardarGris.Visible = False
        'BtnCancelar.Visible = True

        'Habilita los botones de Guardar y Cancelar
        btnGuardarInstrumento.Enabled = False
        'pbxGuardar.Visible = True
        'pbxGuardarGris.Visible = False
        'BtnCancelar.Visible = True
        pbxCancelar.Visible = False
        btnNuevoBanco.Enabled = True
        btnNuevoCuenta.Enabled = True
        btnNuevoInstrumento.Enabled = True
        btnEliminarBanco.Enabled = True
        btnEliminarCuenta.Enabled = True
        btnEliminarInstrumento.Enabled = True
    End Sub

    Private Sub DeshabilitaPanel()
        If varBANCO = 1 Then
            RadPanel2.Enabled = False
            RadPanel3.Enabled = False

            grdCuenta.Enabled = False
            btnNuevoCuenta.Enabled = False

            btnNuevoInstrumento.Enabled = False
            grdInstrumento.Enabled = False
        ElseIf varCUENTA = 1 Then
            RadPanel1.Enabled = False
            RadPanel3.Enabled = False

            grdBanco.Enabled = False
            btnNuevoBanco.Enabled = False
            grdInstrumento.Enabled = False
            btnNuevoInstrumento.Enabled = False
        ElseIf varINSTRUMENTO = 1 Then
            RadPanel1.Enabled = False
            RadPanel2.Enabled = False

            grdBanco.Enabled = False
            btnNuevoBanco.Enabled = False
            grdCuenta.Enabled = False
            btnNuevoCuenta.Enabled = False
        End If
    End Sub

    Private Sub EliminaDatos()
        sql = ""
        If varBANCO = 1 Then
            sql = " DELETE FROM BANCO " & _
            " WHERE CODBANCO = '" & Me.txtCodBanco.Text & "'"
        ElseIf varCUENTA = 1 Then
            sql = " DELETE FROM CUENTABANCARIA " & _
            " WHERE NUMCUENTA = '" & Me.txtNumCuenta.Text & _
            "' AND CODBANCO = '" & Me.txtCodBanco.Text & "'"
        ElseIf varINSTRUMENTO = 1 Then
            sql = " DELETE FROM INSTRUMENTO " & _
            " WHERE CODINSTRUMENTO = '" & Me.txtCodInstrumento.Text & _
            "' AND NUMCUENTA = '" & Me.txtNumCuenta.Text & _
            "' AND CODBANCO = '" & Me.txtCodBanco.Text & "'"
        End If

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ELIMINAR()
        Me.pbxAbierto.Visible = False
        Me.pbxCerrado.Visible = True

        If MessageBox.Show("¿Esta seguro que quiere eliminar estos Datos?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        If varBANCO = 1 Then
            existe = funcion.FuncionConsulta("CODBANCO", "BANCO", "CODBANCO", Me.txtCodBanco.Text)
        ElseIf varCUENTA = 1 Then
            existe = funcion.FuncionConsulta("NUMCUENTA", "CUENTABANCARIA", "NUMCUENTA = " & Me.txtNumCuenta.Text & " AND CODBANCO", Me.txtCodBanco.Text)
        ElseIf varINSTRUMENTO = 1 Then
            existe = funcion.FuncionConsulta("CODINSTRUMENTO", "INSTRUMENTO", "CODINSTRUMENTO = " & txtCodInstrumento.Text & _
                                             "AND NUMCUENTA = " & Me.txtNumCuenta.Text & " AND CODBANCO", Me.txtCodBanco.Text)
        End If

        If existe <> 0 Then
            Dim transaction As SqlTransaction = Nothing
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc

            '############################
            'INSERCION DE LAS AUDITORIAS
            '############################
            If varBANCO = 1 Then
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "BANCO", CStr(CodBanco), "ELIMINACIÓN EN LA TABLA BANCO", _
                Today, 1, "NULL", 0, 0, 1)
            ElseIf varCUENTA = 1 Then
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "CUENTABANCARIA", CStr(NumCuenta), "ELIMINACIÓN EN LA TABLA CUENTA BANCARIA", _
                Today, 1, "NULL", 0, 0, 1)
            ElseIf varINSTRUMENTO = 1 Then
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "INSTRUMENTO", CStr(CodInstrumento), "ELIMINACIÓN EN LA TABLA INSTRUMENTO", _
                Today, 1, "NULL", 0, 0, 1)
            End If

            cmd.Transaction = myTrans

            Try
                EliminaDatos()
                myTrans.Commit()

                MessageBox.Show("Datos eliminada correctamente", "POSEXPRESS")
                DeshabilitaControles()

                If varBANCO = 1 Then
                    Me.BANCOTableAdapter.Fill(Me.DsFacturacion.BANCO)
                ElseIf varCUENTA = 1 Then
                    Me.CUENTABANCARIATableAdapter.Fill(Me.DsFacturacion.CUENTABANCARIA)
                ElseIf varINSTRUMENTO = 1 Then
                    Me.INSTRUMENTOTableAdapter.Fill(Me.DsFacturacion.INSTRUMENTO)
                End If

            Catch ex As SqlException
                Try
                    myTrans.Rollback("")
                Catch
                End Try

                Dim NroError As Integer = ex.Number
                Dim Mensaje As String = ex.Message
                If NroError = 547 Then
                    MessageBox.Show("El registro que desea eliminar tiene relacion con otra tabla del Sistema", "POSEXPRESS")
                Else
                    MessageBox.Show("Ocurrio un error el eliminar los Datos" + ex.Message, "POSEXPRESS")
                End If

            Finally
                sqlc.Close()
            End Try
            DeshabilitaControles()
        End If
    End Sub

    Private Sub GUARDAR()
        Me.pbxAbierto.Visible = False
        Me.pbxCerrado.Visible = True

        '###########################################
        'Se validan los campos que no admiten nulos
        '###########################################

        If varBANCO = 1 Then
            CodBanco = CInt(Me.txtCodBanco.Text)
            'CodUsuario =
            'CodEmpresa=
            NumBanco = CStr(Me.txtCodBanco.Text)

            If Me.txtBanco.Text = "" Then
                MessageBox.Show("Descripción de Banco es obligatorio, por favor introduzcalo", "POSEXPRESS")
                Me.txtBanco.Focus()
                Exit Sub
            Else
                DesBanco = Me.txtBanco.Text
            End If

            If Me.txtBancoSucursal.Text = "" Then
                Sucursal = ""
            Else
                Sucursal = Me.txtBancoSucursal.Text
            End If

            If Me.txtBancoDireccion.Text = "" Then
                Direccion = ""
            Else
                Direccion = Me.txtBancoDireccion.Text
            End If

            If Me.txtBancoAgente.Text = "" Then
                Agente = ""
            Else
                Agente = Me.txtBancoAgente.Text
            End If

            Telefono = Me.txtBancoTelefono.Text
            Email = Me.txtBancoEmail.Text
            FecGra = Today
        ElseIf varCUENTA = 1 Then
            NumCuenta = Me.txtNumCuenta.Text

            If Me.cboTipoCuenta.Text = "" Then
                CodTipoCuenta = "Null"
            Else
                CodTipoCuenta = Me.cboTipoCuenta.SelectedValue
            End If

            'CODUSUARIO=
            'CODEMPRESA=

            If Me.cboCuentaMoneda.Text = "" Then
                CodMoneda = "Null"
            Else
                CodMoneda = CInt(Me.cboCuentaMoneda.SelectedValue)
            End If

            CodBanco = CInt(Me.txtCodBanco.Text)

            If Me.txtCuentaDescripcion.Text = "" Then
                DescripcionCuenta = ""
            Else
                DescripcionCuenta = Me.txtCuentaDescripcion.Text
            End If

            FechaApertura = Today
            If txtCuentaLimite.Text = "" Then
                LimiteCredito = "0"
            Else
                LimiteCredito = CDec(txtCuentaLimite.Text)
                LimiteCredito = Funciones.Cadenas.QuitarCad(LimiteCredito, ".")
                LimiteCredito = LimiteCredito.Replace(",", ".")
            End If

            FecGra = Today
            If chkCuentaSobregiro.Checked = True Then
                Sobregiro = 1
            Else
                Sobregiro = 0
            End If
            If txtCuentaInteres.Text = "" Then
                Interes = "0"
            Else
                Interes = CDec(txtCuentaInteres.Text)
                Interes = Funciones.Cadenas.QuitarCad(Interes, ".")
                Interes = Interes.Replace(",", ".")
            End If

        ElseIf varINSTRUMENTO = 1 Then
            'CodInstrumento = CInt(Me.txtCodInstrumento.Text)
            NumCuenta = Me.txtNumCuenta.Text
            CodBanco = CInt(Me.txtCodBanco.Text)

            'CODUSUARIO=
            'CODEMPRESA=

            If Me.txtInstrumentoDescripcion.Text = "" Then
                MessageBox.Show("Descripción de Instrumento es obligatorio, por favor introduzcalo", "POSEXPRESS")
                Me.txtInstrumentoDescripcion.Focus()
                Exit Sub
            Else
                DescripcionInstrumento = Me.txtInstrumentoDescripcion.Text
            End If

            If Me.txtInstrumentoTipo.Text = "" Then
                TipoInstrumento = ""
            Else
                TipoInstrumento = Me.txtInstrumentoTipo.Text
            End If

            If Me.cboInstrumentoStatus.Text = "" Then
                Status = "Null"
            Else
                If cboInstrumentoStatus.Text = "Activo" Then
                    Status = 1
                ElseIf cboInstrumentoStatus.Text = "Inactivo" Then
                    Status = 0
                End If

            End If

            If Me.txtInstrumentoUsuario.Text = "" Then
                Usuario = ""
            Else
                Usuario = Me.txtInstrumentoUsuario.Text
            End If

            If Me.txtInstrumentoFirma.Text = "" Then
                Firma = ""
            Else
                Firma = Me.txtInstrumentoFirma.Text
            End If

            If Me.txtInstrumentoClave.Text = "" Then
                Clave = ""
            Else
                Clave = Me.txtInstrumentoClave.Text
            End If

            FecGra = Today
        End If

        'Si quiere guardar con algun detalle incompleto
        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        If varBANCO = 1 Then
            existe = funcion.FuncionConsulta("CODBANCO", "BANCO", "CODBANCO", Me.txtCodBanco.Text)
        ElseIf varCUENTA = 1 Then
            existe = funcion.FuncionConsulta("CODBANCO", "CUENTABANCARIA", "NUMCUENTA = '" & Me.txtNumCuenta.Text & "' AND CODBANCO", Me.txtCodBanco.Text)
        ElseIf varINSTRUMENTO = 1 Then
            existe = funcion.FuncionConsulta("CODINSTRUMENTO", "INSTRUMENTO", "CODINSTRUMENTO = " & txtCodInstrumento.Text & _
                                             "AND NUMCUENTA = " & Me.txtNumCuenta.Text & " AND CODBANCO", Me.txtCodBanco.Text)
        End If

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
                If upd = 0 Then
                    MessageBox.Show("No tiene permiso para modificar registros en esta ventana", "POSEXPRESS")
                    Exit Sub
                End If
                ActualizaDatos()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                If varBANCO = 1 Then
                    CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                    Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "BANCO", CStr(CodBanco), "MODIFICACION EN LA TABLA BANCOS", _
                    Today, UsuDescripcion, "NULL", 0, 1, 0)
                ElseIf varCUENTA = 1 Then
                    CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                    Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "CUENTABANCARIA", CStr(NumCuenta), "MODIFICACION EN LA TABLA BANCOS CUENTA BANCARIA", _
                    Today, UsuDescripcion, "NULL", 0, 1, 0)
                ElseIf varINSTRUMENTO = 1 Then
                    CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                    Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "INSTRUMENTO", CStr(CodInstrumento), "MODIFICACION EN LA TABLA INSTRUMENTO", _
                    Today, UsuDescripcion, "NULL", 0, 1, 0)
                End If

                myTrans.Commit()
                MessageBox.Show("El proceso de grabación ha finalizado correctamente", _
                                                       "POSEXPRESS")
                DeshabilitaControles()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Ocurrio un error al intentar actualizar", _
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
                InsertaDatos()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                If varBANCO = 1 Then
                    CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                    Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "BANCO", CStr(CodBanco), "INSERCIÓN EN LA TABLA BANCOS", _
                    Today, UsuDescripcion, "NULL", 1, 0, 0)
                ElseIf varCUENTA = 1 Then
                    CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                    Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "CUENTABANCO", txtNumCuenta.Text, "INSERCIÓN EN LA TABLA CUENTA BANCO", _
                    Today, UsuDescripcion, "NULL", 1, 0, 0)
                ElseIf varINSTRUMENTO = 1 Then
                    CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                    Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "INSTRUMENTO", CStr(CodInstrumento), "INSERCIÓN EN LA TABLA INSTRUMENTO", _
                    Today, UsuDescripcion, "NULL", 1, 0, 0)
                End If

                myTrans.Commit()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", _
                                                       "POSEXPRESS")
            Catch ex As Exception

                myTrans.Rollback("Insertar")

                MessageBox.Show("Ocurrió un error al insertar", _
                                                       "POSEXPRESS")
            Finally
                sqlc.Close()
            End Try

        End If

        If varBANCO = 1 Then
            Try
                Me.BANCOTableAdapter.Fill(Me.DsFacturacion.BANCO)
            Catch ex As Exception

            End Try

        ElseIf varCUENTA = 1 Then
            Try
                Me.CUENTABANCARIATableAdapter.Fill(Me.DsFacturacion.CUENTABANCARIA)
            Catch ex As Exception

            End Try
        ElseIf varINSTRUMENTO = 1 Then
            Try
                Me.INSTRUMENTOTableAdapter.Fill(Me.DsFacturacion.INSTRUMENTO)
            Catch ex As Exception

            End Try

        End If

        DeshabilitaControles()
    End Sub

    Private Sub HabilitaControles()
        If varBANCO = 1 Then
            txtBanco.Enabled = True
            txtBancoSucursal.Enabled = True
            txtBancoDireccion.Enabled = True
            txtBancoAgente.Enabled = True
            txtBancoTelefono.Enabled = True
            txtBancoEmail.Enabled = True

            'Habilita los botones de Guardar y Cancelar
            btnGuardarBanco.Enabled = True
            btnModificarBanco.Enabled = False
            'pbxGuardar.Visible = True
            'pbxGuardarGris.Visible = False
            'BtnCancelar.Visible = True

            btnNuevoBanco.Enabled = False
            btnEliminarBanco.Enabled = False

        ElseIf varCUENTA = 1 Then
            txtCuentaDescripcion.Enabled = True
            txtNumCuenta.Enabled = True
            cboTipoCuenta.Enabled = True
            cboCuentaMoneda.Enabled = True
            chkCuentaSobregiro.Enabled = True
            txtCuentaLimite.Enabled = True
            txtCuentaInteres.Enabled = True

            'Habilita los botones de Guardar y Cancelar
            btnGuardarCuenta.Enabled = True
            btnModificarCuenta.Enabled = False
            'pbxGuardar.Visible = True
            'pbxGuardarGris.Visible = False
            'BtnCancelar.Visible = True

            btnNuevoCuenta.Enabled = False
            btnEliminarCuenta.Enabled = False

        ElseIf varINSTRUMENTO = 1 Then
            txtInstrumentoDescripcion.Enabled = True
            txtInstrumentoTipo.Enabled = True
            cboInstrumentoStatus.Enabled = True
            txtInstrumentoUsuario.Enabled = True
            txtInstrumentoFirma.Enabled = True
            txtInstrumentoClave.Enabled = True

            'Habilita los botones de Guardar y Cancelar
            btnGuardarInstrumento.Enabled = True
            btnModificarInstrumento.Enabled = False
            'pbxGuardar.Visible = True
            'pbxGuardarGris.Visible = False
            'BtnCancelar.Visible = True

            btnNuevoInstrumento.Enabled = False
            btnEliminarInstrumento.Enabled = False

        End If
        pbxCancelar.Visible = True
    End Sub

    Private Sub HabilitaPanel()
        RadPanel1.Enabled = True
        RadPanel2.Enabled = True
        RadPanel3.Enabled = True

        grdBanco.Enabled = True
        grdCuenta.Enabled = True
        grdInstrumento.Enabled = True

        btnNuevoCuenta.Enabled = True
        btnNuevoBanco.Enabled = True
        btnNuevoInstrumento.Enabled = True
        btnModificarBanco.Enabled = True
        btnModificarCuenta.Enabled = True
        btnModificarInstrumento.Enabled = True
    End Sub

    Private Sub InsertaDatos()
        sql = ""
        If varBANCO = 1 Then
            sql = "INSERT INTO [BANCO] " & _
           "([CODBANCO] " & _
           ",[CODUSUARIO] " & _
           ",[CODEMPRESA] " & _
           ",[NUMBANCO] " & _
           ",[DESBANCO] " & _
           ",[SUCURSAL] " & _
           ",[DIRECCION] " & _
           ",[AGENTE] " & _
           ",[TELEFONO] " & _
           ",[EMAIL] " & _
           ",[FECGRA]) " & _
            " VALUES(" & _
           CodBanco & _
           ", " & CodUsuario & _
           ", " & CodEmpresa & _
           ", '" & NumBanco & _
           "', '" & DesBanco & _
           "', '" & Sucursal & _
           "', '" & Direccion & _
           "', '" & Agente & _
           "', '" & Telefono & _
           "', '" & Email & _
           "', " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & ")"
        ElseIf varCUENTA = 1 Then
            sql = "INSERT INTO [CUENTABANCARIA] " & _
           "([NUMCUENTA] " & _
           ",[CODTIPOCUENTA] " & _
           ",[CODUSUARIO] " & _
           ",[CODEMPRESA] " & _
           ",[CODMONEDA] " & _
           ",[CODBANCO] " & _
           ",[DESCRIPCION] " & _
           ",[FECHAAPERTURA] " & _
           ",[LIMITECREDITO] " & _
           ",[FECGRA] " & _
           ",[SOBREGIRO] " & _
           ",[INTERES]) " & _
           " VALUES('" & _
           NumCuenta & _
           "', " & CodTipoCuenta & _
           ", " & CodUsuario & _
           ", " & CodEmpresa & _
           ", " & CodMoneda & _
           ", " & CodBanco & _
           ", '" & DescripcionCuenta & _
           "', " & FechaApertura & _
           ", " & LimiteCredito & _
           ", " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & _
           ", " & Sobregiro & _
           ", " & Interes & ")"
        ElseIf varINSTRUMENTO = 1 Then
            sql = "INSERT INTO [INSTRUMENTO] " & _
           "([CODINSTRUMENTO] " & _
           ",[NUMCUENTA] " & _
           ",[CODBANCO] " & _
           ",[CODUSUARIO] " & _
           ",[CODEMPRESA] " & _
           ",[DESCRIPCION] " & _
           ",[TIPOINTRUMENTO] " & _
           ",[STATUS] " & _
           ",[USUARIO] " & _
           ",[FIRMA] " & _
           ",[CLAVE] " & _
           ",[FECGRA]) " & _
           " VALUES(" & CodInstrumento & ", '" & txtNumCuenta.Text & "', " & CodBanco & ", " & CodUsuario & ", " & CodEmpresa & " " & _
           ", '" & DescripcionInstrumento & "', '" & TipoInstrumento & "', " & Status & ", '" & Usuario & "', '" & Firma & "', '" & Clave & "' " & _
           ", " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & ")"
        End If

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub LimpiarControles()
        chkCuentaSobregiro.Checked = False
    End Sub

    Private Sub MODIFICAR()
        Me.pbxCerrado.Visible = False
        Me.pbxAbierto.Visible = True
        HabilitaControles()
    End Sub

    Private Sub NUEVO()
        Dim funcion As New Funciones.Funciones
        Me.pbxCerrado.Visible = False
        Me.pbxAbierto.Visible = True

        HabilitaControles()
       
        LimpiarControles()

        If varBANCO = 1 Then
            BANCOBindingSource.AddNew()
            txtBanco.Focus()
        ElseIf varCUENTA = 1 Then
            CUENTABANCARIABindingSource.AddNew()
            txtNumCuenta.Focus()
        ElseIf varINSTRUMENTO = 1 Then
            'INSTRUMENTOBindingSource.AddNew()
            txtInstrumentoDescripcion.Focus()
        End If
    End Sub

    Private Sub pbxCancelarGris_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCancelarGris.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxCancelarGris_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCancelarGris.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCancelar.Click
        CANCELAR()
        HabilitaPanel()
        'pbxNuevaFicha.Visible = True
        'pbxNuevaFichaGris.Visible = False
        'pbxEliminarFicha.Visible = True
        'pbxEliminarFichaGris.Visible = False
        'pbxModificarFicha.Visible = True
        'pbxModificarFichaGris.Visible = False
    End Sub

    Private Sub pbxCancelar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCancelar.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxCancelar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCancelar.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxEliminarFichaGris_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxEliminarFichaGris_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxEliminarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ELIMINAR()
    End Sub

    Private Sub pbxEliminarFicha_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxEliminarFicha_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxEnviarErrores_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxEnviarErrores_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxGuardarGris_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxGuardarGris_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GUARDAR()
        'pbxNuevaFicha.Visible = True
        'pbxNuevaFichaGris.Visible = False
        'pbxEliminarFicha.Visible = True
        'pbxEliminarFichaGris.Visible = False
        'pbxModificarFicha.Visible = True
        'pbxModificarFichaGris.Visible = False
    End Sub

    Private Sub pbxGuardar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxGuardar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxModificarFichaGris_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxModificarFichaGris_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxModificarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MODIFICAR()
        'pbxNuevaFicha.Visible = False
        'pbxNuevaFichaGris.Visible = True
        'pbxEliminarFicha.Visible = False
        'pbxEliminarFichaGris.Visible = True
        'pbxModificarFicha.Visible = False
        'pbxModificarFichaGris.Visible = True
    End Sub

    Private Sub pbxModificarFicha_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxModificarFicha_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxNuevaFichaGris_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxNuevaFichaGris_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxNuevaFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NUEVO()
        'pbxNuevaFicha.Visible = False
        'pbxNuevaFichaGris.Visible = True
        'pbxEliminarFicha.Visible = False
        'pbxEliminarFichaGris.Visible = True
        'pbxModificarFicha.Visible = False
        'pbxModificarFichaGris.Visible = True
    End Sub

    Private Sub pbxNuevaFicha_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxNuevaFicha_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
    End Sub

    Private Sub PictureBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.GotFocus
        lb_mensaje.Text = " Buscar los Datos del Banco"
        lb_mensaje.Visible = True
    End Sub

    Private Sub TextBoxEstatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxEstatus.TextChanged
        If TextBoxEstatus.Text = "1" Then
            cboInstrumentoStatus.Text = "Activo"

        ElseIf TextBoxEstatus.Text = "0" Then

            cboInstrumentoStatus.Text = "Inactivo"

        End If
    End Sub

    Private Sub txtBancoAgente_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles txtBancoAgente.GiveFeedback
    End Sub

    Private Sub txtBancoAgente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBancoAgente.GotFocus
        lb_mensaje.Text = " Agente: Ingresar el nombre del Agente "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtBancoAgente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBancoAgente.TextChanged
    End Sub

    Private Sub txtBancoDireccion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBancoDireccion.GotFocus
        lb_mensaje.Text = " Dirección: Ingresar la Dirección que desea "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtBancoDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBancoDireccion.TextChanged
    End Sub

    Private Sub txtBancoEmail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBancoEmail.GotFocus
        lb_mensaje.Text = " Email: Ingresar email deseado "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtBancoEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBancoEmail.TextChanged
    End Sub

    Private Sub txtBancoSucursal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBancoSucursal.GotFocus
        lb_mensaje.Text = " Sucursal: Ingresar la sucursal que desea "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtBancoSucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBancoSucursal.TextChanged
    End Sub

    Private Sub txtBancoTelefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBancoTelefono.GotFocus
        lb_mensaje.Text = " Telefono: Ingresar el Telefono del Banco "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtBancoTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBancoTelefono.TextChanged
    End Sub

    Private Sub txtBanco_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBanco.GotFocus
        lb_mensaje.Text = " Banco: Ingresar el nombre del Banco "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtBanco_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBanco.TextChanged
    End Sub

    Private Sub txtBuscarBanco_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscarBanco.GotFocus
        If txtBuscarBanco.Text = "" Then
            txtBuscarBanco.Text = "Buscar..."
        End If
    End Sub

    Private Sub txtBuscarBanco_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscarBanco.LostFocus
        If txtBuscarBanco.Text = "" Then
            txtBuscarBanco.Text = "Buscar..."
        End If
    End Sub

    Private Sub txtBuscarBanco_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarBanco.TextChanged
        If txtBuscarBanco.Text = "Buscar..." Then
        Else
            Dim Filtro As New FilterExpression()
            Filtro.Predicates.Add(FilterExpression.BinaryOperation.[OR], GridKnownFunction.Contains, GridFilterCellElement.ParameterName)
            Filtro.Parameters.Add(GridFilterCellElement.ParameterName, txtBuscarBanco.Text)
            Me.grdBanco.Columns("DESBANCO").Filter = Filtro
        End If
    End Sub

    Private Sub txtBuscarCuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscarCuenta.GotFocus
        If txtBuscarCuenta.Text = "Buscar..." Then
            txtBuscarCuenta.Text = ""
        End If
    End Sub

    Private Sub txtBuscarCuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscarCuenta.LostFocus
        If txtBuscarCuenta.Text = "" Then
            txtBuscarCuenta.Text = "Buscar..."
        End If
    End Sub

    Private Sub txtBuscarCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarCuenta.TextChanged
        If txtBuscarCuenta.Text = "Buscar..." Then
        Else
            Dim Filtro As New FilterExpression()
            Filtro.Predicates.Add(FilterExpression.BinaryOperation.[OR], GridKnownFunction.Contains, GridFilterCellElement.ParameterName)
            Filtro.Parameters.Add(GridFilterCellElement.ParameterName, txtBuscarCuenta.Text)
            Me.grdCuenta.Columns("DESCRIPCION").Filter = Filtro
        End If
    End Sub

    Private Sub txtBuscarInstrumento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscarInstrumento.GotFocus
        If txtBuscarInstrumento.Text = "Buscar..." Then
            txtBuscarInstrumento.Text = ""
        End If
    End Sub

    Private Sub txtBuscarInstrumento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscarInstrumento.LostFocus
        If txtBuscarInstrumento.Text = "" Then
            txtBuscarInstrumento.Text = "Buscar..."
        End If
    End Sub

    Private Sub txtBuscarInstrumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarInstrumento.TextChanged
        If txtBuscarInstrumento.Text = "Buscar..." Then
        Else
            Dim Filtro As New FilterExpression()
            Filtro.Predicates.Add(FilterExpression.BinaryOperation.[OR], GridKnownFunction.Contains, GridFilterCellElement.ParameterName)
            Filtro.Parameters.Add(GridFilterCellElement.ParameterName, txtBuscarInstrumento.Text)
            Me.grdInstrumento.Columns("DESCRIPCION").Filter = Filtro
        End If
    End Sub

    Private Sub txtCuentaDescripcion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaDescripcion.GotFocus
        lb_mensaje.Text = " Descripción: Ingresar descripción de la cuenta  "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtCuentaDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuentaDescripcion.TextChanged
    End Sub

    Private Sub txtCuentaInteres_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaInteres.GotFocus
        lb_mensaje.Text = " Intereses: Ingresar el interes para su transaccion "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtCuentaInteres_MaskChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs) Handles txtCuentaInteres.MaskChanged
    End Sub

    Private Sub txtCuentaInteres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub txtCuentaLimite_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaLimite.GotFocus
        lb_mensaje.Text = " Limite: Ingresar el limite que usted desea para su transacción "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtCuentaLimite_MaskChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs) Handles txtCuentaLimite.MaskChanged
    End Sub

    Private Sub txtCuentaLimite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub txtInstrumentoClave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInstrumentoClave.GotFocus
        lb_mensaje.Text = " Clave Pin: Ingresar la Clave del Pin "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtInstrumentoClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstrumentoClave.TextChanged
    End Sub

    Private Sub txtInstrumentoDescripcion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInstrumentoDescripcion.GotFocus
        lb_mensaje.Text = " Descripcion: Ingresar la Descripcion del instrumento  "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtInstrumentoDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstrumentoDescripcion.TextChanged
    End Sub

    Private Sub txtInstrumentoFirma_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInstrumentoFirma.GotFocus
        lb_mensaje.Text = " Firma: Ingresar la firma del usuario "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtInstrumentoFirma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstrumentoFirma.TextChanged
    End Sub

    Private Sub txtInstrumentoStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstrumentoStatus.TextChanged
        If txtInstrumentoStatus.Text = "0" Then
            Me.cboInstrumentoStatus.Text = "Activo"
        Else
            Me.cboInstrumentoStatus.Text = "Inactivo"
        End If
    End Sub

    Private Sub txtInstrumentoTipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInstrumentoTipo.GotFocus
        lb_mensaje.Text = " Tipo de Instrumento: Ingresar el Tipo de Instrumento "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtInstrumentoTipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstrumentoTipo.TextChanged
    End Sub

    Private Sub txtInstrumentoUsuario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInstrumentoUsuario.GotFocus
        lb_mensaje.Text = " Usuario: Ingresar el Usuario "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtInstrumentoUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstrumentoUsuario.TextChanged
    End Sub

    Private Sub txtNumCuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumCuenta.GotFocus
        lb_mensaje.Text = " Cuenta Nro: Ingresar el numero de cuenta deseado "
        lb_mensaje.Visible = True
    End Sub

    Private Sub txtNumCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumCuenta.TextChanged
    End Sub

#End Region 'Methods

#Region "Other"

    'Private Sub txtNomFantasia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomFantasia.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtBuscar.Focus()
    '        Case Keys.Down
    '            Me.txtDesEmpresa.Focus()
    '        Case Keys.Enter
    '            Me.txtDesEmpresa.Focus()
    '    End Select
    'End Sub
    'Private Sub txtDesEmpresa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesEmpresa.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtNomFantasia.Focus()
    '        Case Keys.Down
    '            Me.txtDireccion.Focus()
    '        Case Keys.Enter
    '            Me.txtDireccion.Focus()
    '    End Select
    'End Sub
    'Private Sub txtDireccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDireccion.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtDesEmpresa.Focus()
    '        Case Keys.Down
    '            Me.txtTelefono.Focus()
    '        Case Keys.Enter
    '            Me.txtTelefono.Focus()
    '    End Select
    'End Sub
    'Private Sub txtTelefono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtDireccion.Focus()
    '        Case Keys.Down
    '            Me.txtEmail.Focus()
    '        Case Keys.Enter
    '            Me.txtEmail.Focus()
    '    End Select
    'End Sub
    'Private Sub txtEmail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtTelefono.Focus()
    '        Case Keys.Down
    '            Me.txtLocalidad.Focus()
    '        Case Keys.Enter
    '            Me.txtLocalidad.Focus()
    '    End Select
    'End Sub
    'Private Sub txtLocalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocalidad.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtEmail.Focus()
    '        Case Keys.Down
    '            Me.txtNomContribuyente.Focus()
    '        Case Keys.Enter
    '            Me.txtNomContribuyente.Focus()
    '    End Select
    'End Sub
    'Private Sub txtNomContribuyente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomContribuyente.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtLocalidad.Focus()
    '        Case Keys.Down
    '            Me.txtRUCContribuyente.Focus()
    '        Case Keys.Enter
    '            Me.txtRUCContribuyente.Focus()
    '    End Select
    'End Sub
    'Private Sub txtRUCContribuyente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRUCContribuyente.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtNomContribuyente.Focus()
    '        Case Keys.Down
    '            Me.txtNumRegPatronal.Focus()
    '        Case Keys.Enter
    '            Me.txtNumRegPatronal.Focus()
    '    End Select
    'End Sub
    'Private Sub txtNumRegPatronal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumRegPatronal.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtRUCContribuyente.Focus()
    '        Case Keys.Down
    '            Me.txtNomRepresentante.Focus()
    '        Case Keys.Enter
    '            Me.txtNomRepresentante.Focus()
    '    End Select
    'End Sub
    ''Private Sub chkRetentor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkRetentor.KeyDown
    ''    Select Case e.KeyCode()
    ''        Case Keys.Up
    ''            Me.txtNumRegPatronal.Focus()
    ''        Case Keys.Down
    ''            Me.txtNomRepresentante.Focus()
    ''        Case Keys.Enter
    ''            Me.txtNomRepresentante.Focus()
    ''    End Select
    ''End Sub
    'Private Sub txtNomRepresentante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomRepresentante.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtNumRegPatronal.Focus()
    '        Case Keys.Down
    '            Me.txtRUCRepresentante.Focus()
    '        Case Keys.Enter
    '            Me.txtRUCRepresentante.Focus()
    '    End Select
    'End Sub
    'Private Sub txtRUCRepresentante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRUCRepresentante.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtNomRepresentante.Focus()
    '        Case Keys.Down
    '            Me.txtNroRegistro.Focus()
    '        Case Keys.Enter
    '            Me.txtNroRegistro.Focus()
    '    End Select
    'End Sub
    'Private Sub txtNroRegistro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroRegistro.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtRUCRepresentante.Focus()
    '        Case Keys.Down
    '            Me.txtPorRetencion.Focus()
    '        Case Keys.Enter
    '            Me.txtPorRetencion.Focus()
    '    End Select
    'End Sub
    'Private Sub txtPorRetencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorRetencion.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtNroRegistro.Focus()
    '        Case Keys.Down
    '            Me.pbxGuardar.Focus()
    '        Case Keys.Enter
    '            Me.pbxGuardar.Focus()
    '    End Select
    'End Sub

#End Region 'Other

End Class