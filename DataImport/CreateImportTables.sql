USE [MyPetsFW]
GO

DROP Table [dbo].[ItemCategories]
DROP Table [dbo].[Items]
DROP Table [dbo].[Categories]
DROP Table [dbo].[Vendor]

USE [MyPetsFW]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 03/31/2009 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[VendorID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Vendor_IsActive]  DEFAULT ((1)),
	[VendorName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MainPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Website] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Country] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

USE [MyPetsFW]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 03/31/2009 19:59:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] NOT NULL,
	[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CategoryPhoto] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


USE [MyPetsFW]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 03/31/2009 20:02:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VendorID] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[QuantityAvailable] [int] NULL,
	[Price] [money] NULL,
	[PhotoName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhotoLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinQuantity] [int] NULL,
	[CostPrice] [money] NULL,
	[RecommendedPrice] [money] NULL,
	[UPC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Size] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[VendorID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--GO
--ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Vendor] FOREIGN KEY([VendorID])
--REFERENCES [dbo].[Vendor] ([VendorID])
--GO
--ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Vendor]

USE [MyPetsFW]
GO
/****** Object:  Table [dbo].[ItemCategories]    Script Date: 03/31/2009 20:02:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategories](
	[ItemID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VendorID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[VendorID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ItemCategories]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategories_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[ItemCategories] CHECK CONSTRAINT [FK_ItemCategories_Categories]
GO
ALTER TABLE [dbo].[ItemCategories]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategories_Items] FOREIGN KEY([ItemID], [VendorID])
REFERENCES [dbo].[Items] ([ItemID], [VendorID])
GO
ALTER TABLE [dbo].[ItemCategories] CHECK CONSTRAINT [FK_ItemCategories_Items]

==============================================================================================================================================================================================================
==============================================================================================================================================================================================================

Insert into Vendor (VendorID, VendorName) Values (1, 'Vendor 1')
Insert into Vendor (VendorID, VendorName) Values (2, 'Vendor 2')
Insert into Vendor (VendorID, VendorName) Values (3, 'Vendor 3')

Select * from Vendor
Select * from Categories
Select * from ItemCategories
Select * from Items
