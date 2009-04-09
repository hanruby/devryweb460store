<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 440px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navMenuPH" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent2" runat="Server">
    <!-- script manager for the page -->
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- view for logging in and registering/continueing without making an account -->
    <a href="CheckOut.aspx?CheckOut=true">Login</a> | <a href="CheckOut.aspx?Shipping=true">
        Shipping Information</a> | <a href="CheckOut.aspx?OrderReview=true">Order Review + PayPal</a>
    <br />
    <br />
    <br />
    <div runat="server" id="registerOrLogin">
        <table id="checkOutTable">
            <tr>
                <td class="style1">
                    <a href="CheckOut.aspx?Billing=true">CheckOut without registering.</a>
                    <br />
                    <a href="CheckOut.aspx?Billing=true">Register to become a member of MyPetsFW.com!</a>
                </td>
                <td>
                    <asp:Login ID="Login1" runat="server" OnLoggedIn="LoggedIn" BackColor="#EFF3FB" BorderColor="#B5C7DE"
                        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                        Font-Size="12pt" ForeColor="#333333" Height="150px" Width="474px">
                        <TextBoxStyle Font-Size="12pt" Width="200" />
                        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Verdana" Font-Size="12pt" ForeColor="#284E98" />
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="12pt" ForeColor="White" />
                    </asp:Login>
                </td>
            </tr>
        </table>
    </div>
    <!-- view for putting in shipping  details -->
    <div runat="server" id="billingInfo">
        <!-- display errors -->
        <asp:ValidationSummary ID="vsBillingInfo" runat="server" DisplayMode="List" />
        <table>
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" ToolTip="Enter your first name."></asp:TextBox>
                    <!-- required field validator -->
                    <asp:RequiredFieldValidator ID="rvFirstName" runat="server" ErrorMessage="First Name is required."
                        Text="*" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Middle Initial:
                </td>
                <td>
                    <asp:TextBox ID="txtMiddleInitial" runat="server" MaxLength="1" ToolTip="Enter your middle initial."></asp:TextBox>
                    <!-- required field validator -->
                    <asp:RequiredFieldValidator ID="rvMI" runat="server" ErrorMessage="Middle Initial is required."
                        Text="*" ControlToValidate="txtMiddleInitial"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" ToolTip="Enter your last name."></asp:TextBox>
                    <!-- required field validator -->
                    <asp:RequiredFieldValidator ID="rvLastName" runat="server" ErrorMessage="Last Name is required."
                        Text="*" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Address1:
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" MaxLength="50" ToolTip="Enter your Address."></asp:TextBox>
                    <!-- required field validator -->
                    <asp:RequiredFieldValidator ID="rvAddress1" runat="server" ErrorMessage="Address 1 is required."
                        Text="*" ControlToValidate="txtAddress1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Address2:
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50" ToolTip="Enter your address."></asp:TextBox>
                    <!-- required field validator -->
                    <asp:RequiredFieldValidator ID="rvAddress2" runat="server" ErrorMessage="Address 2 is required."
                        Text="*" ControlToValidate="txtAddress2"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    City:
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" MaxLength="50" ToolTip="Enter your city."></asp:TextBox>
                    <!-- required field validator -->
                    <asp:RequiredFieldValidator ID="rvCity" runat="server" ErrorMessage="City is required."
                        Text="*" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    State:
                </td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" Height="16px" Width="122px" ToolTip="Select your state.">
                    </asp:DropDownList>
                    <!-- required expression validator -->
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                        runat="server" ErrorMessage="State is Required." Text="*" ControlToValidate="ddlState"
                        ValidationExpression="^[A-Z]{2}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Zip Code:
                </td>
                <td>
                    <!-- required field validator -->
                    <asp:TextBox ID="txtZipCode" runat="server" MaxLength="5" ToolTip="Enter your zip code."></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Zip Code is required."
                        Text="*" ControlToValidate="txtZipCode" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reState" Text="*" Display="Dynamic" runat="server"
                        ErrorMessage="Zip code cannot have letters and must be 5 digits long." ControlToValidate="txtZipCode"
                        ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Country:
                </td>
                <td>                            
                
                    <!-- regular expression field validator -->
                    <asp:DropDownList ID="ddlCountry" runat="server">
                        <asp:ListItem Value="1">Select</asp:ListItem>
                        <asp:ListItem>United States Of America</asp:ListItem>
                        <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                        <asp:ListItem>The Bahamas"</asp:ListItem>
                        <asp:ListItem>Barbados</asp:ListItem>
                        <asp:ListItem>Belize</asp:ListItem>
                        <asp:ListItem>Canada</asp:ListItem>
                        <asp:ListItem>Costa Rica</asp:ListItem>
                        <asp:ListItem>Cuba</asp:ListItem>
                        <asp:ListItem>Dominica</asp:ListItem>
                        <asp:ListItem>Dominican-Republic</asp:ListItem>
                        <asp:ListItem>Greenland</asp:ListItem>
                        <asp:ListItem>Grenada</asp:ListItem>
                        <asp:ListItem>Guatemala</asp:ListItem>
                        <asp:ListItem>Haiti</asp:ListItem>
                        <asp:ListItem>Jamaica</asp:ListItem>
                        <asp:ListItem>Mexico</asp:ListItem>
                        <asp:ListItem>Nicaragua</asp:ListItem>
                        <asp:ListItem>Panama</asp:ListItem>
                        <asp:ListItem>Saint Kitts and Nevis</asp:ListItem>
                        <asp:ListItem>Saint Lucia</asp:ListItem>
                        <asp:ListItem>Saint Vincent and the Grenadines</asp:ListItem>
                        <asp:ListItem>Trinidad and Tobago</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCountry" ControlToValidate="ddlCountry" runat="server" Text="*" ErrorMessage="Country is Required." InitialValue="1"></asp:RequiredFieldValidator>
                   
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmitDetails" runat="server" Text="Submit And Proceed" ToolTip="Submit and Proceed."
                        Width="197px" OnClick="btnSubmitDetails_Click" />
                </td>
            </tr>
        </table>
    </div>
    <!-- div for reviewing shopping cart information -->
    <div runat="server" id="orderReview">
        <h1>
            Order Review</h1>
        <!-- div for displaying item prices and quantity -->
        <div style="font-family: Andalus; background-color: Olive;">
            <!-- shopping cart is empty message when anonymousUserName sessionID is empty -->
            <div runat="server" id="items">
            </div>
            <br />
            <!-- GridView to display items -->
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                CssClass="tablesorter">
                <Columns>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Width="50" Text='<%# Eval("Quantity")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:Label ID="lblVendorIDHidden" Visible="false" runat="server" Text='<%# Eval("VendorID")%>'></asp:Label>
                            <asp:Label ID="lblOrderIDHidden" Visible="false" runat="server" Text='<%# Eval("OrderID")%>'></asp:Label>
                            <asp:Label ID="lblItemIDHidden" runat="server" Visible="false" Text='<%# Eval("ItemID")%>'></asp:Label>
                            <asp:Label ID="lblItemName" runat="server" Text="Item Name: "></asp:Label>
                            <asp:Label ID="lblItemNameAnswer" runat="server" Text='<%# Eval("ProductName")%>'></asp:Label>
                            <asp:Image ID="imgPhotoLocation" runat="server" ImageUrl='<%# Eval("PhotoLocation")%>'
                                CssClass="shoppingCartProductImage" />
                            <br />
                            <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
                            <asp:Label ID="lblDescriptionAnswer" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                            <br />
                            <asp:Label ID="lblMinQuantity" runat="server" Text="Minimum Quantity: "></asp:Label>
                            <asp:Label ID="lblMinQuantityAnswer" runat="server" Text='<%# Eval("MinQuantity")%>'></asp:Label>
                            <br />
                            <asp:Label ID="lblQuantityAvailable" runat="server" Text="Quantity Available: "></asp:Label>
                            <asp:Label ID="lblQuantityAvailableAnswer" runat="server" Text='<%# Eval("QuantityAvailable")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price",  "{0:C}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Price">
                        <ItemTemplate>
                            <asp:Label ID="lblTotaIndividualPrice" runat="server" Text='<%# Eval("TotalPrice",  "{0:C}")%>'></asp:Label>
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
            <br />
            <!-- labels that display errors -->
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Size="10pt"></asp:Label>
            <asp:Label ID="lblQuantityError" runat="server" Text=" " ForeColor="Red" Font-Size="10pt"></asp:Label>
            <br />
            <div style="text-align: right;">
                <!-- repeater for total price, tax, grosstotal, shipping? *future*??? -->
                <asp:Repeater runat="server" ID="rptOne">
                    <ItemTemplate>
                        <asp:Label ID="lblNetTotal" runat="server" Text="Net Total: "></asp:Label>
                        <asp:Label ID="lblNetTotalAnswer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NetTotal", "{0:C}")%>'></asp:Label>
                        <br />
                        <asp:Label ID="lblTax" runat="server" Text="Tax: "></asp:Label>
                        <asp:Label ID="lblTaxAnswer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Tax",  "{0:C}")%>'></asp:Label>
                        <br />
                        <asp:Label ID="lblGrossTotal" runat="server" Text="Gross Total: "></asp:Label>
                        <asp:Label ID="lblGrossTotalAnswer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GrossTotal", "{0:C}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:Repeater>
                
                
              
            </div>
            
            <!-- end of shopping cart div -->
        </div>
            
           
            <!-- div for displaying update button -->
            <div style="font-family: @Arial Unicode MS; background-color: Gray; height: auto;
                text-align: center;" id="viewOrder">
            
                  <asp:Button ID="btnUpdateQuantity" runat="server" Text="Update Cart" OnClick="btnUpdateQuantity_Click" />
              
                <hr />
                <h2>
                    OR</h2>
                <hr />
          
                       <!-- check out with paypal   -->
                       
                       
                       
                       <form></form> 
            
                <div id="Div1" runat="server">
                    <% 
              
                       
              
                        object customerID;

                        TextBox quantity;


                        Label itemID;
                        object orderID;
                        object tax;
                        double realTax;
                       // double realOrderID;
                        Label vendorID;
                        Label totalIndividualItem;
                        Label price;
                        
                        Label productName;

                        // used to warn user if quantity entered is invalid
                        // count and totalCount are used for counting 
                        // the total price in the shopping cart
                        int minQuantityInt;
                        int quantityAvailableInt;
                        int quantityInt;
                        int count;
                        int totalCount;



                        // get ID of user so I can get the tax for their order




                        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                        {
                            // get the id of the user that I just created and put it
                            // into the session
                            DAL.DataAccess da19 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                            // make command statement 
                            string comm19 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
                            //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                            DataSet ds19 = new DataSet();


                            // make arrays for paramaters and input
                            string[] s19 = { "@username" };
                            string[] v19 = { Membership.GetUser().UserName };
                            ds19 = da19.ExecuteQuery(comm19, s19, v19);


                            customerID = ds19.Tables[0].Rows[0].ItemArray[0];



                            //clear
                            s19 = null;
                            v19 = null;


                            
                            // into the session
                            DAL.DataAccess da20= new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                            // make command statement 
                            string comm20 = "SELECT OrderID, Tax FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
                            //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                            DataSet ds20 = new DataSet();


                            // make arrays for paramaters and input
                            string[] s20 = { "@customerID", "@txnID" };
                            string[] v20 = { customerID.ToString(), "" };
                            ds20 = da20.ExecuteQuery(comm20, s20, v20);


                            orderID = ds20.Tables[0].Rows[0]["OrderID"];
                            tax = ds20.Tables[0].Rows[0]["Tax"];
                            
                            realTax = double.Parse(tax.ToString(), System.Globalization.NumberStyles.Currency);
                            
                            
             
                            
                            //clear
                            s19 = null;
                            v19 = null;

                            if (GridView1.Rows.Count > 0)
                            {
                              

                                Response.Write(" <form id='paypal' name='paypal' action='https://www.sandbox.paypal.com/us/cgi-bin/webscr' method='post' />");
                                Response.Write(" <input type='hidden' name='cmd' value='_cart' />");
                                Response.Write(" <input type='hidden' name='upload' value='1' />");
                                Response.Write(" <input type='hidden' name='business' value='akagon_1236919720_biz@yahoo.com' />");
                                Response.Write(" <input type='hidden' name='return' value='http://www.mypetsfavoritewebsite.com/Complete.aspx' />");
                                Response.Write(" <input type='hidden' name='cancel_return' value='http://www.mypetsfavoritewebsite.com/Cancelled.aspx' />");
                                Response.Write(" <input type='hidden' name='custom' value='" + orderID.ToString() + "' />");

                                Response.Write("<input type='hidden' name='tax_cart' value='" + realTax.ToString("n2") + "' />");

                                Response.Write("<input type='hidden' name='currency_code' value='USD' />");







                                // Enable override of payer's stored PayPal address. 
                                Response.Write("<input type='hidden' name='address_override' value='1'/>");
                                //<!-- Set prepopulation variables to override stored address. --> 
                                Response.Write("<input type='hidden' name='first_name' value='John' />");
                                Response.Write("<input type='hidden' name='last_name' value='Homes' />");
                                Response.Write("<input type='hidden' name='address1' value='545 W NorthShire Road' />");
                                Response.Write("<input type='hidden' name='state' value='AZ' />");
                                Response.Write("<input type='hidden' name='city' value='phoenix' />");
                                Response.Write("<input type='hidden' name='zip' value='85031' />");
                                Response.Write("<input type='hidden' name='country' value='US' />");





                                int itemCount = 1;
                                int amountCount = 1;
                                int quantityCount = 1;
                                int itemNumberCount = 1;



                                foreach (GridViewRow item in GridView1.Rows)
                                {

                                    //  
                                    quantity = (TextBox)item.FindControl("txtQuantity");
                                    itemID = (Label)item.FindControl("lblItemIDHidden");
                                    productName = (Label)item.FindControl("lblItemNameAnswer");

                                    price = (Label)item.FindControl("lblPrice");
                                    totalIndividualItem = (Label)item.FindControl("lblTotaIndividualPrice");
                                    vendorID = (Label)item.FindControl("lblVendorIDHidden");


                                    double x = double.Parse(price.Text, System.Globalization.NumberStyles.Currency);


                                    // get the item_name? plus the amount(price) and quantity(part of quantity is manual for now)
                                    Response.Write("<input type='hidden' name='item_name_" + itemCount++ + "'" + " value='" + productName.Text +
                                                        "'" + "  />");
                                    Response.Write("<input type='hidden' name='amount_" + amountCount++ + "'" + " value='" + price.Text + "'" +
                                    " />");
                                    Response.Write("<input type='hidden' name='quantity_" + quantityCount++ + "'" + " value='" + quantity.Text + "' />");
                                    Response.Write("<input type='hidden' name='item_number_" + itemNumberCount++ + "'" + " value='" +
                                    itemID.Text + "' />");
                                }
                                // calculates total amount and submit input type
                                Response.Write("<button type='submit'  value='Buy Now Using PayPal'><img src='https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif' width='125px' height='50px' /></button>" +
                                       " </form>");

                            }// end of if statement
                        }

                        if (Session["AnonymousUserName"] != null)
                        {
                            // get the id of the user that I just created and put it
                            // into the session
                            DAL.DataAccess da19 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                            // make command statement 
                            string comm19 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
                            //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                            DataSet ds19 = new DataSet();


                            // make arrays for paramaters and input
                            string[] s19 = { "@username" };
                            string[] v19 = { Session["AnonymousUserName"].ToString() };
                            ds19 = da19.ExecuteQuery(comm19, s19, v19);


                            customerID = ds19.Tables[0].Rows[0].ItemArray[0];



                            //clear
                            s19 = null;
                            v19 = null;


                            // into the session
                            DAL.DataAccess da20 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                            // make command statement 
                            string comm20 = "SELECT OrderID, Tax FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
                            //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                            DataSet ds20 = new DataSet();


                            // make arrays for paramaters and input
                            string[] s20 = { "@customerID", "@txnID" };
                            string[] v20 = { customerID.ToString(), "" };
                            ds20 = da20.ExecuteQuery(comm20, s20, v20);


                            orderID = ds20.Tables[0].Rows[0]["OrderID"];
                            tax = ds20.Tables[0].Rows[0]["Tax"];


                            //clear
                            s19 = null;
                            v19 = null; 
                            
                            
                            if (GridView1.Rows.Count > 0)
                        {
                            

                            Response.Write(" <form id='paypal' name='paypal' action='https://www.sandbox.paypal.com/us/cgi-bin/webscr' method='post' />");
                            Response.Write(" <input type='hidden' name='cmd' value='_cart' />");
                            Response.Write(" <input type='hidden' name='upload' value='1' />");
                            Response.Write(" <input type='hidden' name='business' value='akagon_1236919720_biz@yahoo.com' />");
                            Response.Write(" <input type='hidden' name='return' value='http://www.mypetsfavoritewebsite.com/Complete.aspx' />");
                            Response.Write(" <input type='hidden' name='cancel_return' value='http://www.mypetsfavoritewebsite.com/Cancelled.aspx' />");
                            Response.Write(" <input type='hidden' name='custom' value='" + orderID + "' />");

                            Response.Write("<input type='hidden' name='tax_cart' value='" + tax + "' />");

                            Response.Write("<input type='hidden' name='currency_code' value='USD' />");


                         




                            // Enable override of payer's stored PayPal address. 
                            Response.Write("<input type='hidden' name='address_override' value='1'/>");
                            //<!-- Set prepopulation variables to override stored address. --> 
                            Response.Write("<input type='hidden' name='first_name' value='John' />");
                            Response.Write("<input type='hidden' name='last_name' value='Homes' />");
                            Response.Write("<input type='hidden' name='address1' value='545 W NorthShire Road' />");
                            Response.Write("<input type='hidden' name='state' value='AZ' />");
                            Response.Write("<input type='hidden' name='city' value='phoenix' />");
                            Response.Write("<input type='hidden' name='zip' value='85031' />");
                            Response.Write("<input type='hidden' name='country' value='US' />");





                            int itemCount = 1;
                            int amountCount = 1;
                            int quantityCount = 1;
                            int itemNumberCount = 1;



                            foreach (GridViewRow item in GridView1.Rows)
                            {

                                //  
                                quantity = (TextBox)item.FindControl("txtQuantity");
                                itemID = (Label)item.FindControl("lblItemIDHidden");
                                productName = (Label)item.FindControl("lblItemNameAnswer");

                                price = (Label)item.FindControl("lblPrice");
                                totalIndividualItem = (Label)item.FindControl("lblTotaIndividualPrice");
                                vendorID = (Label)item.FindControl("lblVendorIDHidden");


                                double x = double.Parse(price.Text, System.Globalization.NumberStyles.Currency);


                                // get the item_name? plus the amount(price) and quantity(part of quantity is manual for now)
                                Response.Write("<input type='hidden' name='item_name_" + itemCount++ + "'" + " value='" + productName.Text +
                                                    "'" + "  />");
                                Response.Write("<input type='hidden' name='amount_" + amountCount++ + "'" + " value='" + price.Text + "'" +
                                " />");
                                Response.Write("<input type='hidden' name='quantity_" + quantityCount++ + "'" + " value='" + quantity.Text + "' />");
                                Response.Write("<input type='hidden' name='item_number_" + itemNumberCount++ + "'" + " value='" +
                                itemID.Text + "' />");
                            }
                            // calculates total amount and submit input type
                            Response.Write("<button type='submit'  value='Buy Now Using PayPal'><img src='https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif' width='125px' height='50px' /></button>" +
                                   " </form>");

                        }// end of if statement
                        }

                        
                            
                       
                        
                        
                        
                        
                       
              
               
              
                    %> 
                   
                            

                </div>
            </div>
             <!--  <div id="divPayPal" runat="server" /> -->
        <!-- end of order review div -->
        </div> 
        
        
        
 
</asp:Content>
