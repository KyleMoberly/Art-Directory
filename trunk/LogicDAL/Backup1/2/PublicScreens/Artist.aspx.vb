Imports LogicDAL
Partial Class PublicScreens_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim artist As IArtListing = Session(ConstantsLibrary.ARTIST_KEY)
        Dim person As IPerson = Session(ConstantsLibrary.USER_KEY)
        lblName.Text = person.FirstName & " " & person.LastName
        lblAddress.Text = artist.AddressOne
        lblState.Text = artist.State.StateCode
        lblCity.Text = artist.City
        lblZip.Text = artist.Zipcode
        lblPhone.Text = artist.PhoneNumber
        lblEmail.Text = artist.Email
        lblWebSite.Text = artist.URL
        lblBio.Text = artist.Description


    End Sub
End Class
