IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [Activities] (
        [Id] int NOT NULL IDENTITY,
        [Date] nvarchar(max) NULL,
        [NotifyOffset] nvarchar(max) NULL,
        [NotificationIsSent] bit NOT NULL,
        [Subject] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [contactPersonId] int NOT NULL,
        [CompanyId] int NOT NULL,
        [UserId] nvarchar(max) NULL,
        [companyAccountId] int NOT NULL,
        [LastEditedDate] datetime2 NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Activities] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [changePasswordRequests] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [RequestDateTime] datetime2 NOT NULL,
        [LinkRequestId] uniqueidentifier NOT NULL,
        [SendToEmail] nvarchar(max) NULL,
        CONSTRAINT [PK_changePasswordRequests] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [companyAccounts] (
        [companyAccountId] int NOT NULL IDENTITY,
        [type] nvarchar(max) NULL,
        [CompanyName] nvarchar(max) NULL,
        [Companyidentifier] nvarchar(max) NULL,
        [activationKey] uniqueidentifier NOT NULL,
        [activationDate] datetime2 NOT NULL,
        [registrationDate] datetime2 NOT NULL,
        CONSTRAINT [PK_companyAccounts] PRIMARY KEY ([companyAccountId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [ContactPersons] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [CellPhone] nvarchar(max) NULL,
        [Department] nvarchar(max) NULL,
        [CompanyId] int NOT NULL,
        [companyAccountId] int NOT NULL,
        [DineroGuiD] uniqueidentifier NOT NULL,
        [LastEditedDate] datetime2 NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_ContactPersons] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [postnumre] (
        [Id] int NOT NULL IDENTITY,
        [City] nvarchar(max) NULL,
        [Zip] nvarchar(max) NULL,
        CONSTRAINT [PK_postnumre] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [relateCompanyAccountWithRoles] (
        [id] int NOT NULL IDENTITY,
        [companyAccount] int NOT NULL,
        [role] nvarchar(max) NULL,
        CONSTRAINT [PK_relateCompanyAccountWithRoles] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [relateCompanyAccountWithUsers] (
        [id] int NOT NULL IDENTITY,
        [companyAccount] int NOT NULL,
        [user] nvarchar(max) NULL,
        [CompanyName] nvarchar(max) NULL,
        CONSTRAINT [PK_relateCompanyAccountWithUsers] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE TABLE [Companies] (
        [Id] int NOT NULL IDENTITY,
        [CVRNumber] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Street] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [Zip] nvarchar(max) NULL,
        [State] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [HomePage] nvarchar(max) NULL,
        [postalCodeId] nvarchar(max) NULL,
        [companyAccountId] int NOT NULL,
        [DineroGuiD] uniqueidentifier NOT NULL,
        [LastEditedDate] datetime2 NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Companies] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Companies_companyAccounts_companyAccountId] FOREIGN KEY ([companyAccountId]) REFERENCES [companyAccounts] ([companyAccountId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    CREATE INDEX [IX_Companies_companyAccountId] ON [Companies] ([companyAccountId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191208012857_InitilAzure')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191208012857_InitilAzure', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191211004957_usernameOnRegistration')
BEGIN
    ALTER TABLE [relateCompanyAccountWithUsers] ADD [userName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191211004957_usernameOnRegistration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191211004957_usernameOnRegistration', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213211238_aaaaaa')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Companies]') AND [c].[name] = N'Name');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Companies] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Companies] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213211238_aaaaaa')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191213211238_aaaaaa', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191214002951_bbbbbb')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContactPersons]') AND [c].[name] = N'LastName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ContactPersons] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ContactPersons] ALTER COLUMN [LastName] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191214002951_bbbbbb')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContactPersons]') AND [c].[name] = N'FirstName');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ContactPersons] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [ContactPersons] ALTER COLUMN [FirstName] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191214002951_bbbbbb')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Activities]') AND [c].[name] = N'Subject');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Activities] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Activities] ALTER COLUMN [Subject] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191214002951_bbbbbb')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Activities]') AND [c].[name] = N'NotifyOffset');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Activities] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Activities] ALTER COLUMN [NotifyOffset] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191214002951_bbbbbb')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Activities]') AND [c].[name] = N'Date');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Activities] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Activities] ALTER COLUMN [Date] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191214002951_bbbbbb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191214002951_bbbbbb', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191214124101_wswsws')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191214124101_wswsws', N'2.1.11-servicing-32099');
END;

GO

