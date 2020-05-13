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
    VALUES (N'20191208012857_InitilAzure', N'3.1.4');
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
    VALUES (N'20191211004957_usernameOnRegistration', N'3.1.4');
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
    VALUES (N'20191213211238_aaaaaa', N'3.1.4');
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
    VALUES (N'20191214002951_bbbbbb', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191214124101_wswsws')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191214124101_wswsws', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191220040029_cleaning')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191220040029_cleaning', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111170344_vendor')
BEGIN
    CREATE TABLE [Vendors] (
        [Id] int NOT NULL IDENTITY,
        [CVRNumber] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
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
        CONSTRAINT [PK_Vendors] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Vendors_companyAccounts_companyAccountId] FOREIGN KEY ([companyAccountId]) REFERENCES [companyAccounts] ([companyAccountId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111170344_vendor')
BEGIN
    CREATE INDEX [IX_Vendors_companyAccountId] ON [Vendors] ([companyAccountId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111170344_vendor')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200111170344_vendor', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200112170230_CompanySettings')
BEGIN
    ALTER TABLE [companyAccounts] ADD [IntegartionDinero] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200112170230_CompanySettings')
BEGIN
    ALTER TABLE [companyAccounts] ADD [SubscriptionCRM] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200112170230_CompanySettings')
BEGIN
    ALTER TABLE [companyAccounts] ADD [SubscriptionInventory] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200112170230_CompanySettings')
BEGIN
    ALTER TABLE [companyAccounts] ADD [SubscriptionProcurement] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200112170230_CompanySettings')
BEGIN
    ALTER TABLE [companyAccounts] ADD [SubscriptionVendor] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200112170230_CompanySettings')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200112170230_CompanySettings', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200112171531_ny')
BEGIN
    EXEC sp_rename N'[companyAccounts].[IntegartionDinero]', N'IntegrationDinero', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200112171531_ny')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200112171531_ny', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200121194113_stockItems1')
BEGIN
    CREATE TABLE [stockItems] (
        [Id] int NOT NULL IDENTITY,
        [ItemName] nvarchar(max) NULL,
        [ItemNumber] nvarchar(max) NULL,
        [NumberInStock] int NOT NULL,
        [Location] nvarchar(max) NULL,
        [Category] nvarchar(max) NULL,
        [VendorId] int NOT NULL,
        [VendorItemNumber] nvarchar(max) NULL,
        [Expirationdate] datetime2 NOT NULL,
        [InStockAgainDate] datetime2 NOT NULL,
        [CostPrice] decimal(18,4) NOT NULL,
        [SalesPrice] decimal(18,4) NOT NULL,
        CONSTRAINT [PK_stockItems] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200121194113_stockItems1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200121194113_stockItems1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200121194402_stockitems3')
BEGIN
    ALTER TABLE [stockItems] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200121194402_stockitems3')
BEGIN
    ALTER TABLE [stockItems] ADD [LastEditedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200121194402_stockitems3')
BEGIN
    ALTER TABLE [stockItems] ADD [companyAccountId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200121194402_stockitems3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200121194402_stockitems3', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200124001221_decimal2aftercomma')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[stockItems]') AND [c].[name] = N'SalesPrice');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [stockItems] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [stockItems] ALTER COLUMN [SalesPrice] decimal(18,2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200124001221_decimal2aftercomma')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[stockItems]') AND [c].[name] = N'CostPrice');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [stockItems] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [stockItems] ALTER COLUMN [CostPrice] decimal(18,2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200124001221_decimal2aftercomma')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200124001221_decimal2aftercomma', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200125232922_stockvalue')
BEGIN
    ALTER TABLE [stockItems] ADD [StockValue] decimal(18,2) NOT NULL DEFAULT 0.0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200125232922_stockvalue')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200125232922_stockvalue', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200127131214_stockitemexpand')
BEGIN
    ALTER TABLE [stockItems] ADD [DineroGuiD] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200127131214_stockitemexpand')
BEGIN
    ALTER TABLE [stockItems] ADD [Unit] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200127131214_stockitemexpand')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200127131214_stockitemexpand', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131001949_reorderQuantityAdded')
BEGIN
    ALTER TABLE [stockItems] ADD [ReorderNumberInStock] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200131001949_reorderQuantityAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200131001949_reorderQuantityAdded', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200201033248_stockitemcategories')
BEGIN
    CREATE TABLE [stockItemCategory1s] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_stockItemCategory1s] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200201033248_stockitemcategories')
BEGIN
    CREATE TABLE [stockItemCategory2s] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Category1Id] nvarchar(max) NULL,
        CONSTRAINT [PK_stockItemCategory2s] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200201033248_stockitemcategories')
BEGIN
    CREATE TABLE [stockItemCategory3s] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Category2Id] nvarchar(max) NULL,
        CONSTRAINT [PK_stockItemCategory3s] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200201033248_stockitemcategories')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200201033248_stockitemcategories', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200201180054_noget')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[stockItemCategory3s]') AND [c].[name] = N'Category2Id');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [stockItemCategory3s] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [stockItemCategory3s] ALTER COLUMN [Category2Id] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200201180054_noget')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[stockItemCategory2s]') AND [c].[name] = N'Category1Id');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [stockItemCategory2s] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [stockItemCategory2s] ALTER COLUMN [Category1Id] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200201180054_noget')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200201180054_noget', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200202060002_aaa')
BEGIN
    ALTER TABLE [stockItemCategory3s] ADD [companyAccountId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200202060002_aaa')
BEGIN
    ALTER TABLE [stockItemCategory2s] ADD [companyAccountId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200202060002_aaa')
BEGIN
    ALTER TABLE [stockItemCategory1s] ADD [companyAccountId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200202060002_aaa')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200202060002_aaa', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200202193723_aaaxyzx')
BEGIN
    ALTER TABLE [stockItems] ADD [category1Id] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200202193723_aaaxyzx')
BEGIN
    ALTER TABLE [stockItems] ADD [category2Id] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200202193723_aaaxyzx')
BEGIN
    ALTER TABLE [stockItems] ADD [category3Id] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200202193723_aaaxyzx')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200202193723_aaaxyzx', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200205104926_nogetXXXXXX')
BEGIN
    ALTER TABLE [companyAccounts] ADD [DineroAPIOrganization] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200205104926_nogetXXXXXX')
BEGIN
    ALTER TABLE [companyAccounts] ADD [DineroAPIOrganizationKey] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200205104926_nogetXXXXXX')
BEGIN
    ALTER TABLE [companyAccounts] ADD [SalesStatistic] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200205104926_nogetXXXXXX')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200205104926_nogetXXXXXX', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216073154_jobservicetype')
BEGIN
    CREATE TABLE [jobServiceTypes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Desciption] nvarchar(max) NULL,
        [companyAccountId] int NOT NULL,
        CONSTRAINT [PK_jobServiceTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216073154_jobservicetype')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200216073154_jobservicetype', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216075411_bookingresource')
BEGIN
    CREATE TABLE [BookingResources] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [Jobdesciption] nvarchar(max) NULL,
        [EmailForCalendar] nvarchar(max) NULL,
        [companyAccountId] int NOT NULL,
        [LastEditedDate] datetime2 NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_BookingResources] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216075411_bookingresource')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200216075411_bookingresource', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216202120_bookingresourceagain')
BEGIN
    ALTER TABLE [jobServiceTypes] ADD [BookingResourceId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216202120_bookingresourceagain')
BEGIN
    CREATE INDEX [IX_jobServiceTypes_BookingResourceId] ON [jobServiceTypes] ([BookingResourceId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216202120_bookingresourceagain')
BEGIN
    ALTER TABLE [jobServiceTypes] ADD CONSTRAINT [FK_jobServiceTypes_BookingResources_BookingResourceId] FOREIGN KEY ([BookingResourceId]) REFERENCES [BookingResources] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216202120_bookingresourceagain')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200216202120_bookingresourceagain', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216202824_bookingresourceagain1')
BEGIN
    EXEC sp_rename N'[BookingResources].[Jobdesciption]', N'JobDescription', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216202824_bookingresourceagain1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200216202824_bookingresourceagain1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216215125_bookingresourceagain2')
BEGIN
    ALTER TABLE [jobServiceTypes] DROP CONSTRAINT [FK_jobServiceTypes_BookingResources_BookingResourceId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216215125_bookingresourceagain2')
BEGIN
    DROP INDEX [IX_jobServiceTypes_BookingResourceId] ON [jobServiceTypes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216215125_bookingresourceagain2')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[jobServiceTypes]') AND [c].[name] = N'BookingResourceId');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [jobServiceTypes] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [jobServiceTypes] DROP COLUMN [BookingResourceId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216215125_bookingresourceagain2')
BEGIN
    ALTER TABLE [BookingResources] ADD [JobServiceTypes] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216215125_bookingresourceagain2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200216215125_bookingresourceagain2', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216230258_bookingsetup')
BEGIN
    ALTER TABLE [companyAccounts] ADD [Booking] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200216230258_bookingsetup')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200216230258_bookingsetup', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220225612_calendar')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[jobServiceTypes]') AND [c].[name] = N'Name');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [jobServiceTypes] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [jobServiceTypes] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220225612_calendar')
BEGIN
    CREATE TABLE [CalendarEntries] (
        [id] int NOT NULL IDENTITY,
        [caleventid] nvarchar(max) NULL,
        [selectallday] bit NOT NULL,
        [startDateTime] datetime2 NOT NULL,
        [endDateTime] datetime2 NOT NULL,
        [description] nvarchar(max) NULL,
        [repeatingId] int NOT NULL,
        [selectRepeat] bit NOT NULL,
        [startDateTimeRange] datetime2 NOT NULL,
        [endDateTimeRange] datetime2 NOT NULL,
        [rangeWeekDays] nvarchar(max) NULL,
        CONSTRAINT [PK_CalendarEntries] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220225612_calendar')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200220225612_calendar', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221000326_calendar1')
BEGIN
    ALTER TABLE [CalendarEntries] ADD [companyAccountId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221000326_calendar1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200221000326_calendar1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200222080017_aabbcc')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CalendarEntries]') AND [c].[name] = N'caleventid');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [CalendarEntries] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [CalendarEntries] DROP COLUMN [caleventid];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200222080017_aabbcc')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200222080017_aabbcc', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200225091943_calendarOwnerID')
BEGIN
    ALTER TABLE [CalendarEntries] ADD [CalendarEventResourceOwnerId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200225091943_calendarOwnerID')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200225091943_calendarOwnerID', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200225194738_eventcolor')
BEGIN
    ALTER TABLE [CalendarEntries] ADD [EventColor] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200225194738_eventcolor')
BEGIN
    ALTER TABLE [BookingResources] ADD [CalendarEventsColor] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200225194738_eventcolor')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200225194738_eventcolor', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200302211414_nogetCalendar')
BEGIN
    ALTER TABLE [CalendarEntries] ADD [IsFromResourceCalendar] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200302211414_nogetCalendar')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200302211414_nogetCalendar', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200302233319_sgu')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CalendarEntries]') AND [c].[name] = N'EventColor');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [CalendarEntries] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [CalendarEntries] DROP COLUMN [EventColor];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200302233319_sgu')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200302233319_sgu', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200303074243_gggHHHvvv')
BEGIN
    CREATE TABLE [BookingServices] (
        [id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [ProductNumber] nvarchar(max) NULL,
        [durationInMinutes] int NOT NULL,
        [IsBookable] bit NOT NULL,
        [GapTimeBeforeInMinutes] int NOT NULL,
        [GapTimeAfterInMinutes] int NOT NULL,
        [SalesPrice] decimal(18,2) NOT NULL,
        [LastEditedDate] datetime2 NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [companyAccountId] int NULL,
        [DineroGuiD] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_BookingServices] PRIMARY KEY ([id]),
        CONSTRAINT [FK_BookingServices_companyAccounts_companyAccountId] FOREIGN KEY ([companyAccountId]) REFERENCES [companyAccounts] ([companyAccountId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200303074243_gggHHHvvv')
BEGIN
    CREATE INDEX [IX_BookingServices_companyAccountId] ON [BookingServices] ([companyAccountId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200303074243_gggHHHvvv')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200303074243_gggHHHvvv', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200303075247_gggHHHvvvhh')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BookingServices]') AND [c].[name] = N'SalesPrice');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [BookingServices] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [BookingServices] ALTER COLUMN [SalesPrice] decimal(18,2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200303075247_gggHHHvvvhh')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200303075247_gggHHHvvvhh', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304020248_gfetajd')
BEGIN
    ALTER TABLE [BookingServices] DROP CONSTRAINT [FK_BookingServices_companyAccounts_companyAccountId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304020248_gfetajd')
BEGIN
    DROP INDEX [IX_BookingServices_companyAccountId] ON [BookingServices];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304020248_gfetajd')
BEGIN
    ALTER TABLE [jobServiceTypes] ADD [BookingServicesIds] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304020248_gfetajd')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BookingServices]') AND [c].[name] = N'companyAccountId');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [BookingServices] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [BookingServices] ALTER COLUMN [companyAccountId] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304020248_gfetajd')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200304020248_gfetajd', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304185355_bookingsetupforuser')
BEGIN
    CREATE TABLE [BookingSetups] (
        [Id] int NOT NULL IDENTITY,
        [MondayOfficeStartTime] datetime2 NOT NULL,
        [TuesdayOfficeStartTime] datetime2 NOT NULL,
        [WednesdayOfficeStartTime] datetime2 NOT NULL,
        [ThursdayOfficeStartTime] datetime2 NOT NULL,
        [FridayOfficeStartTime] datetime2 NOT NULL,
        [SaturdayOfficeStartTime] datetime2 NOT NULL,
        [SunOfficeStartTime] datetime2 NOT NULL,
        [MondayOfficeEndTime] datetime2 NOT NULL,
        [TuesdayOfficeEndTime] datetime2 NOT NULL,
        [WednesdayOfficeEndTime] datetime2 NOT NULL,
        [ThursdayOfficeEndTime] datetime2 NOT NULL,
        [FridayOfficeEndTime] datetime2 NOT NULL,
        [SaturdayOfficeEndTime] datetime2 NOT NULL,
        [SunOfficeEndTime] datetime2 NOT NULL,
        CONSTRAINT [PK_BookingSetups] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304185355_bookingsetupforuser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200304185355_bookingsetupforuser', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304211908_bookingsetupforusera')
BEGIN
    EXEC sp_rename N'[BookingSetups].[SunOfficeStartTime]', N'SundayOfficeStartTime', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304211908_bookingsetupforusera')
BEGIN
    EXEC sp_rename N'[BookingSetups].[SunOfficeEndTime]', N'SundayOfficeEndTime', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304211908_bookingsetupforusera')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200304211908_bookingsetupforusera', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304215537_bookingsetupforuserab')
BEGIN
    ALTER TABLE [BookingSetups] ADD [companyAccountId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200304215537_bookingsetupforuserab')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200304215537_bookingsetupforuserab', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200305064523_bookinginterval')
BEGIN
    ALTER TABLE [BookingSetups] ADD [BookingFreeTimeInterval] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200305064523_bookinginterval')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200305064523_bookinginterval', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308214503_isPerson')
BEGIN
    ALTER TABLE [Companies] ADD [IsPerson] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308214503_isPerson')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200308214503_isPerson', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308231118_isPersonEmail')
BEGIN
    ALTER TABLE [Companies] ADD [Email] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308231118_isPersonEmail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200308231118_isPersonEmail', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200309222518_bookingapikey')
BEGIN
    ALTER TABLE [BookingSetups] ADD [BookingAPIkey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200309222518_bookingapikey')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200309222518_bookingapikey', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200309225752_bookingapikey1')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BookingSetups]') AND [c].[name] = N'BookingAPIkey');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [BookingSetups] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [BookingSetups] ALTER COLUMN [BookingAPIkey] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200309225752_bookingapikey1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200309225752_bookingapikey1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200311213249_bookingItSelf')
BEGIN
    ALTER TABLE [Companies] ADD [SMSverificationCode] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200311213249_bookingItSelf')
BEGIN
    ALTER TABLE [CalendarEntries] ADD [customerId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200311213249_bookingItSelf')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200311213249_bookingItSelf', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321095125_sync')
BEGIN
    ALTER TABLE [companyAccounts] ADD [ContactsLastSynchronizationDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321095125_sync')
BEGIN
    ALTER TABLE [companyAccounts] ADD [StockItemsLastSynchronizationDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321095125_sync')
BEGIN
    ALTER TABLE [companyAccounts] ADD [VendorsItemsLastSynchronizationDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321095125_sync')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200321095125_sync', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321210713_sync1')
BEGIN
    EXEC sp_rename N'[companyAccounts].[VendorsItemsLastSynchronizationDate]', N'VendorsItemsToDineroLastSynchronizationDate', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321210713_sync1')
BEGIN
    EXEC sp_rename N'[companyAccounts].[StockItemsLastSynchronizationDate]', N'StockItemsToDineroLastSynchronizationDate', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321210713_sync1')
BEGIN
    EXEC sp_rename N'[companyAccounts].[ContactsLastSynchronizationDate]', N'ContactsToNyxiumLastSynchronizationDate', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321210713_sync1')
BEGIN
    ALTER TABLE [companyAccounts] ADD [ContactsToDineroLastSynchronizationDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200321210713_sync1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200321210713_sync1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200322100843_wuabdujf')
BEGIN
    ALTER TABLE [companyAccounts] ADD [synchronizeCustomerFromDineroToNyxium] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200322100843_wuabdujf')
BEGIN
    ALTER TABLE [companyAccounts] ADD [synchronizeCustomerFromNyxiumToDinero] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200322100843_wuabdujf')
BEGIN
    ALTER TABLE [companyAccounts] ADD [synchronizeStockItemFromDineroToNyxium] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200322100843_wuabdujf')
BEGIN
    ALTER TABLE [companyAccounts] ADD [synchronizeStockItemFromNyxiumToDinero] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200322100843_wuabdujf')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200322100843_wuabdujf', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200324215332_synchStockItems')
BEGIN
    ALTER TABLE [companyAccounts] ADD [StockItemsToNyxiumSynchronizationDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200324215332_synchStockItems')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200324215332_synchStockItems', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326092022_licensetypes')
BEGIN
    CREATE TABLE [LicenseTypes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [SalesPriceMonthlyPayment] decimal(18,2) NOT NULL,
        [SalesPriceAnnualPayment] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_LicenseTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326092022_licensetypes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200326092022_licensetypes', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326105544_licensetypesAggain')
BEGIN
    EXEC sp_rename N'[companyAccounts].[type]', N'NyxiumLicenseTypeName', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326105544_licensetypesAggain')
BEGIN
    ALTER TABLE [companyAccounts] ADD [AmountToPayForLicense] decimal(18,2) NOT NULL DEFAULT 0.0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326105544_licensetypesAggain')
BEGIN
    ALTER TABLE [companyAccounts] ADD [NyxiumLicenseTypeId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326105544_licensetypesAggain')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200326105544_licensetypesAggain', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200331070349_countrycode')
BEGIN
    ALTER TABLE [Companies] ADD [CountryCode] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200331070349_countrycode')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200331070349_countrycode', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200331075558_countrycode1')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Companies]') AND [c].[name] = N'State');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Companies] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Companies] DROP COLUMN [State];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200331075558_countrycode1')
BEGIN
    CREATE TABLE [Countries] (
        [Id] int NOT NULL IDENTITY,
        [CountryCode] nvarchar(max) NULL,
        [CountryName] nvarchar(max) NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200331075558_countrycode1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200331075558_countrycode1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200331100516_countryCodeVendor')
BEGIN
    EXEC sp_rename N'[Vendors].[State]', N'CountryCode', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200331100516_countryCodeVendor')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200331100516_countryCodeVendor', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408065246_notes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200408065246_notes', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408094304_notes1')
BEGIN
    CREATE TABLE [Notes] (
        [Id] int NOT NULL IDENTITY,
        [Subject] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        [AttachedFileName] nvarchar(max) NULL,
        [contactPersonId] int NOT NULL,
        [CompanyId] int NOT NULL,
        [Date] datetime2 NOT NULL,
        [companyAccountId] int NOT NULL,
        [LastEditedDate] datetime2 NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Notes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408094304_notes1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200408094304_notes1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408215605_notes2')
BEGIN
    EXEC sp_rename N'[Notes].[AttachedFileName]', N'FileNameOnly', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408215605_notes2')
BEGIN
    ALTER TABLE [Notes] ADD [AttachedFileNameAndPath] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408215605_notes2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200408215605_notes2', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200409082112_noter1')
BEGIN
    EXEC sp_rename N'[Notes].[FileNameOnly]', N'FileNamesOnly', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200409082112_noter1')
BEGIN
    EXEC sp_rename N'[Notes].[AttachedFileNameAndPath]', N'AttachedFilesNameAndPath', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200409082112_noter1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200409082112_noter1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200409185100_Attachment')
BEGIN
    ALTER TABLE [Notes] ADD [ContentTypes] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200409185100_Attachment')
BEGIN
    CREATE TABLE [Attachments] (
        [Id] int NOT NULL IDENTITY,
        [OriginalFileName] nvarchar(max) NULL,
        [companyAccountId] int NOT NULL,
        [uniqueInternalFileName] nvarchar(max) NULL,
        [length] bigint NOT NULL,
        [ContentType] nvarchar(max) NULL,
        CONSTRAINT [PK_Attachments] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200409185100_Attachment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200409185100_Attachment', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200409190219_Attachment1')
BEGIN
    ALTER TABLE [Notes] ADD [AttachedmentIds] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200409190219_Attachment1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200409190219_Attachment1', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200410204538_attachmentIcons')
BEGIN
    ALTER TABLE [Notes] ADD [IconsFilePathAndName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200410204538_attachmentIcons')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200410204538_attachmentIcons', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411112710_contenttypes')
BEGIN
    CREATE TABLE [ContentTypes] (
        [Type] nvarchar(450) NOT NULL,
        [FileExtension] nvarchar(max) NULL,
        [IconFileName] nvarchar(max) NULL,
        CONSTRAINT [PK_ContentTypes] PRIMARY KEY ([Type])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411112710_contenttypes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200411112710_contenttypes', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425110044_activitydatefromstringtodate')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Activities]') AND [c].[name] = N'Date');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Activities] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Activities] ALTER COLUMN [Date] datetime2 NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425110044_activitydatefromstringtodate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200425110044_activitydatefromstringtodate', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200426090802_logoncompanyaccount')
BEGIN
    ALTER TABLE [companyAccounts] ADD [LogoAttachmentIds] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200426090802_logoncompanyaccount')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200426090802_logoncompanyaccount', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513075704_paymentconditions')
BEGIN
    ALTER TABLE [Companies] ADD [PaymentConditions] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513075704_paymentconditions')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200513075704_paymentconditions', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513163928_foreignZipAndCity')
BEGIN
    ALTER TABLE [Companies] ADD [ForeignCity] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513163928_foreignZipAndCity')
BEGIN
    ALTER TABLE [Companies] ADD [ForeignZip] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513163928_foreignZipAndCity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200513163928_foreignZipAndCity', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513212238_vendorForeignZipCity')
BEGIN
    ALTER TABLE [Vendors] ADD [ForeignCity] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513212238_vendorForeignZipCity')
BEGIN
    ALTER TABLE [Vendors] ADD [ForeignZip] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513212238_vendorForeignZipCity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200513212238_vendorForeignZipCity', N'3.1.4');
END;

GO

