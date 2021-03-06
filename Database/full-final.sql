USE [master]
GO
/****** Object:  Database [Store]    Script Date: 04-Jun-20 11:57:29 PM ******/
CREATE DATABASE [Store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Store', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Store.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Store_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Store_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Store] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Store] SET ARITHABORT OFF 
GO
ALTER DATABASE [Store] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Store] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Store] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Store] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Store] SET RECOVERY FULL 
GO
ALTER DATABASE [Store] SET  MULTI_USER 
GO
ALTER DATABASE [Store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Store] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Store', N'ON'
GO
USE [Store]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] NOT NULL,
	[username] [varchar](255) NULL,
	[pwd] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[phone] [varchar](255) NULL,
	[level] [int] NULL,
	[image] [varchar](255) NULL,
	[fullname] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[category]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] NOT NULL,
	[name] [nvarchar](255) NULL,
	[description] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[comment]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[id] [int] NOT NULL,
	[product_id] [int] NULL,
	[users_id] [int] NULL,
	[comments] [nvarchar](4000) NULL,
 CONSTRAINT [PK_dbo.comments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[discount]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[discount](
	[id] [int] NOT NULL,
	[value] [varchar](255) NULL,
	[name] [varchar](255) NULL,
 CONSTRAINT [PK_dbo.discount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[image]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[image](
	[id] [int] NOT NULL,
	[url] [varchar](255) NULL,
	[product_id] [int] NULL,
 CONSTRAINT [PK_dbo.image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[order]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] NOT NULL,
	[users_id] [int] NULL,
	[total_money] [varchar](50) NULL,
	[date_create] [datetime] NULL,
	[method] [nvarchar](255) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_dbo.orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[order_detail]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[order_detail](
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [varchar](255) NULL,
	[money] [varchar](255) NULL,
 CONSTRAINT [PK_dbo.order_detail] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[post]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post](
	[id] [int] NOT NULL,
	[product_id] [int] NULL,
	[name] [nvarchar](255) NULL,
	[descripton] [nvarchar](4000) NULL,
 CONSTRAINT [PK_dbo.posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[product]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] NOT NULL,
	[sku] [varchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[price] [varchar](255) NULL,
	[Ghz] [varchar](255) NULL,
	[color] [varchar](255) NULL,
	[sensor] [varchar](255) NULL,
	[cpu] [varchar](255) NULL,
	[ram] [varchar](255) NULL,
	[storage] [varchar](255) NULL,
	[camera_front] [varchar](255) NULL,
	[camera_rear] [varchar](255) NULL,
	[battery] [varchar](255) NULL,
	[display] [varchar](255) NULL,
	[sim] [varchar](255) NULL,
	[status] [nvarchar](255) NULL,
	[activate] [int] NULL,
	[product_cate_id] [int] NULL,
	[discount_id] [int] NULL,
	[image] [varchar](255) NULL,
	[follow] [int] NULL,
 CONSTRAINT [PK_dbo.products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[review]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[review](
	[id] [int] NOT NULL,
	[product_id] [int] NULL,
	[users_id] [int] NULL,
	[reviews] [nvarchar](4000) NULL,
 CONSTRAINT [PK_dbo.reviews] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[token]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[token](
	[id] [int] NOT NULL,
	[value] [varchar](255) NULL,
	[admin_id] [int] NULL,
 CONSTRAINT [PK_dbo.token] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] NOT NULL,
	[username] [nvarchar](255) NULL,
	[fullname] [nvarchar](255) NULL,
	[pwd] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[phone] [varchar](255) NULL,
	[image] [varchar](255) NULL,
	[activated] [int] NULL,
 CONSTRAINT [PK_dbo.users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[utoken]    Script Date: 04-Jun-20 11:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[utoken](
	[id] [int] NOT NULL,
	[value] [varchar](255) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_dbo.utoken] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[admin] ([id], [username], [pwd], [email], [address], [phone], [level], [image], [fullname]) VALUES (1, N'admin@email.com', N'21232f297a57a5a743894a0e4a801fc3', N'admin@email.com', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[admin] ([id], [username], [pwd], [email], [address], [phone], [level], [image], [fullname]) VALUES (2, N'admin@admin.com', N'21232f297a57a5a743894a0e4a801fc3', N'admin@admin.com', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (1, N'loại điện thoại', N'loại điện thoại cực xịn')
INSERT [dbo].[category] ([id], [name], [description]) VALUES (2, N'loại điện thoại 2', N'loại điện thoại cực xịn')
INSERT [dbo].[category] ([id], [name], [description]) VALUES (16, N'SAM SUNG', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (17, N'OPPO', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (18, N'MOBIISTAR', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (19, N'MOBELL', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (20, N'HUAWAI', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (21, N'HONOR', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (22, N'BPHONE', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (23, N'IPHONE', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (24, N'NOKIA', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (25, N'VSMART', NULL)
INSERT [dbo].[category] ([id], [name], [description]) VALUES (26, N'XIAOMI', NULL)
INSERT [dbo].[discount] ([id], [value], [name]) VALUES (1, N'18', N'IPHONEX')
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (1, NULL, NULL)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (3, N'/Upload/Products/4ec3fc04c73b84b61ab9e4341a364975.jpg', 1)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (4, N'/Upload/Products/8bdd29b6ef9cfe5d4639c09717d2cc5d.jpg', 1)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (5, N'/Upload/Products/8c581916dfa8923d22ce24b316413a8d.jpg', 1)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (8, N'/Upload/Products/83b5009e040969ee7b60362ad7426573.jpeg', 3)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (9, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 3)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (10, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 3)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (11, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 3)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (12, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 4)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (13, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 4)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (14, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 4)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (15, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 4)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (16, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 5)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (17, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 5)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (18, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 5)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (19, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 5)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (20, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 5)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (21, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 5)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (22, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 5)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (23, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 5)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (24, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 6)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (25, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 6)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (26, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 6)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (27, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 6)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (28, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 7)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (29, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 7)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (30, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 7)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (31, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 7)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (32, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 8)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (33, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 8)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (34, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 8)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (35, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 8)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (36, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 9)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (37, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 9)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (38, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 9)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (39, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 9)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (40, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 10)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (41, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 10)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (42, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 10)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (43, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 10)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (44, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 11)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (45, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 11)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (46, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 11)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (47, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 11)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (48, N'/Upload/Products/f3ccdd27d2000e3f9255a7e3e2c48800.jpg', 12)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (49, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 12)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (50, N'/Upload/Products/799bad5a3b514f096e69bbc4a7896cd9.jpg', 12)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (51, N'/Upload/Products/d0096ec6c83575373e3a21d129ff8fef.jpg', 12)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (52, N'/Upload/Products/4a47a0db6e60853dedfcfdf08a5ca249.png', 13)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (53, N'/Upload/Products/fb5c81ed3a220004b71069645f112867.png', 13)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (54, N'/Upload/Products/83b5009e040969ee7b60362ad7426573.jpeg', 14)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (55, N'/Upload/Products/4a47a0db6e60853dedfcfdf08a5ca249.png', 14)
INSERT [dbo].[image] ([id], [url], [product_id]) VALUES (56, N'/Upload/Products/156005c5baf40ff51a327f1c34f2975b.jpg', 14)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (8, 9, N'19490000', CAST(0x0000AA4500E4ECE4 AS DateTime), NULL, 1)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (9, 9, N'19490000', CAST(0x0000AA4500E5A883 AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (10, 9, N'19490000', CAST(0x0000AA4500E7E4FD AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (11, 9, N'19490000', CAST(0x0000AA4500F2298C AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (14, 9, N'194900000', CAST(0x0000AA450103F172 AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (15, 10, N'12380000', CAST(0x0000AA45010CD66F AS DateTime), NULL, 1)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (16, 9, N'19490000', CAST(0x0000AA4600CF5C3F AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (17, 10, N'197960000', CAST(0x0000AA4600D8F9CF AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (18, 10, N'12380000', CAST(0x0000AA4600DA03B9 AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (19, 9, N'38980000', CAST(0x0000AA4700D2C125 AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (20, 9, N'293720000', CAST(0x0000AA4E00F14BCE AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (21, 4, N'19490000', CAST(0x0000AA5600F06348 AS DateTime), NULL, 0)
INSERT [dbo].[order] ([id], [users_id], [total_money], [date_create], [method], [status]) VALUES (22, 1, N'17224844', CAST(0x0000ABD00185EC50 AS DateTime), N'COD', NULL)
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (8, 1, N'1', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (9, 1, N'1', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (10, 1, N'1', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (11, 1, N'1', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (14, 1, N'10', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (15, 6, N'2', N'6190000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (16, 1, N'1', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (17, 1, N'4', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (17, 3, N'6', N'20000000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (18, 6, N'2', N'6190000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (19, 1, N'2', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (20, 1, N'10', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (20, 5, N'18', N'5490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (21, 1, N'1', N'19490000')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (22, 2, N'2', N'2422422')
INSERT [dbo].[order_detail] ([order_id], [product_id], [quantity], [money]) VALUES (22, 6, N'2', N'6190000')
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (1, NULL, N'điện thoại 1', N'3241824vnd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, N'/Upload/Products/4ec3fc04c73b84b61ab9e4341a364975.jpg', 20)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (2, NULL, N'điện thoại 2', N'2422422vnd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 2, NULL, N'/Upload/Products/4ec3fc04c73b84b61ab9e4341a364975.jpg', 12)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (3, N'SP0002', N'IPHONEXS Max', N'20000000', N'H? tr? 4G', N'Ð?', N'NFC, OTG', N'Apple A12 Bionic 6 nhân', N'3 GB', N'64 GB', N'7 MP', N'12 MP', N'2942 mAh', N'828 x 1792 Pixels', N'nanoSim', N'Còn Hàng', 1, 23, NULL, N'/Upload/SingleProduct/8bdd29b6ef9cfe5d4639c09717d2cc5d.jpg', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (4, N'SP0003', N'Sam Sung A6', N'4190000', N'H? tr? 4G', N'Ð?', N'NFC, OTG', N'Exynos 7870 8 nhân 64-bit', N'3 GB', N'64 GB', N'16 MP', N'16 MP', N'3000 mAh', N'uper AMOLED, 5.6", HD+', N'2 Nano SIM', N'Còn Hàng', 0, 16, NULL, N'/Upload/SingleProduct/59e8961cc938cd509893316f4a7d8b19.jpg', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (5, N'SP0004', N'Sam Sung A6+', N'5490000', N'H? tr? 4G', N'Ð?', N'NFC, OTG', N'Qualcomm Snapdragon 450 8 nhân 64-bit', N'4 GB', N'32 GB', N'24 MP', N'16 MP và 5 MP (2 camera)', N'3500 mAh', N'Super AMOLED, 6", Full HD+', N'2 Nano SIM', N'Còn Hàng', 1, 16, NULL, N'/Upload/SingleProduct/8377b01c0586cce7d1e6218eb3548869.png', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (6, N'SP0005', N'Sam Sung A7', N'6190000', N'H? tr? 4G', N'Ð?', N'NFC, OTG', N'Exynos 7885 8 nhân 64-bit', N'4 GB', N'64 GB', N'24 MP', N'24 MP, 8 MP và 5 MP (3 camera)', N'3300', N'Super AMOLED, 6.0", Full HD+', N'2 Nano SIM', N'Còn Hàng', 1, 16, NULL, N'/Upload/SingleProduct/8acc50c69c41fd6553b7149d524c8a14.png', 4)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (7, N'SP0006', N'Sam Sung A8 Star', N'8290000', N'H? tr? 4G', N'Ð?', N'NFC, OTG', N'Qualcomm Snapdragon 660 8 nhân', N'4 GB', N'64 GB', N'24 MP', N'24 MP và 16 MP (2 camera)', N'3700 mAh, có s?c nhanh', N'Super AMOLED, 6.3", Full HD+', N'2 Nano SIM,', N'Còn Hàng', 1, 16, NULL, N'/Upload/SingleProduct/2c4a291407e3a127b3990bfee3a75a59.png', 1)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (8, N'SP0007', N'XIAOMI Mi8', N'12990000', N'H? tr? 4G', N'Ðen, Tr?ng, Vàng, Xanh', N'NFC, OTG', N'Snapdragon 845 8 nhân', N'6 GB', N'64 GB', N'20 MP', N'2 camera 12 MP', N'3400 mAh', N'Full HD+ (1080 x 2248 Pixels)', N'2 Nano SIM', N'Còn Hàng', 1, 26, NULL, N'/Upload/SingleProduct/43fc803f0120f214a684e995752a852c.jpg', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (9, N'SP0008', N'OPPO R17 Pro', N'15990000', N'H? tr? 4G', N'Ðen, Tr?ng, Vàng, Xanh', N'NFC, OTG', N'Snapdragon 710 8 nhân 64-bit', N'8 GB', N'128 GB', N'25 MP', N'20 MP, 12 MP và TOF 3D (3 camera)', N'3700 mAh, có s?c nhanh', N'AMOLED, 6.4", Full HD+', N'2 Nano SIM', N'Còn Hàng', 1, 17, NULL, N'/Upload/SingleProduct/c93aa8b12375abdd6cee8f77264892a6.png', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (10, N'SP0009', N'OPPO Find X', N'19990000', N'H? tr? 4G', N'Ðen, Tr?ng, Vàng, Xanh', N'NFC, OTG', N'Snapdragon 845 8 nhân', N'8 GB', N'256 GB', N'25 MP', N'20 MP và 16 MP (2 camera)', N'3730 mAh', N'AMOLED, 6.42", Full HD+', N'2 Nano SIM', N'Còn Hàng', 1, 17, NULL, N'/Upload/SingleProduct/13687cbc2ce9c92316fbc4d2aee5b1ce.jpg', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (11, N'SP0010', N'HUAWAI Y9', N'4990000', N'H? tr? 4G', N'Ðen, Tr?ng, Vàng, Xanh', N'NFC, OTG', N'HiSilicon Kirin 710', N'4 GB', N'64 GB', N'16 MP và 2 MP (2 camera)', N'16 MP và 2 MP (2 camera)', N'4000 mAh', N'LTPS LCD, 6.5", Full HD+', N'2 Nano SIM', N'Còn Hàng', 1, 20, NULL, N'/Upload/SingleProduct/4c69b9347eb89cac2245e260bb9835e7.png', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (12, N'SP0011', N'HUAWAI Mate20 PRo', N'21990000', N'H? tr? 4G', N'Ðen, Tr?ng, Vàng, Xanh', N'NFC, OTG', N'Hisilicon Kirin 980 8 nhân 64-bit', N'6 GB', N'128 GB', N'24 MP', N'40 MP, 20 MP và 8 MP (3 camera)', N'4200 mAh', N'OLED, 6.39", Quad HD+ (2K+)', N'2 SIM Nano (SIM 2 chung khe th? nh?)', N'Còn Hàng', 1, 20, NULL, N'/Upload/SingleProduct/f93d0c9440e9833342154b38683dc8f9.png', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (13, N'SP0012', N'HONOR 10', N'9990000', N'H? tr? 4G', N'Ðen, Tr?ng, Vàng, Xanh', N'NFC, OTG', N'Hisilicon Kirin 970 , 8 nhân, 4 nhân 2.4 GHz Cortex-A73 & 4 nhân 1.8 GHz ', N'4 GB', N'128 GB', N'24 MP', N'24 MP và 16 MP', N'3400 mAh', N'5.84", 1080 x 2280 pixels', N'Nano SIM, 2 Sim', N'Còn Hàng', 1, 21, NULL, N'/Upload/SingleProduct/027b6247f712eac84d9fc73d7fb85aec.jpg', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (14, N'SP0013', N'HONOR 10 Lite', N'5290000', N'H? tr? 4G', N'Ðen, Tr?ng, Vàng, Xanh', N'NFC, OTG', N'Hisilicon Kirin 710, 8, 4 x 2.2 GHz & 4 x 1.7 GHz', N'3 GB', N'64 GB', N'24.0 MP', N'13.0 MP + 2.0 MP', N'3400 mAh', N'6.21 inches, 1080 x 2340 Pixels', N'2 SIM Nano (SIM 2 chung khe th? nh?)', N'Còn Hàng', 1, 21, NULL, N'/Upload/SingleProduct/d55a0a8e70387956ad1043f29c2a3624.jpg', NULL)
INSERT [dbo].[product] ([id], [sku], [name], [price], [Ghz], [color], [sensor], [cpu], [ram], [storage], [camera_front], [camera_rear], [battery], [display], [sim], [status], [activate], [product_cate_id], [discount_id], [image], [follow]) VALUES (15, N'11', N'Iphone', N'30.000.000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 23, NULL, N'/Upload/SingleProduct/55ccf27d26d7b23839986b6ae2e447ab.jpg', NULL)
INSERT [dbo].[user] ([id], [username], [fullname], [pwd], [email], [address], [phone], [image], [activated]) VALUES (1, N'admin1', N'người dùng 1', N'21232f297a57a5a743894a0e4a801fc3', N'nguoidung@email.com', N'hà nội, việt nam', N'03444447777', N'/Upload/Users/35639cdbb53d33b1bd6c45a37916cc29.jpg', 1)
INSERT [dbo].[user] ([id], [username], [fullname], [pwd], [email], [address], [phone], [image], [activated]) VALUES (4, N'FallenMax', N'Vũ Việt Anh Tuấn ', N'15f8182445bac21b05802649a8a698e7', N'fallen.9x@gmail.com', N'Bắc Giang ', N'0386147455', N'/Upload/Users/1b360dc6d1e366c0d79c8f6525ec0317.png', 1)
INSERT [dbo].[user] ([id], [username], [fullname], [pwd], [email], [address], [phone], [image], [activated]) VALUES (8, N'Cún con', N'Cún Con', N'15f8182445bac21b05802649a8a698e7', N'fallen.9x@gmail.com', N'Bac Giang ', N'0386147455', N'/Upload/Users/06dcebd9f90705c52ddeffd39dd035df.jpg', 1)
INSERT [dbo].[user] ([id], [username], [fullname], [pwd], [email], [address], [phone], [image], [activated]) VALUES (9, N'AnhTuan', N'Vũ Việt Anh Tuấn ', N'15f8182445bac21b05802649a8a698e7', N'fallen.9x@gmail.com', N'Bắc Giang ', N'0386147455', N'/Upload/Users/3c2d870755289c9d7565801ee055e558.jpg', 1)
INSERT [dbo].[user] ([id], [username], [fullname], [pwd], [email], [address], [phone], [image], [activated]) VALUES (10, N'SoiCon', N'Trần Thị Ngọc Ánh', N'5d2820b1582e8a66f55bd0317c4f0008', N'soiconhd1998@gmail.com', N'Hải Dương', N'0335154259', N'/Upload/Users/06dcebd9f90705c52ddeffd39dd035df.jpg', 1)
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_comments_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comments_products]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_comments_users] FOREIGN KEY([users_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comments_users]
GO
ALTER TABLE [dbo].[image]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_orders_users] FOREIGN KEY([users_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_orders_users]
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD  CONSTRAINT [FK__order_det__order__3B75D760] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[order_detail] CHECK CONSTRAINT [FK__order_det__order__3B75D760]
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD  CONSTRAINT [FK__order_det__produ__3C69FB99] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[order_detail] CHECK CONSTRAINT [FK__order_det__produ__3C69FB99]
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD  CONSTRAINT [FK__posts__product_i__3F466844] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [FK__posts__product_i__3F466844]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([discount_id])
REFERENCES [dbo].[discount] ([id])
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_products_category] FOREIGN KEY([product_cate_id])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_products_category]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK__reviews__users_i__45F365D3] FOREIGN KEY([users_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK__reviews__users_i__45F365D3]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_reviews_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_reviews_products]
GO
ALTER TABLE [dbo].[token]  WITH CHECK ADD  CONSTRAINT [FK_token_admin] FOREIGN KEY([admin_id])
REFERENCES [dbo].[admin] ([id])
GO
ALTER TABLE [dbo].[token] CHECK CONSTRAINT [FK_token_admin]
GO
ALTER TABLE [dbo].[utoken]  WITH CHECK ADD  CONSTRAINT [FK_utoken_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[utoken] CHECK CONSTRAINT [FK_utoken_users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'level phan quyen admin' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'admin', @level2type=N'COLUMN',@level2name=N'level'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'3G, 4G, 5G' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product', @level2type=N'COLUMN',@level2name=N'Ghz'
GO
USE [master]
GO
ALTER DATABASE [Store] SET  READ_WRITE 
GO
