Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Public Class Stock

#Region "Fields"
    Private cmd As SqlCommand

    '#################### Para los permisos de usuarios ####################################################################
    Private ser As BDConexión.BDConexion
    Private sqlc As SqlConnection

    Dim DescripSucursal As String
    Dim f As New Funciones.Funciones
    Dim permiso As Double
    Dim DescripProducto As String
#End Region 'Fields

#Region "Constructors"

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

#End Region

    Private Sub Stock_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnRefresh_Click(Nothing, Nothing)
        End If

        If e.KeyCode = Keys.F2 Then
            Dim stock As Double = 0
            For i = 0 To dgvStock.Rows.Count - 1
                stock = stock + CInt(dgvStock.Rows(i).Cells("STOCKACTUAL").Value)
            Next
            MessageBox.Show("Total de Stock : " & FormatNumber(stock, 0), "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub 'Constructors

    Private Sub Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        permiso = PermisoAplicado(UsuCodigo, 59)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express")
            Me.Close()
        End If

        Me.SUCURSALTableAdapter.Fill(Me.DsInventario.SUCURSAL)
        Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='FACTURA Y STOCK'"
        tbxBuscador.Focus()
    End Sub

    Private Sub dgvSucursal_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSucursal.SelectionChanged
        'Filtra Productos y Stock por Sucursal
        Dim CodSucursal As Integer = dgvSucursal.CurrentRow.Cells("CODSUCURSAL").Value
        Me.StockActualTableAdapter.Fill(DsInventario.StockActual, CodSucursal)
        RadLabel15.Text = dgvSucursal.CurrentRow.Cells("DESSUCURSAL").Value
    End Sub

    Private Sub tbxBuscador_GotFocus(sender As Object, e As System.EventArgs) Handles tbxBuscador.GotFocus
        tbxBuscador.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxBuscador_LostFocus(sender As Object, e As System.EventArgs) Handles tbxBuscador.LostFocus
        tbxBuscador.BackColor = Color.Tan
    End Sub

    Private Sub tbxBuscador_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxBuscador.TextChanged
        Dim StockActualBuscar As String = tbxBuscador.Text
        Me.StockActualBindingSource.Filter = "CODIGO LIKE '%" & StockActualBuscar & "%' OR DESPRODUCTO LIKE '%" & StockActualBuscar & "%'"
    End Sub

    Private Sub cbxTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTodos.CheckedChanged
        If cbxTodos.Checked = True Then
            Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock' OR TIPOSUCURSAL = 'Solo Factura' "
        Else
            Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock'"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.AppStarting
        Producto.Show()
        Producto.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.AppStarting
        StockInicial.Show()
        StockInicial.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Dim CodSucursal As Integer = dgvSucursal.CurrentRow.Cells("CODSUCURSAL").Value
        Me.StockActualTableAdapter.Fill(DsInventario.StockActual, CodSucursal)

        If tbxBuscador.Text <> "" Then
            Dim StockActualBuscar As String = tbxBuscador.Text
            Me.StockActualBindingSource.Filter = "CODIGO LIKE '%" & StockActualBuscar & "%' OR DESPRODUCTO LIKE '%" & StockActualBuscar & "%'"
        End If
    End Sub

    Private Sub dgvStock_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvStock.CellFormatting
        Try
            If Me.dgvStock.Columns(e.ColumnIndex).Name = "STOCKACTUAL" Then
                If e.Value IsNot Nothing Then
                    If e.Value < 0 Then
                        e.CellStyle.ForeColor = Color.Red
                    Else
                        If Not IsDBNull(Me.dgvStock(e.ColumnIndex + 1, e.RowIndex).Value) Then
                            If e.Value <= Me.dgvStock(e.ColumnIndex + 1, e.RowIndex).Value Then
                                e.CellStyle.ForeColor = Color.Orange
                            End If
                        End If
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
        
    End Sub
End Class