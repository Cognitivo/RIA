Public Class ProyectosV2


    Private Sub ProyectosV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsEventos.EVENTO' Puede moverla o quitarla según sea necesario.
        Me.EVENTOTableAdapter.Fill(Me.DsEventos.EVENTO)

    End Sub
End Class