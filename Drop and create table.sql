

/****** Object:  Table [dbo].[ConfEq]    Script Date: 03/05/2022 09:15:45 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfEq]') AND type in (N'U'))
DROP TABLE [dbo].[ConfEq]
GO



CREATE TABLE [dbo].[ConfEq](
	[pid] [int] IDENTITY(1,1) NOT NULL,
	[programa] [varchar](50) NOT NULL,
	[comandos] [varchar](50) NOT NULL,
	[fechacarga] [datetime] NOT NULL,
	[activo] [int] NOT NULL
) ON [PRIMARY]
GO


