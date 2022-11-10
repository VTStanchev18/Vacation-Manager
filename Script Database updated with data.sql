USE [master]
GO
/****** Object:  Database [Vacation Manager]    Script Date: 10.11.2022 г. 22:06:44 ******/
CREATE DATABASE [Vacation Manager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vacation Manager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Vacation Manager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Vacation Manager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Vacation Manager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Vacation Manager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vacation Manager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vacation Manager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vacation Manager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vacation Manager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vacation Manager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vacation Manager] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vacation Manager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Vacation Manager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vacation Manager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vacation Manager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vacation Manager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vacation Manager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vacation Manager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vacation Manager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vacation Manager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vacation Manager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Vacation Manager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vacation Manager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vacation Manager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vacation Manager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vacation Manager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vacation Manager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Vacation Manager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vacation Manager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Vacation Manager] SET  MULTI_USER 
GO
ALTER DATABASE [Vacation Manager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vacation Manager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vacation Manager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vacation Manager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Vacation Manager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Vacation Manager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Vacation Manager] SET QUERY_STORE = OFF
GO
USE [Vacation Manager]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 10.11.2022 г. 22:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[TeamId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 10.11.2022 г. 22:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[ProjectId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10.11.2022 г. 22:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
	[TeamId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTeam]    Script Date: 10.11.2022 г. 22:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTeam](
	[LeaderId] [int] NOT NULL,
	[UserId] [int] NULL,
	[TeamId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacation]    Script Date: 10.11.2022 г. 22:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacation](
	[Id] [int] NOT NULL,
	[BeggingDate] [date] NULL,
	[EndingDate] [date] NULL,
	[DateOfCreation] [date] NULL,
	[HalfDay] [bit] NULL,
	[Approved] [bit] NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_TeamId]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_ProjectId]
GO
ALTER TABLE [dbo].[UserTeam]  WITH CHECK ADD FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[UserTeam]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Vacation]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Vacation Manager] SET  READ_WRITE 
GO
