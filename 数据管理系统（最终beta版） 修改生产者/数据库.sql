USE [bst]
GO
/****** Object:  Table [dbo].[t_user]    Script Date: 02/26/2014 22:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uname] [nvarchar](50) NOT NULL,
	[upwd] [nvarchar](50) NOT NULL,
	[uqxz] [int] NOT NULL,
	[uzt] [int] NOT NULL,
 CONSTRAINT [PK_t_user] PRIMARY KEY CLUSTERED 
(
	[uname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_scz]    Script Date: 02/26/2014 22:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_scz](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[scz] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_t_scz] PRIMARY KEY CLUSTERED 
(
	[scz] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_scb]    Script Date: 02/26/2014 22:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_scb](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gh] [nvarchar](50) NOT NULL,
	[cz] [nvarchar](50) NOT NULL,
	[dz] [float] NOT NULL,
	[sl] [int] NOT NULL,
	[zl]  AS ([dz]*[sl]),
	[bz] [nvarchar](50) NULL,
	[sj] [date] NOT NULL,
	[producter] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_t_scb] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_log]    Script Date: 02/26/2014 22:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[czmc] [nvarchar](50) NOT NULL,
	[czms] [nvarchar](50) NOT NULL,
	[czuser] [nvarchar](50) NOT NULL,
	[czsj] [date] NOT NULL,
 CONSTRAINT [PK_t_log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_ggb]    Script Date: 02/26/2014 22:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_ggb](
	[gh] [nvarchar](50) NOT NULL,
	[mc] [nvarchar](50) NULL,
	[gg] [nvarchar](50) NULL,
	[th] [nvarchar](50) NULL,
	[sbh] [nvarchar](50) NULL,
	[cz] [nvarchar](50) NULL,
	[dz] [float] NOT NULL,
	[sl] [int] NULL,
	[bz] [nvarchar](50) NULL,
	[belongkh] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_czb]    Script Date: 02/26/2014 22:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_czb](
	[czbh] [int] IDENTITY(1,1) NOT NULL,
	[czmc] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
