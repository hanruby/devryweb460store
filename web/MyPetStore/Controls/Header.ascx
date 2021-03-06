﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>

<div id="headerLogo">
    <!--Richard Crouch - This code displays the users login status and gives them the option of logging in and out-->
    <p><asp:LoginView ID="view" runat="server">
        <AnonymousTemplate>
            <asp:LoginStatus ID="loginStatus1" runat="server" /> | <a href="UserRegistration.aspx">Not a member? Click here!</a>
        </AnonymousTemplate>
        <LoggedInTemplate>
            Welcome, <asp:LoginName ID="loginName" runat="server" />! | <asp:LoginStatus ID="loginStatus1" runat="server" />
        </LoggedInTemplate> 
    </asp:LoginView>
    </p>
    <!-- <a href="#" class="popup">CLICK ME</a> -->
    <div class="myCart">
        <a id="A1" href="~/ViewProfile.aspx" runat="server">My Account</a> | 
        <a id="A2" href="~/ShoppingCart.aspx" runat="server">View Cart</a> (<asp:Label ID="lblItemsInCart" runat="server" Text=""></asp:Label>) | 
        <a id="A3" href="~/CheckOut.aspx?CheckOut=true" runat="server">Checkout</a>
    </div>
    <div class="search">
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>
    
    <img id="Img1" src="~/Images/headerLogo01.png" alt="" runat="server"/>
    <img id="Img2" class="headerText" src="~/Images/headerText.png" alt="" runat="server" />
</div>