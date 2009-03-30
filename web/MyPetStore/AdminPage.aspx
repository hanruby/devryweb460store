﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="Admin_AdminPage" %>
<%@ Register Src="~/Controls/ViewCustomers.ascx" TagName="viewCustomers" TagPrefix="rr" %>
<%@ Register Src="~/Controls/ViewOrders.ascx" TagName="viewOrders" TagPrefix="rr" %>

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
    <div id="viewCustomer">
        <rr:viewCustomers ID="ctrlViewCustomers" runat="server" />
    </div>
    <br /><br />
    <div id="viewOrder">
        <rr:viewOrders ID="ctrlViewOrders" runat="server" />
    </div>
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

