<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DALTutorial.aspx.cs" Inherits="TestDal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>

        <ItemTemplate>
                <div><b>Id:</b>  <%# DataBinder.Eval(Container.DataItem, "Id")%> 
                <div><b>Name:</b>  <%# DataBinder.Eval(Container.DataItem, "Name")%></div>
                <div><b>State:</b> <%# DataBinder.Eval(Container.DataItem, "ImageLocation")%></div>
                <br />
          </ItemTemplate>

          <FooterTemplate>
          </FooterTemplate>

    </asp:Repeater>
    
    <br /><br />
    
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    
    
    </form>
</body>
</html>
