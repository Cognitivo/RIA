Imports System
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Imports System.Data.Common
Imports System.Windows.Forms
Imports EnviaInformes
Imports BDConexión
Imports CrystalDecisions.Shared

Public Class ComprasRetencion

#Region "Fields"

    Private ser As BDConexión.BDConexion
    Dim sql As String
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Dim f As New Funciones.Funciones
    Dim impresora As String
    Dim NroRetencion, RangoIDRetencion, ImprimeRenta As String
    Dim PorcRetencion, PorcRetencionRenta As Double
    Dim FechaFiltro1, FechaFiltro2 As String
    Private myTrans As SqlTransaction
    Private conexion As System.Data.SqlClient.SqlConnection
    Dim vgCodPago, nvoNumeroRetencion As String
    Dim btnuevo As Integer
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

#End Region

    Private Sub ComprasRetencion_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        Me.EMPRESATableAdapter.Fill(Me.DsRetencionCompra.EMPRESA)
        Me.RETCOMPPROVEEDORTableAdapter.Fill(Me.DsRetencionCompra.RETCOMPPROVEEDOR)
        Me.RETCOMPTIPOCOMPROBANTETableAdapter.Fill(Me.DsRetencionCompra.RETCOMPTIPOCOMPROBANTE)

        CmbAño.SelectedText = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1

        FechaFiltro()

        Try
            Dim dtporc As DataTable = EMPRESATableAdapter.GetData()
            If dtporc.Rows.Count > 0 Then
                Dim drporc As DataRow = dtporc.Rows(0)
                PorcRetencion = drporc("PORRETENCIO")
                PorcRetencionRenta = drporc("PORCRETRENTA")
                lblPorcRetRENTA.Text = FormatNumber(lblPorcRetRENTA.Text, 1) + " %"
                lblPorcRetIVA.Text = FormatNumber(lblPorcRetIVA.Text, 0) + " %"
            End If
            'TipoCompComboBox.SelectedIndex = 0
            ImprimeRenta = 0
            'IvaIncluidoComboBox.SelectedIndex = 0
        Catch ex As Exception

        End Try

        Try
            Me.RETENCIONCOMPRATableAdapter.FillByFecha(Me.DsRetencionCompra.RETENCIONCOMPRA, FechaFiltro1, FechaFiltro2)
        Catch ex As Exception
        End Try

        Deshabilitamos()
        BuscarRetencionTextBox.Focus()
        BtnAnular.Enabled = False
        lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
        LeerNroRetencion()
        PintarCeldas()
    End Sub

    Public Sub PintarCeldas()
        If ComprasSimpleGridView1.RowCount - 1 >= 1 Then
            For i = 0 To ComprasSimpleGridView1.RowCount - 1
                If ComprasSimpleGridView1.Rows(i).Cells("ESTADO").Value = 1 Then
                    ComprasSimpleGridView1.Item(1, i).Style.ForeColor = Color.Green

                ElseIf ComprasSimpleGridView1.Rows(i).Cells("ESTADO").Value = 2 Then
                    ComprasSimpleGridView1.Item(1, i).Style.ForeColor = Color.Maroon
                End If
            Next
        End If
    End Sub

    Private Sub Habilitamos()
        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Cursor = Cursors.Default

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand

        'ModificarPictureBox.Enabled = False
        'ModificarPictureBox.Image = My.Resources.EditOff
        'ModificarPictureBox.Cursor = Cursors.Default

        'EliminarPictureBox.Enabled = False
        'EliminarPictureBox.Image = My.Resources.DeleteOff
        'EliminarPictureBox.Cursor = Cursors.Default

        'GuardarPictureBox.Enabled = False
        'GuardarPictureBox.Image = My.Resources.Save
        'GuardarPictureBox.Cursor = Cursors.Hand

        ComprasSimpleGridView1.Enabled = False
        pnlCabecera.Enabled = True
        pnlDetalle.Enabled = True
        PanelAnular.Enabled = True

        'Botonsillos :)
        BuscarRetencionTextBox.Enabled = False
        BtnFiltro.Enabled = False
        pbxBuscarProveedor.Enabled = True
        tbxNroRetencion.Enabled = True
    End Sub

    Private Sub Deshabilitamos()
        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Default

        'ModificarPictureBox.Enabled = True
        'ModificarPictureBox.Image = My.Resources.Edit
        'ModificarPictureBox.Cursor = Cursors.Hand

        'EliminarPictureBox.Enabled = True
        'EliminarPictureBox.Image = My.Resources.Delete
        'EliminarPictureBox.Cursor = Cursors.Hand

        'GuardarPictureBox.Enabled = False
        'GuardarPictureBox.Image = My.Resources.SaveOff
        'GuardarPictureBox.Cursor = Cursors.Default

        ComprasSimpleGridView1.Enabled = True
        pnlCabecera.Enabled = False
        pnlDetalle.Enabled = False
        PanelAnular.Enabled = False

        'Botonsillos :)
        BuscarRetencionTextBox.Enabled = True
        BtnFiltro.Enabled = True
        pbxBuscarProveedor.Enabled = False
        tbxNroRetencion.Enabled = False
    End Sub

    Private Sub BuscarRetencionTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarRetencionTextBox.GotFocus
        BuscarRetencionTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarRetencionTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarRetencionTextBox.LostFocus
        BuscarRetencionTextBox.BackColor = Color.Gray
    End Sub

    Private Sub BuscarCompraTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarRetencionTextBox.TextChanged
        Try
            Me.RETENCIONCOMPRABindingSource.Filter = "NOMBRE LIKE '%" & BuscarRetencionTextBox.Text & "%' OR NUMRETENCION LIKE '%" & BuscarRetencionTextBox.Text & "%'"
            lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BuscarRetencionTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarRetencionTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ComprasSimpleGridView1.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub ImprimirRetPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirRetRentaPictureBox.Click
        'Debemos preguntar cuantas copias quiere hacer del documento
            Dim NroImpresion As Integer = InputBox("Ingrese el Nro de Copias a Imprimir: ", " Cantidad de Copias", "1")

        '---------------------------- IMPRIMIMOS ----------------------------
        Try
            'lblEstadoVentasPlus.Text = "Imprimiendo"
            Dim TipoImpresion, Imprimir As Integer
            Dim SQL As String = ""

            Dim CodigoMaq As Integer
            If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
                CodigoMaquina = f.FuncionConsultaString("DETPC.IP", "DETPC INNER JOIN PC ON DETPC.IP = PC.IP", "PC.NOMBRE='" & Dashboard.Cmb_Maquina.Text & "' AND DETPC.CODSUCURSAL", SucCodigo)
                CodigoMaq = CodigoMaquina
            Else
                CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
            End If

            SQL = "SELECT DETPC.IMPRIMIR,DETPC.IP,DETPC.IMPRESORA,TIPOCOMPROBANTE.FORMAIMPRESION FROM DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE " & _
                  "WHERE ACTIVO = 1 AND RETENCION = 1 AND DETPC.IP = " & CodigoMaq

            Dim dadatoscomp As New SqlDataAdapter(SQL, ser.CadenaConexion)
            Dim dtdatoscomp As New DataTable
            dadatoscomp.Fill(dtdatoscomp)
            Dim drdatoscomp As DataRow

            drdatoscomp = dtdatoscomp.Rows(0)
            TipoImpresion = drdatoscomp("FORMAIMPRESION")
            Imprimir = drdatoscomp("IMPRIMIR")
            CodigoMaquina = drdatoscomp("IP")
            impresora = drdatoscomp("IMPRESORA")


            'se verifica el tipo de impresion para el tipo de comprobante actuamente seleccionado y de acuerdo a eso realizamos la impresion correspondiente
            'en caso de que este marcado la opcion de imprimir en la ventana "Rango de Comprobantes" 

            For i = 1 To NroImpresion
                'If TipoImpresion = 0 Then   'Formato Ticket
                '    If Imprimir = 1 Then 'Se imprime
                '        If ImprimeRenta = 1 Then
                '            ' imprimirRetRentaTicket()  Hacer tambien Formato Ticket
                '        Else
                '            ' imprimirRetTicket()  Hacer tambien Formato Ticket
                '        End If
                '    End If
                If TipoImpresion = 1 Then 'Formato Impresora
                    If Imprimir = 1 Then 'Se imprime
                        If ImprimeRenta = 1 Then
                            ImprimirReporteRetencionRenta()
                        Else
                            ImprimirReporteRetencion()
                        End If
                    End If
                End If
            Next

            'Desabilitamos
            Deshabilitamos()
            CancelarToolStripMenuItem.Enabled = False
            BtnFiltro_Click(Nothing, Nothing)
        Catch ex As Exception
            MessageBox.Show("Error al imprimir, no existe la impresora ", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
    End Sub

    Private Sub ImprimirReporteRetencion()
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.RetencionIVA
        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        informe.SetDataSource(InfRetencion())

        informe.PrintOptions.PaperSource = PaperSource.Upper  'bandeja
        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress")
        End Try

        informe.PrintToPrinter(1, False, 0, 0)

    End Sub

    Private Sub ImprimirReporteRetencionRenta()
        'Crear el objeto informe
        Dim informe = New ReportesPersonalizados.RetencionRENTA
        'configurar las opciones del informe
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        informe.SetDataSource(InfRetencion())

        informe.PrintOptions.PaperSource = PaperSource.Upper  'bandeja
        Try
            informe.PrintOptions.PrinterName = impresora  'impresora
        Catch ex As Exception
            MessageBox.Show("Nombre de impresora invalida", "POSExpress")
        End Try

        informe.PrintToPrinter(1, False, 0, 0)

    End Sub

    Public Function InfRetencion() As DataSet
        Dim direccion As String = f.FuncionConsultaString("DIRECCION", "PROVEEDOR", "CODPROVEEDOR", ProvFactComboBox.SelectedValue)
        Dim RUC As String = f.FuncionConsultaString("RUC_CIN", "PROVEEDOR", "CODPROVEEDOR", ProvFactComboBox.SelectedValue)
        Dim Config5 As String = f.FuncionConsultaString("CONFIG5", "MODULO", "MODULO_ID", 4)
        Dim ds As New DsInformes
        ds.Clear()
        Dim row As DataRow

        row = ds.Tables("Detalle").NewRow()
        row.Item("Fecha1") = FechaFactTextBox.Text
        row.Item("Campo2") = ProvFactComboBox.Text
        row.Item("Campo3") = RUC
        row.Item("Campo4") = direccion
        row.Item("Campo5") = tbxDescripcion.Text
        row.Item("Numero1") = tbxTotalSinIva.Text
        row.Item("Numero2") = tbxTotalIva.Text
        row.Item("Numero3") = tbxTotalTransaccion.Text
        row.Item("Numero4") = lblTotalRetencion.Text

        If ImprimeRenta = 1 Then
            row.Item("Campo6") = lblPorcRetRENTA.Text
        Else
            row.Item("Campo6") = lblPorcRetIVA.Text
        End If
        row.Item("Campo7") = Funciones.Cadenas.NumeroaLetras(FormatNumber(lblTotalRetencion.Text, 0))

        Dim objCommand As New SqlCommand

        If Config5 = "Si" Then
            Dim NRORETENCION, NRODIGITOS As Double
            Dim CodigoMaq As Integer

            If Dashboard.Cmb_Maquina.SelectedValue = Nothing Then
                CodigoMaq = CodigoMaquina
            Else
                CodigoMaq = Dashboard.Cmb_Maquina.SelectedValue
            End If

            Try
                objCommand.CommandText = "SELECT dbo.DETPC.TIMBRADO, dbo.DETPC.FECHAVALIDEZ, dbo.DETPC.NRODIGITOS, dbo.EMPRESA.RUCCONTRIBUYENTE, dbo.DETPC.ULTIMO " & _
                                         "FROM   dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE INNER JOIN  " & _
                                         "dbo.EMPRESA ON dbo.DETPC.CODEMPRESA = dbo.EMPRESA.CODEMPRESA " & _
                                         "WHERE (dbo.DETPC.ACTIVO = 1) AND (dbo.DETPC.IP = " & CodigoMaq & ") AND (dbo.TIPOCOMPROBANTE.RETENCION = '1')"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        row.Item("Campo8") = odrConfig("TIMBRADO")
                        row.Item("Campo9") = odrConfig("RUCCONTRIBUYENTE")
                        row.Item("Fecha2") = odrConfig("FECHAVALIDEZ")
                        NroRetencion = odrConfig("ULTIMO")
                        NroDigitos = odrConfig("NRODIGITOS")
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try

            row.Item("Campo16") = "Timbrado :"
            row.Item("Campo17") = "Fecha Validez :"
            row.Item("Campo18") = "R.U.C :"

            NRORETENCION = NRORETENCION + 1
            Dim NroRangoString As String = NRORETENCION

            For n = 1 To NRODIGITOS
                If Len(NroRangoString) = NRODIGITOS Then
                    Exit For
                Else
                    NroRangoString = "0" & NroRangoString
                End If
            Next
            row.Item("Campo10") = NroRangoString

        End If

        ds.Tables("Detalle").Rows.Add(row)

        Return ds
    End Function

    Private Sub tbxTotalIva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxTotalIva.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxTotalTransaccion.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub FechaFactTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles FechaFactTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            IvaIncluidoComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxDescripcion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxDescripcion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxTotalSinIva.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxTotalSinIva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxTotalSinIva.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxTotalIva.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxTotalIva_LostFocus(sender As Object, e As System.EventArgs) Handles tbxTotalIva.LostFocus
        Dim CalcRet As Double
        Dim MontoRetenido As Double = 0
        Dim TotalRetenido As Double = 0
        Dim NroFacturas As String = ""

        Try
            If IvaIncluidoComboBox.Text = "Iva" Then
                CalcRet = PorcRetencion / 100
                TotalRetenido = CDec(tbxTotalIva.Text) * CalcRet
                lblRetIVA.Text = FormatNumber(TotalRetenido, 0)
                lblRetRENTA.Text = 0
                lblTotalRetencion.Text = lblRetIVA.Text
            Else
                CalcRet = PorcRetencionRenta / 100
                TotalRetenido = CDec(tbxTotalTransaccion.Text) * CalcRet
                lblRetRENTA.Text = FormatNumber(TotalRetenido, 0)
                lblRetIVA.Text = 0
                lblTotalRetencion.Text = lblRetRENTA.Text
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IvaIncluidoComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles IvaIncluidoComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TipoCompComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub IvaIncluidoComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles IvaIncluidoComboBox.SelectedIndexChanged
        If IvaIncluidoComboBox.Text = "Renta" Then
            ImprimeRenta = 1
            If tbxTotalIva.Text <> "" Then
                tbxTotalIva_LostFocus(Nothing, Nothing)
            End If
        Else
            ImprimeRenta = 0
            If tbxTotalIva.Text <> "" Then
                tbxTotalIva_LostFocus(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub ProvFactComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ProvFactComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            FechaFactTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub TipoCompComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TipoCompComboBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxDescripcion.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxNroRetencion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroRetencion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProvFactComboBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub PbxProveedor_Click(sender As System.Object, e As System.EventArgs) Handles PbxProveedor.Click
        PROVEEDOR.Show()
    End Sub

    Private Sub ComprasSimpleGridView1_SelectionChanged(sender As Object, e As System.EventArgs) Handles ComprasSimpleGridView1.SelectionChanged
        If btnuevo = 0 Then
            If ComprasSimpleGridView1.RowCount <> 0 Then
                lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount

                Me.RETCOMPTIPOCOMPROBANTETableAdapter.Fill(Me.DsRetencionCompra.RETCOMPTIPOCOMPROBANTE)
                If lblTotalRetencion.Text <> "" Then
                    lblTotalRetencion.Text = FormatNumber(lblTotalRetencion.Text, 0)
                    If ComprasSimpleGridView1.CurrentRow.Cells("TIPORETENCIONDataGridViewTextBoxColumn").Value = 1 Then
                        IvaIncluidoComboBox.Text = "Iva"
                        lblRetIVA.Text = FormatNumber(lblTotalRetencion.Text, 0)
                        lblRetRENTA.Text = "0"
                    Else
                        IvaIncluidoComboBox.Text = "Renta"
                        lblRetIVA.Text = "0"
                        lblRetRENTA.Text = FormatNumber(lblTotalRetencion.Text, 0)
                    End If
                End If

                If ComprasSimpleGridView1.CurrentRow.Cells("ESTADO").Value = 1 Then
                    PictureBoxMotivoAnulacion.Enabled = True
                    PictureBoxMotivoAnulacion.Image = My.Resources.Anull
                    PictureBoxMotivoAnulacion.Cursor = Cursors.Hand

                    ImprimirRetRentaPictureBox.Enabled = True
                    ImprimirRetRentaPictureBox.Image = My.Resources.Print
                    ImprimirRetRentaPictureBox.Cursor = Cursors.Hand

                    LblEstado.Text = "Aprobado"
                    LblEstado.ForeColor = Color.Green
                ElseIf ComprasSimpleGridView1.CurrentRow.Cells("ESTADO").Value = 2 Then
                    PictureBoxMotivoAnulacion.Enabled = False
                    PictureBoxMotivoAnulacion.Image = My.Resources.AnullOff
                    PictureBoxMotivoAnulacion.Cursor = Cursors.Default

                    ImprimirRetRentaPictureBox.Enabled = False
                    ImprimirRetRentaPictureBox.Image = My.Resources.PrintOff
                    ImprimirRetRentaPictureBox.Cursor = Cursors.Default

                    LblEstado.Text = "Anulado"
                    LblEstado.ForeColor = Color.Maroon
                End If
            Else
                LblEstado.Text = ""
                LblEstado.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        Habilitamos()
        btnuevo = 1
        CancelarToolStripMenuItem.Enabled = True

        LblEstado.Text = "Para Impresión"
        LblEstado.ForeColor = Color.Black

        RETENCIONCOMPRABindingSource.AddNew()
        GenerarNroRetencion()

        TipoCompComboBox.SelectedIndex = 0
        IvaIncluidoComboBox.SelectedIndex = 0
        lblRetIVA.Text = "0" : lblRetRENTA.Text = "0"
        'Obtenemos el proximo Nro de la Retencion
        tbxNroRetencion.Focus()
    End Sub

    Private Sub GenerarNroRetencion()
        Dim sql As String
        Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString, NumRetencion As String
        Dim NroDigitos As Integer

        NroRetencion = f.FuncionConsultaString("DETPC.ULTIMO", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND (ACTIVO = 1) AND (RETENCION = 1) AND dbo.DETPC.IP", CodigoMaquina)

        If NroRetencion = 0 Or String.IsNullOrEmpty(NroRetencion) = True Then
            MessageBox.Show("Comprobante no tiene mas Rango, cierre esta ventana y cargue lo en (Dashboard >> Configuración >> 'Rangos de Comprobantes') o bien, cargue el Nro. Recibo Manualmente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Dim conexion As System.Data.SqlClient.SqlConnection
            conexion = ser.Abrir()

            Try
                NumSucursal = SucCodigo
                NumMaquina = NumMaquinaGlobal
                NroDigitos = f.FuncionConsultaDecimal("DETPC.NRODIGITOS", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND ACTIVO = 1 AND RETENCION", 1)

                sql = "SELECT dbo.DETPC.RANDOID, dbo.DETPC.CODSUCURSAL, dbo.DETPC.IP, dbo.DETPC.ULTIMO, dbo.DETPC.RANGO2, dbo.TIPOCOMPROBANTE.RETENCION FROM dbo.DETPC INNER JOIN " & _
                     "dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE WHERE (dbo.DETPC.ULTIMO < dbo.DETPC.RANGO2) AND (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.RETENCION = 1) " & _
                     "AND DETPC.IP = " & CodigoMaquina

                Dim dadetpc As New SqlDataAdapter(sql, conexion)
                Dim dtdetpc As New DataTable
                dadetpc.Fill(dtdetpc)
                Dim drdetpc As DataRow
                drdetpc = dtdetpc.Rows(0)

                'Validamos que haya rango para ese TipoComprobante
                NroRetencion = drdetpc("ULTIMO")
                NroRetencion = NroRetencion + 1

                RangoIDRetencion = drdetpc("RANDOID")
                NroRango2 = drdetpc("RANGO2")

                If CDec(NroRetencion) > CDec(NroRango2) Then
                    NumRetencion = ""
                    Exit Sub
                End If

                Dim codsuc As Integer = drdetpc("CODSUCURSAL")
                NumSucTimbrado = f.FuncionConsultaString("SUCURSALTIMBRADO", "SUCURSAL", "CODSUCURSAL", codsuc)

                Dim IPMAQ As Integer = drdetpc("IP")
                NumMaquina = f.FuncionConsultaString("NUMMAQUINA", "PC", "IP", IPMAQ)

                NroRangoString = CStr(NroRetencion)
                For i = 1 To NroDigitos
                    If Len(NroRangoString) = NroDigitos Then
                        Exit For
                    Else
                        NroRangoString = "0" & NroRangoString
                    End If
                Next

                NumRetencion = NumSucTimbrado & "." & NumMaquina & "." & NroRangoString
                Me.tbxNroRetencion.Text = NumRetencion

                If NumRetencion = "" Then
                    MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Catch ex As Exception
            Finally
                conexion.Close()
            End Try

        End If
    End Sub

    Private Sub LeerNroRetencion()
        Dim sql As String
        Dim NumSucursal, NumMaquina, NumSucTimbrado, NroRango2, NroRangoString, NumRetencion As String
        Dim NroDigitos As Integer

        NroRetencion = f.FuncionConsultaString("DETPC.ULTIMO", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND (ACTIVO = 1) AND (RETENCION = 1) AND dbo.DETPC.IP", CodigoMaquina)

        If NroRetencion = 0 Or String.IsNullOrEmpty(NroRetencion) = True Then
            MessageBox.Show("Comprobante no tiene mas Rango, cierre esta ventana y cargue lo en (Dashboard >> Configuración >> 'Rangos de Comprobantes') o bien, cargue el Nro. Recibo Manualmente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Dim conexion As System.Data.SqlClient.SqlConnection
            conexion = ser.Abrir()

            Try
                NumSucursal = SucCodigo
                NumMaquina = NumMaquinaGlobal
                NroDigitos = f.FuncionConsultaDecimal("DETPC.NRODIGITOS", "DETPC INNER JOIN TIPOCOMPROBANTE ON DETPC.CODCOMPROBANTE = TIPOCOMPROBANTE.CODCOMPROBANTE", "(ULTIMO < RANGO2) AND ACTIVO = 1 AND RETENCION", 1)

                sql = "SELECT dbo.DETPC.RANDOID, dbo.DETPC.CODSUCURSAL, dbo.DETPC.IP, dbo.DETPC.ULTIMO, dbo.DETPC.RANGO2, dbo.TIPOCOMPROBANTE.RETENCION FROM dbo.DETPC INNER JOIN " & _
                     "dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE WHERE (dbo.DETPC.ULTIMO < dbo.DETPC.RANGO2) AND (dbo.DETPC.ACTIVO = 1) AND (dbo.TIPOCOMPROBANTE.RETENCION = 1) " & _
                     "AND DETPC.IP = " & CodigoMaquina

                Dim dadetpc As New SqlDataAdapter(sql, conexion)
                Dim dtdetpc As New DataTable
                dadetpc.Fill(dtdetpc)
                Dim drdetpc As DataRow
                drdetpc = dtdetpc.Rows(0)

                'Validamos que haya rango para ese TipoComprobante
                NroRetencion = drdetpc("ULTIMO")
                NroRetencion = NroRetencion + 1

                RangoIDRetencion = drdetpc("RANDOID")
                NroRango2 = drdetpc("RANGO2")

                If CDec(NroRetencion) > CDec(NroRango2) Then
                    NumRetencion = ""
                    Exit Sub
                End If

                Dim codsuc As Integer = drdetpc("CODSUCURSAL")
                NumSucTimbrado = f.FuncionConsultaString("SUCURSALTIMBRADO", "SUCURSAL", "CODSUCURSAL", codsuc)

                Dim IPMAQ As Integer = drdetpc("IP")
                NumMaquina = f.FuncionConsultaString("NUMMAQUINA", "PC", "IP", IPMAQ)

                NroRangoString = CStr(NroRetencion)
                For i = 1 To NroDigitos
                    If Len(NroRangoString) = NroDigitos Then
                        Exit For
                    Else
                        NroRangoString = "0" & NroRangoString
                    End If
                Next

                NumRetencion = NumSucTimbrado & "." & NumMaquina & "." & NroRangoString
                Me.lblProximoNro.Text = "Próximo Nro de Retención  " & NumRetencion

                If NumRetencion = "" Then
                    MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Catch ex As Exception
            Finally
                conexion.Close()
            End Try

        End If
    End Sub

    Private Sub FechaFiltro()
        Try

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
            fechacompleta1 = fechacompleta1 + " 00:00:00.000"
            fechacompleta2 = fechacompleta2 + " 23:59:59.900"
            FechaFiltro1 = CDate(fechacompleta1)
            FechaFiltro2 = CDate(fechacompleta2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Try
            Me.RETCOMPTIPOCOMPROBANTETableAdapter.Fill(Me.DsRetencionCompra.RETCOMPTIPOCOMPROBANTE)
            Me.RETENCIONCOMPRATableAdapter.FillByFecha(Me.DsRetencionCompra.RETENCIONCOMPRA, FechaFiltro1, FechaFiltro2)
        Catch ex As Exception
        End Try

        LeerNroRetencion()
        PintarCeldas()
        lblDGVCant.Text = "Cant. de Items:" & ComprasSimpleGridView1.RowCount
    End Sub

    Private Sub tsNuevaRetencion_Click(sender As System.Object, e As System.EventArgs) Handles tsNuevaRetencion.Click
        NuevoPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsReImprimirAutoF_Click(sender As System.Object, e As System.EventArgs) Handles tsReImprimirAutoF.Click
        ImprimirRetPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Deshabilitamos()
        CancelarToolStripMenuItem.Enabled = False
        RETENCIONCOMPRABindingSource.CancelEdit()
        lblRetIVA.Text = "0" : lblRetRENTA.Text = "0"
        PintarCeldas()
        btnuevo = 0
    End Sub

    Private Sub CancelarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CancelarToolStripMenuItem.Click
        CancelarPictureBox_Click(Nothing, Nothing)
    End Sub

    Private Sub tsQuemarProximo_Click(sender As System.Object, e As System.EventArgs) Handles tsQuemarProximo.Click
        'Calculamos el proximo Nro de retencion
        GenerarNroRetencion()

        'Quemamos el proximo nro
        Try
            ser.Abrir(sqlc)
            conexion = ser.Abrir()
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            Try
                QuemarNro(myTrans)
                ActualizarRetencion(myTrans)

                myTrans.Commit()

                MessageBox.Show("Operación Finalizada con éxito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try

                Throw ex
            End Try

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try

        BtnFiltro_Click(Nothing, Nothing)
    End Sub

    Private Sub QuemarNro(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String

        sql = "UPDATE DETPC SET ULTIMO = ULTIMO + 1 WHERE RANDOID=" & RangoIDRetencion & ""

        Consultas.ConsultaComando(myTrans, sql)
    End Sub

    Private Sub ActualizarRetencion(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String

        sql = "INSERT INTO RETENCIONCOMPRA (NUMRETENCION,FECHARETENCION,CODUSUARIO,CODRANGO,ESTADO) " & _
               "VALUES('" & Me.tbxNroRetencion.Text & "', GETDATE()," & UsuCodigo & "," & RangoIDRetencion & ",2)"

        Consultas.ConsultaComando(myTrans, sql)
    End Sub

    Private Sub tsVentanaDePagos_Click(sender As System.Object, e As System.EventArgs) Handles tsVentanaDePagos.Click
        PagosV2.Show()
    End Sub

    Private Sub PictureBoxMotivoAnulacion_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxMotivoAnulacion.Click
        'Cuando anulamos una retencion debemos Eliminar dicha retencion de COMPRASFORMASPAGO y MOVIMIENTOS y debolver el saldo a la factura afectada
        vgCodPago = f.FuncionConsultaDecimal("CODPAGO", "COMPRASFORMAPAGO", "CODTIPOPAGO = 6 AND NUMRETENCION ", Me.tbxNroRetencion.Text)

        Try
            ser.Abrir(sqlc)
            conexion = ser.Abrir()
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            Try
                '1ro regresamos el monto de las retenciones a las facturas.
                RegresarSaldos(myTrans)

                '2do Eliminamos de COMPRASFORMASPAGO y MOVIMIENTOS
                EliminarCompraFormaPago(myTrans)
                EliminarMovimiento(myTrans)

                '3ro cambiamos el estado a 2 en RetencionesCompras (Anulado)
                AnularRetencionesCompras(myTrans)

                myTrans.Commit()

                MessageBox.Show("Operación Finalizada con éxito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try

                Throw ex
            End Try

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try

        BtnFiltro_Click(Nothing, Nothing)
    End Sub

    Private Sub RegresarSaldos(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim objCommand As New SqlCommand
        Dim sql As System.String
        Dim Importe, CodCompra, CuotaNro As Integer

        sql = "" : Importe = 0 : CodCompra = 0 : CuotaNro = 0

        Try
            objCommand.CommandText = "SELECT CODTIPOPAGO, IMPORTE, NUMRETENCION, CODPAGO, CODCOMPRA, NROCUOTA " & _
                                     "FROM dbo.COMPRASFORMAPAGO " & _
                                     "WHERE (CODTIPOPAGO = 6) AND NUMRETENCION = '" & tbxNroRetencion.Text & "'"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    vgCodPago = odrConfig("CODPAGO")
                    Importe = odrConfig("IMPORTE")
                    CodCompra = odrConfig("CODCOMPRA")
                    CuotaNro = odrConfig("NROCUOTA")

                    sql = sql + "UPDATE FACTURAPAGAR SET SALDOCUOTA = SALDOCUOTA + " & Importe & ", PAGADO = 0  WHERE CODCOMPRA = " & CodCompra
                Loop
            End If

            Consultas.ConsultaComando(myTrans, sql)
            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EliminarMovimiento(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String

        sql = "DELETE movimientos WHERE id_pago = " & vgCodPago

        Consultas.ConsultaComando(myTrans, sql)
    End Sub

    Private Sub EliminarCompraFormaPago(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String

        sql = "DELETE COMPRASFORMAPAGO WHERE CODPAGO = " & vgCodPago

        Consultas.ConsultaComando(myTrans, sql)
    End Sub

    Private Sub AnularRetencionesCompras(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String

        sql = "UPDATE RETENCIONCOMPRA SET ESTADO = 2 WHERE CODRETENCION = " & ComprasSimpleGridView1.CurrentRow.Cells("CODRETENCIONDataGridViewTextBoxColumn").Value

        Consultas.ConsultaComando(myTrans, sql)
    End Sub

    Private Sub tsModificarNroRetencion_Click(sender As System.Object, e As System.EventArgs) Handles tsModificarNroRetencion.Click
        'Cuando se modifica el Nro de retenciones en dicha ventana debemos tambien hacer el cambio en COMPRASFORMASPAGO
        nvoNumeroRetencion = InputBox("Ingrese el nuevo Nro. de Retencion: ", " Modificar Nro. Retencion", Me.tbxNroRetencion.Text)
        vgCodPago = f.FuncionConsultaDecimal("CABPAGO", "COMPRASFORMAPAGO", "CODTIPOPAGO = 6 AND NUMRETENCION ", Me.tbxNroRetencion.Text)

        Try
            ser.Abrir(sqlc)
            conexion = ser.Abrir()
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            Try
                CompraFormaPago(myTrans)
                RetencionesCompras(myTrans)

                myTrans.Commit()

                MessageBox.Show("Operación Finalizada con éxito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try

                Throw ex
            End Try

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try

        BtnFiltro_Click(Nothing, Nothing)
    End Sub

    Private Sub RetencionesCompras(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String

        sql = "UPDATE RETENCIONCOMPRA SET NUMRETENCION = '" & nvoNumeroRetencion & "'  WHERE CODRETENCION = " & ComprasSimpleGridView1.CurrentRow.Cells("CODRETENCIONDataGridViewTextBoxColumn").Value

        Consultas.ConsultaComando(myTrans, sql)
    End Sub

    Private Sub CompraFormaPago(ByVal myTrans As System.Data.Common.DbTransaction)
        Dim sql As System.String

        sql = "UPDATE COMPRASFORMAPAGO SET NUMRETENCION = '" & nvoNumeroRetencion & "'  WHERE  (CABPAGO = " & vgCodPago & ")"

        Consultas.ConsultaComando(myTrans, sql)
    End Sub

    Private Sub tbxNroRetencion_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxNroRetencion.TextChanged

    End Sub
End Class
