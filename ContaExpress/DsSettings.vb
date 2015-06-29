Partial Class DsSettings
    Partial Class PERMISOUSUARIONUEVODataTable

        Private Sub PERMISOUSUARIONUEVODataTable_PERMISOUSUARIONUEVORowChanging(sender As System.Object, e As PERMISOUSUARIONUEVORowChangeEvent) Handles Me.PERMISOUSUARIONUEVORowChanging

        End Sub

    End Class

    Partial Class USUARIODataTable

        Private Sub USUARIODataTable_USUARIORowChanging(sender As System.Object, e As USUARIORowChangeEvent) Handles Me.USUARIORowChanging

        End Sub

    End Class

    Partial Class PERMISOSUSUARIOSDataTable

        'Private Sub PERMISOSUSUARIOSDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
        '    If (e.Column.ColumnName = Me.Usuario_id) Then
        '        'Add user code here
        '    End If

        'End Sub

    End Class

    Partial Class TIPOCOMPROBANTEDataTable

        Private Sub TIPOCOMPROBANTEDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.FORMAIMPRESIONColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace DsSettingsTableAdapters
    
    Partial Class PERMISOUSUARIONUEVOTableAdapter

    End Class

    Partial Public Class PERMISOSUSUARIOSTableAdapter
    End Class
End Namespace

Namespace DsSettingsTableAdapters

    Partial Public Class USUARIOTableAdapter
    End Class
End Namespace
