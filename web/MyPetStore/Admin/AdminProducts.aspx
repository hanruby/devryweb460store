<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminProducts.aspx.cs" Inherits="Admin_AdminProducts" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headerPH" Runat="Server">
    <p>
        q</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navMenuPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftColumnPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PagePhotoPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="mainContentPH" Runat="Server">

    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
    AutoGenerateColumns="False" DataKeyNames="ItemID,VendorID" 
    DataSourceID="AdminProducts">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="ItemID" HeaderText="ItemID" ReadOnly="True" 
                SortExpression="ItemID" />
            <asp:BoundField DataField="VendorID" HeaderText="VendorID" ReadOnly="True" 
                SortExpression="VendorID" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="QuantityAvailable" HeaderText="QuantityAvailable" 
                SortExpression="QuantityAvailable" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="PhotoName" HeaderText="PhotoName" 
                SortExpression="PhotoName" />
            <asp:BoundField DataField="PhotoLocation" HeaderText="PhotoLocation" 
                SortExpression="PhotoLocation" />
            <asp:BoundField DataField="MinQuantity" HeaderText="MinQuantity" 
                SortExpression="MinQuantity" />
            <asp:BoundField DataField="CostPrice" HeaderText="CostPrice" 
                SortExpression="CostPrice" />
            <asp:BoundField DataField="RecommendedPrice" HeaderText="RecommendedPrice" 
                SortExpression="RecommendedPrice" />
            <asp:BoundField DataField="UPC" HeaderText="UPC" SortExpression="UPC" />
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                SortExpression="ProductName" />
            <asp:BoundField DataField="ProductCode" HeaderText="ProductCode" 
                SortExpression="ProductCode" />
            <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
        </Columns>
    </asp:GridView>
<asp:SqlDataSource ID="AdminProducts" runat="server" 
    ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>" 
    SelectCommand="SELECT * FROM [Items]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

