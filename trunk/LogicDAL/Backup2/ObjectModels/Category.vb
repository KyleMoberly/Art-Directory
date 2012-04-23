Public Class Category : Implements ICategory
    Private _primaryKey As Integer
    Private _code As String
    Private _description As String
    Private _parentCategory As ICategory

    Public Sub New()
    End Sub

    Public Sub New(ByVal pk As Integer)
        _primaryKey = pk
    End Sub

    Public ReadOnly Property PrimaryKey() As Integer Implements ICategory.PrimaryKey
        Get
            Return _primaryKey
        End Get
    End Property

    Public Property Code() As String Implements ICategory.Code
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property

    Public Property Description() As String Implements ICategory.Description
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

    Public Property ParentCategory() As ICategory Implements ICategory.ParentCategory
        Get
            Return _parentCategory
        End Get
        Set(ByVal value As ICategory)
            _parentCategory = value
        End Set
    End Property
End Class
