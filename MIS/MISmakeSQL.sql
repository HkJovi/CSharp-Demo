USE [MIS]
GO
/****** Object:  Table [dbo].[t_zczt]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_zczt](
	[zcbz] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[t_zczt] ([zcbz]) VALUES (1)
/****** Object:  Table [dbo].[t_xx]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_xx](
	[xjid] [nvarchar](50) NOT NULL,
	[xjtm] [nvarchar](50) NOT NULL,
	[xjnr] [nvarchar](max) NOT NULL,
	[time] [datetime] NOT NULL,
 CONSTRAINT [PK_t_xx] PRIMARY KEY CLUSTERED 
(
	[xjid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_User]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_User](
	[uID] [nvarchar](50) NOT NULL,
	[uZH] [nvarchar](50) NOT NULL,
	[uPW] [nvarchar](50) NOT NULL,
	[uJBZ] [int] NOT NULL,
	[uZT] [int] NOT NULL,
	[uSF] [int] NOT NULL,
 CONSTRAINT [PK_t_User] PRIMARY KEY CLUSTERED 
(
	[uID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[t_User] ([uID], [uZH], [uPW], [uJBZ], [uZT], [uSF]) VALUES (N'00001', N'aaa', N'1', 1, 1, 1)
INSERT [dbo].[t_User] ([uID], [uZH], [uPW], [uJBZ], [uZT], [uSF]) VALUES (N'00002', N'admin', N'a', 2, 1, 4)
/****** Object:  Table [dbo].[t_sjx]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sjx](
	[xjid] [nvarchar](50) NOT NULL,
	[jszh] [nvarchar](50) NOT NULL,
	[ydbz] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sf]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sf](
	[zcbz] [int] NOT NULL,
	[sfid] [int] NOT NULL,
	[sfmc] [nvarchar](50) NOT NULL,
	[uqxz] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[t_sf] ([zcbz], [sfid], [sfmc], [uqxz]) VALUES (1, 1, N'学生', 1)
INSERT [dbo].[t_sf] ([zcbz], [sfid], [sfmc], [uqxz]) VALUES (1, 2, N'教师', 1)
INSERT [dbo].[t_sf] ([zcbz], [sfid], [sfmc], [uqxz]) VALUES (1, 3, N'职工', 1)
INSERT [dbo].[t_sf] ([zcbz], [sfid], [sfmc], [uqxz]) VALUES (0, 4, N'管理员', 2)
/****** Object:  Table [dbo].[t_qxz]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_qxz](
	[zid] [int] NOT NULL,
	[zmc] [nvarchar](50) NOT NULL,
	[zqx] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[t_qxz] ([zid], [zmc], [zqx]) VALUES (1, N'部分权限', N'部分权限')
INSERT [dbo].[t_qxz] ([zid], [zmc], [zqx]) VALUES (2, N'所有权限', N'所有权限')
/****** Object:  Table [dbo].[t_qx]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_qx](
	[qxid] [int] NOT NULL,
	[qxmc] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_ID]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_ID](
	[ID] [nvarchar](50) NOT NULL,
	[IDzt] [int] NOT NULL,
	[IDsf] [int] NOT NULL,
	[IDjbz] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[t_ID] ([ID], [IDzt], [IDsf], [IDjbz]) VALUES (N'10000', 1, 4, 1)
INSERT [dbo].[t_ID] ([ID], [IDzt], [IDsf], [IDjbz]) VALUES (N'00001', 1, 1, 1)
INSERT [dbo].[t_ID] ([ID], [IDzt], [IDsf], [IDjbz]) VALUES (N'00002', 1, 2, 1)
INSERT [dbo].[t_ID] ([ID], [IDzt], [IDsf], [IDjbz]) VALUES (N'00003', 1, 3, 1)
/****** Object:  Table [dbo].[t_gg]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_gg](
	[ggid] [int] NOT NULL,
	[gg] [nvarchar](max) NOT NULL,
	[time] [datetime] NOT NULL,
	[tm] [ntext] NOT NULL,
 CONSTRAINT [PK_t_gg] PRIMARY KEY CLUSTERED 
(
	[ggid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (1, N'33', CAST(0x0000A21901767CC0 AS DateTime), N'qq')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (2, N'222', CAST(0x0000A21901767108 AS DateTime), N'qqq')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (3, N'1111111111', CAST(0x0000A2190176667C AS DateTime), N'www')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (4, N'9999', CAST(0x0000A21901758C84 AS DateTime), N'22222222222')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (5, N'8888', CAST(0x0000A21901758324 AS DateTime), N'1')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (6, N'77777777777777', CAST(0x0000A21901756F38 AS DateTime), N'22222222222222222')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (7, N'66666', CAST(0x0000A219017557C8 AS DateTime), N'22222222222')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (8, N'55', CAST(0x0000A21901754508 AS DateTime), N'2222222')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (9, N'如果是SQL Server 2005及以后的版本用nvarchar(max)，如果是之前版本用text。另外是否改变格式与前端应用有关，如果前端应用就是保持原有格式提交给数据库那么格式就不会变。如果前端应用就已经把格式改变了，那么到数据库这也没什么办法了。', CAST(0x0000A21901753950 AS DateTime), N'22')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (10, N'333333333333333', CAST(0x0000A2190174EE50 AS DateTime), N'111111111111111111111')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (11, N'2222222222222', CAST(0x0000A2190174DF14 AS DateTime), N'test222222222')
INSERT [dbo].[t_gg] ([ggid], [gg], [time], [tm]) VALUES (12, N'111111111111111', CAST(0x0000A2190174D230 AS DateTime), N'test11111')
/****** Object:  Table [dbo].[t_fjx]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_fjx](
	[xjid] [nvarchar](50) NOT NULL,
	[fszh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_t_fjx] PRIMARY KEY CLUSTERED 
(
	[xjid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_dlxx]    Script Date: 08/28/2013 01:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_dlxx](
	[uZH] [nvarchar](50) NOT NULL,
	[DLtime] [datetime] NOT NULL,
	[DLIP] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_t_dlxx] PRIMARY KEY CLUSTERED 
(
	[DLtime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
