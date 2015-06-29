Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad

Public Class LibrocompraV2

#Region "Fields"
    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction
    Private consulta As System.String
    Private conexion As System.Data.SqlClient.SqlConnection
    Dim permiso As Double
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim f As New Funciones.Funciones
    Dim Linea, CodTemp, TempModulo As Integer
    Dim AccEditar As Integer
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

#Region "Methods"

    Private Sub LibrocompraV2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            btnAsentar_Click(Nothing, Nothing)
        End If

        If e.KeyCode = Keys.F10 Then
            lblVerModulo_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Libros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        permiso = PermisoAplicado(UsuCodigo, 198)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        CmbAño.SelectedText = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1
        FechaFiltro()

        AccEditar = 0

        Try
            Me.PARAASENTARCAB_COMPRASTableAdapter.FillBy(Me.DsPlantillasConta.PARAASENTARCAB_COMPRAS, 3, 4, 11, FechaFiltro1, FechaFiltro2)
        Catch ex As Exception
        End Try

        Me.TIPOCOMPROBANTETableAdapter.Fill(Me.DsPlantillasConta.TIPOCOMPROBANTE)

        If dgvParaAsentar.RowCount = 0 Then
            btnAsentar.Image = My.Resources.ApproveOff : btnAsentar.Enabled = False
            ModificarPictureBox.Image = My.Resources.EditOff : ModificarPictureBox.Enabled = False
        Else
            btnAsentar.Image = My.Resources.Approve : btnAsentar.Enabled = True
            ModificarPictureBox.Image = My.Resources.Edit : ModificarPictureBox.Enabled = True
        End If
        '*************************************************
        'Dim c As Integer = dgvParaAsentar.RowCount
        'For c = 0 To c
        '    If dgvParaAsentar.CurrentRow.Cells("RangoID").Value = 
        'Next
        'Dim codcomreg As Integer = CInt(dgvParaAsentar.CurrentRow.Cells("RegistroID").Value)
        'If tipofactura = "CONTADO" Then
        '    asentvalor = "Factura de Compra Contado / " & w.FuncionConsultaString("PROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", ComprasSimpleGridView.CurrentRow.Cells("DataGridViewTextBoxColumn1").Value)

        'Else
        '    asentvalor = "Factura de Compra Credito / " & w.FuncionConsultaString("PROVEEDOR", "PROVEEDOR", "NUMPROVEEDOR", ComprasSimpleGridView.CurrentRow.Cells("DataGridViewTextBoxColumn1").Value)
        'End If
        'consulta = consulta + " UPDATE PARAASENTAR SET DETALLE = '" & asentvalor & "' WHERE REGISTROID= " & codcomreg
        '*************************************************

        DesHabilitar()
        RecorreDetalle()
    End Sub

    Private Sub InsertaAuditoria(ByVal Insertar As Integer, ByVal Modificar As Integer, ByVal Eliminar As Integer)
        Dim consulta, Accion As String
        Dim CODIGO As Integer = f.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        Accion = ""

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        If Insertar = 1 Then
            Accion = "INSERTO"
        ElseIf Modificar = 1 Then
            Accion = "MODIFICO"
        ElseIf Eliminar = 1 Then
            Accion = "ELIMINO"
        End If

        consulta = "INSERT INTO AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO,DESCRIPCION, FECHA, USUARIO,  INSERTAR, MODIFICAR, ELIMINAR)" & _
        "VALUES ( " & CODIGO & ", " & EmpCodigo & "," & "'LIBRO COMPRA', '" & dgbParaAsentarDetalle.CurrentRow.Cells("AsientoID").Value & "', " & "'" & Accion & " EN LA TABLA LIBRO COMPRA' , " & _
        "CONVERT(DATETIME,  getdate()), " & "'" & UsuDescripcion & "'," & Insertar & "," & Modificar & ", " & Eliminar & " )"

        cmd.CommandText = consulta
        cmd.ExecuteNonQuery()

        myTrans.Commit()

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

    Public Sub Habilitar()
        tbxTimbrado.Enabled = True
        tbxCotizacion.Enabled = True
        tbxFecha.Enabled = True
        cbxTipoPago.Enabled = True
        tbxDetalleAsiento.Enabled = True
        txtFechaCuenta.Enabled = True

        'Detalle
        btnAgregar.Enabled = True
        btnEliminar.Enabled = True
        tbxNroCuenta.Enabled = True
        cbxDebeHaber.Enabled = True
        tbxDebe.Enabled = True
        tbxHaber.Enabled = True

        'Botones
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand

        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        GuardarPictureBox.Cursor = Cursors.Hand

        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Image = My.Resources.DeleteOff
        EliminarPictureBox.Cursor = Cursors.Arrow

        'Grilla
        dgvParaAsentar.Enabled = False
        BuscarTextBox.Enabled = False
    End Sub

    Public Sub DesHabilitar()
        tbxTimbrado.Enabled = False
        tbxComprobante.Enabled = False
        tbxTipoComprobante.Enabled = False
        tbxCotizacion.Enabled = False
        tbxFecha.Enabled = False
        cbxTipoPago.Enabled = False
        tbxDetalleAsiento.Enabled = False
        txtFechaCuenta.Enabled = False

        'Detalle
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        tbxNroCuenta.Enabled = False
        cbxDebeHaber.Enabled = False
        tbxDebe.Enabled = False
        tbxHaber.Enabled = False

        'Botones
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow

        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Cursor = Cursors.Hand

        'Grilla
        dgvParaAsentar.Enabled = True
        BuscarTextBox.Enabled = True
    End Sub

    Private Sub dgvParaAsentar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvParaAsentar.SelectionChanged
        If dgvParaAsentar.RowCount <> 0 Then
            If IsDBNull(dgvParaAsentar.CurrentRow.Cells("RegistroID").Value) Then
            Else
                MostrarEncabezado()
                Me.PARAASENTARDETTableAdapter.Fill(Me.DsPlantillasConta.PARAASENTARDET, dgvParaAsentar.CurrentRow.Cells("ModuloID").Value, dgvParaAsentar.CurrentRow.Cells("RegistroID").Value)
                RecorreDetalle()
            End If
        Else
            Me.PARAASENTARDETTableAdapter.Fill(Me.DsPlantillasConta.PARAASENTARDET, 0, 0)
        End If

    End Sub

    Sub MostrarEncabezado()
        Dim odrDatos As SqlDataReader
        Dim objCommand As New SqlCommand
        Dim TipoFactura As Integer

        conexion = ser.Abrir()

        If dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 3 Then  '----- COMPRAS - REALICE UN CALCULO DE IVA 10 Y 5 EN BASE AL GRAVADA 10 Y 5 (SAUL)

            objCommand.CommandText = "SELECT dbo.PROVEEDOR.NOMBRE AS PROVEEDOR, dbo.PROVEEDOR.RUC_CIN AS RUC, dbo.COMPRAS.NUMCOMPRA AS NUMFACTURA, MODALIDADPAGO, " & _
                                      "ROUND(dbo.COMPRAS.TOTALCOMPRA, 0) AS TOTALFACTURA, ROUND(dbo.COMPRAS.TOTALIVA5, 0) AS TOTAL5, ROUND(dbo.COMPRAS.TOTALIVA10, 0) AS TOTAL10, ROUND(dbo.COMPRAS.TOTALIVA5 * 21, 0) AS TOTALGRAVADO5, " & _
                                      "ROUND(dbo.COMPRAS.TOTALIVA10 * 11, 0) AS TOTALGRAVADO10, ROUND(dbo.COMPRAS.TOTALIVA, 0) AS TOTALIVA, ROUND(dbo.COMPRAS.TOTALEXENTA, 0) AS TOTALEXCENTA, dbo.COMPRAS.CODCOMPROBANTE " & _
                                      "FROM dbo.PROVEEDOR INNER JOIN dbo.COMPRAS ON dbo.PROVEEDOR.CODPROVEEDOR = dbo.COMPRAS.CODPROVEEDOR " & _
                                      "WHERE(dbo.COMPRAS.CODCOMPRA = " & dgvParaAsentar.CurrentRow.Cells("RegistroID").Value & ")"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            odrDatos = objCommand.ExecuteReader()

            If odrDatos.HasRows Then
                Do While odrDatos.Read()
                    If IsDBNull(odrDatos("PROVEEDOR")) Then
                        tbxEmpresa.Text = ""
                    Else
                        tbxEmpresa.Text = odrDatos("PROVEEDOR")
                    End If

                    If IsDBNull(odrDatos("RUC")) Then
                        tbxRUC.Text = ""
                    Else
                        tbxRUC.Text = odrDatos("RUC")
                    End If

                    If IsDBNull(odrDatos("NUMFACTURA")) Then
                        tbxComprobante.Text = ""
                    Else
                        tbxComprobante.Text = odrDatos("NUMFACTURA")
                    End If

                    If IsDBNull(odrDatos("TOTALEXCENTA")) Then
                        tbxExcentas.Text = ""
                    Else
                        tbxExcentas.Text = FormatNumber(odrDatos("TOTALEXCENTA"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALGRAVADO5")) Then
                        tbxGrabIva5.Text = ""
                    Else
                        tbxGrabIva5.Text = FormatNumber(odrDatos("TOTALGRAVADO5"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALGRAVADO10")) Then
                        tbxGrabIva10.Text = ""
                    Else
                        tbxGrabIva10.Text = FormatNumber(odrDatos("TOTALGRAVADO10"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALFACTURA")) Then
                        tbxTotalFactura.Text = ""
                    Else
                        tbxTotalFactura.Text = FormatNumber(odrDatos("TOTALFACTURA"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTAL5")) Then
                        tbxIva5.Text = ""
                    Else
                        tbxIva5.Text = FormatNumber(odrDatos("TOTAL5"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTAL10")) Then
                        tbxIva10.Text = ""
                    Else
                        tbxIva10.Text = FormatNumber(odrDatos("TOTAL10"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALIVA")) Then
                        tbxTotalIva.Text = ""
                    Else
                        tbxTotalIva.Text = FormatNumber(odrDatos("TOTALIVA"), 0)
                    End If
                    If Not IsDBNull(dgvParaAsentar.CurrentRow.Cells("CODMONEDA").Value) Then
                        tbxMoneda.Text = f.FuncionConsultaString("DESMONEDA", "MONEDA", "CODMONEDA", dgvParaAsentar.CurrentRow.Cells("CODMONEDA").Value)
                    Else
                        tbxMoneda.Text = f.FuncionConsultaString("DESMONEDA", "MONEDA", "PRIORIDAD", 1) 'forzamos el guarani..(contabilidad)
                    End If

                    If odrDatos("MODALIDADPAGO") = 1 Then
                        cbxTipoPago.Text = "Crédito"
                    ElseIf TipoFactura = 0 Then
                        cbxTipoPago.Text = "Contado"
                    End If
                Loop
            End If

        ElseIf dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 11 Then '----- DEVOLUCIONES DE VENTAS

            objCommand.CommandText = "SELECT dbo.CLIENTES.NOMBRE AS CLIENTE, dbo.CLIENTES.RUC, dbo.DEVOLUCION.NUMDEVOLUCION AS NUMDEVOLUCION, dbo.VENTAS.TIPOVENTA,  " & _
                                      " dbo.DEVOLUCION.TOTALDEVOLUCION AS TOTALDEVOLUCION, ROUND(dbo.DEVOLUCION.TOTALIVA5 * 21,0) AS TOTALGRAVADO5, " & _
                                      "ROUND(dbo.DEVOLUCION.TOTALIVA10 * 11,0) AS TOTALGRAVADO10, dbo.DEVOLUCION.TOTALIVA, dbo.DEVOLUCION.TOTALEXENTA, dbo.DEVOLUCION.CODCOMPROBANTE,dbo.DEVOLUCION.TOTALIVA5, dbo.DEVOLUCION.TOTALIVA10 " & _
                                      "FROM dbo.DEVOLUCION LEFT OUTER JOIN " & _
                                      "dbo.CLIENTES ON dbo.DEVOLUCION.CODCLIENTE = dbo.CLIENTES.CODCLIENTE LEFT OUTER JOIN dbo.VENTAS ON dbo.CLIENTES.CODCLIENTE = dbo.VENTAS.CODCLIENTE " & _
                                      "WHERE(dbo.DEVOLUCION.CODDEVOLUCION = " & dgvParaAsentar.CurrentRow.Cells("RegistroID").Value & ")"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            odrDatos = objCommand.ExecuteReader()

            If odrDatos.HasRows Then
                Do While odrDatos.Read()
                    If IsDBNull(odrDatos("CLIENTE")) Then
                        tbxEmpresa.Text = ""
                    Else
                        tbxEmpresa.Text = odrDatos("CLIENTE")
                    End If

                    If IsDBNull(odrDatos("RUC")) Then
                        tbxRUC.Text = ""
                    Else
                        tbxRUC.Text = odrDatos("RUC")
                    End If

                    If IsDBNull(odrDatos("NUMDEVOLUCION")) Then
                        tbxComprobante.Text = ""
                    Else
                        tbxComprobante.Text = odrDatos("NUMDEVOLUCION")
                    End If

                    If IsDBNull(odrDatos("TOTALEXENTA")) Then
                        tbxExcentas.Text = ""
                    Else
                        tbxExcentas.Text = FormatNumber(odrDatos("TOTALEXENTA"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALGRAVADO5")) Then
                        tbxGrabIva5.Text = ""
                    Else
                        tbxGrabIva5.Text = FormatNumber(odrDatos("TOTALGRAVADO5"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALGRAVADO10")) Then
                        tbxGrabIva10.Text = ""
                    Else
                        tbxGrabIva10.Text = FormatNumber(odrDatos("TOTALGRAVADO10"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALDEVOLUCION")) Then
                        tbxTotalFactura.Text = ""
                    Else
                        tbxTotalFactura.Text = FormatNumber(odrDatos("TOTALDEVOLUCION"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALIVA5")) Then
                        tbxIva5.Text = ""
                    Else
                        tbxIva5.Text = FormatNumber(odrDatos("TOTALIVA5"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALIVA10")) Then
                        tbxIva10.Text = ""
                    Else
                        tbxIva10.Text = FormatNumber(odrDatos("TOTALIVA10"), 0)
                    End If

                    If IsDBNull(odrDatos("TOTALIVA")) Then
                        tbxTotalIva.Text = ""
                    Else
                        tbxTotalIva.Text = FormatNumber(odrDatos("TOTALIVA"), 0)
                    End If

                    If IsDBNull(dgvParaAsentar.CurrentRow.Cells("CODMONEDA").Value) Then
                        tbxMoneda.Text = ""
                    Else
                        tbxMoneda.Text = f.FuncionConsultaString("DESMONEDA", "MONEDA", "CODMONEDA", dgvParaAsentar.CurrentRow.Cells("CODMONEDA").Value)
                    End If
                    If IsDBNull(odrDatos("CODCOMPROBANTE")) Then
                        tbxTipoComprobante.SelectedIndex = -1
                    Else
                        tbxTipoComprobante.SelectedValue = odrDatos("CODCOMPROBANTE")
                    End If
                Loop
            End If

        Else '----- PAGOS

            objCommand.CommandText = "SELECT SUM(dbo.COMPRASFORMAPAGO.IMPORTE) AS IMPORTE, dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.TIPOPAGO, " & _
                                     "dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRASFORMAPAGO.FECHAPAGO, dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.RUC_CIN, " & _
                                     "dbo.COMPRASFORMAPAGO.DESTIPOPAGO " & _
                                     "FROM dbo.COMPRASFORMAPAGO INNER JOIN " & _
                                     "dbo.COMPRAS ON dbo.COMPRASFORMAPAGO.CODCOMPRA = dbo.COMPRAS.CODCOMPRA INNER JOIN " & _
                                     "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR " & _
                                     "GROUP BY dbo.COMPRASFORMAPAGO.NRORECIBO, dbo.COMPRASFORMAPAGO.TIPOPAGO, dbo.COMPRASFORMAPAGO.CABPAGO, dbo.COMPRASFORMAPAGO.FECHAPAGO, " & _
                                     "dbo.PROVEEDOR.NOMBRE, dbo.PROVEEDOR.RUC_CIN, dbo.COMPRASFORMAPAGO.DESTIPOPAGO " & _
                                     "HAVING (dbo.COMPRASFORMAPAGO.CABPAGO = " & dgvParaAsentar.CurrentRow.Cells("RegistroID").Value & ")"

            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            odrDatos = objCommand.ExecuteReader()

            If odrDatos.HasRows Then
                Do While odrDatos.Read()
                    If IsDBNull(odrDatos("NOMBRE")) Then
                        tbxEmpresa.Text = ""
                    Else
                        tbxEmpresa.Text = odrDatos("NOMBRE")
                    End If

                    If IsDBNull(odrDatos("RUC_CIN")) Then
                        tbxRUC.Text = ""
                    Else
                        tbxRUC.Text = odrDatos("RUC_CIN")
                    End If

                    If IsDBNull(odrDatos("NRORECIBO")) Then
                        tbxComprobante.Text = ""
                    Else
                        tbxComprobante.Text = odrDatos("NRORECIBO")
                    End If

                    If IsDBNull(odrDatos("IMPORTE")) Then
                        tbxTotalFactura.Text = ""
                    Else
                        tbxTotalFactura.Text = FormatNumber(odrDatos("IMPORTE"), 0)
                    End If

                    tbxExcentas.Text = "" : tbxGrabIva5.Text = "" : tbxGrabIva10.Text = "" : tbxIva5.Text = "" : tbxIva10.Text = ""

                    If Not IsDBNull(dgvParaAsentar.CurrentRow.Cells("CODMONEDA").Value) Then
                        tbxMoneda.Text = f.FuncionConsultaString("DESMONEDA", "MONEDA", "CODMONEDA", dgvParaAsentar.CurrentRow.Cells("CODMONEDA").Value)
                    Else
                        tbxMoneda.Text = f.FuncionConsultaString("DESMONEDA", "MONEDA", "PRIORIDAD", 1) 'forzamos el guarani..(contabilidad)
                    End If

                    If odrDatos("TIPOPAGO") = 2 Then
                        cbxTipoPago.Text = "Crédito"
                    ElseIf TipoFactura = 1 Then
                        cbxTipoPago.Text = "Contado"
                    End If
                Loop
            End If
        End If
    End Sub

    Private Sub RecorreDetalle()
        Dim TotalDebe, TotalHaber As Double

        TotalDebe = 0 : TotalHaber = 0
        If dgbParaAsentarDetalle.RowCount <> 0 Then
            For i = 0 To dgbParaAsentarDetalle.RowCount - 1
                TotalDebe = TotalDebe + dgbParaAsentarDetalle.Rows(i).Cells("IMPORTED1").Value
                TotalHaber = TotalHaber + dgbParaAsentarDetalle.Rows(i).Cells("IMPORTEH1").Value
            Next
        End If
        tbxTotalHaber.Text = Math.Round(TotalHaber, 0)
        tbxTotalDebe.Text = Math.Round(TotalDebe, 0)

        If Math.Round(TotalDebe, 0) <> Math.Round(TotalHaber, 0) Then
            tbxTotalHaber.ForeColor = Color.Maroon
            tbxTotalDebe.ForeColor = Color.Maroon
        Else
            tbxTotalHaber.ForeColor = Color.Black
            tbxTotalDebe.ForeColor = Color.Black
        End If
    End Sub

    Private Sub lblVerModulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVerModulo.Click
        'Verificamos a que modulo corresponde
        If IsDBNull(dgvParaAsentar.CurrentRow.Cells("ModuloID").Value) Then
        Else
            If dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 3 Then 'Compras
                CompraPlus.BuscarCompraTextBox.Text = tbxComprobante.Text
                CompraPlus.Show()
                CompraPlus.COMPRASTableAdapter.Fill(CompraPlus.DsPagos.COMPRAS, "%", "01/01/1900", "01/01/2020")

            ElseIf dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 4 Then 'Pagos
                PagosV2.BuscarTextBox.Text = tbxComprobante.Text
                PagosV2.Show()
                PagosV2.PanelFiltradoTipoCobro.BringToFront()
                PagosV2.FechaDesde3.Text = tbxFecha.Text
                PagosV2.FechaHasta3.Text = tbxFecha.Text
                PagosV2.btnFiltrarCuentas_Click(Nothing, Nothing)

            ElseIf dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 11 Then 'Devoluciones
                Devoluciones.BuscarDevolucionTextBox.Text = tbxComprobante.Text
                Devoluciones.Show()
                Devoluciones.DEVOLUCIONTableAdapter.Fill(Devoluciones.DsDevoluciones.DEVOLUCION, "01/01/1900", "01/01/2020")
            End If
        End If
    End Sub

    Private Sub btnCalculadora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculadora.Click
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "calc.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Private Sub BuscarTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.GotFocus
        If BuscarTextBox.Text = "Buscar..." Then
            BuscarTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.LostFocus
        If BuscarTextBox.Text = "" Then
            BuscarTextBox.Text = "Buscar..."
        End If
    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged
        If BuscarTextBox.Text <> "Buscar..." Then
            Me.PARAASENTARCABCOMPRASBindingSource.Filter = "DETALLE LIKE '%" & BuscarTextBox.Text & "%' OR NUMCOMPROBANTE LIKE '%" & BuscarTextBox.Text & "%'"
        End If
    End Sub

    Private Sub btnAsentar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsentar.Click
        Dim ModuloID, RegistroId, Tipofactura, asentvalor As String
        Dim NroAsiento, TipoPago As Integer
        Tipofactura = ""

        If dgvParaAsentar.RowCount <> 0 Then

            If tbxTotalHaber.Text <> tbxTotalDebe.Text Then
                If MessageBox.Show("El Debe y Haber no estan Balanceados ¿Esta seguro que desea guardarlo?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else

                If MessageBox.Show("¿Desea Asentar estos Datos?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            If cbxTipoPago.Text = "Contado" Then
                TipoPago = 1
                Tipofactura = cbxTipoPago.Text
            ElseIf cbxTipoPago.Text = "Crédito" Then
                TipoPago = 2
                Tipofactura = cbxTipoPago.Text
            End If

            '1ro - Copiar datos en la Tabla ASIENTOS
            ModuloID = dgvParaAsentar.CurrentRow.Cells("ModuloID").Value

            RegistroId = dgvParaAsentar.CurrentRow.Cells("RegistroID").Value

            CodPeriodoActual = f.FuncionConsultaDecimal("CODPERIODOFISCAL", "periodofiscal", "ESTADO", "1")

            Dim anoperiodo As Integer = f.FuncionConsultaDecimal("year(FECHAINICIO)", "periodofiscal", "ESTADO", "1")

            Dim asientoanterior As Integer = f.FuncionConsultaStringMAX("max(AsientoID)", "ASIENTOS")

            Dim anoanterior As Integer = f.FuncionConsulta("year(FECHAASIENTO)", "ASIENTOS", "AsientoID", asientoanterior)

            NroAsiento = f.Maximo_con_Where("NUMASIENTO", "ASIENTOS", " CODPERIODOFISCAL =" & CodPeriodoActual)
            If anoperiodo = anoanterior Then
                NroAsiento = NroAsiento + 1
            End If

            If anoperiodo <> anoanterior Then
                NroAsiento = 1
            End If



            conexion = ser.Abrir()
            cmd.CommandText = "SELECT ModuloID, RegistroID, CODMONEDA, FECHAASIENTO, COTIZACION, CODPERIODOFISCAL, " & _
                              "CODPLANCUENTA, DESCRIPCION, IMPORTED, IMPORTEH, NUMCOMPROBANTE, DETALLE, TIMBRADO, TIPOPAGO, CODSUCURSAL  " & _
                              "FROM dbo.PARAASENTAR WHERE (ModuloID = " & ModuloID & ") AND (RegistroID = " & RegistroId & ")"

            cmd.Connection = New SqlConnection(ser.CadenaConexion)
            cmd.Connection.Open()

            Dim odrAsientos As SqlDataReader = cmd.ExecuteReader()
            Dim Fecha As Date
            Dim fechaFormateada As String
            Dim codmoneda, codsucursal As Integer

            If odrAsientos.HasRows Then
                Do While odrAsientos.Read()
                    Fecha = odrAsientos("FECHAASIENTO")
                    fechaFormateada = Fecha.ToString("dd/MM/yyyy")

                    If IsDBNull(odrAsientos("CODMONEDA")) Then
                        codmoneda = 1
                    Else
                        codmoneda = odrAsientos("CODMONEDA")
                    End If

                    If IsDBNull(odrAsientos("CODSUCURSAL")) Then
                        codsucursal = 1
                    Else
                        codsucursal = odrAsientos("CODSUCURSAL")
                    End If

                    'odrAsientos("TIPOPAGO")
                    Try
                        consulta = "INSERT INTO ASIENTOS (ModuloID,RegistroID,CODMONEDA,FECHAASIENTO,COTIZACION, " & _
                                    "CODPERIODOFISCAL,CODPLANCUENTA,DESCRIPCION,IMPORTED,IMPORTEH,DETALLE,TIMBRADO,NUMASIENTO,NUMCOMPROBANTE,TIPOPAGO,CODSUCURSAL)  VALUES   " & _
                                    "(" & odrAsientos("ModuloID") & "," & odrAsientos("RegistroID") & ", " & codmoneda & ", " & _
                                    "CONVERT(DATETIME,'" & fechaFormateada & "',103) , " & Replace(odrAsientos("COTIZACION"), ",", ".") & _
                                    ", " & CodPeriodoActual & ", " & odrAsientos("CODPLANCUENTA") & ", '" & odrAsientos("DESCRIPCION") & "', " & _
                                    Replace(odrAsientos("IMPORTED"), ",", ".") & ", " & Replace(odrAsientos("IMPORTEH"), ",", ".") & ", '" & odrAsientos("DETALLE") & _
                                    "', '" & odrAsientos("TIMBRADO") & "'," & NroAsiento & ", '" & odrAsientos("NUMCOMPROBANTE") & "'," & odrAsientos("TIPOPAGO") & "," & codsucursal & ")"

                        '*************************************************
                        Dim codcomreg As Integer = CInt(dgbParaAsentarDetalle.CurrentRow.Cells("REGISTROID1").Value)
                        If Tipofactura = "CONTADO" Then
                            asentvalor = dgvParaAsentar.CurrentRow.Cells("DETALLE").Value

                        Else
                            asentvalor = dgvParaAsentar.CurrentRow.Cells("DETALLE").Value

                        End If
                        consulta = consulta + "  UPDATE ASIENTOS SET DETALLE = '" & asentvalor & "' WHERE REGISTROID= " & codcomreg
                        '*************************************************

                        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                        Consultas.ConsultaComando(myTrans, consulta)
                        myTrans.Commit()

                    Catch ex As Exception
                        Try
                            myTrans.Rollback("Actualizar")
                        Catch

                        End Try
                        MessageBox.Show("Ocurrio un error al intentar Asentar", "POSEXPRESS")
                        Exit Sub
                    End Try
                Loop
            End If

            odrAsientos.Close()

            '2do - Actualizamos Tablas (VENTAS, COMPRAS, PAGO, COBROS) dependiendo del modulo seleccionado
            Try
                If dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 11 Then   'Ventas

                    consulta = "UPDATE DEVOLUCION SET ASENTADO = 2 WHERE CODDEVOLUCION = " & RegistroId & ""
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                ElseIf dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 3 Then   'Compras

                    consulta = "UPDATE COMPRAS SET ASENTADO = 2 WHERE CODCOMPRA = " & RegistroId & ""
                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                End If

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                MessageBox.Show("Ocurrio un error al intentar Asentar", "POSEXPRESS")
                Exit Sub
            End Try

            '3ro - Eliminamos los datos de la tabla PARAASENTAR
            Try
                consulta = "DELETE PARAASENTAR WHERE ModuloID = " & ModuloID & " AND RegistroID = " & RegistroId
                myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                MessageBox.Show("Ocurrio un error al intentar Asentar", "POSEXPRESS")
                Exit Sub
            End Try

            FechaFiltro()
            Dim reg As Integer = dgvParaAsentar.CurrentRow.Cells("RegistroID").Value
            Dim modu As Integer = dgvParaAsentar.CurrentRow.Cells("ModuloID").Value
            Try
                Me.PARAASENTARCAB_COMPRASTableAdapter.FillBy(Me.DsPlantillasConta.PARAASENTARCAB_COMPRAS, 3, 4, 11, FechaFiltro1, FechaFiltro2)
                Me.PARAASENTARDETTableAdapter.Fill(Me.DsPlantillasConta.PARAASENTARDET, modu, reg)
            Catch ex As Exception
            End Try

            BtnFiltro_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        Habilitar()
        AccEditar = 1
        btnAsentar.Enabled = False
        btnAsentar.Image = My.Resources.ApproveOff
        btnAsentar.Cursor = Cursors.Default

        txtFechaCuenta.Text = Today
        txtFechaCuenta.Focus()
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        DesHabilitar()
        AccEditar = 0
        btnAsentar.Enabled = True
        btnAsentar.Image = My.Resources.Approve
        btnAsentar.Cursor = Cursors.Hand
        If dgvParaAsentar.Rows.Count > 0 Then
            Me.PARAASENTARDETTableAdapter.Fill(Me.DsPlantillasConta.PARAASENTARDET, dgvParaAsentar.CurrentRow.Cells("ModuloID").Value, dgvParaAsentar.CurrentRow.Cells("RegistroID").Value)
        End If

        FechaFiltro()
        Me.PARAASENTARCAB_COMPRASTableAdapter.FillBy(Me.DsPlantillasConta.PARAASENTARCAB_COMPRAS, 3, 4, 11, FechaFiltro1, FechaFiltro2)

        btnAsentar.Enabled = True
        btnAsentar.Image = My.Resources.Approve
        btnAsentar.Cursor = Cursors.Arrow

        tbxNroCuenta.Text = "" : cbxDebeHaber.Text = "" : tbxDebe.Text = "" : tbxHaber.Text = "" : tbxCuenta.Text = ""
        RecorreDetalle()
        AccEditar = 0
    End Sub

    Private Sub tbxNroCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxNroCuenta.KeyPress, tbxCodCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxDebeHaber.Focus()
            KeyAscii = 0
        End If
        If KeyAscii = 42 Then
            Me.PlancuentasTableAdapter.FillByTodos(Me.DsPlantillasConta.plancuentas)
            UltraPopupControlContainer1.Show()
            tbxBuscarCuenta.Text = ""
            tbxBuscarCuenta.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub tbxBuscarCuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxBuscarCuenta.GotFocus
        If tbxBuscarCuenta.Text = "Buscar..." Then
            tbxBuscarCuenta.Text = ""
        End If
    End Sub

    Private Sub tbxBuscarCuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxBuscarCuenta.LostFocus
        If tbxBuscarCuenta.Text = "" Then
            tbxBuscarCuenta.Text = "Buscar..."
        End If
    End Sub

    Private Sub tbxBuscarCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxBuscarCuenta.TextChanged
        If tbxBuscarCuenta.Text <> "Buscar..." Then
            Me.PlancuentasBindingSource.Filter = "DESPLANCUENTA LIKE '%" & tbxBuscarCuenta.Text & "%' OR NUMPLANCUENTA LIKE '%" & tbxBuscarCuenta.Text & "%' "
        End If
    End Sub

    Private Sub cbxDebeHaber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxDebeHaber.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxDebe.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxDebe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxDebe.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxHaber.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxHaber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxHaber.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregar.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        '1 - Controlamos que se hallan cargado todos los datos necesarios
        If tbxNroCuenta.Text = "" Or tbxCuenta.Text = "" Then
            MessageBox.Show("Introduzca un Plan de Cuentas", "POSEXPRESS")
            tbxNroCuenta.Focus()
            Exit Sub
        End If

        If cbxDebeHaber.Text = "" Then
            MessageBox.Show("Indique si es Debe/Haber", "POSEXPRESS")
            cbxDebeHaber.Focus()
            Exit Sub
        End If

        If (tbxDebe.Text = "") And (tbxDebe.Text = "0") Then
            MessageBox.Show("Indique el monto del Debe", "POSEXPRESS")
            cbxDebeHaber.Focus()
            Exit Sub
        End If

        If (tbxHaber.Text = "") And (tbxHaber.Text = "0") Then
            MessageBox.Show("Indique el monto del Haber", "POSEXPRESS")
            cbxDebeHaber.Focus()
            Exit Sub
        End If

        '2 - Validamos que no se repita el Plan de Cuentas
        Dim count As Integer = dgbParaAsentarDetalle.RowCount
        For i = 1 To count
            Try
                If IsDBNull(dgbParaAsentarDetalle.Rows(i - 1).Cells("NUMPLANCUENTA1").Value) Then
                Else
                    If tbxNroCuenta.Text = dgbParaAsentarDetalle.Rows(i - 1).Cells("NUMPLANCUENTA1").Value Then
                        MessageBox.Show("Ya se ingresó la cuenta!!", "POSEXPRESS")
                        tbxNroCuenta.Focus()
                        Exit Sub
                    End If
                End If
            Catch ex As Exception

            End Try
        Next

        '3 - Insertamos en la grilla
        Me.PARAASENTARDETBindingSource.AddNew()
        Dim CantReg As Integer = dgbParaAsentarDetalle.RowCount

        dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("AsientoID").Value = 0
        dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("MODULOID1").Value = dgvParaAsentar.CurrentRow.Cells("ModuloID").Value
        dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("REGISTROID1").Value = dgvParaAsentar.CurrentRow.Cells("RegistroID").Value
        dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("CODPLANCUENTADetalle").Value = tbxCodCuenta.Text
        dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("NUMPLANCUENTA1").Value = tbxNroCuenta.Text
        dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("DESCRIPCION1").Value = tbxCuenta.Text
        dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("FECHAASIENTO").Value = txtFechaCuenta.Text
        dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("EstadoGrilla").Value = "I"

        If cbxDebeHaber.Text = "Debe" Then
            dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("IMPORTED1").Value = CDbl(tbxDebe.Text)
            dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("IMPORTEH1").Value = 0
        ElseIf cbxDebeHaber.Text = "Haber" Then
            dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("IMPORTEH1").Value = CDbl(tbxHaber.Text)
            dgbParaAsentarDetalle.Rows(CantReg - 1).Cells("IMPORTED1").Value = 0
        End If

        tbxNroCuenta.Text = "" : cbxDebeHaber.Text = "" : tbxDebe.Text = "" : tbxHaber.Text = "" : tbxCuenta.Text = "" : txtFechaCuenta.Text = ""
        RecorreDetalle()
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim TipoPago As Integer

        If dgbParaAsentarDetalle.RowCount = 0 Then
            MessageBox.Show("Debe ingresar al menos un detalle", "POSEXPRESS")
            Exit Sub
        End If

        If CDec(tbxTotalHaber.Text) <> CDec(tbxTotalDebe.Text) Then
            If MessageBox.Show("El Debe y Haber no estan Balanceados ¿Esta seguro que desea guardarlo?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If cbxTipoPago.Text = "Contado" Then
            TipoPago = 1
        ElseIf cbxTipoPago.Text = "Crédito" Then
            TipoPago = 2
        End If

        For i = 0 To dgbParaAsentarDetalle.RowCount - 1
            txtFechaCuenta.Text = dgbParaAsentarDetalle.Rows(i).Cells("FECHAASIENTO").Value
            If dgbParaAsentarDetalle.Rows(i).Cells("AsientoID").Value <> 0 Then
                'Update
                Try
                    conexion = ser.Abrir()
                    consulta = "UPDATE PARAASENTAR SET FECHAASIENTO = CONVERT(DATETIME,'" & dgbParaAsentarDetalle.Rows(i).Cells("FECHAASIENTO").Value & "',103) , TIMBRADO = '" & tbxTimbrado.Text & "', IMPORTED = " & Replace(dgbParaAsentarDetalle.Rows(i).Cells("IMPORTED1").Value, ",", ".") & _
                                ", IMPORTEH = " & Replace(dgbParaAsentarDetalle.Rows(i).Cells("IMPORTEH1").Value, ",", ".") & ", DESCRIPCION = '" & dgbParaAsentarDetalle.Rows(i).Cells("DESCRIPCION1").Value & "'," & _
                                "CODPLANCUENTA = " & dgbParaAsentarDetalle.Rows(i).Cells("CODPLANCUENTADetalle").Value & ", COTIZACION = " & Replace(tbxCotizacion.Text, ",", ".") & ", " & _
                                "TIPOPAGO = " & TipoPago & ", DETALLE = '" & tbxDetalleAsiento.Text & "'   WHERE AsientoID = " & dgbParaAsentarDetalle.Rows(i).Cells("AsientoID").Value

                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                    'INSERTAMOS EN AUDITORIA 
                    InsertaAuditoria(0, 1, 0)
                    '#########################

                Catch ex As Exception
                End Try
            Else
                'Insert
                Try
                    Dim codmoneda As Integer
                    If IsDBNull(dgvParaAsentar.CurrentRow.Cells("CODMONEDA").Value) Then
                        codmoneda = 1
                    Else
                        codmoneda = dgvParaAsentar.CurrentRow.Cells("CODMONEDA").Value
                    End If

                    'debemos obtener la suscursal para agregar en la tabla PARAASENTAR
                    Dim vlCodsucursal As Integer = 0
                    If dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 3 Then   'COMPRAS
                        vlCodsucursal = f.FuncionConsultaDecimal("CODSUCURSAL", "COMPRAS", "CODCOMPRA", dgvParaAsentar.CurrentRow.Cells("RegistroID").Value)

                    ElseIf dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 11 Then  'DEVOLUCION DE VENTA
                        vlCodsucursal = f.FuncionConsultaDecimal("CODSUCURSAL", "DEVOLUCION", "CODDEVOLUCION", dgvParaAsentar.CurrentRow.Cells("RegistroID").Value)

                    ElseIf dgvParaAsentar.CurrentRow.Cells("ModuloID").Value = 4 Then  'PAGOS
                        Dim vCodCompra As Integer = f.FuncionConsultaDecimal("CODCOMPRA", "COMPRASFORMAPAGO", "CODPAGO", dgvParaAsentar.CurrentRow.Cells("RegistroID").Value)
                        vlCodsucursal = f.FuncionConsultaDecimal("CODSUCURSAL", "COMPRAS", "CODCOMPRA", vCodCompra)
                    End If

                    conexion = ser.Abrir()
                    consulta = "INSERT PARAASENTAR (ModuloID,RegistroID,CODMONEDA,COTIZACION,FECHAASIENTO,CODPERIODOFISCAL,CODPLANCUENTA,DESCRIPCION," & _
                                "IMPORTED,IMPORTEH,NUMCOMPROBANTE,DETALLE,TIMBRADO,TIPOPAGO,CODSUCURSAL) VALUES " & _
                                "(" & dgvParaAsentar.CurrentRow.Cells("ModuloID").Value & "," & dgvParaAsentar.CurrentRow.Cells("RegistroID").Value & "," & _
                                codmoneda & "," & Replace(tbxCotizacion.Text, ",", ".") & ", CONVERT(DATETIME,'" & dgbParaAsentarDetalle.Rows(i).Cells("FECHAASIENTO").Value & "',103)," & _
                                dgvParaAsentar.CurrentRow.Cells("CODPERIODOFISCAL").Value & "," & dgbParaAsentarDetalle.Rows(i).Cells("CODPLANCUENTADetalle").Value & _
                                ",'" & dgbParaAsentarDetalle.Rows(i).Cells("DESCRIPCION1").Value & "'," & Replace(dgbParaAsentarDetalle.Rows(i).Cells("IMPORTED1").Value, ",", ".") & "," & _
                                Replace(dgbParaAsentarDetalle.Rows(i).Cells("IMPORTEH1").Value, ",", ".") & ",'" & tbxComprobante.Text & "','" & _
                                dgvParaAsentar.CurrentRow.Cells("DETALLE").Value & "','" & tbxTimbrado.Text & "'," & TipoPago & "," & vlCodsucursal & ")"

                    myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                    Consultas.ConsultaComando(myTrans, consulta)
                    myTrans.Commit()

                    'INSERTAMOS EN AUDITORIA 
                    InsertaAuditoria(1, 0, 0)
                    '#########################

                Catch ex As Exception
                End Try
            End If
        Next

        'Actualizamos la Grilla
        DesHabilitar()

        btnAsentar.Enabled = True
        btnAsentar.Image = My.Resources.Approve
        btnAsentar.Cursor = Cursors.Arrow

        CodTemp = dgvParaAsentar.CurrentRow.Cells("RegistroID").Value
        TempModulo = dgvParaAsentar.CurrentRow.Cells("ModuloID").Value

        FechaFiltro()
        Try
            Me.PARAASENTARCAB_COMPRASTableAdapter.FillBy(Me.DsPlantillasConta.PARAASENTARCAB_COMPRAS, 3, 4, 11, FechaFiltro1, FechaFiltro2)
            'Dim dt As DataTable = Me.PARAASENTARCAB_COMPRASTableAdapter.GetDataBy(3, 4, 11, FechaFiltro1, FechaFiltro2)
        Catch ex As Exception
        End Try

        'Buscamos la posicion del registro guardado
        For i = 0 To dgvParaAsentar.RowCount - 1
            If dgvParaAsentar.Rows(i).Cells("RegistroID").Value = CodTemp And dgvParaAsentar.Rows(i).Cells("ModuloID").Value = TempModulo Then
                PARAASENTARCABCOMPRASBindingSource.Position = i
            End If
        Next

        Try
            Me.PARAASENTARDETTableAdapter.Fill(Me.DsPlantillasConta.PARAASENTARDET, dgvParaAsentar.CurrentRow.Cells("ModuloID").Value, dgvParaAsentar.CurrentRow.Cells("RegistroID").Value)
        Catch ex As Exception
        End Try
        RecorreDetalle()

        AccEditar = 0
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim consulta As System.String
        Dim conexion As System.Data.Common.DbConnection
        Dim c, existe As Integer

        c = dgbParaAsentarDetalle.Rows.Count()
        If c = 0 Then
            Exit Sub
        End If

        Dim ConsultaSQL As String = "ModuloID=" & dgvParaAsentar.CurrentRow.Cells("ModuloID").Value & " AND RegistroID =" & _
                                    dgvParaAsentar.CurrentRow.Cells("RegistroID").Value & " AND CODPLANCUENTA"

        'Verificamos si existe o no en la bd 
        existe = f.FuncionConsultaDecimal("AsientoID", "PARAASENTAR ", ConsultaSQL, dgbParaAsentarDetalle.CurrentRow.Cells("CODPLANCUENTADetalle").Value)

        If existe > 0 Then
            Try
                consulta = "DELETE FROM PARAASENTAR WHERE AsientoID=" & existe & " "
                conexion = ser.Abrir()

                Try
                    Consultas.ConsultaComando(conexion, consulta)
                Finally
                    conexion.Close()
                End Try

            Catch ex As Exception
                MessageBox.Show("Error al eliminar el detalle", "POSEXPRESS")
                Exit Sub
            End Try
        End If

        dgbParaAsentarDetalle.Rows.Remove(Me.dgbParaAsentarDetalle.CurrentRow)
        RecorreDetalle()
    End Sub

    Private Sub cbxDebeHaber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDebeHaber.SelectedIndexChanged
        If cbxDebeHaber.Text = "Debe" Then
            Me.tbxDebe.Focus()
            Me.tbxHaber.Text = 0
        ElseIf cbxDebeHaber.Text = "Haber" Then
            Me.tbxHaber.Focus()
            Me.tbxDebe.Text = 0
        End If
    End Sub

    Private Sub dgbParaAsentarDetalle_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbParaAsentarDetalle.CellDoubleClick
        If dgbParaAsentarDetalle.RowCount <> 0 Then
            If AccEditar = 1 Then
                Linea = dgbParaAsentarDetalle.CurrentRow.Index

                btModificar.BringToFront()
                btnCancelar.BringToFront()

                tbxCodCuenta.Text = dgbParaAsentarDetalle.Rows(Linea).Cells("CODPLANCUENTADetalle").Value
                tbxNroCuenta.Text = dgbParaAsentarDetalle.Rows(Linea).Cells("NUMPLANCUENTA1").Value
                tbxCuenta.Text = dgbParaAsentarDetalle.Rows(Linea).Cells("DESCRIPCION1").Value
                txtFechaCuenta.Text = dgbParaAsentarDetalle.Rows(Linea).Cells("FECHAASIENTO").Value
                tbxDebe.Text = dgbParaAsentarDetalle.Rows(Linea).Cells("IMPORTED1").Value
                tbxHaber.Text = dgbParaAsentarDetalle.Rows(Linea).Cells("IMPORTEH1").Value

                If dgbParaAsentarDetalle.Rows(Linea).Cells("IMPORTED1").Value <> "0,00" Then
                    cbxDebeHaber.Text = "Debe"
                Else
                    cbxDebeHaber.Text = "Haber"
                End If
            End If
        End If
    End Sub

    Private Sub dgbParaAsentarDetalle_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgbParaAsentarDetalle.SelectionChanged
        For i = 0 To dgbParaAsentarDetalle.Rows.Count - 1
            If IsDBNull(dgbParaAsentarDetalle.CurrentRow.Cells("FECHAASIENTO").Value) Then
                dgbParaAsentarDetalle.CurrentRow.Cells("FECHAASIENTO").Value = Today
                tbxFecha.Text = dgbParaAsentarDetalle.CurrentRow.Cells("FECHAASIENTO").Value
            Else
                tbxFecha.Text = dgbParaAsentarDetalle.CurrentRow.Cells("FECHAASIENTO").Value
            End If
        Next
    End Sub

    Private Sub txtFechaCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxNroCuenta.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub dgbPlanCuentas_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbPlanCuentas.CellDoubleClick
        If dgbPlanCuentas.RowCount <> 0 Then
            tbxCodCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("CODPLANCUENTA").Value
            tbxNroCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("NUMPLANCUENTA").Value
            tbxCuenta.Text = dgbPlanCuentas.CurrentRow.Cells("DESPLANCUENTA").Value
            cbxDebeHaber.Focus()
            UltraPopupControlContainer1.Close()
        End If
    End Sub
#End Region

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Try
            Me.PARAASENTARCAB_COMPRASTableAdapter.FillBy(Me.DsPlantillasConta.PARAASENTARCAB_COMPRAS, 3, 4, 11, FechaFiltro1, FechaFiltro2)
        Catch ex As Exception
        End Try

        If dgvParaAsentar.RowCount = 0 Then
            btnAsentar.Image = My.Resources.ApproveOff : btnAsentar.Enabled = False
            ModificarPictureBox.Image = My.Resources.EditOff : ModificarPictureBox.Enabled = False
            EliminarPictureBox.Image = My.Resources.DeleteOff : EliminarPictureBox.Enabled = False
        Else
            btnAsentar.Image = My.Resources.Approve : btnAsentar.Enabled = True
            ModificarPictureBox.Image = My.Resources.Edit : ModificarPictureBox.Enabled = True
            EliminarPictureBox.Image = My.Resources.Delete : EliminarPictureBox.Enabled = True
        End If

        RecorreDetalle()
    End Sub

    Private Sub btModificar_Click(sender As System.Object, e As System.EventArgs) Handles btModificar.Click
        btModificar.SendToBack()
        btnCancelar.SendToBack()

        ' dgbParaAsentarDetalle.Rows(Linea).Cells("AsientoID").Value = 0
        dgbParaAsentarDetalle.Rows(Linea).Cells("MODULOID1").Value = dgvParaAsentar.CurrentRow.Cells("ModuloID").Value
        dgbParaAsentarDetalle.Rows(Linea).Cells("REGISTROID1").Value = dgvParaAsentar.CurrentRow.Cells("RegistroID").Value
        dgbParaAsentarDetalle.Rows(Linea).Cells("CODPLANCUENTADetalle").Value = tbxCodCuenta.Text
        dgbParaAsentarDetalle.Rows(Linea).Cells("NUMPLANCUENTA1").Value = tbxNroCuenta.Text
        dgbParaAsentarDetalle.Rows(Linea).Cells("DESCRIPCION1").Value = tbxCuenta.Text
        dgbParaAsentarDetalle.Rows(Linea).Cells("FECHAASIENTO").Value = txtFechaCuenta.Text
        dgbParaAsentarDetalle.Rows(Linea).Cells("EstadoGrilla").Value = "U"

        If cbxDebeHaber.Text = "Debe" Then
            dgbParaAsentarDetalle.Rows(Linea).Cells("IMPORTED1").Value = tbxDebe.Text
            dgbParaAsentarDetalle.Rows(Linea).Cells("IMPORTEH1").Value = 0
        ElseIf cbxDebeHaber.Text = "Haber" Then
            dgbParaAsentarDetalle.Rows(Linea).Cells("IMPORTEH1").Value = tbxHaber.Text
            dgbParaAsentarDetalle.Rows(Linea).Cells("IMPORTED1").Value = 0
        End If

        tbxNroCuenta.Text = "" : cbxDebeHaber.Text = "" : tbxDebe.Text = "" : tbxHaber.Text = "" : tbxCuenta.Text = "" : txtFechaCuenta.Text = ""
        RecorreDetalle()
        txtFechaCuenta.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        tbxNroCuenta.Text = "" : cbxDebeHaber.Text = "" : tbxDebe.Text = "" : tbxHaber.Text = "" : tbxCuenta.Text = "" : txtFechaCuenta.Text = ""
        RecorreDetalle()
        btModificar.SendToBack()
        btnCancelar.SendToBack()

        txtFechaCuenta.Focus()
    End Sub

    Private Sub tbxNroCuenta_LostFocus(sender As Object, e As System.EventArgs) Handles tbxNroCuenta.LostFocus
        Dim objCommand As New SqlCommand

        If tbxNroCuenta.Text <> "" Then
            Try
                objCommand.CommandText = "SELECT CODPLANCUENTA, NUMPLANCUENTA, DESPLANCUENTA FROM dbo.plancuentas WHERE NUMPLANCUENTA = '" & tbxNroCuenta.Text & "'"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        tbxCodCuenta.Text = odrConfig("CODPLANCUENTA")
                        tbxCuenta.Text = odrConfig("DESPLANCUENTA")
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        Dim sql As String

        If dgvParaAsentar.RowCount <> 0 Then
            If MessageBox.Show("¿Esta seguro que quiere eliminar el registro?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            If dgvParaAsentar.RowCount <> 0 Then
                Try
                    ser.Abrir(sqlc)
                    cmd.Connection = sqlc

                    sql = ""
                    sql = "DELETE PARAASENTAR WHERE (ModuloID = " & dgvParaAsentar.CurrentRow.Cells("ModuloID").Value & ") AND (RegistroID = " & dgvParaAsentar.CurrentRow.Cells("RegistroID").Value & ")"

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    sqlc.Close()

                Catch ex As SqlException
                    MessageBox.Show("Ocurrió un error al tratar de Eliminar ", "POSEXPRESS")
                    Exit Sub
                End Try

                CodTemp = dgvParaAsentar.CurrentRow.Cells("RegistroID").Value
                TempModulo = dgvParaAsentar.CurrentRow.Cells("ModuloID").Value

                FechaFiltro()
                Try
                    Me.PARAASENTARCAB_COMPRASTableAdapter.FillBy(Me.DsPlantillasConta.PARAASENTARCAB_COMPRAS, 3, 4, 11, FechaFiltro1, FechaFiltro2)
                Catch ex As Exception
                End Try

                'Buscamos la posicion del registro guardado
                For i = 0 To dgvParaAsentar.RowCount - 1
                    If dgvParaAsentar.Rows(i).Cells("RegistroID").Value = CodTemp And dgvParaAsentar.Rows(i).Cells("ModuloID").Value = TempModulo Then
                        PARAASENTARCABCOMPRASBindingSource.Position = i
                    End If
                Next

                Try
                    Me.PARAASENTARDETTableAdapter.Fill(Me.DsPlantillasConta.PARAASENTARDET, dgvParaAsentar.CurrentRow.Cells("ModuloID").Value, dgvParaAsentar.CurrentRow.Cells("RegistroID").Value)
                Catch ex As Exception
                End Try
                RecorreDetalle()
            End If
        End If
    End Sub
End Class


