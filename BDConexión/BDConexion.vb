Imports System
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Osuna.Utiles.Configuracion

Public Class BDConexion
    Dim connStringDir As String
    Dim UserPrefDir As String

    Public connString As String
    Public Property CadenaConexion As String
        Get
            Return connString
        End Get
        Set(value As String)
            connString = value
        End Set
    End Property

    Public Sub New()
        Leer()
    End Sub

#Region "Functions"
    Public Function LocateCreateXMLconnString() '##Abhi: Looks for connectionString and creates if it does not find it
        connStringDir = Path.Combine(Config.DefaultApplicationDataPath, "appConnectionString.xml")
        If Not (File.Exists(connStringDir)) Then
            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appConnectionString.xml"), connStringDir)
        End If
        Return connStringDir
    End Function

    Public Function LocateCreateXMLconfiguraciones() '##Abhi: Looks for connectionString and creates if it does not find it
        connStringDir = Path.Combine(Config.DefaultApplicationDataPath, "Configuraciones.xml")
        If Not (File.Exists(connStringDir)) Then
            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuraciones.xml"), connStringDir)
        End If
        Return connStringDir
    End Function

    Public Function LocateXMLconnString() '##Abhi: Looks for connectionString
        Dim connStringDir As String
        connStringDir = Path.Combine(Config.DefaultApplicationDataPath, "appConnectionString.xml")
        Return connStringDir
    End Function

    Public Function LocateCreateXMLUserPref() '##Abhi: Looks for UserPref and creates if it does not find it
        UserPrefDir = Path.Combine(Config.DefaultApplicationDataPath, "userPref.xml")
        If Not (File.Exists(UserPrefDir)) Then
            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userPref.xml"), UserPrefDir)
        End If
        Return UserPrefDir
    End Function

    Public Function Abrir() As SqlConnection
        Dim conexion As System.Data.Common.DbConnection
        conexion = New System.Data.SqlClient.SqlConnection(CadenaConexion)
        conexion.Open()
        Return conexion
    End Function
#End Region

#Region "Subs"
    Public Sub Abrir(ByRef sqlc As SqlConnection)
        If sqlc.State = ConnectionState.Closed Then
            sqlc.ConnectionString = CadenaConexion
            sqlc.Open()
        End If
    End Sub

    Public Sub Leer()
        Dim XmlDocument As New System.Xml.XmlDocument
        XmlDocument.Load(LocateCreateXMLconnString())
        Dim Node As System.Xml.XmlNode
        For Each Node In XmlDocument.Item("connectionStrings")
            If Node.Name = "add" Then
                CadenaConexion = Node.Attributes.GetNamedItem("connectionString").Value
            End If
        Next Node
        XmlDocument.Save(LocateCreateXMLconnString())
    End Sub

    Private Sub DesencryptaApp()
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
        Dim sect1 As ConnectionStringsSection = config.ConnectionStrings
        sect1.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider")
        config.Save()
    End Sub

#End Region 'Subs

End Class