Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Osuna.Utiles.Conectividad
Imports EnviaInformes

Public Class ClientesAdherentes
    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction
    Dim dr As SqlDataReader
    Dim f As New Funciones.Funciones

    Dim permiso As Double
    Dim IsNew, ClienteActivo As Integer
    Dim Sql As String
    Dim vgLineaDetalle As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand
        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub ClientesAdherentes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If NuevoPictureBox.Enabled = True Then
                NuevoPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F6 Then
            If ModificarPictureBox.Enabled = True Then
                ModificarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F7 Then
            If GuardarPictureBox.Enabled = True Then
                GuardarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F8 Then
            PictureBox1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ClientesAdherentes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 7)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Acceder esta Ventana", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        Try
            Me.PAISTableAdapter.Fill(Me.DsClientesAdherentes.PAIS)
            Me.CAJATableAdapter.Fill(Me.DsClientesAdherentes.CAJA)
            Me.PRODUCTOSTableAdapter.Fill(Me.DsClientesAdherentes.PRODUCTOS)
            Me.VENDEDORTableAdapter.Fill(Me.DsClientesAdherentes.VENDEDOR)
            Me.CLIENTESTableAdapter.Fill(Me.DsClientesAdherentes.CLIENTES)

            cbxSexo.Items.Add("Masculino")
            cbxSexo.Items.Add("Femenino")

            cbxSexoAdherente.Items.Add("Masculino")
            cbxSexoAdherente.Items.Add("Femenino")
        Catch ex As Exception

        End Try

        DesHabilita()
        BuscarTextBox.Focus()
        IsNew = 0 : ClienteActivo = 0
    End Sub

    Public Sub Habilita()
        'Campos
        tbxNroRegistro.Enabled = True
        dtpFechaInicio.Enabled = True
        tbxCliente.Enabled = True
        tbxRuc.Enabled = True
        tbxDireccion.Enabled = True
        tbxTelefono.Enabled = True
        dtpFechaNac.Enabled = True
        cbxNacionalidad.Enabled = True
        cbxVendedor.Enabled = True
        cbxPlan.Enabled = True
        tbxNroTarjeta.Enabled = True
        cbxBanco.Enabled = True
        tbxEmpresa.Enabled = True
        tbxSeccion.Enabled = True
        tbxDirEmpresa.Enabled = True
        tbxTelEmpresa.Enabled = True
        tbxMonto.Enabled = True
        cbxSexo.Enabled = True
        cbxSexoAdherente.Enabled = True

        tbxAdherentes.Enabled = True
        txtRucAdherente.Enabled = True
        dtpFechaNacAdhe.Enabled = True
        tbxParentesco.Enabled = True
        tbxMontoAdherente.Enabled = True

        btnAgregarAdh.Enabled = True
        pbxBanco.Enabled = True
        pbxVendedor.Enabled = True
        pbxNacionalidad.Enabled = True
        pbxPlanes.Enabled = True

        'Botonera
        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Cursor = Cursors.Arrow
        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Image = My.Resources.DeleteOff
        EliminarPictureBox.Cursor = Cursors.Arrow
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand
        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        GuardarPictureBox.Cursor = Cursors.Hand

        dgwClientes.Enabled = False
        BuscarTextBox.Enabled = False

        dgwAdherentes.Enabled = True
        PictureBoxActivo.Enabled = True
    End Sub

    Public Sub DesHabilita()
        'Campos
        tbxNroRegistro.Enabled = False
        dtpFechaInicio.Enabled = False
        tbxCliente.Enabled = False
        tbxRuc.Enabled = False
        tbxDireccion.Enabled = False
        tbxTelefono.Enabled = False
        dtpFechaNac.Enabled = False
        cbxNacionalidad.Enabled = False
        cbxVendedor.Enabled = False
        cbxPlan.Enabled = False
        tbxNroTarjeta.Enabled = False
        cbxBanco.Enabled = False
        tbxEmpresa.Enabled = False
        tbxSeccion.Enabled = False
        tbxDirEmpresa.Enabled = False
        tbxTelEmpresa.Enabled = False
        tbxMonto.Enabled = False
        cbxSexo.Enabled = False
        cbxSexoAdherente.Enabled = False

        tbxAdherentes.Enabled = False
        txtRucAdherente.Enabled = False
        dtpFechaNacAdhe.Enabled = False
        tbxParentesco.Enabled = False
        tbxMontoAdherente.Enabled = False

        btnAgregarAdh.Enabled = False
        pbxBanco.Enabled = False
        pbxVendedor.Enabled = False
        pbxNacionalidad.Enabled = False
        pbxPlanes.Enabled = False

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
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        dgwClientes.Enabled = True
        BuscarTextBox.Enabled = True

        dgwAdherentes.Enabled = False
        PictureBoxActivo.Enabled = False
    End Sub

    Private Sub pbxNacionalidad_Click(sender As System.Object, e As System.EventArgs) Handles pbxNacionalidad.Click
        ABMPaisV2.ShowDialog()
        Me.PAISTableAdapter.Fill(Me.DsClientesAdherentes.PAIS)
    End Sub

    Private Sub pbxVendedor_Click(sender As System.Object, e As System.EventArgs) Handles pbxVendedor.Click
        ABMVendedorV2.ShowDialog()
        Me.VENDEDORTableAdapter.Fill(Me.DsClientesAdherentes.VENDEDOR)
    End Sub

    Private Sub pbxBanco_Click(sender As System.Object, e As System.EventArgs) Handles pbxBanco.Click
        ABMCaja.ShowDialog()
        Me.CAJATableAdapter.Fill(Me.DsClientesAdherentes.CAJA)
    End Sub

    Private Sub pbxPlanes_Click(sender As System.Object, e As System.EventArgs) Handles pbxPlanes.Click
        Producto.Show()
        Producto.Opacity = 1
        Me.PRODUCTOSTableAdapter.Fill(Me.DsClientesAdherentes.PRODUCTOS)
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 8)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Crear un Cliente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            IsNew = 1 : ClienteActivo = 1
            Habilita()
            CLIENTESBindingSource.AddNew()
            dtpFechaInicio.Value = Now : dtpFechaNac.Value = Now : dtpFechaNacAdhe.Value = Now

            PictureBoxActivo.Image = My.Resources.AbiertoActive
            lblActivo.ForeColor = Color.OrangeRed
            lblActivo.Text = "Activo"

            NuevoPictureBox.Image = My.Resources.NewActive
            cbxBanco.Text = "" : cbxNacionalidad.Text = "" : tbxTotalMontoCuota.Text = "" : dtpFechaBaja.Value = Now
            tbxAdherentes.Text = "" : txtRucAdherente.Text = "" : dtpFechaNacAdhe.Value = Now : tbxParentesco.Text = "" : tbxMontoAdherente.Text = ""

            tbxNroRegistro.Focus()
        End If
    End Sub

    Private Sub tbxNroRegistro_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNroRegistro.GotFocus
        tbxNroRegistro.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxNroRegistro_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroRegistro.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            dtpFechaInicio.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxNroRegistro_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroRegistro.LostFocus
        tbxNroRegistro.BackColor = SystemColors.ControlLightLight

        'Verificamos sis el contrato no esta duplicado
        Try
            Dim ExisteContrato As Integer = f.FuncionExisteDuplicados("NUMCLIENTE", "CLIENTES", "NUMCLIENTE", tbxNroRegistro.Text)
            If ExisteContrato > 0 And IsNew = 1 Then
                MessageBox.Show("Numero de Contrato Duplicado. Favor verificar", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpFechaInicio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaInicio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxCliente.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCliente_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCliente.GotFocus
        tbxCliente.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxRuc.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCliente_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCliente.LostFocus
        tbxCliente.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxRuc_GotFocus(sender As Object, e As System.EventArgs) Handles tbxRuc.GotFocus
        tbxRuc.BackColor = SystemColors.Highlight
        LblInfoDV.Visible = True
    End Sub

    Private Sub tbxRuc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxRuc.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxDireccion.Focus()
        End If

        If KeyAscii = 42 Then
            Dim str As String
            Dim cadena As String

            str = tbxRuc.Text
            cadena = str.Substring(str.Length - 2, 1)

            If cadena <> "-" Then
                Dim DV As Integer
                DV = getDV(tbxRuc.Text)
                tbxRuc.Text = tbxRuc.Text & "-" & DV
            End If
            KeyAscii = 0
        End If

            If KeyAscii = 0 Then
                e.Handled = True
            End If
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

    Private Sub tbxRuc_LostFocus(sender As Object, e As System.EventArgs) Handles tbxRuc.LostFocus
        tbxRuc.BackColor = SystemColors.ControlLightLight
        LblInfoDV.Visible = False
    End Sub

    Private Sub tbxDireccion_GotFocus(sender As Object, e As System.EventArgs) Handles tbxDireccion.GotFocus
        tbxDireccion.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxDireccion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxDireccion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxTelefono.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxDireccion_LostFocus(sender As Object, e As System.EventArgs) Handles tbxDireccion.LostFocus
        tbxDireccion.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub dtpFechaNac_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaNac.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxNacionalidad.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxTelefono_GotFocus(sender As Object, e As System.EventArgs) Handles tbxTelefono.GotFocus
        tbxTelefono.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxTelefono_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxTelefono.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            dtpFechaNac.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxTelefono_LostFocus(sender As Object, e As System.EventArgs) Handles tbxTelefono.LostFocus
        tbxTelefono.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub dtpFechaNac_LostFocus(sender As Object, e As System.EventArgs) Handles dtpFechaNac.LostFocus
        'calculamos la edad del cliente
        tbxEdad.Text = CalcularEdad(dtpFechaNac.Value)
    End Sub

    Public Function CalcularEdad(ByVal FechaNac As Date) As Int32
        Dim Edad As Int32
        Diferencia = Today.Subtract(FechaNac)
        Edad = Fix(Diferencia.TotalDays / 365.25)
        Return Edad
    End Function

    Private Sub cbxNacionalidad_GotFocus(sender As Object, e As System.EventArgs) Handles cbxNacionalidad.GotFocus
        cbxNacionalidad.BackColor = SystemColors.Highlight
    End Sub

    Private Sub cbxNacionalidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxNacionalidad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxSexo.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxSexo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxSexo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxPlan.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxNacionalidad_LostFocus(sender As Object, e As System.EventArgs) Handles cbxNacionalidad.LostFocus
        cbxNacionalidad.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub cbxVendedor_GotFocus(sender As Object, e As System.EventArgs) Handles cbxVendedor.GotFocus
        cbxVendedor.BackColor = SystemColors.Highlight
    End Sub

    Private Sub cbxVendedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxVendedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxNroTarjeta.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxVendedor_LostFocus(sender As Object, e As System.EventArgs) Handles cbxVendedor.LostFocus
        cbxVendedor.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub cbxPlan_GotFocus(sender As Object, e As System.EventArgs) Handles cbxPlan.GotFocus
        cbxPlan.BackColor = SystemColors.Highlight
    End Sub

    Private Sub cbxPlan_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxPlan.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxVendedor.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxPlan_LostFocus(sender As Object, e As System.EventArgs) Handles cbxPlan.LostFocus
        Dim objCommand As New SqlCommand
        cbxPlan.BackColor = SystemColors.ControlLightLight

        'debemos obtener el monto del Plan
        Try
            If cbxPlan.Text <> "" Then
                objCommand.CommandText = "SELECT PRECIOVENTA FROM PRECIO WHERE CODPRODUCTO = " & cbxPlan.SelectedValue
                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrPlanMonto As SqlDataReader = objCommand.ExecuteReader()

                If odrPlanMonto.HasRows Then
                    Do While odrPlanMonto.Read()
                        tbxMonto.Text = FormatNumber(odrPlanMonto("PRECIOVENTA"), 0)
                    Loop
                End If

                odrPlanMonto.Close()
                objCommand.Dispose()

                SumarMontoCuota()
            Else
                tbxMonto.Text = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tbxNroTarjeta_GotFocus(sender As Object, e As System.EventArgs) Handles tbxNroTarjeta.GotFocus
        tbxNroTarjeta.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxNroTarjeta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroTarjeta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxBanco.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxNroTarjeta_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroTarjeta.LostFocus
        tbxNroTarjeta.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub cbxBanco_GotFocus(sender As Object, e As System.EventArgs) Handles cbxBanco.GotFocus
        cbxBanco.BackColor = SystemColors.Highlight
    End Sub

    Private Sub cbxBanco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxBanco.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxEmpresa.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxBanco_LostFocus(sender As Object, e As System.EventArgs) Handles cbxBanco.LostFocus
        cbxBanco.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxEmpresa_GotFocus(sender As Object, e As System.EventArgs) Handles tbxEmpresa.GotFocus
        tbxEmpresa.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxEmpresa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxEmpresa.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxSeccion.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxEmpresa_LostFocus(sender As Object, e As System.EventArgs) Handles tbxEmpresa.LostFocus
        tbxEmpresa.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxSeccion_GotFocus(sender As Object, e As System.EventArgs) Handles tbxSeccion.GotFocus
        tbxSeccion.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxSeccion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxSeccion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxDirEmpresa.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxSeccion_LostFocus(sender As Object, e As System.EventArgs) Handles tbxSeccion.LostFocus
        tbxSeccion.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxDirEmpresa_GotFocus(sender As Object, e As System.EventArgs) Handles tbxDirEmpresa.GotFocus
        tbxDirEmpresa.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxDirEmpresa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxDirEmpresa.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxTelEmpresa.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxDirEmpresa_LostFocus(sender As Object, e As System.EventArgs) Handles tbxDirEmpresa.LostFocus
        tbxDirEmpresa.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxTelEmpresa_GotFocus(sender As Object, e As System.EventArgs) Handles tbxTelEmpresa.GotFocus
        tbxTelEmpresa.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxTelEmpresa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxTelEmpresa.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxAdherentes.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxTelEmpresa_LostFocus(sender As Object, e As System.EventArgs) Handles tbxTelEmpresa.LostFocus
        tbxTelEmpresa.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxAdherentes_GotFocus(sender As Object, e As System.EventArgs) Handles tbxAdherentes.GotFocus
        tbxAdherentes.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxAdherentes_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxAdherentes.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtRucAdherente.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxAdherentes_LostFocus(sender As Object, e As System.EventArgs) Handles tbxAdherentes.LostFocus
        tbxAdherentes.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub txtRucAdherente_GotFocus(sender As Object, e As System.EventArgs) Handles txtRucAdherente.GotFocus
        txtRucAdherente.BackColor = SystemColors.Highlight
    End Sub

    Private Sub txtRucAdherente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucAdherente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            dtpFechaNacAdhe.Focus()
        End If

        If KeyAscii = 42 Then
            Dim str As String
            Dim cadena As String

            str = txtRucAdherente.Text
            cadena = str.Substring(str.Length - 2, 1)

            If cadena <> "-" Then
                Dim DV As Integer
                DV = getDV(txtRucAdherente.Text)
                txtRucAdherente.Text = txtRucAdherente.Text & "-" & DV
            End If
            KeyAscii = 0
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRucAdherente_LostFocus(sender As Object, e As System.EventArgs) Handles txtRucAdherente.LostFocus
        txtRucAdherente.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub dtpFechaNacAdhe_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaNacAdhe.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxParentesco.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxParentesco_GotFocus(sender As Object, e As System.EventArgs) Handles tbxParentesco.GotFocus
        tbxParentesco.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxParentesco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxParentesco.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxMontoAdherente.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxParentesco_LostFocus(sender As Object, e As System.EventArgs) Handles tbxParentesco.LostFocus
        tbxParentesco.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxMontoAdherente_GotFocus(sender As Object, e As System.EventArgs) Handles tbxMontoAdherente.GotFocus
        tbxMontoAdherente.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxMontoAdherente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxMontoAdherente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxSexoAdherente.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxMontoAdherente_LostFocus(sender As Object, e As System.EventArgs) Handles tbxMontoAdherente.LostFocus
        tbxMontoAdherente.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub btnAgregarAdh_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarAdh.Click
        Dim c As Integer

        If tbxAdherentes.Text = "" Then
            MessageBox.Show("Ingrese el Nombre del Adherente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxAdherentes.Focus()
            Exit Sub
        End If

        If tbxMontoAdherente.Text = "" Then
            MessageBox.Show("Ingrese el Monto de la Cuota del Adherente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxMontoAdherente.Focus()
            Exit Sub
        End If

        If cbxSexoAdherente.Text = "" Then
            MessageBox.Show("Ingrese el Sexo del Adherente", "R.I.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxSexoAdherente.Focus()
            Exit Sub
        End If

        If btnAgregarAdh.Text = "Agregar" Then
            Try
                ADHERENTESBindingSource.AddNew()

                c = dgwAdherentes.RowCount
                dgwAdherentes.Rows(c - 1).Cells("FECHAINGRESODataGridViewTextBoxColumn").Value = Now.ToShortDateString.ToString
                dgwAdherentes.Rows(c - 1).Cells("NOMBREDataGridViewTextBoxColumn1").Value = tbxAdherentes.Text
                dgwAdherentes.Rows(c - 1).Cells("RUCDataGridViewTextBoxColumn").Value = txtRucAdherente.Text
                dgwAdherentes.Rows(c - 1).Cells("FECHANACIMIENTODataGridViewTextBoxColumn").Value = dtpFechaNacAdhe.Text
                dgwAdherentes.Rows(c - 1).Cells("DVDataGridViewTextBoxColumn").Value = CalcularEdad(dtpFechaNacAdhe.Text)
                dgwAdherentes.Rows(c - 1).Cells("CUSTOMFIELDDataGridViewTextBoxColumn").Value = tbxParentesco.Text
                dgwAdherentes.Rows(c - 1).Cells("LIMCREDITODataGridViewTextBoxColumn").Value = tbxMontoAdherente.Text
                dgwAdherentes.Rows(c - 1).Cells("AUTORIZADO").Value = 1
                dgwAdherentes.Rows(c - 1).Cells("EstadoGrilla").Value = 1 'Nuevo/Insertar
                If cbxSexoAdherente.SelectedIndex = 0 Then
                    dgwAdherentes.Rows(c - 1).Cells("SEXO").Value = 0
                Else
                    dgwAdherentes.Rows(c - 1).Cells("SEXO").Value = 1
                End If

            Catch ex As Exception
                MessageBox.Show("Problema al Insertar Nuevo Adherente: " + ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

        Else
            Try
                dgwAdherentes.Rows(vgLineaDetalle).Cells("NOMBREDataGridViewTextBoxColumn1").Value = tbxAdherentes.Text
                dgwAdherentes.Rows(vgLineaDetalle).Cells("RUCDataGridViewTextBoxColumn").Value = txtRucAdherente.Text
                dgwAdherentes.Rows(vgLineaDetalle).Cells("FECHANACIMIENTODataGridViewTextBoxColumn").Value = dtpFechaNacAdhe.Text
                dgwAdherentes.Rows(vgLineaDetalle).Cells("DVDataGridViewTextBoxColumn").Value = CalcularEdad(dtpFechaNacAdhe.Text)
                dgwAdherentes.Rows(vgLineaDetalle).Cells("CUSTOMFIELDDataGridViewTextBoxColumn").Value = tbxParentesco.Text
                dgwAdherentes.Rows(vgLineaDetalle).Cells("LIMCREDITODataGridViewTextBoxColumn").Value = tbxMontoAdherente.Text
                dgwAdherentes.Rows(vgLineaDetalle).Cells("AUTORIZADO").Value = 1
                dgwAdherentes.Rows(vgLineaDetalle).Cells("EstadoGrilla").Value = 2 'Editar/Update
                If cbxSexoAdherente.SelectedValue = 0 Then
                    dgwAdherentes.Rows(c - 1).Cells("SEXO").Value = 0
                Else
                    dgwAdherentes.Rows(c - 1).Cells("SEXO").Value = 1
                End If

            Catch ex As Exception
                MessageBox.Show("Problema al Editar Adherente: " + ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If

        tbxAdherentes.Text = "" : txtRucAdherente.Text = "" : dtpFechaNacAdhe.Value = Now : tbxParentesco.Text = "" : tbxMontoAdherente.Text = ""
        tbxAdherentes.Focus()
        btnAgregarAdh.Text = "Agregar"
        SumarMontoCuota()
    End Sub

    Sub SumarMontoCuota()
        Dim TotalMontoCuota, MontoCliente, MontoAdherente As Integer
        TotalMontoCuota = 0 : MontoCliente = 0 : MontoAdherente = 0

        If tbxMonto.Text <> "" Then
            MontoCliente = CInt(tbxMonto.Text)
        End If

        If dgwAdherentes.RowCount <> 0 Then
            For i = 0 To dgwAdherentes.RowCount - 1
                If dgwAdherentes.Rows(i).Cells("AUTORIZADO").Value = 1 Then
                    MontoAdherente = MontoAdherente + CInt(dgwAdherentes.Rows(i).Cells("LIMCREDITODataGridViewTextBoxColumn").Value)
                End If
            Next
        End If

        TotalMontoCuota = MontoCliente + MontoAdherente
        tbxTotalMontoCuota.Text = FormatNumber(TotalMontoCuota, 0)
    End Sub

    Private Sub PictureBoxActivo_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxActivo.Click
        permiso = PermisoAplicado(UsuCodigo, 227)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Activar/Desactivar un Cliente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If ClienteActivo = 0 Then
            ClienteActivo = 1
            PictureBoxActivo.Image = My.Resources.AbiertoActive
            lblActivo.ForeColor = Color.OrangeRed
            lblActivo.Text = "Activo"

            pnlBaja.Visible = False
            pbxMostrarOBS.Image = My.Resources.Display

        ElseIf ClienteActivo = 1 Then
            ClienteActivo = 0
            PictureBoxActivo.Image = My.Resources.AbiertoOff
            lblActivo.ForeColor = Color.Black
            lblActivo.Text = "Inactivo"

            dtpFechaBaja.Value = Now

            pnlBaja.Visible = True
            pbxMostrarOBS.Image = My.Resources.DisplayActive

        End If
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Try
            DesHabilita()
            CLIENTESBindingSource.CancelEdit()
            ADHERENTESBindingSource.CancelEdit()

            Me.CLIENTESTableAdapter.Fill(Me.DsClientesAdherentes.CLIENTES)

            tbxAdherentes.Text = "" : txtRucAdherente.Text = "" : dtpFechaNacAdhe.Value = Now : tbxParentesco.Text = "" : tbxMontoAdherente.Text = "" : IsNew = 0
            btnAgregarAdh.Text = "Agregar"
            BuscarTextBox.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim CodCliente As Integer

        'Verificamos que no deje en blanco los campos principales
        If tbxNroRegistro.Text = "" Then
            MessageBox.Show("Ingrese el Nro de Registro", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxNroRegistro.Focus()
            Exit Sub
        End If

        If tbxCliente.Text = "" Then
            MessageBox.Show("Ingrese el Cliente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxCliente.Focus()
            Exit Sub
        End If

        If tbxRuc.Text = "" Then
            MessageBox.Show("Ingrese el RUC/CI", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxRuc.Focus()
            Exit Sub
        End If

        If tbxDireccion.Text = "" Then
            MessageBox.Show("Ingrese la Direccion del Cliente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxDireccion.Focus()
            Exit Sub
        End If

        If tbxTelefono.Text = "" Then
            MessageBox.Show("Ingrese el Telefono del Cliente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxTelefono.Focus()
            Exit Sub
        End If

        If cbxPlan.Text = "" Or tbxMonto.Text = "" Then
            MessageBox.Show("Ingrese un Tipo de Plan para el Cliente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxPlan.Focus()
            Exit Sub
        End If

        Dim codVendedor As String = cbxVendedor.SelectedValue
        If codVendedor = "" Then
            codVendedor = "NULL"
        End If

        Dim codPais As String = cbxNacionalidad.SelectedValue
        If codPais = "" Then
            codPais = "NULL"
        End If

        ' Dim sexoadherente As Integer
        'If cbxSexoAdherente.SelectedIndex = 0 Then
        'sexoadherente = 0
        'Else
        'sexoadherente = 1
        'End If

        Dim sexoprincipal As Integer
        If cbxSexo.SelectedIndex = 0 Then
            sexoprincipal = 0
        Else
            sexoprincipal = 1
        End If

        'Guardamos los Datos
        If IsNew = 1 Then 'Insertamos
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                'Insertamos Cliente Cabecera
                Sql = "INSERT INTO CLIENTES ([CODUSUARIO],[CODVENDEDOR],[NUMCLIENTE],[NOMBRE],[RUC],[DIRECCION],[TELEFONO],[LIMCREDITO],[FECHAINGRESO],[DIRENVIO]," & _
                      "[NUMEROTOL],[FECHANACIMIENTO],[CODPAIS],[EMPPRESACLIENTE],[PROVEEDOR_ID],[TELEFONO1],[DV],[CUSTOMFIELD],[TIPORELACION],[RELACION],[SEPSA], [AUTORIZADO],Sexo,OBSERVACION) " & _
                      "VALUES(" & UsuCodigo & "," & codVendedor & "," & tbxNroRegistro.Text & ",'" & tbxCliente.Text & "','" & tbxRuc.Text & "','" & Replace(tbxDireccion.Text, "'", "''") & "','" & _
                      tbxTelefono.Text & "'," & Funciones.Cadenas.QuitarCad(tbxMonto.Text, ".") & ", CONVERT(DATETIME,'" & dtpFechaInicio.Text & "',103) , '" & Replace(tbxDirEmpresa.Text, "'", "''") & "', '" &
                      tbxSeccion.Text & "', CONVERT(DATETIME,'" & dtpFechaNac.Text & "',103), " & codPais & ",'" & Replace(tbxEmpresa.Text, "'", "''") & "'," & cbxPlan.SelectedValue & ", '" & _
                      tbxTelEmpresa.Text & "'," & tbxEdad.Text & ",'" & tbxNroTarjeta.Text & "', 1 , 0 , '" & cbxBanco.SelectedValue & "', 1, " & sexoprincipal & ",'" & txtComentario.Text & "')  " & _
                      " SELECT CODCLIENTE FROM CLIENTES WHERE CODCLIENTE = SCOPE_IDENTITY()" & _
                      " UPDATE CLIENTES SET RELACION = CODCLIENTE  WHERE CODCLIENTE = SCOPE_IDENTITY()"

                cmd.CommandText = Sql
                CodCliente = cmd.ExecuteScalar()

                'Insertamos Clientes Adherentes
                InsertaActualizaAdherentes(CodCliente)

                myTrans.Commit()

            Catch ex As Exception
                myTrans.Rollback("Insertar")
            Finally
                sqlc.Close()
            End Try

        Else 'Editamos
            CodCliente = dgwClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                'Insertamos Cliente Cabecera
                Sql = "UPDATE CLIENTES SET CODVENDEDOR = " & codVendedor & ", NUMCLIENTE = " & tbxNroRegistro.Text & " , NOMBRE = '" & tbxCliente.Text & "', RUC = '" & _
                      tbxRuc.Text & "', DIRECCION = '" & Replace(tbxDireccion.Text, "'", "''") & "', TELEFONO = '" & tbxTelefono.Text & "', LIMCREDITO = " & Funciones.Cadenas.QuitarCad(tbxMonto.Text, ".") & "," & _
                      "FECHAINGRESO = CONVERT(DATETIME,'" & dtpFechaInicio.Text & "',103), DIRENVIO = '" & Replace(tbxDirEmpresa.Text, "'", "''") & "', NUMEROTOL = '" & tbxSeccion.Text & "', FECHANACIMIENTO = CONVERT(DATETIME,'" & dtpFechaNac.Text & "',103) , " & _
                      "CODPAIS = " & codPais & ", EMPPRESACLIENTE = '" & Replace(tbxEmpresa.Text, "'", "''") & "', PROVEEDOR_ID = " & cbxPlan.SelectedValue & ", TELEFONO1 = '" & tbxTelEmpresa.Text & "', DV = " & tbxEdad.Text & ", CUSTOMFIELD = '" & tbxNroTarjeta.Text & _
                      "', SEPSA = '" & cbxBanco.SelectedValue & "', AUTORIZADO = " & ClienteActivo & ", OBSERVACION = '" & txtComentario.Text & "' , FECAUTORIZACION = CONVERT(DATETIME,'" & dtpFechaBaja.Text & "',103)   " & _
                      ",Sexo=" & sexoprincipal & _
                      " WHERE CodCliente = " & CodCliente

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

                'Insertamos/Actualiza Clientes Adherentes
                InsertaActualizaAdherentes(CodCliente)

                myTrans.Commit()

            Catch ex As Exception
                myTrans.Rollback("Actualizar")
            Finally
                sqlc.Close()
            End Try

        End If

        'Nos posicionamos en el registro creado
        CLIENTESTableAdapter.Fill(Me.DsClientesAdherentes.CLIENTES)
        For i = 0 To dgwClientes.Rows.Count - 1
            If dgwClientes.Rows(i).Cells("CODCLIENTEDataGridViewTextBoxColumn").Value = CodCliente Then
                CLIENTESBindingSource.Position = i
            End If
        Next

        DesHabilita()
        IsNew = 0
        BuscarTextBox.Focus()
    End Sub

    Private Sub InsertaActualizaAdherentes(ByVal CodCliente As Integer)
        Sql = ""

        Dim codVendedor As String = cbxVendedor.SelectedValue
        If codVendedor = "" Then
            codVendedor = "NULL"
        End If

        
        If dgwAdherentes.Rows.Count <> 0 Then

            Dim sexoadherente As Integer
            If cbxSexoAdherente.SelectedIndex = 0 Then
                sexoadherente = 0
            Else
                sexoadherente = 1
            End If


            For i = 0 To dgwAdherentes.Rows.Count - 1
                If dgwAdherentes.Rows(i).Cells("EstadoGrilla").Value = 1 Then 'Insertar
                    Sql = Sql + "   INSERT INTO CLIENTES ([CODUSUARIO],[CODVENDEDOR],[NUMCLIENTE],[NOMBRE],[RUC],[LIMCREDITO],[FECHAINGRESO],[FECHANACIMIENTO],[DV],[CUSTOMFIELD],[TIPORELACION],[RELACION],[AUTORIZADO],Sexo) " & _
                    "VALUES(" & UsuCodigo & "," & codVendedor & "," & tbxNroRegistro.Text & ",'" & dgwAdherentes.Rows(i).Cells("NOMBREDataGridViewTextBoxColumn1").Value & "','" & dgwAdherentes.Rows(i).Cells("RUCDataGridViewTextBoxColumn").Value & "'," & _
                    dgwAdherentes.Rows(i).Cells("LIMCREDITODataGridViewTextBoxColumn").Value & ", CONVERT(DATETIME,'" & dgwAdherentes.Rows(i).Cells("FECHAINGRESODataGridViewTextBoxColumn").Value & "',103), CONVERT(DATETIME,'" & dgwAdherentes.Rows(i).Cells("FECHANACIMIENTODataGridViewTextBoxColumn").Value & "',103) , " & _
                    dgwAdherentes.Rows(i).Cells("DVDataGridViewTextBoxColumn").Value & ",'" & dgwAdherentes.Rows(i).Cells("CUSTOMFIELDDataGridViewTextBoxColumn").Value & "', 6 , " & CodCliente & " , 1, " & dgwAdherentes.Rows(i).Cells("SEXO").Value & " ) "

                ElseIf dgwAdherentes.Rows(i).Cells("EstadoGrilla").Value = 2 Then 'Update
                    Sql = Sql + "   UPDATE CLIENTES SET NOMBRE = '" & dgwAdherentes.Rows(i).Cells("NOMBREDataGridViewTextBoxColumn1").Value & "' , RUC = '" & dgwAdherentes.Rows(i).Cells("RUCDataGridViewTextBoxColumn").Value & "' , LIMCREDITO = " & dgwAdherentes.Rows(i).Cells("LIMCREDITODataGridViewTextBoxColumn").Value & ", " & _
                        "FECHANACIMIENTO = CONVERT(DATETIME,'" & dgwAdherentes.Rows(i).Cells("FECHANACIMIENTODataGridViewTextBoxColumn").Value & "',103) , DV = " & dgwAdherentes.Rows(i).Cells("DVDataGridViewTextBoxColumn").Value & ", CUSTOMFIELD = '" & dgwAdherentes.Rows(i).Cells("CUSTOMFIELDDataGridViewTextBoxColumn").Value & "'  " & _
                        ",Sexo=" & dgwAdherentes.Rows(i).Cells("SEXO").Value & _
                        " WHERE CODCLIENTE = " & dgwAdherentes.Rows(i).Cells("CODCLIENTEDataGridViewTextBoxColumn1").Value

                ElseIf dgwAdherentes.Rows(i).Cells("EstadoGrilla").Value = 3 Then 'Dar de Baja Adherente
                    Sql = Sql + "   UPDATE CLIENTES SET AUTORIZADO = 0, FECAUTORIZACION = GETDATE()  WHERE CODCLIENTE = " & dgwAdherentes.Rows(i).Cells("CODCLIENTEDataGridViewTextBoxColumn1").Value

                End If
            Next

            If Sql <> "" Then
                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            End If
        End If
    End Sub

    Private Sub dgwClientes_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwClientes.SelectionChanged
        Try
            ADHERENTESTableAdapter.Fill(Me.DsClientesAdherentes.ADHERENTES, dgwClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value)
            SumarMontoCuota()
            PintarCeldas()
            tbxMonto.Text = FormatNumber(tbxMonto.Text, 0)

            If Not (dgwClientes.CurrentRow.Cells("colSexo").Value) Is DBNull.Value Then
                cbxSexo.SelectedIndex = dgwClientes.CurrentRow.Cells("colSexo").Value
            End If

            ClienteActivo = dgwClientes.CurrentRow.Cells("AUTORIZADOCLIENTE").Value

            If ClienteActivo = 1 Then
                PictureBoxActivo.Image = My.Resources.AbiertoActive
                lblActivo.ForeColor = Color.OrangeRed
                lblActivo.Text = "Activo"

                pbxImprimir.Image = My.Resources.Print
                pbxImprimir.Enabled = True

                pnlBaja.Visible = False
                pbxMostrarOBS.Image = My.Resources.Display

            ElseIf ClienteActivo = 0 Then
                PictureBoxActivo.Image = My.Resources.AbiertoOff
                lblActivo.ForeColor = Color.Black
                lblActivo.Text = "Inactivo"

                pbxImprimir.Image = My.Resources.PrintOff
                pbxImprimir.Enabled = False

                pnlBaja.Visible = True
                pbxMostrarOBS.Image = My.Resources.DisplayActive
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%'"
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 10)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Modificar este Cliente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        Else
            Habilita()
            tbxCliente.Focus()
            IsNew = 0
        End If
    End Sub

    Private Sub dgwAdherentes_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwAdherentes.DoubleClick
        If dgwAdherentes.Rows.Count <> 0 Then
            vgLineaDetalle = dgwAdherentes.CurrentRow.Index
            tbxAdherentes.Text = dgwAdherentes.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn1").Value
            txtRucAdherente.Text = dgwAdherentes.CurrentRow.Cells("RUCDataGridViewTextBoxColumn").Value
            dtpFechaNacAdhe.Text = dgwAdherentes.CurrentRow.Cells("FECHANACIMIENTODataGridViewTextBoxColumn").Value
            tbxParentesco.Text = dgwAdherentes.CurrentRow.Cells("CUSTOMFIELDDataGridViewTextBoxColumn").Value
            tbxMontoAdherente.Text = FormatNumber(dgwAdherentes.CurrentRow.Cells("LIMCREDITODataGridViewTextBoxColumn").Value, 0)

            btnAgregarAdh.Text = "Editar"
        End If
    End Sub

    Private Sub dgwAdherentes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgwAdherentes.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgwAdherentes.Rows.Count <> 0 Then
                Dim vindex As Integer = dgwAdherentes.CurrentRow.Index

                dgwAdherentes.CurrentRow.Cells("FECAUTORIZACIONDataGridViewTextBoxColumn").Value = Today
                dgwAdherentes.CurrentRow.Cells("AUTORIZADO").Value = 0
                dgwAdherentes.CurrentRow.Cells("EstadoGrilla").Value = 3 'Eliminar / Delete

                For r = 0 To 10
                    dgwAdherentes.Item(r, vindex).Style.BackColor = Color.Firebrick
                Next
            End If
        End If
    End Sub

    Private Sub PintarCeldas()
        If dgwAdherentes.RowCount <> 0 Then
            For i = 0 To dgwAdherentes.RowCount - 1
                If dgwAdherentes.Rows(i).Cells("AUTORIZADO").Value = 0 Then
                    For r = 0 To 10
                        dgwAdherentes.Item(r, i).Style.BackColor = Color.Firebrick
                    Next
                Else
                    For r = 0 To 10
                        dgwAdherentes.Item(r, i).Style.BackColor = Color.White
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub pbxImprimir_Click(sender As System.Object, e As System.EventArgs) Handles pbxImprimir.Click
        Dim dtBeneficios, dtCliente As New DataTable
        Dim drBenf, drCliente, drInf As DataRow
        Dim rpt = New ReportesPersonalizados.ZCarnet
        Dim frm = New VerInformes
        Dim ds As New EnviaInformes.DsInformes
        Dim Campos, Nro As String

        dtCliente = CarnetTableAdapter.GetData(dgwClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value, 1)
        dtBeneficios = CarnetTableAdapter.GetData(dgwClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value, 6)

        If dgwClientes.Rows.Count <> 0 Then
            drInf = ds.Tables("Detalle").NewRow()

            If dtBeneficios.Rows.Count <> 0 Then
                If dtBeneficios.Rows.Count <> 0 Then
                    For i = 0 To dtBeneficios.Rows.Count - 1
                        drBenf = dtBeneficios.Rows.Item(i)
                        Nro = i + 1 : Campos = "Campo" & Nro
                        drInf.Item(Campos) = "- " & drBenf("NOMBRE").ToString
                    Next
                End If
            End If

            For i = 0 To dtCliente.Rows.Count - 1
                drCliente = dtCliente.Rows.Item(i)
                drInf.Item("Campo11") = drCliente("NOMBRE")
                drInf.Item("Campo12") = drCliente("DESPRODUCTO")
                drInf.Item("Fecha1") = drCliente("FECHANACIMIENTO")
                drInf.Item("Fecha2") = drCliente("FECHAINGRESO")
                drInf.Item("Campo15") = drCliente("RUC")
                drInf.Item("Campo16") = drCliente("NUMCLIENTE")
            Next

            ds.Tables("Detalle").Rows.Add(drInf)
        End If
       
        rpt.SetDataSource(ds)
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub pbxMostrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles pbxMostrarOBS.Click
        If pnlBaja.Visible = False Then
            pnlBaja.Visible = True
            pbxMostrarOBS.Image = My.Resources.DisplayActive
        Else
            pnlBaja.Visible = False
            pbxMostrarOBS.Image = My.Resources.Display
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        pnlimprimirCarnet.Visible = True
        chbTodos.Checked = False
        FILLCLIENTESCARNETTableAdapter.Fill(Me.DsClientesAdherentes.FILLCLIENTESCARNET)
    End Sub

    Private Sub btnCerrarImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarImprimir.Click
        pnlimprimirCarnet.Visible = False
    End Sub

    Private Sub btImprimirMultiples_Click(sender As System.Object, e As System.EventArgs) Handles btImprimirMultiples.Click
        Dim dtBeneficios, dtCliente As New DataTable
        Dim drBenf, drCliente, drInf As DataRow
        Dim rpt = New ReportesPersonalizados.ZCarnet
        Dim frm = New VerInformes
        Dim ds As New EnviaInformes.DsInformes
        Dim Campos, Nro As String

        Dim IsChecked As Integer

        If dgwClientesCarnet.Rows.Count <> 0 Then
            For r = 0 To dgwClientesCarnet.Rows.Count - 1
                IsChecked = dgwClientesCarnet.Rows(r).Cells("marcar").Value

                If (IsChecked = -1) Or (IsChecked = 1) Then
                    dtCliente = CarnetTableAdapter.GetData(dgwClientesCarnet.Rows(r).Cells("CODCLIENTEDataGridViewTextBoxColumn2").Value, 1)
                    dtBeneficios = CarnetTableAdapter.GetData(dgwClientesCarnet.Rows(r).Cells("CODCLIENTEDataGridViewTextBoxColumn2").Value, 6)

                    drInf = ds.Tables("Detalle").NewRow()

                    If dtBeneficios.Rows.Count <> 0 Then
                        If dtBeneficios.Rows.Count <> 0 Then
                            For i = 0 To dtBeneficios.Rows.Count - 1
                                drBenf = dtBeneficios.Rows.Item(i)
                                Nro = i + 1 : Campos = "Campo" & Nro
                                drInf.Item(Campos) = "- " & drBenf("NOMBRE").ToString
                            Next
                        End If
                    End If

                    For i = 0 To dtCliente.Rows.Count - 1
                        drCliente = dtCliente.Rows.Item(i)
                        drInf.Item("Campo11") = drCliente("NOMBRE")
                        drInf.Item("Campo12") = drCliente("DESPRODUCTO")
                        drInf.Item("Fecha1") = drCliente("FECHANACIMIENTO")
                        drInf.Item("Fecha2") = drCliente("FECHAINGRESO")
                        drInf.Item("Campo15") = drCliente("RUC")
                        drInf.Item("Campo16") = drCliente("NUMCLIENTE")
                    Next

                    ds.Tables("Detalle").Rows.Add(drInf)
                End If
            Next

            Try
                rpt.SetDataSource(ds)
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Catch ex As Exception
                MessageBox.Show("Seleccione al menos un Cliente", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub chbTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTodos.CheckedChanged
        If chbTodos.Checked = True Then
            For i = 0 To dgwClientesCarnet.Rows.Count - 1
                dgwClientesCarnet.Rows(i).Cells("marcar").Value = 1
            Next
        Else
            For i = 0 To dgwClientesCarnet.Rows.Count - 1
                dgwClientesCarnet.Rows(i).Cells("marcar").Value = 0
            Next
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 9)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Eliminar este Cliente", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else

            If MessageBox.Show("¿Esta seguro que quiere eliminar el Cliente?", "Pos Express", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim transaction As SqlTransaction = Nothing
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                Sql = ""
                Sql = " DELETE FROM CLIENTES  WHERE RELACION= " & dgwClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
                myTrans.Commit()

            Catch ex As SqlException
                Try
                    myTrans.Rollback("")
                Catch
                End Try

                Dim NroError As Integer = ex.Number
                Dim Mensaje As String = ex.Message

                If NroError = 547 Then
                    MessageBox.Show("Este Cliente que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podra eliminar", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al Eliminar Cliente: " + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Finally
                sqlc.Close()
                Me.CLIENTESTableAdapter.Fill(Me.DsClientesAdherentes.CLIENTES)
            End Try
        End If
    End Sub

    Private Sub tsNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsNuevo.Click
        NuevoPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsEditar.Click
        ModificarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsGuardar.Click
        GuardarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsEliminar_Click(sender As System.Object, e As System.EventArgs) Handles tsEliminar.Click
        EliminarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tmsImprimirMultiples_Click(sender As System.Object, e As System.EventArgs) Handles tmsImprimirMultiples.Click
        PictureBox1_Click(Nothing, Nothing)
    End Sub

    Private Sub tsmImprimirCarnet_Click(sender As System.Object, e As System.EventArgs) Handles tsmImprimirCarnet.Click
        pbxImprimir_Click(Nothing, Nothing)
    End Sub

    Private Sub tsCampoDeObservacion_Click(sender As System.Object, e As System.EventArgs) Handles tsCampoDeObservacion.Click
        pbxMostrarOBS_Click(Nothing, Nothing)
    End Sub

    Private Sub LiquidaciónSemanalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LiquidaciónSemanalToolStripMenuItem.Click
        pnlReporteLiquidacion.Visible = True
        dtpFechaDesde.Value = Now : dtpFechaHasta.Value = Now
    End Sub

    Private Sub btnCerrarInforme_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarInforme.Click
        pnlReporteLiquidacion.Visible = False
        BuscarTextBox.Focus()
    End Sub

    Private Sub btnVerInforme_Click(sender As System.Object, e As System.EventArgs) Handles btnVerInforme.Click

        Dim rpt = New Reportes.LiquidacionSemanalVendedores
        Dim frm = New VerInformes

        LiquidacionsemanalTableAdapter.Fill(DsClientesAdherentes.LIQUIDACIONSEMANAL, cbxVendedor.SelectedValue, dtpFechaDesde.Text, dtpFechaHasta.Text)
        VentascaidasliquidacionTableAdapter.Fill(DsClientesAdherentes.VENTASCAIDASLIQUIDACION, cbxVendedor.SelectedValue, dtpFechaDesde.Text, dtpFechaHasta.Text)

        rpt.SetDataSource([DsClientesAdherentes])

        rpt.SetParameterValue("ptmfechadesde", dtpFechaDesde.Value.ToShortDateString.ToString)
        rpt.SetParameterValue("ptmfechahasta", dtpFechaHasta.Value.ToShortDateString.ToString)
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()

    End Sub

    Private Sub tbxMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxMonto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxNroTarjeta.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbxSexoAdherente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxSexoAdherente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            btnAgregarAdh.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub AgregarComentarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarComentarioToolStripMenuItem.Click
        pnlObservacion.BringToFront()
        pnlObservacion.Visible = True
        txtObservacion.Focus()
    End Sub

    Private Sub btnCerrarOBS_Click(sender As Object, e As EventArgs) Handles btnCerrarOBS.Click

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            Sql = "UPDATE CLIENTES SET OBSERVACION = '" & txtObservacion.Text & "' WHERE NUMCLIENTE = " & dgwClientes.CurrentRow.Cells("NUMCLIENTEDataGridViewTextBoxColumn").Value

            cmd.CommandText = Sql
            myTrans.Commit()

        Catch ex As Exception
            myTrans.Rollback("Insertar")
        Finally
            sqlc.Close()
            pnlObservacion.SendToBack()
            pnlObservacion.Visible = False
        End Try

    End Sub

    Private Sub pbxRefresh_Click(sender As Object, e As EventArgs) Handles pbxRefresh.Click
        Me.CLIENTESTableAdapter.Fill(Me.DsClientesAdherentes.CLIENTES)
    End Sub
End Class