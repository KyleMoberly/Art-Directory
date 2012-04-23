Public Class Ranking : Implements IRanking
    Private _primaryKey As Integer
    Private _artListing As IArtListing
    Private _ranking As Integer



    Public Sub New(ByVal pk As Integer)
        _primaryKey = pk
    End Sub

    Public ReadOnly Property PrimaryKey() As Integer Implements IRanking.PrimaryKey
        Get
            Return _primaryKey
        End Get
    End Property

    Public Property ArtListing() As IArtListing Implements IRanking.ArtistListing
        Get
            Return _artListing
        End Get
        Set(ByVal value As IArtListing)
            _artListing = value
        End Set
    End Property

    Public Property Ranking() As Integer Implements IRanking.Ranking
        Get
            Return _ranking
        End Get
        Set(ByVal value As Integer)
            _ranking = value
        End Set
    End Property
End Class

