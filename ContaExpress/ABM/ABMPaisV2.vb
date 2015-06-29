Imports System.Windows
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Public Class ABMPaisV2
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
    Dim Vglobal As Integer
    Dim Nuevo As Integer
    Dim permiso As Double
    Private Sub ABMPaisV2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 70)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Abrir esta ventana", "Pos Express")
            Me.Close()
            Exit Sub
        End If
        Me.ZONATableAdapter.Fill(Me.DsLocalidad.ZONA)
        Me.CIUDADTableAdapter.Fill(Me.DsLocalidad.CIUDAD)
        Me.PAISTableAdapter.Fill(Me.DsLocalidad.PAIS)
        Vglobal = 0
        tbxBuscarPais.Visible = True
        tbxBuscarCiudad.Visible = False
        tbxBuscarZona.Visible = False
        txtLocalidad.Enabled = False
        lblGuardar.Visible = False
        lblModificar.Visible = True
        lblCancelar.Visible = False
        cbxPrioridadCiudad.Enabled = False
        lblNuevo.Visible = True
        lblEliminar.Visible = True
        dgvCiudad.BackgroundColor = Color.DarkGray
        dgvPais.BackgroundColor = Color.DarkGray
        dgvZona.BackgroundColor = Color.DarkGray
        lblLocalidad.Text = "Países/Departamentos"
        Nuevo = 0
    End Sub
    Private Sub dgvPais_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvPais.SelectionChanged
        'If Vglobal = 1 Then
        '    Exit Sub
        'End If
        If (dgvPais.Rows.Count > 0) Then
            If dgvPais.CurrentRow.Cells("CODPAIS").Value Then
                '=========Filtro de Pais para Ciudad==============
                Dim Vpais As Integer = dgvPais.CurrentRow.Cells("CODPAIS").Value
                Dim VPriorPais As Integer = f.FuncionConsultaDecimal("PRIORIDAD", "PAIS", "CODPAIS", Vpais)

                Me.CIUDADBindingSource.Filter = "CODPAIS='" & Vpais & "'"
                If dgvCiudad.Rows.Count < 1 Then
                    Me.ZONABindingSource.Filter = "CODCIUDAD=NULL"
                End If
                lblLocalidad.Text = "Países/Departamentos"
                txtLocalidad.Text = dgvPais.CurrentRow.Cells("DESPAIS").Value
            End If
        End If
    End Sub


    Private Sub dgvCiudad_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvCiudad.SelectionChanged

        lblLocalidad.Text = "Ciudades"
        If (dgvCiudad.Rows.Count > 0) Then
            If dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value Then
                '=========Filtro de Ciudad para Zona==============
                Dim CIUDAD As Integer = dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value
                Dim VPriorCiudad As Integer = f.FuncionConsultaDecimal("PRIORIDAD", "CIUDAD", "CODCIUDAD", CIUDAD)
                If VPriorCiudad <> 0 Then
                    cbxPrioridadCiudad.Checked = True
                Else
                    cbxPrioridadCiudad.Checked = False
                End If
                Me.ZONABindingSource.Filter = "CODCIUDAD='" & CIUDAD & "'"
                txtLocalidad.Text = dgvCiudad.CurrentRow.Cells("DESCIUDAD").Value
            End If
        End If

      
    End Sub

    Private Sub dgvZona_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvZona.SelectionChanged
        lblLocalidad.Text = "Zonas"
        If (dgvZona.Rows.Count > 0) Then
            If dgvZona.CurrentRow.Cells("CODZONA").Value Then
                txtLocalidad.Text = dgvZona.CurrentRow.Cells("DESZONA").Value
            End If
        End If
    End Sub

    Private Sub lblNuevo_Click(sender As System.Object, e As System.EventArgs) Handles lblNuevo.Click
        permiso = PermisoAplicado(UsuCodigo, 71)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear un nuevo Registro en esta Ventana", "Pos Express")
            Exit Sub
        End If
        txtLocalidad.Enabled = True
        lblGuardar.Visible = True
        lblEliminar.Visible = False
        lblModificar.Visible = False
        If lblLocalidad.Text = "Países/Departamentos" Then
            cbxPrioridadCiudad.Enabled = False
        ElseIf lblLocalidad.Text = "Ciudades" Then
            cbxPrioridadCiudad.Enabled = True
        Else
            cbxPrioridadCiudad.Enabled = False
        End If
        cbxPrioridadCiudad.Checked = False
        txtLocalidad.Text = ""
        lblCancelar.Visible = True
        txtLocalidad.Focus()
        Nuevo = 1
        tlplocalizacion.Enabled = False
    End Sub

    Private Sub lblGuardar_Click(sender As System.Object, e As System.EventArgs) Handles lblGuardar.Click
        '====================Guardar Pais================================
        If lblLocalidad.Text = "Países/Departamentos" Then
            cbxPrioridadCiudad.Enabled = False
            If Nuevo = 1 Then
                Try
                    UltimoCodigo = f.Maximo("CODPAIS", "PAIS")
                    CodGlobal = UltimoCodigo + 1
                    UltimoNumero = f.Maximo("NUMPAIS", "PAIS")
                    CodNumero = UltimoNumero + 1
                    '=====================Insertar Familia==========================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "INSERT INTO PAIS (CODPAIS,CODUSUARIO,CODEMPRESA,NUMPAIS,DESPAIS,PRIORIDAD,FECGRA) values(" & CodGlobal & "," & UsuCodigo & "," & EmpCodigo & "," & CodNumero & ",'" & Replace(txtLocalidad.Text, "'", "''") & "',0,convert(datetime, '" & Today() & " 0:00:00', 103))"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '=====================Llevar al focus de la grilla============================
                    Dim codPaisTemp As String
                    codPaisTemp = CodGlobal
                    Me.PAISTableAdapter.Fill(Me.DsLocalidad.PAIS)
                    For i = 0 To dgvPais.RowCount - 1
                        If dgvPais.Rows(i).Cells("CODPAIS").Value = codPaisTemp Then
                            PAISBindingSource.Position = i
                        End If
                    Next
                Catch ex As Exception

                    myTrans.Rollback()
                    MessageBox.Show("Problema al Insertar el Pais" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

            ElseIf Nuevo = 2 Then
                Try
                    '===================Actualizar Pais================================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "UPDATE PAIS SET DESPAIS='" & Replace(txtLocalidad.Text, "'", "''") & "'WHERE CODPAIS=" & dgvPais.CurrentRow.Cells("CODPAIS").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '=====================Llevar al focus de la grilla============================
                    Dim codPaisTemp As String
                    codPaisTemp = dgvPais.CurrentRow.Cells("CODPAIS").Value
                    Me.PAISTableAdapter.Fill(Me.DsLocalidad.PAIS)
                    For i = 0 To dgvPais.RowCount - 1
                        If dgvPais.Rows(i).Cells("CODPAIS").Value = codPaisTemp Then
                            PAISBindingSource.Position = i
                        End If
                    Next
                Catch ex As Exception

                    myTrans.Rollback()
                    MessageBox.Show("Problema al Actualizar el Pais" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If

        ElseIf lblLocalidad.Text = "Ciudades" Then
            Dim vPais As String = f.FuncionTop1("DESPAIS", "PAIS")
            '========================Guardar Linea=====================================
            If vPais = Nothing Or vPais = "" Then
                MessageBox.Show("Primero debe Crear un País o Departamento", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtLocalidad.Enabled = False
                lblGuardar.Visible = False
                lblModificar.Visible = True
                lblCancelar.Visible = False
                lblNuevo.Visible = True
                lblEliminar.Visible = True
                tlplocalizacion.Enabled = True
                lblLocalidad.Text = "Países/Departamentos"
                dgvPais.Focus()

                Exit Sub

            End If
            cbxPrioridadCiudad.Enabled = True
            Dim VprioridadCiudad As Integer
            If cbxPrioridadCiudad.Checked = True Then

                VprioridadCiudad = 1
                Dim varDesCiudad As String = funcion.FuncionConsultaString("DESCIUDAD", "CIUDAD", "PRIORIDAD", 1)
                If varDesCiudad <> Nothing Then
                    Try
                        MessageBox.Show("La Ciudad de " & varDesCiudad & " ya está configurado como prioritario,esa prioridad se cambiará.", _
                                                                     "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        VprioridadCiudad = 0
                        If Nuevo = 1 Then
                            VprioridadCiudad = 1
                            Try

                                '=====================Insertar CIUDAD=================================
                                ser.Abrir(sqlc)
                                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                                cmd.Connection = sqlc
                                cmd.Transaction = myTrans
                                sql = ""
                                sql = "INSERT INTO CIUDAD (CODCIUDAD,CODUSUARIO,CODEMPRESA,CODDEPARTAMENTO,NUMCIUDAD,DESCIUDAD,PRIORIDAD,FECGRA,CODPAIS) values(" & CodGlobal & "," & UsuCodigo & "," & EmpCodigo & ",NULL," & CodNumero & ",'" & Replace(txtLocalidad.Text, "'", "''") & "'," & VprioridadCiudad & ",convert(datetime, '" & Today() & " 0:00:00', 103)," & dgvPais.CurrentRow.Cells("CODPAIS").Value & ")"
                                cmd.CommandText = sql
                                cmd.ExecuteNonQuery()
                                myTrans.Commit()
                                sqlc.Close()

                                VprioridadCiudad = 0
                                ser.Abrir(sqlc)
                                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                                cmd.Connection = sqlc
                                cmd.Transaction = myTrans
                                sql = ""
                                sql = "UPDATE CIUDAD SET PRIORIDAD=" & VprioridadCiudad & " WHERE DESCIUDAD='" & varDesCiudad & "'"
                                cmd.CommandText = sql
                                cmd.ExecuteNonQuery()
                                myTrans.Commit()
                                sqlc.Close()
                                '===============Llevar al focus========================================
                                Dim codLinea2Temp As String
                                codLinea2Temp = CodGlobal
                                Me.CIUDADTableAdapter.Fill(Me.DsLocalidad.CIUDAD)
                                For i = 0 To dgvCiudad.RowCount - 1
                                    If dgvCiudad.Rows(i).Cells("CODCIUDAD").Value = codLinea2Temp Then
                                        CIUDADBindingSource.Position = i
                                    End If
                                Next

                            Catch ex As Exception
                                myTrans.Rollback()
                                MessageBox.Show("Problema al Insertar la Ciudad" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Try
                        ElseIf Nuevo = 2 Then
                            ser.Abrir(sqlc)
                            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                            cmd.Connection = sqlc
                            cmd.Transaction = myTrans
                            sql = ""
                            sql = "UPDATE CIUDAD SET PRIORIDAD=" & VprioridadCiudad & " WHERE DESCIUDAD='" & varDesCiudad & "'"
                            cmd.CommandText = sql
                            cmd.ExecuteNonQuery()
                            myTrans.Commit()
                            sqlc.Close()

                            VprioridadCiudad = 1
                            ser.Abrir(sqlc)
                            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                            cmd.Connection = sqlc
                            cmd.Transaction = myTrans
                            sql = ""
                            sql = "UPDATE CIUDAD SET DESCIUDAD='" & Replace(txtLocalidad.Text, "'", "''") & "',PRIORIDAD=" & VprioridadCiudad & " WHERE CODCIUDAD=" & dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value
                            cmd.CommandText = sql
                            cmd.ExecuteNonQuery()
                            myTrans.Commit()
                            sqlc.Close()
                        End If
                        Dim codLineaTemp As String
                        codLineaTemp = dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value
                        Me.CIUDADTableAdapter.Fill(Me.DsLocalidad.CIUDAD)
                        For i = 0 To dgvCiudad.RowCount - 1
                            If dgvCiudad.Rows(i).Cells("CODCIUDAD").Value = codLineaTemp Then
                                CIUDADBindingSource.Position = i
                            End If
                        Next
                    Catch ex As Exception
                        myTrans.Rollback()
                        MessageBox.Show("Problema al Actualizar la Ciudad" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                    txtLocalidad.Enabled = False
                    lblGuardar.Visible = False
                    lblModificar.Visible = True
                    lblCancelar.Visible = False
                    lblNuevo.Visible = True
                    lblEliminar.Visible = True
                    cbxPrioridadCiudad.Enabled = False
                    tlplocalizacion.Enabled = True
                    Exit Sub
                End If
            Else
                VprioridadCiudad = 0
            End If
            '========================Guardar Ciudad=====================================
            UltimoCodigo = f.Maximo("CODCIUDAD", "CIUDAD")
            CodGlobal = UltimoCodigo + 1
            UltimoNumero = f.Maximo("NUMCIUDAD", "CIUDAD")
            CodNumero = UltimoNumero + 1
            If Nuevo = 1 Then
                Try

                    '=====================Insertar CIUDAD=================================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "INSERT INTO CIUDAD (CODCIUDAD,CODUSUARIO,CODEMPRESA,CODDEPARTAMENTO,NUMCIUDAD,DESCIUDAD,PRIORIDAD,FECGRA,CODPAIS) values(" & CodGlobal & "," & UsuCodigo & "," & EmpCodigo & ",NULL," & CodNumero & ",'" & Replace(txtLocalidad.Text, "'", "''") & "'," & VprioridadCiudad & ",convert(datetime, '" & Today() & " 0:00:00', 103)," & dgvPais.CurrentRow.Cells("CODPAIS").Value & ")"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '===============Llevar al focus========================================
                    Dim codLineaTemp As String
                    codLineaTemp = CodGlobal
                    Me.CIUDADTableAdapter.Fill(Me.DsLocalidad.CIUDAD)
                    For i = 0 To dgvCiudad.RowCount - 1
                        If dgvCiudad.Rows(i).Cells("CODCIUDAD").Value = codLineaTemp Then
                            CIUDADBindingSource.Position = i
                        End If
                    Next

                Catch ex As Exception
                    myTrans.Rollback()
                    MessageBox.Show("Problema al Insertar la Ciudad" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            ElseIf Nuevo = 2 Then
                Try

                    '======================Actualizar CIUDAD============================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "UPDATE CIUDAD SET DESCIUDAD='" & Replace(txtLocalidad.Text, "'", "''") & "',PRIORIDAD=" & VprioridadCiudad & " WHERE CODCIUDAD=" & dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '===============Llevar al focus========================================
                    Dim codLineaTemp As String
                    codLineaTemp = dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value
                    Me.CIUDADTableAdapter.Fill(Me.DsLocalidad.CIUDAD)
                    For i = 0 To dgvCiudad.RowCount - 1
                        If dgvCiudad.Rows(i).Cells("CODCIUDAD").Value = codLineaTemp Then
                            CIUDADBindingSource.Position = i
                        End If
                    Next
                Catch ex As Exception
                    myTrans.Rollback()
                    MessageBox.Show("Problema al Actualizar la Ciudad" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        ElseIf lblLocalidad.Text = "Zonas" Then
            Dim vCiudad As String = f.FuncionTop1("DESCIUDAD", "CIUDAD")
            '========================Guardar Linea=====================================
            If vCiudad = Nothing Or vCiudad = "" Then
                MessageBox.Show("Primero debe Crear una Ciudad", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtLocalidad.Enabled = False
                lblGuardar.Visible = False
                lblModificar.Visible = True
                lblCancelar.Visible = False
                lblNuevo.Visible = True
                lblEliminar.Visible = True
                tlplocalizacion.Enabled = True
                lblLocalidad.Text = "Ciudades"
                dgvCiudad.Focus()
                Exit Sub

            End If
            cbxPrioridadCiudad.Enabled = False
            If Nuevo = 1 Then
                Try
                    '=========================Guardar Rubro===============================
                    UltimoCodigo = f.Maximo("CODZONA", "ZONA")
                    CodGlobal = UltimoCodigo + 1
                    UltimoNumero = f.Maximo("NUMZONA", "ZONA")
                    CodNumero = UltimoNumero + 1
                    '===================Insertar Rubro===================================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "INSERT INTO ZONA (CODZONA,CODSUCURSAL,CODUSUARIO,CODEMPRESA,CODCIUDAD,NUMZONA,DESZONA,FECGRA) values(" & CodGlobal & "," & SucCodigo & "," & UsuCodigo & "," & EmpCodigo & "," & dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value & "," & CodNumero & ",'" & Replace(txtLocalidad.Text, "'", "''") & "',convert(datetime, '" & Today() & " 0:00:00', 103))"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()

                    '====================Codigo para no perder el focus en la grilla====================================
                    Dim CODZonaTemp As String
                    CODZonaTemp = CodGlobal
                    Me.ZONATableAdapter.Fill(Me.DsLocalidad.ZONA)
                    For i = 0 To dgvZona.RowCount - 1
                        If dgvZona.Rows(i).Cells("CODZONA").Value = CODZonaTemp Then
                            ZONABindingSource.Position = i
                        End If
                    Next
                Catch ex As Exception
                    myTrans.Rollback()
                    MessageBox.Show("Problema al Insertar la Zona" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            ElseIf Nuevo = 2 Then
                Try
                    '======================Actualizar ZONA==============================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "UPDATE ZONA SET DESZONA='" & Replace(txtLocalidad.Text, "'", "''") & "' WHERE CODZONA=" & dgvZona.CurrentRow.Cells("CODZONA").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '====================Codigo para no perder el focus en la grilla====================================
                    Dim CodZona As String
                    CodZona = dgvZona.CurrentRow.Cells("CODZONA").Value
                    Me.ZONATableAdapter.Fill(Me.DsLocalidad.ZONA)
                    For i = 0 To dgvZona.RowCount - 1
                        If dgvZona.Rows(i).Cells("CODZONA").Value = CodZona Then
                            ZONABindingSource.Position = i
                        End If
                    Next
                Catch ex As Exception
                    myTrans.Rollback()
                    MessageBox.Show("Problema al Actualizar la Zona" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If

            End If

            txtLocalidad.Enabled = False
            lblGuardar.Visible = False
            lblModificar.Visible = True
            lblCancelar.Visible = False
            lblNuevo.Visible = True
            lblEliminar.Visible = True
        cbxPrioridadCiudad.Enabled = False
        tlplocalizacion.Enabled = True
    End Sub
    Private Sub dgvPais_Click(sender As Object, e As System.EventArgs) Handles dgvPais.Click
        lblLocalidad.Text = "Países/Departamentos"
        tbxBuscarPais.BringToFront()
        dgvPais.BackgroundColor = Color.LightGray
        dgvPais.DefaultCellStyle.BackColor = Color.LightGray
        dgvCiudad.BackgroundColor = Color.DarkGray
        dgvCiudad.DefaultCellStyle.BackColor = Color.DarkGray
        dgvZona.BackgroundColor = Color.DarkGray
        dgvZona.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvPais.RowCount > 0 Then
            If IsDBNull(dgvPais.CurrentRow.Cells("CODPAIS").Value) Or
              dgvPais.CurrentRow.Cells("CODPAIS").Value Is Nothing Then
                dgvPais.CurrentRow.Cells("CODPAIS").Value = dgvPais.Rows(1).Cells("CODPAIS").Value
            End If
            txtLocalidad.Text = dgvPais.CurrentRow.Cells("DESPAIS").Value
        End If
    End Sub
    Private Sub dgvCiudad_Click(sender As Object, e As System.EventArgs) Handles dgvCiudad.Click
        lblLocalidad.Text = "Ciudades"
        tbxBuscarCiudad.Visible = True
        tbxBuscarCiudad.BringToFront()
        dgvCiudad.BackgroundColor = Color.LightGray
        dgvCiudad.DefaultCellStyle.BackColor = Color.LightGray
        dgvPais.BackgroundColor = Color.DarkGray
        dgvPais.DefaultCellStyle.BackColor = Color.DarkGray
        dgvZona.BackgroundColor = Color.DarkGray
        dgvZona.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvCiudad.RowCount > 0 Then
            If IsDBNull(dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value) Or
               dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value Is Nothing Then
                dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value = dgvCiudad.Rows(1).Cells("CODCIUDAD").Value

            End If

            txtLocalidad.Text = dgvCiudad.CurrentRow.Cells("DESCIUDAD").Value
        End If
    End Sub
    Private Sub dgvZona_Click(sender As Object, e As System.EventArgs) Handles dgvZona.Click
        lblLocalidad.Text = "Zonas"
        tbxBuscarZona.Visible = True
        tbxBuscarZona.BringToFront()
        dgvZona.BackgroundColor = Color.LightGray
        dgvZona.DefaultCellStyle.BackColor = Color.LightGray
        dgvCiudad.BackgroundColor = Color.DarkGray
        dgvCiudad.DefaultCellStyle.BackColor = Color.DarkGray
        dgvPais.BackgroundColor = Color.DarkGray
        dgvPais.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvZona.RowCount > 0 Then
            If IsDBNull(dgvZona.CurrentRow.Cells("CODZONA").Value) Or
                  dgvZona.CurrentRow.Cells("CODZONA").Value Is Nothing Then
                dgvZona.CurrentRow.Cells("CODZONA").Value = dgvZona.Rows(1).Cells("CODZONA").Value
            End If
            txtLocalidad.Text = dgvZona.CurrentRow.Cells("DESZONA").Value
        End If
    End Sub

    Private Sub lblModificar_Click(sender As System.Object, e As System.EventArgs) Handles lblModificar.Click
        permiso = PermisoAplicado(UsuCodigo, 73)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar datos  de este Registro", "Pos Express")
            Exit Sub
        End If
        tlplocalizacion.Enabled = False
        txtLocalidad.Enabled = True
        lblGuardar.Visible = True
        cbxPrioridadCiudad.Enabled = True
        lblCancelar.Visible = True
        Nuevo = 2
        txtLocalidad.Focus()
    End Sub
    Private Sub dgvPais_GotFocus(sender As Object, e As System.EventArgs) Handles dgvPais.GotFocus
        dgvPais.BackgroundColor = Color.LightGray
        dgvPais.DefaultCellStyle.BackColor = Color.LightGray
        dgvCiudad.BackgroundColor = Color.DarkGray
        dgvCiudad.DefaultCellStyle.BackColor = Color.DarkGray
        dgvZona.BackgroundColor = Color.DarkGray
        dgvZona.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvPais.RowCount > 0 Then
            If IsDBNull(dgvPais.CurrentRow.Cells("CODPAIS").Value) Or
               dgvPais.CurrentRow.Cells("CODPAIS").Value Is Nothing Then
                dgvPais.CurrentRow.Cells("CODPAIS").Value = dgvPais.Rows(1).Cells("CODPAIS").Value
            End If
            txtLocalidad.Text = dgvPais.CurrentRow.Cells("DESPAIS").Value
        End If
    End Sub

  
    Private Sub dgvZona_GotFocus(sender As Object, e As System.EventArgs) Handles dgvZona.GotFocus
        dgvZona.BackgroundColor = Color.LightGray
        dgvZona.DefaultCellStyle.BackColor = Color.LightGray
        dgvCiudad.BackgroundColor = Color.DarkGray
        dgvCiudad.DefaultCellStyle.BackColor = Color.DarkGray
        dgvPais.BackgroundColor = Color.DarkGray
        dgvPais.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvZona.RowCount > 0 Then
            If IsDBNull(dgvZona.CurrentRow.Cells("CODZONA").Value) Or
                dgvZona.CurrentRow.Cells("CODZONA").Value Is Nothing Then
                dgvZona.CurrentRow.Cells("CODZONA").Value = dgvZona.Rows(1).Cells("CODZONA").Value
            End If
            txtLocalidad.Text = dgvZona.CurrentRow.Cells("DESZONA").Value
        End If
    End Sub

    Private Sub lblEliminar_Click(sender As System.Object, e As System.EventArgs) Handles lblEliminar.Click
        permiso = PermisoAplicado(UsuCodigo, 72)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar Registros en  esta ventana", "Pos Express")
            Exit Sub
        End If
        txtLocalidad.Enabled = False
        'pnlCategorias.Enabled = True
        Nuevo = 3

        If MessageBox.Show("¿Esta seguro que quiere ELIMINAR:" + txtLocalidad.Text, "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If
        If lblLocalidad.Text = "Países/Departamentos" Then
            Try

                If Nuevo = 3 Then
                    '==================Eliminar Familia================================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "DELETE FROM PAIS WHERE CODPAIS=" & dgvPais.CurrentRow.Cells("CODPAIS").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                End If
            Catch ex As SqlException
                Try
                    myTrans.Rollback("")
                Catch

                End Try

                Dim NroError As Integer = ex.Number
                Dim Mensaje As String = ex.Message
                If NroError = 547 Then
                    MessageBox.Show("Este País que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podrá eliminar", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Problema al eliminar este País: " + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Finally
                sqlc.Close()
            End Try
        ElseIf lblLocalidad.Text = "Ciudades" Then
            Try
                If Nuevo = 3 Then
                    '=====================Eliminar CIUDAD===============
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "DELETE FROM CIUDAD WHERE CODCIUDAD=" & dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                End If
            Catch ex As SqlException
                Try
                    myTrans.Rollback("")
                Catch

                End Try

                Dim NroError As Integer = ex.Number
                Dim Mensaje As String = ex.Message
                If NroError = 547 Then
                    MessageBox.Show("Esta Ciudad que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podrá eliminar", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Problema al eliminar esta Ciudad: " + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Finally
                sqlc.Close()
            End Try
        ElseIf lblLocalidad.Text = "Zonas" Then
            Try
                If Nuevo = 3 Then
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "DELETE FROM ZONA WHERE CODZONA=" & dgvZona.CurrentRow.Cells("CODZONA").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                End If
            Catch ex As SqlException
                Try
                    myTrans.Rollback("")
                Catch

                End Try

                Dim NroError As Integer = ex.Number
                Dim Mensaje As String = ex.Message
                If NroError = 547 Then
                    MessageBox.Show("Esta Zona que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podrá eliminar", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Problema al eliminar esta Zona: " + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Finally
                sqlc.Close()
            End Try
        End If

        '=======================Codigo para no perder el focus en caso de error =========================
        If dgvCiudad.Rows.Count > 0 Then
            Dim codCiudadTemp As String
            codCiudadTemp = dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value
            If lblLocalidad.Text = "Ciudades" Then
                Me.CIUDADTableAdapter.Fill(DsLocalidad.CIUDAD)
                For i = 0 To dgvCiudad.RowCount - 1
                    If dgvCiudad.Rows(i).Cells("CODCIUDAD").Value = codCiudadTemp Then
                        CIUDADBindingSource.Position = i
                    End If
                Next
            End If
        End If
        If dgvZona.Rows.Count > 0 Then
            Dim CODZonaTemp As String
            CODZonaTemp = dgvZona.CurrentRow.Cells("CODZONA").Value
            If lblLocalidad.Text = "Zonas" Then
                Me.ZONATableAdapter.Fill(DsLocalidad.ZONA)
                For i = 0 To dgvZona.RowCount - 1
                    If dgvZona.Rows(i).Cells("CODZONA").Value = CODZonaTemp Then
                        ZONABindingSource.Position = i
                    End If
                Next
            End If
        End If
        If dgvPais.Rows.Count > 0 Then
            Dim codpaisTemp As String
            codpaisTemp = dgvPais.CurrentRow.Cells("CODPAIS").Value
            If lblLocalidad.Text = "Países/Departamentos" Then
                Me.PAISTableAdapter.Fill(DsLocalidad.PAIS)
                For i = 0 To dgvPais.RowCount - 1
                    If dgvPais.Rows(i).Cells("CODPAIS").Value = codpaisTemp Then
                        PAISBindingSource.Position = i
                    End If
                Next
            End If
        End If
        sqlc.Close()
        tlplocalizacion.Enabled = True
    End Sub

    Private Sub lblCancelar_Click(sender As System.Object, e As System.EventArgs) Handles lblCancelar.Click
        Try
            If dgvCiudad.Rows.Count > 0 Then
                Dim codCiudadTemp As String
                codCiudadTemp = dgvCiudad.CurrentRow.Cells("CODCIUDAD").Value
                If lblLocalidad.Text = "Ciudades" Then
                    '===========Cancelar y no perder el foco en linea y refresar la grilla====================
                    Me.CIUDADBindingSource.CancelEdit()
                    Me.CIUDADTableAdapter.Fill(DsLocalidad.CIUDAD)

                    For i = 0 To dgvCiudad.RowCount - 1
                        If dgvCiudad.Rows(i).Cells("CODCIUDAD").Value = codCiudadTemp Then
                            CIUDADBindingSource.Position = i
                        End If
                    Next
                    txtLocalidad.Text = dgvCiudad.CurrentRow.Cells("DESCIUDAD").Value
                End If
            End If
            If dgvZona.Rows.Count > 0 Then
                Dim CODZonaTemp As String
                CODZonaTemp = dgvZona.CurrentRow.Cells("CODZONA").Value
                If lblLocalidad.Text = "Zonas" Then
                    '===========Cancelar y no perder el foco en rubro  y refresar la grilla====================
                    Me.ZONABindingSource.CancelEdit()
                    Me.ZONATableAdapter.Fill(DsLocalidad.ZONA)
                    For i = 0 To dgvZona.RowCount - 1
                        If dgvZona.Rows(i).Cells("CODZONA").Value = CODZonaTemp Then
                            ZONABindingSource.Position = i
                        End If
                    Next
                    txtLocalidad.Text = dgvZona.CurrentRow.Cells("DESZONA").Value
                End If
            End If
            If dgvPais.Rows.Count > 0 Then
                Dim codPaisTemp As String
                codPaisTemp = dgvPais.CurrentRow.Cells("CODPAIS").Value
                If lblLocalidad.Text = "Países/Departamentos" Then
                    '===========Cancelar y no perder el foco en familia  y refresar la grilla====================
                    Me.PAISBindingSource.CancelEdit()
                    Me.PAISTableAdapter.Fill(DsLocalidad.PAIS)
                    For i = 0 To dgvPais.RowCount - 1
                        If dgvPais.Rows(i).Cells("CODPAIS").Value = codPaisTemp Then
                            PAISBindingSource.Position = i
                        End If
                    Next
                    txtLocalidad.Text = dgvPais.CurrentRow.Cells("DESPAIS").Value
                End If
            End If
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Problema al Cancelar la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        txtLocalidad.Enabled = False
        lblGuardar.Visible = False
        lblModificar.Visible = True
        lblCancelar.Visible = False
        lblNuevo.Visible = True
        lblEliminar.Visible = True
        cbxPrioridadCiudad.Enabled = False
        tlplocalizacion.Enabled = True
    End Sub

    Private Sub tbxBuscarPais_GotFocus(sender As Object, e As System.EventArgs) Handles tbxBuscarPais.GotFocus
        tbxBuscarPais.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxBuscarPais_LostFocus(sender As Object, e As System.EventArgs) Handles tbxBuscarPais.LostFocus
        tbxBuscarPais.BackColor = Color.DimGray
    End Sub

    Private Sub tbxBuscarPais_TextChanged(sender As Object, e As System.EventArgs) Handles tbxBuscarPais.TextChanged

        If tbxBuscarPais.Visible = True Then
            Me.PAISBindingSource.Filter = "DESPAIS LIKE '%" & Replace(tbxBuscarPais.Text, "'", "''") & "%'"

        End If
    End Sub

    Private Sub tbxBuscarCiudad_GotFocus(sender As Object, e As System.EventArgs) Handles tbxBuscarCiudad.GotFocus
        tbxBuscarCiudad.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxBuscarCiudad_LostFocus(sender As Object, e As System.EventArgs) Handles tbxBuscarCiudad.LostFocus
        tbxBuscarCiudad.BackColor = Color.DimGray
    End Sub
    Private Sub tbxBuscarCiudad_TextChanged(sender As Object, e As System.EventArgs) Handles tbxBuscarCiudad.TextChanged
        If tbxBuscarCiudad.Visible = True Then
            Me.CIUDADBindingSource.Filter = "DESCIUDAD LIKE '%" & Replace(tbxBuscarCiudad.Text, "'", "''") & "%'"
        End If
    End Sub

    Private Sub tbxBuscarZona_GotFocus(sender As Object, e As System.EventArgs) Handles tbxBuscarZona.GotFocus
        tbxBuscarZona.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxBuscarZona_LostFocus(sender As Object, e As System.EventArgs) Handles tbxBuscarZona.LostFocus
        tbxBuscarZona.BackColor = Color.DimGray
    End Sub

    Private Sub tbxBuscarZona_TextChanged(sender As Object, e As System.EventArgs) Handles tbxBuscarZona.TextChanged
        If tbxBuscarZona.Visible = True Then
            Me.ZONABindingSource.Filter = "DESZONA LIKE '%" & Replace(tbxBuscarZona.Text, "'", "''") & "%'"
        End If
    End Sub
End Class