using System;
using DataAccessModule;
using DataImporter;

public partial class Import : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdImport_Click(object sender, EventArgs e)
    {
        var connection = new SQLServerConnect();
        //for live db
        //connection.SetupConnectionString("Server=MyPetsFW.db.3554730.hostedresource.com;USER ID=MyPetsFW;Password=DevryWeb460;Database=MyPetsFW;Trusted_Connection=False;");

        //for my local db
        //connection.SetupConnectionString("JON/Chris", "", @"Jon\SQLEXPRESS", "MyPetsFW");

        connection.SetupConnectionString("TestUser", "testuser", @"Jon\SQLEXPRESS", "MyPetsFW");

        var reader = new Reader
        {
            VendorID = 1,
            LogFile = @"C:\WEB460\DataImport\Output\Import09.log",
            DebugLevel = 3
        };

        const string fileName = @"C:\WEB460\DataImport\20090310-Products.txt";

        //string output = !reader.DoImport(fileName, connection) ?
        //            "There was an problem with the import." :
        //            "Import Successful.";
        //Console.WriteLine(output);

        lblError.Text = !reader.DoImport(fileName, connection) ? "There was an problem with the import" : "Import Successful";
    }
}
