USE [master]
GO
/****** Object:  Database [World]    Script Date: 10/5/2015 3:35:47 PM ******/
CREATE DATABASE [World]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'World', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\World.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'World_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\World_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [World] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [World].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [World] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [World] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [World] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [World] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [World] SET ARITHABORT OFF 
GO
ALTER DATABASE [World] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [World] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [World] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [World] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [World] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [World] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [World] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [World] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [World] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [World] SET  DISABLE_BROKER 
GO
ALTER DATABASE [World] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [World] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [World] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [World] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [World] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [World] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [World] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [World] SET RECOVERY FULL 
GO
ALTER DATABASE [World] SET  MULTI_USER 
GO
ALTER DATABASE [World] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [World] SET DB_CHAINING OFF 
GO
ALTER DATABASE [World] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [World] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [World] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'World', N'ON'
GO
USE [World]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 10/5/2015 3:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](250) NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 10/5/2015 3:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 10/5/2015 3:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 10/5/2015 3:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 10/5/2015 3:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [AddressText], [TownId]) VALUES (1, N'бул. Мария Луиза 5', 1)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([Id], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([Id], [Name]) VALUES (2, N'Africa')
INSERT [dbo].[Continent] ([Id], [Name]) VALUES (3, N'Asia')
INSERT [dbo].[Continent] ([Id], [Name]) VALUES (4, N'North America')
INSERT [dbo].[Continent] ([Id], [Name]) VALUES (5, N' South America')
INSERT [dbo].[Continent] ([Id], [Name]) VALUES (6, N'Antarctica')
INSERT [dbo].[Continent] ([Id], [Name]) VALUES (7, N'Australia')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name], [ContinentId]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([Id], [Name], [ContinentId]) VALUES (2, N'Serbia', 1)
INSERT [dbo].[Country] ([Id], [Name], [ContinentId]) VALUES (4, N'Romania', 1)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [AddressId]) VALUES (1, N'Петър', N'Петров', 1)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([Id], [Name], [CountryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([Id], [Name], [CountryId]) VALUES (2, N'Belgrad', 2)
INSERT [dbo].[Town] ([Id], [Name], [CountryId]) VALUES (4, N'Bukuresht', 4)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([TownId])
REFERENCES [dbo].[Town] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continent] ([Id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [World] SET  READ_WRITE 
GO
