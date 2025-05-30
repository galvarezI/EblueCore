USE [master]
GO
/****** Object:  Database [workplandb]    Script Date: 4/23/2025 9:13:33 AM ******/
CREATE DATABASE [workplandb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'workplandb', FILENAME = N'C:\Users\GGJEANZS\workplandb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'workplandb_log', FILENAME = N'C:\Users\GGJEANZS\workplandb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [workplandb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [workplandb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [workplandb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [workplandb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [workplandb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [workplandb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [workplandb] SET ARITHABORT OFF 
GO
ALTER DATABASE [workplandb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [workplandb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [workplandb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [workplandb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [workplandb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [workplandb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [workplandb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [workplandb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [workplandb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [workplandb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [workplandb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [workplandb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [workplandb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [workplandb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [workplandb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [workplandb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [workplandb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [workplandb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [workplandb] SET  MULTI_USER 
GO
ALTER DATABASE [workplandb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [workplandb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [workplandb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [workplandb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [workplandb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [workplandb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [workplandb] SET QUERY_STORE = OFF
GO
USE [workplandb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[adminOfficerComments]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adminOfficerComments](
	[adminOfficerCommentsID] [int] IDENTITY(1,1) NOT NULL,
	[AdComments] [text] NULL,
	[projectVigency] [date] NULL,
	[ReviewDate] [date] NULL,
	[WorkplanQuantity] [text] NULL,
	[FundsComments] [text] NULL,
	[ProjectID] [int] NULL,
	[Username] [text] NULL,
	[UserRole] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[adminOfficerCommentsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Analytical]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Analytical](
	[AnalyticalID] [int] IDENTITY(1,1) NOT NULL,
	[analysisRequired] [varchar](200) NULL,
	[numSamples] [varchar](100) NULL,
	[ProbableDate] [date] NULL,
	[ProjectID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnalyticalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[commodity]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[commodity](
	[CommID] [int] IDENTITY(1,1) NOT NULL,
	[CommName] [nvarchar](210) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CommID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](100) NOT NULL,
	[DepartmentCode] [nvarchar](100) NOT NULL,
	[DepartmentOf] [int] NULL,
	[DepartmentOldID] [int] NULL,
	[RosterDepartmentDirectorId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fieldOption]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fieldOption](
	[fieldoptionId] [int] IDENTITY(1,1) NOT NULL,
	[OptionName] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[fieldoptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldWork]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldWork](
	[FieldWorkID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[dateStarted] [date] NULL,
	[dateEnded] [date] NULL,
	[InProgress] [bit] NOT NULL,
	[ToBeInitiated] [bit] NOT NULL,
	[WFieldwork] [text] NULL,
	[Area] [varchar](max) NULL,
	[fieldoptionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FieldWorkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fiscalYear]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fiscalYear](
	[FiscalYearID] [int] IDENTITY(1,1) NOT NULL,
	[FiscalYearName] [nvarchar](100) NOT NULL,
	[FiscalYearNumber] [nvarchar](20) NOT NULL,
	[FiscalYearStatusID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FiscalYearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FiscalYearStatus]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiscalYearStatus](
	[FiscalYearStatusID] [int] NOT NULL,
	[FiscalYearStatusName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FiscalYearStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[funds]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[funds](
	[FundID] [int] IDENTITY(1,1) NOT NULL,
	[LocationID] [int] NOT NULL,
	[Salaries] [money] NULL,
	[Wages] [money] NULL,
	[Benefits] [money] NULL,
	[Assistant] [money] NULL,
	[Materials] [money] NULL,
	[Equipment] [money] NULL,
	[Travel] [money] NULL,
	[Abroad] [money] NULL,
	[Subcontracts] [money] NULL,
	[Others] [money] NULL,
	[ProjectID] [int] NOT NULL,
	[UFISaccount] [nvarchar](50) NULL,
	[IndirectCosts] [money] NULL,
	[TotalAmount] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[FundID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FundType]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundType](
	[FundTypeID] [int] IDENTITY(1,1) NOT NULL,
	[FundTypeName] [nvarchar](250) NULL,
	[IsFederal] [bit] NULL,
	[IsState] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[FundTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gradAss]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gradAss](
	[GAID] [int] IDENTITY(1,1) NOT NULL,
	[Gname] [nvarchar](255) NULL,
	[Thesis] [text] NULL,
	[ProjectID] [int] NULL,
	[StudentID] [int] NULL,
	[Amount] [decimal](18, 0) NULL,
	[RoleID] [int] NULL,
	[StudentName] [varchar](255) NULL,
	[IsGraduated] [bit] NULL,
	[IsUndergraduated] [bit] NULL,
	[thesisProjectId] [int] NULL,
	[gradoptionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[GAID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gradOption]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gradOption](
	[gradoptionId] [int] IDENTITY(1,1) NOT NULL,
	[gradOptionName] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[gradoptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[laboratory]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[laboratory](
	[LabID] [int] IDENTITY(1,1) NOT NULL,
	[AReq] [nvarchar](255) NULL,
	[NoSamples] [nvarchar](70) NULL,
	[SamplesDate] [datetime] NULL,
	[ProjectID] [int] NULL,
	[WorkPlanned] [text] NULL,
	[Descriptions] [text] NULL,
	[EstimatedTime] [text] NULL,
	[FacilitiesNeeded] [text] NULL,
	[timeEstimated] [date] NULL,
	[centralLaboratory] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[LabID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locationn]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locationn](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](200) NOT NULL,
	[LocationOldID] [int] NULL,
	[FundsVar] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtherPersonel]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherPersonel](
	[OPID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[PerTime] [decimal](18, 4) NULL,
	[ProjectID] [int] NULL,
	[LocationID] [int] NULL,
	[RosterID] [int] NULL,
	[PersonnelManAdded] [varchar](150) NULL,
	[RoleManAdded] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[OPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POrganization]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POrganization](
	[POrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[POrganizationName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[POrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[principalLocation]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[principalLocation](
	[PrincLocID] [int] IDENTITY(1,1) NOT NULL,
	[PrincLocName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PrincLocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[processProjectWay]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[processProjectWay](
	[ProcessProjectWayID] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[EstatusId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramArea]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramArea](
	[ProgramAreaID] [int] IDENTITY(1,1) NOT NULL,
	[ProgramAreaName] [nvarchar](200) NULL,
	[ProgramAreaOldID] [int] NULL,
	[RosterProgragmaticCoordinatorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgramAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[projectAssents]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[projectAssents](
	[passentsID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NULL,
	[RosterID] [int] NULL,
	[RoleID] [int] NULL,
	[signData] [nvarchar](max) NULL,
	[signDate] [datetime] NOT NULL,
	[RosterData] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[passentsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectNotes]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectNotes](
	[ProjectNotesId] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [text] NULL,
	[LastUpdate] [datetime] NULL,
	[UserID] [int] NULL,
	[ProjectID] [int] NULL,
	[RosterID] [int] NULL,
	[Username] [text] NULL,
	[DepartmentDirectorComments] [text] NULL,
	[DeanComments] [text] NULL,
	[Roles] [text] NULL,
	[userRole] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectNotesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[projects]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectNumber] [nvarchar](255) NOT NULL,
	[ProjectTitle] [varchar](255) NULL,
	[DepartmentID] [int] NULL,
	[CommID] [int] NULL,
	[ProgramAreaID] [int] NULL,
	[SubStationID] [int] NULL,
	[DateRegister] [datetime] NULL,
	[LastUpdate] [datetime] NULL,
	[FiscalYearID] [int] NULL,
	[Objectives] [text] NULL,
	[ObjWorkPlan] [text] NULL,
	[PresentOutlook] [text] NULL,
	[WP1FieldWork] [text] NULL,
	[WP2ID] [int] NULL,
	[Workplan2Desc] [text] NULL,
	[ResultsAvailable] [nvarchar](255) NULL,
	[Facilities] [text] NULL,
	[Impact] [text] NULL,
	[Salaries] [text] NULL,
	[Materials] [text] NULL,
	[Equipment] [text] NULL,
	[Travel] [text] NULL,
	[Abroad] [text] NULL,
	[Others] [text] NULL,
	[WFSID] [int] NULL,
	[WFUpdate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[TerminationDate] [datetime] NULL,
	[FundTypeID] [int] NULL,
	[WorkPlan2] [text] NULL,
	[Wages] [text] NULL,
	[Benefits] [text] NULL,
	[Assistant] [text] NULL,
	[Subcontracts] [text] NULL,
	[IndirectCosts] [text] NULL,
	[ContractNumber] [text] NULL,
	[ORCID] [text] NULL,
	[ProcessProjectWayID] [int] NULL,
	[POrganizationsId] [int] NULL,
	[LocationID] [int] NULL,
	[ProjectPI] [varchar](200) NULL,
	[RosterID] [int] NULL,
	[Objectives2] [text] NULL,
	[Objectives3] [text] NULL,
	[Objectives4] [text] NULL,
	[Objectives5] [text] NULL,
	[Objectives6] [text] NULL,
	[Substation] [text] NULL,
	[ProjectStatusID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectStatus]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectStatus](
	[ProjectStatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusNumber] [int] NULL,
	[StatusName] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RolesID] [int] IDENTITY(1,1) NOT NULL,
	[RName] [varchar](200) NULL,
	[isResearchDirector] [bit] NULL,
	[isExecutiveOfficer] [bit] NULL,
	[isAdministrativeOfficer] [bit] NULL,
	[isExternalResources] [bit] NULL,
	[rosterID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RolesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roster]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roster](
	[RosterID] [int] IDENTITY(1,1) NOT NULL,
	[RosterSegSoc] [nvarchar](255) NULL,
	[RosterName] [nvarchar](250) NULL,
	[DepartmentID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[CanBePI] [bit] NOT NULL,
	[RoleID] [int] NULL,
	[Email] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[RosterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sciProjects]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sciProjects](
	[SciID] [int] IDENTITY(1,1) NOT NULL,
	[RosterID] [int] NOT NULL,
	[Roles] [int] NOT NULL,
	[Credits] [money] NULL,
	[TR] [money] NULL,
	[CA] [money] NULL,
	[AH] [money] NULL,
	[AdHonorem] [bit] NULL,
	[ProjectID] [int] NULL,
	[thesisProjectId] [int] NULL,
	[sciRolesID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sciRoles]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sciRoles](
	[sciRolesID] [int] IDENTITY(1,1) NOT NULL,
	[SciRoleName] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[sciRolesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Substacion]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Substacion](
	[SubstationID] [int] IDENTITY(1,1) NOT NULL,
	[SubStationName] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubstationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thesisProject]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thesisProject](
	[thesisProjectId] [int] IDENTITY(1,1) NOT NULL,
	[optionName] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[thesisProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/23/2025 9:13:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[RosterID] [int] NULL,
	[isEnabled] [bit] NULL,
	[RolesID] [int] NULL,
	[Roles] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[gradAss] ADD  DEFAULT ((0)) FOR [IsGraduated]
GO
ALTER TABLE [dbo].[gradAss] ADD  DEFAULT ((0)) FOR [IsUndergraduated]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((0)) FOR [isResearchDirector]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((0)) FOR [isExecutiveOfficer]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((0)) FOR [isAdministrativeOfficer]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((0)) FOR [isExternalResources]
GO
ALTER TABLE [dbo].[roster] ADD  DEFAULT ((0)) FOR [CanBePI]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [isEnabled]
GO
ALTER TABLE [dbo].[adminOfficerComments]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[Analytical]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[FieldWork]  WITH CHECK ADD FOREIGN KEY([fieldoptionId])
REFERENCES [dbo].[fieldOption] ([fieldoptionId])
GO
ALTER TABLE [dbo].[FieldWork]  WITH CHECK ADD FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locationn] ([LocationID])
GO
ALTER TABLE [dbo].[FieldWork]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[fiscalYear]  WITH CHECK ADD FOREIGN KEY([FiscalYearStatusID])
REFERENCES [dbo].[FiscalYearStatus] ([FiscalYearStatusID])
GO
ALTER TABLE [dbo].[funds]  WITH CHECK ADD FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locationn] ([LocationID])
GO
ALTER TABLE [dbo].[funds]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[gradAss]  WITH CHECK ADD FOREIGN KEY([gradoptionId])
REFERENCES [dbo].[gradOption] ([gradoptionId])
GO
ALTER TABLE [dbo].[gradAss]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[gradAss]  WITH CHECK ADD FOREIGN KEY([thesisProjectId])
REFERENCES [dbo].[thesisProject] ([thesisProjectId])
GO
ALTER TABLE [dbo].[laboratory]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[OtherPersonel]  WITH CHECK ADD FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locationn] ([LocationID])
GO
ALTER TABLE [dbo].[OtherPersonel]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[OtherPersonel]  WITH CHECK ADD FOREIGN KEY([RosterID])
REFERENCES [dbo].[roster] ([RosterID])
GO
ALTER TABLE [dbo].[processProjectWay]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectNotes]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectNotes]  WITH CHECK ADD FOREIGN KEY([RosterID])
REFERENCES [dbo].[roster] ([RosterID])
GO
ALTER TABLE [dbo].[ProjectNotes]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([CommID])
REFERENCES [dbo].[commodity] ([CommID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([CommID])
REFERENCES [dbo].[commodity] ([CommID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([FiscalYearID])
REFERENCES [dbo].[fiscalYear] ([FiscalYearID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([FundTypeID])
REFERENCES [dbo].[FundType] ([FundTypeID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locationn] ([LocationID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([POrganizationsId])
REFERENCES [dbo].[POrganization] ([POrganizationID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([ProgramAreaID])
REFERENCES [dbo].[ProgramArea] ([ProgramAreaID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([ProjectStatusID])
REFERENCES [dbo].[ProjectStatus] ([ProjectStatusID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([RosterID])
REFERENCES [dbo].[roster] ([RosterID])
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD FOREIGN KEY([SubStationID])
REFERENCES [dbo].[Substacion] ([SubstationID])
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD FOREIGN KEY([rosterID])
REFERENCES [dbo].[roster] ([RosterID])
GO
ALTER TABLE [dbo].[sciProjects]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[projects] ([ProjectID])
GO
ALTER TABLE [dbo].[sciProjects]  WITH CHECK ADD FOREIGN KEY([RosterID])
REFERENCES [dbo].[roster] ([RosterID])
GO
ALTER TABLE [dbo].[sciProjects]  WITH CHECK ADD FOREIGN KEY([sciRolesID])
REFERENCES [dbo].[sciRoles] ([sciRolesID])
GO
ALTER TABLE [dbo].[sciProjects]  WITH CHECK ADD FOREIGN KEY([thesisProjectId])
REFERENCES [dbo].[thesisProject] ([thesisProjectId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RolesID])
REFERENCES [dbo].[Roles] ([RolesID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RosterID])
REFERENCES [dbo].[roster] ([RosterID])
GO
/****** Object:  StoredProcedure [dbo].[ActualizarPag1]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarPag1]

@ProjectId INT,
@Objectives TEXT,
@ObjWorkPlan TEXT,
@PresentOutlook TEXT

AS
Begin
Update projects set
ObjWorkPlan = @ObjWorkPlan,
Objectives = @Objectives,
PresentOutlook = @PresentOutlook

Where ProjectID = @ProjectId;

END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarPag9]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ActualizarPag9]

@ProjectId INT,
@Facilities TEXT,
@Impact TEXT,
@Salaries TEXT,
@Materials TEXT,
@Equipment TEXT,
@Travel TEXT,
@Abroad TEXT,
@Others TEXT,
@Wages TEXT,
@Benefits TEXT,
@Assistant TEXT,
@Subcontracts TEXT,
@IndirectCosts TEXT

AS

BEGIN 

Update projects set

Facilities = @Facilities,
Impact = @Impact,
Salaries = @Salaries,
Materials = @Materials,
Equipment = @Equipment,
Travel = @Travel,
Abroad = @Abroad,
Others = @Others,
Wages = @Wages,
Benefits =@Benefits,
Assistant = @Assistant,
Subcontracts = @Subcontracts,
IndirectCosts = @IndirectCosts
Where ProjectID = @ProjectId;

END
GO
/****** Object:  StoredProcedure [dbo].[report_workplan]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[report_workplan] @projectID nvarchar(20)
AS 
Begin

Select ProjectNumber,ProjectTitle, ProjectPI,DepartmentID,  ProgramAreaID, SubStationID,FiscalYearID,
Objectives,ObjWorkPlan,PresentOutlook, WP1FieldWork,Workplan2Desc,ResultsAvailable, Facilities, Impact,Salaries, Materials,Equipment,
Travel,Abroad,Others,WFSID,WFUpdate,StartDate,TerminationDate,FundTypeID,WorkPlan2,Wages,Benefits,Assistant,Subcontracts,IndirectCosts,ContractNumber,
ORCID as acountNumber,ProcessProjectWayID,POrganizationsId, c.CommName,p.POrganizationName

FROM projects 
INNER JOIN commodity c on projects.CommID = c.CommID
INNER JOIN POrganization p on projects.POrganizationsId = p.POrganizationID
where ProjectID = @projectID;


end;
GO
/****** Object:  StoredProcedure [dbo].[report_workplandb]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[report_workplandb] @projectID bigint
AS 
Begin

Select ProjectNumber,ProjectTitle, ProjectPI,DepartmentID,  ProgramAreaID, SubStationID,FiscalYearID,
Objectives,ObjWorkPlan,PresentOutlook, WP1FieldWork,Workplan2Desc,ResultsAvailable, Facilities, Impact,Salaries, Materials,Equipment,
Travel,Abroad,Others,WFSID,WFUpdate,StartDate,TerminationDate,FundTypeID,WorkPlan2,Wages,Benefits,Assistant,Subcontracts,IndirectCosts,ContractNumber,
ORCID as acountNumber,ProcessProjectWayID,POrganizationsId, c.CommName,p.POrganizationName

FROM projects 
INNER JOIN commodity c on projects.CommID = c.CommID
INNER JOIN POrganization p on projects.POrganizationsId = p.POrganizationID
where ProjectID = @projectID;


end;
GO
/****** Object:  StoredProcedure [dbo].[report_workplandb1]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[report_workplandb1] @projectID bigint
AS 
Begin
/*Este debe ser el procedure definitivo*/

Select pp.ProjectNumber,pp.ProjectTitle, ProjectPI,pp.DepartmentID,  ProgramAreaID, SubStationID,FiscalYearID,
Objectives,ObjWorkPlan,PresentOutlook, Facilities, Impact,Salaries, Materials,Equipment,
Travel,Abroad,Others,WFSID,FundTypeID,WorkPlan2,Wages,Benefits,Assistant,Subcontracts,IndirectCosts,ContractNumber,
ORCID as acountNumber,ProcessProjectWayID,POrganizationsId, c.CommName,p.POrganizationName, r.RosterName ,  d.DepartmentName


FROM projects pp
INNER JOIN commodity c on pp.CommID = c.CommID
INNER JOIN POrganization p on pp.POrganizationsId = p.POrganizationID
INNER JOIN roster r on pp.RosterID = r.RosterID
INNER JOIN Departments d on pp.DepartmentID = d.DepartmentID


select field.WFieldwork,field.Area, fielLo.LocationName, field.dateStarted , field.dateEnded , fo.OptionName

from FieldWork field
INNER JOIN Locationn fielLo on field.LocationID = fielLo.LocationID
INNER JOIN fieldOption fo on field.fieldoptionId = fo.fieldoptionId
where field.ProjectID = @projectID

select lab.WorkPlanned , Descriptions , lab.timeEstimated , lab.FacilitiesNeeded,lab.ProjectID

from laboratory lab
where ProjectID = @projectID

select  a.analysisRequired, a.numSamples, a.ProbableDate ,a.ProjectID

from Analytical a
where ProjectID = @projectID

select rsci.RosterName as Scientist, sci.Credits ,sci.TR,sci.CA , sci.AH , sci.ProjectID

from sciProjects sci
INNER JOIN roster rsci on  sci.RosterID = rsci.RosterID
Where sci.ProjectID = @projectID


select op.Name, op.PerTime, rop.RosterName as PersonnelName, opl.LocationName as opLocation,op.PersonnelManAdded, op.RoleManAdded 

from OtherPersonel op
INNER JOIN Locationn opl on op.LocationID = opl.LocationID
INNER JOIN roster rop on  op.RosterID = rop.RosterID
where op.ProjectID = @projectID


select gra.Gname, gra.Thesis,gra.Amount,gro.gradOptionName,thg.optionName

from gradAss gra
INNER JOIN gradOption gro on gra.gradoptionId = gro.gradoptionId
INNER JOIN thesisProject thg on gra.thesisProjectId = thg.thesisProjectId
Where gra.ProjectID = @projectID

select funlo.LocationName as FunLocation, fun.Salaries as FunSalaries, fun.Wages as FunWages, fun.Benefits as FunBeneficts, fun.Assistant as FunAssistant, fun.Materials as FunMaterials,fun.Equipment as FunEquipment,
fun.Travel as FunTravel, fun.Abroad as FunAbroad, fun.Subcontracts as FunSubcontracts, fun.Others as FunOthers, fun.IndirectCosts as FunIndirectCost



from funds fun
INNER JOIN Locationn funlo on fun.LocationID = funlo.LocationID
where fun.ProjectID = @projectID


end;

GO
/****** Object:  StoredProcedure [dbo].[report_workplandb2]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[report_workplandb2] @projectID bigint
AS 
Begin
/*Este debe ser el procedure definitivo*/

Select pp.ProjectNumber,pp.ProjectTitle, ProjectPI,Substation,
Objectives,ObjWorkPlan,PresentOutlook, Facilities, Impact,Salaries, Materials,Equipment,
Travel,Abroad,Others,WFSID,FundTypeID,WorkPlan2,Wages,Benefits,Assistant,Subcontracts,IndirectCosts,ContractNumber,
ORCID as acountNumber,ProcessProjectWayID,POrganizationsId, c.CommName,p.POrganizationName, r.RosterName ,  d.DepartmentName


FROM projects pp
INNER JOIN commodity c on pp.CommID = c.CommID
INNER JOIN POrganization p on pp.POrganizationsId = p.POrganizationID
INNER JOIN roster r on pp.RosterID = r.RosterID
INNER JOIN Departments d on pp.DepartmentID = d.DepartmentID
Where pp.ProjectID = @projectID



select field.WFieldwork,field.Area, fielLo.LocationName, field.dateStarted , field.dateEnded , fo.OptionName

from FieldWork field
INNER JOIN Locationn fielLo on field.LocationID = fielLo.LocationID
INNER JOIN fieldOption fo on field.fieldoptionId = fo.fieldoptionId
where field.ProjectID = @projectID



select lab.WorkPlanned , Descriptions , lab.timeEstimated , lab.FacilitiesNeeded,lab.ProjectID

from laboratory lab
where ProjectID = @projectID




select  a.analysisRequired, a.numSamples, a.ProbableDate ,a.ProjectID

from Analytical a
where ProjectID = @projectID




select rsci.RosterName as Scientist, sci.Credits ,sci.TR,sci.CA , sci.AH , sci.ProjectID

from sciProjects sci
INNER JOIN roster rsci on  sci.RosterID = rsci.RosterID
Where sci.ProjectID = @projectID



select op.Name, op.PerTime, rop.RosterName as PersonnelName, opl.LocationName as opLocation,op.PersonnelManAdded, op.RoleManAdded 

from OtherPersonel op
INNER JOIN Locationn opl on op.LocationID = opl.LocationID
INNER JOIN roster rop on  op.RosterID = rop.RosterID
where op.ProjectID = @projectID



select gra.Gname, gra.Thesis,gra.Amount,gro.gradOptionName,thg.optionName

from gradAss gra
INNER JOIN gradOption gro on gra.gradoptionId = gro.gradoptionId
INNER JOIN thesisProject thg on gra.thesisProjectId = thg.thesisProjectId
Where gra.ProjectID = @projectID


select funlo.LocationName as FunLocation, fun.Salaries as FunSalaries, fun.Wages as FunWages, fun.Benefits as FunBeneficts, fun.Assistant as FunAssistant, fun.Materials as FunMaterials,fun.Equipment as FunEquipment,
fun.Travel as FunTravel, fun.Abroad as FunAbroad, fun.Subcontracts as FunSubcontracts, fun.Others as FunOthers, fun.IndirectCosts as FunIndirectCost



from funds fun
INNER JOIN Locationn funlo on fun.LocationID = funlo.LocationID
where fun.ProjectID = @projectID


end;
GO
/****** Object:  StoredProcedure [dbo].[report_wplan3]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[report_wplan3]  @projectID bigint
AS 
Begin

Select pp.ProjectNumber,pp.ProjectTitle, ProjectPI,pp.DepartmentID,  ProgramAreaID, SubStationID,FiscalYearID,
Objectives,ObjWorkPlan,PresentOutlook, WP1FieldWork,Workplan2Desc,ResultsAvailable, Facilities, Impact,pp.Salaries, pp.Materials,pp.Equipment,
pp.Travel,pp.Abroad,pp.Others,WFSID,FundTypeID,WorkPlan2,pp.Wages,pp.Benefits,pp.Assistant,pp.Subcontracts,pp.IndirectCosts,ContractNumber,
ORCID as acountNumber,ProcessProjectWayID,POrganizationsId, c.CommName,p.POrganizationName, r.RosterName , fi.WFieldwork , fi.Area , fi.dateStarted ,fi.dateEnded,
fi.ToBeInitiated , fi.InProgress ,lfi.LocationName, d.DepartmentName , lab.WorkPlanned , lab.Descriptions,
lab.timeEstimated , lab.FacilitiesNeeded, anl.analysisRequired, anl.numSamples, anl.ProbableDate,
rtsci.RosterName , sci.Credits , sci.TR , sci.AH, opp.Name , opp.PerTime, opploc.LocationName , oppr.RosterName, opp.PersonnelManAdded , opp.RoleManAdded,
gr.Gname , gr.Thesis , gr.Amount,gth.optionName , gro.gradOptionName,
funlo.LocationName, fun.Salaries , fun.Wages , fun.Benefits, fun.Assistant, fun.Materials,fun.Equipment,
fun.Travel , fun.Abroad , fun.Subcontracts , fun.Others , fun.IndirectCosts




FROM projects pp
INNER JOIN commodity c on pp.CommID = c.CommID
INNER JOIN POrganization p on pp.POrganizationsId = p.POrganizationID
INNER JOIN roster r on pp.RosterID = r.RosterID
INNER JOIN FieldWork fi on pp.ProjectID = fi.ProjectID
INNER JOIN Departments d on pp.DepartmentID = d.DepartmentID
INNER JOIN Locationn lfi on fi.LocationID = lfi.LocationID
INNER JOIN laboratory lab on pp.ProjectID = lab.ProjectID
INNER JOIN Analytical anl on pp.ProjectID = anl.ProjectID
INNER JOIN sciProjects sci on pp.ProjectID = sci.ProjectID
INNER JOIN roster rtsci on sci.RosterID = rtsci.RosterID
INNER JOIN OtherPersonel opp on pp.ProjectID = opp.ProjectID
INNER JOIN Locationn opploc on opp.LocationID = opploc.LocationName
INNER JOIN roster oppr on  opp.RosterID = oppr.RosterName
INNER JOIN gradAss gr on pp.ProjectID = gr.ProjectID
INNER JOIN thesisProject gth on gr.thesisProjectId = gth.thesisProjectId
INNER JOIN gradOption gro on gr.gradoptionId = gro.gradoptionId
INNER JOIN funds fun on pp.ProjectID = fun.ProjectID
INNER JOIN Locationn funlo on fun.LocationID = funlo.LocationID

Where pp.ProjectID = @projectID

end;
GO
/****** Object:  StoredProcedure [dbo].[report_wplan4]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[report_wplan4]  @projectID bigint
AS 
Begin

Select pp.ProjectNumber,pp.ProjectTitle, ProjectPI,pp.DepartmentID,  ProgramAreaID, SubStationID,FiscalYearID,
Objectives,ObjWorkPlan,PresentOutlook, WP1FieldWork,Workplan2Desc,ResultsAvailable, Facilities, Impact,pp.Salaries, pp.Materials,pp.Equipment,
pp.Travel,pp.Abroad,pp.Others,WFSID,FundTypeID,WorkPlan2,pp.Wages,pp.Benefits,pp.Assistant,pp.Subcontracts,pp.IndirectCosts,ContractNumber,
ORCID as acountNumber,ProcessProjectWayID,POrganizationsId, c.CommName,p.POrganizationName, r.RosterName , fi.WFieldwork , fi.Area , fi.dateStarted ,fi.dateEnded,
fi.ToBeInitiated , fi.InProgress ,lfi.LocationName, d.DepartmentName , lab.WorkPlanned , lab.Descriptions,
lab.timeEstimated , lab.FacilitiesNeeded, anl.analysisRequired, anl.numSamples, anl.ProbableDate,
rtsci.RosterName , sci.Credits , sci.TR , sci.AH, opp.Name , opp.PerTime, opploc.LocationName , oppr.RosterName, opp.PersonnelManAdded , opp.RoleManAdded,
gr.Gname , gr.Thesis , gr.Amount,gth.optionName , gro.gradOptionName,
funlo.LocationName, fun.Salaries , fun.Wages , fun.Benefits, fun.Assistant, fun.Materials,fun.Equipment,
fun.Travel , fun.Abroad , fun.Subcontracts , fun.Others , fun.IndirectCosts




FROM projects pp
INNER JOIN commodity c on pp.CommID = c.CommID
INNER JOIN POrganization p on pp.POrganizationsId = p.POrganizationID
INNER JOIN roster r on pp.RosterID = r.RosterID
INNER JOIN FieldWork fi on pp.ProjectID = fi.ProjectID
INNER JOIN Departments d on pp.DepartmentID = d.DepartmentID
INNER JOIN Locationn lfi on fi.LocationID = lfi.LocationID
INNER JOIN laboratory lab on pp.ProjectID = lab.ProjectID
INNER JOIN Analytical anl on pp.ProjectID = anl.ProjectID
INNER JOIN sciProjects sci on pp.ProjectID = sci.ProjectID
INNER JOIN roster rtsci on sci.RosterID = rtsci.RosterID
INNER JOIN OtherPersonel opp on pp.ProjectID = opp.ProjectID
INNER JOIN Locationn opploc on opp.LocationID = opploc.LocationID
INNER JOIN roster oppr on  opp.RosterID = oppr.RosterID
INNER JOIN gradAss gr on pp.ProjectID = gr.ProjectID
INNER JOIN thesisProject gth on gr.thesisProjectId = gth.thesisProjectId
INNER JOIN gradOption gro on gr.gradoptionId = gro.gradoptionId
INNER JOIN funds fun on pp.ProjectID = fun.ProjectID
INNER JOIN Locationn funlo on fun.LocationID = funlo.LocationID

Where pp.ProjectID = @projectID

end;
GO
/****** Object:  StoredProcedure [dbo].[report_wplan5]    Script Date: 4/23/2025 9:13:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[report_wplan5]  @projectID bigint
AS 
Begin

Select pp.ProjectNumber,pp.ProjectTitle,pp.DepartmentID,  ProgramAreaID, SubStationID,FiscalYearID,
Objectives,ObjWorkPlan,PresentOutlook, WP1FieldWork,Workplan2Desc,ResultsAvailable, Facilities, Impact,pp.Salaries, pp.Materials,pp.Equipment,
pp.Travel,pp.Abroad,pp.Others,WFSID,FundTypeID,WorkPlan2,pp.Wages,pp.Benefits,pp.Assistant,pp.Subcontracts,pp.IndirectCosts,ContractNumber,
ORCID as acountNumber,ProcessProjectWayID,POrganizationsId, c.CommName,p.POrganizationName, r.RosterName as Leader, fi.WFieldwork , fi.Area , fi.dateStarted ,fi.dateEnded,
fi.ToBeInitiated , fi.InProgress ,lfi.LocationName as FieldLocation, d.DepartmentName , lab.WorkPlanned , lab.Descriptions,
lab.timeEstimated , lab.FacilitiesNeeded, anl.analysisRequired, anl.numSamples, anl.ProbableDate,
rtsci.RosterName as Scientist, sci.Credits , sci.TR , sci.AH, opp.Name , opp.PerTime, opploc.LocationName as OtherPersonelLoc, oppr.RosterName OtherPersonelN, opp.PersonnelManAdded , opp.RoleManAdded,
gr.Gname , gr.Thesis , gr.Amount,gth.optionName , gro.gradOptionName,
funlo.LocationName as FunLocation, fun.Salaries as FunSalaries, fun.Wages as FunWages, fun.Benefits as FunBeneficts, fun.Assistant as FunAssistant, fun.Materials as FunMaterials,fun.Equipment as FunEquipment,
fun.Travel as FunTravel, fun.Abroad as FunAbroad, fun.Subcontracts as FunSubcontracts, fun.Others as FunOthers, fun.IndirectCosts as FunIndirectCost




FROM projects pp
INNER JOIN commodity c on pp.CommID = c.CommID
INNER JOIN POrganization p on pp.POrganizationsId = p.POrganizationID
INNER JOIN roster r on pp.RosterID = r.RosterID
INNER JOIN FieldWork fi on pp.ProjectID = fi.ProjectID
INNER JOIN Departments d on pp.DepartmentID = d.DepartmentID
INNER JOIN Locationn lfi on fi.LocationID = lfi.LocationID
INNER JOIN laboratory lab on pp.ProjectID = lab.ProjectID
INNER JOIN Analytical anl on pp.ProjectID = anl.ProjectID
INNER JOIN sciProjects sci on pp.ProjectID = sci.ProjectID
INNER JOIN roster rtsci on sci.RosterID = rtsci.RosterID
INNER JOIN OtherPersonel opp on pp.ProjectID = opp.ProjectID
INNER JOIN Locationn opploc on opp.LocationID = opploc.LocationID
INNER JOIN roster oppr on  opp.RosterID = oppr.RosterID
INNER JOIN gradAss gr on pp.ProjectID = gr.ProjectID
INNER JOIN thesisProject gth on gr.thesisProjectId = gth.thesisProjectId
INNER JOIN gradOption gro on gr.gradoptionId = gro.gradoptionId
INNER JOIN funds fun on pp.ProjectID = fun.ProjectID
INNER JOIN Locationn funlo on fun.LocationID = funlo.LocationID

Where pp.ProjectID = @projectID

end;
GO
USE [master]
GO
ALTER DATABASE [workplandb] SET  READ_WRITE 
GO
