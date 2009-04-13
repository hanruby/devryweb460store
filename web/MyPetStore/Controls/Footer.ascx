<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="Footer" %>


        <a href="~/Default.aspx" runat="server">Home</a> | 
        <%--<a href="#">About Us</a> |--%>
        <a href="~/rss.xml" runat="server">RSS Feed</a> |  
        <%--<a href="#">Testimonials</a> | 
        <a href="#">Privacy policy</a> | 
        <a href="#">FAQ</a> | 
        <a href="#">Terms of Sale</a> | --%>
        <a href="~/contact.aspx" runat="server">Contact Us</a>
        
        
        <br /><br />
        <div id="footerText">
            <script type="text/javascript" src="http://s3.chuug.com/chuug.twitthis.scripts/twitthis.js"></script>
            <script type="text/javascript">
                <!--
                document.write('<a href="javascript:;" onclick="TwitThis.pop();"><img src="http://s3.chuug.com/chuug.twitthis.resources/twitthis_grey_72x22.gif" alt="[TwitThis]" title="Twit this page" style="border:none;" /></a>');
                //-->
            </script>
            <a href="~/rss.xml" runat="server" target="_new"><img src="~/Images/valid-rss.png" alt="[Valid RSS]" title="Validated RSS feed" runat="server" /></a>
            <br /><br />
            <p>Copyright &copy 2009 MyPetsFW.com</p>
        </div>
