Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Public Class ABMOrdenarAsientoPorMes
    Private config1 As Integer
    Private f As New Funciones.Funciones

    Private Sub ABMOrdenarAsientoPorMes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PeriodofiscalTableAdapter.Fill(Me.DsPeriodosFiscales.periodofiscal)
        Me.PeriodofiscalTableAdapter.Fill(Me.DsPeriodosFiscales.periodofiscal)
        config1 = f.FuncionConsultaString("CONFIG1", "MODULO", "MODULO_ID", 13)
        CalcularMes()
    End Sub

    Private Sub btnOrdenarMes_Click(sender As Object, e As EventArgs) Handles btnOrdenarMes.Click
        Me.Cursor = Cursors.AppStarting
        Dim periodo As Integer = cmbPeriodo.SelectedValue
        Dim mes As String = "0"
        Dim año As String = cmbAño.Text

        Select Case cmbMes.Text
            Case "Enero" : mes = "01"
            Case "Febrero" : mes = "02"
            Case "Marzo" : mes = "03"
            Case "Abril" : mes = "04"
            Case "Mayo" : mes = "05"
            Case "Junio" : mes = "06"
            Case "Julio" : mes = "07"
            Case "Agosto" : mes = "08"
            Case "Septiembre" : mes = "09"
            Case "Octubre" : mes = "10"
            Case "Noviembre" : mes = "11"
            Case "Diciembre" : mes = "12"
        End Select

        Try
            Me.OrdenarAsientoMesTableAdapter.Fill(DsOrdenarAsientoPeriodo.OrdenarAsientoMes, mes, año, periodo)
            MessageBox.Show("Proceso Finalizado con Exito", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Se Produjo un Error al momento de Ordenar", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
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
End Class