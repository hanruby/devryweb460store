<%@ Page language="c#" Inherits="ExportCSV.ImportExport" CodeFile="ImportExport.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="CntImportCSV" Src="CntImportCSV.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CntExportCSV" Src="CntExportCSV.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ImportExport SQL - CSV/TXT</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table id="Table4" style="z-index: 101; left: 4px; width: 187px; position: absolute;
        top: 2px; height: 16px" bordercolor="#000066" cellspacing="1" cellpadding="1"
        width="187" border="2">
        <tr>
            <td style="width: 50px" valign="top" bgcolor="#ff9966">
                <uc1:CntImportCSV ID="CntImportCSV1" runat="server"></uc1:CntImportCSV>
            </td>
            <td style="width: 50px" valign="top" bgcolor="#cc9966">
                <uc1:CntExportCSV ID="CntExportCSV1" runat="server"></uc1:CntExportCSV>
            </td>
        </tr>
    </table>
    &nbsp;
    </form>
</body>
</html>
