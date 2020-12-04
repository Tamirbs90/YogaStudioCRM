IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE TABLE [Months] (
        [Id] int NOT NULL,
        [MonthName] longtext CHARACTER SET utf8mb4 NULL,
        [Year] longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT [PK_Months] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE TABLE [Persons] (
        [Id] int NOT NULL,
        [Name] longtext CHARACTER SET utf8mb4 NULL,
        [Phone] longtext CHARACTER SET utf8mb4 NULL,
        [Birthday] longtext CHARACTER SET utf8mb4 NULL,
        [TotalPaid] int NOT NULL,
        [Debt] int NOT NULL,
        [IsActive] tinyint(1) NOT NULL,
        [Level] int NOT NULL,
        CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE TABLE [Weeks] (
        [Id] int NOT NULL,
        [StartingDate] datetime(6) NOT NULL,
        [EndDate] datetime(6) NOT NULL,
        [MonthId] int NULL,
        CONSTRAINT [PK_Weeks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Weeks_Months_MonthId] FOREIGN KEY ([MonthId]) REFERENCES [Months] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE TABLE [ClassesPartipciations] (
        [Id] int NOT NULL,
        [Date] longtext CHARACTER SET utf8mb4 NULL,
        [Paid] int NOT NULL,
        [Debt] int NOT NULL,
        [PersonId] int NOT NULL,
        [MonthId] int NULL,
        CONSTRAINT [PK_ClassesPartipciations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ClassesPartipciations_Months_MonthId] FOREIGN KEY ([MonthId]) REFERENCES [Months] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ClassesPartipciations_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE TABLE [YogaLessons] (
        [Id] int NOT NULL,
        [Day] int NOT NULL,
        [StartingTime] datetime(6) NOT NULL,
        [EndTime] datetime(6) NOT NULL,
        [ClassLevel] int NOT NULL,
        [WeekId] int NULL,
        CONSTRAINT [PK_YogaLessons] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_YogaLessons_Weeks_WeekId] FOREIGN KEY ([WeekId]) REFERENCES [Weeks] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE TABLE [StudentsInClass] (
        [Id] int NOT NULL,
        [StudentId] int NULL,
        [Participated] tinyint(1) NOT NULL,
        [YogaLessonId] int NULL,
        CONSTRAINT [PK_StudentsInClass] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_StudentsInClass_Persons_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_StudentsInClass_YogaLessons_YogaLessonId] FOREIGN KEY ([YogaLessonId]) REFERENCES [YogaLessons] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE INDEX [IX_ClassesPartipciations_MonthId] ON [ClassesPartipciations] ([MonthId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE INDEX [IX_ClassesPartipciations_PersonId] ON [ClassesPartipciations] ([PersonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE INDEX [IX_StudentsInClass_StudentId] ON [StudentsInClass] ([StudentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE INDEX [IX_StudentsInClass_YogaLessonId] ON [StudentsInClass] ([YogaLessonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE INDEX [IX_Weeks_MonthId] ON [Weeks] ([MonthId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    CREATE INDEX [IX_YogaLessons_WeekId] ON [YogaLessons] ([WeekId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201016102423_mysqlInit')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201016102423_mysqlInit', N'3.1.8');
END;

GO

