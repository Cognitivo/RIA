Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class CentroDeCosto

    #Region "Fields"

    Dim anu As Integer
    Private cmd As SqlCommand
    Dim del As Integer
    Dim permiso As Double
    '#################### Para los permisos de usuarios ####################################################################
    Dim dr As SqlDataReader

    '#####################################################################
    'variables para Guardar
    Dim Enlazado, CostoFijo, MateriaPrima, Existe, Prioridad As Integer

    '#################Variables de conexion usadas en la transaccion######
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

    Private Sub ActualizaCentroCosto()
        Dim Existe As Integer
        Dim w As New Funciones.Funciones

        Existe = w.FuncionConsulta("CODCENTRO", "CENTROCOSTO", "CODCENTRO", CodCentroTextBox.Text)

        If Existe > 0 Then
            'SE ACTUALIZA
            sql = ""
            sql = "update CENTROCOSTO set CODUSUARIO = " & UsuCodigo & ", CODEMPRESA = " & EmpCodigo & ",  CODSUCURSAL = " & SucCodigo & ",  NUMCENTRO = '" & CodCentroTextBox.Text & "', FECGRA = CONVERT(DATETIME, '" & Today & "', 103), DESCENTRO = '" & DesCentroTextBox.Text & "', ENLAZADO = " & Enlazado & ", COSTOFIJO = " & CostoFijo & ", CONCEPTO = '" & ConceptoTextBox.Text & "', MATERIAPRIMA = " & MateriaPrima & ", PRIORIDAD = " & Prioridad & " where CODCENTRO = " & CodCentroTextBox.Text & ""
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            AUDITORIAMODIFICA()
        Else
            'SE INSERTA
            sql = ""
            sql = "insert into CENTROCOSTO (CODCENTRO, CODUSUARIO, CODEMPRESA, CODSUCURSAL, NUMCENTRO, DESCENTRO, FECGRA, ENLAZADO, COSTOFIJO, CONCEPTO, MATERIAPRIMA, PRIORIDAD) VALUES ( " & CodCentroTextBox.Text & ", " & UsuCodigo & ", " & EmpCodigo & ", " & SucCodigo & ", '" & CodCentroTextBox.Text & "', '" & DesCentroTextBox.Text & "', CONVERT(DATETIME, '" & Today & "', 103 ), " & Enlazado & ", " & CostoFijo & ", '" & ConceptoTextBox.Text & "', " & MateriaPrima & ", " & Prioridad & ")"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            AUDITORIAINSERTA()
        End If
    End Sub

    Private Sub AUDITORIAELIMINA()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1

        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'CENTROCOSTO', '" & CODIGO & "',  'ELIMINACIÓN EN TABLA CENTRO DE COSTO' , CONVERT(DATETIME, '" & Today & "', 103 ), '" & UsuDescripcion & "', Null , 0,  0 , 1 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAINSERTA()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1

        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'CENTROCOSTO', '" & CODIGO & "',  'INSERCIÓN EN TABLA CENTRO DE COSTO' , CONVERT(DATETIME, '" & Today & "', 103 ), '" & UsuDescripcion & "', Null , 1,  0 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub AUDITORIAMODIFICA()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1

        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'CENTROCOSTO', '" & CODIGO & "',  'ACTUALIZACIÓN EN TABLA CENTRO DE COSTO' , CONVERT(DATETIME, '" & Today & "', 103 ), '" & UsuDescripcion & "', Null , 0,  1 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub BuscarChoferTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarChoferTextBox.GotFocus
        If BuscarChoferTextBox.Text = "Buscar..." Then
            BuscarChoferTextBox.Text = ""
        End If
    End Sub

    Private Sub BuscarChoferTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarChoferTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CentroCostoGridView.Focus()
        End If
    End Sub

    Private Sub BuscarChoferTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscarChoferTextBox.LostFocus
        If BuscarChoferTextBox.Text = "" Then
            BuscarChoferTextBox.Text = "Buscar..."
        End If
    End Sub

    Private Sub BuscarChoferTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarChoferTextBox.TextChanged
        If BuscarChoferTextBox.Text <> "Buscar..." Then
            Dim Filtro As New FilterExpression()
            Filtro.Predicates.Add(FilterExpression.BinaryOperation.[OR], GridKnownFunction.Contains, GridFilterCellElement.ParameterName)
            Filtro.Parameters.Add(GridFilterCellElement.ParameterName, BuscarChoferTextBox.Text)
            Me.CentroCostoGridView.Columns("DESCENTRO").Filter = Filtro
        End If
    End Sub

    Private Sub CancelarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarPictureBox.Click
        CENTROCOSTOBindingSource.CancelEdit()
        DeshabilitaControles()

    End Sub

    Private Sub CancelarPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseLeave, ModificarPictureBox.MouseLeave, CancelarPictureBox.MouseLeave, GuardarPictureBox.MouseLeave, EliminarPictureBox.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub CentroDeCosto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Proveedor.CENTROCOSTOTableAdapter.Fill(Proveedor.DsProveedores.CENTROCOSTO)
    End Sub

    Private Sub CentroDeCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 119)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If

        Me.CENTROCOSTOTableAdapter.Fill(Me.DsCentroDeCosto.CENTROCOSTO)

        DeshabilitaControles()
        'pOR EL MOMENTO
        If UsuCodigo = Nothing Then
            UsuCodigo = 1
        End If

        If EmpCodigo = Nothing Then
            EmpCodigo = 1
        End If

        If SucCodigo = Nothing Then
            SucCodigo = 1
        End If

        If UsuDescripcion = Nothing Then
            UsuDescripcion = "ASHAH"
        End If
    End Sub

    Private Sub ConceptoTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ConceptoTextBox.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                EnlazadoCheckBox.Focus()
                e.Handled = True
            Case Keys.Down
                DesCentroTextBox.Focus()
                e.Handled = True
        End Select
    End Sub

    Private Sub ConceptoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptoTextBox.TextChanged
    End Sub

    Private Sub CostoFijoCheckBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CostoFijoCheckBox.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                DesCentroTextBox.Focus()
                e.Handled = True
            Case Keys.Down
                EnlazadoCheckBox.Focus()
                e.Handled = True
        End Select
    End Sub

    Private Sub DesCentroTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DesCentroTextBox.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                ConceptoTextBox.Focus()
                e.Handled = True
            Case Keys.Down
                CostoFijoCheckBox.Focus()
                e.Handled = True
        End Select
    End Sub

    Private Sub DesCentroTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DesCentroTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ConceptoTextBox.Focus()
        End If
    End Sub

    Private Sub DesCentroTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DesCentroTextBox.LostFocus, ConceptoTextBox.LostFocus, CostoFijoCheckBox.LostFocus, EnlazadoCheckBox.LostFocus, CentroCostoGridView.LostFocus
        PanelFocoRango.Visible = False
    End Sub

    Private Sub DeshabilitaControles()

        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Cursor = Cursors.Hand
        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Cursor = Cursors.Hand
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        PrioridadCheckBox.Enabled = False
        DesCentroTextBox.ReadOnly = True
        ConceptoTextBox.ReadOnly = True
        EnlazadoCheckBox.Enabled = False
        CostoFijoCheckBox.Enabled = False

        'DesCentroTextBox.Focus()
        CentroCostoGridView.Enabled = True
        CentroCostoGridView.Focus()
    End Sub

    Private Sub EliminaCentroCosto()
        sql = ""
        sql = " DELETE FROM CENTROCOSTO " & _
        " WHERE CODCENTRO= " & CodCentroTextBox.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

        AUDITORIAELIMINA()
    End Sub

    Private Sub ELIMINAR()
        If CodCentroTextBox.Text = "" Then
            Exit Sub
        End If
        If MessageBox.Show("¿Esta seguro que quiere eliminar el Centro de Costo?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim w As New Funciones.Funciones
        Dim existe As Integer
        existe = w.FuncionConsulta("CODCENTRO", "CENTROCOSTO", "CODCENTRO", CodCentroTextBox.Text)
        If existe <> 0 Then

            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try

                EliminaCentroCosto()

                myTrans.Commit()
                '  Me.CLIENTESTableAdapter.Fill(DsConta.CLIENTES, "%", "%", "%", "%")
                CENTROCOSTOTableAdapter.Fill(DsCentroDeCosto.CENTROCOSTO)
                MessageBox.Show("Centro de Costo eliminado correctamente", "POSEXPRESS")

            Catch ex As Exception
                Try
                    myTrans.Rollback("Eliminar")
                Catch

                End Try
                MessageBox.Show(DesCentroTextBox.Text + " está siendo utilizado por el Sistema y No se puede Eliminar ", "POSEXPRESS")
            Finally
                sqlc.Close()
            End Try
        Else
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 121)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en esta ventana", "Pos Express")
            Exit Sub
        End If
        ELIMINAR()
        CentroCostoGridView.Focus()
        DeshabilitaControles()

    End Sub



    Private Sub EnlazadoCheckBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EnlazadoCheckBox.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                CostoFijoCheckBox.Focus()
                e.Handled = True
            Case Keys.Down
                ConceptoTextBox.Focus()
                e.Handled = True
        End Select
    End Sub

    Private Sub GUARDAR()
        'validamos
        If CodCentroTextBox.Text = "" Then
            Exit Sub
        End If

        If DesCentroTextBox.Text = "" Then
            MessageBox.Show("Ingrese la Descripcion del Centro de Costo", "POSEXPRESS")
            DesCentroTextBox.Focus()
            Exit Sub
        End If

        'Pasamos los Valores de los Check
        If PrioridadCheckBox.Checked = True Then
            Prioridad = 1
        Else
            Prioridad = 0
        End If

        If EnlazadoCheckBox.Checked = True Then
            Enlazado = 1
        Else
            Enlazado = 0
        End If

        If CostoFijoCheckBox.Checked = True Then
            CostoFijo = 1
        Else
            CostoFijo = 0
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "ActualizarCentro")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try

            ActualizaCentroCosto()
            If Prioridad = 1 Then
                'SACAMOS LA RPIORIDAD EN LOS DEMAS
                SacaPrioridad()
            End If

            myTrans.Commit()

            CentroCostoGridView.Refresh()
            Dim I As Integer = CENTROCOSTOBindingSource.Position
            CENTROCOSTOTableAdapter.Fill(DsCentroDeCosto.CENTROCOSTO)
            CENTROCOSTOBindingSource.Position = I

            DeshabilitaControles()

            CentroCostoGridView.Enabled = True

        Catch ex As Exception
            Try
                myTrans.Rollback("ActualizarCentro")
            Catch

            End Try
            MessageBox.Show("Error al Guardar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub GuardarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarPictureBox.Click
        GuardarPictureBox.Image = My.Resources.SaveActive
        GUARDAR()
        CentroCostoGridView.Focus()
        DeshabilitaControles()
    End Sub

    Private Sub HabilitaControles()

        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Image = My.Resources.NewOff
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

        PrioridadCheckBox.Enabled = True
        DesCentroTextBox.ReadOnly = False
        ConceptoTextBox.ReadOnly = False
        EnlazadoCheckBox.Enabled = True
        CostoFijoCheckBox.Enabled = True

        DesCentroTextBox.Focus()
        CentroCostoGridView.Enabled = False
    End Sub



    Private Sub ModificarPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 122)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar en esta ventana", "Pos Express")
            Exit Sub
        End If
        HabilitaControles()
        ModificarPictureBox.Image = My.Resources.EditActive
    End Sub

    Private Sub Nuevo()
        EnlazadoCheckBox.Checked = False
        CostoFijoCheckBox.Checked = False

        CENTROCOSTOBindingSource.AddNew()

        CentroCostoGridView.Enabled = False
        HabilitaControles()
    End Sub

    Private Sub NuevoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 120)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Nuevo()
        NuevoPictureBox.Image = My.Resources.NewActive
    End Sub

    Private Sub NuevoPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoPictureBox.MouseEnter, ModificarPictureBox.MouseEnter, CancelarPictureBox.MouseEnter, GuardarPictureBox.MouseEnter, EliminarPictureBox.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub panelfococontrol(ByVal control As Control, ByVal panelfoco As Panel)
        Dim ancho, largo As Integer
        Dim x, y As Integer
        With control
            panelfoco.Visible = True
            ancho = .Width + 2
            largo = .Height + 2
            x = .Location.X - 1
            y = .Location.Y - 1
        End With
        panelfoco.SetBounds(x, y, ancho, largo)
    End Sub

    Private Sub SacaPrioridad()
        sql = ""
        sql = "update CENTROCOSTO set  PRIORIDAD = 0 where CODCENTRO <> " & CodCentroTextBox.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    #End Region 'Methods
End Class