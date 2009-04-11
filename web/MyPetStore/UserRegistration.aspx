<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
</head>

<body>
<form id="userRegistrationForm" runat="server">
    <div id="userRegistration" >
        <!--Richard Crouch - User registration form-->
        <asp:CreateUserWizard ID="userRegistrationWizard" runat="server" 
            OnContinueButtonClick="UserRegistrationWizard_ContinueButtonClick">
            <WizardSteps>
<asp:CreateUserWizardStep runat="server">
    <ContentTemplate>
        <table border="0">
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
                    <asp:DropDownList ID="cboState" runat="server"></asp:DropDownList>
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
                    <asp:DropDownList ID="cboCountry" runat="server"></asp:DropDownList>
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
