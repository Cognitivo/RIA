Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.ToolStripMenuItem
Imports Osuna.Utiles.Conectividad

Public Class Contactos
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
    Dim Cliente, Shpr, Prov As Integer

    Private Sub Contactos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PROVEEDORTableAdapter.Fill(Me.DsProveedores.PROVEEDOR)
        Me.SHPRCNEETableAdapter.Fill(Me.DsSHPRCNEE.SHPRCNEE)
        Me.CLIENTESTableAdapter.Fill(Me.DsCliente.CLIENTES)
        Me.CONTACTOSTableAdapter.Fill(Me.DsContactos.CONTACTOS)

        'cbxCliente.Enabled = False
        cbxShpr.Enabled = False
        cbxProv.Enabled = False

        'tbxContacto.Enabled = False
        'tbxEmail.Enabled = False
        'tbxTel.Enabled = False
        'tbxCel.Enabled = False
        'txtDireccion.Enabled = False

    End Sub

    Private Sub dgvContacto_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvContacto.SelectionChanged
        If (dgvContacto.Rows.Count > 0) Then
            If IsDBNull(dgvContacto.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value) Then
            Else
                tbxContacto.Text = dgvContacto.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn").Value
                If IsDBNull(dgvContacto.CurrentRow.Cells("EMAILDataGridViewTextBoxColumn").Value) Then
                    tbxEmail.Text = ""
                Else
                    tbxEmail.Text = dgvContacto.CurrentRow.Cells("EMAILDataGridViewTextBoxColumn").Value
                End If
                If IsDBNull(dgvContacto.CurrentRow.Cells("DIRECCIONDataGridViewTextBoxColumn").Value) Then
                    txtDireccion.Text = ""
                Else
                    txtDireccion.Text = dgvContacto.CurrentRow.Cells("DIRECCIONDataGridViewTextBoxColumn").Value
                End If
                If IsDBNull(dgvContacto.CurrentRow.Cells("TELEFONODataGridViewTextBoxColumn").Value) Then
                    tbxTel.Text = ""
                Else
                    tbxTel.Text = dgvContacto.CurrentRow.Cells("TELEFONODataGridViewTextBoxColumn").Value
                End If
                If IsDBNull(dgvContacto.CurrentRow.Cells("CELULARDataGridViewTextBoxColumn").Value) Then
                    tbxCel.Text = ""
                Else
                    tbxCel.Text = dgvContacto.CurrentRow.Cells("CELULARDataGridViewTextBoxColumn").Value
                End If
            End If
        End If
    End Sub

    Private Sub lblNuevo_Click(sender As Object, e As System.EventArgs) Handles pbxNuevaFicha.Click
        Cliente = 0
        Shpr = 0
        Prov = 0
        permiso = PermisoAplicado(UsuCodigo, 67)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en  esta ventana", "Pos Express")
            Exit Sub
        End If
        CONTACTOSBindingSource.AddNew()
        dgvContacto.Enabled = False
        Habilitar()

        tbxContacto.Text = ""
        txtDireccion.Text = ""
        tbxTel.Text = ""
        tbxCel.Text = ""
        tbxEmail.Text = ""
        cbxCliente.Text = ""
        cbxShpr.Text = ""
        cbxProv.Text = ""
        tbxContacto.Focus()
        Nuevo = 1
    End Sub

    Private Sub Habilitar()
        tbxContacto.Enabled = True
        txtDireccion.Enabled = True
        tbxTel.Enabled = True
        tbxCel.Enabled = True
        tbxEmail.Enabled = True

        dgvContacto.Enabled = False
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
            UltimoCodigo = f.Maximo("CODCONTACTO", "CONTACTOS")
            CodGlobal = UltimoCodigo + 1

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "INSERT INTO CONTACTOS (CODCONTACTO,NOMBRE, EMAIL, TELEFONO, CELULAR, DIRECCION,CODCLIEN,CODSHPR,CODPROV)" & _
                  "VALUES ('" & CodGlobal & "','" & tbxContacto.Text & "','" & tbxEmail.Text & "','" & tbxTel.Text & "','" & tbxCel.Text & "','" & txtDireccion.Text & "','" & Cliente & "','" & Shpr & "','" & Prov & "')"
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
            sql = "UPDATE CONTACTOS SET NOMBRE='" & tbxContacto.Text & "', EMAIL='" & tbxEmail.Text & "',TELEFONO='" & tbxTel.Text & "',CELULAR='" & tbxCel.Text & "'" & _
                  ",DIRECCION='" & txtDireccion.Text & "', CODCLIEN='" & Cliente & "',CODSHPR='" & Shpr & "',CODPROV='" & Prov & "' WHERE CODCONTACTO=" & dgvContacto.CurrentRow.Cells("CODCONTACTODataGridViewTextBoxColumn").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()

        End If
        Me.CONTACTOSTableAdapter.Fill(Me.DsContactos.CONTACTOS)
        CONTACTOSBindingSource1.Position = dgvContacto.RowCount - 1
        DesHabilitar()
    End Sub

    Private Sub lblEliminar_Click(sender As System.Object, e As System.EventArgs) Handles pbxEliminarFicha.Click
        permiso = PermisoAplicado(UsuCodigo, 68)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en  esta ventana", "Pos Express")
            Exit Sub
        End If


        tbxContacto.Enabled = False
        'pnlCategorias.Enabled = True
        Nuevo = 3
        'Try
        If MessageBox.Show("¿Esta seguro que quiere ELIMINAR:" + tbxContacto.Text, "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Nuevo = 3 Then

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            sql = ""
            sql = "DELETE FROM CONTACTOS WHERE CODCONTACTO=" & dgvContacto.CurrentRow.Cells("CODCONTACTODataGridViewTextBoxColumn").Value
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
            sqlc.Close()
        End If


        DesHabilitar()
        CONTACTOSTableAdapter.Fill(DsContactos.CONTACTOS)
    End Sub

    Private Sub DesHabilitar()
        tbxContacto.Enabled = False
        txtDireccion.Enabled = False
        tbxTel.Enabled = False
        tbxCel.Enabled = False
        tbxEmail.Enabled = False

        dgvContacto.Enabled = True
        BuscarTextBox.Enabled = True
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

        'cbxCliente.Enabled = True
        'cbxShpr.Enabled = True
        'cbxProv.Enabled = True

        'tbxContacto.Enabled = True
        'tbxEmail.Enabled = True
        'tbxTel.Enabled = True
        'tbxCel.Enabled = True
        'txtDireccion.Enabled = True

        Nuevo = 2
        tbxContacto.Focus()
        Habilitar()
    End Sub

    Private Sub lblCancelar_Click(sender As Object, e As System.EventArgs) Handles pbxCancelar.Click
        Try
            If dgvContacto.Rows.Count > 0 Then
                Me.CONTACTOSBindingSource1.CancelEdit()
                Me.CONTACTOSTableAdapter.Fill(DsContactos.CONTACTOS)
                CONTACTOSBindingSource1.Position = dgvContacto.RowCount - 1
            End If
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Ocurrió un Error Durante la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        'pnlCategorias.Enabled = True
        DesHabilitar()
    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged
        Me.CONTACTOSBindingSource1.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%'"
    End Sub

    Private Sub Contactos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' Proyectos.CONTACTOTableAdapter.Fill(Proyectos.DsEventos.CONTACTO)
        'Proyectos.CONTACTOSTableAdapter.Fill(Proyectos.DsEventos.CONTACTOS)
        'Proyectos.CONTACTOS1TableAdapter.Fill(Proyectos.DsEventos.CONTACTOS1, Shpr)
        'Proyectos.CONTACTOS2TableAdapter.Fill(Proyectos.DsEventos.CONTACTOS2, Prov)
    End Sub

    Private Sub rbtCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCliente.CheckedChanged
        If rbtCliente.Checked = True Then
            cbxCliente.Enabled = True

        Else
            cbxCliente.Enabled = False
            cbxShpr.Enabled = False
            cbxProv.Enabled = False
        End If
    End Sub

    Private Sub rbtShpr_CheckedChanged(sender As Object, e As EventArgs) Handles rbtShpr.CheckedChanged
        If rbtShpr.Checked = True Then
            cbxShpr.Enabled = True

        Else
            cbxCliente.Enabled = False
            cbxShpr.Enabled = False
            cbxProv.Enabled = False
        End If
    End Sub

    Private Sub rbtProv_CheckedChanged(sender As Object, e As EventArgs) Handles rbtProv.CheckedChanged
        If rbtProv.Checked = True Then
            cbxProv.Enabled = True

        Else
            cbxCliente.Enabled = False
            cbxShpr.Enabled = False
            cbxProv.Enabled = False
        End If
    End Sub

    Private Sub pbxVerCliente_Click(sender As Object, e As EventArgs) Handles pbxVerCliente.Click
        ClientesV2.Show()
        ClientesV2.BuscarTextBox.Text = cbxCliente.Text
    End Sub

    Private Sub pbxVerShpr_Click(sender As Object, e As EventArgs) Handles pbxVerShpr.Click
        ShprCnee.Show()
        ShprCnee.BuscarTextBox.Text = cbxShpr.Text
    End Sub

    Private Sub pbxVerProv_Click(sender As Object, e As EventArgs) Handles pbxVerProv.Click
        Proveedor.Show()
        Proveedor.BuscarProveedorTextBox.Text = cbxProv.Text
    End Sub

    Private Sub cbxCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCliente.SelectedIndexChanged
        Cliente = cbxCliente.SelectedValue
    End Sub

    Private Sub cbxShpr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxShpr.SelectedIndexChanged
        Shpr = cbxShpr.SelectedValue
    End Sub

    Private Sub cbxProv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProv.SelectedIndexChanged
        Prov = cbxProv.SelectedValue
    End Sub
End Class