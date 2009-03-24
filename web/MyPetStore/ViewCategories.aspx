<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCategories.aspx.cs" Inherits="MyPetStore_ViewCategories" Title="Untitled Page" %>

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
<asp:TextBox runat="server" id="txtsearch"></asp:TextBox>
<asp:button runat="server" id="btnClickMe" onclick="btnClickMe_Click" />
<asp:Repeater ID="repeater1" runat="server">
    <ItemTemplate>
        something: <%#DataBinder.Eval(Container.DataItem, "CategoryName") %> <br />
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

