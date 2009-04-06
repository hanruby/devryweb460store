<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="ViewOrder" Title="Untitled Page" %>
<%@ Register src="Controls/ViewOrders.ascx" tagname="ViewOrders" tagprefix="uc1" %>


<asp:Content ID="Content6" ContentPlaceHolderID="mainContentPH" Runat="Server">
    <asp:Label ID="lblOrderID" runat="server" Text="Order ID:"></asp:Label> &nbsp
    <asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox><br />
    
    <asp:Button ID="btnLookUp" runat="server" Text="Look Up" OnClick="btnLookUp_Click" /><br /><br />
    <asp:Label ID="lblNoOrder" runat="server" Text="There is no Order for that ID"></asp:Label>
    <asp:FormView ID="FormView1" runat="server">
        <ItemTemplate>
            <table>
                <tr><td align="right"><b>Name: </b></td><td><%# Eval("FName")%> <%# Eval("LName")%></td></tr>
                <tr><td align="right"><b>Sub Total: </b></td><td><%# Eval("GrossTotal")%></td></tr>
                <tr><td align="right"><b>Tax: </b></td><td><%# Eval("Tax")%></td></tr>
                <tr><td align="right"><b>Net Total: </b></td><td><%# Eval("NetTotal")%></td></tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <br /><br /><br />
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table style="text-align: center;">
            <tr>
                <td>Description</td> <td>Quantity</td> <td>Price</td><td>Tracking URL</td><td>Ship Date</td><td>Est. Arrival</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#DataBinder.Eval(Container.DataItem, "Description")%> </td>
                <td><%#DataBinder.Eval(Container.DataItem, "Quantity")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "Price")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "TrackingURL")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "ShipDate")%></td>
                <td><%#DataBinder.Eval(Container.DataItem, "EstArrival")%></td>
            </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    
    <%--<uc1:ViewOrders ID="ViewOrders1" runat="server" />--%>
    
</asp:Content>


