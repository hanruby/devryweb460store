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
        Font-Names="Verdana" Font-Size="1.1em" ForeColor="#333333">
        <TextBoxStyle Font-Size="0.8em" />
        <LoginButtonStyle BackColor="#efefef" BorderColor="#133463" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284775" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <TitleTextStyle BackColor="#133463" Font-Bold="True" Font-Size="1.1em" 
            ForeColor="White" />
    </asp:Login>
</form>
</body>
</html>

