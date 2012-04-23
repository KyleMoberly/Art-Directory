Public Class State : Implements IState

    Private _stateCode As String
    Private _stateName As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal code As String)
        _stateCode = code
    End Sub

    Public ReadOnly Property StateCode() As String Implements IState.StateCode
        Get
            Return _stateCode
        End Get
    End Property

    Public Property StateName() As String Implements IState.StateName
        Get
            Return _stateName
        End Get
        Set(ByVal value As String)
            _stateName = value
        End Set
    End Property
End Class
