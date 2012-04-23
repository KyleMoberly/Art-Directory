<Serializable()> _
Public Class Person : Implements IPerson
    Private _primaryKey As String
    Private _firstName As String
    Private _lastName As String
    Private _password As String
    Private _email As String
    Private _dateLastModified As String
    Private _role As IRole

    Public Sub New()
    End Sub

    Public Sub New(ByVal userName As String)
        _primaryKey = userName
    End Sub
    Public ReadOnly Property PrimaryKey() As String Implements IPerson.PrimaryKey
        Get
            Return _primaryKey
        End Get
    End Property

    Public Property FirstName() As String Implements IPerson.FirstName
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property

    Public Property LastName() As String Implements IPerson.LastName
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    Public Property Password() As String Implements IPerson.Password
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Public Property Email() As String Implements IPerson.Email
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Public Property DateLastModified() As DateTime Implements IPerson.DateLastModified
        Get
            Return _dateLastModified
        End Get
        Set(ByVal value As DateTime)
            _dateLastModified = value
        End Set
    End Property

    Public Property Role() As IRole Implements IPerson.Role
        Get
            Return _role
        End Get
        Set(ByVal value As IRole)
            _role = value
        End Set
    End Property
End Class