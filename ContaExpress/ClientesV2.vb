Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.ToolStripMenuItem
Imports Osuna.Utiles.Conectividad
Imports System.Net
Imports System.IO


Public Class ClientesV2

#Region "Fields"
    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction
    Dim dr As SqlDataReader
    Dim f As New Funciones.Funciones
    Dim clienteActivo As Integer

    'Permisos
    Dim pri As Integer
    Dim sel As Integer
    Dim sql As String
    Dim upd As Integer
    Dim ins As Integer
    Dim del As Integer
    Dim anu As Integer
    Dim permiso As Double
    'Variables Globales de Clientes
    Dim CodClienteGlobal As Integer
    Dim IsNew, IsEdit As Integer
    Dim VGRUCClienteR As String
    Dim Config1, Config2, Config3, Config4, Config5, Config6 As String
    Dim btnuevo, btmodificar As Integer
    Dim FechaDesde As String
    Dim FechaHasta As String
    'Dim re As New Regex("[^0-9_\-\b]", RegexOptions.IgnoreCase)

#End Region

#Region "DB Connection"
    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

#End Region

#Region "Metodos"

    Private Sub ClientesV2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        VentasPlus.CLIENTESTableAdapter.Fill(VentasPlus.DsFacturacionCompleja.CLIENTES)
        VentasSimple.CLIENTESTableAdapter.Fill(VentasSimple.DsFacturacionSimple.CLIENTES)
    End Sub

    Private Sub ClientesV2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F2 Then
            CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & txtCliente.Text & "%' AND CODVENDEDOR = '%" & cbxRepVendedor.SelectedValue & "%'"
        End If
    End Sub

    Private Sub ClientesV2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)

        permiso = PermisoAplicado(UsuCodigo, 7)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Acceder esta Ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        PictureBoxActivo.Enabled = False
        btnuevo = 0 : btmodificar = 0

        Me.PAISTableAdapter.Fill(Me.DsCliente.PAIS)
        Me.CATEGORIACLIENTETableAdapter.Fill(Me.DsCliente.CATEGORIACLIENTE)
        Me.CIUDADTableAdapter.Fill(Me.DsCliente.CIUDAD)
        Me.ZONATableAdapter.Fill(Me.DsCliente.ZONA)
        Me.VENDEDORTableAdapter.Fill(Me.DsCliente.VENDEDOR)
        Me.TIPOCLIENTETableAdapter.Fill(Me.DsCliente.TIPOCLIENTE)
        Me.CLIENTESRELACIONTableAdapter.Fill(Me.DsCliente.CLIENTESRELACION)

        ObtenerConfig()
        actualizargrillaclientes()

        If dgvClientes.RowCount > 0 Then
            'Me.RvMovimientosClienteTableAdapter.Fill(DsRVFacturacion.RVMovimientosCliente, dgvClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value)
        End If
        'Permisos

        DesHabilita()
        pnlDatosCliente.BringToFront()

        IsNew = 0
        IsEdit = 0

        If Config1 = "Nombre de Cliente" Then
            NUMCLIENTEDataGridViewTextBoxColumn.Visible = False
            dgvClientes.ScrollBars = ScrollBars.Vertical
        ElseIf Config1 = "Nro. de Cliente" Then
            NUMCLIENTEDataGridViewTextBoxColumn.Visible = True
            dgvClientes.ScrollBars = ScrollBars.Both
        End If

        If Config2 = "" Then
            Me.LbCustomField.Text = "Custom Field:"
        Else
            Me.LbCustomField.Text = Config2 + ":"
        End If

    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

            objCommand.CommandText = "SELECT CONFIG1, CONFIG2, CONFIG3, CONFIG4, CONFIG5, CONFIG6 FROM MODULO WHERE MODULO_ID = 7"
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
        
    End Sub

    Public Sub Habilita()

        pnlDatosCliente.Enabled = True
        pnlFinanzas2.Enabled = True
        txtNroCliente.Enabled = True
        tbxFantasia.Enabled = True

        'Botonera
        PictureBoxActivo.Enabled = True
        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Cursor = Cursors.Arrow
        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Image = My.Resources.DeleteOff
        EliminarPictureBox.Cursor = Cursors.Arrow
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        tsNuevo.Enabled = False
        tsEditar.Enabled = False
        tsEliminar.Enabled = False
        tsGuardar.Enabled = True

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand
        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        GuardarPictureBox.Cursor = Cursors.Hand

        lblNombre.Visible = False
        txtCliente.Visible = True
        txtCliente.Text = lblNombre.Text
        cbxTipoRelacion.Enabled = True
        txtNombreClienteR.Enabled = False

        dgvClientes.Enabled = False

        BuscarTextBox.Enabled = False

        Me.tbxCantCuotas.Enabled = True


    End Sub

    Public Sub DesHabilita()
        pnlDatosCliente.Enabled = False
        pnlFinanzas2.Enabled = False
        txtNroCliente.Enabled = False
        tbxFantasia.Enabled = False
        txtNombreClienteR.Enabled = False
        lblNombre.Visible = True
        txtCliente.Visible = False
        cbxTipoRelacion.Enabled = False
        LblInfoDV.Visible = False

        'Botonera
        PictureBoxActivo.Enabled = False
        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Cursor = Cursors.Hand
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Cursor = Cursors.Hand
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Cursor = Cursors.Hand

        tsNuevo.Enabled = True
        tsEditar.Enabled = True
        tsEliminar.Enabled = True
        tsGuardar.Enabled = False

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        dgvClientes.Enabled = True

        BuscarTextBox.Enabled = True

        Me.tbxCantCuotas.Enabled = False
    End Sub

    Private Sub dgvClientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvClientes.SelectionChanged
        If tbxCodCliente.Text <> "" Then
            btnFiltro_Click(Nothing, Nothing)
            'Para saber el Tipo de Venta (Contado/Credito)
            If dgvClientes.CurrentRow Is Nothing Then
            Else
                cbxRepVendedor.SelectedValue = dgvClientes.CurrentRow.Cells("CODVENDEDORDataGridViewTextBoxColumn").Value
                If IsDBNull(dgvClientes.CurrentRow.Cells("TIPOVENTADataGridViewTextBoxColumn").Value) Then
                    cbxTipoVenta.Text = ""
                Else
                    If dgvClientes.CurrentRow.Cells("TIPOVENTADataGridViewTextBoxColumn").Value = 0 Then
                        cbxTipoVenta.Text = "Contado"
                    Else
                        cbxTipoVenta.Text = "Crédito"
                    End If
                End If
                If IsDBNull(dgvClientes.CurrentRow.Cells("ACTIVO").Value) Then
                    PictureBoxActivo.Image = My.Resources.AbiertoOff
                    clienteActivo = 0
                    lblActivo.ForeColor = Color.Black
                    lblActivo.Text = "Inactivo"
                Else
                    If dgvClientes.CurrentRow.Cells("ACTIVO").Value = 0 Then
                        PictureBoxActivo.Image = My.Resources.AbiertoOff
                        clienteActivo = 0
                        lblActivo.ForeColor = Color.Black
                        lblActivo.Text = "Inactivo"
                    Else
                        PictureBoxActivo.Image = My.Resources.AbiertoActive
                        clienteActivo = 1
                        lblActivo.ForeColor = Color.OrangeRed
                        lblActivo.Text = "Activo"
                    End If
                End If
            End If

        End If

        If txtIdClienteR.Text <> "" Then
            txtNombreClienteR.Text = f.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", CDec(txtIdClienteR.Text))
        End If

        Dim consulta As String
        consulta = f.FuncionConsulta("DESTIPOCLIENTE", "TIPOCLIENTE", "CODTIPOCLIENTE", cbxListaPrecio.SelectedValue)
        cbxListaPrecio.Text = consulta

        Dim consultacat As String
        consultacat = f.FuncionConsulta("DESCATEGORIA", "CATEGORIACLIENTE", "CODCATEGORIA", cbxCategoria.SelectedValue)
        cbxCategoria.Text = consultacat

        Dim consultavend As String
        consultavend = f.FuncionConsulta("DESVENDEDOR", "VENDEDOR", "CODVENDEDOR", cbxRepVendedor.SelectedValue)
        cbxRepVendedor.Text = consultavend
    End Sub

    Private Sub BuscarTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.GotFocus
        lblClienteEstado.Text = "Buscandor de Clientes"
        BuscarTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.LostFocus
        lblClienteEstado.Text = ""
        BuscarTextBox.BackColor = Color.Tan
    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged

        If BuscarTextBox.Text = "" Then
            Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR NUMCLIENTE1 LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarTextBox.Text & "%' OR CABECERA LIKE '%" & BuscarTextBox.Text & "%'"
        Else
            If Config1 = "Nombre de Cliente" Then
                Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarTextBox.Text & "%' OR CABECERA LIKE '%" & BuscarTextBox.Text & "%'"
            ElseIf Config1 = "Nro. de Cliente" Then
                If Not System.Text.RegularExpressions.Regex.IsMatch(BuscarTextBox.Text, "^\d*$") Then ' Si introduce letras
                    Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarTextBox.Text & "%' OR CABECERA LIKE '%" & BuscarTextBox.Text & "%'"
                Else
                    Me.CLIENTESBindingSource.Filter = "NUMCLIENTE1 =" & BuscarTextBox.Text
                    If dgvClientes.RowCount = 0 Then
                        Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarTextBox.Text & "%' OR CABECERA LIKE '%" & BuscarTextBox.Text & "%'"
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub CalculaSaldoCtaCliente()
        Dim codcompr As String
        Dim saldo As Decimal
        Dim c As Integer = GridViewCuentaCliente.RowCount

        saldo = 0

        codcompr = "0"
        For c = 1 To c
            If (GridViewCuentaCliente.Rows(c - 1).Cells("CODCOMP").Value) <> codcompr Then
                If IsDBNull(GridViewCuentaCliente.Rows(c - 1).Cells("SALDO").Value) Then
                    saldo = saldo + 0
                Else
                    saldo = saldo + CDec(GridViewCuentaCliente.Rows(c - 1).Cells("SALDO").Value)
                End If
                codcompr = (GridViewCuentaCliente.Rows(c - 1).Cells("CODCOMP").Value)
            End If
        Next
        LblSaldo.Text = FormatNumber(saldo, 0)
        ' LblSaldo.Text = saldo.ToString
    End Sub

    Private Sub txtCliente_GotFocus(sender As Object, e As System.EventArgs) Handles txtCliente.GotFocus
        txtCliente.BackColor = SystemColors.Highlight
    End Sub
    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxFantasia.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroCliente_GotFocus(sender As Object, e As System.EventArgs) Handles txtNroCliente.GotFocus
        txtNroCliente.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxFantasia_GotFocus(sender As Object, e As System.EventArgs) Handles tbxFantasia.GotFocus
        tbxFantasia.BackColor = SystemColors.Highlight
    End Sub

    Private Sub txtNroCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)


        If InStr(1, "0123456789" & Chr(15), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If


        If KeyAscii = 13 Then
            cbxTipoRelacion.Focus()

        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxRUC_GotFocus(sender As Object, e As System.EventArgs) Handles tbxRUC.GotFocus
        If Config5 = "Automatico" Then
            tbxRUC.BackColor = SystemColors.Highlight
            LblInfoDV.Visible = False
        Else
            tbxRUC.BackColor = SystemColors.Highlight
            LblInfoDV.Visible = True
        End If
        lblMensajeError.Visible = False
    End Sub

    Private Sub tbxRUC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxRUC.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Config5 = "Automatico" Then
                Dim str As String
                Dim cadena As String

                If tbxRUC.Text <> "" Then

                    str = tbxRUC.Text
                    cadena = str.Substring(str.Length - 2, 1)
                    If cadena <> "-" Then
                        Dim DV As Integer
                        DV = getDV(tbxRUC.Text)
                        tbxRUC.Text = tbxRUC.Text & "-" & DV
                    End If
                End If

            End If
            tbxContacto.Focus()
        ElseIf KeyAscii = 42 Then
            Dim str As String
            Dim cadena As String

            str = tbxRUC.Text
            cadena = str.Substring(str.Length - 2, 1)

            If cadena <> "-" Then
                Dim DV As Integer
                DV = getDV(tbxRUC.Text)
                tbxRUC.Text = tbxRUC.Text & "-" & DV
            End If
            KeyAscii = 0
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxEmail_GotFocus(sender As Object, e As System.EventArgs) Handles tbxEmail.GotFocus
        tbxEmail.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxContacto_GotFocus(sender As Object, e As System.EventArgs) Handles tbxContacto.GotFocus
        tbxContacto.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxEmail.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxTel.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbxContacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxContacto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxEmail.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxTel_GotFocus(sender As Object, e As System.EventArgs) Handles tbxTel.GotFocus
        tbxTel.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxTel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxTel.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If InStr(1, "0123456789-" & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

        If KeyAscii = 13 Then
            tbxCellular.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCellular_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCellular.GotFocus
        tbxCellular.BackColor = SystemColors.Highlight
    End Sub


    Private Sub tbxCellular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCellular.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If InStr(1, "0123456789-" & Chr(15), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

        If KeyAscii = 13 Then
            txtDireccion.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDireccion_GotFocus(sender As Object, e As System.EventArgs) Handles txtDireccion.GotFocus
        txtDireccion.BackColor = SystemColors.Highlight
    End Sub

    Private Sub txtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxCiudad.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxCiudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxCiudad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxZona.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxZona_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxZona.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxListaPrecio.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxListaPrecio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxListaPrecio.GotFocus
        cbxListaPrecio.BackColor = SystemColors.Highlight
    End Sub

    Private Sub cbxListaPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxListaPrecio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxRepVendedor.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxRepVendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxRepVendedor.GotFocus
        'Me.VENDEDORTableAdapter.Fill(Me.DsCliente.VENDEDOR)
        cbxRepVendedor.BackColor = SystemColors.Highlight
    End Sub

    Private Sub cbxRepVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxRepVendedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cbxCategoria.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxCategoria_GotFocus(sender As Object, e As System.EventArgs) Handles cbxCategoria.GotFocus
        cbxCategoria.BackColor = SystemColors.Highlight
    End Sub

    Private Sub cbxCategoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxCategoria.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxCustomField.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtGMaps_GotFocus(sender As Object, e As System.EventArgs) Handles txtGMaps.GotFocus
        txtGMaps.BackColor = SystemColors.Highlight
    End Sub

    Private Sub txtGMaps_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGMaps.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxCustomField.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        lblMensajeError.Visible = False
        btnuevo = 1
        permiso = PermisoAplicado(UsuCodigo, 8)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Crear un Cliente", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            tsmImprimir.Enabled = False
            lblClienteEstado.Text = "Cargue un Nuevo Cliente"
            'Dim conexion As System.Data.SqlClient.SqlConnection
            'Dim myTrans As System.Data.SqlClient.SqlTransaction

            IsNew = 1
            IsEdit = 0

            pnlDatosCliente.BringToFront()
            Habilita()
            actualizargrillaclientes()
            CLIENTESBindingSource.AddNew()

            clienteActivo = 1
            PictureBoxActivo.Image = My.Resources.AbiertoActive
            lblActivo.ForeColor = Color.OrangeRed
            lblActivo.Text = "Activo"

            'conexion = ser.Abrir()
            'Try
            '    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            '    InsertarClienteNuevo(myTrans)
            '    myTrans.Commit()
            'Catch ex As Exception
            '    Try
            '        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            '        myTrans.Rollback("Insertar")
            '    Catch
            '    End Try
            '    Throw
            'End Try

            NuevoPictureBox.Image = My.Resources.NewActive
            If cbxTipoRelacion.Text = "" Then
                cbxTipoRelacion.SelectedIndex = cbxTipoRelacion.SelectedIndex + 1
            End If
            txtIdClienteR.Text = "" : txtNombreClienteR.Text = ""
            txtCliente.Focus()

        End If
    End Sub

    Private Sub InsertarClienteNuevo(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim consulta As System.String
        Dim UltimoCliente As Integer

        'se debe obtener el ultimo nro insertado
        UltimoCliente = f.Maximo("CODCLIENTE", "CLIENTES")
        CodClienteGlobal = UltimoCliente + 1
        tbxCodCliente.Text = CodClienteGlobal

        consulta = "INSERT INTO CLIENTES (CODCLIENTE) VALUES (" & CodClienteGlobal & ")"

        Consultas.ConsultaComando(myTrans, consulta)
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        '**************************************************************************************************************************************************
        btnuevo = 0 : btmodificar = 0
        tbxRUC.BackColor = SystemColors.ControlLightLight
        Me.lblMensajeError.Visible = False

        Dim ClienteIsNull As String

        ClienteIsNull = f.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", CodClienteGlobal)

        If ClienteIsNull = "" Or ClienteIsNull = Nothing Then
            Dim consulta As System.String
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            conexion = ser.Abrir()

            Try
                consulta = ""
                consulta = consulta + "DELETE FROM CLIENTES WHERE CODCLIENTE=" & CodClienteGlobal & " "

                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()
            Catch ex As SqlException

            End Try

        End If

        '**************************************************************************************************************************************************

        Try
            Dim Codclientetemp As String = dgvClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value

            ZONATableAdapter.Fill(DsCliente.ZONA)
            CLIENTESBindingSource.CancelEdit()
            CLIENTESBindingSource.RemoveFilter()
            DesHabilita()
            lblClienteEstado.Text = "Carga fue Cancelada"
            lblNombre.Visible = True
            txtCliente.Visible = False
            actualizargrillaclientes()

            'Buscamos la posicion del registro guardado
            For I = 0 To dgvClientes.RowCount - 1
                If dgvClientes.Rows(I).Cells("CODCLIENTEDataGridViewTextBoxColumn").Value = Codclientetemp Then
                    CLIENTESBindingSource.Position = I
                    Exit For
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NuevoPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NuevoPictureBox.MouseDown
        If NuevoPictureBox.Enabled = True Then
            NuevoPictureBox.Image = My.Resources.NewMouseDown
        End If
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.NuevoPictureBox, "Nuevo Cliente")
    End Sub

    Private Sub EliminarPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles EliminarPictureBox.MouseDown
        If EliminarPictureBox.Enabled = True Then
            EliminarPictureBox.Image = My.Resources.DeleteMouseDown
        End If
    End Sub

    Private Sub EliminarPictureBox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.EliminarPictureBox, "Eliminar Cliente")
    End Sub

    Private Sub ModificarPictureBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ModificarPictureBox.MouseDown
        If ModificarPictureBox.Enabled = True Then
            ModificarPictureBox.Image = My.Resources.EditMouseDown
        End If
    End Sub

    Private Sub ModificarPictureBox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.ModificarPictureBox, "Editar Ficha Cliente")
    End Sub

    Private Sub GuardarPictureBox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.GuardarPictureBox, "Guardar Ficha Cliente")
    End Sub

    Private Sub CancelarPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.GuardarPictureBox, "Cancelar Datos Modificados")
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        btmodificar = 1
        permiso = PermisoAplicado(UsuCodigo, 10)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Modificar este Cliente", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        Else
            'ZONATableAdapter.Fill(DsCliente.ZONA)
            lblClienteEstado.Text = "Planilla lista para Editar"
            If (txtIdClienteR.Text = "") Or (txtIdClienteR.Text = "0") Then
                txtNombreClienteR.Text = ""
            End If

            IsNew = 0
            IsEdit = 1

            Habilita()
            txtCliente.Focus()
            ModificarPictureBox.Image = My.Resources.EditActive
        End If
    End Sub

    Private Sub cbxCiudad_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxCiudad.SelectedValueChanged
        If IsNew = 1 Or IsEdit = 1 Then
            If Me.cbxCiudad.SelectedValue <> Nothing Then
                Me.ZONATableAdapter.FillBy(Me.DsCliente.ZONA, Me.cbxCiudad.SelectedValue)
            End If
        End If
    End Sub

    Private Sub Guardar()
        Dim Relacion As Integer
        Dim CodTipoCliente, CodCategCliente, LimCredito, DiasVenc, TipoVenta, CodVendedor, CodCiudad, CodZona, CodDepartamento, NroCliente, NomFantasia, Contacto, GMaps, Rlegal, CodPostal, Correo1Contacto, Correo2Contacto, ContactoTelefono, ContactoCelular As String
        Dim CantCuotas As Integer
        Dim transaction As SqlTransaction = Nothing

        'Controles
        If txtCliente.Text = "" Then
            MessageBox.Show("Indique un Nombre del Cliente", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCliente.Focus()
            txtCliente.BackColor = Color.Pink
            Exit Sub
        End If

        If cbxTipoRelacion.Text <> "" Then
            If cbxTipoRelacion.Text = "Contacto Principal" Then
                'Apartir de aca debemos verificar que tipo de restriccion tiene y hacer los controles necesarios =.)
                If Config3 = "Medio" Or Config3 = "Alto" Then 'Verificamos RUC
                    If tbxRUC.Text = " " Or tbxRUC.Text = "" Then
                        MessageBox.Show("Indique el Ruc/C.I del Cliente", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        tbxRUC.Focus()
                        tbxRUC.BackColor = Color.Pink
                        Exit Sub
                    End If
                End If
            Else
                If txtIdClienteR.Text = "" Then
                    MessageBox.Show("Indique el Nro de Cliente al Cual esta Relacionado", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtIdClienteR.Focus()
                    txtIdClienteR.BackColor = Color.Pink
                    Exit Sub
                End If
            End If
        Else
            MessageBox.Show("Indique el Tipo de Relacionado", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxTipoRelacion.Focus()
            cbxTipoRelacion.BackColor = Color.Pink
            Exit Sub
        End If

        If Config3 = "Alto" Then 'Verificamos Direccion y Telefono
            If txtDireccion.Text = "" Then
                MessageBox.Show("Indique la Direccion del Cliente", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDireccion.Focus()
                txtDireccion.BackColor = Color.Pink
                Exit Sub
            End If

            If tbxTel.Text = "" And tbxCellular.Text = "" Then
                MessageBox.Show("Indique El telefono o el Celular del Cliente", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If tbxTel.Text = "" Then
                    tbxTel.Focus()
                    tbxTel.BackColor = Color.Pink
                Else
                    tbxCellular.Focus()
                    tbxCellular.BackColor = Color.Pink
                End If
                Exit Sub
            End If
        End If

        pbarClientes.Value += 25
        lblNombre.Text = ""
        'Cargamos los valores por defecto
        If txtNroCliente.Text = "" Then
            GenerarNroCliente()
            NroCliente = txtNroCliente.Text
        Else
            NroCliente = txtNroCliente.Text
        End If

        If Trim(tbxFantasia.Text) = "" Then
            NomFantasia = txtCliente.Text 'Le igualamos al Nombre del cliente
        Else
            NomFantasia = tbxFantasia.Text
        End If

        If tbxContacto.Text = "" Then
            Contacto = " "
        Else
            Contacto = tbxContacto.Text
        End If

        If cbxListaPrecio.SelectedValue = Nothing Or cbxListaPrecio.Text = "" Then
            CodTipoCliente = "NULL"
        Else
            CodTipoCliente = cbxListaPrecio.SelectedValue
        End If

        If cbxCategoria.SelectedValue = Nothing Then
            Dim CodCategGenerica As Integer = f.FuncionConsulta("CODCATEGORIACLIENTE", "CATEGORIACLIENTE", "DESCATEGORIACLIENTE", "Categoría Genérica")
            If CodCategGenerica <> 0 Then
                CodCategCliente = CodCategGenerica
            Else
                CodCategCliente = "NULL"
            End If
        Else
            CodCategCliente = cbxCategoria.SelectedValue
        End If

        If tbxLimiteCredito.Text = "" Then
            LimCredito = "NULL"
        Else
            LimCredito = tbxLimiteCredito.Text
            LimCredito = Funciones.Cadenas.QuitarCad(LimCredito, ".")
            LimCredito = Replace(LimCredito, ",", ".")
        End If

        If cbxCiudad.SelectedValue = Nothing Or cbxCiudad.Text = "" Then
            CodCiudad = "NULL"
            CodDepartamento = "NULL"
        Else
            CodCiudad = cbxCiudad.SelectedValue
            CodDepartamento = f.FuncionConsulta("CODPAIS", "CIUDAD", "CODCIUDAD", CodCiudad)
        End If

        If cbxZona.SelectedValue = Nothing Or cbxZona.Text = "" Then
            CodZona = "NULL"
        Else
            CodZona = cbxZona.SelectedValue
        End If

        If cbxRepVendedor.SelectedValue = Nothing Or cbxRepVendedor.Text = "" Then
            CodVendedor = "NULL"
        Else
            CodVendedor = cbxRepVendedor.SelectedValue
        End If

        If tbxCantCuotas.Text = "" Then
            CantCuotas = "1"
        Else
            CantCuotas = tbxCantCuotas.Text
        End If

        If tbxVencimiento.Text = "" Then
            DiasVenc = "1"
        Else
            DiasVenc = tbxVencimiento.Text
        End If

        If cbxTipoVenta.Text = "" Then
            TipoVenta = 0
        Else
            If cbxTipoVenta.Text = "Contado" Then
                TipoVenta = 0
            Else
                TipoVenta = 1
            End If
        End If

        If cbxTipoRelacion.SelectedValue <> Nothing Then
            Relacion = cbxTipoRelacion.SelectedValue
        Else
            Relacion = CDec(txtIdClienteR.Text)
        End If

        If txtGMaps.Text = Nothing Or txtGMaps.Text = "" Then
            GMaps = ""
        ElseIf txtGMaps.Text Like "*tinyurl*" Then
            GMaps = txtGMaps.Text
        Else
            txtGMaps.Text = getHTML("http://tinyurl.com/api-create.php?url-" + txtGMaps.Text)
            GMaps = txtGMaps.Text
        End If

        If tbxRepresentanteLegal.Text = "" Then
            Rlegal = ""
        Else
            Rlegal = tbxRepresentanteLegal.Text
        End If

        If tbxCodPostal.Text = "" Then
            CodPostal = 0
        Else
            CodPostal = tbxCodPostal.Text
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
            ContactoTelefono = 0
        Else
            ContactoTelefono = tbxTelContacto.Text
        End If

        If tbxCelContacto.Text = "" Then
            ContactoCelular = 0
        Else
            ContactoCelular = tbxCelContacto.Text
        End If

        'Guardamos en la base de datos
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        pbarClientes.Value += 50

        Dim cliente As Integer
        cliente = tbxCodCliente.Text
        sql = ""

        If IsNew = 1 Then
            'VALIDAMOS QUE SE HAYA CARGADO ALGUN LINK   --   ESTO LO HACEMOS ANTES DE INSERTAR YA QUE AL QUERER ACTUALIZAR SE REEMPLAZA EL LINK POR UNO NUEVO QUE SE GENERA.
            If txtGMaps.Text = Nothing Or txtGMaps.Text = "" Then
                GMaps = ""
            Else
                txtGMaps.Text = getHTML("http://tinyurl.com/api-create.php?url-" + txtGMaps.Text)
                GMaps = txtGMaps.Text
            End If
            sql = "INSERT CLIENTES (NOMBRE,RUC,NUMCLIENTE,CODCIUDAD,DIRECCION,TELEFONO,CELULAR,DIASVENCIMIENTO,EMAIL,CODZONA,CODVENDEDOR,CODTIPOCLIENTE,TIPOVENTA," & _
                  "CODCATEGORIACLIENTE,LIMCREDITO,CODDEPARTAMENTO,CUSTOMFIELD,TIPORELACION,OBSERVACION,NOMBREFANTASIA,NOMBRECONTACTO,AUTORIZADO,CODUSUARIO,CANTCUOTAS, RELACION, LINKMAPS,  " & _
                  "REPRESENTANTELEGAL, CODPOSTAL, CONTACTOCORREO1, CONTACTOCORREO2, CONTACTOTELEFONO, CONTACTOCELULAR )" & _
                      "VALUES('" & txtCliente.Text & "','" & tbxRUC.Text & "','" & NroCliente & "', " & CodCiudad & ", '" & Replace(txtDireccion.Text, "'", "''") & "', " & _
                      "'" & tbxTel.Text & "','" & tbxCellular.Text & "'," & DiasVenc & "," & "'" & tbxEmail.Text & "'," & CodZona & "," & CodVendedor & ", " & _
                      CodTipoCliente & "," & TipoVenta & "," & CodCategCliente & ", " & LimCredito & "," & CodDepartamento & ",'" & tbxCustomField.Text & "' ," & _
                      cbxTipoRelacion.SelectedValue & " , '" & txtObservacion.Text & "' ,'" & NomFantasia & "', '" & Contacto & "'," & clienteActivo & "," & UsuCodigo & "," & CantCuotas & "," & Relacion & ",'" & GMaps & "'," & _
                    "'" & Rlegal & "', '" & CodPostal & "', '" & Correo1Contacto & "', '" & Correo2Contacto & "', '" & ContactoTelefono & "', '" & ContactoCelular & "')"

            If cbxTipoRelacion.SelectedValue = 1 Then
                sql = sql + "    UPDATE CLIENTES SET RELACION = CODCLIENTE  WHERE CODCLIENTE = SCOPE_IDENTITY()"
            End If

        ElseIf IsEdit = 1 Then
            sql = "UPDATE CLIENTES SET " & _
            "NOMBRE = '" & txtCliente.Text & "', RUC = '" & tbxRUC.Text & "', NUMCLIENTE = '" & NroCliente & "',  " & _
            "CODCIUDAD = " & CodCiudad & ",DIRECCION = '" & Replace(txtDireccion.Text, "'", "''") & "', " & _
            "TELEFONO= '" & tbxTel.Text & "', CELULAR='" & tbxCellular.Text & "',DIASVENCIMIENTO=" & DiasVenc & ", " & _
            "EMAIL= '" & tbxEmail.Text & "', CODZONA=" & CodZona & ", CODVENDEDOR=" & CodVendedor & ", " & _
            "CODTIPOCLIENTE = " & CodTipoCliente & ", TIPOVENTA = " & TipoVenta & ", CODCATEGORIACLIENTE = " & CodCategCliente & "," & _
            "LIMCREDITO = " & LimCredito & ", CODDEPARTAMENTO = " & CodDepartamento & ", CUSTOMFIELD =  '" & tbxCustomField.Text & "' ," & _
            "TIPORELACION = " & Relacion & ", RELACION = " & cliente & " , OBSERVACION = '" & txtObservacion.Text & "' , " & _
            "NOMBREFANTASIA = '" & NomFantasia & "', NOMBRECONTACTO = '" & Contacto & "', AUTORIZADO =" & clienteActivo & ", CODUSUARIO =  " & UsuCodigo & " , " & _
            "CANTCUOTAS = " & CantCuotas & ", LINKMAPS =  '" & GMaps & "', REPRESENTANTELEGAL = '" & Rlegal & "' , " & _
            "CODPOSTAL = '" & CodPostal & "', CONTACTOCORREO1 = '" & Correo1Contacto & "', CONTACTOCORREO2 = '" & Correo2Contacto & "' , " & _
            "CONTACTOTELEFONO = '" & ContactoTelefono & "', CONTACTOCELULAR = '" & ContactoCelular & "' WHERE CODCLIENTE = " & CDec(tbxCodCliente.Text)
        End If

        Try
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()

            cliente = tbxCodCliente.Text
            IsNew = 0 : IsEdit = 0

            ZONATableAdapter.Fill(DsCliente.ZONA)
            actualizargrillaclientes()

            'Buscamos la posicion del registro guardado
            For I = 0 To dgvClientes.RowCount - 1
                If dgvClientes.Rows(I).Cells("CODCLIENTEDataGridViewTextBoxColumn").Value = cliente Then
                    CLIENTESBindingSource.Position = I
                    Exit For
                End If
            Next

            lblClienteEstado.Text = "Grabado!"
            DesHabilita()
            lblNombre.Visible = True
            txtCliente.Visible = False
            pbarClientes.Value = 100

        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch
            End Try
            MessageBox.Show("Error al Guardar Cliente: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblClienteEstado.Text = "Error al Guardar"
            Me.CancelarPictureBox.PerformLayout()
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        pbarClientes.Value = 0

        Me.Cursor = Cursors.AppStarting
        Guardar()
        Me.Cursor = Cursors.Arrow

        dgvClientes.Focus()
        btnuevo = 0 : btmodificar = 0

        tbxRUC.BackColor = SystemColors.ControlLightLight
        Me.lblMensajeError.Visible = False
        tsmImprimir.Enabled = True
    End Sub

    Private Sub EliminaCliente()
        sql = ""
        sql = " DELETE FROM CLIENTES " & _
              " WHERE CODCLIENTE= " & CDec(tbxCodCliente.Text)
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 9)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Eliminar este Cliente", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else

            If MessageBox.Show("¿Esta seguro que quiere eliminar el Cliente?", "Pos Express", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If
            If tbxCodCliente.Text = "" Then
                MessageBox.Show("Seleccione un Cliente o presione Nuevo para Agregar", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblClienteEstado.Text = "Elija un Cliente antes de eliminarlo!"
                DesHabilita()
                Exit Sub
            End If
            Me.Cursor = Cursors.AppStarting
            Dim transaction As SqlTransaction = Nothing
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try

                EliminaCliente()

                myTrans.Commit()
                actualizargrillaclientes()
                DesHabilita()
                lblClienteEstado.Text = "Cliente Eliminado"

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
            End Try
        End If
        tbxRUC.BackColor = SystemColors.ControlLightLight
        Me.lblMensajeError.Visible = False
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pbxAgregarCiudad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ABMPaisV2.ShowDialog()
        Me.PAISTableAdapter.Fill(Me.DsCliente.PAIS)
        Me.CIUDADTableAdapter.Fill(Me.DsCliente.CIUDAD)
        Me.ZONATableAdapter.Fill(Me.DsCliente.ZONA)
    End Sub

    Private Sub pbxAgregarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarListaPrecio.Click
        ABMTipoCliente.ShowDialog()
        Me.TIPOCLIENTETableAdapter.Fill(DsCliente.TIPOCLIENTE)
    End Sub

    Private Sub pbxAgregarVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarVendedor.Click
        ABMVendedorV2.ShowDialog()
        Me.VENDEDORTableAdapter.Fill(DsCliente.VENDEDOR)
    End Sub

    Private Sub tbxFantasia_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxFantasia.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtNroCliente.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtNroCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroCliente.LostFocus
        'Verificamos que el nro de cliente no se repita.' GenerarNroCliente()

        Dim Existe, CodCliente As Integer
        Dim Maximo As Integer

        If txtNroCliente.Text = "" Then
            Maximo = f.Maximo("NUMCLIENTE", "CLIENTES")
            Maximo = Maximo + 1

            txtNroCliente.Text = Maximo

        ElseIf txtNroCliente.Text <> "" Then
            Existe = f.FuncionConsultaString("NUMCLIENTE", "CLIENTES", "NUMCLIENTE", txtNroCliente.Text)
            CodCliente = f.FuncionConsultaString("CODCLIENTE", "CLIENTES", "NUMCLIENTE", txtNroCliente.Text)

            If (Existe = txtNroCliente.Text) And (CodCliente <> dgvClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value) Then
                MessageBox.Show("El Nro de Cliente ya existe en la Base de Datos. Elija otro Nro para evitar Errores!", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroCliente.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        txtNroCliente.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxFantasia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxFantasia.LostFocus
        tbxFantasia.BackColor = SystemColors.ControlLightLight
    End Sub
#End Region

    Private Sub tbxRUC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxRUC.LostFocus
        lblMensajeError.Visible = False
        LblInfoDV.Visible = False
        If tbxRUC.Text <> "" Then
            If btnuevo = 1 Or btmodificar = 1 Then
                Dim existeruc As String
                existeruc = f.FuncionConsultaString("NOMBRE", "CLIENTES", "RUC", Me.tbxRUC.Text)
                If existeruc = Nothing Or existeruc = "" Then
                    'No existe el ruc
                    tbxRUC.BackColor = SystemColors.ControlLightLight
                    GoTo fin
                Else
                    If btmodificar = 1 And Trim(existeruc) = Trim(lblNombre.Text) Then
                        'Esta Modificando el Cliente dueño del Ruc, entonces no hacer nada
                        'En el caso de los mismos nombres..estos tienen el mismo RUC, entonces esta bien permitirle
                        tbxRUC.BackColor = SystemColors.ControlLightLight
                        GoTo fin
                    End If
                    lblMensajeError.Visible = True
                    tbxRUC.BackColor = Color.Pink
                End If
            End If
        End If
fin:
        'tbxRUC.BackColor =  SystemColors.controllightlight
    End Sub

    Private Sub GenerarNroCliente()
        Dim Existe, CodCliente As Integer
        Dim Aleatorio As Integer
        Dim Minimo As Integer = "1"
        Dim Maximo As Integer = "99999999"

        If txtNroCliente.Text = "" Then
            Aleatorio = "00000001"
            Randomize()
            Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)
            Existe = f.FuncionConsultaString("NUMCLIENTE", "CLIENTES", "NUMCLIENTE", Aleatorio)

            While Existe <> 0
                Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)
                Existe = f.FuncionConsultaString("NUMCLIENTE", "CLIENTES", "NUMCLIENTE", Aleatorio)

            End While

            txtNroCliente.Text = Aleatorio
        ElseIf txtNroCliente.Text <> "" Then
            Existe = f.FuncionConsultaString("NUMCLIENTE", "CLIENTES", "NUMCLIENTE", txtNroCliente.Text)
            CodCliente = f.FuncionConsultaString("CODCLIENTE", "CLIENTES", "NUMCLIENTE", txtNroCliente.Text)

            If (Existe = txtNroCliente.Text) And (CodCliente <> dgvClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value) Then
                MessageBox.Show("El Nro de Cliente ya existe en la Base de Datos. Elija otro Nro para evitar Errores!", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroCliente.Focus()
                txtNroCliente.BackColor = Color.Pink
                Exit Sub
            End If
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

    Private Sub txtCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCliente.LostFocus
        txtCliente.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxEmail_LostFocus(sender As Object, e As System.EventArgs) Handles tbxEmail.LostFocus
        tbxEmail.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub tbxContacto_LostFocus(sender As Object, e As System.EventArgs) Handles tbxContacto.LostFocus
        tbxContacto.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxTel_LostFocus(sender As Object, e As System.EventArgs) Handles tbxTel.LostFocus
        tbxTel.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxCellular_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCellular.LostFocus
        tbxCellular.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub txtDireccion_LostFocus(sender As Object, e As System.EventArgs) Handles txtDireccion.LostFocus
        txtDireccion.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub txtGMaps_LostFocus(sender As Object, e As System.EventArgs) Handles txtGMaps.LostFocus
        txtGMaps.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxCustomField_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCustomField.GotFocus
        tbxCustomField.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxCustomField_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCustomField.LostFocus
        tbxCustomField.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub cbxListaPrecio_LostFocus(sender As Object, e As System.EventArgs) Handles cbxListaPrecio.LostFocus
        cbxListaPrecio.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub cbxRepVendedor_LostFocus(sender As Object, e As System.EventArgs) Handles cbxRepVendedor.LostFocus
        cbxRepVendedor.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub cbxCategoria_LostFocus(sender As Object, e As System.EventArgs) Handles cbxCategoria.LostFocus
        cbxCategoria.BackColor = SystemColors.ControlLightLight
    End Sub
    Private Sub cbxTipoVenta_GotFocus(sender As Object, e As System.EventArgs)
        cbxTipoVenta.BackColor = SystemColors.Highlight
    End Sub

    Private Sub cbxTipoVenta_LostFocus(sender As Object, e As System.EventArgs)
        cbxTipoVenta.BackColor = SystemColors.ControlLightLight
    End Sub


    Private Sub pbxDatosCliente_Click(sender As System.Object, e As System.EventArgs) Handles pbxDatosCliente.Click
        'pnlObservacion.Visible = False
        pbxClienteFinanzas.Image = My.Resources.Financial
        pbxClienteFinanzas.Cursor = Cursors.Hand
        pbxDatosCliente.Image = My.Resources.UserActive
        pbxDatosCliente.Cursor = Cursors.Arrow
        pbxAgregarCiudad.Visible = True
        pbxAgregarListaPrecio.Visible = True
        pbxAgregarVendedor.Visible = True
        pbxAgregarCategoria.Visible = True
        pnlDatosCliente.BringToFront()

    End Sub

    Private Sub pbxClienteFinanzas_Click(sender As System.Object, e As System.EventArgs) Handles pbxClienteFinanzas.Click
        permiso = PermisoAplicado(UsuCodigo, 35)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Acceder estos Datos", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            If IsNew = 0 Then 'quiere decir q no fue Nuevo
                CalculaSaldoCtaCliente()
            Else
                LblSaldo.Text = "0"
            End If

            pbxDatosCliente.Cursor = Cursors.Hand
            pbxDatosCliente.Image = My.Resources.User
            pbxClienteFinanzas.Cursor = Cursors.Arrow
            pbxClienteFinanzas.Image = My.Resources.FinancialActive

            pbxAgregarCiudad.Visible = False
            pbxAgregarListaPrecio.Visible = False
            pbxAgregarVendedor.Visible = False
            pbxAgregarCategoria.Visible = False
            pnlFinanzas.BringToFront()
            pnlFinanzas2.BringToFront()
            tbxCantCuotas.Focus()
            'cbxTipoVenta.Text = "Contado"
        End If
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Dim pag As String
        pag = "http://cogentpotential.com/soporte/ventas/clientes"
        Shell("Explorer " & pag)
    End Sub

    Private Sub pbxAgregarCategoria_Click(sender As System.Object, e As System.EventArgs) Handles pbxAgregarCategoria.Click
        ABMCategoriaCliente.ShowDialog()
        Me.CATEGORIACLIENTETableAdapter.Fill(Me.DsCliente.CATEGORIACLIENTE)
    End Sub

    Private Sub cbxTipoRelacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoRelacion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            If (cbxTipoRelacion.SelectedValue = 1) Or (cbxTipoRelacion.SelectedValue = Nothing) Then
                tbxRUC.Focus()
            Else
                txtIdClienteR.Focus()
            End If
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxTipoRelacion_LostFocus(sender As Object, e As System.EventArgs) Handles cbxTipoRelacion.LostFocus
        If cbxTipoRelacion.Text = "" Then
            cbxTipoRelacion.SelectedIndex = cbxTipoRelacion.SelectedIndex + 1
        End If
    End Sub

    Private Sub cbxTipoRelacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxTipoRelacion.SelectedIndexChanged
        If (cbxTipoRelacion.SelectedValue = 1) Or (cbxTipoRelacion.SelectedValue = Nothing) Then
            lblRelacionado.Visible = False
            tbxRUC.Enabled = True
            lblRuc.BringToFront()
            tbxRUC.BringToFront()
            pbxClienteFinanzas.Enabled = True

        ElseIf cbxTipoRelacion.SelectedValue = 2 Then
            lblRelacionado.Visible = True
            lblRelacionado.BringToFront()
            tbxRUC.Enabled = False
            txtIdClienteR.BringToFront()
            txtNombreClienteR.BringToFront()
            pbxClienteFinanzas.Enabled = True

        Else
            lblRelacionado.Visible = True
            lblRelacionado.BringToFront()
            tbxRUC.Enabled = False
            txtIdClienteR.BringToFront()
            txtNombreClienteR.BringToFront()
            pbxClienteFinanzas.Enabled = False
        End If
    End Sub

    Private Sub txtIdClienteR_GotFocus(sender As Object, e As System.EventArgs) Handles txtIdClienteR.GotFocus
        txtIdClienteR.BackColor = SystemColors.Highlight
    End Sub

    Private Sub txtIdClienteR_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdClienteR.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxEmail.Focus()
        End If

        If KeyAscii = 42 Then
            CLIENTESFILTROTableAdapter.Fill(DsCliente.CLIENTESFILTRO, "%", "%", "%")
            UltraPopupControlContainer1.Show()
            TxtBuscaCliente.Text = ""
            TxtBuscaCliente.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub dgwClientesFiltro_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwClientesFiltro.DoubleClick
        If dgwClientesFiltro.RowCount <> 0 Then

            If IsDBNull(dgwClientesFiltro.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn2").Value) Then
            Else
                txtIdClienteR.Text = dgwClientesFiltro.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn2").Value
            End If

            If IsDBNull(dgwClientesFiltro.CurrentRow.Cells("CLIENTEDataGridViewTextBoxColumn1").Value) Then
            Else
                txtNombreClienteR.Text = dgwClientesFiltro.CurrentRow.Cells("CLIENTEDataGridViewTextBoxColumn1").Value
            End If

            Me.tbxRUC.Text = dgwClientesFiltro.CurrentRow.Cells("RUCDataGridViewTextBoxColumn").Value

            UltraPopupControlContainer1.Close()
        End If
    End Sub

    Private Sub TxtBuscaCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscaCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            dgwClientesFiltro.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtBuscaCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscaCliente.TextChanged
        Me.CLIENTESFILTROBindingSource.Filter = "CLIENTE LIKE '%" & TxtBuscaCliente.Text & "%' OR NUMCLIENTE LIKE '%" & TxtBuscaCliente.Text & "%' OR RUC LIKE '%" & TxtBuscaCliente.Text & "%'"
    End Sub

    Private Sub txtIdClienteR_LostFocus(sender As Object, e As System.EventArgs) Handles txtIdClienteR.LostFocus
        txtIdClienteR.BackColor = SystemColors.ControlLightLight
        If txtIdClienteR.Text <> "" Then
            txtNombreClienteR.Text = f.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", txtIdClienteR.Text)
            tbxRUC.Text = f.FuncionConsultaString("RUC", "CLIENTES", "NUMCLIENTE", txtIdClienteR.Text)
        End If
    End Sub
    Private Sub dgwClientesFiltro_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgwClientesFiltro.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            Dim Index As Integer = dgwClientesFiltro.CurrentRow.Index
            Dim cantReg As Integer = dgwClientesFiltro.RowCount - 1

            If (Index <> 0) And (Index <> cantReg) Then
                Index = Index - 1
            End If

            If IsDBNull(dgwClientesFiltro.Rows(Index).Cells("CODCLIENTEDataGridViewTextBoxColumn2").Value) Then
            Else
                txtIdClienteR.Text = dgwClientesFiltro.Rows(Index).Cells("CODCLIENTEDataGridViewTextBoxColumn2").Value
            End If

            If IsDBNull(dgwClientesFiltro.Rows(Index).Cells("CLIENTEDataGridViewTextBoxColumn1").Value) Then
            Else
                txtNombreClienteR.Text = dgwClientesFiltro.Rows(Index).Cells("CLIENTEDataGridViewTextBoxColumn1").Value
            End If

            Me.tbxRUC.Text = dgwClientesFiltro.Rows(Index).Cells("RUCDataGridViewTextBoxColumn").Value

            UltraPopupControlContainer1.Close()
        End If
    End Sub
    Private Sub actualizargrillaclientes()

        If Config1 = "Nombre de Cliente" Then
            Me.CLIENTESTableAdapter.Fill(Me.DsCliente.CLIENTES)
        ElseIf Config1 = "Nro. de Cliente" Then
            Me.CLIENTESTableAdapter.OrderByNroCliente(Me.DsCliente.CLIENTES)
        End If

    End Sub
    Private Sub btnMostrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles pbxMostrarOBS.Click
        If pnlObservacion.Visible = False Then
            pnlObservacion.Visible = True
            pnlObservacion.BringToFront()
            pbxMostrarOBS.Image = My.Resources.DisplayActive
            If btmodificar = 1 Or btnuevo = 1 Then
                txtObservacion.Enabled = True
                txtObservacion.Focus()
            Else
                txtObservacion.Enabled = False
            End If
        Else
            pnlObservacion.Visible = False
            pbxMostrarOBS.Image = My.Resources.Display
        End If
    End Sub
    Private Sub btnCerrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarOBS.Click
        pbxMostrarOBS.Image = My.Resources.Display
        pnlObservacion.Visible = False
    End Sub
    Private Sub txtObservacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlObservacion.Visible = False
        End If
    End Sub
    Private Sub PictureBox8_DoubleClick(sender As Object, e As System.EventArgs) Handles PictureBox8.DoubleClick
        PictureBox8.BackColor = SystemColors.Highlight
        CLIENTESBindingSource.Filter = "CodCliente = NULL"
        Habilita()
    End Sub
    Private Sub pbxMostrarOBS_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbxMostrarOBS.MouseDown
        If pbxMostrarOBS.Enabled = True Then
            pbxMostrarOBS.Image = My.Resources.DisplayMouseDown
        End If
    End Sub
    Private Sub pbxDatosCliente_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbxDatosCliente.MouseDown
        If pbxDatosCliente.Enabled = True Then
            pbxDatosCliente.Image = My.Resources.UserMouseDown
        End If
    End Sub
    Private Sub pbxClienteFinanzas_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pbxClienteFinanzas.MouseDown
        If pbxClienteFinanzas.Enabled = True Then
            pbxClienteFinanzas.Image = My.Resources.FinancialMouseDown
        End If
    End Sub
    Private Sub PictureBoxActivo_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxActivo.Click
        permiso = PermisoAplicado(UsuCodigo, 227)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Activar/Desactivar un Cliente", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If clienteActivo = 0 Then
            clienteActivo = 1
            PictureBoxActivo.Image = My.Resources.AbiertoActive
            lblActivo.ForeColor = Color.OrangeRed
            lblActivo.Text = "Activo"
        ElseIf clienteActivo = 1 Then
            clienteActivo = 0
            PictureBoxActivo.Image = My.Resources.AbiertoOff
            lblActivo.ForeColor = Color.Black
            lblActivo.Text = "Inactivo"
        End If
    End Sub
    Private Sub tsNuevaVenta_Click(sender As System.Object, e As System.EventArgs) Handles tsNuevo.Click
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
    Private Sub tsPanelDeCreditos_Click(sender As System.Object, e As System.EventArgs) Handles tsPanelDeCreditos.Click
        pbxClienteFinanzas_Click(Nothing, Nothing)
    End Sub

    Private Sub tsCampoDeObservacion_Click(sender As System.Object, e As System.EventArgs) Handles tsCampoDeObservacion.Click
        btnMostrarOBS_Click(Nothing, Nothing)
    End Sub
    Private Sub tsPersonalizarVentas_Click(sender As System.Object, e As System.EventArgs) Handles tsPersonalizarVentas.Click
        ABMConfigPosExpress.Show()
        ABMConfigPosExpress.abrirdesde("Clientes")
    End Sub
    Private Sub btCerrarSepsa_Click(sender As System.Object, e As System.EventArgs) Handles btCerrarSepsa.Click
        pnlSEPSA.Visible = False
    End Sub
    Private Sub SEPSAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles tsmImprimir.Click
        If pnlSEPSA.Visible = False Then
            pnlSEPSA.BringToFront()
            pnlSEPSA.Visible = True
            Try
                txtCodigoSEPSA.Text = f.FuncionConsultaString("SEPSA", "CLIENTES", "CODCLIENTE", CDec(tbxCodCliente.Text))
            Catch ex As Exception
            End Try
            txtCodigoSEPSA.Focus()
        Else
            pnlSEPSA.Visible = False
        End If
    End Sub
    Private Sub btnGuardarSepsa_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardarSepsa.Click
        If txtCodigoSEPSA.Text = "" Then
            MessageBox.Show("Ingrese el Codigo para SEPSA", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCodigoSEPSA.Focus()
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            sql = "UPDATE CLIENTES SET SEPSA = '" & txtCodigoSEPSA.Text & "' WHERE CODCLIENTE = " & CDec(tbxCodCliente.Text) & " "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()

            MessageBox.Show("Codigo Sepsa Guardado con Exito!", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCodigoSEPSA.Focus()

        Catch ex As Exception
            MessageBox.Show("Error al Guardar Codigo Sepsa", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        sqlc.Close()
    End Sub
    Private Sub txtCodigoSEPSA_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoSEPSA.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlSEPSA.Visible = False
        End If
    End Sub
    Private Sub tbxCantCuotas_GotFocus(sender As Object, e As System.EventArgs) Handles tbxCantCuotas.GotFocus

        tbxCantCuotas.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxCantCuotas_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCantCuotas.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxVencimiento.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub
    Private Sub tbxCantCuotas_LostFocus(sender As System.Object, e As System.EventArgs) Handles tbxCantCuotas.LostFocus
        If tbxCantCuotas.Text = "" Then
            cbxTipoVenta.Text = "Contado"
        ElseIf tbxCantCuotas.Text <> 0 Then
            cbxTipoVenta.Text = "Crédito"
        End If
        tbxCantCuotas.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub btnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltro.Click
        Dim desde As String = dtpFechaDesde.Value
        Dim hasta As String = dtpFechaHasta.Value
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:59"

        Try
            Me.RvMovimientosClienteTableAdapter.Fill(DsRVFacturacion.RVMovimientosCliente, CDec(dgvClientes.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn").Value), FechaDesde, FechaHasta)
            CalculaSaldoCtaCliente()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub tbxVencimiento_GotFocus(sender As Object, e As System.EventArgs) Handles tbxVencimiento.GotFocus
        tbxVencimiento.BackColor = SystemColors.Highlight
    End Sub
    Private Sub tbxVencimiento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxVencimiento.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxLimiteCredito.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbxVencimiento_LostFocus(sender As Object, e As System.EventArgs) Handles tbxVencimiento.LostFocus
        tbxVencimiento.BackColor = SystemColors.ControlLightLight
    End Sub

    Private Sub tbxLimiteCredito_GotFocus(sender As Object, e As System.EventArgs) Handles tbxLimiteCredito.GotFocus
        tbxLimiteCredito.BackColor = SystemColors.Highlight
    End Sub

    Private Sub tbxLimiteCredito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxLimiteCredito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxTipoVenta.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbxLimiteCredito_LostFocus(sender As Object, e As System.EventArgs) Handles tbxLimiteCredito.LostFocus
        tbxLimiteCredito.BackColor = SystemColors.ControlLightLight
    End Sub


    Private Sub Maps_Click(sender As Object, e As EventArgs) Handles Maps.Click
        NavigateWebURL("https://www.google.com.py")
    End Sub

    Private Sub NavigateWebURL(ByVal URL As String)
        '// Utiliza el Navegador predeterminado
        Dim link As String
        link = txtGMaps.Text
        Try
            Process.Start(link)
        Catch ex As Exception
            MessageBox.Show("No hay direccion que abrir", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub pbxAgregarCiudad_Click_1(sender As Object, e As EventArgs) Handles pbxAgregarCiudad.Click
        ABMPaisV2.ShowDialog()
        Me.PAISTableAdapter.Fill(Me.DsCliente.PAIS)
        Me.CIUDADTableAdapter.Fill(Me.DsCliente.CIUDAD)
        Me.ZONATableAdapter.Fill(Me.DsCliente.ZONA)
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
        End If

        If KeyAscii = 27 Then
            pnlContacto.SendToBack()
            pnlContacto.Visible = False
            KeyAscii = 0
        End If

    End Sub

    Private Sub tbxMail2Contacto_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxMail2Contacto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxTelContacto.Focus()
        End If

        If KeyAscii = 27 Then
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

        If KeyAscii = 27 Then
            pnlContacto.SendToBack()
            pnlContacto.Visible = False
            KeyAscii = 0

        ElseIf KeyAscii = 13 Then
            tbxCelContacto.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxCodPostal_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCodPostal.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If InStr(1, "0123456789" & Chr(15), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

        If KeyAscii = 13 Then
            cbxListaPrecio.Focus()
            KeyAscii = 0
        End If
    End Sub
    Private Function getHTML(ByVal Address As String)
        Try
            Dim rt As String = ""
            Dim wRequest As WebRequest
            Dim wResponse As WebResponse
            Dim SR As StreamReader
            wRequest = WebRequest.Create(Address)
            wResponse = wRequest.GetResponse
            SR = New StreamReader(wResponse.GetResponseStream)
            rt = SR.ReadToEnd
            SR.Close()
            Return rt
        Catch ex As Exception
            MessageBox.Show("Por favor, asegúrese de poner algo en la caja de texto.")
            Exit Function
        End Try
    End Function
End Class