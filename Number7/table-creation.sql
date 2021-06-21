CREATE TABLE [dbo].[Teacher]
(
    [Id] [int] IDENTITY(1, 1) NOT NULL,
    [FirstName] [nvarchar](100) NOT NULL,
    [LastName] [nvarchar](100) NOT NULL,
    [Gender] [nvarchar](100) NULL,
    [Subject] [nvarchar](100) NOT NULL,
    CONSTRAINT [PK_Teacher]
        PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE TABLE [dbo].[Pupil]
(
    [Id] [int] IDENTITY(1, 1) NOT NULL,
    [FirstName] [nvarchar](100) NOT NULL,
    [LastName] [nvarchar](100) NOT NULL,
    [Gender] [nvarchar](100) NULL,
    [Class] [int] NOT NULL,
    CONSTRAINT [PK_Pupil]
        PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE TABLE [dbo].[Teacher_Pupil_Mapping]
(
    [TeacherId] [int] NOT NULL,
    [PupilId] [int] NOT NULL,
    CONSTRAINT [PK_Teacher_Pupil_Mapping]
        PRIMARY KEY CLUSTERED (
                                  [TeacherId] ASC,
                                  [PupilId] ASC
                              )
)
GO

ALTER TABLE [dbo].[Teacher_Pupil_Mapping]
ADD CONSTRAINT [FK_Teacher_Pupil_Mapping_Pupil]
    FOREIGN KEY ([PupilId])
    REFERENCES [dbo].[Pupil] ([Id])
GO

ALTER TABLE [dbo].[Teacher_Pupil_Mapping]
ADD CONSTRAINT [FK_Teacher_Pupil_Mapping_Teacher]
    FOREIGN KEY ([TeacherId])
    REFERENCES [dbo].[Teacher] ([Id])
GO