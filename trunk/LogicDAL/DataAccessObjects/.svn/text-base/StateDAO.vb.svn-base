Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common

Imports System.Data.Common

Public Class StateDAO

    Public Shared Function GetAllStates() As List(Of IState)
        Logger.Write("Begin 'StateDAO.GetAllStates()'")
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim cmd As DbCommand = db.GetSqlStringCommand(ConstantsLibrary.ALL_STATES)
        Dim dr As IDataReader = db.ExecuteReader(cmd)
        Dim aState As IState
        Dim states As New List(Of IState)

        Logger.Write("Starting to execute: " & ConstantsLibrary.ALL_STATES)
        Try
            While dr.Read()
                aState = New State(dr("stateCD"))
                aState.StateName = dr("stateDescription")
                states.Add(aState)
            End While
        Catch ex As Exception
            Logger.Write("Error Occurred Finding All States: " & ex.Message)
        Finally
            dr.Close()
            cmd = Nothing
            dr = Nothing
            db = Nothing
            Logger.Write("Cleared Reader, Cmd, and DB objects")
        End Try
        Logger.Write("Found " & states.Count.ToString() & " States")

        Return states
    End Function

    Public Shared Sub DeleteState(ByVal state As IState)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "DELETE FROM StateCD Where stateCD = '" & state.StateCode & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim rowsAffected As Integer

        Try
            Logger.Write("Starting to execute: " & sql)
            rowsAffected = db.ExecuteNonQuery(cmd)
        Catch ex As Exception
            Logger.Write("Error occurred deleting state with PK: " & state.StateCode & " - " _
                        & ex.Message)
        Finally
            db = Nothing
            cmd = Nothing
            Logger.Write("Cleared db and cmd objects")
        End Try

        Logger.Write("State with key " & state.StateCode & " was deleted.")
        Logger.Write(rowsAffected & " rows were affected.")
    End Sub

    Public Shared Function GetStateByID(ByVal id As String) As IState
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "SELECT * FROM StateCD WHERE stateCD = '" & id & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)
        Dim theState As IState = Nothing

        Try
            Logger.Write("Starting to execute: " & sql)
            dr.Read()
            theState = New State(dr("stateCD"))
            theState.StateName = dr("stateDescription")
        Catch ex As Exception
            Logger.Write("Exception Occurred during Retrieval: " & ex.Message)
        Finally
            dr.Close()
            cmd = Nothing
            dr = Nothing
            db = Nothing
            Logger.Write("Cleared Reader, Cmd, and DB objects")
        End Try

        Return theState
    End Function

    Public Shared Sub CreateState(ByVal newState As IState)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "INSERT INTO StateCD (stateCD, stateDescription) VALUES ('" _
                            & newState.StateCode & "','" & newState.StateName & "')"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Logger.Write("Starting to Execute: " & sql)
            Dim rowsAffected As Integer = db.ExecuteNonQuery(cmd)
            Logger.Write(rowsAffected & " state was inserted with values: " & newState.StateCode & " " & newState.StateName)
        Catch ex As Exception
            Logger.Write("An error occurred creating the state: " & ex.Message)
        End Try

        db = Nothing
        cmd = Nothing
        Logger.Write("Cleared Objects")
    End Sub

    Public Shared Sub CreateState(ByVal stateCode As String, ByVal stateName As String)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "INSERT INTO StateCD (stateCD, stateDescription) VALUES ('" _
                            & stateCode & "','" & stateName & "')"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Dim rowsAffected As Integer = db.ExecuteNonQuery(cmd)
            If rowsAffected > 0 Then
                Logger.Write(rowsAffected & " State was inserted with values: " & stateCode & ", " & stateName)
            Else
                Logger.Write("State could not be inserted.")
            End If
        Catch ex As Exception
            Logger.Write("Error Occurred creating the state: " & ex.Message)
        End Try

        db = Nothing
        cmd = Nothing
        Logger.Write("Cleared Objects")
    End Sub

    Public Shared Sub UpdateState(ByVal theState As IState)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = "UPDATE StateCD SET stateDescription = '" _
                            & theState.StateName & "' WHERE stateCD = '" _
                            & theState.StateCode & "'"
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Dim rowsAffected = db.ExecuteNonQuery(cmd)
            If rowsAffected > 0 Then
                Logger.Write("State with PK: " & theState.StateCode & " was updated.")
            Else
                Logger.Write("An error occurred while updating state with PK: " & theState.StateCode)
            End If
        Catch ex As Exception
            Logger.Write("Error occurred during update: " & ex.Message)
        End Try

        db = Nothing
        cmd = Nothing
        Logger.Write("Cleared Objects")
    End Sub
End Class
