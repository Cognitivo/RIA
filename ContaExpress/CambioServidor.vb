Imports System.Configuration
Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports BDConexión

Class CambioServidor
    Private ServerName As SqlDataSourceEnumerator
    Private ServerList As DataTable
    Dim CadenaConexion As String = ""
    Dim SucursalID, MaquinaID As String
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim ds As DataSet
    Dim f As New Funciones.Funciones

    Private Sub chbxWinAuth_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxWinAuth.CheckedChanged
        tbxUserSQL.Enabled = False
        tbxPassSQL.Enabled = False
        btnConnectar.Focus()
    End Sub

    Private Sub chbxWinAuth_Unchecked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxWinAuth.CheckStateChanged
        If chbxWinAuth.Checked = True Then
            tbxUserSQL.Enabled = False
            tbxPassSQL.Enabled = False
            btnConnectar.Focus()
        Else
            tbxUserSQL.Enabled = True
            tbxPassSQL.Enabled = True
            tbxUserSQL.Focus()
        End If
    End Sub

    Private Sub btnBuscarSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarSQL.Click
        If btnBuscarSQL.Text = "Buscar" Then
            Me.Cursor = Cursors.AppStarting
            ServerName = SqlDataSourceEnumerator.Instance
            ServerList = New DataTable()
            ServerList = ServerName.GetDataSources()

            If ServerList.Rows.Count <> 0 Then
                Dim listServers As List(Of String) = New List(Of String)
                ' For each element in the datatable add a new element in the list
                For Each rowServer As DataRow In ServerList.Rows
                    If String.IsNullOrEmpty(rowServer("InstanceName").ToString()) Then
                        listServers.Add(rowServer("ServerName").ToString())
                    Else
                        listServers.Add(rowServer("ServerName").ToString() & "\" & rowServer("InstanceName").ToString())
                    End If
                Next
                Me.cbxSQLAddress.DataSource = listServers
            End If
            Me.Cursor = Cursors.Arrow
            tbxSQLAddress.Visible = False
            cbxSQLAddress.Focus()
            btnBuscarSQL.Text = "Manual"
        Else
            tbxSQLAddress.Visible = True
            tbxSQLAddress.Focus()
            btnBuscarSQL.Text = "Buscar"
        End If
    End Sub

    Private Sub btnConnectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnectar.Click
        Me.Cursor = Cursors.AppStarting
        Try
            tbxSQLAddress.Text = cbxSQLAddress.Text

            If chbxWinAuth.Checked = True Then
                CadenaConexion = "Data Source=" & tbxSQLAddress.Text & "; Initial Catalog=master;" & _
            " Trusted_Connection= Yes ;Connect Timeout=20;"
            Else
                CadenaConexion = "Data Source=" & tbxSQLAddress.Text & "; Initial Catalog=master;" & _
            "User Id=" & tbxUserSQL.Text & ";Password=" & tbxPassSQL.Text & ";Connect Timeout=20;"
            End If

            Using con As New SqlConnection(CadenaConexion)
                Try
                    con.Open()
                Catch ex As Exception
                    If MessageBox.Show("Falla de Connexion. Si desea ver la razon de la falla, oprima el boton 'Si'", "COGENT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = MsgBoxResult.Yes Then
                        MessageBox.Show(ex.Message, "Desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End Try

                Dim SelectDB As String = "SELECT name FROM sys.databases"
                Dim DBExists As Integer = 0
                Dim com As SqlCommand = New SqlCommand(SelectDB, con)
                Dim dr As SqlDataReader = com.ExecuteReader()
                Dim ListDB As List(Of String) = New List(Of String)
                While (dr.Read())
                    Dim BD As String = dr(0).ToString
                    If BD = "master" Or BD = "model" Or BD = "msdb" Or BD = "tempdb" Then
                        'Do Nothing *Don't Add into List
                    Else
                        ListDB.Add(dr(0).ToString())
                        DBExists = DBExists + 1
                    End If
                End While
                If DBExists > 0 Then
                    Me.cbxBDEmpresa.DataSource = ListDB
                    cbxBDEmpresa.Focus()

                    cbxBDEmpresa.Enabled = True
                    cbxBDSucursal.Enabled = True
                    cbxBDMaquina.Enabled = True
                Else
                    cbxBDEmpresa.Text = "No Existen Empresas"
                    MessageBox.Show("No existen Empresas (Bases de Datos) en el Servidor Selecionado", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al Connectar al Servidor. Favor verifique sus Credenciales", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim dataSource As String = tbxSQLAddress.Text
        Dim database As String = cbxBDEmpresa.Text
        Dim userName As String = tbxUserSQL.Text
        Dim userPassword As String = tbxPassSQL.Text
        Dim connectString As String = ""
        Dim efconnectString As String = ""
        Dim builder As New System.Data.SqlClient.SqlConnectionStringBuilder(connectString)
        Dim connString As String = ""

        builder.DataSource = dataSource
        builder.InitialCatalog = database
        builder.ConnectTimeout = 20
        builder.ApplicationName = "COGENT SIG"

        If chbxWinAuth.Checked = True Then
            builder.IntegratedSecurity = True
        Else
            builder.IntegratedSecurity = False
            builder.UserID = userName
            builder.Password = userPassword
        End If

        If cbxEncrytar.Checked = True Then
            builder.Encrypt = True
        End If

        connString = builder.ConnectionString

        Try
            Dim XmlDocument As New XmlDocument
            Dim LocateXML As New BDConexion
            XmlDocument.Load(LocateXML.LocateCreateXMLconnString())
            For Each Node In XmlDocument.Item("connectionStrings")
                If Node.Name = "add" Then
                    Node.attributes.getnameditem("connectionString").value = connString
                End If
            Next Node
            XmlDocument.Save(LocateXML.LocateCreateXMLconnString())
        Catch ex As Exception
        End Try

        'Guardamos los Datos de la Sucursal y de la Maquina
        GuardaSucursalConfiguraciones()
        GuardaMaquinaConfiguraciones()

        MessageBox.Show("Cogen SIG Reiniciará con la Nueva Conexión", "CogentSIG", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Application.Restart()
    End Sub

    Private Sub GuardaSucursalConfiguraciones()
        Dim XmlDocument As New System.Xml.XmlDocument
        Dim LocateXML As New BDConexion
        XmlDocument.Load(LocateXML.LocateCreateXMLconfiguraciones())
        Dim Node As System.Xml.XmlNode

        For Each Node In XmlDocument.Item("configuration").Item("Sucursal")
            If Node.Name = "add" Then
                If Node.Attributes.GetNamedItem("key").Value = "Codigo" Then
                    Node.Attributes.GetNamedItem("value").Value = SucursalID
                    Node.Attributes.GetNamedItem("descripcion").Value = cbxBDSucursal.Text
                End If
            End If
        Next Node

        XmlDocument.Save(LocateXML.LocateCreateXMLconfiguraciones())
    End Sub

    Private Sub GuardaMaquinaConfiguraciones()
        Dim XmlDocument As New System.Xml.XmlDocument
        Dim LocateXML As New BDConexion
        XmlDocument.Load(LocateXML.LocateCreateXMLconfiguraciones())
        Dim Node As System.Xml.XmlNode
        For Each Node In XmlDocument.Item("configuration").Item("Maquina")

            If Node.Name = "add" Then
                If Node.Attributes.GetNamedItem("key").Value = "Codigo" Then
                    'Obtenemos el Codigo de la Maquina
                    Dim objCommand As New SqlCommand

                    Try
                        If chbxWinAuth.Checked = True Then
                            CadenaConexion = "Data Source=" & tbxSQLAddress.Text & "; Initial Catalog=" & cbxBDEmpresa.Text & "; Trusted_Connection= Yes ;Connect Timeout=20;"
                        Else
                            CadenaConexion = "Data Source=" & tbxSQLAddress.Text & "; Initial Catalog=" & cbxBDEmpresa.Text & "; User Id=" & tbxUserSQL.Text & ";Password=" & tbxPassSQL.Text & ";Connect Timeout=20;"
                        End If

                        objCommand.CommandText = "SELECT IP FROM PC where CODSUCURSAL = " & SucursalID & " AND NOMBRE ='" & cbxBDMaquina.Text & "' "
                        objCommand.Connection = New SqlConnection(CadenaConexion)
                        objCommand.Connection.Open()

                        Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                        If odrConfig.HasRows Then
                            Do While odrConfig.Read()
                                MaquinaID = odrConfig("IP")
                            Loop
                        End If

                        odrConfig.Close()
                        objCommand.Dispose()
                    Catch ex As Exception
                    End Try

                    Node.Attributes.GetNamedItem("value").Value = MaquinaID
                    Node.Attributes.GetNamedItem("descripcion").Value = cbxBDMaquina.Text
                End If
            End If

        Next Node
        XmlDocument.Save(LocateXML.LocateCreateXMLconfiguraciones())
    End Sub

    Private Sub cbxBDEmpresa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxBDEmpresa.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then           'Enter
            cbxBDSucursal.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxBDEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxBDEmpresa.SelectedIndexChanged
        Dim Dt As DataTable
        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand

        If chbxWinAuth.Checked = True Then
            CadenaConexion = "Data Source=" & tbxSQLAddress.Text & "; Initial Catalog=" & cbxBDEmpresa.Text & "; Trusted_Connection= Yes ;Connect Timeout=20;"
        Else
            CadenaConexion = "Data Source=" & tbxSQLAddress.Text & "; Initial Catalog=" & cbxBDEmpresa.Text & "; User Id=" & tbxUserSQL.Text & ";Password=" & tbxPassSQL.Text & ";Connect Timeout=20;"
        End If

        Dim Cn As New SqlConnection(CadenaConexion)

        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "select rtrim(dessucursal) as Nombre, CODSUCURSAL as id From sucursal WHERE TIPOSUCURSAL = 'Solo Factura' OR TIPOSUCURSAL = 'Factura y Stock' ORDER BY DESSUCURSAL"
            .Connection = Cn
        End With

        Da.SelectCommand = Cmd
        Dt = New DataTable
        Da.Fill(Dt)

        With cbxBDSucursal
            .DisplayMember = "Nombre"
            .ValueMember = "id"
            .DataSource = Dt
        End With

        btnGuardar.Enabled = True
    End Sub

    Private Sub tbxSQLAddress_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxSQLAddress.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then           'Enter
            tbxUserSQL.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxSQLAddress_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxSQLAddress.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then           'Enter
            tbxUserSQL.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxUserSQL_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxUserSQL.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then           'Enter
            tbxPassSQL.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub tbxPassSQL_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxPassSQL.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then           'Enter
            btnConnectar.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxBDSucursal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxBDSucursal.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then           'Enter
            cbxBDMaquina.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxBDMaquina_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxBDMaquina.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        'Si es una tecla válida
        If KeyAscii = 13 Then           'Enter
            btnGuardar.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub cbxBDSucursal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxBDSucursal.SelectedIndexChanged
        Dim Dt As DataTable
        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand

        If cbxBDSucursal.Text <> "" Then
            If chbxWinAuth.Checked = True Then
                CadenaConexion = "Data Source=" & tbxSQLAddress.Text & "; Initial Catalog=" & cbxBDEmpresa.Text & "; Trusted_Connection= Yes ;Connect Timeout=20;"
            Else
                CadenaConexion = "Data Source=" & tbxSQLAddress.Text & "; Initial Catalog=" & cbxBDEmpresa.Text & "; User Id=" & tbxUserSQL.Text & ";Password=" & tbxPassSQL.Text & ";Connect Timeout=20;"
            End If

            'obtenemos la Sucursal
            Dim objCommand As New SqlCommand

            Try
                objCommand.CommandText = "SELECT CODSUCURSAL FROM SUCURSAL where DESSUCURSAL = '" & cbxBDSucursal.Text & "' "
                objCommand.Connection = New SqlConnection(CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        SucursalID = odrConfig("CODSUCURSAL")
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try

            Dim Cn As New SqlConnection(CadenaConexion)
            With Cmd
                .CommandType = CommandType.Text
                .CommandText = "select isnull(ltrim(NOMBRE),'') as Nombre, IP as id from pc where codsucursal = " & SucursalID & "  ORDER BY descripcion"
                .Connection = Cn
            End With

            Da.SelectCommand = Cmd
            Dt = New DataTable
            Da.Fill(Dt)

            If Dt.Rows.Count <> 0 Then
                With cbxBDMaquina
                    .DisplayMember = "Nombre"
                    .ValueMember = "id"
                    .DataSource = Dt
                End With
            Else
                cbxBDMaquina.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub CambioServidor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
