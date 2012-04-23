Imports System.Collections.Generic
Imports LogicDAL

Partial Class PublicScreens_ViewArtListings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString(QueryStringLibrary.SEARCH_BY_ARTIST_KEY) IsNot Nothing Then
            rptByCategory.Visible = False
            rptByArtist.Visible = True
        ElseIf Request.QueryString(QueryStringLibrary.SEARCH_BY_CATEGORY_KEY) IsNot Nothing Then
            rptByArtist.Visible = False
            rptByCategory.Visible = True
        End If
    End Sub
End Class
