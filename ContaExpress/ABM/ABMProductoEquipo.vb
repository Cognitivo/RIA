Imports System.Windows
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class ABMProductoEquipo
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

    Private Sub ABMProductoEquipo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      
        permiso = PermisoAplicado(UsuCodigo, 66)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Abrir  esta ventana", "Pos Express")
            Me.Close()
        End If
     
        Me.PRODUCTOEQUIPOTableAdapter.Fill(Me.DsProductos.PRODUCTOEQUIPO)
        Me.dgvEquipo.Sort(Me.dgvEquipo.Columns("DESEQUIPO"), System.ComponentModel.ListSortDirection.Ascending)

        Nuevo = 0
        'pnlCategorias.Enabled = True
        DesHabilitar()
    End Sub

    Private Sub dgvMarca_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvEquipo.SelectionChanged
        If (dgvEquipo.Rows.Count > 0) Then
            If IsDBNull(dgvEquipo.CurrentRow.Cells("DESEQUIPO").Value) Then
            Else
                tbxDesEquipo.Text = dgvEquipo.CurrentRow.Cells("DESEQUIPO").Value
            End If
        End If
    End Sub

    Private Sub lblNuevo_Click(sender As Object, e As System.EventArgs) Handles pbxNuevaFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 67)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en  esta ventana", "Pos Express")
            Exit Sub
        End If
        PRODUCTOEQUIPOBindingSource.AddNew()
        dgvEquipo.Enabled = False
        Habilitar()

        'txtCategorizacion.Enabled = True
        'pnlCategorias.Enabled = False
        'pbxGuardar.Visible = True
        'pbxEliminarFicha.Visible = False
        'pbxModificarFicha.Visible = False
        tbxDesEquipo.Text = ""
        'pbxCancelar.Visible = True
        tbxDesEquipo.Focus()
        Nuevo = 1
    End Sub

    Private Sub Habilitar()
        tbxDesEquipo.Enabled = True

        dgvEquipo.Enabled = False
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
            UltimoCodigo = f.Maximo("IDEQUIPO", "PRODUCTOEQUIPO")
            CodGlobal = UltimoCodigo + 1

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "INSERT INTO PRODUCTOEQUIPO (IDEQUIPO,DESEQUIPO) values(" & CodGlobal & ",'" & tbxDesEquipo.Text & "')"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()
            '=====================Llevar al focus de la grilla============================
            Me.PRODUCTOEQUIPOTableAdapter.Fill(Me.DsProductos.PRODUCTOEQUIPO)
            PRODUCTOEQUIPOBindingSource.Position = dgvEquipo.RowCount - 1
        ElseIf Nuevo = 2 Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "UPDATE PRODUCTOEQUIPO SET DESEQUIPO='" & tbxDesEquipo.Text & "' WHERE IDEQUIPO=" & dgvEquipo.CurrentRow.Cells("IDEQUIPO").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()
            '=====================Llevar al focus de la grilla============================
            Me.PRODUCTOEQUIPOTableAdapter.Fill(Me.DsProductos.PRODUCTOEQUIPO)
            PRODUCTOEQUIPOBindingSource.Position = dgvEquipo.RowCount - 1
        End If
        DesHabilitar()
    End Sub
    Private Sub lblEliminar_Click(sender As System.Object, e As System.EventArgs) Handles pbxEliminarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 68)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en  esta ventana", "Pos Express")
            Exit Sub
        End If

        tbxDesEquipo.Enabled = False
        'pnlCategorias.Enabled = True
        Nuevo = 3
        'Try
        If MessageBox.Show("¿Esta seguro que quiere ELIMINAR:" + tbxDesEquipo.Text, "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Nuevo = 3 Then
            '==================Eliminar Familia================================
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "DELETE FROM PRODUCTOEQUIPO WHERE IDEQUIPO=" & dgvEquipo.CurrentRow.Cells("IDEQUIPO").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()
        End If


        '    '=======================Codigo para no perder el focus en caso de error =========================
        '    If dgvLinea.Rows.Count > 0 Then
        '        Dim codLineaTemp As String
        '        codLineaTemp = dgvLinea.CurrentRow.Cells("CODLINEA").Value
        '        If lblCategorizacion.Text = "Lineas" Then
        '            Me.LINEATableAdapter.Fill(DsCategorizacion.LINEA)
        '            For i = 0 To dgvLinea.RowCount - 1
        '                If dgvLinea.Rows(i).Cells("CODLINEA").Value = codLineaTemp Then
        '                    LINEABindingSource.Position = i
        '                End If
        '            Next
        '        End If
        '    End If
        '    If dgvRubro.Rows.Count > 0 Then
        '        Dim CODRUBRO1Temp As String
        '        CODRUBRO1Temp = dgvRubro.CurrentRow.Cells("CODRUBRO1").Value
        '        If lblCategorizacion.Text = "Rubros" Then
        '            Me.RUBROTableAdapter.Fill(DsCategorizacion.RUBRO)
        '            For i = 0 To dgvRubro.RowCount - 1
        '                If dgvRubro.Rows(i).Cells("CODRUBRO1").Value = CODRUBRO1Temp Then
        '                    RUBROBindingSource.Position = i
        '                End If
        '            Next
        '        End If
        '    End If
        '    If dgvCategorias.Rows.Count > 0 Then
        '        Dim codFamiliaTemp As String
        '        codFamiliaTemp = dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value
        '        If lblCategorizacion.Text = "Familias" Then
        '            Me.FAMILIATableAdapter.Fill(DsCategorizacion.FAMILIA)
        '            For i = 0 To dgvCategorias.RowCount - 1
        '                If dgvCategorias.Rows(i).Cells("CODFAMILIA").Value = codFamiliaTemp Then
        '                    FAMILIABindingSource.Position = i
        '                End If
        '            Next
        '        End If
        '    End If
        'Catch ex As SqlException
        '    Try
        '        myTrans.Rollback("")
        '    Catch

        '    End Try

        '    Dim NroError As Integer = ex.Number
        '    Dim Mensaje As String = ex.Message
        '    If NroError = 547 Then
        '        MessageBox.Show("La categoria que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podra eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Else
        '        MessageBox.Show("Error al Eliminar la Categoria : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'Finally
        '    sqlc.Close()
        'End Try
        DesHabilitar()
        PRODUCTOEQUIPOTableAdapter.Fill(DsProductos.PRODUCTOEQUIPO)
    End Sub

    Private Sub DesHabilitar()
        tbxDesEquipo.Enabled = True

        dgvEquipo.Enabled = True
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
        tbxDesEquipo.Focus()
        Habilitar()
    End Sub

    Private Sub lblCancelar_Click(sender As Object, e As System.EventArgs) Handles pbxCancelar.Click
        Try
            '===========Cancelar y no perder el foco en familia  y refresar la grilla====================
            Me.PRODUCTOEQUIPOBindingSource.CancelEdit()
            Me.PRODUCTOEQUIPOTableAdapter.Fill(DsProductos.PRODUCTOEQUIPO)
            PRODUCTOEQUIPOBindingSource.Position = dgvEquipo.RowCount - 1
            tbxDesEquipo.Text = dgvEquipo.CurrentRow.Cells("DESEQUIPO").Value
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Ocurrió un Error Durante la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        
        'pnlCategorias.Enabled = True
        DesHabilitar()
    End Sub
End Class
