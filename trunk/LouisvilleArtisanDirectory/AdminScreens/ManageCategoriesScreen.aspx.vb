Imports LogicDAL
Imports System.Collections.Generic

Partial Class AdminScreens_ManageCategoriesScreen
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete

        PopulateDropDownList()
        BuildCategoryList()

        If ViewState(ViewStateLibrary.DELETE_ERROR_KEY) IsNot Nothing Then
            lblMessage.Text = ViewState(ViewStateLibrary.DELETE_ERROR_KEY)
        End If

    End Sub

    Protected Sub PopulateDropDownList()

        ddCat.Items.Clear()
        ddCat.Items.Add("No Parent Category")
        ddCat.Items(0).Value = -1

        Dim counter As Integer = 0
        Dim categories As New List(Of ICategory)
        categories = CategoryDAO.GetAllCategories()

        counter = 1
        For Each category As ICategory In categories
            ddCat.Items.Add(category.Description)
            ddCat.Items(counter).Value = category.PrimaryKey
            counter += 1
        Next
    End Sub

#Region "Category Methods"
    Public Sub CreateCat(ByVal sender As Object, ByVal e As EventArgs)
        Dim category As ICategory = New Category()

        category.Code = txtCatCode.Text
        category.Description = txtCatDesc.Text
        If ddCat.SelectedValue <> -1 Then
            category.ParentCategory = CategoryDAO.GetCategoryByID(ddCat.SelectedValue)
        End If
        
        CategoryDAO.CreateCategory(category)
    End Sub

    'Protected Sub rptCategories_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCategories.ItemDataBound
    '    If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
    '        Dim cat As ICategory = CType(e.Item.DataItem, ICategory)
    '        Dim catByParentID As ObjectDataSource = CType(e.Item.FindControl("SubCategoryDS"), ObjectDataSource)
    '        catByParentID.SelectParameters("id").DefaultValue = cat.PrimaryKey
    '    End If
    'End Sub

    Public Sub BuildCategoryList()
        ltlCategories.Text = "<div class='categories'>"
        Dim categories As List(Of ICategory) = CategoryDAO.GetAllCategories()

        For Each category As ICategory In categories
            ltlCategories.Text += "<a href='EditCategoryScreen.aspx?CategoryID=" & category.PrimaryKey & "'>"
            ltlCategories.Text += category.Description & "</a> <br />"
        Next

        ltlCategories.Text += "</div>"
    End Sub


#End Region


End Class
