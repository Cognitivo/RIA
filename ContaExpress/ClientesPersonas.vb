Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.ToolStripMenuItem
Imports Osuna.Utiles.Conectividad
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Imports System.Data.Common
Imports BDConexión
Imports CrystalDecisions.Shared


Public Class ClientesPersonas

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
        '**************************************************************************************************************************************************
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
        VentasPlus.CLIENTESTableAdapter.Fill(VentasPlus.DsFacturacionCompleja.CLIENTES)
        VentasSimple.CLIENTESTableAdapter.Fill(VentasSimple.DsFacturacionSimple.CLIENTES)
        Contactos.CLIENTESTableAdapter.Fill(DsCliente.CLIENTES)
    End Sub

    Private Sub ClientesV2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F2 Then
            CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & txtCliente.Text & "%'" ' AND CODVENDEDOR = " & cbxRepVendedor.SelectedValue & ""
        End If
    End Sub

    Private Sub ClientesPersonas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        permiso = PermisoAplicado(UsuCodigo, 7)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

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

        DesHabilita()
        pnlDatosCliente.BringToFront()

        IsNew = 0
        IsEdit = 0

        If Config1 = "Nombre de Cliente" Then
            NUMCLIENTE.Visible = False
            dgvClientes.ScrollBars = ScrollBars.Vertical
        ElseIf Config1 = "Nro. de Cliente" Then
            NUMCLIENTE.Visible = True
            dgvClientes.ScrollBars = ScrollBars.Both
        End If

    End Sub

      Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
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
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Habilita()

        pnlDatosCliente.Enabled = True
        pnlFinanzas.Enabled = True
        txtNroCliente.Enabled = True
        'tbxFantasia.Enabled = True

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

        lblNombre.Visible = False
        txtCliente.Visible = True
        txtCliente.Text = lblNombre.Text
        txtNombreClienteR.Enabled = False

        dgvClientes.Enabled = False
        BuscarTextBox.Enabled = False
    End Sub

    Public Sub DesHabilita()
        pnlDatosCliente.Enabled = False
        pnlFinanzas.Enabled = False
        txtNroCliente.Enabled = False
        'tbxFantasia.Enabled = False
        txtNombreClienteR.Enabled = False
        lblNombre.Visible = True
        txtCliente.Visible = False

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

        dgvClientes.Enabled = True
        BuscarTextBox.Enabled = True
    End Sub

    Private Sub dgvClientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvClientes.SelectionChanged

        If tbxCodCliente.Text <> "" Then

            'Para saber el Tipo de Venta (Contado/Credito)
            If dgvClientes.CurrentRow Is Nothing Then
            Else
                If IsDBNull(dgvClientes.CurrentRow.Cells("TIPOVENTADataGridViewTextBoxColumn").Value) Then
                    cbxTipoVenta.Text = ""
                Else
                    If dgvClientes.CurrentRow.Cells("TIPOVENTADataGridViewTextBoxColumn").Value = 0 Then
                        cbxTipoVenta.Text = "Contado"
                    Else
                        cbxTipoVenta.Text = "Crédito"
                    End If
                End If
                If IsDBNull(dgvClientes.CurrentRow.Cells("SEXODataGridViewTextBoxColumn").Value) Then
                    cmbSexo.Text = ""
                Else
                    If dgvClientes.CurrentRow.Cells("SEXODataGridViewTextBoxColumn").Value = 0 Then
                        cmbSexo.Text = "Femenino"
                    ElseIf dgvClientes.CurrentRow.Cells("SEXODataGridViewTextBoxColumn").Value = 1 Then
                        cmbSexo.Text = "Masculino"
                    Else
                        cmbSexo.Text = ""
                    End If
                End If

                '    If IsDBNull(dgvClientes.CurrentRow.Cells("CLIENTEDataGridViewTextBoxColumn").Value) Then
                '        cbxTipoVenta.Text = ""
                '    Else
                '        dgvClientes.CurrentRow.Cells("CLIENTEDataGridViewTextBoxColumn").Value = lblNombre.Text
                'End If
        End If

        End If

        If txtIdClienteR.Text <> "" Then
            txtNombreClienteR.Text = f.FuncionConsultaString("NOMBRE", "CLIENTES", "NUMCLIENTE", CDec(txtIdClienteR.Text))

        End If

    End Sub

    Private Sub BuscarTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.GotFocus
        lblClienteEstado.Text = "Buscandor de Clientes"
        BuscarTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub BuscarTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.LostFocus
        lblClienteEstado.Text = ""
        BuscarTextBox.BackColor = Color.DimGray
    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged
        Try
            If BuscarTextBox.Text = "" Then
                Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR NUMCLIENTE1 LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarTextBox.Text & "%'"
            Else
                If Config1 = "Nombre de Cliente" Then
                    Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarTextBox.Text & "%'"
                ElseIf Config1 = "Nro. de Cliente" Then
                    If Not System.Text.RegularExpressions.Regex.IsMatch(BuscarTextBox.Text, "^\d*$") Then ' Si introduce letras
                        Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarTextBox.Text & "%'"
                    Else
                        Me.CLIENTESBindingSource.Filter = "NUMCLIENTE1 =" & BuscarTextBox.Text
                        If dgvClientes.RowCount = 0 Then
                            Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & BuscarTextBox.Text & "%' OR RUC LIKE '%" & BuscarTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarTextBox.Text & "%'"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

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

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtNroCliente.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxRUC.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxRUC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxRUC.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            dtpFechaNac.Focus()
        End If

        If KeyAscii = 42 Then

            If tbxRUC.Text <> "" Then
                Dim str As String
                Dim cadena As String

                str = tbxRUC.Text
                cadena = str.Substring(str.Length - 2, 1)

                If cadena <> "-" Then
                    Dim DV As Integer
                    DV = getDV(tbxRUC.Text)
                    tbxRUC.Text = tbxRUC.Text & "-" & DV
                End If
                If btnuevo = 1 Or btmodificar = 1 Then
                    Dim existeruc As String
                    existeruc = f.FuncionConsultaString("NOMBRE", "CLIENTES", "RUC", Me.tbxRUC.Text)

                    If existeruc = Nothing Or existeruc = "" Then
                        'No existe el ruc
                        GoTo fin
                    Else
                        If btmodificar = 1 And Trim(existeruc) = Trim(lblNombre.Text) Then
                            'Esta Modificando el Cliente dueño del Ruc, entonces no hacer nada
                            'En el caso de los mismos nombres..estos tienen el mismo RUC, entonces esta bien permitirle

                            GoTo fin
                        End If
                        tbxRUC.BackColor = Color.Pink
                        GoTo fin ' para saltar el cambio de Backcolor
                    End If
                End If
            End If

fin:
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtpfechaNac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaNac.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cmbSexo.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
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

    Private Sub cmbSexo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSexo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxEmail.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
   
    Private Sub tbxTel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxTel.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxCellular.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxCellular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCellular.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtDireccion.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
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

    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        btnuevo = 1
        permiso = PermisoAplicado(UsuCodigo, 8)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para crear un cliente", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            lblClienteEstado.Text = "Cargue un Nuevo Cliente"
            

            IsNew = 1
            IsEdit = 0

            pnlDatosCliente.BringToFront()
            Habilita()
            actualizargrillaclientes()
            CLIENTESBindingSource.AddNew()

            NuevoPictureBox.Image = My.Resources.NewActive
            
            txtIdClienteR.Text = "" : txtNombreClienteR.Text = ""
            txtCliente.Focus()
        End If
    End Sub

    Private Sub Insertar()
        Dim consulta As System.String
        Dim sex As Integer
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction

        conexion = ser.Abrir()
        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        Try
            myTrans.Commit()
            If cmbSexo.Text = "Masculino" Then
                sex = 1
            Else
                sex = 0
            End If
            consulta = "INSERT INTO CLIENTES (CODUSUARIO, CODEMPRESA, CODTIPOCLIENTE, NUMCLIENTE, NOMBRE, RUC, SEXO, TELEFONO, EMAIL, NOMBREFANTASIA, FECHANACIMIENTO, OBSERVACION, CELULAR, DIRECCION, CODCIUDAD) VALUES (1, 1, 1, " & txtNroCliente.Text & ", '" & txtCliente.Text & "', '" & tbxRUC.Text & "', " & sex & ", '" & tbxTel.Text & "', '" & tbxEmail.Text & "', '" & txtCliente.Text & "', CONVERT(DATETIME,'" & dtpFechaNac.Text & "',103), '" & txtObservacion.Text & "', '" & tbxCellular.Text & "', '" & txtDireccion.Text & "', '" & cbxCiudad.SelectedValue & "')"

            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            Consultas.ConsultaComando(myTrans, consulta)
            myTrans.Commit()
        Catch ex As Exception
            'myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            myTrans.Rollback("Insertar")
        End Try
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click

        btnuevo = 0 : btmodificar = 0

        Dim ClienteIsNull As String

        ClienteIsNull = f.FuncionConsultaString("NOMBRE", "CLIENTES", "CODCLIENTE", CodClienteGlobal)

        Try
            CLIENTESBindingSource.CancelEdit()
            CLIENTESBindingSource.RemoveFilter()
            DesHabilita()
            lblNombre.Visible = True
            txtCliente.Visible = False
            actualizargrillaclientes()
        Catch ex As Exception

        End Try
        btmodificar = 0
        lbledad.Visible = True
        Label2.Visible = True
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.NuevoPictureBox, "Nuevo Cliente")
    End Sub

    Private Sub EliminarPictureBox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.EliminarPictureBox, "Eliminar Cliente")
    End Sub

    Private Sub ModificarPictureBox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.ModificarPictureBox, "Editar Ficha Cliente")
    End Sub

    Private Sub GuardarPictureBox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.GuardarPictureBox, "Guardar Ficha Cliente")
    End Sub

    Private Sub CancelarPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.MouseEnter
        Me.ToolTip1.SetToolTip(Me.GuardarPictureBox, "Cancelar Ficha Cliente")
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        btmodificar = 1
        permiso = PermisoAplicado(UsuCodigo, 10)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene Permiso para MODIFICAR", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        Else

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
        Dim LimCredito, TipoVenta, CodCiudad, CodZona, CodDepartamento, NroCliente As String
        Dim sexocliente As Integer
        Dim transaction As SqlTransaction = Nothing

        'Controles
        If txtCliente.Text = "" Then
            MessageBox.Show("Indique un Nombre del Cliente", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCliente.Focus()
            txtCliente.BackColor = Color.Pink
            Exit Sub
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

        'If tbxFantasia.Text = "" Then
        '    NomFantasia = " "
        'Else
        '    NomFantasia = tbxFantasia.Text
        'End If

        If cmbSexo.Text = "Femenino" Then
            sexocliente = 0
        ElseIf cmbSexo.Text = "Masculino" Then
            sexocliente = 1
        Else
            sexocliente = 2
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

        If cbxTipoVenta.Text = "" Then
            TipoVenta = "NULL"
        Else
            If cbxTipoVenta.Text = "Contado" Then
                TipoVenta = 0
            Else
                TipoVenta = 1
            End If
        End If

        'Guardamos en la base de datos
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        pbarClientes.Value += 50
        Try

            Dim Concat As String = dtpFechaNac.Text
            Dim Concatenar As String = Concat & " " + "00:00:00"

            Dim cliente As Integer
            cliente = tbxCodCliente.Text
            sql = ""
            sql = "UPDATE CLIENTES SET " & _
            "NOMBRE = '" & txtCliente.Text & "', RUC = '" & tbxRUC.Text & "', NUMCLIENTE = '" & NroCliente & "',  " & _
            "CODCIUDAD = " & CodCiudad & ",DIRECCION = '" & Replace(txtDireccion.Text, "'", "''") & "', " & _
            "TELEFONO= '" & tbxTel.Text & "', CELULAR='" & tbxCellular.Text & "', " & _
            "EMAIL= '" & tbxEmail.Text & "', CODZONA=" & CodZona & ", " & _
            "CODTIPOCLIENTE = 1, " & _
            "CODDEPARTAMENTO = " & CodDepartamento & " ," & _
            "OBSERVACION = '" & txtObservacion.Text & "' , " & _
            "SEXO = " & sexocliente & ", FECHANACIMIENTO= CONVERT(DATETIME,'" & Concatenar & "',103) " & _
            "WHERE CODCLIENTE = " & CDec(tbxCodCliente.Text) & " "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()

            cliente = tbxCodCliente.Text
            IsNew = 0 : IsEdit = 0

            actualizargrillaclientes()

            'Buscamos la posicion del registro guardado
            For I = 0 To dgvClientes.RowCount - 1
                If dgvClientes.Rows(I).Cells("CODCLIENTEDataGridViewTextBoxColumn").Value = cliente Then
                    CLIENTESBindingSource.Position = I
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
        Dim err As Integer = 0
        Try
            If btmodificar = 1 Then
                Me.Cursor = Cursors.AppStarting
                Guardar()
                Me.Cursor = Cursors.Arrow
                btmodificar = 0
            Else
                Me.Cursor = Cursors.AppStarting
                Insertar()
                Me.Cursor = Cursors.Arrow
            End If

            MessageBox.Show("Registro Guardado Correctamente", "R.I.A. SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

            MessageBox.Show("Hubo un error al Guardar", "R.I.A. SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

        DesHabilita()
        dgvClientes.Focus()
        btnuevo = 0 : btmodificar = 0
        dgvClientes.Refresh()

        actualizargrillaclientes()
        lbledad.Visible = True
        Label2.Visible = True

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
            MessageBox.Show("Usted no tiene permiso para eliminar un cliente", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else

            If MessageBox.Show("¿Esta seguro que quiere eliminar el Cliente?", "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If
            If tbxCodCliente.Text = "" Then
                MessageBox.Show("Seleccione el Cliente A Eliminar", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    MessageBox.Show("Este Cliente que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podra eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al Eliminar Cliente: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Finally
                sqlc.Close()
            End Try
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pbxAgregarCiudad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarCiudad.Click
        ABMPaisV2.ShowDialog()
        Me.PAISTableAdapter.Fill(Me.DsCliente.PAIS)
        Me.CIUDADTableAdapter.Fill(Me.DsCliente.CIUDAD)
        Me.ZONATableAdapter.Fill(Me.DsCliente.ZONA)
    End Sub

    Private Sub pbxAgregarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ABMTipoCliente.ShowDialog()
        Me.TIPOCLIENTETableAdapter.Fill(DsCliente.TIPOCLIENTE)
    End Sub

    Private Sub pbxAgregarVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ABMVendedorV2.ShowDialog()
        Me.VENDEDORTableAdapter.Fill(DsCliente.VENDEDOR)
    End Sub

    Private Sub txtNroCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroCliente.LostFocus
        'Verificamos que el nro de cliente no se repita.
        GenerarNroCliente()

    End Sub

#End Region

    Private Sub GenerarNroCliente()
        Dim Existe, CodCliente As Integer
        Dim Aleatorio As Integer
        Dim Minimo As Integer = "1"
        Dim Maximo As Integer = "9999"

        If txtNroCliente.Text = "" Then
            Aleatorio = "0001"
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

    Private Sub pbxDatosCliente_Click(sender As System.Object, e As System.EventArgs) Handles pbxDatosCliente.Click
        pnlObservacion.Visible = False
        pbxClienteFinanzas.Image = My.Resources.Financial
        pbxClienteFinanzas.Cursor = Cursors.Hand
        pbxDatosCliente.Image = My.Resources.UserActive
        pbxDatosCliente.Cursor = Cursors.Arrow
        pbxAgregarCiudad.Visible = True
        pnlDatosCliente.BringToFront()
    End Sub

    Private Sub pbxClienteFinanzas_Click(sender As System.Object, e As System.EventArgs) Handles pbxClienteFinanzas.Click
        permiso = PermisoAplicado(UsuCodigo, 35)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            If IsNew = 0 Then 'quiere decir q no fue Nuevo
                Me.MOVIMIENTOCUENTACLIENTETableAdapter.Fill(DsCliente.MOVIMIENTOCUENTACLIENTE, tbxCodCliente.Text)
                CalculaSaldoCtaCliente()

            Else
                LblSaldo.Text = "0"
                Me.MOVIMIENTOCUENTACLIENTETableAdapter.Fill(DsCliente.MOVIMIENTOCUENTACLIENTE, Me.CodClienteGlobal)
            End If

            pbxDatosCliente.Cursor = Cursors.Hand
            pbxDatosCliente.Image = My.Resources.User
            pbxClienteFinanzas.Cursor = Cursors.Arrow
            pbxClienteFinanzas.Image = My.Resources.FinancialActive

            pbxAgregarCiudad.Visible = False
            pnlFinanzas.BringToFront()
            tbxVencimiento.Focus()
        End If
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Dim pag As String
        pag = "http://cogentpotential.com/soporte/ventas/clientes"
        Shell("Explorer " & pag)
    End Sub

    Private Sub pbxAgregarCategoria_Click(sender As System.Object, e As System.EventArgs)
        ABMCategoriaCliente.ShowDialog()
        Me.CATEGORIACLIENTETableAdapter.Fill(Me.DsCliente.CATEGORIACLIENTE)
    End Sub

    Private Sub txtIdClienteR_LostFocus(sender As Object, e As System.EventArgs) Handles txtIdClienteR.LostFocus
        If txtIdClienteR.Text <> "" Then
            txtNombreClienteR.Text = f.FuncionConsultaString("NOMBRE", "CLIENTES", "NUMCLIENTE", txtIdClienteR.Text)
            tbxRUC.Text = f.FuncionConsultaString("RUC", "CLIENTES", "NUMCLIENTE", txtIdClienteR.Text)
        End If
    End Sub

    Private Sub actualizargrillaclientes()
        Try
            If Config1 = "Nombre de Cliente" Then
                Me.CLIENTESTableAdapter.Fill(Me.DsCliente.CLIENTES)
            ElseIf Config1 = "Nro. de Cliente" Then
                Me.CLIENTESTableAdapter.OrderByNroCliente(Me.DsCliente.CLIENTES)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMostrarOBS_Click(sender As System.Object, e As System.EventArgs)
        pnlObservacion.Visible = True
        pnlObservacion.BringToFront()

        If btmodificar = 1 Or btnuevo = 1 Then
            txtObservacion.Enabled = True
            txtObservacion.Focus()
        Else
            txtObservacion.Enabled = False
        End If
    End Sub

    Private Sub btnCerrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarOBS.Click
        pnlObservacion.Visible = False
    End Sub

    Private Sub txtObservacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlObservacion.Visible = False
        End If
    End Sub

    Private Sub PictureBox8_DoubleClick(sender As Object, e As System.EventArgs) Handles PictureBox8.DoubleClick

        CLIENTESBindingSource.Filter = "CodCliente = NULL"
        Habilita()
    End Sub

    Private Sub pbxMostrarOBS_Click(sender As System.Object, e As System.EventArgs) Handles pbxMostrarOBS.Click
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
    Public Function CalcularEdad(ByVal FechaNac As Date) As Int32
        Dim Edad As Int32
        Diferencia = Today.Subtract(FechaNac)
        Edad = Fix(Diferencia.TotalDays / 365.25)
        Return Edad
    End Function

    Private Sub dtpFechaNac_LostFocus(sender As Object, e As EventArgs) Handles dtpFechaNac.LostFocus
        lbledad.Text = CalcularEdad(dtpFechaNac.Value)
        lbledad.Visible = True
        Label2.Visible = True

    End Sub

    Private Sub pbxImprimir_Click(sender As Object, e As EventArgs) Handles pbxImprimir.Click
        'Dim frm = New VerInformes
        'Dim rpt = New Reportes.ClientesMailing
        'frm.CrystalReportViewer1.ReportSource = rpt
        'frm.WindowState = FormWindowState.Maximized
        'frm.Show()
    End Sub
End Class