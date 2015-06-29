Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Imports CrystalDecisions.Shared
Imports EnviaInformes
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Imports System.Reflection.BindingFlags

Public Class Devoluciones
    'Variables importantisimas
    Dim Existe As Integer
    Dim w As New Funciones.Funciones
    Private row As DataRow

    'Variables de Transaccion
    Dim filename As String
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Private conexion As System.Data.SqlClient.SqlConnection
    Private objCommand As New SqlCommand
    Dim sql As String
    Dim permisostockneg, band As Integer
    Dim posVenta As Integer
    Dim CondicionStock As String
    Dim vendermasquestock As Integer

    'Variables para guardar la devolucion
    Dim TotalDev, TotalExenta, TotalGravada, TotalIva5, TotalIva10, Cotizacion1, Cotizacion2 As String
    Dim CodVendedor, Descarte, DescSINO, MotivoDescartar, NumDevolucion As String
    'fechas
    Dim Mes As String, Año As String
    Dim FechaFiltro1, FechaFiltro2 As Date
    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim sel As Integer
    Dim ins As Integer
    Dim upd As Integer
    Dim del As Integer
    Dim pri As Integer
    Dim anu As Integer
    Dim NuevaDev, AccBtNuevo, SiDEV As Integer
    Dim Cantlinea, tipoimpresion As Integer
    Dim CodListaPrecio, VGSaldo, tipoventaActual, permiso As Integer
    Dim errorFiltroFecha As Integer = 0
    Dim errorFiltroRango As Integer = 0
    Dim changingselection, YatengoFact As Boolean
    Dim f As New Funciones.Funciones
    Dim NroDevGlobal As Double
    Dim NroRango As String
    Dim btduplicar As Integer = 0
    Dim NroFacturaRelActual As String = ""
    Dim vgDevoluciones As Integer
    Dim vgCodCodigo, vgCodProducto, vgValorDev, vgControl As Integer

    'PARA IMPRIMIR EL TICKET
    Dim CodTipocomprobante, Codsucursalelegida, CodClienteV, NumVenta, TotalVenta, TotalGravado10, TotalGravado5, TotalIva As String
    Dim Total10, Total5, Estado, TimbradoFactura, impresora As String
    Dim Config1, Config2, Config3, Config4, Config5, Config6, Config7, ConfigSaldoContado As String
    Dim DescontarMonto, tratamiento As Integer
    Dim MontoFactura As Integer

#Region "LOAD"

    Private Sub Devoluciones_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            If txtCodigo.Enabled = True Then
                txtCodigo.Focus()
            End If
        End If

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
            If CancelarPictureBox.Enabled = True Then
                CancelarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F9 Then
            'No hay funcion para el F9
        End If

        If e.KeyCode = Keys.F10 Then
            'No hay funcion para F10
        End If

        If e.KeyCode = Keys.F11 Then 'APROBAR
            If btnAprobar.Enabled = True Then
                btnAprobar_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F12 Then 'ANULAR
            If btnAnular.Enabled = True Then
                btnAnular_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            pnlProdcutoCodigo.Visible = False
            VentasGroupBox.Visible = False
            ProductosGroupBox.Visible = False
            GroupBoxClientes.Visible = False
        End If
    End Sub

    Private Sub Devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 42)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        ObtenerConfig()

        ConfigSaldoContado = w.FuncionConsultaString("CONFIG7", "MODULO", "MODULO_ID", 8)

        Me.CLIENTESTableAdapter.Fill(Me.DsDevoluciones.CLIENTES)
        Me.TIPOCOMPROBANTETableAdapter.Fill(Me.DsDevoluciones.TIPOCOMPROBANTE)
        Me.SUCURSALTableAdapter.Fill(Me.DsDevoluciones.SUCURSAL)
        Me.MONEDATableAdapter.Fill(Me.DsDevoluciones.MONEDA)
        Me.VENDEDORTableAdapter.Fill(Me.DsDevoluciones.VENDEDOR)

        InicializaFechaFiltro()
        Me.DEVOLUCIONTableAdapter.FillBySuc(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2, SucCodigo)
        Dim dt As DataTable = DEVOLUCIONTableAdapter.GetDataBySuc(FechaFiltro1, FechaFiltro2, SucCodigo)
        Try
            Me.DEVOLUCIONDETALLETableAdapter.Fill(Me.DsDevoluciones.DEVOLUCIONDETALLE)
        Catch ex As Exception
        End Try
        lblDGVCant.Text = "Cant. de Items:" & DevolucionesDataGridView.RowCount

        CmbMoneda.SelectedValue = CDec(CODMONEDAPRINCIPAL)
        If CmbMoneda.SelectedValue <> Nothing Then
            Cotizacion.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(CmbMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
        End If

        GroupBoxClientes.SendToBack()
        ProductosGroupBox.SendToBack()
        VentasGroupBox.SendToBack()

        'CREAR PERMISO
        permiso = PermisoAplicado(UsuCodigo, 41)
        If permiso = 0 Then
            BtnNuevoP3.Enabled = False
            BtnNuevoP3.Visible = False
            Me.tsCargarNroFactura.Enabled = False
        Else
            BtnNuevoP3.Enabled = False
            Me.tsCargarNroFactura.Enabled = False
            BtnNuevoP3.Visible = True
        End If

        If DevolucionesDataGridView.Rows.Count < 1 Then
            EliminarPictureBox.Enabled = False
            tsEliminar.Enabled = False
            EliminarPictureBox.Image = My.Resources.DeleteOff
            ModificarPictureBox.Enabled = False
            tsEditar.Enabled = False
            ModificarPictureBox.Image = My.Resources.EditOff
            btnAprobar.Enabled = False
            tsAprobar.Enabled = False
            btnAprobar.Image = My.Resources.ApproveOff
        Else
            Try
                RecorreDetalleDevolucion()
                txtNrodeCliente.Text = w.FuncionConsultaString("numcliente", "clientes", "codcliente", CDec(ClienteComboBox.SelectedValue))
            Catch ex As Exception
            End Try
        End If

        Deshabilita()
        TxtEstado_TextChanged(Nothing, Nothing)
        AccBtNuevo = 0
        permisostockneg = PermisoAplicado(UsuCodigo, 201)
        PintarCeldas()
    End Sub

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2

    End Sub

    Public Sub PintarCeldas()
        Try
            If DevolucionesDataGridView.RowCount - 1 >= 1 Then
                For i = 0 To DevolucionesDataGridView.RowCount - 1
                    If DevolucionesDataGridView.Rows(i).Cells("ESTADODEV").Value = 1 Then
                        DevolucionesDataGridView.Item(0, i).Style.ForeColor = Color.Green
                    ElseIf DevolucionesDataGridView.Rows(i).Cells("ESTADODEV").Value = 2 Then
                        DevolucionesDataGridView.Item(0, i).Style.ForeColor = Color.Maroon
                    ElseIf DevolucionesDataGridView.Rows(i).Cells("ESTADODEV").Value = 0 Then
                        DevolucionesDataGridView.Item(0, i).Style.ForeColor = Color.Black
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1, CONFIG2,CONFIG3, CONFIG4,CONFIG5,CONFIG6, CONFIG7 FROM MODULO WHERE MODULO_ID = 11"
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
                    Config7 = odrConfig("CONFIG7")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "BUSCADORES"

    Private Sub tbxBuscarCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxBuscarCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgwClientes.Select()
        End If
    End Sub

    Private Sub tbxBuscarCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxBuscarCliente.TextChanged
        Try
            If tbxBuscarCliente.Text = "" And tbxBuscarCliente.Text <> "Buscar..." Then
                Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & tbxBuscarCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & tbxBuscarCliente.Text & "%' "
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(tbxBuscarCliente.Text, "^\d*$") Then ' Si introduce letras
                    Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & tbxBuscarCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & tbxBuscarCliente.Text & "%' "
                Else
                    Me.CLIENTESBindingSource.Filter = "NUMCLIENTE1 =" & tbxBuscarCliente.Text & ""
                    If DevolucionesDataGridView.RowCount = 0 Then
                        Me.CLIENTESBindingSource.Filter = "CLIENTE LIKE '%" & tbxBuscarCliente.Text & "%' OR NOMBREFANTASIA LIKE '%" & tbxBuscarCliente.Text & "%' "
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tbxBuscarCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxBuscarCliente.GotFocus
        If tbxBuscarCliente.Text = "Buscar..." Then
            tbxBuscarCliente.Text = ""
        End If
    End Sub

    Private Sub BuscaFacturaTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscaFacturaTextBox.GotFocus
        If BuscaFacturaTextBox.Text = "Buscar..." Then
            BuscaFacturaTextBox.Text = ""
        End If
    End Sub

#End Region

#Region "GENERA TIMBRADO"
    Private Sub CalculaNroDevolucion()
        Dim NumSucursal, NumMaquina, NroRango As String
        Dim f As New Funciones.Funciones
        NumSucursal = SucCodigo
        NumMaquina = NumMaquinaGlobal

        NroRango = f.MaximoconWhere("ULTIMO", "DETPC", "IP=" & CodigoMaquina & " AND CODEMPRESA=" & EmpCodigo & " AND CODSUCURSAL=" & SucCodigo & " AND CODCOMPROBANTE", 10)
        NroRango = NroRango + 1

        If SucCodigo = 0 Then
            NumSucursal = "XXX"
        ElseIf Len(NumSucursal) = 1 Then
            NumSucursal = "00" & CStr(NumSucursal)
        ElseIf Len(NumSucursal) = 2 Then
            NumSucursal = "0" & CStr(NumSucursal)
        ElseIf Len(NumSucursal) = 3 Then
            NumSucursal = CStr(NumSucursal)
        End If

        If NumMaquina = "0" Then
            NumMaquina = "XXX"
        ElseIf Len(NumMaquina) = 1 Then
            NumMaquina = "00" & CStr(NumMaquina)
        ElseIf Len(NumMaquina) = 2 Then
            NumMaquina = "0" & CStr(NumMaquina)
        ElseIf Len(IpMaquina) = 3 Then
            NumMaquina = CStr(NumMaquina)
        End If

        If NroRango = "0" Then
            NroRango = "XXXXXX"
        ElseIf Len(NroRango) = 1 Then
            NroRango = "00000" & CStr(NroRango)
        ElseIf Len(NroRango) = 2 Then
            NroRango = "0000" & CStr(NroRango)
        ElseIf Len(NroRango) = 3 Then
            NroRango = "000" & CStr(NroRango)
        ElseIf Len(NroRango) = 4 Then
            NroRango = "00" & CStr(NroRango)
        ElseIf Len(NroRango) = 5 Then
            NroRango = "0" & CStr(NroRango)
        ElseIf Len(NroRango) = 6 Then
            NroRango = CStr(NroRango)
        End If

        NroNCLabel.Text = NumSucursal & "." & NumMaquina & "." & NroRango
    End Sub
#End Region

#Region "Eventos del Formulario"


    Private Sub ClienteComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ClienteComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            upcClientes.Show()
            tbxBuscarCliente.Focus()
            e.Handled = True
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If KeyAscii = 13 Then
            CmbDeposito.Focus()
        End If
    End Sub

    Private Sub Habilita()
        DevolucionesDataGridView.Enabled = False
        BuscarDevolucionTextBox.Enabled = False

        VendendorComboBox.Enabled = True
        CmbMoneda.Enabled = True
        IngresarCotCheckBox.Enabled = True
        cbxDescontarMonto.Enabled = True
        CmbAño.Enabled = False
        CmbMes.Enabled = False
        BtnFiltro.Enabled = False

        cbxDevOtrosDepositos.Enabled = True
        dtpFechaDev.Focus()

        txtNrodeCliente.Enabled = True
        txtNroFactura.Enabled = True
        TipoComprobanteComboBox.Enabled = True
        cbxTipoDevolucion.Enabled = True
        dtpFechaDev.Enabled = True
        ClienteComboBox.Enabled = True

        'Botonsillos
        AddButton.Enabled = True
        AddButton.Visible = True
        ElimButton.Enabled = True
        ElimButton.Visible = True

        'detalle
        Panel2.Enabled = True
        txtCodigo.Enabled = True
        CantidadTextBox.Enabled = True
        cbxDescartar.Enabled = True
        txtMotivoDescarte.Enabled = True
        CmbDeposito.Enabled = True
        cbxIva.Enabled = True
        cbxTipoItem.Enabled = True
        chbxTratamiento.Enabled = True
        txtPrecio.Enabled = True
        cbxRelacionarFactura.Enabled = True
        cbxTipoItem.Enabled = True

        'txtCodigo.Enabled = True
        'CantidadTextBox.Enabled = True
        'txtPrecio.Enabled = True
        'cbxDescartar.Enabled = True
        'cbxIva.Enabled = True
        DetalleDevDataGridView.Enabled = True

        'CREAR PERMISOS
        'Para Permitir modificar el nro de factura
        permiso = PermisoAplicado(UsuCodigo, 41)
        If permiso = 0 Then
            BtnNuevoP3.Enabled = False
            BtnNuevoP3.Visible = False
            Me.tsCargarNroFactura.Enabled = False
        Else
            BtnNuevoP3.Enabled = True
            BtnNuevoP3.Visible = True
            Me.tsCargarNroFactura.Enabled = True
        End If
    End Sub

    Private Sub Deshabilita()
        DevolucionesDataGridView.Enabled = True
        BuscarDevolucionTextBox.Enabled = True

        VendendorComboBox.Enabled = False
        CmbMoneda.Enabled = False
        IngresarCotCheckBox.Enabled = False

        'filtro Fechas
        CmbAño.Enabled = True
        CmbMes.Enabled = True
        BtnFiltro.Enabled = True
        cbxDescontarMonto.Enabled = False
        txtNrodeCliente.Enabled = False
        txtNroFactura.Enabled = False
        TipoComprobanteComboBox.Enabled = False
        cbxTipoDevolucion.Enabled = False
        cbxDevOtrosDepositos.Enabled = False
        dtpFechaDev.Enabled = False
        ClienteComboBox.Enabled = False

        'Botonsillos
        AddButton.Enabled = False
        ElimButton.Enabled = False
        AddButton.Text = "Agregar"
        ElimButton.Text = "Eliminar"

        'detalle
        txtCodigo.Enabled = False
        CantidadTextBox.Enabled = False
        cbxDescartar.Enabled = False
        txtMotivoDescarte.Enabled = False
        chbxTratamiento.Enabled = False
        CmbDeposito.Enabled = False
        cbxIva.Enabled = False
        cbxTipoItem.Enabled = False
        txtPrecio.Enabled = False
        cbxRelacionarFactura.Enabled = False
        BtnNuevoP3.Enabled = False
        Me.tsCargarNroFactura.Enabled = False
    End Sub

    Private Sub VentasDataGridView_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles VentasDataGridView.CellClick
        If VentasDataGridView.CurrentCellAddress.X = 9 Then
            posVenta = VentasDataGridView.CurrentCellAddress.Y
            If VentasDataGridView.CurrentRow.Cells("Usar").Value = True Then
                posVenta = -1
            Else
                For i = 0 To VentasDataGridView.RowCount - 1
                    If VentasDataGridView.Rows(i).Cells("Usar").Value = True Then
                        VentasDataGridView.Rows(i).Cells("Usar").Value = False
                        VentasDataGridView.Rows(posVenta).Cells("Usar").Value = True
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub VentasDataGridView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles VentasDataGridView.CellDoubleClick
        coti = "1,00"
        Try
            If IsDBNull(VentasDataGridView.CurrentRow.Cells("CODVENTA").Value) Then
            Else
                posVenta = VentasDataGridView.CurrentCellAddress.Y
                VentasDataGridView.CurrentRow.Cells("Usar").Value = True
                CodVentaTextBox.Text = VentasDataGridView.CurrentRow.Cells("CODVENTA").Value
                txtNroFactura.Text = VentasDataGridView.CurrentRow.Cells("NUMVENTADataGridViewTextBoxColumn").Value
                tipoventaActual = VentasDataGridView.CurrentRow.Cells("TIPOVENTA").Value

                '------------------TOMA EL TIPO DE LA COTIZACION Y LA COTIZACION DE LA FACTURA ELEGIDA-----------------------
                '------------------------PARA ACTUALIZAR AUTOMATICAMENTE EN LA NOTA DE CREDITO-------------------------------
                coti = VentasDataGridView.Rows(posVenta).Cells("COTIZACION1DataGridViewTextBoxColumn").Value
                CmbMoneda.SelectedValue = VentasDataGridView.Rows(posVenta).Cells("CODMONEDADataGridViewTextBoxColumn").Value
                '------------------------------------------------------------------------------------------------------------

                If VentasDataGridView.CurrentRow.Cells("SALDO").Value = 0 Then
                    VGSaldo = VentasDataGridView.CurrentRow.Cells("SALDODV").Value
                    SiDEV = 1
                Else
                    VGSaldo = VentasDataGridView.CurrentRow.Cells("SALDO").Value
                    SiDEV = 0
                End If

                If IsDBNull(VentasDataGridView.CurrentRow.Cells("CODVENDEDOR2").Value) Then
                Else
                    VendendorComboBox.SelectedValue = VentasDataGridView.CurrentRow.Cells("CODVENDEDOR2").Value
                End If
            End If
            YatengoFact = True
            upcFacturasVentas.Close()
            YatengoFact = False
            txtCodigo.Focus()
            '---Reemplazamos la cotización---
            Cot1FactTextBox.Text = coti
        Catch ex As Exception
            upcFacturasVentas.Close()
        End Try
    End Sub

    Private Sub BuscaProducto(ByVal CodigoIngresado As String)
        Dim ProductoF, DesCodigo1F, Descodigo2F, CodProductoF, CodCodigoF As String

        CodProductoF = w.FuncionConsultaString("CODPRODUCTO", "CODIGOS", "CODIGO", CodigoIngresado)
        CodCodigoF = w.FuncionConsultaString("CODCODIGO", "CODIGOS", "CODIGO", CodigoIngresado)

        If CodCodigoF = "0" Or CodProductoF = "0" Then
            Limpiamos()
            Exit Sub
        End If
        DesCodigo1F = w.FuncionConsultaString("DESCODIGO1", "CODIGOS", "CODIGO", CodigoIngresado)
        Descodigo2F = w.FuncionConsultaString("DESCODIGO2", "CODIGOS", "CODIGO", CodigoIngresado)


        ProductoF = w.FuncionConsultaString("DESPRODUCTO", "PRODUCTOS", "CODPRODUCTO", CodProductoF)

        If DesCodigo1F = "0" Then
            DesCodigo1F = ""
        End If

        If Descodigo2F = "0" Then
            Descodigo2F = ""
        End If

        txtProductoDescripcion.Text = ProductoF + " " + DesCodigo1F + " " + Descodigo2F
        CodCodigoTextBox.Text = CodCodigoF
        CodProductoTextBox.Text = CodProductoF

    End Sub

    Private Sub ProductosDataGridView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosDataGridView.CellDoubleClick
        Try
            If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value) Then
                txtCodigo.Text = ""
            Else
                txtCodigo.Text = ProductosDataGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                CodCodigoTextBox.Text = ""
            Else
                CodCodigoTextBox.Text = ProductosDataGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                CodProductoTextBox.Text = ""
            Else
                CodProductoTextBox.Text = ProductosDataGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(ProductosDataGridView.CurrentRow.Cells("IVADataGridViewTextBoxColumn1").Value) Then
                IVATextBox.Text = ""
            Else
                IVATextBox.Text = ProductosDataGridView.CurrentRow.Cells("IVADataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                CantidadTextBox.Text = ""
            Else
                CantidadTextBox.Text = ProductosDataGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
            End If

            'Cantidad Real
            If cbxRelacionarFactura.Text = "No" Then
                ' If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                CantRealMaskedEdit.Value = 0
                'End If
            Else
                CantRealMaskedEdit.Value = CDec(ProductosDataGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) - CDec((CantidadTextBox).Value)
            End If

            If IsDBNull(ProductosDataGridView.CurrentRow.Cells("PRODUCTODataGridViewTextBoxColumn").Value) Then
                txtProductoDescripcion.Text = ""
            Else
                txtProductoDescripcion.Text = ProductosDataGridView.CurrentRow.Cells("PRODUCTODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(ProductosDataGridView.CurrentRow.Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value) Then
                txtPrecio.Text = ""
            Else
                txtPrecio.Text = ProductosDataGridView.CurrentRow.Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
            End If

            ProductosGroupBox.Visible = False
            CantidadTextBox.Focus()

        Catch ex As Exception
            ProductosGroupBox.Visible = False
            upcProductoFactura.Close()
        End Try
    End Sub

    Private Sub CantidadTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles CantidadTextBox.GotFocus
        ''Dim CantCombo As Integer = CDec(Me.CantidadTextBox.Text)
    End Sub

    Private Sub CantidadTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtPrecio.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 43)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso crear una nueva devolución", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            posVenta = -1 : YatengoFact = False
            Habilita()
            FechaFiltro1 = "01/01/2000" : FechaFiltro2 = "01/01/3000"

            Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)

            DEVOLUCIONBindingSource.AddNew()

            Me.DEVOLUCIONDETALLETableAdapter.FillBy(DsDevoluciones.DEVOLUCIONDETALLE, 0)


            Dim MaxDev As Integer = w.Maximo("CODDEVOLUCION", "DEVOLUCION")

            If CmbDeposito.Text = "" Then
                CmbDeposito.SelectedIndex = CmbDeposito.SelectedIndex + 1
            End If

            If TipoComprobanteComboBox.Text = "" And TipoComprobanteComboBox.Items.Count > 0 Then
                TipoComprobanteComboBox.SelectedIndex = TipoComprobanteComboBox.SelectedIndex + 1
            End If

            CancelarPictureBox.Visible = True : cbxTipoDevolucion.Text = "Devolución"
            cbxDevOtrosDepositos.Text = "No" : cbxRelacionarFactura.Text = "No"
            AccBtNuevo = 1 : TxtEstado.Text = "3" : cbxTipoItem.Text = "Producto"
            tbxSeCobro.Text = "" : tbxBuscarCliente.Text = "" : txtLocalizacionDir.Text = "" : lblNombreFantasia.Text = ""
            cbxDescartar.Text = Config1 : SiDEV = 0

            If Config2 = "Actual" Then
                dtpFechaDev.Value = Today

            ElseIf Config2 = "Atrazada 1 Día" Then
                Dim day As Integer = DateTime.Now.AddDays(-1).Day
                Dim mes As Integer = Today.Month
                Dim anho As Integer = Today.Year

                Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                dtpFechaDev.Value = Fecha

            ElseIf Config2 = "Adelantada 1 Día" Then
                Dim day As Integer = DateTime.Now.AddDays(+1).Day
                Dim mes As Integer = Today.Month
                Dim anho As Integer = Today.Year

                Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                dtpFechaDev.Value = Fecha

            ElseIf Config2 = "Ultima Seleccion" Then
                'Buscamos la Ultima Fecha utilizada
                If MaxDev <> 0 Then
                    dtpFechaDev.Value = w.FuncionConsultaString("FECHADEVOLUCION", "DEVOLUCION", "CODDEVOLUCION", MaxDev)
                End If
            End If

            If Config7 = "No" Then
                cbxIva.Enabled = False
            Else
                cbxIva.Enabled = True
            End If

            CmbMoneda.SelectedValue = CDec(CODMONEDAPRINCIPAL)
            If CmbMoneda.SelectedValue <> Nothing Then
                Cot1FactTextBox.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(CmbMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
            End If

            'CodDevolucionTextBox.Text = MaxDev + 1
            txtNrodeCliente.Focus()
        End If
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 44)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para modificar una devolución", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Dim EstadoDev As Integer = w.FuncionConsultaDecimal("ESTADO", "DEVOLUCION", "CODDEVOLUCION", CodDevolucionTextBox.Text)

            If (EstadoDev = 1) Then
                permiso = PermisoAplicado(UsuCodigo, 254)
                If permiso = 0 Then
                    MessageBox.Show("Usted no tiene permiso para modificar una Devolución Aprobada", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If

            If EstadoDev = 1 Then
                dtpFechaDev.Enabled = True
                txtMotivoDescarte.Enabled = True
                VendendorComboBox.Enabled = True
                cbxRelacionarFactura.Enabled = True
                txtNroFactura.Enabled = True
                BtnAsterisco.Enabled = True
                chbxTratamiento.Enabled = True
                cbxDescontarMonto.Enabled = True
                txtCodigo.Enabled = False
                DetalleDevDataGridView.Enabled = False
            Else
                Habilita()
            End If

            cbxDevOtrosDepositos.Text = "No" : TxtEstado.Text = "3" : cbxTipoItem.Text = "Producto"

            If cbxRelacionarFactura.Text = "No" Then
                Me.txtNroFactura.Text = ""
            Else
                If Not IsDBNull(DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value) Then
                    Dim saldofact As Integer = w.FuncionConsulta("SUM(SALDOCUOTA)", "FACTURACOBRAR", "CODVENTA", DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value)
                    Dim totaldev As Integer = w.FuncionConsulta("SUM(TOTALDEVOLUCION)", "DEVOLUCION", "(ESTADO=1) AND CODVENTA", DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value)
                    Dim importeVenta As Integer = w.FuncionConsulta("TOTALVENTA", "VENTAS", "CODVENTA", DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value)
                    If saldofact <> 0 Then
                        VGSaldo = saldofact
                        SiDEV = 0
                    Else
                        SiDEV = 1
                        VGSaldo = importeVenta - totaldev
                    End If
                End If
            End If

            NroFacturaRelActual = Me.txtNroFactura.Text
            BUSCACLIENTE(txtNrodeCliente.Text)

            If (EstadoDev = 1) Then
                If txtNroFactura.Text <> "" Then 'no puede modificar el cliente si ya tiene una factura relacionada
                    txtNrodeCliente.Enabled = False
                    ClienteComboBox.Enabled = False
                End If
                'Panel2.Enabled = False
            Else
                Panel2.Enabled = True
            End If
        End If
    End Sub

    Private Sub BuscarProductoTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.GotFocus
        If BuscarProductoTextBox.Text = "Buscar..." Then
            BuscarProductoTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProductosDataGridView.Select()
        End If
    End Sub

#End Region


    Private Sub RecorreDetalleDevolucion()
        Dim c As Integer = DetalleDevDataGridView.RowCount
        Dim TotalG As Double = 0
        Dim TotalGravadaG As Double = 0
        Dim TotalExentaG As Double = 0
        Dim CodCodigo, CodProducto As String
        Dim DesProducto As String
        Dim Total, TotalDev As Double
        Dim Iva5, TIva5, Iva10, TIva10, Exenta, TExenta As Double

        TotalDev = 0 : TIva10 = 0 : TIva5 = 0 : TExenta = 0

        For c = 1 To c
            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                CodCodigo = ""
            Else
                CodCodigo = DetalleDevDataGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If
            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) Then
                CodProducto = ""
            Else
                CodProducto = DetalleDevDataGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
            End If

            If CodProducto <> "" Then
                DesProducto = w.FuncionConsultaString("DESPRODUCTO", "PRODUCTOS", "CODPRODUCTO", CodProducto)
                DetalleDevDataGridView.Rows(c - 1).Cells("ProductoGrilla").Value = DesProducto
            End If

            If vgControl = 1 Then
                'Cantidad
                If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                Else
                    DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value = CDbl(FormatNumber(DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value, 2))
                    'CDbl(FormatNumber(Detall
                End If
            End If


            'Total
            Total = CDec(DetalleDevDataGridView.Rows(c - 1).Cells("PrecioNetoGrilla").Value * DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value)
            DetalleDevDataGridView.Rows(c - 1).Cells("PrecioBrutoGrilla").Value = Total
            TotalDev = TotalDev + Total

            'Iva
            If DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 10 Then
                Iva10 = Total / 11
                TIva10 = CDec(TIva10) + CDec(Iva10)
                txtIva10.Text = TIva10
                txtIva10.Text = FormatNumber(txtIva10.Text, 2)
                'TIva5 = 0
            ElseIf DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 5 Then
                Iva5 = Total / 21
                TIva5 = CDec(TIva5) + CDec(Iva5)
                txtIva5.Text = TIva5
                txtIva5.Text = FormatNumber(txtIva5.Text, 2)
                'TIva10 = 0
            ElseIf DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 0 Then
                Exenta = Total
                TExenta = CDec(TExenta) + CDec(Exenta)
                txtExenta.Text = TExenta
                txtExenta.Text = FormatNumber(txtExenta.Text, 2)
            End If

            txtTotalIva.Text = CDec(TIva10) + CDec(TIva5)
            txtTotalIva.Text = FormatNumber(txtTotalIva.Text, 2)

            'Descarte
            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value) Then
            Else
                If DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value = 1 Then
                    DetalleDevDataGridView.Rows(c - 1).Cells("DescartarGrilla").Value = "SI"
                ElseIf DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value = 0 Then
                    DetalleDevDataGridView.Rows(c - 1).Cells("DescartarGrilla").Value = "NO"
                End If
            End If
        Next

        TotalMaskedEdit.Text = TotalDev
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        DEVOLUCIONBindingSource.CancelEdit()
        FechaFiltro()

        Deshabilita()
        Limpiamos()
        TxtEstado.Text = "0"

        If NroFactText.Visible = True Then
            NroFactText.Visible = False
            NroNCLabel.Visible = True

            BtnGuardarP3.Visible = False
            BtnCancelarP3.Visible = False
            BtnNuevoP3.Visible = True
            BtnNuevoP3.Enabled = False
            Me.tsCargarNroFactura.Enabled = False
        End If

        Try
            Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)
        Catch ex As Exception
        End Try
        chxFacturasconSaldoCero.Checked = False

        btnAprobar.Enabled = False
        tsAprobar.Enabled = False
        AccBtNuevo = 0 : SiDEV = 0 : posVenta = -1 : YatengoFact = False
        PintarCeldas()
        pnlProdcutoCodigo.Visible = False
        VentasGroupBox.Visible = False
        ProductosGroupBox.Visible = False
        GroupBoxClientes.Visible = False
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim EstadoDev As Integer = 0

        If DetalleDevDataGridView.RowCount = 0 Then
            MessageBox.Show("Ingrese los detalles de la devolución para guardar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CodDevolucionTextBox.Text = "" Then
            Exit Sub
        End If

        If dtpFechaDev.Text = Nothing Or dtpFechaDev.Text = "" Then
            MessageBox.Show("Ingrese la Fecha para la devolución", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtpFechaDev.Focus()
            Exit Sub
        End If

        If TipoComprobanteComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Elija el Tipo de Comprobante para la devolución", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TipoComprobanteComboBox.Select()
            Exit Sub
        End If

        If ClienteComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Elija el Cliente para la devolución", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClienteComboBox.Select()
            Exit Sub
        End If

        If cbxRelacionarFactura.Text = "Si" Then
            If CodVentaTextBox.Text = "" Then
                MessageBox.Show("Elija la Venta para la devolución", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CodVentaTextBox.Focus()
                Exit Sub
            End If
        End If

        If cbxTipoDevolucion.Text = "" Then
            MessageBox.Show("Elija el Tipo de Devolución", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxTipoDevolucion.Select()
            Exit Sub
        End If

        'SI ESTA APROBADA SE DEBE MODIFICAR ALGUNOS OTROS DATOS
        EstadoDev = w.FuncionConsultaDecimal("ESTADO", "DEVOLUCION", "CODDEVOLUCION", CodDevolucionTextBox.Text)

        'Si esl estado es Aprobado y cambio el nro de factura anterior debemos avisar al usuario si el monto de la devolucion es mayor o menos al nro de factura
        If EstadoDev = 1 And NroFacturaRelActual <> Me.txtNroFactura.Text And Me.txtNroFactura.Text <> "" Then
            MontoFactura = w.FuncionConsulta("SUM(SALDOCUOTA)", "FACTURACOBRAR", "CODVENTA", CodVentaTextBox.Text)

            If MontoFactura < CDec(TotalMaskedEdit.Text) Then
                If MessageBox.Show("El Monto de la Factura es menor al Monto de la Devolución , ¿Desea Continuar?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If

        'Validar
        If cbxRelacionarFactura.Text = "Si" And EstadoDev = 0 Then
            If CDec(TotalMaskedEdit.Text) > VGSaldo Then
                If SiDEV = 1 Then
                    MessageBox.Show("El monto de la Devolución supera al Saldo de la Factura con respecto a Devoluciones Aplicables. El monto de la Devolución puede ser Menor o igual a " & VGSaldo & "", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNroFactura.Focus()
                    Exit Sub
                Else
                    MessageBox.Show("El monto de la Devolución Supera al Saldo de la Factura", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNroFactura.Focus()
                    Exit Sub
                End If
            End If
        ElseIf cbxRelacionarFactura.Text = "No" Then
            txtNroFactura.Text = ""
        End If

        If cbxDescontarMonto.Checked = True Then
            If txtNroFactura.Text = "" Then
                DescontarMonto = 0
            Else
                DescontarMonto = 1
            End If
        Else
            DescontarMonto = 0
        End If

        If chbxTratamiento.Checked = True Then
            tratamiento = 1
        Else
            tratamiento = 0
        End If

        If txtTotalIva.Text = "" Or txtTotalIva.Text = "0,00" Then
            TotalGravada = "0"
        Else
            TotalGravada = txtTotalIva.Text * Math.Round(CDec(Cot1FactTextBox.Text))
            TotalGravada = Funciones.Cadenas.QuitarCad(TotalGravada, ".")
            TotalGravada = Replace(TotalGravada, ",", ".")
        End If


        If txtIva5.Text = "" Or txtIva5.Text = "0,00" Then
            TotalIva5 = "0"
        Else
            TotalIva5 = txtIva5.Text * Math.Round(CDec(Cot1FactTextBox.Text))
            TotalIva5 = Funciones.Cadenas.QuitarCad(TotalIva5, ".")
            TotalIva5 = Replace(TotalIva5, ",", ".")
        End If

        If txtIva10.Text = "" Or txtIva10.Text = "0,00" Then
            TotalIva10 = "0"
        Else
            TotalIva10 = txtIva10.Text * Math.Round(CDec(Cot1FactTextBox.Text))
            TotalIva10 = Funciones.Cadenas.QuitarCad(TotalIva10, ".")
            TotalIva10 = Replace(TotalIva10, ",", ".")
        End If

        If txtExenta.Text = "" Or txtExenta.Text = "0,00" Then
            TotalExenta = "0"
        Else
            TotalExenta = txtExenta.Text * Math.Round(CDec(Cot1FactTextBox.Text))
            TotalExenta = Funciones.Cadenas.QuitarCad(TotalExenta, ".")
            TotalExenta = Replace(TotalExenta, ",", ".")
        End If

        If TotalMaskedEdit.Text = "" Or TotalMaskedEdit.Text = "0,00" Then
            TotalDev = "0"
        Else
            TotalDev = TotalMaskedEdit.Text * Math.Round(CDec(Cot1FactTextBox.Text))
            TotalDev = Funciones.Cadenas.QuitarCad(TotalDev, ".")
            TotalDev = Replace(TotalDev, ",", ".")
        End If

        Cotizacion1 = Cot1FactTextBox.Text
        Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
        Cotizacion1 = Replace(Cotizacion1, ",", ".")

        NumDevolucion = NroNCLabel.Text

        Existe = w.FuncionConsulta("CODDEVOLUCION", "DEVOLUCION", "CODDEVOLUCION", CDec(CodDevolucionTextBox.Text))

        Dim transaction As SqlTransaction = Nothing

        If Existe > 0 Then
            '############################################################################
            'Actualizar la factura. 
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaDevolucion()
                ActualizaDetalleDev()

                myTrans.Commit()

                'sqlc.Close()
                '#####################################################################
                'Cambiar el nro de la Factura una vez que se aprobo la devolucion
                ModificarNroFactura(EstadoDev)
                '#####################################################################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Cancelamos todo :(
            Finally
                sqlc.Close()
            End Try


        Else
            '############################################################################
            'INSERTAR: si el codigo es nuevo inserta

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaDevolucion()
                ActualizaDetalleDev()

                myTrans.Commit()
                DetalleDevDataGridView.Refresh()
            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                sqlc.Close()
            End Try
        End If
        AccBtNuevo = 0
        Me.btnAprobar.Visible = True

        'CREAR PERMISO
        'Despues activamos  la posiblidad de modificar dicho nro de factura
        permiso = PermisoAplicado(UsuCodigo, 43)
        If permiso = 0 Then
            BtnNuevoP3.Enabled = False
            Me.tsCargarNroFactura.Enabled = False
        Else
            If NroNCLabel.Text <> "" Then
                BtnNuevoP3.Visible = True : BtnCancelarP3.Visible = False : BtnGuardarP3.Visible = False
            Else
                BtnNuevoP3.Visible = False : BtnCancelarP3.Visible = False : BtnGuardarP3.Visible = False : Me.tsCargarNroFactura.Enabled = False
            End If
        End If
        TxtEstado.Text = "0"
        cbxTipoItem.Enabled = True : cbxDescontarMonto.Visible = False : chxFacturasconSaldoCero.Checked = False : SiDEV = 0

        Dim CodDev As Integer = Me.CodDevolucionTextBox.Text
        FechaFiltro()
        Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)

        'Buscamos la posicion del registro guardado
        For i = 0 To DevolucionesDataGridView.RowCount - 1
            If DevolucionesDataGridView.Rows(i).Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value = CodDev Then
                DEVOLUCIONBindingSource.Position = i
            End If
        Next

        Try
            Me.DEVOLUCIONDETALLETableAdapter.FillBy(Me.DsDevoluciones.DEVOLUCIONDETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)

        Catch ex As Exception
        End Try


        RecorreDetalleDevolucion()
        Deshabilita()
        PintarCeldas()

    End Sub

    Private Sub ModificarNroFactura(ByVal EstadoDev As Integer)
        'desing by Yolanda Zelaya
        If EstadoDev = 1 And NroFacturaRelActual <> Me.txtNroFactura.Text Then
            'Si esta marcado Descontar Automaticamente del Total , debemos descontar el total de la factura en la tabla FACTURACOBRAR
            Dim VCodVenta, SALDOACTUAL, IMPORTEDEV, Pagado As Integer

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = dtpFechaDev.Text
            Dim Concatenar As String = Concat & " " + hora

            If Me.cbxDescontarMonto.Checked = True Then
                Dim odrDev As SqlDataReader
                Dim MaxCabCobro As Integer = 0

                MaxCabCobro = w.Maximo("CABCOBRO", "VENTASFORMACOBRO")

                MaxCabCobro = MaxCabCobro + 1

                Cotizacion1 = Math.Round(CDec(Cot1FactTextBox.Text))

                TotalDev = TotalMaskedEdit.Text
                TotalDev = Funciones.Cadenas.QuitarCad(TotalDev, ".")
                TotalDev = Replace(TotalDev, ",", ".")

                '####################################################################
                'Si se modifico el nro de factura entonces debemos devolver el saldo a la factura Anterior "NroFacturaRelActual"
                If NroFacturaRelActual <> "" Then
                    VCodVenta = w.FuncionConsultaDecimal("CODVENTA", "VENTAS", "TIPOVENTA < 2 AND NUMVENTA", NroFacturaRelActual)
                    Dim ModalidadPago As String = w.FuncionConsultaString("MODALIDADPAGO", "VENTAS", "CODVENTA", VCodVenta)

                    If VCodVenta <> 0 Then ' Las ventas TIPOVENTA >= 2 No se insertan en FACTURACOBRAR
                        If Not ((ModalidadPago = 0 Or ModalidadPago = 4) And ConfigSaldoContado = "No Generar Saldo") Then ' Si se trata de una factura Contado y la Configuracion de Contado es No Generar Saldo, no debe devolver el monto
                            objCommand.CommandText = "SELECT SALDOCUOTA, IMPORTECUOTA  FROM dbo.FACTURACOBRAR WHERE CODVENTA = " & VCodVenta

                            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                            objCommand.Connection.Open()

                            odrDev = objCommand.ExecuteReader()

                            ser.Abrir(sqlc)

                            sql = ""
                            IMPORTEDEV = CDec(TotalMaskedEdit.Text)
                            If odrDev.HasRows Then
                                Do While odrDev.Read()
                                    If IMPORTEDEV > 0 Then
                                        If IMPORTEDEV < odrDev("IMPORTECUOTA") Then
                                            SALDOACTUAL = (IMPORTEDEV + odrDev("SALDOCUOTA"))
                                            sql = sql + "UPDATE FACTURACOBRAR SET PAGADO = 0 , SALDOCUOTA =  " & SALDOACTUAL & " WHERE CODVENTA = " & VCodVenta & "  "
                                            IMPORTEDEV = IMPORTEDEV - SALDOACTUAL
                                        Else
                                            SALDOACTUAL = odrDev("IMPORTECUOTA")
                                            sql = sql + "UPDATE FACTURACOBRAR SET PAGADO = 0 , SALDOCUOTA =  " & SALDOACTUAL & "   WHERE CODVENTA = " & VCodVenta & "  "
                                            IMPORTEDEV = IMPORTEDEV - odrDev("IMPORTECUOTA")
                                        End If
                                    End If
                                Loop
                            End If
                            Try
                                cmd.CommandText = sql
                                cmd.ExecuteNonQuery()

                            Catch ex As Exception

                            End Try

                            odrDev.Close()
                            objCommand.Dispose()
                        End If
                    End If

                    '##########################################################################################################
                    'Eliminamos en resgistro del movimiento anterior en la tabla Movimiento y VentasFormaCobro
                    conexion = ser.Abrir()
                    ser.Abrir(sqlc)

                    Dim davtafcob As New SqlDataAdapter("Select CODCOBRO, CODVENTA, NROCUOTA, IMPORTE FROM VENTASFORMACOBRO WHERE NUMDEVOLUCION = '" & NroNCLabel.Text & "'", conexion)
                    Dim dtvtafcob As New DataTable
                    davtafcob.Fill(dtvtafcob)
                    Dim drvtafcob As DataRow
                    For i = 0 To dtvtafcob.Rows.Count - 1
                        drvtafcob = dtvtafcob.Rows(i)

                        sql = "DELETE movimientos WHERE id_cobro = " & drvtafcob("CODCOBRO") & ""
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                        sql = ""
                        sql = " DELETE CLIENTESCUENTACORRIENTE WHERE IDTRANSACCION=3 AND CODCOBRO= " & drvtafcob("CODCOBRO") & ""
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()


                        sql = ""
                        sql = "DELETE VENTASFORMACOBRO WHERE CODCOBRO = " & drvtafcob("CODCOBRO")

                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    Next
                End If
                If txtNroFactura.Text <> "" Then '  Si modifico y puso Otra factura
                    '####################################################################
                    'descontamos el saldo de la nueva factura
                    VCodVenta = w.FuncionConsultaDecimal("CODVENTA", "VENTAS", "NUMVENTA", txtNroFactura.Text) ' PARA ASEGURAR PORQUE NO SE HIZO TODAVIA EL FILL PARA REFRESCAR CON LA NUEVAFACTURA
                    Dim MontoFactura As Integer = w.FuncionConsultaDecimal("TOTALVENTA", "VENTAS", "CODVENTA", VCodVenta)

                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc

                    sql = ""
                    Dim IMPORTEACTUAL, SaldoActualizar As Integer
                    Dim saldofact As Integer = w.FuncionConsulta("SUM(SALDOCUOTA)", "FACTURACOBRAR", "CODVENTA", VCodVenta)
                    If saldofact <> 0 Then
                        SiDEV = 0
                    Else
                        SiDEV = 1
                    End If

                    objCommand.CommandText = "SELECT SALDOCUOTA, IMPORTECUOTA,IDFORMACOBRAR, CODNUMEROCUOTA FROM dbo.FACTURACOBRAR WHERE CODVENTA = " & VCodVenta

                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()

                    odrDev = objCommand.ExecuteReader()

                    'ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans

                    sql = ""
                    IMPORTEDEV = CDec(TotalMaskedEdit.Text)
                    If odrDev.HasRows Then
                        Do While odrDev.Read()
                            If IMPORTEDEV > 0 Then
                                SALDOACTUAL = odrDev("SALDOCUOTA")
                                IMPORTEACTUAL = odrDev("IMPORTECUOTA")
                                If SiDEV = 1 Then
                                    SALDOACTUAL = IMPORTEACTUAL
                                End If
                                If SALDOACTUAL <> 0 Then  ' se puso este IF en el caso que SiDEV=0 y por ej. una factura tenga 5 cuotas, 3 pago en efectivo y 2 quiere anular con NC. si no se pone este control igual entra para las 3 primeras cuotas ya saldadas
                                    If IMPORTEDEV < SALDOACTUAL Then ' el IMPORTEDEV es MENOR al Saldo de la Cuota
                                        sql = sql + " INSERT INTO VENTASFORMACOBRO (CODVENTA,CODTIPOCOBRO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOCOBRO,FECHACOBRO,NROCUOTA,NUMDEVOLUCION,CABCOBRO,TIPOCOBRO,AUTORIZADO,FECHAREGISTROCOB,CODCLIENTECAB) " & _
                                           "VALUES (" & VCodVenta & ",5," & CmbMoneda.SelectedValue & "," & Cotizacion1 & "," & IMPORTEDEV & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103)," & _
                                           odrDev("CODNUMEROCUOTA") & ",'" & NumDevolucion & "'," & MaxCabCobro & ",1," & UsuCodigo & ",CONVERT(DATETIME,'" & Concatenar & "',103), " & ClienteComboBox.SelectedValue & ")"

                                        SaldoActualizar = SALDOACTUAL - IMPORTEDEV
                                        IMPORTEDEV = 0
                                        Pagado = 0

                                    Else ' el IMPORTEDEV es Mayor o Igual al Saldo de la Cuota
                                        sql = sql + " INSERT INTO VENTASFORMACOBRO (CODVENTA,CODTIPOCOBRO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOCOBRO,FECHACOBRO,NROCUOTA,NUMDEVOLUCION,CABCOBRO,TIPOCOBRO,AUTORIZADO, FECHAREGISTROCOB, CODCLIENTECAB) " & _
                                           "VALUES (" & VCodVenta & ",5," & CmbMoneda.SelectedValue & "," & Cotizacion1 & "," & SALDOACTUAL & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103)," & _
                                           odrDev("CODNUMEROCUOTA") & ",'" & NumDevolucion & "'," & MaxCabCobro & ",1," & UsuCodigo & ",CONVERT(DATETIME,'" & Concatenar & "',103), " & ClienteComboBox.SelectedValue & ")"

                                        IMPORTEDEV = IMPORTEDEV - SALDOACTUAL
                                        SaldoActualizar = 0
                                        Pagado = 1
                                    End If
                                    If SiDEV = 0 Then ' Si SiDEV=1 eligio una factura de saldo 0, no debe actualizar FACTURACOBRAR
                                        sql = sql + " UPDATE FACTURACOBRAR SET  PAGADO = " & Pagado & " ,SALDOCUOTA =  " & SaldoActualizar & "  WHERE IDFORMACOBRAR = " & odrDev("IDFORMACOBRAR")
                                    End If
                                End If
                            End If
                        Loop
                        sql = sql + " UPDATE DEVOLUCION SET COBRADO =  1, SALDO = 0 WHERE CODDEVOLUCION = " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & "   "

                        Try
                            cmd.CommandText = sql
                            cmd.ExecuteNonQuery()

                            myTrans.Commit()
                        Catch ex As Exception

                        End Try

                        odrDev.Close()
                        objCommand.Dispose()
                    Else 'SI o SI tiene que ser una factura TipoVenta >1
                        Dim consulta As System.String
                        Dim conexion As System.Data.SqlClient.SqlConnection

                        conexion = ser.Abrir()

                        consulta = ""
                        consulta = "UPDATE DEVOLUCION SET COBRADO =  1, SALDO = 0 WHERE CODDEVOLUCION = " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & "   "
                        consulta = consulta + " INSERT INTO VENTASFORMACOBRO (CODVENTA,CODTIPOCOBRO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOCOBRO,FECHACOBRO,NROCUOTA,NUMDEVOLUCION,CABCOBRO,TIPOCOBRO,AUTORIZADO, FECHAREGISTROCOB, CODCLIENTECAB) " & _
                                    "VALUES (" & VCodVenta & ",5," & CmbMoneda.SelectedValue & "," & Cotizacion1 & "," & TotalDev & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103),1,'" & _
                                     NumDevolucion & "'," & MaxCabCobro & ",1," & UsuCodigo & ",CONVERT(DATETIME,'" & Concatenar & "',103)," & ClienteComboBox.SelectedValue & ")"
                        Try
                            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Modificar")
                            Consultas.ConsultaComando(myTrans, consulta)
                            myTrans.Commit()

                        Catch ex As Exception
                            myTrans.Rollback()
                        End Try
                        conexion.Close()
                    End If
                Else ' Tenía antes un nrofactura y ahora no, se devuelve el saldo (igual al importe) a la Devolucion
                    sql = sql + " UPDATE DEVOLUCION SET COBRADO =  0, SALDO = " & CDec(TotalMaskedEdit.Text) & " WHERE CODDEVOLUCION = " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & "   "
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
            End If
        End If
    End Sub

    Private Sub ActualizaDevolucion()
        Dim CodVenta As Integer
        Dim Motivo As String
        Dim CodVendedor, Cobrado As Integer

        Cobrado = DescontarMonto

        If VendendorComboBox.SelectedValue = Nothing Then
            CodVendedor = 0
        Else
            CodVendedor = VendendorComboBox.SelectedValue
        End If

        If cbxRelacionarFactura.Text = "Si" Then
            CodVenta = CodVentaTextBox.Text
        Else
            CodVenta = 0
        End If

        If txtMotivoDescarte.Text = "" Then
            Motivo = " "
        Else
            Motivo = txtMotivoDescarte.Text
        End If

        If Cot1FactTextBox.Text = "" Or Cot1FactTextBox.Text = "0,00" Then
            Cotizacion1 = "1"
        Else
            Cotizacion1 = CDec(Cot1FactTextBox.Text)
            Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
            Cotizacion1 = Replace(Cotizacion1, ",", ".")
        End If

        sql = ""
        sql = "UPDATE DEVOLUCION SET CODCLIENTE=" & ClienteComboBox.SelectedValue & ", CODVENTA=" & CodVenta & ", COBRADO=" & Cobrado & ", " & "CODMONEDA=" & CmbMoneda.SelectedValue & ", " & _
              "FECHADEVOLUCION=CONVERT(DATETIME,'" & dtpFechaDev.Text & "',103), TOTALEXENTA=" & TotalExenta & ", TOTALIVA=" & TotalGravada & ",  MOTIVODESCARTE = '" & Motivo & "'," & _
              "DEVTRATAMIENTO=" & tratamiento & ",TOTALDEVOLUCION=" & TotalDev & ", COTIZACION1=" & Cotizacion1 & ", TOTALIVA5 = " & TotalIva5 & ", TOTALIVA10 = " & TotalIva10 & ", CODCOMPROBANTE = " & TipoComprobanteComboBox.SelectedValue & "," & _
              "CODDEPOSITO= " & CmbDeposito.SelectedValue & ", TIPODEVOLUCION = '" & cbxTipoDevolucion.Text & "', DESCONTARMONTO =" & DescontarMonto & ", CODVENDEDOR = " & CodVendedor & ", CODUSUARIO = " & UsuCodigo & ", SALDO = " & TotalDev & "   " & _
              "WHERE CODDEVOLUCION= " & CDec(CodDevolucionTextBox.Text) & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaDevolucion()
        Dim CodVenta As Integer
        Dim Motivo As String
        Dim CodVendedor As Integer

        If VendendorComboBox.SelectedValue = Nothing Then
            CodVendedor = 0
        Else
            CodVendedor = VendendorComboBox.SelectedValue
        End If

        If cbxRelacionarFactura.Text = "Si" Then
            CodVenta = CodVentaTextBox.Text
        Else
            CodVenta = 0
        End If

        If txtMotivoDescarte.Text = "" Then
            Motivo = " "
        Else
            Motivo = txtMotivoDescarte.Text
        End If

        If Cot1FactTextBox.Text = "" Or Cot1FactTextBox.Text = "0,00" Then
            Cotizacion1 = "1"
        Else
            Cotizacion1 = CDec(Cot1FactTextBox.Text)
            Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
            Cotizacion1 = Replace(Cotizacion1, ",", ".")
        End If

        sql = ""
        sql = "INSERT INTO DEVOLUCION (CODCLIENTE, CODVENTA, CODMONEDA, CODSUCURSAL,FECHADEVOLUCION, TOTALEXENTA, TOTALIVA, TOTALDEVOLUCION, COTIZACION1, " & _
              "TOTALIVA5, TOTALIVA10, FECGRA, CODCOMPROBANTE, COBRADO,CODDEPOSITO, ESTADO,MOTIVODESCARTE, TIPODEVOLUCION,DESCONTARMONTO,CODVENDEDOR,SALDO,DEVTRATAMIENTO,CODUSUARIO) " & _
              "VALUES (" & ClienteComboBox.SelectedValue & ", " & CodVenta & ", " & CmbMoneda.SelectedValue & ", " & SucCodigo & ", " & _
              "CONVERT(DATETIME,'" & dtpFechaDev.Text & "',103), " & TotalExenta & ", " & TotalGravada & ", " & TotalDev & ", " & Cotizacion1 & ", " & TotalIva5 & ", " & TotalIva10 & _
              Cotizacion2 & ", CONVERT(DATETIME,'" & Today & "',103), " & TipoComprobanteComboBox.SelectedValue & ", 0, " & CmbDeposito.SelectedValue & ",0,'" & Motivo & "','" & Me.cbxTipoDevolucion.Text & "'," & _
              DescontarMonto & "," & CodVendedor & "," & TotalDev & "," & tratamiento & "," & UsuCodigo & ")  " & _
              "SELECT CODDEVOLUCION FROM DEVOLUCION WHERE CODDEVOLUCION = SCOPE_IDENTITY();"

        cmd.CommandText = sql
        CodDevolucionTextBox.Text = cmd.ExecuteScalar() 'Este comando necesita si o si el CommandText para poder ejecutarse
    End Sub

    Private Sub ActualizaDetalleDev()
        Dim CodDevolucionDet, CodCodigoDet, CodProductoDet, CantidadDevueltaDet, PrecioNetoDet, IvaDet, DescartarDet, DescripItem, CodVenta As String
        Dim c As Integer = DetalleDevDataGridView.RowCount

        If AccBtNuevo = 1 Then
            CodDevolucionDet = CodDevolucionTextBox.Text
        Else
            CodDevolucionDet = DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value
        End If

        For c = 1 To c
            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                CodCodigoDet = "Null"
            Else
                CodCodigoDet = DetalleDevDataGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) Then
                CodProductoDet = "Null"
            Else
                CodProductoDet = DetalleDevDataGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("ProductoGrilla").Value) Then
                DescripItem = "Null"
            Else
                DescripItem = DetalleDevDataGridView.Rows(c - 1).Cells("ProductoGrilla").Value
                DescripItem = Replace(DescripItem, "'", "''")
            End If

            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CODVENTADataGridViewTextBoxColumn2").Value) Then
                CodVenta = "Null"
            Else
                CodVenta = DetalleDevDataGridView.Rows(c - 1).Cells("CODVENTADataGridViewTextBoxColumn2").Value
            End If

            Try
                If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                    CantidadDevueltaDet = "0"
                Else
                    CantidadDevueltaDet = DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                    CantidadDevueltaDet = Funciones.Cadenas.QuitarCad(CantidadDevueltaDet, ".")
                    CantidadDevueltaDet = Replace(CantidadDevueltaDet, ",", ".")
                End If
            Catch ex As Exception
                CantidadDevueltaDet = "0"
            End Try

            Try
                If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("PrecioNetoGrilla").Value) Then
                    PrecioNetoDet = "0"
                Else
                    PrecioNetoDet = DetalleDevDataGridView.Rows(c - 1).Cells("PrecioNetoGrilla").Value
                    PrecioNetoDet = Funciones.Cadenas.QuitarCad(PrecioNetoDet, ".")
                    PrecioNetoDet = Replace(PrecioNetoDet, ",", ".")
                End If
            Catch ex As Exception
                PrecioNetoDet = "0"
            End Try

            Try
                If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value) Then
                    IvaDet = "0"
                Else
                    IvaDet = DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value
                    IvaDet = Funciones.Cadenas.QuitarCad(IvaDet, ".")
                    IvaDet = Replace(IvaDet, ",", ".")
                End If
            Catch ex As Exception
                IvaDet = "0"
            End Try

            'Descartar
            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value) Then
                DescartarDet = "0"
            Else
                DescartarDet = DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value
            End If

            '#####################################################

            If DetalleDevDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = 2 Then
                sql = ""
                sql = "UPDATE DEVOLUCIONDETALLE SET CODDEVOLUCION = " & CodDevolucionTextBox.Text & ", CODCODIGO= " & CodCodigoDet & ", CODPRODUCTO=" & CodProductoDet & ", CANTIDADDEVUELTA=" & CantidadDevueltaDet & ", " & _
                      "PRECIONETO= " & PrecioNetoDet & ", IVA=" & IvaDet & ",DESCARTAR=" & DescartarDet & ",DESCRIPCION='" & DescripItem & "',CODVENTA=" & CodVenta & "" & _
                      " WHERE CODDEVOLUCION = " & CodDevolucionDet & " and CODDEVOLDET=" & DetalleDevDataGridView.Rows(c - 1).Cells("CODDEVOLDET").Value
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
            '#####################################################
            If DetalleDevDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = 1 Or btduplicar = 1 Then
                sql = ""
                sql = "INSERT INTO DEVOLUCIONDETALLE (CODDEVOLUCION, CODCODIGO, CODPRODUCTO, CANTIDADDEVUELTA, PRECIONETO, IVA,DESCARTAR,DESCRIPCION,CODVENTA) " & _
                      "VALUES(" & CodDevolucionTextBox.Text & ", " & CodCodigoDet & ",  " & CodProductoDet & ", " & CantidadDevueltaDet & ", " & PrecioNetoDet & ", " & _
                      IvaDet & ", " & DescartarDet & ",'" & DescripItem & "'," & CodVenta & ") "
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub DevolucionesDataGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DevolucionesDataGridView.SelectionChanged
        changingselection = True

        'Para saber si ya fue cobrada la nota de credito
        Dim cobrado As Integer

        If CodDevolucionTextBox.Text <> "" Then
            cobrado = w.FuncionConsulta("COBRADO", "DEVOLUCION", "CODDEVOLUCION", CodDevolucionTextBox.Text)

            If cobrado = 0 Then
                Me.tbxSeCobro.Text = "No"
            ElseIf cobrado = 1 Then
                Me.tbxSeCobro.Text = "Si"
            End If
        End If

        If (NroNCLabel.Text = "") Or (NroNCLabel.Text = "Pendiente de Aprob.") Then
            NroNCLabel.Text = "Pendiente de Aprob."
            NroNCLabel.ForeColor = Color.Black
        Else
            NroNCLabel.ForeColor = Color.OrangeRed
        End If

        Dim codzona, CodDep, CodCiu As Integer
        Dim Departamento, Ciudad, Zona As String

        If ClienteComboBox.Text <> "" Then
            txtNrodeCliente.Text = w.FuncionConsultaDecimal("numcliente", "clientes", "codcliente", ClienteComboBox.SelectedValue)
        End If

        'se debe obtner los datos de Departamento, Ciudad y Zona para visualizar en la factura de venta
        If txtNrodeCliente.Text <> "" Then
            Dim CodCliente As Integer

            CodCliente = w.FuncionConsulta("codcliente", "clientes", "numcliente", txtNrodeCliente.Text)
            ClienteComboBox.SelectedValue = CodCliente

            If Config4 = "Mostrar Localizacion del Cliente" Then
                codzona = w.FuncionConsulta("codzona", "clientes", "CAST(codcliente AS VARCHAR)", CodCliente)

                CodDep = w.FuncionConsulta("CODDEPARTAMENTO", "CLIENTES", "codcliente", CodCliente)
                Departamento = w.FuncionConsultaString("DESPAIS", "PAIS", "CODPAIS", CodDep)

                CodCiu = w.FuncionConsulta("CODCIUDAD", "CLIENTES", "codcliente", CodCliente)
                Ciudad = w.FuncionConsultaString("DESCIUDAD", "CIUDAD", "CODCIUDAD", CodCiu)

                Zona = w.FuncionConsultaString("DESZONA", "ZONA", "CODZONA", codzona)

                txtLocalizacion.Text = Departamento + " / " + Ciudad + " / " + Zona

            ElseIf Config4 = "Mostrar Dirección del Cliente" Then
                txtLocalizacionDir.Text = w.FuncionConsultaString("DIRECCION", "CLIENTES", "CODCLIENTE", CodCliente)
            End If

            'crear permiso
            permiso = PermisoAplicado(UsuCodigo, 41)
            If permiso = 0 Then
                BtnNuevoP3.Enabled = False
                BtnNuevoP3.Visible = False
                Me.tsCargarNroFactura.Enabled = False
            Else
                BtnNuevoP3.Enabled = False
                Me.tsCargarNroFactura.Enabled = False
                BtnNuevoP3.Visible = True
                BtnCancelarP3.Visible = False
                BtnGuardarP3.Visible = False
            End If
            Dim venta As String = ""
            If Not IsDBNull(DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value) Then
                venta = DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value
            Else
                venta = 0
            End If
            If IsDBNull(DevolucionesDataGridView.CurrentRow.Cells("CODCLIENTEDataGridViewTextBoxColumn2").Value) Then 'saul
                PanelMotivoAnulacion.BringToFront()
            End If
            If Not IsDBNull(DevolucionesDataGridView.CurrentRow.Cells("DEVTRATAMIENTO").Value) Then
                If DevolucionesDataGridView.CurrentRow.Cells("DEVTRATAMIENTO").Value = 1 Then
                    chbxTratamiento.Checked = True
                Else
                    chbxTratamiento.Checked = False
                End If
            Else
                chbxTratamiento.Checked = False
            End If

            BtnAsterisco.Visible = False
            'Si se enlazo con una factura
            If venta <> 0 Then
                txtNroFactura.Visible = True
                cbxRelacionarFactura.Text = "Si"
                cbxDescontarMonto.Visible = True
                If txtDescontarMotivo.Text <> "" Then
                    If txtDescontarMotivo.Text = 1 Then
                        cbxDescontarMonto.Checked = True
                    Else
                        cbxDescontarMonto.Checked = False
                    End If
                End If
            Else
                txtNroFactura.Visible = False
                cbxRelacionarFactura.Text = "No"
                cbxDescontarMonto.Checked = False
                cbxDescontarMonto.Visible = False
            End If

        Else
            txtNrodeCliente.Text = w.FuncionConsultaDecimal("numcliente", "clientes", "codcliente", ClienteComboBox.SelectedValue)
        End If

        Try
            Me.DEVOLUCIONDETALLETableAdapter.Fill(Me.DsDevoluciones.DEVOLUCIONDETALLE)
            ObternerDatos()
            TxtEstado_TextChanged(Nothing, Nothing)
        Catch ex As Exception
        End Try
        changingselection = False
    End Sub

    Private Sub ObternerDatos()
        Dim c As Integer = DetalleDevDataGridView.RowCount
        Dim TotalG As Double = 0
        Dim TotalGravadaG As Double = 0
        Dim TotalExentaG As Double = 0
        Dim Total, TotalDev As Double
        Dim Iva5, TIva5, Iva10, TIva10, Exenta, TExenta As Double

        TotalDev = 0 : TIva10 = 0 : TIva5 = 0 : TExenta = 0

        For c = 1 To c
            'Total
            Total = DetalleDevDataGridView.Rows(c - 1).Cells("PrecioNetoGrilla").Value * DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
            DetalleDevDataGridView.Rows(c - 1).Cells("PrecioBrutoGrilla").Value = Total
            TotalDev = TotalDev + Total

            'Iva
            If DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 10 Then
                Iva10 = Total / 11
                TIva10 = CDec(TIva10) + CDec(Iva10)
                txtIva10.Text = TIva10
                txtIva10.Text = FormatNumber(txtIva10.Text, 2)
                'TIva5 = 0
            ElseIf DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 5 Then
                Iva5 = Total / 21
                TIva5 = CDec(TIva5) + CDec(Iva5)
                txtIva5.Text = TIva5
                txtIva5.Text = FormatNumber(txtIva5.Text, 2)
                'TIva10 = 0
            ElseIf DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 0 Then
                Exenta = Total
                TExenta = CDec(TExenta) + CDec(Exenta)
                txtExenta.Text = TExenta
                txtExenta.Text = FormatNumber(txtExenta.Text, 2)
            End If

            txtTotalIva.Text = CDec(TIva10) + CDec(TIva5)
            txtTotalIva.Text = FormatNumber(txtTotalIva.Text, 2)

            'Descarte
            If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value) Then
            Else
                If DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value = 1 Then
                    DetalleDevDataGridView.Rows(c - 1).Cells("DescartarGrilla").Value = "SI"
                ElseIf DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value = 0 Then
                    DetalleDevDataGridView.Rows(c - 1).Cells("DescartarGrilla").Value = "NO"
                End If
            End If
        Next
        'TotalMaskedEdit.Text = "0"
        TotalMaskedEdit.Text = TotalDev
        Me.Refresh()
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 45)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para eliminar una devolución", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            ELIMINAR()
            PintarCeldas()
        End If
    End Sub

    Private Sub ELIMINAR()
        If CodDevolucionTextBox.Text = "" Then
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere eliminar la Devolución?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            EliminarDetalleDevolucion()
            EliminaRDevolucion()

            myTrans.Commit()

            Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)
            DEVOLUCIONBindingSource.MoveLast()
            'RecorreCompra()
            RecorreDetalleDevolucion()
            MessageBox.Show("Devolución eliminada correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Deshabilita()

        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch

            End Try
            MessageBox.Show(" La Devolución está siendo utilizado por el Sistema y no se puede Eliminar ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'RecorreCompra()
            RecorreDetalleDevolucion()
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub EliminaRDevolucion()
        sql = ""
        sql = "delete from DEVOLUCION WHERE CODDEVOLUCION = " & CodDevolucionTextBox.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarDetalleDevolucion()
        If DetalleDevDataGridView.RowCount = 0 Then
            Exit Sub
        Else
            sql = ""
            sql = "delete from DEVOLUCIONDETALLE WHERE CODDEVOLUCION = " & CodDevolucionTextBox.Text
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub BuscarDevolucionTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles BuscarDevolucionTextBox.GotFocus
        BuscarDevolucionTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarDevolucionTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles BuscarDevolucionTextBox.LostFocus
        BuscarDevolucionTextBox.BackColor = Color.Tan
    End Sub

    Public Sub BuscarDevolucionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarDevolucionTextBox.TextChanged
        Try
            If BuscarDevolucionTextBox.Text = "" And BuscarDevolucionTextBox.Text <> "Buscar..." Then
                Me.DEVOLUCIONBindingSource.Filter = "NOMBRE LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NUMCLIENTE1 LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NUMDEVOLUCION LIKE '%" & BuscarDevolucionTextBox.Text & "%'"
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(BuscarDevolucionTextBox.Text, "^\d*$") Then ' Si introduce letras
                    Me.DEVOLUCIONBindingSource.Filter = "NOMBRE LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NUMDEVOLUCION LIKE '%" & BuscarDevolucionTextBox.Text & "%'"
                Else
                    Me.DEVOLUCIONBindingSource.Filter = "NOMBRE LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NOMBREFANTASIA LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR DIRECCION LIKE '%" & BuscarDevolucionTextBox.Text & "' OR NUMDEVOLUCION LIKE '%" & BuscarDevolucionTextBox.Text & "%'"
                End If
            End If
            PintarCeldas()
        Catch ex As Exception

        End Try
        'Me.DEVOLUCIONBindingSource.Filter = "NUMCLIENTE  LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NUMDEVOLUCION LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NOMBRE LIKE '%" & BuscarDevolucionTextBox.Text & "%'"
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter, EliminarPictureBox.MouseEnter, CancelarPictureBox.MouseEnter, ModificarPictureBox.MouseEnter, GuardarPictureBox.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub CancelarPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.MouseLeave, NuevoPictureBox.MouseLeave, EliminarPictureBox.MouseLeave, ModificarPictureBox.MouseLeave, GuardarPictureBox.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
        If AddButton.Text = "Agregar" Then
            vgControl = 0

            'validamos que ingrese los datos viteh!!! - No , no vi cheee - Perooooo vo so loooco viteh!!
            If cbxTipoItem.Text <> "Item" Then
                If CodProductoTextBox.Text = "" Then
                    MessageBox.Show("Seleccione un Producto o Combo para el nuevo detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCodigo.Focus()
                    Exit Sub
                End If
            Else
                If cbxIva.Text = "" Then
                    MessageBox.Show("Seleccione el IVA para el Item", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cbxIva.Focus()
                    Exit Sub
                End If
            End If

            If CmbDeposito.Text = "" Then
                MessageBox.Show("Seleccione un Deposito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CmbDeposito.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(CantidadTextBox.Value) Then
                MessageBox.Show("Ingrese la Cantidad Devuelta para el nuevo detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CantidadTextBox.Focus()
                Exit Sub
            ElseIf CDec(CantidadTextBox.Value) = 0 Then
                MessageBox.Show("Ingrese la Cantidad Devuelta mayor a cero para el nuevo detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CantidadTextBox.Focus()
                Exit Sub
            End If

            If cbxRelacionarFactura.Text = "No" Then
                ' If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                CantRealMaskedEdit.Value = 0
                'End If
            Else
                CantRealMaskedEdit.Value = CDec(ProductosDataGridView.CurrentRow.Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) - CDec((CantidadTextBox).Value)
            End If

            Try
                If CDec(CantidadTextBox.Value) <= 0 And cbxRelacionarFactura.Text = "Si" Then
                    MessageBox.Show("La Cantidad Devuelta no puede ser mayor a la Comprada", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CantidadTextBox.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            If cbxDescartar.Text = "NO Sumar al Stock" Then
                Descarte = "0"
                DescSINO = "NO"
            Else
                Descarte = "1"
                DescSINO = "SI"
            End If

            Dim x As Integer = DetalleDevDataGridView.RowCount
            If x >= 1 Then
                If DetalleDevDataGridView.Rows(0).Cells("DescartarGrilla").Value <> DescSINO Then
                    MessageBox.Show("Las condiciones de SUMAR/NO SUMAR al STOCK deben ser iguales para todos los productos en una misma Devolución", "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cbxDescartar.Focus()
                    Exit Sub
                End If
            End If

            For x = 1 To x
                Try
                    If IsDBNull(DetalleDevDataGridView.Rows(x - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                    Else
                        If CodCodigoTextBox.Text = DetalleDevDataGridView.Rows(x - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value Then
                            If MessageBox.Show("El Producto ya se encuentra en el detalle, ¿Desea Agregarlo?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                                CodCodigoTextBox.Text = ""
                                CodProductoTextBox.Text = ""
                                txtCodigo.Focus()
                                Exit Sub
                            Else 'OK
                                Exit For
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next

            'pasamos los datos a la grilla
            DEVOLUCIONDETALLEBindingSource.AddNew()
            Dim c As Integer = DetalleDevDataGridView.RowCount

            If cbxTipoItem.Text = "Item" Then
                DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value = CDec(CantidadTextBox.Text)
                DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = CDec(cbxIva.Text)
                DetalleDevDataGridView.Rows(c - 1).Cells("PrecioNetoGrilla").Value = CDec(txtPrecio.Text)
                DetalleDevDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = 1
                DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value = Descarte
                DetalleDevDataGridView.Rows(c - 1).Cells("ProductoGrilla").Value = Me.txtProductoDescripcion.Text
                If cbxRelacionarFactura.Text = "Si" Then
                    DetalleDevDataGridView.Rows(c - 1).Cells("CODVENTADataGridViewTextBoxColumn2").Value = CodVentaTextBox.Text

                End If

            Else
                DetalleDevDataGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value = CodCodigoTextBox.Text
                DetalleDevDataGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value = CodProductoTextBox.Text
                DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value = CDec(CantidadTextBox.Text)
                DetalleDevDataGridView.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = CDec(cbxIva.Text)
                DetalleDevDataGridView.Rows(c - 1).Cells("PrecioNetoGrilla").Value = CDec(txtPrecio.Text)
                DetalleDevDataGridView.Rows(c - 1).Cells("EstadoGrilla").Value = 1
                DetalleDevDataGridView.Rows(c - 1).Cells("CODIGOPROD").Value = txtCodigo.Text

                If cbxRelacionarFactura.Text = "Si" Then
                    DetalleDevDataGridView.Rows(c - 1).Cells("CODVENTADataGridViewTextBoxColumn2").Value = CodVentaTextBox.Text
                End If
                DetalleDevDataGridView.Rows(c - 1).Cells("DESCARTAR").Value = Descarte
            End If

            RecorreDetalleDevolucion()
            Limpiamos()
            txtCodigo.Focus()
        End If
        '-------------------------------------------------------------SAUL---------------------------------------------------------------------

        If AddButton.Text = "Modificar" Then
            vgControl = 1
            'Dim cant As Integer = CInt(CantRealMaskedEdit.Text)
            'se verifica que los campos principales no esten en blanco
            If (txtCodigo.Text <> "") And (CantidadTextBox.Text <> "") And (txtPrecio.Text <> "") Then
                DetalleDevDataGridView.Rows(vgDevoluciones).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value = CDec(CantidadTextBox.Text)
                CantidadTextBox.BackColor = Control.DefaultBackColor
                DetalleDevDataGridView.Rows(vgDevoluciones).Cells("ProductoGrilla").Value = txtProductoDescripcion.Text
                DetalleDevDataGridView.Rows(vgDevoluciones).Cells("CODIGOPROD").Value = vgCodProducto
                DetalleDevDataGridView.Rows(vgDevoluciones).Cells("CODCODIGODataGridViewTextBoxColumn").Value = vgCodCodigo
                DetalleDevDataGridView.Rows(vgDevoluciones).Cells("CODIGOPROD").Value = txtCodigo.Text
                DetalleDevDataGridView.Rows(vgDevoluciones).Cells("PrecioNetoGrilla").Value = CDec(txtPrecio.Text)
                DetalleDevDataGridView.Rows(vgDevoluciones).Cells("ESTADOGRILLA").Value = "2"

                Dim CalculoTotal As Integer = (DetalleDevDataGridView.Rows(vgDevoluciones).Cells("PrecioNetoGrilla").Value * DetalleDevDataGridView.Rows(vgDevoluciones).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value)
                DetalleDevDataGridView.Rows(vgDevoluciones).Cells("PrecioBrutoGrilla").Value = CalculoTotal

                AddButton.Text = "Agregar" : ElimButton.Text = "Eliminar"
                txtCodigo.Enabled = True

                RecorreDetalleDevolucion()
                Limpiamos()
                txtCodigo.Focus()
                'End If
                'modifDet = 0
            End If
        End If

        '------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub Limpiamos()
        txtCodigo.Text = "" : CantidadTextBox.Text = "" : CodCodigoTextBox.Text = ""
        CodProductoTextBox.Text = "" : IVATextBox.Text = "" : txtProductoDescripcion.Text = ""
        txtPrecio.Text = "" : cbxIva.Text = "" : cbxTipoItem.Text = "Producto"
        'Ahora Una vez que inserto 1 detalle ponemos por defecto el tipo descarte que se inserto primero
        'cbxDescartar.Text = Config1
        If Descarte = "0" Then
            cbxDescartar.Text = "NO Sumar al Stock"
        Else
            cbxDescartar.Text = "Sumar al Stock"
        End If

        CantRealMaskedEdit.Text = Nothing
    End Sub

    Private Sub ElimButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElimButton.Click
        If ElimButton.Text = "Eliminar" Then
            Dim Existe As Integer
            Dim CodigoABorrar As Integer

            If DetalleDevDataGridView.RowCount = 0 Then
                Exit Sub
            End If
            If IsDBNull(DetalleDevDataGridView.CurrentRow) Then
                Exit Sub
            Else
                CodigoABorrar = DetalleDevDataGridView.CurrentRow.Cells("CODDEVOLDET").Value
            End If

            Existe = w.FuncionConsulta("CODDEVOLDET", "DEVOLUCIONDETALLE", "CODDEVOLDET", CodigoABorrar)
            If Existe > 0 Then
                Try
                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc
                    sql = ""
                    sql = "DELETE DEVOLUCIONDETALLE WHERE CODDEVOLDET = " & CodigoABorrar & ""
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    sqlc.Close()
                Catch ex As Exception
                    MessageBox.Show("Error al eliminar el detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
                DEVOLUCIONDETALLETableAdapter.Fill(DsDevoluciones.DEVOLUCIONDETALLE)
            Else
                DetalleDevDataGridView.Rows.Remove(Me.DetalleDevDataGridView.CurrentRow)
            End If

            txtIva10.Text = 0 : txtIva5.Text = 0 : txtExenta.Text = 0 : txtTotalIva.Text = 0
            RecorreDetalleDevolucion()
        End If
        If ElimButton.Text = "Cancelar" Then
            Limpiamos()
            AddButton.Text = "Agregar" : ElimButton.Text = "Eliminar"
            txtCodigo.Enabled = True
            txtCodigo.Focus()
        End If
        'AddButton.Text = "Agregar"
        'ElimButton.Text = "Eliminar"
    End Sub

    Private Sub InicializaFechaFiltro()
        Dim nromes, nroaño As Integer
        Dim fechacompleta1, fechacompleta2, mes As String
        nromes = Today.Month
        nroaño = Today.Year

        CmbAño.Text = nroaño
        CmbMes.SelectedIndex = nromes - 1

        If nromes = 10 Or nromes = 11 Or nromes = 12 Then
            mes = nromes.ToString
        Else
            mes = "0" + nromes.ToString


        End If

        fechacompleta1 = "01" + "/" + mes + "/" + nroaño.ToString
        fechacompleta2 = ""
        If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
            fechacompleta2 = "31" + "/" + mes + "/" + nroaño.ToString

        ElseIf nromes = 2 Or nromes = 4 Or nromes = 6 Or nromes = 7 Or nromes = 9 Or nromes = 11 Then
            If nromes = 2 Then
                If (nroaño - 1992) Mod 4 = 0 Then
                    fechacompleta2 = "29" + "/" + mes + "/" + nroaño.ToString
                Else
                    fechacompleta2 = "28" + "/" + mes + "/" + nroaño.ToString
                End If
            Else
                fechacompleta2 = "30" + "/" + mes + "/" + nroaño.ToString
            End If
        End If
        FechaFiltro1 = CDate(fechacompleta1)
        FechaFiltro2 = CDate(fechacompleta2)
    End Sub

    Private Sub FechaFiltro()
        If CmbMes.Text <> "Filtros" Then
            Dim nromes, nroaño As Integer
            Dim fechacompleta1, fechacompleta2, mes As String
            nromes = CmbMes.SelectedIndex + 1
            nroaño = CInt(CmbAño.Text)

            If nromes = 10 Or nromes = 11 Or nromes = 12 Then
                mes = nromes.ToString
            Else
                mes = "0" + nromes.ToString


            End If

            fechacompleta1 = "01" + "/" + nromes.ToString + "/" + CmbAño.Text
            fechacompleta2 = ""
            If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
                fechacompleta2 = "31" + "/" + nromes.ToString + "/" + CmbAño.Text

            ElseIf nromes = 2 Or nromes = 4 Or nromes = 6 Or nromes = 7 Or nromes = 9 Or nromes = 11 Then
                If nromes = 2 Then
                    If (nroaño - 1992) Mod 4 = 0 Then
                        fechacompleta2 = "29" + "/" + mes.ToString + "/" + nroaño.ToString
                    Else
                        fechacompleta2 = "28" + "/" + mes.ToString + "/" + nroaño.ToString
                    End If
                Else
                    fechacompleta2 = "30" + "/" + mes.ToString + "/" + nroaño.ToString
                End If


            End If
            FechaFiltro1 = CDate(fechacompleta1)
            FechaFiltro2 = CDate(fechacompleta2)
        End If
    End Sub

    Private Sub BtnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Try
            DEVOLUCIONBindingSource.RemoveFilter()

            tsFiltroFechaE.Text = "" : tsFiltroRDesde.Text = "" : tsFiltroRHasta.Text = "" : tsFiltroNroCliente.Text = "" : tsFiltroNomCliente.Text = ""
            Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)
            lblDGVCant.Text = "Cant. de Items:" & DevolucionesDataGridView.RowCount

            txtNrodeCliente.Text = w.FuncionConsultaDecimal("numcliente", "clientes", "codcliente", ClienteComboBox.SelectedValue)
            PintarCeldas()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DescartarComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxDescartar.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxTipoItem.Text = "Producto" Then
                AddButton.Focus()
            Else
                cbxIva.Focus()
            End If
        End If
    End Sub

    Private Sub CodClienteTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ClienteComboBox.Focus()
        End If
    End Sub

    Private Sub MotivoDescarteTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivoDescarte.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxRelacionarFactura.Focus()
            KeyAscii = 0
        End If
    End Sub


#Region "BUSCADOR POR CODIGO, CLIENTE Y FACTURA"
    Private Sub ClienteComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClienteComboBox.SelectedIndexChanged
        Try
            If ClienteComboBox.SelectedValue <> Nothing Then
                'FILL DE LA VENTA PARA QUE SOLO TRAIGA DE ESTE CLIENTE
                VENTASTableAdapter.Fill(DsDevoluciones.VENTAS, ClienteComboBox.SelectedValue)
                txtNrodeCliente.Text = w.FuncionConsultaDecimal("NUMCLIENTE", "CLIENTES", "CODCLIENTE", ClienteComboBox.SelectedValue)
                BUSCACLIENTE(txtNrodeCliente.Text)
            Else
                ' txtNrodeCliente.Text = ""
            End If
        Catch ex As Exception
            ' txtNrodeCliente.Text = ""
        End Try

    End Sub

    Private Sub BUSCACLIENTE(ByVal NroCliente As String)
        Dim CodCliente As Integer
        CodCliente = w.FuncionConsulta("CODCLIENTE", "CLIENTES", "NUMCLIENTE", NroCliente)

        If CodCliente = 0 Then
            ClienteComboBox.Text = " "
            lblNombreFantasia.Visible = False
            lblNombreFantasia.Text = " "
        Else
            ClienteComboBox.SelectedValue = CDec(CodCliente)
            'ClienteComboBox.Text
            CodListaPrecio = w.FuncionConsulta("CODTIPOCLIENTE", "CLIENTES", "CODCLIENTE", CodCliente)
            lblNombreFantasia.Visible = True
            lblNombreFantasia.Text = w.FuncionConsultaString("NOMBREFANTASIA", "CLIENTES", "CODCLIENTE", CodCliente)

            Dim codzona, CodDep, CodCiu As Integer
            Dim Departamento, Ciudad, Zona As String

            'CodCliente = w.FuncionConsulta("codcliente", "clientes", "codcliente", ClienteComboBox.SelectedValue)
            'txtNrodeCliente.Text = w.FuncionConsultaString("numcliente", "clientes", "codcliente", CodCliente)

            If Config4 = "Mostrar Localizacion del Cliente" Then
                codzona = w.FuncionConsulta("codzona", "clientes", "CAST(codcliente AS VARCHAR)", CodCliente)

                CodDep = w.FuncionConsulta("CODDEPARTAMENTO", "CLIENTES", "codcliente", CodCliente)
                Departamento = w.FuncionConsultaString("DESPAIS", "PAIS", "CODPAIS", CodDep)

                CodCiu = w.FuncionConsulta("CODCIUDAD", "CLIENTES", "codcliente", CodCliente)
                Ciudad = w.FuncionConsultaString("DESCIUDAD", "CIUDAD", "CODCIUDAD", CodCiu)

                Zona = w.FuncionConsultaString("DESZONA", "ZONA", "CODZONA", codzona)

                txtLocalizacion.Text = Departamento + " / " + Ciudad + " / " + Zona

            ElseIf Config4 = "Mostrar Dirección del Cliente" Then
                txtLocalizacionDir.Text = w.FuncionConsultaString("DIRECCION", "CLIENTES", "CODCLIENTE", CodCliente)
            End If

        End If
    End Sub

    Private Sub txtNrodeCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNrodeCliente.KeyDown

    End Sub

    Private Sub txtNrodeCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtNrodeCliente.LostFocus
        Dim codvendedor As Decimal

        If txtNrodeCliente.Text <> "" Then
            BUSCACLIENTE(txtNrodeCliente.Text)
            codvendedor = w.FuncionConsulta("codvendedor", "clientes", "codcliente", ClienteComboBox.SelectedValue)
            Try
                VendendorComboBox.SelectedValue = CDec(codvendedor)
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

    Private Sub CodigoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            Dim KeyAscii As Short = Asc(e.KeyChar)
            cbxOtrasListas.Checked = False

            If KeyAscii = 42 Then
                If cbxRelacionarFactura.Text = "Si" Then
                    If CodVentaTextBox.Text <> "" Then
                        If Config5 = "Permitir Cargar otros Items como Detalle" Then
                            GoTo todoslosprod
                        End If
                        Try
                            VENTASDETALLETableAdapter.Fill(DsDevoluciones.VENTASDETALLE, CodVentaTextBox.Text)
                        Catch ex As Exception

                        End Try

                        ProductosGroupBox.Visible = True
                        ProductosGroupBox.BringToFront()
                        BuscarProductoTextBox.Focus()
                        e.Handled = True
                    Else
                        MessageBox.Show("Primero seleccione la Venta para Filtrar los Productos", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtNroFactura.Focus()
                        Exit Sub
                    End If
                Else
todoslosprod:
                    vendermasquestock = permisostockneg
                    If vendermasquestock = 1 Then 'tiene permiso
                        Me.CODIGOTableAdapter.FillBySinStock(DsDevoluciones.CODIGO, CInt(CmbDeposito.SelectedValue), CodListaPrecio)
                        upcProdcutoCodigo.Show()
                        txtBuscarCodigoProducto.Focus()
                    ElseIf vendermasquestock = 0 Then
                        Me.CODIGOTableAdapter.Fill(DsDevoluciones.CODIGO, CInt(CmbDeposito.SelectedValue), CodListaPrecio)
                        upcProdcutoCodigo.Show()
                        txtBuscarCodigoProducto.Focus()
                    End If
                End If
            End If

            If KeyAscii = 0 Then
                e.Handled = True
            End If
            If KeyAscii = 13 Then
                CantidadTextBox.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

#Region "Key Press"
    Private Sub NroDevolucionTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaDev.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub CodVentaTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ' VentaComboBox.Focus()
        End If
    End Sub

    Private Sub FechaDevTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaDev.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtMotivoDescarte.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub NroClienteTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNrodeCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ClienteComboBox.Select()
            KeyAscii = 0
        End If
        If KeyAscii = 42 Then
            upcClientes.Show()
            tbxBuscarCliente.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub NroFacturaTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroFactura.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            BtnAsterisco_Click(Nothing, Nothing)
        End If
        'End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 13 Then
            txtCodigo.Focus()
        End If
    End Sub

#End Region
    Private Sub ImprimirReporte()
        Dim f As New Funciones.Funciones
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.NotaCredito

        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes

        If Config6 = "Papel Continuo" Then
            informe.PrintOptions.PaperSize = GetPapersizeID(impresora, "NCreditoCogent")
        Else
            informe.PrintOptions.PaperSource = PaperSource.Upper 'bandeja
        End If

        informe.SetDataSource(InfFactura())

        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress")
        End Try

        informe.PrintToPrinter(1, False, 0, 0)
    End Sub
    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        Dim s As String = ""
        doctoprint.PrinterSettings.PrinterName = PrinterName '(ex."EpsonSQ-1170ESC/P2")
        For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function
    Public Function InfFactura() As DataSet
        Dim ds As New DsInformes
        ds.Clear()
        Dim diez, cinco, exento, totalcinco, totaldiez, totalexento, total, TotalItems5, TotalItems10, TotalItemsExento As Decimal

        diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0 : TotalItems5 = 0
        TotalItems10 = 0 : TotalItemsExento = 0

        Try
            Dim CantImpresion As Integer
            Dim nronotacredito As String
            nronotacredito = NroNCLabel.Text
            Dim nrofactura As String
            nrofactura = txtNroFactura.Text
            Dim k As Integer = 1
            Dim c As Integer = DetalleDevDataGridView.RowCount()

            CantImpresion = f.FuncionConsultaDecimal("CANTIDADIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)

            Dim dadatosdev As New SqlDataAdapter("SELECT dbo.CLIENTES.NOMBRE, dbo.CLIENTES.DIRECCION, dbo.CLIENTES.TELEFONO, dbo.CLIENTES.CUSTOMFIELD, dbo.CLIENTES.NOMBREFANTASIA, " & _
                         "dbo.DEVOLUCION.MOTIVODESCARTE, SUBSTRING(dbo.VENTAS.NUMVENTA, LEN(dbo.VENTAS.NUMVENTA) - 5, 6) AS NUMVENTA, dbo.ZONA.DESZONA, dbo.VENTAS.FECHAVENTA, dbo.CLIENTES.RUC " & _
            "FROM            dbo.DEVOLUCION LEFT OUTER JOIN " & _
                         "dbo.CLIENTES ON dbo.DEVOLUCION.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN " & _
                         "dbo.ZONA ON dbo.CLIENTES.CODZONA = dbo.ZONA.CODZONA LEFT OUTER JOIN " & _
                         "dbo.VENTAS ON dbo.DEVOLUCION.CODVENTA = dbo.VENTAS.CODVENTA " & _
            "WHERE CODDEVOLUCION=" & CodDevolucionTextBox.Text & "", ser.CadenaConexion)

            Dim dtdatosdev As New DataTable
            dadatosdev.Fill(dtdatosdev)
            Dim drdatosdev As DataRow
            drdatosdev = dtdatosdev.Rows(0)

            If CantImpresion = 0 Then
                CantImpresion = 1
            End If

            For k = 1 To CantImpresion
                For i = 1 To Cantlinea
                    row = ds.Tables("Detalle").NewRow()
                    row.Item("Campo3") = k

                    '########### campos string ##########################################################
                    If i > c Then
                        row.Item("Campo1") = ""
                    Else
                        row.Item("Campo1") = DetalleDevDataGridView.Rows(i - 1).Cells("ProductoGrilla").Value
                    End If

                    If i > c Then
                        row.Item("Campo13") = ""
                    Else
                        row.Item("Campo13") = DetalleDevDataGridView.Rows(i - 1).Cells("CODIGOPROD").Value
                    End If

                    If i = 1 Then
                        row.Item("Campo6") = drdatosdev("RUC")
                        row.Item("Campo4") = drdatosdev("NOMBRE")
                        row.Item("Campo7") = VendendorComboBox.Text
                        row.Item("Campo8") = drdatosdev("DIRECCION")
                        row.Item("Fecha1") = dtpFechaDev.Text
                        row.Item("Campo9") = nronotacredito.Substring(8, nronotacredito.Length - 8) 'drdatoscli("NUMVENTA1")

                        If txtNroFactura.Text Is Nothing Then
                            row.Item("Campo20") = ""
                        Else
                            row.Item("Campo20") = txtNroFactura.Text
                        End If


                        row.Item("Campo5") = drdatosdev("NOMBREFANTASIA")

                        If txtNrodeCliente.Text <> "" Then
                            row.Item("Numero13") = txtNrodeCliente.Text
                        End If

                        row.Item("Campo10") = drdatosdev("DESZONA")
                        row.Item("Campo11") = drdatosdev("TELEFONO")
                        row.Item("Campo12") = drdatosdev("NUMVENTA")
                        row.Item("Campo15") = drdatosdev("CUSTOMFIELD") 'NRO PROVEEDOR
                        'mientras imprimimos fecha de la factura - solo para prueba, luego comentar
                        row.Item("Fecha2") = drdatosdev("FECHAVENTA")
                    End If
                    '#####################################################################################

                    '########### campos numericos ##########################################################

                    If i > c Then
                        ' row.Item("NUMERO1") = Nothing
                    Else
                        row.Item("NUMERO1") = DetalleDevDataGridView.Rows(i - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                    End If

                    If i > c Then
                        'row.Item("NUMERO2") = Nothing
                    Else
                        row.Item("NUMERO2") = DetalleDevDataGridView.Rows(i - 1).Cells("PrecioNetoGrilla").Value
                    End If

                    Dim IVA As Decimal
                    If i > c Then

                    Else
                        IVA = DetalleDevDataGridView.Rows(i - 1).Cells("IVADataGridViewTextBoxColumn").Value

                        If IVA = 10 Then
                            row.Item("NUMERO5") = DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value
                            diez = FormatNumber(DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value / 11, 2)
                            totaldiez = totaldiez + diez
                            total = total + DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value

                            TotalItems10 = TotalItems10 + DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value
                        ElseIf IVA = 0 Then
                            row.Item("NUMERO3") = DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value
                            exento = DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value
                            totalexento = totalexento + exento
                            total = total + DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value

                            TotalItemsExento = TotalItemsExento + DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value
                        ElseIf IVA = 5 Then
                            row.Item("NUMERO4") = DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value
                            cinco = FormatNumber(DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value / 21, 2)
                            totalcinco = totalcinco + cinco
                            total = total + DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value

                            TotalItems5 = TotalItems5 + DetalleDevDataGridView.Rows(i - 1).Cells("PrecioBrutoGrilla").Value
                        End If
                    End If

                    '#####################################################################################

                    row.Item("NUMERO6") = totalcinco
                    row.Item("NUMERO7") = totaldiez
                    row.Item("NUMERO8") = totaldiez + totalcinco
                    row.Item("NUMERO9") = total

                    row.Item("NUMERO11") = TotalItems5
                    row.Item("NUMERO12") = TotalItems10
                    row.Item("NUMERO10") = TotalItemsExento
                    'Guazu
                    row.Item("Campo14") = "                             " & drdatosdev("MOTIVODESCARTE")
                    row.Item("Campo2") = Funciones.Cadenas.NumeroaLetras(total)

                    'If CmbTipVenta.Text = "Crédito" Then
                    '    row.Item("Campo21") = ""
                    '    row.Item("Campo22") = "X"
                    '    row.Item("Campo16") = drdatoscli("DIAS")
                    'Else ' Contado u Otros (Por bonificacion,etc)
                    '    row.Item("Campo21") = "X"
                    '    row.Item("Campo22") = ""
                    '    row.Item("Campo16") = ""
                    'End If


                    ds.Tables("Detalle").Rows.Add(row)
                Next

                diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0
                TotalItems5 = 0 : TotalItems10 = 0 : TotalItemsExento = 0
            Next

        Catch ex As Exception
            MessageBox.Show("Error")
        End Try

        Return ds
    End Function
    Private Sub ImprimirTicket()
        'ds.Clear()
        Dim ticket As New BarControlsCompleto.TicketNotaCredito
        Dim diez, cinco, exento, totalcinco, totaldiez, totalexento, total, TotalItems5, TotalItems10, TotalItemsExento As Decimal
        Dim PBruto, PNeto As Decimal

        diez = 0 : cinco = 0 : exento = 0 : totalcinco = 0 : totaldiez = 0 : totalexento = 0 : total = 0 : TotalItems5 = 0
        TotalItems10 = 0 : TotalItemsExento = 0 : PBruto = 0 : PNeto = 0

        '#########################################################################################################################
        Dim Codigo, DescripcionProducto, Cantidad, Precio, Subtotallinea, IvaTicket, Cliente, DVCliente, TimbradoFactura As String
        Dim Empresa, RucEmpresa, Sucursal, DirSuc, CiudadSuc, TelSuc, FechaValidez As String

        Codigo = "" : DescripcionProducto = "" : Cantidad = "" : Precio = "" : Subtotallinea = "" : IvaTicket = "" : DVCliente = ""
        Empresa = "" : RucEmpresa = "" : Sucursal = "" : DirSuc = "" : CiudadSuc = "" : TelSuc = "" : TimbradoFactura = "" : FechaValidez = ""

        Dim CodCiudad As Integer
        '###################Traer Datos de Sucursal,Empresa y Cliente##############################################################################
        Try
            RucEmpresa = w.FuncionConsultaString2("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)
            DirSuc = w.FuncionConsultaString2("DIRECCION", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            TelSuc = w.FuncionConsultaString2("TELEFONO", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            CodCiudad = w.FuncionConsulta("CODCIUDAD", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            CiudadSuc = w.FuncionConsultaString2("DESCIUDAD", "CIUDAD", "CODCIUDAD", CodCiudad)

            Dim CodigoMaq As Integer
            If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
                CodigoMaq = CodigoMaquina
            Else
                CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
            End If

            TimbradoFactura = w.FuncionConsulta("TIMBRADO", "DETPC", _
                                                "IP=" & CodigoMaq & " " & _
                                                "AND CODSUCURSAL=" & SucCodigo & " AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)

            FechaValidez = w.FuncionConsultaString("FECHAVALIDEZ", "DETPC", _
                                                "IP=" & CodigoMaq & " " & _
                                                "AND CODSUCURSAL=" & SucCodigo & " AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)

            Cliente = ClienteComboBox.Text

            Try
                DVCliente = w.FuncionConsultaString2("RUC", "CLIENTES", "CODCLIENTE", ClienteComboBox.SelectedValue)
            Catch ex As Exception

            End Try

        Catch ex As Exception
        End Try
        '################Cuerpo del Ticket #######################
        'recorta caracteres para centrar

        Empresa = RecortaCaracteres(UCase(EmpNomFantasia))
        Sucursal = RecortaCaracteres(SucDescripcion)
        DirSuc = DirSuc + "-" + CiudadSuc 'RecortaCaracteres(DirSuc + "-" + CiudadSuc)
        RucEmpresa = RecortaCaracteres("RUC:" + RucEmpresa)
        TelSuc = RecortaCaracteres("TEL:" + TelSuc)

        ticket.AddHeaderLine(RecortaCaracteres("* * * * * *"))
        ticket.AddHeaderLine(Empresa)
        ticket.AddHeaderLine(Sucursal)
        ticket.AddHeaderLine(DirSuc)
        ticket.AddHeaderLine(RucEmpresa)
        ticket.AddHeaderLine(TelSuc)
        ticket.AddHeaderLine("================================")
        ticket.AddHeaderLine("NOTA D/CREDITO Nº" + NroNCLabel.Text)
        ticket.AddHeaderLine("TIMBRADO:" + TimbradoFactura)
        ticket.AddHeaderLine("VALIDO HASTA:" + CDate(FechaValidez).ToShortDateString)
        ticket.AddHeaderLine("I.V.A Incluido")

        '##########################################################
        ticket.AddSubHeaderLine("FECHA/HORA:" + dtpFechaDev.Text + " " + DateTime.Now.ToShortTimeString())
        ticket.AddSubHeaderLine("CAJA Nº:" + NumeroCaja + "  " + "CAJERO:" + UsuNombre)
        '##########################################################

        Dim c As Integer = DetalleDevDataGridView.RowCount()
        For i = 1 To c

            DescripcionProducto = DetalleDevDataGridView.Rows(i - 1).Cells("ProductoGrilla").Value
            If DescripcionProducto.Count <= 8 Then
            Else
                DescripcionProducto = DescripcionProducto.Remove(8, DescripcionProducto.Count - 8)
            End If

            'Codigo = DetalleDevDataGridView.Rows(i - 1).Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value
            'If Codigo.Count <= 5 Then
            'Else
            '    Codigo = Codigo.Remove(0, Codigo.Count - 5)
            'End If

            Cantidad = CSng(DetalleDevDataGridView.Rows(i - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value)

            PNeto = DetalleDevDataGridView.Rows(i - 1).Cells("PrecioNetoGrilla").Value
            Precio = PNeto

            PBruto = CDec(Precio) * CDec(Cantidad)
            Subtotallinea = PBruto

            '#####################################################################################
            Dim cantidadcaracteresprecio, cantidadcarecteressubtotallinea As Integer

            cantidadcaracteresprecio = Precio.Count - 4
            cantidadcarecteressubtotallinea = Subtotallinea.Count - 5

            If cantidadcaracteresprecio = 0 Then
                Precio = Precio.Remove(Precio.Count - 3, 3)
            Else
                Precio = Precio.Remove(Precio.Count - 4, 3)
            End If

            If cantidadcarecteressubtotallinea = 0 Then
                Subtotallinea = Subtotallinea.Remove(Subtotallinea.Count - 3, 3)
            Else
                Subtotallinea = Subtotallinea.Remove(Subtotallinea.Count - 4, 3)
            End If

            Precio = Replace(Precio, ".", "")
            Precio = FormatNumber(Precio, 0)
            Subtotallinea = Replace(Subtotallinea, ".", "")
            Subtotallinea = FormatNumber(Subtotallinea, 0)

            ticket.AddItem(DescripcionProducto.PadLeft(8) & " " + Cantidad.PadLeft(3), "", Precio.PadLeft(7) & " " & Subtotallinea.PadLeft(8))
        Next

        Dim numero As System.Decimal
        Dim mascara As System.String

        Dim TotalNC, TotalGB, TotalEX As Decimal

        mascara = "######0.0###"

        If Decimal.TryParse(TotalMaskedEdit.Text, numero) Then
            TotalNC = TotalMaskedEdit.Text
            TotalNC = Replace(TotalNC, ",", ".")
        Else
            TotalNC = "0"
        End If

        If Decimal.TryParse(txtTotalIva.Text, numero) Then
            TotalGB = txtTotalIva.Text
            '  TotalGB = Replace(TotalGB, ",", ".")
        Else
            TotalGB = "0"
        End If

        If Decimal.TryParse(txtExenta.Text, numero) Then
            TotalEX = txtExenta.Text
            TotalEX = Replace(TotalEX, ",", ".")
        Else
            TotalEX = "0"
        End If
        '##########################################################
        'TotalNC = Replace(TotalNC, ".", ",")
        'TotalGB = Replace(TotalGB, ".", ",")
        'TotalEX = Replace(TotalEX, ".", ",")

        ticket.AddTotal("       TOTAL DEVOLUCION :", FormatNumber(TotalMaskedEdit.Text, 0))
        ticket.AddTotal("", "")
        ticket.AddTotal("===============================", "=")

        ticket.AddTotal("TOTAL IVA Gs.    :", FormatNumber(TotalGB, 2))
        ticket.AddTotal("TOTAL EXENTAS GS.:", FormatNumber(TotalEX, 2))
        ticket.AddTotal("===============================", "=")
        '##########################################################
        ticket.AddFooterLine("CANTIDAD DE ARTICULOS:" + c.ToString)
        ticket.AddFooterLine("RUC CLIENTE:" + DVCliente)
        ticket.AddFooterLine("CLIENTE:" + ClienteComboBox.Text)
        ticket.AddFooterLine("")
        ticket.AddFooterLine("================================")

        ticket.PrintTicket(impresora)
    End Sub

    Public Function RecortaCaracteres(ByVal caracter As String, _
        Optional ByVal longitud As Integer = 32) As String
        Select Case Len(caracter)
            Case Is > longitud
                caracter = caracter.Substring(0, 35)
            Case Is < longitud
                Dim longitudEspacio As Integer
                longitudEspacio = ((longitud - Len(caracter)) / 2) + Len(caracter)
                caracter = caracter.PadLeft(longitudEspacio)
        End Select

        Return caracter
    End Function

    Public Function RecortaCaracteres2(ByVal caracter As String, _
      Optional ByVal longitud As Integer = 14) As String
        Select Case Len(caracter)
            Case Is > longitud
                caracter = caracter.Substring(0, 14)
            Case Is < longitud
                Dim longitudEspacio As Integer
                longitudEspacio = ((longitud - Len(caracter)) / 2) + Len(caracter)
                caracter = caracter.PadLeft(longitudEspacio)
        End Select

        Return caracter
    End Function

    Private Sub ActualizaRango()
        Dim f As New Funciones.Funciones
        Dim Ultimo, IDRANGO As Integer
        Dim CodigoMaq As Integer
        CodigoMaq = CodigoMaquina

        IDRANGO = w.FuncionConsulta("RANDOID", "DETPC", "ACTIVO=1 AND IP = " & CodigoMaq & " AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
        Ultimo = w.FuncionConsulta("ULTIMO", "DETPC", "RANDOID", IDRANGO)
        Ultimo = Ultimo + 1

        sql = ""
        sql = "UPDATE DETPC SET ULTIMO = " & Ultimo & " where RANDOID = " & IDRANGO & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub GeneraTimbrado()
        Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango, NroRango2 As String
        Dim NroDigitos, IDRango As Integer
        Dim CodigoMaq As Integer

        CodigoMaq = CodigoMaquina : NumSucursal = SucCodigo
        IDRango = w.FuncionConsulta("RANDOID", "DETPC", "ACTIVO=1 AND IP = " & CodigoMaq & " AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
        NroDigitos = f.FuncionConsultaDecimal("NRODIGITOS", "DETPC", "ACTIVO = 1 AND RANDOID", IDRAngo)

        NumMaquina = w.FuncionConsultaString("NUMMAQUINA", "PC", "IP", CodigoMaq)
        NumSucTimbrado = w.FuncionConsultaString("SUCURSALTIMBRADO", "SUCURSAL", "CODSUCURSAL", NumSucursal)

        NroRango = w.FuncionConsulta("ULTIMO", "DETPC", "RANDOID", IDRango)
        NroRango = NroRango + 1
        NroRango2 = w.FuncionConsulta("RANGO2", "DETPC", "RANDOID", IDRango)

        If CDec(NroRango) > CDec(NroRango2) Then
            MessageBox.Show("El Comprobante " + TipoComprobanteComboBox.Text + " no tiene mas Rango. " + Chr(13) + "Cierre esta ventana y cárguelo en (Dashboard >> Configuración >> 'Rangos de Comprobantes')", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        For i = 1 To 7
            If Len(NroRango) = 7 Then
                Exit For
            Else
                NroRango = "0" & NroRango
            End If
        Next

        NumDevolucion = NumSucTimbrado & "." & NumMaquina & "." & NroRango
        NroNCLabel.Text = NumDevolucion
    End Sub

    Private Sub TipoComprobanteComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TipoComprobanteComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxTipoDevolucion.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub TipoComprobanteComboBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TipoComprobanteComboBox.Validated
        Dim w As New Funciones.Funciones
        Dim hastanro, ultimo As Integer
        Dim Fecha As String

        If TipoComprobanteComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Especifique el comprobante para poder seguir", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TipoComprobanteComboBox.Focus()
            Exit Sub
        End If

        Dim CodigoMaq, CodSuc As Integer
        If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
            CodigoMaq = CodigoMaquina
            CodSuc = SucCodigo
        Else
            CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
            CodSuc = Dashboard.Cmb_Sucursal.SelectedValue
        End If

        Fecha = w.FuncionConsultaString("FECHAVALIDEZ", "DETPC", "CODCOMPROBANTE=" & TipoComprobanteComboBox.SelectedValue & " " & _
                                  "and CODEMPRESA=" & EmpCodigo & " AND ACTIVO=1 AND IP=" & CodigoMaq & " AND CODSUCURSAL", CodSuc)

        hastanro = w.FuncionConsulta("RANGO2", "DETPC", "CODCOMPROBANTE=" & TipoComprobanteComboBox.SelectedValue & " " & _
                                  "and CODEMPRESA=" & EmpCodigo & "AND ACTIVO=1 AND IP=" & CodigoMaq & " AND CODSUCURSAL", CodSuc)
        ultimo = w.FuncionConsulta("ULTIMO", "DETPC", "CODCOMPROBANTE=" & TipoComprobanteComboBox.SelectedValue & " " & _
                                 "and CODEMPRESA=" & EmpCodigo & " AND ACTIVO=1 AND IP=" & CodigoMaq & " AND CODSUCURSAL", CodSuc)
        If Fecha = Nothing Then
            MessageBox.Show("El Comprobante no posee Fecha de Validez", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TipoComprobanteComboBox.Focus()
            Exit Sub
        End If

        If Today > CDate(Fecha) Then
            MessageBox.Show("El Comprobante ya ha superado su Fecha de Validez", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TipoComprobanteComboBox.Focus()
            Exit Sub
        End If

        If hastanro = ultimo Then
            MessageBox.Show("El Comprobante ya Alzanzó su Último Nro", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TipoComprobanteComboBox.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TxtEstado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEstado.TextChanged

        If TxtEstado.Text = "0" Then
            LblEstado.Text = "Pendiente"
            LblEstado.ForeColor = Color.Black

            PanelMotivoAnulacion.Visible = False

            GuardarPictureBox.Enabled = False
            tsGuardar.Enabled = False
            GuardarPictureBox.Image = My.Resources.SaveOff
            GuardarPictureBox.Cursor = Cursors.Arrow
            CancelarPictureBox.Enabled = False
            tsCancelar.Enabled = False
            CancelarPictureBox.Image = My.Resources.SaveCancelOff
            CancelarPictureBox.Cursor = Cursors.Arrow
            tsCambiarIngresoMerc.Enabled = False

            NuevoPictureBox.Enabled = True
            tsNuevaDevoluc.Enabled = True
            NuevoPictureBox.Image = My.Resources.New_
            NuevoPictureBox.Cursor = Cursors.Hand
            EliminarPictureBox.Enabled = True
            tsEliminar.Enabled = True
            EliminarPictureBox.Image = My.Resources.Delete
            EliminarPictureBox.Cursor = Cursors.Hand
            ModificarPictureBox.Enabled = True
            tsEditar.Enabled = False
            ModificarPictureBox.Image = My.Resources.Edit
            ModificarPictureBox.Cursor = Cursors.Hand

            BtnNuevoP3.Enabled = False
            Me.tsCargarNroFactura.Enabled = False

            btnAprobar.Enabled = True
            tsAprobar.Enabled = True
            btnAprobar.Image = My.Resources.Approve
            btnAprobar.Cursor = Cursors.Hand
            btnAnular.Enabled = False
            tsAnular.Enabled = False
            btnAnular.Image = My.Resources.AnullOff
            btnAnular.Cursor = Cursors.Arrow

        ElseIf TxtEstado.Text = "1" Then
            LblEstado.Text = "Aprobado"
            LblEstado.ForeColor = Color.YellowGreen

            NuevoPictureBox.Enabled = True
            tsNuevaDevoluc.Enabled = True
            NuevoPictureBox.Image = My.Resources.New_
            NuevoPictureBox.Cursor = Cursors.Hand
            tsCambiarIngresoMerc.Enabled = True

            EliminarPictureBox.Enabled = False
            tsEliminar.Enabled = False
            EliminarPictureBox.Image = My.Resources.DeleteOff
            EliminarPictureBox.Cursor = Cursors.Arrow
            ModificarPictureBox.Enabled = True
            tsEditar.Enabled = True
            ModificarPictureBox.Image = My.Resources.Edit
            ModificarPictureBox.Cursor = Cursors.Arrow
            btnAprobar.Enabled = False
            tsAprobar.Enabled = False
            btnAprobar.Image = My.Resources.ApproveOff
            btnAprobar.Cursor = Cursors.Arrow

            BtnNuevoP3.Enabled = False
            Me.tsCargarNroFactura.Enabled = False

            btnAnular.Enabled = True
            tsAnular.Enabled = True
            btnAnular.Image = My.Resources.Anull
            btnAnular.Cursor = Cursors.Hand

            PanelMotivoAnulacion.Visible = False
            btnGuardarConceptoAnul.Visible = False
            TxtMotivodeAnulacion.Enabled = True
            BtnAnularMotivo.Enabled = True

        ElseIf TxtEstado.Text = "2" Then
            LblEstado.Text = "Anulado"
            LblEstado.ForeColor = Color.Maroon

            PanelMotivoAnulacion.Visible = True
            NuevoPictureBox.Enabled = True
            tsNuevaDevoluc.Enabled = True
            NuevoPictureBox.Image = My.Resources.New_
            NuevoPictureBox.Cursor = Cursors.Hand
            tsCambiarIngresoMerc.Enabled = False

            EliminarPictureBox.Enabled = False
            tsEliminar.Enabled = False
            EliminarPictureBox.Image = My.Resources.DeleteOff
            EliminarPictureBox.Cursor = Cursors.Arrow
            ModificarPictureBox.Enabled = False
            tsEditar.Enabled = False
            ModificarPictureBox.Image = My.Resources.EditOff
            ModificarPictureBox.Cursor = Cursors.Arrow
            btnAprobar.Enabled = False
            tsAprobar.Enabled = False
            btnAprobar.Image = My.Resources.ApproveOff
            btnAprobar.Cursor = Cursors.Arrow

            BtnNuevoP3.Enabled = False
            Me.tsCargarNroFactura.Enabled = False

            btnAnular.Enabled = False
            tsAnular.Enabled = False
            btnAnular.Image = My.Resources.AnullOff
            btnAnular.Cursor = Cursors.Arrow

            PanelMotivoAnulacion.Visible = True
            PanelMotivoAnulacion.BringToFront()

            If ClienteComboBox.Text = "" Then
                TxtMotivodeAnulacion.Enabled = True
                btnGuardarConceptoAnul.Visible = True
                btnGuardarConceptoAnul.Enabled = True
                btnGuardarConceptoAnul.BringToFront()
            Else
                TxtMotivodeAnulacion.Enabled = False
                BtnAnularMotivo.Enabled = False
                BtnAnularMotivo.BringToFront()
                btnGuardarConceptoAnul.Visible = False
            End If

        ElseIf TxtEstado.Text = "3" Then
            LblEstado.Text = "Para Editar"
            LblEstado.ForeColor = Color.Black

            PanelMotivoAnulacion.Visible = False

            GuardarPictureBox.Enabled = True
            tsGuardar.Enabled = True
            GuardarPictureBox.Image = My.Resources.Save
            GuardarPictureBox.Cursor = Cursors.Hand
            CancelarPictureBox.Enabled = True
            tsCancelar.Enabled = True
            CancelarPictureBox.Image = My.Resources.SaveCancel
            CancelarPictureBox.Cursor = Cursors.Hand
            tsCambiarIngresoMerc.Enabled = False

            NuevoPictureBox.Enabled = False
            tsNuevaDevoluc.Enabled = False
            NuevoPictureBox.Image = My.Resources.NewOff
            NuevoPictureBox.Cursor = Cursors.Arrow
            EliminarPictureBox.Enabled = False
            tsEliminar.Enabled = False
            EliminarPictureBox.Image = My.Resources.DeleteOff
            EliminarPictureBox.Cursor = Cursors.Arrow
            ModificarPictureBox.Enabled = False
            tsEditar.Enabled = False
            ModificarPictureBox.Image = My.Resources.EditOff
            ModificarPictureBox.Cursor = Cursors.Arrow

            btnAprobar.Enabled = False
            tsAprobar.Enabled = False
            btnAprobar.Image = My.Resources.ApproveOff
            btnAprobar.Cursor = Cursors.Arrow
            btnAnular.Enabled = False
            tsAnular.Enabled = False
            btnAnular.Image = My.Resources.AnullOff
            btnAnular.Cursor = Cursors.Arrow

            'CREAR PERMISO
            permiso = PermisoAplicado(UsuCodigo, 46)
            If permiso = 0 Then
                BtnNuevoP3.Enabled = False
                Me.tsCargarNroFactura.Enabled = False
            Else
                BtnNuevoP3.Enabled = True
                BtnNuevoP3.Visible = True
                Me.tsCargarNroFactura.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        permiso = PermisoAplicado(UsuCodigo, 46)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Aprobar la Devolución", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            'Al aprobar la facura se debe general el nro de comprobante y descontar el stock
            Dim imprimirfact As Integer

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            '----------- GENERA Y ACTUALIZA EL RANGO DE COMPROBANTE Y PONE COMO APROBADO LA DEVOLUCION
            Try
                GeneraTimbrado()

                If NumDevolucion = "" Then
                    MessageBox.Show("Verifique el Rango del Comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    sqlc.Close()
                    Exit Sub

                ElseIf NumDevolucion = "Pendiente de Aprob." Then
                    sqlc.Close()
                    Exit Sub
                End If

                ActualizaRango()
                Aprobar()

                myTrans.Commit()
            Catch ex As Exception
                myTrans.Rollback()
                Exit Sub
            End Try
            sqlc.Close()

            '---------------------------- IMPRIMIMOS ----------------------------
            Try
                Dim ValorFiscal As Integer = ValorFiscal = w.FuncionConsulta("VALORFISCAL", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                Dim CodigoMaq, CodSuc, IDRango As Integer
                CodigoMaq = CodigoMaquina : CodSuc = SucCodigo

                IDRango = w.FuncionConsulta("RANDOID", "DETPC", "ACTIVO=1 AND IP = " & CodigoMaq & " AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                tipoimpresion = w.FuncionConsulta("FORMAIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                Cantlinea = w.FuncionConsulta("NROLINEASDETALLE", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                imprimirfact = w.FuncionConsulta("IMPRIMIR", "DETPC", "RANDOID", IDRango)
                impresora = f.FuncionConsultaString("IMPRESORA", "DETPC", "RANDOID", IDRango)

                'se verifica el tipo de impresion para el tipo de comprobante actuamente seleccionado y de acuerdo a eso realizamos la impresion correspondiente
                'en caso de que este marcado la opcion de imprimir en la ventana "Rango de Comprobantes" 

                If tipoimpresion = 0 Then   'Formato Ticket
                    If imprimirfact = 1 Then 'Se imprime
                        ImprimirTicket()
                    End If
                ElseIf tipoimpresion = 1 Then 'Formato Impresora
                    If imprimirfact = 1 Then 'Se imprime
                        ImprimirReporte()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Error al imprimir, no existe la impresora ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = dtpFechaDev.Text
            Dim Concatenar As String = Concat & " " + hora

            NumDevolucion = NroNCLabel.Text

            '----------------- ACTUALIZAMOS STOCK Y MOVIMIENTO DE PRODUCTOS -----------------------------
            Dim cc As Integer = DetalleDevDataGridView.RowCount
            Dim CodProductoDev, CodCodigo, CantidadDev, Precio As String
            Dim existe As Integer

            For cc = 0 To cc - 1
                Dim DescartarStock As String
                DescartarStock = DetalleDevDataGridView.Rows(cc).Cells("DescartarGrilla").Value

                'verificamos si existe o no el producto para saber si modificamos o insertamos
                If DescartarStock = "SI" Then
                    CodProductoDev = DetalleDevDataGridView.Rows(cc).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                    If IsDBNull(DetalleDevDataGridView.Rows(cc).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                        CodCodigo = "NULL"
                    Else
                        CodCodigo = DetalleDevDataGridView.Rows(cc).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                    End If
                    If IsDBNull(DetalleDevDataGridView.Rows(cc).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                        CantidadDev = "NULL"
                    Else
                        CantidadDev = DetalleDevDataGridView.Rows(cc).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                        CantidadDev = Replace(CantidadDev, ",", ".")
                    End If
                    If IsDBNull(DetalleDevDataGridView.Rows(cc).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                        Precio = "NULL"
                    Else
                        Precio = DetalleDevDataGridView.Rows(cc).Cells("PrecioNetoGrilla").Value
                        Precio = Replace(Precio, ",", ".")
                    End If

                    existe = w.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO = " & CodProductoDev & " AND CODCODIGO=" & CodCodigo & " AND CODDEPOSITO", CmbDeposito.SelectedValue)

                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    Try
                        sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,STOCK) " & _
                        "VALUES(" & UsuCodigo & "," & CodCodigo & "," & CmbDeposito.SelectedValue & ",CONVERT(Datetime,'" & Concatenar & "',103),11," & CodDevolucionTextBox.Text & _
                        "," & CantidadDev & "," & Precio & ",'Devolucion de Venta Nro " & NroNCLabel.Text & "',0,1)"

                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                        myTrans.Commit()
                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Actualizar")
                        Catch
                        End Try
                        MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    sqlc.Close()
                End If
            Next

            Dim VCodVenta As Integer
            Dim MaxCabCobro As Integer = 0

            MaxCabCobro = w.Maximo("CABCOBRO", "VENTASFORMACOBRO")
            MaxCabCobro = MaxCabCobro + 1

            Cotizacion1 = Cot1FactTextBox.Text
            Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
            Cotizacion1 = Replace(Cotizacion1, ",", ".")

            TotalDev = TotalMaskedEdit.Text
            TotalDev = Funciones.Cadenas.QuitarCad(TotalDev, ".")
            TotalDev = Replace(TotalDev, ",", ".")

            '------------------------------------------------------------------- CONTABILIDAD --------------------------------------------------------
            'Obtenemos los valores que se utilizaron el modulo de contabilidad - by Yolanda Zelaya 
            Dim ConceptoAsiento, Timbrado, IVA5, IVA10, IVAEXE, TOTALIVA, ClienteProveedor, TOTALVENTACONT As String
            Dim RgMerc, RgMonet As Integer

            IVA5 = CDec(txtIva5.Text) * CDec(Cot1FactTextBox.Text)
            IVA10 = txtIva10.Text * CDec(Cot1FactTextBox.Text)
            IVAEXE = txtExenta.Text * CDec(Cot1FactTextBox.Text)
            TOTALIVA = CDec(IVA5) + CDec(IVA10)
            TOTALVENTACONT = CDec(TotalMaskedEdit.Text) * CDec(Cot1FactTextBox.Text)
            ClienteProveedor = ClienteComboBox.SelectedValue


            RgMonet = 3
            RgMerc = 1

            Timbrado = f.FuncionConsulta("TIMBRADO", "DETPC", "ACTIVO = 1 AND RANDOID", TipoComprobanteComboBox.SelectedValue)
            Cotizacion1 = CDec(Cot1FactTextBox.Text)

            ConceptoAsiento = "Nota de Crédito / " & ClienteComboBox.Text
            ReglaContable(IVAEXE, IVA5, IVA10, TOTALIVA, "DEVOLUCION", CDec(Me.CodDevolucionTextBox.Text), "CODDEVOLUCION", ConceptoAsiento, RgMerc, RgMonet, _
                      CmbMoneda.SelectedValue, Cotizacion1, NumDevolucion, dtpFechaDev.Text, TOTALVENTACONT, "11", Timbrado, ClienteProveedor, SucCodigo)

            '-------------------------------------------------------------------------------------------------------------------------------------------

            'Obtenemos todos los registro del mismo codigo de factura
            VCodVenta = w.FuncionConsultaDecimal("CODVENTA", "DEVOLUCION", "CODDEVOLUCION", DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)


            'Si esta marcado Descontar Automaticamente del Total , debemos descontar el total de la factura en la tabla FACTURACOBRAR

            If Me.txtDescontarMotivo.Text = "1" Then
                Dim SALDOACTUAL, IMPORTEDEV, PAGADO, IMPORTEACTUAL As Integer
                Dim SaldoActualizar As Integer

                objCommand.CommandText = "SELECT SALDOCUOTA, IMPORTECUOTA,IDFORMACOBRAR, CODNUMEROCUOTA  FROM dbo.FACTURACOBRAR WHERE CODVENTA = " & VCodVenta

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrDev As SqlDataReader = objCommand.ExecuteReader()

                If cbxRelacionarFactura.Text = "Si" Then
                    If Not IsDBNull(DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value) Then
                        Dim saldofact As Integer = w.FuncionConsulta("SUM(SALDOCUOTA)", "FACTURACOBRAR", "CODVENTA", DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value)
                        If saldofact <> 0 Then
                            SiDEV = 0
                        Else
                            SiDEV = 1
                        End If
                    End If
                End If

                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                cmd.Connection = sqlc
                cmd.Transaction = myTrans

                sql = ""
                IMPORTEDEV = CDec(TotalMaskedEdit.Text)
                If odrDev.HasRows Then
                    Do While odrDev.Read()
                        Dim NroRecibo As String = Me.txtNroFactura.Text
                        Try
                            NroRecibo = NroRecibo.Substring(10, 4)
                        Catch ex As Exception
                        End Try

                        If IMPORTEDEV > 0 Then
                            SALDOACTUAL = odrDev("SALDOCUOTA")
                            IMPORTEACTUAL = odrDev("IMPORTECUOTA")
                            If SiDEV = 1 Then
                                SALDOACTUAL = IMPORTEACTUAL
                            End If
                            If SALDOACTUAL <> 0 Then  ' se puso este IF en el caso que SiDEV=0 y por ej. una factura tenga 5 cuotas, 3 pago en efectivo y 2 quiere anular con NC. si no se pone este control igual entra para las 3 primeras cuotas ya saldadas
                                If IMPORTEDEV < SALDOACTUAL Then ' el IMPORTEDEV es MENOR al Saldo de la Cuota
                                    sql = sql + " INSERT INTO VENTASFORMACOBRO (CODVENTA,CODTIPOCOBRO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOCOBRO,FECHACOBRO,NROCUOTA,NUMDEVOLUCION,CABCOBRO,TIPOCOBRO,AUTORIZADO, FECHAREGISTROCOB, CODCLIENTECAB,NRORECIBO) " & _
                                       "VALUES (" & VCodVenta & ",5," & CmbMoneda.SelectedValue & "," & Cotizacion1 & "," & IMPORTEDEV & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103)," & _
                                       odrDev("CODNUMEROCUOTA") & ",'" & NumDevolucion & "'," & MaxCabCobro & ",1," & UsuCodigo & ", CONVERT(DATETIME,'" & Concatenar & "',103), " & ClienteComboBox.SelectedValue & ",'" & NroRecibo & "')"

                                    SaldoActualizar = SALDOACTUAL - IMPORTEDEV
                                    IMPORTEDEV = 0
                                    PAGADO = 0

                                Else ' el IMPORTEDEV es Mayor o Igual al Saldo de la Cuota
                                    sql = sql + " INSERT INTO VENTASFORMACOBRO (CODVENTA,CODTIPOCOBRO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOCOBRO,FECHACOBRO,NROCUOTA,NUMDEVOLUCION,CABCOBRO,TIPOCOBRO,AUTORIZADO, FECHAREGISTROCOB, CODCLIENTECAB,NRORECIBO) " & _
                                       "VALUES (" & VCodVenta & ",5," & CmbMoneda.SelectedValue & ",'" & Cotizacion1 & "'," & SALDOACTUAL & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103)," & _
                                       odrDev("CODNUMEROCUOTA") & ",'" & NumDevolucion & "'," & MaxCabCobro & ",1," & UsuCodigo & ", CONVERT(DATETIME,'" & Concatenar & "',103), " & ClienteComboBox.SelectedValue & ",'" & NroRecibo & "')"

                                    IMPORTEDEV = IMPORTEDEV - SALDOACTUAL
                                    SaldoActualizar = 0
                                    PAGADO = 1
                                End If
                                If SiDEV = 0 Then ' Si SiDEV=1 eligio una factura de saldo 0, no debe actualizar FACTURACOBRAR
                                    sql = sql + " UPDATE FACTURACOBRAR SET  PAGADO = " & PAGADO & " ,SALDOCUOTA =  " & SaldoActualizar & "  WHERE IDFORMACOBRAR = " & odrDev("IDFORMACOBRAR")
                                End If
                            End If
                        End If
                    Loop
                End If
                sql = sql + " UPDATE DEVOLUCION SET COBRADO =  1, SALDO = 0 WHERE CODDEVOLUCION = " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & "   "

                Try
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    myTrans.Commit()
                Catch ex As Exception

                End Try

                odrDev.Close()
                objCommand.Dispose()
            End If


            Dim codDevTemp As Integer

            codDevTemp = Me.CodDevolucionTextBox.Text
            FechaFiltro()
            Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)

            'Buscamos la posicion del registro guardado
            For i = 0 To DevolucionesDataGridView.RowCount - 1
                If DevolucionesDataGridView.Rows(i).Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value = codDevTemp Then
                    DEVOLUCIONBindingSource.Position = i
                End If
            Next
            Try
                Me.DEVOLUCIONDETALLETableAdapter.Fill(DsDevoluciones.DEVOLUCIONDETALLE)
            Catch ex As Exception
            End Try

            TxtEstado.Text = "1"
            RecorreDetalleDevolucion()
            PintarCeldas()
        End If
    End Sub

    Private Sub Aprobar()
        sql = ""
        sql = "UPDATE DEVOLUCION SET NUMDEVOLUCION='" & NroNCLabel.Text & "',  ESTADO = 1" & _
              "WHERE CODDEVOLUCION= " & CDec(CodDevolucionTextBox.Text) & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Anular()
        sql = ""
        If cbxRelacionarFactura.Text = "Si" Then 'Tambien eliminamos la relacion con la factura si es el caso que estaba relacionada
            sql = "UPDATE DEVOLUCION SET ESTADO = 2 , MOTIVOANULADO = '" & TxtMotivodeAnulacion.Text & "', COBRADO=0, CODVENTA=0  " & _
              "WHERE CODDEVOLUCION= " & CDec(CodDevolucionTextBox.Text) & ""
        Else
            sql = "UPDATE DEVOLUCION SET ESTADO = 2 , MOTIVOANULADO = '" & TxtMotivodeAnulacion.Text & "'  " & _
              "WHERE CODDEVOLUCION= " & CDec(CodDevolucionTextBox.Text) & ""
        End If
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub CmbSucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbDeposito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TipoComprobanteComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub BtnCerrarMotivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarMotivo.Click
        'If band = 1 Then
        '    Me.Cursor = Cursors.AppStarting
        '    conexion = ser.Abrir()

        '    consulta = "UPDATE DEVOLUCION SET MOTIVODESCARTE = '" & TxtMotivodeAnulacion.Text & "' WHERE CODDEVOLUCION = " & DevolucionesDataGridView.CurrentRow("CODDEVOLUCIONDataGridViewTextBoxColumn").value
        '    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        '    Consultas.ConsultaComando(myTrans, consulta)
        '    myTrans.Commit()
        'End If
        band = 0
        TxtMotivodeAnulacion.Text = ""
        PanelMotivoAnulacion.Visible = False
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        PanelMotivoAnulacion.Visible = True
        PanelMotivoAnulacion.BringToFront()

        TxtMotivodeAnulacion.Enabled = True
        BtnAnularMotivo.Enabled = True
        TxtMotivodeAnulacion.Text = ""
        TxtMotivodeAnulacion.Enabled = True
        TxtMotivodeAnulacion.Focus()
    End Sub

    Private Sub BtnAnularMotivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnularMotivo.Click
        permiso = PermisoAplicado(UsuCodigo, 47)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para anular la Devolución", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            If TxtMotivodeAnulacion.Text = "" Then
                MessageBox.Show("Ingrese el Motivo de Anulación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMotivodeAnulacion.Focus()
                Exit Sub
            End If

            'Actualizamos la factura como estado ANULADO
            Try
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                cmd.Connection = sqlc
                cmd.Transaction = myTrans
            Catch
                MessageBox.Show("Se han creado conexiones paralelas, cierre la ventana y vuelva a abrirla", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
            Try
                Anular()
                myTrans.Commit()

            Catch ex As Exception

            End Try

            'Verificamos si existe 
            Dim c As Integer = DetalleDevDataGridView.RowCount
            Dim CodProductoDev, CodCodigo, CantidadDev, Precio As String
            Dim existe As Integer

            For c = 1 To c
                'verificamos si existe o no el producto para saber si modificamos o insertamos
                If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) Then
                    CodProductoDev = "NULL"
                    'Exit Sub
                    GoTo otrasverif
                Else
                    CodProductoDev = DetalleDevDataGridView.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                    If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                        CodCodigo = "NULL"
                    Else
                        CodCodigo = DetalleDevDataGridView.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                    End If
                    If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                        CantidadDev = "NULL"
                    Else
                        CantidadDev = DetalleDevDataGridView.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                        CantidadDev = Replace(CantidadDev, ",", ".")
                    End If
                    If IsDBNull(DetalleDevDataGridView.Rows(c - 1).Cells("PrecioNetoGrilla").Value) Then
                        Precio = "NULL"
                    Else
                        Precio = Math.Round(DetalleDevDataGridView.Rows(c - 1).Cells("PrecioNetoGrilla").Value, 2)
                        Precio = Replace(Precio, ",", ".")
                    End If
                End If

                'antes de hacer la actualizacion del stock debemos verificar que dicho producto no este marcado como "NO DESCONTAR DEL STOCK"
                Dim DescartarStock As String
                DescartarStock = DetalleDevDataGridView.Rows(c - 1).Cells("DescartarGrilla").Value

                If DescartarStock = "SI" Then
                    existe = w.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO = " & CodProductoDev & " AND CODCODIGO=" & CodCodigo & " AND CODDEPOSITO", CmbDeposito.SelectedValue)

                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans

                    Dim hora, Concat, Concatenar As String
                    hora = Now.ToString("HH:mm:ss")
                    Concat = dtpFechaDev.Text
                    Concatenar = Concat & " " + hora

                    Try
                        sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,STOCK) " & _
                              "VALUES(" & UsuCodigo & "," & CodCodigo & "," & CmbDeposito.SelectedValue & ",CONVERT(Datetime,'" & Concatenar & "',103),11," & CodDevolucionTextBox.Text & _
                              ",-" & CantidadDev & "," & Precio & ",'Anulacion Devolucion de Venta Nro " & NroNCLabel.Text & "',0,1)"

                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                        myTrans.Commit()

                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Actualizar")
                        Catch
                        End Try
                        MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'Cancelamos todo :(
                    Finally
                        sqlc.Close()
                    End Try
                End If
            Next

otrasverif:
            conexion = ser.Abrir()
            'Verificar si la Nota de Crédito ha generado un cobro y ha modificado el saldo de la Factura - REVERTIR SI ES EL CASO
            Dim davtafcob As New SqlDataAdapter("Select CODCOBRO, CODVENTA, NROCUOTA, IMPORTE FROM VENTASFORMACOBRO WHERE NUMDEVOLUCION = '" & NroNCLabel.Text & "'", conexion)
            Dim dtvtafcob As New DataTable
            davtafcob.Fill(dtvtafcob)
            Dim drvtafcob As DataRow

            Dim CodVentaRel As String = DevolucionesDataGridView.CurrentRow.Cells("CODVENTADataGridViewTextBoxColumn1").Value
            Dim ModalidadPago As String = w.FuncionConsultaString("MODALIDADPAGO", "VENTAS", "CODVENTA", CodVentaRel)

            For i = 0 To dtvtafcob.Rows.Count - 1
                drvtafcob = dtvtafcob.Rows(i)

                CantidadDev = drvtafcob("IMPORTE")
                CantidadDev = Replace(CantidadDev, ",", ".")

                ser.Abrir(sqlc)
                sql = "DELETE movimientos WHERE id_cobro = " & drvtafcob("CODCOBRO") & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                sql = ""
                sql = " DELETE CLIENTESCUENTACORRIENTE WHERE IDTRANSACCION=3 AND CODCOBRO= " & drvtafcob("CODCOBRO") & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                sql = ""
                If (ModalidadPago = 0 Or ModalidadPago = 4) And ConfigSaldoContado = "No Generar Saldo" Then 'Si es contado y tiene la configuracion No Generar Saldo, no debe devolverle el saldo
                    sql = "DELETE VENTASFORMACOBRO WHERE CODCOBRO = " & drvtafcob("CODCOBRO")
                Else
                    sql = "DELETE VENTASFORMACOBRO WHERE CODCOBRO = " & drvtafcob("CODCOBRO") & " UPDATE FACTURACOBRAR SET SALDOCUOTA=SALDOCUOTA + " & CantidadDev & " WHERE CODVENTA = " & drvtafcob("CODVENTA") & " AND CODNUMEROCUOTA = " & drvtafcob("NROCUOTA") & ""
                End If

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Next

            MessageBox.Show("Operación finalizada con éxito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim GRPos As Integer = DEVOLUCIONBindingSource.Position
            FechaFiltro()
            Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)
            Me.DEVOLUCIONDETALLETableAdapter.Fill(Me.DsDevoluciones.DEVOLUCIONDETALLE)
            DEVOLUCIONBindingSource.Position = GRPos

            PintarCeldas()
        End If
    End Sub

    Private Sub dgwClientes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwClientes.CellDoubleClick
        If dgwClientes.RowCount <> 0 Then
            Dim codvendedor As Decimal
            Dim codCliente As Integer

            ClienteComboBox.SelectedValue = dgwClientes.CurrentRow.Cells("CODCLIENTE").Value

            If IsDBNull(dgwClientes.CurrentRow.Cells("NUMCLIENTE1").Value) Then
            Else
                txtNrodeCliente.Text = dgwClientes.CurrentRow.Cells("NUMCLIENTE1").Value
            End If

            If IsDBNull(dgwClientes.CurrentRow.Cells("CODTIPOCLIENTE").Value) Then
            Else
                CodListaPrecio = dgwClientes.CurrentRow.Cells("CODTIPOCLIENTE").Value
            End If

            lblNombreFantasia.Visible = True
            lblNombreFantasia.Text = w.FuncionConsultaString("NOMBREFANTASIA", "CLIENTES", "CODCLIENTE", dgwClientes.CurrentRow.Cells("CODCLIENTE").Value)

            codvendedor = w.FuncionConsulta("codvendedor", "clientes", "codcliente", dgwClientes.CurrentRow.Cells("CODCLIENTE").Value)
            Try
                VendendorComboBox.SelectedValue = CDec(codvendedor)
            Catch ex As Exception
            End Try

            Dim codzona, CodDep, CodCiu As Integer
            Dim Departamento, Ciudad, Zona As String

            codCliente = dgwClientes.CurrentRow.Cells("CODCLIENTE").Value

            If Config4 = "Mostrar Localizacion del Cliente" Then
                codzona = w.FuncionConsulta("codzona", "clientes", "CAST(codcliente AS VARCHAR)", codCliente)

                CodDep = w.FuncionConsulta("CODDEPARTAMENTO", "CLIENTES", "codcliente", codCliente)
                Departamento = w.FuncionConsultaString("DESPAIS", "PAIS", "CODPAIS", CodDep)

                CodCiu = w.FuncionConsulta("CODCIUDAD", "CLIENTES", "codcliente", codCliente)
                Ciudad = w.FuncionConsultaString("DESCIUDAD", "CIUDAD", "CODCIUDAD", CodCiu)

                Zona = w.FuncionConsultaString("DESZONA", "ZONA", "CODZONA", codzona)

                txtLocalizacion.Text = Departamento + " / " + Ciudad + " / " + Zona

            ElseIf Config4 = "Mostrar Dirección del Cliente" Then
                txtLocalizacionDir.Text = w.FuncionConsultaString("DIRECCION", "CLIENTES", "CODCLIENTE", codCliente)
            End If
        End If

        upcClientes.Close()
        ClienteComboBox.Focus()
    End Sub


    Private Sub cbxTipoItem_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoItem.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxTipoItem.Text = "Producto" Then
                txtCodigo.Focus()
            Else
                txtProductoDescripcion.Focus()
            End If

            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxTipoItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxTipoItem.SelectedIndexChanged
        If cbxTipoItem.Text <> "" Then
            If cbxTipoItem.Text = "Producto" Then
                txtCodigo.Enabled = True
                txtProductoDescripcion.Enabled = False
                cbxDescartar.Text = "Sumar al Stock"
                cbxDescartar.Enabled = True
                cbxIva.Enabled = False
                txtCodigo.Focus()
            ElseIf cbxTipoItem.Text = "Item" Then
                txtCodigo.Enabled = False
                txtProductoDescripcion.Enabled = True
                cbxDescartar.Text = "NO Sumar al Stock"
                cbxDescartar.Enabled = False
                cbxIva.Enabled = True
                cbxIva.Text = "10"
                txtProductoDescripcion.Focus()
            End If
        End If
    End Sub

    Private Sub cbxRelacionarFactura_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxRelacionarFactura.SelectedIndexChanged
        If cbxRelacionarFactura.Text <> "" Then
            If cbxRelacionarFactura.Text = "No" Then
                txtNroFactura.Visible = False
                cbxTipoItem.Enabled = True
                cbxDescontarMonto.Visible = False
                If changingselection = False Then
                    BtnAsterisco.Visible = False
                End If
            ElseIf cbxRelacionarFactura.Text = "Si" Then
                txtNroFactura.Visible = True
                cbxDescontarMonto.Visible = True
                If changingselection = False Then
                    BtnAsterisco.Visible = True
                End If
                If Config5 = "Permitir Cargar otros Items como Detalle" Then
                    cbxTipoItem.Enabled = True
                Else
                    cbxTipoItem.Enabled = False
                End If
                txtNroFactura.Focus()

                If Config3 = "Automaticamente" Then
                    cbxDescontarMonto.Checked = True
                ElseIf Config3 = "Manualmente" Then
                    cbxDescontarMonto.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub cbxRelacionarFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxRelacionarFactura.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxRelacionarFactura.Text = "No" Then
                VendendorComboBox.Focus()
            ElseIf cbxRelacionarFactura.Text = "Si" Then
                txtNroFactura.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxTipoItem.Text = "Item" Then
                cbxIva.Focus()
            Else
                cbxDescartar.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub dgwProductoCodigo_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwProductoCodigo.CellDoubleClick
        Try
            If dgwProductoCodigo.RowCount <> 0 Then
                Try
                    Dim Iva As Integer
                    CodCodigoTextBox.Text = Me.dgwProductoCodigo.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn2").Value
                    CodProductoTextBox.Text = Me.dgwProductoCodigo.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn2").Value
                    txtCodigo.Text = Me.dgwProductoCodigo.CurrentRow.Cells("CODIGO").Value
                    txtProductoDescripcion.Text = Me.dgwProductoCodigo.CurrentRow.Cells("DESPRODUCTO").Value
                    txtPrecio.Text = Me.dgwProductoCodigo.CurrentRow.Cells("PRECIOVENTA").Value
                    Iva = Me.dgwProductoCodigo.CurrentRow.Cells("CODIVA").Value

                    If Iva = 1 Then
                        IVATextBox.Text = 10
                        cbxIva.Text = "10"
                    ElseIf Iva = 2 Then
                        IVATextBox.Text = 5
                        cbxIva.Text = "5"
                    ElseIf Iva = 3 Then
                        IVATextBox.Text = 0
                        cbxIva.Text = "0"
                    End If

                    'upcProdcutoCodigo.Close()
                    pnlProdcutoCodigo.Visible = False
                Catch ex As Exception

                End Try
            End If
            CantidadTextBox.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgwProductoCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgwProductoCodigo.KeyPress
        Try
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If KeyAscii = 13 Then
                If dgwProductoCodigo.RowCount <> 0 Then
                    Dim pos As Integer = dgwProductoCodigo.CurrentRow.Index
                    Dim cantReg As Integer = dgwProductoCodigo.RowCount - 1

                    If (pos <> 0) And (pos <> cantReg) Then
                        pos = pos - 1
                    End If

                    Dim Iva As Integer

                    CodCodigoTextBox.Text = Me.dgwProductoCodigo.Rows(pos).Cells("CODCODIGODataGridViewTextBoxColumn2").Value
                    CodProductoTextBox.Text = Me.dgwProductoCodigo.Rows(pos).Cells("CODPRODUCTODataGridViewTextBoxColumn2").Value
                    txtCodigo.Text = Me.dgwProductoCodigo.Rows(pos).Cells("CODIGO").Value
                    txtProductoDescripcion.Text = Me.dgwProductoCodigo.Rows(pos).Cells("DESPRODUCTO").Value
                    txtPrecio.Text = Me.dgwProductoCodigo.Rows(pos).Cells("PRECIOVENTA").Value

                    Iva = Me.dgwProductoCodigo.Rows(pos).Cells("CODIVA").Value

                    If Iva = 1 Then
                        IVATextBox.Text = 10
                        cbxIva.Text = "10"
                    ElseIf Iva = 2 Then
                        IVATextBox.Text = 5
                        cbxIva.Text = "5"
                    ElseIf Iva = 3 Then
                        IVATextBox.Text = 0
                        cbxIva.Text = "0"
                    End If
                End If
                '  upcProdcutoCodigo.Close()
                pnlProdcutoCodigo.Visible = False
                CantidadTextBox.Focus()

                KeyAscii = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtBuscarCodigoProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarCodigoProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgwProductoCodigo.Select()
        End If
    End Sub

    Private Sub txtCodigo_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigo.LostFocus
        Try
            ErrorCodigoLabel.Visible = False

            If Config5 = "Permitir Cargar otros Items como Detalle" Then
                DatosProductos()
            Else
                If cbxRelacionarFactura.Text = "No" Then
                    DatosProductos()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DatosProductos()
        Dim Iva As Integer
        If txtCodigo.Text <> "" Then
            objCommand.CommandText = "SELECT dbo.PRODUCTOS.CODPRODUCTO, dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CODIGOS.DESCODIGO1, dbo.PRECIO.PRECIOVENTA, dbo.PRECIO.CODTIPOCLIENTE,dbo.PRODUCTOS.CODIVA  " & _
                                     "FROM dbo.PRODUCTOS INNER JOIN dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO LEFT OUTER JOIN dbo.PRECIO ON dbo.PRODUCTOS.CODPRODUCTO = dbo.PRECIO.CODPRODUCTO  " & _
                                     "WHERE dbo.CODIGOS.CODIGO ='" & txtCodigo.Text & "' AND dbo.PRECIO.CODTIPOCLIENTE = " & CodListaPrecio

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrProductoCodigo As SqlDataReader = objCommand.ExecuteReader()

            If odrProductoCodigo.HasRows Then
                Do While odrProductoCodigo.Read()
                    Me.CodCodigoTextBox.Text = odrProductoCodigo("CODCODIGO")
                    Me.CodProductoTextBox.Text = odrProductoCodigo("CODPRODUCTO")
                    Me.txtPrecio.Text = odrProductoCodigo("PRECIOVENTA")
                    Me.txtProductoDescripcion.Text = odrProductoCodigo("DESPRODUCTO")
                    Iva = odrProductoCodigo("CODIVA")

                    If Iva = 1 Then
                        IVATextBox.Text = 10
                        cbxIva.Text = "10"
                    ElseIf Iva = 2 Then
                        IVATextBox.Text = 5
                        cbxIva.Text = "5"
                    ElseIf Iva = 3 Then
                        IVATextBox.Text = 0
                        cbxIva.Text = "0"
                    End If
                Loop
            Else
                ErrorCodigoLabel.Visible = True
            End If
            odrProductoCodigo.Close()
            objCommand.Dispose()
        End If
    End Sub

    Private Sub BuscaFacturaTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscaFacturaTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            VentasDataGridView.Select()
        End If
    End Sub

    Private Sub VentasDataGridView_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles VentasDataGridView.KeyPress
        'Dim KeyAscii As Short = Asc(e.KeyChar)
        'If KeyAscii = 13 Then
        '    Dim pos As Integer = VentasDataGridView.CurrentRow.Index
        '    Dim cantReg As Integer = VentasDataGridView.RowCount - 1

        '    If (pos <> 0) And (pos <> cantReg) Then
        '        pos = pos - 1
        '    End If

        '    Try
        '        If Not IsDBNull(VentasDataGridView.Rows(pos).Cells("CODVENTA").Value) And VentasDataGridView.Rows(pos).Cells("Usar").Value = True Then
        '            CodVentaTextBox.Text = VentasDataGridView.Rows(pos).Cells("CODVENTA").Value
        '            txtNroFactura.Text = VentasDataGridView.Rows(pos).Cells("NUMVENTADataGridViewTextBoxColumn").Value
        '            tipoventaActual = VentasDataGridView.Rows(pos).Cells("TIPOVENTA").Value

        '            If VentasDataGridView.Rows(pos).Cells("SALDO").Value = 0 Then
        '                VGSaldo = VentasDataGridView.Rows(pos).Cells("SALDODV").Value
        '                SiDEV = 1
        '            Else
        '                VGSaldo = VentasDataGridView.Rows(pos).Cells("SALDO").Value
        '                SiDEV = 0
        '            End If
        '        End If

        '        upcFacturasVentas.Close()
        '        txtCodigo.Focus()
        '    Catch ex As Exception
        '        upcFacturasVentas.Close()
        '    End Try
        'End If
    End Sub

    Private Sub BuscaFacturaTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscaFacturaTextBox.TextChanged
        VENTASBindingSource1.Filter = "NUMVENTA LIKE '%" & BuscaFacturaTextBox.Text & "%' OR NUMCLIENTE LIKE '%" & BuscaFacturaTextBox.Text & "%'"
    End Sub

    Private Sub txtBuscarCodigoProducto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarCodigoProducto.TextChanged
        CODIGOBindingSource.Filter = "DESPRODUCTO LIKE '%" & txtBuscarCodigoProducto.Text & "%' OR CODIGO LIKE '%" & txtBuscarCodigoProducto.Text & "%'"
    End Sub

    Private Sub txtProductoDescripcion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductoDescripcion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            CantidadTextBox.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 13 Then
            CantidadTextBox.Focus()
        End If
    End Sub

    Private Sub cbxIva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxIva.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            AddButton.Focus()
        End If
    End Sub

    Private Sub cbxTipoDevolucion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoDevolucion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaDev.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub btnVerProximo_Click(sender As System.Object, e As System.EventArgs) Handles btnVerProximo.Click
        Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango, NroRango2, NumDev As String
        Dim NroDigitos, Idrango As Integer
        Dim CodigoMaq As Integer
        CodigoMaq = CodigoMaquina

        Idrango = w.FuncionConsulta("RANDOID", "DETPC", "ACTIVO=1 AND IP = " & CodigoMaq & " AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
        NroDigitos = f.FuncionConsultaDecimal("NRODIGITOS", "DETPC", "RANDOID", IDRango)

        NumSucursal = SucCodigo
        NumMaquina = w.FuncionConsultaString("NUMMAQUINA", "PC", "IP", CodigoMaq)
        NumSucTimbrado = w.FuncionConsultaString("SUCURSALTIMBRADO", "SUCURSAL", "CODSUCURSAL", NumSucursal)

        NroRango = w.FuncionConsulta("ULTIMO", "DETPC", "RANDOID", Idrango)
        NroRango = NroRango + 1
        NroRango2 = w.FuncionConsulta("RANGO2", "DETPC", "RANDOID", Idrango)

        If CDec(NroRango) > CDec(NroRango2) Then
            MessageBox.Show("El Comprobante " + TipoComprobanteComboBox.Text + " no tiene mas Rango. " + Chr(13) + "Cierre esta ventana y cárguelo en (Dashboard >> Configuración >> 'Rangos de Comprobantes')", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        For i = 1 To NroDigitos
            If Len(NroRango) = NroDigitos Then
                Exit For
            Else
                NroRango = "0" & NroRango
            End If
        Next

        NumDev = NumSucTimbrado & "." & NumMaquina & "." & NroRango

        MessageBox.Show("Próximo Nro para el Comprobante " + TipoComprobanteComboBox.Text + ": " + NumDev, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub VendendorComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles VendendorComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbMoneda.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub CmbMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CmbMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If IngresarCotCheckBox.Checked = True Then
                Cot1FactTextBox.Focus()
            Else
                If cbxRelacionarFactura.Text = "No" Then
                    cbxTipoItem.Focus()
                Else
                    txtCodigo.Focus()
                End If
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub CmbMoneda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbMoneda.SelectedIndexChanged
        If AccBtNuevo = 1 Then
            TxtCodMoneda.Text = CmbMoneda.SelectedValue
            Dim SimboloEfectivo As String

            If CmbMoneda.SelectedValue <> Nothing Then
                Cot1FactTextBox.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(CmbMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
                SimboloEfectivo = w.FuncionConsultaString("SIMBOLO", "MONEDA", "CODMONEDA", CmbMoneda.SelectedValue)

                If SimboloEfectivo = "0" Then
                    SimCot1Label.Text = "Gs"
                Else
                    SimCot1Label.Text = SimboloEfectivo
                End If
            End If
        End If
    End Sub

    Private Sub IngresarCotCheckBox_ToggleStateChanged(sender As System.Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles IngresarCotCheckBox.ToggleStateChanged
        If IngresarCotCheckBox.Checked = True Then
            Cot1FactTextBox.Enabled = True
            Cot1FactTextBox.BringToFront()
            Cot1FactTextBox.Focus()
        Else
            Cot1FactTextBox.Enabled = False
            Cotizacion.BringToFront()
            Try
                Cot1FactTextBox.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", TxtCodMoneda.Text + " ORDER BY FECHAMOVIMIENTO DESC")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub tsNuevaVenta_Click(sender As System.Object, e As System.EventArgs) Handles tsNuevaDevoluc.Click
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

    Private Sub tsAprobar_Click(sender As System.Object, e As System.EventArgs) Handles tsAprobar.Click
        btnAprobar_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsAnular.Click
        btnAnular_Click(Nothing, Nothing)
    End Sub

    Private Sub tsCancelar_Click(sender As System.Object, e As System.EventArgs) Handles tsCancelar.Click
        CancelarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsAyudaOnline_Click(sender As System.Object, e As System.EventArgs) Handles tsAyudaOnline.Click
        Dim soporte As String = "http://www.cogentpotential.com/soporte/devoluciones/devolucionventa"
        Shell("Explorer " & soporte)
    End Sub

    Private Sub tsMotivoAnulacion_Click(sender As System.Object, e As System.EventArgs) Handles tsMotivoAnulacion.Click
        PanelMotivoAnulacion.Visible = True
        PanelMotivoAnulacion.BringToFront()
    End Sub

    Private Sub tsPersonalizarVentas_Click(sender As System.Object, e As System.EventArgs) Handles tsPersonalizarDev.Click
        ABMConfigPosExpress.Show()
        ABMConfigPosExpress.abrirdesde("Devolución")
    End Sub

    Private Sub tsDuplicarFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsDuplicarFactura.Click
        permiso = PermisoAplicado(UsuCodigo, 213) ' Duplicar una Factura
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else
            Me.NroNCLabel.Text = ""
            Dim MaxDev As Double = w.Maximo("CODDEVOLUCION", "DEVOLUCION")
            CodDevolucionTextBox.Text = MaxDev + 1
            'Si duplica..si o si con la fecha de Hoy
            dtpFechaDev.Value = Today.ToShortDateString

            AccBtNuevo = 1 : btduplicar = 1

            GuardarPictureBox_Click(Nothing, Nothing) ' Aqui llama al evento Click de Guardar 
            btduplicar = 0
        End If
    End Sub

    Private Sub tsReImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsReImprimir.Click
        permiso = PermisoAplicado(UsuCodigo, 192)
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else
            Try
                Dim IDRango As Integer
                Dim ValorFiscal As Integer = ValorFiscal = w.FuncionConsulta("VALORFISCAL", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)

                Dim CodigoMaq, CodSuc As Integer

                CodigoMaq = CodigoMaquina
                CodSuc = SucCodigo

                IDRango = w.FuncionConsulta("RANDOID", "DETPC", "ACTIVO=1 AND IP = " & CodigoMaq & " AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                tipoimpresion = w.FuncionConsulta("FORMAIMPRESION", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                Cantlinea = w.FuncionConsulta("NROLINEASDETALLE", "TIPOCOMPROBANTE", "CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                'imprimirfact = w.FuncionConsulta("IMPRIMIR", "DETPC", "RANDOID", IDRango) EN REIMPRIMIR YA NO PREGUNTAMOS
                impresora = f.FuncionConsultaString("IMPRESORA", "DETPC", "RANDOID", IDRango)

                'se verifica el tipo de impresion para el tipo de comprobante actuamente seleccionado y de acuerdo a eso realizamos la impresion correspondiente
                'en caso de que este marcado la opcion de imprimir en la ventana "Rango de Comprobantes" 
                If tipoimpresion = 0 Then   'Formato Ticket
                    ImprimirTicket()
                ElseIf tipoimpresion = 1 Then 'Formato Impresora
                    ImprimirReporte()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al Imprimir : " & ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub BtnNuevoP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevoP3.Click
        permiso = PermisoAplicado(UsuCodigo, 41)
        If permiso = 0 Then
            BtnNuevoP3.SendToBack()
        Else
            NroFactText.Visible = True
            If NroNCLabel.Text <> "" Then
                NroFactText.Text = NroNCLabel.Text
            Else
                NroFactText.Text = ""
            End If
            NroFactText.Focus()
            NroNCLabel.Visible = False
            BtnGuardarP3.Visible = True
            BtnCancelarP3.Visible = True
            BtnNuevoP3.Visible = False
            Me.tsCargarNroFactura.Enabled = False
        End If
    End Sub

    Private Sub tsCargarNroFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsCargarNroFactura.Click
        permiso = PermisoAplicado(UsuCodigo, 41) ' Cargar Nro. de Factura Manual
        If permiso = 0 Then
            BtnNuevoP3.SendToBack()
        Else
            NroFactText.Visible = True
            If NroNCLabel.Text <> "" Then
                NroFactText.Text = NroNCLabel.Text
            Else
                NroFactText.Text = ""
            End If
            NroFactText.Focus()
            NroNCLabel.Visible = False
            BtnGuardarP3.Visible = True
            BtnCancelarP3.Visible = True
            BtnNuevoP3.Visible = False
            Me.tsCargarNroFactura.Enabled = False
        End If
    End Sub

    Private Sub tsModificarNroFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsModificarNroFactura.Click
        permiso = PermisoAplicado(UsuCodigo, 214) 'Modificar Nro. Factura ya Aprobada
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else
            Dim nvoNumero As String = InputBox("Ingrese el nuevo Nro. de Devolución: ", " Modificar Nro. Devolución", Me.NroNCLabel.Text)
            If nvoNumero <> Me.NroNCLabel.Text And nvoNumero <> "" Then
                Try
                    'Verificamos que el nro de factura nose repita (en devoluciones no se esta guardando el timbrado!!)
                    Dim ExisteNroDevolucion As String = w.FuncionConsultaString("NUMDEVOLUCION", "DEVOLUCION", "ESTADO=1 AND NUMDEVOLUCION", nvoNumero)

                    If ExisteNroDevolucion <> "" Then
                        If MessageBox.Show("Existe una Devolución Aprobada con el mismo Número. Desea modificar el Nro. de todos modos?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                    End If

                    'modificamos nro. de factura
                    Dim consulta As System.String
                    Dim conexion As System.Data.SqlClient.SqlConnection

                    conexion = ser.Abrir()
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    consulta = "UPDATE DEVOLUCION SET NUMDEVOLUCION='" & nvoNumero & "' WHERE CODDEVOLUCION=" & CDec(Me.CodDevolucionTextBox.Text) & ""
                    Consultas.ConsultaComando(myTrans, consulta)

                    myTrans.Commit()

                    Dim GRPos As Integer = DEVOLUCIONBindingSource.Position
                    FechaFiltro()
                    Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)
                    Me.DEVOLUCIONDETALLETableAdapter.Fill(Me.DsDevoluciones.DEVOLUCIONDETALLE)
                    DEVOLUCIONBindingSource.Position = GRPos

                    Me.DevolucionesDataGridView.Refresh()
                Catch ex As Exception
                    'MsgBox(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub tsQuemarProxNro_Click(sender As System.Object, e As System.EventArgs) Handles tsQuemarProxNro.Click
        permiso = PermisoAplicado(UsuCodigo, 212) 'Crear una Factura en Blanco
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else

            Dim consulta As System.String
            Dim UltimaDev, ultimo, IdRango As Integer
            Dim CompActivo As Integer
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction

            PanelMotivoAnulacion.BringToFront()
            'PanelMotivoAnulacion.Enabled
            TxtMotivodeAnulacion.Focus()
            BtnAnularMotivo.Visible = False
            band = 1

            Me.Cursor = Cursors.AppStarting
            conexion = ser.Abrir()
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            Try

                'Verificar si el Comprobante está Activo
                CompActivo = w.CountconWhere("ACTIVO", "DETPC", "IP = " & CodigoMaquina & "" & _
                                 " AND CODEMPRESA=" & EmpCodigo & " AND CODSUCURSAL=" & SucCodigo & " AND (ULTIMO < RANGO2) AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue.ToString)

                If CompActivo = 0 Or String.IsNullOrEmpty(CompActivo) = True Then
                    MessageBox.Show("No hay comprobantes activos para esta máquina o No tiene asignado un nro. de comprobante", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TipoComprobanteComboBox.Focus()
                    'BtnImprimir.Image = My.Resources.Approve
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
                IdRango = w.FuncionConsulta("RANDOID", "DETPC", "ACTIVO=1 AND IP = " & CodigoMaquina & " AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                GeneraTimbrado() 'Se calcula el Nro de Devolucion a Generar de forma automatica

                Dim MaxDev As Integer = w.Maximo("CODDEVOLUCION", "DEVOLUCION")
                'Obtenemos la fecha
                If Config2 = "Actual" Then
                    dtpFechaDev.Value = Today

                ElseIf Config2 = "Atrazada 1 Día" Then
                    Dim day As Integer = DateTime.Now.AddDays(-1).Day
                    Dim mes As Integer = Today.Month
                    Dim anho As Integer = Today.Year

                    Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                    dtpFechaDev.Value = Fecha

                ElseIf Config2 = "Adelantada 1 Día" Then
                    Dim day As Integer = DateTime.Now.AddDays(+1).Day
                    Dim mes As Integer = Today.Month
                    Dim anho As Integer = Today.Year

                    Dim Fecha As String = day.ToString + "/" + mes.ToString + "/" + anho.ToString
                    dtpFechaDev.Value = Fecha

                ElseIf Config2 = "Ultima Seleccion" Then
                    'Buscamos la Ultima Fecha utilizada
                    If MaxDev <> 0 Then
                        dtpFechaDev.Value = w.FuncionConsultaString("FECHADEVOLUCION", "DEVOLUCION", "CODDEVOLUCION", MaxDev)
                    End If
                End If

                'se debe obtener el ultimo nro insertado
                UltimaDev = f.Maximo("CODDEVOLUCION", "DEVOLUCION")
                NroDevGlobal = UltimaDev + 1

                'Nrango acaba de calcular en GeneraTimbrado()

                consulta = "INSERT INTO DEVOLUCION(CODCOMPROBANTE,NUMDEVOLUCION,FECHADEVOLUCION,ESTADO,CODSUCURSAL,CODUSUARIO) VALUES (" & TipoComprobanteComboBox.SelectedValue & ", '" & NumDevolucion & "', CONVERT(DATETIME,'" & dtpFechaDev.Text & "',103), 2, " & SucCodigo & "," & UsuCodigo & ")"

                ultimo = f.MaximoconWhere("ULTIMO", "DETPC", "RANDOID", IdRango)
                ultimo = ultimo + 1

                ' consulta = consulta + " UPDATE DETPC SET ULTIMO = " & ultimo & " where IP = " & _
                ' "" & CodigoMaquina & " AND CODEMPRESA = " & EmpCodigo & " AND " & _
                ' "CODSUCURSAL = " & SucCodigo & " AND CODCOMPROBANTE = " & TipoComprobanteComboBox.SelectedValue & ""

                consulta = consulta + " UPDATE DETPC SET ULTIMO = " & ultimo & " where RANDOID = " & IdRango & ""

                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                'MsgBox(mensajeerror)
                Throw
            End Try

            '---------------------------- DESACTIVA RANGO ----------------------------
            'Verificamos si es el ultimo Nro del rango de comprobantes y ponemos como desabilitado dicho rango
            Dim hastanro As Integer

            ultimo = w.FuncionConsulta("ULTIMO", "DETPC", "RANDOID", IdRango)
            hastanro = w.FuncionConsulta("RANGO2", "DETPC", "RANDOID", IdRango)

            If hastanro = ultimo Then
                Try
                    consulta = "UPDATE DETPC SET ACTIVO=0 WHERE RANDOID =" & IdRango & ""
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()
                Catch ex As Exception

                End Try
            End If

            conexion.Close()

            FechaFiltro()
            Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)
            Me.DEVOLUCIONDETALLETableAdapter.Fill(Me.DsDevoluciones.DEVOLUCIONDETALLE)

            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub tsAplicarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles tsAplicarFiltros.Click
        Dim fechaDesdeEspecial As String
        Dim fechaHastaEspecial As String
        CmbAño.Text = ""
        CmbMes.Text = "Filtros"
        If errorFiltroFecha = 0 And errorFiltroRango = 0 And Trim(tsFiltroFechaE.Text) <> "" And (Trim(tsFiltroRDesde.Text) <> "" Or Trim(tsFiltroRHasta.Text) <> "") Then
            MsgBox("Se introdujeron filtros en Fecha Específica y Rango de Fechas. El Sistema toma por defecto la Fecha Específica", MsgBoxStyle.Information, "Error en Filtro")
        ElseIf Trim(tsFiltroNroCliente.Text) <> "" And Trim(tsFiltroNomCliente.Text) <> "" Then
            MsgBox("Se introdujeron filtros en Nro. de Cliente y Nombre de Cliente. El Sistema toma por defecto el Nro. de Cliente", MsgBoxStyle.Information, "Error en Filtro")
        End If
        If Trim(tsFiltroFechaE.Text) <> "" Then
            If errorFiltroFecha = 0 Then
                fechaDesdeEspecial = tsFiltroFechaE.Text + " 00:00:00"
                fechaHastaEspecial = tsFiltroFechaE.Text + " 23:59:00"
            Else
                GoTo todasfechas
            End If
        Else
            If Trim(tsFiltroRDesde.Text) <> "" And Trim(tsFiltroRHasta.Text) <> "" And errorFiltroRango = 0 Then
                If errorFiltroRango = 0 Then
                    fechaDesdeEspecial = tsFiltroRDesde.Text + " 00:00:00"
                    fechaHastaEspecial = tsFiltroRHasta.Text + " 23:59:00"
                Else
                    GoTo todasfechas
                End If
            ElseIf Trim(tsFiltroRDesde.Text) <> "" Or Trim(tsFiltroRHasta.Text) <> "" Then
                MsgBox("Falta Especificar una Fecha del Rango", MsgBoxStyle.Information, "Error en Filtro")
                Exit Sub
            Else
todasfechas:
                fechaDesdeEspecial = "01/01/1900 00:00:00"
                fechaHastaEspecial = "31/12/2900 23:59:00"
            End If
        End If

        Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, fechaDesdeEspecial, fechaHastaEspecial)
        Me.DEVOLUCIONDETALLETableAdapter.Fill(Me.DsDevoluciones.DEVOLUCIONDETALLE)

        If Trim(tsFiltroNroCliente.Text) <> "" Then
            DEVOLUCIONBindingSource.Filter = "NUMCLIENTE1 = " & Trim(tsFiltroNroCliente.Text)
        Else
            If Trim(tsFiltroNomCliente.Text) <> "" Then
                DEVOLUCIONBindingSource.Filter = "NOMBRE like '%" & Trim(tsFiltroNomCliente.Text) & "%'"
            End If
        End If
        lblDGVCant.Text = "Cant. de Items:" & DevolucionesDataGridView.RowCount
    End Sub

    Private Sub tsLimpiarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles tsLimpiarFiltros.Click
        tsFiltroFechaE.Text = "" : tsFiltroFechaE.BackColor = SystemColors.Window
        tsFiltroRDesde.Text = "" : tsFiltroRDesde.BackColor = SystemColors.Window
        tsFiltroRHasta.Text = "" : tsFiltroRHasta.BackColor = SystemColors.Window
        tsFiltroNroCliente.Text = ""
        tsFiltroNomCliente.Text = ""
        InicializaFechaFiltro()
        If CmbMes.Text = "Filtros" Then
            CmbMes.SelectedIndex = Today.Month - 1
        End If
        If CmbAño.Text = "" Then
            CmbAño.SelectedText = Today.Year.ToString
        End If
        BtnFiltro_Click(Nothing, Nothing)
    End Sub

    Private Sub tsFiltroNroCliente_TextChanged(sender As Object, e As System.EventArgs) Handles tsFiltroNroCliente.TextChanged
        If Not System.Text.RegularExpressions.Regex.IsMatch(tsFiltroNroCliente.Text, "^\d*$") Then
            tsFiltroNroCliente.Text = tsFiltroNroCliente.Text.Remove(tsFiltroNroCliente.Text.Length - 1)
            tsFiltroNroCliente.SelectionStart = tsFiltroNroCliente.Text.Length
        End If
    End Sub

    Private Sub tsFiltroFechaE_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroFechaE.LostFocus
        If Trim(tsFiltroFechaE.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroFechaE.Text)
                errorFiltroFecha = 0
                tsFiltroFechaE.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroFecha = 1
                MsgBox("El Sistema no tomará el Filtro Fecha Específica. Por Favor Ingrese una Fecha válida", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroFechaE.BackColor = Color.Pink
                'tsFiltroFechaE.Focus() no funciona
            End Try
        ElseIf errorFiltroFecha = 1 Then
            errorFiltroFecha = 0
            tsFiltroFechaE.BackColor = SystemColors.Window
        End If
    End Sub
    Private Sub tsFiltroRDesde_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroRDesde.LostFocus
        If Trim(tsFiltroRDesde.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroRDesde.Text)
                errorFiltroRango = 0
                tsFiltroRDesde.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroRango = 1
                MsgBox("El Sistema no tomará el Filtro Rango de Fechas. Por Favor Ingrese una Fecha válida en Fecha Desde", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroRDesde.BackColor = Color.Pink
            End Try
        ElseIf errorFiltroRango = 1 Then
            errorFiltroRango = 0
            tsFiltroRDesde.BackColor = SystemColors.Window
        End If
    End Sub
    Private Sub tsFiltroRHasta_LostFocus(sender As Object, e As System.EventArgs) Handles tsFiltroRHasta.LostFocus
        If Trim(tsFiltroRHasta.Text) <> "" Then
            Dim fecha2 As Date
            Try
                fecha2 = CDate(tsFiltroRHasta.Text)
                errorFiltroRango = 0
                tsFiltroRHasta.BackColor = SystemColors.Window
            Catch ex As Exception
                errorFiltroRango = 1
                MsgBox("El Sistema no tomará el Filtro Rango de Fechas. Por Favor Ingrese una Fecha válida en Fecha Hasta", MsgBoxStyle.Information, "Error en Filtro")
                tsFiltroRHasta.BackColor = Color.Pink
            End Try
        ElseIf errorFiltroRango = 1 Then
            errorFiltroRango = 0
            tsFiltroRHasta.BackColor = SystemColors.Window
        End If
    End Sub
    Private Sub BtnCancelarP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarP3.Click
        NroFactText.Visible = False
        NroNCLabel.Visible = True
        BtnGuardarP3.Visible = False
        BtnCancelarP3.Visible = False
        BtnNuevoP3.Visible = True
    End Sub

    Private Sub BtnGuardarP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarP3.Click
        'Dim f As New Funciones.Funciones
        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction
        Dim ExisteNroFactura, SucRango, SubCadena, Timbrado As String

        'se verifica que el nro de factura no este vacio
        If NroFactText.Text <> "--" Then
            'TxtEstado.Text = "3"
            Try
                'Si se cargo de forma manual verificamos q el rango de factura que ingreso exista en algun rango de comprobantes
                SubCadena = Mid(NroFactText.Text, 1, 3)
                ExisteNroFactura = w.FuncionConsultaString("CODSUCURSAL", "SUCURSAL", "SUCURSALTIMBRADO", SubCadena)
                SucRango = ExisteNroFactura

                If ExisteNroFactura = "" Or ExisteNroFactura = Nothing Then
                    MessageBox.Show("No existe ningún Rango de Comprobante Activo con esta Numeración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' NroFactText.Text = NroRemisionLabel.Text
                    NroNCLabel.Visible = False
                    NroFactText.Visible = True
                    NroFactText.Focus()

                    BtnGuardarP3.Visible = True
                    BtnCancelarP3.Visible = True
                    BtnNuevoP3.Visible = False
                    Me.tsCargarNroFactura.Enabled = False
                    Exit Sub

                Else

                    'SubCadena = Mid(NroFactText.Text, 5, 3)  Consultamos por Rango porque en Devolucion trae todas las devoluciones sin importar que Sucursal este seleccionado en el Dashboard
                    Dim IDRango As Integer = w.FuncionConsulta("RANDOID", "DETPC", "CODCOMPROBANTE=" & TipoComprobanteComboBox.SelectedValue & " " & _
                                 "and CODEMPRESA=" & EmpCodigo & " AND IP=" & CodigoMaquina & " AND ACTIVO = 1 AND CODSUCURSAL", SucCodigo)

                    ExisteNroFactura = w.FuncionConsultaString("NUMMAQUINA", "PC INNER JOIN DETPC ON DETPC.IP = PC.IP", "DETPC.RANDOID", IDRango)

                    If ExisteNroFactura = "" Or ExisteNroFactura = Nothing Then
                        MessageBox.Show("No existe ningún Rango de Comprobante Activo con esta numeración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '  NroFactText.Text = NroRemisionLabel.Text
                        NroNCLabel.Visible = False
                        NroFactText.Visible = True
                        NroFactText.Focus()

                        BtnGuardarP3.Visible = True
                        BtnCancelarP3.Visible = True
                        BtnNuevoP3.Visible = False
                        Me.tsCargarNroFactura.Enabled = False
                        Exit Sub
                    End If
                End If

                'Verificamos que el nro de factura nose repita dentro del mismo timbrado
                Timbrado = f.FuncionConsulta("TIMBRADO", "DETPC", "IP=" & CodigoMaquina & " AND CODSUCURSAL=" & SucCodigo & _
                                             "AND ACTIVO = 1 AND CODCOMPROBANTE", TipoComprobanteComboBox.SelectedValue)
                ExisteNroFactura = w.FuncionConsultaString("NUMVENTA", "VENTAS", "NUMVENTA = '" & NroFactText.Text & "' AND NUMVENTATIMBRADO", Timbrado)

                If ExisteNroFactura <> "" Then
                    MessageBox.Show("El Nro de Factura ya Existe para el Rango con Timbrado: " & Timbrado, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    NroNCLabel.Visible = False
                    NroFactText.Visible = True
                    NroFactText.Focus()

                    BtnGuardarP3.Visible = True
                    BtnCancelarP3.Visible = True
                    BtnNuevoP3.Visible = False
                    Me.tsCargarNroFactura.Enabled = False
                    Exit Sub
                End If

                conexion = ser.Abrir()
                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                consulta = "UPDATE DEVOLUCION SET NUMDEVOLUCION='" & NroFactText.Text & "' WHERE CODDEVOLUCION=" & CDec(Me.CodDevolucionTextBox.Text) & ""
                Consultas.ConsultaComando(myTrans, consulta)

                myTrans.Commit()

            Catch ex As Exception
                Try
                    conexion = ser.Abrir()
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    myTrans.Rollback("Insertar")
                Catch
                End Try

                Throw
            End Try
            NroNCLabel.ForeColor = Color.OrangeRed
            NroNCLabel.Text = NroFactText.Text
            NroFactText.Visible = False
            NroNCLabel.Visible = True
            BtnGuardarP3.Visible = False
            BtnCancelarP3.Visible = False
            BtnNuevoP3.Visible = True

        Else
            MessageBox.Show("Debe ingresar un Nro de Factura", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NroFactText.Focus()
        End If
    End Sub

    Private Sub chxFacturasconSaldoCero_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chxFacturasconSaldoCero.CheckedChanged
        If chxFacturasconSaldoCero.Checked = True Then
            Try
                If cbxDevOtrosDepositos.Text = "Si" Then
                    VENTASTableAdapter.FillBySaldoCero(DsDevoluciones.VENTAS, ClienteComboBox.SelectedValue)
                ElseIf cbxDevOtrosDepositos.Text = "No" Then
                    VENTASTableAdapter.FillBySaldoCeroDeposito(DsDevoluciones.VENTAS, ClienteComboBox.SelectedValue, CInt(CmbDeposito.SelectedValue))
                End If
            Catch ex As Exception
            End Try
        Else
            Try
                If cbxDevOtrosDepositos.Text = "Si" Then
                    VENTASTableAdapter.Fill(DsDevoluciones.VENTAS, ClienteComboBox.SelectedValue)
                ElseIf cbxDevOtrosDepositos.Text = "No" Then
                    VENTASTableAdapter.FillBy(DsDevoluciones.VENTAS, ClienteComboBox.SelectedValue, CInt(CmbDeposito.SelectedValue))
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ProductosDataGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ProductosDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim pos As Integer = ProductosDataGridView.CurrentRow.Index
                Dim cantReg As Integer = ProductosDataGridView.RowCount - 1

                'If (pos <> 0) And (pos <> cantReg) Then
                '    pos = pos - 1
                'End If

                If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CODIGODataGridViewTextBoxColumn").Value) Then
                    txtCodigo.Text = ""
                Else
                    txtCodigo.Text = ProductosDataGridView.Rows(pos).Cells("CODIGODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                    CodCodigoTextBox.Text = ""
                Else
                    CodCodigoTextBox.Text = ProductosDataGridView.Rows(pos).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                End If

                If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                    CodProductoTextBox.Text = ""
                Else
                    CodProductoTextBox.Text = ProductosDataGridView.Rows(pos).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
                End If

                If IsDBNull(ProductosDataGridView.Rows(pos).Cells("IVADataGridViewTextBoxColumn1").Value) Then
                    IVATextBox.Text = ""
                Else
                    IVATextBox.Text = ProductosDataGridView.Rows(pos).Cells("IVADataGridViewTextBoxColumn1").Value
                End If

                If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value) Then
                    CantidadTextBox.Text = ""
                Else
                    CantidadTextBox.Text = ProductosDataGridView.Rows(pos).Cells("CANTIDADVENTADataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(ProductosDataGridView.Rows(pos).Cells("PRODUCTODataGridViewTextBoxColumn").Value) Then
                    txtProductoDescripcion.Text = ""
                Else
                    txtProductoDescripcion.Text = ProductosDataGridView.Rows(pos).Cells("PRODUCTODataGridViewTextBoxColumn").Value
                End If

                If IsDBNull(ProductosDataGridView.Rows(pos).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value) Then
                    txtPrecio.Text = ""
                Else
                    txtPrecio.Text = ProductosDataGridView.Rows(pos).Cells("PRECIOVENTALISTADataGridViewTextBoxColumn").Value
                End If

                ProductosGroupBox.Visible = False
                CantidadTextBox.Focus()
            Catch ex As Exception
                upcProdcutoCodigo.Close()
            End Try
        End If
    End Sub

    Private Sub BtnAsterisco_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsterisco.Click
        If upcFacturasVentas.IsDisplayed Then
            YatengoFact = False
            upcFacturasVentas.Close()
            txtCodigo.Focus()
        Else
            If ClienteComboBox.SelectedValue <> Nothing Then
                'ANTES DE MOSTRAR EL FILTRO DE FACTURAS SE DEBE VERIFICAR SI DESEA FILTRAR SIN IMPORTAR EL DESPOSITO O SOLO DEL DEPOSITO SELECCIONADO
                upcFacturasVentas.Show()
                BuscaFacturaTextBox.Focus()
                Try
                    If cbxDevOtrosDepositos.Text = "Si" Then
                        VENTASTableAdapter.Fill(DsDevoluciones.VENTAS, ClienteComboBox.SelectedValue)
                    ElseIf cbxDevOtrosDepositos.Text = "No" Then
                        VENTASTableAdapter.FillBy(DsDevoluciones.VENTAS, ClienteComboBox.SelectedValue, CInt(CmbDeposito.SelectedValue))
                    End If
                Catch ex As Exception
                End Try
                If posVenta <> -1 And posVenta <= VentasDataGridView.Rows.Count - 1 Then
                    VentasDataGridView.Rows(posVenta).Cells("Usar").Value = True
                End If
            Else
                MessageBox.Show("Primero seleccione el Cliente para Filtrar las Compras", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClienteComboBox.Select()
                Exit Sub
            End If
        End If
    End Sub



    'Private Sub VentasDataGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles VentasDataGridView.KeyDown
    'If e.KeyCode = Keys.Enter Then
    'Dim cantReg As Integer = VentasDataGridView.RowCount - 1

    'If (pos <> 0) And (pos <> cantReg) Then
    '    pos = pos - 1
    'End If

    'Try
    '    If Not IsDBNull(VentasDataGridView.Rows(posVenta).Cells("CODVENTA").Value) And VentasDataGridView.Rows(posVenta).Cells("Usar").Value = True Then
    '        CodVentaTextBox.Text = VentasDataGridView.Rows(posVenta).Cells("CODVENTA").Value
    '        txtNroFactura.Text = VentasDataGridView.Rows(posVenta).Cells("NUMVENTADataGridViewTextBoxColumn").Value
    '        tipoventaActual = VentasDataGridView.Rows(posVenta).Cells("TIPOVENTA").Value

    '        If VentasDataGridView.Rows(posVenta).Cells("SALDO").Value = 0 Then
    '            VGSaldo = VentasDataGridView.Rows(posVenta).Cells("SALDODV").Value
    '            SiDEV = 1
    '        Else
    '            VGSaldo = VentasDataGridView.Rows(posVenta).Cells("SALDO").Value
    '            SiDEV = 0
    '        End If
    '    End If
    '    YatengoFact = True
    '    upcFacturasVentas.Close()
    '    YatengoFact = False
    '    txtCodigo.Focus()
    'Catch ex As Exception
    '    upcFacturasVentas.Close()
    'End Try
    'End If
    'End Sub

    'Private Sub upcFacturasVentas_Closed(sender As Object, e As System.EventArgs) Handles upcFacturasVentas.Closed
    '    If YatengoFact = False And posVenta <> -1 Then
    '        If posVenta <= VentasDataGridView.Rows.Count - 1 Then
    '            If Not IsDBNull(VentasDataGridView.Rows(posVenta).Cells("CODVENTA").Value) Then
    '                CodVentaTextBox.Text = VentasDataGridView.Rows(posVenta).Cells("CODVENTA").Value
    '                txtNroFactura.Text = VentasDataGridView.Rows(posVenta).Cells("NUMVENTADataGridViewTextBoxColumn").Value
    '                tipoventaActual = VentasDataGridView.Rows(posVenta).Cells("TIPOVENTA").Value

    '                If VentasDataGridView.Rows(posVenta).Cells("SALDO").Value = 0 Then
    '                    VGSaldo = VentasDataGridView.Rows(posVenta).Cells("SALDODV").Value
    '                    SiDEV = 1
    '                Else
    '                    VGSaldo = VentasDataGridView.Rows(posVenta).Cells("SALDO").Value
    '                    SiDEV = 0
    '                End If
    '            End If
    '        End If
    '    ElseIf posVenta = -1 Then
    '        CodVentaTextBox.Text = ""
    '        txtNroFactura.Text = ""
    '    End If
    'End Sub

    Private Sub btnUsarFact_Click(sender As System.Object, e As System.EventArgs) Handles btnUsarFact.Click
        Dim coti As String = "1,00"
        Try
            If Not IsDBNull(VentasDataGridView.Rows(posVenta).Cells("CODVENTA").Value) And VentasDataGridView.Rows(posVenta).Cells("Usar").Value = True Then
                CodVentaTextBox.Text = VentasDataGridView.Rows(posVenta).Cells("CODVENTA").Value
                txtNroFactura.Text = VentasDataGridView.Rows(posVenta).Cells("NUMVENTADataGridViewTextBoxColumn").Value
                tipoventaActual = VentasDataGridView.Rows(posVenta).Cells("TIPOVENTA").Value

                '------------------TOMA EL TIPO DE LA COTIZACION Y LA COTIZACION DE LA FACTURA ELEGIDA-----------------------
                '------------------------PARA ACTUALIZAR AUTOMATICAMENTE EN LA NOTA DE CREDITO-------------------------------
                coti = VentasDataGridView.Rows(posVenta).Cells("COTIZACION1DataGridViewTextBoxColumn").Value
                CmbMoneda.SelectedValue = VentasDataGridView.Rows(posVenta).Cells("CODMONEDADataGridViewTextBoxColumn").Value
                '------------------------------------------------------------------------------------------------------------

                If VentasDataGridView.Rows(posVenta).Cells("SALDO").Value = 0 Then
                    VGSaldo = VentasDataGridView.Rows(posVenta).Cells("SALDODV").Value
                    SiDEV = 1
                Else
                    VGSaldo = VentasDataGridView.Rows(posVenta).Cells("SALDO").Value
                    SiDEV = 0
                End If
            End If
            YatengoFact = True
            upcFacturasVentas.Close()
            YatengoFact = False
            txtCodigo.Focus()
            '---Reemplazamos la cotización---
            Cot1FactTextBox.Text = coti
        Catch ex As Exception
            MsgBox("Ocurrio un error: " & ex.Message, MsgBoxStyle.Exclamation)
            upcFacturasVentas.Close()
        End Try
    End Sub

    Private Sub tsCambiarIngresoMerc_Click(sender As System.Object, e As System.EventArgs) Handles tsCambiarIngresoMerc.Click
        Try
            permiso = PermisoAplicado(UsuCodigo, 266) 'Cambiar Ingreso/Salida del Stock
            If permiso = 0 Then
                MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
            Else
                If MessageBox.Show("Confirma que desea Cambiar el Ingreso/Salida del Stock?", "CogentSIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If DetalleDevDataGridView.RowCount <> 0 Then 'TODOS SERAN IGUALES, BASTA CON LEER EL PRIMERO

                        Dim condicion As String = DetalleDevDataGridView.Rows(0).Cells("DescartarGrilla").Value
                        Dim hora As String = Now.ToString("HH:mm:ss")
                        Dim Concat As String = dtpFechaDev.Text
                        Dim Concatenar As String = Concat & " " + hora

                        Dim CodProductoDev, CodCodigo, CantidadDev, Precio As String
                        CodProductoDev = "" : CodCodigo = "" : CantidadDev = "" : Precio = ""
                        Dim existe As Integer

                        If condicion = "NO" Then '----------------- ACTUALIZAMOS STOCK Y MOVIMIENTO DE PRODUCTOS -----------------------------
                            For i = 0 To DetalleDevDataGridView.RowCount - 1

                                'verificamos si existe o no el producto para saber si modificamos o insertamos

                                CodProductoDev = DetalleDevDataGridView.Rows(i).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                                If IsDBNull(DetalleDevDataGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                                    CodCodigo = "NULL"
                                Else
                                    CodCodigo = DetalleDevDataGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                                End If
                                If IsDBNull(DetalleDevDataGridView.Rows(i).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                                    CantidadDev = "NULL"
                                Else
                                    CantidadDev = DetalleDevDataGridView.Rows(i).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                                    CantidadDev = Replace(CantidadDev, ",", ".")
                                End If
                                If IsDBNull(DetalleDevDataGridView.Rows(i).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                                    Precio = "NULL"
                                Else
                                    Precio = DetalleDevDataGridView.Rows(i).Cells("PrecioNetoGrilla").Value
                                    Precio = Replace(Precio, ",", ".")
                                End If

                                existe = w.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO = " & CodProductoDev & " AND CODCODIGO=" & CodCodigo & " AND CODDEPOSITO", CmbDeposito.SelectedValue)

                                ser.Abrir(sqlc)
                                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                                cmd.Connection = sqlc
                                cmd.Transaction = myTrans
                                Try
                                    sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,STOCK) " & _
                                    "VALUES(" & UsuCodigo & "," & CodCodigo & "," & CmbDeposito.SelectedValue & ",CONVERT(Datetime,'" & Concatenar & "',103),11," & CodDevolucionTextBox.Text & _
                                    "," & CantidadDev & "," & Precio & ",'Devolucion de Venta Nro " & NroNCLabel.Text & "',0,1)"

                                    sql = sql + " UPDATE DEVOLUCIONDETALLE SET DESCARTAR=1 where CODDEVOLDET=" & DetalleDevDataGridView.Rows(i).Cells("CODDEVOLDET").Value

                                    cmd.CommandText = sql
                                    cmd.ExecuteNonQuery()

                                    myTrans.Commit()
                                Catch ex As Exception
                                    Try
                                        myTrans.Rollback("Actualizar")
                                    Catch
                                    End Try
                                    MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                                sqlc.Close()
                            Next
                        Else 'ERA SI AHORA CAMBIAMOS A NO - eliminamos el movimiento
                            For i = 0 To DetalleDevDataGridView.RowCount - 1
                                'verificamos si existe o no el producto para saber si modificamos o insertamos
                                If IsDBNull(DetalleDevDataGridView.Rows(i).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) Then
                                    CodProductoDev = "NULL"
                                    'Exit Sub
                                Else
                                    CodProductoDev = DetalleDevDataGridView.Rows(i).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                                    If IsDBNull(DetalleDevDataGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                                        CodCodigo = "NULL"
                                    Else
                                        CodCodigo = DetalleDevDataGridView.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                                    End If
                                    If IsDBNull(DetalleDevDataGridView.Rows(i).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                                        CantidadDev = "NULL"
                                    Else
                                        CantidadDev = DetalleDevDataGridView.Rows(i).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                                        CantidadDev = Replace(CantidadDev, ",", ".")
                                    End If
                                    If IsDBNull(DetalleDevDataGridView.Rows(i).Cells("PrecioNetoGrilla").Value) Then
                                        Precio = "NULL"
                                    Else
                                        Precio = Math.Round(DetalleDevDataGridView.Rows(i).Cells("PrecioNetoGrilla").Value, 2)
                                        Precio = Replace(Precio, ",", ".")
                                    End If
                                End If

                                existe = w.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO = " & CodProductoDev & " AND CODCODIGO=" & CodCodigo & " AND CODDEPOSITO", CmbDeposito.SelectedValue)

                                ser.Abrir(sqlc)
                                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                                cmd.Connection = sqlc
                                cmd.Transaction = myTrans


                                Try
                                    sql = "DELETE MOVPRODUCTO WHERE CODCODIGO=" & CodCodigo & " AND CODDEPOSITO=" & CmbDeposito.SelectedValue & "AND MODULO=11 AND MODULOTRANSID=" & CodDevolucionTextBox.Text & " AND CANTIDAD=" & CantidadDev & " AND VALOR= " & Precio & " AND COSTEABLE=0 AND STOCK=1 "
                                    sql = sql + " UPDATE DEVOLUCIONDETALLE SET DESCARTAR=0 where CODDEVOLDET=" & DetalleDevDataGridView.Rows(i).Cells("CODDEVOLDET").Value

                                    cmd.CommandText = sql
                                    cmd.ExecuteNonQuery()

                                    myTrans.Commit()

                                Catch ex As Exception
                                    Try
                                        myTrans.Rollback("Actualizar")
                                    Catch
                                    End Try
                                    MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    'Cancelamos todo :(
                                Finally
                                    sqlc.Close()
                                End Try
                            Next
                        End If
                        Dim codDevTemp As Integer

                        codDevTemp = Me.CodDevolucionTextBox.Text
                        FechaFiltro()
                        Me.DEVOLUCIONTableAdapter.Fill(Me.DsDevoluciones.DEVOLUCION, FechaFiltro1, FechaFiltro2)

                        'Buscamos la posicion del registro guardado
                        For i = 0 To DevolucionesDataGridView.RowCount - 1
                            If DevolucionesDataGridView.Rows(i).Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value = codDevTemp Then
                                DEVOLUCIONBindingSource.Position = i
                                Exit For
                            End If
                        Next
                        DevolucionesDataGridView_SelectionChanged(Nothing, Nothing)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgwClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgwClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim pos As Integer = dgwClientes.CurrentRow.Index
            Dim cantReg As Integer = dgwClientes.RowCount - 1
            Dim CodVendedor As String
            Dim CodCliente As Integer

            'If (pos <> 0) And (pos <> cantReg) Then
            'pos = pos + 1
            'End If

            If dgwClientes.RowCount <> 0 Then
                ClienteComboBox.SelectedValue = dgwClientes.Rows(pos).Cells("CODCLIENTE").Value
                'txtNrodeCliente.Text = dgwClientes.Rows(pos).Cells("NUMCLIENTE1").Value

                If IsDBNull(dgwClientes.Rows(pos).Cells("NUMCLIENTE1").Value) Then
                Else
                    txtNrodeCliente.Text = dgwClientes.Rows(pos).Cells("NUMCLIENTE1").Value
                End If

                If IsDBNull(dgwClientes.Rows(pos).Cells("CODTIPOCLIENTE").Value) Then
                Else
                    CodListaPrecio = dgwClientes.Rows(pos).Cells("CODTIPOCLIENTE").Value
                End If

                lblNombreFantasia.Visible = True
                lblNombreFantasia.Text = w.FuncionConsultaString("NOMBREFANTASIA", "CLIENTES", "CODCLIENTE", dgwClientes.Rows(pos).Cells("CODCLIENTE").Value)

                CodVendedor = w.FuncionConsulta("codvendedor", "clientes", "codcliente", dgwClientes.Rows(pos).Cells("CODCLIENTE").Value)
                Try
                    VendendorComboBox.SelectedValue = CDec(CodVendedor)
                Catch ex As Exception
                End Try

                Dim codzona, CodDep, CodCiu As Integer
                Dim Departamento, Ciudad, Zona As String

                CodCliente = dgwClientes.Rows(pos).Cells("CODCLIENTE").Value
                txtNrodeCliente.Text = w.FuncionConsultaString("numcliente", "clientes", "codcliente", CodCliente)

                If Config4 = "Mostrar Localizacion del Cliente" Then
                    codzona = w.FuncionConsulta("codzona", "clientes", "CAST(codcliente AS VARCHAR)", CodCliente)

                    CodDep = w.FuncionConsulta("CODDEPARTAMENTO", "CLIENTES", "codcliente", CodCliente)
                    Departamento = w.FuncionConsultaString("DESPAIS", "PAIS", "CODPAIS", CodDep)

                    CodCiu = w.FuncionConsulta("CODCIUDAD", "CLIENTES", "codcliente", CodCliente)
                    Ciudad = w.FuncionConsultaString("DESCIUDAD", "CIUDAD", "CODCIUDAD", CodCiu)

                    Zona = w.FuncionConsultaString("DESZONA", "ZONA", "CODZONA", codzona)

                    txtLocalizacion.Text = Departamento + " / " + Ciudad + " / " + Zona

                ElseIf Config4 = "Mostrar Dirección del Cliente" Then
                    txtLocalizacionDir.Text = w.FuncionConsultaString("DIRECCION", "CLIENTES", "CODCLIENTE", CodCliente)
                End If
            End If
            upcClientes.Close()
            ClienteComboBox.Focus()
            Me.Refresh()

        End If
    End Sub

    Private Sub DetalleDevDataGridView_DoubleClick(sender As Object, e As System.EventArgs) Handles DetalleDevDataGridView.DoubleClick
        AddButton.Text = "Modificar"
        ElimButton.Text = "Cancelar"
        AddButton.Visible = True
        AddButton.Enabled = True
        ElimButton.Visible = True
        ElimButton.Enabled = True
        CantidadTextBox.Focus()
        If TxtEstado.Text = "0" Or TxtEstado.Text = "" Or TxtEstado.Text = "3" Then
            Try
                If IsDBNull(DetalleDevDataGridView.CurrentRow) Then
                    Exit Sub
                Else
                    vgCodCodigo = DetalleDevDataGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value
                    vgCodProducto = DetalleDevDataGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                    vgDevoluciones = DetalleDevDataGridView.CurrentRow.Index
                    Dim LineaVenta As Integer = CInt(DetalleDevDataGridView.CurrentRow.Index)
                    DetalleDevDataGridView.BeginEdit(True)

                    If IsDBNull(DetalleDevDataGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) Then
                        txtCodigo.Text = ""
                    Else
                        txtCodigo.Text = DetalleDevDataGridView.CurrentRow.Cells("CODIGOPROD").Value
                    End If

                    If IsDBNull(DetalleDevDataGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value) Then
                        txtCodigo.Text = ""
                        CodCodigoTextBox.Text = ""
                    Else
                        CodProductoTextBox.Text = DetalleDevDataGridView.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                        CodCodigoTextBox.Text = DetalleDevDataGridView.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value
                        CodVentaTextBox.Text = ""
                    End If

                    CantidadTextBox.Text = CDec(DetalleDevDataGridView.CurrentRow.Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value)
                    txtPrecio.Text = CDec(DetalleDevDataGridView.CurrentRow.Cells("PrecioNetoGrilla").Value)
                    txtProductoDescripcion.Text = DetalleDevDataGridView.CurrentRow.Cells("ProductoGrilla").Value

                End If
            Catch ex As Exception

            End Try
            DetalleDevDataGridView.Enabled = False
            ElimButton.Text = "Cancelar"
        End If
    End Sub

    Private Sub cbxOtrasListas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxOtrasListas.CheckedChanged
        vendermasquestock = permisostockneg
        CODIGOBindingSource.RemoveFilter()
        If cbxOtrasListas.Checked = True Then
            If vendermasquestock = 1 Then 'tiene permiso
                Me.CODIGOTableAdapter.FillBySinStockTDPrecios(DsDevoluciones.CODIGO, CInt(CmbDeposito.SelectedValue))
                upcProdcutoCodigo.Show()
                txtBuscarCodigoProducto.Focus()
            ElseIf vendermasquestock = 0 Then
                Me.CODIGOTableAdapter.FillByTodos(DsDevoluciones.CODIGO, CInt(CmbDeposito.SelectedValue))
                upcProdcutoCodigo.Show()
                txtBuscarCodigoProducto.Focus()
            End If
        Else
            If vendermasquestock = 1 Then 'tiene permiso
                Me.CODIGOTableAdapter.FillBySinStock(DsDevoluciones.CODIGO, CInt(CmbDeposito.SelectedValue), CodListaPrecio)
                upcProdcutoCodigo.Show()
                txtBuscarCodigoProducto.Focus()
            ElseIf vendermasquestock = 0 Then
                Me.CODIGOTableAdapter.Fill(DsDevoluciones.CODIGO, CInt(CmbDeposito.SelectedValue), CodListaPrecio)
                upcProdcutoCodigo.Show()
                txtBuscarCodigoProducto.Focus()
            End If
        End If
    End Sub

    Private Sub btBuscarCliente_Click(sender As System.Object, e As System.EventArgs) Handles btBuscarCliente.Click
        upcClientes.Show()
        tbxBuscarCliente.Focus()
    End Sub

    Private Sub btnGuardarConceptoAnul_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardarConceptoAnul.Click
        Try
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            sql = "UPDATE DEVOLUCION SET MOTIVOANULADO = '" & TxtMotivodeAnulacion.Text & "' WHERE CODDEVOLUCION= " & CDec(CodDevolucionTextBox.Text) & ""

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            MessageBox.Show("Motivo Guardado con Exito!!", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error en la Operación", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub btnAstericoProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnAstericoProducto.Click
        If cbxRelacionarFactura.Text = "Si" Then
            If CodVentaTextBox.Text <> "" Then
                If Config5 = "Permitir Cargar otros Items como Detalle" Then
                    GoTo todoslosprod
                End If
                Try
                    VENTASDETALLETableAdapter.Fill(DsDevoluciones.VENTASDETALLE, CodVentaTextBox.Text)
                Catch ex As Exception
                End Try

                ProductosGroupBox.Visible = True
                ProductosGroupBox.BringToFront()
                BuscarProductoTextBox.Focus()
            Else
                MessageBox.Show("Primero seleccione la Venta para Filtrar los Productos", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroFactura.Focus()
                Exit Sub
            End If
        Else
todoslosprod:
            vendermasquestock = permisostockneg
            If vendermasquestock = 1 Then 'tiene permiso
                Me.CODIGOTableAdapter.FillBySinStock(DsDevoluciones.CODIGO, CInt(CmbDeposito.SelectedValue), CodListaPrecio)
                upcProdcutoCodigo.Show()
                txtBuscarCodigoProducto.Focus()
            ElseIf vendermasquestock = 0 Then
                Me.CODIGOTableAdapter.Fill(DsDevoluciones.CODIGO, CInt(CmbDeposito.SelectedValue), CodListaPrecio)
                upcProdcutoCodigo.Show()
                txtBuscarCodigoProducto.Focus()
            End If
        End If
    End Sub

End Class


