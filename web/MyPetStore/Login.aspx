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
         PasswordRecoveryText="ForgotPassword?">
    </asp:Login>
</form>
</body>
</html>

