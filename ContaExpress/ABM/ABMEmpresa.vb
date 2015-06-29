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
Imports Telerik.WinControls.UI

Public Class ABMEmpresa
    Dim f As New Funciones.Funciones
#Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand

    '#######################################################################################################################
    '################################################
    'Variable para actualizar e insertar el Movimiento
    '################################################
    Dim CodEmpresa, UsuGra, Retentor, CodUsuario, CodVendedor, CodSucursal As Integer
    Dim del As Integer

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim FecGra As Date
    Dim filename As String
    Dim ins As Integer
    Private myTrans As SqlTransaction
    Dim NomFantasia, NomContribuyente, RUCContribuyente, DesEmpresa, Direccion, Telefono, Email, NumRegPatronal, NomRepresentante, CodGNU As String
    Dim PorRetencio, PorcRetRenta As String
    Dim pri As Integer
    Dim RucRepresentante, Localidad, NumRegistro As String
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Dim Permiso As Double

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
    Private Sub ABMEmpresa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub ABMEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Permiso = PermisoAplicado(UsuCodigo, 1)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permisos para abrir esta ventana", "PosExpress")
            Me.Close()

        End If
        Me.AUDITORIATABLASTableAdapter.Fill(Me.DsFacturacion.AUDITORIATABLAS)
        Me.EMPRESATableAdapter.Fill(Me.DsFacturacion.EMPRESA, "%", "%")
        Me.EMPRESATableAdapter1.Fill(Me.DsEmpresa.EMPRESA)
        Dim consulta As String

        ' DeshabilitaControles()
        AsignarValores()
        consulta = f.FuncionConsultaString("EXPORTADOR", "EMPRESA", "CODEMPRESA", CodEmpresa)
        If consulta = "Si" Then
            cmbExportador.Text = "Si"
        Else
            cmbExportador.Text = "No"
        End If

    End Sub

    Private Sub ActualizaEmpresa()
        sql = ""
        sql = "UPDATE [EMPRESA] " & _
        "SET [USUGRA] =  " & UsuGra & _
        ",[NOMFANTASIA] =  '" & NomFantasia & _
        "',[NOMCONTRIBUYENTE] =  '" & NomContribuyente & _
        "',[RUCCONTRIBUYENTE] =  '" & RUCContribuyente & _
        "',[DESEMPRESA] =  '" & DesEmpresa & _
        "',[DIRECCION] =  '" & Direccion & _
        "',[TELEFONO] =  '" & Telefono & _
        "',[EMAIL] =  '" & Email & _
        "',[NUMREGPATRONAL] =  '" & NumRegPatronal & _
        "',[RETENTOR] =  " & Retentor & _
        ",[NOMREPRESENTANTE] =  '" & NomRepresentante & _
        "',[RUCREPRESENTANTE] =  '" & RucRepresentante & _
        "',[FECGRA] =  " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & _
        ",[LOCALIDAD] =  '" & Localidad & _
        "',[NUMREGISTRO] =  '" & NumRegistro & _
        "',[PORRETENCIO] =  " & PorRetencio & _
        ",[PORCRETRENTA] =  " & PorcRetRenta & _
        ",[CARPETACOMPARTIDA] =  '" & CarpetaComTextBox.Text & "' " & _
        ",[CODGNU] = '" & CodGNU & "' " & _
        ",[LOGOTIPO]='" & LOGOTIPOTextBox.Text & "',[EXPORTADOR]='" & cmbExportador.SelectedText & "' WHERE [CODEMPRESA] =  " & CodEmpresa & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AsignarValores()
        If IsDBNull(UsuCodigo) Or UsuCodigo = 0 Then
            CodUsuario = 1
            CodVendedor = 1
            CodCobrador = 1
            UsuGra = 1
        Else
            CodUsuario = UsuCodigo
            CodVendedor = UsuCodigo
            CodCobrador = UsuCodigo
            UsuGra = UsuCodigo
        End If

        If IsDBNull(EmpCodigo) Or EmpCodigo = 0 Then
            CodEmpresa = 1
        Else
            CodEmpresa = EmpCodigo
        End If

        If IsDBNull(SucCodigo) Or SucCodigo = 0 Then
            CodSucursal = 1
        Else
            CodSucursal = EmpCodigo
        End If
    End Sub

    'Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
    '    CANCELAR()
    'End Sub
    Private Sub CANCELAR()
        'Me.pbxAbierto.Visible = False
        'Me.pbxCerrado.Visible = True
        EMPRESABindingSource.CancelEdit()
        Me.EMPRESATableAdapter.Fill(Me.DsFacturacion.EMPRESA, "%", "%")
        '  DeshabilitaControles()
    End Sub



    Private Sub CarpetaComTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarpetaComTextBox.GotFocus

    End Sub

    Private Sub CarpetaComTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarpetaComTextBox.TextChanged
    End Sub

    Private Sub chkRetentor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRetentor.GotFocus

    End Sub

    Private Sub chkRetentor_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles chkRetentor.ToggleStateChanged
        If chkRetentor.Checked = True Then
            txtPorRetencion.Enabled = True
            umePorcRetRenta.Enabled = True
        Else
            txtPorRetencion.Enabled = False
            umePorcRetRenta.Enabled = False
        End If
    End Sub

    Private Sub ConfCarpetaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfCarpetaButton.Click
        Try
            ' Configuración del FolderBrowserDialog
            With (FolderBrowserDialog1)

                .RootFolder = Environment.SpecialFolder.DesktopDirectory
                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                ' si se presionó el botón aceptar ...
                If ret = Windows.Forms.DialogResult.OK Then
                    ' MsgBox("Ruta seleccionada : " & .SelectedPath, MsgBoxStyle.Information)
                End If
                CarpetaComTextBox.Text = .SelectedPath

                ' Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DeshabilitaControles()
        txtNomFantasia.Enabled = False
        txtDesEmpresa.Enabled = False
        txtDireccion.Enabled = False
        txtTelefono.Enabled = False
        txtEmail.Enabled = False
        txtLocalidad.Enabled = False
        txtNomContribuyente.Enabled = False
        txtRUCContribuyente.Enabled = False
        txtNumRegPatronal.Enabled = False
        chkRetentor.Enabled = False
        txtNomRepresentante.Enabled = False
        txtRUCRepresentante.Enabled = False
        txtNroRegistro.Enabled = False
        txtPorRetencion.Enabled = False
        umePorcRetRenta.Enabled = False
        'Panel1.BringToFront()
        'Panel2.SendToBack()

        'Deshabilita los botones de Guardar y Cancelar
        'BtnGuardar.Visible = False
        'pbxGuardar.Visible = False
        'pbxGuardarGris.Visible = True
        'BtnCancelar.Visible = False
        'pbxCancelar.Visible = False
        'pbxCancelarGris.Visible = True

        'boton conf carpetan
        ConfCarpetaButton.Enabled = False
    End Sub

    Private Sub EliminaEmpresa()
        sql = ""
        sql = " DELETE FROM EMPRESA " & _
        " WHERE CODEMPRESA = '" & Me.txtCodEmpresa.Text & "'"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    'Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
    '    ELIMINAR()
    'End Sub
    Private Sub ELIMINAR()
        'Me.pbxAbierto.Visible = False
        'Me.pbxCerrado.Visible = True

        If MessageBox.Show("¿Esta seguro que quiere eliminar la Empresa?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim w As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = w.FuncionConsulta("CODEMPRESA", "EMPRESA", "CODEMPRESA", Me.txtCodEmpresa.Text)
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
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "EMPRESA", CStr(CodEmpresa), "Baja en la Tabla", _
                Today, 1, "NULL", 0, 0, 1)

                myTrans.Commit()

                MessageBox.Show("Empresa eliminada correctamente", "POSEXPRESS")
                DeshabilitaControles()
                EMPRESATableAdapter.Fill(DsFacturacion.EMPRESA, "%", "%")

            Catch ex As Exception
                Try
                    myTrans.Rollback("")
                Catch
                End Try
                MessageBox.Show("Ocurrio un error el eliminar la Empresa" + ex.Message, "POSEXPRESS")
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
        CodEmpresa = txtCodEmpresa.Text

        If txtNomFantasia.Text = "" Then
            MessageBox.Show("Nombre de Fantasía es obligatorio, por favor introduzca ese dato", "POSEXPRESS")
            txtNomFantasia.Focus()
            Exit Sub
        Else
            NomFantasia = txtNomFantasia.Text
        End If

        If txtNomContribuyente.Text = "" Then
            NomContribuyente = ""
        Else
            NomContribuyente = txtNomContribuyente.Text
        End If

        If txtRUCContribuyente.Text = "" Then
            RUCContribuyente = ""
        Else
            RUCContribuyente = txtRUCContribuyente.Text
        End If

        If txtDesEmpresa.Text = "" Then
            DesEmpresa = ""
        Else
            DesEmpresa = txtDesEmpresa.Text
        End If

        If txtDireccion.Text = "" Then
            Direccion = ""
        Else
            Direccion = txtDireccion.Text
        End If

        If txtTelefono.Text = "" Then
            Telefono = ""
        Else
            Telefono = txtTelefono.Text
        End If

        If txtCodGNU.Text = "" Then
            CodGNU = ""
        Else
            CodGNU = Me.txtCodGNU.Text
        End If

        If CarpetaComTextBox.Text = "" Then
            If MessageBox.Show("Se recomienda que elija una Carpeta Compartida para guardar sus imágenes y archivos, " & _
                                                      "¿Desea continuar de todos modos?", "POS EXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                ConfCarpetaButton.Focus()
                Exit Sub
            End If
        End If

        If txtEmail.Text = "" Then
            Email = ""
        Else
            Email = txtEmail.Text
        End If

        If txtNumRegPatronal.Text = "" Then
            NumRegPatronal = ""
        Else
            NumRegPatronal = txtNumRegPatronal.Text
        End If

        If chkRetentor.Checked = True Then
            Retentor = 1
        Else
            Retentor = 0
        End If

        If txtNomRepresentante.Text = "" Then
            NomRepresentante = ""
        Else
            NomRepresentante = txtNomRepresentante.Text
        End If

        If txtRUCRepresentante.Text = "" Then
            RucRepresentante = ""
        Else
            RucRepresentante = txtRUCRepresentante.Text
        End If

        If txtLocalidad.Text = "" Then
            Localidad = ""
        Else
            Localidad = txtLocalidad.Text
        End If

        If txtNroRegistro.Text = "" Then
            NumRegistro = ""
        Else
            NumRegistro = txtNroRegistro.Text
        End If

        If txtPorRetencion.Text = "" Then
            PorRetencio = 0
        Else
            PorRetencio = CDec(txtPorRetencion.Text)
            PorRetencio = Funciones.Cadenas.QuitarCad(PorRetencio, ".")
            PorRetencio = Replace(PorRetencio, ",", ".")
        End If

        If umePorcRetRenta.Text = "" Then
            PorcRetRenta = 0
        Else
            PorcRetRenta = CDec(umePorcRetRenta.Text)
            PorcRetRenta = Funciones.Cadenas.QuitarCad(PorcRetRenta, ".")
            PorcRetRenta = Replace(PorcRetRenta, ",", ".")
        End If

        'Si quiere guardar con algun detalle incompleto
        Dim funcion As New Funciones.Funciones
        Dim existe As Integer
        Dim CodigoAudi As Integer
        Dim Variable As Integer

        existe = funcion.FuncionConsulta("CODEMPRESA", "EMPRESA", "CODEMPRESA", Me.txtCodEmpresa.Text)

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
                ActualizaEmpresa()

                ''############################
                ''INSERCION DE LAS AUDITORIAS
                ''############################
                'CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                'Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, EmpCodigo, "EMPRESA", CStr(CodigoAudi), "Modificación en la Tabla", _
                'Today, UsuDescripcion, UsuNivel, 0, 1, 0)
                myTrans.Commit()
                '############################################# - AUDITORIA TABLAS - ##########################################
                Dim c As New Funciones.Funciones
                Dim codigo As Integer = c.Maximo("CODIGO", "auditoriatablas")
                If codigo = 0 Then
                    codigo = 1
                Else
                    codigo = codigo + 1
                End If

                Me.AUDITORIATABLASTableAdapter.Insert(codigo, EmpCodigo, "EMPRESA", codigo.ToString, "MODIFICACION DE EMPRESA", _
                                                     Today(), UsuDescripcion, UsuNivel, 0, 1, 0)

                '###############################################################################################################

                Dim Indice As Integer = EMPRESABindingSource.Position
                Me.EMPRESATableAdapter.Fill(Me.DsFacturacion.EMPRESA, "%", "%")
                EMPRESABindingSource.Position = Indice

                MessageBox.Show("El proceso de grabación ha finalizado correctamente", _
                                                       "POS EXPRESS")
                ' DeshabilitaControles()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try

                MessageBox.Show("Ocurrio un error al intentar actualizar la Empresa", _
                                                      "POS EXPRESS")
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
                InsertaEmpresa()

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, 1, "EMPRESA", CStr(CodEmpresa), "INSERCIÓN EN LA TABLA EMPRESA", _
                Today, 1, "NULL", 1, 0, 0)

                myTrans.Commit()
                Me.EMPRESATableAdapter.Fill(Me.DsFacturacion.EMPRESA, "%", "%")
                EMPRESABindingSource.MoveLast()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", _
                                                       "POSEXPRESS")
            Catch ex As Exception
                myTrans.Rollback("Insertar")

                MessageBox.Show("Ocurrió un error al insertar la Empresa", _
                                                       "POSEXPRESS")
            Finally
                sqlc.Close()
            End Try

        End If
        'DeshabilitaControles()
    End Sub

    Private Sub HabilitaControles()
        txtNomFantasia.Enabled = True
        txtDesEmpresa.Enabled = True
        txtDireccion.Enabled = True
        txtTelefono.Enabled = True
        txtEmail.Enabled = True
        txtLocalidad.Enabled = True
        txtNomContribuyente.Enabled = True
        txtRUCContribuyente.Enabled = True
        txtNumRegPatronal.Enabled = True
        chkRetentor.Enabled = True
        txtNomRepresentante.Enabled = True
        txtRUCRepresentante.Enabled = True
        txtNroRegistro.Enabled = True
        txtPorRetencion.Enabled = True

        'Panel1.SendToBack()
        'Panel2.BringToFront()

        'Habilita los botones de Guardar y Cancelar
        'BtnGuardar.Visible = True
        'pbxGuardar.Visible = True
        'pbxGuardarGris.Visible = False
        'BtnCancelar.Visible = True
        'pbxCancelar.Visible = True
        'pbxCancelarGris.Visible = False

        'boton conf carpetan
        ConfCarpetaButton.Enabled = True
    End Sub

    Private Sub InsertaEmpresa()
        sql = ""
        sql = "INSERT INTO [EMPRESA] " & _
           "([CODEMPRESA] " & _
           ",[USUGRA] " & _
           ",[NOMFANTASIA] " & _
           ",[NOMCONTRIBUYENTE] " & _
           ",[RUCCONTRIBUYENTE] " & _
           ",[DESEMPRESA] " & _
           ",[DIRECCION] " & _
           ",[TELEFONO] " & _
           ",[EMAIL] " & _
           ",[NUMREGPATRONAL] " & _
           ",[RETENTOR] " & _
           ",[NOMREPRESENTANTE] " & _
           ",[RUCREPRESENTANTE] " & _
           ",[FECGRA] " & _
           ",[LOCALIDAD] " & _
           ",[NUMREGISTRO] " & _
        ",[CARPETACOMPARTIDA] " & _
           ",[PORRETENCIO],[EXPORTADOR],[PORCRETRENTA]) " & _
           " VALUES(" & _
        CodEmpresa & _
        ", " & UsuGra & _
        ", '" & NomFantasia & _
        "', '" & NomContribuyente & _
        "', '" & RUCContribuyente & _
        "', '" & DesEmpresa & _
        "', '" & Direccion & _
        "', '" & Telefono & _
        "', '" & Email & _
        "', '" & NumRegPatronal & _
        "', " & Retentor & _
        ", '" & NomRepresentante & _
        "', '" & RucRepresentante & _
        "', " & "convert(datetime, '" & Today() & " 0:00:00', 103)" & _
        ", '" & Localidad & _
        "', '" & NumRegistro & _
        "', '" & CarpetaComTextBox.Text & _
        "', " & PorRetencio & "," & cmbExportador.SelectedText & "," & PorcRetRenta & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub lb_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub LimpiarControles()
        chkRetentor.Checked = False
    End Sub

    Private Sub LOGOTIPOTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGOTIPOTextBox.TextChanged
        Try
            FileDateTime(LOGOTIPOTextBox.Text) 'para saber si ya no existe la ruta
        Catch ex As Exception
            PictureBoxLogotipo.Image = Nothing
            'ClientePictureBox.Rows(c - 1).Cells("column1").CellElement.Image = Image.FromFile(ImagenRadLabel.Text)
            Exit Sub
        End Try

        PictureBoxLogotipo.Image = Image.FromFile(LOGOTIPOTextBox.Text)
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
        EMPRESABindingSource.AddNew()
        'Me.txtCodigoComenta.Text = funcion.Maximo("CODCOMENTA", "COMENTAPRODUCTOS") + 1
        txtNomFantasia.Focus()
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

    Private Sub pbxGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxGuardar.Click
        Permiso = PermisoAplicado(UsuCodigo, 2)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permisos para guardar en esta ventana", "PosExpress")
            Exit Sub
        Else
            GUARDAR()
        End If
    End Sub

    Private Sub pbxGuardar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxGuardar.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxGuardar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxGuardar.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxModificarFichaGris_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxModificarFichaGris_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxModificarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If upd = 0 Then
            MessageBox.Show("No tiene permiso para modificar registros en esta ventana", "POSEXPRESS")
            Exit Sub
        End If
        MODIFICAR()
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




    Private Sub pbxNuevaFicha_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxNuevaFicha_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxLogotipo.Click
    End Sub

    Private Sub PictureBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxLogotipo.DoubleClick
        Dim w As New Funciones.Funciones
        Dim Destino As String = w.FuncionConsultaString("CARPETACOMPARTIDA", "EMPRESA", "CODEMPRESA", EmpCodigo)

        If Destino = "0" Then
            MessageBox.Show("Todavía no se eligió la carpeta compartida para esta Empresa", "POSEXPRESS")
            Exit Sub
        End If
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Fotos en (*.jpg)|*.jpg|Todos(*.*)|*.*|Fotos (*.bmp)|*.bmp|Fotos en (*.png)|*.png|Fotos en (*.jpge)|*.jpge|Fotos en (*.gif)|*.gif|Fotos en (*.pdf)|*.pdf"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            filename = OpenFileDialog.FileName
            PictureBoxLogotipo.Image = Image.FromFile(filename)
            PictureBoxLogotipo.ImageLocation = filename
            LOGOTIPOTextBox.Text = filename

        End If
    End Sub

    Private Sub RadGroupBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadGroupBox2.Click
    End Sub

    Private Sub txtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        If txtBuscar.Text = "Buscar..." Then
            txtBuscar.Text = ""
        End If
    End Sub

    Private Sub txtBuscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.LostFocus
        If txtBuscar.Text = "" Then
            txtBuscar.Text = "Buscar..."
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "Buscar..." Then
        ElseIf txtBuscar.Text = "" Then
            Me.EMPRESATableAdapter.Fill(DsFacturacion.EMPRESA, "%", "%")
        Else
            Me.EMPRESATableAdapter.Fill(DsFacturacion.EMPRESA, "%" + txtBuscar.Text + "%", "%" + txtBuscar.Text + "%")
        End If
    End Sub

    Private Sub txtDesEmpresa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDesEmpresa.GotFocus

    End Sub

    Private Sub txtDesEmpresa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesEmpresa.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtNomFantasia.Focus()
            Case Keys.Down
                Me.txtDireccion.Focus()
            Case Keys.Enter
                Me.txtDireccion.Focus()
        End Select
    End Sub

    Private Sub txtDesEmpresa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesEmpresa.TextChanged
    End Sub

    Private Sub txtDireccion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDireccion.GotFocus

    End Sub

    Private Sub txtDireccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDireccion.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtDesEmpresa.Focus()
            Case Keys.Down
                Me.txtTelefono.Focus()
            Case Keys.Enter
                Me.txtTelefono.Focus()
        End Select
    End Sub

    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccion.TextChanged
    End Sub

    Private Sub txtEmail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.GotFocus

    End Sub

    Private Sub txtEmail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtTelefono.Focus()
            Case Keys.Down
                Me.txtLocalidad.Focus()
            Case Keys.Enter
                Me.txtLocalidad.Focus()
        End Select
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail.TextChanged
    End Sub

    Private Sub txtLocalidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalidad.GotFocus

    End Sub

    Private Sub txtLocalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocalidad.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtEmail.Focus()
            Case Keys.Down
                Me.txtNomContribuyente.Focus()
            Case Keys.Enter
                Me.txtNomContribuyente.Focus()
        End Select
    End Sub

    Private Sub txtLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocalidad.TextChanged
    End Sub

    Private Sub txtNomContribuyente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomContribuyente.GotFocus

    End Sub

    Private Sub txtNomContribuyente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomContribuyente.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtLocalidad.Focus()
            Case Keys.Down
                Me.txtRUCContribuyente.Focus()
            Case Keys.Enter
                Me.txtRUCContribuyente.Focus()
        End Select
    End Sub

    Private Sub txtNomContribuyente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomContribuyente.TextChanged
    End Sub

    Private Sub txtNomFantasia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomFantasia.GotFocus


    End Sub

    Private Sub txtNomFantasia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomFantasia.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtBuscar.Focus()
            Case Keys.Down
                Me.txtDesEmpresa.Focus()
            Case Keys.Enter
                Me.txtDesEmpresa.Focus()
        End Select
    End Sub

    Private Sub txtNomFantasia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomFantasia.TextChanged
    End Sub

    Private Sub txtNomRepresentante_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomRepresentante.GotFocus

    End Sub

    'Private Sub chkRetentor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkRetentor.KeyDown
    '    Select Case e.KeyCode()
    '        Case Keys.Up
    '            Me.txtNumRegPatronal.Focus()
    '        Case Keys.Down
    '            Me.txtNomRepresentante.Focus()
    '        Case Keys.Enter
    '            Me.txtNomRepresentante.Focus()
    '    End Select
    'End Sub
    Private Sub txtNomRepresentante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomRepresentante.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtNumRegPatronal.Focus()
            Case Keys.Down
                Me.txtRUCRepresentante.Focus()
            Case Keys.Enter
                Me.txtRUCRepresentante.Focus()
        End Select
    End Sub

    Private Sub txtNomRepresentante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomRepresentante.TextChanged
    End Sub

    Private Sub txtNroRegistro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroRegistro.GotFocus

    End Sub

    Private Sub txtNroRegistro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroRegistro.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtRUCRepresentante.Focus()
            Case Keys.Down
                Me.txtPorRetencion.Focus()
            Case Keys.Enter
                Me.txtPorRetencion.Focus()
        End Select
    End Sub


    Private Sub txtNumRegPatronal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumRegPatronal.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtRUCContribuyente.Focus()
            Case Keys.Down
                Me.txtNomRepresentante.Focus()
            Case Keys.Enter
                Me.txtNomRepresentante.Focus()
        End Select
    End Sub

    Private Sub txtPorRetencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorRetencion.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.umePorcRetRenta.Focus()
            Case Keys.Down
                Me.pbxGuardar.Focus()
            Case Keys.Enter
                Me.pbxGuardar.Focus()
        End Select
    End Sub
    Private Sub umePorcRetRenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles umePorcRetRenta.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtPorRetencion.Focus()
            Case Keys.Down
                Me.pbxGuardar.Focus()
            Case Keys.Enter
                Me.pbxGuardar.Focus()
        End Select
    End Sub

    Private Sub txtRUCContribuyente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRUCContribuyente.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtNomContribuyente.Focus()
            Case Keys.Down
                Me.txtNumRegPatronal.Focus()
            Case Keys.Enter
                Me.txtNumRegPatronal.Focus()
        End Select
    End Sub


    Private Sub txtRUCRepresentante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRUCRepresentante.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtNomRepresentante.Focus()
            Case Keys.Down
                Me.txtNroRegistro.Focus()
            Case Keys.Enter
                Me.txtNroRegistro.Focus()
        End Select
    End Sub

    Private Sub txtRUCRepresentante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRUCRepresentante.TextChanged
    End Sub

    Private Sub txtTelefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTelefono.GotFocus

    End Sub

    Private Sub txtTelefono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono.KeyDown
        Select Case e.KeyCode()
            Case Keys.Up
                Me.txtDireccion.Focus()
            Case Keys.Down
                Me.txtEmail.Focus()
            Case Keys.Enter
                Me.txtEmail.Focus()
        End Select
    End Sub

    Private Sub txtTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelefono.TextChanged
    End Sub

#End Region 'Methods


End Class

