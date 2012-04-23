Imports LogicDAL

Partial Class PublicScreens_UserRegistrationPage
    Inherits System.Web.UI.Page

    Public Sub CreateNewPerson(ByVal sender As Object, ByVal e As EventArgs)
        Dim person As IPerson = New Person(txtUsername.Text)

        person.FirstName = txtFirstName.Text
        person.LastName = txtLastName.Text
        person.Password = txtPassword1.Text
        person.Email = txtEmail.Text
        person.DateLastModified = DateTime.Now
        person.Role = RoleDAO.GetRoleByID(Role.ARTIST_ID)
        PersonDAO.CreatePerson(person)

        CreateNewArtListing(person)
        Session.Add("User", person)
        MasterPage.ClearForm(Me.Master, "MainContent")
    End Sub

    Private Sub CreateNewArtListing(ByVal person As IPerson)
        Dim artListing As New ArtListing()

        artListing.Name = person.PrimaryKey & "s Profile"
        artListing.DateLastModified = DateTime.Now
        artListing.Person = person
        artListing.IsActive = False
        artListing.IsFeatured = False

        ArtListingDAO.CreateArtListing(artListing)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            pnlRegister.Visible = False
            pnlThankYou.Visible = True
        End If
    End Sub
End Class
