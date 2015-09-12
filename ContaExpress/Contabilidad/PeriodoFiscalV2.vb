Public Class PeriodoFiscalV2

    Private Property BDConexión As String

    Private Sub PeriodoFiscalV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DSPeriodoFiscalForm.PERIODOFISCALPRESUPUESTO' table. You can move, or remove it, as needed.
        Me.PERIODOFISCALPRESUPUESTOTableAdapter.Fill(Me.DSPeriodoFiscalForm.PERIODOFISCALPRESUPUESTO)
        'TODO: This line of code loads data into the 'DSPeriodoFiscalForm.periodofiscal' table. You can move, or remove it, as needed.
        Me.PeriodofiscalTableAdapter.Fill(Me.DSPeriodoFiscalForm.periodofiscal)
        'TODO: This line of code loads data into the 'DSPeriodoFiscalForm.PERIODOFISCALPRESUPUESTO' table. You can move, or remove it, as needed.
        Me.PERIODOFISCALPRESUPUESTOTableAdapter.Fill(Me.DSPeriodoFiscalForm.PERIODOFISCALPRESUPUESTO)

    End Sub

    Private Sub PERIODOFISCALPRESUPUESTOBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.PERIODOFISCALPRESUPUESTOBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DSPeriodoFiscalForm)

    End Sub

    Private Sub PeriodofiscalBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles PeriodofiscalBindingNavigatorSaveItem.Click
        Me.Validate()

        Me.PeriodofiscalBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DSPeriodoFiscalForm)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim con_period As SqlClient.SqlConnection
            Dim com_period As SqlClient.SqlCommand
            con_period = New SqlClient.SqlConnection(BDConexión)
            com_period = New SqlClient.SqlCommand()
            Dim p1 As SqlClient.SqlParameter = com_period.Parameters.Add("desejercicio", Data.SqlDbType.VarChar, 50)
            p1.Value = Me.DESEJERCICIOTextBox.Text
            Dim p2 As SqlClient.SqlParameter = com_period.Parameters.Add("fechainicio", Data.SqlDbType.DateTime)
            p2.Value = Me.FECHAINICIODateTimePicker
            Dim p3 As SqlClient.SqlParameter = com_period.Parameters.Add("fechafin", Data.SqlDbType.DateTime)
            p3.Value = Me.FECHAFINDateTimePicker

            com_period.CommandType = CommandType.StoredProcedure
            con_period.Open()
            com_period.ExecuteNonQuery()
            con_period.Close()
            MsgBox("Periodo guardado correctamente", MsgBoxStyle.Question, "Periodo")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
End Class