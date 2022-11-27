IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [Califications] (
        [Id] int NOT NULL IDENTITY,
        [Calification1] int NOT NULL,
        [Calification2] int NOT NULL,
        [Calification3] int NOT NULL,
        [CalificationFinal] int NOT NULL,
        CONSTRAINT [PK_Califications] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [Courses] (
        [Id] int NOT NULL IDENTITY,
        [NameCourse] nvarchar(max) NULL,
        [WeeklyHours] int NOT NULL,
        CONSTRAINT [PK_Courses] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [Grades] (
        [Id] int NOT NULL IDENTITY,
        [CodGrade] nvarchar(max) NULL,
        CONSTRAINT [PK_Grades] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [Lounges] (
        [Id] int NOT NULL IDENTITY,
        [NameLounge] nvarchar(max) NULL,
        [Location] nvarchar(max) NULL,
        CONSTRAINT [PK_Lounges] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [NameRole] nvarchar(max) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [TypeDocs] (
        [Id] int NOT NULL IDENTITY,
        [NameTypeDoc] nvarchar(max) NULL,
        CONSTRAINT [PK_TypeDocs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [Doc] nvarchar(max) NULL,
        [Status] bit NOT NULL,
        [IdRol] int NOT NULL,
        [IdTypeDoc] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Roles_IdRol] FOREIGN KEY ([IdRol]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Users_TypeDocs_IdTypeDoc] FOREIGN KEY ([IdTypeDoc]) REFERENCES [TypeDocs] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [AllocationLoads] (
        [Id] int NOT NULL IDENTITY,
        [DateAllocationLoad] datetime2 NOT NULL,
        [IdCourse] int NOT NULL,
        [IdUser] int NOT NULL,
        [IdGrade] int NOT NULL,
        [IdCalifications] int NOT NULL,
        CONSTRAINT [PK_AllocationLoads] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AllocationLoads_Califications_IdCalifications] FOREIGN KEY ([IdCalifications]) REFERENCES [Califications] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AllocationLoads_Courses_IdCourse] FOREIGN KEY ([IdCourse]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AllocationLoads_Grades_IdGrade] FOREIGN KEY ([IdGrade]) REFERENCES [Grades] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AllocationLoads_Users_IdUser] FOREIGN KEY ([IdUser]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [Follow_up_courses] (
        [Id] int NOT NULL IDENTITY,
        [DateFollowUp] datetime2 NOT NULL,
        [IdUser] int NOT NULL,
        [IdGrade] int NOT NULL,
        CONSTRAINT [PK_Follow_up_courses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Follow_up_courses_Grades_IdGrade] FOREIGN KEY ([IdGrade]) REFERENCES [Grades] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Follow_up_courses_Users_IdUser] FOREIGN KEY ([IdUser]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE TABLE [Schedules] (
        [Id] int NOT NULL IDENTITY,
        [Monday] nvarchar(max) NULL,
        [Tuesday] nvarchar(max) NULL,
        [Wednesday] nvarchar(max) NULL,
        [Thursday] nvarchar(max) NULL,
        [Friday] int NOT NULL,
        [IdAllocationLoad] int NOT NULL,
        CONSTRAINT [PK_Schedules] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Schedules_AllocationLoads_IdAllocationLoad] FOREIGN KEY ([IdAllocationLoad]) REFERENCES [AllocationLoads] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_AllocationLoads_IdCalifications] ON [AllocationLoads] ([IdCalifications]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_AllocationLoads_IdCourse] ON [AllocationLoads] ([IdCourse]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_AllocationLoads_IdGrade] ON [AllocationLoads] ([IdGrade]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_AllocationLoads_IdUser] ON [AllocationLoads] ([IdUser]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_Follow_up_courses_IdGrade] ON [Follow_up_courses] ([IdGrade]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_Follow_up_courses_IdUser] ON [Follow_up_courses] ([IdUser]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_Schedules_IdAllocationLoad] ON [Schedules] ([IdAllocationLoad]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_Users_IdRol] ON [Users] ([IdRol]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    CREATE INDEX [IX_Users_IdTypeDoc] ON [Users] ([IdTypeDoc]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914131102_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220914131102_Initial', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916161348_Status-Course&Grade')
BEGIN
    ALTER TABLE [Grades] ADD [Status] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916161348_Status-Course&Grade')
BEGIN
    ALTER TABLE [Courses] ADD [Status] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916161348_Status-Course&Grade')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220916161348_Status-Course&Grade', N'3.1.7');
END;

GO

