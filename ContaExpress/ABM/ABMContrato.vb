Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class ABMContrato

    Private Sub ABMContrato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        wwwContrato.Navigate("http://www.cogentpotential.com/contrato.html")

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click



    End Sub
End Class