Imports LogicDAL
Imports System.Collections.Generic

Partial Class _Default
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CheckUserStatus()

        ddListings.Items.Clear()
        ddPerson.Items.Clear()
        ddStates.Items.Clear()
        ddCat.Items.Clear()

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

        Dim categories As New List(Of ICategory)
        categories = CategoryDAO.GetAllCategories()

        counter = 0
        For Each category As ICategory In categories
            ddCat.Items.Add(category.Code)
            ddCat.Items(counter).Value = category.PrimaryKey
            counter += 1
        Next
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

    Private Sub RefreshTables()
        GridView1.DataBind()
        GridView2.DataBind()
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

    Public Sub Login(ByVal sender As Object, ByVal e As EventArgs)

        Try
            Dim person As IPerson = PersonDAO.GetPersonByID(txtLoginName.Text)
            Dim artist As IArtListing = ArtListingDAO.GetArtListingByPerson(txtLoginName.Text)
            If artist.Person.Password = txtLoginPass.Text Then
                Session.Add("User", person)
                Session.Add("Artist", artist)
            End If

            CheckUserStatus()
        Catch ex As Exception
            Throw New Exception("Could not login!", ex)
        End Try
    End Sub

    Public Sub Logout(ByVal sender As Object, ByVal e As EventArgs)
        Session.Remove(ConstantsLibrary.USER_KEY)
        Session.Remove(ConstantsLibrary.ARTIST_KEY)
        CheckUserStatus()
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
        MasterPage.ClearForm(Me.Master, "MainContent")
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
        MasterPage.ClearForm(Me.Master, "MainContent")
    End Sub

    Public Sub DeleteState(ByVal sender As Object, ByVal e As EventArgs)
        Dim state As State = StateDAO.GetStateByID(ddStates.SelectedValue)
        StateDAO.DeleteState(state)
        RefreshTables()
        MasterPage.ClearForm(Me.Master, "MainContent")
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
        MasterPage.ClearForm(Me.Master, "MainContent")
    End Sub

    Public Sub DeleteListing(ByVal sender As Object, ByVal e As EventArgs)
        Dim artListing As ArtListing = ArtListingDAO.GetArtListingByID(ddListings.SelectedValue)
        ArtListingDAO.DeleteArtListing(artListing)
        RefreshTables()
        MasterPage.ClearForm(Me.Master, "MainContent")
    End Sub
#End Region

#Region "Category Methods"
    Public Sub CreateCat(ByVal sender As Object, ByVal e As EventArgs)
        Dim category As ICategory = New Category()

        category.Code = txtCatCode.Text
        category.Description = txtCatDesc.Text
        category.ParentCategory = CategoryDAO.GetCategoryByID(ddCat.SelectedValue)

        CategoryDAO.CreateCategory(category)
        RefreshTables()
        MasterPage.ClearForm(Me.Master, "MainContent")
    End Sub
#End Region

    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim cat As ICategory = CType(e.Item.DataItem, ICategory)
            Dim catByParentID As ObjectDataSource = CType(e.Item.FindControl("SubCategoryDS"), ObjectDataSource)
            catByParentID.SelectParameters("id").DefaultValue = cat.PrimaryKey
        End If
    End Sub
End Class
