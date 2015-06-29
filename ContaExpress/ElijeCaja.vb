Imports System.Data.SqlClient
Imports System.Windows.Forms


Public Class ElijeCaja

    #Region "Fields"

    Private cmd As SqlCommand
    Private myTrans As SqlTransaction
    Private ser As BDConexión.BDConexion
    Dim sql As String
    Dim w As New Funciones.Funciones
    '#################Variables de conexion usadas en la transaccion######
    Private sqlc As SqlConnection
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

    Private Function ActualizaCajaCobrador() As Boolean
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try

            Dim dtFecha As DateTime = DateTime.Now
            Dim Fecha
            Fecha = dtFecha.ToString("MM/dd/yyyy")
            Fecha = Fecha + " " + dtFecha.ToString("HH:mm:ss")

            sql = ""
            sql = "UPDATE CAJA SET CODUSUARIO = " & UsuCodigo & ", FECGRA = CONVERT(DATETIME, '" & Fecha & "', 102) , ESTATUS = 1   WHERE NUMCAJA= " & NumCaja & " "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            Return True

        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch

            End Try

            MessageBox.Show("Error al Ingresar: " & ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        Finally
            sqlc.Close()
        End Try
    End Function

    Private Sub AsignaMaquina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Verificamos si la PC no tiene una Caja Asignada por defecto
        Dim ExisteCaja As Integer = w.FuncionConsultaDecimal("CODCAJA", "PC", "IP", CodigoMaquina)
        Dim CajaNombre As String = w.FuncionConsultaString("NUMEROCAJA", "CAJA", "NUMCAJA", ExisteCaja)

        CAJATableAdapter.Fill(DsSettings.CAJA, SucCodigo)

        If CajaNombre <> "" Then
            cbxCuenta.Text = CajaNombre
        End If
    End Sub

    Private Sub cbxCuenta_GotFocus(sender As Object, e As System.EventArgs) Handles cbxCuenta.GotFocus
        cbxCuenta.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub RadComboBoxMaquina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxCuenta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAceptar.PerformClick()
            KeyAscii = 0
        End If
    End Sub

    Private Sub GuardaCaja()
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            sql = ""
            sql = "DECLARE @NUMCAJA AS INTEGER  SELECT @NUMCAJA=ISNULL(MAX(NUMCAJA),0 )+1 FROM CAJA " & _
             "Insert into CAJA (NUMCAJA,NUMEROCAJA,CODSUCURSAL,CODCOBRADOR,CODUSUARIO,CODEMPRESA,FECGRA,ESTATUS) " & _
            "values (@NUMCAJA," & cbxCuenta.SelectedValue & "," & SucCodigo & "," & UsuCodigo & "," & UsuCodigo & "," & EmpCodigo & ",getdate(),0)"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            myTrans.Commit()

        Catch ex As Exception
            Try
                myTrans.Rollback("Actualizar")
            Catch

            End Try

        Finally
            sqlc.Close()
        End Try
    End Sub

#End Region 'Methods

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim VerificarCaja, VerificaUser As Integer
        Dim dtFecha As DateTime = DateTime.Now
        Dim Fecha

        Fecha = dtFecha.ToString("MM/dd/yyyy")
        Fecha = Fecha + " " + dtFecha.ToString("HH:mm:ss")

        If cbxCuenta.SelectedValue = Nothing Then
            MessageBox.Show("Seleccione una Cuenta", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxCuenta.Focus()
            Exit Sub
        End If
        NumCaja = cbxCuenta.SelectedValue
        NumeroCaja = cbxCuenta.Text ' Uso Numero de caja para traer el campo NumeroCaja q a veces puede ser descricpcion Caja 1

        'Antes de ActualizaCajaCobrador se debe verificar que el estado de la caja abrir sea 0  - by Yolanda Zelaya
        '1- se verifia si la caja seleccionada ya esta siendo usada, es decir si tiene status 1
        VerificarCaja = w.FuncionConsultaString("ESTATUS", "CAJA", "NUMCAJA", NumCaja)

        If VerificarCaja = 1 Then
            '2 - ahora debemos verificar si dicha caja esta siendo usada por el mismo usuario
            VerificaUser = w.FuncionConsultaString("CODUSUARIO", "CAJA", "NUMCAJA", NumCaja)

            If VerificaUser = UsuCodigo Then
                ActualizaCajaCobrador()

                If ActualizaCajaCobrador() = True Then
                    Me.DialogResult = DialogResult.OK
                Else
                    Me.DialogResult = DialogResult.Cancel
                End If
            Else
                MessageBox.Show("Usted no podra acceder a esta cuenta, Otro Usuario lo esta utilizando!", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ActualizaCajaCobrador()

            If ActualizaCajaCobrador() = True Then
                Me.DialogResult = DialogResult.OK
            Else
                Me.DialogResult = DialogResult.Cancel
            End If
        End If

    End Sub

    Private Sub cbxCuenta_LostFocus(sender As Object, e As System.EventArgs) Handles cbxCuenta.LostFocus
        cbxCuenta.BackColor = Color.Gainsboro
    End Sub

End Class