Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class DevolucionCompra
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Private conexion As System.Data.SqlClient.SqlConnection
    Private objCommand As New SqlCommand
    Dim sql As String
    Dim dtIva As DataTable
    Dim dr2 As DataRow
    Dim permiso As Double
    Dim Mes As String, Año As String
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim w As New Funciones.Funciones
    Dim errorFiltroFecha As Integer = 0
    Dim errorFiltroRango As Integer = 0
    Dim btduplicar As Integer = 0
    Dim DescontarMonto As Integer
    Dim AccBtNuevo As Integer
    Dim Descarte, MotivoDescartar, NumDevolucion As String
    Dim Config1, Config2, Config3, Config4, Config5, Config6 As String
    Dim VGCodDevolucion, VGCodigoCompra, VGSaldo, SiDEV, MontoFactura As Integer
    Dim TotalDev, TotalExenta, TotalGravada, TotalIva5, TotalIva10, Cotizacion1, Cotizacion2 As String
    Dim NroFacturaRelActual As String = ""
    Dim vendermasquestock As Integer
    Dim vgLineaDetalle As Integer
    Dim AccNuevo, AccEditar, modifdet As Integer
    Dim vgCodCodigo, vgCodProducto, vgCodCabecera, vgLineaConsumo As Integer
    Dim vNuevo As Boolean = True
    Dim VNuevoInsertar As Integer
    Dim changingselection, YatengoFact As Boolean
    Dim Max As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub DevolucionCompra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

        If e.KeyCode = Keys.Escape Then 'ESC
            upcProveedores.Close()
            upcProdcutoCodigo.Close()
            upcFacturasCompras.Close()
            upcProductosFactura.Close()
            upcProdcutoCodigo.Close()
        End If
    End Sub

    Private Sub DevolucionCompra_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 215)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        ModificarPictureBox.Enabled = True
        ObtenerConfig()

        Me.SUCURSALTableAdapter.Fill(Me.DsDevolucionCompra.SUCURSAL)
        Me.MONEDATableAdapter.Fill(Me.DsDevolucionCompra.MONEDA)
        Me.TIPOCOMPROBANTETableAdapter.Fill(Me.DsDevolucionCompra.TIPOCOMPROBANTE)
        Me.PROVEEDORTableAdapter.Fill(Me.DsDevolucionCompra.PROVEEDOR)
        Me.IvaDevCompraTableAdapter1.Fill(Me.DsDevolucionCompra.IVADevCompra)

        tbxTimbrado.Visible = True
        tbxTimbrado.BringToFront()
        Label14.Visible = True
        Label14.BringToFront()

        dtIva = IvaDevCompraTableAdapter1.GetData()

        InicializaFechaFiltro()
        Me.DEVOLUCIONCOMPRATableAdapter.Fill(Me.DsDevolucionCompra.DEVOLUCIONCOMPRA, FechaFiltro1, FechaFiltro2)
        Try
            DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)
        Catch ex As Exception
        End Try
        lblDGVCant.Text = "Cant. de Items:" & DevolucionesDataGridView.RowCount

        CmbMoneda.SelectedValue = CDec(CODMONEDAPRINCIPAL)

        If CmbMoneda.SelectedValue <> Nothing Then
            Cot1FactTextBox.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(CmbMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
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
            RecorreDetalleDevolucion()
            VNuevoInsertar = dgwDetalleDev.RowCount
        End If

        Deshabilita()
        TxtEstado_TextChanged(Nothing, Nothing)
        PintarCeldas()
        AccBtNuevo = 0
        btnEditar.Visible = False
        btnCancelar.Visible = False
    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1, CONFIG2,CONFIG3, CONFIG4,CONFIG5,CONFIG6 FROM MODULO WHERE MODULO_ID = 29"
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
    End Sub

    Private Sub Deshabilita()
        DevolucionesDataGridView.Enabled = True
        dgwDetalleDev.Enabled = False
        BuscarDevolucionTextBox.Enabled = True

        CmbMoneda.Enabled = False
        IngresarCotCheckBox.Enabled = False
        cbxDescontarMonto.Enabled = False

        'filtro Fechas
        CmbAño.Enabled = True
        CmbMes.Enabled = True
        BtnFiltro.Enabled = True

        txtNroFactura.Enabled = False
        TipoComprobanteComboBox.Enabled = False
        cbxTipoDevolucion.Enabled = False
        dtpFechaDev.Enabled = False
        cbxProveedor.Enabled = False
        txtNroDevolucion.Enabled = False
        cbxDevOtrosDepositos.Enabled = False
        txtNroProveedor.Enabled = False
        IvaIncluidoComboBox.Enabled = False

        'Botonsillos
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        pbBuscarProducto.Enabled = False
        pbBuscadorProveedor.Enabled = False
        btBuscarFactura.Enabled = False

        'detalle
        txtCodigo.Enabled = False
        txtCantidad.Enabled = False
        cbxDescartar.Enabled = False
        txtMotivoDescarte.Enabled = False
        CmbDeposito.Enabled = False
        cbxIva.Enabled = False
        cbxTipoItem.Enabled = False
        txtPrecio.Enabled = False
        cbxRelacionarFactura.Enabled = False
    End Sub

    Private Sub Habilita()
        DevolucionesDataGridView.Enabled = False
        BuscarDevolucionTextBox.Enabled = False
        dgwDetalleDev.Enabled = True

        CmbMoneda.Enabled = True
        IngresarCotCheckBox.Enabled = True
        cbxDescontarMonto.Enabled = True

        CmbAño.Enabled = False
        CmbMes.Enabled = False
        BtnFiltro.Enabled = False

        txtNroFactura.Enabled = True
        TipoComprobanteComboBox.Enabled = True
        cbxTipoDevolucion.Enabled = True
        dtpFechaDev.Enabled = True
        cbxProveedor.Enabled = True
        txtNroDevolucion.Enabled = True
        cbxDevOtrosDepositos.Enabled = True
        txtNroProveedor.Enabled = True
        IvaIncluidoComboBox.Enabled = True

        'Botonsillos
        btnAgregar.Enabled = True
        btnEliminar.Enabled = True
        pbBuscarProducto.Enabled = True
        pbBuscadorProveedor.Enabled = True
        btBuscarFactura.Enabled = True

        'detalle
        txtCodigo.Enabled = True
        txtCantidad.Enabled = True
        cbxDescartar.Enabled = True
        txtMotivoDescarte.Enabled = True
        CmbDeposito.Enabled = True
        cbxIva.Enabled = True
        cbxTipoItem.Enabled = True
        txtPrecio.Enabled = True
        cbxRelacionarFactura.Enabled = True
    End Sub

    Private Sub cbxProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxProveedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtNroDevolucion.Focus()
        End If
        If KeyAscii = 42 Then
            upcProveedores.Show()
            tbxBuscarProveedores.Focus()
            e.Handled = True
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 43)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso crear una nueva devolución", "Pos Express")
            Exit Sub
        Else
            Habilita()


            DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, 0)
            DEVOLUCIONCOMPRABindingSource.AddNew()

            If CmbDeposito.Text = "" Then
                CmbDeposito.SelectedIndex = CmbDeposito.SelectedIndex + 1
            End If

            If TipoComprobanteComboBox.Text = "" Then
                Try
                    TipoComprobanteComboBox.SelectedIndex = TipoComprobanteComboBox.SelectedIndex + 1
                Catch ex As Exception

                End Try

            End If

            Max = w.Maximo("CODDEVOLUCION", "DEVOLUCIONCOMPRA")
            Max = Max + 1

            CancelarPictureBox.Visible = True : cbxTipoDevolucion.Text = "Devolucion" : cbxRelacionarFactura.Text = "No" : cbxDevOtrosDepositos.Text = "No"
            AccBtNuevo = 1 : TxtEstado.Text = "3" : cbxTipoItem.Text = "Producto" : tbxSeCobro.Text = "" : cbxDescartar.Text = Config1 : SiDEV = 0

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
                Dim MaxDev As Integer = w.Maximo("CODDEVOLUCION", "DEVOLUCIONCOMPRA")
                If MaxDev <> 0 Then
                    dtpFechaDev.Value = w.FuncionConsultaString("FECHADEVOLUCION", "DEVOLUCIONCOMPRA", "CODDEVOLUCION", MaxDev)
                End If
            End If

            CmbMoneda.SelectedValue = CDec(CODMONEDAPRINCIPAL)
            If CmbMoneda.SelectedValue <> Nothing Then
                Cot1FactTextBox.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", Str(CmbMoneda.SelectedValue) + " ORDER BY FECHAMOVIMIENTO DESC")
            End If

            txtIva10.Text = "" : txtIva5.Text = "" : txtExenta.Text = "" : txtTotalIva.Text = ""
            IvaIncluidoComboBox.Text = "Incluido"
            btnAgregar.Visible = True : btnEliminar.Visible = True
            btnEditar.Visible = False : btnCancelar.Visible = False
            txtNroProveedor.Focus()

        End If
    End Sub


    Private Sub dgwProveedores_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwProveedores.CellDoubleClick
        If dgwProveedores.RowCount <> 0 Then
            cbxProveedor.SelectedValue = dgwProveedores.CurrentRow.Cells("CODPROVEEDOR").Value
            txtNroProveedor.Text = dgwProveedores.CurrentRow.Cells("NUMPROVEEDORDataGridViewTextBoxColumn").Value
        End If

        Me.Refresh()
        upcProveedores.Close()
        cbxProveedor.Focus()
    End Sub

    Private Sub tbxBuscarProveedores_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbxBuscarProveedores.KeyDown
        If e.KeyCode = Keys.Escape Then 'ESC
            upcProveedores.Close()
        End If
    End Sub

    Private Sub tbxBuscarProveedores_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxBuscarProveedores.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgwProveedores.Select()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbxBuscarProveedores_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxBuscarProveedores.TextChanged
        PROVEEDORBindingSource.Filter = "NOMBRE LIKE '%" & tbxBuscarProveedores.Text & "%' OR RUC_CIN  LIKE '%" & tbxBuscarProveedores.Text & "%'"
    End Sub

    Private Sub TxtEstado_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtEstado.TextChanged
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

            NuevoPictureBox.Enabled = True
            tsNuevaDevoluc.Enabled = True
            NuevoPictureBox.Image = My.Resources.New_
            NuevoPictureBox.Cursor = Cursors.Hand
            EliminarPictureBox.Enabled = True
            tsEliminar.Enabled = True
            EliminarPictureBox.Image = My.Resources.Delete
            EliminarPictureBox.Cursor = Cursors.Hand
            ModificarPictureBox.Enabled = True
            tsEditar.Enabled = True
            ModificarPictureBox.Image = My.Resources.Edit
            ModificarPictureBox.Cursor = Cursors.Hand

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

            EliminarPictureBox.Enabled = False
            tsEliminar.Enabled = False
            EliminarPictureBox.Image = My.Resources.DeleteOff
            EliminarPictureBox.Cursor = Cursors.Arrow
            ModificarPictureBox.Enabled = False
            tsEditar.Enabled = True
            ModificarPictureBox.Image = My.Resources.EditOff
            ModificarPictureBox.Cursor = Cursors.Arrow
            btnAprobar.Enabled = False
            tsAprobar.Enabled = False
            btnAprobar.Image = My.Resources.ApproveOff
            btnAprobar.Cursor = Cursors.Arrow

            btnAnular.Enabled = True
            tsAnular.Enabled = True
            btnAnular.Image = My.Resources.Anull
            btnAnular.Cursor = Cursors.Hand

            PanelMotivoAnulacion.Visible = False
            TxtMotivodeAnulacion.Enabled = True
            BtnAnularMotivo.Enabled = True

        ElseIf TxtEstado.Text = "2" Then
            LblEstado.Text = "Anulado"
            LblEstado.ForeColor = Color.Maroon

            NuevoPictureBox.Enabled = True
            tsNuevaDevoluc.Enabled = True
            NuevoPictureBox.Image = My.Resources.New_
            NuevoPictureBox.Cursor = Cursors.Hand

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

            PanelMotivoAnulacion.Visible = True
            PanelMotivoAnulacion.BringToFront()
            TxtMotivodeAnulacion.Enabled = False
            BtnAnularMotivo.Enabled = False

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

        End If
    End Sub

    Private Sub txtNroDevolucion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDevolucion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbDeposito.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TipoComprobanteComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TipoComprobanteComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxTipoDevolucion.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxTipoDevolucion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoDevolucion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaDev.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtpFechaDev_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaDev.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtMotivoDescarte.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxRelacionarFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxRelacionarFactura.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxRelacionarFactura.Text = "No" Then
                CmbMoneda.Focus()
            ElseIf cbxRelacionarFactura.Text = "Si" Then
                txtNroFactura.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxRelacionarFactura_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxRelacionarFactura.SelectedIndexChanged
        If cbxRelacionarFactura.Text <> "" Then
            If cbxRelacionarFactura.Text = "No" Then
                txtNroFactura.Visible = False
                cbxTipoItem.Enabled = True
                cbxDescontarMonto.Visible = False
                btBuscarFactura.Visible = False

            ElseIf cbxRelacionarFactura.Text = "Si" Then
                txtNroFactura.Visible = True
                cbxDescontarMonto.Visible = True
                btBuscarFactura.Visible = True

                If Config4 = "Permitir Cargar otros Items como Detalle" Then
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

    Private Sub txtMotivoDescarte_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivoDescarte.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxRelacionarFactura.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CmbMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If IngresarCotCheckBox.Checked = True Then
                Cot1FactTextBox.Focus()
            Else
                IvaIncluidoComboBox.Focus()
            End If
            KeyAscii = 0
        End If
    End Sub

    Private Sub CmbMoneda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbMoneda.SelectedIndexChanged
        If AccBtNuevo = 1 Then
            Cot1FactTextBox.Text = CmbMoneda.SelectedValue
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

    Private Sub cbxTipoItem_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoItem.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxTipoItem.Text = "Producto" Then
                txtCodigo.Focus()
            Else
                txtProductoDescripcion.Focus()
            End If

            If KeyAscii = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cbxTipoItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxTipoItem.SelectedIndexChanged
        If cbxTipoItem.Text <> "" Then
            If cbxTipoItem.Text = "Producto" Then
                txtCodigo.Enabled = True
                txtProductoDescripcion.Enabled = False
                cbxDescartar.Text = "Descontar del Stock"
                cbxIva.Enabled = False
                txtCodigo.Focus()
            ElseIf cbxTipoItem.Text = "Item" Then
                txtCodigo.Enabled = False
                txtProductoDescripcion.Enabled = True
                cbxDescartar.Text = "NO Descontar del Stock"
                cbxIva.Enabled = True
                txtProductoDescripcion.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            If cbxRelacionarFactura.Text = "Si" Then
                If txtCodFacturaCompra.Text <> "" Then
                    Try
                        If Config4 = "Permitir Cargar otros Items como Detalle" Then
                            GoTo todoslosprod
                        End If
                        COMPRASDERTALLETableAdapter.Fill(DsDevolucionCompra.COMPRASDERTALLE, Me.txtCodFacturaCompra.Text)
                    Catch ex As Exception

                    End Try

                    upcProductosFactura.Show()
                    BuscarProductoTextBox.Focus()

                    e.Handled = True
                Else
                    MessageBox.Show("Primero seleccione la Compra para Filtrar los Productos", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNroFactura.Focus()
                    Exit Sub
                End If
            Else
todoslosprod:
                vendermasquestock = PermisoAplicado(UsuCodigo, 201)
                If vendermasquestock = 1 Then
                    Me.CODIGOTableAdapter.FillBy(DsDevolucionCompra.CODIGO, CInt(CmbDeposito.SelectedValue))
                    upcProdcutoCodigo.Show()
                    txtBuscarCodigoProducto.Focus()
                ElseIf vendermasquestock = 0 Then

                    Me.CODIGOTableAdapter.Fill(DsDevolucionCompra.CODIGO, CInt(CmbDeposito.SelectedValue))
                    upcProdcutoCodigo.Show()
                    txtBuscarCodigoProducto.Focus()
                End If
            End If
        End If

        If KeyAscii = 13 Then
            txtCantidad.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtProductoDescripcion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductoDescripcion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtCantidad.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CantidadTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtPrecio.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxDescartar.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxDescartar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxDescartar.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxIva.Enabled = False Then
                If btnAgregar.Visible = True Then
                    btnAgregar.Focus()
                Else
                    btnEditar.Focus()
                End If
            Else
                cbxIva.Focus()
            End If
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxIva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxIva.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If btnAgregar.Visible = True Then
                btnAgregar.Focus()
            Else
                btnEditar.Focus()
            End If

        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CmbDeposito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CmbDeposito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TipoComprobanteComboBox.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        DEVOLUCIONCOMPRABindingSource.CancelEdit()

        Deshabilita() : Limpiamos()
        TxtEstado.Text = "0"

        FechaFiltro()
        Me.DEVOLUCIONCOMPRATableAdapter.Fill(Me.DsDevolucionCompra.DEVOLUCIONCOMPRA, FechaFiltro1, FechaFiltro2)
        chxFacturasconSaldoCero.Checked = False : SiDEV = 0

        btnAprobar.Enabled = False
        tsAprobar.Enabled = False
        AccBtNuevo = 0
        btnAgregar.Visible = True : btnEliminar.Visible = True
        btnEditar.Visible = False : btnCancelar.Visible = False

        PintarCeldas()
    End Sub

    Private Sub txtCodigo_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigo.LostFocus
        Dim Iva As Integer
        ErrorCodigoLabel.Visible = False

        If cbxRelacionarFactura.Text = "No" Then
            If txtCodigo.Text <> "" Then
                objCommand.CommandText = "SELECT dbo.PRODUCTOS.CODPRODUCTO, dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CODIGOS.DESCODIGO1, dbo.PRODUCTOS.CODIVA   " & _
                                         "FROM dbo.PRODUCTOS INNER JOIN dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO  " & _
                                         "WHERE dbo.CODIGOS.CODIGO ='" & txtCodigo.Text & "'"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrProductoCodigo As SqlDataReader = objCommand.ExecuteReader()

                If odrProductoCodigo.HasRows Then
                    Do While odrProductoCodigo.Read()
                        Me.CodCodigoTextBox.Text = odrProductoCodigo("CODCODIGO")
                        Me.CodProductoTextBox.Text = odrProductoCodigo("CODPRODUCTO")
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
        End If
    End Sub

    Private Sub ProductosDataGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosDataGridView.CellDoubleClick

        If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value) Then
            txtCodigo.Text = ""
        Else
            txtCodigo.Text = ProductosDataGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
        End If

        If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CODCODIGO").Value) Then
            CodCodigoTextBox.Text = ""
        Else
            CodCodigoTextBox.Text = ProductosDataGridView.CurrentRow.Cells("CODCODIGO").Value
        End If

        If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CODPRODUCTO").Value) Then
            CodProductoTextBox.Text = ""
        Else
            CodProductoTextBox.Text = ProductosDataGridView.CurrentRow.Cells("CODPRODUCTO").Value
        End If

        If IsDBNull(ProductosDataGridView.CurrentRow.Cells("IVA").Value) Then
            cbxIva.Text = ""
        Else
            cbxIva.Text = ProductosDataGridView.CurrentRow.Cells("IVA").Value
        End If

        If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CANTIDADCOMPRADataGridViewTextBoxColumn").Value) Then
            txtCantidad.Text = ""
        Else
            txtCantidad.Text = ProductosDataGridView.CurrentRow.Cells("CANTIDADCOMPRADataGridViewTextBoxColumn").Value
        End If

        'Cantidad Real
        If IsDBNull(ProductosDataGridView.CurrentRow.Cells("CANTIDADCOMPRADataGridViewTextBoxColumn").Value) Then
            CantRealMaskedEdit.Text = ""
        Else
            CantRealMaskedEdit.Text = CDec(ProductosDataGridView.CurrentRow.Cells("CANTIDADCOMPRADataGridViewTextBoxColumn").Value) - CDec(ProductosDataGridView.CurrentRow.Cells("TOTALDEVUELTO").Value)
        End If

        If IsDBNull(ProductosDataGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value) Then
            txtProductoDescripcion.Text = ""
        Else
            txtProductoDescripcion.Text = ProductosDataGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
        End If

        If IsDBNull(ProductosDataGridView.CurrentRow.Cells("COSTOUNITARIODataGridViewTextBoxColumn").Value) Then
            txtPrecio.Text = ""
        Else
            txtPrecio.Text = ProductosDataGridView.CurrentRow.Cells("COSTOUNITARIODataGridViewTextBoxColumn").Value
        End If

        upcProductosFactura.Close()
        txtCantidad.Focus()
    End Sub

    Private Sub ProductosDataGridView_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ProductosDataGridView.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Dim pos As Integer = ProductosDataGridView.CurrentRow.Index
            Dim cantReg As Integer = ProductosDataGridView.RowCount - 1

            If (pos <> 0) And (pos <> cantReg) Then
                pos = pos - 1
            End If

            If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CODIGODataGridViewTextBoxColumn").Value) Then
                txtCodigo.Text = ""
            Else
                txtCodigo.Text = ProductosDataGridView.Rows(pos).Cells("CODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CODCODIGO").Value) Then
                CodCodigoTextBox.Text = ""
            Else
                CodCodigoTextBox.Text = ProductosDataGridView.Rows(pos).Cells("CODCODIGO").Value
            End If

            If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CODPRODUCTO").Value) Then
                CodProductoTextBox.Text = ""
            Else
                CodProductoTextBox.Text = ProductosDataGridView.Rows(pos).Cells("CODPRODUCTO").Value
            End If

            If IsDBNull(ProductosDataGridView.Rows(pos).Cells("IVA").Value) Then
                cbxIva.Text = ""
            Else
                cbxIva.Text = ProductosDataGridView.Rows(pos).Cells("IVA").Value
            End If

            If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CANTIDADCOMPRADataGridViewTextBoxColumn").Value) Then
                txtCantidad.Text = ""
            Else
                txtCantidad.Text = ProductosDataGridView.Rows(pos).Cells("CANTIDADCOMPRADataGridViewTextBoxColumn").Value
            End If

            'Cantidad Real
            If IsDBNull(ProductosDataGridView.Rows(pos).Cells("CANTIDADCOMPRADataGridViewTextBoxColumn").Value) Then
                CantRealMaskedEdit.Text = ""
            Else
                CantRealMaskedEdit.Text = CDec(ProductosDataGridView.Rows(pos).Cells("CANTIDADCOMPRADataGridViewTextBoxColumn").Value) - CDec(ProductosDataGridView.Rows(pos).Cells("TOTALDEVUELTO").Value)
            End If

            If IsDBNull(ProductosDataGridView.Rows(pos).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value) Then
                txtProductoDescripcion.Text = ""
            Else
                txtProductoDescripcion.Text = ProductosDataGridView.Rows(pos).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(ProductosDataGridView.Rows(pos).Cells("COSTOUNITARIODataGridViewTextBoxColumn").Value) Then
                txtPrecio.Text = ""
            Else
                txtPrecio.Text = ProductosDataGridView.Rows(pos).Cells("COSTOUNITARIODataGridViewTextBoxColumn").Value
            End If

            upcProductosFactura.Close()
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub BuscarProductoTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles BuscarProductoTextBox.KeyDown
        If e.KeyCode = Keys.Escape Then 'ESC
            upcProductosFactura.Close()
        End If
    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProductosDataGridView.Select()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        Me.COMPRASDERTALLEBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
    End Sub

    Private Sub BuscaFacturaTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles BuscaFacturaTextBox.KeyDown
        If e.KeyCode = Keys.Escape Then 'ESC
            upcFacturasCompras.Close()
        End If
    End Sub

    Private Sub BuscaFacturaTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscaFacturaTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgwCompras.Select()
        End If
    End Sub

    Private Sub BuscaFacturaTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscaFacturaTextBox.TextChanged
        COMPRASBindingSource.Filter = "NUMCOMPRA LIKE '%" & BuscaFacturaTextBox.Text & "%'"
    End Sub

    Private Sub txtNroFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroFactura.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 42 Then
            If cbxProveedor.SelectedValue <> Nothing Then
                'ANTES DE MOSTRAR EL FILTRO DE FACTURAS SE DEBE VERIFICAR SI DESEA FILTRAR SIN IMPORTAR EL DESPOSITO O SOLO DEL DEPOSITO SELECCIONADO
                upcFacturasCompras.Show()
                BuscaFacturaTextBox.Focus()
                Try
                    If cbxDevOtrosDepositos.Text = "Si" Then
                        COMPRASTableAdapter.Fill(DsDevolucionCompra.COMPRAS, cbxProveedor.SelectedValue)
                    ElseIf cbxDevOtrosDepositos.Text = "No" Then
                        COMPRASTableAdapter.FillBy(DsDevolucionCompra.COMPRAS, cbxProveedor.SelectedValue, CmbDeposito.SelectedValue)
                    End If
                Catch ex As Exception
                End Try
                chxFacturasconSaldoCero.Checked = False
                'If dgwCompras.RowCount = 0 Then
                '    MsgBox("El Proveedor no cuenta con Compras disponibles")
                '    dgwCompras.SendToBack()
                '    txtNroFactura.Text = ""
                '    Exit Sub
                'Else
                '    e.Handled = True
                'End If

            Else
                MessageBox.Show("Primero seleccione el Proveedor para Filtrar las Compras", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxProveedor.Select()
                Exit Sub
            End If
        End If
        'End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 13 Then
            CmbMoneda.Focus()
        End If
    End Sub

    Private Sub dgwCompras_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwCompras.CellDoubleClick
        Try
            If IsDBNull(dgwCompras.CurrentRow.Cells("CODCOMPRA").Value) Then
                txtCodFacturaCompra.Text = ""
                VGCodigoCompra = 0
                VGSaldo = 0
            Else
                txtCodFacturaCompra.Text = dgwCompras.CurrentRow.Cells("CODCOMPRA").Value
                VGCodigoCompra = dgwCompras.CurrentRow.Cells("CODCOMPRA").Value

                If dgwCompras.CurrentRow.Cells("SALDO").Value = 0 Then
                    VGSaldo = dgwCompras.CurrentRow.Cells("SALDODV").Value
                    SiDEV = 1
                Else
                    VGSaldo = dgwCompras.CurrentRow.Cells("SALDO").Value
                    SiDEV = 0
                End If
            End If

            If IsDBNull(dgwCompras.CurrentRow.Cells("NUMCOMPRA").Value) Then
            Else
                txtNroFactura.Text = dgwCompras.CurrentRow.Cells("NUMCOMPRA").Value
            End If

            upcFacturasCompras.Close()
            txtCodigo.Focus()
        Catch ex As Exception
            upcFacturasCompras.Close()
        End Try
    End Sub

    Private Sub dgwCompras_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgwCompras.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Dim pos As Integer = dgwCompras.CurrentRow.Index
            Dim cantReg As Integer = dgwCompras.RowCount - 1

            If (pos <> 0) And (pos <> cantReg) Then
                pos = pos - 1
            End If

            Try
                If IsDBNull(dgwCompras.Rows(pos).Cells("CODCOMPRA").Value) Then
                    txtCodFacturaCompra.Text = ""
                    VGCodigoCompra = 0
                    VGSaldo = 0
                Else
                    txtCodFacturaCompra.Text = dgwCompras.Rows(pos).Cells("CODCOMPRA").Value
                    VGCodigoCompra = dgwCompras.Rows(pos).Cells("CODCOMPRA").Value

                    If dgwCompras.Rows(pos).Cells("SALDO").Value = 0 Then
                        VGSaldo = dgwCompras.Rows(pos).Cells("SALDODV").Value
                        SiDEV = 1
                    Else
                        VGSaldo = dgwCompras.Rows(pos).Cells("SALDO").Value
                        SiDEV = 0
                    End If
                End If

                If IsDBNull(dgwCompras.Rows(pos).Cells("NUMCOMPRA").Value) Then
                Else
                    txtNroFactura.Text = dgwCompras.Rows(pos).Cells("NUMCOMPRA").Value
                End If

                upcFacturasCompras.Close()
                txtCodigo.Focus()
            Catch ex As Exception
                upcFacturasCompras.Close()
            End Try
        End If
    End Sub

    Private Sub txtBuscarCodigoProducto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarCodigoProducto.KeyDown
        If e.KeyCode = Keys.Escape Then 'ESC
            upcProdcutoCodigo.Close()
        End If
    End Sub

    Private Sub txtBuscarCodigoProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarCodigoProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgwProductoCodigo.Select()
        End If
    End Sub

    Private Sub txtBuscarCodigoProducto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarCodigoProducto.TextChanged
        Me.CODIGOBindingSource.Filter = "DESPRODUCTO LIKE '%" & txtBuscarCodigoProducto.Text & "%' OR CODIGO LIKE '%" & txtBuscarCodigoProducto.Text & "%'"
    End Sub

    Private Sub dgwProductoCodigo_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwProductoCodigo.CellDoubleClick
        If dgwProductoCodigo.RowCount <> 0 Then
            Try
                Dim Iva As Integer
                vgCodCodigo = Me.dgwProductoCodigo.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value
                CodCodigoTextBox.Text = Me.dgwProductoCodigo.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value
                CodProductoTextBox.Text = Me.dgwProductoCodigo.CurrentRow.Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                txtCodigo.Text = Me.dgwProductoCodigo.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn1").Value
                txtProductoDescripcion.Text = Me.dgwProductoCodigo.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value
                Iva = Me.dgwProductoCodigo.CurrentRow.Cells("CODIVADataGridViewTextBoxColumn").Value

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

                upcProdcutoCodigo.Close()
            Catch ex As Exception

            End Try
        End If
        txtCantidad.Focus()
    End Sub

    Private Sub dgwProductoCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgwProductoCodigo.KeyPress
        If dgwProductoCodigo.RowCount <> 0 Then
            Dim pos As Integer = dgwProductoCodigo.CurrentRow.Index
            Dim cantReg As Integer = dgwProductoCodigo.RowCount - 1

            If (pos <> 0) And (pos <> cantReg) Then
                pos = pos - 1
            End If

            Try
                Dim Iva As Integer
                vgCodCodigo = Me.dgwProductoCodigo.Rows(pos).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                CodCodigoTextBox.Text = Me.dgwProductoCodigo.Rows(pos).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                CodProductoTextBox.Text = Me.dgwProductoCodigo.Rows(pos).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value
                txtCodigo.Text = Me.dgwProductoCodigo.Rows(pos).Cells("CODIGODataGridViewTextBoxColumn1").Value
                txtProductoDescripcion.Text = Me.dgwProductoCodigo.Rows(pos).Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value
                Iva = Me.dgwProductoCodigo.Rows(pos).Cells("CODIVADataGridViewTextBoxColumn").Value

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

                upcProdcutoCodigo.Close()
            Catch ex As Exception

            End Try
        End If
        txtCantidad.Focus()
    End Sub

    Private Sub AddButton_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click

        'valida el valor en cantidad
        If String.IsNullOrEmpty(txtCantidad.Text) Then
            MessageBox.Show("Ingrese la Cantidad para el nuevo detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCantidad.Focus()
            Exit Sub
        Else
            If CDec(txtCantidad.Text) = 0 Then
                MessageBox.Show("Ingrese una cantidad mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCantidad.Focus()
                Exit Sub
            End If
        End If
        'valida el valor del Precio
        If String.IsNullOrEmpty(txtPrecio.Text) Then
            MessageBox.Show("Ingrese el precio para el nuevo detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPrecio.Focus()
            Exit Sub
        Else
            If CDec(txtPrecio.Text) = 0 Then
                MessageBox.Show("Ingrese un precio mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPrecio.Focus()
                Exit Sub
            End If
        End If

        If cbxTipoItem.Text <> "Item" Then
            If CodCodigoTextBox.Text = "" Or CodProductoTextBox.Text = "" Then
                MessageBox.Show("Seleccione un Producto o Combo para el nuevo detalle", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCodigo.Focus()
                Exit Sub
            End If
        Else
            If cbxIva.Text = "" Then
                MessageBox.Show("Seleccione el IVA para el Item", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxIva.Focus()
                Exit Sub
            End If

        End If

        If CmbDeposito.Text = "" Then
            MessageBox.Show("Seleccione un Deposito", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CmbDeposito.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtCantidad.Text) Then
            MessageBox.Show("Ingrese la Cantidad Devuelta para el nuevo detalle", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCantidad.Focus()
            Exit Sub
        ElseIf CDec(txtCantidad.Text) = 0 Then
            MessageBox.Show("Ingrese la Cantidad Devuelta mayor a cero para el nuevo detalle", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCantidad.Focus()
            Exit Sub
        End If

        Try
            If CDec(txtCantidad.Text) > CDec(CantRealMaskedEdit.Text) Then
                MessageBox.Show("La Cantidad Devuelta no puede ser mayor a la Comprada", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCantidad.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try

        If cbxDescartar.Text = "NO Descontar del Stock" Then
            Descarte = "0"
        Else
            Descarte = "1"
        End If

        Dim x As Integer = dgwDetalleDev.RowCount
        For x = 1 To x
            Try
                If IsDBNull(dgwDetalleDev.Rows(x - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                Else
                    If CodCodigoTextBox.Text = dgwDetalleDev.Rows(x - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value Then
                        MessageBox.Show("El Producto ya se encuentra en el detalle", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
            End Try
        Next

        'pasamos los datos a la grilla
        DEVOLUCIONCOMPRADETALLEBindingSource.AddNew()
        Dim c As Integer = dgwDetalleDev.RowCount

        'Verificamos si marco la opcion con Iva Incluido o Sin Iva, para saber si calcular el Iva.
        Dim coheficiente, costo As Double
        Dim Iva As Integer

        For i = 0 To dtIva.Rows.Count - 1
            dr2 = dtIva.Rows(i)
            If FormatNumber(dr2("PORCENTAJEIVA"), 0) = cbxIva.Text Then
                coheficiente = dr2("COHEFICIENTE")
            End If
        Next

        costo = CDec(txtPrecio.Text)
        If IvaIncluidoComboBox.Text = "No Incluido" Then
            costo = costo * coheficiente
        End If

        If cbxIva.Text = "" Then
            Iva = 0
        Else
            Iva = CDec(cbxIva.Text)
        End If

        dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value = CDec(txtCantidad.Text)
        dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = Iva
        dgwDetalleDev.Rows(c - 1).Cells("PRECIONETODataGridViewTextBoxColumn").Value = costo
        dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value = Descarte
        dgwDetalleDev.Rows(c - 1).Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value = Me.txtProductoDescripcion.Text
        dgwDetalleDev.Rows(c - 1).Cells("CODDEVOLUCION").Value = Me.CodDevolucionTextBox.Text
        dgwDetalleDev.Rows(c - 1).Cells("EstadoGrilla").Value = "I" 'Insert

        If cbxTipoItem.Text = "Producto" Then
            dgwDetalleDev.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = CodCodigoTextBox.Text
            dgwDetalleDev.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value = CodProductoTextBox.Text
            dgwDetalleDev.Rows(c - 1).Cells("CODIGO").Value = txtCodigo.Text

            If cbxRelacionarFactura.Text = "Si" Then
                dgwDetalleDev.Rows(c - 1).Cells("CODCOMPRADataGridViewTextBoxColumn1").Value = txtCodFacturaCompra.Text
            End If
        End If

        RecorreDetalleDevolucion()
        Limpiamos()
        txtCodigo.Focus()
    End Sub

    Private Sub RecorreDetalleDevolucion()
        Dim c As Integer = dgwDetalleDev.RowCount
        Dim TotalG As Double = 0
        Dim TotalGravadaG As Double = 0
        Dim TotalExentaG As Double = 0
        Dim CodCodigo, CodProducto As String
        Dim DesProducto As String
        Dim Total, TotalDev As Double
        Dim Iva5, TIva5, Iva10, TIva10, Exenta, TExenta As Double

        TotalDev = 0 : TIva10 = 0 : TIva5 = 0 : TExenta = 0

        For c = 1 To c
            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                CodCodigo = ""
            Else
                CodCodigo = dgwDetalleDev.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
            End If
            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                CodProducto = ""
            Else
                CodProducto = dgwDetalleDev.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
            End If

            If CodProducto <> "" Then
                DesProducto = w.FuncionConsultaString("DESPRODUCTO", "PRODUCTOS", "CODPRODUCTO", CodProducto)
                dgwDetalleDev.Rows(c - 1).Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value = DesProducto
            End If

            'Cantidad
            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
            Else
                dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value = dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
            End If

            'Total
            Total = dgwDetalleDev.Rows(c - 1).Cells("PRECIONETODataGridViewTextBoxColumn").Value * dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
            dgwDetalleDev.Rows(c - 1).Cells("SubTotal").Value = Total
            TotalDev = TotalDev + Total

            'Iva
            If dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 10 Then
                Iva10 = Total / 11
                TIva10 = CDec(TIva10) + CDec(Iva10)
                txtIva10.Text = TIva10
                txtIva10.Text = FormatNumber(TIva10, 2)
                TIva5 = 0
            ElseIf dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 5 Then
                Iva5 = Total / 21
                TIva5 = CDec(TIva5) + CDec(Iva5)
                txtIva5.Text = TIva5
                txtIva5.Text = FormatNumber(TIva5, 2)
                TIva10 = 0
            ElseIf dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 0 Then
                Exenta = Total
                TExenta = CDec(TExenta) + CDec(Exenta)
                txtExenta.Text = TExenta
                txtExenta.Text = FormatNumber(TExenta, 2)
            End If

            txtTotalIva.Text = CDec(TIva10) + CDec(TIva5)
            txtTotalIva.Text = FormatNumber(txtTotalIva.Text, 2)

            'Descarte
            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value) Then
            Else
                If dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value = 1 Then
                    dgwDetalleDev.Rows(c - 1).Cells("AumentarStock").Value = "SI"
                ElseIf dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value = 0 Then
                    dgwDetalleDev.Rows(c - 1).Cells("AumentarStock").Value = "NO"
                End If
            End If
        Next

        txtIva10.Text = FormatNumber(TIva10, 2)
        txtIva5.Text = FormatNumber(TIva5, 2)
        txtExenta.Text = FormatNumber(TExenta, 2)

        TotalMaskedEdit.Text = TotalDev
    End Sub

    Private Sub ElimButton_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim Existe As Integer
        Dim CodigoABorrar As Integer

        If dgwDetalleDev.RowCount = 0 Then
            Exit Sub
        End If
        If IsDBNull(dgwDetalleDev.CurrentRow) Then
            Exit Sub
        Else
            CodigoABorrar = dgwDetalleDev.CurrentRow.Cells("CODDEVOLDETDataGridViewTextBoxColumn").Value
        End If

        Existe = w.FuncionConsulta("CODDEVOLDET", "DEVOLUCIONCOMPRADETALLE", "CODDEVOLDET", CodigoABorrar)
        If Existe > 0 Then
            Try
                ser.Abrir(sqlc)
                cmd.Connection = sqlc
                sql = ""
                sql = "DELETE DEVOLUCIONCOMPRADETALLE WHERE CODDEVOLDET = " & CodigoABorrar & ""
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                sqlc.Close()
            Catch ex As Exception
                MessageBox.Show("Error al eliminar el detalle", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)

        Else
            dgwDetalleDev.Rows.Remove(Me.dgwDetalleDev.CurrentRow)
        End If

        txtIva10.Text = 0 : txtIva5.Text = 0 : txtExenta.Text = 0 : txtTotalIva.Text = 0
        RecorreDetalleDevolucion()
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 217)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para modificar una devolución", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Habilita()
            TxtEstado.Text = "3"
            cbxDevOtrosDepositos.Text = "No" : TxtEstado.Text = "3" : cbxTipoItem.Text = "Producto" : IvaIncluidoComboBox.Text = "Incluido"

            If cbxRelacionarFactura.Text = "No" Then
                Me.txtNroFactura.Text = ""
            Else
                If Not IsDBNull(DevolucionesDataGridView.CurrentRow.Cells("CODCOMPRATextBoxColumn1").Value) Then
                    Dim saldofact As Integer = w.FuncionConsulta("SUM(SALDOCUOTA)", "FACTURAPAGAR", "CODCOMPRA", DevolucionesDataGridView.CurrentRow.Cells("CODCOMPRATextBoxColumn1").Value)
                    Dim totaldev As Integer = w.FuncionConsulta("SUM(TOTALDEVOLUCION)", "DEVOLUCIONCOMPRA", "(ESTADO=1) AND CODCOMPRA", DevolucionesDataGridView.CurrentRow.Cells("CODCOMPRATextBoxColumn1").Value)
                    Dim importeCompra As Integer = w.FuncionConsulta("TOTALCOMPRA", "COMPRAS", "CODCOMPRA", DevolucionesDataGridView.CurrentRow.Cells("CODCOMPRATextBoxColumn1").Value)
                    VGCodigoCompra = DevolucionesDataGridView.CurrentRow.Cells("CODCOMPRATextBoxColumn1").Value
                    If saldofact <> 0 Then
                        VGSaldo = saldofact
                        SiDEV = 0
                    Else
                        SiDEV = 1
                        VGSaldo = importeCompra - totaldev
                    End If
                End If
            End If

            dgwDetalleDev.Enabled = True
            NroFacturaRelActual = Me.txtNroFactura.Text
            Dim EstadoDev As Integer = w.FuncionConsultaDecimal("ESTADO", "DEVOLUCIONCOMPRA", "CODDEVOLUCION", CodDevolucionTextBox.Text)

            If (EstadoDev = 1) Then
                If txtNroFactura.Text <> "" Then 'no puede modificar el cliente si ya tiene una factura relacionada
                    cbxProveedor.Enabled = False
                End If
                Panel2.Enabled = False
            End If
        End If
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim CodDev, Existe As Integer
        Dim EstadoDev As Integer = 0

        If dgwDetalleDev.RowCount = 0 Then
            MessageBox.Show("Ingrese los detalles de la devolución para guardar", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CodDevolucionTextBox.Text = "" Then
            Exit Sub
        End If

        If dtpFechaDev.Text = Nothing Or dtpFechaDev.Text = "" Then
            MessageBox.Show("Ingrese la Fecha para la devolución", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtpFechaDev.Focus()
            Exit Sub
        End If

        If TipoComprobanteComboBox.SelectedValue = Nothing Then
            MessageBox.Show("Elija el Tipo de Comprobante para la devolución", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TipoComprobanteComboBox.Select()
            Exit Sub
        End If

        If cbxProveedor.SelectedValue = Nothing Then
            MessageBox.Show("Elija el Proveedor para la devolución", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxProveedor.Select()
            Exit Sub
        End If

        'SI ESTA APROBADA SE DEBE MODIFICAR ALGUNOS OTROS DATOS
        EstadoDev = w.FuncionConsultaDecimal("ESTADO", "DEVOLUCIONCOMPRA", "CODDEVOLUCION", CodDevolucionTextBox.Text)

        'Si esl estado es Aprobado y cambio el nro de factura anterior debemos avisar al usuario si el monto de la devolucion es mayor o menos al nro de factura
        If EstadoDev = 1 And NroFacturaRelActual <> Me.txtNroFactura.Text And Me.txtNroFactura.Text <> "" Then
            MontoFactura = w.FuncionConsulta("SUM(SALDOCUOTA)", "FACTURAPAGAR", "CODCOMPRA", VGCodigoCompra)

            If MontoFactura < CDec(TotalMaskedEdit.Text) Then
                If MessageBox.Show("El Saldo de la Nueva Factura es menor al Monto de la Devolución , ¿Desea Continuar?", "Cogent SIG", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If

        'Validar
        If cbxRelacionarFactura.Text = "Si" And EstadoDev = 0 Then
            If txtCodFacturaCompra.Text = "" Then
                MessageBox.Show("Elija la Compra para la devolución", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCodFacturaCompra.Focus()
                Exit Sub
            Else
                If CDec(TotalMaskedEdit.Text) > VGSaldo Then
                    If SiDEV = 1 Then
                        MessageBox.Show("El monto de la Devolución supera al Saldo de la Factura con respecto a Devoluciones Aplicables. El monto de la Devolución puede ser Menor o igual a " & VGSaldo & "", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCodFacturaCompra.Focus()
                        Exit Sub
                    Else
                        MessageBox.Show("El monto de la Devolución Supera al Saldo de la Factura", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCodFacturaCompra.Focus()
                        Exit Sub
                    End If
                End If
            End If
        ElseIf cbxRelacionarFactura.Text = "No" Then
            txtNroFactura.Text = ""
        End If

        If cbxTipoDevolucion.Text = "" Then
            MessageBox.Show("Elija el Tipo de Devolución", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxTipoDevolucion.Select()
            Exit Sub
        End If

        'Validar
        If cbxDescontarMonto.Checked = True Then
            If txtNroFactura.Text = "" Then
                DescontarMonto = 0
            Else
                DescontarMonto = 1
            End If
        Else
            DescontarMonto = 0
        End If

        If txtTotalIva.Text = "" Or txtTotalIva.Text = "0,00" Then
            TotalGravada = "0"
        Else
            TotalGravada = txtTotalIva.Text
            TotalGravada = Funciones.Cadenas.QuitarCad(TotalGravada, ".")
            TotalGravada = Replace(TotalGravada, ",", ".")
        End If

        If txtIva5.Text = "" Or txtIva5.Text = "0,00" Then
            TotalIva5 = "0"
        Else
            TotalIva5 = txtIva5.Text
            TotalIva5 = Funciones.Cadenas.QuitarCad(TotalIva5, ".")
            TotalIva5 = Replace(TotalIva5, ",", ".")
        End If

        If txtIva10.Text = "" Or txtIva10.Text = "0,00" Then
            TotalIva10 = "0"
        Else
            TotalIva10 = txtIva10.Text
            TotalIva10 = Funciones.Cadenas.QuitarCad(TotalIva10, ".")
            TotalIva10 = Replace(TotalIva10, ",", ".")
        End If

        If txtExenta.Text = "" Or txtExenta.Text = "0,00" Then
            TotalExenta = "0"
        Else
            TotalExenta = txtExenta.Text
            TotalExenta = Funciones.Cadenas.QuitarCad(TotalExenta, ".")
            TotalExenta = Replace(TotalExenta, ",", ".")
        End If

        If TotalMaskedEdit.Text = "" Or TotalMaskedEdit.Text = "0,00" Then
            TotalDev = "0"
        Else
            TotalDev = TotalMaskedEdit.Text
            TotalDev = Funciones.Cadenas.QuitarCad(TotalDev, ".")
            TotalDev = Replace(TotalDev, ",", ".")
        End If

        Cotizacion1 = Cot1FactTextBox.Text
        Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
        Cotizacion1 = Replace(Cotizacion1, ",", ".")
        NumDevolucion = txtNroDevolucion.Text

        Existe = w.FuncionConsulta("CODDEVOLUCION", "DEVOLUCIONCOMPRA", "CODDEVOLUCION", CDec(CodDevolucionTextBox.Text))

        Dim transaction As SqlTransaction = Nothing

        If Existe > 0 Then
            '############################################################################
            'Actualizar la factura. Solo se puede actualizar si el estado de la factura es Activa=0

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaDevolucion()
                ActualizaDetalleDev()

                myTrans.Commit()

                '#####################################################################
                'Cambiar el nro de la Factura una vez que se aprobo la devolucion
                ModificarNroFactura(EstadoDev)
                '#####################################################################
                If EstadoDev = 1 Then
                    MessageBox.Show("Operación finalizada con éxito", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error en la Operación", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                InsertaDetalleDev()

                myTrans.Commit()
                'MessageBox.Show("Operación finalizada con éxito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error en la Operación", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                sqlc.Close()
            End Try
        End If

        AccBtNuevo = 0
        Me.btnAprobar.Visible = True : TxtEstado.Text = "0"
        txtNroFactura.Visible = False : cbxTipoItem.Enabled = True : cbxDescontarMonto.Visible = False : chxFacturasconSaldoCero.Checked = False : SiDEV = 0

        CodDev = Me.CodDevolucionTextBox.Text
        FechaFiltro()

        Me.DEVOLUCIONCOMPRATableAdapter.Fill(Me.DsDevolucionCompra.DEVOLUCIONCOMPRA, FechaFiltro1, FechaFiltro2)

        'Buscamos la posicion del registro guardado
        For i = 0 To DevolucionesDataGridView.RowCount - 1
            If DevolucionesDataGridView.Rows(i).Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value = Max Then
                DEVOLUCIONCOMPRABindingSource.Position = i
            End If
        Next
      
        Try
            DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)
        Catch ex As Exception
        End Try

        Deshabilita()
        RecorreDetalleDevolucion()
        PintarCeldas()




    End Sub

    Private Sub InsertaDevolucion()
        Dim CodCompra As Integer
        Dim Motivo As String

        If cbxRelacionarFactura.Text = "Si" Then
            CodCompra = txtCodFacturaCompra.Text
        Else
            CodCompra = 0
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
        sql = "INSERT INTO DEVOLUCIONCOMPRA (CODPROVEEDOR, CODCOMPRA, CODMONEDA, CODSUCURSAL,FECHADEVOLUCION, TOTALEXENTA, TOTALIVA, TOTALDEVOLUCION, COTIZACION1, " & _
              "TOTALIVA5, TOTALIVA10, FECGRA, CODCOMPROBANTE, COBRADO,CODDEPOSITO, ESTADO,MOTIVODESCARTE, TIPODEVOLUCION,DESCONTARMONTO, NUMDEVOLUCION,SALDO, timbradoprov) " & _
              "VALUES (" & cbxProveedor.SelectedValue & ", " & CodCompra & ", " & CmbMoneda.SelectedValue & ", " & CmbDeposito.SelectedValue & ", " & _
              "CONVERT(DATETIME,'" & dtpFechaDev.Text & "',103), " & TotalExenta & ", " & TotalGravada & ", " & TotalDev & ", " & Cotizacion1 & ", " & TotalIva5 & ", " & TotalIva10 & _
              Cotizacion2 & ", CONVERT(DATETIME,'" & Today & "',103), " & TipoComprobanteComboBox.SelectedValue & ", 0, " & CmbDeposito.SelectedValue & ",0,'" & Motivo & "','" & Me.cbxTipoDevolucion.Text & "'," & _
              DescontarMonto & ",'" & txtNroDevolucion.Text & "', " & TotalDev & ", '" & tbxTimbrado.Text & "' )  " & _
              "SELECT CODDEVOLUCION FROM DEVOLUCIONCOMPRA WHERE CODDEVOLUCION = SCOPE_IDENTITY();"

        cmd.CommandText = sql
        VGCodDevolucion = cmd.ExecuteScalar()
    End Sub

    Private Sub ActualizaDevolucion()
        Dim CodCompra As Integer
        Dim Motivo As String

        If cbxRelacionarFactura.Text = "Si" Then
            CodCompra = txtCodFacturaCompra.Text
        Else
            CodCompra = 0
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
        sql = "UPDATE DEVOLUCIONCOMPRA SET CODPROVEEDOR=" & cbxProveedor.SelectedValue & ",CODCOMPRA=" & CodCompra & ",CODMONEDA=" & CmbMoneda.SelectedValue & ",CODSUCURSAL=" & SucCodigo & "," & _
              "FECHADEVOLUCION = CONVERT(DATETIME,'" & dtpFechaDev.Text & "',103), TOTALEXENTA = " & TotalExenta & ",TOTALIVA=" & TotalGravada & ",TOTALDEVOLUCION=" & TotalDev & ",COTIZACION1 =" & _
              Cotizacion1 & ",TOTALIVA5 = " & TotalIva5 & ",TOTALIVA10 = " & TotalIva10 & ", FECGRA = CONVERT(DATETIME,'" & Today & "',103),CODCOMPROBANTE = " & TipoComprobanteComboBox.SelectedValue & "," & _
              "COBRADO = 0,CODDEPOSITO = " & CmbDeposito.SelectedValue & ", MOTIVODESCARTE ='" & Motivo & "',TIPODEVOLUCION='" & Me.cbxTipoDevolucion.Text & "',DESCONTARMONTO=" & DescontarMonto & _
              ", NUMDEVOLUCION='" & txtNroDevolucion.Text & "', timbradoprov = '" & tbxTimbrado.Text & "' WHERE CODDEVOLUCION=" & CDec(CodDevolucionTextBox.Text) & ""

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ActualizaDetalleDev()
        Dim CodDevolucionDet, CodCodigoDet, CodProductoDet, CantidadDevueltaDet, PrecioNetoDet, IvaDet, DescartarDet, DescripItem, CodCompra As String
        Dim c As Integer = dgwDetalleDev.RowCount

        For i = 0 To dgwDetalleDev.RowCount - 1

            CodDevolucionDet = DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value

            If IsDBNull(dgwDetalleDev.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                CodCodigoDet = "Null"
            Else
                CodCodigoDet = dgwDetalleDev.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(dgwDetalleDev.Rows(i).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                CodProductoDet = "Null"
            Else
                CodProductoDet = dgwDetalleDev.Rows(i).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(dgwDetalleDev.Rows(i).Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value) Then
                DescripItem = "Null"
            Else
                DescripItem = dgwDetalleDev.Rows(i).Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(dgwDetalleDev.Rows(i).Cells("CODCOMPRADataGridViewTextBoxColumn1").Value) Then
                CodCompra = "Null"
            Else
                CodCompra = dgwDetalleDev.Rows(i).Cells("CODCOMPRADataGridViewTextBoxColumn1").Value
            End If

            Try
                If IsDBNull(dgwDetalleDev.Rows(i).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                    CantidadDevueltaDet = "0"
                Else
                    CantidadDevueltaDet = dgwDetalleDev.Rows(i).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                    CantidadDevueltaDet = Funciones.Cadenas.QuitarCad(CantidadDevueltaDet, ".")
                    CantidadDevueltaDet = Replace(CantidadDevueltaDet, ",", ".")
                End If
            Catch ex As Exception
                CantidadDevueltaDet = "0"
            End Try

            Try
                If IsDBNull(dgwDetalleDev.Rows(i).Cells("PRECIONETODataGridViewTextBoxColumn").Value) Then
                    PrecioNetoDet = "0"
                Else
                    PrecioNetoDet = dgwDetalleDev.Rows(i).Cells("PRECIONETODataGridViewTextBoxColumn").Value
                    PrecioNetoDet = Funciones.Cadenas.QuitarCad(PrecioNetoDet, ".")
                    PrecioNetoDet = Replace(PrecioNetoDet, ",", ".")
                End If
            Catch ex As Exception
                PrecioNetoDet = "0"
            End Try

            Try
                If IsDBNull(dgwDetalleDev.Rows(i).Cells("IVADataGridViewTextBoxColumn").Value) Then
                    IvaDet = "0"
                Else
                    IvaDet = dgwDetalleDev.Rows(i).Cells("IVADataGridViewTextBoxColumn").Value
                    IvaDet = Funciones.Cadenas.QuitarCad(IvaDet, ".")
                    IvaDet = Replace(IvaDet, ",", ".")
                End If
            Catch ex As Exception
                IvaDet = "0"
            End Try

            'Descartar
            If IsDBNull(dgwDetalleDev.Rows(i).Cells("DESCARTARDataGridViewTextBoxColumn").Value) Then
                DescartarDet = "0"
            Else
                DescartarDet = dgwDetalleDev.Rows(i).Cells("DESCARTARDataGridViewTextBoxColumn").Value
            End If

            If dgwDetalleDev.Rows(i).Cells("EstadoGrilla").Value = "U" Then
                sql = ""
                sql = "update DEVOLUCIONCOMPRADETALLE Set CODCODIGO=" & CodProductoDet & ",CODPRODUCTO=" & CodProductoDet & ",CANTIDADDEVUELTA=" & CantidadDevueltaDet & ",PRECIONETO=" & PrecioNetoDet & _
                    ",IVA=" & IvaDet & ",DESCARTAR=" & DescartarDet & ",DESCRIPCION='" & DescripItem & "',CODCOMPRA=" & CodCompra & " Where CODDEVOLUCION=" & CodDevolucionDet & " and CODDEVOLDET=" & dgwDetalleDev.Rows(i).Cells("CODDEVOLDETDataGridViewTextBoxColumn").Value


                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

            ElseIf dgwDetalleDev.Rows(i).Cells("EstadoGrilla").Value = "I" Then
                sql = ""
                sql = "INSERT INTO DEVOLUCIONCOMPRADETALLE (CODDEVOLUCION, CODCODIGO, CODPRODUCTO, CANTIDADDEVUELTA, PRECIONETO, IVA,DESCARTAR,DESCRIPCION,CODCOMPRA) " & _
                     "VALUES(" & CodDevolucionDet & ", " & CodCodigoDet & ",  " & CodProductoDet & ", " & CantidadDevueltaDet & ", " & PrecioNetoDet & ", " & _
                     IvaDet & ", " & DescartarDet & ",'" & DescripItem & "'," & CodCompra & ") "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            End If

        Next



     
    End Sub

    Private Sub InsertaDetalleDev()
        Dim CodDevolucionDet, CodCodigoDet, CodProductoDet, CantidadDevueltaDet, PrecioNetoDet, IvaDet, DescartarDet, DescripItem, CodCompra As String
        Dim c As Integer = dgwDetalleDev.RowCount

        CodDevolucionDet = VGCodDevolucion

        For c = 1 To c
            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                CodCodigoDet = "Null"
            Else
                CodCodigoDet = dgwDetalleDev.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                CodProductoDet = "Null"
            Else
                CodProductoDet = dgwDetalleDev.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
            End If

            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value) Then
                DescripItem = "Null"
            Else
                DescripItem = dgwDetalleDev.Rows(c - 1).Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CODCOMPRADataGridViewTextBoxColumn1").Value) Then
                CodCompra = "Null"
            Else
                CodCompra = dgwDetalleDev.Rows(c - 1).Cells("CODCOMPRADataGridViewTextBoxColumn1").Value
            End If

            Try
                If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                    CantidadDevueltaDet = "0"
                Else
                    CantidadDevueltaDet = dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                    CantidadDevueltaDet = Funciones.Cadenas.QuitarCad(CantidadDevueltaDet, ".")
                    CantidadDevueltaDet = Replace(CantidadDevueltaDet, ",", ".")
                End If
            Catch ex As Exception
                CantidadDevueltaDet = "0"
            End Try

            Try
                If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("PRECIONETODataGridViewTextBoxColumn").Value) Then
                    PrecioNetoDet = "0"
                Else
                    PrecioNetoDet = dgwDetalleDev.Rows(c - 1).Cells("PRECIONETODataGridViewTextBoxColumn").Value
                    PrecioNetoDet = Funciones.Cadenas.QuitarCad(PrecioNetoDet, ".")
                    PrecioNetoDet = Replace(PrecioNetoDet, ",", ".")
                End If
            Catch ex As Exception
                PrecioNetoDet = "0"
            End Try

            Try
                If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value) Then
                    IvaDet = "0"
                Else
                    IvaDet = dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value
                    IvaDet = Funciones.Cadenas.QuitarCad(IvaDet, ".")
                    IvaDet = Replace(IvaDet, ",", ".")
                End If
            Catch ex As Exception
                IvaDet = "0"
            End Try

            'Descartar
            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value) Then
                DescartarDet = "0"
            Else
                DescartarDet = dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value
            End If

            If dgwDetalleDev.Rows(c - 1).Cells("EstadoGrilla").Value = "I" Or btduplicar = 1 Then
                sql = ""
                sql = "INSERT INTO DEVOLUCIONCOMPRADETALLE (CODDEVOLUCION, CODCODIGO, CODPRODUCTO, CANTIDADDEVUELTA, PRECIONETO, IVA,DESCARTAR,DESCRIPCION,CODCOMPRA) " & _
                      "VALUES(" & CodDevolucionDet & ", " & CodCodigoDet & ",  " & CodProductoDet & ", " & CantidadDevueltaDet & ", " & PrecioNetoDet & ", " & _
                      IvaDet & ", " & DescartarDet & ",'" & DescripItem & "'," & CodCompra & ") "

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

            End If
        Next
    End Sub

    Private Sub ObternerDatos()
        Dim c As Integer = dgwDetalleDev.RowCount
        Dim TotalG As Double = 0
        Dim TotalGravadaG As Double = 0
        Dim TotalExentaG As Double = 0
        Dim Total, TotalDev As Double
        Dim Iva5, TIva5, Iva10, TIva10, Exenta, TExenta As Double

        TotalDev = 0 : TIva10 = 0 : TIva5 = 0 : TExenta = 0

        For c = 1 To c
            'Total
            Total = dgwDetalleDev.Rows(c - 1).Cells("PRECIONETODataGridViewTextBoxColumn").Value * dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
            dgwDetalleDev.Rows(c - 1).Cells("SubTotal").Value = Total
            TotalDev = TotalDev + Total

            'Iva
            If dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 10 Then
                Iva10 = Total / 11
                TIva10 = CDec(TIva10) + CDec(Iva10)
                txtIva10.Text = TIva10
                txtIva10.Text = FormatNumber(txtIva10.Text, 2)
                TIva5 = 0
            ElseIf dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 5 Then
                Iva5 = Total / 21
                TIva5 = CDec(TIva5) + CDec(Iva5)
                txtIva5.Text = TIva5
                txtIva5.Text = FormatNumber(txtIva5.Text, 2)
                TIva10 = 0
            ElseIf dgwDetalleDev.Rows(c - 1).Cells("IVADataGridViewTextBoxColumn").Value = 0 Then
                Exenta = Total
                TExenta = CDec(TExenta) + CDec(Exenta)
                txtExenta.Text = TExenta
                txtExenta.Text = FormatNumber(txtExenta.Text, 2)
            End If

            txtTotalIva.Text = CDec(TIva10) + CDec(TIva5)
            txtTotalIva.Text = FormatNumber(txtTotalIva.Text, 2)

            'Descarte
            If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value) Then
            Else
                If dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value = 1 Then
                    dgwDetalleDev.Rows(c - 1).Cells("AumentarStock").Value = "SI"
                ElseIf dgwDetalleDev.Rows(c - 1).Cells("DESCARTARDataGridViewTextBoxColumn").Value = 0 Then
                    dgwDetalleDev.Rows(c - 1).Cells("AumentarStock").Value = "NO"
                End If
            End If
        Next

        TotalMaskedEdit.Text = TotalDev
    End Sub

    Private Sub DevolucionesDataGridView_SelectionChanged(sender As Object, e As System.EventArgs) Handles DevolucionesDataGridView.SelectionChanged

        'Para saber si ya fue cobrada la nota de credito
        Dim cobrado As Integer

        If CodDevolucionTextBox.Text <> "" Then
            Try
                DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)

                ObternerDatos()
                cobrado = w.FuncionConsulta("COBRADO", "DEVOLUCIONCOMPRA", "CODDEVOLUCION", CodDevolucionTextBox.Text)

                If cobrado = 0 Then
                    Me.tbxSeCobro.Text = "No"
                ElseIf cobrado = 1 Then
                    Me.tbxSeCobro.Text = "Si"
                End If

                'Si se enlazo con una factura
                If txtDescontarMotivo.Text <> "" Then
                    If txtDescontarMotivo.Text = 1 Then
                        txtNroFactura.Visible = True
                        cbxRelacionarFactura.Text = "Si"
                    Else
                        txtNroFactura.Visible = False
                        cbxRelacionarFactura.Text = "No"
                    End If
                End If

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 218)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para eliminar una devolución", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            ELIMINAR()
            PintarCeldas()
            DevolucionesDataGridView.Rows(0).Selected = True
        End If
    End Sub

    Private Sub ELIMINAR()
        If CodDevolucionTextBox.Text = "" Then
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere eliminar la Devolución?", "Cogent SIG", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
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

            InicializaFechaFiltro()
            Me.DEVOLUCIONCOMPRATableAdapter.Fill(Me.DsDevolucionCompra.DEVOLUCIONCOMPRA, FechaFiltro1, FechaFiltro2)
            Try
                DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)
            Catch ex As Exception
            End Try
            DEVOLUCIONCOMPRABindingSource.MoveLast()

            MessageBox.Show("Devolución eliminada correctamente", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch

            End Try
            MessageBox.Show(" La Devolución está siendo utilizado por el Sistema y no se puede Eliminar ", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlc.Close()
        End Try

        RecorreDetalleDevolucion()
    End Sub

    Private Sub EliminaRDevolucion()
        sql = ""
        sql = "DELETE FROM DEVOLUCIONCOMPRA WHERE CODDEVOLUCION = " & CodDevolucionTextBox.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarDetalleDevolucion()
        If dgwDetalleDev.RowCount = 0 Then
            Exit Sub
        Else
            sql = ""
            sql = "DELETE FROM DEVOLUCIONCOMPRADETALLE WHERE CODDEVOLUCION = " & CodDevolucionTextBox.Text
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Sub ModificarDetalleCompra()
        'se verifica que los campos principales no esten en blanco

        'valida el valor en cantidad
        If String.IsNullOrEmpty(txtCantidad.Text) Then
            MessageBox.Show("Ingrese la Cantidad para el nuevo detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCantidad.Focus()
            Exit Sub
        Else
            If CDec(txtCantidad.Text) = 0 Then
                MessageBox.Show("Ingrese una cantidad mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCantidad.Focus()
                Exit Sub
            End If
        End If
        'valida el valor en costo
        If String.IsNullOrEmpty(txtPrecio.Text) Then
            MessageBox.Show("Ingrese el precio para el nuevo detalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPrecio.Focus()
            Exit Sub
        Else
            If CDec(txtPrecio.Text) = 0 Then
                MessageBox.Show("Ingrese un precio mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPrecio.Focus()
                Exit Sub
            End If
        End If

        If (txtCodigo.Text <> "") And (txtCantidad.Text <> "") And (txtPrecio.Text <> "") Then

            If cbxDescartar.Text = "NO Descontar del Stock" Then
                Descarte = "0"
            Else
                Descarte = "1"
            End If

            'Verificamos si marco la opcion con Iva Incluido o Sin Iva, para saber si calcular el Iva.
            Dim coheficiente, costo As Double
            Dim Iva As Integer

            For i = 0 To dtIva.Rows.Count - 1
                dr2 = dtIva.Rows(i)
                If FormatNumber(dr2("PORCENTAJEIVA"), 0) = cbxIva.Text Then
                    coheficiente = dr2("COHEFICIENTE")
                End If
            Next

            costo = CDec(txtPrecio.Text)
            If IvaIncluidoComboBox.Text = "No Incluido" Then
                costo = costo * coheficiente
            End If

            If cbxIva.Text = "" Then
                Iva = 0
            Else
                Iva = CDec(cbxIva.Text)
            End If

            dgwDetalleDev.Rows(vgLineaDetalle).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = vgCodCodigo
            dgwDetalleDev.Rows(vgLineaDetalle).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value = vgCodCodigo
            dgwDetalleDev.Rows(vgLineaDetalle).Cells("IVADataGridViewTextBoxColumn").Value = Iva
            dgwDetalleDev.Rows(vgLineaDetalle).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value = CDec(txtCantidad.Text)
            dgwDetalleDev.Rows(vgLineaDetalle).Cells("PRECIONETODataGridViewTextBoxColumn").Value = costo
            dgwDetalleDev.Rows(vgLineaDetalle).Cells("DESCARTARDataGridViewTextBoxColumn").Value = Descarte
            dgwDetalleDev.Rows(vgLineaDetalle).Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value = txtProductoDescripcion.Text

            If dgwDetalleDev.Rows(vgLineaDetalle).Cells("EstadoGrilla").Value = "" Then
                dgwDetalleDev.Rows(vgLineaDetalle).Cells("EstadoGrilla").Value = "U"
            End If

            'Dim CalculoTotal As Integer = costo * dgwDetalleDev.Rows(vgLineaDetalle).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
            Dim CalculoTotal As Integer = (dgwDetalleDev.Rows(vgLineaDetalle).Cells("PRECIONETODataGridViewTextBoxColumn").Value * dgwDetalleDev.Rows(vgLineaDetalle).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value)
            dgwDetalleDev.Rows(vgLineaDetalle).Cells("SubTotal").Value = CalculoTotal

            btnAgregar.BringToFront() : btnEliminar.BringToFront()
            txtCodigo.Enabled = True

            RecorreDetalleDevolucion()
            Limpiamos()
            txtCodigo.Focus()
            vNuevo = True
        End If
        modifdet = 0
    End Sub

    Private Sub Limpiamos()
        txtCodigo.Text = "" : txtCantidad.Text = "" : CodCodigoTextBox.Text = ""
        CodProductoTextBox.Text = "" : IVATextBox.Text = "" : txtProductoDescripcion.Text = ""
        txtPrecio.Text = "" : cbxIva.Text = "" : cbxTipoItem.Text = "Producto"
        btnAgregar.Visible = True : btnEliminar.Visible = True
        btnEditar.Visible = False : btnCancelar.Visible = False
        cbxDescartar.Text = Config1
        CantRealMaskedEdit.Text = Nothing
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Try
            DEVOLUCIONCOMPRABindingSource.RemoveFilter()

            tsFiltroFechaE.Text = "" : tsFiltroRDesde.Text = "" : tsFiltroRHasta.Text = "" : tsFiltroNroCliente.Text = "" : tsFiltroNomCliente.Text = ""
            Me.DEVOLUCIONCOMPRATableAdapter.Fill(Me.DsDevolucionCompra.DEVOLUCIONCOMPRA, FechaFiltro1, FechaFiltro2)
            lblDGVCant.Text = "Cant. de Items:" & DevolucionesDataGridView.RowCount
        Catch ex As Exception
        End Try
        PintarCeldas()
    End Sub

    Private Sub ModificarNroFactura(ByVal EstadoDev As Integer)
        'desing by Yolanda Zelaya
        If EstadoDev = 1 And NroFacturaRelActual <> Me.txtNroFactura.Text Then
            'Si esta marcado Descontar Automaticamente del Total , debemos descontar el total de la factura en la tabla FACTURAPAGAR
            Dim VCodCOMPRA, SALDOACTUAL, IMPORTEDEV, Pagado As Integer

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = dtpFechaDev.Text
            Dim Concatenar As String = Concat & " " + hora

            If Me.cbxDescontarMonto.Checked = True Then
                Dim odrDev As SqlDataReader
                Dim MaxPago As Integer = 0
                Dim MaxCABPAGO As Integer = 0

                MaxPago = w.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                MaxCABPAGO = w.Maximo("CABPAGO", "COMPRASFORMAPAGO")

                MaxCABPAGO = MaxCABPAGO + 1

                Cotizacion1 = Math.Round(CDec(Cot1FactTextBox.Text))

                TotalDev = TotalMaskedEdit.Text
                TotalDev = Funciones.Cadenas.QuitarCad(TotalDev, ".")
                TotalDev = Replace(TotalDev, ",", ".")

                '####################################################################
                'Si se modifico el nro de factura entonces debemos devolver el saldo a la factura Anterior "NroFacturaRelActual"
                If NroFacturaRelActual <> "" Then
                    VCodCOMPRA = w.FuncionConsultaDecimal("CODCOMPRA", "COMPRAS", "CODPROVEEDOR = " & cbxProveedor.SelectedValue & " AND NUMCOMPRA", NroFacturaRelActual)
                    If VCodCOMPRA <> 0 Then ' Las COMPRAs TIPOCOMPRA >= 2 No se insertan en FACTURAPAGAR
                        objCommand.CommandText = "SELECT NUMEROCUOTA,SALDOCUOTA, IMPORTECUOTA  FROM FACTURAPAGAR WHERE CODCOMPRA = " & VCodCOMPRA

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
                                        sql = sql + "UPDATE FACTURAPAGAR SET PAGADO = 0 , SALDOCUOTA =  " & SALDOACTUAL & "   WHERE CODCOMPRA = " & VCodCOMPRA & " AND NUMEROCUOTA= " & odrDev("NUMEROCUOTA") & ""
                                        IMPORTEDEV = IMPORTEDEV - SALDOACTUAL
                                    Else
                                        SALDOACTUAL = odrDev("IMPORTECUOTA")
                                        sql = sql + "UPDATE FACTURAPAGAR SET PAGADO = 0 , SALDOCUOTA =  " & SALDOACTUAL & "   WHERE CODCOMPRA = " & VCodCOMPRA & " AND NUMEROCUOTA= " & odrDev("NUMEROCUOTA") & ""
                                        IMPORTEDEV = IMPORTEDEV - odrDev("IMPORTECUOTA")
                                    End If
                                End If
                            Loop
                        End If
                        Try
                            cmd.CommandText = sql
                            cmd.ExecuteNonQuery()

                            'myTrans.Commit()
                        Catch ex As Exception

                        End Try

                        odrDev.Close()
                        objCommand.Dispose()
                    End If

                    '##########################################################################################################
                    'Eliminamos en resgistro del movimiento anterior en la tabla Movimiento y COMPRASFORMAPAGO
                    conexion = ser.Abrir()

                    Dim davtafcob As New SqlDataAdapter("Select CODPAGO, CODCOMPRA, NROCUOTA, IMPORTE FROM COMPRASFORMAPAGO WHERE NUMDEVOLUCION = '" & DevolucionesDataGridView.CurrentRow.Cells("NUMDEVOLUCION1").Value & "'", conexion)
                    Dim dtvtafcob As New DataTable
                    davtafcob.Fill(dtvtafcob)
                    Dim drvtafcob As DataRow
                    For i = 0 To dtvtafcob.Rows.Count - 1
                        drvtafcob = dtvtafcob.Rows(i)

                        sql = "DELETE movimientos WHERE id_pago = " & drvtafcob("CODPAGO") & ""
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                        sql = ""
                        sql = "DELETE COMPRASFORMAPAGO WHERE CODPAGO = " & drvtafcob("CODPAGO")

                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    Next
                End If
                If txtNroFactura.Text <> "" Then '  Si modifico y puso Otra factura
                    '####################################################################
                    'descontamos el saldo de la nueva factura
                    VCodCOMPRA = w.FuncionConsultaDecimal("CODCOMPRA", "COMPRAS", "CODPROVEEDOR = " & cbxProveedor.SelectedValue & " AND NUMCOMPRA", txtNroFactura.Text) ' PARA ASEGURAR PORQUE NO SE HIZO TODAVIA EL FILL PARA REFRESCAR CON LA NUEVAFACTURA

                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc

                    Dim IMPORTEACTUAL, SaldoActualizar As Integer


                    Dim saldofact As Integer = w.FuncionConsulta("SUM(SALDOCUOTA)", "FACTURAPAGAR", "CODCOMPRA", VCodCOMPRA)
                    If saldofact <> 0 Then
                        SiDEV = 0
                    Else
                        SiDEV = 1
                    End If

                    objCommand.CommandText = "SELECT SALDOCUOTA, IMPORTECUOTA, NUMEROCUOTA FROM FACTURAPAGAR WHERE CODCOMPRA = " & VCodCOMPRA

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
                                MaxPago = MaxPago + 1
                                If SiDEV = 1 Then
                                    SALDOACTUAL = IMPORTEACTUAL
                                End If
                                If SALDOACTUAL <> 0 Then ' se puso este IF en el caso que SiDEV=0 y por ej. una factura tenga 5 cuotas, 3 pago en efectivo y 2 quiere anular con NC. si no se pone este control igual entra para las 3 primeras cuotas ya saldadas
                                    If IMPORTEDEV < SALDOACTUAL Then ' el IMPORTEDEV es MENOR al Saldo de la Cuota o Saldo de DevolucionesXFactura
                                        sql = sql + " INSERT INTO COMPRASFORMAPAGO (CODPAGO,CODCOMPRA,CODTIPOPAGO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOPAGO,FECHAPAGO,NROCUOTA,NUMDEVOLUCION,CABPAGO,TIPOPAGO,AUTORIZADO) " & _
                                             "VALUES (" & MaxPago & "," & VCodCOMPRA & ",5," & CmbMoneda.SelectedValue & "," & Cotizacion1 & "," & IMPORTEDEV & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103), " & _
                                             odrDev("NUMEROCUOTA") & ",'" & NumDevolucion & "'," & MaxCABPAGO & ",1," & UsuCodigo & ")"

                                        SaldoActualizar = SALDOACTUAL - IMPORTEDEV
                                        IMPORTEDEV = 0
                                        Pagado = 0

                                    Else ' el IMPORTEDEV es Mayor o Igual al Saldo de la Cuota o Saldo de DevolucionesXFactura
                                        sql = sql + " INSERT INTO COMPRASFORMAPAGO (CODPAGO,CODCOMPRA,CODTIPOPAGO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOPAGO,FECHAPAGO,NROCUOTA,NUMDEVOLUCION,CABPAGO,TIPOPAGO,AUTORIZADO) " & _
                                             "VALUES (" & MaxPago & "," & VCodCOMPRA & ",5," & CmbMoneda.SelectedValue & "," & Cotizacion1 & "," & SALDOACTUAL & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103), " & _
                                             odrDev("NUMEROCUOTA") & ",'" & NumDevolucion & "'," & MaxCABPAGO & ",1," & UsuCodigo & ")"

                                        IMPORTEDEV = IMPORTEDEV - SALDOACTUAL
                                        SaldoActualizar = 0
                                        Pagado = 1
                                    End If
                                    If SiDEV = 0 Then ' Si SiDEV=1 eligio una factura de saldo 0, no debe actualizar FacturaaPagar
                                        sql = sql + " UPDATE FACTURAPAGAR SET  PAGADO = " & Pagado & " ,SALDOCUOTA =  " & SaldoActualizar & "  WHERE NUMEROCUOTA = " & odrDev("NUMEROCUOTA") & " AND CODCOMPRA = " & VCodCOMPRA
                                    End If
                                End If
                            End If
                        Loop
                    End If
                    sql = sql + " UPDATE DEVOLUCIONCOMPRA SET COBRADO =  1, SALDO = 0 WHERE CODDEVOLUCION = " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & "   "

                    Try
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                        myTrans.Commit()
                    Catch ex As Exception

                    End Try

                    odrDev.Close()
                    objCommand.Dispose()
                Else ' Tenía antes un nrofactura y ahora no, se devuelve el saldo (igual al importe) a la Devolucion
                    sql = sql + " UPDATE DEVOLUCIONCOMPRA SET COBRADO =  0, SALDO = " & CDec(TotalMaskedEdit.Text) & " WHERE CODDEVOLUCION = " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & "   "
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
            End If
        End If
    End Sub
    Private Sub btnAprobar_Click(sender As System.Object, e As System.EventArgs) Handles btnAprobar.Click
        permiso = PermisoAplicado(UsuCodigo, 46)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Aprobar la Devolución", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            'Dim imprimirfact As Integer
            'Dim impresora As String

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            '----------- PONE COMO APROBADO LA DEVOLUCION
            Try
                Aprobar()

                myTrans.Commit()
            Catch ex As Exception
                myTrans.Rollback()
            End Try
            sqlc.Close()

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = dtpFechaDev.Text
            Dim Concatenar As String = Concat & " " + hora
            NumDevolucion = txtNroDevolucion.Text
            Dim CodDeposito As String = CmbDeposito.SelectedValue

            '----------------- ACTUALIZAMOS STOCK Y MOVIEMITO DE PRODUCTOS -----------------------------
            Dim cc As Integer = dgwDetalleDev.RowCount
            Dim CodProductoDev, CodCodigo, CantidadDev As String
            Dim existe As Integer

            For cc = 0 To cc - 1
                Dim AumentaStock As String
                AumentaStock = dgwDetalleDev.Rows(cc).Cells("AumentarStock").Value

                'verificamos si existe o no el producto para saber si modificamos o insertamos
                If AumentaStock = "SI" Then
                    CodProductoDev = dgwDetalleDev.Rows(cc).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
                    If IsDBNull(dgwDetalleDev.Rows(cc).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                        CodCodigo = "NULL"
                    Else
                        CodCodigo = dgwDetalleDev.Rows(cc).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                    End If
                    If IsDBNull(dgwDetalleDev.Rows(cc).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                        CantidadDev = "NULL"
                    Else
                        CantidadDev = CDec(dgwDetalleDev.Rows(cc).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) * -1
                        'CantidadDev = CDec(dgwDetalleDev.Rows(cc).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value)
                        CantidadDev = Replace(CantidadDev, ",", ".")
                    End If

                    existe = w.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO = " & CodProductoDev & " AND CODCODIGO=" & CodCodigo & " AND CODDEPOSITO", CmbDeposito.SelectedValue)

                    'existe = 2559
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    Try

                        InsertaMovProducto(CodProductoDev, CodCodigo, CantidadDev, "Aprobar")
                        myTrans.Commit()

                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Actualizar")
                        Catch
                        End Try
                        MessageBox.Show("Ocurrió un error en la Operación", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'Cancelamos todo :(
                    End Try
                    sqlc.Close()
                End If
            Next



            Cotizacion1 = Cot1FactTextBox.Text
            Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
            Cotizacion1 = Replace(Cotizacion1, ",", ".")

            TotalDev = TotalMaskedEdit.Text
            TotalDev = Funciones.Cadenas.QuitarCad(TotalDev, ".")
            TotalDev = Replace(TotalDev, ",", ".")


            '----------------------------------------------------Contabilidad------------------------------------------------------------------------------------
            Dim ConceptoAsiento, IVA5, IVA10, EXE, TOTALIVA, ClienteProveedor, TOTALVENTACONT As String
            Dim RgMerc, RgMonet As Integer

            IVA5 = CDec(txtIva5.Text) * CDec(Cot1FactTextBox.Text)
            IVA10 = CDec(txtIva10.Text) * CDec(Cot1FactTextBox.Text)
            EXE = CDec(txtExenta.Text) * CDec(Cot1FactTextBox.Text)
            TOTALIVA = CDec(IVA5) + CDec(IVA10)
            TOTALVENTACONT = CDec(TotalMaskedEdit.Text) * CDec(Cot1FactTextBox.Text)
            ClienteProveedor = cbxProveedor.SelectedValue
            '#TODO : CORREGIR MARILIN
            RgMonet = 2
            RgMerc = 1

            If Cot1FactTextBox.Text = "" Or Cot1FactTextBox.Text = "0,00" Then
                Cotizacion1 = "1"
            Else
                Cotizacion1 = Cot1FactTextBox.Text
                Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
                Cotizacion1 = Replace(Cotizacion1, ",", ".")
            End If

            ConceptoAsiento = "Nota de Crédito Proveedor / " & cbxProveedor.Text
            ReglaContable(EXE, IVA5, IVA10, TOTALIVA, "DEVOLUCIONCOMPRA", CDec(CodDevolucionTextBox.Text), "CODDEVOLUCION", ConceptoAsiento, RgMerc, RgMonet, _
            CmbMoneda.SelectedValue, Cotizacion1, NumDevolucion, dtpFechaDev.Text, TOTALVENTACONT, "29", 0, ClienteProveedor, SucCodigo)

            'Si esta marcado Descontar Automaticamente del Total , debemos descontar el total de la factura en la tabla FACTURAPAGAR
            If Me.txtDescontarMotivo.Text = "1" Then
                Dim MaxPago As Integer = 0
                Dim MaxCabPago As Integer = 0
                Dim VCodCompra, SALDOACTUAL, IMPORTEDEV, PAGADO, SaldoActualizar, IMPORTEACTUAL As Integer

                MaxPago = w.Maximo("CODPAGO", "COMPRASFORMAPAGO")
                MaxCabPago = w.Maximo("CABPAGO", "COMPRASFORMAPAGO")

                MaxCabPago = MaxCabPago + 1

                Cotizacion1 = Cot1FactTextBox.Text
                Cotizacion1 = Funciones.Cadenas.QuitarCad(Cotizacion1, ".")
                Cotizacion1 = Replace(Cotizacion1, ",", ".")

                TotalDev = TotalMaskedEdit.Text
                TotalDev = Funciones.Cadenas.QuitarCad(TotalDev, ".")
                TotalDev = Replace(TotalDev, ",", ".")

                'Obtenemos todos los datos de la factura
                VCodCompra = w.FuncionConsultaDecimal("CODCOMPRA", "DEVOLUCIONCOMPRA", "CODDEVOLUCION", DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)

                objCommand.CommandText = "SELECT SALDOCUOTA, IMPORTECUOTA, NUMEROCUOTA FROM FACTURAPAGAR WHERE CODCOMPRA = " & VCodCompra

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrDev As SqlDataReader = objCommand.ExecuteReader()

                If cbxRelacionarFactura.Text = "Si" Then
                    If Not IsDBNull(DevolucionesDataGridView.CurrentRow.Cells("CODCOMPRATextBoxColumn1").Value) Then
                        Dim saldofact As Integer = w.FuncionConsulta("SUM(SALDOCUOTA)", "FACTURAPAGAR", "CODCOMPRA", DevolucionesDataGridView.CurrentRow.Cells("CODCOMPRATextBoxColumn1").Value)
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
                        If IMPORTEDEV > 0 Then
                            SALDOACTUAL = odrDev("SALDOCUOTA")
                            IMPORTEACTUAL = odrDev("IMPORTECUOTA")
                            MaxPago = MaxPago + 1
                            If SiDEV = 1 Then
                                SALDOACTUAL = IMPORTEACTUAL
                            End If
                            If SALDOACTUAL <> 0 Then ' se puso este IF en el caso que SiDEV=0 y por ej. una factura tenga 5 cuotas, 3 pago en efectivo y 2 quiere anular con NC. si no se pone este control igual entra para las 3 primeras cuotas ya saldadas
                                If IMPORTEDEV < SALDOACTUAL Then ' el IMPORTEDEV es MENOR al Saldo de la Cuota o Saldo de DevolucionesXFactura
                                    sql = sql + " INSERT INTO COMPRASFORMAPAGO (CODPAGO,CODCOMPRA,CODTIPOPAGO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOPAGO,FECHAPAGO,NROCUOTA,NUMDEVOLUCION,CABPAGO,TIPOPAGO,AUTORIZADO) " & _
                                         "VALUES (" & MaxPago & "," & VCodCompra & ",5," & CmbMoneda.SelectedValue & "," & Cotizacion1 & "," & IMPORTEDEV & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103), " & _
                                         odrDev("NUMEROCUOTA") & ",'" & NumDevolucion & "'," & MaxCabPago & ",1," & UsuCodigo & ")"

                                    SaldoActualizar = SALDOACTUAL - IMPORTEDEV
                                    IMPORTEDEV = 0
                                    PAGADO = 0

                                Else ' el IMPORTEDEV es Mayor o Igual al Saldo de la Cuota o Saldo de DevolucionesXFactura
                                    sql = sql + " INSERT INTO COMPRASFORMAPAGO (CODPAGO,CODCOMPRA,CODTIPOPAGO,CODMONEDA,COTIZACION1,IMPORTE,DESTIPOPAGO,FECHAPAGO,NROCUOTA,NUMDEVOLUCION,CABPAGO,TIPOPAGO,AUTORIZADO) " & _
                                         "VALUES (" & MaxPago & "," & VCodCompra & ",5," & CmbMoneda.SelectedValue & "," & Cotizacion1 & "," & SALDOACTUAL & ",'Nota de Credito',CONVERT(DATETIME,'" & Concatenar & "',103), " & _
                                         odrDev("NUMEROCUOTA") & ",'" & NumDevolucion & "'," & MaxCabPago & ",1," & UsuCodigo & ")"

                                    IMPORTEDEV = IMPORTEDEV - SALDOACTUAL
                                    SaldoActualizar = 0
                                    PAGADO = 1
                                End If
                                If SiDEV = 0 Then ' Si SiDEV=1 eligio una factura de saldo 0, no debe actualizar FacturaaPagar
                                    sql = sql + " UPDATE FACTURAPAGAR SET  PAGADO = " & PAGADO & " ,SALDOCUOTA =  " & SaldoActualizar & "  WHERE NUMEROCUOTA = " & odrDev("NUMEROCUOTA") & " AND CODCOMPRA = " & VCodCompra
                                End If
                            End If
                        End If
                    Loop
                End If
                sql = sql + " UPDATE DEVOLUCIONCOMPRA SET COBRADO =  1, SALDO = 0 WHERE CODDEVOLUCION = " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & "   "

                Try
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    myTrans.Commit()
                Catch ex As Exception

                End Try

                odrDev.Close()
                objCommand.Dispose()
            End If

            MessageBox.Show("Operación finalizada con éxito", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim CodDev As Integer = Me.CodDevolucionTextBox.Text
            FechaFiltro()

            Me.DEVOLUCIONCOMPRATableAdapter.Fill(Me.DsDevolucionCompra.DEVOLUCIONCOMPRA, FechaFiltro1, FechaFiltro2)

            'Buscamos la posicion del registro guardado
            For i = 0 To DevolucionesDataGridView.RowCount - 1
                If DevolucionesDataGridView.Rows(i).Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value = CodDev Then
                    DEVOLUCIONCOMPRABindingSource.Position = i
                End If
            Next

            Try
                DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)
            Catch ex As Exception
            End Try

            TxtEstado.Text = "1"
            Deshabilita()
            RecorreDetalleDevolucion()
            PintarCeldas()
        End If
    End Sub

    Private Sub InsertaMovProducto(ByRef CodProductoDev As String, ByRef CodCodigo As String, ByRef CantidadDev As String, ByRef tipo As String)
        sql = ""
        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim Concat As String = dtpFechaDev.Text
        Dim Concatenar As String = Concat & " " + hora

        If tipo = "Aprobar" Then
            sql = "INSERT INTO MOVPRODUCTO " & _
                        "(CODCODIGO,CONCEPTO,CANTIDAD,FECHAMOVIMIENTO,CODUSUARIO, CODDEPOSITO,MODULO,STOCK,COSTEABLE,MODULOTRANSID)" & _
                        " VALUES (" & CodCodigo & ",'Devolución de Compra Nro. " & txtNroDevolucion.Text & "', " & CantidadDev & ", CONVERT(Datetime,'" & Concatenar & "',103)," & _
                        "" & UsuCodigo & "," & CmbDeposito.SelectedValue & ",29,1,0," & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & " ) "
        Else
            sql = "INSERT INTO MOVPRODUCTO " & _
                        "(CODCODIGO,CONCEPTO,CANTIDAD,FECHAMOVIMIENTO,CODUSUARIO, CODDEPOSITO,MODULO,STOCK,COSTEABLE,MODULOTRANSID)" & _
                        " VALUES (" & CodCodigo & ",'Anulación Devolución de Compra Nro. " & txtNroDevolucion.Text & "', " & CantidadDev & ", CONVERT(Datetime,'" & Concatenar & "',103)," & _
                        "" & UsuCodigo & "," & CmbDeposito.SelectedValue & ",29,1,0," & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value & " ) "
        End If


        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

    End Sub

    Private Sub Aprobar()

        sql = ""
        sql = "UPDATE DEVOLUCIONCOMPRA SET ESTADO = 1 WHERE CODDEVOLUCION= " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub BuscarDevolucionTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarDevolucionTextBox.TextChanged
        Try
            Me.DEVOLUCIONCOMPRABindingSource.Filter = "NUMDEVOLUCION LIKE '%" & BuscarDevolucionTextBox.Text & "%' OR NOMBRE LIKE '%" & BuscarDevolucionTextBox.Text & "%'"
            lblDGVCant.Text = "Cant. de Items:" & DevolucionesDataGridView.RowCount
            PintarCeldas()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        'si la nota de credito ya se uso no debe poder anularse
        If tbxSeCobro.Text = "No" Then
            PanelMotivoAnulacion.Visible = True
            PanelMotivoAnulacion.BringToFront()

            TxtMotivodeAnulacion.Enabled = True
            BtnAnularMotivo.Enabled = True
            TxtMotivodeAnulacion.Text = ""
            TxtMotivodeAnulacion.Focus()
        Else
            MessageBox.Show("No se puede Anular una Nota de Credito ya Cobrada", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PanelMotivoAnulacion.Visible = False
        End If
    End Sub

    Private Sub BtnCerrarMotivo_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrarMotivo.Click
        TxtMotivodeAnulacion.Text = ""
        PanelMotivoAnulacion.Visible = False
    End Sub

    Private Sub BtnAnularMotivo_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnularMotivo.Click
        permiso = PermisoAplicado(UsuCodigo, 220)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para anular la Devolución", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            If TxtMotivodeAnulacion.Text = "" Then
                MessageBox.Show("Ingrese el Motivo de Anulación", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtMotivodeAnulacion.Focus()
                Exit Sub
            End If

            'Actualizamos la factura como estado ANULADO
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans

            Try
                Anular()
                myTrans.Commit()

            Catch ex As Exception

            End Try

            'Verificamos si existe 
            Dim c As Integer = dgwDetalleDev.RowCount
            Dim CodProductoDev, CodCodigo, CantidadDev As String
            'Dim existe As Integer

            For c = 1 To c
                'verificamos si existe o no el producto para saber si modificamos o insertamos
                If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value) Then
                    CodProductoDev = "NULL"
                    Exit Sub
                Else
                    CodProductoDev = dgwDetalleDev.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn1").Value
                    If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value) Then
                        CodCodigo = "NULL"
                    Else
                        CodCodigo = dgwDetalleDev.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                    End If

                    If IsDBNull(dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value) Then
                        CantidadDev = "NULL"
                    Else
                        CantidadDev = dgwDetalleDev.Rows(c - 1).Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value
                        CantidadDev = Replace(CantidadDev, ",", ".")
                    End If
                End If

                'antes de hacer la actualizacion del stock debemos verificar que dicho producto no este marcado como "NO DESCONTAR DEL STOCK"
                Dim DescartarStock As String

                DescartarStock = dgwDetalleDev.Rows(c - 1).Cells("AumentarStock").Value

                If DescartarStock = "SI" Then

                    'existe = w.FuncionConsulta("CODSTOCKDEPOSTIPO", "STOCKDEPOSITO", "CODPRODUCTO = " & CodProductoDev & " AND CODCODIGO=" & CodCodigo & " AND CODDEPOSITO", CmbDeposito.SelectedValue)

                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    Try
                        ' ActualizarStock(CodProductoDev, CodCodigo, CantidadDev, "Anular")
                        InsertaMovProducto(CodProductoDev, CodCodigo, CantidadDev, "Anular")

                        myTrans.Commit()

                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Actualizar")
                        Catch
                        End Try

                        MessageBox.Show("Ocurrió un error en la Operación", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'Cancelamos todo :(
                    Finally
                        sqlc.Close()
                    End Try
                End If
            Next

            MessageBox.Show("Operación finalizada con éxito", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Dim CodDev As Integer = Me.CodDevolucionTextBox.Text
            FechaFiltro()

            Me.DEVOLUCIONCOMPRATableAdapter.Fill(Me.DsDevolucionCompra.DEVOLUCIONCOMPRA, FechaFiltro1, FechaFiltro2)

            'Buscamos la posicion del registro guardado
            For i = 0 To DevolucionesDataGridView.RowCount - 1
                If DevolucionesDataGridView.Rows(i).Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value = CodDev Then
                    DEVOLUCIONCOMPRABindingSource.Position = i
                End If
            Next

            Try
                DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)
            Catch ex As Exception
            End Try

            TxtEstado.Text = "2"
            Deshabilita()
            RecorreDetalleDevolucion()
            PintarCeldas()
        End If
    End Sub

    Private Sub Anular()
        sql = ""
        sql = "UPDATE DEVOLUCIONCOMPRA SET ESTADO = 2 , MOTIVOANULADO = '" & TxtMotivodeAnulacion.Text & "'  WHERE CODDEVOLUCION= " & DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub tsNuevaDevoluc_Click(sender As System.Object, e As System.EventArgs) Handles tsNuevaDevoluc.Click
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
        Dim soporte As String = "http://www.cogentpotential.com/soporte/devoluciones/devolucioncompra"
        Shell("Explorer " & soporte)
    End Sub

    Private Sub tsMotivoAnulacion_Click(sender As System.Object, e As System.EventArgs) Handles tsMotivoAnulacion.Click
        PanelMotivoAnulacion.Visible = True
        PanelMotivoAnulacion.BringToFront()
    End Sub

    Private Sub tsPersonalizarDev_Click(sender As System.Object, e As System.EventArgs) Handles tsPersonalizarDev.Click
        ABMConfigPosExpress.Show()
        ABMConfigPosExpress.abrirdesde("DevoluciónCompra")
    End Sub

    Private Sub tsDuplicarFactura_Click(sender As System.Object, e As System.EventArgs) Handles tsDuplicarFactura.Click
        permiso = PermisoAplicado(UsuCodigo, 213) ' Duplicar una Factura
        If permiso = 0 Then
            MsgBox("No tiene permiso para realizar la operación", MsgBoxStyle.Information, "Pos Express")
        Else
            Me.txtNroDevolucion.Text = ""
            Dim MaxDev As Double = w.Maximo("CODDEVOLUCION", "DEVOLUCIONCOMPRA")
            CodDevolucionTextBox.Text = MaxDev + 1
            'Si duplica..si o si con la fecha de Hoy
            dtpFechaDev.Value = Today.ToShortDateString

            AccBtNuevo = 1
            btduplicar = 1
            'Nuevo()
            GuardarPictureBox_Click(Nothing, Nothing) ' Aqui llama al evento Click de Guardar que ya contiene AUDITORIAINSERTAVENTA()
            btduplicar = 0
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
            MsgBox("Se introdujeron filtros en Nro. de Proveedor y Nombre de Proveedor. El Sistema toma por defecto el Nro. de Proveedor", MsgBoxStyle.Information, "Error en Filtro")
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

        Me.DEVOLUCIONCOMPRATableAdapter.Fill(Me.DsDevolucionCompra.DEVOLUCIONCOMPRA, fechaDesdeEspecial, fechaHastaEspecial)
        Try
            DEVOLUCIONCOMPRADETALLETableAdapter.Fill(DsDevolucionCompra.DEVOLUCIONCOMPRADETALLE, DevolucionesDataGridView.CurrentRow.Cells("CODDEVOLUCIONDataGridViewTextBoxColumn").Value)
        Catch ex As Exception
        End Try

        If Trim(tsFiltroNroCliente.Text) <> "" Then
            DEVOLUCIONCOMPRABindingSource.Filter = "NUMPROVEEDOR = " & Trim(tsFiltroNroCliente.Text)
        Else
            If Trim(tsFiltroNomCliente.Text) <> "" Then
                DEVOLUCIONCOMPRABindingSource.Filter = "NOMBRE like '%" & Trim(tsFiltroNomCliente.Text) & "%'"
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
    Private Sub chxFacturasconSaldoCero_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chxFacturasconSaldoCero.CheckedChanged
        If chxFacturasconSaldoCero.Checked = True Then
            Try
                If cbxDevOtrosDepositos.Text = "Si" Then
                    COMPRASTableAdapter.FillBySaldoCero(DsDevolucionCompra.COMPRAS, cbxProveedor.SelectedValue)
                ElseIf cbxDevOtrosDepositos.Text = "No" Then
                    COMPRASTableAdapter.FillByDepSaldoCero(DsDevolucionCompra.COMPRAS, cbxProveedor.SelectedValue, CmbDeposito.SelectedValue)
                End If
            Catch ex As Exception
            End Try
            SALDODV.Visible = True
            SALDO.Visible = False
        Else
            Try
                If cbxDevOtrosDepositos.Text = "Si" Then
                    COMPRASTableAdapter.Fill(DsDevolucionCompra.COMPRAS, cbxProveedor.SelectedValue)
                ElseIf cbxDevOtrosDepositos.Text = "No" Then
                    COMPRASTableAdapter.FillBy(DsDevolucionCompra.COMPRAS, cbxProveedor.SelectedValue, CmbDeposito.SelectedValue)
                End If
            Catch ex As Exception
            End Try
            SALDODV.Visible = False
            SALDO.Visible = True
        End If
    End Sub

    Private Sub dgwProveedores_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgwProveedores.KeyPress
        If dgwProveedores.RowCount <> 0 Then
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If KeyAscii = 13 Then
                Try
                    Dim pos As Integer = dgwProveedores.CurrentRow.Index
                    Dim cantReg As Integer = dgwProveedores.RowCount - 1

                    If (pos <> 0) And (pos <> cantReg) Then
                        pos = pos - 1
                    End If

                    cbxProveedor.SelectedValue = dgwProveedores.Rows(pos).Cells("CODPROVEEDOR").Value
                    txtNroProveedor.Text = dgwProveedores.Rows(pos).Cells("NUMPROVEEDORDataGridViewTextBoxColumn").Value
                Catch ex As Exception
                End Try
            End If

            upcProveedores.Close()
            cbxProveedor.Focus()
        End If
    End Sub

    Private Sub pbBuscadorProveedor_Click(sender As System.Object, e As System.EventArgs) Handles pbBuscadorProveedor.Click
        upcProveedores.Show()
        tbxBuscarProveedores.Focus()
    End Sub

    Private Sub pbBuscarProducto_Click(sender As System.Object, e As System.EventArgs) Handles pbBuscarProducto.Click
        If cbxRelacionarFactura.Text = "Si" Then
            If txtCodFacturaCompra.Text <> "" Then
                Try
                    If Config4 = "Permitir Cargar otros Items como Detalle" Then
                        GoTo todoslosprod
                    End If
                    COMPRASDERTALLETableAdapter.Fill(DsDevolucionCompra.COMPRASDERTALLE, Me.txtCodFacturaCompra.Text)
                Catch ex As Exception

                End Try

                upcProductosFactura.Show()
                BuscarProductoTextBox.Focus()
            Else
                MessageBox.Show("Primero seleccione la Compra para Filtrar los Productos", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroFactura.Focus()
                Exit Sub
            End If
        Else
todoslosprod:
            vendermasquestock = PermisoAplicado(UsuCodigo, 201)
            If vendermasquestock = 1 Then
                Me.CODIGOTableAdapter.FillBy(DsDevolucionCompra.CODIGO, CInt(CmbDeposito.SelectedValue))
                upcProdcutoCodigo.Show()
                txtBuscarCodigoProducto.Focus()
            ElseIf vendermasquestock = 0 Then

                Me.CODIGOTableAdapter.Fill(DsDevolucionCompra.CODIGO, CInt(CmbDeposito.SelectedValue))
                upcProdcutoCodigo.Show()
                txtBuscarCodigoProducto.Focus()
            End If
        End If
    End Sub

    Private Sub btBuscarFactura_Click(sender As System.Object, e As System.EventArgs) Handles btBuscarFactura.Click
        If upcFacturasCompras.IsDisplayed Then
            upcFacturasCompras.Close()
            txtCodigo.Focus()
        Else
            If cbxProveedor.SelectedValue <> Nothing Then
                'ANTES DE MOSTRAR EL FILTRO DE FACTURAS SE DEBE VERIFICAR SI DESEA FILTRAR SIN IMPORTAR EL DESPOSITO O SOLO DEL DEPOSITO SELECCIONADO
                upcFacturasCompras.Show()
                BuscaFacturaTextBox.Focus()
                Try
                    If cbxDevOtrosDepositos.Text = "Si" Then
                        COMPRASTableAdapter.Fill(DsDevolucionCompra.COMPRAS, cbxProveedor.SelectedValue)
                    ElseIf cbxDevOtrosDepositos.Text = "No" Then
                        COMPRASTableAdapter.FillBy(DsDevolucionCompra.COMPRAS, cbxProveedor.SelectedValue, CmbDeposito.SelectedValue)
                    End If
                Catch ex As Exception
                End Try
                chxFacturasconSaldoCero.Checked = False
            Else
                MessageBox.Show("Primero seleccione el Proveedor para Filtrar las Compras", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxProveedor.Select()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub dgwCompras_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgwCompras.KeyDown
        If e.KeyCode = Keys.Escape Then 'ESC
            upcFacturasCompras.Close()
        End If
    End Sub

    Private Sub txtNroProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroProveedor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxProveedor.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroProveedor_LostFocus(sender As Object, e As System.EventArgs) Handles txtNroProveedor.LostFocus
        'Obtenemos el Nombre del Proveedor
        Dim CodProveedor As Double

        If txtNroProveedor.Text <> "" Then
            CodProveedor = w.FuncionConsulta("CODPROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", txtNroProveedor.Text)
            Try
                cbxProveedor.SelectedValue = CDec(CodProveedor)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub cbxProveedor_LostFocus(sender As Object, e As System.EventArgs) Handles cbxProveedor.LostFocus
        'Obtenemos el Numero del Proveedor
        If cbxProveedor.Text <> "" Then
            Try
                txtNroProveedor.Text = w.FuncionConsultaString("NUMPROVEEDOR", "PROVEEDOR", "CODPROVEEDOR", cbxProveedor.SelectedValue)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub PintarCeldas()
        If DevolucionesDataGridView.RowCount - 1 >= 1 Then
            For i = 0 To DevolucionesDataGridView.RowCount - 1
                If DevolucionesDataGridView.Rows(i).Cells("ESTADO").Value = 1 Then
                    DevolucionesDataGridView.Item(0, i).Style.ForeColor = Color.Green
                ElseIf DevolucionesDataGridView.Rows(i).Cells("ESTADO").Value = 2 Then
                    DevolucionesDataGridView.Item(0, i).Style.ForeColor = Color.Maroon
                ElseIf DevolucionesDataGridView.Rows(i).Cells("ESTADO").Value = 0 Then
                    DevolucionesDataGridView.Item(0, i).Style.ForeColor = Color.Black
                End If
            Next
        End If
    End Sub

    Private Sub IngresarCotCheckBox_ToggleStateChanged(sender As System.Object, args As Telerik.WinControls.UI.StateChangedEventArgs)
        If IngresarCotCheckBox.Checked = True Then
            Cot1FactTextBox.ReadOnly = False
            Cot1FactTextBox.Enabled = True
            Cot1FactTextBox.Focus()
            Try
                Cot1FactTextBox.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", CmbMoneda.Text + " ORDER BY FECHAMOVIMIENTO DESC")
            Catch ex As Exception

            End Try
        Else
            Cot1FactTextBox.ReadOnly = True
            Cot1FactTextBox.Enabled = False
            IvaIncluidoComboBox.Focus()
        End If
    End Sub

    Private Sub IvaIncluidoComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles IvaIncluidoComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxRelacionarFactura.Text = "No" Then
                cbxTipoItem.Focus()
            Else
                txtCodigo.Focus()
            End If
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub DetalleDevDataGridView_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwDetalleDev.DoubleClick
        Try
            If IsDBNull(dgwDetalleDev.CurrentRow) Then
                Exit Sub
            Else
                vgLineaDetalle = dgwDetalleDev.CurrentRow.Index
                modifdet = 1

                If IsDBNull(dgwDetalleDev.CurrentRow.Cells("CODIGO").Value) Then
                    txtCodigo.Text = ""
                Else
                    txtCodigo.Text = dgwDetalleDev.CurrentRow.Cells("CODIGO").Value
                End If

                If txtCodigo.Text = "" Then
                    vgCodProducto = 0
                    vgCodCodigo = 0
                End If

                vgCodCodigo = dgwDetalleDev.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn1").Value
                txtCantidad.Text = CDec(dgwDetalleDev.CurrentRow.Cells("CANTIDADDEVUELTADataGridViewTextBoxColumn").Value)
                txtPrecio.Text = CDec(dgwDetalleDev.CurrentRow.Cells("PRECIONETODataGridViewTextBoxColumn").Value)
                cbxIva.Text = dgwDetalleDev.CurrentRow.Cells("IVADataGridViewTextBoxColumn").Value
                txtProductoDescripcion.Text = dgwDetalleDev.CurrentRow.Cells("DESCRIPCIONDataGridViewTextBoxColumn").Value
            End If

        Catch ex As Exception

        End Try
        btnAgregar.Visible = False : btnEliminar.Visible = False
        btnEditar.Visible = True : btnCancelar.Visible = True
        txtCodigo.Enabled = True
        vNuevo = False
        VNuevoInsertar = dgwDetalleDev.RowCount
        txtCodigo.Focus()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As System.EventArgs) Handles btnEditar.Click
        ModificarDetalleCompra()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Limpiamos()
        btnAgregar.BringToFront() : btnEliminar.BringToFront()
        txtCodigo.Enabled = True
        txtCodigo.Focus()
        modifDet = 0
    End Sub

    Private Sub BuscarDevolucionTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles BuscarDevolucionTextBox.GotFocus
        BuscarDevolucionTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarDevolucionTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles BuscarDevolucionTextBox.LostFocus
        BuscarDevolucionTextBox.BackColor = Color.Tan
    End Sub

End Class
