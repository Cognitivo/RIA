Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class ABMCalculoFifo
    Dim permiso As Double
    Dim CodCodigo As Integer
    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub btnCalcularFifo_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcularFifo.Click
        Me.Cursor = Cursors.AppStarting
        Try
            Me.ScriptCostoLifoTableAdapter.Fill(Me.DsProduccion.ScriptCostoLifo)
            MessageBox.Show("Proceso Finalizado con Exito", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Se Produjo un Error en el Proceso del Calculo", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CalculoFifo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 203)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        Try
            Me.PRODUCTOSTableAdapter.Fill(Me.DsProduccion.PRODUCTOS)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtCodigoProd_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoProd.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            'Obtenemos la Descripcion del Producto y su CODCODIGO
            If TxtCodigoProd.Text <> "" Then
                Dim objCommand As New SqlCommand
                Try
                    objCommand.CommandText = "SELECT dbo.CODIGOS.CODCODIGO, dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO FROM dbo.CODIGOS INNER JOIN  " & _
                                             "dbo.PRODUCTOS ON dbo.CODIGOS.CODPRODUCTO = dbo.PRODUCTOS.CODPRODUCTO " & _
                                             "WHERE dbo.CODIGOS.CODIGO = '" & TxtCodigoProd.Text & "'"

                    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                    objCommand.Connection.Open()
                    Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                    If odrConfig.HasRows Then
                        Do While odrConfig.Read()
                            CodCodigo = odrConfig("CODCODIGO")
                            txtProducto.Text = odrConfig("DESPRODUCTO")
                        Loop
                    End If

                    odrConfig.Close()
                    objCommand.Dispose()
                Catch ex As Exception
                End Try
                btnImprimir.Focus()
            End If
        End If

        If KeyAscii = 42 Then
            UltraPopupControlContainer1.Show()
            BuscarProductoTextBox.Text = "" : BuscarProductoTextBox.Focus()
            e.Handled = True
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Me.Cursor = Cursors.AppStarting
        Dim frm = New VerInformes
        Dim rpt As New Reportes.MovCostoFifo

        Me.IMPRFIFOTableAdapter.Fill(Me.DsProduccion.IMPRFIFO, CodCodigo)
        Me.STOCKACTUALFIFOTableAdapter.Fill(Me.DsProduccion.STOCKACTUALFIFO, CodCodigo)

        rpt.SetDataSource([DsProduccion])
        rpt.SetParameterValue("pmtEmpresa", EmpNomFantasia)

        frm.CrystalReportViewer1.ReportSource = rpt
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgwProductos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwProductos.CellDoubleClick
        If dgwProductos.RowCount <> 0 Then
            txtProducto.Text = dgwProductos.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
            CodCodigo = dgwProductos.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value
            TxtCodigoProd.Text = dgwProductos.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value

            UltraPopupControlContainer1.Close()
            btnImprimir.Focus()
        End If
    End Sub

    Private Sub dgwProductos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgwProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgwProductos.RowCount <> 0 Then
                Dim i As Integer = dgwProductos.CurrentRow.Index

                txtProducto.Text = dgwProductos.Rows(i).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
                CodCodigo = dgwProductos.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
                TxtCodigoProd.Text = dgwProductos.Rows(i).Cells("CODIGODataGridViewTextBoxColumn").Value

                UltraPopupControlContainer1.Close()
                btnImprimir.Focus()
            End If
        End If
    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dgwProductos.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        PRODUCTOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%'"
    End Sub
End Class