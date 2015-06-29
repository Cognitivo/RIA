Imports System.Reflection.Assembly
Imports System.IO

Public Class Sistema

    #Region "Methods"

    '<summary>
    ' Devuelve el nombre del ejecutable.
    ' Al usarse desde una librería (DLL), hay que usar GetCallingAssembly
    ' para que devuelva el nombre del ejecutable (o librería) que llama a esta función.
    ' Si no se usa GetCallingAssembly, devolvería el nombre de esta librería.
    '</summary>
    '<param name="fullPath">Opcional. True si debe devolver nombre completo.</param>
    '<returns>El nombre del ejecutable, con o sin el path completo, según el valor del parámetro.
    '</returns>
    Public Function AppExeName(Optional ByVal fullPath As Boolean = False) As String
        Dim s As String = GetExecutingAssembly.GetCallingAssembly.Location
        Dim fi As New IO.FileInfo(s)
        If fullPath Then
            s = fi.FullName
        Else
            s = fi.Name
        End If
        '
        Return s
    End Function

    '''<summary>
    ''' Devuelve el path de la aplicación.
    ''' Al usarse desde una librería (DLL), hay que usar GetCallingAssembly
    ''' para que devuelva el path del ejecutable (o librería) que llama a esta función.
    ''' Si no se usa GetCallingAssembly, devolvería el path de la librería.
    '''</summary>
    '''<param name="backSlash">Opcional. True si debe devolver el path terminado en \</param>
    '''<returns>
    ''' El path de la aplicación con o sin backslash, según el valor del parámetro.
    '''</returns>
    Public Function AppPath(Optional ByVal backSlash As Boolean = False) As String
        Dim s As String = IO.Path.GetDirectoryName(GetExecutingAssembly.GetCallingAssembly.Location)
        ' si hay que añadirle el backslash
        If backSlash Then
            s &= "\"
        End If
        Return s
    End Function

    '''<summary>
    ''' Devuelve el nombre de esta librería.
    '''</summary>
    '''<param name="fullPath">Opcional. True si debe devolver nombre completo.</param>
    '''<returns>El nombre de esta librería, con o sin el path completo, según el valor del parámetro.
    '''</returns> 
    Public Function DLLName(Optional ByVal fullPath As Boolean = False) As String
        Dim s As String = GetExecutingAssembly.Location
        Dim fi As New IO.FileInfo(s)
        If fullPath Then
            s = fi.FullName
        Else
            s = fi.Name
        End If
        '
        Return s
    End Function

    '''<summary>
    ''' Devuelve el path de esta librería.
    '''</summary>
    '''<param name="backSlash">Opcional. True si debe devolver el path terminado en \
    '''</param>
    '''<returns>
    ''' El path de esta librería, con o sin backslash, según el valor del parámetro.
    '''</returns>
    Public Function DLLPath(Optional ByVal backSlash As Boolean = False) As String
        Dim s As String = IO.Path.GetDirectoryName(GetExecutingAssembly.Location)
        ' si hay que añadirle el backslash
        If backSlash Then
            s &= "\"
        End If
        Return s
    End Function

    #End Region 'Methods

End Class