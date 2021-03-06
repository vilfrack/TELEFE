USE [Coordenadas]
GO
/****** Object:  Table [dbo].[TableCoordenadas]    Script Date: 18/11/2018 12:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TableCoordenadas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coordenadas] [varchar](10) NULL,
	[palabra] [varchar](50) NULL,
 CONSTRAINT [PK_TableCoordenadas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
