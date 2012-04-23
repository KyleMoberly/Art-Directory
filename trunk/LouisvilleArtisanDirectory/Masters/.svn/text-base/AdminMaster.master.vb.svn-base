Imports LogicDAL

Partial Class Masters_AdminMaster
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session(ConstantsLibrary.USER_KEY) IsNot Nothing Then
            Dim user As IPerson = Session(ConstantsLibrary.USER_KEY)

            If user.Role.RoleID <> Role.ADMIN_ID Then
                Response.Redirect("~/Default.aspx")
            End If
        Else
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class

