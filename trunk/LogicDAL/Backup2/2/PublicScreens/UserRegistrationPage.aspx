<%@ Page Language="VB" 
         AutoEventWireup="false" 
         CodeFile="UserRegistrationPage.aspx.vb"  
         Theme="Public" Inherits="PublicScreens_UserRegistrationPage"  
         MasterPageFile="~/Masters/MasterPage.master" 
         Title="Join us! Create Your Account Today!" %>

    <asp:Content runat="server" ContentPlaceHolderID="MainContent">
        <div>
            <asp:Panel ID="pnlRegister" runat="server" Visible="true">
            <table>
                <tr>
                    <td colspan="3">
                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtPassword2" ControlToCompare="txtPassword1" runat="server"
                                              Text="Password Mismatch" style="color:Red" SetFocusOnError="true" Display="Static" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Username:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valUserName" ControlToValidate="txtUsername" runat="server"
                                                    Text="*" style="color:Red" SetFocusOnError="True" Display="Dynamic"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password"/>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valPassword" ControlToValidate="txtPassword1" runat="server"
                                                    Text="*" style="color:Red" SetFocusOnError="true" Display="dynamic" />
                    </td>
                </tr>      
                <tr>
                    <td>
                        Verify Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"/>
                    </td>
                    <td>
                         <asp:RequiredFieldValidator ID="valPassword2" ControlToValidate="txtPassword2" runat="server"
                                                    Text="*" style="color:Red" SetFocusOnError="true" Display="dynamic" />               
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valFirstName" ControlToValidate="txtFirstName" runat="server"
                                                    Text="*" style="color:Red" SetFocusOnError="true" Display="dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Name:
                    </td>
                    <td>
                         <asp:TextBox ID="txtLastName" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valLastName" ControlToValidate="txtLastName" runat="server"
                                                    Text="*" style="color:Red" SetFocusOnError="true" Display="dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Email Address:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="valEmail" ControlToValidate="txtEmail" runat="server"
                                                    Text="*" style="color:Red" SetFocusOnError="true" Display="dynamic" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnCreatPerson" OnClick="CreateNewPerson" runat="server" Text="Create Account" />
                    </td>
                </tr>
            </table>
            </asp:Panel> 
            
            <asp:Panel ID="pnlThankYou" runat="server" Visible="false">
                <div class="thankYouMessage">
                    Thank you For Registering! Click 
                    <a href="Artist.aspx">
                        Here
                    </a>
                    to begin creating your page!
                </div>
            
            </asp:Panel>     
        </div>
    </asp:Content>

