Imports System.Windows
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class ABMCategorias
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
    Private Sub ABMCategorias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 66)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Abrir  esta ventana", "Pos Express")
            Me.Close()
        End If
        txtCategorizacion.Enabled = False
        lblGuardar.Visible = False
        lblModificar.Visible = True
        lblCancelar.Visible = False
        lblNuevo.Visible = True
        lblEliminar.Visible = True
        dgvLinea.BackgroundColor = Color.DarkGray
        dgvCategorias.BackgroundColor = Color.DarkGray
        dgvRubro.BackgroundColor = Color.DarkGray

        Me.RUBROTableAdapter.Fill(Me.DsCategorizacion.RUBRO)
        Me.LINEATableAdapter.Fill(Me.DsCategorizacion.LINEA)
        Me.FAMILIATableAdapter.Fill(Me.DsCategorizacion.FAMILIA)
        Nuevo = 0
   
        'pnlCategorias.Enabled = True
    End Sub

    Private Sub dgvCategorias_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvCategorias.SelectionChanged

        If (dgvCategorias.Rows.Count > 0) Then
            If dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value Then
                '=========Filtro de familia para Linea==============
                Dim categoria As Integer = dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value
                Me.LINEABindingSource.Filter = "CODFAMILIA='" & categoria & "'"
                If dgvLinea.Rows.Count < 1 Then
                    Me.RUBROBindingSource.Filter = "CODLINEA=NULL"
                End If
                lblCategorizacion.Text = "Familias"
                txtCategorizacion.Text = dgvCategorias.CurrentRow.Cells("DESFAMILIA").Value
            End If
        End If
    End Sub
    Private Sub dgvLinea_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvLinea.SelectionChanged

        lblCategorizacion.Text = "Lineas"
        If (dgvLinea.Rows.Count > 0) Then
            If dgvLinea.CurrentRow.Cells("CODLINEA").Value Then
                '=========Filtro de linea para Rubro==============
                Dim linea As Integer = dgvLinea.CurrentRow.Cells("CODLINEA").Value
                Me.RUBROBindingSource.Filter = "CODLINEA='" & linea & "'"
                txtCategorizacion.Text = dgvLinea.CurrentRow.Cells("DESLINEA").Value
            End If
        End If
    End Sub


    Private Sub dgvRubro_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvRubro.SelectionChanged

        lblCategorizacion.Text = "Rubros"
        If (dgvRubro.Rows.Count > 0) Then
            If dgvRubro.CurrentRow.Cells("CODRUBRO1").Value Then
                txtCategorizacion.Text = dgvRubro.CurrentRow.Cells("DESRUBRO2").Value
            End If
        End If
    End Sub
    Private Sub lblNuevo_Click(sender As Object, e As System.EventArgs) Handles lblNuevo.Click
        permiso = PermisoAplicado(UsuCodigo, 67)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear en  esta ventana", "Pos Express")
            Exit Sub
        End If

        txtCategorizacion.Enabled = True
        'pnlCategorias.Enabled = False
        lblGuardar.Visible = True
        lblEliminar.Visible = False
        lblModificar.Visible = False
        txtCategorizacion.Text = ""
        lblCancelar.Visible = True
        txtCategorizacion.Focus()
        Nuevo = 1
    End Sub
    Private Sub lblGuardar_Click(sender As Object, e As System.EventArgs) Handles lblGuardar.Click
        Try
            '====================Guardar Familia================================
            If lblCategorizacion.Text = "Familias" Then
                If Nuevo = 1 Then
                    UltimoCodigo = f.Maximo("CODFAMILIA", "FAMILIA")
                    CodGlobal = UltimoCodigo + 1
                    UltimoNumero = f.Maximo("NUMFAMILIA", "FAMILIA")
                    CodNumero = UltimoNumero + 1
                    '=====================Insertar Familia==========================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "INSERT INTO FAMILIA (CODFAMILIA,CODUSUARIO,CODEMPRESA,NUMFAMILIA,FECGRA,DESFAMILIA) values(" & CodGlobal & "," & UsuCodigo & "," & EmpCodigo & "," & CodNumero & ",convert(datetime, '" & Today() & " 0:00:00', 103),'" & txtCategorizacion.Text & "')"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '=====================Llevar al focus de la grilla============================
                    Dim codFamiliaTemp As String
                    codFamiliaTemp = CodGlobal
                    Me.FAMILIATableAdapter.Fill(Me.DsCategorizacion.FAMILIA)
                    For i = 0 To dgvCategorias.RowCount - 1
                        If dgvCategorias.Rows(i).Cells("CODFAMILIA").Value = codFamiliaTemp Then
                            FAMILIABindingSource.Position = i
                        End If
                    Next
                ElseIf Nuevo = 2 Then
                    '===================Actualizar Familia================================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "UPDATE FAMILIA SET DESFAMILIA='" & txtCategorizacion.Text & "' WHERE CODFAMILIA=" & dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '=====================Llevar al focus de la grilla============================
                    Dim codFamiliaTemp As String
                    codFamiliaTemp = dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value
                    Me.FAMILIATableAdapter.Fill(Me.DsCategorizacion.FAMILIA)
                    For i = 0 To dgvCategorias.RowCount - 1
                        If dgvCategorias.Rows(i).Cells("CODFAMILIA").Value = codFamiliaTemp Then
                            FAMILIABindingSource.Position = i
                        End If
                    Next
                End If

            ElseIf lblCategorizacion.Text = "Lineas" Then
                Dim vFamilia As String = f.FuncionTop1("DESFAMILIA", "FAMILIA")
                '========================Guardar Linea=====================================
                If vFamilia = Nothing Or vFamilia = "" Then
                    MessageBox.Show("Primero debe Crear una Categoría o Familia", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCategorizacion.Enabled = False
                    lblGuardar.Visible = False
                    lblModificar.Visible = True
                    lblCancelar.Visible = False
                    lblNuevo.Visible = True
                    lblEliminar.Visible = True
                    lblCategorizacion.Text = "Familias"
                    dgvCategorias.Focus()
                    Exit Sub

                End If
                UltimoCodigo = f.Maximo("CODLINEA", "LINEA")
                CodGlobal = UltimoCodigo + 1
                UltimoNumero = f.Maximo("NUMLINEA", "LINEA")
                CodNumero = UltimoNumero + 1
                If Nuevo = 1 Then
                    '=====================Insertar Linea=================================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "INSERT INTO LINEA (CODLINEA,CODFAMILIA,CODUSUARIO,CODEMPRESA,NUMLINEA,DESLINEA,FECGRA) values(" & CodGlobal & "," & dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value & "," & UsuCodigo & "," & EmpCodigo & "," & CodNumero & ",'" & txtCategorizacion.Text & "',convert(datetime, '" & Today() & " 0:00:00', 103))"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '===============Llevar al focus========================================
                    Dim codLineaTemp As String
                    codLineaTemp = CodGlobal
                    Me.LINEATableAdapter.Fill(Me.DsCategorizacion.LINEA)
                    For i = 0 To dgvLinea.RowCount - 1
                        If dgvLinea.Rows(i).Cells("CODLINEA").Value = codLineaTemp Then
                            LINEABindingSource.Position = i
                        End If
                    Next
                ElseIf Nuevo = 2 Then
                    '======================Actualizar Linea============================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "UPDATE LINEA SET DESLINEA='" & txtCategorizacion.Text & "' WHERE CODLINEA=" & dgvLinea.CurrentRow.Cells("CODLINEA").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '===============Llevar al focus========================================
                    Dim codLineaTemp As String
                    codLineaTemp = dgvLinea.CurrentRow.Cells("CODLINEA").Value
                    Me.LINEATableAdapter.Fill(Me.DsCategorizacion.LINEA)
                    For i = 0 To dgvLinea.RowCount - 1
                        If dgvLinea.Rows(i).Cells("CODLINEA").Value = codLineaTemp Then
                            LINEABindingSource.Position = i
                        End If
                    Next
                End If
            ElseIf lblCategorizacion.Text = "Rubros" Then
                Dim vLinea As String = f.FuncionTop1("DESLINEA", "LINEA")
                '========================Guardar Linea=====================================
                If vLinea = Nothing Or vLinea = "" Then
                    MessageBox.Show("Primero debe Crear una Linea", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCategorizacion.Enabled = False
                    lblGuardar.Visible = False
                    lblModificar.Visible = True
                    lblCancelar.Visible = False
                    lblNuevo.Visible = True
                    lblEliminar.Visible = True
                    lblCategorizacion.Text = "Lineas"
                    dgvLinea.Focus()
                    Exit Sub

                End If
                If Nuevo = 1 Then
                    '=========================Guardar Rubro===============================
                    UltimoCodigo = f.Maximo("CODRUBRO", "RUBRO")
                    CodGlobal = UltimoCodigo + 1
                    UltimoNumero = f.Maximo("NUMRUBRO", "RUBRO")
                    CodNumero = UltimoNumero + 1
                    '===================Insertar Rubro===================================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "INSERT INTO RUBRO (CODRUBRO,CODLINEA,CODUSUARIO,CODEMPRESA,NUMRUBRO,DESRUBRO,FECGRA) values(" & CodGlobal & "," & dgvLinea.CurrentRow.Cells("CODLINEA").Value & "," & UsuCodigo & "," & EmpCodigo & "," & CodNumero & ",'" & txtCategorizacion.Text & "',convert(datetime, '" & Today() & " 0:00:00', 103))"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()

                    '====================Codigo para no perder el focus en la grilla====================================
                    Dim CODRUBRO1Temp As String
                    CODRUBRO1Temp = CodGlobal
                    Me.RUBROTableAdapter.Fill(Me.DsCategorizacion.RUBRO)
                    For i = 0 To dgvRubro.RowCount - 1
                        If dgvRubro.Rows(i).Cells("CODRUBRO1").Value = CODRUBRO1Temp Then
                            RUBROBindingSource.Position = i
                        End If
                    Next
                ElseIf Nuevo = 2 Then
                    '======================Actualizar Rubro==============================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "UPDATE RUBRO SET DESRUBRO='" & txtCategorizacion.Text & "' WHERE CODRUBRO=" & dgvRubro.CurrentRow.Cells("CODRUBRO1").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                    '====================Codigo para no perder el focus en la grilla====================================
                    Dim CODRUBRO1Temp As String
                    CODRUBRO1Temp = dgvRubro.CurrentRow.Cells("CODRUBRO1").Value
                    Me.RUBROTableAdapter.Fill(Me.DsCategorizacion.RUBRO)
                    For i = 0 To dgvRubro.RowCount - 1
                        If dgvRubro.Rows(i).Cells("CODRUBRO1").Value = CODRUBRO1Temp Then
                            RUBROBindingSource.Position = i
                        End If
                    Next
                End If

            End If
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Ocurrió un Error Durante la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        txtCategorizacion.Enabled = False
        lblGuardar.Visible = False
        lblModificar.Visible = True
        lblCancelar.Visible = False
        lblNuevo.Visible = True
        lblEliminar.Visible = True
       
    End Sub
    Private Sub lblEliminar_Click(sender As System.Object, e As System.EventArgs) Handles lblEliminar.Click
        permiso = PermisoAplicado(UsuCodigo, 68)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar en  esta ventana", "Pos Express")
            Exit Sub
        End If

        txtCategorizacion.Enabled = False
        'pnlCategorias.Enabled = True
        Nuevo = 3
        Try
            If MessageBox.Show("¿Esta seguro que quiere ELIMINAR:" + txtCategorizacion.Text, "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                Exit Sub
            End If
            If lblCategorizacion.Text = "Familias" Then
                If Nuevo = 3 Then
                    '==================Eliminar Familia================================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "DELETE FROM FAMILIA WHERE CODFAMILIA=" & dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                End If
            ElseIf lblCategorizacion.Text = "Lineas" Then
                If Nuevo = 3 Then
                    '=====================Eliminar Linea===============
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "DELETE FROM LINEA WHERE CODLINEA=" & dgvLinea.CurrentRow.Cells("CODLINEA").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                End If
            ElseIf lblCategorizacion.Text = "Rubros" Then
                If Nuevo = 3 Then
                    '======================Elimiar Rubro============================
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans
                    sql = ""
                    sql = "DELETE FROM RUBRO WHERE CODRUBRO=" & dgvRubro.CurrentRow.Cells("CODRUBRO1").Value
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                End If
            End If


            '=======================Codigo para no perder el focus en caso de error =========================
            If dgvLinea.Rows.Count > 0 Then
                Dim codLineaTemp As String
                codLineaTemp = dgvLinea.CurrentRow.Cells("CODLINEA").Value
                If lblCategorizacion.Text = "Lineas" Then
                    Me.LINEATableAdapter.Fill(DsCategorizacion.LINEA)
                    For i = 0 To dgvLinea.RowCount - 1
                        If dgvLinea.Rows(i).Cells("CODLINEA").Value = codLineaTemp Then
                            LINEABindingSource.Position = i
                        End If
                    Next
                End If
            End If
            If dgvRubro.Rows.Count > 0 Then
                Dim CODRUBRO1Temp As String
                CODRUBRO1Temp = dgvRubro.CurrentRow.Cells("CODRUBRO1").Value
                If lblCategorizacion.Text = "Rubros" Then
                    Me.RUBROTableAdapter.Fill(DsCategorizacion.RUBRO)
                    For i = 0 To dgvRubro.RowCount - 1
                        If dgvRubro.Rows(i).Cells("CODRUBRO1").Value = CODRUBRO1Temp Then
                            RUBROBindingSource.Position = i
                        End If
                    Next
                End If
            End If
            If dgvCategorias.Rows.Count > 0 Then
                Dim codFamiliaTemp As String
                codFamiliaTemp = dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value
                If lblCategorizacion.Text = "Familias" Then
                    Me.FAMILIATableAdapter.Fill(DsCategorizacion.FAMILIA)
                    For i = 0 To dgvCategorias.RowCount - 1
                        If dgvCategorias.Rows(i).Cells("CODFAMILIA").Value = codFamiliaTemp Then
                            FAMILIABindingSource.Position = i
                        End If
                    Next
                End If
            End If
        Catch ex As SqlException
            Try
                myTrans.Rollback("")
            Catch

            End Try

            Dim NroError As Integer = ex.Number
            Dim Mensaje As String = ex.Message
            If NroError = 547 Then
                MessageBox.Show("La categoria que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podra eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Error al Eliminar la Categoria : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Finally
            sqlc.Close()

        End Try
    End Sub
    Private Sub lblModificar_Click(sender As System.Object, e As System.EventArgs) Handles lblModificar.Click
        permiso = PermisoAplicado(UsuCodigo, 69)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Modificar datos  de este Registro", "Pos Express")
            Exit Sub
        End If

        txtCategorizacion.Enabled = True
        lblGuardar.Visible = True
        lblCancelar.Visible = True
        Nuevo = 2
        txtCategorizacion.Focus()
    End Sub
    Private Sub lblCancelar_Click(sender As Object, e As System.EventArgs) Handles lblCancelar.Click
        Try
            If dgvLinea.Rows.Count > 0 Then
                Dim codLineaTemp As String
                codLineaTemp = dgvLinea.CurrentRow.Cells("CODLINEA").Value
                If lblCategorizacion.Text = "Lineas" Then
                    '===========Cancelar y no perder el foco en linea y refresar la grilla====================
                    Me.LINEABindingSource.CancelEdit()
                    Me.LINEATableAdapter.Fill(DsCategorizacion.LINEA)

                    For i = 0 To dgvLinea.RowCount - 1
                        If dgvLinea.Rows(i).Cells("CODLINEA").Value = codLineaTemp Then
                            LINEABindingSource.Position = i
                        End If
                    Next
                    txtCategorizacion.Text = dgvLinea.CurrentRow.Cells("DESLINEA").Value
                End If
            End If
            If dgvRubro.Rows.Count > 0 Then
                Dim CODRUBRO1Temp As String
                CODRUBRO1Temp = dgvRubro.CurrentRow.Cells("CODRUBRO1").Value
                If lblCategorizacion.Text = "Rubros" Then
                    '===========Cancelar y no perder el foco en rubro  y refresar la grilla====================
                    Me.RUBROBindingSource.CancelEdit()
                    Me.RUBROTableAdapter.Fill(DsCategorizacion.RUBRO)
                    For i = 0 To dgvRubro.RowCount - 1
                        If dgvRubro.Rows(i).Cells("CODRUBRO1").Value = CODRUBRO1Temp Then
                            RUBROBindingSource.Position = i
                        End If
                    Next
                    txtCategorizacion.Text = dgvRubro.CurrentRow.Cells("DESRUBRO2").Value
                End If
            End If
            If dgvCategorias.Rows.Count > 0 Then
                Dim codFamiliaTemp As String
                codFamiliaTemp = dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value
                If lblCategorizacion.Text = "Familias" Then
                    '===========Cancelar y no perder el foco en familia  y refresar la grilla====================
                    Me.FAMILIABindingSource.CancelEdit()
                    Me.FAMILIATableAdapter.Fill(DsCategorizacion.FAMILIA)
                    For i = 0 To dgvCategorias.RowCount - 1
                        If dgvCategorias.Rows(i).Cells("CODFAMILIA").Value = codFamiliaTemp Then
                            FAMILIABindingSource.Position = i
                        End If
                    Next
                    txtCategorizacion.Text = dgvCategorias.CurrentRow.Cells("DESFAMILIA").Value
                End If
            End If
        Catch ex As Exception
            myTrans.Rollback()
            MessageBox.Show("Ocurrió un Error Durante la Operación" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        txtCategorizacion.Enabled = False
        lblGuardar.Visible = False
        lblModificar.Visible = True
        lblCancelar.Visible = False
        lblNuevo.Visible = True
        lblEliminar.Visible = True
        'pnlCategorias.Enabled = True
    End Sub
    Private Sub dgvLinea_Click(sender As Object, e As System.EventArgs) Handles dgvLinea.Click
        lblCategorizacion.Text = "Lineas"
        dgvLinea.BackgroundColor = Color.LightGray
        dgvLinea.DefaultCellStyle.BackColor = Color.LightGray
        dgvCategorias.BackgroundColor = Color.DarkGray
        dgvCategorias.DefaultCellStyle.BackColor = Color.DarkGray
        dgvRubro.BackgroundColor = Color.DarkGray
        dgvRubro.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvLinea.RowCount > 0 Then


            If IsDBNull(dgvLinea.CurrentRow.Cells("CODLINEA").Value) Or
               dgvLinea.CurrentRow.Cells("CODLINEA").Value Is Nothing Then
                dgvLinea.CurrentRow.Cells("CODLINEA").Value = dgvLinea.Rows(1).Cells("CODLINEA").Value
            End If

            txtCategorizacion.Text = dgvLinea.CurrentRow.Cells("DESLINEA").Value
        End If
    End Sub
    Private Sub dgvRubro_Click(sender As Object, e As System.EventArgs) Handles dgvRubro.Click
        Try

       
        lblCategorizacion.Text = "Rubros"
        dgvRubro.BackgroundColor = Color.LightGray
        dgvRubro.DefaultCellStyle.BackColor = Color.LightGray
        dgvLinea.BackgroundColor = Color.DarkGray
        dgvLinea.DefaultCellStyle.BackColor = Color.DarkGray
        dgvCategorias.BackgroundColor = Color.DarkGray
            dgvCategorias.DefaultCellStyle.BackColor = Color.DarkGray
            If dgvRubro.RowCount > 0 Then
                If IsDBNull(dgvRubro.CurrentRow.Cells("CODRUBRO1").Value) Or
                      dgvRubro.CurrentRow.Cells("CODRUBRO1").Value Is Nothing Then
                    dgvRubro.CurrentRow.Cells("CODRUBRO1").Value = dgvRubro.Rows(1).Cells("CODRUBRO1").Value
                End If
                txtCategorizacion.Text = dgvRubro.CurrentRow.Cells("DESRUBRO2").Value
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgvCategorias_Click(sender As Object, e As System.EventArgs) Handles dgvCategorias.Click
        lblCategorizacion.Text = "Familias"
        dgvCategorias.BackgroundColor = Color.LightGray
        dgvCategorias.DefaultCellStyle.BackColor = Color.LightGray
        dgvLinea.BackgroundColor = Color.DarkGray
        dgvLinea.DefaultCellStyle.BackColor = Color.DarkGray
        dgvRubro.BackgroundColor = Color.DarkGray
        dgvRubro.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvCategorias.RowCount > 0 Then
            If IsDBNull(dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value) Or
              dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value Is Nothing Then
                dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value = dgvCategorias.Rows(1).Cells("CODFAMILIA").Value
            End If
            txtCategorizacion.Text = dgvCategorias.CurrentRow.Cells("DESFAMILIA").Value
        End If
    End Sub

    Private Sub dgvCategorias_GotFocus(sender As Object, e As System.EventArgs) Handles dgvCategorias.GotFocus
        dgvCategorias.BackgroundColor = Color.LightGray
        dgvCategorias.DefaultCellStyle.BackColor = Color.LightGray
        dgvLinea.BackgroundColor = Color.DarkGray
        dgvLinea.DefaultCellStyle.BackColor = Color.DarkGray
        dgvRubro.BackgroundColor = Color.DarkGray
        dgvRubro.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvCategorias.RowCount > 0 Then
            If IsDBNull(dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value) Or
               dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value Is Nothing Then
                dgvCategorias.CurrentRow.Cells("CODFAMILIA").Value = dgvCategorias.Rows(1).Cells("CODFAMILIA").Value
            End If
            txtCategorizacion.Text = dgvCategorias.CurrentRow.Cells("DESFAMILIA").Value
        End If
    End Sub


    Private Sub dgvLinea_GotFocus(sender As Object, e As System.EventArgs) Handles dgvLinea.GotFocus
        dgvLinea.BackgroundColor = Color.LightGray
        dgvLinea.DefaultCellStyle.BackColor = Color.LightGray
        dgvCategorias.BackgroundColor = Color.DarkGray
        dgvCategorias.DefaultCellStyle.BackColor = Color.DarkGray
        dgvRubro.BackgroundColor = Color.DarkGray
        dgvRubro.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvLinea.RowCount > 0 Then
            If IsDBNull(dgvLinea.CurrentRow.Cells("CODLINEA").Value) Or
                dgvLinea.CurrentRow.Cells("CODLINEA").Value Is Nothing Then
                dgvLinea.CurrentRow.Cells("CODLINEA").Value = dgvLinea.Rows(1).Cells("CODLINEA").Value
            End If
            txtCategorizacion.Text = dgvLinea.CurrentRow.Cells("DESLINEA").Value
        End If
    End Sub
    Private Sub dgvRubro_GotFocus(sender As Object, e As System.EventArgs) Handles dgvRubro.GotFocus
        dgvRubro.BackgroundColor = Color.LightGray
        dgvRubro.DefaultCellStyle.BackColor = Color.LightGray
        dgvLinea.BackgroundColor = Color.DarkGray
        dgvLinea.DefaultCellStyle.BackColor = Color.DarkGray
        dgvCategorias.BackgroundColor = Color.DarkGray
        dgvCategorias.DefaultCellStyle.BackColor = Color.DarkGray
        If dgvRubro.RowCount > 0 Then
            If IsDBNull(dgvRubro.CurrentRow.Cells("CODRUBRO1").Value) Or
                dgvRubro.CurrentRow.Cells("CODRUBRO1").Value Is Nothing Then
                dgvRubro.CurrentRow.Cells("CODRUBRO1").Value = dgvRubro.Rows(1).Cells("CODRUBRO1").Value
            End If
            txtCategorizacion.Text = dgvRubro.CurrentRow.Cells("DESRUBRO2").Value
        End If
    End Sub

    
End Class