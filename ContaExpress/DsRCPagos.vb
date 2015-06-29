Namespace DsRCPagosTableAdapters
    Partial Class RCPendientePagoDifTableAdapter

    End Class
    Partial Class RCRetencionesTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class RCNotasCreditoTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class RCRECIBOSPROVEEDORDETTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class RCFacturasXReciboTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class RCPagosProveedorTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class RCCOMPRASLISTATableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
End Namespace

Partial Class DsRCPagos
    Partial Class RCMovimientosProveedorDataTable

        Private Sub RCMovimientosProveedorDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.NRORECIBOColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

