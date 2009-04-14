<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightColumn.ascx.cs" Inherits="RightColumn" %>
<fieldset>
    <legend>Shopping Cart Items</legend>
    <br />
<asp:Label ID="lblNoShoppingCartItems" runat="server" Text="" ></asp:Label>    
  <asp:Repeater ID="rpShoppingCartItems" runat="server" >
<ItemTemplate>

<div class="rpShoppingCartItems">
<br />
<a href="<%= Request.RawUrl %>?Delete=true&IID=<%# Eval("ItemID") %>&OID=<%# Eval("OrderID") %>&VID=<%# Eval("VendorID") %>">Delete</a>
<br />
<asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName")%>'  ></asp:Label>
<br />
<asp:Image runat="server" ID="imgProduct" ImageUrl='<%# "~/" + Eval("PhotoLocation") %>' Width="50px" Height="50px" />
<br />
<asp:Label ID="lblQuantityAvailable" runat="server" Text="Quantity Available: " ></asp:Label>
<asp:Label ID="lblQuantityAvailableAnswer" runat="server" Text='<%# Eval("QuantityAvailable")%>' ></asp:Label>
<br />
<asp:Label ID="lblQuantity" runat="server" Text="Quantity: " ></asp:Label>
<asp:Label ID="lblQuantityAnswer" runat="server" Text='<%# Eval("Quantity")%>' ></asp:Label>
<br />
<asp:Label ID="lblSinglePrice" runat="server" Text="Single Item Price: " ></asp:Label>
<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price",  "{0:C}")%>' ></asp:Label>
</div>
</ItemTemplate>
</asp:Repeater>
   
  
 
</fieldset>