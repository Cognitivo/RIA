Partial Class DsPagos

#Region "Nested Types"

    Partial Class CODIGOSDataTable

#Region "Methods"

        Private Sub CODIGOSDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DESPRODUCTOColumn.ColumnName) Then
                'Add user code here
            End If
        End Sub

#End Region 'Methods

    End Class

#End Region 'Nested Types

End Class

Namespace DsPagosTableAdapters

    Partial Class RELACIONCOMPRAORDENCOMPRATableAdapter

    End Class

    Partial Class CODIGOSTableAdapter

    End Class

    Partial Public Class COMPRASTableAdapter
    End Class

End Namespace

