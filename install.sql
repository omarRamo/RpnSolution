CREATE DATABASE [RpnCalculation]
GO

/****** Object:  Table [dbo].[T_Line]    Script Date: 28/02/2022 21:23:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Use [RpnCalculation]
CREATE TABLE [dbo].[T_Line](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Value] [float] NULL,
[ModifiedOn] [datetime] NULL CONSTRAINT [DF_T_Lines_ModifiedOn]  DEFAULT (getdate()),
 CONSTRAINT [PK_T_Lines] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO