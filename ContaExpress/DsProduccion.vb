Partial Class DsProduccion
    Partial Class PRODUCTOSDataTable

        Private Sub PRODUCTOSDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DESPRODUCTOColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace DsProduccionTableAdapters
    
    Partial Public Class AjustesHistoricoStockTableAdapter
    End Class
End Namespace
