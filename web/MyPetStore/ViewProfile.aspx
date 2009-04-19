<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" Title="View Profile"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Your Profile</title>
</head>

<body>
    <form id="viewProfile" runat="server">
        <p>Your profile.</p>
        <br />
        <table border="0" cellpadding="1" cellspacing="3">
            <tr>
                <td align="right">
                    <asp:Label ID="lblFName" runat="server" Text="First Name:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserFName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblLName" runat="server" Text="Last Name:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserLName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblAddress" runat="server" Text="E-mail:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblAddress2" runat="server" Text="Address:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserAddress2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblCity" runat="server" Text="Address2:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserCity" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblState" runat="server" Text="City:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblZip" runat="server" Text="State:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserZip" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblCountry" runat="server" Text="Zip:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserCountry" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true"></asp:Label>         
                </td>
                <td>
                    <asp:Label ID="lblUserEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" 
                       onclick="btnEditProfile_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>