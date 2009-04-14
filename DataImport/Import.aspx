<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import.aspx.cs" Inherits="Import" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import only</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <br />
        <asp:Button ID="cmdImport" runat="server" Text="Import" onclick="cmdImport_Click" /><br />
        <asp:Label ID="lblError" runat="server" />
    </div>
    </form>
</body>
</html>
