Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class GenerarHistoricoStock
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

    Private Sub CalculoFifo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 273)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
    End Sub

    Private Sub btnCalcularAjuste_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcularAjuste.Click
        Me.Cursor = Cursors.AppStarting
        Try
            HistoricoStockTableAdapter1.Fill(DsProduccion.HistoricoStock)
            MessageBox.Show("Proceso Finalizado con Exito", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Se Produjo un Error en el Proceso de Generar el Stock Historico", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnVerificarFecha_Click(sender As System.Object, e As System.EventArgs) Handles btnVerificarFecha.Click
        Try
            dtpFecha.Text = f.FuncionConsultaStringMAX("MAX(FECHA)", "STOCKHISTORICO")
        Catch ex As Exception
            MessageBox.Show("Se Produjo un Error al Verificar la fecha del Stock Historico", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class