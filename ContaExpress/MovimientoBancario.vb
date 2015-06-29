Imports System.Data
Imports System.Data.SqlClient

Public Class MovimientoBancario

    Private cmd As SqlCommand
    Private ser As BDConexión.BDConexion
    Private myTrans As SqlTransaction
    Private sqlc As SqlConnection

    Dim w As New Funciones.Funciones

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub frmMoviBanco_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MONEDATableAdapter.Fill(Me.DsMovBancario.MONEDA)
        Me.TIPOFORMACOBROTableAdapter.Fill(Me.DsMovBancario.TIPOFORMACOBRO)
        Me.CAJATableAdapter.Fill(Me.DsMovBancario.CAJA)

        dtpDesde.Value = DateAdd(DateInterval.Month, -1, Today)
        dtpHasta.Value = DateAdd(DateInterval.Day, 1, Today)
        dtpFechaMov.Value = Now

        cbobanco.Text = "%" : cboCaja.Focus() : cboTipo.SelectedIndex = 0 : cbxMoneda.SelectedIndex = 0 : cboTipoMovi.Text = "Entrada"

        btnFiltrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click



        Try
            Dim i As Integer
            Dim entrada, salida, diferencia As Double

            If cbobanco.Text.Trim = "%" Then
                Me.MOVBANCARIOTableAdapter.FillBy(Me.DsMovBancario.MOVBANCARIO, cboMonedaFiltro.SelectedValue, dtpDesde.Text, dtpHasta.Text)
            Else
                Me.MOVBANCARIOTableAdapter.Fill(Me.DsMovBancario.MOVBANCARIO, cboMonedaFiltro.SelectedValue, cbobanco.SelectedValue, dtpDesde.Text, dtpHasta.Text)
            End If

            For i = 0 To dgvMovimiento.RowCount - 1
                If IsDBNull(dgvMovimiento.Rows(i).Cells("EntradaDataGridViewTextBoxColumn").Value) Then
                Else
                    entrada = entrada + CDec(dgvMovimiento.Rows(i).Cells("EntradaDataGridViewTextBoxColumn").Value)
                End If

                If IsDBNull(dgvMovimiento.Rows(i).Cells("SalidaDataGridViewTextBoxColumn").Value) Then
                Else
                    salida = salida + CDec(dgvMovimiento.Rows(i).Cells("SalidaDataGridViewTextBoxColumn").Value)
                End If
            Next

            diferencia = entrada - salida
            Me.txtEntradaTotal.Text = FormatNumber(entrada.ToString, 0)
            Me.txtSalidaTotal.Text = FormatNumber(salida.ToString, 0)
            Me.txtDiferencia.Text = FormatNumber(diferencia.ToString, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboCaja_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCaja.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtImporte.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporte.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxMoneda.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cboTipo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cboTipoMovi.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub txtConcepto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaMov.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbobanco_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbobanco.KeyDown
        If e.KeyCode = Keys.F12 Then
            cbobanco.Text = "%"
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click

        If txtImporte.Text.Trim = "" Or txtConcepto.Text.Trim = "" Then
            MessageBox.Show("Los campos de Monto o de Concepto estan vacios. Favor ingrezar.", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                Dim sql As String = ""
                Dim IDMovimiento As Integer = w.Maximo("id_movimiento", "movimientos")
                IDMovimiento = IDMovimiento + 1

                Dim MaxIdApertura As Integer = w.MaximoconWhere("id_apertura", "aperturas", "id_caja=" & cboCaja.SelectedValue & " AND codsucursal ", SucCodigo)

                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

                cmd.Connection = sqlc
                cmd.Transaction = myTrans

                sql = "INSERT INTO movimientos (id_movimiento,id_apertura,id_usuario,id_empresa,fecha_mto,id_moneda,id_tipo_dinero,cotizacion1,concepto,monto,codsucursal,entradasalida) " & _
                       "VALUES (" & IDMovimiento & ", " & MaxIdApertura & "," & UsuCodigo & "," & EmpCodigo & "," & "convert(datetime,'" & dtpFechaMov.Text & "',103),  " & _
                       cbxMoneda.SelectedValue & "," & cboTipo.SelectedValue & "," & txtCotizacion.Text & ",'" & txtConcepto.Text & "'," & txtImporte.Text & "," & SucCodigo & ",'" & cboTipoMovi.Text & "')"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                myTrans.Commit()

                txtConcepto.Text = "" : txtImporte.Text = ""
                MessageBox.Show("Moviemiento Guardado con Exito", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Ocurrio un Error al Insertar el Moviemiento", "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                sqlc.Close()
            End Try

        End If
    End Sub

    Private Sub cbxMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxMoneda.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtCotizacion.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub txtCotizacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCotizacion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cboTipo.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cboTipoMovi_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoMovi.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtConcepto.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxMoneda_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbxMoneda.SelectedValueChanged
        If cbxMoneda.Text <> "" Then
            txtCotizacion.Text = w.FuncionConsultaString2("TOP(1) FACTORVENTA", "COTIZACION", "CODMONEDA", cbxMoneda.SelectedValue.ToString + " ORDER BY FECHAMOVIMIENTO DESC")

            If txtCotizacion.Text <> "" Then
                txtCotizacion.Text = FormatNumber(txtCotizacion.Text, 0)
            Else
                txtCotizacion.Text = 1
            End If
        End If
    End Sub

    Private Sub dgvMovimiento_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMovimiento.CellContentClick

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class