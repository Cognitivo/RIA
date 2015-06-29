Public Class frmReAsentar
    Dim permiso As Double
    Dim f As New Funciones.Funciones
    Dim VentaCompra As Integer
    Dim FechaFiltro1, FechaFiltro2 As Date

    Private Sub frmReAsentar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            permiso = PermisoAplicado(UsuCodigo, 196)
            If Permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
            End If

            cbxModulos.Text = "VENTAS"
            PanelVenta.BringToFront()

            cmbAnho.SelectedText = Today.Year.ToString
            cmbMes.SelectedIndex = Today.Month - 1
            FechaFiltro()

            Me.ReAsentarVentasTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarVentas, FechaFiltro1, FechaFiltro2)
            Me.ReAsentarCobrosTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarCobros, FechaFiltro1, FechaFiltro2)
            Me.ReAsentarComprasTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarCompras, FechaFiltro1, FechaFiltro2)
            Me.ReAsentarPagosTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarPagos, FechaFiltro1, FechaFiltro2)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbTodos_CheckedChanged(sender As Object, e As System.EventArgs) Handles cmbTodos.CheckedChanged
        Dim c As Integer = dgbParaAsentarDetalle.RowCount
        Dim cc As Integer = dgbParaAsentarDetalleCompra.RowCount
        Dim ccc As Integer = dgvReAsentarCobro.RowCount
        Dim cccc As Integer = dgvReAsentarPagos.RowCount

        If cbxModulos.Text = "VENTAS" Then
            If c = 0 Then
                Exit Sub
            Else
                For i = 0 To c - 1
                    If cmbTodos.Checked = True Then
                        dgbParaAsentarDetalle.Rows(i).Cells("Marcar").Value = 1
                    ElseIf cmbTodos.Checked = False Then
                        dgbParaAsentarDetalle.Rows(i).Cells("Marcar").Value = 0
                    End If
                Next
            End If

        ElseIf cbxModulos.Text = "COMPRAS" Then
            If cc = 0 Then
                Exit Sub
            Else
                For i = 0 To cc - 1
                    If cmbTodos.Checked = True Then
                        dgbParaAsentarDetalleCompra.Rows(i).Cells("Marcar1").Value = 1
                    ElseIf cmbTodos.Checked = False Then
                        dgbParaAsentarDetalleCompra.Rows(i).Cells("Marcar1").Value = 0

                    End If
                Next
            End If

        ElseIf cbxModulos.Text = "COBROS" Then
            If ccc = 0 Then
                Exit Sub
            Else
                For i = 0 To ccc - 1
                    If cmbTodos.Checked = True Then
                        dgvReAsentarCobro.Rows(i).Cells("Marcar2").Value = 1
                    ElseIf cmbTodos.Checked = False Then
                        dgvReAsentarCobro.Rows(i).Cells("Marcar2").Value = 0

                    End If
                Next
            End If

        ElseIf cbxModulos.Text = "PAGOS" Then
            If cccc = 0 Then
                Exit Sub
            Else
                For i = 0 To cccc - 1
                    If cmbTodos.Checked = True Then
                        dgvReAsentarPagos.Rows(i).Cells("Marcar3").Value = 1
                    ElseIf cmbTodos.Checked = False Then
                        dgvReAsentarPagos.Rows(i).Cells("Marcar3").Value = 0

                    End If
                Next
            End If
        End If

    End Sub

    Private Sub btnAsentar_Click(sender As System.Object, e As System.EventArgs) Handles btnAsentar.Click
        Dim HuboError As Integer = 0
        Dim ParaMensaje As Integer = 0
        Dim ConceptoAsiento, Timbrado, IVA5, IVA10, IVAEXE, TOTALIVA As String
        Dim codVenta, codCompra, moneda, numventa, FechaVenta As String
        Dim cotizacion, metodo, TipoCompra, TipoVenta As String
        Dim codcliente, RgMonet, RgMerc, TotalVenta, TotalCompra As Integer
        Dim comprobante, cliente As String
        Dim nombreCliente As String

        If cbxModulos.Text = "VENTAS" Then
            For i = 0 To dgbParaAsentarDetalle.Rows.Count - 1
                Try
                    Dim dgvCheckBoxCellVenta As DataGridViewCheckBoxCell = Me.dgbParaAsentarDetalle.Rows(i).Cells("Marcar")
                    Me.dgbParaAsentarDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    Dim checkedVenta As Boolean = CType(dgvCheckBoxCellVenta.Value, Boolean)
                    If checkedVenta = True Then
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("CODVENTA").Value) Then
                            codVenta = dgbParaAsentarDetalle.Rows(i).Cells("CODVENTA").Value
                        Else
                            codVenta = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("CODMONEDA").Value) Then
                            moneda = dgbParaAsentarDetalle.Rows(i).Cells("CODMONEDA").Value
                        Else
                            moneda = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("NUMVENTA").Value) Then
                            numventa = dgbParaAsentarDetalle.Rows(i).Cells("NUMVENTA").Value
                        Else
                            numventa = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("FECHAVENTA").Value) Then
                            FechaVenta = dgbParaAsentarDetalle.Rows(i).Cells("FECHAVENTA").Value
                        Else
                            FechaVenta = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("TOTALVENTA").Value) Then
                            TotalVenta = dgbParaAsentarDetalle.Rows(i).Cells("TOTALVENTA").Value
                        Else
                            TotalVenta = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("TIPOVENTA").Value) Then
                            TipoVenta = dgbParaAsentarDetalle.Rows(i).Cells("TIPOVENTA").Value
                        Else
                            TipoVenta = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("METODO").Value) Then
                            metodo = dgbParaAsentarDetalle.Rows(i).Cells("METODO").Value
                        Else
                            metodo = "NULL"
                        End If

                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("COTIZACION1").Value) Then
                            cotizacion = dgbParaAsentarDetalle.Rows(i).Cells("COTIZACION1").Value
                        Else
                            cotizacion = "0"
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("TOTALEXENTA").Value) Then
                            IVAEXE = dgbParaAsentarDetalle.Rows(i).Cells("TOTALEXENTA").Value
                        Else
                            IVAEXE = 0
                        End If

                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("TOTAL5").Value) Then
                            IVA5 = dgbParaAsentarDetalle.Rows(i).Cells("TOTAL5").Value
                        Else
                            IVA5 = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("TOTAL10").Value) Then
                            IVA10 = dgbParaAsentarDetalle.Rows(i).Cells("TOTAL10").Value
                        Else
                            IVA10 = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("TOTALIVA").Value) Then
                            TOTALIVA = dgbParaAsentarDetalle.Rows(i).Cells("TOTALIVA").Value
                        Else
                            TOTALIVA = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("CODCOMPROBANTE").Value) Then
                            comprobante = dgbParaAsentarDetalle.Rows(i).Cells("CODCOMPROBANTE").Value
                        Else
                            comprobante = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("CODCLIENTE").Value) Then
                            codcliente = dgbParaAsentarDetalle.Rows(i).Cells("CODCLIENTE").Value
                        Else
                            codcliente = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalle.Rows(i).Cells("NOMBRECLIENTE").Value) Then
                            cliente = dgbParaAsentarDetalle.Rows(i).Cells("NOMBRECLIENTE").Value
                        Else
                            cliente = ""
                        End If

                        Timbrado = f.FuncionConsulta("TIMBRADO", "DETPC", "IP=" & CodigoMaquina & " AND CODEMPRESA=" & EmpCodigo & " AND CODSUCURSAL=" & SucCodigo & _
                                                 " AND ACTIVO = 1 AND CODCOMPROBANTE", comprobante)
                        If TipoVenta = "Contado" Then
                            RgMonet = 1
                        ElseIf TipoVenta = "Crédito" Or TipoVenta = "Credito" Then
                            RgMonet = 2
                        End If

                        If RTrim(metodo) = "Simplificado" Then
                            RgMerc = 1
                        ElseIf RTrim(metodo) = "Avanzado" Then
                            RgMerc = 2
                        End If

                        If HuboError <> 1 Then
                            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
                            ConceptoAsiento = "Factura de Venta " & TipoVenta & " / " & cliente
                            ReglaContable(IVAEXE, IVA5, IVA10, TOTALIVA, "VENTAS", codVenta, "CODVENTA", ConceptoAsiento, RgMerc, RgMonet, _
                                          moneda, cotizacion, numventa, FechaVenta, TotalVenta, "8", Timbrado, codcliente, SucCodigo)
                        End If
                        HuboError = 0
                    End If
                Catch ex As Exception
                    MessageBox.Show("Problemas al registrar el asiento:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            Next

            If ParaMensaje <> 0 Then
                MessageBox.Show("No se pudo procesar toda la información porque no se encontraron algunos datos.", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Me.ReAsentarVentasTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarVentas)
            ReAsentarVentasTableAdapter.Fill(DsPlantillasConta.ReAsentarVentas, FechaFiltro1, FechaFiltro2)

            MessageBox.Show("Datos Procesados Correctamente ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf cbxModulos.Text = "COMPRAS" Then
            For i = 0 To dgbParaAsentarDetalleCompra.Rows.Count - 1
                Try
                    Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgbParaAsentarDetalleCompra.Rows(i).Cells("Marcar1")
                    Me.dgbParaAsentarDetalleCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)
                    If checked = True Then
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("CODCOMPRA").Value) Then
                            codCompra = dgbParaAsentarDetalleCompra.Rows(i).Cells("CODCOMPRA").Value
                        Else
                            codCompra = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("CODMONEDA1").Value) Then
                            moneda = dgbParaAsentarDetalleCompra.Rows(i).Cells("CODMONEDA1").Value
                        Else
                            moneda = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("NUMCOMPRA").Value) Then
                            numventa = dgbParaAsentarDetalleCompra.Rows(i).Cells("NUMCOMPRA").Value
                        Else
                            numventa = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("FECHACOMPRA").Value) Then
                            FechaVenta = dgbParaAsentarDetalleCompra.Rows(i).Cells("FECHACOMPRA").Value
                        Else
                            FechaVenta = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTALCOMPRA").Value) Then
                            TotalCompra = dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTALCOMPRA").Value
                        Else
                            TotalCompra = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("TIPOCOMPRA").Value) Then
                            TipoCompra = dgbParaAsentarDetalleCompra.Rows(i).Cells("TIPOCOMPRA").Value
                        Else
                            TipoCompra = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("METODO1").Value) Then
                            metodo = dgbParaAsentarDetalleCompra.Rows(i).Cells("METODO1").Value
                        Else
                            metodo = "NULL"
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("COTIZACION2").Value) Then
                            cotizacion = dgbParaAsentarDetalleCompra.Rows(i).Cells("COTIZACION2").Value
                        Else
                            cotizacion = "0"
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTALEXENTA1").Value) Then
                            IVAEXE = dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTALEXENTA1").Value
                        Else
                            IVAEXE = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTAL51").Value) Then
                            IVA5 = dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTAL51").Value
                            ' IVA5 = IVA5 / 21
                        Else
                            IVA5 = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTAL101").Value) Then
                            IVA10 = dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTAL101").Value
                            'IVA10 = IVA10 / 11
                        Else
                            IVA10 = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTALIVA1").Value) Then
                            TOTALIVA = dgbParaAsentarDetalleCompra.Rows(i).Cells("TOTALIVA1").Value
                        Else
                            TOTALIVA = 0
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("CODCOMPROBANTE1").Value) Then
                            comprobante = dgbParaAsentarDetalleCompra.Rows(i).Cells("CODCOMPROBANTE1").Value
                        Else
                            comprobante = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("CODPROVEEDOR").Value) Then
                            cliente = dgbParaAsentarDetalleCompra.Rows(i).Cells("CODPROVEEDOR").Value
                        Else
                            cliente = ""
                        End If
                        If Not IsDBNull(dgbParaAsentarDetalleCompra.Rows(i).Cells("NOMBRE").Value) Then
                            nombreCliente = dgbParaAsentarDetalleCompra.Rows(i).Cells("NOMBRE").Value
                        Else
                            nombreCliente = ""
                        End If
                        Timbrado = f.FuncionConsulta("TIMBRADO", "DETPC", "IP=" & CodigoMaquina & " AND CODEMPRESA=" & EmpCodigo & " AND CODSUCURSAL=" & SucCodigo & _
                                                 " AND ACTIVO = 1 AND CODCOMPROBANTE", comprobante)
                        Dim tipcompra As String = ""
                        If TipoCompra = "Contado" Then
                            RgMonet = 1

                        ElseIf TipoCompra = "Crédito" Then
                            RgMonet = 2
                        End If

                        If RTrim(metodo) = "Simplificado" Then
                            RgMerc = 1
                        ElseIf RTrim(metodo) = "NULL" Then
                            HuboError = 1
                            ParaMensaje = ParaMensaje + 1
                        End If

                        If HuboError <> 1 Then
                            'Dimensionamos una variable de tipo Boolean para hacer la verificacion
                            ConceptoAsiento = "Factura de Compra " & tipcompra & " / " & nombreCliente
                            ReglaContable(IVAEXE, IVA5, IVA10, TOTALIVA, "COMPRAS", codCompra, "CODCOMPRA", ConceptoAsiento, RgMerc, RgMonet, _
                                          moneda, cotizacion, numventa, FechaVenta, TotalCompra, "3", Timbrado, cliente, SucCodigo)
                        End If
                        HuboError = 0
                    End If
                Catch ex As Exception
                    MessageBox.Show("Problemas al registrar el asiento:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            Next

            If ParaMensaje <> 0 Then
                MessageBox.Show("No se pudo procesar toda la información porque no se encontraron algunos datos.", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.ReAsentarComprasTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarCompras, FechaFiltro1, FechaFiltro2)
            MessageBox.Show("Datos Procesados Correctamente ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf cbxModulos.Text = "COBROS" Then
            Dim cabCobro As String
            For i = 0 To dgvReAsentarCobro.Rows.Count - 1
                Try
                    Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgvReAsentarCobro.Rows(i).Cells("Marcar4")
                    Me.dgvReAsentarCobro.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)
                    If checked = True Then
                        If Not IsDBNull(dgvReAsentarCobro.Rows(i).Cells("CABCOBRO").Value) Then
                            cabCobro = dgvReAsentarCobro.Rows(i).Cells("CABCOBRO").Value
                        Else
                            cabCobro = "0"
                        End If

                        If Not IsDBNull(dgvReAsentarCobro.Rows(i).Cells("CODCLIENTE2").Value) Then
                            cliente = dgvReAsentarCobro.Rows(i).Cells("CODCLIENTE2").Value
                        Else
                            cliente = ""
                        End If

                        'Dimensionamos una variable de tipo Boolean para hacer la verificacion
                        CobroContabilidad(cabCobro, cliente, SucCodigo)

                    End If
                Catch ex As Exception
                    MessageBox.Show("Problemas al registrar el asiento:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

            Next
            Me.ReAsentarCobrosTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarCobros, FechaFiltro1, FechaFiltro2)

        ElseIf cbxModulos.Text = "PAGOS" Then
            Dim cabpago As String
            Dim contador As Integer = 0
            For i = 0 To dgvReAsentarPagos.Rows.Count - 1
                Try
                    Dim dgvCheckBoxCell As DataGridViewCheckBoxCell = Me.dgvReAsentarPagos.Rows(i).Cells("Marcar3")
                    Me.dgvReAsentarPagos.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    Dim checked As Boolean = CType(dgvCheckBoxCell.Value, Boolean)
                    If checked = True Then
                        If Not IsDBNull(dgvReAsentarPagos.Rows(i).Cells("CABPAGO").Value) Then
                            cabpago = dgvReAsentarPagos.Rows(i).Cells("CABPAGO").Value
                        Else
                            cabpago = "0"
                            contador = contador + 1
                        End If

                        If Not IsDBNull(dgvReAsentarPagos.Rows(i).Cells("CODPROVEEDOR2").Value) Then
                            cliente = dgvReAsentarPagos.Rows(i).Cells("CODPROVEEDOR2").Value
                        Else
                            cliente = ""
                        End If

                        'Dimensionamos una variable de tipo Boolean para hacer la verificacion
                        PagosContabilidad(cabpago, cliente, SucCodigo)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Problemas al registrar el asiento:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

            Next
            Me.ReAsentarPagosTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarPagos, FechaFiltro1, FechaFiltro2)

        Else
            MessageBox.Show("Seleccione un Modulo ", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        Try
            If cbxModulos.Text = "VENTAS" Then
                Me.ReAsentarVentasBindingSource.Filter = "NOMBRECLIENTE LIKE ('%" + BuscarTextBox.Text + "%')OR NUMVENTA LIKE ('%" + BuscarTextBox.Text + "%')"

            ElseIf cbxModulos.Text = "COMPRAS" Then
                Me.ReAsentarComprasBindingSource.Filter = "NOMBRE LIKE ('%" + BuscarTextBox.Text + "%')OR NUMCOMPRA LIKE ('%" + BuscarTextBox.Text + "%')"

            ElseIf cbxModulos.Text = "COBROS" Then
                Me.ReAsentarCobrosBindingSource.Filter = "NOMBRECLIENTE LIKE ('%" + BuscarTextBox.Text + "%')OR NUMVENTA LIKE ('%" + BuscarTextBox.Text + "%')"

            ElseIf cbxModulos.Text = "PAGOS" Then
                Me.ReAsentarPagosBindingSource.Filter = "NOMBRE LIKE ('%" + BuscarTextBox.Text + "%')OR NUMCOMPRA LIKE ('%" + BuscarTextBox.Text + "%')"
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cbxModulos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cbxModulos.SelectedIndexChanged
        Try
            FechaFiltro()

            If cbxModulos.Text = "VENTAS" Then 'ventas
                PanelVenta.BringToFront()
                ReAsentarVentasTableAdapter.Fill(DsPlantillasConta.ReAsentarVentas, FechaFiltro1, FechaFiltro2)

            ElseIf cbxModulos.Text = "COMPRAS" Then 'compras
                PanelCompra.BringToFront()
                Me.ReAsentarComprasTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarCompras, FechaFiltro1, FechaFiltro2)

            ElseIf cbxModulos.Text = "COBROS" Then 'cobros
                PanelCobro.BringToFront()
                Me.ReAsentarCobrosTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarCobros, FechaFiltro1, FechaFiltro2)

            ElseIf cbxModulos.Text = "PAGOS" Then 'pagos
                Panelpagos.BringToFront()
                Me.ReAsentarPagosTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarPagos, FechaFiltro1, FechaFiltro2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FechaFiltro()
        Try
            If cbxModulos.Text = "VENTAS" Then 'ventas
                PanelVenta.BringToFront()
                ReAsentarVentasTableAdapter.Fill(DsPlantillasConta.ReAsentarVentas, FechaFiltro1, FechaFiltro2)

            ElseIf cbxModulos.Text = "COMPRAS" Then 'compras
                PanelCompra.BringToFront()
                Me.ReAsentarComprasTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarCompras, FechaFiltro1, FechaFiltro2)

            ElseIf cbxModulos.Text = "COBROS" Then 'cobros
                PanelCobro.BringToFront()
                Me.ReAsentarCobrosTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarCobros, FechaFiltro1, FechaFiltro2)

            ElseIf cbxModulos.Text = "PAGOS" Then 'pagos
                Panelpagos.BringToFront()
                Me.ReAsentarPagosTableAdapter.Fill(Me.DsPlantillasConta.ReAsentarPagos, FechaFiltro1, FechaFiltro2)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FechaFiltro()
        Try
            Dim nromes, nroaño As Integer
            Dim fechacompleta1, fechacompleta2, mes As String
            nromes = cmbMes.SelectedIndex + 1
            nroaño = CInt(cmbAnho.Text)

            If nromes = 10 Or nromes = 11 Or nromes = 12 Then
                mes = nromes.ToString
            Else
                mes = "0" + nromes.ToString

            End If
            fechacompleta1 = "01" + "/" + nromes.ToString + "/" + cmbAnho.Text
            fechacompleta2 = ""
            If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
                fechacompleta2 = "31" + "/" + nromes.ToString + "/" + cmbAnho.Text

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
   
End Class