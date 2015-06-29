#Region "Header"

' -------------------------------------------------------------------------------
' FUNCION:  CLASE PARA MANEJO DE CADENAS.
' AUTOR:    CARLOS HUMBERTO BARDALES CASTAÑEDA
' FECHA:    25/01/2003.
' E-MAIL:   BARDASOFT@YAHOO.COM
' -------------------------------------------------------------------------------
'IniciaCon         Devuelve si el texto inicia con una subcadena XX
'TerminaCon        Devuelve si el texto termina con una subcadena Xx
'Ancho             Devuelve el largo en bytes del texto.
'PosIni            Posicion de la primera ocurrencia de una Subcad.
'PosEnd            Posicion de la ultima ocurrencia de una Subcad.
'Insertar          Inserta una subcadena, con soporte de desplazamiento y truncado.
'Truncar           Devuelve una subcadena truncada al ancho indicado.
'AlinearIzq        Devuelve una cadena alineada a la izquierda, con WildCards
'AlinearDer        Devuelve una cadena alineada a la derecha, con WildCards
'Centrar           Devuelve una cadena alineada al centro, con WildCards
'Replicate         Devuelve un Caracter replicado XX veces.
'Remover           Remueve x bytes de una cadena, a partir de x posicion
'QuitarCad         Remueve todas las ocurrencias de la Subcadena.
'Amplia            Devuelve una cadena, con un caracter separador entre cada byte
'Reemplazar        Reemplaza todas las ocurrencias de la Subcadena.
'Divide            Divide una Cadena, con un separador especifico.
'Divide2           Divide una cadena, con soporte de corchetes entre subcadenas
'Extrae            Extrae una Subcadena, a partir de xx posicion, y XX bytes.
'Izquierda         Extrae xx bytes a la izquierda de la cadena.
'Derecha           Extrae xx bytes, a la derecha de la cadena
'Minusculas        Convierte a minusculas toda la cadena.
'Mayusculas        Convierte a mayusculas toda la cadena.
'Frase             Convierte a Mayusculas las primeras letras de cada palabra.
'LTrim             Elimina espacios en blanco a la izquierda de una cadena.
'RTrim             Elimina espacios en blanco a la derecha de una cadena.
'AllTrim           Elimina espacios en blanco a ambos lados de la cadena.
'Blancos           Elimina todos los espacios en blanco, dentro y fuera de la cadena.
'Contiene          Verifica si una subcadena esta contenido en la cadena.
'Compara           Verifica si la cadena es igual a la subcadena indicada.
'AscII             Devuelve el código AscII del caracter xx dentro de la cadena.
'txtLIKE           Verifica si la subcadena se parece a la cadena.
'Inverso           Devuelve la cadena inversa
'Soundex           Devuelve el código fonético de la cadena, para hacer comparaciones y busquedas.,
'SinAcentos        Devuelve una cadena, sin palabras acentuadas (mayusculas y minusculas)
'ContarCad         Cuenta el numero de veces que aparece una cadena dentro de otra
'Encripta          Encripta el contenido de la cadena.
'Descripta         Descripta una cadena encriptada previamente.
'EncrypKey         Encripta con un password.
'DecrypKey         Des-cripta con un password.
'EncodeBase64      Encripta con el algoritmo Base64
'DecodeBase64      Des-Encripta con el algoritmo Base64
'GetDelimited      Extrae un texto delimitado dentro de la cadena.
'FilterDup         Elimina los caracteres duplicados en una cadena
'MayorCad          Ordena la cadena de mayor a menor valor ASCII
'MenorCad          Ordena la cadena de menor a mayor valor ASCII
'OrdenaAsc         Ordena la cadena en forma ascendente
'OrdenaDesc        Ordena la cadena en forma descendente
'Palabras          Cuenta el numero de palabras de la cadena con soporte de signos
'StripControlChars Elimina todos los caracteres de control de una cadena
'GetTokenIdx       Retorna una subcadena que se encuentra despues de la cadena indicada
'QuitarEspaciosDup Elimina los espacios duplicados dentro de una cadena
'CheckNumeric      Verifica si una cadena tiene formato de numero
'FilterString      Filtra una cadena a solo los caracteres indicados.
'SoloAlfanumerico  Devuelve una cadena sòlo con caracteres alfanumericos
'SoloNumeros       Devuelve una cadena sólo con caracteres numericos
'CountLineas       Retorna el numero de lineas dentro de un string
'GetLineString     Retorna el string que ocupa la linea xxx dentro de la cadena
'ConcatenaStrings  Concatena un array de objetos, en un string
'ConcatenaStrings2 Concatena un array de solo strings, en un string
'IsStringLower     Verifica si el string contiene solo minusculas
'IsStringUpper     Verifica si la cadena contiene solo mayusculas
'IsControl         Verifica si el caracter de una cadena es un caracter de control
'IsDigit           Verifica si el caracter de una cadena es un digito
'IsLetter          Verifica si el caracter de una cadena es una letra
'IsLetterOrDigit   Verifica si el caracer de una cadena es numero o letra
'IsCharLower       Verifica si el caracter de una cadena es minuscula
'IsCharNumber      Verifica si el caracter de la cadena es un numero
'IsCharPuntuacion  Verifica si el caracter de la cadena es signo de puntuacion
'IsCharSeparator   Verifica si el caracter de la cadena es un separador
'IsCharSymbol      Verifica si el caracter de la cadena es un simbolo
'IsCharUpper       Verifica si el caracter de la cadena es mayuscula
'IsCharWhite       Verifica si el caracter de la cadena es un espacio en blanco
'CleanAmpersand    Limpiar los caracteres & de una cadena
'CleanQuotes       Reemplaza "" por apostrofes simples
'ContainsAlpha     Verifica si existe un caracteres alfanumerico en la cadena
'CountDelimitedWords Cuenta el numero de palabras entre delimitadores
'CountOccurrences  Cuenta el numero de ocurrencias de un string dentro de otro
'CountWords        Cuenta el numero de palabras en un string (separados por espacios)
'EncloseString     Agrega los caracteres indicados al principio y al final del string
'GetRandomPassword Retorna un password aleatoreo
'GetDelimitedWord  Devuelve la cadena que se encuentra dentro del limitador indicado
'NumberSuffix      Convierte un numero en su respectivo formato de orden: 1st, 2nd, etc.
'TextToHTML        Convierte el texto a su formato de HTML
'CalculaFechaAnterior Recibe una fecha en forma de cadena y retorna la fecha del mes anterior en cadena -----'Función César Gte Gral
' ------------------------------------------------------------------------------

#End Region 'Header

Imports System
Imports System.Collections.Generic
Imports System.Math
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Imports Microsoft.VisualBasic
Imports System.ComponentModel

Public Class Cadenas


#Region "Enumerations"

    Enum FormatColumnAlignment
        Left
        Center
        Right
    End Enum

#End Region 'Enumerations

#Region "Methods"

    ' -------------------------------------------------------------
    ' ALINEA A LA DERECHA UNA CADENA, RELLENANDO CON UN CARACTER XX
    ' -------------------------------------------------------------
    Public Shared Function AlinearDer(ByVal cadena As String, ByVal car As Char, _
        ByVal tam As Integer) As String
        Return cadena.PadRight(tam, car)
    End Function

    ' -------------------------------------------------------------
    ' ALINEA A LA izquierda UNA CADENA, RELLENANDO CON UN CARACTER XX
    ' -------------------------------------------------------------
    Public Shared Function AlinearIzq(ByVal cadena As String, ByVal car As Char, _
        ByVal tam As Integer) As String
        Return cadena.PadLeft(tam, car)
    End Function

    ' -------------------------------------------------------------
    ' ELIMINA ESPACIOS A LOS LADOS
    ' -------------------------------------------------------------
    Public Shared Function AllTrim(ByVal MiCadena As String) As String
        Return MiCadena.Trim
    End Function

    '----------------------------------------------------
    ' DEVUELVE UNA CADENA CON EL CARACTER INSERTADO
    ' amliar("TITULO","-") = "T-I-T-U-L-O"
    '----------------------------------------------------
    Public Shared Function Amplia(ByVal miCadena As String, Optional ByVal cad2 As String = " ") As String
        Dim nPos As Integer
        Dim Cad3 As String = ""

        For nPos = 0 To miCadena.Length - 1
            Cad3 += miCadena.Substring(nPos, 1) & cad2
        Next

        Return Cad3 & miCadena.Substring(miCadena.Length, 1)
    End Function

    '----------------------------------------------------
    ' DEVUELVE EL LARGO DE UNA CADENA
    '----------------------------------------------------
    Public Shared Function Ancho(ByVal cadena As String) As Long
        Return cadena.Length
    End Function

    '----------------------------------------------------
    ' Devuelve el número Ascii/ansi del carácter indicado.
    ' BASE 1:
    '----------------------------------------------------
    Public Shared Function Ascii(ByVal MiCadena As String, Optional ByVal Cual As Integer = 1) As Integer
        Return AscW(MiCadena.Substring(Cual - 1, 1))
    End Function

    '-------------------------------------------------------------
    ' ELIMINAR LOS CARACTERES BLANCOS DENTRO Y FUERA DE UNA CADENA
    '-------------------------------------------------------------
    Public Shared Function Blancos(ByVal miCadena As String) As String
        Dim nuevaCadena As String
        Dim cad As Char
        Dim cadena As String = ""

        nuevaCadena = miCadena.Trim()  'eliminar blancos fuera de la cadena

        For Each cad In nuevaCadena
            If cad <> " " Then
                cadena += cad
            End If
        Next

        Return cadena
    End Function

    Public Shared Function CalculaFechaAnterior(ByVal fecha As String) As String
        'Función César Gte Gral
        Dim mes As String
        mes = (Today.Month - 1).ToString
        If mes.Length = 1 Then
            mes = "0" + mes
        End If
        fecha = Today.Day.ToString + "/" + mes + "/" + Today.Year.ToString
        Return fecha
    End Function

    ' ------------------------------------------------------------
    ' convert a string to camel case
    ' for example: CamelCase("new file name") => "NewFileName"
    ' ------------------------------------------------------------
    Public Shared Function CamelCase(ByVal Text As String) As String
        ' convert all non-alphanumeric chars to spaces
        For i As Integer = Len(Text) To 1 Step -1
            If InStr(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", Mid$(Text, i, 1), _
                vbTextCompare) = 0 Then
                Mid$(Text, i, 1) = " "
            End If
        Next
        ' convert the string to proper case, and filter out all spaces
        CamelCase = Replace(StrConv(Text, VbStrConv.ProperCase), " ", "")
    End Function

    '------------------------------------------------------
    ' JUSTIFICA LA CADENA CENTRADA, CON EL CARACTER INDICADO
    '------------------------------------------------------
    Public Shared Function Centrar(ByVal cadena As String, ByVal nLargo As Integer) As String
        Return Centrar(cadena, nLargo, " ")
    End Function

    Public Shared Function Centrar(ByVal cadena As String, ByVal nLargo As Integer, ByVal Cad2 As String) As String
        Dim nNum As Integer
        If nLargo < cadena.Length + 2 Then
            Return cadena
        End If
        nNum = Convert.ToInt32(Round(((nLargo - cadena.Length) / 2), 0))
        Return StrDup(nNum, Cad2) & cadena & StrDup(nNum, Cad2)
    End Function

    ' -----------------------------------------------------------------
    ' VERIFICA SI EL TEXTO ES UN NUMERO
    ' -----------------------------------------------------------------
    Public Shared Function CheckNumeric(ByRef text As String, ByRef DecValue As Boolean) As Boolean
        Dim i As Integer
        Dim decSep As String
        ' retrieve the decimal separator symbol
        decSep = Format(0.1, ".")
        For i = 1 To Len(text)
            Select Case Mid(text, i, 1)
                Case "0" To "9"
                Case "-", "+"
                    ' minus/plus sign are only allowed
                    ' as leading chars
                    If i > 1 Then Exit Function
                Case decSep
                    ' exit if decimal values not allowed
                    If Not DecValue Then Exit Function
                    ' only one decimal separator is allowed
                    If InStr(text, decSep) < i Then Exit Function
                Case Else
                    ' reject all other characters
                    Exit Function
            End Select
        Next
        Return True
    End Function

    '----------------------------------------------------------------------
    ' When placing text in a control's Caption property, an ampersand
    ' displays as an underline to denote a hot-key. For example, setting
    ' a caption to "Crumb&Assoc." causes the A in "Assoc." to appear
    ' as a hotkey. This function doubles every ampersand character in the
    ' input string to remove the character's special meaning.
    ' Arguments : stringIn - The string to clean
    ' Returns   : The cleaned string
    '----------------------------------------------------------------------
    Public Shared Function CleanAmpersand(ByVal stringIn As String) As String
        Return stringIn.Replace("&", "&&")
    End Function

    '--------------------------------------------------------------------
    ' Coverts double-quote (") characters in a string to apostrophes
    ' ('). This function is useful when using strings as SQL strings.
    ' Arguments : stringIn - The string to clean
    ' Returns   : The cleaned string
    '--------------------------------------------------------------------
    Public Shared Function CleanQuotes(ByVal stringIn As String) As String
        Return stringIn.Replace(Chr(34), "'")
    End Function

    '----------------------------------------------------
    ' VERIFICA SI UNA CADENA ES IGUAL A OTRA
    '----------------------------------------------------
    Public Shared Function Compara(ByVal Cadena1 As String, ByVal cadena2 As String) As Boolean
        Return Cadena1.Equals(cadena2)
    End Function

    '----------------------------------------------------------------------
    'CONCATENA UN ARRAY DE STRINGS, EL PRIMER ARGUMENTO ES EL SEPARADOR
    '----------------------------------------------------------------------
    Public Shared Function ConcatenaStrings(ByVal sep As String, ByVal ParamArray args() As _
        Object) As String
        Dim builder As New System.Text.StringBuilder
        ' add each item of the input array to the StringBuilder's string
        Dim o As Object
        For Each o In args
            If builder.Length > 0 Then
                ' add the separator if this is not the first item we add
                builder.Append(sep)
            End If
            builder.Append(o)
        Next
        ' return the final string
        Return builder.ToString()
    End Function

    '----------------------------------------------------------------------
    'CONCATENA UN ARRAY DE STRINGS, EL PRIMER ARGUMENTO ES EL SEPARADOR
    'si todos los argumentos son strings, esta funcion es mas rapida
    '----------------------------------------------------------------------
    Public Shared Function ConcatenaStrings2(ByVal sep As String, ByVal ParamArray args() As String) As String
        Return String.Join(sep, args)
    End Function

    '-------------------------------------------------------------
    ' Determines if there are alpha characters other than "-"
    ' in the supplied string
    ' Arguments : stringIn - The string to check
    ' Returns   : True if the string contains alpha characters other
    '             than "-" or " ", False otherwise
    '-------------------------------------------------------------
    Public Shared Function ContainsAlpha(ByVal stringIn As String) As Boolean
        Dim counter As Integer
        Dim tempChar As String
        Dim hasAlpha As Boolean = False
        ' Loop through the string
        For counter = 0 To stringIn.Length - 1
            tempChar = stringIn.Substring(counter, 1)
            If tempChar >= "0" And tempChar <= "9" Then
                ' The character is numeric, so continue.
            Else
                If tempChar <> "-" And tempChar <> " " Then
                    hasAlpha = True
                    Exit For
                End If
            End If
        Next counter
        Return hasAlpha
    End Function

    Public Shared Function ContainsNumeric(ByVal stringIn As String) As Boolean
        Dim counter As Integer
        Dim tempChar As String
        Dim hasNumeric As Boolean = False
        ' Loop through the string
        For counter = 0 To stringIn.Length - 1
            tempChar = stringIn.Substring(counter, 1)
            If tempChar >= "0" And tempChar <= "9" Then
                hasNumeric = True
                Exit For
            Else
                If tempChar <> "-" And tempChar <> " " Then

                    hasNumeric = False
                End If
            End If
        Next counter
        Return hasNumeric
    End Function

    ''' <summary>
    ''' CUENTA EL NUMERO DE APARICIONES DE LA SUBCADENA
    ''' BASE 1:
    ''' </summary>
    ''' <param name="miCadena"></param>
    ''' <param name="search"></param>
    ''' <param name="start"></param>
    ''' <param name="Compare"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ContarCad(ByVal miCadena As String, ByVal search As String, ByVal start As Integer, ByVal Compare As CompareMethod) As Integer
        Dim i As Integer, result As Integer
        start = start - 1  'convertir a base 1
        i = InStr(start, miCadena, search, Compare)
        Do While i > 0
            result = result + 1
            i = InStr(i + 1, miCadena, search, Compare)
        Loop
        Return result
    End Function

    Public Shared Function ContarCad(ByVal miCadena As String, ByVal search As String) As Integer
        Return ContarCad(miCadena, search, 1, CompareMethod.Binary)
    End Function

    Public Shared Function ContarCad(ByVal miCadena As String, ByVal search As String, ByVal start As Integer) As Integer
        Return ContarCad(miCadena, search, start, CompareMethod.Binary)
    End Function

    ' -------------------------------------------------------------
    ' VERIFICA SI UNA CADENA ESTA CONTENIDA DENTRO DE OTRA
    ' -------------------------------------------------------------
    'TODO: Eliminar esta función innecesaria
    Public Shared Function Contiene(ByVal subcadena As String, ByVal cadOrigen As String) As Boolean
        'Return IIf(cadOrigen.IndexOf(subcadena) = -1, False, True)
        Return cadOrigen.Contains(subcadena)
    End Function

    ' -------------------------------------------------------------
    ' change a sentence in CamelCase to a sentence with spaces
    ' for example ConvertCamelCase("FileExchange") => "File Exchange"
    ' -------------------------------------------------------------
    Public Shared Function ConvertCamelCase(ByVal Value As String) As String
        Dim newValue As String
        Dim i As Integer

        newValue = Value.Trim()
        i = 1

        ' If the character is uppercase, then insert a space before
        While i <= newValue.Length
            If IsCharUpper(newValue, i) Then
                newValue = newValue.Substring(0, i) & " " & newValue.Substring(i + 2)
                i += 1
            End If

            i += 1
        End While

        Return newValue
    End Function

    ' ----------------------------------------------------------
    'convert a reversed full name back to the "FirstName LastName" format
    ' for example, ConvertReverseFullName("Smith, John A.") ==> "John A. Smith"
    ' ----------------------------------------------------------
    Public Shared Function ConvertReverseFullName(ByVal ReverseFullName As String) As String
        Dim i As Integer
        ReverseFullName = ReverseFullName.Trim()
        i = InStr(ReverseFullName, ",")
        If i = 0 Then
            ' no comma, just return the argument
            ConvertReverseFullName = ReverseFullName
        Else
            ' exchange first and last name
            ConvertReverseFullName = Mid$(ReverseFullName, i + 1) & " " & Left$(ReverseFullName, i - 1)
        End If
    End Function

    ' ----------------------------------------------------
    ' Returns the number of words in a delimited string
    ' Arguments : stringIn - The string to count words in
    '             delimitChar - The character that delimits words
    ' Returns   : The number of occurrences
    ' ----------------------------------------------------
    Public Shared Function CountDelimitedWords( _
        ByVal stringIn As String, _
        ByVal delimitChar As String) As Integer
        Dim wordCount As Integer = 1
        Dim position As Integer
        ' Find the first occurence
        position = stringIn.IndexOf(delimitChar)
        Do While position > 0
            ' Increment the word counter
            wordCount = wordCount + 1
            position = stringIn.IndexOf(delimitChar, position + 1)
        Loop
        Return wordCount
    End Function

    '----------------------------------------------------------------------
    'RETORNA EL NUMERO DE LINEAS DE UNA CADENA
    '----------------------------------------------------------------------
    Public Shared Function CountLineas(ByVal tcString As String) As Integer
        If tcString.Trim().Length = 0 Then
            Return 0
        Else
            Return ContarCad(tcString, vbCr) + 1
        End If
    End Function

    '------------------------------------------------------------
    ' Returns the number of times a string appears in a string
    ' Arguments : stringIn - The string to search in
    '             searchFor - The string to search for
    ' Returns   : The number of occurrences
    '------------------------------------------------------------
    Public Shared Function CountOccurrences( _
        ByVal stringIn As String, _
        ByVal searchFor As String) As Integer
        Dim position As Integer
        Dim wordCount As Integer
        ' Find the first occurrence
        position = stringIn.IndexOf(searchFor)
        If position > 0 Then
            wordCount = 1
        End If
        Do While position > 0
            ' Find remaining occurrences
            position = stringIn.IndexOf(searchFor, position + 1)
            If position > 0 Then
                ' Increment the hit counter
                wordCount = wordCount + 1
            End If
        Loop
        Return wordCount
    End Function

    ' ------------------------------------------------------
    ' Returns the number of words seperated by spaces
    ' Arguments : stringIn - The string to count words in
    ' Returns   : The number of words
    ' ------------------------------------------------------
    Public Shared Function CountWords(ByVal stringIn As String) As Integer
        Dim wordCount As Integer
        Dim counter As Integer
        Dim isSpace As Boolean = True
        ' Walk through the entire string
        For counter = 0 To stringIn.Length - 1
            ' Determine if we are on a space
            If stringIn.Substring(counter, 1) = " " Then
                isSpace = True
            Else
                If isSpace Then
                    isSpace = False
                    ' Increment the hit counter
                    wordCount = wordCount + 1
                End If
            End If
        Next counter
        Return wordCount
    End Function

    Public Shared Function DecodeBase64(ByVal input As String) As String
        Dim strBytes() As Byte = System.Convert.FromBase64String(input)
        Return System.Text.Encoding.UTF8.GetString(strBytes)
    End Function

    ' ----------------------------------------------
    ' DESCRIPTA UNA CADENA QUE TIENE PASSWORD
    ' ----------------------------------------------
    Public Shared Function DeCryptKey(ByVal PstrText As String, ByVal pstrPass As String) As String
        Dim intpasslen As Integer
        Dim inttextlen As Integer
        Dim k As Integer
        Dim i As Integer
        Dim strdrypt As String = ""
        Dim cb As Integer

        intpasslen = pstrPass.Length

        For i = 1 To intpasslen
            k = k + (Asc(Mid(pstrPass, i, 1)) * i)
            If k > 255 Then k = k - 255 'Get Key
        Next i
        Do While k > 255
            k = k - 255
        Loop

        inttextlen = Len(PstrText)
        For i = 1 To inttextlen
            cb = Asc(Mid(PstrText, i, 1)) - k 'Change Current Byte
            If cb < 0 Then cb = cb + 255
            strdrypt = strdrypt + Chr(cb)
            k = k + Asc(Mid(PstrText, i, 1))
            If k > 255 Then k = k - 255 'Update Key
        Next i

        Return strdrypt 'Return ResulStrDecrpt
    End Function

    ' -------------------------------------------------------------
    ' EXTRAE UNA SUBCADENA DE LA CADENA, A PARTIR DE LA DERECHA
    ' -------------------------------------------------------------
    'TODO: eliminar función innecesaria
    Public Shared Function Derecha(ByVal MiCadena As String, ByVal cuantos As Integer) As String
        Return Right(MiCadena, cuantos)
    End Function

    '------------------------------------------------------
    ' DESCRIPTA EL CONTENIDO DE LA CADENA ENCRIPTADA
    '------------------------------------------------------
    Public Shared Function Descripta(ByVal cadenaEncriptada As String) As String
        Dim i As Integer
        Dim Real As String
        Dim result As String

        result = ""

        For i = 0 To Len(cadenaEncriptada) - 1
            Real = ChrW(AscW(Mid(cadenaEncriptada, i, 1)) - Len(cadenaEncriptada))
            result = result & Real
        Next

        Return result
    End Function

    ' -------------------------------------------------------------
    ' RETORNA UN ARRAY, CON LAS SUBCADENAS DELIMITADAS CON UN BYTE
    ' -------------------------------------------------------------
    Public Shared Function Divide(ByVal Micadena As String, ByVal ParamArray delim() As Char) As String()
        Return Micadena.Split(delim)
    End Function

    '-------------------------------------------------------
    ' FUNCION SIMILAR A SPLIT, PERO CON DELIMITADORES
    '     arr() = txt_divide2("[one,two],three,[four,five]","[]")
    ' into 3 items, because commas inside []
    '-------------------------------------------------------
    Public Shared Function Divide2(ByVal Micadena As String, Optional ByVal Quotes As String = """", _
        Optional ByVal Separator As String = ",") As ArrayList
        ' this is the result
        Dim res As New ArrayList
        ' get the open and close chars, escape them for using in regular expressions
        Dim openChar As String = System.Text.RegularExpressions.Regex.Escape _
            (Quotes.Chars(0))
        Dim closeChar As String = System.Text.RegularExpressions.Regex.Escape _
            (Quotes.Chars(Quotes.Length - 1))
        ' build the patter that searches for both quoted and unquoted elements
        ' notice that the quoted element is defined by group #2
        ' and the unquoted element is defined by group #3
        Dim pattern As String = "\s*(" & openChar & "([^" & closeChar & "]*)" & _
            closeChar & "|([^" & Separator & "]+))\s*"
        ' search all the elements
        Dim m As System.Text.RegularExpressions.Match
        For Each m In System.Text.RegularExpressions.Regex.Matches(Micadena, pattern)
            ' get a reference to the unquoted element, if it's there
            Dim g3 As String = m.Groups(3).Value
            If Not (g3 Is Nothing) AndAlso g3.Length > 0 Then
                ' if the 3rd group is not null, then the element wasn't quoted
                res.Add(g3)
            Else
                ' get the quoted string, but without the quotes
                res.Add(m.Groups(2).Value)
            End If
        Next
        Return res
    End Function

    '-----------------------------------------------------------------------
    ' Wraps the string in the specified characters
    ' This function is useful for enclosing table or field
    ' names containing spaces with brackets
    ' Arguments : stringIn       - The string to modifiy
    '             charsBegin     - The character or characters to add
    '                            to the beginning of the string
    '             charsEnd       - The character or characters to add
    '                            to the end of the string
    '             skipIfEnclosed - True to skip the string if it
    '                            already starts with the specified value
    ' Returns   : The modified string
    '-----------------------------------------------------------------------
    Public Shared Function EncloseString( _
        ByVal stringIn As String, _
        ByVal charsBegin As String, _
        ByVal charsEnd As String, _
        ByVal skipIfEnclosed As Boolean) As String
        Dim skip As Boolean
        Dim retValue As System.Text.StringBuilder = _
            New System.Text.StringBuilder(stringIn)
        If skipIfEnclosed = True Then
            If stringIn.StartsWith(charsBegin) Then
                ' Skip, since the string already starts with the
                ' specified enclosing character(s)
                skip = True
            End If
        End If
        If skip = True Then
            ' Do not modify the string
        Else
            retValue.Append(charsBegin, 0, charsBegin.Length)
            retValue.Append(charsEnd)
        End If
        Return retValue.ToString
    End Function

    '------------------------------------------------------
    ' ENCRIPTA Y DESCRIPTA LA CADENA, CODIGO DE 64 BITS.
    '------------------------------------------------------
    ' Returns the input string encoded to base64
    Public Shared Function EncodeBase64(ByVal miCadena As String) As String
        Dim strBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(miCadena)
        Return System.Convert.ToBase64String(strBytes)
    End Function

    '------------------------------------------------------
    ' ENCRIPTA EL CONTENIDO DE LA CADENA
    '------------------------------------------------------
    Public Shared Function Encripta(ByVal MiCadena As String) As String
        Dim i As Integer
        Dim NuevoCaracter As String
        Dim result As String = ""

        For i = 0 To MiCadena.Length - 1
            'devolver el codigo ascii del caracter, mas la longitud total de la cadena
            NuevoCaracter = ChrW(AscW(Mid(MiCadena, i, 1)) + MiCadena.Length)
            result = result & NuevoCaracter
        Next
        Return result
    End Function

    ' -----------------------------------
    ' ENCRIPTA UNA CADENA CON PASSWORD
    ' -----------------------------------
    Public Shared Function EnCryptKey(ByVal PstrText As String, ByVal pstrPass As String) As String
        Dim intpasslen As Integer
        Dim inttextlen As Integer
        Dim k As Integer
        Dim i As Integer
        Dim strencrpt As String = ""
        Dim cb As Integer
        intpasslen = Len(pstrPass)
        For i = 1 To intpasslen
            k = k + (Asc(Mid(pstrPass, i, 1)) * i) 'Get Key
            If k > 255 Then k = k - 255
        Next i
        Do While k > 255
            k = k - 255
        Loop
        inttextlen = Len(PstrText)
        For i = 1 To inttextlen
            cb = Asc(Mid(PstrText, i, 1)) + k   'Change Current Byte
            If cb > 255 Then cb = cb - 255
            strencrpt = strencrpt + Chr(cb)
            k = k + cb
            If k > 255 Then k = k - 255 'Update Key
        Next i
        Return strencrpt 'Return ResulStrEncrpt
    End Function

    ' ----------------------------------------------------------------------
    'Check whether a string ends with one of multiple possible choices.
    ' Return -1 if no possible string matches the end of the source,
    '  otherwise return the index of the matching string.
    ' Examples:
    '    Debug.WriteLine(EndsWith("This is my test line", True, "Line", "String")) ' => -1
    '    Debug.WriteLine(EndsWith("This is my test line", True, "string", "line")) ' => 1
    '    Debug.WriteLine(EndsWith("This is my test line", False, "Line", "String")) ' => 0
    '    Debug.WriteLine(EndsWith("This is my test line", False, "string","sentence")) ' => -1
    ' ----------------------------------------------------------------------
    Public Shared Function EndsWith(ByVal source As String, ByVal caseSensitive As Boolean, _
        ByVal ParamArray parts() As String) As Integer
        Dim i As Integer
        For i = 0 To parts.Length - 1
            Dim part As String = parts(i)
            If caseSensitive Then
                If source.EndsWith(part) Then Return i
            Else
                If source.ToLower().EndsWith(part.ToLower()) Then Return i
            End If
        Next
        ' if we get here, the source does not end with one of the possible choices,
        '  so return -1
        Return -1
    End Function

    ' -------------------------------------------------------------
    ' EXTRAE UNA SUBCADENA DE LA CADENA
    ' BASE 1:
    ' -------------------------------------------------------------
    Public Shared Function Extrae(ByVal MiCadena As String, ByVal inicio As Integer, _
        ByVal cuantos As Integer) As String
        Return MiCadena.Substring(inicio - 1, cuantos)
    End Function

    ' ------------------------------------------------
    ' ELIMINA LOS CARACTERES DUPLICADOS DE LA CADENA.
    ' ------------------------------------------------
    Public Shared Function FilterDup(ByVal miCadena As String) As String
        Dim nPos As Integer
        Dim cCar As Char
        Dim cCad2 As String = ""

        For nPos = 0 To miCadena.Length - 1
            cCar = miCadena(nPos)
            If miCadena.IndexOf(cCar) = -1 Then
                cCad2 += cCar
            End If
        Next

        Return cCad2
    End Function

    '------------------------------------------------------------
    'FILTRA UNA CADENA, A LOS CARACTERES VALIDOS INDICADOS
    '------------------------------------------------------------
    Public Shared Function FilterString(ByRef text As String, ByRef ValidChars As String) As String
        Dim i As Integer
        Dim result As String

        result = ""

        For i = 0 To Len(text) - 1
            If ValidChars.Contains(text(i)) Then
                result += text(i)
            End If
        Next

        Return result
    End Function

    ' -------------------------------------------------------------
    ' Invert the case of all characters of the input string
    ' Examples:
    '    Debug.WriteLine(FlipCase("Hello World")) ' => hELLO wORLD
    '    Debug.WriteLine(FlipCase("hELLO wORLD")) ' => Hello World
    '    Debug.WriteLine(FlipCase("3) this is message n. 3")) ' => 3) THIS IS
    ' MESSAGE N. 3
    ' -------------------------------------------------------------
    Public Shared Function FlipCase(ByVal input As String) As String
        Dim i As Integer
        Dim res As New System.Text.StringBuilder(input.Length)
        For i = 0 To input.Length - 1
            ' if the char is lowercase, add to the stringbuilder the char in
            ' uppercase
            If Char.IsLower(input.Chars(i)) Then
                res.Append(Char.ToUpper(input.Chars(i)))
            ElseIf Char.IsUpper(input.Chars(i)) Then
                ' if the char is uppercase, add to the stringbuilder the char in
                ' lowercase
                res.Append(Char.ToLower(input.Chars(i)))
            Else
                ' if the char is a digit or another non-letter char, add it as it is
                res.Append(input.Chars(i))
            End If
        Next
        Return res.ToString()
    End Function

    ' --------------------------------------------------------------------------
    ' format a value in a column of given width and with specified alignment
    ' using the specified pad character
    ' --------------------------------------------------------------------------
    Public Shared Function FormatValue(ByVal value As String, ByVal width As Integer, _
        ByVal alignment As FormatColumnAlignment, Optional ByVal padchar As Char = _
        " "c) As String
        Dim val As String = value.ToString
        Dim len As Integer = val.Length
        Select Case alignment
            Case FormatColumnAlignment.Left
                If len < width Then
                    val = val.PadRight(width, padchar)
                ElseIf len > width Then
                    val = val.Substring(0, width)
                End If
            Case FormatColumnAlignment.Center
                If len < width Then
                    Dim charnum As Integer = len + (width - len) \ 2
                    val = val.PadLeft(charnum, padchar).PadRight(width, padchar)
                ElseIf len > width Then
                    val = val.Substring((len - width) \ 2, width)
                End If
            Case FormatColumnAlignment.Right
                If len < width Then
                    val = val.PadLeft(width, padchar)
                ElseIf len > width Then
                    val = val.Substring(len - width)
                End If
        End Select
        Return val
    End Function

    '----------------------------------------------------
    ' CONVIERTE LA CADENA LOS PRIMERAS LETRAS
    '----------------------------------------------------
    Public Shared Function Frase(ByVal MiCadena As String) As String
        Return StrConv(MiCadena, vbProperCase)
    End Function

    '----------------------------------------------------------------------
    ' Generates a random string suitable for a password. To avoid passwords
    ' that are easily guessed or easy to crack with a dictionary-based
    ' password cracker, this function generates meaningless passwords.
    ' Optionally alternate vowels to make the password more "pronounceable."
    ' Arguments : pwdLength - Number of characters in the password
    '             alternateVowels - True to alternate between
    '                               consonants and vowels to make
    '                               the password "pronounceable"
    ' Returns   : The password string
    Public Shared Function GenRandomPassword( _
        ByVal pwdLength As Integer, _
        ByVal alternateVowels As Boolean) As String
        Dim position As Integer
        Dim randomChar As Integer
        Dim letters As String = "AEIOUBCDFGHJKLMNPQRSTVWXYZ"
        Dim retValue As String = ""
        ' Initialize the random number generator with the
        ' return value from the system timer
        Dim rndNum As System.Random = New System.Random _
            (CType(DateTime.Now.Second, Integer))
        For position = 0 To pwdLength - 1
            If alternateVowels Then
                ' Every other character should be a vowel
                If position Mod 2 = 0 Then
                    ' Pick a number between 6 and 26
                    randomChar = rndNum.Next(6, 26)
                Else
                    ' Pick a number between 1 and 5
                    randomChar = rndNum.Next(1, 5)
                End If
            Else
                ' Each character is random across the whole
                ' alphabet. Pick a number between 1 and 26
                randomChar = rndNum.Next(1, 26)
            End If
            ' Get the random character and append it to the
            ' password string
            retValue = retValue & letters.Substring(randomChar, 1)
        Next position
        Return retValue
    End Function

    ' -----------------------------------------------------------------------
    ' EXTRAE DE UNA CADENA, UN TEXTO DELIMITADO:
    ' EJEMPLO:
    '   Dim source As String = " a sentence with (a word) in parenthesis"
    '   Dim i As Integer = 0
    '   CAD = GetDelimitedText(source, "(", ")", i)
    '   RETORNA: "a word"
    '   NOTA: DEJA EL PUNTERO "i" en la posicion despues de ")"
    '   IF YA NO HAY MAS QUE EXTRAER, RETORNA "", Y EL INDICE = -1
    '  NOTA:  index OPTION BASE = 1
    ' -----------------------------------------------------------------------
    Public Shared Function GetDelimited(ByVal miCadena As String, ByVal OpenDelimiter As String, ByVal CloseDelimiter As String, ByRef index As Integer) As String
        Dim i As Integer, j As Integer
        index = index - 1  'AJUSTAR A BASE 1
        If index < 0 Then index = 0
        ' buscar la marca de apertura
        i = miCadena.IndexOf(OpenDelimiter, index)
        If i < 0 Then
            index = -1
            Return Nothing
        End If
        i = i + OpenDelimiter.Length
        ' buscar la marca de cierre
        j = miCadena.IndexOf(CloseDelimiter, i)
        If j < 0 Then
            index = -1
            Return Nothing
        End If
        ' avanzar el puntero al siguiente byte
        index = j + CloseDelimiter.Length
        ' devolver la cadena entre los delimitadores
        Return miCadena.Substring(i, j - i)
    End Function

    '-----------------------------------------
    ' Returns a word from a delimited string
    ' Arguments : stringIn - The string to search
    '             index - The word position to find
    '             delimitChar - The character used as the delimter
    ' Returns   : The nth word from the string
    '-----------------------------------------
    Public Shared Function GetDelimitedWord(ByVal stringIn As String, ByVal index As Integer, ByVal delimitChar As String) As String
        Dim counter As Integer = 1
        Dim startPos As Integer = 0
        Dim endPos As Integer
        Dim indexExceedsWordCount As Boolean = False
        Dim retVal As String
        ' Count to the specified index

        For counter = 2 To index
            ' Get the new starting position
            startPos = stringIn.IndexOf(delimitChar, startPos) + 1
            If startPos = 0 Then
                ' The index exceeds the number of words in the string
                indexExceedsWordCount = True
            End If
        Next counter

        If Not indexExceedsWordCount = True And Not index = 0 Then
            ' Determine the ending position
            endPos = stringIn.IndexOf(delimitChar, startPos + 1)
            ' Ensure that the ending position is not less than 1
            If endPos <= 0 Then
                endPos = stringIn.Length
            End If
            ' Pull the word out and return it
            retVal = stringIn.Substring(startPos, endPos - startPos)
        Else
            retVal = ""
        End If

        Return retVal
    End Function

    '----------------------------------------------------------------------
    'RETORNA EL STRING QUE SE ENCUENTRA EN UNA FILA XX DE LA CADENA
    '----------------------------------------------------------------------
    Public Shared Function GetLineString(ByVal tcString As String, ByVal tnLineNo As Integer) As String
        Dim aLines() As String = tcString.Split(ControlChars.Cr)
        Dim lcRetVal As String = ""
        Try
            lcRetVal = aLines(tnLineNo - 1)
        Catch
            'Ignore the exception as MLINE always returns a value
        End Try
        Return lcRetVal
    End Function

    '----------------------------------------------------------------------
    ' RETORNA UNA SUBCADENA, QUE SE ENCUENTRA DESPUES DE LA CADENA INDICADA
    ' PstrVal       : String to Search
    ' PintIndex     : Index Value in the Search String
    ' PstrDelimiter : [string] delimiter (1 or more chars)
    ' Returns       : [string] "Token" (section of data) from a list of
    '                 delimited string data
    ' Examples      : GetToken("sslindia@hotmail.com", 2, "@") returns "hotmail.com"
    '                 GetToken("123-45-6789", 2, "-") returns "45"
    '                 GetToken("first,middle,last", 3, ",") returns "last"
    ' -------------------------------------------------------------------------------
    Public Shared Function GetTokenIdx(ByVal MiCadena As String, ByVal PintIndex As Integer, ByVal PstrDelimiter As String) As String
        Dim strSubString() As String
        Dim intIndex2 As Integer
        Dim i As Integer
        Dim intDelimitLen As Integer
        Dim PstrVal As String = MiCadena

        intIndex2 = 1
        i = 0
        intDelimitLen = Len(PstrDelimiter)

        Do
            ReDim Preserve strSubString(i + 1)
            intIndex2 = InStr(1, PstrVal, PstrDelimiter)
            If intIndex2 > 0 Then
                strSubString(i) = Mid(PstrVal, 1, (intIndex2 - 1))
                PstrVal = Mid(PstrVal, (intIndex2 + intDelimitLen), _
                         Len(PstrVal))
            Else
                strSubString(i) = PstrVal
            End If
            i = i + 1
        Loop While intIndex2 > 0

        If PintIndex > (i + 1) Or PintIndex < 1 Then
            Return ""
        Else
            Return strSubString(PintIndex - 1)
        End If
    End Function

    ' ------------------------------------------------------------
    ' Increment the numeric right-most portion of a string
    ' Example: MessageBox.Show(IncrementString("test219")) ' => 220
    ' ------------------------------------------------------------
    Public Shared Function IncrementString(ByVal text As String) As String
        Dim index As Integer
        Dim i As Integer
        For i = text.Length - 1 To 0 Step -1
            Select Case text.Substring(i, 1)
                Case "0" To "9"
                Case Else
                    index = i
                    Exit For
            End Select
        Next

        If index = text.Length - 1 Then
            Return text & "1"
        Else
            Dim value As Integer = Integer.Parse(text.Substring(index + 1)) + 1
            Return text.Substring(0, index) & value.ToString()
        End If
    End Function

    ' -------------------------------------------------------------
    ' VERIFICA SI UNA CADENA COMIENZA CON LA QUE SE INDIQUE
    ' -------------------------------------------------------------
    Public Shared Function IniciaCon(ByVal cadena As String, ByVal Buscar As String) As Boolean
        Return cadena.StartsWith(Buscar)
    End Function

    ' -------------------------------------------------------
    ' INSERTA CUALQUIER OBJETO EN LA CADENA, EN LA POSICION INDICADA
    ' BASE 1: OPCIONALMENTE, PUEDE DESPLAZAR EL CONTENIDO INTERNO.
    '
    ' Si Posicion es mayor que ancho de cadena original, o es
    ' menor que 1: NO SE PUEDE INSERTAR: RETORNA CADENA ORIGINAL
    '
    ' NOTA: Es mejor usar esta rutina en cadenas cortas
    ' Si se quiere utilizarla para procesar un archivo de texto,
    ' Es mejor
    ' -------------------------------------------------------
    Public Shared Function Insertar(ByVal cadena As String, ByVal posicion As Integer, _
        ByVal Subcad As String, _
        Optional ByVal desplazar As Boolean = False, _
        Optional ByVal truncar As Boolean = True) As String
        posicion = posicion - 1 'readecuar a base 0
        Dim nLargoOriginal As Integer = cadena.Length
        Dim cResult As String
        Try
            If desplazar Then
                cResult = cadena.Insert(posicion, Subcad)
            Else
                Subcad = Subcad.Substring(0, nLargoOriginal - posicion)
                cResult = cadena.Remove(posicion, Subcad.Length)
                cResult = cResult.Insert(posicion, CType(Subcad, String))
            End If
            If truncar Then
                Return cResult.ToString.Substring(0, nLargoOriginal)
            Else
                Return cResult.ToString
            End If
        Catch errors As Exception
            Return cadena
        End Try
    End Function

    ' -----------------------------------------------------------
    ' search for a string starting at a given index
    ' and return the index of the character that follows
    ' the searched string (case insensitive search)
    ' -----------------------------------------------------------
    Public Shared Function InstrAfter(ByVal Source As String, ByVal Search As String, ByVal index As Integer) As Integer
        Dim startIndex As Integer

        startIndex = Source.IndexOf(Search, index, CompareMethod.Text)

        If (startIndex > -1) Then
            Return startIndex + Search.Length
        End If
    End Function

    ' ----------------------------------------------
    ' returns the last occurrence of a substring
    ' The syntax is similar to InStr
    ' ----------------------------------------------
    Public Shared Function InstrLast(ByVal start As Integer, ByVal source As String, ByVal search As String) As Integer
        Return InstrLast(start, source, search, CompareMethod.Binary)
    End Function

    Public Shared Function InstrLast(ByVal start As Integer, ByVal source As String, ByVal search As String, ByVal compare As Microsoft.VisualBasic.CompareMethod) As Integer
        Dim lastIndex As Integer

        Do
            ' search the next occurrence
            lastIndex = source.IndexOf(search, start, compare)

            If start = 0 Then Exit Do
            ' we found one
            InstrLast = start
            start = start + 1
        Loop

        Return 0
    End Function

    ' ----------------------------------------------------------------------------
    ' If INCLUDE is True or is omitted, return the first occurrence of a character
    ' in a group
    ' or -1 if SOURCE doesn't contain any character among those listed in TABLE.
    ' If INCLUDE is False, return the first occurrence of the character in SOURCE
    ' that does not appear in TABLE.
    ' string indices are zero-based
    ' TABLE can be in the form "A-Z"
    ' ----------------------------------------------------------------------------
    Public Shared Function InstrTbl(ByVal Start As Integer, ByVal Source As String, _
        ByVal Table As String, Optional ByVal Include As Boolean = True, _
        Optional ByVal CaseInsensitive As Boolean = False) As Integer
        ' create the regular expression
        Dim pattern As String
        If Include Then
            pattern = "[" & Table & "]"
        Else
            pattern = "[^" & Table & "]"
        End If
        ' prepare the correct regex option
        Dim options As Text.RegularExpressions.RegexOptions
        If CaseInsensitive Then
            options = Text.RegularExpressions.RegexOptions.IgnoreCase
        End If
        ' create the Regex object
        Dim re As New Text.RegularExpressions.Regex(pattern, options)

        ' find the match
        Dim ma As Text.RegularExpressions.Match = re.Match(Source, Start)
        ' return the found index, or -1
        If ma.Success Then
            Return ma.Index
        Else
            Return -1
        End If
    End Function

    ' ----------------------------------------------------------------------------
    ' If INCLUDE is True or is omitted, return the last occurrence of a character
    ' in a group
    ' or -1 if SOURCE doesn't contain any character among those listed in TABLE.
    ' If INCLUDE is False, return the last occurrence of the character in SOURCE
    ' that does not appear in TABLE.
    '
    ' string indices are zero-based
    ' START = -1 searches from the end of string
    ' TABLE can be in the form "A-Z"
    ' ----------------------------------------------------------------------------
    Public Shared Function InstrTblRev(ByVal Start As Integer, ByVal Source As String, _
        ByVal Table As String, Optional ByVal Include As Boolean = True, _
        Optional ByVal CaseInsensitive As Boolean = False) As Integer
        ' create the regular expression
        Dim pattern As String
        If Include Then
            pattern = "[" & Table & "]"
        Else
            pattern = "[^" & Table & "]"
        End If
        ' prepare the correct regex option
        Dim options As Text.RegularExpressions.RegexOptions
        If CaseInsensitive Then
            options = Text.RegularExpressions.RegexOptions.IgnoreCase
        End If
        ' create the Regex object
        Dim re As New Text.RegularExpressions.Regex(pattern, options)

        ' adjust arguments for backward search
        Source = StrReverse(Source)
        If Start >= 0 And Start < Source.Length Then
            Start = Source.Length - Start
        Else
            Start = 0
        End If
        ' find the match
        Dim ma As Text.RegularExpressions.Match = re.Match(Source, Start)
        ' return the found index, or -1
        If ma.Success Then
            Return Source.Length - ma.Index - 1
        Else
            Return -1
        End If
    End Function

    '----------------------------------------------------
    ' OBTIENE la inversa de la cadena
    '----------------------------------------------------
    Public Shared Function Inverso(ByVal miCadena As String) As String
        Return StrReverse(miCadena)
    End Function

    '----------------------------------------------------
    ' Determine whether the character is a lower case letter
    '----------------------------------------------------
    Public Shared Function IsCharLower( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsLower(str, position)
    End Function

    '----------------------------------------------------
    ' Determine whether the character is a decimal or hexidecimal digit
    '----------------------------------------------------
    Public Shared Function IsCharNumber( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsNumber(str, position)
    End Function

    '----------------------------------------------------
    ' Determine whether the character is a punctuation mark
    '----------------------------------------------------
    Public Shared Function IsCharPuntuacion( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsPunctuation(str, position)
    End Function

    '---------------------------------------------------------
    'Determine whether the character is a seperator character
    '---------------------------------------------------------
    Public Shared Function IsCharSeparator( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsSeparator(str, position)
    End Function

    '---------------------------------------------------------
    ' Determine whether the character is a symbol
    '---------------------------------------------------------
    Public Shared Function IsCharSymbol( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsSymbol(str, position)
    End Function

    '---------------------------------------------------------
    ' Determine whether the character is an upper case letter
    '---------------------------------------------------------
    Public Shared Function IsCharUpper( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsUpper(str, position)
    End Function

    '---------------------------------------------------------
    ' Determine whether the character is white space
    '---------------------------------------------------------
    Public Shared Function IsCharWhite( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsWhiteSpace(str, position)
    End Function

    '----------------------------------------------------
    'RETORNA SI EL CARACTER ES UN CARACTER DE CONTROL
    '----------------------------------------------------
    Public Shared Function IsControl( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsControl(str, position)
    End Function

    '----------------------------------------------------
    'RETORNA SI EL CARACTER ES UN CARACTER DE CONTROL
    '----------------------------------------------------
    Public Shared Function IsDigit( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsDigit(str, position)
    End Function

    '----------------------------------------------------
    'RETORNA SI EL CARACTER ES UN CARACTER DE CONTROL
    '----------------------------------------------------
    Public Shared Function IsLetter( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsLetter(str, position)
    End Function

    '----------------------------------------------------
    ' Determine whether the character is either a letter or a decimal digit
    '----------------------------------------------------
    Public Shared Function IsLetterOrDigit( _
        ByVal str As String, _
        ByVal position As Integer) As Boolean
        Return System.Char.IsLetterOrDigit(str, position)
    End Function

    '----------------------------------------------------------------------
    'VERIFICA SI LA CADENA TIENE SOLO MINUSCULAS
    '----------------------------------------------------------------------
    Public Shared Function IsStringLower(ByVal sText As String) As Boolean
        Dim c As Char
        For Each c In sText
            If Not Char.IsLower(c) Then Return False
        Next
        Return True
    End Function

    '----------------------------------------------------------------------
    'VERIFICA SI LA CADENA TIENE SOLO MAYUSCULAS
    '----------------------------------------------------------------------
    Public Shared Function IsStringUpper(ByVal sText As String) As Boolean
        Dim c As Char
        For Each c In sText
            If Not Char.IsUpper(c) Then Return False
        Next
        Return True
    End Function

    ' -------------------------------------------------------------
    ' EXTRAE UNA SUBCADENA DE LA CADENA, A PARTIR DE LA IZQUIERDA
    ' -------------------------------------------------------------
    Public Shared Function Izquierda(ByVal MiCadena As String, ByVal cuantos As Integer) As String
        Return MiCadena.Substring(0, cuantos)
    End Function

    ' -------------------------------------------------------------
    ' ELIMINA ESPACIOS A LA IZQUIERDA
    ' -------------------------------------------------------------
    Public Shared Function LTrim(ByVal MiCadena As String) As String
        Return MiCadena.TrimStart
    End Function

    ' ------------------------------------------------
    ' ORDENA EL CARACTER DE MAYOR VALOR ASCII.
    ' ------------------------------------------------
    Public Shared Function MayorCad(ByVal MiCadena As String) As String
        Dim cMayor As String, i As Integer, Subcad As String
        cMayor = MiCadena.Substring(0, 1)
        For i = 1 To MiCadena.Length - 1
            Subcad = MiCadena.Substring(i, 1)
            If AscW(Subcad) > AscW(cMayor) Then cMayor = Subcad
        Next
        Return cMayor
    End Function

    ' -------------------------------------------------------------
    ' CONVIERTE TODA LA CADENA A MAYUSCULAS
    ' -------------------------------------------------------------
    Public Shared Function Mayusculas(ByVal MiCadena As String) As String
        Return MiCadena.ToUpper
    End Function

    ' ------------------------------------------------
    ' ORDENA EL CARACTER DE MENOR VALOR ASCII.
    ' ------------------------------------------------
    Public Shared Function MenorCad(ByVal miCadena As String) As String
        Dim cMenor As String, i As Integer, Subcad As String
        cMenor = miCadena.Substring(0, 1)
        For i = 1 To miCadena.Length - 1
            Subcad = miCadena.Substring(i, 1)
            If AscW(Subcad) > AscW(cMenor) Then cMenor = Subcad
        Next
        Return cMenor
    End Function

    ' -------------------------------------------------------------
    ' CONVIERTE TODA LA CADENA A MINUSCULAS
    ' -------------------------------------------------------------
    Public Shared Function Minusculas(ByVal MiCadena As String) As String
        Return MiCadena.ToLower
    End Function

    ' --------------------------------------------------------------
    ' Converts an integer into a string with a trailing suffix
    ' Arguments : numberIn - The number to convert
    ' Returns   : The string with a suffix
    '             (i.e. 1 becomes "1st", 2 becomes "2nd", etc.)
    ' --------------------------------------------------------------
    Public Shared Function NumberSuffix(ByVal numberIn As Integer) As String
        Dim suffix As String
        ' First check >10 and <20
        If numberIn > 10 And numberIn < 20 Then
            suffix = "th"
        Else
            ' Grab the last digit
            Select Case numberIn Mod 10
                Case 1
                    suffix = "st"
                Case 2
                    suffix = "nd"
                Case 3
                    suffix = "rd"
                Case Else
                    suffix = "th"
            End Select
        End If
        Return numberIn & suffix
    End Function

    Public Shared Function NumeroaLetras(ByVal vnum As Decimal) As String

        Dim vnumero As String
        Dim vlongitud As Long
        Dim vagregar, vconta As Long
        Dim vgrupo1, vgrupo2, vgrupo3, vgrupo4, vdescrip As String
        Dim vgrupo As String = ""
        Dim vlongg, vbande, vconta2 As Long
        Dim vdecimal As Decimal

        vdecimal = vnum

        Dim UNIDAD(9)
        Dim DECENA(9)
        Dim DECENA2(15)
        Dim CENTENA(9)
        Dim AGREGADO(4)

        UNIDAD(1) = "UN "
        UNIDAD(2) = "DOS "
        UNIDAD(3) = "TRES "
        UNIDAD(4) = "CUATRO "
        UNIDAD(5) = "CINCO "
        UNIDAD(6) = "SEIS "
        UNIDAD(7) = "SIETE "
        UNIDAD(8) = "OCHO "
        UNIDAD(9) = "NUEVE "

        DECENA(1) = "DIEZ "
        DECENA(2) = "VEINTE "
        DECENA(3) = "TREINTA "
        DECENA(4) = "CUARENTA "
        DECENA(5) = "CINCUENTA "
        DECENA(6) = "SESENTA "
        DECENA(7) = "SETENTA "
        DECENA(8) = "OCHENTA "
        DECENA(9) = "NOVENTA "

        DECENA2(11) = "ONCE "
        DECENA2(12) = "DOCE "
        DECENA2(13) = "TRECE "
        DECENA2(14) = "CATORCE "
        DECENA2(15) = "QUINCE "

        CENTENA(1) = "CIENTO "
        CENTENA(2) = "DOSCIENTOS "
        CENTENA(3) = "TRESCIENTOS "
        CENTENA(4) = "CUATROCIENTOS "
        CENTENA(5) = "QUINIENTOS "
        CENTENA(6) = "SEISCIENTOS "
        CENTENA(7) = "SETECIENTOS "
        CENTENA(8) = "OCHOCIENTOS "
        CENTENA(9) = "NOVECIENTOS "

        AGREGADO(1) = ""
        AGREGADO(2) = "MIL "
        AGREGADO(3) = "MILLONES "
        'AGREGADO(4) = "BILLONES "
        AGREGADO(4) = "MIL "

        vnum = Int(vnum)
        vnumero = LTrim(Str(vnum))
        vlongitud = Len(vnumero)
        vagregar = 0

        vgrupo1 = "   "
        vgrupo2 = "   "
        vgrupo3 = "   "
        vgrupo4 = "   "

        vdescrip = ""

        Select Case vlongitud
            Case 1 To 3
                vagregar = 1
                vgrupo1 = vnumero
            Case 4 To 6
                vagregar = 2
                vgrupo2 = vnumero.Substring(0, vlongitud - 3)
                vgrupo1 = Right(vnumero, 3)
            Case 7 To 9
                vagregar = 3
                vgrupo3 = vnumero.Substring(0, vlongitud - 6)
                vgrupo2 = vnumero.Substring(vlongitud - 6, 3)
                vgrupo1 = Right(vnumero, 3)
            Case 10 To 12
                vagregar = 4
                vgrupo4 = vnumero.Substring(0, vlongitud - 9)
                vgrupo3 = vnumero.Substring(vlongitud - 9, 3)
                vgrupo2 = vnumero.Substring(vlongitud - 6, 3)
                vgrupo1 = Right(vnumero, 3)
        End Select

        vconta = vagregar

        Do While vconta > 0

            Select Case vconta
                Case Is = 4
                    vgrupo = vgrupo4
                Case Is = 3
                    vgrupo = vgrupo3
                Case Is = 2
                    vgrupo = vgrupo2
                Case Is = 1
                    vgrupo = vgrupo1
            End Select

            vlongg = Len(vgrupo)
            vbande = 0

            If Val(vgrupo) <> 0 Then
                vconta2 = vlongg
                Do While vconta2 > 0

                    Select Case vconta2
                        Case Is = 3
                            If Val(vgrupo) = 100 Then
                                vdescrip = vdescrip + "CIEN "
                                Exit Do
                            Else
                                vdescrip = vdescrip + CENTENA(Val(vgrupo.Substring(0, 1)))
                                If vgrupo.Substring(1, 2) = "00" Then
                                    Exit Do
                                End If
                            End If
                        Case Is = 2
                            If Val(vgrupo.Substring(vlongg - 2, 1)) <> 0 Then
                                If Val(vgrupo.Substring(vlongg - 2, 2)) > 10 And Val(vgrupo.Substring(vlongg - 2, 2)) < 16 Then
                                    vdescrip = vdescrip + DECENA2(Val(vgrupo.Substring(vlongg - 2, 2)))
                                    Exit Do
                                Else
                                    vdescrip = vdescrip + DECENA(Val(vgrupo.Substring(vlongg - 2, 1)))
                                    If vgrupo.Substring(vlongg - 1, 1) = "0" Then
                                        Exit Do
                                    End If
                                End If
                            Else
                                vbande = 1
                            End If
                        Case Is = 1
                            If Val(vgrupo) > 9 And vbande = 0 Then
                                vdescrip = vdescrip + "Y "
                            End If
                            If Val(vgrupo.Substring(vlongg - 1, 1)) = 1 And vconta = 1 Then
                                vdescrip = vdescrip + "UNO "
                            Else
                                vdescrip = vdescrip + UNIDAD(Val(vgrupo.Substring(vlongg - 1, 1)))
                            End If


                    End Select
                    vconta2 = vconta2 - 1

                Loop

                If vconta = 4 And Val(vgrupo) = 1 Then
                    vdescrip = vdescrip + "MIL "    ' "BILLON "
                Else
                    If vconta = 3 And Val(vgrupo) = 1 Then
                        vdescrip = vdescrip + "MILLON "
                    Else
                        vdescrip = vdescrip + AGREGADO(vconta)
                    End If
                End If
            End If
            vconta = vconta - 1

        Loop

        If vdecimal <> Int(vdecimal) Then
            vdecimal = (vdecimal - Int(vdecimal)) * 100
            vdecimal = Math.Round(vdecimal, 0)
            vdescrip = vdescrip + "CON " + AllTrim(Str(vdecimal)) + "/100"
        End If

        Return vdescrip

    End Function

    ' ------------------------------------------------
    ' ORDENA LA CADENA EN FORMA ASCENDENTE
    ' ------------------------------------------------
    Public Shared Function OrdenaAsc(ByVal miCadena As String) As String
        Dim nContador As Integer, nPos As Integer
        For nContador = 0 To miCadena.Length - 2
            For nPos = 0 To Len(miCadena) - nContador - 1
                If miCadena.Substring(nPos, 1) > miCadena.Substring(nPos + 1, 1) Then
                    miCadena = Left(miCadena, nPos - 1) & _
                    miCadena.Substring(nPos + 1, 1) & _
                    miCadena.Substring(nPos, 1) & _
                    Right(miCadena, miCadena.Length - nPos - 1)
                End If
            Next
        Next
        Return miCadena
    End Function

    ' ------------------------------------------------
    ' ORDENA LA CADENA EN FORMA DESCENDENTE
    ' ------------------------------------------------
    Public Shared Function OrdenaDesc(ByVal miCadena As String) As String
        Dim nContador As Integer, nPos As Integer
        For nContador = 0 To miCadena.Length - 2
            For nPos = 0 To miCadena.Length - nContador - 1
                If miCadena.Substring(nPos, 1) < miCadena.Substring(nPos + 1, 1) Then
                    miCadena = Left(miCadena, nPos - 1) & _
                    miCadena.Substring(nPos + 1, 1) & _
                    miCadena.Substring(nPos, 1) & _
                      Right(miCadena, miCadena.Length - nPos - 1)
                End If
            Next
        Next
        Return miCadena
    End Function

    ' ------------------------------------------------
    ' CUENTA EL NUMERO DE PALABRAS DE LA CADENA
    ' Omite los signos de puntuacion
    ' ------------------------------------------------
    Public Shared Function Palabras(ByVal miCadena As String) As Long
        Dim nPos As Integer, lSwitch As Boolean = True, nCad3 As Long = 0
        Dim cCad2 As String = ",;.:-_'{}[]()*+^`¨­?=/&%$#@ |!\" + Chr(34)
        For nPos = 0 To miCadena.Length - 1
            If Not Contiene(miCadena.Substring(nPos, 1), cCad2) And lSwitch Then
                lSwitch = False
                nCad3 = nCad3 + 1
            End If
            If Contiene(miCadena.Substring(nPos, 1), cCad2) Then
                lSwitch = True
            End If
        Next
        Return nCad3
    End Function

    ' ------------------------------------------------------------
    ' Generates all combination possibilities out of a string
    ' ------------------------------------------------------------
    Public Shared Function PermuteString(ByVal Ztring As String) As String
        Return PermuteString(Ztring, "")
    End Function

    Public Shared Function PermuteString(ByVal Ztring As String, ByVal Base As String) As String
        Dim TmpStrArray() As String
        Dim I As Integer
        Dim result As String = ""

        'split elements in one array of elements
        TmpStrArray = Split(Ztring, " ", , vbTextCompare)

        If TmpStrArray.Length < 2 Then
            ' If there's only 1 element then
            result = Base & " " & Ztring & vbCrLf
        Else
            ' If more than 1 element
            If Base = "" Then
                ' Loop trough each element and do callbacks to permute again
                For I = LBound(TmpStrArray) To UBound(TmpStrArray)
                    result = result & PermuteString(ReturnAllBut(TmpStrArray, I), TmpStrArray(I))
                Next
            Else
                ' Loop trough each element and do callbacks to permute again
                For I = LBound(TmpStrArray) To UBound(TmpStrArray)
                    result = result & " " & PermuteString(ReturnAllBut(TmpStrArray, I), Base & " " & TmpStrArray(I))
                Next
            End If
        End If

        Return result
    End Function

    ' -------------------------------------------------------
    ' RETORNA LA POSICION DE LA ULTIMA OCURRENCIA DEL CARACTER
    ' RETORNA 0: SI CAR NO EXISTE DENTRO DE LA CADENA
    ' FUNCION DE BASE 1
    ' NOTA: DISTINGUE MINUSCULAS DE MAYUSCULAS
    ' -------------------------------------------------------
    Public Shared Function PosEnd(ByVal cadena As String, ByVal Buscar As String) As Integer
        Return cadena.LastIndexOf(Buscar) + 1
    End Function

    ' ----------------------------------------------------------
    ' RETORNA LA POSICION DE LA PRIMERA OCURRENCIA DEL CARACTER
    ' RETORNA 0: SI CAR NO EXISTE DENTRO DE LA CADENA
    ' FUNCION DE BASE 1
    ' NOTA: DISTINGUE MINUSCULAS DE MAYUSCULAS
    ' ----------------------------------------------------------
    Public Shared Function PosIni(ByVal cadena As String, ByVal Buscar As String) As Integer
        Return cadena.IndexOf(Buscar) + 1
    End Function

    ' -------------------------------------------------------------
    ' QUITA ESPACIOS DUPLICADOS DENTRO DE UNA CADENA
    ' -------------------------------------------------------------
    Public Shared Function QuitaEspaciosDup(ByVal MiCadena As String) As String
        Const TWO_SPACES As String = "  "
        Dim intPos As Integer
        Dim strtemp As String
        Dim PstrText As String = MiCadena.Trim
        intPos = InStr(1, PstrText, TWO_SPACES, vbBinaryCompare)
        Do While intPos > 0
            strtemp = Mid(PstrText, intPos + 1).TrimStart
            PstrText = Left(PstrText, intPos) & strtemp
            intPos = InStr(1, PstrText, TWO_SPACES, vbBinaryCompare)
        Loop
        Return PstrText
    End Function

    '------------------------------------------------------
    ' REMOVER TODOS LOS CARACTERES INDICADOS EN UNA CADENA
    '------------------------------------------------------
    Public Shared Function QuitarCad(ByVal micadena As String, ByVal Subcad As String) As String
        Return micadena.Replace(Subcad, "")
    End Function

    ' -------------------------------------------------------
    ' generate a random string
    ' the mask can contain the following special chars
    '    ? : any ASCII character (1-127)
    '    # : a digit
    '    A : an alphabetic char
    '    N : an alphanumeric char
    '    H : an hex char
    ' all other chars are taken literally
    ' Example: a random-generated phone number
    '   phone = RandomString("(###)-####-####")
    ' -------------------------------------------------------
    Public Shared Function RandomString(ByVal mask As String) As String
        Dim options As String
        Dim char1 As Char

        ' initialize result with proper lenght
        RandomString = mask

        For i As Integer = 0 To Len(mask) - 1
            ' get the character
            char1 = mask(i)
            Select Case char1
                Case "?"c
                    char1 = Chr(1 + Convert.ToInt32(Rnd()) * 127)
                    options = ""
                Case "#"c
                    options = "0123456789"
                Case "A"c
                    options = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                Case "N"c
                    options = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0" _
                        & "123456789"
                Case "H"c
                    options = "0123456789ABCDEF"
                Case Else
                    ' don't modify the character
                    options = ""
            End Select
            ' select a random char in the option string

            If options.Length > 0 Then
                ' select a random char
                ' note that we add an extra char, in case RND returns 1
                char1 = Mid$(options & Right$(options, 1), 1 + Convert.ToInt32(Rnd()) * options.Length, 1)(1)
            End If
            ' insert the character in result string
            Mid(RandomString, i, 1) = char1
        Next
    End Function

    ' -------------------------------------------------------------
    ' REEMPLAZAR TODAS LAS OCURRENCIAS EN LA CADENA
    ' -------------------------------------------------------------
    Public Shared Function Reemplazar(ByVal micadena As String, ByVal cadena As String, _
        ByVal Nuevo As String) As String
        Return micadena.Replace(cadena, Nuevo)
    End Function

    ' -------------------------------------------------------------
    ' ELIMINA UN NUMERO DETERMINADO DE BYTES, A PARTIR DE UNA POSICION
    ' COMENZANDO POR LA IZQUIERDA.
    ' BASE 1
    ' -------------------------------------------------------------
    Public Shared Function Remover(ByVal cadena As String, ByVal cuantos As Integer, _
        ByVal pos As Integer) As String
        Return cadena.Remove(pos - 1, cuantos)
    End Function

    ' ------------------------------------------------------
    ' Replace placeholders in the form @@1, @@2, etc.
    ' with arguments passed after the first one.
    ' For example, calling this function with
    '    res = ReplaceArgs("File @@1 not found on drive @@2", "README.TXT", "C:")
    '    it returns the string
    '    "File README.TXT not found in drive A:"
    ' ------------------------------------------------------
    Public Shared Function ReplaceArgs(ByVal Text As String, ByVal ParamArray args() As Object) As String
        Dim i As Integer
        For i = 0 To UBound(args)
            Text = Replace(Text, "@@" & CStr(i + 1), args(i))
        Next
        Return Text
    End Function

    ' --------------------------------------------------
    ' Replace the last occurrence of a string
    ' --------------------------------------------------
    Public Shared Function ReplaceLast(ByVal Expression As String, ByVal Find As String, ByVal ReplaceStr As String, _
        Optional ByVal Compare As Microsoft.VisualBasic.CompareMethod = CompareMethod.Text) As String
        Dim i As Long
        i = InStrRev(Expression, Find, , Compare)
        If i Then
            ' the search string is there
            ' note that the Replace function trims the first part
            ' of the string, so we must restore it using Left$
            Return Left$(Expression, i - 1) & Replace(Expression, Find, _
                ReplaceStr, i, 1, Compare)
        Else
            ' the search string isn't there
            Return Expression
        End If
    End Function

    ' ----------------------------------------------------------------------
    ' Perform multiple substitutions in a string
    ' The first argument is the string to be searched
    ' The second argument is vbBinaryCompare or vbTextCompare
    '     and tells whether the search is case sensitive or not
    ' The following arguments are pairs of (find, replace) strings
    '
    ' For example:
    '   Print ReplaceMulti("ABCDEF abcdef", vbBinaryCompare, "AB", "#", "DE", "%")
    '         displays "#C%F abcdef"
    '   Print ReplaceMulti("ABCDEF abcdef", vbTextCompare, "AB", "#", "DE", "%")
    '         displays "#C%F #c%f"
    '
    ' The function raises an error if the arguments are unbalanced
    ' ----------------------------------------------------------------------
    Public Shared Function ReplaceMulti(ByVal Text As String, ByVal CompareMethod As Microsoft.VisualBasic.CompareMethod, _
        ByVal ParamArray args() As Object) As String
        ' raise Illegal Function Call error if the args()
        ' array contains an odd number of items
        If UBound(args) Mod 2 = 0 Then
            Err.Raise(5)
        End If
        ' replace each argument in the pair
        For i As Integer = 0 To UBound(args) Step 2
            Text = Replace(Text, args(i), args(i + 1), , , CompareMethod)
        Next
        Return Text
    End Function

    '------------------------------------------------------
    ' DEVUELVE UNA CADENA REPLICADA UN X NUMERO DE VECES
    '------------------------------------------------------
    Public Shared Function Replicate(ByVal source As String, ByVal times As Integer) As String
        Dim sb As New System.Text.StringBuilder(source.Length * times)
        Dim index As Integer
        For index = 1 To times
            sb.Append(source)
        Next
        Return sb.ToString()
    End Function

    ' Return all items in a array but 1
    Public Shared Function ReturnAllBut(ByRef Arrai() As String, ByVal But As Integer) As String
        Dim I As Integer
        Dim result As String = ""

        For I = LBound(Arrai) To UBound(Arrai)
            If I <> But Then
                result = result & Arrai(I) & " "
            End If
        Next

        result = RTrim(result)

        Return result
    End Function

    ' -------------------------------------------------------------
    ' ELIMINA ESPACIOS A LA DERECHA
    ' -------------------------------------------------------------
    Public Shared Function RTrim(ByVal miCadena As String) As String
        Return miCadena.TrimEnd
    End Function

    ' -----------------------------------------------------------------------
    '  Search the specified string, with the case-sensitive mode or not
    ' Returns the index of the first occurrence found, or -1 if not found
    ' -----------------------------------------------------------------------
    Public Overloads Shared Function SearchString(ByVal source As String, ByVal search As String, _
        Optional ByVal ignoreCase As Boolean = False) As Integer
        Dim options As System.Text.RegularExpressions.RegexOptions
        ' set the search options according to the ignoreCase parameter
        If ignoreCase Then
            options = System.Text.RegularExpressions.RegexOptions.IgnoreCase
        Else
            options = System.Text.RegularExpressions.RegexOptions.None
        End If

        ' count the occurrences
        Dim m As System.Text.RegularExpressions.Match = _
            System.Text.RegularExpressions.Regex.Match(source, search, options)
        If m.Success Then
            Return m.Index
        Else
            Return -1
        End If
    End Function

    ' ---------------------------------------------------------------------
    ' Search the specified string, starting at the specified index,
    '  with the case-sensitive mode or not
    ' Returns the index of the first occurrence found, or -1 if not found
    ' ----------------------------------------------------------------------
    Public Overloads Shared Function SearchString(ByVal source As String, _
        ByVal startIndex As Integer, ByVal search As String, _
        Optional ByVal ignoreCase As Boolean = False) As Integer
        Dim i As Integer = SearchString(source.Substring(startIndex), search, _
            ignoreCase)
        If i = -1 Then
            Return -1
        Else
            Return i + startIndex
        End If
    End Function

    '------------------------------------------------------
    ' QUITA ACENTOS
    '------------------------------------------------------
    Public Shared Function SinAcentos(ByVal MiCadena As String) As String
        Dim Con As String, Sin As String, posCad As Long, i As Long
        Dim result As String, cad As String, subs As String

        Con = "á,é,í,ó,ú,Á,É,Í,Ó,Ú"    'caracteres con acentos
        Sin = "a,e,i,o,u,A,E,I,O,U"    'caracteres sin acentos
        result = ""

        For i = 0 To MiCadena.Length - 1      'verificar todos los bytes de la cadena
            cad = MiCadena.Substring(i, 1)    'extraer el byte indicado
            posCad = InStr(Con, cad)    'verificar si el byte es acentuado
            subs = ""
            If posCad > 0 Then          'Si es acentuado, entonces
                subs = CStr(posCad)       'Reemplazarlo por el que no es acentuado
            End If

            result = result + subs      'seguir con las demas bytes
        Next

        Return result
    End Function

    ' ----------------------------------------------------------------------
    ' DEVUELVE UNA CADENA, SOLO CON LOS CARACTERES ALFANUMERICOS QUE CONTIENE
    ' ----------------------------------------------------------------------
    Public Shared Function SoloAlfaNumerico(ByVal MiCadena As String) As String
        Return FilterString(MiCadena, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ")
    End Function

    '----------------------------------------------------------------------
    'DEVUELVE UNA CADENA, SOLO CON LOS CARACTERES NUMERICOS QUE CONTIENE
    '----------------------------------------------------------------------
    Public Shared Function SoloNumeros(ByVal Micadena As String) As String
        Return FilterString(Micadena, "0123456789")
    End Function

    '----------------------------------------------------
    ' DEVUELVE EL CODIGO FONETICO DE UNA CADENA
    '----------------------------------------------------
    Public Shared Function Soundex(ByVal MiCadena As String) As String
        Dim word As String, Result As String, i As Long, acode As Integer
        Dim dcode As Integer, oldCode As Integer
        word = MiCadena.ToUpper ' soundex is case-insensitive
        ' the first letter is copied in the result
        Result = Left(MiCadena, 1)
        oldCode = AscW(Mid("01230120022455012623010202", AscW(word) - 64))
        For i = 1 To Len(word) - 1
            acode = AscW(Mid(word, i, 1)) - 64
            ' discard non-alphabetic chars
            If acode >= 1 And acode <= 26 Then
                ' convert to a digit
                dcode = AscW(Mid("01230120022455012623010202", acode, 1))
                ' don't insert repeated digits
                If dcode <> 48 And dcode <> oldCode Then
                    Result = Result & ChrW(dcode)
                    If Len(Result) = 4 Then Exit For
                End If
                oldCode = dcode
            End If
        Next
        Return Result
    End Function

    ' ----------------------------------------------------------------------
    ' Check whether a string starts with one of multiple possible choices.
    ' Return -1 if no possible string matches the start of the source,
    '  otherwise return the index of the matching string.
    ' Examples:
    '    Debug.WriteLine(StartsWith("This is my test line", True, "this", "that")) ' => -1
    '    Debug.WriteLine(StartsWith("This is my test line", True, "That", "This")) ' => 1
    '    Debug.WriteLine(StartsWith("This is my test line", False,"this", "that")) ' => 0
    '    Debug.WriteLine(StartsWith("This is my test line", False, "That","Those")) ' => -1
    ' ----------------------------------------------------------------------
    Public Shared Function StartsWith(ByVal source As String, ByVal caseSensitive As Boolean, _
        ByVal ParamArray parts() As String) As Integer
        Dim i As Integer
        For i = 0 To parts.Length - 1
            Dim part As String = parts(i)
            If caseSensitive Then
                If source.StartsWith(part) Then Return i
            Else
                If source.ToLower().StartsWith(part.ToLower()) Then Return i
            End If
        Next
        ' if we get here, the source does not start with one of the possible
        ' choices, so return -1
        Return -1
    End Function

    '-------------------------------------------------------------------
    'QUITA TODOS LOS CARACTERES DE CONTROL DE LA CADENA (ASCII code < 32)
    ' If the second argument is True or omitted,
    ' CR-LF pairs are preserved
    '-------------------------------------------------------------------
    Public Shared Function StripControlChars(ByVal miCadena As String, Optional ByVal KeepCRLF As Boolean = True) As String
        ' we use this to build the result
        Dim sb As New System.Text.StringBuilder(miCadena.Length)
        Dim index As Integer
        For index = 0 To miCadena.Length - 1
            If Not Char.IsControl(miCadena, index) Then
                ' not a control char, so we can add to result
                sb.Append(miCadena.Chars(index))
            ElseIf KeepCRLF AndAlso miCadena.Substring(index, _
                2) = ControlChars.CrLf Then
                ' it is a CRLF, and the user asked to keep it
                sb.Append(miCadena.Chars(index))
            End If
        Next
        Return sb.ToString()
    End Function

    ' -------------------------------------------------------
    ' VERIFICA SI UNA CADENA TERMINA CON CIERTOS CARACTERES
    ' -------------------------------------------------------
    Public Shared Function TerminaCon(ByVal cadena As String, ByVal buscar As String) As Boolean
        Return cadena.EndsWith(buscar)
    End Function

    '------------------------------------------------------------
    ' Encode text in an HTML safe manner by delimiting
    ' special characters.
    ' Parameters: strIn - string to encode
    ' Returns   : Encoded string
    '------------------------------------------------------------
    Public Shared Function TextToHTML(ByVal strIn As String) As String
        Dim TempString As String
        TempString = strIn.Replace("&", "&amp;")
        TempString = TempString.Replace(">", "&gt;")
        TempString = TempString.Replace("<", "&lt;")
        TempString = TempString.Replace(Chr(34), "&quot;")
        Return TempString
    End Function

    ' -------------------------------------------------------------
    ' TRUNCAR UNA CADENA, A UN LARGO DETERMINADO.
    ' -------------------------------------------------------------
    Public Shared Function Truncar(ByVal cadena As String, ByVal nlargo As Integer) As String
        Return cadena.Substring(0, nlargo)
    End Function

    '----------------------------------------------------
    ' Verifica si una cadena coincide con el parametro LIKE
    '----------------------------------------------------
    Public Shared Function TxtLike(ByVal cad1 As String, ByVal Cad2 As String) As Boolean
        Return cad1 Like Cad2
    End Function

    ' --------------------------------------------------------------
    ' build a list of all the individual words in a string
    '
    ' returns a collection that contains all the unique words.
    ' The key for each item is the word itself
    ' so you can easily use the result collection to both
    ' enumerate the words and test whether a given word appears
    ' in the text. Words are inserted in the order they appear
    ' and are stored as lowercase strings.
    '
    ' Numbers are ignored, but digit characters are preserved
    ' if they appear in the middle or at the end of a word.
    ' --------------------------------------------------------------
    Public Shared Function UniqueWords(ByVal Text As String) As Collection
        Dim thisWord As String
        Dim i As Long
        Dim wordStart As Long
        Dim varWord As Object
        Dim res As String
        ' prepare the result collection
        UniqueWords = New Collection
        ' ignore duplicate words
        On Error Resume Next
        ' extract all words from the text
        For i = 1 To Len(Text)
            Select Case Asc(Mid$(Text, i, 1))
                Case 65 To 90, 97 To 122
                    ' an alpha char
                    If wordStart = 0 Then wordStart = i
                Case 48 To 57
                    ' include digits only if suffix of a word (as in "ABCD23")
                Case Else
                    If wordStart Then
                        ' extract the word
                        thisWord = LCase$(Mid$(Text, wordStart, i - wordStart))
                        ' add to the collection, but ignore if already there
                        UniqueWords.Add(thisWord, thisWord)
                        ' reset the flag/pointer
                        wordStart = 0
                    End If
            End Select
        Next
        ' account for the last word
        If wordStart Then
            ' extract the word
            thisWord = LCase$(Mid$(Text, wordStart, i - wordStart))
            ' add to the collection, but ignore if already there
            UniqueWords.Add(thisWord, thisWord)
        End If
    End Function
    Public Shared Function EncryptarString(ByVal InputString As String, ByVal SecretKey As String, Optional ByVal CyphMode As CipherMode = CipherMode.ECB) As String
        Try
            Dim Des As New TripleDESCryptoServiceProvider
            'Put the string into a byte array
            Dim InputbyteArray() As Byte = Encoding.UTF8.GetBytes(InputString)
            'Create the crypto objects, with the key, as passed in
            Dim hashMD5 As New MD5CryptoServiceProvider
            Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretKey))
            Des.Mode = CyphMode
            Dim ms As MemoryStream = New MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateEncryptor(), _
            CryptoStreamMode.Write)
            'Write the byte array into the crypto stream
            '(It will end up in the memory stream)
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()
            'Get the data back from the memory stream, and into a string
            Dim ret As StringBuilder = New StringBuilder
            Dim b() As Byte = ms.ToArray
            ms.Close()
            Dim I As Integer
            For I = 0 To UBound(b)
                'Format as hex
                ret.AppendFormat("{0:X2}", b(I))
            Next

            Return ret.ToString()
        Catch ex As System.Security.Cryptography.CryptographicException

            Return ""
        End Try

    End Function

    Public Shared Function DecryptarString(ByVal InputString As String, ByVal SecretKey As String, Optional ByVal CyphMode As CipherMode = CipherMode.ECB) As String
        If InputString = String.Empty Then
            Return ""
        Else
            Dim Des As New TripleDESCryptoServiceProvider
            'Put the string into a byte array
            Dim InputbyteArray(CType(InputString.Length / 2 - 1, Integer)) As Byte '= Encoding.UTF8.GetBytes(InputString)
            'Create the crypto objects, with the key, as passed in
            Dim hashMD5 As New MD5CryptoServiceProvider

            Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretKey))
            Des.Mode = CyphMode
            'Put the input string into the byte array

            Dim X As Integer

            For X = 0 To InputbyteArray.Length - 1
                Dim IJ As Int32 = (Convert.ToInt32(InputString.Substring(X * 2, 2), 16))
                Dim BT As New ByteConverter
                InputbyteArray(X) = New Byte
                InputbyteArray(X) = CType(BT.ConvertTo(IJ, GetType(Byte)), Byte)
            Next

            Dim ms As MemoryStream = New MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateDecryptor(), _
            CryptoStreamMode.Write)

            'Flush the data through the crypto stream into the memory stream
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()

            '//Get the decrypted data back from the memory stream
            Dim ret As StringBuilder = New StringBuilder
            Dim B() As Byte = ms.ToArray

            ms.Close()

            Dim I As Integer

            For I = 0 To UBound(B)
                ret.Append(Chr(B(I)))
            Next

            Return ret.ToString()
        End If
    End Function
#End Region 'Methods

End Class