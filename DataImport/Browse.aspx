<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Browse and Import</title>
</head>
<body>
    <form id="myForm" runat="server">
        <asp:FileUpload ID="myFileUpload" runat="server" />
        <asp:Button ID="btnFileUpload" runat="server" Text="Upload File" onclick="btnFileUpload_Click" />
        <asp:Label ID="lblError" runat="server" />
    </form>
    <%--<form id="form1" runat="server">
    <div align="center">
        <br />
        <input id="txtFile" type="file" runat="server" /><br /><br />
        <asp:Button ID="cmdImport" runat="server" Text="Import" /><br />
        <asp:Label ID="lblError" runat="server" />
    </div>
    </form>--%>
</body>
</html>
