USE [master]
GO
/****** Object:  Database [School-Journal-App-DB]    Script Date: 28.12.2020 9:52:54 ******/
CREATE DATABASE [School-Journal-App-DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'School-Journal-App-DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\School-Journal-App-DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'School-Journal-App-DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\School-Journal-App-DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [School-Journal-App-DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [School-Journal-App-DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [School-Journal-App-DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [School-Journal-App-DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [School-Journal-App-DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [School-Journal-App-DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [School-Journal-App-DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [School-Journal-App-DB] SET  MULTI_USER 
GO
ALTER DATABASE [School-Journal-App-DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [School-Journal-App-DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [School-Journal-App-DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [School-Journal-App-DB] SET TARGET_RECOVERY_TIME = 0 SECONDS  
GO
EXEC sys.sp_db_vardecimal_storage_format N'School-Journal-App-DB', N'ON'
GO
USE [School-Journal-App-DB]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 28.12.2020 9:52:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groups](
	[group_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_groups] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marks]    Script Date: 28.12.2020 9:52:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marks](
	[mark_id] [int] IDENTITY(1,1) NOT NULL,
	[mark] [varchar](50) NULL,
	[student_login] [nvarchar](50) NOT NULL,
	[item_id] [int] NOT NULL,
 CONSTRAINT [PK_marks] PRIMARY KEY CLUSTERED 
(
	[mark_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subject_item]    Script Date: 28.12.2020 9:52:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subject_item](
	[item_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[date] [date] NOT NULL,
	[comment] [varchar](50) NOT NULL,
	[max_mark] [int] NOT NULL,
	[files] [varchar](50) NULL,
	[subject_id] [int] NOT NULL,
 CONSTRAINT [PK_subject_item] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subjects]    Script Date: 28.12.2020 9:52:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subjects](
	[subject_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[teacher_id] [nvarchar](50) NOT NULL,
	[group_id] [int] NOT NULL,
 CONSTRAINT [PK_subjects] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 28.12.2020 9:52:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[middle_name] [nvarchar](50) NULL,
	[birthday] [date] NOT NULL,
	[group_id] [int] NULL,
	[user_photo] [image] NULL,
	[email] [nvarchar](50) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[role] [int] NOT NULL,
 CONSTRAINT [PK_users_1] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[marks]  WITH CHECK ADD  CONSTRAINT [FK_marks_items] FOREIGN KEY([item_id])
REFERENCES [dbo].[subject_item] ([item_id])
GO
ALTER TABLE [dbo].[marks] CHECK CONSTRAINT [FK_marks_items]
GO
ALTER TABLE [dbo].[marks]  WITH CHECK ADD  CONSTRAINT [FK_marks_users] FOREIGN KEY([student_login])
REFERENCES [dbo].[users] ([login])
GO
ALTER TABLE [dbo].[marks] CHECK CONSTRAINT [FK_marks_users]
GO
ALTER TABLE [dbo].[subject_item]  WITH CHECK ADD  CONSTRAINT [FK_subject_item_subjects] FOREIGN KEY([subject_id])
REFERENCES [dbo].[subjects] ([subject_id])
GO
ALTER TABLE [dbo].[subject_item] CHECK CONSTRAINT [FK_subject_item_subjects]
GO
ALTER TABLE [dbo].[subjects]  WITH CHECK ADD  CONSTRAINT [FK_subjects_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[groups] ([group_id])
GO
ALTER TABLE [dbo].[subjects] CHECK CONSTRAINT [FK_subjects_groups]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[groups] ([group_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_groups]
GO
USE [master]
GO
ALTER DATABASE [School-Journal-App-DB] SET  READ_WRITE 
GO
