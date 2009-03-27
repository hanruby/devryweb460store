<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewCustomers.ascx.cs" Inherits="Controls_ViewCustomers" %>
<fieldset>
    <legend>View Customer Info</legend>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" />&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Click to retrieve a list of customers who are registered users"></asp:Label>
    <br /><br />
    <asp:DataList ID="dlRegisteredCustomers" runat="server" AlternatingItemStyle-BackColor="#f8f8f8" RepeatDirection="Vertical" HeaderStyle-BackColor="black" HeaderStyle-ForeColor="white" HeaderStyle-Font-Bold="true">
        <HeaderTemplate>
            Customers
        </HeaderTemplate>
        <ItemTemplate>
        <table border="1" style="padding:4px">
            <thead>
                <tr>
                    <th>Customer ID</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Address</th>

                    <th>City</th>
                    <th>State</th>
                    <th>Zip</th>
                    <th>Country</th>
                    <th>UserName</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><%#DataBinder.Eval(Container.DataItem, "CustomerID") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "FName") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "LName") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Address") %><br />
                    <%#DataBinder.Eval(Container.DataItem, "Address2") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "City") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "State") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Zip") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Country") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "UserName") %></td>
                    <td><%#DataBinder.Eval(Container.DataItem, "Email") %></td>
                </tr>
            </tbody>
        </table>   
    </ItemTemplate>
    </asp:DataList>
</fieldset>