<%@ Page Language="C#" MasterPageFile="../Styles/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

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
    <!--Richard Crouch - User login form-->
    <asp:Login ID="UserLogin" runat="server" CreateUserText="Not a member? Click here." 
        CreateUserUrl="../Pages/UserRegistration.aspx">
    </asp:Login>
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>


