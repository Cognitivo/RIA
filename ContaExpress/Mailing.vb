Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Collections

Public Class MailingMail
    Dim Body As String
    Dim Mensaje As String
    Dim ImageAdjunto As String
    Dim ImagePreview As String
    Dim Preview As Boolean
    Dim Header As String
    Dim PreviewFileName As String
    Dim sPath As String = Application.StartupPath
    Dim Existe As String
    Dim F As New Funciones.Funciones
    Dim ServidorSMTP, Puerto, Usuario, Pass, Remitente, ErrorCadena As String
    Dim c, EmailError As Integer
    Dim sql As String
    Private sqlc As New SqlConnection
    Private ser As New BDConexión.BDConexion
    Private myTrans As SqlTransaction
    Private cmd As New SqlCommand
    Dim TextoHtml As Boolean
    Dim Fecha As String
    Dim Edit As Boolean
    Dim permiso As Double

    Dim EstiloColor, EstiloAling As String

    Private Sub btnH2_Click(sender As System.Object, e As System.EventArgs) Handles btnH2.Click
        Me.tbxMessageBody.SelectedText = "<h2> Titulo </h2>"
    End Sub

    Private Sub btnP_Click(sender As System.Object, e As System.EventArgs) Handles btnP.Click
        Me.tbxMessageBody.SelectedText = "<p> NuevoParafo </p>"
    End Sub

    Private Sub Mailing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 191)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para abrir esta ventana", "Pos Express")
            Me.Close()
        End If


        EmailError = 0
        Fecha = (Today.ToString("ddMMyyyy"))
        DesHabilitar()
        pnlEmailBody.BringToFront()
        pbxMensajeEmail.Image = My.Resources.EmailMessageActive
        Me.DETALLEEMAILTableAdapter.Fill(Me.DsMassEmailing.DETALLEEMAIL)
        Me.TIPOCLIENTETableAdapter.Fill(Me.DsMassEmailing.TIPOCLIENTE)

        '===================Consultamos en la Base de Datos==================
        Existe = F.Maximo("CODSMTP", "SMTP")
        ServidorSMTP = F.FuncionConsultaString("SERVIDORSMTP", "SMTP", "CODSMTP", Existe)
        Puerto = F.FuncionConsultaString("PUERTO", "SMTP", "CODSMTP", Existe)
        Usuario = F.FuncionConsultaString("USUARIO", "SMTP", "CODSMTP", Existe)
        Pass = F.FuncionConsultaString("CONTRASENHA", "SMTP", "CODSMTP", Existe)
        Remitente = F.FuncionConsultaString("REMITENTE", "SMTP", "CODSMTP", Existe)

    End Sub

    Private Sub pbxHtml_Click(sender As System.Object, e As System.EventArgs) Handles pbxHtml.Click

        TextoHtml = True
        pnlHTML.BringToFront()
        pbxHtml.Image = My.Resources.HtmlActive
        pbxHtml.Cursor = Cursors.Arrow
        pbxVistaPrevia.Image = My.Resources.Display
        pbxVistaPrevia.Cursor = Cursors.Hand
        pbxMensajeEmail.Image = My.Resources.EmailMessage
        pbxMensajeEmail.Cursor = Cursors.Hand
        pbxPublico.Image = My.Resources.User
        pbxPublico.Cursor = Cursors.Hand
    End Sub

    Private Sub pbxMensajeEmail_Click(sender As System.Object, e As System.EventArgs) Handles pbxMensajeEmail.Click
       
        TextoHtml = False
        pnlEmailBody.BringToFront()
        pbxHtml.Image = My.Resources.Html
        pbxHtml.Cursor = Cursors.Hand
        pbxVistaPrevia.Image = My.Resources.Display
        pbxVistaPrevia.Cursor = Cursors.Hand
        pbxMensajeEmail.Image = My.Resources.EmailMessageActive
        pbxMensajeEmail.Cursor = Cursors.Arrow
        pbxPublico.Image = My.Resources.User
        pbxPublico.Cursor = Cursors.Hand
    End Sub

    Private Sub pbxVistaPrevia_Click(sender As System.Object, e As System.EventArgs) Handles pbxVistaPrevia.Click

        pnlVistaPrevia.BringToFront()
        pbxHtml.Image = My.Resources.Html
        pbxHtml.Cursor = Cursors.Hand
        pbxVistaPrevia.Image = My.Resources.DisplayActive
        pbxVistaPrevia.Cursor = Cursors.Arrow
        pbxMensajeEmail.Image = My.Resources.EmailMessage
        pbxMensajeEmail.Cursor = Cursors.Hand
        pbxPublico.Image = My.Resources.User
        pbxPublico.Cursor = Cursors.Hand
        Preview = True

        If TextoHtml = True Then
            MensajeEm()
        Else
            MensajeEmail()
        End If
    End Sub

    Private Sub btnNegrita_Click(sender As Object, e As System.EventArgs) Handles btnNegrita.Click
        Me.tbxMessageBody.SelectedText = "<b> TextoNegrita </b>"
    End Sub

    Private Sub btnItalico_Click(sender As Object, e As System.EventArgs) Handles btnItalico.Click
        Me.tbxMessageBody.SelectedText = "<i> TextoItalico </i>"
    End Sub

    Private Sub btnColorSel_Click(sender As System.Object, e As System.EventArgs) Handles btnColorSel.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            tbxColorFondo.BackColor = ColorDialog1.Color
            tbxMessageBody.BackColor = ColorDialog1.Color
            Dim a, r, g, b As Integer
            a = ColorDialog1.Color.A
            r = ColorDialog1.Color.R
            g = ColorDialog1.Color.G
            b = ColorDialog1.Color.B
            tbxColorFondo.Text = System.Drawing.ColorTranslator.ToHtml(ColorDialog1.Color)
        End If
        tbxColorFondo.Focus()

    End Sub

    Private Sub pbxPublico_Click(sender As System.Object, e As System.EventArgs) Handles pbxPublico.Click
        pnlPublico.BringToFront()
        pbxPublico.Image = My.Resources.UserActive
        pbxPublico.Cursor = Cursors.Arrow
        pbxHtml.Image = My.Resources.Html
        pbxHtml.Cursor = Cursors.Hand
        pbxVistaPrevia.Image = My.Resources.Display
        pbxVistaPrevia.Cursor = Cursors.Hand
        pbxMensajeEmail.Image = My.Resources.EmailMessage
        pbxMensajeEmail.Cursor = Cursors.Hand

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Me.CLIENTESMKTTableAdapter.selectcommand.CommandText = "SELECT NOMBRE, FECHANACIMIENTO, SEXO, EMAIL, CODTIPOCLIENTE FROM CLIENTES"

            Dim sql As String = ""
            Dim Sexo As String = ""
            Dim ListaPrecio As String = ""
            Dim SiFSexo As Boolean = False

            If cmbSexo.Text <> "%" Then
                SiFSexo = True
                If cmbSexo.Text = "Femenino" Then
                    Sexo = "SEXO = 0"
                ElseIf cmbSexo.Text = "Masculino" Then
                    Sexo = "SEXO = 1"
                Else
                    Sexo = "SEXO = 2"
                End If
            End If

            If cmbListaPrecio.Text <> "%" Then
                If SiFSexo = True Then
                    ListaPrecio = " AND CODTIPOCLIENTE = " & cmbListaPrecio.SelectedValue
                Else
                    ListaPrecio = "CODTIPOCLIENTE = " & cmbListaPrecio.SelectedValue
                End If
            Else
                CLIENTESMKTTableAdapter.Fill(Me.DsMassEmailing.CLIENTESMKT)
            End If

            If Sexo + ListaPrecio = "" Then
                sql = "EMAIL is not null AND EMAIL <> ' ' AND SEXO IS NOT NULL AND DAY(FECHANACIMIENTO)>=" & cmbDiaDesde.Text & " AND DAY(FECHANACIMIENTO)<=" & cmbDiaHasta.Text & " AND MONTH(FECHANACIMIENTO)>= " & cmbMesDesde.SelectedIndex + 1 & " AND MONTH(FECHANACIMIENTO)<=" & cmbMesHasta.SelectedIndex + 1 & " ORDER BY NOMBRE"
            Else
                sql = "EMAIL is not null AND EMAIL <> ' ' AND SEXO IS NOT NULL AND DAY(FECHANACIMIENTO)>=" & cmbDiaDesde.Text & " AND DAY(FECHANACIMIENTO)<=" & cmbDiaHasta.Text & " AND MONTH(FECHANACIMIENTO)>= " & cmbMesDesde.SelectedIndex + 1 & " AND MONTH(FECHANACIMIENTO)<=" & cmbMesHasta.SelectedIndex + 1 & " AND " + Sexo + ListaPrecio + " ORDER BY NOMBRE"
            End If

            Me.CLIENTESMKTTableAdapter.selectcommand.CommandText += " WHERE " + sql
            Me.CLIENTESMKTTableAdapter.Fill(Me.DsMassEmailing.CLIENTESMKT)
            '   For i = 0 To dgvTipoCliente.Rows.Count - 1
            '        Dim checked As Boolean
            '        checked = dgvTipoCliente.Rows(i).Cells("Agregar").Value
            '        Dim primero As Boolean
            '        If checked = True Then
            '            If primero = 0 Then
            '                sql = dgvTipoCliente.Rows(i).Cells("DESTIPOCLIENTE1").Value
            '                primero = 1
            '            Else
            '                sql = sql + "," + dgvTipoCliente.Rows(i).Cells("DESTIPOCLIENTE1").Value

            '            End If
            '        End If

            '    Next
            '    Me.CLIENTESTableAdapter.Fill(DsMassEmailing.CLIENTES, sql)
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub
    Private Sub cmbSexo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbSexo.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbSexo.Text = "%"
        End If
    End Sub
    Private Sub cmbListaPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbListaPrecio.KeyDown
        If e.KeyCode = Keys.F12 Then
            cmbListaPrecio.Text = "%"
        End If
    End Sub

    Private Sub pbxEnviarEmail_Click(sender As System.Object, e As System.EventArgs) Handles pbxEnviarEmail.Click

        If dgvListaCliente.RowCount = 0 Then
            MessageBox.Show("Selecciones una lista de Emails para el Envio", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pnlPublico.BringToFront()
            Exit Sub
        End If

        Me.Cursor = Cursors.AppStarting

        If TextoHtml = True Then
            MensajeEm()
        Else
            MensajeEmail()
        End If

        pbxEnviarEmail.Image = My.Resources.SendEmailActive
        pbxEnviarEmail.Cursor = Cursors.Arrow

        Application.DoEvents()

        EnviarEmail()

        Me.Cursor = Cursors.Arrow

    End Sub

    Public Sub EnviarEmail()
        Try
            Dim email As String
            Dim nombre As String
            Dim QtyEnvio As Integer = 0
            pgBarEnviado.Maximum = dgvListaCliente.RowCount

            '===================================Consultamos en Base de Datos============================================

            Existe = F.Maximo("CODSMTP", "SMTP")
            ServidorSMTP = F.FuncionConsultaString("SERVIDORSMTP", "SMTP", "CODSMTP", Existe)
            Puerto = F.FuncionConsultaString("PUERTO", "SMTP", "CODSMTP", Existe)
            Usuario = F.FuncionConsultaString("USUARIO", "SMTP", "CODSMTP", Existe)
            Pass = F.FuncionConsultaString("CONTRASENHA", "SMTP", "CODSMTP", Existe)

            Remitente = F.FuncionConsultaString("REMITENTE", "SMTP", "CODSMTP", Existe)
            Preview = False
            MensajeEm()
            Application.DoEvents()
            '=============================Envio de MAIL=====================================================================
            QtyEnvio = 0 : EmailError = 0
            ErrorCadena = ""

            For i = 0 To dgvListaCliente.Rows.Count - 1
                Try
                    email = dgvListaCliente.Rows(i).Cells("EMAIL").Value
                    nombre = dgvListaCliente.Rows(i).Cells("NOMBRE").Value
                    Dim insMail As New MailMessage(New MailAddress(Usuario), New MailAddress(email))
                    With insMail

                        .Subject = txtAsunto.Text
                        .IsBodyHtml = True 'envia el mensaje como html
                        .Body = Mensaje
                        .From = New MailAddress(Usuario)
                        .ReplyTo = New MailAddress(email)

                    End With
                    Dim smtp As New System.Net.Mail.SmtpClient
                    smtp.Host = ServidorSMTP
                    smtp.Port = Puerto
                    smtp.EnableSsl = True
                    smtp.UseDefaultCredentials = False
                    smtp.Credentials = New System.Net.NetworkCredential(Usuario, Pass)
                    Dim vistahtml As AlternateView = AlternateView.CreateAlternateViewFromString(Mensaje, Nothing, MediaTypeNames.Text.Html)

                    If tbxImage.Text <> "" Then
                        Dim Image As New LinkedResource(tbxImage.Text)
                        Image.ContentId = "Imagen"
                        vistahtml.LinkedResources.Add(Image)
                        insMail.AlternateViews.Add(vistahtml)
                    End If

                    QtyEnvio += 1
                    Me.Cursor = Cursors.WaitCursor
                    smtp.Send(insMail)
                    lblEnviados.Text = "Enviados " & CStr(QtyEnvio) & " de " & CStr(dgvListaCliente.Rows.Count)
                    Application.DoEvents()
                    Me.Cursor = Cursors.AppStarting
                    pgBarEnviado.Value = QtyEnvio

                Catch ex As Exception
                    EmailError = EmailError + 1
                    ErrorCadena = dgvListaCliente.Rows(i).Cells("NOMBRE").Value & vbNewLine & ErrorCadena
                    pgBarEnviado.Value = QtyEnvio

                End Try

                Application.DoEvents()

            Next
            If EmailError <> 0 Then
                lblError.Text = "Ver Errores"
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        lblEnviados.Text = "Processo Terminado!"
        pbxEnviarEmail.Image = My.Resources.SendEmail
    End Sub

    Private Sub MensajeEm()
        '==================Fromacion del Texto HTML a traves de la pestaña pbxHtml==================================
        '=============En caso que se entre en el boton modificar le asignamos de vuelta los valores xq se pierden al guardar en la BD el archivo HTML en vez del Texto ======================
        Dim texto As String
        texto = "<div style=""text-align: center"">" & tbxHTMLBody.Text & "</div>"
        If Preview = True Then
            Body = "<body style= ""background-color:" & tbxColorFondo.Text & """>" & texto + "<p>" + ImagePreview + "</p></body></html>"
        Else
            Body = "<body style= ""background-color:" & tbxColorFondo.Text & """>" & texto + "<p>" + ImageAdjunto + "</p></body></html>"
        End If
        PreviewFileName = sPath + "\" & tbxCampaignName.Text & Fecha & ".html"
        If Body <> "" Then

            Mensaje = tbxHTMLHead.Text + Body
        End If
        If Preview = True Then
            Try
                My.Computer.FileSystem.WriteAllText(PreviewFileName, Mensaje, False)
                wwwVistaPrevia.Navigate(sPath + "\" & tbxCampaignName.Text & Fecha & ".html")
            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub MensajeEmail()
        '==================Fromacion del Texto HTML a traves de la pestaña pbxMensajeEmail==================================
        Dim texto As String
        texto = tbxMessageBody.Text
        If Preview = True Then
            Body = "<body style= ""background-color:" & tbxColorFondo.Text & """>" & texto + "<p>" + ImagePreview + "</p></body></html>"
        Else
            Body = "<body style= ""background-color:" & tbxColorFondo.Text & """>" & texto + "<p>" + ImageAdjunto + "</p></body></html>"
        End If
        PreviewFileName = sPath + "\" & tbxCampaignName.Text & Fecha & ".html"
        If Body <> "" Then
            Mensaje = "<!DOCTYPE HTML><html>" + Body
        End If
        If Preview = True Then
            Try
                My.Computer.FileSystem.WriteAllText(PreviewFileName, Mensaje, False)
                wwwVistaPrevia.Navigate(sPath + "\" & tbxCampaignName.Text & Fecha & ".html")
            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message, "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
        tbxHTMLBody.Text = Body
        tbxHTMLHead.Text = "<!DOCTYPE HTML><html>"
    End Sub

    Private Sub btnExaminar_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminar.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Fotos en (*.jpg)|*.jpg|Todos(*.*)|*.*|Fotos (*.bmp)|*.bmp|Fotos en (*.png)|*.png|Fotos en (*.jpge)|*.jpge|Fotos en (*.gif)|*.gif|Fotos en (*.pdf)|*.pdf"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            tbxImage.Text = OpenFileDialog.FileName
            'Dim filePath As String = tbxImage.Text
            ImageAdjunto = OpenFileDialog.SafeFileName
            ImagePreview = "<img src=""" & tbxImage.Text & """""cid:Imagen"">"
            ImageAdjunto = "<img src=""cid:Imagen"">"
        End If

        btnColorSel.Focus()
    End Sub

    Private Sub pbxNuevoEmail_Click(sender As System.Object, e As System.EventArgs) Handles pbxNuevoEmail.Click
        Habilitar()
        limpiar()
        tbxCampaignName.Focus()
    End Sub

    Private Sub Habilitar()

        pbxNuevoEmail.Image = My.Resources.NewOff
        pbxNuevoEmail.Cursor = Cursors.Arrow
        pbxEnviarEmail.Enabled = True
        pbxEnviarEmail.Image = My.Resources.SendEmail
        pbxEnviarEmail.Cursor = Cursors.Arrow

        Panel3.Enabled = True
        pnlEmailBody.Enabled = True
        pnlEmailBody.Enabled = True
        pnlPublico.Enabled = True
        pnlHTML.Enabled = True
        pnlEmailBody.BringToFront()

        tbxCampaignName.Enabled = True
        txtAsunto.Enabled = True
        tbxMessageBody.Enabled = True
        btnExaminar.Enabled = True
        btnColorSel.Enabled = True
    End Sub

    Private Sub DesHabilitar()

        pbxNuevoEmail.Image = My.Resources.New_
        pbxNuevoEmail.Cursor = Cursors.Hand
        pbxEnviarEmail.Enabled = True
        pbxEnviarEmail.Image = My.Resources.SendEmailOff
        pbxEnviarEmail.Cursor = Cursors.Hand

        Panel3.Enabled = False
        pnlEmailBody.Enabled = False
        pnlPublico.Enabled = False
        pnlEmailBody.BringToFront()

        pnlHTML.Enabled = False

        tbxCampaignName.Enabled = False
        txtAsunto.Enabled = False
        tbxMessageBody.Enabled = False
        btnExaminar.Enabled = False
        btnColorSel.Enabled = False
    End Sub

    Private Sub pbxGuardarEmail_Click(sender As System.Object, e As System.EventArgs)


        If tbxCampaignName.Text = "" Then
            MessageBox.Show("Ingrese la Descripcion para el Email", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            Exit Sub
        End If
        Existe = F.FuncionConsulta("CODEMAIL", "EMAIL", "CODEMAIL", txtCodEmail.Text)
        If Existe <> "0" Then
            Try
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
                cmd.Connection = sqlc
                cmd.Transaction = myTrans
                If TextoHtml = False Then
                    ActualizaEmail()
                Else
                    Actualizar()
                End If
                ActualizaDetalleEmail()
                myTrans.Commit()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Habilitar()
            Catch ex As Exception
                myTrans.Rollback("Actualizar")
                MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                sqlc.Close()
            End Try
        Else
            Try
                ser.Abrir(sqlc)
                myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Insertar")
                cmd.Connection = sqlc
                cmd.Transaction = myTrans
                If TextoHtml = False Then
                    InsertaEmail()
                Else
                    Insertar()
                End If
                ActualizaDetalleEmail()
                myTrans.Commit()
                MessageBox.Show("El proceso de grabación a finalizado correctamente", "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Habilitar()
                limpiar()
            Catch ex As Exception
                myTrans.Rollback("Insertar")
                MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                sqlc.Close()
            End Try
        End If
        DesHabilitar()
    End Sub

    Sub limpiar()
        txtAsunto.Text = ""
        tbxCampaignName.Text = ""
        tbxMessageBody.Text = ""
        tbxImage.Text = ""
        tbxColorFondo.Text = ""

    End Sub

    Private Sub ActualizaEmail()
        sql = ""
        sql = "update EMAIL SET DESCRIPCION = '" & tbxCampaignName.Text & "', IMAGEN = '" & tbxImage.Text & "'," & _
        " TEXTO = '" & PreviewFileName & "', COLORFONDO = '" & tbxColorFondo.Text & "' " & _
        " WHERE CODEMAIL = " & txtCodEmail.Text & "  "
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Actualizar()
        Try

            sql = ""
            sql = "update EMAIL SET DESCRIPCION = '" & tbxCampaignName.Text & "', IMAGEN = '" & tbxImage.Text & "'," & _
            " TEXTO = '" & PreviewFileName & "', COLORFONDO = '" & tbxColorFondo.Text & "' " & _
            " WHERE CODEMAIL = " & txtCodEmail.Text & "  "
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ActualizaDetalleEmail()
        Dim CodCatCliente, CodEmail As String
        For i = 1 To dgvTipoCliente.Rows.Count
            If IsDBNull(dgvTipoCliente.Rows(i - 1).Cells("DESTIPOCLIENTE1").Value) Then
                CodCatCliente = "Null"
            Else
                CodCatCliente = dgvTipoCliente.Rows(i - 1).Cells("CODTIPOCLIENTE").Value
                CodEmail = txtCodEmail.Text
                Existe = F.FuncionConsulta("CODEMAIL", "DETALLEEMAILTIPOCLIENTE", "CODEMAIL = " & CodEmail & " and CODTIPOCLIENTE", CodCatCliente)
                If Existe = "0" Then
                    sql = ""
                    sql = "INSERT INTO DETALLEEMAILTIPOCLIENTE (CODEMAIL, CODTIPOCLIENTE) VALUES " & _
                    " (" & CodEmail & ", " & CodCatCliente & ")"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
            End If
        Next
    End Sub

    Private Sub InsertaEmail()
        sql = ""
        sql = "INSERT INTO EMAIL (CODEMAIL, DESCRIPCION, IMAGEN, FECGRA, REMITENTE, TEXTO, COLORFONDO, EMPRESA, " & _
        " MUJER, HOMBRE, CODEVENTO, RANGO, CODSMTP) VALUES (" & txtCodEmail.Text & ", '" & tbxCampaignName.Text & "', '" & tbxImage.Text & "', " & _
        " CONVERT(DATETIME, '" & Today & "', 103), NULL, '" & PreviewFileName & "', " & _
        " '" & tbxColorFondo.Text & "', NULL,  NULL , NULL, NULL, NULL, NULL)"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Insertar()
        sql = ""
        sql = "INSERT INTO EMAIL (CODEMAIL, DESCRIPCION, IMAGEN, FECGRA, REMITENTE, TEXTO, COLORFONDO, EMPRESA, " & _
        " MUJER, HOMBRE, CODEVENTO, RANGO, CODSMTP) VALUES (" & txtCodEmail.Text & ", '" & tbxCampaignName.Text & "', '" & tbxImage.Text & "', " & _
        " CONVERT(DATETIME, '" & Today & "', 103), NULL, '" & PreviewFileName & "', " & _
        " '" & tbxColorFondo.Text & "', NULL,  NULL , NULL, NULL, NULL, NULL,NULL)"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub pbxEliminarEmail_Click(sender As System.Object, e As System.EventArgs)

        If txtCodEmail.Text = "" Then
            Exit Sub
        End If
        If MessageBox.Show("¿Esta seguro que quiere eliminar el Email?", "POSEXPRESS", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans
        Try
            EliminarDetalleEmail()
            EliminarEmail()
            myTrans.Commit()
            MessageBox.Show("Email eliminado correctamente", "POSEXPRESS")
            DesHabilitar()
        Catch ex As Exception
            Try
                myTrans.Rollback("Eliminar")
            Catch
                MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

        Finally
            sqlc.Close()
        End Try
    End Sub

    Private Sub EliminarDetalleEmail()
        Dim CodCatCliente As String
        CodCatCliente = dgvTipoCliente.CurrentRow.Cells("CODTIPOCLIENTE").Value
        sql = ""
        sql = "DELETE FROM DETALLEEMAILTIPOCLIENTE WHERE CODEMAIL = " & txtCodEmail.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub EliminarEmail()
        sql = ""
        sql = "DELETE FROM EMAIL WHERE CODEMAIL = " & txtCodEmail.Text & ""
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub pbxEditarEmail_Click(sender As System.Object, e As System.EventArgs)
        Edit = True
        Habilitar()

        Dim objReader As New StreamReader(sPath + "\" & tbxCampaignName.Text & Fecha & ".html")
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        tbxMessageBody.Text = sLine

    End Sub

    Private Sub dgvEmail_SelectionChanged(sender As Object, e As System.EventArgs)

        PreviewFileName = sPath + "\" & tbxCampaignName.Text & Fecha & ".html"
        Try
            My.Computer.FileSystem.WriteAllText(PreviewFileName, Mensaje, False)
            wwwVistaPrevia.Navigate(sPath + "\" & tbxCampaignName.Text & Fecha & ".html")
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message, "POS EXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub pbxCancelarEmail_Click(sender As System.Object, e As System.EventArgs)
        DesHabilitar()
        limpiar()
    End Sub

    Private Sub tbxCampaignName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCampaignName.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtAsunto.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtAsunto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAsunto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            tbxMessageBody.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub tbxImage_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxImage.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            btnExaminar.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub lblError_Click(sender As System.Object, e As System.EventArgs) Handles lblError.Click
        pnlMensajeError.Visible = True
        pnlMensajeError.BringToFront()
        lblMalisError.Text = EmailError
        tbxCadenaError.Text = ErrorCadena
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        pnlMensajeError.Visible = False
    End Sub

    Private Sub btnLinea_Click(sender As System.Object, e As System.EventArgs) Handles btnLinea.Click
        tbxMessageBody.SelectedText = "<hr  size=2>"
    End Sub

    Private Sub btnEstiloColor_Click(sender As System.Object, e As System.EventArgs) Handles btnEstiloColor.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim FontColor = System.Drawing.ColorTranslator.ToHtml(ColorDialog1.Color)
            EstiloColor = "color:" & FontColor & ";"

            Dim a, r, g, b As Integer
            a = ColorDialog1.Color.A
            r = ColorDialog1.Color.R
            g = ColorDialog1.Color.G
            b = ColorDialog1.Color.B

            btnEstiloColor.BackColor = Color.Khaki
        End If
    End Sub

    Private Sub btnEstiloIzq_Click(sender As System.Object, e As System.EventArgs) Handles btnEstiloIzq.Click
        EstiloAling = "text-align: left;"
        btnEstiloIzq.BackColor = Color.Khaki
        btnEstiloCentro.BackColor = Color.Silver
        btnEstiloDer.BackColor = Color.Silver
    End Sub

    Private Sub btnEstiloCentro_Click(sender As System.Object, e As System.EventArgs) Handles btnEstiloCentro.Click
        EstiloAling = "text-align: center;"
        btnEstiloIzq.BackColor = Color.Silver
        btnEstiloCentro.BackColor = Color.Khaki
        btnEstiloDer.BackColor = Color.Silver
    End Sub

    Private Sub btnEstiloDer_Click(sender As System.Object, e As System.EventArgs) Handles btnEstiloDer.Click
        EstiloAling = "text-align: right;"
        btnEstiloIzq.BackColor = Color.Silver
        btnEstiloCentro.BackColor = Color.Silver
        btnEstiloDer.BackColor = Color.Khaki
    End Sub

    Private Sub btAplicarEstilos_Click(sender As System.Object, e As System.EventArgs) Handles btAplicarEstilos.Click
        btnEstiloIzq.BackColor = Color.Silver
        btnEstiloCentro.BackColor = Color.Silver
        btnEstiloDer.BackColor = Color.Silver
        btnEstiloColor.BackColor = Color.Silver

        Me.tbxMessageBody.SelectedText = "<p style = """ & EstiloAling & EstiloColor & """> TextoConEstilo </p>"
    End Sub

    Private Sub cmbSexo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSexo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cmbListaPrecio.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbListaPrecio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbListaPrecio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            Button1.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbMesDesde_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMesDesde.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cmbMesHasta.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbMesHasta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMesHasta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cmbSexo.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbDiaDesde_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDiaDesde.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cmbDiaHasta.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbDiaHasta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDiaHasta.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            cmbMesDesde.Focus()
        End If

        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As Object, e As EventArgs) Handles BuscarTextBox.TextChanged
        CLIENTESMTKBindingSource.Filter = "NOMBRE LIKE '%" & BuscarTextBox.Text & "%' OR EMAIL LIKE '%" & BuscarTextBox.Text & "%'"
    End Sub

    Private Sub dgvListaCliente_SelectionChanged(sender As Object, e As EventArgs) Handles dgvListaCliente.SelectionChanged
        'selectedCellCount = dgvListaCliente.GetCellCount(DataGridViewElementStates.Selected)

        'If selectedCellCount > 0 Then

        '    If dgvListaCliente.AreAllCellsSelected(True) Then
        '    Else

        '        Dim sb As New System.Text.StringBuilder()

        '        Dim i As Integer
        '        For i = 0 To selectedCellCount - 1

        '            sb.Append("Row: ")
        '            sb.Append(dgvListaCliente.SelectedCells(i).RowIndex.ToString())
        '            sb.Append(", Column: ")
        '            sb.Append(dgvListaCliente.SelectedCells(i).ColumnIndex.ToString())
        '            sb.Append(Environment.NewLine)

        '        Next i

        '        sb.Append("Total: " + selectedCellCount.ToString())
        '        'MessageBox.Show(sb.ToString(), "Selected Cells")

        '    End If

        'End If
    End Sub
End Class