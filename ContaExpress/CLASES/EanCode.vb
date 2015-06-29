Public Class EanCode
    Public Function EAN13(ByVal value As String) As String
        Dim tableAB(,) As Integer = New Integer(,) {{0, 0, 0, 0, 0, 0}, {0, 0, 1, 0, 1, 1}, _
                                                    {0, 0, 1, 1, 0, 1}, {0, 0, 1, 1, 1, 0}, _
                                                    {0, 1, 0, 0, 1, 1}, {0, 1, 1, 0, 0, 1}, _
                                                    {0, 1, 1, 1, 0, 0}, {0, 1, 0, 1, 0, 1}, _
                                                    {0, 1, 0, 1, 1, 0}, {0, 1, 1, 0, 1, 0}}
        Dim result As String = value.Substring(0, 1)
        Dim first As Integer = Convert.ToInt32(result)
        Dim check As Integer = first
        Dim digit As Integer = 0
        Dim i As Integer = 1
        Dim r As Integer
        Do While (i <= 6)
            digit = Convert.ToInt32(value.Substring(i, 1))
            If i Mod 2 = 0 Then
                r = 1
            Else
                r = 3
            End If
            check = (check + (digit * (r)))

            result = (result + CType(ChrW((65 + (digit + (tableAB(first, (i - 1)) * 10)))), Char))
            i = (i + 1)
        Loop

        result = (result + "*")

        i = 7
        Do While (i < 12)
            digit = Convert.ToInt32(value.Substring(i, 1))
            If i Mod 2 = 0 Then
                r = 1
            Else
                r = 3
            End If
            check = (check + (digit * (r)))
            result = (result + CType(ChrW((97 + digit)), Char))
            i = (i + 1)
        Loop

        digit = ((10 - (check Mod 10)) Mod 10)
        result = (result + CType(ChrW((97 + digit)), Char))
        result = (result + "+")
        Return result
    End Function
End Class
