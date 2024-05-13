IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [UserxID] int NOT NULL IDENTITY,
    [Age] int NOT NULL,
    [Name] varchar(50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserxID])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserxID', N'Age', N'Name') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserxID], [Age], [Name])
VALUES (1, 0, 'User 1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserxID', N'Age', N'Name') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240424073348_mig', N'8.0.1');
GO

COMMIT;
GO

