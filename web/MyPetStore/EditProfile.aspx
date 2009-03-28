<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" Title="Untitled Page" %>

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
    <p>Editing your profile . . .</p>
    
    <table border="0" cellpadding="1" cellspacing="0" 
                style="border-collapse:collapse;">
        <tr>
            <td align="right">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAddress2" runat="server" Text="Address2:"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>         
            </td>
            <td>
                <asp:DropDownList ID="cboState" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblZip" runat="server" Text="Zip:"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtZip" runat="server" Columns="5" MaxLength="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSubmitChanges" runat="server" Text="Submit Changes" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

