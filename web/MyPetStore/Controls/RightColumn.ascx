<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightColumn.ascx.cs" Inherits="RightColumn" %>
<fieldset>
    <legend>View Order Info</legend>
    <br />
    <asp:Button ID="btnOrderInfo" runat="server" Text="Go" 
          />&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Items in Shopping Cart:"></asp:Label>
    <br />
    <asp:GridView ID="gvShoppingCartItems" runat="server" CssClass="tablesorter">
    <Columns>
    <asp:TemplateField HeaderText="Price">
<ItemTemplate>
<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price",  "{0:C}")%>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    
<asp:TemplateField HeaderText="Product">
<ItemTemplate>
<asp:Label ID="lblVendorIDHidden" Visible="false" runat="server" Text='<%# Eval("VendorID")%>' ></asp:Label>
<asp:Label ID="lblOrderIDHidden" Visible="false" runat="server" Text='<%# Eval("OrderID")%>' ></asp:Label>
<asp:Label ID="lblItemIDHidden" runat="server" Visible="false" Text='<%# Eval("ItemID")%>' ></asp:Label>
<asp:Label ID="lblItemName" runat="server" Text="Item Name: " ></asp:Label>
<asp:Label ID="lblItemNameAnswer" runat="server" Text='<%# Eval("ProductName")%>' ></asp:Label>
<asp:Image ID="imgPhotoLocation" runat="server" ImageUrl='<%# Eval("PhotoLocation")%>' CssClass="shoppingCartProductImage" />
<br />
<asp:Label ID="lblDescription" runat="server" Text="Description: " ></asp:Label>
<asp:Label ID="lblDescriptionAnswer" runat="server" Text='<%# Eval("Description")%>' ></asp:Label>
<br />
<asp:Label ID="lblMinQuantity" runat="server" Text="Minimum Quantity: " ></asp:Label>
<asp:Label ID="lblMinQuantityAnswer" runat="server" Text='<%# Eval("MinQuantity")%>' ></asp:Label>
<br />
<asp:Label ID="lblQuantityAvailable" runat="server" Text="Quantity Available: " ></asp:Label>
<asp:Label ID="lblQuantityAvailableAnswer" runat="server" Text='<%# Eval("QuantityAvailable")%>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>
    </asp:GridView>
    <br />
  
 
</fieldset>