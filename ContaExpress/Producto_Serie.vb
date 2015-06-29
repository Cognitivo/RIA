Imports System.Data
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class Producto_Serie
    Private ser As BDConexión.BDConexion  'LLAMA A LA CLASE BDCONEXION
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction
    Dim sql As String
    Dim isNew As Integer = 0

    'ES LO PRIMERO QUE SE EJECUTA ANTES DEL LOAD
    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand
        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2  'ES EL ESTRING DE CONEXION
    End Sub

    Private Sub Producto_Serie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PRODUCTO_SERIETableAdapter.Fill(Me.DsSerie1.PRODUCTO_SERIE)
        Me.PRODUCTOSTableAdapter.Fill(Me.DsSerie.PRODUCTOS)
        Deshabilitar()
    End Sub

    Private Sub PictureBoxNuevo_Click(sender As Object, e As EventArgs) Handles PictureBoxNuevo.Click
        isNew = 1
        Habilita()
        Limpiar()
        CbxProducto.Focus()
    End Sub

    Public Sub Habilita()
        CbxProducto.Enabled = True
        TbxDesde.Enabled = True
        TbxHasta.Enabled = True
        TbxActual.Enabled = True
        TxbPrefijo.Enabled = True
        btnAsterisco.Enabled = True
        PictureBoxNuevo.Enabled = False
        PictureBoxNuevo.Image = My.Resources.NewOff
        PictureBoxEliminar.Enabled = False
        PictureBoxEliminar.Image = My.Resources.DeleteOff
        PictureBoxModifica.Enabled = False
        PictureBoxModifica.Image = My.Resources.EditOff
        PictureBoxGuardar.Enabled = True
        PictureBoxGuardar.Image = My.Resources.Save
        PictureBoxCancelar.Enabled = True
        PictureBoxCancelar.Image = My.Resources.SaveCancel
    End Sub

    Public Sub Deshabilitar()
        CbxProducto.Enabled = False
        TbxDesde.Enabled = False
        TbxHasta.Enabled = False
        TbxActual.Enabled = False
        TxbPrefijo.Enabled = False
        btnAsterisco.Enabled = False
        PictureBoxNuevo.Enabled = True
        PictureBoxNuevo.Image = My.Resources.New_
        PictureBoxEliminar.Enabled = True
        PictureBoxEliminar.Image = My.Resources.Delete
        PictureBoxModifica.Enabled = True
        PictureBoxModifica.Image = My.Resources.Edit
        PictureBoxGuardar.Enabled = False
        PictureBoxGuardar.Image = My.Resources.SaveOff
        PictureBoxCancelar.Enabled = False
        PictureBoxCancelar.Image = My.Resources.SaveCancelOff
    End Sub

    Public Sub Limpiar()
        TbxDesde.Text = ""
        TbxHasta.Text = ""
        TbxActual.Text = ""
        TxbPrefijo.Text = ""
    End Sub

    Private Sub PictureBoxModifica_Click(sender As Object, e As EventArgs) Handles PictureBoxModifica.Click
        isNew = 0
        Habilita()
        CbxProducto.Focus()
        PictureBoxModifica.Image = My.Resources.EditActive
    End Sub

    Private Sub PictureBoxEliminar_Click(sender As Object, e As EventArgs) Handles PictureBoxEliminar.Click
        If MessageBox.Show("¿Esta seguro que quiere eliminar la Producto Serie?", "RIA", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim transaction As SqlTransaction = Nothing
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            EliminaProductoSerie()

            myTrans.Commit()
            Me.PRODUCTO_SERIETableAdapter.Fill(Me.DsSerie.PRODUCTO_SERIE)

            Deshabilitar()

        Catch ex As SqlException
            Try
                myTrans.Rollback("")
            Catch

            End Try

            Dim NroError As Integer = ex.Number
            Dim Mensaje As String = ex.Message

            If NroError = 547 Then
                MessageBox.Show("La Cuenta que desea eliminar tiene relacion con alguna otra tabla del Sistema", "POSEXPRESS")
            Else
                MessageBox.Show("Ocurrio un error el eliminar la Pagare" + ex.Message, "RIA")
            End If

        Finally
            sqlc.Close()
            Me.PRODUCTO_SERIETableAdapter.Fill(Me.DsSerie1.PRODUCTO_SERIE)
        End Try
    End Sub
   
    Private Sub EliminaProductoSerie()
        sql = ""
        sql = " DELETE FROM PRODUCTO_SERIE " & _
              " WHERE Id= " & ProductosGridView.CurrentRow.Cells("IdDataGridViewTextBoxColumn").Value

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub PictureBoxGuardar_Click(sender As Object, e As EventArgs) Handles PictureBoxGuardar.Click
        Dim consulta As System.String = Nothing
        Dim conexion As System.Data.SqlClient.SqlConnection
        Dim myTrans As System.Data.SqlClient.SqlTransaction

        conexion = ser.Abrir()

        If isNew = 1 Then
            consulta = "INSERT INTO PRODUCTO_SERIE (Id_producto, Serie_desde, Serie_hasta, Serie_actual, Prefijo, Estado) VALUES (" & CbxProducto.SelectedValue & ", " & TbxDesde.Text & ", " & TbxHasta.Text & ", '" & TbxActual.Text & "', '" & TxbPrefijo.Text & "', 1)"
        Else
            consulta = "UPDATE PRODUCTO_SERIE UPDATE Id_producto = " & CbxProducto.SelectedValue & ", Serie_desde = " & TbxDesde.Text & ", Serie_hasta = " & TbxHasta.Text & _
                       ", Serie_actual = " & TbxActual.Text & ", Prefijo = '" & TxbPrefijo.Text & "' WHERE id = " & ProductosGridView.CurrentRow.Cells("IdDataGridViewTextBoxColumn").Value
        End If

        myTrans = conexion.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
        Consultas.ConsultaComando(myTrans, consulta)

        Try
            myTrans.Commit()
            Deshabilitar()
        Catch ex As Exception
            myTrans.Rollback("Insertar")
            MessageBox.Show(ex.Message, "RIA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Me.PRODUCTO_SERIETableAdapter.Fill(Me.DsSerie1.PRODUCTO_SERIE)
        isNew = 0
    End Sub

    Private Sub BuscaProductoTextBox_TextChanged(sender As Object, e As EventArgs) Handles BuscaProductoTextBox.TextChanged
        PRODUCTOSERIEBindingSource.Filter = "DESPRODUCTO  LIKE '%" & BuscaProductoTextBox.Text & "%'"
    End Sub

    Private Sub PictureBoxCancelar_Click(sender As Object, e As EventArgs) Handles PictureBoxCancelar.Click
        PRODUCTOSERIEBindingSource.CancelEdit()
        Me.PRODUCTO_SERIETableAdapter.Fill(Me.DsSerie1.PRODUCTO_SERIE)
        Deshabilitar()
    End Sub

    Private Sub btnAsterisco_Click(sender As Object, e As EventArgs) Handles btnAsterisco.Click
        upcProductos.Show()
        tbxBuscarProductos.Text = ""
        tbxBuscarProductos.Focus()
    End Sub

    Private Sub dgwProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwProductos.CellContentClick
        upcProductos.Close()
    End Sub

    Private Sub tbxBuscarProductos_TextChanged(sender As Object, e As EventArgs) Handles tbxBuscarProductos.TextChanged
        PRODUCTOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & tbxBuscarProductos.Text & "%' OR CODIGO LIKE '%" & tbxBuscarProductos.Text & "%'"
    End Sub
End Class