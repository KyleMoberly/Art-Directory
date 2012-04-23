<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Masters/AdminMaster.master" Theme="Admin"CodeFile="ArtistAdmin.aspx.vb" Inherits="PublicScreens_Default"  %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="PrimaryKey" HeaderText="PrimaryKey" 
                    SortExpression="PrimaryKey" ReadOnly="True" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="AddressOne" HeaderText="AddressOne" SortExpression="AddressOne" />
                <asp:BoundField DataField="AddressTwo" HeaderText="AddressTwo" SortExpression="AddressTwo" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Zipcode" HeaderText="Zipcode" SortExpression="Zipcode" />
                <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />
                <asp:CheckBoxField DataField="IsFeatured" HeaderText="IsFeatured" SortExpression="IsFeatured" />
                <asp:BoundField DataField="DateLastModified" HeaderText="DateLastModified" SortExpression="DateLastModified" />
                <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
                <asp:BoundField DataField="ImagePath" HeaderText="ImagePath" SortExpression="ImagePath" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>   
       <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllArtListings"
            TypeName="LogicDAL.ArtListingDAO" 
            DataObjectTypeName="LogicDAL.ArtListing" DeleteMethod="DeleteArtListing" 
            InsertMethod="CreateArtListing" UpdateMethod="UpdateArtListing"></asp:ObjectDataSource> 
 </asp:Content>
            