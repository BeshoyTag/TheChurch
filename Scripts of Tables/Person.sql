USE [5admaa]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 10/28/2021 1:37:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Birthday] [datetime2](7) NULL,
	[Mobile] [nchar](11) NULL,
	[Telephone] [varchar](20) NULL,
	[BarCode] [nvarchar](50) NULL,
	[EducationID] [int] NULL,
	[QualificationID] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[RecognitionFather] [nvarchar](250) NULL,
	[KhadmaID] [int] NULL,
	[Khadem] [nvarchar](250) NULL,
	[Gender] [bit] NULL,
	[SocialStatus] [nvarchar](50) NULL,
	[PersonType] [int] NULL,
	[Salary] [decimal](18, 3) NULL,
	[Address] [nvarchar](250) NULL,
	[Notes] [nvarchar](max) NULL,
	[CurchID] [int] NULL,
	[CityID] [int] NULL,
	[Image] [nvarchar](max) NULL,
	[Job] [nvarchar](350) NULL,
	[NationalID] [nchar](14) NULL,
	[HM] [int] NULL,
	[Total_Income] [int] NULL,
	[Total_Cost] [int] NULL,
 CONSTRAINT [PK_Person_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Church] FOREIGN KEY([CurchID])
REFERENCES [dbo].[Church] ([ID])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Church]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_City]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Education] FOREIGN KEY([EducationID])
REFERENCES [dbo].[Education] ([ID])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Education]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Khadma] FOREIGN KEY([KhadmaID])
REFERENCES [dbo].[Khadma] ([ID])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Khadma]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Qualification] FOREIGN KEY([QualificationID])
REFERENCES [dbo].[Qualification] ([ID])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Qualification]
GO

