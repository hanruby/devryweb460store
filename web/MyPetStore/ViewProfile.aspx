<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" Title="Untitled Page" %>

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
<asp:Content ID="Content6" ContentPlaceHolderID="rightColumnPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="mainContentPH" Runat="Server">
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
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

