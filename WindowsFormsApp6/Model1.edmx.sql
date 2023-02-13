
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2022 23:16:19
-- Generated from EDMX file: C:\Users\Марат\source\repos\Cloth\WindowsFormsApp6\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [labass];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManagerSet] DROP CONSTRAINT [FK_UserManager];
GO
IF OBJECT_ID(N'[dbo].[FK_UserBuyer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuyerSet] DROP CONSTRAINT [FK_UserBuyer];
GO
IF OBJECT_ID(N'[dbo].[FK_BuyerManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManagerSet] DROP CONSTRAINT [FK_BuyerManager];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerPokupka]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PokupkaSet] DROP CONSTRAINT [FK_ManagerPokupka];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[ManagerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManagerSet];
GO
IF OBJECT_ID(N'[dbo].[BuyerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuyerSet];
GO
IF OBJECT_ID(N'[dbo].[PokupkaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PokupkaSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ManagerSet'
CREATE TABLE [dbo].[ManagerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Salary] nvarchar(max)  NOT NULL,
    [User_Id] int  NULL,
    [Buyer_Id] int  NULL
);
GO

-- Creating table 'BuyerSet'
CREATE TABLE [dbo].[BuyerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Pasport] nvarchar(max)  NOT NULL,
    [User_Id] int  NULL
);
GO

-- Creating table 'PokupkaSet'
CREATE TABLE [dbo].[PokupkaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tovar] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [Manager_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [PK_ManagerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BuyerSet'
ALTER TABLE [dbo].[BuyerSet]
ADD CONSTRAINT [PK_BuyerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PokupkaSet'
ALTER TABLE [dbo].[PokupkaSet]
ADD CONSTRAINT [PK_PokupkaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [FK_UserManager]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserManager'
CREATE INDEX [IX_FK_UserManager]
ON [dbo].[ManagerSet]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'BuyerSet'
ALTER TABLE [dbo].[BuyerSet]
ADD CONSTRAINT [FK_UserBuyer]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBuyer'
CREATE INDEX [IX_FK_UserBuyer]
ON [dbo].[BuyerSet]
    ([User_Id]);
GO

-- Creating foreign key on [Buyer_Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [FK_BuyerManager]
    FOREIGN KEY ([Buyer_Id])
    REFERENCES [dbo].[BuyerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuyerManager'
CREATE INDEX [IX_FK_BuyerManager]
ON [dbo].[ManagerSet]
    ([Buyer_Id]);
GO

-- Creating foreign key on [Manager_Id] in table 'PokupkaSet'
ALTER TABLE [dbo].[PokupkaSet]
ADD CONSTRAINT [FK_ManagerPokupka]
    FOREIGN KEY ([Manager_Id])
    REFERENCES [dbo].[ManagerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerPokupka'
CREATE INDEX [IX_FK_ManagerPokupka]
ON [dbo].[PokupkaSet]
    ([Manager_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------