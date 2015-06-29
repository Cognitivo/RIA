Namespace DSReporteComprasTableAdapters

    Partial Class GastosPorProductoTableAdapter

    End Class

    Partial Class ComprasPorSucursalTableAdapter

    End Class

    Partial Class ComprasAprobadasTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class RCIVANCLEYTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class RCIVACOMPRASTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class RCIVALEYTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
End Namespace
Partial Class DSReporteCompras
    Partial Class COGSDetalladoDataTable

        Private Sub COGSDetalladoDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DESPRODUCTOColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class ComprasPorProductoDataTable

        Private Sub ComprasPorProductoDataTable_ComprasPorProductoRowChanging(sender As System.Object, e As ComprasPorProductoRowChangeEvent) Handles Me.ComprasPorProductoRowChanging

        End Sub

    End Class

End Class
