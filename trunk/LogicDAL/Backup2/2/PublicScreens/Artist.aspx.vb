﻿Imports LogicDAL
Partial Class PublicScreens_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ArtListingID") Is Nothing Then
            Dim person As IPerson = Session(ConstantsLibrary.USER_KEY)
            Dim artist As IArtListing = ArtListingDAO.GetArtListingByPerson(person.PrimaryKey)

            lblName.Text = artist.Person.FirstName & " " & artist.Person.LastName
            lblAddress.Text = artist.AddressOne
            lblState.Text = artist.State
            lblCity.Text = artist.City
            lblZip.Text = artist.Zipcode
            lblPhone.Text = artist.PhoneNumber
            lblEmail.Text = artist.Email
            lblWebSite.Text = artist.URL
            lblBio.Text = artist.Description
            Repeater1.Visible = False
            hlProject.Visible = True
            hlUpdate.Visible = True
            lblProjects.Visible = False

        Else

            Dim artist As IArtListing = ArtListingDAO.GetArtListingByID(Request.QueryString("ArtListingID"))

            lblName.Text = artist.Person.FirstName & " " & artist.Person.LastName
            lblAddress.Text = artist.AddressOne
            lblState.Text = artist.State
            lblCity.Text = artist.City
            lblZip.Text = artist.Zipcode
            lblPhone.Text = artist.PhoneNumber
            lblEmail.Text = artist.Email
            lblWebSite.Text = artist.URL
            lblBio.Text = artist.Description
            Repeater1.Visible = True
            hlUpdate.Visible = False
            hlProject.Visible = False
            lblProjects.Visible = True
        End If





    End Sub
    Protected Sub Rank(ByVal sender As Object, ByVal e As EventArgs)

    End Sub


End Class
