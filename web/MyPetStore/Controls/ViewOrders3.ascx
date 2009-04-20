<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewOrders3.ascx.cs" Inherits="Controls_ViewOrders3" %>
<fieldset>
<legend>Order lookup</legend>
    <asp:Label ID="lblOrders_OrderDate_Start" runat="server" Text="From Date"></asp:Label> &nbsp
    <asp:TextBox ID="txtOrders_OrderDate_Start" runat="server"></asp:TextBox>
    &nbsp &nbsp
    <asp:Label ID="lblOrders_OrderDate_End" runat="server" Text="To Date"></asp:Label> &nbsp
    <asp:TextBox ID="txtOrders_OrderDate_End" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblOrders_NetTotal_Start" runat="server" Text="From Net Price"></asp:Label> &nbsp
    <asp:TextBox ID="txtOrders_NetTotal_Start" runat="server"></asp:TextBox>
    &nbsp &nbsp
    <asp:Label ID="lblOrders_NetTotal_End" runat="server" Text="To Net Price"></asp:Label> &nbsp
    <asp:TextBox ID="txtOrders_NetTotal_End" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblCustomer_CustomerID" runat="server" Text="Customer ID"></asp:Label> &nbsp
    <asp:TextBox ID="txtCustomer_CustomerID" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblCustomer_FName" runat="server" Text="First Name"></asp:Label> &nbsp
    <asp:TextBox ID="txtCustomer_FName" runat="server"></asp:TextBox>
    &nbsp &nbsp
    <asp:Label ID="lblCustomer_LName" runat="server" Text="Last Name"></asp:Label> &nbsp
    <asp:TextBox ID="txtCustomer_LName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblCustomer_UserName" runat="server" Text="User Name"></asp:Label> &nbsp
    <asp:TextBox ID="txtCustomer_UserName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblCustomer_City" runat="server" Text="City"></asp:Label> &nbsp
    <asp:TextBox ID="txtCustomer_City" runat="server"></asp:TextBox>
    &nbsp &nbsp
    <asp:Label ID="lblCustomer_State" runat="server" Text="State"></asp:Label> &nbsp
    <asp:TextBox ID="txtCustomer_State" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblItems_ProductName" runat="server" Text="Product Name"></asp:Label> &nbsp
    <asp:TextBox ID="txtItems_ProductName" runat="server"></asp:TextBox>
    <br />
    
    <asp:Button ID="btnLookUp" runat="server" Text="Look Up" OnClick="btnLookUp_Click" /><br /><br />
    <asp:Label ID="lblNoOrder" runat="server" Text="There is no order that meets your criteria" Visible="false"></asp:Label>
    
    <asp:GridView ID="gvOrders1" runat="server" CssClass="tablesorter"></asp:GridView>

</fieldset>