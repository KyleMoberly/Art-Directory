Imports LogicDAL
Partial Class PublicScreens_Default
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim artist As IArtListing = Session(ConstantsLibrary.ARTIST_KEY)
        Dim person As IPerson = Session(ConstantsLibrary.USER_KEY)
        If IsPostBack Then


        Else
            lblFirstName.Text = artist.Person.FirstName
            lblLastName.Text = artist.Person.LastName
            lblAddress.Text = artist.AddressOne
            lblState.Text = artist.State.StateCode
            lblCity.Text = artist.City
            lblZip.Text = artist.Zipcode
            lblPhone.Text = artist.PhoneNumber
            lblEmail.Text = artist.Email
            lblWebSite.Text = artist.URL
            txtBio.Text = artist.Description
        End If




    End Sub
    Protected Sub Update(ByVal sender As Object, ByVal e As EventArgs)
        Dim artist As IArtListing = Session(ConstantsLibrary.ARTIST_KEY)
        Dim person As IPerson = Session(ConstantsLibrary.USER_KEY)



        artist.AddressOne = lblAddress.Text
        artist.City = lblCity.Text
        artist.Zipcode = lblZip.Text
        artist.PhoneNumber = lblPhone.Text
        artist.Email = lblEmail.Text
        artist.URL = lblWebSite.Text
        artist.Description = txtBio.Text

        ArtListingDAO.UpdateArtListing(artist)

        Response.Redirect("Artist.aspx")

    End Sub
End Class
