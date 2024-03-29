USE [master]
GO
/****** Object:  Database [EmployeeManagement]    Script Date: 25/02/2024 22:35:58 ******/
CREATE DATABASE [EmployeeManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EmployeeManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EmployeeManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EmployeeManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeManagement] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeManagement', N'ON'
GO
ALTER DATABASE [EmployeeManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [EmployeeManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EmployeeManagement]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 25/02/2024 22:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 25/02/2024 22:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserNo] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Salary] [int] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Role_Id] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary]    Script Date: 25/02/2024 22:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Month] [varchar](50) NOT NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 25/02/2024 22:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Content] [varchar](50) NULL,
	[StartDate] [date] NULL,
	[DeliveryDate] [date] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Name]) VALUES (1, N'VinHome')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (2, N'FSoft')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (3, N'Department3')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (4, N'FPT')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [UserNo], [Name], [DepartmentID], [Salary], [Address], [Password], [Role_Id]) VALUES (1, 1, N'Minh Phuc', 1, 4000, N'VietNam', N'123', 1)
INSERT [dbo].[Employees] ([Id], [UserNo], [Name], [DepartmentID], [Salary], [Address], [Password], [Role_Id]) VALUES (2, 2, N'Minh', 2, 2000, N'VietNam', N'123', 2)
INSERT [dbo].[Employees] ([Id], [UserNo], [Name], [DepartmentID], [Salary], [Address], [Password], [Role_Id]) VALUES (3, 3, N'Phuc', 1, 1500, N'VietNam

', N'123', 1)
INSERT [dbo].[Employees] ([Id], [UserNo], [Name], [DepartmentID], [Salary], [Address], [Password], [Role_Id]) VALUES (11, 4, N'Quan', 1, 1000, N'FPT

', N'12345', 3)
INSERT [dbo].[Employees] ([Id], [UserNo], [Name], [DepartmentID], [Salary], [Address], [Password], [Role_Id]) VALUES (13, 5, N'An', 3, 1234, N'Q9

', N'123', 3)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Salary] ON 

INSERT [dbo].[Salary] ([Id], [EmployeeID], [Amount], [Month], [Year]) VALUES (1, 3, 1500, N'December', 2023)
INSERT [dbo].[Salary] ([Id], [EmployeeID], [Amount], [Month], [Year]) VALUES (2, 3, 1500, N'February', 2024)
INSERT [dbo].[Salary] ([Id], [EmployeeID], [Amount], [Month], [Year]) VALUES (3, 2, 2000, N'December', 2023)
INSERT [dbo].[Salary] ([Id], [EmployeeID], [Amount], [Month], [Year]) VALUES (4, 2, 2000, N'February', 2024)
INSERT [dbo].[Salary] ([Id], [EmployeeID], [Amount], [Month], [Year]) VALUES (5, 11, 1000, N'January', 2024)
INSERT [dbo].[Salary] ([Id], [EmployeeID], [Amount], [Month], [Year]) VALUES (6, 13, 1234, N'January', 2024)
SET IDENTITY_INSERT [dbo].[Salary] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Id], [EmployeeID], [Title], [Content], [StartDate], [DeliveryDate]) VALUES (1, 3, N'WPF APP', N'Create WPF application has 4 functions', CAST(N'2024-02-24' AS Date), CAST(N'2024-03-02' AS Date))
INSERT [dbo].[Task] ([Id], [EmployeeID], [Title], [Content], [StartDate], [DeliveryDate]) VALUES (3, 3, N'WPF APP', N'WPF Coffee Shop has 4 functions', CAST(N'2024-02-24' AS Date), CAST(N'2024-03-02' AS Date))
INSERT [dbo].[Task] ([Id], [EmployeeID], [Title], [Content], [StartDate], [DeliveryDate]) VALUES (4, 11, N'WPF', N'Create A WPF APP', CAST(N'2024-02-24' AS Date), CAST(N'2024-03-02' AS Date))
INSERT [dbo].[Task] ([Id], [EmployeeID], [Title], [Content], [StartDate], [DeliveryDate]) VALUES (5, 13, N'Threads', N'Create a clock ', CAST(N'2024-02-24' AS Date), CAST(N'2024-03-02' AS Date))
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Department]
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [FK_Salary_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [FK_Salary_Employee]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Employee]
GO
USE [master]
GO
ALTER DATABASE [EmployeeManagement] SET  READ_WRITE 
GO
