
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2013 02:33:18
-- Generated from EDMX file: C:\Users\M-R\Desktop\SE22\GroupA\Implementation\ADVIEWER\ADVIEWER\DAL\Model1.edmx
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
IF OBJECT_ID(N'[dbo].[FK_UserTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets1] DROP CONSTRAINT [FK_UserTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroup_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserGroup] DROP CONSTRAINT [FK_UserGroup_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserGroup] DROP CONSTRAINT [FK_UserGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvertismentKeyWord_Advertisment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvertismentKeyWord] DROP CONSTRAINT [FK_AdvertismentKeyWord_Advertisment];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvertismentKeyWord_KeyWord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvertismentKeyWord] DROP CONSTRAINT [FK_AdvertismentKeyWord_KeyWord];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAdvertisment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advertisments] DROP CONSTRAINT [FK_UserAdvertisment];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvertismentGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advertisments] DROP CONSTRAINT [FK_AdvertismentGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvertismentRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rates] DROP CONSTRAINT [FK_AdvertismentRating];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rates] DROP CONSTRAINT [FK_UserRating];
GO
IF OBJECT_ID(N'[dbo].[FK_StateCityAdvertisment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advertisments] DROP CONSTRAINT [FK_StateCityAdvertisment];
GO
IF OBJECT_ID(N'[dbo].[FK_StateCityStateCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StateCities] DROP CONSTRAINT [FK_StateCityStateCity];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Advertisments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Advertisments];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Tickets1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets1];
GO
IF OBJECT_ID(N'[dbo].[Payments1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments1];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
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
IF OBJECT_ID(N'[dbo].[KeyWords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KeyWords];
GO
IF OBJECT_ID(N'[dbo].[Rates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rates];
GO
IF OBJECT_ID(N'[dbo].[StateCities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StateCities];
GO
IF OBJECT_ID(N'[dbo].[UserGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroup];
GO
IF OBJECT_ID(N'[dbo].[AdvertismentKeyWord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvertismentKeyWord];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Advertisments'
CREATE TABLE [dbo].[Advertisments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NOT NULL,
    [StateCityID] int  NULL,
    [StarCount] int  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [ShortDescription] nvarchar(300)  NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Pic] nvarchar(200)  NULL,
    [IsConfirmed] bit  NOT NULL,
    [IsPaid] bit  NULL,
    [IsRead] bit  NOT NULL,
    [DenyReason] nvarchar(max)  NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [Tell] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [Address] nvarchar(1000)  NULL,
    [Email] nvarchar(100)  NOT NULL,
    [YahooID] nvarchar(100)  NULL,
    [Price] nvarchar(200)  NULL,
    [ExpirationDate] datetime  NOT NULL,
    [RegistrationDate] datetime  NOT NULL,
    [LastRenewal] datetime  NOT NULL,
    [ReviewCount] int  NOT NULL,
    [TellTime] nvarchar(100)  NOT NULL,
    [Link] nvarchar(1000)  NULL,
    [PaidID] bigint  NULL,
    [AdvDuration] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [IsManager] bit  NOT NULL,
    [RegisterDate] datetime  NOT NULL,
    [Mobile] nvarchar(50)  NULL,
    [Tell] nvarchar(50)  NULL,
    [Address] nvarchar(1000)  NULL,
    [LastLogin] datetime  NOT NULL,
    [StateID] int  NULL,
    [CityID] int  NULL,
    [Fax] nvarchar(50)  NULL,
    [YahooID] nvarchar(100)  NULL,
    [About] nvarchar(max)  NULL,
    [PicAddress] nvarchar(100)  NULL,
    [BannedMsg] nvarchar(max)  NULL,
    [UserProviderKey] uniqueidentifier  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tickets1'
CREATE TABLE [dbo].[Tickets1] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [Title] nvarchar(100)  NULL,
    [Text] nvarchar(max)  NULL,
    [RegDate] datetime  NULL,
    [Priority] nvarchar(10)  NULL,
    [IsRead] bit  NULL,
    [LastUpdate] datetime  NULL,
    [Answer] nvarchar(max)  NULL
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
    [ParentID] int  NULL
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

-- Creating table 'KeyWords'
CREATE TABLE [dbo].[KeyWords] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rates'
CREATE TABLE [dbo].[Rates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AdvertismentId] int  NOT NULL,
    [UserId] int  NULL,
    [Value] real  NOT NULL
);
GO

-- Creating table 'StateCities'
CREATE TABLE [dbo].[StateCities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StateId] int  NULL
);
GO

-- Creating table 'UserGroup'
CREATE TABLE [dbo].[UserGroup] (
    [Users_ID] int  NOT NULL,
    [Groups_ID] int  NOT NULL
);
GO

-- Creating table 'AdvertismentKeyWord'
CREATE TABLE [dbo].[AdvertismentKeyWord] (
    [Advertisment_ID] int  NOT NULL,
    [KeyWords_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Advertisments'
ALTER TABLE [dbo].[Advertisments]
ADD CONSTRAINT [PK_Advertisments]
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

-- Creating primary key on [Id] in table 'KeyWords'
ALTER TABLE [dbo].[KeyWords]
ADD CONSTRAINT [PK_KeyWords]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rates'
ALTER TABLE [dbo].[Rates]
ADD CONSTRAINT [PK_Rates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StateCities'
ALTER TABLE [dbo].[StateCities]
ADD CONSTRAINT [PK_StateCities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Users_ID], [Groups_ID] in table 'UserGroup'
ALTER TABLE [dbo].[UserGroup]
ADD CONSTRAINT [PK_UserGroup]
    PRIMARY KEY NONCLUSTERED ([Users_ID], [Groups_ID] ASC);
GO

-- Creating primary key on [Advertisment_ID], [KeyWords_Id] in table 'AdvertismentKeyWord'
ALTER TABLE [dbo].[AdvertismentKeyWord]
ADD CONSTRAINT [PK_AdvertismentKeyWord]
    PRIMARY KEY NONCLUSTERED ([Advertisment_ID], [KeyWords_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ParentID] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_GroupGroup]
    FOREIGN KEY ([ParentID])
    REFERENCES [dbo].[Groups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroup'
CREATE INDEX [IX_FK_GroupGroup]
ON [dbo].[Groups]
    ([ParentID]);
GO

-- Creating foreign key on [UserID] in table 'Tickets1'
ALTER TABLE [dbo].[Tickets1]
ADD CONSTRAINT [FK_UserTicket]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTicket'
CREATE INDEX [IX_FK_UserTicket]
ON [dbo].[Tickets1]
    ([UserID]);
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

-- Creating foreign key on [Advertisment_ID] in table 'AdvertismentKeyWord'
ALTER TABLE [dbo].[AdvertismentKeyWord]
ADD CONSTRAINT [FK_AdvertismentKeyWord_Advertisment]
    FOREIGN KEY ([Advertisment_ID])
    REFERENCES [dbo].[Advertisments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KeyWords_Id] in table 'AdvertismentKeyWord'
ALTER TABLE [dbo].[AdvertismentKeyWord]
ADD CONSTRAINT [FK_AdvertismentKeyWord_KeyWord]
    FOREIGN KEY ([KeyWords_Id])
    REFERENCES [dbo].[KeyWords]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvertismentKeyWord_KeyWord'
CREATE INDEX [IX_FK_AdvertismentKeyWord_KeyWord]
ON [dbo].[AdvertismentKeyWord]
    ([KeyWords_Id]);
GO

-- Creating foreign key on [UserId] in table 'Advertisments'
ALTER TABLE [dbo].[Advertisments]
ADD CONSTRAINT [FK_UserAdvertisment]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAdvertisment'
CREATE INDEX [IX_FK_UserAdvertisment]
ON [dbo].[Advertisments]
    ([UserId]);
GO

-- Creating foreign key on [GroupID] in table 'Advertisments'
ALTER TABLE [dbo].[Advertisments]
ADD CONSTRAINT [FK_AdvertismentGroup]
    FOREIGN KEY ([GroupID])
    REFERENCES [dbo].[Groups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvertismentGroup'
CREATE INDEX [IX_FK_AdvertismentGroup]
ON [dbo].[Advertisments]
    ([GroupID]);
GO

-- Creating foreign key on [AdvertismentId] in table 'Rates'
ALTER TABLE [dbo].[Rates]
ADD CONSTRAINT [FK_AdvertismentRating]
    FOREIGN KEY ([AdvertismentId])
    REFERENCES [dbo].[Advertisments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvertismentRating'
CREATE INDEX [IX_FK_AdvertismentRating]
ON [dbo].[Rates]
    ([AdvertismentId]);
GO

-- Creating foreign key on [UserId] in table 'Rates'
ALTER TABLE [dbo].[Rates]
ADD CONSTRAINT [FK_UserRating]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRating'
CREATE INDEX [IX_FK_UserRating]
ON [dbo].[Rates]
    ([UserId]);
GO

-- Creating foreign key on [StateCityID] in table 'Advertisments'
ALTER TABLE [dbo].[Advertisments]
ADD CONSTRAINT [FK_StateCityAdvertisment]
    FOREIGN KEY ([StateCityID])
    REFERENCES [dbo].[StateCities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateCityAdvertisment'
CREATE INDEX [IX_FK_StateCityAdvertisment]
ON [dbo].[Advertisments]
    ([StateCityID]);
GO

-- Creating foreign key on [StateId] in table 'StateCities'
ALTER TABLE [dbo].[StateCities]
ADD CONSTRAINT [FK_StateCityStateCity]
    FOREIGN KEY ([StateId])
    REFERENCES [dbo].[StateCities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateCityStateCity'
CREATE INDEX [IX_FK_StateCityStateCity]
ON [dbo].[StateCities]
    ([StateId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------