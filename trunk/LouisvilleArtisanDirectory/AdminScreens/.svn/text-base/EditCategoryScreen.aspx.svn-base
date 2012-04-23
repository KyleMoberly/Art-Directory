<%@ Page Language="VB" MasterPageFile="~/Masters/AdminMaster.master" Theme="Admin" AutoEventWireup="false" CodeFile="EditCategoryScreen.aspx.vb" Inherits="AdminScreens_EditCategoryScreen" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <table>
            <tr>
                <td colspan="2" align="right">
                    <asp:HyperLink ID="lnkDelete" runat="Server" 
                            NavigateUrl="~/AdminScreens/DeleteCategory.aspx?CategoryID=">
                        <img src="../App_Themes/Images/Delete.png"
                             alt="Delete This Category"
                             title="Delete This Category" />
                    </asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    Category Code:
                </td>
                <td>
                    <asp:TextBox ID="txtCatCode" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Category Description:
                </td>
                <td>
                    <asp:TextBox ID="txtCatDesc" runat="Server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:DropDownList ID="ddCategories" runat="Server" />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnUpdate" runat="Server"  OnClick="UpdateCategory" Text="Update" />
                </td>
            </tr>
       </table>
</asp:Content>

