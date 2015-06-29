Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class AjusteHistoricoStock
    Dim permiso As Double
    Dim CodCodigo As Integer
    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private config1 As Integer
    Private f As New Funciones.Funciones
    Private sqlc As SqlConnection

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub btnCalcularAjuste_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcularAjuste.Click
        Me.Cursor = Cursors.AppStarting
        Try
            Dim mes As Integer
            If cmbTipoAjuste.Text = "Según Configuración" Then
                Me.AjustesHistoricoStockTableAdapter.Fill(Me.DsProduccion.AjustesHistoricoStock)
            Else
                Select Case cmbMes.Text
                    Case "Enero" : mes = 1
                    Case "Febrero" : mes = 2
                    Case "Marzo" : mes = 3
                    Case "Abril" : mes = 4
                    Case "Mayo" : mes = 5
                    Case "Junio" : mes = 6
                    Case "Julio" : mes = 7
                    Case "Agosto" : mes = 8
                    Case "Septiembre" : mes = 9
                    Case "Octubre" : mes = 10
                    Case "Noviembre" : mes = 11
                    Case "Diciembre" : mes = 12
                End Select
                Me.AjusteHistoricoAPedidoTableAdapter.Fill(Me.DsProduccion.AjusteHistoricoAPedido, mes, cmbAño.Text)
            End If

            MessageBox.Show("Proceso Finalizado con Exito", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Se Produjo un Error en el Proceso del Calculo", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CalculoFifo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 272)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        config1 = f.FuncionConsultaString("CONFIG1", "MODULO", "MODULO_ID", 13)
        CalcularMes()
        cmbTipoAjuste.SelectedIndex = 0

    End Sub
    Private Sub CalcularMes()
        Dim mes As Integer = 0
        Dim anho As Integer

        mes = Now.Month - config1
        anho = Now.Year
        If mes = 0 Then
            mes = 12
            anho = Now.Year - 1
        ElseIf mes < 0 Then 'Obs. no creo q se vaya elegir mas de 12 meses atras!
            mes = 12 + mes
            anho = Now.Year - 1
        End If

        cmbMes.Text = mes
        cmbAño.Text = anho

        Select Case cmbMes.Text
            Case "1" : cmbMes.Text = "Enero"
            Case "2" : cmbMes.Text = "Febrero"
            Case "3" : cmbMes.Text = "Marzo"
            Case "4" : cmbMes.Text = "Abril"
            Case "5" : cmbMes.Text = "Mayo"
            Case "6" : cmbMes.Text = "Junio"
            Case "7" : cmbMes.Text = "Julio"
            Case "8" : cmbMes.Text = "Agosto"
            Case "9" : cmbMes.Text = "Septiembre"
            Case "10" : cmbMes.Text = "Octubre"
            Case "11" : cmbMes.Text = "Noviembre"
            Case "12" : cmbMes.Text = "Diciembre"
        End Select
    End Sub
    Private Sub cmbTipoAjuste_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTipoAjuste.SelectedIndexChanged
        If cmbTipoAjuste.Text = "Según Configuración" Then
            pnlAutomatico.BringToFront()
            pnlManual.SendToBack()
            lblManual.Visible = False
            CalcularMes()
            lblSegunConfig.Text = "Por movimientos del mes de " + cmbMes.Text + " de " + cmbAño.Text
        Else
            lblManual.Visible = True
            pnlAutomatico.SendToBack()
            pnlManual.BringToFront()
        End If
    End Sub
End Class