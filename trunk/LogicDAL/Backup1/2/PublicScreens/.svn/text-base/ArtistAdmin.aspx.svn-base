<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ArtistAdmin.aspx.vb" Inherits="PublicScreens_Default" MasterPageFile="~/Masters/MasterPage.master" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                        DataKeyNames="Name, PrimaryKey, PhoneNumber, Email, AddressOne, AddressTwo, 
                                        City, Zipcode, IsActive, IsFeatured, DateLastModified, URL, 
                                        ImagePath, Description">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="PrimaryKey" HeaderText="PrimaryKey" SortExpression="PrimaryKey" />
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
            TypeName="LogicDAL.ArtListingDAO"></asp:ObjectDataSource> 
 </asp:Content>
            