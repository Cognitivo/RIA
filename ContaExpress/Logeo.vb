Imports Osuna.Utiles.Configuracion
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Threading
Imports BDConexión

Public Class Logeo

#Region "Fields"
    Dim frmSplash As LogeoSplashScreen
    Dim codusu As New Funciones.Funciones
    Dim f As New Funciones.Funciones
    Dim dr As SqlDataReader
    Dim veces As Integer = 1
    Private treadSplash As Thread
    Dim BDConexion As New BDConexión.BDConexion
    Dim PrefUserName As String = ""
    Dim Completo, Simple As Integer
#End Region 'Fields

    Public Sub New()
        Me.InitializeComponent()
        BDConexion = New BDConexión.BDConexion
    End Sub

#Region "Methods"

    Private Sub Logeo_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If PrefUserName = "userPref" Or PrefUserName = "" Then
            UsernameTextBox.Focus()
        Else
            tbxPassSimple.Focus()
        End If
    End Sub

    Private Sub Logeo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Completo = 0 : Simple = 0
        treadSplash = New Thread(New ThreadStart(AddressOf Me.Splash))
        treadSplash.Start()

        Try
            LeerUserPref()
        Catch ex As Exception
        End Try

        Try
            BDConexion.Leer()
            EmpNomFantasia = f.FuncionTop1("NOMFANTASIA", "EMPRESA")

            If PrefUserName = "userPref" Or PrefUserName = "" Then
                pnlSimplificado.SendToBack()
                UsernameTextBox.Focus()
                Completo = 1
            Else
                lblUser.Text = "Hola " & PrefUserName & ", favor ingrese su contraseña"
                pnlComplejo.SendToBack()
                tbxPassSimple.Focus()
                Simple = 1
            End If

            Me.Text = "LogIn - " + EmpNomFantasia

        Catch ex As Exception
            MessageBox.Show("No logramos establecer una conexion con el Servidor. Automaticamente re-direcionaremos a la ventana de configuración.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CambioServidor.ShowDialog()
            Me.Close()
        Finally
            treadSplash.Abort()
        End Try
    End Sub

    Public Sub LeerUserPref()
        Try
            Dim XmlDocument As New System.Xml.XmlDocument
            XmlDocument.Load(BDConexion.LocateCreateXMLUserPref())
            Dim Node As System.Xml.XmlNode
            For Each Node In XmlDocument.Item("userPref")
                If Node.Name = "User" Then
                    PrefUserName = Node.Attributes.GetNamedItem("name").Value
                End If
            Next Node
            XmlDocument.Save(BDConexion.LocateCreateXMLUserPref())
        Catch ex As Exception
            MessageBox.Show("Usuario:" + ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub limpiar()
        UsernameTextBox.Text = "" : PasswordTextBox.Text = ""
        tbxPassSimple.Text = ""
    End Sub

    Public Sub EntrarSistema()
        Dim UsuEstado As Boolean
        Dim Usuario, Contrasenha As String

        Usuario = "" : Contrasenha = ""

        If Completo = 1 Then
            Usuario = UsernameTextBox.Text
            Contrasenha = PasswordTextBox.Text
        Else
            Usuario = PrefUserName
            Contrasenha = tbxPassSimple.Text
        End If

        If veces <= 3 Then      'Si son menos de 3 intentos
            dr = codusu.usuario(Usuario, Contrasenha, 1)
            Try
                'Para cualquier error
                Dim f As New Funciones.Funciones

                If dr.HasRows = True Then
                    dr.Read()
                End If

                UsuEstado = dr("ESTADO")
                If UsuEstado = False Then
                    MessageBox.Show("Acceso Denegado. El Usuario se encuentra en Estado Inactivo", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    UsuCodigo = 0 : Entrar = 0 : tbxPassSimple.Focus()
                    Exit Sub
                End If

                UsuCodigo = dr("codigo")
                UsuDescripcion = dr("usuario")
                UsuDescripcion = UsuDescripcion.Trim
                UsuPassword = dr("password")
                UsuNombre = dr("nombre")

                If IsDBNull(dr("imagen")) Then
                    UserImgFondo = Nothing
                Else
                    UserImgFondo = dr("imagen")
                End If

                EmpDescripcion = EmpNomFantasia
                Entrar = 1

                'Obtenemos la Sucursal y la Maquina
                leersucursal()
                leermaquina()
                EmpCodigo = 1 'Por defecto el codigo de empresa es 1

                Try
                    CODMONEDAPRINCIPAL = f.FuncionConsulta("Codmoneda", "Moneda", "Prioridad", 1)
                Catch ex As Exception
                End Try

                'Guardamos el usuario si marco la opcion de "Recordar usuario"
                If cbxRecodarUser.Checked = True Then
                    Try
                        Dim XmlDocument As New System.Xml.XmlDocument
                        XmlDocument.Load(BDConexion.LocateCreateXMLUserPref())
                        Dim Node As System.Xml.XmlNode

                        For Each Node In XmlDocument.Item("userPref")
                            If Node.Name = "User" Then
                                Node.Attributes.GetNamedItem("name").Value = UsernameTextBox.Text
                            End If
                        Next Node
                        XmlDocument.Save(BDConexion.LocateCreateXMLUserPref())
                    Catch ex As Exception
                        MessageBox.Show("Guardar Usuario:" + ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If

            Catch
                MessageBox.Show("Acceso Denegado", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                UsuCodigo = 0 : Entrar = 0
            Finally

                If UsuCodigo <> 0 Then 'validamos q la fecha del servidor sea igual a la fecha de la maquina
                    b = 1
                    Me.Close()
                Else
                    Call limpiar()
                End If

                dr.Close()
                veces = veces + 1
                codusu.usuario(UsernameTextBox.Text, PasswordTextBox.Text, 1).Close()
                UsernameTextBox.Focus()
            End Try
        Else
            veces = veces + 1
            Call limpiar()
        End If

        If veces <= 3 Then
            UsernameTextBox.Focus()
        Else
            MessageBox.Show("Es obvio que estas intentando adivinar! Porque no te tomas unos minutos para recordar y intentas de nuevo.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End
        End If
    End Sub

    Public Sub leersucursal()
        Try
            Dim XmlDocument As New System.Xml.XmlDocument
            Dim LocateXML As New BDConexion
            XmlDocument.Load(LocateXML.LocateCreateXMLconfiguraciones())
            Dim Node As System.Xml.XmlNode

            For Each Node In XmlDocument.Item("configuration").Item("Sucursal")
                If Node.Name = "add" Then
                    If Node.Attributes.GetNamedItem("key").Value = "Codigo" Then
                        SucCodigo = Node.Attributes.GetNamedItem("value").Value
                        SucDescripcion = Node.Attributes.GetNamedItem("descripcion").Value
                    End If
                End If
            Next Node
        Catch ex As Exception
            MessageBox.Show("Sucursal:" + ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub leermaquina()
        Try
            Dim XmlDocument As New System.Xml.XmlDocument
            Dim LocateXML As New BDConexion
            XmlDocument.Load(LocateXML.LocateCreateXMLconfiguraciones())
            Dim Node As System.Xml.XmlNode

            For Each Node In XmlDocument.Item("configuration").Item("Maquina")
                If Node.Name = "add" Then
                    If Node.Attributes.GetNamedItem("key").Value = "Codigo" Then
                        CodigoMaquina = Node.Attributes.GetNamedItem("value").Value
                        NumMaquinaGlobal = f.FuncionConsultaString("NUMMAQUINA", "PC", "IP", CodigoMaquina)
                        nommaquina = Node.Attributes.GetNamedItem("descripcion").Value
                    End If
                End If
            Next Node
        Catch ex As Exception
            MessageBox.Show("Maquina:" + ex.Message, "Cogent", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LinkLabelAqui_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelAqui.LinkClicked
        CambioServidor.ShowDialog()
    End Sub

    Public Sub Splash()
        frmSplash = New LogeoSplashScreen
        frmSplash.ShowDialog()
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        EntrarSistema()
    End Sub

    Private Sub PasswordTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasswordTextBox.GotFocus
        PasswordTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub PasswordTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then           'Enter
            EntrarSistema()
            KeyAscii = 0
        End If
    End Sub

    Private Sub UsernameTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.GotFocus
        UsernameTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub UsernameTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then           'Enter
            PasswordTextBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub PasswordTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasswordTextBox.LostFocus
        PasswordTextBox.BackColor = Color.Gainsboro
    End Sub

    Private Sub UsernameTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.LostFocus
        UsernameTextBox.BackColor = Color.Gainsboro
    End Sub

    Private Sub bckwrkSplash_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bckwrkSplash.Disposed
        frmSplash = New LogeoSplashScreen
        frmSplash.Close()
    End Sub

    Private Sub bckwrkSplash_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bckwrkSplash.DoWork
        frmSplash = New LogeoSplashScreen
        frmSplash.ShowDialog()
    End Sub

    Private Sub lblCambiarUsuario_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCambiarUsuario.LinkClicked
        pnlSimplificado.SendToBack()
        UsernameTextBox.Focus()
        Completo = 1
    End Sub
#End Region 'Methods

    Private Sub tbxPassSimple_GotFocus(sender As Object, e As System.EventArgs) Handles tbxPassSimple.GotFocus
        tbxPassSimple.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub tbxPassSimple_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxPassSimple.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then           'Enter
            EntrarSistema() : tbxPassSimple.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxPassSimple_LostFocus(sender As Object, e As System.EventArgs) Handles tbxPassSimple.LostFocus
        tbxPassSimple.BackColor = Color.Gainsboro
    End Sub

    Private Sub tbxPassSimple_Move(sender As Object, e As System.EventArgs) Handles tbxPassSimple.Move

    End Sub

    Private Sub tbxPassSimple_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxPassSimple.TextChanged

    End Sub
End Class