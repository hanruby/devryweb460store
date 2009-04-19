<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewOrders2.ascx.cs" Inherits="Controls_ViewOrders2" %>
<fieldset>
<legend>View Order Info</legend>
    <asp:Label ID="lblOrderID" runat="server" Text="Order ID:"></asp:Label> &nbsp
    <asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox><br />
    
    <asp:Button ID="btnLookUp" runat="server" Text="Look Up" OnClick="btnLookUp_Click" /><br /><br />
    <asp:Label ID="lblNoOrder" runat="server" Text="There is no Order for that ID" Visible="false"></asp:Label>
    
    <asp:GridView ID="gvOrders1" runat="server" CssClass="tablesorter"></asp:GridView>
    <br /><br /><br />
    <asp:GridView ID="gvOrders2" runat="server" CssClass="tablesorter"></asp:GridView>
</fieldset>