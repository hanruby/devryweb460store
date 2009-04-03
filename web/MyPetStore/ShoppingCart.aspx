<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" Title="Shopping Cart" %>
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



<!-- top div -->
<div style="font-family:@Arial Unicode MS; background-color:Beige;">
<h1>Shopping Cart</h1>

</div>

<!-- div for displaying item prices and quantity -->
<div style="font-family:Andalus; background-color:Red;" >
<!-- GridView to display items -->
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="tablesorter">
<Columns>
<asp:TemplateField HeaderText="Quantity">
<ItemTemplate>
<asp:Label ID="lblQuantity" runat="server" Visible='<%# !(bool) IsInEditMode %>' Text='<%# Eval("Quantity")%>' ></asp:Label>
<asp:TextBox ID="txtQuantity" runat="server" Visible='<%# IsInEditMode %>' Width="40" Text='<%# Eval("Quantity")%>' ></asp:TextBox>
<br />
<a href="ShoppingCart.aspx?Delete=true&OID=<%# Eval("OrderID") %>&IID=<%# Eval("ItemID") %>&VID=<%# Eval("VendorID") %>" >Delete Item</a>

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

<asp:TemplateField HeaderText="Price">
<ItemTemplate>
<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price",  "{0:C}")%>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Total Price">
<ItemTemplate>
<asp:Label ID="lblTotaIndividualPrice" runat="server" Text='<%# Eval("TotalPrice",  "{0:C}")%>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

</Columns>
<EmptyDataTemplate>
Your Shopping Cart is empty.
</EmptyDataTemplate>
</asp:GridView>
<!-- ddl for state selection -->
    
    <asp:Label ID="lblState" runat="server" Text="Shipping State: " Font-Size="X-Large"></asp:Label>
 <asp:DropDownList runat="server" ID="ddlState">
    </asp:DropDownList>

</div>
<!-- div for displaying total price and tax -->
<div style="font-family:@Arial Unicode MS; background-color:Gray; height:auto" id="viewOrder">

<!-- repeater for total price, tax, grosstotal, shipping? -->
<asp:Repeater runat="server" ID="rptOne">

<ItemTemplate>
<asp:Label ID="lblNetTotal" runat="server" Text="Net Total: " ></asp:Label>
<asp:Label ID="lblNetTotalAnswer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NetTotal", "{0:C}")%>' ></asp:Label>
<br />
<asp:Label ID="lblTax" runat="server" Text="Tax: " ></asp:Label>
<asp:Label ID="lblTaxAnswer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Tax",  "{0:C}")%>' ></asp:Label>
<br />
<asp:Label ID="lblGrossTotal" runat="server" Text="Gross Total: " ></asp:Label>
<asp:Label ID="lblGrossTotalAnswer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GrossTotal", "{0:C}")%>' ></asp:Label>
</ItemTemplate>

</asp:Repeater>

<br />

</div>














<!-- buttons -->
<br />
<asp:Button ID="btnUpdateQuantity" runat="server" Text="Update Quantity" OnClick="btnUpdateQuantity_Click" />
<asp:Button ID="btnEditQuantity" runat="server" Text="Edit Quantity" OnClick="btnEditQuantity_Click" />
<asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClick="btnProceed_Click" />




</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>
