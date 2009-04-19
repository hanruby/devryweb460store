<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewOrders3.ascx.cs" Inherits="Controls_ViewOrders3" %>
<fieldset>
<legend>Order lookup</legend>
    <asp:Label ID="lblOrderID" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txtOrderId" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnLookUp" runat="server" Text="Look Up" OnClick="btnLookUp_Click" /><br /><br />
    <asp:Label ID="lblNoOrder" runat="server" Text="There is no Order for that ID" Visible="false"></asp:Label>
    
    <asp:GridView ID="gvOrders1" runat="server" CssClass="tablesorter"></asp:GridView>

</fieldset>