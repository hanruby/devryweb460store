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
        public void GetVendorList()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Vendor]( [VendorID] [int] NOT NULL, [IsActive] [bit] NOT NULL CONSTRAINT [DF_Vendor_IsActive]  DEFAULT ((1)), [VendorName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [MainPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Website] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Address2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [City] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [State] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Zip] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Country] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED ( [VendorID] ASC )WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Vendor] ([VendorID], [VendorName], [MainPhone], [ContactName], [ContactEmail], [ContactPhone],[Website],[Address],[Address2],[City],[State],[Zip],[Country])VALUES(1, 'Vendor 1', '(xx) xxx-xxxx', 'Contact 1', 'Contact Email', '(ZZZ) ZZZ-ZZZZ', 'Website', 'Address', 'Address2', 'City', 'AZ', 'XXXX-XXXX', 'Country')", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Vendor] ([VendorID], [VendorName], [MainPhone], [ContactName], [ContactEmail], [ContactPhone],[Website],[Address],[Address2],[City],[State],[Zip],[Country])VALUES(2, 'Vendor 2', '(xx) xxx-xxxx', 'Contact 2', 'Contact Email', '(ZZZ) ZZZ-ZZZZ', 'Website', 'Address', 'Address2', 'City', 'AZ', 'XXXX-XXXX', 'Country')", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Vendor] ([VendorID], [VendorName], [MainPhone], [ContactName], [ContactEmail], [ContactPhone],[Website],[Address],[Address2],[City],[State],[Zip],[Country])VALUES(3, 'Vendor 3', '(xx) xxx-xxxx', 'Contact 3', 'Contact Email', '(ZZZ) ZZZ-ZZZZ', 'Website', 'Address', 'Address2', 'City', 'AZ', 'XXXX-XXXX', 'Country')", null);

                var reader = new VendorDA
                {
                    GetAll = true
                };
                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var vendorList = reader.Execute();

                Assert.AreEqual(3, vendorList.Count);

                Assert.AreEqual(1, vendorList[0].VendorID);
                Assert.AreEqual("Vendor 1", vendorList[0].VendorName);
                Assert.AreEqual(2, vendorList[1].VendorID);
                Assert.AreEqual("Vendor 2", vendorList[1].VendorName);
                Assert.AreEqual(3, vendorList[2].VendorID);
                Assert.AreEqual("Vendor 3", vendorList[2].VendorName);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Vendor", null);
            }
        }

        [Test]
        public void InsertVendor()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Vendor]( [VendorID] [int] NOT NULL, [IsActive] [bit] NOT NULL CONSTRAINT [DF_Vendor_IsActive]  DEFAULT ((1)), [VendorName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [MainPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Website] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Address2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [City] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [State] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Zip] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Country] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED ( [VendorID] ASC )WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ) ON [PRIMARY]",
                                                        null);

                var item = new Vendor
                {
                    VendorID = 1,
                    VendorName = "Vendor 1",
                    IsActive = true,
                    MainPhone = "XXX.XXX.XXXX",
                    ContactName = "Testing",
                    ContactEmail = "PCode",
                    ContactPhone = "Desc",
                    Website = "Name",
                    Address = "Size",
                    Address2 = "Section",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country"
                };

                var reader = new VendorDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);

                var vendorList = reader.Execute();
                Assert.AreEqual(0, vendorList.Count);

                reader = new VendorDA
                {
                    GetAll = true
                };
                reader.SetupConnectionString(connStr);
                vendorList = reader.Execute();
                Assert.AreEqual(1, vendorList.Count);
                Assert.AreEqual("Vendor 1", vendorList[0].VendorName);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Vendor", null);
            }
        }

        [Test]
        public void UpdateVendor()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Vendor]( [VendorID] [int] NOT NULL, [IsActive] [bit] NOT NULL CONSTRAINT [DF_Vendor_IsActive]  DEFAULT ((1)), [VendorName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [MainPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Website] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Address2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [City] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [State] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Zip] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Country] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED ( [VendorID] ASC )WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ) ON [PRIMARY]",
                                                        null);


                var item = new Vendor
                {
                    VendorID = 1,
                    VendorName = "Vendor 1",
                    IsActive = true,
                    MainPhone = "XXX.XXX.XXXX",
                    ContactName = "Testing",
                    ContactEmail = "PCode",
                    ContactPhone = "Desc",
                    Website = "Name",
                    Address = "Size",
                    Address2 = "Section",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country"
                };

                var reader = new VendorDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);

                var vendorList = reader.Execute();
                Assert.AreEqual(0, vendorList.Count);

                item = new Vendor
                {
                    VendorID = 1,
                    VendorName = "Vendor 1",
                    IsActive = true,
                    MainPhone = "New Phone",
                    ContactName = "Testing",
                    ContactEmail = "PCode",
                    ContactPhone = "Desc",
                    Website = "Name",
                    Address = "Size",
                    Address2 = "Section",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country"
                };
                reader = new VendorDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                reader.SetupConnectionString(connStr);
                reader.Execute();

                reader = new VendorDA
                {
                    GetAll = true
                };
                reader.SetupConnectionString(connStr);
                vendorList = reader.Execute();
                Assert.AreEqual(1, vendorList.Count);
                Assert.AreEqual("New Phone", vendorList[0].MainPhone);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Vendor", null);
            }
        }

        [Test]
        public void QueryVendor()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Vendor]( [VendorID] [int] NOT NULL, [IsActive] [bit] NOT NULL CONSTRAINT [DF_Vendor_IsActive]  DEFAULT ((1)), [VendorName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [MainPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [ContactPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Website] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Address2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [City] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [State] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, [Zip] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Country] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED ( [VendorID] ASC )WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Vendor] ([VendorID], [VendorName], [MainPhone], [ContactName], [ContactEmail], [ContactPhone],[Website],[Address],[Address2],[City],[State],[Zip],[Country])VALUES(1, 'Vendor 1', '(xx) xxx-xxxx', 'Contact 1', 'Contact Email', '(ZZZ) ZZZ-ZZZZ', 'Website', 'Address', 'Address2', 'City', 'AZ', 'XXXX-XXXX', 'Country')", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Vendor] ([VendorID], [VendorName], [MainPhone], [ContactName], [ContactEmail], [ContactPhone],[Website],[Address],[Address2],[City],[State],[Zip],[Country])VALUES(2, 'Vendor 2', '(xx) xxx-xxxx', 'Contact 2', 'Contact Email', '(ZZZ) ZZZ-ZZZZ', 'Website', 'Address', 'Address2', 'City', 'AZ', 'XXXX-XXXX', 'Country')", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Vendor] ([VendorID], [VendorName], [MainPhone], [ContactName], [ContactEmail], [ContactPhone],[Website],[Address],[Address2],[City],[State],[Zip],[Country])VALUES(3, 'Vendor 3', '(xx) xxx-xxxx', 'Contact 3', 'Contact Email', '(ZZZ) ZZZ-ZZZZ', 'Website', 'Address', 'Address2', 'City', 'AZ', 'XXXX-XXXX', 'Country')", null);

                var item = new Vendor
                {
                    VendorName = "Vendor 2",
                };

                var reader = new VendorDA
                {
                    WorkingItem = item
                };
                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var vendorList = reader.Execute();

                Assert.AreEqual(1, vendorList.Count);

                Assert.AreEqual(2, vendorList[0].VendorID);
                Assert.AreEqual("Vendor 2", vendorList[0].VendorName);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Vendor", null);
            }
        }
    }
}

#endif