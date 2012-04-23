Imports LogicDAL

Partial Class PublicScreens_LoginScreen
    Inherits System.Web.UI.Page

    Public Sub Login(ByVal sender As Object, ByVal e As EventArgs)

        Try
            Dim person As IPerson = PersonDAO.GetPersonByID(txtLoginName.Text)
            'Dim artist As IArtListing = ArtListingDAO.GetArtListingByPerson(txtLoginName.Text)
            If person.Password = txtLoginPass.Text Then
                Session.Add("User", person)
                'Session.Add("Artist", artist)
            End If

        Catch ex As Exception
            lblMessage.Text = "Invalid Username or Password"
        End Try
    End Sub

    Public Sub Logout(ByVal sender As Object, ByVal e As EventArgs)
        Session.Remove(ConstantsLibrary.USER_KEY)
        Session.Remove(ConstantsLibrary.ARTIST_KEY)
    End Sub

    Private Sub CheckUserStatus()
        If Session(ConstantsLibrary.USER_KEY) Is Nothing Then
            pnlLogin.Visible = True
            pnlLogout.Visible = False
        Else
            pnlLogin.Visible = False
            pnlLogout.Visible = True
            Dim person As IPerson = Session(ConstantsLibrary.USER_KEY)
            lblLoggedIn.Text = "Welcome, " & person.FirstName & " " & person.LastName
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CheckUserStatus()
    End Sub
End Class
