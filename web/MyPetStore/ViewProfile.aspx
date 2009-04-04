<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" Title="View Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headerPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navMenuPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftColumnPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PagePhotoPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="mainContentPH" Runat="Server">
    <p>Hello, you are now viewing your profile.</p>
    <br />
    <table border="0" cellpadding="1" cellspacing="0" 
                style="border-collapse:collapse;">
        <tr>
            <td align="right">
                <asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserFName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserLName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAddress" runat="server" Text="E-mail:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserAddress" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAddress2" runat="server" Text="Address:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserAddress2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCity" runat="server" Text="Address2:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserCity" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblState" runat="server" Text="City:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserState" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblZip" runat="server" Text="State:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserZip" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCountry" runat="server" Text="Zip:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserCountry" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblEmail" runat="server" Text="Country:"></asp:Label>         
            </td>
            <td>
                <asp:Label ID="lblUserEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="2">
                <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" 
                    onclick="btnEditProfile_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

