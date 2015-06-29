Public Class Link
    Dim permiso As Double
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        'This is a Simple Test
        LinkBrowser.Refresh()
    End Sub

    Private Sub Link_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'permiso = PermisoAplicado(UsuCodigo, 147)
        'If permiso = 0 Then
        '    MessageBox.Show("Usted no tiene permiso para abrir en esta ventana", "Pos Express")
        '    Me.Close()
        'End If
    End Sub
End Class