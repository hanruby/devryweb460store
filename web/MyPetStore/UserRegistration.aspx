<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

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
    <div id="userRegistrationForm" >
        <!--Richard Crouch - User registration form-->
        <asp:CreateUserWizard ID="userRegistrationWizard" runat="server" 
            OnContinueButtonClick="UserRegistrationWizard_ContinueButtonClick">
        </asp:CreateUserWizard>
    </div>
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>
