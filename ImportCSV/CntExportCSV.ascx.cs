namespace ExportCSV
{
	//This is just a sample application.
	//For any details contact ajay at aas2314@yahoo.com
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;	
	using System.Data.SqlClient;
	using System.Collections.Specialized;
	using System.Configuration;
	using System.IO;
	using ExportCSV.Classes;
	
	/// <summary>
	///		Summary description for CntExportCSV.
	/// </summary>
	public partial  class CntExportCSV : System.Web.UI.UserControl
	{
		#region Controls
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}		
		private void InitializeComponent()
		{

		}
		#endregion
		
		#region Private Methods
		protected void Submit_Click(object sender, System.EventArgs e)
		{
			try
			{				
				SetProperties sp = new SetProperties();
				sp.ExportTableName = txtTableName.Text;
				sp.ExportCSVasName = txtCSVFileName.Text;
				sp.ExportCSVDirOnServer = txtCSVDir.Text;
				sp.ExportAsCsvOrText = "T"; //"C" for CSV or "T" for Text
				switch(ddlDB.SelectedItem.Value)
				{
					case "SQL":
						ClsSQLCSV objSQL = new ClsSQLCSV();
						importstatus.Text	=	objSQL.GenerateCSVFile(sp);
						break;
					case "MSA":
						ClsMSACSV objMSA = new ClsMSACSV();
						importstatus.Text	=	objMSA.GenerateCSVFile(sp);
						break;
				}
			}
			catch(Exception ex)
			{
				importstatus.Text =	ex.Message.ToString() + "<br>";
				importstatus.Text += "Error exporting. Please try again";
			}
		}	
		#endregion
	}
}