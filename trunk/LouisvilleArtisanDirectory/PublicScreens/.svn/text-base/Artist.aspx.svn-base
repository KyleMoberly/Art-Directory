<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Artist.aspx.vb" Inherits="PublicScreens_Default" Theme="Public" MasterPageFile="~/Masters/MasterPage.master" %>




<asp:Content ID="ArtPage" ContentPlaceHolderID="MainContent"  runat="server">


<table>
    <tr>
        <td>
        <asp:HyperLink ID="hlUpdate" Text="Update Profile" runat="server" NavigateUrl="~/PublicScreens/ArtistEditScreen.aspx"/>
        <br /><asp:HyperLink ID="hlProject" Text="Add Project" runat="server" NavigateUrl="~/PublicScreens/Project.aspx"/>

        </td>
        <td><asp:Label ID="lblCat" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td><img src="art.jpg" /></td>
        <td><b><asp:Label  ID="lblName" runat="server"/></b>
        <br /><asp:Label ID="lblAddress" runat="server" />
        <br /><asp:Label ID="lblCity" runat="server" />
        ,<asp:Label ID="lblState" runat="server" />
         <asp:Label ID="lblZip" runat="server" />
        <br />Tel: <asp:Label ID="lblPhone" runat="server" />
        <br />Email: <asp:Label ID="lblEmail" runat="server" />
        <br />WebSite: <asp:Label ID="lblWebSite" runat="server" />
        <br />
        <br />
        Rank This User(1-5):<asp:TextBox ID="txtRank" runat="server"></asp:TextBox>
        <asp:Button ID="btnRank" OnClick="Rank" runat="server" text="rank" />
        </td>
    </tr>
    <tr>
    <td colspan="2" align="center"><b>Bio:</b></td>
    </tr>
    
    <tr>
        <td colspan="2" align="center">
        <br /><br /><asp:Label ID="lblBio" runat="server" />
        </td>
    </tr>
    <tr >
        <td align="center" colspan="2">
        <asp:Label Text="Projects:" ID="lblProjects" runat="server" /></td>
    </tr>
    <tr><td colspan="2">
        
    
    

        
    
    
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ProjectDS">
            <ItemTemplate>
                <strong><%#Eval("Name")%></strong>
                <br />
                <%#Eval("Description")%><br /><br />
                
            
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="ProjectDS" runat="server" 
            SelectMethod="GetProjectArtListing" TypeName="LogicDAL.ProjectDAO">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="id" 
                    QueryStringField="ArtListingID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
    
    

        
    
    
    </td></tr>
        
        

</table>

</asp:Content>
