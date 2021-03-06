﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="Styles/MyPetStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="userRegistrationForm" runat="server">
    <div id="userRegistration">
        <!--Richard Crouch - User registration form-->
        <asp:CreateUserWizard ID="userRegistrationWizard" runat="server"  
            OnContinueButtonClick="UserRegistrationWizard_ContinueButtonClick" 
            oncreateduser="userRegistrationWizard_CreatedUser" BackColor="#94b6ff" 
            BorderColor="#133463" BorderStyle="Solid" BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="0.8em" DisplayCancelButton="True" CancelDestinationPageUrl="~/Default.aspx">
            <SideBarStyle BackColor="#1C5E55" Font-Size="0.9em" VerticalAlign="Top" />
            <SideBarButtonStyle ForeColor="White" />
            <ContinueButtonStyle BackColor="White" BorderColor="#133463" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#1C5E55" />
            <NavigationButtonStyle BackColor="White" BorderColor="#133463" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#1C5E55" />
            <HeaderStyle BackColor="#666666" BorderColor="#133463" BorderStyle="Solid" 
                BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" 
                HorizontalAlign="Center" />
            <CreateUserButtonStyle BackColor="#efefef" BorderColor="#133463" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#000000" />
            <CancelButtonStyle BackColor="#efefef" BorderColor="#133463" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#000000" />
            <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <StepStyle BorderWidth="0px" />
            <WizardSteps>
<asp:CreateUserWizardStep runat="server">
    <ContentTemplate>
        <table border="0" class="padded">
            <tr>
                <td align="center" colspan="2">
                    Sign Up for Your New Account</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                    Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                        ToolTip="User Name is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                        ControlToValidate="Password" ErrorMessage="Password is required." 
                        ToolTip="Password is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                        AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                        ControlToValidate="ConfirmPassword" 
                        ErrorMessage="Confirm Password is required." 
                        ToolTip="Confirm Password is required." 
                        ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName">First 
                    Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" 
                        ControlToValidate="txtFirstName" ErrorMessage="First Name is required." 
                        ToolTip="First Name is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName">Last 
                    Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" 
                        ControlToValidate="txtLastName" ErrorMessage="Last Name is required." 
                        ToolTip="Last Name is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress">Address:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AddressRequired" runat="server" 
                        ControlToValidate="txtAddress" ErrorMessage="Address is required." 
                        ToolTip="Address is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblAddress2" runat="server" AssociatedControlID="txtAddress2">Address2:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity">City:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CityNameRequired" runat="server" 
                        ControlToValidate="UserName" ErrorMessage="City Name is required." 
                        ToolTip="City Name is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblState" runat="server" AssociatedControlID="cboState">State:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboState" runat="server">
                        <asp:ListItem>AK</asp:ListItem>
                        <asp:ListItem>AL</asp:ListItem>
                        <asp:ListItem>AR</asp:ListItem> 
                        <asp:ListItem>AZ</asp:ListItem> 
                        <asp:ListItem>CA</asp:ListItem> 
                        <asp:ListItem>CO</asp:ListItem> 
                        <asp:ListItem>CT</asp:ListItem> 
                        <asp:ListItem>DC</asp:ListItem>               
                        <asp:ListItem>DE</asp:ListItem> 
                        <asp:ListItem>FL</asp:ListItem> 
                        <asp:ListItem>GA</asp:ListItem> 
                        <asp:ListItem>HI</asp:ListItem> 
                        <asp:ListItem>IA</asp:ListItem> 
                        <asp:ListItem>ID</asp:ListItem> 
                        <asp:ListItem>IL</asp:ListItem> 
                        <asp:ListItem>IN</asp:ListItem> 
                        <asp:ListItem>KS</asp:ListItem>
                        <asp:ListItem>KY</asp:ListItem>               
                        <asp:ListItem>LA</asp:ListItem> 
                        <asp:ListItem>MA</asp:ListItem> 
                        <asp:ListItem>MD</asp:ListItem> 
                        <asp:ListItem>ME</asp:ListItem> 
                        <asp:ListItem>MI</asp:ListItem> 
                        <asp:ListItem>MN</asp:ListItem> 
                        <asp:ListItem>MO</asp:ListItem> 
                        <asp:ListItem>MS</asp:ListItem> 
                        <asp:ListItem>MT</asp:ListItem> 
                        <asp:ListItem>NC</asp:ListItem>               
                        <asp:ListItem>ND</asp:ListItem>
                        <asp:ListItem>NE</asp:ListItem> 
                        <asp:ListItem>NH</asp:ListItem> 
                        <asp:ListItem>NJ</asp:ListItem> 
                        <asp:ListItem>NM</asp:ListItem> 
                        <asp:ListItem>NV</asp:ListItem> 
                        <asp:ListItem>NY</asp:ListItem> 
                        <asp:ListItem>OH</asp:ListItem> 
                        <asp:ListItem>OK</asp:ListItem> 
                        <asp:ListItem>OR</asp:ListItem>               
                        <asp:ListItem>PA</asp:ListItem> 
                        <asp:ListItem>RI</asp:ListItem> 
                        <asp:ListItem>SC</asp:ListItem> 
                        <asp:ListItem>SD</asp:ListItem> 
                        <asp:ListItem>TN</asp:ListItem> 
                        <asp:ListItem>TX</asp:ListItem> 
                        <asp:ListItem>UT</asp:ListItem> 
                        <asp:ListItem>VA</asp:ListItem> 
                        <asp:ListItem>VT</asp:ListItem> 
                        <asp:ListItem>WA</asp:ListItem> 
                        <asp:ListItem>WI</asp:ListItem> 
                        <asp:ListItem>WV</asp:ListItem>
                        <asp:ListItem>WY</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblZip" runat="server" AssociatedControlID="txtZip">Zip Code:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ZipCodeRequired" runat="server" 
                        ControlToValidate="UserName" ErrorMessage="Zip code is required." 
                        ToolTip="Zip code is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblCountry" runat="server" AssociatedControlID="cboCountry">Country:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboCountry" runat="server">
                    <asp:ListItem>United States Of America</asp:ListItem>
                        <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                        <asp:ListItem>The Bahamas</asp:ListItem>
                        <asp:ListItem>Barbados</asp:ListItem>
                        <asp:ListItem>Belize</asp:ListItem>
                        <asp:ListItem>Canada</asp:ListItem>
                        <asp:ListItem>Costa Rica</asp:ListItem>
                        <asp:ListItem>Cuba</asp:ListItem>
                        <asp:ListItem>Dominica</asp:ListItem>
                        <asp:ListItem>Dominican-Republic</asp:ListItem>
                        <asp:ListItem>Greenland</asp:ListItem>
                        <asp:ListItem>Grenada</asp:ListItem>
                        <asp:ListItem>Guatemala</asp:ListItem>
                        <asp:ListItem>Haiti</asp:ListItem>
                        <asp:ListItem>Jamaica</asp:ListItem>
                        <asp:ListItem>Mexico</asp:ListItem>
                        <asp:ListItem>Nicaragua</asp:ListItem>
                        <asp:ListItem>Panama</asp:ListItem>
                        <asp:ListItem>Saint Kitts and Nevis</asp:ListItem>
                        <asp:ListItem>Saint Lucia</asp:ListItem>
                        <asp:ListItem>Saint Vincent and the Grenadines</asp:ListItem>
                        <asp:ListItem>Trinidad and Tobago</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                        ControlToValidate="Email" ErrorMessage="E-mail is required." 
                        ToolTip="E-mail is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security 
                    Question:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                        ControlToValidate="Question" ErrorMessage="Security question is required." 
                        ToolTip="Security question is required." 
                        ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security 
                    Answer:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                        ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                        ToolTip="Security answer is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:CompareValidator ID="PasswordCompare" runat="server" 
                        ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                        Display="Dynamic" 
                        ErrorMessage="The Password and Confirmation Password must match." 
                        ValidationGroup="userRegistrationWizard"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="color:Red;">
                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
        </table>
    </ContentTemplate>
                </asp:CreateUserWizardStep>
<asp:CompleteWizardStep runat="server"></asp:CompleteWizardStep>
</WizardSteps>
        </asp:CreateUserWizard>
    </div>
</form>
</body>
</html>
