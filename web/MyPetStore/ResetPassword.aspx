<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" Title="Untitled Page" %>

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
    <table border="0" cellpadding="1" cellspacing="0" 
                style="border-collapse:collapse;">
        <tr>
            <td align="right">
                <asp:Label ID="lblUserName" runat="server" Text="User Name: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblUserNameLiteral" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblQuestion" runat="server" Text="Security Question: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblUserQuestion" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAnswer" runat="server" Text="Answer: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtQuestionAnswer" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblNewPassword" runat="server" Text="New Password: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblRetypeNewPassword" runat="server" Text="Re-type New Password: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRetypeNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

