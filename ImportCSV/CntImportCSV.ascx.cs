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
	///		Summary description for CntImportCSV.
	/// </summary>
	public partial  class CntImportCSV : System.Web.UI.UserControl
	{
		#region Controls
		protected System.Web.UI.WebControls.Button Cancel;
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
		protected void Page_Load(object sender, System.EventArgs e)
		{		
		}

		protected void Submit_Click(object sender, System.EventArgs e)
		{
			try
			{
				FileInfo FICSV = new FileInfo(OFDSelectFile.PostedFile.FileName);
				SetProperties sp = new SetProperties();
			
				if (IsValidFile(FICSV))
				{
					sp.TableName = txtTableName.Text;
					sp.CsvDirOnServer = txtCSVDir.Text;
					sp.DropExistingTable=true;
					sp.SaveFileOnServer=true;
					sp.FileInformation = FICSV;

					switch(ddlDB.SelectedItem.Value)
					{
						case "SQL":	
							ClsSQLCSV objSQL = new ClsSQLCSV();
							importstatus.Text = objSQL.GenerateTable(sp);
							break;
						case "MSA":
							ClsMSACSV objMSA = new ClsMSACSV();
							importstatus.Text = objMSA.GenerateTable(sp);
							break;
					}
				}
			}
			catch(Exception ex)
			{
				importstatus.Text =	ex.Message.ToString() + "<br>";
				importstatus.Text += "Error importing. Please try again";
			}
		}

		private bool IsValidFile(FileInfo FICSV)
		{
			if(FICSV.FullName.Length <=	0)
			{
				importstatus.Text = "No File Selected!";
				return false;
			}

			if(FICSV.Name.Substring(FICSV.Name.Length-3,3)!="csv" && FICSV.Name.Substring(FICSV.Name.Length-3,3)!="txt")
			{
				importstatus.Text = "InValid File Selection!";
				return false;
			}
			
			return true;
		}
		
		#endregion
	}
}