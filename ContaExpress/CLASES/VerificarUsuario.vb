Imports System.Data.SqlClient


Module VerificarUsuario

    Dim f As New Funciones.Funciones
    Dim PermisoUsuario As Double


    Public Function PermisoAplicado(ByVal UsuarioId As Integer, ByVal PermisoId As Integer) As Double

        PermisoUsuario = f.FuncionConsultaDecimal("Permiso", "PERMISOSAPLICADOS", "Usuario_id=" & UsuarioId & " AND Permiso_Id", PermisoId)

        Return PermisoUsuario
    End Function
End Module
