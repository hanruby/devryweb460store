<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Items.aspx.cs" Inherits="CategoryImages_Items" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPH" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headerPH" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navMenuPH" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftColumnPH" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PagePhotoPH" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="mainContentPH" runat="Server">
    <!-- listview -->
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2" DataKeyNames="ItemID,VendorID"
          GroupItemCount="3" >
   
           
        <ItemTemplate>
            <td id="Td2" runat="server" class="listViewItemTemplate">
            <!-- div for content -->
            <div class="listViewItemTemplateBackground">
                <!-- div for spacing -->
                <div class="listViewItemTemplateSpacing">
                    <!-- div for details button -->
                    <div style="text-align: right;">
                        <asp:HyperLink ID="hl" runat="server" NavigateUrl='<%# "~/ItemDetails.aspx?ItemID=" + (DataBinder.Eval(Container.DataItem, "ItemID")) %>'>Details</asp:HyperLink>
                    </div>
                    <!-- hyperlink with item's name -->
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ItemDetails.aspx?ItemID=" + (DataBinder.Eval(Container.DataItem, "ItemID")) %>'><%# Eval("PhotoName") %></asp:HyperLink>
                    <br />
                    <a href="ItemDetails.aspx?ItemID=<%# Eval("ItemID") %>">
                        <asp:Image ID="imgItem" runat="server" ImageUrl='<%# Eval("PhotoLocation") %>' AlternateText='<%# Eval("Description") %>'
                            Width="75" Height="75" /></a>
                    <br />
                    <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                    <asp:Label ID="lblPriceAnswer" runat="server" Text='<%# Bind("Price", "{0:C}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="lblQuantityAvailable" runat="server" Text="Quantity Available: "></asp:Label>
                    <asp:Label ID="lblQuantityAvailableAnswer" runat="server" Text='<%# Eval("QuantityAvailable", "{0}") %>'></asp:Label>
            </td>
            
            <!-- end of spacing div -->
            </div>
            <!-- end of content div -->
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <td id="Td3" runat="server" class="listViewAlternativeItemTemplate">
            
            <!-- div for background -->
            <div class="listViewAlternativeTemplateBackground">
            <!-- div for spacing -->
            <div class="listViewAlternativeTemplateSpacing">
                <!-- div for details button -->
                <div style="text-align: right;">
                    <asp:HyperLink ID="hl" runat="server" NavigateUrl='<%# "~/ItemDetails.aspx?ItemID=" + (DataBinder.Eval(Container.DataItem, "ItemID")) %>'>Details</asp:HyperLink>
                </div>
                <!-- hyperlink with item's name -->
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ItemDetails.aspx?ItemID=" + (DataBinder.Eval(Container.DataItem, "ItemID")) %>'><%# Eval("PhotoName") %></asp:HyperLink>
                <br />
                <a href="ItemDetails.aspx?ItemID=<%# Eval("ItemID") %>">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PhotoLocation") %>' AlternateText='<%# Eval("Description") %>'
                        Width="75" Height="75" /></a>
                <br />
                <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                <asp:Label ID="lblPriceAnswer" runat="server" Text='<%# Bind("Price", "{0:C}") %>'></asp:Label>
                <br />
                <asp:Label ID="lblQuantityAvailable" runat="server" Text="Quantity:"></asp:Label>
                <asp:Label ID="lblQuantityAvailableAnswer" runat="server" Text='<%# Eval("QuantityAvailable", "{0}") %>'></asp:Label><br />
            </td>
            <!-- end of content div -->
            </div>
            
            <!-- end of background div -->
            </div>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table id="Table1" runat="server" style="">
                <tr>
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <td id="Td4" runat="server" style="">
                ItemID:
                <asp:TextBox ID="ItemIDTextBox" runat="server" Text='<%# Bind("ItemID") %>'>
                </asp:TextBox><br />
                VendorID:
                <asp:TextBox ID="VendorIDTextBox" runat="server" Text='<%# Bind("VendorID") %>'>
                </asp:TextBox><br />
                <asp:CheckBox ID="IsActiveCheckBox" runat="server" Checked='<%# Bind("IsActive") %>'
                    Text="IsActive" /><br />
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
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" /><br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" /><br />
            </td>
        </InsertItemTemplate>
        <LayoutTemplate>
        
         
     

        
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td5" runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr2" runat="server">
                    <td id="Td6" runat="server" style="text-align:center;">
                    
                    <!-- buttons for paging -->
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="9" >
                            <Fields >
                            
                                 <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                       ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                   <asp:NumericPagerField ButtonCount="5" />
                                   <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                       ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <td id="Td7" runat="server" style="">
                ItemID:
                <asp:Label ID="ItemIDLabel1" runat="server" Text='<%# Eval("ItemID") %>'></asp:Label><br />
                VendorID:
                <asp:Label ID="VendorIDLabel1" runat="server" Text='<%# Eval("VendorID") %>'></asp:Label><br />
                <asp:CheckBox ID="IsActiveCheckBox" runat="server" Checked='<%# Bind("IsActive") %>'
                    Text="IsActive" /><br />
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
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" /><br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" /><br />
            </td>
        </EditItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
        <SelectedItemTemplate>
            <td id="Td8" runat="server" style="">
                ItemID:
                <asp:Label ID="ItemIDLabel" runat="server" Text='<%# Eval("ItemID") %>'></asp:Label><br />
                VendorID:
                <asp:Label ID="VendorIDLabel" runat="server" Text='<%# Eval("VendorID") %>'></asp:Label><br />
                <asp:CheckBox ID="IsActiveCheckBox" runat="server" Checked='<%# Eval("IsActive") %>'
                    Enabled="false" Text="IsActive" /><br />
                Description:
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>'>
                </asp:Label><br />
                QuantityAvailable:
                <asp:Label ID="QuantityAvailableLabel" runat="server" Text='<%# Eval("QuantityAvailable") %>'>
                </asp:Label><br />
                Price:
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>'></asp:Label><br />
                RecommendedPrice:
                <asp:Label ID="RecommendedPriceLabel" runat="server" Text='<%# Eval("RecommendedPrice") %>'>
                </asp:Label><br />
                CostPrice:
                <asp:Label ID="CostPriceLabel" runat="server" Text='<%# Eval("CostPrice") %>'></asp:Label><br />
                MinQuantity:
                <asp:Label ID="MinQuantityLabel" runat="server" Text='<%# Eval("MinQuantity") %>'>
                </asp:Label><br />
                PhotoLocation:
                <asp:Label ID="PhotoLocationLabel" runat="server" Text='<%# Eval("PhotoLocation") %>'>
                </asp:Label><br />
                PhotoName:
                <asp:Label ID="PhotoNameLabel" runat="server" Text='<%# Eval("PhotoName") %>'></asp:Label><br />
            </td>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>"
        SelectCommand="SELECT [ItemID], [VendorID], [IsActive], [QuantityAvailable], [Description], [Price], [RecommendedPrice], [CostPrice], [MinQuantity], [PhotoLocation], [PhotoName] FROM [Items] WHERE (([Description] LIKE '%' + @Description + '%') AND ([IsActive] = @IsActive))">
        <SelectParameters>
            <asp:QueryStringParameter Name="Description" QueryStringField="CategoryName" Type="String" />
            <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" runat="Server">
</asp:Content>
