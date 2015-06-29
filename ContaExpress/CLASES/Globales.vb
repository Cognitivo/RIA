Imports System.Configuration
Imports System.Deployment
Imports System.IO
Imports System.Windows.Forms
Imports Osuna.Utiles.Configuracion
Imports System.Threading


Module Globales

#Region "Fields"
    Public vgProdProduccion, vgProdConsumoInterno As Integer
    Public ControlarStock As Integer
    Public b As Integer
    Public CodCobrador As Long 'para manejar el codigo de cobrador ingresado
    Public CodigoMaquina As Integer 'Trae el IP o Codigo de la Maquina
    Public CODMONEDAPRINCIPAL As Integer 'Codigo de la moneda principal del sistema
    Public EmpCodigo As Long 'para manejar el Codigo de la Empresa
    Public EmpDescripcion As String 'para manejar la Descripcion de la Empresa
    Public EmpNomFantasia As String
    Public Entrar As Long 'para usuario
    Public FECGRA As String
    Public FechaValidez As String
    Public FORMATOFECHA As String
    Public funcion As Funciones.Funciones
    Public IpMaquina As String 'para almacenar el numero de equipo
    Public MDI As Dashboard
    Public MONEDA1 As String 'moneda principal del sistema Ej : Gs.
    Public NombretablaBus As String 'para el buscador por descripcion y codigo
    Public nomImpresora As String 'para almacenar el balor de buscar
    Public nommaquina As String 'Nombre de la Maquina
    Public NroTimbrado As String
    Public NumBuscarCuenta As Long 'para almacenar el valor de buscar cuentas contables
    Public NumCaja As Long 'para manejar el codigo de caja ingresado
    Public NumeroCaja As String 'para manejar el numero de caja correspondiente
    Public NumMaquinaGlobal As String 'Trae el Nro de la Maquina o PC actual
    Public NumSistemas As String
    Public SucCodigo As Long 'para manejar el Codigo de la Sucursal
    Public SucDescripcion As String 'para manejar la Descripcion de la Sucursal
    Public unidadglobal As String
    Public UsuCajero As Integer 'para saber si es cajero o no el usuario logeado
    Public UserImgFondo As Integer
    Public QuemandoNro As Integer
    '#########################################################################
    Public UsuCodigo As Long 'para manejar el Usuario Logeado
    Public UsuDescripcion As String 'para manejar la Descripcion del Usuario Logeado
    Public UsuNivel As Integer 'para manejar el Nivel del Usuario
    Public UsuNombre As String 'nombre de usuario
    Public UsuPassword As String 'para manejar el Nivel del Usuario

    Public CodPeriodoFiscalGlobal As Integer
    Public DescPeriodoFiscalGlobal As String
    Public TraerPanelUtilidades As String
    Private Acceso As Logeo

    Public VGComprasFacil, VGComprasPlus As Integer
    '#########################################################################
    Public LinkOn As Integer = 0
    
#End Region 'Fields

#Region "Methods"

    Private Sub UbicarArchivoConfiguracion()
        Dim strTemp As String
        strTemp = Path.Combine(Config.DefaultApplicationDataPath, "Configuraciones.xml")

        If Not (File.Exists(strTemp)) Then
            File.Copy(Path.Combine(Application.StartupPath, "Configuraciones.xml"), strTemp)
        End If
        ' Return strTemp
    End Sub

    Private Sub DesencryptaApp()
        'desencryptar
        Dim config1 As Configuration = _
               ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim sect As ConnectionStringsSection = config1.ConnectionStrings
        If sect.SectionInformation.IsProtected Then
            sect.SectionInformation.UnprotectSection()
            config1.Save()
        End If
    End Sub

    Private Sub EncryptaApp()
        Dim config As Configuration = _
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        config.ConnectionStrings.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider")
        ' We must save the changes to the configuration file.
        config.Save(ConfigurationSaveMode.Full, True)

        ' Protect our vault
        Dim vaultProtector As New ConfigSectionProtector("Vault")
        vaultProtector.ProtectSection()

    End Sub

    Private Sub EstablecerConfiguracionRegional()
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-PY")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "."
        ' My.Computer.Registry.CurrentUser.OpenSubKey("Keyboard Layout\Preload", True).SetValue("Predeterminado", 2)
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("es-ES"))
    End Sub

    Sub Main()
        Dim result As System.Windows.Forms.DialogResult

        Try
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
            Dim configFileName As String

            configFileName = Path.Combine(Config.DefaultApplicationDataPath, "ContaExpress.exe.config")

            If (Not File.Exists(configFileName)) Then
                File.Copy(Path.Combine(Application.StartupPath, "ContaExpress.exe.config"), configFileName)
            End If

            Config.SetConfigFile(configFileName)
            Config.LoadConfigFile(configFileName)
            UbicarArchivoConfiguracion()

            Entrar = 0

            Acceso = New Logeo
            Acceso.ShowDialog()

            If Entrar = 0 Then
                End
            Else
                funcion = New Funciones.Funciones
                NumSistemas = funcion.FuncionConsulta("NUMSISTEMAS", "USUARIO", "CODUSUARIO", UsuCodigo)
                'informes = New EnviaInformes.EnviaInformes
                Dim MDI As New Dashboard

                EstablecerConfiguracionRegional()
                Dim permiso As Double
                permiso = PermisoAplicado(UsuCodigo, 136)
                If permiso = 1 Then
                    result = ElijeCaja.ShowDialog()

                    Select Case result
                        Case DialogResult.OK
                            Try
                                EliminaArchivosAppConfig()
                            Catch ex As Exception

                            End Try
                            Dashboard.ShowDialog()

                        Case DialogResult.Cancel
                            Application.Restart()
                    End Select
                Else

                End If
                Try
                    EliminaArchivosAppConfig()
                Catch ex As Exception

                End Try
                MDI.ShowDialog()


            End If
        Catch ex As Exception
            ' If MessageBox.Show("Occurio un Error no Controlada. Desea ver el Mensaje?", "Cogent SIG", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).No = DialogResult.Yes Then
            MessageBox.Show("Mensaje de Excepción: " + ex.Message, "Excepción General", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' End If
        End Try
    End Sub

    Private Sub EliminaArchivosAppConfig()
        Dim sPath1 As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
        Dim sPath2 As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)

        Dim archivo1 As String = "\ContaExpress.exe.config"
        Dim archivo2 As String = "\Configuraciones.xml"

        sPath1 += archivo1
        sPath2 += archivo2

        If Not File.Exists(sPath1) Then
        Else
            Kill(sPath1)
        End If

        If Not File.Exists(sPath2) Then
        Else
            Kill(sPath2)
        End If
    End Sub

#End Region 'Methods

End Module