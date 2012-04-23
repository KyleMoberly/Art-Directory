<%@ Page Language="VB" 
         MasterPageFile="~/Masters/MasterPage.master" 
         AutoEventWireup="false" 
         CodeFile="ViewArtListings.aspx.vb" 
         Inherits="PublicScreens_ViewArtListings" 
         title="Current ArtListings" 
         Theme="Public" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:Repeater runat="Server" ID="rptByArtist" datasourceId="ArtListingByArtist">
        <ItemTemplate> 
            <strong>
                <a href="Artist.aspx?ArtListingID=<%#Eval("PrimaryKey") %>">
                    <%#Eval("Name")%> 
                </a>
            </strong> 
            <br />
            <br />
                     <%#Eval("Description") %>
            <hr />
            <br />
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ArtListingByArtist" runat="server" SelectMethod="GetArtListingsByArtist"
        TypeName="LogicDAL.ArtListingDAO">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="parameter" QueryStringField="SearchByArtist"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp;&nbsp;
    
    <asp:Repeater ID="rptByCategory" runat="server" DataSourceID="ArtListingByCategory">
        <ItemTemplate> 
            <strong>
                <a href="Artist.aspx?ArtListingID=<%#Eval("PrimaryKey") %>">
                    <%#Eval("Name")%> 
                </a>
            </strong> 
            <br />
            <br />
                     <%#Eval("Description") %>
            <hr />
            <br />
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ArtListingByCategory" runat="server" SelectMethod="GetArtListingsByCategory"
        TypeName="LogicDAL.ArtListingDAO">
        <SelectParameters>
            <asp:QueryStringParameter Name="parameter" DefaultValue="" QueryStringField="SearchByCategory" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:Literal ID="ltlTest" runat="Server" />
</asp:Content>

