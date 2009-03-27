<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" Title="Untitled Page" %>
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
<div style="font-family:@Arial Unicode MS; background-color:Red;">
<!-- GridView to display items -->
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
<Columns>
<asp:TemplateField HeaderText="ItemID">
<ItemTemplate>
<asp:Label ID="lblItemID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID")%>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Price">
<ItemTemplate>
<asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price",  "{0:C}")%>' ></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Quantity">
<ItemTemplate>
<asp:Label ID="lblQuantity" runat="server" Visible='<%# !(bool) IsInEditMode %>' Text='<%# DataBinder.Eval(Container.DataItem, "Quantity")%>' ></asp:Label>
<asp:TextBox ID="txtQuantity" runat="server" Visible='<%# IsInEditMode %>' Width="40" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity")%>' ></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

</Columns>
</asp:GridView>
</div>

<!-- div for displaying total price and tax -->
<div style="font-family:@Arial Unicode MS; background-color:Gray;">
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
</div>















<br />
<asp:Button ID="btnUpdateQuantity" runat="server" Text="Update Quantity" />
<asp:Button ID="btnEditQuantity" runat="server" Text="Edit Quantity" OnClick="btnEditQuantity_Click" />
<asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClick="btnProceed_Click" />



</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

