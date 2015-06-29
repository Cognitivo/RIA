Imports System.Data.SqlClient

Public Class Metas

    #Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand
    Dim Comision, Existe, Estado, Meta As String
    Dim del As Integer

    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader

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
    Dim permiso As Double
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

    Private Sub ActualizaMeta()
        sql = ""
        sql = "UPDATE METAS SET DESCRIPCIONMETA='" & DescripcionTextBox.Text & "',TIPO='" & TipoTextBox.Text & "', " & _
              "PORCENTAJECOMISION=" & Comision & ", META = " & Meta & ",  ESTADO=" & Estado & " " & _
              "WHERE CODMETA= " & CDec(CodMetaTextBox.Text) & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAELIMINAMeta()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'METAS', '" & CODIGO & "',  'ELIMINACION EN TABLA METAS' , CONVERT(DATETIME, getdate(), 103 ), '" & UsuDescripcion & "', Null , 0,  0 , 1 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAINSERTAMeta()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'METAS', '" & CODIGO & "',  'INSERCION EN TABLA METAS' , CONVERT(DATETIME, getdate(), 103 ), '" & UsuDescripcion & "', Null , 1,  0 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAMODIFICAMeta()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'METAS', '" & CODIGO & "',  'ACTUALIZACIÓN EN TABLA METAS' , CONVERT(DATETIME, getdate(), 103 ), '" & UsuDescripcion & "', Null , 0,  1 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub BuscarMetasTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarMetasTextBox.GotFocus
        If BuscarMetasTextBox.Text = "Buscar..." Then
            BuscarMetasTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarMetasTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarMetasTextBox.LostFocus
        If BuscarMetasTextBox.Text = "" Then
            BuscarMetasTextBox.Text = "Buscar..."
        End If
    End Sub

    Private Sub BuscarMetasTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarMetasTextBox.TextChanged
        If BuscarMetasTextBox.Text <> "Buscar..." Then
            Me.METASBindingSource.Filter = "DESCRIPCIONMETA LIKE '%" & BuscarMetasTextBox.Text & "%'OR TIPO LIKE '%" & BuscarMetasTextBox.Text & "%' "
        End If
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        METASBindingSource.CancelEdit()
        Deshabilita()
    End Sub

    
    Private Sub Deshabilita()
        MetasDataGridView.Enabled = True
        BuscarMetasTextBox.Enabled = True

        DescripcionTextBox.Enabled = False
        TipoTextBox.Enabled = False
        PorComisionTextBox.Enabled = False
        EstadoComboBox.Enabled = False
        MetaMaskedEdit.Enabled = False

        'Botonera
        GuardarPictureBox.Visible = False
        NuevoPictureBox.BringToFront()
        EliminarPictureBox.BringToFront()
        ModificarPictureBox.BringToFront()

        BloqueoPictureBox.BringToFront()
    End Sub

    Private Sub ELIMINAR()
        If CodMetaTextBox.Text = "" Then
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere eliminar la Meta?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            EliminaRDevolucion()

            ' AUDITORIAELIMINA()
            AUDITORIAELIMINAMeta()
            myTrans.Commit()

            Me.METASTableAdapter.Fill(Me.DsMetas.METAS)
            METASBindingSource.MoveLast()
            'RecorreCompra()

            MessageBox.Show("Meta eliminada correctamente", "POSEXPRESS")
            Deshabilita()
        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch

            End Try
            MessageBox.Show(" La Meta está siendo utilizado por el Sistema y no se puede Eliminar ", "POSEXPRESS")

        Finally
            sqlc.Close()

        End Try
    End Sub

    Private Sub EliminaRDevolucion()
        sql = ""
        sql = "delete from METAS WHERE CODMETA = " & CodMetaTextBox.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 125)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If
        ELIMINAR()
    End Sub

    Private Sub EstadoComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoComboBox.SelectedIndexChanged
        Try
            If EstadoComboBox.Text = "Activo" Then
                EstadoTextBox.Text = "1"
            ElseIf EstadoComboBox.Text = "No Activo" Then
                EstadoTextBox.Text = "0"
            Else
                EstadoTextBox.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoTextBox.TextChanged
        If EstadoTextBox.Text = "1" Then
            EstadoComboBox.Text = "Activo"
        ElseIf EstadoTextBox.Text = "0" Then
            EstadoComboBox.Text = "No Activo"
        Else
            EstadoComboBox.Text = ""
        End If
    End Sub

    Private Sub GUARDAR()
        If CodMetaTextBox.Text = "" Then
            Exit Sub
        End If

        If DescripcionTextBox.Text = "" Then
            MessageBox.Show("El campo Descripción no puede quedar vacio", "POSEXPRESS")
            DescripcionTextBox.Focus()
            Exit Sub
        End If

        If TipoTextBox.Text = "" Then
            MessageBox.Show("El campo Tipo no puede quedar vacio", "POSEXPRESS")
            TipoTextBox.Focus()
            Exit Sub
        End If

        If PorComisionTextBox.Text = Nothing Then
            MessageBox.Show("El campo % Comisión no puede quedar vacio", "POSEXPRESS")
            PorComisionTextBox.Focus()
            Exit Sub
        End If

        If MetaMaskedEdit.Text = Nothing Then
            MessageBox.Show("El campo Meta no puede quedar vacio", "POSEXPRESS")
            MetaMaskedEdit.Focus()
            Exit Sub
        End If

        'Validar
        Comision = PorComisionTextBox.Text
        Comision = Funciones.Cadenas.QuitarCad(Comision, ".")
        Comision = Replace(Comision, ",", ".")

        Meta = MetaMaskedEdit.Text
        Meta = Funciones.Cadenas.QuitarCad(Meta, ".")
        Meta = Replace(Meta, ",", ".")

        If EstadoTextBox.Text = "" Then
            Estado = "Null"
        Else
            Estado = EstadoTextBox.Text
        End If

        Existe = w.FuncionConsulta("CODMETA", "METAS", "CODMETA", CDec(CodMetaTextBox.Text))

        Dim transaction As SqlTransaction = Nothing

        If Existe > 0 Then
            '############################################################################
            'Actualizar la factura. Solo se puede actualizar si el estado de la factura es Activa=0

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try

                ActualizaMeta()
                'AUDITORIAS.
                AUDITORIAMODIFICAMeta()

                myTrans.Commit()
                MessageBox.Show("Operación finalizada con éxito", "POSEXPRESS")
                Dim J As Integer
                J = METASBindingSource.Position

                Me.METASTableAdapter.Fill(Me.DsMetas.METAS)

                METASBindingSource.Position = J

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
                InsertaMeta()
                'AUDITORIAS.
                AUDITORIAINSERTAMeta()

                myTrans.Commit()
                MessageBox.Show("Operación finalizada con éxito", "POSEXPRESS")

                Me.METASTableAdapter.Fill(Me.DsMetas.METAS)
                METASBindingSource.MoveLast()
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
        GUARDAR()
    End Sub

    Private Sub Habilita()
        MetasDataGridView.Enabled = False
        BuscarMetasTextBox.Enabled = False

        DescripcionTextBox.Enabled = True
        TipoTextBox.Enabled = True
        PorComisionTextBox.Enabled = True
        EstadoComboBox.Enabled = True
        MetaMaskedEdit.Enabled = True

        'Botonera
        GuardarPictureBox.Visible = True
        NuevoGrisPictureBox.BringToFront()
        EliminarGrisPictureBox.BringToFront()
        CancelarPictureBox.BringToFront()

        EditablePictureBox.BringToFront()
    End Sub

    Private Sub InsertaMeta()
        sql = ""
        sql = "INSERT INTO METAS (CODMETA, DESCRIPCIONMETA, PORCENTAJECOMISION, META, TIPO, CODUSUARIO, CODEMPRESA, FECGRA) VALUES " & _
              "( " & CodMetaTextBox.Text & ", '" & DescripcionTextBox.Text & "', " & Comision & ", " & Meta & ", " & _
              "' " & TipoTextBox.Text & "', " & UsuCodigo & ", " & EmpCodigo & ", CONVERT(DATETIME,'" & Today & "',103)) "
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Metas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 123)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If

        Me.METASTableAdapter.Fill(Me.DsMetas.METAS)

        Deshabilita()

        'POR AHORA
        If EmpCodigo = Nothing Then
            EmpCodigo = 1
        End If
        If SucCodigo = Nothing Then
            SucCodigo = 1
        End If


    End Sub

    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 126)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar en esta ventana", "Pos Express")
            Exit Sub
        End If
        Habilita()
        DescripcionTextBox.Focus()
    End Sub

    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 124)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express")
            Exit Sub
        End If
        METASBindingSource.AddNew()
        Habilita()
        DescripcionTextBox.Focus()
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter, EliminarPictureBox.MouseEnter, CancelarPictureBox.MouseEnter, ModificarPictureBox.MouseEnter, GuardarPictureBox.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub NuevoPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseLeave, EliminarPictureBox.MouseLeave, CancelarPictureBox.MouseLeave, ModificarPictureBox.MouseLeave, GuardarPictureBox.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    #End Region 'Methods

End Class