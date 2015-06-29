Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Public Class AjusteStock

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
        If e.KeyCode = Keys.F2 Then
            dgwAjusteStock_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub 'Constructors

    Private Sub Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 138)
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
        Me.STOCKAJUSTENVTableAdapter.Fill(Me.DsInventario.STOCKAJUSTENV, CodSucursal)
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
        Me.STOCKAJUSTENVBindingSource.Filter = "CODIGO LIKE '%" & StockActualBuscar & "%' OR PRODUCTO LIKE '%" & StockActualBuscar & "%'"
    End Sub

    Private Sub cbxTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTodos.CheckedChanged
        If cbxTodos.Checked = True Then
            Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock' OR TIPOSUCURSAL = 'Solo Factura' "
        Else
            Me.SUCURSALBindingSource.Filter = "TIPOSUCURSAL = 'Solo Stock' OR TIPOSUCURSAL='Factura Y Stock'"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.AppStarting
        Producto.Show()
        Producto.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.AppStarting
        StockInicial.Show()
        StockInicial.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgwAjusteStock_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwAjusteStock.CellDoubleClick
        Dim nvoNumero As String = InputBox("Ingrese el Stock Real: ", " Ajuste de Stock", "")

        If dgwAjusteStock.RowCount <> 0 Then
            Dim StockActual, StockReal, Ajuste, CodCodigo As Double
            Dim TipoMov, sql As String
            Dim myTrans As SqlTransaction

            If nvoNumero <> "" Then
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

                cmd.Connection = sqlc
                cmd.Transaction = myTrans

                'Restamos el StockActual del StockReal para saber si se aumenta o disminuye el stock
                StockActual = dgwAjusteStock.CurrentRow.Cells("StockActual").Value
                StockReal = nvoNumero
                Ajuste = StockReal - StockActual

                If StockReal > StockActual Then
                    TipoMov = "ENTRADA"
                Else
                    TipoMov = "SALIDA"
                End If

                dgwAjusteStock.CurrentRow.Cells("StockReal").Value = Ajuste
                CodCodigo = dgwAjusteStock.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value
                Dim CodSucursal As Integer = dgvSucursal.CurrentRow.Cells("CODSUCURSAL").Value

                Try
                    Dim w As New Funciones.Funciones
                    Dim Concepto As String = "Ajuste. / Usuario : " & UsuNombre

                    sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,CANTIDAD,CONCEPTO,COSTEABLE,STOCK) " & _
                          "VALUES(" & UsuCodigo & "," & CodCodigo & "," & CodSucursal & ",GETDATE(),13," & Replace(Ajuste, ",", ".") & ", '" & Concepto & "',0,1)"

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    myTrans.Commit()
                Catch ex As Exception

                End Try

                sqlc.Close()

                Me.STOCKAJUSTENVTableAdapter.Fill(Me.DsInventario.STOCKAJUSTENV, CodSucursal)

                'Buscamos la posicion del producto y le asignamos los cambios realiados
                For i = 0 To dgwAjusteStock.RowCount - 1
                    If dgwAjusteStock.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value = CodCodigo Then
                        STOCKAJUSTENVBindingSource.Position = i
                        dgwAjusteStock.Rows(i).Cells("StockReal").Value = StockReal
                        dgwAjusteStock.Rows(i).Cells("Ajuste").Value = Ajuste
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub dgwAjusteStock_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwAjusteStock.CellContentClick

    End Sub
End Class