<%@ Control Language="c#" Inherits="ExportCSV.CntImportCSV" CodeFile="CntImportCSV.ascx.cs" %>
<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="280" align="left" border="0"
	style="HEIGHT: 178px" bgColor="#ff9966">
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial; HEIGHT: 18px"
			align="left">&nbsp;CSV/TXT to&nbsp;
			<asp:DropDownList id="ddlDB" runat="server">
				<asp:ListItem Value="SQL" Selected="True">MS-SQL</asp:ListItem>
				<asp:ListItem Value="MSA">MS-Access</asp:ListItem>
			</asp:DropDownList>
			Table</TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial"
			align="left">&nbsp;Select&nbsp;File : Comma Seperated .CSV/.TXT file
		</TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; WIDTH: 171px; COLOR: aliceblue; FONT-FAMILY: Arial"
			align="left" width="171"><INPUT id="OFDSelectFile" type="file" size="26" name="filMyFile" runat="server"></TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial"
			align="left">Table Name to Store in Database</TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: aliceblue; FONT-FAMILY: Arial"
			align="left" width="81">
			<asp:TextBox id="txtTableName" runat="server" Width="272px">TempTable</asp:TextBox></TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: aliceblue; FONT-FAMILY: Arial"
			align="left">Save .csv/.txt file to your web server folder</TD>
	</TR>
	<TR>
		<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: aliceblue; FONT-FAMILY: Arial"
			align="left" width="81">
			<asp:TextBox id="txtCSVDir" runat="server" Width="272px">Import/Table</asp:TextBox></TD>
	</TR>
	<TR>
		<TD align="right">
			<asp:button id="Submit" runat="server" Text="Import" onclick="Submit_Click"></asp:button>&nbsp;&nbsp;</TD>
	</TR>
	<TR>
		<TD align="left">
			<asp:label id="importstatus" runat="server" Font-Size="XX-Small" Font-Names="Arial" Font-Bold="True"
				ForeColor="Red"></asp:label></TD>
	</TR>
</TABLE>
