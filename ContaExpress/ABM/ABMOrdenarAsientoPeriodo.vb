Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Public Class ABMOrdenarAsientoPeriodo

    Private Sub btnOrdenarPeriodo_Click(sender As Object, e As EventArgs) Handles btnOrdenarPeriodo.Click

        Dim sqlConnection1 As New SqlConnection(My.Settings.GESTIONConnectionString2)
        Dim cmd As New SqlCommand

        Me.Cursor = Cursors.AppStarting
        Dim periodo As Integer = CmbPeriodo.SelectedValue
        Dim vnumasiento As Integer
        Dim vrenum As Integer
        Dim SQLstr As String

        SQLstr = "ALTER TABLE asientos ADD flag varchar"
        cmd.CommandText = SQLstr 'Crear Columna Flag para marcar

        cmd.CommandText = "SELECT numasiento FROM asientos WHERE FECHAASIENTO between CONVERT (datetime, '2014-01-01 00:00:00', 102) and CONVERT (datetime, '2014-12-31 23:59:59', 102) ORDER by FECHAASIENTO"
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()
        Dim numasiento As String = cmd.ExecuteScalar()

        Try
            vrenum = 1
            vnumasiento = numasiento

            cmd.CommandText = "SELECT COUNT(*) FROM asientos WHERE FECHAASIENTO between CONVERT (datetime, '2014-01-01 00:00:00', 102) and CONVERT (datetime, '2014-12-31 23:59:59', 102) ORDER by FECHAASIENTO"
            Dim NumeroRegistros As Integer = CType(cmd.ExecuteScalar, Integer)
            MessageBox.Show(NumeroRegistros.ToString)

            Do While NumeroRegistros >= vrenum

                SQLstr = "UPDATE asientos SET numasiento = vrenum, flag = ´*´ WHERE FECHAASIENTO BETWEEN CONVERT (datetime, '2014-01-01 00:00:00', 102) and CONVERT (datetime, '2014-12-31 23:59:59', 102) AND Flag IS Null AND numasiento=vnumasiento ORDER by FECHAASIENTO"
                cmd.CommandText = SQLstr 'Actualizar un Numero de Asiento y coloca marca en Flag

                SQLstr = "SELECT * FROM asientos WHERE FECHAASIENTO BETWEEN CONVERT (datetime, '2014-01-01 00:00:00', 102) and CONVERT (datetime, '2014-12-31 23:59:59', 102) ORDER by FECHAASIENTO"
                cmd.CommandText = SQLstr 'Selecciona solo registros del periodo sin marca en Flag

                vnumasiento = numasiento
                vrenum = vrenum + 1
            Loop

            MessageBox.Show("Proceso Finalizado con Exito", "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Se Produjo un Error al momento de Ordenar", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        SQLstr = "ALTER TABLE asientos DROP COLUMN flag"
        cmd.CommandText = SQLstr 'Elimina Columna Flag de marcado

        Me.Cursor = Cursors.Arrow
        sqlConnection1.Close()

    End Sub

    Private Sub ABMOrdenarAsientoPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsPeriodosFiscales.periodofiscal' Puede moverla o quitarla según sea necesario.
        Me.PeriodofiscalTableAdapter.Fill(Me.DsPeriodosFiscales.periodofiscal)

    End Sub

    Private Sub CmbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPeriodo.SelectedIndexChanged

    End Sub
End Class