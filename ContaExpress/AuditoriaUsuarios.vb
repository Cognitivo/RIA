Imports System.Data.SqlClient

Public Class AuditoriaUsuarios
    Private ser As BDConexión.BDConexion
    Private sqlc As SqlConnection
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim permiso As Double

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion()

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub AuditoriaUsuarios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 140)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        CmbAño.SelectedText = Today.Year.ToString
        CmbMes.SelectedIndex = Today.Month - 1

        FechaFiltro()
        Me.MODULOCABECERATableAdapter.Fill(Me.DsAuditoriaUsuario.MODULOCABECERA)
    End Sub

    Private Sub dgvModulo_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvModulo.SelectionChanged

        If dgvModulo.RowCount <> 0 Then
            lblModuloName.Text = dgvModulo.CurrentRow.Cells("DataGridViewTextBoxColumn3").Value

            dgwAuditoria.DataSource = Nothing
            If dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 7 Then
                CargarModuloCliente()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 8 Then  'Ventas
                CargarModuloClienteVentasPlus()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 26 Then
                CargarModuloClienteContabilidad()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 11 Then
                CargarModuloClienteDevoluciones()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 2 Then
                CargarModuloProveedor()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 12 Then
                CargarModuloProducto()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 3 Then
                CargarModuloProveedorCompra()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 28 Then
                CargarModuloProduccion()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 19 Then
                CargarModuloConfiguracion()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 5 Then
                CargarModuloCajas()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 10 Then   'Cobros
                CargarModuloCobros()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 29 Then
                CargarModuloDevolucionCompras()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 4 Then
                CargarModuloPagos()
            ElseIf dgvModulo.CurrentRow.Cells("MODULO_ID2").Value = 9 Then
                CargarModuloMovimientos()
            End If
        End If

        lblDGVCant.Text = "Cantidad de Registros = " & dgwAuditoria.RowCount
        If dgwAuditoria.RowCount = 0 Then
            Me.AUDITORIADETALLETableAdapter.Fill(Me.DsAuditoriaUsuario.AUDITORIADETALLE, 0, 0)
        End If
    End Sub

    Private Sub CargarModuloCliente()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, " & _
                                         "dbo.CLIENTES.NOMBRE  " & _
                                         "FROM  dbo.AUDITORIA INNER JOIN dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID INNER JOIN  " & _
                                         "dbo.CLIENTES ON dbo.AUDITORIA.IDTRANS = dbo.CLIENTES.CODCLIENTE " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.CLIENTES.NOMBRE,dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 7) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloClienteVentasPlus()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, " & _
                                  "dbo.VENTAS.NOMBRECLIENTE   FROM dbo.AUDITORIA INNER JOIN dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID INNER JOIN " & _
                                  "dbo.VENTAS ON dbo.AUDITORIA.IDTRANS = dbo.VENTAS.CODVENTA " & _
                                  "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.AUDITORIA.FECHA, " & _
                                  "dbo.VENTAS.NOMBRECLIENTE  " & _
                                  "HAVING (dbo.AUDITORIA.IDMODULO = 8) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                  "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)

            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False : dgwAuditoria.Columns("IDTRANS").Width = 30
            dgwAuditoria.Columns("IDMODULO").Visible = False : dgwAuditoria.Columns("IDMODULO").Width = 120
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloClienteContabilidad()

        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, " & _
                                         "dbo.AUDITORIA.DETALLE  " & _
                                         "FROM            dbo.AUDITORIA INNER JOIN  " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.AUDITORIA.DETALLE, dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 26) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloClienteDevoluciones()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, " & _
                                         "dbo.CLIENTES.NOMBRE  " & _
                                         "FROM  dbo.AUDITORIA INNER JOIN dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID INNER JOIN  " & _
                                         "dbo.CLIENTES ON dbo.AUDITORIA.IDTRANS = dbo.CLIENTES.CODCLIENTE " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.CLIENTES.NOMBRE, dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 11) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloProveedor()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = " SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDMODULO, dbo.AUDITORIA.IDTRANS,  " & _
                                         "dbo.PROVEEDOR.NOMBRE  " & _
                                         "FROM dbo.PROVEEDOR INNER JOIN dbo.AUDITORIA INNER JOIN " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID ON dbo.PROVEEDOR.CODPROVEEDOR = dbo.AUDITORIA.IDTRANS  " & _
                                         "GROUP BY dbo.AUDITORIA.IDMODULO, dbo.AUDITORIA.IDTRANS, dbo.PROVEEDOR.NOMBRE,dbo.AUDITORIA.FECHA   " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 2) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloProveedorCompra()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO,  " & _
                                         "dbo.PROVEEDOR.NOMBRE  " & _
                                         "FROM dbo.AUDITORIA INNER JOIN  " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID INNER JOIN  " & _
                                         "dbo.COMPRAS ON dbo.AUDITORIA.IDTRANS = dbo.COMPRAS.CODCOMPRA INNER JOIN  " & _
                                         "dbo.PROVEEDOR ON dbo.COMPRAS.CODPROVEEDOR = dbo.PROVEEDOR.CODPROVEEDOR  " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.PROVEEDOR.NOMBRE, dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 3)  AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"


            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloProducto()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = " SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDMODULO, dbo.AUDITORIA.IDTRANS,  " & _
                                         "dbo.PRODUCTOS.DESPRODUCTO  " & _
                                         "FROM dbo.PRODUCTOS INNER JOIN dbo.AUDITORIA INNER JOIN " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID ON dbo.PRODUCTOS.CODPRODUCTO = dbo.AUDITORIA.IDTRANS  " & _
                                         "GROUP BY dbo.AUDITORIA.IDMODULO, dbo.AUDITORIA.IDTRANS, dbo.PRODUCTOS.DESPRODUCTO,dbo.AUDITORIA.FECHA, dbo.AUDITORIA.IDUSUARIO   " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 12) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103))   " & _
                                         "AND (dbo.AUDITORIA.IDUSUARIO IS NOT NULL)   ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloProduccion()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT  MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, " & _
                                         "dbo.AUDITORIA.DETALLE  " & _
                                         "FROM dbo.AUDITORIA INNER JOIN  " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.AUDITORIA.DETALLE,dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 28) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloConfiguracion()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT  MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO,  " & _
                                         "dbo.AUDITORIA.DETALLE  " & _
                                         "FROM dbo.AUDITORIA INNER JOIN  " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.AUDITORIA.DETALLE, dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 19) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloCajas()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT  MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO,  " & _
                                         "dbo.AUDITORIA.DETALLE  " & _
                                         "FROM dbo.AUDITORIA INNER JOIN  " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.AUDITORIA.DETALLE, dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 5) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub


    Private Sub CargarModuloCobros()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO,  " & _
                                         "dbo.AUDITORIA.DETALLE  " & _
                                         "FROM dbo.AUDITORIA INNER JOIN  " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.AUDITORIA.DETALLE, dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 10) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloDevolucionCompras()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, " & _
                                         "dbo.PROVEEDOR.NOMBRE  " & _
                                         "FROM  dbo.AUDITORIA INNER JOIN dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID INNER JOIN  " & _
                                         "dbo.PROVEEDOR ON dbo.AUDITORIA.IDTRANS = dbo.PROVEEDOR.CODPROVEEDOR " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.PROVEEDOR.NOMBRE, dbo.AUDITORIA.FECHA  " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 29) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloPagos()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT  MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO,  " & _
                                         "dbo.AUDITORIA.DETALLE  " & _
                                         "FROM dbo.AUDITORIA INNER JOIN  " & _
                                         "dbo.MODULO ON dbo.AUDITORIA.IDMODULO = dbo.MODULO.MODULO_ID " & _
                                         "GROUP BY dbo.AUDITORIA.IDTRANS, dbo.AUDITORIA.IDMODULO, dbo.MODULO.MODULO, dbo.AUDITORIA.IDUSUARIO, dbo.AUDITORIA.DETALLE ,dbo.AUDITORIA.FECHA " & _
                                         "HAVING (dbo.AUDITORIA.IDMODULO = 4) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                         "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = False
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarModuloMovimientos()
        Try
            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand

            Dim query As String = "SELECT DISTINCT  MAX(CONVERT(varchar(10), dbo.AUDITORIA.FECHA, 103)) AS FECHA, dbo.AUDITORIA.IDMODULO, dbo.AUDITORIA.IDTRANS, " & _
                                  "dbo.SUCURSAL.DESSUCURSAL  FROM  dbo.AUDITORIA INNER JOIN dbo.MOVPRODUCTO ON dbo.AUDITORIA.IDTRANS = dbo.MOVPRODUCTO.MODULOTRANSID INNER JOIN  " & _
                                  "dbo.SUCURSAL ON dbo.MOVPRODUCTO.CODDEPOSITO = dbo.SUCURSAL.CODSUCURSAL  " & _
                                  "GROUP BY dbo.AUDITORIA.IDMODULO, dbo.AUDITORIA.IDTRANS, dbo.SUCURSAL.DESSUCURSAL, dbo.AUDITORIA.FECHA  " & _
                                  "HAVING (dbo.AUDITORIA.IDMODULO = 13) AND (dbo.AUDITORIA.FECHA >= CONVERT(DATETIME,'" & FechaFiltro1 & "', 103)) AND (dbo.AUDITORIA.FECHA <= CONVERT(DATETIME, '" & FechaFiltro2 & "', 103)) " & _
                                  "ORDER BY FECHA"
            ser.Abrir(sqlc)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = sqlc

            dr = cmd.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)
            dgwAuditoria.DataSource = dt

            dgwAuditoria.Columns("IDTRANS").Visible = True
            dgwAuditoria.Columns("IDMODULO").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FechaFiltro()
        Try
            Dim nromes, nroaño As Integer
            Dim fechacompleta1, fechacompleta2, mes As String

            'Obtenemos el Mes y Año actual
            Select Case CmbMes.Text
                Case "Enero" : nromes = 1
                Case "Febrero" : nromes = 2
                Case "Marzo" : nromes = 3
                Case "Abril" : nromes = 4
                Case "Mayo" : nromes = 5
                Case "Junio" : nromes = 6
                Case "Julio" : nromes = 7
                Case "Agosto" : nromes = 8
                Case "Septiembre" : nromes = 9
                Case "Octubre" : nromes = 10
                Case "Noviembre" : nromes = 11
                Case "Diciembre" : nromes = 12
            End Select

            nroaño = CmbAño.Text

            If nromes = 10 Or nromes = 11 Or nromes = 12 Then
                mes = nromes.ToString
            Else
                mes = "0" + nromes.ToString
            End If

            fechacompleta1 = "01" + "/" + nromes.ToString + "/" + nroaño.ToString
            fechacompleta2 = ""

            If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
                fechacompleta2 = "31" + "/" + nromes.ToString + "/" + nroaño.ToString

            ElseIf nromes = 2 Or nromes = 4 Or nromes = 6 Or nromes = 7 Or nromes = 9 Or nromes = 11 Then
                If nromes = 2 Then
                    If (nroaño - 1992) Mod 4 = 0 Then
                        fechacompleta2 = "29" + "/" + mes.ToString + "/" + nroaño.ToString
                    Else
                        fechacompleta2 = "28" + "/" + mes.ToString + "/" + nroaño.ToString
                    End If
                Else
                    fechacompleta2 = "30" + "/" + mes.ToString + "/" + nroaño.ToString
                End If
            End If

            FechaFiltro1 = CDate(fechacompleta1)
            FechaFiltro2 = CDate(fechacompleta2)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgwAuditoria_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwAuditoria.SelectionChanged
        If dgwAuditoria.RowCount <> 0 Then
            Me.AUDITORIADETALLETableAdapter.Fill(Me.DsAuditoriaUsuario.AUDITORIADETALLE, Me.dgwAuditoria.CurrentRow.Cells("IDTRANS").Value, Me.dgwAuditoria.CurrentRow.Cells("IDMODULO").Value)
        Else
            Me.AUDITORIADETALLETableAdapter.Fill(Me.DsAuditoriaUsuario.AUDITORIADETALLE, 0, 0)
        End If
    End Sub

    Private Function cbxModulo() As Object
        Throw New NotImplementedException
    End Function

    Private Sub BuscarChoferTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarChoferTextBox.TextChanged
        Try
            AUDITORIADETALLEBindingSource1.Filter = "NOMBRE LIKE '%" & BuscarChoferTextBox.Text & "%' OR DESCRIPCION LIKE '%" & BuscarChoferTextBox.Text & "%'"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        dgvModulo_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub dgvModulo_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModulo.CellContentClick

    End Sub
End Class