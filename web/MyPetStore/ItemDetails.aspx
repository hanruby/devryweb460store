<%@ Page Language="C#" MasterPageFile="MasterPage2.master" AutoEventWireup="true" CodeFile="ItemDetails.aspx.cs" Inherits="ItemDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">

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
            
         <%  Label salePriceAnswer = (Label)FormView1.FindControl("lblSalePriceAnswer");

             if (salePriceAnswer.Visible == true)
             { %>
           <del> <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price", "{0:C}") %>' ForeColor="Red"></asp:Label></del> <br />
          
           <%} %>
             
           
          <%  Label salePriceAnswer2 = (Label)FormView1.FindControl("lblSalePriceAnswer");

             if (salePriceAnswer2.Visible == false)
             { %>
           <asp:Label ID="lblPrice2" runat="server" Text='<%# Bind("Price", "{0:C}") %>' ForeColor="Red"></asp:Label><br />
          
           <%} %>
                 

                 
               
           
            <!-- discounted price -->
            <asp:Label ID="lblSalePrice" runat="server" Text="On Sale: "></asp:Label>
           <asp:Label ID="lblSalePriceAnswer" runat="server"  Text='<%# Bind("DiscountedPrice", "{0:C}") %>' ForeColor="Green"></asp:Label><br />
            
            
            RecommendedPrice:
            <asp:Label ID="lblRecommendedPrice" runat="server" Text='<%# Bind("RecommendedPrice", "{0:C}") %>'>
            </asp:Label><br />
            CostPrice:
            <asp:Label ID="lblCostPrice" runat="server" Text='<%# Bind("CostPrice", "{0:C}") %>'></asp:Label><br />
            MinQuantity:
            <asp:Label ID="lblMinQuantity" runat="server" Text='<%# Bind("MinQuantity") %>'>
            </asp:Label><br />
            <!-- hyperlink sends querystirng itemID and displays name of item 
                      <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ItemDetails.aspx?ItemID=" + (DataBinder.Eval(Container.DataItem, "ItemID")) %>' ><%# Eval("PhotoName") %></asp:HyperLink>
                      <br />-->
                  <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
          <br />
                      <!-- image  -->
  
<!-- <div  onmouseover="zoom_on(event,250,250,'<%# Eval("PhotoLocation") %>');" onmousemove="zoom_move(event);" onmouseout="zoom_off();"> 
<img src='<%# Eval("PhotoLocation") %>' alt='<%# Eval("ProductName") %>' title='<%# Eval("ProductName") %>' style="padding:0;margin:0;border:0;width:250px;height:250px;" />
</div>     -->               
              
            <asp:Image ID="Image1" runat="server" Width="250px" Height="250px" AlternateText='<%# Eval("Description") %>' ImageUrl='<%# Eval("PhotoLocation") %>'/>
           
           <br />
           <!-- add to cart button and other stuff --> 
           <div style="text-align:Left;">
           <asp:Label ID="lblQuantity" runat="server" Text="Quantity: "></asp:Label>
           <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("minQuantity") %>'></asp:TextBox>
           <asp:Button runat="server" ID="btnAddToCart" Text="AddToCart" OnClick="btnAddToCart_Click" />
           <br />
            <!-- range validator and required validator for txtQuantity -->
            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtQuantity" MinimumValue='<%# Bind("minQuantity") %>' MaximumValue='<%# Bind("QuantityAvailable") %>' runat="server" ErrorMessage="Quantity must be more than the minimum quantity and less than than the quantity available." Type="Integer" Display="Dynamic"></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Quantity is Required." Display="Dynamic"></asp:RequiredFieldValidator>
           
 </div> 
            
          
        </ItemTemplate>
    </asp:FormView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>"
        SelectCommand="SELECT [ItemID], [VendorID], [IsActive], [Description], [DiscountedPrice], [ProductName], [QuantityAvailable], [Price], [RecommendedPrice], [CostPrice], [MinQuantity], [PhotoLocation], [PhotoName] FROM [Items] WHERE ([ItemID] = @ItemID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ItemID" QueryStringField="ItemID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <!-- labels to show status of adding to cart and errors -->
     <asp:Label runat="server" ID="lblSuccessful" Text="" Visible="false" ForeColor="Green"></asp:Label>
     <asp:Label runat="server" ID="lblError" Text="" Visible="false" ForeColor="Red" ></asp:Label>     

</asp:Content>
  
        