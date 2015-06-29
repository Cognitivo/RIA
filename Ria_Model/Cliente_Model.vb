Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad
Public Class Cliente_Model
    Dim SQLConn As System.Data.Common.DbConnection
    Dim ser As New BDConexión.BDConexion
    Dim SQLCmd As New SqlCommand
    Dim SQLRdr As SqlDataReader

    Function InsertarCliente(ByVal codUsuario As Integer, codVendedor As String, NumCliente As Integer, Nombre As String, RUC As String, _
                        Direccion As String, Telefono As String, LimCredito As Integer, FechaIngreso As Date, DirEnvio As String, NumeroTol As String, _
                        FechaNacimiento As Date, CodPais As String, EmpresaCliente As String, ProveedorId As Integer, Telefono1 As String, _
                        dv As Integer, CustomField As String, TipoRelacion As Integer, relacion As Integer, SEPSA As String, Autorizado As Integer, Sexo As Integer)
        Try
            SQLConn = ser.Abrir
            SQLCmd = New SqlCommand(" INSERT INTO CLIENTES ([CODUSUARIO],[CODVENDEDOR],[NUMCLIENTE],[NOMBRE],[RUC],[DIRECCION],[TELEFONO],[LIMCREDITO],[FECHAINGRESO],[DIRENVIO]," & _
                                    " [NUMEROTOL],[FECHANACIMIENTO],[EMPPRESACLIENTE],[PROVEEDOR_ID],[TELEFONO1],[DV],[CUSTOMFIELD],[TIPORELACION],[RELACION],[SEPSA], [AUTORIZADO],Sexo)" & _
                                    " values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23)", SQLConn)
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@1", codUsuario))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@2", SqlDbType.NVarChar))
            'SQLCmd.Parameters("@2").Value = "NULL".ToString
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@3", NumCliente))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@4", Nombre))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@5", RUC))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@6", Direccion))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@7", Telefono))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@8", LimCredito))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@9", FechaIngreso))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@10", DirEnvio))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@11", NumeroTol))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@12", FechaNacimiento))
            ''SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@13", "NULL"))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@14", EmpresaCliente))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@15", ProveedorId))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@16", Telefono1))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@17", dv))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@18", CustomField))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@19", TipoRelacion))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@20", relacion))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@21", SEPSA))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@22", Autorizado))
            'SQLCmd.Parameters.Add(New SqlClient.SqlParameter("@23", Sexo))

            SQLCmd.ExecuteNonQuery()


        Catch ex As Exception

        End Try
        'Dim Sql As String = " INSERT INTO CLIENTES ([CODUSUARIO],[CODVENDEDOR],[NUMCLIENTE],[NOMBRE],[RUC],[DIRECCION],[TELEFONO],[LIMCREDITO],[FECHAINGRESO],[DIRENVIO]," & _
        '                    " [NUMEROTOL],[FECHANACIMIENTO],[CODPAIS],[EMPPRESACLIENTE],[PROVEEDOR_ID],[TELEFONO1],[DV],[CUSTOMFIELD],[TIPORELACION],[RELACION],[SEPSA], [AUTORIZADO],Sexo) " & _
        '                    " VALUES(" & codUsuario & "," & codVendedor & "," & NumCliente & "," & Nombre & "," & RUC & "," & Direccion & "," & Telefono & "," & LimCredito & "," & _
        '                  " CONVERT(DATETIME,'" & FechaIngreso & "',103)" & "," & DirEnvio & "," & NumeroTol & "," & " CONVERT(DATETIME,'" & FechaNacimiento & "',103)" & "," & CodPais & "," & EmpresaCliente & "," & ProveedorId & "," & _
        '                 Telefono1 & "," & dv & "," & CustomField & "," & TipoRelacion & "," & relacion & "," & SEPSA & "," & Autorizado & "," & Sexo & ")" & _
        '                " SELECT CODCLIENTE FROM CLIENTES WHERE CODCLIENTE = SCOPE_IDENTITY()" & _
        '                " UPDATE CLIENTES SET RELACION = SCOPE_IDENTITY() WHERE CODCLIENTE = SCOPE_IDENTITY()"
    End Function

    Sub InsertarAdherente(ByVal SQL As String)
        '  Dim sqlQuery As New Ria_DataAccessLayer.exeSQLQuery
        'sqlQuery.SQLQuery_Execute(SQL)
    End Sub
End Class
