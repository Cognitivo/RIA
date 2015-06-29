Imports System.Data.SqlClient

Public Class ABMSmtp

    #Region "Fields"

    Private cmd As SqlCommand
    Dim Existe As String
    Dim permiso As Double
    '***Variables de conexion usadas en la transaccion**********************
    Dim filename As String
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Private sqlc As SqlConnection
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
    'usar la imaginacion
    Private Sub ABMSmtp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 109)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If
        Me.SMTPTableAdapter.Fill(Me.DsSMTP.SMTP)

        Habilita()
    End Sub

    Private Sub ActualizaSMTP()
        sql = ""
        sql = "update SMTP set SERVIDORSMTP = '" & ServidorSMTPTextBox.Text & "'," & _
              "PUERTO = '" & PuertoTextBox.Text & "', USUARIO = '" & UsuarioTextBox.Text & "', " & _
              "CONTRASENHA = '" & PassTextBox.Text & "', REMITENTE = '" & RemitenteTextBox.Text & "' " & _
              "where CODSMTP = " & CDec(CodSMTPTextBox.Text) & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub BuscarTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.GotFocus
        If BuscarTextBox.Text = "Buscar..." Then
            BuscarTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarTextBox.LostFocus
        If BuscarTextBox.Text = "" Then
            BuscarTextBox.Text = "Buscar..."
        End If
    End Sub

    Private Sub BuscarTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarTextBox.TextChanged
        If BuscarTextBox.Text <> "Buscar..." Then
            Me.SMTPBindingSource.Filter = "SERVIDORSMTP LIKE '%" & BuscarTextBox.Text & "%' "
        End If
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        SMTPBindingSource.CancelEdit()
        Habilita()
    End Sub

    Private Sub CancelarPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.MouseLeave, NuevoPictureBox.MouseLeave, GuardarPictureBox.MouseLeave, ModificarPictureBox.MouseLeave, EliminarPictureBox.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Deshabilita()
        SMTPRadGridView.Enabled = False
        BuscarTextBox.Enabled = False

        ServidorSMTPTextBox.Enabled = True
        ServidorSMTPTextBox.Focus()
        PuertoTextBox.Enabled = True
        UsuarioTextBox.Enabled = True
        RemitenteTextBox.Enabled = True
        PassTextBox.Enabled = True
        ConfirmapassTextBox.Visible = True
        ConfLabel.Visible = True
        ConfirmapassTextBox.Text = ""

        'Botonera
        GuardarPictureBox.Visible = True
        NuevoGrisPictureBox.BringToFront()
        EliminarGrisPictureBox.BringToFront()
        CancelarPictureBox.BringToFront()

        EditablePictureBox.BringToFront()
    End Sub

    Private Sub Eliminar()
        If CodSMTPTextBox.Text = "" Then
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere eliminar el ServidorSMTP?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            EliminarServidor()

            ' AUDITORIAELIMINA()

            myTrans.Commit()

            Me.SMTPTableAdapter.Fill(Me.DsSMTP.SMTP)
            SMTPBindingSource.MoveLast()
            'RecorreCompra()

            MessageBox.Show("ServidorSMTP eliminado correctamente", "POSEXPRESS")
            Habilita()
        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch

            End Try
            MessageBox.Show("El Email está siendo utilizado por el Sistema y no se puede Eliminar ", "POSEXPRESS")

        Finally
            sqlc.Close()

        End Try
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 111)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If
        Eliminar()
    End Sub

    Private Sub EliminarServidor()
        sql = ""
        sql = "DELETE FROM SMTP WHERE CODSMTP = " & CodSMTPTextBox.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Guardar()
        'Validamos
        If CodSMTPTextBox.Text = "" Then
            Exit Sub
        End If

        If ServidorSMTPTextBox.Text = "" Then
            MessageBox.Show("Ingrese el Servidor SMTP", "POSEXPRESS")
            ServidorSMTPTextBox.Focus()
            Exit Sub
        End If

        If PuertoTextBox.Text = "" Then
            MessageBox.Show("Ingrese el Nro de Puerto", "POSEXPRESS")
            PuertoTextBox.Focus()
            Exit Sub
        End If

        If UsuarioTextBox.Text = "" Then
            MessageBox.Show("Ingrese el Usuario", "POSEXPRESS")
            UsuarioTextBox.Focus()
            Exit Sub
        End If

        If PassTextBox.Text = "" Then
            MessageBox.Show("Ingrese la Contraseña del Usuario", "POSEXPRESS")
            PassTextBox.Focus()
            Exit Sub
        End If

        If PassTextBox.Text <> ConfirmapassTextBox.Text Then
            MessageBox.Show("Las Contraseñas no coinciden", "POSEXPRESS")
            PassTextBox.Focus()
            Exit Sub
        End If

        Existe = w.FuncionConsulta("CODSMTP", "SMTP", "CODSMTP", CodSMTPTextBox.Text)

        Dim transaction As SqlTransaction = Nothing

        If existe > 0 Then
            '###################################################################
            'ACTUALIZAR: si existe el codigo de la Compra actualiza
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                ActualizaSMTP()

                ' AUDITORIAMODIFICA()

                myTrans.Commit()
                Dim I As Integer = SMTPBindingSource.Position
                SMTPTableAdapter.Fill(DsSMTP.SMTP)
                SMTPBindingSource.Position = I

                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")
                Habilita()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Actualizar")
                Catch

                End Try
                MessageBox.Show("Ocurrio un error al intentar actualizar el ServidorSMTP" + ex.Message, "POSEXPRESS")

            Finally
                sqlc.Close()

            End Try
            ' DeshabilitaControles()
        Else
            '############################################################################
            'INSERTAR: si el codigo es nuevo inserta

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                InsertaSMTP()

                '   AUDITORIAINSERTA()

                myTrans.Commit()

                SMTPTableAdapter.Fill(DsSMTP.SMTP)
                SMTPBindingSource.MoveLast()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")
                Habilita()

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
                MessageBox.Show("Ocurrió un error al insertar el Servidor", "POSEXPRESS")

            Finally
                sqlc.Close()
            End Try

        End If
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 112)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Guardar en esta ventana", "Pos Express")
            Exit Sub
        End If
        Guardar()
    End Sub

    Private Sub Habilita()
        SMTPRadGridView.Enabled = True
        BuscarTextBox.Enabled = True

        ServidorSMTPTextBox.Enabled = False
        PuertoTextBox.Enabled = False
        UsuarioTextBox.Enabled = False
        RemitenteTextBox.Enabled = False
        PassTextBox.Enabled = False
        ConfirmapassTextBox.Visible = False
        ConfLabel.Visible = False

        'Botonera
        GuardarPictureBox.Visible = False
        NuevoPictureBox.BringToFront()
        EliminarPictureBox.BringToFront()
        ModificarPictureBox.BringToFront()

        BloqueoPictureBox.BringToFront()
    End Sub

    Private Sub InsertaSMTP()
        sql = ""
        sql = "INSERT INTO SMTP (CODSMTP, SERVIDORSMTP, PUERTO, USUARIO, CONTRASENHA, REMITENTE) VALUES " & _
        "(" & CodSMTPTextBox.Text & ", '" & ServidorSMTPTextBox.Text & "', '" & PuertoTextBox.Text & "', " & _
        " '" & UsuarioTextBox.Text & "', '" & PassTextBox.Text & "', '" & RemitenteTextBox.Text & "')"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        If CodSMTPTextBox.Text <> "" Then
            Deshabilita()
        End If
    End Sub

    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 110)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        SMTPBindingSource.AddNew()
        Deshabilita()
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter, GuardarPictureBox.MouseEnter, CancelarPictureBox.MouseEnter, ModificarPictureBox.MouseEnter, EliminarPictureBox.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PassTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PassTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Try
                ConfirmapassTextBox.Focus()
                KeyAscii = 0
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PuertoTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PuertoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            RemitenteTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub PuertoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PuertoTextBox.TextChanged
    End Sub

    Private Sub RemitenteTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RemitenteTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            UsuarioTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub RemitenteTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemitenteTextBox.TextChanged
    End Sub

    Private Sub ServidorSMTPTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ServidorSMTPTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            PuertoTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub UsuarioTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UsuarioTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            PassTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub UsuarioTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuarioTextBox.TextChanged
    End Sub

    #End Region 'Methods

End Class