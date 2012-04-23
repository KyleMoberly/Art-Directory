Imports LogicDAL
Imports System.Collections.Generic

Partial Class AdminScreens_EditCategoryScreen
    Inherits System.Web.UI.Page

    Private _category As ICategory

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString(QueryStringLibrary.CATEGORY_ID_KEY) IsNot Nothing Then
            Try
                Dim categoryID As Integer = Request.QueryString(QueryStringLibrary.CATEGORY_ID_KEY)
                _category = CategoryDAO.GetCategoryByID(categoryID)
                lnkDelete.NavigateUrl += _category.PrimaryKey.ToString()
            Catch ex As Exception
                Throw New Exception("Query parameter was invalid", ex)
            End Try
        Else
            'This redirect should contain a Query String that indicates the propery Error Message
            'The error message should be stored in an ErrorMessageLibrary.vb file
            'Not enough time at the moment
            Response.Redirect("~/AdminScreens/ManageCategoriesScreen.aspx")
        End If

        If Not IsPostBack Then
            txtCatCode.Text = _category.Code
            txtCatDesc.Text = _category.Description
        End If


        PopulateDropDown()
    End Sub

    Private Sub PopulateDropDown()

        ddCategories.Items.Clear()
        ddCategories.Items.Add("No Parent Category")
        ddCategories.Items(0).Value = -1

        Dim categories As List(Of ICategory) = CategoryDAO.GetAllCategories()
        Dim counter As Integer = 1

        For Each category As ICategory In categories
            ddCategories.Items.Add(category.Description)
            ddCategories.Items(counter).Value = category.PrimaryKey
        Next
    End Sub

    Protected Sub UpdateCategory(ByVal sender As Object, ByVal e As EventArgs)
        _category.Code = txtCatCode.Text
        _category.Description = txtCatDesc.Text

        If ddCategories.SelectedValue <> -1 Then
            _category.ParentCategory = CategoryDAO.GetCategoryByID(ddCategories.SelectedValue)
        End If

        CategoryDAO.UpdateCategory(_category)

        Server.Transfer("~/AdminScreens/ManageCategoriesScreen.aspx")
    End Sub
End Class
