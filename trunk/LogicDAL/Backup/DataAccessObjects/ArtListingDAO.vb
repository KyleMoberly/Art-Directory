Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Logging

Imports System.Data.Common

Public Class ArtListingDAO

    Public Shared Function GetAllArtListings() As List(Of IArtListing)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim cmd As DbCommand = db.GetSqlStringCommand(ConstantsLibrary.ALL_ART_LISTINGS)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim listings As New List(Of IArtListing)
        Dim artListing As IArtListing

        Try
            Logger.Write("Starting to execute: " & ConstantsLibrary.ALL_ART_LISTINGS)
            While dr.Read()
                artListing = New ArtListing(dr("listId"))
                artListing.AddressOne = Utilities.GetFieldValue(dr("listAddress1"))
                artListing.AddressTwo = Utilities.GetFieldValue(dr("listAddress2"))
                artListing.City = Utilities.GetFieldValue(dr("listCity"))
                artListing.DateLastModified = Utilities.GetFieldValue(dr("modDt"))
                artListing.Description = Utilities.GetFieldValue(dr("listDescription"))
                artListing.Email = Utilities.GetFieldValue(dr("listEmail"))
                artListing.ImagePath = Utilities.GetFieldValue(dr("listPhoto"))
                artListing.IsActive = Utilities.GetFieldValue(dr("activeYN"))
                artListing.IsFeatured = Utilities.GetFieldValue(dr("listFeaturedYN"))
                artListing.Name = Utilities.GetFieldValue(dr("listName"))
                artListing.PhoneNumber = Utilities.GetFieldValue(dr("listPhone"))
                artListing.URL = Utilities.GetFieldValue(dr("listURL"))
                artListing.Zipcode = Utilities.GetFieldValue(dr("listZip"))

                If dr("stateCD") IsNot DBNull.Value Then
                    artListing.State = StateDAO.GetStateByID(dr("stateCD"))
                End If

                If dr("personId") IsNot DBNull.Value Then
                    artListing.Person = PersonDAO.GetPersonByID(dr("personId"))
                End If

                listings.Add(artListing)
            End While
            Logger.Write("Retrieved " & listings.Count & " artListings.")
        Catch ex As Exception
            Logger.Write("An error occurred during query: " & ex.Message)
            Throw New Exception("An error occurred getting all ArtListings.", ex)
        Finally
            dr.Close()
            dr = Nothing
            db = Nothing
            cmd = Nothing
            Logger.Write("Closed connection and cleared objects")
        End Try

        Return listings
    End Function

    Public Shared Function GetArtListingByID(ByVal id As Integer) As IArtListing
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "SELECT * FROM ArtListing WHERE listId = " & id
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim artListing As IArtListing = Nothing

        Try
            Logger.Write("Started executing: " & sql)
            dr.Read()
            artListing = New ArtListing(dr("listId"))
            artListing.AddressOne = Utilities.GetFieldValue(dr("listAddress1"))
            artListing.AddressTwo = Utilities.GetFieldValue(dr("listAddress2"))
            artListing.City = Utilities.GetFieldValue(dr("listCity"))
            artListing.DateLastModified = Utilities.GetFieldValue(dr("modDt"))
            artListing.Description = Utilities.GetFieldValue(dr("listDescription"))
            artListing.Email = Utilities.GetFieldValue(dr("listEmail"))
            artListing.ImagePath = Utilities.GetFieldValue(dr("listPhoto"))
            artListing.IsActive = Utilities.GetFieldValue(dr("activeYN"))
            artListing.IsFeatured = Utilities.GetFieldValue(dr("listFeaturedYN"))
            artListing.Name = Utilities.GetFieldValue(dr("listName"))
            artListing.PhoneNumber = Utilities.GetFieldValue(dr("listPhone"))
            artListing.URL = Utilities.GetFieldValue(dr("listURL"))
            artListing.Zipcode = Utilities.GetFieldValue(dr("listZip"))

            If dr("stateCD") IsNot DBNull.Value Then
                artListing.State = StateDAO.GetStateByID(dr("stateCD"))
            End If

            If dr("personId") IsNot DBNull.Value Then
                artListing.Person = PersonDAO.GetPersonByID(dr("personId"))
            End If

        Catch ex As Exception
            Logger.Write("An error occurring during retrieval: " & ex.Message)
            Throw New Exception("An error occurred finding ArtListing with PK: " & id, ex)
        Finally
            dr.Close()
            dr = Nothing
            db = Nothing
            cmd = Nothing
            Logger.Write("Closed connection and cleared objects")
        End Try

        Return artListing
    End Function

    Public Shared Sub DeleteArtListing(ByVal artListing As IArtListing)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "DELETE FROM ArtListing Where listId = " & artListing.PrimaryKey
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Logger.Write("Starting to execute: " & sql)
            Dim rowsAffected As Integer = db.ExecuteNonQuery(cmd)

            If rowsAffected > 0 Then
                Logger.Write("Successfully deleted ArtListing with PK: " & artListing.PrimaryKey)
            Else
                Logger.Write("ArtListing was not deleted")
            End If
        Catch ex As Exception
            Logger.Write("An errored occurred while deleted ArtListing: " & ex.Message)
            Throw New Exception("An Error occurred trying to delete ArtListing with PK: " & artListing.PrimaryKey, ex)
        Finally
            db = Nothing
            Logger.Write("Clearing DB")
        End Try
    End Sub

    Public Shared Sub CreateArtListing(ByVal artListing As IArtListing)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "INSERT INTO ArtListing " _
                            & "(listName, listPhone, listAddress1, listAddress2, listCity, stateCD, listZip, listEmail, personId, activeYN, modDt, listUrl, listFeaturedYN, listPhoto, listDescription)" _
                            & "VALUES ('" _
                            & artListing.Name & "','" _
                            & artListing.PhoneNumber & "','" _
                            & artListing.AddressOne & "','" _
                            & artListing.AddressTwo & "','" _
                            & artListing.City & "','" _
                            & artListing.State.StateCode & "','" _
                            & artListing.Zipcode & "','" _
                            & artListing.Email & "','" _
                            & artListing.Person.PrimaryKey & "','" _
                            & artListing.IsActive.ToString() & "','" _
                            & artListing.DateLastModified.ToString() & "','" _
                            & artListing.URL & "','" _
                            & artListing.IsFeatured.ToString() & "','" _
                            & artListing.ImagePath & "','" _
                            & artListing.Description & "')"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Logger.Write("Starting to execute: " & sql)
            Dim rowsAffected As Integer = db.ExecuteNonQuery(cmd)

            If rowsAffected > 0 Then
                Logger.Write("Successfully created new ArtListing")
            Else
                Logger.Write("ArtListing was not inserted")
            End If
        Catch ex As Exception
            Logger.Write("An errored occurred while inserting ArtListing: " & ex.Message)
            Throw New Exception("An error occurred while inserting new ArtListing.", ex)
        Finally
            db = Nothing
            Logger.Write("Clearing DB")
        End Try
    End Sub

    Public Shared Sub UpdateArtListing(ByVal artListing As IArtListing)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "UPDATE ArtListing SET " _
                            & "listName = '" & artListing.Name _
                            & "', listPhone = '" & artListing.PhoneNumber _
                            & "', listAddress1 = '" & artListing.AddressOne _
                            & "', listAddress2 = '" & artListing.AddressTwo _
                            & "', listCity = '" & artListing.City _
                            & "', stateCD = '" & artListing.State.StateCode _
                            & "', listZip = '" & artListing.Zipcode _
                            & "', listEmail = '" & artListing.Email _
                            & "', personId = " & artListing.Person.PrimaryKey _
                            & ", activeYN = '" & artListing.IsActive _
                            & "', modDt = '" & artListing.DateLastModified _
                            & "', listUrl = '" & artListing.URL _
                            & "', listFeaturedYN = '" & artListing.IsFeatured _
                            & "', listPhoto = '" & artListing.ImagePath _
                            & "', listDescription = '" & artListing.Description _
                            & "' WHERE listId = " & artListing.PrimaryKey
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Logger.Write("Starting to execute: " & sql)
            Dim rowsAffected = db.ExecuteNonQuery(cmd)

            If rowsAffected > 0 Then
                Logger.Write("Succesfully updated ArtListing: " & artListing.PrimaryKey)
            Else
                Logger.Write("An error occurred udpating ArtListing: " & artListing.PrimaryKey)
            End If
        Catch ex As Exception
            Logger.Write("An error occurred during update: " & ex.Message)
            Throw New Exception("An error occurred updating ArtListing with PK: " & artListing.PrimaryKey, ex)
        Finally
            db = Nothing
            Logger.Write("Clearing DB")
        End Try
    End Sub
End Class
