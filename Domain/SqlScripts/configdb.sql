/* JJ Config managerEnvironment
     sqlcmd -S (localDB)\MsSqlLocalDb -i configdb.sql
*/

USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name='ConfigDatabase')
DROP DATABASE ConfigDatabase
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) -1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE ConfigDatabase
  ON PRIMARY (NAME = N''ConfigDatabase'', FILENAME = N''' + @device_directory + N'ConfigDatabase.mdf'')
  LOG ON (NAME = N''ConfigDatabase_log'',  FILENAME = N''' + @device_directory + N'ConfigDatabase.ldf'')')
GO

USE ConfigDatabase
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admin]') AND type in (N'U'))
DROP TABLE [dbo].[Admin]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Environment]') AND type in (N'U'))
DROP TABLE [dbo].[Environment]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Configdata]') AND type in (N'U'))
DROP TABLE [dbo].[Configdata]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Environment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Environment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EnvironmentName] [nvarchar] (10) NOT NULL,
	[Description] [nvarchar](30) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Configdata]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Configdata](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ConfigName] [nvarchar] (25) NOT NULL,
	[Application] [nvarchar](25) NOT NULL,
    [EnvironmentId] [bigint] NOT NULL,
    [ConfigValue] [nvarchar](200) NOT NULL,
    [Timestamp] [datetime] NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY (EnvironmentId) REFERENCES Environment(Id)
)
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Admin](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar] (15) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
)
END
GO

INSERT [dbo].[Admin] ([Username], [Password]) VALUES ('admin', 'passord' )

INSERT [dbo].[Admin] ([Username], [Password]) VALUES ('sjefen', 'bacon' )

INSERT [dbo].[Environment] ([EnvironmentName], [Description]) VALUES ('Dev', 'Development' )

INSERT [dbo].[Environment] ([EnvironmentName], [Description]) VALUES ('S-Test', 'System test' )

INSERT [dbo].[Environment] ([EnvironmentName], [Description]) VALUES ('A-Test', 'Acceptance test' )

INSERT [dbo].[Environment] ([EnvironmentName], [Description]) VALUES ('Prod', 'Production' )

INSERT [dbo].[Configdata] ([ConfigName], [Application], [EnvironmentId], [ConfigValue], [Timestamp]) 
				   VALUES ( 'ConnectionStrings', 'JJ Config manager', 1, '"ConfigManagerContext": "Server=(LocalDb)\\mssqllocaldb; Initial Catalog=ConfigDatabase; Integrated Security=True"', getdate() )

INSERT [dbo].[Configdata] ([ConfigName], [Application], [EnvironmentId], [ConfigValue], [Timestamp]) 
				   VALUES ( 'ConnectionStrings', 'JJ Config manager', 2, '"ConfigManagerContext": "Server=(LocalDb)\\mssqllocaldb; Initial Catalog=ConfigDatabase; Integrated Security=True"', getdate() )

INSERT [dbo].[Configdata] ([ConfigName], [Application], [EnvironmentId], [ConfigValue], [Timestamp]) 
				   VALUES ( 'Server', 'JJ Config manager', 2, 'Server=(LocalDb)\mssqllocaldb', getdate() )

INSERT [dbo].[Configdata] ([ConfigName], [Application], [EnvironmentId], [ConfigValue], [Timestamp]) 
				   VALUES ( 'ConnectionStrings', 'Bank 4 All', 1, '"Bank4AllContext": "Server=(LocalDb)\\mssqllocaldb; Initial Catalog=Bank4AllDatabase; Integrated Security=True"', getdate() )

INSERT [dbo].[Configdata] ([ConfigName], [Application], [EnvironmentId], [ConfigValue], [Timestamp]) 
				   VALUES ( 'ConnectionStrings', 'Bank 4 All', 4, '"Bank4AllContext": "Server=(LocalDb)\\mssqllocaldb; Initial Catalog=Bank4AllDatabase; Integrated Security=True"', getdate() )

INSERT [dbo].[Configdata] ([ConfigName], [Application], [EnvironmentId], [ConfigValue], [Timestamp]) 
				   VALUES ( 'Server', 'JJ Config manager', 1, '(LocalDb)\mssqllocaldb', getdate() )

INSERT [dbo].[Configdata] ([ConfigName], [Application], [EnvironmentId], [ConfigValue], [Timestamp]) 
				   VALUES ( 'Sqlcmd', 'JJ Config manager', 1, 'sqlcmd -S (localDB)\MsSqlLocalDb -i configdb.sql', getdate() )

