using System;
using DataAccessModule;
using DataImporter;

public partial class Browse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnFileUpload_Click(object sender, EventArgs e)
    {
        //this does not work yet, meant to browse for the file to be Imported.
        var connection = new SQLServerConnect();
        connection.SetupConnectionString("TestUser", "testuser", @"Jon\SQLEXPRESS", "MyPetsFW");

        var reader = new Reader
        {
            VendorID = 1,
            LogFile = @"C:\WEB460\DataImport\Output\Import01.log",
            DebugLevel = 3
        };

        if (myFileUpload.HasFile)
        {
            myFileUpload.SaveAs(Server.MapPath("uploads/" + myFileUpload.FileName));
        }

        lblError.Text = !reader.DoImport(myFileUpload.ToString(), connection) ? "There was an problem with the import" : "Import Successful";
    }
}
