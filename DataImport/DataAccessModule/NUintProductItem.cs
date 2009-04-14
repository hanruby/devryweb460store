#if TESTDRIVER

using System;
using TesterBC;

namespace DataAccessModule
{
    using NUnit.Framework;

    [TestFixture]
    public class NUintProductItem : TesterBaseClass
    {
        [Test]
        public void TestProductItem()
        {
            var item = new ProductItem
                           {
                               Category = "ABC",
                               Cost = 5.54M,
                               VendorID = 10,
                               Picture = "Testing",
                               ProductCode = "PCode",
                               ProductDescription = "Desc",
                               ProductName = "Name",
                               ProductSize = "Size",
                               Section = "Section",
                               ShippingSurcharge = 3.43M,
                               UPC = "UPCData"
                           };

            Assert.AreEqual("ABC", item.Category);
            Assert.AreEqual(5.54, item.Cost);
            Assert.AreEqual(10, item.VendorID);
            Assert.AreEqual("Testing", item.Picture);
            Assert.AreEqual("PCode", item.ProductCode);
            Assert.AreEqual("Desc", item.ProductDescription);
            Assert.AreEqual("Name", item.ProductName);
            Assert.AreEqual("Size", item.ProductSize);
            Assert.AreEqual("Section", item.Section);
            Assert.AreEqual(3.43, item.ShippingSurcharge);
            Assert.AreEqual("UPCData", item.UPC);
        }

        [Test]
        public void TestProductItemInsert()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Items]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[IsActive] [bit] NULL,[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[QuantityAvailable] [int] NULL,[Price] [money] NULL,[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[MinQuantity] [int] NULL,[CostPrice] [money] NULL,[RecommendedPrice] [money] NULL,[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]", null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                var item = new ProductItem
                {
                    ItemID = "WERT",
                    Category = "ABC",
                    Subcategory = "DEF",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing",
                    ProductCode = "PCode",
                    ProductDescription = "Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData"
                };

                var productItemReader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                var connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                productItemReader.SetupConnectionString(connStr);
                productItemReader.Execute();

                productItemReader = new ProductItemDA
                {
                    GetAll = true
                };
                productItemReader.SetupConnectionString(connStr);
                var productItems = productItemReader.Execute();
                Assert.AreEqual(1, productItems.Count);

                var categoryReader = new CategoryDA
                {
                    GetAll = true
                };
                categoryReader.SetupConnectionString(connStr);
                var catItems = categoryReader.Execute();
                Assert.AreEqual(1, catItems.Count);

                var itemCategoryReader = new ItemCategoriesDA
                {
                    GetAll = true
                };
                itemCategoryReader.SetupConnectionString(connStr);
                var itemCatItems = itemCategoryReader.Execute();
                Assert.AreEqual(1, itemCatItems.Count);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Items", null);
                connection.ReturnSQLDataReader("Drop Table Categories", null);
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
            }
        }

        [Test]
        public void TestProductItemUpdate()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Items]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[IsActive] [bit] NULL,[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[QuantityAvailable] [int] NULL,[Price] [money] NULL,[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[MinQuantity] [int] NULL,[CostPrice] [money] NULL,[RecommendedPrice] [money] NULL,[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]", null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                var item = new ProductItem
                {
                    ItemID = "WERT",
                    Category = "ABC",
                    Subcategory ="DEF",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing",
                    ProductCode = "PCode",
                    ProductDescription = "Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData"
                };

                var reader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };

                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var items = reader.Execute();
                Assert.AreEqual(0, items.Count);

                item = new ProductItem
                {
                    ItemID = "WERT",
                    Category = "ABC",
                    Subcategory = "DEF",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing",
                    ProductCode = "PCode",
                    ProductDescription = "New Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData"
                };
                reader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };

                reader.SetupConnectionString(connStr);
                reader.Execute();

                var productItemReader = new ProductItemDA
                {
                    GetAll = true
                };
                productItemReader.SetupConnectionString(connStr);
                var productItems = productItemReader.Execute();
                Assert.AreEqual(1, productItems.Count);

                var categoryReader = new CategoryDA
                {
                    GetAll = true
                };
                categoryReader.SetupConnectionString(connStr);
                var catItems = categoryReader.Execute();
                Assert.AreEqual(1, catItems.Count);

                var itemCategoryReader = new ItemCategoriesDA
                {
                    GetAll = true
                };
                itemCategoryReader.SetupConnectionString(connStr);
                var itemCatItems = itemCategoryReader.Execute();
                Assert.AreEqual(1, itemCatItems.Count);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Items", null);
                connection.ReturnSQLDataReader("Drop Table Categories", null);
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
            }
        }

        [Test]
        public void TestProductItemUpdate2()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Items]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[IsActive] [bit] NULL,[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[QuantityAvailable] [int] NULL,[Price] [money] NULL,[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[MinQuantity] [int] NULL,[CostPrice] [money] NULL,[RecommendedPrice] [money] NULL,[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]", null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                var item = new ProductItem
                {
                    ItemID = "WERT",
                    Category = "ABC",
                    Subcategory = "DEF",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing",
                    ProductCode = "PCode",
                    ProductDescription = "Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData"
                };

                var reader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };

                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var items = reader.Execute();
                Assert.AreEqual(0, items.Count);

                item = new ProductItem
                {
                    ItemID = "KJHG",
                    Category = "ABC",
                    Subcategory = "DEF",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing",
                    ProductCode = "PCode",
                    ProductDescription = "New Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData"
                };
                reader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };

                reader.SetupConnectionString(connStr);
                reader.Execute();

                var productItemReader = new ProductItemDA
                {
                    GetAll = true
                };
                productItemReader.SetupConnectionString(connStr);
                var productItems = productItemReader.Execute();
                Assert.AreEqual(2, productItems.Count);

                var categoryReader = new CategoryDA
                {
                    GetAll = true
                };
                categoryReader.SetupConnectionString(connStr);
                var catItems = categoryReader.Execute();
                Assert.AreEqual(1, catItems.Count);

                var itemCategoryReader = new ItemCategoriesDA
                {
                    GetAll = true
                };
                itemCategoryReader.SetupConnectionString(connStr);
                var itemCatItems = itemCategoryReader.Execute();
                Assert.AreEqual(2, itemCatItems.Count);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Items", null);
                connection.ReturnSQLDataReader("Drop Table Categories", null);
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
            }
        }

        [Test]
        public void GetProductListCatMatch()
        {
            var connection = new SQLServerConnect();
            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Items]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[IsActive] [bit] NULL,[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[QuantityAvailable] [int] NULL,[Price] [money] NULL,[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[MinQuantity] [int] NULL,[CostPrice] [money] NULL,[RecommendedPrice] [money] NULL,[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]", null);
                CreateProductTable(connection);

                var item = new ProductItem
                {
                    ProductCode = "ATS77848"
                };
                var reader = new ProductItemDA
                {
                    WorkingItem = item
                };

                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var items = reader.Execute();

                Assert.AreEqual(1, items.Count);
            }

            finally
            {
                connection.ExecuteCmd("Drop Table Items", null);
            }
        }

        [Test]
        public void GetProductListAll()
        {
            var connection = new SQLServerConnect();
            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Items]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[IsActive] [bit] NULL,[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[QuantityAvailable] [int] NULL,[Price] [money] NULL,[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[MinQuantity] [int] NULL,[CostPrice] [money] NULL,[RecommendedPrice] [money] NULL,[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]", null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                CreateProductTable(connection);

                var reader = new ProductItemDA
                {
                    GetAll = true
                };

                string connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                reader.SetupConnectionString(connStr);
                var items = reader.Execute();

                Assert.AreEqual(53, items.Count);

                ProductItem checkItem = null;
                foreach (ProductItem item in items)
                {
                    if (item.ItemID == "AII61036")
                    {
                        checkItem = item;
                    }
                }

                Assert.AreEqual("Aquarium", checkItem.Category);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Items", null);
                connection.ReturnSQLDataReader("Drop Table Categories", null);
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
            }
        }

        [Test]
        public void TestProductItemInsertTwoItems()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Items]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[IsActive] [bit] NULL,[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[QuantityAvailable] [int] NULL,[Price] [money] NULL,[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[MinQuantity] [int] NULL,[CostPrice] [money] NULL,[RecommendedPrice] [money] NULL,[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]", null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                var item = new ProductItem
                {
                    ItemID = "WERT",
                    Category = "ABC",
                    Subcategory = "DEF",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing",
                    ProductCode = "PCode",
                    ProductDescription = "Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData"
                };

                var productItemReader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                var connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                productItemReader.SetupConnectionString(connStr);
                productItemReader.Execute();

                item = new ProductItem
                {
                    ItemID = "OIY",
                    Category = "ABC",
                    Subcategory = "RTE",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing 2",
                    ProductCode = "PCode",
                    ProductDescription = "Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData2"
                };

                productItemReader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                productItemReader.SetupConnectionString(connStr);
                productItemReader.Execute();

                productItemReader = new ProductItemDA
                {
                    GetAll = true
                };
                productItemReader.SetupConnectionString(connStr);
                var productItems = productItemReader.Execute();
                Assert.AreEqual(2, productItems.Count);

                var categoryReader = new CategoryDA
                {
                    GetAll = true
                };
                categoryReader.SetupConnectionString(connStr);
                var catItems = categoryReader.Execute();
                Assert.AreEqual(1, catItems.Count);

                var itemCategoryReader = new ItemCategoriesDA
                {
                    GetAll = true
                };
                itemCategoryReader.SetupConnectionString(connStr);
                var itemCatItems = itemCategoryReader.Execute();
                Assert.AreEqual(2, itemCatItems.Count);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Items", null);
                connection.ReturnSQLDataReader("Drop Table Categories", null);
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
            }
        }

        [Test]
        public void TestCategoryProductItemInsertTwoItems()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Items]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[IsActive] [bit] NULL,[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[QuantityAvailable] [int] NULL,[Price] [money] NULL,[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[MinQuantity] [int] NULL,[CostPrice] [money] NULL,[RecommendedPrice] [money] NULL,[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]", null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                var item = new ProductItem
                {
                    ItemID = "WERT",
                    Category = "ABC",
                    Subcategory = "DEF",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing",
                    ProductCode = "PCode",
                    ProductDescription = "Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData"
                };

                var productItemReader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                var connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                productItemReader.SetupConnectionString(connStr);
                productItemReader.Execute();

                item = new ProductItem
                {
                    ItemID = "OIY",
                    Category = "DEF",
                    Subcategory = "RTE",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing 2",
                    ProductCode = "PCode",
                    ProductDescription = "Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData2"
                };

                productItemReader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                productItemReader.SetupConnectionString(connStr);
                productItemReader.Execute();

                productItemReader = new ProductItemDA
                {
                    GetAll = true
                };
                productItemReader.SetupConnectionString(connStr);
                var productItems = productItemReader.Execute();
                Assert.AreEqual(2, productItems.Count);

                var categoryReader = new CategoryDA
                {
                    GetAll = true
                };
                categoryReader.SetupConnectionString(connStr);
                var catItems = categoryReader.Execute();
                Assert.AreEqual(2, catItems.Count);
                Assert.AreEqual("ABC", catItems[0].Name);
                Assert.AreEqual("DEF", catItems[1].Name);

                var itemCategoryReader = new ItemCategoriesDA
                {
                    GetAll = true
                };
                itemCategoryReader.SetupConnectionString(connStr);
                var itemCatItems = itemCategoryReader.Execute();
                Assert.AreEqual(2, itemCatItems.Count);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Items", null);
                connection.ReturnSQLDataReader("Drop Table Categories", null);
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
            }
        }

        [Test]
        public void TestProductItemQuery()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);

            try
            {
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Items]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[IsActive] [bit] NULL,[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[QuantityAvailable] [int] NULL,[Price] [money] NULL,[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[MinQuantity] [int] NULL,[CostPrice] [money] NULL,[RecommendedPrice] [money] NULL,[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]", null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[Categories]([CategoryID] [int] NOT NULL,[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                connection.ReturnSQLDataReader("CREATE TABLE [dbo].[ItemCategories]([ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[VendorID] [int] NOT NULL,[CategoryID] [int] NOT NULL,CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED ([ItemID] ASC,[VendorID] ASC,[CategoryID] ASC)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]",
                                                        null);
                var item = new ProductItem
                {
                    ItemID = "WERT",
                    Category = "ABC",
                    Subcategory = "DEF",
                    Cost = 5.54M,
                    VendorID = 10,
                    Picture = "Testing",
                    ProductCode = "PCode",
                    ProductDescription = "Desc",
                    ProductName = "Name",
                    ProductSize = "Size",
                    Section = "Section",
                    ShippingSurcharge = 3.43M,
                    UPC = "UPCData"
                };

                var productItemReader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                var connStr = String.Format(
                    "Data Source='{0}'; database={1}; user id={2}; password={3}",
                    Server, Database, UserName, UserPassword);
                productItemReader.SetupConnectionString(connStr);
                productItemReader.Execute();

                item = new ProductItem
                {
                    ItemID = "WERT",
                };

                productItemReader = new ProductItemDA
                {
                    WorkingItem = item,
                    InsertUpdateData = false
                };
                productItemReader.SetupConnectionString(connStr);
                var productItems = productItemReader.Execute();
                Assert.AreEqual(1, productItems.Count);
                Assert.AreEqual("ABC", productItems[0].Category);
                Assert.AreEqual(1, productItems[0].CategoryID);
            }

            finally
            {
                connection.ReturnSQLDataReader("Drop Table Items", null);
                connection.ReturnSQLDataReader("Drop Table Categories", null);
                connection.ReturnSQLDataReader("Drop Table ItemCategories", null);
            }
        }

        private static void CreateProductTable(DAConnect connection)
        {
            DoProductInsert("1	AII61036	Aquarium	Air Pumps	Hurricane Category 2 (deluxe Battery Operated Pump)	&lt;p&gt;Hurricane Pumps   from Deep Blue   are designed to help your aquarium residents survive a temporary power loss&amp;#046;  Our deluxe Category 2 pump features &lt;/p&gt;&lt;ul&gt;&lt;li&gt;&quot;Compact design makes it ideal for fish transportation, as well as, back up aeration during temporary power loss&amp;#046;&quot;&lt;/li&gt;&lt;li&gt;Water Resistant &amp;#045; A rubber seal for both the battery compartment and power switch&amp;#046;&lt;/li&gt;&lt;li&gt;Comes with a length of silicone air tubing and an airstone&amp;#046;&lt;/li&gt;&lt;li&gt;&quot;Has two &amp;#040;2&amp;#041;  &quot;&quot;D&quot;&quot; cell battery slots&amp;#046; Batteries are not included&amp;#046;&quot;&lt;/li&gt;&lt;li&gt;Made of high quality impact plastic for durability and quiet operation&amp;#046;&lt;/li&gt;&lt;li&gt;Single outlet design&amp;#046;&lt;/li&gt;&lt;/ul&gt;	1882_pid.jpg		5.45	0	749729610366", connection);
            DoProductInsert("1	AII61037	Aquarium	Air Pumps	Hurricane Category 5 (professional Ac/dc Battery Operated Pump)	Hurricane category 5 (professional ac/dc battery operated pump)	1883_pid.jpg		75.3	0	749729610373", connection);
            DoProductInsert("1	AAP702A	Aquarium	Air Pumps	Rena Air 50 Pump (for Up To 10gal Tanks)	Rena air  50 pump (for up to 10gal tanks)	1884_pid.jpg		11.75	0	17163507024", connection);
            DoProductInsert("1	AAP702B	Aquarium	Air Pumps	Rena Air 100 Pump (for Up To 20gal Tanks)	Rena air 100 pump (for up to 20gal tanks)	1885_pid.jpg		18.17	0	17163107026", connection);
            DoProductInsert("1	AAP702C	Aquarium	Air Pumps	Rena Air 200 Pump (for Up To 30gal Tanks)	Rena air 200 pump (for up to 30gal tanks)	1886_pid.jpg		27.95	0	17163207023", connection);
            DoProductInsert("1	AAP702D	Aquarium	Air Pumps	Rena Air 300 Pump (for Up To 75gal Tanks)	Rena air 300 pump (for up to 75gal tanks)	1887_pid.jpg		39.04	0	17163307020", connection);
            DoProductInsert("1	AAP702E	Aquarium	Air Pumps	Rena Air 400 Pump (for Up To 150gal Tanks)	Rena air 400 pump (for up to 150gal tanks)	1888_pid.jpg		60.47	0	17163407027", connection);
            DoProductInsert("1	ABLVF1	Aquarium	Air Pumps	Vibra Flow Air Pump 1 Single	&lt;p&gt;Single outlet air pump for fish bowls, 5 galllon and 10 gallon aquariums&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	2320_pid.jpg		6.47	0	30157004989", connection);
            DoProductInsert("1	ABLVF2	Aquarium	Air Pumps	Vibra Flow Air Pump 2 Double Outlet	&lt;p&gt;Double outlet air pump &amp;#045; ideal for all aquariums&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	2321_pid.jpg		9.36	0	30157004996", connection);
            DoProductInsert("1	ABLVF3	Aquarium	Air Pumps	Vibra Flow Air Pump 3 Double Outlet	&lt;p&gt;Double outlet air pump &amp;#045; ideal for all aquariums&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	2322_pid.jpg		10.92	0	30157005009", connection);
            DoProductInsert("1	ABLVFB1	Aquarium	Air Pumps	Vibra Flow Battery Air Pump	&lt;p&gt;&quot;Portable battery operated air pump is safe and convenient to use&amp;#046;  Ideal for holding tanks, fish transport&amp;#046;&quot;Portable battery operated air pump is safe and convenient to use&amp;#046; &lt;/p&gt;&lt;ul&gt;&lt;li&gt;&quot;Belt clip, tubing &amp; air stone included&quot;&lt;/li&gt;&lt;li&gt;1<br>&lt;/li&gt;&lt;/ul&gt;	2323_pid.jpg		8.51	0	30157001469", connection);
            DoProductInsert("1	ABLVFMINI	Aquarium	Air Pumps	Vibra Flow Air Pump Mini Single	&lt;p&gt;Mini size air pump &amp;#045; ideal for bowls and small aquariums&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	2324_pid.jpg		5.17	0	30157004972", connection);
            DoProductInsert("1	ACL01655	Aquarium	Air Pumps	Coralife Luft Pump	&lt;UL&gt;&lt;LI&gt;Luft Pump (Air Pump)&lt;/LI&gt;&lt;/UL&gt;&lt;ul&gt;	2892_pid.jpg		70.04	0	96316016552", connection);
            DoProductInsert("1	ACL01656	Aquarium	Air Pumps	Super Luft High Pressure Air Pump Sl - 38	Super luft high pressure air pump sl-38	2893_pid.jpg		70.27	0	96316016569", connection);
            DoProductInsert("1	ACL01657	Aquarium	Air Pumps	Super Luft High Pressure Air Pump Sl - 65	Super luft high pressure air pump sl-65	2894_pid.jpg		77.38	0	96316016576", connection);
            DoProductInsert("1	ATS77846	Aquarium	Air Pumps	Whisper 10 Air Pump (new Design Ul Approved)	&lt;p&gt;The new Whisper air pump was redesigned from the ground up for silence and performance&amp;#046;  It has many patented features that minimize noise yet allows for a  powerful flow of air&amp;#046;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7194_pid.jpg		9.52	0	46798778462", connection);
            DoProductInsert("1	ATS77847	Aquarium	Air Pumps	Whisper 20 Air Pump (new Design Ul Approved)	&lt;p&gt;The new Whisper air pump was redesigned from the ground up for silence and performance&amp;#046;  It has many patented features that minimize noise yet allows for a  powerful flow of air&amp;#046;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7195_pid.jpg		12.87	0	46798778479", connection);
            DoProductInsert("1	ATS77848	Aquarium	Air Pumps	Whisper 40 Air Pump (new Design Ul Approved)	&lt;p&gt;The new Whisper air pump was redesigned from the ground up for silence and performance&amp;#046;  It has many patented features that minimize noise yet allows for a  powerful flow of air&amp;#046;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7196_pid.jpg		13.99	0	46798778486", connection);
            DoProductInsert("1	ATS77849	Aquarium	Air Pumps	Whisper 60 Air Pump (new Design Ul Approved)	&lt;p&gt;The new Whisper air pump was redesigned from the ground up for silence and performance&amp;#046;  It has many patented features that minimize noise yet allows for a  powerful flow of air&amp;#046;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7197_pid.jpg		18.64	0	46798778493", connection);
            DoProductInsert("1	ATS77851	Aquarium	Air Pumps	Whisper 10 Air Pump (new Design)	&lt;p&gt;The new Whisper air pump was redesigned from the ground up for silence and performance&amp;#046;  It has many patented features that minimize noise yet allows for a  powerful flow of air&amp;#046;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7198_pid.jpg		6.91	0	46798778516", connection);
            DoProductInsert("1	ATS77852	Aquarium	Air Pumps	Whisper 20 Air Pump (new Design)	&lt;p&gt;The new Whisper air pump was redesigned from the ground up for silence and performance&amp;#046;  It has many patented features that minimize noise yet allows for a  powerful flow of air&amp;#046;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7199_pid.jpg		9.02	0	46798778523", connection);
            DoProductInsert("1	ATS77853	Aquarium	Air Pumps	Whisper 40 Air Pump (new Design)	&lt;p&gt;The new Whisper air pump was redesigned from the ground up for silence and performance&amp;#046;  It has many patented features that minimize noise yet allows for a  powerful flow of air&amp;#046;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7200_pid.jpg		11.39	0	46798778530", connection);
            DoProductInsert("1	ATS77854	Aquarium	Air Pumps	Whisper 60 Air Pump (new Design)	&lt;p&gt;The new Whisper air pump was redesigned from the ground up for silence and performance&amp;#046;  It has many patented features that minimize noise yet allows for a  powerful flow of air&amp;#046;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7201_pid.jpg		16.59	0	46798778547", connection);
            DoProductInsert("1	ATO1032	Aquarium	Air Pumps	Stellar S - 10 Air Pump (1 Device)	&lt;p&gt;Air Pump: Stellar S&amp;#045;10 &lt;/p&gt;&lt;p&gt;Tank up to 10 Gallons&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7489_pid.jpg		9.05	0	33153010329", connection);
            DoProductInsert("1	ATO1040	Aquarium	Air Pumps	Stellar S - 20 Air Pump (2 Devices)	&lt;p&gt;Air Pump: StellarS&amp;#045;20 &lt;/p&gt;&lt;p&gt;Tank up to 15 gallons&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7490_pid.jpg		10.08	0	33153010404", connection);
            DoProductInsert("1	ATO1042	Aquarium	Air Pumps	Stellar S - 30 Air Pump (3 Devices)	&lt;p&gt;Air Pump: StellarS&amp;#045;30 &lt;/p&gt;&lt;p&gt;Tank up to 20 Gallons&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7491_pid.jpg		14.05	0	33153010428", connection);
            DoProductInsert("1	ATO1050	Aquarium	Air Pumps	Stellar W - 40 Twin Outlet Air Pump (4 Devices)	&lt;p&gt;Air Pump: StellarW&amp;#045;40 (2 Outlets) &lt;/p&gt;&lt;p&gt;Tank up to  40 Gallons&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7492_pid.jpg		14.97	0	33153010503", connection);
            DoProductInsert("1	ATO1052	Aquarium	Air Pumps	Stellar W - 60 Twin Outlet Air Pump (6 Devices)	&lt;p&gt;Air Pump: StellarW&amp;#045;60 (2 Outlets) &lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	7493_pid.jpg		19.94	0	33153010527", connection);
            DoProductInsert("1	ATO1248	Aquarium	Air Pumps	Mini - 8 Air Pump (1 Outlet)	Mini-8 air pump (1 outlet)	7494_pid.jpg		6.32	0	33153012484", connection);
            DoProductInsert("1	ACA17557	Aquarium	Air Pumps	Million Air Ma - 200 Air Pump With Variable Flow Control Knob	&lt;p&gt; Simply the best pump for your dollar&amp;#046; A strong, reliable, safe and quiet air pump yet affordable&amp;#046; Available models for virtually any aquatic environment&amp;#046; &lt;/p&gt;&lt;p&gt; Model&amp;#045; MA200&lt;/p&gt;&lt;p&gt;Aquarium Size&amp;#045; 10&amp;#045;30 gallon&lt;/p&gt;&lt;p&gt;Outlet&amp;#045; Single &lt;/p&gt;&lt;p&gt;Control&amp;#045; yes&amp;#045; variable&lt;/p&gt;&lt;p&gt;Power&amp;#045; 2&amp;#046;3 watts&lt;/p&gt;&lt;p&gt;Air output&amp;#045; 1666 cc&amp;#047;m&lt;/p&gt;&lt;p&gt;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	21725_pid.jpg		8.26	0	6903717557", connection);
            DoProductInsert("1	ACA17595	Aquarium	Air Pumps	Million Air Ma - 600 Double Outlet Air Pump With Variable Flow Control Knob	&lt;p&gt; Simply the best pump for your dollar&amp;#046; A strong, reliable, safe and quiet air pump yet affordable&amp;#046; Available models for virtually any aquatic environment&amp;#046; &lt;/p&gt;&lt;p&gt; Model&amp;#045; MA600&lt;/p&gt;&lt;p&gt;Aquarium Size&amp;#045; 60 and up gallon&lt;/p&gt;&lt;p&gt;Outlet&amp;#045; Dual&lt;/p&gt;&lt;p&gt;Control&amp;#045;yes&amp;#045;varaible&lt;/p&gt;&lt;p&gt; Power&amp;#045; 3&amp;#046;4 watts&lt;/p&gt;&lt;p&gt;Air output&amp;#045; 2666 cc&amp;#047;m&lt;/p&gt;&lt;p&gt;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	21735_pid.jpg		11.18	0	6903717595", connection);
            DoProductInsert("1	ACA17588	Aquarium	Air Pumps	Million Air Ma - 500 Double Outlet Air Pump	Million air ma-500 double outlet air pump	21730_pid.jpg		10.58	0	6903717588", connection);
            DoProductInsert("1	ACA17571	Aquarium	Air Pumps	Million Air Ma - 400 Double Outlet Air Pump With Variable Flow Control Knob	&lt;p&gt; Simply the best pump for your dollar&amp;#046; A strong, reliable, safe and quiet air pump yet affordable&amp;#046; Available models for virtually any aquatic environment&amp;#046; &lt;/p&gt;&lt;p&gt; Model&amp;#045; MA400&lt;/p&gt;&lt;p&gt;Aquarium Size&amp;#045; 30&amp;#045;50 gallon&lt;/p&gt;&lt;p&gt;Outlet&amp;#045; Dual&lt;/p&gt;&lt;p&gt;Control&amp;#045; yes&amp;#045;variable&lt;/p&gt;&lt;p&gt;Power&amp;#045; 2&amp;#046;4 watts&lt;/p&gt;&lt;p&gt;Air output&amp;#045; 2000 cc&amp;#047;m&lt;/p&gt;&lt;p&gt;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	21729_pid.jpg		9.21	0	6903717571", connection);
            DoProductInsert("1	ACA17564	Aquarium	Air Pumps	Million Air Ma - 300 Double Outlet Air Pump	&lt;p&gt; Simply the best pump for your dollar&amp;#046; A strong, reliable, safe and quiet air pump yet affordable&amp;#046; Available models for virtually any aquatic environment&amp;#046; &lt;/p&gt;&lt;p&gt; Model&amp;#045; MA300&lt;/p&gt;&lt;p&gt;Aquarium Size&amp;#045; 25&amp;#045;40 gallon&lt;/p&gt;&lt;p&gt;Outlet&amp;#045; Dual&lt;/p&gt;&lt;p&gt;Control&amp;#045; &lt;/p&gt;&lt;p&gt;Power&amp;#045; 2&amp;#046;4 watts&lt;/p&gt;&lt;p&gt;Air output&amp;#045; 2000 cc&amp;#047;m&lt;/p&gt;&lt;p&gt;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;	21726_pid.jpg		8.78	0	6903717564", connection);
            DoProductInsert("1	AHYKB2101	Aquarium	Air Pumps	Ario Geyser Kit (ornament &amp; Ario 2 Blue) Medium	Ario geyser kit (ornament &amp; ario 2 blue)	22645_pid.jpg		39.66	0	841421005263", connection);
            DoProductInsert("1	AHYKB1101	Aquarium	Air Pumps	Ario Volcano Kit (ornament &amp; Ario 2 Red) Medium	Ario volcano kit (ornament &amp; ario 2 red)	22644_pid.jpg		39.66	0	841421005249", connection);
            DoProductInsert("1	ACA17175	Aquarium	Air Pumps	Million Air Ma - 80 Air Pump	&lt;html&gt;&lt;head&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt; Million Air&amp;#047;Commodity Axis Inc&amp;#046; - ACA17175&lt;/h2&gt;&lt;p&gt; Simply the best pump for your dollar&amp;#046; A strong, reliable, safe and quiet air pump yet affordable&amp;#046; Available models for virtually any aquatic environment&amp;#046; &lt;/p&gt;&lt;p&gt; Model&amp;#045; MA80&lt;/p&gt;&lt;p&gt;Aquarium Size&amp;#045; 5&amp;#045;10 gallon&lt;/p&gt;&lt;p&gt;Outlet&amp;#045; Single &lt;/p&gt;&lt;p&gt;Control&amp;#045; &lt;/p&gt;&lt;p&gt;Power&amp;#045; 2&amp;#046;4 watts&lt;/p&gt;&lt;p&gt;Air output&amp;#045; 833 cc&amp;#047;m&lt;/p&gt;&lt;p&gt;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	24624_pid.jpg		7.14	0	6903717175", connection);
            DoProductInsert("1	AJW21502	Aquarium	Air Pumps	Fusion Air Pump 300	Fusion air pump 300	24635_pid.jpg		6.89	0	618940215028", connection);
            DoProductInsert("1	AJW21510	Aquarium	Air Pumps	Fusion Air Pump 700	Fusion air pump 700	24639_pid.jpg		20.68	0	618940215103", connection);
            DoProductInsert("1	AJW21508	Aquarium	Air Pumps	Fusion Air Pump 600	Fusion air pump 600	24638_pid.jpg		17.24	0	618940215080", connection);
            DoProductInsert("1	AJW21506	Aquarium	Air Pumps	Fusion Air Pump 500	Fusion air pump 500	24637_pid.jpg		11.72	0	618940215066", connection);
            DoProductInsert("1	AJW21504	Aquarium	Air Pumps	Fusion Air Pump 400	Fusion air pump 400	24636_pid.jpg		8.61	0	618940215042", connection);
            DoProductInsert("1	ACA17540	Aquarium	Air Pumps	Million Air Ma - 100 Air Pump	&lt;html&gt;&lt;head&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt; Million Air&amp;#047;Commodity Axis Inc&amp;#046; - ACA17540&lt;/h2&gt;&lt;p&gt; Simply the best pump for your dollar&amp;#046; A strong, reliable, safe and quiet air pump yet affordable&amp;#046; Available models for virtually any aquatic environment&amp;#046; &lt;/p&gt;&lt;p&gt; Model&amp;#045; MA100&lt;/p&gt;&lt;p&gt;Aquarium Size&amp;#045; 5&amp;#045;20 gallon&lt;/p&gt;&lt;p&gt;Outlet&amp;#045; Single &lt;/p&gt;&lt;p&gt;Control&amp;#045; &lt;/p&gt;&lt;p&gt;Power&amp;#045; 2&amp;#046;3 watts&lt;/p&gt;&lt;p&gt;Air output&amp;#045; 1666 cc&amp;#047;m&lt;/p&gt;&lt;p&gt;&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	24626_pid.jpg		8.01	0	6903717540", connection);
            DoProductInsert("1	AHYKB3201	Aquarium	Air Pumps	Ario Log Kit (ornament &amp; Ario 4 Green) Large	&lt;html&gt;&lt;head&gt;&lt;LINK REL=&quot;stylesheet&quot; HREF=&quot;/VIA/RES/Settings/PreloginCatalog.css&quot; TYPE=&quot;text/css&quot;&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt;HYDOR USA INC - HYDOR ARIO LOG KIT GREEN LG&lt;/h2&gt;&lt;ul&gt;&lt;li&gt;Beautiful Deco aquarium ornament kit features a large log/stump ornament and a green Ario #4.  For aquariums 20&quot;+- deep.&lt;/li&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	25719_pid.jpg		60.37	0	841421005294", connection);
            DoProductInsert("1	ATS26075	Aquarium	Air Pumps	Tetra 150 Air Pump Formally Deep Water	&lt;html&gt;&lt;head&gt;&lt;LINK REL=&quot;stylesheet&quot; HREF=&quot;/VIA/RES/Settings/PreloginCatalog.css&quot; TYPE=&quot;text/css&quot;&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt;Tetra - TETRA AP 150 AIR PUMP&lt;/h2&gt;&lt;p&gt;These Whisper® air Pumps are Tetra&amp;#039;s most powerful line of air pumps&amp;#046;  The pumps are designed for situations that produce greater back&amp;#045;pressure, such as deep tanks &amp;#040;up to 8 feet deep&amp;#041;, long decorator air stones, multiple air stones in one or more tanks, and protein skimmers for saltwater&amp;#046;&lt;/p&gt;&lt;p&gt;AP 150&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	25812_pid.jpg		42.27	0	46798260752", connection);
            DoProductInsert("1	ATS77855	Aquarium	Air Pumps	Whisper 100 Air Pump (new Design)	&lt;html&gt;&lt;head&gt;&lt;LINK REL=&quot;stylesheet&quot; HREF=&quot;/VIA/RES/Settings/PreloginCatalog.css&quot; TYPE=&quot;text/css&quot;&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt;Tetra - TETRA WHISP 100 AIR PUMP&lt;/h2&gt;&lt;p&gt;Whisper 100 Air Pump&lt;/p&gt;&lt;p&gt;The New Shape of Silence&amp;#033;  Designed From the Ground Up for Silence and Performance&amp;#046;&lt;/p&gt;&lt;p&gt;Minimal noise, maximum air flow&amp;#046;  The Whisper® Air Pump&amp;#039;s dome shape actually flattens sound wave frequencies&amp;#046;  In addition, each model features sound&amp;#045;dampening chambers designed specifically for that model&amp;#046;  And the air pump&amp;#039;s rubber feet and suspended motor prevent sound waves from reflecting off surfaces such as tables and shelves&amp;#046; &lt;/p&gt;&lt;ul&gt;&lt;li&gt;Whisper® 100&lt;/li&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	25814_pid.jpg		22.79	0	46798778554", connection);
            DoProductInsert("1	AHYKB3101	Aquarium	Air Pumps	Ario Log Kit (ornament &amp; Ario 2 Green) Medium	&lt;html&gt;&lt;head&gt;&lt;LINK REL=&quot;stylesheet&quot; HREF=&quot;/VIA/RES/Settings/PreloginCatalog.css&quot; TYPE=&quot;text/css&quot;&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt;HYDOR USA INC - HYDOR ARIO LOG KIT GRN MD&lt;/h2&gt;&lt;ul&gt;&lt;li&gt;Beautiful Deco aquarium ornament kit features a medium log/stump ornament and a green Ario #2.  For aquariums 15&quot;+- deep.&lt;/li&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	25718_pid.jpg		39.66	0	841421005287", connection);
            DoProductInsert("1	AHYKB2201	Aquarium	Air Pumps	Ario Geyser Kit (ornament &amp; Ario 4 Blue) Large	&lt;html&gt;&lt;head&gt;&lt;LINK REL=&quot;stylesheet&quot; HREF=&quot;/VIA/RES/Settings/PreloginCatalog.css&quot; TYPE=&quot;text/css&quot;&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt;HYDOR USA INC - HYDOR ARIO GEYSER KIT BLUE LG&lt;/h2&gt;&lt;ul&gt;&lt;li&gt;Beautiful deco aquarium ornament kit features a large guyser ornament and a blue Ario #4.  For aquariums 20&quot;+- deep.&lt;/li&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	25717_pid.jpg		60.37	0	841421005270", connection);
            DoProductInsert("1	AHYKB1201	Aquarium	Air Pumps	Ario Volcano Kit (ornament &amp; Ario 4 Red) Large	&lt;html&gt;&lt;head&gt;&lt;LINK REL=&quot;stylesheet&quot; HREF=&quot;/VIA/RES/Settings/PreloginCatalog.css&quot; TYPE=&quot;text/css&quot;&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt;HYDOR USA INC - HYDOR ARIO VOLCANO KIT RED LG&lt;/h2&gt;&lt;ul&gt;&lt;li&gt;Beautiful Deco aquarium ornament kit features a large volcano ornament and a red Ario #4.  For aquariums 20&quot;+- deep.&lt;/li&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	25716_pid.jpg		60.37	0	841421005256", connection);
            DoProductInsert("1	ATS26076	Aquarium	Air Pumps	Tetra 300 Air Pump (tanks To 96&quot; Or Multi Applications) Formally Deep Water	&lt;html&gt;&lt;head&gt;&lt;LINK REL=&quot;stylesheet&quot; HREF=&quot;/VIA/RES/Settings/PreloginCatalog.css&quot; TYPE=&quot;text/css&quot;&gt;&lt;/head&gt;&lt;body&gt;&lt;h2&gt;TETRA AP 300 AIR PUMP - These Whisper® air Pumps are Tetra&amp;#039;s most powerful line of air pumps&amp;#046;  The pumps are designed for situations that produce greater back&amp;#045;pressure, such as deep tanks &amp;#040;up to 8 feet deep&amp;#041;, long decorator air stones, multiple air stones in one or more tanks, and protein skimmers for saltwater&amp;#046;&lt;/h2&gt;&lt;p&gt;AP 300&lt;/p&gt;&lt;ul&gt;&lt;/ul&gt;&lt;/body&gt;&lt;/html&gt;	25813_pid.jpg		73.97	0	46798260769", connection);
            DoProductInsert("1	AHY14201	Aquarium	Air Pumps	Ario 4 Color Venturi Submersible Air Pump Red	Ario 4 color venturi submersible air pump red	28102_pid.jpg		29.15	0	0", connection);
            DoProductInsert("1	AHY22101	Aquarium	Air Pumps	Ario 2 Color Venturi Submersible Air Pump Blue	Ario 2 color venturi submersible air pump blue	28103_pid.jpg		26.89	0	0", connection);
            DoProductInsert("1	AAP704C	Aquarium	Air Stones &amp; Wands	Rena Micro Bubbler Ceramic Airstone 2&quot;	Rena micro bubbler ceramic airstone 2&quot;	1889_pid.jpg		4.1	0	17163037040", connection);
        }

        private static void DoProductInsert(string P_line, DAConnect P_connection)
        {
            string[] parts = P_line.Split('\t');
            var item = new ProductItem {VendorID = 1};

            if (parts[1].Length < 50)
            {
                item.ItemID = parts[1];
                item.ProductCode = parts[1];
            }
            else
            {
                item.ItemID = parts[1].Substring(0, 50);
                item.ProductCode = parts[1].Substring(0, 50);
            }

            if (parts[2].Length < 50)
            {
                item.Category = parts[2];
            }
            else
            {
                item.Category = parts[2].Substring(0, 50);
            }

            if (parts[4].Length < 50)
            {
                item.ProductName = parts[4];
            }
            else
            {
                item.ProductName = parts[4].Substring(0, 50);
            }

            if (parts[5].Length < 50)
            {
                item.ProductDescription = parts[5];
            }
            else
            {
                item.ProductDescription = parts[5].Substring(0, 50);
            }

            if (parts[6].Length < 50)
            {
                item.Picture = parts[6];
            }
            else
            {
                item.Picture = parts[6].Substring(0, 50);
            }

            if (parts[7].Length < 50)
            {
                item.ProductSize = parts[7];
            }
            else
            {
                item.ProductSize = parts[7].Substring(0, 50);
            }

            item.Cost = Convert.ToDecimal(parts[8]);
            item.UPC = parts[10];

            var itemDA = new ProductItemDA {WorkingItem = item, InsertUpdateData = true};
            itemDA.SetupConnectionString(P_connection.GetConnectionString());
            itemDA.Execute();
        }
    }
}

#endif