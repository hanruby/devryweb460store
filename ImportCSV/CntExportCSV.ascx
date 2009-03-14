<%@ Control Language="c#" Inherits="ExportCSV.CntExportCSV" CodeFile="CntExportCSV.ascx.cs" %>
<TABLE id="Table1" style="WIDTH: 280px; HEIGHT: 160px" cellSpacing="0" cellPadding="0"
	width="280" align="left" bgColor="#cc9966" border="0">
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px"><asp:dropdownlist id="ddlDB" runat="server">
				<asp:ListItem Value="SQL" Selected="True">MS-SQL</asp:ListItem>
				<asp:ListItem Value="MSA">MS-Access</asp:ListItem>
			</asp:dropdownlist>&nbsp;to CSV/TXT File</TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px">Table 
			from where data will be fetched</TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px"><asp:textbox id="txtTableName" runat="server" Width="272px">TempTable</asp:textbox></TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px">CSV 
			File Name to be saved as on web server</TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px"><asp:textbox id="txtCSVFileName" runat="server" Width="272px">ExportedCSV</asp:textbox></TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px">Save 
			CSV file to folder on web server</TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px"><asp:textbox id="txtCSVDir" runat="server" Width="272px">Files/CSVFiles</asp:textbox></TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px"
			align="right"><asp:button id="Submit" runat="server" Text="Export" onclick="Submit_Click"></asp:button></TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px"
			align="left"><asp:label id="importstatus" runat="server" Font-Size="XX-Small" Font-Names="Arial" Font-Bold="True"
				ForeColor="Red"></asp:label></TD>
	</TR>
</TABLE>
