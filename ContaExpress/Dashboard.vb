Imports System.Data.SqlClient
Imports System.Drawing.Color
Imports System.Drawing.Drawing2D
Imports System.Threading
Imports Telerik.WinControls
Imports Telerik.WinControls.Tests
Imports System.Net.Sockets
Imports System.IO
Imports System.Net

Public Class Dashboard

#Region "Fields"

    Dim a As Single

    'Agrupar
    Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
    Private da As SqlDataAdapter
    Dim DescripSuc, DescripMaq As String

    '#################################################################################################
    '***Variables de conexion u
    Dim ComercioPlus As Integer = 0
    Dim vProyectos As Integer = 0
    Dim ComercioPlusPrueba As Integer = 0
    Dim ContabilidadLite As Integer = 0
    Dim Contabilidad As Integer = 0
    Dim ContabilidadPrueba As Integer = 0
    Dim Produccion As Integer = 0
    Dim ProduccionPrueba As Integer = 0
    Dim Mailing As Integer = 0
    Dim MailingPrueba As Integer = 0
    Dim sentFuncion As New Funciones.Funciones
    Private ser As BDConexión.BDConexion 'en la transaccion**********************
    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Dim sql As String
    Private sqlc As SqlConnection
    Dim w As New Funciones.Funciones
    Dim f As New Funciones.Funciones
    Private myThreadPromo As Thread
    Private myThreadPermisos As Thread
    Private myThreadFunc As Thread
    Dim SucActiveLNK As Integer
    Dim SucLinkId As Integer
    Dim Config1, configDb2, config3, config4, config5, config6 As String
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

   

    Private Sub Dashboard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '******************************************************************************
        'Cuando se cierre el Dashboard debemos poner en cero el STATUS de la caja actual
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            Dim dtFecha As DateTime = DateTime.Now
            Dim Fecha

            Fecha = dtFecha.ToString("MM/dd/yyyy")
            Fecha = Fecha + dtFecha.ToString(" HH:mm:ss")

            sql = ""
            sql = "UPDATE CAJA SET FECGRA = CONVERT(DATETIME, '" & Fecha & "', 102) , ESTATUS = 0 WHERE NUMCAJA= " & NumCaja & " "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()

            'Si no esta activada la sucursal esto no debe hacer
            If SucActiveLNK = 1 Then
                '******************************************************************************
                'Despues de poner en 0 el STATUS verificamos que la caja este cerrada antes de salir
                Dim CodApertura, ExisteCierre As Double
                Dim CadenaSQL As String


                CadenaSQL = "id_caja = " & NumCaja & " AND codsucursal "
                CodApertura = w.MaximoconWhere("id_apertura", "aperturas", CadenaSQL, SucCodigo)

                ObtenerConfig()

                'Despues de obtener el ultimo codigo de apertura de dicha caja y usuario, verificamos si tiene un cierre
                If Config1 = "Si" Then
                    ExisteCierre = w.FuncionConsultaString("id_apertura", "cierres", "id_apertura", CodApertura)

                    If (ExisteCierre = 0) And (CodApertura <> 0) Then 'SINO TIENE UNA APERTURA NO PUEDE TENER UN CIERRE
                        If MessageBox.Show("La Caja esta Abierta ¿Esta seguro que desea salir?", "Verifique", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch

            End Try
            MessageBox.Show("No Logramos Cerrar la Caja :(", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            sqlc.Close()
        End Try

        End
    End Sub

    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Descomentar si se quiere aplicar a esta version un periodo de prueba de 30 dias
        'Dim objCommand As New SqlCommand
        'Dim FechaPeriodoFin As String = ""
        'Dim sql As String = ""
        'Dim FechaActual As String = Now.ToShortDateString.ToString

        'Try
        '    objCommand.CommandText = "SELECT CONVERT(CHAR(10),FECHAFIN,103) AS FECHAFIN FROM PERIODO"
        '    objCommand.Connection = New SqlConnection(ser.CadenaConexion)
        '    objCommand.Connection.Open()
        '    Dim odrPeriodo As SqlDataReader = objCommand.ExecuteReader()

        '    If odrPeriodo.HasRows Then
        '        Do While odrPeriodo.Read()
        '            FechaPeriodoFin = odrPeriodo("FECHAFIN")
        '        Loop
        '    End If

        '    odrPeriodo.Close()
        '    objCommand.Dispose()

        '    If FechaActual >= FechaPeriodoFin Then
        '        DeshabilitarSucursalPeriodo()
        '        MessageBox.Show("El Periodo de Prueba a Expirado, para mas informacion contactarse con soporte@cogentpotential.com", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Me.Close()
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        'End Try

        '1ro verificamos en la base de datos local si la sucursal esta activa
        Dim EstadoSucursal As Integer

        ser.Abrir(sqlc)
        Dim cmd As New SqlCommand("SELECT IMAGEN FROM USUARIOFONDO WHERE CODIMAGEN='" & UserImgFondo & "'", sqlc)
        Dim imageData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
        If Not imageData Is Nothing Then
            Using ms As New MemoryStream(imageData, 0, imageData.Length)
                ms.Write(imageData, 0, imageData.Length)
                Me.Background.BackgroundImage = Image.FromStream(ms, True)
                ms.Dispose()
            End Using
        End If

        'Verifica el estado de la sucursal
        SucLinkId = f.FuncionConsultaDecimal("LINKID", "SUCURSAL", "CODSUCURSAL", SucCodigo)
        EstadoSucursal = f.HAB(SucCodigo)

        ObtenerConfig()

        If EstadoSucursal = 1 Then
1:          SucActiveLNK = 1
            PanelUsuarios.BringToFront()
            Windows.Forms.Application.DoEvents()

            lblEmpresa.Text = EmpNomFantasia
            UsuarioLabel.Text = UsuNombre

            DescripSuc = f.FuncionConsultaString("DESSUCURSAL", "SUCURSAL", "CODSUCURSAL", SucCodigo)
            DescripMaq = f.FuncionConsultaString("DESCRIPCION", "PC", "CODSUCURSAL = " & SucCodigo & "AND IP ", CodigoMaquina)

            Me.SUCURSALTableAdapter.Fill(Me.DsDashboard.SUCURSAL)
            Me.DETPCTableAdapter.Fill(Me.DsDashboard.DETPC, SucCodigo)
            Me.CAJATableAdapter.Fill(Me.DsCaja.CAJA)

            Cmb_Sucursal.Text = DescripSuc
            SucDescripcion = DescripSuc
            Cmb_Maquina.Text = DescripMaq
            NumMaquinaGlobal = f.FuncionConsultaString("NUMMAQUINA", "PC", "CODSUCURSAL = " & SucCodigo & "AND IP ", CodigoMaquina)
            CmbCaja.Text = NumeroCaja

            lblUbicacion.Text = DescripSuc & " : " & DescripMaq & " : " & NumeroCaja

        Else
            'LinkOn = 1
            'SucActiveLNK = VerificarLNK("Active", "CompanyBranch", "BranchID", SucLinkId)
            'If SucActiveLNK = 1 Then
            '    GoTo 1
            'Else
            MessageBox.Show("Esta Instalacion se encuentra Deshabilitada, para mayor Informacion contactenos: 'soporte@cogentpotential.com'", "Servicio de Activacion / Desactivacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Exit Sub
            'End If
        End If
        Me.Refresh()
    End Sub

    Private Sub DeshabilitarSucursalPeriodo()
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = "OPEN SYMMETRIC KEY CogentTableKey " & _
                  "DECRYPTION BY CERTIFICATE EncryptCogentCert  " & _
                  "UPDATE Link SET UPD = ENCRYPTBYKEY ( KEY_GUID ( 'CogentTableKey' ), '123456' )  " & _
                  "OPEN SYMMETRIC KEY CogentTableKey " & _
                  "DECRYPTION BY CERTIFICATE EncryptCogentCert  " & _
                  "UPDATE SUCURSAL SET HAB = ENCRYPTBYKEY ( KEY_GUID ( 'CogentTableKey' ), '0' )  "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT CONFIG1,CONFIG2 FROM MODULO WHERE MODULO_ID = 23"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    Config1 = odrConfig("CONFIG1")
                    configDb2 = odrConfig("CONFIG2")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub VerificarFechaComercio()

        ''Verificamos si tiene conexion a internet
        'ConeccionInternet()

        'Verificamos si tiene conexion a internet
        'ConeccionInternet()


        'If LinkOn = 1 Then ' Verifica si tiene internet
        '    'Verifq si alguna Version de Prueba esta Activado
        '    Dim Comercio As Integer = w.FuncionConsultaDecimal("PRUEBA", "LINK", "LINKID", 1)
        '    If Comercio = 1 Then
        '        ComercioPlusPrueba = FuncionesLNK.PromoActivo(SucLinkId, 1)
        '    End If
        '    Dim Contabilidad As Integer = w.FuncionConsultaDecimal("PRUEBA", "LINK", "LINKID", 2)
        '    If Contabilidad = 1 Then
        '        ContabilidadPrueba = FuncionesLNK.PromoActivo(SucLinkId, 2)
        '    End If
        '    Dim Mailing As Integer = w.FuncionConsultaDecimal("PRUEBA", "LINK", "LINKID", 3)
        '    If Mailing = 1 Then
        '        MailingPrueba = FuncionesLNK.PromoActivo(SucLinkId, 3)
        '    End If

        '    'Verifica el estado de la sucursal
        '    Try
        '        SucActiveLNK = VerificarLNK("Active", "CompanyBranch", "BranchID", SucLinkId)
        '        SucLinkId = f.FuncionConsultaDecimal("LINKID", "SUCURSAL", "CODSUCURSAL", SucCodigo)
        '        Dim EstadoSucursal As Integer = f.HAB(SucCodigo)

        '        If SucActiveLNK = 0 Then
        '            'Update BDLocal
        '            ser.Abrir(sqlc)
        '            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        '            cmd.Connection = sqlc
        '            cmd.Transaction = myTrans

        '            Try
        '                sql = "OPEN SYMMETRIC KEY CogentTableKey  " & _
        '                      "DECRYPTION BY CERTIFICATE EncryptCogentCert " & _
        '                      "Update SUCURSAL " & _
        '                      "SET HAB = ENCRYPTBYKEY ( KEY_GUID ( 'CogentTableKey' ), '0' )  " & _
        '                      "WHERE(CODSUCURSAL =" & SucCodigo & ")"

        '                cmd.CommandText = sql
        '                cmd.ExecuteNonQuery()
        '                myTrans.Commit()
        '            Catch ex As Exception
        '            End Try

        '        ElseIf EstadoSucursal = 0 And SucActiveLNK = 1 Then
        '            'Update BDLocal
        '            ser.Abrir(sqlc)
        '            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        '            cmd.Connection = sqlc
        '            cmd.Transaction = myTrans

        '            Try
        '                sql = "OPEN SYMMETRIC KEY CogentTableKey  " & _
        '                      "DECRYPTION BY CERTIFICATE EncryptCogentCert " & _
        '                      "Update SUCURSAL " & _
        '                      "SET HAB = ENCRYPTBYKEY ( KEY_GUID ( 'CogentTableKey' ), '1' )  " & _
        '                      "WHERE(CODSUCURSAL =" & SucCodigo & ")"

        '                cmd.CommandText = sql
        '                cmd.ExecuteNonQuery()
        '                myTrans.Commit()
        '            Catch ex As Exception
        '            End Try
        '        End If
        '    Catch ex As Exception
        '    End Try


        '    'Verifica si existen modulos Nuevos
        '    Try
        '        Dim myCommand As New MySqlCommand
        '        Dim DataReader As MySqlDataReader
        '        Dim VerificarModulo, CompanyID As String
        '        Dim HayNuevos As Integer = 0
        '        Dim Purchase As Integer

        ''Verifica si existen modulos Nuevos
        'Try
        '    Dim myCommand As New MySqlCommand
        '    Dim DataReader As MySqlDataReader
        '    Dim VerificarModulo, CompanyID As String
        '    Dim HayNuevos As Integer = 0
        '    Dim Purchase As Integer




        '    CompanyID = f.FuncionConsultaString("NUMCLIENTECOGENT", "EMPRESA", "CODEMPRESA", 1)

        '        LNKDB()
        '        LNKConn.Open()

        '    LNKDB()
        '    LNKConn.Open()



        '        myCommand.Connection = LNKConn
        '        myCommand.CommandText = "SELECT ModuleId, Purchase FROM Link.CompanyBranchModule WHERE CompanyBranchID = " & SucLinkId
        '        DataReader = myCommand.ExecuteReader

        '    myCommand.Connection = LNKConn
        '    myCommand.CommandText = "SELECT ModuleId, Purchase FROM Link.CompanyBranchModule WHERE CompanyBranchID = " & SucLinkId
        '    DataReader = myCommand.ExecuteReader



        '        ser.Abrir(sqlc)

        '    ser.Abrir(sqlc)



        '        While DataReader.Read
        '            VerificarModulo = f.FuncionDECRYPTBYKEY(DataReader("ModuleId"))

        '    While DataReader.Read
        '        VerificarModulo = f.FuncionDECRYPTBYKEY(DataReader("ModuleId"))



        '            If Not IsDBNull(DataReader.GetValue(DataReader.GetOrdinal("Purchase"))) Then
        '                Purchase = 1
        '            Else
        '                Purchase = 0
        '            End If

        '        If Not IsDBNull(DataReader.GetValue(DataReader.GetOrdinal("Purchase"))) Then
        '            Purchase = 1
        '        Else
        '            Purchase = 0
        '        End If

        '            If (VerificarModulo <> "THS5uthA") And (Purchase = 1) Then   'Si esta Activo en LINK pero no el LOCAL

        '        If (VerificarModulo <> "THS5uthA") And (Purchase = 1) Then   'Si esta Activo en LINK pero no el LOCAL



        '                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        '                cmd.Connection = sqlc
        '                cmd.Transaction = myTrans

        '            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        '            cmd.Connection = sqlc
        '            cmd.Transaction = myTrans

        '                Try
        '                    sql = "OPEN SYMMETRIC KEY CogentTableKey  " & _
        '                          "DECRYPTION BY CERTIFICATE EncryptCogentCert " & _
        '                          "Update LINK " & _
        '                          "SET UPD = ENCRYPTBYKEY ( KEY_GUID ( 'CogentTableKey' ), 'THS5uthA' )  " & _
        '                          "WHERE(LINKID =" & DataReader("ModuleId") & ")"

        '            Try
        '                sql = "OPEN SYMMETRIC KEY CogentTableKey  " & _
        '                      "DECRYPTION BY CERTIFICATE EncryptCogentCert " & _
        '                      "Update LINK " & _
        '                      "SET UPD = ENCRYPTBYKEY ( KEY_GUID ( 'CogentTableKey' ), 'THS5uthA' )  " & _
        '                      "WHERE(LINKID =" & DataReader("ModuleId") & ")"



        '                    cmd.CommandText = sql
        '                    cmd.ExecuteNonQuery()

        '                cmd.CommandText = sql
        '                cmd.ExecuteNonQuery()
        '       

        '                    HayNuevos = 1
        '                Catch ex As Exception

        '                HayNuevos = 1
        '            Catch ex As Exception



        '                End Try

        '      
        '            ElseIf (VerificarModulo = "THS5uthA") And (Purchase = 0) Then 'Sino esta Activo LINK y si en el LOCAL
        '                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        '                cmd.Connection = sqlc
        '                cmd.Transaction = myTrans

        '        ElseIf (VerificarModulo = "THS5uthA") And (Purchase = 0) Then 'Sino esta Activo LINK y si en el LOCAL
        '            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        '            cmd.Connection = sqlc
        '            cmd.Transaction = myTrans

        '                Try
        '                    sql = "OPEN SYMMETRIC KEY CogentTableKey  " & _
        '                          "DECRYPTION BY CERTIFICATE EncryptCogentCert " & _
        '                          "Update LINK " & _
        '                          "SET UPD = ENCRYPTBYKEY ( KEY_GUID ( 'CogentTableKey' ), '123456' )  " & _
        '                          "WHERE(LINKID =" & DataReader("ModuleId") & ")"

        '            Try
        '                sql = "OPEN SYMMETRIC KEY CogentTableKey  " & _
        '                      "DECRYPTION BY CERTIFICATE EncryptCogentCert " & _
        '                      "Update LINK " & _
        '                      "SET UPD = ENCRYPTBYKEY ( KEY_GUID ( 'CogentTableKey' ), '123456' )  " & _
        '                      "WHERE(LINKID =" & DataReader("ModuleId") & ")"

        '                    cmd.CommandText = sql
        '                    cmd.ExecuteNonQuery()
        '                    myTrans.Commit()

        '                cmd.CommandText = sql
        '                cmd.ExecuteNonQuery()
        '                myTrans.Commit()

        '                    HayNuevos = 1
        '                Catch ex As Exception
        '                End Try
        '            End If
        '        End While

        '                HayNuevos = 1
        '            Catch ex As Exception
        '            End Try
        '        End If
        '    End While



        '        If HayNuevos = 1 Then
        '            MessageBox.Show("Usted tiene Habilitados Nuevos Modulos, Cierre Pos Express para visualizar el Cambio", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If

        '    If HayNuevos = 1 Then
        '        MessageBox.Show("Usted tiene Habilitados Nuevos Modulos, Cierre Pos Express para visualizar el Cambio", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Information)



        '        DataReader.Close()
        '        LNKConn.Close()
        '        sqlc.Close()
        '    Catch ex As Exception
        '    End Try
        'End If

        '    DataReader.Close()
        '    LNKConn.Close()
        '    sqlc.Close()
        'Catch ex As Exception
        'End Try
        'End If

    End Sub

    Private Sub EmailingPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailingPictureBox.Click
        If Mailing = 1 Then
            Me.Cursor = Cursors.AppStarting
            MailingMail.Show()
            MailingMail.Opacity = 1
            Me.Cursor = Cursors.Arrow
        Else
            MailingPromo.Show()
        End If
    End Sub

    Private Sub InventPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventPictureBox.Click
        Me.Cursor = Cursors.AppStarting
        Stock.Show()
        Stock.Opacity = 1
        Stock.tbxBuscador.Focus()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PanelMarketing_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelMarketing.Click
        Dim VerificarModulo As String
        MarketingPanel.BringToFront()

        VerificarModulo = f.FuncionDECRYPTBYKEY(3)
        If VerificarModulo = "THS5uthA" Then
            Mailing = 1
            EmailingPictureBox.Image = My.Resources.Mailing
        Else
            'Preguntamos si esta en modo Prueba...
            If (LinkOn = 1) And (MailingPrueba = 1) Then
                Mailing = 1
                EmailingPictureBox.Image = My.Resources.Mailing
            End If
        End If
    End Sub

    Private Sub PanelMarketing_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelMarketing.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        PanelMarketing.BackgroundImage = My.Resources.Marketing_MouseOver_
    End Sub

    Private Sub PanelMarketing_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelMarketing.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        PanelMarketing.BackgroundImage = My.Resources.Marketing_Normal_
    End Sub

    Private Sub PanelSettingGral_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelSettingGral.Click
        Me.Cursor = Cursors.AppStarting
        SETSettingsGeneral.Show()
        Me.Cursor = Cursors.Arrow
        SETSettingsGeneral.Opacity = 1
    End Sub

    Private Sub PanelSettingGral_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelSettingGral.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        PanelSettingGral.BackgroundImage = My.Resources.Configuracion_MouseOver_
    End Sub

    Private Sub PanelSettingGral_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelSettingGral.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        PanelSettingGral.BackgroundImage = My.Resources.Configuracion_Normal_
    End Sub

    Private Sub PbxProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbxProveedor.Click
        Me.Cursor = Cursors.AppStarting
        Proveedor.Show()
        Me.Cursor = Cursors.Arrow
        Proveedor.Opacity = 1
    End Sub

    Private Sub PbxProveedor_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PbxProveedor.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PctBoxConfirmaPagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PctBoxConfirmaPagos.Click
        If ComercioPlus = 1 Then
            Me.Cursor = Cursors.AppStarting
            PagosV2.Show()
            Me.Cursor = Cursors.Arrow
            PagosV2.Opacity = 1

            If PagosV2.Config4 = "N° de Proveedor" Then
                PagosV2.tbxNumCliPend.Focus()
            ElseIf PagosV2.Config4 = "N° de Factura" Then
                PagosV2.tbxNroFacturaPend.Focus()
            End If
        Else
            CommercioPromo.Show()
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxReporteCompra.Click
        ReporteCompras.Show()
    End Sub

    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxReporteCompra.MouseHover
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        ToolTip1.SetToolTip(PictureBoxReporteCompra, "REPORTE DE COMPRAS")
        ToolTip1.Active = True
    End Sub

    Private Sub PictureBoxAjuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxAjuste.Click
        Me.Cursor = Cursors.AppStarting
        AjusteInventario.Show()
        Me.Cursor = Cursors.Arrow
        AjusteInventario.Opacity = 1
        AjusteInventario.txtCodigoAjuste.Focus()
    End Sub

    Private Sub PictureBoxAuditoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxAuditoria.Click
        Me.Cursor = Cursors.AppStarting
        AuditoriaUsuarios.Show()
        Me.Cursor = Cursors.Arrow
        AuditoriaUsuarios.Opacity = 1
    End Sub

    Private Sub PictureBoxCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCaja.Click
        Me.Cursor = Cursors.AppStarting
        Dim AperturaCierreCaja As New AperturaCierreCaja
        AperturaCierreCaja.LblSucursal.Text = funcion.Descripcion_Tabla("DESSUCURSAL", "SUCURSAL", "CODSUCURSAL", SucCodigo, EmpCodigo)
        AperturaCierreCaja.LblCaja.Text = NumCaja
        AperturaCierreCaja.LblCajero.Text = UsuDescripcion
        AperturaCierreCaja.Show()
        Me.Cursor = Cursors.Arrow
        AperturaCierreCaja.Opacity = 1
    End Sub

    Private Sub PictureBoxCaja_MouselLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBoxCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCliente.Click
        Me.Cursor = Cursors.AppStarting

        If configDb2 = "Si" Then
            ClientesAdherentes.Show()
            ClientesAdherentes.Opacity = 1
            Me.Cursor = Cursors.Arrow
        Else
            ClientesV2.Show()
            ClientesV2.Opacity = 1
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub PictureBoxCliente_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxCliente.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBoxCobros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCobros.Click
        If ComercioPlus = 1 Then
            Me.Cursor = Cursors.AppStarting
            CobroV2.Show()
            Me.Cursor = Cursors.Arrow
            CobroV2.Opacity = 1

            If CobroV2.Config4 = "N° de Cliente" Then
                CobroV2.tbxNumCliPend.Focus()
            ElseIf CobroV2.Config4 = "N° de Factura" Then
                CobroV2.tbxNroFacturaPend.Focus()
            End If
        Else
            CommercioPromo.Show()
        End If
    End Sub

    Private Sub PictureBoxCombo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxCombo.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBoxComprasCompleja_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBoxCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCompras.Click
        Me.Cursor = Cursors.AppStarting
        CompraPlus.Show()
        Me.Cursor = Cursors.Arrow
        CompraPlus.Opacity = 1
    End Sub

    Private Sub PictureBoxDevoluciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxDevoluciones.Click
        If ComercioPlus = 1 Then
            Me.Cursor = Cursors.AppStarting
            Devoluciones.Show()
            Me.Cursor = Cursors.Arrow
            Devoluciones.Opacity = 1
        Else
            CommercioPromo.Show()
        End If
    End Sub

    Private Sub PictureBoxFacturacionPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxFacturacionPlus.Click
        If ComercioPlus = 1 Then
            Me.Cursor = Cursors.AppStarting
            VentasPlus.Show()
            VentasPlus.BuscarTextBox.Focus()
            VentasPlus.Opacity = 1
            Me.Cursor = Cursors.Arrow
        Else
            CommercioPromo.Show()
        End If
    End Sub

    Private Sub PictureBoxFacturacionSimple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxFacturacionSimple.Click
        Dim permiso As Double
        permiso = PermisoAplicado(UsuCodigo, 25)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Me.Cursor = Cursors.AppStarting
            VentasSimple.Show()
            Me.Cursor = Cursors.Arrow
            VentasSimple.Opacity = 1
        End If
    End Sub

    Private Sub PictureBoxInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxInventario.Click
        FiltroReporteInventario.Show()
    End Sub

    Private Sub PictureBoxInventario_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxInventario.MouseHover
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        ToolTip1.SetToolTip(PictureBoxInventario, "Reportes de Inventario y Stock")
        ToolTip1.Active = True
    End Sub

    Private Sub pbxCombos_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCombos.MouseHover
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        ToolTip1.SetToolTip(PictureBoxInventario, "Entrada y Salida de Combos")
        ToolTip1.Active = True
    End Sub

    Private Sub pbxCombos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCombos.Click
        If Produccion = 1 Then
            vgProdProduccion = 2 'Combos
            ComboSalEntrProduccion.Show()
            Me.Cursor = Cursors.Arrow
            ComboSalEntrProduccion.Opacity = 1
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub PictureBoxReporteProduccion_Click(sender As Object, e As System.EventArgs) Handles PictureBoxReporteProduccion.Click
        'If Produccion = 1 Then
        '    vgProdProduccion = 4 'Reportes
        '    ComboSalEntrProduccion.Show()
        '    Me.Cursor = Cursors.Arrow
        '    ComboSalEntrProduccion.Opacity = 1
        'Else
        FiltroReporteProduccion.Show()
        'End If
    End Sub

    Private Sub PictureBoxReporteProduccion_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxReporteProduccion.MouseHover
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        ToolTip1.SetToolTip(PictureBoxReporteProduccion, "Reportes de Producción")
        ToolTip1.Active = True
    End Sub

    Private Sub PictureBoxReporteVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxReporteVenta.Click
        FiltroReporteVentas.Show()
        FiltroReporteVentas.BuscarTextBox.Focus()
    End Sub

    Private Sub PictureBoxReporteVenta_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxReporteVenta.MouseHover
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        ToolTip1.SetToolTip(PictureBoxReporteVenta, "Reportes de Ventas")
        ToolTip1.Active = True
    End Sub

    Private Sub PictureBoxUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxUsuario.Click
        Me.Cursor = Cursors.AppStarting
        UsuarioV2.Show()
        Me.Cursor = Cursors.Arrow
        UsuarioV2.Opacity = 1
    End Sub

    Private Sub PictureBoxProductoI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxProductoI.Click
        Me.Cursor = Cursors.AppStarting
        Producto.Show()
        Producto.Opacity = 1
        Producto.BuscaProductoTextBox.Focus()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RadPanel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelCompras.Click
        Dim VerificarModulo As String
        AreaPanel.BringToFront()
        NumSistemas = 1
        ' If ComercioPlus = 0 Then
        VerificarModulo = f.FuncionDECRYPTBYKEY(1)
        If VerificarModulo = "THS5uthA" Then
            ComercioPlus = 1
            PictureBoxCompras.Image = My.Resources.COMPRASplus
            pbxDevolucionCompras.Image = My.Resources.devolucion1
            pbxNotaDebito.Image = My.Resources.Ndebito
            pbxUtilidades.Image = My.Resources.btnUtilidades
            btnCheques.Image = My.Resources.pbxCheques
        Else
            ComercioPlus = 2
            If (LinkOn = 1) And (ComercioPlusPrueba = 1) Then
                ComercioPlus = 1
                PictureBoxCompras.Image = My.Resources.COMPRASplus
                pbxDevolucionCompras.Image = My.Resources.devolucion1
                pbxNotaDebito.Image = My.Resources.Ndebito
                pbxUtilidades.Image = My.Resources.btnUtilidades
                btnCheques.Image = My.Resources.pbxCheques
            End If
        End If
    End Sub

    Private Sub RadPanel2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelCompras.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        RadPanelCompras.BackgroundImage = My.Resources.Compras_MouseOver_
    End Sub

    Private Sub RadPanel2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelCompras.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        RadPanelCompras.BackgroundImage = My.Resources.Compras_Normal_
    End Sub

    Private Sub RadPanel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelVentas.Click
        Dim VerificarModulo As String
        PanelVentas.BringToFront()
        NumSistemas = 1
        'If ComercioPlus = 0 Then
        VerificarModulo = f.FuncionDECRYPTBYKEY(1)
        If VerificarModulo = "THS5uthA" Then
            ComercioPlus = 1
            PictureBoxFacturacionPlus.Image = My.Resources.ventasplus
            PictureBoxDevoluciones.Image = My.Resources.devolucion1
            PictureBoxCobros.Image = My.Resources.cobro
            PictureBoxEnviomercaderia.Image = My.Resources.envio_mercaderia
            btnPagares.Image = My.Resources.btnPagares
            btnUtilVentas.Image = My.Resources.btnUtilidades
        Else
            ComercioPlus = 2
            'Preguntamos si esta en modo Prueba...
            If (LinkOn = 1) And (ComercioPlusPrueba = 1) Then
                ComercioPlus = 1
                PictureBoxFacturacionPlus.Image = My.Resources.ventasplus
                PictureBoxDevoluciones.Image = My.Resources.devolucion1
                PictureBoxCobros.Image = My.Resources.cobro
                PictureBoxEnviomercaderia.Image = My.Resources.envio_mercaderia
                btnPagares.Image = My.Resources.btnPagares
                btnUtilVentas.Image = My.Resources.btnUtilidades
            End If
        End If
        'End If
    End Sub

    Private Sub RadPanel3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelVentas.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        RadPanelVentas.BackgroundImage = My.Resources.Ventas_MouseOver_
    End Sub

    Private Sub RadPanel3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelVentas.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        RadPanelVentas.BackgroundImage = My.Resources.Ventas_Normal_
    End Sub

    Private Sub RadPanel4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelInventario.Click
        InventarioPanel.BringToFront()
        NumSistemas = 3
    End Sub

    Private Sub RadPanel4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelInventario.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        RadPanelInventario.BackgroundImage = My.Resources.Stock_MouseOver_
    End Sub

    Private Sub RadPanel4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelInventario.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        RadPanelInventario.BackgroundImage = My.Resources.Stock_Normal_
    End Sub

    Private Sub RadPanel6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelUsuarios.Click
        PanelUsuarios.BringToFront()
    End Sub

    Private Sub RadPanel6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelUsuarios.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        RadPanelUsuarios.BackgroundImage = My.Resources.Seguridad_MouseOver_
    End Sub

    Private Sub RadPanel6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadPanelUsuarios.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        RadPanelUsuarios.BackgroundImage = My.Resources.Seguridad_Normal_
    End Sub

    Private Sub UsuariosPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
    End Sub

    Private Sub UsuariosPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PanelContabalidadAbajo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelContabalidadAbajo.Click
        Dim VerificarModulo As String
        PanelContabilidad.BringToFront()
        'If Contabilidad = 0 Then
        VerificarModulo = f.FuncionDECRYPTBYKEY(2)
        If VerificarModulo = "THS5uthA" Then
            Contabilidad = 1
            PbxPlanCuenta.Image = My.Resources.PlanCuentas
            PbxLibroVenta.Image = My.Resources.LibVenta
            PbxLibroCompra.Image = My.Resources.LibCompra
            PbxAsientosCostos.Image = My.Resources.asientocosto
            PbxRegistrarAsientos.Image = My.Resources.ASIENTOS
            PbxPeriodoFiscal.Image = My.Resources.EjeContable
            PbxPlanillaContable.Image = My.Resources.PlantillaContable
            btnUtilidadesContabilidad.Image = My.Resources.btnUtilidades
        Else
            'Como contamos con un modulo de contabilidad Lite en caso que no sea la Full, debemos verificar si Lite esta activo
            Contabilidad = 2
            VerificarModulo = f.FuncionDECRYPTBYKEY(6)
            If VerificarModulo = "THS5uthA" Then
                ContabilidadLite = 1
                PbxPeriodoFiscal.Image = My.Resources.EjeContable
            End If
            If (LinkOn = 1) And (ContabilidadPrueba = 1) Then
                Contabilidad = 1
                PbxPlanCuenta.Image = My.Resources.PlanCuentas
                PbxLibroVenta.Image = My.Resources.LibVenta
                PbxLibroCompra.Image = My.Resources.LibCompra
                PbxAsientosCostos.Image = My.Resources.asientocosto
                PbxRegistrarAsientos.Image = My.Resources.ASIENTOS
                PbxPeriodoFiscal.Image = My.Resources.EjeContable
                PbxPlanillaContable.Image = My.Resources.PlantillaContable
                btnUtilidadesContabilidad.Image = My.Resources.btnUtilidades
            End If
        End If
        'End If
    End Sub

    Private Sub PbxPeriodoFiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbxPeriodoFiscal.Click
        If Contabilidad = 1 Or ContabilidadLite = 1 Then
            Dim F As New Funciones.Funciones
            Me.Cursor = Cursors.AppStarting
            PeriodoFiscalV2.Show()
            Me.Cursor = Cursors.Arrow
            PeriodoFiscal.Opacity = 1
        Else
            ContabilidadPromo.Show()
        End If
    End Sub

    Private Sub PbxPlanCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbxPlanCuenta.Click
        If Contabilidad = 1 Then
            Dim F As New Funciones.Funciones
            PlanCuentaV2.Show()
            Me.Cursor = Cursors.Arrow
            PlanCuentaV2.Opacity = 1
        Else
            ContabilidadPromo.Show()
        End If
    End Sub

    Private Sub PbxReporteContabilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbxReporteContabilidad.Click
        If Contabilidad = 1 Or ContabilidadLite = 1 Then
            Dim F As New Funciones.Funciones
            FiltroReporteContabilidad.Show()
            Me.Cursor = Cursors.Arrow
            FiltroReporteContabilidad.Opacity = 1
        Else
            ContabilidadPromo.Show()
        End If
    End Sub

    Private Sub Cmb_Maquina_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_Maquina.SelectedIndexChanged
        Try
            If (Me.Cmb_Maquina.Text <> "") Then
                Me.Cmb_Maquina.Text = "" : Me.CmbCaja.Text = ""
                SucCodigo = Cmb_Sucursal.SelectedValue
                CAJABindingSource.RemoveFilter()
                Me.CAJABindingSource.Filter = "CODSUCURSAL = " & SucCodigo
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmb_Sucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_Sucursal.SelectedIndexChanged
        Try
            If (Me.Cmb_Sucursal.Text <> "") Then
                SucCodigo = Cmb_Sucursal.SelectedValue
                Me.CmbCaja.Text = ""
                Me.CAJABindingSource.Filter = "CODSUCURSAL = 0"
                Me.DETPCTableAdapter.Fill(Me.DsDashboard.DETPC, SucCodigo)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PanelContabalidadAbajo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelContabalidadAbajo.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        PanelContabalidadAbajo.BackgroundImage = My.Resources.Conta_MouseOver_
    End Sub

    Private Sub PanelContabalidadAbajo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelContabalidadAbajo.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        PanelContabalidadAbajo.BackgroundImage = My.Resources.Conta_Normal_
    End Sub

    Private Sub bt_ayuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt_ayuda.Click
        Dim pag As String
        pag = "http://cogentpotential.com/soporte/"
        Shell("Explorer " & pag)
    End Sub

    Private Sub PanelLink_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelLink.MouseEnter
        PanelLink.BackgroundImage = My.Resources.Link_MouseOver_
    End Sub
    Private Sub PanelLink_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelLink.MouseLeave
        PanelLink.BackgroundImage = My.Resources.Link_Normal_
    End Sub

    Private Sub PanelLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelLink.Click
        Link.Show()
        Link.Opacity = 1
    End Sub

    Private Sub btnCerrarCambioSuc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarCambioSuc.Click
        Dim VerificarCaja, VerificaUser As Integer

        VerificarCaja = w.FuncionConsultaString("ESTATUS", "CAJA", "NUMCAJA", NumCaja)

        If CmbCaja.Text <> "" Then
            If VerificarCaja = 1 Then
                VerificaUser = w.FuncionConsultaString("CODUSUARIO", "CAJA", "NUMCAJA", NumCaja)
                If VerificaUser <> UsuCodigo Then
                    MessageBox.Show("Esta caja ya esta siendo usada por otro usuario", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CmbCaja.Focus()
                    ' Me.pnlCambioSucursal.Visible = False
                    Exit Sub
                End If
            End If
        End If

        'Datos de la Caja
        NumCaja = CmbCaja.SelectedValue
        NumeroCaja = CmbCaja.Text

        Try
            'Obtenemos el Nro de la Maquina
            NumMaquinaGlobal = w.FuncionConsultaString("NUMMAQUINA", "PC", "IP", Cmb_Maquina.SelectedValue)
            CodigoMaquina = Cmb_Maquina.SelectedValue : DescripMaq = Cmb_Maquina.Text
        Catch ex As Exception
            MessageBox.Show("Esta sucursal no tiene facturador", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cmb_Sucursal.Focus()
            Exit Sub
        End Try


        'Datos Sucursal
        SucCodigo = Cmb_Sucursal.SelectedValue
        DescripSuc = Cmb_Sucursal.Text
        SucDescripcion = DescripSuc

        pnlCambioSucursal.Visible = False
        lblUbicacion.Text = DescripSuc & " : " & DescripMaq & " : " & NumeroCaja
    End Sub

    Private Sub CmbCaja_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCaja.SelectedValueChanged
        If (Me.CmbCaja.Text <> "") Then
            NumCaja = CmbCaja.SelectedValue
            NumeroCaja = CmbCaja.Text
        End If
    End Sub

    Private Sub PbxLibroVenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PbxLibroVenta.Click
        If Contabilidad = 1 Then
            LibroVenta.Show()
            Me.Cursor = Cursors.Arrow
            LibroVenta.Opacity = 1
        Else
            ContabilidadPromo.Show()
        End If
    End Sub

    Private Sub PbxLibroCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbxLibroCompra.Click
        If Contabilidad = 1 Then
            LibrocompraV2.Show()
            Me.Cursor = Cursors.Arrow
            LibrocompraV2.Opacity = 1
        Else
            ContabilidadPromo.Show()
        End If
    End Sub

    Private Sub PbxPlanillaContable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbxPlanillaContable.Click
        If Contabilidad = 1 Then
            ContaPlantillas.Show()
            Me.Cursor = Cursors.Arrow
            ContaPlantillas.Opacity = 1
        Else
            ContabilidadPromo.Show()
        End If
    End Sub

    Private Sub PictureBoxCombo_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxCombo.Click
        ProductosAdjustePrecio.Show()
        Me.Cursor = Cursors.Arrow
        ProductosAdjustePrecio.Opacity = 1
    End Sub

    Private Sub PictureBoxComprasCompleja_Click(sender As System.Object, e As System.EventArgs)
        VGComprasPlus = 1
        VGComprasFacil = 0
        Me.Cursor = Cursors.AppStarting
        CompraPlus.Show()
        CompraPlus.BuscarCompraTextBox.Focus()
        Me.Cursor = Cursors.Arrow
        CompraPlus.Opacity = 1
    End Sub

    Private Sub PbxRegistrarAsientos_Click(sender As System.Object, e As System.EventArgs) Handles PbxRegistrarAsientos.Click
        If Contabilidad = 1 Then
            Asientos.Show()
            Me.Cursor = Cursors.Arrow
            Asientos.Opacity = 1
        Else
            ContabilidadPromo.Show()
        End If
    End Sub

    Private Sub pbxComprasPromo_Click(sender As System.Object, e As System.EventArgs)
        CommercioPromo.Show()
        Me.Cursor = Cursors.Arrow
        CommercioPromo.Opacity = 1
    End Sub

    Private Sub pbxCodigos_Click(sender As Object, e As System.EventArgs) Handles pbxCodigos.Click
        CodigodeBarra.Show()
        Me.Cursor = Cursors.Arrow
        CodigodeBarra.Opacity = 1
    End Sub

    Private Sub pbxComprasPromo_MouseLeave(sender As Object, e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub RadPanelProduccion_Click(sender As Object, e As System.EventArgs) Handles RadPanelProduccion.Click
        Dim VerificarModulo As String
        ProduccionPanelMenu.BringToFront()

        'Verificamos que tipo de produccion es Si FULL o LITE
        VerificarModulo = f.FuncionDECRYPTBYKEY(4)  'Produccion LITE - GUAZU
        If VerificarModulo = "THS5uthA" Then
            Produccion = 1
            ConsumoInternoPictureBox.Visible = True : ProduccionPictureBox.Visible = True : FraccionamientoPictureBox.Visible = True : pbxEtiquetas.Visible = True : pbxCombos.Visible = True : pbxAjustes.Visible = True
            PictureBoxOrdenProduccion.Visible = False : pbxRecetas.Visible = False : pbxPlanillaProduccion.Visible = False : pbxEtiquetasProduccion.Visible = False : pbxPlanilladeProduccion.Visible = False

            ConsumoInternoPictureBox.Image = My.Resources.ConsumoInterno
            ProduccionPictureBox.Image = My.Resources.EntradaSalidaProduccion
            FraccionamientoPictureBox.Image = My.Resources.EntradaSalidaFraccionamiento
            pbxEtiquetas.Image = My.Resources.SalidaCajasyEtiquetas
            pbxCombos.Image = My.Resources.EntradaSalidaCombos
            pbxAjustes.Image = My.Resources.AjustedeProduccion
            Exit Sub
        Else
            Produccion = 0
            ConsumoInternoPictureBox.Visible = True : ProduccionPictureBox.Visible = True : FraccionamientoPictureBox.Visible = True : pbxEtiquetas.Visible = True : pbxCombos.Visible = True : pbxAjustes.Visible = True
            PictureBoxOrdenProduccion.Visible = False : pbxRecetas.Visible = False : pbxPlanillaProduccion.Visible = False : pbxEtiquetasProduccion.Visible = False : pbxPlanilladeProduccion.Visible = False

            ConsumoInternoPictureBox.Image = My.Resources.ConsumoInternoInactivo
            ProduccionPictureBox.Image = My.Resources.EntradaSalidaProduccionInactivo
            FraccionamientoPictureBox.Image = My.Resources.EntradaSalidaFraccionamientoInactivo
            pbxEtiquetas.Image = My.Resources.SalidaCajasyEtiquetasInactivo
            pbxCombos.Image = My.Resources.EntradaSalidaCombosInactivo
            pbxAjustes.Image = My.Resources.AjustedeProduccionInactivo
        End If

        VerificarModulo = f.FuncionDECRYPTBYKEY(5)  'Produccion FULL - ENVASES
        If VerificarModulo = "THS5uthA" Then
            Produccion = 1
            ConsumoInternoPictureBox.Visible = False : ProduccionPictureBox.Visible = False : FraccionamientoPictureBox.Visible = False : pbxEtiquetas.Visible = False : pbxCombos.Visible = False : pbxAjustes.Visible = False
            PictureBoxOrdenProduccion.Visible = True : pbxRecetas.Visible = True : pbxPlanillaProduccion.Visible = True : pbxEtiquetasProduccion.Visible = True : pbxPlanilladeProduccion.Visible = True

            PictureBoxOrdenProduccion.Image = My.Resources.btnPedidoCliente
            pbxRecetas.Image = My.Resources.Recetas
            pbxPlanillaProduccion.Image = My.Resources.OrdenProduccion
            pbxEtiquetasProduccion.Image = My.Resources.etiquetas
            pbxPlanilladeProduccion.Image = My.Resources.Planilla_Produccoin
            Exit Sub
        Else
            Produccion = 0
            ConsumoInternoPictureBox.Visible = False : ProduccionPictureBox.Visible = False : FraccionamientoPictureBox.Visible = False : pbxEtiquetas.Visible = False : pbxCombos.Visible = False : pbxAjustes.Visible = False
            PictureBoxOrdenProduccion.Visible = True : pbxRecetas.Visible = True : pbxPlanillaProduccion.Visible = True : pbxEtiquetasProduccion.Visible = False : pbxPlanilladeProduccion.Visible = True

            PictureBoxOrdenProduccion.Image = My.Resources.btnPedidoClienteInactivo
            pbxRecetas.Image = My.Resources.RecetasInactivo
            pbxPlanillaProduccion.Image = My.Resources.OrdenProduccion2
            pbxEtiquetasProduccion.Image = My.Resources.etiquetas
            pbxPlanilladeProduccion.Image = My.Resources.Planilla_Produccoin_Inactivo
        End If
    End Sub

    Private Sub RadPanelProduccion_MouseEnter(sender As Object, e As System.EventArgs) Handles RadPanelProduccion.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        RadPanelProduccion.BackgroundImage = My.Resources.PRODUCCION_W_LABEL
    End Sub

    Private Sub RadPanelProduccion_MouseLeave(sender As Object, e As System.EventArgs) Handles RadPanelProduccion.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        RadPanelProduccion.BackgroundImage = My.Resources.PRODUCCION
    End Sub

#End Region 'Methods

    Private Sub PlanillaPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ConsumoInternoPictureBox.Click
        If Produccion = 1 Then
            vgProdConsumoInterno = 0  'Consumo Interno
            ProdConsumoInterno.Show()
            Me.Cursor = Cursors.Arrow
            ProdConsumoInterno.Opacity = 1
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub pbxDevolucionCompras_Click(sender As System.Object, e As System.EventArgs) Handles pbxDevolucionCompras.Click
        If ComercioPlus = 1 Then
            Me.Cursor = Cursors.AppStarting
            DevolucionCompra.Show()
            Me.Cursor = Cursors.Arrow
            DevolucionCompra.Opacity = 1
        Else
            CommercioPromo.Show()
        End If
    End Sub

    Private Sub ClientesMktPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ClientesMktPictureBox.Click
        If Mailing = 1 Then
            Me.Cursor = Cursors.AppStarting
            ClientesPersonas.Show()
            Me.Cursor = Cursors.Arrow
            ClientesPersonas.Opacity = 1
        Else
            MailingPromo.Show()
        End If
    End Sub

    Private Sub pbxSucursal_Click(sender As System.Object, e As System.EventArgs) Handles pbxSucursal.Click
        pnlCambioSucursal.Visible = True
        pnlCambioSucursal.BringToFront()
    End Sub

    Private Sub OrdenProdPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ProduccionPictureBox.Click
        If Produccion = 1 Then
            vgProdProduccion = 1  'Produccion
            ProdSalidaEntradaProduccion.Show()
            Me.Cursor = Cursors.Arrow
            ProdSalidaEntradaProduccion.Opacity = 1
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub FraccionamientoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles FraccionamientoPictureBox.Click
        If Produccion = 1 Then
            vgProdProduccion = 0 'Fraccionamiento
            FraccSaliaEntredaProduccion.Show()
            Me.Cursor = Cursors.Arrow
            FraccSaliaEntredaProduccion.Opacity = 1
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub pbxAjustes_Click(sender As System.Object, e As System.EventArgs) Handles pbxAjustes.Click
        If Produccion = 1 Then
            vgProdProduccion = 3  'Ajuste
            AjusteSalidaEntredaProduccion.Show()
            Me.Cursor = Cursors.Arrow
            AjusteSalidaEntredaProduccion.Opacity = 1
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub pbxEtiquetas_Click(sender As System.Object, e As System.EventArgs) Handles pbxEtiquetas.Click
        If Produccion = 1 Then
            vgProdConsumoInterno = 1  'Cajas y Etiquetas
            CajasEtiquetasConsumoInterno.Show()
            Me.Cursor = Cursors.Arrow
            CajasEtiquetasConsumoInterno.Opacity = 1
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub PbxAsientosCostos_Click(sender As System.Object, e As System.EventArgs) Handles PbxAsientosCostos.Click
        If Contabilidad = 1 Then
            AsientoCosto.Show()
            Me.Cursor = Cursors.Arrow
            AsientoCosto.Opacity = 1
        Else
            ContabilidadPromo.Show()
        End If
    End Sub

    Private Sub pbxAjusteStock_Click(sender As System.Object, e As System.EventArgs) Handles pbxAjusteStock.Click
        Me.Cursor = Cursors.AppStarting
        AjusteStock.Show()
        AjusteStock.Opacity = 1
        AjusteStock.tbxBuscador.Focus()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ConeccionInternet()
        Dim url As New System.Uri("http://www.google.com/")
        Dim req As System.Net.WebRequest
        req = System.Net.WebRequest.Create(url)
        Dim resp As System.Net.WebResponse

        Try
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            LinkOn = 1  'Si hay internet

        Catch ex As Exception
            req = Nothing
            LinkOn = 0  'No hay internet
        End Try
    End Sub

    Private Sub Dashboard_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Try
            myThreadPromo = New Thread(New ThreadStart(AddressOf VerificarFechaComercio))
            myThreadPromo.Start()
        Catch ex As Exception
        End Try

        Try
            myThreadPermisos = New Thread(New ThreadStart(AddressOf ExistePermiso))
            myThreadPermisos.Start()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnReporteAuditoria_Click(sender As System.Object, e As System.EventArgs) Handles btnReporteAuditoria.Click
        FiltroReporteAuditoria.Show()
    End Sub

    Private Sub pbxUtilidades_Click(sender As System.Object, e As System.EventArgs) Handles pbxUtilidades.Click
        If ComercioPlus = 1 Then
            TraerPanelUtilidades = "Compras"
            Me.Cursor = Cursors.AppStarting
            UtilidadesCogent.Show()
            Me.Cursor = Cursors.Arrow
            UtilidadesCogent.Opacity = 1
        Else
            CommercioPromo.Show()
        End If
    End Sub

    Private Sub pbxUtilidadesStock_Click(sender As System.Object, e As System.EventArgs) Handles pbxUtilidadesStock.Click
        TraerPanelUtilidades = "Stock"
        Me.Cursor = Cursors.AppStarting
        UtilidadesCogent.Show()
        Me.Cursor = Cursors.Arrow
        UtilidadesCogent.Opacity = 1
    End Sub

    Private Sub pbxTranferencias_Click(sender As System.Object, e As System.EventArgs) Handles pbxTranferencias.Click
        Me.Cursor = Cursors.AppStarting
        Transferencias.Show()
        Me.Cursor = Cursors.Arrow
        Transferencias.Opacity = 1
    End Sub

    Private Sub btnUtilidadesContabilidad_Click(sender As System.Object, e As System.EventArgs) Handles btnUtilidadesContabilidad.Click
        TraerPanelUtilidades = "Contabilidad"
        Me.Cursor = Cursors.AppStarting
        UtilidadesCogent.Show()
        Me.Cursor = Cursors.Arrow
        UtilidadesCogent.Opacity = 1
    End Sub

    Private Sub PictureBoxEnviomercaderia_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxEnviomercaderia.Click
        Me.Cursor = Cursors.AppStarting
        Envios.Show()
        Me.Cursor = Cursors.Arrow
        Envios.Opacity = 1
    End Sub

    Private Sub pbxNotaDebito_Click(sender As System.Object, e As System.EventArgs) Handles pbxNotaDebito.Click
        Me.Cursor = Cursors.AppStarting
        DevolucionCompraDebito.Show()
        Me.Cursor = Cursors.Arrow
        DevolucionCompraDebito.Opacity = 1
    End Sub

    Private Sub PanelBancosAbajo_Click(sender As Object, e As System.EventArgs) Handles PanelBancosAbajo.Click
        PanelBancos.BringToFront()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ReporteFlujoCaja.Show()
    End Sub


    Private Sub PanelBancosAbajo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelBancosAbajo.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        PanelBancosAbajo.BackgroundImage = My.Resources.Bancos1
    End Sub

    Private Sub PanelBancosAbajo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelBancosAbajo.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        PanelBancosAbajo.BackgroundImage = My.Resources.bancos
    End Sub

    Private Sub btnFlujodeCaja_Click(sender As System.Object, e As System.EventArgs) Handles btnFlujodeCaja.Click
        ReporteFlujoCaja.Show()
    End Sub

    Private Sub btnMovBancario_Click(sender As System.Object, e As System.EventArgs) Handles btnMovBancario.Click
        MovimientoBancario.Show()
    End Sub

    Private Sub pbxCombosKit_Click(sender As System.Object, e As System.EventArgs) Handles pbxCombosKit.Click
        Me.Cursor = Cursors.AppStarting
        Combos.Show()
        Combos.Opacity = 1
        Combos.BuscaProductoTextBox.Focus()
        Combos.Text = "Kits y Combos | COGENT SIG"
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBoxOrdenProduccion_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxOrdenProduccion.Click
        If Produccion = 1 Then
            Me.Cursor = Cursors.AppStarting
            PedidoCliente.Show()
            PedidoCliente.Opacity = 1
            Me.Cursor = Cursors.Arrow
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub pbxRecetas_Click(sender As System.Object, e As System.EventArgs) Handles pbxRecetas.Click
        If Produccion = 1 Then
            Me.Cursor = Cursors.AppStarting
            Combos.Show()
            Combos.Opacity = 1
            Combos.BuscaProductoTextBox.Focus()
            Combos.Text = "Recetas | COGENT SIG"
            Me.Cursor = Cursors.Arrow
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub pbxPlanillaProduccion_Click(sender As System.Object, e As System.EventArgs) Handles pbxPlanillaProduccion.Click
        If Produccion = 1 Then
            Me.Cursor = Cursors.AppStarting
            OrdenProduccion.Show()
            OrdenProduccion.Opacity = 1
            OrdenProduccion.BuscarTextBox.Focus()
            Me.Cursor = Cursors.Arrow
        Else
            ProduccionPromo.Show()
        End If
    End Sub
   
    Private Sub btnPagares_Click(sender As Object, e As EventArgs) Handles btnPagares.Click
        If ComercioPlus = 1 Then
            Me.Cursor = Cursors.AppStarting
            Venta_Pagare.Show()
            Me.Cursor = Cursors.Arrow
            Venta_Pagare.Opacity = 1
        Else
            CommercioPromo.Show()
        End If
    End Sub

    Private Sub pbxEtiquetasProduccion_Click(sender As Object, e As EventArgs) Handles pbxEtiquetasProduccion.Click
        If Produccion = 1 Then
            Me.Cursor = Cursors.AppStarting
            ImpEtiquetas.Show()
            ImpEtiquetas.Opacity = 1
            ImpEtiquetas.BuscarTextBox.Focus()
            Me.Cursor = Cursors.Arrow
        Else
            ProduccionPromo.Show()
        End If
    End Sub

    Private Sub PanelProyectos_Click(sender As Object, e As EventArgs) Handles PanelProyectos.Click
        Dim VerificarModulo As String
        ProyectosCentral.BringToFront()
        VerificarModulo = f.FuncionDECRYPTBYKEY(7)

        If VerificarModulo = "THS5uthA" Then
            vProyectos = 1
            pbxEventos.Image = My.Resources.btnProyectos
        End If
    End Sub

    Private Sub PanelProyectos_MouseEnter(sender As Object, e As EventArgs) Handles PanelProyectos.MouseEnter
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        PanelProyectos.BackgroundImage = My.Resources.MenuProyecto
    End Sub

    Private Sub PanelProyectos_MouseLeave(sender As Object, e As EventArgs) Handles PanelProyectos.MouseLeave
        Me.Cursor = System.Windows.Forms.Cursors.Default
        PanelProyectos.BackgroundImage = My.Resources.MenuProyecto2
    End Sub

    Private Sub pbxEventos_Click(sender As Object, e As EventArgs) Handles pbxEventos.Click
        If vProyectos = 1 Then
            Me.Cursor = Cursors.AppStarting
            'ProyectosV2.Show()
            'ProyectosV2.Opacity = 1
            'ProyectosV.txtBuscar.Focus()
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub btnUtilVentas_Click(sender As Object, e As EventArgs) Handles btnUtilVentas.Click
        If ComercioPlus = 1 Then
            TraerPanelUtilidades = "Ventas"
            Me.Cursor = Cursors.AppStarting
            UtilidadesCogent.Show()
            Me.Cursor = Cursors.Arrow
            UtilidadesCogent.Opacity = 1
        Else
            CommercioPromo.Show()
        End If
    End Sub

    Private Sub RadPanelCompras_Paint(sender As Object, e As PaintEventArgs) Handles RadPanelCompras.Paint

    End Sub

    Private Sub RadPanelProduccion_Paint(sender As Object, e As PaintEventArgs) Handles RadPanelProduccion.Paint

    End Sub

    Private Sub pbxPlanilladeProduccion_Click(sender As Object, e As EventArgs) Handles pbxPlanilladeProduccion.Click
        PlanillaProduccion.Show()
    End Sub
End Class