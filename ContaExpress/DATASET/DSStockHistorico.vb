Partial Class DSStockHistorico
End Class

Namespace DSStockHistoricoTableAdapters

    Partial Class StockHistSimpleTableAdapter

        Public ReadOnly Property SelectCommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class

End Namespace
