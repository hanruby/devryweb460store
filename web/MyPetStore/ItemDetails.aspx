<%@ Page Language="C#" MasterPageFile="MasterPage2.master" AutoEventWireup="true" CodeFile="ItemDetails.aspx.cs" Inherits="ItemDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">

<!-- script manager for page -->
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ItemID,VendorID" DataSourceID="SqlDataSource1">
      
      
        <ItemTemplate>
      
           <!-- start of table -->
           
           <table ><tr><td>
                      <!-- image  -->
  
 <div style="float:left;"  onmouseover="zoom_on(event,250,250,'<%# Eval("PhotoLocation") %>');" onmousemove="zoom_move(event);" onmouseout="zoom_off();"> 
<img src='<%# Eval("PhotoLocation") %>' alt='<%# Eval("ProductName") %>' title='<%# Eval("ProductName") %>' style="padding:0px;margin:0px;border:0px;width:250px;height:250px;float:left" />
</div>  <div style="clear:both;"></div>                
              
         </td>
         <td style="vertical-align:top; text-align:left; overflow:hidden;">  
         <!--    <asp:Image ID="Image1" runat="server" Width="250px" Height="250px" AlternateText='<%# Eval("Description") %>' ImageUrl='<%# Eval("PhotoLocation") %>'/> -->
           
           <br />
          <asp:Label ID="lblItemID" runat="server" Visible="false" Text='<%# Eval("ItemID") %>'></asp:Label>
         
            <asp:Label ID="lblVendorID" runat="server" Visible="false" Text='<%# Eval("VendorID") %>'></asp:Label>
      
        <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
          <br />
           
            Description:
            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'>
            </asp:Label><br />
            QuantityAvailable:
            <asp:Label ID="lblQuantityAvailable" runat="server" Text='<%# Bind("QuantityAvailable") %>'>
            </asp:Label>
            <br />
        
            
            MinQuantity:
            <asp:Label ID="lblMinQuantity" runat="server" Text='<%# Bind("MinQuantity") %>'>
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
            
           
         
            <!-- hyperlink sends querystirng itemID and displays name of item 
                      <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ItemDetails.aspx?ItemID=" + (DataBinder.Eval(Container.DataItem, "ItemID")) %>' ><%# Eval("PhotoName") %></asp:HyperLink>
                      <br />-->
                
           </td>  
           </tr>
         
         
         <tr>
         
         <td>
         
      
           
           
           
           <!-- add to cart button and other stuff --> 
           <div style="text-align:Left;">
           <asp:Label ID="lblQuantity" runat="server" Text="Quantity: "></asp:Label>
           <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("minQuantity") %>'></asp:TextBox>
           <asp:Button runat="server" ID="btnAddToCart" Text="AddToCart" OnClick="btnAddToCart_Click" />
           <br />
            <!-- range validator and required validator for txtQuantity -->
            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtQuantity" MinimumValue='<%# Bind("minQuantity") %>' MaximumValue='<%# Bind("QuantityAvailable") %>' runat="server" ErrorMessage="Quantity must be more than the minimum quantity and less than than the quantity available." Type="Integer" Display="Dynamic"></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Quantity is Required." Display="Dynamic"></asp:RequiredFieldValidator>
              
              <!-- end of table and div -->
              </td></tr>
              </table> 
 </div> 
            
          
        </ItemTemplate>
    </asp:FormView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>"
        SelectCommand="SELECT [ItemID], [VendorID], [IsActive], [Description], [DiscountedPrice], [ProductName], [QuantityAvailable], [Price], [MinQuantity], [PhotoLocation], [PhotoName] FROM [Items] WHERE ([ItemID] = @ItemID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ItemID" QueryStringField="ItemID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
   
       <!-- labels to show status of adding to cart and errors -->
     <asp:Label runat="server" ID="lblSuccessful" Text="" Visible="false" ForeColor="Green"></asp:Label>
     <asp:Label runat="server" ID="lblError" Text="" Visible="false" ForeColor="Red" ></asp:Label> 
   

</asp:Content>
  
        