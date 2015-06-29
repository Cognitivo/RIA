Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.ToolStripMenuItem
Imports Osuna.Utiles.Conectividad

Public Class ProduccionControl
    Private ser As New BDConexión.BDConexion
    Private cmd As New SqlCommand
    Private sqlc As New SqlConnection
    Private myTrans As SqlTransaction

    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim nuevo, editar As Integer
    Dim Cabecera, detalle As Integer
    Dim f As New Funciones.Funciones
    Dim vgProduccionCab As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion()
    End Sub

    Private Sub PlanillaProduccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        nuevo = 0 : editar = 0 : Cabecera = 0 : detalle = 0

        cmbAño.Text = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1

        FechaFiltro()

        Dim FechaDesde, FechaHasta, fecha, fecha2 As String
        Dim Concat As Date = FechaFiltro1
        Dim Concat2 As Date = FechaFiltro2

        fecha = Concat.ToString("dd/MM/yyy")
        fecha2 = Concat2.ToString("dd/MM/yyy")
        FechaDesde = fecha & " 00:00:00"
        FechaHasta = fecha2 & " 23:59:59"

        Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)
        'Me.UNIDADMEDIDATableAdapter.Fill(Me.DsProduccion.UNIDADMEDIDA)
        If dgvDetalleProduccion.RowCount <> 0 Then
            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
        End If
        Deshabilita()
    End Sub

    Sub Habilita()

        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        txtCodigo.Enabled = True
        txtcantidad.Enabled = True
        'cmbCategoria.Enabled = True
        'txtCodigoItem.Enabled = True
        dtpFecha.Enabled = True
        'cbxMedida.Enabled = True
        'txtCantidadConsumo.Enabled = True
        CmbMes.Enabled = False
        cmbAño.Enabled = False
        dgvDetalleProduccion.Enabled = False
    End Sub

    Sub Deshabilita()
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Cursor = Cursors.Hand

        txtCodigo.Enabled = False
        txtcantidad.Enabled = False
        'cmbCategoria.Enabled = False
        'txtCodigoItem.Enabled = False
        dtpFecha.Enabled = False
        'cbxMedida.Enabled = False
        'txtCantidadConsumo.Enabled = False
        CmbMes.Enabled = True
        cmbAño.Enabled = True
        dgvDetalleProduccion.Enabled = True
    End Sub

    Private Sub Limpiar()
        txtPlanilla.Text = ""
        txtPlanilla.Text = ""
        txtCodigo.Text = ""
        txtProducto.Text = ""
        txtcantidad.Text = ""
        'cmbCategoria.Text = ""
        'txtDescripcion.Text = ""
        dtpFecha.Text = ""
        'txtCantidadConsumo.Text = ""
        'txtCodigoItem.Text = ""
    End Sub

    Sub FechaFiltro()
        Dim nromes, nroaño As Integer
        Dim fechacompleta1, fechacompleta2, mes As String

        nromes = CmbMes.SelectedIndex + 1
        nroaño = CInt(cmbAño.Text)

        If nromes = 10 Or nromes = 11 Or nromes = 12 Then
            mes = nromes.ToString
        Else
            mes = "0" + nromes.ToString
        End If

        fechacompleta1 = "01" + "/" + nromes.ToString + "/" + cmbAño.Text
        fechacompleta2 = ""
        If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
            fechacompleta2 = "31" + "/" + nromes.ToString + "/" + cmbAño.Text

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

    Private Sub txtCodigo_GotFocus(sender As Object, e As System.EventArgs) Handles txtCodigo.GotFocus
        txtCodigo.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtcantidad.Focus()
        ElseIf KeyAscii = 42 Then
            Cabecera = 1 : detalle = 0
            PRODUCTOSBindingSource.RemoveFilter()
            'pnlProductos.Visible = True
            'pnlProductos.BringToFront()
            'txtBuscarProducto.Focus()
        End If
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFecha.Focus()
        End If
    End Sub

    Private Sub dtpFecha_GotFocus(sender As Object, e As System.EventArgs) Handles dtpFecha.GotFocus
        dtpFecha.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub dtpFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            'cmbCategoria.Focus()
        End If
    End Sub

    Private Sub txtCodigo_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigo.LostFocus
        txtCodigo.BackColor = Color.Gainsboro

        If txtCodigo.Text <> "" Then
            txtProducto.Text = f.FuncionConsultaDosTablas("DESPRODUCTO", "PRODUCTOS", "CODIGOS", "CODPRODUCTO", "CODIGO", "" & txtCodigo.Text & "")
            CodCodigoDetalleProducto.Text = f.FuncionConsultaDecimal("CODCODIGO", "CODIGOS", "CODIGO", txtCodigo.Text)
        End If
    End Sub

    Private Sub txtcantidad_LostFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.LostFocus
        txtcantidad.BackColor = Color.Gainsboro
    End Sub

    Private Sub dtpFecha_LostFocus(sender As Object, e As System.EventArgs) Handles dtpFecha.LostFocus
        dtpFecha.BackColor = Color.Gainsboro
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Deshabilita()
        Me.PRODUCCIONCABBindingSource.CancelEdit()
        Me.PRODUCCIONDETBindingSource.CancelEdit()

        FechaFiltro()

        Dim FechaDesde, FechaHasta, fecha, fecha2 As String
        Dim Concat As Date = FechaFiltro1
        Dim Concat2 As Date = FechaFiltro2

        fecha = Concat.ToString("dd/MM/yyy")
        fecha2 = Concat2.ToString("dd/MM/yyy")
        FechaDesde = fecha & " 00:00:00"
        FechaHasta = fecha2 & " 23:59:59"

        Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)
        If dgvDetalleProduccion.RowCount <> 0 Then
            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        FechaFiltro()

        Dim FechaDesde, FechaHasta, fecha, fecha2 As String
        Dim Concat As Date = FechaFiltro1
        Dim Concat2 As Date = FechaFiltro2

        fecha = Concat.ToString("dd/MM/yyy")
        fecha2 = Concat2.ToString("dd/MM/yyy")
        FechaDesde = fecha & " 00:00:00"
        FechaHasta = fecha2 & " 23:59:59"

        Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)
        If dgvDetalleProduccion.RowCount <> 0 Then
            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
        End If
    End Sub

End Class