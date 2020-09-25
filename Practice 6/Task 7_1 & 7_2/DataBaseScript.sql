USE [master]
GO

CREATE DATABASE [Task 6]
CONTAINMENT = NONE
ON  PRIMARY 

GO
ALTER DATABASE [Task 6] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Task 6].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Task 6] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Task 6] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Task 6] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Task 6] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Task 6] SET ARITHABORT OFF 
GO
ALTER DATABASE [Task 6] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Task 6] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Task 6] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Task 6] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Task 6] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Task 6] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Task 6] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Task 6] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Task 6] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Task 6] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Task 6] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Task 6] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Task 6] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Task 6] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Task 6] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Task 6] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Task 6] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Task 6] SET RECOVERY FULL 
GO
ALTER DATABASE [Task 6] SET  MULTI_USER 
GO
ALTER DATABASE [Task 6] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Task 6] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Task 6] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Task 6] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Task 6] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Task 6', N'ON'
GO
ALTER DATABASE [Task 6] SET QUERY_STORE = OFF
GO
USE [Task 6]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [uniqueidentifier] NOT NULL,
	[AuthenticationID] [int] NOT NULL,
	[AutorisationID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account.Authentication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Authentication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account.Autorisation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Autorisation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account.User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountAndBonus](
	[AccountID] [uniqueidentifier] NOT NULL,
	[BonusID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bonus](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Bonus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account.Authentication] FOREIGN KEY([AuthenticationID])
REFERENCES [dbo].[Account.Authentication] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Account.Authentication]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account.Autorisation] FOREIGN KEY([AutorisationID])
REFERENCES [dbo].[Account.Autorisation] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Account.Autorisation]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account.User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Account.User] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Account.User]
GO
ALTER TABLE [dbo].[AccountAndBonus]  WITH CHECK ADD  CONSTRAINT [FK_AccountAndBonus_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountAndBonus] CHECK CONSTRAINT [FK_AccountAndBonus_Account]
GO
ALTER TABLE [dbo].[AccountAndBonus]  WITH CHECK ADD  CONSTRAINT [FK_AccountAndBonus_Bonus] FOREIGN KEY([BonusID])
REFERENCES [dbo].[Bonus] ([Id])
GO
ALTER TABLE [dbo].[AccountAndBonus] CHECK CONSTRAINT [FK_AccountAndBonus_Bonus]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_AddUser]
	@Id uniqueidentifier,
	@Login nvarchar(20),
	@Password nvarchar(20),
	@Role nvarchar(20),
	@Name nvarchar(20),
	@DateOfBirth datetime

AS
BEGIN
	SET NOCOUNT off;

	declare
		@AuthenticationID int,
		@AutorisationID int,
		@UserID int

	insert into [Account.Authentication] (Login, Password) values (@Login, @Password);

	set @AuthenticationID = @@IDENTITY;

	insert into [Account.Autorisation] (Role) values (@Role);

	set @AutorisationID = @@IDENTITY;

	insert into [Account.User] (Name, DateOfBirth) values (@Name, @DateOfBirth);

	set @UserID = @@IDENTITY;

	insert into Account (Id, AuthenticationID, AutorisationID, UserID) values (@Id, @AuthenticationID, @AutorisationID, @UserID);

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_ChangeUser]
	@Id uniqueidentifier,
	@Login nvarchar(20),
	@Password nvarchar(20),
	@Role nvarchar(20),
	@Name nvarchar(20),
	@DateOfBirth datetime
	

AS
BEGIN
	SET NOCOUNT off;

	declare
		@AuthenticationID int,
		@AutorisationID int,
		@UserID int

	select 
		@AuthenticationID = AuthenticationID,
		@AutorisationID = AutorisationID,
		@UserID = UserID
	from Account where Id = @Id;

	update [Account.Authentication] set 
		Login = @Login, 
		Password = @Password
	where Id = @AuthenticationID;

	update [Account.Autorisation] set
		Role = @Role
	where Id = @AutorisationID;

	update [Account.User] set
		Name = @Name,
		DateOfBirth = @DateOfBirth
	where Id = @UserID;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_GetAllUsers]

AS
BEGIN
	SET NOCOUNT on;

	select 
		Account.Id,
		[Account.Authentication].Login,
		[Account.Authentication].Password,
		[Account.Autorisation].Role,
		[Account.User].Name,
		[Account.User].DateOfBirth
	from Account
	inner join [Account.Authentication] on [Account.Authentication].Id = Account.AuthenticationID
	inner join [Account.Autorisation] on [Account.Autorisation].Id = Account.AutorisationID
	inner join [Account.User] on [Account.User].Id = Account.UserID;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_GetUser]
		@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT on;

	declare
		@AuthenticationID int,
		@AutorisationID int,
		@UserID int

	select 
		@AuthenticationID = AuthenticationID,
		@AutorisationID = AutorisationID,
		@UserID = UserID
	from Account where Id = @Id;

	select 
		Account.Id,
		[Account.Authentication].Login,
		[Account.Authentication].Password,
		[Account.Autorisation].Role,
		[Account.User].Name,
		[Account.User].DateOfBirth
	from Account
	inner join [Account.Authentication] on [Account.Authentication].Id = @AuthenticationID
	inner join [Account.Autorisation] on [Account.Autorisation].Id = @AutorisationID
	inner join [Account.User] on [Account.User].Id = @UserID
	where Account.Id = @Id;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_IsUser]
		@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT on;

	select Account.Id from Account
	where Account.Id = @Id;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_RemoveUser]
	@Id uniqueidentifier


AS
BEGIN
	SET NOCOUNT off;

	declare
		@AuthenticationID int,
		@AutorisationID int,
		@UserID int

	select 
		@AuthenticationID = AuthenticationID,
		@AutorisationID = AutorisationID,
		@UserID = UserID
	from Account where Id = @Id;

	delete from Account
	where Id = @Id;

	delete from [Account.Authentication]
	where Id = @AuthenticationID;

	delete from [Account.Autorisation]
	where Id = @AutorisationID;

	delete from [Account.User]
	where Id = @UserID;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountAndBonus_AddDependUserAndBonuss]
	@UserId uniqueidentifier,
	@BonusId uniqueidentifier

AS
BEGIN
	SET NOCOUNT off;

    Insert into AccountAndBonus (AccountID, BonusID) values (@UserId, @BonusId);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountAndBonus_GetAllBonusedUserGuids]
	@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT ON;

	select AccountAndBonus.AccountID from AccountAndBonus
	where AccountAndBonus.BonusID = @Id;
end
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountAndBonus_GetAllСustomBonusGuids]
	@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT ON;

	select AccountAndBonus.BonusID from AccountAndBonus
	where AccountAndBonus.AccountID = @Id;
end
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountAndBonus_RemoveDependUserAndBonuss]
	@UserId uniqueidentifier,
	@BonusId uniqueidentifier

AS
BEGIN
	SET NOCOUNT off;

	delete from AccountAndBonus
	where AccountID = @UserId and BonusID = @BonusId;

end
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bonus_AddBonus]
	@Id uniqueidentifier,
	@Title nvarchar(20)

AS
BEGIN
	SET NOCOUNT off;

    insert into Bonus (Id, Title) values (@Id, @Title);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bonus_GetAllBonuss]

AS
BEGIN
	SET NOCOUNT ON;

	select * from Bonus;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bonus_GetBonus]
	@Id uniqueidentifier
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * from Bonus
	where Bonus.Id = @Id;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bonus_RemoveBonus]
	@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT off;

    delete from Bonus
	where Id = @Id;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bonuss_ChangeBonus]
	@Id uniqueidentifier,
	@Title nvarchar(20)

AS
BEGIN
	SET NOCOUNT off;

	update Bonus set Title = @Title
	where Id = @Id;

END
GO
USE [master]
GO
ALTER DATABASE [Task 6] SET  READ_WRITE 
GO