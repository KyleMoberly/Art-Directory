<%@ Page Language="VB" 
         MasterPageFile="~/Masters/AdminMaster.master" 
         AutoEventWireup="false" 
         CodeFile="ManageCategoriesScreen.aspx.vb" 
         Inherits="AdminScreens_ManageCategoriesScreen" 
         title="Manage Categories"
         Theme="Admin" %>
         
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
        <h3> Create a New Category:</h3>
        <br />
        <asp:Label ID="lblMessage" runat="Server" />
        <br />
        Name/Code: 
        <asp:TextBox runat="server" ID="txtCatCode" />
        <br />
        Description:
        <asp:TextBox runat="server" ID="txtCatDesc" />
        <br />
        Parent Category: 
        <asp:DropDownList ID="ddCat" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="btnCreateCat" runat="server" OnClick="CreateCat" Text="Create" />
        <br />
        <br />
        
        
        <asp:Literal ID="ltlCategories" runat="Server">
        </asp:Literal> 
        
</asp:Content>

