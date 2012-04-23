Imports LogicDAL

Partial Class AdminScreens_DeleteCategory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString(QueryStringLibrary.CATEGORY_ID_KEY) IsNot Nothing Then
            Dim category As ICategory = CategoryDAO.GetCategoryByID(Request.QueryString(QueryStringLibrary.CATEGORY_ID_KEY))

            Try
                CategoryDAO.DeleteCategory(category)
            Catch ex As DeleteException
                ViewState.Add(ViewStateLibrary.DELETE_ERROR_KEY, _
                                String.Format(ViewStateLibrary.DELETE_ERROR_MESSAGE, "Category", category.PrimaryKey))
            End Try

        End If

        'This should also pass query parameters letting you know what was deleted
        'Also, not enough time
        Response.Redirect("~/AdminScreens/ManageCategoriesScreen.aspx")
    End Sub
End Class
