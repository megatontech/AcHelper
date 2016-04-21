
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/05/2014 23:12:25
-- Generated from EDMX file: C:\Users\Administrator\Desktop\Acfun\HClient\Data\DBEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[DBModelStoreContainer].[CONFIG]', 'U') IS NOT NULL
    DROP TABLE [DBModelStoreContainer].[CONFIG];
GO
IF OBJECT_ID(N'[DBModelStoreContainer].[COOKIE]', 'U') IS NOT NULL
    DROP TABLE [DBModelStoreContainer].[COOKIE];
GO
IF OBJECT_ID(N'[DBModelStoreContainer].[GROUP]', 'U') IS NOT NULL
    DROP TABLE [DBModelStoreContainer].[GROUP];
GO
IF OBJECT_ID(N'[DBModelStoreContainer].[IMG]', 'U') IS NOT NULL
    DROP TABLE [DBModelStoreContainer].[IMG];
GO
IF OBJECT_ID(N'[DBModelStoreContainer].[PO]', 'U') IS NOT NULL
    DROP TABLE [DBModelStoreContainer].[PO];
GO
IF OBJECT_ID(N'[DBModelStoreContainer].[POST]', 'U') IS NOT NULL
    DROP TABLE [DBModelStoreContainer].[POST];
GO
IF OBJECT_ID(N'[DBModelStoreContainer].[THREAD]', 'U') IS NOT NULL
    DROP TABLE [DBModelStoreContainer].[THREAD];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CONFIG'
CREATE TABLE [dbo].[CONFIG] (
    [CONFIG_NAME] nvarchar(10485760)  NOT NULL,
    [CONFIG_ID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'COOKIE'
CREATE TABLE [dbo].[COOKIE] (
    [ID] uniqueidentifier  NOT NULL,
    [USERID] nvarchar(10485760)  NULL,
    [SAILSID] nvarchar(10485760)  NULL,
    [TC] nvarchar(10485760)  NULL,
    [DB] blob  NULL,
    [NO] nvarchar(10485760)  NULL
);
GO

-- Creating table 'GROUP'
CREATE TABLE [dbo].[GROUP] (
    [GROUP_ID] uniqueidentifier  NOT NULL,
    [GROUP_TITLE] nvarchar(10485760)  NOT NULL,
    [GROUP_IMG] nvarchar(10485760)  NULL,
    [GROUP_NO] integer  NULL
);
GO

-- Creating table 'IMG'
CREATE TABLE [dbo].[IMG] (
    [IMG_ID] uniqueidentifier  NOT NULL,
    [IMG_DIR] nvarchar(10485760)  NULL,
    [IMG_TYPE] nvarchar(10485760)  NULL,
    [IMG_ISTHUMB] integer  NULL
);
GO

-- Creating table 'PO'
CREATE TABLE [dbo].[PO] (
    [ID] uniqueidentifier  NOT NULL,
    [ISBAN] nvarchar(10485760)  NULL,
    [USED_ID] nvarchar(10485760)  NULL
);
GO

-- Creating table 'POST'
CREATE TABLE [dbo].[POST] (
    [POST_ID] uniqueidentifier  NOT NULL,
    [POST_TITLE] nvarchar(10485760)  NULL,
    [POST_EMAIL] nvarchar(10485760)  NULL,
    [POST_TIME] nvarchar(10485760)  NULL,
    [POST_NAME] nvarchar(10485760)  NULL,
    [POST_IMG] nvarchar(10485760)  NULL,
    [POST_CONTENT] nvarchar(10485760)  NULL,
    [THREAD_ID] nvarchar(10485760)  NULL
);
GO

-- Creating table 'THREAD'
CREATE TABLE [dbo].[THREAD] (
    [THREAD_ID] uniqueidentifier  NOT NULL,
    [THREAD_TITLE] nvarchar(10485760)  NULL,
    [THREAD_EMAIL] nvarchar(10485760)  NULL,
    [THREAD_TIME] nvarchar(10485760)  NULL,
    [THREAD_IMG] nvarchar(10485760)  NULL,
    [THREAD_NAME] nvarchar(10485760)  NULL,
    [THREAD_ISVISIBLE] integer  NULL,
    [THREAD_ISSAGE] integer  NULL,
    [THREAD_ISFOCUS] integer  NULL,
    [THREAD_ISDAILY] integer  NULL,
    [GROUP_ID] nvarchar(10485760)  NOT NULL,
    [THREAD_CONTENT] nvarchar(10485760)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CONFIG_NAME], [CONFIG_ID] in table 'CONFIG'
ALTER TABLE [dbo].[CONFIG]
ADD CONSTRAINT [PK_CONFIG]
    PRIMARY KEY CLUSTERED ([CONFIG_NAME], [CONFIG_ID] ASC);
GO

-- Creating primary key on [ID] in table 'COOKIE'
ALTER TABLE [dbo].[COOKIE]
ADD CONSTRAINT [PK_COOKIE]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [GROUP_ID], [GROUP_TITLE] in table 'GROUP'
ALTER TABLE [dbo].[GROUP]
ADD CONSTRAINT [PK_GROUP]
    PRIMARY KEY CLUSTERED ([GROUP_ID], [GROUP_TITLE] ASC);
GO

-- Creating primary key on [IMG_ID] in table 'IMG'
ALTER TABLE [dbo].[IMG]
ADD CONSTRAINT [PK_IMG]
    PRIMARY KEY CLUSTERED ([IMG_ID] ASC);
GO

-- Creating primary key on [ID] in table 'PO'
ALTER TABLE [dbo].[PO]
ADD CONSTRAINT [PK_PO]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [POST_ID] in table 'POST'
ALTER TABLE [dbo].[POST]
ADD CONSTRAINT [PK_POST]
    PRIMARY KEY CLUSTERED ([POST_ID] ASC);
GO

-- Creating primary key on [THREAD_ID], [GROUP_ID] in table 'THREAD'
ALTER TABLE [dbo].[THREAD]
ADD CONSTRAINT [PK_THREAD]
    PRIMARY KEY CLUSTERED ([THREAD_ID], [GROUP_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------