Public Class Project : Implements IProject
    Private _primaryKey As String
    Private _projname As String
    Private _projdates As String
    Private _projurl As String
    Private _projdesc As String
    Private _artListing As IArtListing

    Public Sub New()
    End Sub

    Public Sub New(ByVal projID As String)
        _primaryKey = projID
    End Sub
    Public ReadOnly Property PrimaryKey() As Integer Implements IProject.PrimaryKey
        Get
            Return _primaryKey
        End Get
    End Property

    Public Property Name() As String Implements IProject.Name
        Get
            Return _projname
        End Get
        Set(ByVal value As String)
            _projname = value
        End Set
    End Property

    Public Property Dates() As String Implements IProject.Dates
        Get
            Return _projdates
        End Get
        Set(ByVal value As String)
            _projdates = value
        End Set
    End Property

    Public Property URL() As String Implements IProject.URL
        Get
            Return _projurl
        End Get
        Set(ByVal value As String)
            _projurl = value
        End Set
    End Property

    Public Property Description() As String Implements IProject.Description
        Get
            Return _projdesc
        End Get
        Set(ByVal value As String)
            _projdesc = value
        End Set
    End Property

    Public Property ArtListing() As IArtListing Implements IProject.ArtListing
        Get
            Return _artListing
        End Get
        Set(ByVal value As IArtListing)
            _artListing = value
        End Set
    End Property
End Class
