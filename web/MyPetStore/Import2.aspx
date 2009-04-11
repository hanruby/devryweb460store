<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Import2.aspx.cs" Inherits="Import2" Title="Import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navMenuPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent2" Runat="Server">
    <div align="center">
        <input id="txtFile" type="file" runat="server" name="txtFile" /><br /><br />
        <asp:Button ID="cmdImport" runat="server" Text="Import" 
            onclick="cmdImport_Click" /><br />
        <asp:Label ID="lblError" runat="server" />
    </div>
</asp:Content>