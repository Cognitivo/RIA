Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.IO
Imports BarControls
Imports Osuna.Utiles.Configuracion
Imports Osuna.Utiles.Conectividad
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports EnviaInformes
Imports Telerik.WinControls.Data


Public Class CodigodeBarra

    Private cmd As SqlCommand
    Dim sql As String
    Private sqlc As SqlConnection
    Dim dr As SqlDataReader
    Private ser As BDConexión.BDConexion
    Private myTrans As SqlTransaction
    Dim permiso As Double
    Dim f As New Funciones.Funciones
    Dim Active As Integer
    Dim RucEmpresa As String

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

#Region "Methods"

    Public Function EAN13(ByVal value As String) As String
        Dim tableAB(,) As Integer = New Integer(,) {{0, 0, 0, 0, 0, 0}, {0, 0, 1, 0, 1, 1}, _
                                                    {0, 0, 1, 1, 0, 1}, {0, 0, 1, 1, 1, 0}, _
                                                    {0, 1, 0, 0, 1, 1}, {0, 1, 1, 0, 0, 1}, _
                                                    {0, 1, 1, 1, 0, 0}, {0, 1, 0, 1, 0, 1}, _
                                                    {0, 1, 0, 1, 1, 0}, {0, 1, 1, 0, 1, 0}}
        Dim result As String = value.Substring(0, 1)
        Dim first As Integer = Convert.ToInt32(result)
        Dim check As Integer = first
        Dim digit As Integer = 0
        Dim i As Integer = 1
        Dim r As Integer
        Do While (i <= 6)
            digit = Convert.ToInt32(value.Substring(i, 1))
            If i Mod 2 = 0 Then
                r = 1
            Else
                r = 3
            End If
            check = (check + (digit * (r)))

            result = (result + CType(ChrW((65 + (digit + (tableAB(first, (i - 1)) * 10)))), Char))
            i = (i + 1)
        Loop

        result = (result + "*")

        i = 7
        Do While (i < 12)
            digit = Convert.ToInt32(value.Substring(i, 1))
            If i Mod 2 = 0 Then
                r = 1
            Else
                r = 3
            End If
            check = (check + (digit * (r)))
            result = (result + CType(ChrW((97 + digit)), Char))
            i = (i + 1)
        Loop

        digit = ((10 - (check Mod 10)) Mod 10)
        result = (result + CType(ChrW((97 + digit)), Char))
        result = (result + "+")
        Return result

    End Function

    Private Sub BuscaProductoTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscaProductoTextBox.GotFocus
        BuscaProductoTextBox.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub BuscaProductoTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BuscaProductoTextBox.LostFocus
        BuscaProductoTextBox.BackColor = Color.Gainsboro
    End Sub

    Private Sub BuscaProductoTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscaProductoTextBox.TextChanged

        Dim Filtro As New FilterExpression()
        If Active = 1 Then
            Me.CodigodeBarraTableAdapter.Fill(DsProductos.CodigodeBarra, "%" + BuscaProductoTextBox.Text + "%", "%" + BuscaProductoTextBox.Text + "%", "%" + BuscaProductoTextBox.Text + "%")
        Else
            Dim Codtipocliprioridad As Integer
            Codtipocliprioridad = f.FuncionConsulta("CODTIPOCLIENTE", "TIPOCLIENTE", "PRIORIDAD", 1)
            Me.CodigoPesableBindingSource.Filter = "(CODIGO LIKE '%" & BuscaProductoTextBox.Text & "%' OR DESPRODUCTO LIKE '%" & BuscaProductoTextBox.Text & "%') AND (CODTIPOCLIENTE = " & Codtipocliprioridad & ")"
        End If

    End Sub

    Private Sub CodigodeBarra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CodigodeBarraTableAdapter.Fill(DsProductos.CodigodeBarra, "%", "%", "%")
        Me.CodigoPesableTableAdapter.Fill(DsProductos.CodigoPesable, "%", "%", "%")
        pnlCodigo.BringToFront()
        Active = 1
        rbtPrecio.Checked = True
        rpt13x5.Checked = True
        RucEmpresa = f.FuncionConsultaString2("RUCCONTRIBUYENTE", "EMPRESA", "CODEMPRESA", EmpCodigo)
    End Sub

    Private Sub Imprimir13x5()
        Dim informe = New Reportes.InfCodigodeBarra3
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim x, cant As Integer
        Dim tamanho As Integer
        Dim codigo, prod As String

        Dim dtCodigodeBarra As New DataTable
        dtCodigodeBarra.Columns.Add("NombreProducto")
        dtCodigodeBarra.Columns.Add("Precio")
        dtCodigodeBarra.Columns.Add("Codigo")

        For i = 0 To dgwCodigos.Rows.Count - 1
            Dim CodigoFormateado As String
            Dim IsChecked As Integer = dgwCodigos.Rows(i).Cells("Marcar").Value
            'Verificamos si esta marcado...
            If (IsChecked = -1) Or (IsChecked = 1) Then

                prod = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                codigo = dgwCodigos.Rows(i).Cells("CODIGO").Value
                tamanho = codigo.Length

                If (tamanho < 12) Then

                Else
                    If dgwCodigos.Rows(i).Cells("Cantidad").Value = 0 Then
                        cant = 1
                    Else
                        cant = dgwCodigos.Rows(i).Cells("Cantidad").Value
                    End If

                    For x = 0 To cant - 1
                        Dim dr As DataRow = dtCodigodeBarra.NewRow
                        dr("NombreProducto") = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                        dr("Precio") = dgwCodigos.Rows(i).Cells("PRECIOVENTA").Value
                        CodigoFormateado = dgwCodigos.Rows(i).Cells("CODIGO").Value
                        CodigoFormateado = EAN13(CodigoFormateado)
                        dr("Codigo") = CodigoFormateado
                        dtCodigodeBarra.Rows.Add(dr)
                        dtCodigodeBarra.AcceptChanges()
                    Next
                End If
            End If
        Next
        informe.SetDataSource(informes.InfCodigoBarraMultiple(dtCodigodeBarra))
        frm.CrystalReportViewer1.ReportSource = informe
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
    Private Sub Imprimir13x5Empresa()
        Dim informe = New Reportes.InfCodigodeBarra5
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim x, cant As Integer
        Dim tamanho As Integer
        Dim codigo, prod As String

        Dim dtCodigodeBarra As New DataTable
        dtCodigodeBarra.Columns.Add("NombreProducto")
        dtCodigodeBarra.Columns.Add("Empresa")
        dtCodigodeBarra.Columns.Add("Ruc")
        dtCodigodeBarra.Columns.Add("Codigo")

        For i = 0 To dgwCodigos.Rows.Count - 1
            Dim CodigoFormateado As String
            Dim IsChecked As Integer = dgwCodigos.Rows(i).Cells("Marcar").Value
            'Verificamos si esta marcado...
            If (IsChecked = -1) Or (IsChecked = 1) Then

                prod = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                codigo = dgwCodigos.Rows(i).Cells("CODIGO").Value
                tamanho = codigo.Length

                If (tamanho < 12) Then

                Else
                    If dgwCodigos.Rows(i).Cells("Cantidad").Value = 0 Then
                        cant = 1
                    Else
                        cant = dgwCodigos.Rows(i).Cells("Cantidad").Value
                    End If

                    For x = 0 To cant - 1
                        Dim dr As DataRow = dtCodigodeBarra.NewRow
                        dr("NombreProducto") = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                        dr("Empresa") = EmpNomFantasia
                        CodigoFormateado = dgwCodigos.Rows(i).Cells("CODIGO").Value
                        CodigoFormateado = EAN13(CodigoFormateado)
                        dr("Ruc") = " RUC " + RucEmpresa
                        dr("Codigo") = CodigoFormateado
                        dtCodigodeBarra.Rows.Add(dr)
                        dtCodigodeBarra.AcceptChanges()
                    Next
                End If
            End If
        Next
        informe.SetDataSource(informes.InfCodigoBarraMultiple2(dtCodigodeBarra))
        frm.CrystalReportViewer1.ReportSource = informe
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
    Private Sub ImprimirCodigo()
        Dim informe = New Reportes.InfCodigodeBarra1
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim x, cant As Integer
        Dim tamanho As Integer
        Dim codigo, prod As String

        Dim dtCodigodeBarra As New DataTable
        dtCodigodeBarra.Columns.Add("NombreProducto")
        dtCodigodeBarra.Columns.Add("Precio")
        dtCodigodeBarra.Columns.Add("Codigo")

        For i = 0 To dgwCodigos.Rows.Count - 1
            Dim CodigoFormateado As String
            Dim IsChecked As Integer = dgwCodigos.Rows(i).Cells("Marcar").Value
            'Verificamos si esta marcado...
            If (IsChecked = -1) Or (IsChecked = 1) Then

                prod = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                codigo = dgwCodigos.Rows(i).Cells("CODIGO").Value
                tamanho = codigo.Length

                If (tamanho < 12) Then

                Else
                    If dgwCodigos.Rows(i).Cells("Cantidad").Value = 0 Then
                        cant = 1
                    Else
                        cant = dgwCodigos.Rows(i).Cells("Cantidad").Value
                    End If
                    Try


                        For x = 0 To cant - 1
                            Dim dr As DataRow = dtCodigodeBarra.NewRow
                            dr("NombreProducto") = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                            dr("Precio") = dgwCodigos.Rows(i).Cells("PRECIOVENTA").Value
                            CodigoFormateado = dgwCodigos.Rows(i).Cells("CODIGO").Value
                            'MessageBox.Show(NumericCode.Text.PadRight(12, "0"))
                            CodigoFormateado = EAN13(CodigoFormateado)
                            dr("Codigo") = CodigoFormateado
                            dtCodigodeBarra.Rows.Add(dr)
                            dtCodigodeBarra.AcceptChanges()
                        Next
                    Catch ex As Exception

                    End Try
                End If
            End If
        Next
        informe.SetDataSource(informes.InfCodigoBarraMultiple(dtCodigodeBarra))
        frm.CrystalReportViewer1.ReportSource = informe
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
       
    End Sub

    Private Sub CodigoPersonalizado()
        Dim informe = New Reportes.InfCodigodeBarra1
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim x, cant As Integer
        Dim tamanho As Integer
        Dim codigo, prod As String

        Dim dtCodigodeBarra As New DataTable
        dtCodigodeBarra.Columns.Add("NombreProducto")
        dtCodigodeBarra.Columns.Add("Precio")
        dtCodigodeBarra.Columns.Add("Codigo")

        For i = 0 To dgwCodigos.Rows.Count - 1
            Dim CodigoFormateado As String
            Dim IsChecked As Integer = dgwCodigos.Rows(i).Cells("Marcar").Value
            'Verificamos si esta marcado...
            If (IsChecked = -1) Or (IsChecked = 1) Then

                prod = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                codigo = dgwCodigos.Rows(i).Cells("CODIGO").Value
                tamanho = codigo.Length

                If (tamanho < 12) Then

                Else
                    If dgwCodigos.Rows(i).Cells("Cantidad").Value = 0 Then
                        cant = 1
                    Else
                        cant = dgwCodigos.Rows(i).Cells("Cantidad").Value
                    End If
                    Try


                        For x = 0 To cant - 1
                            Dim dr As DataRow = dtCodigodeBarra.NewRow
                            dr("NombreProducto") = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                            dr("Precio") = dgwCodigos.Rows(i).Cells("PRECIOVENTA").Value
                            CodigoFormateado = dgwCodigos.Rows(i).Cells("CODIGO").Value
                            'MessageBox.Show(NumericCode.Text.PadRight(12, "0"))
                            CodigoFormateado = EAN13(CodigoFormateado)
                            dr("Codigo") = CodigoFormateado
                            dtCodigodeBarra.Rows.Add(dr)
                            dtCodigodeBarra.AcceptChanges()
                        Next
                    Catch ex As Exception

                    End Try
                End If
            End If
        Next
        informe.SetDataSource(informes.InfCodigoBarraMultiple(dtCodigodeBarra))
        frm.CrystalReportViewer1.ReportSource = informe
        frm.WindowState = FormWindowState.Maximized
        frm.Show()

    End Sub
    Private Sub Imprimir7x3()
        Dim informe = New Reportes.InfCodigodeBarra4
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim x, cant As Integer
        Dim tamanho As Integer
        Dim codigo, prod As String

        Dim dtCodigodeBarra As New DataTable
        dtCodigodeBarra.Columns.Add("NombreProducto")
        dtCodigodeBarra.Columns.Add("Precio")
        dtCodigodeBarra.Columns.Add("Codigo")

        For i = 0 To dgwCodigos.Rows.Count - 1
            Dim CodigoFormateado As String
            Dim IsChecked As Integer = dgwCodigos.Rows(i).Cells("Marcar").Value
            'Verificamos si esta marcado...
            If (IsChecked = -1) Or (IsChecked = 1) Then

                prod = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                codigo = dgwCodigos.Rows(i).Cells("CODIGO").Value
                tamanho = codigo.Length

                If (tamanho < 12) Then

                Else
                    If dgwCodigos.Rows(i).Cells("Cantidad").Value = 0 Then
                        cant = 1
                    Else
                        cant = dgwCodigos.Rows(i).Cells("Cantidad").Value
                    End If

                    For x = 0 To cant - 1
                        Dim dr As DataRow = dtCodigodeBarra.NewRow
                        dr("NombreProducto") = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                        dr("Precio") = dgwCodigos.Rows(i).Cells("PRECIOVENTA").Value
                        CodigoFormateado = dgwCodigos.Rows(i).Cells("CODIGO").Value
                        'MessageBox.Show(NumericCode.Text.PadRight(12, "0"))
                        CodigoFormateado = EAN13(CodigoFormateado)
                        dr("Codigo") = CodigoFormateado
                        dtCodigodeBarra.Rows.Add(dr)
                        dtCodigodeBarra.AcceptChanges()
                    Next
                End If
            End If
        Next
        informe.SetDataSource(informes.InfCodigoBarraMultiple(dtCodigodeBarra))
        frm.CrystalReportViewer1.ReportSource = informe
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub Imprimir7x3Empresa()
        Dim informe = New Reportes.InfCodigodeBarra6
        Dim frm = New VerInformes
        Dim informes As New EnviaInformes.EnviaInformes
        Dim x, cant As Integer
        Dim tamanho As Integer
        Dim codigo, prod As String

        Dim dtCodigodeBarra As New DataTable
        dtCodigodeBarra.Columns.Add("NombreProducto")
        dtCodigodeBarra.Columns.Add("Empresa")
        dtCodigodeBarra.Columns.Add("Ruc")
        dtCodigodeBarra.Columns.Add("Codigo")

        For i = 0 To dgwCodigos.Rows.Count - 1
            Dim CodigoFormateado As String
            Dim IsChecked As Integer = dgwCodigos.Rows(i).Cells("Marcar").Value
            'Verificamos si esta marcado...
            If (IsChecked = -1) Or (IsChecked = 1) Then

                prod = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                codigo = dgwCodigos.Rows(i).Cells("CODIGO").Value
                tamanho = codigo.Length

                If (tamanho < 12) Then

                Else
                    If dgwCodigos.Rows(i).Cells("Cantidad").Value = 0 Then
                        cant = 1
                    Else
                        cant = dgwCodigos.Rows(i).Cells("Cantidad").Value
                    End If

                    For x = 0 To cant - 1
                        Dim dr As DataRow = dtCodigodeBarra.NewRow
                        dr("NombreProducto") = dgwCodigos.Rows(i).Cells("PRODUCTO").Value
                        CodigoFormateado = dgwCodigos.Rows(i).Cells("CODIGO").Value
                        'MessageBox.Show(NumericCode.Text.PadRight(12, "0"))
                        CodigoFormateado = EAN13(CodigoFormateado)
                        dr("Empresa") = EmpNomFantasia
                        dr("Ruc") = " RUC " + RucEmpresa
                        dr("Codigo") = CodigoFormateado
                        dtCodigodeBarra.Rows.Add(dr)
                        dtCodigodeBarra.AcceptChanges()
                    Next
                End If
            End If
        Next
        informe.SetDataSource(informes.InfCodigoBarraMultiple2(dtCodigodeBarra))
        frm.CrystalReportViewer1.ReportSource = informe
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
    Private Sub RadButtonImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButtonImprimir.Click

        If rbtPrecio.Checked = True Then
            'Verificamos que formato de reporte selecciono
            If (rpt7x3.Checked = True) Then
                Me.Cursor = Cursors.AppStarting
                Imprimir7x3()
            ElseIf (rpt13x5.Checked = True) Then
                Me.Cursor = Cursors.AppStarting
                Imprimir13x5()
            ElseIf (rdbCodigo.Checked = True) Then
                Me.Cursor = Cursors.AppStarting
                ImprimirCodigo()
            ElseIf (rptPers.Checked = True) Then
                Me.Cursor = Cursors.AppStarting
                CodigoPersonalizado()
            Else
                MessageBox.Show("Seleccione un Formato de Impresion para el Codigo de Barra", "POSEXPRESS")
            End If
        Else 'Empresa
            'Verificamos que formato de reporte selecciono
            If (rpt7x3.Checked = True) Then
                Me.Cursor = Cursors.AppStarting
                Imprimir7x3Empresa()
            ElseIf (rpt13x5.Checked = True) Then
                Me.Cursor = Cursors.AppStarting
                Imprimir13x5Empresa()
                'ElseIf (rdbCodigo.Checked = True) Then
                '    Me.Cursor = Cursors.AppStarting
                '    ImprimirCodigo()
            Else
                MessageBox.Show("Seleccione un Formato de Impresion para el Codigo de Barra", "POSEXPRESS")
            End If
        End If
        
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region 'Methods

    Private Sub ChckTodoCodigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckTodoCodigo.CheckedChanged
        Dim c As Integer = dgwCodigos.RowCount

        If c = 0 Then
            Exit Sub
        Else
            If ChckTodoCodigo.Checked = True Then
                For i = 0 To c - 1
                    dgwCodigos.Rows(i).Cells("Marcar").Value = 1
                Next

            Else
                For i = 0 To c - 1
                    dgwCodigos.Rows(i).Cells("Marcar").Value = 0
                Next
            End If
        End If
    End Sub

    Private Sub BtnExportaraBalanza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportaraBalanza.Click

        'Sacamos el sevidor de archivos para esa empresa
        Dim CodProducto, Codigo, Producto, Pesable, Vencimiento, Text, Precio, NumFamilia, NumLinea As String
        Dim Cantidadespacio As Integer

        Dim Destino As String = f.FuncionConsultaString("CARPETACOMPARTIDA", "EMPRESA", "CODEMPRESA", EmpCodigo)
        If Destino = Nothing Then
            MessageBox.Show("Todavía no se estableció una carpeta compartida para alojar los archivos de la Empresa", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Destino = Path.Combine(Destino, "PRONETCOGENT.imp")

        If (File.Exists(Destino)) Then
            If MessageBox.Show("El archivo ya existe desea reemplazar y actualizarlo?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                File.Delete(Destino)
            End If
        End If
        Me.Cursor = Cursors.AppStarting
        Try
            Dim c As Integer
            Dim sw As New System.IO.StreamWriter(Destino, True)

            c = dgwBalanzas.Rows.Count
            For i = 1 To c

                If (dgwBalanzas.Rows(i - 1).Cells("MarcarBalanza").Value = 1) Or (dgwBalanzas.Rows(i - 1).Cells("MarcarBalanza").Value = -1) Then
                    '#######################################CodProducto ########################################
                    CodProducto = dgwBalanzas.Rows(i - 1).Cells("CODPRODUCTO").Value.ToString
                    If CodProducto.Length = 1 Then
                        CodProducto = "0000" + CodProducto
                    ElseIf CodProducto.Length = 2 Then
                        CodProducto = "000" + CodProducto
                    ElseIf CodProducto.Length = 3 Then
                        CodProducto = "00" + CodProducto
                    ElseIf CodProducto.Length = 4 Then
                        CodProducto = "0" + CodProducto
                    End If
                    '###########################################################################################

                    Codigo = dgwBalanzas.Rows(i - 1).Cells("CODIGODataGridView").Value.ToString
                    Producto = dgwBalanzas.Rows(i - 1).Cells("PRODUCTODataGridView").Value.ToString

                    If Codigo.Length > 5 Then
                        '#######################################Codigo ########################################
                        Codigo = Codigo.Remove(0, 2)
                        If Codigo.Length = 5 Then
                        Else
                            Codigo = Codigo.Remove(5, Codigo.Length - 5)
                        End If

                        '#######################################################################################


                        '#######################################Descripción de Producto#########################
                        If Producto.Length > 21 Then
                            Producto = Producto.Remove(21, Producto.Length - 21)
                            Cantidadespacio = 193
                        ElseIf Producto.Length < 21 Then
                            Cantidadespacio = 193 + (21 - Producto.Length)
                        ElseIf Producto.Length = 21 Then
                            Cantidadespacio = 193
                        End If
                        Producto = String.Concat(Producto, Space(Cantidadespacio))
                        '########################################################################################


                        '####################################### Pesable ########################################
                        If IsDBNull(dgwBalanzas.Rows(i - 1).Cells("PESABLE").Value) Then
                            Pesable = "NP"
                        Else
                            Pesable = dgwBalanzas.Rows(i - 1).Cells("PESABLE").Value
                            If Pesable = "1" Then
                                Pesable = "PE"
                            ElseIf Pesable = "0" Then
                                Pesable = "NP"
                            End If
                        End If
                        '#########################################################################################


                        '####################################### Vencimiento #####################################
                        If IsDBNull(dgwBalanzas.Rows(i - 1).Cells("VENCIMIENTO").Value) Then
                            Vencimiento = "N"
                        Else
                            Vencimiento = dgwBalanzas.Rows(i - 1).Cells("VENCIMIENTO").Value
                            If Vencimiento = "1" Then
                                Vencimiento = "S"
                            ElseIf Vencimiento = "0" Then
                                Vencimiento = "N"
                            End If
                        End If
                        '##########################################################################################

                        '####################################### Precio ###########################################
                        Dim indice As Integer
                        Precio = dgwBalanzas.Rows(i - 1).Cells("PRECIOVENTADataGridView").Value.ToString
                        indice = Precio.IndexOf(",")
                        Precio = Precio.Remove(indice, 3)

                        If Precio.Length = 1 Then
                            Precio = "00000" + Precio
                        ElseIf Precio.Length = 2 Then
                            Precio = "0000" + Precio
                        ElseIf Precio.Length = 3 Then
                            Precio = "000" + Precio
                        ElseIf Precio.Length = 4 Then
                            Precio = "00" + Precio
                        ElseIf Precio.Length = 5 Then
                            Precio = "0" + Precio
                        Else

                        End If
                        '##########################################################################################

                        '####################################### Familia ##########################################
                        NumFamilia = dgwBalanzas.Rows(i - 1).Cells("NUMFAMILIA").Value
                        NumFamilia = Trim(NumFamilia)
                        If NumFamilia.Length = 1 Then
                            NumFamilia = "0" + NumFamilia
                        End If
                        '##########################################################################################

                        '####################################### Linea ############################################
                        NumLinea = dgwBalanzas.Rows(i - 1).Cells("NUMLINEA").Value
                        NumLinea = Trim(NumLinea)
                        If NumLinea.Length = 1 Then
                            NumLinea = "0" + NumLinea
                        End If
                        '##########################################################################################

                        Text = Codigo + " " + "3" + " " + Producto + " " _
                        + Codigo + " " + Pesable + " " + Precio + " " _
                        + "00000" + " " + "00000" + " " + Vencimiento + " " + "000" + " " _
                        + NumFamilia + " " + NumLinea

                        '  MessageBox.Show(Text, "POSEXPRESS")
                        sw.WriteLine(Text)

                        Text = ""
                    End If
                End If
            Next

            sw.Flush()
            sw.Close()
            MessageBox.Show("Proceso ejecutado correctamente", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("No existe el Directorio: '" & Destino & "'", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        Me.Cursor = Cursors.Arrow
        'FileClose(1) ' lo cierra
    End Sub


    Private Sub chbxMarcarTodoBalanza_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxMarcarTodoBalanza.CheckedChanged

        Dim c As Integer = dgwBalanzas.RowCount
        If c = 0 Then
            Exit Sub
        Else
            If chbxMarcarTodoBalanza.Checked = True Then
                For i = 0 To c - 1
                    dgwBalanzas.Rows(i).Cells("MarcarBalanza").Value = 1
                Next

            Else
                For i = 0 To c - 1
                    dgwBalanzas.Rows(i).Cells("MarcarBalanza").Value = 0
                Next
            End If
        End If
    End Sub


    Private Sub pbxBalanza_Click(sender As System.Object, e As System.EventArgs) Handles pbxBalanza.Click
        Active = 2
        Dim Codtipocliprioridad As Integer

        pnlBalanza.BringToFront()

        Codtipocliprioridad = f.FuncionConsulta("CODTIPOCLIENTE", "TIPOCLIENTE", "PRIORIDAD", 1)
        If Codtipocliprioridad = 0 Then
            MessageBox.Show("Debe establecer el tipo de cliente prioritario para continuar con el proceso", "POSEXPRESS")
            Exit Sub
        End If
        Me.CodigoPesableBindingSource.Filter = "CODTIPOCLIENTE = " & Codtipocliprioridad
        pbxBalanza.Image = My.Resources.WeightActive
        pbxBalanza.Cursor = Cursors.Hand
        pbxCodigo.Image = My.Resources.Barcode
        pbxCodigo.Cursor = Cursors.Hand
    End Sub

    Private Sub pbxCodigo_Click(sender As System.Object, e As System.EventArgs) Handles pbxCodigo.Click
        Active = 1
        pnlCodigo.BringToFront()
        pbxCodigo.Image = My.Resources.BarcodeActive
        pbxCodigo.Cursor = Cursors.Arrow
        pbxBalanza.Image = My.Resources.Weight
        pbxBalanza.Cursor = Cursors.Hand
    End Sub
End Class