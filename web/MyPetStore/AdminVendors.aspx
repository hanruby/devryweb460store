<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminVendors.aspx.cs" Inherits="AdminVendors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPH" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 74px;
        }
        .style2
        {
            width: 77px;
        }
    </style>
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
    
    <table cellpadding="2" cellspacing="2" width="600" >
        <tr>
            <td class="style1"><asp:CheckBox ID="cboxIsActive" runat="server" Text="Active" /></td>
            <td></td><td class="style2"></td><td></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblVendorID" runat="server" Text="Vendor ID "></asp:Label></td>
            <td><asp:TextBox ID="txtVendorID" runat="server" ></asp:TextBox></td>
            <td align="right" class="style2"><asp:Label ID="lblVendorName" runat="server" Text="Vendor Name "></asp:Label></td>
            <td><asp:TextBox ID="txtVendorName" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblMainPhone" runat="server" Text="Main Phone "></asp:Label></td>
            <td><asp:TextBox ID="txtMainPhone" runat="server" ></asp:TextBox></td>
            <td align="right" class="style2"><asp:Label ID="lblWebsite" runat="server" Text="Website "></asp:Label></td>
            <td><asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblAddress" runat="server" Text="Address "></asp:Label></td>
            <td colspan="3" ><asp:TextBox ID="txtAddress" runat="server" Width="518px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblAddress2" runat="server" Text="Address 2"></asp:Label></td>
            <td colspan="3" ><asp:TextBox ID="txtAddress2" runat="server" Width="518px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblCity" runat="server" Text="City "></asp:Label></td>
            <td colspan="3" ><asp:TextBox ID="txtCity" runat="server" Width="518px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblState" runat="server" Text="State "></asp:Label></td>
            <td><asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
            <td class="style2"><asp:Label ID="lblZip" runat="server" Text="Zip "></asp:Label></td>
            <td><asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label ID="lblCountry" runat="server" Text="Country "></asp:Label></td>
            <td colspan="3" ><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    
    <br />
     
    <table cellpadding="2" cellspacing="2" width="600" >
    <tr><td colspan="2"></td></tr>
        <tr>
            <td><asp:Label ID="lblContactName" runat="server" Text="Contact Name "></asp:Label></td>
            <td><asp:TextBox ID="txtContactName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblContactEmail" runat="server" Text="Contact Email "></asp:Label></td>
            <td><asp:TextBox ID="txtContactEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblContactPhone" runat="server" Text="Contact Phone "></asp:Label></td>
            <td><asp:TextBox ID="txtContactPhone" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" /> &nbsp
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" /> &nbsp
    <asp:Button ID="btnAdd" runat="server" Text="Add New" onclick="btnAdd_Click" /> &nbsp
    <asp:Button ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click" /> &nbsp
    <asp:Button ID="btnClear" runat="server" Text="ClearForm" 
        onclick="btnClear_Click" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

