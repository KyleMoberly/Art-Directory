Public Class ArtListing : Implements IArtListing

    Private _addressOne As String
    Private _addressTwo As String
    Private _city As String
    Private _dateLastModified As DateTime
    Private _email As String
    Private _imagePath As String
    Private _isActive As Boolean
    Private _isFeatured As Boolean
    Private _name As String
    Private _phoneNumber As String
    Private _primaryKey As Integer
    Private _url As String
    Private _zipCode As String
    Private _person As IPerson
    Private _state As IState
    Private _description As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal pk As Integer)
        _primaryKey = pk
    End Sub

    Public Property AddressOne() As String Implements IArtListing.AddressOne
        Get
            Return _addressOne
        End Get
        Set(ByVal value As String)
            _addressOne = value
        End Set
    End Property

    Public Property AddressTwo() As String Implements IArtListing.AddressTwo
        Get
            Return _addressTwo
        End Get
        Set(ByVal value As String)
            _addressTwo = value
        End Set
    End Property

    Public Property City() As String Implements IArtListing.City
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property

    Public Property DateLastModified() As Date Implements IArtListing.DateLastModified
        Get
            Return _dateLastModified
        End Get
        Set(ByVal value As Date)
            _dateLastModified = value
        End Set
    End Property

    Public Property Description() As String Implements IArtListing.Description
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

    Public Property Email() As String Implements IArtListing.Email
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Public Property ImagePath() As String Implements IArtListing.ImagePath
        Get
            Return _imagePath
        End Get
        Set(ByVal value As String)
            _imagePath = value
        End Set
    End Property

    Public Property IsActive() As Boolean Implements IArtListing.IsActive
        Get
            Return _isActive
        End Get
        Set(ByVal value As Boolean)
            _isActive = value
        End Set
    End Property

    Public Property IsFeatured() As Boolean Implements IArtListing.IsFeatured
        Get
            Return _isFeatured
        End Get
        Set(ByVal value As Boolean)
            _isFeatured = value
        End Set
    End Property

    Public Property Name() As String Implements IArtListing.Name
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property Person() As IPerson Implements IArtListing.Person
        Get
            Return _person
        End Get
        Set(ByVal value As IPerson)
            _person = value
        End Set
    End Property
    Public Property PhoneNumber() As String Implements IArtListing.PhoneNumber
        Get
            Return _phoneNumber
        End Get
        Set(ByVal value As String)
            _phoneNumber = value
        End Set
    End Property

    Public ReadOnly Property PrimaryKey() As Integer Implements IArtListing.PrimaryKey
        Get
            Return _primaryKey
        End Get
    End Property

    Public Property State() As IState Implements IArtListing.State
        Get
            Return _state
        End Get
        Set(ByVal value As IState)
            _state = value
        End Set
    End Property
    Public Property URL() As String Implements IArtListing.URL
        Get
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property

    Public Property Zipcode() As String Implements IArtListing.Zipcode
        Get
            Return _zipCode
        End Get
        Set(ByVal value As String)
            _zipCode = value
        End Set
    End Property

End Class
