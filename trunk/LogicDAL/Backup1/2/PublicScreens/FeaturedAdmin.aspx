<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FeaturedAdmin.aspx.vb" Inherits="PublicScreens_FeaturedAdmin" MasterPageFile="~/Masters/MasterPage.master"%>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">





    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="FeaturedDataSource" DataKeyNames="Name, IsFeatured">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:CheckBoxField DataField="IsFeatured" HeaderText="IsFeatured" 
                SortExpression="IsFeatured"   />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="FeaturedDataSource" runat="server" 
        DataObjectTypeName="LogicDAL.IArtListing" SelectMethod="GetAllArtListings" 
        TypeName="LogicDAL.ArtListingDAO" UpdateMethod="UpdateArtListing" 
        DeleteMethod="DeleteArtListing" InsertMethod="CreateArtListing">
    </asp:ObjectDataSource>
   





</asp:Content>