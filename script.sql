USE [master]
GO
/****** Object:  Database [dbStunningDisco]    Script Date: 08-08-2022 02:05:00 ******/
CREATE DATABASE [dbStunningDisco]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbStunningDisco', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\dbStunningDisco.mdf' , SIZE = 139264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbStunningDisco_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\dbStunningDisco_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbStunningDisco] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbStunningDisco].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbStunningDisco] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbStunningDisco] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbStunningDisco] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbStunningDisco] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbStunningDisco] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbStunningDisco] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbStunningDisco] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbStunningDisco] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbStunningDisco] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbStunningDisco] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbStunningDisco] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbStunningDisco] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbStunningDisco] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbStunningDisco] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbStunningDisco] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbStunningDisco] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbStunningDisco] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbStunningDisco] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbStunningDisco] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbStunningDisco] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbStunningDisco] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbStunningDisco] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbStunningDisco] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbStunningDisco] SET  MULTI_USER 
GO
ALTER DATABASE [dbStunningDisco] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbStunningDisco] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbStunningDisco] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbStunningDisco] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbStunningDisco] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbStunningDisco] SET QUERY_STORE = OFF
GO
USE [dbStunningDisco]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [dbStunningDisco]
GO
/****** Object:  Table [dbo].[tblArtist]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArtist](
	[artistId] [int] IDENTITY(1,1) NOT NULL,
	[artistName] [varchar](20) NULL,
	[artistDOB] [date] NULL,
	[artistBio] [varchar](100) NULL,
	[artistIsActive] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[artistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSong]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSong](
	[songId] [int] IDENTITY(1,1) NOT NULL,
	[songName] [varchar](20) NULL,
	[songDOR] [date] NULL,
	[songImage] [image] NULL,
	[songIsActive] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[songId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblArtistSongMapping]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArtistSongMapping](
	[mapArtistId] [int] NULL,
	[mapSongId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewArtistSong]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[viewArtistSong]
as 
select songId, a.artistId, songName, songDOR, songImage,
artistName from tblArtistSongMapping asm, tblSong s, tblArtist a 
where asm.mapArtistId = a.artistId and asm.mapSongId = s.songId
GO
/****** Object:  Table [dbo].[tblUserRating]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRating](
	[userIdRate] [int] NULL,
	[songIdRate] [int] NULL,
	[rate] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewSongListArtist]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[viewSongListArtist]
as
select distinct v1.artistId,avg(ur.rate) rateArtist,
STUFF((SELECT ', ' +songName FROM viewArtistSong v WHERE v.artistId = v1.artistId FOR XML PATH('')),1,1,'') songsArtist
from viewArtistSong v1, tblUserRating ur 
where ur.songIdRate = v1.songId
group by v1.artistId;
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](20) NULL,
	[userEmail] [varchar](50) NULL,
	[userPassword] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblArtistSongMapping]  WITH CHECK ADD FOREIGN KEY([mapArtistId])
REFERENCES [dbo].[tblArtist] ([artistId])
GO
ALTER TABLE [dbo].[tblArtistSongMapping]  WITH CHECK ADD FOREIGN KEY([mapSongId])
REFERENCES [dbo].[tblSong] ([songId])
GO
ALTER TABLE [dbo].[tblUserRating]  WITH CHECK ADD FOREIGN KEY([songIdRate])
REFERENCES [dbo].[tblSong] ([songId])
GO
ALTER TABLE [dbo].[tblUserRating]  WITH CHECK ADD FOREIGN KEY([userIdRate])
REFERENCES [dbo].[tblUser] ([userId])
GO
/****** Object:  StoredProcedure [dbo].[sp_checkUser]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_checkUser]
(
	@userEmail varchar(50),
	@userPassword varchar(20),
	@ERROR varchar(20) out
)
as
begin
if exists( select userId from tblUser where userEmail like @userEmail and userPassword like @userPassword)
begin
	select userId from tblUser where userEmail like @userEmail and userPassword like @userPassword;
	set @ERROR = '1';
end
else
	begin
		set @ERROR = '0';
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DisplayArtistName]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DisplayArtistName]
as
begin
	select artistName, artistId from tblArtist where artistIsActive = 1;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertArtistSongMapping]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_InsertArtistSongMapping]
(
	@mapArtistId int,
	@mapSongId int
)
as
begin
	insert into tblArtistSongMapping values(@mapArtistId,@mapSongId);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNewArtist]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertNewArtist]
(
	@artistName varchar(20),
	@artistDOB date,
	@artistBio varchar(100),
	@artistIsActive int,
	@ERROR varchar(100) out
)
as
begin
if exists ( select * from tblArtist where artistName like @artistName and artistIsActive = 1)
begin
	set @ERROR = 'Artist already exists';
end
else
begin
	insert into tblArtist values
	(
		@artistName ,
		@artistDOB ,
		@artistBio ,
		@artistIsActive 
	);
	set @ERROR = 'Artist Added Successfully';
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNewSong]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertNewSong]
(
	@songName varchar(20),
	@songDOR date,
	@songImage image,
	@songIsActive int,
	@ERROR varchar(100) out
)
as
begin
	if exists(select songName from tblSong where songName like @songName)
	begin
		set @ERROR = 'Song already exists';
	end
	else
	begin
		insert into tblSong values (
								@songName,
								@songDOR,
								@songImage,
								@songIsActive
								);
		set @ERROR = 'Song Added Successfully';
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNewUser]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_InsertNewUser]
(
	@userName varchar(20),
	@userEmail varchar(50),
	@userPassword varchar(20),
	@ERROR varchar(100) out
)
as
begin
if exists (select userEmail from tblUser where userEmail like @userEmail)
begin
	set @ERROR = 'Email already exists';
end
else
	begin
		insert into tblUser values (@userName, @userEmail, @userPassword);
		set @ERROR = 'User Registered Successfully';
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUserRating]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_InsertUserRating]
(
	@userIdRate int,
	@songIdRate int,
	@rate int
)
as
begin
	if not exists(select songIdRate from tblUserRating where userIdRate = @userIdRate and songIdRate = @songIdRate)
	begin			
		insert into tblUserRating values (@userIdRate, @songIdRate, @rate);		
	end	
end
GO
/****** Object:  StoredProcedure [dbo].[sp_RetrieveSongId]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_RetrieveSongId]
as
begin
	select top 1 songId, songName from tblSong order by songId desc;
end
		
GO
/****** Object:  StoredProcedure [dbo].[sp_RetrieveSongs]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_RetrieveSongs]
as
begin
	SELECT songId, songName, songDOR, songImage,
	STUFF((SELECT ', ' +ARTISTNAME FROM viewArtistSong v	WHERE v.songId = v1.SONGID FOR XML PATH('')),1,1,'')
	ARTISTNAME FROM viewArtistSong v1
end


GO
/****** Object:  StoredProcedure [dbo].[sp_RetrieveTopArtists]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_RetrieveTopArtists]
as
select distinct v.artistId,
v.rateArtist, v.songsArtist, a.artistName, a.artistDOB
from viewSongListArtist v, tblArtist a, tblUserRating ur
where a.artistId = v.artistId


GO
/****** Object:  StoredProcedure [dbo].[sp_RetrieveTopSongs]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_RetrieveTopSongs]
(
	@para int
)
as
begin
	if @para = -1 
	begin
		SELECT distinct top 10 songId, songName, songDOR, ur.rate, 
		STUFF((SELECT ', ' +ARTISTNAME FROM viewArtistSong v WHERE v.songId = v1.SONGID FOR XML PATH('')),1,1,'')
		ARTISTNAME FROM viewArtistSong v1, tblUserRating ur
		where ur.songIdRate = v1.songId order by ur.rate desc;
	end
	else
	begin
		SELECT distinct top 10 songId, songName, songDOR, ur.rate,
		STUFF((SELECT ', ' +ARTISTNAME FROM viewArtistSong v WHERE v.songId = v1.SONGID FOR XML PATH('')),1,1,'')
		ARTISTNAME FROM viewArtistSong v1, tblUserRating ur
		where ur.songIdRate = v1.songId and ur.userIdRate = 2 order by ur.rate desc;
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_RetrieveUsers]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_RetrieveUsers]
as
begin
	select userId, userName,userEmail from tblUser
end
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchSongs]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_SearchSongs]
(
	@para varchar(20)
)
as
begin
SELECT songId, songName, songDOR, songImage,
	STUFF((SELECT ', ' +ARTISTNAME FROM viewArtistSong v	WHERE v.songId = v1.SONGID FOR XML PATH('')),1,1,'')
	ARTISTNAME FROM viewArtistSong v1 where v1.songName like '%'+@para+'%';
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ViewArtists]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ViewArtists]
as
begin
select artistId, artistName, artistDOB from tblArtist
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ViewSongs]    Script Date: 08-08-2022 02:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ViewSongs]
as
begin
SELECT distinct songId, songName, songDOR,
	STUFF((SELECT ', ' +ARTISTNAME FROM viewArtistSong v	WHERE v.songId = v1.SONGID FOR XML PATH('')),1,1,'')
	ARTISTNAME FROM viewArtistSong v1
end
GO
USE [master]
GO
ALTER DATABASE [dbStunningDisco] SET  READ_WRITE 
GO
