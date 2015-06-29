Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ExportarImportarExcel

    #Region "Fields"

    Private cmd As SqlCommand

    '###################################
    Dim CodCliente, CodigoCliente, Nombre, RazonSocial, Ruc, Direccion, Telefono, Fax, Email, Obs As String
    Dim CodCodigo As String
    Dim CodProducto, CodigoProducto, DescProducto As String
    Dim CodProveedor, CodigoProveedor, NombreProveedor, RazonSocialProveedor, RucProveedor, DireccionProveedor, TelefonoProveedor, FaxProveedor, EmailProveedor, ObsProveedor As String
    Dim permiso As Double
    Dim codigocta, numerocuenta, descripcion, nivel, tipocuenta, asentable, destipocuenta As String

    Dim CodPlanCuenta, CodSucursal, CodUsuario, CodEmpresa, NumPlanCuenta, Desplancuenta, NivelCuenta As String

    Dim Existe As String
    Dim filename As String
    Private myTrans As SqlTransaction
    Dim NombrePlantilla As String

    '###############################3
    Dim Procesando As Integer
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Private sqlc As SqlConnection

    '#################################
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

    Private Sub BuscarPlantillaButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarPlantillaButton.Click
        If Procesando = 1 Then
            Exit Sub
        End If
        Dim openFD As New OpenFileDialog()
        Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim strConfigLoc As String = Asm.Location

        Dim strTemp As String
        strTemp = strConfigLoc
        strTemp = System.IO.Path.GetDirectoryName(strConfigLoc)
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Todos los archivos (*.xls)|*.xls"
            .Multiselect = False
            .InitialDirectory = System.IO.Path.GetDirectoryName(strConfigLoc)
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TextPathExcel.Text = .FileName
            End If
        End With
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Procesando = 1 Then
            Exit Sub
        End If
        Try
            Me.ExcelToSQLGridView.DataSource = Nothing
            Me.ExcelToSQLGridView.Rows.Clear()
            NroRegLabel.Visible = False
            Label3.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Sub Cargar( _
        ByVal dgView As DataGridView, _
        ByVal SLibro As String, _
        ByVal sHoja As String)
        'HDR=YES : Con encabezado
        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                           "Data Source=" & SLibro & ";" & _
                           "Extended Properties=""Excel 8.0;HDR=YES"""
        Try
            ' cadena de conexión
            Dim cn As New Odbc.OdbcConnection(cs)

            If Not System.IO.File.Exists(SLibro) Then
                MsgBox("No se encontró el Libro: " & _
                        SLibro, MsgBoxStyle.Critical, _
                       "Ruta inválida")
                Exit Sub
            End If

            ' se conecta con la hoja sheet 1
            Dim dAdapter As New OleDbDataAdapter("Select * From [" & sHoja & "$]", cs)

            Dim datos As New DataSet

            ' agrega los datos
            dAdapter.Fill(datos)

            With ExcelToSQLGridView
                ' llena el DataGridView
                .DataSource = datos.Tables(0)

                ' DefaultCellStyle: formato currency
                'para los encabezados 1,2 y 3 del DataGrid
                .Columns(1).DefaultCellStyle.Format = "c"
                '.Columns(2).DefaultCellStyle.Format = "c"
                '.Columns(3).DefaultCellStyle.Format = "c"
                '.Columns(4).DefaultCellStyle.Format = "c"
                '.Columns(5).DefaultCellStyle.Format = "c"
                '.Columns(6).DefaultCellStyle.Format = "c"
            End With

            'Nro registros
            Dim c As Integer = ExcelToSQLGridView.RowCount
            NroRegLabel.Visible = True
            Label3.Visible = True
            NroRegLabel.Text = c
        Catch oMsg As Exception
            MsgBox(oMsg.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CargarGrillaButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarGrillaButton.Click
        permiso = PermisoAplicado(UsuCodigo, 135)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Cargar la grilla", "Pos Express")
            Exit Sub
        End If

        If Procesando = 1 Then
            Exit Sub
        End If
        Cargar(ExcelToSQLGridView, TextPathExcel.Text, TextHoja.Text)
    End Sub

    Private Sub ClientesLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ClientesLinkLabel.LinkClicked
        Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim strConfigLoc As String = Asm.Location

        Dim strTemp As String
        strTemp = strConfigLoc
        strTemp = System.IO.Path.GetDirectoryName(strConfigLoc)
        Dim Archivo As String = strTemp + "\PlantillaClientes.xls"

        Try
            System.Diagnostics.Process.Start(Archivo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportarImportarExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 134)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
            Me.Close()
        End If

        Procesando = 0
        Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub GuardarBDButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarBDButton.Click
        If Procesando = 1 Then
            Exit Sub
        End If
        Dim c As Integer = ExcelToSQLGridView.RowCount

        Dim NroRegistros As Integer = ExcelToSQLGridView.RowCount
        If c < 1 Then
            MessageBox.Show("No hay datos para guardar", "POSEXPRESS")
            Exit Sub
        End If

        Try
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            'Sacamos el nombre de la plantilla
            Dim tama, posicion1 As Integer
            tama = TextPathExcel.Text.Length
            posicion1 = TextPathExcel.Text.LastIndexOf("\", tama)
            NombrePlantilla = TextPathExcel.Text.Substring(posicion1 + 1)

            If NombrePlantilla = "PlantillaClientes.xls" Then
                InsertaClientes()
            ElseIf NombrePlantilla = "PlantillaProductos.xls" Then
                InsertaProductos()
            ElseIf NombrePlantilla = "PlantillaProveedores.xls" Then
                InsertaProveedores()
            ElseIf NombrePlantilla = "PlanCuentas.xls" Then
                InsertaPlan()
            Else
                MessageBox.Show("Seleccione una Plantilla Excel válida para la carga de registros", "POSEXPRESS")
                Exit Sub
            End If

            GuardandoLabel.Visible = False
            RadWaitingBar1.Visible = False
            RadWaitingBar1.EndWaiting()
            Procesando = 0
            MessageBox.Show("" & NroRegistros & " Registros guardados correctamente", "POSEXPRESS")
            Me.ExcelToSQLGridView.DataSource = Nothing
            Me.ExcelToSQLGridView.Rows.Clear()

            NroRegLabel.Visible = False
            Label3.Visible = False

        Catch ex As Exception
            'Try
            '    myTrans.Rollback("Insertar")
            'Catch

            'End Try
            GuardandoLabel.Visible = False
            RadWaitingBar1.Visible = False
            RadWaitingBar1.EndWaiting()
            Procesando = 0
            MessageBox.Show("Error al guardar Clientes" & ex.Message & "", "POSEXPRESS")
            'NroRegLabel.Visible = False
            'Label3.Visible = False
        Finally
            sqlc.Close()

        End Try
    End Sub

    Private Sub InsertaAuditoria()
        Dim CODIGO As Integer = w.Maximo("CODIGO", "AUDITORIATABLAS") + 1
        sql = ""
        sql = "insert into AUDITORIATABLAS (CODIGO, EMPRESA, TABLA, NUMCODIGO, DESCRIPCION, FECHA, USUARIO, NIVEL, INSERTAR, MODIFICAR, ELIMINAR) VALUES ( " & CODIGO & ", " & EmpCodigo & ",  'COMPRAS', '" & CODIGO & "',  'INSERCIÓN EN TABLA COMPRAS DESDE EXCEL' , CONVERT(DATETIME, '" & Today & "', 103 ), '" & UsuDescripcion & "', Null , 1,  0 , 0 )"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaClientes()
        Dim c As Integer = ExcelToSQLGridView.RowCount

        For c = 1 To c
            CodCliente = w.Maximo("CODCLIENTE", "CLIENTES") + 1

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("CODIGO").Value) Then
                CodigoCliente = ""
            Else
                CodigoCliente = ExcelToSQLGridView.Rows(c - 1).Cells("CODIGO").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("NOMBRE").Value) Then
                Nombre = ""
            Else
                Nombre = ExcelToSQLGridView.Rows(c - 1).Cells("NOMBRE").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("RAZONSOCIAL").Value) Then
                RazonSocial = ""
            Else
                RazonSocial = ExcelToSQLGridView.Rows(c - 1).Cells("RAZONSOCIAL").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("DIRECCION").Value) Then
                Direccion = ""
            Else
                Direccion = ExcelToSQLGridView.Rows(c - 1).Cells("DIRECCION").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("RUC").Value) Then
                Ruc = ""
            Else
                Ruc = ExcelToSQLGridView.Rows(c - 1).Cells("RUC").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("TELEFONO").Value) Then
                Telefono = ""
            Else
                Telefono = ExcelToSQLGridView.Rows(c - 1).Cells("TELEFONO").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("FAX").Value) Then
                Fax = ""
            Else
                Fax = ExcelToSQLGridView.Rows(c - 1).Cells("FAX").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("EMAIL").Value) Then
                Email = ""
            Else
                Email = ExcelToSQLGridView.Rows(c - 1).Cells("EMAIL").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("OBS").Value) Then
                Obs = ""
            Else
                Obs = ExcelToSQLGridView.Rows(c - 1).Cells("OBS").Value
            End If

            sql = ""
            sql = "INSERT INTO CLIENTES (CODCLIENTE, NUMCLIENTE, NOMBRE, APELLIDO, DIRECCION, RUC, TELEFONO, FAX, EMAIL, OBSERVACION, CODUSUARIO, CODEMPRESA) " & _
                  " values (" & CodCliente & ", '" & CodigoCliente & "', '" & Replace(Nombre, "'", "''") & "', '" & Replace(RazonSocial, "'", "''") & "', '" & Replace(Direccion, "'", "''") & "', " & _
                  " '" & Ruc & "', '" & Telefono & "', '" & Fax & "', '" & Email & "', '" & Obs & "', " & UsuCodigo & ", " & EmpCodigo & ")"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            'Nro Registros isertados
            ' NroRegLabel.Text = c
            GuardandoLabel.Visible = True
            RadWaitingBar1.Visible = True
            RadWaitingBar1.StartWaiting()

            Procesando = 1

            Application.DoEvents()

        Next
    End Sub

    Private Sub InsertaProductos()
        Dim c As Integer = ExcelToSQLGridView.RowCount

        For c = 1 To c
            CodProducto = w.Maximo("CODPRODUCTO", "PRODUCTOS") + 1

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("CODIGOPRODUCTO").Value) Then
                CodigoProducto = ""
            Else
                CodigoProducto = ExcelToSQLGridView.Rows(c - 1).Cells("CODIGOPRODUCTO").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("DESCRIPCION").Value) Then
                DescProducto = ""
            Else
                DescProducto = ExcelToSQLGridView.Rows(c - 1).Cells("DESCRIPCION").Value
            End If

            sql = ""
            sql = "INSERT INTO PRODUCTOS (CODPRODUCTO, DESPRODUCTO, CODUSUARIO, CODEMPRESA, ESTADO, SERVICIO, PRODUCTO) " & _
                  " values (" & CodProducto & ", '" & Replace(DescProducto, "'", "''") & "', " & _
                  " " & UsuCodigo & ", " & EmpCodigo & ", 0, 0, 1)"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            CodCodigo = w.Maximo("CODCODIGO", "CODIGOS") + 1
            sql = ""
            sql = "INSERT INTO CODIGOS (CODCODIGO, CODPRODUCTO, CODIGO, CODUSUARIO, CODEMPRESA) " & _
                  " VALUES (" & CodCodigo & ", " & CodProducto & ", '" & CodigoProducto & "', " & _
                   " " & UsuCodigo & ", " & EmpCodigo & ")"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            'Nro Registros isertados
            ' NroRegLabel.Text = c
            GuardandoLabel.Visible = True
            RadWaitingBar1.Visible = True
            RadWaitingBar1.StartWaiting()

            Procesando = 1

            Application.DoEvents()

        Next
    End Sub

    Private Sub InsertaProveedores()
        Dim c As Integer = ExcelToSQLGridView.RowCount

        For c = 1 To c
            CodProveedor = w.Maximo("CODPROVEEDOR", "PROVEEDOR") + 1

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("CODIGO").Value) Then
                CodigoProveedor = ""
            Else
                CodigoProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("CODIGO").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("NOMBRE").Value) Then
                NombreProveedor = ""
            Else
                NombreProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("NOMBRE").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("RAZONSOCIAL").Value) Then
                RazonSocialProveedor = ""
            Else
                RazonSocialProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("RAZONSOCIAL").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("DIRECCION").Value) Then
                DireccionProveedor = ""
            Else
                DireccionProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("DIRECCION").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("RUC").Value) Then
                RucProveedor = ""
            Else
                RucProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("RUC").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("TELEFONO").Value) Then
                TelefonoProveedor = ""
            Else
                TelefonoProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("TELEFONO").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("FAX").Value) Then
                FaxProveedor = ""
            Else
                FaxProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("FAX").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("EMAIL").Value) Then
                EmailProveedor = ""
            Else
                EmailProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("EMAIL").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("OBS").Value) Then
                ObsProveedor = ""
            Else
                ObsProveedor = ExcelToSQLGridView.Rows(c - 1).Cells("OBS").Value
            End If

            sql = ""
            sql = "INSERT INTO PROVEEDOR (CODPROVEEDOR, NUMPROVEEDOR, NOMBRE, APELLIDO, DIRECCION, RUC_CIN, TELEFONO, FAX, EMAIL, OBSERVACION, CODUSUARIO, CODEMPRESA) " & _
                  " values (" & CodProveedor & ", '" & CodigoProveedor & "', '" & Replace(NombreProveedor, "'", "''") & "', '" & Replace(RazonSocialProveedor, "'", "''") & "', '" & Replace(DireccionProveedor, "'", "''") & "', " & _
                  " '" & RucProveedor & "', '" & TelefonoProveedor & "', '" & FaxProveedor & "', '" & EmailProveedor & "', '" & ObsProveedor & "', " & UsuCodigo & ", " & EmpCodigo & ")"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            'Nro Registros isertados
            ' NroRegLabel.Text = c
            GuardandoLabel.Visible = True
            RadWaitingBar1.Visible = True
            RadWaitingBar1.StartWaiting()

            Procesando = 1

            Application.DoEvents()

        Next
    End Sub
    Private Sub InsertaPlan()
        Dim c As Integer = ExcelToSQLGridView.RowCount

        For c = 1 To c
            Codigocta = w.Maximo("CODIGO", "PLANCUENTAS") + 1

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("CODIGO").Value) Then
                Codigocta = ""
            Else
                Codigocta = ExcelToSQLGridView.Rows(c - 1).Cells("codigo").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("Numerocuenta").Value) Then
                Numerocuenta = ""
            Else
                Numerocuenta = ExcelToSQLGridView.Rows(c - 1).Cells("Numerocuenta").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("descripcion").Value) Then
                descripcion = ""
            Else
                descripcion = ExcelToSQLGridView.Rows(c - 1).Cells("descripcion").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("nivel").Value) Then
                nivel = ""
            Else
                nivel = ExcelToSQLGridView.Rows(c - 1).Cells("nivel").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("tipocuenta").Value) Then
                tipocuenta = ""
            Else
                tipocuenta = ExcelToSQLGridView.Rows(c - 1).Cells("tipocuenta").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("asentable").Value) Then
                asentable = ""
            Else
                asentable = ExcelToSQLGridView.Rows(c - 1).Cells("asentable").Value
            End If

            If IsDBNull(ExcelToSQLGridView.Rows(c - 1).Cells("destipocuenta").Value) Then
                destipocuenta = ""
            Else
                destipocuenta = ExcelToSQLGridView.Rows(c - 1).Cells("destipocuenta").Value
            End If

            sql = ""
            sql = "INSERT INTO Plancuentas (CODPLANCUENTA, CODSUCURSAL, CODUSUARIO, CODEMPRESA, NUMPLANCUENTA, DESPLANCUENTA, TIPOCUENTA, NIVELCUENTA, ASENTABLE, CODMONEDA, DESTIPOCUENTA) " & _
                  " values (" & codigocta & ", '1', '" & UsuCodigo & "', '" & EmpCodigo & "', '" & numerocuenta & "', " & _
                  " '" & descripcion & "', '" & tipocuenta & "', '" & nivel & "', '" & asentable & "', '1', '" & destipocuenta & "')"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            'Nro Registros isertados
            ' NroRegLabel.Text = c
            GuardandoLabel.Visible = True
            RadWaitingBar1.Visible = True
            RadWaitingBar1.StartWaiting()

            Procesando = 1

            Application.DoEvents()

        Next
    End Sub

    Private Sub ProdLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ProdLinkLabel.LinkClicked
        Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim strConfigLoc As String = Asm.Location

        Dim strTemp As String
        strTemp = strConfigLoc
        strTemp = System.IO.Path.GetDirectoryName(strConfigLoc)
        Dim Archivo As String = strTemp + "\PlantillaProductos.xls"

        Try
            System.Diagnostics.Process.Start(Archivo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProvLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ProvLinkLabel.LinkClicked
        Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim strConfigLoc As String = Asm.Location

        Dim strTemp As String
        strTemp = strConfigLoc
        strTemp = System.IO.Path.GetDirectoryName(strConfigLoc)
        Dim Archivo As String = strTemp + "\PlantillaProveedores.xls"

        Try
            System.Diagnostics.Process.Start(Archivo)
        Catch ex As Exception

        End Try
    End Sub

    #End Region 'Methods

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles PlanLinkLabel4.LinkClicked
        Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim strConfigLoc As String = Asm.Location

        Dim strTemp As String
        strTemp = strConfigLoc
        strTemp = System.IO.Path.GetDirectoryName(strConfigLoc)
        Dim Archivo As String = strTemp + "\PlantillaCuentas.xls"

        Try
            System.Diagnostics.Process.Start(Archivo)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub planLinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles PlanLinkLabel4.LinkClicked
        Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim strConfigLoc As String = Asm.Location

        Dim strTemp As String
        strTemp = strConfigLoc
        strTemp = System.IO.Path.GetDirectoryName(strConfigLoc)
        Dim Archivo As String = strTemp + "\PlanCuentas.xls"

        Try
            System.Diagnostics.Process.Start(Archivo)
        Catch ex As Exception

        End Try
    End Sub
End Class