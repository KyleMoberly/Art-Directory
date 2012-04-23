Public Class DeleteException : Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub



    Public Sub New(ByVal message As String, ByVal e As Exception)
        MyBase.New(message, e)
    End Sub

    Dim strExtracrInfo As String
    Public Property ExtarcterrorInfo() As String
        Get
            Return strExtracrInfo
        End Get
        Set(ByVal value As String)
            strExtracrInfo = value
        End Set
    End Property

End Class


