Imports LogicDAL
Imports System.Collections.Generic

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ddListings.Items.Clear()
        ddPerson.Items.Clear()
        ddStates.Items.Clear()

        PopulateDropDownLists()
    End Sub

    Private Sub PopulateDropDownLists()
        Dim counter As Integer = 0
        Dim listings As New List(Of IArtListing)
        listings = ArtListingDAO.GetAllArtListings()

        For Each listing As IArtListing In listings
            ddListings.Items.Add(listing.Name)
            ddListings.Items(counter).Value = listing.PrimaryKey.ToString()
            counter += 1
        Next

        Dim people As New List(Of IPerson)
        people = PersonDAO.GetAllPersons()

        counter = 0
        For Each person As IPerson In people
            ddPerson.Items.Add(person.PrimaryKey)
            ddPerson.Items(counter).Value = person.PrimaryKey
            counter += 1
        Next

        Dim states As New List(Of IState)
        states = StateDAO.GetAllStates()

        counter = 0
        For Each state As IState In states
            ddStates.Items.Add(state.StateName)
            ddStates.Items(counter).Value = state.StateCode
            counter += 1
        Next
    End Sub

    Private Sub RefreshTables()
        GridView1.DataBind()
        GridView2.DataBind()
        GridView3.DataBind()
    End Sub

    Private Sub ClearForms()
        Dim form As Control = Me.FindControl(ME.form1.UniqueID)

        Dim tb As TextBox
        For Each cont As Control In form.Controls
            If TypeOf cont Is TextBox Then
                tb = CType(cont, TextBox)
                tb.Text = ""
            End If
        Next
    End Sub

#Region "Person Methods"
    Public Sub GetPerson(ByVal sender As Object, ByVal e As EventArgs)
        Dim aPerson As New Person()
        aPerson = PersonDAO.GetPersonByID("ME")

        lblPerson.Text = aPerson.FirstName & aPerson.LastName & aPerson.Password
        btnDelete.Visible = True
        ViewState.Add("person", aPerson)
    End Sub

    Public Sub CreateNewPerson(ByVal sender As Object, ByVal e As EventArgs)
        Dim aPerson As New Person(txtPK.Text)

        aPerson.FirstName = txtFirstName.Text
        aPerson.LastName = txtLastName.Text
        aPerson.Password = txtPass.Text
        aPerson.Email = txtEmail.Text
        aPerson.DateLastModified = DateTime.Now

        PersonDAO.CreatePerson(aPerson)
        RefreshTables()
        ClearForms()
    End Sub

    Public Sub DeletePerson(ByVal sender As Object, ByVal e As EventArgs)
        Dim aPerson As Person = PersonDAO.GetPersonByID(ddPerson.SelectedValue)
        PersonDAO.DeletePerson(aPerson)
        RefreshTables()
    End Sub
#End Region

#Region "State Methods"
    Public Sub CreateState(ByVal sender As Object, ByVal e As EventArgs)
        Dim aState As New State(txtCode.Text)
        aState.StateName = txtStateName.Text

        StateDAO.CreateState(aState)
        RefreshTables()
        ClearForms()
    End Sub

    Public Sub DeleteState(ByVal sender As Object, ByVal e As EventArgs)
        Dim state As State = StateDAO.GetStateByID(ddStates.SelectedValue)
        StateDAO.DeleteState(state)
        RefreshTables()
        ClearForms()
    End Sub
#End Region

#Region "ArtListing Methods"
    Public Sub CreateArtListing(ByVal sender As Object, ByVal e As EventArgs)
        Dim artListing As New ArtListing()

        artListing.AddressOne = txtListAddressOne.Text
        artListing.AddressTwo = txtListAddressTwo.Text
        artListing.City = txtListCity.Text
        artListing.DateLastModified = DateTime.Now
        artListing.Description = txtListDesc.Text
        artListing.Email = txtListEmail.Text
        artListing.ImagePath = Nothing
        artListing.IsActive = True
        artListing.IsFeatured = False
        artListing.Name = txtListName.Text
        artListing.Person = PersonDAO.GetPersonByID("Barryrowe")
        artListing.PhoneNumber = txtListPhone.Text
        artListing.State = StateDAO.GetStateByID("KY")
        artListing.URL = txtListURL.Text
        artListing.Zipcode = txtListZip.Text

        ArtListingDAO.CreateArtListing(artListing)

        RefreshTables()
        ClearForms()
    End Sub

    Public Sub DeleteListing(ByVal sender As Object, ByVal e As EventArgs)
        Dim artListing As ArtListing = ArtListingDAO.GetArtListingByID(ddListings.SelectedValue)
        ArtListingDAO.DeleteArtListing(artListing)
        RefreshTables()
        ClearForms()
    End Sub
#End Region

   
End Class
