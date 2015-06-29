


Partial Public Class DsPlantillasConta
    Partial Class AsientosDataTable

        Private Sub AsientosDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.NUMASIENTOColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class ReAsentarComprasDataTable

        Private Sub ReAsentarComprasDataTable_ReAsentarComprasRowChanging(sender As System.Object, e As ReAsentarComprasRowChangeEvent) Handles Me.ReAsentarComprasRowChanging

        End Sub

    End Class

    Partial Class PARAASENTARCAB_COMPRASDataTable


        Private Sub PARAASENTARCAB_COMPRASDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.RegistroIDColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class plancuentasDataTable

    End Class

End Class

Namespace DsPlantillasContaTableAdapters
       Partial Class PARAASENTARCAB_COMPRASTableAdapter

    End Class

    Partial Class ReAsentarCobrosTableAdapter

    End Class


End Namespace

Namespace DsPlantillasContaTableAdapters

    Partial Public Class PARAASENTARCAB_COMPRASTableAdapter
    End Class
End Namespace
