SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUsersOnline](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[timestamp] [datetime] NOT NULL CONSTRAINT [DF_tblUsersOnline_timestamp]  DEFAULT (getdate())
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF