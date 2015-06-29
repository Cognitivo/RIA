Partial Class dsOrdenTrabajo
    Partial Class DETPC_OTDataTable

        Private Sub DETPC_OTDataTable_DETPC_OTRowChanging(sender As System.Object, e As DETPC_OTRowChangeEvent) Handles Me.DETPC_OTRowChanging

        End Sub

    End Class

End Class

Namespace dsOrdenTrabajoTableAdapters
    Partial Class ORDENTRABAJOCONSULTATableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property

        Public ReadOnly Property insertcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
End Namespace

