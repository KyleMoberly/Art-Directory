SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categories](
	[CatID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CategoryCD] [char](2) NOT NULL,
	[CategoryDescription] [varchar](100) NOT NULL,
	[CatParentID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Roles](
	[RoleID] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateCD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StateCD](
	[stateCD] [char](2) NOT NULL,
	[stateDescription] [nchar](50) NOT NULL,
 CONSTRAINT [PK_StateCD] PRIMARY KEY CLUSTERED 
(
	[stateCD] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Person]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Person](
	[personId] [varchar](25) NOT NULL,
	[personFirstName] [varchar](50) NOT NULL,
	[personLastName] [nchar](10) NOT NULL,
	[personPass] [varchar](50) NOT NULL,
	[personEmail] [varchar](100) NOT NULL,
	[modDt] [datetime] NOT NULL,
	[RoleID] [varchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ranking]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Ranking](
	[rankId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[listId] [numeric](18, 0) NOT NULL,
	[rankNum] [int] NULL,
 CONSTRAINT [PK_Ranking] PRIMARY KEY CLUSTERED 
(
	[rankId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[list2categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[list2categories](
	[listId] [numeric](18, 0) NOT NULL,
	[CatId] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_list2categories] PRIMARY KEY CLUSTERED 
(
	[listId] ASC,
	[CatId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Projects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Projects](
	[projectId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[projectName] [varchar](150) NOT NULL,
	[projectDates] [varchar](250) NULL,
	[projectUrl] [varchar](150) NOT NULL,
	[projectDesc] [varchar](250) NOT NULL,
	[listId] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[projectId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ArtListing]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ArtListing](
	[listName] [varchar](100) NOT NULL,
	[listId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[listPhone] [varchar](10) NULL,
	[listAddress1] [varchar](150) NULL,
	[listAddress2] [varchar](150) NULL,
	[listCity] [varchar](100) NULL,
	[stateCD] [char](2) NULL,
	[listZip] [varchar](50) NULL,
	[listEmail] [varchar](100) NULL,
	[personId] [varchar](25) NOT NULL,
	[activeYN] [bit] NOT NULL,
	[modDt] [datetime] NOT NULL,
	[listUrl] [varchar](250) NULL,
	[listFeaturedYN] [bit] NOT NULL,
	[listPhoto] [varchar](250) NULL,
	[listDescription] [varchar](max) NULL,
 CONSTRAINT [PK_ArtListing] PRIMARY KEY CLUSTERED 
(
	[listId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Categories_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Categories]'))
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([CatParentID])
REFERENCES [dbo].[Categories] ([CatID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ranking_ArtListing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ranking]'))
ALTER TABLE [dbo].[Ranking]  WITH CHECK ADD  CONSTRAINT [FK_Ranking_ArtListing] FOREIGN KEY([listId])
REFERENCES [dbo].[ArtListing] ([listId])
GO
ALTER TABLE [dbo].[Ranking] CHECK CONSTRAINT [FK_Ranking_ArtListing]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_list2categories_ArtListing]') AND parent_object_id = OBJECT_ID(N'[dbo].[list2categories]'))
ALTER TABLE [dbo].[list2categories]  WITH CHECK ADD  CONSTRAINT [FK_list2categories_ArtListing] FOREIGN KEY([listId])
REFERENCES [dbo].[ArtListing] ([listId])
GO
ALTER TABLE [dbo].[list2categories] CHECK CONSTRAINT [FK_list2categories_ArtListing]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_list2categories_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[list2categories]'))
ALTER TABLE [dbo].[list2categories]  WITH CHECK ADD  CONSTRAINT [FK_list2categories_Categories] FOREIGN KEY([CatId])
REFERENCES [dbo].[Categories] ([CatID])
GO
ALTER TABLE [dbo].[list2categories] CHECK CONSTRAINT [FK_list2categories_Categories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Projects_ArtListing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ArtListing] FOREIGN KEY([listId])
REFERENCES [dbo].[ArtListing] ([listId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ArtListing]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArtListing_Person]') AND parent_object_id = OBJECT_ID(N'[dbo].[ArtListing]'))
ALTER TABLE [dbo].[ArtListing]  WITH CHECK ADD  CONSTRAINT [FK_ArtListing_Person] FOREIGN KEY([personId])
REFERENCES [dbo].[Person] ([personId])
GO
ALTER TABLE [dbo].[ArtListing] CHECK CONSTRAINT [FK_ArtListing_Person]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArtListing_StateCD]') AND parent_object_id = OBJECT_ID(N'[dbo].[ArtListing]'))
ALTER TABLE [dbo].[ArtListing]  WITH CHECK ADD  CONSTRAINT [FK_ArtListing_StateCD] FOREIGN KEY([stateCD])
REFERENCES [dbo].[StateCD] ([stateCD])
GO
ALTER TABLE [dbo].[ArtListing] CHECK CONSTRAINT [FK_ArtListing_StateCD]
