Public Class Utilities
    ''' <summary>
    ''' Returns value of a DB Field, and converts to Nothing if is Null
    ''' </summary>
    ''' <param name="fieldValue">Reading From a DB</param>
    Public Shared Function GetFieldValue(ByRef fieldValue As Object)
        If fieldValue Is DBNull.Value Then
            Return Nothing
        Else
            Return fieldValue
        End If
    End Function
End Class
