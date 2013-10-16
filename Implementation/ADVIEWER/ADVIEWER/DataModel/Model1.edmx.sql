
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/16/2013 22:31:17
-- Generated from EDMX file: E:\se2\ADVIEWER\ADVIEWER\DataModel\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ADVIEWERdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GroupGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_GroupGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_StateCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cities] DROP CONSTRAINT [FK_StateCity];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDataAdvetisement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advetisements] DROP CONSTRAINT [FK_UserDataAdvetisement];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets1] DROP CONSTRAINT [FK_UserTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroup_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserGroup] DROP CONSTRAINT [FK_UserGroup_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserGroup] DROP CONSTRAINT [FK_UserGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_StateAdvetisement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advetisements] DROP CONSTRAINT [FK_StateAdvetisement];
GO
IF OBJECT_ID(N'[dbo].[FK_CityAdvetisement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advetisements] DROP CONSTRAINT [FK_CityAdvetisement];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Advetisements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Advetisements];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Tickets1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets1];
GO
IF OBJECT_ID(N'[dbo].[States]', 'U') IS NOT NULL
    DROP TABLE [dbo].[States];
GO
IF OBJECT_ID(N'[dbo].[Payments1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments1];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[ContactMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactMessages];
GO
IF OBJECT_ID(N'[dbo].[AdvertisementMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvertisementMessages];
GO
IF OBJECT_ID(N'[dbo].[Mail_User1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mail_User1];
GO
IF OBJECT_ID(N'[dbo].[UserGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroup];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Advetisements'
CREATE TABLE [dbo].[Advetisements] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [GroupID] int  NOT NULL,
    [SateID] int  NOT NULL,
    [StarCount] int  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(300)  NULL,
    [Text] nvarchar(max)  NOT NULL,
    [KeyWords] nvarchar(300)  NULL,
    [Pic] nvarchar(200)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsConfirmed] bit  NULL,
    [IsPaid] bit  NULL,
    [IsRead] bit  NULL,
    [ConfirmMsg] nvarchar(max)  NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [Tell] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [Address] nvarchar(1000)  NULL,
    [Email] nvarchar(100)  NOT NULL,
    [YahooID] nvarchar(100)  NULL,
    [Price] nvarchar(200)  NULL,
    [StartDate] datetime  NULL,
    [ExpirationDate] datetime  NOT NULL,
    [RegistrationDate] datetime  NOT NULL,
    [LastRenewal] datetime  NULL,
    [CreditTime] int  NOT NULL,
    [ReviewCount] int  NOT NULL,
    [TellTime] nvarchar(100)  NULL,
    [Link] nvarchar(1000)  NULL,
    [PaidID] bigint  NULL,
    [ShowContactForm] bit  NULL,
    [ActiveMsg] nvarchar(3000)  NULL,
    [IsHaraji] bit  NULL,
    [EndTime] nvarchar(200)  NULL,
    [LastPrice] bit  NULL,
    [ClickCount] int  NOT NULL,
    [CityID] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [IsActive] bit  NULL,
    [IsManager] bit  NULL,
    [RegisterDate] datetime  NOT NULL,
    [Mobile] nvarchar(50)  NULL,
    [Tell] nvarchar(50)  NULL,
    [Address] nvarchar(1000)  NULL,
    [IP] nvarchar(50)  NULL,
    [LastLogin] datetime  NOT NULL,
    [StateID] int  NULL,
    [CityID] int  NULL,
    [Fax] nvarchar(50)  NULL,
    [YahooID] nvarchar(100)  NULL,
    [About] nvarchar(max)  NULL,
    [PicAddress] nvarchar(100)  NULL,
    [BannedMsg] nvarchar(max)  NULL,
    [AffiliateMoney] int  NULL,
    [UserID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Tickets1'
CREATE TABLE [dbo].[Tickets1] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [Title] nvarchar(100)  NULL,
    [Text] nvarchar(max)  NULL,
    [RegDate] datetime  NULL,
    [Status] smallint  NULL,
    [Priority] nvarchar(10)  NULL,
    [IsRead] bit  NULL,
    [IsManageRead] bit  NULL,
    [Part] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL,
    [LastUpdate] datetime  NULL,
    [User_ID] int  NOT NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [ID] int  NOT NULL,
    [StateName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Payments1'
CREATE TABLE [dbo].[Payments1] (
    [RequestID] bigint IDENTITY(1,1) NOT NULL,
    [UserID] bigint  NULL,
    [AgahiID] nvarchar(1000)  NULL,
    [Title] nvarchar(1000)  NULL,
    [RegisterDate] datetime  NULL,
    [Mablagh] int  NULL,
    [IsRead] bit  NULL,
    [SanadNum] nvarchar(250)  NULL,
    [ResidNum] nvarchar(250)  NULL,
    [Status] int  NULL,
    [Name] nvarchar(50)  NULL,
    [Tel] nvarchar(50)  NULL,
    [Description] nvarchar(3000)  NULL,
    [Bank] nvarchar(50)  NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Pic] nvarchar(100)  NULL,
    [GroupName] nvarchar(max)  NOT NULL,
    [ParentID] int  NULL,
    [childGroup_ID] int  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(max)  NOT NULL,
    [StateID] int  NOT NULL,
    [State_ID] int  NOT NULL
);
GO

-- Creating table 'ContactMessages'
CREATE TABLE [dbo].[ContactMessages] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FulName] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Tell] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [Text] nvarchar(2000)  NULL,
    [Reply] nvarchar(3000)  NULL,
    [IsRead] bit  NULL,
    [RegDate] datetime  NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'AdvertisementMessages'
CREATE TABLE [dbo].[AdvertisementMessages] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [AgahiID] bigint  NULL,
    [UserID] bigint  NULL,
    [FullName] nvarchar(100)  NULL,
    [Email] nvarchar(100)  NULL,
    [Text] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [IsRead] bit  NULL,
    [Tell] nvarchar(200)  NULL,
    [Inbox] bit  NULL,
    [reply] nvarchar(max)  NULL
);
GO

-- Creating table 'Mail_User1'
CREATE TABLE [dbo].[Mail_User1] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [SenderID] bigint  NULL,
    [ReciverID] bigint  NULL,
    [QuotationID] bigint  NULL,
    [Title] nvarchar(200)  NULL,
    [Text] nvarchar(max)  NULL,
    [IsRead] bigint  NULL,
    [SenderDelete] bit  NULL,
    [ReciverDelete] bit  NULL,
    [IsAnswerd] bit  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'UserGroup'
CREATE TABLE [dbo].[UserGroup] (
    [Users_ID] int  NOT NULL,
    [Groups_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Advetisements'
ALTER TABLE [dbo].[Advetisements]
ADD CONSTRAINT [PK_Advetisements]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tickets1'
ALTER TABLE [dbo].[Tickets1]
ADD CONSTRAINT [PK_Tickets1]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [RequestID] in table 'Payments1'
ALTER TABLE [dbo].[Payments1]
ADD CONSTRAINT [PK_Payments1]
    PRIMARY KEY CLUSTERED ([RequestID] ASC);
GO

-- Creating primary key on [ID] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ContactMessages'
ALTER TABLE [dbo].[ContactMessages]
ADD CONSTRAINT [PK_ContactMessages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AdvertisementMessages'
ALTER TABLE [dbo].[AdvertisementMessages]
ADD CONSTRAINT [PK_AdvertisementMessages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Mail_User1'
ALTER TABLE [dbo].[Mail_User1]
ADD CONSTRAINT [PK_Mail_User1]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Users_ID], [Groups_ID] in table 'UserGroup'
ALTER TABLE [dbo].[UserGroup]
ADD CONSTRAINT [PK_UserGroup]
    PRIMARY KEY NONCLUSTERED ([Users_ID], [Groups_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [childGroup_ID] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_GroupGroup]
    FOREIGN KEY ([childGroup_ID])
    REFERENCES [dbo].[Groups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroup'
CREATE INDEX [IX_FK_GroupGroup]
ON [dbo].[Groups]
    ([childGroup_ID]);
GO

-- Creating foreign key on [State_ID] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_StateCity]
    FOREIGN KEY ([State_ID])
    REFERENCES [dbo].[States]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateCity'
CREATE INDEX [IX_FK_StateCity]
ON [dbo].[Cities]
    ([State_ID]);
GO

-- Creating foreign key on [UserID] in table 'Advetisements'
ALTER TABLE [dbo].[Advetisements]
ADD CONSTRAINT [FK_UserDataAdvetisement]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDataAdvetisement'
CREATE INDEX [IX_FK_UserDataAdvetisement]
ON [dbo].[Advetisements]
    ([UserID]);
GO

-- Creating foreign key on [User_ID] in table 'Tickets1'
ALTER TABLE [dbo].[Tickets1]
ADD CONSTRAINT [FK_UserTicket]
    FOREIGN KEY ([User_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTicket'
CREATE INDEX [IX_FK_UserTicket]
ON [dbo].[Tickets1]
    ([User_ID]);
GO

-- Creating foreign key on [Users_ID] in table 'UserGroup'
ALTER TABLE [dbo].[UserGroup]
ADD CONSTRAINT [FK_UserGroup_User]
    FOREIGN KEY ([Users_ID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Groups_ID] in table 'UserGroup'
ALTER TABLE [dbo].[UserGroup]
ADD CONSTRAINT [FK_UserGroup_Group]
    FOREIGN KEY ([Groups_ID])
    REFERENCES [dbo].[Groups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroup_Group'
CREATE INDEX [IX_FK_UserGroup_Group]
ON [dbo].[UserGroup]
    ([Groups_ID]);
GO

-- Creating foreign key on [SateID] in table 'Advetisements'
ALTER TABLE [dbo].[Advetisements]
ADD CONSTRAINT [FK_StateAdvetisement]
    FOREIGN KEY ([SateID])
    REFERENCES [dbo].[States]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateAdvetisement'
CREATE INDEX [IX_FK_StateAdvetisement]
ON [dbo].[Advetisements]
    ([SateID]);
GO

-- Creating foreign key on [CityID] in table 'Advetisements'
ALTER TABLE [dbo].[Advetisements]
ADD CONSTRAINT [FK_CityAdvetisement]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Cities]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CityAdvetisement'
CREATE INDEX [IX_FK_CityAdvetisement]
ON [dbo].[Advetisements]
    ([CityID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------