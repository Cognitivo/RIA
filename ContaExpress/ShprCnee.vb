Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.ToolStripMenuItem
Imports Osuna.Utiles.Conectividad

Public Class ShprCnee
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

    Private Sub ShprCnee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CIUDADTableAdapter.Fill(Me.DsSHPRCNEE.CIUDAD)
        Me.PAISTableAdapter.Fill(Me.DsSHPRCNEE.PAIS)
        Me.SHPRCNEETableAdapter.Fill(Me.DsSHPRCNEE.SHPRCNEE)

    End Sub
    Private Sub dgvShprCnee_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvShprCnee.SelectionChanged
        If (dgvShprCnee.Rows.Count > 0) Then
            If IsDBNull(dgvShprCnee.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value) Then
            Else
                tbxNombre.Text = dgvShprCnee.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value
                tbxRUC.Text = dgvShprCnee.CurrentRow.Cells("RUCDataGridViewTextBoxColumn").Value
                tbxDireccion.Text = dgvShprCnee.CurrentRow.Cells("DIRECCIONDataGridViewTextBoxColumn").Value
                tbxCodPostal.Text = dgvShprCnee.CurrentRow.Cells("CODPOSTALDataGridViewTextBoxColumn").Value
                tbxCodZona.Text = dgvShprCnee.CurrentRow.Cells("CODZONADataGridViewTextBoxColumn").Value
                tbxTelefono.Text = dgvShprCnee.CurrentRow.Cells("TELDataGridViewTextBoxColumn").Value
                tbxFax.Text = dgvShprCnee.CurrentRow.Cells("FAXDataGridViewTextBoxColumn").Value
                tbxEmail.Text = dgvShprCnee.CurrentRow.Cells("EMAILDataGridViewTextBoxColumn").Value
            End If
        End If
    End Sub

    Private Sub lblNuevo_Click(sender As Object, e As System.EventArgs) Handles pbxNuevaFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 67)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en  esta ventana", "Pos Express")
            Exit Sub
        End If
        SHPRCNEEBindingSource.AddNew()
        dgvShprCnee.Enabled = False
        Habilitar()

        'txtCategorizacion.Enabled = True
        'pnlCategorias.Enabled = False
        'pbxGuardar.Visible = True
        'pbxEliminarFicha.Visible = False
        'pbxModificarFicha.Visible = False
        'pbxCancelar.Visible = True
        tbxNombre.Text = ""
        tbxRUC.Text = ""
        tbxDireccion.Text = ""
        tbxCodPostal.Text = ""
        tbxCodZona.Text = ""
        tbxTelefono.Text = ""
        tbxFax.Text = ""
        tbxEmail.Text = ""
        tbxNombre.Focus()
        Nuevo = 1
    End Sub

    Private Sub Habilitar()
        tbxDesEquipo.Enabled = True

        dgvShprCnee.Enabled = False
        BuscarTextBox.Enabled = False
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
            UltimoCodigo = f.Maximo("ID", "SHPRCNEE")
            CodGlobal = UltimoCodigo + 1

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "INSERT INTO SHPRCNEE (NOMBRE, RUC, DIRECCION, CODPAIS, CODCIUDAD, TEL, FAX, CODPOSTAL, EMAIL, CODZONA)" & _
                  "VALUES ('" & tbxNombre.Text & "','" & tbxRUC.Text & "','" & tbxDireccion.Text & "','" & cbxPais.SelectedValue & "','" & cbxCiudad.SelectedValue & "'" & _
                  ",'" & tbxTelefono.Text & "','" & tbxFax.Text & "','" & tbxCodPostal.Text & "','" & tbxEmail.Text & "','" & tbxCodZona.Text & "')"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()

        ElseIf Nuevo = 2 Then
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "UPDATE SHPRCNEE SET NOMBRE='" & tbxNombre.Text & "', RUC='" & tbxRUC.Text & "',DIRECCION='" & tbxDireccion.Text & "',CODPAIS='" & cbxPais.SelectedValue & "'" & _
                  ",CODCIUDAD='" & cbxCiudad.SelectedValue & "',TEL='" & tbxTelefono.Text & "',FAX='" & tbxFax.Text & "',CODPOSTAL='" & tbxCodPostal.Text & "',EMAIL='" & tbxEmail.Text & "',CODZONA='" & tbxCodZona.Text & "'" & _
                  "WHERE ID=" & dgvShprCnee.CurrentRow.Cells("ID").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()

        End If
        Me.SHPRCNEETableAdapter.Fill(Me.DsSHPRCNEE.SHPRCNEE)
        SHPRCNEEBindingSource.Position = dgvShprCnee.RowCount - 1
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

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "DELETE FROM SHPRCNEE WHERE ID=" & dgvShprCnee.CurrentRow.Cells("ID").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()
        End If


        DesHabilitar()
        SHPRCNEETableAdapter.Fill(DsSHPRCNEE.SHPRCNEE)
    End Sub

    Private Sub DesHabilitar()
        tbxDesEquipo.Enabled = True

        dgvShprCnee.Enabled = True
        BuscarTextBox.Enabled = False
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
            If dgvShprCnee.Rows.Count > 0 Then
                Me.SHPRCNEEBindingSource.CancelEdit()
                Me.SHPRCNEETableAdapter.Fill(DsSHPRCNEE.SHPRCNEE)
                SHPRCNEEBindingSource.Position = dgvShprCnee.RowCount - 1
            End If
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Ocurrió un Error Durante la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'pnlCategorias.Enabled = True
        DesHabilitar()
    End Sub

    Private Sub SHPRCNEE_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' Proyectos.SHPRCNEETableAdapter1.Fill(Proyectos.DsEventos.SHPRCNEE)
        Contactos.SHPRCNEETableAdapter.Fill(DsSHPRCNEE.SHPRCNEE)
    End Sub

    'Private Sub cbxPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPais.SelectedIndexChanged
    '    CIUDADBindingSource.Filter = "CODPAIS ='" & cbxPais.SelectedValue & "'"
    'End Sub
End Class