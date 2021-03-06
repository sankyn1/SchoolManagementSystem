USE [master]
GO
/****** Object:  Database [InstituteManagement]    Script Date: 4/28/2019 10:22:41 PM ******/
CREATE DATABASE [InstituteManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InstituteManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2014\MSSQL\DATA\InstituteManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'InstituteManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2014\MSSQL\DATA\InstituteManagement_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [InstituteManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InstituteManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InstituteManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InstituteManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InstituteManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InstituteManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InstituteManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [InstituteManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InstituteManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [InstituteManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InstituteManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InstituteManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InstituteManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InstituteManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InstituteManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InstituteManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InstituteManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InstituteManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InstituteManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InstituteManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InstituteManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InstituteManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InstituteManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InstituteManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InstituteManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InstituteManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [InstituteManagement] SET  MULTI_USER 
GO
ALTER DATABASE [InstituteManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InstituteManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InstituteManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InstituteManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'InstituteManagement', N'ON'
GO
USE [InstituteManagement]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 4/28/2019 10:22:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[cities](
	[id] [int] NOT NULL,
	[name] [varchar](30) NOT NULL,
	[state_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[countries]    Script Date: 4/28/2019 10:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[countries](
	[id] [int] NOT NULL,
	[sortname] [varchar](3) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[phonecode] [int] NOT NULL,
 CONSTRAINT [PK__countrie__3213E83F8A514D4C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseMaster]    Script Date: 4/28/2019 10:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CourseMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymodeMaster]    Script Date: 4/28/2019 10:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymodeMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PaymodeMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[states]    Script Date: 4/28/2019 10:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[states](
	[id] [int] NOT NULL,
	[name] [varchar](30) NOT NULL,
	[country_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentMaster]    Script Date: 4/28/2019 10:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Mobile] [varchar](15) NULL,
	[Address] [nvarchar](200) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [int] NULL,
	[Pin] [varchar](6) NULL,
 CONSTRAINT [PK_StudentMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UniversityMaster]    Script Date: 4/28/2019 10:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UniversityMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_UniversityMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 4/28/2019 10:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[RoleId] [int] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[states] ADD  DEFAULT ('1') FOR [country_id]
GO
ALTER TABLE [dbo].[cities]  WITH CHECK ADD  CONSTRAINT [FK_cities_states] FOREIGN KEY([state_id])
REFERENCES [dbo].[states] ([id])
GO
ALTER TABLE [dbo].[cities] CHECK CONSTRAINT [FK_cities_states]
GO
ALTER TABLE [dbo].[states]  WITH CHECK ADD  CONSTRAINT [FK_states_countries] FOREIGN KEY([country_id])
REFERENCES [dbo].[countries] ([id])
GO
ALTER TABLE [dbo].[states] CHECK CONSTRAINT [FK_states_countries]
GO
ALTER TABLE [dbo].[StudentMaster]  WITH CHECK ADD  CONSTRAINT [FK_StudentMaster_cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[cities] ([id])
GO
ALTER TABLE [dbo].[StudentMaster] CHECK CONSTRAINT [FK_StudentMaster_cities]
GO
ALTER TABLE [dbo].[StudentMaster]  WITH CHECK ADD  CONSTRAINT [FK_StudentMaster_countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[countries] ([id])
GO
ALTER TABLE [dbo].[StudentMaster] CHECK CONSTRAINT [FK_StudentMaster_countries]
GO
ALTER TABLE [dbo].[StudentMaster]  WITH CHECK ADD  CONSTRAINT [FK_StudentMaster_states] FOREIGN KEY([StateId])
REFERENCES [dbo].[states] ([id])
GO
ALTER TABLE [dbo].[StudentMaster] CHECK CONSTRAINT [FK_StudentMaster_states]
GO
USE [master]
GO
ALTER DATABASE [InstituteManagement] SET  READ_WRITE 
GO
