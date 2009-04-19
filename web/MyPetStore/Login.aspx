<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
</head>

<body>
<form id="login" runat="server">
    <!--Richard Crouch - User login form-->
    <asp:Login ID="UserLogin" runat="server" OnLoggedIn="LoggedIn" CreateUserText="Not a member? Click here." 
        CreateUserUrl="../UserRegistration.aspx" PasswordRecoveryUrl="~/ForgotPassword.aspx"
         PasswordRecoveryText="ForgotPassword?" BackColor="#94b6ff" 
        BorderColor="#133463" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
        Font-Names="Verdana" Font-Size="1.1em" ForeColor="#333333" >
        <TextBoxStyle Font-Size="0.8em" />
        <LoginButtonStyle BackColor="#efefef" BorderColor="#133463" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284775" />
        <LayoutTemplate>
            <table border="0" cellpadding="4" cellspacing="0" 
                style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="center" colspan="2" 
                                    style="color:White;background-color:#133463;font-size:1.1em;font-weight:bold;">
                                    Log In</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                    Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="UserLogin">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="UserLogin">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="CancelButton" runat="server" BackColor="#EFEFEF" 
                                        BorderColor="#133463" BorderStyle="Solid" BorderWidth="1px" 
                                        Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284775" Text="Cancel" 
                                        onclick="CancelButton_Click" />
                                    <asp:Button ID="LoginButton" runat="server" BackColor="#EFEFEF" 
                                        BorderColor="#133463" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                        Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284775" Text="Log In" 
                                        ValidationGroup="UserLogin" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HyperLink ID="CreateUserLink" runat="server" 
                                        NavigateUrl="~/UserRegistration.aspx">Not a member? Click here.</asp:HyperLink>
                                    <br />
                                    <asp:HyperLink ID="PasswordRecoveryLink" runat="server" 
                                        NavigateUrl="~/ForgotPassword.aspx">ForgotPassword?</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <TitleTextStyle BackColor="#133463" Font-Bold="True" Font-Size="1.1em" 
            ForeColor="White" />
    </asp:Login>
</form>
</body>
</html>

