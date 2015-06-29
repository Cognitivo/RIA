Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Public Class ABMConfigPosExpress

    Private ser As BDConexión.BDConexion
    Private sql As String
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction
    Private cmd As SqlCommand
    Dim Permiso As Integer
    Dim btnuevo As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion
        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub ABMConfigPosExpress_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Permiso = PermisoAplicado(UsuCodigo, 210)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            DesHabilitar()
            Me.MODULOTableAdapter.Fill(Me.DsConfigPEX.MODULO)
            cambiarlabelsconfig()
        End If
        btnuevo = 0
    End Sub

    Private Sub Habilitar()
        cbxConfig1.Enabled = True
        cbxConfig2.Enabled = True
        cbxConfig3.Enabled = True
        cbxConfig4.Enabled = True
        cbxConfig5.Enabled = True
        cbxConfig6.Enabled = True
        cbxConfig7.Enabled = True
        cbxConfig8.Enabled = True
        cbxConfig9.Enabled = True
        cbxConfig10.Enabled = True
        cbxConfig11.Enabled = True
        cbxConfig12.Enabled = True
        cbxConfig13.Enabled = True

        tbxCustomField.Enabled = True
        tbxMesesAjuste.Enabled = True

        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand
        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        GuardarPictureBox.Cursor = Cursors.Hand

        BuscarTextBox.Enabled = False
        dgwModulo.Enabled = False
    End Sub

    Private Sub cambiarlabelsconfig()

        'De acuerdo al Modulo modificamos los labels de Configuraciones
        tbxCustomField.Visible = False
        tbxMesesAjuste.Visible = False
        lblAjuste.Visible = False
        lblMensajeRestrinccion.Visible = False
        cbxConfig1.Visible = True

        If dgwModulo.CurrentRow.Cells("MODULOID").Value = 2 Then 'Proveedor

            Me.RadLbConfig1.Text = "Ordenar por: "

            Me.RadLbConfig2.Text = "Calcular DV Automatico/Manual: "
            Me.RadLbConfig3.Text = "Configuración 3: "
            Me.RadLbConfig4.Text = "Configuración 4: "
            Me.RadLbConfig5.Text = "Configuración 5: "
            Me.RadLbConfig6.Text = "Configuración 6: "
            Me.RadLbConfig7.Text = "Configuración 7: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 3 Then 'Compras

            Me.RadLbConfig1.Text = "Cuotas: "
            Me.RadLbConfig2.Text = "Panel de Cobro: "
            Me.RadLbConfig3.Text = "Saldo Contado: "
            Me.RadLbConfig4.Text = "Imprimir en: "
            Me.RadLbConfig5.Text = "Mostrar Costo: "
            Me.RadLbConfig6.Text = "Mostrar Costo en Campo Precio: "
            Me.RadLbConfig7.Text = "Guardar sin Número de Factura: "
            Me.RadLbConfig8.Text = "Guardar sin Número Timbrado: "
            Me.RadLbConfig9.Text = "Marchar Opcion: "
            Me.RadLbConfig10.Text = "Mostrar Timbrado del Proveedor: "
            Me.RadLbConfig11.Text = "Alertar Cambio de Costo: "
            Me.RadLbConfig12.Text = "Alertar en Nro Factura menor a 13 dig.: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 7 Then 'Clientes

            Me.RadLbConfig1.Text = "Ordenar por: "
            Me.RadLbConfig2.Text = "Campo Personalizado: "
            Me.RadLbConfig3.Text = "Restricción al Guardar: "
            Me.RadLbConfig4.Text = "Reportes Listas Mostrar: "

            tbxCustomField.Visible = True
            tbxCustomField.BringToFront()

            Me.RadLbConfig5.Text = "Calcular DV Automatico/Manual: "
            Me.RadLbConfig6.Text = "Configuración 6: "
            Me.RadLbConfig7.Text = "Configuración 7: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 8 Then 'Ventas Plus

            Me.RadLbConfig1.Text = "Facturar: "
            Me.RadLbConfig2.Text = "Carga Fecha Factura: "
            Me.RadLbConfig3.Text = "Cuotas: "
            Me.RadLbConfig4.Text = "Datos Cliente: "
            Me.RadLbConfig5.Text = "Comprobante: "
            Me.RadLbConfig6.Text = "Panel de Cobro: "
            Me.RadLbConfig7.Text = "Saldo Contado: "
            Me.RadLbConfig8.Text = "Al Anular Factura: "
            Me.RadLbConfig9.Text = "Imprimir en: "
            Me.RadLbConfig10.Text = "Al Aprobar: "
            Me.RadLbConfig11.Text = "Alertar Cambio de Precio:"
            Me.RadLbConfig12.Text = "IVA de Productos: "
            Me.RadLbConfig13.Text = "Mostrar Nro de Serie: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 10 Then 'Cobros

            Me.RadLbConfig1.Text = "Cargar Fecha Factura: "
            Me.RadLbConfig2.Text = "Generar Recibo: "
            Me.RadLbConfig3.Text = "Mostrar : "
            Me.RadLbConfig4.Text = "Buscar Por : "
            Me.RadLbConfig5.Text = "Mostrar Caja: "
            Me.RadLbConfig6.Text = "Configuración 6: "
            Me.RadLbConfig7.Text = "Configuración 7: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 11 Then 'Devoluciones Ventas

            Me.RadLbConfig1.Text = "Mostrar por Defecto: "
            Me.RadLbConfig2.Text = "Mostrar Fecha: "
            Me.RadLbConfig3.Text = "Descontar del Total "
            Me.RadLbConfig4.Text = "Datos Cliente: "
            Me.RadLbConfig5.Text = "Al Relacionar Factura: "
            Me.RadLbConfig6.Text = "Imprimir en: "
            Me.RadLbConfig7.Text = "Habilitar I.V.A: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 13 Then 'Stock

            Me.RadLbConfig1.Text = "Ajuste Diario Stock Histórico de: "
            tbxMesesAjuste.Visible = True : lblAjuste.Visible = True : cbxConfig1.Visible = False

            Me.RadLbConfig2.Text = "Transf. Seleccionar Deposito: "
            Me.RadLbConfig3.Text = "Transf. Número de Transf.: "
            Me.RadLbConfig4.Text = "Configuración 4: "
            Me.RadLbConfig5.Text = "Configuración 5: "
            Me.RadLbConfig6.Text = "Configuración 6: "
            Me.RadLbConfig7.Text = "Configuración 7: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 29 Then 'Devoluciones Compras

            Me.RadLbConfig1.Text = "Mostrar por Defecto: "
            Me.RadLbConfig2.Text = "Mostrar Fecha: "
            Me.RadLbConfig3.Text = "Descontar del Total "
            Me.RadLbConfig4.Text = "Al Relacionar Factura: "
            Me.RadLbConfig5.Text = "Configuración 5: "
            Me.RadLbConfig6.Text = "Configuración 6: "
            Me.RadLbConfig7.Text = "Configuración 7: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 4 Then 'Pagos

            Me.RadLbConfig1.Text = "Cargar Fecha Factura: "
            Me.RadLbConfig2.Text = "Generar Recibo: "
            Me.RadLbConfig3.Text = "Mostrar : "
            Me.RadLbConfig4.Text = "Buscar Por : "
            Me.RadLbConfig5.Text = "Imprimir Retencion Completa: "
            Me.RadLbConfig6.Text = "Mostrar Caja: "
            Me.RadLbConfig7.Text = "Traer último Nro. Recibo: "
            Me.RadLbConfig8.Text = "Buscar por: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 23 Then '*DASHBOARD

            Me.RadLbConfig1.Text = "Mostar mensaje - Caja Abierta: "
            Me.RadLbConfig2.Text = "Mostrar Clientes - Adherentes: "
            Me.RadLbConfig3.Text = "Configuración 3: "
            Me.RadLbConfig4.Text = "Configuración 4: "
            Me.RadLbConfig5.Text = "Configuración 5: "
            Me.RadLbConfig6.Text = "Configuración 6: "
            Me.RadLbConfig7.Text = "Configuración 7: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 30 Then 'Ventas Simples

            Me.RadLbConfig1.Text = "Integrar Cobro: "
            Me.RadLbConfig2.Text = "Panel de Productos: "
            Me.RadLbConfig3.Text = "AutoCarga del Precio:"
            Me.RadLbConfig4.Text = "Imprimir en: "
            Me.RadLbConfig5.Text = "Panel de Lista de Precios: "
            Me.RadLbConfig6.Text = "Abrir Cambio de Nro. Factura: "
            Me.RadLbConfig7.Text = "Cantidad: "
            Me.RadLbConfig8.Text = "Buscador de Productos Mostrar: "
            Me.RadLbConfig9.Text = "Integrar Contabilidad: "
            Me.RadLbConfig10.Text = "Imprimir ticket Comanda: "
            Me.RadLbConfig11.Text = "Descripcion Total del Producto: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 12 Then 'PRODUCTOS

            Me.RadLbConfig1.Text = "Mostrar en Panel de Costos: "
            Me.RadLbConfig2.Text = "Ver Variante: "
            Me.RadLbConfig3.Text = "Configuración 3: "
            Me.RadLbConfig4.Text = "Configuración 4: "
            Me.RadLbConfig5.Text = "Configuración 5: "
            Me.RadLbConfig6.Text = "Configuración 6: "
            Me.RadLbConfig7.Text = "Configuración 7: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "

        Else
            tbxCustomField.Visible = False
            Me.RadLbConfig1.Text = "Configuración 1: "
            Me.RadLbConfig2.Text = "Configuración 2: "
            Me.RadLbConfig3.Text = "Configuración 3: "
            Me.RadLbConfig4.Text = "Configuración 4: "
            Me.RadLbConfig5.Text = "Configuración 5: "
            Me.RadLbConfig6.Text = "Configuración 6: "
            Me.RadLbConfig7.Text = "Configuración 7: "
            Me.RadLbConfig8.Text = "Configuración 8: "
            Me.RadLbConfig9.Text = "Configuración 9: "
            Me.RadLbConfig10.Text = "Configuración 10: "
            Me.RadLbConfig11.Text = "Configuración 11: "
            Me.RadLbConfig12.Text = "Configuración 12: "
            Me.RadLbConfig13.Text = "Configuración 13: "
        End If

    End Sub

    Private Sub DesHabilitar()
        cbxConfig1.Enabled = False
        cbxConfig2.Enabled = False
        cbxConfig3.Enabled = False
        cbxConfig4.Enabled = False
        cbxConfig5.Enabled = False
        cbxConfig6.Enabled = False
        cbxConfig7.Enabled = False
        cbxConfig8.Enabled = False
        cbxConfig9.Enabled = False
        cbxConfig10.Enabled = False
        cbxConfig11.Enabled = False
        cbxConfig12.Enabled = False
        cbxConfig13.Enabled = False
        tbxCustomField.Enabled = False
        tbxMesesAjuste.Enabled = False

        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        BuscarTextBox.Enabled = True
        dgwModulo.Enabled = True
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        Permiso = PermisoAplicado(UsuCodigo, 211)
        If Permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            Habilitar()
            cbxConfig1.Focus()

            'Limpiamos
            cbxConfig1.Items.Clear()
            cbxConfig2.Items.Clear()
            cbxConfig3.Items.Clear()
            cbxConfig4.Items.Clear()
            cbxConfig5.Items.Clear()
            cbxConfig6.Items.Clear()
            cbxConfig7.Items.Clear()
            cbxConfig8.Items.Clear()
            cbxConfig9.Items.Clear()
            cbxConfig10.Items.Clear()
            cbxConfig11.Items.Clear()
            cbxConfig12.Items.Clear()
            cbxConfig13.Items.Clear()

            cambiarlabelsconfig()
            'De acuerdo al Modulo Cargamos los ComboBox para las Configuraciones

            If dgwModulo.CurrentRow.Cells("MODULOID").Value = 2 Then 'Proveedor
                cbxConfig1.Items.Add("Nombre de Proveedor")
                cbxConfig1.Items.Add("Nro. de Proveedor")

                cbxConfig2.Items.Add("Automatico")
                cbxConfig2.Items.Add("Manual")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 3 Then 'Compras

                cbxConfig1.Items.Add("Simplificar Cuotas")
                cbxConfig1.Items.Add("Generar Cuotas")

                cbxConfig2.Items.Add("Mostrar automaticamente")
                cbxConfig2.Items.Add("No mostrar automáticamente")

                cbxConfig3.Items.Add("No Generar Saldo")
                cbxConfig3.Items.Add("Generar Saldo igual al Importe")

                cbxConfig4.Items.Add("Papel Continuo")
                cbxConfig4.Items.Add("Papel Normal")

                cbxConfig5.Items.Add("Costo FIFO")
                cbxConfig5.Items.Add("Precio Última Compra")

                cbxConfig6.Items.Add("Si")
                cbxConfig6.Items.Add("No")

                cbxConfig7.Items.Add("Si")
                cbxConfig7.Items.Add("No")

                cbxConfig8.Items.Add("Si")
                cbxConfig8.Items.Add("No")

                cbxConfig9.Items.Add("Ver Facturas")
                cbxConfig9.Items.Add("Ver Ordenes de Compra")
                cbxConfig9.Items.Add("Ver Todo")

                cbxConfig10.Items.Add("Si")
                cbxConfig10.Items.Add("No")

                cbxConfig11.Items.Add("Si")
                cbxConfig11.Items.Add("No")

                cbxConfig12.Items.Add("Si")
                cbxConfig12.Items.Add("No")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 7 Then 'Clientes

                cbxConfig1.Items.Add("Nombre de Cliente")
                cbxConfig1.Items.Add("Nro. de Cliente")

                cbxConfig3.Items.Add("Bajo")
                cbxConfig3.Items.Add("Medio")
                cbxConfig3.Items.Add("Alto")

                cbxConfig4.Items.Add("Nombre del Cliente")
                cbxConfig4.Items.Add("Nombre de Fantasía del Cliente")

                cbxConfig5.Items.Add("Automatico")
                cbxConfig5.Items.Add("Manual")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 23 Then 'DASHBOARD

                cbxConfig1.Items.Add("Si")
                cbxConfig1.Items.Add("No")

                cbxConfig2.Items.Add("Si")
                cbxConfig2.Items.Add("No")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 8 Then 'Ventas Plus

                cbxConfig1.Items.Add("Con todas las Sucursales")
                cbxConfig1.Items.Add("Sucursal seleccionado segun DashBoard")

                cbxConfig2.Items.Add("Mostrar Fecha Actual")
                cbxConfig2.Items.Add("Mostrar Fecha Adelantada 1 Día")
                cbxConfig2.Items.Add("Mostrar Fecha Atrazada 1 Día")
                cbxConfig2.Items.Add("Mostrar Fecha de Ultima Seleccion")
                cbxConfig2.Items.Add("Mostrar Fecha de Ultima Seleccion por Usuario")

                cbxConfig3.Items.Add("Simplificar Cuotas")
                cbxConfig3.Items.Add("Generar Cuotas")

                cbxConfig4.Items.Add("Mostrar Localizacion del Cliente")
                cbxConfig4.Items.Add("Mostrar Dirección del Cliente")

                cbxConfig5.Items.Add("Mostrar Ultimo Seleccionado")
                cbxConfig5.Items.Add("Mostrar el Primero de la Lista")

                cbxConfig6.Items.Add("Mostrar automaticamente")
                cbxConfig6.Items.Add("No mostrar automáticamente")

                cbxConfig7.Items.Add("No Generar Saldo")
                cbxConfig7.Items.Add("Generar Saldo igual al Importe")

                cbxConfig8.Items.Add("Habilitar Eliminar Cobro")
                cbxConfig8.Items.Add("No Habilitar Eliminar Cobro")

                cbxConfig9.Items.Add("Papel Continuo")
                cbxConfig9.Items.Add("Papel Normal")

                cbxConfig10.Items.Add("Mostrar Panel de Productos Sin Stock")
                cbxConfig10.Items.Add("NO Mostrar Panel de Productos Sin Stock")

                cbxConfig11.Items.Add("Si")
                cbxConfig11.Items.Add("No")

                cbxConfig12.Items.Add("Habilitar")
                cbxConfig12.Items.Add("DesHabilitar")

                cbxConfig13.Items.Add("Si")
                cbxConfig13.Items.Add("No")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 13 Then 'Stock

                cbxConfig2.Items.Add("Con todos los Depositos")
                cbxConfig2.Items.Add("Deposito Destino seleccionado segun DashBoard")

                cbxConfig3.Items.Add("Numeracion por Suc. Destino")
                cbxConfig3.Items.Add("Numeracion Global")


            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 30 Then 'Ventas Simples

                cbxConfig1.Items.Add("Si")
                cbxConfig1.Items.Add("No")

                cbxConfig2.Items.Add("Mostrar Siempre")
                cbxConfig2.Items.Add("Mostrar solo con *")

                cbxConfig3.Items.Add("Si")
                cbxConfig3.Items.Add("No")

                cbxConfig4.Items.Add("Papel Continuo")
                cbxConfig4.Items.Add("Papel Normal")

                cbxConfig5.Items.Add("Mostrar Siempre")
                cbxConfig5.Items.Add("Mostrar solo con *")

                cbxConfig6.Items.Add("Si")
                cbxConfig6.Items.Add("No")

                cbxConfig7.Items.Add("Con Decimales")
                cbxConfig7.Items.Add("Sin Decimales")

                cbxConfig8.Items.Add("Precio Unitario")
                cbxConfig8.Items.Add("Precio por Cantidad")

                cbxConfig9.Items.Add("Si")
                cbxConfig9.Items.Add("No")

                cbxConfig10.Items.Add("Si")
                cbxConfig10.Items.Add("No")

                cbxConfig11.Items.Add("Si")
                cbxConfig11.Items.Add("No")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 10 Then 'Cobros

                cbxConfig1.Items.Add("Mostrar Fecha Actual")
                cbxConfig1.Items.Add("Mostrar Fecha Adelantada 1 Día")
                cbxConfig1.Items.Add("Mostrar Fecha Atrazada 1 Día")
                cbxConfig1.Items.Add("Mostrar Fecha de Ultima Seleccion")
                cbxConfig1.Items.Add("Mostrar Fecha de Ultima Seleccion por Usuario")

                cbxConfig2.Items.Add("Automático")
                cbxConfig2.Items.Add("Manual sin Importar usuario")
                cbxConfig2.Items.Add("Manual por Usuario")

                cbxConfig3.Items.Add("Panel de Cobro")
                cbxConfig3.Items.Add("Panel Facturas Pendientes")

                cbxConfig4.Items.Add("N° de Cliente")
                cbxConfig4.Items.Add("N° de Factura")

                cbxConfig5.Items.Add("Seleccionada segun DashBoard")
                cbxConfig5.Items.Add("Mostrar el Primero de la Lista")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 11 Then 'Devolucion de Ventas

                cbxConfig1.Items.Add("Sumar al Stock")
                cbxConfig1.Items.Add("NO Sumar al Stock")

                cbxConfig2.Items.Add("Actual")
                cbxConfig2.Items.Add("Adelantada 1 Día")
                cbxConfig2.Items.Add("Atrazada 1 Día")
                cbxConfig2.Items.Add("Ultima Seleccion")

                cbxConfig3.Items.Add("Automaticamente")
                cbxConfig3.Items.Add("Manualmente")

                cbxConfig4.Items.Add("Mostrar Localizacion del Cliente")
                cbxConfig4.Items.Add("Mostrar Dirección del Cliente")

                cbxConfig5.Items.Add("Permitir Cargar otros Items como Detalle")
                cbxConfig5.Items.Add("Permitir Cargar Sólo Productos de la Fact.")

                cbxConfig6.Items.Add("Papel Continuo")
                cbxConfig6.Items.Add("Papel Normal")

                cbxConfig7.Items.Add("No")
                cbxConfig7.Items.Add("Si")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 29 Then 'Devolucion de Compras

                cbxConfig1.Items.Add("Descontar del Stock")
                cbxConfig1.Items.Add("NO Descontar del Stock")

                cbxConfig2.Items.Add("Actual")
                cbxConfig2.Items.Add("Adelantada 1 Día")
                cbxConfig2.Items.Add("Atrazada 1 Día")
                cbxConfig2.Items.Add("Ultima Seleccion")

                cbxConfig3.Items.Add("Automaticamente")
                cbxConfig3.Items.Add("Manualmente")

                cbxConfig4.Items.Add("Permitir Cargar otros Items como Detalle")
                cbxConfig4.Items.Add("Permitir Cargar Sólo Productos de la Fact.")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 4 Then 'Pagos

                cbxConfig1.Items.Add("Mostrar Fecha Actual")
                cbxConfig1.Items.Add("Mostrar Fecha Adelantada 1 Día")
                cbxConfig1.Items.Add("Mostrar Fecha Atrazada 1 Día")
                cbxConfig1.Items.Add("Mostrar Fecha de Ultima Seleccion")
                cbxConfig1.Items.Add("Mostrar Fecha de Ultima Seleccion por Usuario")

                cbxConfig2.Items.Add("Automático")
                cbxConfig2.Items.Add("Manual sin Importar usuario")
                cbxConfig2.Items.Add("Manual por Usuario")

                cbxConfig3.Items.Add("Panel de Pagos")
                cbxConfig3.Items.Add("Panel Facturas Pendientes")

                cbxConfig4.Items.Add("N° de Proveedor")
                cbxConfig4.Items.Add("N° de Factura")

                cbxConfig5.Items.Add("Si")
                cbxConfig5.Items.Add("No")

                cbxConfig6.Items.Add("Seleccionada segun DashBoard")
                cbxConfig6.Items.Add("Mostrar el Primero de la Lista")

                cbxConfig7.Items.Add("Si")
                cbxConfig7.Items.Add("No")

                cbxConfig8.Items.Add("RUC")
                cbxConfig8.Items.Add("Número de Proveedor")

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 12 Then 'PRODUCTOS

                cbxConfig1.Items.Add("Costo Último Movimiento (Sin Iva)")
                cbxConfig1.Items.Add("Precio Última Compra (Con Iva)")

                cbxConfig2.Items.Add("No")
                cbxConfig2.Items.Add("Si")

            End If
        End If
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        lblMensajeRestrinccion.Visible = False
        DesHabilitar()
        MODULOBindingSource.CancelEdit()
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        lblMensajeRestrinccion.Visible = False

        'Verificamos
        btnuevo = 1
        If cbxConfig1.Items.Count > 0 Then
            If cbxConfig1.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig1.Focus()
                cbxConfig1.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig2.Items.Count > 0 Then
            If cbxConfig2.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig2.Focus()
                cbxConfig2.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig3.Items.Count > 0 Then
            If cbxConfig3.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig3.Focus()
                cbxConfig3.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig4.Items.Count > 0 Then
            If cbxConfig4.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig4.Focus()
                cbxConfig4.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig5.Items.Count > 0 Then
            If cbxConfig5.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig5.Focus()
                cbxConfig5.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig6.Items.Count > 0 Then
            If cbxConfig6.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig6.Focus()
                cbxConfig6.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig7.Items.Count > 0 Then
            If cbxConfig7.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig7.Focus()
                cbxConfig7.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig8.Items.Count > 0 Then
            If cbxConfig8.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig8.Focus()
                cbxConfig8.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig9.Items.Count > 0 Then
            If cbxConfig9.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig9.Focus()
                cbxConfig9.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        If cbxConfig10.Items.Count > 0 Then
            If cbxConfig10.Text = "" Then
                MessageBox.Show("Elija una Configuración", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxConfig10.Focus()
                cbxConfig10.BackColor = Color.Pink
                Exit Sub
            End If
        End If

        'Guardamos
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            sql = ""
            If dgwModulo.CurrentRow.Cells("MODULOID").Value = 7 Then 'Porque tiene un TextBox en lugar del ComboBox
                sql = "UPDATE MODULO SET CONFIG1 = '" & cbxConfig1.Text & "' ,CONFIG2  = '" & Me.tbxCustomField.Text & "' ,CONFIG3 = '" & cbxConfig3.Text & "' ,CONFIG4 = '" & cbxConfig4.Text & "',  " & _
                 "CONFIG5 = '" & cbxConfig5.Text & "', CONFIG6 = '" & cbxConfig6.Text & "', CONFIG7 = '" & cbxConfig7.Text & "' , CONFIG8 = '" & cbxConfig8.Text & "' , CONFIG9 = '" & cbxConfig9.Text & "'  " & _
                 ", CONFIG10 = '" & cbxConfig10.Text & "', CONFIG11 = '" & cbxConfig11.Text & "', CONFIG12 = '" & cbxConfig12.Text & "', CONFIG13 = '" & cbxConfig13.Text & "'  " & _
                 "WHERE  MODULO_ID = " & dgwModulo.CurrentRow.Cells("MODULOID").Value

            ElseIf dgwModulo.CurrentRow.Cells("MODULOID").Value = 13 Then 'Porque tiene un TextBox en lugar del ComboBox
                sql = "UPDATE MODULO SET CONFIG1 = '" & tbxMesesAjuste.Text & "' ,CONFIG2  = '" & cbxConfig2.Text & "' ,CONFIG3 = '" & cbxConfig3.Text & "' ,CONFIG4 = '" & cbxConfig4.Text & "',  " & _
                 "CONFIG5 = '" & cbxConfig5.Text & "', CONFIG6 = '" & cbxConfig6.Text & "', CONFIG7 = '" & cbxConfig7.Text & "' , CONFIG8 = '" & cbxConfig8.Text & "' , CONFIG9 = '" & cbxConfig9.Text & "' " & _
                 ", CONFIG10 = '" & cbxConfig10.Text & "', CONFIG11 = '" & cbxConfig11.Text & "', CONFIG12 = '" & cbxConfig12.Text & "', CONFIG13 = '" & cbxConfig13.Text & "'  " & _
                 "WHERE  MODULO_ID = " & dgwModulo.CurrentRow.Cells("MODULOID").Value
            Else
                sql = "UPDATE MODULO SET CONFIG1 = '" & cbxConfig1.Text & "' ,CONFIG2  = '" & cbxConfig2.Text & "' ,CONFIG3 = '" & cbxConfig3.Text & "' ,CONFIG4 = '" & cbxConfig4.Text & "',  " & _
                  "CONFIG5 = '" & cbxConfig5.Text & "' ,CONFIG6  = '" & cbxConfig6.Text & "', CONFIG7 = '" & cbxConfig7.Text & "' , CONFIG8 = '" & cbxConfig8.Text & "' , CONFIG9 = '" & cbxConfig9.Text & "'  " & _
                  ", CONFIG10  = '" & cbxConfig10.Text & "', CONFIG11  = '" & cbxConfig11.Text & "' , CONFIG12 = '" & cbxConfig12.Text & "', CONFIG13 = '" & cbxConfig13.Text & "'  " & _
                  "WHERE  MODULO_ID = " & dgwModulo.CurrentRow.Cells("MODULOID").Value
            End If

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar actualizar el registro" + ex.Message, "POSEXPRESS")
        End Try

        Dim J As Integer
        J = MODULOBindingSource.Position
        Me.MODULOTableAdapter.Fill(Me.DsConfigPEX.MODULO)
        MODULOBindingSource.Position = J

        DesHabilitar()
        btnuevo = 0
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        MODULOBindingSource.Filter = "MODULO LIKE '%" & BuscarTextBox.Text & "%'"
    End Sub

    Private Sub dgwModulo_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwModulo.SelectionChanged
        If btnuevo = 0 Then
            cambiarlabelsconfig()
        End If
    End Sub

    Public Sub abrirdesde(ByVal nombreform As String)
        If btnuevo = 0 Then
            If nombreform = "Ventas" Then
                BuscarTextBox.Text = "Ventas Plus"
            ElseIf nombreform = "Compras" Then
                BuscarTextBox.Text = "Compras"
            ElseIf nombreform = "Devolución" Then
                BuscarTextBox.Text = "Devoluciones Ventas"
            ElseIf nombreform = "Cobros" Then
                BuscarTextBox.Text = "Cobros"
            ElseIf nombreform = "Pagos" Then
                BuscarTextBox.Text = "Pagos"
            ElseIf nombreform = "Clientes" Then
                BuscarTextBox.Text = "Clientes"
            End If
        End If
    End Sub

    Private Sub cbxConfig3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxConfig3.SelectedIndexChanged
        'Solo si es el modulo de clientes mostramos el mensaje de la restriccion
        Try
            If dgwModulo.CurrentRow.Cells("MODULOID").Value = 7 Then 'Clientes
                lblMensajeRestrinccion.Visible = True

                If cbxConfig3.Text = "Bajo" Then
                    lblMensajeRestrinccion.Text = "Solo exige el Nombre del Cliente"
                ElseIf cbxConfig3.Text = "Medio" Then
                    lblMensajeRestrinccion.Text = "Exige el Nombre del Cliente y RUC"
                ElseIf cbxConfig3.Text = "Alto" Then
                    lblMensajeRestrinccion.Text = "Exige el Nombre, RUC, Direccion y Telefono"
                End If
            Else
                lblMensajeRestrinccion.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgwModulo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwModulo.CellContentClick

    End Sub
End Class