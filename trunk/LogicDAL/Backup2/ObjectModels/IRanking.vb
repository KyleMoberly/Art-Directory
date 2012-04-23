Public Interface IRanking
    ReadOnly Property PrimaryKey() As Integer
    Property ArtistListing() As IArtListing
    Property Ranking() As Integer
End Interface
