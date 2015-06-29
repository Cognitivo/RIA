Namespace DsReportesAuditoriaTableAdapters
    Partial Class AVentasAprobadasTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
End Namespace

Partial Class DsReportesAuditoria
   
End Class
