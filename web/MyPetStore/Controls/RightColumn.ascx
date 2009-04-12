<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightColumn.ascx.cs" Inherits="RightColumn" %>
<fieldset>
    <legend>Shopping Cart Items</legend>
    <br />
<asp:Label ID="lblNoShoppingCartItems" runat="server" Text="" ></asp:Label>    
  <asp:Repeater ID="rpShoppingCartItems" runat="server" >
<ItemTemplate>

<a href="<%= Request.Url %>?Delete=true&IID=<%# Eval("ItemID") %>&OID=<%# Eval("OrderID") %>&VID=<%# Eval("VendorID") %>">Delete</a>
<br />
<asp:Label ID="lblItemName" runat="server" Text="Item Name: " ></asp:Label>
<br />
<asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName")%>'  ></asp:Label>
<br />


<asp:Label ID="lblQuantityAvailable" runat="server" Text="Quantity Available: " ></asp:Label>
<asp:Label ID="lblQuantityAvailableAnswer" runat="server" Text='<%# Eval("QuantityAvailable")%>' ></asp:Label>
<br />
<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price",  "{0:C}")%>' ></asp:Label>

<br />

</ItemTemplate>
</asp:Repeater>
   
  
    <br />
  
 
</fieldset>