Imports System.Windows
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Public Class TipoProduccion
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
    Dim Nuevo As Integer
    Dim permiso As Double

    Private Sub TipoProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 66)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Abrir  esta ventana", "Pos Express")
            Me.Close()
        End If
        Me.TIPOPRODUCCIONTableAdapter.Fill(Me.DsTipoProduccion.TIPOPRODUCCION)
        Nuevo = 0
        DesHabilitar()
    End Sub

    Private Sub dgvTipoProd_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvTipoProd.SelectionChanged
        If (dgvTipoProd.Rows.Count > 0) Then
            If IsDBNull(dgvTipoProd.CurrentRow.Cells("DESTIPODataGridViewTextBoxColumn").Value) Then
            Else
                tbxDesTipoProd.Text = dgvTipoProd.CurrentRow.Cells("DESTIPODataGridViewTextBoxColumn").Value
            End If
        End If
    End Sub

    Private Sub lblNuevo_Click(sender As Object, e As System.EventArgs) Handles pbxNuevaFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 67)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en  esta ventana", "Pos Express")
            Exit Sub
        End If
        TIPOPRODUCCIONBindingSource.AddNew()
        dgvTipoProd.Enabled = False
        Habilitar()

        'txtCategorizacion.Enabled = True
        'pnlCategorias.Enabled = False
        'pbxGuardar.Visible = True
        'pbxEliminarFicha.Visible = False
        'pbxModificarFicha.Visible = False
        tbxDesTipoProd.Text = ""
        'pbxCancelar.Visible = True
        tbxDesTipoProd.Focus()
        Nuevo = 1
    End Sub

    Private Sub Habilitar()
        tbxDesTipoProd.Enabled = True

        dgvTipoProd.Enabled = False
        txtBuscar.Enabled = False
        'PanelDatos.Enabled = True 
        'Botonera
        pbxNuevaFicha.Image = My.Resources.NewOff
        pbxNuevaFicha.Enabled = False
        pbxNuevaFicha.Cursor = Cursors.Arrow

        pbxEliminarFicha.Enabled = False
        pbxEliminarFicha.Image = My.Resources.DeleteOff
        pbxEliminarFicha.Cursor = Cursors.Arrow

        pbxModificarFicha.Enabled = False
        pbxModificarFicha.Image = My.Resources.EditOff
        pbxModificarFicha.Cursor = Cursors.Arrow

        pbxCancelar.Enabled = True
        pbxCancelar.Image = My.Resources.SaveCancel
        pbxCancelar.Cursor = Cursors.Hand

        pbxGuardar.Enabled = True
        pbxGuardar.Image = My.Resources.Save
        pbxGuardar.Cursor = Cursors.Hand
    End Sub

    Private Sub lblGuardar_Click(sender As Object, e As System.EventArgs) Handles pbxGuardar.Click
        If Nuevo = 1 Then
            UltimoCodigo = f.Maximo("ID", "TIPOPRODUCCION")
            CodGlobal = UltimoCodigo + 1

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "INSERT INTO TIPOPRODUCCION (DESTIPO) values('" & tbxDesTipoProd.Text & "')"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()
            '=====================Llevar al focus de la grilla============================
            Me.TIPOPRODUCCIONTableAdapter.Fill(Me.DsTipoProduccion.TIPOPRODUCCION)
            TIPOPRODUCCIONBindingSource.Position = dgvTipoProd.RowCount - 1
        ElseIf Nuevo = 2 Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "UPDATE TIPOPRODUCCION SET DESTIPO='" & tbxDesTipoProd.Text & "' WHERE ID=" & dgvTipoProd.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()
            '=====================Llevar al focus de la grilla============================
            Me.TIPOPRODUCCIONTableAdapter.Fill(Me.DsTipoProduccion.TIPOPRODUCCION)
            TIPOPRODUCCIONBindingSource.Position = dgvTipoProd.RowCount - 1
        End If
        DesHabilitar()
    End Sub

    Private Sub lblEliminar_Click(sender As System.Object, e As System.EventArgs) Handles pbxEliminarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 68)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en  esta ventana", "Pos Express")
            Exit Sub
        End If

        tbxDesTipoProd.Enabled = False
        'pnlCategorias.Enabled = True
        Nuevo = 3
        'Try
        If MessageBox.Show("¿Esta seguro que quiere ELIMINAR:" + tbxDesTipoProd.Text, "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Nuevo = 3 Then
            '==================Eliminar Familia================================
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "DELETE FROM TIPOPRODUCCION WHERE ID=" & dgvTipoProd.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()
        End If

        DesHabilitar()
        TIPOPRODUCCIONTableAdapter.Fill(DsTipoProduccion.TIPOPRODUCCION)
    End Sub

    Private Sub DesHabilitar()
        tbxDesTipoProd.Enabled = True

        dgvTipoProd.Enabled = True
        txtBuscar.Enabled = False
        'PanelDatos.Enabled = False
        'Botonera
        pbxNuevaFicha.Image = My.Resources.New_
        pbxNuevaFicha.Enabled = True
        pbxNuevaFicha.Cursor = Cursors.Hand

        pbxEliminarFicha.Image = My.Resources.Delete
        pbxEliminarFicha.Enabled = True
        pbxEliminarFicha.Cursor = Cursors.Hand

        pbxModificarFicha.Image = My.Resources.Edit
        pbxModificarFicha.Enabled = True
        pbxModificarFicha.Cursor = Cursors.Hand

        pbxCancelar.Enabled = False
        pbxCancelar.Image = My.Resources.SaveCancelOff
        pbxCancelar.Cursor = Cursors.Arrow

        pbxGuardar.Enabled = False
        pbxGuardar.Image = My.Resources.SaveOff
        pbxGuardar.Cursor = Cursors.Arrow
    End Sub
    Private Sub lblModificar_Click(sender As System.Object, e As System.EventArgs) Handles pbxModificarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 69)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar datos  de este Registro", "Pos Express")
            Exit Sub
        End If

        Nuevo = 2
        tbxDesTipoProd.Focus()
        Habilitar()
    End Sub

    Private Sub lblCancelar_Click(sender As Object, e As System.EventArgs) Handles pbxCancelar.Click
        Try
            '===========Cancelar y no perder el foco en familia  y refresar la grilla====================
            Me.TIPOPRODUCCIONBindingSource.CancelEdit()
            Me.TIPOPRODUCCIONTableAdapter.Fill(DsTipoProduccion.TIPOPRODUCCION)
            TIPOPRODUCCIONBindingSource.Position = dgvTipoProd.RowCount - 1
            tbxDesTipoProd.Text = dgvTipoProd.CurrentRow.Cells("DESTIPODataGridViewTextBoxColumn").Value
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Ocurrió un Error Durante la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'pnlCategorias.Enabled = True
        DesHabilitar()
    End Sub
End Class