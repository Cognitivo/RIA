Imports System.Data.SqlClient
Imports Osuna.Utiles.Configuracion
Imports System.Configuration
Imports System.Deployment
Imports System.Windows.Forms
Imports System.IO

Public Class PeriodoFiscal

    'Dimensionamos la variable indice que no se para que era pero inicializamos para la tabla
    Dim Indice As Integer
    Private cmd As SqlCommand
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
    Dim permiso As Double

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub


    Private Sub PeriodoFiscal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 199)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        PeriodofiscalTableAdapter.Fill(DsPeriodoFiscal.periodofiscal, "%")
        FechaInicio.FechaDate = Today
        FechaFin.FechaDate = Today
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If BtnAgregar.Text = "Modificar" Then
            GridViewPeriodos.Rows(Indice).Cells("CODPERIODOFISCAL").Value = Txtcodperiodofiscal.Text
            GridViewPeriodos.Rows(Indice).Cells("DESEJERCICIO1").Value = TxtDescripcion.Text
            GridViewPeriodos.Rows(Indice).Cells("FechaInicio1").Value = FechaInicio.Text
            GridViewPeriodos.Rows(Indice).Cells("FechaFin1").Value = FechaInicio.Text
        Else
            If TxtDescripcion.Text = "" Then
                MessageBox.Show("Se necesita una descripcion para el ejercicio", "POSEXPRESS")
                TxtDescripcion.Focus()
                Exit Sub
            End If
            If FechaInicio.Text = "  /  /    " Then
                MessageBox.Show("Se necesita una fecha de inicio para el ejercicio", "POSEXPRESS")
                FechaInicio.Focus()
                Exit Sub
            End If
            If FechaFin.Text = "  /  /    " Then
                MessageBox.Show("Se necesita una fecha final para el ejercicio", "POSEXPRESS")
                FechaFin.Focus()
                'verifica si el dia de fin no es menor a la fecha de inicio
                Exit Sub
            Else
                If CDate(FechaInicio.Text) > CDate(FechaFin.Text) Then
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin", "POSEXPRESS")
                    FechaInicio.Focus()
                    Exit Sub
                End If
            End If
            'VERIFICA SI LA FECHA DE INICIO Y FIN NO ENTRA ENTRE UN VALOR DE FECHA INICIO EN LA BD
            Dim entra As Integer
            entra = w.CantidadRegistro("CODPERIODOFISCAL", "PERIODOFISCAL WHERE FECHAINICIO >= CONVERT(DATETIME,'" & FechaInicio.Text & "',103) " & _
                                     " AND FECHAINICIO <= CONVERT(DATETIME,'" & FechaFin.Text & "',103)")
            If entra > 0 Then
                MessageBox.Show("El rango de fechas coincide con otro periodo, verifique las fechas", "POSEXPRESS")
                FechaInicio.Focus()
                Exit Sub
            End If
            'VERIFICA SI LA FECHA DE INICIO Y FIN NO ENTRA ENTRE UN VALOR DE FECHA FIN EN LA BD
            entra = w.CantidadRegistro("CODPERIODOFISCAL WHERE FECHAFIN >= CONVERT(DATETIME,'" & FechaInicio.Text & "',103) " & _
                                     " AND FECHAFIN <= CONVERT(DATETIME,'" & FechaFin.Text & "',103)", "PERIODOFISCAL")
            If entra > 1 Then
                MessageBox.Show("El rango de fechas coincide con otro periodo, verifique las fechas", "POSEXPRESS")
                FechaFin.Focus()
                Exit Sub
            End If
            'Ingresa los datos en la tabla de periodo
            ser.Abrir(sqlc)
            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

            cmd.Connection = sqlc
            cmd.Transaction = myTrans
            Try
                cargaperiodo()
                myTrans.Commit()

                TxtDescripcion.Text = ""
                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POSEXPRESS")

                PeriodofiscalTableAdapter.Fill(DsPeriodoFiscal.periodofiscal, "%")
                PeriodofiscalBindingSource.MoveLast()

                'INSERTAMOS EN AUDITORIA 
                InsertaAuditoria(1, 0, 0)
                '#########################

            Catch ex As Exception
                Try
                    myTrans.Rollback("Insertar")
                Catch
                End Try
            End Try
        End If
    End Sub

    Private Sub cargaperiodo()
        ' Dim codperiodo, descri_periodo, fechainicio, fechafin As String

        sql = "DECLARE @CODIGO INT SELECT @CODIGO=ISNULL(MAX(CODPERIODOFISCAL ),0)+1 FROM periodofiscal " & _
        " INSERT INTO  PERIODOFISCAL (CODPERIODOFISCAL,FECHAINICIO,FECHAFIN,DESEJERCICIO)" & _
        " VALUES (@CODIGO, CONVERT(DATETIME, '" & FechaInicio.Text & "', 103), CONVERT(DATETIME, '" & FechaFin.Text & "', 103),'" & TxtDescripcion.Text & "')  "
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaAuditoria(ByVal Insertar As Integer, ByVal Modificar As Integer, ByVal Eliminar As Integer)
        Dim consulta, Accion As String
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        Accion = ""

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        If Insertar = 1 Then
            Accion = "INSERTO"
        ElseIf Modificar = 1 Then
            Accion = "MODIFICO"
        ElseIf Eliminar = 1 Then
            Accion = "ELIMINO"
        End If

        consulta = "INSERT INTO AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO,DESCRIPCION, FECHA, USUARIO,  INSERTAR, MODIFICAR, ELIMINAR)" & _
        "VALUES ( " & CODIGO & ", " & EmpCodigo & "," & "'PERIODO FISCAL', '" & Txtcodperiodofiscal.Text & "', " & "'" & Accion & " EN TABLA DE PERIODO FISCAL' , " & _
        "CONVERT(DATETIME,  getdate()), " & "'" & UsuDescripcion & "'," & Insertar & "," & Modificar & ", " & Eliminar & " )"

        cmd.CommandText = consulta
        cmd.ExecuteNonQuery()

        myTrans.Commit()

    End Sub

    Private Sub eliminaperiodo()
        ' Dim codperiodo, descri_periodo, fechainicio, fechafin As String
        Indice = GridViewPeriodos.CurrentRow.Index
        Txtcodperiodofiscal.Text = GridViewPeriodos.Rows(Indice).Cells("CODPERIODOFISCAL").Value
        sql = " delete from  PERIODOFISCAL where codperiodofiscal=" & Txtcodperiodofiscal.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If GridViewPeriodos.RowCount = 0 Then
            Exit Sub
        End If
        If MessageBox.Show("Esta seguro que desea eliminar el registro", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            TxtDescripcion.Focus()
            Exit Sub
        Else
            Try
                ser.Abrir(sqlc)
                cmd.Connection = sqlc
                eliminaperiodo()
                MessageBox.Show("El periodo ha sido borrado satisfactoriamente", "POSEXPRESS")
                PeriodofiscalTableAdapter.Fill(DsPeriodoFiscal.periodofiscal, "%")

                'INSERTAMOS EN AUDITORIA 
                InsertaAuditoria(0, 0, 1)
                '#########################

            Catch ex As Exception
                MessageBox.Show("Error al eliminar el detalle", "POSEXPRESS")
                Exit Sub
            Finally
                sqlc.Close()
            End Try
        End If
    End Sub

    Private Sub TxtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.GotFocus
        If TxtBuscar.Text = "Buscar..." Then
            TxtBuscar.Text = ""
        End If
    End Sub

    Private Sub TxtBuscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.LostFocus
        If TxtBuscar.Text = "" Then
            TxtBuscar.Text = "Buscar..."
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        If TxtBuscar.Text <> "Buscar..." Then
            PeriodofiscalTableAdapter.Fill(DsPeriodoFiscal.periodofiscal, "%" + TxtBuscar.Text + "%")
        End If
    End Sub

    Private Sub BtnEstablecerPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEstablecerPeriodo.Click
        If GridViewPeriodos.Rows.Count = 0 Then
            Exit Sub
        End If
        If IsDBNull(GridViewPeriodos.CurrentRow) Then
            MessageBox.Show("Seleccione el periodo ", "POSEXPRESS")
        End If
        ActivarPeriodo()
    End Sub

    Public Sub ActivarPeriodo()
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try

            sql = "UPDATE PERIODOFISCAL SET ESTADO = 0   UPDATE PERIODOFISCAL SET ESTADO = 1 WHERE CODPERIODOFISCAL = " & Me.GridViewPeriodos.CurrentRow.Cells("CODPERIODOFISCAL").Value

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()

            PeriodofiscalTableAdapter.Fill(DsPeriodoFiscal.periodofiscal, "%")

        Catch ex As Exception
            Try
                myTrans.Rollback("Insertar")
            Catch
            End Try
        End Try
    End Sub

End Class