<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Artist.aspx.vb" Inherits="PublicScreens_Default" MasterPageFile="~/Masters/MasterPage.master" %>



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
        <td><asp:Label  ID="lblName" runat="server"/>
        <br /><asp:Label ID="lblAddress" runat="server" />
        <br /><asp:Label ID="lblCity" runat="server" />
        <br /><asp:Label ID="lblState" runat="server" />
        <br /><asp:Label ID="lblZip" runat="server" />
        <br /><asp:Label ID="lblPhone" runat="server" />
        <br /><asp:Label ID="lblEmail" runat="server" />
        <br /><asp:Label ID="lblWebSite" runat="server" />
        <br /><asp:Label ID="lblBio" runat="server" />
        <br /><asp:HyperLink ID="hl394" Text="Update Profile" runat="server" NavigateUrl="~/PublicScreens/ArtistEditScreen.aspx"/>
        </td>
    </tr>
</table>

</asp:Content>
