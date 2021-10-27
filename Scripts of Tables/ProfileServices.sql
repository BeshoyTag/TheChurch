USE [5admaa]
GO

/****** Object:  Table [dbo].[ProfileServices]    Script Date: 10/28/2021 1:37:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProfileServices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BarCode] [nvarchar](250) NOT NULL,
	[ServiceID] [int] NOT NULL,
	[EnterDate] [datetime] NOT NULL,
	[Attachment] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProfileServices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProfileServices] ADD  CONSTRAINT [DF_ProfileServices_EnterDate]  DEFAULT (getdate()) FOR [EnterDate]
GO

ALTER TABLE [dbo].[ProfileServices]  WITH CHECK ADD  CONSTRAINT [FK_ProfileServices_ProfileServices1] FOREIGN KEY([ID])
REFERENCES [dbo].[ProfileServices] ([ID])
GO

ALTER TABLE [dbo].[ProfileServices] CHECK CONSTRAINT [FK_ProfileServices_ProfileServices1]
GO

ALTER TABLE [dbo].[ProfileServices]  WITH CHECK ADD  CONSTRAINT [FK_ProfileServices_service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[service] ([ID])
GO

ALTER TABLE [dbo].[ProfileServices] CHECK CONSTRAINT [FK_ProfileServices_service]
GO

