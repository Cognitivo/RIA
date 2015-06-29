Partial Class DsFacturacionCompleja
    Partial Class VENTASDataTable

        Private Sub VENTASDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.TOTALEXENTAColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace DsFacturacionComplejaTableAdapters

    Partial Class CODIGOSTableAdapter

    End Class

    Partial Public Class SUCURSALTableAdapter
    End Class
End Namespace

Namespace DsFacturacionComplejaTableAdapters

    Partial Public Class CODIGOSTableAdapter
    End Class
End Namespace
