Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms
Imports BDConexión
Imports Osuna.Utiles.Conectividad
Imports System.Drawing.SystemIcons

Public Class FiltroReporteInventario
    Dim sql As String
    Dim sql1 As String
    Dim Pos1 As System.Drawing.Point = New Point(3, 56)
    Dim Pos2 As System.Drawing.Point = New Point(3, 104)
    Dim Pos3 As System.Drawing.Point = New Point(3, 152)
    Dim Pos4 As System.Drawing.Point = New Point(3, 200)
    Dim Pos5 As System.Drawing.Point = New Point(3, 248)
    Dim Pos6 As System.Drawing.Point = New Point(3, 296)
    Dim Pos7 As System.Drawing.Point = New Point(3, 344)
    Dim PosSinFiltro As System.Drawing.Point = New Point(4, 31)
    Dim PosInvisible As System.Drawing.Point = New Point(3000, 33)
    Dim permiso As Double
    Dim FechaDesde As String
    Dim FechaHasta As String
    Dim ListaReportes(15, 3) As String
    Dim dtListaPrecio, dtSucursal, dtFamilia As DataTable
    Dim CodigoGral, FormatF1, FormatF2, FormatF3, FormatF4, FormatF5, Formateado As String
    Dim f As New Funciones.Funciones
    Dim banverifcheck As Boolean = True
    Dim Filtrar As Boolean = True
    Dim Buscador As String
    'Variables para la Conexion con la BD
    Private objCommand As New SqlCommand
    Private ser As BDConexión.BDConexion
    Private consulta As System.String
    Private conexion As System.Data.SqlClient.SqlConnection
    Private myTrans As System.Data.SqlClient.SqlTransaction

    Sub New()
        InitializeComponent()
        ser = New BDConexión.BDConexion()
    End Sub

    Private Sub FiltroReporteInventario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UltraPopupControlContainer1.IsDisplayed Then
                If Buscador = "Producto" Then 'Si mas adelante se agrega otro buscador, ya esta la variable para diferenciar cual esta abierto
                    BuscarProductoTextBox.Text = ""
                    cmbProducto.Focus()
                    UltraPopupControlContainer1.Close()
                End If
            End If
        End If
    End Sub

    Private Sub FiltroReporteInventario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.SuspendLayout() ' saul

        Me.FAMILIATableAdapter.Fill(Me.DsReporteProductoNW.FAMILIA)
        Dim dt As DataTable = Me.FAMILIATableAdapter.GetData
        Me.LineaTableAdapter.Fill(Me.DsReporteProductoNW.Linea)
        Me.RUBROTableAdapter.Fill(Me.DsReporteProductoNW.RUBRO)
        Me.SUCURSALTableAdapter.Fill(Me.DsReporteProductoNW.SUCURSAL)
        Me.RiProductosTableAdapter.Fill(Me.DsRVFiltroInventario.RIProductos)

        cargarListaReportes()
        PintarCeldas()

        Dim dr As DataRow
        dtSucursal = Me.SUCURSALTableAdapter.GetData()
        If dtSucursal.Rows.Count > 0 Then
            For i = 0 To dtSucursal.Rows.Count - 1
                dr = dtSucursal.Rows.Item(i)
                cmbSucursal.Items.Add(dr("DESSUCURSAL"))
            Next
        End If

        '--------------------Will.i.am----------------------
        dtFamilia = Me.FAMILIATableAdapter.GetData()
        If dtFamilia.Rows.Count > 0 Then
            For i = 0 To dtFamilia.Rows.Count - 1
                dr = dtFamilia.Rows.Item(i)
                cmbFamilia.Items.Add(dr("DESFAMILIA"))
            Next
        End If

        dtListaPrecio = Me.RITIPOCLIENTETableAdapter.GetData()
        If dtListaPrecio.Rows.Count > 0 Then
            For i = 0 To dtListaPrecio.Rows.Count - 1
                dr = dtListaPrecio.Rows.Item(i)
                cmbListaPrecio.Items.Add(dr("DESTIPOCLIENTE"))
            Next
        End If

        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpFechaHasta.Value = DateAdd(DateInterval.Day, 1, Today)
        BuscarTextBox.Focus()

        Me.ResumeLayout() ' saul
    End Sub

    Public Sub PintarCeldas()
        If dgvListaReportes.RowCount - 1 > 1 Then
            For i = 0 To dgvListaReportes.RowCount - 1
                If dgvListaReportes.Rows(i).Cells("REFERENCIA").Value = "TITULO" Then
                    dgvListaReportes.Item(0, i).Style.BackColor = Color.PaleGoldenrod
                Else
                    dgvListaReportes.Item(0, i).Style.BackColor = Color.White
                End If
            Next
        End If
    End Sub

    Private Sub cargarListaReportes()
        ListaReportes = {{"TITULO", "MOVIMIENTOS", "Movimiento,Producto,Detallado"},
                          {"rptMovProducto", "Movimiento Resumido de Productos", "Movimiento,Producto,Detallado"},
                          {"rptMovDetProducto", "Movimiento Detallado de Productos", "Movimiento,Producto,Detallado"},
                          {"rptMovDetFifo", "Movimiento Detallado Fifo", "Movimiento,Producto,Detallado"},
                          {"TITULO", "INVENTARIOS", "Stock,Fecha,Inventario"},
                          {"rptStockValAgrup", "Stock Valorizado Global", "Stock,Fecha,Inventario"},
                          {"rptStockActual", "Stock de Producto/ Inventario Actual", "Stock,Fecha,Inventario,Minimo"},
                          {"rptStockFecha", "Stock de Producto a una Fecha", "Stock,Fecha,Inventario,Minimo"},
                          {"rptStockMinimo", "Productos con Stock igual o por debajo del Stock Minimo", "Stock,Fecha,Inventario,Minimo"},
                          {"TITULO", "LISTAS/CATALOGO", "Listado,Catalogo,Precios,Productos,Costos"},
                          {"rptListaArticulos", "Lista de Artículos", "Listado,Catalogo,Precios,Productos"},
                          {"rptListaCosto", "Listado de Costos", "Listado,Catalogo,Precios,Productos,Costo"},
                          {"rptCatalogoPrecio", "Catálogo de Artículos", "Listado,Catalogo,Precios,Productos"},
                          {"TITULO", "TRANSFERENCIAS", "Transferencias,Depositos"},
                          {"rptTransferencias", "Transferencias entre Depositos", "Transferencias,Depositos"}}

        ' {"rptCatalogo", "Catalogo de Productos", "Listado,Catalogo,Precios,Productos"},
        '{"rptStockValPorSuc", "Stock Valorizado Por Sucursal", "Stock,Fecha,Inventario"},

        For i = 0 To 14
            dgvListaReportes.Rows.Add()
            dgvListaReportes.Item(1, i).Value = ListaReportes(i, 0)
            dgvListaReportes.Item(0, i).Value = ListaReportes(i, 1)
            dgvListaReportes.Item(2, i).Value = ListaReportes(i, 2)
        Next
        dgvListaReportes.AllowUserToAddRows = False
    End Sub

    Private Function FormatearFiltroCombo(combo As System.Windows.Forms.ComboBox, tipo As String) As String
        Formateado = ""
        If combo.Text = "%" Then
            Formateado = "%"
        Else
            If tipo = "T" Then
                Formateado = combo.Text
            ElseIf tipo = "SV" Then
                Formateado = combo.SelectedValue
            End If
        End If
        Return Formateado
    End Function

    Private Function FormatearFiltroCheckCombo(combo As PresentationControls.CheckBoxComboBox, ByVal Dtable As DataTable, CampoCodigo As String, ReturnPorc As String) As String
        Formateado = ""
        If combo.Text = "%" And ReturnPorc = "SI" Then
            Formateado = "%"
        Else
            Formateado = calcularCodigos(Dtable, combo, CampoCodigo)
        End If
        Return Formateado
    End Function

    Private Sub cmbSucursal_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbSucursal.CheckBoxCheckedChanged
        verificarchecks(cmbSucursal, dtSucursal)
    End Sub

    Private Sub cmbSucursal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbSucursal.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbSucursal.Text = "%"
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"
        End If
    End Sub
    Private Sub cmbSucursal_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbSucursal.KeyUp
        If cmbSucursal.Text = "" And cmbSucursal.AccessibleName <> "False" Then
            cmbSucursal.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodos(cmbSucursal, dtSucursal)
        End If
    End Sub

    Private Sub marcardesmarcartodos(combo As PresentationControls.CheckBoxComboBox, dt As DataTable)
        banverifcheck = False
        If dt.Rows.Count > 0 Then
            If combo.AccessibleName <> "True" Then
                For i = 0 To combo.CheckBoxItems.Count - 1
                    combo.CheckBoxItems(i).Checked = True
                Next
                combo.AccessibleName = "True"
            Else
                For i = 0 To combo.CheckBoxItems.Count - 1
                    combo.CheckBoxItems(i).Checked = False
                Next
                combo.AccessibleName = "False"
            End If
        End If
        banverifcheck = True
    End Sub

    Private Sub verificarchecks(ByVal control As PresentationControls.CheckBoxComboBox, dt As DataTable)
        If banverifcheck = True Then
            Dim contcheck As Integer = 0
            For i = 0 To dt.Rows.Count - 1
                If control.CheckBoxItems(i).Checked = True Then
                    contcheck = contcheck + 1
                End If
            Next
            If contcheck = dt.Rows.Count Then
                control.AccessibleName = "True"
            ElseIf contcheck = 0 Then
                control.AccessibleName = "False"
            Else
                control.AccessibleName = "Parcial"
            End If
        End If
    End Sub

    Private Function calcularcmbConTexto(combo As PresentationControls.CheckBoxComboBox, Campo As String, ReturnPorcentaje As String) As String
        CodigoGral = ""
        Dim contchk As Integer = 0
        If combo.Text = "%" And ReturnPorcentaje = "SI" Then
            CodigoGral = "%"
        Else
            For i = 0 To combo.Items.Count - 1
                If combo.CheckBoxItems(i).Checked = True Then
                    contchk = contchk + 1
                    If contchk = 1 Then
                        CodigoGral = "(" + Campo + " = '" + combo.CheckBoxItems(i).Text + "'"
                    Else
                        CodigoGral = CodigoGral + " OR " + Campo + " = '" + combo.CheckBoxItems(i).Text + "'"
                    End If
                End If
            Next
            If CodigoGral <> "" Then
                CodigoGral = CodigoGral + ")"
            End If
        End If
        Return CodigoGral
    End Function

    Private Function calcularCodigos(ByVal Dtable As DataTable, combo As PresentationControls.CheckBoxComboBox, CampoCodigo As String) As String
        CodigoGral = ""
        Dim dr As DataRow
        For i = 0 To combo.Items.Count - 1
            If combo.CheckBoxItems(i).Checked = True Then
                dr = Dtable.Rows(i) ' Los ItemsIndex Coinciden
                CodigoGral = CodigoGral + dr("" & CampoCodigo & "").ToString + ","
            End If
        Next
        If CodigoGral <> "" Then
            CodigoGral = Mid(CodigoGral, 1, CodigoGral.Length - 1)
        End If
        Return CodigoGral
    End Function

    Private Sub btnFiltros_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltros.Click
        If pnlFiltros.Visible = True Then
            pnlFiltros.Visible = False
        Else
            pnlFiltros.Visible = True
        End If
    End Sub

    Private Sub pbxCerrarFiltros_Click(sender As System.Object, e As System.EventArgs) Handles pbxCerrarFiltros.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub chbxCodProducto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbxCodProducto.CheckedChanged
        If chbxCodProducto.Checked = True Then
            tbxcodProd.BringToFront()
            tbxcodProd.Focus()
        Else
            tbxcodProd.SendToBack()
            tbxcodProd.Text = ""
        End If
    End Sub

    Private Sub BtnAsteriscoProducto_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsteriscoProducto.Click
        Buscador = "Producto"
        If cmbProducto.Text = "%" Then
            BuscarProductoTextBox.Text = ""
        Else
            BuscarProductoTextBox.Text = cmbProducto.Text
        End If
        If chbxCodProducto.Checked = True Then
            chbxCodProducto.Checked = False
        End If
        UltraPopupControlContainer1.PopupControl = ProductosGroupBox
        UltraPopupControlContainer1.Show()

        BuscarProductoTextBox.Focus()
        BuscarProductoTextBox.SelectionStart = BuscarProductoTextBox.TextLength
    End Sub
    Private Sub pbxRangoProd_Click(sender As System.Object, e As System.EventArgs) Handles pbxRangoProd.Click
        If chbxCodProducto.Checked = True Then
            chbxCodProducto.Checked = False
        Else
            chbxCodProducto.Checked = True
        End If
    End Sub

    Private Sub dgvListaReportes_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvListaReportes.SelectionChanged
        InvisivilizarTodo()
        btnGenerar.Visible = True
        chbxMatricial.Visible = False
        dtpFechaDesde.Visible = True
        dtpFechaHasta.Visible = True
        lblFDesde.Text = "Desde Fecha"
        lblFDesde.Visible = True
        lblHastaF.Visible = True
        PRODUCTOSBindingSource.RemoveFilter()
        cbxCategoria.Text = "%"
        cbxLinea.Text = "%"
        cbxRubro.Text = "%"
        cmbProducto.Text = "%"
        cmbFamilia.Text = "%"

        rbEstadoTodos.Checked = True
        chbxCosto0Neg.Visible = True

        Dim rpt As Reportes.ReporteBlanco
        CrystalReportViewer.ReportSource = rpt
        If pnlFiltros.Visible = False Then
            pnlFiltros.Visible = True
        End If

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockFecha" Then
            chbxMatricial.Visible = False
            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2
            pnlDeposito.Location = Pos3
            pnlfechas.Location = Pos4
            pnlEstadoStock.Location = New Point(Pos5.X + 7, Pos5.Y)
            pnlOtrasOpciones.Location = New Point(Pos6.X + 7, Pos6.Y + 30)
            rbEstadosEsp.Checked = True
            rbAgrupFamillia.Checked = True
            chbxCosto0Neg.Visible = False

            dtpFechaHasta.Visible = False
            lblHastaF.Visible = False
            lblFDesde.Text = "Fecha"
            dtpFechaDesde.Value = Now.ToShortDateString

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            lblReporte.Text = "Stock de Productos a una Fecha Especifica"
            lblReporteDescrip.Text = "Muestra el Stock de los Productos a una Fecha Especifica"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovProducto" Then

            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2
            pnlDeposito.Location = Pos3
            pnlfechas.Location = Pos4

            cbxCategoria.Enabled = True
            cbxLinea.Enabled = False
            cbxRubro.Enabled = False

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            lblReporte.Text = "Movimiento de Productos"
            lblReporteDescrip.Text = "Muestra el total de los Movimientos de un Producto en un rango de Fechas"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovDetProducto" Then

            pnlProducto.Location = Pos1
            pnlDeposito.Location = Pos2
            pnlfechas.Location = Pos3

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            lblReporte.Text = "Movimiento Detallado de Productos"
            lblReporteDescrip.Text = "Muestra el detalle de Movimientos de Productos en un rango de Fechas agrupados por Fecha"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovDetFifo" Then

            pnlProducto.Location = Pos1
            cmbProducto.SelectedItem = 1
            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"


            lblReporte.Text = "Movimiento Detallado de Productos"
            lblReporteDescrip.Text = "Muestra el detalle del Calculo del Metodo FIFO"
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockActual" Then

            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2
            pnlDeposito.Location = Pos3
            pnlEstadoStock.Location = New Point(Pos5.X + 7, Pos4.Y)

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            lblReporte.Text = "Stock de Producto/ Inventario"
            lblReporteDescrip.Text = "Muestra el Stock Actual de Productos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockMinimo" Then

            pnlDeposito.Location = Pos1

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            lblReporte.Text = "Productos con Stock igual o por debajo del Stock Minimo"
            lblReporteDescrip.Text = "Muestra los Productos que se encuentran por debajo del Stock Mínimo, su Cant. Stock Mínimo y su Stock Actual"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaArticulos" Then
            chbxMatricial.Visible = True
            pnlCategorias.Location = Pos1
            pnlOtrasOpciones.Location = Pos2

            lblReporte.Text = "Lista de Artículos"
            lblReporteDescrip.Text = "Muestra la Lista de Artículos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCatalogoPrecio" Then
            chbxMatricial.Visible = True

            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
            cbxCategoria.Text = "%" : cbxLinea.Text = "%" : cbxRubro.Text = "%"
            pnlListaPrecio.Location = Pos1
            pnlCategorias.Location = Pos2
            pnlOtrasOpciones.Location = Pos3


            lblReporte.Text = "Catálogo de Artículos"
            lblReporteDescrip.Text = "Muestra el Codigo, Descripcion, Stock y Precio de Artículos por cada Lista de Precio"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockValPorSuc" Then
            cbxCategoria.Text = "%" : cbxLinea.Text = "%" : cbxRubro.Text = "%"

            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2
            pnlDeposito.Location = Pos3
            pnlfechas.Location = Pos4
            pnlEstadoStock.Location = New Point(Pos5.X + 7, Pos5.Y)
            pnlOtrasOpciones.Location = New Point(Pos6.X + 7, Pos6.Y + 30)
            rbEstadosEsp.Checked = True
            rbAgrupFamillia.Checked = True

            dtpFechaHasta.Visible = False
            lblHastaF.Visible = False
            lblFDesde.Text = "Fecha"

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            lblReporte.Text = "Stock Valorizado Por Sucursal"
            lblReporteDescrip.Text = ""

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockValAgrup" Then

            cbxCategoria.Text = "%" : cbxLinea.Text = "%" : cbxRubro.Text = "%"

            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2
            pnlDeposito.Location = Pos3
            pnlfechas.Location = Pos4
            pnlEstadoStock.Location = New Point(Pos5.X + 7, Pos5.Y)
            pnlOtrasOpciones.Location = New Point(Pos6.X + 7, Pos6.Y + 30)
            rbEstadosEsp.Checked = True
            rbAgrupFamillia.Checked = True

            dtpFechaHasta.Visible = False
            lblHastaF.Visible = False
            lblFDesde.Text = "Fecha"
            dtpFechaDesde.Value = Now.ToShortDateString

            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If
            cmbSucursal.Text = "%"

            lblReporte.Text = "Stock Valorizado Global"
            lblReporteDescrip.Text = ""

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCatalogo" Then

            pnlCategorias.Location = Pos1
            pnlDeposito.Location = Pos2


            If cmbSucursal.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbSucursal, dtSucursal)
            End If

            cmbSucursal.Text = "%"
            cbxCategoria.Text = "%" : cbxLinea.Text = "%" : cbxRubro.Text = "%"

            lblReporte.Text = "Catálogo de Productos"
            lblReporteDescrip.Text = ""

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptTransferencias" Then
            chbxMatricial.Visible = True

            pnlProducto.Location = Pos1
            pnlTransferencias.Location = Pos2
            pnlfechas.Location = Pos3

            lblReporte.Text = "Transferencias entre Depósitos"
            lblReporteDescrip.Text = "Muestra las transferencias hechas entre depósitos"

        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaCosto" Then
            pnlCategorias.Location = Pos1
            pnlProducto.Location = Pos2

            cbxCategoria.Text = "%" : cbxLinea.Text = "%" : cbxRubro.Text = "%"
            cmbProducto.Text = "%"

            lblReporte.Text = "Lista de Costos"
            lblReporteDescrip.Text = "Muestra el Costo FIFO de los Productos"

        Else
            pnlSinFiltro.Location = Pos1
            lblReporte.Text = ""
            lblReporteDescrip.Text = ""
            btnGenerar.Visible = False
        End If
    End Sub

    Private Sub verificarvacioscombo(ByVal control As System.Windows.Forms.ComboBox)
        If Trim(control.Text) = "" Then
            control.Text = "%"
        End If
    End Sub
    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        CrystalReportViewer.ShowPageNavigateButtons = True
        CrystalReportViewer.DisplayStatusBar = True
        CrystalReportViewer.DisplayToolbar = True
        Dim desde As String = dtpFechaDesde.Value
        Dim hasta As String = dtpFechaHasta.Value
        FechaDesde = desde & " 00:00:00"
        FechaHasta = hasta & " 23:59:00"
        verificarvacioscombo(cmbSucursal)
        verificarvacioscombo(cmbProducto)
        Filtrar = False
        verificarvacioscombo(cbxCategoria)
        verificarvacioscombo(cbxLinea)
        verificarvacioscombo(cbxRubro)
        Filtrar = True

        If pnlEstadoStock.Location <> PosInvisible Then
            If rbEstadosEsp.Checked = True Then
                If chbxConStock.Checked = False And chbxStockNeg.Checked = False And chbxStock0.Checked = False Then
                    MessageBox.Show("Debe marcar alguna opcion de Estado o de lo contrario marcar Todos")
                    Exit Sub
                End If
            End If
        End If

        Me.Cursor = Cursors.AppStarting

        If dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockActual" Then
            ReporteStockProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCategorias" Then
            ReporteCategorias()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockMinimo" Then
            ReporteStockMinimo()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovDetProducto" Then
            ReporteMovDetallado()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovDetFifo" Then
            ReporteMovFifo()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptMovProducto" Then
            ReporteMovProducto()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockValAgrup" Then
            ReporteStockValAgrupado()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockValPorSuc" Then
            ReporteStockValPorSucursal()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCatalogo" Then
            ReporteCatalogo()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptTransferencias" Then
            ReporteTransferencias()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaArticulos" Then
            ReporteListaProductos()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptCatalogoPrecio" Then
            ReporteCatalogoPrecio()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptStockFecha" Then
            rptStockFecha()
        ElseIf dgvListaReportes.CurrentRow.Cells("REFERENCIA").Value = "rptListaCosto" Then
            rptListadoCosto()
        End If

        Me.Cursor = Cursors.Default
        pnlFiltros.Visible = False

    End Sub

    Private Sub InvisivilizarTodo()
        pnlCategorias.Location = PosInvisible
        pnlDeposito.Location = PosInvisible
        pnlfechas.Location = PosInvisible
        pnlProducto.Location = PosInvisible
        pnlSinFiltro.Location = PosInvisible
        pnlTransferencias.Location = PosInvisible
        pnlListaPrecio.Location = PosInvisible
        pnlOtrasOpciones.Location = PosInvisible
        pnlEstadoStock.Location = PosInvisible
    End Sub

    Private Sub cbxCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxCategoria.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbxCategoria.Text = "%"
        End If
        cbxLinea.Select()
    End Sub

    Private Sub cmbDepOrigen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbDepOrigen.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbDepOrigen.Text = "%"
        End If
        cmbDepDestino.Select()
    End Sub

    Private Sub cmbDepDestino_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbDepDestino.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbDepDestino.Text = "%"
        End If
    End Sub

    Private Sub cmbProducto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbProducto.Text = "%"
        End If
    End Sub

    Private Sub cbxLinea_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxLinea.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbxLinea.Text = "%"
        End If
        cbxRubro.Select()
    End Sub

    Private Sub cbxRubro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbxRubro.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbxRubro.Text = "%"
        End If
        cmbProducto.Select()
    End Sub

    Private Sub cbxRubro_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxRubro.SelectedIndexChanged
        'Dim rubro As String = cbxRubro.Text
        Dim CODLINEA As String = cbxLinea.Text
        Me.PRODUCTOSBindingSource.Filter = "DESLINEA like '" & CODLINEA & "' AND DESRUBRO like '" & cbxRubro.Text & "'"
    End Sub

    Private Sub cbxCategoria_TextChanged(sender As Object, e As System.EventArgs) Handles cbxCategoria.TextChanged
        Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "DESFAMILIA", cbxLinea.Text, "DESLINEA", cbxRubro.Text, "DESRUBRO", "%", "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")
        If Trim(sqlwhere) = "" Then
            Me.PRODUCTOSTableAdapter.Fill(DsReporteProductoNW.PRODUCTOS)
            Me.PRODUCTOSBindingSource.RemoveFilter()
        Else
            Me.PRODUCTOSBindingSource.Filter = sqlwhere
            Me.LINEABindingSource.Filter = "DESFAMILIA like '" & cbxCategoria.Text & "'"
            cbxLinea_TextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub cbxLinea_TextChanged(sender As System.Object, e As System.EventArgs) Handles cbxLinea.TextChanged
        Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "DESFAMILIA", cbxLinea.Text, "DESLINEA", cbxRubro.Text, "DESRUBRO", "%", "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")
        If Trim(sqlwhere) = "" Then
            Me.PRODUCTOSTableAdapter.Fill(DsReporteProductoNW.PRODUCTOS)
            Me.PRODUCTOSBindingSource.RemoveFilter()
        Else
            Me.PRODUCTOSBindingSource.Filter = sqlwhere
            Me.RUBROBindingSource.Filter = "DESLINEA like '" & cbxLinea.Text & "'"
            cbxRubro_TextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub cbxRubro_TextChanged(sender As Object, e As System.EventArgs) Handles cbxRubro.TextChanged
        If Filtrar = True Then
            Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "DESFAMILIA", cbxLinea.Text, "DESLINEA", cbxRubro.Text, "DESRUBRO", "%", "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")
            If Trim(sqlwhere) = "" Then
                Me.PRODUCTOSTableAdapter.Fill(DsReporteProductoNW.PRODUCTOS)
                Me.PRODUCTOSBindingSource.RemoveFilter()
            Else
                Me.PRODUCTOSBindingSource.Filter = sqlwhere
            End If
        End If
    End Sub

    Function obtenerwhere(ByVal Filtro1 As String, ByVal nombrecampof1 As String, ByVal Filtro2 As String, ByVal nombrecampof2 As String, ByVal Filtro3 As String, ByVal nombrecampof3 As String, ByVal Filtro4 As String, ByVal nombrecampof4 As String, ByVal tipo1 As String, ByVal tipo2 As String, ByVal tipo3 As String, ByVal tipo4 As String, Optional ByVal filtro5 As String = "%", Optional ByVal nombrecampof5 As String = "", Optional ByVal tipo5 As String = "")

        Dim CtrlFiltro1 As String = ""
        Dim SiFiltro1 As Boolean = False
        Dim CtrlFiltro2 As String = ""
        Dim SiFiltro2 As Boolean = False
        Dim CtrlFiltro3 As String = ""
        Dim SiFiltro3 As Boolean = False
        Dim CtrlFiltro4 As String = ""
        Dim SiFiltro4 As Boolean = False
        Dim CtrlFiltro5 As String = ""
        Dim consultawhere As String

        If Filtro1 = "%" Or Filtro1 = "" Then
            SiFiltro1 = False
        Else
            If tipo1 = "Cadena Text" Then
                CtrlFiltro1 = nombrecampof1 + " = '" & Filtro1 & "'"
            ElseIf tipo1 = "Numero Text" Then
                CtrlFiltro1 = nombrecampof1 + " = " & Filtro1
            ElseIf tipo1 = "CodigoIn" Then
                CtrlFiltro1 = nombrecampof1 + " IN (" & Filtro1 & ")"
            ElseIf tipo1 = "CodigoIn NULL" Then
                CtrlFiltro1 = "(" & nombrecampof1 + " IN (" & Filtro1 & ") OR " & nombrecampof1 & " IS NULL)"
            ElseIf tipo1 = "Especial" Then
                CtrlFiltro1 = Filtro1
            End If
            SiFiltro1 = True
        End If

        If Filtro2 = "%" Or Filtro2 = "" Then
            SiFiltro2 = False
        Else
            SiFiltro2 = True
            If SiFiltro1 = False Then
                If tipo2 = "Cadena Text" Then
                    CtrlFiltro2 = nombrecampof2 + " = '" & Filtro2 & "'"
                ElseIf tipo2 = "Numero Text" Then
                    CtrlFiltro2 = nombrecampof2 + " = " & Filtro2
                ElseIf tipo2 = "CodigoIn" Then
                    CtrlFiltro2 = nombrecampof2 + " IN (" & Filtro2 & ")"
                ElseIf tipo2 = "CodigoIn NULL" Then
                    CtrlFiltro2 = "(" & nombrecampof2 + " IN (" & Filtro2 & ") OR " & nombrecampof2 & " IS NULL)"
                ElseIf tipo2 = "Especial" Then
                    CtrlFiltro2 = Filtro2
                End If
            Else
                If tipo2 = "Cadena Text" Then
                    CtrlFiltro2 = " AND " + nombrecampof2 + " = '" & Filtro2 & "'"
                ElseIf tipo2 = "Numero Text" Then
                    CtrlFiltro2 = " AND " + nombrecampof2 + " = " & Filtro2
                ElseIf tipo2 = "CodigoIn" Then
                    CtrlFiltro2 = " AND " & nombrecampof2 + " IN (" & Filtro2 & ")"
                ElseIf tipo2 = "CodigoIn NULL" Then
                    CtrlFiltro2 = " AND (" + nombrecampof2 + " IN (" & Filtro2 & ") OR " & nombrecampof2 & " IS NULL)"
                ElseIf tipo2 = "Especial" Then
                    CtrlFiltro2 = " AND " + Filtro2
                End If
            End If
        End If

        If Filtro3 = "%" Or Filtro3 = "" Then
            SiFiltro3 = False
        Else
            SiFiltro3 = True
            If SiFiltro1 = True Or SiFiltro2 = True Then
                If tipo3 = "Cadena Text" Then
                    CtrlFiltro3 = " AND " + nombrecampof3 + " = '" & Filtro3 & "'"
                ElseIf tipo3 = "Numero Text" Then
                    CtrlFiltro3 = " AND " + nombrecampof3 + " = " & Filtro3
                ElseIf tipo3 = "CodigoIn" Then
                    CtrlFiltro3 = " AND " + nombrecampof3 + " IN (" & Filtro3 & ")"
                ElseIf tipo3 = "CodigoIn NULL" Then
                    CtrlFiltro3 = " AND (" + nombrecampof3 + " IN (" & Filtro3 & ") OR " & nombrecampof3 & " IS NULL)"
                ElseIf tipo3 = "Especial" Then
                    CtrlFiltro3 = " AND " + Filtro3
                End If
            Else
                If tipo3 = "Cadena Text" Then
                    CtrlFiltro3 = nombrecampof3 + " = '" & Filtro3 & "'"
                ElseIf tipo3 = "Numero Text" Then
                    CtrlFiltro3 = nombrecampof3 + " = " & Filtro3
                ElseIf tipo3 = "CodigoIn" Then
                    CtrlFiltro3 = nombrecampof3 + " IN (" & Filtro3 & ")"
                ElseIf tipo3 = "CodigoIn NULL" Then
                    CtrlFiltro3 = "(" & nombrecampof3 + " IN (" & Filtro3 & ") OR " & nombrecampof3 & " IS NULL)"
                ElseIf tipo3 = "Especial" Then
                    CtrlFiltro3 = Filtro3
                End If
            End If
        End If


        If Filtro4 = "%" Or Filtro4 = "" Then
            SiFiltro4 = False
        Else
            SiFiltro4 = True
            If SiFiltro1 = True Or SiFiltro2 = True Or SiFiltro3 = True Then
                If tipo4 = "Cadena Text" Then
                    CtrlFiltro4 = " AND " + nombrecampof4 + " = '" & Filtro4 & "'"
                ElseIf tipo4 = "Numero Text" Then
                    CtrlFiltro4 = " AND " + nombrecampof4 + " = " & Filtro4
                ElseIf tipo4 = "CodigoIn" Then
                    CtrlFiltro4 = " AND " + nombrecampof4 + " IN (" & Filtro4 & ")"
                ElseIf tipo4 = "CodigoIn NULL" Then
                    CtrlFiltro4 = " AND (" + nombrecampof4 + " IN (" & Filtro4 & ") OR " & nombrecampof4 & " IS NULL)"
                ElseIf tipo4 = "Especial" Then
                    CtrlFiltro4 = " AND " + Filtro4
                End If
            Else
                If tipo4 = "Cadena Text" Then
                    CtrlFiltro4 = nombrecampof4 + " = '" & Filtro4 & "'"
                ElseIf tipo4 = "Numero Text" Then
                    CtrlFiltro4 = nombrecampof4 + " = " & Filtro4 & ""
                ElseIf tipo4 = "CodigoIn" Then
                    CtrlFiltro4 = nombrecampof4 + " IN (" & Filtro4 & ")"
                ElseIf tipo4 = "CodigoIn NULL" Then
                    CtrlFiltro4 = "(" & nombrecampof4 + " IN (" & Filtro4 & ") OR " & nombrecampof4 & " IS NULL)"
                ElseIf tipo4 = "Especial" Then
                    CtrlFiltro4 = Filtro4
                End If
            End If
        End If

        If filtro5 = "%" Or filtro5 = "" Then
            'Nada
        Else
            If SiFiltro1 = True Or SiFiltro2 = True Or SiFiltro3 = True Or SiFiltro4 = True Then
                If tipo5 = "Cadena Text" Then
                    CtrlFiltro5 = " AND " + nombrecampof5 + " = '" & filtro5 & "'"
                ElseIf tipo5 = "Numero Text" Then
                    CtrlFiltro5 = " AND " + nombrecampof5 + " = " & filtro5
                ElseIf tipo5 = "CodigoIn" Then
                    CtrlFiltro5 = " AND " + nombrecampof5 + " IN (" & filtro5 & ")"
                ElseIf tipo5 = "CodigoIn NULL" Then
                    CtrlFiltro5 = " AND (" + nombrecampof5 + " IN (" & filtro5 & ") OR " & nombrecampof5 & " IS NULL)"
                ElseIf tipo5 = "Especial" Then
                    CtrlFiltro5 = " AND " + filtro5
                End If
            Else
                If tipo5 = "Cadena Text" Then
                    CtrlFiltro5 = nombrecampof5 + " = '" & filtro5 & "'"
                ElseIf tipo5 = "Numero Text" Then
                    CtrlFiltro5 = nombrecampof5 + " = " & filtro5 & ""
                ElseIf tipo5 = "CodigoIn" Then
                    CtrlFiltro5 = nombrecampof5 + " IN (" & filtro5 & ")"
                ElseIf tipo5 = "CodigoIn NULL" Then
                    CtrlFiltro5 = "(" & nombrecampof5 + " IN (" & filtro5 & ") OR " & nombrecampof5 & " IS NULL)"
                ElseIf tipo5 = "Especial" Then
                    CtrlFiltro5 = filtro5
                End If
            End If
        End If

        consultawhere = CtrlFiltro1 + CtrlFiltro2 + CtrlFiltro3 + CtrlFiltro4 + CtrlFiltro5

        Return consultawhere
    End Function

    Private Sub rptStockFecha()
        Dim frm = New VerInformes

        Dim Hasta As String = dtpFechaDesde.Value
        FechaDesde = Hasta & " 00:00:00"
        FechaHasta = Hasta & " 23:59:59"
        Dim año As Integer = dtpFechaDesde.Value.Year
        'OBTENER PRIMER DIA DEL MES DE LA FECHA SELECCIONADA
        Dim primerdiadelmes As New DateTime
        primerdiadelmes = FechaDesde
        primerdiadelmes = primerdiadelmes.AddDays(-primerdiadelmes.Day + 1)

        Me.RvfistockaunafechaTableAdapter.selectcommand.CommandText = "SELECT CODCODIGO, CODIGO, DESPRODUCTO, DESFAMILIA, DESMEDIDA, STOCKFECHA, DESSUCURSAL, CODSUCURSAL, PRECIO " & _
            "FROM            (SELECT COD.CODCODIGO, COD.CODIGO, PRODUCTOS.DESPRODUCTO, FAMILIA.DESFAMILIA, UNIDADMEDIDA.DESMEDIDA, RUBRO.DESRUBRO, LINEA.DESLINEA, " & _
                                 "(SELECT   STOCK FROM STOCKHISTORICO WHERE (MONTH(FECHA) = '" & dtpFechaDesde.Value.Month & "') AND (YEAR(FECHA) = " & año & ") AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)) " & _
                         "+ ISNULL((SELECT SUM(CANTIDAD) AS Expr1 FROM MOVPRODUCTO WHERE (FECHAMOVIMIENTO >= CONVERT(DATETIME,'" & primerdiadelmes & "',103)) AND (FECHAMOVIMIENTO <= CONVERT(DATETIME,'" & FechaHasta & "',103)) AND (CODCODIGO = COD.CODCODIGO) AND  " & _
                                    "(CODDEPOSITO = SD.CODDEPOSITO)), 0) AS STOCKFECHA, SUCURSAL.DESSUCURSAL, SUCURSAL.CODSUCURSAL, COD.PRECIO " & _
        "FROM            CODIGOS AS COD INNER JOIN " & _
                         "PRODUCTOS ON COD.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                         "STOCKDEPOSITO AS SD ON COD.CODCODIGO = SD.CODCODIGO INNER JOIN " & _
                         "SUCURSAL ON SD.CODDEPOSITO = SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                         "UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN " & _
                         "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                         "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                         "LINEA ON RUBRO.CODLINEA = LINEA.CODLINEA ) AS derivedtbl_1 "

        FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "DESFAMILIA", cbxLinea.Text, "DESLINEA", cbxRubro.Text, "DESRUBRO", "%", "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

        Dim primerocontitulo As Boolean = False
        If rbEstadosEsp.Checked = True Then
            If chbxConStock.Checked = True Then
                primerocontitulo = True
                If sqlwhere = "" Then
                    sqlwhere = sqlwhere + " (STOCKFECHA > 0 "
                Else
                    sqlwhere = sqlwhere + " AND (STOCKFECHA > 0 "
                End If
            End If
            If chbxStock0.Checked = True Then
                If primerocontitulo = True Then
                    sqlwhere = sqlwhere + " OR STOCKFECHA = 0 "
                Else
                    primerocontitulo = True
                    If sqlwhere = "" Then
                        sqlwhere = sqlwhere + " (STOCKFECHA = 0 "
                    Else
                        sqlwhere = sqlwhere + " AND (STOCKFECHA = 0 "
                    End If
                End If
            End If
            If chbxStockNeg.Checked = True Then
                If primerocontitulo = True Then
                    sqlwhere = sqlwhere + " OR STOCKFECHA < 0 "
                Else
                    primerocontitulo = True
                    If sqlwhere = "" Then
                        sqlwhere = sqlwhere + "(STOCKFECHA < 0 "
                    Else
                        sqlwhere = sqlwhere + "AND (STOCKFECHA < 0 "
                    End If
                End If
            End If
        End If
        If primerocontitulo = True Then
            sqlwhere = sqlwhere + ")"
        End If

        If sqlwhere = "" Then
            If chbxCodProducto.Checked = True Then
                Me.RvfistockaunafechaTableAdapter.selectcommand.CommandText += " WHERE (CODIGO IN (SELECT item FROM dbo.fnPartir('" & tbxcodProd.Text & "' , ',') AS fnPartir_1)) AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY DESPRODUCTO, CODIGO"
            ElseIf cmbProducto.Text = "%" Then
                Me.RvfistockaunafechaTableAdapter.selectcommand.CommandText += " WHERE (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY DESPRODUCTO, CODIGO"
            Else
                Me.RvfistockaunafechaTableAdapter.selectcommand.CommandText += " WHERE (CODCODIGO= " & cmbProducto.SelectedValue & ") AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY DESPRODUCTO, CODIGO"
            End If
        Else
            If chbxCodProducto.Checked = True Then
                Me.RvfistockaunafechaTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (CODIGO IN (SELECT item FROM dbo.fnPartir('" & tbxcodProd.Text & "' , ',') AS fnPartir_1)) AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY DESPRODUCTO, CODIGO"
            ElseIf cmbProducto.Text = "%" Then
                Me.RvfistockaunafechaTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY DESPRODUCTO, CODIGO"
            Else
                Me.RvfistockaunafechaTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (CODCODIGO= " & cmbProducto.SelectedValue & ") AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY DESPRODUCTO, CODIGO"
            End If
        End If
        Me.RvfistockaunafechaTableAdapter.Fill(DsRVFiltroInventario.RVFISTOCKAUNAFECHA)

        If rbAgrupFamillia.Checked = False Then
            Dim rpt As New Reportes.InvStockProductoFechaEsp
            Dim rptmat As New Reportes.InvStockProductoFechaEsp

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVFiltroInventario])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtFecha", dtpFechaDesde.Text)

                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rptmat
                    CrystalReportViewer.Refresh()
                End If
            Else
                rpt.SetDataSource([DsRVFiltroInventario])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtFecha", dtpFechaDesde.Text)

                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            End If
        Else
            Dim rpt As New Reportes.InvStockProductoFechaEspAFam
            Dim rptmat As New Reportes.InvStockProductoFechaEspAFam

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRVFiltroInventario])
                rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rptmat.SetParameterValue("pmtFecha", dtpFechaDesde.Text)

                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rptmat
                    CrystalReportViewer.Refresh()
                End If
            Else
                rpt.SetDataSource([DsRVFiltroInventario])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtFecha", dtpFechaDesde.Text)

                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            End If
        End If

    End Sub
    Sub ReporteCatalogoPrecio()
        If rbAgrupFamillia.Checked = True Then
            Try
                Dim frm = New VerInformes
                Dim rpt As New Reportes.InvCatalogoPrecioConAgrup
                Dim rptmat As New Reportes.InvCatalogoPrecioMATR

                RICatalogoPrecioTableAdapter.selectcommand.CommandText = "SELECT CODIGOS.CODIGO, PRODUCTOS.DESPRODUCTO + ' ' + RTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + RTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) " & _
                             "AS PRODUCTO, FAMILIA.DESFAMILIA, LINEA.DESLINEA, RUBRO.DESRUBRO, SUCURSAL.DESSUCURSAL, STOCKDEPOSITO.STOCKACTUAL, " & _
                             "PRECIO.CODTIPOCLIENTE, PRECIO.PRECIOVENTA, TIPOCLIENTE.DESTIPOCLIENTE, CODIGOS.CODCODIGO " & _
                "FROM            PRODUCTOS LEFT OUTER JOIN " & _
                             "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                             "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                             "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                             "LINEA ON LINEA.CODLINEA = RUBRO.CODLINEA LEFT OUTER JOIN " & _
                             "STOCKDEPOSITO ON CODIGOS.CODCODIGO = STOCKDEPOSITO.CODCODIGO LEFT OUTER JOIN " & _
                             "SUCURSAL ON STOCKDEPOSITO.CODDEPOSITO = SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                             "PRECIO ON PRECIO.CODPRODUCTO = PRODUCTOS.CODPRODUCTO LEFT OUTER JOIN " & _
                             "TIPOCLIENTE ON TIPOCLIENTE.CODTIPOCLIENTE = PRECIO.CODTIPOCLIENTE"

                FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
                Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "FAMILIA.DESFAMILIA", cbxLinea.Text, "LINEA.DESLINEA", cbxRubro.Text, "RUBRO.DESRUBRO", FormatF1, "TIPOCLIENTE.CODTIPOCLIENTE", "Cadena Text", "Cadena Text", "Cadena Text", "CodigoIn")

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RICatalogoPrecioTableAdapter.selectcommand.CommandText += " ORDER BY PRODUCTO "
                Else
                    Me.RICatalogoPrecioTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY PRODUCTO"
                End If

                RICatalogoPrecioTableAdapter.Fill(DsRIProductos.RICatalogoPrecio)
                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRIProductos])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                    If chbxNuevaVent.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rptmat
                        CrystalReportViewer.Refresh()
                    End If
                Else
                    rpt.SetDataSource([DsRIProductos])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                    If chbxNuevaVent.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rpt
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rpt
                        CrystalReportViewer.Refresh()
                    End If
                End If

            Catch ex As Exception

            End Try
        Else
            Try
                Dim frm = New VerInformes
                Dim rpt As New Reportes.InvCatalogoPrecio
                Dim rptmat As New Reportes.InvCatalogoPrecioMATR

                RICatalogoPrecioTableAdapter.selectcommand.CommandText = "SELECT CODIGOS.CODIGO, PRODUCTOS.DESPRODUCTO + ' ' + RTRIM(ISNULL(CODIGOS.DESCODIGO1, '')) + ' ' + RTRIM(ISNULL(CODIGOS.DESCODIGO2, '')) " & _
                             "AS PRODUCTO, FAMILIA.DESFAMILIA, LINEA.DESLINEA, RUBRO.DESRUBRO, SUCURSAL.DESSUCURSAL, STOCKDEPOSITO.STOCKACTUAL, " & _
                             "PRECIO.CODTIPOCLIENTE, PRECIO.PRECIOVENTA, TIPOCLIENTE.DESTIPOCLIENTE, CODIGOS.CODCODIGO " & _
                "FROM            PRODUCTOS LEFT OUTER JOIN " & _
                             "CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                             "FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                             "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                             "LINEA ON LINEA.CODLINEA = RUBRO.CODLINEA LEFT OUTER JOIN " & _
                             "STOCKDEPOSITO ON CODIGOS.CODCODIGO = STOCKDEPOSITO.CODCODIGO LEFT OUTER JOIN " & _
                             "SUCURSAL ON STOCKDEPOSITO.CODDEPOSITO = SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                             "PRECIO ON PRECIO.CODPRODUCTO = PRODUCTOS.CODPRODUCTO LEFT OUTER JOIN " & _
                             "TIPOCLIENTE ON TIPOCLIENTE.CODTIPOCLIENTE = PRECIO.CODTIPOCLIENTE"

                FormatF1 = FormatearFiltroCheckCombo(cmbListaPrecio, dtListaPrecio, "CODTIPOCLIENTE", "NO")
                Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "FAMILIA.DESFAMILIA", cbxLinea.Text, "LINEA.DESLINEA", cbxRubro.Text, "RUBRO.DESRUBRO", FormatF1, "TIPOCLIENTE.CODTIPOCLIENTE", "Cadena Text", "Cadena Text", "Cadena Text", "CodigoIn")

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RICatalogoPrecioTableAdapter.selectcommand.CommandText += " ORDER BY PRODUCTO "
                Else
                    Me.RICatalogoPrecioTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY PRODUCTO"
                End If

                RICatalogoPrecioTableAdapter.Fill(DsRIProductos.RICatalogoPrecio)
                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRIProductos])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                    If chbxNuevaVent.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rptmat
                        CrystalReportViewer.Refresh()
                    End If
                Else
                    rpt.SetDataSource([DsRIProductos])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                    If chbxNuevaVent.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rpt
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rpt
                        CrystalReportViewer.Refresh()
                    End If
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub rptListadoCosto()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.InvListaCosto

        RiListadoCostoTableAdapter.selectcommand.CommandText = "SELECT TOP (100) PERCENT dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CODIGOS.PRECIO AS COSTO, " & _
                                                                "dbo.FAMILIA.DESFAMILIA, dbo.LINEA.DESLINEA, dbo.RUBRO.DESRUBRO FROM dbo.CODIGOS INNER JOIN " & _
                                                                "dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO LEFT OUTER JOIN " & _
                                                                "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN  " & _
                                                                "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                                                                "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA"

        Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "FAMILIA.DESFAMILIA", cbxLinea.Text, "LINEA.DESLINEA", cbxRubro.Text, "RUBRO.DESRUBRO", cmbProducto.Text, "PRODUCTOS.DESPRODUCTO", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

        If Trim(sqlwhere) = "" Then ' se eligieron todos %
            Me.RiListadoCostoTableAdapter.selectcommand.CommandText += " ORDER BY FAMILIA.DESFAMILIA "
        Else
            Me.RiListadoCostoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY FAMILIA.DESFAMILIA"
        End If

        RiListadoCostoTableAdapter.Fill(DsRVFiltroInventario.RIListadoCosto)

        rpt.SetDataSource([DsRVFiltroInventario])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If
    End Sub

    Sub ReporteListaProductos()
        If rbAgrupFamillia.Checked = True Then
            Try
                Dim frm = New VerInformes
                Dim rpt As New Reportes.InvListaProductosConAgrup
                Dim rptmat As New Reportes.InvListaProductosMATR

                RiListaProductoTableAdapter.selectcommand.CommandText = "SELECT TOP (100) PERCENT dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO + ' ' + RTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) " & _
                             "+ ' ' + RTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')) AS PRODUCTO, dbo.FAMILIA.DESFAMILIA, dbo.LINEA.DESLINEA, dbo.RUBRO.DESRUBRO, " & _
                             "CASE PRODUCTOS.SERVICIO WHEN 0 THEN 'PRODUCTO' WHEN 1 THEN 'SERVICIO' WHEN 2 THEN 'PROD. PRODUCIDO' WHEN 3 THEN 'MATERIA PRIMA' END AS TIPO " & _
                "FROM            dbo.PRODUCTOS INNER JOIN " & _
                             "dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                             "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                             "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                             "dbo.LINEA ON dbo.RUBRO.CODLINEA = dbo.LINEA.CODLINEA "

                Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "FAMILIA.DESFAMILIA", cbxLinea.Text, "LINEA.DESLINEA", cbxRubro.Text, "RUBRO.DESRUBRO", "%", "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RiListaProductoTableAdapter.selectcommand.CommandText += " ORDER BY PRODUCTO "
                Else
                    Me.RiListaProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY PRODUCTO "
                End If

                RiListaProductoTableAdapter.Fill(DsRIProductos.RIListaProducto)
                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRIProductos])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                    If chbxNuevaVent.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rptmat
                        CrystalReportViewer.Refresh()
                    End If
                Else
                    rpt.SetDataSource([DsRIProductos])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                    If chbxNuevaVent.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rpt
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rpt
                        CrystalReportViewer.Refresh()
                    End If
                End If

            Catch ex As Exception

            End Try
        Else
            Try
                Dim frm = New VerInformes
                Dim rpt As New Reportes.InvListaProductos
                Dim rptmat As New Reportes.InvListaProductosMATR

                RiListaProductoTableAdapter.selectcommand.CommandText = "SELECT TOP (100) PERCENT dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO + ' ' + RTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) " & _
                             "+ ' ' + RTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')) AS PRODUCTO, dbo.FAMILIA.DESFAMILIA, dbo.LINEA.DESLINEA, dbo.RUBRO.DESRUBRO, " & _
                             "CASE PRODUCTOS.SERVICIO WHEN 0 THEN 'PRODUCTO' WHEN 1 THEN 'SERVICIO' WHEN 2 THEN 'PROD. PRODUCIDO' WHEN 3 THEN 'MATERIA PRIMA' END AS TIPO " & _
                "FROM            dbo.PRODUCTOS INNER JOIN " & _
                             "dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                             "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA LEFT OUTER JOIN " & _
                             "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                             "dbo.LINEA ON dbo.RUBRO.CODLINEA = dbo.LINEA.CODLINEA "

                Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "FAMILIA.DESFAMILIA", cbxLinea.Text, "LINEA.DESLINEA", cbxRubro.Text, "RUBRO.DESRUBRO", "%", "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

                If Trim(sqlwhere) = "" Then ' se eligieron todos %
                    Me.RiListaProductoTableAdapter.selectcommand.CommandText += " ORDER BY PRODUCTO "
                Else
                    Me.RiListaProductoTableAdapter.selectcommand.CommandText += " WHERE " + sqlwhere + " ORDER BY PRODUCTO "
                End If

                RiListaProductoTableAdapter.Fill(DsRIProductos.RIListaProducto)
                If chbxMatricial.Checked = True Then
                    rptmat.SetDataSource([DsRIProductos])
                    rptmat.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                    If chbxNuevaVent.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rptmat
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rptmat
                        CrystalReportViewer.Refresh()
                    End If
                Else
                    rpt.SetDataSource([DsRIProductos])
                    rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

                    If chbxNuevaVent.Checked = True Then
                        frm.CrystalReportViewer1.ReportSource = rpt
                        frm.WindowState = FormWindowState.Maximized
                        frm.Show()
                    Else
                        CrystalReportViewer.ReportSource = rpt
                        CrystalReportViewer.Refresh()
                    End If
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub ReporteTransferencias()
        Try

            Dim frm = New VerInformes
            Dim rpt As New Reportes.InvTransferencias
            Dim rptmat As New Reportes.InvTransferenciasMATR

            If cmbProducto.Text = "%" Then
                RiTransferenciaTableAdapter.Fill(DsRITransferencias.RITransferencia, cmbDepOrigen.Text, cmbDepDestino.Text, FechaDesde, FechaHasta)
            Else
                RiTransferenciaTableAdapter.FillByProd(DsRITransferencias.RITransferencia, cmbDepOrigen.Text, cmbDepDestino.Text, FechaDesde, FechaHasta, cmbProducto.SelectedValue)
            End If

            If chbxMatricial.Checked = True Then
                rptmat.SetDataSource([DsRITransferencias])
                rptmat.SetParameterValue("pmtNroMov", "")
                rptmat.SetParameterValue("pmtObs", "")
                rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
                rptmat.SetParameterValue("pmtRangoFecha", "Fecha Desde: " + dtpFechaDesde.Text + "   " + "Fecha Hasta: " + dtpFechaHasta.Text)
                frm.CrystalReportViewer1.ReportSource = rptmat
            Else
                rpt.SetDataSource([DsRITransferencias])
                rpt.SetParameterValue("pmtNroMov", "")
                rpt.SetParameterValue("pmtObs", "")
                rpt.SetParameterValue("pmtEmpresa", EmpDescripcion)
                rpt.SetParameterValue("pmtRangoFecha", "Fecha Desde: " + dtpFechaDesde.Text + "   " + "Fecha Hasta: " + dtpFechaHasta.Text)
                frm.CrystalReportViewer1.ReportSource = rpt
            End If

            If chbxMatricial.Checked = True Then
                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rptmat
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rptmat
                    CrystalReportViewer.Refresh()
                End If
            Else
                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub ReporteCatalogo()

        Dim cstringCosto As String = ""
        Dim cstringStockActual As String = ""
        Dim cstringPrecio As String = ""
        Dim categ As String = ""
        Dim Sicateg As Boolean = True
        Dim Linea As String = ""
        Dim SiLinea As Boolean = True
        Dim Rubro As String = ""
        Dim Sucursal As String = ""
        Dim SiSuc As Boolean = True

        FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        If cmbSucursal.Text = "%" Then
            SiSuc = False
        Else

            Sucursal = "SUCURSAL.CODSUCURSAL IN(" & FormatF1 & ")"
        End If

        If cbxCategoria.Text = "%" Or Trim(cbxCategoria.Text) = "" Then
            Sicateg = False
        Else
            If SiSuc = False Then
                categ = " FAMILIA.DESFAMILIA = '" & cbxCategoria.Text & "'"
            Else
                categ = " AND FAMILIA.DESFAMILIA = '" & cbxCategoria.Text & "'"
            End If
        End If

        If cbxLinea.Text = "%" Or Trim(cbxLinea.Text) = "" Then

            SiLinea = False
        Else
            If SiSuc = True Then
                Linea = " AND LINEA.DESLINEA = '" & cbxLinea.Text & "'"
            ElseIf Sicateg = False Then
                Linea = " AND LINEA.DESLINEA = '" & cbxLinea.Text & "'"
            Else
                Linea = " AND LINEA.DESLINEA = '" & cbxLinea.Text & "'"
            End If
        End If


        If cbxRubro.Text = "%" Or Trim(cbxRubro.Text) = "" Then
            'Nada
        Else
            If SiSuc = True Then
                Rubro = " AND RUBRO.DESRUBRO = '" & cbxRubro.Text & "'"
            ElseIf Sicateg = False And SiLinea = False Then
                Rubro = " RUBRO.DESRUBRO = '" & cbxRubro.Text & "'"
            Else
                Rubro = " AND RUBRO.DESRUBRO = '" & cbxRubro.Text & "'"
            End If
        End If


        If Sucursal = "" Then
            If categ = "" And Linea = "" And Rubro = "" Then
                Me.RiCostoPromedioTableAdapter.selectcommand.CommandText = "SELECT        DESFAMILIA, DESLINEA, DESRUBRO, DESMEDIDA, CODIGO, DESSUCURSAL, PRODUCTO, CASE WHEN SUM(Cantidad) IS NULL THEN 0 ELSE SUM(Cantidad)  " & _
                         " END AS Cantidad, CASE WHEN SUM(TotalUni) IS NULL THEN 0 ELSE SUM(TotalUni) END AS TotalUni " & _
                 "FROM            (SELECT        FAMILIA.DESFAMILIA, LINEA.DESLINEA, RUBRO.DESRUBRO, UNIDADMEDIDA.DESMEDIDA, CODIGOS.CODIGO, SUCURSAL.DESSUCURSAL, " & _
                                                  "  RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1) AS PRODUCTO, COMPRASDETALLE.CANTIDADCOMPRA AS Cantidad, " & _
                                                   " COMPRASDETALLE.CANTIDADCOMPRA * COMPRASDETALLE.COSTOUNITARIO AS TotalUni " & _
                       "   FROM                       PRODUCTOS INNER JOIN " & _
                                                  "  CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                                                   "  SUCURSAL LEFT OUTER JOIN " & _
                                                  "   COMPRAS LEFT OUTER JOIN " & _
                                                  "  COMPRASDETALLE ON COMPRAS.CODCOMPRA = COMPRASDETALLE.CODCOMPRA ON SUCURSAL.CODSUCURSAL = COMPRAS.CODSUCURSAL ON" & _
                                                   " CODIGOS.CODCODIGO = COMPRASDETALLE.CODCODIGO LEFT OUTER JOIN" & _
                                                   " UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN" & _
                                                   " RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN" & _
                                                   " LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA LEFT OUTER JOIN" & _
                                                    " FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA" & _
                                                   " WHERE  (PRODUCTOS.SERVICIO <> 1) AND (PRODUCTOS.ESTADO = 0)" & _
                                                  " GROUP BY CODIGOS.CODIGO, RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1), SUCURSAL.DESSUCURSAL, RUBRO.DESRUBRO," & _
                                                    "FAMILIA.DESFAMILIA, LINEA.DESLINEA, UNIDADMEDIDA.DESMEDIDA, COMPRASDETALLE.CANTIDADCOMPRA, COMPRASDETALLE.COSTOUNITARIO) AS Subconsulta " & _
                          "GROUP BY CODIGO, PRODUCTO, DESSUCURSAL, DESRUBRO, DESFAMILIA, DESLINEA, DESMEDIDA"

            Else
                Me.RiCostoPromedioTableAdapter.selectcommand.CommandText = "SELECT        DESFAMILIA, DESLINEA, DESRUBRO, DESMEDIDA, CODIGO, DESSUCURSAL, PRODUCTO, CASE WHEN SUM(Cantidad) IS NULL THEN 0 ELSE SUM(Cantidad)  " & _
                         " END AS Cantidad, CASE WHEN SUM(TotalUni) IS NULL THEN 0 ELSE SUM(TotalUni) END AS TotalUni " & _
    "FROM            (SELECT        FAMILIA.DESFAMILIA, LINEA.DESLINEA, RUBRO.DESRUBRO, UNIDADMEDIDA.DESMEDIDA, CODIGOS.CODIGO, SUCURSAL.DESSUCURSAL, " & _
                                                  "  RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1) AS PRODUCTO, COMPRASDETALLE.CANTIDADCOMPRA AS Cantidad, " & _
                                                   " COMPRASDETALLE.CANTIDADCOMPRA * COMPRASDETALLE.COSTOUNITARIO AS TotalUni " & _
                       "   FROM                       PRODUCTOS INNER JOIN " & _
                                                  "  CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                                                   "  SUCURSAL LEFT OUTER JOIN " & _
                                                  "   COMPRAS LEFT OUTER JOIN " & _
                                                  "  COMPRASDETALLE ON COMPRAS.CODCOMPRA = COMPRASDETALLE.CODCOMPRA ON SUCURSAL.CODSUCURSAL = COMPRAS.CODSUCURSAL ON" & _
                                                   " CODIGOS.CODCODIGO = COMPRASDETALLE.CODCODIGO LEFT OUTER JOIN" & _
                                                   " UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN" & _
                                                   " RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN" & _
                                                   " LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA LEFT OUTER JOIN" & _
                                                     " FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA" & _
                                                   " WHERE   " + categ + Linea + Rubro + " AND (PRODUCTOS.SERVICIO <> 1) AND (PRODUCTOS.ESTADO = 0)" & _
                                                  " GROUP BY CODIGOS.CODIGO, RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1), SUCURSAL.DESSUCURSAL, RUBRO.DESRUBRO," & _
                                                    "FAMILIA.DESFAMILIA, LINEA.DESLINEA, UNIDADMEDIDA.DESMEDIDA, COMPRASDETALLE.CANTIDADCOMPRA, COMPRASDETALLE.COSTOUNITARIO) AS Subconsulta " & _
                          "GROUP BY CODIGO, PRODUCTO, DESSUCURSAL, DESRUBRO, DESFAMILIA, DESLINEA, DESMEDIDA"
            End If
        Else
            If categ = "" And Linea = "" And Rubro = "" Then
                Me.RiCostoPromedioTableAdapter.selectcommand.CommandText = "SELECT        DESFAMILIA, DESLINEA, DESRUBRO, DESMEDIDA, CODIGO, DESSUCURSAL, PRODUCTO, CASE WHEN SUM(Cantidad) IS NULL THEN 0 ELSE SUM(Cantidad)  " & _
                         " END AS Cantidad, CASE WHEN SUM(TotalUni) IS NULL THEN 0 ELSE SUM(TotalUni) END AS TotalUni " & _
    "FROM            (SELECT        FAMILIA.DESFAMILIA, LINEA.DESLINEA, RUBRO.DESRUBRO, UNIDADMEDIDA.DESMEDIDA, CODIGOS.CODIGO, SUCURSAL.DESSUCURSAL, " & _
                                                  "  RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1) AS PRODUCTO, COMPRASDETALLE.CANTIDADCOMPRA AS Cantidad, " & _
                                                   " COMPRASDETALLE.CANTIDADCOMPRA * COMPRASDETALLE.COSTOUNITARIO AS TotalUni " & _
                       "   FROM                       PRODUCTOS INNER JOIN " & _
                                                  "  CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                                                   "  SUCURSAL LEFT OUTER JOIN " & _
                                                  "   COMPRAS LEFT OUTER JOIN " & _
                                                  "  COMPRASDETALLE ON COMPRAS.CODCOMPRA = COMPRASDETALLE.CODCOMPRA ON SUCURSAL.CODSUCURSAL = COMPRAS.CODSUCURSAL ON" & _
                                                   " CODIGOS.CODCODIGO = COMPRASDETALLE.CODCODIGO LEFT OUTER JOIN" & _
                                                   " UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN" & _
                                                   " RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN" & _
                                                   " LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA LEFT OUTER JOIN" & _
                                                    " FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA" & _
                                                   " WHERE " + Sucursal + categ + Linea + Rubro + " AND (PRODUCTOS.SERVICIO <> 1) AND (PRODUCTOS.ESTADO = 0)" & _
                                                  " GROUP BY CODIGOS.CODIGO, RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1), SUCURSAL.DESSUCURSAL, RUBRO.DESRUBRO," & _
                                                    "FAMILIA.DESFAMILIA, LINEA.DESLINEA, UNIDADMEDIDA.DESMEDIDA, COMPRASDETALLE.CANTIDADCOMPRA, COMPRASDETALLE.COSTOUNITARIO)  AS Subconsulta " & _
                          "GROUP BY CODIGO, PRODUCTO, DESSUCURSAL, DESRUBRO, DESFAMILIA, DESLINEA, DESMEDIDA"
            Else

                Me.RiCostoPromedioTableAdapter.selectcommand.CommandText = "SELECT        DESFAMILIA, DESLINEA, DESRUBRO, DESMEDIDA, CODIGO, DESSUCURSAL, PRODUCTO, CASE WHEN SUM(Cantidad) IS NULL THEN 0 ELSE SUM(Cantidad)  " & _
                         " END AS Cantidad, CASE WHEN SUM(TotalUni) IS NULL THEN 0 ELSE SUM(TotalUni) END AS TotalUni " & _
    "FROM            (SELECT        FAMILIA.DESFAMILIA, LINEA.DESLINEA, RUBRO.DESRUBRO, UNIDADMEDIDA.DESMEDIDA, CODIGOS.CODIGO, SUCURSAL.DESSUCURSAL, " & _
                                      "  RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1) AS PRODUCTO, COMPRASDETALLE.CANTIDADCOMPRA AS Cantidad, " & _
                                       " COMPRASDETALLE.CANTIDADCOMPRA * COMPRASDETALLE.COSTOUNITARIO AS TotalUni " & _
           "   FROM                       PRODUCTOS INNER JOIN " & _
                                      "  CODIGOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                                       "  SUCURSAL LEFT OUTER JOIN " & _
                                      "   COMPRAS LEFT OUTER JOIN " & _
                                      "  COMPRASDETALLE ON COMPRAS.CODCOMPRA = COMPRASDETALLE.CODCOMPRA ON SUCURSAL.CODSUCURSAL = COMPRAS.CODSUCURSAL ON" & _
                                       " CODIGOS.CODCODIGO = COMPRASDETALLE.CODCODIGO LEFT OUTER JOIN" & _
                                       " UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN" & _
                                       " RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN" & _
                                       " LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA LEFT OUTER JOIN" & _
                                        " FAMILIA ON PRODUCTOS.CODFAMILIA = FAMILIA.CODFAMILIA" & _
                                       " WHERE   " + Sucursal + categ + Linea + Rubro + " AND (PRODUCTOS.SERVICIO <> 1) AND (PRODUCTOS.ESTADO = 0)" & _
                                      " GROUP BY CODIGOS.CODIGO, RTRIM(PRODUCTOS.DESPRODUCTO) + ' ' + LTRIM(CODIGOS.DESCODIGO1), SUCURSAL.DESSUCURSAL, RUBRO.DESRUBRO," & _
                                        "FAMILIA.DESFAMILIA, LINEA.DESLINEA, UNIDADMEDIDA.DESMEDIDA, COMPRASDETALLE.CANTIDADCOMPRA, COMPRASDETALLE.COSTOUNITARIO)  AS Subconsulta " & _
                          "GROUP BY CODIGO, PRODUCTO, DESSUCURSAL, DESRUBRO, DESFAMILIA, DESLINEA, DESMEDIDA"
            End If
        End If




        Me.RiCostoPromedioTableAdapter.Fill(Me.DsRVFiltroInventario.RICostoPromedio)



        Me.RiStockDepositoTableAdapter.Fill(Me.DsRVFiltroInventario.RIStockDeposito)
        Me.RiPrecioTableAdapter.Fill(Me.DsRVFiltroInventario.RIPrecio)



        Dim frm = New VerInformes
        If cmbSucursal.Text = "%" Then
            Dim rpt As New Reportes.InvCatalogoNW
            rpt.SetDataSource(DsRVFiltroInventario)
            frm.CrystalReportViewer1.ReportSource = rpt

            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        Else
            Dim rpt As New Reportes.InvCatalogoNWSXSuc
            rpt.SetDataSource(DsRVFiltroInventario)
            frm.CrystalReportViewer1.ReportSource = rpt
            If chbxNuevaVent.Checked = True Then
                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            Else
                CrystalReportViewer.ReportSource = rpt
                CrystalReportViewer.Refresh()
            End If
        End If


    End Sub

    Sub ReporteStockValAgrupado()
        Try
            Dim Hasta As String = dtpFechaDesde.Value
            FechaDesde = Hasta & " 00:00:00"
            FechaHasta = Hasta & " 23:59:59"
            Dim año As Integer = dtpFechaDesde.Value.Year
            'OBTENER PRIMER DIA DEL MES DE LA FECHA SELECCIONADA
            Dim primerdiadelmes As New DateTime
            primerdiadelmes = FechaDesde
            primerdiadelmes = primerdiadelmes.AddDays(-primerdiadelmes.Day + 1)

            FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
            FormatF2 = FormatearFiltroCheckCombo(cmbFamilia, dtFamilia, "CODFAMILIA", "NO")
            'Me.RvfistockaunafechaTableAdapter.FillByListaProd(Me.DsRVFiltroInventario.RVFISTOCKAUNAFECHA, dtpFechaDesde.Value.Month, año, primerdiadelmes, FechaHasta, tbxcodProd.Text, FormatF1)

            If chbxCosto0Neg.Checked = True Then

                Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText = "SELECT CODFAMILIA, DESFAMILIA, DESLINEA,PRODUCTO, CODIGO, CODCODIGO, AVG(PRECIO) AS PRECIO, SUM(STOCKFECHA) AS STOCKFECHA, CASE WHEN SUM(STOCKFECHA)< 0 THEN 0 ELSE (CASE WHEN ISNULL (AVG(FIFO) * SUM(STOCKFECHA),0) = 0 THEN 0 ELSE AVG(FIFO) * SUM(STOCKFECHA) END) END  AS VALOR, CASE WHEN FIFO <> 0 THEN FIFO ELSE 0 END AS COSTO " & _
                "FROM (SELECT dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,dbo.LINEA.DESLINEA, PRODUCTOS.DESPRODUCTO + ISNULL(COD.DESCODIGO1, '') + ISNULL(COD.DESCODIGO2, '') AS PRODUCTO, COD.CODIGO, COD.CODCODIGO, COD.PRECIO, ISNULL " & _
                                                        "((SELECT top (1) STOCK FROM STOCKHISTORICO WHERE (MONTH(FECHA) = '" & dtpFechaDesde.Value.Month & "') AND (YEAR(FECHA) = " & año & ") AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)) + ISNULL " & _
                                                        "((SELECT SUM(CANTIDAD) AS Expr1 FROM MOVPRODUCTO " & _
                                                            "WHERE (FECHAMOVIMIENTO >= CONVERT(DATETIME,'" & primerdiadelmes & "',103)) AND (FECHAMOVIMIENTO <= CONVERT(DATETIME,'" & FechaHasta & "',103)) AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)), 0), 0) AS STOCKFECHA, " & _
                                                            "(SELECT dbo.fnFifoAFecha(CONVERT(DATETIME,'" & FechaDesde & "', 103), CONVERT(DATETIME,'" & FechaHasta & "', 103), COD.CODCODIGO, SD.CODDEPOSITO)) AS FIFO," & _
                "SUCURSAL.DESSUCURSAL, SUCURSAL.CODSUCURSAL " & _
                                "FROM            CODIGOS AS COD INNER JOIN " & _
                                                    "PRODUCTOS ON COD.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                                                    "STOCKDEPOSITO AS SD ON COD.CODCODIGO = SD.CODCODIGO INNER JOIN " & _
                                                    "SUCURSAL ON SD.CODDEPOSITO = SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                                                    "UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN " & _
                                                    "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                                                    "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                                                    "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA)  AS STOCK " & _
                                "WHERE (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) " & _
                                " GROUP BY CODFAMILIA, DESFAMILIA, DESLINEA, PRODUCTO, CODIGO, CODCODIGO, FIFO  "


            Else

                Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText = "SELECT CODFAMILIA, DESFAMILIA,DESLINEA, PRODUCTO, CODIGO, CODCODIGO, AVG(PRECIO) AS PRECIO, SUM(STOCKFECHA) AS STOCKFECHA, CASE WHEN ISNULL (AVG(FIFO) * SUM(STOCKFECHA),0) = 0 THEN 0 ELSE AVG(FIFO) * SUM(STOCKFECHA) END  AS VALOR, CASE WHEN FIFO <> 0 THEN FIFO ELSE 0 END AS COSTO " & _
                "FROM (SELECT TOP (100) PERCENT dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA,dbo.LINEA.DESLINEA, PRODUCTOS.DESPRODUCTO + ISNULL(COD.DESCODIGO1, '') + ISNULL(COD.DESCODIGO2, '') AS PRODUCTO, COD.CODIGO, COD.CODCODIGO, COD.PRECIO, ISNULL " & _
                                                        "((SELECT top (1) STOCK FROM STOCKHISTORICO WHERE (MONTH(FECHA) = '" & dtpFechaDesde.Value.Month & "') AND (YEAR(FECHA) = " & año & ") AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)) + ISNULL " & _
                                                        "((SELECT SUM(CANTIDAD) AS Expr1 FROM MOVPRODUCTO " & _
                                                            "WHERE (FECHAMOVIMIENTO >= CONVERT(DATETIME,'" & primerdiadelmes & "',103)) AND (FECHAMOVIMIENTO <= CONVERT(DATETIME,'" & FechaHasta & "',103)) AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)), 0), 0) AS STOCKFECHA, " & _
                                                            "(SELECT dbo.fnFifoAFecha(CONVERT(DATETIME,'" & FechaDesde & "', 103), CONVERT(DATETIME,'" & FechaHasta & "', 103), COD.CODCODIGO, SD.CODDEPOSITO)) AS FIFO," & _
                                                        "SUCURSAL.DESSUCURSAL, SUCURSAL.CODSUCURSAL " & _
                                "FROM            CODIGOS AS COD INNER JOIN " & _
                                                    "PRODUCTOS ON COD.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                                                    "STOCKDEPOSITO AS SD ON COD.CODCODIGO = SD.CODCODIGO INNER JOIN " & _
                                                    "SUCURSAL ON SD.CODDEPOSITO = SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                                                    "UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN " & _
                                                    "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                                                    "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                                                    "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA)  AS STOCK " & _
                                "WHERE (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) " & _
                                " GROUP BY CODFAMILIA, DESFAMILIA, DESLINEA,PRODUCTO, CODIGO, CODCODIGO, FIFO  "

            End If

            Dim sqlhaving As String = obtenerwhere(cmbFamilia.Text, "DESFAMILIA", cbxLinea.Text, "DESLINEA", cbxRubro.Text, "RUBRO.DESRUBRO", "%", "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

            Dim primerocontitulo As Boolean = False
            Dim sqlhaving2 As String = ""
            If rbEstadosEsp.Checked = True Then
                If sqlhaving <> "" Then
                    primerocontitulo = True
                End If

                If chbxConStock.Checked = True Then
                    If primerocontitulo = True Then
                        sqlhaving2 = sqlhaving2 + " or SUM(STOCKFECHA)>0 "
                    Else
                        primerocontitulo = True
                        sqlhaving2 = " SUM(STOCKFECHA)>0 "
                    End If
                End If
                If chbxStock0.Checked = True Then
                    If primerocontitulo = True Then
                        sqlhaving2 = sqlhaving2 + " or SUM(STOCKFECHA)=0"
                    Else
                        primerocontitulo = True
                        sqlhaving2 = " SUM(STOCKFECHA)=0 "
                    End If
                End If
                If chbxStockNeg.Checked = True Then
                    If primerocontitulo = True Then
                        sqlhaving2 = sqlhaving2 + " or SUM(STOCKFECHA)<0"
                    Else
                        primerocontitulo = True
                        sqlhaving2 = " SUM(STOCKFECHA)<0 "
                    End If
                End If
            End If

            If sqlhaving2 <> "" Then
                sqlhaving = sqlhaving + sqlhaving2
            End If

            If sqlhaving = "" Then
                If chbxCodProducto.Checked = True Then
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " HAVING (CODIGO IN (SELECT item FROM dbo.fnPartir('" & tbxcodProd.Text & "' , ',') AS fnPartir_1))  ORDER BY PRODUCTO, CODIGO"
                ElseIf cmbProducto.Text = "%" Then
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " ORDER BY PRODUCTO, CODIGO"
                Else
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " HAVING  (CODCODIGO= " & cmbProducto.SelectedValue & ") ORDER BY PRODUCTO, CODIGO"
                End If
            Else
                If chbxCodProducto.Checked = True Then
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " HAVING " & sqlhaving & " AND (CODIGO IN (SELECT item FROM dbo.fnPartir('" & tbxcodProd.Text & "' , ',') AS fnPartir_1))  ORDER BY PRODUCTO, CODIGO"
                ElseIf cmbProducto.Text = "%" Then
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " HAVING " & sqlhaving & " ORDER BY PRODUCTO, CODIGO"
                Else
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " HAVING " & sqlhaving & " AND (CODCODIGO= " & cmbProducto.SelectedValue & ") ORDER BY PRODUCTO, CODIGO"
                End If
            End If

            Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandTimeout = 100000
            Me.RiprodstockaunafechaTableAdapter.Fill(DsRIProductos.RIPRODSTOCKAUNAFECHA)

            If rbAgrupFamillia.Checked = True Then
                Dim rpt As New Reportes.InvStockValorizadoAgrupadoAFam
                rpt.SetDataSource([DsRIProductos])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtSucursal", cmbSucursal.Text)
                rpt.SetParameterValue("pmtFecha", dtpFechaDesde.Text)

                Dim frm = New VerInformes
                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.InvStockValorizadoAgrupado
                rpt.SetDataSource([DsRIProductos])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtSucursal", cmbSucursal.Text)
                rpt.SetParameterValue("pmtFecha", dtpFechaDesde.Text)
                Dim frm = New VerInformes
                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Dim informe = New Reportes.InfFifo

    End Sub

    Sub ReporteStockValPorSucursal()
        Try
            Dim Hasta As String = dtpFechaDesde.Value
            FechaDesde = Hasta & " 00:00:00"
            FechaHasta = Hasta & " 23:59:59"
            Dim año As Integer = dtpFechaDesde.Value.Year
            'OBTENER PRIMER DIA DEL MES DE LA FECHA SELECCIONADA
            Dim primerdiadelmes As New DateTime
            primerdiadelmes = FechaDesde
            primerdiadelmes = primerdiadelmes.AddDays(-primerdiadelmes.Day + 1)

            FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")

            'Me.RvfistockaunafechaTableAdapter.FillByListaProd(Me.DsRVFiltroInventario.RVFISTOCKAUNAFECHA, dtpFechaDesde.Value.Month, año, primerdiadelmes, FechaHasta, tbxcodProd.Text, FormatF1)

            If chbxCosto0Neg.Checked = True Then

                Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText = "SELECT CODFAMILIA, DESFAMILIA, PRODUCTO, CODIGO, CODCODIGO, PRECIO, STOCKFECHA, CASE WHEN STOCKFECHA< 0 THEN 0 ELSE STOCKFECHA * PRECIO END AS VALOR, CASE WHEN STOCKFECHA<0 THEN 0 ELSE PRECIO END AS COSTO, DESSUCURSAL, CODSUCURSAL " & _
                "FROM (SELECT TOP (100) PERCENT dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, PRODUCTOS.DESPRODUCTO + ISNULL(COD.DESCODIGO1, '') + ISNULL(COD.DESCODIGO2, '') AS PRODUCTO, COD.CODIGO, COD.CODCODIGO, COD.PRECIO, ISNULL " & _
                                                        "((SELECT STOCK FROM STOCKHISTORICO WHERE (MONTH(FECHA) = '" & dtpFechaDesde.Value.Month & "') AND (YEAR(FECHA) = " & año & ") AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)) + ISNULL " & _
                                                        "((SELECT SUM(CANTIDAD) AS Expr1 FROM MOVPRODUCTO " & _
                                                            "WHERE (FECHAMOVIMIENTO >= CONVERT(DATETIME,'" & primerdiadelmes & "',103)) AND (FECHAMOVIMIENTO <= CONVERT(DATETIME,'" & FechaHasta & "',103)) AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)), 0), 0) AS STOCKFECHA, " & _
                "SUCURSAL.DESSUCURSAL, SUCURSAL.CODSUCURSAL " & _
                                "FROM            CODIGOS AS COD INNER JOIN " & _
                                                    "PRODUCTOS ON COD.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                                                    "STOCKDEPOSITO AS SD ON COD.CODCODIGO = SD.CODCODIGO INNER JOIN " & _
                                                    "SUCURSAL ON SD.CODDEPOSITO = SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                                                    "UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN " & _
                                                    "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                                                    "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                                                    "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA)  AS STOCK "
            Else

                Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText = "SELECT CODFAMILIA, DESFAMILIA, PRODUCTO, CODIGO, CODCODIGO, PRECIO, STOCKFECHA, STOCKFECHA * PRECIO AS VALOR, PRECIO AS COSTO, DESSUCURSAL, CODSUCURSAL " & _
                "FROM (SELECT TOP (100) PERCENT dbo.FAMILIA.CODFAMILIA, dbo.FAMILIA.DESFAMILIA, PRODUCTOS.DESPRODUCTO + ISNULL(COD.DESCODIGO1, '') + ISNULL(COD.DESCODIGO2, '') AS PRODUCTO, COD.CODIGO, COD.CODCODIGO, COD.PRECIO, ISNULL " & _
                                                        "((SELECT STOCK FROM STOCKHISTORICO WHERE (MONTH(FECHA) = '" & dtpFechaDesde.Value.Month & "') AND (YEAR(FECHA) = " & año & ") AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)) + ISNULL " & _
                                                        "((SELECT SUM(CANTIDAD) AS Expr1 FROM MOVPRODUCTO " & _
                                                            "WHERE (FECHAMOVIMIENTO >= CONVERT(DATETIME,'" & primerdiadelmes & "',103)) AND (FECHAMOVIMIENTO <= CONVERT(DATETIME,'" & FechaHasta & "',103)) AND (CODCODIGO = COD.CODCODIGO) AND (CODDEPOSITO = SD.CODDEPOSITO)), 0), 0) AS STOCKFECHA, " & _
                "SUCURSAL.DESSUCURSAL, SUCURSAL.CODSUCURSAL " & _
                                "FROM            CODIGOS AS COD INNER JOIN " & _
                                                    "PRODUCTOS ON COD.CODPRODUCTO = PRODUCTOS.CODPRODUCTO INNER JOIN " & _
                                                    "STOCKDEPOSITO AS SD ON COD.CODCODIGO = SD.CODCODIGO INNER JOIN " & _
                                                    "SUCURSAL ON SD.CODDEPOSITO = SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                                                    "UNIDADMEDIDA ON PRODUCTOS.CODMEDIDA = UNIDADMEDIDA.CODMEDIDA LEFT OUTER JOIN " & _
                                                    "dbo.RUBRO ON dbo.PRODUCTOS.CODRUBRO = dbo.RUBRO.CODRUBRO LEFT OUTER JOIN " & _
                                                    "dbo.LINEA ON dbo.PRODUCTOS.CODLINEA = dbo.LINEA.CODLINEA LEFT OUTER JOIN " & _
                                                    "dbo.FAMILIA ON dbo.PRODUCTOS.CODFAMILIA = dbo.FAMILIA.CODFAMILIA)  AS STOCK "

            End If

            FormatF1 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
            Dim sqlwhere As String = obtenerwhere(cbxCategoria.Text, "DESFAMILIA", cbxLinea.Text, "LINEA.DESLINEA", cbxRubro.Text, "RUBRO.DESRUBRO", "%", "", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

            Dim primerocontitulo As Boolean = False
            If rbEstadosEsp.Checked = True Then
                If chbxConStock.Checked = True Then
                    primerocontitulo = True
                    If sqlwhere = "" Then
                        sqlwhere = sqlwhere + " (STOCKFECHA > 0 "
                    Else
                        sqlwhere = sqlwhere + " AND (STOCKFECHA > 0 "
                    End If
                End If
                If chbxStock0.Checked = True Then
                    If primerocontitulo = True Then
                        sqlwhere = sqlwhere + " OR STOCKFECHA = 0 "
                    Else
                        primerocontitulo = True
                        If sqlwhere = "" Then
                            sqlwhere = sqlwhere + " (STOCKFECHA = 0 "
                        Else
                            sqlwhere = sqlwhere + " AND (STOCKFECHA = 0 "
                        End If
                    End If
                End If
                If chbxStockNeg.Checked = True Then
                    If primerocontitulo = True Then
                        sqlwhere = sqlwhere + " OR STOCKFECHA < 0 "
                    Else
                        primerocontitulo = True
                        If sqlwhere = "" Then
                            sqlwhere = sqlwhere + "(STOCKFECHA < 0 "
                        Else
                            sqlwhere = sqlwhere + "AND (STOCKFECHA < 0 "
                        End If
                    End If
                End If
            End If
            If primerocontitulo = True Then
                sqlwhere = sqlwhere + ")"
            End If

            If sqlwhere = "" Then

                If chbxCodProducto.Checked = True Then
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " WHERE (COD.CODIGO IN (SELECT item FROM dbo.fnPartir('" & tbxcodProd.Text & "' , ',') AS fnPartir_1)) AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY PRODUCTO, CODIGO"
                ElseIf cmbProducto.Text = "%" Then
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " WHERE (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY PRODUCTO, CODIGO"
                Else
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " WHERE (COD.CODCODIGO= " & cmbProducto.SelectedValue & ") AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY PRODUCTO, CODIGO"
                End If
            Else
                If chbxCodProducto.Checked = True Then
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (COD.CODIGO IN (SELECT item FROM dbo.fnPartir('" & tbxcodProd.Text & "' , ',') AS fnPartir_1)) AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY PRODUCTO, CODIGO"
                ElseIf cmbProducto.Text = "%" Then
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY PRODUCTO, CODIGO"
                Else
                    Me.RiprodstockaunafechaTableAdapter.selectcommand.CommandText += " WHERE " & sqlwhere & " AND (COD.CODCODIGO= " & cmbProducto.SelectedValue & ") AND (CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) ORDER BY PRODUCTO, CODIGO"
                End If
            End If

            Me.RiprodstockaunafechaTableAdapter.Fill(DsRIProductos.RIPRODSTOCKAUNAFECHA)

            If rbAgrupFamillia.Checked = True Then
                Dim rpt As New Reportes.InvStockValorizadoPorSucursalAFam
                rpt.SetDataSource([DsRIProductos])
                'If chbxCosto0Neg.Checked = True Then
                '    rpt.SetParameterValue("pmtCosto0Neg", "SI")
                'Else
                '    rpt.SetParameterValue("pmtCosto0Neg", "NO")
                'End If
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtSucursal", cmbSucursal.Text)
                rpt.SetParameterValue("pmtFecha", dtpFechaDesde.Text)
                Dim frm = New VerInformes
                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            Else
                Dim rpt As New Reportes.InvStockValorizadoPorSucursal
                rpt.SetDataSource([DsRIProductos])
                rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
                rpt.SetParameterValue("pmtSucursal", cmbSucursal.Text)
                rpt.SetParameterValue("pmtFecha", dtpFechaDesde.Text)
                'If chbxCosto0Neg.Checked = True Then
                '    rpt.SetParameterValue("pmtCosto0Neg", "SI")
                'Else
                '    rpt.SetParameterValue("pmtCosto0Neg", "NO")
                'End If
                Dim frm = New VerInformes
                If chbxNuevaVent.Checked = True Then
                    frm.CrystalReportViewer1.ReportSource = rpt
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                Else
                    CrystalReportViewer.ReportSource = rpt
                    CrystalReportViewer.Refresh()
                End If
            End If

        Catch ex As Exception

        End Try
        'Dim informe = New Reportes.InfFifo

    End Sub

    Sub ReporteMovProducto()
        Dim informe = New Reportes.InvMtoProducto
        Dim frm = New VerInformes

        Dim informes As New EnviaInformes.EnviaInformes
        ' Dim DesSuc As String
        Dim codsucursal As String
        codsucursal = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        Dim DesFamilia As String
        DesFamilia = cbxCategoria.Text
        'DesFamilia = "'" & DesFamilia & "'"
        'If cmbSucursal.Text = "%" Then
        '    DesSuc = "Todos"
        'Else
        '    If cmbSucursal.SelectedValue = Nothing Or cmbSucursal.Text = "" Then
        '        MessageBox.Show("Seleccione la Sucursal o presione F12 para todas las sucursales", "POSEXPRESS")
        '        cmbSucursal.Focus()
        '        Exit Sub
        '    End If
        '    DesSuc = cmbSucursal.Text
        'End If



        Dim dtMov As New DataTable
        Dim dtStockA As New DataTable
        Dim dtStockH As New DataTable
        Dim drInf As DataRow
        Dim drMov As DataRow
        Dim drStock As DataRow
        Dim i As Integer
        Dim ds As New EnviaInformes.DsInformes
        Dim StockFecha As Decimal = 0

        Dim primerdiadelmes As New DateTime
        primerdiadelmes = FechaDesde
        primerdiadelmes = primerdiadelmes.AddDays(-primerdiadelmes.Day + 1)
        Dim diaanterior As Date
        If primerdiadelmes <> dtpFechaDesde.Value.Date Then
            diaanterior = Me.dtpFechaDesde.Value.Date
            diaanterior = diaanterior.AddDays(-1)
        Else
            diaanterior = primerdiadelmes
        End If

        Dim Hasta As String = diaanterior.ToShortDateString
        FechaDesde = Hasta & " 00:00:00"
        FechaHasta = Hasta & " 23:59:59"
        Dim año As Integer = diaanterior.Year
        If cmbProducto.Text = "" Then
            cmbProducto.Text = "%"
        End If

        Dim codcodigo As Integer = CInt(cmbProducto.SelectedValue)
        Try
            If chbxCodProducto.Checked = True Then
                If cmbSucursal.Text = "%" Then
                    Me.RimovproductoxrangofechaTableAdapter.FillByLPSinSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, tbxcodProd.Text)
                    dtMov = Me.RimovproductoxrangofechaTableAdapter.GetDataByLPSinSuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, tbxcodProd.Text)
                Else
                    Me.RimovproductoxrangofechaTableAdapter.FillByLPSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codsucursal, tbxcodProd.Text)
                    dtMov = Me.RimovproductoxrangofechaTableAdapter.GetDataByLPSuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codsucursal, tbxcodProd.Text)
                End If
            Else
                If cmbProducto.Text = "%" Then
                    If cmbSucursal.Text = "%" Then
                        If cbxCategoria.Text = "%" Then
                            Me.RimovproductoxrangofechaTableAdapter.FillByTPSinSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value)
                            dtMov = Me.RimovproductoxrangofechaTableAdapter.GetDataByTPSinSuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value)
                        Else

                            Me.RimovproductoxrangofechaTableAdapter.FillByFSinPyS(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, dtpFechaDesde.Value, dtpFechaHasta.Value, DesFamilia)
                            dtMov = DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA

                            Me.RvfistockaunafechaTableAdapter.FillBy1Prod(Me.DsRVFiltroInventario.RVFISTOCKAUNAFECHA, codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)
                            dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)

                            If dtStockA.Rows.Count = 0 Then
                                StockFecha = 0
                            Else
                                drStock = dtStockA.Rows.Item(0)
                                If IsDBNull(drStock("STOCKFECHA")) Or CStr(drStock("STOCKFECHA")) = "" Then
                                    StockFecha = 0
                                Else
                                    StockFecha = drStock("STOCKFECHA")
                                End If
                            End If
                        End If
                    Else

                        If cbxCategoria.Text = "%" Then
                            Me.RimovproductoxrangofechaTableAdapter.FillByTPSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codsucursal)
                            dtMov = DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA
                        Else

                            Me.RimovproductoxrangofechaTableAdapter.FillByFSsinP(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, dtpFechaHasta.Value, DesFamilia, codsucursal)
                            dtMov = DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA

                            Me.RvfistockaunafechaTableAdapter.FillBy1Prod(Me.DsRVFiltroInventario.RVFISTOCKAUNAFECHA, codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)
                            dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)

                            If dtStockA.Rows.Count = 0 Then
                                StockFecha = 0
                            Else
                                drStock = dtStockA.Rows.Item(0)
                                If IsDBNull(drStock("STOCKFECHA")) Or CStr(drStock("STOCKFECHA")) = "" Then
                                    StockFecha = 0
                                Else
                                    StockFecha = drStock("STOCKFECHA")
                                End If
                            End If
                        End If


                    End If
                Else
                    If cmbSucursal.Text = "%" Then
                        If cbxCategoria.Text = "%" Then
                            Me.RimovproductoxrangofechaTableAdapter.FillBy1PSinSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codcodigo)
                            dtMov = DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA
                        Else
                            Me.RimovproductoxrangofechaTableAdapter.FillByFPSinS(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codcodigo, DesFamilia)
                            dtMov = DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA

                            Me.RvfistockaunafechaTableAdapter.FillBy1Prod(Me.DsRVFiltroInventario.RVFISTOCKAUNAFECHA, codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)
                            dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)

                            If dtStockA.Rows.Count = 0 Then
                                StockFecha = 0
                            Else
                                drStock = dtStockA.Rows.Item(0)
                                If IsDBNull(drStock("STOCKFECHA")) Then
                                    StockFecha = 0
                                Else
                                    If CStr(drStock("STOCKFECHA")) = "" Then
                                        StockFecha = 0
                                    Else
                                        StockFecha = drStock("STOCKFECHA")
                                    End If
                                End If
                            End If
                        End If

                    Else
                        If cbxCategoria.Text = "%" Then
                            Me.RimovproductoxrangofechaTableAdapter.Fill1PSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codcodigo, codsucursal)
                            dtMov = DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA
                        Else
                            Me.RimovproductoxrangofechaTableAdapter.FillByFPS(Me.DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codcodigo, DesFamilia, codsucursal)
                            dtMov = DsRVFiltroInventario.RIMOVPRODUCTOXRANGOFECHA

                            Me.RvfistockaunafechaTableAdapter.FillBy1Prod(Me.DsRVFiltroInventario.RVFISTOCKAUNAFECHA, codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)
                            dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)

                            If dtStockA.Rows.Count = 0 Then
                                StockFecha = 0
                            Else
                                drStock = dtStockA.Rows.Item(0)
                                If IsDBNull(drStock("STOCKFECHA")) Then
                                    StockFecha = 0
                                Else
                                    If CStr(drStock("STOCKFECHA")) = "" Then
                                        StockFecha = 0
                                    Else
                                        StockFecha = drStock("STOCKFECHA")
                                    End If
                                End If
                            End If
                        End If

                    End If
                End If

            End If


            Dim RangoFecha As String = "De " + Me.dtpFechaDesde.Value + "    Hasta  " + Me.dtpFechaHasta.Value


            Dim SucActual As Decimal = 0


            If dtMov.Rows.Count <> 0 Then
                For i = 0 To dtMov.Rows.Count - 1
                    drMov = dtMov.Rows.Item(i)
                    drInf = ds.Tables("Detalle").NewRow()
                    drInf.Item("Campo8") = drMov("CODIGO")
                    drInf.Item("Campo1") = drMov("PRODUCTO")
                    drInf.Item("Campo2") = drMov("DESFAMILIA")
                    drInf.Item("Campo3") = drMov("DESLINEA")
                    drInf.Item("Numero1") = drMov("STOCKINICIAL")
                    drInf.Item("Numero2") = drMov("COMPRA")
                    drInf.Item("Numero3") = drMov("DEVOLUCIONCLIENTE")
                    drInf.Item("Numero4") = drMov("TRANSFERENCIAENTRADA")
                    drInf.Item("Numero5") = drMov("AJUSTEENTRADA")
                    drInf.Item("Numero6") = drMov("VENTA")
                    drInf.Item("Numero7") = drMov("SALPROD")
                    drInf.Item("Numero8") = drMov("TRANSFERENCIASALIDA")
                    drInf.Item("Numero9") = drMov("AJUSTESALIDA")
                    drInf.Item("Numero10") = drMov("CODCODIGO")
                    drInf.Item("Numero14") = drMov("ANULVTA")
                    drInf.Item("Numero15") = drMov("ENTRPROD")
                    drInf.Item("Numero16") = drMov("DEVCOMP")
                    drInf.Item("Numero17") = drMov("ANULCOMP")
                    drInf.Item("Numero18") = drMov("ANULDEVCOMP")
                    drInf.Item("Numero19") = drMov("ANULDEVVTA")

                    If i = 0 Then
                        dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(drMov("CODCODIGO"), diaanterior.Month, año, primerdiadelmes, diaanterior, drMov("CODSUCURSAL"))
                        If dtStockA.Rows.Count = 0 Then
                            drInf.Item("Numero11") = 0
                        Else
                            drStock = dtStockA.Rows.Item(0)
                            drInf.Item("Numero11") = drStock("STOCKFECHA")
                        End If
                        SucActual = drMov("CODSUCURSAL")
                    Else
                        If drMov("CODSUCURSAL") <> SucActual Then
                            dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(drMov("CODCODIGO"), diaanterior.Month, año, primerdiadelmes, diaanterior, drMov("CODSUCURSAL"))
                            If dtStockA.Rows.Count = 0 Then
                                drInf.Item("Numero11") = 0
                            Else
                                drStock = dtStockA.Rows.Item(0)
                                drInf.Item("Numero11") = drStock("STOCKFECHA")
                            End If
                            SucActual = drMov("CODSUCURSAL")
                        Else
                            dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(drMov("CODCODIGO"), diaanterior.Month, año, primerdiadelmes, diaanterior, drMov("CODSUCURSAL"))
                            If dtStockA.Rows.Count = 0 Then
                                drInf.Item("Numero11") = 0
                            Else
                                drStock = dtStockA.Rows.Item(0)
                                drInf.Item("Numero11") = drStock("STOCKFECHA")
                            End If
                        End If
                    End If


                    drInf.Item("Numero13") = drMov("CODRUBRO")
                    drInf.Item("Campo5") = EmpDescripcion
                    drInf.Item("Campo6") = drMov("DESSUCURSAL")
                    drInf.Item("Campo4") = RangoFecha
                    ds.Tables("Detalle").Rows.Add(drInf)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If primerdiadelmes = dtpFechaDesde.Value.Date Then
            diaanterior = Me.dtpFechaDesde.Value.Date
            diaanterior = diaanterior.AddDays(-1)
        End If

        informe.SetDataSource(ds)
        informe.SetParameterValue("DiaAnterior", diaanterior.ToString)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = informe
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = informe
            CrystalReportViewer.Refresh()
        End If

    End Sub

    Sub ReporteMovDetallado()
        Dim informe = New Reportes.InvMtoDetProducto
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        'Dim DesSuc As String
        Dim codsucursal As String
        codsucursal = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")

        'If cmbSucursal.Text = "%" Then
        '    DesSuc = "Todos"
        'Else
        '    If codsucursal = Nothing Or cmbSucursal.Text = "" Then
        '        MessageBox.Show("Seleccione la Sucursal o presione F12 para todas las sucursales", "POSEXPRESS")
        '        cmbSucursal.Focus()
        '        Exit Sub
        '    End If
        '    DesSuc = cmbSucursal.Text
        'End If

        Dim dtMov As New DataTable
        Dim dtStockA As New DataTable
        Dim dtStockH As New DataTable
        Dim drInf As DataRow
        Dim drMov As DataRow
        Dim drStock As DataRow
        Dim i As Integer
        Dim ds As New EnviaInformes.DsInformes
        Dim StockFecha As Decimal = 0
        Dim primerdiadelmes, primerdiadelmesAux As New DateTime
        primerdiadelmes = FechaDesde
        primerdiadelmes = primerdiadelmes.AddDays(-primerdiadelmes.Day + 1)
        Dim diaanterior As Date
        If primerdiadelmes <> dtpFechaDesde.Value.Date Then
            diaanterior = Me.dtpFechaDesde.Value.Date
            diaanterior = diaanterior.AddDays(-1)
        Else
            diaanterior = primerdiadelmes
        End If



        Dim Hasta As String = diaanterior.ToShortDateString
        FechaDesde = Hasta & " 00:00:00"
        FechaHasta = Hasta & " 23:59:59"

        Dim año As Integer = diaanterior.Year

        Dim codcodigo As Integer = CInt(cmbProducto.SelectedValue)
        Try
            If chbxCodProducto.Checked = True Then
                If cmbSucursal.Text = "%" Then
                    Me.RimovproductoporfechaTableAdapter.FillByLPSinSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOPORFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, tbxcodProd.Text)
                    dtMov = Me.RimovproductoporfechaTableAdapter.GetDataByLPSinSuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, tbxcodProd.Text)
                Else
                    Me.RimovproductoporfechaTableAdapter.FillByLPSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOPORFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, tbxcodProd.Text, codsucursal)
                    dtMov = Me.RimovproductoporfechaTableAdapter.GetDataByLPSuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, tbxcodProd.Text, codsucursal)
                End If
            Else
                If cmbProducto.Text = "%" Then
                    If cmbSucursal.Text = "%" Then
                        Me.RimovproductoporfechaTableAdapter.FillByTPSinSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOPORFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value)
                        dtMov = Me.RimovproductoporfechaTableAdapter.GetDataByTPSinSuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value)
                    Else

                        Me.RimovproductoporfechaTableAdapter.FillByTPSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOPORFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codsucursal)
                        dtMov = Me.RimovproductoporfechaTableAdapter.GetDataByTPSuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codsucursal)

                        Me.RvfistockaunafechaTableAdapter.FillBy1Prod(Me.DsRVFiltroInventario.RVFISTOCKAUNAFECHA, codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)
                        dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)

                        If dtStockA.Rows.Count = 0 Then
                            StockFecha = 0
                        Else
                            drStock = dtStockA.Rows.Item(0)
                            If IsDBNull(drStock("STOCKFECHA")) Then
                                StockFecha = 0
                            Else
                                If CStr(drStock("STOCKFECHA")) = "" Then
                                    StockFecha = 0
                                Else
                                    StockFecha = drStock("STOCKFECHA")
                                End If
                            End If
                        End If
                    End If
                Else
                    If cmbSucursal.Text = "%" Then
                        Me.RimovproductoporfechaTableAdapter.FillBySinSuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOPORFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codcodigo)
                        dtMov = Me.RimovproductoporfechaTableAdapter.GetDataBySinSuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codcodigo)
                    Else
                        Me.RimovproductoporfechaTableAdapter.FillBySuc(Me.DsRVFiltroInventario.RIMOVPRODUCTOPORFECHA, Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codcodigo, codsucursal)
                        dtMov = Me.RimovproductoporfechaTableAdapter.GetDataBySuc(Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value, codcodigo, codsucursal)

                        Me.RvfistockaunafechaTableAdapter.FillBy1Prod(Me.DsRVFiltroInventario.RVFISTOCKAUNAFECHA, codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)
                        dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(codcodigo, diaanterior.Month, año, primerdiadelmes, diaanterior, codsucursal)

                        If dtStockA.Rows.Count = 0 Then
                            StockFecha = 0
                        Else
                            drStock = dtStockA.Rows.Item(0)
                            If IsDBNull(drStock("STOCKFECHA")) Then
                                StockFecha = 0
                            Else
                                If CStr(drStock("STOCKFECHA")) = "" Then
                                    StockFecha = 0
                                Else
                                    StockFecha = drStock("STOCKFECHA")
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Dim RangoFecha As String = "De " + Me.dtpFechaDesde.Value + "    Hasta  " + Me.dtpFechaHasta.Value
            Dim SucActual As Decimal = 0

            If dtMov.Rows.Count <> 0 Then
                For i = 0 To dtMov.Rows.Count - 1
                    drMov = dtMov.Rows.Item(i)
                    drInf = ds.Tables("Detalle").NewRow()
                    drInf.Item("Campo8") = drMov("CODIGO")
                    drInf.Item("Campo1") = drMov("PRODUCTO")
                    drInf.Item("Campo2") = drMov("DESFAMILIA")
                    drInf.Item("Campo3") = drMov("DESLINEA")
                    drInf.Item("Numero1") = drMov("STOCKINICIAL")
                    drInf.Item("Numero2") = drMov("COMPRA")
                    drInf.Item("Numero3") = drMov("DEVOLUCIONCLIENTE")
                    drInf.Item("Numero4") = drMov("TRANSFERENCIAENTRADA")
                    drInf.Item("Numero5") = drMov("AJUSTEENTRADA")
                    drInf.Item("Numero6") = drMov("VENTA")
                    drInf.Item("Numero7") = drMov("SALPROD")
                    drInf.Item("Numero8") = drMov("TRANSFERENCIASALIDA")
                    drInf.Item("Numero9") = drMov("AJUSTESALIDA")
                    drInf.Item("Numero10") = drMov("CODCODIGO")
                    drInf.Item("Numero14") = drMov("ANULVTA")
                    drInf.Item("Numero15") = drMov("ENTRPROD")
                    drInf.Item("Numero16") = drMov("DEVCOMP")
                    drInf.Item("Numero17") = drMov("ANULCOMP")
                    drInf.Item("Numero18") = drMov("ANULDEVCOMP")
                    drInf.Item("Numero19") = drMov("ANULDEVVTA")

                    If i = 0 Then
                        dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(drMov("CODCODIGO"), diaanterior.Month, año, primerdiadelmes, diaanterior, drMov("CODSUCURSAL"))
                        If dtStockA.Rows.Count = 0 Then
                            drInf.Item("Numero11") = 0
                        Else
                            drStock = dtStockA.Rows.Item(0)
                            drInf.Item("Numero11") = drStock("STOCKFECHA")
                        End If
                        SucActual = drMov("CODSUCURSAL")
                    Else
                        If drMov("CODSUCURSAL") <> SucActual Then
                            dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(drMov("CODCODIGO"), diaanterior.Month, año, primerdiadelmes, diaanterior, drMov("CODSUCURSAL"))
                            If dtStockA.Rows.Count = 0 Then
                                drInf.Item("Numero11") = 0
                            Else
                                drStock = dtStockA.Rows.Item(0)
                                drInf.Item("Numero11") = drStock("STOCKFECHA")
                            End If
                            SucActual = drMov("CODSUCURSAL")
                        Else
                            dtStockA = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(drMov("CODCODIGO"), diaanterior.Month, año, primerdiadelmes, diaanterior, drMov("CODSUCURSAL"))
                            If dtStockA.Rows.Count = 0 Then
                                drInf.Item("Numero11") = 0
                            Else
                                drStock = dtStockA.Rows.Item(0)
                                drInf.Item("Numero11") = drStock("STOCKFECHA")
                            End If
                        End If
                    End If

                    primerdiadelmesAux = CDate(drMov("FECHAMTO"))
                    primerdiadelmesAux = primerdiadelmesAux.AddDays(-primerdiadelmesAux.Day + 1)
                    Dim stockhoy As String = drMov("FECHAMTO") & " 23:59:59"
                    dtStockH = Me.RvfistockaunafechaTableAdapter.GetDataBy1Prod(drMov("CODCODIGO"), CDate(drMov("FECHAMTO")).Month, CDate(drMov("FECHAMTO")).Year, primerdiadelmesAux, CDate(stockhoy), drMov("CODSUCURSAL"))
                    drStock = dtStockH.Rows.Item(0)

                    drInf.Item("Numero12") = drStock("STOCKFECHA")
                    drInf.Item("Numero13") = drMov("CODRUBRO")
                    drInf.Item("Fecha3") = drMov("FECHAMTO")
                    drInf.Item("Campo5") = EmpDescripcion
                    drInf.Item("Campo6") = drMov("DESSUCURSAL")
                    drInf.Item("Campo4") = RangoFecha
                    ds.Tables("Detalle").Rows.Add(drInf)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If primerdiadelmes = dtpFechaDesde.Value.Date Then
            diaanterior = Me.dtpFechaDesde.Value.Date
            diaanterior = diaanterior.AddDays(-1)
        End If

        informe.SetDataSource(ds)
        informe.SetParameterValue("DiaAnterior", diaanterior.ToString)

        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = informe
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = informe
            CrystalReportViewer.Refresh()
        End If
    End Sub
    Sub ReporteMovFifo()
        ' Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim frm = New VerInformes
        Dim rpt As New Reportes.MovCostoFifo

        If cmbProducto.Text = "%" Or Trim(cmbProducto.Text) = "" Then
            MessageBox.Show("Seleccione un solo Producto")
            cmbProducto.Focus()
            Exit Sub
        Else
            Me.ImprfifoTableAdapter.Fill(Me.DsProduccion.IMPRFIFO, cmbProducto.SelectedValue)
            Me.StockactualfifoTableAdapter.Fill(Me.DsProduccion.STOCKACTUALFIFO, cmbProducto.SelectedValue)

        End If


        rpt.SetDataSource([DsProduccion])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)
        If chbxNuevaVent.Checked = True Then

            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub


    Sub ReporteStockMinimo()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.InvStockMinimo

        Dim midsnw As New DSReporteProductoNW
        Dim codsucursal As String = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        midsnw.EnforceConstraints = False
        If cmbSucursal.Text = "%" Then
            RiStockMinimoTableAdapter.Fill(Me.DsRVFiltroInventario.RIStockMinimo)
        Else
            Me.RiStockMinimoTableAdapter.FillBySuc(Me.DsRVFiltroInventario.RIStockMinimo, codsucursal)
        End If

        rpt.SetDataSource([DsRVFiltroInventario])
        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub

    Sub ReporteCategorias()
        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim frm = New VerInformes
        Dim rpt As New Reportes.InvCategoriasNW

        txt = rpt.ReportDefinition.ReportObjects.Item("TextTodos")
        Dim codsucursal As String = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        If cmbSucursal.Text = "%" Then
            Me.RiOrdenPorCategoriaTableAdapter.Fill(DsRVFiltroInventario.RIOrdenPorCategoria)
            txt.Text = "Todos"
        Else
            Me.RiOrdenPorCategoriaTableAdapter.FillBySucursal(DsRVFiltroInventario.RIOrdenPorCategoria, codsucursal)
            txt.Text = ""
        End If

        rpt.SetDataSource([DsRVFiltroInventario])
        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub

    Sub ReporteStockProducto()
        Dim frm = New VerInformes
        Dim rpt As New Reportes.InvStockProducto
        Dim codsucursal As String = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")

        Me.RiStockActualTableAdapter1.selectcommand.CommandText = "SELECT UNIDADMEDIDA.DESMEDIDA, FAMILIA.DESFAMILIA, LINEA.DESLINEA, CODIGOS.CODIGO, STOCKDEPOSITO.STOCKACTUAL, SUCURSAL.DESSUCURSAL, " & _
                         "RUBRO.DESRUBRO, PRODUCTOS.DESPRODUCTO AS PRODUCTO, CODIGOS.CODCODIGO " & _
        "FROM            STOCKDEPOSITO INNER JOIN " & _
                         "CODIGOS ON STOCKDEPOSITO.CODCODIGO = CODIGOS.CODCODIGO LEFT OUTER JOIN " & _
                         "PRODUCTOS ON PRODUCTOS.CODPRODUCTO = CODIGOS.CODPRODUCTO LEFT OUTER JOIN " & _
                         "SUCURSAL ON STOCKDEPOSITO.CODDEPOSITO = SUCURSAL.CODSUCURSAL LEFT OUTER JOIN " & _
                         "FAMILIA ON FAMILIA.CODFAMILIA = PRODUCTOS.CODFAMILIA LEFT OUTER JOIN " & _
                         "RUBRO ON PRODUCTOS.CODRUBRO = RUBRO.CODRUBRO LEFT OUTER JOIN  " & _
                         "LINEA ON PRODUCTOS.CODLINEA = LINEA.CODLINEA AND FAMILIA.CODFAMILIA = PRODUCTOS.CODFAMILIA LEFT OUTER JOIN " & _
                         "UNIDADMEDIDA ON UNIDADMEDIDA.CODMEDIDA = PRODUCTOS.CODMEDIDA " & _
        "WHERE        (PRODUCTOS.ESTADO = 0) AND (PRODUCTOS.SERVICIO <> 1) "

        Dim sqlwhere As String = ""
        Dim codInicio As String = ""
        Dim codFin As String = ""
        Dim TestPos As Integer
        If chbxCodProducto.Checked = True Then
            TestPos = InStr(1, tbxcodProd.Text, "-", CompareMethod.Text)
            If TestPos = 0 Then 'El texto no tiene guion
                FormatF1 = "%"
            Else
                codInicio = "'" + Trim(Mid(tbxcodProd.Text, 1, TestPos - 1)) + "'"
                codFin = "'" + Trim(Mid(tbxcodProd.Text, TestPos + 1, tbxcodProd.Text.Length)) + "'"
                FormatF1 = "%"
            End If
        ElseIf cmbProducto.Text = "%" Then
            FormatF1 = "%"
        Else
            FormatF1 = cmbProducto.Text
        End If

        FormatF2 = FormatearFiltroCheckCombo(cmbSucursal, dtSucursal, "CODSUCURSAL", "NO")
        sqlwhere = obtenerwhere(cbxCategoria.Text, "FAMILIA.DESFAMILIA", cbxLinea.Text, "LINEA.DESLINEA", cbxRubro.Text, "RUBRO.DESRUBRO", FormatF1, "PRODUCTOS.DESPRODUCTO", "Cadena Text", "Cadena Text", "Cadena Text", "Cadena Text")

        '--------------------------Will.i.am----------------------------
        Dim primerocontitulo As Boolean = False
        Dim sqlhaving2 As String = ""
        If rbEstadosEsp.Checked = True Then
            If sqlwhere <> "" Then
                primerocontitulo = True
            End If

            If chbxConStock.Checked = True Then
                If primerocontitulo = True Then
                    sqlhaving2 = sqlhaving2 + " AND MAX(STOCKDEPOSITO.STOCKACTUAL)>0 "
                Else
                    primerocontitulo = True
                    sqlhaving2 = " STOCKDEPOSITO.STOCKACTUAL>0 "
                End If
            End If
            If chbxStock0.Checked = True Then
                If primerocontitulo = True Then
                    sqlhaving2 = sqlhaving2 + " AND STOCKDEPOSITO.STOCKACTUAL=0"
                Else
                    primerocontitulo = True
                    sqlhaving2 = " STOCKDEPOSITO.STOCKACTUAL=0 "
                End If
            End If
            If chbxStockNeg.Checked = True Then
                If primerocontitulo = True Then
                    sqlhaving2 = sqlhaving2 + " AND STOCKDEPOSITO.STOCKACTUAL<0"
                Else
                    primerocontitulo = True
                    sqlhaving2 = " STOCKDEPOSITO.STOCKACTUAL<0 "
                End If
            End If
        End If

        If sqlhaving2 <> "" Then
            sqlwhere = sqlwhere + sqlhaving2
        End If
        '--------------------------Will.i.am---------------------------

        If chbxCodProducto.Checked = True And TestPos = 0 Then
            If sqlwhere = "" Then
                Me.RiStockActualTableAdapter1.selectcommand.CommandText += " AND (CODIGOS.CODIGO IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) AND (SUCURSAL.CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF2 & "' , ',') AS fnPartir_1)) "
            Else
                Me.RiStockActualTableAdapter1.selectcommand.CommandText += " AND " & sqlwhere & " AND (CODIGOS.CODIGO IN (SELECT item FROM dbo.fnPartir('" & FormatF1 & "' , ',') AS fnPartir_1)) AND (SUCURSAL.CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF2 & "' , ',') AS fnPartir_1)) "
            End If
        ElseIf chbxCodProducto.Checked = True And codInicio <> "" And codFin <> "" Then
            If sqlwhere = "" Then
                Me.RiStockActualTableAdapter1.selectcommand.CommandText += " AND (CODIGOS.CODIGO BETWEEN " & codInicio & " AND " & codFin & ") AND (SUCURSAL.CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF2 & "' , ',') AS fnPartir_1)) "
            Else
                Me.RiStockActualTableAdapter1.selectcommand.CommandText += " AND " & sqlwhere & " AND (CODIGOS.CODIGO BETWEEN " & codInicio & " AND " & codFin & ") AND (SUCURSAL.CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF2 & "' , ',') AS fnPartir_1)) "
            End If
        Else
            If sqlwhere = "" Then
                Me.RiStockActualTableAdapter1.selectcommand.CommandText += " AND (SUCURSAL.CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF2 & "' , ',') AS fnPartir_1)) "
            Else
                Me.RiStockActualTableAdapter1.selectcommand.CommandText += " AND " & sqlwhere & " AND (SUCURSAL.CODSUCURSAL IN (SELECT item FROM dbo.fnPartir('" & FormatF2 & "' , ',') AS fnPartir_1)) "
            End If
        End If



        RiStockActualTableAdapter1.FillTP(DsRVFiltroInventario.RIStockActual)

        rpt.SetDataSource([DsRVFiltroInventario])
        If chbxNuevaVent.Checked = True Then
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            CrystalReportViewer.ReportSource = rpt
            CrystalReportViewer.Refresh()
        End If

    End Sub

    Private Sub cmbProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProducto.KeyPress
        Try
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If KeyAscii = 42 Then
                'BtnAsteriscoProducto_Click(Nothing, Nothing)
                '--------------------------------------- SE CAMBIO PORQUE TENIA UN ERROR NO CONTROLADO
                UltraPopupControlContainer1.PopupControl = ProductosGroupBox
                UltraPopupControlContainer1.Show()
                BuscarProductoTextBox.Focus()
                BuscarProductoTextBox.SelectionStart = BuscarProductoTextBox.TextLength
                '---------------------------------------

                e.Handled = True
            End If
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        Catch ex As Exception
        Finally

        End Try

    End Sub

    Private Sub ProductosGridView_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ProductosGridView.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Me.PRODUCTOSBindingSource.Position = Me.PRODUCTOSBindingSource.Position - 1
            cmbProducto.Focus()
            UltraPopupControlContainer1.Close()
        End If
    End Sub

    Private Sub ProductosGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosGridView.CellDoubleClick
        cmbProducto.Focus()
        UltraPopupControlContainer1.Close()
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        If BuscarProductoTextBox.Text <> "Buscar..." Then
            Me.PRODUCTOSBindingSource.Filter = "DESCRIPCION LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
        End If
    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProductosGridView.Focus()
        End If
        If KeyAscii = 27 Then
            cmbProducto.Text = ""
            cmbProducto.Focus()

            If ProductosGroupBox.Visible = True Then
                ProductosGroupBox.Visible = False
                ProductosGroupBox.SendToBack()
                cmbProducto.Focus()
            End If
        End If
    End Sub
    Private Sub cmbListaPrecio_Click(sender As Object, e As System.EventArgs) Handles cmbListaPrecio.Click
        cmbListaPrecio.Focus()
    End Sub
    Private Sub cmbListaPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbListaPrecio.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbListaPrecio.AccessibleName <> "True" Then
                marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
            End If
            cmbListaPrecio.Text = "%"
        End If
    End Sub
    Private Sub cmbListaPrecio_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbListaPrecio.KeyUp
        If cmbListaPrecio.Text = "" And cmbListaPrecio.AccessibleName <> "False" Then
            cmbListaPrecio.AccessibleName = "True" 'Forzamos para que desmarque todos
            marcardesmarcartodos(cmbListaPrecio, dtListaPrecio)
        End If
    End Sub
    Private Sub cmbListaPrecio_CheckBoxCheckedChanged(sender As Object, e As System.EventArgs) Handles cmbListaPrecio.CheckBoxCheckedChanged
        verificarchecks(cmbListaPrecio, dtListaPrecio)
    End Sub

    Private Sub FiltroReporteInventario_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim rpt As New Reportes.ReporteBlanco
        rpt.SetParameterValue("pmtReporteName", "Reportes de Inventario")
        CrystalReportViewer.ReportSource = rpt
    End Sub

    Private Sub rbEstadosEsp_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEstadosEsp.CheckedChanged
        pnlEstadosEsp.Visible = rbEstadosEsp.Checked
        chbxConStock.Checked = True
        chbxStock0.Checked = False
        chbxStockNeg.Checked = False
    End Sub

    Private Sub BuscarTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.GotFocus
        BuscarTextBox.BackColor = SystemColors.Highlight
    End Sub

    Private Sub BuscarTextBox_LostFocus(sender As Object, e As System.EventArgs) Handles BuscarTextBox.LostFocus
        BuscarTextBox.BackColor = Color.Tan
    End Sub

End Class