Imports System.Text

Public Class ConstantsLibrary

    Public Shared LOCAL_ART_DB As String = "strLocalArtDB"
    Public Shared ALL_STATES As String = "SELECT * FROM StateCD"
    Public Shared ALL_ART_LISTINGS As String = "SELECT * FROM ArtListing"
    Public Shared ALL_PERSONS As String = "SELECT * FROM Person"
    Public Shared ALL_CATEGORIES As String = "SELECT * FROM Categories"
    Public Shared ALL_PROJECTS As String = "SELECT * FROM Projects"

    Public Shared ReadOnly Property GET_CATEGORY_BY_ID(ByVal primaryKey As Integer) As String
        Get
            Dim sb As New StringBuilder()
            sb.Append("SELECT * FROM Categories WHERE CatID = '")
            sb.Append(primaryKey & "'")
            Return sb.ToString()
        End Get
    End Property

    Public Shared ReadOnly Property DELETE_CATEGORY(ByVal primaryKey As Integer) As String
        Get
            Dim sb As New StringBuilder()
            sb.Append("DELETE FROM Categories WHERE CatID = '")
            sb.Append(primaryKey & "'")
            Return sb.ToString()
        End Get
    End Property

    Public Shared ReadOnly Property Delete_State(ByVal state As State) As String
        Get
            Dim sb As New StringBuilder()
            sb.Append("DELETE FROM StateCD WHERE StateCD = '")
            sb.Append(state.StateCode & "'")
            Return sb.ToString()
        End Get
    End Property

End Class
