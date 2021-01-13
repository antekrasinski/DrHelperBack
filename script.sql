USE [master]
GO
/****** Object:  Database [DrHelperDB]    Script Date: 29.12.2020 02:19:24 ******/
CREATE DATABASE [DrHelperDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DrHelperDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DrHelperDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DrHelperDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DrHelperDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DrHelperDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DrHelperDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DrHelperDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DrHelperDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DrHelperDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DrHelperDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DrHelperDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DrHelperDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DrHelperDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DrHelperDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DrHelperDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DrHelperDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DrHelperDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DrHelperDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DrHelperDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DrHelperDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DrHelperDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DrHelperDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DrHelperDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DrHelperDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DrHelperDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DrHelperDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DrHelperDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DrHelperDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DrHelperDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DrHelperDB] SET  MULTI_USER 
GO
ALTER DATABASE [DrHelperDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DrHelperDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DrHelperDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DrHelperDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DrHelperDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DrHelperDB', N'ON'
GO
ALTER DATABASE [DrHelperDB] SET QUERY_STORE = OFF
GO
USE [DrHelperDB]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[idAppointment] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](200) NULL,
 CONSTRAINT [Appointment_PK] PRIMARY KEY CLUSTERED 
(
	[idAppointment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disease]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disease](
	[idDisease] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [Disease_PK] PRIMARY KEY CLUSTERED 
(
	[idDisease] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[idMedicine] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [Medicine_PK] PRIMARY KEY CLUSTERED 
(
	[idMedicine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription](
	[idPrescription] [int] IDENTITY(1,1) NOT NULL,
	[prescriptionDate] [datetime] NULL,
 CONSTRAINT [Prescription_PK] PRIMARY KEY CLUSTERED 
(
	[idPrescription] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrescriptionsMedicine]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrescriptionsMedicine](
	[idPrescription] [int] NOT NULL,
	[idMedicine] [int] NOT NULL,
	[amount] [varchar](100) NULL,
 CONSTRAINT [prescription_medicine_PK] PRIMARY KEY CLUSTERED 
(
	[idPrescription] ASC,
	[idMedicine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timeblock]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timeblock](
	[idTimeblock] [int] IDENTITY(1,1) NOT NULL,
	[startTime] [datetime] NOT NULL,
	[endTime] [datetime] NOT NULL,
	[avaliable] [bit] NOT NULL,
	[idUser] [int] NOT NULL,
	[idAppointment] [int] NULL,
 CONSTRAINT [Timeblock_PK] PRIMARY KEY CLUSTERED 
(
	[idTimeblock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](100) NULL,
	[description] [varchar](200) NULL,
	[idUserType] [int] NOT NULL,
	[passwordHash] [binary](64) NULL,
	[passwordSalt] [binary](128) NULL,
 CONSTRAINT [User_PK] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersDiseases]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersDiseases](
	[idUsersDiseases] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[idDisease] [int] NOT NULL,
	[occurrenceDate] [datetime] NOT NULL,
	[description] [varchar](200) NULL,
 CONSTRAINT [users_diseases_PK] PRIMARY KEY CLUSTERED 
(
	[idUsersDiseases] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersPrescriptions]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersPrescriptions](
	[idPrescription] [int] NOT NULL,
	[idUser] [int] NOT NULL,
 CONSTRAINT [users_prescriptions_PK] PRIMARY KEY CLUSTERED 
(
	[idPrescription] ASC,
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 29.12.2020 02:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[idUserType] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](20) NOT NULL,
 CONSTRAINT [UserType_PK] PRIMARY KEY CLUSTERED 
(
	[idUserType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PrescriptionsMedicine]  WITH CHECK ADD  CONSTRAINT [FK_ASS_5] FOREIGN KEY([idPrescription])
REFERENCES [dbo].[Prescription] ([idPrescription])
GO
ALTER TABLE [dbo].[PrescriptionsMedicine] CHECK CONSTRAINT [FK_ASS_5]
GO
ALTER TABLE [dbo].[PrescriptionsMedicine]  WITH CHECK ADD  CONSTRAINT [FK_ASS_8] FOREIGN KEY([idMedicine])
REFERENCES [dbo].[Medicine] ([idMedicine])
GO
ALTER TABLE [dbo].[PrescriptionsMedicine] CHECK CONSTRAINT [FK_ASS_8]
GO
ALTER TABLE [dbo].[Timeblock]  WITH CHECK ADD  CONSTRAINT [Timeblock_Appointment_FK] FOREIGN KEY([idAppointment])
REFERENCES [dbo].[Appointment] ([idAppointment])
ON UPDATE SET DEFAULT
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[Timeblock] CHECK CONSTRAINT [Timeblock_Appointment_FK]
GO
ALTER TABLE [dbo].[Timeblock]  WITH CHECK ADD  CONSTRAINT [Timeblock_User_FK] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Timeblock] CHECK CONSTRAINT [Timeblock_User_FK]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [User_UserType_FK] FOREIGN KEY([idUserType])
REFERENCES [dbo].[UserType] ([idUserType])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [User_UserType_FK]
GO
ALTER TABLE [dbo].[UsersDiseases]  WITH CHECK ADD  CONSTRAINT [FK_ASS_1] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersDiseases] CHECK CONSTRAINT [FK_ASS_1]
GO
ALTER TABLE [dbo].[UsersDiseases]  WITH CHECK ADD  CONSTRAINT [FK_ASS_2] FOREIGN KEY([idDisease])
REFERENCES [dbo].[Disease] ([idDisease])
GO
ALTER TABLE [dbo].[UsersDiseases] CHECK CONSTRAINT [FK_ASS_2]
GO
ALTER TABLE [dbo].[UsersPrescriptions]  WITH CHECK ADD  CONSTRAINT [FK_ASS_6] FOREIGN KEY([idPrescription])
REFERENCES [dbo].[Prescription] ([idPrescription])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersPrescriptions] CHECK CONSTRAINT [FK_ASS_6]
GO
ALTER TABLE [dbo].[UsersPrescriptions]  WITH CHECK ADD  CONSTRAINT [FK_ASS_7] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersPrescriptions] CHECK CONSTRAINT [FK_ASS_7]
GO
USE [master]
GO
ALTER DATABASE [DrHelperDB] SET  READ_WRITE 
GO
INSERT INTO [dbo].[UserType](type) VALUES ('admin')
GO
INSERT INTO [dbo].[UserType](type) VALUES ('doctor')
GO
INSERT INTO [dbo].[UserType](type) VALUES ('patient')
GO
INSERT INTO [dbo].[User](username,idUserType, passwordHash, passwordSalt, name, surname, description) VALUES ('admin',1,0x07A668A38BEC5934F2511FCA226A3237A43C1DA4C8D40FD296A5F8B06E16B97E6CC36FBFDF4C6CCE4D7E7A9231B88D1005376F5BDFCE1861717D916519E13CEB,0x36978B8F1539BAD7168E0AC21C46B2D06C17E5C991067D7A3BD56A0C9FA5B35C23EE370CE0F7A966B6FEF55E94BF245079DB2F31B7D0CB49DFB45C3949D5A05DC2CCFD9C14FC82157C6848109661EE5E59B841659E4F99A416FDFD46FD457B5123C1076B7A1D68BA4158E8CE1A49F5590A81D6E2C410564CA0855A030C4EA312,'','','')
GO