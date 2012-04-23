Public Interface IArtListing

    Property Name() As String
    ReadOnly Property PrimaryKey() As Integer
    Property PhoneNumber() As String
    Property Email() As String
    Property AddressOne() As String
    Property AddressTwo() As String
    Property City() As String
    Property State() As IState
    Property Zipcode() As String
    Property Person() As IPerson
    Property IsActive() As Boolean
    Property IsFeatured() As Boolean
    Property DateLastModified() As DateTime
    Property URL() As String
    Property ImagePath() As String
    Property Description() As String

End Interface
