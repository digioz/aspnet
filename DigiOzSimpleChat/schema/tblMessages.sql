SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMessages](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[message] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[timestamp] [datetime] NULL CONSTRAINT [DF_tblMessages_timestamp]  DEFAULT (getdate())
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF