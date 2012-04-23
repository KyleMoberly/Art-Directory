Public Interface IPerson
    ReadOnly Property PrimaryKey() As String
    Property FirstName() As String
    Property LastName() As String
    Property Email() As String
    Property Password() As String
    Property DateLastModified() As DateTime
    Property Role() As IRole
End Interface
