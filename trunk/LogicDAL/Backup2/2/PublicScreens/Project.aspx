<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Project.aspx.vb" Inherits="PublicScreens_Project" MasterPageFile="~/Masters/MasterPage.master" Theme="Public" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<table>
<tr><td>
Add Project:
</td></tr>
<tr>
    <td>Project Name: </td>
    <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
</tr>

<tr>
    <td>Project Dates: </td>
    <td><asp:TextBox ID="txtDates" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>Project URL: </td>
    <td><asp:TextBox ID="txtURL" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>Project Description: </td>
    <td><asp:TextBox ID="txtDesc" runat="server" Height="143px" 
        TextMode="MultiLine" Width="405px"></asp:TextBox></td>
</tr>        
<tr>
    <td><asp:Button ID="btnCreate" Text="CreateNewProject" runat="server" OnClick="CreateProject" />
    </td>
</tr>



</table>





</asp:Content>