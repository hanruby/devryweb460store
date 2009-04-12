<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="AdminViewOrder.aspx.cs" Inherits="AdminViewOrder" %>
<%@ Register Src="~/Controls/ViewOrders.ascx" TagName="viewOrders" TagPrefix="rr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-personalized-1.6rc6.js" type="text/javascript"></script>
    <script src="../Scripts/MyPetStore.js" type="text/javascript"></script>
    <script src="../Scripts/tablesorter.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    <rr:viewOrders ID="ctrlViewOrders" runat="server" />
</asp:Content>

