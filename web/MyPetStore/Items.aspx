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
    <asp:ListView ID="listViewItems" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="CheckSale" DataKeyNames="ItemID,VendorID"
          GroupItemCount="3" >
   
           
        <ItemTemplate>
            <td id="Td2" runat="server" class="listViewItemTemplate">
            <!-- div for content -->
            <div class="listViewItemTemplateBackground">
                <!-- div for spacing -->
                <div class="listViewItemTemplateSpacing">
                 <br />
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
                     <!-- div for price and quantity available on hover-->
                     <div class="listViewItemTemplateBottom">
                    <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                    <asp:Label ID="lblPriceAnswer" runat="server" Text='<%# Bind("Price", "{0:C}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="lblOnSale" runat="server"  Text="On Sale:"></asp:Label>
                <asp:Label ID="lblOnSaleAnswer"  runat="server" Text='<%# Bind("DiscountedPrice", "{0:C}") %>' ForeColor="Green"></asp:Label><br />
             
                </div>
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
            <br />
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
                <!-- div for price and quantity available on hover-->
             <div class="listViewAlternativeItemTemplateBottom">
             
             
                <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                <asp:Label ID="lblPriceAnswer" runat="server" Text='<%# Bind("Price", "{0:C}") %>'></asp:Label>
                <br />   
                <asp:Label ID="lblOnSale" runat="server" Text="On Sale:" ></asp:Label>
                <asp:Label ID="lblOnSaleAnswer" runat="server" Text='<%# Bind("DiscountedPrice", "{0:C}") %>' ></asp:Label><br />
             
                  
                    
                    
                
            </div>
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
                        The are no products that meet your criteria.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    
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
     
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
       
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>"
        SelectCommand="SELECT [ItemID], [VendorID], [IsActive], [QuantityAvailable], [Description], [Price], [DiscountedPrice], [RecommendedPrice], [CostPrice], [MinQuantity], [PhotoLocation], [PhotoName] FROM [Items] WHERE (([Description] LIKE '%' + @Description + '%') AND ([IsActive] = @IsActive))">
        <SelectParameters>
            <asp:QueryStringParameter Name="Description" QueryStringField="CategoryName" Type="String" />
            <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    
    
    <!-- listview for search -->
     <asp:ListView ID="listViewSearch" runat="server"  OnItemDataBound="CheckSale" DataKeyNames="ItemID,VendorID"
          GroupItemCount="3" DataSourceID="SqlDataSource2" >
   
           
        <ItemTemplate>
            <td id="Td2" runat="server" class="listViewItemTemplate">
            <!-- div for content -->
            <div class="listViewItemTemplateBackground">
                <!-- div for spacing -->
                <div class="listViewItemTemplateSpacing">
                 <br />
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
                     <!-- div for price and quantity available on hover-->
                     <div class="listViewItemTemplateBottom">
                    <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                    <asp:Label ID="lblPriceAnswer" runat="server" Text='<%# Bind("Price", "{0:C}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="lblOnSale" runat="server"  Text="On Sale:"></asp:Label>
                <asp:Label ID="lblOnSaleAnswer"  runat="server" Text='<%# Bind("DiscountedPrice", "{0:C}") %>' ForeColor="Green"></asp:Label><br />
             
                </div>
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
            <br />
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
                <!-- div for price and quantity available on hover-->
             <div class="listViewAlternativeItemTemplateBottom">
             
             
                <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                <asp:Label ID="lblPriceAnswer" runat="server" Text='<%# Bind("Price", "{0:C}") %>'></asp:Label>
                <br />   
                <asp:Label ID="lblOnSale" runat="server" Text="On Sale:" ></asp:Label>
                <asp:Label ID="lblOnSaleAnswer" runat="server" Text='<%# Bind("DiscountedPrice", "{0:C}") %>' ></asp:Label><br />
             
                  
                    
                    
                
            </div>
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
                        The are no products that meet your criteria.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    
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
     
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
       
    </asp:ListView>
    
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>"
        SelectCommand="SELECT [ItemID], [VendorID], [IsActive], [QuantityAvailable], [Description], [Price], [DiscountedPrice], [RecommendedPrice], [CostPrice], [MinQuantity], [PhotoLocation], [PhotoName] FROM [Items] WHERE (([Description] LIKE '%' + @Description + '%') OR ([Size] LIKE '%' + @Size + '%') OR ([PhotoName] = @PhotoName) OR ([UPC] = @UPC) OR ([ProductName] = @ProductName) AND ([IsActive] = @IsActive)) ">
        <SelectParameters>
            <asp:QueryStringParameter Name="Description" QueryStringField="Search" Type="String" />
            <asp:QueryStringParameter Name="Size" QueryStringField="Search" Type="String" />
            <asp:QueryStringParameter Name="UPC" QueryStringField="Search" Type="String" />
            <asp:QueryStringParameter Name="PhotoName" QueryStringField="Search" Type="String" />
            <asp:QueryStringParameter Name="ProductName" QueryStringField="Search" Type="String" />
     
            <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    
   
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" runat="Server">
</asp:Content>
