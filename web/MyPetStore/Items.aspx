<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Items.aspx.cs" Inherits="CategoryImages_Items" Title="Untitled Page" %>
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID,VendorID"
        DataSourceID="SqlDataSource1" AllowPaging="True" Width="434px">
        <Columns>
            <asp:TemplateField SortExpression="QuantityAvailable">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("QuantityAvailable") %>'></asp:TextBox>
                </EditItemTemplate>
                
                <ItemTemplate>
                <!-- div for details button -->
                  <div style="text-align:right;">
                  
                      <asp:HyperLink ID="hl" runat="server" NavigateUrl='<%# "~/ItemDetails.aspx?ItemID=" + (DataBinder.Eval(Container.DataItem, "ItemID")) %>' >Details</asp:HyperLink>
            </div> 
            <!-- hyperlink with item's name -->
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ItemDetails.aspx?ItemID=" + (DataBinder.Eval(Container.DataItem, "ItemID")) %>' ><%# Eval("PhotoName") %></asp:HyperLink>
             <br />
                   <a href="ItemDetails.aspx?ItemID=<%# Eval("ItemID") %>" ><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PhotoLocation") %>' Width="150" Height="150" /></a><br />
                    
                    <div style="text-align:left;">
                    <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                    <asp:Label ID="lblPriceAnswer" runat="server" Text='<%# Bind("Price", "{0:C}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="lblQuantityAvailable" runat="server" Text="Quantity:"></asp:Label>&nbsp;
                    <asp:Label ID="lblQuantityAvailableAnswer" runat="server" Text='<%# Eval("QuantityAvailable", "{0}") %>'></asp:Label><br />
                    </div>
                   
                </ItemTemplate>
                <HeaderStyle BackColor="#404040" />
                <ItemStyle BackColor="Silver" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>"
        SelectCommand="SELECT [ItemID], [VendorID], [IsActive], [QuantityAvailable], [Description], [Price], [RecommendedPrice], [CostPrice], [MinQuantity], [PhotoLocation], [PhotoName] FROM [Items] WHERE (([Description] LIKE '%' + @Description + '%') AND ([IsActive] = @IsActive))">
        <SelectParameters>
            <asp:QueryStringParameter Name="Description" QueryStringField="CategoryName" Type="String" />
            <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

