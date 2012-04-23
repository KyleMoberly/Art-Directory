<%@ Page    Language="VB" 
            MasterPageFile="~/Masters/MasterPage.master" 
            AutoEventWireup="false" 
            CodeFile="LoginScreen.aspx.vb" 
            Inherits="PublicScreens_LoginScreen" 
            title="Welcome! Please Login"
            Theme="Public" %>
            
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:Panel runat="server" ID="pnlLogin" Visible="false">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblMessage" />
                </td>
            </tr>
            <tr>
                <td>
                    Username:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLoginName" />
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLoginPass" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="Login"  />
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pnlLogout" Visible="False">
        <asp:Label ID="lblLoggedIn" runat="server" />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="Logout" />
    </asp:Panel>
    
</asp:Content>

