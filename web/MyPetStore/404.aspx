<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" Title="Error {404}" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navMenuPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent2" Runat="Server">

<div id="error">
        <h1>
            Oops!....<br />
            Page or File Not Found
        </h1>
        <br />
        <p>
            Someone is to blame for this! Rest assured, the proper person will be dealt with.<br />
            If you have any choice words to pass along, please <a href="contact.aspx">Contact Us</a>.
        </p>
        <br />
        <h3>
            <a href="Default.aspx">Return Home</a>
        </h3>
    </div>

</asp:Content>

