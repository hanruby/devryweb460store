<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" Title="Shopping Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-personalized-1.6rc6.js" type="text/javascript"></script>
    <script src="../Scripts/MyPetStore.js" type="text/javascript"></script>
    <script src="../Scripts/tablesorter.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">

<!-- script manager for the page -->
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<!-- top div -->
<div style="font-family:@Arial Unicode MS; background-color:Gray;">
<h1 style="font-size:40pt">Shopping Cart</h1>

</div>

<!-- div for displaying item prices and quantity -->
<div style="font-family:Andalus; background-color:Olive;" >
<!-- GridView to display items -->
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="tablesorter">
<Columns>

<asp:TemplateField HeaderText="Quantity">
<ItemTemplate>
<asp:TextBox ID="txtQuantity" runat="server" Width="50" Text='<%# Eval("Quantity")%>' ></asp:TextBox>
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

<asp:TemplateField HeaderText="Delete">
<ItemTemplate>
    <asp:CheckBox ID="ItemSelector" runat="server" />
</ItemTemplate>
</asp:TemplateField>

</Columns>
<EmptyDataTemplate>
Your Shopping Cart is empty.
</EmptyDataTemplate>
</asp:GridView>
<!-- ddl for state selection -->

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
   
    <asp:Label ID="lblState" runat="server" Text="Shipping State: " Font-Size="X-Large"></asp:Label>
 <asp:DropDownList runat="server" ID="ddlState">

    </asp:DropDownList>
    <br />
   </ContentTemplate>
    </asp:UpdatePanel>
    
    <!-- displays errors -->
<asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Size="10pt"></asp:Label>
<asp:Label ID="lblQuantityError" runat="server" Text=" " ForeColor="Red" Font-Size="10pt"></asp:Label>
<br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ErrorMessage="Please select a state in order to calculate your gross total with tax." ControlToValidate="ddlState" ValidationExpression="[A-Z]{2}"></asp:RegularExpressionValidator>


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
<asp:Button ID="btnUpdateQuantity" runat="server" Text="Update Cart" OnClick="btnUpdateQuantity_Click" />
<asp:Button ID="btnContinueShopping" runat="server" Text="Continue Shopping" OnClick="btnContinueShopping_Click" />
<asp:Button ID="btnProceed" runat="server" Text="Proceed To CheckOut" OnClick="btnProceed_Click" />




</asp:Content>

