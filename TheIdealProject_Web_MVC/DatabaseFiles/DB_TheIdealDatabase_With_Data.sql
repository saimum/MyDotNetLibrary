USE [master]
GO
/****** Object:  Database [DB_TheIdealDatabase]    Script Date: 2021-08-23 5:44:40 PM ******/
CREATE DATABASE [DB_TheIdealDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_TheIdealDatabase', FILENAME = N'D:\Installed Sooftwares\MSSQL\DATA\DB_TheIdealDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_TheIdealDatabase_log', FILENAME = N'D:\Installed Sooftwares\MSSQL\DATA\DB_TheIdealDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_TheIdealDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_TheIdealDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_TheIdealDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_TheIdealDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_TheIdealDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_TheIdealDatabase', N'ON'
GO
ALTER DATABASE [DB_TheIdealDatabase] SET QUERY_STORE = OFF
GO
USE [DB_TheIdealDatabase]
GO
/****** Object:  Table [dbo].[TL_Category]    Script Date: 2021-08-23 5:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TL_Category](
	[TL_CategoryPk] [bigint] IDENTITY(0,1) NOT NULL,
	[TM_CategoryFk] [bigint] NOT NULL,
	[Category_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TL_Category] PRIMARY KEY CLUSTERED 
(
	[TL_CategoryPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TL_Product]    Script Date: 2021-08-23 5:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TL_Product](
	[TL_ProductPk] [bigint] IDENTITY(0,1) NOT NULL,
	[TM_ProductFk] [bigint] NOT NULL,
	[Product_DevelperNote] [varchar](50) NULL,
	[Product_TM_SubCategoryFk] [bigint] NOT NULL,
	[Product_TL_SubCategoryFk] [bigint] NOT NULL,
	[Product_IsActive] [bit] NULL,
	[Product_IsViewable] [bit] NULL,
	[Product_IsDeleted] [bit] NULL,
	[Product_Code] [varchar](20) NOT NULL,
	[Product_Name] [varchar](50) NOT NULL,
	[Product_Price] [bigint] NULL,
	[Product_TM_UserFk_Creator_Nt] [bigint] NULL,
	[Product_CreatedAt_Nt] [datetime] NULL,
	[Product_TM_UserFk_Modifier_Nt] [bigint] NULL,
	[Product_ModifiedAt_Nt] [datetime] NULL,
 CONSTRAINT [PK_TL_Product] PRIMARY KEY CLUSTERED 
(
	[TL_ProductPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TL_SubCategory]    Script Date: 2021-08-23 5:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TL_SubCategory](
	[TL_SubCategoryPk] [bigint] IDENTITY(0,1) NOT NULL,
	[TM_SubCategoryFk] [bigint] NOT NULL,
	[TM_CategoryFk] [bigint] NOT NULL,
	[TL_CategoryFk] [bigint] NOT NULL,
	[SubCategory_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TL_SubCategory] PRIMARY KEY CLUSTERED 
(
	[TL_SubCategoryPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TM_Category]    Script Date: 2021-08-23 5:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TM_Category](
	[TM_CategoryPk] [bigint] IDENTITY(0,1) NOT NULL,
	[TL_CategoryFk] [bigint] NOT NULL,
	[Category_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TM_Category] PRIMARY KEY CLUSTERED 
(
	[TM_CategoryPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TM_Product]    Script Date: 2021-08-23 5:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TM_Product](
	[TM_ProductPk] [bigint] IDENTITY(0,1) NOT NULL,
	[TL_ProductFk] [bigint] NOT NULL,
	[Product_DevelperNote] [varchar](50) NULL,
	[Product_TM_SubCategoryFk] [bigint] NOT NULL,
	[Product_TL_SubCategoryFk] [bigint] NOT NULL,
	[Product_IsActive] [bit] NULL,
	[Product_IsViewable] [bit] NULL,
	[Product_IsDeleted] [bit] NULL,
	[Product_Code] [varchar](20) NOT NULL,
	[Product_Name] [varchar](50) NOT NULL,
	[Product_Price] [bigint] NULL,
	[Product_TM_UserFk_Creator_Nt] [bigint] NULL,
	[Product_CreatedAt_Nt] [datetime] NULL,
	[Product_TM_UserFk_Modifier_Nt] [bigint] NULL,
	[Product_ModifiedAt_Nt] [datetime] NULL,
 CONSTRAINT [PK_TM_Product] PRIMARY KEY CLUSTERED 
(
	[TM_ProductPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TM_SubCategory]    Script Date: 2021-08-23 5:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TM_SubCategory](
	[TM_SubCategoryPk] [bigint] IDENTITY(0,1) NOT NULL,
	[TL_SubCategoryFk] [bigint] NOT NULL,
	[TM_CategoryFk] [bigint] NOT NULL,
	[TL_CategoryFk] [bigint] NOT NULL,
	[SubCategory_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TM_SubCategory] PRIMARY KEY CLUSTERED 
(
	[TM_SubCategoryPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TM_User]    Script Date: 2021-08-23 5:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TM_User](
	[TM_UserPk] [bigint] IDENTITY(0,1) NOT NULL,
	[User_ID] [varchar](50) NOT NULL,
	[User_Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TM_User] PRIMARY KEY CLUSTERED 
(
	[TM_UserPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_TM_Category_Category_Name]    Script Date: 2021-08-23 5:44:44 PM ******/
ALTER TABLE [dbo].[TM_Category] ADD  CONSTRAINT [UC_TM_Category_Category_Name] UNIQUE NONCLUSTERED 
(
	[Category_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_TM_Product_Product_Code]    Script Date: 2021-08-23 5:44:44 PM ******/
ALTER TABLE [dbo].[TM_Product] ADD  CONSTRAINT [UC_TM_Product_Product_Code] UNIQUE NONCLUSTERED 
(
	[Product_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_TM_Product_Product_Name]    Script Date: 2021-08-23 5:44:44 PM ******/
ALTER TABLE [dbo].[TM_Product] ADD  CONSTRAINT [UC_TM_Product_Product_Name] UNIQUE NONCLUSTERED 
(
	[Product_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_TM_SubCategory_SubCategory_Name]    Script Date: 2021-08-23 5:44:45 PM ******/
ALTER TABLE [dbo].[TM_SubCategory] ADD  CONSTRAINT [UC_TM_SubCategory_SubCategory_Name] UNIQUE NONCLUSTERED 
(
	[SubCategory_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_TM_User_User_ID]    Script Date: 2021-08-23 5:44:45 PM ******/
ALTER TABLE [dbo].[TM_User] ADD  CONSTRAINT [UC_TM_User_User_ID] UNIQUE NONCLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TL_Category] ADD  DEFAULT ((0)) FOR [TM_CategoryFk]
GO
ALTER TABLE [dbo].[TL_Product] ADD  DEFAULT ((0)) FOR [TM_ProductFk]
GO
ALTER TABLE [dbo].[TL_Product] ADD  DEFAULT ((0)) FOR [Product_TM_SubCategoryFk]
GO
ALTER TABLE [dbo].[TL_Product] ADD  DEFAULT ((0)) FOR [Product_TL_SubCategoryFk]
GO
ALTER TABLE [dbo].[TL_SubCategory] ADD  DEFAULT ((0)) FOR [TM_SubCategoryFk]
GO
ALTER TABLE [dbo].[TL_SubCategory] ADD  DEFAULT ((0)) FOR [TM_CategoryFk]
GO
ALTER TABLE [dbo].[TL_SubCategory] ADD  DEFAULT ((0)) FOR [TL_CategoryFk]
GO
ALTER TABLE [dbo].[TM_Category] ADD  DEFAULT ((0)) FOR [TL_CategoryFk]
GO
ALTER TABLE [dbo].[TM_Product] ADD  DEFAULT ((0)) FOR [TL_ProductFk]
GO
ALTER TABLE [dbo].[TM_Product] ADD  DEFAULT ((0)) FOR [Product_TM_SubCategoryFk]
GO
ALTER TABLE [dbo].[TM_Product] ADD  DEFAULT ((0)) FOR [Product_TL_SubCategoryFk]
GO
ALTER TABLE [dbo].[TM_SubCategory] ADD  DEFAULT ((0)) FOR [TL_SubCategoryFk]
GO
ALTER TABLE [dbo].[TM_SubCategory] ADD  DEFAULT ((0)) FOR [TM_CategoryFk]
GO
ALTER TABLE [dbo].[TM_SubCategory] ADD  DEFAULT ((0)) FOR [TL_CategoryFk]
GO
USE [master]
GO
ALTER DATABASE [DB_TheIdealDatabase] SET  READ_WRITE 
GO
