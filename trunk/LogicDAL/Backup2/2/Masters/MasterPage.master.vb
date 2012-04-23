Imports LogicDAL

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

    Public Sub SearchListings(ByVal sender As Object, ByVal e As EventArgs)
        Dim sb As New StringBuilder()
        sb.Append("~/PublicScreens/ViewArtListings.aspx?")

        If Artist.Checked Then
            sb.Append("SearchByArtist=")
        Else
            sb.Append("SearchByCategory=")
        End If

        sb.Append(txtSearch.Text)
        Response.Redirect(sb.ToString())
    End Sub


    Public Sub ToggleAdminLink()
        If Session(ConstantsLibrary.USER_KEY) Is Nothing Then
            lnkAdmin.Visible = False
        Else
            Dim user As IPerson = Session(ConstantsLibrary.USER_KEY)
            If user.Role.RoleID = Role.ADMIN_ID Then
                lnkAdmin.Visible = True
            Else
                lnkAdmin.Visible = False
            End If
        End If
    End Sub

    Private Sub ToggleSearchButtons()
        If Request.QueryString(QueryStringLibrary.SEARCH_BY_ARTIST_KEY) IsNot Nothing Then
            Artist.Checked = True
            Category.Checked = False
        ElseIf Request.QueryString(QueryStringLibrary.SEARCH_BY_CATEGORY_KEY) IsNot Nothing Then
            Artist.Checked = False
            Category.Checked = True
        End If
    End Sub

    Private Sub ToggleProfileLink()
        If Session(ConstantsLibrary.USER_KEY) Is Nothing Then
            lnkProfile.Visible = False
            lnkCreateAccount.Visible = True
            lnkLogin.Text = "Login"
        Else
            lnkProfile.Visible = True
            lnkCreateAccount.Visible = False
            lnkLogin.Text = "Logout"
        End If
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ToggleAdminLink()
        ToggleSearchButtons()
        ToggleProfileLink()
    End Sub
End Class

