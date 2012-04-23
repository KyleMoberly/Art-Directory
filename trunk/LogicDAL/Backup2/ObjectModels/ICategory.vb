Public Interface ICategory
    ReadOnly Property PrimaryKey() As Integer
    Property Code() As String
    Property Description() As String
    Property ParentCategory() As ICategory

End Interface
