Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports Osuna.Utiles.Conectividad
Imports EnviaInformes

Public Class Venta_Pagare
    Private ser As BDConexión.BDConexion  'LLAMA A LA CLASE BDCONEXION
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Dim btnuevo, btmodificar As Integer
    Dim Config1, sql As String
    Dim FechaFiltro1, FechaFiltro2 As Date

    'ES LO PRIMERO QUE SE EJECUTA ANTES DEL LOAD
    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand
        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2  'ES EL ESTRING DE CONEXION
    End Sub

    Private Sub Venta_Pagare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ESTADOTableAdapter.Fill(Me.DsPagare.ESTADO)
        Me.CLIENTESTableAdapter.Fill(Me.DsPagare.CLIENTES)
        Me.MONEDATableAdapter.Fill(Me.DsPagare.MONEDA)

        CmbAño.SelectedText = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1

        rbtverPendientes_CheckedChanged(Nothing, Nothing)

        Deshabilitar()
    End Sub

    Private Sub FechaFiltro()
        Try
            Dim nromes, nroaño As Integer
            Dim fechacompleta1, fechacompleta2, mes As String
            nromes = CmbMes.SelectedIndex + 1
            nroaño = CInt(CmbAño.Text)

            If nromes = 10 Or nromes = 11 Or nromes = 12 Then
                mes = nromes.ToString
            Else
                mes = "0" + nromes.ToString

            End If

            fechacompleta1 = "01" + "/" + nromes.ToString + "/" + CmbAño.Text
            fechacompleta2 = ""
            If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
                fechacompleta2 = "31" + "/" + nromes.ToString + "/" + CmbAño.Text

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

    Private Sub NuevoPictureBox_Click(sender As Object, e As EventArgs) Handles NuevoPictureBox.Click
        Habilita()
        Limpiar()
        cbxcliente.Focus()
    End Sub

    Public Sub Habilita()
        CbxEstado.Enabled = True
        dtpFechaCreacion.Enabled = True
        dtpFechaVencimiento.Enabled = True
        tbxobservacion.Enabled = True
        tbxvalor.Enabled = True

        cbxcliente.Enabled = False
        TxtVentas.Enabled = False
        Cbxmoneda.Enabled = False
        tbxcotizacion.Enabled = False
        txtNroCuota.Enabled = False

        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Image = My.Resources.DeleteOff
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel

        dgvPagare.Enabled = False
        BuscarTextBox.Enabled = False
    End Sub

    Public Sub Deshabilitar()
        CbxEstado.Enabled = False
        dtpFechaCreacion.Enabled = False
        dtpFechaVencimiento.Enabled = False
        tbxobservacion.Enabled = False
        tbxvalor.Enabled = False

        cbxcliente.Enabled = False
        TxtVentas.Enabled = False
        Cbxmoneda.Enabled = False
        tbxcotizacion.Enabled = False
        txtNroCuota.Enabled = False

        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Image = My.Resources.Delete
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Image = My.Resources.Edit
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff

        dgvPagare.Enabled = True
        BuscarTextBox.Enabled = True
    End Sub

    Public Sub Limpiar()
        TxtVentas.Text = "" : tbxvalor.Text = "" : tbxobservacion.Text = "" : tbxcotizacion.Text = ""
    End Sub

    Private Sub ModificarPictureBox_Click(sender As Object, e As EventArgs) Handles ModificarPictureBox.Click
        Habilita()
        cbxcliente.Focus()
        ModificarPictureBox.Image = My.Resources.EditActive
    End Sub

    Private Sub GuardarPictureBox_Click(sender As Object, e As EventArgs) Handles GuardarPictureBox.Click
        Dim consulta As System.String
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction
        Dim Importe As String = tbxvalor.Text

        Importe = Funciones.Cadenas.QuitarCad(Importe, ".")
        Importe = Replace(Importe, ",", ".")

        conexion = ser.Abrir()
        consulta = "UPDATE VENTAS_PAGARE SET CodEstado = " & CbxEstado.SelectedValue & ", FechaCreacion =  CONVERT(DATETIME,'" & dtpFechaCreacion.Text & "',103), FechaVencimiento = CONVERT(DATETIME,'" & dtpFechaVencimiento.Text & "',103), " & _
                    "Observacion = '" & tbxobservacion.Text & "', Valor = " & Importe & "    WHERE Codpagare = " & dgvPagare.CurrentRow.Cells("CodpagareDataGridViewTextBoxColumn").Value

        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        Consultas.ConsultaComando(myTrans, consulta)

        Try
            myTrans.Commit()
            Deshabilitar()
        Catch ex As Exception
            myTrans.Rollback("Insertar")
            MessageBox.Show(ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        conexion.Close()

        If rbtverPendientes.Checked = True Then
            rbtverPendientes_CheckedChanged(Nothing, Nothing)
        ElseIf rbtVerImpresos.Checked = True Then
            rbtVerImpresos_CheckedChanged(Nothing, Nothing)
        End If

        dgvPagare.Refresh()
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As Object, e As EventArgs) Handles BuscarTextBox.TextChanged
        Try
            VENTASPAGAREBindingSource.Filter = "NOMBRE  LIKE '%" & BuscarTextBox.Text & "%' OR NUMVENTA LIKE '%" & BuscarTextBox.Text & "%' OR NroPagare LIKE '%" & BuscarTextBox.Text & "%'"
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub EliminarPictureBox_Click(sender As Object, e As EventArgs) Handles EliminarPictureBox.Click
        EliminaPagare()
    End Sub

    Private Sub EliminaPagare()
        If MessageBox.Show("¿Esta seguro que quiere eliminar la Pagare?", "RIA", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim transaction As SqlTransaction = Nothing
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            sql = ""
            sql = " DELETE FROM VENTAS_PAGARE " & _
                  " WHERE CodPagare= " & dgvPagare.CurrentRow.Cells("CodpagareDataGridViewTextBoxColumn").Value

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            VENTAS_PAGARETableAdapter.Fill(Me.DsPagare.VENTAS_PAGARE)

            sqlc.Close()
        Catch ex As Exception
            Try
                myTrans.Rollback("")
            Catch
            End Try
        Finally
            sqlc.Close()
        End Try
        VENTAS_PAGARETableAdapter.Fill(Me.DsPagare.VENTAS_PAGARE)
    End Sub

    Private Sub CancelarPictureBox_Click(sender As Object, e As EventArgs) Handles CancelarPictureBox.Click
        VENTASPAGAREBindingSource.CancelEdit()
        VENTAS_PAGARETableAdapter.Fill(Me.DsPagare.VENTAS_PAGARE)
        Deshabilitar()
    End Sub

    Private Sub dgvPagare_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPagare.CellContentClick
        If dgvPagare.Rows.Count <> 0 Then
            tbxvalor.Text = FormatNumber(tbxvalor.Text, 2)
        End If
    End Sub

    Private Sub pbxImprimirPagare_Click(sender As Object, e As EventArgs) Handles pbxImprimirPagare.Click
        Dim informe = New ReportesPersonalizados.Pagare
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim impresora As String = ""

        'Obtenemos el nombre de la impresora
        Dim dtTipoComp As New DataTable("TIPOCOMPROBANTE")
        Dim connString As New SqlConnection(ser.CadenaConexion)
        sql = "SELECT dbo.DETPC.IMPRESORA FROM dbo.DETPC INNER JOIN dbo.TIPOCOMPROBANTE ON dbo.DETPC.CODCOMPROBANTE = dbo.TIPOCOMPROBANTE.CODCOMPROBANTE " & _
              "WHERE (dbo.TIPOCOMPROBANTE.PAGARE = 1) AND (dbo.DETPC.ACTIVO = 1)"
        Dim SQLCmd As New SqlCommand(sql, connString)
        connString.Open()
        dr = SQLCmd.ExecuteReader(CommandBehavior.Default)
        dtTipoComp.Load(dr)
        connString.Close()

        If dtTipoComp.Rows.Count <> 0 Then
            For Each rows In dtTipoComp.Rows
                impresora = rows("IMPRESORA")
            Next

            informe.PrintOptions.PaperSource = PaperSource.Upper 'bandeja
            Me.ImpPagareTableAdapter.Fill(DsPagare.ImpPagare, dgvPagare.CurrentRow.Cells("CodpagareDataGridViewTextBoxColumn").Value)

            informe.SetDataSource([DsPagare])
            informe.SetParameterValue("ImporteLetra", Funciones.Cadenas.NumeroaLetras(tbxvalor.Text))
            informe.SetParameterValue("VencimientoLetras", Convert.ToDateTime(dtpFechaVencimiento.Value).ToString("D"))

            Try
                informe.PrintOptions.PrinterName = impresora
            Catch ex As Exception
                MessageBox.Show("Nombre de impresora invalida", "RIA")
            End Try

            informe.PrintToPrinter(1, False, 0, 0)

            'Despues de Imprimir cambiamos el estado a Impreso
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            sql = " UPDATE VENTAS_PAGARE SET CodEstado = 3 WHERE Codpagare = " & dgvPagare.CurrentRow.Cells("CodpagareDataGridViewTextBoxColumn").Value

            Try
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            sqlc.Close()

            'Para ver si con esto se limpia un poco el cache del Crystall. Nose si funciona hay que verificar. Si es posible en Guazu. Sarita =(
            informe.Close() : informe.Dispose()
            If rbtverPendientes.Checked = True Then
                rbtverPendientes_CheckedChanged(Nothing, Nothing)
            ElseIf rbtVerImpresos.Checked = True Then
                rbtVerImpresos_CheckedChanged(Nothing, Nothing)
            End If

        Else
            MessageBox.Show("Esta Pc no tiene una Impresora Asignada para la Impresion de Pagares", "RIA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        Dim s As String = ""
        doctoprint.PrinterSettings.PrinterName = PrinterName
        For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function

    Private Sub rbtverPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtverPendientes.CheckedChanged
        Me.VENTAS_PAGARETableAdapter.Fill(Me.DsPagare.VENTAS_PAGARE)
        CmbMes.Enabled = False : CmbAño.Enabled = False : BtnFiltro.Enabled = False
    End Sub

    Private Sub rbtVerImpresos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtVerImpresos.CheckedChanged
        FechaFiltro()
        Me.VENTAS_PAGARETableAdapter.FillBy(Me.DsPagare.VENTAS_PAGARE, FechaFiltro1, FechaFiltro2)
        CmbMes.Enabled = True : CmbAño.Enabled = True : BtnFiltro.Enabled = True
    End Sub

    Private Sub BtnFiltro_Click(sender As Object, e As EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Me.VENTAS_PAGARETableAdapter.FillBy(Me.DsPagare.VENTAS_PAGARE, FechaFiltro1, FechaFiltro2)
    End Sub
End Class