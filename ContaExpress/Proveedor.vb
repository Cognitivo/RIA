Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class Proveedor
    Dim f As New Funciones.Funciones
    Dim consulta As String
    Dim ProveedorActivo As Integer


#Region "Fields"

    Public VieneMenu As Integer

    Dim anu As Integer
    Private cmd As SqlCommand
    Dim CodCentro, CodMoneda, PersonaJuridica, CodCategoria, VtoTimbrado As String
    Dim representanteLegal, Link, Pais, Ciudad, CodPostal, Correo1Contacto, Correo2Contacto, TelefonoContacto, CelularContacto, NombreProv As String
    Dim IntFormaPago As Integer
    'Dim f As New Funciones.Funciones

    '########################################################################################################################
    Dim Ctrl, N, G, T, D As Boolean 'D back space
    Dim del As Integer

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader

    '***Variables de conexion usadas en la transaccion**********************
    Dim filename As String
    Dim ins As Integer
    Private myTrans As SqlTransaction
    Dim pri As Integer
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Private sqlc As SqlConnection
    Dim upd As Integer
    Dim Permiso As Double
    Dim btnuevo As Integer = 0
    Dim btmodificar As Integer = 0
    Dim Config1, Config2, Config3, Config4, Config5, Config6 As String
    Dim contentrada As Integer = 0
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

    Private Sub ActualizaProveedor()
        Dim proveedorexterior As Integer
        If chbxExterior.Checked Then
            proveedorexterior = 1
        Else
            proveedorexterior = 0
        End If
        sql = ""
        If VtoTimbrado = "NULL" Then
            sql = "update PROVEEDOR set NOMBRE = '" & NombreProv & "', NUMPROVEEDOR = '" & NumProveedorTextBox.Text & "', " & _
            "RUC_CIN = '" & Replace(RucProveedorTextBox.Text, "'", "''") & "'," & _
            "DIRECCION = '" & Replace(DireccionProveedorTextBox.Text, "'", "''") & "', TELEFONO = '" & Replace(TelefonoProveedorTextBox.Text, "'", "''") & "', " & _
            "TIMBRADOFACTURA = '" & Replace(TimbradoTextBox.Text, "'", "''") & "',MASCARA= " & proveedorexterior & ", CODCENTRO = " & CodCentro & ", " & _
            "CODMONEDA = " & CodMoneda & ", PERSONAJURIDICA = " & PersonaJuridica & ", CODCATEGORIAPROVEEDOR = " & CodCategoria & ", EMAIL = '" & tbxEmailGral.Text & "', " & _
            "FORMAPAGO = " & IntFormaPago & ", CONTACTO1 = '" & tbxContacto.Text & "', CONTACTO2 = '" & txtNomCont2.Text & "', EMAILCONT1 = '" & txtEmailCont1.Text & "', " & _
            "EMAILCONT2 = '" & txtEmailCont2.Text & "', DIRECCIONCONT1 = '" & txtDirCont1.Text & "', DIRECCIONCONT2 = '" & txtDirCont2.Text & "', TELCONT1 = '" & txtTelCont1.Text & "', " & _
            "TELCONT2 = '" & txtTelCont2.Text & "'  , ESTADO = " & ProveedorActivo & ", DIASVENCIMIENTO = " & tbxDiasVto.Text & ", FECHAVTOTIMBRADO = " & VtoTimbrado & ", CANTCUOTAS = " & tbxCantCuotas.Text & " , " & _
            "REPRESENTANTELEGAL = '" & representanteLegal & "' , LINKMAPS = '" & Link & "', CODPAIS = " & Pais & ", CODCIUDAD = " & Ciudad & ", CODIGOPOSTAL = " & CodPostal & ", CORREO1CONTACTO = '" & Correo1Contacto & "', " & _
            "CORREO2CONTACTO = '" & Correo2Contacto & "', TELEFONOCONTACTO = " & TelefonoContacto & ", CELULARCONTACTO = '" & CelularContacto & "' where CODPROVEEDOR = " & CDec(CodProvTextBox.Text) & " "

        Else
            sql = "update PROVEEDOR set NOMBRE = '" & NombreProv & "', NUMPROVEEDOR = '" & NumProveedorTextBox.Text & "', " & _
            "RUC_CIN = '" & Replace(RucProveedorTextBox.Text, "'", "''") & "'," & _
            "DIRECCION = '" & Replace(DireccionProveedorTextBox.Text, "'", "''") & "', TELEFONO = '" & Replace(TelefonoProveedorTextBox.Text, "'", "''") & "', " & _
            "TIMBRADOFACTURA = '" & Replace(TimbradoTextBox.Text, "'", "''") & "',MASCARA= " & proveedorexterior & ", CODCENTRO = " & CodCentro & ", " & _
            "CODMONEDA = " & CodMoneda & ", PERSONAJURIDICA = " & PersonaJuridica & ", CODCATEGORIAPROVEEDOR = " & CodCategoria & ", EMAIL = '" & tbxEmailGral.Text & "', " & _
            "FORMAPAGO = " & IntFormaPago & ", CONTACTO1 = '" & tbxContacto.Text & "', CONTACTO2 = '" & txtNomCont2.Text & "', EMAILCONT1 = '" & txtEmailCont1.Text & "', " & _
            "EMAILCONT2 = '" & txtEmailCont2.Text & "', DIRECCIONCONT1 = '" & txtDirCont1.Text & "', DIRECCIONCONT2 = '" & txtDirCont2.Text & "', TELCONT1 = '" & txtTelCont1.Text & "', " & _
            "TELCONT2 = '" & txtTelCont2.Text & "'  , ESTADO = " & ProveedorActivo & ", DIASVENCIMIENTO = " & tbxDiasVto.Text & ", CANTCUOTAS = " & tbxCantCuotas.Text & ", FECHAVTOTIMBRADO = CONVERT(DATE,'" & VtoTimbrado & "',103),  " & _
            "REPRESENTANTELEGAL = '" & representanteLegal & "' , LINKMAPS = '" & Link & "', CODPAIS = " & Pais & ", CODCIUDAD = " & Ciudad & ", CODIGOPOSTAL = " & CodPostal & ", CORREO1CONTACTO = '" & Correo1Contacto & "', " & _
            "CORREO2CONTACTO = '" & Correo2Contacto & "', TELEFONOCONTACTO = " & TelefonoContacto & ", CELULARCONTACTO = '" & CelularContacto & "'  where CODPROVEEDOR = " & CDec(CodProvTextBox.Text) & ""
            '"where CODPROVEEDOR = " & CDec(CodProvTextBox.Text) & ""
        End If

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizaProveedorAuditoria()
        Dim w As New Funciones.Funciones
        Dim CodAutitoria As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) values (" & CodAutitoria & ", " & EmpCodigo & ", 'PROVEEDOR', '" & CodAutitoria & "', 'ACTUALIZACION EN LA TABLA PROVEEDOR', CONVERT(DATETIME,  getdate()), '" & UsuDescripcion & "', '" & UsuNivel & "', 0, 1, 0)"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub BtnGuardarP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarP1.Click
        Try

            If CategoriaTextBox.Text = "" Then
                MsgBox("Inserte los datos")
                CategoriaTextBox.Focus()
                Exit Sub
            End If

            Dim Existe As Integer
            Dim w As New Funciones.Funciones

            Existe = w.FuncionConsultaString("CODCATEGORIAPROVEEDOR", "CATEGORIAPROVEEDOR", "DESCATEGORIAPROVEEDOR", CategoriaTextBox.Text)

            If Existe <> "0" Then
                MessageBox.Show("La Categoría: " & CategoriaTextBox.Text & " ya existe", "POSEXPRESS")
                CategoriaTextBox.Focus()
                Exit Sub
            End If
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "InsertaCategoria")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            InsertaCategoria()
            myTrans.Commit()
            CATEGORIAPROVEEDORTableAdapter.Fill(DsProveedores.CATEGORIAPROVEEDOR)

            CATEGORIAPROVEEDORBindingSource.MoveLast()

        Catch ex As Exception
            Try
                myTrans.Rollback("InsertaCategoria")
            Catch
                MsgBox("Error al intentar insertar la categoria:" + ex.Message)
            End Try
        Finally
            sqlc.Close()
        End Try

        CategoriaTextBox.Visible = False
        CategoriaComboBox.Visible = True

        BtnNuevoP1.Text = " N"
        BtnGuardarP1.Enabled = False
    End Sub

    Private Sub BtnNuevoP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevoP1.Click
        If BtnNuevoP1.Text = " N" Then
            BtnNuevoP1.Text = " C"
            BtnGuardarP1.Enabled = True
            CategoriaComboBox.Visible = False
            CategoriaTextBox.Visible = True

            CategoriaTextBox.Text = ""
            CategoriaTextBox.Focus()
        ElseIf BtnNuevoP1.Text = " C" Then
            BtnGuardarP1.Enabled = False
            CategoriaTextBox.Visible = False
            CategoriaComboBox.Visible = True
            BtnNuevoP1.Text = " N"
        End If
    End Sub

    Private Sub BuscarProveedorTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarProveedorTextBox.GotFocus

        BuscarProveedorTextBox.BackColor = Color.LightSteelBlue
        tbxProveedorEstado.Text = "Buscar Proveedor por Nombre"
    End Sub

    Private Sub BuscarProveedorTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarProveedorTextBox.LostFocus
        If BuscarProveedorTextBox.Text = "" Then
            BuscarProveedorTextBox.BackColor = Color.Tan
            tbxProveedorEstado.Text = ""
        End If
    End Sub

    Private Sub BuscarProveedorTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarProveedorTextBox.TextChanged
        If BuscarProveedorTextBox.Text = "" Then
            Me.PROVEEDORBindingSource.Filter = "NOMBRE LIKE '%" & BuscarProveedorTextBox.Text & "' OR APELLIDO  LIKE '%" & BuscarProveedorTextBox.Text & "%' OR RUC_CIN LIKE '%" & BuscarProveedorTextBox.Text & "%'"
        Else
            If Config1 = "Nombre de Proveedor" Then
                Me.PROVEEDORBindingSource.Filter = "NOMBRE LIKE '%" & BuscarProveedorTextBox.Text & "%' OR RUC_CIN LIKE '%" & BuscarProveedorTextBox.Text & "%'"
            ElseIf Config1 = "Nro. de Proveedor" Then
                Me.PROVEEDORBindingSource.Filter = " NUMPROVEEDOR ='" & BuscarProveedorTextBox.Text & "' OR NOMBRE LIKE '%" & BuscarProveedorTextBox.Text & "%'"
            End If
        End If
    End Sub


    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        '**************************************************************************************************************************************************
        'Cuando se cancela una factura se debe eliminar de la base de datos el registro q se creo al presionar nuevo (esto es por un error que se genero al
        'trabajar con ventas en simultaneo). Para esto verificamos si el campo clientes no es nulo.

        Dim ProveedorIsNull As String

        ProveedorIsNull = f.FuncionConsultaString("NOMBRE", "PROVEEDOR", "CODPROVEEDOR", Me.CodProvTextBox.Text)
        If ProveedorIsNull = "" Or ProveedorIsNull = Nothing Then
            Dim consulta As System.String
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            conexion = ser.Abrir()

            Try
                consulta = ""
                consulta = consulta + "DELETE FROM PROVEEDOR WHERE CODPROVEEDOR=" & CDec(CodProvTextBox.Text) & " "

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
            Catch ex As SqlException
            End Try

        End If
        '**************************************************************************************************************************************************

        PROVEEDORBindingSource.CancelEdit()
        Dim IndiceP As Integer = PROVEEDORBindingSource.Position
        actualizargrillaprov()

        PROVEEDORBindingSource.Position = IndiceP
        '#####################################
        DeshabiltaProveedor()
    End Sub

    Private Sub NuevoPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NuevoPictureBox.MouseDown
        If NuevoPictureBox.Enabled = True Then
            NuevoPictureBox.Image = My.Resources.NewMouseDown
        End If
    End Sub

    Private Sub EliminarPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles EliminarPictureBox.MouseDown
        If EliminarPictureBox.Enabled = True Then
            EliminarPictureBox.Image = My.Resources.DeleteMouseDown
        End If
    End Sub

    Private Sub ModificarPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ModificarPictureBox.MouseDown
        If ModificarPictureBox.Enabled = True Then
            ModificarPictureBox.Image = My.Resources.EditMouseDown
        End If
    End Sub

    Private Sub GuardarPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GuardarPictureBox.MouseDown
        If GuardarPictureBox.Enabled = True Then
            GuardarPictureBox.Image = My.Resources.SaveMouseDown
        End If
    End Sub

    Private Sub CancelarPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseLeave, EliminarPictureBox.MouseLeave, ModificarPictureBox.MouseLeave, CancelarPictureBox.MouseLeave, GuardarPictureBox.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DeshabiltaProveedor()
        PictureBoxActivo.Enabled = False
        ProveedorGridView.Enabled = True
        BuscarProveedorTextBox.Enabled = True

        NumProveedorTextBox.Enabled = False
        NombreProveedorTextBox.Enabled = False

        NombreProveedorTextBox.Visible = False
        lblNombre.Visible = True

        RucProveedorTextBox.Enabled = False
        DireccionProveedorTextBox.Enabled = False
        TelefonoProveedorTextBox.Enabled = False
        CentroCostoComboBox.Enabled = False
        MonedaComboBox.Enabled = False
        CategoriaComboBox.Enabled = False
        BtnNuevoP1.Enabled = False
        BtnGuardarP1.Enabled = False
        chbxExterior.Enabled = False
        TimbradoTextBox.Enabled = False
        Me.cmbFormaPago.Enabled = False
        Me.tbxEmailGral.Enabled = False
        Me.tbxDiasVto.Enabled = False
        Me.tbxCantCuotas.Enabled = False
        Me.dtpVtoTimbrado.Enabled = False

        Me.txtNomCont1.Enabled = False
        Me.txtEmailCont1.Enabled = False
        Me.txtTelCont1.Enabled = False
        Me.txtDirCont1.Enabled = False
        Me.txtNomCont2.Enabled = False
        Me.txtEmailCont2.Enabled = False
        Me.txtTelCont2.Enabled = False
        Me.txtDirCont2.Enabled = False

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
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff

        BuscarProveedorTextBox.Focus()
    End Sub


    Private Sub HabilitaProveedor()
        PictureBoxActivo.Enabled = True
        ProveedorGridView.Enabled = False
        BuscarProveedorTextBox.Enabled = False

        NumProveedorTextBox.Enabled = True
        NombreProveedorTextBox.Enabled = True

        NombreProveedorTextBox.Visible = True
        lblNombre.Visible = False

        RucProveedorTextBox.Enabled = True
        DireccionProveedorTextBox.Enabled = True
        TelefonoProveedorTextBox.Enabled = True
        CentroCostoComboBox.Enabled = True
        MonedaComboBox.Enabled = True

        CategoriaComboBox.Enabled = True
        BtnNuevoP1.Enabled = True
        BtnGuardarP1.Enabled = True
        chbxExterior.Enabled = True
        TimbradoTextBox.Enabled = True
        Me.cmbFormaPago.Enabled = True
        Me.tbxEmailGral.Enabled = True

        Me.txtNomCont1.Enabled = True
        Me.txtEmailCont1.Enabled = True
        Me.txtTelCont1.Enabled = True
        Me.txtDirCont1.Enabled = True

        Me.txtNomCont2.Enabled = True
        Me.txtEmailCont2.Enabled = True
        Me.txtTelCont2.Enabled = True
        Me.txtDirCont2.Enabled = True
        Me.tbxDiasVto.Enabled = True
        Me.tbxCantCuotas.Enabled = True
        Me.dtpVtoTimbrado.Enabled = True

        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Cursor = Cursors.Arrow
        EliminarPictureBox.Image = My.Resources.DeleteOff
        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Cursor = Cursors.Arrow
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Cursor = Cursors.Arrow
        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save

        NombreProveedorTextBox.Focus()
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click

        Permiso = PermisoAplicado(UsuCodigo, 5)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para eliminar un proveedor", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else

            If MessageBox.Show("¿Esta seguro que quiere Eliminar este Proveedor?", "POS EXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If
            If CodProvTextBox.Text <> "" Then
                ser.Abrir(sqlc)
                cmd.Connection = sqlc
                cmd.Transaction = myTrans

                Try
                    sql = ""
                    sql = " DELETE FROM PROVEEDOR " & _
                    " WHERE CODPROVEEDOR= " & CDec(CodProvTextBox.Text) & ""
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    actualizargrillaprov()
                    tbxProveedorEstado.Text = "Proveedor Eliminado"
                Catch ex As Exception
                    MessageBox.Show("El Proveedor está siendo utilizado por el sistema y no se puede Eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

                DeshabiltaProveedor()
                sqlc.Close()
            End If
        End If
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim MensajesError As String = ""
        Dim NroError As Integer = 0

        If CodProvTextBox.Text = "" Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Debe ingresar un Código para este Proveedor " + Chr(13)
            tbxProveedorEstado.Text = "Cargue un Nro de Proveedor"
            CodProvTextBox.BackColor = Color.Pink
        End If

        Dim existe As Integer
        Dim w As New Funciones.Funciones

        existe = w.FuncionConsultaString("CODPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR <> " & CodProvTextBox.Text & " AND NUMPROVEEDOR", NumProveedorTextBox.Text)


        If existe <> Nothing Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Este Nro. de Proveedor ya está siendo utilizado" + Chr(13)
            tbxProveedorEstado.Text = "Este Nro de Proveedor ya se esta siendo utilizado!"
            NumProveedorTextBox.BackColor = Color.Pink
        End If

        If NombreProveedorTextBox.Text = "" Then
            NroError = NroError + 1
            MensajesError = CStr(NroError) & ") Debe ingresar un Nombre para el Proveedor" + Chr(13)
            tbxProveedorEstado.Text = "Cargue un Nombre"
            NombreProveedorTextBox.BackColor = Color.Pink
        End If

        If NroError <> 0 Then
            MessageBox.Show("Faltaron datos para completar el proceso de Guardado. Favor revise estos items antes de seguir:  " + Chr(13) + MensajesError, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        tbxProveedorEstado.Text = "Guardando"
        GuardarPictureBox.Image = My.Resources.SaveActive
        GUARDARPROVEEDOR()
        DeshabiltaProveedor()
        tbxProveedorEstado.Text = "Guardado!"
        btnuevo = 0 : btmodificar = 0
    End Sub

    Public Sub GUARDARPROVEEDOR()
        '##############VALIDAMOS######################
        'Dim existe As Integer
        Dim w As New Funciones.Funciones


        barProveedor.Value = 30
        If CentroCostoComboBox.SelectedValue = Nothing Then
            CodCentro = "NULL"
        Else
            CodCentro = CentroCostoComboBox.SelectedValue
        End If

        If MonedaComboBox.SelectedValue = Nothing Then
            CodMoneda = "NULL"
        Else
            CodMoneda = MonedaComboBox.SelectedValue
        End If

        PersonaJuridica = 1

        If CategoriaComboBox.SelectedValue = Nothing Then
            CodCategoria = "NULL"
        Else
            CodCategoria = CategoriaComboBox.SelectedValue
        End If

        If tbxDiasVto.Text = "" Then
            tbxDiasVto.Text = "1"
        End If

        If tbxCantCuotas.Text = "" Then
            tbxCantCuotas.Text = "1"
        End If

        If dtpVtoTimbrado.Checked = False Then
            VtoTimbrado = "NULL"
        Else
            VtoTimbrado = dtpVtoTimbrado.Text
        End If

        If cmbFormaPago.Text = "Contado" Then
            IntFormaPago = 0
        ElseIf cmbFormaPago.Text = "Crédito" Then
            IntFormaPago = 1
        Else
            IntFormaPago = 0 ' le forzamos contado
        End If

        If tbxRepresentanteLegal.Text = "" Then
            representanteLegal = ""
        Else
            representanteLegal = tbxRepresentanteLegal.Text
        End If

        If txtGMaps.Text = "" Then
            Link = ""
        Else
            Link = txtGMaps.Text
        End If

        If cmbPais.SelectedValue Is Nothing Then
            Pais = 0
        Else
            Pais = cmbPais.SelectedValue
        End If

        If cbxCiudad.SelectedValue Is Nothing Then
            Ciudad = 0
        Else
            Ciudad = cbxCiudad.SelectedValue
        End If

        If tbxMail1Contacto.Text = "" Then
            Correo1Contacto = ""
        Else
            Correo1Contacto = tbxMail1Contacto.Text
        End If

        If tbxMail2Contacto.Text = "" Then
            Correo2Contacto = ""
        Else
            Correo2Contacto = tbxMail2Contacto.Text
        End If

        If tbxTelContacto.Text = "" Then
            TelefonoContacto = 0
        Else
            TelefonoContacto = tbxTelContacto.Text
        End If

        If tbxCelContacto.Text = "" Then
            CelularContacto = 0
        Else
            CelularContacto = tbxCelContacto.Text
        End If

        If tbxCodPostal.Text = "" Then
            CodPostal = 0
        Else
            CodPostal = tbxCodPostal.Text
        End If

        If NombreProveedorTextBox.Text = "" Then
            NombreProv = ""
        Else
            NombreProv = NombreProveedorTextBox.Text
        End If

        '##############################################
        barProveedor.Value = 80

        Dim transaction As SqlTransaction = Nothing

        If btmodificar = 1 Then
            '###################################################################
            'ACTUALIZAR: si existe el codigo de cliente actualiza
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaProveedor()

                '####AUDITORIA##############
                ActualizaProveedorAuditoria()
                '##########################

                myTrans.Commit()
                Dim Indice As Integer = PROVEEDORBindingSource.Position
                actualizargrillaprov()
                PROVEEDORBindingSource.Position = Indice
                barProveedor.Value = 100
                tbxProveedorEstado.Text = "Grabado"
                DeshabiltaProveedor()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                MessageBox.Show("Ocurrio un error al intentar actualizar el Proveedor" + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                barProveedor.Value = 0
                tbxProveedorEstado.Text = "Error al Grabar"
            Finally
                sqlc.Close()

            End Try

        ElseIf btnuevo = 1 Then
            '############################################################################
            'INSERTAR: si el codigo es nuevo inserta
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaProveedor()

                '####AUDITORIA##############
                InsertaProveedorAuditoria()
                '##########################

                myTrans.Commit()

                actualizargrillaprov()
                PROVEEDORBindingSource.MoveLast()
                barProveedor.Value = 100
                tbxProveedorEstado.Text = "Grabado!"

                If VieneMenu = 1 Then
                    Exit Sub
                End If

                'PROVEEDORTableAdapter.Fill(DsPagos.PROVEEDOR, "%", "%")
                'ComprasFacil.PROVEEDORBindingSource.MoveLast()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error al insertar el Proveedor", "POSEXPRESS")
                barProveedor.Value = 0
                tbxProveedorEstado.Text = "Error al Grabar"
            Finally
                sqlc.Close()

            End Try

        End If
    End Sub


    Private Sub InsertaCategoria()
        Dim F As New Funciones.Funciones
        Dim codcategoria As Integer
        Try
            codcategoria = F.Maximo("CODCATEGORIAPROVEEDOR", "CATEGORIAPROVEEDOR") + 1
        Catch ex As Exception

        End Try

        sql = ""
        sql = "insert into CATEGORIAPROVEEDOR (CODCATEGORIAPROVEEDOR, NUMCATEGORIAPROVEEDOR, DESCATEGORIAPROVEEDOR, FECGRA, CODUSUARIO, CODEMPRESA)" & _
        " VALUES (" & codcategoria & "," & codcategoria.ToString & ",'" & CategoriaTextBox.Text & "',getdate()," & UsuCodigo & "," & EmpCodigo & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub InsertaProveedor()
        Dim proveedorexterior As Integer
        If chbxExterior.Checked Then
            proveedorexterior = 1
        Else
            proveedorexterior = 0
        End If

        Dim CodProveedorGlobal As Integer

        'se debe obtener el ultimo nro insertado
        CodProveedorGlobal = f.Maximo("CODPROVEEDOR", "PROVEEDOR")
        CodProveedorGlobal = CodProveedorGlobal + 1
        CodProvTextBox.Text = CodProveedorGlobal

        sql = ""
        If VtoTimbrado = "NULL" Then
            sql = "insert into PROVEEDOR " & _
           "(CODPROVEEDOR, CODUSUARIO, CODEMPRESA, NUMPROVEEDOR, NOMBRE, APELLIDO, RUC_CIN, DIRECCION, FECGRA, " & _
           "TELEFONO, TIMBRADOFACTURA, MASCARA, CODCENTRO, PERSONAJURIDICA, CODCATEGORIAPROVEEDOR, EMAIL, FORMAPAGO, " & _
           "CONTACTO1, CONTACTO2, EMAILCONT1, EMAILCONT2, DIRECCIONCONT1, DIRECCIONCONT2, TELCONT1, TELCONT2, CODMONEDA, ESTADO,DIASVENCIMIENTO, CANTCUOTAS, REPRESENTANTELEGAL, LINKMAPS, CODPAIS, CODCIUDAD, CODIGOPOSTAL, CORREO1CONTACTO, CORREO2CONTACTO, TELEFONOCONTACTO, CELULARCONTACTO) " & _
           " values (" & CDec(CodProvTextBox.Text) & ", " & UsuCodigo & ", " & EmpCodigo & ", " & _
           "'" & NumProveedorTextBox.Text & "', '" & NombreProv & "', '', " & _
           "'" & Replace(RucProveedorTextBox.Text, "'", "''") & "', '" & Replace(DireccionProveedorTextBox.Text, "'", "''") & "', CONVERT(DATETIME, '" & Today & "', 103), " & _
           "'" & Replace(TelefonoProveedorTextBox.Text, "'", "''") & "', '" & Replace(TimbradoTextBox.Text, "'", "''") & "'," & proveedorexterior & ", " & CodCentro & ", " & PersonaJuridica & ", " & CodCategoria & ", " & _
           "'" & tbxEmailGral.Text & "', " & IntFormaPago & ", '" & tbxContacto.Text & "', '" & txtNomCont2.Text & "', '" & txtEmailCont1.Text & "', " & _
           "'" & txtEmailCont2.Text & "', '" & txtDirCont1.Text & "', '" & txtDirCont2.Text & "', '" & txtTelCont1.Text & "', " & _
           "'" & txtTelCont2.Text & "', " & CodMoneda & " , " & ProveedorActivo & "," & tbxDiasVto.Text & "," & tbxCantCuotas.Text & ", '" & representanteLegal & "', '" & Link & "', " & Pais & ", " & Ciudad & ", " & CodPostal & ", '" & Correo1Contacto & "','" & Correo2Contacto & "'," & TelefonoContacto & "," & CelularContacto & " )"
        Else
            sql = "insert into PROVEEDOR " & _
            "(CODPROVEEDOR, CODUSUARIO, CODEMPRESA, NUMPROVEEDOR, NOMBRE, APELLIDO, RUC_CIN, DIRECCION, FECGRA, " & _
            "TELEFONO, TIMBRADOFACTURA, MASCARA, CODCENTRO, PERSONAJURIDICA, CODCATEGORIAPROVEEDOR, EMAIL, FORMAPAGO, " & _
            "CONTACTO1, CONTACTO2, EMAILCONT1, EMAILCONT2, DIRECCIONCONT1, DIRECCIONCONT2, TELCONT1, TELCONT2, CODMONEDA, ESTADO,DIASVENCIMIENTO,FECHAVTOTIMBRADO, CANTCUOTAS, REPRESENTANTELEGAL, LINKMAPS, CODPAIS, CODCIUDAD, CODIGOPOSTAL, CORREO1CONTACTO, CORREO2CONTACTO, TELEFONOCONTACTO, CELULARCONTACTO) " & _
            " values (" & CDec(CodProvTextBox.Text) & ", " & UsuCodigo & ", " & EmpCodigo & ", " & _
            "'" & NumProveedorTextBox.Text & "', '" & NombreProv & "', '', " & _
            "'" & Replace(RucProveedorTextBox.Text, "'", "''") & "', '" & Replace(DireccionProveedorTextBox.Text, "'", "''") & "', CONVERT(DATETIME, '" & Today & "', 103), " & _
            "'" & Replace(TelefonoProveedorTextBox.Text, "'", "''") & "', '" & Replace(TimbradoTextBox.Text, "'", "''") & "'," & proveedorexterior & ", " & CodCentro & ", " & PersonaJuridica & ", " & CodCategoria & ", " & _
            "'" & tbxEmailGral.Text & "', " & IntFormaPago & ", '" & tbxContacto.Text & "', '" & txtNomCont2.Text & "', '" & txtEmailCont1.Text & "', " & _
            "'" & txtEmailCont2.Text & "', '" & txtDirCont1.Text & "', '" & txtDirCont2.Text & "', '" & txtTelCont1.Text & "', " & _
            "'" & txtTelCont2.Text & "', " & CodMoneda & " , " & ProveedorActivo & "," & tbxDiasVto.Text & ", CONVERT(DATE,'" & VtoTimbrado & "',103)," & tbxCantCuotas.Text & ", '" & representanteLegal & "', '" & Link & "', " & Pais & ", " & Ciudad & ", " & CodPostal & ", '" & Correo1Contacto & "','" & Correo2Contacto & "'," & TelefonoContacto & "," & CelularContacto & ")"
        End If

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

    End Sub

    Private Sub InsertaProveedorAuditoria()
        Dim w As New Funciones.Funciones
        Dim CodAutitoria As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) values (" & CodAutitoria & ", " & EmpCodigo & ", 'PROVEEDOR', '" & CodAutitoria & "', 'INSERCION EN LA TABLA PROVEEDOR', CONVERT(DATETIME, '" & Today & "', 103), '" & UsuDescripcion & "', '" & UsuNivel & "', 1, 0, 0)"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub


    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        btmodificar = 1
        Permiso = PermisoAplicado(UsuCodigo, 6)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para MODIFICAR", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            HabilitaProveedor()
            ModificarPictureBox.Image = My.Resources.EditActive
        End If

    End Sub

    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        btnuevo = 1

        Permiso = PermisoAplicado(UsuCodigo, 4)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para crear un Nuevo Proveedor", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            PanelContacto.Visible = False
            PROVEEDORBindingSource.AddNew()
            Me.cmbFormaPago.Text = ""
            HabilitaProveedor()

            ProveedorActivo = 1
            PictureBoxActivo.Image = My.Resources.AbiertoActive
            lblActivo.ForeColor = Color.OrangeRed
            lblActivo.Text = "Activo"

            Me.pnlProveedor.BringToFront()
            NombreProveedorTextBox.Focus()
            NuevoPictureBox.Image = My.Resources.NewActive
        End If

    End Sub

    Private Sub Proveedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            PROVEEDORBindingSource.CancelEdit()
            CompraPlus.PROVEEDORTableAdapter.Fill(CompraPlus.DsPagos.PROVEEDOR, "%", "%")
            Contactos.PROVEEDORTableAdapter.Fill(DsProveedores.PROVEEDOR)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Proveedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.PanelContacto.Visible = False
            pbxDatosContacto.Image = My.Resources.User
            Me.pnlProveedor.BringToFront()
            Me.BtnNuevoP1.Visible = True
            Me.BtnGuardarP1.Visible = True
            Me.pbxAgregarCentroCosto.Visible = True
        End If
    End Sub

    Private Sub Proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsCliente.ZONA' Puede moverla o quitarla según sea necesario.
        Me.ZONATableAdapter.Fill(Me.DsCliente.ZONA)
        'TODO: esta línea de código carga datos en la tabla 'DsCliente.CIUDAD' Puede moverla o quitarla según sea necesario.
        Me.CIUDADTableAdapter.Fill(Me.DsCliente.CIUDAD)
        'TODO: esta línea de código carga datos en la tabla 'DsCliente.PAIS' Puede moverla o quitarla según sea necesario.
        Me.PAISTableAdapter.Fill(Me.DsCliente.PAIS)
        Permiso = PermisoAplicado(UsuCodigo, 3)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        Me.CATEGORIAPROVEEDORTableAdapter.Fill(Me.DsProveedores.CATEGORIAPROVEEDOR)
        Me.MONEDATableAdapter.Fill(Me.DsProveedores.MONEDA)
        Me.CENTROCOSTOTableAdapter.Fill(Me.DsProveedores.CENTROCOSTO)
        dtpVtoTimbrado.ShowCheckBox = True

        ObtenerConfig()
        actualizargrillaprov()

        If ProveedorGridView.RowCount <> 0 Then
            If IsDBNull(ProveedorGridView.CurrentRow.Cells("FORMAPAGO").Value) Then
            ElseIf ProveedorGridView.CurrentRow.Cells("FORMAPAGO").Value = 0 Then
                cmbFormaPago.SelectedIndex = 0
            ElseIf ProveedorGridView.CurrentRow.Cells("FORMAPAGO").Value = 1 Then
                cmbFormaPago.SelectedIndex = 1
            End If
        End If

        DeshabiltaProveedor()
        Me.pnlProveedor.BringToFront()

        If Config1 = "Nombre de Proveedor" Then
            NUMPROVEEDORDataGridViewTextBoxColumn.Visible = False
            ProveedorGridView.ScrollBars = ScrollBars.Vertical
        Else
            NUMPROVEEDORDataGridViewTextBoxColumn.Visible = True
            ProveedorGridView.ScrollBars = ScrollBars.Both
            'CLIENTESBindingSource.Sort = "NUMCLIENTEDataGridViewTextBoxColumn" NO FUNCIONA
        End If

    End Sub

    Private Sub NombreProveedorTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles NombreProveedorTextBox.GotFocus
        NombreProveedorTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub NombreProveedorTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NombreProveedorTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            NumProveedorTextBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNomCont1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNomCont1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtDirCont1.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNomCont2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNomCont2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtDirCont2.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDirCont1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDirCont1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtTelCont1.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDirCont2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDirCont2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtTelCont2.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumProveedorTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles NumProveedorTextBox.GotFocus
        NumProveedorTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub NumProveedorTextBox_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumProveedorTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            chbxExterior.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub chbxExterior_GotFocus(sender As Object, e As System.EventArgs) Handles chbxExterior.GotFocus
        chbxExterior.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub chbxExterior_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chbxExterior.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            RucProveedorTextBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub RucProveedorTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles RucProveedorTextBox.GotFocus

        If Config2 = "Manual" Then
            RucProveedorTextBox.BackColor = Color.LightSteelBlue
            'LblInfoDV.Visible = True
        End If

    End Sub

    Private Sub RucProveedorTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RucProveedorTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            If Config2 = "Automatico" Then
                Dim str As String
                Dim cadena As String
                If RucProveedorTextBox.Text <> "" Then
                    Str = RucProveedorTextBox.Text
                    cadena = Str.Substring(Str.Length - 2, 1)

                    If cadena <> "-" Then
                        Dim DV As Integer
                        DV = getDV(RucProveedorTextBox.Text)
                        RucProveedorTextBox.Text = RucProveedorTextBox.Text & "-" & DV
                    End If
                End If
            End If
            TimbradoTextBox.Focus()
        ElseIf KeyAscii = 42 Then
            If RucProveedorTextBox.Text <> "" Then
                Dim str As String
                Dim cadena As String

                str = RucProveedorTextBox.Text
                cadena = str.Substring(str.Length - 2, 1)

                If cadena <> "-" Then
                    Dim DV As Integer
                    DV = getDV(RucProveedorTextBox.Text)
                    RucProveedorTextBox.Text = RucProveedorTextBox.Text & "-" & DV
                End If
            End If
            KeyAscii = 0
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TimbradoTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles TimbradoTextBox.GotFocus
        TimbradoTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub TimbradoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TimbradoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpVtoTimbrado.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub DireccionProveedorTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles DireccionProveedorTextBox.GotFocus
        DireccionProveedorTextBox.BackColor = Color.LightSteelBlue
    End Sub


    Private Sub DireccionProveedorTextBox_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DireccionProveedorTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TelefonoProveedorTextBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TelefonoProveedorTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles TelefonoProveedorTextBox.GotFocus
        TelefonoProveedorTextBox.BackColor = Color.LightSteelBlue
    End Sub
    Private Sub tbxEmailGral_GotFocus(sender As Object, e As System.EventArgs) Handles tbxEmailGral.GotFocus
        tbxEmailGral.BackColor = Color.LightSteelBlue
    End Sub
    Private Sub TelefonoProveedorTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TelefonoProveedorTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxEmailGral.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbxEmailGral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxEmailGral.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            DireccionProveedorTextBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CategoriaComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles CategoriaComboBox.GotFocus
        CategoriaComboBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub CategoriaComboBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CategoriaComboBox.KeyDown
        If e.KeyData = Keys.Enter Then
            CentroCostoComboBox.Focus()
        End If

    End Sub

    Private Sub CategoriaComboBox_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CategoriaComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CentroCostoComboBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CentroCostoComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles CentroCostoComboBox.GotFocus
        CentroCostoComboBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub CentroCostoComboBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CentroCostoComboBox.KeyDown
        If e.KeyData = Keys.Enter Then
            MonedaComboBox.Focus()
        End If
    End Sub

    Private Sub CentroCostoComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CentroCostoComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            MonedaComboBox.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

#End Region

    Private Sub NumProveedorTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumProveedorTextBox.LostFocus
        Dim Aleatorio, Existe, CodProveedor As Integer
        Dim Minimo As Integer
        Dim Maximo As Integer

        If NumProveedorTextBox.Text = "" Then
            Aleatorio = "0001"
            Minimo = "1"
            Maximo = "9999"

            Randomize() ' inicializar la semilla
            Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)


            Existe = f.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", Aleatorio)

            While Existe <> 0
                Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)
                Existe = f.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", Aleatorio)
            End While

            NumProveedorTextBox.Text = Aleatorio
        ElseIf NumProveedorTextBox.Text <> "" Then
            Existe = f.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", NumProveedorTextBox.Text)
            CodProveedor = f.FuncionConsultaString("CODPROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", NumProveedorTextBox.Text)

            Try
                If (Existe = NumProveedorTextBox.Text) And (CodProveedor <> ProveedorGridView.CurrentRow.Cells("CODPROVEEDORDataGridViewTextBoxColumn").Value) Then
                    MessageBox.Show("El Numero de proveedor ya existe", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    NumProveedorTextBox.Focus()
                    NumProveedorTextBox.BackColor = Color.Pink
                    Exit Sub
                End If
            Catch
            End Try

        End If
        NumProveedorTextBox.BackColor = Color.White
    End Sub

    Private Sub pbxAgregarCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarCentroCosto.Click
        Try
            CentroDeCosto.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbxExterior_LostFocus(sender As Object, e As System.EventArgs) Handles chbxExterior.LostFocus
        Try
            chbxExterior.BackColor = Color.LightGray
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NombreProveedorTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles NombreProveedorTextBox.LostFocus
        NombreProveedorTextBox.BackColor = Color.White
    End Sub
    Private Sub txtNomCont1_LostFocus(sender As Object, e As System.EventArgs) Handles txtNomCont1.LostFocus
        txtNomCont1.BackColor = Color.White
    End Sub
    Private Sub txtNomCont2_LostFocus(sender As Object, e As System.EventArgs) Handles txtNomCont2.LostFocus
        txtNomCont2.BackColor = Color.White
    End Sub

    Private Sub txtTelCont1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelCont1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtEmailCont1.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelCont1_LostFocus(sender As Object, e As System.EventArgs) Handles txtTelCont1.LostFocus
        txtTelCont1.BackColor = Color.White
    End Sub

    Private Sub txtTelCont2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelCont2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtEmailCont2.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelCont2_LostFocus(sender As Object, e As System.EventArgs) Handles txtTelCont2.LostFocus
        txtTelCont2.BackColor = Color.White
    End Sub

    Private Sub txtEmailCont1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailCont1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtNomCont2.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEmailCont1_LostFocus(sender As Object, e As System.EventArgs) Handles txtEmailCont1.LostFocus
        txtEmailCont1.BackColor = Color.White
    End Sub
    Private Sub txtEmailCont2_LostFocus(sender As Object, e As System.EventArgs) Handles txtEmailCont2.LostFocus
        txtEmailCont2.BackColor = Color.White
    End Sub
    Private Sub txtDirCont1_LostFocus(sender As Object, e As System.EventArgs) Handles txtDirCont1.LostFocus
        txtDirCont1.BackColor = Color.White
    End Sub
    Private Sub txtDirCont2_LostFocus(sender As Object, e As System.EventArgs) Handles txtDirCont2.LostFocus
        txtDirCont2.BackColor = Color.White
    End Sub
    Private Sub DireccionProveedorTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles DireccionProveedorTextBox.LostFocus
        DireccionProveedorTextBox.BackColor = Color.White
    End Sub

    Private Sub TelefonoProveedorTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles TelefonoProveedorTextBox.LostFocus
        TelefonoProveedorTextBox.BackColor = Color.White
    End Sub

    Private Sub tbxEmailGral_LostFocus(sender As Object, e As System.EventArgs) Handles tbxEmailGral.LostFocus
        tbxEmailGral.BackColor = Color.White
    End Sub

    Private Sub CategoriaComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles CategoriaComboBox.LostFocus
        CategoriaComboBox.BackColor = Color.White
        Try
            If CategoriaComboBox.Text = "" Then
                CategoriaComboBox.SelectedIndex = CategoriaComboBox.SelectedIndex + 1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CentroCostoComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles CentroCostoComboBox.LostFocus
        CentroCostoComboBox.BackColor = Color.White
        If CentroCostoComboBox.Text = "" Then
            CentroCostoComboBox.SelectedIndex = CentroCostoComboBox.SelectedIndex + 1
        End If
    End Sub

    Private Sub MonedaComboBox_GotFocus(sender As Object, e As System.EventArgs) Handles MonedaComboBox.GotFocus
        MonedaComboBox.BackColor = Color.LightSteelBlue
        If MonedaComboBox.Text = "" Then
            MonedaComboBox.SelectedIndex = MonedaComboBox.SelectedIndex + 1
        End If
    End Sub

    Private Sub cmbFormaPago_GotFocus(sender As Object, e As System.EventArgs) Handles cmbFormaPago.GotFocus
        cmbFormaPago.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtNomCont1_GotFocus(sender As Object, e As System.EventArgs) Handles txtNomCont1.GotFocus
        txtNomCont1.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtNomCont2_GotFocus(sender As Object, e As System.EventArgs) Handles txtNomCont2.GotFocus
        txtNomCont2.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtTelCont1_GotFocus(sender As Object, e As System.EventArgs) Handles txtTelCont1.GotFocus
        txtTelCont1.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtTelCont2_GotFocus(sender As Object, e As System.EventArgs) Handles txtTelCont2.GotFocus
        txtTelCont2.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtEmailCont1_GotFocus(sender As Object, e As System.EventArgs) Handles txtEmailCont1.GotFocus
        txtEmailCont1.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtEmailCont2_GotFocus(sender As Object, e As System.EventArgs) Handles txtEmailCont2.GotFocus
        txtEmailCont2.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtDirCont1_GotFocus(sender As Object, e As System.EventArgs) Handles txtDirCont1.GotFocus
        txtDirCont1.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtDirCont2_GotFocus(sender As Object, e As System.EventArgs) Handles txtDirCont2.GotFocus
        txtDirCont2.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub MonedaComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MonedaComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbFormaPago.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub MonedaComboBox_LostFocus(sender As Object, e As System.EventArgs) Handles MonedaComboBox.LostFocus
        MonedaComboBox.BackColor = Color.White
    End Sub

    Private Sub TimbradoTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles TimbradoTextBox.LostFocus
        TimbradoTextBox.BackColor = Color.White
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Dim soporte As String = "http://www.cogentpotential.com/soporte/compras/proveedor"
        Shell("Explorer " & soporte)
    End Sub


    Private Sub ProveedorGridView_SelectionChanged(sender As Object, e As System.EventArgs) Handles ProveedorGridView.SelectionChanged

        '  For i = 0 To ProveedorGridView.Rows.Count - 1
        Try
            consulta = f.FuncionConsultaString("MASCARA", "PROVEEDOR", "CODPROVEEDOR", ProveedorGridView.CurrentRow.Cells("CODPROVEEDORDataGridViewTextBoxColumn").Value)
        Catch
        End Try

        If consulta <> 0 Then
            chbxExterior.Checked = True
        Else
            chbxExterior.Checked = False
        End If

        'Next
        If lblFormaPago.Text = "0" Then
            cmbFormaPago.Text = "Contado"
        ElseIf lblFormaPago.Text = "1" Then
            cmbFormaPago.Text = "Crédito"
        Else
            cmbFormaPago.Text = ""
        End If

        Try
            If IsDBNull(ProveedorGridView.CurrentRow.Cells("FECHAVTOTIMBRADO").Value) Then
                dtpVtoTimbrado.Checked = False
            Else
                dtpVtoTimbrado.Checked = True
            End If
        Catch
        End Try

        Try
            If IsDBNull(ProveedorGridView.CurrentRow.Cells("ESTADO").Value) Then
                PictureBoxActivo.Image = My.Resources.AbiertoOff
                ProveedorActivo = 0
                lblActivo.ForeColor = Color.Black
                lblActivo.Text = "Inactivo"
            Else
                If ProveedorGridView.CurrentRow.Cells("ESTADO").Value = 0 Then
                    PictureBoxActivo.Image = My.Resources.AbiertoOff
                    ProveedorActivo = 0
                    lblActivo.ForeColor = Color.Black
                    lblActivo.Text = "Inactivo"
                Else
                    PictureBoxActivo.Image = My.Resources.AbiertoActive
                    ProveedorActivo = 1
                    lblActivo.ForeColor = Color.OrangeRed
                    lblActivo.Text = "Activo"
                End If
            End If
        Catch
        End Try


    End Sub

    Function getDV(ByVal RUC As String) As String
        getDV = calcular(RUC, 11)
    End Function


    Function calcular(ByVal numero As String, ByVal basemax As Integer) As String
        Dim codigo As Long
        Dim numero_al As String = ""

        Dim i
        For i = 1 To Len(numero)
            Dim c
            c = Mid$(numero, i, 1)
            codigo = Asc(UCase(c))
            If Not (codigo >= 48 And codigo <= 57) Then
                numero_al = numero_al & codigo
            Else
                numero_al = numero_al & c
            End If
        Next

        Dim k : Dim total
        k = 2
        total = 0

        For i = Len(numero_al) To 1 Step -1
            If (k > basemax) Then k = 2
            Dim numero_aux
            numero_aux = Val(Mid(numero_al, i, 1))
            total = total + (numero_aux * k)
            k = k + 1
        Next


        Dim resto : Dim digito
        resto = total Mod 11
        If (resto > 1) Then
            digito = 11 - resto
        Else
            digito = 0
        End If
        calcular = digito
    End Function

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1, CONFIG2, CONFIG3, CONFIG4, CONFIG5, CONFIG6 FROM MODULO WHERE MODULO_ID = 2"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    Config1 = odrConfig("CONFIG1")
                    Config2 = odrConfig("CONFIG2")
                    Config3 = odrConfig("CONFIG3")
                    Config4 = odrConfig("CONFIG4")
                    Config5 = odrConfig("CONFIG5")
                    Config6 = odrConfig("CONFIG6")
                Loop
            End If
            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub actualizargrillaprov()
        Try
            If Config1 = "Nombre de Proveedor" Then
                PROVEEDORTableAdapter.Fill(Me.DsProveedores.PROVEEDOR)
            Else
                PROVEEDORTableAdapter.FillByOrderByNum(Me.DsProveedores.PROVEEDOR)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pbxDatosContacto_Click(sender As System.Object, e As System.EventArgs) Handles pbxDatosContacto.Click
        If PanelContacto.Visible = False Then
            PanelContacto.Visible = True
            PanelContacto.BringToFront()
            txtNomCont1.Focus()
            pbxDatosContacto.Image = My.Resources.UserActive
        Else
            PanelContacto.Visible = False
            pbxDatosContacto.Image = My.Resources.User
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs)
        PanelContacto.Visible = False
        pbxDatosContacto.Image = My.Resources.User
    End Sub

    Private Sub pbxDatosContacto_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbxDatosContacto.MouseDown
        If pbxDatosContacto.Enabled = True Then
            pbxDatosContacto.Image = My.Resources.UserMouseDown
        End If
    End Sub

    Private Sub PictureBoxActivo_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxActivo.Click
        Permiso = PermisoAplicado(UsuCodigo, 259)
        If Permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Activar/Desactivar un Proveedor", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If ProveedorActivo = 0 Then
            ProveedorActivo = 1
            PictureBoxActivo.Image = My.Resources.AbiertoActive
            lblActivo.ForeColor = Color.OrangeRed
            lblActivo.Text = "Activo"
        ElseIf ProveedorActivo = 1 Then
            ProveedorActivo = 0
            PictureBoxActivo.Image = My.Resources.AbiertoOff
            lblActivo.ForeColor = Color.Black
            lblActivo.Text = "Inactivo"
        End If
    End Sub

    Private Sub RucProveedorTextBox_LostFocus(sender As Object, e As EventArgs) Handles RucProveedorTextBox.LostFocus
        lblMensajeError.Visible = False
        'LblInfoDV.Visible = False
        If RucProveedorTextBox.Text <> "" Then
            If btnuevo = 1 Or btmodificar = 1 Then
                Dim existeruc As String
                existeruc = f.FuncionConsultaString("NOMBRE", "PROVEEDOR", "RUC_CIN", Me.RucProveedorTextBox.Text)
                If existeruc = Nothing Or existeruc = "" Then
                    'No existe el ruc
                    RucProveedorTextBox.BackColor = SystemColors.ControlLightLight
                    GoTo fin
                Else
                    If btmodificar = 1 And Trim(existeruc) = Trim(lblNombre.Text) Then
                        'Esta Modificando el Cliente dueño del Ruc, entonces no hacer nada
                        'En el caso de los mismos nombres..estos tienen el mismo RUC, entonces esta bien permitirle
                        RucProveedorTextBox.BackColor = SystemColors.ControlLightLight
                        GoTo fin
                    End If
                    lblMensajeError.Visible = True
                    RucProveedorTextBox.BackColor = Color.Pink
                End If
            End If
        End If
fin:
        'tbxRUC.BackColor =  SystemColors.controllightlight
    End Sub

    Private Sub btnAddPais_Click(sender As Object, e As EventArgs) Handles btnAddPais.Click
        ABMPaisV2.ShowDialog()
        Me.PAISTableAdapter.Fill(Me.DsCliente.PAIS)
        Me.CIUDADTableAdapter.Fill(Me.DsCliente.CIUDAD)
        Me.ZONATableAdapter.Fill(Me.DsCliente.ZONA)
    End Sub

    Private Sub btnIrLink_Click(sender As Object, e As EventArgs) Handles btnIrLink.Click
        '// Utiliza el Navegador predeterminado
        Dim link As String
        link = txtGMaps.Text
        Try
            Process.Start(link)
        Catch ex As Exception
            MessageBox.Show("No hay direccion que abrir", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnVerContacto_Click(sender As Object, e As EventArgs) Handles btnVerContacto.Click
        pnlContacto.BringToFront()
        pnlContacto.Visible = True
        lblNombreContacto.Text = tbxContacto.Text
    End Sub

    Private Sub tbxCelContacto_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCelContacto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If InStr(1, "0123456789" & Chr(15), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

        If KeyAscii = 27 Then
            pnlContacto.SendToBack()
            pnlContacto.Visible = False
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxMail1Contacto_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxMail1Contacto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxMail2Contacto.Focus()
        ElseIf KeyAscii = 27 Then
            pnlContacto.SendToBack()
            pnlContacto.Visible = False
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxMail2Contacto_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxMail2Contacto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxTelContacto.Focus()
        ElseIf KeyAscii = 27 Then
            pnlContacto.SendToBack()
            pnlContacto.Visible = False
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxTelContacto_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxTelContacto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If InStr(1, "0123456789" & Chr(15), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

        If KeyAscii = 13 Then
            tbxCelContacto.Focus()
            KeyAscii = 0
        ElseIf KeyAscii = 27 Then
            pnlContacto.SendToBack()
            pnlContacto.Visible = False
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxCodPostal_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCodPostal.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If InStr(1, "0123456789" & Chr(15), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

        If KeyAscii = 13 Then
            CategoriaComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub


    Private Sub dtpVtoTimbrado_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpVtoTimbrado.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxRepresentanteLegal.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxRepresentanteLegal_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxRepresentanteLegal.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxContacto.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxContacto_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxContacto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TelefonoProveedorTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub DireccionProveedorTextBox_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DireccionProveedorTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtGMaps.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub txtGMaps_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGMaps.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbPais.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cmbPais_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPais.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxCiudad.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxCiudad_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxCiudad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxZona.Focus()
            KeyAscii = 0
        End If
    End Sub


    Private Sub cbxZona_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxZona.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxCodPostal.Focus()
            KeyAscii = 0
        End If
    End Sub

End Class