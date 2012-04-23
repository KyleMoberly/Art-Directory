Public Class Role : Implements IRole

    Private _roleID As String
    Private _roleDescription As String

    Public Shared ADMIN_ID As String = "Admin"
    Public Shared ARTIST_ID As String = "Artist"

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As String)
        _roleID = id
    End Sub

    Public Property Description() As String Implements IRole.Description
        Get
            Return _roleDescription
        End Get
        Set(ByVal value As String)
            _roleDescription = value
        End Set
    End Property

    Public ReadOnly Property RoleID() As String Implements IRole.RoleID
        Get
            Return _roleID
        End Get
    End Property
End Class
