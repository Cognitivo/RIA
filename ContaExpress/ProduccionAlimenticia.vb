Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.ToolStripMenuItem
Imports Osuna.Utiles.Conectividad

Public Class ProduccionAlimenticia
    Private ser As New BDConexión.BDConexion
    Private cmd As New SqlCommand
    Private sqlc As New SqlConnection
    Private myTrans As SqlTransaction

    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim nuevo, editar As Integer
    Dim Cabecera, detalle As Integer
    Dim f As New Funciones.Funciones
    Dim vgProduccionCab As Integer
    Dim TempIdProduccion As Integer
    Dim permiso As Double

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion()
    End Sub

    Private Sub ProduccionAlimenticia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 204)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express")
            Me.Close()
        Else
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
            FechaHasta = fecha2 & " 23:59:00"

            Me.SUCURSALTableAdapter.Fill(Me.DsProduccion.SUCURSAL)
            Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)

            If dgvDetalleProduccion.RowCount <> 0 Then
                Me.PRODUCCIONDETPRODUCTOTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDETPRODUCTO, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
            End If

            Deshabilita()
            '   VerificarEstado()
        End If
    End Sub

    Sub Deshabilita()
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

        pnlProduccionCab.Enabled = False
        pnlCargaProduccion.Enabled = False

        BuscarTextBox.Enabled = True
    End Sub

    Sub Habilita()
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

        BuscarTextBox.Enabled = False

        pnlProduccionCab.Enabled = True
        pnlCargaProduccion.Enabled = True

        BuscarTextBox.Enabled = False
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

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 205)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear una Nueva Produccion", "Pos Express")
            Exit Sub
        End If

        Try
            ' pnlMotivoAnulacion.Visible = False
            NuevoPictureBox.Image = My.Resources.NewActive
            Habilita()
            txtDescripProduccion.Focus()

            dtpFecha.Text = Today : cmbCategoria.Text = "Materia Prima"
            nuevo = 1 : editar = 0
            FechaFiltro()

            Dim FechaDesde, FechaHasta, fecha, fecha2 As String
            Dim Concat As Date = FechaFiltro1
            Dim Concat2 As Date = FechaFiltro2

            fecha = Concat.ToString("dd/MM/yyy")
            fecha2 = Concat2.ToString("dd/MM/yyy")
            FechaDesde = fecha & " 00:00:00"
            FechaHasta = fecha2 & " 23:59:00"

            ' pnlProductos.SendToBack()

            txtPlanilla.Text = ""
            lblUsuario.Text = UsuNombre

            Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)

            PRODUCCIONCABBindingSource.AddNew()
            PRODUCCIONDETPRODUCTOTableAdapter.Fill(DsProduccion.PRODUCCIONDETPRODUCTO, 0)
            '  Me.PRODUCTOSTableAdapter.Fill(Me.DsProduccion.PRODUCTOS)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDescripProduccion_GotFocus(sender As Object, e As System.EventArgs) Handles txtDescripProduccion.GotFocus
        txtDescripProduccion.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtDescripProduccion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripProduccion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxDeposito.Focus()
        End If
    End Sub

    Private Sub cbxDeposito_GotFocus(sender As Object, e As System.EventArgs) Handles cbxDeposito.GotFocus

    End Sub

    Private Sub cbxDeposito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxDeposito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFecha.Focus()
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtCodigoProducto.Focus()
        End If
    End Sub

    Private Sub txtCodigoProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtDescripProduccion.Focus()
        End If
    End Sub

    Private Sub txtDescripProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtCantidadProducto.Focus()
        End If
    End Sub

    Private Sub txtCantidadProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtPesoProducto.Focus()
        End If
    End Sub

    Private Sub txtPesoProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesoProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregarProducto.Focus()
        End If
    End Sub

    Private Sub txtDescripProduccion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripProduccion.TextChanged

    End Sub

    Private Sub cbxDeposito_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxDeposito.SelectedIndexChanged

    End Sub
End Class