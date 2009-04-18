<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" EnableEventValidation="false" %>

<%@ Import Namespace="System.Collections.ObjectModel" %>
<%@ Import Namespace="DataAccessModule" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                <td style="width: 440px;">
                    <a href="CheckOut.aspx?Shipping=true">CheckOut without registering.</a>
                    <br />
                </td>
                <td>
                    <asp:Login ID="UserLogin" runat="server" OnLoggedIn="LoggedIn" BackColor="#EFF3FB" BorderColor="#B5C7DE"
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
        <!-- create user wizard
                  OnContinueButtonClick="UserRegistrationWizard_ContinueButtonClick"  -->
        <asp:CreateUserWizard ID="userRegistrationWizard" runat="server" OnCreatedUser="ReconfigureOrder">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Sign Up for Your New Account
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                    Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                        ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="RtxtFirstName">First 
                    Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="RtxtFirstName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="RtxtFirstName"
                                        ErrorMessage="First Name is required." ToolTip="First Name is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="RlblLastName" runat="server" AssociatedControlID="RtxtLastName">Last 
                    Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="RtxtLastName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="RtxtLastName"
                                        ErrorMessage="Last Name is required." ToolTip="Last Name is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAddress" runat="server" AssociatedControlID="RtxtAddress">Address:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="RtxtAddress" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="RtxtAddress"
                                        ErrorMessage="Address is required." ToolTip="Address is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAddress2" runat="server" AssociatedControlID="RtxtAddress2">Address2:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="RtxtAddress2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="RlblCity" runat="server" AssociatedControlID="RtxtCity">City:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="RtxtCity" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CityNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="City Name is required." ToolTip="City Name is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblState" runat="server" AssociatedControlID="cboState">State:</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboState" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblZip" runat="server" AssociatedControlID="RtxtZip">Zip Code:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="RtxtZip" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ZipCodeRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="Zip code is required." ToolTip="Zip code is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCountry" runat="server" AssociatedControlID="cboCountry">Country:</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboCountry" runat="server">
                                        <asp:ListItem>United States Of America</asp:ListItem>
                                        <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                                        <asp:ListItem>The Bahamas</asp:ListItem>
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
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security 
                    Question:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                        ErrorMessage="Security question is required." ToolTip="Security question is required."
                                        ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security 
                    Answer:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                        ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                                        ValidationGroup="userRegistrationWizard">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                        ValidationGroup="userRegistrationWizard"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                                <!-- end of second table and user wizard. -->
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
    <!-- view for inputting in shipping  details -->
    <div runat="server" id="billingInfo" class="billingInfo">
        <!-- display errors -->
        <asp:ValidationSummary ID="vsBillingInfo" runat="server" DisplayMode="List" />
        <!-- start of table -->
        <table class="shippingInfoBackground">
            <tr>
                <td colspan="2">
                    <h1>
                        Shipping Information</h1>
                    <br />
                </td>
            </tr>
            <tr>
                <th colspan="2">
                    Please make sure your shipping information is correct. Thank you!
                </th>
            </tr>
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
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                        <asp:ListItem>AL</asp:ListItem>
                        <asp:ListItem>AK</asp:ListItem>
                        <asp:ListItem>AS</asp:ListItem>
                        <asp:ListItem>AZ</asp:ListItem>
                        <asp:ListItem>AR</asp:ListItem>
                        <asp:ListItem>CA</asp:ListItem>
                        <asp:ListItem>CO</asp:ListItem>
                        <asp:ListItem>CT</asp:ListItem>
                        <asp:ListItem>DE</asp:ListItem>
                        <asp:ListItem>DC</asp:ListItem>
                        <asp:ListItem>FM</asp:ListItem>
                        <asp:ListItem>FL</asp:ListItem>
                        <asp:ListItem>GA</asp:ListItem>
                        <asp:ListItem>GU</asp:ListItem>
                        <asp:ListItem>HI</asp:ListItem>
                        <asp:ListItem>ID</asp:ListItem>
                        <asp:ListItem>IL</asp:ListItem>
                        <asp:ListItem>IN</asp:ListItem>
                        <asp:ListItem>IA</asp:ListItem>
                        <asp:ListItem>KS</asp:ListItem>
                        <asp:ListItem>KY</asp:ListItem>
                        <asp:ListItem>LA</asp:ListItem>
                        <asp:ListItem>ME</asp:ListItem>
                        <asp:ListItem>MH</asp:ListItem>
                        <asp:ListItem>MD</asp:ListItem>
                        <asp:ListItem>MA</asp:ListItem>
                        <asp:ListItem>MI</asp:ListItem>
                        <asp:ListItem>MI</asp:ListItem>
                        <asp:ListItem>MI</asp:ListItem>
                        <asp:ListItem>MI</asp:ListItem>
                        <asp:ListItem>MI</asp:ListItem>
                        <asp:ListItem>MI</asp:ListItem>
                        <asp:ListItem>MN</asp:ListItem>
                        <asp:ListItem>MS</asp:ListItem>
                        <asp:ListItem>MO</asp:ListItem>
                        <asp:ListItem>MT</asp:ListItem>
                        <asp:ListItem>NE</asp:ListItem>
                        <asp:ListItem>NV</asp:ListItem>
                        <asp:ListItem>NH</asp:ListItem>
                        <asp:ListItem>NJ</asp:ListItem>
                        <asp:ListItem>NM</asp:ListItem>
                        <asp:ListItem>NY</asp:ListItem>
                        <asp:ListItem>NC</asp:ListItem>
                        <asp:ListItem>ND</asp:ListItem>
                        <asp:ListItem>MP</asp:ListItem>
                        <asp:ListItem>OH</asp:ListItem>
                        <asp:ListItem>OK</asp:ListItem>
                        <asp:ListItem>OR</asp:ListItem>
                        <asp:ListItem>PW</asp:ListItem>
                        <asp:ListItem>PA</asp:ListItem>
                        <asp:ListItem>PR</asp:ListItem>
                        <asp:ListItem>RI</asp:ListItem>
                        <asp:ListItem>SC</asp:ListItem>
                        <asp:ListItem>SD</asp:ListItem>
                        <asp:ListItem>TN</asp:ListItem>
                        <asp:ListItem>TX</asp:ListItem>
                        <asp:ListItem>UT</asp:ListItem>
                        <asp:ListItem>VT</asp:ListItem>
                        <asp:ListItem>VI</asp:ListItem>
                        <asp:ListItem>VA</asp:ListItem>
                        <asp:ListItem>WA</asp:ListItem>
                        <asp:ListItem>WV</asp:ListItem>
                        <asp:ListItem>WI</asp:ListItem>
                        <asp:ListItem>WY</asp:ListItem>
                    </asp:DropDownList>
                    <!-- validator -->
                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                        Text="*" ErrorMessage="Country is Required." InitialValue="-1"></asp:RequiredFieldValidator>
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
                    <asp:DropDownList ID="ddlCountry" runat="server">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                        <asp:ListItem>United States Of America</asp:ListItem>
                        <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                        <asp:ListItem>The Bahamas</asp:ListItem>
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
                    <!-- validator -->
                    <asp:RequiredFieldValidator ID="rfvCountry" ControlToValidate="ddlCountry" runat="server"
                        Text="*" ErrorMessage="Country is Required." InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmitDetails" runat="server" Text="Submit And Proceed" ToolTip="Submit and Proceed."
                        Width="197px" OnClick="btnSubmitDetails_Click" />
                </td>
            </tr>
            <!-- end of table -->
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
            <h3>
                Shipping Details:</h3>
            <!-- repeater to display shipping details -->
            <asp:Repeater runat="server" ID="rptShippingAddress">
                <ItemTemplate>
                    <asp:Label runat="server" ID="SlblFName" Text='<%# Eval("FirstName") %>'></asp:Label>
                    <asp:Label runat="server" ID="SlblLName" Text='<%# Eval("LastName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="SlblAddress1" Text='<%# Eval("Address") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="SlblAddress2" Text='<%# Eval("Address2") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="ClblCity" Text='<%# Eval("City") %>'></asp:Label>,
                    <asp:Label runat="server" ID="SlblState" Text='<%# Eval("State") %>'></asp:Label>,
                    <asp:Label runat="server" ID="ZlblZip" Text='<%# Eval("Zip") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="SlblCountry" Text='<%# Eval("Country") %>'></asp:Label>
                </ItemTemplate>
            </asp:Repeater>
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
          
            <!-- labels that display errors -->
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Size="10pt"></asp:Label>
            <asp:Label ID="lblQuantityError" runat="server" Text=" " ForeColor="Red" Font-Size="10pt"></asp:Label>
           
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
            <!-- needs for to work -->
            <form action="">
            </form>
            <!-- check out with paypal   -->
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




                    if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        // into the session


                        Order order = new Order();
                        order.CustomerId = int.Parse(GetCustomerID());
                        order.TxnId = "";

                        OrderDA orderDA = new OrderDA();

                        Collection<Order> getOrder = orderDA.Get(order);


                        orderID = getOrder[0].Id;
                        tax = getOrder[0].Tax;

                        realTax = double.Parse(tax.ToString(), System.Globalization.NumberStyles.Currency);




                        //clear
                        order = null;
                        orderDA = null;
                        getOrder = null;

                        if (GridView1.Rows.Count > 0)
                        {


                            Response.Write(" <form id='paypal' name='paypal' action='https://www.sandbox.paypal.com/us/cgi-bin/webscr' method='post' />");
                            Response.Write(" <input type='hidden' name='cmd' value='_cart' />");
                            Response.Write(" <input type='hidden' name='upload' value='1' />");
                            Response.Write(" <input type='hidden' name='business' value='akagon_1236919720_biz@yahoo.com' />");
                            Response.Write(" <input type='hidden' name='return' value='http://www.mypetsfavoritewebsite.com/PurchaseCompleted.aspx' />");
                            Response.Write(" <input type='hidden' name='cancel_return' value='http://www.mypetsfavoritewebsite.com/PurchaseCancelled.aspx' />");
                            Response.Write(" <input type='hidden' name='custom' value='" + orderID.ToString() + "' />");

                            Response.Write("<input type='hidden' name='tax_cart' value='" + realTax.ToString("n2") + "' />");

                            Response.Write("<input type='hidden' name='currency_code' value='USD' />");



                            // get customer shipping details to send to paypal
                            // get customer information to pass on to paypal
                            //Instantiate our Customer specific DataAccess Class
                            CustomerDA customerDA = new CustomerDA();

                            // check to see if user has items in their cart
                            //Create an Object that specifies what we want to Get
                            Customer customer = new Customer();

                            //gets customer info based on customer id

                            customer.Id = int.Parse(GetCustomerID());

                            //We will be returned a collection so lets Declare that and fill it using Get()
                            Collection<Customer> getCustomer = customerDA.Get(customer);

                            



                            // Enable override of payer's stored PayPal address. 
                            Response.Write("<input type='hidden' name='address_override' value='1'/>");
                            //<!-- Set prepopulation variables to override stored address. --> 
                            Response.Write("<input type='hidden' name='first_name' value='" + getCustomer[0].FirstName.ToString() + "' />");
                            Response.Write("<input type='hidden' name='last_name' value='" + getCustomer[0].LastName.ToString() + "' />");
                            Response.Write("<input type='hidden' name='address1' value='" + getCustomer[0].Address.ToString() + "' />");
                            Response.Write("<input type='hidden' name='address2' value='" + getCustomer[0].Address2.ToString() + "' />");
                            Response.Write("<input type='hidden' name='state' value='" + getCustomer[0].State.ToString() + "' />");
                            Response.Write("<input type='hidden' name='city' value='" + getCustomer[0].City.ToString() + "' />");
                            Response.Write("<input type='hidden' name='zip' value='" + getCustomer[0].Zip.ToString() + "' />");
                            Response.Write("<input type='hidden' name='country' value='" + getCustomer[0].Country.ToString() + "' />");

                            // clear
                            customerDA = null;
                            customer = null;
                            getCustomer = null;
                            
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

                    else if (Session["AnonymousUserName"] != null)
                    {

                        Customer customerID2 = new Customer();
                        customerID2.Username = Session["AnonymousUserName"].ToString();

                        CustomerDA customerDA2 = new CustomerDA();

                        Collection<Customer> getCustomer2 = customerDA2.Get(customerID2);

                        customerID = getCustomer2[0].Id;


                        //clear
                        customerID2 = null;
                        customerDA2 = null;
                        getCustomer2 = null;


                        Order order = new Order();
                        order.CustomerId = int.Parse(GetCustomerID());
                        order.TxnId = "";

                        OrderDA orderDA = new OrderDA();

                        Collection<Order> getOrder = orderDA.Get(order);


                        orderID = getOrder[0].Id;
                        tax = getOrder[0].Tax;


                        //clear
                        order = null;
                        orderDA = null;
                        getOrder = null;


                        if (GridView1.Rows.Count > 0)
                        {

                            // start of paypal form              
                            Response.Write(" <form id='paypal' name='paypal' action='https://www.sandbox.paypal.com/us/cgi-bin/webscr' method='post' />");
                            Response.Write(" <input type='hidden' name='cmd' value='_cart' />");
                            Response.Write(" <input type='hidden' name='upload' value='1' />");
                            Response.Write(" <input type='hidden' name='business' value='akagon_1236919720_biz@yahoo.com' />");
                            Response.Write(" <input type='hidden' name='return' value='http://www.mypetsfavoritewebsite.com/PurchaseCompleted.aspx' />");
                            Response.Write(" <input type='hidden' name='cancel_return' value='http://www.mypetsfavoritewebsite.com/PurchaseCancelled.aspx' />");
                            Response.Write(" <input type='hidden' name='custom' value='" + orderID + "' />");

                            Response.Write("<input type='hidden' name='tax_cart' value='" + tax + "' />");

                            Response.Write("<input type='hidden' name='currency_code' value='USD' />");



                            // check to see if user has items in their cart
                            //Create an Object that specifies what we want to Get
                            Customer customer = new Customer();

                            // get customer information to pass on to paypal
                            //Instantiate our Customer specific DataAccess Class
                            CustomerDA customerDA = new CustomerDA();

                            // get customer info based on customer id

                            customer.Id = int.Parse(customerID.ToString());

                            //We will be returned a collection so lets Declare that and fill it using Get()
                            Collection<Customer> getCustomer = customerDA.Get(customer);



                            // Enable override of payer's stored PayPal address. 
                            Response.Write("<input type='hidden' name='address_override' value='1'/>");
                            //<!-- Set prepopulation variables to override stored address. --> 
                            Response.Write("<input type='hidden' name='first_name' value='" + getCustomer[0].FirstName.ToString() + "' />");
                            Response.Write("<input type='hidden' name='last_name' value='" + getCustomer[0].LastName.ToString() + "' />");
                            Response.Write("<input type='hidden' name='address1' value='" + getCustomer[0].Address.ToString() +  "' />");
                            Response.Write("<input type='hidden' name='address2' value='" + getCustomer[0].Address2.ToString() + "' />");
                            Response.Write("<input type='hidden' name='state' value='" + getCustomer[0].State.ToString() + "' />");
                            Response.Write("<input type='hidden' name='city' value='" + getCustomer[0].City.ToString() + "' />");
                            Response.Write("<input type='hidden' name='zip' value='" + getCustomer[0].Zip.ToString() + "' />");
                            Response.Write("<input type='hidden' name='country' value='" + getCustomer[0].Country.ToString() + "' />");
                            
                            // clear
                            customerDA = null;
                            customer = null;
                            getCustomer = null;



                            // create incremental variables
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
