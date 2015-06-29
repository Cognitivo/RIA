#Region "Header"

'ESTA ES LA NUEVA VERSION DE MONEDAS. FECHA: 11/MARZO/2010

#End Region 'Header

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
Imports Osuna.Utiles.Conectividad

Imports Microsoft.VisualBasic
Imports Telerik.WinControls.UI

Public Class ABMMonedas

#Region "Fields"
    Dim varnuevo As Integer
    Dim anu As Integer
    Private cmd As SqlCommand
    Dim IsNew, IsEdit As Integer
    '################################################
    'Variable para actualizar e insertar el Movimiento
    '################################################
    Dim CodMoneda, CodUsuario, CodEmpresa, Prioridad, Decimales As Integer
    Dim del As Integer

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim Existe, MODIFICARDetalle, INDICE As Integer
    Dim FecGra As Date
    Dim filename As String
    Dim ins As Integer
    Private myTrans As SqlTransaction
    Dim NumMoneda, DesMoneda, Simbolo, Imagen As String
    Dim permiso As Double
    Dim vgPrioridad As Integer
    Dim vgMonedaNombre As String
    '#######################################################################################################################
    Dim pasodetalle As Integer
    Dim pri As Integer
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Dim f As New Funciones.Funciones
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

    'PERMITE UTILIZAR LAS TECLAS DE FUNCION PARA REALIZAR LOS PROCEDIMIENTOS

    Private Sub ABMMoneda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 90)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If

        DeshabilitaControles()
        DeshabilitaDetalle()
        AsignarValores()
        InicializarDetalle()

        'Obtenemos el Nombre de la Moneda Principal
        vgMonedaNombre = f.FuncionConsultaString("DESMONEDA", "MONEDA", "PRIORIDAD", 1)
        Try
            Windows.Forms.Application.DoEvents()
            Me.MONEDATableAdapter.Fill(Me.DsFacturacion.MONEDA, "%")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ActualizaDetalle()
        Dim CodMoneda, CodUsuario, CodEmpresa As Integer
        Dim FactorVenta, FactorCobro As String
        Dim FechaMovimiento, FecGra As Date
        Dim IndiceCotizacion = grdCotizacion.RowCount
        Dim funcion As New Funciones.Funciones
        If IndiceCotizacion > 0 Then
            For IndiceCotizacion = 1 To IndiceCotizacion
                FechaMovimiento = grdCotizacion.Rows(IndiceCotizacion - 1).Cells("FECHAMOVIMIENTOCOTIZACION").Value
                CodMoneda = grdCotizacion.Rows(IndiceCotizacion - 1).Cells("CODMONEDACOTIZACION").Value
                CodUsuario = grdCotizacion.Rows(IndiceCotizacion - 1).Cells("CODUSUARIOCOTIZACION").Value
                CodEmpresa = grdCotizacion.Rows(IndiceCotizacion - 1).Cells("CODEMPRESACOTIZACION").Value
                FactorVenta = grdCotizacion.Rows(IndiceCotizacion - 1).Cells("FACTORVENTACOTIZACION").Value
                FactorCobro = grdCotizacion.Rows(IndiceCotizacion - 1).Cells("FACTORCOBROCOTIZACION").Value
                FecGra = grdCotizacion.Rows(IndiceCotizacion - 1).Cells("FECGRACOTIZACION").Value

                FactorVenta = Funciones.Cadenas.QuitarCad(FactorVenta, ".")
                FactorVenta = Replace(FactorVenta, ",", ".")
                FactorCobro = Funciones.Cadenas.QuitarCad(FactorCobro, ".")
                FactorCobro = Replace(FactorCobro, ",", ".")

                Existe = 0 'funcion.FuncionConsultaDecimal("CODMONEDA", "COTIZACION", _
                '                                        "FECHAMOVIMIENTO = " & FechaMovimiento & " AND CODUSUARIO = " & CodUsuario & " AND CODEMPRESA", CodEmpresa)
                Dim hora As String = Now.ToString("HH:mm:ss")
                Dim Concat As String = FecGra
                Dim Concatenar As String = Concat & " " + hora
                If Existe <> 0 Then
                    sql = ""
                    sql = "UPDATE [COTIZACION] " & _
                    "SET [CODMONEDA] = " & CodMoneda & _
                    ",[FACTORVENTA] = " & FactorVenta & _
                    ",[FACTORCOBRO] = " & FactorCobro & _
                    ",[FECGRA] = " & "convert(datetime, '" & Concatenar & "', 103)" & _
                    "WHERE [FECHAMOVIMIENTO] =  " & FechaMovimiento & _
                    " AND [CODUSUARIO] =  " & CodUsuario & _
                    " AND [CODEMPRESA] =  " & CodEmpresa & ""

                Else 'FechaMovimiento = Today Then
                    sql = ""
                    sql = "INSERT INTO [COTIZACION] " & _
                    "([FECHAMOVIMIENTO] " & _
                    ",[CODMONEDA] " & _
                    ",[CODUSUARIO] " & _
                    ",[CODEMPRESA] " & _
                    ",[FACTORVENTA] " & _
                    ",[FACTORCOBRO] " & _
                    ",[FECGRA]) " & _
                    " VALUES( " & _
                    "getdate()" & _
                    ", " & CodMoneda & _
                    ", " & CodUsuario & _
                    ", " & CodEmpresa & _
                    ", " & FactorVenta & _
                    ", " & FactorCobro & _
                    ", " & "convert(datetime, '" & Concatenar & "', 103)" & ")"
                    '"convert(datetime, '" & FechaMovimiento & " 0:00:00', 103)" & _

                End If

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Next
        End If
    End Sub

    Private Sub ActualizaMoneda()
        Dim ultimo As Integer
        Dim UsarDec As Integer

        DesMoneda = txtDesMoneda.Text
        Simbolo = txtSimbolo.Text

        If varnuevo = 1 Then
            ultimo = f.Maximo("CODMONEDA", "MONEDA")
        ElseIf varnuevo = 2 Then
            ultimo = txtCodMoneda.Text
        End If

        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim fecha As String
        Dim Concat As DateTime = Today
        Dim Concatenar As DateTime = Concat & " " + hora

        fecha = Concatenar.ToString("dd/MM/yyy HH:mm:ss")

        If cbxDecimales.Text = "Si" Then
            UsarDec = 1
        Else
            UsarDec = 0
        End If

        sql = ""
        sql = "UPDATE [MONEDA] " & _
        "SET [CODUSUARIO] = " & CodUsuario & _
        ",[CODEMPRESA] = " & CodEmpresa & _
        ",[NUMMONEDA] = '" & NumMoneda & _
        "',[DESMONEDA] = '" & DesMoneda & _
        "',[SIMBOLO] = '" & Simbolo & _
        "',[FECGRA] = " & "convert(datetime, '" & fecha & "', 103)" & _
        ",[PRIORIDAD] = " & vgPrioridad & _
        ",[DECIMALES] = " & UsarDec & _
        ",[CANTIDADDECIMALES] = " & Decimales & _
        ",[MULTIPLICADOR] = '" & Me.txtMultiplicador.Text & "'   " & _
        " WHERE [CODMONEDA] =  " & ultimo & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AgregarDetalle()
        If grdCotizacion.Enabled = False Then
            MessageBox.Show("Presione Modificar", "POSExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'valida el valor en la venta
        If String.IsNullOrEmpty(txtVentaCotizacion.Text) Then
            MessageBox.Show("Ingrese la Cotización en la venta", "POSEXPRESS")
            txtVentaCotizacion.Focus()
            Exit Sub
        ElseIf CDec(txtVentaCotizacion.Text) = 0 Then
            MessageBox.Show("Ingrese una cantidad mayor a cero en la venta", "POSEXPRESS")
            txtVentaCotizacion.Focus()
            Exit Sub
        End If
      
        If txtDesMoneda.Text = "" Then
            MessageBox.Show("Descripción de Moneda es obligatorio, por favor introduzca ese dato", "POSEXPRESS")
            txtDesMoneda.Focus()
            Exit Sub
        Else
            DesMoneda = txtDesMoneda.Text
        End If

        If txtSimbolo.Text = "" Then
            MessageBox.Show("Simbolo es obligatorio, por favor introduzca ese dato", "POSEXPRESS")
            txtSimbolo.Focus()
            Exit Sub
        Else
            Simbolo = txtSimbolo.Text
        End If

        If MODIFICARDetalle = 0 Then
            Dim fila1 As Integer = grdCotizacion.RowCount

            COTIZACIONBindingSource.AddNew()
            Dim fila As Integer = grdCotizacion.RowCount

            If fila > 0 Then
                grdCotizacion.Rows(fila - 1).Cells("FECHAMOVIMIENTOCOTIZACION").Value = txtFechaCotizacion.Text
                grdCotizacion.Rows(fila - 1).Cells("CODMONEDACOTIZACION").Value = CInt(txtCodMoneda.Text)
                grdCotizacion.Rows(fila - 1).Cells("CODUSUARIOCOTIZACION").Value = CodUsuario
                grdCotizacion.Rows(fila - 1).Cells("CODEMPRESACOTIZACION").Value = CodEmpresa
                grdCotizacion.Rows(fila - 1).Cells("FACTORVENTACOTIZACION").Value = CDec(txtVentaCotizacion.Text)
                grdCotizacion.Rows(fila - 1).Cells("FECGRACOTIZACION").Value = Today
                'GUARDARDETALLE()
                GUARDAR()
            End If

        Else
            grdCotizacion.Rows(INDICE).Cells("FECHAMOVIMIENTOCOTIZACION").Value = txtFechaCotizacion.Text
            grdCotizacion.Rows(INDICE).Cells("CODMONEDACOTIZACION").Value = CInt(txtCodMoneda.Text)
            grdCotizacion.Rows(INDICE).Cells("CODUSUARIOCOTIZACION").Value = CodUsuario
            grdCotizacion.Rows(INDICE).Cells("CODEMPRESACOTIZACION").Value = CodEmpresa
            grdCotizacion.Rows(INDICE).Cells("FACTORVENTACOTIZACION").Value = CDec(txtVentaCotizacion.Text)
            grdCotizacion.Rows(INDICE).Cells("FECGRACOTIZACION").Value = Today
            'GUARDARDETALLE()
            GUARDAR()
            MODIFICARDetalle = 0
        End If
        InicializarDetalle()
        DeshabilitaDetalle()
    End Sub

    Private Sub AsignarValores()
        If IsDBNull(UsuCodigo) Or UsuCodigo = 0 Then
            CodUsuario = 1
            'CodVendedor = 1
            CodCobrador = 1
        Else
            CodUsuario = UsuCodigo
            'CodVendedor = UsuCodigo
            CodCobrador = UsuCodigo
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

    Private Sub CANCELAR()
        varnuevo = 0
        MONEDABindingSource.CancelEdit()
        Me.MONEDATableAdapter.Fill(Me.DsFacturacion.MONEDA, "%")
        grdBuscador_SelectionChanged(Nothing, Nothing)

        DeshabilitaControles()
        DeshabilitaDetalle()
        pasodetalle = 0
    End Sub

    Private Sub DeshabilitaControles()
        txtDesMoneda.Enabled = False
        txtSimbolo.Enabled = False
        txtCantDecimales.Enabled = False
        cbxDecimales.Enabled = False

        txtMultiplicador.Enabled = False
        grdBuscador.Enabled = True

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

    Private Sub DeshabilitaDetalle()
        txtFechaCotizacion.Enabled = False
        txtVentaCotizacion.Enabled = False
        rbtnAgregarCotizacion.Enabled = False
        grdCotizacion.Enabled = False
    End Sub

    Private Sub EliminaDetalleMoneda()
        sql = ""
        sql = " DELETE FROM COTIZACION " & _
        " WHERE CODMONEDA = '" & Me.txtCodMoneda.Text & "'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminaMoneda()
        sql = ""
        sql = " DELETE FROM MONEDA " & _
        " WHERE CODMONEDA = '" & Me.txtCodMoneda.Text & "'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ELIMINAR()
        'Me.pbxAbierto.Visible = False
        'Me.pbxCerrado.Visible = True

        If MessageBox.Show("¿Esta seguro que quiere eliminar la Moneda?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim w As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = w.FuncionConsulta("CODMONEDA", "MONEDA", "CODMONEDA", txtCodMoneda.Text)
        If existe <> 0 Then
            Dim transaction As SqlTransaction = Nothing
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                EliminaDetalleMoneda()
                EliminaMoneda()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "MONEDA", CStr(CodMoneda), "ELIMINACIÓN EN LA TABLA MONEDAS", _
                Today, UsuDescripcion, "NULL", 0, 0, 1)

                myTrans.Commit()
                MessageBox.Show("Moneda eliminada correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DeshabilitaControles()
                MONEDATableAdapter.Fill(DsFacturacion.MONEDA, "%")

            Catch ex As SqlException
                Try
                    myTrans.Rollback("")
                Catch
                End Try
                Dim NroError As Integer = ex.Number
                Dim Mensaje As String = ex.Message
                If NroError = 547 Then
                    MessageBox.Show("El registro que desea eliminar tiene relacion con otra tabla del Sistema", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Ocurrio un error el eliminar los Datos" + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Finally
                sqlc.Close()
            End Try

            DeshabilitaControles()
        End If
    End Sub

    Private Sub GUARDAR()
        '###########################################
        'Se validan los campos que no admiten nulos
        '###########################################
        Dim funcion As New Funciones.Funciones

        CodMoneda = CInt(txtCodMoneda.Text)
        NumMoneda = CStr(txtCodMoneda.Text)

        If txtCantDecimales.Text = "" Then
            Decimales = 0
        Else
            Decimales = txtCantDecimales.Text
        End If
        Imagen = txtImagen.Text

        'Si quiere guardar con algun detalle incompleto
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = funcion.FuncionConsulta("CODMONEDA", "MONEDA", "CODMONEDA", Me.txtCodMoneda.Text)

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
                ActualizaMoneda()
                If grdCotizacion.RowCount = 0 Or txtVentaCotizacion.Text = "0" Or txtVentaCotizacion.Text = "" Then

                Else
                    GUARDARDETALLE()
                    pasodetalle = 0
                End If

                'Si Marco la opcion de moneda principal se debe agregar de forma automatica 1 en la cotizacion
                If vgPrioridad = 1 Then
                    GUARDARDETALLEPRIORIDAD()
                End If

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "MONEDA", CStr(CodMoneda), "MODIFICACIÓN EN LA TABLA MONEDAS", _
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

                MessageBox.Show("Error al Guardar: " & ex.Message, _
                                                      "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                InsertaMoneda()
                'GUARDARDETALLE()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "MONEDA", CStr(CodMoneda), "INSERCIÓN EN LA TABLA MONEDAS", _
                Today, UsuDescripcion, "NULL", 1, 0, 0)

                myTrans.Commit()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", _
                                                       "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception

                myTrans.Rollback("Insertar")

                MessageBox.Show("Error al Guardar: " & ex.Message, _
                                                      "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                sqlc.Close()
            End Try
        End If

        txtVentaCotizacion.Text = "0" : varnuevo = 0
        Try
            'Obtenemos el Nombre de la Moneda Principal
            vgMonedaNombre = f.FuncionConsultaString("DESMONEDA", "MONEDA", "PRIORIDAD", 1)
            Me.MONEDATableAdapter.Fill(Me.DsFacturacion.MONEDA, "%")
            grdBuscador_SelectionChanged(Nothing, Nothing)
        Catch ex As Exception
        End Try
        
        DeshabilitaControles()
    End Sub

    Private Sub GUARDARDETALLE()
        Dim FactorVenta As String = txtVentaCotizacion.Text
        FactorVenta = Funciones.Cadenas.QuitarCad(FactorVenta, ".")
        FactorVenta = Replace(FactorVenta, ",", ".")

        Dim FactorCobro As String = txtVentaCotizacion.Text
        FactorCobro = Funciones.Cadenas.QuitarCad(FactorCobro, ".")
        FactorCobro = Replace(FactorCobro, ",", ".")

        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim fecha As String
        Dim Concat As DateTime = Today
        Dim Concatenar As DateTime = Concat & " " + hora
        fecha = Concatenar.ToString("dd/MM/yyy HH:mm:ss")

        'Try
        sql = ""
        sql = "INSERT INTO [COTIZACION] " & _
        "([FECHAMOVIMIENTO] " & _
        ",[CODMONEDA]   " & _
        ",[CODUSUARIO]  " & _
        ",[CODEMPRESA]  " & _
        ",[FACTORVENTA] " & _
        ",[FACTORCOBRO] " & _
        ",[FECGRA]) " & _
        " VALUES( getdate()" & _
        ", " & txtCodMoneda.Text & _
        ", " & CodUsuario & _
        ", " & CodEmpresa & _
        ", " & FactorVenta & _
        ", " & FactorCobro & _
        ", " & "convert(datetime, '" & fecha & "', 103)" & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub GUARDARDETALLEPRIORIDAD()
        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim fecha As String
        Dim Concat As DateTime = Today
        Dim Concatenar As DateTime = Concat & " " + hora
        fecha = Concatenar.ToString("dd/MM/yyy HH:mm:ss")

        'Try
        sql = ""
        sql = "INSERT INTO [COTIZACION] " & _
        "([FECHAMOVIMIENTO] " & _
        ",[CODMONEDA]   " & _
        ",[CODUSUARIO]  " & _
        ",[CODEMPRESA]  " & _
        ",[FACTORVENTA] " & _
        ",[FACTORCOBRO] " & _
        ",[FECGRA]) " & _
        " VALUES( getdate()" & _
        ", " & txtCodMoneda.Text & _
        ", " & CodUsuario & _
        ", " & CodEmpresa & _
        ", 1, 1 , convert(datetime, '" & fecha & "', 103)" & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub HabilitaControles()
        txtDesMoneda.Enabled = True
        txtSimbolo.Enabled = True
        txtCantDecimales.Enabled = True
        cbxDecimales.Enabled = True

        If txtMultiplicador.Text = " " And vgPrioridad = 0 Then
            txtMultiplicador.Enabled = True
        ElseIf txtMultiplicador.Text = " " And vgPrioridad = 1 Then
            txtMultiplicador.Enabled = False
        Else
            txtMultiplicador.Enabled = True
        End If

        grdBuscador.Enabled = False

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

    Private Sub HabilitaDetalle()
        txtFechaCotizacion.Enabled = True
        txtVentaCotizacion.Enabled = True
        rbtnAgregarCotizacion.Enabled = True
        grdCotizacion.Enabled = True
    End Sub

    Private Sub InicializarDetalle()
        txtFechaCotizacion.Text = Today
        txtVentaCotizacion.Text = 0
    End Sub

    Private Sub InsertaMoneda()
        Dim ultimo As Integer
        Dim codmoneda, UsarDec As Integer

        ultimo = f.Maximo("CODMONEDA", "MONEDA")
        codmoneda = ultimo + 1

        If cbxDecimales.Text = "Si" Then
            UsarDec = 1
        Else
            UsarDec = 0
        End If

        sql = ""
        sql = "INSERT INTO [MONEDA] " & _
        "([CODMONEDA] " & _
        ",[CODUSUARIO] " & _
        ",[CODEMPRESA] " & _
        ",[NUMMONEDA] " & _
        ",[DESMONEDA] " & _
        ",[SIMBOLO] " & _
        ",[FECGRA], CANTIDADDECIMALES) " & _
        ",[PRIORIDAD] " & _
        " VALUES( " & _
        codmoneda & _
        ", " & CodUsuario & _
        ", " & CodEmpresa & _
        ", '" & NumMoneda & _
        "', '" & DesMoneda & _
        "', '" & Simbolo & _
        "'," & UsarDec & _
        ", " & "getdate ()" & _
        "," & vgPrioridad & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub MODIFICAR()
        HabilitaControles()
        HabilitaDetalle()
    End Sub

    Private Sub NUEVO()
        Dim funcion As New Funciones.Funciones
        HabilitaControles()

        MONEDABindingSource.AddNew()
        pbxNuevaFicha.Image = My.Resources.NewActive
        txtDesMoneda.Focus()
    End Sub

    Private Sub pbxCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCancelar.Click
        CANCELAR()
    End Sub

    Private Sub pbxEliminarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEliminarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 92)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para ELIMINAR", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ELIMINAR()
    End Sub


    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxGuardar.Click
        HabilitaDetalle()
        GUARDAR()
    End Sub

    Private Sub pbxModificarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxModificarFicha.Click
        varnuevo = 2
        If txtCodMoneda.Text = "" Then
            Exit Sub
        End If
        permiso = PermisoAplicado(UsuCodigo, 94)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para MODIFICAR", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        MODIFICAR()
        pbxModificarFicha.Image = My.Resources.EditActive
    End Sub

    Private Sub pbxNuevaFichaGris_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxNuevaFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxNuevaFicha.Click
        varnuevo = 1
        permiso = PermisoAplicado(UsuCodigo, 91)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para CREAR una MONEDA", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        cbxDecimales.Text = "No" : txtCantDecimales.Text = "0" : IsNew = 1 : IsEdit = 0 : txtDesMoneda.Text = "" : txtSimbolo.Text = "" : txtMultiplicador.Text = ""
        txtFechaCotizacion.Text = Now()
        HabilitaControles()
        HabilitaDetalle()

        COTIZACIONTableAdapter.Fill(DsFacturacion.COTIZACION, 0)
        Try
            Dim conexion As System.Data.SqlClient.SqlConnection
            conexion = ser.Abrir()
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            Dim consulta As System.String
            Dim Ultimo As Integer
            'Obtenemos el numero mayor registrado en la base de datos y le sumamos 1 para nuestro actual codigo
            Ultimo = f.Maximo("CODMONEDA", "MONEDA")
            CodMoneda = Ultimo + 1

            consulta = "INSERT INTO MONEDA (CODMONEDA) VALUES (" & CodMoneda & ")"
            txtDesMoneda.Focus()
            Consultas.ConsultaComando(myTrans, consulta)
            myTrans.Commit()
        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            End Try
            Throw
        End Try

        MONEDABindingSource.AddNew()
        vgPrioridad = 0 : lblEjemplo.Text = ""
        pbxEnPromocion.Image = My.Resources.star___copia

        pbxNuevaFicha.Image = My.Resources.NewActive
        txtCodMoneda.Text = CodMoneda
    End Sub

    Private Sub rbtnAgregarProductoPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAgregarCotizacion.Click
        permiso = PermisoAplicado(UsuCodigo, 93)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para CAMBIAR la COTIZACION", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        AgregarDetalle()
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "Buscar..." Then
        ElseIf txtBuscar.Text = "" Then
            Me.MONEDATableAdapter.Fill(DsFacturacion.MONEDA, "%")
        Else
            Me.MONEDATableAdapter.Fill(DsFacturacion.MONEDA, "%" + txtBuscar.Text + "%")
        End If
    End Sub

    Private Sub txtCompraCotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then
            'Enter
            AgregarDetalle()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDesMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtSimbolo.Focus()
        End If
    End Sub

    Private Sub txtFechaCotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaCotizacion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtVentaCotizacion.Focus()
        End If
    End Sub

    Private Sub grdBuscador_SelectionChanged(sender As Object, e As System.EventArgs) Handles grdBuscador.SelectionChanged
        If txtCodMoneda.Text <> "" And varnuevo = 0 Then
            Try
                Me.COTIZACIONTableAdapter.Fill(DsFacturacion.COTIZACION, txtCodMoneda.Text)

                Me.txtCantDecimales.Text = f.FuncionConsultaDecimal("CANTIDADDECIMALES", "MONEDA", "CODMONEDA", txtCodMoneda.Text)
                Dim UsarDec As String = f.FuncionConsultaString("DECIMALES", "MONEDA", "CODMONEDA", txtCodMoneda.Text)
                Dim vPrioriad As Integer = Me.grdBuscador.CurrentRow.Cells("PRIORIDADDataGridViewTextBoxColumn").Value
                txtMultiplicador.Text = f.FuncionConsultaString("MULTIPLICADOR", "MONEDA", "CODMONEDA", txtCodMoneda.Text)

                If UsarDec = "True" Then
                    cbxDecimales.Text = "Si"
                Else
                    cbxDecimales.Text = "No"
                End If
                If vPrioriad = 0 Then
                    vgPrioridad = 0
                    pbxEnPromocion.Image = My.Resources.star___copia
                Else
                    vgPrioridad = 1
                    pbxEnPromocion.Image = My.Resources.star
                End If

                txtMultiplicador_SelectedIndexChanged(Nothing, Nothing)

            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region 'Methods

    Private Sub cbxDecimales_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxDecimales.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtCantDecimales.Focus()
        End If
    End Sub

    Private Sub txtCantDecimales_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantDecimales.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtMultiplicador.Focus()
        End If
    End Sub

    Private Sub txtSimbolo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSimbolo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxDecimales.Focus()
        End If
    End Sub

    Private Sub pbxEnPromocion_Click(sender As Object, e As EventArgs) Handles pbxEnPromocion.Click
        'Antes de Marcar como prioridad debemos verificar que no este marcado otro como prioridad
        Dim existePrioridad As Integer = f.FuncionConsultaDecimal("PRIORIDAD", "MONEDA", "PRIORIDAD", 1)

        If existePrioridad = 1 And vgPrioridad = 1 Then
            vgPrioridad = 0 : txtMultiplicador.Enabled = True
            pbxEnPromocion.Image = My.Resources.star___copia

        ElseIf existePrioridad = 0 And vgPrioridad = 0 Then
            vgPrioridad = 1 : txtMultiplicador.Text = " " : txtMultiplicador.Enabled = False
            pbxEnPromocion.Image = My.Resources.star

        ElseIf existePrioridad = 1 And vgPrioridad = 0 Then
            MessageBox.Show("Solo una Moneda puede ser Marcada como Prioridad, Verifique que no exista Otra Moneda como Prioridad", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            vgPrioridad = 0 : txtMultiplicador.Enabled = True
            pbxEnPromocion.Image = My.Resources.star___copia
        End If
    End Sub

    Private Sub txtMultiplicador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMultiplicador.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtFechaCotizacion.Focus()
        End If
    End Sub

    Private Sub txtMultiplicador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtMultiplicador.SelectedIndexChanged
        'Obtenemos la ultima cotizacion
        If grdCotizacion.Rows.Count <> 0 Then
            Dim UltimaCotizacion As Double = CDec(grdCotizacion.Rows(0).Cells("FACTORVENTACOTIZACION").Value)
            Dim CalculoEjemplo As Double = 0

            If txtMultiplicador.Text = "*" Then
                CalculoEjemplo = 100 * UltimaCotizacion

                lblEjemplo.Text = "100 " & vgMonedaNombre & " equivalen a " & CStr(FormatNumber(CalculoEjemplo, 0)) & " " & txtDesMoneda.Text & vbCrLf & _
                                   "100 * " & CStr(FormatNumber(UltimaCotizacion, 0)) & " = " & CStr(FormatNumber(CalculoEjemplo, 0)) & " " & txtDesMoneda.Text
            ElseIf txtMultiplicador.Text = "/" Then
                CalculoEjemplo = 100 / UltimaCotizacion

                lblEjemplo.Text = "100 " & vgMonedaNombre & " equivalen a " & CStr(FormatNumber(CalculoEjemplo, 3)) & " " & txtDesMoneda.Text & vbCrLf & _
                                   "100 / " & CStr(FormatNumber(UltimaCotizacion, 0)) & " = " & CStr(FormatNumber(CalculoEjemplo, 3)) & " " & txtDesMoneda.Text
            Else
                lblEjemplo.Text = ""
            End If

        Else
            If varnuevo <> 0 Then
                MessageBox.Show("Ingrese una Cotizacion para la moneda", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtMultiplicador.Text = " "
                txtFechaCotizacion.Focus()
            End If
        End If
    End Sub

    Private Sub txtVentaCotizacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVentaCotizacion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            rbtnAgregarCotizacion.Focus()
        End If
    End Sub

    Private Sub grdBuscador_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdBuscador.CellContentClick

    End Sub
End Class