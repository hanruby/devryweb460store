<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="Pages_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--quick test, will use this to grab the connection string-->
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" 
            EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="TestId" HeaderText="TestId" ReadOnly="True" 
                    SortExpression="TestId" InsertVisible="False" />
                <asp:BoundField DataField="TestData" HeaderText="TestData" 
                    SortExpression="TestData" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ASPNETDBConnectionString1 %>" 
            ProviderName="<%$ ConnectionStrings:ASPNETDBConnectionString1.ProviderName %>" 
            SelectCommand="SELECT [TestId], [TestData] FROM [Test_Table]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
