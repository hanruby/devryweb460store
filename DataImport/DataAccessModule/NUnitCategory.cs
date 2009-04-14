#if TESTDRIVER

using System;
using TesterBC;

namespace DataAccessModule
{
    using NUnit.Framework;

    [TestFixture]
    public class NUnitCategory : TesterBaseClass
    {
        [Test]
        public void GetCategoryList()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Categories]([CategoryID],[CategoryName],[CategoryPhoto])VALUES(1, 'Testing 1', 'Picture 1')", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Categories]([CategoryID],[CategoryName],[CategoryPhoto])VALUES(2, 'Testing 2', 'Picture 2')", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Categories]([CategoryID],[CategoryName],[CategoryPhoto])VALUES(3, 'Testing 3', 'Picture 3')", null);

                var reader = new CategoryDA
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
                Assert.AreEqual("Testing 1", vendorList[0].Name);
                Assert.AreEqual(2, vendorList[1].CategoryID);
                Assert.AreEqual("Testing 2", vendorList[1].Name);
                Assert.AreEqual(3, vendorList[2].CategoryID);
                Assert.AreEqual("Testing 3", vendorList[2].Name);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Categories", null);
            }
        }

        [Test]
        public void InsertCategory()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);

                var item = new Category
                {
                    Name = "Category 1",
                    Picture = "Picture 1"
                };

                var reader = new CategoryDA
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

                reader = new CategoryDA
                {
                    GetAll = true
                };
                reader.SetupConnectionString(connStr);
                list = reader.Execute();
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual("Category 1", list[0].Name);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Categories", null);
            }
        }

        [Test]
        public void UpdateCategory()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);


                var item = new Category
                {
                    Name = "Category 1",
                    Picture = "Picture 1"
                };

                var reader = new CategoryDA
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

                var item2 = new Category
                {
                    CategoryID = 1,
                    Name = "Category 1",
                    Picture = "Picture 2"
                };
                reader = new CategoryDA
                {
                    WorkingItem = item2,
                    InsertUpdateData = true
                };
                reader.SetupConnectionString(connStr);
                reader.Execute();

                reader = new CategoryDA
                {
                    GetAll = true
                };
                reader.SetupConnectionString(connStr);
                vendorList = reader.Execute();
                Assert.AreEqual(1, vendorList.Count);
                Assert.AreEqual("Picture 2", vendorList[0].Picture);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Categories", null);
            }
        }

        [Test]
        public void QueryCategory()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Categories]([CategoryID],[CategoryName],[CategoryPhoto])VALUES(1, 'Testing 1', 'Picture 1')", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Categories]([CategoryID],[CategoryName],[CategoryPhoto])VALUES(2, 'Testing 2', 'Picture 2')", null);
                connection.ReturnSQLDataReader("INSERT INTO [dbo].[Categories]([CategoryID],[CategoryName],[CategoryPhoto])VALUES(3, 'Testing 3', 'Picture 3')", null);

                var item = new Category
                {
                    Name = "Testing 2",
                };

                var reader = new CategoryDA
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
                Assert.AreEqual("Testing 2", vendorList[0].Name);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Categories", null);
            }
        }

        [Test]
        public void InsertTwoCategories()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);

                var item = new Category
                {
                    Name = "Category 1",
                    Picture = "Picture 1"
                };

                var reader = new CategoryDA
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

                item = new Category
                {
                    Name = "Category 2",
                    Picture = "Picture 2"
                };

                reader = new CategoryDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                reader.SetupConnectionString(connStr);
                reader.Execute();

                reader = new CategoryDA
                {
                    GetAll = true
                };
                reader.SetupConnectionString(connStr);
                list = reader.Execute();
                Assert.AreEqual(2, list.Count);
                Assert.AreEqual("Category 1", list[0].Name);
                Assert.AreEqual("Category 2", list[1].Name);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Categories", null);
            }
        }
    }
}

#endif