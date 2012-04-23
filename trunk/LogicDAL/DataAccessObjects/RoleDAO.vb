Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Logging

Imports System.Data.Common

Public Class RoleDAO

    Public Shared Function GetRoleByID(ByVal id As String) As IRole
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.SQL_GET_ROLE_BY_ID(id)
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim role As IRole = Nothing

        Logger.Write("Beginning execution of: " & sql)
        Try
            dr.Read()
            role = New Role(Utilities.GetFieldValue(dr("RoleID")))
            role.Description = Utilities.GetFieldValue(dr("Description"))

        Catch ex As Exception
            Throw New Exception("Could not retrieve Role with ID: " & id, ex)
        Finally
            dr.Close()
            dr = Nothing
            cmd = Nothing
            db = Nothing
        End Try

        Return role
    End Function

End Class
