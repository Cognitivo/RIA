Imports System.Windows
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Imports System


Public Class ABMCategoriaProveedor
    Dim Nuevo As Integer
    Private sqlc As New SqlConnection
    Private myTrans As SqlTransaction
    Private ser As New BDConexión.BDConexion
    Private cmd As New SqlCommand
    Private sql As String
    Dim CodGlobal As Integer
    Dim f As New Funciones.Funciones
    Dim UltimoCodigo As Integer
    Dim UltimoNumero As Integer
    Dim CodNumero As Integer
    Dim permiso As Double

    Private Sub ABMCategoriaProveedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 171)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express")
            Me.Close()
        End If

        Me.CATEGORIAPROVEEDORTableAdapter.Fill(Me.DsCategoriaProveedor.CATEGORIAPROVEEDOR)
        Deshabilitar()
        lblCategoria.Text = "Categorias"
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        permiso = PermisoAplicado(UsuCodigo, 172)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en  esta ventana", "Pos Express")
            Exit Sub
        End If
        Nuevo = 1
        Habilitar()
        txtCategorizacion.Text = " "
        txtCategorizacion.Focus()
        txtCategorizacion.BackColor = Color.LightSteelBlue
        lblCategoria.Text = "Ingrese la descripcion de la Categoria"
        btnNuevo.Image = My.Resources.NewActive
    End Sub

    Private Sub dgvCategoriaProveedor_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvCategoriaProveedor.SelectionChanged
        If (dgvCategoriaProveedor.Rows.Count > 0) Then
            If dgvCategoriaProveedor.CurrentRow.Cells("CODCATEGORIAPROVEEDOR").Value Then
                Dim categoria As Integer = dgvCategoriaProveedor.CurrentRow.Cells("CODCATEGORIAPROVEEDOR").Value


                txtCategorizacion.Text = dgvCategoriaProveedor.CurrentRow.Cells("DESCATEGORIAPROVEEDOR").Value
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Try

            '====================Guardar Categoria Del Proveedor================================

            If Nuevo = 1 Then
                UltimoCodigo = f.Maximo("CODCATEGORIAPROVEEDOR", "CATEGORIAPROVEEDOR")
                CodGlobal = UltimoCodigo + 1
                UltimoNumero = f.Maximo("NUMCATEGORIAPROVEEDOR", "CATEGORIAPROVEEDOR")
                CodNumero = UltimoNumero + 1
                '=====================Insertar Categoria Proveedor==========================
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                cmd.Connection = sqlc
                cmd.Transaction = myTrans
                sql = ""
                sql = "INSERT INTO CATEGORIAPROVEEDOR (CODCATEGORIAPROVEEDOR,CODUSUARIO,CODEMPRESA,NUMCATEGORIAPROVEEDOR,DESCATEGORIAPROVEEDOR,FECGRA) values(" & CodGlobal & "," & UsuCodigo & "," & EmpCodigo & "," & CodNumero & ",'" & txtCategorizacion.Text & "', convert(datetime, '" & Today() & " 0:00:00', 103))"
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                myTrans.Commit()
                sqlc.Close()
                '=====================Llevar al focus de la grilla============================
                Dim codCatTemp As String
                codCatTemp = CodGlobal
                Me.CATEGORIAPROVEEDORTableAdapter.Fill(Me.DsCategoriaProveedor.CATEGORIAPROVEEDOR)
                For i = 0 To dgvCategoriaProveedor.RowCount - 1
                    If dgvCategoriaProveedor.Rows(i).Cells("CODCATEGORIAPROVEEDOR").Value = codCatTemp Then
                        CATEGORIAPROVEEDORBindingSource.Position = i
                    End If
                Next
            ElseIf Nuevo = 2 Then
                '===================Actualizar Categoria Proveedor================================
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                cmd.Connection = sqlc
                cmd.Transaction = myTrans
                sql = ""
                sql = "UPDATE CATEGORIAPROVEEDOR SET DESCATEGORIAPROVEEDOR='" & txtCategorizacion.Text & "' WHERE CODCATEGORIAPROVEEDOR=" & dgvCategoriaProveedor.CurrentRow.Cells("CODCATEGORIAPROVEEDOR").Value
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                myTrans.Commit()
                sqlc.Close()
                '=====================Llevar al focus de la grilla============================
                Dim codCatTemp As String
                codCatTemp = dgvCategoriaProveedor.CurrentRow.Cells("CODCATEGORIAPROVEEDOR").Value
                Me.CATEGORIAPROVEEDORTableAdapter.Fill(Me.DsCategoriaProveedor.CATEGORIAPROVEEDOR)
                For i = 0 To dgvCategoriaProveedor.RowCount - 1
                    If dgvCategoriaProveedor.Rows(i).Cells("CODCATEGORIAPROVEEDOR").Value = codCatTemp Then
                        CATEGORIAPROVEEDORBindingSource.Position = i
                    End If
                Next
            End If
            Deshabilitar()
            lblCategoria.Text = "Categorias"
            txtCategorizacion.Text = ""
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Ocurrió un Error Durante la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub Habilitar()
        btnNuevo.Image = My.Resources.NewOff
        btnNuevo.Enabled = False
        btnNuevo.Cursor = Cursors.Arrow
        BtnEliminar.Enabled = False
        BtnEliminar.Image = My.Resources.DeleteOff
        BtnEliminar.Cursor = Cursors.Arrow
        BtnModificar.Enabled = False
        BtnModificar.Image = My.Resources.EditOff
        BtnModificar.Cursor = Cursors.Arrow

        btnCancelar.Enabled = True
        btnCancelar.Image = My.Resources.SaveCancel
        btnCancelar.Cursor = Cursors.Hand
        BtnGuardar.Enabled = True
        BtnGuardar.Image = My.Resources.Save
        BtnGuardar.Cursor = Cursors.Hand
        txtCategorizacion.Enabled = True

        dgvCategoriaProveedor.Enabled = False
        txtBuscaProveedor.Enabled = False
    End Sub
    Private Sub Deshabilitar()
        btnNuevo.Image = My.Resources.New_
        btnNuevo.Enabled = True
        btnNuevo.Cursor = Cursors.Hand

        BtnEliminar.Enabled = True
        BtnEliminar.Image = My.Resources.Delete
        BtnEliminar.Cursor = Cursors.Hand
        BtnModificar.Enabled = True
        BtnModificar.Image = My.Resources.Edit
        BtnModificar.Cursor = Cursors.Hand

        btnCancelar.Enabled = True
        btnCancelar.Image = My.Resources.SaveCancelOff
        btnCancelar.Cursor = Cursors.Arrow
        BtnGuardar.Enabled = False
        BtnGuardar.Image = My.Resources.SaveOff
        BtnGuardar.Cursor = Cursors.Arrow
        txtCategorizacion.Enabled = False

        dgvCategoriaProveedor.Enabled = True
        txtBuscaProveedor.Enabled = True
    End Sub
    Private Sub BtnModificar_Click(sender As Object, e As System.EventArgs) Handles BtnModificar.Click
        permiso = PermisoAplicado(UsuCodigo, 174)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar los datos de Este Registro", "Pos Express")
            Exit Sub
        End If
        Nuevo = 2
        Habilitar()
        txtCategorizacion.Focus()
        txtCategorizacion.BackColor = Color.LightSteelBlue
        BtnModificar.Image = My.Resources.EditActive
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As System.EventArgs) Handles BtnEliminar.Click
        permiso = PermisoAplicado(UsuCodigo, 173)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en  esta ventana", "Pos Express")
            Exit Sub
        End If

        Try
            If MessageBox.Show("¿Esta seguro que quiere eliminar la Categoria del Proveedor?", "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If
            txtCategorizacion.Enabled = False

            Nuevo = 3



            If Nuevo = 3 Then
                '==================Eliminar Categoria Proveedor================================
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                cmd.Connection = sqlc
                cmd.Transaction = myTrans
                sql = ""
                sql = "DELETE FROM CATEGORIAPROVEEDOR WHERE CODCATEGORIAPROVEEDOR=" & dgvCategoriaProveedor.CurrentRow.Cells("CODCATEGORIAPROVEEDOR").Value
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                myTrans.Commit()
                sqlc.Close()
            End If
            Dim codCatTemp As String
            codCatTemp = dgvCategoriaProveedor.CurrentRow.Cells("CODCATEGORIAPROVEEDOR").Value
            Me.CATEGORIAPROVEEDORTableAdapter.Fill(Me.DsCategoriaProveedor.CATEGORIAPROVEEDOR)
            For i = 0 To dgvCategoriaProveedor.RowCount - 1
                If dgvCategoriaProveedor.Rows(i).Cells("CODCATEGORIAPROVEEDOR").Value = codCatTemp Then
                    CATEGORIAPROVEEDORBindingSource.Position = i
                End If
            Next
        Catch ex As SqlException
            Try
                myTrans.Rollback("")
            Catch

            End Try

            Dim NroError As Integer = ex.Number
            Dim Mensaje As String = ex.Message
            If NroError = 547 Then
                MessageBox.Show("La categoria que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podra eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al Eliminar la Categoria del Cliente: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Finally
            sqlc.Close()

        End Try
        Deshabilitar()
        lblCategoria.Text = "Categorias"
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Try


            If dgvCategoriaProveedor.Rows.Count > 0 Then
                Dim codCatTemp As String
                codCatTemp = dgvCategoriaProveedor.CurrentRow.Cells("CODCATEGORIAPROVEEDOR").Value

                '===========Cancelar y no perder el foco en linea y refresar la grilla====================
                Me.CATEGORIAPROVEEDORBindingSource.CancelEdit()
                Me.CATEGORIAPROVEEDORTableAdapter.Fill(Me.DsCategoriaProveedor.CATEGORIAPROVEEDOR)

                For i = 0 To dgvCategoriaProveedor.RowCount - 1
                    If dgvCategoriaProveedor.Rows(i).Cells("CODCATEGORIAPROVEEDOR").Value = codCatTemp Then
                        CATEGORIAPROVEEDORBindingSource.Position = i
                    End If
                Next
                txtCategorizacion.Text = dgvCategoriaProveedor.CurrentRow.Cells("DESCATEGORIAPROVEEDOR").Value

            End If
            Deshabilitar()
            lblCategoria.Text = "Categorias"
            txtCategorizacion.Text = dgvCategoriaProveedor.CurrentRow.Cells("DESCATEGORIAPROVEEDOR").Value
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Ocurrió un Error Durante la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub txtBuscaProveedor_GotFocus(sender As Object, e As System.EventArgs) Handles txtBuscaProveedor.GotFocus
        txtBuscaProveedor.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub txtBuscaProveedor_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscaProveedor.LostFocus
        txtBuscaProveedor.BackColor = Color.DimGray
    End Sub
    Private Sub txtBuscaProveedor_TextChanged(sender As Object, e As System.EventArgs) Handles txtBuscaProveedor.TextChanged
        Me.CATEGORIAPROVEEDORBindingSource.Filter = "DESCATEGORIAPROVEEDOR like '%" & txtBuscaProveedor.Text & "%'"
    End Sub

End Class