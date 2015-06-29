
Imports Osuna.Utiles.Conectividad
Imports System
Imports System.Data.SqlClient

Public Class MailingPromo
    Private ser As BDConexión.BDConexion
    Private sqlc As SqlConnection
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction

    Dim f As New Funciones.Funciones
    Dim sel As Integer
    Dim sql As String

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand
        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub btnActivarPrueba_Click(sender As System.Object, e As System.EventArgs) Handles btnActivarPrueba.Click

        'If LinkOn = 1 Then
        '    Me.Cursor = Cursors.AppStarting
        '    Dim myCommand As New MySqlCommand
        '    Dim consulta As String
        '    Dim YaProboSistema, SucLinkId As Integer

        ''If LinkOn = 1 Then
        ''    Me.Cursor = Cursors.AppStarting
        ''    Dim myCommand As New MySqlCommand
        ''    Dim consulta As String
        ''    Dim YaProboSistema, SucLinkId As Integer

        '    'Antes de Activar el periodo de Prueba debemos verificar si esta empres ya no probo antes el sistema
        '    SucLinkId = f.FuncionConsultaDecimal("LINKID", "SUCURSAL", "CODSUCURSAL", SucCodigo)

        ''    'Antes de Activar el periodo de Prueba debemos verificar si esta empres ya no probo antes el sistema
        ''    SucLinkId = f.FuncionConsultaDecimal("LINKID", "SUCURSAL", "CODSUCURSAL", SucCodigo)
        ''    YaProboSistema = VerificarLNK("CompanyBranchModuleId", "CompanyBranchModule", "ModuleId = 3 AND CompanyBranchid", SucLinkId)



        '    If YaProboSistema = 0 Then
        '        '1 - Generamos la fecha para el periodo de prueba
        '        Dim FechaPromo As Date = GenerarFechaPromo()
        '        Dim FechaPromoPeriodo As String = Format(FechaPromo, "yyyy-MM-dd")

        ''    If YaProboSistema = 0 Then
        ''        '1 - Generamos la fecha para el periodo de prueba
        ''        Dim FechaPromo As Date = GenerarFechaPromo()
        ''        Dim FechaPromoPeriodo As String = Format(FechaPromo, "yyyy-MM-dd")



        '        '2 - Obtenemos el IdLink de la Empresa
        '        Dim LinkID As Integer = f.FuncionConsultaDecimal("LINKID", "SUCURSAL", "CODSUCURSAL", SucCodigo)

        ''        '3 - Insertamos en la Base de datos de Link la fecha del Periodo de prueba / Mysql        
        ''        Try
        ''            LNKDB()
        ''            LNKConn.Open()

        '            consulta = "INSERT INTO Link.CompanyBranchModule (CompanyBranchId, ModuleId,TrailEndDat,Trail) " & _
        '                        "VALUES( " & LinkID & ", 3 ,'" & FechaPromoPeriodo & "', 1);"

        '            myCommand.Connection = LNKConn
        '            myCommand.CommandText = consulta
        '            myCommand.ExecuteNonQuery()
        '4 - Actualizamos la Tabla Link para indicar que modulo esta en periodo de prueba
        '            ser.Abrir(sqlc)
        '            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")


        '            cmd.Connection = sqlc
        '            cmd.Transaction = myTrans
        'sql = ""
        ''            sql = "UPDATE LINK SET PRUEBA = 1 WHERE LINKID = 3"

        '            cmd.CommandText = sql
        '            cmd.ExecuteNonQuery()
        '            myTrans.Commit()

        '            LNKConn.Close()
        '            LNKConn.Dispose()

        '            MessageBox.Show("Mailing fue habilitado con Exito, Ahora puede empezar a Probarlo por 15 Días!!!", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Catch ex As Exception
        '            MessageBox.Show("Error al Tratar de Habilitar el Modulo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End Try
        '    Else
        '        MessageBox.Show("Expiro su periodo de prueba, para mas informacion contacte a soporte@cogentpotential.com", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'Else
        '    MessageBox.Show("Necesita tener Internet para Habilitar este Modulo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        'Me.Cursor = Cursors.Arrow

        ''            MessageBox.Show("Mailing fue habilitado con Exito, Ahora puede empezar a Probarlo por 15 Días!!!", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''        Catch ex As Exception
        ''            MessageBox.Show("Error al Tratar de Habilitar el Modulo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ''        End Try
        ''    Else
        ''        MessageBox.Show("Expiro su periodo de prueba, para mas informacion contacte a soporte@cogentpotential.com", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ''    End If
        ''Else
        ''    MessageBox.Show("Necesita tener Internet para Habilitar este Modulo", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ''End If
        ''Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ComprasPromo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If LinkOn = 1 Then
            wwwLinkOn.BringToFront()
        Else
            pnlLinkOff.BringToFront()
        End If
    End Sub
End Class