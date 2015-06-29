Imports System
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Imports System.Windows.Forms
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class AperturaCierreCaja
#Region "Fields"

    Dim Anho As String
   
    Dim CCotizacion, IImporte, MMoneda As String
    Private cmd As SqlCommand
    Dim Ctrl, N, G, T As Boolean
    Dim del As Integer
    Dim ErrorCot As Integer

    '#################Variables para los permisos ########################
    Dim dr As SqlDataReader
    Dim FechadeCierre As String
    Dim FechaFiltro1, FechaFiltro2 As Date

   

    '#################### Para el filtro de fechas ##############################
    Dim Mes As String
    Private myTrans As SqlTransaction
    Dim sel, upd, ins, anu, pri, ajuste As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String

    '#################Variables de conexion usadas en la transaccion######
    Private sqlc As SqlConnection
    Dim w As New Funciones.Funciones
    Dim ID_APERTURA As Integer
    Dim permiso As Double

    Dim arrValues() As String
    'Flag para la tecla BackSpace  
    Private bKeyBack As Boolean
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


    Private Sub AperturaCierreCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 148)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        Me.Cierres_detTableAdapter.Fill(Me.DsCaja1.cierres_det)
        Me.MovimientosTableAdapter.Fill(Me.DsCaja1.movimientos)

        Try
            Me.TIPOFORMACOBROTableAdapter.Fill(Me.DsCaja1.TIPOFORMACOBRO)
        Catch ex As Exception

        End Try
        Try
            Me.MONEDATableAdapter.Fill(Me.DsCaja1.MONEDA)
        Catch ex As Exception

        End Try
        ajuste = 0

        LimpiarControles()
        cbxMonedaApertura.Focus()
        FechaHoy.Text = Today.ToShortDateString

        CierresTableAdapter.Fill(DsCaja1.cierres, Me.LblCaja.Text)
        If GridViewCierre.RowCount <> 0 Then
            VisiblePanel(2)
            CierrePictureBox.Image = My.Resources.CerradoActive
        Else
            VisiblePanel(1)
            AperturaPictureBox.Image = My.Resources.AbiertoActive
        End If
        lblDescripCaja.Text = w.FuncionConsultaString("NUMEROCAJA", "CAJA", "NUMCAJA", Me.LblCaja.Text)
        lblNroApertura.Text = w.MaximoconWhere("CAST(apertura_num AS INT)", "aperturas", " id_caja", NumCaja)
    End Sub

    Private Sub VisiblePanel(ByVal numero As Integer)
        Select Case numero
            Case 1
                PanelApertura.Visible = True
                PanelCierreCaja.Visible = False
                PanelIngresoEgreso.Visible = False

                LimpiarControles()
                InicializaFechaFiltro()

            Case 2
                PanelApertura.Visible = True
                PanelCierreCaja.Visible = True
                PanelIngresoEgreso.Visible = False

                LimpiarControles()
                InicializaFechaFiltro()

            Case 3
                PanelIngresoEgreso.Visible = True
                PanelApertura.Visible = False
                PanelCierreCaja.Visible = False

                Dim IdApertura As Integer
                IdApertura = w.MaximoconWhere("id_apertura", "aperturas", "id_caja=" & NumCaja & " AND codsucursal ", SucCodigo)

                If IdApertura <> 0 Then
                    LblId_AperturaActual.Text = IdApertura
                    MtosingresoegresodetalleTableAdapter.Fill(DsCaja1.mtosingresoegresodetalle, IdApertura)
                End If
        End Select
    End Sub
    Private Sub InicializaFechaFiltro()
        Dim nromes, nroaño As Integer

        nromes = Today.Month
        nroaño = Today.Year

        FechaFiltro1 = New DateTime(nroaño, nromes, 1)
        FechaFiltro2 = New DateTime(nroaño, nromes, DateTime.DaysInMonth(nroaño, nromes))
    End Sub
    Private Sub FechaFiltro()
        Dim nromes, nroaño As Integer
        nromes = CmbMesApertura.SelectedIndex + 1
        nroaño = CInt(CmbAnhoApertura.Text)

        FechaFiltro1 = New DateTime(nroaño, nromes, 1)
        FechaFiltro2 = New DateTime(nroaño, nromes, DateTime.DaysInMonth(nroaño, nromes))
    End Sub

    Private Sub LimpiarControles()
        TxtMontoApertura.Text = "0"
        TxtImporteCierre.Text = ""
    End Sub

    Private Sub AperturaPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AperturaPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 16)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para dar apertura a la caja", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            AperturaPictureBox.Image = My.Resources.AbiertoActive
            CierrePictureBox.Image = My.Resources.Cerrado
            IngresoPictureBox.Image = My.Resources.AjusteCaja
            VisiblePanel(1)
        End If
    End Sub

    Private Sub CierrePictureBFox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierrePictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 17)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para cerrar la caja", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            AperturaPictureBox.Image = My.Resources.Abierto
            CierrePictureBox.Image = My.Resources.CerradoActive
            IngresoPictureBox.Image = My.Resources.AjusteCaja
            VisiblePanel(2)
        End If
    End Sub

    Private Sub BtnAgregarApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarApertura.Click
        Dim MaxIdApertura, ExisteCierre As Integer
        Dim maxidcajausuario As Integer


        If FechaHoy.Text.Trim = "" Or FechaHoy.Text = "  /  /    " Then
            MessageBox.Show("Ingrese una fecha", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FechaHoy.Focus()
            Exit Sub
        End If
        If cbxMonedaApertura.SelectedValue = Nothing Then
            MessageBox.Show("Elija la moneda", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxMonedaApertura.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(TxtMontoApertura.Text) Then
            MessageBox.Show("Debe introducir un monto correcto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMontoApertura.Focus()
            Exit Sub
        ElseIf CDec(TxtMontoApertura.Text) = 0 Then
            MessageBox.Show("Debe introducir un monto mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMontoApertura.Focus()
            Exit Sub
        End If


        If cbxTipoCobroApertura.SelectedValue = Nothing Then
            MessageBox.Show("Elija la forma de dinero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxMonedaApertura.Focus()
            Exit Sub
        End If

        'Verifica si ya existen registros en apertura para la primera vez 
        Dim cant As Integer
        cant = w.CantidadRegistro("id_apertura", "aperturas")
        If cant > 0 Then
            'Verifica si la apertura ya tiene cierre 
            Try
                MaxIdApertura = w.MaximoconWhere("id_apertura", "aperturas", "id_caja", NumCaja)
                If MaxIdApertura > 0 Then
                    ExisteCierre = w.MaximoconWhere("id_apertura", "cierres", "id_apertura", MaxIdApertura)
                    If ExisteCierre > 0 Then
                        If w.FuncionConsulta("id_apertura", "aperturas", "id_usuario", UsuCodigo) > 0 Then
                            'Si existe capturar el codigo de caja y preguntar si es igual al codigo de caja con el que se logueo el usuario 
                            'Caso positivo no puede insertar caso negativo si puede insertar 
                            Try
                                maxidcajausuario = w.MaximoconWhere("id_apertura", "aperturas", "id_usuario=" & UsuCodigo & " and id_empresa", EmpCodigo)
                            Catch ex As Exception

                            End Try
                        End If
                    Else
                        MessageBox.Show("No puede realizar otra apertura hasta que cierre la caja:" & NumCaja & "", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                        cbxMonedaApertura.Focus()
                    End If
                Else
                    Try
                        maxidcajausuario = w.MaximoconWhere("id_apertura", "aperturas", "id_usuario=" & UsuCodigo & " and id_empresa", EmpCodigo)
                    Catch ex As Exception

                    End Try
                    If maxidcajausuario > 0 Then
                        If w.MaximoconWhere("id_apertura", "cierres", "id_apertura", maxidcajausuario) > 0 Then
                        Else

                            MessageBox.Show("El usuario : " & UsuDescripcion & " tiene abierta otra caja que no ha cerrado aún, no puede abrir otra caja ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                            cbxMonedaApertura.Focus()
                        End If
                    End If


                    If w.CountconWhere("id_apertura", "aperturas", "id_caja", NumCaja) > 0 Then
                        'Verifica que el usuario que hizo la apertura no pueda hacer otra apertura con otra caja
                        If w.FuncionConsulta("id_apertura", "aperturas", "id_usuario", UsuCodigo) > 0 Then


                            'Si existe capturar el codigo de caja y preguntar si es igual al codigo de caja con el que se logueo el usuario 
                            'Caso positivo no puede insertar caso negativo si puede insertar 
                            Dim CodigoCaja As Integer
                            Try
                                CodigoCaja = w.MaximoconWhere("id_apertura", "aperturas", "id_usuario=" & UsuCodigo & " and id_empresa=" & EmpCodigo & " and id_apertura", MaxIdApertura)
                                If CodigoCaja = NumCaja Or CodigoCaja = 0 Then
                                Else
                                    MessageBox.Show("El usuario : " & UsuDescripcion & " tiene abierta otra caja que no ha cerrado aún, no puede abrir otra caja ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                    cbxMonedaApertura.Focus()
                                End If

                            Catch ex As Exception

                            End Try
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try

            'Agregar
        End If

        For I = 1 To GridViewApertura1.RowCount
            If cbxTipoCobroApertura.SelectedValue = GridViewApertura1.Rows(I - 1).Cells("CODTIPOFORMACOBRO").Value _
            And cbxMonedaApertura.SelectedValue = GridViewApertura1.Rows(I - 1).Cells("CODMONEDA1").Value Then
                MessageBox.Show("No puede repetir la moneda y con el mismo tipo de dinero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxMonedaApertura.Focus()
                Exit Sub
            End If
        Next
        GridViewApertura1.Rows.Add()
        Dim C As Integer = GridViewApertura1.RowCount
        GridViewApertura1.Rows(C - 1).Cells("TIPO").Value = cbxTipoCobroApertura.Text
        GridViewApertura1.Rows(C - 1).Cells("CODTIPOFORMACOBRO").Value = cbxTipoCobroApertura.SelectedValue
        GridViewApertura1.Rows(C - 1).Cells("CODMONEDA1").Value = cbxMonedaApertura.SelectedValue
        GridViewApertura1.Rows(C - 1).Cells("Moneda1").Value = cbxMonedaApertura.Text
        GridViewApertura1.Rows(C - 1).Cells("Monto").Value = TxtMontoApertura.Text
        LimpiarControles()
        cbxMonedaApertura.Focus()
    End Sub

    Private Sub TxtBuscarApertura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscarApertura.GotFocus
        If TxtBuscarApertura.Text = "Buscar..." Then
            TxtBuscarApertura.Text = ""
        End If
    End Sub

    Private Sub TxtBuscarApertura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscarApertura.LostFocus
        If TxtBuscarApertura.Text = "" Then
            TxtBuscarApertura.Text = "Buscar..."
        End If
    End Sub

    Private Sub TxtBuscarApertura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscarApertura.TextChanged
        If TxtBuscarApertura.Text <> "Buscar..." Then
            Me.AperturasBindingSource.Filter = "apertura_num " & _
            "LIKE '%" & TxtBuscarApertura.Text & "%' OR DESUSUARIO " & _
            "LIKE '%" & TxtBuscarApertura.Text & "%' OR NUMEROCAJA LIKE '%" & TxtBuscarApertura.Text & "%'  "
        End If
    End Sub

    Private Sub BtnFiltroApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltroApertura.Click
        FechaFiltro()
        Me.AperturasTableAdapter.Fill(DsCaja1.aperturas, UsuCodigo, FechaFiltro1, FechaFiltro2, SucCodigo)

    End Sub

    Private Sub InsertaApertura()
        Dim fecha As String
        Dim fecha2 As String = FechaHoy.Text
        Dim hora As String = Now.ToString("HH:mm:ss")

        'Obtenemos el Nro de la Apertura (ultimo nro por caja)
        Dim MaxNumApertura As Integer = w.MaximoconWhere("CAST(apertura_num AS INT)", "aperturas", " id_caja", NumCaja)
        MaxNumApertura = MaxNumApertura + 1

        Dim MaxIdApertura As Integer = w.Maximo("id_apertura", "aperturas")
        MaxIdApertura = MaxIdApertura + 1
        Txtid_apertura.Text = MaxIdApertura

        fecha = fecha2 + " " + hora
        sql = ""
        sql = "INSERT INTO [aperturas] ([id_apertura] ,[fechapaertura],[id_usuario],[id_empresa],[id_caja],[apertura_num],[codsucursal])" & _
              "VALUES (" & MaxIdApertura & ", convert(datetime,'" & fecha & "',103), " & UsuCodigo & ", " & EmpCodigo & "," & NumCaja & " ," & _
              "'" & MaxNumApertura & "'," & SucCodigo & " )"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaAperturaDetalle()
        Dim c, id_apertura_det, id_apertura, id_tipo_dinero, id_moneda As Integer
        Dim MontoCot, CotC As Decimal
        Dim monto, cotizacioningreso1 As String
        Dim IDMovimiento As Long
        Dim ImporteReal As Decimal

        IDMovimiento = w.Maximo("id_movimiento", "movimientos")
        c = GridViewAperturaDet.Rows.Count

        For i = 1 To c
            id_apertura_det = GridViewAperturaDet.Rows(i - 1).Cells("IdaperturadetDataGridViewTextBoxColumn").Value
            id_apertura = GridViewAperturaDet.Rows(i - 1).Cells("IdaperturaDataGridViewTextBoxColumn").Value
            id_tipo_dinero = GridViewAperturaDet.Rows(i - 1).Cells("IdtipodineroDataGridViewTextBoxColumn").Value
            id_moneda = GridViewAperturaDet.Rows(i - 1).Cells("IdmonedaDataGridViewTextBoxColumn").Value

            cotizacioningreso1 = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", CInt(id_moneda) & " ORDER BY FECHAMOVIMIENTO DESC")
            If cotizacioningreso1 = 0 Then
                MessageBox.Show("Ingrese una Cotización para la Moneda ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ErrorCot = 1
                Exit Sub
            End If

            cotizacioningreso1 = cotizacioningreso1.Replace(".", "")
            cotizacioningreso1 = cotizacioningreso1.Replace(",", ".")

            monto = GridViewAperturaDet.Rows(i - 1).Cells("MontoDataGridViewTextBoxColumn").Value
            monto = Funciones.Cadenas.QuitarCad(monto, ".")
            monto = Replace(monto, ",", ".")

            sql = ""
            sql = "INSERT INTO [aperturas_det] " & _
               "([id_apertura_det]" & _
               ",[id_apertura] " & _
               ",[id_tipo_dinero] " & _
               ",[monto] " & _
               ",[id_moneda]) " & _
               "VALUES (" & id_apertura_det & ", " & _
               "" & id_apertura & " , " & _
               "" & id_tipo_dinero & "," & _
               "" & monto & "," & _
               "" & id_moneda & ") "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            IDMovimiento = IDMovimiento + 1
            MontoCot = Replace(monto, ".", ",")
            CotC = Replace(cotizacioningreso1, ".", ",")
            ImporteReal = MontoCot * CotC
            InsertaMovimientos(IDMovimiento, id_apertura, id_moneda, id_tipo_dinero, cotizacioningreso1, "Apertura " & GridViewAperturaDet.Rows(i - 1).Cells("DESFORCOBRODataGridViewTextBoxColumn").Value, CInt(ImporteReal), "Entrada")
        Next

    End Sub

    Private Sub BtnConfirmaApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfirmaApertura.Click
        permiso = PermisoAplicado(UsuCodigo, 16)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para realizar una Apertura", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If MessageBox.Show("¿Esta seguro antes de confirmar?  ", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            CierresTableAdapter.Fill(DsCaja1.cierres, Me.LblCaja.Text)
            Aperturas_detTableAdapter.Fill(DsCaja1.aperturas_det)
            ConfirmarApertura()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ConfirmarApertura()
        Dim transaction As SqlTransaction = Nothing
        Dim CodigoAudi, Variable As Integer
        If GridViewApertura1.Rows.Count = 0 Then
            Exit Sub
        End If
        '########################################
        'INSERTAR: si el codigo es nuevo inserta
        '########################################
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            ErrorCot = 0
            AperturasTableAdapter.FillTotal(DsCaja1.aperturas)
            AperturasBindingSource.AddNew()

            InsertaApertura()
            VolcarGrillaApertura()
            InsertaAperturaDetalle()

            If ErrorCot = 0 Then

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, EmpCodigo, "APERTURAS", CodigoAudi.ToString, "INSERCIÓN EN LA TABLA APERTURAS", _
                                                           Today, EmpCodigo, "NULL", 1, 0, 0)

                myTrans.Commit()
                lblCuentasEstado.Text = "Grabado"
                CierresTableAdapter.Fill(DsCaja1.cierres, Me.LblCaja.Text)
                AperturasBindingSource.MoveLast()
                Me.Aperturas_detTableAdapter.Fill(Me.DsCaja1.aperturas_det)
                GridViewApertura1.Rows.Clear()
            Else
                Exit Sub
            End If

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch

            End Try

            MsgBox(ex.ToString)
            MessageBox.Show("Ocurrió un error al insertar el registro", _
                                                   "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AperturasBindingSource.CancelEdit()
            AperturasdetBindingSource.CancelEdit()
        Finally
            sqlc.Close()
        End Try


    End Sub

    Private Sub BtnEliminarApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarApertura.Click
        If GridViewApertura1.RowCount > 0 Then
            GridViewApertura1.Rows.Remove(GridViewApertura1.CurrentRow)
        End If
    End Sub

    Private Sub VolcarGrillaApertura()

        For i = 1 To GridViewApertura1.RowCount

            AperturasdetBindingSource.AddNew()
            Dim c As Integer = GridViewAperturaDet.Rows.Count

            GridViewAperturaDet.Rows(c - 1).Cells("IdaperturaDataGridViewTextBoxColumn").Value = Txtid_apertura.Text
            GridViewAperturaDet.Rows(c - 1).Cells("IdmonedaDataGridViewTextBoxColumn").Value = GridViewApertura1.Rows(i - 1).Cells("CODMONEDA1").Value
            GridViewAperturaDet.Rows(c - 1).Cells("DESMONEDADataGridViewTextBoxColumn").Value = GridViewApertura1.Rows(i - 1).Cells("Moneda1").Value
            GridViewAperturaDet.Rows(c - 1).Cells("IdtipodineroDataGridViewTextBoxColumn").Value = GridViewApertura1.Rows(i - 1).Cells("CODTIPOFORMACOBRO").Value
            GridViewAperturaDet.Rows(c - 1).Cells("DESFORCOBRODataGridViewTextBoxColumn").Value = GridViewApertura1.Rows(i - 1).Cells("TIPO").Value
            GridViewAperturaDet.Rows(c - 1).Cells("MontoDataGridViewTextBoxColumn").Value = CDec(GridViewApertura1.Rows(i - 1).Cells("Monto").Value)
        Next
    End Sub

    Private Sub cbxMonedaApertura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMonedaApertura.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TxtMontoApertura.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub TxtMontoApertura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMontoApertura.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxTipoCobroApertura.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxTipoCobroApertura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoCobroApertura.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            BtnAgregarApertura.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxMonedaCierre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMonedaCierre.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TxtImporteCierre.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub TxtImporteCierre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImporteCierre.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxTipoCobroCierre.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxTipoCobroCierre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipoCobroCierre.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            BtnAgregarCierre.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub BtnAgregarCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarCierre.Click
        Dim MaxIdApertura, ExisteCierre As Integer


        If FechaHoy.Text.Trim = "" Or FechaHoy.Text = "  /  /    " Then
            MessageBox.Show("Ingrese una fecha", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FechaHoy.Focus()
            Exit Sub
        End If
        If cbxMonedaCierre.SelectedValue = Nothing Then
            MessageBox.Show("Elija la moneda", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxMonedaCierre.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(TxtImporteCierre.Text) Then
            MessageBox.Show("Debe introducir algun monto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtImporteCierre.Focus()
            Exit Sub
        ElseIf CDec(TxtImporteCierre.Text) = 0 Then
            MessageBox.Show("Debe introducir un monto mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtImporteCierre.Focus()
            Exit Sub
        End If
        If cbxTipoCobroCierre.SelectedValue = Nothing Then
            MessageBox.Show("Elija la forma de dinero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxTipoCobroCierre.Focus()
            Exit Sub
        End If

        'Verifica si la apertura ya tiene cierre 
        Try
            MaxIdApertura = w.MaximoconWhere("id_apertura", "aperturas", "id_caja", NumCaja)

            If MaxIdApertura > 0 Then
                ExisteCierre = w.MaximoconWhere("id_apertura", "cierres", "id_apertura", MaxIdApertura)
                If ExisteCierre > 0 Then
                    MessageBox.Show("La caja: " & NumCaja & " ya está cerrada", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                    cbxMonedaCierre.Focus()
                End If
            Else

            End If
        Catch ex As Exception

        End Try

        'Agregar


        For I = 1 To GridViewCierre1.RowCount
            If cbxTipoCobroCierre.SelectedValue = GridViewCierre1.Rows(I - 1).Cells("CodTipoDinero").Value _
            And cbxMonedaCierre.SelectedValue = GridViewCierre1.Rows(I - 1).Cells("CodMonedaCierre").Value Then
                MessageBox.Show("No se puede volver a cargar un Monto con el mismo tipo de Moneda y Tipo!", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxMonedaCierre.Focus()
                Exit Sub
            End If
        Next
        GridViewCierre1.Rows.Add()
        Dim C As Integer = GridViewCierre1.RowCount
        GridViewCierre1.Rows(C - 1).Cells("TipoDineroCierre").Value = cbxTipoCobroCierre.Text
        GridViewCierre1.Rows(C - 1).Cells("CodTipoDinero").Value = cbxTipoCobroCierre.SelectedValue
        GridViewCierre1.Rows(C - 1).Cells("CodMonedaCierre").Value = cbxMonedaCierre.SelectedValue
        GridViewCierre1.Rows(C - 1).Cells("MonedaCierre").Value = cbxMonedaCierre.Text
        GridViewCierre1.Rows(C - 1).Cells("MontoCierre").Value = TxtImporteCierre.Text

        GridViewCierreDetalle.Rows.Add()
        GridViewCierreDetalle.Rows(C - 1).Cells("IdaperturaDataGridViewTextBoxColumn1").Value = MaxIdApertura
        GridViewCierreDetalle.Rows(C - 1).Cells("IdmonedaDataGridViewTextBoxColumn1").Value = GridViewCierre1.Rows(C - 1).Cells("CodMonedaCierre").Value
        GridViewCierreDetalle.Rows(C - 1).Cells("DESMONEDADataGridViewTextBoxColumn1").Value = GridViewCierre1.Rows(C - 1).Cells("MonedaCierre").Value
        GridViewCierreDetalle.Rows(C - 1).Cells("IdtipodineroDataGridViewTextBoxColumn1").Value = GridViewCierre1.Rows(C - 1).Cells("CodTipoDinero").Value
        GridViewCierreDetalle.Rows(C - 1).Cells("DESFORCOBRODataGridViewTextBoxColumn1").Value = GridViewCierre1.Rows(C - 1).Cells("TipoDineroCierre").Value
        GridViewCierreDetalle.Rows(C - 1).Cells("MontoDataGridViewTextBoxColumn1").Value = CDec(GridViewCierre1.Rows(C - 1).Cells("MontoCierre").Value)

        LimpiarControles()
        cbxMonedaCierre.Focus()
    End Sub

    Private Sub BtnEliminarCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarCierre.Click

        If GridViewCierre1.RowCount > 0 Then
            'GridViewCierreDetalle. = GridViewCierreDetalle(GridViewCierre1.CurrentCellAddress.Y, GridViewCierre1.CurrentCellAddress.X)
            GridViewCierreDetalle.Rows.Remove(GridViewCierreDetalle.Rows(GridViewCierre1.CurrentRow.Index))
            GridViewCierre1.Rows.Remove(GridViewCierre1.CurrentRow)
        End If
    End Sub

    Private Sub BtnConfirmarCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfirmarCierre.Click
        If MessageBox.Show("¿Esta seguro antes de confirmar?  ", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If
        permiso = PermisoAplicado(UsuCodigo, 17)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para realizar un cierre", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Try
            CierresTableAdapter.Fill(DsCaja1.cierres, Me.LblCaja.Text)
            Cierres_detTableAdapter.Fill(DsCaja1.cierres_det)
            ConfirmarCierre()
        Catch ex As Exception

        End Try
    End Sub
    'Private Sub VolcarGrillaCierre()
    '    Dim f As New Funciones.Funciones
    '    Dim idapertura As Integer

    '    Try
    '        idapertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja=" & NumCaja & " AND  id_empresa", EmpCodigo.ToString)
    '    Catch ex As Exception

    '    End Try
    '    For i = 1 To GridViewCierre1.RowCount

    '        CierresdetBindingSource.AddNew()
    '        Dim c As Integer = GridViewCierreDetalle.Rows.Count

    '        GridViewCierreDetalle.Rows(c - 1).Cells("IdaperturaDataGridViewTextBoxColumn1").Value = idapertura
    '        GridViewCierreDetalle.Rows(c - 1).Cells("IdmonedaDataGridViewTextBoxColumn1").Value = GridViewCierre1.Rows(i - 1).Cells("CodMonedaCierre").Value
    '        GridViewCierreDetalle.Rows(c - 1).Cells("DESMONEDADataGridViewTextBoxColumn1").Value = GridViewCierre1.Rows(i - 1).Cells("MonedaCierre").Value
    '        GridViewCierreDetalle.Rows(c - 1).Cells("IdtipodineroDataGridViewTextBoxColumn1").Value = GridViewCierre1.Rows(i - 1).Cells("CodTipoDinero").Value
    '        GridViewCierreDetalle.Rows(c - 1).Cells("DESFORCOBRODataGridViewTextBoxColumn1").Value = GridViewCierre1.Rows(i - 1).Cells("TipoDineroCierre").Value
    '        GridViewCierreDetalle.Rows(c - 1).Cells("MontoDataGridViewTextBoxColumn1").Value = CDec(GridViewCierre1.Rows(i - 1).Cells("MontoCierre").Value)
    '    Next
    'End Sub

    Private Sub ConfirmarCierre()
        Dim transaction As SqlTransaction = Nothing
        Dim CodigoAudi, Variable As Integer

        If GridViewCierre1.Rows.Count = 0 Then
            Exit Sub
        End If
        '########################################
        'INSERTAR: si el codigo es nuevo inserta
        '########################################
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            ErrorCot = 0
            CierresBindingSource.AddNew()

            InsertaCierre()
            'VolcarGrillaCierre()
            InsertaCierreDetalle()

            If ErrorCot = 0 Then
                InsertarEnMovimiento()
                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, EmpCodigo, "CIERRES", _
                                                           CodigoAudi.ToString, "INSERCIÓN EN LA TABLA CIERRES", _
                                                           Today, EmpCodigo, "NULL", 1, 0, 0)

                myTrans.Commit()
                lblCuentasEstado.Text = "Grabado"
                CierresTableAdapter.Fill(DsCaja1.cierres, Me.LblCaja.Text)
                Cierres_detTableAdapter.Fill(DsCaja1.cierres_det)
                GridViewCierre1.Rows.Clear()
            Else
                Exit Sub
            End If

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch

            End Try
            MsgBox(ex.ToString)
            MessageBox.Show("Ocurrió un error al insertar el registro", _
                                                   "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblCuentasEstado.Text = "Error al Grabar!"
            CierresBindingSource.CancelEdit()
            CierresdetBindingSource.CancelEdit()
        Finally
            sqlc.Close()
        End Try

        Try

            'CierresTableAdapter.Fill(DsCaja1.cierres, FechaFiltro1, FechaFiltro2)
            'Me.Cierres_detTableAdapter.Fill(Me.DsCaja1.cierres_det)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub InsertarEnMovimiento()
        Dim f As New Funciones.Funciones
        Dim c, id_apertura, id_tipo_dinero, id_moneda As Integer
        Dim MontoCot, CotC As Decimal
        Dim monto, cotizacioningreso1 As String
        Dim IDMovimiento As Long
        Dim ImporteReal As Decimal


        Try
            id_apertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja=" & NumCaja & " AND  id_empresa", EmpCodigo.ToString)
            IDMovimiento = w.Maximo("id_movimiento", "movimientos")
        Catch ex As Exception

        End Try

        c = GridViewCierre1.Rows.Count

        For i = 1 To c
            id_tipo_dinero = GridViewCierre1.Rows(i - 1).Cells("CodTipoDinero").Value
            id_moneda = GridViewCierre1.Rows(i - 1).Cells("CodMonedaCierre").Value

            cotizacioningreso1 = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", CInt(id_moneda) & " ORDER BY FECHAMOVIMIENTO DESC")
            cotizacioningreso1 = cotizacioningreso1.Replace(".", "")
            cotizacioningreso1 = cotizacioningreso1.Replace(",", ".")

            monto = "-" + GridViewCierre1.Rows(i - 1).Cells("MontoCierre").Value
            monto = Funciones.Cadenas.QuitarCad(monto, ".")
            monto = Replace(monto, ",", ".")

            IDMovimiento = IDMovimiento + 1
            MontoCot = Replace(monto, ".", ",")
            CotC = Replace(cotizacioningreso1, ".", ",")
            ImporteReal = MontoCot * CotC
            InsertaMovimientos(IDMovimiento, id_apertura, id_moneda, id_tipo_dinero, cotizacioningreso1, "Cierre " & GridViewCierre1.Rows(i - 1).Cells("TipoDineroCierre").Value, CInt(ImporteReal), "Salida")
        Next
    End Sub


    Private Sub InsertaCierre()
        Dim f As New Funciones.Funciones
        Dim fechaapertura As DateTime
        Dim fechacadena As String
        Dim idapertura As Integer
        fechacadena = ""
        Try
            '  idapertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja=" & NumCaja & " AND id_usuario=" & UsuCodigo & " AND id_empresa", EmpCodigo.ToString)
            idapertura = f.MaximoconWhere("id_apertura", "aperturas", "id_caja=" & NumCaja & " AND id_empresa", EmpCodigo.ToString)
            fechaapertura = f.FuncionConsultaString("fechapaertura", "Aperturas", "id_apertura", idapertura)
            fechacadena = fechaapertura.ToString("dd/MM/yyyy  HH:mm:ss")

        Catch ex As Exception

        End Try

        Dim fecha As String
        Dim fecha2 As String = FechaHoy.Text
        Dim hora As String = Now.ToString("HH:mm:ss")
        fecha = fecha2 + " " + hora
        sql = ""
        sql = "INSERT INTO [cierres]" & _
           "([id_apertura]" & _
           ",[id_usuario] " & _
           ",[id_empresa] " & _
           ",[fecha_apertura] " & _
           ",[fecha_cierre] " & _
           ",[cierre_num],[codsucursal]) " & _
           "VALUES (" & idapertura & ", " & _
           "" & UsuCodigo & "," & _
           "" & EmpCodigo & "," & _
           "convert(datetime,'" & fechacadena & "',103), " & _
           "convert(datetime,'" & fecha & "',103), " & _
           "'" & idapertura.ToString & "'," & SucCodigo & " )"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaCierreDetalle()
        Dim c, id_cierre_det, id_apertura, id_tipo_dinero, id_moneda As Integer

        Dim monto, cotizacioningreso1 As String

        c = GridViewCierreDetalle.Rows.Count
        'Verificamos el MaxIdDatalle
        id_cierre_det = w.Maximo("id_cierre_det", "cierres_det")

        For i = 1 To c
            id_cierre_det = id_cierre_det + 1
            id_apertura = GridViewCierreDetalle.Rows(i - 1).Cells("IdaperturaDataGridViewTextBoxColumn1").Value
            id_tipo_dinero = GridViewCierreDetalle.Rows(i - 1).Cells("IdtipodineroDataGridViewTextBoxColumn1").Value
            id_moneda = GridViewCierreDetalle.Rows(i - 1).Cells("IdmonedaDataGridViewTextBoxColumn1").Value

            cotizacioningreso1 = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", CInt(id_moneda) & " ORDER BY FECHAMOVIMIENTO DESC")
            If cotizacioningreso1 = 0 Then
                MessageBox.Show("Ingrese una Cotización para la Moneda ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ErrorCot = 1
                Exit Sub
            End If

            cotizacioningreso1 = cotizacioningreso1.Replace(".", "")
            cotizacioningreso1 = cotizacioningreso1.Replace(",", ".")

            monto = (GridViewCierreDetalle.Rows(i - 1).Cells("MontoDataGridViewTextBoxColumn1").Value)
            monto = Funciones.Cadenas.QuitarCad(monto, ".")
            monto = Replace(monto, ",", ".")

            sql = ""
            sql = " INSERT INTO [cierres_det]" & _
               "([id_cierre_det]" & _
               ",[id_apertura] " & _
               ",[id_tipo_dinero] " & _
               ",[monto] " & _
               ",[id_moneda]) " & _
               "VALUES (" & id_cierre_det & ", " & _
               "" & id_apertura & " , " & _
               "" & id_tipo_dinero & "," & _
               "" & monto & "," & _
               "" & id_moneda & ") "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            'IDMovimiento = IDMovimiento + 1
            'MontoCot = Replace(monto, ".", ",")
            'CotC = Replace(cotizacioningreso1, ".", ",")
            'ImporteReal = MontoCot * CotC
            'InsertaMovimientos(IDMovimiento, id_apertura, id_moneda, id_tipo_dinero, cotizacioningreso1, "Cierre " & GridViewCierreDetalle.Rows(i - 1).Cells("DESFORCOBRODataGridViewTextBoxColumn1").Value, CInt(ImporteReal), "Salida")
        Next
    End Sub


    Private Sub IngresoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 18)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para hacer ajustes en esta ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            AperturaPictureBox.Image = My.Resources.Abierto
            CierrePictureBox.Image = My.Resources.Cerrado
            IngresoPictureBox.Image = My.Resources.AjusteCajaActive
            VisiblePanel(3)
        End If

    End Sub
#Region "Ingreso/Egreso"
    Private Sub BtnAgregarIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarIngreso.Click
        permiso = PermisoAplicado(UsuCodigo, 18)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para realizar Ajustes", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Dim MaxIdApertura, ExisteCierre As Integer

        'verificamos si existe una apertura de caja
        Dim CadenaCaja As String

        CadenaCaja = "id_caja=" & NumCaja & " AND codsucursal "
        MaxIdApertura = w.MaximoconWhere("id_apertura", "aperturas", CadenaCaja, SucCodigo)
        LblId_AperturaActual.Text = MaxIdApertura
        If MaxIdApertura = 0 Then
            If MessageBox.Show("Caja Nro: " & NumeroCaja & ",  Falta Abrir! Por tanto no podra hacer movimientos ", "POSEXPRESS") = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If FechaHoy.Text.Trim = "" Or FechaHoy.Text = "  /  /    " Then
            MessageBox.Show("Ingrese una fecha", "POSEXPRESS")
            FechaHoy.Focus()
            Exit Sub
        End If
        If cbxMonedaAjuste.SelectedValue = Nothing Then
            MessageBox.Show("Elija la moneda", "POSEXPRESS")
            cbxMonedaAjuste.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(TxtImporteIngreso.Text) Then
            MessageBox.Show("Debe introducir un monto", "POSEXPRESS")
            TxtImporteIngreso.Focus()
            Exit Sub
        ElseIf CDec(TxtImporteIngreso.Text) = 0 Then
            MessageBox.Show("Debe introducir un monto mayor a cero", "POSEXPRESS")
            TxtImporteIngreso.Focus()
            Exit Sub
        End If

        If cbxTipo.SelectedValue = Nothing Then
            MessageBox.Show("Elija la forma de dinero", "POSEXPRESS")
            cbxTipo.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(tbxConcepto.Text) Then
            MessageBox.Show("Ingrese la descripción del concepto", "POSEXPRESS")
            tbxConcepto.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(CmbEntradaSalida.Text) Then
            MessageBox.Show("Ingrese si es el entrada o salida de caja", "POSEXPRESS")
            CmbEntradaSalida.Focus()
            Exit Sub
        End If


        'Verifica si ya existen registros en apertura para la primera vez 
        Dim cant As Integer
        cant = w.CantidadRegistro("id_apertura", "aperturas")
        If cant > 0 Then
            ExisteCierre = w.MaximoconWhere("id_apertura", "cierres", "id_apertura", MaxIdApertura)
            If ExisteCierre > 0 Then
                MessageBox.Show("La caja ya cerró no puede insertar items", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim transaction As SqlTransaction = Nothing
            Dim CodigoAudi, Variable As Integer
            '########################################
            'INSERTAR: si el codigo es nuevo inserta
            '########################################
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                Dim cotizacioningreso1 As String
                Dim monto As String

                monto = TxtImporteIngreso.Text
                cotizacioningreso1 = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", cbxMonedaAjuste.SelectedValue)
                monto = monto * cotizacioningreso1

                monto = Funciones.Cadenas.QuitarCad(monto, ".")
                monto = Replace(monto, ",", ".")

                If CmbEntradaSalida.Text = "Salida" Then
                    monto = "-" + monto
                End If

                cotizacioningreso1 = cotizacioningreso1.Replace(".", "")
                cotizacioningreso1 = cotizacioningreso1.Replace(",", ".")

                Dim IDMovimiento As Long
                IDMovimiento = w.Maximo("id_movimiento", "movimientos")
                IDMovimiento = IDMovimiento + 1

                ajuste = 1
                InsertaMovimientos(IDMovimiento, LblId_AperturaActual.Text, cbxMonedaAjuste.SelectedValue, cbxTipo.SelectedValue, cotizacioningreso1, tbxConcepto.Text, monto, CmbEntradaSalida.Text)
                ajuste = 0

                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, EmpCodigo, "MOVIMIENTOS", _
                                                           CodigoAudi.ToString, "INSERCIÓN EN LA TABLA MOVIMIENTOS", _
                                                           Today, EmpCodigo, "NULL", 1, 0, 0)

                myTrans.Commit()
                MtosingresoegresodetalleTableAdapter.Fill(DsCaja1.mtosingresoegresodetalle, CDec(LblId_AperturaActual.Text))

                'Limpiamos los campos
                TxtImporteIngreso.Text = ""
                tbxConcepto.Text = ""
                CmbEntradaSalida.Text = ""

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch

                End Try
                MsgBox(ex.ToString)
                MessageBox.Show("Ocurrió un error al intentar insertar el registro", _
                                                       "POSEXPRESS")

            Finally
                sqlc.Close()
                ajuste = 0
            End Try

            Try

            Catch ex As Exception
            End Try


        End If
    End Sub

    Private Sub InsertaMovimientos(ByVal IDMovimiento As Long, ByVal IdApertura As Integer, ByVal IdMoneda As Integer, ByVal IdTipoDinero As Integer, _
                                   ByVal CotCambio As String, ByVal ConceptoMov As String, ByVal MontoMovi As String, ByVal TipoMov As String)
        Dim fecha As String
        Dim fecha2 As String = FechaHoy.Text
        Dim hora As String = Now.ToString("HH:mm:ss")
        fecha = fecha2 + " " + hora
        If ajuste = 1 Then ' Si es un Ajuste Ingreso-Egreso que al lado imprima el tipo dinero para que se visualice en los reportes de Caja
            ConceptoMov = ConceptoMov + " " + cbxTipo.Text
        End If

        sql = ""
        sql = "INSERT INTO [movimientos] " & _
               "([id_movimiento]" & _
               ",[id_apertura]" & _
               ",[id_usuario]" & _
               ",[id_empresa] " & _
               ",[fecha_mto] " & _
               ",[id_moneda] " & _
               ",[id_tipo_dinero] " & _
               ",[cotizacion1] " & _
               ",[cotizacion2] " & _
               " ,[vuelto] " & _
               ",[concepto] " & _
               ",[monto] " & _
               ",[codsucursal] " & _
               ",[entradasalida])" & _
               "VALUES (" & IDMovimiento & ", " & _
               "" & IdApertura & "," & _
               "" & UsuCodigo & "," & _
               "" & EmpCodigo & "," & _
               "convert(datetime,'" & fecha & "',103),  " & _
               "" & IdMoneda & "," & _
               "" & IdTipoDinero & "," & _
               "" & CotCambio & "," & _
               "0, 0," & _
               "'" & ConceptoMov & "'," & _
               "" & MontoMovi & "," & _
               "" & SucCodigo & "," & _
               "'" & TipoMov & "'" & _
               ")"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub EliminaMovimientos()
        sql = ""
        sql = "DELETE FROM MOVIMIENTOS WHERE id_movimiento=" & GridViewIngresos.CurrentRow.Cells("IdmovimientoDataGridViewTextBoxColumn").Value & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub BtnEliminarIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarIngreso.Click

        Dim MaxIdApertura, ExisteCierre As Integer
        Dim cant As Integer
        cant = w.CantidadRegistro("id_apertura", "aperturas")
        If GridViewIngresos.Rows.Count = 0 Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(LblId_AperturaActual.Text) Then
            MessageBox.Show("No hay apertura aún", "POSEXPRESS")
            Exit Sub

        End If
        If cant > 0 Then
            MaxIdApertura = LblId_AperturaActual.Text
            'MaxIdApertura = w.MaximoconWhere("id_apertura", "aperturas", "id_caja", NumCaja)
            ExisteCierre = w.MaximoconWhere("id_apertura", "cierres", "id_apertura", MaxIdApertura)
            If ExisteCierre > 0 Then
                MessageBox.Show("La caja ya cerró no puede eliminar items", "POSEXPRESS")
                Exit Sub
            End If

            Dim transaction As SqlTransaction = Nothing
            Dim CodigoAudi, Variable As Integer
            '########################################
            'INSERTAR: si el codigo es nuevo inserta
            '########################################
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try

                EliminaMovimientos()


                '############################
                'INSERCION DE LAS AUDITORIAS
                '############################
                CodigoAudi = funcion.Maximo("CODIGO", "AUDITORIATABLAS") + 1
                Variable = funcion.InsertarAuditoriaTablas(CodigoAudi, EmpCodigo, "MOVIMIENTOS", _
                                                           CodigoAudi.ToString, "ELIMINACIÓN EN LA TABLA MOVIMIENTOS", _
                                                           Today, EmpCodigo, "NULL", 0, 0, 1)

                myTrans.Commit()
                MtosingresoegresodetalleTableAdapter.Fill(DsCaja1.mtosingresoegresodetalle, CDec(LblId_AperturaActual.Text))
                MessageBox.Show("El registro ha sido eliminado correctamente", _
                  "POSEXPRESS")


                'Agregar


            Catch ex As Exception
                Try
                    myTrans.Rollback("Eliminar")
                Catch

                End Try
                MsgBox(ex.ToString)
                MessageBox.Show("Ocurrió un error al intentar eliminar el registro", _
                                                       "POSEXPRESS")

            Finally
                sqlc.Close()
            End Try

            Try

            Catch ex As Exception
            End Try


        End If
        LimpiarIngresoEgreso()
    End Sub
    Private Sub LimpiarIngresoEgreso()
        TxtImporteIngreso.Text = ""
        CmbEntradaSalida.Text = ""
        tbxConcepto.Text = ""
        cbxMonedaAjuste.Focus()
    End Sub
#End Region

    Private Sub cbxMonedaAjuste_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMonedaAjuste.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TxtImporteIngreso.Focus()
            KeyAscii = 0
        End If
    End Sub
    Private Sub TxtImporteIngreso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImporteIngreso.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxTipo.Focus()
            KeyAscii = 0
        End If
    End Sub
    Private Sub cbxTipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxTipo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbEntradaSalida.Focus()
            KeyAscii = 0
        End If
    End Sub
    Private Sub CmbTipoEntradaSalida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbEntradaSalida.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxConcepto.Focus()
            KeyAscii = 0
        End If
    End Sub
    Private Sub tbxConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxConcepto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            BtnAgregarIngreso.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.CierresTableAdapter.Fill(Me.DsCaja1.cierres, Me.LblCaja.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cbxTipoCobroCierre_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxTipoCobroCierre.SelectedIndexChanged

    End Sub
End Class