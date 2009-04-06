<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavMenu.ascx.cs" Inherits="Controls_NavMenu" %>

<div id="tabs">
    <ul>
        <li><a href="#tabs-1">Dog</a></li>
		<li><a href="#tabs-2">Cat</a></li>
		<li><a href="#tabs-3">Aquarium</a></li>
		<li><a href="#tabs-4">Bird</a></li>
		<li><a href="#tabs-5">Small Animal</a></li>
		<li><a href="#tabs-6">LINKS *WEB460 use only*</a></li>
	</ul>
	            
	<div id="tabs-1">
        <ul>
            <li><a href="#">Books-by Breed</a></li>
            <li><a href="#">Collars</a></li>
            <li><a href="#">Displays</a></li>
            <li><a href="#">Treats</a></li>
            <li><a href="#">Flea & Tick Products</a></li>
            <li><a href="#">Harnesses</a></li>
            <li><a href="#">Toys-fleece & Plush</a></li>
        </ul>
	</div>
	
	<div id="tabs-2">
        <ul>
            <li><a href="#">Flea & Tick Products</a></li>
            <li><a href="#">Scratching Posts</a></li>
            <li><a href="#">Toys-danglers & Wands</a></li>
            <li><a href="#">Treats</a></li>
        </ul>
	</div>
	
	<div id="tabs-3">
	    <ul>
            <li><a href="#">Books-marine</a></li>
            <li><a href="#">Hi-tech Marine Equipment</a></li>
            <li><a href="#">Resin Ornaments</a></li>
        </ul>
	</div>
	
	<div id="tabs-4">
	    <ul>
            <li><a href="#">Baby Formula & Related</a></li>
            <li><a href="#">Cages-keet/canary/finch</a></li>
            <li><a href="#">Toys-plastic & Acrylic</a></li>
            <li><a href="#">Toys-wood</a></li>
            <li><a href="#">Vitamins & Supplements</a></li>
        </ul>
	</div>
	
	<div id="tabs-5">
	    <ul>
            <li><a href="#">Cages</a></li>
            <li><a href="#">Habitats</a></li>
            <li><a href="#">Reptile Bedding</a></li>
            <li><a href="#">Treats</a></li>
        </ul>
	</div>
	
	<div id="tabs-6">
	    <ul>
            <li><a href="~/Default.aspx" runat="server">Home</a></li>
            <li><a href="~/contact.aspx" runat="server">Contact</a></li>
            <li><a href="~/dbtest.aspx" runat="server">DatabaseTest</a></li>
            <li><a href="~/ForgotPassword.aspx" runat="server">ForgotPassword</a></li>
            <li><a href="~/IPN.aspx" runat="server">IPN</a></li>
            <li><a href="~/Login.aspx" runat="server">Login</a></li>
            <li><a href="~/PasswordSuccess.aspx" runat="server">PasswordSuccess</a></li>
            <li><a href="~/ResetPassword.aspx" runat="server">ResetPassword</a></li>
            <li><a href="~/TwitterUpdate.aspx" runat="server">TwitterUpdate</a></li>
            <li><a href="~/UserRegistration.aspx" runat="server">UserRegistration</a></li>
            <li><a href="ViewCustomers.ascx" runat="server">View Customers</a></li>
            <li><a href="~/ViewOrder.aspx" runat="server">View Orders</a></li>
            <br />
            <li><a href="~/rss.xml" runat="server">RSS Feed</a></li>
        </ul>
	</div>
	
</div>