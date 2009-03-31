#if TESTDRIVER

using System;
using TesterBC;

namespace DataAccessModule
{
    using NUnit.Framework;

    [TestFixture]
    public class NUnitVendor : TesterBaseClass
    {
        [Test]
        public void GetVendList()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("Create Table Vendor (ID int, Name char(10))", null);
                connection.ReturnSQLDataReader("Insert into Vendor (ID, Name) Values (1, 'Vendor1')", null);
                connection.ReturnSQLDataReader("Insert into Vendor (ID, Name) Values (2, 'Vendor2')", null);
                connection.ReturnSQLDataReader("Insert into Vendor (ID, Name) Values (3, 'Vendor3')", null);

                var reader = new VendorDA();
                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var vendorList = reader.Execute();

                Assert.AreEqual(3, vendorList.Count);

                Assert.AreEqual(1, vendorList[0].VendorID);
                Assert.AreEqual("Vendor1", vendorList[0].VendorName);
                Assert.AreEqual(2, vendorList[1].VendorID);
                Assert.AreEqual("Vendor2", vendorList[1].VendorName);
                Assert.AreEqual(3, vendorList[2].VendorID);
                Assert.AreEqual("Vendor3", vendorList[2].VendorName);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Vendor", null);
            }
        }
    }
}

#endif