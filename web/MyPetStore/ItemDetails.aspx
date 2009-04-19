<%@ Page Language="C#" MasterPageFile="MasterPage2.master" AutoEventWireup="true"
    CodeFile="ItemDetails.aspx.cs" Inherits="ItemDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" runat="Server">
  
            
             <!-- script manager for page -->
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ItemID,VendorID" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            
           
             <!-- div to center align table -->
            <div class="centerAlign" > 
               <!-- start of table -->
            <table class="itemDetailsBackground" >
                <tr>
                    <td style="vertical-align:top; width:200px; height:300px">
                    <br />
         
                        <!--  tell user they can use arrow keys to expand, zoom in, zoom out, of image -->
                        <asp:Label ID="lblMagnify" runat="server" Text="Place mouse over image to magnify it."></asp:Label>
                        <br />
                        <asp:Label ID="lblArrows" runat="server" Text="Use arrow keys on keyboard to zoom in and out and expand and decrease magnifying glass's size."></asp:Label>
                        <br />
                        <br />
                         <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                        <br />
                        <!-- image  -->
                        <div style="float: left;" onmouseover="zoom_on(event,200,200,'<%# Eval("PhotoLocation") %>');"
                            onmousemove="zoom_move(event);" onmouseout="zoom_off();">
                            <img src='<%# Eval("PhotoLocation") %>' alt='<%# Eval("ProductName") %>' title='<%# Eval("ProductName") %>'
                                style="padding: 0px; margin: 0px; border: 0px; width: 200px; height: 200px; float: left" />
                        </div>
                        <div style="clear: both;">
                        </div>
                    </td>
                    <td style="vertical-align: top; text-align: left; max-width:200px; overflow:hidden;">
                        <asp:Label ID="lblItemID" runat="server" Visible="false" Text='<%# Eval("ItemID") %>'></asp:Label>
                        <asp:Label ID="lblVendorID" runat="server" Visible="false" Text='<%# Eval("VendorID") %>'></asp:Label>
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                        Description:
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'>
                        </asp:Label><br />
                        <asp:Label ID="lblSize" runat="server" Text="Size: "></asp:Label>
                        
                        <%  
                            Label sizeAnswer = (Label)FormView1.FindControl("lblSizeAnswer");
                            if (sizeAnswer.Text == "")
                            {
                     

                                sizeAnswer.Text = "N/A";
                          
                        
                            }%>
                       
                        <asp:Label ID="lblSizeAnswer" runat="server" Text='<%# Bind("Size") %>'>
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
                        <del>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price", "{0:C}") %>' ForeColor="Red"></asp:Label></del>
                        <br />
                        <%} %>
                        <%  Label salePriceAnswer2 = (Label)FormView1.FindControl("lblSalePriceAnswer");

                            if (salePriceAnswer2.Visible == false)
                            { %>
                        <asp:Label ID="lblPrice2" runat="server" Text='<%# Bind("Price", "{0:C}") %>' ForeColor="Red"></asp:Label><br />
                        <%} %>
                        <!-- discounted price -->
                        <asp:Label ID="lblSalePrice" runat="server" Text="On Sale: "></asp:Label>
                        <asp:Label ID="lblSalePriceAnswer" runat="server" Text='<%# Bind("DiscountedPrice", "{0:C}") %>'
                            ForeColor="Green"></asp:Label><br />
                      
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <!-- add to cart button and other stuff -->
                        <div style="text-align:center;">
                            <asp:Label ID="lblQuantity" runat="server" Text="Quantity: "></asp:Label>
                            <asp:TextBox ID="txtQuantity" runat="server" Width="50px" Text='<%# Bind("minQuantity") %>'></asp:TextBox>
                            <asp:Button runat="server" ID="btnAddToCart" Text="AddToCart" OnClick="btnAddToCart_Click" />
                            
                            <br />
                            
                             <!-- labels to show status of adding to cart and sold out message -->
                             <asp:Label runat="server" ID="lblSuccessful" Text="" Visible="false" ForeColor="Green"></asp:Label>
                             <asp:Label runat="server" ID="lblError" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <br />
                            <!--  range validator for txtQuantity -->
                          


                            <asp:RangeValidator ID="rvQuantity" ControlToValidate="txtQuantity" MinimumValue=""
                                MaximumValue="" runat="server" ErrorMessage="Quantity must be the same or more than the minimum quantity and the same or less than  the quantity available."
                                Type="Integer" Display="Dynamic"></asp:RangeValidator>
                        
                             
                             

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuantity"
                                ErrorMessage="Quantity is Required." Display="Dynamic"></asp:RequiredFieldValidator>
                            <!-- end of table and div --> 
                         
           </div>
                    </td>
                </tr>
            </table>
    
     <!-- end of center align table div -->
          </div>
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>"
        SelectCommand="SELECT [ItemID], [VendorID], [IsActive], [Size], [Description], [DiscountedPrice], [ProductName], [QuantityAvailable], [Price], [MinQuantity], [PhotoLocation], [PhotoName] FROM [Items] WHERE ([ItemID] = @ItemID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ItemID" QueryStringField="ItemID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
   
        
</asp:Content>
