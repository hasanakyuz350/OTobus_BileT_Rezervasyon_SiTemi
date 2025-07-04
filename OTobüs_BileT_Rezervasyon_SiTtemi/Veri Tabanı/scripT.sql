USE [master]
GO
/****** Object:  Database [OTobüs_BileT_Rezervasyon_SiTtemi]    Script Date: 13.06.2025 20:31:55 ******/
CREATE DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OTobüs_BileT_Rezervasyon_SiTtemi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OTobüs_BileT_Rezervasyon_SiTtemi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OTobüs_BileT_Rezervasyon_SiTtemi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OTobüs_BileT_Rezervasyon_SiTtemi_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OTobüs_BileT_Rezervasyon_SiTtemi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET ARITHABORT OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET  MULTI_USER 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET QUERY_STORE = ON
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OTobüs_BileT_Rezervasyon_SiTtemi]
GO
/****** Object:  Table [dbo].[dberzervasyonTable]    Script Date: 13.06.2025 20:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dberzervasyonTable](
	[rezervasyonID] [int] IDENTITY(1,1) NOT NULL,
	[seferID] [int] NULL,
	[m_ID] [int] NULL,
	[kolTuknumara] [tinyint] NULL,
	[ucreT] [money] NULL,
	[rezervasyonTarihi] [datetime] NULL,
 CONSTRAINT [PK_dberzervasyonTable] PRIMARY KEY CLUSTERED 
(
	[rezervasyonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dbkasaTable]    Script Date: 13.06.2025 20:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dbkasaTable](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Kasa] [decimal](18, 3) NULL,
 CONSTRAINT [PK_dbkasaTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dbmusTeriTable]    Script Date: 13.06.2025 20:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dbmusTeriTable](
	[m_ID] [int] IDENTITY(1,1) NOT NULL,
	[m_ad] [varchar](30) NULL,
	[m_soyad] [varchar](30) NULL,
	[cinsiyeT] [bit] NULL,
	[phone] [tinyint] NULL,
	[mail] [nvarchar](30) NULL,
	[kimlikno] [tinyint] NULL,
 CONSTRAINT [PK_dbmusTeriTable] PRIMARY KEY CLUSTERED 
(
	[m_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dboTobusTable]    Script Date: 13.06.2025 20:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dboTobusTable](
	[busID] [int] IDENTITY(1,1) NOT NULL,
	[marka] [nvarchar](30) NULL,
	[plaka] [varchar](20) NULL,
	[kolTuksayisi] [tinyint] NULL,
 CONSTRAINT [PK_dboTobusTable] PRIMARY KEY CLUSTERED 
(
	[busID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dbseferTable]    Script Date: 13.06.2025 20:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dbseferTable](
	[seferID] [int] IDENTITY(1,1) NOT NULL,
	[busID] [int] NULL,
	[sehirID] [int] NULL,
	[daTe] [datetime] NULL,
	[fiyaT] [decimal](15, 3) NULL,
 CONSTRAINT [PK_dbseferTable] PRIMARY KEY CLUSTERED 
(
	[seferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dbsehirTable]    Script Date: 13.06.2025 20:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dbsehirTable](
	[sehirID] [int] IDENTITY(1,1) NOT NULL,
	[sehir1] [varchar](20) NULL,
	[sehir2] [varchar](20) NULL,
	[mesafe_KM] [int] NULL,
 CONSTRAINT [PK_dbsehirTable] PRIMARY KEY CLUSTERED 
(
	[sehirID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarihler]    Script Date: 13.06.2025 20:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarihler](
	[daTeID] [smallint] IDENTITY(1,1) NOT NULL,
	[Gun] [tinyint] NULL,
	[Ay] [tinyint] NULL,
	[Yil] [smallint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dberzervasyonTable]  WITH CHECK ADD  CONSTRAINT [FK_dberzervasyonTable_dbmusTeriTable] FOREIGN KEY([m_ID])
REFERENCES [dbo].[dbmusTeriTable] ([m_ID])
GO
ALTER TABLE [dbo].[dberzervasyonTable] CHECK CONSTRAINT [FK_dberzervasyonTable_dbmusTeriTable]
GO
ALTER TABLE [dbo].[dberzervasyonTable]  WITH CHECK ADD  CONSTRAINT [FK_dberzervasyonTable_dbseferTable] FOREIGN KEY([seferID])
REFERENCES [dbo].[dbseferTable] ([seferID])
GO
ALTER TABLE [dbo].[dberzervasyonTable] CHECK CONSTRAINT [FK_dberzervasyonTable_dbseferTable]
GO
ALTER TABLE [dbo].[dbseferTable]  WITH CHECK ADD  CONSTRAINT [FK_dbseferTable_dboTobusTable] FOREIGN KEY([busID])
REFERENCES [dbo].[dboTobusTable] ([busID])
GO
ALTER TABLE [dbo].[dbseferTable] CHECK CONSTRAINT [FK_dbseferTable_dboTobusTable]
GO
ALTER TABLE [dbo].[dbseferTable]  WITH CHECK ADD  CONSTRAINT [FK_dbseferTable_dbsehirTable] FOREIGN KEY([sehirID])
REFERENCES [dbo].[dbsehirTable] ([sehirID])
GO
ALTER TABLE [dbo].[dbseferTable] CHECK CONSTRAINT [FK_dbseferTable_dbsehirTable]
GO
USE [master]
GO
ALTER DATABASE [OTobüs_BileT_Rezervasyon_SiTtemi] SET  READ_WRITE 
GO
