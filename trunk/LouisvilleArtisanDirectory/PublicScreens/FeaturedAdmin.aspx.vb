Imports LogicDAL
Imports System.Collections.Generic

Partial Class PublicScreens_FeaturedAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete


        BuildCategoryList()


    End Sub

    Public Sub BuildCategoryList()
        ltlListing.Text = "<div class='listing'>"
        Dim listing As List(Of IArtListing) = ArtListingDAO.GetAllArtListings()

        For Each artListing As IArtListing In listing
            ltlListing.Text += "<a href='EditCategoryScreen.aspx?Featured=" & artListing.IsFeatured & "'>"
            ltlListing.Text += artListing.Description & "</a> <br />"
        Next

        ltlListing.Text += "</div>"
    End Sub

End Class
