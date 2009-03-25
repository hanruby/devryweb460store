<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemDetails.aspx.cs" Inherits="ItemDetails" Title="Untitled Page" %>
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

    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ItemID,VendorID" DataSourceID="SqlDataSource1">
        <EditItemTemplate>
            ItemID:
            <asp:Label ID="ItemIDLabel1" runat="server" Text='<%# Eval("ItemID") %>'></asp:Label><br />
            VendorID:
            <asp:Label ID="VendorIDLabel1" runat="server" Text='<%# Eval("VendorID") %>'></asp:Label><br />
           
            <asp:CheckBox ID="IsActiveCheckBox" runat="server" Text="Is Active" Checked='<%# Bind("IsActive") %>' /><br />
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>'>
            </asp:TextBox><br />
            QuantityAvailable:
            <asp:TextBox ID="QuantityAvailableTextBox" runat="server" Text='<%# Bind("QuantityAvailable") %>'>
            </asp:TextBox><br />
            Price:
            <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>'>
            </asp:TextBox><br />
            RecommendedPrice:
            <asp:TextBox ID="RecommendedPriceTextBox" runat="server" Text='<%# Bind("RecommendedPrice") %>'>
            </asp:TextBox><br />
            CostPrice:
            <asp:TextBox ID="CostPriceTextBox" runat="server" Text='<%# Bind("CostPrice") %>'>
            </asp:TextBox><br />
            MinQuantity:
            <asp:TextBox ID="MinQuantityTextBox" runat="server" Text='<%# Bind("MinQuantity") %>'>
            </asp:TextBox>
            <br />
            <br />
            PhotoLocation:
            <asp:TextBox ID="PhotoLocationTextBox" runat="server" Text='<%# Bind("PhotoLocation") %>'>
            </asp:TextBox>
            <br />
            PhotoName:
            <asp:TextBox ID="PhotoNameTextBox" runat="server" Text='<%# Bind("PhotoName") %>'>
            </asp:TextBox><br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update">
            </asp:LinkButton>
            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel">
                
                
            </asp:LinkButton>
        </EditItemTemplate>
        <InsertItemTemplate>
            ItemID:
            <asp:TextBox ID="ItemIDTextBox" runat="server" Text='<%# Bind("ItemID") %>'>
            </asp:TextBox><br />
            VendorID:
            <asp:TextBox ID="VendorIDTextBox" runat="server" Text='<%# Bind("VendorID") %>'>
            </asp:TextBox><br />
            IsActive:
            <asp:CheckBox ID="IsActiveCheckBox" runat="server" Checked='<%# Bind("IsActive") %>' /><br />
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>'>
            </asp:TextBox><br />
            QuantityAvailable:
            <asp:TextBox ID="QuantityAvailableTextBox" runat="server" Text='<%# Bind("QuantityAvailable") %>'>
            </asp:TextBox><br />
            Price:
            <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>'>
            </asp:TextBox><br />
            RecommendedPrice:
            <asp:TextBox ID="RecommendedPriceTextBox" runat="server" Text='<%# Bind("RecommendedPrice") %>'>
            </asp:TextBox><br />
            CostPrice:
            <asp:TextBox ID="CostPriceTextBox" runat="server" Text='<%# Bind("CostPrice") %>'>
            </asp:TextBox><br />
            MinQuantity:
            <asp:TextBox ID="MinQuantityTextBox" runat="server" Text='<%# Bind("MinQuantity") %>'>
            </asp:TextBox><br />
            PhotoLocation:
            <asp:TextBox ID="PhotoLocationTextBox" runat="server" Text='<%# Bind("PhotoLocation") %>'>
            </asp:TextBox><br />
            PhotoName:
            <asp:TextBox ID="PhotoNameTextBox" runat="server" Text='<%# Bind("PhotoName") %>'>
            </asp:TextBox><br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert">
            </asp:LinkButton>
            <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel">
            </asp:LinkButton>
        </InsertItemTemplate>
        <ItemTemplate>
            ItemID:
            <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("ItemID") %>'></asp:Label><br />
            VendorID:
            <asp:Label ID="lblVendorID" runat="server" Text='<%# Eval("VendorID") %>'></asp:Label><br />
         <asp:CheckBox ID="chbIsActive" runat="server" Text="Is Active" Checked='<%# Eval("IsActive") %>' />
           <br />
           Description:
            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'>
            </asp:Label><br />
            QuantityAvailable:
            <asp:Label ID="lblQuantityAvailable" runat="server" Text='<%# Bind("QuantityAvailable") %>'>
            </asp:Label><br />
            Price:
            <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label><br />
            RecommendedPrice:
            <asp:Label ID="lblRecommendedPrice" runat="server" Text='<%# Bind("RecommendedPrice") %>'>
            </asp:Label><br />
            CostPrice:
            <asp:Label ID="lblCostPrice" runat="server" Text='<%# Bind("CostPrice") %>'></asp:Label><br />
            MinQuantity:
            <asp:Label ID="lblMinQuantity" runat="server" Text='<%# Bind("MinQuantity") %>'>
            </asp:Label><br />
         
             <a href="ItemDetails.aspx?=<%# Eval("ItemID") %>" ><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PhotoLocation") %>' Width="150" Height="150" /></a>
           <br />
            PhotoName:
            <asp:Label ID="lblPhotoName" runat="server" Text='<%# Bind("PhotoName") %>'></asp:Label><br />
            
           <div style="text-align:right;">
            <asp:Button runat="server" ID="btnAddToCart" Text="AddToCart" UseSubmitBehavior="false" OnClick="btnAddToCart_Click" />
            </div> 
            
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT [ItemID], [VendorID], [IsActive], [Description], [QuantityAvailable], [Price], [RecommendedPrice], [CostPrice], [MinQuantity], [PhotoLocation], [PhotoName] FROM [Items] WHERE ([ItemID] = @ItemID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ItemID" QueryStringField="ItemID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

