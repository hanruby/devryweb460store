﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" Title="Edit Profile" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Edit Profile</title>
</head>

<body>
<form id="editProfile" runat="server">
    <p>Editing your profile . . .</p>
    <br />
    <table border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="right">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" 
                    ontextchanged="txtFirstName_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Font-Bold="true"></asp:Label>         
            </td>
            <td>   
                <asp:TextBox ID="txtLastName" runat="server" 
                    ontextchanged="txtLastName_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAddress" runat="server" Text="Address:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" 
                    ontextchanged="txtAddress_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAddress2" runat="server" Text="Address2:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server" 
                    ontextchanged="txtAddress2_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCity" runat="server" Text="City:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" ontextchanged="txtCity_TextChanged"
                 AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblState" runat="server" Text="State:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:DropDownList ID="cboState" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblZip" runat="server" Text="Zip:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtZip" runat="server" Columns="5" MaxLength="5" 
                    ontextchanged="txtZip_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCountry" runat="server" Text="Country:" Font-Bold="true"></asp:Label>         
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
                <asp:Label ID="lblEmail" runat="server" Text="E-mail:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" ontextchanged="txtEmail_TextChanged"
                 AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal ID="ErrorText" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSubmitChanges" runat="server" Text="Submit Changes" 
                    onclick="btnSubmitChanges_Click" />
            </td>
        </tr>
    </table>
</form>
</body>
</html>
