USE [master]
GO
/****** Object:  Database [AcademyFitnessMusaeva]    Script Date: 11.02.2022 2:14:04 ******/
CREATE DATABASE [AcademyFitnessMusaeva]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AcademyFitnessAliev', FILENAME = N'C:\dataBases\AcademyFitnessAliev.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AcademyFitnessAliev_log', FILENAME = N'C:\dataBases\AcademyFitnessAliev_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AcademyFitnessMusaeva].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET ARITHABORT OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET  MULTI_USER 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET QUERY_STORE = OFF
GO
USE [AcademyFitnessMusaeva]
GO
/****** Object:  User [MMSS\Admin]    Script Date: 11.02.2022 2:14:04 ******/
CREATE USER [MMSS\Admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[CourseRegistration]    Script Date: 11.02.2022 2:14:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainerId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[IsDone] [bit] NOT NULL,
	[TotalPoint] [int] NOT NULL,
	[CertificateImage] [image] NULL,
	[Comment] [nvarchar](100) NULL,
 CONSTRAINT [PK_CourseRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 11.02.2022 2:14:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 11.02.2022 2:14:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[CallNumber] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CourseRegistration] ON 

INSERT [dbo].[CourseRegistration] ([Id], [TrainerId], [CourseId], [CreatedDate], [IsDone], [TotalPoint], [CertificateImage], [Comment]) VALUES (3, 4, 1, CAST(N'2021-12-21' AS Date), 1, 30, NULL, NULL)
INSERT [dbo].[CourseRegistration] ([Id], [TrainerId], [CourseId], [CreatedDate], [IsDone], [TotalPoint], [CertificateImage], [Comment]) VALUES (4, 5, 2, CAST(N'2021-12-12' AS Date), 0, 50, NULL, NULL)
INSERT [dbo].[CourseRegistration] ([Id], [TrainerId], [CourseId], [CreatedDate], [IsDone], [TotalPoint], [CertificateImage], [Comment]) VALUES (5, 1, 5, CAST(N'2021-12-14' AS Date), 1, 60, NULL, N'')
INSERT [dbo].[CourseRegistration] ([Id], [TrainerId], [CourseId], [CreatedDate], [IsDone], [TotalPoint], [CertificateImage], [Comment]) VALUES (6, 2, 3, CAST(N'2021-12-15' AS Date), 1, 70, NULL, NULL)
INSERT [dbo].[CourseRegistration] ([Id], [TrainerId], [CourseId], [CreatedDate], [IsDone], [TotalPoint], [CertificateImage], [Comment]) VALUES (7, 3, 2, CAST(N'0001-01-01' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[CourseRegistration] ([Id], [TrainerId], [CourseId], [CreatedDate], [IsDone], [TotalPoint], [CertificateImage], [Comment]) VALUES (8, 3, 2, CAST(N'0001-01-01' AS Date), 0, 0, NULL, NULL)
INSERT [dbo].[CourseRegistration] ([Id], [TrainerId], [CourseId], [CreatedDate], [IsDone], [TotalPoint], [CertificateImage], [Comment]) VALUES (10, 1, 2, CAST(N'0001-01-03' AS Date), 0, 10, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CourseRegistration] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Title]) VALUES (1, N'Пилатес')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (2, N'Аэробика')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (3, N'Стретчинг')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (4, N'Детская гимнастика')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (5, N'Калланетика')
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainers] ON 

INSERT [dbo].[Trainers] ([Id], [Name], [Surname], [CallNumber]) VALUES (1, N'Аминат', N'Абдулазизова', N'89632229984')
INSERT [dbo].[Trainers] ([Id], [Name], [Surname], [CallNumber]) VALUES (2, N'Альбина', N'Назарлиева', N'89035564484')
INSERT [dbo].[Trainers] ([Id], [Name], [Surname], [CallNumber]) VALUES (3, N'Галимат', N'Куратова', N'88725554444')
INSERT [dbo].[Trainers] ([Id], [Name], [Surname], [CallNumber]) VALUES (4, N'Ирина', N'Гаджиева', N'89285554452')
INSERT [dbo].[Trainers] ([Id], [Name], [Surname], [CallNumber]) VALUES (5, N'Гульбахар', N'Саркисова', N'89885784128')
SET IDENTITY_INSERT [dbo].[Trainers] OFF
GO
ALTER TABLE [dbo].[CourseRegistration]  WITH CHECK ADD  CONSTRAINT [FK_CourseRegistration_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CourseRegistration] CHECK CONSTRAINT [FK_CourseRegistration_Course]
GO
ALTER TABLE [dbo].[CourseRegistration]  WITH CHECK ADD  CONSTRAINT [FK_CourseRegistration_Trainers] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainers] ([Id])
GO
ALTER TABLE [dbo].[CourseRegistration] CHECK CONSTRAINT [FK_CourseRegistration_Trainers]
GO
USE [master]
GO
ALTER DATABASE [AcademyFitnessMusaeva] SET  READ_WRITE 
GO
