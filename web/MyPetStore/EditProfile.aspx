<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" Title="Untitled Page" %>

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
<asp:Content ID="Content6" ContentPlaceHolderID="rightColumnPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="mainContentPH" Runat="Server">
<p>Editing your profile . . .</p>
    <br />
    <table border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="right">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Font-Bold="true"></asp:Label>         
            </td>
            <td>   
                <asp:TextBox ID="txtLastName" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAddress" runat="server" Text="Address:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAddress2" runat="server" Text="Address2:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCity" runat="server" Text="City:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblState" runat="server" Text="State:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:DropDownList ID="cboState" runat="server">
                    <asp:ListItem>AK</asp:ListItem>
                    <asp:ListItem>AL</asp:ListItem>
                    <asp:ListItem>AR</asp:ListItem> 
                    <asp:ListItem>AZ</asp:ListItem> 
                    <asp:ListItem>CA</asp:ListItem> 
                    <asp:ListItem>CO</asp:ListItem> 
                    <asp:ListItem>CT</asp:ListItem> 
                    <asp:ListItem>DC</asp:ListItem>               
                    <asp:ListItem>DE</asp:ListItem> 
                    <asp:ListItem>FL</asp:ListItem> 
                    <asp:ListItem>GA</asp:ListItem> 
                    <asp:ListItem>HI</asp:ListItem> 
                    <asp:ListItem>IA</asp:ListItem> 
                    <asp:ListItem>ID</asp:ListItem> 
                    <asp:ListItem>IL</asp:ListItem> 
                    <asp:ListItem>IN</asp:ListItem> 
                    <asp:ListItem>KS</asp:ListItem>
                    <asp:ListItem>KY</asp:ListItem>               
                    <asp:ListItem>LA</asp:ListItem> 
                    <asp:ListItem>MA</asp:ListItem> 
                    <asp:ListItem>MD</asp:ListItem> 
                    <asp:ListItem>ME</asp:ListItem> 
                    <asp:ListItem>MI</asp:ListItem> 
                    <asp:ListItem>MN</asp:ListItem> 
                    <asp:ListItem>MO</asp:ListItem> 
                    <asp:ListItem>MS</asp:ListItem> 
                    <asp:ListItem>MT</asp:ListItem> 
                    <asp:ListItem>NC</asp:ListItem>               
                    <asp:ListItem>ND</asp:ListItem>
                    <asp:ListItem>NE</asp:ListItem> 
                    <asp:ListItem>NH</asp:ListItem> 
                    <asp:ListItem>NJ</asp:ListItem> 
                    <asp:ListItem>NM</asp:ListItem> 
                    <asp:ListItem>NV</asp:ListItem> 
                    <asp:ListItem>NY</asp:ListItem> 
                    <asp:ListItem>OH</asp:ListItem> 
                    <asp:ListItem>OK</asp:ListItem> 
                    <asp:ListItem>OR</asp:ListItem>               
                    <asp:ListItem>PA</asp:ListItem> 
                    <asp:ListItem>RI</asp:ListItem> 
                    <asp:ListItem>SC</asp:ListItem> 
                    <asp:ListItem>SD</asp:ListItem> 
                    <asp:ListItem>TN</asp:ListItem> 
                    <asp:ListItem>TX</asp:ListItem> 
                    <asp:ListItem>UT</asp:ListItem> 
                    <asp:ListItem>VA</asp:ListItem> 
                    <asp:ListItem>VT</asp:ListItem> 
                    <asp:ListItem>WA</asp:ListItem> 
                    <asp:ListItem>WI</asp:ListItem> 
                    <asp:ListItem>WV</asp:ListItem>
                    <asp:ListItem>WY</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblZip" runat="server" Text="Zip:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtZip" runat="server" Columns="5" MaxLength="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCountry" runat="server" Text="Country:" Font-Bold="true"></asp:Label>         
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
                <asp:Label ID="lblEmail" runat="server" Text="E-mail:" Font-Bold="true"></asp:Label>         
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal ID="ErrorText" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSubmitChanges" runat="server" Text="Submit Changes" 
                    onclick="btnSubmitChanges_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

