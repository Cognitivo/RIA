Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Imports Microsoft.VisualBasic

Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class SETSettingsGeneral

    #Region "Fields"

    Dim sentFuncion As New Funciones.Funciones

    #End Region 'Fields

    #Region "Methods"

    Private Sub ABMSmtpPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABMSmtpPictureBox.Click
        ABMSmtp.Show()
    End Sub

    Private Sub ABMSmtpPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ABMSmtpPictureBox.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub ABMSmtpPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ABMSmtpPictureBox.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub EventosPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventosPictureBox.Click
            'Barra()
            Eventos.Show()
    End Sub

    Private Sub EventosPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles EventosPictureBox.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub EventosPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles EventosPictureBox.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub ExcelPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelPictureBox.Click
        ExportarImportarExcel.Show()
    End Sub

    Private Sub ExcelPictureBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExcelPictureBox.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub ExcelPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExcelPictureBox.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub MetasPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetasPictureBox.Click
        Metas.Show()
        ' MetasV2.Show()
    End Sub

    Private Sub MetasPictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetasPictureBox.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PboxConfiguracionGral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxContrato.Click
        'ABMContrato.Show()
        ABMConfigPosExpress.Show()
    End Sub

    Private Sub pbxBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxBancos.Click
        ABMBanco.Show()
    End Sub

    Private Sub pbxBancos_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxBancos.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxBancos_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxBancos.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCaja.Click
            'Barra()
            ABMCaja.Show()
    End Sub


    Private Sub pbxCentroCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCentroCostos.Click
        CentroDeCosto.Show()
    End Sub

    Private Sub pbxCentroCostos_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCentroCostos.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxCentroCostos_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCentroCostos.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PbxClasificacionProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PbxClasificacionProducto.Click
        ABMCategorias.Show()
    End Sub

    Private Sub pbxCotizacionMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxCotizacionMoneda.Click
        ABMMonedas.Show()
    End Sub

    Private Sub pbxCotizacionMoneda_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCotizacionMoneda.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxCotizacionMoneda_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxCotizacionMoneda.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxEmpresa.Click
        ABMEmpresa.Show()
    End Sub

    Private Sub pbxEmpresa_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxEmpresa.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxEmpresa_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxEmpresa.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    'RED
    '*******************************************************************
    'ALTA, BAJA Y MODIFICACION (LISTADO)
    '*******************************************************************
    Private Sub pbxPaisCiudad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxPaisCiudad.Click
        'ABMPais.Show()
        ABMPaisV2.Show()
    End Sub

    'ALTA, BAJA Y MODIFICACION (LISTADO)
    '*******************************************************************
    Private Sub pbxPaisCiudad_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxPaisCiudad.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxPaisCiudad_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxPaisCiudad.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxSucursales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxSucursales.Click
        Sucursales.Show()
    End Sub

    Private Sub pbxSucursales_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxSucursales.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxSucursales_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxSucursales.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub pbxTipoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxTipoCliente.Click 
            ' Barra()
            ABMTipoCliente.Show()
    End Sub

    Private Sub pbxTipoCliente_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxTipoCliente.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxTipoCliente_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxTipoCliente.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub


    Private Sub pbxUnidadMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxUnidadMedida.Click
        ABMUnidadMedida.Show()
    End Sub

    Private Sub pbxUnidadMedida_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxUnidadMedida.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub pbxUnidadMedida_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbxUnidadMedida.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBoxEncargado_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxTarjeta.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBoxEncargado_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxTarjeta.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBoxRango_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxRango.Click
        ABMRangoComprobante.Show()
        ' RangoComprobantes1.Show()
    End Sub

    Private Sub PictureBoxRango_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxRango.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBoxRango_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxRango.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBoxStockIniProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxStockIniProductos.Click
        StockInicial.Show()
    End Sub

    Private Sub PictureBoxTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxTarjeta.Click
            ABMTarjetaCredito.Show()
    End Sub

    Private Sub PictureBoxVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxVendedor.Click
        ABMVendedorV2.Show()
    End Sub

    Private Sub PictureBoxVendedor_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxVendedor.MouseHover
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

#End Region 'Methods

    Private Sub SETSettingsGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NumSistemas = 5
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        ABMTipoComprobante.Show()
    End Sub

    Private Sub PictureBoxCategoriasCliente_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxCategoriasCliente.Click
        ABMCategoriaCliente.Show()
    End Sub

    Private Sub PictureBoxCategoriaProveedor_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxCategoriaProveedor.Click
        ABMCategoriaProveedor.Show()
    End Sub

    Private Sub pbxCalculoFIFO_Click(sender As System.Object, e As System.EventArgs)
        ABMCalculoFifo.Show()
    End Sub

    Private Sub pbxSQLSync_Click(sender As System.Object, e As System.EventArgs) Handles pbxSQLSync.Click
        ABMSqlSync.Show()
    End Sub
End Class