Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Logging

Imports System.Data.Common

Public Class ArtListingDAO
    Private Shared Function GetArtListingFromDataReader(ByVal dr As IDataReader) As IArtListing
        Dim artListing As IArtListing

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
        artListing.State = Utilities.GetFieldValue(dr("stateCD"))
        'If dr("stateCD") IsNot DBNull.Value Then
        'artListing.State = StateDAO.GetStateByID(dr("stateCD"))
        'End If

        If dr("personId") IsNot DBNull.Value Then
            artListing.Person = PersonDAO.GetPersonByID(dr("personId"))
        End If

        Return artListing
    End Function

    Private Shared Function GetDataReader(ByVal sql As String) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Return dr
    End Function
    Public Shared Function GetAllArtListings() As List(Of IArtListing)
        Dim dr As IDataReader = GetDataReader(ConstantsLibrary.ALL_ART_LISTINGS)

        Dim listings As New List(Of IArtListing)

        Try
            Logger.Write("Starting to execute: " & ConstantsLibrary.ALL_ART_LISTINGS)
            While dr.Read()
                listings.Add(GetArtListingFromDataReader(dr))
            End While
            Logger.Write("Retrieved " & listings.Count & " artListings.")
        Catch ex As Exception
            Logger.Write("An error occurred during query: " & ex.Message)
            Throw New Exception("An error occurred getting all ArtListings.", ex)
        Finally
            dr.Close()
            dr = Nothing
            Logger.Write("Closed connection and cleared objects")
        End Try

        Return listings
    End Function

    Public Shared Function GetArtListingByPerson(ByVal id As String) As IArtListing
        Dim sql As String = "SELECT * FROM ArtListing WHERE personId = '" & id & "'"
        Dim dr As IDataReader = GetDataReader(sql)

        Dim artListing As IArtListing = Nothing

        Try
            Logger.Write("Started executing: " & sql)

            dr.Read()
            artListing = GetArtListingFromDataReader(dr)

        Catch ex As Exception
            Logger.Write("An error occurring during retrieval: " & ex.Message)
            Throw New Exception("An error occurred finding ArtListing with PK: " & id, ex)
        Finally
            dr.Close()
            dr = Nothing
            Logger.Write("Closed connection and cleared objects")
        End Try

        Return artListing
    End Function

    Public Shared Function GetArtListingByID(ByVal id As Integer) As IArtListing
        Dim sql As String = "SELECT * FROM ArtListing WHERE listId = " & id
        Dim dr As IDataReader = GetDataReader(sql)

        Dim artListing As IArtListing = Nothing

        Try
            Logger.Write("Started executing: " & sql)

            dr.Read()
            artListing = GetArtListingFromDataReader(dr)

        Catch ex As Exception
            Logger.Write("An error occurring during retrieval: " & ex.Message)
            Throw New Exception("An error occurred finding ArtListing with PK: " & id, ex)
        Finally
            dr.Close()
            dr = Nothing

            Logger.Write("Closed connection and cleared objects")
        End Try

        Return artListing
    End Function

    Public Shared Sub DeleteArtListing(ByVal artListing As ArtListing)
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
        Dim sql As String = ConstantsLibrary.SQL_CREATE_NEW_ART_LISTING(artListing)
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

    Public Shared Sub UpdateArtListing(ByVal artListing As ArtListing)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "UPDATE ArtListing SET " _
                            & "listName = '" & artListing.Name _
                            & "', listPhone = '" & artListing.PhoneNumber _
                            & "', listAddress1 = '" & artListing.AddressOne _
                            & "', listAddress2 = '" & artListing.AddressTwo _
                            & "', listCity = '" & artListing.City _
                            & "', listZip = '" & artListing.Zipcode _
                            & "', listEmail = '" & artListing.Email _
                            & "', activeYN = '" & artListing.IsActive _
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

    Public Shared Function GetArtListingsByArtist(ByVal parameter As String) As List(Of IArtListing)
        Dim sql As String = ConstantsLibrary.SQL_GET_ART_LISTINGS_BY_ARTIST(parameter)
        Dim dr As IDataReader = GetDataReader(sql)

        Dim listings As New List(Of IArtListing)

        Try
            While dr.Read()
                listings.Add(GetArtListingFromDataReader(dr))
            End While
        Catch ex As Exception
            Throw New Exception("A problem occurred while searching for listings by Artist.", ex)
        Finally
            dr.Close()
            dr = Nothing
        End Try

        Return listings
    End Function

    Public Shared Function GetArtListingsByCategory(ByVal parameter As String) As List(Of IArtListing)
        Dim sql As String = ConstantsLibrary.SQL_GET_ART_LISTINGS_BY_CATEGORY(parameter)
        Dim dr As IDataReader = GetDataReader(sql)

        Dim listings As New List(Of IArtListing)

        Try
            Logger.Write("Starting to execute: " & sql)
            While dr.Read()
                listings.Add(GetArtListingFromDataReader(dr))
            End While
        Catch ex As Exception
            Throw New Exception("Error getting Listings by Category.", ex)
        Finally
            dr.Close()
            dr = Nothing
        End Try

        Return listings
    End Function
End Class
