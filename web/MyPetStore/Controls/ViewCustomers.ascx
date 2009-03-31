<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewCustomers.ascx.cs" Inherits="Controls_ViewCustomers" %>
<fieldset>
    <legend>View Customer Info</legend>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" />&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Click to retrieve a list of customers who are registered users"></asp:Label>
    <br /><br />
        <asp:GridView ID="gvCustomers" runat="server" CssClass="tablesorter">
        </asp:GridView>
</fieldset>
