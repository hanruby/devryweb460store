﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>

<div id="headerLogo">
    <!--Richard Crouch - This code displays the users login status and gives them the option of logging in and out-->
    <p><asp:LoginView ID="view" runat="server">
        <AnonymousTemplate>
            <asp:LoginStatus ID="loginStatus1" runat="server" /> | Not a member? <a href="UserRegistration.aspx">Click here!</a>
        </AnonymousTemplate>
        <LoggedInTemplate>
            Welcome, <asp:LoginName ID="loginName" runat="server" />! | <asp:LoginStatus ID="loginStatus1" runat="server" />
        </LoggedInTemplate> 
    </asp:LoginView>
    </p>
    <!-- <a href="#" class="popup">CLICK ME</a> -->
    <div class="myCart">
        <a href="ViewProfile.aspx">My Account</a> | 
        <a href="ShoppingCart.aspx">View Cart</a> (<asp:Label ID="lblItemsInCart" runat="server" Text=""></asp:Label>) | 
        <a href="#">Checkout</a>
    </div>
    <div class="search">
        SEARCH TOOL CAN GO HERE
    </div>
    
    <img src="~/Images/headerLogo01.png" alt="" runat="server"/>
    <img class="headerText" src="~/Images/headerText.png" alt="" runat="server" />
</div>