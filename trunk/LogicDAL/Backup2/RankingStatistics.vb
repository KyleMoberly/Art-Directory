Public Class RankingStatistics
    Private _rankId As Long
    Private _listId As Long
    Private _listName As String
    Private _rankCount As Integer
    Private _rankAverage As Double
    Private _rankTotal As Double
    Public Property RankAverage() As Double
        Get
            Return _rankAverage
        End Get
        Set(ByVal value As Double)
            _rankAverage = value
        End Set
    End Property
    Public Property RankId() As Long
        Get
            Return _rankId
        End Get
        Set(ByVal value As Long)
            _rankId = value
        End Set
    End Property
    Public Property ListId() As Long
        Get
            Return _listId
        End Get
        Set(ByVal value As Long)
            _listId = value
        End Set
    End Property
    Public Property ListName() As String
        Get
            Return _listName
        End Get
        Set(ByVal value As String)
            _listName = value
        End Set
    End Property
    Public Property RankCount() As Integer
        Get
            Return _rankCount
        End Get
        Set(ByVal value As Integer)
            _rankCount = value
        End Set
    End Property
    Public Property RankTotal() As Double
        Get
            Return _rankTotal
        End Get
        Set(ByVal value As Double)
            _rankTotal = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return "rankId=" + RankId + ", listId=" + ListId + _
               ", listName=" + ListName + ", RankCount=" + RankCount + _
               ", RankAverage=" + RankAverage + ", RankTotal=" + RankTotal
    End Function

End Class
