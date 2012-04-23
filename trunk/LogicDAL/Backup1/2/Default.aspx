<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" Theme="Public" MasterPageFile="~/Masters/MasterPage.master" %>

<asp:Content ID="DefaultContent" runat="server" ContentPlaceHolderID="MainContent">    
    <asp:HyperLink ID="hl2200" NavigateURL="~/PublicScreens/Artist.aspx" runat="server" Text="Profile"/>
    <asp:Panel runat="server" ID="pnlLogin" Visible="false">
        <table border="none">
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
        <br />
        
        
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ParentCategoryDS">
            <ItemTemplate>
                <%#Eval("Description")%> >> <br />
                <asp:Repeater ID="subRepeater" runat="Server" DataSourceID="SubCategoryDS">
                    <ItemTemplate>
                       --- <%#Eval("Description")%>
                    </ItemTemplate> 
                </asp:Repeater>
                <asp:ObjectDataSource ID="SubCategoryDS" runat="server" SelectMethod="GetCategoriesByParentID"
                                        TypeName="LogicDAL.CategoryDAO">
                    <SelectParameters>
                        <asp:Parameter Name="id" Type="int32" /> 
                    </SelectParameters>                       
                </asp:ObjectDataSource>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="ParentCategoryDS" runat="server" SelectMethod="ListParentCategories"
            TypeName="LogicDAL.CategoryDAO"></asp:ObjectDataSource>
            
            
    <div>  &nbsp;&nbsp; Projects:<br />
        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="ProjectDataSource">
            <Columns>
                <asp:BoundField DataField="PrimaryKey" HeaderText="PrimaryKey" ReadOnly="True" SortExpression="PrimaryKey" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Dates" HeaderText="Dates" SortExpression="Dates" />
                <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ProjectDataSource" runat="server" DataObjectTypeName="LogicDAL.IProject"
            DeleteMethod="DeleteProject" InsertMethod="CreateProject" SelectMethod="ListAllProjects"
            TypeName="LogicDAL.ProjectDAO" UpdateMethod="UpdateProject"></asp:ObjectDataSource>
        &nbsp;
        <br />
        <br />
        Categories:&nbsp;
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="CategoryDataSource"
                        DataKeyNames="PrimaryKey, Code, Description">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="PrimaryKey" HeaderText="PrimaryKey" ReadOnly="True" SortExpression="PrimaryKey" />
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="CategoryDataSource" runat="server" DataObjectTypeName="LogicDAL.ICategory"
            DeleteMethod="DeleteCategory" SelectMethod="GetAllCategories" TypeName="LogicDAL.CategoryDAO">
        </asp:ObjectDataSource>
        <br />
        <br />
        Create a New Category:
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

        
        <asp:Label ID="lblArtListingHeader" Text="Art Listings:" runat="server" />
        <br />
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
       <br />
       
        <asp:Label ID="lblListName" text="Listing Name:" runat="server" />
        <asp:TextBox ID="txtListName" runat="server" />
        <br />
        <asp:Label ID="lblListPK" Text="PK:" runat="server" />
        <asp:TextBox ID="txtListPK" runat="server" />
        <br />
        <asp:Label ID="lblPhone" Text="Phone Number:" runat="server" />
        <asp:TextBox ID="txtListPhone" runat="server" />
        <br />
        <asp:Label ID="lblListEmail" Text="Email:" runat="server" />
        <asp:TextBox ID="txtListEmail" runat="server" />
        <br />
        <asp:Label ID="lblListAddressOne" Text="Address One:" runat="server" />
        <asp:TextBox ID="txtListAddressOne" runat="server" />
        <br />
        <asp:Label ID="lblListAddresTwo" text="Address Two:" runat="server" />
        <asp:TextBox ID="txtListAddressTwo" runat="server" />
        <br />
        <asp:Label ID="lblListCity" Text="City:" runat="server" />
        <asp:TextBox ID="txtListCity" runat="server" />
        <br />
        <asp:Label ID="lblListZip" Text="Zip Code:" runat="server" />
        <asp:TextBox ID="txtListZip" runat="server" />
        <br />
        <asp:Label ID="lblListURL" Text="URL:" runat="server" />
        <asp:TextBox ID="txtListURL" runat="server" />
        <br />
        <asp:Label ID="lblListDesc" Text="Description:" runat="server" />
        <asp:TextBox ID="txtListDesc" runat="server" />
        <br />
        <asp:Button ID="btnCreatPeron" runat="server" OnClick="CreateArtListing" Text="Create List" />
        <br />
        
        <asp:DropDownList runat="server" ID="ddListings">
        </asp:DropDownList>
        <asp:Button ID="btnListingsDelete" runat="server" text="Delete" OnClick="DeleteListing" />
        <br />
        <br />
        
        <asp:Label ID="lblStateHeader" Text="States:" runat="server" />&nbsp;<br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="StateCode" HeaderText="StateCode" SortExpression="StateCode" />
                <asp:BoundField DataField="StateName" HeaderText="StateName" SortExpression="StateName" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="LogicDAL.State"
            DeleteMethod="DeleteState" InsertMethod="CreateState" SelectMethod="GetAllStates"
            TypeName="LogicDAL.StateDAO" UpdateMethod="UpdateState"></asp:ObjectDataSource>
        <br />
        
        <asp:Label ID="lblStateCode" runat="server" Text="StateCode:"/>
        <asp:TextBox ID="txtCode" runat="server" />
        <asp:Label ID="lblStateName" runat="server" Text="StateName:" />
        <asp:TextBox ID="txtStateName" runat="server" />
        <br />
        <asp:Button ID="btnCreate" runat="server" OnClick="CreateState" Text="Create" />
        <br />
        
        <asp:DropDownList ID="ddStates" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnStateDelete" runat="server" OnClick="DeleteState" Text="Delete" />
        <br />
        
        <asp:Label ID="lblPersonHeader" runat="server" Text="People: " />
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="PeopleDataSource"
                        DataKeyNames="PrimaryKey, FirstName, LastName, Email, Password, DateLastModified">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="PrimaryKey" HeaderText="PrimaryKey" SortExpression="PrimaryKey" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="DateLastModified" HeaderText="DateLastModified" SortExpression="DateLastModified" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="PeopleDataSource" runat="server" SelectMethod="GetAllPersons"
            TypeName="LogicDAL.PersonDAO" DataObjectTypeName="LogicDAL.IPerson" DeleteMethod="DeletePerson" InsertMethod="CreatePerson" UpdateMethod="UpdatePerson"></asp:ObjectDataSource>
            
        <asp:Label ID="lblPerson" runat="server"/>
        <asp:Button ID="btnPerson" runat="server" OnClick="GetPerson" Text="get Me"/>
        <asp:Button ID="btnDelete" runat="server" OnClick="DeletePerson" text="deleteMe" Visible="false" /></div>
        <br />
        <asp:Label ID="lblFirstName" text="FirstName:" runat="server" />
        <asp:TextBox ID="txtFirstName" runat="server" />
        <br />
        <asp:Label ID="lblLastName" Text="LastName:" runat="server" />
        <asp:TextBox ID="txtLastName" runat="server" />
        <br />
        <asp:Label ID="lblUserName" Text="UserName:" runat="server" />
        <asp:TextBox ID="txtPK" runat="server" />
        <br />
        <asp:Label ID="lblPass" Text="Password:" runat="server" />
        <asp:TextBox ID="txtPass" runat="server" />
        
        
         <br />
        <asp:Label ID="lblEmail" Text="Email:" runat="server" />
        <asp:TextBox ID="txtEmail" runat="server" />
        <br />
        <asp:Button ID="btnMakePerson" OnClick="CreateNewPerson" runat="server" Text="SavePerson" />
        <br />
        
        <asp:DropDownList ID="ddPerson" runat="server" Width="113px">
        </asp:DropDownList>
        <asp:Button ID="btnDeletePerson" runat="server" OnClick="DeletePerson" Text="Delete" />&nbsp;<br /><br />
    </asp:Content>    

