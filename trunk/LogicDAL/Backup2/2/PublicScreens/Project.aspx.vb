Imports LogicDAL
Partial Class PublicScreens_Project
    Inherits System.Web.UI.Page

    Protected Sub CreateProject(ByVal sender As Object, ByVal e As EventArgs)
        Dim person As IPerson = Session(ConstantsLibrary.USER_KEY)
        Dim artist As IArtListing = ArtListingDAO.GetArtListingByPerson(person.PrimaryKey)
        Dim proj As IProject = New Project()
        Dim pkey As Integer = artist.PrimaryKey


        proj.Name = txtName.Text
        proj.Dates = txtDates.Text
        proj.URL = txtURL.Text
        proj.Description = txtDesc.Text
        proj.ArtListing = pkey

        ProjectDAO.CreateProject(proj)
        Response.Redirect("Artist.Aspx")

    End Sub
End Class
