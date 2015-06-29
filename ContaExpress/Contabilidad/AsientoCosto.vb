Imports System.Data.SqlClient
Imports System.IO
Imports Osuna.Utiles.Conectividad

Public Class AsientoCosto
    Private ser As BDConexión.BDConexion
    Private myTrans As SqlTransaction
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Dim panelactivo As String
    Dim f As New Funciones.Funciones
    Dim permiso As Double

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub AsientoCosto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 256)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        panelactivo = "Venta"
        PanelVentas.BringToFront()
    End Sub

    Private Sub btFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btFiltrar.Click
        Dim FechaInicio, FechaFin As String

        FechaInicio = dtpFechaDesde.Text & " 12:00:00 a.m."
        FechaFin = dtpFechaHasta.Text & " 11:59:00 p.m."

        If panelactivo = "Venta" Then
            Me.VENTASDETALLETableAdapter.Fill(DsCosteo.VENTASDETALLE, FechaInicio, FechaFin)
        Else
            Me.ACDEVOLUCIONDETALLETableAdapter.Fill(DsCosteo.ACDEVOLUCIONDETALLE, FechaInicio, FechaFin)
            Dim dt As DataTable = ACDEVOLUCIONDETALLETableAdapter.GetData(FechaInicio, FechaFin)
        End If

    End Sub

    Private Sub btnGenerarAsiento_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarAsiento.Click
        dgwResultado.Rows.Clear()

        Me.Cursor = Cursors.AppStarting

        Dim FechaActual, FechaRegistro As String
        Dim AsintosMax As Integer = f.Maximo("NUMASIENTO", "ASIENTOS")
        Dim CostoTotal As Integer = 0
        Dim Reg As Integer

        If panelactivo = "Venta" Then
            Me.PLANTILLACOSTOTableAdapter.Fill(Me.DsCosteo.PLANTILLACOSTO, 8)

            If dgvVentasDetalle.RowCount <> 0 Then
                FechaActual = dgvVentasDetalle.Rows(0).Cells("FECHAVENTA").Value
                FechaActual = Format(FechaActual, "Short Date")

                Try
                    'Sumamos el Costo agrupado por dia
                    For i = 0 To dgvVentasDetalle.RowCount - 1
                        FechaRegistro = dgvVentasDetalle.Rows(i).Cells("FECHAVENTA").Value
                        FechaRegistro = Format(FechaRegistro, "Short Date")

                        If FechaActual = FechaRegistro Then '--> Si las fechas son iguales sumamos
Costo:                      If IsDBNull(dgvVentasDetalle.Rows(i).Cells("SUBTOTAL").Value) Then
                            Else
                                CostoTotal = CostoTotal + dgvVentasDetalle.Rows(i).Cells("SUBTOTAL").Value
                            End If

                        Else '--> Si las fechas cambiaron debemos insertar en la grilla
                            AsintosMax = AsintosMax + 1
                            For j = 0 To dgwPlantillaCosto.RowCount - 1
                                dgwResultado.Rows.Add()
                                Reg = dgwResultado.RowCount - 1

                                dgwResultado.Item(0, Reg).Value = AsintosMax
                                dgwResultado.Item(1, Reg).Value = FechaActual
                                dgwResultado.Item(2, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("NUMPLANCUENTA").Value
                                dgwResultado.Item(3, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("DESPLANCUENTA").Value

                                If dgwPlantillaCosto.Rows(j).Cells("Debe1").Value = "SI" Then
                                    dgwResultado.Item(4, Reg).Value = CostoTotal
                                ElseIf dgwPlantillaCosto.Rows(j).Cells("Haber1").Value = "SI" Then
                                    dgwResultado.Item(5, Reg).Value = CostoTotal
                                End If

                                dgwResultado.Item(6, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("CODPLANCUENTA").Value
                            Next

                            FechaActual = dgvVentasDetalle.Rows(i).Cells("FECHAVENTA").Value
                            FechaActual = Format(FechaActual, "Short Date")
                            CostoTotal = 0

                            GoTo Costo
                        End If
                    Next

                    'Hacemos esto para el ultimo registro
                    AsintosMax = AsintosMax + 1
                    For j = 0 To dgwPlantillaCosto.RowCount - 1
                        dgwResultado.Rows.Add()
                        Reg = dgwResultado.RowCount - 1

                        dgwResultado.Item(0, Reg).Value = AsintosMax
                        dgwResultado.Item(1, Reg).Value = FechaActual
                        dgwResultado.Item(2, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("NUMPLANCUENTA").Value
                        dgwResultado.Item(3, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("DESPLANCUENTA").Value

                        If dgwPlantillaCosto.Rows(j).Cells("Debe1").Value = "SI" Then
                            dgwResultado.Item(4, Reg).Value = CostoTotal
                        ElseIf dgwPlantillaCosto.Rows(j).Cells("Haber1").Value = "SI" Then
                            dgwResultado.Item(5, Reg).Value = CostoTotal
                        End If

                        dgwResultado.Item(6, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("CODPLANCUENTA").Value
                    Next

                Catch ex As Exception
                End Try
            End If
        Else 'Devolucion
            Me.PLANTILLACOSTOTableAdapter.Fill(Me.DsCosteo.PLANTILLACOSTO, 11)

            If dgvDevolucionDet.RowCount <> 0 Then
                FechaActual = dgvDevolucionDet.Rows(0).Cells("FECHADEVOLUCION").Value
                FechaActual = Format(FechaActual, "Short Date")

                Try
                    'Sumamos el Costo agrupado por dia
                    For i = 0 To dgvDevolucionDet.RowCount - 1
                        FechaRegistro = dgvDevolucionDet.Rows(i).Cells("FECHADEVOLUCION").Value
                        FechaRegistro = Format(FechaRegistro, "Short Date")

                        If FechaActual = FechaRegistro Then '--> Si las fechas son iguales sumamos
Costo2:                     If IsDBNull(dgvDevolucionDet.Rows(i).Cells("SUBTOTAL").Value) Then
                            Else
                                CostoTotal = CostoTotal + dgvDevolucionDet.Rows(i).Cells("SUBTOTAL").Value
                            End If

                        Else '--> Si las fechas cambiaron debemos insertar en la grilla
                            AsintosMax = AsintosMax + 1
                            For j = 0 To dgwPlantillaCosto.RowCount - 1
                                dgwResultado.Rows.Add()
                                Reg = dgwResultado.RowCount - 1

                                dgwResultado.Item(0, Reg).Value = AsintosMax
                                dgwResultado.Item(1, Reg).Value = FechaActual
                                dgwResultado.Item(2, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("NUMPLANCUENTA").Value
                                dgwResultado.Item(3, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("DESPLANCUENTA").Value

                                If dgwPlantillaCosto.Rows(j).Cells("Debe1").Value = "SI" Then
                                    dgwResultado.Item(4, Reg).Value = CostoTotal
                                ElseIf dgwPlantillaCosto.Rows(j).Cells("Haber1").Value = "SI" Then
                                    dgwResultado.Item(5, Reg).Value = CostoTotal
                                End If

                                dgwResultado.Item(6, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("CODPLANCUENTA").Value
                            Next

                            FechaActual = dgvDevolucionDet.Rows(i).Cells("FECHADEVOLUCION").Value
                            FechaActual = Format(FechaActual, "Short Date")
                            CostoTotal = 0

                            GoTo Costo2
                        End If
                    Next

                    'Hacemos esto para el ultimo registro
                    AsintosMax = AsintosMax + 1
                    For j = 0 To dgwPlantillaCosto.RowCount - 1
                        dgwResultado.Rows.Add()
                        Reg = dgwResultado.RowCount - 1

                        dgwResultado.Item(0, Reg).Value = AsintosMax
                        dgwResultado.Item(1, Reg).Value = FechaActual
                        dgwResultado.Item(2, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("NUMPLANCUENTA").Value
                        dgwResultado.Item(3, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("DESPLANCUENTA").Value

                        If dgwPlantillaCosto.Rows(j).Cells("Debe1").Value = "SI" Then
                            dgwResultado.Item(4, Reg).Value = CostoTotal
                        ElseIf dgwPlantillaCosto.Rows(j).Cells("Haber1").Value = "SI" Then
                            dgwResultado.Item(5, Reg).Value = CostoTotal
                        End If

                        dgwResultado.Item(6, Reg).Value = dgwPlantillaCosto.Rows(j).Cells("CODPLANCUENTA").Value
                    Next

                Catch ex As Exception
                End Try
            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btAsentarCosto_Click(sender As System.Object, e As System.EventArgs) Handles btAsentarCosto.Click
        Me.Cursor = Cursors.AppStarting

        If dgwResultado.RowCount <> 0 Then
            Dim sql As String
            Dim fechaAsiento, PeriodoFiscal, Detalle As String
            Dim ImporteD, ImporteH As Integer

            'Volvamos los datos de la Grilla Resultados a Tabla Asientos
            PeriodoFiscal = f.FuncionConsultaDecimal("CODPERIODOFISCAL", "periodofiscal", "ESTADO", 1)

            ser.Abrir(sqlc)
            cmd.Connection = sqlc
 
            For i = 0 To dgwResultado.RowCount - 1
                Try
                    fechaAsiento = dgwResultado.Rows(i).Cells("Fecha").Value

                    If IsDBNull(dgwResultado.Rows(i).Cells("Debe").Value) Then
                        ImporteD = 0
                    Else
                        ImporteD = dgwResultado.Rows(i).Cells("Debe").Value
                    End If

                    If IsDBNull(dgwResultado.Rows(i).Cells("Haber").Value) Then
                        ImporteH = 0
                    Else
                        ImporteH = dgwResultado.Rows(i).Cells("Haber").Value
                    End If

                    If panelactivo = "Venta" Then
                        Detalle = "Asiento de Costo del " & fechaAsiento
                        sql = "INSERT INTO ASIENTOS (ModuloID,RegistroID,CODMONEDA,FECHAASIENTO,COTIZACION, CODPERIODOFISCAL,CODPLANCUENTA,DESCRIPCION,IMPORTED,IMPORTEH,DETALLE,NUMASIENTO) " & _
                               "VALUES (8, 0, 1 , " & "CONVERT(DATETIME,'" & fechaAsiento & "',103) , 1 , " & PeriodoFiscal & "," & dgwResultado.Rows(i).Cells("CodCuenta").Value & ",'" & dgwResultado.Rows(i).Cells("PlanCuenta").Value & "'," & _
                                ImporteD & "," & ImporteH & ",'" & Detalle & "'," & dgwResultado.Rows(i).Cells("NroAsiento").Value & ")"
                    Else
                        Detalle = "Reversión de Asiento de Costo del " & fechaAsiento
                        sql = "INSERT INTO ASIENTOS (ModuloID,RegistroID,CODMONEDA,FECHAASIENTO,COTIZACION, CODPERIODOFISCAL,CODPLANCUENTA,DESCRIPCION,IMPORTED,IMPORTEH,DETALLE,NUMASIENTO) " & _
                               "VALUES (11, 0, 1 , " & "CONVERT(DATETIME,'" & fechaAsiento & "',103) , 1 , " & PeriodoFiscal & "," & dgwResultado.Rows(i).Cells("CodCuenta").Value & ",'" & dgwResultado.Rows(i).Cells("PlanCuenta").Value & "'," & _
                                ImporteD & "," & ImporteH & ",'" & Detalle & "'," & dgwResultado.Rows(i).Cells("NroAsiento").Value & ")"
                    End If
                    
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    Try
                        myTrans.Rollback("Actualizar")
                    Catch

                    End Try
                    MessageBox.Show("Ocurrio un error al intentar Asentar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            Next

            If panelactivo = "Ventas" Or panelactivo = "Venta" Then
                'Una Vez que pasamos los datos a la tabla de Asientos debemos marcar como costeados dichas ventas.
                For i = 0 To dgvVentasDetalle.RowCount - 1
                    Try
                        sql = " UPDATE VENTASDETALLE SET COSTEADO = 1 WHERE VentaDetalleID =" & dgvVentasDetalle.Rows(i).Cells("VentaDetalleID").Value

                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        MessageBox.Show("Error al Actualizar VentasDetalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
            Else
                'Una Vez que pasamos los datos a la tabla de Asientos debemos marcar como costeados dichas devoluciones.
                For i = 0 To dgvDevolucionDet.RowCount - 1
                    Try
                        sql = " UPDATE DEVOLUCIONDETALLE SET COSTEADO = 1 WHERE CODDEVOLDET= " & dgvDevolucionDet.Rows(i).Cells("CODDEVOLDET").Value

                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        MessageBox.Show("Error al Actualizar DevolucionDetalle", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
            End If
            
            MessageBox.Show("Asiento Generado Exitosamente!", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Debe generar Primero los Resultados antes de Asentar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        dgwResultado.Rows.Clear()

        If panelactivo = "Venta" Then
            Me.VENTASDETALLETableAdapter.Fill(DsCosteo.VENTASDETALLE, dtpFechaDesde.Value, dtpFechaHasta.Value)
        Else
            Me.ACDEVOLUCIONDETALLETableAdapter.Fill(DsCosteo.ACDEVOLUCIONDETALLE, dtpFechaDesde.Value, dtpFechaHasta.Value)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvVentasDetalle_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVentasDetalle.CellDoubleClick
        Dim nvoNumero As String = InputBox("Ingrese El Costo Unitario del Producto : ", " Modificar Costo", "")
       
        If dgvVentasDetalle.RowCount <> 0 Then
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            Dim consulta As System.String

            conexion = ser.Abrir()
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            Try
                consulta = " UPDATE VENTASDETALLE SET COSTOPROMEDIO = " & nvoNumero & "  WHERE VentaDetalleID =" & dgvVentasDetalle.CurrentRow.Cells("VentaDetalleID").Value

                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()

            Catch ex As Exception
                MessageBox.Show("Error al Actualizar el Costo", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Me.VENTASDETALLETableAdapter.Fill(DsCosteo.VENTASDETALLE, dtpFechaDesde.Value, dtpFechaHasta.Value)
        End If
    End Sub

    Private Sub dgvDevolucionDet_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDevolucionDet.CellDoubleClick
        Dim nvoNumero As String = InputBox("Ingrese El Costo Total del Producto (Costo * Cant.): ", " Modificar Costo", "")

        If dgvDevolucionDet.RowCount <> 0 Then
            Dim conexion As System.Data.SqlClient.SqlConnection
            Dim myTrans As System.Data.SqlClient.SqlTransaction
            Dim consulta As System.String

            conexion = ser.Abrir()
            myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            Try
                consulta = " UPDATE DEVOlUCIONDETALLE SET COSTOPROMEDIO = " & nvoNumero & "  WHERE CODDEVOLDET=" & dgvDevolucionDet.CurrentRow.Cells("CODDEVOLDET").Value

                Consultas.ConsultaComando(myTrans, consulta)
                myTrans.Commit()

            Catch ex As Exception
                MessageBox.Show("Error al Actualizar el Costo", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Me.ACDEVOLUCIONDETALLETableAdapter.Fill(DsCosteo.ACDEVOLUCIONDETALLE, dtpFechaDesde.Value, dtpFechaHasta.Value)
        End If
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        If panelactivo = "Venta" Then
            VENTASDETALLEBindingSource.Filter = "NUMVENTA LIKE '%" & BuscarTextBox.Text & "%' OR DESPRODUCTO LIKE '%" & BuscarTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarTextBox.Text & "%'"
        Else
            ACDEVOLUCIONDETALLEBindingSource.Filter = "NUMDEVOLUCION LIKE '%" & BuscarTextBox.Text & "%' OR DESPRODUCTO LIKE '%" & BuscarTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarTextBox.Text & "%'"
        End If
    End Sub

    Private Sub lblCambiarModulo_Click(sender As System.Object, e As System.EventArgs) Handles lblCambiarModulo.Click
        If lblCambiarModulo.Text = "Cambiar a Devoluciones" Then
            panelactivo = "Devolucion"
            PanelDevolucion.BringToFront()
            PanelVentas.SendToBack()
            lblCambiarModulo.Text = "Cambiar a Ventas"
        Else
            panelactivo = "Venta"
            PanelDevolucion.SendToBack()
            PanelVentas.BringToFront()
            lblCambiarModulo.Text = "Cambiar a Devoluciones"
        End If
    End Sub

    Private Sub lblCambiarModulo_MouseHover(sender As Object, e As System.EventArgs) Handles lblCambiarModulo.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lblCambiarModulo_MouseLeave(sender As Object, e As System.EventArgs) Handles lblCambiarModulo.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvVentasDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentasDetalle.CellContentClick

    End Sub
End Class