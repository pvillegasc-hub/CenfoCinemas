USE [cenfocinemas-db]
GO

/****** Objeto: Table [dbo].[tbIuser] Fecha de script: 5/6/2026 19:48:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbIuser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[UserCode] [nvarchar](25) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Status] [nvarchar](2) NOT NULL,
	[PhoneNumber] [int] NULL,
 CONSTRAINT [PK_tbIuser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


