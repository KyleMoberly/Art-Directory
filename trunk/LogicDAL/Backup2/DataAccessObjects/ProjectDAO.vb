Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common

Imports System.Data.Common

Public Class ProjectDAO

    Public Shared Function ListAllProjects() As List(Of IProject)
        Logger.Write("Begin 'ProjectDAO.ListProjects()'")
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim cmd As DbCommand = db.GetSqlStringCommand(ConstantsLibrary.ALL_PROJECTS)
        Dim dr As IDataReader = db.ExecuteReader(cmd)
        Dim aProject As IProject
        Dim projects As New List(Of IProject)

        Logger.Write("Starting to execute: " & ConstantsLibrary.ALL_PROJECTS)
        Try
            While dr.Read()
                aProject = New Project(Utilities.GetFieldValue(dr("projectID")))
                aProject.Name = Utilities.GetFieldValue(dr("projectName"))
                aProject.Dates = Utilities.GetFieldValue(dr("projectDates"))
                aProject.URL = Utilities.GetFieldValue(dr("projectURL"))
                aProject.Description = Utilities.GetFieldValue(dr("projectDesc"))
                aProject.ArtListing = Utilities.GetFieldValue(dr("listId"))
                'If dr("listId") IsNot Nothing Then
                'aProject.ArtListing = ArtListingDAO.GetArtListingByID(dr("listId"))
                'End If

                projects.Add(aProject)
            End While
        Catch ex As Exception
            Throw New Exception("Error Getting all projects.", ex)
            'Logger.Write("Error Occurred Finding All Projects: " & ex.Message)
        Finally
            dr.Close()
            cmd = Nothing
            dr = Nothing
            db = Nothing
            Logger.Write("Cleared Reader, Cmd, and DB objects")
        End Try
        Logger.Write("Found " & projects.Count.ToString() & " Projects")

        Return projects
    End Function

    Public Shared Sub DeleteProject(ByVal project As IProject)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "DELETE FROM Projects Where projectID = '" & project.PrimaryKey & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim rowsAffected As Integer

        Try
            Logger.Write("Starting to execute: " & sql)
            rowsAffected = db.ExecuteNonQuery(cmd)
        Catch ex As Exception
            Throw New Exception("Error Deleting Project.", ex)
            'Logger.Write("Error occurred deleting state with PK: " & project.PrimaryKey & " - " _
            '           & ex.Message)
        Finally
            db = Nothing
            cmd = Nothing
            Logger.Write("Cleared db and cmd objects")
        End Try

        Logger.Write("Project with key " & project.PrimaryKey & " was deleted.")
        Logger.Write(rowsAffected & " rows were affected.")
    End Sub

    Public Shared Function GetProjectByID(ByVal id As Integer) As IProject
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "SELECT * FROM Projects WHERE projectId = '" & id & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)
        Dim aProject As IProject = Nothing

        Try
            Logger.Write("Starting to execute: " & sql)
            dr.Read()
            aProject = New Project(Utilities.GetFieldValue(dr("projectID")))
            aProject.Name = Utilities.GetFieldValue(dr("projectName"))
            aProject.Dates = Utilities.GetFieldValue(dr("projectDates"))
            aProject.URL = Utilities.GetFieldValue(dr("projectUrl"))
            aProject.Description = Utilities.GetFieldValue(dr("projectDesc"))
            aProject.ArtListing = Utilities.GetFieldValue(dr("listId"))
            'If dr("listId") IsNot Nothing Then
            'aProject.ArtListing = ArtListingDAO.GetArtListingByID(dr("listId"))
            'End If

        Catch ex As Exception
            Throw New Exception("Error retrieving project with id: " & id, ex)
            'Logger.Write("Exception Occurred during Retrieval: " & ex.Message)
        Finally
            dr.Close()
            cmd = Nothing
            dr = Nothing
            db = Nothing
            Logger.Write("Cleared Reader, Cmd, and DB objects")
        End Try

        Return aProject
    End Function

    Public Shared Function GetProjectArtListing(ByVal id As Integer) As IProject
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "SELECT * FROM Projects WHERE listId = '" & id & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)
        Dim aProject As IProject = Nothing

        Try
            Logger.Write("Starting to execute: " & sql)
            dr.Read()
            aProject = New Project(dr("projectID"))
            aProject.Name = Utilities.GetFieldValue(dr("projectName"))
            aProject.Dates = Utilities.GetFieldValue(dr("projectDates"))
            aProject.URL = Utilities.GetFieldValue(dr("projectUrl"))
            aProject.Description = Utilities.GetFieldValue(dr("projectDesc"))
            aProject.ArtListing = Utilities.GetFieldValue(dr("listId"))
            'If dr("listId") IsNot Nothing Then
            'aProject.ArtListing = ArtListingDAO.GetArtListingByID(dr("listId"))
            'End If

        Catch ex As Exception
            Throw New Exception("Error retrieving project with id: " & id, ex)
            'Logger.Write("Exception Occurred during Retrieval: " & ex.Message)
        Finally
            dr.Close()
            cmd = Nothing
            dr = Nothing
            db = Nothing
            Logger.Write("Cleared Reader, Cmd, and DB objects")
        End Try

        Return aProject
    End Function

    Public Shared Sub CreateProject(ByVal newProject As IProject)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "INSERT INTO Projects (projectName, projectDates, projectURL, projectDesc, listId) VALUES ('" _
                            & newProject.Name & "','" & newProject.Dates & "','" & newProject.URL & "','" & newProject.Description & "'," & newProject.ArtListing & ")"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try

            Logger.Write("Starting to Execute: " & sql)
            Dim rowsAffected As Integer = db.ExecuteNonQuery(cmd)
            Logger.Write(rowsAffected & " project was inserted with values: " & newProject.PrimaryKey & " " & newProject.Name & " " & newProject.Dates & " " & newProject.URL & " " & newProject.Description & " " & newProject.ArtListing)
        Catch ex As Exception
            Throw New Exception("Error creating new project.", ex)
            'Logger.Write("An error occurred creating the project: " & ex.Message)
        End Try

        db = Nothing
        cmd = Nothing
        Logger.Write("Cleared Objects")
    End Sub


    Public Shared Sub UpdateProject(ByVal aProject As IProject)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "UPDATE Projects SET " _
                            & "projectName = '" & aProject.Name _
                            & "', projectDates = '" & aProject.Dates _
                            & "', projectURL = '" & aProject.URL _
                            & "', projectDesc = '" & aProject.Description _
                            & "', listId = '" & aProject.ArtListing _
                            & "' WHERE projectId = " & aProject.PrimaryKey
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Dim rowsAffected = db.ExecuteNonQuery(cmd)
            If rowsAffected > 0 Then
                Logger.Write("State with PK: " & aProject.PrimaryKey & " was updated.")
            Else
                Logger.Write("An error occurred while updating Project with PK: " & aProject.PrimaryKey)
            End If
        Catch ex As Exception
            Throw New Exception("Error occurred updating project with id: " & aProject.PrimaryKey, ex)
            'Logger.Write("Error occurred during update: " & ex.Message)
        End Try

        db = Nothing
        cmd = Nothing
        Logger.Write("Cleared Objects")
    End Sub
End Class
