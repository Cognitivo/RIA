Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class ABMCaja
    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim sel As Integer
    Dim ins As Integer
    Dim upd As Integer
    Dim del As Integer
    Dim pri As Integer
    Dim anu As Integer
    Dim CodUsuarioCobrador As String
    Dim cajacobrador As Boolean
    Dim permiso As Double
    Dim Ctrl, N, G, T, D As Boolean
    Dim f As New Funciones.Funciones

#Region "Load de la Ventana"
    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub ABMCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 62)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "PosExpress")
            Me.Close()
        End If

        Me.USUARIOTableAdapter.Fill(Me.DsSettingFO.USUARIO)
        Me.SUCURSALTableAdapter.Fill(Me.DsSettingFO.SUCURSAL)

        Try
            Me.CAJATableAdapter.Fill(Me.DsSettingFO.CAJA)
        Catch ex As Exception
        End Try
        cajacobrador = True

        DeshabilitaControles()
        AsignarValores()
        Windows.Forms.Application.DoEvents()
    End Sub
   
#End Region

#Region "Se definen las variables que se usaran en la pantalla"
    '################################################
    'Variable para actualizar e insertar el Movimiento
    '################################################
    Dim NumCaja, CodUsuario, CodEmpresa, CodSucursal, CodPlanCuenta, CodCobrador As Integer
    Dim NumeroCaja As String
    Dim FecGra As Date

    '###############################################
    'Variables de conexion usadas en la transaccion
    '###############################################
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Dim filename As String

    Private Sub AsignarValores()
        If IsDBNull(UsuCodigo) Or UsuCodigo = 0 Then
            CodUsuario = 1
            'CodVendedor = 1
            CodCobrador = 1
            'UsuGra = 1
        Else
            CodUsuario = UsuCodigo
            CodCobrador = UsuCodigo
        End If

        If IsDBNull(EmpCodigo) Or EmpCodigo = 0 Then
            CodEmpresa = 1
        Else
            CodEmpresa = EmpCodigo
        End If

     
    End Sub
#End Region

#Region "Habilitar y Deshabilitar controles"
    Private Sub HabilitaControles()
        If cajacobrador = True Then
            txtNumeroCaja.Enabled = True
            cboSucursal.Enabled = True
        End If

        grdBuscador.Enabled = False
        cbxContabilidad.Enabled = True

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

        btnGenerarApertura.Enabled = True
    End Sub

    Private Sub DeshabilitaControles()
        If cajacobrador = True Then
            txtNumeroCaja.Enabled = False
            cboSucursal.Enabled = False
        End If

        grdBuscador.Enabled = True
        cbxContabilidad.Enabled = False

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

        btnGenerarApertura.Enabled = False
    End Sub

#End Region


#Region "Rutinas para Agregar, Modificar Datos a la tabla"


    Private Sub NUEVO()
        Dim funcion As New Funciones.Funciones
      
        If cajacobrador = True Then
            HabilitaControles()
            CAJABindingSource.AddNew()
            txtNumeroCaja.Focus()
        Else
            NuevoCobrador()
        End If

    End Sub
    Private Sub NuevoCobrador()
        LabelNroCobrador.Text = ""
        HabilitaControles()
        Cobrador1BindingSource.AddNew()
        txtNumeroCaja.Focus()
    End Sub


    Private Sub MODIFICAR()
        HabilitaControles()
    End Sub


    Private Sub CANCELAR()
 
        If cajacobrador = True Then
            CAJABindingSource.CancelEdit()
            Me.CAJATableAdapter.Fill(Me.DsSettingFO.CAJA)
        Else
            Cobrador1BindingSource.CancelEdit()
            COBRADORTableAdapter.Fill(DsSettingFO.COBRADOR)
        End If
        DeshabilitaControles()
    End Sub

    Private Sub GUARDAR()
        NumCaja = 0

        If txtNumeroCaja.Text = "" Then
            MessageBox.Show("Descripción de Caja es obligatorio, por favor introduzca ese dato", "POSEXPRESS")
            txtNumeroCaja.Focus()
            Exit Sub
        Else
            NumeroCaja = txtNumeroCaja.Text
        End If

        If cboSucursal.Text = "" Then
            MessageBox.Show("Sucursal es obligatorio, por favor seleccione sucursal", "POSEXPRESS")
            cboSucursal.Focus()
            Exit Sub
        Else
            CodSucursal = cboSucursal.SelectedValue
        End If

        CodPlanCuenta = 1

        FecGra = Today

        'Si quiere guardar con algun detalle incompleto
        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = funcion.FuncionConsulta("NUMCAJA", "CAJA", "NUMCAJA", Me.txtNumCaja.Text)

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
                ActualizaCaja()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "CAJA", CStr(NumCaja), "MODIFICACIÒN EN LA TABLA CAJA", _
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

                MessageBox.Show("Ocurrio un error al intentar actualizar la Caja", _
                                                      "POSEXPRESS")
            Finally
                sqlc.Close()

            End Try
        Else
            NumCaja = f.Maximo("NUMCAJA", "CAJA")
            NumCaja = NumCaja + 1

            '########################################
            'INSERTAR: si el codigo es nuevo inserta
            '########################################
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaCaja()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "CAJA", CStr(NumCaja), "INSERCIÓN EN LA TABLA CAJA", _
                Today, 1, "NULL", 1, 0, 0)

                myTrans.Commit()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

            Catch ex As Exception
                myTrans.Rollback("Insertar")
                MessageBox.Show("Ocurrió un error al insertar la Caja", "POSEXPRESS")
            Finally
                sqlc.Close()
            End Try

        End If

        If MessageBox.Show("¿Desea Genera una Apertura para Esta Cuenta?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
        Else
            InsertarApertura()
        End If

        Try
            Me.CAJATableAdapter.Fill(Me.DsSettingFO.CAJA)
        Catch ex As Exception
        End Try

        DeshabilitaControles()
    End Sub
   
    Private Sub InsertaCaja()
        Dim Contabilidad As Integer

        If cbxContabilidad.Checked = True Then
            Contabilidad = 1
        Else
            Contabilidad = 0
        End If

        sql = ""
        sql = " INSERT INTO [CAJA] " & _
        "([NUMCAJA] " & _
        ",[NUMEROCAJA] " & _
        ",[CODSUCURSAL] " & _
        ",[CODUSUARIO] " & _
        ",[CODEMPRESA] " & _
        ",[CONTABILIDAD] " & _
        ",[FECGRA]) " & _
        " VALUES(" & NumCaja & _
        ", '" & NumeroCaja & _
        "', " & CodSucursal & _
        ", " & CodUsuario & _
        ", " & CodEmpresa & _
        ", " & Contabilidad & _
        ", " & "convert(datetime, '" & Today() & "', 103)" & ")  "

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub
   

    Private Sub ActualizaCaja()

        Dim Contabilidad As Integer

        
        If cbxContabilidad.Checked = True Then
            Contabilidad = 1
        Else
            Contabilidad = 0
        End If

        sql = ""
        sql = "UPDATE [CAJA] " & _
        "SET [NUMEROCAJA] = '" & NumeroCaja & _
        "',[CODSUCURSAL] = " & CodSucursal & _
        ",[CODUSUARIO] = " & CodUsuario & _
        ",[CODEMPRESA] = " & CodEmpresa & _
        ",[CONTABILIDAD] = " & Contabilidad & _
        ",[FECGRA] =  " & "convert(datetime, '" & Today & "', 103)" & _
        " WHERE [NUMCAJA] =  " & txtNumCaja.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub
  
#End Region

#Region "Eliminar registro de la tabla"

    Private Sub ELIMINAR()

        If MessageBox.Show("¿Esta seguro que quiere ELIMINAR esta Caja?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer
        If cajacobrador = True Then
            existe = funcion.FuncionConsulta("NUMCAJA", "CAJA", "NUMCAJA", Me.txtNumCaja.Text)
            If existe <> 0 Then
                Dim transaction As SqlTransaction = Nothing
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

                cmd.Connection = sqlc
                cmd.Transaction = myTrans

                Try
                    EliminaCaja()
                    '############################
                    'INSERCION DE LAS AUDITORIAS
                    '############################
                    CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                    Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "CAJA", CodigoAudi.ToString, "ELIMINACIÓN EN LA TABLA CAJA", _
                    Today, UsuDescripcion, "NULL", 0, 0, 1)

                    myTrans.Commit()

                    MessageBox.Show("Caja Eliminada correctamente", "POSEXPRESS")
                    DeshabilitaControles()
                    CAJATableAdapter.Fill(DsSettingFO.CAJA)

                Catch ex As Exception
                    Try
                        myTrans.Rollback("")
                    Catch
                    End Try
                    MessageBox.Show("Error al Eliminar Caja: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Finally
                    sqlc.Close()
                End Try
                DeshabilitaControles()
            End If
           
        End If
    End Sub

    Private Sub EliminaCaja()
        sql = ""
        sql = " DELETE FROM CAJA " & _
        " WHERE NUMCAJA = '" & Me.txtNumCaja.Text & "'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub
   
#End Region

#Region "Click de las Imagenes"
    Private Sub pbxNuevaFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxNuevaFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 63)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para CREAR una Nueva Cuenta", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            NUEVO()
            btnGenerarApertura.Enabled = False
            pbxNuevaFicha.Image = My.Resources.NewActive
        End If

    End Sub

    Private Sub pbxModificarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxModificarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 64)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para MODIFICAR", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        MODIFICAR()

        'Si la Cuenta ya posee una apertura bloqueamos el boton para que no pueda generar otra apertura paralela
        Dim ExisteApertura As Integer
        ExisteApertura = f.FuncionConsultaDecimal("id_caja", "aperturas", "id_caja", grdBuscador.CurrentRow.Cells("NUMCAJA").Value)
        If ExisteApertura <> 0 Then
            btnGenerarApertura.Enabled = False
        End If

        pbxModificarFicha.Image = My.Resources.EditActive
    End Sub

    Private Sub pbxEliminarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEliminarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 65)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para ELIMINAR", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            ELIMINAR()
        End If

    End Sub

    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxGuardar.Click
        GUARDAR()
        
    End Sub

    Private Sub pbxCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCancelar.Click
        CANCELAR()
    End Sub
#End Region


#Region "KeyDown - KeyPress"

    Private Sub cboSucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSucursal.KeyPress
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
#End Region

    Private Sub txtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        txtBuscar.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtBuscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.LostFocus
        txtBuscar.BackColor = Color.Gray
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "Buscar..." Then
        Else
            Try
                Dim Filtro As New FilterExpression()
                Filtro.Predicates.Add(FilterExpression.BinaryOperation.[OR], GridKnownFunction.Contains, GridFilterCellElement.ParameterName)
                Filtro.Parameters.Add(GridFilterCellElement.ParameterName, txtBuscar.Text)
                Me.grdBuscador.Columns("NUMEROCAJA").Filter = Filtro
            Catch ex As Exception
            End Try

        End If
    End Sub

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

    '    Select Case keyData
    '        Case Keys.Delete
    '            ELIMINAR()
    '        Case Else
    '            Return MyBase.ProcessCmdKey(msg, keyData)
    '    End Select

    'End Function

    Private Sub grdBuscador_SelectionChanged(sender As Object, e As System.EventArgs) Handles grdBuscador.SelectionChanged
        If grdBuscador.RowCount <> 0 Then
            Dim Contabilidad As Integer = f.FuncionConsultaDecimal("CONTABILIDAD", "CAJA", "NUMCAJA", txtNumCaja.Text)

            If Contabilidad = 0 Then
                cbxContabilidad.Checked = False
            Else
                cbxContabilidad.Checked = True
            End If
        End If
    End Sub

    Private Sub btnGenerarApertura_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarApertura.Click
        NumCaja = Me.txtNumCaja.Text
        InsertarApertura()
    End Sub

    Private Sub InsertarApertura()
        Dim sql As String
        Dim MaxApertura, MaxAperturaDet As Integer

        MaxApertura = f.Maximo("id_apertura", "aperturas")
        MaxApertura = MaxApertura + 1

        MaxAperturaDet = f.Maximo("id_apertura_det", "aperturas_det")
        MaxAperturaDet = MaxAperturaDet + 1

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            sql = ""
            sql = "INSERT INTO aperturas (id_apertura,fechapaertura,id_usuario,id_caja,apertura_num,codsucursal) " & _
                  "VALUES (" & MaxApertura & ",GETDATE()," & UsuCodigo & "," & NumCaja & "," & MaxApertura & "," & cboSucursal.SelectedValue & ")   " & _
                  "INSERT aperturas_det (id_apertura_det,id_apertura,id_tipo_dinero,monto,id_moneda) VALUES (" & MaxAperturaDet & "," & MaxApertura & ",1,0,1)"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            MessageBox.Show("Apertura Realizada Correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnGenerarApertura.Enabled = False

        Catch ex As Exception
            myTrans.Rollback("Actualizar")
        End Try
    End Sub
End Class