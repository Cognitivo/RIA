Imports System.Data.SqlClient

Public Class Eventos

    #Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand
    Dim del As Integer
    Dim permiso As Double
    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader
    Dim Existe, Estado As String

    'Variables de Transaccion
    Dim filename As String
    Dim ins As Integer
    Private myTrans As SqlTransaction
    Dim pri As Integer
    Dim sel As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Private sqlc As SqlConnection
    Dim upd As Integer
    Dim w As New Funciones.Funciones

    #End Region 'Fields

    #Region "Constructors"

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    #End Region 'Constructors

    #Region "Methods"

    Private Sub ActualizaEvento()
        sql = ""
        sql = "UPDATE EVENTO SET NUMEVENTO ='" & DescripcionTextBox.Text & "', DESCEVENTO='" & DescripcionTextBox.Text & "',ESTADO=" & Estado & " " & _
              "WHERE CODEVENTO= " & CDec(CodEventoTextBox.Text) & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAELIMINAEvento()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'EVENTO', '" & CODIGO & "',  'ELIMINACION EN TABLA EVENTO' , CONVERT(DATETIME, getdate(), 103 ), '" & UsuDescripcion & "', Null , 0,  0 , 1 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAINSERTAEvento()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'EVENTO', '" & CODIGO & "',  'INSERCION EN TABLA EVENTO' , CONVERT(DATETIME, getdate(), 103 ), '" & UsuDescripcion & "', Null , 1,  0 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAMODIFICAEvento()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'EVENTO', '" & CODIGO & "',  'ACTUALIZACIÓN EN TABLA EVENTO' , CONVERT(DATETIME, getdate(), 103 ), '" & UsuDescripcion & "', Null , 0,  1 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub BuscarEventosTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarEventosTextBox.GotFocus
        If BuscarEventosTextBox.Text = "Buscar..." Then
            BuscarEventosTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarEventosTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarEventosTextBox.LostFocus
        If BuscarEventosTextBox.Text = "" Then
            BuscarEventosTextBox.Text = "Buscar..."
        End If
    End Sub

    Private Sub BuscarEventosTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarEventosTextBox.TextChanged
        If BuscarEventosTextBox.Text <> "Buscar..." Then
            Me.EVENTOBindingSource.Filter = "NUMEVENTO LIKE '%" & BuscarEventosTextBox.Text & "%'OR  DESCEVENTO like '%" & BuscarEventosTextBox.Text & "%' "
        End If
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        EVENTOBindingSource.CancelEdit()
        Deshabilita()
        EventosDataGridView_SelectionChanged(Nothing, Nothing)
    End Sub

    
    Private Sub Deshabilita()
        EventosDataGridView.Enabled = True
        BuscarEventosTextBox.Enabled = True

        EstadoComboBox.Enabled = False
        CodEventoTextBox.Enabled = False
        DescripcionTextBox.Enabled = False
        EstadoComboBox.Text = ""

        'Botonera
        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Cursor = Cursors.Hand
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Cursor = Cursors.Hand
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

    End Sub

    Private Sub ELIMINAR()
        If CodEventoTextBox.Text = "" Then
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere eliminar el Evento?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            EliminarEvento()

            ' AUDITORIAELIMINA()
            AUDITORIAELIMINAEvento()
            myTrans.Commit()

            Me.EVENTOTableAdapter.Fill(Me.DsEventos.EVENTO)
            EVENTOBindingSource.MoveLast()
            'RecorreCompra()

            MessageBox.Show("Evento eliminado correctamente", "POSEXPRESS")
            Deshabilita()
        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch

            End Try
            MessageBox.Show("El Evento está siendo utilizado por el Sistema y no se puede Eliminar ", "POSEXPRESS")

        Finally
            sqlc.Close()

        End Try
    End Sub

    Private Sub EliminarEvento()
        sql = ""
        sql = "delete from EVENTO WHERE CODEVENTO = " & CodEventoTextBox.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 129)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar este Estado", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ELIMINAR()
        EventosDataGridView_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub Eventos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 127)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Abrir esta Ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If
        Me.EVENTOTableAdapter.Fill(Me.DsEventos.EVENTO)
        Deshabilita()
        'arturo
        If EventosDataGridView.CurrentRow Is Nothing Then
        Else
            If EventosDataGridView.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 1 Then
                EstadoComboBox.Text = "Activo"
            ElseIf EventosDataGridView.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 0 Then
                EstadoComboBox.Text = "No Activo"
            Else
                EstadoComboBox.Text = ""
            End If

        End If
        'arturo DIOS TE AMA


    End Sub

    Private Sub GUARDAR()
        If CodEventoTextBox.Text = "" Then
            Exit Sub
        End If

        If DescripcionTextBox.Text = "" Then
            MessageBox.Show("El campo Descripción no puede quedar vacio", "POSEXPRESS")
            DescripcionTextBox.Focus()
            Exit Sub
        End If

        If EstadoComboBox.Text = "Activo" Then
            Estado = "1"
        ElseIf EstadoComboBox.Text = "No Activo" Then
            Estado = "0"
        End If

        Existe = w.FuncionConsulta("CODEVENTO", "EVENTO", "CODEVENTO", CDec(CodEventoTextBox.Text))


        If Existe > 0 Then
            '############################################################################
            'Actualizar la factura. Solo se puede actualizar si el estado de la factura es Activa=0

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try

                ActualizaEvento()
                'AUDITORIAS.
                AUDITORIAMODIFICAEvento()

                myTrans.Commit()
                MessageBox.Show("Operación finalizada con éxito", "POSEXPRESS")
                Dim J As Integer
                J = EVENTOBindingSource.Position

                Me.EVENTOTableAdapter.Fill(Me.DsEventos.EVENTO)

                EVENTOBindingSource.Position = J

                Deshabilita()
            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS")
                'Cancelamos todo :(
            Finally
                sqlc.Close()
            End Try
        Else
            '############################################################################
            'INSERTAR: si el codigo es nuevo inserta

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaEvento()
                'AUDITORIAS.
                AUDITORIAINSERTAEvento()

                myTrans.Commit()
                MessageBox.Show("Operación finalizada con éxito", "POSEXPRESS")

                Me.EVENTOTableAdapter.Fill(Me.DsEventos.EVENTO)
                EVENTOBindingSource.MoveLast()
                'AUDITORIAS.

                Deshabilita()
            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error en la Operación", "POSEXPRESS")
                'Cancelamos todo :(
            Finally
                sqlc.Close()
            End Try

        End If
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 130)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Guardar en esta ventana", "Pos Express")
            Exit Sub
        End If
        GUARDAR()
        EventosDataGridView_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub Habilita()
        EventosDataGridView.Enabled = False
        BuscarEventosTextBox.Enabled = False

        EstadoComboBox.Enabled = True
        CodEventoTextBox.Enabled = True
        DescripcionTextBox.Enabled = True
        EstadoComboBox.Enabled = True

        'Botonera
        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Cursor = Cursors.Arrow
        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Image = My.Resources.DeleteOff
        EliminarPictureBox.Cursor = Cursors.Arrow
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand
        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        GuardarPictureBox.Cursor = Cursors.Hand

        DescripcionTextBox.Focus()
    End Sub

    Private Sub InsertaEvento()
        sql = ""
        sql = "INSERT INTO EVENTO (CODEVENTO, NUMEVENTO, DESCEVENTO, CODUSUARIO, CODEMPRESA, ESTADO) VALUES " & _
              "( " & CodEventoTextBox.Text & ", '" & DescripcionTextBox.Text & "', '" & DescripcionTextBox.Text & "', " & UsuCodigo & ", " & EmpCodigo & ", " & _
              " " & Estado & ") "
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 130)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar en esta ventana", "Pos Express")
            Exit Sub
        End If
        Habilita()
    End Sub

    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 128)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        EVENTOBindingSource.AddNew()
        EstadoComboBox.Text = "Activo"
        Habilita()
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter, EliminarPictureBox.MouseEnter, CancelarPictureBox.MouseEnter, ModificarPictureBox.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub NuevoPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseLeave, EliminarPictureBox.MouseLeave, CancelarPictureBox.MouseLeave, ModificarPictureBox.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    #End Region 'Methods

    Private Sub EstadoComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoComboBox.SelectedIndexChanged

    End Sub


    Private Sub EventosDataGridView_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EventosDataGridView.CellContentClick

    End Sub

    Private Sub EventosDataGridView_SelectionChanged(sender As Object, e As System.EventArgs) Handles EventosDataGridView.SelectionChanged

        If EventosDataGridView.CurrentRow Is Nothing Then
        Else
            If EventosDataGridView.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value Is DBNull.Value Then
            Else
                If EventosDataGridView.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 1 Then
                    EstadoComboBox.Text = "Activo"
                ElseIf EventosDataGridView.CurrentRow.Cells("ESTADODataGridViewTextBoxColumn").Value = 0 Then
                    EstadoComboBox.Text = "No Activo"
                Else
                    EstadoComboBox.Text = ""
                End If
            End If
        End If

    End Sub
End Class