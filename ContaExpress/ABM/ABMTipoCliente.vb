Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms


Public Class ABMTipoCliente

#Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand

    '################################################
    'Variable para actualizar e insertar el Movimiento
    '################################################
    Dim CodTipoCliente, CodUsuario, CodEmpresa As Integer
    Dim del As Integer
    Dim NumTipoCliente, PorcentaCliente As Integer
    Dim DestipoCliente As String
    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim FecGra As Date
    'Dim filename As String
    'Dim ins As Integer
    Private myTrans As SqlTransaction
    Dim pri As Integer
    Dim permiso As Double
    '#######################################################################################################################
    Dim prioridad As Integer
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String

    '###############################################
    'Variables de conexion usadas en la transaccion
    '###############################################
    Private sqlc As SqlConnection
    'Dim upd As Integer

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

    Private Sub ABMTipoCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        permiso = PermisoAplicado(UsuCodigo, 100)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        Me.TIPOCLIENTETableAdapter1.Fill(Me.DsSettingFO1.TIPOCLIENTE)
        DeshabilitaControles()
        AsignarValores()

    End Sub

    Private Sub ActualizaPrioridad()
        sql = ""
        sql = "UPDATE TIPOCLIENTE SET PRIORIDAD=" & prioridad & " " & _
        "WHERE CODTIPOCLIENTE = " & CodTipoCliente & ""
        sql = sql + " UPDATE TIPOCLIENTE SET PRIORIDAD=0 " & _
        "WHERE NOT CODTIPOCLIENTE = " & CodTipoCliente & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizaTipoCliente()
        Dim multiplicado As Integer
        If chbxCantMult.Checked = True Then
            multiplicado = 1
        Else
            multiplicado = 0
        End If
        '",[CODPLANCUENTA] = " & CodPlanCuenta & _
        sql = ""
        sql = "UPDATE [TIPOCLIENTE] " & _
        "SET [CODUSUARIO] = " & CodUsuario & _
        ",[CODEMPRESA] = " & CodEmpresa & _
        ",[NUMTIPOCLIENTE] = '" & NumTipoCliente & _
        "',[DESTIPOCLIENTE] = '" & DestipoCliente & _
        "',[CANTMULT] = " & multiplicado & _
        ",[FECGRA] = " & FecGra & _
        ",[PORCENTAJE] = " & PorcentaCliente & _
        ",[PRIORIDAD]=" & prioridad & " WHERE [CODTIPOCLIENTE] = " & CodTipoCliente & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AsignarValores()
        If IsDBNull(UsuCodigo) Or UsuCodigo = 0 Then
            CodUsuario = 1

        Else
            CodUsuario = UsuCodigo

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
        TIPOCLIENTEBindingSource1.CancelEdit()
        'Me.TIPOCLIENTETableAdapter1.Fill(Me.DsSettingFO.TIPOCLIENTE)
        Me.TIPOCLIENTETableAdapter1.Fill(Me.DsSettingFO1.TIPOCLIENTE)
        DeshabilitaControles()
    End Sub

    Private Sub DeshabilitaControles()
        tbxListaPrecio.Enabled = False
        txtProcVenta.Enabled = False

        pbxNuevaFicha.Enabled = True
        pbxNuevaFicha.Image = My.Resources.New_
        pbxNuevaFicha.Cursor = Cursors.Hand
        pbxEliminarFicha.Enabled = True
        pbxEliminarFicha.Image = My.Resources.Delete
        pbxEliminarFicha.Cursor = Cursors.Hand
        pbxModificarFicha.Enabled = True
        pbxModificarFicha.Image = My.Resources.Edit
        pbxModificarFicha.Cursor = Cursors.Hand

        pbxGuardar.Enabled = False
        pbxGuardar.Image = My.Resources.SaveOff
        pbxGuardar.Cursor = Cursors.Arrow
        pbxGuardar.Enabled = False
        pbxCancelar.Image = My.Resources.SaveCancelOff
        pbxCancelar.Cursor = Cursors.Arrow
        pbxCancelar.Enabled = False
    End Sub

    Private Sub ELIMINAR()
        If MessageBox.Show("¿Esta seguro que quiere eliminar esta Lista de Precio?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer = 0
        Dim Variable As Integer = 0
        txtCodTipoCliente.Refresh()
        existe = funcion.FuncionConsulta("CODTIPOCLIENTE", "TIPOCLIENTE", "CODTIPOCLIENTE", Me.txtCodTipoCliente.Text)
        If existe <> 0 Then
            Dim transaction As SqlTransaction = Nothing
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                EliminaTipoCliente()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                'CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                'Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "TIPOCLIENTE", CStr(CodTipoCliente), "ELIMINACIÓN EN LA TABLA TIPO DE CLIENTES", _
                'Today, UsuDescripcion, "NULL", 0, 0, 1)

                myTrans.Commit()

                MessageBox.Show("Tipo Cliente eliminado correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DeshabilitaControles()
                grdBuscador.Refresh()
                TIPOCLIENTETableAdapter1.Fill(DsSettingFO1.TIPOCLIENTE)

            Catch ex As Exception
                'Try
                '    myTrans.Rollback("Eliminar")
                'Catch
                'End Try
                'MessageBox.Show("Ocurrio un error el eliminar el Tipo Cliente" + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MessageBox.Show("No se puede eliminar el registro en cascada", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                myTrans.Rollback("Eliminar")
            Finally
                sqlc.Close()
            End Try

            DeshabilitaControles()
        End If
    End Sub

    Private Sub EliminaTipoCliente()
        sql = ""
        sql = " DELETE FROM TIPOCLIENTE " & _
        " WHERE CODTIPOCLIENTE = '" & Me.txtCodTipoCliente.Text & "'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
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
        If txtProcVenta.Text = "" Then
            txtProcVenta.Text = 0
        End If
        CodTipoCliente = CInt(txtCodTipoCliente.Text)
        NumTipoCliente = CStr(txtCodTipoCliente.Text)
        PorcentaCliente = CInt(txtProcVenta.Text)
        If PRIORIDADCheckBox.Checked = True Then
            prioridad = 1
        Else
            prioridad = 0
        End If

        If tbxListaPrecio.Text = "" Then
            MessageBox.Show("Descripcion para la Lista de Precio es Obligatorio", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxListaPrecio.Focus()
            Exit Sub
        Else
            DestipoCliente = tbxListaPrecio.Text
            PorcentaCliente = txtProcVenta.Text
        End If

        FecGra = Today

        'Si quiere guardar con algun detalle incompleto
        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = funcion.FuncionConsulta("CODTIPOCLIENTE", "TIPOCLIENTE", "CODTIPOCLIENTE", Me.txtCodTipoCliente.Text)

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
                ActualizaTipoCliente()
                If prioridad = 1 Then
                    ActualizaPrioridad()
                End If
                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "TIPOCLIENTE", CStr(CodTipoCliente), "MODIFICACIÓN EN LA TABLA TIPO DE CLIENTES", _
                Today, UsuDescripcion, "NULL", 0, 1, 0)

                myTrans.Commit()
                DeshabilitaControles()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Error al Guardar: " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                InsertaTipoCliente()
                If prioridad = 1 Then
                    ActualizaPrioridad()
                End If
                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "TIPOCLIENTE", CStr(CodTipoCliente), "INSERCIÓN EN LA TABLA TIPO DE CLIENTES", _
                Today, UsuDescripcion, "NULL", 1, 0, 0)

                myTrans.Commit()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                myTrans.Rollback("Insertar")

                MessageBox.Show("Error al Guardar: " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                sqlc.Close()
            End Try

        End If

        Try
            Dim I As Integer = TIPOCLIENTEBindingSource1.Position
            Me.TIPOCLIENTETableAdapter.Fill(Me.DsSettingFO.TIPOCLIENTE)
            TIPOCLIENTEBindingSource1.Position = I

        Catch ex As Exception
        End Try
        DeshabilitaControles()
    End Sub

    Private Sub HabilitaControles()
        tbxListaPrecio.Enabled = True
        txtProcVenta.Enabled = True

        pbxNuevaFicha.Enabled = False
        pbxNuevaFicha.Image = My.Resources.NewOff
        pbxNuevaFicha.Cursor = Cursors.Arrow
        pbxEliminarFicha.Enabled = False
        pbxEliminarFicha.Image = My.Resources.DeleteOff
        pbxEliminarFicha.Cursor = Cursors.Arrow
        pbxModificarFicha.Enabled = False
        pbxModificarFicha.Image = My.Resources.EditOff
        pbxModificarFicha.Cursor = Cursors.Arrow

        pbxGuardar.Enabled = True
        pbxGuardar.Image = My.Resources.Save
        pbxGuardar.Cursor = Cursors.Hand
        pbxGuardar.Enabled = True
        pbxCancelar.Image = My.Resources.SaveCancel
        pbxCancelar.Cursor = Cursors.Hand
        pbxCancelar.Enabled = True
    End Sub

    Private Sub InsertaTipoCliente()
        Dim multiplicado As Integer
        If chbxCantMult.Checked = True Then
            multiplicado = 1
        Else
            multiplicado = 0
        End If
        sql = ""
        sql = "INSERT INTO [TIPOCLIENTE] " & _
        "([CODTIPOCLIENTE] " & _
        ",[CODUSUARIO] " & _
        ",[CODEMPRESA] " & _
        ",[NUMTIPOCLIENTE] " & _
        ",[DESTIPOCLIENTE] " & _
        ",[FECGRA] " & _
        ",[PRIORIDAD] " & _
        ",[CANTMULT] " & _
        ",[PORCENTAJE]) " & _
        " VALUES(" & _
        CodTipoCliente & _
        ", " & CodUsuario & _
        ", " & CodEmpresa & _
        ", '" & NumTipoCliente & _
        "', '" & DestipoCliente & _
        "', " & "convert(datetime, '" & Today() & "', 103)" & _
        ", '" & prioridad & "'," & multiplicado & "," & PorcentaCliente & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub


    Private Sub NUEVO()
        Dim funcion As New Funciones.Funciones
        TIPOCLIENTEBindingSource1.AddNew()
        Me.txtCodTipoCliente.Text = funcion.Maximo("CODTIPOCLIENTE", "TIPOCLIENTE") + 1
        tbxListaPrecio.Focus()
    End Sub

    Private Sub pbxCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCancelar.Click
        CANCELAR()
    End Sub

    Private Sub pbxEliminarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEliminarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 102)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar registros en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ELIMINAR()

    End Sub

    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxGuardar.Click
        GUARDAR()

    End Sub

    Private Sub pbxModificarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxModificarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 103)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar registros en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        HabilitaControles()
    End Sub


    Private Sub pbxNuevaFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxNuevaFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 101)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        tbxListaPrecio.Focus()
        NUEVO()
        PRIORIDADCheckBox.Checked = False
        chbxCantMult.Checked = False
        HabilitaControles()
    End Sub

    Private Sub PRIORIDADCheckBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PRIORIDADCheckBox.Click
        If PRIORIDADCheckBox.Checked = False Then
            MessageBox.Show("Solo se puede deshabilitar habilitando otra opción", "POSEXPRESS")
            PRIORIDADCheckBox.Checked = True
        End If
    End Sub


#End Region 'Methods

    Private Sub grdBuscador_SelectionChanged(sender As Object, e As System.EventArgs)
        If grdBuscador.RowCount <> 0 Then
            Dim mult As String
            'HICE ASI PORQUE AL EDITAR EL DATASET ME DIO PROBLEMAS
            mult = funcion.FuncionConsultaString("CANTMULT", "TIPOCLIENTE", "CODTIPOCLIENTE", txtCodTipoCliente.Text)
            If mult = "True" Then
                chbxCantMult.Checked = True
            Else
                chbxCantMult.Checked = False
            End If
        End If
    End Sub
End Class

