<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="AdminProducts.aspx.cs" Inherits="Admin_AdminProducts" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Styles/MyPetStyles.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-personalized-1.6rc6.js" type="text/javascript"></script>
    <script src="../Scripts/MyPetStore.js" type="text/javascript"></script>
    <script src="../Scripts/tablesorter.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="MainContent2"  Runat="Server">
<asp:TextBox ID="txtID" runat="server"></asp:TextBox>
<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
<asp:Button ID="cmdSave" runat="server" text="Save" onclick="cmdSave_Click" />

</asp:Content>

