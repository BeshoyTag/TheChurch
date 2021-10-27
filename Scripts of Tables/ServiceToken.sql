USE [5admaa]
GO

/****** Object:  Table [dbo].[ServiceToken]    Script Date: 10/28/2021 1:37:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ServiceToken](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BarCode] [nvarchar](250) NOT NULL,
	[ServiceID] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_ServiceToken] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ServiceToken] ADD  CONSTRAINT [DF_ServiceToken_DateTime]  DEFAULT (getdate()) FOR [DateTime]
GO

ALTER TABLE [dbo].[ServiceToken]  WITH CHECK ADD  CONSTRAINT [FK_ServiceToken_service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[service] ([ID])
GO

ALTER TABLE [dbo].[ServiceToken] CHECK CONSTRAINT [FK_ServiceToken_service]
GO

