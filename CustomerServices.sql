USE [CustomerServices]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 16/11/2020 10:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[customerId] [int] NOT NULL,
	[docType] [varchar](5) NULL,
	[docNum] [varchar](10) NULL,
	[email] [varchar](120) NULL,
	[givenName] [varchar](25) NULL,
	[familyName] [varchar](25) NULL,
	[phone] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 16/11/2020 10:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[serviceId] [int] NOT NULL,
	[productName] [varchar](120) NULL,
	[productNameType] [varchar](10) NULL,
	[numeracioTerminal] [int] NULL,
	[soldAt] [datetime] NULL,
	[customerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[serviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
