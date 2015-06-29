Namespace DsRVClientesTableAdapters
    Partial Class RVListaClientesTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class

End Namespace
Partial Class DsRVClientes
    Partial Class RVListaClientesDataTable

        Private Sub RVListaClientesDataTable_RVListaClientesRowChanging(sender As System.Object, e As RVListaClientesRowChangeEvent) Handles Me.RVListaClientesRowChanging

        End Sub

    End Class

End Class
