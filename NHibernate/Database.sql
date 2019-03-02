---------------------------------------------------------------------------------------------------------------------
USE [master]
GO
---------------------------------------------------------------------------------------------------------------------
CREATE DATABASE [Database]
GO
---------------------------------------------------------------------------------------------------------------------
USE [Database]
GO
---------------------------------------------------------------------------------------------------------------------
CREATE SCHEMA [User];
GO
---------------------------------------------------------------------------------------------------------------------
CREATE TABLE [User].[Users]
(
	[UserId]	[bigint]		IDENTITY(1,1) NOT NULL,
	[Name]		[varchar](50)	NOT NULL,
	[Surname]	[varchar](100)	NOT NULL,
	[Email]		[varchar](250)	NOT NULL,
	[Login]		[varchar](300)	NOT NULL,
	[Password]	[varchar](500)	NOT NULL,
	[Status]	[int]			NOT NULL,
	CONSTRAINT [PK_User.Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
) ON [PRIMARY]
GO
---------------------------------------------------------------------------------------------------------------------
CREATE TABLE [User].[UsersLogs]
(
	[UserLogId]	[bigint]		IDENTITY(1,1) NOT NULL,
	[UserId]	[bigint]		NOT NULL,
	[DateTime]	[datetime]		NOT NULL,
	[LogType]	[int]			NOT NULL,
	[Message]	[varchar](8000)	NULL,
	CONSTRAINT [PK_User.UsersLogs] PRIMARY KEY CLUSTERED ([UserLogId] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [User].[UsersLogs] WITH CHECK ADD CONSTRAINT [FK_User.UsersLogs_User.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [User].[Users] ([UserId])
GO

ALTER TABLE [User].[UsersLogs] CHECK CONSTRAINT [FK_User.UsersLogs_User.Users_UserId]
GO

ALTER TABLE [User].[UsersLogs] WITH CHECK ADD CONSTRAINT [FK97E7976FE6C3C04] FOREIGN KEY([UserId])
REFERENCES [User].[Users] ([UserId])
GO

ALTER TABLE [User].[UsersLogs] CHECK CONSTRAINT [FK97E7976FE6C3C04]
GO
---------------------------------------------------------------------------------------------------------------------
CREATE TABLE [User].[UsersRoles]
(
	[UserId]	[bigint]	NOT NULL,
	[Role]		[int]		NOT NULL,
	CONSTRAINT [PK_User.UsersRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [Role] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [User].[UsersRoles] WITH CHECK ADD CONSTRAINT [FK_User.UsersRoles_User.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [User].[Users] ([UserId])
GO

ALTER TABLE [User].[UsersRoles] CHECK CONSTRAINT [FK_User.UsersRoles_User.Users_UserId]
GO

ALTER TABLE [User].[UsersRoles] WITH CHECK ADD CONSTRAINT [FKCC264850E6C3C04] FOREIGN KEY([UserId])
REFERENCES [User].[Users] ([UserId])
GO

ALTER TABLE [User].[UsersRoles] CHECK CONSTRAINT [FKCC264850E6C3C04]
GO
---------------------------------------------------------------------------------------------------------------------