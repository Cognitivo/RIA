Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class ImprimirCheque

    Sub Imprimir_Cheque(FechaEmisión As String, FechaDiferido As String, Total As Decimal, Concepto As String, Proveedor As String)
        MessageBox.Show(FechaEmisión, "Fecha Emision")
        MessageBox.Show(FechaDiferido, "Fecha Diferido")
        MessageBox.Show(Total, "Total")
        MessageBox.Show(Concepto, "Concepto")
        MessageBox.Show(Proveedor, "Proveedor")
    End Sub
End Class
