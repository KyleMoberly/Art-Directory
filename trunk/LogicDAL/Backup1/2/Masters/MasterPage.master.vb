
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public Shared Sub ClearForm(ByVal control As Control, ByVal controlId As String)
        Dim content As Control = control.FindControl(controlId)

        Dim tb As TextBox
        For Each cont As Control In content.Controls
            If TypeOf cont Is TextBox Then
                tb = CType(cont, TextBox)
                tb.Text = ""
            End If
        Next
    End Sub
End Class

