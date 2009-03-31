<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewOrders.ascx.cs" Inherits="Controls_ViewOrders" %>

<fieldset>
    <legend>View Order Info</legend>
    <br />
    <asp:Button ID="btnOrderInfo" runat="server" Text="Go" 
        onclick="btnOrderInfo_Click"  />&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Click to retrieve a list of orders with corresponding customer ID"></asp:Label>
    <br /><br />
    <asp:GridView ID="gvOrders" runat="server" CssClass="tablesorter">
    </asp:GridView>
    <br /><br />
    <asp:Button ID="btnShipStatus" runat="server" Text="Go" 
        onclick="btnShipStatus_Click" />&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="...table not ready yet"></asp:Label>
    <asp:GridView ID="gvShipStatus" runat="server" CssClass="tablesorter">
    </asp:GridView>
        
</fieldset>