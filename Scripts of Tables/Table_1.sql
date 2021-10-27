USE [5admaa]
GO

/****** Object:  Table [dbo].[Table_1]    Script Date: 10/28/2021 1:37:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Table_1](
	[BarCode] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[NationalID] [nchar](14) NULL,
	[PersonType] [int] NULL,
	[HM] [int] NULL,
	[HM2] [int] NULL,
	[Address] [nvarchar](250) NULL,
	[Job] [nvarchar](350) NULL,
	[EducationID] [int] NULL,
	[Salary] [decimal](18, 3) NULL,
	[Total_Income] [int] NULL,
	[Total_Cost] [int] NULL,
	[Mobile] [nchar](11) NULL,
	[RecognitionFather] [nvarchar](250) NULL
) ON [PRIMARY]
GO

