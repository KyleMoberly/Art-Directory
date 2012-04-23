<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddArtistListing.aspx.vb" Inherits="AdminScreens_AddArtistListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<table>
<tr><td>
Add Listing
</td></tr>
<tr>
    <td>Listing Name: </td>
    <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
</tr>

<tr>
    <td>Phone Number: </td>
    <td><asp:TextBox ID="txtDates" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>Address 1: </td>
    <td><asp:TextBox ID="txtURL" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>Address 2: </td>
    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
</tr>

<tr>
    <td>City: </td>
    <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>State: </td>
    <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>User: </td>
    <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>URL </td>
    <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
</tr>


<tr>
    <td>Description: </td>
    <td><asp:TextBox ID="txtDesc" runat="server" Height="143px" 
        TextMode="MultiLine" Width="405px"></asp:TextBox></td>
</tr>        
<tr>
    <td><asp:Button ID="btnCreate" Text="Create New Listing" runat="server" OnClick="CreateListing" />
    </td>
</tr>



</table>





</asp:Content>