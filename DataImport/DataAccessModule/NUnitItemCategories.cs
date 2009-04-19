#if TESTDRIVER

using System;
using TesterBC;

namespace DataAccessModule
{
    using NUnit.Framework;

    [TestFixture]
    public class NUnitItemCategories : TesterBaseClass
    {
        [Test]
        public void GetVendorList()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[ItemCategories]([ItemID],[VendorID],[CategoryID])VALUES('Testing 1', 1, 1)", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[ItemCategories]([ItemID],[VendorID],[CategoryID])VALUES('Testing 2', 2, 2)", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[ItemCategories]([ItemID],[VendorID],[CategoryID])VALUES('Testing 3', 3, 3)", null);

                var reader = new ItemCategoriesDA
                {
                    GetAll = true
                };
                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var vendorList = reader.Execute();

                Assert.AreEqual(3, vendorList.Count);

                Assert.AreEqual(1, vendorList[0].CategoryID);
                Assert.AreEqual("Testing 1", vendorList[0].ItemID);
                Assert.AreEqual(2, vendorList[1].CategoryID);
                Assert.AreEqual("Testing 2", vendorList[1].ItemID);
                Assert.AreEqual(3, vendorList[2].CategoryID);
                Assert.AreEqual("Testing 3", vendorList[2].ItemID);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
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
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);

                var item = new ItemCategories
                {
                    ItemID = "Item 1",
                    VendorID = 1,
                    CategoryID = 1
                };

                var reader = new ItemCategoriesDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);

                var list = reader.Execute();
                Assert.AreEqual(0, list.Count);

                reader = new ItemCategoriesDA
                {
                    GetAll = true
                };
                reader.SetupConnectionString(connStr);
                list = reader.Execute();
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual("Item 1", list[0].ItemID);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
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
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);

                var item = new ItemCategories
                {
                    ItemID = "Item 1",
                    VendorID = 1,
                    CategoryID = 1
                };

                var reader = new ItemCategoriesDA
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

                item = new ItemCategories
                {
                    ItemID = "Item 2",
                    VendorID = 1,
                    CategoryID = 1
                };
                reader = new ItemCategoriesDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                reader.SetupConnectionString(connStr);
                reader.Execute();

                reader = new ItemCategoriesDA
                {
                    GetAll = true
                };
                reader.SetupConnectionString(connStr);
                vendorList = reader.Execute();
                Assert.AreEqual(2, vendorList.Count);
                Assert.AreEqual("Item 1", vendorList[0].ItemID);
                Assert.AreEqual("Item 2", vendorList[1].ItemID);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
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
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[ItemCategories]([ItemID],[VendorID],[CategoryID])VALUES('Testing 1', 1, 1)", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[ItemCategories]([ItemID],[VendorID],[CategoryID])VALUES('Testing 2', 2, 2)", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[ItemCategories]([ItemID],[VendorID],[CategoryID])VALUES('Testing 3', 3, 3)", null);

                var item = new ItemCategories
                {
                    ItemID = "Testing 2",
                };

                var reader = new ItemCategoriesDA
                {
                    WorkingItem = item
                };
                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var vendorList = reader.Execute();

                Assert.AreEqual(1, vendorList.Count);

                Assert.AreEqual(2, vendorList[0].CategoryID);
                Assert.AreEqual("Testing 2", vendorList[0].ItemID);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
            }
        }
    }
}

#endif