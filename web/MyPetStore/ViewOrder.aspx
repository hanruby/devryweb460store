<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="ViewOrder" Title="Untitled Page" %>
<%@ Register src="Controls/ViewOrders2.ascx" tagname="ViewOrders2" tagprefix="uc2" %>


<asp:Content ID="Content6" ContentPlaceHolderID="mainContentPH" Runat="Server">
    
    <uc2:ViewOrders2 ID="ViewOrders2" runat="server" />
    
</asp:Content>


