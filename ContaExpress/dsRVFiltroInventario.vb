

Namespace dsRVFiltroInventarioTableAdapters
    Partial Class RICostoPromedioTableAdapter

        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class

    Partial Class RVFISTOCKAUNAFECHATableAdapter

        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
   
    Partial Class RIListadoCostoTableAdapter
        Inherits System.ComponentModel.Component

        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class

    Partial Class RIStockActualTableAdapter
        Inherits System.ComponentModel.Component

        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class

End Namespace

Partial Class dsRVFiltroInventario
    Partial Class RVFISTOCKAUNAFECHADataTable

        Private Sub RVFISTOCKAUNAFECHADataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.CODSUCURSALColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
