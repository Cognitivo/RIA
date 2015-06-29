Partial Class DsInfContabilidad

End Class
Namespace DsInfContabilidadTableAdapters

    Partial Class LibroIvaTicketTableAdapter

    End Class

    Partial Class HISTORICOLIBROMAYOTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
    Partial Class SaldoAnteriorTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
End Namespace
