USE [5admaa]
GO

/****** Object:  Table [dbo].[FromExellSheet]    Script Date: 11/19/2021 5:01:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FromExellSheet](
	[col1] [nvarchar](50) NULL,
	[col2] [nvarchar](50) NULL,
	[col3] [nvarchar](50) NULL,
	[col4] [nvarchar](50) NULL,
	[col5] [nvarchar](50) NULL,
	[col6] [nvarchar](50) NULL,
	[col7] [nvarchar](50) NULL,
	[col8] [nvarchar](50) NULL,
	[col9] [nvarchar](50) NULL,
	[col10] [nvarchar](50) NULL,
	[col11] [nvarchar](50) NULL,
	[col12] [nvarchar](50) NULL,
	[col13] [nvarchar](50) NULL,
	[col14] [nvarchar](50) NULL
) ON [PRIMARY]
GO

USE [5admaa]
GO

INSERT INTO [dbo].[Person]([BarCode],[Name],[NationalID]
 ,[SocialStatus] ,[KhadmaID],[HM],[Address],[Job],[EducationID]
  ,[Salary],[Total_Income],[Total_Cost],[Mobile] ,[RecognitionFather])

SELECT [col1],[col2],[col3],[col4],[col5]
      ,[col6]
      ,[col7]
      ,[col8]
      ,[col9]
      ,[col10]
      ,[col11]
      ,[col12]
      ,[col13]
      ,[col14]
  FROM [dbo].[FromExellSheet]