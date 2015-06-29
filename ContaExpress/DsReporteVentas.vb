Namespace DsReporteVentasTableAdapters

    Partial Class ListadereciboTableAdapter

    End Class

    Partial Class PorcentajedeventaTableAdapter

    End Class

    Partial Class VentasResumenTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class VentasDetalladoTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class NotaCreditoDetalladoTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
End Namespace

Partial Class DsReporteVentas

    Partial Class LibroVentasLeyDataTable

        Private Sub LibroVentasLeyDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DIAVENTAColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class


End Class
