

Partial Public Class DsMassEmailing
End Class

Namespace DsMassEmailingTableAdapters
    Partial Public Class CLIENTESMKTTableAdapter
        Inherits System.ComponentModel.Component
        Public ReadOnly Property selectcommand() As System.Data.SqlClient.SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property
    End Class
End Namespace
