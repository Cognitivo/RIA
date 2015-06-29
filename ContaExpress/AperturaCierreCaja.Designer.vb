<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AperturaCierreCaja
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AperturaCierreCaja))
        Me.lblDescripCaja = New System.Windows.Forms.Label()
        Me.LblCajero = New System.Windows.Forms.Label()
        Me.LblSucursal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelApertura = New System.Windows.Forms.Panel()
        Me.PanelCierreCaja = New System.Windows.Forms.Panel()
        Me.cbxTipoCobroCierre = New System.Windows.Forms.ComboBox()
        Me.TIPOFORMACOBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCaja1 = New ContaExpress.DsCaja1()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtImporteCierre = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Txtid_apertura = New Telerik.WinControls.UI.RadTextBox()
        Me.AperturasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxMonedaCierre = New System.Windows.Forms.ComboBox()
        Me.MONEDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtnEliminarCierre = New Telerik.WinControls.UI.RadButton()
        Me.GridViewCierre1 = New System.Windows.Forms.DataGridView()
        Me.MonedaCierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoCierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMonedaCierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDineroCierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodTipoDinero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnAgregarCierre = New Telerik.WinControls.UI.RadButton()
        Me.TxtId_Cierre = New System.Windows.Forms.TextBox()
        Me.CierresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewCierreDetalle = New System.Windows.Forms.DataGridView()
        Me.IdcierredetDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdmonedaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdtipodineroDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMONEDADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdaperturaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESFORCOBRODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.BtnConfirmarCierre = New Telerik.WinControls.UI.RadButton()
        Me.cbxMonedaApertura = New System.Windows.Forms.ComboBox()
        Me.GridViewCierre = New System.Windows.Forms.DataGridView()
        Me.IdaperturaDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechapaerturaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdcajaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AperturanumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdempresaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdusuarioDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GridViewApertura1 = New System.Windows.Forms.DataGridView()
        Me.Moneda1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPOFORMACOBRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridViewAperturaDet = New System.Windows.Forms.DataGridView()
        Me.IdaperturadetDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdaperturaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdtipodineroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdmonedaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESFORCOBRODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AperturasdetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtnConfirmaApertura = New Telerik.WinControls.UI.RadButton()
        Me.CmbAnhoApertura = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem13 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem14 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem15 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem16 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem17 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem18 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem19 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem20 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem21 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem22 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem23 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem24 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem25 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem26 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem27 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem28 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem29 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem30 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem31 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem32 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem33 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.CmbMesApertura = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem1 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem2 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem3 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem4 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem5 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem6 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem7 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem8 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem9 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem10 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem11 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem12 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.BtnFiltroApertura = New Telerik.WinControls.UI.RadButton()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.BtnEliminarApertura = New Telerik.WinControls.UI.RadButton()
        Me.BtnAgregarApertura = New Telerik.WinControls.UI.RadButton()
        Me.TxtMontoApertura = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.TxtBuscarApertura = New System.Windows.Forms.TextBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.cbxTipoCobroApertura = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CierresdetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TIPOFORMACOBROCIERREBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MONEDACIERREBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadTextBox4 = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNroApertura = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.FechaHoy = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.IngresoPictureBox = New System.Windows.Forms.PictureBox()
        Me.AperturaPictureBox = New System.Windows.Forms.PictureBox()
        Me.CierrePictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarGrisPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarGrisPictureBox = New System.Windows.Forms.PictureBox()
        Me.LblCaja = New System.Windows.Forms.Label()
        Me.PanelIngresoEgreso = New System.Windows.Forms.Panel()
        Me.cbxTipo = New System.Windows.Forms.ComboBox()
        Me.cbxMonedaAjuste = New System.Windows.Forms.ComboBox()
        Me.TxtImporteIngreso = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.tbxConcepto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblId_AperturaActual = New System.Windows.Forms.Label()
        Me.CmbEntradaSalida = New Telerik.WinControls.UI.RadComboBox()
        Me.Entrada = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.Salida = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridViewIngresos = New System.Windows.Forms.DataGridView()
        Me.IdmovimientoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdaperturaDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdusuarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdempresaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechamtoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConceptoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntradasalidaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdmonedaDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdtipodineroDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMONEDADataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESFORCOBRODataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cotizacion1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cotizacion2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdcobroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdventaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdpagoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdcompraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VueltoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodsucursalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MtosingresoegresodetalleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtnEliminarIngreso = New Telerik.WinControls.UI.RadButton()
        Me.BtnAgregarIngreso = New Telerik.WinControls.UI.RadButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.FKmovimientosaperturas1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FKcierresdetcierresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AperturasTableAdapter = New ContaExpress.DsCaja1TableAdapters.aperturasTableAdapter()
        Me.Aperturas_detTableAdapter = New ContaExpress.DsCaja1TableAdapters.aperturas_detTableAdapter()
        Me.MONEDATableAdapter = New ContaExpress.DsCaja1TableAdapters.MONEDATableAdapter()
        Me.TIPOFORMACOBROTableAdapter = New ContaExpress.DsCaja1TableAdapters.TIPOFORMACOBROTableAdapter()
        Me.CierresTableAdapter = New ContaExpress.DsCaja1TableAdapters.cierresTableAdapter()
        Me.Cierres_detTableAdapter = New ContaExpress.DsCaja1TableAdapters.cierres_detTableAdapter()
        Me.MtosingresoegresodetalleTableAdapter = New ContaExpress.DsCaja1TableAdapters.mtosingresoegresodetalleTableAdapter()
        Me.MovimientosTableAdapter = New ContaExpress.DsCaja1TableAdapters.movimientosTableAdapter()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCuentasEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbarEstadoVentas = New System.Windows.Forms.ToolStripProgressBar()
        Me.PanelApertura.SuspendLayout()
        Me.PanelCierreCaja.SuspendLayout()
        CType(Me.TIPOFORMACOBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCaja1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtid_apertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AperturasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEliminarCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCierre1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAgregarCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CierresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCierreDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnConfirmarCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewApertura1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAperturaDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AperturasdetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnConfirmaApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbAnhoApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbMesApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFiltroApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEliminarApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAgregarApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CierresdetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOFORMACOBROCIERREBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MONEDACIERREBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadTextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.IngresoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AperturaPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CierrePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarGrisPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarGrisPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelIngresoEgreso.SuspendLayout()
        CType(Me.CmbEntradaSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MtosingresoegresodetalleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEliminarIngreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAgregarIngreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKmovimientosaperturas1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKcierresdetcierresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDescripCaja
        '
        Me.lblDescripCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripCaja.ForeColor = System.Drawing.Color.Black
        Me.lblDescripCaja.Location = New System.Drawing.Point(252, 22)
        Me.lblDescripCaja.Name = "lblDescripCaja"
        Me.lblDescripCaja.Size = New System.Drawing.Size(167, 16)
        Me.lblDescripCaja.TabIndex = 89
        Me.lblDescripCaja.Text = "CajaDescrip"
        Me.lblDescripCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCajero
        '
        Me.LblCajero.BackColor = System.Drawing.Color.Transparent
        Me.LblCajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCajero.ForeColor = System.Drawing.Color.Black
        Me.LblCajero.Location = New System.Drawing.Point(52, 1)
        Me.LblCajero.Name = "LblCajero"
        Me.LblCajero.Size = New System.Drawing.Size(131, 18)
        Me.LblCajero.TabIndex = 90
        Me.LblCajero.Text = "Cajero"
        Me.LblCajero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSucursal
        '
        Me.LblSucursal.BackColor = System.Drawing.Color.Transparent
        Me.LblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSucursal.ForeColor = System.Drawing.Color.Black
        Me.LblSucursal.Location = New System.Drawing.Point(252, 1)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(167, 20)
        Me.LblSucursal.TabIndex = 88
        Me.LblSucursal.Text = "Sucursal"
        Me.LblSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(186, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Cuenta Des.:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(-4, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Usuario:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(202, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Sucursal:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelApertura
        '
        Me.PanelApertura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelApertura.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelApertura.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.PanelApertura.Controls.Add(Me.PanelCierreCaja)
        Me.PanelApertura.Controls.Add(Me.cbxMonedaApertura)
        Me.PanelApertura.Controls.Add(Me.GridViewCierre)
        Me.PanelApertura.Controls.Add(Me.Label17)
        Me.PanelApertura.Controls.Add(Me.GridViewApertura1)
        Me.PanelApertura.Controls.Add(Me.GridViewAperturaDet)
        Me.PanelApertura.Controls.Add(Me.BtnConfirmaApertura)
        Me.PanelApertura.Controls.Add(Me.CmbAnhoApertura)
        Me.PanelApertura.Controls.Add(Me.CmbMesApertura)
        Me.PanelApertura.Controls.Add(Me.BtnFiltroApertura)
        Me.PanelApertura.Controls.Add(Me.Label30)
        Me.PanelApertura.Controls.Add(Me.Label31)
        Me.PanelApertura.Controls.Add(Me.BtnEliminarApertura)
        Me.PanelApertura.Controls.Add(Me.BtnAgregarApertura)
        Me.PanelApertura.Controls.Add(Me.TxtMontoApertura)
        Me.PanelApertura.Controls.Add(Me.TxtBuscarApertura)
        Me.PanelApertura.Controls.Add(Me.PictureBox8)
        Me.PanelApertura.Controls.Add(Me.cbxTipoCobroApertura)
        Me.PanelApertura.Controls.Add(Me.Label21)
        Me.PanelApertura.Controls.Add(Me.Label22)
        Me.PanelApertura.Controls.Add(Me.Label24)
        Me.PanelApertura.Location = New System.Drawing.Point(2, 40)
        Me.PanelApertura.Name = "PanelApertura"
        Me.PanelApertura.Size = New System.Drawing.Size(839, 514)
        Me.PanelApertura.TabIndex = 0
        Me.PanelApertura.Visible = False
        '
        'PanelCierreCaja
        '
        Me.PanelCierreCaja.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelCierreCaja.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelCierreCaja.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelCierreCaja.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.PanelCierreCaja.Controls.Add(Me.cbxTipoCobroCierre)
        Me.PanelCierreCaja.Controls.Add(Me.Label23)
        Me.PanelCierreCaja.Controls.Add(Me.TxtImporteCierre)
        Me.PanelCierreCaja.Controls.Add(Me.Txtid_apertura)
        Me.PanelCierreCaja.Controls.Add(Me.cbxMonedaCierre)
        Me.PanelCierreCaja.Controls.Add(Me.BtnEliminarCierre)
        Me.PanelCierreCaja.Controls.Add(Me.GridViewCierre1)
        Me.PanelCierreCaja.Controls.Add(Me.BtnAgregarCierre)
        Me.PanelCierreCaja.Controls.Add(Me.TxtId_Cierre)
        Me.PanelCierreCaja.Controls.Add(Me.GridViewCierreDetalle)
        Me.PanelCierreCaja.Controls.Add(Me.Label27)
        Me.PanelCierreCaja.Controls.Add(Me.Label25)
        Me.PanelCierreCaja.Controls.Add(Me.Label28)
        Me.PanelCierreCaja.Controls.Add(Me.BtnConfirmarCierre)
        Me.PanelCierreCaja.Location = New System.Drawing.Point(277, 0)
        Me.PanelCierreCaja.Name = "PanelCierreCaja"
        Me.PanelCierreCaja.Size = New System.Drawing.Size(561, 514)
        Me.PanelCierreCaja.TabIndex = 1
        Me.PanelCierreCaja.Visible = False
        '
        'cbxTipoCobroCierre
        '
        Me.cbxTipoCobroCierre.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxTipoCobroCierre.DataSource = Me.TIPOFORMACOBROBindingSource
        Me.cbxTipoCobroCierre.DisplayMember = "DESFORCOBRO"
        Me.cbxTipoCobroCierre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoCobroCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoCobroCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTipoCobroCierre.FormattingEnabled = True
        Me.cbxTipoCobroCierre.Location = New System.Drawing.Point(297, 59)
        Me.cbxTipoCobroCierre.Name = "cbxTipoCobroCierre"
        Me.cbxTipoCobroCierre.Size = New System.Drawing.Size(142, 26)
        Me.cbxTipoCobroCierre.TabIndex = 256
        Me.cbxTipoCobroCierre.ValueMember = "CODFORCOBRO"
        '
        'TIPOFORMACOBROBindingSource
        '
        Me.TIPOFORMACOBROBindingSource.DataMember = "TIPOFORMACOBRO"
        Me.TIPOFORMACOBROBindingSource.DataSource = Me.DsCaja1
        '
        'DsCaja1
        '
        Me.DsCaja1.DataSetName = "DsCaja1"
        Me.DsCaja1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Light", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label23.Location = New System.Drawing.Point(4, 4)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(241, 33)
        Me.Label23.TabIndex = 230
        Me.Label23.Text = "Cierre de Cuenta"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtImporteCierre
        '
        Me.TxtImporteCierre.AllowDrop = True
        Appearance1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance1.FontData.SizeInPoints = 13.0!
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.TxtImporteCierre.Appearance = Appearance1
        Me.TxtImporteCierre.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.TxtImporteCierre.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.TxtImporteCierre.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.TxtImporteCierre.Location = New System.Drawing.Point(154, 59)
        Me.TxtImporteCierre.Name = "TxtImporteCierre"
        Me.TxtImporteCierre.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtImporteCierre.Size = New System.Drawing.Size(136, 27)
        Me.TxtImporteCierre.TabIndex = 2
        '
        'Txtid_apertura
        '
        Me.Txtid_apertura.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AperturasBindingSource, "id_apertura", True))
        Me.Txtid_apertura.Location = New System.Drawing.Point(191, 15)
        Me.Txtid_apertura.Name = "Txtid_apertura"
        Me.Txtid_apertura.ReadOnly = True
        Me.Txtid_apertura.Size = New System.Drawing.Size(41, 20)
        Me.Txtid_apertura.TabIndex = 247
        Me.Txtid_apertura.TabStop = False
        Me.Txtid_apertura.ThemeName = "Breeze"
        '
        'AperturasBindingSource
        '
        Me.AperturasBindingSource.DataMember = "aperturas"
        Me.AperturasBindingSource.DataSource = Me.DsCaja1
        '
        'cbxMonedaCierre
        '
        Me.cbxMonedaCierre.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxMonedaCierre.DataSource = Me.MONEDABindingSource
        Me.cbxMonedaCierre.DisplayMember = "DESMONEDA"
        Me.cbxMonedaCierre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMonedaCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMonedaCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMonedaCierre.FormattingEnabled = True
        Me.cbxMonedaCierre.Location = New System.Drawing.Point(10, 59)
        Me.cbxMonedaCierre.Name = "cbxMonedaCierre"
        Me.cbxMonedaCierre.Size = New System.Drawing.Size(142, 26)
        Me.cbxMonedaCierre.TabIndex = 255
        Me.cbxMonedaCierre.ValueMember = "CODMONEDA"
        '
        'MONEDABindingSource
        '
        Me.MONEDABindingSource.DataMember = "MONEDA"
        Me.MONEDABindingSource.DataSource = Me.DsCaja1
        '
        'BtnEliminarCierre
        '
        Me.BtnEliminarCierre.Location = New System.Drawing.Point(499, 59)
        Me.BtnEliminarCierre.Name = "BtnEliminarCierre"
        Me.BtnEliminarCierre.Size = New System.Drawing.Size(54, 27)
        Me.BtnEliminarCierre.TabIndex = 5
        Me.BtnEliminarCierre.Text = "&Eliminar"
        '
        'GridViewCierre1
        '
        Me.GridViewCierre1.AllowUserToAddRows = False
        Me.GridViewCierre1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridViewCierre1.BackgroundColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewCierre1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridViewCierre1.ColumnHeadersHeight = 35
        Me.GridViewCierre1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MonedaCierre, Me.MontoCierre, Me.CodMonedaCierre, Me.TipoDineroCierre, Me.CodTipoDinero, Me.FechaCierre})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewCierre1.DefaultCellStyle = DataGridViewCellStyle3
        Me.GridViewCierre1.GridColor = System.Drawing.Color.Gainsboro
        Me.GridViewCierre1.Location = New System.Drawing.Point(3, 92)
        Me.GridViewCierre1.Name = "GridViewCierre1"
        Me.GridViewCierre1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewCierre1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GridViewCierre1.RowHeadersVisible = False
        Me.GridViewCierre1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewCierre1.Size = New System.Drawing.Size(556, 422)
        Me.GridViewCierre1.TabIndex = 246
        '
        'MonedaCierre
        '
        Me.MonedaCierre.HeaderText = "Moneda"
        Me.MonedaCierre.Name = "MonedaCierre"
        Me.MonedaCierre.ReadOnly = True
        '
        'MontoCierre
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N1"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.MontoCierre.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontoCierre.HeaderText = "Monto"
        Me.MontoCierre.Name = "MontoCierre"
        Me.MontoCierre.ReadOnly = True
        '
        'CodMonedaCierre
        '
        Me.CodMonedaCierre.HeaderText = "CODMONEDA"
        Me.CodMonedaCierre.Name = "CodMonedaCierre"
        Me.CodMonedaCierre.ReadOnly = True
        Me.CodMonedaCierre.Visible = False
        '
        'TipoDineroCierre
        '
        Me.TipoDineroCierre.HeaderText = "Tipo"
        Me.TipoDineroCierre.Name = "TipoDineroCierre"
        Me.TipoDineroCierre.ReadOnly = True
        '
        'CodTipoDinero
        '
        Me.CodTipoDinero.HeaderText = "CODTIPOFORMACOBRO"
        Me.CodTipoDinero.Name = "CodTipoDinero"
        Me.CodTipoDinero.ReadOnly = True
        Me.CodTipoDinero.Visible = False
        '
        'FechaCierre
        '
        Me.FechaCierre.HeaderText = "FECHA"
        Me.FechaCierre.Name = "FechaCierre"
        Me.FechaCierre.ReadOnly = True
        Me.FechaCierre.Visible = False
        '
        'BtnAgregarCierre
        '
        Me.BtnAgregarCierre.Location = New System.Drawing.Point(443, 59)
        Me.BtnAgregarCierre.Name = "BtnAgregarCierre"
        Me.BtnAgregarCierre.Size = New System.Drawing.Size(54, 27)
        Me.BtnAgregarCierre.TabIndex = 4
        Me.BtnAgregarCierre.Text = "&Agregar"
        '
        'TxtId_Cierre
        '
        Me.TxtId_Cierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtId_Cierre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CierresBindingSource, "id_apertura", True))
        Me.TxtId_Cierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtId_Cierre.Location = New System.Drawing.Point(805, 20)
        Me.TxtId_Cierre.Name = "TxtId_Cierre"
        Me.TxtId_Cierre.Size = New System.Drawing.Size(20, 18)
        Me.TxtId_Cierre.TabIndex = 254
        '
        'CierresBindingSource
        '
        Me.CierresBindingSource.DataMember = "cierres"
        Me.CierresBindingSource.DataSource = Me.DsCaja1
        '
        'GridViewCierreDetalle
        '
        Me.GridViewCierreDetalle.AllowUserToAddRows = False
        Me.GridViewCierreDetalle.BackgroundColor = System.Drawing.Color.White
        Me.GridViewCierreDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewCierreDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.GridViewCierreDetalle.ColumnHeadersHeight = 35
        Me.GridViewCierreDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdcierredetDataGridViewTextBoxColumn, Me.IdmonedaDataGridViewTextBoxColumn1, Me.IdtipodineroDataGridViewTextBoxColumn1, Me.DESMONEDADataGridViewTextBoxColumn1, Me.MontoDataGridViewTextBoxColumn1, Me.IdaperturaDataGridViewTextBoxColumn1, Me.DESFORCOBRODataGridViewTextBoxColumn1})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewCierreDetalle.DefaultCellStyle = DataGridViewCellStyle6
        Me.GridViewCierreDetalle.GridColor = System.Drawing.Color.Gainsboro
        Me.GridViewCierreDetalle.Location = New System.Drawing.Point(47, 197)
        Me.GridViewCierreDetalle.Name = "GridViewCierreDetalle"
        Me.GridViewCierreDetalle.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewCierreDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GridViewCierreDetalle.RowHeadersVisible = False
        Me.GridViewCierreDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewCierreDetalle.Size = New System.Drawing.Size(311, 165)
        Me.GridViewCierreDetalle.TabIndex = 252
        Me.GridViewCierreDetalle.Visible = False
        '
        'IdcierredetDataGridViewTextBoxColumn
        '
        Me.IdcierredetDataGridViewTextBoxColumn.HeaderText = "Column1"
        Me.IdcierredetDataGridViewTextBoxColumn.Name = "IdcierredetDataGridViewTextBoxColumn"
        Me.IdcierredetDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdcierredetDataGridViewTextBoxColumn.Visible = False
        '
        'IdmonedaDataGridViewTextBoxColumn1
        '
        Me.IdmonedaDataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.IdmonedaDataGridViewTextBoxColumn1.Name = "IdmonedaDataGridViewTextBoxColumn1"
        Me.IdmonedaDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IdmonedaDataGridViewTextBoxColumn1.Visible = False
        '
        'IdtipodineroDataGridViewTextBoxColumn1
        '
        Me.IdtipodineroDataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.IdtipodineroDataGridViewTextBoxColumn1.Name = "IdtipodineroDataGridViewTextBoxColumn1"
        Me.IdtipodineroDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IdtipodineroDataGridViewTextBoxColumn1.Visible = False
        '
        'DESMONEDADataGridViewTextBoxColumn1
        '
        Me.DESMONEDADataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.DESMONEDADataGridViewTextBoxColumn1.Name = "DESMONEDADataGridViewTextBoxColumn1"
        Me.DESMONEDADataGridViewTextBoxColumn1.ReadOnly = True
        Me.DESMONEDADataGridViewTextBoxColumn1.Visible = False
        '
        'MontoDataGridViewTextBoxColumn1
        '
        Me.MontoDataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.MontoDataGridViewTextBoxColumn1.Name = "MontoDataGridViewTextBoxColumn1"
        Me.MontoDataGridViewTextBoxColumn1.ReadOnly = True
        Me.MontoDataGridViewTextBoxColumn1.Visible = False
        '
        'IdaperturaDataGridViewTextBoxColumn1
        '
        Me.IdaperturaDataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.IdaperturaDataGridViewTextBoxColumn1.Name = "IdaperturaDataGridViewTextBoxColumn1"
        Me.IdaperturaDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IdaperturaDataGridViewTextBoxColumn1.Visible = False
        '
        'DESFORCOBRODataGridViewTextBoxColumn1
        '
        Me.DESFORCOBRODataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.DESFORCOBRODataGridViewTextBoxColumn1.Name = "DESFORCOBRODataGridViewTextBoxColumn1"
        Me.DESFORCOBRODataGridViewTextBoxColumn1.ReadOnly = True
        Me.DESFORCOBRODataGridViewTextBoxColumn1.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(7, 45)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 13)
        Me.Label27.TabIndex = 193
        Me.Label27.Text = "Moneda"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(152, 44)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 13)
        Me.Label25.TabIndex = 194
        Me.Label25.Text = "Importe"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(294, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(28, 13)
        Me.Label28.TabIndex = 188
        Me.Label28.Text = "Tipo"
        '
        'BtnConfirmarCierre
        '
        Me.BtnConfirmarCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirmarCierre.Location = New System.Drawing.Point(382, 12)
        Me.BtnConfirmarCierre.Name = "BtnConfirmarCierre"
        Me.BtnConfirmarCierre.Size = New System.Drawing.Size(168, 32)
        Me.BtnConfirmarCierre.TabIndex = 6
        Me.BtnConfirmarCierre.Text = "CONFIRMAR"
        CType(Me.BtnConfirmarCierre.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "CONFIRMAR"
        CType(Me.BtnConfirmarCierre.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(194, Byte), Integer))
        CType(Me.BtnConfirmarCierre.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(167, Byte), Integer))
        CType(Me.BtnConfirmarCierre.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(167, Byte), Integer))
        CType(Me.BtnConfirmarCierre.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(167, Byte), Integer))
        '
        'cbxMonedaApertura
        '
        Me.cbxMonedaApertura.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxMonedaApertura.DataSource = Me.MONEDABindingSource
        Me.cbxMonedaApertura.DisplayMember = "DESMONEDA"
        Me.cbxMonedaApertura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMonedaApertura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMonedaApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMonedaApertura.FormattingEnabled = True
        Me.cbxMonedaApertura.Location = New System.Drawing.Point(286, 58)
        Me.cbxMonedaApertura.Name = "cbxMonedaApertura"
        Me.cbxMonedaApertura.Size = New System.Drawing.Size(142, 26)
        Me.cbxMonedaApertura.TabIndex = 426
        Me.cbxMonedaApertura.ValueMember = "CODMONEDA"
        '
        'GridViewCierre
        '
        Me.GridViewCierre.AllowUserToAddRows = False
        Me.GridViewCierre.AllowUserToDeleteRows = False
        Me.GridViewCierre.AutoGenerateColumns = False
        Me.GridViewCierre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridViewCierre.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewCierre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GridViewCierre.ColumnHeadersHeight = 35
        Me.GridViewCierre.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdaperturaDataGridViewTextBoxColumn3, Me.FechapaerturaDataGridViewTextBoxColumn, Me.IdcajaDataGridViewTextBoxColumn, Me.DESUSUARIODataGridViewTextBoxColumn, Me.AperturanumDataGridViewTextBoxColumn, Me.IdempresaDataGridViewTextBoxColumn1, Me.IdusuarioDataGridViewTextBoxColumn1})
        Me.GridViewCierre.DataSource = Me.CierresBindingSource
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewCierre.DefaultCellStyle = DataGridViewCellStyle9
        Me.GridViewCierre.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.GridViewCierre.Location = New System.Drawing.Point(-1, 0)
        Me.GridViewCierre.Name = "GridViewCierre"
        Me.GridViewCierre.ReadOnly = True
        Me.GridViewCierre.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewCierre.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.GridViewCierre.RowHeadersVisible = False
        Me.GridViewCierre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewCierre.Size = New System.Drawing.Size(277, 514)
        Me.GridViewCierre.TabIndex = 425
        '
        'IdaperturaDataGridViewTextBoxColumn3
        '
        Me.IdaperturaDataGridViewTextBoxColumn3.DataPropertyName = "id_apertura"
        Me.IdaperturaDataGridViewTextBoxColumn3.HeaderText = "Nº"
        Me.IdaperturaDataGridViewTextBoxColumn3.Name = "IdaperturaDataGridViewTextBoxColumn3"
        Me.IdaperturaDataGridViewTextBoxColumn3.ReadOnly = True
        Me.IdaperturaDataGridViewTextBoxColumn3.Visible = False
        '
        'FechapaerturaDataGridViewTextBoxColumn
        '
        Me.FechapaerturaDataGridViewTextBoxColumn.DataPropertyName = "fechapaertura"
        Me.FechapaerturaDataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FechapaerturaDataGridViewTextBoxColumn.Name = "FechapaerturaDataGridViewTextBoxColumn"
        Me.FechapaerturaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdcajaDataGridViewTextBoxColumn
        '
        Me.IdcajaDataGridViewTextBoxColumn.DataPropertyName = "id_caja"
        Me.IdcajaDataGridViewTextBoxColumn.HeaderText = "Nº Caja"
        Me.IdcajaDataGridViewTextBoxColumn.Name = "IdcajaDataGridViewTextBoxColumn"
        Me.IdcajaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESUSUARIODataGridViewTextBoxColumn
        '
        Me.DESUSUARIODataGridViewTextBoxColumn.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIODataGridViewTextBoxColumn.HeaderText = "Usuario"
        Me.DESUSUARIODataGridViewTextBoxColumn.Name = "DESUSUARIODataGridViewTextBoxColumn"
        Me.DESUSUARIODataGridViewTextBoxColumn.ReadOnly = True
        '
        'AperturanumDataGridViewTextBoxColumn
        '
        Me.AperturanumDataGridViewTextBoxColumn.DataPropertyName = "apertura_num"
        Me.AperturanumDataGridViewTextBoxColumn.HeaderText = "apertura_num"
        Me.AperturanumDataGridViewTextBoxColumn.Name = "AperturanumDataGridViewTextBoxColumn"
        Me.AperturanumDataGridViewTextBoxColumn.ReadOnly = True
        Me.AperturanumDataGridViewTextBoxColumn.Visible = False
        '
        'IdempresaDataGridViewTextBoxColumn1
        '
        Me.IdempresaDataGridViewTextBoxColumn1.DataPropertyName = "id_empresa"
        Me.IdempresaDataGridViewTextBoxColumn1.HeaderText = "id_empresa"
        Me.IdempresaDataGridViewTextBoxColumn1.Name = "IdempresaDataGridViewTextBoxColumn1"
        Me.IdempresaDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IdempresaDataGridViewTextBoxColumn1.Visible = False
        '
        'IdusuarioDataGridViewTextBoxColumn1
        '
        Me.IdusuarioDataGridViewTextBoxColumn1.DataPropertyName = "id_usuario"
        Me.IdusuarioDataGridViewTextBoxColumn1.HeaderText = "id_usuario"
        Me.IdusuarioDataGridViewTextBoxColumn1.Name = "IdusuarioDataGridViewTextBoxColumn1"
        Me.IdusuarioDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IdusuarioDataGridViewTextBoxColumn1.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Light", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label17.Location = New System.Drawing.Point(283, 4)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(240, 36)
        Me.Label17.TabIndex = 230
        Me.Label17.Text = "Apertura de Cuenta"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GridViewApertura1
        '
        Me.GridViewApertura1.AllowUserToAddRows = False
        Me.GridViewApertura1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridViewApertura1.BackgroundColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewApertura1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.GridViewApertura1.ColumnHeadersHeight = 35
        Me.GridViewApertura1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Moneda1, Me.Monto, Me.CODMONEDA1, Me.TIPO, Me.CODTIPOFORMACOBRO, Me.FECHA})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewApertura1.DefaultCellStyle = DataGridViewCellStyle13
        Me.GridViewApertura1.GridColor = System.Drawing.Color.Gainsboro
        Me.GridViewApertura1.Location = New System.Drawing.Point(278, 90)
        Me.GridViewApertura1.Name = "GridViewApertura1"
        Me.GridViewApertura1.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewApertura1.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.GridViewApertura1.RowHeadersVisible = False
        Me.GridViewApertura1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewApertura1.Size = New System.Drawing.Size(559, 424)
        Me.GridViewApertura1.TabIndex = 245
        '
        'Moneda1
        '
        Me.Moneda1.HeaderText = "Moneda"
        Me.Moneda1.Name = "Moneda1"
        Me.Moneda1.ReadOnly = True
        '
        'Monto
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N1"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.Monto.DefaultCellStyle = DataGridViewCellStyle12
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        '
        'CODMONEDA1
        '
        Me.CODMONEDA1.HeaderText = "CODMONEDA"
        Me.CODMONEDA1.Name = "CODMONEDA1"
        Me.CODMONEDA1.ReadOnly = True
        Me.CODMONEDA1.Visible = False
        '
        'TIPO
        '
        Me.TIPO.HeaderText = "Tipo"
        Me.TIPO.Name = "TIPO"
        Me.TIPO.ReadOnly = True
        '
        'CODTIPOFORMACOBRO
        '
        Me.CODTIPOFORMACOBRO.HeaderText = "CODTIPOFORMACOBRO"
        Me.CODTIPOFORMACOBRO.Name = "CODTIPOFORMACOBRO"
        Me.CODTIPOFORMACOBRO.ReadOnly = True
        Me.CODTIPOFORMACOBRO.Visible = False
        '
        'FECHA
        '
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        Me.FECHA.Visible = False
        '
        'GridViewAperturaDet
        '
        Me.GridViewAperturaDet.AllowUserToAddRows = False
        Me.GridViewAperturaDet.AutoGenerateColumns = False
        Me.GridViewAperturaDet.BackgroundColor = System.Drawing.Color.White
        Me.GridViewAperturaDet.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewAperturaDet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.GridViewAperturaDet.ColumnHeadersHeight = 35
        Me.GridViewAperturaDet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdaperturadetDataGridViewTextBoxColumn, Me.IdaperturaDataGridViewTextBoxColumn, Me.IdtipodineroDataGridViewTextBoxColumn, Me.IdmonedaDataGridViewTextBoxColumn, Me.DESMONEDADataGridViewTextBoxColumn, Me.MontoDataGridViewTextBoxColumn, Me.DESFORCOBRODataGridViewTextBoxColumn})
        Me.GridViewAperturaDet.DataSource = Me.AperturasdetBindingSource
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewAperturaDet.DefaultCellStyle = DataGridViewCellStyle16
        Me.GridViewAperturaDet.GridColor = System.Drawing.Color.Gainsboro
        Me.GridViewAperturaDet.Location = New System.Drawing.Point(288, 179)
        Me.GridViewAperturaDet.Name = "GridViewAperturaDet"
        Me.GridViewAperturaDet.ReadOnly = True
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewAperturaDet.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.GridViewAperturaDet.RowHeadersVisible = False
        Me.GridViewAperturaDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewAperturaDet.Size = New System.Drawing.Size(364, 140)
        Me.GridViewAperturaDet.TabIndex = 246
        Me.GridViewAperturaDet.Visible = False
        '
        'IdaperturadetDataGridViewTextBoxColumn
        '
        Me.IdaperturadetDataGridViewTextBoxColumn.DataPropertyName = "id_apertura_det"
        Me.IdaperturadetDataGridViewTextBoxColumn.HeaderText = "id_apertura_det"
        Me.IdaperturadetDataGridViewTextBoxColumn.Name = "IdaperturadetDataGridViewTextBoxColumn"
        Me.IdaperturadetDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdaperturadetDataGridViewTextBoxColumn.Visible = False
        '
        'IdaperturaDataGridViewTextBoxColumn
        '
        Me.IdaperturaDataGridViewTextBoxColumn.DataPropertyName = "id_apertura"
        Me.IdaperturaDataGridViewTextBoxColumn.HeaderText = "id_apertura"
        Me.IdaperturaDataGridViewTextBoxColumn.Name = "IdaperturaDataGridViewTextBoxColumn"
        Me.IdaperturaDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdaperturaDataGridViewTextBoxColumn.Visible = False
        '
        'IdtipodineroDataGridViewTextBoxColumn
        '
        Me.IdtipodineroDataGridViewTextBoxColumn.DataPropertyName = "id_tipo_dinero"
        Me.IdtipodineroDataGridViewTextBoxColumn.HeaderText = "id_tipo_dinero"
        Me.IdtipodineroDataGridViewTextBoxColumn.Name = "IdtipodineroDataGridViewTextBoxColumn"
        Me.IdtipodineroDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdtipodineroDataGridViewTextBoxColumn.Visible = False
        '
        'IdmonedaDataGridViewTextBoxColumn
        '
        Me.IdmonedaDataGridViewTextBoxColumn.DataPropertyName = "id_moneda"
        Me.IdmonedaDataGridViewTextBoxColumn.HeaderText = "id_moneda"
        Me.IdmonedaDataGridViewTextBoxColumn.Name = "IdmonedaDataGridViewTextBoxColumn"
        Me.IdmonedaDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdmonedaDataGridViewTextBoxColumn.Visible = False
        '
        'DESMONEDADataGridViewTextBoxColumn
        '
        Me.DESMONEDADataGridViewTextBoxColumn.DataPropertyName = "DESMONEDA"
        Me.DESMONEDADataGridViewTextBoxColumn.HeaderText = "Moneda"
        Me.DESMONEDADataGridViewTextBoxColumn.Name = "DESMONEDADataGridViewTextBoxColumn"
        Me.DESMONEDADataGridViewTextBoxColumn.ReadOnly = True
        Me.DESMONEDADataGridViewTextBoxColumn.Width = 180
        '
        'MontoDataGridViewTextBoxColumn
        '
        Me.MontoDataGridViewTextBoxColumn.DataPropertyName = "monto"
        Me.MontoDataGridViewTextBoxColumn.HeaderText = "Monto"
        Me.MontoDataGridViewTextBoxColumn.Name = "MontoDataGridViewTextBoxColumn"
        Me.MontoDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontoDataGridViewTextBoxColumn.Width = 150
        '
        'DESFORCOBRODataGridViewTextBoxColumn
        '
        Me.DESFORCOBRODataGridViewTextBoxColumn.DataPropertyName = "DESFORCOBRO"
        Me.DESFORCOBRODataGridViewTextBoxColumn.HeaderText = "Tipo"
        Me.DESFORCOBRODataGridViewTextBoxColumn.Name = "DESFORCOBRODataGridViewTextBoxColumn"
        Me.DESFORCOBRODataGridViewTextBoxColumn.ReadOnly = True
        '
        'AperturasdetBindingSource
        '
        Me.AperturasdetBindingSource.DataMember = "FK_aperturas_det_aperturas"
        Me.AperturasdetBindingSource.DataSource = Me.AperturasBindingSource
        '
        'BtnConfirmaApertura
        '
        Me.BtnConfirmaApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.BtnConfirmaApertura.Location = New System.Drawing.Point(660, 12)
        Me.BtnConfirmaApertura.Name = "BtnConfirmaApertura"
        Me.BtnConfirmaApertura.Size = New System.Drawing.Size(169, 32)
        Me.BtnConfirmaApertura.TabIndex = 6
        Me.BtnConfirmaApertura.Text = "CONFIRMAR"
        CType(Me.BtnConfirmaApertura.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "CONFIRMAR"
        CType(Me.BtnConfirmaApertura.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(194, Byte), Integer))
        CType(Me.BtnConfirmaApertura.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(167, Byte), Integer))
        CType(Me.BtnConfirmaApertura.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(167, Byte), Integer))
        CType(Me.BtnConfirmaApertura.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(167, Byte), Integer))
        '
        'CmbAnhoApertura
        '
        Me.CmbAnhoApertura.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbAnhoApertura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAnhoApertura.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem13, Me.RadComboBoxItem14, Me.RadComboBoxItem15, Me.RadComboBoxItem16, Me.RadComboBoxItem17, Me.RadComboBoxItem18, Me.RadComboBoxItem19, Me.RadComboBoxItem20, Me.RadComboBoxItem21, Me.RadComboBoxItem22, Me.RadComboBoxItem23, Me.RadComboBoxItem24, Me.RadComboBoxItem25, Me.RadComboBoxItem26, Me.RadComboBoxItem27, Me.RadComboBoxItem28, Me.RadComboBoxItem29, Me.RadComboBoxItem30, Me.RadComboBoxItem31, Me.RadComboBoxItem32, Me.RadComboBoxItem33})
        Me.CmbAnhoApertura.Location = New System.Drawing.Point(105, 31)
        Me.CmbAnhoApertura.Name = "CmbAnhoApertura"
        '
        '
        '
        Me.CmbAnhoApertura.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbAnhoApertura.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAnhoApertura.Size = New System.Drawing.Size(53, 20)
        Me.CmbAnhoApertura.TabIndex = 239
        Me.CmbAnhoApertura.TabStop = False
        Me.CmbAnhoApertura.ThemeName = "Breeze"
        Me.CmbAnhoApertura.Visible = False
        '
        'RadComboBoxItem13
        '
        Me.RadComboBoxItem13.Name = "RadComboBoxItem13"
        Me.RadComboBoxItem13.Text = "2000"
        '
        'RadComboBoxItem14
        '
        Me.RadComboBoxItem14.Name = "RadComboBoxItem14"
        Me.RadComboBoxItem14.Text = "2001"
        '
        'RadComboBoxItem15
        '
        Me.RadComboBoxItem15.Name = "RadComboBoxItem15"
        Me.RadComboBoxItem15.Text = "2002"
        '
        'RadComboBoxItem16
        '
        Me.RadComboBoxItem16.Name = "RadComboBoxItem16"
        Me.RadComboBoxItem16.Text = "2003"
        '
        'RadComboBoxItem17
        '
        Me.RadComboBoxItem17.Name = "RadComboBoxItem17"
        Me.RadComboBoxItem17.Text = "2004"
        '
        'RadComboBoxItem18
        '
        Me.RadComboBoxItem18.Name = "RadComboBoxItem18"
        Me.RadComboBoxItem18.Text = "2005"
        '
        'RadComboBoxItem19
        '
        Me.RadComboBoxItem19.Name = "RadComboBoxItem19"
        Me.RadComboBoxItem19.Text = "2006"
        '
        'RadComboBoxItem20
        '
        Me.RadComboBoxItem20.Name = "RadComboBoxItem20"
        Me.RadComboBoxItem20.Text = "2007"
        '
        'RadComboBoxItem21
        '
        Me.RadComboBoxItem21.Name = "RadComboBoxItem21"
        Me.RadComboBoxItem21.Text = "2008"
        '
        'RadComboBoxItem22
        '
        Me.RadComboBoxItem22.Name = "RadComboBoxItem22"
        Me.RadComboBoxItem22.Text = "2009"
        '
        'RadComboBoxItem23
        '
        Me.RadComboBoxItem23.Name = "RadComboBoxItem23"
        Me.RadComboBoxItem23.Text = "2010"
        '
        'RadComboBoxItem24
        '
        Me.RadComboBoxItem24.Name = "RadComboBoxItem24"
        Me.RadComboBoxItem24.Text = "2011"
        '
        'RadComboBoxItem25
        '
        Me.RadComboBoxItem25.Name = "RadComboBoxItem25"
        Me.RadComboBoxItem25.Text = "2012"
        '
        'RadComboBoxItem26
        '
        Me.RadComboBoxItem26.Name = "RadComboBoxItem26"
        Me.RadComboBoxItem26.Text = "2013"
        '
        'RadComboBoxItem27
        '
        Me.RadComboBoxItem27.Name = "RadComboBoxItem27"
        Me.RadComboBoxItem27.Text = "2014"
        '
        'RadComboBoxItem28
        '
        Me.RadComboBoxItem28.Name = "RadComboBoxItem28"
        Me.RadComboBoxItem28.Text = "2015"
        '
        'RadComboBoxItem29
        '
        Me.RadComboBoxItem29.Name = "RadComboBoxItem29"
        Me.RadComboBoxItem29.Text = "2016"
        '
        'RadComboBoxItem30
        '
        Me.RadComboBoxItem30.Name = "RadComboBoxItem30"
        Me.RadComboBoxItem30.Text = "2017"
        '
        'RadComboBoxItem31
        '
        Me.RadComboBoxItem31.Name = "RadComboBoxItem31"
        Me.RadComboBoxItem31.Text = "2018"
        '
        'RadComboBoxItem32
        '
        Me.RadComboBoxItem32.Name = "RadComboBoxItem32"
        Me.RadComboBoxItem32.Text = "2019"
        '
        'RadComboBoxItem33
        '
        Me.RadComboBoxItem33.Name = "RadComboBoxItem33"
        Me.RadComboBoxItem33.Text = "2020"
        '
        'CmbMesApertura
        '
        Me.CmbMesApertura.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbMesApertura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbMesApertura.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem1, Me.RadComboBoxItem2, Me.RadComboBoxItem3, Me.RadComboBoxItem4, Me.RadComboBoxItem5, Me.RadComboBoxItem6, Me.RadComboBoxItem7, Me.RadComboBoxItem8, Me.RadComboBoxItem9, Me.RadComboBoxItem10, Me.RadComboBoxItem11, Me.RadComboBoxItem12})
        Me.CmbMesApertura.Location = New System.Drawing.Point(12, 31)
        Me.CmbMesApertura.Name = "CmbMesApertura"
        '
        '
        '
        Me.CmbMesApertura.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbMesApertura.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbMesApertura.Size = New System.Drawing.Size(90, 20)
        Me.CmbMesApertura.TabIndex = 238
        Me.CmbMesApertura.TabStop = False
        Me.CmbMesApertura.ThemeName = "Breeze"
        Me.CmbMesApertura.Visible = False
        '
        'RadComboBoxItem1
        '
        Me.RadComboBoxItem1.Name = "RadComboBoxItem1"
        Me.RadComboBoxItem1.Text = "Enero"
        '
        'RadComboBoxItem2
        '
        Me.RadComboBoxItem2.Name = "RadComboBoxItem2"
        Me.RadComboBoxItem2.Text = "Febrero"
        '
        'RadComboBoxItem3
        '
        Me.RadComboBoxItem3.Name = "RadComboBoxItem3"
        Me.RadComboBoxItem3.Text = "Marzo"
        '
        'RadComboBoxItem4
        '
        Me.RadComboBoxItem4.Name = "RadComboBoxItem4"
        Me.RadComboBoxItem4.Text = "Abril"
        '
        'RadComboBoxItem5
        '
        Me.RadComboBoxItem5.Name = "RadComboBoxItem5"
        Me.RadComboBoxItem5.Text = "Mayo"
        '
        'RadComboBoxItem6
        '
        Me.RadComboBoxItem6.Name = "RadComboBoxItem6"
        Me.RadComboBoxItem6.Text = "Junio"
        '
        'RadComboBoxItem7
        '
        Me.RadComboBoxItem7.Name = "RadComboBoxItem7"
        Me.RadComboBoxItem7.Text = "Julio"
        '
        'RadComboBoxItem8
        '
        Me.RadComboBoxItem8.Name = "RadComboBoxItem8"
        Me.RadComboBoxItem8.Text = "Agosto"
        '
        'RadComboBoxItem9
        '
        Me.RadComboBoxItem9.Name = "RadComboBoxItem9"
        Me.RadComboBoxItem9.Text = "Setiembre"
        '
        'RadComboBoxItem10
        '
        Me.RadComboBoxItem10.Name = "RadComboBoxItem10"
        Me.RadComboBoxItem10.Text = "Octubre"
        '
        'RadComboBoxItem11
        '
        Me.RadComboBoxItem11.Name = "RadComboBoxItem11"
        Me.RadComboBoxItem11.Text = "Noviembre"
        '
        'RadComboBoxItem12
        '
        Me.RadComboBoxItem12.Name = "RadComboBoxItem12"
        Me.RadComboBoxItem12.Text = "Diciembre"
        '
        'BtnFiltroApertura
        '
        Me.BtnFiltroApertura.AllowDrop = True
        Me.BtnFiltroApertura.BackColor = System.Drawing.Color.Transparent
        Me.BtnFiltroApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltroApertura.Location = New System.Drawing.Point(161, 32)
        Me.BtnFiltroApertura.Name = "BtnFiltroApertura"
        Me.BtnFiltroApertura.Size = New System.Drawing.Size(53, 19)
        Me.BtnFiltroApertura.TabIndex = 237
        Me.BtnFiltroApertura.Text = "Filtrar"
        Me.BtnFiltroApertura.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(105, 15)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(29, 13)
        Me.Label30.TabIndex = 235
        Me.Label30.Text = "Año."
        Me.Label30.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(14, 15)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(30, 13)
        Me.Label31.TabIndex = 234
        Me.Label31.Text = "Mes."
        Me.Label31.Visible = False
        '
        'BtnEliminarApertura
        '
        Me.BtnEliminarApertura.Location = New System.Drawing.Point(777, 59)
        Me.BtnEliminarApertura.Name = "BtnEliminarApertura"
        Me.BtnEliminarApertura.Size = New System.Drawing.Size(54, 27)
        Me.BtnEliminarApertura.TabIndex = 5
        Me.BtnEliminarApertura.Text = "Eliminar"
        '
        'BtnAgregarApertura
        '
        Me.BtnAgregarApertura.Location = New System.Drawing.Point(721, 59)
        Me.BtnAgregarApertura.Name = "BtnAgregarApertura"
        Me.BtnAgregarApertura.Size = New System.Drawing.Size(54, 27)
        Me.BtnAgregarApertura.TabIndex = 4
        Me.BtnAgregarApertura.Text = "Agregar"
        '
        'TxtMontoApertura
        '
        Me.TxtMontoApertura.AllowDrop = True
        Appearance2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance2.FontData.SizeInPoints = 13.0!
        Appearance2.TextHAlignAsString = "Right"
        Me.TxtMontoApertura.Appearance = Appearance2
        Me.TxtMontoApertura.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.TxtMontoApertura.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.TxtMontoApertura.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.TxtMontoApertura.Location = New System.Drawing.Point(432, 59)
        Me.TxtMontoApertura.Name = "TxtMontoApertura"
        Me.TxtMontoApertura.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtMontoApertura.Size = New System.Drawing.Size(136, 27)
        Me.TxtMontoApertura.TabIndex = 2
        '
        'TxtBuscarApertura
        '
        Me.TxtBuscarApertura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuscarApertura.Location = New System.Drawing.Point(53, 115)
        Me.TxtBuscarApertura.Name = "TxtBuscarApertura"
        Me.TxtBuscarApertura.Size = New System.Drawing.Size(129, 13)
        Me.TxtBuscarApertura.TabIndex = 180
        Me.TxtBuscarApertura.Text = "Buscar..."
        Me.TxtBuscarApertura.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Busqueda_Rapida
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.Location = New System.Drawing.Point(15, 106)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(182, 28)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 181
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'cbxTipoCobroApertura
        '
        Me.cbxTipoCobroApertura.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxTipoCobroApertura.DataSource = Me.TIPOFORMACOBROBindingSource
        Me.cbxTipoCobroApertura.DisplayMember = "DESFORCOBRO"
        Me.cbxTipoCobroApertura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoCobroApertura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoCobroApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTipoCobroApertura.FormattingEnabled = True
        Me.cbxTipoCobroApertura.Location = New System.Drawing.Point(575, 59)
        Me.cbxTipoCobroApertura.Name = "cbxTipoCobroApertura"
        Me.cbxTipoCobroApertura.Size = New System.Drawing.Size(142, 26)
        Me.cbxTipoCobroApertura.TabIndex = 427
        Me.cbxTipoCobroApertura.ValueMember = "CODFORCOBRO"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(425, 43)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 13)
        Me.Label21.TabIndex = 194
        Me.Label21.Text = "Importe"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(283, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 13)
        Me.Label22.TabIndex = 193
        Me.Label22.Text = "Moneda"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(576, 44)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 13)
        Me.Label24.TabIndex = 188
        Me.Label24.Text = "Tipo"
        '
        'CierresdetBindingSource
        '
        Me.CierresdetBindingSource.AllowNew = True
        Me.CierresdetBindingSource.DataMember = "FK_cierres_det_cierres"
        Me.CierresdetBindingSource.DataSource = Me.CierresBindingSource
        '
        'TIPOFORMACOBROCIERREBindingSource
        '
        Me.TIPOFORMACOBROCIERREBindingSource.DataMember = "TIPOFORMACOBRO"
        Me.TIPOFORMACOBROCIERREBindingSource.DataSource = Me.DsCaja1
        '
        'MONEDACIERREBindingSource
        '
        Me.MONEDACIERREBindingSource.DataMember = "MONEDA"
        Me.MONEDACIERREBindingSource.DataSource = Me.DsCaja1
        '
        'RadTextBox4
        '
        Me.RadTextBox4.Location = New System.Drawing.Point(76, 49)
        Me.RadTextBox4.Name = "RadTextBox4"
        Me.RadTextBox4.Size = New System.Drawing.Size(74, 20)
        Me.RadTextBox4.TabIndex = 255
        Me.RadTextBox4.TabStop = False
        Me.RadTextBox4.ThemeName = "Breeze"
        Me.RadTextBox4.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblNroApertura)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.FechaHoy)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblDescripCaja)
        Me.Panel1.Controls.Add(Me.LblCajero)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblSucursal)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.IngresoPictureBox)
        Me.Panel1.Controls.Add(Me.AperturaPictureBox)
        Me.Panel1.Controls.Add(Me.CierrePictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.EliminarGrisPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarGrisPictureBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LblCaja)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 42)
        Me.Panel1.TabIndex = 152
        '
        'lblNroApertura
        '
        Me.lblNroApertura.BackColor = System.Drawing.Color.Transparent
        Me.lblNroApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroApertura.ForeColor = System.Drawing.Color.Black
        Me.lblNroApertura.Location = New System.Drawing.Point(555, 9)
        Me.lblNroApertura.Name = "lblNroApertura"
        Me.lblNroApertura.Size = New System.Drawing.Size(92, 20)
        Me.lblNroApertura.TabIndex = 94
        Me.lblNroApertura.Text = "NroApertura"
        Me.lblNroApertura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label13.Location = New System.Drawing.Point(462, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 23)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "Nro de Apertura:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FechaHoy
        '
        Me.FechaHoy.AutoSize = True
        Me.FechaHoy.BackColor = System.Drawing.Color.Transparent
        Me.FechaHoy.Location = New System.Drawing.Point(52, 24)
        Me.FechaHoy.Name = "FechaHoy"
        Me.FechaHoy.Size = New System.Drawing.Size(77, 13)
        Me.FechaHoy.TabIndex = 92
        Me.FechaHoy.Text = "FechaApertura"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(-4, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 23)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Fecha:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'IngresoPictureBox
        '
        Me.IngresoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.IngresoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IngresoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.AjusteCaja
        Me.IngresoPictureBox.InitialImage = Nothing
        Me.IngresoPictureBox.Location = New System.Drawing.Point(800, 1)
        Me.IngresoPictureBox.Name = "IngresoPictureBox"
        Me.IngresoPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.IngresoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IngresoPictureBox.TabIndex = 73
        Me.IngresoPictureBox.TabStop = False
        '
        'AperturaPictureBox
        '
        Me.AperturaPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AperturaPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.AperturaPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Abierto
        Me.AperturaPictureBox.Location = New System.Drawing.Point(726, 1)
        Me.AperturaPictureBox.Name = "AperturaPictureBox"
        Me.AperturaPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.AperturaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.AperturaPictureBox.TabIndex = 72
        Me.AperturaPictureBox.TabStop = False
        '
        'CierrePictureBox
        '
        Me.CierrePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CierrePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CierrePictureBox.Image = Global.ContaExpress.My.Resources.Resources.Cerrado
        Me.CierrePictureBox.Location = New System.Drawing.Point(763, 1)
        Me.CierrePictureBox.Name = "CierrePictureBox"
        Me.CierrePictureBox.Size = New System.Drawing.Size(35, 35)
        Me.CierrePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CierrePictureBox.TabIndex = 70
        Me.CierrePictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.modificarficha
        Me.ModificarPictureBox.Location = New System.Drawing.Point(1045, 4)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.cancelar
        Me.CancelarPictureBox.Location = New System.Drawing.Point(1045, 4)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.guardar
        Me.GuardarPictureBox.Location = New System.Drawing.Point(966, 4)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.eliminar_ficha
        Me.EliminarPictureBox.Location = New System.Drawing.Point(887, 4)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'EliminarGrisPictureBox
        '
        Me.EliminarGrisPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarGrisPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarGrisPictureBox.Image = Global.ContaExpress.My.Resources.Resources.eliminar_fichagris
        Me.EliminarGrisPictureBox.Location = New System.Drawing.Point(887, 4)
        Me.EliminarGrisPictureBox.Name = "EliminarGrisPictureBox"
        Me.EliminarGrisPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.EliminarGrisPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarGrisPictureBox.TabIndex = 7
        Me.EliminarGrisPictureBox.TabStop = False
        '
        'GuardarGrisPictureBox
        '
        Me.GuardarGrisPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarGrisPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarGrisPictureBox.Image = Global.ContaExpress.My.Resources.Resources.guardargris
        Me.GuardarGrisPictureBox.Location = New System.Drawing.Point(1045, 4)
        Me.GuardarGrisPictureBox.Name = "GuardarGrisPictureBox"
        Me.GuardarGrisPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.GuardarGrisPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarGrisPictureBox.TabIndex = 9
        Me.GuardarGrisPictureBox.TabStop = False
        '
        'LblCaja
        '
        Me.LblCaja.BackColor = System.Drawing.Color.Black
        Me.LblCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblCaja.ForeColor = System.Drawing.Color.Silver
        Me.LblCaja.Location = New System.Drawing.Point(728, 8)
        Me.LblCaja.Name = "LblCaja"
        Me.LblCaja.Size = New System.Drawing.Size(33, 23)
        Me.LblCaja.TabIndex = 89
        Me.LblCaja.Text = "Caja"
        Me.LblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblCaja.Visible = False
        '
        'PanelIngresoEgreso
        '
        Me.PanelIngresoEgreso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelIngresoEgreso.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelIngresoEgreso.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.PanelIngresoEgreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelIngresoEgreso.Controls.Add(Me.cbxTipo)
        Me.PanelIngresoEgreso.Controls.Add(Me.cbxMonedaAjuste)
        Me.PanelIngresoEgreso.Controls.Add(Me.TxtImporteIngreso)
        Me.PanelIngresoEgreso.Controls.Add(Me.tbxConcepto)
        Me.PanelIngresoEgreso.Controls.Add(Me.Label5)
        Me.PanelIngresoEgreso.Controls.Add(Me.LblId_AperturaActual)
        Me.PanelIngresoEgreso.Controls.Add(Me.CmbEntradaSalida)
        Me.PanelIngresoEgreso.Controls.Add(Me.Label4)
        Me.PanelIngresoEgreso.Controls.Add(Me.GridViewIngresos)
        Me.PanelIngresoEgreso.Controls.Add(Me.BtnEliminarIngreso)
        Me.PanelIngresoEgreso.Controls.Add(Me.BtnAgregarIngreso)
        Me.PanelIngresoEgreso.Controls.Add(Me.Label9)
        Me.PanelIngresoEgreso.Controls.Add(Me.Label8)
        Me.PanelIngresoEgreso.Controls.Add(Me.Label7)
        Me.PanelIngresoEgreso.Controls.Add(Me.Label10)
        Me.PanelIngresoEgreso.Controls.Add(Me.Label11)
        Me.PanelIngresoEgreso.Location = New System.Drawing.Point(-2, 40)
        Me.PanelIngresoEgreso.Name = "PanelIngresoEgreso"
        Me.PanelIngresoEgreso.Size = New System.Drawing.Size(843, 514)
        Me.PanelIngresoEgreso.TabIndex = 236
        Me.PanelIngresoEgreso.Visible = False
        '
        'cbxTipo
        '
        Me.cbxTipo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxTipo.DataSource = Me.TIPOFORMACOBROBindingSource
        Me.cbxTipo.DisplayMember = "DESFORCOBRO"
        Me.cbxTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTipo.FormattingEnabled = True
        Me.cbxTipo.Location = New System.Drawing.Point(278, 69)
        Me.cbxTipo.Name = "cbxTipo"
        Me.cbxTipo.Size = New System.Drawing.Size(134, 26)
        Me.cbxTipo.TabIndex = 257
        Me.cbxTipo.ValueMember = "CODFORCOBRO"
        '
        'cbxMonedaAjuste
        '
        Me.cbxMonedaAjuste.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxMonedaAjuste.DataSource = Me.MONEDABindingSource
        Me.cbxMonedaAjuste.DisplayMember = "DESMONEDA"
        Me.cbxMonedaAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMonedaAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMonedaAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMonedaAjuste.FormattingEnabled = True
        Me.cbxMonedaAjuste.Location = New System.Drawing.Point(9, 69)
        Me.cbxMonedaAjuste.Name = "cbxMonedaAjuste"
        Me.cbxMonedaAjuste.Size = New System.Drawing.Size(129, 26)
        Me.cbxMonedaAjuste.TabIndex = 255
        Me.cbxMonedaAjuste.ValueMember = "CODMONEDA"
        '
        'TxtImporteIngreso
        '
        Me.TxtImporteIngreso.AllowDrop = True
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.FontData.SizeInPoints = 13.0!
        Appearance3.TextHAlignAsString = "Right"
        Me.TxtImporteIngreso.Appearance = Appearance3
        Me.TxtImporteIngreso.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.TxtImporteIngreso.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.TxtImporteIngreso.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.TxtImporteIngreso.Location = New System.Drawing.Point(143, 69)
        Me.TxtImporteIngreso.Name = "TxtImporteIngreso"
        Me.TxtImporteIngreso.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtImporteIngreso.Size = New System.Drawing.Size(130, 27)
        Me.TxtImporteIngreso.TabIndex = 2
        '
        'tbxConcepto
        '
        Me.tbxConcepto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxConcepto.Location = New System.Drawing.Point(9, 112)
        Me.tbxConcepto.Name = "tbxConcepto"
        Me.tbxConcepto.Size = New System.Drawing.Size(639, 27)
        Me.tbxConcepto.TabIndex = 256
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(644, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 23)
        Me.Label5.TabIndex = 253
        Me.Label5.Text = "Id Apertura Actual:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblId_AperturaActual
        '
        Me.LblId_AperturaActual.BackColor = System.Drawing.Color.Transparent
        Me.LblId_AperturaActual.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AperturasBindingSource, "id_apertura", True))
        Me.LblId_AperturaActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId_AperturaActual.ForeColor = System.Drawing.Color.Black
        Me.LblId_AperturaActual.Location = New System.Drawing.Point(760, 5)
        Me.LblId_AperturaActual.Name = "LblId_AperturaActual"
        Me.LblId_AperturaActual.Size = New System.Drawing.Size(69, 23)
        Me.LblId_AperturaActual.TabIndex = 254
        Me.LblId_AperturaActual.Text = "Id"
        Me.LblId_AperturaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbEntradaSalida
        '
        Me.CmbEntradaSalida.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CmbEntradaSalida.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.CmbEntradaSalida.Font = New System.Drawing.Font("Arial", 13.0!)
        Me.CmbEntradaSalida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbEntradaSalida.Items.AddRange(New Telerik.WinControls.RadItem() {Me.Entrada, Me.Salida})
        Me.CmbEntradaSalida.Location = New System.Drawing.Point(418, 69)
        Me.CmbEntradaSalida.Name = "CmbEntradaSalida"
        '
        '
        '
        Me.CmbEntradaSalida.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbEntradaSalida.RootElement.FlipText = False
        Me.CmbEntradaSalida.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbEntradaSalida.Size = New System.Drawing.Size(150, 27)
        Me.CmbEntradaSalida.TabIndex = 4
        Me.CmbEntradaSalida.TabStop = False
        Me.CmbEntradaSalida.ThemeName = "Breeze"
        CType(Me.CmbEntradaSalida.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        CType(Me.CmbEntradaSalida.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).BackColor = System.Drawing.Color.White
        CType(Me.CmbEntradaSalida.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 13.0!)
        CType(Me.CmbEntradaSalida.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
        CType(Me.CmbEntradaSalida.GetChildAt(0).GetChildAt(2).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Text = ""
        CType(Me.CmbEntradaSalida.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        '
        'Entrada
        '
        Me.Entrada.Name = "Entrada"
        Me.Entrada.Text = "Entrada"
        '
        'Salida
        '
        Me.Salida.Name = "Salida"
        Me.Salida.Text = "Salida"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Light", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label4.Location = New System.Drawing.Point(8, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(349, 34)
        Me.Label4.TabIndex = 230
        Me.Label4.Text = "Apertura / Cierre de Caja"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GridViewIngresos
        '
        Me.GridViewIngresos.AllowUserToAddRows = False
        Me.GridViewIngresos.AutoGenerateColumns = False
        Me.GridViewIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridViewIngresos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.GridViewIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewIngresos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.GridViewIngresos.ColumnHeadersHeight = 35
        Me.GridViewIngresos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdmovimientoDataGridViewTextBoxColumn, Me.IdaperturaDataGridViewTextBoxColumn2, Me.IdusuarioDataGridViewTextBoxColumn, Me.IdempresaDataGridViewTextBoxColumn, Me.FechamtoDataGridViewTextBoxColumn, Me.ConceptoDataGridViewTextBoxColumn, Me.EntradasalidaDataGridViewTextBoxColumn, Me.IdmonedaDataGridViewTextBoxColumn2, Me.IdtipodineroDataGridViewTextBoxColumn2, Me.MontoDataGridViewTextBoxColumn2, Me.DESMONEDADataGridViewTextBoxColumn2, Me.DESFORCOBRODataGridViewTextBoxColumn2, Me.Cotizacion1DataGridViewTextBoxColumn, Me.Cotizacion2DataGridViewTextBoxColumn, Me.IdcobroDataGridViewTextBoxColumn, Me.IdventaDataGridViewTextBoxColumn, Me.IdpagoDataGridViewTextBoxColumn, Me.IdcompraDataGridViewTextBoxColumn, Me.VueltoDataGridViewTextBoxColumn, Me.CodsucursalDataGridViewTextBoxColumn})
        Me.GridViewIngresos.DataSource = Me.MtosingresoegresodetalleBindingSource
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewIngresos.DefaultCellStyle = DataGridViewCellStyle21
        Me.GridViewIngresos.GridColor = System.Drawing.Color.Gainsboro
        Me.GridViewIngresos.Location = New System.Drawing.Point(4, 145)
        Me.GridViewIngresos.Name = "GridViewIngresos"
        Me.GridViewIngresos.ReadOnly = True
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewIngresos.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.GridViewIngresos.RowHeadersVisible = False
        Me.GridViewIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewIngresos.Size = New System.Drawing.Size(832, 364)
        Me.GridViewIngresos.TabIndex = 245
        '
        'IdmovimientoDataGridViewTextBoxColumn
        '
        Me.IdmovimientoDataGridViewTextBoxColumn.DataPropertyName = "id_movimiento"
        Me.IdmovimientoDataGridViewTextBoxColumn.HeaderText = "id_movimiento"
        Me.IdmovimientoDataGridViewTextBoxColumn.Name = "IdmovimientoDataGridViewTextBoxColumn"
        Me.IdmovimientoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdmovimientoDataGridViewTextBoxColumn.Visible = False
        '
        'IdaperturaDataGridViewTextBoxColumn2
        '
        Me.IdaperturaDataGridViewTextBoxColumn2.DataPropertyName = "id_apertura"
        Me.IdaperturaDataGridViewTextBoxColumn2.HeaderText = "id_apertura"
        Me.IdaperturaDataGridViewTextBoxColumn2.Name = "IdaperturaDataGridViewTextBoxColumn2"
        Me.IdaperturaDataGridViewTextBoxColumn2.ReadOnly = True
        Me.IdaperturaDataGridViewTextBoxColumn2.Visible = False
        '
        'IdusuarioDataGridViewTextBoxColumn
        '
        Me.IdusuarioDataGridViewTextBoxColumn.DataPropertyName = "id_usuario"
        Me.IdusuarioDataGridViewTextBoxColumn.HeaderText = "id_usuario"
        Me.IdusuarioDataGridViewTextBoxColumn.Name = "IdusuarioDataGridViewTextBoxColumn"
        Me.IdusuarioDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdusuarioDataGridViewTextBoxColumn.Visible = False
        '
        'IdempresaDataGridViewTextBoxColumn
        '
        Me.IdempresaDataGridViewTextBoxColumn.DataPropertyName = "id_empresa"
        Me.IdempresaDataGridViewTextBoxColumn.HeaderText = "id_empresa"
        Me.IdempresaDataGridViewTextBoxColumn.Name = "IdempresaDataGridViewTextBoxColumn"
        Me.IdempresaDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdempresaDataGridViewTextBoxColumn.Visible = False
        '
        'FechamtoDataGridViewTextBoxColumn
        '
        Me.FechamtoDataGridViewTextBoxColumn.DataPropertyName = "fecha_mto"
        Me.FechamtoDataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FechamtoDataGridViewTextBoxColumn.Name = "FechamtoDataGridViewTextBoxColumn"
        Me.FechamtoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ConceptoDataGridViewTextBoxColumn
        '
        Me.ConceptoDataGridViewTextBoxColumn.DataPropertyName = "concepto"
        Me.ConceptoDataGridViewTextBoxColumn.HeaderText = "Concepto"
        Me.ConceptoDataGridViewTextBoxColumn.Name = "ConceptoDataGridViewTextBoxColumn"
        Me.ConceptoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EntradasalidaDataGridViewTextBoxColumn
        '
        Me.EntradasalidaDataGridViewTextBoxColumn.DataPropertyName = "entradasalida"
        Me.EntradasalidaDataGridViewTextBoxColumn.HeaderText = "Ent/Sal."
        Me.EntradasalidaDataGridViewTextBoxColumn.Name = "EntradasalidaDataGridViewTextBoxColumn"
        Me.EntradasalidaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdmonedaDataGridViewTextBoxColumn2
        '
        Me.IdmonedaDataGridViewTextBoxColumn2.DataPropertyName = "id_moneda"
        Me.IdmonedaDataGridViewTextBoxColumn2.HeaderText = "id_moneda"
        Me.IdmonedaDataGridViewTextBoxColumn2.Name = "IdmonedaDataGridViewTextBoxColumn2"
        Me.IdmonedaDataGridViewTextBoxColumn2.ReadOnly = True
        Me.IdmonedaDataGridViewTextBoxColumn2.Visible = False
        '
        'IdtipodineroDataGridViewTextBoxColumn2
        '
        Me.IdtipodineroDataGridViewTextBoxColumn2.DataPropertyName = "id_tipo_dinero"
        Me.IdtipodineroDataGridViewTextBoxColumn2.HeaderText = "id_tipo_dinero"
        Me.IdtipodineroDataGridViewTextBoxColumn2.Name = "IdtipodineroDataGridViewTextBoxColumn2"
        Me.IdtipodineroDataGridViewTextBoxColumn2.ReadOnly = True
        Me.IdtipodineroDataGridViewTextBoxColumn2.Visible = False
        '
        'MontoDataGridViewTextBoxColumn2
        '
        Me.MontoDataGridViewTextBoxColumn2.DataPropertyName = "monto"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Format = "N1"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.MontoDataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle19
        Me.MontoDataGridViewTextBoxColumn2.HeaderText = "Monto"
        Me.MontoDataGridViewTextBoxColumn2.Name = "MontoDataGridViewTextBoxColumn2"
        Me.MontoDataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DESMONEDADataGridViewTextBoxColumn2
        '
        Me.DESMONEDADataGridViewTextBoxColumn2.DataPropertyName = "DESMONEDA"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DESMONEDADataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle20
        Me.DESMONEDADataGridViewTextBoxColumn2.HeaderText = "Moneda"
        Me.DESMONEDADataGridViewTextBoxColumn2.Name = "DESMONEDADataGridViewTextBoxColumn2"
        Me.DESMONEDADataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DESFORCOBRODataGridViewTextBoxColumn2
        '
        Me.DESFORCOBRODataGridViewTextBoxColumn2.DataPropertyName = "DESFORCOBRO"
        Me.DESFORCOBRODataGridViewTextBoxColumn2.HeaderText = "Tipo"
        Me.DESFORCOBRODataGridViewTextBoxColumn2.Name = "DESFORCOBRODataGridViewTextBoxColumn2"
        Me.DESFORCOBRODataGridViewTextBoxColumn2.ReadOnly = True
        '
        'Cotizacion1DataGridViewTextBoxColumn
        '
        Me.Cotizacion1DataGridViewTextBoxColumn.DataPropertyName = "cotizacion1"
        Me.Cotizacion1DataGridViewTextBoxColumn.HeaderText = "Cotización"
        Me.Cotizacion1DataGridViewTextBoxColumn.Name = "Cotizacion1DataGridViewTextBoxColumn"
        Me.Cotizacion1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Cotizacion2DataGridViewTextBoxColumn
        '
        Me.Cotizacion2DataGridViewTextBoxColumn.DataPropertyName = "cotizacion2"
        Me.Cotizacion2DataGridViewTextBoxColumn.HeaderText = "cotizacion2"
        Me.Cotizacion2DataGridViewTextBoxColumn.Name = "Cotizacion2DataGridViewTextBoxColumn"
        Me.Cotizacion2DataGridViewTextBoxColumn.ReadOnly = True
        Me.Cotizacion2DataGridViewTextBoxColumn.Visible = False
        '
        'IdcobroDataGridViewTextBoxColumn
        '
        Me.IdcobroDataGridViewTextBoxColumn.DataPropertyName = "id_cobro"
        Me.IdcobroDataGridViewTextBoxColumn.HeaderText = "id_cobro"
        Me.IdcobroDataGridViewTextBoxColumn.Name = "IdcobroDataGridViewTextBoxColumn"
        Me.IdcobroDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdcobroDataGridViewTextBoxColumn.Visible = False
        '
        'IdventaDataGridViewTextBoxColumn
        '
        Me.IdventaDataGridViewTextBoxColumn.DataPropertyName = "id_venta"
        Me.IdventaDataGridViewTextBoxColumn.HeaderText = "id_venta"
        Me.IdventaDataGridViewTextBoxColumn.Name = "IdventaDataGridViewTextBoxColumn"
        Me.IdventaDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdventaDataGridViewTextBoxColumn.Visible = False
        '
        'IdpagoDataGridViewTextBoxColumn
        '
        Me.IdpagoDataGridViewTextBoxColumn.DataPropertyName = "id_pago"
        Me.IdpagoDataGridViewTextBoxColumn.HeaderText = "id_pago"
        Me.IdpagoDataGridViewTextBoxColumn.Name = "IdpagoDataGridViewTextBoxColumn"
        Me.IdpagoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdpagoDataGridViewTextBoxColumn.Visible = False
        '
        'IdcompraDataGridViewTextBoxColumn
        '
        Me.IdcompraDataGridViewTextBoxColumn.DataPropertyName = "id_compra"
        Me.IdcompraDataGridViewTextBoxColumn.HeaderText = "id_compra"
        Me.IdcompraDataGridViewTextBoxColumn.Name = "IdcompraDataGridViewTextBoxColumn"
        Me.IdcompraDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdcompraDataGridViewTextBoxColumn.Visible = False
        '
        'VueltoDataGridViewTextBoxColumn
        '
        Me.VueltoDataGridViewTextBoxColumn.DataPropertyName = "vuelto"
        Me.VueltoDataGridViewTextBoxColumn.HeaderText = "vuelto"
        Me.VueltoDataGridViewTextBoxColumn.Name = "VueltoDataGridViewTextBoxColumn"
        Me.VueltoDataGridViewTextBoxColumn.ReadOnly = True
        Me.VueltoDataGridViewTextBoxColumn.Visible = False
        '
        'CodsucursalDataGridViewTextBoxColumn
        '
        Me.CodsucursalDataGridViewTextBoxColumn.DataPropertyName = "codsucursal"
        Me.CodsucursalDataGridViewTextBoxColumn.HeaderText = "codsucursal"
        Me.CodsucursalDataGridViewTextBoxColumn.Name = "CodsucursalDataGridViewTextBoxColumn"
        Me.CodsucursalDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodsucursalDataGridViewTextBoxColumn.Visible = False
        '
        'MtosingresoegresodetalleBindingSource
        '
        Me.MtosingresoegresodetalleBindingSource.DataMember = "mtosingresoegresodetalle"
        Me.MtosingresoegresodetalleBindingSource.DataSource = Me.DsCaja1
        '
        'BtnEliminarIngreso
        '
        Me.BtnEliminarIngreso.Location = New System.Drawing.Point(748, 112)
        Me.BtnEliminarIngreso.Name = "BtnEliminarIngreso"
        Me.BtnEliminarIngreso.Size = New System.Drawing.Size(88, 27)
        Me.BtnEliminarIngreso.TabIndex = 7
        Me.BtnEliminarIngreso.Text = "Eliminar"
        '
        'BtnAgregarIngreso
        '
        Me.BtnAgregarIngreso.Location = New System.Drawing.Point(654, 112)
        Me.BtnAgregarIngreso.Name = "BtnAgregarIngreso"
        Me.BtnAgregarIngreso.Size = New System.Drawing.Size(88, 27)
        Me.BtnAgregarIngreso.TabIndex = 6
        Me.BtnAgregarIngreso.Text = "Agregar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(275, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 188
        Me.Label9.Text = "Tipo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(7, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "Moneda"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(140, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 194
        Me.Label7.Text = "Importe"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 251
        Me.Label10.Text = "Concepto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(414, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 252
        Me.Label11.Text = "Entrada/Salida"
        '
        'FKmovimientosaperturas1BindingSource
        '
        Me.FKmovimientosaperturas1BindingSource.DataMember = "FK_movimientos_aperturas1"
        Me.FKmovimientosaperturas1BindingSource.DataSource = Me.CierresBindingSource
        '
        'FKcierresdetcierresBindingSource
        '
        Me.FKcierresdetcierresBindingSource.DataMember = "FK_cierres_det_cierres"
        Me.FKcierresdetcierresBindingSource.DataSource = Me.CierresBindingSource
        '
        'AperturasTableAdapter
        '
        Me.AperturasTableAdapter.ClearBeforeFill = True
        '
        'Aperturas_detTableAdapter
        '
        Me.Aperturas_detTableAdapter.ClearBeforeFill = True
        '
        'MONEDATableAdapter
        '
        Me.MONEDATableAdapter.ClearBeforeFill = True
        '
        'TIPOFORMACOBROTableAdapter
        '
        Me.TIPOFORMACOBROTableAdapter.ClearBeforeFill = True
        '
        'CierresTableAdapter
        '
        Me.CierresTableAdapter.ClearBeforeFill = True
        '
        'Cierres_detTableAdapter
        '
        Me.Cierres_detTableAdapter.ClearBeforeFill = True
        '
        'MtosingresoegresodetalleTableAdapter
        '
        Me.MtosingresoegresodetalleTableAdapter.ClearBeforeFill = True
        '
        'MovimientosTableAdapter
        '
        Me.MovimientosTableAdapter.ClearBeforeFill = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Tan
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.lblCuentasEstado, Me.pbarEstadoVentas})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 557)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(838, 22)
        Me.StatusStrip1.TabIndex = 467
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Image = Global.ContaExpress.My.Resources.Resources.help
        Me.ToolStripStatusLabel2.IsLink = True
        Me.ToolStripStatusLabel2.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripStatusLabel2.Text = "Ayuda"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(634, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'lblCuentasEstado
        '
        Me.lblCuentasEstado.AutoToolTip = True
        Me.lblCuentasEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblCuentasEstado.Name = "lblCuentasEstado"
        Me.lblCuentasEstado.Size = New System.Drawing.Size(30, 17)
        Me.lblCuentasEstado.Text = "Caja"
        Me.lblCuentasEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbarEstadoVentas
        '
        Me.pbarEstadoVentas.BackColor = System.Drawing.Color.Gainsboro
        Me.pbarEstadoVentas.Name = "pbarEstadoVentas"
        Me.pbarEstadoVentas.Size = New System.Drawing.Size(100, 16)
        Me.pbarEstadoVentas.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'AperturaCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(838, 579)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PanelApertura)
        Me.Controls.Add(Me.PanelIngresoEgreso)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AperturaCierreCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion de Cuentas | Cogent SIG"
        Me.PanelApertura.ResumeLayout(False)
        Me.PanelApertura.PerformLayout()
        Me.PanelCierreCaja.ResumeLayout(False)
        Me.PanelCierreCaja.PerformLayout()
        CType(Me.TIPOFORMACOBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCaja1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtid_apertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AperturasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEliminarCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCierre1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAgregarCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CierresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCierreDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnConfirmarCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewApertura1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAperturaDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AperturasdetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnConfirmaApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbAnhoApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbMesApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFiltroApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEliminarApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAgregarApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CierresdetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOFORMACOBROCIERREBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MONEDACIERREBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadTextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.IngresoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AperturaPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CierrePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarGrisPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarGrisPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelIngresoEgreso.ResumeLayout(False)
        Me.PanelIngresoEgreso.PerformLayout()
        CType(Me.CmbEntradaSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MtosingresoegresodetalleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEliminarIngreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAgregarIngreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKmovimientosaperturas1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKcierresdetcierresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents AperturaPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CierrePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarGrisPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarGrisPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblSucursal As System.Windows.Forms.Label
    Friend WithEvents LblCajero As System.Windows.Forms.Label
    Friend WithEvents PanelApertura As System.Windows.Forms.Panel
    Friend WithEvents BtnConfirmaApertura As Telerik.WinControls.UI.RadButton
    Friend WithEvents CmbAnhoApertura As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents CmbMesApertura As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents BtnFiltroApertura As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents BtnEliminarApertura As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnAgregarApertura As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtMontoApertura As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtBuscarApertura As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents AperturasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsCaja1 As ContaExpress.DsCaja1
    Friend WithEvents AperturasTableAdapter As ContaExpress.DsCaja1TableAdapters.aperturasTableAdapter
    Friend WithEvents PanelCierreCaja As System.Windows.Forms.Panel
    Friend WithEvents BtnConfirmarCierre As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnEliminarCierre As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnAgregarCierre As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteCierre As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents CmbMonedaCierre As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents RadTextBox4 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents GridViewApertura1 As System.Windows.Forms.DataGridView
    Friend WithEvents AperturasdetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Aperturas_detTableAdapter As ContaExpress.DsCaja1TableAdapters.aperturas_detTableAdapter
    Friend WithEvents MONEDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MONEDATableAdapter As ContaExpress.DsCaja1TableAdapters.MONEDATableAdapter
    Friend WithEvents TIPOFORMACOBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOFORMACOBROTableAdapter As ContaExpress.DsCaja1TableAdapters.TIPOFORMACOBROTableAdapter
    Friend WithEvents MONEDACIERREBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOFORMACOBROCIERREBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Txtid_apertura As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents GridViewCierre1 As System.Windows.Forms.DataGridView
    Friend WithEvents CierresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CierresTableAdapter As ContaExpress.DsCaja1TableAdapters.cierresTableAdapter
    Friend WithEvents CierresdetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cierres_detTableAdapter As ContaExpress.DsCaja1TableAdapters.cierres_detTableAdapter
    Friend WithEvents TxtId_Cierre As System.Windows.Forms.TextBox
    Friend WithEvents IngresoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PanelIngresoEgreso As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GridViewIngresos As System.Windows.Forms.DataGridView
    Friend WithEvents BtnEliminarIngreso As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnAgregarIngreso As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteIngreso As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmbEntradaSalida As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents MtosingresoegresodetalleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MtosingresoegresodetalleTableAdapter As ContaExpress.DsCaja1TableAdapters.mtosingresoegresodetalleTableAdapter
    Friend WithEvents Entrada As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents Salida As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblId_AperturaActual As System.Windows.Forms.Label
    Friend WithEvents RadComboBoxItem13 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem14 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem15 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem16 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem17 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem18 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem19 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem20 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem21 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem22 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem23 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem24 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem25 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem26 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem27 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem28 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem29 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem30 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem31 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem32 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem33 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem1 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem2 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem3 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem4 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem5 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem6 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem7 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem8 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem9 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem10 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem11 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem12 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents FKmovimientosaperturas1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MovimientosTableAdapter As ContaExpress.DsCaja1TableAdapters.movimientosTableAdapter
    Friend WithEvents FKcierresdetcierresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GridViewCierre As System.Windows.Forms.DataGridView
    Friend WithEvents IdaperturaDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechapaerturaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdcajaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AperturanumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdempresaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdusuarioDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GridViewCierreDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents GridViewAperturaDet As System.Windows.Forms.DataGridView
    Friend WithEvents IdaperturadetDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdaperturaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdtipodineroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdmonedaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESFORCOBRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblDescripCaja As System.Windows.Forms.Label
    Friend WithEvents cbxMonedaCierre As System.Windows.Forms.ComboBox
    Friend WithEvents cbxMonedaApertura As System.Windows.Forms.ComboBox
    Friend WithEvents cbxTipoCobroCierre As System.Windows.Forms.ComboBox
    Friend WithEvents cbxTipoCobroApertura As System.Windows.Forms.ComboBox
    Friend WithEvents cbxMonedaAjuste As System.Windows.Forms.ComboBox
    Friend WithEvents tbxConcepto As System.Windows.Forms.TextBox
    Friend WithEvents cbxTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Moneda1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDA1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPOFORMACOBRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonedaCierre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoCierre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodMonedaCierre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDineroCierre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodTipoDinero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCierre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCuentasEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pbarEstadoVentas As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents IdmovimientoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdaperturaDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdusuarioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdempresaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechamtoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConceptoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntradasalidaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdmonedaDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdtipodineroDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMONEDADataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESFORCOBRODataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cotizacion1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cotizacion2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdcobroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdventaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdpagoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdcompraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VueltoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodsucursalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdcierredetDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdmonedaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdtipodineroDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMONEDADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdaperturaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESFORCOBRODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FechaHoy As System.Windows.Forms.Label
    Friend WithEvents LblCaja As System.Windows.Forms.Label
    Friend WithEvents lblNroApertura As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
