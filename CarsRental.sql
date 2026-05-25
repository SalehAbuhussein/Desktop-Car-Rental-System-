USE [master]
GO
/****** Object:  Database [CarsRentalSystem]    Script Date: 5/25/2026 11:19:36 PM ******/
CREATE DATABASE [CarsRentalSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarsRentalSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CarsRentalSystem.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarsRentalSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CarsRentalSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CarsRentalSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarsRentalSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarsRentalSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarsRentalSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarsRentalSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarsRentalSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarsRentalSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [CarsRentalSystem] SET  MULTI_USER 
GO
ALTER DATABASE [CarsRentalSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarsRentalSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarsRentalSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarsRentalSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarsRentalSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarsRentalSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CarsRentalSystem', N'ON'
GO
ALTER DATABASE [CarsRentalSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [CarsRentalSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CarsRentalSystem]
GO
/****** Object:  Table [dbo].[CarRentalPayments]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRentalPayments](
	[CarRentalPaymentID] [int] IDENTITY(1,1) NOT NULL,
	[CarRentalID] [int] NOT NULL,
	[PaymentID] [int] NOT NULL,
	[PaidAmount] [decimal](10, 2) NOT NULL,
	[Status] [nvarchar](9) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarRentalPaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarID] [int] IDENTITY(1,1) NOT NULL,
	[CarName] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](255) NULL,
	[VIN] [nvarchar](17) NOT NULL,
	[PlateNumber] [nvarchar](11) NOT NULL,
	[Mileage] [int] NOT NULL,
	[PricePerDay] [decimal](18, 0) NOT NULL,
	[Active] [bit] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[ModelID] [int] NOT NULL,
	[YearID] [int] NOT NULL,
	[FuelTypeID] [int] NOT NULL,
	[TransmissionID] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedByID] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK__Cars__68A0340ED4CE06C9] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Cars__036926248798F78B] UNIQUE NONCLUSTERED 
(
	[PlateNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Cars__C5DF234C6C9D228E] UNIQUE NONCLUSTERED 
(
	[VIN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[LicenseNumber] [nvarchar](30) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK__Customer__A4AE64B8BDDC1D80] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Customer__AA2FFB840AC981D3] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Secondname] [nvarchar](50) NOT NULL,
	[Thirdname] [nvarchar](50) NULL,
	[NationalNo] [nvarchar](20) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK__People__AA2FFB854F808C24] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NationalNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarRentals]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRentals](
	[CarRentalID] [int] IDENTITY(1,1) NOT NULL,
	[CarID] [int] NOT NULL,
	[CustomerID] [int] NULL,
	[Deposit] [decimal](10, 2) NOT NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[PickupLocation] [nvarchar](30) NOT NULL,
	[PickupDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	[PricePerDaySnapshot] [decimal](18, 0) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK__CarRenta__99A2D3DC7BCBB2A2] PRIMARY KEY CLUSTERED 
(
	[CarRentalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[carRental_view]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE VIEW [dbo].[carRental_view]
AS

SELECT
	CR.CarRentalID,
	CustomerName = CONCAT_WS(' ', P.Firstname, P.Secondname, P.Thirdname, P.Lastname),
	P.NationalNo,
	C.CarName,
	C.PricePerDay,
	CR.PickupDate,
	CR.ReturnDate,
	CR.Status,
	TotalPaidAmount = SUM(CRP.PaidAmount)
FROM CarRentals CR
INNER JOIN Cars C ON CR.CarID = C.CarID
INNER JOIN CarRentalPayments CRP ON CR.CarRentalID = CRP.CarRentalID
INNER JOIN Customers CC ON CR.CustomerID = CC.CustomerID
INNER JOIN People P ON CC.PersonID = P.PersonID
GROUP BY
    CR.CarRentalID,
    C.CarName,
	CONCAT_WS(' ', P.Firstname, P.Secondname, P.Thirdname, P.Lastname),
	P.NationalNo,
	C.PricePerDay,
    CR.PickupDate,
    CR.ReturnDate,
    CR.Status

GO
/****** Object:  View [dbo].[CustomersView]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CustomersView] AS
(
	SELECT
		C.CustomerID,
		CustomerName = CONCAT_WS(' ', P.Firstname, P.Secondname, P.Thirdname, P.Lastname),
		NationalNo
	FROM Customers C
	INNER JOIN People P ON C.PersonID = P.PersonID
)
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK__Payments__9B556A58A3554087] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[rentalPaymentsView]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[rentalPaymentsView]
AS
SELECT 
	CRP.CarRentalPaymentID,
	CR.CarRentalID,
	CustomerName = CONCAT_WS(' ', PP.Firstname, PP.Lastname),
	Amount = P.Amount,
	Type = CRP.Status,
	CR.Status,
	P.CreatedAt
FROM CarRentalPayments CRP
INNER JOIN Payments P ON CRP.PaymentID = P.PaymentID
INNER JOIN CarRentals CR ON CRP.CarRentalID = CR.CarRentalID
INNER JOIN Customers C ON CR.CustomerID = C.CustomerID
INNER JOIN People PP ON C.PersonID = PP.PersonID
GO
/****** Object:  View [dbo].[StudentView]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[StudentView] AS
SELECT P.StudentID, P.Name, P.Address, A.Course, A.Grade
FROM PersonalInfo P
JOIN AcademicInfo A ON P.StudentID = A.StudentID;

GO
/****** Object:  Table [dbo].[FuelTypes]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelTypes](
	[FuelTypeID] [int] IDENTITY(1,1) NOT NULL,
	[FuelType] [nvarchar](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FuelTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FuelType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Makes]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Makes](
	[MakeID] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK__Makes__43646F318CC698DE] PRIMARY KEY CLUSTERED 
(
	[MakeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[ModelID] [int] IDENTITY(1,1) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[MakeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalReturns]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalReturns](
	[RentalReturnID] [int] IDENTITY(1,1) NOT NULL,
	[CarRentalID] [int] NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RentalReturnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CarRentalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](65) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK__Roles__8AFACE3A8DA8D8EA] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Roles__8A2B61602687C2C2] UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transmissions]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transmissions](
	[TransmissionID] [int] IDENTITY(1,1) NOT NULL,
	[Transmission] [nvarchar](9) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransmissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](225) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK__Users__1788CCAC664468B6] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Users__536C85E478E38940] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Users__AA2FFB84115F04F8] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Years]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Years](
	[YearID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[YearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarRentals] ADD  CONSTRAINT [DF_CarRentals_Status]  DEFAULT ('Active') FOR [Status]
GO
ALTER TABLE [dbo].[CarRentals] ADD  CONSTRAINT [DF__CarRental__Creat__603D47BB]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CarRentals] ADD  CONSTRAINT [DF__CarRental__Updat__61316BF4]  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF__Cars__Active__75A278F5]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [df_Cars_IsAvailable]  DEFAULT ((1)) FOR [IsAvailable]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF__Cars__Status__2CBDA3B5]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF__Cars__CreatedAt__245D67DE]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF__Cars__UpdatedAt__25518C17]  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF__Customers__Creat__3D7E1B63]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [df_customers_active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Makes] ADD  CONSTRAINT [DF__Makes__Active__70DDC3D8]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Payments] ADD  CONSTRAINT [DF__Payments__Create__3DE82FB7]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[RentalReturns] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [df_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Active__440B1D61]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[CarRentalPayments]  WITH CHECK ADD  CONSTRAINT [fk_CarRentalPayments_CarRentalID] FOREIGN KEY([CarRentalID])
REFERENCES [dbo].[CarRentals] ([CarRentalID])
GO
ALTER TABLE [dbo].[CarRentalPayments] CHECK CONSTRAINT [fk_CarRentalPayments_CarRentalID]
GO
ALTER TABLE [dbo].[CarRentalPayments]  WITH CHECK ADD  CONSTRAINT [fk_CarRentalPayments_PaymentID] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payments] ([PaymentID])
GO
ALTER TABLE [dbo].[CarRentalPayments] CHECK CONSTRAINT [fk_CarRentalPayments_PaymentID]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [fk_CarRentals_CarID] FOREIGN KEY([CarID])
REFERENCES [dbo].[Cars] ([CarID])
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [fk_CarRentals_CarID]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [fk_CarRentals_CreatedByUserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [fk_CarRentals_CreatedByUserID]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [fk_CarRentals_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [fk_CarRentals_Customers]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [fk_Customer_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [fk_Customer_PersonID]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [fk_Models_MakeID] FOREIGN KEY([MakeID])
REFERENCES [dbo].[Makes] ([MakeID])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [fk_Models_MakeID]
GO
ALTER TABLE [dbo].[RentalReturns]  WITH CHECK ADD  CONSTRAINT [fk_RentalReturns_CarRentalID] FOREIGN KEY([CarRentalID])
REFERENCES [dbo].[CarRentals] ([CarRentalID])
GO
ALTER TABLE [dbo].[RentalReturns] CHECK CONSTRAINT [fk_RentalReturns_CarRentalID]
GO
ALTER TABLE [dbo].[RentalReturns]  WITH CHECK ADD  CONSTRAINT [fk_RentalReturns_CreatedByUserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[RentalReturns] CHECK CONSTRAINT [fk_RentalReturns_CreatedByUserID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [fk_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [fk_Person]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [fk_Users_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [fk_Users_RoleID]
GO
ALTER TABLE [dbo].[CarRentalPayments]  WITH CHECK ADD CHECK  (([Status]='Return' OR [Status]='Extension' OR [Status]='Initial'))
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [chk_PickupDates] CHECK  (([ReturnDate]>[PickupDate]))
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [chk_PickupDates]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [chk_ReturnDates] CHECK  (([PickupDate]<[ReturnDate]))
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [chk_ReturnDates]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [CK__CarRental__Depos__5D60DB10] CHECK  (([Deposit]>(0)))
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [CK__CarRental__Depos__5D60DB10]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [CK__CarRental__Statu__69C6B1F5] CHECK  (([Status]='Completed' OR [Status]='Active'))
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [CK__CarRental__Statu__69C6B1F5]
GO
ALTER TABLE [dbo].[CarRentals]  WITH CHECK ADD  CONSTRAINT [CK__CarRental__Total__5E54FF49] CHECK  (([TotalPrice]>(0)))
GO
ALTER TABLE [dbo].[CarRentals] CHECK CONSTRAINT [CK__CarRental__Total__5E54FF49]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [chk_paymentMethod] CHECK  (([PaymentMethod]='Mobile Wallet' OR [PaymentMethod]='Bank Transfer' OR [PaymentMethod]='Card' OR [PaymentMethod]='Cash'))
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [chk_paymentMethod]
GO
/****** Object:  StoredProcedure [dbo].[createRentalRecord]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[createRentalRecord]
(
	@CarID INT,
	@Deposit INT,
	@InitialPayment DECIMAL(10, 2) = NULL,
	@PaymentMethod NVARCHAR(50) = 'Cash',
	@PickupLocation NVARCHAR(30),
	@PickupDate DATETIME,
	@ReturnDate DATETIME,
	@UserID INT,
	@CustomerID INT,
	@CarRentalID INT OUT
)
AS
BEGIN
	--DECLARE @PricePerDay
	DECLARE @TotalRentDays INT = ABS(DATEDIFF(day, @PickupDate, @ReturnDate));
	DECLARE @PricePerDay DECIMAL;

	SELECT @PricePerDay = PricePerDay FROM Cars WHERE CarID = @CarID;

	DECLARE @TotalPrice DECIMAL(10, 2) = @TotalRentDays * @PricePerDay;
	DECLARE @PaymentID INT = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;

		UPDATE Cars
		SET IsAvailable = 0
		WHERE CarID = @CarID;

		-- Create Initial Payment Record
		IF (@InitialPayment IS NOT NULL)
			BEGIN

				INSERT INTO [dbo].[Payments]
						   ([Amount]
						   ,[PaymentMethod])
					 VALUES
						   (@InitialPayment
						   ,@PaymentMethod);

				SET @PaymentID = SCOPE_IDENTITY();
			END

		INSERT INTO [dbo].[CarRentals]
				   ([CarID]
				   ,[Deposit]
				   ,[TotalPrice]
				   ,[PickupLocation]
				   ,[PickupDate]
				   ,[ReturnDate]
				   ,[CreatedByUserID]
				   ,[PricePerDaySnapshot]
				   ,[CustomerID])
			 VALUES
				   (@CarID
				   ,@Deposit
				   ,@TotalPrice
				   ,@PickupLocation
				   ,@PickupDate
				   ,@ReturnDate
				   ,@UserID,
				   @PricePerDay,
				   @CustomerID)

		SET @CarRentalID = SCOPE_IDENTITY();

		IF (@PaymentID IS NOT NULL)
			BEGIN
				INSERT INTO [dbo].[CarRentalPayments]
						   ([CarRentalID]
						   ,[PaymentID]
						   ,[PaidAmount]
						   ,[Status])
					 VALUES
						   (@CarRentalID
						   ,@PaymentID
						   ,@InitialPayment
						   ,'Initial')
			END

		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION;

		PRINT 'SQL ERROR: ' + ERROR_MESSAGE();

		THROW;
	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[getModelsByMake]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getModelsByMake]
(
	@Make nvarchar(50)
)
AS
BEGIN
	SELECT * FROM Models
	INNER JOIN Makes ON Models.MakeID = Makes.MakeID
	WHERE Makes.Make = @Make
END
GO
/****** Object:  StoredProcedure [dbo].[getModelsByMakeID]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getModelsByMakeID]
(
	@MakeID INT
)
AS
BEGIN

SELECT * FROM Models
WHERE MakeID = @MakeID

END
GO
/****** Object:  StoredProcedure [dbo].[spExtendRental]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spExtendRental]
(
	@CarRentalID INT,
	@NewReturnDate DATETIME
)
AS
BEGIN
	DECLARE @CarID INT;
	DECLARE @CurrentReturnDate DATETIME;
	DECLARE @PricePerDay DECIMAL(10, 2) = 0;
	DECLARE @Amount DECIMAL(10, 2) = 0;

	BEGIN TRY
		BEGIN TRANSACTION;
			SELECT 
				@CarID = CarID,
				@CurrentReturnDate = ReturnDate,
				@PricePerDay = PricePerDaySnapshot
			FROM CarRentals 
			WHERE CarRentalID = @CarRentalID;

			SET @Amount = @PricePerDay * ABS(DATEDIFF(DAY, @CurrentReturnDate, @NewReturnDate));

			IF (@NewReturnDate <= @CurrentReturnDate)
				BEGIN
					;THROW 51000, 'New Return Date can not be lesser than current date!', 1;
				END

			-- Update Car Rental Payments Remaining Amount to indicate the Amount increased. (Wrong one)
			--UPDATE CarRentalPayments
			--SET RemainingAmount = SUM(PaidAmount) - PaidAmount RemainingAmount + @Amount - PaidAmount
			--WHERE CarRentalID = @CarRentalID;

			-- Update total price and new car rental in the
			-- Check the result of DATEDIFF
			UPDATE CarRentals
			SET TotalPrice = TotalPrice + @PricePerDay * ABS(DATEDIFF(DAY, @NewReturnDate, @CurrentReturnDate)),
				ReturnDate = @NewReturnDate
			WHERE CarRentalID = @CarRentalID;

			COMMIT TRANSACTION;

			RETURN 1;
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE();
		RETURN 0;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spReturnCar]    Script Date: 5/25/2026 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReturnCar]
	@CarRentalID INT,
	@ActualReturnDate DATETIME,
	@CreatedByUserID INT
AS
	BEGIN
		DECLARE @PaidAmount DECIMAL(10, 2) = 0;
		DECLARE @RemainingAmount DECIMAL(10, 2) = 0;
		DECLARE @CarID INT;

		BEGIN TRY
			BEGIN TRANSACTION
				DECLARE @PickupDate DATETIME;
				DECLARE @TotalDaysRented INT;
				DECLARE @PricePerDay DECIMAL(10, 2) = 0;

				-- Get Paid Amount
				SELECT 
					@PaidAmount = SUM(CRP.PaidAmount)
				FROM CarRentals CR
				INNER JOIN CarRentalPayments CRP ON CR.CarRentalID = CRP.CarRentalID
				WHERE CR.CarRentalID = @CarRentalID;

				SELECT
					@PickupDate = PickupDate,
					@CarID = CarID,
					@PricePerDay = PricePerDaySnapshot
				FROM CarRentals
				WHERE CarRentalID = @CarRentalID;

				-- Calculate the total Days rented and Calculate remaining amount based on it.
				SET @TotalDaysRented = DATEDIFF(DAY, @PickupDate, @ActualReturnDate);

				SET @RemainingAmount = (@PricePerDay * @TotalDaysRented) - @PaidAmount;

				PRINT @ActualReturnDate;

				INSERT INTO [dbo].[Payments]
							([Amount]
							,[PaymentMethod])
						VALUES
							(@RemainingAmount
							,'Cash');

				INSERT INTO [dbo].[CarRentalPayments]
							([CarRentalID]
							,[PaymentID]
							,[PaidAmount]
							,[Status])
						VALUES
							(@CarRentalID
							,SCOPE_IDENTITY()
							,@RemainingAmount
							,'Return')

				INSERT INTO [dbo].[RentalReturns]
						   ([CarRentalID]
						   ,[ReturnDate]
						   ,[CreatedByUserID])
					 VALUES
						   (@CarRentalID
						   ,@ActualReturnDate
						   ,@CreatedByUserID)

				UPDATE [dbo].[CarRentals]
				   SET [Status] = 'Completed'
				 WHERE CarRentalID = @CarRentalID

				UPDATE [dbo].[Cars]
					SET [IsAvailable] = 1
				WHERE CarID = @CarID;

				COMMIT TRANSACTION;
				RETURN 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			RETURN 0;
		END CATCH
	END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Initial, Return, Extension' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarRentalPayments', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Available = 1,
Rented = 2,
Maintenance = 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cars'
GO
USE [master]
GO
ALTER DATABASE [CarsRentalSystem] SET  READ_WRITE 
GO
