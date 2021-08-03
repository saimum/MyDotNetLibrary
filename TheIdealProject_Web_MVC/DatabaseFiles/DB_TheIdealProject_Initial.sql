USE [master]
GO
/****** Object:  Database [DB_TheIdealPrtoject]    Script Date: 2021-08-03 7:17:55 PM ******/
CREATE DATABASE [DB_TheIdealPrtoject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_the_ideal_project', FILENAME = N'D:\Installed Sooftwares\MSSQL\DATA\db_the_ideal_project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_the_ideal_project_log', FILENAME = N'D:\Installed Sooftwares\MSSQL\DATA\db_the_ideal_project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_TheIdealPrtoject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET  MULTI_USER 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_TheIdealPrtoject', N'ON'
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET QUERY_STORE = OFF
GO
USE [DB_TheIdealPrtoject]
GO
/****** Object:  Table [dbo].[Tl_Product]    Script Date: 2021-08-03 7:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tl_Product](
	[Tl_ProductPk] [bigint] IDENTITY(0,1) NOT NULL,
	[Product_TmProductFk] [bigint] NULL,
	[productDevelperNote] [varchar](50) NULL,
	[productIsActive] [bit] NULL,
	[productIsViewable] [bit] NULL,
	[productIsDeleted] [bit] NULL,
	[product_TmCategoryFk] [bigint] NULL,
	[productName] [varchar](50) NULL,
	[product_TmUserFk_Creator] [bigint] NULL,
	[productCreatedAt] [datetime] NULL,
	[product_TmUserFk_Modifier] [bigint] NULL,
	[productModifiedAt] [datetime] NULL,
	[productPrice] [bigint] NULL,
 CONSTRAINT [PK_Tl_Product] PRIMARY KEY CLUSTERED 
(
	[Tl_ProductPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tm_Category]    Script Date: 2021-08-03 7:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tm_Category](
	[TmCategoryPk] [bigint] IDENTITY(0,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tm_category] PRIMARY KEY CLUSTERED 
(
	[TmCategoryPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tm_Product]    Script Date: 2021-08-03 7:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tm_Product](
	[TmProductPk] [bigint] IDENTITY(0,1) NOT NULL,
	[Product_TlProductFk] [bigint] NULL,
	[productDevelperNote] [varchar](50) NULL,
	[productIsActive] [bit] NULL,
	[productIsViewable] [bit] NULL,
	[productIsDeleted] [bit] NULL,
	[product_TmCategoryFk] [bigint] NULL,
	[productName] [varchar](50) NULL,
	[product_TmUserFk_Creator] [bigint] NULL,
	[productCreatedAt] [datetime] NULL,
	[product_TmUserFk_Modifier] [bigint] NULL,
	[productModifiedAt] [datetime] NULL,
	[productPrice] [bigint] NULL,
 CONSTRAINT [PK_TmProduct] PRIMARY KEY CLUSTERED 
(
	[TmProductPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tm_User]    Script Date: 2021-08-03 7:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tm_User](
	[TmUserPk] [bigint] IDENTITY(0,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TmUser] PRIMARY KEY CLUSTERED 
(
	[TmUserPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tm_Category] ON 

INSERT [dbo].[Tm_Category] ([TmCategoryPk], [CategoryName]) VALUES (0, N'N/A')
INSERT [dbo].[Tm_Category] ([TmCategoryPk], [CategoryName]) VALUES (1, N'ALL')
SET IDENTITY_INSERT [dbo].[Tm_Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Tm_Product] ON 

INSERT [dbo].[Tm_Product] ([TmProductPk], [Product_TlProductFk], [productDevelperNote], [productIsActive], [productIsViewable], [productIsDeleted], [product_TmCategoryFk], [productName], [product_TmUserFk_Creator], [productCreatedAt], [product_TmUserFk_Modifier], [productModifiedAt], [productPrice]) VALUES (0, NULL, NULL, NULL, NULL, NULL, 0, N'N/A', 0, NULL, 0, NULL, NULL)
INSERT [dbo].[Tm_Product] ([TmProductPk], [Product_TlProductFk], [productDevelperNote], [productIsActive], [productIsViewable], [productIsDeleted], [product_TmCategoryFk], [productName], [product_TmUserFk_Creator], [productCreatedAt], [product_TmUserFk_Modifier], [productModifiedAt], [productPrice]) VALUES (1, NULL, NULL, NULL, NULL, NULL, 0, N'ALL', 0, NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tm_Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Tm_User] ON 

INSERT [dbo].[Tm_User] ([TmUserPk], [UserName]) VALUES (0, N'N/A')
INSERT [dbo].[Tm_User] ([TmUserPk], [UserName]) VALUES (1, N'ALL')
INSERT [dbo].[Tm_User] ([TmUserPk], [UserName]) VALUES (2, N'admin user')
SET IDENTITY_INSERT [dbo].[Tm_User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tm_Produ__0A9CBBE0645C5D86]    Script Date: 2021-08-03 7:17:57 PM ******/
ALTER TABLE [dbo].[Tm_Product] ADD  CONSTRAINT [UQ__Tm_Produ__0A9CBBE0645C5D86] UNIQUE NONCLUSTERED 
(
	[productName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tm_Product] ADD  CONSTRAINT [DF_Tm_Product_product_TmCategoryFk]  DEFAULT ((0)) FOR [product_TmCategoryFk]
GO
ALTER TABLE [dbo].[Tm_Product] ADD  CONSTRAINT [DF_Tm_Product_product_TmUserFk_Creator]  DEFAULT ((0)) FOR [product_TmUserFk_Creator]
GO
ALTER TABLE [dbo].[Tm_Product] ADD  CONSTRAINT [DF_Tm_Product_product_TmUserFk_Modifier]  DEFAULT ((0)) FOR [product_TmUserFk_Modifier]
GO
ALTER TABLE [dbo].[Tm_Product]  WITH CHECK ADD  CONSTRAINT [FK_Tm_Product_Tm_Category] FOREIGN KEY([product_TmCategoryFk])
REFERENCES [dbo].[Tm_Category] ([TmCategoryPk])
GO
ALTER TABLE [dbo].[Tm_Product] CHECK CONSTRAINT [FK_Tm_Product_Tm_Category]
GO
ALTER TABLE [dbo].[Tm_Product]  WITH CHECK ADD  CONSTRAINT [fk_Tm_user_creator_Tm_Product] FOREIGN KEY([product_TmUserFk_Creator])
REFERENCES [dbo].[Tm_User] ([TmUserPk])
GO
ALTER TABLE [dbo].[Tm_Product] CHECK CONSTRAINT [fk_Tm_user_creator_Tm_Product]
GO
ALTER TABLE [dbo].[Tm_Product]  WITH CHECK ADD  CONSTRAINT [fk_Tm_user_modifier_Tm_Product] FOREIGN KEY([product_TmUserFk_Modifier])
REFERENCES [dbo].[Tm_User] ([TmUserPk])
GO
ALTER TABLE [dbo].[Tm_Product] CHECK CONSTRAINT [fk_Tm_user_modifier_Tm_Product]
GO
USE [master]
GO
ALTER DATABASE [DB_TheIdealPrtoject] SET  READ_WRITE 
GO
