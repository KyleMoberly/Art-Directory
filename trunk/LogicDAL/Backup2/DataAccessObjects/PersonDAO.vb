Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Logging

Imports System.Data.Common

Public Class PersonDAO

    Public Shared Function GetAllPersons() As List(Of IPerson)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.ALL_PERSONS
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim people As New List(Of IPerson)
        Dim aPerson As IPerson

        Try
            Logger.Write("Starting to execute: " & sql)
            While dr.Read()
                aPerson = New Person(Utilities.GetFieldValue(dr("personId")))
                aPerson.Password = Utilities.GetFieldValue(dr("personPass"))
                aPerson.LastName = Utilities.GetFieldValue(dr("personLastName"))
                aPerson.FirstName = Utilities.GetFieldValue(dr("personFirstName"))
                aPerson.Email = Utilities.GetFieldValue(dr("personEmail"))
                aPerson.DateLastModified = Utilities.GetFieldValue(dr("modDt"))

                If dr("RoleID") IsNot DBNull.Value Then
                    aPerson.Role = RoleDAO.GetRoleByID(dr("RoleID"))
                End If

                people.Add(aPerson)
            End While
            Logger.Write("Found " & people.Count & " people.")
        Catch ex As Exception
            Logger.Write("An error occured during retrieval: " & ex.Message)
        Finally
            dr.Close()
            dr = Nothing
            db = Nothing
            cmd = Nothing
            Logger.Write("Cleared Objects")
        End Try

        Return people
    End Function

    Public Shared Sub CreatePerson(ByVal thePerson As IPerson)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "INSERT INTO Person (personId, personFirstName, personLastName, personPass, personEmail, modDt, RoleID)" _
                            & "VALUES ('" _
                            & thePerson.PrimaryKey & "','" _
                            & thePerson.FirstName & "','" _
                            & thePerson.LastName & "','" _
                            & thePerson.Password & "','" _
                            & thePerson.Email & "','" _
                            & thePerson.DateLastModified & "','" _
                            & thePerson.Role.RoleID & "')"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Logger.Write("Starting to execute: " & sql)
            Dim rowsAffected = db.ExecuteNonQuery(cmd)

            If rowsAffected > 0 Then
                Logger.Write("Create on person: " & thePerson.PrimaryKey & " was successful.")
            Else
                Logger.Write("Could not create person: " & thePerson.PrimaryKey)
            End If
        Catch ex As Exception
            Logger.Write("An error occurred during insert: " & ex.Message)
        End Try

        db = Nothing
        Logger.Write("Cleared DB")
    End Sub

    Public Shared Function GetPersonByID(ByVal id As String) As IPerson
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "SELECT * FROM Person WHERE personId = '" & id & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim thePerson As IPerson = Nothing

        Try
            Logger.Write("Starting to execute: " & sql)
            dr.Read()
            thePerson = New Person(dr("personId"))

            thePerson.DateLastModified = Utilities.GetFieldValue(dr("modDt"))
            thePerson.Email = Utilities.GetFieldValue(dr("personEmail"))
            thePerson.FirstName = Utilities.GetFieldValue(dr("personFirstName"))
            thePerson.LastName = Utilities.GetFieldValue(dr("personLastName"))
            thePerson.Password = Utilities.GetFieldValue(dr("personPass"))

            If dr("RoleID") IsNot DBNull.Value Then
                thePerson.Role = RoleDAO.GetRoleByID(dr("RoleID"))
            End If

        Catch ex As Exception
            Logger.Write("An error occurred during retrieval: " & ex.Message)
        Finally
            dr.Close()
            dr = Nothing
            cmd = Nothing
            db = Nothing
        End Try

        Return thePerson
    End Function

    Public Shared Sub DeletePerson(ByVal thePerson As IPerson)
        thePerson = CType(thePerson, Person)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "DELETE FROM Person WHERE personId = '" & thePerson.PrimaryKey & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(Sql)

        Try
            Logger.Write("Starting to execute: " & Sql)
            Dim rowsAffected = db.ExecuteNonQuery(cmd)

            If rowsAffected > 0 Then
                Logger.Write("Delete on person: " & thePerson.PrimaryKey & " was successful.")
            Else
                Logger.Write("Could not delete person: " & thePerson.PrimaryKey)
            End If
        Catch ex As Exception
            Logger.Write("An error occurred during delete: " & ex.Message)
        End Try

        db = Nothing
        Logger.Write("Cleared DB")
    End Sub

    Public Shared Sub UpdatePerson(ByVal person As IPerson)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "UPDATE Person SET " _
                            & "personPass = '" & person.Password _
                            & "', personFirstName = '" & person.FirstName _
                            & "', personLastName = '" & person.LastName _
                            & "', personEmail = '" & person.Email _
                            & "', modDt = '" & DateTime.Now _
                            & "', RoleID = '" & person.Role.RoleID _
                            & "' WHERE personId = '" & person.PrimaryKey & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Logger.Write("Starting to execute: " & sql)
            Dim rowsAffected = db.ExecuteNonQuery(cmd)

            If rowsAffected > 0 Then
                Logger.Write("Update on person: " & person.PrimaryKey & " was successful.")
            Else
                Logger.Write("Could not update person: " & person.PrimaryKey)
            End If
        Catch ex As Exception
            Logger.Write("An error occurred during update: " & ex.Message)
        End Try

        db = Nothing
        Logger.Write("Cleared DB")
    End Sub

End Class
