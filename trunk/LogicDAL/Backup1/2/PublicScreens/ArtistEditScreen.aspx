<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ArtistEditScreen.aspx.vb" Inherits="PublicScreens_Default" MasterPageFile="~/Masters/MasterPage.master" %>



<asp:Content ID="ArtPage" ContentPlaceHolderID="Main" runat="server">

<table>
    <tr>
        <td>
        <asp:Label Text="Breadcrumbs go here" ID="lblBC" runat="server"></asp:Label>
        </td>
        <td><asp:Label ID="lblCat" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td><asp:Image ID="UserImage"  runat="server"/></td>
        <td><asp:TextBox  ID="lblFirstName" runat="server"/>
        <br /><asp:TextBox ID="lblLastName" runat="server" />
        <br /><asp:TextBox ID="lblAddress" txt="Address" runat="server" />
        <br /><asp:TextBox ID="lblCity" runat="server" />
        <br /><asp:TextBox ID="lblState" runat="server" />
        <br /><asp:TextBox ID="lblZip" runat="server" />
        <br /><asp:TextBox ID="lblPhone" runat="server" />
        <br /><asp:TextBox ID="lblEmail" runat="server" />
        <br /><asp:TextBox ID="lblWebSite" runat="server" />
        <br /><asp:TextBox ID="txtBio" runat="server" />
        <br /><asp:Button ID="btnSubmit" Text="Update" runat="server" OnClick="Update"   />
        </td>
    </tr>
</table>

</asp:Content>
