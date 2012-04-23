<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FeaturedAdmin.aspx.vb" Theme="Admin" Inherits="PublicScreens_FeaturedAdmin" MasterPageFile="~/Masters/AdminMaster.master"%>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">




    <asp:Literal ID="ltlListing" runat="Server">
    </asp:Literal> 
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="FeaturedDataSource" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="PrimaryKey" HeaderText="PrimaryKey" ReadOnly="True" 
                SortExpression="PrimaryKey" visible="false"/>
            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" 
                SortExpression="PhoneNumber" visible="false"/>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" visible="false"/>
            <asp:BoundField DataField="AddressOne" HeaderText="AddressOne" 
                SortExpression="AddressOne" visible="false"/>
            <asp:BoundField DataField="AddressTwo" HeaderText="AddressTwo" 
                SortExpression="AddressTwo" visible="false"/>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" visible="false"/>
            <asp:BoundField DataField="Zipcode" HeaderText="Zipcode" 
                SortExpression="Zipcode" visible="false"/>
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive"   visible="false"/>
            <asp:CheckBoxField DataField="IsFeatured" HeaderText="IsFeatured" 
                SortExpression="IsFeatured"/>
            <asp:BoundField DataField="DateLastModified" HeaderText="DateLastModified" 
                SortExpression="DateLastModified" visible="false"/>
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" visible="false"/>
            <asp:BoundField DataField="ImagePath" HeaderText="ImagePath" 
                SortExpression="ImagePath" visible="false"/>
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" visible="false"/>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="FeaturedDataSource" runat="server" 
        DataObjectTypeName="LogicDAL.ArtListing" SelectMethod="GetAllArtListings" 
        TypeName="LogicDAL.ArtListingDAO" UpdateMethod="UpdateArtListing" 
        DeleteMethod="DeleteArtListing" InsertMethod="CreateArtListing">
    </asp:ObjectDataSource>
   





</asp:Content>